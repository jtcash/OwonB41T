Imports System.Reflection
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form_Plot


    Private Database(100) As Decimal
    Private Database_Count As Integer = 0
    Private Database_Length As Integer = My.Settings.NumericUpDown_PlotPoints_Value


    'FORM
    Private Sub Form_Plot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Icon = My.Resources.Plotter
        Database_Length = My.Settings.NumericUpDown_PlotPoints_Value

        Set_Range()

    End Sub
    Private Sub Form_Plot_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Form1.Polt_Open = False

    End Sub
    'PLOT
    Private Sub Timer_ReadValue_Tick(sender As Object, e As EventArgs) Handles Timer_ReadValue.Tick

        If Database_Count > Database_Length Then
            Database_Count = Database_Length - 1
        End If

        'Read value
        If Form1.OwonB41T_Data IsNot Nothing Then

            Database(Database_Count) = True_UnitValue(Form1.OwonB41T_Data(1), Form1.Dec_Value)

            Database_Count += 1

            If Database_Count >= Database.Length Then

                Database_Count = Database.Length - 1

                For index = 0 To Database.Length - 2

                    Database(index) = Database(index + 1)

                Next
            End If

            Plot_Values()
        End If

    End Sub
    Private Sub Plot_Values()

        Chart_Plot.Series("Series_Plot").Points.Clear()
        For index = 0 To Database_Count - 1

            Chart_Plot.Series("Series_Plot").Points.AddXY(index, Database(index))

        Next

    End Sub
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
    'UI
    Private Sub Set_Range()



        Select Case ComboBox_Range.SelectedIndex

            Case 0 '0.6
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 0.05
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0.6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -0.6

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0.6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -0.6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 0.1

                End If

            Case 1 '6
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 0.5
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -6

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 1

                End If

            Case 2 '60
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 5
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 60
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -60

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 60
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -60
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 10

                End If

            Case 3 '600
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 50
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 600
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -600

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 600
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -600
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 100

                End If

            Case 4 '6000
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 500
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 6000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -6000

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 6000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -6000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 1000

                End If

            Case 5 '60000
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 5000
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 60000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -60000

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 60000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -60000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 10000

                End If

            Case 6 '600000
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 50000
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 600000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -600000

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 600000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -600000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 100000

                End If

            Case 7 '6000000
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 500000
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 6000000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -6000000

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 6000000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -6000000
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 1000000

                End If

            Case Else
                Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 0.5
                If RadioButton_Range1.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = 0

                ElseIf RadioButton_Range2.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 0
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -6

                ElseIf RadioButton_Range3.Checked Then

                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Maximum = 6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Minimum = -6
                    Chart_Plot.ChartAreas.Item("ChartArea_Plot").AxisY.Interval = 1

                End If

        End Select











    End Sub
    Private Sub ComboBox_Range_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Range.SelectedIndexChanged
        Set_Range()
    End Sub
    Private Sub RadioButton_Range1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Range1.CheckedChanged
        If RadioButton_Range1.Checked Then Set_Range()
    End Sub
    Private Sub RadioButton_Range2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Range2.CheckedChanged
        If RadioButton_Range2.Checked Then Set_Range()
    End Sub
    Private Sub RadioButton_Range3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Range3.CheckedChanged
        If RadioButton_Range3.Checked Then Set_Range()
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
    Private Sub Change_Database_Length()

        Database_Length = Database.Length

        If Database_Length > NumericUpDown_PlotPoints.Value And Database_Count > NumericUpDown_PlotPoints.Value Then

            For index = 0 To NumericUpDown_PlotPoints.Value - 2 'may need to start at 1?

                Database(index) = Database(index + (Database_Count - NumericUpDown_PlotPoints.Value))
            Next
        End If

        Database_Length = NumericUpDown_PlotPoints.Value
        ReDim Preserve Database(NumericUpDown_PlotPoints.Value)

    End Sub

End Class