Imports Microsoft.PointOfService
Imports System.Globalization
Imports System.Reflection
Imports System.Text

Public Class class_PosPrinter

    'Printer object
    Private m_Printer As PosPrinter = Nothing

    'Now Step
    Private m_strStep As String = "MicrSample_Step2"

    Private m_strRawData As String = ""
    Private m_strMessage As String = ""

    Public Function Initialize() As Boolean
        Dim strLogicalName As String
        Dim deviceInfo As DeviceInfo = Nothing
        Dim posExplorer As PosExplorer

        strLogicalName = "PosPrinter"
        '<<<step5>>--Start

        'Create PosExplorer
        posExplorer = New PosExplorer

        Try

            deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName)

        Catch ex As Exception

            Return False
        End Try

        '<<<step4>>>--Start
        Try
            m_Printer = posExplorer.CreateInstance(deviceInfo)

        Catch ex As Exception
            'Fails CreateInstance
            Return False
        End Try

        Try

            'Open the device
            m_Printer.Open()

        Catch ex As PosControlException

            MessageBox.Show("Este dispositivo no ha sido registrado en este computador ó NO puede ser usado. Registrelo con la utilidad Epson.opos.tm.setpos.exe", m_strStep, MessageBoxButtons.OK)

            'Nothing can be used.
            Return False
        End Try

        Try

            'Get the exclusive control right for the opened device.
            'Then the device is disable from other application.
            m_Printer.Claim(1000)

        Catch ex As PosControlException

            MessageBox.Show("Error al intentar acceso exclusivo al dispositivo.", m_strStep, MessageBoxButtons.OK)

            'Nothing can be used.
            Return False
        End Try

        Try

            'Enable the device.
            m_Printer.DeviceEnabled = True

        Catch ex As PosControlException

            MessageBox.Show("En este momento el dispositivo NO está disponible.", m_strStep, MessageBoxButtons.OK)

            'Nothing can be used.
            Return False
        End Try

        Return True

    End Function

    Public Function Remove() As Boolean
        If m_Printer Is Nothing Then

            Return False

        End If

        Try

            'Cancel the device
            m_Printer.DeviceEnabled = False

            'Release the device exclusive control right.
            m_Printer.Release()

        Catch ex As Exception

        Finally
            'Finish using the device.
            m_Printer.Close()

        End Try
    End Function

    ''' <summary>
    ''' The processing of the insertion of the slip paper and the
    ''' processing when an error occurs is described here.
    ''' </summary>
    Public Function WaitforInsertion(ByVal timeout As Integer) As Boolean

        '<<<Step10>>>--Start
        Dim dialogResult As DialogResult
        Dim bInsertion As Boolean = True

