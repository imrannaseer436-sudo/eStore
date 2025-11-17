<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeliveryValueReportT
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnTransferReceipt = New System.Windows.Forms.Button()
        Me.chkOmitCP = New System.Windows.Forms.CheckBox()
        Me.SimpleLine1 = New simpleline.assemblies.simpleLine()
        Me.mebTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mebFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CRpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.btnClose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(705, 39)
        Me.Panel3.TabIndex = 22
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(7, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(222, 25)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = " Delivery Value Report"
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(632, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(67, 30)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Tag = "1"
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnTransferReceipt)
        Me.Panel4.Controls.Add(Me.chkOmitCP)
        Me.Panel4.Controls.Add(Me.SimpleLine1)
        Me.Panel4.Controls.Add(Me.mebTo)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.mebFrom)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.btnDisplay)
        Me.Panel4.Controls.Add(Me.cmbLocation)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 39)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(705, 93)
        Me.Panel4.TabIndex = 23
        '
        'btnTransferReceipt
        '
        Me.btnTransferReceipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnTransferReceipt.FlatAppearance.BorderSize = 0
        Me.btnTransferReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransferReceipt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferReceipt.ForeColor = System.Drawing.Color.White
        Me.btnTransferReceipt.Location = New System.Drawing.Point(541, 55)
        Me.btnTransferReceipt.Name = "btnTransferReceipt"
        Me.btnTransferReceipt.Size = New System.Drawing.Size(135, 23)
        Me.btnTransferReceipt.TabIndex = 36
        Me.btnTransferReceipt.Text = "GENERATE TRANSFER"
        Me.btnTransferReceipt.UseVisualStyleBackColor = False
        '
        'chkOmitCP
        '
        Me.chkOmitCP.AutoSize = True
        Me.chkOmitCP.Checked = True
        Me.chkOmitCP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOmitCP.Location = New System.Drawing.Point(448, 3)
        Me.chkOmitCP.Name = "chkOmitCP"
        Me.chkOmitCP.Size = New System.Drawing.Size(67, 17)
        Me.chkOmitCP.TabIndex = 35
        Me.chkOmitCP.Text = "Omit CP"
        Me.chkOmitCP.UseVisualStyleBackColor = True
        '
        'SimpleLine1
        '
        Me.SimpleLine1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SimpleLine1.FillColor = System.Drawing.Color.Transparent
        Me.SimpleLine1.FitToParent = False
        Me.SimpleLine1.Gradient = System.Drawing.Color.Transparent
        Me.SimpleLine1.GradientAngle = simpleline.assemblies.GradientDirection.Horizontal
        Me.SimpleLine1.LineColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.SimpleLine1.LineWidth = 1
        Me.SimpleLine1.Location = New System.Drawing.Point(0, 92)
        Me.SimpleLine1.Name = "SimpleLine1"
        Me.SimpleLine1.Size = New System.Drawing.Size(705, 1)
        Me.SimpleLine1.Style = simpleline.assemblies.LineStyle.Horizontal
        Me.SimpleLine1.TabIndex = 34
        Me.SimpleLine1.UseGradient = False
        '
        'mebTo
        '
        Me.mebTo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mebTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mebTo.Location = New System.Drawing.Point(118, 56)
        Me.mebTo.Name = "mebTo"
        Me.mebTo.Size = New System.Drawing.Size(100, 22)
        Me.mebTo.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(115, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "TO"
        '
        'mebFrom
        '
        Me.mebFrom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mebFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mebFrom.Location = New System.Drawing.Point(12, 56)
        Me.mebFrom.Name = "mebFrom"
        Me.mebFrom.Size = New System.Drawing.Size(100, 22)
        Me.mebFrom.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "FROM"
        '
        'btnDisplay
        '
        Me.btnDisplay.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnDisplay.FlatAppearance.BorderSize = 0
        Me.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisplay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisplay.ForeColor = System.Drawing.Color.White
        Me.btnDisplay.Location = New System.Drawing.Point(448, 55)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(87, 23)
        Me.btnDisplay.TabIndex = 2
        Me.btnDisplay.Text = "DISPLAY"
        Me.btnDisplay.UseVisualStyleBackColor = False
        '
        'cmbLocation
        '
        Me.cmbLocation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(224, 55)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(218, 23)
        Me.cmbLocation.TabIndex = 0
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(9, 8)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(117, 17)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "LOCATION FILTER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(445, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "OPTIONS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(221, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "DELIVERY LOCATION"
        '
        'CRpt
        '
        Me.CRpt.ActiveViewIndex = -1
        Me.CRpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRpt.Location = New System.Drawing.Point(0, 132)
        Me.CRpt.Name = "CRpt"
        Me.CRpt.Size = New System.Drawing.Size(705, 386)
        Me.CRpt.TabIndex = 24
        Me.CRpt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'DeliveryValueReportT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(705, 518)
        Me.Controls.Add(Me.CRpt)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DeliveryValueReportT"
        Me.Tag = "30"
        Me.Text = "Delivery Value Report"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents SimpleLine1 As simpleline.assemblies.simpleLine
    Friend WithEvents mebTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mebFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CRpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkOmitCP As CheckBox
    Friend WithEvents btnTransferReceipt As Button
End Class
