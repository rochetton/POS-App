Public Class FrmDocCliente

    Dim rowsSelection

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call llenarDocumentos()

        DtpFechaInicialDoc.Value = DtpFechaInicialDocPagados.Value.AddDays(-120)
        DtpFechaFinalDoc.Value = DtpFechaFinalDocPagados.Value.AddDays(120)

        DtpFechaInicialDocPagados.Value = DtpFechaInicialDocPagados.Value.AddDays(-120)
        DtpFechaFinalDocPagados.Value = DtpFechaFinalDocPagados.Value.AddDays(90)
        DtpFechaFinalDocPendientes.Value = DtpFechaFinalDocPendientes.Value.AddDays(90)

        cbx_estadoDocumentos.Items.Clear()
        cbx_estadoDocumentos.Items.Add("(Todos)")
        cbx_estadoDocumentos.Items.Add("Pendiente")
        cbx_estadoDocumentos.Items.Add("Pagado")

        cbx_estadoDocumentos.SelectedItem = cbx_estadoDocumentos.Items.Item(0).ToString()

        If TabControl1.TabPages.ContainsKey("TabDocPendientes") = True Then
            TabControl1.TabPages.RemoveByKey("TabDocPendientes")
        End If

        If TabControl1.TabPages.ContainsKey("TabDocPagados") = True Then
            TabControl1.TabPages.RemoveByKey("TabDocPagados")
        End If
    End Sub

    Sub llenarDocumentos()
        Dim totalDoc As Double = 0
        Dim totalDocPendientes As Double = 0
        Dim totalDocPagados As Double = 0

        DgvDocCliente.Rows.Clear()
        DgvDocCliente.Rows.Add("Factura", 400, Now.AddDays(30).ToShortDateString, Now.ToShortDateString, 100000, "Pendiente")
        DgvDocCliente.Rows.Add("Factura", 500, Now.AddDays(60).ToShortDateString, Now.ToShortDateString, 200000, "Pendiente")
        DgvDocCliente.Rows.Add("Factura", 600, Now.AddDays(90).ToShortDateString, Now.ToShortDateString, 300000, "Pendiente")
        DgvDocCliente.Rows.Add("Factura", 100, Now.AddDays(-30).ToShortDateString, Now.ToShortDateString, 100000, "Pagado", "Efectivo")
        DgvDocCliente.Rows.Add("Factura", 200, Now.AddDays(-60).ToShortDateString, Now.ToShortDateString, 200000, "Pagado", "Efectivo")
        DgvDocCliente.Rows.Add("Factura", 300, Now.AddDays(-90).ToShortDateString, Now.ToShortDateString, 300000, "Pagado", "Efectivo")

        DgvDocPendientesCliente.Rows.Clear()
        DgvDocPendientesCliente.Rows.Add("Factura", 400, Now.AddDays(30).ToShortDateString, Now.ToShortDateString, 100000)
        DgvDocPendientesCliente.Rows.Add("Factura", 500, Now.AddDays(60).ToShortDateString, Now.ToShortDateString, 200000)
        DgvDocPendientesCliente.Rows.Add("Factura", 600, Now.AddDays(90).ToShortDateString, Now.ToShortDateString, 300000)

        DgvDocPagadosCliente.Rows.Clear()
        DgvDocPagadosCliente.Rows.Add("Factura", 100, Now.AddDays(-30).ToShortDateString, Now.ToShortDateString, 100000, "Efectivo")
        DgvDocPagadosCliente.Rows.Add("Factura", 200, Now.AddDays(-60).ToShortDateString, Now.ToShortDateString, 200000, "Efectivo")
        DgvDocPagadosCliente.Rows.Add("Factura", 300, Now.AddDays(-90).ToShortDateString, Now.ToShortDateString, 300000, "Efectivo")

        For Each fila As DataGridViewRow In DgvDocCliente.Rows
            totalDoc += Convert.ToDouble(fila.Cells.Item(4).Value)
        Next
        lbl_totalDoc.Text = totalDoc.ToString("$ #,##0")

        For Each fila As DataGridViewRow In DgvDocPendientesCliente.Rows
            totalDocPendientes += Convert.ToDouble(fila.Cells.Item(4).Value)
        Next
        lbl_saldoDocPendientes.Text = totalDocPendientes.ToString("$ #,##0")
        lbl_totalPendientes.Text = totalDocPendientes.ToString("$ #,##0")

        For Each fila As DataGridViewRow In DgvDocPagadosCliente.Rows
            totalDocPagados += Convert.ToDouble(fila.Cells.Item(4).Value)
        Next
        lbl_totalPagados.Text = totalDocPagados.ToString("$ #,##0")

    End Sub

    Private Sub btnVerPendientes_Click(sender As Object, e As EventArgs) Handles btnVerPendientes.Click
        Dim fechaCelda As Date = Nothing

        For Each fila As DataGridViewRow In DgvDocPendientesCliente.Rows
            fechaCelda = Convert.ToDateTime(fila.Cells.Item(2).Value)
            fila.Visible = (fechaCelda >= DtpFechaInicialDocPendientes.Value AndAlso fechaCelda <= DtpFechaFinalDocPendientes.Value)
        Next
    End Sub

    Private Sub btnVerPagados_Click(sender As Object, e As EventArgs) Handles btnVerPagados.Click
        Dim fechaCelda As Date = Nothing

        For Each fila As DataGridViewRow In DgvDocPagadosCliente.Rows
            fechaCelda = Convert.ToDateTime(fila.Cells.Item(2).Value)
            fila.Visible = (fechaCelda >= DtpFechaInicialDocPagados.Value AndAlso fechaCelda <= DtpFechaFinalDocPagados.Value)
        Next
    End Sub

    Private Sub DgvDocPendientesCliente_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvDocPendientesCliente.CellPainting
        Dim dgvControl As DataGridView = CType(sender, DataGridView)

        If e.RowIndex > -1 Then

            If e.ColumnIndex = 9 Then 'Imprimir
                Dim imgXML As Image = iml_botones_columnas.Images(3)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True
            ElseIf e.ColumnIndex = 10 Then 'Enviar por Correo
                Dim imgXML As Image = iml_botones_columnas.Images(4)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DgvDocPagadosCliente_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvDocPagadosCliente.CellPainting
        Dim dgvControl As DataGridView = CType(sender, DataGridView)

        If e.RowIndex > -1 Then

            If e.ColumnIndex = 10 Then 'Imprimir
                Dim imgXML As Image = iml_botones_columnas.Images(3)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True
            ElseIf e.ColumnIndex = 11 Then 'Enviar por Correo
                Dim imgXML As Image = iml_botones_columnas.Images(4)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cbx_estadoDocumentos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_estadoDocumentos.SelectedIndexChanged
        Dim totalDoc As Double = 0

        If cbx_estadoDocumentos.SelectedIndex.ToString() <> "" AndAlso cbx_estadoDocumentos.SelectedItem.ToString().Trim <> "(Todos)" Then

            For Each fila As DataGridViewRow In DgvDocCliente.Rows
                If fila.Cells(5).Value.ToString().Trim().Contains(cbx_estadoDocumentos.SelectedItem.ToString().Trim) Then
                    totalDoc += Convert.ToDouble(fila.Cells.Item(4).Value)
                    fila.Visible = True
                Else
                    fila.Visible = False
                End If
            Next

        Else
            For Each fila As DataGridViewRow In DgvDocCliente.Rows
                totalDoc += Convert.ToDouble(fila.Cells.Item(4).Value)
                fila.Visible = True
            Next

        End If

        lbl_totalDoc.Text = totalDoc.ToString("$ #,##0")
    End Sub

    Private Sub DgvDocCliente_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvDocCliente.CellPainting
        Dim dgvControl As DataGridView = CType(sender, DataGridView)

        If e.RowIndex > -1 Then

            If e.ColumnIndex = 11 Then 'Imprimir
                Dim imgXML As Image = iml_botones_columnas.Images(3)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True
            ElseIf e.ColumnIndex = 12 Then 'Enviar por Correo
                Dim imgXML As Image = iml_botones_columnas.Images(4)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True
            ElseIf e.ColumnIndex = 13 Then 'Crear Nota de Crédito
                Dim imgXML As Image = iml_botones_columnas.Images(5)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.DrawImage(imgXML, e.CellBounds.Location.X + 5, e.CellBounds.Location.Y, 32, 20)
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub DgvDocCliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDocCliente.CellClick
        Dim dgvControl As DataGridView = CType(sender, DataGridView)
        Dim frmNotaCredito As frmNotaCredito = Nothing

        If e.RowIndex > -1 Then
            If e.ColumnIndex = 13 Then 'Crear Nota de Crédito
                frmNotaCredito = New frmNotaCredito
                frmNotaCredito.tipoDocumento = dgvControl.Rows(e.RowIndex).Cells.Item(0).Value.ToString()
                frmNotaCredito.numeroDocumento = dgvControl.Rows(e.RowIndex).Cells.Item(1).Value.ToString()
                frmNotaCredito.totalDocumento = Convert.ToInt32(dgvControl.Rows(e.RowIndex).Cells.Item(4).Value).ToString("$ #,##0")

                frmNotaCredito.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub DgvDocCliente_CellMouseDown(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DgvDocCliente.CellMouseDown
        rowsSelection = New DataGridViewRow(DgvDocCliente.SelectedRows.Count - 1) {}
        DgvDocCliente.SelectedRows.CopyTo(rowsSelection, 0)
    End Sub

    Private Sub DgvDocCliente_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DgvDocCliente.RowHeaderMouseClick
        For Each gr As DataGridViewRow In rowsSelection

            If gr Is DgvDocCliente.CurrentRow Then
                gr.Selected = False
            Else
                gr.Selected = True
            End If
        Next
    End Sub

    Private Sub DgvDocCliente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDocCliente.CellContentClick

    End Sub
End Class