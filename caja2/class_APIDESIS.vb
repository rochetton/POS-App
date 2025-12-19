Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Xml.Serialization
Imports caja2.BOLETAS
Imports caja2.DataSet_catalogo
Imports caja2.DTE
Imports caja2.ExtensionesTipo.StringExtensions

Public Class class_APIDESIS

    Dim tbaDesisLog As desis_logTableAdapter = New desis_logTableAdapter

    Dim intAmbiente As Integer = 0 '-1 = Desarrollo, 0 = QA, 1 = Producción
    Dim usuario As String
    Dim rut As String
    Dim password As String
    Dim puerto As String
    Dim incluyeLink As Integer
    Dim urlDescarga As String = ""
    Dim urlDescargaCedible As String = ""
    Dim strErrorProcesar As String = ""
    Dim strEnvioXML As String = ""
    Dim strRespuestaXML As String = ""
    Dim bolResultadoEnvio As Boolean = False
    Dim strTrackId As String = ""

    Dim obj_logSyncObject As Object = New Object

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(ByVal ambiente As Integer, ByVal usuario As String, ByVal rut As String, ByVal password As String, ByVal puerto As String, ByVal incluyeLink As Integer)
        Me.intAmbiente = ambiente
        Me.usuario = EncodeStrToBase64(usuario) 'Q0FSRU5TUEE=
        Me.rut = EncodeStrToBase64(rut) 'MS05
        Me.password = EncodeStrToBase64(password) 'cGxhbm85MTA5OA==
        Me.puerto = EncodeStrToBase64(puerto) 'MA==

        Me.incluyeLink = incluyeLink

    End Sub

    Public Function obtenerTrackIdBoleta(ByRef empresa As pos_empresaDteRow, ByRef cabecera As pos_documentoCabRow, ByRef detalle As pos_documentoDetDataTable,
                                         ByVal idSucursalDTE As Integer, ByVal nombreTienda As String, ByVal nombreVendedor As String, ByVal codigoCondicionPagoDESIS As DTEDefTypeDocumentoEncabezadoIdDocFmaPago, ByVal nombreCondicionPago As String,
                                         ByVal numeroOC As String, ByVal numeroHES As String, ByVal IdCaja As String, ByVal nombreCajero As String, ByVal direccionSucursal As String,
                                         ByVal totalNeto As Integer, ByVal totalIva As Integer, montoTotal As Integer) As String
        Dim obj_envelopeProcesarWSMasivo As APIDESIS.EnvelopeProcesarWSMasivo = New APIDESIS.EnvelopeProcesarWSMasivo()
        Dim obj_BOLETA As BOLETADefType = New BOLETADefType()
        Dim bol_Resultado As Boolean
        Dim errorRespuesta As String = ""
        Dim tipoDTE As Integer = 39
        Dim folioDTE As Integer = 0
        Dim fechaActual As String = Format(Now, "dd-MM-yyyy")
        Dim str_trackId As String = ""
        Dim str_formatoAlfaNum As String = "[^a-zA-Z0-9 ]"

        Dim obj_documento As BOLETADefTypeDocumento = New BOLETADefTypeDocumento

        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Rut = Me.rut '"MS05"
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Clave = Me.password '"cGxhbm85MTA5OA=="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Puerto = Me.puerto '"MA=="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.IncluyeLink = Me.incluyeLink.ToString() '1
        obj_envelopeProcesarWSMasivo.Body.Procesar.formato = 2 'XML

        obj_documento.ID = "F1T" & tipoDTE.ToString()
        obj_documento.Encabezado = New BOLETADefTypeDocumentoEncabezado
        obj_documento.Encabezado.Emisor = New BOLETADefTypeDocumentoEncabezadoEmisor

        obj_documento.Encabezado.IdDoc = New BOLETADefTypeDocumentoEncabezadoIdDoc
        obj_documento.Encabezado.IdDoc.TipoDTE = DTE.DTEType.Item33
        obj_documento.Encabezado.IdDoc.Folio = folioDTE.ToString()
        obj_documento.Encabezado.IdDoc.FchEmis = Format(Now(), "yyyy-MM-dd") '"2008-04-09"

        obj_documento.Encabezado.Emisor = New BOLETADefTypeDocumentoEncabezadoEmisor
        obj_documento.Encabezado.Emisor.RUTEmisor = empresa.RUTEmisor.Trim() '"77307757-6"
        obj_documento.Encabezado.Emisor.RznSocEmisor = empresa.RznSocEmisor.Trim() '"CAREN SPA"
        obj_documento.Encabezado.Emisor.GiroEmisor = empresa.GiroEmisor.Trim() '"VENTA DE PARTES, PIEZAS Y ACCESORIOS PARA VEHICULOS AUTOMOTORES"
        obj_documento.Encabezado.Emisor.DirOrigen = empresa.DirOrigen.Trim() '"Obispo Umaña 1042"
        obj_documento.Encabezado.Emisor.CmnaOrigen = empresa.CmnaOrigen.Trim() '"Estación Central"
        obj_documento.Encabezado.Emisor.CiudadOrigen = empresa.CiudadOrigen.Trim() '"SANTIAGO"
        obj_documento.Encabezado.Emisor.Sucursal = idSucursalDTE.ToString()

        obj_documento.Encabezado.Receptor = New BOLETADefTypeDocumentoEncabezadoReceptor
        If cabecera.Item("dpc_rutClienteBoleta").ToString().Trim() = "" Then
            obj_documento.Encabezado.Receptor.RUTRecep = "66666666-6" 'Rut cliente genérico SII
        Else
            obj_documento.Encabezado.Receptor.RUTRecep = cabecera.Item("dpc_rutClienteBoleta").ToString().Trim()
        End If

        obj_documento.Encabezado.Receptor.CdgIntRecep = cabecera.Item("cli_id").ToString().Trim() '"15915915"
        obj_documento.Encabezado.Receptor.RznSocRecep = Regex.Replace(cabecera.Item("dpc_nombreClienteBoleta").ToString().Trim(), str_formatoAlfaNum, " ") '"SERVICIOS GRAFICOS"
        obj_documento.Encabezado.Receptor.DirRecep = ""

        obj_documento.Encabezado.Receptor.CmnaRecep = ""
        obj_documento.Encabezado.Receptor.CiudadRecep = ""

        obj_documento.Encabezado.Totales = New BOLETADefTypeDocumentoEncabezadoTotales
        obj_documento.Encabezado.Totales.MntNeto = totalNeto 'cabecera.dpc_totalNeto.ToString()
        obj_documento.Encabezado.Totales.IVA = totalIva 'cabecera.dpc_totalIva.ToString()
        obj_documento.Encabezado.Totales.MntTotal = montoTotal 'cabecera.dpc_totalFinal.ToString()
        obj_documento.Encabezado.Totales.TotalPeriodo = montoTotal 'cabecera.dpc_totalFinal.ToString()

        obj_documento.Adicional = New caja2.BOLETAS.DTEDocumentoAdicional
        obj_documento.Adicional.NodosA = New caja2.BOLETAS.DTEDocumentoAdicionalNodosA()
        obj_documento.Adicional.NodosA.A1 = Format(Now(), "yyyy-MM-dd") 'Vencimiento"
        obj_documento.Adicional.NodosA.A2 = nombreCondicionPago.ToString().Trim()  'Cond. de Pago"
        obj_documento.Adicional.NodosA.A3 = nombreVendedor.ToString().Trim() 'Vendedor"
        obj_documento.Adicional.NodosA.A4 = nombreTienda.ToString().Trim() 'Local"
        obj_documento.Adicional.NodosA.A5 = IIf(cabecera.Isdpc_telefonoClienteBoletaNull = True, "", cabecera.Item("dpc_telefonoClienteBoleta").ToString().Trim())
        obj_documento.Adicional.NodosA.A6 = "" 'OC"
        obj_documento.Adicional.NodosA.A7 = cabecera.Item("dpc_numDocOrigen").ToString().Trim 'Nro Nota Venta / Nro Orden de Servicio
        obj_documento.Adicional.NodosA.A8 = IdCaja 'ID Caja
        obj_documento.Adicional.NodosA.A9 = nombreCajero 'Cod.Cliente
        obj_documento.Adicional.NodosA.A10 = nombreTienda.ToString().Trim() 'Sucursal
        obj_documento.Adicional.NodosA.A11 = cabecera.dpc_fecha.ToString("HH:mm:ss")

        Dim listaDetalle As List(Of BOLETADefTypeDocumentoDetalle) = New List(Of BOLETADefTypeDocumentoDetalle)
        Dim obj_detalle As BOLETADefTypeDocumentoDetalle = Nothing
        Dim obj_detalleCdgItem As BOLETADefTypeDocumentoDetalleCdgItem = Nothing

        Dim NumItem As Integer = 1
        Dim totalFilaConIva As Integer = 0
        Dim totalRemanente As Integer = montoTotal

        For Each filaDet As pos_documentoDetRow In detalle.Rows
            totalFilaConIva = Math.Round(filaDet.dpd_totalNetoFinal * 1.19, 0)

            obj_detalle = New BOLETADefTypeDocumentoDetalle
            obj_detalleCdgItem = New BOLETADefTypeDocumentoDetalleCdgItem
            obj_detalle.NroLinDet = NumItem
            obj_detalleCdgItem.TpoCodigo = "INT1"
            obj_detalleCdgItem.VlrCodigo = filaDet.rp_codigo.ToString.Trim 'Código producto
            obj_detalle.CdgItem = (New List(Of BOLETADefTypeDocumentoDetalleCdgItem) From {obj_detalleCdgItem}).ToArray()
            obj_detalle.NmbItem = filaDet.rp_descripcion.ToString.Trim
            obj_detalle.DscItem = ""
            obj_detalle.QtyItem = Convert.ToDecimal(filaDet.dpd_cantidad)
            obj_detalle.QtyItemSpecified = True
            obj_detalle.UnmdItem = "UN"

            If detalle.Rows.IndexOf(filaDet) + 1 = detalle.Rows.Count Then
                obj_detalle.PrcItem = Convert.ToDecimal(totalRemanente / filaDet.dpd_cantidad)
            Else
                obj_detalle.PrcItem = Convert.ToDecimal(totalFilaConIva / filaDet.dpd_cantidad)
            End If

            obj_detalle.PrcItem = Math.Round(obj_detalle.PrcItem, 6, MidpointRounding.AwayFromZero) 'Se ajusta la cantidad de decimales máximos segun SII. 12 enteros, 6 decimales.

            obj_detalle.PrcItemSpecified = True

            If detalle.Rows.IndexOf(filaDet) + 1 = detalle.Rows.Count Then
                obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(totalRemanente), 0)
            Else
                obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(totalFilaConIva), 0)
            End If

            listaDetalle.Add(obj_detalle)

            NumItem = NumItem + 1
            totalRemanente = totalRemanente - totalFilaConIva
        Next

        obj_documento.Detalle = listaDetalle.ToArray()

        If numeroOC <> "" OrElse numeroHES <> "" Then
            Dim listaReferencia As List(Of BOLETADefTypeDocumentoReferencia) = New List(Of BOLETADefTypeDocumentoReferencia)
            Dim obj_referencia As BOLETADefTypeDocumentoReferencia = Nothing

            If numeroOC <> "" Then
                obj_referencia = New BOLETADefTypeDocumentoReferencia
                obj_referencia.NroLinRef = listaReferencia.Count + 1
                obj_referencia.CodRef = "801"
                obj_referencia.TpoDocRef = "801"
                obj_referencia.FolioRef = numeroOC
                obj_referencia.RazonRef = "ORDEN DE COMPRA"
                listaReferencia.Add(obj_referencia)
            End If

            If numeroHES <> "" Then
                obj_referencia = New BOLETADefTypeDocumentoReferencia
                obj_referencia.NroLinRef = listaReferencia.Count + 1
                obj_referencia.CodRef = "802"
                obj_referencia.TpoDocRef = "802"
                obj_referencia.FolioRef = numeroHES
                obj_referencia.RazonRef = "NOTA DE PEDIDO"
                listaReferencia.Add(obj_referencia)
            End If

            obj_documento.Referencia = listaReferencia.ToArray()
        End If

        obj_BOLETA.Documento = obj_documento

        Dim string_documento As String = func_SerializarObjeto(obj_BOLETA, GetType(BOLETADefType), System.Text.Encoding.UTF8)
        string_documento = string_documento.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
        string_documento = string_documento.Replace("xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ", "")
        string_documento = string_documento.Replace("xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ", "")
        string_documento = string_documento.Replace(vbCrLf & "<DTE ", "<DTE ")

        Me.strEnvioXML = string_documento.ToString()
        obj_envelopeProcesarWSMasivo.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)

        Me.urlDescarga = ""
        Me.strErrorProcesar = ""
        Me.strTrackId = ""
        Me.bolResultadoEnvio = False

        Dim resultado As String = postProcesarWSMasivo(obj_envelopeProcesarWSMasivo)
        Me.strRespuestaXML = resultado.ToString()

        Dim obj_reponseProcesar As APIDESIS.EnvelopeResponseProcesarWSMasivo = Nothing
        func_DeserializarObjeto(resultado, GetType(APIDESIS.EnvelopeResponseProcesarWSMasivo), obj_reponseProcesar)

        Dim xml_responseProcesar As Xml.XmlDocument = New Xml.XmlDocument()

        Try
            xml_responseProcesar.LoadXml(obj_reponseProcesar.Body.ProcesarWSMasivoResponse.ProcesarWSMasivoResult)
            '<?xml version="1.0"?><WSPLANO><Resultado>True</Resultado><Mensaje>Proceso exitoso.</Mensaje><TrackId>38</TrackId></WSPLANO>

            bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText

            If xml_responseProcesar.GetElementsByTagName("TrackId").Count > 0 Then
                str_trackId = xml_responseProcesar.GetElementsByTagName("TrackId").Item(0).InnerText
            End If

            If bol_Resultado = False Then
                errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
                Me.strErrorProcesar = errorRespuesta
                Me.bolResultadoEnvio = False

            Else
                Me.strErrorProcesar = ""
                Me.bolResultadoEnvio = True

            End If

        Catch ex As Exception
            Me.bolResultadoEnvio = False
        End Try

        Return str_trackId

    End Function

    Public Function obtenerTrackIdFactura(ByRef empresa As pos_empresaDteRow, ByRef cabecera As pos_documentoCabRow, ByRef detalle As pos_documentoDetDataTable,
                                          ByVal idSucursalDTE As Integer, ByVal nombreTienda As String, ByVal nombreVendedor As String, ByVal codigoCondicionPagoDESIS As DTEDefTypeDocumentoEncabezadoIdDocFmaPago, ByVal nombreCondicionPago As String,
                                          ByVal fechaVencimiento As Date, ByVal numeroOC As String, ByVal numeroHES As String, ByVal fechaReferencia As Date, ByVal direccionFacturacion As String, ByVal comunaFacturacion As String,
                                          ByVal ciudadFacturacion As String, ByVal totalNeto As Integer, ByVal totalIva As Integer, montoTotal As Integer) As String
        Dim obj_envelopeProcesarWSMasivo As APIDESIS.EnvelopeProcesarWSMasivo = New APIDESIS.EnvelopeProcesarWSMasivo()
        Dim obj_DTE As DTEDefType = New DTEDefType()
        Dim bol_Resultado As Boolean
        Dim errorRespuesta As String = ""
        Dim tipoDTE As Integer = 33
        Dim folioDTE As Integer = 0
        Dim fechaActual As String = Format(Now, "dd-MM-yyyy")
        Dim str_trackId As String = ""
        Dim str_formatoAlfaNum As String = "[^a-zA-Z0-9 ]"

        Dim obj_documento As DTEDefTypeDocumento = New DTEDefTypeDocumento()

        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Rut = Me.rut '"MS05"
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Clave = Me.password '"cGxhbm85MTA5OA=="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Puerto = Me.puerto '"MA=="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.IncluyeLink = Me.incluyeLink.ToString() '11
        obj_envelopeProcesarWSMasivo.Body.Procesar.formato = 2 'XML

        obj_documento.ID = "F" & folioDTE.ToString() & "T" & tipoDTE.ToString()
        obj_documento.Encabezado = New DTEDefTypeDocumentoEncabezado()
        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()

        obj_documento.Encabezado.IdDoc = New DTEDefTypeDocumentoEncabezadoIdDoc()
        obj_documento.Encabezado.IdDoc.TipoDTE = DTE.DTEType.Item33
        obj_documento.Encabezado.IdDoc.Folio = folioDTE.ToString()
        obj_documento.Encabezado.IdDoc.FchEmis = Format(Now(), "yyyy-MM-dd") '"2008-04-09"
        obj_documento.Encabezado.IdDoc.FmaPago = codigoCondicionPagoDESIS
        obj_documento.Encabezado.IdDoc.FmaPagoSpecified = True
        obj_documento.Encabezado.IdDoc.FchVenc = fechaVencimiento
        obj_documento.Encabezado.IdDoc.FchVencSpecified = True

        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()
        obj_documento.Encabezado.Emisor.RUTEmisor = empresa.RUTEmisor.Trim() ' "77307757-6"
        obj_documento.Encabezado.Emisor.RznSoc = empresa.RznSocEmisor.Trim() '"CAREN SPA"
        obj_documento.Encabezado.Emisor.GiroEmis = empresa.GiroEmisor.Trim() '"VENTA DE PARTES, PIEZAS Y ACCESORIOS PARA VEHICULOS AUTOMOTORES"
        obj_documento.Encabezado.Emisor.Acteco = New String() {empresa.Acteco.ToString().Trim()} '"453000"
        obj_documento.Encabezado.Emisor.DirOrigen = empresa.DirOrigen.Trim() '"Obispo Umaña 1042"
        obj_documento.Encabezado.Emisor.CmnaOrigen = empresa.CmnaOrigen.Trim() '"Estación Central"
        obj_documento.Encabezado.Emisor.CiudadOrigen = empresa.CiudadOrigen.Trim() '"SANTIAGO"
        obj_documento.Encabezado.Emisor.Sucursal = idSucursalDTE.ToString()

        obj_documento.Encabezado.Receptor = New DTEDefTypeDocumentoEncabezadoReceptor()
        obj_documento.Encabezado.Receptor.RUTRecep = cabecera.Item("dpc_rut").ToString().Trim()  '"15915915-9"
        obj_documento.Encabezado.Receptor.CdgIntRecep = cabecera.Item("cli_id").ToString().Trim() '"15915915"
        obj_documento.Encabezado.Receptor.RznSocRecep = cabecera.Item("dpc_nombre").ToString().Trim() '"SERVICIOS GRAFICOS"

        If cabecera.Item("dpc_giroFacturacion").ToString().Trim().Length > 40 Then
            obj_documento.Encabezado.Receptor.GiroRecep = cabecera.Item("dpc_giroFacturacion").ToString().Trim().Substring(0, 40)
        Else
            obj_documento.Encabezado.Receptor.GiroRecep = cabecera.Item("dpc_giroFacturacion").ToString().Trim() '"SERVICIO"
        End If

        obj_documento.Encabezado.Receptor.DirRecep = Regex.Replace(direccionFacturacion.ToString().Trim(), str_formatoAlfaNum, " ")  'cabecera.Item("dpc_direccionFacturacion").ToString().Trim() '"DEPARTAMENTAL 250"

        If obj_documento.Encabezado.Receptor.DirRecep.ToString().Length > 70 Then
            obj_documento.Encabezado.Receptor.DirRecep = obj_documento.Encabezado.Receptor.DirRecep.Substring(0, 70)
        End If

        obj_documento.Encabezado.Receptor.CmnaRecep = comunaFacturacion.ToString().Trim() 'cabecera.Item("dpc_nombreComunaFacturacion").ToString().Trim() ' "SAN JOAQUIN"
        obj_documento.Encabezado.Receptor.CiudadRecep = ciudadFacturacion.ToString().Trim() 'cabecera.Item("dpc_nombreCiudadFacturacion").ToString().Trim()  '"SANTIAGO"

        obj_documento.Encabezado.Totales = New DTEDefTypeDocumentoEncabezadoTotales()
        obj_documento.Encabezado.Totales.MntNeto = totalNeto ' cabecera.dpc_totalNeto.ToString()
        obj_documento.Encabezado.Totales.TasaIVA = Convert.ToDecimal("19")
        obj_documento.Encabezado.Totales.TasaIVASpecified = True
        obj_documento.Encabezado.Totales.IVA = totalIva ' cabecera.dpc_totalIva.ToString()
        obj_documento.Encabezado.Totales.MntTotal = montoTotal ' cabecera.dpc_totalFinal.ToString()

        obj_documento.Adicional = New caja2.DTE.DTEDocumentoAdicional
        obj_documento.Adicional.NodosA = New caja2.DTE.DTEDocumentoAdicionalNodosA()
        obj_documento.Adicional.NodosA.A1 = Format(fechaVencimiento, "dd-MM-yyyy") 'Vencimiento"
        obj_documento.Adicional.NodosA.A2 = nombreCondicionPago.ToString().Trim()  'Cond. de Pago"
        obj_documento.Adicional.NodosA.A3 = nombreVendedor.ToString().Trim() 'Vendedor"
        obj_documento.Adicional.NodosA.A4 = nombreTienda.ToString().Trim() 'Local"
        obj_documento.Adicional.NodosA.A5 = cabecera.Item("dpc_telefonoFacturacion").ToString().Trim()
        obj_documento.Adicional.NodosA.A6 = numeroOC.ToString().Trim() 'OC
        obj_documento.Adicional.NodosA.A7 = cabecera.Item("dpc_numDocOrigen").ToString().Trim() 'Nro Nota Venta / Nro Orden de Servicio"
        obj_documento.Adicional.NodosA.A8 = "" 'Observaciones"
        obj_documento.Adicional.NodosA.A9 = cabecera.cli_id.ToString() 'Cod.Cliente"

        Dim listaDetalle As List(Of DTEDefTypeDocumentoDetalle) = New List(Of DTEDefTypeDocumentoDetalle)
        Dim obj_detalle As DTEDefTypeDocumentoDetalle = Nothing
        Dim obj_detalleCdgItem As DTEDefTypeDocumentoDetalleCdgItem = Nothing

        Dim NumItem As Integer = 1

        For Each filaDet As pos_documentoDetRow In detalle.Rows

            obj_detalle = New DTEDefTypeDocumentoDetalle()
            obj_detalleCdgItem = New DTEDefTypeDocumentoDetalleCdgItem
            obj_detalle.NroLinDet = NumItem
            obj_detalleCdgItem.TpoCodigo = "INT1"
            obj_detalleCdgItem.VlrCodigo = filaDet.rp_codigo.ToString.Trim 'Código producto
            obj_detalle.CdgItem = (New List(Of DTEDefTypeDocumentoDetalleCdgItem) From {obj_detalleCdgItem}).ToArray()
            obj_detalle.NmbItem = filaDet.rp_descripcion.ToString.Trim
            obj_detalle.DscItem = ""
            obj_detalle.QtyItem = Convert.ToDecimal(filaDet.dpd_cantidad)
            obj_detalle.QtyItemSpecified = True
            obj_detalle.UnmdItem = "UN"
            obj_detalle.PrcItem = Convert.ToDecimal(filaDet.dpd_precioUnitarioNetoFinal)
            obj_detalle.PrcItemSpecified = True
            obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(filaDet.dpd_totalNetoFinal), 0)

            listaDetalle.Add(obj_detalle)

            NumItem = NumItem + 1

        Next

        obj_documento.Detalle = listaDetalle.ToArray()

        If numeroOC <> "" OrElse numeroHES <> "" Then
            Dim listaReferencia As List(Of DTEDefTypeDocumentoReferencia) = New List(Of DTEDefTypeDocumentoReferencia)
            Dim obj_referencia As DTEDefTypeDocumentoReferencia = New DTEDefTypeDocumentoReferencia

            If numeroOC <> "" Then
                obj_referencia = New DTEDefTypeDocumentoReferencia
                obj_referencia.NroLinRef = listaReferencia.Count + 1
                obj_referencia.TpoDocRef = "801"
                obj_referencia.FolioRef = numeroOC
                obj_referencia.RazonRef = "" 'ORDEN DE COMPRA
                obj_referencia.FchRef = fechaReferencia
                listaReferencia.Add(obj_referencia)
            End If

            If numeroHES <> "" Then
                obj_referencia = New DTEDefTypeDocumentoReferencia
                obj_referencia.NroLinRef = listaReferencia.Count + 1
                obj_referencia.TpoDocRef = "802"
                obj_referencia.FolioRef = numeroHES
                obj_referencia.RazonRef = "NOTA DE PEDIDO"
                obj_referencia.FchRef = fechaReferencia
                listaReferencia.Add(obj_referencia)
            End If

            obj_documento.Referencia = listaReferencia.ToArray()
        End If

        obj_DTE.Item = obj_documento

        Dim string_documento As String = func_SerializarObjeto(obj_DTE, GetType(DTEDefType), System.Text.Encoding.UTF8)
        string_documento = string_documento.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
        string_documento = string_documento.Replace(vbCrLf & "<DTE ", "<DTE ")

        Me.strEnvioXML = string_documento.ToString()
        obj_envelopeProcesarWSMasivo.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)

        Me.urlDescarga = ""
        Me.strErrorProcesar = ""
        Me.strTrackId = ""
        Me.bolResultadoEnvio = False

        Dim resultado As String = postProcesarWSMasivo(obj_envelopeProcesarWSMasivo)
        Me.strRespuestaXML = resultado.ToString()

        Dim obj_reponseProcesar As APIDESIS.EnvelopeResponseProcesarWSMasivo = Nothing
        func_DeserializarObjeto(resultado, GetType(APIDESIS.EnvelopeResponseProcesarWSMasivo), obj_reponseProcesar)

        Dim xml_responseProcesar As Xml.XmlDocument = New Xml.XmlDocument()

        Try
            xml_responseProcesar.LoadXml(obj_reponseProcesar.Body.ProcesarWSMasivoResponse.ProcesarWSMasivoResult)

            bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
            If xml_responseProcesar.GetElementsByTagName("TrackId").Count > 0 Then
                str_trackId = xml_responseProcesar.GetElementsByTagName("TrackId").Item(0).InnerText
            End If

            If bol_Resultado = False Then
                errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
                Me.strErrorProcesar = errorRespuesta
                Me.bolResultadoEnvio = False
            Else
                Me.strErrorProcesar = ""
                Me.bolResultadoEnvio = True
            End If

        Catch ex As Exception
            Me.bolResultadoEnvio = False
        End Try

        Return str_trackId
    End Function

    Public Function obtenerTrackIdNotaCredito(ByRef empresa As pos_empresaDteRow, ByRef cabecera As pos_documentoCabRow, ByRef detalle As pos_documentoDetDataTable,
                                              ByVal idSucursalDTE As Integer, ByVal nombreTienda As String, ByVal nombreVendedor As String, ByVal codigoCondicionPagoDESIS As DTEDefTypeDocumentoEncabezadoIdDocFmaPago, ByVal nombreCondicionPago As String,
                                              ByVal tipoDteRef As Integer, ByVal folioDteRef As Long, ByVal CodRef As DTEDefTypeDocumentoReferenciaCodRef, ByVal numDocOrigen As Integer,
                                              ByVal totalNeto As Integer, ByVal totalIva As Integer, montoTotal As Integer) As String

        Dim obj_envelopeProcesarWSMasivo As APIDESIS.EnvelopeProcesarWSMasivo = New APIDESIS.EnvelopeProcesarWSMasivo()
        Dim obj_DTE As DTEDefType = New DTEDefType()
        Dim bol_Resultado As Boolean
        Dim errorRespuesta As String = ""
        Dim tipoDTE As Integer = 61
        Dim folioDTE As Integer = 0
        Dim fechaActual As String = Format(Now, "dd-MM-yyyy")
        Dim str_trackId As String = ""
        Dim str_formatoAlfaNum As String = "[^a-zA-Z0-9 ]"
        Dim dat_fechaRef As Date = Now.Date
        Dim espacio As String = Chr(32)

        Dim obj_documento As DTEDefTypeDocumento = New DTEDefTypeDocumento()

        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Rut = Me.rut '"MS05"
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Clave = Me.password '"cGxhbm85MTA5OA=="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Puerto = Me.puerto '"MA=="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.IncluyeLink = Me.incluyeLink.ToString() '11
        obj_envelopeProcesarWSMasivo.Body.Procesar.formato = 2 'XML

        obj_documento.ID = "F" & folioDTE.ToString() & "T" & tipoDTE.ToString()
        obj_documento.Encabezado = New DTEDefTypeDocumentoEncabezado()
        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()

        obj_documento.Encabezado.IdDoc = New DTEDefTypeDocumentoEncabezadoIdDoc()
        obj_documento.Encabezado.IdDoc.TipoDTE = DTE.DTEType.Item61
        obj_documento.Encabezado.IdDoc.Folio = folioDTE.ToString()
        obj_documento.Encabezado.IdDoc.FchEmis = Format(Now(), "yyyy-MM-dd") '"2008-04-09"
        obj_documento.Encabezado.IdDoc.FmaPago = codigoCondicionPagoDESIS
        obj_documento.Encabezado.IdDoc.FmaPagoSpecified = True
        'obj_documento.Encabezado.IdDoc.MntBruto = DTEDefTypeDocumentoEncabezadoIdDocMntBruto.Item1
        'obj_documento.Encabezado.IdDoc.MntBrutoSpecified = True

        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()
        obj_documento.Encabezado.Emisor.RUTEmisor = empresa.RUTEmisor.Trim() ' "77307757-6"
        obj_documento.Encabezado.Emisor.RznSoc = empresa.RznSocEmisor.Trim() '"CAREN SPA"
        obj_documento.Encabezado.Emisor.GiroEmis = empresa.GiroEmisor.Trim() '"VENTA DE PARTES, PIEZAS Y ACCESORIOS PARA VEHICULOS AUTOMOTORES"
        obj_documento.Encabezado.Emisor.Acteco = New String() {empresa.Acteco.ToString().Trim()} '"453000"
        obj_documento.Encabezado.Emisor.DirOrigen = empresa.DirOrigen.Trim() '"Obispo Umaña 1042"
        obj_documento.Encabezado.Emisor.CmnaOrigen = empresa.CmnaOrigen.Trim() '"Estación Central"
        obj_documento.Encabezado.Emisor.CiudadOrigen = empresa.CiudadOrigen.Trim() '"SANTIAGO"
        obj_documento.Encabezado.Emisor.Sucursal = idSucursalDTE.ToString()

        obj_documento.Encabezado.Receptor = New DTEDefTypeDocumentoEncabezadoReceptor()
        obj_documento.Encabezado.Receptor.RUTRecep = cabecera.dpc_rut.ToString().Trim()  '"15915915-9"
        obj_documento.Encabezado.Receptor.CdgIntRecep = cabecera.cli_id.ToString() '"15915915"
        obj_documento.Encabezado.Receptor.RznSocRecep = cabecera.Item("dpc_nombre").ToString().Trim() '"SERVICIOS GRAFICOS"

        If cabecera.Item("dpc_giroFacturacion").ToString().Trim().Length > 40 Then
            obj_documento.Encabezado.Receptor.GiroRecep = cabecera.Item("dpc_giroFacturacion").ToString().Trim().Substring(0, 40)
        Else
            obj_documento.Encabezado.Receptor.GiroRecep = cabecera.Item("dpc_giroFacturacion").ToString().Trim() '"SERVICIO"
        End If

        obj_documento.Encabezado.Receptor.DirRecep = Regex.Replace(cabecera.Item("dpc_direccionFacturacion").ToString().Trim(), str_formatoAlfaNum, " ")   '"DEPARTAMENTAL 250"
        obj_documento.Encabezado.Receptor.DirRecep = Regex.Replace(obj_documento.Encabezado.Receptor.DirRecep, espacio.ToString() & "{2,}", " ") ' Si dirección tiene mas de 1 espacio consecutivo reemplazar con un solo espacio

        If obj_documento.Encabezado.Receptor.DirRecep.ToString().Length > 70 Then
            obj_documento.Encabezado.Receptor.DirRecep = obj_documento.Encabezado.Receptor.DirRecep.Substring(0, 70)
        End If

        obj_documento.Encabezado.Receptor.CmnaRecep = cabecera.Item("dpc_nombreComunaFacturacion").ToString().Trim() ' "SAN JOAQUIN"
        obj_documento.Encabezado.Receptor.CiudadRecep = cabecera.Item("dpc_nombreCiudadFacturacion").ToString().Trim()  '"SANTIAGO"

        obj_documento.Encabezado.Totales = New DTEDefTypeDocumentoEncabezadoTotales()
        obj_documento.Encabezado.Totales.MntNeto = totalNeto 'cabecera.dpc_totalNeto.ToString()
        obj_documento.Encabezado.Totales.TasaIVA = Convert.ToDecimal("19")
        obj_documento.Encabezado.Totales.TasaIVASpecified = True
        obj_documento.Encabezado.Totales.IVA = totalIva 'cabecera.dpc_totalIva.ToString()
        obj_documento.Encabezado.Totales.MntTotal = montoTotal 'cabecera.dpc_totalFinal.ToString()

        Dim tbaDteCab As dte_cabTableAdapter = New dte_cabTableAdapter
        Dim dtbDteCab As DataTable = tbaDteCab.GetDataByTipoDTEAndFolio(tipoDteRef, folioDteRef)

        If dtbDteCab.Rows.Count > 0 Then
            Date.TryParse(dtbDteCab.Rows(0).Item("FchEmis").ToString(), dat_fechaRef)

            If CodRef = DTEDefTypeDocumentoReferenciaCodRef.Item1 Then ' 1 = Anula Documento

                obj_documento.Encabezado.Totales.MntNeto = dtbDteCab.Rows(0).Item("MntNeto")
                obj_documento.Encabezado.Totales.IVA = dtbDteCab.Rows(0).Item("IVA")
                obj_documento.Encabezado.Totales.MntTotal = dtbDteCab.Rows(0).Item("MntTotal")

            End If
        End If

        obj_documento.Adicional = New caja2.DTE.DTEDocumentoAdicional
        obj_documento.Adicional.NodosA = New caja2.DTE.DTEDocumentoAdicionalNodosA()
        obj_documento.Adicional.NodosA.A1 = Format(Now(), "yyyy-MM-dd") 'Vencimiento"
        obj_documento.Adicional.NodosA.A2 = nombreCondicionPago.ToString().Trim()  'Cond. de Pago"
        obj_documento.Adicional.NodosA.A3 = nombreVendedor.ToString().Trim() 'Vendedor"
        obj_documento.Adicional.NodosA.A4 = nombreTienda.ToString().Trim() 'Local"
        obj_documento.Adicional.NodosA.A5 = cabecera.Item("dpc_telefonoFacturacion").ToString()
        obj_documento.Adicional.NodosA.A6 = "" 'OC"
        obj_documento.Adicional.NodosA.A7 = numDocOrigen.ToString() 'Nro Nota Venta / Nro Orden de Servicio"
        obj_documento.Adicional.NodosA.A8 = "" 'Observaciones"
        obj_documento.Adicional.NodosA.A9 = cabecera.cli_id.ToString() 'Cod.Cliente"

        Dim listaDetalle As List(Of DTEDefTypeDocumentoDetalle) = New List(Of DTEDefTypeDocumentoDetalle)
        Dim obj_detalle As DTEDefTypeDocumentoDetalle = Nothing
        Dim obj_detalleCdgItem As DTEDefTypeDocumentoDetalleCdgItem = Nothing

        Dim NumItem As Integer = 1

        For Each filaDet As pos_documentoDetRow In detalle.Rows

            obj_detalle = New DTEDefTypeDocumentoDetalle()
            obj_detalleCdgItem = New DTEDefTypeDocumentoDetalleCdgItem
            obj_detalle.NroLinDet = NumItem
            obj_detalleCdgItem.TpoCodigo = "INT1"
            obj_detalleCdgItem.VlrCodigo = filaDet.rp_codigo.ToString.Trim 'Código producto
            obj_detalle.CdgItem = (New List(Of DTEDefTypeDocumentoDetalleCdgItem) From {obj_detalleCdgItem}).ToArray()
            obj_detalle.NmbItem = filaDet.rp_descripcion.ToString.Trim
            obj_detalle.DscItem = ""
            obj_detalle.QtyItem = Convert.ToDecimal(filaDet.dpd_cantidad)
            obj_detalle.QtyItemSpecified = True
            obj_detalle.UnmdItem = "UN"

            If tipoDteRef = 33 Then 'Factura de Venta
                obj_detalle.PrcItem = Convert.ToDecimal(filaDet.dpd_precioUnitarioNetoFinal)
            ElseIf tipoDteRef = 39 Then 'Boleta de Venta
                obj_detalle.PrcItem = Convert.ToDecimal(filaDet.dpd_precio)
            End If

            obj_detalle.PrcItemSpecified = True

            If tipoDteRef = 33 Then 'Factura de Venta
                obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(filaDet.dpd_totalNetoFinal), 0)
            ElseIf tipoDteRef = 39 Then 'Boleta de Venta
                obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(filaDet.dpd_total), 0)
            End If

            listaDetalle.Add(obj_detalle)

            NumItem = NumItem + 1

        Next

        Dim tbaDteDet As dte_detTableAdapter = New dte_detTableAdapter
        Dim dtbDteDet As DataTable = tbaDteDet.GetDataByTipoDTEAndFolio(tipoDteRef, folioDteRef)

        If tipoDteRef = 39 AndAlso listaDetalle.Count = 1 AndAlso dtbDteDet.Rows.Count = 1 Then
            listaDetalle.Item(0).PrcItem = Convert.ToDecimal(dtbDteDet.Rows(0).Item("PrcItem"))
            listaDetalle.Item(0).MontoItem = Math.Round(Convert.ToDecimal(listaDetalle.Item(0).QtyItem * listaDetalle.Item(0).PrcItem))

        End If

        obj_documento.Detalle = listaDetalle.ToArray()

        Dim listaReferencia As List(Of DTEDefTypeDocumentoReferencia) = New List(Of DTEDefTypeDocumentoReferencia)
        Dim obj_referencia As DTEDefTypeDocumentoReferencia = New DTEDefTypeDocumentoReferencia

        obj_referencia.NroLinRef = 1
        obj_referencia.CodRef = CodRef
        obj_referencia.CodRefSpecified = True
        obj_referencia.TpoDocRef = tipoDteRef.ToString()
        obj_referencia.FolioRef = folioDteRef.ToString()
        obj_referencia.FchRef = dat_fechaRef
        listaReferencia.Add(obj_referencia)

        obj_documento.Referencia = listaReferencia.ToArray()

        Dim listaDscRcgGlobal As List(Of DTEDefTypeDocumentoDscRcgGlobal) = New List(Of DTEDefTypeDocumentoDscRcgGlobal)
        Dim obj_DscRcgGlobal As DTEDefTypeDocumentoDscRcgGlobal = Nothing

        If CodRef = DTEDefTypeDocumentoReferenciaCodRef.Item1 OrElse CodRef = DTEDefTypeDocumentoReferenciaCodRef.Item3 Then ' 1 = Anula Documento, 3 = Corrige Montos
            Dim tbaDscRcg As dte_dsc_rcgTableAdapter = New dte_dsc_rcgTableAdapter
            Dim dtbDscRcg As DataTable = tbaDscRcg.GetDataByTipoDTEAndFolio(tipoDteRef, folioDteRef)

            If dtbDscRcg.Rows.Count > 0 Then
                For Each fila As DataRow In dtbDscRcg.Rows
                    obj_DscRcgGlobal = New DTEDefTypeDocumentoDscRcgGlobal
                    obj_DscRcgGlobal.NroLinDR = fila.Item("NroLinDR")

                    obj_DscRcgGlobal.TpoMov = [Enum].Parse(GetType(DTEDefTypeDocumentoDscRcgGlobalTpoMov), fila.Item("TpoMov"))

                    If fila.Item("TpoValor").ToString().Trim() = "%" Then
                        obj_DscRcgGlobal.TpoValor = DineroPorcentajeType.Item
                    ElseIf fila.Item("TpoValor").ToString().Trim() = "$" Then
                        obj_DscRcgGlobal.TpoValor = DineroPorcentajeType.Item1
                    End If

                    obj_DscRcgGlobal.ValorDR = Convert.ToDecimal(fila.Item("ValorDR"))

                    listaDscRcgGlobal.Add(obj_DscRcgGlobal)

                Next

                obj_documento.DscRcgGlobal = listaDscRcgGlobal.ToArray()

                If CodRef = DTEDefTypeDocumentoReferenciaCodRef.Item3 AndAlso listaDscRcgGlobal.Count > 0 Then
                    Dim porcDescuentoRecargoGlobal As Double = listaDscRcgGlobal.Item(0).ValorDR

                    If listaDscRcgGlobal.Item(0).TpoMov = DTEDefTypeDocumentoDscRcgGlobalTpoMov.D Then 'Descuento Global
                        obj_documento.Encabezado.Totales.MntNeto = Math.Round(Convert.ToInt32(obj_documento.Encabezado.Totales.MntNeto) - (Convert.ToInt32(obj_documento.Encabezado.Totales.MntNeto) * (porcDescuentoRecargoGlobal / 100)))

                    ElseIf listaDscRcgGlobal.Item(0).TpoMov = DTEDefTypeDocumentoDscRcgGlobalTpoMov.R Then  'Recargo Global
                        obj_documento.Encabezado.Totales.MntNeto = Math.Round(Convert.ToInt32(obj_documento.Encabezado.Totales.MntNeto) + (Convert.ToInt32(obj_documento.Encabezado.Totales.MntNeto) * (porcDescuentoRecargoGlobal / 100)))

                    End If

                    obj_documento.Encabezado.Totales.IVA = Convert.ToInt32(Convert.ToInt32(obj_documento.Encabezado.Totales.MntNeto) * 0.19)
                    obj_documento.Encabezado.Totales.MntTotal = Convert.ToInt32(obj_documento.Encabezado.Totales.MntNeto) + Convert.ToInt32(obj_documento.Encabezado.Totales.IVA)

                End If
            End If

        End If

        obj_DTE.Item = obj_documento

        Dim string_documento As String = func_SerializarObjeto(obj_DTE, GetType(DTEDefType), System.Text.Encoding.UTF8)
        string_documento = string_documento.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
        string_documento = string_documento.Replace(vbCrLf & "<DTE ", "<DTE ")

        Me.strEnvioXML = string_documento.ToString()
        obj_envelopeProcesarWSMasivo.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)

        Me.urlDescarga = ""
        Me.strErrorProcesar = ""
        Me.strTrackId = ""
        Me.bolResultadoEnvio = False

        Dim resultado As String = postProcesarWSMasivo(obj_envelopeProcesarWSMasivo)
        Me.strRespuestaXML = resultado.ToString()

        Dim obj_reponseProcesar As APIDESIS.EnvelopeResponseProcesarWSMasivo = Nothing
        func_DeserializarObjeto(resultado, GetType(APIDESIS.EnvelopeResponseProcesarWSMasivo), obj_reponseProcesar)

        Dim xml_responseProcesar As Xml.XmlDocument = New Xml.XmlDocument()

        Try
            xml_responseProcesar.LoadXml(obj_reponseProcesar.Body.ProcesarWSMasivoResponse.ProcesarWSMasivoResult)
            '<?xml version="1.0"?><WSPLANO><Resultado>True</Resultado><Mensaje>Proceso exitoso.</Mensaje><TrackId>38</TrackId></WSPLANO>

            bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
            If xml_responseProcesar.GetElementsByTagName("TrackId").Count > 0 Then
                str_trackId = xml_responseProcesar.GetElementsByTagName("TrackId").Item(0).InnerText
            End If

            If bol_Resultado = False Then
                errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
                Me.strErrorProcesar = errorRespuesta
                Me.bolResultadoEnvio = False
            Else
                Me.strErrorProcesar = ""
                Me.bolResultadoEnvio = True
            End If

        Catch ex As Exception
            Me.bolResultadoEnvio = False
        End Try

        Return str_trackId
    End Function

    Public Function generarBoleta(ByRef empresa As pos_empresaDteRow, ByRef cabecera As pos_documentoCabRow, ByRef detalle As pos_documentoDetDataTable,
                                  ByVal idSucursalDTE As Integer, ByVal nombreTienda As String, ByVal nombreVendedor As String, ByVal codigoCondicionPagoDESIS As DTEDefTypeDocumentoEncabezadoIdDocFmaPago, ByVal nombreCondicionPago As String,
                                  ByVal numeroOC As String, ByVal numeroHES As String, ByVal IdCaja As String, ByVal nombreCajero As String, ByVal direccionSucursal As String) As Int64
        Dim obj_envelopeProcesar As APIDESIS.EnvelopeProcesar = New APIDESIS.EnvelopeProcesar()
        Dim obj_BOLETA As BOLETADefType = New BOLETADefType()
        Dim bol_Resultado As Boolean
        Dim str_folio As String
        Dim errorRespuesta As String = ""
        Dim url_original As String = ""
        Dim tipoDTE As Integer = 39
        Dim folioDTE As Integer = 0
        Dim fechaActual As String = Format(Now, "dd-MM-yyyy")

        Dim obj_documento As BOLETADefTypeDocumento = New BOLETADefTypeDocumento

        obj_envelopeProcesar.Body.Procesar.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
        obj_envelopeProcesar.Body.Procesar.login.Rut = Me.rut '"MS05"
        obj_envelopeProcesar.Body.Procesar.login.Clave = Me.password '"cGxhbm85MTA5OA=="
        obj_envelopeProcesar.Body.Procesar.login.Puerto = Me.puerto '"MA=="
        obj_envelopeProcesar.Body.Procesar.login.IncluyeLink = Me.incluyeLink.ToString() '1
        obj_envelopeProcesar.Body.Procesar.formato = 2 'XML

        obj_documento.ID = "F1T" & tipoDTE.ToString()
        obj_documento.Encabezado = New BOLETADefTypeDocumentoEncabezado
        obj_documento.Encabezado.Emisor = New BOLETADefTypeDocumentoEncabezadoEmisor

        obj_documento.Encabezado.IdDoc = New BOLETADefTypeDocumentoEncabezadoIdDoc
        obj_documento.Encabezado.IdDoc.TipoDTE = DTE.DTEType.Item33
        obj_documento.Encabezado.IdDoc.Folio = folioDTE.ToString()
        obj_documento.Encabezado.IdDoc.FchEmis = Format(Now(), "yyyy-MM-dd") '"2008-04-09"

        obj_documento.Encabezado.Emisor = New BOLETADefTypeDocumentoEncabezadoEmisor
        obj_documento.Encabezado.Emisor.RUTEmisor = empresa.RUTEmisor.Trim() '"77307757-6"
        obj_documento.Encabezado.Emisor.RznSocEmisor = empresa.RznSocEmisor.Trim() '"CAREN SPA"
        obj_documento.Encabezado.Emisor.GiroEmisor = empresa.GiroEmisor.Trim() '"VENTA DE PARTES, PIEZAS Y ACCESORIOS PARA VEHICULOS AUTOMOTORES"
        obj_documento.Encabezado.Emisor.DirOrigen = empresa.DirOrigen.Trim() '"Obispo Umaña 1042"
        obj_documento.Encabezado.Emisor.CmnaOrigen = empresa.CmnaOrigen.Trim() '"Estación Central"
        obj_documento.Encabezado.Emisor.CiudadOrigen = empresa.CiudadOrigen.Trim() '"SANTIAGO"
        obj_documento.Encabezado.Emisor.Sucursal = idSucursalDTE.ToString()

        obj_documento.Encabezado.Receptor = New BOLETADefTypeDocumentoEncabezadoReceptor
        If cabecera.Item("dpc_rutClienteBoleta").ToString().Trim() = "" Then
            obj_documento.Encabezado.Receptor.RUTRecep = "66666666-6" 'Rut cliente genérico SII
        Else
            obj_documento.Encabezado.Receptor.RUTRecep = cabecera.Item("dpc_rutClienteBoleta").ToString().Trim()
        End If

        obj_documento.Encabezado.Receptor.CdgIntRecep = cabecera.Item("cli_id").ToString().Trim() '"15915915"
        obj_documento.Encabezado.Receptor.RznSocRecep = cabecera.Item("dpc_nombreClienteBoleta").ToString().Trim() '"SERVICIOS GRAFICOS"
        obj_documento.Encabezado.Receptor.DirRecep = ""
        obj_documento.Encabezado.Receptor.CmnaRecep = ""
        obj_documento.Encabezado.Receptor.CiudadRecep = ""

        obj_documento.Encabezado.Totales = New BOLETADefTypeDocumentoEncabezadoTotales
        obj_documento.Encabezado.Totales.MntNeto = cabecera.dpc_totalNeto.ToString()
        obj_documento.Encabezado.Totales.IVA = cabecera.dpc_totalIva.ToString()
        obj_documento.Encabezado.Totales.MntTotal = cabecera.dpc_totalFinal.ToString()
        obj_documento.Encabezado.Totales.TotalPeriodo = cabecera.dpc_totalFinal.ToString()

        obj_documento.Adicional = New caja2.BOLETAS.DTEDocumentoAdicional
        obj_documento.Adicional.NodosA = New caja2.BOLETAS.DTEDocumentoAdicionalNodosA()
        obj_documento.Adicional.NodosA.A1 = Format(Now(), "yyyy-MM-dd") 'Vencimiento"
        obj_documento.Adicional.NodosA.A2 = nombreCondicionPago.ToString().Trim()  'Cond. de Pago"
        obj_documento.Adicional.NodosA.A3 = nombreVendedor.ToString().Trim() 'Vendedor"
        obj_documento.Adicional.NodosA.A4 = nombreTienda.ToString().Trim() 'Local"
        obj_documento.Adicional.NodosA.A5 = IIf(cabecera.Isdpc_telefonoClienteBoletaNull = True, "", cabecera.Item("dpc_telefonoClienteBoleta").ToString().Trim())
        obj_documento.Adicional.NodosA.A6 = "" 'OC"
        obj_documento.Adicional.NodosA.A7 = cabecera.Item("dpc_numDocOrigen").ToString().Trim 'Nro Nota Venta / Nro Orden de Servicio
        obj_documento.Adicional.NodosA.A8 = IdCaja 'ID Caja
        obj_documento.Adicional.NodosA.A9 = nombreCajero 'Cod.Cliente
        obj_documento.Adicional.NodosA.A10 = nombreTienda.ToString().Trim() 'Sucursal
        obj_documento.Adicional.NodosA.A11 = cabecera.dpc_fecha.ToString("HH:mm:ss")

        Dim listaDetalle As List(Of BOLETADefTypeDocumentoDetalle) = New List(Of BOLETADefTypeDocumentoDetalle)
        Dim obj_detalle As BOLETADefTypeDocumentoDetalle = Nothing
        Dim obj_detalleCdgItem As BOLETADefTypeDocumentoDetalleCdgItem = Nothing

        Dim NumItem As Integer = 1

        For Each filaDet As pos_documentoDetRow In detalle.Rows

            obj_detalle = New BOLETADefTypeDocumentoDetalle
            obj_detalleCdgItem = New BOLETADefTypeDocumentoDetalleCdgItem
            obj_detalle.NroLinDet = NumItem
            obj_detalleCdgItem.TpoCodigo = "INT1"
            obj_detalleCdgItem.VlrCodigo = filaDet.rp_codigo.ToString.Trim 'Código producto
            obj_detalle.CdgItem = (New List(Of BOLETADefTypeDocumentoDetalleCdgItem) From {obj_detalleCdgItem}).ToArray()
            obj_detalle.NmbItem = filaDet.rp_descripcion.ToString.Trim
            obj_detalle.DscItem = ""
            obj_detalle.QtyItem = Convert.ToDecimal(filaDet.dpd_cantidad)
            obj_detalle.QtyItemSpecified = True
            obj_detalle.UnmdItem = "UN"
            obj_detalle.PrcItem = Convert.ToDecimal(filaDet.dpd_precio)
            obj_detalle.PrcItemSpecified = True
            obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(filaDet.dpd_total), 0)

            listaDetalle.Add(obj_detalle)

            NumItem = NumItem + 1

        Next

        obj_documento.Detalle = listaDetalle.ToArray()

        If numeroOC <> "" OrElse numeroHES <> "" Then
            Dim listaReferencia As List(Of BOLETADefTypeDocumentoReferencia) = New List(Of BOLETADefTypeDocumentoReferencia)
            Dim obj_referencia As BOLETADefTypeDocumentoReferencia = Nothing

            If numeroOC <> "" Then
                obj_referencia = New BOLETADefTypeDocumentoReferencia
                obj_referencia.NroLinRef = listaReferencia.Count + 1
                obj_referencia.CodRef = "801"
                obj_referencia.TpoDocRef = "801"
                obj_referencia.FolioRef = numeroOC
                obj_referencia.RazonRef = "ORDEN DE COMPRA"
                listaReferencia.Add(obj_referencia)
            End If

            If numeroHES <> "" Then
                obj_referencia = New BOLETADefTypeDocumentoReferencia
                obj_referencia.NroLinRef = listaReferencia.Count + 1
                obj_referencia.CodRef = "802"
                obj_referencia.TpoDocRef = "802"
                obj_referencia.FolioRef = numeroHES
                obj_referencia.RazonRef = "NOTA DE PEDIDO"
                listaReferencia.Add(obj_referencia)
            End If

            obj_documento.Referencia = listaReferencia.ToArray()
        End If

        obj_BOLETA.Documento = obj_documento

        Dim string_documento As String = func_SerializarObjeto(obj_BOLETA, GetType(BOLETADefType), System.Text.Encoding.UTF8)
        string_documento = string_documento.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
        string_documento = string_documento.Replace("xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ", "")
        string_documento = string_documento.Replace("xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ", "")
        string_documento = string_documento.Replace(vbCrLf & "<DTE ", "<DTE ")

        Me.strEnvioXML = string_documento.ToString()
        obj_envelopeProcesar.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)

        Me.urlDescarga = ""
        Me.strErrorProcesar = ""

        Dim resultado As String = postProcesar(obj_envelopeProcesar)
        Me.strRespuestaXML = resultado.ToString()

        Dim obj_reponseProcesar As EnvelopeResponseProcesar = Nothing
        func_DeserializarObjeto(resultado, GetType(EnvelopeResponseProcesar), obj_reponseProcesar)

        Dim xml_responseProcesar As Xml.XmlDocument = New Xml.XmlDocument()
        xml_responseProcesar.LoadXml(CType(obj_reponseProcesar.Body.ProcesarResponse.ProcesarResult, Xml.XmlNode())(0).InnerText)

        bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
        str_folio = xml_responseProcesar.GetElementsByTagName("Folio").Item(0).InnerText

        If bol_Resultado = False Then
            errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
            Me.strErrorProcesar = errorRespuesta
            Me.bolResultadoEnvio = False

        Else
            Me.urlDescarga = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlOriginal").Item(0).InnerText)
            Me.strErrorProcesar = ""
            Me.bolResultadoEnvio = True

        End If

        Return str_folio

    End Function

    Public Function generarFactura(ByRef empresa As pos_empresaDteRow, ByRef cabecera As pos_documentoCabRow, ByRef detalle As pos_documentoDetDataTable,
                                   ByVal idSucursalDTE As Integer, ByVal nombreTienda As String, ByVal nombreVendedor As String, ByVal codigoCondicionPagoDESIS As DTEDefTypeDocumentoEncabezadoIdDocFmaPago, ByVal nombreCondicionPago As String,
                                   ByVal fechaVencimiento As Date, ByVal numeroOC As String, ByVal numeroHES As String, ByVal fechaReferencia As Date, ByVal direccionFacturacion As String, ByVal comunaFacturacion As String,
                                   ByVal ciudadFacturacion As String) As Int64
        Dim obj_envelopeProcesar As APIDESIS.EnvelopeProcesar = New APIDESIS.EnvelopeProcesar()
        Dim obj_envelopeProcesarWSMasivo As APIDESIS.EnvelopeProcesarWSMasivo = New APIDESIS.EnvelopeProcesarWSMasivo()
        Dim obj_DTE As DTEDefType = New DTEDefType()
        Dim bol_Resultado As Boolean
        Dim str_folio As String
        Dim errorRespuesta As String = ""
        Dim url_tributaria As String = ""
        Dim url_cedible As String = ""
        Dim tipoDTE As Integer = 33
        Dim folioDTE As Integer = 0
        Dim fechaActual As String = Format(Now, "dd-MM-yyyy")

        Dim obj_documento As DTEDefTypeDocumento = New DTEDefTypeDocumento()

        obj_envelopeProcesar.Body.Procesar.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
        obj_envelopeProcesar.Body.Procesar.login.Rut = Me.rut '"MS05"
        obj_envelopeProcesar.Body.Procesar.login.Clave = Me.password '"cGxhbm85MTA5OA=="
        obj_envelopeProcesar.Body.Procesar.login.Puerto = Me.puerto '"MA=="
        obj_envelopeProcesar.Body.Procesar.login.IncluyeLink = Me.incluyeLink.ToString() '11
        obj_envelopeProcesar.Body.Procesar.formato = 2 'XML

        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Rut = Me.rut '"MS05"
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Clave = Me.password '"cGxhbm85MTA5OA=="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.Puerto = Me.puerto '"MA=="
        obj_envelopeProcesarWSMasivo.Body.Procesar.login.IncluyeLink = Me.incluyeLink.ToString() '11
        obj_envelopeProcesarWSMasivo.Body.Procesar.formato = 2 'XML

        obj_documento.ID = "F" & folioDTE.ToString() & "T" & tipoDTE.ToString()
        obj_documento.Encabezado = New DTEDefTypeDocumentoEncabezado()
        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()

        obj_documento.Encabezado.IdDoc = New DTEDefTypeDocumentoEncabezadoIdDoc()
        obj_documento.Encabezado.IdDoc.TipoDTE = DTE.DTEType.Item33
        obj_documento.Encabezado.IdDoc.Folio = folioDTE.ToString()
        obj_documento.Encabezado.IdDoc.FchEmis = Format(Now(), "yyyy-MM-dd") '"2008-04-09"
        obj_documento.Encabezado.IdDoc.FmaPago = codigoCondicionPagoDESIS
        obj_documento.Encabezado.IdDoc.FmaPagoSpecified = True
        obj_documento.Encabezado.IdDoc.FchVenc = fechaVencimiento
        obj_documento.Encabezado.IdDoc.FchVencSpecified = True

        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()
        obj_documento.Encabezado.Emisor.RUTEmisor = empresa.RUTEmisor.Trim() ' "77307757-6"
        obj_documento.Encabezado.Emisor.RznSoc = empresa.RznSocEmisor.Trim() '"CAREN SPA"
        obj_documento.Encabezado.Emisor.GiroEmis = empresa.GiroEmisor.Trim() '"VENTA DE PARTES, PIEZAS Y ACCESORIOS PARA VEHICULOS AUTOMOTORES"
        obj_documento.Encabezado.Emisor.Acteco = New String() {empresa.Acteco.ToString().Trim()} '"453000"
        obj_documento.Encabezado.Emisor.DirOrigen = empresa.DirOrigen.Trim() '"Obispo Umaña 1042"
        obj_documento.Encabezado.Emisor.CmnaOrigen = empresa.CmnaOrigen.Trim() '"Estación Central"
        obj_documento.Encabezado.Emisor.CiudadOrigen = empresa.CiudadOrigen.Trim() '"SANTIAGO"
        obj_documento.Encabezado.Emisor.Sucursal = idSucursalDTE.ToString()

        obj_documento.Encabezado.Receptor = New DTEDefTypeDocumentoEncabezadoReceptor()
        obj_documento.Encabezado.Receptor.RUTRecep = cabecera.Item("dpc_rut").ToString().Trim()  '"15915915-9"
        obj_documento.Encabezado.Receptor.CdgIntRecep = cabecera.Item("cli_id").ToString().Trim() '"15915915"
        obj_documento.Encabezado.Receptor.RznSocRecep = cabecera.Item("dpc_nombre").ToString().Trim() '"SERVICIOS GRAFICOS"

        If cabecera.Item("dpc_giroFacturacion").ToString().Trim().Length > 40 Then
            obj_documento.Encabezado.Receptor.GiroRecep = cabecera.Item("dpc_giroFacturacion").ToString().Trim().Substring(0, 40)
        Else
            obj_documento.Encabezado.Receptor.GiroRecep = cabecera.Item("dpc_giroFacturacion").ToString().Trim() '"SERVICIO"
        End If

        obj_documento.Encabezado.Receptor.DirRecep = direccionFacturacion.ToString().Trim() 'cabecera.Item("dpc_direccionFacturacion").ToString().Trim() '"DEPARTAMENTAL 250"
        obj_documento.Encabezado.Receptor.CmnaRecep = comunaFacturacion.ToString().Trim() 'cabecera.Item("dpc_nombreComunaFacturacion").ToString().Trim() ' "SAN JOAQUIN"
        obj_documento.Encabezado.Receptor.CiudadRecep = ciudadFacturacion.ToString().Trim() 'cabecera.Item("dpc_nombreCiudadFacturacion").ToString().Trim()  '"SANTIAGO"

        obj_documento.Encabezado.Totales = New DTEDefTypeDocumentoEncabezadoTotales()
        obj_documento.Encabezado.Totales.MntNeto = cabecera.dpc_totalNeto.ToString()
        obj_documento.Encabezado.Totales.TasaIVA = Convert.ToDecimal("19")
        obj_documento.Encabezado.Totales.TasaIVASpecified = True
        obj_documento.Encabezado.Totales.IVA = cabecera.dpc_totalIva.ToString()
        obj_documento.Encabezado.Totales.MntTotal = cabecera.dpc_totalFinal.ToString()

        obj_documento.Adicional = New caja2.DTE.DTEDocumentoAdicional
        obj_documento.Adicional.NodosA = New caja2.DTE.DTEDocumentoAdicionalNodosA()
        obj_documento.Adicional.NodosA.A1 = Format(fechaVencimiento, "dd-MM-yyyy") 'Vencimiento"
        obj_documento.Adicional.NodosA.A2 = nombreCondicionPago.ToString().Trim()  'Cond. de Pago"
        obj_documento.Adicional.NodosA.A3 = nombreVendedor.ToString().Trim() 'Vendedor"
        obj_documento.Adicional.NodosA.A4 = nombreTienda.ToString().Trim() 'Local"
        obj_documento.Adicional.NodosA.A5 = cabecera.Item("dpc_telefonoFacturacion").ToString().Trim()
        obj_documento.Adicional.NodosA.A6 = numeroOC.ToString().Trim() 'OC
        obj_documento.Adicional.NodosA.A7 = cabecera.Item("dpc_numDocOrigen").ToString().Trim() 'Nro Nota Venta / Nro Orden de Servicio"
        obj_documento.Adicional.NodosA.A8 = "" 'Observaciones"
        obj_documento.Adicional.NodosA.A9 = cabecera.cli_id.ToString() 'Cod.Cliente"

        Dim listaDetalle As List(Of DTEDefTypeDocumentoDetalle) = New List(Of DTEDefTypeDocumentoDetalle)
        Dim obj_detalle As DTEDefTypeDocumentoDetalle = Nothing
        Dim obj_detalleCdgItem As DTEDefTypeDocumentoDetalleCdgItem = Nothing

        Dim NumItem As Integer = 1

        For Each filaDet As pos_documentoDetRow In detalle.Rows

            obj_detalle = New DTEDefTypeDocumentoDetalle()
            obj_detalleCdgItem = New DTEDefTypeDocumentoDetalleCdgItem
            obj_detalle.NroLinDet = NumItem
            obj_detalleCdgItem.TpoCodigo = "INT1"
            obj_detalleCdgItem.VlrCodigo = filaDet.rp_codigo.ToString.Trim 'Código producto
            obj_detalle.CdgItem = (New List(Of DTEDefTypeDocumentoDetalleCdgItem) From {obj_detalleCdgItem}).ToArray()
            obj_detalle.NmbItem = filaDet.rp_descripcion.ToString.Trim
            obj_detalle.DscItem = ""
            obj_detalle.QtyItem = Convert.ToDecimal(filaDet.dpd_cantidad)
            obj_detalle.QtyItemSpecified = True
            obj_detalle.UnmdItem = "UN"
            obj_detalle.PrcItem = Convert.ToDecimal(filaDet.dpd_precioUnitarioNetoFinal)
            obj_detalle.PrcItemSpecified = True
            obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(filaDet.dpd_totalNetoFinal), 0)

            listaDetalle.Add(obj_detalle)

            NumItem = NumItem + 1

        Next

        obj_documento.Detalle = listaDetalle.ToArray()

        If numeroOC <> "" OrElse numeroHES <> "" Then
            Dim listaReferencia As List(Of DTEDefTypeDocumentoReferencia) = New List(Of DTEDefTypeDocumentoReferencia)
            Dim obj_referencia As DTEDefTypeDocumentoReferencia = New DTEDefTypeDocumentoReferencia

            If numeroOC <> "" Then
                obj_referencia = New DTEDefTypeDocumentoReferencia
                obj_referencia.NroLinRef = listaReferencia.Count + 1
                obj_referencia.TpoDocRef = "801"
                obj_referencia.FolioRef = numeroOC
                obj_referencia.RazonRef = "" 'ORDEN DE COMPRA
                obj_referencia.FchRef = fechaReferencia
                listaReferencia.Add(obj_referencia)
            End If

            If numeroHES <> "" Then
                obj_referencia = New DTEDefTypeDocumentoReferencia
                obj_referencia.NroLinRef = listaReferencia.Count + 1
                obj_referencia.TpoDocRef = "802"
                obj_referencia.FolioRef = numeroHES
                obj_referencia.RazonRef = "NOTA DE PEDIDO"
                obj_referencia.FchRef = fechaReferencia
                listaReferencia.Add(obj_referencia)
            End If

            obj_documento.Referencia = listaReferencia.ToArray()
        End If

        obj_DTE.Item = obj_documento

        Dim string_documento As String = func_SerializarObjeto(obj_DTE, GetType(DTEDefType), System.Text.Encoding.UTF8)
        string_documento = string_documento.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
        string_documento = string_documento.Replace(vbCrLf & "<DTE ", "<DTE ")

        Me.strEnvioXML = string_documento.ToString()
        obj_envelopeProcesar.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)
        obj_envelopeProcesarWSMasivo.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)

        Me.urlDescarga = ""
        Me.strErrorProcesar = ""

        Dim resultado As String = postProcesar(obj_envelopeProcesar)
        Me.strRespuestaXML = resultado.ToString()

        Dim obj_reponseProcesar As EnvelopeResponseProcesar = Nothing
        func_DeserializarObjeto(resultado, GetType(EnvelopeResponseProcesar), obj_reponseProcesar)

        Dim xml_responseProcesar As Xml.XmlDocument = New Xml.XmlDocument()
        xml_responseProcesar.LoadXml(CType(obj_reponseProcesar.Body.ProcesarResponse.ProcesarResult, Xml.XmlNode())(0).InnerText)
        '<?xml version="1.0"?><WSPLANO><Resultado>True</Resultado><Mensaje>Proceso exitoso.</Mensaje><Detalle><Documento><Folio>9920019856</Folio><TipoDte>33</TipoDte><Operacion>VENTA</Operacion><Fecha>2022-04-11T13:35:10</Fecha><Resultado>True</Resultado><urlOriginal>aHR0cDovL3d3dy5mYWN0dXJhY2lvbi5jbC9wbGFuby9kZXNjYXJnYXIucGhwP3AxPWY2OTQ4NjE1ZDgmcDI9R0RJJm09ViZpPTEzMDI4NTEmYz1mYWxzZQ==</urlOriginal><urlCedible>aHR0cDovL3d3dy5mYWN0dXJhY2lvbi5jbC9wbGFuby9kZXNjYXJnYXIucGhwP3AxPWRiYzBhMzEzZmMmcDI9R0RJJm09ViZpPTEzMDI4NTEmYz10cnVl</urlCedible></Documento></Detalle></WSPLANO>

        bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
        str_folio = xml_responseProcesar.GetElementsByTagName("Folio").Item(0).InnerText

        If bol_Resultado = False Then
            errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
            Me.strErrorProcesar = errorRespuesta
            Me.bolResultadoEnvio = False
        Else
            url_tributaria = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlOriginal").Item(0).InnerText)
            url_cedible = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlCedible").Item(0).InnerText)
            Me.urlDescarga = url_tributaria
            Me.strErrorProcesar = ""
            Me.bolResultadoEnvio = True
        End If

        Return str_folio
    End Function

    Public Function generarNotaCredito(ByRef empresa As pos_empresaDteRow, ByRef cabecera As pos_documentoCabRow, ByRef detalle As pos_documentoDetDataTable,
                                       ByVal idSucursalDTE As Integer, ByVal nombreTienda As String, ByVal nombreVendedor As String, ByVal codigoCondicionPagoDESIS As DTEDefTypeDocumentoEncabezadoIdDocFmaPago, ByVal nombreCondicionPago As String,
                                       ByVal tipoDteRef As Integer, ByVal folioDteRef As Long, ByVal CodRef As DTEDefTypeDocumentoReferenciaCodRef, ByVal numDocOrigen As Integer) As Int64

        Dim obj_envelopeProcesar As APIDESIS.EnvelopeProcesar = New APIDESIS.EnvelopeProcesar()
        Dim obj_DTE As DTEDefType = New DTEDefType()
        Dim bol_Resultado As Boolean
        Dim str_folio As String
        Dim errorRespuesta As String = ""
        Dim url_tributaria As String = ""
        Dim url_cedible As String = ""
        Dim tipoDTE As Integer = 61
        Dim folioDTE As Integer = 0
        Dim fechaActual As String = Format(Now, "dd-MM-yyyy")

        Dim obj_documento As DTEDefTypeDocumento = New DTEDefTypeDocumento()

        obj_envelopeProcesar.Body.Procesar.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
        obj_envelopeProcesar.Body.Procesar.login.Rut = Me.rut '"MS05"
        obj_envelopeProcesar.Body.Procesar.login.Clave = Me.password '"cGxhbm85MTA5OA=="
        obj_envelopeProcesar.Body.Procesar.login.Puerto = Me.puerto '"MA=="
        obj_envelopeProcesar.Body.Procesar.login.IncluyeLink = Me.incluyeLink.ToString() '11
        obj_envelopeProcesar.Body.Procesar.formato = 2 'XML

        obj_documento.ID = "F" & folioDTE.ToString() & "T" & tipoDTE.ToString()
        obj_documento.Encabezado = New DTEDefTypeDocumentoEncabezado()
        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()

        obj_documento.Encabezado.IdDoc = New DTEDefTypeDocumentoEncabezadoIdDoc()
        obj_documento.Encabezado.IdDoc.TipoDTE = DTE.DTEType.Item61
        obj_documento.Encabezado.IdDoc.Folio = folioDTE.ToString()
        obj_documento.Encabezado.IdDoc.FchEmis = Format(Now(), "yyyy-MM-dd") '"2008-04-09"
        obj_documento.Encabezado.IdDoc.FmaPago = codigoCondicionPagoDESIS
        obj_documento.Encabezado.IdDoc.FmaPagoSpecified = True
        obj_documento.Encabezado.IdDoc.MntBruto = DTEDefTypeDocumentoEncabezadoIdDocMntBruto.Item1
        obj_documento.Encabezado.IdDoc.MntBrutoSpecified = True

        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()
        obj_documento.Encabezado.Emisor.RUTEmisor = empresa.RUTEmisor.Trim() ' "77307757-6"
        obj_documento.Encabezado.Emisor.RznSoc = empresa.RznSocEmisor.Trim() '"CAREN SPA"
        obj_documento.Encabezado.Emisor.GiroEmis = empresa.GiroEmisor.Trim() '"VENTA DE PARTES, PIEZAS Y ACCESORIOS PARA VEHICULOS AUTOMOTORES"
        obj_documento.Encabezado.Emisor.Acteco = New String() {empresa.Acteco.ToString().Trim()} '"453000"
        obj_documento.Encabezado.Emisor.DirOrigen = empresa.DirOrigen.Trim() '"Obispo Umaña 1042"
        obj_documento.Encabezado.Emisor.CmnaOrigen = empresa.CmnaOrigen.Trim() '"Estación Central"
        obj_documento.Encabezado.Emisor.CiudadOrigen = empresa.CiudadOrigen.Trim() '"SANTIAGO"
        obj_documento.Encabezado.Emisor.Sucursal = idSucursalDTE.ToString()

        obj_documento.Encabezado.Receptor = New DTEDefTypeDocumentoEncabezadoReceptor()
        obj_documento.Encabezado.Receptor.RUTRecep = cabecera.dpc_rut.ToString().Trim()  '"15915915-9"
        obj_documento.Encabezado.Receptor.CdgIntRecep = cabecera.cli_id.ToString() '"15915915"
        obj_documento.Encabezado.Receptor.RznSocRecep = cabecera.Item("dpc_nombre").ToString().Trim() '"SERVICIOS GRAFICOS"

        If cabecera.Item("dpc_giroFacturacion").ToString().Trim().Length > 40 Then
            obj_documento.Encabezado.Receptor.GiroRecep = cabecera.Item("dpc_giroFacturacion").ToString().Trim().Substring(0, 40)
        Else
            obj_documento.Encabezado.Receptor.GiroRecep = cabecera.Item("dpc_giroFacturacion").ToString().Trim() '"SERVICIO"
        End If

        obj_documento.Encabezado.Receptor.DirRecep = cabecera.Item("dpc_direccionFacturacion").ToString().Trim() '"DEPARTAMENTAL 250"
        obj_documento.Encabezado.Receptor.CmnaRecep = cabecera.Item("dpc_nombreComunaFacturacion").ToString().Trim() ' "SAN JOAQUIN"
        obj_documento.Encabezado.Receptor.CiudadRecep = cabecera.Item("dpc_nombreCiudadFacturacion").ToString().Trim()  '"SANTIAGO"

        obj_documento.Encabezado.Totales = New DTEDefTypeDocumentoEncabezadoTotales()
        obj_documento.Encabezado.Totales.MntNeto = cabecera.dpc_totalNeto.ToString()
        obj_documento.Encabezado.Totales.TasaIVA = Convert.ToDecimal("19")
        obj_documento.Encabezado.Totales.TasaIVASpecified = True
        obj_documento.Encabezado.Totales.IVA = cabecera.dpc_totalIva.ToString()
        obj_documento.Encabezado.Totales.MntTotal = cabecera.dpc_totalFinal.ToString()

        obj_documento.Adicional = New caja2.DTE.DTEDocumentoAdicional
        obj_documento.Adicional.NodosA = New caja2.DTE.DTEDocumentoAdicionalNodosA()
        obj_documento.Adicional.NodosA.A1 = Format(Now(), "yyyy-MM-dd") 'Vencimiento"
        obj_documento.Adicional.NodosA.A2 = nombreCondicionPago.ToString().Trim()  'Cond. de Pago"
        obj_documento.Adicional.NodosA.A3 = nombreVendedor.ToString().Trim() 'Vendedor"
        obj_documento.Adicional.NodosA.A4 = nombreTienda.ToString().Trim() 'Local"
        obj_documento.Adicional.NodosA.A5 = cabecera.Item("dpc_telefonoFacturacion").ToString()
        obj_documento.Adicional.NodosA.A6 = "" 'OC"
        obj_documento.Adicional.NodosA.A7 = numDocOrigen.ToString() 'Nro Nota Venta / Nro Orden de Servicio"
        obj_documento.Adicional.NodosA.A8 = "" 'Observaciones"
        obj_documento.Adicional.NodosA.A9 = cabecera.cli_id.ToString() 'Cod.Cliente"

        Dim listaDetalle As List(Of DTEDefTypeDocumentoDetalle) = New List(Of DTEDefTypeDocumentoDetalle)
        Dim obj_detalle As DTEDefTypeDocumentoDetalle = Nothing
        Dim obj_detalleCdgItem As DTEDefTypeDocumentoDetalleCdgItem = Nothing

        Dim NumItem As Integer = 1

        For Each filaDet As pos_documentoDetRow In detalle.Rows

            obj_detalle = New DTEDefTypeDocumentoDetalle()
            obj_detalleCdgItem = New DTEDefTypeDocumentoDetalleCdgItem
            obj_detalle.NroLinDet = NumItem
            obj_detalleCdgItem.TpoCodigo = "INT1"
            obj_detalleCdgItem.VlrCodigo = filaDet.rp_codigo.ToString.Trim 'Código producto
            obj_detalle.CdgItem = (New List(Of DTEDefTypeDocumentoDetalleCdgItem) From {obj_detalleCdgItem}).ToArray()
            obj_detalle.NmbItem = filaDet.rp_descripcion.ToString.Trim
            obj_detalle.DscItem = ""
            obj_detalle.QtyItem = Convert.ToDecimal(filaDet.dpd_cantidad)
            obj_detalle.QtyItemSpecified = True
            obj_detalle.UnmdItem = "UN"
            obj_detalle.PrcItem = Convert.ToDecimal(filaDet.dpd_precio)
            obj_detalle.PrcItemSpecified = True
            obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(filaDet.dpd_total), 0)

            listaDetalle.Add(obj_detalle)

            NumItem = NumItem + 1

        Next

        obj_documento.Detalle = listaDetalle.ToArray()

        Dim listaReferencia As List(Of DTEDefTypeDocumentoReferencia) = New List(Of DTEDefTypeDocumentoReferencia)
        Dim obj_referencia As DTEDefTypeDocumentoReferencia = New DTEDefTypeDocumentoReferencia

        obj_referencia.NroLinRef = 1
        obj_referencia.CodRef = CodRef
        obj_referencia.CodRefSpecified = True
        obj_referencia.TpoDocRef = tipoDteRef.ToString()
        obj_referencia.FolioRef = folioDteRef.ToString()
        obj_referencia.FchRef = Now.Date
        listaReferencia.Add(obj_referencia)

        obj_documento.Referencia = listaReferencia.ToArray()

        obj_DTE.Item = obj_documento

        Dim string_documento As String = func_SerializarObjeto(obj_DTE, GetType(DTEDefType), System.Text.Encoding.UTF8)
        string_documento = string_documento.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
        string_documento = string_documento.Replace(vbCrLf & "<DTE ", "<DTE ")

        Me.strEnvioXML = string_documento.ToString()
        obj_envelopeProcesar.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)

        Me.urlDescarga = ""
        Me.strErrorProcesar = ""
        Me.bolResultadoEnvio = False

        Dim resultado As String = postProcesar(obj_envelopeProcesar)
        Me.strRespuestaXML = resultado.ToString()

        Dim obj_reponseProcesar As EnvelopeResponseProcesar = Nothing
        func_DeserializarObjeto(resultado, GetType(EnvelopeResponseProcesar), obj_reponseProcesar)

        Dim xml_responseProcesar As Xml.XmlDocument = New Xml.XmlDocument()
        xml_responseProcesar.LoadXml(CType(obj_reponseProcesar.Body.ProcesarResponse.ProcesarResult, Xml.XmlNode())(0).InnerText)
        '<?xml version=""1.0""?><WSPLANO><Resultado>True</Resultado><Mensaje>Proceso exitoso.</Mensaje><Detalle><Documento><Folio>9999951525</Folio><TipoDte>61</TipoDte><Operacion>VENTA</Operacion><Fecha>2022-06-13T15:32:22</Fecha><Resultado>True</Resultado><urlOriginal>aHR0cDovL3d3dy5mYWN0dXJhY2lvbi5jbC9wbGFuby9kZXNjYXJnYXIucGhwP3AxPTkzNjAwZjI5NmUmcDI9R0RJJm09ViZpPTEzMTA4MDQmYz1mYWxzZQ==</urlOriginal></Documento></Detalle></WSPLANO>

        bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
        str_folio = xml_responseProcesar.GetElementsByTagName("Folio").Item(0).InnerText

        If bol_Resultado = False Then
            errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
            Me.strErrorProcesar = errorRespuesta
            Me.bolResultadoEnvio = False
        Else
            url_tributaria = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlOriginal").Item(0).InnerText)
            Me.urlDescarga = url_tributaria
            Me.strErrorProcesar = ""
            Me.bolResultadoEnvio = True
        End If

        Return str_folio
    End Function

    'Public Function generarFactura(ByRef empresa As pos_empresaDteRow, ByRef cabecera As web_notaVentaCabRow, ByRef detalle As web_notaVentaDetDataTable, ByVal idSucursalDTE As Integer, ByVal IDTienda As String, ByVal rutaAplicacion As String) As Int64
    '    Dim obj_envelopeProcesar As APIDESIS.EnvelopeProcesar = New APIDESIS.EnvelopeProcesar()
    '    Dim obj_DTE As DTEDefType = New DTEDefType()
    '    Dim bol_Resultado As Boolean
    '    Dim str_folio As String
    '    Dim errorRespuesta As String = ""
    '    Dim url_tributaria As String = ""
    '    Dim url_cedible As String = ""
    '    Dim tipoDTE As Integer = 33
    '    Dim folioDTE As Integer = 0
    '    Dim fechaActual As String = Format(Now(), "yyyy-MM-dd")

    '    Dim obj_documento As DTEDefTypeDocumento = New DTEDefTypeDocumento()

    '    obj_envelopeProcesar.Body.Procesar.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
    '    obj_envelopeProcesar.Body.Procesar.login.Rut = Me.rut '"MS05"
    '    obj_envelopeProcesar.Body.Procesar.login.Clave = Me.password '"cGxhbm85MTA5OA=="
    '    obj_envelopeProcesar.Body.Procesar.login.Puerto = Me.puerto '"MA=="
    '    obj_envelopeProcesar.Body.Procesar.login.IncluyeLink = Me.incluyeLink.ToString() '11
    '    obj_envelopeProcesar.Body.Procesar.formato = 2 'XML

    '    obj_documento.ID = "F1T" & tipoDTE.ToString()
    '    obj_documento.Encabezado = New DTEDefTypeDocumentoEncabezado()
    '    obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()

    '    obj_documento.Encabezado.IdDoc = New DTEDefTypeDocumentoEncabezadoIdDoc()
    '    obj_documento.Encabezado.IdDoc.TipoDTE = DTE.DTEType.Item33
    '    obj_documento.Encabezado.IdDoc.Folio = folioDTE.ToString()
    '    obj_documento.Encabezado.IdDoc.FchEmis = fechaActual '"2008-04-09"

    '    obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()
    '    obj_documento.Encabezado.Emisor.RUTEmisor = empresa.RUTEmisor.Trim() ' "77307757-6"
    '    obj_documento.Encabezado.Emisor.RznSoc = empresa.RznSocEmisor.Trim() '"CAREN SPA"
    '    obj_documento.Encabezado.Emisor.GiroEmis = empresa.GiroEmisor.Trim() '"VENTA DE PARTES, PIEZAS Y ACCESORIOS PARA VEHICULOS AUTOMOTORES"
    '    obj_documento.Encabezado.Emisor.Acteco = New String() {empresa.Acteco.ToString().Trim()} '"453000"
    '    obj_documento.Encabezado.Emisor.DirOrigen = empresa.DirOrigen.Trim() '"Obispo Umaña 1042"
    '    obj_documento.Encabezado.Emisor.CmnaOrigen = empresa.CmnaOrigen.Trim() '"Estación Central"
    '    obj_documento.Encabezado.Emisor.CiudadOrigen = empresa.CiudadOrigen.Trim() '"SANTIAGO"
    '    obj_documento.Encabezado.Emisor.Sucursal = idSucursalDTE.ToString()

    '    obj_documento.Encabezado.Receptor = New DTEDefTypeDocumentoEncabezadoReceptor()
    '    obj_documento.Encabezado.Receptor.RUTRecep = cabecera.nvc_rut.ToString().Trim()  '"15915915-9"
    '    obj_documento.Encabezado.Receptor.CdgIntRecep = cabecera.cli_id.ToString() '"15915915"
    '    obj_documento.Encabezado.Receptor.RznSocRecep = cabecera.nvc_nombre.ToString().Trim() '"SERVICIOS GRAFICOS"
    '    obj_documento.Encabezado.Receptor.GiroRecep = cabecera.nvc_giroFacturacion.ToString().Trim() '"SERVICIO"
    '    obj_documento.Encabezado.Receptor.DirRecep = cabecera.nvc_direccionFacturacion.ToString().Trim() '"DEPARTAMENTAL 250"
    '    obj_documento.Encabezado.Receptor.CmnaRecep = cabecera.nvc_nombreComunaFacturacion.ToString().Trim() ' "SAN JOAQUIN"
    '    obj_documento.Encabezado.Receptor.CiudadRecep = cabecera.nvc_nombreCiudadFacturacion.ToString().Trim()  '"SANTIAGO"

    '    obj_documento.Encabezado.Totales = New DTEDefTypeDocumentoEncabezadoTotales()
    '    obj_documento.Encabezado.Totales.MntNeto = cabecera.nvc_totalNeto.ToString()
    '    obj_documento.Encabezado.Totales.TasaIVA = Convert.ToDecimal("19")
    '    obj_documento.Encabezado.Totales.TasaIVASpecified = True
    '    obj_documento.Encabezado.Totales.IVA = cabecera.nvc_totalIva.ToString()
    '    obj_documento.Encabezado.Totales.MntTotal = cabecera.nvc_totalFinal.ToString()

    '    obj_documento.Adicional = New DTE.DTEDocumentoAdicional
    '    obj_documento.Adicional.NodosA = New DTE.DTEDocumentoAdicionalNodosA()
    '    obj_documento.Adicional.NodosA.A1 = Format(Now(), "yyyy-MM-dd") 'Vencimiento"
    '    obj_documento.Adicional.NodosA.A2 = "" 'Cond. de Pago"
    '    obj_documento.Adicional.NodosA.A3 = "" 'Vendedor"
    '    obj_documento.Adicional.NodosA.A4 = IDTienda.ToString() 'Local"
    '    obj_documento.Adicional.NodosA.A5 = cabecera.nvc_telefonoFacturacion.ToString().Trim()
    '    obj_documento.Adicional.NodosA.A6 = "" 'OC"
    '    obj_documento.Adicional.NodosA.A7 = cabecera.nvc_numero.ToString() 'Nro de Venta"
    '    obj_documento.Adicional.NodosA.A8 = "" 'Observaciones"
    '    obj_documento.Adicional.NodosA.A9 = cabecera.cli_id.ToString() 'CodC.liente"

    '    Dim listaDetalle As List(Of DTEDefTypeDocumentoDetalle) = New List(Of DTEDefTypeDocumentoDetalle)
    '    Dim obj_detalle As DTEDefTypeDocumentoDetalle = Nothing
    '    Dim obj_detalleCdgItem As DTEDefTypeDocumentoDetalleCdgItem = Nothing

    '    Dim NumItem As Integer = 1

    '    For Each filaDet As web_notaVentaDetRow In detalle.Rows

    '        obj_detalle = New DTEDefTypeDocumentoDetalle()
    '        obj_detalleCdgItem = New DTEDefTypeDocumentoDetalleCdgItem
    '        obj_detalle.NroLinDet = NumItem
    '        obj_detalleCdgItem.TpoCodigo = "INT1"
    '        obj_detalleCdgItem.VlrCodigo = filaDet.rp_codigo.ToString.Trim 'Código producto
    '        obj_detalle.CdgItem = (New List(Of DTEDefTypeDocumentoDetalleCdgItem) From {obj_detalleCdgItem}).ToArray()
    '        obj_detalle.NmbItem = filaDet.rp_descripcion.ToString.Trim
    '        obj_detalle.DscItem = ""
    '        obj_detalle.QtyItem = Convert.ToDecimal(filaDet.nvd_cantidad)
    '        obj_detalle.QtyItemSpecified = True
    '        obj_detalle.UnmdItem = "UN"
    '        obj_detalle.PrcItem = Math.Round(Convert.ToDecimal(filaDet.nvd_precioUnitarioNetoFinal), 0)
    '        obj_detalle.PrcItemSpecified = True
    '        obj_detalle.MontoItem = Math.Round(Convert.ToDecimal(filaDet.nvd_totalNetoFinal), 0)

    '        listaDetalle.Add(obj_detalle)

    '        NumItem = NumItem + 1

    '    Next

    '    obj_documento.Detalle = listaDetalle.ToArray()

    '    obj_DTE.Item = obj_documento

    '    Dim string_documento As String = func_SerializarObjeto(obj_DTE, GetType(DTEDefType), System.Text.Encoding.UTF8)
    '    string_documento = string_documento.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")

    '    Me.strEnvioXML = string_documento.ToString()
    '    obj_envelopeProcesar.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)

    '    Dim resultado As String = postProcesar(obj_envelopeProcesar)
    '    Me.strRespuestaXML = resultado.ToString()

    '    Dim obj_reponseProcesar As Envelope = Nothing
    '    func_DeserializarObjeto(resultado, GetType(Envelope), obj_reponseProcesar)

    '    Dim xml_responseProcesar As XmlDocument = New XmlDocument()
    '    xml_responseProcesar.LoadXml(CType(obj_reponseProcesar.Body.ProcesarResponse.ProcesarResult, System.Xml.XmlNode())(0).InnerText)

    '    bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
    '    str_folio = xml_responseProcesar.GetElementsByTagName("Folio").Item(0).InnerText

    '    If bol_Resultado = False Then
    '        errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
    '        Me.strErrorProcesar = errorRespuesta
    '        Me.bolResultadoEnvio = False

    '    Else
    '        url_tributaria = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlOriginal").Item(0).InnerText)
    '        url_cedible = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlCedible").Item(0).InnerText)

    '        Me.strErrorProcesar = ""
    '        Me.bolResultadoEnvio = True

    '    End If

    '    Return str_folio
    'End Function

    Public Function ConsultarEstadoBoleta(ByVal trackId As String) As Int64
        Dim obj_envelopeConsultarEstado As APIDESIS.EnvelopeConsultarEstado = New APIDESIS.EnvelopeConsultarEstado()
        Dim bol_Resultado As Boolean
        Dim bol_Deserializar As Boolean
        Dim lng_folio As Int64
        Dim errorRespuesta As String = ""
        Dim resultado As String = ""
        Dim obj_reponseProcesar As EnvelopeResponseConsultarEstado = Nothing
        Dim xml_responseProcesar As Xml.XmlDocument

        Try
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Rut = Me.rut '"MS05"
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Clave = Me.password '"cGxhbm85MTA5OA=="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Puerto = Me.puerto '"MA=="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.IncluyeLink = Me.incluyeLink.ToString() '1
            obj_envelopeConsultarEstado.Body.ConsultarEstado.trackid = trackId.ToString()

            Me.urlDescarga = ""
            Me.strErrorProcesar = ""

            resultado = postConsultarEstado(obj_envelopeConsultarEstado)
            Me.strRespuestaXML = resultado.ToString()

            Try
                If String.IsNullOrEmpty(resultado) = False AndAlso resultado.Contains("&lt;Resultado&gt;False&lt;/Resultado&gt;") = True Then
                    tbaDesisLog.Insert("POS-DESIS", 0, Now, trackId, resultado, Configuracion.IDUsuario, 0, 0, 0, 0, 0, Nothing)
                End If

            Catch ex As Exception
            End Try

            bol_Deserializar = func_DeserializarObjeto(resultado, GetType(EnvelopeResponseConsultarEstado), obj_reponseProcesar)

            xml_responseProcesar = New Xml.XmlDocument()
            xml_responseProcesar.LoadXml(CType(obj_reponseProcesar.Body.ConsultarEstadoResponse.ConsultarEstadoResult, Xml.XmlNode())(0).InnerText)

            bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
            lng_folio = xml_responseProcesar.GetElementsByTagName("Folio").Item(0).InnerText

            If bol_Resultado = False Then
                errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
                Me.strErrorProcesar = errorRespuesta
                Me.bolResultadoEnvio = False

            Else
                Me.urlDescarga = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlOriginal").Item(0).InnerText)
                Me.strErrorProcesar = ""
                Me.bolResultadoEnvio = True

            End If

        Catch ex As Exception
            func_RegistrarEnLogFile("ConsultarEstadoBoleta trackId : [" & trackId.ToString() & "] " & ex.Message, ex.StackTrace)
        End Try

        Return lng_folio

    End Function

    Public Function ConsultarEstadoFactura(ByVal trackId As String) As Int64
        Dim obj_envelopeConsultarEstado As APIDESIS.EnvelopeConsultarEstado = New APIDESIS.EnvelopeConsultarEstado()
        Dim bol_Resultado As Boolean
        Dim bol_Deserializar As Boolean
        Dim lng_folio As Int64
        Dim errorRespuesta As String = ""
        Dim obj_reponseProcesar As EnvelopeResponseConsultarEstado = Nothing
        Dim xml_responseProcesar As Xml.XmlDocument

        Try
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Rut = Me.rut '"MS05"
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Clave = Me.password '"cGxhbm85MTA5OA=="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Puerto = Me.puerto '"MA=="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.IncluyeLink = Me.incluyeLink.ToString() '1
            obj_envelopeConsultarEstado.Body.ConsultarEstado.trackid = trackId.ToString()

            Me.urlDescarga = ""
            Me.urlDescargaCedible = ""
            Me.strErrorProcesar = ""
            Me.bolResultadoEnvio = False

            Dim resultado As String = postConsultarEstado(obj_envelopeConsultarEstado)
            Me.strRespuestaXML = resultado.ToString()

            Try
                If String.IsNullOrEmpty(resultado) = False AndAlso resultado.Contains("&lt;Resultado&gt;False&lt;/Resultado&gt;") = True Then
                    tbaDesisLog.Insert("POS-DESIS", 0, Now, trackId, resultado, Configuracion.IDUsuario, 0, 0, 0, 0, 0, Nothing)
                End If

            Catch ex As Exception
            End Try

            bol_Deserializar = func_DeserializarObjeto(resultado, GetType(EnvelopeResponseConsultarEstado), obj_reponseProcesar)

            xml_responseProcesar = New Xml.XmlDocument()
            xml_responseProcesar.LoadXml(CType(obj_reponseProcesar.Body.ConsultarEstadoResponse.ConsultarEstadoResult, Xml.XmlNode())(0).InnerText)

            bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
            lng_Folio = xml_responseProcesar.GetElementsByTagName("Folio").Item(0).InnerText

            If bol_Resultado = False Then
                errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
                Me.strErrorProcesar = errorRespuesta
                Me.bolResultadoEnvio = False

            Else
                Me.urlDescarga = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlOriginal").Item(0).InnerText)
                Me.urlDescargaCedible = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlCedible").Item(0).InnerText)
                Me.strErrorProcesar = ""
                Me.bolResultadoEnvio = True

            End If

        Catch ex As Exception
            func_RegistrarEnLogFile("ConsultarEstadoFactura trackId : [" & trackId.ToString() & "] " & ex.Message, ex.StackTrace)
        End Try

        Return lng_Folio

    End Function

    Public Function ConsultarEstadoNotaCredito(ByVal trackId As String) As Int64
        Dim obj_envelopeConsultarEstado As APIDESIS.EnvelopeConsultarEstado = New APIDESIS.EnvelopeConsultarEstado()
        Dim bol_Resultado As Boolean
        Dim bol_Deserializar As Boolean
        Dim lng_folio As Int64
        Dim errorRespuesta As String = ""
        Dim obj_reponseProcesar As EnvelopeResponseConsultarEstado = Nothing
        Dim xml_responseProcesar As Xml.XmlDocument

        Try
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Usuario = Me.usuario '"Q0FSRU5TUEE="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Rut = Me.rut '"MS05"
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Clave = Me.password '"cGxhbm85MTA5OA=="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.Puerto = Me.puerto '"MA=="
            obj_envelopeConsultarEstado.Body.ConsultarEstado.login.IncluyeLink = Me.incluyeLink.ToString() '1
            obj_envelopeConsultarEstado.Body.ConsultarEstado.trackid = trackId.ToString()

            Me.urlDescarga = ""
            Me.strErrorProcesar = ""

            Dim resultado As String = postConsultarEstado(obj_envelopeConsultarEstado)
            Me.strRespuestaXML = resultado.ToString()

            Try
                If String.IsNullOrEmpty(resultado) = False AndAlso resultado.Contains("&lt;Resultado&gt;False&lt;/Resultado&gt;") = True Then
                    tbaDesisLog.Insert("POS-DESIS", 0, Now, trackId, resultado, Configuracion.IDUsuario, 0, 0, 0, 0, 0, Nothing)
                End If

            Catch ex As Exception
            End Try

            bol_Deserializar = func_DeserializarObjeto(resultado, GetType(EnvelopeResponseConsultarEstado), obj_reponseProcesar)

            xml_responseProcesar = New Xml.XmlDocument()
            xml_responseProcesar.LoadXml(CType(obj_reponseProcesar.Body.ConsultarEstadoResponse.ConsultarEstadoResult, Xml.XmlNode())(0).InnerText)

            bol_Resultado = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
            lng_folio = xml_responseProcesar.GetElementsByTagName("Folio").Item(0).InnerText

            If bol_Resultado = False Then
                errorRespuesta = xml_responseProcesar.GetElementsByTagName("Error").Item(0).InnerText
                Me.strErrorProcesar = errorRespuesta
                Me.bolResultadoEnvio = False

            Else
                Me.urlDescarga = class_APIDESIS.DecodeBase64ToString(xml_responseProcesar.GetElementsByTagName("urlOriginal").Item(0).InnerText)
                Me.strErrorProcesar = ""
                Me.bolResultadoEnvio = True

            End If

        Catch ex As Exception
            func_RegistrarEnLogFile("ConsultarEstadoNotaCredito trackId : [" & trackId.ToString() & "] " & ex.Message, ex.StackTrace)
        End Try

        Return lng_folio

    End Function

    Public Function postProcesar(ByRef obj_procesar As APIDESIS.EnvelopeProcesar) As String
        Dim host As String = "http://ws.facturacion.cl/WSDS/wsplano.asmx"
        Dim req As HttpWebRequest = Nothing
        Dim postData As String = ""

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True

            req = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.Headers.Add("Accept-Encoding", "gzip,deflate")
            req.ContentType = "application/soap+xml;charset=UTF-8;action=""http://tempuri.org/Procesar"""

            postData = func_SerializarObjeto(obj_procesar, GetType(APIDESIS.EnvelopeProcesar), Encoding.UTF8, "soap", "http://www.w3.org/2003/05/soap-envelope")
            postData = postData.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")

            'postData = "<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:tem=""http://tempuri.org"">" +
            '            " <soap:Header/>                                  " +
            '            " <soap:Body>                                    " +
            '            "    <tem:Procesar>                               " +
            '            "       <!--Optional:-->                          " +
            '            "       <tem:login>                               " +
            '            "          <!--Optional:-->                       " +
            '            "          <tem:Usuario>Q0FSRU5TUEE=</tem:Usuario>" +
            '            "          <!--Optional:-->                       " +
            '            "          <tem:Rut>MS05</tem:Rut>                " +
            '            "          <!--Optional:-->                       " +
            '            "          <tem:Clave>cGxhbm85MTA5OA==</tem:Clave>" +
            '            "          <!--Optional:-->                       " +
            '            "          <tem:Puerto>MA==</tem:Puerto>          " +
            '            "          <!--Optional:-->                       " +
            '            "          <tem:IncluyeLink>1</tem:IncluyeLink>   " +
            '            "       </tem:login>                              " +
            '            "       <!--Optional:-->                          " +
            '            "       <tem:file>PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iSVNPLTg4NTktMSI/Pgo8RFRFIHZlcnNpb249IjEuMCI+Cgk8RG9jdW1lbnRvIElEPSJGMVQzMyI+CgkJPEVuY2FiZXphZG8+CgkJCTxJZERvYz4KCQkJCTxUaXBvRFRFPjMzPC9UaXBvRFRFPgoJCQkJPEZvbGlvPjA8L0ZvbGlvPgoJCQkJPEZjaEVtaXM+MjAwOC0wNC0wOTwvRmNoRW1pcz4KCQkJPC9JZERvYz4KCQkJPEVtaXNvcj4KCQkJCTxSVVRFbWlzb3I+MS05PC9SVVRFbWlzb3I+CgkJCQk8UnpuU29jPlJvYmVydG8gR29tZXo8L1J6blNvYz4KCQkJCTxHaXJvRW1pcz5JbXBvcnRhY2nDs24gPC9HaXJvRW1pcz4KCQkJCTxBY3RlY28+NTE1MDA5PC9BY3RlY28+CgkJCQk8RGlyT3JpZ2VuPlBlZHJvIGRlIFZhbGRpdmlhIDI1PC9EaXJPcmlnZW4+CgkJCQk8Q21uYU9yaWdlbj5Qcm92aWRlbmNpYTwvQ21uYU9yaWdlbj4KCQkJCTxDaXVkYWRPcmlnZW4+U0FOVElBR088L0NpdWRhZE9yaWdlbj4KCQkJPC9FbWlzb3I+CgkJCTxSZWNlcHRvcj4KCQkJCTxSVVRSZWNlcD4xNTkxNTkxNS05PC9SVVRSZWNlcD4KCQkJCTxDZGdJbnRSZWNlcD4xNTkxNTkxNTwvQ2RnSW50UmVjZXA+CgkJCQk8UnpuU29jUmVjZXA+U0VSVklDSU9TIEdSQUZJQ09TPC9Sem5Tb2NSZWNlcD4KCQkJCTxHaXJvUmVjZXA+U0VSVklDSU88L0dpcm9SZWNlcD4KCQkJCTxEaXJSZWNlcD5ERVBBUlRBTUVOVEFMIDI1MDwvRGlyUmVjZXA+CgkJCQk8Q21uYVJlY2VwPlNBTiBKT0FRVUlOPC9DbW5hUmVjZXA+CgkJCQk8Q2l1ZGFkUmVjZXA+U0FOVElBR088L0NpdWRhZFJlY2VwPgoJCQk8L1JlY2VwdG9yPgoJCQk8VG90YWxlcz4KCQkJCTxNbnROZXRvPjU1NzI2MjwvTW50TmV0bz4KCQkJCTxUYXNhSVZBPjE5PC9UYXNhSVZBPgoJCQkJPElWQT4xMDU4ODA8L0lWQT4KCQkJCTxNbnRUb3RhbD42NjMxNDI8L01udFRvdGFsPgoJCQk8L1RvdGFsZXM+CgkJPC9FbmNhYmV6YWRvPgoJCTxEZXRhbGxlPgoJCQk8TnJvTGluRGV0PjE8L05yb0xpbkRldD4KCQkJPENkZ0l0ZW0+CgkJCQk8VHBvQ29kaWdvPklOVDE8L1Rwb0NvZGlnbz4KCQkJCTxWbHJDb2RpZ28+Q0E8L1ZsckNvZGlnbz4KCQkJPC9DZGdJdGVtPgoJCQk8Tm1iSXRlbT5DYWrDs24gQUZFQ1RPPC9ObWJJdGVtPgoJCQk8RHNjSXRlbT5UZXh0byBhZGljaW9uYWwgYWwgcHJvZHVjdG88L0RzY0l0ZW0+CgkJCTxRdHlJdGVtPjE2NjwvUXR5SXRlbT4KCQkJPFVubWRJdGVtPlVOPC9Vbm1kSXRlbT4KCQkJPFByY0l0ZW0+MzM1NzwvUHJjSXRlbT4KCQkJPE1vbnRvSXRlbT41NTcyNjI8L01vbnRvSXRlbT4KCQk8L0RldGFsbGU+CgkJPEFkaWNpb25hbD4KCQkJPE5vZG9zQT4KCQkJCTxBMT40MDAwMDA8L0ExPgoJCQkJPEEyPjwvQTI+CgkJCQk8QTM+PC9BMz4KCQkJCTxBND48L0E0PgoJCQkJPEE1PjwvQTU+CgkJCQk8QTY+Q09NTUVOVFM8L0E2PgoJCQk8L05vZG9zQT4KCQk8L0FkaWNpb25hbD4KCTwvRG9jdW1lbnRvPgo8L0RURT4K</tem:file>" +
            '            "       <tem:formato>2</tem:formato>              " +
            '            "    </tem:Procesar>                              " +
            '            " </soap:Body>                                    " +
            '            "</soap:Envelope>"

            Dim postBytes As Byte() = Encoding.UTF8.GetBytes(postData)
            req.ContentLength = postBytes.Length
            Dim postStream As Stream = req.GetRequestStream()
            postStream.Write(postBytes, 0, postBytes.Length)
            postStream.Flush()
            postStream.Close()
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim result As String = ""
            Dim reader As StreamReader = Nothing
            reader = New StreamReader(stream)
            result = reader.ReadToEnd()
            stream.Close()
            Return result
        Catch ex As Exception
            func_RegistrarEnLogFile("postProcesar : " & ex.Message, ex.StackTrace)
        End Try
        Return ""
    End Function

    Public Function postProcesarWSMasivo(ByRef obj_procesar As APIDESIS.EnvelopeProcesarWSMasivo) As String
        Dim host As String = "http://ws.facturacion.cl/WSDS/wsplano.asmx"
        Dim req As HttpWebRequest = Nothing
        Dim postData As String = ""
        Dim result As String = ""

        Dim WebExceptionMessage As String = ""
        Dim ExceptionFullMessage As String = ""
        Dim bolExcepcion As Boolean = False

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True

            req = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.Headers.Add("Accept-Encoding", "gzip,deflate")
            req.ContentType = "application/soap+xml;charset=UTF-8;action=""http://tempuri.org/ProcesarWSMasivo"""

            postData = func_SerializarObjeto(obj_procesar, GetType(APIDESIS.EnvelopeProcesarWSMasivo), Encoding.UTF8, "soap", "http://www.w3.org/2003/05/soap-envelope")
            postData = postData.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
            postData = postData.Replace(vbCrLf & "<soap:", "<soap:")

            Dim postBytes As Byte() = Encoding.UTF8.GetBytes(postData)
            req.ContentLength = postBytes.Length
            Dim postStream As Stream = req.GetRequestStream()
            postStream.Write(postBytes, 0, postBytes.Length)
            postStream.Flush()
            postStream.Close()
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = Nothing
            reader = New StreamReader(stream)
            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            bolExcepcion = True

            Try
                If TypeOf wex.Response Is WebResponse Then
                    WebExceptionMessage = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd().Trim()
                Else
                    WebExceptionMessage = "[]"
                End If

                WebExceptionMessage &= " status " & wex.Status.ToString()

                ExceptionFullMessage = WebExceptionMessage & vbCrLf & wex.Message & vbCrLf & wex.StackTrace & vbCrLf & " [" & String.Format("{0}", result) & "]"
            Catch ex As Exception
                Dim mensaje As String = ex.Message
            End Try

            func_RegistrarEnLogFile("postProcesarWSMasivo " & String.Format("{0}", WebExceptionMessage), wex.StackTrace & vbCrLf & " [" & postData & "]" & vbCrLf & " [" & String.Format("{0}", result) & "]")
        Catch ex As Exception
            bolExcepcion = True
            ExceptionFullMessage = ex.Message & vbCrLf & ex.StackTrace & vbCrLf & " [" & String.Format("{0}", result) & "]"

            func_RegistrarEnLogFile("postProcesarWSMasivo : " & ex.Message, ex.StackTrace & vbCrLf & " [" & postData & "]" & vbCrLf & " [" & String.Format("{0}", result) & "]")
        End Try

        If bolExcepcion = True Then
            Try
                tbaDesisLog.Insert("POS-DESIS", 0, Now, postData, ExceptionFullMessage, Configuracion.IDUsuario, 0, 0, 0, 0, 0, Nothing)
            Catch ex As Exception
            End Try
        End If

        Return ""
    End Function

    Public Function postConsultarEstado(ByRef obj_consultarEstado As APIDESIS.EnvelopeConsultarEstado) As String
        Dim host As String = "http://ws.facturacion.cl/WSDS/wsplano.asmx"
        Dim req As HttpWebRequest = Nothing
        Dim postData As String = ""
        Dim result As String = ""

        Dim WebExceptionMessage As String = ""
        Dim ExceptionFullMessage As String = ""
        Dim bolExcepcion As Boolean = False

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True

            req = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.Headers.Add("Accept-Encoding", "gzip,deflate")
            req.ContentType = "application/soap+xml;charset=UTF-8;action=""http://tempuri.org/ConsultarEstado"""

            postData = func_SerializarObjeto(obj_consultarEstado, GetType(APIDESIS.EnvelopeConsultarEstado), Encoding.UTF8, "soap", "http://www.w3.org/2003/05/soap-envelope")
            postData = postData.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
            postData = postData.Replace(vbCrLf & "<soap:", "<soap:")

            Dim postBytes As Byte() = Encoding.UTF8.GetBytes(postData)
            req.ContentLength = postBytes.Length
            Dim postStream As Stream = req.GetRequestStream()
            postStream.Write(postBytes, 0, postBytes.Length)
            postStream.Flush()
            postStream.Close()
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = Nothing
            reader = New StreamReader(stream)
            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            bolExcepcion = True

            If TypeOf wex.Response Is WebResponse Then
                WebExceptionMessage = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd().Trim()
            Else
                WebExceptionMessage = "[]"
            End If

            ExceptionFullMessage = WebExceptionMessage & vbCrLf & wex.Message & vbCrLf & wex.StackTrace & vbCrLf & " [" & result.ToString() & "]"
            func_RegistrarEnLogFile("postConsultarEstado " & WebExceptionMessage, wex.StackTrace & vbCrLf & " [" & postData & "]" & vbCrLf & " [" & result.ToString() & "]")

        Catch ex As Exception
            bolExcepcion = True
            ExceptionFullMessage = ex.Message & vbCrLf & ex.StackTrace & vbCrLf & " [" & result.ToString() & "]"
            func_RegistrarEnLogFile("postConsultarEstado : " & ex.Message, ex.StackTrace & vbCrLf & " [" & postData & "]" & vbCrLf & " [" & result.ToString() & "]")

        End Try

        If bolExcepcion = True Then
            Try
                tbaDesisLog.Insert("POS-DESIS", 0, Now, postData, ExceptionFullMessage, Configuracion.IDUsuario, 0, 0, 0, 0, 0, obj_consultarEstado.Body.ConsultarEstado.trackid.ToString())
            Catch ex As Exception
            End Try
        End If

        Return ""
    End Function

    Public Function grabaDTE(ByVal tipo As String, ByVal Folio As String, ByVal DocumentoXML As String) As Boolean
        Dim adDTECab As dte_cabTableAdapter = New dte_cabTableAdapter
        Dim adDTEDet As dte_detTableAdapter = New dte_detTableAdapter
        Dim adDTEDscRcg As dte_dsc_rcgTableAdapter = New dte_dsc_rcgTableAdapter
        Dim adDTERef As dte_refTableAdapter = New dte_refTableAdapter

        Dim int_linkDescarga As Integer = 1
        Dim TipoDte, fEmis, fmaPago, termPagoGlosa, RUTEmisor, Acteco, DirOrigen, CmnaOrigen, CiudadOrigen, RUTRecep, GiroRecep, DirRecep, CmnaRecep, CiudadRecep As String
        Dim MntNeto, MntExe, IVA, MntTotal As Double
        Dim TasaIVA As Decimal

        Dim NroLinDet As Integer
        Dim QtyItem, PrcItem, MontoItem As Double
        Dim TpoCodigo, VlrCodigo, NmbItem, UnmdItem, ID As String
        Dim TipoMovimiento As String = "V"

        Dim d_RazonEmisor, d_GiroEmisor, y_RazonRecep As String
        'Boleta 
        Dim IndServicio, FchVenc, CdgIntRecep As String
        Dim VlrPagar As Decimal
        'Descuentos y Recargos Globales
        Dim NroLinDR As Integer, TpoMov As String, TpoValor As String, ValorDR As Double

        Dim NroLinRef As Integer
        Dim TpoDocRef As Integer
        Dim FolioRef As Long
        Dim FchRef As String
        Dim CodRef As String
        Dim RazonRef As String

        Try

            If tipo = "39" Then TipoMovimiento = "B"

            If DocumentoXML <> "" Then

                Dim xml_responseGetXmlDte As System.Xml.XmlDocument = New System.Xml.XmlDocument()
                Dim xml_responseGetXmlDetalleProd As System.Xml.XmlDocument = New System.Xml.XmlDocument()
                xml_responseGetXmlDte.LoadXml(DocumentoXML)
                Dim nsmgr = New XmlNamespaceManager(xml_responseGetXmlDte.NameTable)
                nsmgr.AddNamespace("SII", "http://www.sii.cl/SiiDte")

                If xml_responseGetXmlDte.GetElementsByTagName("Encabezado").Count > 0 Then
                    'Encabezado documento

                    ID = xml_responseGetXmlDte.GetElementsByTagName("Documento").Item(0).Attributes("ID").Value

                    If tipo = "39" Then
                        'Campos especificos para boleta. Se limpian los campos exclusivos para factura
                        IndServicio = xml_responseGetXmlDte.GetElementsByTagName("IndServicio").Item(0).InnerText
                        If xml_responseGetXmlDte.GetElementsByTagName("FchVenc").Count > 0 Then
                            FchVenc = xml_responseGetXmlDte.GetElementsByTagName("FchVenc").Item(0).InnerText
                        End If
                        CdgIntRecep = xml_responseGetXmlDte.GetElementsByTagName("CdgIntRecep").Item(0).InnerText
                        If xml_responseGetXmlDte.GetElementsByTagName("VlrPagar").Count > 0 Then
                            VlrPagar = xml_responseGetXmlDte.GetElementsByTagName("VlrPagar").Item(0).InnerText
                        End If
                        d_RazonEmisor = xml_responseGetXmlDte.GetElementsByTagName("RznSocEmisor").Item(0).InnerText
                        d_GiroEmisor = xml_responseGetXmlDte.GetElementsByTagName("GiroEmisor").Item(0).InnerText
                        y_RazonRecep = xml_responseGetXmlDte.GetElementsByTagName("RznSocRecep").Item(0).InnerText

                        fmaPago = Nothing
                        termPagoGlosa = Nothing
                        GiroRecep = Nothing
                        MntExe = Nothing
                        TasaIVA = Nothing
                        Acteco = Nothing
                    End If

                    If tipo = "33" Then
                        'Campos especificos para factura. Se limpian los campos exclusivos para boleta
                        CdgIntRecep = Nothing
                        IndServicio = Nothing
                        FchVenc = Nothing
                        VlrPagar = Nothing

                        fmaPago = xml_responseGetXmlDte.GetElementsByTagName("FmaPago").Item(0).InnerText

                        If xml_responseGetXmlDte.GetElementsByTagName("TermPagoGlosa").Count > 0 Then
                            termPagoGlosa = xml_responseGetXmlDte.GetElementsByTagName("TermPagoGlosa").Item(0).InnerText
                        End If

                        d_RazonEmisor = xml_responseGetXmlDte.GetElementsByTagName("RznSoc").Item(0).InnerText
                        d_GiroEmisor = xml_responseGetXmlDte.GetElementsByTagName("GiroEmis").Item(0).InnerText
                        Acteco = xml_responseGetXmlDte.GetElementsByTagName("Acteco").Item(0).InnerText
                        y_RazonRecep = xml_responseGetXmlDte.GetElementsByTagName("RznSocRecep").Item(0).InnerText
                        GiroRecep = xml_responseGetXmlDte.GetElementsByTagName("GiroRecep").Item(0).InnerText

                        If xml_responseGetXmlDte.GetElementsByTagName("MntExe").Count > 0 Then
                            MntExe = xml_responseGetXmlDte.GetElementsByTagName("MntExe").Item(0).InnerText
                        End If

                        TasaIVA = xml_responseGetXmlDte.GetElementsByTagName("TasaIVA").Item(0).InnerText

                    End If

                    'Boleta y factura tienen los mismos campos:
                    TipoDte = xml_responseGetXmlDte.GetElementsByTagName("TipoDTE").Item(0).InnerText
                    'Folio = xml_responseGetXmlDte.GetElementsByTagName("Folio").Item(0).InnerText
                    fEmis = xml_responseGetXmlDte.GetElementsByTagName("FchEmis").Item(0).InnerText
                    RUTEmisor = xml_responseGetXmlDte.GetElementsByTagName("RUTEmisor").Item(0).InnerText
                    DirOrigen = xml_responseGetXmlDte.GetElementsByTagName("DirOrigen").Item(0).InnerText
                    CmnaOrigen = xml_responseGetXmlDte.GetElementsByTagName("CmnaOrigen").Item(0).InnerText
                    CiudadOrigen = xml_responseGetXmlDte.GetElementsByTagName("CiudadOrigen").Item(0).InnerText
                    RUTRecep = xml_responseGetXmlDte.GetElementsByTagName("RUTRecep").Item(0).InnerText

                    If xml_responseGetXmlDte.GetElementsByTagName("DirRecep").Count > 0 Then
                        DirRecep = xml_responseGetXmlDte.GetElementsByTagName("DirRecep").Item(0).InnerText
                    End If
                    If xml_responseGetXmlDte.GetElementsByTagName("CmnaRecep").Count > 0 Then
                        CmnaRecep = xml_responseGetXmlDte.GetElementsByTagName("CmnaRecep").Item(0).InnerText
                    End If
                    If xml_responseGetXmlDte.GetElementsByTagName("CiudadRecep").Count > 0 Then
                        CiudadRecep = xml_responseGetXmlDte.GetElementsByTagName("CiudadRecep").Item(0).InnerText
                    End If

                    MntNeto = xml_responseGetXmlDte.GetElementsByTagName("MntNeto").Item(0).InnerText
                    IVA = xml_responseGetXmlDte.GetElementsByTagName("IVA").Item(0).InnerText
                    MntTotal = xml_responseGetXmlDte.GetElementsByTagName("MntTotal").Item(0).InnerText

                    If adDTECab.ExisteDocInsertado(TipoDte, Folio) = 0 Then
                        'No existe. Insertar cab

                        If FchVenc = "" Then FchVenc = "1900-01-01"

                        adDTECab.Insert(TipoDte, Folio, fEmis, fmaPago, termPagoGlosa, RUTEmisor, d_RazonEmisor, d_GiroEmisor, Acteco, DirOrigen,
                                        CmnaOrigen, CiudadOrigen, RUTRecep, y_RazonRecep, GiroRecep, DirRecep, CmnaRecep, CiudadRecep,
                                        MntNeto, MntExe, TasaIVA, IVA, MntTotal, ID, IndServicio, FchVenc, CdgIntRecep, VlrPagar)

                    End If

                    Dim nodeListDetalle As System.Xml.XmlNodeList = xml_responseGetXmlDte.SelectNodes("SII:DTE/SII:Documento/SII:Detalle", nsmgr)

                    For Each node As System.Xml.XmlNode In nodeListDetalle

                        NroLinDet = node("NroLinDet").InnerText
                        xml_responseGetXmlDetalleProd.LoadXml(node("CdgItem").OuterXml)
                        TpoCodigo = xml_responseGetXmlDetalleProd.GetElementsByTagName("TpoCodigo").Item(0).InnerText
                        VlrCodigo = xml_responseGetXmlDetalleProd.GetElementsByTagName("VlrCodigo").Item(0).InnerText
                        NmbItem = node("NmbItem").InnerText
                        QtyItem = node("QtyItem").InnerText
                        UnmdItem = node("UnmdItem").InnerText
                        PrcItem = node("PrcItem").InnerText.ToDblEng()
                        MontoItem = node("MontoItem").InnerText

                        If adDTEDet.ExisteDet(TipoDte, Folio, NroLinDet) = 0 Then
                            'No existe. Insertar det

                            adDTEDet.Insert(TipoDte, Folio, NroLinDet, TpoCodigo, VlrCodigo, NmbItem, QtyItem, UnmdItem, PrcItem, MontoItem)


                        End If


                    Next

                    Dim nodeListDscRcg As System.Xml.XmlNodeList = xml_responseGetXmlDte.SelectNodes("SII:DTE/SII:Documento/SII:DscRcgGlobal", nsmgr)

                    For Each node As System.Xml.XmlNode In nodeListDscRcg
                        NroLinDR = node("NroLinDR").InnerText
                        TpoMov = node("TpoMov").InnerText
                        TpoValor = node("TpoValor").InnerText
                        ValorDR = node("ValorDR").InnerText

                        If adDTEDscRcg.ExisteDet(TipoDte, Folio, NroLinDR) = 0 Then

                            adDTEDscRcg.Insert(TipoDte, Folio, NroLinDR, TpoMov, TpoValor, ValorDR)
                        End If
                    Next

                    Dim nodeListReferencia As System.Xml.XmlNodeList = xml_responseGetXmlDte.SelectNodes("SII:DTE/SII:Documento/SII:Referencia", nsmgr)

                    For Each node As System.Xml.XmlNode In nodeListReferencia

                        NroLinRef = node("NroLinRef").InnerText
                        TpoDocRef = node("TpoDocRef").InnerText
                        FolioRef = node("FolioRef").InnerText
                        FchRef = node("FchRef").InnerText
                        CodRef = node("CodRef").InnerText
                        If Not node("RazonRef") Is Nothing Then
                            RazonRef = node("RazonRef").InnerText
                        End If

                        If adDTERef.ExisteDocInsertado(TipoDte, Folio, NroLinRef) = 0 Then

                            adDTERef.Insert(TipoDte, Folio, NroLinRef, TpoDocRef, "", FolioRef, FchRef, CodRef, RazonRef)
                        End If
                    Next
                End If

            End If

        Catch ex As Exception
            'Me.strErrorProcesar &= mensajeExceptionAjax(ex)
            func_RegistrarEnLogFile("grabaDTE : " & ex.Message & " " & ex.StackTrace)
            Return False
        End Try

        Return True
    End Function

    Public Function func_SerializarObjeto(ByVal obj_ObjetoaSerializar As Object, ByVal objtype_ObjetoTipo As Type,
                                          ByVal enc_CodificacionArchivoSerializado As Encoding, Optional ByVal str_prefix As String = "",
                                          Optional ByVal str_Namespace As String = "") As String
        Dim mySerializer As XmlSerializer = Nothing
        Dim strObjetoXML As String = ""

        Try

            If str_Namespace = "" Then
                mySerializer = New XmlSerializer(objtype_ObjetoTipo)
            Else
                mySerializer = New XmlSerializer(objtype_ObjetoTipo, str_Namespace)
            End If

            Dim xmlWriterSettings As XmlWriterSettings = New XmlWriterSettings
            xmlWriterSettings.ConformanceLevel = ConformanceLevel.Document
            xmlWriterSettings.Encoding = enc_CodificacionArchivoSerializado
            xmlWriterSettings.IndentChars = vbTab
            xmlWriterSettings.Indent = True

            Dim ns_XmlSerializer As New XmlSerializerNamespaces
            If str_prefix <> "" Then
                ns_XmlSerializer.Add("soap", str_Namespace)
            End If

            Using Obj_stringWriter As StringWriter = New StringWriter()

                Using XmlWriter As XmlWriter = XmlWriter.Create(Obj_stringWriter, xmlWriterSettings)

                    mySerializer.Serialize(XmlWriter, obj_ObjetoaSerializar, ns_XmlSerializer)
                    strObjetoXML = Obj_stringWriter.ToString()
                    XmlWriter.Close()
                End Using

            End Using

        Catch ex As Exception
            func_RegistrarEnLogFile("func_SerializarObjeto : " & ex.Message, ex.StackTrace)
        End Try
        Return strObjetoXML
    End Function

    Public Function func_DeserializarObjeto(ByVal str_contenidoXML As String,
                                            ByVal objtype_ObjetoTipo As Type,
                                            ByRef obj_ObjetoReceptor As Object) As Boolean
        Try
            Dim mySerializer As XmlSerializer = New XmlSerializer(objtype_ObjetoTipo)
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(str_contenidoXML)

            Dim StreamXML As MemoryStream = New MemoryStream(byteArray)

            Using strReader As StreamReader = New StreamReader(StreamXML, System.Text.Encoding.UTF8)
                obj_ObjetoReceptor = mySerializer.Deserialize(strReader)
                strReader.Close()
            End Using

            Return True
        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try
        Return False
    End Function

    Public ReadOnly Property ambiente As String
        Get
            Return intAmbiente
        End Get
    End Property

    Public ReadOnly Property resultadoEnvio As Boolean
        Get
            Return bolResultadoEnvio
        End Get
    End Property

    Public ReadOnly Property errorProcesar As String
        Get
            Return strErrorProcesar
        End Get
    End Property

    Public ReadOnly Property urlDescargaArchivo As String
        Get
            Return urlDescarga
        End Get
    End Property

    Public ReadOnly Property urlDescargaArchivoCedible As String
        Get
            Return urlDescargaCedible
        End Get
    End Property

    Public ReadOnly Property envioXML As String
        Get
            Return strEnvioXML
        End Get
    End Property

    Public ReadOnly Property respuestaXML As String
        Get
            Return strRespuestaXML
        End Get
    End Property

    Public ReadOnly Property trackId As String
        Get
            Return strTrackId
        End Get
    End Property

    Public Shared Function DecodeBase64ToString(valor As String) As String
        Dim myBase64ret As Byte() = Convert.FromBase64String(valor)
        Dim myString As String = System.Text.Encoding.UTF8.GetString(myBase64ret)
        Return myString
    End Function

    Public Shared Function EncodeStrToBase64(valor As String) As String
        Dim myByte As Byte() = System.Text.Encoding.UTF8.GetBytes(valor)
        Dim myBase64 As String = Convert.ToBase64String(myByte)
        Return myBase64
    End Function

    Public Function func_RegistrarEnLogFile(ByVal str_EntradaRegistroLog As String, Optional ByVal str_StackTrace As String = "") As Boolean

        SyncLock obj_logSyncObject
            Dim str_NombreArchivoLog As String = "Desis"
            Dim str_NombreUsuario As String = ""
            Dim AppPath As String = AppDomain.CurrentDomain.BaseDirectory

            Try
                Dim str_EntradaRegistroLogFormateada As String = Format(Now, "yyyy-MM-dd HH:mm:ss") & "[" & Environment.MachineName & "](" & str_NombreUsuario & ") " & str_EntradaRegistroLog & " " & str_StackTrace
                Dim stwFileLog As New StreamWriter(AppPath & "log\" & str_NombreArchivoLog & "_" & Now.ToString("yyyy-MM-dd") & ".log", True)
                stwFileLog.WriteLine(str_EntradaRegistroLogFormateada)
                stwFileLog.Close()
                stwFileLog = Nothing

                Return True
            Catch ex As Exception

                Return False

            End Try
            Return False
        End SyncLock

        Return False
    End Function

End Class
