'************************************************* Bismillah ************************************************
Imports System.Data.SqlClient
Public Class Products3

    Private EntryNo As Integer = 0
    Private Pluid As Integer = 0
    Private CatID(0 To 5) As Short
    Private CatDesc(0 To 5) As String

    Private IsAutomatic As Boolean = False

    Private Sub Products_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            'Case Keys.F5
            '    btnReset.PerformClick()
            Case Keys.F6
                txtCostPrice.Focus()
            Case Keys.F8
                cmbDept.Focus()
            Case Keys.Escape
                If pnlStitchedStatus.Visible Then pnlStitchedStatus.Hide() : Exit Sub
                If pnlMultiOptions.Visible = True Then btnClose2.PerformClick() : Exit Sub
                btnClose.PerformClick()
            Case Keys.Enter
                If Me.ActiveControl.Tag <> "1" Then
                    e.SuppressKeyPress = True
                    Me.ProcessTabKey(True)
                End If

        End Select

    End Sub

    Private Sub LoadAttributes()

        SQL = "SELECT BrandId,Brand FROM TSBrand  ORDER BY Brand"
        ESSA.LoadCombo(cmbBrand, SQL, "Brand", "BrandId")

        SQL = "SELECT CatalogId,Catalog FROM TSCatalog  ORDER BY Catalog"
        ESSA.LoadCombo(cmbCatalog, SQL, "Catalog", "CatalogId")

        SQL = "SELECT CatId,Category FROM TSCategory  ORDER BY Category"
        ESSA.LoadCombo(cmbTSCat, SQL, "Category", "CatId")

        SQL = "SELECT  ColorId,Color FROM TSColor WHERE ISActive=1 ORDER BY Color"
        ESSA.LoadCombo(cmbColor, SQL, "Color", "ColorId")

        SQL = "SELECT  ColorId,Color FROM TSColor WHERE ISActive=1 ORDER BY Color"
        ESSA.LoadCombo(cmbColor2, SQL, "Color", "ColorId")

        'SQL = "SELECT  ColorId,Color FROM TSColor WHERE ISActive=1 ORDER BY Color"
        'ESSA.LoadSFCombo(CmbColors, SQL, "Color", "ColorId")

        SQL = "SELECT  DeptId,Department FROM   TSDepartment  ORDER BY Department"
        ESSA.LoadCombo(cmbTSDept, SQL, "Department", "DeptId")

        SQL = "SELECT  MaterialId,Material FROM   TSMaterial  ORDER BY Material"
        ESSA.LoadCombo(cmbMts, SQL, "Material", "MaterialId")

        SQL = "SELECT  PatternId,Pattern FROM   TSPattern  ORDER BY Pattern"
        ESSA.LoadCombo(cmbPattern, SQL, "Pattern", "PatternId")

        SQL = "SELECT  SleeveId,Sleeve FROM   TSSleeve  ORDER BY Sleeve"
        ESSA.LoadCombo(cmbSleeve, SQL, "Sleeve", "SleeveId")

        SQL = "SELECT  StyleId,Style  FROM   TSStyle  ORDER BY Style "
        ESSA.LoadCombo(cmbStyle, SQL, "Style", "StyleId")

    End Sub


    Private Sub RefreshForm()

        ESSA.ClearTextBox(Panel2)
        LoadAttributes()
        ResetAttributes()
        LoadVendors()
        TG.Rows.Clear()
        cmbHSN.Text = "NONE"
        lblTotalEntries.Text = "0"
        lblLastAdded.Text = "0"
        chkUTax.Checked = False
        ChkDis.Checked = False
        pnlStitchedStatus.Hide()
        txtPlucode.Focus()

    End Sub

    Private Sub LoadColors()

        SQL = "select ColorId,code,color from TSColor where isactive=1 order by color"
        With ESSA.OpenReader(SQL)
            TGColor.Rows.Clear()
            While .Read
                TGColor.Rows.Add()
                TGColor.Item(0, TGColor.Rows.Count - 1).Value = .Item(0)
                TGColor.Item(1, TGColor.Rows.Count - 1).Value = .GetString(1)
                TGColor.Item(2, TGColor.Rows.Count - 1).Value = .GetString(2)
            End While
            .Close()
        End With

    End Sub

    Private Sub Products_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'isDevelopmentMode()

        For Each ctl As Control In Panel2.Controls

            If TypeOf ctl Is TextBox Or TypeOf ctl Is ComboBox Then

                AddHandler ctl.Enter, AddressOf Control_Enter
                AddHandler ctl.Leave, AddressOf Control_Leave

            End If

        Next

        SQL = "select distinct printname from productmaster where len(printname)>0 order by printname"
        ESSA.LoadCombo(cmbPrintName, SQL, "printname")

        'SQL = "select distinct hsncode from productmaster order by hsncode"
        'ESSA.LoadCombo(cmbHSN, SQL, "hsncode", "", "NONE")

        LoadColorTable()
        LoadAttributes()
        ResetAttributes()

        'LoadDepartment()
        LoadColors()
        'PopulateTreeview()
        LoadVendors()
        TG.ColumnHeadersDefaultCellStyle.Font = New Font(TG.Font, FontStyle.Bold)
        cmbTaxable.SelectedIndex = 0

        cmbUTax.SelectedIndex = 0
        cmbUOM.SelectedIndex = cmbUOM.FindStringExact("Pcs")

        btnAutomatic.Select()

    End Sub

    Private ColorTable As New DataTable

    Private Sub LoadColorTable()

        SQL = "SELECT ColorId, Color, Code FROM TSColor WHERE ISActive = 1 ORDER BY ColorId"

        ESSA.OpenConnection()
        ColorTable.Clear()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Adp.Fill(ColorTable)
        End Using
        Con.Close()

    End Sub

    Private Sub ResetAttributes()

        cmbBrand.SelectedValue = 1
        cmbCatalog.SelectedValue = 1
        cmbTSCat.SelectedValue = 1
        cmbColor.SelectedValue = 1
        cmbColor2.SelectedValue = 1
        cmbTSDept.SelectedValue = 1
        cmbMts.SelectedValue = 1
        cmbPattern.SelectedValue = 1
        cmbSleeve.SelectedValue = 1
        cmbStyle.SelectedValue = 1

    End Sub

    Private Sub Control_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CType(sender, Control).BackColor = Color.LightYellow

    End Sub

    Private Sub Control_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CType(sender, Control).BackColor = SystemColors.Window

    End Sub

    Private Sub LoadVendors()

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid")

        'SQL = "select distinct units from productmaster where len(units)>0 order by units"
        'ESSA.LoadCombo(cmbUOM, SQL, "units")

    End Sub

    Private Sub PopulateTreeview()

        SQL = "select catid,catdesc from category order by catid;" _
            & "select pvscatid,scatid,scatdesc from categorylevels where cattype=1 order by pvscatid,scatid"

        With ESSA.OpenReader(SQL)

            TVCat.Nodes.Clear()

            While .Read
                TVCat.Nodes.Add(.Item(0), .GetString(1).Trim)
            End While

            .NextResult()

            While .Read

                Dim TN As TreeNode() = TVCat.Nodes.Find(.Item(0), True)
                If TN.Length > 0 Then
                    TN(0).Nodes.Add(.Item(1), .GetString(2).Trim)
                End If

            End While

            .Close()

        End With

    End Sub

    Private Sub TVCat_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)

        'If e.Node Is Nothing Then Exit Sub

        'For i As Byte = 0 To 5
        '    CatID(i) = 0
        '    CatDesc(i) = ""
        'Next

        'txtSCat.Text = e.Node.FullPath
        'CatID(e.Node.Level) = e.Node.Name
        'CatDesc(e.Node.Level) = e.Node.Text

        'Dim t = e.Node.Parent
        'Do Until t Is Nothing
        '    CatID(t.Level) = t.Name
        '    CatDesc(t.Level) = t.Text
        '    t = t.Parent
        'Loop

        'cmbUOM.Focus()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Function getCatLink() As String

        getCatLink = ""

        If cmbDept.SelectedIndex > -1 Then
            getCatLink = cmbDept.Text.Trim
        End If

        If cmbCat.SelectedIndex > -1 Then
            getCatLink &= "->" & cmbCat.Text.Trim
        End If

        If cmbSCat.SelectedIndex > -1 Then
            getCatLink &= "->" & cmbSCat.Text.Trim
        End If

        If cmbSCat2.SelectedIndex > -1 Then
            getCatLink &= "->" & cmbSCat2.Text.Trim
        End If

    End Function

    Private Function getCatLink2() As String

        getCatLink2 = ""

        If cmbTSDept.SelectedIndex > -1 Then
            getCatLink2 &= IIf(cmbTSDept.SelectedValue = 1, "", cmbTSDept.Text)
        End If

        If cmbTSCat.SelectedIndex > -1 Then
            getCatLink2 &= IIf(cmbTSCat.SelectedValue = 1, "", "->" & cmbTSCat.Text)
            'getCatLink2 &= "->" & cmbTSCat.Text.Trim
        End If

        'If cmbStyle.SelectedIndex > -1 Then
        '    getCatLink2 &= IIf(cmbStyle.SelectedValue = 1, "", "->" & cmbStyle.SelectedValue)
        '    'getCatLink2 &= "->" & cmbStyle.Text.Trim
        'End If

        'If cmbPattern.SelectedIndex > -1 Then
        '    getCatLink2 &= IIf(cmbPattern.SelectedValue = 1, "", "->" & cmbPattern.SelectedValue)
        '    'getCatLink2 &= "->" & cmbPattern.Text.Trim
        'End If

        If cmbMts.SelectedIndex > -1 Then
            'getCatLink2 &= "->" & cmbMts.Text.Trim
            getCatLink2 &= IIf(cmbMts.SelectedValue = 1, "", "->" & cmbMts.Text)
        End If

        'If cmbColor.SelectedIndex > -1 Then
        '    getCatLink2 &= IIf(cmbColor.SelectedValue = 1, "", "->" & cmbColor.SelectedValue)
        '    'getCatLink2 &= "->" & cmbColor.Text.Trim
        'End If

        'If cmbSleeve.SelectedIndex > -1 Then
        '    getCatLink2 &= IIf(cmbSleeve.SelectedValue = 1, "", "->" & cmbSleeve.SelectedValue)
        '    'getCatLink2 &= "->" & cmbSleeve.Text.Trim
        'End If

        'If cmbBrand.SelectedIndex > -1 Then
        '    getCatLink2 &= IIf(cmbBrand.SelectedValue = 1, "", "->" & cmbBrand.SelectedValue)
        '    'getCatLink2 &= "->" & cmbBrand.Text.Trim
        'End If

        'If cmbCatalog.SelectedIndex > -1 Then
        '    getCatLink2 &= IIf(cmbCatalog.SelectedValue = 1, "", "->" & cmbCatalog.SelectedValue)
        '    'getCatLink2 &= "->" & cmbCatalog.Text.Trim
        'End If

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'If txtSCat.Text.Trim = "" Then
        '    TTip.Show("Category not selected..!", txtSCat, 0, 25, 2000)
        '    txtSCat.Focus()
        '    Exit Sub
        'ElseIf TG.Rows.Count = 0 Then
        '    TTip.Show("No products to save..!", btnSave, 0, 25, 2000)
        '    Exit Sub
        'End If

        If TG.Rows.Count = 0 Then
            TTip.Show("No products to save..!", btnSave, 0, 25, 2000)
            Exit Sub
        End If

        'If Not pnlStitchedStatus.Visible Then
        '    pnlStitchedStatus.Show()
        '    Exit Sub
        'End If

        For i As Short = 0 To TG.Rows.Count - 1

            SQL = "select pluid from productmaster where plucode='" & TG.Item(0, i).Value & "'"
            If ESSA.ISFound(SQL) = True Then
                MsgBox("Unable to save, The product code " & TG.Item(0, i).Value & " already exists..!", MsgBoxStyle.Critical)
                Exit Sub
                Exit For
            End If

        Next

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction(IsolationLevel.Serializable)
        Cmd.Transaction = Trn

        Try

            Dim TmpID = ESSA.GenerateID("select max(pluid) from productmaster")
            Dim Prefix = "ES"
            With ESSA.OpenReader("select param_value from settings where param_name = 'BarcodePrefix'")
                If .Read Then
                    Prefix = .GetString(0).Trim.ToUpper
                End If
            End With
            Dim BarcodeNo = ESSA.GenerateID($"SELECT Count(PluID) FROM ProductMaster WHERE Plucode LIKE '{Prefix}%'")
            Dim EntryNo = ESSA.GenerateID("SELECT MAX(EntryNo) FROM ProductAttributes")

            For i As Short = 0 To TG.Rows.Count - 1

                SQL = "insert into productmaster values (" _
                    & TmpID & ",'" _
                    & IIf(IsAutomatic, Prefix + Format(BarcodeNo, "000000"), TG.Item(0, i).Value) & "','" _
                    & TG.Item(1, i).Value & "',0,'" _
                    & TG.Item(2, i).Value & "'," _
                    & cmbVendor.SelectedValue & ",'" _
                    & TG.Item(8, i).Value & "','" _
                    & TG.Item(3, i).Value & "','" _
                    & TG.Item(5, i).Value & "','" _
                    & TG.Item(6, i).Value & "','" _
                    & TG.Item(7, i).Value & "','" _
                    & TG.Item(4, i).Value & "'," _
                    & TmpID & ",'" _
                    & TG.Item(23, i).Value & "','" _
                    & TG.Item(29, i).Value & "','" _
                    & txtRack.Text.Trim & "',0,'" _
                    & Format(Now, "yyyy-MM-dd hh:mm:ss") & "'," _
                    & UserID & "," _
                    & TG.Item(25, i).Value & ",'" _
                    & TG.Item(26, i).Value & "','" _
                    & TG.Item(27, i).Value & "'," _
                    & Val(TG.Item(28, i).Value) & ");"

                SQL &= "insert into productlevels values (" _
                    & TmpID & "," _
                    & TG.Item(10, i).Value & ",'" _
                    & TG.Item(11, i).Value & "'," _
                    & TG.Item(12, i).Value & ",'" _
                    & TG.Item(13, i).Value & "'," _
                    & TG.Item(14, i).Value & ",'" _
                    & TG.Item(15, i).Value & "'," _
                    & TG.Item(16, i).Value & ",'" _
                    & TG.Item(17, i).Value & "'," _
                    & TG.Item(18, i).Value & ",'" _
                    & TG.Item(19, i).Value & "'," _
                    & TG.Item(20, i).Value & ",'" _
                    & TG.Item(21, i).Value & "',0);"

                SQL &= "insert into productbatch values (1," _
                    & TmpID & "," _
                    & Val(TG.Item(5, i).Value) & "," _
                    & Val(TG.Item(5, i).Value) & ",0,'" _
                    & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'," _
                    & ShopID & "," _
                    & UserID & ");"

                SQL &= "INSERT INTO ProductAttributes VALUES (" _
                    & TmpID & "," _
                    & TG.Item(30, i).Value & ",'" _
                    & TG.Item(31, i).Value & "'," _
                    & TG.Item(32, i).Value & ",'" _
                    & TG.Item(33, i).Value & "'," _
                    & TG.Item(34, i).Value & ",'" _
                    & TG.Item(35, i).Value & "'," _
                    & TG.Item(36, i).Value & ",'" _
                    & TG.Item(37, i).Value & "'," _
                    & TG.Item(38, i).Value & ",'" _
                    & TG.Item(39, i).Value & "'," _
                    & TG.Item(40, i).Value & ",'" _
                    & TG.Item(41, i).Value & "'," _
                    & TG.Item(42, i).Value & ",'" _
                    & TG.Item(43, i).Value & "'," _
                    & TG.Item(44, i).Value & ",'" _
                    & TG.Item(45, i).Value & "'," _
                    & TG.Item(46, i).Value & ",'" _
                    & TG.Item(47, i).Value & "'," _
                    & EntryNo & "," _
                    & i + 1 & ", 0)"

                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()

                TmpID += 1
                BarcodeNo += 1

            Next

            Trn.Commit()
            Con.Close()
            MsgBox("Product registered successfully..!", vbExclamation)
            RefreshForm()

        Catch ex As SqlException

            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub

    Private Sub AddProductRows(ByVal e As Object)

        If e.KeyCode = Keys.Enter Then

            If txtPlucode.Text.Trim = "" Then
                TTip.Show("Product code cannot be blank..!", txtPlucode, 0, 25, 2000)
                txtPlucode.Focus()
                Exit Sub
            ElseIf Val(txtCostPrice.Text) <= 0 Or Val(txtRetail.Text) <= 0 Then
                TTip.Show("Cost price and retail price cannot be zero..!", txtCostPrice, 0, 25, 2000)
                txtCostPrice.Focus()
                Exit Sub
            ElseIf Val(txtStart.Text) > Val(txtEnd.Text) Then
                TTip.Show("End size cannot less then stating size..!", txtEnd, 0, 25, 2000)
                txtEnd.Focus()
                Exit Sub
            ElseIf txtSCat.Text.Trim = "" Or CatID(0) = 0 Then
                TTip.Show("Category not selected..!", txtSCat, 0, 25, 2000)
                txtSCat.Focus()
                Exit Sub
            ElseIf cmbHSN.Text.Trim = "NONE" Or cmbHSN.Text.Trim = "" Then
                TTip.Show("Please Select HSN Code..!", cmbHSN, 0, 25, 2000)
                cmbHSN.Focus()
                Exit Sub
            ElseIf cmbTaxable.SelectedIndex = -1 Then
                TTip.Show("Please Select Stitched Status..!", cmbTaxable, 0, 25, 2000)
                cmbTaxable.Focus()
                Exit Sub
            End If

            Dim Siz As Short = Val(txtSize.Text)
            Dim NRI As Short = 0
            Dim ifr As Boolean = False
            Dim rwi As Double = 0
            Dim icp As Double = 0 'Increase Cost Price

            For i As Short = Val(txtStart.Text) To Val(txtEnd.Text) Step Val(txtIncr.Text)

                NRI = ESSA.FindGridIndex(TG, 0, txtPlucode.Text.Trim & IIf(chkSB.Checked = True, SizeToCode(i), i))
                If NRI = -1 Then NRI = TG.Rows.Add()

                If ifr = False Then
                    rwi = Val(txtRetail.Text)
                    ifr = True
                Else
                    rwi += Val(txtRate.Text)
                    If chkOCP.Checked = False Then
                        icp += Val(txtRate.Text)
                    End If
                End If

                TG.Item(0, NRI).Value = txtPlucode.Text.Trim & IIf(chkSB.Checked = True, SizeToCode(i), i)
                TG.Item(1, NRI).Value = txtPludesc.Text.Trim & IIf(chkSB.Checked = True, SizeToCode(i), i)
                TG.Item(2, NRI).Value = cmbUOM.Text
                TG.Item(3, NRI).Value = Val(txtCostPrice.Text) + IIf(chkOCP.Checked = False, icp, 0)
                TG.Item(4, NRI).Value = Val(txtDis.Text)
                TG.Item(5, NRI).Value = rwi
                TG.Item(6, NRI).Value = rwi
                TG.Item(7, NRI).Value = rwi
                TG.Item(8, NRI).Value = IIf(cmbTaxable.SelectedIndex = 0, 1, 0)
                TG.Item(9, NRI).Value = cmbVendor.SelectedValue
                TG.Item(10, NRI).Value = CatID(0)
                TG.Item(11, NRI).Value = CatDesc(0)
                TG.Item(12, NRI).Value = CatID(1)
                TG.Item(13, NRI).Value = CatDesc(1)
                TG.Item(14, NRI).Value = CatID(2)
                TG.Item(15, NRI).Value = CatDesc(2)
                TG.Item(16, NRI).Value = CatID(3)
                TG.Item(17, NRI).Value = CatDesc(3)
                TG.Item(18, NRI).Value = CatID(4)
                TG.Item(19, NRI).Value = CatDesc(4)
                TG.Item(20, NRI).Value = CatID(5)
                TG.Item(21, NRI).Value = CatDesc(5)
                TG.Item(22, NRI).Value = Siz
                TG.Item(23, NRI).Value = IIf(chkSB.Checked = True, SizeToCode(i), i)
                TG.Item(24, NRI).Value = txtSCat.Text
                Siz += 2

            Next

            txtPlucode.Focus()

        End If


    End Sub

    Private Function GetColorCode(ByVal Index As SByte) As String

        If chkColorWise.Checked = True Then
            GetColorCode = TGPick.Item(1, Index).Value
        Else
            GetColorCode = "NC"
        End If

    End Function

    Private Function GetColorID(ByVal Index As SByte) As Short

        If chkColorWise.Checked = False Then
            GetColorID = 1
        Else
            GetColorID = TGPick.Item(0, Index).Value
        End If

    End Function

    Private Function GetColorName(ByVal Index As SByte) As String

        If chkColorWise.Checked = False Then
            GetColorName = "NO COLOR"
        Else
            GetColorName = TGPick.Item(2, Index).Value
        End If

    End Function

    Private Sub getCatID()

        For i As Byte = 0 To 5
            CatID(i) = 0
            CatDesc(i) = ""
        Next

        If cmbDept.SelectedIndex > -1 Then
            CatID(0) = cmbDept.SelectedValue
            CatDesc(0) = cmbDept.Text.Trim
        End If

        If cmbCat.SelectedIndex > -1 Then
            CatID(1) = cmbCat.SelectedValue
            CatDesc(1) = cmbCat.Text.Trim
        End If

        If cmbSCat.SelectedIndex > -1 Then
            CatID(2) = cmbSCat.SelectedValue
            CatDesc(3) = cmbSCat.Text.Trim
        End If

        If cmbSCat2.SelectedIndex > -1 Then
            CatID(3) = cmbSCat2.SelectedValue
            CatDesc(3) = cmbSCat2.Text.Trim
        End If

    End Sub

    Private Sub cmbHSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbHSN.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True
            txtRounds.Focus()

        End If

    End Sub

    Private Function SizeToCode(ByVal Size As Short) As String

        Select Case Size

            Case 1
                SizeToCode = "S"
            Case 2
                SizeToCode = "M"
            Case 3
                SizeToCode = "L"
            Case 4
                SizeToCode = "XL"
            Case 5
                SizeToCode = "XXL"
            Case 6
                SizeToCode = "3XL"
            Case 7
                SizeToCode = "4XL"
            Case 8
                SizeToCode = "5XL"
            Case 9
                SizeToCode = "6XL"
            Case 10
                SizeToCode = "7XL"
            Case Else
                SizeToCode = ""

        End Select

    End Function

    Private Sub TTip_Draw(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawToolTipEventArgs) Handles TTip.Draw

        'Dim Rect As New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
        'e.Graphics.FillRectangle(Brushes.Black, Rect)

        e.DrawBackground()
        e.DrawBorder()
        e.DrawText()

    End Sub

    Private Function RoundOff(ByVal Amt As Double) As Double

        RoundOff = Amt
        Amt = Amt Mod 10

        If Amt > 0 Then
            RoundOff += IIf(Amt >= 5, 10 - Amt, -Amt)
        End If

    End Function

    'Private Sub txtProfit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProfit.TextChanged, txtExtra.TextChanged, txtCostPrice.TextChanged

    '    Dim Retail As Double = Math.Round(Val(txtCostPrice.Text) + ((Val(txtCostPrice.Text) * Val(txtProfit.Text)) / 100) + Val(txtExtra.Text))

    '    If chkRO.Checked = True Then
    '        Retail = RoundOff(Retail)
    '    End If

    '    txtRetail.Text = Format(Retail, "0.00")
    '    txtWholesale.Text = Format(Val(txtRetail.Text), "0.00")
    '    txtMRP.Text = Format(Val(txtRetail.Text), "0.00")

    'End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        ESSA.ClearTextBox(Panel2, "5")
        RefreshForm()
        'PopulateTreeview()

    End Sub

    Private Sub TG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TG.KeyUp

        If e.KeyCode = Keys.Delete Then
            TG.Rows.RemoveAt(TG.CurrentRow.Index)
        End If

    End Sub

    Private Sub txtRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtDis.Focus()
        End If

    End Sub

    Private Sub btnShowColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowColor.Click

        pnlColors.Visible = True
        txtCode.Focus()

    End Sub

    Private Sub Products_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        TG.Columns(30).Width = TG.Width - 830
        ESSA.MovetoCenter(pnlColors, Me)
        ESSA.MovetoCenter(pnlMultiOptions, Me)
        ESSA.MovetoCenter(pnlEntryType, Me)

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        PickRow(False, TGColor, TGPick)

    End Sub

    Private Sub PickRow(ByVal PickAll As Boolean, ByVal Source As DataGridView, ByVal Target As DataGridView)

        If PickAll = True Then

            For i As Short = 0 To Target.Rows.Count - 1
                Target.Rows.Add()
                Target.Item(0, Target.Rows.Count - 1).Value = Source.Item(0, i).Value
                Target.Item(1, Target.Rows.Count - 1).Value = Source.Item(1, i).Value
                Target.Item(2, Target.Rows.Count - 1).Value = Source.Item(2, i).Value
            Next

            Source.Rows.Clear()

        Else

            Target.Rows.Add()
            Target.Item(0, Target.Rows.Count - 1).Value = Source.Item(0, Source.CurrentRow.Index).Value
            Target.Item(1, Target.Rows.Count - 1).Value = Source.Item(1, Source.CurrentRow.Index).Value
            Target.Item(2, Target.Rows.Count - 1).Value = Source.Item(2, Source.CurrentRow.Index).Value
            Source.Rows.RemoveAt(Source.CurrentRow.Index)
            If Source.Rows.Count > 0 Then
                Source.CurrentCell = Source.Item(1, Source.CurrentRow.Index)
            End If

        End If

    End Sub

    Private Sub btnAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAll.Click

        PickRow(True, TGColor, TGPick)

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        PickRow(False, TGPick, TGColor)

    End Sub

    Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click

        PickRow(True, TGPick, TGColor)

    End Sub

    Private Sub TGColor_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TGColor.CellDoubleClick

        If TGColor.CurrentRow.Index = -1 Then Exit Sub
        btnAdd.PerformClick()

    End Sub

    Private Sub TGPick_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TGPick.DoubleClick

        If TGPick.CurrentRow.Index = -1 Then Exit Sub
        btnRemove.PerformClick()

    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click

        pnlColors.Visible = False
        txtRounds.Focus()

    End Sub

    Private Sub chkColorWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkColorWise.CheckedChanged

        btnShowColor.Enabled = chkColorWise.Checked
        cmbColor.Enabled = Not chkColorWise.Checked

    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click

        pnlColors.Visible = False

    End Sub

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnAdd.PerformClick()
        End If

    End Sub

    Private Sub txtCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyUp

        If e.KeyCode = Keys.Down Then
            TGColor.Focus()
        ElseIf e.KeyCode <> Keys.Enter Then
            ESSA.FindAndSelect(TGColor, 1, txtCode.Text)
        End If

    End Sub

    Private Sub txtColor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColor.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnAdd.PerformClick()
        End If

    End Sub

    Private Sub txtColor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColor.KeyUp

        If e.KeyCode = Keys.Down Then
            TGPick.Focus()
        ElseIf e.KeyCode <> Keys.Enter Then
            ESSA.FindAndSelect(TGPick, 1, txtColor.Text)
        End If

    End Sub

    Private Sub btnReLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReLoad.Click

        TGColor.Rows.Clear()
        TGPick.Rows.Clear()
        LoadColors()

    End Sub

    Private Sub btnAddColors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddColors.Click

        Colors.Visible = False
        Colors.ShowDialog(Me)

    End Sub

    Private Sub btnPickCategory_Click(sender As Object, e As EventArgs) Handles btnPickCategory.Click

        pnlCategoryList.Visible = True
        TVCat.Focus()

    End Sub

    Private Sub txtEnd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEnd.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnPickCategory.Focus()
        End If

    End Sub

    Private Sub LoadDepartment()

        SQL = "select catid,catdesc from category order by catdesc"
        ESSA.LoadCombo(cmbDept, SQL, "catdesc", "catid")

    End Sub

    'Private Sub cmbDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDept.SelectedIndexChanged

    '    If cmbDept.SelectedIndex = -1 Then Exit Sub

    '    SQL = String.Format("select scatid,scatdesc from subcategory1 where pvscatid={0} order by scatdesc", cmbDept.SelectedValue)
    '    ESSA.LoadCombo(cmbCat, SQL, "scatdesc", "scatid")

    'End Sub

    'Private Sub cmbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCat.SelectedIndexChanged

    '    If cmbCat.SelectedIndex = -1 Then Exit Sub
    '    SQL = String.Format("select scatid,scatdesc from subcategory2 where pvscatid={0} order by scatdesc", cmbCat.SelectedValue)
    '    ESSA.LoadCombo(cmbSCat, SQL, "scatdesc", "scatid")

    'End Sub

    'Private Sub cmbSCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSCat.SelectedIndexChanged

    '    If cmbSCat.SelectedIndex = -1 Then Exit Sub
    '    SQL = String.Format("select scatid,scatdesc from subcategory3 where pvscatid={0} order by scatdesc", cmbSCat.SelectedValue)
    '    ESSA.LoadCombo(cmbSCat2, SQL, "scatdesc", "scatid")

    'End Sub

    Private Sub btnClose2_Click(sender As Object, e As EventArgs) Handles btnClose2.Click

        pnlMultiOptions.Visible = False
        txtCode.Focus()

    End Sub

    Private Sub btnMultiOptions_Click(sender As Object, e As EventArgs) Handles btnMultiOptions.Click

        pnlMultiOptions.Visible = True

    End Sub

    Private Sub btnHSN_Click(sender As Object, e As EventArgs) Handles btnHSN.Click

        'pnlHSNUpdater.Visible = True
        'txtCode2.Focus()
        frmHSN2021.Visible = False
        frmHSN2021.Show(Me)

    End Sub

    Private Sub btnClose3_Click(sender As Object, e As EventArgs) Handles btnClose3.Click

        pnlHSNUpdater.Visible = False

    End Sub

    Private Sub txtCode2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode2.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SQL = "select pluid,plucode,hsncode,utax from productmaster where plucode='{0}'"
            SQL = String.Format(SQL, txtCode2.Text.Trim)
            With ESSA.OpenReader(SQL)
                If .Read Then
                    lblPluID.Text = .Item(0)
                    txtHSN2.Text = .Item(2)
                    cmbUTax.SelectedIndex = .Item(3)
                    txtHSN2.Focus()
                Else
                    MsgBox("Product code not found..!", MsgBoxStyle.Critical)
                    txtCode2.Focus()
                    Exit Sub
                End If
                .Close()
            End With
        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If txtCode2.Text.Trim = "" Then
            MsgBox("Product code cannot be empty..!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf Val(lblPluID.Text) = 0 Then
            MsgBox("Product code cannot be empty..!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf txtHSN2.Text.Trim.Length < 5 Then
            MsgBox("HSN code cannot be empty..!", MsgBoxStyle.Critical)
            txtHSN2.Focus()
            Exit Sub
        End If

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction
        Cmd.Transaction = Trn

        Try

            SQL = "update productmaster set plucode='{0}', hsncode={1}, utax={2}, isupdated=0 " _
                & "where pluid={3}"
            SQL = String.Format(SQL, txtCode2.Text.Trim, txtHSN2.Text.Trim, cmbUTax.SelectedIndex, Val(lblPluID.Text))

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            Trn.Commit()
            Con.Close()

            MsgBox("Entry updated successfully..!", MsgBoxStyle.Information)

            txtCode2.Clear()
            txtHSN2.Clear()
            txtCode2.Focus()

        Catch ex As SqlException

            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try


    End Sub

    Private SelectedCells As DataGridViewSelectedCellCollection
    Private Sub UpdateColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateColorToolStripMenuItem.Click

        SelectedCells = TG.SelectedCells

        If SelectedCells.Count > 0 Then

            pnlColorUpdater.Show()
            cmbColor2.Focus()

        End If

    End Sub

    Private Sub btnUpdateColor_Click(sender As Object, e As EventArgs) Handles btnUpdateColor.Click

        If SelectedCells.Count > 0 Then

            For Each row As DataGridViewCell In SelectedCells

                TG.Item(40, row.RowIndex).Value = cmbColor2.SelectedValue
                TG.Item(41, row.RowIndex).Value = cmbColor2.Text.Trim

                'Dim desc = Trim(TG.Item(48, row.RowIndex).Value)

                'Dim tColorCode = GetColorCodeTwo(cmbColor2.SelectedValue)
                'TG.Item(1, row.RowIndex).Value = AutoNameGenerator(desc, tColorCode) & Val(TG.Item(23, row.RowIndex).Value)

            Next

            pnlColorUpdater.Hide()

        End If

    End Sub

    Private Sub btnHide6_Click(sender As Object, e As EventArgs) Handles btnHide6.Click

        pnlColorUpdater.Hide()

    End Sub

    'Private Function AutoNameGenerator(name As String, code As String, cp As Integer) As String

    '    Dim cpcode = CostPriceToCode(cp)

    '    Return String.Format("{0} {1} ({2}) - ", name, code, cpcode)

    'End Function

    Private Function AutoNameGenerator(name As String, code As String) As String

        'Dim cpcode = CostPriceToCode(cp)

        Return String.Format("{0} {1} - ", name, code)

    End Function

    Private Function CostPriceToCode(amount As String)

        CostPriceToCode = ""

        For i As SByte = 1 To amount.Length
            Dim letter = Mid(amount, i, 1)
            CostPriceToCode &= StringToWord(letter)
        Next

    End Function

    Private Function StringToWord(letter As Char)

        StringToWord = ""

        Select Case letter
            Case "1"
                StringToWord = "B"
            Case "2"
                StringToWord = "A"
            Case "3"
                StringToWord = "C"
            Case "4"
                StringToWord = "K"
            Case "5"
                StringToWord = "G"
            Case "6"
                StringToWord = "R"
            Case "7"
                StringToWord = "O"
            Case "8"
                StringToWord = "U"
            Case "9"
                StringToWord = "N"
            Case "0"
                StringToWord = "D"
        End Select

    End Function

    Private ColorCode As String = ""
    Private Sub cmbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColor.SelectedIndexChanged

        If cmbColor.SelectedIndex = -1 Then Exit Sub

        ColorCode = GetColorCodeTwo(cmbColor.SelectedValue)

    End Sub

    Private Function GetColorCodeTwo(colorId As Short) As String

        GetColorCodeTwo = ""
        Dim Result = ColorTable.Select("ColorId = " & colorId).ToList
        If Result.Count > 0 Then
            GetColorCodeTwo = Result(0).Item(2)
        End If

    End Function

    Private Sub cmbHSN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHSN.SelectedIndexChanged

    End Sub

    Private Sub btnGetLatestCode_Click(sender As Object, e As EventArgs) Handles btnGetLatestCode.Click

        SQL = "SELECT MAX(GRNNo) FROM GRNMaster WHERE VendorID = {0}"
        SQL = String.Format(SQL, cmbVendor.SelectedValue)

        Dim VendorId = ESSA.GetData(SQL)

        SQL = "SELECT M.Plucode, M.CostPrice, M.RetailPrice, M.MRP " _
            & "FROM GRNDETAILS D, ProductMaster M WHERE " _
            & "M.PluID = D.PluID AND " _
            & "D.GRNNO={0} AND SNO IN " _
            & "(SELECT MAX(SNO) FROM GRNDetails WHERE GRNNO={0})"

        SQL = String.Format(SQL, VendorId)

        With ESSA.OpenReader(SQL)
            If .Read Then
                txtPlucode.Text = .GetString(0).Trim
                MsgBox("Code: " & .GetString(0).Trim & vbCrLf _
                     & "Cost Price: " & Format(.Item(1), "0.00") & vbCrLf _
                     & "Retail Price: " & Format(.Item(2), "0.00"), MsgBoxStyle.Information)
            End If
            .Close()
        End With

    End Sub

    'Private Sub txtRetail_TextChanged(sender As Object, e As EventArgs) Handles txtRetail.TextChanged

    '    txtWholesale.Text = Val(txtRetail.Text)
    '    txtMRP.Text = Val(txtRetail.Text)

    'End Sub

    Private Sub btnReloadCategory_Click(sender As Object, e As EventArgs) Handles btnReloadCategory.Click

        LoadAttributes()
        ResetAttributes()

    End Sub

    Private Sub btnAddRows_Click(sender As Object, e As EventArgs) Handles btnAddRows.Click

        'If txtPlucode.Text.Trim = "" Then
        '    TTip.Show("Product code cannot be blank..!", txtPlucode, 0, 25, 2000)
        '    txtPlucode.Focus()
        '    Exit Sub
        'Else

        GetHsnCode()

        If Val(txtCostPrice.Text) <= 0 Or Val(txtRetail.Text) <= 0 Then
            TTip.Show("Cost price and retail price cannot be zero..!", txtCostPrice, 0, 25, 2000)
            txtCostPrice.Focus()
            Exit Sub
        ElseIf Val(txtStart.Text) > Val(txtEnd.Text) Then
            TTip.Show("End size cannot be less then starting size..!", txtEnd, 0, 25, 2000)
            txtEnd.Focus()
            Exit Sub
        ElseIf Val(txtIncr.Text) = 0 Then
            TTip.Show("step value cannot be zero..!", txtIncr, 0, 25, 2000)
            txtIncr.Focus()
            Exit Sub
        ElseIf cmbHSN.Text.Trim = "NONE" Or cmbHSN.Text.Trim = "" Then
            TTip.Show("HSN Code not found..!", cmbHSN, 0, 25, 2000)
            cmbHSN.Focus()
            Exit Sub
        ElseIf cmbTaxable.SelectedIndex = -1 Then
            TTip.Show("Please Select Stitched Status..!", cmbTaxable, 0, 25, 2000)
            cmbTaxable.Focus()
            Exit Sub
        ElseIf cmbTSDept.SelectedValue <= 1 Then
            TTip.Show("Please Select Valid Department..!", cmbTSDept, 0, 25, 2000)
            cmbTSDept.Focus()
            Exit Sub
        ElseIf cmbTSCat.SelectedValue <= 1 Then
            TTip.Show("Please Select Valid Category..!", cmbTSCat, 0, 25, 2000)
            cmbTSCat.Focus()
            Exit Sub
        ElseIf cmbStyle.SelectedValue < 1 Then
            TTip.Show("Please Select Valid Style..!", cmbStyle, 0, 25, 2000)
            cmbStyle.Focus()
            Exit Sub
        ElseIf cmbMts.SelectedValue < 1 Then
            TTip.Show("Please Select Valid Material..!", cmbMts, 0, 25, 2000)
            cmbMts.Focus()
            Exit Sub
        ElseIf cmbPattern.SelectedValue < 1 Then
            TTip.Show("Please Select Valid Pattern..!", cmbPattern, 0, 25, 2000)
            cmbPattern.Focus()
            Exit Sub
        ElseIf cmbSleeve.SelectedValue < 1 Then
            TTip.Show("Please Select Valid Sleeve..!", cmbSleeve, 0, 25, 2000)
            cmbSleeve.Focus()
            Exit Sub
        ElseIf cmbBrand.SelectedValue < 1 Then
            TTip.Show("Please Select Valid Brand..!", cmbBrand, 0, 25, 2000)
            cmbBrand.Focus()
            Exit Sub
        ElseIf cmbCatalog.SelectedValue < 1 Then
            TTip.Show("Please Select Valid Catalog..!", cmbCatalog, 0, 25, 2000)
            cmbCatalog.Focus()
            Exit Sub
        ElseIf cmbColor.SelectedValue < 1 Then
            TTip.Show("Please Select Valid Color..!", cmbColor, 0, 25, 2000)
            cmbColor.Focus()
            Exit Sub
        End If

        '--------------------------------------
        'Check code already exists
        '--------------------------------------

        If Not IsAutomatic Then

            Dim codeExists As Boolean = False
            Dim codeTemp As String = ""

            ESSA.OpenConnection()
            Dim Cmd = Con.CreateCommand

            For i As Short = Val(txtStart.Text) To Val(txtEnd.Text) Step Val(txtIncr.Text)

                Dim myCode = txtPlucode.Text & i

                SQL = "SELECT PluId FROM ProductMaster WHERE Plucode='" & myCode & "'"
                Cmd.CommandText = SQL
                Dim result = Cmd.ExecuteScalar
                If Not result = Nothing Then
                    codeTemp = myCode
                    codeExists = True
                    Exit For
                End If

            Next

            Con.Close()

            If codeExists Then
                MsgBox("Code already found:" & codeTemp, MsgBoxStyle.Critical)
                Exit Sub
            End If

        End If

        'lblDesc.Text = AutoNameGenerator(txtPludesc.Text.Trim, ColorCode)

        Dim Siz As Short = Val(txtSize.Text)
        Dim NRI As Short = -1
        Dim ifr As Boolean = False
        Dim rwi As Double = 0
        Dim icp As Double = 0 'Increase Cost Price
        Dim pcc As SByte = 0 'Picked Color Count

        getCatID()

        If chkColorWise.Checked = True Then
            pcc = TGPick.Rows.Count - 1
            If pcc = -1 Then
                MsgBox("Please pick colors..!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If



        For rounds As Byte = 1 To Int(txtRounds.Value)

            For c As Byte = 0 To pcc

                For i As Short = Val(txtStart.Text) To Val(txtEnd.Text) Step Val(txtIncr.Text)

                    If chkSB.Checked Then
                        If SizeToCode(i) = "" Then
                            MsgBox("Size code not exists..!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                    End If

                    If IsAutomatic Then
                        NRI = ESSA.FindGridIndex(TG, 0, txtPlucode.Text.Trim & IIf(chkSB.Checked = True, SizeToCode(i), i))
                    End If
                    If NRI = -1 Then NRI = TG.Rows.Add()

                    If ifr = False Then
                        rwi = Val(txtRetail.Text)
                        ifr = True
                    Else
                        rwi += Val(txtRate.Text)
                        If chkOCP.Checked = False Then
                            icp += Val(txtRate.Text)
                        End If
                    End If

                    TG.Item(0, NRI).Value = IIf(IsAutomatic, "", txtPlucode.Text.Trim & IIf(chkColorWise.Checked = True, GetColorCode(c), "") & IIf(chkSB.Checked = True, SizeToCode(i), i))
                    TG.Item(1, NRI).Value = IIf(IsAutomatic, txtPludesc.Text.Trim & IIf(chkColorWise.Checked = True, " " & GetColorCode(c), ""), txtPludesc.Text.Trim)
                    'TG.Item(1, NRI).Value = txtPludesc.Text.Trim
                    'TG.Item(1, NRI).Value = lblDesc.Text.Trim & IIf(chkSB.Checked = True, SizeToCode(i), i)
                    TG.Item(2, NRI).Value = cmbUOM.Text
                    TG.Item(3, NRI).Value = Val(txtCostPrice.Text) + IIf(chkOCP.Checked = False, icp, 0)
                    TG.Item(4, NRI).Value = Val(txtDis.Text)
                    TG.Item(5, NRI).Value = rwi
                    TG.Item(6, NRI).Value = rwi
                    TG.Item(7, NRI).Value = rwi
                    TG.Item(8, NRI).Value = IIf(cmbTaxable.SelectedIndex = 0, 1, 0)
                    TG.Item(9, NRI).Value = cmbVendor.SelectedValue
                    TG.Item(10, NRI).Value = CatID(0)
                    TG.Item(11, NRI).Value = CatDesc(0)
                    TG.Item(12, NRI).Value = CatID(1)
                    TG.Item(13, NRI).Value = CatDesc(1)
                    TG.Item(14, NRI).Value = CatID(2)
                    TG.Item(15, NRI).Value = CatDesc(2)
                    TG.Item(16, NRI).Value = CatID(3)
                    TG.Item(17, NRI).Value = CatDesc(3)
                    TG.Item(18, NRI).Value = CatID(4)
                    TG.Item(19, NRI).Value = CatDesc(4)
                    TG.Item(20, NRI).Value = CatID(5)
                    TG.Item(21, NRI).Value = CatDesc(5)
                    TG.Item(22, NRI).Value = Siz
                    TG.Item(23, NRI).Value = IIf(chkSB.Checked = True, SizeToCode(i), i)
                    'TG.Item(24, NRI).Value = txtSCat.Text
                    TG.Item(29, NRI).Value = getCatLink2()
                    TG.Item(25, NRI).Value = GetColorID(c)
                    TG.Item(26, NRI).Value = cmbPrintName.Text.Trim
                    TG.Item(27, NRI).Value = cmbHSN.Text.Trim
                    TG.Item(28, NRI).Value = IIf(cmbTaxable.SelectedIndex = 0, 1, 0)

                    TG.Item(30, NRI).Value = cmbTSDept.SelectedValue
                    TG.Item(31, NRI).Value = cmbTSDept.Text

                    TG.Item(32, NRI).Value = cmbTSCat.SelectedValue
                    TG.Item(33, NRI).Value = cmbTSCat.Text

                    TG.Item(34, NRI).Value = cmbStyle.SelectedValue
                    TG.Item(35, NRI).Value = cmbStyle.Text

                    TG.Item(36, NRI).Value = cmbPattern.SelectedValue
                    TG.Item(37, NRI).Value = cmbPattern.Text

                    TG.Item(38, NRI).Value = cmbMts.SelectedValue
                    TG.Item(39, NRI).Value = cmbMts.Text

                    TG.Item(40, NRI).Value = IIf(chkColorWise.Checked, GetColorID(c), cmbColor.SelectedValue)
                    TG.Item(41, NRI).Value = IIf(chkColorWise.Checked, GetColorName(c), cmbColor.Text)

                    'TG.Item(40, NRI).Value = cmbColor.SelectedValue
                    'TG.Item(41, NRI).Value = cmbColor.Text

                    TG.Item(42, NRI).Value = cmbSleeve.SelectedValue
                    TG.Item(43, NRI).Value = cmbSleeve.Text

                    TG.Item(44, NRI).Value = cmbBrand.SelectedValue
                    TG.Item(45, NRI).Value = cmbBrand.Text

                    TG.Item(46, NRI).Value = cmbCatalog.SelectedValue
                    TG.Item(47, NRI).Value = cmbCatalog.Text

                    TG.Item(48, NRI).Value = txtPludesc.Text.Trim

                    Siz += 2

                Next

            Next

        Next

        If chkReset.Checked Then
            txtRounds.Value = 1
        End If

        If IsAutomatic Then
            txtPludesc.Focus()
        Else
            txtPlucode.Focus()
        End If
        CalculateCPTotal()


    End Sub

    Private Sub btnAutomatic_Click(sender As Object, e As EventArgs) Handles btnAutomatic.Click

        lblMode.Text = "Mode: Automatic"
        lblMode.ForeColor = Color.Maroon

        IsAutomatic = True
        txtPlucode.Enabled = Not IsAutomatic
        pnlEntryType.Hide()
        cmbVendor.Select()

    End Sub

    Private Sub btnManual_Click(sender As Object, e As EventArgs) Handles btnManual.Click

        lblMode.Text = "Mode: Manual"
        lblMode.ForeColor = Color.Navy

        IsAutomatic = False
        txtPlucode.Enabled = Not IsAutomatic
        pnlEntryType.Hide()
        cmbVendor.Select()

    End Sub

    Private Sub ChkDis_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDis.CheckedChanged

        txtDis.Enabled = ChkDis.Checked
        If Not ChkDis.Checked Then
            txtDis.Clear()
        End If

    End Sub

    Private Sub cmbMts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMts.SelectedIndexChanged



    End Sub

    Private Sub cmbMts_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMts.KeyDown



    End Sub

    Private Sub GetHsnCode()

        cmbHSN.Text = ""

        SQL = "SELECT DISTINCT HSN FROM ProductTax WHERE DeptId = " _
             & cmbTSDept.SelectedValue & " AND CatId = " _
             & cmbTSCat.SelectedValue & "AND MatId = " _
             & cmbMts.SelectedValue

        With ESSA.OpenReader(SQL)
            If .Read Then
                cmbHSN.Text = .GetString(0).Trim
            End If
            .Close()
        End With

    End Sub

    Private Sub TG_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles TG.RowsAdded

        lblLastAdded.Text = Val(txtRounds.Value)
        lblTotalEntries.Text = TG.Rows.Count


    End Sub

    Private Sub TG_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles TG.RowsRemoved

        lblTotalEntries.Text = TG.Rows.Count
        CalculateCPTotal()

    End Sub

    Private Sub CalculateCPTotal()

        Dim CPTotal As Double = 0
        For i As Short = 0 To TG.Rows.Count - 1
            CPTotal += Val(TG.Item(3, i).Value)
        Next
        lblTotCP.Text = Format(CPTotal, "0.00")

    End Sub

    Private Sub LblHSNReload_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub txtRetail_KeyPress(sender As Object, e As KeyEventArgs) Handles txtRetail.KeyUp

        txtProfit.Text = Format(((Val(txtRetail.Text) - Val(txtCostPrice.Text)) / Val(txtCostPrice.Text)) * 100, "0.00")

    End Sub

    Private Sub txtProfit_KeyPress(sender As Object, e As KeyEventArgs) Handles txtProfit.KeyUp, txtExtra.KeyUp, txtCostPrice.KeyUp

        Dim Retail As Double = Math.Round(Val(txtCostPrice.Text) + ((Val(txtCostPrice.Text) * Val(txtProfit.Text)) / 100) + Val(txtExtra.Text))

        If chkRO.Checked = True Then
            Retail = RoundOff(Retail)
        End If

        txtRetail.Text = Format(Retail, "0.00")
        txtWholesale.Text = Format(Val(txtRetail.Text), "0.00")
        txtMRP.Text = Format(Val(txtRetail.Text), "0.00")

    End Sub


End Class