Imports System.Data.SqlClient
Imports Zuby.ADGV
Imports OfficeOpenXml

Public Class frmStockReportNew

    Private Bind As New BindingSource
    Private sTable As New DataTable

    Private Sub LoadAttributes()

        SQL = "SELECT ShopId,ShopName + '-' + ShopCode Name FROM Shops  ORDER BY ShopId"
        ESSA.LoadCombo(CmbLocation, SQL, "Name", "ShopId")

        SQL = "SELECT BrandId,Brand FROM TSBrand  ORDER BY Brand"
        ESSA.LoadCombo(cmbBrand, SQL, "Brand", "BrandId", "All Brands")

        SQL = "SELECT CatalogId,Catalog FROM TSCatalog  ORDER BY Catalog"
        ESSA.LoadCombo(cmbCatalog, SQL, "Catalog", "CatalogId", "All Catalogs")

        SQL = "SELECT CatId,Category FROM TSCategory  ORDER BY Category"
        ESSA.LoadCombo(cmbCat, SQL, "Category", "CatId", "All Categories")

        SQL = "SELECT  ColorId,Color FROM  TSColor WHERE IsActive=1 ORDER BY Color"
        ESSA.LoadCombo(cmbColor, SQL, "Color", "ColorId", "All Colors")

        SQL = "SELECT  DeptId,Department FROM   TSDepartment  ORDER BY Department"
        ESSA.LoadCombo(cmbDept, SQL, "Department", "DeptId", "All Departments")

        SQL = "SELECT  MaterialId,Material FROM   TSMaterial  ORDER BY Material"
        ESSA.LoadCombo(cmbMts, SQL, "Material", "MaterialId", "All Materials")

        SQL = "SELECT  PatternId,Pattern FROM   TSPattern  ORDER BY Pattern"
        ESSA.LoadCombo(cmbPattern, SQL, "Pattern", "PatternId", "All Pattern")

        SQL = "SELECT  SleeveId,Sleeve FROM   TSSleeve  ORDER BY Sleeve"
        ESSA.LoadCombo(cmbSleeve, SQL, "Sleeve", "SleeveId", "All Sleeves")

        SQL = "SELECT  StyleId,Style  FROM   TSStyle  ORDER BY Style "
        ESSA.LoadCombo(cmbStyle, SQL, "Style", "StyleId", "All Styles")

        SQL = "SELECT VendorId, VendorName FROM Vendors ORDER BY VendorName"
        ESSA.LoadCombo(cmbVendor, SQL, "VendorName", "VendorId", "All Vendors")

        'For newly added type attribute
        SQL = "SELECT TypeId, Type FROM TSType ORDER BY Type"
        ESSA.LoadCombo(cmbType, SQL, "Type", "TypeId", "All Types")

    End Sub
    Private Sub ResetAttributes()

        CmbLocation.SelectedIndex = 0
        cmbBrand.SelectedIndex = 0
        cmbCatalog.SelectedIndex = 0
        cmbCat.SelectedIndex = 0
        cmbColor.SelectedIndex = 0
        cmbDept.SelectedIndex = 0
        cmbMts.SelectedIndex = 0
        cmbPattern.SelectedIndex = 0
        cmbSleeve.SelectedIndex = 0
        cmbStyle.SelectedIndex = 0
        cmbVendor.SelectedIndex = 0
        cmbType.SelectedIndex = 0

    End Sub

    Private Sub LoadData(iSql As String)

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(iSql, Con)
            sTable.Clear()
            Adp.Fill(sTable)
            Bind.DataSource = Nothing
            Bind.DataSource = sTable

            TG.CleanFilterAndSort()
            TG.DataSource = Nothing
            TG.DataSource = Bind.DataSource
        End Using
        Con.Close()

        TG.Columns(0).Visible = False
        getTotalStock()

    End Sub

    Private Sub getTotalStock()

        Dim totalQuantity As Double = 0

        For i As Integer = 0 To TG.Rows.Count - 1
            totalQuantity += Val(TG.Item(4, i).Value)
        Next

        lblStock.Text = totalQuantity

    End Sub
    Private Sub btnApplyFilter_Click(sender As Object, e As EventArgs) Handles btnApplyFilter.Click

        pnlLoading.Show() : pnlLoading.Refresh()

        Dim Db As String = "V_StockPos"
        'If rbWH.Checked Then
        '    Db = "V_StockPos"
        'ElseIf rbL2.Checked Then
        '    Db = "TSERVER.TAQUAPOS1314.DBO.V_StockPos"
        'ElseIf rbL4.Checked Then
        '    Db = "TSERVER2.TAQUAPOS1314.DBO.V_StockPos"
        'End If

        SQL = "SELECT " _
            & "P.PluId, P.Plucode, P.Pluname, P.Units, S.Stock," _
            & "P.Id, PM.CostPrice, PM.RetailPrice, PM.Discount, V.VendorName," _
            & "A.Department, A.Category, A.Style, A.Pattern, A.Material, A.Color," _
            & "A.Sleeve, A.Brand, A.Catalog, A.Type " _
            & "FROM " & Db & " S, ProductMaster P, ProductAttributes A, Vendors V,PriceMaster PM " _
            & "WHERE S.PluID = P.PluId AND P.PluId = A.PluId AND P.VendorId = V.VendorId AND PM.Pluid = S.Pluid AND PM.ShopId = " & CmbLocation.SelectedValue & "  AND S.location_id = " & CmbLocation.SelectedValue & " "

        If chkEZS.Checked Then
            SQL &= " AND S.Stock>0"
        End If

        If cmbDept.SelectedIndex > 0 Then SQL &= " AND A.DeptId=" & cmbDept.SelectedValue
        If cmbCat.SelectedIndex > 0 Then SQL &= " AND A.CatId=" & cmbCat.SelectedValue
        If cmbStyle.SelectedIndex > 0 Then SQL &= " AND A.StyleId=" & cmbStyle.SelectedValue
        If cmbPattern.SelectedIndex > 0 Then SQL &= " AND A.PatternId=" & cmbPattern.SelectedValue
        If cmbMts.SelectedIndex > 0 Then SQL &= " AND A.MaterialId=" & cmbMts.SelectedValue
        If cmbColor.SelectedIndex > 0 Then SQL &= " AND A.ColorId=" & cmbColor.SelectedValue
        If cmbSleeve.SelectedIndex > 0 Then SQL &= " AND A.SleeveId=" & cmbSleeve.SelectedValue
        If cmbBrand.SelectedIndex > 0 Then SQL &= " AND A.BrandId=" & cmbBrand.SelectedValue
        If cmbCatalog.SelectedIndex > 0 Then SQL &= " AND A.CatalogId=" & cmbCatalog.SelectedValue
        If cmbType.SelectedIndex > 0 Then SQL &= " AND A.TypeId=" & cmbType.SelectedValue
        If cmbVendor.SelectedIndex > 0 Then SQL &= " AND V.VendorId=" & cmbVendor.SelectedValue

        LoadData(SQL)

        pnlLoading.Hide()
        pnlFilter.Hide()

    End Sub
    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click

        pnlFilter.Hide()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadAttributes()
        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlFilter, Me)
        ESSA.MovetoCenter(pnlLoading, Me)

    End Sub

    Private Sub frmStockReportNew_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            If pnlFilter.Visible Then pnlFilter.Hide() : Exit Sub
            If MsgBox("Do you want to exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Close()
        End If

    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click

        pnlFilter.Show()
        cmbDept.Focus()

    End Sub

    Private Sub TG_SortStringChanged(sender As Object, e As AdvancedDataGridView.SortEventArgs) Handles TG.SortStringChanged

        Bind.Sort = TG.SortString

    End Sub

    Private Sub TG_FilterStringChanged(sender As Object, e As AdvancedDataGridView.FilterEventArgs) Handles TG.FilterStringChanged

        Bind.Filter = TG.FilterString
        getTotalStock()

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        If TG.Rows.Count = 0 Then
            MsgBox("No data to export!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If TG.Rows.Count > 0 Then

            Dim ofd1 As New SaveFileDialog
            ofd1.FileName = "StockReport.xlsx"
            ofd1.Filter = "Excel File (*.xlsx) | *.xlsx"
            If ofd1.ShowDialog = DialogResult.No Then Exit Sub

            Dim dTable = sTable.DefaultView.ToTable()

            Using pck As New ExcelPackage(New IO.FileInfo(ofd1.FileName))
                Dim ws As ExcelWorksheet = pck.Workbook.Worksheets.Add("Sheet1")
                ws.Cells("A1").LoadFromDataTable(dTable, True)
                pck.Save()
            End Using

            Process.Start(ofd1.FileName)

        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        MainWindowX.CloseTab(Me.Tag)

    End Sub

End Class