
Imports Newtonsoft.Json

Public Class TiendasModel
    Public Property ZVMM_TIENDASType As TiendaModel()
End Class

Public Class TiendaModel
    Public Property DIRECCION As String
    Public Property to_almacen As To_Almacen
    Public Property TIPO As String
    Public Property APERTURA As Date
    Public Property TIENDA As String
    Public Property NAME1 As String
End Class

Public Class To_Almacen
    Public Property ZVMM_ALMACENESType As ALMACEN()
End Class

Public Class ALMACEN
    Public Property TIENDA As String
    Public Property DESCRIPCION As String
    Public Property ALMACEN As String
End Class

Public Class DateJSONConverter
    Inherits Newtonsoft.Json.JsonConverter

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        If value Is Nothing OrElse value.ToString() = "" Then
            writer.WriteValue(Date.MinValue)
        Else
            writer.WriteValue(Convert.ToDateTime(value))
        End If
    End Sub

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        If reader.Value Is Nothing Then
            Return Date.MinValue
        ElseIf reader.Value.ToString() = "" Then
            Return Date.MinValue
        Else
            Return Convert.ToDateTime(reader.Value)
        End If
    End Function

    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Return objectType Is GetType(DateTime)
    End Function

    Public Overrides ReadOnly Property CanRead As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property CanWrite As Boolean
        Get
            Return False
        End Get
    End Property

End Class
