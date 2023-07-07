Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.VisualBasic.FileIO

Public Class Form_Plot


    Private Database(100) As Decimal
    Private Database_Count As Integer = 0
    Private Database_Length As Integer = My.Settings.NumericUpDown_PlotPoints_Value
    Private Range As Integer = 0
    Private Current_Range As Integer = 0
    Private MAX_Value As Decimal = 0
    Public ReadPlot As Boolean = True


    'FORM
    Private Sub Form_Plot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AcceptButton = Button_Hold
        Icon = My.Resources.Plotter
        Change_Database_Length()
        Auto_Range()
        Set_RadioButtons()
        Change_Zoom_Level()

    End Sub
    Private Sub Form_Plot_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Form1.Polt_Open = False

    End Sub
    'PLOT (Add value to Array)
    Private Sub Timer_ReadValue_Tick(sender As Object, e As EventArgs) Handles Timer_ReadValue.Tick

        If RadioButton_Mode1.Checked Then
            'LIVE MODE
            If Database_Count > Database_Length Then
                Database_Count = Database_Length - 1
            End If

            'Read value
            If Form1.OwonB41T_Data IsNot Nothing Then

                Database(Database_Count) = True_UnitValue(Form1.OwonB41T_Data(1), Form1.Dec_Value)

                If Database_Count < Database.Length - 2 Then
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisX.ScaleView.Position = Database_Count - NumericUpDown_ZoomLevel.Value
                End If


                If CheckBox_AutoRange.Checked Then
                    'Find MAX
                    If Database(Database_Count) > MAX_Value Then MAX_Value = Database(Database_Count)
                    Auto_Range()
                End If

                Database_Count += 1

                If Database_Count >= Database.Length Then

                    Database_Count = Database.Length - 1

                    For index = 0 To Database.Length - 2

                        Database(index) = Database(index + 1)

                    Next
                End If

                Plot_Values()
            End If
        End If

    End Sub
    Private Sub Plot_Values()

        Chart_Plot.Series("Series_Plot").Points.Clear()
        For index = 0 To Database_Count - 1

            Chart_Plot.Series("Series_Plot").Points.AddXY(index, Database(index))

        Next

    End Sub
    'ABSALUTE VALUE
    Private Function True_UnitValue(dataType As String, recivedValue As Single)

        'Scaling for plot.

        '1 F = 1000000 µF
        '1 F = 1000000000 nF

        'OwonB41T_Data(1)
        'm V DC
        'm V AC
        '  V DC
        '  V AC
        '  Ohm
        'k Ohm
        'M Ohm
        '  Volts Diode
        '  Ohms Continuity
        'n Farad
        'u Farad
        '  Hz
        '  Duty
        '  hFE
        '  TempC
        '  TempF
        'u A DC
        'u A AC
        'm A DC
        'm A AC
        '  A DC
        '  A AC

        If dataType = "m V DC" Or dataType = "m V AC" Then recivedValue *= 1000
        If dataType = "  V DC" Or dataType = "  V AC" Then recivedValue *= 1
        If dataType = "  Ohm" Then recivedValue *= 1
        If dataType = "k Ohm" Then recivedValue *= 1000
        If dataType = "M Ohm" Then recivedValue *= 1000000
        If dataType = "  Volts Diode" Then recivedValue *= 1
        If dataType = "  Ohms Continuity" Then recivedValue *= 1
        If dataType = "n Farad" Then recivedValue *= 1000000
        If dataType = "u Farad" Then recivedValue *= 1000
        If dataType = "  Hz" Then recivedValue *= 1000
        If dataType = "  Duty" Then recivedValue *= 1000
        If dataType = "  hFE" Then recivedValue *= 1000
        If dataType = "  TempC" Or dataType = "  TempF" Then recivedValue *= 1000
        If dataType = "u A DC" Or dataType = "u A AC" Then recivedValue *= 1000
        If dataType = "m A DC" Or dataType = "m A AC" Then recivedValue *= 1000
        If dataType = "  A DC" Or dataType = "  A AC" Then recivedValue *= 1000

        Return recivedValue

    End Function
    'RANGE
    Private Sub Auto_Range()


        If MAX_Value <= 0.6 Then
            Range = 0
        ElseIf MAX_Value > 0.6 And MAX_Value <= 6 Then
            Range = 1
        ElseIf MAX_Value > 6 And MAX_Value <= 60 Then
            Range = 2
        ElseIf MAX_Value > 60 And MAX_Value <= 600 Then
            Range = 3
        ElseIf MAX_Value > 600 And MAX_Value <= 6000 Then
            Range = 4
        ElseIf MAX_Value > 6000 And MAX_Value <= 60000 Then
            Range = 5
        ElseIf MAX_Value > 60000 And MAX_Value <= 600000 Then
            Range = 6
        ElseIf MAX_Value > 60000 And MAX_Value <= 600000 Then
            Range = 7
        End If

        If Range <> Current_Range Then
            Current_Range = Range
            Set_Range()
        End If

    End Sub
    Private Sub Set_Range()

        Select Case Current_Range

            Case 0 '0.6
                Set_Range_Values(0.6)
            Case 1 '6
                Set_Range_Values(6)
            Case 2 '60
                Set_Range_Values(60)
            Case 3 '600
                Set_Range_Values(600)
            Case 4 '6000
                Set_Range_Values(6000)
            Case 5 '60000
                Set_Range_Values(60000)
            Case 6 '600000
                Set_Range_Values(600000)
            Case 7 '6000000
                Set_Range_Values(6000000)
            Case Else
                Set_Range_Values(6)
        End Select

    End Sub
    Private Sub Set_Range_Values(baseNumber As Decimal)

        Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = baseNumber / 12
        If RadioButton_Range1.Checked Then

            Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = baseNumber
            Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

        ElseIf RadioButton_Range2.Checked Then

            Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
            Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = baseNumber * -1

        ElseIf RadioButton_Range3.Checked Then

            Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = baseNumber
            Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = baseNumber * -1
            Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = baseNumber / 6

        End If

    End Sub
    Private Sub ComboBox_Range_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Range.SelectedIndexChanged
        Current_Range = ComboBox_Range.SelectedIndex
        Set_Range()
    End Sub
    Private Sub RadioButton_Range1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Range1.CheckedChanged
        If RadioButton_Range1.Focused Then
            If RadioButton_Range1.Checked Then
                Save_RadioButtons(1)
                Set_Range()
            End If
        End If
    End Sub
    Private Sub RadioButton_Range2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Range2.CheckedChanged
        If RadioButton_Range2.Focused Then
            If RadioButton_Range2.Checked Then
                Save_RadioButtons(2)
                Set_Range()
            End If
        End If
    End Sub
    Private Sub RadioButton_Range3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Range3.CheckedChanged
        If RadioButton_Range3.Focused Then
            If RadioButton_Range3.Checked Then
                Save_RadioButtons(3)
                Set_Range()
            End If
        End If
    End Sub
    Private Sub CheckBox_AutoRange_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_AutoRange.CheckedChanged
        If CheckBox_AutoRange.Focused Then
            MAX_Value = 0
            If CheckBox_AutoRange.Checked Then
                ComboBox_Range.Enabled = False
            Else
                ComboBox_Range.Enabled = True
            End If
            My.Settings.Save()

        End If
    End Sub
    'DATABASE
    Private Sub Change_Database_Length()

        Database_Length = Database.Length

        If Database_Length > NumericUpDown_PlotPoints.Value And Database_Count > NumericUpDown_PlotPoints.Value Then

            For index = 0 To NumericUpDown_PlotPoints.Value - 2

                Database(index) = Database(index + (Database_Count - NumericUpDown_PlotPoints.Value))
            Next
        End If

        Database_Length = NumericUpDown_PlotPoints.Value
        ReDim Preserve Database(NumericUpDown_PlotPoints.Value)

    End Sub
    Private Sub NumericUpDown_PlotPoints_TextChanged(sender As Object, e As EventArgs) Handles NumericUpDown_PlotPoints.TextChanged

        If NumericUpDown_PlotPoints.Text <> "" And
                NumericUpDown_PlotPoints.Text >= NumericUpDown_PlotPoints.Minimum And
                NumericUpDown_PlotPoints.Text <= NumericUpDown_PlotPoints.Maximum Then

            NumericUpDown_PlotPoints.Value = NumericUpDown_PlotPoints.Text
        End If

    End Sub
    Private Sub NumericUpDown_PlotPoints_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_PlotPoints.ValueChanged

        If NumericUpDown_PlotPoints.Focused Then
            Change_Database_Length()
        End If
    End Sub
    Private Sub Change_Read_Interval()

        Timer_ReadValue.Interval = NumericUpDown_ReadInterval.Value * 1000

    End Sub
    Private Sub NumericUpDown_ReadInterval_TextChanged(sender As Object, e As EventArgs) Handles NumericUpDown_ReadInterval.TextChanged
        If NumericUpDown_ReadInterval.Text <> "" And
                NumericUpDown_ReadInterval.Text >= NumericUpDown_ReadInterval.Minimum And
                NumericUpDown_ReadInterval.Text <= NumericUpDown_ReadInterval.Maximum Then

            NumericUpDown_ReadInterval.Value = NumericUpDown_ReadInterval.Text
        End If
    End Sub
    Private Sub NumericUpDown_ReadInterval_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_ReadInterval.ValueChanged

        If NumericUpDown_ReadInterval.Focused Then
            Change_Read_Interval()
        End If

    End Sub
    Private Sub Change_Zoom_Level()

        If NumericUpDown_ZoomLevel.Value >= 100 And NumericUpDown_ZoomLevel.Value < Database.Length Then

            Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisX.ScaleView.Size = NumericUpDown_ZoomLevel.Value

        End If

    End Sub
    Private Sub NumericUpDown_ZoomLevel_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_ZoomLevel.TextChanged

        If NumericUpDown_ZoomLevel.Text <> "" And
            NumericUpDown_ZoomLevel.Text >= NumericUpDown_ZoomLevel.Minimum And
            NumericUpDown_ZoomLevel.Text <= NumericUpDown_PlotPoints.Value Then

            NumericUpDown_ZoomLevel.Value = NumericUpDown_ZoomLevel.Text
        End If

    End Sub
    Private Sub NumericUpDown_ZoomLevel_TextChanged(sender As Object, e As EventArgs) Handles NumericUpDown_ZoomLevel.ValueChanged

        If NumericUpDown_ZoomLevel.Focused Then
            Change_Zoom_Level()
        End If

    End Sub
    'File
    Private Sub Button_SaveToFile_Click(sender As Object, e As EventArgs) Handles Button_SaveToFile.Click

        SaveFileDialog1.Filter = "Comma-Separated Values|*.CSV|Text|*.txt|All|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.Title = "Save to File"
        SaveFileDialog1.ShowDialog()

        If SaveFileDialog1.FileName <> "" And DialogResult.OK Then

            Dim file As StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(SaveFileDialog1.FileName, CheckBox_AppendFile.Checked)

            Dim _count As Integer = 0

            For Each _value In Database

                file.Write(_value)
                _count += 1
                If _count >= Database.Length Then Exit For
                file.Write(",")

            Next
            file.Write(vbCrLf)
            file.Close()

        End If

    End Sub
    'RADIO BUTTONS
    Private Sub Set_RadioButtons()

        Select Case My.Settings.RadioButton_Range_Checked
            Case 1
                RadioButton_Range1.Checked = True
            Case 2
                RadioButton_Range2.Checked = True
            Case 3
                RadioButton_Range3.Checked = True
            Case Else
                RadioButton_Range1.Checked = True
        End Select

    End Sub
    Private Sub Save_RadioButtons(radioButton As Integer)

        My.Settings.RadioButton_Range_Checked = radioButton

    End Sub
    'BUTTONS
    Private Sub Button_Hold_Click(sender As Object, e As EventArgs) Handles Button_Hold.Click
        If Button_Hold.Focused Then
            Form1.Hold()
            Hold()
        End If
    End Sub
    Public Sub Hold()

        ReadPlot = Not ReadPlot

        If ReadPlot Then
            Timer_ReadValue.Start()
        Else
            Timer_ReadValue.Stop()
        End If

    End Sub

    Private Sub Button_ZeroCursor_Click(sender As Object, e As EventArgs) Handles Button_ZeroCursor.Click

        Chart_Plot.ChartAreas.Item("ChartArea_Plot").CursorY.Position = 0

    End Sub

    Private Sub RadioButton_Mode1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Mode1.CheckedChanged
        Change_Mode()
    End Sub
    Private Sub Change_Mode()
        If RadioButton_Mode1.Checked Then
            Form1.OffLineMode = False
            GroupBox_OffLine.Enabled = False
        Else
            Form1.OffLineMode = True
            GroupBox_OffLine.Enabled = True
        End If

    End Sub
    'DOWNLOAD
    Private Sub Button_SaveOffLineRecording_Click(sender As Object, e As EventArgs) Handles Button_SaveOffLineRecording.Click
        DownloadData()
    End Sub
    Private Sub DownloadData()

        SaveFileDialog1.Filter = "Comma-Separated Values|*.CSV|Text|*.txt|All|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.Title = "Save to File"
        SaveFileDialog1.ShowDialog()

        If SaveFileDialog1.FileName <> "" And DialogResult.OK Then

            Form1.Off_Line_Data_Count = 0

            Form1.SendCommand("o")

        End If

    End Sub
    Public Sub Save_Downloaded_Data()

        Dim file As StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(SaveFileDialog1.FileName, CheckBox_AppendFile.Checked)

        Dim _count As Integer = 0

        For Each _value In Form1.Off_Line_Data

            file.Write(_value(2))
            _count += 1
            If _count >= Database.Length - 1 Then Exit For
            file.Write(",")

        Next
        file.Write(vbCrLf)
        file.Close()

    End Sub
    'SET METER RECORDING
    Private Sub Button_StartOffLineRecording_Click(sender As Object, e As EventArgs) Handles Button_StartOffLineRecording.Click
        Set_Meter_Recording()
    End Sub
    Private Sub Set_Meter_Recording()

        If Form1.Shell_Open = True Then

            Form1.SendCommand("p " + NumericUpDown_RecordInterval.Value.ToString() + " " + NumericUpDown_RecordNumberOfReading.Value.ToString())
            Form1.Stop_Reading()
        Else

            MessageBox.Show("Warning: The Digital Multimeter is not connected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    'LOAD CSV FILE
    Private Sub Button_LoadCSV_Click(sender As Object, e As EventArgs) Handles Button_LoadCSV.Click

        Dim data As Decimal()()
        Database_Length = 0

        OpenFileDialog1.Filter = "Tim's Comma-Separated Values|*.CSV|Text|*.txt|All|*.*"
        OpenFileDialog1.Title = "Select a CSV File"
        OpenFileDialog1.FilterIndex = 1

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog1.FileName
            Dim lines As String() = File.ReadAllLines(filePath)
            data = New Decimal(lines.Length - 1)() {}
            For i As Integer = 0 To lines.Length - 1
                Dim line As String = lines(i).TrimEnd(","c)
                Dim fields As String() = line.Split(","c)
                data(i) = Array.ConvertAll(fields, Function(str) Decimal.Parse(str))
            Next
            ' data now contains an array of Decimal arrays, where each element of the outer array represents a line from the file


            Database = data(0)
            Database_Length = Database.Length
            Database_Count = Database.Length
            NumericUpDown_PlotPoints.Value = Database_Length


            Plot_Values()
        End If

    End Sub





    '
End Class