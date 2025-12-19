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
Imports Transbank.Responses.CommonResponses

Public Class RefundPrompt

    Private Sub RefundPrompt_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub close_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub accept_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim op As Integer = Convert.ToInt32(opInputText.Text)

        Try
            Dim response As Task(Of RefundResponse) = POSIntegrado.Instance.Refund(op)
            response.Wait()

            If response.Result.Success Then
                MessageBox.Show(response.ToString(), "Refund Success.")
                Me.Close()
            End If

        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

End Class