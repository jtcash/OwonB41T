<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button_Connect = New System.Windows.Forms.Button()
        Me.RichTextBox_Input = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox_ErrorStream = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox_ShellOutput = New System.Windows.Forms.RichTextBox()
        Me.Button_UI = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label_Hfe = New System.Windows.Forms.Label()
        Me.Label_Temp = New System.Windows.Forms.Label()
        Me.PictureBox_Bar = New System.Windows.Forms.PictureBox()
        Me.Picture_BoxNegative = New System.Windows.Forms.PictureBox()
        Me.Label_RPM = New System.Windows.Forms.Label()
        Me.PictureBox_BarFixed = New System.Windows.Forms.PictureBox()
        Me.Label_Volts = New System.Windows.Forms.Label()
        Me.Label_ACDC = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label_Amps = New System.Windows.Forms.Label()
        Me.Label_Hz = New System.Windows.Forms.Label()
        Me.PictureBox_Hold = New System.Windows.Forms.PictureBox()
        Me.Label_Ohm = New System.Windows.Forms.Label()
        Me.PictureBox_Triangle = New System.Windows.Forms.PictureBox()
        Me.PictureBox_HighV = New System.Windows.Forms.PictureBox()
        Me.Label_Auto = New System.Windows.Forms.Label()
        Me.PictureBox_Speaker = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Diode = New System.Windows.Forms.PictureBox()
        Me.Label_Duty = New System.Windows.Forms.Label()
        Me.Label_Max = New System.Windows.Forms.Label()
        Me.Label_Min = New System.Windows.Forms.Label()
        Me.RichTextBox_Negative = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox_MeterValue = New System.Windows.Forms.RichTextBox()
        Me.Label_BlueTooth = New System.Windows.Forms.Label()
        Me.Button_HzDuty = New System.Windows.Forms.Button()
        Me.Button_MaxMin = New System.Windows.Forms.Button()
        Me.Button_Range = New System.Windows.Forms.Button()
        Me.Button_Select = New System.Windows.Forms.Button()
        Me.Button_Send = New System.Windows.Forms.Button()
        Me.GroupBox_ShellOutput = New System.Windows.Forms.GroupBox()
        Me.GroupBox_ShellPath = New System.Windows.Forms.GroupBox()
        Me.TextBox_Shell_Path = New System.Windows.Forms.TextBox()
        Me.GroupBox_Status = New System.Windows.Forms.GroupBox()
        Me.GroupBox_CommandInput = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button_BackLight = New System.Windows.Forms.Button()
        Me.Button_Relative = New System.Windows.Forms.Button()
        Me.Button_Bluetooth = New System.Windows.Forms.Button()
        Me.Button_Hold = New System.Windows.Forms.Button()
        Me.Button_Auto = New System.Windows.Forms.Button()
        Me.Button_Plot = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture_BoxNegative, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_BarFixed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Hold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Triangle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_HighV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Speaker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Diode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_ShellOutput.SuspendLayout()
        Me.GroupBox_ShellPath.SuspendLayout()
        Me.GroupBox_Status.SuspendLayout()
        Me.GroupBox_CommandInput.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Connect
        '
        Me.Button_Connect.BackColor = System.Drawing.Color.Green
        Me.Button_Connect.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_Connect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
        Me.Button_Connect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime
        Me.Button_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Connect.ForeColor = System.Drawing.Color.Silver
        Me.Button_Connect.Location = New System.Drawing.Point(5, 399)
        Me.Button_Connect.Name = "Button_Connect"
        Me.Button_Connect.Size = New System.Drawing.Size(105, 25)
        Me.Button_Connect.TabIndex = 11
        Me.Button_Connect.Text = "Connect"
        Me.Button_Connect.UseVisualStyleBackColor = False
        '
        'RichTextBox_Input
        '
        Me.RichTextBox_Input.BackColor = System.Drawing.Color.White
        Me.RichTextBox_Input.DetectUrls = False
        Me.RichTextBox_Input.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox_Input.ForeColor = System.Drawing.Color.Black
        Me.RichTextBox_Input.Location = New System.Drawing.Point(5, 15)
        Me.RichTextBox_Input.Multiline = False
        Me.RichTextBox_Input.Name = "RichTextBox_Input"
        Me.RichTextBox_Input.Size = New System.Drawing.Size(344, 28)
        Me.RichTextBox_Input.TabIndex = 7
        Me.RichTextBox_Input.Text = ""
        '
        'RichTextBox_ErrorStream
        '
        Me.RichTextBox_ErrorStream.BackColor = System.Drawing.Color.Silver
        Me.RichTextBox_ErrorStream.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox_ErrorStream.ForeColor = System.Drawing.Color.Black
        Me.RichTextBox_ErrorStream.Location = New System.Drawing.Point(5, 15)
        Me.RichTextBox_ErrorStream.Name = "RichTextBox_ErrorStream"
        Me.RichTextBox_ErrorStream.ReadOnly = True
        Me.RichTextBox_ErrorStream.Size = New System.Drawing.Size(430, 108)
        Me.RichTextBox_ErrorStream.TabIndex = 10
        Me.RichTextBox_ErrorStream.TabStop = False
        Me.RichTextBox_ErrorStream.Text = ""
        '
        'RichTextBox_ShellOutput
        '
        Me.RichTextBox_ShellOutput.BackColor = System.Drawing.Color.MidnightBlue
        Me.RichTextBox_ShellOutput.ForeColor = System.Drawing.Color.White
        Me.RichTextBox_ShellOutput.Location = New System.Drawing.Point(5, 15)
        Me.RichTextBox_ShellOutput.Name = "RichTextBox_ShellOutput"
        Me.RichTextBox_ShellOutput.ReadOnly = True
        Me.RichTextBox_ShellOutput.Size = New System.Drawing.Size(430, 168)
        Me.RichTextBox_ShellOutput.TabIndex = 8
        Me.RichTextBox_ShellOutput.TabStop = False
        Me.RichTextBox_ShellOutput.Text = ""
        '
        'Button_UI
        '
        Me.Button_UI.BackColor = System.Drawing.Color.Gray
        Me.Button_UI.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_UI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button_UI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_UI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_UI.ForeColor = System.Drawing.Color.Silver
        Me.Button_UI.Location = New System.Drawing.Point(410, 399)
        Me.Button_UI.Name = "Button_UI"
        Me.Button_UI.Size = New System.Drawing.Size(105, 25)
        Me.Button_UI.TabIndex = 17
        Me.Button_UI.Text = "UI"
        Me.Button_UI.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label_BlueTooth)
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(510, 280)
        Me.Panel1.TabIndex = 21
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label_Hfe)
        Me.Panel3.Controls.Add(Me.Label_Temp)
        Me.Panel3.Controls.Add(Me.PictureBox_Bar)
        Me.Panel3.Controls.Add(Me.Picture_BoxNegative)
        Me.Panel3.Controls.Add(Me.Label_RPM)
        Me.Panel3.Controls.Add(Me.PictureBox_BarFixed)
        Me.Panel3.Controls.Add(Me.Label_Volts)
        Me.Panel3.Controls.Add(Me.Label_ACDC)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.Label_Amps)
        Me.Panel3.Controls.Add(Me.Label_Hz)
        Me.Panel3.Controls.Add(Me.PictureBox_Hold)
        Me.Panel3.Controls.Add(Me.Label_Ohm)
        Me.Panel3.Controls.Add(Me.PictureBox_Triangle)
        Me.Panel3.Controls.Add(Me.PictureBox_HighV)
        Me.Panel3.Controls.Add(Me.Label_Auto)
        Me.Panel3.Controls.Add(Me.PictureBox_Speaker)
        Me.Panel3.Controls.Add(Me.PictureBox_Diode)
        Me.Panel3.Controls.Add(Me.Label_Duty)
        Me.Panel3.Controls.Add(Me.Label_Max)
        Me.Panel3.Controls.Add(Me.Label_Min)
        Me.Panel3.Controls.Add(Me.RichTextBox_Negative)
        Me.Panel3.Controls.Add(Me.RichTextBox_MeterValue)
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(500, 270)
        Me.Panel3.TabIndex = 42
        '
        'Label_Hfe
        '
        Me.Label_Hfe.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Hfe.Location = New System.Drawing.Point(403, 50)
        Me.Label_Hfe.Name = "Label_Hfe"
        Me.Label_Hfe.Size = New System.Drawing.Size(60, 22)
        Me.Label_Hfe.TabIndex = 30
        Me.Label_Hfe.Text = "hFE"
        Me.Label_Hfe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Temp
        '
        Me.Label_Temp.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Temp.Location = New System.Drawing.Point(448, 50)
        Me.Label_Temp.Name = "Label_Temp"
        Me.Label_Temp.Size = New System.Drawing.Size(60, 22)
        Me.Label_Temp.TabIndex = 28
        Me.Label_Temp.Text = "°C"
        Me.Label_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox_Bar
        '
        Me.PictureBox_Bar.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Bar.Image = CType(resources.GetObject("PictureBox_Bar.Image"), System.Drawing.Image)
        Me.PictureBox_Bar.Location = New System.Drawing.Point(32, 202)
        Me.PictureBox_Bar.Name = "PictureBox_Bar"
        Me.PictureBox_Bar.Size = New System.Drawing.Size(464, 44)
        Me.PictureBox_Bar.TabIndex = 0
        Me.PictureBox_Bar.TabStop = False
        '
        'Picture_BoxNegative
        '
        Me.Picture_BoxNegative.Image = Global.Tim_s_OWON_Meter_UI.My.Resources.Resources.Negative
        Me.Picture_BoxNegative.Location = New System.Drawing.Point(0, 202)
        Me.Picture_BoxNegative.Name = "Picture_BoxNegative"
        Me.Picture_BoxNegative.Size = New System.Drawing.Size(30, 35)
        Me.Picture_BoxNegative.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Picture_BoxNegative.TabIndex = 43
        Me.Picture_BoxNegative.TabStop = False
        Me.Picture_BoxNegative.Visible = False
        '
        'Label_RPM
        '
        Me.Label_RPM.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_RPM.Location = New System.Drawing.Point(439, 86)
        Me.Label_RPM.Name = "Label_RPM"
        Me.Label_RPM.Size = New System.Drawing.Size(60, 22)
        Me.Label_RPM.TabIndex = 42
        Me.Label_RPM.Text = "RPM"
        Me.Label_RPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_RPM.Visible = False
        '
        'PictureBox_BarFixed
        '
        Me.PictureBox_BarFixed.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_BarFixed.Image = Global.Tim_s_OWON_Meter_UI.My.Resources.Resources.Bar_Values1
        Me.PictureBox_BarFixed.Location = New System.Drawing.Point(30, 246)
        Me.PictureBox_BarFixed.Name = "PictureBox_BarFixed"
        Me.PictureBox_BarFixed.Size = New System.Drawing.Size(467, 20)
        Me.PictureBox_BarFixed.TabIndex = 1
        Me.PictureBox_BarFixed.TabStop = False
        '
        'Label_Volts
        '
        Me.Label_Volts.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Volts.Location = New System.Drawing.Point(405, 158)
        Me.Label_Volts.Name = "Label_Volts"
        Me.Label_Volts.Size = New System.Drawing.Size(50, 22)
        Me.Label_Volts.TabIndex = 24
        Me.Label_Volts.Text = "mV"
        Me.Label_Volts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_ACDC
        '
        Me.Label_ACDC.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ACDC.Location = New System.Drawing.Point(10, 158)
        Me.Label_ACDC.Name = "Label_ACDC"
        Me.Label_ACDC.Size = New System.Drawing.Size(45, 22)
        Me.Label_ACDC.TabIndex = 23
        Me.Label_ACDC.Text = "DC"
        Me.Label_ACDC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(10, 50)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 22)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label_Amps
        '
        Me.Label_Amps.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Amps.Location = New System.Drawing.Point(450, 158)
        Me.Label_Amps.Name = "Label_Amps"
        Me.Label_Amps.Size = New System.Drawing.Size(50, 22)
        Me.Label_Amps.TabIndex = 26
        Me.Label_Amps.Text = "mA"
        Me.Label_Amps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Hz
        '
        Me.Label_Hz.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Hz.Location = New System.Drawing.Point(451, 122)
        Me.Label_Hz.Name = "Label_Hz"
        Me.Label_Hz.Size = New System.Drawing.Size(50, 22)
        Me.Label_Hz.TabIndex = 27
        Me.Label_Hz.Text = "Hz"
        Me.Label_Hz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox_Hold
        '
        Me.PictureBox_Hold.Image = CType(resources.GetObject("PictureBox_Hold.Image"), System.Drawing.Image)
        Me.PictureBox_Hold.Location = New System.Drawing.Point(232, 4)
        Me.PictureBox_Hold.Name = "PictureBox_Hold"
        Me.PictureBox_Hold.Size = New System.Drawing.Size(40, 22)
        Me.PictureBox_Hold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Hold.TabIndex = 40
        Me.PictureBox_Hold.TabStop = False
        Me.PictureBox_Hold.Visible = False
        '
        'Label_Ohm
        '
        Me.Label_Ohm.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Ohm.Location = New System.Drawing.Point(405, 122)
        Me.Label_Ohm.Name = "Label_Ohm"
        Me.Label_Ohm.Size = New System.Drawing.Size(50, 22)
        Me.Label_Ohm.TabIndex = 25
        Me.Label_Ohm.Text = "MΩ"
        Me.Label_Ohm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox_Triangle
        '
        Me.PictureBox_Triangle.Image = CType(resources.GetObject("PictureBox_Triangle.Image"), System.Drawing.Image)
        Me.PictureBox_Triangle.Location = New System.Drawing.Point(289, 4)
        Me.PictureBox_Triangle.Name = "PictureBox_Triangle"
        Me.PictureBox_Triangle.Size = New System.Drawing.Size(40, 22)
        Me.PictureBox_Triangle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Triangle.TabIndex = 39
        Me.PictureBox_Triangle.TabStop = False
        Me.PictureBox_Triangle.Visible = False
        '
        'PictureBox_HighV
        '
        Me.PictureBox_HighV.Image = CType(resources.GetObject("PictureBox_HighV.Image"), System.Drawing.Image)
        Me.PictureBox_HighV.Location = New System.Drawing.Point(456, 4)
        Me.PictureBox_HighV.Name = "PictureBox_HighV"
        Me.PictureBox_HighV.Size = New System.Drawing.Size(40, 22)
        Me.PictureBox_HighV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_HighV.TabIndex = 38
        Me.PictureBox_HighV.TabStop = False
        Me.PictureBox_HighV.Visible = False
        '
        'Label_Auto
        '
        Me.Label_Auto.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Auto.Location = New System.Drawing.Point(35, 4)
        Me.Label_Auto.Name = "Label_Auto"
        Me.Label_Auto.Size = New System.Drawing.Size(75, 22)
        Me.Label_Auto.TabIndex = 29
        Me.Label_Auto.Text = "AUTO"
        Me.Label_Auto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox_Speaker
        '
        Me.PictureBox_Speaker.Image = CType(resources.GetObject("PictureBox_Speaker.Image"), System.Drawing.Image)
        Me.PictureBox_Speaker.Location = New System.Drawing.Point(402, 4)
        Me.PictureBox_Speaker.Name = "PictureBox_Speaker"
        Me.PictureBox_Speaker.Size = New System.Drawing.Size(40, 22)
        Me.PictureBox_Speaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Speaker.TabIndex = 37
        Me.PictureBox_Speaker.TabStop = False
        Me.PictureBox_Speaker.Visible = False
        '
        'PictureBox_Diode
        '
        Me.PictureBox_Diode.Image = CType(resources.GetObject("PictureBox_Diode.Image"), System.Drawing.Image)
        Me.PictureBox_Diode.Location = New System.Drawing.Point(345, 4)
        Me.PictureBox_Diode.Name = "PictureBox_Diode"
        Me.PictureBox_Diode.Size = New System.Drawing.Size(40, 22)
        Me.PictureBox_Diode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Diode.TabIndex = 36
        Me.PictureBox_Diode.TabStop = False
        Me.PictureBox_Diode.Visible = False
        '
        'Label_Duty
        '
        Me.Label_Duty.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Duty.Location = New System.Drawing.Point(407, 86)
        Me.Label_Duty.Name = "Label_Duty"
        Me.Label_Duty.Size = New System.Drawing.Size(35, 22)
        Me.Label_Duty.TabIndex = 31
        Me.Label_Duty.Text = "%"
        Me.Label_Duty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Max
        '
        Me.Label_Max.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Max.Location = New System.Drawing.Point(108, 4)
        Me.Label_Max.Name = "Label_Max"
        Me.Label_Max.Size = New System.Drawing.Size(60, 22)
        Me.Label_Max.TabIndex = 32
        Me.Label_Max.Text = "MAX"
        Me.Label_Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Min
        '
        Me.Label_Min.Font = New System.Drawing.Font("Tims_OWON_Meter", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Min.Location = New System.Drawing.Point(167, 4)
        Me.Label_Min.Name = "Label_Min"
        Me.Label_Min.Size = New System.Drawing.Size(60, 22)
        Me.Label_Min.TabIndex = 33
        Me.Label_Min.Text = "MIN"
        Me.Label_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RichTextBox_Negative
        '
        Me.RichTextBox_Negative.BackColor = System.Drawing.Color.Silver
        Me.RichTextBox_Negative.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox_Negative.Font = New System.Drawing.Font("Tims_OWON_Meter", 100.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox_Negative.Location = New System.Drawing.Point(10, 30)
        Me.RichTextBox_Negative.Multiline = False
        Me.RichTextBox_Negative.Name = "RichTextBox_Negative"
        Me.RichTextBox_Negative.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RichTextBox_Negative.Size = New System.Drawing.Size(60, 185)
        Me.RichTextBox_Negative.TabIndex = 0
        Me.RichTextBox_Negative.Text = "-"
        '
        'RichTextBox_MeterValue
        '
        Me.RichTextBox_MeterValue.BackColor = System.Drawing.Color.Silver
        Me.RichTextBox_MeterValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox_MeterValue.Font = New System.Drawing.Font("Tims_OWON_Meter", 120.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox_MeterValue.Location = New System.Drawing.Point(70, 17)
        Me.RichTextBox_MeterValue.Name = "RichTextBox_MeterValue"
        Me.RichTextBox_MeterValue.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RichTextBox_MeterValue.Size = New System.Drawing.Size(340, 185)
        Me.RichTextBox_MeterValue.TabIndex = 1
        Me.RichTextBox_MeterValue.Text = "66.88"
        '
        'Label_BlueTooth
        '
        Me.Label_BlueTooth.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_BlueTooth.Location = New System.Drawing.Point(4, 10)
        Me.Label_BlueTooth.Name = "Label_BlueTooth"
        Me.Label_BlueTooth.Size = New System.Drawing.Size(45, 22)
        Me.Label_BlueTooth.TabIndex = 34
        Me.Label_BlueTooth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_HzDuty
        '
        Me.Button_HzDuty.BackColor = System.Drawing.Color.Gold
        Me.Button_HzDuty.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_HzDuty.Location = New System.Drawing.Point(269, 319)
        Me.Button_HzDuty.Name = "Button_HzDuty"
        Me.Button_HzDuty.Size = New System.Drawing.Size(115, 30)
        Me.Button_HzDuty.TabIndex = 49
        Me.Button_HzDuty.Text = "Hz/Duty"
        Me.Button_HzDuty.UseVisualStyleBackColor = False
        '
        'Button_MaxMin
        '
        Me.Button_MaxMin.BackColor = System.Drawing.Color.Gold
        Me.Button_MaxMin.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_MaxMin.Location = New System.Drawing.Point(400, 319)
        Me.Button_MaxMin.Name = "Button_MaxMin"
        Me.Button_MaxMin.Size = New System.Drawing.Size(115, 30)
        Me.Button_MaxMin.TabIndex = 48
        Me.Button_MaxMin.Text = "Max/Min"
        Me.Button_MaxMin.UseVisualStyleBackColor = False
        '
        'Button_Range
        '
        Me.Button_Range.BackColor = System.Drawing.Color.Gold
        Me.Button_Range.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Range.Location = New System.Drawing.Point(136, 319)
        Me.Button_Range.Name = "Button_Range"
        Me.Button_Range.Size = New System.Drawing.Size(115, 30)
        Me.Button_Range.TabIndex = 47
        Me.Button_Range.Text = "Range"
        Me.Button_Range.UseVisualStyleBackColor = False
        '
        'Button_Select
        '
        Me.Button_Select.BackColor = System.Drawing.Color.Gold
        Me.Button_Select.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Select.Location = New System.Drawing.Point(5, 319)
        Me.Button_Select.Name = "Button_Select"
        Me.Button_Select.Size = New System.Drawing.Size(115, 30)
        Me.Button_Select.TabIndex = 46
        Me.Button_Select.Text = "Select"
        Me.Button_Select.UseVisualStyleBackColor = False
        '
        'Button_Send
        '
        Me.Button_Send.ForeColor = System.Drawing.Color.Black
        Me.Button_Send.Location = New System.Drawing.Point(355, 15)
        Me.Button_Send.Name = "Button_Send"
        Me.Button_Send.Size = New System.Drawing.Size(80, 30)
        Me.Button_Send.TabIndex = 22
        Me.Button_Send.Text = "Send"
        Me.Button_Send.UseVisualStyleBackColor = True
        '
        'GroupBox_ShellOutput
        '
        Me.GroupBox_ShellOutput.Controls.Add(Me.RichTextBox_ShellOutput)
        Me.GroupBox_ShellOutput.ForeColor = System.Drawing.Color.Silver
        Me.GroupBox_ShellOutput.Location = New System.Drawing.Point(535, 50)
        Me.GroupBox_ShellOutput.Name = "GroupBox_ShellOutput"
        Me.GroupBox_ShellOutput.Size = New System.Drawing.Size(440, 190)
        Me.GroupBox_ShellOutput.TabIndex = 23
        Me.GroupBox_ShellOutput.TabStop = False
        Me.GroupBox_ShellOutput.Text = "Shell Output"
        '
        'GroupBox_ShellPath
        '
        Me.GroupBox_ShellPath.Controls.Add(Me.TextBox_Shell_Path)
        Me.GroupBox_ShellPath.ForeColor = System.Drawing.Color.Silver
        Me.GroupBox_ShellPath.Location = New System.Drawing.Point(535, 2)
        Me.GroupBox_ShellPath.Name = "GroupBox_ShellPath"
        Me.GroupBox_ShellPath.Size = New System.Drawing.Size(440, 45)
        Me.GroupBox_ShellPath.TabIndex = 24
        Me.GroupBox_ShellPath.TabStop = False
        Me.GroupBox_ShellPath.Text = "Shell Path"
        '
        'TextBox_Shell_Path
        '
        Me.TextBox_Shell_Path.BackColor = System.Drawing.Color.Silver
        Me.TextBox_Shell_Path.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "TextBox_Shell_Path_Text", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBox_Shell_Path.Location = New System.Drawing.Point(5, 15)
        Me.TextBox_Shell_Path.Name = "TextBox_Shell_Path"
        Me.TextBox_Shell_Path.Size = New System.Drawing.Size(430, 23)
        Me.TextBox_Shell_Path.TabIndex = 19
        Me.TextBox_Shell_Path.Text = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.TextBox_Shell_Path_Text
        Me.TextBox_Shell_Path.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_Status
        '
        Me.GroupBox_Status.Controls.Add(Me.RichTextBox_ErrorStream)
        Me.GroupBox_Status.ForeColor = System.Drawing.Color.Silver
        Me.GroupBox_Status.Location = New System.Drawing.Point(535, 242)
        Me.GroupBox_Status.Name = "GroupBox_Status"
        Me.GroupBox_Status.Size = New System.Drawing.Size(440, 130)
        Me.GroupBox_Status.TabIndex = 25
        Me.GroupBox_Status.TabStop = False
        Me.GroupBox_Status.Text = "Status"
        '
        'GroupBox_CommandInput
        '
        Me.GroupBox_CommandInput.Controls.Add(Me.RichTextBox_Input)
        Me.GroupBox_CommandInput.Controls.Add(Me.Button_Send)
        Me.GroupBox_CommandInput.ForeColor = System.Drawing.Color.Silver
        Me.GroupBox_CommandInput.Location = New System.Drawing.Point(535, 375)
        Me.GroupBox_CommandInput.Name = "GroupBox_CommandInput"
        Me.GroupBox_CommandInput.Size = New System.Drawing.Size(440, 52)
        Me.GroupBox_CommandInput.TabIndex = 26
        Me.GroupBox_CommandInput.TabStop = False
        Me.GroupBox_CommandInput.Text = "Command Input"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(2, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 28)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Digital Multimeter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(395, 287)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 28)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "True RMS"
        '
        'Button_BackLight
        '
        Me.Button_BackLight.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_BackLight.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_BackLight.Image = CType(resources.GetObject("Button_BackLight.Image"), System.Drawing.Image)
        Me.Button_BackLight.Location = New System.Drawing.Point(5, 354)
        Me.Button_BackLight.Name = "Button_BackLight"
        Me.Button_BackLight.Size = New System.Drawing.Size(50, 40)
        Me.Button_BackLight.TabIndex = 43
        Me.Button_BackLight.UseVisualStyleBackColor = False
        '
        'Button_Relative
        '
        Me.Button_Relative.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_Relative.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Relative.Image = CType(resources.GetObject("Button_Relative.Image"), System.Drawing.Image)
        Me.Button_Relative.Location = New System.Drawing.Point(410, 354)
        Me.Button_Relative.Name = "Button_Relative"
        Me.Button_Relative.Size = New System.Drawing.Size(50, 40)
        Me.Button_Relative.TabIndex = 45
        Me.Button_Relative.UseVisualStyleBackColor = False
        '
        'Button_Bluetooth
        '
        Me.Button_Bluetooth.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_Bluetooth.Enabled = False
        Me.Button_Bluetooth.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Bluetooth.Image = CType(resources.GetObject("Button_Bluetooth.Image"), System.Drawing.Image)
        Me.Button_Bluetooth.Location = New System.Drawing.Point(465, 354)
        Me.Button_Bluetooth.Name = "Button_Bluetooth"
        Me.Button_Bluetooth.Size = New System.Drawing.Size(50, 40)
        Me.Button_Bluetooth.TabIndex = 44
        Me.Button_Bluetooth.UseVisualStyleBackColor = False
        '
        'Button_Hold
        '
        Me.Button_Hold.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_Hold.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Hold.Image = CType(resources.GetObject("Button_Hold.Image"), System.Drawing.Image)
        Me.Button_Hold.Location = New System.Drawing.Point(60, 354)
        Me.Button_Hold.Name = "Button_Hold"
        Me.Button_Hold.Size = New System.Drawing.Size(50, 40)
        Me.Button_Hold.TabIndex = 19
        Me.Button_Hold.UseVisualStyleBackColor = False
        '
        'Button_Auto
        '
        Me.Button_Auto.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_Auto.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Auto.ForeColor = System.Drawing.Color.Silver
        Me.Button_Auto.Location = New System.Drawing.Point(210, 354)
        Me.Button_Auto.Name = "Button_Auto"
        Me.Button_Auto.Size = New System.Drawing.Size(100, 35)
        Me.Button_Auto.TabIndex = 52
        Me.Button_Auto.Text = "AUTO"
        Me.Button_Auto.UseVisualStyleBackColor = False
        '
        'Button_Plot
        '
        Me.Button_Plot.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button_Plot.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Plot.ForeColor = System.Drawing.Color.Silver
        Me.Button_Plot.Location = New System.Drawing.Point(210, 394)
        Me.Button_Plot.Name = "Button_Plot"
        Me.Button_Plot.Size = New System.Drawing.Size(100, 35)
        Me.Button_Plot.TabIndex = 53
        Me.Button_Plot.Text = "Plot"
        Me.Button_Plot.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(980, 432)
        Me.Controls.Add(Me.Button_Plot)
        Me.Controls.Add(Me.Button_Auto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button_MaxMin)
        Me.Controls.Add(Me.Button_HzDuty)
        Me.Controls.Add(Me.GroupBox_CommandInput)
        Me.Controls.Add(Me.GroupBox_Status)
        Me.Controls.Add(Me.Button_Range)
        Me.Controls.Add(Me.GroupBox_ShellPath)
        Me.Controls.Add(Me.Button_Select)
        Me.Controls.Add(Me.GroupBox_ShellOutput)
        Me.Controls.Add(Me.Button_BackLight)
        Me.Controls.Add(Me.Button_Relative)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button_Bluetooth)
        Me.Controls.Add(Me.Button_Hold)
        Me.Controls.Add(Me.Button_UI)
        Me.Controls.Add(Me.Button_Connect)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.Tim_s_OWON_Meter_UI.My.MySettings.Default, "Form1_Location", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = Global.Tim_s_OWON_Meter_UI.My.MySettings.Default.Form1_Location
        Me.MaximumSize = New System.Drawing.Size(990, 465)
        Me.MinimumSize = New System.Drawing.Size(534, 465)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tim's OWON Meter UI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture_BoxNegative, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_BarFixed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Hold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Triangle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_HighV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Speaker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Diode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_ShellOutput.ResumeLayout(False)
        Me.GroupBox_ShellPath.ResumeLayout(False)
        Me.GroupBox_ShellPath.PerformLayout()
        Me.GroupBox_Status.ResumeLayout(False)
        Me.GroupBox_CommandInput.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Button_Connect As Button
    Private WithEvents RichTextBox_Input As RichTextBox
    Private WithEvents RichTextBox_ErrorStream As RichTextBox
    Private WithEvents RichTextBox_ShellOutput As RichTextBox
    Friend WithEvents Button_UI As Button
    Friend WithEvents TextBox_Shell_Path As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button_Send As Button
    Friend WithEvents Button_Hold As Button
    Friend WithEvents RichTextBox_MeterValue As RichTextBox
    Friend WithEvents RichTextBox_Negative As RichTextBox
    Friend WithEvents Label_ACDC As Label
    Friend WithEvents Label_Volts As Label
    Friend WithEvents Label_Hz As Label
    Friend WithEvents Label_Amps As Label
    Friend WithEvents Label_Ohm As Label
    Friend WithEvents Label_Temp As Label
    Friend WithEvents Label_Auto As Label
    Friend WithEvents Label_Hfe As Label
    Friend WithEvents Label_Duty As Label
    Friend WithEvents Label_Max As Label
    Friend WithEvents Label_Min As Label
    Friend WithEvents Label_BlueTooth As Label
    Friend WithEvents PictureBox_BarFixed As PictureBox
    Friend WithEvents PictureBox_Bar As PictureBox
    Friend WithEvents PictureBox_Hold As PictureBox
    Friend WithEvents PictureBox_Triangle As PictureBox
    Friend WithEvents PictureBox_HighV As PictureBox
    Friend WithEvents PictureBox_Speaker As PictureBox
    Friend WithEvents PictureBox_Diode As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label_RPM As Label
    Friend WithEvents Button_Relative As Button
    Friend WithEvents Button_Bluetooth As Button
    Friend WithEvents Button_BackLight As Button
    Friend WithEvents GroupBox_ShellOutput As GroupBox
    Friend WithEvents GroupBox_ShellPath As GroupBox
    Friend WithEvents GroupBox_Status As GroupBox
    Friend WithEvents GroupBox_CommandInput As GroupBox
    Friend WithEvents Button_HzDuty As Button
    Friend WithEvents Button_MaxMin As Button
    Friend WithEvents Button_Range As Button
    Friend WithEvents Button_Select As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button_Auto As Button
    Friend WithEvents Picture_BoxNegative As PictureBox
    Friend WithEvents Button_Plot As Button
End Class
