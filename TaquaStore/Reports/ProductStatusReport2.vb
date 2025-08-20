'**************************** In the name of Allah, Most Merciful, Most Compassionate ********************************
Imports OfficeOpenXml
Imports System.IO
Imports System.Threading.Tasks
Imports System.Environment

Public Class ProductStatusReport2

    'Private Rpt As New RptProductStatusReport
    Private Rpt As New ProductStatusReportNew

    Private Async Sub ProductStatusReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SQL = "SELECT DISTINCT DeptId, Department FROM TSDepartment ORDER BY Department"
        Await ESSA.LoadComboAsync(cmbDept, SQL, "Department", "DeptId", "All Departments")

        SQL = "SELECT DISTINCT CatId, Category FROM TSCategory ORDER BY Category"
        Await ESSA.LoadComboAsync(cmbCat, SQL, "Category", "CatId", "All Categories")

        SQL = "SELECT DISTINCT CatalogId, Catalog FROM TSCatalog ORDER BY Catalog"
        Await ESSA.LoadComboAsync(cmbCatalog, SQL, "Catalog", "CatalogId", "All Catalogs")

        SQL = "SELECT DISTINCT StyleId, Style FROM TSStyle ORDER BY Style"
        Await ESSA.LoadComboAsync(CmbStyle, SQL, "Style", "StyleId", "All Styles")

        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Async Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        If cmbCat.SelectedIndex <= 0 Then
            MsgBox("Please select valid category..!", MsgBoxStyle.Information)
            cmbCat.Focus()
            Exit Sub
        End If

        UpdateLoadingPanel()

        SQL = $"select shopname,department,category,catalog,sum(purchase) purchase,
        sum(delivery) delivery,sum(sales) sales,sum([return]) [return],sum(stock) stock
        from v_productstatus2 where catid = {cmbCat.SelectedValue}"

        If cmbDept.SelectedIndex > 0 Then
            SQL &= $" and deptid = {cmbDept.SelectedValue}"
        End If

        If cmbCatalog.SelectedIndex > 0 Then
            SQL &= $" and catalogid = {cmbCatalog.SelectedValue}"
        End If

        If CmbStyle.SelectedIndex > 0 Then
            SQL &= $" and styleid = {CmbStyle.SelectedValue}"
        End If

        SQL &= $" group by shopname,department,category,catalog"

        TG.Rows.Clear()
        With Await ESSA.OpenReaderAsync(SQL)
            While Await .ReadAsync
                Dim row = TG.Rows.Add
                TG.Item(0, row).Value = .Item("shopname")
                TG.Item(1, row).Value = .Item("department")
                TG.Item(2, row).Value = .Item("category")
                TG.Item(3, row).Value = .Item("catalog")
                TG.Item(4, row).Value = .Item("purchase")
                TG.Item(5, row).Value = .Item("delivery")
                TG.Item(6, row).Value = .Item("sales")
                TG.Item(7, row).Value = .Item("return")
                TG.Item(8, row).Value = .Item("stock")
            End While
            .Close()
        End With

        UpdateLoadingPanel()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Async Sub btnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click

        'If TG.Rows.Count = 0 Then Exit Sub
        'Dim fileName As String = String.Empty

        'If cmbDept.SelectedIndex > 0 Then
        '    fileName &= cmbDept.Text & "->"
        'ElseIf cmbCat.SelectedIndex > 0 Then
        '    fileName &= cmbCat.Text & "->"
        'ElseIf cmbCatalog.SelectedIndex > 0 Then
        '    fileName &= cmbCatalog.Text & "->"
        'ElseIf CmbStyle.SelectedIndex > 0 Then
        '    fileName &= CmbStyle.Text
        'End If

        Try
            UpdateLoadingPanel()
            Await ExportToExcelWithHeadersAsync(TG, "Product Status Report")
            UpdateLoadingPanel()
            MessageBox.Show("Exported successfully..!", "eStore", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try


    End Sub

    Private Sub ProductStatusReport_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlLoad, Me)

    End Sub

    Private Sub UpdateLoadingPanel()
        pnlLoad.Visible = Not pnlLoad.Visible
    End Sub

    Private Async Function ExportToExcelWithHeadersAsync(dataGridView As DataGridView, fileName As String) As Task
        Dim desktopPath As String = GetFolderPath(SpecialFolder.Desktop)
        Dim excelFilePath As String = IO.Path.Combine(desktopPath, fileName & ".xlsx")

        Await Task.Run(Sub()
                           ' Create a new Excel package and add a new worksheet to it
                           Using package As New ExcelPackage(New FileInfo(excelFilePath))
                               Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Data")

                               ' Set column headers
                               For colIndex As Integer = 1 To dataGridView.Columns.Count
                                   worksheet.Cells(1, colIndex).Value = dataGridView.Columns(colIndex - 1).HeaderText
                                   worksheet.Cells(1, colIndex).Style.Font.Bold = True
                               Next

                               ' Populate data from DataGridView
                               For rowIndex As Integer = 0 To dataGridView.Rows.Count - 1
                                   For colIndex As Integer = 0 To dataGridView.Columns.Count - 1
                                       worksheet.Cells(rowIndex + 2, colIndex + 1).Value = dataGridView.Rows(rowIndex).Cells(colIndex).Value
                                   Next
                               Next

                               ' Auto-fit columns for better visibility
                               worksheet.Cells.AutoFitColumns()

                               ' Save the Excel file
                               package.Save()
                           End Using
                       End Sub)
    End Function



End Class