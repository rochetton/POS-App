Imports caja2.DataSet_catalogoTableAdapters

Public Class vw_BT_cliente_ProductoPrecioTableAdapterCustom
    Inherits vw_BT_cliente_ProductoPrecioTableAdapter

    Public Shadows Function GetDataByProSKUCliID(ByVal pro_SKU As String, ByVal cli_id As Decimal) As DataTable
        Dim adaptador As Global.System.Data.SqlClient.SqlDataAdapter = New Data.SqlClient.SqlDataAdapter
        Dim tabla As Global.System.Data.DataTable = New Data.DataTable

        For Each Comando As SqlClient.SqlCommand In Me.CommandCollection
            If Comando.Parameters.Contains("@pro_SKU") = True AndAlso Comando.Parameters.Contains("@cli_id") = True AndAlso Comando.Parameters.Count = 2 Then
                For Each Parametro As SqlClient.SqlParameter In Comando.Parameters
                    If Parametro.ParameterName = "@pro_SKU" Then
                        Parametro.Value = CType(pro_SKU, String)
                    ElseIf Parametro.ParameterName = "@cli_id" Then
                        Parametro.Value = CType(cli_id, String)
                    End If
                Next

                adaptador.SelectCommand = Comando
                Exit For
            End If
        Next

        adaptador.Fill(tabla)
        Return tabla

    End Function

End Class

Public Class vw_pos_cierreCaja_detTableAdapterCustom
    Inherits vw_pos_cierreCaja_detTableAdapter

    Dim dataRowErrors As DataRow() = Nothing

    Private ReadOnly Property DataErrorRows() As DataRow()
        Get
            Return Me.dataRowErrors
        End Get
    End Property

    Public Shadows Function GetDataByID(ByVal pcc_ID As Integer) As DataTable
        Dim adaptador As Global.System.Data.SqlClient.SqlDataAdapter = New Data.SqlClient.SqlDataAdapter
        Dim tabla As Global.System.Data.DataTable = New Data.DataTable

        For Each Comando As SqlClient.SqlCommand In Me.CommandCollection
            If Comando.Parameters.Contains("@pcc_ID") = True AndAlso Comando.Parameters.Count = 1 Then
                Try
                    For Each Parametro As SqlClient.SqlParameter In Comando.Parameters
                        If Parametro.ParameterName = "@pcc_ID" Then
                            Parametro.Value = CType(pcc_ID, Integer)
                        End If
                    Next

                    adaptador.SelectCommand = Comando
                    adaptador.Fill(tabla)
                    Exit For

                Catch ex As Exception
                    dataRowErrors = tabla.GetErrors()
                End Try

            End If
        Next

        Return tabla

    End Function

End Class

Public Class vw_pos_notaVenta_ordenServicioTableAdapterCustom
    Inherits vw_pos_notaVenta_ordenServicioTableAdapter

    Dim dataRowErrors As DataRow() = Nothing

    Private ReadOnly Property DataErrorRows() As DataRow()
        Get
            Return Me.dataRowErrors
        End Get
    End Property

    Public Shadows Function GetDataByIdTienda(ByVal idtienda As String) As DataTable
        Dim adaptador As Global.System.Data.SqlClient.SqlDataAdapter = New Data.SqlClient.SqlDataAdapter
        Dim tabla As DataSet_catalogo.vw_pos_notaVenta_ordenServicioDataTable = New DataSet_catalogo.vw_pos_notaVenta_ordenServicioDataTable

        For Each Comando As SqlClient.SqlCommand In Me.CommandCollection
            If Comando.Parameters.Contains("@idtienda") = True AndAlso Comando.Parameters.Count = 1 Then
                Try
                    For Each Parametro As SqlClient.SqlParameter In Comando.Parameters
                        If Parametro.ParameterName = "@idtienda" Then
                            Parametro.Value = CType(idtienda, String)
                        End If
                    Next

                    adaptador.SelectCommand = Comando
                    adaptador.Fill(tabla)
                    Exit For

                Catch ex As Exception
                    dataRowErrors = tabla.GetErrors()
                End Try

            End If
        Next

        Return tabla

    End Function

End Class

'Public Class vw_pos_notaCreditoTableAdapterCustom
'    Inherits vw_pos_notaCreditoTableAdapter

'    Dim dataRowErrors As DataRow() = Nothing

'    Private ReadOnly Property DataErrorRows() As DataRow()
'        Get
'            Return Me.dataRowErrors
'        End Get
'    End Property

'    Public Shadows Function GetDataByIdTiendaUsuarioDevolucion(ByVal idTiendaUsuarioDevolucion As String) As DataTable
'        Dim adaptador As Global.System.Data.SqlClient.SqlDataAdapter = New Data.SqlClient.SqlDataAdapter
'        Dim tabla As DataSet_catalogo.vw_pos_notaCreditoDataTable = New DataSet_catalogo.vw_pos_notaCreditoDataTable

'        For Each Comando As SqlClient.SqlCommand In Me.CommandCollection
'            If Comando.Parameters.Contains("@idTiendaUsuarioDevolucion") = True AndAlso Comando.Parameters.Count = 1 Then
'                Try
'                    For Each Parametro As SqlClient.SqlParameter In Comando.Parameters
'                        If Parametro.ParameterName = "@idTiendaUsuarioDevolucion" Then
'                            Parametro.Value = CType(idTiendaUsuarioDevolucion, String)
'                        End If
'                    Next

'                    adaptador.SelectCommand = Comando
'                    adaptador.Fill(tabla)
'                    Exit For

'                Catch ex As Exception
'                    dataRowErrors = tabla.GetErrors()
'                End Try

'            End If
'        Next

'        Return tabla

'    End Function

'End Class


Public Class vw_pos_notaCredito2TableAdapterCustom
    Inherits vw_pos_notaCredito2TableAdapter

    Dim dataRowErrors As DataRow() = Nothing

    Private ReadOnly Property DataErrorRows() As DataRow()
        Get
            Return Me.dataRowErrors
        End Get
    End Property

    Public Shadows Function GetDataByIdTiendaUsuarioDevolucion(ByVal idTiendaUsuarioDevolucion As String) As DataTable
        Dim adaptador As Global.System.Data.SqlClient.SqlDataAdapter = New Data.SqlClient.SqlDataAdapter
        Dim tabla As DataSet_catalogo.vw_pos_notaCredito2DataTable = New DataSet_catalogo.vw_pos_notaCredito2DataTable

        For Each Comando As SqlClient.SqlCommand In Me.CommandCollection
            If Comando.Parameters.Contains("@idTiendaUsuarioDevolucion") = True AndAlso Comando.Parameters.Count = 1 Then
                Try
                    For Each Parametro As SqlClient.SqlParameter In Comando.Parameters
                        If Parametro.ParameterName = "@idTiendaUsuarioDevolucion" Then
                            Parametro.Value = CType(idTiendaUsuarioDevolucion, String)
                        End If
                    Next

                    adaptador.SelectCommand = Comando
                    adaptador.Fill(tabla)
                    Exit For

                Catch ex As Exception
                    dataRowErrors = tabla.GetErrors()
                End Try

            End If
        Next

        Return tabla

    End Function

End Class