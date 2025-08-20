Imports System.Data.SqlClient
Imports OfficeOpenXml

Public Class StockReportSW

    Private GetId As String = ""

    Private Sub StockReportSW_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQL = "select shopid,(shopname+' - '+shopcode) shopdesc from shops order by shopid"
        ESSA.LoadCombo(cmbLocation, SQL, "shopdesc", "shopid")

        SQL = "SELECT DISTINCT DeptId, Department FROM TSDepartment ORDER BY Department"
        ESSA.LoadCombo(cmbDept, SQL, "Department", "Deptid", "All Departments")

        SQL = "SELECT DISTINCT CatId, Category FROM TSCategory ORDER BY Category"
        ESSA.LoadCombo(cmbCat, SQL, "Category", "CatId", "All Categories")

        SQL = "SELECT DISTINCT StyleId, Style FROM TSStyle ORDER BY Style"
        ESSA.LoadCombo(cmbStyle, SQL, "Style", "StyleId", "All Styles")

        SQL = "SELECT DISTINCT MaterialId, Material FROM TSMaterial ORDER BY Material"
        ESSA.LoadCombo(cmbMat, SQL, "Material", "MaterialId", "All Materials")

        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        ESSA.MovetoCenter(pnlLoad, Me)
        pnlLoad.Show() : pnlLoad.Refresh()

        SQL = "SELECT M.ID FROM ProductMaster M, ProductAttributes A, V_StockPOS S"

        'If cmbLocation.SelectedIndex = 0 Then
        '    SQL &= "V_StockPOS S WHERE "

        'ElseIf cmbLocation.SelectedIndex = 2 Then
        '    SQL &= "V_StockL2 S WHERE "

        'ElseIf cmbLocation.SelectedIndex = 4 Then
        '    SQL &= "V_StockL4 S WHERE "

        'Else
        '    MsgBox("Data not available for selected location..!", MsgBoxStyle.Critical)
        '    cmbLocation.Focus()
        '    Exit Sub
        'End If

        SQL &= " WHERE M.PluID = A.PluId AND S.pluid = M.PluID AND S.location_id = " & cmbLocation.SelectedValue & " AND S.stock > 0 "

        If cmbDept.SelectedIndex > 0 Then
            SQL &= " And A.Department = '" & cmbDept.Text.Trim & "'"
        End If

        If cmbCat.SelectedIndex > 0 Then
            SQL &= " And A.Category = '" & cmbCat.Text.Trim & "'"
        End If

        If cmbStyle.SelectedIndex > 0 Then
            SQL &= " And A.Style = '" & cmbStyle.Text.Trim & "'"
        End If

        If cmbMat.SelectedIndex > 0 Then
            SQL &= " And A.Material = '" & cmbMat.Text.Trim & "' "
        End If

        SQL &= "GROUP BY ID " _
            & "ORDER BY " _
            & "Case " _
            & "WHEN ISNUMERIC(ID) = 1 THEN CONVERT(INT, ID) " _
            & "ELSE 9999999 " _
            & "END, " _
            & "ID"

        With ESSA.OpenReader(SQL)

            lblId.Text = ""
            While .Read
                lblId.Text &= "SUM([" + .GetString(0).Trim + "]) [" + .GetString(0).Trim + "],"
            End While
            .Close()

        End With

        GetId = Mid(lblId.Text, 1, lblId.Text.Length - 1)

        SQL = "Select DISTINCT VendorName [Vendor Name], " & GetId & ",SUM(Total) Total " _
               & " FROM V_StockSizeWise WHERE LocationId = " & cmbLocation.SelectedValue & ""

        'If cmbLocation.SelectedIndex = 0 Then
        '    SQL &= "V_StockSizeWiseWH WHERE "

        'ElseIf cmbLocation.SelectedIndex = 2 Then
        '    SQL &= "V_StockSizeWiseL2 WHERE "

        'ElseIf cmbLocation.SelectedIndex = 4 Then
        '    SQL &= "V_StockSizeWiseL4 WHERE "

        'Else
        '    MsgBox("Data Not available For selected location..!", MsgBoxStyle.Critical)
        '    cmbLocation.Focus()
        '    Exit Sub
        'End If

        If cmbCat.SelectedIndex > 0 Then
            SQL &= " AND Category = '" & cmbCat.Text.Trim & "'"
        End If

        If cmbDept.SelectedIndex > 0 Then
            SQL &= " And Department = '" & cmbDept.Text.Trim & "'"
        End If

        If cmbStyle.SelectedIndex > 0 Then
            SQL &= " And Style = '" & cmbStyle.Text.Trim & "'"
        End If

        If cmbMat.SelectedIndex > 0 Then
            SQL &= " And Material = '" & cmbMat.Text.Trim & "'"
        End If

        SQL &= " GROUP BY VendorName UNION ALL "

        SQL &= "SELECT 'TOTAL', " & GetId & ",SUM(Total) Total " _
            & " FROM V_StockSizeWise WHERE LocationId = " & cmbLocation.SelectedValue & " "

        'If cmbLocation.SelectedIndex = 0 Then
        '    SQL &= "V_StockSizeWiseWH WHERE "

        'ElseIf cmbLocation.SelectedIndex = 2 Then
        '    SQL &= "V_StockSizeWiseL2 WHERE "

        'ElseIf cmbLocation.SelectedIndex = 4 Then
        '    SQL &= "V_StockSizeWiseL4 WHERE "

        'Else
        '    MsgBox("Data not available for selected location..!", MsgBoxStyle.Critical)
        '    cmbLocation.Focus()
        '    Exit Sub
        'End If

        If cmbCat.SelectedIndex > 0 Then
            SQL &= " AND Category = '" & cmbCat.Text.Trim & "'"
        End If

        If cmbDept.SelectedIndex > 0 Then
            SQL &= " And Department = '" & cmbDept.Text.Trim & "'"
        End If

        If cmbStyle.SelectedIndex > 0 Then
            SQL &= " And Style = '" & cmbStyle.Text.Trim & "'"
        End If

        If cmbMat.SelectedIndex > 0 Then
            SQL &= " And Material = '" & cmbMat.Text.Trim & "'"
        End If

        If TG.Columns.Count > 0 Then
            TG.Columns.Clear()
        End If

        ESSA.LoadDataGrid(TG, SQL)

        For i As Short = 1 To TG.Columns.Count - 1
            TG.Columns(0).Width = 200
            TG.Columns(i).Width = 40
            TG.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            TG.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        pnlLoad.Hide()

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        If TG.Rows.Count = 0 Then Exit Sub

        Dim sfd1 As New SaveFileDialog
        sfd1.Title = "Please select export location"
        sfd1.FileName = "Stock Report"
        sfd1.Filter = "Excel Files (*.xlsx)|*.xlsx"
        If sfd1.ShowDialog = DialogResult.Cancel Then Exit Sub

        Dim fileName = sfd1.FileName & ".xlsx"
        Dim tableData As New DataTable
        tableData = CType(TG.DataSource, DataTable)

        Using package As New ExcelPackage(New IO.FileInfo(fileName))
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet1")
            ws.Cells("A1").LoadFromDataTable(tableData, True)
            package.Save()
        End Using

        MsgBox("File exported successfully..!", MsgBoxStyle.Exclamation)

    End Sub

End Class