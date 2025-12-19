Public Class FrmLogin

    Dim tbaSPValidaUsuario3 As sp_validaUsuario3TableAdapter = New sp_validaUsuario3TableAdapter
    Dim dtbSPValidaUsuario3 As DataTable = Nothing
    Dim frmInicial As Form = Nothing
    'Dim frmPrincipal As FrmPrincipal = Nothing
    Dim IDSistema As Integer = 9 '9 = Sistema POS Caja
    Dim tbaTienda_ciudad As tienda_ciudadTableAdapter = New tienda_ciudadTableAdapter
    Dim tbaPosAccionUsuario As pos_accionUsuarioTableAdapter = New pos_accionUsuarioTableAdapter
    Dim dtbTienda_ciudad As DataSet_catalogo.tienda_ciudadDataTable = Nothing
    Dim tbaDesisMensajeUsuario As desis_mensajeUsuarioTableAdapter = New desis_mensajeUsuarioTableAdapter

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Application.ApplicationExit, AddressOf OnApplicationExit
        lblVersion.Text = "Versión " & Application.ProductVersion

    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim filaSPValidaUsuario3 As Perfiles.sp_validaUsuario3Row

        Try

            If txt_usuario.Text.Trim <> "" AndAlso txt_clave.Text.Trim <> "" Then
                dtbSPValidaUsuario3 = tbaSPValidaUsuario3.GetData(txt_usuario.Text.Trim, txt_clave.Text, IDSistema)

                If dtbSPValidaUsuario3.Rows.Count = 0 Then
                    dtbSPValidaUsuario3 = tbaSPValidaUsuario3.GetData(txt_usuario.Text.Trim, GlobalToolsNet2.class_AES.AESEncryptStringToBase64(txt_clave.Text.Trim), IDSistema)
                End If

                If dtbSPValidaUsuario3.Rows.Count > 0 Then
                    Me.Hide()

                    filaSPValidaUsuario3 = dtbSPValidaUsuario3.Rows(0)

                    If Screen.PrimaryScreen.WorkingArea.Width > 1440 Then
                        frmInicial = New FrmPrincipal
                    Else
                        frmInicial = New FrmPrincipalAngosto
                    End If

                    frmInicial.Text = "Sistema de Cajas - TIENDA " & dtbSPValidaUsuario3.Rows(0).Item("nombreTienda").ToString() & " (" & dtbSPValidaUsuario3.Rows(0).Item("NomUsuario").ToString() & ")"

                    Configuracion.idTiendaUsuario = dtbSPValidaUsuario3.Rows(0).Item("IDTienda")
                    Configuracion.IDUsuario = dtbSPValidaUsuario3.Rows(0).Item("IDUsuario")
                    Configuracion.LoginUsuario = dtbSPValidaUsuario3.Rows(0).Item("Login").ToString()
                    Configuracion.NombreUsuario = dtbSPValidaUsuario3.Rows(0).Item("NomUsuario").ToString()
                    Configuracion.IDCanal = "10"
                    Configuracion.IDTiendaSAP = dtbSPValidaUsuario3.Rows(0).Item("IDTiendaSAP").ToString()
                    Configuracion.IDCliente = "0000000000"
                    Configuracion.BPartner = dtbSPValidaUsuario3.Rows(0).Item("codUsuarioSAP").ToString()
                    Configuracion.NombreTiendaUsuario = dtbSPValidaUsuario3.Rows(0).Item("nombreTienda").ToString().Trim()
                    Integer.TryParse(filaSPValidaUsuario3.IDUsuarioTipo, Configuracion.IDTipoUsuario)

                    dtbTienda_ciudad = tbaTienda_ciudad.GetDataByID(Configuracion.IDTiendaSAP)

                    If dtbTienda_ciudad.Rows.Count > 0 Then
                        Configuracion.ciudadCheque = dtbTienda_ciudad.Rows(0).Item("tie_ciudadCheque").ToString()
                    End If

                    Configuracion.dtbDesisMensajeUsuario = tbaDesisMensajeUsuario.GetData()

                    If dtbSPValidaUsuario3.Rows(0).Item("IDEstado") Is DBNull.Value OrElse dtbSPValidaUsuario3.Rows(0).Item("IDEstado") = 1 Then ' 1 = Activo
                        tbaPosAccionUsuario.Insert(1, "Abriendo sesión de usuario " & Configuracion.LoginUsuario & " de " & Configuracion.NombreUsuario, Now, Configuracion.IDTiendaSAP, Configuracion.IDUsuario, Nothing)

                        frmInicial.Show()

                    ElseIf dtbSPValidaUsuario3.Rows(0).Item("IDEstado") = 2 Then ' 2 = Bloqueado
                        tbaPosAccionUsuario.Insert(4, "Bloqueo sesión de usuario " & Configuracion.LoginUsuario & " de " & Configuracion.NombreUsuario, Now, Configuracion.IDTiendaSAP, Configuracion.IDUsuario, Nothing)
                        MessageBox.Show("Credenciales bloqueadas", "Ingreso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Else
                    MessageBox.Show("Credenciales incorrectas", "Ingreso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

        Catch Sqlex As SqlClient.SqlException
            MessageBox.Show("Error de Conexión a Base de Datos", "Ingreso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erro de ingreso", "Ingreso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txt_usuario_TextChanged(sender As Object, e As EventArgs) Handles txt_usuario.TextChanged
        Try

            If sender Is txt_usuario AndAlso txt_usuario.Text.Trim.Contains("|") = True Then
                Dim arrCredenciales As String() = txt_usuario.Text.Trim.Split("|")
                txt_usuario.Text = arrCredenciales(0)
                txt_clave.Text = arrCredenciales(1)

            ElseIf sender Is txt_usuario AndAlso txt_usuario.Text.Trim.Contains(vbTab) = True Then
                Dim arrCredenciales As String() = txt_usuario.Text.Trim.Split(vbTab)
                txt_usuario.Text = arrCredenciales(0)
                txt_clave.Text = arrCredenciales(1)

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
        Try
            tbaPosAccionUsuario.Insert(2, "Cerrando sesión de usuario " & Configuracion.LoginUsuario & " de " & Configuracion.NombreUsuario, Now, Configuracion.IDTiendaSAP, Configuracion.IDUsuario, Nothing)
        Catch
        End Try
    End Sub

End Class