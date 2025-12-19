Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports iTextSharp.text.pdf
Imports Newtonsoft.Json

Public Class FrmCierreCaja

    Dim BancoTableAdapter As DataSet_catalogoTableAdapters.bancoTableAdapter = New DataSet_catalogoTableAdapters.bancoTableAdapter
    Dim tbaVwPosDocumentoDetPago As vw_pos_documentoDetPagoTableAdapter = New vw_pos_documentoDetPagoTableAdapter
    Dim tbaVwPosCierreCajaCab As vw_pos_cierreCaja_cabTableAdapter = New vw_pos_cierreCaja_cabTableAdapter
    Dim tbaVwPosCierreCajaDet As vw_pos_cierreCaja_detTableAdapterCustom = New vw_pos_cierreCaja_detTableAdapterCustom
    Dim tbaPosDocumentoDetPago As pos_documentoDetPagoTableAdapter = New pos_documentoDetPagoTableAdapter
    Dim tbaPosCierreCajaCab As pos_cierreCaja_cabTableAdapter = New pos_cierreCaja_cabTableAdapter
    Dim tbaPosCierreCajaDet As pos_cierreCaja_detTableAdapter = New pos_cierreCaja_detTableAdapter
    Dim tbaSPPosCierreCajaActualizarTotales As sp_pos_cierreCaja_actualizarTotalesTableAdapter = New sp_pos_cierreCaja_actualizarTotalesTableAdapter
    Dim tbaPosCierreCajaTotales As pos_cierreCaja_totalesTableAdapter = New pos_cierreCaja_totalesTableAdapter
    Dim tbaSpPosCierreCajaActualizarEstado As sp_pos_cierreCaja_actualizarEstadoTableAdapter = New sp_pos_cierreCaja_actualizarEstadoTableAdapter
    Dim tbaPosAccionUsuario As pos_accionUsuarioTableAdapter = New pos_accionUsuarioTableAdapter

    Dim dtbBanco As DataTable = Nothing
    Dim dtbVwPosDocumentoDetPago As DataTable = Nothing
    Dim dtbPosCajaMovimiento As DataTable = Nothing
    Dim dtbVwPosCierreCajaCab As DataTable = Nothing
    Dim dtbVwPosCierreCajaDet As DataTable = Nothing
    Dim dtbPosCierreCajaCab As DataTable = Nothing
    Dim dtbPosCierreCajaTotales As DataTable = Nothing

    Public frmPadre As FrmPrincipal
    Public frmPadreAngosto As FrmPrincipalAngosto

    Dim TimerActualizarCierresCaja As System.Threading.Timer
    Delegate Sub DelActualizarGrillaCierresCaja()

    Dim formatoNumero As String = "$ {0:#,##0}"
    Dim numeroCierreCaja As Integer = 0
    Dim fechaCierreCaja As Date = Now
    Dim nbfInfo As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo() With {.NumberDecimalSeparator = ",", .NumberGroupSeparator = "."}
    Dim bolAgregandoDeposito As Boolean = False

    Private Sub FrmCierreCaja_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call limpiarTotales()

        lblDiferenciaFondoFijo.Text = lblTotalFondoFijo.Text
        lblFondoFijoDiferencia.Text = lblTotalFondoFijo.Text

        lblDiferenciaEfectivo.Text = lblTotalEfectivo.Text
        lblEfectivoDiferencia.Text = lblTotalEfectivo.Text

        lblDiferenciaCheques.Text = lblTotalCheques.Text
        lblChequeDiferencia.Text = lblTotalCheques.Text

        lblDiferenciaTC.Text = lblTotalTC.Text
        lblTCDiferencia.Text = lblTotalTC.Text

        lblDiferenciaTD.Text = lblTotalTD.Text
        lblTDDiferencia.Text = lblTotalTD.Text

        lblDiferenciaTransferencia.Text = lblTotalTransferencia.Text
        lblTransferenciaDiferencia.Text = lblTotalTransferencia.Text

        dtbBanco = BancoTableAdapter.GetData()

        Dim dtvBanco As DataView = New DataView(dtbBanco, "bc_id = 4", "", DataViewRowState.CurrentRows)

        cmbBancoEfectivo.DisplayMember = "bc_nombre"
        cmbBancoEfectivo.ValueMember = "bc_id"
        cmbBancoEfectivo.DataSource = dtvBanco

        cmbBancoCheques.DisplayMember = "bc_nombre"
        cmbBancoCheques.ValueMember = "bc_id"
        cmbBancoCheques.DataSource = dtvBanco

        lbTituloCierreCaja.Text = "Cierre Caja " & numeroCierreCaja & " - " & Now.ToString("dd/MM/yyyy")

        Call ActualizarGrillaCierreCabecera()

        If dtbVwPosCierreCajaCab.Rows.Count > 0 Then
            numeroCierreCaja = dtbVwPosCierreCajaCab.Rows(0).Item("pcc_ID")

            If dtbVwPosCierreCajaCab.Rows(0).Item("pcce_ID") <> 2 Then '2 = por aprobación
                Call ActualizarGrillasDetalle(numeroCierreCaja)
                Call ActualizarGrillaCierreDetalle(numeroCierreCaja)

            End If

        End If

        cmbBancoEfectivo.SelectedIndex = 0
        cmbBancoCheques.SelectedIndex = 0

        Call ActualizarTotales()
        Call PosicionarControles()
    End Sub

    Private Sub PosicionarControles()
        DgvCierresCaja.Width = Math.Round(Me.Width * 0.97)
        TbcCierreCaja.Width = Math.Round(Me.Width * 0.97)
        DgvChequesDeposito.Width = Math.Round(Me.Width * 0.57)
        DgvCierresCaja.Height = Math.Round(Me.Height * 0.22)
        TbcCierreCaja.Height = Math.Round(Me.Height * 0.65)

        btnCerrarCierreCaja.Location = New Point(DgvCierresCaja.Location.X, DgvCierresCaja.Top + DgvCierresCaja.Height + 1)
        TbcCierreCaja.Location = New Point(btnCerrarCierreCaja.Location.X, btnCerrarCierreCaja.Top + btnCerrarCierreCaja.Height + 1)
        panel_cheque.Location = New Point(DgvChequesDeposito.Left + DgvChequesDeposito.Width + 1, panel_cheque.Location.Y)
    End Sub

    Private Sub SchedularActualizarCierresCajaCallback(e As Object)
        If Me.DgvCierresCaja.InvokeRequired Then
            Dim del As New DelActualizarGrillaCierresCaja(AddressOf ActualizarCierresCaja)
            Me.Invoke(del)
        Else
            Call ActualizarCierresCaja()
        End If

    End Sub

    Private Sub ActualizarCierresCaja()
        bolAgregandoDeposito = True
        Call ActualizarGrillaCierreCabecera()
        bolAgregandoDeposito = False
    End Sub

    Private Sub limpiarTotales()
        txtTotalCajaFondoFijo.Text = "$ 0"
        lblFondoFijoFisica.Text = "$ 0"

        txtTotalCajaEfectivo.Text = "$ 0"
        lblEfectivoFisica.Text = "$ 0"

        txtTotalCajaCheques.Text = "$ 0"
        lblChequeFisica.Text = "$ 0"

        txtTotalCajaTC.Text = "$ 0"
        lblTCFisica.Text = "$ 0"

        txtTotalCajaTD.Text = "$ 0"
        lblTDFisica.Text = "$ 0"

        txtTotalCajaTransferencia.Text = "$ 0"
        lblTransferenciaFisica.Text = "$ 0"

    End Sub

    Private Sub LimpiarDiferencias()
        lblFondoFijoDiferencia.Text = "$ 0"
        lblEfectivoDiferencia.Text = "$ 0"
        lblChequeDiferencia.Text = "$ 0"
        lblTCDiferencia.Text = "$ 0"
        lblTDDiferencia.Text = "$ 0"
        lblTransferenciaDiferencia.Text = "$ 0"
        lblTotalDiferencia.Text = "$ 0"
    End Sub

    Private Sub ActualizarGrillasDetalle(ByVal numeroCierreCaja As Integer)
        DgvEfectivo.Rows.Clear()
        DgvTC.Rows.Clear()
        DgvTD.Rows.Clear()
        DgvChequesCaja.Rows.Clear()
        DgvChequesDeposito.Rows.Clear()
        DgvTransferencia.Rows.Clear()

        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByIDCierreCaja(numeroCierreCaja)

        For Each fila As DataRow In dtbVwPosDocumentoDetPago.Rows
            If fila.Item("dpdp_tipo") = 1 Then 'Efectivo
                DgvEfectivo.Rows.Add("Tx " & fila.Item("dpc_numero").ToString() & "-" & fila.Item("dpdp_corr").ToString(), fila.Item("dpdp_montoPago"), fila.Item("cli_id"))

            ElseIf fila.Item("dpdp_tipo") = 2 Then 'Línea de Crédito

            ElseIf fila.Item("dpdp_tipo") = 3 Then 'Tarjeta de Crédito
                DgvTC.Rows.Add("Tx " & fila.Item("dpc_numero").ToString() & "-" & fila.Item("dpdp_corr").ToString(), fila.Item("dpdp_montoPago"), fila.Item("cli_id"))

            ElseIf fila.Item("dpdp_tipo") = 4 Then 'Tarjeta de Débito
                DgvTD.Rows.Add("Tx " & fila.Item("dpc_numero").ToString() & "-" & fila.Item("dpdp_corr").ToString(), fila.Item("dpdp_montoPago"), fila.Item("cli_id"))

            ElseIf fila.Item("dpdp_tipo") = 5 Then 'Cheque
                DgvChequesCaja.Rows.Add("Tx " & fila.Item("dpc_numero").ToString() & "-" & fila.Item("dpdp_corr").ToString(), fila.Item("dpdp_numeroCheque").ToString(), fila.Item("dpdp_bancoCheque").ToString(), fila.Item("dpdp_fechaCheque").ToString(),
                                        fila.Item("dpdp_montoPago"), fila.Item("cli_id"))
                If Not fila.Item("pcc_ID") Is DBNull.Value AndAlso fila.Item("pcc_ID") = numeroCierreCaja AndAlso fila.Item("pcd_corr") = 0 Then
                    DgvChequesDeposito.Rows.Add(False, "Tx " & fila.Item("dpc_numero").ToString() & "-" & fila.Item("dpdp_corr").ToString(), fila.Item("dpdp_numeroCheque"), fila.Item("dpdp_bancoCheque").ToString(), fila.Item("dpdp_fechaCheque").ToString(),
                                            fila.Item("dpdp_montoPago"), fila.Item("cli_id"), fila.Item("dpdp_numeroORSAN"), fila.Item("dpc_numero").ToString(), fila.Item("dpdp_corr").ToString())

                End If

            ElseIf fila.Item("dpdp_tipo") = 6 Then 'Transferencia
                DgvTransferencia.Rows.Add("Tx " & fila.Item("dpc_numero").ToString() & "-" & fila.Item("dpdp_corr").ToString(), fila.Item("dpdp_bancoCheque").ToString(), fila.Item("dpdp_montoPago"))

            ElseIf fila.Item("dpdp_tipo") = 7 Then 'Anticipo

            ElseIf fila.Item("dpdp_tipo") = 8 Then 'Nota de Crédito

            ElseIf fila.Item("dpdp_tipo") = 9 Then 'Linea Funcionario

            End If
        Next

    End Sub

    Private Sub ActualizarGrillaChequesDeposito()
        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByIdUsuario(Configuracion.IDUsuario)

        DgvChequesDeposito.Rows.Clear()

        For Each fila As DataRow In dtbVwPosDocumentoDetPago.Rows
            If fila.Item("dpdp_tipo") = 5 Then 'Cheque
                If Not fila.Item("pcc_ID") Is DBNull.Value AndAlso fila.Item("pcc_ID") = numeroCierreCaja AndAlso fila.Item("pcd_corr") = 0 Then
                    DgvChequesDeposito.Rows.Add(False, "Tx " & fila.Item("dpc_numero").ToString() & "-" & fila.Item("dpdp_corr").ToString(), fila.Item("dpdp_numeroCheque"), fila.Item("dpdp_bancoCheque").ToString(), fila.Item("dpdp_fechaCheque").ToString(),
                                        fila.Item("dpdp_montoPago"), fila.Item("cli_id"), fila.Item("dpdp_numeroORSAN"), fila.Item("dpc_numero").ToString(), fila.Item("dpdp_corr").ToString())

                End If
            End If
        Next

    End Sub

    'Private Sub AsignarGrillaCierreCabecera()
    '    dtbVwPosCierreCajaCab = tbaVwPosCierreCajaCab.GetDataByIDUsuario(Configuracion.IDUsuario)
    '    bnsVwPosCierreCajaCab = New BindingSource()
    '    bnsVwPosCierreCajaCab.DataSource = dtbVwPosCierreCajaCab

    '    DgvCierresCaja.AutoGenerateColumns = False
    '    DgvCierresCaja.DataSource = bnsVwPosCierreCajaCab

    'End Sub

    Private Sub ActualizarGrillaCierreCabecera()
        dtbVwPosCierreCajaCab = tbaVwPosCierreCajaCab.GetDataByIDUsuario(Configuracion.IDUsuario)

        DgvCierresCaja.AutoGenerateColumns = False
        DgvCierresCaja.DataSource = dtbVwPosCierreCajaCab

    End Sub

    Private Sub ActualizarGrillaCierreDetalle(ByVal pcc_id As Integer)
        dtbVwPosCierreCajaDet = tbaVwPosCierreCajaDet.GetDataByID(pcc_id)

        DgvCierresCajaDetalle.AutoGenerateColumns = False
        DgvCierresCajaDetalle.DataSource = dtbVwPosCierreCajaDet

    End Sub

    Private Sub ActualizarTotales()

        lblFondoFijoSistema.Text = lblTotalFondoFijo.Text

        lblTotalEfectivo.Text = String.Format(formatoNumero, DgvEfectivo.Rows.Cast(Of DataGridViewRow)().Sum(Function(t) Convert.ToInt32(t.Cells(1).Value)))
        lblEfectivoSistema.Text = lblTotalEfectivo.Text

        lblTotalCheques.Text = String.Format(formatoNumero, DgvChequesCaja.Rows.Cast(Of DataGridViewRow)().Sum(Function(t) Convert.ToInt32(t.Cells(4).Value)))
        lblChequeSistema.Text = lblTotalCheques.Text

        lblTotalTC.Text = String.Format(formatoNumero, DgvTC.Rows.Cast(Of DataGridViewRow)().Sum(Function(t) Convert.ToInt32(t.Cells(1).Value)))
        lblTCSistema.Text = lblTotalTC.Text

        lblTotalTD.Text = String.Format(formatoNumero, DgvTD.Rows.Cast(Of DataGridViewRow)().Sum(Function(t) Convert.ToInt32(t.Cells(1).Value)))
        lblTDSistema.Text = lblTotalTD.Text

        lblTotalTransferencia.Text = String.Format(formatoNumero, DgvTransferencia.Rows.Cast(Of DataGridViewRow)().Sum(Function(t) Convert.ToInt32(t.Cells(2).Value)))
        lblTransferenciaSistema.Text = lblTotalTransferencia.Text

        lblMontoTotalEfectivo.Text = lblEfectivoFisica.Text 'total para deposito

        ActualizarTotalesFinales()

    End Sub

    Private Sub ActualizarTotalesFinales()
        lblTotalSistema.Text = String.Format(formatoNumero, ValorNumericoControl(lblFondoFijoSistema) + ValorNumericoControl(lblEfectivoSistema) + ValorNumericoControl(lblChequeSistema) + ValorNumericoControl(lblTCSistema) + ValorNumericoControl(lblTDSistema) + ValorNumericoControl(lblTransferenciaSistema))
        lblTotalFisica.Text = String.Format(formatoNumero, ValorNumericoControl(lblFondoFijoFisica) + ValorNumericoControl(lblEfectivoFisica) + ValorNumericoControl(lblChequeFisica) + ValorNumericoControl(lblTCFisica) + ValorNumericoControl(lblTDFisica) + ValorNumericoControl(lblTransferenciaFisica))
        lblTotalDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblFondoFijoDiferencia) + ValorNumericoControl(lblEfectivoDiferencia) + ValorNumericoControl(lblChequeDiferencia) + ValorNumericoControl(lblTCDiferencia) + ValorNumericoControl(lblTDDiferencia) + ValorNumericoControl(lblTransferenciaDiferencia))

    End Sub

    Private Sub txtTotalCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalCajaFondoFijo.KeyPress, txtTotalCajaEfectivo.KeyPress, txtTotalCajaCheques.KeyPress, txtTotalCajaTC.KeyPress, txtTotalCajaTD.KeyPress, txtTotalCajaTransferencia.KeyPress, txtNumeroDepositoEfectivo.KeyPress, txtNumeroDepositoCheques.KeyPress
        If IsNumeric(e.KeyChar) = False AndAlso e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalCaja_LostFocus(sender As Object, e As EventArgs) Handles txtTotalCajaFondoFijo.LostFocus, txtTotalCajaEfectivo.LostFocus, txtTotalCajaCheques.LostFocus, txtTotalCajaTC.LostFocus, txtTotalCajaTD.LostFocus, txtTotalCajaTransferencia.LostFocus
        Dim txtControl As TextBox = CType(sender, TextBox)

        txtControl.Text = String.Format(formatoNumero, ValorNumericoControl(txtControl))

        If txtControl.Name = "txtTotalCajaEfectivo" Then
            lblEfectivoFisica.Text = String.Format(formatoNumero, ValorNumericoControl(txtControl))
            lblEfectivoDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblEfectivoFisica) - ValorNumericoControl(lblEfectivoSistema))
            lblDiferenciaEfectivo.Text = lblEfectivoDiferencia.Text
            tbaPosCierreCajaTotales.UpdateQuery(ValorNumericoControl(lblEfectivoSistema), ValorNumericoControl(lblEfectivoFisica), ValorNumericoControl(lblEfectivoDiferencia), numeroCierreCaja, 1)

        ElseIf txtControl.Name = "txtTotalCajaCheques" Then
            lblChequeFisica.Text = String.Format(formatoNumero, ValorNumericoControl(txtControl))
            lblChequeDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblChequeFisica) - ValorNumericoControl(lblChequeSistema))
            lblDiferenciaCheques.Text = lblChequeDiferencia.Text
            tbaPosCierreCajaTotales.UpdateQuery(ValorNumericoControl(lblChequeSistema), ValorNumericoControl(lblChequeFisica), ValorNumericoControl(lblChequeDiferencia), numeroCierreCaja, 5)

        ElseIf txtControl.Name = "txtTotalCajaTC" Then
            lblTCFisica.Text = String.Format(formatoNumero, ValorNumericoControl(txtControl))
            lblTCDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblTCFisica) - ValorNumericoControl(lblTCSistema))
            lblDiferenciaTC.Text = lblTCDiferencia.Text
            tbaPosCierreCajaTotales.UpdateQuery(ValorNumericoControl(lblTCSistema), ValorNumericoControl(lblTCFisica), ValorNumericoControl(lblTCDiferencia), numeroCierreCaja, 3)

        ElseIf txtControl.Name = "txtTotalCajaTD" Then
            lblTDFisica.Text = String.Format(formatoNumero, ValorNumericoControl(txtControl))
            lblTDDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblTDFisica) - ValorNumericoControl(lblTDSistema))
            lblDiferenciaTD.Text = lblTDDiferencia.Text
            tbaPosCierreCajaTotales.UpdateQuery(ValorNumericoControl(lblTDSistema), ValorNumericoControl(lblTDFisica), ValorNumericoControl(lblTDDiferencia), numeroCierreCaja, 4)

        ElseIf txtControl.Name = "txtTotalCajaTransferencia" Then
            lblTransferenciaFisica.Text = String.Format(formatoNumero, ValorNumericoControl(txtControl))
            lblTransferenciaDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblTransferenciaFisica) - ValorNumericoControl(lblTransferenciaSistema))
            lblDiferenciaTransferencia.Text = lblTransferenciaDiferencia.Text
            tbaPosCierreCajaTotales.UpdateQuery(ValorNumericoControl(lblTransferenciaSistema), ValorNumericoControl(lblTransferenciaFisica), ValorNumericoControl(lblTransferenciaDiferencia), numeroCierreCaja, 6)

        ElseIf txtControl.Name = "txtTotalCajaFondoFijo" Then
            lblFondoFijoFisica.Text = String.Format(formatoNumero, ValorNumericoControl(txtControl))
            lblFondoFijoDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblFondoFijoFisica) - ValorNumericoControl(lblFondoFijoSistema))
            lblDiferenciaFondoFijo.Text = lblFondoFijoDiferencia.Text
            tbaPosCierreCajaTotales.UpdateQuery(ValorNumericoControl(lblFondoFijoSistema), ValorNumericoControl(lblFondoFijoFisica), ValorNumericoControl(lblFondoFijoDiferencia), numeroCierreCaja, 10)

        End If

        Call ActualizarTotales()
    End Sub

    Private Sub txtTotalCaja_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTotalCajaFondoFijo.KeyUp, txtTotalCajaEfectivo.KeyUp, txtTotalCajaCheques.KeyUp, txtTotalCajaTC.KeyUp, txtTotalCajaTD.KeyUp, txtTotalCajaTransferencia.KeyUp
        If e.KeyCode = Keys.Return Then
            Call txtTotalCaja_LostFocus(sender, e)
        End If
    End Sub

    Private Sub DgvEfectivo_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DgvEfectivo.RowsRemoved, DgvChequesCaja.RowsRemoved, DgvTC.RowsRemoved, DgvTD.RowsRemoved, DgvTransferencia.RowsRemoved
        Dim dgvControl As DataGridView = CType(sender, DataGridView)

        Call ActualizarTotales()

        If dgvControl.Name = "DgvEfectivo" Then
            lblEfectivoDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblEfectivoFisica) - ValorNumericoControl(lblEfectivoSistema))
            lblDiferenciaEfectivo.Text = lblEfectivoDiferencia.Text

        ElseIf dgvControl.Name = "DgvCheques" Then
            lblChequeDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblChequeFisica) - ValorNumericoControl(lblChequeSistema))
            lblDiferenciaCheques.Text = lblChequeDiferencia.Text

        ElseIf dgvControl.Name = "DgvTC" Then
            lblTCDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblTCFisica) - ValorNumericoControl(lblTCSistema))
            lblDiferenciaTC.Text = lblTCDiferencia.Text

        ElseIf dgvControl.Name = "DgvTD" Then
            lblTDDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblTDFisica) - ValorNumericoControl(lblTDSistema))
            lblDiferenciaTD.Text = lblTDDiferencia.Text

        ElseIf dgvControl.Name = "DgvTransferencia" Then
            lblTransferenciaDiferencia.Text = String.Format(formatoNumero, ValorNumericoControl(lblTransferenciaFisica) - ValorNumericoControl(lblTransferenciaSistema))
            lblDiferenciaTransferencia.Text = lblTransferenciaDiferencia.Text

        End If

    End Sub

    Private Function ValorNumericoControl(ByVal Control As Control) As Integer
        Dim resultado As Integer = 0

        If TypeOf Control Is Label Then
            Integer.TryParse(Regex.Replace(CType(Control, Label).Text, "[^0-9]", ""), resultado)
        ElseIf TypeOf Control Is TextBox Then
            Integer.TryParse(Regex.Replace(CType(Control, TextBox).Text, "[^0-9]", ""), resultado)
        End If

        Return resultado
    End Function

    Private Function ValorNumerico(ByVal dato As String) As Integer
        Dim resultado As Integer = 0

        Integer.TryParse(Regex.Replace(dato, "[^0-9]", ""), resultado)

        Return resultado
    End Function

    Private Sub btn_aprobar_recaudacion_Click(sender As Object, e As EventArgs)
        'cmbBancoEfectivo.Enabled = True
        txtNumeroDepositoEfectivo.Enabled = True
        dtpFechaDepositoEfectivo.Enabled = True
    End Sub

    Private Sub DgvChequesDeposito_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvChequesDeposito.CellMouseClick
        Dim montoTotalDeposito As Integer = 0

        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            DgvChequesDeposito.Item(0, e.RowIndex).Value = Not DgvChequesDeposito.Item(0, e.RowIndex).Value

        End If

        For Each itemGrilla As DataGridViewRow In DgvChequesDeposito.Rows
            If DgvChequesDeposito.Item(0, itemGrilla.Index).Value = True AndAlso itemGrilla.Visible = True Then
                montoTotalDeposito += DgvChequesDeposito.Item(5, itemGrilla.Index).Value
            End If
        Next

        txtTotalDepositoCheques.Text = String.Format(formatoNumero, montoTotalDeposito)
    End Sub

    Private Sub DgvChequesDepositados_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 0 Then ' columna Seleccionar
                If DgvCierresCajaDetalle.Item(7, e.RowIndex).Value.ToString() <> "" Then
                    Dim dgvCelda As DataGridViewCell = DgvCierresCajaDetalle.Rows(e.RowIndex).Cells(0)
                    dgvCelda.ReadOnly = True
                    Dim imgboton As Image = iml_botones_columnas.Images(0)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    e.Graphics.DrawImage(imgboton, e.CellBounds.Location.X + Convert.ToInt32(e.CellBounds.Width / 2) - 8, e.CellBounds.Location.Y + 2, 16, 16)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub DgvEfectivo_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        ActualizarTotales()
    End Sub

    Private Sub lblFondoFijoDiferencia_TextChanged(sender As Object, e As EventArgs) Handles lblFondoFijoDiferencia.TextChanged
        cambiaColor(lblFondoFijoFisica, lblFondoFijoDiferencia)
    End Sub

    Private Sub lblFondoFijoFisica_TextChanged(sender As Object, e As EventArgs) Handles lblFondoFijoFisica.TextChanged
        cambiaColor(lblFondoFijoFisica, lblFondoFijoDiferencia)
    End Sub

    Private Sub lblEfectivoDiferencia_TextChanged(sender As Object, e As EventArgs) Handles lblEfectivoDiferencia.TextChanged
        cambiaColor(lblEfectivoFisica, lblEfectivoDiferencia)
    End Sub

    Private Sub lblChequeDiferencia_TextChanged(sender As Object, e As EventArgs) Handles lblChequeDiferencia.TextChanged
        cambiaColor(lblChequeFisica, lblChequeDiferencia)
    End Sub

    Private Sub lblTCDiferencia_TextChanged(sender As Object, e As EventArgs) Handles lblTCDiferencia.TextChanged
        cambiaColor(lblTCFisica, lblTCDiferencia)
    End Sub

    Private Sub lblTDDiferencia_TextChanged(sender As Object, e As EventArgs) Handles lblTDDiferencia.TextChanged
        cambiaColor(lblTDFisica, lblTDDiferencia)
    End Sub

    Private Sub lblTransferenciaDiferencia_TextChanged(sender As Object, e As EventArgs) Handles lblTransferenciaDiferencia.TextChanged
        cambiaColor(lblTransferenciaFisica, lblTransferenciaDiferencia)
    End Sub

    Private Sub lblTotalDiferencia_TextChanged(sender As Object, e As EventArgs) Handles lblTotalDiferencia.TextChanged
        cambiaColor(lblTotalFisica, lblTotalDiferencia)
    End Sub

    Private Sub lblEfectivoFisica_TextChanged(sender As Object, e As EventArgs) Handles lblEfectivoFisica.TextChanged
        cambiaColor(lblEfectivoFisica, lblEfectivoDiferencia)
    End Sub

    Private Sub lblChequeFisicaTextChanged(sender As Object, e As EventArgs) Handles lblChequeFisica.TextChanged
        cambiaColor(lblChequeFisica, lblChequeDiferencia)
    End Sub

    Private Sub lblTCFisica_TextChanged(sender As Object, e As EventArgs) Handles lblTCFisica.TextChanged
        cambiaColor(lblTCFisica, lblTCDiferencia)
    End Sub

    Private Sub lblTDFisica_TextChanged(sender As Object, e As EventArgs) Handles lblTDFisica.TextChanged
        cambiaColor(lblTDFisica, lblTDDiferencia)
    End Sub

    Private Sub lblTransferenciaFisica_TextChanged(sender As Object, e As EventArgs) Handles lblTransferenciaFisica.TextChanged
        cambiaColor(lblTransferenciaFisica, lblTransferenciaDiferencia)
    End Sub

    Private Sub lblTotalFisica_TextChanged(sender As Object, e As EventArgs) Handles lblTotalFisica.TextChanged
        cambiaColor(lblTotalFisica, lblTotalDiferencia)
    End Sub

    Sub cambiaColor(ByVal ControlFisico As Label, ByVal Control As Control)
        Control.BackColor = Color.White
        If ValorNumericoControl(Control) > 0 Then Control.BackColor = Color.LightGoldenrodYellow
        If ValorNumericoControl(Control) < 0 Then Control.BackColor = Color.MistyRose
        If ValorNumericoControl(Control) = 0 And ValorNumericoControl(ControlFisico) <> 0 Then Control.BackColor = Color.PaleGreen
        'MsgBox(ValorNumericoControl(ControlFisico))

        ActualizarTotalesFinales()
    End Sub

    Private Sub DgvEfectivo_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs)
        If MsgBox("¿ Estas seguro de querer eliminar el registro ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") <> vbYes Then e.Cancel = True
    End Sub

    Private Sub DgvChequesCaja_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs)
        If MsgBox("¿ Estas seguro de querer eliminar el registro ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") <> vbYes Then e.Cancel = True
    End Sub

    Private Sub DgvTC_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs)
        If MsgBox("¿ Estas seguro de querer eliminar el registro ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") <> vbYes Then e.Cancel = True
    End Sub

    Private Sub DgvTD_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs)
        If MsgBox("¿ Estas seguro de querer eliminar el registro ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") <> vbYes Then e.Cancel = True
    End Sub

    Private Sub DgvTransferencia_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs)
        If MsgBox("¿ Estas seguro de querer eliminar el registro ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar") <> vbYes Then e.Cancel = True
    End Sub

    Private Sub btnVerPDFCierreCaja_Click(sender As Object, e As EventArgs) Handles btnVerPDFCierreCaja.Click
        Dim str_rutaAplicacion As String = AppDomain.CurrentDomain.BaseDirectory
        Dim str_nombreArchivoDestino As String = str_rutaAplicacion & "CierreCaja" & numeroCierreCaja.ToString() & ".pdf"

        editarPDF(numeroCierreCaja, str_nombreArchivoDestino)
        System.Diagnostics.Process.Start(str_nombreArchivoDestino)
    End Sub

    Private Sub btnDepositoEfectivo_Click(sender As Object, e As EventArgs) Handles btnDepositoEfectivo.Click
        Dim montoEfectivo As Double = 0

        If txtNumeroDepositoEfectivo.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar un número de depósito antes de agregar", "Depósito en Efectivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If IsNumeric(Regex.Replace(lblMontoTotalEfectivo.Text.Trim, "[^0-9]", "")) = True Then
            montoEfectivo = Convert.ToDouble(Regex.Replace(lblMontoTotalEfectivo.Text.Trim, "[^0-9]", ""))

            If montoEfectivo <= 0 Then
                MessageBox.Show("Debe ingresar un monto mayor a cero", "Depósito en Efectivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            tbaPosCierreCajaDet.Insert(numeroCierreCaja, tbaPosCierreCajaDet.GetCorrMaximoByID(numeroCierreCaja) + 1, dtpFechaDepositoEfectivo.Value, 1, Convert.ToInt32(cmbBancoEfectivo.SelectedValue), Convert.ToDouble(montoEfectivo),
                                       txtNumeroDepositoEfectivo.Text, Nothing, Nothing, 1)
            tbaSPPosCierreCajaActualizarTotales.GetData(numeroCierreCaja)

            bolAgregandoDeposito = True
            Call ActualizarGrillaCierreCabecera()
            bolAgregandoDeposito = False
            Call ActualizarGrillaCierreDetalle(numeroCierreCaja)

            txtNumeroDepositoEfectivo.Text = ""
            lblMontoTotalEfectivo.Text = ""
        End If

    End Sub

    Private Sub btnDepositoCheque_Click(sender As Object, e As EventArgs) Handles btnDepositoCheque.Click
        Dim numCierreCajaDetalle As Integer = tbaPosCierreCajaDet.GetCorrMaximoByID(numeroCierreCaja) + 1
        Dim montoDepositoCheques As Integer = 0
        'Dim lstSeleccion As List(Of Boolean) = New List(Of Boolean)

        If txtNumeroDepositoCheques.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar un número de depósito antes de agregar", "Depósito de Cheques", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If IsNumeric(Regex.Replace(txtTotalDepositoCheques.Text, "[^0-9]", "")) = True Then
            montoDepositoCheques = Convert.ToInt32(Regex.Replace(txtTotalDepositoCheques.Text.Trim, "[^0-9]", ""))
            tbaPosCierreCajaDet.Insert(numeroCierreCaja, numCierreCajaDetalle, dtpFechaDepositoCheques.Value, 2, Convert.ToInt32(cmbBancoCheques.SelectedValue), Convert.ToDouble(montoDepositoCheques), txtNumeroDepositoCheques.Text, Nothing, Nothing, 1)
            tbaSPPosCierreCajaActualizarTotales.GetData(numeroCierreCaja)

            'For Each itemGrilla As DataGridViewRow In DgvChequesDeposito.Rows
            '    If DgvChequesDeposito.Item(0, itemGrilla.Index).Value = True Then
            '        lstSeleccion.Add(True)
            '    Else
            '        lstSeleccion.Add(False)
            '    End If

            'Next

            For Each itemGrilla As DataGridViewRow In DgvChequesDeposito.Rows
                'If lstSeleccion.Item(itemGrilla.Index) = True Then
                '    tbaPosDocumentoDetPago.UpdateByNumeroAndCorr(numeroCierreCaja, numCierreCajaDetalle, DgvChequesDeposito.Item(8, itemGrilla.Index).Value, DgvChequesDeposito.Item(9, itemGrilla.Index).Value)
                'Else
                '    tbaPosDocumentoDetPago.UpdateByNumeroAndCorr(numeroCierreCaja, Nothing, DgvChequesDeposito.Item(8, itemGrilla.Index).Value, DgvChequesDeposito.Item(9, itemGrilla.Index).Value)
                'End If

                If itemGrilla.Visible = True Then 'procesamos solo las filas visibles
                    If itemGrilla.Cells.Item("Sel").Value = True Then
                        tbaPosDocumentoDetPago.UpdateByNumeroAndCorr(numeroCierreCaja, numCierreCajaDetalle, itemGrilla.Cells.Item("dpc_numero").Value, itemGrilla.Cells.Item("dpd_corr").Value)
                        itemGrilla.Visible = False
                    Else
                        tbaPosDocumentoDetPago.UpdateByNumeroAndCorr(numeroCierreCaja, 0, itemGrilla.Cells.Item("dpc_numero").Value, itemGrilla.Cells.Item("dpd_corr").Value)
                    End If
                End If

                'If itemGrilla.Cells.Item(0).Value = True Then
                '    DgvChequesDeposito.Rows(itemGrilla.Index).Visible = False
                'End If
            Next

            bolAgregandoDeposito = True
            Call ActualizarGrillaCierreCabecera()
            bolAgregandoDeposito = False
            Call ActualizarGrillaCierreDetalle(numeroCierreCaja)

            txtNumeroDepositoCheques.Text = ""
            txtTotalDepositoCheques.Text = ""

        End If

    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click

        'numeroCierreCaja = numeroCierreCaja + 1

        'lbTituloCierreCaja.Text = "Cierre Caja " & numeroCierreCaja & " - " & Now.ToString("dd/MM/yyyy")

        lblFondoFijoSistema.Text = txtTotalCajaFondoFijo.Text
        lblEfectivoSistema.Text = ""
        lblChequeSistema.Text = ""
        lblTCSistema.Text = ""
        lblTDSistema.Text = ""
        lblTransferenciaSistema.Text = ""

        lblFondoFijoFisica.Text = ""
        lblEfectivoFisica.Text = ""
        lblChequeFisica.Text = ""
        lblTCFisica.Text = ""
        lblTDFisica.Text = ""
        lblTransferenciaFisica.Text = ""

        lblFondoFijoDiferencia.Text = ""
        lblEfectivoDiferencia.Text = ""
        lblChequeDiferencia.Text = ""
        lblTCDiferencia.Text = ""
        lblTDDiferencia.Text = ""
        lblTransferenciaDiferencia.Text = ""

        lblTotalSistema.Text = ""
        lblTotalFisica.Text = ""
        lblTotalDiferencia.Text = ""

        TbcCierreCaja.TabPages(0).Select()
        TbcCierreCaja.TabPages(1).Enabled = False

        lblTotalFondoFijo.Text = txtTotalCajaFondoFijo.Text
        txtTotalCajaFondoFijo.Text = ""
        lblDiferenciaFondoFijo.Text = ""

        DgvEfectivo.Rows.Clear()
        DgvChequesCaja.Rows.Clear()
        DgvTC.Rows.Clear()
        DgvTD.Rows.Clear()
        DgvTransferencia.Rows.Clear()


    End Sub

    'Private Function enviarCierreCaja() As Boolean
    '    Dim obj_sap As class_sap = Nothing
    '    Dim obj_cierreCaja As CierreCajaModel = Nothing
    '    Dim obj_cierreCajaResponse As CierreCajaResponseModel = Nothing
    '    Dim str_resultadoJSON As String = ""
    '    Dim str_postDataJSON As String
    '    Dim lstCheques As List(Of Cheque) = New List(Of Cheque)
    '    Dim itemCheque As Cheque = Nothing
    '    Dim nombreBancoDeposito As String = Global.caja2.My.MySettings.Default.nombreBancoDeposito

    '    Try
    '        With Global.caja2.My.MySettings.Default
    '            obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2)
    '        End With

    '        'Efectivo
    '        For Each fila As DataGridViewRow In DgvDepositos.Rows
    '            If fila.Cells.Item(0).Value.ToString() = "Efectivo" Then
    '                obj_cierreCaja = New CierreCajaModel()

    '                obj_cierreCaja.Tienda = Configuracion.IDTiendaSAP
    '                obj_cierreCaja.Efectivo = Regex.Replace(fila.Cells.Item(4).Value.ToString(), "[^0-9]", "")
    '                obj_cierreCaja.Banco = nombreBancoDeposito
    '                obj_cierreCaja.Fecha_Operacion = Convert.ToDateTime(fila.Cells.Item(1).Value).ToString("dd-MM-yyyy")
    '                obj_cierreCaja.Orsan_G = ""
    '                obj_cierreCaja.Num_Deposito = fila.Cells.Item(3).Value.ToString()

    '                Dim settings As JsonSerializerSettings = New JsonSerializerSettings()
    '                settings.NullValueHandling = NullValueHandling.Ignore
    '                str_postDataJSON = JsonConvert.SerializeObject(obj_cierreCaja, settings)

    '                str_resultadoJSON = obj_sap.postCierreCaja(str_postDataJSON)

    '                If String.IsNullOrEmpty(str_resultadoJSON) = False Then
    '                    obj_cierreCajaResponse = JsonConvert.DeserializeObject(Of CierreCajaResponseModel)(str_resultadoJSON)

    '                    If Not obj_cierreCajaResponse Is Nothing Then
    '                        MessageBox.Show("Documento grabado en SAP. " & obj_cierreCajaResponse.EDocumento, "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                Else
    '                    MessageBox.Show("Documento NO pudo ser grabado en SAP." & vbCrLf & "respuesta vacia", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End If

    '            End If
    '        Next

    '        'Cheque
    '        For Each fila As DataGridViewRow In DgvDepositos.Rows
    '            If fila.Cells.Item(0).Value.ToString() = "Cheques" Then
    '                obj_cierreCaja = New CierreCajaModel()

    '                obj_cierreCaja.Tienda = Configuracion.IDTiendaSAP
    '                obj_cierreCaja.Efectivo = "0"
    '                obj_cierreCaja.Banco = nombreBancoDeposito
    '                obj_cierreCaja.Fecha_Operacion = Convert.ToDateTime(fila.Cells.Item(1).Value).ToString("dd-MM-yyyy")
    '                obj_cierreCaja.Orsan_G = ""
    '                obj_cierreCaja.Num_Deposito = fila.Cells.Item(3).Value.ToString()

    '                For Each filaDeposito As DataGridViewRow In DgvChequesDeposito.Rows

    '                    If Convert.ToBoolean(filaDeposito.Cells.Item(0).Value) = True Then
    '                        itemCheque = New Cheque
    '                        itemCheque.Banco_Cheque = filaDeposito.Cells.Item(3).Value.ToString()
    '                        itemCheque.Cliente = filaDeposito.Cells.Item(6).Value.ToString()
    '                        itemCheque.Fecha_Cheque = Convert.ToDateTime(filaDeposito.Cells.Item(4).Value).ToString("dd-MM-yyyy")
    '                        itemCheque.Importe = filaDeposito.Cells.Item(5).Value.ToString()
    '                        itemCheque.Moneda = "CLP"
    '                        itemCheque.Nro_Orsan = filaDeposito.Cells.Item(7).Value.ToString()
    '                        itemCheque.Num_Cheque = filaDeposito.Cells.Item(2).Value.ToString()

    '                        lstCheques.Add(itemCheque)
    '                    End If
    '                Next

    '                If lstCheques.Count > 0 Then
    '                    obj_cierreCaja.Cheques = lstCheques.ToArray()
    '                End If

    '                str_postDataJSON = JsonConvert.SerializeObject(obj_cierreCaja)

    '                str_resultadoJSON = obj_sap.postCierreCaja(str_postDataJSON)

    '                If String.IsNullOrEmpty(str_resultadoJSON) = False Then
    '                    obj_cierreCajaResponse = JsonConvert.DeserializeObject(Of CierreCajaResponseModel)(str_resultadoJSON)

    '                    If Not obj_cierreCajaResponse Is Nothing Then
    '                        MessageBox.Show("Documento grabado en SAP. " & obj_cierreCajaResponse.EDocumento, "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                Else
    '                    MessageBox.Show("Documento NO pudo ser grabado en SAP." & vbCrLf & "respuesta vacia", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End If

    '            End If
    '        Next

    '    Catch ex As Exception
    '        MessageBox.Show("Documento NO pudo ser grabado en SAP." & ex.Message & vbCrLf & ex.StackTrace, "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try

    'End Function

    Private Sub DgvCierresCaja_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCierresCaja.SelectionChanged
        Dim dgvControl As DataGridView = CType(sender, DataGridView)
        Dim filaWeb As DataGridViewRow = Nothing
        Dim fila As DataRowView = Nothing
        Dim rutCliente As String = ""

        If bolAgregandoDeposito = True Then
            Exit Sub
        End If

        If dgvControl.SelectedRows.Count > 0 Then
            filaWeb = dgvControl.CurrentRow
            fila = filaWeb.DataBoundItem

            numeroCierreCaja = fila.Item("pcc_ID")

            Call ActualizarGrillasDetalle(numeroCierreCaja)
            Call ActualizarGrillaCierreDetalle(numeroCierreCaja)

            lbTituloCierreCaja.Text = "Cierre de Caja " & numeroCierreCaja & " del " & Convert.ToDateTime(fila.Item("pcc_fecha")).ToString("dd-MM-yyyy")

            Call CargarCierre(numeroCierreCaja)
            Call ActualizarTotales()
        Else
            lbTituloCierreCaja.Text = ""
            btnCerrarCierreCaja.Enabled = False
        End If

    End Sub

    Private Sub CargarCierre(ByVal numeroCierreCaja As Integer)
        dtbPosCierreCajaCab = tbaPosCierreCajaCab.GetDataByID(numeroCierreCaja)

        If dtbPosCierreCajaCab.Rows.Count > 0 Then
            If dtbPosCierreCajaCab.Rows(0).Item("pcce_ID") = 1 OrElse dtbPosCierreCajaCab.Rows(0).Item("pcce_ID") = 3 Then '1 = creado, 3 = rechazado
                btnCerrarCierreCaja.Enabled = True

                DgvCierresCajaDetalle.Enabled = True
                btnDepositoEfectivo.Enabled = True
                btnDepositoCheque.Enabled = True

                TabCierreCaja.Enabled = True
                TabDepositos.Enabled = True
                TbcDetallePagos.Enabled = True

                Call limpiarTotales()
                Call LimpiarDiferencias()
            Else
                btnCerrarCierreCaja.Enabled = False

                DgvCierresCajaDetalle.Enabled = False
                btnDepositoEfectivo.Enabled = False
                btnDepositoCheque.Enabled = False

                TabCierreCaja.Enabled = False
                TabDepositos.Enabled = False
                TbcDetallePagos.Enabled = False

                dtbPosCierreCajaTotales = tbaPosCierreCajaTotales.GetDataByID(numeroCierreCaja)
                If dtbPosCierreCajaTotales.Rows.Count > 0 Then

                    For Each fila As DataRow In dtbPosCierreCajaTotales.Rows
                        If fila.Item("dpdpt_ID") = 1 Then 'Efectivo
                            lblEfectivoSistema.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalSistema"))
                            lblEfectivoFisica.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalFisica"))
                            lblEfectivoDiferencia.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalDiferencia"))

                        ElseIf fila.Item("dpdpt_ID") = 2 Then 'Línea de Crédito

                        ElseIf fila.Item("dpdpt_ID") = 3 Then 'Tarjeta de Crédito
                            lblTCSistema.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalSistema"))
                            lblTCFisica.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalFisica"))
                            lblTCDiferencia.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalDiferencia"))

                        ElseIf fila.Item("dpdpt_ID") = 4 Then 'Tarjeta de Débito
                            lblTDSistema.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalSistema"))
                            lblTDFisica.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalFisica"))
                            lblTDDiferencia.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalDiferencia"))

                        ElseIf fila.Item("dpdpt_ID") = 5 Then 'Cheque
                            lblChequeSistema.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalSistema"))
                            lblChequeFisica.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalFisica"))
                            lblChequeDiferencia.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalDiferencia"))

                        ElseIf fila.Item("dpdpt_ID") = 6 Then 'Transferencia
                            lblTransferenciaSistema.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalSistema"))
                            lblTransferenciaFisica.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalFisica"))
                            lblTransferenciaDiferencia.Text = String.Format(formatoNumero, fila.Item("pct_montoTotalDiferencia"))

                        ElseIf fila.Item("dpdpt_ID") = 7 Then 'Anticipo

                        ElseIf fila.Item("dpdpt_ID") = 8 Then 'Nota de Crédito

                        ElseIf fila.Item("dpdpt_ID") = 9 Then 'Linea Funcionario

                        End If


                    Next

                End If

            End If


        End If

    End Sub

    Private Sub btnControl_EnabledChanged(sender As Object, e As EventArgs) Handles btnCerrarCierreCaja.EnabledChanged, btnDepositoEfectivo.EnabledChanged, btnDepositoCheque.EnabledChanged
        Dim btnControl As Button = CType(sender, Button)

        If btnControl.Enabled = True Then
            btnControl.BackColor = Color.DarkOrange
        Else
            btnControl.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub btnCerrarCierreCaja_Click(sender As Object, e As EventArgs) Handles btnCerrarCierreCaja.Click
        Dim dgvControl As DataGridView = CType(DgvCierresCaja, DataGridView)
        Dim filaWeb As DataGridViewRow = Nothing
        Dim fila As DataRowView = Nothing
        Dim rutCliente As String = ""

        If dgvControl.SelectedRows.Count > 0 Then

            If MessageBox.Show("Desea cerrar la recaudación del número seleccionado", "Cierre de Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
                filaWeb = dgvControl.CurrentRow
                fila = filaWeb.DataBoundItem

                If tbaPosCierreCajaTotales.CuentaByIDAndTipo(numeroCierreCaja, 10) = 0 Then ' fondo fijo
                    tbaPosCierreCajaTotales.Insert(numeroCierreCaja, 10, ValorNumerico(lblFondoFijoSistema.Text), ValorNumerico(lblFondoFijoFisica.Text), ValorNumerico(lblFondoFijoDiferencia.Text))
                Else
                    tbaPosCierreCajaTotales.UpdateQuery(ValorNumerico(lblFondoFijoSistema.Text), ValorNumerico(lblFondoFijoFisica.Text), ValorNumerico(lblFondoFijoDiferencia.Text), numeroCierreCaja, 10)
                End If

                If tbaPosCierreCajaTotales.CuentaByIDAndTipo(numeroCierreCaja, 1) = 0 Then ' efectivo
                    tbaPosCierreCajaTotales.Insert(numeroCierreCaja, 1, ValorNumerico(lblEfectivoSistema.Text), ValorNumerico(lblEfectivoFisica.Text), ValorNumerico(lblEfectivoDiferencia.Text))
                Else
                    tbaPosCierreCajaTotales.UpdateQuery(ValorNumerico(lblEfectivoSistema.Text), ValorNumerico(lblEfectivoFisica.Text), ValorNumerico(lblEfectivoDiferencia.Text), numeroCierreCaja, 1)
                End If

                If tbaPosCierreCajaTotales.CuentaByIDAndTipo(numeroCierreCaja, 5) = 0 Then ' cheque
                    tbaPosCierreCajaTotales.Insert(numeroCierreCaja, 5, ValorNumerico(lblChequeSistema.Text), ValorNumerico(lblChequeFisica.Text), ValorNumerico(lblChequeDiferencia.Text))
                Else
                    tbaPosCierreCajaTotales.UpdateQuery(ValorNumerico(lblChequeSistema.Text), ValorNumerico(lblChequeFisica.Text), ValorNumerico(lblChequeDiferencia.Text), numeroCierreCaja, 5)
                End If

                If tbaPosCierreCajaTotales.CuentaByIDAndTipo(numeroCierreCaja, 3) = 0 Then ' tarjeta de crédito
                    tbaPosCierreCajaTotales.Insert(numeroCierreCaja, 3, ValorNumerico(lblTCSistema.Text), ValorNumerico(lblTCFisica.Text), ValorNumerico(lblTCDiferencia.Text))
                Else
                    tbaPosCierreCajaTotales.UpdateQuery(ValorNumerico(lblTCSistema.Text), ValorNumerico(lblTCFisica.Text), ValorNumerico(lblTCDiferencia.Text), numeroCierreCaja, 3)
                End If

                If tbaPosCierreCajaTotales.CuentaByIDAndTipo(numeroCierreCaja, 4) = 0 Then ' tarjeta de débito
                    tbaPosCierreCajaTotales.Insert(numeroCierreCaja, 4, ValorNumerico(lblTDSistema.Text), ValorNumerico(lblTDFisica.Text), ValorNumerico(lblTDDiferencia.Text))
                Else
                    tbaPosCierreCajaTotales.UpdateQuery(ValorNumerico(lblTDSistema.Text), ValorNumerico(lblTDFisica.Text), ValorNumerico(lblTDDiferencia.Text), numeroCierreCaja, 4)
                End If

                If tbaPosCierreCajaTotales.CuentaByIDAndTipo(numeroCierreCaja, 6) = 0 Then ' transferencia
                    tbaPosCierreCajaTotales.Insert(numeroCierreCaja, 6, ValorNumerico(lblTransferenciaSistema.Text), ValorNumerico(lblTransferenciaFisica.Text), ValorNumerico(lblTransferenciaDiferencia.Text))
                Else
                    tbaPosCierreCajaTotales.UpdateQuery(ValorNumerico(lblTransferenciaSistema.Text), ValorNumerico(lblTransferenciaFisica.Text), ValorNumerico(lblTransferenciaDiferencia.Text), numeroCierreCaja, 6)
                End If

                tbaSpPosCierreCajaActualizarEstado.GetData(numeroCierreCaja, 2, Configuracion.IDUsuario, "", Now, 0) '2 = cerrado

                tbaPosAccionUsuario.Insert(3, "solicitando aprobación de cierre de Caja " & Configuracion.LoginUsuario & " de " & Configuracion.NombreUsuario, Now, Configuracion.IDTiendaSAP, Configuracion.IDUsuario, Nothing)

                bolAgregandoDeposito = True
                Call ActualizarGrillaCierreCabecera()
                bolAgregandoDeposito = False
                Call CargarCierre(numeroCierreCaja)

                TimerActualizarCierresCaja = New Threading.Timer(New TimerCallback(AddressOf SchedularActualizarCierresCajaCallback))
                TimerActualizarCierresCaja.Change(12000, 12000)

            End If

        End If

    End Sub

    Sub editarPDF(ByVal pcc_ID As Integer, ByVal nombreArchivoDestino As String)

        Dim memoria As New IO.MemoryStream
        Dim font1 = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA_BOLD, iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
        Dim font2 = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
        Dim oldFileFA As String = Application.StartupPath() & "\PDF\PLANTILLA_CIERRE_CAJA.V2.pdf"
        Dim cantPaginas As Integer = 0
        Dim itemsPorPagina As Integer = 23
        Dim itemActual As Integer = 0
        Dim itemPagina As Integer = 0
        Dim filaDatos As DataRow = Nothing
        Dim residuoPaginas As Integer = 0

        ' abre el reader
        Dim FA_reader = New PdfReader(oldFileFA)

        Dim sizeFACTURA = FA_reader.GetPageSizeWithRotation(1)
        Dim documentFINAL = New iTextSharp.text.Document(sizeFACTURA)
        Dim writer = PdfWriter.GetInstance(documentFINAL, memoria)
        Dim x, y As Integer

        documentFINAL.Open()
        Dim cb = writer.DirectContent

        ' create the new pages and add it to the pdf
        Dim FA_page1 = writer.GetImportedPage(FA_reader, 1)
        Dim FA_page2 = writer.GetImportedPage(FA_reader, 2)
        Dim FA_page3 = writer.GetImportedPage(FA_reader, 3)
        Dim FA_page4 = writer.GetImportedPage(FA_reader, 4)
        Dim FA_page5 = writer.GetImportedPage(FA_reader, 5)
        Dim FA_page6 = writer.GetImportedPage(FA_reader, 6)
        Dim FA_page7 = writer.GetImportedPage(FA_reader, 7)

        dtbVwPosCierreCajaCab = tbaVwPosCierreCajaCab.GetDataByID(pcc_ID)
        dtbVwPosCierreCajaDet = tbaVwPosCierreCajaDet.GetDataByID(pcc_ID)
        dtbPosCierreCajaTotales = tbaPosCierreCajaTotales.GetDataByID(pcc_ID)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Pagina 1
        documentFINAL.NewPage()
        cb.AddTemplate(FA_page1, 0, 0)
        'Alineación: 1=center, 0=left, 2=rigth

        'N° caja:
        agregaTextoPDF(cb, font1, 16, 0, 370, 700, dtbVwPosCierreCajaCab.Rows(0).Item("pcc_ID"))

        'Fecha:
        agregaTextoPDF(cb, font1, 14, 1, 335, 675, Convert.ToDateTime(dtbVwPosCierreCajaCab.Rows(0).Item("pcc_fecha")).ToString("dd-MM-yyyy"))

        'Primera página. Totales:

        x = 285 'Set primera columna RECAUDACIÓN SISTEMA
        For Each fila As DataRow In dtbPosCierreCajaTotales.Rows

            If fila.Item("dpdpt_ID") = 10 Then ' fondo fijo
                agregaTextoPDF(cb, font2, 12, 2, x, 596, "$ " & FormatNumber(fila("pct_montoTotalSistema"), 0)) 'FONDO FIJO
            ElseIf fila.Item("dpdpt_ID") = 1 Then 'efectivo
                agregaTextoPDF(cb, font2, 12, 2, x, 575, "$ " & FormatNumber(fila("pct_montoTotalSistema"), 0)) 'EFECTIVO
            ElseIf fila.Item("dpdpt_ID") = 5 Then 'cheque
                agregaTextoPDF(cb, font2, 12, 2, x, 556, "$ " & FormatNumber(fila("pct_montoTotalSistema"), 0)) 'CHEQUE
            ElseIf fila.Item("dpdpt_ID") = 3 Then 'tarjeta de crédito
                agregaTextoPDF(cb, font2, 12, 2, x, 536, "$ " & FormatNumber(fila("pct_montoTotalSistema"), 0)) 'TARJETA CRÉDITO
            ElseIf fila.Item("dpdpt_ID") = 4 Then 'tarjeta de débito
                agregaTextoPDF(cb, font2, 12, 2, x, 516, "$ " & FormatNumber(fila("pct_montoTotalSistema"), 0)) 'TARJETA DÉBITO
            ElseIf fila.Item("dpdpt_ID") = 6 Then 'transferencia
                agregaTextoPDF(cb, font2, 12, 2, x, 496, "$ " & FormatNumber(fila("pct_montoTotalSistema"), 0)) 'TRANSFERENCIA
            End If
        Next

        x = 400 'Set segunda columna RECAUDACIÓN FÍSICA
        For Each fila As DataRow In dtbPosCierreCajaTotales.Rows

            If fila.Item("dpdpt_ID") = 10 Then ' fondo fijo
                agregaTextoPDF(cb, font2, 12, 2, x, 596, "$ " & FormatNumber(fila("pct_montoTotalFisica"), 0)) 'FONDO FIJO
            ElseIf fila.Item("dpdpt_ID") = 1 Then 'efectivo
                agregaTextoPDF(cb, font2, 12, 2, x, 575, "$ " & FormatNumber(fila("pct_montoTotalFisica"), 0)) 'EFECTIVO
            ElseIf fila.Item("dpdpt_ID") = 5 Then 'cheque
                agregaTextoPDF(cb, font2, 12, 2, x, 556, "$ " & FormatNumber(fila("pct_montoTotalFisica"), 0)) 'CHEQUE
            ElseIf fila.Item("dpdpt_ID") = 3 Then 'tarjeta de crédito
                agregaTextoPDF(cb, font2, 12, 2, x, 536, "$ " & FormatNumber(fila("pct_montoTotalFisica"), 0)) 'TARJETA CRÉDITO
            ElseIf fila.Item("dpdpt_ID") = 4 Then 'tarjeta de débito
                agregaTextoPDF(cb, font2, 12, 2, x, 516, "$ " & FormatNumber(fila("pct_montoTotalFisica"), 0)) 'TARJETA DÉBITO
            ElseIf fila.Item("dpdpt_ID") = 6 Then 'transferencia
                agregaTextoPDF(cb, font2, 12, 2, x, 496, "$ " & FormatNumber(fila("pct_montoTotalFisica"), 0)) 'TRANSFERENCIA
            End If
        Next

        x = 510 'Set tercera columna DIFERENCIA
        For Each fila As DataRow In dtbPosCierreCajaTotales.Rows

            If fila.Item("dpdpt_ID") = 10 Then ' fondo fijo
                agregaTextoPDF(cb, font2, 12, 2, x, 596, "$ " & FormatNumber(fila("pct_montoTotalDiferencia"), 0)) 'FONDO FIJO
            ElseIf fila.Item("dpdpt_ID") = 1 Then 'efectivo
                agregaTextoPDF(cb, font2, 12, 2, x, 575, "$ " & FormatNumber(fila("pct_montoTotalDiferencia"), 0)) 'EFECTIVO
            ElseIf fila.Item("dpdpt_ID") = 5 Then 'cheque
                agregaTextoPDF(cb, font2, 12, 2, x, 556, "$ " & FormatNumber(fila("pct_montoTotalDiferencia"), 0)) 'CHEQUE
            ElseIf fila.Item("dpdpt_ID") = 3 Then 'tarjeta de crédito
                agregaTextoPDF(cb, font2, 12, 2, x, 536, "$ " & FormatNumber(fila("pct_montoTotalDiferencia"), 0)) 'TARJETA CRÉDITO
            ElseIf fila.Item("dpdpt_ID") = 4 Then 'tarjeta de débito
                agregaTextoPDF(cb, font2, 12, 2, x, 516, "$ " & FormatNumber(fila("pct_montoTotalDiferencia"), 0)) 'TARJETA DÉBITO
            ElseIf fila.Item("dpdpt_ID") = 6 Then 'transferencia
                agregaTextoPDF(cb, font2, 12, 2, x, 496, "$ " & FormatNumber(fila("pct_montoTotalDiferencia"), 0)) 'TRANSFERENCIA
            End If
        Next

        'Set totales primera página
        cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
        agregaTextoPDF(cb, font2, 12, 2, 285, 476, "$ " & FormatNumber(dtbVwPosCierreCajaCab.Rows(0).Item("pcc_montoTotalSistema"), 0)) 'total RECAUDACIÓN SISTEMA
        agregaTextoPDF(cb, font2, 12, 2, 400, 476, "$ " & FormatNumber(dtbVwPosCierreCajaCab.Rows(0).Item("pcc_montoTotalFisica"), 0)) 'total RECAUDACIÓN FÍSICA
        agregaTextoPDF(cb, font2, 12, 2, 510, 476, "$ " & FormatNumber(dtbVwPosCierreCajaCab.Rows(0).Item("pcc_montoTotalDiferencia"), 0)) 'total DIFERENCIA

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim total As Integer = 0

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Página 2 DETALLE DE CHEQUES
        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByIdCierreCajaAndTipo(pcc_ID, 5)

        If dtbVwPosDocumentoDetPago.Rows.Count > 0 Then
            cantPaginas = Convert.ToInt32(Math.Floor(dtbVwPosDocumentoDetPago.Rows.Count / itemsPorPagina))
            residuoPaginas = dtbVwPosDocumentoDetPago.Rows.Count Mod itemsPorPagina

            If residuoPaginas > 0 Then
                cantPaginas = cantPaginas + 1
            End If

            total = 0
            itemActual = 0

            For paginaActual As Integer = 1 To cantPaginas
                documentFINAL.NewPage()
                cb.AddTemplate(FA_page2, 0, 0)

                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)


                total = 0
                x = 120
                y = 692
                itemPagina = 0

                While itemActual < dtbVwPosDocumentoDetPago.Rows.Count
                    filaDatos = dtbVwPosDocumentoDetPago.Rows.Item(itemActual)

                    'N° OPERACIÓN
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("dpc_numero") & " - " & filaDatos.Item("dpdp_corr"))

                    'N° DOC
                    x = x + 50
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("dpdp_numeroCheque"))

                    'Banco
                    x = x + 20
                    agregaTextoPDF(cb, font2, 9, 0, x, y, "NOMBRE DEL BANCO(" & filaDatos.Item("dpdp_bancoCheque") & ")")

                    'FECHA
                    x = x + 200
                    agregaTextoPDF(cb, font2, 9, 2, x, y, Convert.ToDateTime(filaDatos.Item("dpdp_fechaCheque")).ToString("dd-MM-yyyyy"))

                    'MONTO
                    x = x + 60
                    total = total + filaDatos.Item("dpdp_montoPago")
                    agregaTextoPDF(cb, font2, 9, 2, x, y, String.Format(nbfInfo, "$ {0:N0}", filaDatos.Item("dpdp_montoPago")))

                    'N° CLIENTE
                    x = x + 85
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("cli_id"))

                    y = y - 20
                    x = 120

                    itemPagina = itemPagina + 1
                    itemActual = itemActual + 1

                    If itemPagina >= itemsPorPagina Then
                        Exit While
                    End If
                End While

            Next

        End If


        'Total al pie y cambiar texto a color blanco
        cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
        agregaTextoPDF(cb, font1, 10, 2, 420, 258, "$ " & FormatNumber(total, 0))

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Página 3 DETALLE DE TARJETA DE CRÉDITO
        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByIdCierreCajaAndTipo(pcc_ID, 3)

        If dtbVwPosDocumentoDetPago.Rows.Count > 0 Then
            cantPaginas = Convert.ToInt32(Math.Floor(dtbVwPosDocumentoDetPago.Rows.Count / itemsPorPagina))
            residuoPaginas = dtbVwPosDocumentoDetPago.Rows.Count Mod itemsPorPagina

            If residuoPaginas > 0 Then
                cantPaginas = cantPaginas + 1
            End If

            total = 0
            itemActual = 0

            For paginaActual As Integer = 1 To cantPaginas
                documentFINAL.NewPage()
                cb.AddTemplate(FA_page3, 0, 0)

                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)


                total = 0
                x = 120
                y = 692
                itemPagina = 0

                While itemActual < dtbVwPosDocumentoDetPago.Rows.Count
                    filaDatos = dtbVwPosDocumentoDetPago.Rows.Item(itemActual)

                    'N° OPERACIÓN
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("dpc_numero") & " - " & filaDatos.Item("dpdp_corr"))

                    'MONTO
                    x = x + 85
                    agregaTextoPDF(cb, font2, 9, 2, x, y, String.Format(nbfInfo, "$ {0:N0}", filaDatos.Item("dpdp_montoPago")))

                    'N° CLIENTE
                    x = x + 80
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("cli_id"))

                    y = y - 20
                    x = 120

                    total = total + filaDatos.Item("dpdp_montoPago")

                    itemPagina = itemPagina + 1
                    itemActual = itemActual + 1

                    If itemPagina >= itemsPorPagina Then
                        Exit While
                    End If
                End While

            Next

        End If


        'Total al pie y cambiar texto a color blanco
        cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
        agregaTextoPDF(cb, font1, 10, 2, 200, 198, "$ " & FormatNumber(total, 0))


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Página 4 DETALLE DE TARJETA DE DÉBITO
        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByIdCierreCajaAndTipo(pcc_ID, 4)

        If dtbVwPosDocumentoDetPago.Rows.Count > 0 Then
            cantPaginas = Convert.ToInt32(Math.Floor(dtbVwPosDocumentoDetPago.Rows.Count / itemsPorPagina))
            residuoPaginas = dtbVwPosDocumentoDetPago.Rows.Count Mod itemsPorPagina

            If residuoPaginas > 0 Then
                cantPaginas = cantPaginas + 1
            End If

            total = 0
            itemActual = 0

            For paginaActual As Integer = 1 To cantPaginas
                documentFINAL.NewPage()
                cb.AddTemplate(FA_page4, 0, 0)

                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)


                total = 0
                x = 120
                y = 692
                itemPagina = 0

                While itemActual < dtbVwPosDocumentoDetPago.Rows.Count
                    filaDatos = dtbVwPosDocumentoDetPago.Rows.Item(itemActual)
                    'N° OPERACIÓN
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("dpc_numero") & " - " & filaDatos.Item("dpdp_corr"))

                    'MONTO
                    x = x + 85
                    agregaTextoPDF(cb, font2, 9, 2, x, y, String.Format(nbfInfo, "$ {0:N0}", filaDatos.Item("dpdp_montoPago")))

                    'N° CLIENTE
                    x = x + 80
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("cli_id"))

                    y = y - 20
                    x = 120

                    total = total + filaDatos.Item("dpdp_montoPago")

                    itemPagina = itemPagina + 1
                    itemActual = itemActual + 1

                    If itemPagina >= itemsPorPagina Then
                        Exit While
                    End If
                End While

            Next

        End If

        'Total al pie y cambiar texto a color blanco
        cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
        agregaTextoPDF(cb, font1, 10, 2, 210, 218, "$ " & FormatNumber(total, 0))



        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Página 5 DETALLE DE TRANSFERENCIAS
        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByIdCierreCajaAndTipo(pcc_ID, 6)

        If dtbVwPosDocumentoDetPago.Rows.Count > 0 Then
            cantPaginas = Convert.ToInt32(Math.Floor(dtbVwPosDocumentoDetPago.Rows.Count / itemsPorPagina))
            residuoPaginas = dtbVwPosDocumentoDetPago.Rows.Count Mod itemsPorPagina

            If residuoPaginas > 0 Then
                cantPaginas = cantPaginas + 1
            End If

            total = 0
            itemActual = 0

            For paginaActual As Integer = 1 To cantPaginas
                documentFINAL.NewPage()
                cb.AddTemplate(FA_page5, 0, 0)

                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)


                total = 0
                x = 120
                y = 692
                itemPagina = 0

                While itemActual < dtbVwPosDocumentoDetPago.Rows.Count
                    filaDatos = dtbVwPosDocumentoDetPago.Rows.Item(itemActual)

                    'N° OPERACIÓN
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("dpc_numero") & " - " & filaDatos.Item("dpdp_corr"))

                    'Banco
                    x = x + 20
                    agregaTextoPDF(cb, font2, 9, 0, x, y, "NOMBRE DEL BANCO(" & filaDatos.Item("dpdp_bancoCheque") & ")")

                    'MONTO
                    x = x + 260
                    agregaTextoPDF(cb, font2, 9, 2, x, y, String.Format(nbfInfo, "$ {0:N0}", filaDatos.Item("dpdp_montoPago")))

                    'N° CLIENTE
                    x = x + 120
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("cli_id"))

                    y = y - 20
                    x = 120

                    total = total + filaDatos.Item("dpdp_montoPago")

                    itemPagina = itemPagina + 1
                    itemActual = itemActual + 1

                    If itemPagina >= itemsPorPagina Then
                        Exit While
                    End If
                End While

            Next

        End If

        'Total al pie y cambiar texto a color blanco
        cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
        agregaTextoPDF(cb, font1, 10, 2, 400, 219, "$ " & FormatNumber(total, 0))

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Página 6 EFECTIVO
        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByIdCierreCajaAndTipo(pcc_ID, 1)

        If dtbVwPosDocumentoDetPago.Rows.Count > 0 Then
            cantPaginas = Convert.ToInt32(Math.Floor(dtbVwPosDocumentoDetPago.Rows.Count / itemsPorPagina))
            residuoPaginas = dtbVwPosDocumentoDetPago.Rows.Count Mod itemsPorPagina

            If residuoPaginas > 0 Then
                cantPaginas = cantPaginas + 1
            End If

            total = 0
            itemActual = 0

            For paginaActual As Integer = 1 To cantPaginas

                documentFINAL.NewPage()
                cb.AddTemplate(FA_page6, 0, 0)

                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)

                x = 120
                y = 692
                itemPagina = 0


                While itemActual < dtbVwPosDocumentoDetPago.Rows.Count
                    filaDatos = dtbVwPosDocumentoDetPago.Rows.Item(itemActual)

                    'N° OPERACIÓN
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("dpc_numero") & " - " & filaDatos.Item("dpdp_corr"))

                    'MONTO
                    x = x + 85
                    agregaTextoPDF(cb, font2, 9, 2, x, y, String.Format(nbfInfo, "$ {0:N0}", filaDatos.Item("dpdp_montoPago")))

                    'N° CLIENTE
                    x = x + 80
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("cli_id"))

                    y = y - 20
                    x = 120

                    total = total + filaDatos.Item("dpdp_montoPago")
                    itemPagina = itemPagina + 1
                    itemActual = itemActual + 1

                    If itemPagina >= itemsPorPagina Then
                        Exit While
                    End If
                End While

            Next
        End If


        'Total al pie y cambiar texto a color blanco
        cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
        agregaTextoPDF(cb, font1, 10, 2, 210, 218, "$ " & FormatNumber(total, 0))

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Página 7 LINEA DE CREDITO
        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByIdCierreCajaAndTipo(pcc_ID, 2)

        If dtbVwPosDocumentoDetPago.Rows.Count > 0 Then
            cantPaginas = Convert.ToInt32(Math.Floor(dtbVwPosDocumentoDetPago.Rows.Count / itemsPorPagina))
            residuoPaginas = dtbVwPosDocumentoDetPago.Rows.Count Mod itemsPorPagina

            If residuoPaginas > 0 Then
                cantPaginas = cantPaginas + 1
            End If

            total = 0
            itemActual = 0

            For paginaActual As Integer = 1 To cantPaginas

                documentFINAL.NewPage()
                cb.AddTemplate(FA_page7, 0, 0)

                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)

                x = 120
                y = 692
                itemPagina = 0


                While itemActual < dtbVwPosDocumentoDetPago.Rows.Count
                    filaDatos = dtbVwPosDocumentoDetPago.Rows.Item(itemActual)

                    'N° OPERACIÓN
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("dpc_numero") & " - " & filaDatos.Item("dpdp_corr"))

                    'MONTO
                    x = x + 85
                    agregaTextoPDF(cb, font2, 9, 2, x, y, String.Format(nbfInfo, "$ {0:N0}", filaDatos.Item("dpdp_montoPago")))

                    'N° CLIENTE
                    x = x + 80
                    agregaTextoPDF(cb, font2, 9, 2, x, y, filaDatos.Item("cli_id"))

                    y = y - 20
                    x = 120

                    total = total + filaDatos.Item("dpdp_montoPago")

                    itemPagina = itemPagina + 1
                    itemActual = itemActual + 1

                    If itemPagina >= itemsPorPagina Then
                        Exit While
                    End If
                End While

            Next


        End If


        'Total al pie y cambiar texto a color blanco
        cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
        agregaTextoPDF(cb, font1, 10, 2, 210, 218, "$ " & FormatNumber(total, 0))



        'Propiedades del documento
        documentFINAL.AddTitle("Documento")
        documentFINAL.Close()
        writer.Close()
        FA_reader.Close()

        Dim bytes As Byte() = memoria.ToArray()
        File.WriteAllBytes(nombreArchivoDestino, bytes)

    End Sub

    Public Shared Sub agregaTextoPDF(ByRef cb As iTextSharp.text.pdf.PdfContentByte, ByVal font As iTextSharp.text.pdf.BaseFont, ByVal fontSize As Integer, ByVal align As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal texto As String, Optional largo As Integer = 999999)
        cb.BeginText()
        cb.SetFontAndSize(font, fontSize)

        If Len(texto) > largo Then
            Dim linea1 As String, linea2 As String

            largo = texto.Substring(0, largo).LastIndexOf(" ")

            linea1 = texto.Substring(0, largo)
            linea2 = texto.Substring(largo)

            cb.ShowTextAligned(align, linea1.Trim, X, Y, 0)
            cb.ShowTextAligned(align, linea2.Trim, X, Y - fontSize, 0)
        Else
            cb.ShowTextAligned(align, texto, X, Y, 0)
        End If


        cb.EndText()
    End Sub

    Private Sub DgvCierresCajaDetalle_KeyUp(sender As Object, e As KeyEventArgs) Handles DgvCierresCajaDetalle.KeyUp
        If e.KeyCode = Keys.Delete AndAlso Not DgvCierresCajaDetalle.CurrentRow Is Nothing Then

            If DgvCierresCajaDetalle.CurrentRow.Index >= 0 Then
                Dim corrDetalle As Integer = DgvCierresCajaDetalle.Item(0, DgvCierresCajaDetalle.CurrentRow.Index).Value
                tbaPosCierreCajaDet.DeleteByIDAndCorr(numeroCierreCaja, DgvCierresCajaDetalle.Item(0, DgvCierresCajaDetalle.CurrentRow.Index).Value)
                tbaPosDocumentoDetPago.UpdateByIDCierreAndDetCierre(numeroCierreCaja, DgvCierresCajaDetalle.Item(0, DgvCierresCajaDetalle.CurrentRow.Index).Value)
                tbaSPPosCierreCajaActualizarTotales.GetData(numeroCierreCaja)

                'Call ActualizarGrillasDetalle()
                bolAgregandoDeposito = True
                Call ActualizarGrillaCierreCabecera()
                bolAgregandoDeposito = False
                Call ActualizarGrillaCierreDetalle(numeroCierreCaja)
                Call ActualizarGrillaChequesDeposito()
            End If
        End If
    End Sub

    Private Sub DgvControl_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DgvCierresCaja.DataError, DgvCierresCajaDetalle.DataError, DgvChequesDeposito.DataError, DgvEfectivo.DataError, DgvChequesCaja.DataError,
                                     DgvTC.DataError, DgvTD.DataError, DgvTransferencia.DataError
        Dim dgvControl As DataGridView = CType(sender, DataGridView)
        e.Cancel = True
    End Sub

    Private Sub FrmCierreCaja_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Visible = False

        If TypeOf frmPadre Is FrmPrincipal Then
            frmPadre.ValidarEstadoCierresCaja()
            frmPadre = Nothing

        ElseIf TypeOf frmPadreAngosto Is FrmPrincipalAngosto Then
            frmPadreAngosto.ValidarEstadoCierresCaja()
            frmPadreAngosto = Nothing

        End If
    End Sub

    Private Sub FrmCierreCaja_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged
        Call PosicionarControles()
    End Sub

End Class