Imports System.Environment
Imports System.IO
Imports System.Threading.Tasks
Imports OfficeOpenXml

Public Class DeliveryWiseSalesAndStockReport
    Private Async Sub DeliveryWiseSalesAndStockReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQL = "select shopid,convert(varchar,shopname) + ' - ' + convert(varchar,shopcode) name from shops where shoptype='Retail' order by shopid"
        Await ESSA.LoadComboAsync(CmbShop, SQL, "name", "shopid")

        SQL = "SELECT DISTINCT DeptId, Department FROM TSDepartment ORDER BY Department"
        Await ESSA.LoadComboAsync(cmbDept, SQL, "Department", "DeptId", "All Departments")

        SQL = "SELECT DISTINCT CatId, Category FROM TSCategory ORDER BY Category"
        Await ESSA.LoadComboAsync(cmbCat, SQL, "Category", "CatId", "All Categories")

        SQL = "SELECT DISTINCT CatalogId, Catalog FROM TSCatalog ORDER BY Catalog"
        Await ESSA.LoadComboAsync(CmbCatalog, SQL, "Catalog", "CatalogId", "All Catalogs")

        SQL = "SELECT DISTINCT StyleId, Style FROM TSStyle ORDER BY Style"
        Await ESSA.LoadComboAsync(CmbStyle, SQL, "Style", "StyleId", "All Styles")

        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Async Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        If CmbShop.SelectedIndex < 0 Then
            MsgBox("Please select shop..!", MsgBoxStyle.Critical)
            CmbShop.Focus()
            Exit Sub
        End If

        SQL = $"SELECT A.BARCODE,A.DEPARTMENT,A.CATEGORY,A.STYLE,A.CATALOG,A.SIZE,SUM(DELIVERY) DELIVERY,
        SUM(SALES) SALES,SUM([RETURN]) [RETURN],SUM(STOCK) STOCK
        FROM
        (SELECT SUM(DD.QUANTITY) [DELIVERY],0 [SALES],0 [RETURN],0 [STOCK],
        A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,A.CATALOGID,
        A.CATALOG,P.ID [SIZE],P.PLUCODE [BARCODE]
        FROM DELIVERYMASTER DM
        INNER JOIN DELIVERYDETAILS DD ON DM.ID = DD.ID AND DM.DELIVERYTO = {CmbShop.SelectedValue} 
        AND DM.DELIVERYFROM = 1 AND CONVERT(DATE,DM.DELIVERYDATE) BETWEEN '{mebFrom.Value:yyyy-MM-dd}' AND '{mebTo.Value:yyyy-MM-dd}'
        INNER JOIN PRODUCTMASTER P ON P.PLUID = DD.PLUID
        INNER JOIN PRODUCTATTRIBUTES A ON A.PLUID = DD.PLUID 
        {IIf(CmbCatalog.SelectedIndex > 0, $" AND A.CATALOGID = { CmbCatalog.SelectedValue }", "")}
        {IIf(cmbDept.SelectedIndex > 0, $" AND A.DEPTID = { cmbDept.SelectedValue }", "")}
        {IIf(cmbCat.SelectedIndex > 0, $" AND A.CATID = { cmbCat.SelectedValue }", "")}
        {IIf(CmbStyle.SelectedIndex > 0, $" AND A.STYLEID = { CmbStyle.SelectedValue }", "")}
        GROUP BY A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,
        A.CATALOGID,A.CATALOG,P.ID,P.PLUCODE
        UNION ALL
        SELECT 0,SUM(BD.QTY),0,0,A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,
        A.STYLEID,A.STYLE,A.CATALOGID,A.CATALOG,P.ID,P.PLUCODE
        FROM BILLMASTER BM
        INNER JOIN BILLDETAILS BD ON BM.BILLID = BD.BILLID AND BD.SHOPID = {CmbShop.SelectedValue}
        INNER JOIN PRODUCTMASTER P ON P.PLUID = BD.PLUID
        INNER JOIN PRODUCTATTRIBUTES A ON A.PLUID = BD.PLUID 
        {IIf(CmbCatalog.SelectedIndex > 0, $" AND A.CATALOGID = { CmbCatalog.SelectedValue }", "")}
        {IIf(cmbDept.SelectedIndex > 0, $" AND A.DEPTID = { cmbDept.SelectedValue }", "")}
        {IIf(cmbCat.SelectedIndex > 0, $" AND A.CATID = { cmbCat.SelectedValue }", "")}
        {IIf(CmbStyle.SelectedIndex > 0, $" AND A.STYLEID = { CmbStyle.SelectedValue }", "")}        
        AND EXISTS ( SELECT * FROM DELIVERYDETAILS DD,DELIVERYMASTER DM WHERE DD.PLUID = BD.PLUID 
        AND DM.DELIVERYTO = {CmbShop.SelectedValue} AND DM.DELIVERYFROM = 1 AND DD.ID = DM.ID AND CONVERT(DATE,DM.DELIVERYDATE) 
        BETWEEN '{mebFrom.Value:yyyy-MM-dd}' AND '{mebTo.Value:yyyy-MM-dd}')
        GROUP BY A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,
        A.CATALOGID,A.CATALOG,P.ID,P.PLUCODE
        UNION ALL
        SELECT 0,0,SUM(DD.QUANTITY),0,A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,
        A.STYLEID,A.STYLE,A.CATALOGID,A.CATALOG,P.ID,P.PLUCODE
        FROM DELIVERYMASTER DM
        INNER JOIN DELIVERYDETAILS DD ON DM.ID = DD.ID AND DM.DELIVERYTO = 1 AND DM.DELIVERYFROM = {CmbShop.SelectedValue}
        INNER JOIN PRODUCTMASTER P ON P.PLUID = DD.PLUID 
        INNER JOIN PRODUCTATTRIBUTES A ON A.PLUID = DD.PLUID 
        {IIf(CmbCatalog.SelectedIndex > 0, $" AND A.CATALOGID = { CmbCatalog.SelectedValue }", "")}
        {IIf(cmbDept.SelectedIndex > 0, $" AND A.DEPTID = { cmbDept.SelectedValue }", "")}
        {IIf(cmbCat.SelectedIndex > 0, $" AND A.CATID = { cmbCat.SelectedValue }", "")}
        {IIf(CmbStyle.SelectedIndex > 0, $" AND A.STYLEID = { CmbStyle.SelectedValue }", "")}
        AND EXISTS ( SELECT * FROM DELIVERYDETAILS D,DELIVERYMASTER M WHERE DD.PLUID = D.PLUID 
        AND M.DELIVERYTO = {CmbShop.SelectedValue} AND M.DELIVERYFROM = 1 AND D.ID = M.ID AND CONVERT(DATE,M.DELIVERYDATE) 
        BETWEEN '{mebFrom.Value:yyyy-MM-dd}' AND '{mebTo.Value:yyyy-MM-dd}')
        GROUP BY A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,
        A.CATALOGID,A.CATALOG,P.ID,P.PLUCODE
        UNION ALL
        SELECT 0,0,0,SUM(V.STOCK),A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,
        A.STYLEID,A.STYLE,A.CATALOGID,A.CATALOG,P.ID,P.PLUCODE
        FROM V_STOCKPOS V
        INNER JOIN PRODUCTMASTER P ON P.PLUID = V.PLUID
        INNER JOIN PRODUCTATTRIBUTES A ON A.PLUID = V.PLUID AND V.LOCATION_ID = {CmbShop.SelectedValue} 
        {IIf(CmbCatalog.SelectedIndex > 0, $" AND A.CATALOGID = { CmbCatalog.SelectedValue }", "")}
        {IIf(cmbDept.SelectedIndex > 0, $" AND A.DEPTID = { cmbDept.SelectedValue }", "")}
        {IIf(cmbCat.SelectedIndex > 0, $" AND A.CATID = { cmbCat.SelectedValue }", "")}
        {IIf(CmbStyle.SelectedIndex > 0, $" AND A.STYLEID = { CmbStyle.SelectedValue }", "")}
        AND EXISTS ( SELECT * FROM DELIVERYDETAILS DD,DELIVERYMASTER DM WHERE DD.PLUID = V.PLUID 
        AND DM.DELIVERYTO = {CmbShop.SelectedValue} AND DM.DELIVERYFROM = 1 AND DD.ID = DM.ID AND CONVERT(DATE,DM.DELIVERYDATE) 
        BETWEEN '{mebFrom.Value:yyyy-MM-dd}' AND '{mebTo.Value:yyyy-MM-dd}')
        GROUP BY A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,
        A.CATALOGID,A.CATALOG,P.ID,P.PLUCODE) A
        GROUP BY A.DEPARTMENT,A.CATEGORY,A.STYLE,A.CATALOG,A.SIZE,A.BARCODE"

        'SQL = $"SELECT A.DEPARTMENT,A.CATEGORY,A.STYLE,A.CATALOG,SUM(DELIVERY) DELIVERY,
        'SUM(SALES) SALES,SUM([RETURN]) [RETURN],SUM(STOCK) STOCK
        'FROM
        '(SELECT SUM(DD.QUANTITY) [DELIVERY],0 [SALES],0 [RETURN],0 [STOCK],
        'A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,A.CATALOGID,
        'A.CATALOG
        'FROM DELIVERYMASTER DM
        'INNER JOIN DELIVERYDETAILS DD ON DM.ID = DD.ID AND DM.DELIVERYTO = {CmbShop.SelectedValue} 
        'AND DM.DELIVERYFROM = 1 AND CONVERT(DATE,DM.DELIVERYDATE) BETWEEN '{mebFrom.Value:yyyy-MM-dd}' AND '{mebTo.Value:yyyy-MM-dd}'
        'INNER JOIN PRODUCTATTRIBUTES A ON A.PLUID = DD.PLUID 
        '{IIf(CmbCatalog.SelectedIndex > 0, $" AND A.CATALOGID = { CmbCatalog.SelectedValue }", "")}
        '{IIf(cmbDept.SelectedIndex > 0, $" AND A.DEPTID = { cmbDept.SelectedValue }", "")}
        '{IIf(cmbCat.SelectedIndex > 0, $" AND A.CATID = { cmbCat.SelectedValue }", "")}
        '{IIf(CmbStyle.SelectedIndex > 0, $" AND A.STYLEID = { CmbStyle.SelectedValue }", "")}
        'GROUP BY A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,
        'A.CATALOGID,A.CATALOG
        'UNION ALL
        'SELECT 0,SUM(BD.QTY),0,0,A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,
        'A.STYLEID,A.STYLE,A.CATALOGID,A.CATALOG
        'FROM BILLMASTER BM
        'INNER JOIN BILLDETAILS BD ON BM.BILLID = BD.BILLID AND BD.SHOPID = {CmbShop.SelectedValue}
        'INNER JOIN PRODUCTATTRIBUTES A ON A.PLUID = BD.PLUID 
        '{IIf(CmbCatalog.SelectedIndex > 0, $" AND A.CATALOGID = { CmbCatalog.SelectedValue }", "")}
        '{IIf(cmbDept.SelectedIndex > 0, $" AND A.DEPTID = { cmbDept.SelectedValue }", "")}
        '{IIf(cmbCat.SelectedIndex > 0, $" AND A.CATID = { cmbCat.SelectedValue }", "")}
        '{IIf(CmbStyle.SelectedIndex > 0, $" AND A.STYLEID = { CmbStyle.SelectedValue }", "")}        
        'AND EXISTS ( SELECT * FROM DELIVERYDETAILS DD,DELIVERYMASTER DM WHERE DD.PLUID = BD.PLUID 
        'AND DM.DELIVERYTO = {CmbShop.SelectedValue} AND DM.DELIVERYFROM = 1 AND DD.ID = DM.ID AND CONVERT(DATE,DM.DELIVERYDATE) 
        'BETWEEN '{mebFrom.Value:yyyy-MM-dd}' AND '{mebTo.Value:yyyy-MM-dd}')
        'GROUP BY A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,
        'A.CATALOGID,A.CATALOG
        'UNION ALL
        'SELECT 0,0,SUM(DD.QUANTITY),0,A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,
        'A.STYLEID,A.STYLE,A.CATALOGID,A.CATALOG
        'FROM DELIVERYMASTER DM
        'INNER JOIN DELIVERYDETAILS DD ON DM.ID = DD.ID AND DM.DELIVERYTO = 1 AND DM.DELIVERYFROM = {CmbShop.SelectedValue}
        'INNER JOIN PRODUCTATTRIBUTES A ON A.PLUID = DD.PLUID 
        '{IIf(CmbCatalog.SelectedIndex > 0, $" AND A.CATALOGID = { CmbCatalog.SelectedValue }", "")}
        '{IIf(cmbDept.SelectedIndex > 0, $" AND A.DEPTID = { cmbDept.SelectedValue }", "")}
        '{IIf(cmbCat.SelectedIndex > 0, $" AND A.CATID = { cmbCat.SelectedValue }", "")}
        '{IIf(CmbStyle.SelectedIndex > 0, $" AND A.STYLEID = { CmbStyle.SelectedValue }", "")}
        'AND EXISTS ( SELECT * FROM DELIVERYDETAILS D,DELIVERYMASTER M WHERE DD.PLUID = D.PLUID 
        'AND M.DELIVERYTO = {CmbShop.SelectedValue} AND M.DELIVERYFROM = 1 AND D.ID = M.ID AND CONVERT(DATE,M.DELIVERYDATE) 
        'BETWEEN '{mebFrom.Value:yyyy-MM-dd}' AND '{mebTo.Value:yyyy-MM-dd}')
        'GROUP BY A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,
        'A.CATALOGID,A.CATALOG
        'UNION ALL
        'SELECT 0,0,0,SUM(V.STOCK),A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,
        'A.STYLEID,A.STYLE,A.CATALOGID,A.CATALOG
        'FROM V_STOCKPOS V
        'INNER JOIN PRODUCTATTRIBUTES A ON A.PLUID = V.PLUID AND V.LOCATION_ID = {CmbShop.SelectedValue} 
        '{IIf(CmbCatalog.SelectedIndex > 0, $" AND A.CATALOGID = { CmbCatalog.SelectedValue }", "")}
        '{IIf(cmbDept.SelectedIndex > 0, $" AND A.DEPTID = { cmbDept.SelectedValue }", "")}
        '{IIf(cmbCat.SelectedIndex > 0, $" AND A.CATID = { cmbCat.SelectedValue }", "")}
        '{IIf(CmbStyle.SelectedIndex > 0, $" AND A.STYLEID = { CmbStyle.SelectedValue }", "")}
        'AND EXISTS ( SELECT * FROM DELIVERYDETAILS DD,DELIVERYMASTER DM WHERE DD.PLUID = V.PLUID 
        'AND DM.DELIVERYTO = {CmbShop.SelectedValue} AND DM.DELIVERYFROM = 1 AND DD.ID = DM.ID AND CONVERT(DATE,DM.DELIVERYDATE) 
        'BETWEEN '{mebFrom.Value:yyyy-MM-dd}' AND '{mebTo.Value:yyyy-MM-dd}')
        'GROUP BY A.DEPTID,A.DEPARTMENT,A.CATID,A.CATEGORY,A.STYLEID,A.STYLE,
        'A.CATALOGID,A.CATALOG) A
        'GROUP BY A.DEPARTMENT,A.CATEGORY,A.STYLE,A.CATALOG"

        UpdateLoadingPanel()
        Await ESSA.LoadDataGridAsync(TG, SQL)
        Await CalculateSummary()
        UpdateLoadingPanel()

    End Sub

    Private Sub DeliveryWiseSalesAndStockReport_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlLoad, Me)

    End Sub

    Private Sub UpdateLoadingPanel()

        pnlLoad.Visible = Not pnlLoad.Visible

    End Sub

    Private Async Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click

        If TG.Rows.Count = 0 Then Exit Sub

        Try
            UpdateLoadingPanel()
            Await ExportToExcelWithHeadersAsync(TG, "Sales And Stock Report")
            UpdateLoadingPanel()
            MessageBox.Show("Exported successfully..!", "eStore", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try

    End Sub

    Private Async Function ExportToExcelWithHeadersAsync(dataGridView As DataGridView, fileName As String) As Task
        Dim desktopPath As String = GetFolderPath(SpecialFolder.Desktop)
        Dim excelFilePath As String = IO.Path.Combine(desktopPath, $"{fileName} {Format(DateTime.Now, "dd-MM-yyyy hh-mm-ss")}.xlsx")

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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Async Function CalculateSummary() As Task
        Await Task.Run(Sub()
                           Dim deliverySum As Integer = 0
                           Dim salesSum As Integer = 0
                           Dim returnSum As Integer = 0
                           Dim stockSum As Integer = 0

                           For i As Integer = 0 To TG.Rows.Count - 1
                               deliverySum += Val(TG.Item(6, i).Value)
                               salesSum += Val(TG.Item(7, i).Value)
                               returnSum += Val(TG.Item(8, i).Value)
                               stockSum += Val(TG.Item(9, i).Value)
                           Next

                           Me.Invoke(Sub()
                                         LblDelivery.Text = deliverySum.ToString("0")
                                         LblSales.Text = salesSum.ToString("0")
                                         LblReturn.Text = returnSum.ToString("0")
                                         LblStock.Text = stockSum.ToString("0")
                                     End Sub)
                       End Sub)
    End Function


End Class