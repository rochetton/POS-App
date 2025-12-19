
Public Class CrearVentaResponseModel
    Public Property Message1 As Message1
    Public Property Message2 As Message2
End Class

Public Class Message1
    Public Property ZWPUBON1Response As Zwpubon1response
End Class

Public Class Zwpubon1response
    Public Property IdocAssign As Idocassign
End Class

Public Class Idocassign
    Public Property TransferId As String
    Public Property DbId As String
End Class

Public Class Message2
    Public Property MediosPagos As Mediospagos
End Class

Public Class Mediospagos
    Public Property EDocumento As String
    Public Property EtReturn As Etreturn
End Class

Public Class Etreturn
    Public Property item As String()
End Class