InsertStart:

        Do
            Try

                m_Printer.BeginInsertion(1000)

            Catch ex As PosControlException

                If ex.ErrorCode = ErrorCode.Timeout Then

                    dialogResult = MessageBox.Show(ex.Message, "Inserción de Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If dialogResult = DialogResult.No Then

                        bInsertion = False

                        Try
                            m_Printer.EndInsertion()
                            m_Printer.BeginRemoval(10000)

                        Catch ex2 As PosControlException

                        End Try

                        Return bInsertion

                    End If

                Else
                    Dim strMessage As String
                    strMessage = GetErrorCode(ex)
                    MessageBox.Show(strMessage, m_strStep)
                    bInsertion = False

                End If

            End Try

            Try
                m_Printer.EndInsertion()
                bInsertion = True

            Catch ex As PosControlException
                Dim strMessage As String = ""
                If ex.ErrorCodeExtended = PosPrinter.ExtendedErrorSlipEmpty Then

                    strMessage = "Please insert a form."

                Else
                    If m_Printer.SlpEmpty = False Then

                        strMessage = "Please remove a form."

                    Else

                        strMessage = GetErrorCode(ex)

                    End If
                End If


                dialogResult = MessageBox.Show(strMessage + vbCrLf + vbCrLf + "¿ Desea Continuar ?", "Imprimir Cheque", MessageBoxButtons.YesNo)

                If dialogResult = DialogResult.No Then
                    bInsertion = False
                    Return bInsertion
                End If

                Try
                    m_Printer.BeginRemoval(10000)


                Catch ex3 As PosControlException


                End Try

                GoTo InsertStart

            End Try

            Exit Do

        Loop

        Return bInsertion
        '<<<Step10>>>--End

    End Function

    ''' <summary>
    ''' The information related to the error from the parameter
    ''' "ex" is received as a type of "int".
    ''' Information by the sentence corresponding to the received
    ''' information is returned as "strErrorCodeEx".
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <returns>
    ''' "int" type information is changed into the information
    ''' by the sentence, and is returned as a "String" type.
    ''' "strErrorCodeEx" holds the information on this "int" type.
    ''' </returns>
    Private Function GetErrorCode(ByVal ex As PosControlException) As String

        '<<<step10>>>--Start
        Dim strErrorCodeEx As String = ""
        Dim strEC As String = ""
        Dim strECE As String = ""

        Select Case ex.ErrorCodeExtended

            Case PosPrinter.ExtendedErrorCoverOpen
                strErrorCodeEx = ex.Message
            Case PosPrinter.ExtendedErrorJournalEmpty
                strErrorCodeEx = ex.Message
            Case PosPrinter.ExtendedErrorReceiptEmpty
                strErrorCodeEx = ex.Message
            Case PosPrinter.ExtendedErrorSlipEmpty
                strErrorCodeEx = ex.Message
            Case Else
                strEC = ex.ErrorCode.ToString()
                strECE = ex.ErrorCodeExtended.ToString()
                strErrorCodeEx = "ErrorCode =" + strEC + vbCrLf + "ErrorCodeExtended =" + strECE + vbCrLf _
                + ex.Message

        End Select

        GetErrorCode = strErrorCodeEx

        '<<<step10>>>--End
    End Function

    Public Function PrintFrontSide(ByRef obj_MICR As class_MICR, ByRef obj_PosPrinter As class_PosPrinter, ByVal fechaCheque As Date, ByVal montoCheque As Integer, ByVal nombreEmpresaPago As String, ByVal nombreCiudadCheque As String,
                                   ByVal montoEnPalabras As String, ByVal FilaFormato As DataRow, ByVal CodigoFormatoCheque As Integer) As Boolean
        Dim nowDate As DateTime = fechaCheque
        Dim dateFormat As DateTimeFormatInfo = New DateTimeFormatInfo
        Dim strPrintData As StringBuilder = New StringBuilder
        Dim lineaActual As Integer = 1
        Dim montoLinea1 As String = ""
        Dim montoLinea2 As String = ""
        Dim largoMaximoLinea1 As Integer = 60
        Dim largoMaximoLinea2 As Integer = 30
        Dim ESC As String = Chr(&H1B) 'ESC command
        Dim GS As String = Chr(&H1D)
        Dim FUENTE As String = Chr(&H99)
        Dim arrMonto As String() = Nothing
        Dim largoLineaCruzarCheque As Integer = 55

        Try
            m_Printer.ChangePrintSide(PrinterSide.Side1) 'Al llamar este método indicamos a la impresora que debe resetear la posición del cabezal de la impresora. El cheque debe moverse hacia abajo.
            m_Printer.ChangePrintSide(PrinterSide.Side1) 'Llamamos nuevamente al método para asegurarnos que se ha movido el cheque. No siempre el cabezal se mueve la primera vez. Si NO se mueve el cabezal la impresión el eje X es mayor. 

        Catch ex As PosControlException
            Me.mensaje = ex.Message & " " & ex.StackTrace
            Return False
        End Try

        arrMonto = montoEnPalabras.Split(" ")

        For indice As Integer = 0 To arrMonto.Length - 1
            If arrMonto(indice).Trim <> "" Then
                'If montoLinea1.Length + arrMonto(indice).Length < largoMaximoLinea1 Then
                '    montoLinea1 &= arrMonto(indice).Trim & " "
                'Else
                '    montoLinea2 &= arrMonto(indice).Trim & " "
                'End If

                If montoLinea1.Length + arrMonto(indice).Length < largoMaximoLinea1 AndAlso lineaActual = 1 Then
                    montoLinea1 &= arrMonto(indice).Trim & " "
                Else
                    montoLinea2 &= arrMonto(indice).Trim & " "
                    lineaActual = 2
                End If

            End If
        Next

        'If CodigoFormatoCheque = 1 Then
        '    largoMaximoLinea1 = 60
        '    largoMaximoLinea2 = 30

        'ElseIf CodigoFormatoCheque = 2 Then
        '    largoMaximoLinea1 = 63
        '    largoMaximoLinea2 = 25
        'End If

        largoMaximoLinea1 = FilaFormato.Item("largoMaximoLinea1")
        largoMaximoLinea2 = FilaFormato.Item("largoMaximoLinea2")
        largoLineaCruzarCheque = FilaFormato.Item("largoLineaCruzarCheque")

        If montoLinea1.Length < largoMaximoLinea1 Then
            montoLinea1 &= New String("*", largoMaximoLinea1 - montoLinea1.Length)
        End If

        If montoLinea2.Length < largoMaximoLinea2 Then
            montoLinea2 &= New String("*", largoMaximoLinea2 - montoLinea2.Length)
        End If

        Try
            m_Printer.PageModeStation = PrinterStation.Slip
            m_Printer.PageModePrint(PageModePrintControl.PageMode)
            m_Printer.PageModePrintDirection = PageModePrintDirection.BottomToTop '90 grados a la izquierda
            m_Printer.PageModePrintArea = New Rectangle(0, 0, m_Printer.PageModeArea.X, m_Printer.PageModeArea.Y)

        Catch ex As PosControlException
            Dim mensaje As String = ex.Message

            Return False

            'obj_PosPrinter.Remove()
            'obj_PosPrinter.Initialize()

            'm_Printer.PageModeStation = PrinterStation.Slip
            'm_Printer.PageModePrint(PageModePrintControl.PageMode)
            'm_Printer.PageModePrintDirection = PageModePrintDirection.BottomToTop '90 grados a la izquierda
            'm_Printer.PageModePrintArea = New Rectangle(0, 0, m_Printer.PageModeArea.X, m_Printer.PageModeArea.Y)

        End Try

        Try

            'If CodigoFormatoCheque = 1 Then

            '    'monto en números
            '    m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX1") ' 15
            '    m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY1") ' 90
            '    strPrintData.Clear()
            '    strPrintData.Append(ESC & "|rA" + Format(montoCheque, New String("*", 6) & "#,##0") & ".-")
            '    m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            '    'nombre de plaza del cheque y número de dia
            '    m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX2") '165
            '    m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY2") ' 130
            '    strPrintData.Clear()
            '    strPrintData.Append(ESC & "|rA" + nombreCiudadCheque & ",  " & nowDate.ToString("dd"))
            '    m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            '    'número de mes
            '    m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX3") '70
            '    'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY3") ' 130
            '    strPrintData.Clear()
            '    strPrintData.Append(ESC & "|rA" & MonthName(nowDate.Month))
            '    m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            '    'número de año
            '    m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX4") '5
            '    'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY4") ' 130
            '    strPrintData.Clear()
            '    strPrintData.Append(ESC & "|rA" & nowDate.ToString("yy"))
            '    m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            '    'destino pago
            '    m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX5") '330
            '    m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY5") ' 145
            '    strPrintData.Clear()
            '    strPrintData.Append(ESC & "|rA" & nombreEmpresaPago)
            '    m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            '    'monto en palabras linea 1
            '    m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX6") '0
            '    m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY6") ' 162
            '    strPrintData.Clear()
            '    strPrintData.Append(ESC & "|rA" & montoLinea1)
            '    m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            '    'monto en palabras linea 2
            '    m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX7") '165
            '    m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY7") ' 172
            '    strPrintData.Clear()
            '    strPrintData.Append(ESC & "|rA" & montoLinea2)
            '    m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            'Else
            If CodigoFormatoCheque = 2 Then ' cheque con casilleros
                'monto en números
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX1")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY1")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" + Format(montoCheque, New String("*", 18) & "#,##0") & ".-")
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                'nombre de plaza del cheque
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX2")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY2")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" + nombreCiudadCheque)
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                'número de dia
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX3")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY3")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" + nowDate.ToString("dd"))
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                'número de mes
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX4")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY4")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" & nowDate.ToString("MM"))
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                'número de año
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX5")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY5")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" & nowDate.ToString("yy"))
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                'destino pago
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX6")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY6")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" & nombreEmpresaPago)
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                'monto en palabras linea 1
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX7")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY7")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" & montoLinea1)
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                'monto en palabras linea 2
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX8")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY8")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" & montoLinea2)
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            End If

            'Cambiamos la orientación de la impresión a horizontal para cruzar el cheque
            m_Printer.PageModePrintDirection = PageModePrintDirection.LeftToRight
            m_Printer.PageModePrintArea = New Rectangle(0, 0, m_Printer.PageModeArea.X, m_Printer.PageModeArea.Y)

            'cruzamos el cheque linea 1
            m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX9")
            m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY9")
            strPrintData.Clear()
            strPrintData.Append(ESC & New String("-", largoLineaCruzarCheque)) '55
            m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            'cruzamos el cheque linea 2
            m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX10")
            m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY10")
            strPrintData.Clear()
            strPrintData.Append(ESC & New String("-", largoLineaCruzarCheque)) '55
            m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            'cruzamos el cheque linea de prueba
            'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX10")
            'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY10") + 10
            'm_Printer.SlpLineChars = 60
            'Dim lineaTexto As String = "123456789012345678901234567890123456789012345678901234567890"
            'm_Printer.PrintNormal(PrinterStation.Slip, lineaTexto)

            m_Printer.PageModePrint(PageModePrintControl.Normal) 'Cambiamos de modo de impresión para que la impresora imprima todo el texto almacenado en el buffer con el metodo PageModePrint

        Catch pcex As PosControlException
            Dim mensaje As String = pcex.Message

            If mensaje.Contains("Out of slip form") = True Then
                Try
                    m_Printer.ChangePrintSide(PrinterSide.Side1) 'Al llamar este método indicamos a la impresora que debe resetear la posición del cabezal de la impresora.
                Catch ex As Exception
                End Try

            End If

        End Try

        Return True
    End Function

    Public Function PrintFrontSideTest(ByVal fechaCheque As Date, ByVal montoCheque As Integer, ByVal nombreEmpresaPago As String, ByVal nombreCiudadCheque As String, ByVal montoEnPalabras As String, ByVal FilaFormato As DataRow,
                                       ByVal CodigoFormatoCheque As Integer) As Boolean
        Dim nowDate As DateTime = fechaCheque
        Dim dateFormat As DateTimeFormatInfo = New DateTimeFormatInfo
        Dim strPrintData As StringBuilder = New StringBuilder
        Dim lineaActual As Integer = 1
        Dim montoLinea1 As String = ""
        Dim montoLinea2 As String = ""
        Dim largoMaximoLinea1 As Integer = 60
        Dim largoMaximoLinea2 As Integer = 30
        Dim ESC As String = Chr(&H1B) 'ESC command
        Dim GS As String = Chr(&H1D)
        Dim FUENTE As String = Chr(&H99)
        Dim arrMonto As String() = Nothing
        Dim largoLineaCruzarCheque As Integer = 55

        Try
            m_Printer.ChangePrintSide(PrinterSide.Side1) 'Al llamar este método indicamos a la impresora que debe resetear la posición del cabezal de la impresora.
        Catch ex As PosControlException
            Me.mensaje = ex.Message & " " & ex.StackTrace
        End Try

        arrMonto = montoEnPalabras.Split(" ")

        For indice As Integer = 0 To arrMonto.Length - 1
            If arrMonto(indice).Trim <> "" Then

                If montoLinea1.Length + arrMonto(indice).Length < largoMaximoLinea1 AndAlso lineaActual = 1 Then
                    montoLinea1 &= arrMonto(indice).Trim & " "
                Else
                    montoLinea2 &= arrMonto(indice).Trim & " "
                    lineaActual = 2
                End If

            End If
        Next

        largoMaximoLinea1 = FilaFormato.Item("largoMaximoLinea1")
        largoMaximoLinea2 = FilaFormato.Item("largoMaximoLinea2")

        If montoLinea1.Length < largoMaximoLinea1 Then
            montoLinea1 &= New String("*", largoMaximoLinea1 - montoLinea1.Length)
        End If

        If montoLinea2.Length < largoMaximoLinea2 Then
            montoLinea2 &= New String("*", largoMaximoLinea2 - montoLinea2.Length)
        End If

        Try
            m_Printer.PageModeStation = PrinterStation.Slip
            m_Printer.PageModePrint(PageModePrintControl.PageMode)
            m_Printer.PageModePrintDirection = PageModePrintDirection.BottomToTop '90 grados a la izquierda
            m_Printer.PageModePrintArea = New Rectangle(0, 0, m_Printer.PageModeArea.X, m_Printer.PageModeArea.Y)

            If CodigoFormatoCheque = 2 Then ' cheque con casilleros
                'monto en números
                m_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX1")
                m_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY1")
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" + Format(montoCheque, New String("*", 18) & "#,##0") & ".-")
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                ''nombre de plaza del cheque
                'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX2")
                'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY2")
                'strPrintData.Clear()
                'strPrintData.Append(ESC & "|rA" + nombreCiudadCheque)
                'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                ''número de dia
                'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX3")
                'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY3")
                'strPrintData.Clear()
                'strPrintData.Append(ESC & "|rA" + nowDate.ToString("dd"))
                'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                ''número de mes
                'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX4")
                'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY4")
                'strPrintData.Clear()
                'strPrintData.Append(ESC & "|rA" & nowDate.ToString("MM"))
                'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                ''número de año
                'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX5")
                'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY5")
                'strPrintData.Clear()
                'strPrintData.Append(ESC & "|rA" & nowDate.ToString("yy"))
                'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                ''destino pago
                'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX6")
                'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY6")
                'strPrintData.Clear()
                'strPrintData.Append(ESC & "|rA" & nombreEmpresaPago)
                'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                ''monto en palabras linea 1
                'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX7")
                'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY7")
                'strPrintData.Clear()
                'strPrintData.Append(ESC & "|rA" & montoLinea1)
                'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

                ''monto en palabras linea 2
                'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX8")
                'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY8")
                'strPrintData.Clear()
                'strPrintData.Append(ESC & "|rA" & montoLinea2)
                'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            End If

            'Cambiamos la orientación de la impresión para cruzar el cheque
            m_Printer.PageModePrintDirection = PageModePrintDirection.LeftToRight
            m_Printer.PageModePrintArea = New Rectangle(0, 0, m_Printer.PageModeArea.X, m_Printer.PageModeArea.Y)

            ''cruzamos el cheque linea 1
            'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX9")
            'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY9")
            'strPrintData.Clear()
            'strPrintData.Append(ESC & New String("-", largoLineaCruzarCheque)) '55
            'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            ''cruzamos el cheque linea 2
            'm_Printer.PageModeHorizontalPosition = FilaFormato.Item("posicionFrontalX10")
            'm_Printer.PageModeVerticalPosition = FilaFormato.Item("posicionFrontalY10")
            'strPrintData.Clear()
            'strPrintData.Append(ESC & New String("-", largoLineaCruzarCheque)) '55
            'm_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            m_Printer.PageModePrint(PageModePrintControl.Normal) 'Cambiamos de modo para que la impresora imprima todo el texto almacenado en el buffer con el metodo PrintNormal

        Catch ex As PosControlException
            Dim mensaje As String = ex.Message
        End Try

        Return True

    End Function

    Public Function PrintBackSide(ByVal Fila As DataRow) As Boolean
        Dim strPrintData As StringBuilder = New StringBuilder
        Dim ESC As Char = Chr(&H1B) 'ESC command
        Dim LF As Char = Chr(&HA)
        Dim CR As Char = Chr(&HD)
        Dim FF As Char = Chr(&HC)
        Dim PF As Char = Chr(&H4A)
        Dim GS As Char = Chr(&H1D)
        Dim EXCLAMATION As Char = Chr(&H21)
        Dim Simbolo As Char = Chr(&H27)
        Dim arrCode As Char() = New Char() {"|", "r", "A"}
        Dim rutTitular As String
        Dim telefonoTitular As String
        Dim numeroCuentaDeposito As String
        Dim nombreBancoDeposito As String
        Dim motivoDeposito As String

        Try
            rutTitular = Fila.Item("rut_titular").ToString().Trim()
            telefonoTitular = Fila.Item("telefono_titular").ToString().Trim()
            numeroCuentaDeposito = Fila.Item("numero_cuenta").ToString().Trim()
            nombreBancoDeposito = Fila.Item("nombre_banco").ToString().Trim()
            motivoDeposito = Fila.Item("motivo").ToString().Trim()

        Catch ex As Exception
            Me.mensaje = ex.Message & " " & ex.StackTrace
        End Try

        Try
            m_Printer.ChangePrintSide(PrinterSide.Side2) 'En este modo solo se puede utilizar una fuente y se puede imprimir un máximo de 40 caracteres y 8 lineas.
        Catch ex As PosControlException
            Me.mensaje = ex.Message & " " & ex.StackTrace
        End Try

        Try
            'Avanzamos una o mas lineas
            For indice As Integer = 1 To 10
                strPrintData.Clear()
                strPrintData.Append(ESC & "|rA" & vbCrLf)
                m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())
            Next

            'rut del Titular
            strPrintData.Clear()
            strPrintData.Append(ESC & "|rA" & New String(" ", 15) & "C.I.      " & rutTitular & vbCrLf)
            m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            'teléfono del Titular
            strPrintData.Clear()
            strPrintData.Append(ESC & "|rA" & New String(" ", 15) & "TELEFONO  " & telefonoTitular & vbCrLf)
            m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            'número de Cuenta depósito
            strPrintData.Clear()
            strPrintData.Append(ESC & "|rA" & New String(" ", 15) & "CTA. CTE. " & numeroCuentaDeposito & vbCrLf)
            m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            'nombre de Banco Depósito
            strPrintData.Clear()
            strPrintData.Append(ESC & "|rA" & New String(" ", 15) & "BANCO     " & nombreBancoDeposito & vbCrLf)
            m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

            'motivo de depósito
            strPrintData.Clear()
            strPrintData.Append(ESC & "|rA" & New String(" ", 15) & "MOTIVO    " & motivoDeposito & vbCrLf)
            m_Printer.PrintNormal(PrinterStation.Slip, strPrintData.ToString())

        Catch ex As PosControlException
            Me.mensaje = ex.Message & " " & ex.StackTrace
        End Try
        Return True
    End Function

    Public Property mensaje() As String
        Get
            Return m_strMessage
        End Get
        Set(value As String)
            m_strMessage = value
        End Set
    End Property
End Class

