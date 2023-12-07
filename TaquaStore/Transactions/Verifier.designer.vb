<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Verifier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Verifier))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnFetch = New Syncfusion.WinForms.Controls.SfButton()
        Me.BtnSave = New Syncfusion.WinForms.Controls.SfButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCode = New System.Windows.Forms.TextBox()
        Me.BtnLoad = New Syncfusion.WinForms.Controls.SfButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbDeliveryCodes = New Syncfusion.Windows.Forms.Tools.MultiSelectionComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DgVerifier = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgScan = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel3.SuspendLayout()
        CType(Me.CmbDeliveryCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.DgVerifier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Delivery Verifier"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Location = New System.Drawing.Point(18, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(770, 1)
        Me.Panel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BtnFetch)
        Me.Panel3.Controls.Add(Me.BtnSave)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.TxtCode)
        Me.Panel3.Controls.Add(Me.BtnLoad)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.CmbDeliveryCodes)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(800, 104)
        Me.Panel3.TabIndex = 4
        '
        'BtnFetch
        '
        Me.BtnFetch.AccessibleName = "Button"
        Me.BtnFetch.BackColor = System.Drawing.Color.Navy
        Me.BtnFetch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnFetch.ForeColor = System.Drawing.Color.White
        Me.BtnFetch.Location = New System.Drawing.Point(467, 65)
        Me.BtnFetch.Name = "BtnFetch"
        Me.BtnFetch.Size = New System.Drawing.Size(96, 28)
        Me.BtnFetch.Style.BackColor = System.Drawing.Color.Navy
        Me.BtnFetch.Style.ForeColor = System.Drawing.Color.White
        Me.BtnFetch.TabIndex = 10
        Me.BtnFetch.Text = "Fetch"
        Me.BtnFetch.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.AccessibleName = "Button"
        Me.BtnSave.BackColor = System.Drawing.Color.Navy
        Me.BtnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnSave.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Location = New System.Drawing.Point(365, 65)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(96, 28)
        Me.BtnSave.Style.BackColor = System.Drawing.Color.Navy
        Me.BtnSave.Style.ForeColor = System.Drawing.Color.White
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(652, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Barcode"
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(655, 73)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(133, 22)
        Me.TxtCode.TabIndex = 7
        '
        'BtnLoad
        '
        Me.BtnLoad.AccessibleName = "Button"
        Me.BtnLoad.BackColor = System.Drawing.Color.Navy
        Me.BtnLoad.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnLoad.ForeColor = System.Drawing.Color.White
        Me.BtnLoad.Location = New System.Drawing.Point(263, 66)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(96, 28)
        Me.BtnLoad.Style.BackColor = System.Drawing.Color.Navy
        Me.BtnLoad.Style.ForeColor = System.Drawing.Color.White
        Me.BtnLoad.TabIndex = 6
        Me.BtnLoad.Text = "Load"
        Me.BtnLoad.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Delivery List"
        '
        'CmbDeliveryCodes
        '
        Me.CmbDeliveryCodes.BeforeTouchSize = New System.Drawing.Size(238, 30)
        Me.CmbDeliveryCodes.ButtonStyle = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.CmbDeliveryCodes.DataSource = CType(resources.GetObject("CmbDeliveryCodes.DataSource"), Object)
        Me.CmbDeliveryCodes.DisplayMode = Syncfusion.Windows.Forms.Tools.DisplayMode.DelimiterMode
        Me.CmbDeliveryCodes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbDeliveryCodes.Location = New System.Drawing.Point(18, 65)
        Me.CmbDeliveryCodes.Name = "CmbDeliveryCodes"
        Me.CmbDeliveryCodes.ShowCheckBox = True
        Me.CmbDeliveryCodes.Size = New System.Drawing.Size(238, 30)
        Me.CmbDeliveryCodes.TabIndex = 4
        Me.CmbDeliveryCodes.ThemeName = "Metro"
        Me.CmbDeliveryCodes.UseVisualStyle = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.DgVerifier)
        Me.Panel4.Controls.Add(Me.DgScan)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 104)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(800, 411)
        Me.Panel4.TabIndex = 5
        '
        'DgVerifier
        '
        Me.DgVerifier.AllowUserToAddRows = False
        Me.DgVerifier.AllowUserToDeleteRows = False
        Me.DgVerifier.BackgroundColor = System.Drawing.Color.White
        Me.DgVerifier.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgVerifier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgVerifier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgVerifier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DgVerifier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgVerifier.EnableHeadersVisualStyles = False
        Me.DgVerifier.Location = New System.Drawing.Point(0, 0)
        Me.DgVerifier.Name = "DgVerifier"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgVerifier.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgVerifier.Size = New System.Drawing.Size(655, 411)
        Me.DgVerifier.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "PluId"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Barcode"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Delivery"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Scanned"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Variation"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 80
        '
        'DgScan
        '
        Me.DgScan.AllowUserToAddRows = False
        Me.DgScan.AllowUserToDeleteRows = False
        Me.DgScan.BackgroundColor = System.Drawing.Color.White
        Me.DgScan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgScan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgScan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.Column6})
        Me.DgScan.Dock = System.Windows.Forms.DockStyle.Right
        Me.DgScan.EnableHeadersVisualStyles = False
        Me.DgScan.Location = New System.Drawing.Point(655, 0)
        Me.DgScan.Name = "DgScan"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgScan.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DgScan.RowHeadersVisible = False
        Me.DgScan.Size = New System.Drawing.Size(145, 411)
        Me.DgScan.TabIndex = 1
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Scanned List"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        Me.Column6.Text = "r"
        Me.Column6.UseColumnTextForButtonValue = True
        Me.Column6.Width = 20
        '
        'Verifier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 515)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Verifier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verifier"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.CmbDeliveryCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.DgVerifier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CmbDeliveryCodes As Syncfusion.Windows.Forms.Tools.MultiSelectionComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnLoad As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DgVerifier As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtCode As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents BtnSave As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents BtnFetch As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents DgScan As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewButtonColumn
End Class
