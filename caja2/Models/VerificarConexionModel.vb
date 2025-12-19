Public Class VerificarConexionModel

    Public Property d As DModel

    Public Class DModel
        Public Property results As Result()
    End Class

    Public Class Result
        Public Property __metadata As __Metadata
        Public Property bname As String
        Public Property Conn As String
    End Class

    Public Class __Metadata
        Public Property id As String
        Public Property uri As String
        Public Property type As String
    End Class

End Class
