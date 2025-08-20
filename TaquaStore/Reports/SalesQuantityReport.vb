'******************************** In the name of Allah, Most Mericiful, Most Compassionate ************************
Imports System.Data.SqlClient
Public Class SalesQuantityReport

    Private Rpt As New RptSalesQuantityReportDW

    Private Sub SalesQuantityReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SQL = "select shopid,(shopname+' - '+shopcode) shopdesc from shops where shopid<>" & ShopID & " order by shopid"
        ESSA.LoadCombo(cmbLocation, SQL, "shopdesc", "shopid")

        SQL = "SELECT DISTINCT DeptId,Department FROM ProductAttributes ORDER BY Department"
        ESSA.LoadCombo(cmbDept, SQL, "Department", "DeptId", "All Department(s)")

        SQL = "SELECT DISTINCT CatId,Category FROM ProductAttributes ORDER BY Category"
        ESSA.LoadCombo(cmbCat, SQL, "Category", "CatId", "All Category(s)")

        SQL = "SELECT DISTINCT StyleId,Style FROM ProductAttributes ORDER BY Style"
        ESSA.LoadCombo(cmbStyle, SQL, "Style", "StyleId", "All Style(s)")

        SQL = "SELECT DISTINCT CatalogId,Catalog FROM ProductAttributes ORDER BY Catalog"
        ESSA.LoadCombo(CmbCatalog, SQL, "Catalog", "CatalogId", "All Catalog(s)")

        SQL = "select DISTINCT vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid", "All Vendor(s)")

        'SQL = "select catid,catdesc from category order by catdesc"
        'ESSA.LoadComboSimple(cmbDept, SQL, "catdesc", "catid", "All Category(s)")        

        Dim OBTbl As New DataTable
        OBTbl.Columns.Add("OBID")
        OBTbl.Columns.Add("OBNAME")

        Dim DR = OBTbl.NewRow
        DR("OBID") = "plucode"
        DR("OBNAME") = "CODE"
        OBTbl.Rows.Add(DR)


        DR = OBTbl.NewRow
        DR("OBID") = "vendorname"
        DR("OBNAME") = "VENDOR NAME"
        OBTbl.Rows.Add(DR)

        DR = OBTbl.NewRow
        DR("OBID") = "billdt"
        DR("OBNAME") = "Bill Date"
        OBTbl.Rows.Add(DR)

        cmbOrderBy.DataSource = OBTbl
        cmbOrderBy.DisplayMember = "OBNAME"
        cmbOrderBy.ValueMember = "OBID"

        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        'SQL = "select p.plucode,p.pluname,p.id,sum(d.qty) 'Quantity',convert(decimal(10,2),d.ORate) 'MRP',convert(decimal(10,2),sum(d.amount)) 'Amount',convert(decimal(10,2),sum(d.DisAmt)) 'Discount',l.CatDesc,l.SCatDesc1,l.SCatDesc2,l.SCatDesc3,l.SCatDesc4,v.vendorname,d.billdt,p.costprice,d.disperc disp from " _
        '    & "productmaster p,billdetails d,productlevels l,vendors v where p.vendorid=v.vendorid and p.pluid=l.pluid and p.pluid=d.pluid and d.shopid=" & cmbLocation.SelectedValue _
        '    & " and d.billdt between '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' and '" & Format(mebTo.Value, "yyyy-MM-dd") & "'"
        SQL = "select p.plucode,p.pluname,p.id,d.qty 'Quantity',convert(decimal(10,2),d.ORate) 'MRP',convert(decimal(10,2),sum(d.amount)) 'Amount',convert(decimal(10,2),sum(d.DisAmt)) 'Discount',A.Department,A.Category,A.Style,A.Catalog [Material],V.VendorName,d.billdt,d.qty * p.costprice costprice,d.disperc disp from " _
            & "productmaster p,billdetails d,ProductAttributes A,vendors v where p.vendorid=v.vendorid and p.pluid=A.pluid and p.pluid=d.pluid and d.shopid=" & cmbLocation.SelectedValue _
            & " and d.billdt between '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' and '" & Format(mebTo.Value, "yyyy-MM-dd") & "'"

        If pnlCatFilter.Visible = True Then
            If cmbVendor.SelectedIndex > 0 Then SQL &= " and p.vendorid=" & cmbVendor.SelectedValue
            'If cmbDept.SelectedIndex > 0 Then SQL &= " and l.catid=" & ESSA.GetItemValue(cmbDept)
            'If cmbCat.SelectedIndex > 0 Then SQL &= " and l.scatid1=" & ESSA.GetItemValue(cmbCat)
            'If cmbStyle.SelectedIndex > 0 Then SQL &= " and l.scatid2=" & ESSA.GetItemValue(cmbStyle)
            'If cmbMaterial.SelectedIndex > 0 Then SQL &= " and l.scatid3=" & ESSA.GetItemValue(cmbMaterial)

            If cmbDept.SelectedIndex > 0 Then SQL &= " and A.DeptId =" & cmbDept.SelectedValue
            If cmbCat.SelectedIndex > 0 Then SQL &= " and A.CatId =" & cmbCat.SelectedValue
            If cmbStyle.SelectedIndex > 0 Then SQL &= " and A.StyleId =" & cmbStyle.SelectedValue
            If CmbCatalog.SelectedIndex > 0 Then SQL &= " and A.CatalogId =" & CmbCatalog.SelectedValue

            If chkFGW.Checked = True Then
                SQL &= " and d.pluid in (select distinct pluid from grndetails where grnno=" & Val(CMBGrn.Text) & ")"
            End If

        End If

        SQL &= " group by p.plucode,p.pluname,p.id,d.qty,d.ORate,Department,Category,Style,Catalog,v.vendorname,d.billdt,p.costprice,d.disperc" _
            & " order by " & cmbOrderBy.SelectedValue

        'SQL = "select p.plucode,p.pluname,p.id,d.qty 'Quantity',convert(decimal(10,2),d.ORate) 'MRP',convert(decimal(10,2),sum(d.amount)) 'Amount',convert(decimal(10,2),sum(d.DisAmt)) 'Discount',A.Department,A.Category,A.Style,A.Material,V.VendorName,d.billdt,p.costprice,d.disperc disp from " _
        '    & "productmaster p,billdetails d,ProductAttributes A,vendors v where p.vendorid=v.vendorid and p.pluid=A.pluid and p.pluid=d.pluid and d.shopid=" & cmbLocation.SelectedValue _
        '    & " and d.billdt between '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' and '" & Format(mebTo.Value, "yyyy-MM-dd") & "'"

        'If pnlCatFilter.Visible = True Then
        '    If cmbVendor.SelectedIndex > 0 Then SQL &= " and p.vendorid=" & cmbVendor.SelectedValue
        '    'If cmbDept.SelectedIndex > 0 Then SQL &= " and l.catid=" & ESSA.GetItemValue(cmbDept)
        '    'If cmbCat.SelectedIndex > 0 Then SQL &= " and l.scatid1=" & ESSA.GetItemValue(cmbCat)
        '    'If cmbStyle.SelectedIndex > 0 Then SQL &= " and l.scatid2=" & ESSA.GetItemValue(cmbStyle)
        '    'If cmbMaterial.SelectedIndex > 0 Then SQL &= " and l.scatid3=" & ESSA.GetItemValue(cmbMaterial)

        '    If cmbDept.SelectedIndex > 0 Then SQL &= " and A.DeptId =" & cmbDept.SelectedValue
        '    If cmbCat.SelectedIndex > 0 Then SQL &= " and A.CatId =" & cmbCat.SelectedValue
        '    If cmbStyle.SelectedIndex > 0 Then SQL &= " and A.StyleId =" & cmbStyle.SelectedValue
        '    If cmbMaterial.SelectedIndex > 0 Then SQL &= " and A.MaterialId =" & cmbMaterial.SelectedValue

        '    If chkFGW.Checked = True Then
        '        SQL &= " and d.pluid in (select distinct pluid from grndetails where grnno=" & Val(CMBGrn.Text) & ")"
        '    End If

        'End If

        'SQL &= " group by p.plucode,p.pluname,p.id,d.qty,d.ORate,Department,Category,Style,Material,v.vendorname,d.billdt,p.costprice,d.disperc" _
        '    & " order by " & cmbOrderBy.SelectedValue


        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                Rpt.SetDataSource(Tbl)
                Rpt.SetParameterValue("LOCATION", cmbLocation.Text)
                Rpt.SetParameterValue("DURATION", Format(mebFrom.Value, "dd-MMM-yyyy") & " TO " & Format(mebTo.Value, "dd-MMM-yyyy"))
                CRpt.ReportSource = Rpt
            End Using
        End Using
        Con.Close()

        'ESSA.OpenConnection()
        'Using Adp As New SqlDataAdapter(SQL, Con)
        '    Using Tbl As New DataTable
        '        Adp.Fill(Tbl)
        '        TG.DataSource = Nothing
        '        TG.DataSource = Tbl
        '        TG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        '    End Using
        'End Using
        'Con.Close()

    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click

        pnlCatFilter.Visible = False

    End Sub

    'Private Sub CmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged

    '    If cmbDept.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory1 " & IIf(cmbDept.SelectedIndex > 0, " where pvscatid=" & ESSA.GetItemValue(cmbDept), "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(cmbCat, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

    'Private Sub CmbSCat1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged

    '    If cmbCat.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory2 " & IIf(cmbCat.SelectedIndex > 0, " where pvscatid=" & ESSA.GetItemValue(cmbCat), "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(cmbStyle, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

    'Private Sub cmbSCat2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStyle.SelectedIndexChanged

    '    If cmbStyle.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory3 " & IIf(cmbStyle.SelectedIndex > 0, " where pvscatid=" & ESSA.GetItemValue(cmbStyle), "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(cmbMaterial, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

    Private Sub btnAdvanceSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvanceSearch.Click

        pnlCatFilter.Visible = True
        cmbVendor.Focus()

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click

        If CMBGrn.Items.Count = 0 And chkFGW.Checked = True Then
            xMessageBox.ShowMessage("GRN Number not selected..!", "GRN Error..!", xMessageBox.MessageBoxStyle.OKOnly)
            Exit Sub
        End If

        btnDisplay.PerformClick()
        pnlCatFilter.Visible = False

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub btnLoadGRN_Click(sender As Object, e As EventArgs) Handles btnLoadGRN.Click

        If cmbVendor.SelectedIndex > 0 Then
            SQL = "SELECT grnno FROM GRNMASTER WHERE VENDORID=" & cmbVendor.SelectedValue & " ORDER BY GRNNO"
            ESSA.LoadCombo(CMBGrn, SQL, "grnno")
        End If

    End Sub

    Private Sub chkFGW_CheckedChanged(sender As Object, e As EventArgs) Handles chkFGW.CheckedChanged

        btnLoadGRN.Visible = chkFGW.Checked
        lblGRN.Visible = chkFGW.Checked
        CMBGrn.Visible = chkFGW.Checked

    End Sub

    Private Sub pnlCatFilter_Paint(sender As Object, e As PaintEventArgs) Handles pnlCatFilter.Paint

    End Sub

    Private Sub cmbVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVendor.SelectedIndexChanged

    End Sub
End Class