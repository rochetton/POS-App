Imports caja2.WfAprobacionTableAdapters
Imports System.Text.RegularExpressions
Imports caja2.OrsanAPI
Imports Newtonsoft.Json
Imports caja2.DTE
Imports caja2.ExtensionesTipo
Imports System.Threading
Imports System.IO
Imports caja2.DataSet_catalogo
Imports System.Net
Imports System.Text
Imports iTextSharp.text.pdf

Public Class FrmPrincipalAngosto

    Dim tbaVwWebNotaVentaCab As vw_web_notaVentaCabTableAdapter = New vw_web_notaVentaCabTableAdapter
    Dim tbaVwWebNotaVentaDet As vw_web_notaVentaDetTableAdapter = New vw_web_notaVentaDetTableAdapter
    Dim tbaVwWebRepuestoDetalle As vw_web_repuestoDetalleTableAdapter = New vw_web_repuestoDetalleTableAdapter
    Dim tbaVwBTClienteProductoPrecio As vw_BT_cliente_ProductoPrecioTableAdapterCustom = New vw_BT_cliente_ProductoPrecioTableAdapterCustom

    Dim tbaVwBanco As vw_bancoTableAdapter = New vw_bancoTableAdapter
    Dim tbaPosCuentaDeposito As pos_cuentaDepositoTableAdapter = New pos_cuentaDepositoTableAdapter
    Dim tbaPosFormatoImpresionCheque As pos_formatoImpresionChequeTableAdapter = New pos_formatoImpresionChequeTableAdapter
    Dim tbaPosSucursalBanco As pos_sucursalBancoTableAdapter = New pos_sucursalBancoTableAdapter
    Dim tbaWebCiudad As web_ciudadTableAdapter = New web_ciudadTableAdapter
    Dim tbaWebComuna As web_comunaTableAdapter = New web_comunaTableAdapter

    Dim tbaVwCliente As vw_clienteTableAdapter = New vw_clienteTableAdapter
    Dim tbaSolicitudDevolucion As solicitud_devolucionTableAdapter = New solicitud_devolucionTableAdapter
    Dim tbaVwArticulo As vw_articuloTableAdapter = New vw_articuloTableAdapter
    Dim tbaVwArticuloUnidadMedida As vw_articulo_unidadMedidaTableAdapter = New vw_articulo_unidadMedidaTableAdapter
    Dim tbaVwArticuloEAN As vw_articulo_EANTableAdapter = New vw_articulo_EANTableAdapter
    Dim tbaVwArticuloStock As vw_articulo_stockTableAdapter = New vw_articulo_stockTableAdapter
    Dim tbaVwPosVencimientoCheque As vw_pos_vencimientoChequeTableAdapter = New vw_pos_vencimientoChequeTableAdapter
    Dim tbaSPPosDocumentoAgregaNotaVenta As sp_pos_documento_agregaNotaVentaTableAdapter = New sp_pos_documento_agregaNotaVentaTableAdapter
    Dim tbaPosDocumentoCab As pos_documentoCabTableAdapter = New pos_documentoCabTableAdapter
    Dim tbaPosDocumentoDet As pos_documentoDetTableAdapter = New pos_documentoDetTableAdapter
    Dim tbaPosDocumentoDetPago As pos_documentoDetPagoTableAdapter = New pos_documentoDetPagoTableAdapter
    Dim tbaVwPosDocumentoCab As vw_pos_documentoCabTableAdapter = New vw_pos_documentoCabTableAdapter
    Dim tbaVwPosDocumentoDetPago As vw_pos_documentoDetPagoTableAdapter = New vw_pos_documentoDetPagoTableAdapter
    Dim tbaVwPosDocumentoDetPagoDoc As vw_pos_documentoDetPagoDocTableAdapter = New vw_pos_documentoDetPagoDocTableAdapter
    Dim tbaWebNotaVentaCab As web_notaVentaCabTableAdapter = New web_notaVentaCabTableAdapter
    Dim tbaVWPosDocumentoDet As vw_pos_documentoDetTableAdapter = New vw_pos_documentoDetTableAdapter
    Dim tbaSPPosDocumentoFechasCheque As sp_pos_documento_fechasChequeTableAdapter = New sp_pos_documento_fechasChequeTableAdapter
    Dim tbaSPPosAgregaLineaPago As sp_pos_documento_agregaLineaPago2TableAdapter = New sp_pos_documento_agregaLineaPago2TableAdapter
    Dim tbaWebNotaVentaCabMarketPlace As web_notaVentaCab_marketPlaceTableAdapter = New web_notaVentaCab_marketPlaceTableAdapter
    Dim tbaUsuario As usuarioTableAdapter = New usuarioTableAdapter
    Dim tbaSPPosDocumentoAgregaLineaDetalle As sp_pos_documento_agregaLineaDetalleTableAdapter = New sp_pos_documento_agregaLineaDetalleTableAdapter
    Dim tbaVwPosNotaVentaOrdenServicio As vw_pos_notaVenta_ordenServicioTableAdapter = New vw_pos_notaVenta_ordenServicioTableAdapter
    Dim tbaVwPosNotaVentaTeleventas As vw_pos_notaVenta_televentasTableAdapter = New vw_pos_notaVenta_televentasTableAdapter
    Dim tbaSPWebNotaVentaAgregadocumentosPOS As sp_web_notaVenta_agregaDocumentoPosTableAdapter = New sp_web_notaVenta_agregaDocumentoPosTableAdapter
    Dim tbaSPPosDocumentoAgregaOrdenServicio As sp_pos_documento_agregaOrdenServicioTableAdapter = New sp_pos_documento_agregaOrdenServicioTableAdapter
    Dim tbaOrdenServicio As ordenServicioTableAdapter = New ordenServicioTableAdapter
    Dim tbaTiendaCiudad As tienda_ciudadTableAdapter = New tienda_ciudadTableAdapter
    Dim tbaVwPosNotaCredito As vw_pos_notaCredito2TableAdapterCustom = New vw_pos_notaCredito2TableAdapterCustom
    Dim tbaSPPosDocumentoAgregaDevolucion As sp_pos_documento_agregaDevolucionTableAdapter = New sp_pos_documento_agregaDevolucionTableAdapter
    Dim tbaDesisLog As desis_logTableAdapter = New desis_logTableAdapter
    Dim tbaVwBTproductoServicio As vw_BT_productoServicioTableAdapter = New vw_BT_productoServicioTableAdapter
    Dim tbaWebSolicitudGarantiaResolucion As web_solicitud_garantia_resolucionTableAdapter = New web_solicitud_garantia_resolucionTableAdapter
    Dim tbaPosCierreCajaCab As pos_cierreCaja_cabTableAdapter = New pos_cierreCaja_cabTableAdapter
    Dim tbaSPPosCierreCajaCrear As sp_pos_cierreCaja_crearTableAdapter = New sp_pos_cierreCaja_crearTableAdapter
    Dim tbaSPPosDocumentoAgregaLineaPagoDoc As sp_pos_documento_agregaLineaPagoDocTableAdapter = New sp_pos_documento_agregaLineaPagoDocTableAdapter
    Dim tbaSPPosDocumentoCrear As sp_pos_documento_crearTableAdapter = New sp_pos_documento_crearTableAdapter
    Dim tbaClienteRangosLineaCredito As cliente_rangosLineaCreditoTableAdapter = New cliente_rangosLineaCreditoTableAdapter
    Dim tbaTienda As tiendaTableAdapter = New tiendaTableAdapter
    Dim tbaVwClienteDireccion As vw_cliente_direccionTableAdapter = New vw_cliente_direccionTableAdapter
    Dim tbaVwPosCierreCajaCab As vw_pos_cierreCaja_cabTableAdapter = New vw_pos_cierreCaja_cabTableAdapter
    Dim tbaSap_log As sap_logTableAdapter = New sap_logTableAdapter
    Dim tbaPosEmpresaDTE As pos_empresaDteTableAdapter = New pos_empresaDteTableAdapter
    Dim tbaOrsanLog As orsan_logTableAdapter = New orsan_logTableAdapter
    Dim tbaOrsanCodigoRechazo As orsan_codigoRechazoTableAdapter = New orsan_codigoRechazoTableAdapter
    Dim tbaNotaVentaAccion As notaVenta_accionTableAdapter = New notaVenta_accionTableAdapter
    Dim tbaPosDocumentoDetPagoDoc As pos_documentoDetPagoDocTableAdapter = New pos_documentoDetPagoDocTableAdapter
    Dim tbaPosCodigoPartidaCliente As pos_codigoPartidaClienteTableAdapter = New pos_codigoPartidaClienteTableAdapter
    Dim tbaWebSolicitudGarantia As web_solicitud_garantiaTableAdapter = New web_solicitud_garantiaTableAdapter
    Dim tbaFncMontoSobregiroLineaCredito As fnc_montoSobregiroLineaCreditoTableAdapter = New fnc_montoSobregiroLineaCreditoTableAdapter
    Dim tbaMensajeUsuarioEnvioDTE As fnc_mensajeUsuarioEnvioDTETableAdapter = New fnc_mensajeUsuarioEnvioDTETableAdapter																														

    Dim dtbSPPosDocumentoAgregaOrdenServicio As DataTable = Nothing
    Dim dtbVwWebNotaVentaCab As DataTable = Nothing
    Dim dtbVwWebNotaVentaDet As DataTable = Nothing
    Dim dtbVwBTClienteProductoPrecio As DataTable = Nothing
    Dim dtbBanco As DataTable = Nothing
    Dim dtbBancoTransferencia As DataTable = Nothing
    Dim dtbDetalle As DataTable = Nothing
    Dim dtbPosCuentaDeposito As DataTable = Nothing
    Dim dtbCliente As DataTable = Nothing
    Dim dtbVwCliente As DataTable = Nothing
    Dim dtbDocPorPagar As DataTable = Nothing
    Dim dtbAbonos As DataTable = Nothing
    Dim dtbSolicitudDevolucion As DataTable = Nothing
    Dim dtbPosFormatoImpresionCheque As DataTable = Nothing
    Dim dtbSPPosDocumentoAgregaNotaVenta As DataTable = Nothing
    Dim dtbPosDocumentoCab As DataTable = Nothing
    Dim dtbPosDocumentoDet As DataTable = Nothing
    Dim dtbPosDocumentoDetPago As DataTable = Nothing
    Dim dtbVwPosDocumentoCab As DataTable = Nothing
    Dim dtbVWPosDocumentoDet As DataTable = Nothing
    Dim dtbVwPosDocumentoDetPago As DataTable = Nothing
    Dim dtbVwPosDocumentoDetPagoDoc As DataTable = Nothing
    Dim dtbSPPosDocumentoFechasCheque As DataTable = Nothing
    Dim dtbSPPosDocumentoAgregaLineaDetalle As DataTable = Nothing
    Dim dtbVwArticulo As DataTable = Nothing
    Dim dtbVwArticuloUnidadMedida As DataTable = Nothing
    Dim dtbVwArticuloStock As DataTable = Nothing
    Dim dtbVwPosNotaVentaOrdenServicio As DataTable = Nothing
    Dim dtbSPWebNotaVentaAgregadocumentosPOS As DataTable = Nothing
    Dim dtbWebNotaVentaCab As DataTable = Nothing
    Dim dtbVwPosNotaCredito As DataTable = Nothing
    Dim dtbSPPosDocumentoAgregaDevolucion As DataTable = Nothing
    Dim dtbOrdenServicio As DataTable = Nothing
    Dim dtbVencimientoCheque As DataTable = Nothing
    Dim dtbSPPosDocumentoCrear As DataTable = Nothing
    Dim dtbVwClienteDireccion As DataTable = Nothing
    Dim dtbSPPosAgregaLineaPago As DataTable = Nothing
    Dim dtbVwArticuloEAN As DataTable = Nothing
    Dim dtbVwPosCierreCajaCab As DataTable = Nothing
    Dim dtbPosEmpresaDTE As DataTable = Nothing
    Dim dtbOrsanCodigoRechazo As DataTable = Nothing
    Dim dtbOrsanLog As DataTable = Nothing
    Dim dtbPosDocumentoDetPagoDoc As DataTable = Nothing
    Dim dtbPosCodigoPartidaCliente As DataTable = Nothing
    Dim dtbVwPosVencimientoCheque As DataTable = Nothing
    Dim dtbFncMontoSobregiroLineaCredito As DataTable = Nothing
    Dim dtbFncmensajeUsuarioEnvioDTE As DataTable = Nothing														   

    Dim obj_logSyncObject As Object = New Object

    Dim TimerActualizarNotasVenta As System.Threading.Timer
    Delegate Sub DelActualizarGrillaNotasVenta()
    Dim TimerActualizarNotasCredito As System.Threading.Timer
    Delegate Sub DelActualizarGrillaNotasCredito()

    Dim dctEstadoControles As Dictionary(Of Control, Boolean) = New Dictionary(Of Control, Boolean)

    Public IDTienda As String = ""
    Dim numeroDocumentoPOS As Integer = 0
    Dim IDNotaVenta As Integer = 0
    Dim IDOrdenServicio As Integer = 0
    Dim IDDevolucion As Integer = 0
    Dim URL_notaVenta As String = ""
    Dim pcc_ID As Integer = 0
    Dim ordenServicioOC As String = ""
    Dim ordenServicioHES As String = ""
    Dim estadoNotaVenta As String = ""

    Dim filaNotaVenta As DataSet_catalogo.vw_web_notaVentaCabRow
    Dim filaPosDocumentoCab As DataSet_catalogo.pos_documentoCabRow
    Dim lstVencimientosCheque As List(Of Tuple(Of String, String, String, String, String, String)) = New List(Of Tuple(Of String, String, String, String, String, String))

    Dim totalProductosNeto As Double = 0
    Dim totalProductosConIva As Double = 0
    Dim totalNeto As Double = 0
    Dim totalIva As Double = 0
    Dim totalFinal As Double = 0
    Dim totalDescuento As Double = 0
    Dim totalDescuentoCupon As Double = 0
    Dim totalDocumentos As Double = 0
    Dim totalPago As Double = 0
    Dim totalLineaCliente As Double = 0
    Dim totalDisponibleCliente As Double = 0
    Dim totalSobregiroCliente As Double = 0
    Dim nbfInfo As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo() With {.NumberDecimalSeparator = ",", .NumberGroupSeparator = "."}
    Dim codigosExclusionStock As String = ""
    Dim pagandoDocumentos As Boolean = False
    Dim seleccionandoMedioPago As Boolean = False

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Text = "Sistema de Cajas - TIENDA " & tiendaNombre & " (" & usrNombre & ")"

        Try
            'Call Test()

            If Global.caja2.My.MySettings.Default.AmbienteSAP = "0" Then
                Me.Text &= " - Ambiente Prueba" & " - Pantalla : " & Screen.PrimaryScreen.WorkingArea.Width.ToString() & " x " & Screen.PrimaryScreen.WorkingArea.Height.ToString()
            End If

            Dim str_conexion As String = Global.caja2.My.MySettings.Default.CatalogoCARENConnectionString

            codigosExclusionStock = Global.caja2.My.MySettings.Default.codigosExclusionStock

            If IsNumeric(Global.caja2.My.MySettings.Default.RangoDiasCheque) = True Then
                NudFecVencimientoCheque.Minimum = Global.caja2.My.MySettings.Default.RangoDiasCheque * -1
                NudFecVencimientoCheque.Maximum = Global.caja2.My.MySettings.Default.RangoDiasCheque * 1
            End If

            Configuracion.AbrirConexion(str_conexion)

            tbaVwWebNotaVentaCab.Connection = Configuracion.Conexion
            tbaVwWebNotaVentaDet.Connection = Configuracion.Conexion
            tbaVwWebRepuestoDetalle.Connection = Configuracion.Conexion
            tbaVwBTClienteProductoPrecio.Connection = Configuracion.Conexion
            'tbaBanco.Connection = Configuracion.Conexion
            tbaVwBanco.Connection = Configuracion.Conexion
            tbaPosCuentaDeposito.Connection = Configuracion.Conexion
            tbaPosFormatoImpresionCheque.Connection = Configuracion.Conexion
            tbaWebCiudad.Connection = Configuracion.Conexion
            tbaWebComuna.Connection = Configuracion.Conexion
            tbaPosCierreCajaCab.Connection = Configuracion.Conexion
            tbaPosDocumentoCab.Connection = Configuracion.Conexion
            tbaPosDocumentoDetPagoDoc.Connection = Configuracion.Conexion
            tbaVwPosNotaCredito.Connection = Configuracion.Conexion
            tbaSap_log.Connection = Configuracion.Conexion
            tbaWebSolicitudGarantia.Connection = Configuracion.Conexion

            tbaSolicitudDevolucion.Connection = Configuracion.ObtieneConexion(Global.caja2.My.MySettings.Default.WfAprobacionConnectionString)

            tbaOrdenServicio.Connection = Configuracion.ObtieneConexion(Global.caja2.My.MySettings.Default.BaseTransferencia_sapConnectionString)
            tbaVwCliente.Connection = Configuracion.ObtieneConexion(Global.caja2.My.MySettings.Default.BaseTransferencia_sapConnectionString)
            tbaVwArticulo.Connection = Configuracion.ObtieneConexion(Global.caja2.My.MySettings.Default.BaseTransferencia_sapConnectionString)
            tbaFncMontoSobregiroLineaCredito.Connection = Configuracion.ObtieneConexion(Global.caja2.My.MySettings.Default.BaseTransferencia_sapConnectionString)

            lblVersion.Text = "Versión " & Application.ProductVersion

            If tbaPosCierreCajaCab.CuentaByIdUsuario(Configuracion.IDUsuario) = 0 Then
                tbaSPPosCierreCajaCrear.GetData(pcc_ID, Configuracion.IDUsuario, Configuracion.IDTiendaSAP, Now)

            ElseIf ValidarEstadoCierresCaja() = False Then
                Exit Sub

            End If

            CmbEstadoNotaVenta.Items.Add("(Todas)")
            CmbEstadoNotaVenta.Items.Add("Liberadas")
            CmbEstadoNotaVenta.Items.Add("Por liberar")
            CmbEstadoNotaVenta.SelectedIndex = CmbEstadoNotaVenta.FindStringExact("(Todas)")

            cmbTipoDoc.Items.Add("(Todos)")
            cmbTipoDoc.Items.Add("Factura")
            cmbTipoDoc.Items.Add("Cheque por Cobrar")
            cmbTipoDoc.SelectedIndex = cmbTipoDoc.FindStringExact("(Todos)")

            cmbTipoTarjetaCredito.Items.Add("(Seleccione)")
            cmbTipoTarjetaCredito.Items.Add("Tarjeta de Débito")
            cmbTipoTarjetaCredito.Items.Add("Tarjeta de Crédito")
            cmbTipoTarjetaCredito.SelectedIndex = cmbTipoTarjetaCredito.FindStringExact("(Seleccione)")

            TabPagos.SelectedIndex = 1

            If Configuracion.IDTipoUsuario = 30 Then
                btnEfectivo_Click(sender, e)
            Else
                btnEfectivo.Enabled = False
            End If

            Call ActualizarNotasVentaOrdenesServicio()
            Call ActualizarNotasCreditoWorkflow()

            TimerActualizarNotasVenta = New Threading.Timer(New TimerCallback(AddressOf SchedularActualizarNotasVentaCallback))
            TimerActualizarNotasVenta.Change(10000, 10000)
            TimerActualizarNotasCredito = New Threading.Timer(New TimerCallback(AddressOf SchedularActualizarNotasCreditoCallback))
            TimerActualizarNotasCredito.Change(12000, 12000)

            Call DgvNotasVenta_CellContentClick(DgvNotasVenta, New DataGridViewCellEventArgs(0, 0))

            dtbBanco = tbaVwBanco.GetData()
            cbx_banco.DataSource = dtbBanco

            dtbBancoTransferencia = tbaVwBanco.GetData()
            Dim dtvBancoTransferencia As DataView = dtbBancoTransferencia.DefaultView
            dtvBancoTransferencia.RowFilter = "bc_id = 4 OR bc_id = 19" '4 = Banco Chile, 19 = Santander 
            cbx_bcoTransferencia.DataSource = dtvBancoTransferencia

            dtbVencimientoCheque = tbaVwPosVencimientoCheque.GetData() 'tbaVencimientoCheque.GetData()
            cbx_tipoVencimientoCheque.DisplayMember = "pvc_nombre"
            'cbx_tipoVencimientoCheque.ValueMember = "dato"
            cbx_tipoVencimientoCheque.DataSource = dtbVencimientoCheque

            cbx_marketPlace.DisplayMember = "nvmp_id"
            cbx_marketPlace.ValueMember = "nvmp_nombre"
            cbx_marketPlace.DataSource = tbaWebNotaVentaCabMarketPlace.GetData()

            dtbSPPosDocumentoFechasCheque = tbaSPPosDocumentoFechasCheque.GetData(Now)
            If dtbSPPosDocumentoFechasCheque.Rows.Count > 0 Then
                DtpFechaVencCheque.Value = dtbSPPosDocumentoFechasCheque.Rows(0).Item("fechaCheque")
                DtpFechaVencCheque.Enabled = False

                If IsNumeric(Global.caja2.My.MySettings.Default.RangoDiasCheque) = True Then
                    DtpFechaVencCheque.MinDate = DtpFechaVencCheque.Value.AddDays(Global.caja2.My.MySettings.Default.RangoDiasCheque * -1)
                    DtpFechaVencCheque.MaxDate = DtpFechaVencCheque.Value.AddDays(Global.caja2.My.MySettings.Default.RangoDiasCheque)
                End If

            End If

            pnl_totalDocumentos.Parent = Panel4

            lbl_creditoDispCliente.Parent = Panel_BotonesPago

            Call PosicionarBotonesMediosPago()
            Call PosicionarPaneles()

            'Call recargarDocumentoPos(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function mensajeUsuarioDESIS(ByVal mensajeBuscar As String) As String
        Dim mensajeUsuario As String = "Error procesamiento DESIS"
        Dim dtvDesisMensajeUsuario As DataView

        Try
            Dim posicionInicioError As Integer = mensajeBuscar.IndexOf("&lt;Error&gt;")
            Dim posicionFinalError As Integer = mensajeBuscar.IndexOf("&lt;/Error&gt;&lt;")
            Dim largoInicioError As Integer = Len("&lt;Error&gt;")

            If (posicionInicioError + largoInicioError) > 0 And (posicionFinalError - posicionInicioError - largoInicioError) > 0 Then
                mensajeBuscar = mensajeBuscar.Substring(posicionInicioError + largoInicioError, posicionFinalError - posicionInicioError - largoInicioError)
            End If

            Dim dtrResultado As DataRow = Configuracion.dtbDesisMensajeUsuario.AsEnumerable.Where(Function(fila) mensajeBuscar.Contains(fila.Item("dmu_mensajeDesis").ToString())).FirstOrDefault

            If Not dtrResultado Is Nothing Then
                mensajeUsuario = dtrResultado.Item("dmu_mensajeUsuario").ToString()
            End If

        Catch ex As Exception
            mensajeUsuario = ""
        End Try

        Return mensajeUsuario
    End Function
    Public Sub PosicionarPaneles()
        Dim lst_paneles As List(Of Panel) = New List(Of Panel) From {Panel_Anticipos, Panel_Cheque, Panel_CtaCAREN, Panel_Efectivo, panel_LineaFuncionario, Panel_marketPlace, Panel_NotaCredito, Panel_Tarjeta, Panel_Transferencia}

        For Each itemPanel In lst_paneles
            itemPanel.Parent = Panel_BotonesPago
            itemPanel.Visible = False
            itemPanel.Location = New Point(29, 142)
        Next
    End Sub

    Public Sub recargarDocumentoPos(ByVal numero As Integer, Optional consultaEstadoDESIS As Boolean = False)
        Dim str_tipoDocSAP As String
        Dim int_tipoDTE As Integer
        Dim int_folioDocumento As Long
        Dim ordenServicioOC As String = ""
        Dim observaciones As String = ""
        Dim idUsuarioVendedor As Integer
        Dim idVendedor As Integer
        Dim idVendedorRetira As Integer
        Dim idUsuarioEquiv As String
        Dim idUsuarioDocOrigen As Integer
        Dim strIdEntregaNotaCredito As String
        Dim numDocOrigen As Integer

        numeroDocumentoPOS = numero
        lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()
        dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(numeroDocumentoPOS)

        If dtbPosDocumentoCab.Rows.Count > 0 Then
            Integer.TryParse(dtbPosDocumentoCab.Rows(0).Item("dpc_tipoDte").ToString(), int_tipoDTE)
            Long.TryParse(dtbPosDocumentoCab.Rows(0).Item("dpc_folioDte").ToString(), int_folioDocumento)

            If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDocOrigen") = 1 Then ' Nota de Venta
                IDNotaVenta = dtbPosDocumentoCab.Rows(0).Item("dpc_numDocOrigen")

            ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDocOrigen") = 3 Then ' Devolución
                IDDevolucion = dtbPosDocumentoCab.Rows(0).Item("dpc_numDocOrigen")

            End If

            If IDNotaVenta > 0 Then
                dtbWebNotaVentaCab = tbaWebNotaVentaCab.GetDataByID(IDNotaVenta)

                If dtbWebNotaVentaCab.Rows.Count > 0 Then
                    idUsuarioVendedor = dtbWebNotaVentaCab.Rows(0).Item("nvc_idUsuario")
                    If Not dtbWebNotaVentaCab.Rows(0).Item("nvc_idVendedor") Is DBNull.Value Then
                        idVendedorRetira = tbaUsuario.GetCodUsuarioSAPByID(dtbWebNotaVentaCab.Rows(0).Item("nvc_idVendedor"))
                    End If
                End If

                idVendedor = tbaUsuario.GetCodUsuarioSAPByID(Convert.ToDecimal(idUsuarioVendedor))

                TabPagos.SelectedIndex = 0
                filaNotaVenta = CType(tbaVwWebNotaVentaCab.GetDataByID(IDNotaVenta).Rows(0), DataSet_catalogo.vw_web_notaVentaCabRow)

                lbl_creditoDispCliente.Visible = True
                txt_nombreCajero.Text = Configuracion.NombreUsuario '"cajero 1"
                txt_vendedor.Text = "Vendedor " & "3"
                txt_NotaVenta.Text = filaNotaVenta.Item("nvc_numero").ToString()
                txt_idCliente.Text = filaNotaVenta.Item("cli_id").ToString()
                txt_rutCliente.Text = filaNotaVenta.Item("nvc_rut").ToString()

                dtbVwCliente = tbaVwCliente.GetDataByTaxNumber(txt_rutCliente.Text.Trim)

                If dtbVwCliente.Rows.Count > 0 Then
                    Call ActualizarDatosCliente(dtbVwCliente)
                End If

                If filaNotaVenta.Item("nvc_idTipoDocFacturacion") Is DBNull.Value Then
                    RadioButton_boleta.Checked = True

                ElseIf filaNotaVenta.Item("nvc_idTipoDocFacturacion") = 1 Then 'boleta
                    RadioButton_boleta.Checked = True

                Else
                    RadioButton_factura.Checked = True

                End If

                If txt_idCliente.Text.StartsWith("005") = True Then
                    lbl_tituloCliente.Text = "Datos del Funcionario"
                    btnLineaFuncionario.Visible = True
                    Call btnLineaFuncionario_Click(btnLineaFuncionario, New EventArgs())
                Else
                    lbl_tituloCliente.Text = "Datos del Cliente"
                    btnLineaFuncionario.Visible = False
                End If

            ElseIf IDDevolucion > 0 Then
                dtbSolicitudDevolucion = tbaSolicitudDevolucion.GetDataByID(IDDevolucion)

                If dtbSolicitudDevolucion.Rows.Count > 0 Then
                    Integer.TryParse(dtbSolicitudDevolucion.Rows(0).Item("sdtdo_idUsuario").ToString(), idUsuarioDocOrigen)
                    Integer.TryParse(dtbSolicitudDevolucion.Rows(0).Item("sdtdo_numero").ToString(), numDocOrigen)
                    idUsuarioEquiv = dtbSolicitudDevolucion.Rows(0).Item("sdtdo_idEquivUsuario").ToString()

                    If dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString() = "1" Then ' 1 = Devolución de Producto
                        strIdEntregaNotaCredito = "08" '08 -NC Devolución

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString() = "2" Then ' 2 = Descuento NO aplicado
                        strIdEntregaNotaCredito = "09" '09 - NC Corrige monto

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString() = "3" Then ' 3 = Aviso Garantia 
                        strIdEntregaNotaCredito = "09" '09 - NC Corrige monto

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString() = "4" Then ' 4 = Refacturación
                        strIdEntregaNotaCredito = "08" '08 -NC Devolución

                    End If

                End If

                If idUsuarioEquiv.ToString().Trim() <> "" Then
                    idVendedor = idUsuarioEquiv
                Else
                    idVendedor = tbaUsuario.GetCodUsuarioSAPByID(Convert.ToDecimal(idUsuarioDocOrigen))
                End If

            End If

            If dtbPosDocumentoCab.Rows(0).Item("dpc_tipoDte") Is DBNull.Value AndAlso IDNotaVenta > 0 AndAlso dtbWebNotaVentaCab.Rows(0).Item("nvc_idTipoDocFacturacion") = 2 Then
                str_tipoDocSAP = "FF"
            ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_tipoDte") = 33 Then
                str_tipoDocSAP = "FF"
            ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_tipoDte") = 39 Then
                str_tipoDocSAP = "BO"
            ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_tipoDte") = 61 Then
                str_tipoDocSAP = "NF"
            End If

            LlenarGrillaDetalle(numeroDocumentoPOS)
            LlenarGrillaDetallePago(numeroDocumentoPOS)

            'If consultaEstadoDESIS = True Then

            'End If

            If IDNotaVenta > 0 Then
                Call crearPedidoVenta(str_tipoDocSAP, int_tipoDTE, int_folioDocumento, ordenServicioOC, observaciones, totalFinal, "", 0, idVendedor, idVendedorRetira)

            ElseIf IDDevolucion > 0 Then
                Call crearPedidoVenta(str_tipoDocSAP, int_tipoDTE, int_folioDocumento, ordenServicioOC, observaciones, totalFinal, strIdEntregaNotaCredito, numDocOrigen, idVendedor)

            End If

            Call limpiaDocumento()
        End If

    End Sub

    Public Sub Test()
        'Dim montoEnPalabras As String = func_montoAPalabras(1332653)

        'Dim montoLinea1 As String = ""
        'Dim montoLinea2 As String = ""
        'Dim lineaActual As Integer = 1
        'Dim largoMaximoLinea1 As Integer = 60
        'Dim arrMonto As String() = Nothing

        'arrMonto = montoEnPalabras.Split(" ")

        'For indice As Integer = 0 To arrMonto.Length - 1
        '    If arrMonto(indice).Trim <> "" Then
        '        If montoLinea1.Length + arrMonto(indice).Length < largoMaximoLinea1 AndAlso lineaActual = 1 Then
        '            montoLinea1 &= arrMonto(indice).Trim & " "
        '        Else
        '            montoLinea2 &= arrMonto(indice).Trim & " "
        '            lineaActual = 2
        '        End If
        '    End If
        'Next

        Dim obj_APIDESIS As class_APIDESIS
        With Global.caja2.My.MySettings.Default
            obj_APIDESIS = New class_APIDESIS(Global.caja2.My.MySettings.Default.AmbienteSAP, .DESISUsuario, .DESISRut, .DESISPassword, .DESISPuerto, 0)
        End With

        If obj_APIDESIS.ambiente = 0 Then ' 0 = QA
            obj_APIDESIS.grabaDTE(61, 9999959866, "<DTE xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" version=""1"" xmlns=""http://www.sii.cl/SiiDte"">   <Documento ID=""F0T61"">    <Encabezado>     <IdDoc>      <TipoDTE>61</TipoDTE>      <Folio>0</Folio>      <FchEmis>2024-07-09</FchEmis>      <FmaPago>1</FmaPago>     </IdDoc>     <Emisor>      <RUTEmisor>77307757-6</RUTEmisor>      <RznSoc>CAREN SPA</RznSoc>      <GiroEmis>VENTA DE PARTES, PIEZAS Y ACCESORIOS PARA VEHICULOS AUTOMOTORES</GiroEmis>      <Acteco>453000</Acteco>      <Sucursal>5</Sucursal>      <DirOrigen>Obispo Umaña 1042</DirOrigen>      <CmnaOrigen>Estación Central</CmnaOrigen>      <CiudadOrigen>SANTIAGO</CiudadOrigen>     </Emisor>     <Receptor>      <RUTRecep>4872876-6</RUTRecep>      <CdgIntRecep>0010055877</CdgIntRecep>      <RznSocRecep>MARIO ANTONIO MELO</RznSocRecep>      <GiroRecep>SERV.FORESTALES / TRANSPO</GiroRecep>      <DirRecep>ERCILLA 395</DirRecep>      <CmnaRecep>LOS ÁNGELES</CmnaRecep>      <CiudadRecep>LOS ANGELES</CiudadRecep>     </Receptor>     <Totales>      <MntNeto>67218</MntNeto>      <TasaIVA>19</TasaIVA>      <IVA>12771</IVA>      <MntTotal>79989</MntTotal>     </Totales>    </Encabezado>    <Detalle>     <NroLinDet>1</NroLinDet>     <CdgItem>      <TpoCodigo>INT1</TpoCodigo>      <VlrCodigo>300231</VlrCodigo>     </CdgItem>     <NmbItem>LUBPRO 15W-40 CI-4 19LT LUBPRO</NmbItem>     <DscItem />     <QtyItem>1</QtyItem>     <UnmdItem>UN</UnmdItem>     <PrcItem>67218</PrcItem>     <MontoItem>67218</MontoItem>    </Detalle>    <Referencia>     <NroLinRef>1</NroLinRef>     <TpoDocRef>33</TpoDocRef>     <FolioRef>9999750050</FolioRef>     <FchRef>2024-07-09</FchRef>     <CodRef>3</CodRef>    </Referencia>    <Adicional>     <NodosA>      <A1>2024-07-09</A1>      <A2 />      <A3>LUIS GUTIERREZ</A3>      <A4>VIÑA DEL MAR</A4>      <A5>56998838120                   </A5>      <A6 />      <A7>25282</A7>      <A8 />      <A9>0010055877</A9>     </NodosA>    </Adicional>    <TmstFirma>0001-01-01T00:00:00</TmstFirma>   </Documento>  </DTE>")
        End If
    End Sub

    Public Function TryExecuteSql(Of T As Exception)(ByVal numberOfTries As Integer, ByVal anAction As Action) As Boolean
        Dim resultado As Boolean = False
        Dim posicion As Point

        imagen_conexion_basedatos.Visible = False
        imagen_conexion_basedatos.Image = caja2.My.Resources.Resources.wifi
        imagen_conexion_basedatos.SizeMode = PictureBoxSizeMode.StretchImage

        posicion = Me.imagen_conexion_basedatos.PointToClient(Panel4.PointToScreen(Me.lblReintento.Location))

        If posicion.X > 0 AndAlso posicion.Y > 0 Then
            lblReintento.Location = posicion
            lblReintento.Location = New Point(lblReintento.Location.X - 10, lblReintento.Location.Y - 7)
            lblReintento.Parent = Me.imagen_conexion_basedatos
        End If

        lblReintento.Text = ""
        lblReintento.Visible = True
        lblReintento.BringToFront()

        For i As Integer = 1 To numberOfTries
            Try
                anAction()
                resultado = True
                Exit For

            Catch ex As T
                func_RegistrarEnLogFile(ex.Message & " " & ex.HResult.ToString())
                imagen_conexion_basedatos.Visible = True
                imagen_conexion_basedatos.Refresh()

                lblReintento.Text = i.ToString()
                'lblReintento.Refresh()

                Application.DoEvents()

                If ex.HResult = -2146232060 Then
                    Thread.Sleep(3000)
                Else
                    Thread.Sleep(1000)
                End If
            End Try
        Next

        imagen_conexion_basedatos.Visible = False

        Return resultado
    End Function

    Private Sub FrmPrincipalAngosto_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        pnl_totalDocumentos.Top = pnl_totalProductos.Top
    End Sub

    Public Function ValidarEstadoCierresCaja() As Boolean
        dtbVwPosCierreCajaCab = tbaVwPosCierreCajaCab.GetDataByIDUsuario(Configuracion.IDUsuario)

        For Each fila As DataRow In dtbVwPosCierreCajaCab.Rows
            If fila.Item("pcce_ID") Is DBNull.Value Then
            ElseIf fila.Item("pcce_ID") = 1 Then ' 1 = Creado
                Dim tmsDiferencia As TimeSpan = Now.Date - Convert.ToDateTime(fila.Item("pcc_fecha")).Date

                If tmsDiferencia.TotalDays > 0 Then
                    MessageBox.Show("Debe cerrar su caja para realizar ventas." & vbCrLf & " Su número de cierre " & fila.Item("pcc_ID").ToString() & " está activo", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Call EstadoControles(False)
                    Return False

                End If

            ElseIf fila.Item("pcce_ID") = 2 Then ' 2 = por aprobación
                MessageBox.Show("Su número de cierre " & fila.Item("pcc_ID").ToString() & " está por aprobación" & vbCrLf & "NO es posible crear nuevas transacciones hasta que sea aprobado por Jefatura.", "Caja",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Call EstadoControles(False)
                Return False

            End If
        Next

        Return True
    End Function

    Private Sub EstadoControles(ByVal estado As Boolean)
        chk_anticipo.Enabled = estado
        RadioButton_boleta.Enabled = estado
        RadioButton_factura.Enabled = estado
        RadioButton_notaCredito.Enabled = estado
        txt_rutCliente.Enabled = estado
        btnRestablecer.Enabled = estado
        btnPagarDocumentos.Enabled = estado
        btnFacturar.Enabled = estado
        TabPagos.Enabled = estado
        btnAgregarProducto.Enabled = estado
        btnGrabarCliente.Enabled = estado
        btnBuscarProducto.Enabled = estado
        btnVerDatosCliente.Enabled = estado
        chk_emailDocumento.Enabled = estado
        chk_imprimirDocumento.Enabled = estado

    End Sub

    Private Sub GuardarEstadoControles()
        dctEstadoControles.Clear()

        dctEstadoControles.Add(chk_anticipo, chk_anticipo.Enabled)
        dctEstadoControles.Add(RadioButton_boleta, RadioButton_boleta.Enabled)
        dctEstadoControles.Add(RadioButton_factura, RadioButton_factura.Enabled)
        dctEstadoControles.Add(RadioButton_notaCredito, RadioButton_notaCredito.Enabled)
        dctEstadoControles.Add(txt_rutCliente, txt_rutCliente.Enabled)
        dctEstadoControles.Add(btnRestablecer, btnRestablecer.Enabled)
        dctEstadoControles.Add(btnPagarDocumentos, btnPagarDocumentos.Enabled)
        dctEstadoControles.Add(btnFacturar, btnFacturar.Enabled)
        dctEstadoControles.Add(TabPagos, TabPagos.Enabled)
        dctEstadoControles.Add(btnAgregarProducto, btnAgregarProducto.Enabled)
        dctEstadoControles.Add(btnGrabarCliente, btnGrabarCliente.Enabled)
        dctEstadoControles.Add(btnBuscarProducto, btnBuscarProducto.Enabled)
        dctEstadoControles.Add(btnVerDatosCliente, btnVerDatosCliente.Enabled)
        dctEstadoControles.Add(chk_emailDocumento, chk_emailDocumento.Enabled)
        dctEstadoControles.Add(chk_imprimirDocumento, chk_imprimirDocumento.Enabled)
        dctEstadoControles.Add(DgvDocPorPagar, DgvDocPorPagar.Enabled)
        dctEstadoControles.Add(btnCierreCaja, btnCierreCaja.Enabled)
        dctEstadoControles.Add(btnMenuAdmin, btnMenuAdmin.Enabled)

        For Each item In dctEstadoControles
            item.Key.Enabled = False
        Next

    End Sub

    Private Sub RestaurarEstadoControles()
        For Each item In dctEstadoControles
            item.Key.Enabled = item.Value
        Next

    End Sub

    Private Sub PosicionarBotonesMediosPago()
        Dim x As Integer = 0
        Dim y As Integer = 0

        Panel_BotonesPago.Parent = TbpPago
        Panel_BotonesPago.Location = New Point(5, DgvDocPorPagar.Location.Y + DgvDocPorPagar.Height + 2)
        Panel_BotonesPago.BringToFront()

        Panel_BotonesMedioPago.Parent = Panel_BotonesPago
        Panel_BotonesMedioPago.Location = New Point(1, lblTituloPago.Height + 1)

        Dim lst_botones_fila1 As List(Of Button) = New List(Of Button) From {btnEfectivo, btnTarjeta, btnCheque, btnTransferencia, btnLineaFuncionario}

        x = 6
        y = 13

        For Each boton As Button In lst_botones_fila1
            boton.Parent = Panel_BotonesMedioPago
            boton.Location = New Point(x, y)
            x += boton.Width + 4
        Next

        Dim lst_botones_fila2 As List(Of Button) = New List(Of Button) From {btnLineaCredito, btnNotaCredito, btnAnticipos, btnMarketPlace, btnValeVista}

        x = 6
        y += lst_botones_fila1.Item(0).Height + 2

        For Each boton As Button In lst_botones_fila2
            boton.Parent = Panel_BotonesMedioPago
            boton.Location = New Point(x, y)
            x += boton.Width + 4
        Next

    End Sub

    Private Sub BloquearBotonesPago()
        btnEfectivo.Enabled = False
        btnTarjeta.Enabled = False
        btnCheque.Enabled = False
        btnTransferencia.Enabled = False
        btnLineaFuncionario.Enabled = False
        btnLineaCredito.Enabled = False
        btnNotaCredito.Enabled = False
        btnAnticipos.Enabled = False
        btnMarketPlace.Enabled = False

        btnAgregarEfectivo.Enabled = False
        txt_montoEfectivo.Enabled = False
    End Sub

    Private Sub EstadoBotonesPago()
        If txt_idCliente.Text.Trim().StartsWith("005") = True AndAlso RadioButton_notaCredito.Checked = False Then ' funcionario
            btnEfectivo.Enabled = (Configuracion.IDTipoUsuario = 30) ' True
            btnTarjeta.Enabled = True
            btnCheque.Enabled = True
            btnTransferencia.Enabled = True
            btnLineaFuncionario.Enabled = True
            btnLineaCredito.Enabled = False
            btnNotaCredito.Enabled = True
            btnAnticipos.Enabled = True
            btnMarketPlace.Enabled = False

        ElseIf chk_anticipo.Checked = True Then ' crear anticipo de cliente
            btnEfectivo.Enabled = (Configuracion.IDTipoUsuario = 30) ' True
            btnTarjeta.Enabled = True
            btnCheque.Enabled = True
            btnTransferencia.Enabled = True
            btnLineaFuncionario.Enabled = False
            btnLineaCredito.Enabled = False
            btnNotaCredito.Enabled = False
            btnAnticipos.Enabled = False
            btnMarketPlace.Enabled = False

        ElseIf RadioButton_notaCredito.Checked = True Then
            btnEfectivo.Enabled = False
            btnTarjeta.Enabled = False
            btnCheque.Enabled = False
            btnTransferencia.Enabled = False
            btnLineaFuncionario.Enabled = False
            btnLineaCredito.Enabled = False
            btnNotaCredito.Enabled = False
            btnAnticipos.Enabled = False
            btnMarketPlace.Enabled = False
            btnAgregarEfectivo.Enabled = False
            txt_montoEfectivo.Enabled = False

            btnEfectivo.BackColor = Color.LightGray
            btnTarjeta.BackColor = Color.LightGray
            btnCheque.BackColor = Color.LightGray
            btnTransferencia.BackColor = Color.LightGray
            btnLineaFuncionario.BackColor = Color.LightGray
            btnLineaCredito.BackColor = Color.LightGray
            btnNotaCredito.BackColor = Color.LightGray
            btnAnticipos.BackColor = Color.LightGray
            btnMarketPlace.BackColor = Color.LightGray
            btnAgregarEfectivo.BackColor = Color.LightGray

        Else
            btnEfectivo.Enabled = (Configuracion.IDTipoUsuario = 30) ' True
            btnTarjeta.Enabled = True
            btnCheque.Enabled = True
            btnTransferencia.Enabled = True
            btnLineaFuncionario.Enabled = False
            btnLineaCredito.Enabled = True
            btnNotaCredito.Enabled = True
            btnAnticipos.Enabled = True
            btnMarketPlace.Enabled = False
        End If
    End Sub

    Private Sub SchedularActualizarNotasVentaCallback(e As Object)
        If Me.DgvNotasVenta.InvokeRequired Then
            Dim del As New DelActualizarGrillaNotasVenta(AddressOf ActualizarNotasVentaOrdenesServicio)
            Me.Invoke(del)
        Else
            Call ActualizarNotasVentaOrdenesServicio()
        End If

    End Sub

    Private Sub SchedularActualizarNotasCreditoCallback(e As Object)
        If Me.DgvNotasCreditoWorkflow.InvokeRequired Then
            Dim del As New DelActualizarGrillaNotasCredito(AddressOf ActualizarNotasCreditoWorkflow)
            Me.Invoke(del)
        Else
            Call ActualizarNotasCreditoWorkflow()
        End If

    End Sub

    Private Sub ActualizarNotasVentaOrdenesServicio()
        If Configuracion.IDTipoUsuario = 30 Then '30 = Cajero POS
            dtbVwPosNotaVentaOrdenServicio = tbaVwPosNotaVentaOrdenServicio.GetDataByIdTienda(Configuracion.IDTiendaSAP)

        ElseIf Configuracion.IDTipoUsuario = 42 Then '42 = Cajero POS Televentas
            dtbVwPosNotaVentaOrdenServicio = tbaVwPosNotaVentaTeleventas.GetDataByIdTienda(Configuracion.IDTiendaSAP)

        End If

        If dtbVwPosNotaVentaOrdenServicio.Rows.Count > 0 Then

            Dim primeraFilaMostrada As Integer = DgvNotasVenta.FirstDisplayedScrollingRowIndex
            DgvNotasVenta.AutoGenerateColumns = False
            DgvNotasVenta.DataSource = dtbVwPosNotaVentaOrdenServicio

            Try
                If DgvNotasVenta.Columns.GetColumnCount(DataGridViewElementStates.Visible) > 0 Then
                    DgvNotasVenta.Columns.Item("TipoDocImagen").Resizable = False

                    If primeraFilaMostrada >= 0 Then
                        DgvNotasVenta.FirstDisplayedScrollingRowIndex = primeraFilaMostrada
                    End If

                End If

            Catch ex As Exception

            End Try
        Else
            DgvNotasVenta.AutoGenerateColumns = False
            DgvNotasVenta.DataSource = dtbVwPosNotaVentaOrdenServicio

        End If

    End Sub

    Private Sub ActualizarNotasCreditoWorkflow()
        dtbVwPosNotaCredito = tbaVwPosNotaCredito.GetDataByIdTiendaUsuarioDevolucion(Configuracion.IDTiendaSAP)

        If dtbVwPosNotaCredito.Rows.Count > 0 Then

            Dim primeraFilaMostrada As Integer = DgvNotasCreditoWorkflow.FirstDisplayedScrollingRowIndex
            DgvNotasCreditoWorkflow.AutoGenerateColumns = False
            DgvNotasCreditoWorkflow.DataSource = dtbVwPosNotaCredito

            Try
                If DgvNotasCreditoWorkflow.Columns.GetColumnCount(DataGridViewElementStates.Visible) > 0 Then

                    If primeraFilaMostrada >= 0 Then
                        DgvNotasCreditoWorkflow.FirstDisplayedScrollingRowIndex = primeraFilaMostrada
                    End If

                End If

            Catch ex As Exception

            End Try
        Else
            DgvNotasCreditoWorkflow.AutoGenerateColumns = False
            DgvNotasCreditoWorkflow.DataSource = dtbVwPosNotaCredito

        End If

    End Sub

    Public Sub buttonBorderRadius(ByRef buttonObj As Object, ByVal borderRadiusINT As Integer)
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()

        'TOP LEFT CORNER
        p.AddArc(New Rectangle(0, 0, borderRadiusINT, borderRadiusINT), 180, 90)
        p.AddLine(40, 0, buttonObj.Width - borderRadiusINT, 0)

        'TOP RIGHT CORNER
        p.AddArc(New Rectangle(buttonObj.Width - borderRadiusINT, 0, borderRadiusINT, borderRadiusINT), -90, 90)
        p.AddLine(buttonObj.Width, 40, buttonObj.Width, buttonObj.Height - borderRadiusINT)

        'BOTTOM RIGHT CORNER
        p.AddArc(New Rectangle(buttonObj.Width - borderRadiusINT, buttonObj.Height - borderRadiusINT, borderRadiusINT, borderRadiusINT), 0, 90)
        p.AddLine(buttonObj.Width - borderRadiusINT, buttonObj.Height, borderRadiusINT, buttonObj.Height)

        'BOTTOM LEFT CORNER
        p.AddArc(New Rectangle(0, buttonObj.Height - borderRadiusINT, borderRadiusINT, borderRadiusINT), 90, 90)
        p.CloseFigure()
        buttonObj.Region = New Region(p)

    End Sub

    Private Sub btn_agregar_producto_Paint(sender As Object, e As PaintEventArgs) Handles btnAgregarProducto.Paint
        'buttonBorderRadius(sender, 10)
    End Sub

    Private Sub RadioButtonTarjeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel_Tarjeta.Visible = True
        Panel_Cheque.Visible = Not Panel_Tarjeta.Visible
    End Sub

    Private Sub RadioButtonCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel_Tarjeta.Visible = False
        Panel_Cheque.Visible = Not Panel_Tarjeta.Visible
    End Sub

    Private Sub RadioButtonCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel_Tarjeta.Visible = False
        Panel_Cheque.Visible = False
    End Sub

    Private Sub RadioButtonEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel_Tarjeta.Visible = False
        Panel_Cheque.Visible = False
    End Sub

    Private Sub btnEscanearCheque_Click(sender As Object, e As EventArgs) Handles btnEscanearCheque.Click
        Dim msgResult As MsgBoxResult = Nothing
        Dim obj_MICR As class_MICR = New class_MICR
        Dim arr_RawData As String() = Nothing
        Dim str_SBIF As String = ""
        Dim str_SucursalBanco As String = ""
        Dim int_posFind As Integer = -1
        Dim dtbSucursalBanco As DataTable = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            btnEscanearCheque.Enabled = False

            obj_MICR.Initialize()

            msgResult = MessageBox.Show("Inserte un cheque en la impresora y seleccione aceptar", "Escaneo de Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If msgResult = MsgBoxResult.Ok Then
                obj_MICR.BeginInsertion(1000)

                If String.IsNullOrEmpty(obj_MICR.RawData) = True Then
                    MessageBox.Show("Datos obtenidos del cheque vacios", "Escaneo de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If obj_MICR.RawData.Contains("r") = True Then
                        arr_RawData = obj_MICR.RawData.ToString().Split("r")

                        txt_numeroCuenta.Text = arr_RawData(2).ToString().Trim().Split("i")(0)
                        txt_nroCheque.Text = arr_RawData(0).ToString().Trim().Substring(1)

                        str_SBIF = arr_RawData(1).ToString().Trim.Substring(0, 3)
                        str_SucursalBanco = arr_RawData(1).ToString().Trim.Substring(3)

                        If String.IsNullOrEmpty(str_SBIF) = False Then
                            dtbBanco = tbaVwBanco.GetDataByCodigoSBIF(str_SBIF)

                            If dtbBanco.Rows.Count > 0 Then
                                int_posFind = cbx_banco.FindStringExact(dtbBanco.Rows(0).Item("bc_nombre"))
                                cbx_banco.SelectedIndex = int_posFind
                            End If

                            dtbSucursalBanco = tbaPosSucursalBanco.GetDataByCodigoBanco(cbx_banco.SelectedValue)
                            cbx_plazaBanco.ValueMember = "codigo_sucursal"
                            cbx_plazaBanco.DisplayMember = "nombre_sucursal"
                            cbx_plazaBanco.DataSource = dtbSucursalBanco
                        End If

                        If String.IsNullOrEmpty(str_SucursalBanco) = False AndAlso IsNumeric(str_SucursalBanco) = True Then
                            If dtbSucursalBanco.Rows.Count > 0 Then
                                For Each DrvFila As DataRowView In cbx_plazaBanco.Items
                                    If Convert.ToInt32(DrvFila.Item("codigo_sucursal")) = Convert.ToInt32(str_SucursalBanco) Then
                                        cbx_plazaBanco.SelectedValue = Convert.ToInt32(DrvFila.Item("codigo_sucursal"))
                                    End If
                                Next
                            End If
                        End If

                    Else
                        MessageBox.Show("Datos obtenidos del cheque NO válidos. " & obj_MICR.RawData.ToString(), "Escaneo de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

                obj_MICR.Remove()
                obj_MICR.Close()

                If String.IsNullOrEmpty(obj_MICR.RawData) = True Then
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Cheque NO puso ser escaneado. " & ex.Message, "Escaneo de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
            btnEscanearCheque.Enabled = True
        End Try
    End Sub

    Private Sub btnValidarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidarCheque.Click
        Dim dtbBanco As DataTable = Nothing
        Dim obj_ORSAN As class_ORSAN = New class_ORSAN(Global.caja2.My.MySettings.Default.caja_OrsanWS_ChequesServiceURL, Global.caja2.My.MySettings.Default.caja_OrsanWS_IdUnico) 'CHC1390H28HB4709
        Dim str_SBIF As String = ""
        Dim str_SucursalBanco As String = ""
        Dim obj_respuesta As Respuesta = Nothing
        Dim header As String = ""
        Dim documento As String = ""
        Dim nombreBanco As String = ""
        Dim nombreSucursalBanco As String = ""

        Dim AsyncKey As String = "99999"
        Dim NII As String = "0005"
        Dim Producto As String = "C01"
        Dim Funcion As String = "011"
        Dim Version As String = "10"
        Dim ID_Unico As String = Global.caja2.My.MySettings.Default.caja_OrsanWS_IdUnico ' "CHC1390H28HB4709"
        Dim STAN As String = "051519"
        Dim Hora As String = Now.ToString("HHmmss") ' "111827"
        Dim Fecha As String = Now.ToString("yyyyMMdd") '"20160324"
        Dim origen As String = "02"
        Dim Captura As String = "0012"
        Dim Pacifico As String = "0000"
        Dim Reservado As String = New String(" ", 12) & "0" '"            0"

        Dim MICR As String = "0003694^00200037^07400163124/01                   "
        Dim RUT_Girador As String = "000000000108"
        Dim RUT_Titular As String = "000064114875"
        Dim Serie As String = "0000000000"
        Dim Telefono As String = "000000000000"
        Dim Monto As String = "000000062406"
        Dim Moneda As String = "152" ' 152 = Chilean pesos
        Dim Cuotas As String = "01"
        Dim Intervalo As String = "00"
        Dim Vence As String = Now.ToString("ddMMyyyy") ' "24032016"
        Dim Tipo_doc_Venta As String = "1" ' Sales Document Type (Reference Data) 1 = Ticket. 2 = Invoice
        Dim Nro_DocumentoVenta As String = "24111827"
        Dim Monto_Pie As String = "000000000000"
        Dim Tipo_Pie As String = "01"
        Dim Vendedor As String = New String(" ", 10)
        Dim Reservado2 As String = New String(" ", 40)

        Try

            'verificamos los datos del cheque

            btnValidarCheque.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            If IsNumeric(txt_montoCheque.Text) = False Then
                MessageBox.Show("Debe ingresar un monto antes de escanear", "Escaneo de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnValidarCheque.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub

            ElseIf txt_numeroCuenta.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar un número de cuenta antes de Verificar", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnValidarCheque.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub

            ElseIf txt_nroCheque.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar un número de cheque antes de Verificar", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnValidarCheque.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub

            ElseIf txt_rutCliente.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar el Rut del Cliente antes de Verificar", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnValidarCheque.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub

            ElseIf txt_rutGirador.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar el Rut del Girador antes de Verificar", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnValidarCheque.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub

            ElseIf validacionRut(txt_rutGirador.Text.Trim) = False Then
                MessageBox.Show("Debe ingresar un Rut de Girador válido antes de Verificar", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnValidarCheque.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub

            End If

            header = AsyncKey & NII & Producto & Funcion & Version & ID_Unico & STAN & Hora & Fecha & origen & Captura & Pacifico & Reservado

            dtbBanco = tbaVwBanco.GetDataByID(cbx_banco.SelectedValue)

            If dtbBanco.Rows.Count > 0 Then
                str_SBIF = dtbBanco.Rows(0).Item("codigo_SBIF").ToString()
                nombreBanco = dtbBanco.Rows(0).Item("bc_nombre").ToString().Trim()
            End If

            str_SBIF = New String("0", 3 - str_SBIF.Length) & str_SBIF

            If cbx_plazaBanco.SelectedValue Is Nothing Then
                str_SucursalBanco = "0000"
            Else
                str_SucursalBanco = cbx_plazaBanco.SelectedValue.ToString().Trim()
                str_SucursalBanco = New String("0", 4 - str_SucursalBanco.Length) & str_SucursalBanco
            End If

            MICR = txt_nroCheque.Text.Trim() & Chr(94) & str_SBIF & str_SucursalBanco & Chr(94) & txt_numeroCuenta.Text.Trim()
            MICR = MICR & New String(" ", 50 - MICR.Length)

            Monto = Regex.Replace(txt_montoCheque.Text.Trim, "[^0-9]", "")
            Monto = New String("0", 12 - Monto.Length) & Monto

            Serie = txt_nroCheque.Text.Trim
            Serie = New String("0", 10 - Serie.Length) & Serie

            RUT_Titular = Regex.Replace(txt_rutCliente.Text.Trim, "[^0-9Kk]", "")
            RUT_Titular = New String("0", 12 - RUT_Titular.Length) & RUT_Titular

            RUT_Girador = Regex.Replace(txt_rutGirador.Text.Trim, "[^0-9Kk]", "")
            RUT_Girador = New String("0", 12 - RUT_Girador.Length) & RUT_Girador

            If IDNotaVenta > 0 Then
                Nro_DocumentoVenta = IDNotaVenta.ToString()

            ElseIf IDOrdenServicio > 0 Then
                Nro_DocumentoVenta = IDOrdenServicio.ToString()

            ElseIf numeroDocumentoPOS > 0 Then
                Nro_DocumentoVenta = numeroDocumentoPOS.ToString()

            ElseIf numeroDocumentoPOS = 0 AndAlso pagandoDocumentos = True AndAlso IsNumeric(txt_idCliente.Text.Trim) = False Then

                MessageBox.Show("Debe ingresar rut del cliente antes de validar un cheque", "Validar Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            ElseIf numeroDocumentoPOS = 0 AndAlso pagandoDocumentos = True AndAlso IsNumeric(txt_idCliente.Text.Trim) = True Then

                dtbSPPosDocumentoCrear = tbaSPPosDocumentoCrear.GetData(1, numeroDocumentoPOS, Now, txt_idCliente.Text.Trim, txt_rutCliente.Text.Trim, Configuracion.IDUsuario, Configuracion.IDTiendaSAP)

                If dtbSPPosDocumentoCrear.Rows.Count > 0 Then
                    numeroDocumentoPOS = dtbSPPosDocumentoCrear.Rows(0).Item("dpc_numero")
                    lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()
                End If

                Nro_DocumentoVenta = numeroDocumentoPOS.ToString()
            Else
                MessageBox.Show("Datos de Cliente y/o Venta insuficientes para validar cheques", "Validar Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If

            Nro_DocumentoVenta = New String("0", 8 - Nro_DocumentoVenta.Length) & Nro_DocumentoVenta

            'se envia el rut del girador en vez del rut del titular por politicas de CAREN. Se supone que el rut del titular para ORSAN es quien porta el cheque y NO el rut de la empresa a la que se emite la factura o boleta
            documento = MICR & RUT_Girador & RUT_Girador & Serie & Telefono & Monto & Moneda & Cuotas & Intervalo & Vence & Tipo_doc_Venta & Nro_DocumentoVenta & Monto_Pie & Tipo_Pie & Vendedor & Reservado2

            txt_codigoAutorizacion.Text = ""
            lbl_codigoRechazoOrsan.Text = ""

            Dim idOrsanLog As Integer = tbaOrsanLog.InsertQuery("POS", numeroDocumentoPOS, Now, header & documento, Nothing, nombreBanco, Serie, txt_numeroCuenta.Text.Trim(), str_SBIF, str_SucursalBanco, Monto, RUT_Girador, Configuracion.IDUsuario,
                                                                Nothing, 0, 0, IDNotaVenta, IDCliente, Nothing, Nothing)
            obj_respuesta = obj_ORSAN.chequeProcess(header & documento)

            If Not obj_respuesta Is Nothing Then
                tbaOrsanLog.UpdateQuery(obj_respuesta.Data.Trim(), obj_respuesta.Respuesta, idOrsanLog)

                Imagen_Validacion_Cheque.Visible = True

                If obj_respuesta.Respuesta = "0" AndAlso IsNumeric(obj_respuesta.Autorizacion.ToString()) = True Then
                    txt_codigoAutorizacion.Text = obj_respuesta.Autorizacion.ToString()

                    If Convert.ToInt32(obj_respuesta.Autorizacion) > 0 Then
                        tbaOrsanLog.UpdateCodigoAutorizacion(obj_respuesta.Autorizacion, idOrsanLog)
                        Imagen_Validacion_Cheque.Image = caja2.My.Resources.Resources.Check

                    ElseIf Convert.ToInt32(obj_respuesta.Autorizacion) <= 0 Then
                        Imagen_Validacion_Cheque.Image = caja2.My.Resources.Resources.Cancel

                        Dim informacionRechazo As String = obj_respuesta.MensajeVisor.ToString().Trim() & ". "

                        If IsNumeric(obj_respuesta.Motivo1) = True Then
                            tbaOrsanLog.UpdateCodigoRechazo(obj_respuesta.Motivo1, idOrsanLog)
                            lbl_codigoRechazoOrsan.Text = obj_respuesta.Motivo1

                            dtbOrsanCodigoRechazo = tbaOrsanCodigoRechazo.GetDataByCodigoRechazo(obj_respuesta.Motivo1)

                            If dtbOrsanCodigoRechazo.Rows.Count > 0 Then
                                informacionRechazo = dtbOrsanCodigoRechazo.Rows(0).Item("ocr_descripcion").ToString() & "." & vbCrLf & dtbOrsanCodigoRechazo.Rows(0).Item("ocr_accionSugerida").ToString()
                            End If
                        End If

                        MessageBox.Show(informacionRechazo, "Verificación de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If
            Else
                Imagen_Validacion_Cheque.Visible = False
                MessageBox.Show("Respuesta ORSAN vacía", "Verificación de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Cheque NO pudo ser verificado. " & ex.Message, "Verificación Cheque en ORSAN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            btnValidarCheque.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnImprimirCheque_Click(sender As Object, e As EventArgs) Handles btnImprimirCheque.Click
        Dim dtbBanco As DataTable = Nothing
        Dim dlgResult As DialogResult = Nothing
        Dim obj_MICR As class_MICR = New class_MICR
        Dim obj_PosPrinter As class_PosPrinter = New class_PosPrinter
        Dim int_codigoFormato As Integer = Global.caja2.My.MySettings.Default.FormatoImpresionCheque
        Dim str_faseImpresion As String = ""
        Dim str_nombreCiudadCheque As String = Configuracion.ciudadCheque
        Dim str_montoEnPalabras As String
        Dim bol_resultado As Boolean

        Try
            If IsNumeric(txt_montoCheque.Text.Trim) = False Then
                MessageBox.Show("Debe ingresar un monto antes de imprimir un cheque", "Imprimir de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            Else
                str_montoEnPalabras = func_montoAPalabras(txt_montoCheque.Text)
            End If

            dtbPosCuentaDeposito = tbaPosCuentaDeposito.GetData()
            dtbPosFormatoImpresionCheque = tbaPosFormatoImpresionCheque.GetDataByCodigoFormato(int_codigoFormato)

            If dtbPosCuentaDeposito.Rows.Count = 0 Then
                MessageBox.Show("Debe configurar cuenta de depósito antes de imprimir", "Imprimir Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If Not cbx_plazaBanco.SelectedItem Is Nothing AndAlso TypeOf cbx_plazaBanco.SelectedItem Is DataRowView Then
            '    str_nombreCiudadCheque = CType(cbx_plazaBanco.SelectedItem, DataRowView).Row.Item("nombre_sucursal").ToString()
            'End If

            bol_resultado = obj_MICR.Initialize()
            bol_resultado = obj_PosPrinter.Initialize()

            dlgResult = MessageBox.Show("Inserte un cheque en la impresora y seleccione aceptar", "Imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If dlgResult = DialogResult.OK Then
                'bol_resultado = obj_MICR.BeginInsertion(1000)
                bol_resultado = obj_PosPrinter.WaitforInsertion(1000)

                'obj_PosPrinter.PrintBackSide(dtbPosCuentaDeposito.Rows(0))

                bol_resultado = obj_PosPrinter.PrintFrontSide(obj_MICR, obj_PosPrinter, DtpFechaVencCheque.Value, txt_montoCheque.Text, dtbPosCuentaDeposito.Rows(0).Item("nombre_destinatario").ToString(), str_nombreCiudadCheque,
                                                              str_montoEnPalabras, dtbPosFormatoImpresionCheque.Rows(0), int_codigoFormato)

                obj_PosPrinter.Remove()

                obj_MICR.Remove(Not bol_resultado)
                obj_MICR.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR btnImprimir_Click " & str_faseImpresion & vbCrLf & ex.Message & vbCrLf & ex.StackTrace, "Imprimir Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub btnImprimirCheque_MouseDown(sender As Object, e As MouseEventArgs) Handles btnImprimirCheque.MouseDown
        Dim dlgResult As DialogResult = Nothing
        Dim obj_MICR As class_MICR = New class_MICR
        Dim obj_PosPrinter As class_PosPrinter = New class_PosPrinter
        Dim int_codigoFormato As Integer = Global.caja2.My.MySettings.Default.FormatoImpresionCheque

        If Control.ModifierKeys = Keys.Shift Then

            dlgResult = MessageBox.Show("Inserte un cheque en la impresora y seleccione aceptar", "Imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If dlgResult = DialogResult.OK Then
                dtbPosCuentaDeposito = tbaPosCuentaDeposito.GetData()
                dtbPosFormatoImpresionCheque = tbaPosFormatoImpresionCheque.GetDataByCodigoFormato(int_codigoFormato)

                If dtbPosCuentaDeposito.Rows.Count > 0 Then
                    obj_MICR.Initialize()
                    obj_PosPrinter.Initialize()

                    obj_MICR.BeginInsertion(1000)

                    txt_montoCheque.Text = "10000"
                    obj_PosPrinter.PrintFrontSideTest(DtpFechaVencCheque.Value, txt_montoCheque.Text, "CAREN SPA", "Santiago,  ", func_montoAPalabras(txt_montoCheque.Text), dtbPosFormatoImpresionCheque.Rows(0), int_codigoFormato)
                    obj_PosPrinter.Remove()

                    obj_MICR.Remove()
                    obj_MICR.Close()

                Else
                    MessageBox.Show("Debe configurar cuenta de depósito antes de imprimir", "Imprimir Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If
    End Sub


    Private Sub RadioButton_boleta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_boleta.CheckedChanged
        txt_giro_cliente.Enabled = False
        cbx_ciudad_cliente.Enabled = False
        cbx_comuna_cliente.Enabled = False
        txt_direccion_cliente.Enabled = False
    End Sub

    Private Sub RadioButton_factura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_factura.CheckedChanged
        txt_giro_cliente.Enabled = True
        cbx_ciudad_cliente.Enabled = True
        cbx_comuna_cliente.Enabled = True
        txt_direccion_cliente.Enabled = True
    End Sub

    Private Sub Txt_cupon_TextChanged(sender As Object, e As EventArgs) Handles txt_cupon.TextChanged
        Label_OK_Cupon.Visible = False
        If txt_cupon.Text = "123456" Then Label_OK_Cupon.Visible = True
    End Sub

    Private Sub DgvNotasVenta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNotasVenta.CellContentClick
        Dim grvControl As DataGridView = CType(sender, DataGridView)
        Dim filaWeb As DataGridViewRow = Nothing
        Dim fila As DataRowView = Nothing

        Try
            If e.RowIndex >= 0 Then
                Me.Cursor = Cursors.WaitCursor

                Call limpiaDocumento()

                filaWeb = grvControl.CurrentRow
                fila = filaWeb.DataBoundItem

                If fila.Row.Item("tipoDoc") = 1 Then 'Nota de Venta
                    URL_notaVenta = Global.caja2.My.MySettings.Default.urlECommerce & "/msjNotaVenta.aspx?numeroNotaVenta=" & fila.Row.Item("numero").ToString()
                    WbbNotaVenta.Url = New Uri(URL_notaVenta)
                Else
                    WbbNotaVenta.Navigate(New Uri("about:blank"))
                End If

                Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DgvNotasVenta_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNotasVenta.CellDoubleClick
        Dim dgvControl As DataGridView = CType(sender, DataGridView)
        Dim filaWeb As DataGridViewRow = Nothing
        Dim fila As DataRowView = Nothing
        Dim rutCliente As String = ""

        'Try
        If dgvControl.SelectedRows.Count > 0 Then
            filaWeb = dgvControl.CurrentRow
            fila = filaWeb.DataBoundItem
        End If

        If fila.Row Is Nothing Then
        ElseIf fila.Row.Item("tipoDoc") = 1 AndAlso (Convert.ToInt32(fila.Row.Item("estado")) = 9 OrElse Convert.ToInt32(fila.Row.Item("estado")) = 11) Then ' 9 = Bloqueada, 11 =  Rechazada
            MessageBox.Show("Nota de Venta NO puede ser facturada debido a su estado", "Nota de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf fila.Row.Item("tipoDoc") = 2 AndAlso (Convert.ToInt32(fila.Row.Item("estado")) = 3 OrElse Convert.ToInt32(fila.Row.Item("estado")) = 5) Then ' 3	= por autorizar, 5 = rechazada
            MessageBox.Show("Orden de Servicio NO puede ser facturada debido a su estado", "Orden de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf fila.Row.Item("tipoDoc") = 3 AndAlso (Convert.ToInt32(fila.Row.Item("estado")) = 5 OrElse Convert.ToInt32(fila.Row.Item("estado")) = 7) Then ' 5	= por autorizar, 7 = rechazado
            MessageBox.Show("Documento Pago NO puede ser facturada debido a su estado", "Documento Pago", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf fila.Row.Item("tipoDoc") = 1 Then 'Nota de Venta
            filaNotaVenta = CType(tbaVwWebNotaVentaCab.GetDataByID(fila.Row.Item("numero")).Rows(0), DataSet_catalogo.vw_web_notaVentaCabRow)

            Call limpiaDocumento()
            chk_anticipo.Enabled = False

            IDNotaVenta = fila.Row.Item("numero")
            estadoNotaVenta = filaNotaVenta.Item("nombreEstadoNotaVenta").ToString()
            dtbSPPosDocumentoAgregaNotaVenta = tbaSPPosDocumentoAgregaNotaVenta.GetData(lblNumeroDocumento.Text.ToNullableInt, IDNotaVenta, Configuracion.IDUsuario)

            If dtbSPPosDocumentoAgregaNotaVenta.Rows.Count > 0 Then
                numeroDocumentoPOS = dtbSPPosDocumentoAgregaNotaVenta.Rows(0).Item("numeroDocumentoPOS").ToString()
                lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()
                txt_OC.Text = fila.Item("numeroOrdenCompra").ToString().Trim

                dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(lblNumeroDocumento.Text)
                If dtbPosDocumentoCab.Rows.Count > 0 Then
                    Configuracion.IDCliente = dtbPosDocumentoCab.Rows(0).Item("cli_id")
                    rutCliente = dtbPosDocumentoCab.Rows(0).Item("dpc_rut").ToString()
                    txt_rutGirador.Text = dtbPosDocumentoCab.Rows(0).Item("dpc_rut").ToString().Trim()
                    txt_rutGirador.Enabled = False
                    txt_rutGirador.ForeColor = Color.Black

                    If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") Is DBNull.Value Then
                        lblDatosDespacho.Text = ""
                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 1 Then 'Retiro en tienda
                        lblDatosDespacho.Text = "Datos Retiro en Tienda"
                        If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")) = True Then
                            txt_datosDespacho.Text = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")).ToShortDateString()
                        End If

                        txt_datosDespacho.Text &= " / Tienda : " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreTiendaDespacho").ToString() & " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_rutRetiroTienda").ToString() & " - " &
                                                  dtbPosDocumentoCab.Rows(0).Item("dpc_nombreRetiroTienda").ToString()

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 2 Then 'Despacho a Domicilio
                        lblDatosDespacho.Text = "Datos Despacho a Domicilio"
                        If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")) = True Then
                            txt_datosDespacho.Text = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")).ToShortDateString()
                        End If

                        Dim aDireccionDespacho() As String = dtbPosDocumentoCab.Rows(0).Item("dpc_direccionDespacho").ToString().Split("|")

                        If aDireccionDespacho.Length > 0 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(0)
                        End If
                        If aDireccionDespacho.Length > 1 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(1)
                        End If
                        If aDireccionDespacho.Length > 2 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(2)
                        End If

                        txt_datosDespacho.Text &= " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreComunaDespacho").ToString() & " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreCiudadDespacho").ToString()

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 3 Then 'Retira Vendedor
                        txt_datosDespacho.Text = ""

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 4 Then 'Envio por Pagar
                        txt_datosDespacho.Text = ""

                    End If

                End If
            End If

            If DgvDetalleProductos.Rows.Count > 0 Then
                If filaNotaVenta.Item("nvc_idTipoDocFacturacion") = 1 AndAlso txt_rutCliente.Text <> filaNotaVenta.Item("nvc_rutClienteBoleta").ToString().Trim Then
                    MessageBox.Show("Debe eliminar todos los productos antes de seleccionar un cliente distinto", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                ElseIf filaNotaVenta.Item("nvc_idTipoDocFacturacion") = 2 AndAlso txt_rutCliente.Text <> filaNotaVenta.Item("nvc_rutFacturacion").ToString().Trim Then
                    MessageBox.Show("Debe eliminar todos los productos antes de seleccionar un cliente distinto", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
            End If

            TabPagos.SelectedIndex = 0

            lbl_creditoDispCliente.Visible = True
            txt_nombreCajero.Text = Configuracion.NombreUsuario '"cajero 1"
            txt_vendedor.Text = "Vendedor " & "3"
            txt_NotaVenta.Text = filaNotaVenta.Item("nvc_numero").ToString()
            txt_idCliente.Text = filaNotaVenta.Item("cli_id").ToString()
            txt_rutCliente.Text = filaNotaVenta.Item("nvc_rut").ToString()

            dtbVwCliente = tbaVwCliente.GetDataByTaxNumber(txt_rutCliente.Text.Trim)

            If dtbVwCliente.Rows.Count > 0 Then
                Call ActualizarDatosCliente(dtbVwCliente)
            End If

            If filaNotaVenta.Item("nvc_idTipoDocFacturacion") Is DBNull.Value Then
                RadioButton_boleta.Checked = True

            ElseIf filaNotaVenta.Item("nvc_idTipoDocFacturacion") = 1 Then 'boleta
                RadioButton_boleta.Checked = True

            Else
                RadioButton_factura.Checked = True

            End If

            If txt_idCliente.Text.StartsWith("005") = True Then
                lbl_tituloCliente.Text = "Datos del Funcionario"
                btnLineaFuncionario.Visible = True
                Call btnLineaFuncionario_Click(sender, New EventArgs())
            Else
                lbl_tituloCliente.Text = "Datos del Cliente"
                btnLineaFuncionario.Visible = False
            End If

            LlenarGrillaDetalle(numeroDocumentoPOS)

            If Not IsDBNull(filaNotaVenta.Item("nvc_idTipoMedioPago")) Then

                btnMarketPlace.Visible = filaNotaVenta.Item("nvc_idTipoMedioPago") = 9

                seleccionaMedioPago(filaNotaVenta.Item("nvc_idTipoMedioPago"))
            End If

            txt_medioPago.Text = filaNotaVenta.Item("nombreTipoMedioPago").ToString()

            If estadoNotaVenta = "Liberada" Then
                btnAgregarProducto.Enabled = False
            End If

            'obtenemos el crédito del cliente desde SAP

            Call EstadoBotonesPago()
            Call ActualizarCreditoCliente(rutCliente, txt_idCliente.Text.Trim, estadoNotaVenta)

            If tbaNotaVentaAccion.CuentaByNumeroNotaVentaAccionFecha(IDNotaVenta, "Liberar") > 0 OrElse tbaNotaVentaAccion.CuentaByNumeroNotaVentaAccionFecha(IDNotaVenta.ToString().PadLeft(10, "0"), "Liberar") > 0 Then
                LlenarGrillaDetallePago(numeroDocumentoPOS)
                dtbPosDocumentoDetPago = tbaPosDocumentoDetPago.GetDataByNumero(numeroDocumentoPOS)

                If dtbPosDocumentoDetPago.Rows.Count > 0 Then
                    Call BloquearBotonesPago()
                End If

            End If
        ElseIf fila.Row.Item("tipoDoc") = 2 Then 'Orden de Servicio
            Call limpiaDocumento()
            chk_anticipo.Enabled = False
            estadoNotaVenta = ""

            IDOrdenServicio = fila.Row.Item("numero")

            dtbSPPosDocumentoAgregaOrdenServicio = tbaSPPosDocumentoAgregaOrdenServicio.GetData(numeroDocumentoPOS, IDOrdenServicio, Configuracion.IDUsuario)

            If dtbSPPosDocumentoAgregaOrdenServicio.Rows.Count > 0 Then
                numeroDocumentoPOS = dtbSPPosDocumentoAgregaOrdenServicio.Rows(0).Item("numeroDocumentoPOS").ToString()
                lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()

                dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(lblNumeroDocumento.Text)
                If dtbPosDocumentoCab.Rows.Count > 0 Then
                    filaPosDocumentoCab = dtbPosDocumentoCab.Rows(0)
                    Configuracion.IDCliente = dtbPosDocumentoCab.Rows(0).Item("cli_id")
                    rutCliente = dtbPosDocumentoCab.Rows(0).Item("dpc_rut").ToString()

                    If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") Is DBNull.Value Then
                        lblDatosDespacho.Text = ""
                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 1 Then 'Retiro en tienda
                        lblDatosDespacho.Text = "Datos Retiro en Tienda"
                        If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")) = True Then
                            txt_datosDespacho.Text = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")).ToShortDateString()
                        End If

                        txt_datosDespacho.Text &= " / Tienda : " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreTiendaDespacho").ToString() & " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_rutRetiroTienda").ToString() & " - " &
                                                  dtbPosDocumentoCab.Rows(0).Item("dpc_nombreRetiroTienda").ToString()

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 2 Then 'Despacho a Domicilio
                        lblDatosDespacho.Text = "Datos Despacho a Domicilio"
                        If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")) = True Then
                            txt_datosDespacho.Text = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")).ToShortDateString()
                        End If

                        Dim aDireccionDespacho() As String = dtbPosDocumentoCab.Rows(0).Item("dpc_direccionDespacho").ToString().Split("|")

                        If aDireccionDespacho.Length > 0 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(0)
                        End If
                        If aDireccionDespacho.Length > 1 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(1)
                        End If
                        If aDireccionDespacho.Length > 2 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(2)
                        End If

                        txt_datosDespacho.Text &= " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreComunaDespacho").ToString() & " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreCiudadDespacho").ToString()

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 3 Then 'Retira Vendedor
                        txt_datosDespacho.Text = ""

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 4 Then 'Envio por Pagar
                        txt_datosDespacho.Text = ""

                    End If

                End If
            End If

            If DgvDetalleProductos.Rows.Count > 0 Then
                If filaPosDocumentoCab.Item("dpc_idTipoDocFacturacion") = 1 AndAlso txt_rutCliente.Text <> filaPosDocumentoCab.Item("dpc_rutClienteBoleta").ToString().Trim Then
                    MessageBox.Show("Debe eliminar todos los productos antes de seleccionar un cliente distinto", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                ElseIf filaPosDocumentoCab.Item("dpc_idTipoDocFacturacion") = 2 AndAlso txt_rutCliente.Text <> filaPosDocumentoCab.Item("dpc_rutFacturacion").ToString().Trim Then
                    MessageBox.Show("Debe eliminar todos los productos antes de seleccionar un cliente distinto", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
            End If

            txt_nombreCajero.Text = Configuracion.NombreUsuario '"cajero 1"
            txt_vendedor.Text = filaPosDocumentoCab.Item("dpc_nombreVendedor").ToString()
            txt_NotaVenta.Text = filaPosDocumentoCab.Item("dpc_numDocOrigen").ToString()

            TabPagos.SelectedIndex = 0
            lbl_creditoDispCliente.Visible = True

            txt_rutCliente.Text = filaPosDocumentoCab.Item("dpc_rut").ToString()

            dtbVwCliente = tbaVwCliente.GetDataByTaxNumber(txt_rutCliente.Text.Trim)

            If dtbVwCliente.Rows.Count > 0 Then
                Call ActualizarDatosCliente(dtbVwCliente)
            End If

            If filaPosDocumentoCab.Item("dpc_idTipoDocFacturacion") Is DBNull.Value OrElse filaPosDocumentoCab.Item("dpc_idTipoDocFacturacion") = 1 Then 'boleta
                RadioButton_boleta.Checked = True

            Else
                RadioButton_factura.Checked = True

            End If

            If txt_email_cliente.Text.Contains("@caren.cl") = True Then
                lbl_tituloCliente.Text = "Datos del Funcionario"
            Else
                lbl_tituloCliente.Text = "Datos del Cliente"
                btnLineaFuncionario.Visible = False
            End If

            LlenarGrillaDetalle(numeroDocumentoPOS)

            DgvDetalleProductos.Enabled = False
            txt_codigo_CAREN.Enabled = False
            txt_cantidad.Enabled = False
            btnBuscarProducto.Enabled = False
            btnAgregarProducto.Enabled = False

            If Not IsDBNull(filaPosDocumentoCab.Item("dpc_idTipoMedioPago")) Then

                btnMarketPlace.Visible = filaPosDocumentoCab.Item("dpc_idTipoMedioPago") = 9

                seleccionaMedioPago(filaPosDocumentoCab.Item("dpc_idTipoMedioPago"))
            End If

            RadioButton_boleta.Checked = False
            RadioButton_factura.Checked = False
            RadioButton_notaCredito.Checked = False

            btnAgregarProducto.Enabled = False

            'obtenemos el crédito del cliente desde SAP

            Call ActualizarCreditoCliente(rutCliente, txt_idCliente.Text.Trim, estadoNotaVenta)

            If tbaNotaVentaAccion.CuentaByNumeroNotaVentaAccionFecha(IDOrdenServicio, "Liberar") > 0 OrElse tbaNotaVentaAccion.CuentaByNumeroNotaVentaAccionFecha(IDOrdenServicio.ToString().PadLeft(10, "0"), "Liberar") > 0 Then
                LlenarGrillaDetallePago(numeroDocumentoPOS)
                dtbPosDocumentoDetPago = tbaPosDocumentoDetPago.GetDataByNumero(numeroDocumentoPOS)

                If dtbPosDocumentoDetPago.Rows.Count > 0 Then
                    Call BloquearBotonesPago()
                End If
            End If

        ElseIf fila.Row.Item("tipoDoc") = 3 Then 'Documento Pago POS
            Call limpiaDocumento()
            chk_anticipo.Enabled = False

            numeroDocumentoPOS = fila.Row.Item("numero")

            dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(numeroDocumentoPOS)

            lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()

            dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(lblNumeroDocumento.Text)
            If dtbPosDocumentoCab.Rows.Count > 0 Then
                filaPosDocumentoCab = dtbPosDocumentoCab.Rows(0)
                Configuracion.IDCliente = dtbPosDocumentoCab.Rows(0).Item("cli_id")
                rutCliente = dtbPosDocumentoCab.Rows(0).Item("dpc_rut").ToString()

                If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDocumento") Is DBNull.Value Then
                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDocumento") = 2 Then ' 2 = Pago de Documentos
                    chk_anticipo.Checked = False
                    RadioButton_boleta.Enabled = False
                    RadioButton_factura.Enabled = False
                    RadioButton_notaCredito.Enabled = False
                    btnFacturar.Enabled = False
                    btnPagarDocumentos.Enabled = True
                    pagandoDocumentos = True

                    pnl_totalDocumentos.Visible = True
                    pnl_totalProductos.Visible = False
                    chk_imprimirDocumento.Checked = True
                    chk_emailDocumento.Checked = False
                    chk_emailDocumento.Enabled = False

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDocumento") = 3 Then ' 3 = Anticipo
                    chk_anticipo.Checked = True
                    RadioButton_boleta.Enabled = False
                    RadioButton_factura.Enabled = False
                    RadioButton_notaCredito.Enabled = False
                    btnFacturar.Enabled = False
                    btnPagarDocumentos.Enabled = True
                    pagandoDocumentos = False

                End If

                If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") Is DBNull.Value Then
                    lblDatosDespacho.Text = ""
                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 1 Then 'Retiro en tienda
                    lblDatosDespacho.Text = "Datos Retiro en Tienda"
                    If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")) = True Then
                        txt_datosDespacho.Text = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")).ToShortDateString()
                    End If

                    txt_datosDespacho.Text &= " / Tienda : " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreTiendaDespacho").ToString() & " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_rutRetiroTienda").ToString() & " - " &
                                                  dtbPosDocumentoCab.Rows(0).Item("dpc_nombreRetiroTienda").ToString()

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 2 Then 'Despacho a Domicilio
                    lblDatosDespacho.Text = "Datos Despacho a Domicilio"
                    If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")) = True Then
                        txt_datosDespacho.Text = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")).ToShortDateString()
                    End If

                    Dim aDireccionDespacho() As String = dtbPosDocumentoCab.Rows(0).Item("dpc_direccionDespacho").ToString().Split("|")

                    If aDireccionDespacho.Length > 0 Then
                        txt_datosDespacho.Text &= " " & aDireccionDespacho(0)
                    End If
                    If aDireccionDespacho.Length > 1 Then
                        txt_datosDespacho.Text &= " " & aDireccionDespacho(1)
                    End If
                    If aDireccionDespacho.Length > 2 Then
                        txt_datosDespacho.Text &= " " & aDireccionDespacho(2)
                    End If

                    txt_datosDespacho.Text &= " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreComunaDespacho").ToString() & " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreCiudadDespacho").ToString()

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 3 Then 'Retira Vendedor
                    txt_datosDespacho.Text = ""

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 4 Then 'Envio por Pagar
                    txt_datosDespacho.Text = ""

                End If

            End If

            If DgvDetalleProductos.Rows.Count > 0 Then
                If filaPosDocumentoCab.Item("dpc_idTipoDocFacturacion") = 1 AndAlso txt_rutCliente.Text <> filaPosDocumentoCab.Item("dpc_rutClienteBoleta").ToString().Trim Then
                    MessageBox.Show("Debe eliminar todos los productos antes de seleccionar un cliente distinto", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                ElseIf filaPosDocumentoCab.Item("dpc_idTipoDocFacturacion") = 2 AndAlso txt_rutCliente.Text <> filaPosDocumentoCab.Item("dpc_rutFacturacion").ToString().Trim Then
                    MessageBox.Show("Debe eliminar todos los productos antes de seleccionar un cliente distinto", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
            End If

            txt_nombreCajero.Text = Configuracion.NombreUsuario '"cajero 1"
            txt_vendedor.Text = filaPosDocumentoCab.Item("dpc_nombreVendedor").ToString()
            txt_NotaVenta.Text = filaPosDocumentoCab.Item("dpc_numDocOrigen").ToString()

            TabPagos.SelectedIndex = 0
            lbl_creditoDispCliente.Visible = True

            txt_rutCliente.Text = filaPosDocumentoCab.Item("dpc_rut").ToString()

            dtbVwCliente = tbaVwCliente.GetDataByTaxNumber(txt_rutCliente.Text.Trim)

            If dtbVwCliente.Rows.Count > 0 Then
                Call ActualizarDatosCliente(dtbVwCliente)
            End If

            If filaPosDocumentoCab.Item("dpc_idTipoDocFacturacion") Is DBNull.Value OrElse filaPosDocumentoCab.Item("dpc_idTipoDocFacturacion") = 1 Then 'boleta
                RadioButton_boleta.Checked = True

            Else
                RadioButton_factura.Checked = True

            End If

            If txt_email_cliente.Text.Contains("@caren.cl") = True Then
                lbl_tituloCliente.Text = "Datos del Funcionario"
            Else
                lbl_tituloCliente.Text = "Datos del Cliente"
                btnLineaFuncionario.Visible = False
            End If

            LlenarGrillaDetalle(numeroDocumentoPOS)

            DgvDetalleProductos.Enabled = False
            txt_codigo_CAREN.Enabled = False
            txt_cantidad.Enabled = False
            btnBuscarProducto.Enabled = False
            btnAgregarProducto.Enabled = False

            If Not IsDBNull(filaPosDocumentoCab.Item("dpc_idTipoMedioPago")) Then

                btnMarketPlace.Visible = filaPosDocumentoCab.Item("dpc_idTipoMedioPago") = 9

                seleccionaMedioPago(filaPosDocumentoCab.Item("dpc_idTipoMedioPago"))
            End If

            RadioButton_boleta.Checked = False
            RadioButton_factura.Checked = False
            RadioButton_notaCredito.Checked = False

            btnAgregarProducto.Enabled = False

            'obtenemos el crédito del cliente desde SAP

            Call ActualizarCreditoCliente(rutCliente, txt_idCliente.Text.Trim, estadoNotaVenta)

            If tbaNotaVentaAccion.CuentaByNumeroNotaVentaAccionFecha("A" & numeroDocumentoPOS.ToString(), "Liberar") > 0 Then
                LlenarGrillaDetallePago(numeroDocumentoPOS)
                Call BloquearBotonesPago()

                SincronizarGrillaDetallePagoDoc(numeroDocumentoPOS)
                btnFacturar.Enabled = False
                btnFacturar.BackColor = Color.LightGray

            End If

        End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Nota de Venta", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'End Try

    End Sub

    Private Sub DgvNotasCreditoWorkflow_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNotasCreditoWorkflow.CellDoubleClick
        Dim dgvControl As DataGridView = CType(sender, DataGridView)
        Dim filaWeb As DataGridViewRow = Nothing
        Dim fila As DataRowView = Nothing
        Dim rutCliente As String = ""
        Dim numeroSolicitudAvisoGarantia As Integer = 0

        'Try
        If dgvControl.SelectedRows.Count > 0 Then
            filaWeb = dgvControl.CurrentRow
            fila = filaWeb.DataBoundItem
        End If

        If fila.Row Is Nothing Then
        ElseIf fila.Row.Item("estado") Is DBNull.Value OrElse Convert.ToInt32(fila.Row.Item("estado")) <> 2 Then ' 1 = abierta, 2 = aprobada
            MessageBox.Show("Nota de Crédito NO puede ser facturada debido a su estado", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf Convert.ToInt32(fila.Row.Item("estado")) = 2 Then '2 = Nota de Crédito aprobada

            Call limpiaDocumento()
            chk_anticipo.Enabled = False

            IDDevolucion = fila.Row.Item("numero")

            dtbSolicitudDevolucion = tbaSolicitudDevolucion.GetDataByID(IDDevolucion)
            If dtbSolicitudDevolucion.Rows.Count > 0 Then
                If dtbSolicitudDevolucion.Rows(0).Item("sdtn_id") = 3 Then
                    numeroSolicitudAvisoGarantia = dtbSolicitudDevolucion.Rows(0).Item("sag_ID")

                    If ActualizarResolucionGarantia(numeroSolicitudAvisoGarantia) = False Then
                        MessageBox.Show("Nota de Crédito NO puede ser facturada debido a que no se ha recibido información de la resolución", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If

            dtbSPPosDocumentoAgregaDevolucion = tbaSPPosDocumentoAgregaDevolucion.GetData(numeroDocumentoPOS, IDDevolucion, Configuracion.IDUsuario)

            If dtbSPPosDocumentoAgregaDevolucion.Rows.Count > 0 Then
                numeroDocumentoPOS = dtbSPPosDocumentoAgregaDevolucion.Rows(0).Item("numeroDocumentoPOS").ToString()
                lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()

                dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(lblNumeroDocumento.Text)
                If dtbPosDocumentoCab.Rows.Count > 0 Then
                    filaPosDocumentoCab = dtbPosDocumentoCab.Rows(0)
                    Configuracion.IDCliente = dtbPosDocumentoCab.Rows(0).Item("cli_id")
                    rutCliente = dtbPosDocumentoCab.Rows(0).Item("dpc_rut").ToString()

                    If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") Is DBNull.Value Then
                        lblDatosDespacho.Text = ""
                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 1 Then 'Retiro en tienda
                        lblDatosDespacho.Text = "Datos Retiro en Tienda"
                        If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")) = True Then
                            txt_datosDespacho.Text = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")).ToShortDateString()
                        End If

                        txt_datosDespacho.Text &= " / Tienda : " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreTiendaDespacho").ToString() & " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_rutRetiroTienda").ToString() & " - " &
                                                  dtbPosDocumentoCab.Rows(0).Item("dpc_nombreRetiroTienda").ToString()

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 2 Then 'Despacho a Domicilio
                        lblDatosDespacho.Text = "Datos Despacho a Domicilio"
                        If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")) = True Then
                            txt_datosDespacho.Text = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")).ToShortDateString()
                        End If

                        Dim aDireccionDespacho() As String = dtbPosDocumentoCab.Rows(0).Item("dpc_direccionDespacho").ToString().Split("|")

                        If aDireccionDespacho.Length > 0 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(0)
                        End If
                        If aDireccionDespacho.Length > 1 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(1)
                        End If
                        If aDireccionDespacho.Length > 2 Then
                            txt_datosDespacho.Text &= " " & aDireccionDespacho(2)
                        End If

                        txt_datosDespacho.Text &= " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreComunaDespacho").ToString() & " / " & dtbPosDocumentoCab.Rows(0).Item("dpc_nombreCiudadDespacho").ToString()

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 3 Then 'Retira Vendedor
                        txt_datosDespacho.Text = ""

                    ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 4 Then 'Envio por Pagar
                        txt_datosDespacho.Text = ""

                    End If

                End If
            Else
                MessageBox.Show("Nota de Crédito NO puede ser facturada. Documento de origen tiene datos incorrectos.", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call limpiaDocumento()
                Exit Sub
            End If

            txt_nombreCajero.Text = Configuracion.NombreUsuario '"cajero 1"
            txt_vendedor.Text = filaPosDocumentoCab.Item("dpc_nombreVendedor").ToString()
            txt_NotaVenta.Text = filaPosDocumentoCab.Item("dpc_numDocOrigen").ToString()

            TabPagos.SelectedIndex = 0
            lbl_creditoDispCliente.Visible = True

            txt_rutCliente.Text = filaPosDocumentoCab.Item("dpc_rut").ToString()

            dtbVwCliente = tbaVwCliente.GetDataByTaxNumber(txt_rutCliente.Text.Trim)

            If dtbVwCliente.Rows.Count > 0 Then
                Call ActualizarDatosCliente(dtbVwCliente)
            End If

            RadioButton_boleta.Checked = False
            RadioButton_factura.Checked = False

            RadioButton_boleta.Enabled = False
            RadioButton_factura.Enabled = False

            RadioButton_notaCredito.Checked = True
            RadioButton_notaCredito.Enabled = True

            If txt_email_cliente.Text.Contains("@caren.cl") = True Then
                lbl_tituloCliente.Text = "Datos del Funcionario"
            Else
                lbl_tituloCliente.Text = "Datos del Cliente"
                btnLineaFuncionario.Visible = False
            End If

            LlenarGrillaDetalleDesdeNotaCredito(numeroDocumentoPOS)

            DgvDetalleProductos.Enabled = False
            txt_codigo_CAREN.Enabled = False
            txt_cantidad.Enabled = False
            btnBuscarProducto.Enabled = False
            btnAgregarProducto.Enabled = False

            'obtenemos el crédito del cliente desde SAP

            Call ActualizarCreditoCliente(rutCliente, txt_idCliente.Text.Trim, "")

            'bloqueamos controles no permitidos para Notas de Crédito 
            chk_anticipo.Enabled = False
            btnPagarDocumentos.Enabled = False
            btnPagarDocumentos.BackColor = Color.LightGray
            Call EstadoBotonesPago()
            btnAgregarEfectivo.Enabled = False

            'activamos el botón para facturar la Nota de crédito
            btnFacturar.Enabled = True
            btnFacturar.BackColor = Color.DarkOrange
        End If
    End Sub

    Private Sub ActualizarCreditoCliente(ByVal rutCliente As String, ByVal IDCliente As String, ByVal estadoNotaVenta As String)
        Dim obj_controlCredito As ControlCreditoModel = Nothing
        Dim obj_sap As class_sap = Nothing
        Dim str_resultadoJSON As String = ""

        Dim obj_estadosDocumentos As EstadoPartidasCliente

        Try
            With Global.caja2.My.MySettings.Default
                obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
            End With

            totalSobregiroCliente = 0
            dtbFncMontoSobregiroLineaCredito = tbaFncMontoSobregiroLineaCredito.GetData(IDCliente)
            If dtbFncMontoSobregiroLineaCredito.Rows.Count > 0 AndAlso Not dtbFncMontoSobregiroLineaCredito.Rows(0).Item("montoSobregiro") Is DBNull.Value Then
                totalSobregiroCliente = dtbFncMontoSobregiroLineaCredito.Rows(0).Item("montoSobregiro")
            End If

            obj_estadosDocumentos = obj_sap.func_estadosPartidasAbiertasCliente(IDCliente)

            str_resultadoJSON = obj_sap.getControlCredito(rutCliente)

            If String.IsNullOrEmpty(str_resultadoJSON) = False Then
                obj_controlCredito = JsonConvert.DeserializeObject(Of ControlCreditoModel)(str_resultadoJSON)

                If Not obj_controlCredito Is Nothing Then
                    lbl_creditoDispCliente.Text = String.Format(nbfInfo, "$ {0:N0}", obj_controlCredito.LineaCredito.Disponible.ToDblEng())
                    lbl_creditoDispCliente.Refresh()

                    totalLineaCliente = obj_controlCredito.LineaCredito.Totallinea.ToDblEng()
                    totalDisponibleCliente = obj_controlCredito.LineaCredito.Disponible.ToDblEng()

                    If totalLineaCliente = 0 Then 'cliente no tiene linea de crédito en SAP
                        btnLineaCredito.Enabled = False
                        btnLineaCredito.Text = "Linea NO Disp.(N)"
                        btnAgregarMontoCuenta.Enabled = False

                    ElseIf estadoNotaVenta = "Liberada" Then 'Nota de Venta liberada. Es posible cambiar el monto de linea si es cero o negativo
                        btnLineaCredito.Enabled = True
                        btnLineaCredito.Text = "Línea Crédito.(L)"
                        btnAgregarMontoCuenta.Enabled = True

                        If totalDisponibleCliente <= 0 Then
                            txt_montoLineaCredito.Enabled = True
                        End If

                    ElseIf estadoNotaVenta = "Autorizada" Then 'Nota de Venta autorizada. NO se permite cambiar el monto porque se debe respetar el monto autorizado
                        btnLineaCredito.Enabled = True
                        btnLineaCredito.Text = "Línea Crédito.(A)"
                        btnAgregarMontoCuenta.Enabled = True
                        txt_montoLineaCredito.Enabled = False

                    ElseIf obj_controlCredito.LineaCredito.Estatus = "true" Then 'cliente ha sido bloqueado manualmente en ERP
                        btnLineaCredito.Enabled = False
                        btnLineaCredito.Text = "Linea NO Disp.(B)"
                        btnAgregarMontoCuenta.Enabled = False

                    ElseIf ((totalDisponibleCliente + totalSobregiroCliente) < totalFinal) Then 'la suma del disponible en su linea de crédito más su monto de sobregiro permitido es inferior al total de la venta
                        btnLineaCredito.Enabled = False
                        btnLineaCredito.Text = "Linea NO Disp.(E)"
                        btnAgregarMontoCuenta.Enabled = False
                        txt_montoLineaCredito.Enabled = False

                    ElseIf (obj_estadosDocumentos.EstadoFacturas > 0 OrElse obj_estadosDocumentos.EstadoCheques > 0) Then 'cliente tiene facturas o cheques en estado no permitido

                        If obj_estadosDocumentos.EstadoFacturas > 0 Then '1 = Facturas impagas
                            btnLineaCredito.Enabled = False
                            btnLineaCredito.Text = "Linea NO Disp.(F)"
                            btnAgregarMontoCuenta.Enabled = False
                        End If

                        If obj_estadosDocumentos.EstadoCheques > 0 Then '1 = Cheques impagos
                            btnCheque.Enabled = False
                            btnCheque.Text = "Cheque NO Disp.(CH)"
                            btnAgregarCheque.Enabled = False
                        End If

                    Else 'la linea de crédito está disponible para uso.
                        btnLineaCredito.Enabled = True
                        btnLineaCredito.Text = "Línea Crédito"
                        btnAgregarMontoCuenta.Enabled = True

                    End If
                End If

            Else
                lbl_creditoDispCliente.Text = ""
                MessageBox.Show("Información de crédito del Cliente NO pudo ser obtenida", "Estado Crédito Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            lbl_creditoDispCliente.Text = ""
            MessageBox.Show("Información de crédito del Cliente NO pudo ser obtenida", "Estado Crédito Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'Private Sub ActualizarCreditoCliente(ByVal rutCliente As String, ByVal IDCliente As String, ByVal estadoNotaVenta As String)
    '    Dim obj_controlCredito As ControlCreditoModel = Nothing
    '    Dim obj_sap As class_sap = Nothing
    '    Dim str_resultadoJSON As String = ""
    '    Dim obj_estadosDocumentos As EstadoPartidasCliente

    '    Try
    '        With Global.caja2.My.MySettings.Default
    '            obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
    '        End With

    '        dtbFncMontoSobregiroLineaCredito = tbaFncMontoSobregiroLineaCredito.GetData(IDCliente)
    '        If dtbFncMontoSobregiroLineaCredito.Rows.Count > 0 Then
    '            totalSobregiroCliente = dtbFncMontoSobregiroLineaCredito.Rows(0).Item("montoSobregiro")
    '        Else
    '            totalSobregiroCliente = 0
    '        End If

    '        obj_estadosDocumentos = obj_sap.func_estadosPartidasAbiertasCliente(IDCliente)

    '        str_resultadoJSON = obj_sap.getControlCredito(rutCliente)

    '        If String.IsNullOrEmpty(str_resultadoJSON) = False Then
    '            obj_controlCredito = JsonConvert.DeserializeObject(Of ControlCreditoModel)(str_resultadoJSON)

    '            If Not obj_controlCredito Is Nothing Then
    '                lbl_creditoDispCliente.Text = String.Format(nbfInfo, "$ {0:N0}", obj_controlCredito.LineaCredito.Disponible.ToDblEng())
    '                lbl_creditoDispCliente.Refresh()

    '                totalLineaCliente = obj_controlCredito.LineaCredito.Totallinea.ToDblEng()
    '                totalDisponibleCliente = obj_controlCredito.LineaCredito.Disponible.ToDblEng()

    '                If totalLineaCliente = 0 Then 'cliente no tiene linea de crédito
    '                    btnLineaCredito.Enabled = False
    '                    btnLineaCredito.Text = "Linea NO Disp.(N)"
    '                    btnAgregarMontoCuenta.Enabled = False

    '                ElseIf obj_controlCredito.LineaCredito.Estatus = "true" Then 'cliente bloqueado
    '                    btnLineaCredito.Enabled = False
    '                    btnLineaCredito.Text = "Linea NO Disp.(B)"
    '                    btnAgregarMontoCuenta.Enabled = False

    '                ElseIf estadoNotaVenta = "Liberada" OrElse estadoNotaVenta = "Autorizada" Then
    '                    btnLineaCredito.Enabled = True
    '                    btnLineaCredito.Text = "Línea Crédito"
    '                    btnAgregarMontoCuenta.Enabled = True

    '                    If totalDisponibleCliente <= 0 AndAlso estadoNotaVenta = "Liberada" AndAlso estadoNotaVenta <> "Autorizada" Then
    '                        txt_montoLineaCredito.Enabled = True
    '                    End If

    '                ElseIf ((totalDisponibleCliente + totalSobregiroCliente) < totalFinal) Then 'cliente no tiene disponible en su linea de crédito. Incluyendo su monto de sobregiro permitido
    '                    btnLineaCredito.Enabled = False
    '                    btnLineaCredito.Text = "Linea NO Disp.(S)"
    '                    btnAgregarMontoCuenta.Enabled = False

    '                    'ElseIf totalDisponibleCliente <= 0 AndAlso estadoNotaVenta <> "Liberada" AndAlso estadoNotaVenta <> "Autorizada" Then 'cliente no tiene disponible en su linea de crédito
    '                    '    btnLineaCredito.Enabled = False
    '                    '    btnLineaCredito.Text = "Linea NO Disp.(D)"
    '                    '    btnAgregarMontoCuenta.Enabled = False

    '                    'ElseIf int_estadoDocumentos > 0 AndAlso estadoNotaVenta <> "Liberada" AndAlso estadoNotaVenta <> "Autorizada" Then
    '                    '    btnLineaCredito.Enabled = False
    '                    '    If int_estadoDocumentos = 1 Then '1 = Facturas impagas
    '                    '        btnLineaCredito.Text = "Linea NO Disp."
    '                    '    End If
    '                    '    btnAgregarMontoCuenta.Enabled = False

    '                    '    btnCheque.Enabled = False
    '                    '    If int_estadoDocumentos = 2 Then '1 = Cheques impagos
    '                    '        btnCheque.Text = "Cheque NO Disp."
    '                    '    End If
    '                    '    btnAgregarCheque.Enabled = False

    '                ElseIf (obj_estadosDocumentos.EstadoFacturas > 0 OrElse obj_estadosDocumentos.EstadoCheques > 0) Then

    '                    If obj_estadosDocumentos.EstadoFacturas > 0 Then '1 = Facturas impagas
    '                        btnLineaCredito.Enabled = False
    '                        btnLineaCredito.Text = "Linea NO Disp.(F)"
    '                        btnAgregarMontoCuenta.Enabled = False
    '                    End If

    '                    If obj_estadosDocumentos.EstadoCheques > 0 Then '1 = Cheques impagos
    '                        btnCheque.Enabled = False
    '                        btnCheque.Text = "Cheque NO Disp.(CH)"
    '                        btnAgregarCheque.Enabled = False
    '                    End If

    '                Else
    '                    btnLineaCredito.Enabled = True
    '                    btnLineaCredito.Text = "Línea Crédito"
    '                    btnAgregarMontoCuenta.Enabled = True

    '                End If
    '            End If
    '        Else
    '            lbl_creditoDispCliente.Text = ""
    '            MessageBox.Show("Información de crédito del Cliente NO pudo ser obtenida", "Estado Crédito Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If

    '    Catch ex As Exception
    '        lbl_creditoDispCliente.Text = ""
    '        MessageBox.Show("Información de crédito del Cliente NO pudo ser obtenida", "Estado Crédito Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try

    'End Sub

    Private Sub ActualizarPartidasCliente(ByVal BPartner As String)
        Dim obj_partidasAbiertasCliente As PartidasAbiertasClienteModel = Nothing
        Dim obj_sap As class_sap = Nothing
        Dim str_resultadoJSON As String = ""
        Dim str_tipoDocPorPagar As String = ""
        Dim dat_fechaDesde As DateTime = Configuracion.fechaInicioPartidas

        Try
            DgvNotasCredito.Rows.Clear()
            DgvAnticipos.Rows.Clear()

            With Global.caja2.My.MySettings.Default
                obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
            End With

            str_resultadoJSON = obj_sap.getPartidasClienteAbiertas(BPartner, dat_fechaDesde, Now)

            If String.IsNullOrEmpty(str_resultadoJSON) = False Then
                obj_partidasAbiertasCliente = JsonConvert.DeserializeObject(Of PartidasAbiertasClienteModel)(str_resultadoJSON)

                If Not obj_partidasAbiertasCliente Is Nothing Then
                    DgvNotasCredito.Rows.Clear()

                    dtbDocPorPagar = New DataTable
                    dtbDocPorPagar.Columns.Add("Sel", GetType(Boolean))
                    dtbDocPorPagar.Columns.Add("TipoDoc", GetType(String))
                    dtbDocPorPagar.Columns.Add("Folio", GetType(String))
                    dtbDocPorPagar.Columns.Add("Fecha", GetType(DateTime))
                    dtbDocPorPagar.Columns.Add("FechaVto", GetType(DateTime))
                    dtbDocPorPagar.Columns.Add("Monto", GetType(Double))
                    dtbDocPorPagar.Columns.Add("Morosidad", GetType(String))
                    dtbDocPorPagar.Columns.Add("Bloqueado", GetType(String))
                    dtbDocPorPagar.Columns.Add("CME", GetType(String))
                    dtbDocPorPagar.Columns.Add("Numero_SAP", GetType(Int64))
                    dtbDocPorPagar.Columns.Add("Numero_NotaVenta", GetType(String))
                    dtbDocPorPagar.Columns.Add("Nombre_Banco", GetType(String))
                    dtbDocPorPagar.Columns.Add("Cod_Autorizacion", GetType(String))
                    dtbDocPorPagar.Columns.Add("Cod_Empresa", GetType(String))
                    dtbDocPorPagar.Columns.Add("Ejercicio", GetType(String))

                    For Each partidaCliente In obj_partidasAbiertasCliente.d.results

                        dtbPosCodigoPartidaCliente = tbaPosCodigoPartidaCliente.GetDataByClaseTipoClasificacion(partidaCliente.ClaseDoc.ToString().ToUpper(), partidaCliente.TipoCheque.Trim.ToUpper(), "CHEQUE")

                        If partidaCliente.ClaseDoc.ToString().ToUpper() = "CI" Then
                            If partidaCliente.Texto.Trim() = "FACTURAS CXC" Then
                                dtbDocPorPagar.Rows.Add(False, partidaCliente.Texto.Trim(), partidaCliente.Folio, partidaCliente.FechaDoc, partidaCliente.FechaVenc, partidaCliente.Monto,
                                                        Now.Subtract(partidaCliente.FechaVenc).Days.ToString() & " dias", partidaCliente.Bloqueo, "", partidaCliente.NumDoc, partidaCliente.NotaVenta)

                            ElseIf partidaCliente.Texto.Trim().ToUpper() = "NOTAS DE CREDITO" AndAlso partidaCliente.Bloqueo.ToString() <> "A" Then

                                DgvNotasCredito.Rows.Add("NC", partidaCliente.Folio, partidaCliente.FechaDoc, partidaCliente.Monto, "", partidaCliente.NumDoc, partidaCliente.CodEmpresa, partidaCliente.Ejercicio)

                            ElseIf partidaCliente.Texto.Trim().ToUpper() = "ANTICIPO" Then

                                DgvAnticipos.Rows.Add("ANT", partidaCliente.Folio, partidaCliente.FechaDoc, partidaCliente.Monto, "", partidaCliente.NumDoc, partidaCliente.CodEmpresa, partidaCliente.Ejercicio)

                            ElseIf partidaCliente.Texto.Trim().ToUpper() = "CHEQUES EN CARTERA" Then
                                dtbDocPorPagar.Rows.Add(False, partidaCliente.Texto.Trim(), partidaCliente.NumCheque, partidaCliente.FechaDoc, partidaCliente.FechaVenc, partidaCliente.Monto,
                                                        Now.Subtract(partidaCliente.FechaVenc).Days.ToString() & " dias", partidaCliente.Bloqueo, partidaCliente.TipoCheque, partidaCliente.NumDoc, partidaCliente.NotaVenta, partidaCliente.BancoCheque,
                                                        partidaCliente.CodOrsan)

                            End If


                        ElseIf partidaCliente.TipoCheque.Trim.ToUpper = "A" AndAlso
                            (partidaCliente.ClaseDoc.ToString().ToUpper() = "ZA" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZB" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZD" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZS") Then

                            DgvAnticipos.Rows.Add("ANT", partidaCliente.Folio, partidaCliente.FechaDoc, partidaCliente.Monto, "", partidaCliente.NumDoc, partidaCliente.CodEmpresa, partidaCliente.Ejercicio)

                        ElseIf dtbPosCodigoPartidaCliente.Rows.Count > 0 Then
                            dtbDocPorPagar.Rows.Add(False, dtbPosCodigoPartidaCliente.Rows(0).Item("pcpc_descripcion").ToString().Trim().ToUpper(), partidaCliente.NumCheque, partidaCliente.FechaDoc, partidaCliente.FechaVenc, partidaCliente.Monto,
                                                    Now.Subtract(partidaCliente.FechaVenc).Days.ToString() & " dias",
                                                    partidaCliente.Bloqueo, partidaCliente.TipoCheque, partidaCliente.NumDoc, partidaCliente.NotaVenta, partidaCliente.BancoCheque, partidaCliente.CodOrsan)

                            'ElseIf partidaCliente.TipoCheque.Trim.ToUpper = "C" AndAlso (partidaCliente.ClaseDoc.ToString().ToUpper() = "ZS" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZB") Then
                            '    dtbDocPorPagar.Rows.Add(False, "CHEQUES EN CARTERA", partidaCliente.NumCheque, partidaCliente.FechaDoc, partidaCliente.FechaVenc, partidaCliente.Monto, Now.Subtract(partidaCliente.FechaVenc).Days.ToString() & " dias",
                            '                            partidaCliente.Bloqueo, partidaCliente.TipoCheque, partidaCliente.NumDoc, partidaCliente.NotaVenta, partidaCliente.BancoCheque, partidaCliente.CodOrsan)

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "V5" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "R5" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZN") AndAlso
                                partidaCliente.Bloqueo.ToString() <> "A" Then

                            DgvNotasCredito.Rows.Add("NC", partidaCliente.Folio, partidaCliente.FechaDoc, partidaCliente.Monto, "", partidaCliente.NumDoc, partidaCliente.CodEmpresa, partidaCliente.Ejercicio)

                        ElseIf partidaCliente.ClaseDoc.ToString().ToUpper() = "V1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "R1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZF" Then
                            dtbDocPorPagar.Rows.Add(False, "FACTURAS CXC", partidaCliente.Folio, partidaCliente.FechaDoc, partidaCliente.FechaVenc, partidaCliente.Monto, Now.Subtract(partidaCliente.FechaVenc).Days.ToString() & " dias",
                                                    partidaCliente.Bloqueo, "", partidaCliente.NumDoc, partidaCliente.NotaVenta)

                        ElseIf partidaCliente.ClaseDoc.ToString().ToUpper() = "BE" Then
                            dtbDocPorPagar.Rows.Add(False, "BOLETAS CXC", partidaCliente.Folio, partidaCliente.FechaDoc, partidaCliente.FechaVenc, partidaCliente.Monto, Now.Subtract(partidaCliente.FechaVenc).Days.ToString() & " dias",
                                                    partidaCliente.Bloqueo, "", partidaCliente.NumDoc, partidaCliente.NotaVenta)
                        End If
                    Next

                    DgvDocPorPagar.AutoGenerateColumns = False
                    DgvDocPorPagar.DataSource = dtbDocPorPagar

                    For Each columna As DataGridViewColumn In DgvDocPorPagar.Columns
                        columna.ReadOnly = True
                    Next

                    DgvDocPorPagar.Height = 257

                End If
            End If

        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try

    End Sub

    Sub seleccionaMedioPago(id As Integer)
        seleccionandoMedioPago = True

        Select Case id
            Case 1
                btnLineaCredito_Click(Me, Nothing)
                txt_medioPago.Text = "CUENTA CAREN"
            Case 2
                btnCheque_Click(Me, Nothing)
                txt_medioPago.Text = "CHEQUE"
            Case 3, 4
                btnTarjeta_Click(Me, Nothing)
                txt_medioPago.Text = "TARJETA"
            Case 5
                btnEfectivo_Click(Me, Nothing)
                txt_medioPago.Text = "EFECTIVO"
            Case 6
                RadioButton_factura.Checked = True 'Medio de pago Linea de crédito solo con factura
                btnLineaCredito_Click(Me, Nothing)
                txt_medioPago.Text = "SALDO"
            Case 7
                btnAgregarTransferencia_Click(Me, Nothing)
                txt_medioPago.Text = "TRANSFERENCIA"
        End Select

        seleccionandoMedioPago = False
    End Sub

    Private Sub LlenarGrillaDetalle(id As Integer)

        dtbVWPosDocumentoDet = tbaVWPosDocumentoDet.GetDataByID(id)

        Try
            For Each fila As DataRow In dtbVWPosDocumentoDet.Rows
                If fila.Item("dpd_precioUnitarioNetoFinal") Is DBNull.Value OrElse fila.Item("dpd_precioUnitarioNetoFinal") <= 0 Then
                    MessageBox.Show("Documento de Origen tiene valores incorrectos para el SKU " & fila.Item("rp_codigo").ToString(), "Detalle de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call limpiaDocumento()
                    Exit For

                Else
                    agregaProducto(fila.Item("rp_codigo"), fila.Item("rp_descripcion"), fila.Item("dpd_cantidad"), fila.Item("dpd_precioUnitarioNetoFinal"), fila.Item("dpd_total"))
                End If

            Next
        Catch ex As Exception
            MessageBox.Show("Documento de Origen tiene valores incorrectos.", "Detalle de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call limpiaDocumento()
        End Try

    End Sub

    Private Sub LlenarGrillaDetallePago(id As Integer)
        Dim montoTexto As String
        Dim pesoRedondeo As Integer = 0
        Dim montoPago As Integer

        dtbPosDocumentoDetPago = tbaPosDocumentoDetPago.GetDataByNumero(id)

        Try
            DgvDetallePagos.Rows.Clear()

            For Each filaPago As DataRow In dtbPosDocumentoDetPago.Rows
                If (filaPago.Item("dpdp_montoPago") Is DBNull.Value OrElse filaPago.Item("dpdp_montoPago") < 0) Then
                    MessageBox.Show("Documento de Origen tiene valores incorrectos para el Monto " & filaPago.Item("dpdp_montoPago").ToString(), "Detalle de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call limpiaDocumento()
                    Exit For

                ElseIf filaPago.Item("dpdp_montoPago") = 0 AndAlso filaPago.Item("dpdp_tipo") <> 1 Then ' Se permite monto cero para efectivo 
                    MessageBox.Show("Documento de Origen tiene valores incorrectos para el Monto " & filaPago.Item("dpdp_montoPago").ToString(), "Detalle de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call limpiaDocumento()
                    Exit For

                Else
                    montoPago = filaPago.Item("dpdp_montoPago")
                    montoTexto = Format(filaPago.Item("dpdp_montoPago"), "$ #,##0").Trim()

                    If filaPago.Item("dpdp_tipo") = 1 Then

                        Integer.TryParse(filaPago.Item("dpdp_montoRedondeo"), pesoRedondeo)

                        montoTexto = Format(montoPago, "$ #,##0")
                    End If

                    DgvDetallePagos.Rows.Add(filaPago.Item("dpdp_tipoNombre").ToString().Trim(), montoTexto, filaPago.Item("dpdp_detalle").ToString().Trim(), "", 0, filaPago.Item("dpdp_numeroOperacion").ToString().Trim(),
                                             filaPago.Item("dpdp_numeroCheque").ToString().Trim(), filaPago.Item("dpdp_fechaCheque"), filaPago.Item("dpdp_bancoCheque").ToString().Trim(), filaPago.Item("dpdp_numeroORSAN").ToString().Trim(),
                                             filaPago.Item("dpdp_numeroCuenta").ToString().Trim(), filaPago.Item("dpdp_rutGirador").ToString().Trim(), Global.caja2.My.MySettings.Default.empresaSAP,
                                             filaPago.Item("dpdp_ejercicioSAP"), filaPago.Item("dpdp_numeroSAP"), pesoRedondeo, filaPago.Item("dpdp_numeroTarjeta"), filaPago.Item("dpdp_IDTerminal"), filaPago.Item("dpdp_numeroCuotas"),
                                             filaPago.Item("dpdp_corr"), filaPago.Item("dpdp_codigoRechazoORSAN"))

                End If

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace, "Detalle de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call limpiaDocumento()
        End Try

    End Sub

    Private Sub SincronizarGrillaDetallePagoDoc(id As Integer)
        Dim celdaSeleccion As DataGridViewCell
        Dim nombreTipoDocumento As String

        dtbPosDocumentoDetPagoDoc = tbaPosDocumentoDetPagoDoc.GetDataByID(id)

        For Each filaPagoDoc As DataRow In dtbPosDocumentoDetPagoDoc.Rows

            For Each filaGrilla As DataGridViewRow In DgvDocPorPagar.Rows
                If filaPagoDoc.Item("dpdd_numeroDoc") Is DBNull.Value Then

                ElseIf filaPagoDoc.Item("dpdd_numeroDoc").ToString() = filaGrilla.Cells.Item("Folio").Value.ToString() AndAlso filaPagoDoc.Item("dpdd_total") = filaGrilla.Cells.Item("Monto").Value AndAlso
                    filaPagoDoc.Item("dpdd_numeroNotaVenta") = filaGrilla.Cells.Item("Numero_NotaVenta").Value Then
                    nombreTipoDocumento = filaGrilla.Cells.Item("TipoDoc").Value.ToString()
                    agregaProducto(filaGrilla.Cells.Item("Folio").Value, nombreTipoDocumento, 1, filaGrilla.Cells.Item("Monto").Value, filaGrilla.Cells.Item("Monto").Value)

                    filaGrilla.Cells.Item("Sel").Value = True
                    filaGrilla.ReadOnly = True
                    filaGrilla.DefaultCellStyle.BackColor = Color.LightGray

                    celdaSeleccion = filaGrilla.Cells.Item("Sel")
                    celdaSeleccion.Style.ForeColor = Color.LightGray
                    celdaSeleccion.ReadOnly = True

                    Exit For
                End If
            Next

        Next

        Call ActualizarTotales()
    End Sub

    Sub agregaProducto(codigo As String, Descripcion As String, cantidad As Integer, valorUnitarioNeto As Integer, total As Double)
        Dim encontrado As Boolean = False

        For Each fila As DataGridViewRow In DgvDetalleProductos.Rows
            If Trim(fila.Cells("colCodigo").Value.ToString) = codigo Then
                fila.Cells("colCantidad").Value = fila.Cells("colCantidad").Value + cantidad
                fila.Cells("colTotalNeto").Value = fila.Cells("colCantidad").Value * fila.Cells("colUnitarioNeto").Value
                encontrado = True
                Exit For
            End If
        Next

        If Not encontrado Then
            DgvDetalleProductos.Rows.Add(codigo, Descripcion, cantidad, valorUnitarioNeto, cantidad * valorUnitarioNeto, total)
        End If

    End Sub

    Private Sub LlenarGrillaDetalleDesdeNotaCredito(id As Integer)

        dtbVWPosDocumentoDet = tbaVWPosDocumentoDet.GetDataByID(id)

        Try
            For Each fila As DataRow In dtbVWPosDocumentoDet.Rows
                agregaProducto(fila.Item("rp_codigo"), fila.Item("rp_descripcion"), fila.Item("dpd_cantidad"), fila.Item("dpd_precioUnitarioNetoFinal"), fila.Item("dpd_totalNetoFinal"), fila.Item("dpd_total"))
            Next
        Catch ex As Exception
            MessageBox.Show("Documento de Origen tiene valores incorrectos.", "Detalle de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call limpiaDocumento()
        End Try

    End Sub

    Sub agregaProducto(codigo As String, Descripcion As String, cantidad As Integer, valorUnitarioNeto As Double, totalNeto As Double, total As Double)
        Dim encontrado As Boolean = False

        For Each fila As DataGridViewRow In DgvDetalleProductos.Rows
            If Trim(fila.Cells("colCodigo").Value.ToString) = codigo Then
                fila.Cells("colCantidad").Value = fila.Cells("colCantidad").Value + cantidad
                fila.Cells("colTotalNeto").Value = fila.Cells("colCantidad").Value * fila.Cells("colUnitarioNeto").Value
                encontrado = True
                Exit For
            End If
        Next

        If Not encontrado Then
            DgvDetalleProductos.Rows.Add(codigo, Descripcion, cantidad, valorUnitarioNeto, totalNeto, total)
        End If

    End Sub

    Private Sub btn_agregar_producto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        Try
            Dim cantidadGrilla As Integer = 0
            Dim cantidad As Integer = txt_cantidad.Text

            If txt_rutCliente.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar un Rut de Cliente antes de agregar un producto", "agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            txt_codigo_CAREN.Text = txt_codigo_CAREN.Text.Trim

            dtbVwArticulo = tbaVwArticulo.GetDataByLocalMaterial(Configuracion.IDTiendaSAP, txt_codigo_CAREN.Text)
            If dtbVwArticulo.Rows.Count = 0 Then
                dtbVwArticuloEAN = tbaVwArticuloEAN.GetDataByEAN(txt_codigo_CAREN.Text.Trim)

                If dtbVwArticuloEAN.Rows.Count > 0 Then
                    txt_codigo_CAREN.Text = dtbVwArticuloEAN.Rows(0).Item("Material").ToString().Trim()
                End If
            End If

            dtbVwArticulo = tbaVwArticulo.GetDataByLocalMaterial(Configuracion.IDTiendaSAP, txt_codigo_CAREN.Text)
            If dtbVwArticulo.Rows.Count > 0 Then

                dtbVwArticuloStock = tbaVwArticuloStock.GetDataByLocalMaterial(Configuracion.IDTiendaSAP, txt_codigo_CAREN.Text.Trim)

                cantidadGrilla = DgvDetalleProductos.Rows.Cast(Of DataGridViewRow)().Where(Function(fila) fila.Cells.Item("colCodigo").Value = txt_codigo_CAREN.Text.Trim).Sum(Function(fila) fila.Cells.Item("colCantidad").Value)

                If dtbVwArticuloStock.Rows.Count > 0 Then

                    If codigosExclusionStock.Contains(txt_codigo_CAREN.Text.Trim) = False Then
                        If dtbVwArticuloStock.Rows(0).Item("Disponible") <= 0 OrElse cantidadGrilla + cantidad > dtbVwArticuloStock.Rows(0).Item("Disponible") Then
                            MessageBox.Show("producto NO pudo ser agregado porque la tienda no tiene stock suficiente", "agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                Else
                    MessageBox.Show("código de producto NO existe en la tienda actual", "agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                dtbVwBTClienteProductoPrecio = tbaVwBTClienteProductoPrecio.GetDataByIDCanalIDTiendaIDClienteCodigo(Configuracion.IDCanal, Configuracion.IDTiendaSAP, Configuracion.IDCliente, txt_codigo_CAREN.Text.Trim)

                If dtbVwBTClienteProductoPrecio.Rows.Count > 0 Then
                    Dim dtrFila As DataRow = dtbVwBTClienteProductoPrecio.Rows(0)
                    Dim precioUnitarioSinIva As Double = Math.Round(dtrFila.Item("precio") / 1.19, 0)
                    Dim precioCostoUnitario As Double = Math.Round(dtrFila.Item("precio") / 2, 0)

                    agregaProducto(txt_codigo_CAREN.Text, dtbVwArticulo.Rows(0).Item("TextoMaterial").ToString().Trim(), cantidad, precioUnitarioSinIva, cantidad * dtrFila.Item("precio"))
                    dtbSPPosDocumentoAgregaLineaDetalle = tbaSPPosDocumentoAgregaLineaDetalle.GetData(txt_idCliente.Text.Trim, txt_rutCliente.Text.Trim, numeroDocumentoPOS, Configuracion.IDUsuario, Configuracion.IDTiendaSAP, 0, txt_codigo_CAREN.Text,
                                                                                                      dtbVwArticulo.Rows(0).Item("TextoMaterial").ToString().Trim(), dtrFila.Item("precio"), dtrFila.Item("precio"),
                                                                                                      dtrFila.Item("precio"), 0, precioUnitarioSinIva, 0, 0, cantidad,
                                                                                                      precioUnitarioSinIva, cantidad * dtrFila.Item("precio"), cantidad * dtrFila.Item("precio"),
                                                                                                      cantidad * precioUnitarioSinIva, cantidad * precioUnitarioSinIva, precioCostoUnitario * cantidad,
                                                                                                      precioCostoUnitario, 0, 0, 0, 1, 0, Configuracion.IDTiendaSAP, 0, 0)

                    If dtbSPPosDocumentoAgregaLineaDetalle.Rows.Count > 0 Then
                        numeroDocumentoPOS = dtbSPPosDocumentoAgregaLineaDetalle.Rows(0).Item("dpc_numero")
                        lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()
                    End If

                    txt_codigo_CAREN.Text = ""
                    txt_cantidad.Text = ""

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("producto NO pudo ser agregado " & ex.Message & vbCrLf & ex.StackTrace, "agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Function FormatearCodigoSAP(ByVal largo As Integer, ByVal codigo As Object) As String
        Dim resultado As String = codigo.ToString().Trim()

        resultado = New String("0", largo - Len(resultado)) & resultado

        Return resultado
    End Function

    Private Sub ActualizarTotales()
        totalProductosConIva = 0
        totalProductosNeto = 0
        totalDescuento = 0
        totalDescuentoCupon = 0
        totalDocumentos = 0

        For Each fila As DataGridViewRow In DgvDetalleProductos.Rows
            If fila.Cells("colDescrip").Value.ToString() <> "Factura" AndAlso fila.Cells("colDescrip").Value.ToString() <> "Cheque por Cobrar" Then
                totalProductosNeto = totalProductosNeto + fila.Cells("colTotalNeto").Value
                totalProductosConIva = totalProductosConIva + fila.Cells("colTotal").Value
            End If
        Next

        For Each fila As DataGridViewRow In DgvDocPorPagar.Rows
            If Convert.ToBoolean(fila.Cells("Sel").Value) = True Then
                totalDocumentos = totalDocumentos + fila.Cells("Monto").Value
            End If
        Next

        If pagandoDocumentos = False Then 'Facturas y otros documentos pendientes de pago del cliente
            totalNeto = totalProductosNeto
            totalIva = Math.Round(totalNeto * 0.19)
            totalFinal = totalNeto + totalIva

            txt_totalDocumentos.Text = totalDocumentos.ToString("$ #,##0")
            txt_totalNeto.Text = totalNeto.ToString("$ #,##0")
            txt_totalDescuentoCupon.Text = totalDescuentoCupon.ToString("-$ #,##0")

            txt_totalIva.Text = totalIva.ToString("$ #,##0")
            lbl_totalFinal.Text = totalFinal.ToString("$ #,##0")

            lbl_total.Text = lbl_totalFinal.Text
            lbl_totalPedido.Text = lbl_totalFinal.Text

        Else 'Notas de Venta y Ordenes de Servicio
            totalNeto = totalProductosNeto
            totalIva = 0
            totalFinal = totalNeto

            txt_totalDocumentos.Text = totalDocumentos.ToString("$ #,##0")
            txt_totalNeto.Text = totalNeto.ToString("$ #,##0")
            txt_totalDescuentoCupon.Text = totalDescuentoCupon.ToString("-$ #,##0")

            txt_totalIva.Text = totalIva.ToString("$ #,##0")
            lbl_totalFinal.Text = totalFinal.ToString("$ #,##0")

            lbl_total.Text = lbl_totalFinal.Text
            lbl_totalPedido.Text = lbl_totalFinal.Text

        End If

        CalculaPago()

    End Sub

    Sub CalculaPago()
        Dim sumaPago As Integer = 0
        Dim saldo As Integer = 0

        If DgvDetallePagos.Rows.Count > 0 Then
            For Each Fila As DataGridViewRow In DgvDetallePagos.Rows
                sumaPago = sumaPago + limpiaDato(Fila.Cells.Item("col_monto").Value + Fila.Cells.Item("col_montoRedondeo").Value)
            Next
        End If

        totalPago = sumaPago

        lbl_pago.Text = Format(sumaPago, "-$ #,##0")

        If totalFinal = 0 Then 'no se han ingresado documentos a pagar o los documentos suman cero
            lbl_Saldo.Text = Format(totalFinal, "-$ #,##0")
            lbl_vuelto.Text = Format(totalPago, "-$ #,##0")
            saldo = totalFinal

        ElseIf (totalFinal - sumaPago) >= 0 Then 'se han ingresado pagos inferiores al saldo a pagar
            lbl_Saldo.Text = Format(totalFinal - sumaPago, "-$ #,##0")
            lbl_vuelto.Text = Format(0, "-$ #,##0")
            saldo = totalFinal - sumaPago

        ElseIf (totalFinal - sumaPago) < 0 Then ' se han ingresado pagos superiores al saldo a pagar
            lbl_Saldo.Text = Format(0, "-$ #,##0")
            lbl_vuelto.Text = Format(sumaPago - totalFinal, "-$ #,##0")
            saldo = totalFinal - sumaPago

        End If

        If saldo <= 0 AndAlso chk_anticipo.Checked = True Then
            btnFacturar.Enabled = False
            btnFacturar.BackColor = Color.DarkOrange

        ElseIf saldo <= 0 AndAlso pagandoDocumentos = False Then
            btnFacturar.Enabled = True
            btnFacturar.BackColor = Color.DarkOrange

        Else
            btnFacturar.Enabled = False
            btnFacturar.BackColor = Color.LightGray

        End If

    End Sub

    Private Sub btnEfectivo_Click(sender As Object, e As EventArgs) Handles btnEfectivo.Click
        If Configuracion.IDTipoUsuario = 30 Then
            botonesAzules(Panel_Efectivo)
            btnEfectivo.BackColor = Color.DarkOrange
        End If

        Panel_Efectivo.Parent = Panel_BotonesPago
        Panel_Efectivo.Visible = True
        Panel_Efectivo.Location = New Point(Panel_BotonesMedioPago.Left, Panel_BotonesMedioPago.Top + Panel_BotonesMedioPago.Height + 2) ' New Point(29, 142)
        Panel_Efectivo.BringToFront()
    End Sub

    Private Sub btnTarjeta_Click(sender As Object, e As EventArgs) Handles btnTarjeta.Click
        botonesAzules(Panel_Tarjeta)
        btnTarjeta.BackColor = Color.DarkOrange

        Panel_Tarjeta.Parent = Panel_BotonesPago
        Panel_Tarjeta.Visible = True
        Panel_Tarjeta.Location = New Point(Panel_BotonesMedioPago.Left, Panel_BotonesMedioPago.Top + Panel_BotonesMedioPago.Height + 2)  ' New Point(29, 142)
    End Sub

    Private Sub btnLineaCredito_Click(sender As Object, e As EventArgs) Handles btnLineaCredito.Click
        If RadioButton_factura.Checked = False Then
            btnAgregarMontoCuenta.Enabled = False
            MessageBox.Show("Solo se puede seleccionar pago con linea de crédito cuando el documento de Venta es factura", "Linea de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        ElseIf RadioButton_factura.Checked = True Then
            Call ActualizarCreditoCliente(txt_rutCliente.Text, txt_idCliente.Text, estadoNotaVenta)

        End If

        botonesAzules(Panel_CtaCAREN)
        btnLineaCredito.BackColor = Color.DarkOrange

        Panel_CtaCAREN.Parent = Panel_BotonesPago
        Panel_CtaCAREN.Visible = True
        Panel_CtaCAREN.Location = New Point(Panel_BotonesMedioPago.Left, Panel_BotonesMedioPago.Top + Panel_BotonesMedioPago.Height + 2)  ' New Point(29, 142)
    End Sub

    Private Sub btnLineaFuncionario_Click(sender As Object, e As EventArgs) Handles btnLineaFuncionario.Click
        botonesAzules(Nothing)
        btnLineaFuncionario.BackColor = Color.DarkOrange

        panel_LineaFuncionario.Parent = Panel_BotonesPago
        panel_LineaFuncionario.Visible = True
        panel_LineaFuncionario.Location = New Point(Panel_BotonesMedioPago.Left, Panel_BotonesMedioPago.Top + Panel_BotonesMedioPago.Height + 2)  ' New Point(29, 142)
    End Sub

    Private Sub btnCheque_Click(sender As Object, e As EventArgs) Handles btnCheque.Click
        Dim montoLineaCredito As Double = 0

        If IsNumeric(Regex.Replace(lbl_creditoDispCliente.Text, "[^0-9]", "")) = True Then
            montoLineaCredito = Regex.Replace(lbl_creditoDispCliente.Text, "[^0-9]", "")
        End If

        botonesAzules(Panel_Cheque)
        btnCheque.BackColor = Color.DarkOrange

        Panel_Cheque.Parent = Panel_BotonesPago
        Panel_Cheque.Visible = True
        Panel_Cheque.Location = New Point(Panel_BotonesMedioPago.Left, Panel_BotonesMedioPago.Top + Panel_BotonesMedioPago.Height + 2)  ' New Point(18, 142)
        Panel_Cheque.BringToFront()

    End Sub

    Private Sub btnTransferencia_Click(sender As Object, e As EventArgs) Handles btnTransferencia.Click
        botonesAzules(Panel_Transferencia)
        btnTransferencia.BackColor = Color.DarkOrange

        Panel_Transferencia.Parent = Panel_BotonesPago
        Panel_Transferencia.Visible = True
        Panel_Transferencia.Location = New Point(Panel_BotonesMedioPago.Left, Panel_BotonesMedioPago.Top + Panel_BotonesMedioPago.Height + 2)  ' New Point(29, 138)
    End Sub

    Private Sub btnNotaCredito_Click(sender As Object, e As EventArgs) Handles btnNotaCredito.Click
        botonesAzules(Panel_NotaCredito)
        btnNotaCredito.BackColor = Color.DarkOrange

        Panel_NotaCredito.Parent = Panel_BotonesPago
        Panel_NotaCredito.Visible = True
        Panel_NotaCredito.Location = New Point(Panel_BotonesMedioPago.Left, Panel_BotonesMedioPago.Top + Panel_BotonesMedioPago.Height + 2)  ' New Point(29, 142)
    End Sub

    Private Sub btnAnticipos_Click(sender As Object, e As EventArgs) Handles btnAnticipos.Click
        botonesAzules(Panel_Anticipos)
        btnAnticipos.BackColor = Color.DarkOrange

        Panel_Anticipos.Parent = Panel_BotonesPago
        Panel_Anticipos.Visible = True
        Panel_Anticipos.Location = New Point(Panel_BotonesMedioPago.Left, Panel_BotonesMedioPago.Top + Panel_BotonesMedioPago.Height + 2)  ' New Point(29, 142)
    End Sub

    Sub botonesAzules(ByRef panel As Panel)
        btnLineaCredito.BackColor = Color.SteelBlue
        btnLineaFuncionario.BackColor = Color.SteelBlue
        btnCheque.BackColor = Color.SteelBlue
        btnEfectivo.BackColor = Color.SteelBlue
        'btnAjuste.BackColor = Color.SteelBlue
        btnTransferencia.BackColor = Color.SteelBlue
        btnTarjeta.BackColor = Color.SteelBlue
        btnValeVista.BackColor = Color.SteelBlue
        btnNotaCredito.BackColor = Color.SteelBlue
        btnAnticipos.BackColor = Color.SteelBlue
        btnMarketPlace.BackColor = Color.SteelBlue

        Panel_Tarjeta.Visible = False
        Panel_Tarjeta.SendToBack()

        Panel_CtaCAREN.Visible = False
        Panel_CtaCAREN.SendToBack()

        Panel_Cheque.Visible = False
        Panel_Cheque.SendToBack()

        Panel_Efectivo.Visible = False
        Panel_Efectivo.SendToBack()

        Panel_Transferencia.Visible = False
        Panel_Transferencia.SendToBack()

        Panel_NotaCredito.Visible = False
        Panel_NotaCredito.SendToBack()

        Panel_Anticipos.Visible = False
        Panel_Anticipos.SendToBack()

        Panel_marketPlace.Visible = False
        Panel_marketPlace.SendToBack()

        panel_LineaFuncionario.Visible = False
        panel_LineaFuncionario.SendToBack()

    End Sub

    Private Sub lbl_totalFinal_TextChanged(sender As Object, e As EventArgs) Handles lbl_totalFinal.TextChanged
        lbl_Saldo.Text = lbl_totalFinal.Text
    End Sub

    Private Sub txt_montoEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txt_montoEfectivo.TextChanged
        Dim saldoPago As Double = Regex.Replace(lbl_Saldo.Text, "[^0-9]", "")

        If saldoPago > 0 Then
            txt_vueltoEfectivo.Text = ""
            Try
                Dim resp As Integer = saldoPago - CInt(txt_montoEfectivo.Text)
                If resp < 0 Then
                    txt_vueltoEfectivo.Text = resp * -1
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvDetalleProductos.CellPainting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 10 Then ' Borrar Linea
                Dim imgXML As Image = iml_botones_columnas.Images(0)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y + 2, 18, 18)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DgvDetalleProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetalleProductos.CellClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 10 Then
                dtbDetalle.Rows(e.RowIndex).Delete()
                'Call AsignarGrillaDetalle()
                Call ActualizarTotales()
            End If
        End If
    End Sub

    Private Sub txt_codigo_CAREN_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_codigo_CAREN.KeyUp
        If e.KeyCode = 13 Then
            txt_cantidad.Text = "1"
            Call btn_agregar_producto_Click(sender, New EventArgs())
        End If
    End Sub

    Private Sub btnVerDatosCliente_Click(sender As Object, e As EventArgs) Handles btnVerDatosCliente.Click
        FrmDocCliente.txt_nombre_cliente.Text = IIf(txt_nombre_cliente.Text <> "", txt_nombre_cliente.Text, "Juan Pérez")
        FrmDocCliente.ShowDialog(Me)
    End Sub

    Private Sub btnAbrirCaja_Click(sender As Object, e As EventArgs)
        FrmCierreCaja.Text = "Abrir Caja"
        FrmCierreCaja.Show()
    End Sub

    Private Sub btnCierreCaja_Click(sender As Object, e As EventArgs) Handles btnCierreCaja.Click
        FrmCierreCaja.frmPadreAngosto = Me
        FrmCierreCaja.Font = New Font("Microsoft Sans Serif", "7")
        FrmCierreCaja.MaximizeBox = True
        FrmCierreCaja.MaximumSize = New Size(1366, 768)
        FrmCierreCaja.WindowState = FormWindowState.Maximized

        FrmCierreCaja.DgvChequesDeposito.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", "7")
        FrmCierreCaja.DgvChequesDeposito.Font = New Font("Microsoft Sans Serif", "7")

        FrmCierreCaja.DgvCierresCajaDetalle.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", "7")
        FrmCierreCaja.DgvCierresCajaDetalle.Font = New Font("Microsoft Sans Serif", "7")

        If Global.caja2.My.MySettings.Default.AmbienteSAP = "0" Then
            FrmCierreCaja.Text &= " - Pantalla : " & Screen.PrimaryScreen.WorkingArea.Width.ToString() & " x " & Screen.PrimaryScreen.WorkingArea.Height.ToString()
        End If

        FrmCierreCaja.Show()
    End Sub

    Private Sub btnVerNotaCredito_Click(sender As Object, e As EventArgs)
        FrmCierreCaja.Text = "Nota de Crédito"
        FrmCierreCaja.Show()
    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        FrmBusqueda.Show()
    End Sub

    Private Sub FillToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.Vw_web_notaVentaCabTableAdapter.Fill(Me.DataSet_catalogo.vw_web_notaVentaCab)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub agregaPago(idTipo As Integer, nombreTipo As String, monto As Integer, detalle As String, Optional numeroOperacion As String = "", Optional numeroCheque As String = "", Optional fechaCheque As String = "", Optional bancoCheque As String = "",
                   Optional numeroCuenta As String = "", Optional rutGirador As String = "", Optional numeroOrsan As String = "", Optional codEmpresa As String = "", Optional ejercicioSAP As String = "", Optional numeroSAP As String = "",
                   Optional IDTerminal As String = "", Optional numeroCuotas As String = "0", Optional numeroTarjeta As String = "", Optional codigoRechazoOrsan As String = "")
        Dim montoTexto As String = Format(monto, "$ #,##0")
        Dim vuelto As Double = limpiaDato(lbl_vuelto.Text)
        Dim divisionEfectivo As Integer = 0
        Dim pesoEfectivo As Integer = 0
        Dim pesoRedondeo As Integer = 0
        Dim correlativo As Integer = 0
        Dim filaGrilla As DataGridViewRow

        If idTipo = 1 Then ' 1 = Efectivo
            divisionEfectivo = Math.Truncate(monto / 10)
            pesoEfectivo = monto - (divisionEfectivo * 10)

            If pesoEfectivo >= 5 Then 'redondeo hacia arriba
                monto = (divisionEfectivo * 10) + 10
                pesoRedondeo = pesoEfectivo - 10

            Else 'redondeo hacia abajo
                monto = (divisionEfectivo * 10)
                pesoRedondeo = pesoEfectivo

            End If

            montoTexto = Format(monto, "$ #,##0")
        End If

        If numeroDocumentoPOS = 0 Then
            dtbSPPosDocumentoCrear = tbaSPPosDocumentoCrear.GetData(1, numeroDocumentoPOS, Now, txt_idCliente.Text.Trim, txt_rutCliente.Text.Trim, Configuracion.IDUsuario, Configuracion.IDTiendaSAP)

            If dtbSPPosDocumentoCrear.Rows.Count > 0 Then
                numeroDocumentoPOS = dtbSPPosDocumentoCrear.Rows(0).Item("dpc_numero")
                lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()
            End If
        End If

        dtbSPPosAgregaLineaPago = tbaSPPosAgregaLineaPago.GetData(numeroDocumentoPOS, 0, idTipo, nombreTipo, monto, detalle, numeroOperacion, numeroCheque, fechaCheque.ToNullableDateTime(), bancoCheque, numeroCuenta, rutGirador, numeroOrsan,
                                                                  ejercicioSAP, numeroSAP, IDTerminal, numeroCuotas, numeroTarjeta, codigoRechazoOrsan, pesoRedondeo)

        If dtbSPPosAgregaLineaPago.Rows.Count > 0 Then
            DgvDetallePagos.Rows.Add(nombreTipo, montoTexto, detalle, "", 0, numeroOperacion, numeroCheque, fechaCheque, bancoCheque, numeroOrsan, numeroCuenta, rutGirador, codEmpresa, ejercicioSAP, numeroSAP, pesoRedondeo, numeroTarjeta, IDTerminal,
                                     numeroCuotas, dtbSPPosAgregaLineaPago.Rows(0).Item("dpdp_corr"), codigoRechazoOrsan)

            filaGrilla = DgvDetallePagos.Rows.Item(DgvDetallePagos.Rows.Count - 1)

            If filaGrilla.Cells.Item("col_tipoMedioPago").Value = "Cheque" Then

                Dim Serie As String = numeroCheque
                Serie = New String("0", 10 - Serie.Length) & Serie

                Dim RUT_Girador As String = Regex.Replace(rutGirador, "[^0-9Kk]", "")
                RUT_Girador = New String("0", 12 - RUT_Girador.Length) & RUT_Girador

                'se desactiva la validación de ORSAN por solicitud de CAREN.
                'dtbOrsanLog = tbaOrsanLog.GetDataByFieldsValue(bancoCheque, Serie, numeroCuenta, monto, RUT_Girador)

                'If dtbOrsanLog.Rows.Count > 0 Then
                '    If IsNumeric(dtbOrsanLog.Rows(0).Item("CodigoRechazo").ToString()) = True Then
                '        filaGrilla.Cells.Item("col_tipoMedioPago").ErrorText = "Cheque con código de rechazo " & dtbOrsanLog.Rows(0).Item("CodigoRechazo").ToString().Trim()
                '    End If

                'Else
                '    filaGrilla.Cells.Item("col_tipoMedioPago").ErrorText = "Cheque NO validado en ORSAN"
                'End If

            End If

        End If

        Call ActualizarTotales()
    End Sub

    Private Function redondearEfectivo(ByVal montoEfectivo As Integer) As Integer
        Dim divisionEfectivo As Integer = 0
        Dim pesoEfectivo As Integer = 0
        Dim pesoRedondeo As Integer = 0
        Dim resultado As Integer = 0

        divisionEfectivo = Math.Truncate(montoEfectivo / 10)
        pesoEfectivo = montoEfectivo - (divisionEfectivo * 10)

        If pesoEfectivo >= 5 Then 'redondeo hacia arriba
            resultado = (divisionEfectivo * 10) + 10
            pesoRedondeo = pesoEfectivo - 10

        Else 'redondeo hacia abajo
            resultado = (divisionEfectivo * 10)
            pesoRedondeo = pesoEfectivo

        End If

        Return resultado
    End Function

    Private Sub btnAgregarEfectivo_Click(sender As Object, e As EventArgs) Handles btnAgregarEfectivo.Click
        If IsNumeric(txt_montoEfectivo.Text) = True Then
            agregaPago(1, "Efectivo", txt_montoEfectivo.Text, "")
        Else
            MessageBox.Show("Debe ingresar un monto", "efectivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub btnAgregarMontoTarjeta_Click(sender As Object, e As EventArgs) Handles btnAgregarMontoCuenta.Click
        If txt_montoLineaCredito.Text <> "" Then agregaPago(2, "Línea de Crédito", txt_montoLineaCredito.Text, "")
    End Sub

    Private Sub btnPagarTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagarTarjeta.Click
        Dim msgResult As DialogResult = MessageBox.Show("Pagando...", "Pago con Tarjeta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        Dim obj_PosIntegrado As class_PosIntegrado = Nothing
        Dim saleResponse As Transbank.Responses.IntegradoResponses.SaleResponse = Nothing
        Dim ticket As String = New Random().[Next](0, 999999).ToString("D6")
        Dim str_saleResponse As String = ""

        If rdbPagoSerial.Checked = True Then
            If msgResult = DialogResult.OK Then
                obj_PosIntegrado = New class_PosIntegrado(Global.caja2.My.MySettings.Default.puertoPOSTransbank)

                If obj_PosIntegrado.connect() = False Then
                    MessageBox.Show("No existe comunicación con POS", "Pago con Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ticket = numeroDocumentoPOS.ToString()

                saleResponse = obj_PosIntegrado.payment(ticket, txt_montoTarjeta.Text.Trim)

                If Not saleResponse Is Nothing Then
                    If saleResponse.Success = True Then
                        If saleResponse.ResponseCode = 0 Then 'Pago Autorizado por Transbank
                            Label_OK_Tarjeta.Visible = True

                            str_saleResponse = JsonConvert.SerializeObject(saleResponse).ToString()

                            If saleResponse.CardType.ToString().Trim().ToUpper() = "CR" Then 'Tarjeta de Crédito

                                agregaPago(3, "Tarj. Crédito", txt_montoTarjeta.Text, "Número Tarjeta: " & saleResponse.Last4Digits.ToString() & " Cód. Autorización: " & saleResponse.AuthorizationCode.Trim, saleResponse.AuthorizationCode.Trim, "",
                                           "", "", "", "", "", "", "", "", saleResponse.TerminalId.ToString(), saleResponse.SharesNumber.ToString())

                            ElseIf saleResponse.CardType.ToString().Trim().ToUpper() = "DB" Then 'Tarjeta de Débito
                                agregaPago(4, "Tarj. Débito", txt_montoTarjeta.Text, "Número Tarjeta: " & saleResponse.Last4Digits.ToString() & " Cód. Autorización: " & saleResponse.AuthorizationCode.Trim, saleResponse.AuthorizationCode.Trim, "",
                                           "", "", "", "", "", "", "", "", saleResponse.TerminalId.ToString(), saleResponse.SharesNumber.ToString())

                            Else
                                MessageBox.Show("Tipo de Tarjeta utilizada NO reconocida : [" & saleResponse.CardType.ToString().Trim().ToUpper() & "]", "Pago con Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        End If

                    ElseIf saleResponse.Success = False Then
                        If saleResponse.ResponseCode = 1 Then
                            MessageBox.Show("Error en selección de tipo tarjeta, reintentar", "Pago con Tarjeta. " & "Código POS recibido : " & saleResponse.ResponseCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf saleResponse.ResponseCode = 3 Then
                            MessageBox.Show("Reintente - Conexión falló", "Pago con Tarjeta. " & "Código POS recibido : " & saleResponse.ResponseCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf saleResponse.ResponseCode = 7 Then
                            MessageBox.Show("Reintente Transacción", "Pago con Tarjeta. " & "Código POS recibido : " & saleResponse.ResponseCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf saleResponse.ResponseCode = 18 Then
                            MessageBox.Show("Error en selección de tipo tarjeta, reintentar", "Pago con Tarjeta. " & "Código POS recibido : " & saleResponse.ResponseCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf saleResponse.ResponseCode = 22 Then
                            MessageBox.Show("Reintente Transacción", "Pago con Tarjeta. " & "Código POS recibido : " & saleResponse.ResponseCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else
                            MessageBox.Show("Transacción NO pudo ser cursada", "Pago con Tarjeta. " & "Código POS recibido : " & saleResponse.ResponseCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If
                    End If
                Else
                    MessageBox.Show("pago NO pudo ser enviado a Transbank" & vbCrLf & "Verificar que POS está en modo POS Integrado", "Pago con Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                Label_OK_Tarjeta.Visible = False
            End If

        ElseIf rdbPagoManual.Checked = True Then
            If IsNumeric(txt_montoTarjeta.Text) = False Then
                MessageBox.Show("Debe ingresar un monto de pago", "Pago con Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf txt_NumeroTarjeta.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar un número de tarjeta", "Pago con Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf txt_AutorizacionTarjeta.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar un código de Autorización", "Pago con Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf cmbTipoTarjetaCredito.SelectedIndex = 0 Then
                MessageBox.Show("Debe seleccionar un tipo de tarjeta", "Pago con Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf cmbTipoTarjetaCredito.SelectedIndex = 2 AndAlso IsNumeric(txt_NumeroCuotas.Text.Trim) = False Then
                MessageBox.Show("Debe ingresar un número de cuotas", "Pago con Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                If cmbTipoTarjetaCredito.SelectedIndex = 1 Then 'Tarjeta de Débito
                    agregaPago(4, "Tarj. Débito", txt_montoTarjeta.Text, "Número Tarjeta: " & txt_NumeroTarjeta.Text.Trim & " Cód. Autorización: " & txt_AutorizacionTarjeta.Text.Trim, txt_AutorizacionTarjeta.Text.Trim, "", "", "", "", "", "",
                                   "", "", "", "", "0", txt_NumeroTarjeta.Text.Trim)

                ElseIf cmbTipoTarjetaCredito.SelectedIndex = 2 Then 'Tarjeta de Crédito
                    agregaPago(3, "Tarj. Crédito", txt_montoTarjeta.Text, "Número Tarjeta: " & txt_NumeroTarjeta.Text.Trim & " Cód. Autorización: " & txt_AutorizacionTarjeta.Text.Trim, txt_AutorizacionTarjeta.Text.Trim, "", "", "", "", "", "",
                                   "", "", "", "", txt_NumeroCuotas.Text.Trim, txt_NumeroTarjeta.Text.Trim)

                End If

            End If

        End If

    End Sub

    Function limpiaDato(dato As String) As Integer
        If dato Is Nothing OrElse dato = "" Then Return 0

        Return CInt(Regex.Replace(dato, "[^0-9]", ""))
    End Function


    Private Sub btnAgregarCheque_Click(sender As Object, e As EventArgs) Handles btnAgregarCheque.Click
        Dim detalle As String = cbx_banco.Text.Trim & ", CTA: " & txt_numeroCuenta.Text.Trim & ", N°: " & txt_nroCheque.Text.Trim & ", VENC: " & DtpFechaVencCheque.Value.ToString("dd/MM/yyyy")

        If sender Is btnAgregarCheque AndAlso ValidarControlesCheque() = False Then
            Exit Sub
        End If

        If IsNumeric(txt_codigoAutorizacion.Text.Trim) = True AndAlso Convert.ToInt32(txt_codigoAutorizacion.Text.Trim) > 0 Then
            detalle &= ", GARANTIZADO CÓD: " & txt_codigoAutorizacion.Text.Trim
        End If

        agregaPago(idTipo:=5, nombreTipo:="Cheque", monto:=txt_montoCheque.Text, detalle:=detalle, numeroOperacion:=txt_numeroOperacion.Text, numeroCheque:=txt_nroCheque.Text, fechaCheque:=DtpFechaVencCheque.Value.ToString("dd-MM-yyyy"),
                   bancoCheque:=cbx_banco.Text.Trim, numeroCuenta:=txt_numeroCuenta.Text, rutGirador:=txt_rutGirador.Text.Trim, numeroOrsan:=txt_codigoAutorizacion.Text.Trim, codigoRechazoOrsan:=lbl_codigoRechazoOrsan.Text)

        Imagen_Validacion_Cheque.Image = Nothing
        Imagen_Validacion_Cheque.Visible = False
        txt_codigoAutorizacion.Text = ""
        txt_montoCheque.Select()

    End Sub

    Private Sub DgvDetalleProductos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvDetalleProductos.RowsAdded
        ActualizarTotales()
    End Sub

    Private Sub DgvDetalleProductos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DgvDetalleProductos.RowsRemoved
        ActualizarTotales()
    End Sub

    Private Sub DgvDetalleProductos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetalleProductos.CellValueChanged
        ActualizarTotales()
    End Sub

    Private Sub DgvDetallePagos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvDetallePagos.RowsAdded
        CalculaPago()
    End Sub

    Private Sub Label_OK_Cupon_VisibleChanged(sender As Object, e As EventArgs) Handles Label_OK_Cupon.VisibleChanged
        ActualizarTotales()
    End Sub

    Private Sub DgvDetallePagos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DgvDetallePagos.RowsRemoved
        For Each filaPago As DataGridViewRow In DgvDetallePagos.Rows
            Dim numeroSAP As String = filaPago.Cells.Item("col_numeroSAP").Value.ToString()

            For Each Fila As DataGridViewRow In DgvAnticipos.Rows
                If Fila.Cells.Item("ColAntNumeroSAP").Value.ToString() = numeroSAP Then
                    Fila.Visible = False
                Else
                    Fila.Visible = True
                End If
            Next

            For Each Fila As DataGridViewRow In DgvNotasCredito.Rows
                If Fila.Cells.Item("ColNCNumeroSAP").Value.ToString() = numeroSAP Then
                    Fila.Visible = False
                Else
                    Fila.Visible = True
                End If
            Next
        Next

        If DgvDetallePagos.Rows.Count = 0 Then
            For Each Fila As DataGridViewRow In DgvAnticipos.Rows
                Fila.Visible = True
            Next

            For Each Fila As DataGridViewRow In DgvNotasCredito.Rows
                Fila.Visible = True
            Next

        End If

        CalculaPago()
    End Sub

    Private Sub lbl_Saldo_TextChanged(sender As Object, e As EventArgs) Handles lbl_Saldo.TextChanged
        Dim saldo As String = limpiaDato(lbl_Saldo.Text)
        Dim efectivoRedondeado As Integer = 0

        If CInt(saldo) <= 0 Then saldo = ""

        If saldo = "" Then
            txt_montoEfectivo.Text = saldo

        ElseIf IsNumeric(saldo) = True Then
            txt_montoEfectivo.Text = saldo
            efectivoRedondeado = redondearEfectivo(saldo)

            lbl_redondeoEfectivo.Text = efectivoRedondeado - saldo

            lbl_efectivoRedondeado.Text = efectivoRedondeado
            txt_montoEfectivo.Text = saldo

            If totalDisponibleCliente + totalSobregiroCliente >= saldo Then
                txt_montoLineaCredito.Text = saldo

            ElseIf totalDisponibleCliente + totalSobregiroCliente > 0 Then
                txt_montoLineaCredito.Text = totalDisponibleCliente + totalSobregiroCliente

            Else
                txt_montoLineaCredito.Text = "0"

            End If

        End If

        txt_montoTarjeta.Text = saldo
        txt_montoLineaFuncionario.Text = saldo

    End Sub

    Private Sub DgvDocPorPagar_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDocPorPagar.CellMouseClick
        Dim codigo As String = ""
        Dim nombreTipoDocumento As String = ""
        Dim filaBorrar As DataGridViewRow = Nothing
        Dim int_cuentaSeleccion As Integer = 0
        Dim dpce_ID As Integer = 0

        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            dpce_ID = tbaPosDocumentoCab.GetEstadoByID(numeroDocumentoPOS)

            If dpce_ID = 6 OrElse DgvDocPorPagar.Rows(e.RowIndex).ReadOnly = True Then ' Si la fila es de solo lectura significa que el documento de pago ya ha sido autorizado en SAP y NO se permite modificar la selección
                MessageBox.Show("Documento ha sido autorizado EN SAP" & vbCrLf & "NO se permite cambiar la selección", "Documentos por Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            DgvDocPorPagar.Item(0, e.RowIndex).Value = Not DgvDocPorPagar.Item(0, e.RowIndex).Value

            For Each filaGrilla In DgvDocPorPagar.Rows
                If DgvDocPorPagar.Item(0, DgvDocPorPagar.Rows.IndexOf(filaGrilla)).Value = True Then
                    int_cuentaSeleccion += 1
                End If
            Next

            pagandoDocumentos = (int_cuentaSeleccion > 0)

            If DgvDocPorPagar.Item(0, e.RowIndex).Value = True AndAlso (IDNotaVenta > 0 OrElse IDOrdenServicio > 0) Then 'Si se habia agregado una Nota de Venta ó una Orden de Servicio se borran los datos cuando se pagan documentos
                Call limpiaDocumento()
                pagandoDocumentos = (int_cuentaSeleccion > 0)
            End If

            If pagandoDocumentos = True Then
                pnl_totalDocumentos.Visible = True
                pnl_totalProductos.Visible = False
                chk_anticipo.Checked = False
                btnPagarDocumentos.Enabled = True
                btnLineaCredito.Enabled = False
                btnAgregarMontoCuenta.Enabled = False
                chk_imprimirDocumento.Checked = True
                chk_emailDocumento.Checked = False
                chk_emailDocumento.Enabled = False
                tbaPosDocumentoCab.ActualizarTipoByID(2, numeroDocumentoPOS) '2 = pago documentos

            Else
                pnl_totalDocumentos.Visible = False
                pnl_totalProductos.Visible = True

            End If

            nombreTipoDocumento = DgvDocPorPagar.Item(1, e.RowIndex).Value.ToString()
            codigo = DgvDocPorPagar.Item(2, e.RowIndex).Value.ToString()

            If DgvDocPorPagar.Item(0, e.RowIndex).Value = True Then
                agregaProducto(DgvDocPorPagar.Item(2, e.RowIndex).Value, nombreTipoDocumento, 1, DgvDocPorPagar.Item(5, e.RowIndex).Value, DgvDocPorPagar.Item(5, e.RowIndex).Value)

            ElseIf DgvDocPorPagar.Item(0, e.RowIndex).Value = False Then
                For Each fila As DataGridViewRow In DgvDetalleProductos.Rows
                    If fila.Cells(0).Value = codigo AndAlso fila.Cells(1).Value = nombreTipoDocumento Then
                        filaBorrar = fila
                        Exit For
                    End If
                Next

                If Not filaBorrar Is Nothing Then
                    DgvDetalleProductos.Rows.Remove(filaBorrar)
                End If
            End If

            btnFacturar.Text = "Pagar"

            Call ActualizarTotales()
        End If

    End Sub

    Private Sub btnAgregarTransferencia_Click(sender As Object, e As EventArgs) Handles btnAgregarTransferencia.Click
        Dim detalle As String = cbx_bcoTransferencia.Text & ", N° Operación: " & txt_numeroOperacion.Text

        If seleccionandoMedioPago = True Then
            Exit Sub
        End If

        If txt_numeroOperacion.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar un número de operación", "Agregar Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf IsNumeric(txt_montoTransferencia.Text) = False Then
            MessageBox.Show("Debe ingresar un monto", "Agregar Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf txt_nombreArchivoComprobante.Text = "" Then
            MessageBox.Show("Debe adjuntar un comprobante", "Agregar Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            agregaPago(6, "Transferencia", Convert.ToDouble(txt_montoTransferencia.Text), detalle, txt_numeroOperacion.Text, "", "", cbx_bcoTransferencia.Text.ToString(), "")
            txt_nombreArchivoComprobante.Text = ""
        End If

    End Sub

    Private Sub btn_EnviarArchivoERP_Click(sender As Object, e As EventArgs) Handles btnAdjuntarComprobante.Click
        Dim result As DialogResult = Nothing
        Dim int_indiceArchivo As Integer = 0

        'Ofd_importar.Filter = "Comprobantes de Transferencia (*.txt)|*.txt"
        Ofd_importar.Multiselect = False
        result = Ofd_importar.ShowDialog()

        If result = DialogResult.OK AndAlso Ofd_importar.FileName.ToString().Trim <> "" Then
            EnviarArchivoERP(Ofd_importar.FileName.Trim)
            txt_nombreArchivoComprobante.Text = Ofd_importar.FileName.Trim

            MessageBox.Show("Comprobante adjuntado correctamente", "Adjuntar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Function EnviarArchivoERP(ByVal nombreArchivo As String) As Boolean
        Return True
    End Function

    Private Sub DgvDetallePagos_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvDetallePagos.CellPainting
        Dim dgvControl As DataGridView = CType(sender, DataGridView)

        If e.RowIndex > -1 Then

            If e.ColumnIndex = 3 Then
                If dgvControl.Rows.Item(e.RowIndex).Cells.Item("col_tipoMedioPago").Value = "Transferencia" Then ' Ver Comprobante
                    Dim imgXML As Image = iml_botones_columnas.Images(2)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                    e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                    e.Handled = True
                Else
                    e.PaintBackground(e.CellBounds, True)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub DgvDetallePagos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetallePagos.CellClick
        Dim dgvControl As DataGridView = CType(sender, DataGridView)

        If e.RowIndex > -1 Then
            If e.ColumnIndex = 3 AndAlso dgvControl.Rows.Item(e.RowIndex).Cells.Item("col_tipoMedioPago").Value = "Transferencia" Then ' Ver Comprobante
                Process.Start(AppDomain.CurrentDomain.BaseDirectory & "voucher.jpg")
            End If
        End If
    End Sub

    Private Sub DgvDocPorPagar_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvDocPorPagar.CellPainting
        Dim dgvControl As DataGridView = CType(sender, DataGridView)

        If e.RowIndex > -1 Then

            If e.ColumnIndex = dgvControl.Columns.Item("Imprimir").Index Then 'Imprimir
                Dim imgXML As Image = iml_botones_columnas.Images(3)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True

            ElseIf e.ColumnIndex = dgvControl.Columns.Item("Correo").Index Then 'Enviar por Correo
                Dim imgXML As Image = iml_botones_columnas.Images(4)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True

            Else
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub limpiaDocumento()
        btnFacturar.Text = "Facturar"
        btnPagarDocumentos.Enabled = False

        lbl_totalFinal.Text = "$ 0"
        lbl_totalPedido.Text = "$ 0"
        lbl_totalDocumentos.Text = "$ 0"
        lbl_total.Text = "$ 0"
        lbl_pago.Text = "$ 0"
        lbl_Saldo.Text = "$ 0"
        lbl_vuelto.Text = ""
        lbl_docOrigen.Text = "Nota de Venta"
        lbl_creditoDispCliente.Text = "( $ 0 )"
        lbl_redondeoEfectivo.Text = ""
        lbl_efectivoRedondeado.Text = ""

        txt_nombreCajero.Text = ""
        txt_vendedor.Text = ""
        txt_NotaVenta.Text = ""
        txt_OC.Text = ""
        txt_medioPago.Text = ""
        txt_nombre_cliente.Text = ""
        txt_apellido_cliente.Text = ""
        txt_rutCliente.Text = ""
        txt_telefono_cliente.Text = ""
        txt_email_cliente.Text = ""
        txt_giro_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_codigo_CAREN.Text = ""
        txt_cantidad.Text = ""
        txt_cupon.Text = ""
        txt_subtotal.Text = "$ 0"
        txt_totalDescuento.Text = "$ -0"
        txt_totalDocumentos.Text = "$ 0"
        txt_totalNeto.Text = "$ 0"
        txt_totalDescuentoCupon.Text = "$ -0"
        txt_totalIva.Text = "$ 0"
        txt_montoCheque.Text = "$ 0"
        txt_codigoAutorizacion.Text = ""
        txt_numeroCuenta.Text = ""
        txt_nroCheque.Text = ""
        txt_numeroOperacion.Text = ""
        txt_montoTransferencia.Text = ""
        txt_nombreArchivoComprobante.Text = ""
        txt_montoLineaCredito.Text = ""
        txt_montoEfectivo.Text = ""
        txt_vueltoEfectivo.Text = ""
        txt_idCliente.Text = ""
        txt_datosDespacho.Text = ""
        txt_montoTotalCheques.Text = ""
        txt_rutGirador.Text = ""
        txt_montoTarjeta.Text = ""
        txt_NumeroTarjeta.Text = ""
        txt_AutorizacionTarjeta.Text = ""

        cbx_banco.Text = ""
        cbx_bcoTransferencia.Text = ""
        cbx_tipoVencimientoCheque.DisplayMember = "pvc_nombre"
        'cbx_tipoVencimientoCheque.ValueMember = "dato"
        cbx_tipoVencimientoCheque.DataSource = tbaVwPosVencimientoCheque.GetData() 'tbaVencimientoCheque.GetData()

        lstVencimientosCheque.Clear()

        btnAgregarCheque.Enabled = True
        btnAgregarCheque.Visible = True
        btnChequeAnterior.Visible = False
        btnChequeSiguiente.Visible = False
        btnBuscarProducto.Enabled = True
        btnAgregarProducto.Enabled = True
        btnLineaCredito.Enabled = True
        btnLineaCredito.Text = "Línea Crédito"
        btnCheque.Enabled = True
        btnCheque.Text = "Cheque"
        btnGrabarCliente.Text = "Nuevo Cliente"
        btnEfectivo.Enabled = (Configuracion.IDTipoUsuario = 30) 'True
        btnTarjeta.Enabled = True
        btnCheque.Enabled = True
        btnTransferencia.Enabled = True
        btnAgregarEfectivo.Enabled = True

        pnl_totalDocumentos.Visible = False
        pnl_totalProductos.Visible = True

        Configuracion.IDCliente = "0000000000"

        numeroDocumentoPOS = 0
        lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()

        IDNotaVenta = 0
        IDOrdenServicio = 0
        IDDevolucion = 0
        ordenServicioOC = ""
        ordenServicioHES = ""
        estadoNotaVenta = ""

        txt_NotaVenta.Text = IDNotaVenta.ToString()

        pagandoDocumentos = False

        If pagandoDocumentos = True Then
            chk_imprimirDocumento.Checked = False
            chk_emailDocumento.Checked = False
            chk_emailDocumento.Enabled = False

        ElseIf pagandoDocumentos = False Then
            DgvDocPorPagar.DataSource = Nothing
            chk_emailDocumento.Enabled = True

        End If

        chk_imprimirDocumento.Checked = True

        DgvDetalleProductos.Rows.Clear()
        DgvDetalleProductos.Enabled = True
        DgvDetallePagos.Rows.Clear()
        DgvAnticipos.Rows.Clear()
        DgvNotasCredito.Rows.Clear()

        chk_anticipo.Enabled = True
        chk_anticipo.Checked = False

        txt_codigo_CAREN.Enabled = True
        txt_cantidad.Enabled = True

        RadioButton_boleta.Enabled = True
        RadioButton_factura.Enabled = True
        RadioButton_notaCredito.Checked = False
        RadioButton_notaCredito.Enabled = False

        rdbPagoSerial.Checked = True

        cbx_direcciones_cliente.DataSource = Nothing

        cbx_ciudad_cliente.Items.Clear()
        cbx_ciudad_cliente.Text = ""
        cbx_ciudad_cliente.Refresh()

        cbx_comuna_cliente.Items.Clear()
        cbx_comuna_cliente.Text = ""
        cbx_comuna_cliente.Refresh()

        rdbPagoManual.Checked = True

        Imagen_Validacion_Cheque.Image = Nothing
        Imagen_Validacion_Cheque.Visible = False

        txt_montoLineaCredito.Enabled = False
        txt_montoEfectivo.Enabled = True

        WbbNotaVenta.Navigate(New Uri("about:blank"))

        If (Configuracion.IDTipoUsuario = 30) Then
            Call btnEfectivo_Click(btnEfectivo, New EventArgs())
        Else
            Call btnTarjeta_Click(btnTarjeta, New EventArgs())
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnRestablecer_Click(sender As Object, e As EventArgs) Handles btnRestablecer.Click
        Call limpiaDocumento()

        'tbaPosCierreCajaCab.Connection.ConnectionString = "Data Source=(local)\SQLEXP2012;Initial Catalog=catalogoCAREN;Persist Security Info=True;connection timeout=10;User ID=sa;Password=123456;"

        'If TryExecuteSql(Of SqlClient.SqlException)(10,
        '           Sub()
        '               tbaPosCierreCajaCab.CuentaByIdUsuario(Configuracion.IDUsuario)
        '           End Sub) = False Then
        '    MessageBox.Show("Se ha perdido la conexión a Internet", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

    End Sub

    Private Sub textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_montoCheque.KeyPress, txt_montoEfectivo.KeyPress, txt_montoLineaCredito.KeyPress, txt_montoTransferencia.KeyPress, txt_montoTarjeta.KeyPress,
                                                                                   txt_montoTotalCheques.KeyPress, txt_cantidad.KeyPress, txt_NumeroCuotas.KeyPress
        If IsNumeric(e.KeyChar) = False AndAlso e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_rutCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rutCliente.KeyPress
        If e.KeyChar <> ChrW(22) AndAlso e.KeyChar <> vbBack AndAlso IsNumeric(e.KeyChar) = False AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> "K" AndAlso e.KeyChar <> "k" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_rutCliente_LostFocus(sender As Object, e As EventArgs) Handles txt_rutCliente.LostFocus
        If txt_rutCliente.Text.Trim <> "" AndAlso class_funciones.validacionRut(txt_rutCliente.Text) = False Then
            MessageBox.Show("Rut de Cliente incorrecto", "Rut del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAgregarAnticipo_Click(sender As Object, e As EventArgs) Handles btnAgregarAnticipo.Click

        If CType(DgvAnticipos.SelectedRows, IList).Count = 0 Then
            MessageBox.Show("Debe seleccionar una anticipo antes de agregar", "Abonos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim celdas As DataGridViewCellCollection = DgvAnticipos.Rows(DgvAnticipos.CurrentRow.Index).Cells
            Dim valorAnticipo As Double = limpiaDato(celdas.Item("ColAntValor").Value.ToString())
            Dim saldoAPagar As Double = totalFinal - totalPago

            If saldoAPagar <= 0 Then
                MessageBox.Show("NO es posible utilizar un anticipo cuando el saldo a pagar es cero o negativo", "Abonos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If valorAnticipo > saldoAPagar Then
                valorAnticipo = saldoAPagar
            End If

            agregaPago(7, "Anticipo", valorAnticipo,
                       "Anticipo " & celdas.Item("ColAntNumeroDoc").Value.ToString(), "", "", "", "", "", "", "", celdas.Item("ColAntCodEmpresa").Value.ToString(), celdas.Item("ColAntEjercicio").Value.ToString(),
                       celdas.Item("ColAntNumeroSap").Value.ToString())

            DgvAnticipos.Rows(DgvAnticipos.SelectedRows.Item(0).Index).Visible = False
        End If

    End Sub

    Private Sub btnAgregarNotaCredito_Click(sender As Object, e As EventArgs) Handles btnAgregarNotaCredito.Click

        If CType(DgvNotasCredito.SelectedRows, IList).Count = 0 Then
            MessageBox.Show("Debe seleccionar una Nota de Crédito antes de agregar", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim celdas As DataGridViewCellCollection = DgvNotasCredito.Rows(DgvNotasCredito.CurrentRow.Index).Cells

            If totalFinal < Math.Abs(Convert.ToDouble(celdas.Item("ColNCValor").Value.ToString())) Then
                MessageBox.Show("NO se permite utilizar una Nota de Crédito parcialmente. El monto a facturar es menor al total de la Nota de Crédito", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                agregaPago(8, "Nota de Crédito", limpiaDato(celdas.Item("ColNCValor").Value.ToString()),
                           "Nota de Crédito " & celdas.Item("ColNCNumeroDoc").Value.ToString(), "", "", "", "", "", "", "", celdas.Item("ColNCCodEmpresa").Value.ToString(), celdas.Item("ColNCEjercicio").Value.ToString(),
                           celdas.Item("ColNCNumeroSap").Value.ToString())

                DgvNotasCredito.Rows(DgvNotasCredito.SelectedRows.Item(0).Index).Visible = False
            End If
        End If
    End Sub

    Public Function func_montoAPalabras(ByVal value As Double) As String
        Select Case value
            Case 0 : func_montoAPalabras = "CERO"
            Case 1 : func_montoAPalabras = "UN"
            Case 2 : func_montoAPalabras = "DOS"
            Case 3 : func_montoAPalabras = "TRES"
            Case 4 : func_montoAPalabras = "CUATRO"
            Case 5 : func_montoAPalabras = "CINCO"
            Case 6 : func_montoAPalabras = "SEIS"
            Case 7 : func_montoAPalabras = "SIETE"
            Case 8 : func_montoAPalabras = "OCHO"
            Case 9 : func_montoAPalabras = "NUEVE"
            Case 10 : func_montoAPalabras = "DIEZ"
            Case 11 : func_montoAPalabras = "ONCE"
            Case 12 : func_montoAPalabras = "DOCE"
            Case 13 : func_montoAPalabras = "TRECE"
            Case 14 : func_montoAPalabras = "CATORCE"
            Case 15 : func_montoAPalabras = "QUINCE"
            Case Is < 20 : func_montoAPalabras = "DIECI" & func_montoAPalabras(value - 10)
            Case 20 : func_montoAPalabras = "VEINTE"
            Case Is < 30 : func_montoAPalabras = "VEINTI" & func_montoAPalabras(value - 20)
            Case 30 : func_montoAPalabras = "TREINTA"
            Case 40 : func_montoAPalabras = "CUARENTA"
            Case 50 : func_montoAPalabras = "CINCUENTA"
            Case 60 : func_montoAPalabras = "SESENTA"
            Case 70 : func_montoAPalabras = "SETENTA"
            Case 80 : func_montoAPalabras = "OCHENTA"
            Case 90 : func_montoAPalabras = "NOVENTA"
            Case Is < 100 : func_montoAPalabras = func_montoAPalabras(Int(value \ 10) * 10) & " Y " & func_montoAPalabras(value Mod 10)
            Case 100 : func_montoAPalabras = "CIEN"
            Case Is < 200 : func_montoAPalabras = "CIENTO " & func_montoAPalabras(value - 100)
            Case 200, 300, 400, 600, 800 : func_montoAPalabras = func_montoAPalabras(Int(value \ 100)) & "CIENTOS"
            Case 500 : func_montoAPalabras = "QUINIENTOS"
            Case 700 : func_montoAPalabras = "SETECIENTOS"
            Case 900 : func_montoAPalabras = "NOVECIENTOS"
            Case Is < 1000 : func_montoAPalabras = func_montoAPalabras(Int(value \ 100) * 100) & " " & func_montoAPalabras(value Mod 100)
            Case 1000 : func_montoAPalabras = "MIL"
            Case Is < 2000 : func_montoAPalabras = "MIL " & func_montoAPalabras(value Mod 1000)
            Case Is < 1000000 : func_montoAPalabras = func_montoAPalabras(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then func_montoAPalabras = func_montoAPalabras & " " & func_montoAPalabras(value Mod 1000)
            Case 1000000 : func_montoAPalabras = "UN MILLON"
            Case Is < 2000000 : func_montoAPalabras = "UN MILLON " & func_montoAPalabras(value Mod 1000000)
            Case Is < 1000000000000.0# : func_montoAPalabras = func_montoAPalabras(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then func_montoAPalabras = func_montoAPalabras & " " & func_montoAPalabras(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : func_montoAPalabras = "UN BILLON"
            Case Is < 2000000000000.0# : func_montoAPalabras = "UN BILLON " & func_montoAPalabras(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : func_montoAPalabras = func_montoAPalabras(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then func_montoAPalabras = func_montoAPalabras & " " & func_montoAPalabras(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    Private Sub btnNuevoCliente_Click(sender As Object, e As EventArgs) Handles btnGrabarCliente.Click
        Dim frmCliente As FrmCliente = New FrmCliente

        frmCliente.IniciarControles()
        If btnGrabarCliente.Text = "Modificar Cliente" Then
            frmCliente.txt_rutCliente.Text = txt_rutCliente.Text.Trim
            frmCliente.txt_rutCliente.Enabled = False
            frmCliente.txt_idCliente.Text = txt_idCliente.Text.Trim
            frmCliente.txt_idCliente.Enabled = False
        Else
            frmCliente.txt_rutCliente.Text = ""
            frmCliente.txt_rutCliente.Enabled = True
        End If
        frmCliente.ShowDialog(Me)
    End Sub

    Private Sub txt_rutCliente_TextChanged(sender As Object, e As EventArgs) Handles txt_rutCliente.TextChanged
        Dim str_TaxNumber As String = ""
        Dim str_tipoEmpresa As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor

            If IDNotaVenta = 0 AndAlso txt_rutCliente.Text.Trim.Length = 10 AndAlso txt_rutCliente.Text.Contains("-") = False Then
                str_TaxNumber = tbaVwCliente.GetTaxNumberByID(txt_rutCliente.Text.Trim)
                If str_TaxNumber <> "" Then
                    txt_rutCliente.Text = str_TaxNumber.Trim()
                End If
            End If

            If class_funciones.validacionRut(txt_rutCliente.Text.Trim) = True Then
                dtbVwCliente = tbaVwCliente.GetDataByTaxNumber(txt_rutCliente.Text.Trim)

                txt_rutGirador.Text = txt_rutCliente.Text.Trim
                txt_rutGirador.Enabled = False

                If dtbVwCliente.Rows.Count > 0 Then

                    Call ActualizarDatosCliente(dtbVwCliente)
                    Call ActualizarCreditoCliente(txt_rutCliente.Text.Trim, txt_idCliente.Text.Trim, estadoNotaVenta)
                    Call ActualizarPartidasCliente(dtbVwCliente.Rows(0).Item("Bpartner").ToString().Trim())

                    btnEfectivo.Enabled = (Configuracion.IDTipoUsuario = 30)
                    txt_numeroOperacion.Text = txt_rutCliente.Text
                    btnGrabarCliente.Text = "Modificar Cliente"
                Else
                    MessageBox.Show("Cliente NO existe", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    btnGrabarCliente.Text = "Nuevo Cliente"
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cambio de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmbTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDoc.SelectedIndexChanged
        Call AplicarfiltroGrillaPagos()
    End Sub

    Private Sub txt_FolioPagar_TextChanged(sender As Object, e As EventArgs) Handles txt_FolioPagar.TextChanged
        Call AplicarfiltroGrillaPagos()
    End Sub

    Private Sub btnFiltrarPagos_Click(sender As Object, e As EventArgs) Handles btnFiltrarPagos.Click
        Call AplicarfiltroGrillaPagos()
    End Sub

    Private Sub AplicarfiltroGrillaPagos()
        If Not dtbDocPorPagar Is Nothing Then
            If cmbTipoDoc.SelectedItem.ToString() <> "(Todos)" AndAlso txt_FolioPagar.Text.Trim <> "" Then
                dtbDocPorPagar.DefaultView.RowFilter = "TipoDoc = '" & cmbTipoDoc.SelectedItem.ToString() & "' AND Folio=" & txt_FolioPagar.Text

            ElseIf cmbTipoDoc.SelectedItem.ToString() <> "(Todos)" Then
                dtbDocPorPagar.DefaultView.RowFilter = "TipoDoc = '" & cmbTipoDoc.SelectedItem.ToString() & "'"

            ElseIf txt_FolioPagar.Text.Trim <> "" Then
                dtbDocPorPagar.DefaultView.RowFilter = "Folio=" & txt_FolioPagar.Text

            Else
                dtbDocPorPagar.DefaultView.RowFilter = String.Empty
            End If

            DgvDocPorPagar.DataSource = dtbDocPorPagar.DefaultView
        End If
    End Sub

    Private Sub btnFiltrarNotaVenta_Click(sender As Object, e As EventArgs) Handles btnFiltrarNotaVenta.Click
        Call AplicarFiltroNotasVenta()
    End Sub

    Private Sub CmbEstadoNotaVenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEstadoNotaVenta.SelectedIndexChanged
        Call AplicarFiltroNotasVenta()
    End Sub

    Private Sub txt_numeroNV_TextChanged(sender As Object, e As EventArgs) Handles txt_numeroNV.TextChanged
        Call AplicarFiltroNotasVenta()
    End Sub

    Private Sub txt_nombreClienteNV_TextChanged(sender As Object, e As EventArgs) Handles txt_nombreClienteNV.TextChanged
        Call AplicarFiltroNotasVenta()
    End Sub

    Private Sub AplicarFiltroNotasVenta()
        Dim filtro As String = ""

        If Not dtbVwWebNotaVentaCab Is Nothing Then

            If CmbEstadoNotaVenta.SelectedItem.ToString() = "Liberadas" Then
                filtro = "porLiberar = ''"
            ElseIf CmbEstadoNotaVenta.SelectedItem.ToString() = "Por liberar" Then
                filtro = "porLiberar = 'SI'"
            End If

            If txt_numeroNV.Text.Trim <> "" Then
                filtro &= IIf(filtro <> "", " AND ", "") & "nvc_numero=" & txt_numeroNV.Text.Trim
            End If

            If txt_nombreClienteNV.Text.Trim <> "" Then
                filtro &= IIf(filtro <> "", " AND ", "") & "nvc_nombre LIKE '" & txt_nombreClienteNV.Text.Trim & "*'"
            End If

            If filtro = "" Then
                filtro = String.Empty
            End If

            dtbVwWebNotaVentaCab.DefaultView.RowFilter = filtro
            DgvNotasVenta.DataSource = dtbVwWebNotaVentaCab.DefaultView
        End If
    End Sub

    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        Dim str_rutaArchivoPDF As String = ""
        Dim str_rutaArchivoCediblePDF As String = ""
        Dim int_tipoDTE As Integer = 0
        Dim int_folioDocumento As Int64 = 0
        Dim str_RUTEmisor As String = ""
        Dim str_tipoDocSAP As String = ""
        Dim str_rutaAplicacion As String = AppDomain.CurrentDomain.BaseDirectory
        Dim obj_APIDESIS As class_APIDESIS = Nothing
        Dim int_linkDescarga As Integer = 1
        Dim filaPosEmpresaDTE As pos_empresaDteRow = New pos_empresaDteTableAdapter().GetData().Rows(0)
        Dim idSucursalDTE As Integer = 0
        Dim idTiendaFacturacion As String = ""
        Dim filaPosDocumentoCab As pos_documentoCabRow = Nothing
        Dim filaSolicitudDevolucion As WfAprobacion.solicitud_devolucionRow
        Dim obj_filaWebNotaVentaCab As web_notaVentaCabRow = Nothing
        Dim str_idocSAP As String = ""
        Dim str_rutaDescarga As String = ""
        Dim str_rutaDescargaCedible As String = ""
        Dim obj_webClient As System.Net.WebClient = New System.Net.WebClient
        Dim int_reintentosDescarga As Integer = 3
        Dim bol_validacionStock As Boolean = False
        Dim bol_ventaCaja As Boolean = False
        Dim nombreVendedor As String
        Dim nombreTienda As String
        Dim direccionsucursal As String = ""
        Dim idTiendaStock As String
        Dim idUsuarioVendedor As Integer = 0
        Dim totalPagosGrilla As Integer = 0
        Dim observaciones As String = ""
        Dim idVendedorRetira As String = ""
        Dim bpartner As String = ""
        Dim str_trackId As String = ""
        Dim int_milisegundosDESIS As Integer = 2000
        Dim int_reintentosDESIS As Integer = 60
        Dim int_indiceReintentos As Integer = 0
        Dim idVendedor As String = ""
        Dim bol_facturado As Boolean = False
        Dim lng_numeroDocumentoDESIS As Long = 0
        Dim int_reintentosConexion As Integer = 10

        Dim tipoDteRef As Integer = 0
        Dim folioDteRef As Long = 0
        Dim fechaReferencia As Date = Now
        Dim tipoDocOrigen As Integer = 0
        Dim numDocOrigen As Integer = 0
        Dim numNotaVentaOrigen As Integer = 0
        Dim idUsuarioDocOrigen As Integer = 0
        Dim idUsuarioEquiv As String = ""
        Dim codRefNotaCredito As DTEDefTypeDocumentoReferenciaCodRef = DTEDefTypeDocumentoReferenciaCodRef.Item1
        Dim strIdEntregaNotaCredito As String = ""
        Dim obj_condicionPago As condicionPago = class_sap.condicionPago(DgvDetallePagos, Now, Configuracion.IDCliente, Global.caja2.My.MySettings.Default.SapOrgVentas, Configuracion.IDCanal, Global.caja2.My.MySettings.Default.SapSector)
        Dim cuentaDocOrigen As Integer
        Dim PrefijoDocOrigen As String = ""
        Dim montoDevolucion As Double = 0

        Try
            btnFacturar.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            If RadioButton_boleta.Checked = False AndAlso RadioButton_factura.Checked = False AndAlso RadioButton_notaCredito.Checked = False Then
                MessageBox.Show("Debe seleccionar un documento de venta", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnFacturar.Enabled = True
                Me.Cursor = Cursors.Default

                Exit Sub
            End If

            If chk_anticipo.Checked = False AndAlso pagandoDocumentos = False Then
                totalPagosGrilla = DgvDetallePagos.Rows.Cast(Of DataGridViewRow)().Sum(Function(fila) fila.Cells.Item("col_monto").Value + fila.Cells.Item("col_montoRedondeo").Value)
                If totalPagosGrilla > totalFinal Then
                    MessageBox.Show("Esta pagando un monto mayor a la venta", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnFacturar.Enabled = True
                    Me.Cursor = Cursors.Default

                    Exit Sub
                End If
            End If

            If ValidarChequesRechazados() = False Then
                btnFacturar.Enabled = True
                Me.Cursor = Cursors.Default

                Exit Sub
            End If


            If IDOrdenServicio = 0 AndAlso IDNotaVenta = 0 AndAlso IDDevolucion = 0 Then 'Si se está facturando sin un número de Nota de Venta, creamos un folio de Nota de Venta automaticamente
                dtbSPWebNotaVentaAgregadocumentosPOS = tbaSPWebNotaVentaAgregadocumentosPOS.GetData(IDNotaVenta, numeroDocumentoPOS)
                If dtbSPWebNotaVentaAgregadocumentosPOS.Rows.Count > 0 Then
                    IDNotaVenta = dtbSPWebNotaVentaAgregadocumentosPOS.Rows(0).Item("numeroNotaVenta")
                End If
                bol_ventaCaja = True
                idTiendaStock = Configuracion.IDTiendaSAP
                dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(numeroDocumentoPOS)
                dtbPosDocumentoDet = tbaPosDocumentoDet.GetDataByID(numeroDocumentoPOS)

                If dtbPosDocumentoCab.Rows.Count > 0 Then
                    filaPosDocumentoCab = dtbPosDocumentoCab.Rows(0)
                End If

                idUsuarioVendedor = dtbPosDocumentoCab.Rows(0).Item("dpc_idUsuario")
                nombreVendedor = tbaUsuario.GetNombreByID(dtbPosDocumentoCab.Rows(0).Item("dpc_idUsuario"))
                nombreTienda = dtbPosDocumentoCab.Rows(0).Item("dpc_nombreTiendaUsuario").ToString()
                idTiendaFacturacion = filaPosDocumentoCab.dpc_idTiendaUsuario
                idTiendaStock = Configuracion.IDTiendaSAP

            Else
                dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(numeroDocumentoPOS)
                dtbPosDocumentoDet = tbaPosDocumentoDet.GetDataByID(numeroDocumentoPOS)

                If dtbPosDocumentoCab.Rows.Count > 0 Then
                    filaPosDocumentoCab = dtbPosDocumentoCab.Rows(0)
                End If

                If IDNotaVenta > 0 Then
                    dtbWebNotaVentaCab = tbaWebNotaVentaCab.GetDataByID(IDNotaVenta)
                    If dtbWebNotaVentaCab.Rows.Count > 0 Then
                        idUsuarioVendedor = dtbWebNotaVentaCab.Rows(0).Item("nvc_idUsuario")
                        nombreVendedor = tbaUsuario.GetNombreByID(dtbWebNotaVentaCab.Rows(0).Item("nvc_idUsuario"))
                        nombreTienda = dtbWebNotaVentaCab.Rows(0).Item("nvc_nombreTiendaUsuario").ToString()
                        idTiendaFacturacion = dtbWebNotaVentaCab.Rows(0).Item("nvc_idTiendaUsuario").ToString()
                        idTiendaStock = dtbWebNotaVentaCab.Rows(0).Item("nvc_idTiendaNotaVenta").ToString()
                        observaciones = dtbWebNotaVentaCab.Rows(0).Item("nvc_observacionDespacho").ToString()
                        If Not dtbWebNotaVentaCab.Rows(0).Item("nvc_idVendedor") Is DBNull.Value Then
                            idVendedorRetira = tbaUsuario.GetCodUsuarioSAPByID(dtbWebNotaVentaCab.Rows(0).Item("nvc_idVendedor"))
                        End If
                        bpartner = dtbWebNotaVentaCab.Rows(0).Item("cli_id").ToString()
                    End If
                Else
                    idUsuarioVendedor = dtbPosDocumentoCab.Rows(0).Item("dpc_idUsuario")
                    nombreVendedor = tbaUsuario.GetNombreByID(dtbPosDocumentoCab.Rows(0).Item("dpc_idUsuario"))
                    nombreTienda = dtbPosDocumentoCab.Rows(0).Item("dpc_nombreTiendaUsuario").ToString()
                    idTiendaFacturacion = filaPosDocumentoCab.dpc_idTiendaUsuario
                    idTiendaStock = Configuracion.IDTiendaSAP
                    bpartner = dtbPosDocumentoCab.Rows(0).Item("cli_id").ToString()
                End If

            End If

            If RadioButton_notaCredito.Checked = True OrElse IDOrdenServicio > 0 OrElse pagandoDocumentos = True Then
                bol_validacionStock = True
            Else
                bol_validacionStock = ValidarStockProductos(idTiendaStock)
            End If

            If bol_validacionStock = False Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("Uno o más productos NO tienen stock suficiente", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnFacturar.Enabled = True
                Me.Cursor = Cursors.Default

                Exit Sub
            End If

            str_RUTEmisor = filaPosEmpresaDTE.Item("RUTEmisor")

            With Global.caja2.My.MySettings.Default
                obj_APIDESIS = New class_APIDESIS(Global.caja2.My.MySettings.Default.AmbienteSAP, .DESISUsuario, .DESISRut, .DESISPassword, .DESISPuerto, int_linkDescarga)
            End With

            btnFacturar.Enabled = False
            btnFacturar.Text = "Facturando..(DESIS)"
            btnFacturar.Refresh()

            idSucursalDTE = tbaTiendaCiudad.GetSucursalDTEById(idTiendaFacturacion)
            direccionsucursal = tbaTienda.GetDireccionByID(idTiendaFacturacion)
            idVendedor = tbaUsuario.GetCodUsuarioSAPByID(Convert.ToDecimal(idUsuarioVendedor))

            If IDOrdenServicio > 0 Then
                dtbOrdenServicio = tbaOrdenServicio.GetDataByNroOrden(IDOrdenServicio)
                If dtbOrdenServicio.Rows.Count > 0 Then
                    ordenServicioOC = dtbOrdenServicio.Rows(0).Item("NumPedido").ToString().Trim()
                    ordenServicioHES = dtbOrdenServicio.Rows(0).Item("NumServicio").ToString().Trim()
                    idVendedor = dtbOrdenServicio.Rows(0).Item("Vendedor").ToString().Trim()
                    nombreVendedor = dtbOrdenServicio.Rows(0).Item("UsuarioCreador").ToString().Trim()
                    fechaReferencia = dtbOrdenServicio.Rows(0).Item("FechaInicio").ToString().Trim().Substring(0, 4) & "-" & dtbOrdenServicio.Rows(0).Item("FechaInicio").ToString().Trim().Substring(4, 2) & "-" &
                                      dtbOrdenServicio.Rows(0).Item("FechaInicio").ToString().Trim().Substring(6, 2)
                End If
                lng_numeroDocumentoDESIS = IDOrdenServicio

            ElseIf IDNotaVenta > 0 Then
                dtbWebNotaVentaCab = tbaWebNotaVentaCab.GetDataByID(IDNotaVenta)
                If dtbWebNotaVentaCab.Rows.Count > 0 Then
                    ordenServicioOC = dtbWebNotaVentaCab.Rows(0).Item("nvc_numeroOrdenCompra").ToString().Trim()
                End If
                lng_numeroDocumentoDESIS = IDNotaVenta

            ElseIf IDDevolucion > 0 Then
                lng_numeroDocumentoDESIS = IDDevolucion

            End If

            If lng_numeroDocumentoDESIS > 0 Then
                If RadioButton_notaCredito.Checked = True AndAlso tbaDesisLog.CuentaByTipoDteAndNumeroNotaVentaAndResultadoEnvio(61, lng_numeroDocumentoDESIS, -1) > 0 Then
                    int_folioDocumento = tbaDesisLog.GetFolioDteByTipoDteNumeroNotaVenta(61, lng_numeroDocumentoDESIS)
                    MessageBox.Show("Este documento ya ha sido facturado con el folio " & int_folioDocumento.ToString(), "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnFacturar.Enabled = True
                    Me.Cursor = Cursors.Default

                    Exit Sub

                ElseIf RadioButton_factura.Checked = True AndAlso tbaDesisLog.CuentaByTipoDteAndNumeroNotaVentaAndResultadoEnvio(33, lng_numeroDocumentoDESIS, -1) > 0 Then
                    int_folioDocumento = tbaDesisLog.GetFolioDteByTipoDteNumeroNotaVenta(33, lng_numeroDocumentoDESIS)
                    MessageBox.Show("Este documento ya ha sido facturado con el folio " & int_folioDocumento.ToString(), "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnFacturar.Enabled = True
                    Me.Cursor = Cursors.Default

                    Exit Sub

                ElseIf RadioButton_boleta.Checked = True AndAlso tbaDesisLog.CuentaByTipoDteAndNumeroNotaVentaAndResultadoEnvio(39, lng_numeroDocumentoDESIS, -1) > 0 Then
                    int_folioDocumento = tbaDesisLog.GetFolioDteByTipoDteNumeroNotaVenta(39, lng_numeroDocumentoDESIS)
                    MessageBox.Show("Este documento ya ha sido facturado con el folio " & int_folioDocumento.ToString(), "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnFacturar.Enabled = True
                    Me.Cursor = Cursors.Default

                    Exit Sub

                End If
            End If

            If RadioButton_boleta.Checked = True Then
                int_tipoDTE = 39

                If Global.caja2.My.MySettings.Default.DESISMetodoProcesar = "1" Then
                    int_folioDocumento = obj_APIDESIS.generarBoleta(filaPosEmpresaDTE, filaPosDocumentoCab, dtbPosDocumentoDet, idSucursalDTE, nombreTienda, nombreVendedor, obj_condicionPago.CodigoCondicionPago, obj_condicionPago.nombreCondicionPago,
                                                                    ordenServicioOC, ordenServicioHES, Configuracion.IDCaja, Configuracion.NombreUsuario, direccionsucursal)

                ElseIf Global.caja2.My.MySettings.Default.DESISMetodoProcesar = "2" Then
                    str_trackId = obj_APIDESIS.obtenerTrackIdBoleta(filaPosEmpresaDTE, filaPosDocumentoCab, dtbPosDocumentoDet, idSucursalDTE, nombreTienda, nombreVendedor, obj_condicionPago.CodigoCondicionPago, obj_condicionPago.nombreCondicionPago,
                                                                    ordenServicioOC, ordenServicioHES, Configuracion.IDCaja, Configuracion.NombreUsuario, direccionsucursal, totalNeto, totalIva, totalFinal)

                    If obj_APIDESIS.resultadoEnvio = True AndAlso IsNumeric(str_trackId) = True Then
                        For int_indiceReintentos = 1 To int_reintentosDESIS
                            Threading.Thread.Sleep(int_milisegundosDESIS)

                            btnFacturar.Text = "Facturando..(DESIS) " & int_indiceReintentos.ToString()
                            btnFacturar.Refresh()

                            int_folioDocumento = obj_APIDESIS.ConsultarEstadoBoleta(str_trackId)

                            If obj_APIDESIS.resultadoEnvio = True Then
                                Exit For
                            ElseIf obj_APIDESIS.resultadoEnvio = False AndAlso obj_APIDESIS.errorProcesar <> "Documento no procesado" Then
                                Exit For
                            End If
                        Next

                    Else
                        If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS,
                                                  int_indiceReintentos, str_trackId)
                           End Sub) = False Then
                            MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Verificar BOLETA " & int_folioDocumento.ToString() & " en portal SII.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                        If IsNumeric(str_trackId) = False Then
                            MessageBox.Show("DESIS NO ha devuelto un trackId para el documento.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ElseIf String.IsNullOrEmpty(obj_APIDESIS.respuestaXML) = False Then
                            MessageBox.Show(mensajeUsuarioDESIS(obj_APIDESIS.respuestaXML), "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("DESIS NO pudo procesar el documento.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        btnFacturar.Enabled = True
                        Me.Cursor = Cursors.Default

                        Exit Sub
                    End If

                End If

                filaPosDocumentoCab.dpc_tipoDte = int_tipoDTE
                str_rutaArchivoPDF = str_rutaAplicacion & "pdf\E" & str_RUTEmisor & "T" & int_tipoDTE.ToString().Trim() & "F" & int_folioDocumento.ToString() & ".pdf"
                str_tipoDocSAP = "BO"

                'tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS, int_indiceReintentos,
                '                   str_trackId)

                'debemos registrar cuando un DTE fue enviado y se obtuvo el trackId luego fue aceptado ó se agota la cantidad de reintentos de consulta de estado																																								  
                If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                   Sub()
                       tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS,
                                          int_indiceReintentos, str_trackId)
                   End Sub) = False Then
                    MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Verificar BOLETA " & int_folioDocumento.ToString() & " en portal SII.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Cursor = Cursors.Default

                    Exit Sub
                End If

            ElseIf RadioButton_factura.Checked = True Then
                int_tipoDTE = 33

                If Global.caja2.My.MySettings.Default.DESISMetodoProcesar = "1" Then
                    int_folioDocumento = obj_APIDESIS.generarFactura(filaPosEmpresaDTE, filaPosDocumentoCab, dtbPosDocumentoDet, idSucursalDTE, nombreTienda, nombreVendedor, obj_condicionPago.CodigoCondicionPago, obj_condicionPago.nombreCondicionPago,
                                                                     obj_condicionPago.FechaVencimiento, ordenServicioOC, ordenServicioHES, fechaReferencia, cbx_direcciones_cliente.Text, cbx_comuna_cliente.Text, cbx_ciudad_cliente.Text)

                ElseIf Global.caja2.My.MySettings.Default.DESISMetodoProcesar = "2" Then
                    str_trackId = obj_APIDESIS.obtenerTrackIdFactura(filaPosEmpresaDTE, filaPosDocumentoCab, dtbPosDocumentoDet, idSucursalDTE, nombreTienda, nombreVendedor, obj_condicionPago.CodigoCondicionPago, obj_condicionPago.nombreCondicionPago,
                                                                     obj_condicionPago.FechaVencimiento, ordenServicioOC, ordenServicioHES, fechaReferencia, cbx_direcciones_cliente.Text, cbx_comuna_cliente.Text, cbx_ciudad_cliente.Text,
                                                                     totalNeto, totalIva, totalFinal)

                    If obj_APIDESIS.resultadoEnvio = True AndAlso IsNumeric(str_trackId) = True Then
                        For int_indiceReintentos = 1 To int_reintentosDESIS
                            Threading.Thread.Sleep(int_milisegundosDESIS)

                            btnFacturar.Text = "Facturando..(DESIS) " & int_indiceReintentos.ToString()
                            btnFacturar.Refresh()

                            int_folioDocumento = obj_APIDESIS.ConsultarEstadoFactura(str_trackId)

                            If obj_APIDESIS.resultadoEnvio = True Then
                                Exit For
                            ElseIf obj_APIDESIS.resultadoEnvio = False AndAlso obj_APIDESIS.errorProcesar <> "Documento no procesado" Then
                                Exit For
                            End If
                        Next
                    Else
                        If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS,
                                                  int_indiceReintentos, str_trackId)
                           End Sub) = False Then
                            MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Verificar BOLETA " & int_folioDocumento.ToString() & " en portal SII.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                        If IsNumeric(str_trackId) = False Then
                            MessageBox.Show("DESIS NO ha devuelto un trackId para el documento.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ElseIf String.IsNullOrEmpty(obj_APIDESIS.respuestaXML) = False Then
                            MessageBox.Show(mensajeUsuarioDESIS(obj_APIDESIS.respuestaXML), "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("DESIS NO pudo procesar el documento.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        btnFacturar.Enabled = True
                        Me.Cursor = Cursors.Default

                        Exit Sub

                    End If

                End If

                filaPosDocumentoCab.dpc_tipoDte = int_tipoDTE
                str_rutaArchivoPDF = str_rutaAplicacion & "pdf\E" & str_RUTEmisor & "T" & int_tipoDTE.ToString().Trim() & "F" & int_folioDocumento.ToString() & ".pdf"
                str_tipoDocSAP = "FF"

                'tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS, int_indiceReintentos,
                '                   str_trackId)

                'debemos registrar cuando un DTE fue enviado y se obtuvo el trackId luego fue aceptado ó se agota la cantidad de reintentos de consulta de estado																																								  
                If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                   Sub()
                       tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS,
                                          int_indiceReintentos, str_trackId)
                   End Sub) = False Then
                    MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Verificar FACTURA " & int_folioDocumento.ToString() & " en portal SII.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Cursor = Cursors.Default

                    Exit Sub
                End If

            ElseIf RadioButton_notaCredito.Checked = True Then
                int_tipoDTE = 61

                dtbSolicitudDevolucion = tbaSolicitudDevolucion.GetDataByID(IDDevolucion)

                If dtbSolicitudDevolucion.Rows.Count > 0 Then
                    filaSolicitudDevolucion = dtbSolicitudDevolucion.Rows(0)
                    folioDteRef = dtbSolicitudDevolucion.Rows(0).Item("sdv_numeroDocVenta")
                    tipoDteRef = dtbSolicitudDevolucion.Rows(0).Item("sdtd_id")
                    Integer.TryParse(dtbSolicitudDevolucion.Rows(0).Item("sdtdo_ID").ToString(), tipoDocOrigen)
                    Integer.TryParse(dtbSolicitudDevolucion.Rows(0).Item("sdtdo_numero").ToString(), numDocOrigen)
                    Integer.TryParse(dtbSolicitudDevolucion.Rows(0).Item("sdtdo_idUsuario").ToString(), idUsuarioDocOrigen)
                    idUsuarioEquiv = dtbSolicitudDevolucion.Rows(0).Item("sdtdo_idEquivUsuario").ToString()
                    Integer.TryParse(dtbSolicitudDevolucion.Rows(0).Item("sdv_numeroNotaVenta").ToString(), numNotaVentaOrigen)
                    Double.TryParse(dtbSolicitudDevolucion.Rows(0).Item("sdv_montoDevolucion").ToString(), montoDevolucion)

                    If idUsuarioEquiv.ToString().Trim() <> "" Then
                        idVendedor = idUsuarioEquiv
                    Else
                        idVendedor = tbaUsuario.GetCodUsuarioSAPByID(Convert.ToDecimal(idUsuarioDocOrigen))
                    End If

                    nombreVendedor = tbaUsuario.GetNombreByID(idUsuarioDocOrigen)

                    If dtbSolicitudDevolucion.Rows(0).Item("sdtnt_id") Is DBNull.Value OrElse dtbSolicitudDevolucion.Rows(0).Item("sdtnt_id") = 0 Then
                        codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item1

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtnt_id") = 1 Then 'Anula documento
                        codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item1

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtnt_id") = 2 Then 'Corrige texto referencia
                        codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item2

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtnt_id") = 3 Then 'Corrige Montos
                        codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item3

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtnt_id") = 4 Then 'Anula documento
                        codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item1

                    End If

                    'Corrección Boletas de Venta Nota de Crédito anulación

                    Dim tbaDteCab As dte_cabTableAdapter = New dte_cabTableAdapter
                    Dim tbaDteDet As dte_detTableAdapter = New dte_detTableAdapter
                    Dim dtbDteCab As DataTable = tbaDteCab.GetDataByTipoDteAndFolio(tipoDteRef, folioDteRef)
                    Dim dtbDteDet As DataTable = tbaDteDet.GetDataByTipoDTEAndFolio(tipoDteRef, folioDteRef)

                    If (tipoDteRef = 33 OrElse tipoDteRef = 39) AndAlso codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item3 Then

                        If dtbDteCab.Rows.Count > 0 AndAlso dtbDteDet.Rows.Count = 1 AndAlso dtbDteDet.Rows(0).Item("QtyItem") = 1 Then

                            If dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString().Trim() = "1" Then ' 1 = Devolución de Producto
                                codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item1

                            ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString().Trim() = "2" AndAlso tipoDteRef = 39 AndAlso
                                (montoDevolucion = dtbDteCab.Rows(0).Item("MntTotal") OrElse Math.Round(montoDevolucion / 1.19, 0) = dtbDteCab.Rows(0).Item("MntTotal")) Then ' 2 = Descuento no Aplicado
                                codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item1

                            ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString().Trim() = "3" AndAlso tbaWebSolicitudGarantia.GetPorcGarantiaByID(IDDevolucion).ToString().Trim() = "100" Then ' 3 = Devolución Aviso de Garantía
                                codRefNotaCredito = DTEDefTypeDocumentoReferenciaCodRef.Item1

                            End If

                        End If

                    End If

                    If dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString() = "1" Then ' 1 = Devolución de Producto
                        strIdEntregaNotaCredito = "08" '08 -NC Devolución

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString() = "2" Then ' 2 = Descuento NO aplicado
                        strIdEntregaNotaCredito = "09" '09 - NC Corrige monto

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString() = "3" Then ' 3 = Aviso Garantia 
                        strIdEntregaNotaCredito = "09" '09 - NC Corrige monto

                    ElseIf dtbSolicitudDevolucion.Rows(0).Item("sdtn_id").ToString() = "4" Then ' 4 = Refacturación
                        strIdEntregaNotaCredito = "08" '08 -NC Devolución

                    End If

                    str_tipoDocSAP = "NF"

                End If

                If Global.caja2.My.MySettings.Default.DESISMetodoProcesar = "1" Then
                    int_folioDocumento = obj_APIDESIS.generarNotaCredito(filaPosEmpresaDTE, filaPosDocumentoCab, dtbPosDocumentoDet, idSucursalDTE, nombreTienda, nombreVendedor, DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1, "", tipoDteRef,
                                                                         folioDteRef, codRefNotaCredito, numDocOrigen)

                ElseIf Global.caja2.My.MySettings.Default.DESISMetodoProcesar = "2" Then
                    str_trackId = obj_APIDESIS.obtenerTrackIdNotaCredito(filaPosEmpresaDTE, filaPosDocumentoCab, dtbPosDocumentoDet, idSucursalDTE, nombreTienda, nombreVendedor, DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1, "", tipoDteRef,
                                                                         folioDteRef, codRefNotaCredito, numDocOrigen, totalNeto, totalIva, totalFinal)

                    If obj_APIDESIS.resultadoEnvio = True AndAlso IsNumeric(str_trackId) = True Then
                        For int_indiceReintentos = 1 To int_reintentosDESIS
                            Threading.Thread.Sleep(int_milisegundosDESIS)

                            btnFacturar.Text = "Facturando..(DESIS) " & int_indiceReintentos.ToString()
                            btnFacturar.Refresh()

                            int_folioDocumento = obj_APIDESIS.ConsultarEstadoNotaCredito(str_trackId)
                            If obj_APIDESIS.resultadoEnvio = True Then
                                Exit For
                            ElseIf obj_APIDESIS.resultadoEnvio = False AndAlso obj_APIDESIS.errorProcesar <> "Documento no procesado" Then
                                Exit For
                            End If
                        Next

                    Else
                        If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS,
                                                  int_indiceReintentos, str_trackId)
                           End Sub) = False Then
                            MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Verificar BOLETA " & int_folioDocumento.ToString() & " en portal SII.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                        If IsNumeric(str_trackId) = False Then
                            MessageBox.Show("DESIS NO ha devuelto un trackId para el documento.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ElseIf String.IsNullOrEmpty(obj_APIDESIS.respuestaXML) = False Then
                            MessageBox.Show(mensajeUsuarioDESIS(obj_APIDESIS.respuestaXML), "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("DESIS NO pudo procesar el documento.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        btnFacturar.Enabled = True
                        Me.Cursor = Cursors.Default

                        Exit Sub

                    End If

                End If

                filaPosDocumentoCab.dpc_tipoDte = int_tipoDTE
                str_rutaArchivoPDF = str_rutaAplicacion & "pdf\E" & str_RUTEmisor & "T" & int_tipoDTE.ToString().Trim() & "F" & int_folioDocumento.ToString() & ".pdf"

                'tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS, int_indiceReintentos,
                '                   str_trackId)

                'debemos registrar cuando un DTE fue enviado y se obtuvo el trackId luego fue aceptado ó se agota la cantidad de reintentos de consulta de estado																																								  
                If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                   Sub()
                       tbaDesisLog.Insert("POS", numeroDocumentoPOS, Now, obj_APIDESIS.envioXML, obj_APIDESIS.respuestaXML, Configuracion.IDUsuario, obj_APIDESIS.resultadoEnvio, int_tipoDTE, int_folioDocumento, lng_numeroDocumentoDESIS,
                                          int_indiceReintentos, str_trackId)
                   End Sub) = False Then
                    MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Verificar NOTA DE CRÉDITO " & int_folioDocumento.ToString() & " en portal SII.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Me.Cursor = Cursors.Default

                    Exit Sub
                End If

            End If

            If obj_APIDESIS.resultadoEnvio = True Then
                bol_facturado = True
                'tbaPosDocumentoCab.ActualizarEstadoByID(2, numeroDocumentoPOS) ' 2 = facturado

                Try
                    If obj_APIDESIS.ambiente = 0 Then ' 0 = QA
                        obj_APIDESIS.grabaDTE(int_tipoDTE, int_folioDocumento, obj_APIDESIS.envioXML)

                    ElseIf obj_APIDESIS.ambiente = 1 AndAlso int_tipoDTE = 61 Then ' 1 = Producción
                        obj_APIDESIS.grabaDTE(int_tipoDTE, int_folioDocumento, obj_APIDESIS.envioXML)

                    End If

                Catch ex As Exception
                    func_RegistrarEnLogFile("btnFacturar_Click. GrabaDTE : " & ex.Message, ex.StackTrace)
                End Try

                If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                   Sub()
                       tbaPosDocumentoCab.ActualizarEstadoByID(2, numeroDocumentoPOS) ' 2 = facturado
                   End Sub) = False Then
                    MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Estado Documento POS " & numeroDocumentoPOS.ToString() & "NO pudo ser actualizado", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Me.Cursor = Cursors.Default

                    Exit Sub
                End If

                btnFacturar.Text = "Facturando..(SAP)"
                btnFacturar.Refresh()

                If IDOrdenServicio > 0 Then
                    ''tbaOrdenServicio.ActualizarEstadoByNroOrden(1, IDOrdenServicio) '1 = Facturado

                    If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                       Sub()
                           tbaOrdenServicio.ActualizarEstadoByNroOrden(1, IDOrdenServicio) '1 = Facturado
                       End Sub) = False Then
                        MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Estado Orden de Servicio " & IDOrdenServicio.ToString() & " NO pudo ser actualizado", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Me.Cursor = Cursors.Default

                        Exit Sub
                    End If

                    If RadioButton_boleta.Checked = True Then 'Boleta de Venta
                        filaPosDocumentoCab.dpc_tipoDte = 39

                    ElseIf RadioButton_factura.Checked = True Then 'Factura de Venta
                        filaPosDocumentoCab.dpc_tipoDte = 33

                    End If

                    filaPosDocumentoCab.dpc_folioDte = int_folioDocumento.ToString()
                    filaPosDocumentoCab.dpc_urlDte = obj_APIDESIS.urlDescargaArchivo.ToString().Trim()
                    filaPosDocumentoCab.dpce_ID = 2 ' 2 = facturado

                    ''tbaPosDocumentoCab.Update(filaPosDocumentoCab)

                    If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                       Sub()
                           tbaPosDocumentoCab.Update(filaPosDocumentoCab)
                       End Sub) = False Then
                        MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Estado Documento POS " & numeroDocumentoPOS.ToString() & " NO pudo ser actualizado", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Me.Cursor = Cursors.Default

                        Exit Sub
                    End If

                    Call crearPedidoVenta(str_tipoDocSAP, int_tipoDTE, int_folioDocumento, ordenServicioOC, observaciones, totalFinal, "", 0, idVendedor)

                ElseIf IDNotaVenta > 0 Then
                    ''dtbWebNotaVentaCab = tbaWebNotaVentaCab.GetDataByID(IDNotaVenta)

                    If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                       Sub()
                           dtbWebNotaVentaCab = tbaWebNotaVentaCab.GetDataByID(IDNotaVenta)
                       End Sub) = False Then
                        MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Nota de Venta " & IDNotaVenta.ToString() & " NO pudo ser obtenida", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Me.Cursor = Cursors.Default

                        Exit Sub
                    End If

                    If dtbWebNotaVentaCab.Rows.Count > 0 Then
                        obj_filaWebNotaVentaCab = dtbWebNotaVentaCab.Rows(0)

                        If RadioButton_boleta.Checked = True Then 'Boleta de Venta
                            obj_filaWebNotaVentaCab.nvc_tipoDte = 39
                            filaPosDocumentoCab.dpc_tipoDte = 39

                        ElseIf RadioButton_factura.Checked = True Then 'Factura de Venta
                            obj_filaWebNotaVentaCab.nvc_tipoDte = 33
                            filaPosDocumentoCab.dpc_tipoDte = 33

                        End If

                        obj_filaWebNotaVentaCab.nvc_folioDte = int_folioDocumento
                        obj_filaWebNotaVentaCab.nvc_urlDte = obj_APIDESIS.urlDescargaArchivo.ToString().Trim()
                        obj_filaWebNotaVentaCab.nvc_estado = 8 ' 8 = Facturado

                        ''tbaWebNotaVentaCab.Update(obj_filaWebNotaVentaCab)

                        If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaWebNotaVentaCab.Update(obj_filaWebNotaVentaCab)
                           End Sub) = False Then
                            MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Nota de Venta " & IDNotaVenta.ToString() & " NO pudo ser actualizada", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Me.Cursor = Cursors.Default

                            Exit Sub
                        End If

                        filaPosDocumentoCab.dpc_folioDte = int_folioDocumento.ToString()
                        filaPosDocumentoCab.dpc_urlDte = obj_APIDESIS.urlDescargaArchivo.ToString().Trim()
                        filaPosDocumentoCab.dpce_ID = 2 ' 2 = facturado

                        ''tbaPosDocumentoCab.Update(filaPosDocumentoCab)

                        If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaPosDocumentoCab.Update(filaPosDocumentoCab)
                           End Sub) = False Then
                            MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Documento POS " & numeroDocumentoPOS.ToString() & " NO pudo ser actualizado", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Me.Cursor = Cursors.Default

                            Exit Sub
                        End If
                    End If

                    Call crearPedidoVenta(str_tipoDocSAP, int_tipoDTE, int_folioDocumento, ordenServicioOC, observaciones, totalFinal, "", 0, idVendedor, idVendedorRetira)

                ElseIf IDDevolucion > 0 Then
                    filaPosDocumentoCab.dpc_tipoDte = 61
                    filaPosDocumentoCab.dpc_folioDte = int_folioDocumento.ToString()
                    filaPosDocumentoCab.dpc_urlDte = obj_APIDESIS.urlDescargaArchivo.ToString().Trim()
                    filaPosDocumentoCab.dpce_ID = 2 ' 2 = facturado

                    ''tbaPosDocumentoCab.Update(filaPosDocumentoCab)

                    If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaPosDocumentoCab.Update(filaPosDocumentoCab)
                           End Sub) = False Then
                        MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Documento POS " & numeroDocumentoPOS.ToString() & " NO pudo ser actualizado", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Me.Cursor = Cursors.Default

                        Exit Sub
                    End If

                    filaSolicitudDevolucion.sdv_tipoDte = 61
                    filaSolicitudDevolucion.sdv_folioDte = int_folioDocumento.ToString()
                    filaSolicitudDevolucion.sdv_urlDte = obj_APIDESIS.urlDescargaArchivo.ToString().Trim()

                    If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaSolicitudDevolucion.Update(filaSolicitudDevolucion)
                           End Sub) = False Then
                        MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Solicitud de Devolución " & numeroDocumentoPOS.ToString() & " NO pudo ser actualizada", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Me.Cursor = Cursors.Default

                        Exit Sub
                    End If

                    If numNotaVentaOrigen > 0 Then
                        If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               cuentaDocOrigen = tbaSolicitudDevolucion.CuentaByNotaVentaTipoDteEstado(numNotaVentaOrigen, 61, 3)
                           End Sub) = False Then
                            MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "btnFacturar", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                        'Verificamos si la Nota de Venta ya tiene Notas de Crédito facturadas
                        If cuentaDocOrigen = 1 Then
                            PrefijoDocOrigen = "R"

                        ElseIf cuentaDocOrigen = 2 Then
                            PrefijoDocOrigen = "R" & Chr(65)

                        ElseIf cuentaDocOrigen = 3 Then
                            PrefijoDocOrigen = "R" & Chr(65 + 1)

                        ElseIf cuentaDocOrigen > 3 Then
                            PrefijoDocOrigen = "R" & Chr(65 + cuentaDocOrigen - 2)

                        End If

                    Else
                        func_RegistrarEnLogFile("btnFacturar - " & IDDevolucion.ToString() & " : Nota de Venta es cero")

                    End If

                    ''tbaSolicitudDevolucion.ActualizarEstadoByID(3, IDDevolucion) ' 3 = Facturada

                    If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaSolicitudDevolucion.ActualizarEstadoByID(3, IDDevolucion) ' 3 = Facturada
                           End Sub) = False Then
                        MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "Solicitud de Devolución " & numeroDocumentoPOS.ToString() & " NO pudo ser actualizada", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Me.Cursor = Cursors.Default

                        Exit Sub
                    End If

                    Call crearPedidoVenta(str_tipoDocSAP, int_tipoDTE, int_folioDocumento, ordenServicioOC, observaciones, totalFinal, strIdEntregaNotaCredito, numDocOrigen, idVendedor, "", PrefijoDocOrigen)
                End If

                If obj_APIDESIS.urlDescargaArchivo.ToString().Trim() <> "" Then
                    btnFacturar.Text = "Descargando..(PDF)"
                    btnFacturar.Refresh()

                    str_rutaDescarga = str_rutaAplicacion & "pdf\E" & str_RUTEmisor.Trim & "T" & filaPosDocumentoCab.dpc_tipoDte.ToString() & "F" & int_folioDocumento.ToString() & ".pdf"

                    For int_indice As Integer = 1 To int_reintentosDescarga
                        obj_webClient.DownloadFile(obj_APIDESIS.urlDescargaArchivo, str_rutaDescarga)

                        If System.IO.File.Exists(str_rutaDescarga) = True Then
                            Dim nombreArchivo As New FileInfo(str_rutaDescarga)
                            Dim LargoEnBytes As Long = nombreArchivo.Length

                            If LargoEnBytes < 2048 Then 'el archivo se descargó pero si su tamaño es menor a 2 Kb fue de forma parcial. Debemos descargarlo nuevamente
                                Threading.Thread.Sleep(200)
                            Else
                                Exit For
                            End If
                        End If

                    Next

                    If filaPosDocumentoCab.dpc_tipoDte = 33 Then
                        str_rutaDescargaCedible = str_rutaAplicacion & "pdf\E" & str_RUTEmisor.Trim & "T" & filaPosDocumentoCab.dpc_tipoDte.ToString() & "F" & int_folioDocumento.ToString() & ".Cedible.pdf"

                        For int_indice As Integer = 1 To int_reintentosDescarga
                            obj_webClient.DownloadFile(obj_APIDESIS.urlDescargaArchivoCedible, str_rutaDescargaCedible)

                            If System.IO.File.Exists(str_rutaDescargaCedible) = True Then
                                Dim nombreArchivo As New FileInfo(str_rutaDescargaCedible)
                                Dim LargoEnBytes As Long = nombreArchivo.Length

                                If LargoEnBytes < 2048 Then 'el archivo se descargó pero si su tamaño es menor a 2 Kb fue de forma parcial. Debemos descargarlo nuevamente
                                    Threading.Thread.Sleep(200)
                                Else
                                    Exit For
                                End If
                            End If

                        Next

                    End If

                    obj_webClient = Nothing
                End If

                Call ActualizarNotasVentaOrdenesServicio()
                Call ActualizarNotasCreditoWorkflow()
            Else
                tbaPosDocumentoCab.ActualizarEstadoByID(4, numeroDocumentoPOS) ' 4 = anulado
                tbaPosDocumentoDetPago.UpdateByNumero(0, 0, numeroDocumentoPOS) 'eliminamos el documento del cierre de caja activo

                btnFacturar.Text = "Facturando..."
                btnFacturar.Refresh()
                MessageBox.Show("Documento NO pudo ser grabado en DESIS.", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'impresión de documentos
            If chk_imprimirDocumento.Checked AndAlso int_folioDocumento > 0 Then
                Dim numeroCopias As Integer = IIf(int_tipoDTE = 33, 2, 1)
                Dim docPDF As Spire.Pdf.PdfDocument

                btnFacturar.Text = "Imprimiendo..."
                btnFacturar.Refresh()

                If System.IO.File.Exists(str_rutaDescarga) = True Then
                    Try

                        For indice As Integer = 1 To numeroCopias
                            docPDF = New Spire.Pdf.PdfDocument()
                            docPDF.LoadFromFile(str_rutaDescarga)
                            docPDF.Print()
                            docPDF.Close()
                            docPDF.Dispose()
                        Next

                    Catch ex As Exception
                        func_RegistrarEnLogFile("btnFacturar_Click : " & ex.Message, ex.StackTrace)
                        MessageBox.Show("Documento " & str_rutaDescarga & " no pudo ser impreso." & vbCrLf & ex.Message, "imprimir documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If

                If int_tipoDTE = 33 AndAlso System.IO.File.Exists(str_rutaDescargaCedible) = True Then
                    Try
                        docPDF = New Spire.Pdf.PdfDocument()
                        docPDF.LoadFromFile(str_rutaDescargaCedible)
                        docPDF.Print()
                        docPDF.Close()
                        docPDF.Dispose()

                    Catch ex As Exception
                        func_RegistrarEnLogFile("btnFacturar_Click : " & ex.Message, ex.StackTrace)
                        MessageBox.Show("Documento " & str_rutaDescargaCedible & " no pudo ser impreso." & vbCrLf & ex.Message, "imprimir documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If

            End If

            If chk_emailDocumento.Checked AndAlso int_folioDocumento > 0 Then
                btnFacturar.Text = "Enviando correo"
                btnFacturar.Refresh()

                Dim htmlOutput As String = ""

                htmlOutput = "<html xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns:m= 'http://schemas.microsoft.com/office/2004/12/omml' " &
                "xmlns='http://www.w3.org/TR/REC-html40'>" &
                "<head>" &
                "<meta http-equiv=Content-Type content='text/html; charset=utf-8'><meta name=Generator content='Microsoft Word 15 (filtered medium)'>" &
                "<!--[if !mso]><style>v\:* {behavior:url(#default#VML);}" &
                "o\:* {behavior:url(#default#VML);}" &
                "w\:* {behavior:url(#default#VML);}" &
                ".shape {behavior:url(#default#VML);}" &
                "</style><![endif]--><style><!--" &
                "/* Font Definitions */" &
                "@font-face	{font-family:Helvetica;	panose-1:2 11 6 4 2 2 2 2 2 4;}" &
                "@font-face	{font-family:'Cambria Math';	panose-1:2 4 5 3 5 4 6 3 2 4;}" &
                "@font-face	{font-family:Calibri;	panose-1:2 15 5 2 2 2 4 3 2 4;}" &
                "@font-face	{font-family:Verdana;	panose-1:2 11 6 4 3 5 4 4 2 4;}" &
                "/* Style Definitions */" &
                "p.MsoNormal, li.MsoNormal, div.MsoNormal{margin:0cm;	margin-bottom:.0001pt;	font-size:12.0pt;	font-family:'Roboto',serif;}" &
                "h1 {mso-style-priority:9;	mso-style-link:'Título 1 Car';	mso-margin-top-alt:auto;	margin-right:0cm;	mso-margin-bottom-alt:auto;	margin-left:0cm;" &
                "font-size:24.0pt;	font-family:'Roboto',serif;}" &
                "a:link, span.MsoHyperlink	{mso-style-priority:99;	color:blue;	text-decoration:underline;}" &
                "a:visited, span.MsoHyperlinkFollowed	{mso-style-priority:99;	color:purple;	text-decoration:underline;}" &
                "span.Ttulo1Car	{mso-style-name:'Título 1 Car';	mso-style-priority:9;	mso-style-link:'Título 1';	font-family:'Calibri Light',sans-serif;	color:#2E74B5;}" &
                "span.EstiloCorreo19	{mso-style-type:personal-reply;	font-family:'Calibri',sans-serif;	color:black;	font-weight:normal;	font-style:normal;	text-decoration:none none;}" &
                ".MsoChpDefault	{mso-style-type:export-only;	font-size:10.0pt;}" &
                ".DivLeftMargin {    /*margin: 3px 0px 3px 10px !important;*/    padding: 5px 0px 5px 10px !important;}" &
                "@page WordSection1	{size:612.0pt 792.0pt;     margin:70.85pt 3.0cm 70.85pt 3.0cm;}" &
                "div.WordSection1	{page:WordSection1;}" &
                "--></style><!--[if gte mso 9]><xml><o:shapedefaults v:ext='edit' spidmax='1026' /></xml><![endif]--><!--[if gte mso 9]><xml><o:shapelayout v:ext='edit'><o:idmap v:ext='edit' data='1' /></o:shapelayout></xml><![endif]-->" &
                " <title></title> </head><body bgcolor='#EEEEEE' lang=ES link=blue vlink=purple ><form id='form1' ><div class=WordSection1><div align=center>" &
                "<!-- 1--><table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='font-family:'Montserrat', sans-serif;font-weight:bold;width:100.0%;border-collapse:collapse;max-width:600px'>" &
                "<tbody> <tr> <td valign='top' style='padding:0cm 0cm 0cm 0cm'> <div align='center'>" &
                "<!-- 2--><table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='0' style='font-family:'Montserrat', sans-serif;font-weight:bold;width:450.0pt;border-collapse:collapse;max-width:600px'>" &
                "<tbody><tr><td width='600' valign='top' style='width:450.0pt;padding:0cm 0cm 0cm 0cm'><div align='center'>" &
                "<!-- 3--><table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='font-family:'Montserrat', sans-serif;font-weight:bold;width:100.0%;border-collapse:collapse'>" &
                "<tbody> <tr><td valign='top' style='padding:0cm 0cm 0cm 0cm'><div align='center'>" &
                "<!-- 4--><table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='0' style='font-family:'Montserrat', sans-serif;font-weight:bold;width:450.0pt;border-collapse:collapse'>" &
                "<tbody> <tr> <td width='600' valign='top' style='width:450.0pt;padding:0cm 0cm 0cm 0cm'>" &
                "<div align='center'></div> <!-- 5--><table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='font-family:'Montserrat', sans-serif;font-weight:bold;width:100.0%;border-collapse:collapse'>" &
                "<tbody><tr><td valign='top' style='background:white;padding:0cm 0cm 0cm 0cm'>" &
                "<div align='center'><!-- 6--><table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='0' style='font-family:'Montserrat', sans-serif;font-weight:bold;width:450.0pt;border-collapse:collapse'>" &
                "<tbody><tr><td width='600' valign='top' style='width:450.0pt;padding:0cm 0cm 0cm 0cm'>" &
                "<!-- 7-->" &
                "<table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' align='left' width='100%' style='font-family:'Montserrat',sans-serif;font-weight:bold;width:100.0%;background:#f2f2f2;border-collapse:collapse;margin-right:-2.25pt'>" &
                "<tbody>  <!-- Cabecera--> <tr><td><p class='MsoNormal'><a href='https://www.caren.cl' target='_blank'><span style='text-decoration:none'>" &
                "<img border='0' width='600' src='http://www.caren.cl/images/header_DTE.png' alt='' />" &
                "</span></a><o:p></o:p></p></td> </tr> <!-- Fin Cabecera--><!-- Cuerpo --> <tr> <td> <div ID='pnl_solicita'>" &
                " <div style = 'margin: 10px 40px 10px 70px; height:auto; '>" &
                "<table class = 'TablaWidth' style='font-family:Montserrat, sans-serif;font-size:14px;color:#000000;'>" &
                "<tr><td style = 'width:550px; text-align:left; padding-left:50px; padding-top:10px;' ><br /><p><label>Estimado(a):<b> " & txt_nombre_cliente.Text.Trim &
                "</b>, </label></p> <p><label>Junto con saludarte, te enviamos el documento electrónico folio " & int_folioDocumento.ToString() & " correspondiente a la compra de fecha " & Now.ToShortDateString() &
                ".</label></p><p>Gracias por preferirnos.</p></td></tr><tr><td style ='height:20px;'><br /></td></tr>" &
                "<tr><td colspan='2' class='full-width-image'><div style='margin:30px;text-align: center;'><label>Atentamente, caren.cl</label></div></td></tr> </table>" &
                "</div> </div>  </td> </tr>  <tr><td><p class='MsoNormal'><a href='https://www.caren.cl' target='_blank'><span style='text-decoration:none'>" &
                "<img border='0' width='600' src='http://www.caren.cl/images/MailFooter.png' alt='' />" &
                "</span></a><o:p></o:p></p></td> </tr> <!-- Fin Pie --> </tbody> </table> </td></tr></tbody> </table> </div> </td>" &
                " </tr></tbody> </table> </td> </tr> </tbody> </table> </div> </td> </tr> </tbody> </table> </div></td></tr></tbody> </table> </div> </td> </tr> </tbody> </table>" &
                " </div> </div> </form> </body> </html>"

                Dim vistaAlternativa As Net.Mail.AlternateView = Nothing
                vistaAlternativa = Net.Mail.AlternateView.CreateAlternateViewFromString(htmlOutput, Nothing, System.Net.Mime.MediaTypeNames.Text.Html)

                Dim MailDestino As String = txt_email_cliente.Text

                If Global.caja2.My.MySettings.Default.MailPruebas.ToString().Trim() <> "" Then
                    MailDestino = Global.caja2.My.MySettings.Default.MailPruebas.ToString().Trim()
                End If

                If MailDestino <> "" AndAlso MailDestino.Contains("@") = True Then
                    Dim message As New Net.Mail.MailMessage()
                    message.From = New Net.Mail.MailAddress(Global.caja2.My.MySettings.Default.MailFrom)
                    message.AlternateViews.Add(vistaAlternativa)

                    message.To.Add(MailDestino)

                    message.Subject = "Envío de documento electrónico"
                    message.Body = htmlOutput
                    message.IsBodyHtml = True

                    Dim archivoAdjunto As Net.Mail.Attachment = New Net.Mail.Attachment(str_rutaArchivoPDF)

                    message.Attachments.Add(archivoAdjunto)

                    Dim client As Net.Mail.SmtpClient = Nothing
                    Try
                        client = New Net.Mail.SmtpClient()
                        client.UseDefaultCredentials = False
                        client.Host = Global.caja2.My.MySettings.Default.MailSmtpServer.ToString().Trim()
                        client.Port = Global.caja2.My.MySettings.Default.MailSmtpServerPort.ToString().Trim()
                        client.EnableSsl = Global.caja2.My.MySettings.Default.MailSmtpEnableSSL.ToString().Trim()
                        client.Credentials = New System.Net.NetworkCredential(Global.caja2.My.MySettings.Default.MailFrom, Global.caja2.My.MySettings.Default.MailPassword)
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                        client.Send(message)

                        message.Attachments.Clear()
                        client.Dispose()

                    Catch ex As Exception
                        Dim mensaje As String = ex.Message
                    End Try

                    MessageBox.Show("Email enviado a " & MailDestino, "Envío de email", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("Casilla de correo " & MailDestino & " incorrecta", "Envío de email", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

            Call limpiaDocumento()

            btnFacturar.Text = "Facturar"
            btnFacturar.Enabled = True
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            func_RegistrarEnLogFile("btnFacturar.Click " & ex.Message, ex.StackTrace)
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace, "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Finally
            If bol_validacionStock = True AndAlso obj_APIDESIS.resultadoEnvio = True Then
                Call limpiaDocumento()
            End If
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub crearPedidoVenta(ByVal TipoDoc As String, ByVal int_tipoDocumento As Integer, ByVal int_folioDocumento As Int64, ByVal ordenCompra As String, ByVal observaciones As String, ByVal totalDocumento As Integer,
                                 Optional ByVal strIdEntregaNotaCredito As String = "", Optional ByVal numeroDocOrigen As Integer = 0, Optional idUsuarioVendedor As String = "", Optional IdVendedorRetira As String = "",
                                 Optional ByVal PrefijoDocOrigen As String = "")
        Dim obj_sap As class_sap = Nothing
        Dim obj_crearVenta As CrearVentaModel = Nothing
        Dim int_ambiente As Integer = Global.caja2.My.MySettings.Default.AmbienteSAP ' -1 = Desarrollo, 0 = QA, 1 = Producción
        Dim IDTiendaFacturacion As String = Configuracion.IDTiendaSAP
        Dim IDCaja As String = Configuracion.IDCaja
        Dim Fecha As String = Now.ToString("yyyyMMdd")
        Dim NumDTE As String = int_folioDocumento.ToString()
        Dim IDCliente As String = Configuracion.IDCliente
        Dim IDCajero As String = Configuracion.IDUsuario
        Dim Moneda As String = Global.caja2.My.MySettings.Default.monedaSAP
        Dim IDVendedor As String = Configuracion.IDUsuario.ToString()
        Dim IDCanal As String = Configuracion.IDCanal
        Dim Anticipo As String = ""
        Dim Doc_Origen As String = "" 'Nota de Venta / Orden de Servicio
        Dim cuentaDocOrigen As Integer
        Dim id_Entrega As String = ""
        Dim grupoVendedor As String = ""
        Dim despachado_a As String = ""
        Dim dir_despacho As String = "" 'BP direccion alternativa despacho
        Dim fechaEntrega As String = ""
        Dim IDTiendaStock As String = ""
        Dim IDTiendaDespacho As String = ""
        Dim fechaOrdenCompra As String = Now.ToString("yyyyMMdd")
        Dim transportista As String = ""
        Dim tipo_Transporte As String = ""
        Dim codigoProducto As String = ""
        Dim IDClienteBoleta As String

        Dim lst_precio As List(Of Precio) = Nothing
        Dim item_precio As Precio = Nothing
        Dim item_posicion As Posicion = Nothing
        Dim lst_posicion As List(Of Posicion) = New List(Of Posicion)
        Dim item_pago As PagoModel = Nothing
        Dim lst_pagos As List(Of PagoModel) = New List(Of PagoModel)

        Dim totalProductosSAP As Integer = 0
        Dim totalPagosSAP As Integer = 0
        Dim totalDiferenciaSAP As Integer = 0

        Dim int_reintentosConexion As Integer = 10
        Dim int_totalRemanente As Integer = totalDocumento

        Try

            'dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(lblNumeroDocumento.Text)

            If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               dtbPosDocumentoCab = tbaPosDocumentoCab.GetDataByID(lblNumeroDocumento.Text)
                           End Sub) = False Then
                MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "crearPedidoVenta ", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            If dtbPosDocumentoCab.Rows.Count > 0 Then
                Doc_Origen = dtbPosDocumentoCab.Rows(0).Item("dpc_numDocOrigen").ToString()

                IDVendedor = idUsuarioVendedor

                If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") Is DBNull.Value Then
                    id_Entrega = ""

                    'Descomentamos las 3 lineas siguientes por modificación en tiendas de stock para devoluciones en CD
                    If int_tipoDocumento = 61 Then
                        IDTiendaDespacho = dtbPosDocumentoCab.Rows(0).Item("dpc_idTiendaDespacho").ToString().Trim()
                    End If

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 1 Then 'Retiro en Tienda
                    id_Entrega = "01"

                    If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")) = True Then
                        fechaEntrega = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaRetiroTienda")).ToString("yyyyMMdd")
                    End If

                    IDTiendaDespacho = dtbPosDocumentoCab.Rows(0).Item("dpc_idTiendaDespacho").ToString()
                    IdVendedorRetira = ""

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 2 Then 'Despacho a Domicilio
                    id_Entrega = "02"
                    IDTiendaDespacho = dtbPosDocumentoCab.Rows(0).Item("dpc_idTiendaNotaVenta").ToString()
                    IdVendedorRetira = ""

                    If dtbPosDocumentoCab.Rows(0).Item("wcr_id") Is DBNull.Value OrElse dtbPosDocumentoCab.Rows(0).Item("wcr_id") = 1 Then
                        If IsDate(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")) = True Then
                            fechaEntrega = Convert.ToDateTime(dtbPosDocumentoCab.Rows(0).Item("dpc_fechaDespachoDomicilio")).ToString("yyyyMMdd")
                        End If
                    End If

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 4 Then 'envio por pagar
                    id_Entrega = "03"
                    IDTiendaDespacho = dtbPosDocumentoCab.Rows(0).Item("dpc_idTiendaNotaVenta").ToString()
                    IdVendedorRetira = ""

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 3 Then 'retira vendedor
                    id_Entrega = "04"
                    IDTiendaDespacho = dtbPosDocumentoCab.Rows(0).Item("dpc_idTiendaNotaVenta").ToString()

                End If

                IDTiendaStock = dtbPosDocumentoCab.Rows(0).Item("dpc_idTiendaNotaVenta").ToString()

            End If

            If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") Is DBNull.Value Then
                tipo_Transporte = ""

            ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 2 Then 'Despacho a Domicilio
                If dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoTransporte") = 1 Then 'Transporte Interno
                    tipo_Transporte = "I"
                    transportista = ""

                ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoTransporte") = 2 Then 'Operador Externo
                    tipo_Transporte = "E"
                    transportista = dtbPosDocumentoCab.Rows(0).Item("dpc_idOperadorDespacho").ToString()

                Else
                    tipo_Transporte = ""
                    transportista = ""

                End If
            ElseIf dtbPosDocumentoCab.Rows(0).Item("dpc_idTipoDespacho") = 4 Then 'envio por pagar
                transportista = dtbPosDocumentoCab.Rows(0).Item("dpc_idOperadorDespacho").ToString()

            End If

            dir_despacho = dtbPosDocumentoCab.Rows(0).Item("dpc_idDireccionDespacho").ToString()

            If IDTiendaStock = "" Then
                IDTiendaStock = Configuracion.IDTiendaSAP
            End If
            If IDTiendaDespacho = "" Then
                IDTiendaDespacho = Configuracion.IDTiendaSAP
            End If

            If TipoDoc = "NF" Then 'Nota de Crédito
                id_Entrega = strIdEntregaNotaCredito
                Doc_Origen = numeroDocOrigen
            End If

            If TipoDoc = "BO" Then 'Boleta de Venta
                If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               IDClienteBoleta = tbaVwCliente.GetBPartnerByTaxNumber(dtbPosDocumentoCab.Rows(0).Item("dpc_rutClienteBoleta").ToString().Trim())
                           End Sub) = False Then
                    MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "crearPedidoVenta ", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                If dtbPosDocumentoCab.Rows(0).Item("dpc_rutClienteBoleta") Is DBNull.Value OrElse dtbPosDocumentoCab.Rows(0).Item("dpc_rutClienteBoleta").ToString().Trim() = "" OrElse
                   dtbPosDocumentoCab.Rows(0).Item("dpc_rutClienteBoleta").ToString().Trim() = "0-0" OrElse dtbPosDocumentoCab.Rows(0).Item("dpc_rutClienteBoleta").ToString().Trim() = "66666666-6" Then
                    IDCliente = Global.caja2.My.MySettings.Default.SAPBPBoleta

                ElseIf IDClienteBoleta.ToString().Trim() <> "" Then 'tbaVwCliente.GetBPartnerByTaxNumber(dtbPosDocumentoCab.Rows(0).Item("dpc_rutClienteBoleta").ToString().Trim()) <> ""
                    IDCliente = IDClienteBoleta 'tbaVwCliente.GetBPartnerByTaxNumber(dtbPosDocumentoCab.Rows(0).Item("dpc_rutClienteBoleta").ToString().Trim())

                Else
                    IDCliente = Global.caja2.My.MySettings.Default.SAPBPBoleta

                End If
            End If

            With Global.caja2.My.MySettings.Default
                obj_sap = New class_sap(int_ambiente, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
            End With

            For Each fila As DataGridViewRow In DgvDetalleProductos.Rows
                Dim totalFilaConIva As Integer = Math.Round(Convert.ToInt32(fila.Cells("colTotalNeto").Value) * 1.19, 0, MidpointRounding.AwayFromZero)

                If DgvDetalleProductos.Rows.IndexOf(fila) + 1 = DgvDetalleProductos.Rows.Count Then
                    totalFilaConIva = int_totalRemanente
                Else
                    int_totalRemanente = int_totalRemanente - totalFilaConIva
                End If

                If IDOrdenServicio > 0 Then
                    item_posicion = New Posicion("ARTN", fila.Cells("colCodigo").Value.ToString().Trim(), fila.Cells("colCantidad").Value.ToString(), (New List(Of Precio) From {New Precio("PN10", totalFilaConIva)}).ToArray(),
                                                 New Adicionales(IDOrdenServicio.ToString()))
                Else
                    item_posicion = New Posicion("ARTN", fila.Cells("colCodigo").Value.ToString().Trim(), fila.Cells("colCantidad").Value.ToString(), (New List(Of Precio) From {New Precio("PN10", totalFilaConIva)}).ToArray(),
                                                 New Adicionales(""))
                End If

                If TipoDoc = "NF" AndAlso item_posicion.Material.Trim.Length < 6 Then
                    'dtbVwArticulo = tbaVwArticulo.GetDataByLocalNumAnterior(Configuracion.IDTiendaSAP, item_posicion.Material.Trim)

                    If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               dtbVwArticulo = tbaVwArticulo.GetDataByLocalNumAnterior(Configuracion.IDTiendaSAP, item_posicion.Material.Trim)
                           End Sub) = False Then
                        MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "crearPedidoVenta ", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    If dtbVwArticulo.Rows.Count > 0 Then
                        item_posicion.Material = dtbVwArticulo.Rows(0).Item("Material").ToString()
                    End If
                End If

                totalProductosSAP += totalFilaConIva
                lst_posicion.Add(item_posicion)
            Next

            For Each filaPagos As DataGridViewRow In DgvDetallePagos.Rows
                If filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Efectivo" Then
                    item_pago = New PagoModel("PTCS", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), "", "", "", "", "", "", "", "", "", "", "", "", "")

                ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Tarj. Débito" Then
                    item_pago = New PagoModel("ZTDB", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), filaPagos.Cells("col_numeroOperacion").Value, "", "", "", "", "", "", "", "", "",
                                          filaPagos.Cells("ColIDTerminal").Value.ToString(), filaPagos.Cells("ColNumeroCuotas").Value.ToString(), filaPagos.Cells("ColNumeroTarjeta").Value.ToString())

                ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Tarj. Crédito" Then
                    item_pago = New PagoModel("ZTCC", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), filaPagos.Cells("col_numeroOperacion").Value, "", "", "", "", "", "", "", "", "",
                                          filaPagos.Cells("ColIDTerminal").Value.ToString(), filaPagos.Cells("ColNumeroCuotas").Value.ToString(), filaPagos.Cells("ColNumeroTarjeta").Value.ToString())

                ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Cheque" Then
                    item_pago = New PagoModel("PTCH", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), "", "", "", "", filaPagos.Cells("col_numCheque").Value, filaPagos.Cells("col_fechaCheque").Value,
                                          filaPagos.Cells("col_bancoCheque").Value, filaPagos.Cells("col_NroOrsan").Value, filaPagos.Cells("col_rutGirador").Value, filaPagos.Cells("col_nroCuenta").Value, "", "", "")

                ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Nota de Crédito" Then
                    item_pago = New PagoModel("ZNCC", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), "", filaPagos.Cells("col_codEmpresa").Value, filaPagos.Cells("col_ejercicio").Value,
                                          filaPagos.Cells("col_numeroSAP").Value, "", "", "", "", "", "", "", "", "")

                ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Anticipo" Then
                    item_pago = New PagoModel("ZANT", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), "", filaPagos.Cells("col_codEmpresa").Value, filaPagos.Cells("col_ejercicio").Value,
                                          filaPagos.Cells("col_numeroSAP").Value, "", "", "", "", "", "", "", "", "")

                ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Transferencia" Then
                    If filaPagos.Cells("col_bancoCheque").Value.ToString().Trim() = "Chile" Then
                        item_pago = New PagoModel("ZTDC", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), filaPagos.Cells("col_numeroOperacion").Value.ToString(), "", "", "", "", "", "", "", "", "", "", "", "")

                    ElseIf filaPagos.Cells("col_bancoCheque").Value.ToString().Trim() = "Santander" Then
                        item_pago = New PagoModel("ZTDS", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), filaPagos.Cells("col_numeroOperacion").Value.ToString(), "", "", "", "", "", "", "", "", "", "", "", "")

                    Else
                        item_pago = Nothing
                    End If

                ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Linea Funcionario" Then
                    item_pago = New PagoModel("ZEMP", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), "", "", "", "", "", "", "", "", "", "", "", "", "")

                Else ' pago con cargo a linea de crédito, no se envia
                    item_pago = Nothing
                End If

                If Not item_pago Is Nothing Then
                    totalPagosSAP += item_pago.Importe
                    lst_pagos.Add(item_pago)
                End If

                If filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Efectivo" AndAlso filaPagos.Cells("col_montoRedondeo").Value <> 0 Then 'pago en efectivo con redondeo de pesos
                    item_pago = New PagoModel("ZRDD", filaPagos.Cells("col_montoRedondeo").Value, "", "", "", "", "", "", "", "", "", "", "", "", "")
                    totalPagosSAP += item_pago.Importe
                    lst_pagos.Add(item_pago)
                End If

            Next

            'inicio ajuste pesos. comentado en esta versión hasta que sea habilitado en SAP

            'Determinamos si hay diferencia entre el total de pagos y el monto total de productos. Si existe agregamos un nuevo item con la diferencia
            'totalDiferenciaSAP = (totalProductosSAP - totalPagosSAP)

            'If totalPagosSAP <> totalProductosSAP AndAlso Math.Abs(totalDiferenciaSAP) <= Global.caja2.My.MySettings.Default.RangoAjustePesos Then
            '    item_pago = New PagoModel("ZDFC", totalDiferenciaSAP, "", "", "", "", "", "", "", "", "", "", "", "", "")
            '    lst_pagos.Add(item_pago)
            'End If

            'fin ajuste pesos

            obj_crearVenta = New CrearVentaModel(IDTiendaFacturacion, TipoDoc, IDCaja, Fecha, NumDTE, IDCliente, IDCajero, Moneda, IDVendedor, PrefijoDocOrigen & Doc_Origen, IDTiendaStock, IDTiendaDespacho, id_Entrega, grupoVendedor, despachado_a,
                                                 dir_despacho, fechaEntrega, IDCanal, Anticipo, ordenCompra, fechaOrdenCompra, observaciones, transportista, IdVendedorRetira, tipo_Transporte, lst_posicion.ToArray(), lst_pagos.ToArray())

            Dim str_postDataJSON As String = JsonConvert.SerializeObject(obj_crearVenta)
            'tbaSap_log.Insert("POS", numeroDocumentoPOS, Now, str_postDataJSON, "", IDUsuario, -1, int_tipoDocumento, int_folioDocumento, Doc_Origen)
            If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaSap_log.Insert("POS", numeroDocumentoPOS, Now, str_postDataJSON, "", IDUsuario, -1, int_tipoDocumento, int_folioDocumento, Doc_Origen)
                           End Sub) = False Then
                func_RegistrarEnLogFile("crearPedidoVenta. Conexión interrumpida grabando documento : " & numeroDocumentoPOS.ToString() & vbCrLf & str_postDataJSON)
                MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "crearPedidoVenta ", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            Dim str_resultadoJSON As String = obj_sap.postCrearVenta(str_postDataJSON, 200000)
            'tbaSap_log.UpdateByTipoAndNumero(str_resultadoJSON.ToString(), "POS", numeroDocumentoPOS)
            If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                           Sub()
                               tbaSap_log.UpdateByTipoAndNumero(str_resultadoJSON.ToString(), "POS", numeroDocumentoPOS)
                           End Sub) = False Then
                MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "crearPedidoVenta ", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            Dim obj_CrearVentaResponseModel As CrearVentaResponseModel = Nothing

            If String.IsNullOrEmpty(str_resultadoJSON) = False Then

                Try
                    obj_CrearVentaResponseModel = JsonConvert.DeserializeObject(Of CrearVentaResponseModel)(str_resultadoJSON)
                Catch ex As Exception
                    MessageBox.Show("Respuesta NO pudo ser deserializada. " & vbCrLf & str_resultadoJSON, "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

                If Not obj_CrearVentaResponseModel Is Nothing AndAlso Not obj_CrearVentaResponseModel.Message1.ZWPUBON1Response.IdocAssign Is Nothing Then
                    Dim str_idRespuesta As String = "TID : " & obj_CrearVentaResponseModel.Message1.ZWPUBON1Response.IdocAssign.TransferId.ToString() & " DBID : " & obj_CrearVentaResponseModel.Message1.ZWPUBON1Response.IdocAssign.DbId.ToString()

                    dtbPosDocumentoCab.Rows(0).Item("dpc_tid") = obj_CrearVentaResponseModel.Message1.ZWPUBON1Response.IdocAssign.TransferId.ToString()
                    dtbPosDocumentoCab.Rows(0).Item("dpc_dbid") = obj_CrearVentaResponseModel.Message1.ZWPUBON1Response.IdocAssign.DbId.ToString()

                    'tbaPosDocumentoCab.Update(dtbPosDocumentoCab)
                    If TryExecuteSql(Of SqlClient.SqlException)(int_reintentosConexion,
                               Sub()
                                   tbaPosDocumentoCab.Update(dtbPosDocumentoCab)
                               End Sub) = False Then
                        MessageBox.Show("Conexión NO pudo ser restablecida" & vbCrLf & "crearPedidoVenta ", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    MessageBox.Show("Documento se ha grabado correctamente." & vbCrLf & str_idRespuesta, "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Documento NO se ha grabado correctamente." & vbCrLf & str_resultadoJSON, "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Documento NO se ha grabado correctamente. respuesta vacia." & vbCrLf & str_resultadoJSON, "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            func_RegistrarEnLogFile("crearPedidoVenta " & ex.Message, ex.StackTrace)
        End Try

    End Sub

    Private Sub btnChequeAnterior_Click(sender As Object, e As EventArgs) Handles btnChequeAnterior.Click
        If Convert.ToInt32(lblPosicionCheque.Text) > 1 Then
            Call asignarDatosCheque(lblPosicionCheque.Text)
            lblPosicionCheque.Text = Convert.ToInt32(lblPosicionCheque.Text) - 1
            Call ActualizarDatosCheque(lblPosicionCheque.Text)
        End If
    End Sub

    Private Sub btnChequeSiguiente_Click(sender As Object, e As EventArgs) Handles btnChequeSiguiente.Click

        If ValidarControlesCheque() = True Then
            If Convert.ToInt32(lblPosicionCheque.Text) <= lstVencimientosCheque.Count Then
                Call btnAgregarCheque_Click(btnChequeSiguiente, New EventArgs())
            End If

            If Convert.ToInt32(lblPosicionCheque.Text) < lstVencimientosCheque.Count Then
                Call asignarDatosCheque(lblPosicionCheque.Text)

                If lblPosicionCheque.Text.Trim = "1" Then
                    Dim lstDatosCheque As List(Of Tuple(Of String, String, String, String, String, String)) = New List(Of Tuple(Of String, String, String, String, String, String))
                    Dim numeroCheque As Integer

                    Integer.TryParse(txt_nroCheque.Text.Trim, numeroCheque)

                    For Each item In lstVencimientosCheque
                        Dim arrTupla As String() = New String() {item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6}

                        If lstVencimientosCheque.IndexOf(item) > 0 Then
                            If item.Item1 = "" Then
                                arrTupla(0) = txt_rutGirador.Text.Trim
                            End If
                            If item.Item3 <> cbx_banco.SelectedValue.ToString() Then
                                arrTupla(2) = cbx_banco.SelectedValue
                            End If
                            If item.Item4 = "" Then
                                arrTupla(3) = txt_numeroCuenta.Text.Trim
                            End If
                            If item.Item5 < 10 Then
                                If numeroCheque.ToString().Trim().Length < 7 Then
                                    arrTupla(4) = New String("0", 7 - numeroCheque.ToString().Length) & numeroCheque.ToString().Trim()
                                Else
                                    arrTupla(4) = numeroCheque.ToString()
                                End If

                            End If
                        End If

                        lstDatosCheque.Add(New Tuple(Of String, String, String, String, String, String)(arrTupla(0), arrTupla(1), arrTupla(2), arrTupla(3), arrTupla(4), arrTupla(5)))
                        numeroCheque = numeroCheque + 1
                    Next

                    lstVencimientosCheque = lstDatosCheque
                End If

                lblPosicionCheque.Text = Convert.ToInt32(lblPosicionCheque.Text.Trim) + 1
                Call ActualizarDatosCheque(lblPosicionCheque.Text)
            End If
        End If

    End Sub

    Private Function ValidarControlesCheque() As Boolean
        Dim bol_chequeExistente As Boolean = False

        If DgvDetallePagos.Rows.Count > 0 Then
            For Each Fila As DataGridViewRow In DgvDetallePagos.Rows
                If Fila.Cells.Item("col_tipoMedioPago").Value = "Cheque" AndAlso
                    Fila.Cells.Item("col_detalle").Value.ToString().StartsWith(cbx_banco.Text.Trim & ", CTA: " & txt_numeroCuenta.Text & ", N°: " & txt_nroCheque.Text.Trim) = True Then
                    bol_chequeExistente = True
                    Exit For
                End If
            Next
        End If

        If txt_numeroCuenta.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar un número de cuenta", "Agregar Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False

        ElseIf txt_rutGirador.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar un rut de girador", "Agregar Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False

        ElseIf txt_nroCheque.Text.Trim = "" OrElse txt_nroCheque.Text.Trim = "0" Then
            MessageBox.Show("Debe ingresar el número del cheque", "Agregar Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False

        ElseIf IsNumeric(txt_montoCheque.Text) = False Then
            MessageBox.Show("Debe ingresar un monto", "Agregar Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False

        ElseIf bol_chequeExistente = True Then
            MessageBox.Show("Número de Cheque ya ingresado", "Agregar Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False

            'se desactiva validación de código de autorización por solicitud CAREN
            'ElseIf txt_codigoAutorizacion.Text.Trim = "" AndAlso
            '    MessageBox.Show("Cheque NO ha sido validado y será agregado como rechazado" & vbCrLf & "¿ desea agregarlo de todas formas ?", "Agregar Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
            '    Return False
        End If

        Return True
    End Function

    Private Sub cbx_VencimientoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_tipoVencimientoCheque.SelectedIndexChanged
        If cbx_tipoVencimientoCheque.SelectedValue Is Nothing Then
            Exit Sub
        End If

        Dim filatipoVencimientoCheque As DataRowView = cbx_tipoVencimientoCheque.SelectedValue
        Dim int_cantidadVencimientos As Integer = filatipoVencimientoCheque.Item("pvc_numItera")
        Dim dbl_totalCheques As Double = 0
        Dim dbl_montoCheque As Double = 0
        Dim int_numeroCheque As Integer = 0
        Dim dat_vencimientoCheque As DateTime = DateAdd(DateInterval.Day, filatipoVencimientoCheque.Item("pvc_diaIni"), Now)

        If IsNumeric(txt_montoTotalCheques.Text) = True Then
            Integer.TryParse(txt_nroCheque.Text, int_numeroCheque)
            dbl_totalCheques = txt_montoTotalCheques.Text
            dbl_montoCheque = Convert.ToInt32(dbl_totalCheques / int_cantidadVencimientos)
            lstVencimientosCheque.Clear()

            For int_indice As Integer = 1 To int_cantidadVencimientos
                dtbSPPosDocumentoFechasCheque = tbaSPPosDocumentoFechasCheque.GetData(dat_vencimientoCheque)
                If dtbSPPosDocumentoFechasCheque.Rows.Count > 0 Then
                    dat_vencimientoCheque = dtbSPPosDocumentoFechasCheque.Rows(0).Item("fechaCheque")
                End If

                If int_indice = int_cantidadVencimientos Then
                    lstVencimientosCheque.Add(New Tuple(Of String, String, String, String, String, String)(txt_rutGirador.Text, dbl_totalCheques.ToString(), cbx_banco.SelectedValue.ToString(), txt_numeroCuenta.Text, int_numeroCheque.ToString(),
                                                                                                           dat_vencimientoCheque))
                Else
                    lstVencimientosCheque.Add(New Tuple(Of String, String, String, String, String, String)(txt_rutGirador.Text, dbl_montoCheque.ToString(), cbx_banco.SelectedValue.ToString(), txt_numeroCuenta.Text, int_numeroCheque.ToString(),
                                                                                                           dat_vencimientoCheque))
                    dbl_totalCheques -= dbl_montoCheque
                    dat_vencimientoCheque = dat_vencimientoCheque.AddDays(filatipoVencimientoCheque.Item("pvc_diaAgrega"))
                    int_numeroCheque = int_numeroCheque + 1
                End If
            Next

            lblPosicionCheque.Text = "1"
            lblCantidadCheques.Text = lstVencimientosCheque.Count.ToString()
            Call ActualizarDatosCheque(1)

        ElseIf int_cantidadVencimientos > 1 AndAlso IsNumeric(txt_montoTotalCheques.Text) = False Then
            Dim dtvVencimientos As DataView = filatipoVencimientoCheque.DataView
            cbx_tipoVencimientoCheque.SelectedItem = dtvVencimientos.Item(0)
            'cbx_tipoVencimientoCheque.SelectedValue = 1
            MessageBox.Show("Debe ingresar un monto total antes de seleccionar los vencimientos.", "Vencimientos de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        filatipoVencimientoCheque = cbx_tipoVencimientoCheque.SelectedValue
        int_cantidadVencimientos = filatipoVencimientoCheque.Item("pvc_numItera")

        If int_cantidadVencimientos = 1 Then
            btnAgregarCheque.Visible = True
            btnChequeAnterior.Visible = False
            btnChequeSiguiente.Visible = False

        ElseIf int_cantidadVencimientos > 1 Then
            btnAgregarCheque.Visible = False
            btnChequeAnterior.Visible = True
            btnChequeSiguiente.Visible = True

        Else
            btnAgregarCheque.Visible = False
            btnChequeAnterior.Visible = False
            btnChequeSiguiente.Visible = False

        End If
    End Sub

    Private Sub asignarDatosCheque(ByVal indice As Integer)
        If indice > 0 AndAlso indice <= lstVencimientosCheque.Count Then
            lstVencimientosCheque.Item(indice - 1) = New Tuple(Of String, String, String, String, String, String)(txt_rutGirador.Text, txt_montoCheque.Text, cbx_banco.SelectedValue.ToString(), txt_numeroCuenta.Text, txt_nroCheque.Text,
                                                                                                                  DtpFechaVencCheque.Value)
        End If
    End Sub

    Private Sub ActualizarDatosCheque(ByVal indice As Integer)
        If indice > 0 AndAlso indice <= lstVencimientosCheque.Count Then
            txt_rutGirador.Text = lstVencimientosCheque.Item(indice - 1).Item1
            txt_montoCheque.Text = lstVencimientosCheque.Item(indice - 1).Item2
            cbx_banco.SelectedValue = lstVencimientosCheque.Item(indice - 1).Item3
            txt_numeroCuenta.Text = lstVencimientosCheque.Item(indice - 1).Item4
            txt_nroCheque.Text = lstVencimientosCheque.Item(indice - 1).Item5

            DtpFechaVencCheque.MinDate = Convert.ToDateTime("2000-01-01")
            DtpFechaVencCheque.MaxDate = Convert.ToDateTime("2100-01-01")
            DtpFechaVencCheque.Value = lstVencimientosCheque.Item(indice - 1).Item6

            If IsNumeric(Global.caja2.My.MySettings.Default.RangoDiasCheque) = True Then
                DtpFechaVencCheque.MinDate = DtpFechaVencCheque.Value.AddDays(Global.caja2.My.MySettings.Default.RangoDiasCheque * -1)
                DtpFechaVencCheque.MaxDate = DtpFechaVencCheque.Value.AddDays(Global.caja2.My.MySettings.Default.RangoDiasCheque)
            End If
        End If

    End Sub

    Private Sub txt_montoTotalCheques_LostFocus(sender As Object, e As EventArgs) Handles txt_montoTotalCheques.LostFocus
        Dim cantidadVencimientos As String = 1

        If cbx_tipoVencimientoCheque.SelectedValue Is Nothing Then
            Exit Sub
        End If

        If TypeOf cbx_tipoVencimientoCheque.SelectedValue Is DataRowView Then
            cantidadVencimientos = CType(cbx_tipoVencimientoCheque.SelectedValue, DataRowView).Row.Item("pvc_numitera")
        End If

        If IsNumeric(txt_montoTotalCheques.Text) = True AndAlso cantidadVencimientos = 1 Then
            txt_montoCheque.Text = txt_montoTotalCheques.Text
        End If
    End Sub

    Private Sub comboBoxDropDown_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles cbx_tipoVencimientoCheque.DrawItem, cbx_banco.DrawItem, cbx_bcoTransferencia.DrawItem, cmbTipoTarjetaCredito.DrawItem
        Dim CmbControl As ComboBox = CType(sender, ComboBox)
        Dim Brush = Brushes.Black
        Dim Point = New Point(2, e.Index * e.Bounds.Height + 1)
        Dim index As Integer = If(e.Index >= 0, e.Index, 0)
        Dim drvFila As DataRowView = Nothing
        Dim texto As String = ""

        If CmbControl.Items.Count > 0 Then
            If TypeOf CmbControl.Items(index) Is DataRowView Then
                drvFila = CmbControl.Items(index)
                texto = drvFila.Item(CmbControl.DisplayMember).ToString()
            Else
                texto = CmbControl.Items(index).ToString()
            End If

            e.Graphics.FillRectangle(New SolidBrush(CmbControl.BackColor), New Rectangle(Point, e.Bounds.Size))
            e.Graphics.DrawString(texto, e.Font, Brush, e.Bounds, StringFormat.GenericDefault)

        ElseIf CmbControl.Items.Count = 0 Then
            e.Graphics.FillRectangle(New SolidBrush(CmbControl.BackColor), New Rectangle(Point, e.Bounds.Size))
            e.Graphics.DrawString("", e.Font, Brush, e.Bounds, StringFormat.GenericDefault)

        End If
    End Sub

    Private Sub TbpNotaVenta_Enter(sender As Object, e As EventArgs) Handles TbpNotaVenta.Enter
        Call SchedularActualizarNotasVentaCallback(Nothing)
    End Sub

    Private Sub btnPagarDocumentos_Click(sender As Object, e As EventArgs) Handles btnPagarDocumentos.Click
        Dim obj_medioPagoModel As MedioPagoModel = New MedioPagoModel
        Dim lst_documentos As List(Of Documento) = New List(Of Documento)
        Dim obj_documento As Documento = Nothing
        Dim lst_pagos As List(Of Pago) = New List(Of Pago)
        Dim item_pago As Pago = Nothing
        Dim obj_sap As class_sap = Nothing
        Dim str_resultadoJSON As String = ""
        Dim str_moneda As String = Global.caja2.My.MySettings.Default.monedaSAP
        Dim dat_fechaVencDoc As DateTime = Nothing
        Dim bol_fechaVencDoc As Boolean = False
        Dim dpce_ID As Integer = 0
        Dim bol_autorizado As Boolean = False
        Dim int_totalDetallePago As Integer
        Dim int_totalDetalleDocumentos As Integer

        btnPagarDocumentos.Enabled = False
        Call GuardarEstadoControles()
        Me.Cursor = Cursors.WaitCursor

        If totalPago = 0 Then
            MessageBox.Show("Debe agregar pagos antes de pagar documentos o Crear un Anticipo" & str_resultadoJSON, "Pagar Documentos / Crear Anticipo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnPagarDocumentos.Enabled = True
            RestaurarEstadoControles()
            Me.Cursor = Cursors.Default

            Exit Sub

        ElseIf chk_anticipo.Checked = False Then
            int_totalDetallePago = DgvDetallePagos.Rows.Cast(Of DataGridViewRow)().Sum(Function(fila) fila.Cells.Item("col_monto").Value + fila.Cells.Item("col_montoRedondeo").Value)
            int_totalDetalleDocumentos = DgvDocPorPagar.Rows.Cast(Of DataGridViewRow)().Where(Function(fila) fila.Cells.Item("Sel").Value = True).Sum(Function(fila) fila.Cells.Item("Monto").Value)

            If int_totalDetallePago <> int_totalDetalleDocumentos Then
                MessageBox.Show("Esta pagando un monto distinto a la suma de los documentos." & vbCrLf & "Corrija antes de Pagar Documentos", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnPagarDocumentos.Enabled = True
                RestaurarEstadoControles()
                Me.Cursor = Cursors.Default

                Exit Sub
            End If

        End If

        dpce_ID = tbaPosDocumentoCab.GetEstadoByID(numeroDocumentoPOS)

        If chk_anticipo.Checked = True Then
            tbaPosDocumentoCab.ActualizarTipoByID(3, numeroDocumentoPOS) '3 = Anticipo
        Else
            tbaPosDocumentoCab.ActualizarTipoByID(2, numeroDocumentoPOS) '2 = pago documentos

            If dpce_ID = 0 OrElse dpce_ID = 1 Then '1 = creado
                For Each fila As DataGridViewRow In DgvDocPorPagar.Rows
                    If fila.Cells.Item("Sel").Value = True Then


                        tbaSPPosDocumentoAgregaLineaPagoDoc.GetData(numeroDocumentoPOS, 0, fila.Cells.Item("Numero_NotaVenta").Value.ToString().Trim(), fila.Cells.Item("Monto").Value.ToString().Trim(), fila.Cells.Item("Monto").Value.ToString().Trim(),
                                                                    0, fila.Cells.Item("TipoDoc").Value.ToString().Trim(), fila.Cells.Item("Folio").Value.ToString().Trim(), fila.Cells.Item("FechaVto").Value.ToString().Trim())


                    End If
                Next
            End If
        End If

        If ValidarChequesRechazados() = False Then
            btnPagarDocumentos.Enabled = True
            RestaurarEstadoControles()
            Me.Cursor = Cursors.Default

            Exit Sub
        End If

        With obj_medioPagoModel
            .Tienda = Configuracion.IDTiendaSAP
            .Cliente = Configuracion.IDCliente
            .Fecha_operacion = Now.ToShortDateString()
            .Orsan_G = ""
            .Canal_Venta = Configuracion.IDCanal
            .Anticipo = ""

            If chk_anticipo.Checked = True Then
                .Anticipo = "X"
            End If
        End With

        If dpce_ID = 6 Then '6 = autorizado
            bol_autorizado = True
            pcc_ID = tbaVwPosCierreCajaCab.UltimoCierreCajaActivo(Configuracion.IDUsuario)
            tbaPosDocumentoCab.ActualizarEstadoByID(1, numeroDocumentoPOS) ' 1 = creado
            tbaPosDocumentoDetPago.UpdateByNumero(pcc_ID, 0, numeroDocumentoPOS) 'incorporamos el documento al cierre de caja actual
        End If

        For Each filaPagos As DataGridViewRow In DgvDetallePagos.Rows
            item_pago = Nothing

            If filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Efectivo" Then
                If Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", "") <> "0" Then 'API integración SAP NO permite efectivo con valor cero
                    item_pago = New Pago("PTCS", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), str_moneda, "", "", "", "", "", "", "", "", "", "")
                End If

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Tarj. Débito" Then
                item_pago = New Pago("ZTDB", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), str_moneda, filaPagos.Cells("col_numeroOperacion").Value, "", "", "", "", "", "", "", "", "")

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Tarj. Crédito" Then
                item_pago = New Pago("ZTCC", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), str_moneda, filaPagos.Cells("col_numeroOperacion").Value, "", "", "", "", "", "", "", "", "")

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Cheque" Then
                item_pago = New Pago("PTCH", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), str_moneda, "", "", "", "", filaPagos.Cells("col_numCheque").Value, filaPagos.Cells("col_fechaCheque").Value,
                                     filaPagos.Cells("col_bancoCheque").Value, filaPagos.Cells("col_NroOrsan").Value, filaPagos.Cells("col_rutGirador").Value, filaPagos.Cells("col_nroCuenta").Value)

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Nota de Crédito" Then
                item_pago = New Pago("ZNCC", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), str_moneda, "", filaPagos.Cells("col_codEmpresa").Value, filaPagos.Cells("col_ejercicio").Value,
                                     filaPagos.Cells("col_numeroSAP").Value, "", "", "", "", "", "")

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Anticipo" Then
                item_pago = New Pago("ZANT", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), str_moneda, "", filaPagos.Cells("col_codEmpresa").Value, filaPagos.Cells("col_ejercicio").Value,
                                     filaPagos.Cells("col_numeroSAP").Value, "", "", "", "", "", "")

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Transferencia" Then
                If filaPagos.Cells("col_bancoCheque").Value.ToString().Trim() = "Chile" Then
                    item_pago = New Pago("ZTDC", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), str_moneda, filaPagos.Cells("col_numeroOperacion").Value.ToString(), "", "", "", "", "", "", "", "", "")

                ElseIf filaPagos.Cells("col_bancoCheque").Value.ToString().Trim() = "Santander" Then
                    item_pago = New Pago("ZTDS", Regex.Replace(filaPagos.Cells("col_monto").Value.ToString(), "[^0-9]", ""), str_moneda, filaPagos.Cells("col_numeroOperacion").Value.ToString(), "", "", "", "", "", "", "", "", "")

                End If
            Else ' pago con cargo a linea de crédito
                item_pago = New Pago("", 0, "", "", "", "", "", "", "", "", "", "", "")
            End If

            If Not item_pago Is Nothing Then
                lst_pagos.Add(item_pago)
            End If

            If filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Efectivo" AndAlso filaPagos.Cells("col_montoRedondeo").Value <> 0 Then 'pago en efectivo con redondeo de pesos
                item_pago = New Pago("ZRDD", Regex.Replace(filaPagos.Cells("col_montoRedondeo").Value.ToString(), "[^0-9-]", ""), str_moneda, "", "", "", "", "", "", "", "", "", "")
                lst_pagos.Add(item_pago)
            End If

        Next

        If chk_anticipo.Checked = True Then 'Anticipo 
            obj_documento = New Documento("", "", "")
            lst_documentos.Add(obj_documento)

        ElseIf chk_anticipo.Checked = False Then 'Pago de Documentos impagos
            For Each fila As DataGridViewRow In DgvDocPorPagar.Rows
                If fila.Cells.Item("Sel").Value = True Then
                    obj_documento = New Documento(fila.Cells.Item("Numero_NotaVenta").Value.ToString().Trim(), fila.Cells.Item("Monto").Value.ToString().Trim(), fila.Cells.Item("Numero_SAP").Value.ToString().Trim())
                    lst_documentos.Add(obj_documento)
                End If
            Next

        End If

        obj_medioPagoModel.Pagos = lst_pagos.ToArray()
        obj_medioPagoModel.Documentos = lst_documentos.ToArray()

        With Global.caja2.My.MySettings.Default
            obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
        End With

        Dim str_postDataJSON As String = ""
        Dim obj_medioPagoResponseModel As MedioPagoResponseModel = Nothing

        str_postDataJSON = JsonConvert.SerializeObject(obj_medioPagoModel)
        tbaSap_log.Insert("POS", numeroDocumentoPOS, Now, str_postDataJSON, "", IDUsuario, -1, 0, 0, numeroDocumentoPOS)
        str_resultadoJSON = obj_sap.postMedioPago(str_postDataJSON)
        tbaSap_log.UpdateByTipoAndNumero(str_resultadoJSON.ToString(), "POS", numeroDocumentoPOS)

        If String.IsNullOrEmpty(str_resultadoJSON) = False Then
            obj_medioPagoResponseModel = JsonConvert.DeserializeObject(Of MedioPagoResponseModel)(str_resultadoJSON)

            If chk_anticipo.Checked = True AndAlso Not obj_medioPagoResponseModel Is Nothing AndAlso IsNumeric(obj_medioPagoResponseModel.EDocumento) = True Then 'Anticipo 
                tbaPosDocumentoCab.ActualizarEstadoByID(2, numeroDocumentoPOS) ' 2 = facturado

                If chk_imprimirDocumento.Checked = True Then
                    Call CrearReciboPago(numeroDocumentoPOS)
                End If

                MessageBox.Show("Documento creado : " & obj_medioPagoResponseModel.EDocumento.ToString(), "Anticipo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf chk_anticipo.Checked = False AndAlso Not obj_medioPagoResponseModel Is Nothing AndAlso obj_medioPagoResponseModel.EtReturn.GetLength(0) > 0 AndAlso
                CType(obj_medioPagoResponseModel.EtReturn.GetValue(0), MedioPagoEtreturn).item.Contains("was posted in company code") = True Then 'Pago de Documentos

                tbaPosDocumentoCab.ActualizarEstadoByID(2, numeroDocumentoPOS) ' 2 = facturado

                If chk_imprimirDocumento.Checked = True Then
                    Call CrearReciboPago(numeroDocumentoPOS)
                End If

                MessageBox.Show("Documento creado : " & obj_medioPagoResponseModel.EDocumento.ToString(), "Pagar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If bol_autorizado = True Then
                    tbaPosDocumentoCab.ActualizarEstadoByID(6, numeroDocumentoPOS) ' 6 = autorizado
                End If
                MessageBox.Show("Respuesta API  : " & str_resultadoJSON, "Pagar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBox.Show("Respuesta API  : respuesta vacía", "Pagar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        pagandoDocumentos = False
        RestaurarEstadoControles()
        Call limpiaDocumento()
        Call EstadoBotonesPago()

    End Sub

    Private Sub CrearReciboPago(ByVal numeroDocumento As Integer)
        Dim str_rutaAplicacion As String = AppDomain.CurrentDomain.BaseDirectory
        Dim str_nombreArchivoDestino As String = str_rutaAplicacion & "pdf\" & "ReciboPago" & numeroDocumento.ToString() & ".pdf"

        Dim nombreCopiaCliente As String = crearPDFRecibo(numeroDocumento, str_rutaAplicacion & "pdf\" & "ReciboPago" & numeroDocumento.ToString() & ".cliente.pdf", "Copia Cliente")
        Dim nombreCopiaCajero As String = crearPDFRecibo(numeroDocumento, str_rutaAplicacion & "pdf\" & "ReciboPago" & numeroDocumento.ToString() & ".cajero.pdf", "Copia Cajero")

        Dim ListaMatrizContenido As List(Of Byte()) = New List(Of Byte())
        Dim matrizCopiaCliente As Byte() = File.ReadAllBytes(nombreCopiaCliente)
        Dim matrizCopiaCajero As Byte() = File.ReadAllBytes(nombreCopiaCajero)

        ListaMatrizContenido.Add(matrizCopiaCliente)
        ListaMatrizContenido.Add(matrizCopiaCajero)

        Dim matrizFusionContenido As Byte() = class_PdfMerger.MergeFiles(ListaMatrizContenido)
        File.WriteAllBytes(str_nombreArchivoDestino, matrizFusionContenido)

        System.Diagnostics.Process.Start(str_nombreArchivoDestino)

    End Sub


    Private Function crearPDFRecibo(ByVal dpc_numero As Integer, ByVal nombreArchivoDestino As String, ByVal nombreCopia As String) As String
        'Alineación: 0 = left, 1 = center, 2 = rigth
        Dim memoria As New System.IO.MemoryStream
        Dim colorAzulClaro As iTextSharp.text.BaseColor = New iTextSharp.text.BaseColor(156, 180, 224)
        Dim colorAzulOscuro As iTextSharp.text.BaseColor = New iTextSharp.text.BaseColor(0, 32, 96)
        Dim colorNegro As iTextSharp.text.BaseColor = New iTextSharp.text.BaseColor(0, 0, 0)
        Dim font1 As BaseFont = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA_BOLD, iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
        Dim font2 As BaseFont = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
        Dim fontSize8 As Integer = 8
        Dim oldFileFA As String = Application.StartupPath() & "\PDF\ReciboPago.pdf"
        Dim appPath As String = AppDomain.CurrentDomain.BaseDirectory
        Dim itemActual As Integer = 0
        Dim filaDatos As DataRow = Nothing
        Dim altoFilaDetallePago As Integer = 14
        Dim altoFilaDetallePagoDoc As Integer = 14
        Dim yInicial As Integer = 0
        Dim totalAPagar As Integer = 0
        Dim totalPagado As Integer = 0
        Dim arrRutCliente As String() = Nothing

        'Obtenemos los Datos
        dtbPosEmpresaDTE = tbaPosEmpresaDTE.GetData()
        dtbVwPosDocumentoCab = tbaVwPosDocumentoCab.GetDataByID(dpc_numero)
        dtbVwPosDocumentoDetPagoDoc = tbaVwPosDocumentoDetPagoDoc.GetDataByID(dpc_numero)
        dtbVwPosDocumentoDetPago = tbaVwPosDocumentoDetPago.GetDataByID(dpc_numero)

        ' abre el reader
        Dim FA_reader = New PdfReader(oldFileFA)
        Dim sizeReciboPago = FA_reader.GetPageSizeWithRotation(1)

        yInicial += sizeReciboPago.Height
        yInicial += (dtbVwPosDocumentoDetPagoDoc.Rows.Count * altoFilaDetallePagoDoc)

        If dtbVwPosDocumentoDetPago.Rows.Count > 0 Then
            yInicial += 28 'Cabecera Forma de Pago
            yInicial += (dtbVwPosDocumentoDetPago.Rows.Count * altoFilaDetallePago)
        End If

        yInicial += 45 'TOTALES
        yInicial += 35 'TIMBRE
        yInicial += 20 'MARGEN

        Dim rectanguloDocumento As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(Convert.ToSingle(sizeReciboPago.Width), Convert.ToSingle(yInicial))
        Dim documentFINAL As iTextSharp.text.Document = New iTextSharp.text.Document(rectanguloDocumento, 0, 0, 0, 0)
        Dim writer = PdfWriter.GetInstance(documentFINAL, memoria)
        Dim x As Integer, y As Integer

        documentFINAL.Open()
        Dim cb = writer.DirectContent

        ' create the new pages and add it to the pdf
        Dim FA_page1 = writer.GetImportedPage(FA_reader, 1)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Nueva Página
        documentFINAL.NewPage()
        cb.AddTemplate(FA_page1, 0, rectanguloDocumento.Height - sizeReciboPago.Height)

        Dim fuenteArialBoldMT As BaseFont = Nothing
        Dim fuenteArialMT As BaseFont = Nothing
        Dim fuenteArialNarrow As BaseFont = Nothing
        Dim fuenteArialNarrowBold As BaseFont = Nothing

        Dim fonts As List(Of Object()) = BaseFont.GetDocumentFonts(FA_reader)
        Dim baseFonts As BaseFont() = New BaseFont(fonts.Count - 1) {}
        Dim fn = New String(fonts.Count - 1) {}

        For i = 0 To fonts.Count - 1
            Dim obj As Object = fonts(i)
            baseFonts(i) = BaseFont.CreateFont(CType(obj(1), PRIndirectReference))
            fn(i) = baseFonts(i).PostscriptFontName.ToString()
            Console.WriteLine(baseFonts(i).FamilyFontName(0)(1).ToString())

            If baseFonts(i).PostscriptFontName.ToString().EndsWith("+Arial-BoldMT") = True Then
                fuenteArialBoldMT = BaseFont.CreateFont(CType(obj(1), PRIndirectReference))

            ElseIf baseFonts(i).PostscriptFontName.ToString().EndsWith("+ArialNarrow") = True Then
                fuenteArialNarrow = BaseFont.CreateFont(CType(obj(1), PRIndirectReference))

            ElseIf baseFonts(i).PostscriptFontName.ToString().EndsWith("+ArialNarrow-Bold") = True Then
                fuenteArialNarrowBold = BaseFont.CreateFont(CType(obj(1), PRIndirectReference))

            ElseIf baseFonts(i).PostscriptFontName.ToString().EndsWith("+ArialMT") = True Then
                fuenteArialMT = BaseFont.CreateFont(CType(obj(1), PRIndirectReference))

            End If
        Next

        fuenteArialBoldMT = iTextSharp.text.pdf.BaseFont.CreateFont(appPath & "fonts\" & "Arial-BoldMT.otf", iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.EMBEDDED)
        fuenteArialMT = iTextSharp.text.pdf.BaseFont.CreateFont(appPath & "fonts\" & "ARIALMT.ttf", iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.EMBEDDED)

        cb.SetColorFill(colorNegro)

        If dtbPosEmpresaDTE.Rows.Count > 0 Then
            agregaTextoPDF(cb, font1, 8, 0, 50, rectanguloDocumento.Height - 161, Configuracion.NombreTiendaUsuario)
        End If

        'N° documento:
        agregaTextoPDF(cb, font1, 11, 0, 140, rectanguloDocumento.Height - 78, dtbVwPosDocumentoCab.Rows(0).Item("dpc_numero").ToString())

        'Fecha:
        agregaTextoPDF(cb, font1, 8, 1, 135, rectanguloDocumento.Height - 98, Convert.ToDateTime(dtbVwPosDocumentoCab.Rows(0).Item("dpc_fecha")).ToString("dd-MM-yyyy"))
        agregaTextoPDF(cb, font1, 8, 1, 195, rectanguloDocumento.Height - 98, Convert.ToDateTime(dtbVwPosDocumentoCab.Rows(0).Item("dpc_fecha")).ToString("HH:mm").ToUpper())

        'Datos del Cliente
        arrRutCliente = dtbVwPosDocumentoCab.Rows(0).Item("dpc_rut").ToString().Split("-")

        If arrRutCliente.Length > 0 AndAlso IsNumeric(arrRutCliente(0)) = True Then
            arrRutCliente(0) = String.Format(nbfInfo, "{0:#,##0}", Convert.ToInt32(arrRutCliente(0)))
        End If

        cb.SetColorFill(colorNegro)
        agregaTextoPDF(cb, font1, 8, 0, 44, rectanguloDocumento.Height - 185, dtbVwPosDocumentoCab.Rows(0).Item("dpc_nombre").ToString().ToUpper())
        agregaTextoPDF(cb, font1, 8, 0, 44, rectanguloDocumento.Height - 196, String.Join("-", arrRutCliente))
        agregaTextoPDF(cb, font1, 8, 1, 242, rectanguloDocumento.Height - 197, dtbVwPosDocumentoCab.Rows(0).Item("cli_id").ToString())

        y = rectanguloDocumento.Height - sizeReciboPago.Height

        '
        'DETALLE DE DOCUMENTOS PAGADOS

        If dtbVwPosDocumentoCab.Rows(0).Item("dpc_idTipoDocumento") Is DBNull.Value OrElse dtbVwPosDocumentoCab.Rows(0).Item("dpc_idTipoDocumento") = 1 Then
        ElseIf dtbVwPosDocumentoCab.Rows(0).Item("dpc_idTipoDocumento") = 2 Then ' Pago de Documentos
            itemActual = 0

            While itemActual < dtbVwPosDocumentoDetPagoDoc.Rows.Count
                filaDatos = dtbVwPosDocumentoDetPagoDoc.Rows.Item(itemActual)

                x = 0

                'N° TIPO DOCUMENTO
                x = x + 23

                If filaDatos.Item("dpdd_nombreTipoDoc").ToString().Contains("FACTURAS CXC") Then
                    agregaTextoPDF(cb, font2, fontSize8, 0, x, y, "FACTURAS")

                ElseIf filaDatos.Item("dpdd_nombreTipoDoc").ToString().Contains("CHEQUES EN CARTERA") = True OrElse filaDatos.Item("dpdd_nombreTipoDoc").ToString().Contains("CHEQUE") = True Then
                    agregaTextoPDF(cb, font2, fontSize8, 0, x, y, "CHEQUES")

                Else
                    agregaTextoPDF(cb, font2, fontSize8, 0, x, y, filaDatos.Item("dpdd_nombreTipoDoc").ToString().Trim())

                End If

                'N° DOCUMENTO
                x = x + 95
                agregaTextoPDF(cb, font2, fontSize8, 2, x, y, String.Format(nbfInfo, "{0:N0}", filaDatos.Item("dpdd_numeroDoc")))

                'VENCIMIENTO
                x = x + 47
                If IsDate(filaDatos.Item("dpdd_fechaVencDoc")) = True Then
                    agregaTextoPDF(cb, font2, fontSize8, 1, x, y, String.Format(nbfInfo, "{0:dd-MM-yyyy}", filaDatos.Item("dpdd_fechaVencDoc")))
                End If

                'MONTO
                x = x + 100
                agregaTextoPDF(cb, font2, fontSize8, 2, x, y, String.Format(nbfInfo, "$ {0:N0}", filaDatos.Item("dpdd_total")))

                totalAPagar += filaDatos.Item("dpdd_total")

                y = y - altoFilaDetallePagoDoc

                itemActual = itemActual + 1

            End While


        End If

        If dtbVwPosDocumentoCab.Rows(0).Item("dpc_idTipoDocumento") = 3 Then ' Anticipo
            Dim xRectangulo As Integer = 0 + 25 + 50
            Dim yRectangulo As Integer = rectanguloDocumento.Height - sizeReciboPago.Height

            Dim rectanguloFila As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(Convert.ToSingle(xRectangulo), Convert.ToSingle(yRectangulo + 12), Convert.ToSingle(xRectangulo + 120), Convert.ToSingle(yRectangulo + 35 - 7))
            rectanguloFila.BackgroundColor = iTextSharp.text.BaseColor.WHITE

            'rectanguloFila.BorderColorLeft = iTextSharp.text.BaseColor.BLUE
            'rectanguloFila.BorderWidthLeft = 0.5
            'rectanguloFila.BorderColorRight = iTextSharp.text.BaseColor.YELLOW
            'rectanguloFila.BorderWidthRight = 0.5
            'rectanguloFila.BorderColorTop = iTextSharp.text.BaseColor.GREEN
            'rectanguloFila.BorderWidthTop = 0.5
            'rectanguloFila.BorderColorBottom = iTextSharp.text.BaseColor.RED
            'rectanguloFila.BorderWidthBottom = 0.5

            cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
            cb.Rectangle(rectanguloFila)

            cb.SetColorFill(colorNegro)
            x = 0

            'N° TIPO DOCUMENTO
            x = x + 23

            agregaTextoPDF(cb, font2, fontSize8, 0, x, y, "ANTICIPO")

            'N° DOCUMENTO
            x = x + 95

            'VENCIMIENTO
            x = x + 47

            'MONTO
            totalAPagar = dtbVwPosDocumentoDetPago.AsEnumerable().Sum(Function(fila) fila("dpdp_montoPago"))

            x = x + 100
            agregaTextoPDF(cb, font2, fontSize8, 2, x, y, String.Format(nbfInfo, "$ {0:N0}", totalAPagar))

            y = y - altoFilaDetallePagoDoc

        End If

        'CABECERA DETALLE DE PAGOS
        y = y - 5

        cb.SetColorFill(colorNegro)
        agregaTextoPDF(cb, fuenteArialBoldMT, 8, 0, 25, y, "FORMA DE PAGO")

        y = y - 15
        agregaTextoPDF(cb, fuenteArialMT, 8, 0, 25, y, "MEDIO DE PAGO")
        agregaTextoPDF(cb, fuenteArialMT, 8, 0, 110, y, "N° DOCUMENTO")
        agregaTextoPDF(cb, fuenteArialMT, 8, 0, 220, y, "MONTO")

        y = y - 8
        DrawThickLine(cb, 15, y, 280, y, 1)

        y = y - 10

        itemActual = 0

        While itemActual < dtbVwPosDocumentoDetPago.Rows.Count
            filaDatos = dtbVwPosDocumentoDetPago.Rows.Item(itemActual)

            x = 0

            x = x + 25
            'TIPO
            agregaTextoPDF(cb, font2, 8, 0, x, y, filaDatos.Item("dpdp_tipoNombre").ToString())

            x = x + 65
            'DOCUMENTO
            If filaDatos.Item("dpdp_tipo") Is DBNull.Value Then

            ElseIf filaDatos.Item("dpdp_tipo") = 1 Then 'Efectivo
                agregaTextoPDF(cb, font2, 8, 0, x, y, "")

            ElseIf filaDatos.Item("dpdp_tipo") = 2 Then 'Línea de Crédito
                agregaTextoPDF(cb, font2, 8, 0, x, y, "LINEA DE CREDITO")

            ElseIf filaDatos.Item("dpdp_tipo") = 3 Then 'Tarjeta de Crédito
                agregaTextoPDF(cb, font2, 8, 0, x, y, filaDatos.Item("dpdp_numeroOperacion").ToString())

            ElseIf filaDatos.Item("dpdp_tipo") = 4 Then 'Tarjeta de Débito
                agregaTextoPDF(cb, font2, 8, 0, x, y, filaDatos.Item("dpdp_numeroOperacion").ToString())

            ElseIf filaDatos.Item("dpdp_tipo") = 5 Then 'Cheque
                agregaTextoPDF(cb, font2, 8, 0, x, y, filaDatos.Item("dpdp_numeroCheque").ToString())

            ElseIf filaDatos.Item("dpdp_tipo") = 6 Then 'Transferencia
                agregaTextoPDF(cb, font2, 8, 0, x, y, filaDatos.Item("dpdp_detalle").ToString())

            ElseIf filaDatos.Item("dpdp_tipo") = 7 Then 'Anticipo
                agregaTextoPDF(cb, font2, 8, 0, x, y, "DOCUMENTO")

            ElseIf filaDatos.Item("dpdp_tipo") = 8 Then 'Nota de Crédito
                agregaTextoPDF(cb, font2, 8, 0, x, y, filaDatos.Item("dpdp_detalle").ToString())

            ElseIf filaDatos.Item("dpdp_tipo") = 9 Then 'Linea Funcionario
                agregaTextoPDF(cb, font2, 8, 0, x, y, "LINEA FUNCIONARIO")

            ElseIf filaDatos.Item("dpdp_tipo") = 10 Then 'Fondo Fijo
                agregaTextoPDF(cb, font2, 8, 0, x, y, "FONDO FIJO")

            End If

            x = x + 175
            'N° LINEA
            agregaTextoPDF(cb, font2, 8, 2, x, y, String.Format(nbfInfo, "- $ {0:N0}", filaDatos.Item("dpdp_montoPago")))

            totalPagado = totalPagado + filaDatos.Item("dpdp_montoPago")

            y = y - altoFilaDetallePago
            itemActual = itemActual + 1

        End While

        'Total al pie
        y = y - 15

        cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
        agregaTextoPDF(cb, font1, 8, 2, 210, y, "MONTO A PAGAR")
        agregaTextoPDF(cb, font1, 8, 2, 267, y, String.Format(nbfInfo, "$ {0:N0}", totalAPagar))

        y = y - 15

        cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
        agregaTextoPDF(cb, font1, 8, 2, 210, y, "MONTO PAGADO")
        agregaTextoPDF(cb, font1, 8, 2, 267, y, String.Format(nbfInfo, "- $ {0:N0}", totalPagado))

        y = y - 15

        cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
        agregaTextoPDF(cb, font1, 8, 2, 210, y, "TOTAL")
        agregaTextoPDF(cb, font1, 8, 2, 267, y, String.Format(nbfInfo, "$ {0:N0}", totalAPagar - totalPagado))

        'y = y - 12
        'DrawThickLine(cb, 15, y, 280, y, 1)

        y = y - 30

        cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
        agregaTextoPDF(cb, font1, 8, 0, 30, y, "TIMBRE PAGADO ")
        agregaTextoPDF(cb, font1, 8, 0, 200, y, nombreCopia)

        'Propiedades del documento
        documentFINAL.AddTitle("Documento")
        documentFINAL.Close()
        writer.Close()
        FA_reader.Close()

        Dim bytesContenido As Byte() = memoria.ToArray()
        File.WriteAllBytes(nombreArchivoDestino, bytesContenido)

        Return nombreArchivoDestino

    End Function

    Private Shared Sub DrawThickLine(ByVal cb As PdfContentByte, ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal lineWidth As Single)
        cb.SetLineWidth(lineWidth)
        cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK)
        cb.MoveTo(x1, y1)
        cb.LineTo(x2, y2)
        cb.Stroke()
    End Sub

    Public Shared Sub agregaTextoPDF(ByRef cb As iTextSharp.text.pdf.PdfContentByte, ByVal font As iTextSharp.text.pdf.BaseFont, ByVal fontSize As Integer, ByVal align As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal texto As String,
                                     Optional largo As Integer = 999999)
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

    Private Sub DgvNotasVenta_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvNotasVenta.CellPainting
        Dim dgvControl As DataGridView = CType(sender, DataGridView)

        If e.RowIndex > -1 Then

            If e.ColumnIndex = dgvControl.Columns.Item("TipoDocImagen").Index Then
                If dgvControl.Rows.Item(e.RowIndex).Cells.Item("TipoDocOrigen").Value.ToString() = "2" Then 'Tipo de Documento : 1 = Nota de Venta, 2 = Orden de Servicio
                    Dim imgXML As Image = iml_imagenes_grilla.Images(0)
                    e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X, e.CellBounds.Location.Y - 2, 32, 24)
                    e.Handled = True
                Else
                    Dim imgXML As Image = iml_imagenes_grilla.Images(1)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border)
                    e.Handled = True
                End If
            Else

            End If
        End If

    End Sub

    Private Sub DgvNotasVenta_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DgvNotasVenta.DataError
        e.Cancel = True
    End Sub

    Private Sub DgvDocPorPagar_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DgvDocPorPagar.DataError
        e.Cancel = True
    End Sub

    Private Sub chk_anticipo_Click(sender As Object, e As EventArgs) Handles chk_anticipo.Click
        If chk_anticipo.Checked = False Then
            If IsNumeric(txt_idCliente.Text.Trim) = False Then
                MessageBox.Show("Debe ingresar datos del cliente antes de crear un anticipo", "Crear Anticipo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If

            btnPagarDocumentos.Text = "Crear Anticipo"
            btnPagarDocumentos.Enabled = True
            DgvDetalleProductos.Enabled = False
            RadioButton_boleta.Enabled = False
            RadioButton_factura.Enabled = False
            btnFacturar.Enabled = False

            If numeroDocumentoPOS = 0 Then
                dtbSPPosDocumentoCrear = tbaSPPosDocumentoCrear.GetData(1, numeroDocumentoPOS, Now, txt_idCliente.Text.Trim, txt_rutCliente.Text.Trim, Configuracion.IDUsuario, Configuracion.IDTiendaSAP)

                If dtbSPPosDocumentoCrear.Rows.Count > 0 Then
                    numeroDocumentoPOS = dtbSPPosDocumentoCrear.Rows(0).Item("dpc_numero")
                    lblNumeroDocumento.Text = numeroDocumentoPOS.ToString()
                    tbaPosDocumentoCab.ActualizarTipoByID(3, numeroDocumentoPOS) '3 = Anticipo
                End If
            End If

            chk_anticipo.Checked = True
        Else
            Call limpiaDocumento()
            btnPagarDocumentos.Text = "Pagar Documentos"
            btnPagarDocumentos.Enabled = False
            DgvDetalleProductos.Enabled = True

        End If

        Call EstadoBotonesPago()
        Call ActualizarCreditoCliente(txt_rutCliente.Text.Trim, txt_idCliente.Text.Trim, "")
    End Sub

    Private Sub btnAgregarMontoFuncionario_Click(sender As Object, e As EventArgs) Handles btnAgregarMontoFuncionario.Click
        If txt_montoLineaFuncionario.Text <> "" Then
            agregaPago(9, "Linea Funcionario", txt_montoLineaFuncionario.Text, "")
        End If

    End Sub

    Private Function ValidarStockProductos(ByVal idTienda As String) As Boolean
        Dim resultado As Boolean = True
        Dim strCodigo As String = ""
        Dim strListaCodigos As String = ""
        Dim lstCodigos As List(Of String) = New List(Of String)
        Dim str_resultadoJSON As String = ""
        Dim obj_stockArticulosTiendaMasivoModel As StockArticulosTiendaMasivo = Nothing
        Dim obj_sap As class_sap = Nothing

        For Each fila As DataGridViewRow In DgvDetalleProductos.Rows
            strCodigo = fila.Cells("colCodigo").Value.ToString().Trim()

            If codigosExclusionStock.Contains(strCodigo) = False AndAlso tbaVwBTproductoServicio.CuentaByMaterial(strCodigo) = 0 Then
                lstCodigos.Add(strCodigo)
            End If
        Next

        strListaCodigos = String.Join(",", lstCodigos.ToArray())

        Try
            With Global.caja2.My.MySettings.Default
                obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
            End With

            str_resultadoJSON = obj_sap.getStockArticulosTiendaMasivo(strListaCodigos, idTienda)

            If String.IsNullOrEmpty(str_resultadoJSON) = False Then
                obj_stockArticulosTiendaMasivoModel = JsonConvert.DeserializeObject(Of StockArticulosTiendaMasivo)(str_resultadoJSON)

                If Not obj_stockArticulosTiendaMasivoModel Is Nothing Then
                    For Each fila As DataGridViewRow In DgvDetalleProductos.Rows

                        For Each itemStock In obj_stockArticulosTiendaMasivoModel.ET_STOCK_DISP.item
                            If fila.Cells("colCodigo").Value.ToString().Trim() = itemStock.MATERIAL.Trim().Substring(itemStock.MATERIAL.Trim().Length - 6) Then
                                Dim celdaCantidad As DataGridViewCell = DgvDetalleProductos.Rows(fila.Index).Cells(DgvDetalleProductos.Columns.Item("colCantidad").Index)

                                If Convert.ToDouble(fila.Cells("colCantidad").Value) > itemStock.DISPONIBLE.ToDblEng Then
                                    celdaCantidad.ErrorText = "stock insuficiente"
                                    resultado = False
                                Else
                                    celdaCantidad.ErrorText = ""
                                End If

                            End If

                        Next
                    Next

                End If

            End If

        Catch ex As Exception
            Dim mensaje As String = ex.Message

        End Try

        Return resultado
    End Function

    Public Function func_RegistrarEnLogFile(ByVal str_EntradaRegistroLog As String, Optional ByVal str_StackTrace As String = "") As Boolean

        SyncLock obj_logSyncObject
            Dim str_NombreArchivoLog As String = "Caja"
            Dim str_NombreUsuario As String = ""
            Dim AppPath As String = AppDomain.CurrentDomain.BaseDirectory

            Try
                Dim str_EntradaRegistroLogFormateada As String = Format(Now, "yyyy-MM-dd HH:mm:ss") & "[" & Environment.MachineName & "](" & str_NombreUsuario & ") " & str_EntradaRegistroLog & " " & str_StackTrace
                Dim stwFileLog As New StreamWriter(AppPath & "log\" & str_NombreArchivoLog & "_" & Now.ToString("yyyy-MM-dd") & ".log", True)
                stwFileLog.WriteLine(str_EntradaRegistroLogFormateada)
                stwFileLog.Close()
                stwFileLog = Nothing

                Return True
            Catch ex As Exception

                Return False

            End Try
            Return False
        End SyncLock

        Return False
    End Function

    Private Sub rdbPagoSerial_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPagoSerial.CheckedChanged
        lblAutorizacionTarjeta.Visible = False
        txt_AutorizacionTarjeta.Visible = False
        lblTipoTarjeta.Visible = False
        cmbTipoTarjetaCredito.Visible = False
        lblTituloNumeroTarjeta.Visible = False
        txt_NumeroTarjeta.Visible = False
    End Sub

    Private Sub rdbPagoManual_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPagoManual.CheckedChanged
        lblAutorizacionTarjeta.Visible = True
        txt_AutorizacionTarjeta.Visible = True
        lblTipoTarjeta.Visible = True
        cmbTipoTarjetaCredito.Visible = True
        lblTituloNumeroTarjeta.Visible = True
        txt_NumeroTarjeta.Visible = True
    End Sub

    Private Function ActualizarResolucionGarantia(ByVal numeroAvisoGarantia As Integer) As Boolean
        Dim obj_sap As class_sap = Nothing
        Dim obj_resolucionGarantia As ResolucionGarantiaResponseModel = Nothing
        Dim str_resultadoJSON As String = ""
        Dim arr_archivoInforme As Byte() = Nothing

        Try
            With Global.caja2.My.MySettings.Default
                obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
            End With

            str_resultadoJSON = obj_sap.getResolucionGarantia(numeroAvisoGarantia)

            If String.IsNullOrEmpty(str_resultadoJSON) = False Then
                obj_resolucionGarantia = JsonConvert.DeserializeObject(Of ResolucionGarantiaResponseModel)(str_resultadoJSON)

                If Not obj_resolucionGarantia Is Nothing Then

                    arr_archivoInforme = Encoding.UTF8.GetBytes(class_APIDESIS.DecodeBase64ToString(obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.Informe.ToString()))
                    If tbaWebSolicitudGarantiaResolucion.CuentaByID(numeroAvisoGarantia) = 0 Then
                        tbaWebSolicitudGarantiaResolucion.Insert(numeroAvisoGarantia, obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.NroSAP, obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.INrogarantia,
                                                                 obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.Porcgarantia.ToNullableDouble(), obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.Resol,
                                                                 arr_archivoInforme)
                    Else
                        tbaWebSolicitudGarantiaResolucion.Update(obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.NroSAP, obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.INrogarantia,
                                                                 obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.Porcgarantia.ToNullableDouble(), obj_resolucionGarantia.ResolGarantiaSet.ResolGarantia.Resol,
                                                                 arr_archivoInforme, numeroAvisoGarantia)
                    End If

                    Return True
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function

    Private Sub btnControl_EnabledChanged(sender As Object, e As EventArgs) Handles btnFacturar.EnabledChanged, btnPagarDocumentos.EnabledChanged, btnAgregarProducto.EnabledChanged,
                                                                                    btnAgregarMontoCuenta.EnabledChanged, btnRestablecer.EnabledChanged, btnAgregarEfectivo.EnabledChanged

        Dim btnControl As Button = CType(sender, Button)

        If btnControl.Enabled = True Then
            btnControl.BackColor = Color.DarkOrange
        Else
            btnControl.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub btnMedioPago_EnabledChanged(sender As Object, e As EventArgs)

        Dim btnControl As Button = CType(sender, Button)

        btnControl.ForeColor = Color.White
        If btnControl.Enabled = True Then
            btnControl.BackColor = Color.SteelBlue
        Else
            btnControl.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub FrmPrincipalAngosto_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmLogin.Close()
    End Sub

    Private Sub cmbTipoTarjetaCredito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoTarjetaCredito.SelectedIndexChanged
        If cmbTipoTarjetaCredito.SelectedIndex = 2 Then 'Tarjeta de Crédito
            lblNumeroCuotas.Visible = True
            txt_NumeroCuotas.Visible = True

        Else
            lblNumeroCuotas.Visible = False
            txt_NumeroCuotas.Visible = False

        End If
    End Sub

    Private Sub cbx_direcciones_cliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbx_direcciones_cliente.SelectedValueChanged
        Dim drvFila As DataRowView = Nothing

        If Not cbx_direcciones_cliente.SelectedItem Is Nothing Then
            drvFila = cbx_direcciones_cliente.SelectedItem

            cbx_ciudad_cliente.Items.Clear()
            cbx_ciudad_cliente.Items.Add(drvFila.Item("District").ToString().Trim())
            cbx_ciudad_cliente.SelectedIndex = 0

            cbx_comuna_cliente.Items.Clear()
            cbx_comuna_cliente.Items.Add(drvFila.Item("City").ToString().Trim())
            cbx_comuna_cliente.SelectedIndex = 0

        End If

    End Sub

    Private Sub cbx_direcciones_cliente_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cbx_direcciones_cliente.DrawItem
        Dim CmbControl As ComboBox = CType(sender, ComboBox)
        Dim Brush = Brushes.Black
        Dim Point = New Point(2, e.Index * e.Bounds.Height + 1)
        Dim index As Integer = If(e.Index >= 0, e.Index, 0)
        Dim drvFila As DataRowView = Nothing
        Dim texto As String = ""
        Dim str_partner As String = ""
        Dim str_city As String = ""
        Dim str_District As String = ""
        Dim str_street As String = ""

        If CmbControl.Items.Count > 0 Then
            If TypeOf CmbControl.Items(index) Is DataRowView Then
                drvFila = CmbControl.Items(index)
                str_partner = drvFila("partner").ToString().Trim().ToUpper()
                str_city = drvFila("city").ToString().Trim().ToUpper()
                str_District = drvFila("district").ToString().Trim().ToUpper()
                str_street = drvFila("street").ToString().Trim().ToUpper()

                texto = str_District & " / " & str_city & " / " & str_street & " ( " & str_partner & " )"
            Else
                texto = CmbControl.Items(index).ToString()
            End If

            e.Graphics.FillRectangle(New SolidBrush(CmbControl.BackColor), New Rectangle(Point, e.Bounds.Size))
            e.Graphics.DrawString(texto, e.Font, Brush, e.Bounds, StringFormat.GenericDefault)

        ElseIf CmbControl.Items.Count = 0 Then
            e.Graphics.FillRectangle(New SolidBrush(CmbControl.BackColor), New Rectangle(Point, e.Bounds.Size))
            e.Graphics.DrawString("", e.Font, Brush, e.Bounds, StringFormat.GenericDefault)

        End If

    End Sub

    Private Sub cbx_ciudad_cliente_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cbx_ciudad_cliente.DrawItem
        Dim CmbControl As ComboBox = CType(sender, ComboBox)
        Dim Brush = Brushes.Black
        Dim Point = New Point(2, e.Index * e.Bounds.Height + 1)
        Dim index As Integer = If(e.Index >= 0, e.Index, 0)
        Dim drvFila As DataRowView = Nothing
        Dim texto As String = ""
        Dim rectangulo As Size = New Size(e.Bounds.Width, e.Bounds.Height + 2)

        If CmbControl.Items.Count > 0 Then
            If TypeOf CmbControl.Items(index) Is DataRowView Then
                texto = CmbControl.Items(index).ToString()
            Else
                texto = CmbControl.Items(index).ToString()
            End If

            e.Graphics.FillRectangle(New SolidBrush(CmbControl.BackColor), New Rectangle(Point, rectangulo))
            e.Graphics.DrawString(texto, e.Font, Brush, e.Bounds, StringFormat.GenericDefault)

        ElseIf CmbControl.Items.Count = 0 Then
            e.Graphics.FillRectangle(New SolidBrush(CmbControl.BackColor), New Rectangle(Point, e.Bounds.Size))
            e.Graphics.DrawString("", e.Font, Brush, e.Bounds, StringFormat.GenericDefault)

        End If

    End Sub

    Private Sub cbx_comuna_cliente_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cbx_comuna_cliente.DrawItem
        Dim CmbControl As ComboBox = CType(sender, ComboBox)
        Dim Brush = Brushes.Black
        Dim Point = New Point(2, e.Index * e.Bounds.Height + 1)
        Dim index As Integer = If(e.Index >= 0, e.Index, 0)
        Dim drvFila As DataRowView = Nothing
        Dim texto As String = ""
        Dim rectangulo As Size = New Size(e.Bounds.Width, e.Bounds.Height + 2)

        If CmbControl.Items.Count > 0 Then
            If TypeOf CmbControl.Items(index) Is DataRowView Then
                texto = CmbControl.Items(index).ToString()
            Else
                texto = CmbControl.Items(index).ToString()
            End If

            e.Graphics.FillRectangle(New SolidBrush(CmbControl.BackColor), New Rectangle(Point, rectangulo))
            e.Graphics.DrawString(texto, e.Font, Brush, e.Bounds, StringFormat.GenericDefault)

        ElseIf CmbControl.Items.Count = 0 Then
            e.Graphics.FillRectangle(New SolidBrush(CmbControl.BackColor), New Rectangle(Point, e.Bounds.Size))
            e.Graphics.DrawString("", e.Font, Brush, e.Bounds, StringFormat.GenericDefault)

        End If

    End Sub

    Private Sub ActualizarDatosCliente(ByRef dtbVwCliente As DataTable)
        Dim str_tipoEmpresa As String = ""

        str_tipoEmpresa = dtbVwCliente.Rows(0).Item("EmpresaPersonal").ToString().Trim()
        txt_telefono_cliente.Text = dtbVwCliente.Rows(0).Item("Telephone").ToString().Trim()
        txt_email_cliente.Text = dtbVwCliente.Rows(0).Item("EMail").ToString().Trim()
        txt_giro_cliente.Text = dtbVwCliente.Rows(0).Item("Giro").ToString().Trim()
        txt_direccion_cliente.Text = dtbVwCliente.Rows(0).Item("Street").ToString().Trim() & " " & dtbVwCliente.Rows(0).Item("StrSuppl1").ToString().Trim()
        txt_idCliente.Text = dtbVwCliente.Rows(0).Item("Bpartner").ToString().Trim()

        Configuracion.IDCliente = dtbVwCliente.Rows(0).Item("Bpartner").ToString().Trim()

        cbx_ciudad_cliente.Items.Clear()
        cbx_ciudad_cliente.Items.Add(dtbVwCliente.Rows(0).Item("District").ToString().Trim())
        cbx_ciudad_cliente.SelectedIndex = 0

        cbx_comuna_cliente.Items.Clear()
        cbx_comuna_cliente.Items.Add(dtbVwCliente.Rows(0).Item("City").ToString().Trim())
        cbx_comuna_cliente.SelectedIndex = 0

        If str_tipoEmpresa = "1" Then 'persona natural
            txt_nombre_cliente.Text = dtbVwCliente.Rows(0).Item("Name1").ToString().Trim()
            txt_apellido_cliente.Text = dtbVwCliente.Rows(0).Item("Name2").ToString().Trim()

            lblApellidoCliente.Visible = True
            txt_apellido_cliente.Visible = True
            txt_nombre_cliente.Width = 277

        ElseIf str_tipoEmpresa = "2" Then 'empresa
            txt_nombre_cliente.Text = dtbVwCliente.Rows(0).Item("Name1").ToString().Trim() & " " & dtbVwCliente.Rows(0).Item("Name2").ToString().Trim() & " " & dtbVwCliente.Rows(0).Item("Name3").ToString().Trim() & " " &
                                      dtbVwCliente.Rows(0).Item("Name4").ToString().Trim()

            lblApellidoCliente.Visible = False
            txt_apellido_cliente.Visible = False
            txt_nombre_cliente.Width = 560

        Else
            txt_nombre_cliente.Text = dtbVwCliente.Rows(0).Item("Name1").ToString().Trim()
            txt_apellido_cliente.Text = dtbVwCliente.Rows(0).Item("Name2").ToString().Trim()

            lblApellidoCliente.Visible = True
            txt_apellido_cliente.Visible = True
            txt_nombre_cliente.Width = 277

        End If

        dtbVwClienteDireccion = tbaVwClienteDireccion.GetDataByBPartner(dtbVwCliente.Rows(0).Item("Bpartner").ToString().Trim())
        cbx_direcciones_cliente.DisplayMember = "Street"
        cbx_direcciones_cliente.ValueMember = "Partner"
        cbx_direcciones_cliente.DataSource = dtbVwClienteDireccion

    End Sub

    Private Sub NudFecVencimientoCheque_ValueChanged(sender As Object, e As EventArgs) Handles NudFecVencimientoCheque.ValueChanged
        Dim int_variacionValor As Integer = NudFecVencimientoCheque.Value - NudFecVencimientoCheque.Text

        If int_variacionValor < 0 Then
            If DtpFechaVencCheque.MinDate <= DtpFechaVencCheque.Value.AddDays(-1) Then
                DtpFechaVencCheque.Value = DtpFechaVencCheque.Value.AddDays(-1)
            End If

        ElseIf int_variacionValor > 0 Then
            If DtpFechaVencCheque.MaxDate >= DtpFechaVencCheque.Value.AddDays(1) Then
                DtpFechaVencCheque.Value = DtpFechaVencCheque.Value.AddDays(1)
            End If

        End If
        DtpFechaVencCheque.Refresh()
    End Sub

    Private Sub DgvDetallePagos_KeyUp(sender As Object, e As KeyEventArgs) Handles DgvDetallePagos.KeyUp
        If e.KeyCode = Keys.Delete AndAlso Not DgvDetallePagos.CurrentRow Is Nothing Then

            If DgvDetallePagos.CurrentRow.Index >= 0 Then
                Dim corrDetalle As Integer = DgvDetallePagos.CurrentRow.Cells.Item("col_correlativo").Value
                tbaPosDocumentoDetPago.DeleteByNumeroAndCorr(numeroDocumentoPOS, corrDetalle)
                DgvDetallePagos.Rows.Remove(DgvDetallePagos.CurrentRow)
            End If
        End If

    End Sub

    Private Sub DgvNotasCreditoWorkflow_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DgvNotasCreditoWorkflow.DataError
        e.Cancel = True
    End Sub

    Private Sub btnMenuAdmin_Click(sender As Object, e As EventArgs) Handles btnMenuAdmin.Click
        FrmMenuAdmin.Show()
    End Sub

    Public Shared Function validacionRut(ByVal rut As String) As Boolean
        Dim validacion As Boolean = False

        Try
            If rut.Contains("-") = False Then
                Return False
            ElseIf rut.Contains("-") = True AndAlso rut.Count(Function(c As Char) c = "-") > 1 Then
                Return False
            End If

            Dim aRut() As String = Regex.Replace(rut.Trim, "[^0-9Kk-]", "").Split("-")
            Dim NumeroTexto As String = aRut(0)
            Dim Resultado As String = ""
            Dim Multiplicador As Integer = 2
            Dim iNum As Integer = 0
            Dim Suma As Integer = 0

            NumeroTexto = NumeroTexto.PadLeft(8, "0")

            For i As Integer = 8 To 1 Step -1
                If i <= NumeroTexto.Length Then
                    iNum = NumeroTexto.Substring(i - 1, 1)
                    Suma += iNum * Multiplicador
                End If
                Multiplicador += 1
                If Multiplicador = 8 Then
                    Multiplicador = 2
                End If
            Next

            Resultado = CStr(11 - (Suma Mod 11))
            If Resultado = "10" Then Resultado = "K"
            If Resultado = "11" Then Resultado = "0"
            validacion = (aRut(1) = Resultado)

        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try

        Return validacion
    End Function

    Private Function bloquearNotaVenta(ByRef filaNotaVentaCab As web_notaVentaCabRow, ByVal motivoBloqueo As String, ByVal referenciaBloqueo As String) As Boolean
        Dim obj_sap As class_sap = Nothing
        Dim str_postDataJSON As String = ""
        Dim str_resultadoJSON As String = ""
        Dim obj_bloquearNotaVenta As BloquearNotaVentaModel = New BloquearNotaVentaModel
        Dim obj_bloquearNotaVentaRespuesta As BloquearNotaVentaResponseModel
        Dim bol_resultado As Boolean = False

        Try

            With Global.caja2.My.MySettings.Default
                obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
            End With

            If motivoBloqueo.Length > 40 Then
                motivoBloqueo = motivoBloqueo.Substring(0, 40)
            End If

            If referenciaBloqueo.Length > 20 Then
                referenciaBloqueo = referenciaBloqueo.Substring(0, 20)
            End If

            With obj_bloquearNotaVenta
                .Accion = "I"
                .DocVenta = filaNotaVentaCab.nvc_numero.ToString()
                .Sucursal = filaNotaVentaCab.nvc_idTiendaUsuario.ToString()
                .FechaCreacion = filaNotaVentaCab.nvc_fecha.ToString("yyyyMMdd")
                .HoraCreacion = filaNotaVentaCab.nvc_fecha.ToString("HH:mm:ss")
                .UsuarioCreacion = "MV" 'Máscara del Vendedor
                .TipoDoc = "1"
                .ValorNeto = filaNotaVentaCab.nvc_totalNeto.ToString()
                .Moneda = "CLP"
                .Cliente = filaNotaVentaCab.cli_id.ToString()
                .Referencia = referenciaBloqueo
                .OrgVenta = "1000"
                .Canal = IDCanal
                .ClasePedido = ""
                .Motivo = motivoBloqueo
                .Vendedor = tbaUsuario.GetCodUsuarioSAPByID(filaNotaVentaCab.nvc_idUsuario).ToString()
                .MedioPago = filaNotaVentaCab.Item("id_medioPagoSAP").ToString()
            End With

            str_postDataJSON = JsonConvert.SerializeObject(obj_bloquearNotaVenta)
            str_resultadoJSON = obj_sap.postBloquearNotaVenta(str_postDataJSON)

            If String.IsNullOrEmpty(str_resultadoJSON.ToString()) = False Then
                obj_bloquearNotaVentaRespuesta = JsonConvert.DeserializeObject(Of BloquearNotaVentaResponseModel)(str_resultadoJSON)

                If Not obj_bloquearNotaVentaRespuesta Is Nothing AndAlso obj_bloquearNotaVentaRespuesta.Mensaje.Trim = "Registro Guardado Exitosamente" Then
                    bol_resultado = True
                End If

            End If

        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try

        Return bol_resultado
    End Function

    Private Function bloquearOrdenServicio(ByRef filaOrdenServicioCab As BaseTransferencia_sap.ordenServicioRow, ByVal motivoBloqueo As String, ByVal referenciaBloqueo As String) As Boolean
        Dim obj_sap As class_sap = Nothing
        Dim str_postDataJSON As String = ""
        Dim str_resultadoJSON As String = ""
        Dim obj_bloquearNotaVenta As BloquearNotaVentaModel = New BloquearNotaVentaModel
        Dim obj_bloquearNotaVentaRespuesta As BloquearNotaVentaResponseModel
        Dim bol_resultado As Boolean = False

        Try

            With Global.caja2.My.MySettings.Default
                obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
            End With

            If motivoBloqueo.Length > 40 Then
                motivoBloqueo = motivoBloqueo.Substring(0, 40)
            End If

            If referenciaBloqueo.Length > 20 Then
                referenciaBloqueo = referenciaBloqueo.Substring(0, 20)
            End If

            With obj_bloquearNotaVenta
                .Accion = "I"
                .DocVenta = Convert.ToInt32(filaOrdenServicioCab.NroOrden).ToString().Trim()
                .Sucursal = filaOrdenServicioCab.Tienda.ToString().Trim()
                .FechaCreacion = filaOrdenServicioCab.FechaInicio.Trim()
                .HoraCreacion = filaOrdenServicioCab.DateInserted.ToString("HH:mm:ss")
                .UsuarioCreacion = "MV" 'Máscara del Vendedor
                .TipoDoc = "2"
                .ValorNeto = filaOrdenServicioCab.TotalNeto.ToString()
                .Moneda = "CLP"
                .Cliente = filaOrdenServicioCab.NroCliente.ToString().Trim()
                .Referencia = referenciaBloqueo
                .OrgVenta = "1000"
                .Canal = IDCanal
                .ClasePedido = ""
                .Motivo = motivoBloqueo
                .Vendedor = filaOrdenServicioCab.Vendedor.ToString().Trim()
                .MedioPago = "" 'filaOrdenServicioCab.Item("id_medioPagoSAP").ToString()
            End With

            str_postDataJSON = JsonConvert.SerializeObject(obj_bloquearNotaVenta)
            str_resultadoJSON = obj_sap.postBloquearNotaVenta(str_postDataJSON)

            If String.IsNullOrEmpty(str_resultadoJSON.ToString()) = False Then
                obj_bloquearNotaVentaRespuesta = JsonConvert.DeserializeObject(Of BloquearNotaVentaResponseModel)(str_resultadoJSON)

                If Not obj_bloquearNotaVentaRespuesta Is Nothing AndAlso obj_bloquearNotaVentaRespuesta.Mensaje.Trim = "Registro Guardado Exitosamente" Then
                    bol_resultado = True
                End If

            End If

        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try

        Return bol_resultado
    End Function

    Private Function bloquearDocumentoPOS(ByRef filaDocumentoPosCab As pos_documentoCabRow, ByVal motivoBloqueo As String, ByVal referenciaBloqueo As String, ByVal prefijoNumeroDoc As String) As Boolean
        Dim obj_sap As class_sap = Nothing
        Dim str_postDataJSON As String = ""
        Dim str_resultadoJSON As String = ""
        Dim obj_bloquearNotaVenta As BloquearNotaVentaModel = New BloquearNotaVentaModel
        Dim obj_bloquearNotaVentaRespuesta As BloquearNotaVentaResponseModel
        Dim bol_resultado As Boolean = False

        Try

            With Global.caja2.My.MySettings.Default
                obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
            End With

            If motivoBloqueo.Length > 40 Then
                motivoBloqueo = motivoBloqueo.Substring(0, 40)
            End If

            If referenciaBloqueo.Length > 20 Then
                referenciaBloqueo = referenciaBloqueo.Substring(0, 20)
            End If

            With obj_bloquearNotaVenta
                .Accion = "I"
                .DocVenta = prefijoNumeroDoc & filaDocumentoPosCab.dpc_numero.ToString().Trim()
                .Sucursal = filaDocumentoPosCab.dpc_idTiendaUsuario.ToString().Trim()
                .FechaCreacion = filaDocumentoPosCab.dpc_fecha.ToString("yyyyMMdd")
                .HoraCreacion = filaDocumentoPosCab.dpc_fecha.ToString("HH:mm:ss")
                .UsuarioCreacion = "MV" 'Máscara del Vendedor
                .TipoDoc = "3"
                .ValorNeto = "0" 'filaDocumentoPosCab.dpc_totalNeto.ToString()
                .Moneda = "CLP"
                .Cliente = filaDocumentoPosCab.cli_id.ToString().Trim()
                .Referencia = referenciaBloqueo
                .OrgVenta = "1000"
                .Canal = IDCanal
                .ClasePedido = ""
                .Motivo = motivoBloqueo
                .Vendedor = "" 'filaDocumentoPosCab.Vendedor.ToString().Trim()
                .MedioPago = "" 'filaDocumentoPosCab.Item("id_medioPagoSAP").ToString()
            End With

            str_postDataJSON = JsonConvert.SerializeObject(obj_bloquearNotaVenta)
            str_resultadoJSON = obj_sap.postBloquearNotaVenta(str_postDataJSON)

            If String.IsNullOrEmpty(str_resultadoJSON.ToString()) = False Then
                obj_bloquearNotaVentaRespuesta = JsonConvert.DeserializeObject(Of BloquearNotaVentaResponseModel)(str_resultadoJSON)

                If Not obj_bloquearNotaVentaRespuesta Is Nothing AndAlso obj_bloquearNotaVentaRespuesta.Mensaje.Trim = "Registro Guardado Exitosamente" Then
                    bol_resultado = True
                End If

            End If

        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try

        Return bol_resultado
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim str_rutaAplicacion As String = AppDomain.CurrentDomain.BaseDirectory
        Dim str_rutaDescarga As String = str_rutaAplicacion & "pdf\test.pdf"

        'Create PdfDocument object
        Dim doc As Spire.Pdf.PdfDocument = New Spire.Pdf.PdfDocument()
        'Load a PDF file               
        doc.LoadFromFile(str_rutaDescarga)
        'Print with default printer 
        doc.Print()
        doc.Close()
        doc.Dispose()
    End Sub

    Private Function ValidarChequesRechazados() As Boolean

        If IDNotaVenta > 0 OrElse IDOrdenServicio > 0 OrElse numeroDocumentoPOS > 0 Then
            Dim motivoRechazo As String = "Cheque(s) : "
            Dim referenciaRechazo As String = ""
            Dim totalChequesRechazados As Double = 0
            Dim resultadoBloqueo As Boolean = False
            Dim numeroDocLiberado As String = ""
            Dim cuentaChequesRechazados As Integer = 0

            If IDNotaVenta > 0 Then
                numeroDocLiberado = IDNotaVenta.ToString()

            ElseIf IDOrdenServicio > 0 Then
                numeroDocLiberado = IDOrdenServicio.ToString()

            ElseIf numeroDocumentoPOS > 0 Then
                numeroDocLiberado = "A" & numeroDocumentoPOS.ToString()

            End If

            cuentaChequesRechazados = DgvDetallePagos.Rows.Cast(Of DataGridViewRow)().Count(Function(fila) Not String.IsNullOrEmpty(fila.Cells.Item("col_tipoMedioPago").ErrorText))

            If cuentaChequesRechazados > 0 AndAlso tbaNotaVentaAccion.CuentaByNumeroNotaVentaAccionFecha(numeroDocLiberado, "Liberar") = 0 Then
                If MessageBox.Show("Existen " & cuentaChequesRechazados.ToString() & " cheque(s) rechazado(s)" & vbCrLf & "¿ Desea enviarlos a Autorización ?", "Facturar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                    For Each fila As DataGridViewRow In DgvDetallePagos.Rows
                        If Not String.IsNullOrEmpty(fila.Cells.Item("col_tipoMedioPago").ErrorText) Then
                            motivoRechazo &= fila.Cells.Item("col_numCheque").Value & " " & fila.Cells.Item("col_CodigoRechazoOrsan").Value & "|"
                            totalChequesRechazados += fila.Cells.Item("col_monto").Value
                        End If
                    Next

                    referenciaRechazo = cuentaChequesRechazados.ToString() & " cheque(s) " & String.Format(nbfInfo, "$ {0:N0}", totalChequesRechazados)

                    If IDNotaVenta > 0 Then
                        resultadoBloqueo = bloquearNotaVenta(CType(tbaWebNotaVentaCab.GetDataByID(IDNotaVenta).Rows(0), DataSet_catalogo.web_notaVentaCabRow), motivoRechazo, referenciaRechazo)

                    ElseIf IDOrdenServicio > 0 Then
                        resultadoBloqueo = bloquearOrdenServicio(CType(tbaOrdenServicio.GetDataByNroOrden(IDOrdenServicio).Rows(0), BaseTransferencia_sap.ordenServicioRow), motivoRechazo, referenciaRechazo)

                    ElseIf numeroDocumentoPOS > 0 Then
                        resultadoBloqueo = bloquearDocumentoPOS(CType(tbaPosDocumentoCab.GetDataByID(numeroDocumentoPOS).Rows(0), DataSet_catalogo.pos_documentoCabRow), motivoRechazo, referenciaRechazo, "A")

                    Else
                        MessageBox.Show("Cheques NO pudieron ser enviados a autorización" & vbCrLf & "NO existe documento de Origen", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                    If resultadoBloqueo = True Then
                        If IDNotaVenta > 0 Then
                            tbaWebNotaVentaCab.ActualizaEstadoByID(9, IDNotaVenta) ' 9 = Bloqueada

                        ElseIf IDOrdenServicio > 0 Then
                            tbaOrdenServicio.ActualizarEstadoByNroOrden(3, IDOrdenServicio) ' 3 = por autorizar

                        End If

                        tbaPosDocumentoCab.ActualizarEstadoByID(5, numeroDocumentoPOS) ' 5 = por autorizar
                        tbaPosDocumentoDetPago.UpdateByNumero(0, 0, numeroDocumentoPOS) 'eliminamos el documento de los cierres de caja

                        MessageBox.Show("Cheques han sido enviados a autorización" & vbCrLf & "Espere la autorización de la Nota de Venta antes de Facturar nuevamente", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Call limpiaDocumento()
                        Call ActualizarNotasVentaOrdenesServicio()

                    Else
                        MessageBox.Show("Cheques NO pudieron ser enviados a autorización", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Else
                    MessageBox.Show("Debe eliminar los cheques rechazados antes de Facturar", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

                Return False
            End If

        End If

        Return True
    End Function

End Class
