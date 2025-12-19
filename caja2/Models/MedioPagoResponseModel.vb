
Public Class MedioPagoResponseModel
    Public Property EDocumento As String
    Public Property EtReturn As MedioPagoEtreturn()
End Class

Public Class MedioPagoEtreturn
    Public Property item As String
End Class
