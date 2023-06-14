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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart_Plot = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Timer_ReadValue = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Chart_Plot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart_Plot
        '
        Me.Chart_Plot.BackColor = System.Drawing.Color.Silver
        Me.Chart_Plot.BackSecondaryColor = System.Drawing.Color.Silver
        Me.Chart_Plot.BorderlineColor = System.Drawing.Color.Silver
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea2.AxisX.LabelStyle.Enabled = False
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisX.MajorTickMark.Enabled = False
        ChartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisY.Interval = 1.0R
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray
        ChartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisY.Maximum = 6.0R
        ChartArea2.AxisY.Minimum = -6.0R
        ChartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisY.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea2.AxisY.ScrollBar.Enabled = False
        ChartArea2.BackColor = System.Drawing.Color.MidnightBlue
        ChartArea2.BackSecondaryColor = System.Drawing.Color.Silver
        ChartArea2.Name = "ChartArea1"
        Me.Chart_Plot.ChartAreas.Add(ChartArea2)
        Me.Chart_Plot.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.BackColor = System.Drawing.Color.Silver
        Legend2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center
        Legend2.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled
        Legend2.DockedToChartArea = "ChartArea1"
        Legend2.ItemColumnSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.GradientLine
        Legend2.ItemColumnSpacing = 5
        Legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row
        Legend2.Name = "Legend1"
        Legend2.Position.Auto = False
        Legend2.Position.Height = 6.0!
        Legend2.Position.Width = 100.0!
        Me.Chart_Plot.Legends.Add(Legend2)
        Me.Chart_Plot.Location = New System.Drawing.Point(0, 0)
        Me.Chart_Plot.Name = "Chart_Plot"
        Me.Chart_Plot.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left
        Series2.BackSecondaryColor = System.Drawing.Color.Silver
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series2.Color = System.Drawing.Color.Yellow
        Series2.IsVisibleInLegend = False
        Series2.LabelBackColor = System.Drawing.Color.Transparent
        Series2.Legend = "Legend1"
        Series2.MarkerBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series2.Name = "Series_Plot"
        Me.Chart_Plot.Series.Add(Series2)
        Me.Chart_Plot.Size = New System.Drawing.Size(800, 450)
        Me.Chart_Plot.TabIndex = 0
        Me.Chart_Plot.Text = "Plot"
        '
        'Timer_ReadValue
        '
        Me.Timer_ReadValue.Enabled = True
        Me.Timer_ReadValue.Interval = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(283, 358)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 37)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Work in Progress"
        '
        'Form_Plot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chart_Plot)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "Form_Plot_Location", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Location = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.Form_Plot_Location
        Me.Name = "Form_Plot"
        Me.Text = "Plot"
        CType(Me.Chart_Plot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart_Plot As DataVisualization.Charting.Chart
    Friend WithEvents Timer_ReadValue As Timer
    Friend WithEvents Label1 As Label
End Class
