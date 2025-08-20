'******************************************* Bismillah ******************************************
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class SalesQuantityReportCW

    Private LSERVER As String = ""
    Private DBASE As String = ""

    Private Sub DeliveryValueReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SQL = "select shopid,(shopname + ' - ' + shopcode) sname from shops where shopid<>" & ShopID _
           & " order by shopid"
        ESSA.LoadCombo(cmbBranch, SQL, "sname", "shopid")

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid", "All Vendor(s)")

        SQL = "select CatId,Category from TSCategory order by Category"
        ESSA.LoadCombo(cmbCategory, SQL, "Category", "CatId", "All Category(s)")

        ESSA.EnableContainsFilterForAll(Me)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        Dim Rpt As New RptSalesQuantityReportCW
        Dim Rpt1 As New RptSalesQuantityReportCWNew

        If chkCWN.Checked = False Then

            If chkIncludeStock.Checked = True Then

                GetConnectionString()

                SQL = "SELECT V.VENDORNAME,L.Category 'CATDESC1',SUM(D.QTY) QUANTITY,SUM(V1.STOCK) CSTOCK FROM VENDORS V,BILLDETAILS D,PRODUCTMASTER P,GrnMaster GM,GrnDetails GD,ProductAttributes L," & LSTBL("V_STOCKPOS", "V1") _
                    & " WHERE P.PLUID=L.PLUID AND D.PLUID=P.PLUID AND D.PLUID=V1.PLUID AND GM.GrnNo = GD.GrnNo AND GD.PluId = P.Size AND GM.VENDORID=V.VENDORID AND D.SHOPID=" & cmbBranch.SelectedValue & " " _
                    & "AND D.BILLDT BETWEEN '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd") & "'"

                If cmbVendor.SelectedIndex > 0 Then
                    SQL &= " AND GM.VENDORID=" & cmbVendor.SelectedValue
                End If

                If cmbCategory.SelectedIndex > 0 Then
                    SQL &= " AND L.CatId=" & cmbCategory.SelectedValue
                End If

                SQL &= " GROUP BY V.VENDORNAME,L.Category ORDER BY V.VENDORNAME"

            Else

                SQL = "SELECT V.VENDORNAME,L.Category 'CATDESC1',SUM(D.QTY) QUANTITY FROM VENDORS V,BILLDETAILS D,PRODUCTMASTER P,GrnMaster GM,GrnDetails GD,ProductAttributes L " _
                    & "WHERE P.PLUID=L.PLUID AND D.PLUID=P.PLUID AND GM.GrnNo = GD.GrnNo AND GD.PluId = P.Size AND GM.VENDORID=V.VENDORID AND D.SHOPID=" & cmbBranch.SelectedValue & " " _
                    & "AND D.BILLDT BETWEEN '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd") & "'"

                If cmbVendor.SelectedIndex > 0 Then
                    SQL &= " AND GM.VENDORID=" & cmbVendor.SelectedValue
                End If

                If cmbCategory.SelectedIndex > 0 Then
                    SQL &= " AND L.CatId=" & cmbCategory.SelectedValue
                End If

                SQL &= " GROUP BY V.VENDORNAME,L.Category ORDER BY V.VENDORNAME"

            End If

        Else

            If chkTill.Checked = True Then

                SQL = "SELECT A.VENDORNAME,A.CATDESC1,A.QUANTITY,B.DQUANTITY FROM " _
                    & "(SELECT V.VENDORNAME,L.Category 'CATDESC1',SUM(D.QTY) QUANTITY,L.CATID,GM.VENDORID FROM VENDORS V,BILLDETAILS D,PRODUCTMASTER P,GrnMaster GM,GrnDetails GD,ProductAttributes L " _
                    & "WHERE P.PLUID=L.PLUID AND D.PLUID=P.PLUID AND GM.GrnNo = GD.GrnNo AND GD.PluId = P.Size AND GM.VENDORID=V.VENDORID AND D.SHOPID=" & cmbBranch.SelectedValue & " " _
                    & "AND D.BILLDT<='" & Format(mebTo.Value, "yyyy-MM-dd") & "'"

                If cmbVendor.SelectedIndex > 0 Then
                    SQL &= " AND GM.VENDORID=" & cmbVendor.SelectedValue
                End If

                If cmbCategory.SelectedIndex > 0 Then
                    SQL &= " AND L.Category =" & cmbCategory.SelectedValue
                End If

                SQL &= " GROUP BY V.VENDORNAME,L.Category,L.CatId,V.VENDORID) A LEFT OUTER JOIN (" _
                    & "SELECT VENDORID,CatId,QTY DQUANTITY FROM V_DELIVERYQUANTITYCW WHERE " _
                    & "DELIVERYTO=" & cmbBranch.SelectedValue & ") B ON A.CATID=B.CATID AND A.VENDORID=B.VENDORID ORDER BY A.VENDORNAME"

            Else

                SQL = "SELECT V.VENDORNAME,L.CATEGORY 'CATDESC1',SUM(D.QTY) QUANTITY FROM VENDORS V,BILLDETAILS D,PRODUCTMASTER P,GrnMaster GM,GrnDetails GD,PRODUCTATTRIBUTES L " _
                    & "WHERE P.PLUID=L.PLUID AND D.PLUID=P.PLUID AND GM.GrnNo = GD.GrnNo AND GD.PluId = P.Size AND GM.VENDORID=V.VENDORID AND D.SHOPID=" & cmbBranch.SelectedValue _
                    & " AND D.BILLDT BETWEEN '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd") & "'"

                If cmbVendor.SelectedIndex > 0 Then
                    SQL &= " AND GM.VENDORID=" & cmbVendor.SelectedValue
                End If

                If cmbCategory.SelectedIndex > 0 Then
                    SQL &= " AND L.CATID=" & cmbCategory.SelectedValue
                End If

                SQL &= " GROUP BY V.VENDORNAME,L.Category ORDER BY V.VENDORNAME"

            End If

        End If

        If chkCWN.Checked = False Then

            ESSA.OpenConnection()
            Using Adp As New SqlDataAdapter(SQL, Con)
                Adp.SelectCommand.CommandTimeout = 120
                Using Tbl As New DataTable
                    Adp.Fill(Tbl)
                    Rpt.SetDataSource(Tbl)
                    Rpt.SetParameterValue("LOCATION", cmbBranch.Text)
                    Rpt.SetParameterValue("DURATION", Format(mebFrom.Value, "dd-MMM-yyyy") & " TO " & Format(mebTo.Value, "dd-MMM-yyyy"))
                    CRpt.ReportSource = Rpt
                End Using
            End Using
            Con.Close()

        Else

            ESSA.OpenConnection()
            Using Adp As New SqlDataAdapter(SQL, Con)
                Adp.SelectCommand.CommandTimeout = 120
                Using Tbl As New DataTable
                    Adp.Fill(Tbl)
                    Rpt1.SetDataSource(Tbl)
                    Rpt1.SetParameterValue("LOCATION", cmbBranch.Text)
                    Rpt1.SetParameterValue("DURATION", Format(mebFrom.Value, "dd-MMM-yyyy") & " TO " & Format(mebTo.Value, "dd-MMM-yyyy"))
                    CRpt.ReportSource = Rpt1
                End Using
            End Using
            Con.Close()

        End If

    End Sub

    Private Sub GetConnectionString()

        SQL = "select * from locationsettings where shopid=" & cmbBranch.SelectedValue
        With ESSA.OpenReader(SQL)
            If .Read Then
                LSERVER = .GetString(1)
                DBASE = .GetString(4)
            End If
            .Close()
        End With

    End Sub

    Private Function LSTBL(ByVal Tbl As String, ByVal Alis As String) As String
        LSTBL = LSERVER & "." & DBASE & ".DBO." & Tbl & " " & Alis
    End Function


End Class