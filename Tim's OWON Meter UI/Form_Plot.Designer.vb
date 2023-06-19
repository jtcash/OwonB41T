<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Plot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Plot))
        Me.Chart_Plot = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Timer_ReadValue = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox_Range = New System.Windows.Forms.GroupBox()
        Me.RadioButton_Range3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Range2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox_AutoRange = New System.Windows.Forms.CheckBox()
        Me.ComboBox_Range = New System.Windows.Forms.ComboBox()
        Me.RadioButton_Range1 = New System.Windows.Forms.RadioButton()
        Me.NumericUpDown_PlotPoints = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox_PlotPoints = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox_ReadInterval = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown_ReadInterval = New System.Windows.Forms.NumericUpDown()
        Me.Button_Hold = New System.Windows.Forms.Button()
        Me.GroupBox_ZoomLevel = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown_ZoomLevel = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox_SaveData = New System.Windows.Forms.GroupBox()
        Me.CheckBox_AppendFile = New System.Windows.Forms.CheckBox()
        Me.Button_SaveToFile = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBoxMode = New System.Windows.Forms.GroupBox()
        Me.RadioButton_Mode2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Mode1 = New System.Windows.Forms.RadioButton()
        Me.Button_ZeroCursor = New System.Windows.Forms.Button()
        CType(Me.Chart_Plot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Range.SuspendLayout()
        CType(Me.NumericUpDown_PlotPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_PlotPoints.SuspendLayout()
        Me.GroupBox_ReadInterval.SuspendLayout()
        CType(Me.NumericUpDown_ReadInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_ZoomLevel.SuspendLayout()
        CType(Me.NumericUpDown_ZoomLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_SaveData.SuspendLayout()
        Me.GroupBoxMode.SuspendLayout()
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
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea1.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelAutoFitMaxFontSize = 12
        ChartArea1.AxisX.LabelAutoFitMinFontSize = 8
        ChartArea1.AxisX.LabelAutoFitStyle = CType((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Tims_OWON_Meter", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.MajorTickMark.Interval = 0R
        ChartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Red
        ChartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis
        ChartArea1.AxisX.MaximumAutoSize = 12.0!
        ChartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.MinorTickMark.Enabled = True
        ChartArea1.AxisX.MinorTickMark.Interval = 5.0R
        ChartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Red
        ChartArea1.AxisX.ScaleView.MinSize = 100.0R
        ChartArea1.AxisX.ScaleView.Size = 100.0R
        ChartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.MidnightBlue
        ChartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll
        ChartArea1.AxisY.Interval = 1.0R
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelAutoFitMaxFontSize = 16
        ChartArea1.AxisY.LabelAutoFitMinFontSize = 10
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Red
        ChartArea1.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis
        ChartArea1.AxisY.Maximum = 6.0R
        ChartArea1.AxisY.MaximumAutoSize = 16.0!
        ChartArea1.AxisY.Minimum = -6.0R
        ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisY.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea1.AxisY.ScrollBar.Enabled = False
        ChartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Tims_OWON_Meter", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.BackColor = System.Drawing.Color.MidnightBlue
        ChartArea1.BackSecondaryColor = System.Drawing.Color.Silver
        ChartArea1.CursorY.IsUserEnabled = True
        ChartArea1.CursorY.Position = 0R
        ChartArea1.Name = "ChartArea_Plot"
        ChartArea1.Position.Auto = False
        ChartArea1.Position.Height = 100.0!
        ChartArea1.Position.Width = 100.0!
        Me.Chart_Plot.ChartAreas.Add(ChartArea1)
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
        Series1.MarkerBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series1.Name = "Series_Plot"
        Me.Chart_Plot.Series.Add(Series1)
        Me.Chart_Plot.Size = New System.Drawing.Size(1007, 766)
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
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(4, 741)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Work in Progress"
        '
        'GroupBox_Range
        '
        Me.GroupBox_Range.Controls.Add(Me.RadioButton_Range3)
        Me.GroupBox_Range.Controls.Add(Me.RadioButton_Range2)
        Me.GroupBox_Range.Controls.Add(Me.CheckBox_AutoRange)
        Me.GroupBox_Range.Controls.Add(Me.ComboBox_Range)
        Me.GroupBox_Range.Controls.Add(Me.RadioButton_Range1)
        Me.GroupBox_Range.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox_Range.Name = "GroupBox_Range"
        Me.GroupBox_Range.Size = New System.Drawing.Size(180, 66)
        Me.GroupBox_Range.TabIndex = 2
        Me.GroupBox_Range.TabStop = False
        Me.GroupBox_Range.Text = "Range"
        '
        'RadioButton_Range3
        '
        Me.RadioButton_Range3.Checked = True
        Me.RadioButton_Range3.Location = New System.Drawing.Point(117, 15)
        Me.RadioButton_Range3.Name = "RadioButton_Range3"
        Me.RadioButton_Range3.Size = New System.Drawing.Size(50, 20)
        Me.RadioButton_Range3.TabIndex = 5
        Me.RadioButton_Range3.TabStop = True
        Me.RadioButton_Range3.Text = "Both"
        Me.RadioButton_Range3.UseVisualStyleBackColor = True
        '
        'RadioButton_Range2
        '
        Me.RadioButton_Range2.Location = New System.Drawing.Point(61, 15)
        Me.RadioButton_Range2.Name = "RadioButton_Range2"
        Me.RadioButton_Range2.Size = New System.Drawing.Size(55, 20)
        Me.RadioButton_Range2.TabIndex = 4
        Me.RadioButton_Range2.Text = "-Neg."
        Me.RadioButton_Range2.UseVisualStyleBackColor = True
        '
        'CheckBox_AutoRange
        '
        Me.CheckBox_AutoRange.Checked = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.CheckBox_Auto_Checked
        Me.CheckBox_AutoRange.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "CheckBox_Auto_Checked", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox_AutoRange.Location = New System.Drawing.Point(115, 40)
        Me.CheckBox_AutoRange.Name = "CheckBox_AutoRange"
        Me.CheckBox_AutoRange.Size = New System.Drawing.Size(50, 21)
        Me.CheckBox_AutoRange.TabIndex = 5
        Me.CheckBox_AutoRange.Text = "Auto"
        Me.CheckBox_AutoRange.UseVisualStyleBackColor = True
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
        Me.ComboBox_Range.Size = New System.Drawing.Size(100, 21)
        Me.ComboBox_Range.TabIndex = 3
        Me.ComboBox_Range.Text = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.ComboBox_Range_Text
        '
        'RadioButton_Range1
        '
        Me.RadioButton_Range1.Location = New System.Drawing.Point(5, 15)
        Me.RadioButton_Range1.Name = "RadioButton_Range1"
        Me.RadioButton_Range1.Size = New System.Drawing.Size(55, 20)
        Me.RadioButton_Range1.TabIndex = 3
        Me.RadioButton_Range1.Text = "+Pos."
        Me.RadioButton_Range1.UseVisualStyleBackColor = True
        '
        'NumericUpDown_PlotPoints
        '
        Me.NumericUpDown_PlotPoints.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "NumericUpDown_PlotPoints_Value", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown_PlotPoints.Location = New System.Drawing.Point(15, 15)
        Me.NumericUpDown_PlotPoints.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown_PlotPoints.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NumericUpDown_PlotPoints.Name = "NumericUpDown_PlotPoints"
        Me.NumericUpDown_PlotPoints.Size = New System.Drawing.Size(60, 20)
        Me.NumericUpDown_PlotPoints.TabIndex = 3
        Me.NumericUpDown_PlotPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown_PlotPoints.Value = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.NumericUpDown_PlotPoints_Value
        '
        'GroupBox_PlotPoints
        '
        Me.GroupBox_PlotPoints.Controls.Add(Me.Label3)
        Me.GroupBox_PlotPoints.Controls.Add(Me.NumericUpDown_PlotPoints)
        Me.GroupBox_PlotPoints.Location = New System.Drawing.Point(12, 132)
        Me.GroupBox_PlotPoints.Name = "GroupBox_PlotPoints"
        Me.GroupBox_PlotPoints.Size = New System.Drawing.Size(180, 44)
        Me.GroupBox_PlotPoints.TabIndex = 5
        Me.GroupBox_PlotPoints.TabStop = False
        Me.GroupBox_PlotPoints.Text = "Plot Points"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(80, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 26)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Number of Points" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stored"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox_ReadInterval
        '
        Me.GroupBox_ReadInterval.Controls.Add(Me.Label2)
        Me.GroupBox_ReadInterval.Controls.Add(Me.NumericUpDown_ReadInterval)
        Me.GroupBox_ReadInterval.Location = New System.Drawing.Point(12, 232)
        Me.GroupBox_ReadInterval.Name = "GroupBox_ReadInterval"
        Me.GroupBox_ReadInterval.Size = New System.Drawing.Size(180, 44)
        Me.GroupBox_ReadInterval.TabIndex = 6
        Me.GroupBox_ReadInterval.TabStop = False
        Me.GroupBox_ReadInterval.Text = "Read Interval"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(80, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 26)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Seconds"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumericUpDown_ReadInterval
        '
        Me.NumericUpDown_ReadInterval.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "NumericUpDown_ReadInterval_Value", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown_ReadInterval.DecimalPlaces = 1
        Me.NumericUpDown_ReadInterval.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.NumericUpDown_ReadInterval.Location = New System.Drawing.Point(15, 15)
        Me.NumericUpDown_ReadInterval.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.NumericUpDown_ReadInterval.Minimum = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.NumericUpDown_ReadInterval.Name = "NumericUpDown_ReadInterval"
        Me.NumericUpDown_ReadInterval.Size = New System.Drawing.Size(60, 20)
        Me.NumericUpDown_ReadInterval.TabIndex = 3
        Me.NumericUpDown_ReadInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown_ReadInterval.Value = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.NumericUpDown_ReadInterval_Value
        '
        'Button_Hold
        '
        Me.Button_Hold.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_Hold.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Hold.Image = CType(resources.GetObject("Button_Hold.Image"), System.Drawing.Image)
        Me.Button_Hold.Location = New System.Drawing.Point(12, 368)
        Me.Button_Hold.Name = "Button_Hold"
        Me.Button_Hold.Size = New System.Drawing.Size(50, 40)
        Me.Button_Hold.TabIndex = 20
        Me.Button_Hold.UseVisualStyleBackColor = False
        '
        'GroupBox_ZoomLevel
        '
        Me.GroupBox_ZoomLevel.Controls.Add(Me.NumericUpDown_ZoomLevel)
        Me.GroupBox_ZoomLevel.Controls.Add(Me.Label4)
        Me.GroupBox_ZoomLevel.Location = New System.Drawing.Point(12, 182)
        Me.GroupBox_ZoomLevel.Name = "GroupBox_ZoomLevel"
        Me.GroupBox_ZoomLevel.Size = New System.Drawing.Size(180, 44)
        Me.GroupBox_ZoomLevel.TabIndex = 8
        Me.GroupBox_ZoomLevel.TabStop = False
        Me.GroupBox_ZoomLevel.Text = "Zoom Level"
        '
        'NumericUpDown_ZoomLevel
        '
        Me.NumericUpDown_ZoomLevel.Location = New System.Drawing.Point(15, 15)
        Me.NumericUpDown_ZoomLevel.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.NumericUpDown_ZoomLevel.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NumericUpDown_ZoomLevel.Name = "NumericUpDown_ZoomLevel"
        Me.NumericUpDown_ZoomLevel.Size = New System.Drawing.Size(60, 20)
        Me.NumericUpDown_ZoomLevel.TabIndex = 21
        Me.NumericUpDown_ZoomLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown_ZoomLevel.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(80, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 26)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Number of Points" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Viewable"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox_SaveData
        '
        Me.GroupBox_SaveData.Controls.Add(Me.CheckBox_AppendFile)
        Me.GroupBox_SaveData.Controls.Add(Me.Button_SaveToFile)
        Me.GroupBox_SaveData.Location = New System.Drawing.Point(12, 282)
        Me.GroupBox_SaveData.Name = "GroupBox_SaveData"
        Me.GroupBox_SaveData.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox_SaveData.TabIndex = 21
        Me.GroupBox_SaveData.TabStop = False
        Me.GroupBox_SaveData.Text = "Save Data (CSV)"
        '
        'CheckBox_AppendFile
        '
        Me.CheckBox_AppendFile.AutoSize = True
        Me.CheckBox_AppendFile.Checked = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.CheckBox_AppendFile_Checked
        Me.CheckBox_AppendFile.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "CheckBox_AppendFile_Checked", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox_AppendFile.Location = New System.Drawing.Point(15, 15)
        Me.CheckBox_AppendFile.Name = "CheckBox_AppendFile"
        Me.CheckBox_AppendFile.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox_AppendFile.TabIndex = 23
        Me.CheckBox_AppendFile.Text = "Append to File"
        Me.CheckBox_AppendFile.UseVisualStyleBackColor = True
        '
        'Button_SaveToFile
        '
        Me.Button_SaveToFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_SaveToFile.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button_SaveToFile.FlatAppearance.BorderSize = 2
        Me.Button_SaveToFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_SaveToFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Button_SaveToFile.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_SaveToFile.ForeColor = System.Drawing.Color.Silver
        Me.Button_SaveToFile.Location = New System.Drawing.Point(5, 38)
        Me.Button_SaveToFile.Name = "Button_SaveToFile"
        Me.Button_SaveToFile.Size = New System.Drawing.Size(170, 35)
        Me.Button_SaveToFile.TabIndex = 54
        Me.Button_SaveToFile.Text = "Save To File"
        Me.Button_SaveToFile.UseVisualStyleBackColor = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.SaveFileDialog1_FileName
        '
        'GroupBoxMode
        '
        Me.GroupBoxMode.Controls.Add(Me.RadioButton_Mode2)
        Me.GroupBoxMode.Controls.Add(Me.RadioButton_Mode1)
        Me.GroupBoxMode.Enabled = False
        Me.GroupBoxMode.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxMode.Name = "GroupBoxMode"
        Me.GroupBoxMode.Size = New System.Drawing.Size(180, 42)
        Me.GroupBoxMode.TabIndex = 22
        Me.GroupBoxMode.TabStop = False
        Me.GroupBoxMode.Text = "Mode"
        '
        'RadioButton_Mode2
        '
        Me.RadioButton_Mode2.Location = New System.Drawing.Point(61, 15)
        Me.RadioButton_Mode2.Name = "RadioButton_Mode2"
        Me.RadioButton_Mode2.Size = New System.Drawing.Size(70, 20)
        Me.RadioButton_Mode2.TabIndex = 4
        Me.RadioButton_Mode2.Text = "Off-Line"
        Me.RadioButton_Mode2.UseVisualStyleBackColor = True
        '
        'RadioButton_Mode1
        '
        Me.RadioButton_Mode1.Checked = True
        Me.RadioButton_Mode1.Location = New System.Drawing.Point(5, 15)
        Me.RadioButton_Mode1.Name = "RadioButton_Mode1"
        Me.RadioButton_Mode1.Size = New System.Drawing.Size(55, 20)
        Me.RadioButton_Mode1.TabIndex = 3
        Me.RadioButton_Mode1.TabStop = True
        Me.RadioButton_Mode1.Text = "Live"
        Me.RadioButton_Mode1.UseVisualStyleBackColor = True
        '
        'Button_ZeroCursor
        '
        Me.Button_ZeroCursor.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_ZeroCursor.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button_ZeroCursor.FlatAppearance.BorderSize = 2
        Me.Button_ZeroCursor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_ZeroCursor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.Button_ZeroCursor.Font = New System.Drawing.Font("Tims_OWON_Meter", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_ZeroCursor.ForeColor = System.Drawing.Color.Silver
        Me.Button_ZeroCursor.Location = New System.Drawing.Point(66, 368)
        Me.Button_ZeroCursor.Name = "Button_ZeroCursor"
        Me.Button_ZeroCursor.Size = New System.Drawing.Size(126, 40)
        Me.Button_ZeroCursor.TabIndex = 55
        Me.Button_ZeroCursor.Text = "Zero Cursor"
        Me.Button_ZeroCursor.UseVisualStyleBackColor = False
        '
        'Form_Plot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1219, 783)
        Me.Controls.Add(Me.Button_ZeroCursor)
        Me.Controls.Add(Me.GroupBoxMode)
        Me.Controls.Add(Me.GroupBox_SaveData)
        Me.Controls.Add(Me.GroupBox_ZoomLevel)
        Me.Controls.Add(Me.Button_Hold)
        Me.Controls.Add(Me.GroupBox_ReadInterval)
        Me.Controls.Add(Me.GroupBox_PlotPoints)
        Me.Controls.Add(Me.GroupBox_Range)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chart_Plot)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "Form_Plot_Location", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Location = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.Form_Plot_Location
        Me.MinimumSize = New System.Drawing.Size(820, 500)
        Me.Name = "Form_Plot"
        Me.Text = "Plot"
        CType(Me.Chart_Plot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Range.ResumeLayout(False)
        CType(Me.NumericUpDown_PlotPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_PlotPoints.ResumeLayout(False)
        Me.GroupBox_ReadInterval.ResumeLayout(False)
        CType(Me.NumericUpDown_ReadInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_ZoomLevel.ResumeLayout(False)
        CType(Me.NumericUpDown_ZoomLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_SaveData.ResumeLayout(False)
        Me.GroupBox_SaveData.PerformLayout()
        Me.GroupBoxMode.ResumeLayout(False)
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
    Friend WithEvents CheckBox_AutoRange As CheckBox
    Friend WithEvents GroupBox_PlotPoints As GroupBox
    Friend WithEvents GroupBox_ReadInterval As GroupBox
    Friend WithEvents NumericUpDown_ReadInterval As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button_Hold As Button
    Friend WithEvents GroupBox_ZoomLevel As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDown_ZoomLevel As NumericUpDown
    Friend WithEvents GroupBox_SaveData As GroupBox
    Friend WithEvents Button_SaveToFile As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents GroupBoxMode As GroupBox
    Friend WithEvents RadioButton_Mode2 As RadioButton
    Friend WithEvents RadioButton_Mode1 As RadioButton
    Friend WithEvents CheckBox_AppendFile As CheckBox
    Friend WithEvents Button_ZeroCursor As Button
End Class
