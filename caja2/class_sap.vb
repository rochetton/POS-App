Imports System.IO
Imports System.Net
Imports System.Text
Imports caja2.DTE
Imports Newtonsoft.Json

Public Class class_sap

    Dim ambiente As Integer = 0
    Dim str_sufijoMetodo As String = ""
    Dim sapClient As String = ""
    Dim sapCompany As String = ""
    Dim sapCurrency As String = ""

    Dim username1 As String = ""
    Dim password1 As String = ""

    Dim username2 As String = ""
    Dim password2 As String = ""

    Public Sub New(ByVal ambiente As Integer, ByVal username1 As String, ByVal password1 As String, ByVal username2 As String, ByVal password2 As String, ByVal clienteSAP As String, ByVal empresaSAP As String, ByVal monedaSAP As String)
        If ambiente = -1 Then ' -1 = Desarrollo
            str_sufijoMetodo = ""
        ElseIf ambiente = 0 Then ' 0 = QA
            str_sufijoMetodo = "_qas"
        ElseIf ambiente = 1 Then ' 1 = Producción
            str_sufijoMetodo = "_prd"
        End If

        Me.ambiente = ambiente
        Me.sapClient = clienteSAP
        Me.sapCompany = empresaSAP
        Me.sapCurrency = monedaSAP

        Me.username1 = username1
        Me.password1 = password1

        Me.username2 = username2
        Me.password2 = password2
    End Sub

    Public Function getTiendas() As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/GetTiendas{0}", str_sufijoMetodo)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "GET"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            Dim result As String = ""
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(stream)

            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("getTiendas " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("getTiendas " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function getStockArticulo(ByVal material As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/GetStockAvailable{0}?Articulo={1}", str_sufijoMetodo, material)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "GET"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            Dim result As String = ""
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(stream)

            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("getStockArticulo " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("getStockArticulo " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function getStockArticuloTienda(ByVal material As String, ByVal tienda As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/GetStockAvailable{0}?Articulo={1}&Tienda={2}", str_sufijoMetodo, material, tienda)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "GET"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            Dim result As String = ""
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(stream)

            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("getStockArticuloTienda " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("getStockArticuloTienda " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function getStockArticulosTiendaMasivo(ByVal materiales As String, ByVal tienda As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/GetStockAvailableMass{0}?Articulo={1}&Tienda={2}", str_sufijoMetodo, materiales, tienda)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "GET"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            Dim result As String = ""
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(stream)

            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("getStockArticulosTiendaMasivo " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("getStockArticulosTiendaMasivo " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function getControlCredito(ByVal rutCliente As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/GetCreditLineV2{0}?sap-client={1}&$filter= Company eq '{2}' and Rut eq '{3}' and Moneda eq '{4}'", str_sufijoMetodo, sapClient, sapCompany,
                                           rutCliente, sapCurrency)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "GET"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            Dim result As String = ""
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(stream)

            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("getControlCredito " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("getControlCredito " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function getVerificarConexion() As String
        Dim host As String = "https://carenapimanagement.prod.apimanagement.us10.hana.ondemand.com/ZC_CLIENT_CDS/ZC_CLIENT?$format=json"
        Dim autorizacion As String = EncodeStrToBase64(Me.username1.Trim & ":" & Me.password1.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "GET"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            Dim result As String = ""
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(stream)

            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("getVerificarConexion " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("getVerificarConexion " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function getPartidasClienteAbiertas(ByVal BPartner As String, ByVal fechaDesde As DateTime, ByVal fechaHasta As DateTime) As String
        Dim host As String = String.Format("https://carenapimanagement.prod.apimanagement.us10.hana.ondemand.com:443/ZVFI_GETOPENITEMS_CDS{0}/ZVFI_GETOPENITEMS(P_Bukrs='{1}',P_Kunnr='{2}',P_BudatD='{3:yyyyMMdd}',P_BudatH='{4:yyyyMMdd}')/Set?$format=json",
                                           str_sufijoMetodo.ToUpper(), sapCompany, BPartner, fechaDesde, fechaHasta)

        Dim autorizacion As String = EncodeStrToBase64(Me.username1.Trim & ":" & Me.password1.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "GET"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            Dim result As String = ""
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(stream)

            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("getPartidasClienteAbiertas " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("getPartidasClienteAbiertas " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function getResolucionGarantia(ByVal numeroAvisoGarantia As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/GetResGarantia{0}?sap-client={1}&$filter= INrogarantia eq '{2}'", str_sufijoMetodo, sapClient, numeroAvisoGarantia)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "GET"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            Dim result As String = ""
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(stream)

            result = reader.ReadToEnd()
            stream.Close()
            Return result

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("getResolucionGarantia " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("getResolucionGarantia " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function postCierreCaja(ByVal postData As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/CierreCaja{0}", str_sufijoMetodo)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

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

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("postCierreCaja [" & postData & "] " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("postCierreCaja [" & postData & "] " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function postMedioPago(ByVal postData As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/MediosPago{0}", str_sufijoMetodo)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

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

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("postMedioPago [" & postData & "] " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("postMedioPago [" & postData & "] " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function postPedidoVenta(ByVal postData As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/CreateDelivery{0}", str_sufijoMetodo)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

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

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("postPedidoVenta [" & postData & "] " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("postPedidoVenta [" & postData & "] " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function postCrearVenta(ByVal postData As String, Optional ByVal timeout As Integer = 100000) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/CreateVenta{0}", str_sufijoMetodo)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

            req.Timeout = timeout

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

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("postCrearVenta [" & postData & "] " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("postCrearVenta [" & postData & "] " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function postCrearCliente(ByVal postData As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/CreateBP{0}", str_sufijoMetodo)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

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

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("postCrearCliente [" & postData & "] " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("postCrearCliente [" & postData & "] " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function postAnularDeposito(ByVal postData As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/AnulDepositos{0}", str_sufijoMetodo)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

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

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("postAnularDeposito [" & postData & "] " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("postAnularDeposito [" & postData & "] " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function postBloquearNotaVenta(ByVal postData As String) As String
        Dim host As String = String.Format("https://devcaren.it-cpi003-rt.cfapps.us10.hana.ondemand.com/http/BloqueoPos{0}", str_sufijoMetodo)
        Dim autorizacion As String = EncodeStrToBase64(Me.username2.Trim & ":" & Me.password2.Trim)

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(a, b, c, d) True
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = CType(WebRequest.Create(host), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/json; charset=utf-8"
            req.Headers.Add("Authorization", "Basic " & autorizacion)

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

        Catch wex As WebException
            Dim WebExceptionMessage As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd
            func_RegistrarEnArchivoLog("postBloquearNotaVenta [" & postData & "] " & WebExceptionMessage, wex.StackTrace & vbCrLf)

        Catch e As Exception
            func_RegistrarEnArchivoLog("postBloquearNotaVenta [" & postData & "] " & e.Message, e.StackTrace & vbCrLf)
        End Try
        Return ""
    End Function

    Public Function func_estadosPartidasAbiertasCliente(ByVal BPartner As String) As EstadoPartidasCliente
        Dim tbaPosCodigoPartidaCliente As pos_codigoPartidaClienteTableAdapter = New pos_codigoPartidaClienteTableAdapter
        Dim obj_resultado As EstadoPartidasCliente = New EstadoPartidasCliente
        Dim obj_partidasAbiertasCliente As PartidasAbiertasClienteModel = Nothing
        Dim obj_sap As class_sap = Nothing
        Dim str_resultadoJSON As String = ""
        Dim str_tipoDocPorPagar As String = ""
        Dim int_diasVencimientoDoc As Integer = 10 ' se permiten documentos con 10 dias de vencimiento
        Dim str_codigoFactura As String = "1UVXYZ"
        Dim dat_fechaDesde As DateTime = Configuracion.fechaInicioPartidas

        Try
            str_resultadoJSON = getPartidasClienteAbiertas(BPartner, dat_fechaDesde, Now)

            If String.IsNullOrEmpty(str_resultadoJSON) = False Then
                obj_partidasAbiertasCliente = JsonConvert.DeserializeObject(Of PartidasAbiertasClienteModel)(str_resultadoJSON)

                If Not obj_partidasAbiertasCliente Is Nothing Then

                    'Evaluamos Facturas Morosas
                    For Each partidaCliente In obj_partidasAbiertasCliente.d.results
                        If partidaCliente.ClaseDoc.ToString().ToUpper() = "CI" Then
                            If partidaCliente.Texto.Trim() = "FACTURAS CXC" AndAlso Now.Subtract(partidaCliente.FechaVenc).Days > int_diasVencimientoDoc Then
                                obj_resultado.EstadoFacturas = 1
                                Exit For

                            ElseIf partidaCliente.Texto.Trim() = "FACTURAS CXC" AndAlso partidaCliente.TipoCheque.ToString().Trim() <> "" AndAlso str_codigoFactura.Contains(partidaCliente.TipoCheque.ToString().Trim()) = True Then
                                obj_resultado.EstadoFacturas = 1
                                Exit For

                            End If

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "V1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "R1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZF") AndAlso
                            Now.Subtract(partidaCliente.FechaVenc).Days > int_diasVencimientoDoc Then 'Facturas
                            obj_resultado.EstadoFacturas = 1
                            Exit For

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "V1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "R1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZF") AndAlso
                             partidaCliente.TipoCheque.ToString().Trim() <> "" AndAlso str_codigoFactura.Contains(partidaCliente.TipoCheque.ToString().Trim()) = True Then 'Facturas
                            obj_resultado.EstadoFacturas = 1
                            Exit For

                        End If
                    Next

                    'Evaluamos Cheques
                    For Each partidaCliente In obj_partidasAbiertasCliente.d.results
                        If partidaCliente.ClaseDoc.ToString().ToUpper() = "CI" Then
                            If partidaCliente.Texto.Trim().ToUpper() = "CHEQUES EN CARTERA" AndAlso Now.Subtract(partidaCliente.FechaVenc).Days > int_diasVencimientoDoc Then
                                obj_resultado.EstadoCheques = 1
                                Exit For

                            ElseIf partidaCliente.Texto.Trim().ToUpper() = "CHEQUES EN CARTERA" AndAlso tbaPosCodigoPartidaCliente.CuentaByTipoClasificacionBloqueo(partidaCliente.TipoCheque.ToString().Trim().ToUpper(), "CHEQUE", 1) > 0 Then
                                obj_resultado.EstadoCheques = 1
                                Exit For

                            End If

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "ZS" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZB" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZD" OrElse
                                partidaCliente.ClaseDoc.ToString().ToUpper() = "ZA") And partidaCliente.TipoCheque.ToString().Trim() = "A" Then 'Anticipos
                            'ignoramos los anticipos

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "ZS" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZC") AndAlso Now.Subtract(partidaCliente.FechaVenc).Days > int_diasVencimientoDoc Then 'Cheques
                            obj_resultado.EstadoCheques = 1
                            Exit For

                        ElseIf tbaPosCodigoPartidaCliente.CuentaByTipoClasificacionBloqueo(partidaCliente.TipoCheque.ToString().Trim().ToUpper(), "CHEQUE", 1) > 0 Then
                            obj_resultado.EstadoCheques = 1
                            Exit For

                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try

        Return obj_resultado

    End Function

    Public Function func_estadoPartidasAbiertasCliente(ByVal BPartner As String) As Integer
        Dim int_resultado As Integer = 0
        Dim obj_partidasAbiertasCliente As PartidasAbiertasClienteModel = Nothing
        Dim obj_sap As class_sap = Nothing
        Dim str_resultadoJSON As String = ""
        Dim str_tipoDocPorPagar As String = ""
        Dim int_diasVencimientoDoc As Integer = 10 ' se permiten documentos con 10 dias de vencimiento
        Dim str_codigoFactura As String = "1UVXYZ"
        Dim str_codigoCheque As String = "2DELMNÑOQRS" '2EMNÑORS
        Dim dat_fechaDesde As DateTime = Configuracion.fechaInicioPartidas

        Try
            str_resultadoJSON = getPartidasClienteAbiertas(BPartner, dat_fechaDesde, Now)

            If String.IsNullOrEmpty(str_resultadoJSON) = False Then
                obj_partidasAbiertasCliente = JsonConvert.DeserializeObject(Of PartidasAbiertasClienteModel)(str_resultadoJSON)

                If Not obj_partidasAbiertasCliente Is Nothing Then

                    For Each partidaCliente In obj_partidasAbiertasCliente.d.results
                        If partidaCliente.ClaseDoc.ToString().ToUpper() = "CI" Then
                            If partidaCliente.Texto.Trim() = "FACTURAS CXC" AndAlso Now.Subtract(partidaCliente.FechaVenc).Days > int_diasVencimientoDoc Then
                                int_resultado = 1
                                Exit For

                            ElseIf partidaCliente.Texto.Trim() = "FACTURAS CXC" AndAlso partidaCliente.TipoCheque.ToString().Trim() <> "" AndAlso str_codigoFactura.Contains(partidaCliente.TipoCheque.ToString().Trim()) = True Then
                                int_resultado = 1
                                Exit For

                            ElseIf partidaCliente.Texto.Trim().ToUpper() = "CHEQUES EN CARTERA" AndAlso Now.Subtract(partidaCliente.FechaVenc).Days > int_diasVencimientoDoc Then
                                int_resultado = 2
                                Exit For

                            ElseIf partidaCliente.Texto.Trim().ToUpper() = "CHEQUES EN CARTERA" AndAlso partidaCliente.TipoCheque.ToString().Trim() <> "" AndAlso str_codigoCheque.Contains(partidaCliente.TipoCheque.ToString().Trim()) = True Then
                                int_resultado = 2
                                Exit For

                            End If

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "V1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "R1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZF") AndAlso
                            Now.Subtract(partidaCliente.FechaVenc).Days > int_diasVencimientoDoc Then 'Facturas
                            int_resultado = 1
                            Exit For

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "V1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "R1" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZF") AndAlso
                             partidaCliente.TipoCheque.ToString().Trim() <> "" AndAlso str_codigoFactura.Contains(partidaCliente.TipoCheque.ToString().Trim()) = True Then 'Facturas
                            int_resultado = 1
                            Exit For

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "ZS" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZC") AndAlso Now.Subtract(partidaCliente.FechaVenc).Days > int_diasVencimientoDoc Then 'Cheques
                            int_resultado = 2
                            Exit For

                        ElseIf (partidaCliente.ClaseDoc.ToString().ToUpper() = "ZS" OrElse partidaCliente.ClaseDoc.ToString().ToUpper() = "ZC") AndAlso partidaCliente.TipoCheque.ToString().Trim() <> "" AndAlso
                            str_codigoCheque.Contains(partidaCliente.TipoCheque.ToString().Trim()) = True Then 'Cheques
                            int_resultado = 2
                            Exit For

                        End If
                    Next

                End If
            End If
        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try

        Return int_resultado
    End Function

    Public Shared Function condicionPago(ByVal dgvControl As DataGridView, fechaDocPago As Date, ByVal BPartner As String, ByVal OrgVentas As String, ByVal idCanal As String, ByVal sector As String) As condicionPago
        Dim obj_condicionPago As condicionPago = New condicionPago()
        Dim tbaVwClienteDatosCom As vw_cliente_datosComTableAdapter = New vw_cliente_datosComTableAdapter
        Dim dtbVwClienteDatosCom As DataTable = Nothing
        Dim intCantidadCheques As Integer = 0
        Dim lstDiasVencimientoCheques As List(Of Integer) = New List(Of Integer)
        Dim intDiferenciaVencimiento As Integer = 0

        dtbVwClienteDatosCom = tbaVwClienteDatosCom.GetDataByBPartnerOrgVentasIDCanalSector(BPartner, OrgVentas, idCanal, sector)

        For Each filaPagos As DataGridViewRow In dgvControl.Rows
            If filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Efectivo" Then
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1
                obj_condicionPago.nombreCondicionPago = "CONTADO"
                obj_condicionPago.FechaVencimiento = Now
                Exit For

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Tarj. Débito" Then
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1
                obj_condicionPago.nombreCondicionPago = "CONTADO"
                obj_condicionPago.FechaVencimiento = Now
                Exit For

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Tarj. Crédito" Then
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1
                obj_condicionPago.nombreCondicionPago = "CONTADO"
                obj_condicionPago.FechaVencimiento = Now
                Exit For

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Cheque" Then
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item2
                obj_condicionPago.nombreCondicionPago = "CHEQUE"
                intCantidadCheques += 1

                If IsDate(filaPagos.Cells("col_fechaCheque").Value.ToString().Trim) = True Then
                    intDiferenciaVencimiento = Convert.ToDateTime(filaPagos.Cells("col_fechaCheque").Value.ToString().Trim).Subtract(fechaDocPago).Days

                    If intDiferenciaVencimiento >= 0 AndAlso intDiferenciaVencimiento <= 10 Then
                        lstDiasVencimientoCheques.Add(0)

                    ElseIf intDiferenciaVencimiento >= 26 AndAlso intDiferenciaVencimiento <= 35 Then
                        lstDiasVencimientoCheques.Add(30)

                    ElseIf intDiferenciaVencimiento >= 36 AndAlso intDiferenciaVencimiento <= 49 Then
                        lstDiasVencimientoCheques.Add(45)

                    ElseIf intDiferenciaVencimiento >= 50 AndAlso intDiferenciaVencimiento <= 65 Then
                        lstDiasVencimientoCheques.Add(60)

                    ElseIf intDiferenciaVencimiento >= 80 AndAlso intDiferenciaVencimiento <= 100 Then
                        lstDiasVencimientoCheques.Add(90)

                    ElseIf intDiferenciaVencimiento >= 110 AndAlso intDiferenciaVencimiento <= 130 Then
                        lstDiasVencimientoCheques.Add(120)

                    ElseIf intDiferenciaVencimiento >= 140 AndAlso intDiferenciaVencimiento <= 160 Then
                        lstDiasVencimientoCheques.Add(150)

                    End If

                End If

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Nota de Crédito" Then
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1
                obj_condicionPago.nombreCondicionPago = "CONTADO"
                obj_condicionPago.FechaVencimiento = Now
                Exit For

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Transferencia" Then
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1
                obj_condicionPago.nombreCondicionPago = "CONTADO"
                obj_condicionPago.FechaVencimiento = Now
                Exit For

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Línea de Crédito" Then
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item2
                obj_condicionPago.nombreCondicionPago = "CUENTA CORRIENTE"
                obj_condicionPago.FechaVencimiento = Now.AddDays(30)

                If dtbVwClienteDatosCom.Rows.Count > 0 Then
                    If dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CC01" Then
                        obj_condicionPago.nombreCondicionPago = "CONTADO"
                        obj_condicionPago.FechaVencimiento = Now

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CC02" Then
                        obj_condicionPago.nombreCondicionPago = "CONTADO"
                        obj_condicionPago.FechaVencimiento = Now

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CC03" Then
                        obj_condicionPago.nombreCondicionPago = "CONTADO"
                        obj_condicionPago.FechaVencimiento = Now

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CC04" Then
                        obj_condicionPago.nombreCondicionPago = "CONTADO"
                        obj_condicionPago.FechaVencimiento = Now

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CC05" Then
                        obj_condicionPago.nombreCondicionPago = "CONTADO"
                        obj_condicionPago.FechaVencimiento = Now

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CC06" Then
                        obj_condicionPago.nombreCondicionPago = "CONTADO"
                        obj_condicionPago.FechaVencimiento = Now

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT01" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 30 DIAS."
                        obj_condicionPago.FechaVencimiento = Now.AddDays(30)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT02" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 45 DIAS."
                        obj_condicionPago.FechaVencimiento = Now.AddDays(45)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT03" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 60 DIAS."
                        obj_condicionPago.FechaVencimiento = Now.AddDays(60)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT04" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 75 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(75)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT05" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 90 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(90)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT06" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 120 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(120)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT07" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 150 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(150)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT08" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 180 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(180)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT10" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 30,60 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(30)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT11" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 30,60,90 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(30)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT12" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 30,60,90,120 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(30)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT13" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 30,60,90,120,150 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(30)

                    ElseIf dtbVwClienteDatosCom.Rows(0).Item("CondPago").ToString() = "CT14" Then
                        obj_condicionPago.nombreCondicionPago = "CTA. CTE. 30,60,90,120,150,180 DIAS"
                        obj_condicionPago.FechaVencimiento = Now.AddDays(30)

                    End If

                End If

                Exit For

            ElseIf filaPagos.Cells("col_tipoMedioPago").Value.ToString().Trim = "Linea Funcionario" Then
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item2
                obj_condicionPago.nombreCondicionPago = "CUENTA CORRIENTE"
                Exit For

            Else
                obj_condicionPago.CodigoCondicionPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1
                obj_condicionPago.nombreCondicionPago = "CONTADO"
                obj_condicionPago.FechaVencimiento = Now
                Exit For

            End If

        Next

        If intCantidadCheques = 1 Then
            obj_condicionPago.FechaVencimiento = Now.AddMonths(1)

            If lstDiasVencimientoCheques.Count > 0 Then
                If lstDiasVencimientoCheques.Item(0) = 0 Then
                    obj_condicionPago.nombreCondicionPago &= " AL DÍA"
                    obj_condicionPago.FechaVencimiento = Now
                Else
                    obj_condicionPago.nombreCondicionPago &= " " & lstDiasVencimientoCheques.Item(0).ToString() & " DÍAS"
                End If

            End If

        ElseIf intCantidadCheques > 1 Then
            obj_condicionPago.FechaVencimiento = Now.AddMonths(1)
            obj_condicionPago.nombreCondicionPago &= " "

            For Each itemDia As Integer In lstDiasVencimientoCheques
                If itemDia = 0 Then
                    obj_condicionPago.nombreCondicionPago &= "AL DÍA,"
                Else
                    obj_condicionPago.nombreCondicionPago &= itemDia.ToString() & ","
                End If

            Next

            obj_condicionPago.nombreCondicionPago &= " "
            obj_condicionPago.nombreCondicionPago = obj_condicionPago.nombreCondicionPago.Replace(", ", "")
            obj_condicionPago.nombreCondicionPago &= " DÍAS"
        End If

        Return obj_condicionPago
    End Function

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

    Public Function func_RegistrarEnArchivoLog(ByVal str_EntradaRegistroLog As String, Optional ByVal str_StackTrace As String = "", Optional ByVal nombreUsuario As String = "") As Boolean
        Dim ObjetoLock As New Object
        Dim AppPath As String = AppDomain.CurrentDomain.BaseDirectory

        SyncLock ObjetoLock
            Dim str_NombreArchivoLog As String
            Try
                'Registro en archivo
                str_NombreArchivoLog = AppPath & "log\sap_" & Format(Now, "yyyy-MM-dd") & ".log"
                Dim str_NombreUsuario As String = nombreUsuario
                Dim str_EntradaRegistroLogFormateada As String = Format(Now, "HH:mm:ss") & "[" & Environment.MachineName & "](" & str_NombreUsuario & ") " & str_EntradaRegistroLog & vbCrLf & str_StackTrace
                File.AppendAllText(str_NombreArchivoLog, str_EntradaRegistroLogFormateada)
                Return True
            Catch ex As Exception
                'Crear un registro de error en C:\ 
                Try
                    str_NombreArchivoLog = "C:\sap_" & Format(Now, "yyyy-MM-dd") & ".log"
                    File.AppendAllText(str_NombreArchivoLog, str_EntradaRegistroLog & vbCrLf & str_StackTrace)
                Catch exFile As Exception
                End Try
            End Try
            Return False
        End SyncLock
    End Function

End Class

Public Class condicionPago
    Dim mvarCodigoCondicionPago As DTEDefTypeDocumentoEncabezadoIdDocFmaPago = DTEDefTypeDocumentoEncabezadoIdDocFmaPago.Item1
    Dim mvarNombreCondicionPago As String = ""
    Dim mvarFechaVencimiento As Date = Now

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(codigoCondicionPago As DTEDefTypeDocumentoEncabezadoIdDocFmaPago, nombreCondicionPago As String, mvarFechaVencimiento As Date)
        Me.mvarFechaVencimiento = mvarFechaVencimiento
        Me.CodigoCondicionPago = codigoCondicionPago
        Me.nombreCondicionPago = nombreCondicionPago
    End Sub

    Public Property CodigoCondicionPago As DTEDefTypeDocumentoEncabezadoIdDocFmaPago
        Set(value As DTEDefTypeDocumentoEncabezadoIdDocFmaPago)
            mvarCodigoCondicionPago = value
        End Set
        Get
            Return Me.mvarCodigoCondicionPago
        End Get
    End Property

    Public Property nombreCondicionPago As String
        Set(value As String)
            mvarNombreCondicionPago = value
        End Set
        Get
            Return Me.mvarNombreCondicionPago
        End Get
    End Property

    Public Property FechaVencimiento As Date
        Set(value As Date)
            mvarFechaVencimiento = value
        End Set
        Get
            Return Me.mvarFechaVencimiento
        End Get
    End Property

End Class

Public Class EstadoPartidasCliente
    Dim mvarEstadoCheques As Integer
    Dim mvarEstadoFacturas As Integer

    Public Property EstadoCheques As Integer
        Set(value As Integer)
            mvarEstadoCheques = value
        End Set
        Get
            Return Me.mvarEstadoCheques
        End Get
    End Property

    Public Property EstadoFacturas As Integer
        Set(value As Integer)
            mvarEstadoFacturas = value
        End Set
        Get
            Return Me.mvarEstadoFacturas
        End Get
    End Property

End Class
