Imports caja2.DataSet_catalogoTableAdapters

Public Class FrmBusqueda

    Dim sp As sp_web_busqueda_generalTableAdapter = New sp_web_busqueda_generalTableAdapter

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Configuracion.AbrirConexion()
        sp.Connection = Configuracion.Conexion
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles Button14.Click

        Dim dtb As DataTable = Nothing

        Dim dato As String = """" & TextBox2.Text & """"

        dtb = sp.GetData(0, 0, dato, Configuracion.IDCliente, Configuracion.IDCanal, Configuracion.IDTiendaSAP, 0)

        DataGridView2.DataSource = dtb

        For Each columna As DataGridViewColumn In DataGridView2.Columns
            If columna.Name = "Código" OrElse columna.Name = "Marca" OrElse columna.Name = "Descripción" OrElse columna.Name = "Precio" Then
                columna.Visible = True
            Else
                columna.Visible = False
            End If
        Next
        'Call DataGridView_CellContentClick(DataGridView2, New DataGridViewCellEventArgs(0, 0))
    End Sub


End Class