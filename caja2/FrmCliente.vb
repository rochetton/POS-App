Imports Newtonsoft.Json

Public Class FrmCliente

    Dim frmPrincipal As FrmPrincipal = Nothing
    Dim tbaWebCiudad As web_ciudadTableAdapter = New web_ciudadTableAdapter
    Dim tbaWebComuna As web_comunaTableAdapter = New web_comunaTableAdapter
    Dim tbaCliente As clienteTableAdapter = New clienteTableAdapter
    Dim tbaClienteContacto As cliente_contactoTableAdapter = New cliente_contactoTableAdapter
    Dim tbaClienteDatosCom As cliente_datosComTableAdapter = New cliente_datosComTableAdapter
    Dim tbaClienteDirecccion As cliente_direccionTableAdapter = New cliente_direccionTableAdapter
    Dim tbaVwLocalidad As vw_localidadTableAdapter = New vw_localidadTableAdapter
    Dim tbaVwCliente As vw_clienteTableAdapter = New vw_clienteTableAdapter

    Dim dtbCliente As DataTable = Nothing
    Dim dtbClienteContacto As DataTable = Nothing
    Dim dtbClienteDatosCom As DataTable = Nothing
    Dim dtbClienteDirecccion As DataTable = Nothing
    Dim dtbVwLocalidad As DataTable = Nothing
    Dim dtbVwCliente As DataTable = Nothing

    Public BPartner As String = ""
    Dim bol_nuevoCliente As Boolean = False

    Private Sub FrmCliente_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Public Sub IniciarControles()

        'frmPrincipal = Me.Owner

        'If bol_nuevoCliente = True Then
        '    rdbPersona.Checked = True
        'Else
        '    rdbPersona.Enabled = False
        '    rdbEmpresa.Enabled = False
        'End If

        cbx_ciudad_cliente.DisplayMember = "ciudad_nombre"
        cbx_ciudad_cliente.ValueMember = "ciudad_id"
        cbx_ciudad_cliente.DataSource = tbaWebCiudad.GetData()

        cbx_comuna_cliente.DisplayMember = "comuna_nombre"
        cbx_comuna_cliente.ValueMember = "comuna_id"
        cbx_comuna_cliente.DataSource = tbaWebComuna.GetDataByIdCiudad(cbx_ciudad_cliente.SelectedValue)

        cbx_ciudad_direccion.DisplayMember = "ciudad_nombre"
        cbx_ciudad_direccion.ValueMember = "ciudad_id"
        cbx_ciudad_direccion.DataSource = tbaWebCiudad.GetData()

        cbx_comuna_direccion.DisplayMember = "comuna_nombre"
        cbx_comuna_direccion.ValueMember = "comuna_id"
        cbx_comuna_direccion.DataSource = tbaWebComuna.GetDataByIdCiudad(cbx_ciudad_cliente.SelectedValue)

    End Sub

    Private Sub btnAgregarDireccion_Click(sender As Object, e As EventArgs) Handles btnAgregarDireccion.Click
        Dim drvFila As DataRowView = CType(cbx_ciudad_direccion.SelectedItem, DataRowView)
        Dim codigoLocalidad As String = cbx_comuna_direccion.SelectedValue.ToString()

        codigoLocalidad = New String("0", 4 - codigoLocalidad.Trim.Length) & codigoLocalidad.Trim

        DgvDireccionesCliente.Rows.Add("", cbx_ciudad_direccion.SelectedValue, drvFila.Item("ciudad_nombre"), cbx_comuna_direccion.SelectedValue,
                                       CType(cbx_comuna_direccion.SelectedItem, DataRowView).Item("comuna_nombre"), txt_direccion_direccion.Text.Trim, txt_telefono_direccion.Text, txt_celular_direccion.Text.Trim, txt_email_direccion.Text.Trim,
                                       codigoLocalidad, drvFila.Item("abrev_region"))
        Call LimpiarControlesDireccion()
    End Sub

    Private Sub LimpiarControles()
        txt_nombre_cliente.Text = ""
        txt_apellido_cliente.Text = ""
        cbx_ciudad_cliente.DataSource = tbaWebCiudad.GetData()
        cbx_comuna_cliente.DataSource = tbaWebComuna.GetDataByIdCiudad(cbx_ciudad_cliente.SelectedValue)
        txt_direccion_cliente.Text = ""
        txt_telefono_fijo_cliente.Text = ""
        txt_celular_cliente.Text = ""
        txt_email_cliente.Text = ""
    End Sub

    Private Sub LimpiarControlesDireccion()
        txt_celular_direccion.Text = ""
        txt_direccion_direccion.Text = ""
        txt_email_direccion.Text = ""
        txt_telefono_direccion.Text = ""
        cbx_ciudad_direccion.DataSource = tbaWebCiudad.GetData()
        cbx_comuna_direccion.DataSource = tbaWebComuna.GetDataByIdCiudad(cbx_ciudad_direccion.SelectedValue)
    End Sub

    Private Sub btnGrabarCliente_Click(sender As Object, e As EventArgs) Handles btnGrabarCliente.Click
        Dim obj_cliente As ClienteModel = Nothing
        Dim LstClienteContacto As List(Of Personascontacto) = New List(Of Personascontacto)
        Dim LstClienteDatosCom As List(Of Datoscomerciales) = New List(Of Datoscomerciales)
        Dim LstClienteDireccion As List(Of Diralternativa) = New List(Of Diralternativa)
        Dim obj_clienteContacto As Personascontacto = Nothing
        Dim obj_clienteDatosCom As Datoscomerciales = Nothing
        Dim obj_clienteDireccion As Diralternativa = Nothing
        Dim filaCliente As DataRow = Nothing
        Dim filaClienteContacto As DataRow = Nothing
        Dim filaClienteCom As DataRow = Nothing
        Dim filaClienteDir As DataRow = Nothing
        Dim codigoLocalidad As String
        Dim nombre1 As String = ""
        Dim nombre2 As String = ""
        Dim apellido1 As String = ""
        Dim apellido2 As String = ""
        Dim empresaPersonal As String = ""
        Dim titleKey As String = ""
        Dim grupoCliente As String = ""
        Dim conOrdenCompra As String = ""
        Dim localidad As String = ""
        Dim comuna As String = ""
        Dim ciudad As String = ""
        Dim zonaTransportes As String = ""
        Dim abreviaturaRegion As String = "RM"
        Dim tipoIdentificacion As String = "CL1"
        Dim pais As String = "CL"
        Dim bol_nuevoCliente As Boolean = False
        Dim accionCliente As String = ""
        Dim bpartner As String = ""
        Dim dateUpdatedInicial As Date = Nothing
        Dim dateUpdatedFinal As Date = Nothing

        Try

            If ValidarControles() = True Then
                codigoLocalidad = cbx_comuna_cliente.SelectedValue.ToString()
                codigoLocalidad = New String("0", 4 - codigoLocalidad.Trim.Length) & codigoLocalidad.Trim

                nombre1 = txt_nombre_cliente.Text.Trim
                nombre2 = txt_apellido_cliente.Text.Trim

                If rdbPersona.Checked = True Then
                    empresaPersonal = "1"
                    titleKey = "0005"

                    If nombre1.Length > 40 Then
                        nombre1 = nombre1.Substring(0, 40)
                    End If

                    If nombre2.Length > 40 Then
                        nombre2 = nombre2.Substring(0, 40)
                    End If

                ElseIf rdbEmpresa.Checked = True Then
                    empresaPersonal = "2"
                    titleKey = "0003"

                    If nombre1.Length <= 40 Then
                        nombre1 = nombre1.Substring(0)

                    ElseIf nombre1.Length < 80 Then
                        nombre2 = nombre1.Substring(40)
                        nombre1 = nombre1.Substring(0, 40)

                    ElseIf nombre1.Length < 120 Then
                        apellido1 = nombre1.Substring(80)
                        nombre2 = nombre1.Substring(40, 40)
                        nombre1 = nombre1.Substring(0, 40)

                    ElseIf nombre1.Length < 160 Then
                        apellido2 = nombre1.Substring(120, 40)
                        apellido1 = nombre1.Substring(80, 40)
                        nombre2 = nombre1.Substring(40, 40)
                        nombre1 = nombre1.Substring(0, 40)
                    End If
                End If

                If ChkOrdenCompra.Checked = True Then
                    conOrdenCompra = "X"
                Else
                    conOrdenCompra = ""
                End If

                If tbaCliente.CuentaByTaxNumber(txt_rutCliente.Text.Trim) = 0 Then  'nuevo cliente
                    bol_nuevoCliente = True
                    accionCliente = "I"

                Else 'cliente existente
                    accionCliente = "U"
                    bpartner = txt_idCliente.Text.Trim
                End If

                'obj_cliente = New ClienteModel("U", filaCliente.Item("Bpartner").ToString().Trim(), filaCliente.Item("City").ToString().Trim(), filaCliente.Item("Country").ToString().Trim(), filaCliente.Item("District").ToString().Trim(),
                '                               filaCliente.Item("EmpresaPersonal").ToString().Trim(), filaCliente.Item("EMail").ToString().Trim(), filaCliente.Item("Giro").ToString().Trim(), filaCliente.Item("GroupClient").ToString().Trim(),
                '                               filaCliente.Item("ConOrdenCompra").ToString().Trim(), filaCliente.Item("Name1").ToString().Trim(), filaCliente.Item("Name2").ToString().Trim(), filaCliente.Item("Name3").ToString().Trim(),
                '                               filaCliente.Item("Name4").ToString().Trim(), filaCliente.Item("Region").ToString().Trim(), filaCliente.Item("Street").ToString().Trim(), filaCliente.Item("StrSuppl1").ToString().Trim(),
                '                               filaCliente.Item("TaxNumber").ToString().Trim(), filaCliente.Item("Telephone").ToString().Trim(), filaCliente.Item("TelMovil").ToString().Trim(), filaCliente.Item("TitleKey").ToString().Trim(),
                '                               filaCliente.Item("CargoEmpleado").ToString().Trim(), filaCliente.Item("DescCargoEmpleado").ToString().Trim(), filaCliente.Item("ListaPrecio").ToString().Trim(),
                '                               filaCliente.Item("Localidad").ToString().Trim(), filaCliente.Item("ZonaTransporte").ToString().Trim(), filaCliente.Item("Sociedad").ToString().Trim(),
                '                               filaCliente.Item("AgruInterComercial").ToString().Trim(), filaCliente.Item("GrupoCuenta").ToString().Trim(), filaCliente.Item("Idioma").ToString().Trim(), filaCliente.Item("HusoHorario").ToString().Trim(),
                '                               filaCliente.Item("TipoIdentificacion").ToString().Trim(), filaCliente.Item("ProcReclamacion").ToString().Trim(), filaCliente.Item("Cuenta").ToString().Trim(),
                '                               filaCliente.Item("GrupoTesoreria").ToString().Trim(), filaCliente.Item("IndIntereses").ToString().Trim(), filaCliente.Item("ClasificacionFiscal").ToString().Trim(), Nothing, Nothing, Nothing)

                'dtbClienteContacto = tbaClienteContacto.GetDataByBPartner(BPartner)
                'If dtbClienteContacto.Rows.Count > 0 Then
                '    filaClienteContacto = dtbClienteContacto.Rows(0)
                '    obj_clienteContacto = New Personascontacto(filaClienteContacto.Item("PCPartner").ToString().Trim(), filaClienteContacto.Item("CodFuncion").ToString().Trim(), filaClienteContacto.Item("Funcion").ToString().Trim(), filaClienteContacto.Item("NombrePC").ToString().Trim(), filaClienteContacto.Item("ApellidoPC").ToString().Trim(), filaClienteContacto.Item("CityPC").ToString().Trim(),
                '                                               filaClienteContacto.Item("DistrictPC").ToString().Trim(), filaClienteContacto.Item("StreetPC").ToString().Trim(), filaClienteContacto.Item("HouseNum1PC").ToString().Trim(), filaClienteContacto.Item("CountryPC").ToString().Trim(), filaClienteContacto.Item("TelephonePC").ToString().Trim(), filaClienteContacto.Item("TelMovilPC").ToString().Trim(),
                '                                               filaClienteContacto.Item("EMailPC").ToString().Trim())
                '    LstClienteContacto.Add(obj_clienteContacto)
                'End If

                'dtbClienteDatosCom = tbaClienteDatosCom.GetDataByBPartner(BPartner)
                'If dtbClienteDatosCom.Rows.Count > 0 Then
                '    filaClienteCom = dtbClienteDatosCom.Rows(0)
                '    obj_clienteDatosCom = New Datoscomerciales(filaClienteCom.Item("OrgVentas").ToString().Trim(), filaClienteCom.Item("Canal").ToString().Trim(), filaClienteCom.Item("Sector").ToString().Trim(), filaClienteCom.Item("ZonaVentas").ToString().Trim(), filaClienteCom.Item("OficVentas").ToString().Trim(), filaClienteCom.Item("GrupoVendedores").ToString().Trim(),
                '                                               filaClienteCom.Item("Moneda").ToString().Trim(), filaClienteCom.Item("EsquemaCliente").ToString().Trim(), filaClienteCom.Item("GrupoEstadCliente").ToString().Trim(), filaClienteCom.Item("PrioEntrega").ToString().Trim(), filaClienteCom.Item("CondExpedicion").ToString().Trim(),
                '                                               filaClienteCom.Item("CondPago").ToString().Trim(), filaClienteCom.Item("GrupoImpuCliente").ToString().Trim())
                '    LstClienteDatosCom.Add(obj_clienteDatosCom)
                'End If

                'dtbClienteDirecccion = tbaClienteDirecccion.GetDataByBPartner(BPartner)
                'If dtbClienteDirecccion.Rows.Count > 0 Then
                '    filaClienteDir = dtbClienteDirecccion.Rows(0)
                '    obj_clienteDireccion = New Diralternativa(filaClienteDir.Item("Partner").ToString().Trim(), filaClienteDir.Item("City").ToString().Trim(), filaClienteDir.Item("Localidad").ToString().Trim(), filaClienteDir.Item("District").ToString().Trim(), filaClienteDir.Item("Street").ToString().Trim(), filaClienteDir.Item("StrSuppl1").ToString().Trim(),
                '                                              filaClienteDir.Item("Country").ToString().Trim(), filaClienteDir.Item("Region").ToString().Trim(), filaClienteDir.Item("Telephone").ToString().Trim(), filaClienteDir.Item("TelMovil").ToString().Trim(), filaClienteDir.Item("EMail").ToString().Trim())
                '    LstClienteDireccion.Add(obj_clienteDireccion)
                'End If

                'If tbaVwClienteDireccion.CuentaByBPartnerLocalidadStreet(filaCliente.Item("Bpartner").ToString().Trim(), codigoLocalidad, txt_calleDespacho.Text.Trim) = 0 Then 'NO existe localidad para el BPartner
                '    If filaCliente.Item("Localidad") Is DBNull.Value OrElse filaCliente.Item("Localidad").ToString().Trim() = "" Then
                '        obj_cliente.Localidad = codigoLocalidad
                '        obj_cliente.Street = txt_calleDespacho.Text.Trim
                '        bol_localidadVacia = True

                '    ElseIf filaCliente.Item("Localidad").ToString().Trim() = codigoLocalidad.Trim() AndAlso filaCliente.Item("Street").ToString().Trim() = txt_calleDespacho.Text.Trim Then
                '        Return BPartner

                '    Else
                '        dtbVwLocalidad = tbaVwLocalidad.GetDataByID(Convert.ToInt32(codigoLocalidad))

                '        If dtbVwLocalidad.Rows.Count > 0 Then
                '            obj_clienteDireccion = New Diralternativa("", dtbVwLocalidad.Rows(0).Item("comuna2").ToString().ToUpper(), codigoLocalidad, dtbVwLocalidad.Rows(0).Item("equiv_ciudad").ToString().ToUpper(), txt_calleDespacho.Text.Trim, "",
                '                                                      "CL", dtbVwLocalidad.Rows(0).Item("abrev_region").ToString().ToUpper(), "", "", "")
                '            bol_nuevaDireccion = True
                '            LstClienteDireccion.Clear()
                '            LstClienteDireccion.Add(obj_clienteDireccion)

                '        End If

                '    End If

                'End If

                dtbVwLocalidad = tbaVwLocalidad.GetDataByID(cbx_comuna_cliente.SelectedValue)

                ciudad = dtbVwLocalidad.Rows(0).Item("equiv_ciudad").ToString().ToUpper()
                abreviaturaRegion = dtbVwLocalidad.Rows(0).Item("abrev_region").ToString()
                localidad = dtbVwLocalidad.Rows(0).Item("Localidad_codigo").ToString()
                zonaTransportes = dtbVwLocalidad.Rows(0).Item("zona_transportes").ToString()
                comuna = dtbVwLocalidad.Rows(0).Item("comuna2").ToString().ToUpper()

                obj_cliente = New ClienteModel(accionCliente, bpartner, comuna, pais, ciudad, empresaPersonal, txt_email_cliente.Text.Trim, txt_giro_cliente.Text.Trim, grupoCliente,
                                               conOrdenCompra, nombre1.Trim(), nombre2.Trim(), apellido1.Trim(), apellido2.Trim(), abreviaturaRegion, txt_direccion_cliente.Text.Trim, "", txt_rutCliente.Text.Trim,
                                               txt_telefono_fijo_cliente.Text.Trim, txt_celular_cliente.Text.Trim, titleKey, "", "", "", localidad, zonaTransportes, "", "", "", "", "", tipoIdentificacion, "", "", "", "", "", Nothing, Nothing, Nothing)

                For Each filaDireccion As DataGridViewRow In DgvDireccionesCliente.Rows
                    dtbVwLocalidad = tbaVwLocalidad.GetDataByID(filaDireccion.Cells("ColCodigoLocalidad").Value)

                    ciudad = dtbVwLocalidad.Rows(0).Item("equiv_ciudad").ToString().ToUpper()
                    abreviaturaRegion = dtbVwLocalidad.Rows(0).Item("abrev_region").ToString()
                    localidad = New String("0", 4 - dtbVwLocalidad.Rows(0).Item("Localidad_codigo").ToString().Trim().Length) & dtbVwLocalidad.Rows(0).Item("Localidad_codigo").ToString().Trim()
                    zonaTransportes = dtbVwLocalidad.Rows(0).Item("zona_transportes").ToString()
                    comuna = dtbVwLocalidad.Rows(0).Item("comuna2").ToString().ToUpper()

                    obj_clienteDireccion = New Diralternativa("", comuna, localidad, ciudad,
                                                              filaDireccion.Cells("ColDireccion").Value.ToString().Trim(), "", pais, filaDireccion.Cells("ColAbrevRegion").Value.ToString().Trim(),
                                                              filaDireccion.Cells("ColTelefono").Value.ToString().Trim(), filaDireccion.Cells("ColCelular").Value.ToString().Trim(), filaDireccion.Cells("ColEmail").Value.ToString().Trim())
                    LstClienteDireccion.Add(obj_clienteDireccion)

                Next

                If LstClienteContacto.Count > 0 Then
                    obj_cliente.PersonasContacto = LstClienteContacto.ToArray()
                End If
                If LstClienteDatosCom.Count > 0 Then
                    obj_cliente.DatosComerciales = LstClienteDatosCom.ToArray()
                End If
                If LstClienteDireccion.Count > 0 Then
                    obj_cliente.DirAlternativa = LstClienteDireccion.ToArray()
                End If

                Dim str_postDataJSON As String = JsonConvert.SerializeObject(obj_cliente)

                If LstClienteContacto.Count = 0 Then
                    str_postDataJSON = str_postDataJSON.Replace(",""PersonasContacto"":null", "")
                End If
                If LstClienteDatosCom.Count = 0 Then
                    str_postDataJSON = str_postDataJSON.Replace(",""DatosComerciales"":null", "")
                End If
                If LstClienteDireccion.Count = 0 Then
                    str_postDataJSON = str_postDataJSON.Replace(",""DirAlternativa"":null", "")
                End If

                Dim obj_sap As class_sap = Nothing

                With Global.caja2.My.MySettings.Default
                    obj_sap = New class_sap(.AmbienteSAP, .SAPUsername1, .SAPPassword1, .SAPUsername2, .SAPPassword2, .clienteSAP, .empresaSAP, .monedaSAP)
                End With

                If accionCliente = "I" Then
                    dateUpdatedInicial = Now
                Else
                    dateUpdatedInicial = tbaCliente.GetDateUpdatedByBpartner(obj_cliente.Bpartner)
                End If

                Dim str_resultadoJSON As String = obj_sap.postCrearCliente(str_postDataJSON)
                Dim obj_clienteResponseModel As ClienteResponseModel = Nothing
                Dim int_indiceDireccion As Integer = 0

                If String.IsNullOrEmpty(str_resultadoJSON) = False Then
                    obj_clienteResponseModel = JsonConvert.DeserializeObject(Of ClienteResponseModel)(str_resultadoJSON)

                    If Not obj_clienteResponseModel Is Nothing Then
                        If IsNumeric(obj_clienteResponseModel.Bp.ToString().Trim()) = True Then

                            bpartner = obj_clienteResponseModel.Bp.ToString().Trim()
                            obj_cliente.Bpartner = obj_clienteResponseModel.Bp.ToString().Trim()

                            dateUpdatedFinal = tbaCliente.GetDateUpdatedByBpartner(obj_cliente.Bpartner)

                            If accionCliente = "I" Then
                                If dateUpdatedFinal <= dateUpdatedInicial Then 'grabamos solo cuando NO ha llegado el cliente desde SAP todavia. Si ya se ha enviado omitimos la grabación
                                    tbaCliente.Insert(accionCliente, obj_cliente.Bpartner, obj_cliente.City, obj_cliente.Country, obj_cliente.District, obj_cliente.EmpresaPersonal, obj_cliente.EMail, obj_cliente.Giro, obj_cliente.GroupClient,
                                                      obj_cliente.Name1, obj_cliente.Name2, obj_cliente.Name3, obj_cliente.Name4, obj_cliente.Region, obj_cliente.Street, obj_cliente.StrSuppl1, obj_cliente.TaxNumber, obj_cliente.Telephone,
                                                      obj_cliente.TelMovil, obj_cliente.TitleKey, obj_cliente.CargoEmpleado, obj_cliente.DescCargoEmpleado, obj_cliente.ListaPrecio, obj_cliente.Localidad, obj_cliente.ConOrdenCompra,
                                                      obj_cliente.ZonaTransporte, obj_cliente.Sociedad, obj_cliente.AgruInterComercial, obj_cliente.GrupoCuenta, obj_cliente.Idioma, obj_cliente.HusoHorario, obj_cliente.TipoIdentificacion,
                                                      obj_cliente.ProcReclamacion, obj_cliente.Cuenta, obj_cliente.GrupoTesoreria, obj_cliente.IndIntereses, obj_cliente.ClasificacionFiscal, 1, Now, Nothing)

                                    If obj_clienteResponseModel.TBpDirAlt.Length > 0 Then

                                        For Each item As Treturn In obj_clienteResponseModel.TBpDirAlt
                                            obj_clienteDireccion = LstClienteDireccion.Item(int_indiceDireccion)

                                            tbaClienteDirecccion.Insert(bpartner, obj_clienteResponseModel.TBpDirAlt.GetValue(0).Item.ToString(), obj_clienteDireccion.City, obj_clienteDireccion.Localidad, obj_clienteDireccion.District,
                                                                        obj_clienteDireccion.Street, obj_clienteDireccion.StrSuppl1, obj_clienteDireccion.District, obj_clienteDireccion.Region, obj_clienteDireccion.Telephone, obj_clienteDireccion.TelMovil,
                                                                        obj_clienteDireccion.EMail, Now, Nothing)

                                            int_indiceDireccion += 1
                                        Next

                                    End If
                                End If

                                MessageBox.Show("Cliente " & obj_clienteResponseModel.Bp.ToString().Trim() & " creado correctamente", "Grabar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else

                                If dateUpdatedFinal <= dateUpdatedInicial Then 'grabamos solo cuando NO ha llegado el cliente desde SAP todavia. Si ya se ha enviado omitimos la grabación
                                    tbaCliente.UpdateQuery(accionCliente, obj_cliente.Bpartner, obj_cliente.City, obj_cliente.Country, obj_cliente.District, obj_cliente.EmpresaPersonal, obj_cliente.EMail, obj_cliente.Giro, obj_cliente.GroupClient,
                                                           obj_cliente.Name1, obj_cliente.Name2, obj_cliente.Name3, obj_cliente.Name4, obj_cliente.Region, obj_cliente.Street, obj_cliente.StrSuppl1, obj_cliente.TaxNumber, obj_cliente.Telephone,
                                                           obj_cliente.TelMovil, obj_cliente.TitleKey, obj_cliente.CargoEmpleado, obj_cliente.DescCargoEmpleado, obj_cliente.ListaPrecio, obj_cliente.Localidad, obj_cliente.ConOrdenCompra,
                                                           obj_cliente.ZonaTransporte, obj_cliente.Sociedad, obj_cliente.AgruInterComercial, obj_cliente.GrupoCuenta, obj_cliente.Idioma, obj_cliente.HusoHorario, obj_cliente.TipoIdentificacion,
                                                           obj_cliente.ProcReclamacion, obj_cliente.Cuenta, obj_cliente.GrupoTesoreria, obj_cliente.IndIntereses, obj_cliente.ClasificacionFiscal, 1, Now)

                                End If

                                MessageBox.Show("Cliente " & obj_clienteResponseModel.Bp.ToString().Trim() & " actualizado correctamente", "Grabar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Else

                        End If

                    End If

                End If

                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grabar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cbx_ciudad_cliente_SelectedIndexChanged(sender As Object, e As EventArgs)
        cbx_comuna_cliente.DataSource = tbaWebComuna.GetDataByIdCiudad(cbx_ciudad_cliente.SelectedValue)
    End Sub

    Private Sub txt_rutCliente_TextChanged(sender As Object, e As EventArgs) Handles txt_rutCliente.TextChanged
        If class_funciones.validacionRut(txt_rutCliente.Text) = True Then
            dtbVwCliente = tbaVwCliente.GetDataByTaxNumber(txt_rutCliente.Text)

            If dtbVwCliente.Rows.Count > 0 Then
                bol_nuevoCliente = False
                rdbPersona.Enabled = False
                rdbEmpresa.Enabled = False

                If dtbVwCliente.Rows(0).Item("EmpresaPersonal").ToString() = "1" Then 'persona natural
                    rdbPersona.Checked = True
                    rdbEmpresa.Checked = False
                    txt_nombre_cliente.Text = dtbVwCliente.Rows(0).Item("Name1").ToString().Trim()
                    txt_apellido_cliente.Text = dtbVwCliente.Rows(0).Item("Name2").ToString().Trim()
                    Call rdbPersona_CheckedChanged(rdbPersona, New EventArgs())

                ElseIf dtbVwCliente.Rows(0).Item("EmpresaPersonal").ToString() = "2" Then 'empresa
                    rdbEmpresa.Checked = True
                    rdbPersona.Checked = False
                    txt_nombre_cliente.Text = dtbVwCliente.Rows(0).Item("Name1").ToString().Trim() & " " & dtbVwCliente.Rows(0).Item("Name2").ToString().Trim() & " " & dtbVwCliente.Rows(0).Item("Name3").ToString().Trim() & " " &
                                              dtbVwCliente.Rows(0).Item("Name4").ToString().Trim()
                    Call rdbEmpresa_CheckedChanged(rdbEmpresa, New EventArgs())

                End If

                If bol_nuevoCliente = True Then
                    rdbPersona.Checked = True
                Else
                End If


                txt_telefono_fijo_cliente.Text = dtbVwCliente.Rows(0).Item("Telephone").ToString()
                txt_celular_cliente.Text = dtbVwCliente.Rows(0).Item("TelMovil").ToString()
                txt_email_cliente.Text = dtbVwCliente.Rows(0).Item("EMail").ToString()
                txt_giro_cliente.Text = dtbVwCliente.Rows(0).Item("Giro").ToString()
                txt_direccion_cliente.Text = dtbVwCliente.Rows(0).Item("Street").ToString().Trim() & " " & dtbVwCliente.Rows(0).Item("StrSuppl1").ToString().Trim()
                txt_idCliente.Text = dtbVwCliente.Rows(0).Item("Bpartner").ToString()

                If IsNumeric(dtbVwCliente.Rows(0).Item("Localidad").ToString()) = True Then
                    dtbVwLocalidad = tbaVwLocalidad.GetDataByID(dtbVwCliente.Rows(0).Item("Localidad").ToString())
                Else
                    dtbVwLocalidad = tbaVwLocalidad.GetDataByID("0")
                End If

                If dtbVwLocalidad.Rows.Count > 0 Then
                    For Each fila As DataRowView In cbx_ciudad_cliente.Items
                        If fila.Row.Item("ciudad_id") = dtbVwLocalidad.Rows(0).Item("ciudad_id") Then
                            cbx_ciudad_cliente.SelectedValue = dtbVwLocalidad.Rows(0).Item("ciudad_id")
                            Exit For
                        End If
                    Next

                    For Each fila As DataRowView In cbx_comuna_cliente.Items
                        If fila.Row.Item("comuna_id") = dtbVwLocalidad.Rows(0).Item("localidad_id") Then
                            cbx_comuna_cliente.SelectedValue = dtbVwLocalidad.Rows(0).Item("localidad_id")
                            Exit For
                        End If
                    Next
                Else
                    If cbx_ciudad_cliente.FindStringExact(dtbVwCliente.Rows(0).Item("District").ToString().Trim()) >= 0 Then
                        cbx_ciudad_cliente.SelectedIndex = cbx_ciudad_cliente.FindStringExact(dtbVwCliente.Rows(0).Item("District").ToString().Trim())
                    End If
                    If cbx_comuna_cliente.FindStringExact(dtbVwCliente.Rows(0).Item("City").ToString().Trim()) >= 0 Then
                        cbx_comuna_cliente.SelectedIndex = cbx_comuna_cliente.FindStringExact(dtbVwCliente.Rows(0).Item("City").ToString().Trim())
                    End If

                End If

                If dtbVwCliente.Rows(0).Item("ConOrdenCompra").ToString() = "X" Then
                    ChkOrdenCompra.Checked = True
                Else
                    ChkOrdenCompra.Checked = False
                End If

            Else
                bol_nuevoCliente = True
                rdbPersona.Enabled = True
                rdbEmpresa.Enabled = True

            End If

        End If

    End Sub

    Private Sub txt_rutCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rutCliente.KeyPress
        If e.KeyChar <> ChrW(22) AndAlso e.KeyChar <> vbBack AndAlso IsNumeric(e.KeyChar) = False AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> "K" AndAlso e.KeyChar <> "k" Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txt_telefono_fijo_cliente_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ChrW(22) AndAlso e.KeyChar <> vbBack AndAlso IsNumeric(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_celular_cliente_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ChrW(22) AndAlso e.KeyChar <> vbBack AndAlso IsNumeric(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_numero_direccion_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ChrW(22) AndAlso e.KeyChar <> vbBack AndAlso IsNumeric(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub rdbPersona_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPersona.CheckedChanged
        lblApellido.Visible = True
        txt_apellido_cliente.Visible = True
        txt_nombre_cliente.Width = 328
    End Sub

    Private Sub rdbEmpresa_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEmpresa.CheckedChanged
        lblApellido.Visible = False
        txt_apellido_cliente.Visible = False
        txt_nombre_cliente.Width = 678
    End Sub

    Private Sub cbx_ciudad_cliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbx_ciudad_cliente.SelectedValueChanged
        If Not cbx_ciudad_cliente.SelectedValue Is Nothing Then
            cbx_comuna_cliente.DataSource = tbaWebComuna.GetDataByIdCiudad(cbx_ciudad_cliente.SelectedValue)
        End If
    End Sub

    Private Sub cbx_ciudad_direccion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbx_ciudad_direccion.SelectedValueChanged
        If Not cbx_ciudad_direccion.SelectedValue Is Nothing Then
            cbx_comuna_direccion.DataSource = tbaWebComuna.GetDataByIdCiudad(cbx_ciudad_direccion.SelectedValue)
        End If
    End Sub

    Private Function ValidarControles() As Boolean
        Return True
    End Function

    Private Sub textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_telefono_direccion.KeyPress, txt_celular_direccion.KeyPress
        If IsNumeric(e.KeyChar) = False AndAlso e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
End Class