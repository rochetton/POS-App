Imports System.Data.SqlClient

Module Configuracion
    Public str_ConnectionString As String '= "Data Source=54.232.226.45;Initial Catalog=CatalogoCAREN;Persist Security Info=True;User ID=fau_consulting;Password=Fau.03200"
    Public dtbDesisMensajeUsuario As DataTable = Nothing

    Private WithEvents Cnx_BaseDatos As SqlClient.SqlConnection = Nothing
    Private str_message As String = ""
    Private str_stackTrace As String = ""

    Public IDUsuario As Integer = 160694
    Public LoginUsuario As String = "usrVendedor"
    Public NombreUsuario As String = "Vendedor POS"
    Public NombreTiendaUsuario As String = "CD PUERTA NORTE"
    Public idTiendaUsuario As Integer = 0
    Public IDCanal As String = "10"
    Public IDCliente As String = "0000000000"
    Public IDTiendaSAP As String = "CD01"
    Public IDCaja As String = "001"
    Public BPartner As String = "0000000000"
    Public SocSAP As String = "1000"
    Public ciudadCheque As String = "Santiago"
    Public fechaInicioPartidas As Date = New DateTime(2021, 10, 1)
    Public IDTipoUsuario As Integer = 30

    Public Function AbrirConexion() As Boolean
        Dim ssb_Conexion As SqlConnectionStringBuilder = Nothing

        Try
            Cnx_BaseDatos = New SqlClient.SqlConnection()
            Cnx_BaseDatos.ConnectionString = str_ConnectionString
            Cnx_BaseDatos.Open()
        Catch ex As Exception
            str_message = ex.Message
            str_stackTrace = ex.StackTrace
            Return False
        End Try

        Return True
    End Function

    Public Function AbrirConexion(ByVal str_ConnectionString As String) As Boolean
        Dim ssb_Conexion As SqlConnectionStringBuilder = Nothing

        Try
            Cnx_BaseDatos = New SqlClient.SqlConnection()
            Cnx_BaseDatos.ConnectionString = str_ConnectionString
            Cnx_BaseDatos.Open()
        Catch ex As Exception
            str_message = ex.Message
            str_stackTrace = ex.StackTrace
            Return False
        End Try

        Return True
    End Function

    Public Function Conexion() As SqlClient.SqlConnection
        Return Cnx_BaseDatos
    End Function

    Public Function ObtieneConexion(ByVal str_ConnectionString As String) As SqlClient.SqlConnection
        Dim ssb_Conexion As SqlConnectionStringBuilder = Nothing
        Dim obj_conexion As SqlClient.SqlConnection = Nothing

        Try
            obj_conexion = New SqlClient.SqlConnection()
            obj_conexion.ConnectionString = str_ConnectionString
            obj_conexion.Open()
        Catch ex As Exception
            str_message = ex.Message
            str_stackTrace = ex.StackTrace
        End Try

        Return obj_conexion
    End Function

End Module
