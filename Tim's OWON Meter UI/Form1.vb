Imports System.ComponentModel
Imports System.IO

'A user Inteface to use the Output from OwonB41T.cpp by: Jeffrey Cash
'
'This is By: Tim Jackson.1960.
'Use as you like.
'
'Some things I still need to do: Some bottons.


#Region "Notes"
'My Standard Notes
'
'AcceptButton = SendCommand_Button
'to update the UP/Down text make value = text
'Threading.Thread.Sleep(50)
'Invoke(New Action(Of String)(AddressOf sub), TextToSend)
'Invoke(New EventHandler(AddressOf sub))

'ReceivedDataRichTextBox.Invoke(Sub()
'                                   ReceivedDataRichTextBox.AppendText("File Loaded" + vbCrLf)
'                                   End Sub)

'BitConverter.GetBytes(several bit value)(0)
'BitConverter.GetBytes(several bit value)(1)....
'If SerialPort1.IsOpen Then
'    Try
'
'
'    Catch ex As Exception
'        Debug.Print("error ")
'    End Try
'End If
'
#End Region

Public Class Form1

    Private OwonB41T_Shell_Process As Process = Nothing
    Private OwonB41T_StreamWriter As StreamWriter = Nothing
    Private OwonB41T_Path As String = "E:\tim\Documents\Visual Studio Projects\_Repositorys\OwonB41T\x64\Release\OwonB41T.exe" ' This path can be entered in the Application. And will be remembered.
    Private OwonB41T_Output As String = ""
    Private Button_Connected As Boolean = False
    Dim OwonB41T_Data() As String

    'FORM
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AcceptButton = Button_Send
        Set_UI_Width()
        Clear_Screen()


    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        OwonB41T_Shell_Process?.Kill()

    End Sub
    Private Sub Clear_Screen()

        Label_ACDC.Text = ""
        Label_Auto.Text = ""
        Label_Max.Text = ""
        Label_Min.Text = ""
        Label_Hfe.Text = ""
        Label_Temp.Text = ""
        Label_Duty.Text = ""
        Label_RPM.Text = ""
        Label_Ohm.Text = ""
        Label_Hz.Text = ""
        Label_Volts.Text = ""
        Label_Amps.Text = ""
        RichTextBox_Negative.Text = ""
        RichTextBox_MeterValue.Text = ""

    End Sub
    'Process
    Private Sub StartCmdProcess(synchObj As Control)

        Dim OwonB41T_Start_Info = New ProcessStartInfo() With {
            .FileName = OwonB41T_Path,
            .CreateNoWindow = True,
            .RedirectStandardError = True,
            .RedirectStandardInput = True,
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .WorkingDirectory = Application.StartupPath
        }

        OwonB41T_Shell_Process = New Process() With {
            .EnableRaisingEvents = True,
            .StartInfo = OwonB41T_Start_Info,
            .SynchronizingObject = synchObj
        }

        OwonB41T_Shell_Process.Start()
        OwonB41T_Shell_Process.BeginErrorReadLine()
        OwonB41T_Shell_Process.BeginOutputReadLine()
        OwonB41T_StreamWriter = OwonB41T_Shell_Process.StandardInput

        AddHandler OwonB41T_Shell_Process.OutputDataReceived,
            Sub(s, evt)
                If evt.Data IsNot Nothing Then
                    OwonB41T_Output = evt.Data + Environment.NewLine
                    RichTextBox_ShellOutput.AppendText(evt.Data + Environment.NewLine)
                    RichTextBox_ShellOutput.ScrollToCaret()
                    Invoke(New EventHandler(AddressOf Update_Display))
                End If
            End Sub
        AddHandler OwonB41T_Shell_Process.ErrorDataReceived,
            Sub(s, evt)
                If evt.Data IsNot Nothing Then
                    RichTextBox_ErrorStream.AppendText(evt.Data + Environment.NewLine)
                    RichTextBox_ErrorStream.ScrollToCaret()
                End If
            End Sub

        AddHandler OwonB41T_Shell_Process.Exited,
            Sub(s, evt)
                OwonB41T_StreamWriter?.Dispose()
                OwonB41T_Shell_Process?.Dispose()
            End Sub
    End Sub
    'Buttons
    Private Sub Button_Connect_Click(sender As Object, e As EventArgs) Handles Button_Connect.Click

        Button_Connected = Not Button_Connected
        If Button_Connected Then

            StartCmdProcess(Me)
            Button_Connect.Enabled = True
            Button_Connect.BackColor = Color.Red
            Button_Connect.Text = "Disconect"
            Button_Connect.FlatAppearance.MouseOverBackColor = Color.Orange

        Else

            OwonB41T_Shell_Process?.Kill()
            Button_Connect.Enabled = True
            Button_Connect.BackColor = Color.Green
            Button_Connect.Text = "Connect"
            Button_Connect.FlatAppearance.MouseOverBackColor = Color.Lime

        End If


    End Sub
    Private Sub Button_Send_Click(sender As Object, e As EventArgs) Handles Button_Send.Click

        If OwonB41T_StreamWriter Is Nothing Then
            RichTextBox_ErrorStream.AppendText("Shell not Running or not Connected." + Environment.NewLine)
            Return
        End If

        If OwonB41T_StreamWriter.BaseStream.CanWrite Then
            OwonB41T_StreamWriter.Write(RichTextBox_Input.Text + Environment.NewLine)
            OwonB41T_StreamWriter.WriteLine() ' To write to the Shell, just: OwonB41T_StreamWriter.WriteLine(RichTextBox_Input.Text); 
        End If
        RichTextBox_Input.Clear()

    End Sub
    Private Sub Button_Hold_Click(sender As Object, e As EventArgs) Handles Button_Hold.Click
        SendCommand("h")
    End Sub
    Private Sub Button_BackLight_Click(sender As Object, e As EventArgs) Handles Button_BackLight.Click
        SendCommand("H")
    End Sub
    Private Sub Button_Relative_Click(sender As Object, e As EventArgs) Handles Button_Relative.Click
        SendCommand("d")
    End Sub
    Private Sub Button_Select_Click(sender As Object, e As EventArgs) Handles Button_Select.Click
        SendCommand("s")
    End Sub
    Private Sub Button_Range_Click(sender As Object, e As EventArgs) Handles Button_Range.Click
        SendCommand("r")
    End Sub
    Private Sub Button_HzDuty_Click(sender As Object, e As EventArgs) Handles Button_HzDuty.Click
        SendCommand("z")
    End Sub
    Private Sub Button_MaxMin_Click(sender As Object, e As EventArgs) Handles Button_MaxMin.Click
        SendCommand("m")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'MIN MAX
        If OwonB41T_Data(2).Contains("MAX") Or OwonB41T_Data(2).Contains("MIN") Then
            SendCommand("M")
        End If
        'VOLTS
        If OwonB41T_Data(1).Contains("V") Then
            SendCommand("R")
        End If



    End Sub




    Private Sub SendCommand(command As String)

        If OwonB41T_StreamWriter Is Nothing Then
            RichTextBox_ErrorStream.AppendText("Shell not Running or not Connected." + Environment.NewLine)
            Return
        End If

        If OwonB41T_StreamWriter.BaseStream.CanWrite Then
            OwonB41T_StreamWriter.WriteLine(command)
        End If

    End Sub



    Private Sub Button_UI_Click(sender As Object, e As EventArgs) Handles Button_UI.Click

        My.Settings.UI_Width_Max = Not My.Settings.UI_Width_Max
        Set_UI_Width()

    End Sub
    Private Sub Set_UI_Width()

        If My.Settings.UI_Width_Max Then
            Width = MaximumSize.Width
        Else
            Width = MinimumSize.Width
        End If

    End Sub
    'Display
    Private Sub Update_Display()

        Dim _negative As Boolean = False
        OwonB41T_Data = OwonB41T_Output.Split(vbTab)

        'Format Value to four digits.
        If OwonB41T_Data(0).StartsWith("-") Then _negative = True

        If _negative Then
            RichTextBox_Negative.Text = "-"
        Else
            RichTextBox_Negative.Text = ""
        End If

        'VALUE need to check it is a number
        If OwonB41T_Data(0) <> "OL" Then
            RichTextBox_MeterValue.Text = Math.Abs(Convert.ToDecimal(OwonB41T_Data(0))).ToString()
        End If
        If OwonB41T_Data(0) = "OL" Then
            RichTextBox_MeterValue.Text = "OL"
        End If
        'ACDC
        If OwonB41T_Data(1).Contains("AC") Then
            Label_ACDC.Text = "AC"
        ElseIf OwonB41T_Data(1).Contains("DC") Then
            Label_ACDC.Text = "DC"
        Else
            Label_ACDC.Text = ""
        End If
        'VOLTS
        If OwonB41T_Data(1).Contains("m V") Then
            Label_Volts.Text = "mV"
        ElseIf OwonB41T_Data(1).Contains("V") Then
            Label_Volts.Text = "V"
        Else
            Label_Volts.Text = ""
        End If
        'AMPS
        If OwonB41T_Data(1).Contains("u A") Then
            Label_Amps.Text = "µA"
        ElseIf OwonB41T_Data(1).Contains("m A") Then
            Label_Amps.Text = "mA"
        ElseIf OwonB41T_Data(1).Contains("A ") Then
            Label_Amps.Text = "A"
        Else
            Label_Amps.Text = ""
        End If
        'TEMP
        If OwonB41T_Data(1).Contains("TempC") Then
            Label_Temp.Text = "°C"
        ElseIf OwonB41T_Data(1).Contains("TempF") Then
            Label_Temp.Text = "°F"
        Else
            Label_Temp.Text = ""
        End If
        'hFE
        If OwonB41T_Data(1).Contains("hFE") Then
            Label_Hfe.Text = "hFE"
        Else
            Label_Hfe.Text = ""
        End If
        'OHM
        If OwonB41T_Data(1).Contains("M Ohm") Then
            Label_Ohm.Text = "MΩ"
        ElseIf OwonB41T_Data(1).Contains("k Ohm") Then
            Label_Ohm.Text = "kΩ"
        ElseIf OwonB41T_Data(1).Contains("Ohm") Then
            Label_Ohm.Text = "Ω"
        Else
            Label_Ohm.Text = ""
        End If
        'hFE
        If OwonB41T_Data(1).Contains("Hz") Then
            Label_Hz.Text = "Hz"
        Else
            Label_Hz.Text = ""
        End If
        'AUTO
        If OwonB41T_Data(2).Contains("AUTO") Then
            Label_Auto.Text = "AUTO"
        Else
            Label_Auto.Text = ""
        End If
        'AUTO
        If OwonB41T_Data(1).Contains("Duty") Then
            Label_Duty.Text = "%"
        Else
            Label_Duty.Text = ""
        End If
        'MAX
        If OwonB41T_Data(2).Contains("MAX") Then
            Label_Max.Text = "MAX"
        Else
            Label_Max.Text = ""
        End If
        'MIN
        If OwonB41T_Data(2).Contains("MIN") Then
            Label_Min.Text = "MIN"
        Else
            Label_Min.Text = ""
        End If


        'Images
        'HOLD
        If OwonB41T_Data(2).Contains("HOLD") Then
            PictureBox_Hold.Visible = True
        Else
            PictureBox_Hold.Visible = False
        End If
        'RELATIVE
        If OwonB41T_Data(2).Contains("REL") Then
            PictureBox_Triangle.Visible = True
        Else
            PictureBox_Triangle.Visible = False
        End If
        'DIODE
        If OwonB41T_Data(1).Contains("Volts Diode") Then
            PictureBox_Diode.Visible = True
        Else
            PictureBox_Diode.Visible = False
        End If
        'CONTINUITY
        If OwonB41T_Data(1).Contains("Ohms Continuity") Then
            PictureBox_Speaker.Visible = True
        Else
            PictureBox_Speaker.Visible = False
        End If
        ''HIGH VOLTAGE
        'If OwonB41T_Data(1).Contains("") Then
        '    PictureBox_HighV.Visible = True
        'Else
        '    PictureBox_HighV.Visible = False
        'End If




        'Ω°µ
        'm V DC
        'u A DC
        'Volts Diode
        'Ohms Continuity


    End Sub

End Class