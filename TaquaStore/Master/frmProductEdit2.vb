Imports System.Data.SqlClient

Public Class frmProductEdit2

    Private rackNo As String = ""
    Private entryNo As Integer = 0
    Private serialNo As Integer = 0
    Private productId As Integer = 0
    Private isUpdated As SByte = 1
    Private quantityOnHand As Integer = 0

    Private Sub frmProductEdit2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadCollections()
        loadAttributes()
        resetAttributes()
        isTaxable.SelectedIndex = 0
        txtCode.Select()

    End Sub

    Private Sub generateCatLink()

        Dim link As String = ""

        If cmbDept.SelectedValue > 1 Then
            link &= cmbDept.Text.Trim & "->"
        End If

        If cmbCat.SelectedValue > 1 Then
            link &= cmbCat.Text.Trim & "->"
        End If

        If cmbStyle.SelectedValue > 1 Then
            link &= cmbStyle.Text.Trim & "->"
        End If

        If cmbPattern.SelectedValue > 1 Then
            link &= cmbPattern.Text.Trim & "->"
        End If

        If cmbMts.SelectedValue > 1 Then
            link &= cmbMts.Text.Trim & "->"
        End If

        If cmbSleeve.SelectedValue > 1 Then
            link &= cmbSleeve.Text.Trim & "->"
        End If

        If cmbBrand.SelectedValue > 1 Then
            link &= cmbBrand.Text.Trim & "->"
        End If

        If cmbCatalog.SelectedValue > 1 Then
            link &= cmbPattern.Text.Trim & "->"
        End If

        If link.Length > 0 Then
            link = Mid(link, 1, link.Length - 2)
        End If

        txtLink.Text = link

    End Sub

    Private Sub resetAttributes()

        cmbBrand.SelectedValue = 1
        cmbCatalog.SelectedValue = 1
        cmbCat.SelectedValue = 1
        cmbColor.SelectedValue = 1
        cmbDept.SelectedValue = 1
        cmbMts.SelectedValue = 1
        cmbPattern.SelectedValue = 1
        cmbSleeve.SelectedValue = 1
        cmbStyle.SelectedValue = 1
        cmbType.SelectedValue = 1

    End Sub

    Private Sub loadAttributes()

        SQL = "SELECT BrandId,Brand FROM TSBrand  ORDER BY Brand"
        ESSA.LoadCombo(cmbBrand, SQL, "Brand", "BrandId")

        SQL = "SELECT CatalogId,Catalog FROM TSCatalog  ORDER BY Catalog"
        ESSA.LoadCombo(cmbCatalog, SQL, "Catalog", "CatalogId")

        SQL = "SELECT CatId,Category FROM TSCategory  ORDER BY Category"
        ESSA.LoadCombo(cmbCat, SQL, "Category", "CatId")

        SQL = "SELECT  ColorId,Color FROM  TSColor WHERE IsActive=1 ORDER BY Color"
        ESSA.LoadCombo(cmbColor, SQL, "Color", "ColorId")

        SQL = "SELECT  DeptId,Department FROM   TSDepartment  ORDER BY Department"
        ESSA.LoadCombo(cmbDept, SQL, "Department", "DeptId")

        SQL = "SELECT  MaterialId,Material FROM   TSMaterial  ORDER BY Material"
        ESSA.LoadCombo(cmbMts, SQL, "Material", "MaterialId")

        SQL = "SELECT  PatternId,Pattern FROM   TSPattern  ORDER BY Pattern"
        ESSA.LoadCombo(cmbPattern, SQL, "Pattern", "PatternId")

        SQL = "SELECT  SleeveId,Sleeve FROM   TSSleeve  ORDER BY Sleeve"
        ESSA.LoadCombo(cmbSleeve, SQL, "Sleeve", "SleeveId")

        SQL = "SELECT  StyleId,Style  FROM   TSStyle  ORDER BY Style "
        ESSA.LoadCombo(cmbStyle, SQL, "Style", "StyleId")

        'For type combo box
        SQL = "SELECT TypeId, Type FROM TSType ORDER BY Type"
        ESSA.LoadCombo(cmbType, SQL, "Type", "TypeId")

    End Sub


    Private Sub loadCollections()

        ' Vendors
        Dim qry = "SELECT VendorId, VendorName FROM Vendors ORDER BY VendorName"
        ESSA.LoadCombo(cmbVendors, qry, "VendorName", "VendorId")

        ' Units
        qry = "SELECT DISTINCT Units FROM ProductMaster WHERE LEN(Units) > 0 ORDER BY Units"
        ESSA.LoadCombo(cmbUnits, qry, "Units")

        ' Hsncodes
        'qry = "SELECT DISTINCT HSNCode FROM ProductMaster WHERE LEN(HSNCode) > 0 ORDER BY HSNCode"
        'ESSA.LoadCombo(cmbHsn, qry, "HSNCode")

    End Sub

    Private Sub selectItem(cmb As ComboBox, value As Object)

        cmb.SelectedIndex = cmb.FindStringExact(value.ToString)

    End Sub

    Private Function formatN2(value As Double)

        Return Format(value, "0.00")

    End Function

    Private Sub viewProducts(code As String)

        Dim qry = "SELECT PluId FROM ProductMaster WHERE PluCode = '" & code & "'"
        Dim id = ESSA.GetData(qry)

        If id = 0 Then
            MsgBox("Product code not found..!", MsgBoxStyle.Critical)
            txtCode.Focus()
            Exit Sub
        End If

        qry = "SELECT " _
                & "M.Plucode, M.Pluname, M.Units," _
                & "M.VendorID, M.CostPrice, M.RetailPrice," _
                & "M.Discount, M.IsTaxable, M.HSNCode," _
                & "M.Size, M.Id, M.PrintName, M.CatLink, M.RackNo " _
                & "FROM ProductMaster M " _
                & "WHERE M.PluID = {0};"

        qry &= "SELECT " _
                & "A.DeptId," _
                & "A.CatId," _
                & "A.StyleId," _
                & "A.PatternId," _
                & "A.MaterialId," _
                & "A.ColorId," _
                & "A.SleeveId," _
                & "A.BrandId," _
                & "A.CatalogId, " _
                & "A.EntryNo, " _
                & "A.Sno , " _
                & "A.TypeId " _
                & "FROM ProductAttributes A " _
                & "WHERE A.PluId = {0}"

        qry = String.Format(qry, id)

        With ESSA.OpenReader(qry)
            If .Read Then
                productId = id
                txtCode.Text = .GetString(0).Trim
                txtName.Text = .GetString(1).Trim
                selectItem(cmbUnits, .GetString(2).Trim)
                cmbVendors.SelectedValue = .Item(3)
                txtCostPrice.Text = formatN2(.Item(4))
                txtRetailPrice.Text = formatN2(.Item(5))
                txtDiscount.Text = formatN2(.Item(6))
                isTaxable.SelectedIndex = .Item(7)
                selectItem(cmbHsn, .GetString(8).Trim)
                txtSize.Text = .Item(9)
                txtId.Text = .GetString(10).Trim
                txtPrint.Text = .GetString(11).Trim
                txtLink.Text = .GetString(12).Trim
                rackNo = .GetString(13).Trim
            End If

            .NextResult()

            If .Read Then
                cmbDept.SelectedValue = .Item(0)
                cmbCat.SelectedValue = .Item(1)
                cmbStyle.SelectedValue = .Item(2)
                cmbPattern.SelectedValue = .Item(3)
                cmbMts.SelectedValue = .Item(4)
                cmbColor.SelectedValue = .Item(5)
                cmbSleeve.SelectedValue = .Item(6)
                cmbBrand.SelectedValue = .Item(7)
                cmbCatalog.SelectedValue = .Item(8)
                entryNo = .Item(9)
                serialNo = .Item(10)
                cmbType.SelectedValue = .Item(11)
            End If
            txtCode.Enabled = False
            .Close()
        End With

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        LoadHsn()
        If productId = 0 Then
            MsgBox("Product not loaded properly!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf cmbHsn.Text.Length < 4 Then
            MsgBox("HSN is not loaded..!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Do you want to update..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        generateCatLink()


        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction
        Cmd.Transaction = Trn

        Try

            Dim sql = "DELETE FROM ProductMaster WHERE PluId = " & productId

            Cmd.CommandText = sql
            Cmd.ExecuteNonQuery()

            sql = "INSERT INTO ProductMaster VALUES (" _
                & productId & ",'" _
                & txtCode.Text.Trim & "','" _
                & txtName.Text.Trim & "'," _
                & quantityOnHand & ",'" _
                & cmbUnits.Text.Trim & "'," _
                & cmbVendors.SelectedValue & "," _
                & isTaxable.SelectedIndex & "," _
                & Val(txtCostPrice.Text) & "," _
                & Val(txtRetailPrice.Text) & "," _
                & Val(txtRetailPrice.Text) & "," _
                & Val(txtRetailPrice.Text) & "," _
                & Val(txtDiscount.Text) & "," _
                & Val(txtSize.Text) & ",'" _
                & Trim(txtId.Text) & "','" _
                & txtLink.Text.Trim & "','" _
                & rackNo & "'," _
                & 0 & ",'" _
                & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'," _
                & UserID & "," _
                & cmbColor.SelectedValue & ",'" _
                & txtPrint.Text.Trim & "','" _
                & cmbHsn.Text.Trim & "'," _
                & isTaxable.SelectedIndex & ")"

            Cmd.CommandText = sql
            Cmd.ExecuteNonQuery()


            sql = "DELETE FROM ProductAttributes WHERE PluId = " & productId

            Cmd.CommandText = sql
            Cmd.ExecuteNonQuery()

            sql = "INSERT INTO ProductAttributes VALUES (" _
                & productId & "," _
                & cmbDept.SelectedValue & ",'" _
                & cmbDept.Text.Trim & "'," _
                & cmbCat.SelectedValue & ",'" _
                & cmbCat.Text.Trim & "'," _
                & cmbStyle.SelectedValue & ",'" _
                & cmbStyle.Text.Trim & "'," _
                & cmbPattern.SelectedValue & ",'" _
                & cmbPattern.Text.Trim & "'," _
                & cmbMts.SelectedValue & ",'" _
                & cmbMts.Text.Trim & "'," _
                & cmbColor.SelectedValue & ",'" _
                & cmbColor.Text.Trim & "'," _
                & cmbSleeve.SelectedValue & ",'" _
                & cmbSleeve.Text.Trim & "'," _
                & cmbBrand.SelectedValue & ",'" _
                & cmbBrand.Text.Trim & "'," _
                & cmbCatalog.SelectedValue & ",'" _
                & cmbCatalog.Text.Trim & "'," _
                & cmbType.SelectedValue & ", '" _
                & cmbType.Text.Trim & "'," _
                & entryNo & "," _
                & serialNo & "," _
                & 0 & ")"

            Cmd.CommandText = sql
            Cmd.ExecuteNonQuery()

            Trn.Commit()
            Con.Close()

            MsgBox("Product has been updated!", MsgBoxStyle.Exclamation)
            resetForm()

        Catch ex As SqlException

            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub

    Private Sub resetForm()

        ESSA.ClearTextBox(Me)
        resetAttributes()
        txtCode.Enabled = True
        txtCode.Focus()
        productId = 0

    End Sub

    Private Sub txtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCode.Text.Trim = "" Then
                MsgBox("Code cannot be empty!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            viewProducts(txtCode.Text.Trim)
            txtName.Focus()
        End If


    End Sub

    Private Sub frmProductEdit2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Tag <> "1" Then
                e.SuppressKeyPress = True
                Me.ProcessTabKey(True)
            End If
        End If

    End Sub

    Private Sub LoadHsn()

        cmbHsn.Text = ""

        SQL = "SELECT HSN FROM ProductTax WHERE DeptId = " _
            & cmbDept.SelectedValue & " AND CatId = " _
            & cmbCat.SelectedValue & " AND MatId = " _
            & cmbMts.SelectedValue & " AND IsUpdated = " _
            & TaxVersion & ""

        With ESSA.OpenReader(SQL)
            If .Read Then
                cmbHsn.Text = .GetString(0).Trim
            End If
            .Close()
        End With

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        resetForm()
    End Sub
End Class