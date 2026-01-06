Imports System.Data.SqlClient
Public Class ProductReturnReport

    Private Rpt As New RptProductReturnReport
    Private Rpt1 As New RptReturnFromShops

    Private Sub ProductReturnReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SQL = "select deliverycode from deliverymaster where status = 0 and deliveryto = " & ShopID & " order by deliverydate"
        ESSA.LoadCombo(cmbDCode, SQL, "deliverycode")

        SQL = "select shopid,(shopname+' - '+shopcode) shopdesc from shops where shopid<>" & ShopID & " order by shopid"
        ESSA.LoadCombo(cmbLocation, SQL, "shopdesc", "shopid", "All Locations")

        SQL = "select deptid,department from tsdepartment order by department"
        ESSA.LoadComboSimple(CmbCat, SQL, "department", "deptid", "All Department(s)")

        SQL = "select catid,category from tscategory order by category"
        ESSA.LoadComboSimple(CmbSCat1, SQL, "category", "catid", "All Category(s)")

        SQL = "select catalogid,catalog from tscatalog order by catalog"
        ESSA.LoadComboSimple(cmbSCat2, SQL, "catalog", "catalogid", "All Catalog(s)")

        SQL = "select styleid,style from tsstyle order by style"
        ESSA.LoadComboSimple(cmbSCat3, SQL, "style", "styleid", "All Style(s)")

        'SQL = "select catid,catdesc from category order by catdesc"
        'ESSA.LoadComboSimple(CmbCat, SQL, "catdesc", "catid", "All Category(s)")

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid", "All Vendor(s)")

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
        DR("OBID") = "DeliveryDate"
        DR("OBNAME") = "D.C Date"
        OBTbl.Rows.Add(DR)

        cmbOrderBy.DataSource = OBTbl
        cmbOrderBy.DisplayMember = "OBNAME"
        cmbOrderBy.ValueMember = "OBID"

        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Sub ProductReturnReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlVerify, Me)

    End Sub

    Private Sub btnReturnVerifier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnVerifier.Click

        pnlVerify.Visible = True
        cmbDCode.Focus()

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim Tbl As New DataTable

        SQL = "SELECT P.PLUCODE,P.PLUNAME,D.QUANTITY,D.COSTPRICE,D.RETAILPRICE,V.VENDORNAME,GM.InvNo,GM.InvDt FROM PRODUCTMASTER P,DELIVERYDETAILS D,DELIVERYMASTER M,VENDORS V,GrnMaster GM, GrnDetails GD  " _
            & "WHERE P.PLUID=D.PLUID AND V.VENDORID = P.VENDORID AND GM.GrnNo = GD.GrnNo AND GD.PluID = P.Size AND M.ID = D.ID AND M.STATUS = 0 AND M.DELIVERYTO = " & ShopID & " AND M.DELIVERYCODE='" & cmbDCode.Text.Trim & "' ORDER BY V.VENDORNAME"

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Adp.Fill(Tbl)
        End Using
        Con.Close()

        SQL = "SELECT DELIVERYCODE,DELIVERYDATE,S.SHOPNAME FROM DELIVERYMASTER M,SHOPS S WHERE M.DELIVERYFROM=S.SHOPID AND M.STATUS = 0 AND " _
            & "M.DELIVERYCODE='" & cmbDCode.Text.Trim & "'"
        With ESSA.OpenReader(SQL)
            If .Read Then
                Rpt.SetDataSource(Tbl)
                Rpt.SetParameterValue("ReportName", "Product Return Verifier")
                Rpt.SetParameterValue("RCode", .GetString(0))
                Rpt.SetParameterValue("RDate", .GetDateTime(1).Date)
                Rpt.SetParameterValue("Location", .GetString(2))
                CRpt.ReportSource = Rpt
            End If
            .Close()
        End With

        pnlVerify.Visible = False

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        SQL = "SELECT M.DELIVERYCODE,M.DELIVERYDATE BILLDT,M.DeliveryCode UNITS,P.PLUCODE,P.PLUNAME,P.ID,D.QUANTITY,D.COSTPRICE,D.RETAILPRICE MRP,(D.QUANTITY*D.COSTPRICE) AMOUNT,l.department,l.category,l.catalog material,l.Style,l.brand,v.VENDORNAME,GM.GRNNO [INV_NO],GM.GRNDT [INV_DATE]  FROM " _
            & "DELIVERYMASTER M,DELIVERYDETAILS D,PRODUCTMASTER P,PRODUCTATTRIBUTES L,SHOPS S,VENDORS V,GRNMASTER GM,GRNDETAILS GD WHERE M.DELIVERYFROM=S.SHOPID AND M.ID=D.ID AND M.DELIVERYTO = " & ShopID & " AND D.PLUID=P.PLUID AND P.PLUID=L.PLUID " _
            & "AND P.VENDORID=V.VENDORID AND GM.GRNNO = GD.GRNNO AND GD.PLUID = D.PLUID AND CONVERT(DATE,M.DELIVERYDATE) BETWEEN '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd") & "'"

        If chkECF.Checked = True Then
            SQL &= " AND P.PLUCODE LIKE '%" & txtCode.Text.Trim & "%'"
        End If

        If cmbLocation.SelectedIndex > 0 Then
            SQL &= " AND S.SHOPID=" & cmbLocation.SelectedValue
        End If

        If ChkPending.Checked Then
            SQL &= " AND M.STATUS = 0"
        End If

        If pnlCatFilter.Visible = True Then
            If cmbVendor.SelectedIndex > 0 Then SQL &= " and p.vendorid=" & cmbVendor.SelectedValue
            If CmbCat.SelectedIndex > 0 Then SQL &= " and l.deptid=" & ESSA.GetItemValue(CmbCat)
            If CmbSCat1.SelectedIndex > 0 Then SQL &= " and l.catid=" & ESSA.GetItemValue(CmbSCat1)
            If cmbSCat2.SelectedIndex > 0 Then SQL &= " and l.catalogid=" & ESSA.GetItemValue(cmbSCat2)
            If cmbSCat3.SelectedIndex > 0 Then SQL &= " and l.styleid=" & ESSA.GetItemValue(cmbSCat3)
        End If

        SQL &= " order by " & cmbOrderBy.SelectedValue

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                Rpt1.SetDataSource(Tbl)
                Rpt1.SetParameterValue("LOCATION", cmbLocation.Text)
                Rpt1.SetParameterValue("DURATION", Format(mebFrom.Value, "dd-MMM-yyyy") & " TO " & Format(mebTo.Value, "dd-MMM-yyyy"))
                CRpt.ReportSource = Rpt1
            End Using
        End Using
        Con.Close()

    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click

        pnlVerify.Visible = False

    End Sub

    'Private Sub CmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCat.SelectedIndexChanged

    '    If CmbCat.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory1 " & IIf(CmbCat.SelectedIndex > 0, " where pvscatid=" & ESSA.GetItemValue(CmbCat), "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(CmbSCat1, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

    'Private Sub CmbSCat1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSCat1.SelectedIndexChanged

    '    If CmbSCat1.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory2 " & IIf(CmbSCat1.SelectedIndex > 0, " where pvscatid=" & ESSA.GetItemValue(CmbSCat1), "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(cmbSCat2, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

    'Private Sub cmbSCat2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSCat2.SelectedIndexChanged

    '    If cmbSCat2.SelectedIndex = -1 Then Exit Sub
    '    SQL = "select scatid,scatdesc from subcategory3 " & IIf(cmbSCat2.SelectedIndex > 0, " where pvscatid=" & ESSA.GetItemValue(cmbSCat2), "") & " order by scatdesc"
    '    ESSA.LoadComboSimple(cmbSCat3, SQL, "scatdesc", "scatid", "All Category(s)")

    'End Sub

    Private Sub btnAdvanceSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvanceSearch.Click

        pnlCatFilter.Visible = True
        cmbVendor.Focus()

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click

        btnDisplay.PerformClick()
        pnlCatFilter.Visible = False

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub chkECF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkECF.CheckedChanged

        If chkECF.Checked = True Then
            txtCode.Enabled = True
        Else
            txtCode.Clear()
            txtCode.Enabled = False
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        pnlCatFilter.Visible = False

    End Sub

End Class