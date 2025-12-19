Imports System.IO
Imports System.Text

Namespace OrsanAPI

    Public Class class_ORSAN

        Dim lectorConfig As New System.Configuration.AppSettingsReader
        Dim url As String = ""
        Dim apiKey As String = ""

        Public Sub New(ByVal url As String, ByVal apiKey As String)
            Me.url = url
            Me.apiKey = apiKey
        End Sub

        Public Function chequeProcess(ByVal postData As String) As Respuesta
            Dim mensaje As Byte() = Nothing
            Dim requestData As Byte() = Nothing
            Dim responseData As Byte() = Nothing
            Dim responseDataString As String = ""
            Dim nTxLen As Integer = 0
            Dim requerimiento As String
            Dim i As Integer
            Dim classEsb As OrsanWS.ChequesService = Nothing
            Dim obj_respuesta As Respuesta = Nothing
            Dim mensajeEx As String = ""

            Dim respuesta As String = ""
            Dim motivo1 As String = ""
            Dim autorizacion As String = ""
            Dim mensaje_visor As String = ""

            Try
                mensaje = Encoding.UTF8.GetBytes(postData)
                Dim lenRx As Byte() = New Byte(mensaje.Length + 2 - 1) {}

                Console.WriteLine("================================================")
                Console.WriteLine("DATOS CADENA ENTRADA")
                Console.WriteLine("================================================")
                Console.WriteLine("Cadena.................: ")
                Console.WriteLine("                         " & postData & "#")
                Console.WriteLine("Payload Cadena.........: " & postData.Length)

                'almacenamos el largo del mensaje en los dos primeros bytes de la matriz
                lenRx(0) = CByte(((mensaje.Length) / 256))
                lenRx(1) = CByte(((mensaje.Length) Mod 256))

                'movemos todos los datos 2 bytes hacia adelante en la matriz
                For i = 2 To lenRx.Length - 1
                    lenRx(i) = mensaje(i - 2)
                Next

                requestData = lenRx

                Console.WriteLine("")
                Console.WriteLine("================================================")
                Console.WriteLine("DATOS MENSAJERIA REQUEST")
                Console.WriteLine("================================================")
                Console.WriteLine("Mensaje Request........: " & Encoding.UTF8.GetString(requestData))
                Console.WriteLine("Payload Request........: " & requestData.Length)

                Try
                    Console.WriteLine("")
                    Console.WriteLine("================================================")
                    Console.WriteLine("CONSUMO SERVICIO")
                    Console.WriteLine("================================================")

                    classEsb = New OrsanWS.ChequesService()
                    classEsb.Url = Me.url

                    Console.WriteLine("Inicio.................:" & DateTime.Now)

                    responseData = classEsb.chequeProcess(requestData)
                    responseDataString = Encoding.UTF8.GetString(responseData)

                    Console.WriteLine("Fin....................:" & DateTime.Now)
                    Console.WriteLine("")
                    Console.WriteLine("================================================")
                    Console.WriteLine("DATOS MENSAJERIA RESPONSE")
                    Console.WriteLine("================================================")
                    Console.WriteLine("Mensaje Response.......: " & responseDataString)
                    Console.WriteLine("Payload Response.......: " & responseData.Length)

                    Try
                        Console.WriteLine("Primer Valor...........: " & (responseData(0) And &HFF) * 256)
                        Console.WriteLine("Segundo Valor..........: " & (responseData(1) And &HFF))
                        nTxLen = ((responseData(0) And &HFF) * 256) + (responseData(1) And &HFF)
                        Console.WriteLine("Payload Cadena.........: " & nTxLen)
                        Dim buffMsj As Byte() = New Byte(nTxLen - 1) {}

                        If responseData.Length > 2 Then

                            For i = 2 To responseData.Length - 1
                                buffMsj(i - 2) = responseData(i)
                            Next
                        Else
                            Console.WriteLine("")
                            Console.WriteLine("REQUERIMIENTO NO VALIDO")
                            Console.WriteLine("")
                        End If

                        Try
                            requerimiento = Encoding.UTF8.GetString(buffMsj)

                            If requerimiento.Length >= 77 Then
                                respuesta = requerimiento.Substring(76, 1)
                            End If

                            If respuesta = "0" Then '0 = Successful
                                motivo1 = requerimiento.Substring(85, 3)
                                autorizacion = requerimiento.Substring(101, 6)
                                mensaje_visor = requerimiento.Substring(135, 40)

                            ElseIf respuesta = "1" Then 'Service does Not respond Or failed
                                motivo1 = "Service does Not respond Or failed"
                                autorizacion = ""
                                mensaje_visor = "Service does Not respond Or failed"

                            Else 'Other = System Error
                                motivo1 = "System Error"
                                autorizacion = ""
                                mensaje_visor = "System Error"

                            End If

                            If IsNumeric(respuesta) = False Then
                                respuesta = "-1"
                            End If

                            obj_respuesta = New Respuesta(respuesta, motivo1, mensaje_visor, autorizacion, responseDataString)

                            Console.WriteLine("")
                            Console.WriteLine("================================================")
                            Console.WriteLine("RESPUESTA TRANSACCION")
                            Console.WriteLine("================================================")
                            Console.WriteLine("Rechazo................:" & motivo1)
                            Console.WriteLine("Motivo Rechazo.........:" & mensaje_visor)
                            Console.WriteLine("Codigo Autorizacion....:" & autorizacion)

                        Catch ex As Exception
                            obj_respuesta = New Respuesta("-2", "Nivel 2", ex.Message & " " & ex.StackTrace, autorizacion, responseDataString)
                            Console.WriteLine("")
                            Console.WriteLine("Nivel 2 " & ex.Message & " " & ex.StackTrace)
                            Console.WriteLine("")
                        End Try

                    Catch ex As Exception
                        obj_respuesta = New Respuesta("-3", "Nivel 3", ex.Message & " " & ex.StackTrace, autorizacion, responseDataString)
                        Console.WriteLine("")
                        Console.WriteLine("Nivel 3 " & ex.Message & " " & ex.StackTrace)
                        Console.WriteLine("")
                    End Try

                Catch ex As Exception
                    obj_respuesta = New Respuesta("-4", "Nivel 4", ex.Message & " " & ex.StackTrace, autorizacion, responseDataString)
                    Console.WriteLine("")
                    Console.WriteLine("Nivel 4 " & ex.Message & " " & ex.StackTrace)
                    Console.WriteLine("")
                End Try

            Catch ex As Exception
                obj_respuesta = New Respuesta("-5", "Nivel 5", ex.Message & " " & ex.StackTrace, autorizacion, responseDataString)
                Console.WriteLine("")
                Console.WriteLine("Nivel 5 " & ex.Message & " " & ex.StackTrace)
                Console.WriteLine("")
            End Try

            Return obj_respuesta
        End Function

        Public Function func_RegistrarEnArchivoLog(ByVal str_EntradaRegistroLog As String, Optional ByVal str_StackTrace As String = "", Optional ByVal nombreUsuario As String = "") As Boolean
            Dim ObjetoLock As New Object
            Dim AppPath As String = AppDomain.CurrentDomain.BaseDirectory

            SyncLock ObjetoLock
                Dim str_NombreArchivoLog As String
                Try
                    'Registro en archivo
                    str_NombreArchivoLog = AppPath & "ORSAN\orsan_" & Format(Now, "yyyy-MM-dd") & ".log"
                    Dim str_NombreUsuario As String = nombreUsuario
                    Dim str_EntradaRegistroLogFormateada As String = Format(Now, "HH:mm:ss") & "[" & Environment.MachineName & "](" & str_NombreUsuario & ") " & str_EntradaRegistroLog & vbCrLf & str_StackTrace
                    File.AppendAllText(str_NombreArchivoLog, str_EntradaRegistroLogFormateada)
                    Return True
                Catch ex As Exception
                End Try
                Return False
            End SyncLock
        End Function

    End Class

    Public Class Respuesta

        Private str_respuesta As String
        Private str_motivo1 As String
        Private str_mensajeVisor As String
        Private str_autorizacion As String
        Private str_data As String

        Public Sub New(ByVal respuesta As String, ByVal motivo1 As String, ByVal mensajeVisor As String, ByVal autorizacion As String, ByVal data As String)
            str_motivo1 = motivo1
            str_mensajeVisor = mensajeVisor
            str_autorizacion = autorizacion
            str_respuesta = respuesta
            str_data = data
        End Sub

        Public ReadOnly Property Motivo1 As String
            Get
                Return str_motivo1
            End Get
        End Property

        Public ReadOnly Property MensajeVisor As String
            Get
                Return str_mensajeVisor
            End Get
        End Property

        Public ReadOnly Property Autorizacion As String
            Get
                Return str_autorizacion
            End Get
        End Property

        Public ReadOnly Property Respuesta As String
            Get
                Return str_respuesta
            End Get
        End Property

        Public ReadOnly Property Data As String
            Get
                Return str_data
            End Get
        End Property

    End Class

End Namespace
