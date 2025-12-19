Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Imports Transbank.POSIntegrado
Imports Transbank.Exceptions.CommonExceptions
Imports Transbank.Responses.IntegradoResponses


Public Class DetailPrompt

    Private Sub DetailPrompt_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub printToPOS_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim details As Task(Of List(Of DetailResponse)) = POSIntegrado.Instance.Details(True)
            details.Wait()
            MessageBox.Show("Impreso en POS", "Resultado Detalle de venta.")
            Me.Close()
        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub noPrintBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim response As String = ""
            Dim details As Task(Of List(Of DetailResponse)) = POSIntegrado.Instance.Details(False)
            details.Wait()

            For Each detail As DetailResponse In details.Result
                response += "Tipo de Tarjeta : " & detail.CardType & " Total : " + detail.Amount & vbLf
            Next

            MessageBox.Show(response, "Resultado Detalle de venta.")
            Me.Close()
        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class