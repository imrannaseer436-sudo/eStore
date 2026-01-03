<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DiscountAssigner
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiscountAssigner))
        Me.TG = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.lblLoad = New System.Windows.Forms.Label()
        Me.pnlHint = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SimpleLine2 = New simpleline.assemblies.simpleLine()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SimpleLine1 = New simpleline.assemblies.simpleLine()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbLableFormat = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.TGTMP = New System.Windows.Forms.DataGridView()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCle = New System.Windows.Forms.Button()
        Me.chkLoadCostPrice = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlRM = New System.Windows.Forms.Panel()
        Me.SimpleLine4 = New simpleline.assemblies.simpleLine()
        Me.SimpleLine3 = New simpleline.assemblies.simpleLine()
        Me.btnHide = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAmt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.cmbMode = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnShowRM = New System.Windows.Forms.Label()
        Me.chkLWR = New System.Windows.Forms.CheckBox()
        Me.chkLESWQ = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkRate = New System.Windows.Forms.CheckBox()
        Me.PnlDisReason = New System.Windows.Forms.Panel()
        Me.CmbReason = New System.Windows.Forms.ComboBox()
        Me.SimpleLine5 = New simpleline.assemblies.simpleLine()
        Me.SimpleLine6 = New simpleline.assemblies.simpleLine()
        Me.BtnHide2 = New System.Windows.Forms.Button()
        Me.BtnApply2 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.BtnReason = New System.Windows.Forms.Button()
        Me.CmbShop = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.chkRateUpdate = New System.Windows.Forms.CheckBox()
        CType(Me.TG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHint.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TGTMP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRM.SuspendLayout()
        Me.PnlDisReason.SuspendLayout()
        Me.SuspendLayout()
        '
        'TG
        '
        Me.TG.AllowUserToAddRows = False
        Me.TG.AllowUserToDeleteRows = False
        Me.TG.AllowUserToResizeColumns = False
        Me.TG.AllowUserToResizeRows = False
        Me.TG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.TG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column9, Me.Column8, Me.Column10, Me.Column17, Me.Column18, Me.Column24, Me.Column25, Me.Column26, Me.Column27})
        Me.TG.Location = New System.Drawing.Point(12, 76)
        Me.TG.Name = "TG"
        Me.TG.RowHeadersVisible = False
        Me.TG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TG.Size = New System.Drawing.Size(753, 350)
        Me.TG.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Sno"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "Code"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Description"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 210
        '
        'Column5
        '
        Me.Column5.HeaderText = "OLD Rate"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 80
        '
        'Column6
        '
        Me.Column6.HeaderText = "Discount"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 60
        '
        'Column7
        '
        Me.Column7.HeaderText = "New Rate"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 80
        '
        'Column9
        '
        Me.Column9.HeaderText = "Copies"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 60
        '
        'Column8
        '
        Me.Column8.HeaderText = ""
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        Me.Column8.Width = 20
        '
        'Column10
        '
        Me.Column10.HeaderText = "ID"
        Me.Column10.Name = "Column10"
        Me.Column10.Visible = False
        '
        'Column17
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column17.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column17.HeaderText = "S.Discount"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 88
        '
        'Column18
        '
        Me.Column18.HeaderText = ""
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Width = 20
        '
        'Column24
        '
        Me.Column24.HeaderText = "product"
        Me.Column24.Name = "Column24"
        Me.Column24.Visible = False
        '
        'Column25
        '
        Me.Column25.HeaderText = "style"
        Me.Column25.Name = "Column25"
        Me.Column25.Visible = False
        '
        'Column26
        '
        Me.Column26.HeaderText = "material"
        Me.Column26.Name = "Column26"
        Me.Column26.Visible = False
        '
        'Column27
        '
        Me.Column27.HeaderText = "color"
        Me.Column27.Name = "Column27"
        Me.Column27.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File Location :"
        '
        'txtFileName
        '
        Me.txtFileName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(7, 28)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(344, 21)
        Me.txtFileName.TabIndex = 0
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(357, 28)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(28, 23)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "...&B"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(546, 28)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(69, 23)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(682, 455)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(77, 23)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Send Label"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'OFD
        '
        Me.OFD.Filter = "Excel Files |*.xlsx;*.xls"
        Me.OFD.Title = "Select Excel File"
        '
        'lblLoad
        '
        Me.lblLoad.BackColor = System.Drawing.Color.Black
        Me.lblLoad.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoad.ForeColor = System.Drawing.Color.Yellow
        Me.lblLoad.Location = New System.Drawing.Point(243, 215)
        Me.lblLoad.Name = "lblLoad"
        Me.lblLoad.Size = New System.Drawing.Size(280, 41)
        Me.lblLoad.TabIndex = 5
        Me.lblLoad.Text = "Loading...!"
        Me.lblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLoad.Visible = False
        '
        'pnlHint
        '
        Me.pnlHint.BackColor = System.Drawing.Color.White
        Me.pnlHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHint.Controls.Add(Me.Panel1)
        Me.pnlHint.Controls.Add(Me.Label6)
        Me.pnlHint.Controls.Add(Me.Label5)
        Me.pnlHint.Controls.Add(Me.btnClose)
        Me.pnlHint.Controls.Add(Me.Label4)
        Me.pnlHint.Controls.Add(Me.SimpleLine2)
        Me.pnlHint.Controls.Add(Me.Label3)
        Me.pnlHint.Controls.Add(Me.SimpleLine1)
        Me.pnlHint.Controls.Add(Me.PictureBox1)
        Me.pnlHint.Controls.Add(Me.Label2)
        Me.pnlHint.Location = New System.Drawing.Point(182, 107)
        Me.pnlHint.Name = "pnlHint"
        Me.pnlHint.Size = New System.Drawing.Size(419, 313)
        Me.pnlHint.TabIndex = 9
        Me.pnlHint.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(120, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(60, 51)
        Me.Panel1.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(22, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(228, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "2. Worksheet name must be Sheet1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(22, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(204, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "1. Excel File should exact format"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(268, 265)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 32)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Close Window"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(354, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 25)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "2"
        '
        'SimpleLine2
        '
        Me.SimpleLine2.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine2.FitToParent = False
        Me.SimpleLine2.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine2.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine2.LineColor = System.Drawing.Color.Black
        Me.SimpleLine2.LineWidth = 1
        Me.SimpleLine2.Location = New System.Drawing.Point(144, 170)
        Me.SimpleLine2.Name = "SimpleLine2"
        Me.SimpleLine2.Size = New System.Drawing.Size(202, 1)
        Me.SimpleLine2.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine2.TabIndex = 4
        Me.SimpleLine2.UseGradient = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(353, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "1"
        '
        'SimpleLine1
        '
        Me.SimpleLine1.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine1.FitToParent = False
        Me.SimpleLine1.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine1.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine1.LineColor = System.Drawing.Color.Black
        Me.SimpleLine1.LineWidth = 1
        Me.SimpleLine1.Location = New System.Drawing.Point(258, 88)
        Me.SimpleLine1.Name = "SimpleLine1"
        Me.SimpleLine1.Size = New System.Drawing.Size(89, 1)
        Me.SimpleLine1.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine1.TabIndex = 2
        Me.SimpleLine1.UseGradient = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(25, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(156, 120)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(107, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Excel Format Help"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 462)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "[F2] - Discount"
        '
        'cmbLableFormat
        '
        Me.cmbLableFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLableFormat.FormattingEnabled = True
        Me.cmbLableFormat.Location = New System.Drawing.Point(519, 486)
        Me.cmbLableFormat.Name = "cmbLableFormat"
        Me.cmbLableFormat.Size = New System.Drawing.Size(160, 22)
        Me.cmbLableFormat.TabIndex = 6
        Me.cmbLableFormat.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(438, 490)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 14)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Lable Format :"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(531, 489)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 14)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Date :"
        Me.Label9.Visible = False
        '
        'txtDate
        '
        Me.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Location = New System.Drawing.Point(572, 487)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(94, 20)
        Me.txtDate.TabIndex = 24
        Me.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDate.Visible = False
        '
        'TGTMP
        '
        Me.TGTMP.AllowUserToAddRows = False
        Me.TGTMP.AllowUserToDeleteRows = False
        Me.TGTMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TGTMP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column23})
        Me.TGTMP.EnableHeadersVisualStyles = False
        Me.TGTMP.Location = New System.Drawing.Point(82, 163)
        Me.TGTMP.Name = "TGTMP"
        Me.TGTMP.ReadOnly = True
        Me.TGTMP.RowHeadersVisible = False
        Me.TGTMP.Size = New System.Drawing.Size(603, 167)
        Me.TGTMP.TabIndex = 8
        Me.TGTMP.Visible = False
        '
        'Column11
        '
        Me.Column11.HeaderText = "code"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "desc"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "oprice"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "disc"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "nprice"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "id"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.HeaderText = "size"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.HeaderText = "product"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'Column21
        '
        Me.Column21.HeaderText = "style"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        '
        'Column22
        '
        Me.Column22.HeaderText = "material"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        '
        'Column23
        '
        Me.Column23.HeaderText = "color"
        Me.Column23.Name = "Column23"
        Me.Column23.ReadOnly = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(258, 462)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "[F9] - Delete Row"
        '
        'btnCle
        '
        Me.btnCle.Location = New System.Drawing.Point(621, 28)
        Me.btnCle.Name = "btnCle"
        Me.btnCle.Size = New System.Drawing.Size(69, 23)
        Me.btnCle.TabIndex = 4
        Me.btnCle.Text = "&Clear"
        Me.btnCle.UseVisualStyleBackColor = True
        '
        'chkLoadCostPrice
        '
        Me.chkLoadCostPrice.AutoSize = True
        Me.chkLoadCostPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLoadCostPrice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkLoadCostPrice.Location = New System.Drawing.Point(94, 8)
        Me.chkLoadCostPrice.Name = "chkLoadCostPrice"
        Me.chkLoadCostPrice.Size = New System.Drawing.Size(112, 17)
        Me.chkLoadCostPrice.TabIndex = 14
        Me.chkLoadCostPrice.Text = "Load Cost Price"
        Me.chkLoadCostPrice.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(168, 462)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "[F3] - Rate"
        '
        'pnlRM
        '
        Me.pnlRM.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlRM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRM.Controls.Add(Me.SimpleLine4)
        Me.pnlRM.Controls.Add(Me.SimpleLine3)
        Me.pnlRM.Controls.Add(Me.btnHide)
        Me.pnlRM.Controls.Add(Me.btnApply)
        Me.pnlRM.Controls.Add(Me.Label15)
        Me.pnlRM.Controls.Add(Me.txtAmt)
        Me.pnlRM.Controls.Add(Me.Label14)
        Me.pnlRM.Controls.Add(Me.cmbType)
        Me.pnlRM.Controls.Add(Me.cmbMode)
        Me.pnlRM.Controls.Add(Me.Label13)
        Me.pnlRM.Controls.Add(Me.Label12)
        Me.pnlRM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlRM.Location = New System.Drawing.Point(225, 173)
        Me.pnlRM.Name = "pnlRM"
        Me.pnlRM.Size = New System.Drawing.Size(332, 180)
        Me.pnlRM.TabIndex = 16
        Me.pnlRM.Visible = False
        '
        'SimpleLine4
        '
        Me.SimpleLine4.Enabled = False
        Me.SimpleLine4.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine4.FitToParent = False
        Me.SimpleLine4.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine4.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine4.LineColor = System.Drawing.Color.Gainsboro
        Me.SimpleLine4.LineWidth = 1
        Me.SimpleLine4.Location = New System.Drawing.Point(19, 106)
        Me.SimpleLine4.Name = "SimpleLine4"
        Me.SimpleLine4.Size = New System.Drawing.Size(293, 1)
        Me.SimpleLine4.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine4.TabIndex = 10
        Me.SimpleLine4.UseGradient = False
        '
        'SimpleLine3
        '
        Me.SimpleLine3.Enabled = False
        Me.SimpleLine3.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine3.FitToParent = False
        Me.SimpleLine3.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine3.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine3.LineColor = System.Drawing.Color.White
        Me.SimpleLine3.LineWidth = 1
        Me.SimpleLine3.Location = New System.Drawing.Point(19, 106)
        Me.SimpleLine3.Name = "SimpleLine3"
        Me.SimpleLine3.Size = New System.Drawing.Size(293, 1)
        Me.SimpleLine3.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine3.TabIndex = 9
        Me.SimpleLine3.UseGradient = False
        '
        'btnHide
        '
        Me.btnHide.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHide.Location = New System.Drawing.Point(168, 129)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(80, 25)
        Me.btnHide.TabIndex = 4
        Me.btnHide.Text = "&Hide"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.Location = New System.Drawing.Point(82, 129)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(80, 25)
        Me.btnApply.TabIndex = 3
        Me.btnApply.Text = "&Update"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(223, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 14)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Amount"
        '
        'txtAmt
        '
        Me.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmt.Location = New System.Drawing.Point(226, 65)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Size = New System.Drawing.Size(87, 22)
        Me.txtAmt.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(106, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 14)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Calc Type"
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Amount", "Percentage"})
        Me.cmbType.Location = New System.Drawing.Point(109, 65)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(99, 22)
        Me.cmbType.TabIndex = 1
        '
        'cmbMode
        '
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.FormattingEnabled = True
        Me.cmbMode.Items.AddRange(New Object() {"Add", "Less"})
        Me.cmbMode.Location = New System.Drawing.Point(20, 65)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(83, 22)
        Me.cmbMode.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 14)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Mode"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(330, 25)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Rate Modifier"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnShowRM
        '
        Me.btnShowRM.AutoSize = True
        Me.btnShowRM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowRM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowRM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnShowRM.Location = New System.Drawing.Point(675, 8)
        Me.btnShowRM.Name = "btnShowRM"
        Me.btnShowRM.Size = New System.Drawing.Size(83, 13)
        Me.btnShowRM.TabIndex = 17
        Me.btnShowRM.Text = "Rate Modifier"
        '
        'chkLWR
        '
        Me.chkLWR.AutoSize = True
        Me.chkLWR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLWR.Location = New System.Drawing.Point(212, 8)
        Me.chkLWR.Name = "chkLWR"
        Me.chkLWR.Size = New System.Drawing.Size(140, 17)
        Me.chkLWR.TabIndex = 18
        Me.chkLWR.Text = "Load With Round Off"
        Me.chkLWR.UseVisualStyleBackColor = True
        '
        'chkLESWQ
        '
        Me.chkLESWQ.AutoSize = True
        Me.chkLESWQ.Location = New System.Drawing.Point(12, 52)
        Me.chkLESWQ.Name = "chkLESWQ"
        Me.chkLESWQ.Size = New System.Drawing.Size(177, 18)
        Me.chkLESWQ.TabIndex = 19
        Me.chkLESWQ.Text = "Load Excel Sheet With Quantity"
        Me.chkLESWQ.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Purple
        Me.Label16.Location = New System.Drawing.Point(28, 492)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 13)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "[F6] - Yes  [F7] - No"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(168, 492)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(174, 13)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "[F8] - Show Discount Varation"
        '
        'chkRate
        '
        Me.chkRate.AutoSize = True
        Me.chkRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkRate.Location = New System.Drawing.Point(396, 458)
        Me.chkRate.Name = "chkRate"
        Me.chkRate.Size = New System.Drawing.Size(196, 17)
        Me.chkRate.TabIndex = 22
        Me.chkRate.Text = "Less Rate Instead Percentage"
        Me.chkRate.UseVisualStyleBackColor = True
        '
        'PnlDisReason
        '
        Me.PnlDisReason.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnlDisReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlDisReason.Controls.Add(Me.CmbReason)
        Me.PnlDisReason.Controls.Add(Me.SimpleLine5)
        Me.PnlDisReason.Controls.Add(Me.SimpleLine6)
        Me.PnlDisReason.Controls.Add(Me.BtnHide2)
        Me.PnlDisReason.Controls.Add(Me.BtnApply2)
        Me.PnlDisReason.Controls.Add(Me.Label20)
        Me.PnlDisReason.Controls.Add(Me.Label21)
        Me.PnlDisReason.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDisReason.Location = New System.Drawing.Point(225, 173)
        Me.PnlDisReason.Name = "PnlDisReason"
        Me.PnlDisReason.Size = New System.Drawing.Size(332, 180)
        Me.PnlDisReason.TabIndex = 23
        Me.PnlDisReason.Visible = False
        '
        'CmbReason
        '
        Me.CmbReason.FormattingEnabled = True
        Me.CmbReason.Location = New System.Drawing.Point(20, 66)
        Me.CmbReason.Name = "CmbReason"
        Me.CmbReason.Size = New System.Drawing.Size(292, 22)
        Me.CmbReason.TabIndex = 11
        '
        'SimpleLine5
        '
        Me.SimpleLine5.Enabled = False
        Me.SimpleLine5.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine5.FitToParent = False
        Me.SimpleLine5.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine5.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine5.LineColor = System.Drawing.Color.Gainsboro
        Me.SimpleLine5.LineWidth = 1
        Me.SimpleLine5.Location = New System.Drawing.Point(19, 106)
        Me.SimpleLine5.Name = "SimpleLine5"
        Me.SimpleLine5.Size = New System.Drawing.Size(293, 1)
        Me.SimpleLine5.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine5.TabIndex = 10
        Me.SimpleLine5.UseGradient = False
        '
        'SimpleLine6
        '
        Me.SimpleLine6.Enabled = False
        Me.SimpleLine6.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine6.FitToParent = False
        Me.SimpleLine6.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine6.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine6.LineColor = System.Drawing.Color.White
        Me.SimpleLine6.LineWidth = 1
        Me.SimpleLine6.Location = New System.Drawing.Point(19, 106)
        Me.SimpleLine6.Name = "SimpleLine6"
        Me.SimpleLine6.Size = New System.Drawing.Size(293, 1)
        Me.SimpleLine6.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine6.TabIndex = 9
        Me.SimpleLine6.UseGradient = False
        '
        'BtnHide2
        '
        Me.BtnHide2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHide2.Location = New System.Drawing.Point(168, 129)
        Me.BtnHide2.Name = "BtnHide2"
        Me.BtnHide2.Size = New System.Drawing.Size(80, 25)
        Me.BtnHide2.TabIndex = 4
        Me.BtnHide2.Text = "&Hide"
        Me.BtnHide2.UseVisualStyleBackColor = True
        '
        'BtnApply2
        '
        Me.BtnApply2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApply2.Location = New System.Drawing.Point(82, 129)
        Me.BtnApply2.Name = "BtnApply2"
        Me.BtnApply2.Size = New System.Drawing.Size(80, 25)
        Me.BtnApply2.TabIndex = 3
        Me.BtnApply2.Text = "&Update"
        Me.BtnApply2.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(17, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 14)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Reason"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(0, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(330, 25)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Discount Reason "
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnReason
        '
        Me.BtnReason.Location = New System.Drawing.Point(696, 28)
        Me.BtnReason.Name = "BtnReason"
        Me.BtnReason.Size = New System.Drawing.Size(69, 23)
        Me.BtnReason.TabIndex = 5
        Me.BtnReason.Text = "&Reason"
        Me.BtnReason.UseVisualStyleBackColor = True
        '
        'CmbShop
        '
        Me.CmbShop.FormattingEnabled = True
        Me.CmbShop.Location = New System.Drawing.Point(391, 27)
        Me.CmbShop.Name = "CmbShop"
        Me.CmbShop.Size = New System.Drawing.Size(149, 22)
        Me.CmbShop.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(391, 10)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 14)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Shop"
        '
        'chkRateUpdate
        '
        Me.chkRateUpdate.AutoSize = True
        Me.chkRateUpdate.Location = New System.Drawing.Point(195, 52)
        Me.chkRateUpdate.Name = "chkRateUpdate"
        Me.chkRateUpdate.Size = New System.Drawing.Size(75, 18)
        Me.chkRateUpdate.TabIndex = 27
        Me.chkRateUpdate.Text = "Load Rate"
        Me.chkRateUpdate.UseVisualStyleBackColor = True
        '
        'DiscountAssigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 526)
        Me.Controls.Add(Me.chkRateUpdate)
        Me.Controls.Add(Me.PnlDisReason)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CmbShop)
        Me.Controls.Add(Me.BtnReason)
        Me.Controls.Add(Me.chkRate)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.chkLESWQ)
        Me.Controls.Add(Me.chkLWR)
        Me.Controls.Add(Me.btnShowRM)
        Me.Controls.Add(Me.pnlRM)
        Me.Controls.Add(Me.pnlHint)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.chkLoadCostPrice)
        Me.Controls.Add(Me.btnCle)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TGTMP)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbLableFormat)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblLoad)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TG)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "DiscountAssigner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Discount Assigner"
        CType(Me.TG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHint.ResumeLayout(False)
        Me.pnlHint.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TGTMP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRM.ResumeLayout(False)
        Me.pnlRM.PerformLayout()
        Me.PnlDisReason.ResumeLayout(False)
        Me.PnlDisReason.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TG As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblLoad As System.Windows.Forms.Label
    Friend WithEvents pnlHint As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SimpleLine2 As simpleline.assemblies.simpleLine
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SimpleLine1 As simpleline.assemblies.simpleLine
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbLableFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents TGTMP As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCle As System.Windows.Forms.Button
    Friend WithEvents chkLoadCostPrice As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents pnlRM As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents txtAmt As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents cmbMode As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents SimpleLine3 As simpleline.assemblies.simpleLine
    Friend WithEvents btnHide As Button
    Friend WithEvents btnShowRM As Label
    Friend WithEvents chkLWR As CheckBox
    Friend WithEvents SimpleLine4 As simpleline.assemblies.simpleLine
    Friend WithEvents chkLESWQ As CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkRate As System.Windows.Forms.CheckBox
    Friend WithEvents PnlDisReason As Panel
    Friend WithEvents SimpleLine5 As simpleline.assemblies.simpleLine
    Friend WithEvents SimpleLine6 As simpleline.assemblies.simpleLine
    Friend WithEvents BtnHide2 As Button
    Friend WithEvents BtnApply2 As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents BtnReason As Button
    Friend WithEvents CmbReason As ComboBox
    Friend WithEvents CmbShop As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column20 As DataGridViewTextBoxColumn
    Friend WithEvents Column21 As DataGridViewTextBoxColumn
    Friend WithEvents Column22 As DataGridViewTextBoxColumn
    Friend WithEvents Column23 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column24 As DataGridViewTextBoxColumn
    Friend WithEvents Column25 As DataGridViewTextBoxColumn
    Friend WithEvents Column26 As DataGridViewTextBoxColumn
    Friend WithEvents Column27 As DataGridViewTextBoxColumn
    Friend WithEvents chkRateUpdate As CheckBox
    Friend WithEvents Panel1 As Panel
End Class
