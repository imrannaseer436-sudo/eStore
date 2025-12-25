<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductEdit2
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUnits = New System.Windows.Forms.ComboBox()
        Me.cmbVendors = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbHsn = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtCostPrice = New System.Windows.Forms.TextBox()
        Me.txtRetailPrice = New System.Windows.Forms.TextBox()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.isTaxable = New System.Windows.Forms.ComboBox()
        Me.SimpleLine1 = New simpleline.assemblies.simpleLine()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SimpleLine2 = New simpleline.assemblies.simpleLine()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SimpleLine3 = New simpleline.assemblies.simpleLine()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPrint = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtLink = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbSleeve = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbMts = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbPattern = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbStyle = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbCat = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbDept = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.SimpleLine4 = New simpleline.assemblies.simpleLine()
        Me.cmbCatalog = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SimpleLine5 = New simpleline.assemblies.simpleLine()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnReloadCategory = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Units"
        '
        'cmbUnits
        '
        Me.cmbUnits.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnits.FormattingEnabled = True
        Me.cmbUnits.Location = New System.Drawing.Point(14, 97)
        Me.cmbUnits.Name = "cmbUnits"
        Me.cmbUnits.Size = New System.Drawing.Size(100, 21)
        Me.cmbUnits.TabIndex = 3
        '
        'cmbVendors
        '
        Me.cmbVendors.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendors.FormattingEnabled = True
        Me.cmbVendors.Location = New System.Drawing.Point(120, 97)
        Me.cmbVendors.Name = "cmbVendors"
        Me.cmbVendors.Size = New System.Drawing.Size(310, 21)
        Me.cmbVendors.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vendors"
        '
        'cmbHsn
        '
        Me.cmbHsn.Enabled = False
        Me.cmbHsn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHsn.FormattingEnabled = True
        Me.cmbHsn.Location = New System.Drawing.Point(366, 169)
        Me.cmbHsn.Name = "cmbHsn"
        Me.cmbHsn.Size = New System.Drawing.Size(64, 21)
        Me.cmbHsn.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(363, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "HSN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(117, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Description"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(293, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Stitched ?"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Cost Price"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(117, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Retail Price"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(223, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Discount"
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(14, 54)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 21)
        Me.txtCode.TabIndex = 1
        Me.txtCode.Tag = "1"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(120, 54)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(310, 21)
        Me.txtName.TabIndex = 2
        '
        'txtCostPrice
        '
        Me.txtCostPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostPrice.Location = New System.Drawing.Point(14, 169)
        Me.txtCostPrice.Name = "txtCostPrice"
        Me.txtCostPrice.Size = New System.Drawing.Size(100, 21)
        Me.txtCostPrice.TabIndex = 5
        '
        'txtRetailPrice
        '
        Me.txtRetailPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetailPrice.Location = New System.Drawing.Point(120, 169)
        Me.txtRetailPrice.Name = "txtRetailPrice"
        Me.txtRetailPrice.Size = New System.Drawing.Size(100, 21)
        Me.txtRetailPrice.TabIndex = 6
        '
        'txtDiscount
        '
        Me.txtDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscount.Location = New System.Drawing.Point(226, 169)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(64, 21)
        Me.txtDiscount.TabIndex = 7
        '
        'isTaxable
        '
        Me.isTaxable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.isTaxable.FormattingEnabled = True
        Me.isTaxable.Items.AddRange(New Object() {"No", "Yes"})
        Me.isTaxable.Location = New System.Drawing.Point(296, 169)
        Me.isTaxable.Name = "isTaxable"
        Me.isTaxable.Size = New System.Drawing.Size(64, 21)
        Me.isTaxable.TabIndex = 8
        '
        'SimpleLine1
        '
        Me.SimpleLine1.Enabled = False
        Me.SimpleLine1.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine1.FitToParent = False
        Me.SimpleLine1.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine1.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine1.LineColor = System.Drawing.Color.Gainsboro
        Me.SimpleLine1.LineWidth = 1
        Me.SimpleLine1.Location = New System.Drawing.Point(14, 28)
        Me.SimpleLine1.Name = "SimpleLine1"
        Me.SimpleLine1.Size = New System.Drawing.Size(416, 1)
        Me.SimpleLine1.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine1.TabIndex = 13
        Me.SimpleLine1.UseGradient = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "PRODUCT INFO"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "PRICE INFO"
        '
        'SimpleLine2
        '
        Me.SimpleLine2.Enabled = False
        Me.SimpleLine2.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine2.FitToParent = False
        Me.SimpleLine2.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine2.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine2.LineColor = System.Drawing.Color.Gainsboro
        Me.SimpleLine2.LineWidth = 1
        Me.SimpleLine2.Location = New System.Drawing.Point(14, 143)
        Me.SimpleLine2.Name = "SimpleLine2"
        Me.SimpleLine2.Size = New System.Drawing.Size(416, 1)
        Me.SimpleLine2.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine2.TabIndex = 15
        Me.SimpleLine2.UseGradient = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 199)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "SIZE INFO"
        '
        'SimpleLine3
        '
        Me.SimpleLine3.Enabled = False
        Me.SimpleLine3.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine3.FitToParent = False
        Me.SimpleLine3.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine3.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine3.LineColor = System.Drawing.Color.Gainsboro
        Me.SimpleLine3.LineWidth = 1
        Me.SimpleLine3.Location = New System.Drawing.Point(14, 215)
        Me.SimpleLine3.Name = "SimpleLine3"
        Me.SimpleLine3.Size = New System.Drawing.Size(416, 1)
        Me.SimpleLine3.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine3.TabIndex = 18
        Me.SimpleLine3.UseGradient = False
        '
        'txtSize
        '
        Me.txtSize.Enabled = False
        Me.txtSize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(14, 241)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(100, 21)
        Me.txtSize.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 225)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "O.PluId"
        '
        'txtId
        '
        Me.txtId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(120, 241)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(100, 21)
        Me.txtId.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(117, 225)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Size"
        '
        'txtPrint
        '
        Me.txtPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrint.Location = New System.Drawing.Point(226, 241)
        Me.txtPrint.Name = "txtPrint"
        Me.txtPrint.Size = New System.Drawing.Size(204, 21)
        Me.txtPrint.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(223, 225)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Print Name"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(120, 346)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 25
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtLink
        '
        Me.txtLink.Enabled = False
        Me.txtLink.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLink.Location = New System.Drawing.Point(14, 284)
        Me.txtLink.Name = "txtLink"
        Me.txtLink.Size = New System.Drawing.Size(416, 21)
        Me.txtLink.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 268)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Category Link"
        '
        'cmbSleeve
        '
        Me.cmbSleeve.BackColor = System.Drawing.Color.Thistle
        Me.cmbSleeve.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSleeve.FormattingEnabled = True
        Me.cmbSleeve.Location = New System.Drawing.Point(735, 53)
        Me.cmbSleeve.Name = "cmbSleeve"
        Me.cmbSleeve.Size = New System.Drawing.Size(272, 21)
        Me.cmbSleeve.TabIndex = 20
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(732, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "Sleeve"
        '
        'cmbMts
        '
        Me.cmbMts.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmbMts.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMts.FormattingEnabled = True
        Me.cmbMts.Location = New System.Drawing.Point(448, 234)
        Me.cmbMts.Name = "cmbMts"
        Me.cmbMts.Size = New System.Drawing.Size(272, 21)
        Me.cmbMts.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(445, 218)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Material"
        '
        'cmbPattern
        '
        Me.cmbPattern.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbPattern.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPattern.FormattingEnabled = True
        Me.cmbPattern.Location = New System.Drawing.Point(448, 188)
        Me.cmbPattern.Name = "cmbPattern"
        Me.cmbPattern.Size = New System.Drawing.Size(272, 21)
        Me.cmbPattern.TabIndex = 17
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(445, 172)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 13)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Pattern"
        '
        'cmbStyle
        '
        Me.cmbStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStyle.FormattingEnabled = True
        Me.cmbStyle.Location = New System.Drawing.Point(448, 142)
        Me.cmbStyle.Name = "cmbStyle"
        Me.cmbStyle.Size = New System.Drawing.Size(272, 21)
        Me.cmbStyle.TabIndex = 16
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(445, 126)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "Style"
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbCat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(448, 96)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(272, 21)
        Me.cmbCat.TabIndex = 15
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(445, 81)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "Category"
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbDept.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(448, 54)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(272, 21)
        Me.cmbDept.TabIndex = 14
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(445, 38)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 13)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Department"
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.Color.Khaki
        Me.cmbColor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(448, 283)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(272, 21)
        Me.cmbColor.TabIndex = 19
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(445, 267)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(37, 13)
        Me.Label23.TabIndex = 41
        Me.Label23.Text = "Colors"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(445, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(106, 13)
        Me.Label24.TabIndex = 44
        Me.Label24.Text = "ATTRIBUTES INFO"
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
        Me.SimpleLine4.Location = New System.Drawing.Point(448, 28)
        Me.SimpleLine4.Name = "SimpleLine4"
        Me.SimpleLine4.Size = New System.Drawing.Size(559, 1)
        Me.SimpleLine4.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine4.TabIndex = 43
        Me.SimpleLine4.UseGradient = False
        '
        'cmbCatalog
        '
        Me.cmbCatalog.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmbCatalog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCatalog.FormattingEnabled = True
        Me.cmbCatalog.Location = New System.Drawing.Point(735, 143)
        Me.cmbCatalog.Name = "cmbCatalog"
        Me.cmbCatalog.Size = New System.Drawing.Size(272, 21)
        Me.cmbCatalog.TabIndex = 22
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(732, 127)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 49
        Me.Label26.Text = "Catalog"
        '
        'cmbBrand
        '
        Me.cmbBrand.BackColor = System.Drawing.Color.Lavender
        Me.cmbBrand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(735, 96)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(272, 21)
        Me.cmbBrand.TabIndex = 21
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(732, 81)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(35, 13)
        Me.Label27.TabIndex = 48
        Me.Label27.Text = "Brand"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(14, 346)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 30)
        Me.btnSave.TabIndex = 24
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'SimpleLine5
        '
        Me.SimpleLine5.Enabled = False
        Me.SimpleLine5.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine5.FitToParent = False
        Me.SimpleLine5.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine5.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine5.LineColor = System.Drawing.Color.LightGray
        Me.SimpleLine5.LineWidth = 1
        Me.SimpleLine5.Location = New System.Drawing.Point(14, 333)
        Me.SimpleLine5.Name = "SimpleLine5"
        Me.SimpleLine5.Size = New System.Drawing.Size(993, 1)
        Me.SimpleLine5.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine5.TabIndex = 51
        Me.SimpleLine5.UseGradient = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(11, 317)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 13)
        Me.Label25.TabIndex = 52
        Me.Label25.Text = "OPTIONS"
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(226, 346)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(100, 30)
        Me.btnReset.TabIndex = 53
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmbType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(735, 188)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(272, 21)
        Me.cmbType.TabIndex = 23
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(732, 172)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 13)
        Me.Label28.TabIndex = 55
        Me.Label28.Text = "Type"
        '
        'btnReloadCategory
        '
        Me.btnReloadCategory.AutoSize = True
        Me.btnReloadCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReloadCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReloadCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnReloadCategory.Location = New System.Drawing.Point(894, 9)
        Me.btnReloadCategory.Name = "btnReloadCategory"
        Me.btnReloadCategory.Size = New System.Drawing.Size(113, 13)
        Me.btnReloadCategory.TabIndex = 148
        Me.btnReloadCategory.Text = "RELOAD CATEGORY"
        '
        'frmProductEdit2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1019, 661)
        Me.Controls.Add(Me.btnReloadCategory)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.SimpleLine5)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmbCatalog)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cmbBrand)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.SimpleLine4)
        Me.Controls.Add(Me.cmbSleeve)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmbMts)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmbPattern)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cmbStyle)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cmbCat)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cmbDept)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtLink)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtPrint)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.SimpleLine3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.SimpleLine2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.SimpleLine1)
        Me.Controls.Add(Me.isTaxable)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.txtRetailPrice)
        Me.Controls.Add(Me.txtCostPrice)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbHsn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbVendors)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbUnits)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmProductEdit2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbUnits As ComboBox
    Friend WithEvents cmbVendors As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbHsn As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCode As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtCostPrice As TextBox
    Friend WithEvents txtRetailPrice As TextBox
    Friend WithEvents txtDiscount As TextBox
    Friend WithEvents isTaxable As ComboBox
    Friend WithEvents SimpleLine1 As simpleline.assemblies.simpleLine
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents SimpleLine2 As simpleline.assemblies.simpleLine
    Friend WithEvents Label12 As Label
    Friend WithEvents SimpleLine3 As simpleline.assemblies.simpleLine
    Friend WithEvents txtSize As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtPrint As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents txtLink As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbSleeve As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbMts As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbPattern As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbStyle As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbCat As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbDept As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cmbColor As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents SimpleLine4 As simpleline.assemblies.simpleLine
    Friend WithEvents cmbCatalog As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents cmbBrand As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents SimpleLine5 As simpleline.assemblies.simpleLine
    Friend WithEvents Label25 As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents btnReloadCategory As Label
End Class
