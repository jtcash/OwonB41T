<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Plot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart_Plot = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Timer_ReadValue = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox_Range = New System.Windows.Forms.GroupBox()
        Me.ComboBox_Range = New System.Windows.Forms.ComboBox()
        Me.RadioButton_Range3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Range2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Range1 = New System.Windows.Forms.RadioButton()
        Me.NumericUpDown_PlotPoints = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Chart_Plot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Range.SuspendLayout()
        CType(Me.NumericUpDown_PlotPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart_Plot
        '
        Me.Chart_Plot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart_Plot.BackColor = System.Drawing.Color.Silver
        Me.Chart_Plot.BackSecondaryColor = System.Drawing.Color.Silver
        Me.Chart_Plot.BorderlineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.LabelStyle.Enabled = False
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisY.Interval = 1.0R
        ChartArea1.AxisY.LabelAutoFitMaxFontSize = 20
        ChartArea1.AxisY.LabelAutoFitMinFontSize = 10
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisY.Maximum = 6.0R
        ChartArea1.AxisY.MaximumAutoSize = 20.0!
        ChartArea1.AxisY.Minimum = -6.0R
        ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisY.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea1.AxisY.ScrollBar.Enabled = False
        ChartArea1.BackColor = System.Drawing.Color.MidnightBlue
        ChartArea1.BackSecondaryColor = System.Drawing.Color.Silver
        ChartArea1.Name = "ChartArea_Plot"
        ChartArea1.Position.Auto = False
        ChartArea1.Position.Height = 90.0!
        ChartArea1.Position.Width = 94.0!
        ChartArea1.Position.X = 3.0!
        ChartArea1.Position.Y = 8.0!
        Me.Chart_Plot.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Silver
        Legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center
        Legend1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled
        Legend1.DockedToChartArea = "ChartArea_Plot"
        Legend1.ItemColumnSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.GradientLine
        Legend1.ItemColumnSpacing = 5
        Legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row
        Legend1.Name = "Legend1"
        Legend1.Position.Auto = False
        Legend1.Position.Height = 6.0!
        Legend1.Position.Width = 100.0!
        Me.Chart_Plot.Legends.Add(Legend1)
        Me.Chart_Plot.Location = New System.Drawing.Point(200, 5)
        Me.Chart_Plot.Name = "Chart_Plot"
        Me.Chart_Plot.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left
        Series1.BackSecondaryColor = System.Drawing.Color.Silver
        Series1.ChartArea = "ChartArea_Plot"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series1.Color = System.Drawing.Color.Yellow
        Series1.IsVisibleInLegend = False
        Series1.LabelBackColor = System.Drawing.Color.Transparent
        Series1.Legend = "Legend1"
        Series1.MarkerBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series1.Name = "Series_Plot"
        Me.Chart_Plot.Series.Add(Series1)
        Me.Chart_Plot.Size = New System.Drawing.Size(770, 640)
        Me.Chart_Plot.TabIndex = 0
        Me.Chart_Plot.Text = "Plot"
        '
        'Timer_ReadValue
        '
        Me.Timer_ReadValue.Enabled = True
        Me.Timer_ReadValue.Interval = 150
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 33)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Work in Progress"
        '
        'GroupBox_Range
        '
        Me.GroupBox_Range.Controls.Add(Me.ComboBox_Range)
        Me.GroupBox_Range.Controls.Add(Me.RadioButton_Range3)
        Me.GroupBox_Range.Controls.Add(Me.RadioButton_Range2)
        Me.GroupBox_Range.Controls.Add(Me.RadioButton_Range1)
        Me.GroupBox_Range.Location = New System.Drawing.Point(5, 50)
        Me.GroupBox_Range.Name = "GroupBox_Range"
        Me.GroupBox_Range.Size = New System.Drawing.Size(190, 66)
        Me.GroupBox_Range.TabIndex = 2
        Me.GroupBox_Range.TabStop = False
        Me.GroupBox_Range.Text = "Range"
        '
        'ComboBox_Range
        '
        Me.ComboBox_Range.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "ComboBox_Range_Text", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ComboBox_Range.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Range.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBox_Range.FormattingEnabled = True
        Me.ComboBox_Range.Items.AddRange(New Object() {"0.6", "6", "60", "600", "6000", "60000", "600000", "6000000"})
        Me.ComboBox_Range.Location = New System.Drawing.Point(5, 40)
        Me.ComboBox_Range.Name = "ComboBox_Range"
        Me.ComboBox_Range.Size = New System.Drawing.Size(104, 21)
        Me.ComboBox_Range.TabIndex = 3
        Me.ComboBox_Range.Text = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.ComboBox_Range_Text
        '
        'RadioButton_Range3
        '
        Me.RadioButton_Range3.Checked = True
        Me.RadioButton_Range3.Location = New System.Drawing.Point(125, 15)
        Me.RadioButton_Range3.Name = "RadioButton_Range3"
        Me.RadioButton_Range3.Size = New System.Drawing.Size(60, 20)
        Me.RadioButton_Range3.TabIndex = 5
        Me.RadioButton_Range3.TabStop = True
        Me.RadioButton_Range3.Text = "Both"
        Me.RadioButton_Range3.UseVisualStyleBackColor = True
        '
        'RadioButton_Range2
        '
        Me.RadioButton_Range2.Location = New System.Drawing.Point(65, 15)
        Me.RadioButton_Range2.Name = "RadioButton_Range2"
        Me.RadioButton_Range2.Size = New System.Drawing.Size(60, 20)
        Me.RadioButton_Range2.TabIndex = 4
        Me.RadioButton_Range2.Text = "-Neg."
        Me.RadioButton_Range2.UseVisualStyleBackColor = True
        '
        'RadioButton_Range1
        '
        Me.RadioButton_Range1.Location = New System.Drawing.Point(5, 15)
        Me.RadioButton_Range1.Name = "RadioButton_Range1"
        Me.RadioButton_Range1.Size = New System.Drawing.Size(60, 20)
        Me.RadioButton_Range1.TabIndex = 3
        Me.RadioButton_Range1.Text = "+Pos."
        Me.RadioButton_Range1.UseVisualStyleBackColor = True
        '
        'NumericUpDown_PlotPoints
        '
        Me.NumericUpDown_PlotPoints.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_PlotPoints.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "NumericUpDown_PlotPoints_Value", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown_PlotPoints.Location = New System.Drawing.Point(900, 640)
        Me.NumericUpDown_PlotPoints.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown_PlotPoints.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NumericUpDown_PlotPoints.Name = "NumericUpDown_PlotPoints"
        Me.NumericUpDown_PlotPoints.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown_PlotPoints.TabIndex = 3
        Me.NumericUpDown_PlotPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown_PlotPoints.Value = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.NumericUpDown_PlotPoints_Value
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(840, 642)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Plot Points"
        '
        'Form_Plot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(992, 669)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown_PlotPoints)
        Me.Controls.Add(Me.GroupBox_Range)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chart_Plot)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "Form_Plot_Location", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Location = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.Form_Plot_Location
        Me.Name = "Form_Plot"
        Me.Text = "Plot"
        CType(Me.Chart_Plot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Range.ResumeLayout(False)
        CType(Me.NumericUpDown_PlotPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart_Plot As DataVisualization.Charting.Chart
    Friend WithEvents Timer_ReadValue As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox_Range As GroupBox
    Friend WithEvents RadioButton_Range3 As RadioButton
    Friend WithEvents RadioButton_Range2 As RadioButton
    Friend WithEvents RadioButton_Range1 As RadioButton
    Friend WithEvents ComboBox_Range As ComboBox
    Friend WithEvents NumericUpDown_PlotPoints As NumericUpDown
    Friend WithEvents Label2 As Label
End Class
