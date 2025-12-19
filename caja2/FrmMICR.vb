Imports Microsoft.PointOfService
Imports System.Reflection

Public Class FrmMICR
    Inherits System.Windows.Forms.Form

    'Micr object
    Private m_Micr As Micr = Nothing

    'Now Step
    Private m_strStep As String = "MicrSample_Step2"

    ''' <summary>
    ''' The code for inserting a check are described.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnInsert_Click(ByVal sender As System.Object _
    , ByVal e As System.EventArgs) Handles btnInsert.Click

        '<<<step2>>>--Start
        Dim dialogResult As DialogResult

        Do

            Try

                'Insertion preparations of a check are made.
                m_Micr.BeginInsertion(1000)
                Exit Do

            Catch ex As PosControlException

                If ex.ErrorCode = ErrorCode.Timeout Then

                    dialogResult = MessageBox.Show("Please insert a check." _
                    , m_strStep, MessageBoxButtons.YesNo)

                    If dialogResult = DialogResult.No Then

                        Try

                            m_Micr.EndInsertion()
                            m_Micr.BeginRemoval(10000)

                        Catch ex2 As PosControlException

                        End Try

                        Exit Sub

                    End If

                ElseIf ex.ErrorCode = ErrorCode.Illegal And ex.ErrorCodeExtended = jp.co.epson.uposcommon.EpsonUPOSConst.UPOS_EX_INVALID_MODE Then

                    dialogResult = MessageBox.Show("Insert error.", "Insert error.", MessageBoxButtons.OK)

                    Exit Sub

                Else

                    Exit Sub

                End If

            End Try
        Loop

        Try

            'Insertion operation of a check is started.
            m_Micr.EndInsertion()


        Catch ex As PosControlException

        End Try
        '<<<step2>>>--End

    End Sub
    ''' <summary>
    ''' The code for removing a check are described.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRemove_Click(ByVal sender As System.Object _
    , ByVal e As System.EventArgs) Handles btnRemove.Click

        '<<<step2>>>--Start
        Try

            m_Micr.BeginRemoval(3000)

        Catch ex As PosControlException

            If ex.ErrorCode = ErrorCode.Timeout Then

                MessageBox.Show("Please remove a check.", m_strStep)

            End If

        End Try
        '<<<step2>>>--End

    End Sub
    ''' <summary>
    ''' When the method "ChangeButtonStatus" was called,
    ''' all buttons other than a button "Close" become invalid.
    ''' </summary>
    Private Sub ChangeButtonStatus()

        btnInsert.Enabled = False
        btnRemove.Enabled = False
        txtRawData.Enabled = False

    End Sub
    ''' <summary>
    ''' Form close.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExit_Click(ByVal sender As System.Object _
    , ByVal e As System.EventArgs) Handles btnExit.Click

        Close()

    End Sub
    ''' <summary>
    ''' The processing code required in order to enable to use of service is written here.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FrameStep2_Load(ByVal sender As System.Object _
    , ByVal e As System.EventArgs) Handles MyBase.Load

        '<<<step1>>>--Start
        'Use a Logical Device Name which has been set on the SetupPOS.
        Dim strLogicalName As String
        Dim deviceInfo As DeviceInfo
        Dim posExplorer As PosExplorer

        strLogicalName = "Micr"

        'Create PosExplorer
        posExplorer = New PosExplorer

        Try

            deviceInfo = posExplorer.GetDevice(DeviceType.Micr, strLogicalName)
            m_Micr = posExplorer.CreateInstance(deviceInfo)

        Catch ex As Exception
            ChangeButtonStatus()
            Return
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

            ChangeButtonStatus()

        End Try
        '<<<step1>>>--End

    End Sub
    ''' <summary>
    ''' When the method "closing" is called,
    ''' the following code is run.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FrameStep2_Closing(ByVal sender As Object _
    , ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        '<<<step1>>>--Start
        If m_Micr Is Nothing Then

            Return

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
    End Sub
    ''' <summary>
    ''' Add DataEventEventHandler.
    ''' </summary>
    ''' <param name="eventSource"></param>
    Protected Sub AddDataEvent(ByVal eventSource As Object)

        '<<<step1>>>--Start
        Dim dataEvent As EventInfo = Nothing

        dataEvent = eventSource.GetType().GetEvent("DataEvent")

        If Not (dataEvent Is Nothing) Then
            dataEvent.AddEventHandler(eventSource _
            , New DataEventHandler(AddressOf OnDataEvent))

        End If
        '<<<step1>>>--End
    End Sub
    ''' <summary>
    ''' Remove DataEventHandler.
    ''' </summary>
    ''' <param name="eventSource"></param>
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
    ''' <summary>
    ''' Data Event
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    Protected Sub OnDataEvent(ByVal source As Object, ByVal e As DataEventArgs)

        If InvokeRequired Then
            'Ensure calls to Windows Form Controls are from this application's thread
            Invoke(New DataEventHandler(AddressOf OnDataEvent), New Object() {source, e})
            Return
        End If

        '<<<step1>>>--Start
        txtRawData.Text = m_Micr.RawData

        m_Micr.DataEventEnabled = True
        '<<<step1>>>--End

    End Sub

End Class