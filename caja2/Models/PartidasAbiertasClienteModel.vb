Public Class PartidasAbiertasClienteModel
    Public Property d As D
End Class

Public Class D
    Public Property results As Result()
End Class

Public Class Result
    Public Property __metadata As __Metadata
    Public Property P_Werks As String
    Public Property P_Kunnr As String
    Public Property P_Budat As String
    Public Property CodEmpresa As String
    Public Property CodCliente As String
    Public Property Ejercicio As String
    Public Property NumDoc As String
    Public Property ClaseDoc As String
    Public Property Folio As String
    Public Property NumCheque As String
    Public Property BancoCheque As String
    Public Property CodOrsan As String
    Public Property NotaVenta As String
    Public Property Rut As String
    Public Property DiasMora As Integer
    Public Property FechaContab As Date
    Public Property FechaDoc As Date
    Public Property FechaVenc As Date
    Public Property TipoCheque As String
    Public Property DescTipoCheque As String
    Public Property Moneda As String
    Public Property Monto As String
    Public Property Bloqueo As String
    Public Property Texto As String
    Public Property RefFact As String
    Public Property Parameters As Parameters
End Class

Public Class __Metadata
    Public Property id As String
    Public Property uri As String
    Public Property type As String
End Class

Public Class Parameters
    Public Property __deferred As __Deferred
End Class

Public Class __Deferred
    Public Property uri As String
End Class

