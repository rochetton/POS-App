Public Class class_producto
    Public Property Name As String
    Public Property Price As Integer

    Public ReadOnly Property Row As String()
        Get
            Return New String() {Name, Price.ToString()}
        End Get
    End Property
End Class
