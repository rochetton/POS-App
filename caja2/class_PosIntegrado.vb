Imports System.Threading.Tasks
Imports Transbank.POSIntegrado
Imports Transbank.Exceptions.CommonExceptions
Imports Transbank.Exceptions.IntegradoExceptions
Imports Transbank.Responses.CommonResponses
Imports Transbank.Responses.IntegradoResponses

Public Class class_PosIntegrado

    Private portName As String = ""
    Private intermediateMsg As Boolean = False
    Private eventResponseMessage As String = ""

    Public Sub New(ByVal portName As String)
        Me.portName = portName
        AddHandler POSIntegrado.Instance.IntermediateResponseChange, New EventHandler(Of IntermediateResponse)(Sub(s, response) UpdateMessage(s, response))
    End Sub

    Private Sub UpdateMessage(ByVal sender As Object, ByVal response As IntermediateResponse)
        eventResponseMessage = response.ResponseMessage
    End Sub

    Public Function connect() As Boolean
        Try
            POSIntegrado.Instance.OpenPort(portName)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function disconnect() As Boolean
        Try
            POSIntegrado.Instance.ClosePort()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function payment(ByVal ticket As String, ByVal total As Integer, ByVal Optional Msg As Boolean = False) As SaleResponse
        Try
            Dim response As Task(Of SaleResponse) = POSIntegrado.Instance.Sale(total, ticket, intermediateMsg)
            response.Wait()
            Return response.Result

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
