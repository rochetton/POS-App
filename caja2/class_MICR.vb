Imports Microsoft.PointOfService
Imports System.Globalization
Imports System.Reflection
Imports System.Text

Public Class class_MICR

    'Micr object
    Private m_Micr As Micr = Nothing

    'Now Step
    Private m_strStep As String = "MicrSample_Step2"

    Private m_strRawData As String = ""

    Public Function Initialize() As Boolean
        '<<<step1>>>--Start
        'Use a Logical Device Name which has been set on the SetupPOS.
        Dim strMicrLogicalName As String
        Dim deviceInfo As DeviceInfo
        Dim posExplorer As PosExplorer

        strMicrLogicalName = "Micr"

        'Create PosExplorer
        posExplorer = New PosExplorer

        Try

            deviceInfo = posExplorer.GetDevice(DeviceType.Micr, strMicrLogicalName)
            m_Micr = posExplorer.CreateInstance(deviceInfo)

        Catch ex As Exception
            Return False
        End Try

        Try

            'Register DataEventHandler.
            AddDataEvent(m_Micr)

            'Open the device
            m_Micr.Open()

            'Get the exclusive control right for the opened device.
            'Then the device is disable from other application.
            m_Micr.Claim(1000)

            'Enable the device.
            m_Micr.DeviceEnabled = True

            'In order to enable it to use the DataEvent.
            m_Micr.DataEventEnabled = True

        Catch ex As PosControlException

            Return False

        End Try
        '<<<step1>>>--End

        Return True
    End Function

    Public Function BeginInsertion(ByVal timeout As Integer) As Boolean

        Try
            Try

                'Insertion preparations of a check are made.
                m_Micr.BeginInsertion(1000)

            Catch ex As PosControlException
                MessageBox.Show(ex.Message, "Inserción de Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                If ex.ErrorCode = ErrorCode.Timeout Then

                    m_Micr.EndInsertion()
                    m_Micr.BeginRemoval(10000)

                    Return False
                ElseIf ex.ErrorCode = ErrorCode.Illegal And ex.ErrorCodeExtended = jp.co.epson.uposcommon.EpsonUPOSConst.UPOS_EX_INVALID_MODE Then

                    Return False

                End If

            End Try

            Try

                'Insertion operation of a check is started.
                m_Micr.EndInsertion()

            Catch ex As PosControlException
                MessageBox.Show(ex.Message, "Inserción de Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                Return False
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Inserción de Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Return False
        End Try

        If String.IsNullOrEmpty(Me.RawData) = True AndAlso String.IsNullOrEmpty(m_Micr.RawData) = False Then 'Check if DataEvent not raised
            m_strRawData = m_Micr.RawData
        End If

        Return True
    End Function

    Public Function Remove(Optional ByVal retryMessage As Boolean = False) As Boolean
        '<<<step2>>>--Start

        Try

            m_Micr.BeginRemoval(3000)

        Catch ex As PosControlException

            If ex.ErrorCode = ErrorCode.Timeout Then

                If retryMessage = True Then
                    MessageBox.Show("Remueva el cheque de la impresora y seleccione aceptar." & vbCrLf & "Luego Reintente", "Validación Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("Remueva el cheque de la impresora y seleccione aceptar", "Validación Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                End If


            End If

        End Try

        '<<<step2>>>--End

        Return True
    End Function

    Protected Sub AddDataEvent(ByVal eventSource As Object)

        '<<<step1>>>--Start
        Dim dataEvent As EventInfo = Nothing

        dataEvent = eventSource.GetType().GetEvent("DataEvent")

        If Not (dataEvent Is Nothing) Then
            dataEvent.AddEventHandler(eventSource, New DataEventHandler(AddressOf OnDataEvent))
        End If
        '<<<step1>>>--End
    End Sub

    Protected Sub OnDataEvent(ByVal source As Object, ByVal e As DataEventArgs)

        'If InvokeRequired Then
        '    'Ensure calls to Windows Form Controls are from this application's thread
        'Invoke(New DataEventHandler(AddressOf OnDataEvent), New Object() {source, e})
        '    Return
        'End If

        ''<<<step1>>>--Start
        m_strRawData = m_Micr.RawData

        m_Micr.DataEventEnabled = True
        '<<<step1>>>--End

    End Sub

    Protected Sub RemoveDataEvent(ByVal eventSource As Object)

        '<<<step1>>>--Start
        Dim dataEvent As EventInfo = Nothing

        dataEvent = eventSource.GetType().GetEvent("DataEvent")

        If Not (dataEvent Is Nothing) Then
            dataEvent.RemoveEventHandler(eventSource _
            , New DataEventHandler(AddressOf OnDataEvent))

        End If
        '<<<step1>>>--End
    End Sub

    Public ReadOnly Property RawData As String
        Get
            Return m_strRawData
        End Get
    End Property

    Public Function Close() As Boolean
        '<<<step1>>>--Start
        If m_Micr Is Nothing Then

            Return False

        End If

        Try

            'Remove ErrorEventHandler.
            RemoveDataEvent(m_Micr)

            'Cancel the device
            m_Micr.DeviceEnabled = False

            'Release the device exclusive control right.
            m_Micr.Release()

        Catch ex As Exception

        Finally
            'Finish using the device.
            m_Micr.Close()

        End Try
        '<<<step1>>>--End

        Return True
    End Function


End Class
