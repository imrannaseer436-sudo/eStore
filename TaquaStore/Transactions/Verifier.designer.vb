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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
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
        Me.BtnSave = New Syncfusion.WinForms.Controls.SfButton()
        Me.BtnFetch = New Syncfusion.WinForms.Controls.SfButton()
        Me.Panel3.SuspendLayout()
        CType(Me.CmbDeliveryCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.DgVerifier, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(634, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Barcode"
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(637, 73)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(151, 22)
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
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgVerifier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DgVerifier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgVerifier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DgVerifier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgVerifier.EnableHeadersVisualStyles = False
        Me.DgVerifier.Location = New System.Drawing.Point(0, 0)
        Me.DgVerifier.Name = "DgVerifier"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgVerifier.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DgVerifier.Size = New System.Drawing.Size(800, 411)
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
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle12
        Me.Column3.HeaderText = "Delivery"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle13
        Me.Column4.HeaderText = "Scanned"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle14
        Me.Column5.HeaderText = "Variation"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 80
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
End Class
