Imports caja2.DTE

Public Class FrmDESIS

    Dim obj_APIDESIS As class_APIDESIS = New class_APIDESIS()
    Dim obj_envelopeProcesar As APIDESIS.EnvelopeProcesar = New APIDESIS.EnvelopeProcesar()
    Dim obj_DTE As DTEDefType = New DTEDefType()

    Private Sub FrmDESIS_Load(sender As Object, e As EventArgs) Handles Me.Load

        obj_envelopeProcesar.Body.Procesar.login.Usuario = "Q0FSRU5TUEE="
        obj_envelopeProcesar.Body.Procesar.login.Rut = "MS05"
        obj_envelopeProcesar.Body.Procesar.login.Clave = "cGxhbm85MTA5OA=="
        obj_envelopeProcesar.Body.Procesar.login.Puerto = "MA=="
        obj_envelopeProcesar.Body.Procesar.login.IncluyeLink = 1
        obj_envelopeProcesar.Body.Procesar.file = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iSVNPLTg4NTktMSI/Pgo8RFRFIHZlcnNpb249IjEuMCI+Cgk8RG9jdW1lbnRvIElEPSJGMVQzMyI+CgkJPEVuY2FiZXphZG8+CgkJCTxJZERvYz4KCQkJCTxUaXBvRFRFPjMzPC9UaXBvRFRFPgoJCQkJPEZvbGlvPjA8L0ZvbGlvPgoJCQkJPEZjaEVtaXM+MjAwOC0wNC0wOTwvRmNoRW1pcz4KCQkJPC9JZERvYz4KCQkJPEVtaXNvcj4KCQkJCTxSVVRFbWlzb3I+MS05PC9SVVRFbWlzb3I+CgkJCQk8UnpuU29jPlJvYmVydG8gR29tZXo8L1J6blNvYz4KCQkJCTxHaXJvRW1pcz5JbXBvcnRhY2nDs24gPC9HaXJvRW1pcz4KCQkJCTxBY3RlY28+NTE1MDA5PC9BY3RlY28+CgkJCQk8RGlyT3JpZ2VuPlBlZHJvIGRlIFZhbGRpdmlhIDI1PC9EaXJPcmlnZW4+CgkJCQk8Q21uYU9yaWdlbj5Qcm92aWRlbmNpYTwvQ21uYU9yaWdlbj4KCQkJCTxDaXVkYWRPcmlnZW4+U0FOVElBR088L0NpdWRhZE9yaWdlbj4KCQkJPC9FbWlzb3I+CgkJCTxSZWNlcHRvcj4KCQkJCTxSVVRSZWNlcD4xNTkxNTkxNS05PC9SVVRSZWNlcD4KCQkJCTxDZGdJbnRSZWNlcD4xNTkxNTkxNTwvQ2RnSW50UmVjZXA+CgkJCQk8UnpuU29jUmVjZXA+U0VSVklDSU9TIEdSQUZJQ09TPC9Sem5Tb2NSZWNlcD4KCQkJCTxHaXJvUmVjZXA+U0VSVklDSU88L0dpcm9SZWNlcD4KCQkJCTxEaXJSZWNlcD5ERVBBUlRBTUVOVEFMIDI1MDwvRGlyUmVjZXA+CgkJCQk8Q21uYVJlY2VwPlNBTiBKT0FRVUlOPC9DbW5hUmVjZXA+CgkJCQk8Q2l1ZGFkUmVjZXA+U0FOVElBR088L0NpdWRhZFJlY2VwPgoJCQk8L1JlY2VwdG9yPgoJCQk8VG90YWxlcz4KCQkJCTxNbnROZXRvPjU1NzI2MjwvTW50TmV0bz4KCQkJCTxUYXNhSVZBPjE5PC9UYXNhSVZBPgoJCQkJPElWQT4xMDU4ODA8L0lWQT4KCQkJCTxNbnRUb3RhbD42NjMxNDI8L01udFRvdGFsPgoJCQk8L1RvdGFsZXM+CgkJPC9FbmNhYmV6YWRvPgoJCTxEZXRhbGxlPgoJCQk8TnJvTGluRGV0PjE8L05yb0xpbkRldD4KCQkJPENkZ0l0ZW0+CgkJCQk8VHBvQ29kaWdvPklOVDE8L1Rwb0NvZGlnbz4KCQkJCTxWbHJDb2RpZ28+Q0E8L1ZsckNvZGlnbz4KCQkJPC9DZGdJdGVtPgoJCQk8Tm1iSXRlbT5DYWrDs24gQUZFQ1RPPC9ObWJJdGVtPgoJCQk8RHNjSXRlbT5UZXh0byBhZGljaW9uYWwgYWwgcHJvZHVjdG88L0RzY0l0ZW0+CgkJCTxRdHlJdGVtPjE2NjwvUXR5SXRlbT4KCQkJPFVubWRJdGVtPlVOPC9Vbm1kSXRlbT4KCQkJPFByY0l0ZW0+MzM1NzwvUHJjSXRlbT4KCQkJPE1vbnRvSXRlbT41NTcyNjI8L01vbnRvSXRlbT4KCQk8L0RldGFsbGU+CgkJPEFkaWNpb25hbD4KCQkJPE5vZG9zQT4KCQkJCTxBMT40MDAwMDA8L0ExPgoJCQkJPEEyPjwvQTI+CgkJCQk8QTM+PC9BMz4KCQkJCTxBND48L0E0PgoJCQkJPEE1PjwvQTU+CgkJCQk8QTY+Q09NTUVOVFM8L0E2PgoJCQk8L05vZG9zQT4KCQk8L0FkaWNpb25hbD4KCTwvRG9jdW1lbnRvPgo8L0RURT4K"
        obj_envelopeProcesar.Body.Procesar.formato = 2

    End Sub

    Private Sub btnProcesarDTE_Click(sender As Object, e As EventArgs) Handles btnProcesarDTE.Click
        Dim obj_dte As DTEDefType = New DTEDefType
        Dim obj_documento As DTEDefTypeDocumento = New DTEDefTypeDocumento()

        obj_documento.ID = "F1T33"
        obj_documento.Encabezado = New DTEDefTypeDocumentoEncabezado()
        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()

        obj_documento.Encabezado.IdDoc = New DTEDefTypeDocumentoEncabezadoIdDoc()
        obj_documento.Encabezado.IdDoc.TipoDTE = DTE.DTEType.Item33
        obj_documento.Encabezado.IdDoc.Folio = "0"
        obj_documento.Encabezado.IdDoc.FchEmis = "2008-04-09"

        obj_documento.Encabezado.Emisor = New DTEDefTypeDocumentoEncabezadoEmisor()
        obj_documento.Encabezado.Emisor.RUTEmisor = "1-9"
        obj_documento.Encabezado.Emisor.RznSoc = "Roberto Gomez"
        obj_documento.Encabezado.Emisor.GiroEmis = "Importación "
        obj_documento.Encabezado.Emisor.Acteco = New String() {"515009"}
        obj_documento.Encabezado.Emisor.DirOrigen = "Pedro de Valdivia 25"
        obj_documento.Encabezado.Emisor.CmnaOrigen = "Providencia"
        obj_documento.Encabezado.Emisor.CiudadOrigen = "SANTIAGO"

        obj_documento.Encabezado.Receptor = New DTEDefTypeDocumentoEncabezadoReceptor()
        obj_documento.Encabezado.Receptor.RUTRecep = "15915915-9"
        obj_documento.Encabezado.Receptor.CdgIntRecep = "15915915"
        obj_documento.Encabezado.Receptor.RznSocRecep = "SERVICIOS GRAFICOS"
        obj_documento.Encabezado.Receptor.GiroRecep = "SERVICIO"
        obj_documento.Encabezado.Receptor.DirRecep = "DEPARTAMENTAL 250"
        obj_documento.Encabezado.Receptor.CmnaRecep = "SAN JOAQUIN"
        obj_documento.Encabezado.Receptor.CiudadRecep = "SANTIAGO"

        obj_documento.Encabezado.Totales = New DTEDefTypeDocumentoEncabezadoTotales()
        obj_documento.Encabezado.Totales.MntNeto = "557262"
        obj_documento.Encabezado.Totales.TasaIVA = Convert.ToDecimal("19")
        obj_documento.Encabezado.Totales.TasaIVASpecified = True
        obj_documento.Encabezado.Totales.IVA = "105880"
        obj_documento.Encabezado.Totales.MntTotal = "663142"

        Dim listaDetalle As List(Of DTEDefTypeDocumentoDetalle) = New List(Of DTEDefTypeDocumentoDetalle)
        Dim obj_detalle = New DTEDefTypeDocumentoDetalle()
        Dim obj_detalleCdgItem = New DTEDefTypeDocumentoDetalleCdgItem()


        obj_detalle.NroLinDet = "1"
        obj_detalleCdgItem.TpoCodigo = "INT1"
        obj_detalleCdgItem.VlrCodigo = "CA"
        obj_detalle.CdgItem = (New List(Of DTEDefTypeDocumentoDetalleCdgItem) From {obj_detalleCdgItem}).ToArray()

        obj_detalle.NmbItem = "Cajón AFECTO"
        obj_detalle.DscItem = "Texto adicional al producto"
        obj_detalle.QtyItem = Convert.ToDecimal(166)
        obj_detalle.QtyItemSpecified = True
        obj_detalle.UnmdItem = "UN"
        obj_detalle.PrcItem = Convert.ToDecimal(3357)
        obj_detalle.PrcItemSpecified = True
        obj_detalle.MontoItem = 557262

        listaDetalle.Add(obj_detalle)

        obj_documento.Detalle = listaDetalle.ToArray()

        '<Detalle>
        '	<NroLinDet>1</NroLinDet>
        '	<CdgItem>
        '		<TpoCodigo>INT1</TpoCodigo>
        '		<VlrCodigo>CA</VlrCodigo>
        '	</CdgItem>
        '	<NmbItem>Cajón AFECTO</NmbItem>
        '	<DscItem>Texto adicional al producto</DscItem>
        '	<QtyItem>166</QtyItem>
        '	<UnmdItem>UN</UnmdItem>
        '	<PrcItem>3357</PrcItem>
        '	<MontoItem>557262</MontoItem>
        '</Detalle>
        '<Adicional>
        '	<NodosA>
        '		<A1>400000</A1>
        '		<A2></A2>
        '		<A3></A3>
        '		<A4></A4>
        '		<A5></A5>
        '		<A6>COMMENTS</A6>
        '	</NodosA>
        '</Adicional>

        'NOTA:serializar obj_documento a string con funcion func_SerializarObjeto y convertirlo a base64
        obj_dte.Item = obj_documento

        Dim string_documento As String = obj_APIDESIS.func_SerializarObjeto(obj_dte, GetType(DTEDefType), System.Text.Encoding.UTF8)
        string_documento = string_documento.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")

        obj_envelopeProcesar.Body.Procesar.file = class_APIDESIS.EncodeStrToBase64(string_documento)

        Dim resultado As String = obj_APIDESIS.postProcesar(obj_envelopeProcesar)

        Dim obj_reponseProcesar As EnvelopeResponseProcesar = Nothing
        obj_APIDESIS.func_DeserializarObjeto(resultado, GetType(EnvelopeResponseProcesar), obj_reponseProcesar)

        Dim xml_responseProcesar As Xml.XmlDocument = New Xml.XmlDocument()
        xml_responseProcesar.LoadXml(CType(obj_reponseProcesar.Body.ProcesarResponse.ProcesarResult, Xml.XmlNode())(0).InnerText)
        '<?xml version="1.0"?><WSPLANO><Resultado>True</Resultado><Mensaje>Proceso exitoso.</Mensaje><Detalle><Documento><Folio>9920019856</Folio><TipoDte>33</TipoDte><Operacion>VENTA</Operacion><Fecha>2022-04-11T13:35:10</Fecha><Resultado>True</Resultado><urlOriginal>aHR0cDovL3d3dy5mYWN0dXJhY2lvbi5jbC9wbGFuby9kZXNjYXJnYXIucGhwP3AxPWY2OTQ4NjE1ZDgmcDI9R0RJJm09ViZpPTEzMDI4NTEmYz1mYWxzZQ==</urlOriginal><urlCedible>aHR0cDovL3d3dy5mYWN0dXJhY2lvbi5jbC9wbGFuby9kZXNjYXJnYXIucGhwP3AxPWRiYzBhMzEzZmMmcDI9R0RJJm09ViZpPTEzMDI4NTEmYz10cnVl</urlCedible></Documento></Detalle></WSPLANO>

        Dim str_Resultado As String = xml_responseProcesar.GetElementsByTagName("Resultado").Item(0).InnerText
        Dim str_folio As String = xml_responseProcesar.GetElementsByTagName("Folio").Item(0).InnerText
		
        txtResultado.Text = resultado
    End Sub
End Class