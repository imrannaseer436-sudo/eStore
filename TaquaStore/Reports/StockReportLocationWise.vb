'******************************************** Bismillah ********************************************
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class StockReportLocationWise

    Private LSERVER As String = ""
    Private DBASE As String = ""
    Private Rpt As New RptStockReportLW

    Private Sub StockReportLocationWise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'SQL = "select shopid,(shopname+' - '+shopcode) shopdesc from shops where shopid<>" & ShopID & " order by shopid"
        'ESSA.LoadCombo(cmbLocation, SQL, "shopdesc", "shopid")

        SQL = "select shopid,(shopname+' - '+shopcode) shopdesc from shops order by shopid"
        ESSA.LoadCombo(cmbLocation, SQL, "shopdesc", "shopid")

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid", "All Vendor(s)")

        SQL = "SELECT DISTINCT DeptId,Department FROM ProductAttributes ORDER BY Department"
        ESSA.LoadCombo(cmbDept, SQL, "Department", "DeptId", "All Department(s)")

        SQL = "SELECT DISTINCT CatId,Category FROM ProductAttributes ORDER BY Category"
        ESSA.LoadCombo(cmbCat, SQL, "Category", "CatId", "All Category(s)")

        SQL = "SELECT DISTINCT StyleId,Style FROM ProductAttributes ORDER BY Style"
        ESSA.LoadCombo(cmbStyle, SQL, "Style", "StyleId", "All Style(s)")

        SQL = "SELECT DISTINCT CatalogId,Catalog FROM ProductAttributes ORDER BY Catalog"
        ESSA.LoadCombo(cmbMaterial, SQL, "Catalog", "CatalogId", "All Catalog(s)")

        ESSA.EnableContainsFilterForAll(Me)

        'SQL = "select catid,catdesc from category order by catdesc"
        'ESSA.LoadCombo(cmbDept, SQL, "catdesc", "catid", "All Category(s)")

        'SQL = "select scatid,scatdesc from subcategory1 order by scatdesc"
        'ESSA.LoadCombo(cmbCategory, SQL, "scatdesc", "scatid", "All Category(s)")

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Function LSTBL(ByVal Tbl As String, ByVal Alis As String) As String
        LSTBL = LSERVER & "." & DBASE & ".DBO." & Tbl & " " & Alis
    End Function

    Private Sub DeliveryBasedStock()

        'SQL = "select p.plucode,p.pluname,p.units,v.stock,p.costprice,p.retailprice,l.catdesc,l.scatdesc1,l.scatdesc2,vd.vendorname,p.id from " & LSTBL("Vendors", "vd") & "," & LSTBL("ProductMaster", "p") & "," & LSTBL("v_stockpos", "v") & "," & LSTBL("productlevels", "l") & " where " _
        '    & "p.pluid=v.pluid and p.pluid=l.pluid and p.vendorid=vd.vendorid and p.pluid in (" _
        '    & "select distinct d.pluid from " & LSTBL("receivedmaster", "m") & "," & LSTBL("receiveddetails", "d") & " where m.deliverycode=d.deliverycode and " _
        '    & "m.deliveryto=" & cmbLocation.SelectedValue & " and m.deliverydate between '" _
        '    & Format(mebFrDt.Value, "yyyy-MM-dd") & "' and '" & Format(mebToDt.Value, "yyyy-MM-dd") & "')"

        'GetConnectionString()

        SQL = "select p.plucode,p.pluname,p.units,v.stock,p.costprice,p.retailprice,A.Department,A.Category,A.Style,A.Catalog Material,vd.vendorname,p.id from Vendors vd,ProductMaster p,v_stockpos v,ProductAttributes A where " _
            & "p.pluid=v.pluid and p.pluid=A.pluid and p.vendorid=vd.vendorid and v.location_id = " & cmbLocation.SelectedValue & " and p.pluid in (" _
            & "select distinct d.pluid from receivedmaster m,receiveddetails d where m.id=d.id and " _
            & "m.deliveryto=" & cmbLocation.SelectedValue & " and m.deliverydate between '" _
            & Format(mebFrDt.Value, "yyyy-MM-dd") & "' and '" & Format(mebToDt.Value, "yyyy-MM-dd") & "')"

        If cmbVendor.SelectedIndex > 0 Then
            SQL &= " and p.vendorid=" & cmbVendor.SelectedValue
        End If

        If cmbDept.SelectedIndex > 0 Then
            SQL &= " and A.DeptId=" & cmbDept.SelectedValue
        End If

        If cmbCat.SelectedIndex > 0 Then
            SQL &= " and A.CatId=" & cmbCat.SelectedValue
        End If

        If cmbStyle.SelectedIndex > 0 Then
            SQL &= " and A.StyleId=" & cmbStyle.SelectedValue
        End If

        If cmbMaterial.SelectedIndex > 0 Then
            SQL &= " and A.CatalogId=" & cmbMaterial.SelectedValue
        End If

        If chkEZQ.Checked = True Then
            SQL &= " and v.stock>0"
        End If

        SQL &= " order by p.plucode"

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        'GetConnectionString()

        If chkEDBF.Checked = True Then
            DeliveryBasedStock()
        ElseIf chkUseDateWise.Checked = False Then

            SQL = "select p.plucode,p.pluname,p.units,v2.stock,p.costprice,p.retailprice,A.Department,A.Category,A.Style,A.Catalog Material,v.vendorname,p.id from Vendors v,ProductMaster p,v_stockpos v2,ProductAttributes A where " _
                & "p.pluid=v2.pluid and p.pluid=A.pluid and v.vendorid=p.vendorid and v2.location_id = " & cmbLocation.SelectedValue & ""

            If cmbVendor.SelectedIndex > 0 Then
                SQL &= " and p.vendorid=" & cmbVendor.SelectedValue
            End If

            If cmbDept.SelectedIndex > 0 Then
                SQL &= " and A.DeptId=" & cmbDept.SelectedValue
            End If

            If cmbCat.SelectedIndex > 0 Then
                SQL &= " and A.CatId=" & cmbCat.SelectedValue
            End If

            If cmbStyle.SelectedIndex > 0 Then
                SQL &= " and A.StyleId=" & cmbStyle.SelectedValue
            End If

            If cmbMaterial.SelectedIndex > 0 Then
                SQL &= " and A.CatalogId=" & cmbMaterial.SelectedValue
            End If

            'If cmbDept.SelectedIndex > 0 Then
            '    SQL &= " and l.catid=" & cmbDept.SelectedValue
            'End If

            'If cmbCat.SelectedIndex > 0 Then
            '    SQL &= " and l.scatid1=" & ESSA.GetItemValue(cmbCat)
            'End If

            'If cmbStyle.SelectedIndex > 0 Then
            '    SQL &= " and l.scatid2=" & ESSA.GetItemValue(cmbStyle)
            'End If

            'If cmbMaterial.SelectedIndex > 0 Then
            '    SQL &= " and l.scatid3=" & ESSA.GetItemValue(cmbMaterial)
            'End If

            If chkEZQ.Checked = True Then
                SQL &= " and v2.stock>0"
            End If

            SQL &= " order by p.plucode"

        Else

            SQL = "select p.plucode,p.pluname,p.units,sum(v2.rcpt-v2.sales) qty,p.costprice,p.retailprice,A.Department,A.Category,A.Style,A.Catalog Material,v.vendorname,p.id from Vendors v,ProductMaster p,v_currentstockpos v2,ProductAttributes A where " _
                & "p.pluid=v.pluid and p.pluid=A.pluid and v.billdt<='" & Format(mebTillDt.Value, "yyyy-MM-dd") & "' and v.vendorid=p.vendorid and v2.location_id = " & cmbLocation.SelectedValue & ""

            If cmbVendor.SelectedIndex > 0 Then
                SQL &= " and p.vendorid=" & cmbVendor.SelectedValue
            End If

            If cmbDept.SelectedIndex > 0 Then
                SQL &= " and A.DeptId=" & cmbDept.SelectedValue
            End If

            If cmbCat.SelectedIndex > 0 Then
                SQL &= " and A.CatId=" & cmbCat.SelectedValue
            End If

            If cmbStyle.SelectedIndex > 0 Then
                SQL &= " and A.StyleId=" & cmbStyle.SelectedValue
            End If

            If cmbMaterial.SelectedIndex > 0 Then
                SQL &= " and A.CatalogId=" & cmbMaterial.SelectedValue
            End If

            'If cmbCat.SelectedIndex > 0 Then
            '    SQL &= " and l.scatid1=" & ESSA.GetItemValue(cmbCat)
            'End If

            'If cmbStyle.SelectedIndex > 0 Then
            '    SQL &= " and l.scatid2=" & ESSA.GetItemValue(cmbStyle)
            'End If

            'If cmbMaterial.SelectedIndex > 0 Then
            '    SQL &= " and l.scatid3=" & ESSA.GetItemValue(cmbMaterial)
            'End If

            SQL &= " group by p.plucode,p.pluname,p.units,p.costprice,p.retailprice,A.Department,A.Category,A.Style,A.Catalog,v.vendorname"

            If chkEZQ.Checked = True Then
                SQL &= " having sum(v2.qty)>0"
            End If

            SQL &= " order by p.plucode"

        End If

        ESSA.OpenConnection()

        Try

            Using Adp As New SqlDataAdapter(SQL, Con)
                Using Tbl As New DataTable
                    Adp.Fill(Tbl)
                    Rpt.SetDataSource(Tbl)
                    Rpt.SetParameterValue("LOCATION", cmbLocation.Text)
                    CRpt.ReportSource = Rpt
                End Using
            End Using

        Catch ex As SqlException
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub GetConnectionString()

        SQL = "select * from locationsettings where shopid=" & cmbLocation.SelectedValue
        With ESSA.OpenReader(SQL)
            If .Read Then
                LSERVER = .GetString(1)
                DBASE = .GetString(4)
            End If
            .Close()
        End With

    End Sub

    'Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDept.SelectedIndexChanged

    '    If cmbDept.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory1 " & IIf(cmbDept.SelectedIndex > 0, " where pvscatid=" & cmbDept.SelectedValue, "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(cmbCat, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

    'Private Sub cmbSCat1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCat.SelectedIndexChanged

    '    If cmbCat.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory2 " & IIf(cmbCat.SelectedIndex > 0, " where pvscatid=" & ESSA.GetItemValue(cmbCat), "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(cmbStyle, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

    'Private Sub cmbSCat2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStyle.SelectedIndexChanged

    '    If cmbStyle.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory3 " & IIf(cmbStyle.SelectedIndex > 0, " where pvscatid=" & ESSA.GetItemValue(cmbStyle), "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(cmbMaterial, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

End Class