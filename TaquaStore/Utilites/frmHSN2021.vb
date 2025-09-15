Imports System.Data.SqlClient

Public Class frmHSN2021

    Private Edit As Boolean = False
    Private EntryNo As Integer = 0

    Private Sub frmHSN2021_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQL = "SELECT DeptId,Department FROM TSDepartment ORDER BY Department"
        ESSA.LoadCombo(cmbDept, SQL, "Department", "DeptId")

        SQL = "SELECT CatId,Category FROM TSCategory ORDER BY Category"
        ESSA.LoadCombo(cmbCategory, SQL, "Category", "CatId")

        SQL = "SELECT MaterialId,Material FROM TSMaterial ORDER BY Material"
        ESSA.LoadCombo(cmbMaterial, SQL, "Material", "MaterialId")

        SQL = "SELECT DISTINCT MN FROM ProductTax ORDER BY MN"
        ESSA.LoadCombo(cmbMin, SQL, "MN")

        SQL = "SELECT DISTINCT MX FROM ProductTax ORDER BY MX"
        ESSA.LoadCombo(cmbMax, SQL, "MX")

        SetAttributes()
        LoadProductTax()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If ValidateCombo(cmbDept) = -1 Then
            MsgBox("Please select valid Department..!", MsgBoxStyle.Critical)
            cmbDept.Focus()
            Exit Sub
        ElseIf ValidateCombo(cmbCategory) = -1 Then
            MsgBox("Please select valid Category..!", MsgBoxStyle.Critical)
            cmbCategory.Focus()
            Exit Sub
        ElseIf ValidateCombo(cmbMaterial) = -1 Then
            MsgBox("Please select valid Material..!", MsgBoxStyle.Critical)
            cmbMaterial.Focus()
            Exit Sub
        ElseIf txtHSN.Text.Length <> 8 Then
            MsgBox("HSN code Should be eight digits..!", MsgBoxStyle.Critical)
            txtHSN.Focus()
            Exit Sub
            'ElseIf ValidateCombo(cmbMin) = -1 Then
            '    MsgBox("Please select valid minimum tax..!", MsgBoxStyle.Critical)
            '    cmbMaterial.Focus()
            '    Exit Sub
            'ElseIf ValidateCombo(cmbMax) = -1 Then
            '    MsgBox("Please select valid maximum tax..!", MsgBoxStyle.Critical)
            '    cmbMaterial.Focus()
            '    Exit Sub
        ElseIf txtMax.Text.Trim = "" Then
            MsgBox("Please enter max value..!", MsgBoxStyle.Critical)
            txtHSN.Focus()
            Exit Sub
        ElseIf Not Edit Then
            If ifExist() Then
                MsgBox("HSN already exist for this catlink..!", MsgBoxStyle.Critical)
                cmbDept.Focus()
                Exit Sub
            Else
                GenerateEntryNo()
            End If
        ElseIf Edit Then
            SQL = "DELETE FROM ProductTax WHERE EntryNo =" & EntryNo
            ESSA.Execute(SQL)
        End If

        'Using IsUpdated column for tax revisions

        SQL = "INSERT INTO ProductTax VALUES (" _
            & EntryNo & "," _
            & cmbDept.SelectedValue & "," _
            & cmbCategory.SelectedValue & "," _
            & cmbMaterial.SelectedValue & "," _
            & Val(cmbMin.Text) & "," _
            & Val(cmbMax.Text) & "," _
            & Val(txtMax.Text) & "," _
            & Val(txtHSN.Text) & ",'" _
            & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'," _
            & TaxVersion & "," _
            & UserID & ")"

        ESSA.Execute(SQL)

        LoadProductTax()
        SetAttributes()

    End Sub

    Private Sub GenerateEntryNo()

        SQL = "SELECT MAX(EntryNo) FROM ProductTax"
        EntryNo = ESSA.GenerateID(SQL)

    End Sub

    Private Sub TG_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TG.CellMouseClick

        If e.Button = MouseButtons.Right Then

            If IsAdmin Then

                Edit = True
                lblEdit.Visible = Edit
                EntryNo = TG.Item(0, e.RowIndex).Value
                cmbDept.SelectedIndex = cmbDept.FindStringExact(TG.Item(1, e.RowIndex).Value)
                cmbCategory.SelectedIndex = cmbCategory.FindStringExact(TG.Item(2, e.RowIndex).Value)
                cmbMaterial.SelectedIndex = cmbMaterial.FindStringExact(TG.Item(3, e.RowIndex).Value)
                cmbMin.SelectedIndex = cmbMin.FindStringExact(TG.Item(4, e.RowIndex).Value)
                cmbMax.SelectedIndex = cmbMax.FindStringExact(TG.Item(5, e.RowIndex).Value)
                txtMax.Text = TG.Item(6, e.RowIndex).Value
                txtHSN.Text = TG.Item(7, e.RowIndex).Value

            End If

        End If

    End Sub

    Private Function ValidateCombo(cmb As ComboBox) As Short

        Dim Index = cmb.FindStringExact(cmb.Text.Trim)
        If Index <> -1 Then
            cmb.SelectedIndex = Index
        End If
        Return Index

    End Function

    Private Sub LoadProductTax()

        'Using IsUpdated column for tax revisions

        SQL = "SELECT P.EntryNo,D.Department,C.Category,M.Material," _
            & " P.Mn,P.Mx,P.Val,P.HSN FROM " _
            & " ProductTax P,TSDepartment D, TSCategory C, TSMaterial M" _
            & " WHERE P.DeptId = D.DeptId AND P.CatId = C.CatId AND " _
            & " P.MatId = M.MaterialId" _
            & " AND P.IsUpdated = " & TaxVersion

        With ESSA.OpenReader(SQL)

            TG.Rows.Clear()

            While .Read

                Dim row = TG.Rows.Add()

                TG.Item(0, row).Value = .Item(0)
                TG.Item(1, row).Value = .GetString(1).Trim
                TG.Item(2, row).Value = .GetString(2).Trim
                TG.Item(3, row).Value = .GetString(3).Trim
                TG.Item(4, row).Value = Val(.Item(4))
                TG.Item(5, row).Value = Val(.Item(5))
                TG.Item(6, row).Value = Val(.Item(6))
                TG.Item(7, row).Value = .GetString(7).Trim

            End While
            .Close()
        End With

    End Sub

    Private Function ifExist() As Boolean

        ifExist = False

        'Using IsUpdated column for tax revisions

        SQL = "SELECT DISTINCT HSN FROM ProductTax WHERE DeptId = " _
          & cmbDept.SelectedValue & " AND CatId = " _
          & cmbCategory.SelectedValue & " AND MatId = " _
          & cmbMaterial.SelectedValue & " AND IsUpdated = " _
          & TaxVersion & ""

        With ESSA.OpenReader(SQL)

            If .Read Then
                ifExist = True
            End If

        End With

        Return ifExist

    End Function

    Private Sub SetAttributes()

        cmbDept.SelectedValue = 1
        cmbCategory.SelectedValue = 1
        cmbMaterial.SelectedValue = 1
        txtHSN.Clear()
        txtMax.Clear()
        Edit = False
        lblEdit.Visible = Edit
        cmbDept.Focus()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Close()

    End Sub

    Private Sub frmHSN2021_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Tag <> "1" Then
                e.SuppressKeyPress = True
                Me.ProcessTabKey(True)
            End If
        End If

    End Sub
End Class