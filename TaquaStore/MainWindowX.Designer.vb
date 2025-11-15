<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindowX
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindowX))
        Me.MenuList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tabMain = New Dotnetrix.Controls.TabControlEX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDayEnd = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnUser = New System.Windows.Forms.Label()
        Me.btnSignOut = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblShopName = New System.Windows.Forms.Label()
        Me.btnSettings = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImportToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Label()
        Me.pnlQV = New System.Windows.Forms.Panel()
        Me.btnColorUpdater = New System.Windows.Forms.Button()
        Me.btnColorRegister = New System.Windows.Forms.Button()
        Me.btnCodeConvertor = New System.Windows.Forms.Button()
        Me.btnAttributes = New System.Windows.Forms.Button()
        Me.btnCodeFinder = New System.Windows.Forms.Button()
        Me.btnCodeReader = New System.Windows.Forms.Button()
        Me.btnHideMe = New System.Windows.Forms.Button()
        Me.btnVendor = New System.Windows.Forms.Button()
        Me.btnDayEnd2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlReports = New System.Windows.Forms.Panel()
        Me.MnuDebitReport = New System.Windows.Forms.Button()
        Me.MnuStockReportIW = New System.Windows.Forms.Button()
        Me.MnuVendorRpt = New System.Windows.Forms.Button()
        Me.mnuStockReport = New System.Windows.Forms.Button()
        Me.mnuProductSearch = New System.Windows.Forms.Button()
        Me.mnuPurchaseReport = New System.Windows.Forms.Button()
        Me.mnuDueReport = New System.Windows.Forms.Button()
        Me.mnuPendingReport = New System.Windows.Forms.Button()
        Me.mnuHideReports = New System.Windows.Forms.Button()
        Me.mnuSalesReport = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCommission = New System.Windows.Forms.Button()
        CType(Me.MenuList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlQV.SuspendLayout()
        Me.pnlReports.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuList
        '
        Me.MenuList.AllowUserToAddRows = False
        Me.MenuList.AllowUserToDeleteRows = False
        Me.MenuList.AllowUserToResizeColumns = False
        Me.MenuList.AllowUserToResizeRows = False
        Me.MenuList.BackgroundColor = System.Drawing.Color.Black
        Me.MenuList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MenuList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.MenuList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.MenuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MenuList.ColumnHeadersVisible = False
        Me.MenuList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column4, Me.Column2, Me.Column3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.YellowGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MenuList.DefaultCellStyle = DataGridViewCellStyle2
        Me.MenuList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuList.EnableHeadersVisualStyles = False
        Me.MenuList.GridColor = System.Drawing.Color.Black
        Me.MenuList.Location = New System.Drawing.Point(3, 53)
        Me.MenuList.MultiSelect = False
        Me.MenuList.Name = "MenuList"
        Me.MenuList.ReadOnly = True
        Me.MenuList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.MenuList.RowHeadersVisible = False
        Me.MenuList.RowTemplate.Height = 35
        Me.MenuList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.MenuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MenuList.Size = New System.Drawing.Size(239, 455)
        Me.MenuList.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "MenuID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = ""
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 5
        '
        'Column4
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Symbol", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkGray
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column4.HeaderText = "Icon"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 40
        '
        'Column2
        '
        Me.Column2.HeaderText = "Menu Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 194
        '
        'Column3
        '
        Me.Column3.HeaderText = "HeadID"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(239, 44)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Symbol", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 40)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(46, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "eStore"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1033, 511)
        Me.SplitContainer1.SplitterDistance = 245
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.MenuList, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(245, 511)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tabMain
        '
        Me.tabMain.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab
        Me.tabMain.BackColor = System.Drawing.SystemColors.Control
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.FlatBorderColor = System.Drawing.SystemColors.Control
        Me.tabMain.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabMain.Location = New System.Drawing.Point(0, 36)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedTabColor = System.Drawing.SystemColors.Control
        Me.tabMain.Size = New System.Drawing.Size(787, 475)
        Me.tabMain.TabIndex = 1
        Me.tabMain.UseVisualStyles = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.btnDayEnd, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnUser, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSignOut, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblShopName, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSettings, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSearch, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(787, 36)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'btnDayEnd
        '
        Me.btnDayEnd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDayEnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDayEnd.FlatAppearance.BorderSize = 0
        Me.btnDayEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDayEnd.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDayEnd.ForeColor = System.Drawing.Color.White
        Me.btnDayEnd.Location = New System.Drawing.Point(676, 6)
        Me.btnDayEnd.Name = "btnDayEnd"
        Me.btnDayEnd.Size = New System.Drawing.Size(108, 23)
        Me.btnDayEnd.TabIndex = 1
        Me.btnDayEnd.Text = "Quick Viewer   "
        Me.btnDayEnd.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(662, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(8, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "▏"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(575, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(8, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "▏"
        '
        'btnUser
        '
        Me.btnUser.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnUser.AutoSize = True
        Me.btnUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUser.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUser.ForeColor = System.Drawing.Color.White
        Me.btnUser.Location = New System.Drawing.Point(361, 10)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(117, 15)
        Me.btnUser.TabIndex = 0
        Me.btnUser.Text = "Welcome, Admin "
        '
        'btnSignOut
        '
        Me.btnSignOut.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSignOut.AutoSize = True
        Me.btnSignOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignOut.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignOut.ForeColor = System.Drawing.Color.White
        Me.btnSignOut.Location = New System.Drawing.Point(498, 10)
        Me.btnSignOut.Name = "btnSignOut"
        Me.btnSignOut.Size = New System.Drawing.Size(71, 15)
        Me.btnSignOut.TabIndex = 1
        Me.btnSignOut.Text = "Sign Out "
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(484, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(8, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "▏"
        '
        'lblShopName
        '
        Me.lblShopName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblShopName.AutoSize = True
        Me.lblShopName.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblShopName.Location = New System.Drawing.Point(3, 9)
        Me.lblShopName.Name = "lblShopName"
        Me.lblShopName.Size = New System.Drawing.Size(0, 18)
        Me.lblShopName.TabIndex = 2
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSettings.AutoSize = True
        Me.btnSettings.ContextMenuStrip = Me.ContextMenuStrip1
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Location = New System.Drawing.Point(589, 10)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(67, 15)
        Me.btnSettings.TabIndex = 0
        Me.btnSettings.Text = "Settings "
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 26)
        '
        'ImportToolToolStripMenuItem
        '
        Me.ImportToolToolStripMenuItem.Name = "ImportToolToolStripMenuItem"
        Me.ImportToolToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ImportToolToolStripMenuItem.Text = "Import Tool"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSearch.AutoSize = True
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSearch.Location = New System.Drawing.Point(281, 10)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(74, 15)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "New Reports"
        '
        'pnlQV
        '
        Me.pnlQV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlQV.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlQV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlQV.Controls.Add(Me.btnCommission)
        Me.pnlQV.Controls.Add(Me.btnColorUpdater)
        Me.pnlQV.Controls.Add(Me.btnColorRegister)
        Me.pnlQV.Controls.Add(Me.btnCodeConvertor)
        Me.pnlQV.Controls.Add(Me.btnAttributes)
        Me.pnlQV.Controls.Add(Me.btnCodeFinder)
        Me.pnlQV.Controls.Add(Me.btnCodeReader)
        Me.pnlQV.Controls.Add(Me.btnHideMe)
        Me.pnlQV.Controls.Add(Me.btnVendor)
        Me.pnlQV.Controls.Add(Me.btnDayEnd2)
        Me.pnlQV.Controls.Add(Me.Label3)
        Me.pnlQV.Location = New System.Drawing.Point(800, 40)
        Me.pnlQV.Name = "pnlQV"
        Me.pnlQV.Size = New System.Drawing.Size(230, 440)
        Me.pnlQV.TabIndex = 3
        Me.pnlQV.Visible = False
        '
        'btnColorUpdater
        '
        Me.btnColorUpdater.BackColor = System.Drawing.Color.White
        Me.btnColorUpdater.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnColorUpdater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorUpdater.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.btnColorUpdater.ForeColor = System.Drawing.Color.Black
        Me.btnColorUpdater.Location = New System.Drawing.Point(10, 313)
        Me.btnColorUpdater.Name = "btnColorUpdater"
        Me.btnColorUpdater.Size = New System.Drawing.Size(209, 33)
        Me.btnColorUpdater.TabIndex = 7
        Me.btnColorUpdater.Text = "Color Updater"
        Me.btnColorUpdater.UseVisualStyleBackColor = False
        '
        'btnColorRegister
        '
        Me.btnColorRegister.BackColor = System.Drawing.Color.White
        Me.btnColorRegister.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnColorRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorRegister.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.btnColorRegister.ForeColor = System.Drawing.Color.Black
        Me.btnColorRegister.Location = New System.Drawing.Point(10, 275)
        Me.btnColorRegister.Name = "btnColorRegister"
        Me.btnColorRegister.Size = New System.Drawing.Size(209, 33)
        Me.btnColorRegister.TabIndex = 6
        Me.btnColorRegister.Text = "Color Register"
        Me.btnColorRegister.UseVisualStyleBackColor = False
        '
        'btnCodeConvertor
        '
        Me.btnCodeConvertor.BackColor = System.Drawing.Color.White
        Me.btnCodeConvertor.Enabled = False
        Me.btnCodeConvertor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCodeConvertor.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.btnCodeConvertor.ForeColor = System.Drawing.Color.Black
        Me.btnCodeConvertor.Location = New System.Drawing.Point(10, 237)
        Me.btnCodeConvertor.Name = "btnCodeConvertor"
        Me.btnCodeConvertor.Size = New System.Drawing.Size(209, 33)
        Me.btnCodeConvertor.TabIndex = 5
        Me.btnCodeConvertor.Text = "Code C&onvertor"
        Me.btnCodeConvertor.UseVisualStyleBackColor = False
        '
        'btnAttributes
        '
        Me.btnAttributes.BackColor = System.Drawing.Color.White
        Me.btnAttributes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAttributes.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.btnAttributes.ForeColor = System.Drawing.Color.Black
        Me.btnAttributes.Location = New System.Drawing.Point(10, 199)
        Me.btnAttributes.Name = "btnAttributes"
        Me.btnAttributes.Size = New System.Drawing.Size(209, 33)
        Me.btnAttributes.TabIndex = 4
        Me.btnAttributes.Text = "&Attributes"
        Me.btnAttributes.UseVisualStyleBackColor = False
        '
        'btnCodeFinder
        '
        Me.btnCodeFinder.BackColor = System.Drawing.Color.White
        Me.btnCodeFinder.Enabled = False
        Me.btnCodeFinder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCodeFinder.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodeFinder.ForeColor = System.Drawing.Color.Black
        Me.btnCodeFinder.Location = New System.Drawing.Point(10, 161)
        Me.btnCodeFinder.Name = "btnCodeFinder"
        Me.btnCodeFinder.Size = New System.Drawing.Size(209, 33)
        Me.btnCodeFinder.TabIndex = 3
        Me.btnCodeFinder.Text = "Code &Finder"
        Me.btnCodeFinder.UseVisualStyleBackColor = False
        '
        'btnCodeReader
        '
        Me.btnCodeReader.BackColor = System.Drawing.Color.White
        Me.btnCodeReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCodeReader.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodeReader.ForeColor = System.Drawing.Color.Black
        Me.btnCodeReader.Location = New System.Drawing.Point(10, 123)
        Me.btnCodeReader.Name = "btnCodeReader"
        Me.btnCodeReader.Size = New System.Drawing.Size(209, 33)
        Me.btnCodeReader.TabIndex = 2
        Me.btnCodeReader.Text = "&Code Reader"
        Me.btnCodeReader.UseVisualStyleBackColor = False
        '
        'btnHideMe
        '
        Me.btnHideMe.BackColor = System.Drawing.Color.White
        Me.btnHideMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHideMe.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHideMe.Location = New System.Drawing.Point(10, 389)
        Me.btnHideMe.Name = "btnHideMe"
        Me.btnHideMe.Size = New System.Drawing.Size(209, 33)
        Me.btnHideMe.TabIndex = 8
        Me.btnHideMe.Text = "&Hide Me"
        Me.btnHideMe.UseVisualStyleBackColor = False
        '
        'btnVendor
        '
        Me.btnVendor.BackColor = System.Drawing.Color.White
        Me.btnVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVendor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVendor.Location = New System.Drawing.Point(10, 85)
        Me.btnVendor.Name = "btnVendor"
        Me.btnVendor.Size = New System.Drawing.Size(209, 33)
        Me.btnVendor.TabIndex = 1
        Me.btnVendor.Text = "&Vendor Viewer"
        Me.btnVendor.UseVisualStyleBackColor = False
        '
        'btnDayEnd2
        '
        Me.btnDayEnd2.BackColor = System.Drawing.Color.White
        Me.btnDayEnd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDayEnd2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDayEnd2.Location = New System.Drawing.Point(10, 47)
        Me.btnDayEnd2.Name = "btnDayEnd2"
        Me.btnDayEnd2.Size = New System.Drawing.Size(209, 33)
        Me.btnDayEnd2.TabIndex = 0
        Me.btnDayEnd2.Text = "&Discount Assigner"
        Me.btnDayEnd2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(69, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Quick Viewer"
        '
        'pnlReports
        '
        Me.pnlReports.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlReports.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlReports.Controls.Add(Me.MnuDebitReport)
        Me.pnlReports.Controls.Add(Me.MnuStockReportIW)
        Me.pnlReports.Controls.Add(Me.MnuVendorRpt)
        Me.pnlReports.Controls.Add(Me.mnuStockReport)
        Me.pnlReports.Controls.Add(Me.mnuProductSearch)
        Me.pnlReports.Controls.Add(Me.mnuPurchaseReport)
        Me.pnlReports.Controls.Add(Me.mnuDueReport)
        Me.pnlReports.Controls.Add(Me.mnuPendingReport)
        Me.pnlReports.Controls.Add(Me.mnuHideReports)
        Me.pnlReports.Controls.Add(Me.mnuSalesReport)
        Me.pnlReports.Controls.Add(Me.Label4)
        Me.pnlReports.Location = New System.Drawing.Point(523, 40)
        Me.pnlReports.Name = "pnlReports"
        Me.pnlReports.Size = New System.Drawing.Size(230, 440)
        Me.pnlReports.TabIndex = 5
        Me.pnlReports.Visible = False
        '
        'MnuDebitReport
        '
        Me.MnuDebitReport.BackColor = System.Drawing.Color.White
        Me.MnuDebitReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MnuDebitReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuDebitReport.Location = New System.Drawing.Point(10, 354)
        Me.MnuDebitReport.Name = "MnuDebitReport"
        Me.MnuDebitReport.Size = New System.Drawing.Size(209, 33)
        Me.MnuDebitReport.TabIndex = 14
        Me.MnuDebitReport.Text = "Debit Report"
        Me.MnuDebitReport.UseVisualStyleBackColor = False
        '
        'MnuStockReportIW
        '
        Me.MnuStockReportIW.BackColor = System.Drawing.Color.White
        Me.MnuStockReportIW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MnuStockReportIW.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuStockReportIW.Location = New System.Drawing.Point(10, 315)
        Me.MnuStockReportIW.Name = "MnuStockReportIW"
        Me.MnuStockReportIW.Size = New System.Drawing.Size(209, 33)
        Me.MnuStockReportIW.TabIndex = 13
        Me.MnuStockReportIW.Text = "Stock Report (Inv. Wise)"
        Me.MnuStockReportIW.UseVisualStyleBackColor = False
        '
        'MnuVendorRpt
        '
        Me.MnuVendorRpt.BackColor = System.Drawing.Color.White
        Me.MnuVendorRpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MnuVendorRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuVendorRpt.Location = New System.Drawing.Point(10, 276)
        Me.MnuVendorRpt.Name = "MnuVendorRpt"
        Me.MnuVendorRpt.Size = New System.Drawing.Size(209, 33)
        Me.MnuVendorRpt.TabIndex = 12
        Me.MnuVendorRpt.Text = "&Vendors Report"
        Me.MnuVendorRpt.UseVisualStyleBackColor = False
        '
        'mnuStockReport
        '
        Me.mnuStockReport.BackColor = System.Drawing.Color.White
        Me.mnuStockReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mnuStockReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuStockReport.Location = New System.Drawing.Point(10, 161)
        Me.mnuStockReport.Name = "mnuStockReport"
        Me.mnuStockReport.Size = New System.Drawing.Size(209, 33)
        Me.mnuStockReport.TabIndex = 11
        Me.mnuStockReport.Text = "Stoc&k Report"
        Me.mnuStockReport.UseVisualStyleBackColor = False
        '
        'mnuProductSearch
        '
        Me.mnuProductSearch.BackColor = System.Drawing.Color.White
        Me.mnuProductSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mnuProductSearch.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuProductSearch.Location = New System.Drawing.Point(10, 47)
        Me.mnuProductSearch.Name = "mnuProductSearch"
        Me.mnuProductSearch.Size = New System.Drawing.Size(209, 33)
        Me.mnuProductSearch.TabIndex = 10
        Me.mnuProductSearch.Text = "Product &Search"
        Me.mnuProductSearch.UseVisualStyleBackColor = False
        '
        'mnuPurchaseReport
        '
        Me.mnuPurchaseReport.BackColor = System.Drawing.Color.White
        Me.mnuPurchaseReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mnuPurchaseReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuPurchaseReport.Location = New System.Drawing.Point(10, 123)
        Me.mnuPurchaseReport.Name = "mnuPurchaseReport"
        Me.mnuPurchaseReport.Size = New System.Drawing.Size(209, 33)
        Me.mnuPurchaseReport.TabIndex = 9
        Me.mnuPurchaseReport.Text = "&Purchase Report"
        Me.mnuPurchaseReport.UseVisualStyleBackColor = False
        '
        'mnuDueReport
        '
        Me.mnuDueReport.BackColor = System.Drawing.Color.White
        Me.mnuDueReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mnuDueReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuDueReport.Location = New System.Drawing.Point(10, 237)
        Me.mnuDueReport.Name = "mnuDueReport"
        Me.mnuDueReport.Size = New System.Drawing.Size(209, 33)
        Me.mnuDueReport.TabIndex = 8
        Me.mnuDueReport.Text = "&Due Days Report"
        Me.mnuDueReport.UseVisualStyleBackColor = False
        '
        'mnuPendingReport
        '
        Me.mnuPendingReport.BackColor = System.Drawing.Color.White
        Me.mnuPendingReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mnuPendingReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuPendingReport.Location = New System.Drawing.Point(10, 199)
        Me.mnuPendingReport.Name = "mnuPendingReport"
        Me.mnuPendingReport.Size = New System.Drawing.Size(209, 33)
        Me.mnuPendingReport.TabIndex = 8
        Me.mnuPendingReport.Text = "P&ending Report"
        Me.mnuPendingReport.UseVisualStyleBackColor = False
        '
        'mnuHideReports
        '
        Me.mnuHideReports.BackColor = System.Drawing.Color.White
        Me.mnuHideReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mnuHideReports.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuHideReports.Location = New System.Drawing.Point(10, 393)
        Me.mnuHideReports.Name = "mnuHideReports"
        Me.mnuHideReports.Size = New System.Drawing.Size(209, 33)
        Me.mnuHideReports.TabIndex = 8
        Me.mnuHideReports.Text = "&Hide Me"
        Me.mnuHideReports.UseVisualStyleBackColor = False
        '
        'mnuSalesReport
        '
        Me.mnuSalesReport.BackColor = System.Drawing.Color.White
        Me.mnuSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mnuSalesReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSalesReport.Location = New System.Drawing.Point(10, 85)
        Me.mnuSalesReport.Name = "mnuSalesReport"
        Me.mnuSalesReport.Size = New System.Drawing.Size(209, 33)
        Me.mnuSalesReport.TabIndex = 0
        Me.mnuSalesReport.Text = "&Sales Report - New"
        Me.mnuSalesReport.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(69, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Quick Viewer"
        '
        'btnCommission
        '
        Me.btnCommission.BackColor = System.Drawing.Color.White
        Me.btnCommission.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnCommission.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCommission.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.btnCommission.ForeColor = System.Drawing.Color.Black
        Me.btnCommission.Location = New System.Drawing.Point(10, 351)
        Me.btnCommission.Name = "btnCommission"
        Me.btnCommission.Size = New System.Drawing.Size(209, 33)
        Me.btnCommission.TabIndex = 9
        Me.btnCommission.Text = "Commission Assigner"
        Me.btnCommission.UseVisualStyleBackColor = False
        '
        'MainWindowX
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1033, 511)
        Me.Controls.Add(Me.pnlReports)
        Me.Controls.Add(Me.pnlQV)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainWindowX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "eStore"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlQV.ResumeLayout(False)
        Me.pnlQV.PerformLayout()
        Me.pnlReports.ResumeLayout(False)
        Me.pnlReports.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuList As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabMain As Dotnetrix.Controls.TabControlEX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSettings As System.Windows.Forms.Label
    Friend WithEvents btnUser As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblShopName As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSignOut As System.Windows.Forms.Label
    Friend WithEvents btnDayEnd As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImportToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSearch As System.Windows.Forms.Label
    Friend WithEvents pnlQV As System.Windows.Forms.Panel
    Friend WithEvents btnHideMe As System.Windows.Forms.Button
    Friend WithEvents btnVendor As System.Windows.Forms.Button
    Friend WithEvents btnDayEnd2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCodeReader As System.Windows.Forms.Button
    Friend WithEvents btnCodeFinder As Button
    Friend WithEvents btnAttributes As Button
    Friend WithEvents btnCodeConvertor As Button
    Friend WithEvents btnColorRegister As Button
    Friend WithEvents btnColorUpdater As Button
    Friend WithEvents pnlReports As Panel
    Friend WithEvents mnuHideReports As Button
    Friend WithEvents mnuSalesReport As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents mnuPurchaseReport As Button
    Friend WithEvents mnuProductSearch As Button
    Friend WithEvents mnuStockReport As Button
    Friend WithEvents mnuPendingReport As Button
    Friend WithEvents mnuDueReport As Button
    Friend WithEvents MnuVendorRpt As Button
    Friend WithEvents MnuStockReportIW As Button
    Friend WithEvents MnuDebitReport As Button
    Friend WithEvents btnCommission As Button
End Class
