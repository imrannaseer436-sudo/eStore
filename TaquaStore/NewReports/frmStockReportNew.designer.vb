<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStockReportNew
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
        Me.TG = New Zuby.ADGV.AdvancedDataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.CmbLocation = New System.Windows.Forms.ComboBox()
        Me.chkEZS = New System.Windows.Forms.CheckBox()
        Me.btnResetAttribute = New System.Windows.Forms.Label()
        Me.btnHide = New System.Windows.Forms.Button()
        Me.btnApplyFilter = New System.Windows.Forms.Button()
        Me.SimpleLine3 = New simpleline.assemblies.simpleLine()
        Me.cmbVendor = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SimpleLine1 = New simpleline.assemblies.simpleLine()
        Me.cmbCatalog = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbSleeve = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMts = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbPattern = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbStyle = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbCat = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDept = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.TG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        Me.SuspendLayout()
        '
        'TG
        '
        Me.TG.AllowUserToAddRows = False
        Me.TG.AllowUserToDeleteRows = False
        Me.TG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TG.FilterAndSortEnabled = True
        Me.TG.Location = New System.Drawing.Point(0, 0)
        Me.TG.Name = "TG"
        Me.TG.ReadOnly = True
        Me.TG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TG.Size = New System.Drawing.Size(952, 553)
        Me.TG.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.lblStock)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.btnFilter)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(952, 52)
        Me.Panel1.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Navy
        Me.btnExit.Location = New System.Drawing.Point(875, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(65, 30)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.Color.LightYellow
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.SaddleBrown
        Me.btnExport.Location = New System.Drawing.Point(752, 12)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(117, 30)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.ForeColor = System.Drawing.Color.Maroon
        Me.lblStock.Location = New System.Drawing.Point(81, 18)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(16, 18)
        Me.lblStock.TabIndex = 4
        Me.lblStock.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(21, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 18)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Stock :"
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.BackColor = System.Drawing.Color.MistyRose
        Me.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilter.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.ForeColor = System.Drawing.Color.Maroon
        Me.btnFilter.Location = New System.Drawing.Point(629, 12)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(117, 30)
        Me.btnFilter.TabIndex = 2
        Me.btnFilter.Text = "&Filter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TG)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(952, 553)
        Me.Panel2.TabIndex = 2
        '
        'pnlFilter
        '
        Me.pnlFilter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilter.Controls.Add(Me.cmbType)
        Me.pnlFilter.Controls.Add(Me.Label8)
        Me.pnlFilter.Controls.Add(Me.CmbLocation)
        Me.pnlFilter.Controls.Add(Me.chkEZS)
        Me.pnlFilter.Controls.Add(Me.btnResetAttribute)
        Me.pnlFilter.Controls.Add(Me.btnHide)
        Me.pnlFilter.Controls.Add(Me.btnApplyFilter)
        Me.pnlFilter.Controls.Add(Me.SimpleLine3)
        Me.pnlFilter.Controls.Add(Me.cmbVendor)
        Me.pnlFilter.Controls.Add(Me.Label15)
        Me.pnlFilter.Controls.Add(Me.Label2)
        Me.pnlFilter.Controls.Add(Me.Label1)
        Me.pnlFilter.Controls.Add(Me.SimpleLine1)
        Me.pnlFilter.Controls.Add(Me.cmbCatalog)
        Me.pnlFilter.Controls.Add(Me.Label14)
        Me.pnlFilter.Controls.Add(Me.cmbBrand)
        Me.pnlFilter.Controls.Add(Me.Label13)
        Me.pnlFilter.Controls.Add(Me.cmbSleeve)
        Me.pnlFilter.Controls.Add(Me.Label12)
        Me.pnlFilter.Controls.Add(Me.cmbMts)
        Me.pnlFilter.Controls.Add(Me.Label7)
        Me.pnlFilter.Controls.Add(Me.cmbPattern)
        Me.pnlFilter.Controls.Add(Me.Label6)
        Me.pnlFilter.Controls.Add(Me.cmbStyle)
        Me.pnlFilter.Controls.Add(Me.Label5)
        Me.pnlFilter.Controls.Add(Me.cmbCat)
        Me.pnlFilter.Controls.Add(Me.Label4)
        Me.pnlFilter.Controls.Add(Me.cmbDept)
        Me.pnlFilter.Controls.Add(Me.Label3)
        Me.pnlFilter.Controls.Add(Me.cmbColor)
        Me.pnlFilter.Controls.Add(Me.Label11)
        Me.pnlFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFilter.Location = New System.Drawing.Point(131, 101)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(691, 440)
        Me.pnlFilter.TabIndex = 3
        '
        'CmbLocation
        '
        Me.CmbLocation.BackColor = System.Drawing.Color.Aquamarine
        Me.CmbLocation.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbLocation.FormattingEnabled = True
        Me.CmbLocation.Location = New System.Drawing.Point(473, 401)
        Me.CmbLocation.Name = "CmbLocation"
        Me.CmbLocation.Size = New System.Drawing.Size(197, 22)
        Me.CmbLocation.TabIndex = 63
        '
        'chkEZS
        '
        Me.chkEZS.AutoSize = True
        Me.chkEZS.Checked = True
        Me.chkEZS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEZS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEZS.ForeColor = System.Drawing.Color.Maroon
        Me.chkEZS.Location = New System.Drawing.Point(17, 403)
        Me.chkEZS.Name = "chkEZS"
        Me.chkEZS.Size = New System.Drawing.Size(147, 20)
        Me.chkEZS.TabIndex = 62
        Me.chkEZS.Text = "Exclude Zero Stock"
        Me.chkEZS.UseVisualStyleBackColor = True
        '
        'btnResetAttribute
        '
        Me.btnResetAttribute.AutoSize = True
        Me.btnResetAttribute.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResetAttribute.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAttribute.ForeColor = System.Drawing.Color.Navy
        Me.btnResetAttribute.Location = New System.Drawing.Point(571, 40)
        Me.btnResetAttribute.Name = "btnResetAttribute"
        Me.btnResetAttribute.Size = New System.Drawing.Size(104, 14)
        Me.btnResetAttribute.TabIndex = 61
        Me.btnResetAttribute.Text = "Reset Attribute"
        '
        'btnHide
        '
        Me.btnHide.BackColor = System.Drawing.Color.Maroon
        Me.btnHide.FlatAppearance.BorderSize = 0
        Me.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHide.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnHide.ForeColor = System.Drawing.Color.White
        Me.btnHide.Location = New System.Drawing.Point(654, -1)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(36, 27)
        Me.btnHide.TabIndex = 60
        Me.btnHide.Text = "r"
        Me.btnHide.UseVisualStyleBackColor = False
        '
        'btnApplyFilter
        '
        Me.btnApplyFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyFilter.Location = New System.Drawing.Point(257, 396)
        Me.btnApplyFilter.Name = "btnApplyFilter"
        Me.btnApplyFilter.Size = New System.Drawing.Size(175, 32)
        Me.btnApplyFilter.TabIndex = 15
        Me.btnApplyFilter.Text = "&Apply Filter"
        Me.btnApplyFilter.UseVisualStyleBackColor = True
        '
        'SimpleLine3
        '
        Me.SimpleLine3.Enabled = False
        Me.SimpleLine3.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine3.FitToParent = False
        Me.SimpleLine3.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine3.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine3.LineColor = System.Drawing.Color.LightGray
        Me.SimpleLine3.LineWidth = 1
        Me.SimpleLine3.Location = New System.Drawing.Point(17, 386)
        Me.SimpleLine3.Name = "SimpleLine3"
        Me.SimpleLine3.Size = New System.Drawing.Size(653, 1)
        Me.SimpleLine3.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine3.TabIndex = 53
        Me.SimpleLine3.UseGradient = False
        '
        'cmbVendor
        '
        Me.cmbVendor.BackColor = System.Drawing.Color.PaleTurquoise
        Me.cmbVendor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendor.FormattingEnabled = True
        Me.cmbVendor.Location = New System.Drawing.Point(353, 297)
        Me.cmbVendor.Name = "cmbVendor"
        Me.cmbVendor.Size = New System.Drawing.Size(317, 22)
        Me.cmbVendor.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(350, 281)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Vendor"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(689, 27)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Search And Filter"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 14)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Attribute Filter"
        '
        'SimpleLine1
        '
        Me.SimpleLine1.Enabled = False
        Me.SimpleLine1.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine1.FitToParent = False
        Me.SimpleLine1.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine1.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine1.LineColor = System.Drawing.Color.LightGray
        Me.SimpleLine1.LineWidth = 1
        Me.SimpleLine1.Location = New System.Drawing.Point(17, 60)
        Me.SimpleLine1.Name = "SimpleLine1"
        Me.SimpleLine1.Size = New System.Drawing.Size(653, 1)
        Me.SimpleLine1.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine1.TabIndex = 42
        Me.SimpleLine1.UseGradient = False
        '
        'cmbCatalog
        '
        Me.cmbCatalog.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmbCatalog.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCatalog.FormattingEnabled = True
        Me.cmbCatalog.Location = New System.Drawing.Point(353, 244)
        Me.cmbCatalog.Name = "cmbCatalog"
        Me.cmbCatalog.Size = New System.Drawing.Size(317, 22)
        Me.cmbCatalog.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(350, 228)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Catalog"
        '
        'cmbBrand
        '
        Me.cmbBrand.BackColor = System.Drawing.Color.Lavender
        Me.cmbBrand.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(353, 192)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(317, 22)
        Me.cmbBrand.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(350, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Brand"
        '
        'cmbSleeve
        '
        Me.cmbSleeve.BackColor = System.Drawing.Color.Thistle
        Me.cmbSleeve.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSleeve.FormattingEnabled = True
        Me.cmbSleeve.Location = New System.Drawing.Point(353, 139)
        Me.cmbSleeve.Name = "cmbSleeve"
        Me.cmbSleeve.Size = New System.Drawing.Size(317, 22)
        Me.cmbSleeve.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(350, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Sleeve"
        '
        'cmbMts
        '
        Me.cmbMts.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmbMts.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMts.FormattingEnabled = True
        Me.cmbMts.Location = New System.Drawing.Point(17, 297)
        Me.cmbMts.Name = "cmbMts"
        Me.cmbMts.Size = New System.Drawing.Size(317, 22)
        Me.cmbMts.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Material"
        '
        'cmbPattern
        '
        Me.cmbPattern.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbPattern.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPattern.FormattingEnabled = True
        Me.cmbPattern.Location = New System.Drawing.Point(17, 244)
        Me.cmbPattern.Name = "cmbPattern"
        Me.cmbPattern.Size = New System.Drawing.Size(317, 22)
        Me.cmbPattern.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Pattern"
        '
        'cmbStyle
        '
        Me.cmbStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStyle.FormattingEnabled = True
        Me.cmbStyle.Location = New System.Drawing.Point(17, 192)
        Me.cmbStyle.Name = "cmbStyle"
        Me.cmbStyle.Size = New System.Drawing.Size(317, 22)
        Me.cmbStyle.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Style"
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbCat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(17, 139)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(317, 22)
        Me.cmbCat.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Category"
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbDept.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(17, 88)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(317, 22)
        Me.cmbDept.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Department"
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.Color.Khaki
        Me.cmbColor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(353, 90)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(317, 22)
        Me.cmbColor.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(350, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Colors"
        '
        'pnlLoading
        '
        Me.pnlLoading.BackColor = System.Drawing.Color.Navy
        Me.pnlLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLoading.Controls.Add(Me.Label18)
        Me.pnlLoading.Location = New System.Drawing.Point(351, 272)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(250, 60)
        Me.pnlLoading.TabIndex = 4
        Me.pnlLoading.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Yellow
        Me.Label18.Location = New System.Drawing.Point(29, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(191, 18)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Loading Data, Please Wait"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.Thistle
        Me.cmbType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(17, 346)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(317, 22)
        Me.cmbType.TabIndex = 64
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 329)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Type"
        '
        'frmStockReportNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 605)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "frmStockReportNew"
        Me.Tag = "frmStockReportNew"
        Me.Text = "Stock Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.pnlLoading.ResumeLayout(False)
        Me.pnlLoading.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TG As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnFilter As Button
    Friend WithEvents pnlFilter As Panel
    Friend WithEvents btnResetAttribute As Label
    Friend WithEvents btnHide As Button
    Friend WithEvents btnApplyFilter As Button
    Friend WithEvents SimpleLine3 As simpleline.assemblies.simpleLine
    Friend WithEvents cmbVendor As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SimpleLine1 As simpleline.assemblies.simpleLine
    Friend WithEvents cmbCatalog As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbBrand As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbSleeve As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbMts As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbPattern As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbStyle As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbCat As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbDept As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbColor As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents pnlLoading As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents lblStock As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents chkEZS As CheckBox
    Friend WithEvents btnExport As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents CmbLocation As ComboBox
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents Label8 As Label
End Class
