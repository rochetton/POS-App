Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports Transbank.POSIntegrado
Imports Transbank.Exceptions.CommonExceptions
Imports Transbank.Exceptions.IntegradoExceptions
Imports Transbank.Responses.CommonResponses
Imports Transbank.Responses.IntegradoResponses
Imports System.Threading.Tasks

Public Class FrmMenuAdmin

    Private portName As String = ""
    Private total As Integer = 0
    Private intermediateMsg As Boolean = False
    Private eventResponseMessage As String = ""
    Private tituloFormulario As String = ""
    Private codigoPOS As String = ""
    Private puertoAbierto As Boolean = False

    Private Sub FrmMenuAdmin_Load(sender As Object, e As EventArgs) Handles Me.Load
        CenterToScreen()
        tituloFormulario = Me.Text
        PortName_lbl.Text = portName
        Port_ddown.DataSource = POSIntegrado.Instance.ListPorts()
        portName = Port_ddown.SelectedItem.ToString()

        For Each item In Port_ddown.Items
            If item = Global.caja2.My.MySettings.Default.puertoPOSTransbank Then
                Port_ddown.SelectedItem = item
                Exit For
            End If
        Next
        AddHandler POSIntegrado.Instance.IntermediateResponseChange, New EventHandler(Of IntermediateResponse)(Sub(s, response) UpdateMessage(s, response))

    End Sub

    Private Sub PortDropDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Port_ddown.SelectedIndexChanged
        portName = Port_ddown.SelectedItem.ToString()
    End Sub

    Private Sub UpdateMessage(ByVal sender As Object, ByVal response As IntermediateResponse)
        If eventResponseMessage <> response.ResponseMessage Then intermediateMsgTxtBox.Text += $"{response.ResponseMessage}\r\n"
        intermediateMsgTxtBox.SelectionStart = intermediateMsgTxtBox.Text.Length
        intermediateMsgTxtBox.ScrollToCaret()
        Refresh()
        eventResponseMessage = response.ResponseMessage
    End Sub

    Private Sub Connect_btn_Click(sender As Object, e As EventArgs) Handles Connect_btn.Click
        Try
            POSIntegrado.Instance.OpenPort(portName)
            PortName_lbl.Text = portName
            Port_ddown.Enabled = False
            Connect_btn.Enabled = False
            Disconnect_btn.Enabled = True

        Catch a As TransbankException
            codigoPOS = ""
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub Disconnect_btn_Click(sender As Object, e As EventArgs) Handles Disconnect_btn.Click
        Try
            POSIntegrado.Instance.ClosePort()
            PortName_lbl.Text = ""
            Port_ddown.Enabled = True
            Connect_btn.Enabled = True
            Disconnect_btn.Enabled = False

        Catch a As TransbankException
            codigoPOS = ""
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub CargaDeLlavesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargaDeLlavesToolStripMenuItem.Click
        Dim nombreTarea As String = "Carga de llaves."

        Try
            puertoAbierto = POSIntegrado.Instance.IsPortOpen
        Catch ex As NullReferenceException
            MessageBox.Show("Debe conectar un puerto antes de elegir esta opción." & vbCrLf & "Elija un puerto desde la lista y click en Conectar", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Try
            intermediateMsgTxtBox.Text &= "Cargando llaves..." & vbCrLf
            Dim response As Task(Of LoadKeysResponse) = POSIntegrado.Instance.LoadKeys()
            response.Wait()

            If response.Result.Success Then
                codigoPOS = "00"
                intermediateMsgTxtBox.Text &= "Carga de llaves OK. - " & codigoPOS & vbCrLf
                MessageBox.Show("Carga de llaves OK", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                If response.Result.ResponseCode = 2 Then
                    codigoPOS = "02"
                    intermediateMsgTxtBox.Text &= "Host no responde - " & codigoPOS & vbCrLf
                    MessageBox.Show("Host no responde", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

                ElseIf response.Result.ResponseCode = 3 Then
                    codigoPOS = "03"
                    intermediateMsgTxtBox.Text &= "Reintente - Conexión falló - " & codigoPOS & vbCrLf
                    MessageBox.Show("Reintente - Conexión falló", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    codigoPOS = ""
                    intermediateMsgTxtBox.Text &= "Carga de llaves NO pudo ser realizada" & vbCrLf
                    MessageBox.Show("Carga de llaves NO pudo ser realizada", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

            Me.Text = tituloFormulario & " - " & codigoPOS
        Catch a As TransbankException
            codigoPOS = ""
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub CierreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CierreToolStripMenuItem.Click
        Dim nombreTarea As String = "Cierre."

        Try
            puertoAbierto = POSIntegrado.Instance.IsPortOpen
        Catch ex As NullReferenceException
            MessageBox.Show("Debe conectar un puerto antes de elegir esta opción." & vbCrLf & "Elija un puerto desde la lista y click en Conectar", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Try
            intermediateMsgTxtBox.Text &= "Ejecutando cierre..." & vbCrLf
            Dim response As Task(Of CloseResponse) = POSIntegrado.Instance.Close()
            response.Wait()

            If response.Result.Success Then
                codigoPOS = "00"
                intermediateMsgTxtBox.Text &= "Cierre OK - " & codigoPOS & vbCrLf
                MessageBox.Show("Cierre OK", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                codigoPOS = "03"
                intermediateMsgTxtBox.Text &= "Reintente - Conexión falló " & codigoPOS & vbCrLf
                MessageBox.Show("Reintente - Conexión falló", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch a As TransbankException
            codigoPOS = ""
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub AnularVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularVentaToolStripMenuItem.Click
        Dim nombreTarea As String = "Anular Venta"
        Dim respuesta As String = ""
        Dim op As Integer = 0

        Try
            puertoAbierto = POSIntegrado.Instance.IsPortOpen
        Catch ex As NullReferenceException
            MessageBox.Show("Debe conectar un puerto antes de elegir esta opción." & vbCrLf & "Elija un puerto desde la lista y click en Conectar", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Try
            respuesta = InputBox("Ingrese Número de Operación", "Anular Venta", "")

            If IsNumeric(respuesta) = True Then
                op = Convert.ToInt32(respuesta)

                intermediateMsgTxtBox.Text &= "Anulando venta número de operación " & respuesta & "..." & vbCrLf
                Dim response As Task(Of RefundResponse) = POSIntegrado.Instance.Refund(op)
                response.Wait()

                If response.Result.Success Then
                    codigoPOS = ""
                    intermediateMsgTxtBox.Text &= "Anulación de venta número de operación " & respuesta & " realizada correctamente" & vbCrLf
                    MessageBox.Show("Anulación de venta número de operación " & respuesta & " realizada correctamente", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    If response.Result.ResponseCode = 5 Then
                        codigoPOS = "05"
                        intermediateMsgTxtBox.Text &= "No Existe Transacción para Anular - " & codigoPOS & vbCrLf
                        MessageBox.Show("No Existe Transacción para Anular", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ElseIf response.Result.ResponseCode = 21 Then
                        codigoPOS = "20"
                        intermediateMsgTxtBox.Text &= "No puede anular transacción de debito - " & codigoPOS & vbCrLf
                        MessageBox.Show("No puede anular transacción de debito", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End If
            Else
                MessageBox.Show("Número de Operación debe ser numérico", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        Catch ex As TransbankException
            codigoPOS = ""
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub CambioAModoNormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambioAModoNormalToolStripMenuItem.Click
        Dim nombreTarea As String = "Cambio Modo"

        Try
            Try
                puertoAbierto = POSIntegrado.Instance.IsPortOpen
            Catch ex As NullReferenceException
                MessageBox.Show("Debe conectar un puerto antes de elegir esta opción." & vbCrLf & "Elija un puerto desde la lista y click en Conectar", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

            Dim dialogResult As DialogResult = MessageBox.Show("Cambiar a Modo Normal desconectará el POS" & vbLf & " ¿ está seguro ?", "Cambiar a Modo Normal", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

            If dialogResult = DialogResult.Yes Then
                Dim result As Task(Of Boolean) = Task.Run(Async Function() Await POSIntegrado.Instance.SetNormalMode())
                result.Wait()

                If result.Result Then
                    MessageBox.Show("Cambio Modo Normal OK", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Falla al configurar el POS en modo Normal", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If

        Catch a As TransbankException
            codigoPOS = ""
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnLimpiarLog_Click(sender As Object, e As EventArgs) Handles btnLimpiarLog.Click
        intermediateMsgTxtBox.Text = ""
    End Sub

    Private Sub DetalleDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleDeVentasToolStripMenuItem.Click
        Dim nombreTarea As String = "Detalle de Ventas"

        Try
            puertoAbierto = POSIntegrado.Instance.IsPortOpen
        Catch ex As NullReferenceException
            MessageBox.Show("Debe conectar un puerto antes de elegir esta opción." & vbCrLf & "Elija un puerto desde la lista y click en Conectar", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Try
            intermediateMsgTxtBox.Text &= "Obteniendo detalle de Ventas..." & vbCrLf
            Dim details As Task(Of List(Of DetailResponse)) = POSIntegrado.Instance.Details(False) ' False = sin imprimir para obtener el detalle de las ventas y la cuenta
            details.Wait()

            For Each detail As DetailResponse In details.Result
                intermediateMsgTxtBox.Text &= "Tipo de Tarjeta : " & detail.CardType.ToString() & " Total : " + detail.Amount.ToString() & vbCrLf
            Next

            If details.Result.Count > 0 Then
                codigoPOS = "00"
                intermediateMsgTxtBox.Text &= "Cierre OK - " & codigoPOS & vbCrLf
                MessageBox.Show(nombreTarea & " OK", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                codigoPOS = "11"
                intermediateMsgTxtBox.Text &= "Error en " & nombreTarea & " - " & codigoPOS & vbCrLf
                MessageBox.Show("Error en " & nombreTarea, nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            details = POSIntegrado.Instance.Details(True) ' True = imprimir el voucher en el POS
            details.Wait()

        Catch a As TransbankException
            codigoPOS = ""
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub TotalDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalDeVentasToolStripMenuItem.Click
        Dim nombreTarea As String = "Total de Ventas"

        Try
            puertoAbierto = POSIntegrado.Instance.IsPortOpen
        Catch ex As NullReferenceException
            MessageBox.Show("Debe conectar un puerto antes de elegir esta opción." & vbCrLf & "Elija un puerto desde la lista y click en Conectar", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Try
            intermediateMsgTxtBox.Text &= "Obteniendo " & nombreTarea & "..." & vbCrLf
            Dim response As Task(Of TotalsResponse) = POSIntegrado.Instance.Totals()
            response.Wait()

            If response.Result.Success = True Then
                codigoPOS = "00"
                intermediateMsgTxtBox.Text &= nombreTarea & " OK - " & codigoPOS & vbCrLf
                MessageBox.Show(nombreTarea & " OK", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                codigoPOS = "11"
                intermediateMsgTxtBox.Text &= "Totales NO pudieron ser obtenidos - " & codigoPOS & vbCrLf
                MessageBox.Show(nombreTarea & " NO pudieron ser obtenidos", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch a As TransbankException
            codigoPOS = ""
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub ÚltimaVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÚltimaVentaToolStripMenuItem.Click
        Dim nombreTarea As String = "Última Venta"

        Try
            puertoAbierto = POSIntegrado.Instance.IsPortOpen
        Catch ex As NullReferenceException
            MessageBox.Show("Debe conectar un puerto antes de elegir esta opción." & vbCrLf & "Elija un puerto desde la lista y click en Conectar", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Try
            intermediateMsgTxtBox.Text &= "Obteniendo " & nombreTarea & "..." & vbCrLf
            Dim response As Task(Of LastSaleResponse) = POSIntegrado.Instance.LastSale()
            response.Wait()

            If response.Result.Success = True Then
                codigoPOS = "00"
                intermediateMsgTxtBox.Text &= "Impresión de última venta OK - " & codigoPOS & vbCrLf
                MessageBox.Show("Impresión de última venta OK", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                codigoPOS = "11"
                intermediateMsgTxtBox.Text &= "última venta NO pudo ser obtenida - " & codigoPOS & vbCrLf
                MessageBox.Show("última venta NO pudo ser obtenida", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch a As TransbankException
            codigoPOS = ""
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub PollingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PollingToolStripMenuItem.Click
        Dim nombreTarea As String = "Polling"

        Try
            puertoAbierto = POSIntegrado.Instance.IsPortOpen
        Catch ex As NullReferenceException
            MessageBox.Show("Debe conectar un puerto antes de elegir esta opción." & vbCrLf & "Elija un puerto desde la lista y click en Conectar", nombreTarea, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Try
            intermediateMsgTxtBox.Text &= nombreTarea & vbCrLf
            Dim response As Task(Of Boolean) = Task.Run(Async Function() Await POSIntegrado.Instance.Poll())
            response.Wait()

            If response.Result = True Then
                codigoPOS = "ACK"
                intermediateMsgTxtBox.Text &= nombreTarea & " OK - " & codigoPOS & vbCrLf
                MessageBox.Show("Polling OK", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                codigoPOS = "11"
                intermediateMsgTxtBox.Text &= nombreTarea & " NO pudo ser ejecutado - " & codigoPOS & vbCrLf
                MessageBox.Show("Problema de conexión con POS", nombreTarea & " - " & codigoPOS, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ae As AggregateException
            codigoPOS = ""
            MessageBox.Show("Problema de conexión con POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])

        Catch tex As TransbankException
            codigoPOS = ""
            MessageBox.Show(tex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class