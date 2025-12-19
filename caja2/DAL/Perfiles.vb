Partial Class Perfiles
    Partial Public Class sp_validaUsuario3DataTable
        Private Sub sp_validaUsuario3DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.codUsuarioSAPColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class
End Class
