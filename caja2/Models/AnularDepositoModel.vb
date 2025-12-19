Public Class AnularDepositoModel

    Public Property Documento As String
    Public Property Fecha As String
    Public Property Sociedad As String

    Public Sub New(documento As String, fecha As String, sociedad As String)
        Me.Documento = documento
        Me.Fecha = fecha
        Me.Sociedad = sociedad
    End Sub
End Class
