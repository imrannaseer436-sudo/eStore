'****************************************** Bismillah *************************************************
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class DeliveryChallanReport


    Private Rpt1 As New RptProductDeliveryReport

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub DeliveryChallanReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SQL = "select shopid,(shopname + ' - ' + shopcode) sname from shops where shopid<>" & ShopID _
            & " order by shopid"
        ESSA.LoadCombo(cmbDLoc, SQL, "sname", "shopid", "All Shops(s)")

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid", "All Vendor(s)")

        Dim OBTbl As New DataTable
        OBTbl.Columns.Add("OBID")
        OBTbl.Columns.Add("OBNAME")

        Dim DR = OBTbl.NewRow
        DR("OBID") = "deliverydate"
        DR("OBNAME") = "D.C Da"
        OBTbl.Rows.Add(DR)

        DR = OBTbl.NewRow
        DR("OBID") = "plucode"
        DR("OBNAME") = "CODE"
        OBTbl.Rows.Add(DR)

        cmbOrderBy.DataSource = OBTbl
        cmbOrderBy.DisplayMember = "OBNAME"
        cmbOrderBy.ValueMember = "OBID"

        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Sub cmbDLoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDLoc.SelectedIndexChanged

        If cmbDLoc.SelectedIndex = -1 Then Exit Sub

        SQL = "select deliverycode from deliverymaster"
        If cmbDLoc.SelectedIndex > 0 Then
            SQL &= " where deliveryto=" & IIf(cmbDLoc.SelectedValue.ToString.Contains("DataRow"), 0, cmbDLoc.SelectedValue)
        End If
        SQL &= " order by deliverydate"

        ESSA.LoadCombo(cmbDCode, SQL, "deliverycode", "")

    End Sub

    Private Sub LoadDeliveryReportVendorWise()

        SQL = "select m.deliverycode,m.deliverydate,p.plucode,d.quantity,a.category from deliverymaster m,deliverydetails d,productmaster p,productattributes a where " _
            & "m.id=d.id and d.pluid=p.pluid and p.pluid=a.pluid and m.deliveryfrom=" & ShopID & " and m.deliveryto=" & cmbDLoc.SelectedValue

        If cmbVendor.SelectedIndex > 0 Then
            SQL &= " and p.vendorid=" & cmbVendor.SelectedValue
        End If

        If txtCode.Text.Trim.Length > 0 Then
            SQL &= " and p.plucode='" & txtCode.Text.Trim & "'"
        End If

        SQL &= " order by " & cmbOrderBy.SelectedValue

        ESSA.OpenConnection()

        Using Adp As New SqlDataAdapter(SQL, Con)

            Using Tbl As New DataTable

                Adp.Fill(Tbl)
                Rpt1.SetDataSource(Tbl)
                Rpt1.SetParameterValue("Location", cmbDLoc.Text)
                CRpt.ReportSource = Rpt1

            End Using

        End Using

        Con.Close()

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        If chkVBR.Checked = True Then

            LoadDeliveryReportVendorWise()

        Else

            If cmbDCode.SelectedIndex = -1 Then
                MsgBox("Delivery code not found..!", MsgBoxStyle.Information)
                Exit Sub
            End If

            PrintDeliveryChallan(cmbDCode.Text.Trim)

        End If

    End Sub

    Private Rpt As New RptDeliveryChallan
    Private Sub PrintDeliveryChallan(deliveryCode As String)

        Using nCon As New SqlConnection(ConStr)

            nCon.Open()

            Try

                SQL = "select s.alias,s.city,m.deliverycode,m.deliverydate,p.plucode,p.pluname,p.units,d.quantity," _
                    & "s1.shopname dfrom,s2.shopname dto,a.category,m.remarks,p.id Size from deliverymaster m,shops s,shops s1,shops s2,deliverydetails d,productmaster p,productattributes a where p.pluid=a.pluid and " _
                    & "m.deliveryfrom = s.shopid And m.id = d.id And d.pluid = p.pluid And m.deliveryfrom = s1.shopid " _
                    & " And m.deliveryto = s2.shopid and m.deliverycode='" & deliveryCode & "' order by d.sno"

                Using Adp As New SqlDataAdapter(SQL, nCon)

                    Using Tbl As New DataTable
                        Adp.Fill(Tbl)
                        Rpt.SetDataSource(Tbl)
                        CRpt.ReportSource = Rpt
                    End Using

                End Using

            Catch ex As SqlException

                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try

            nCon.Close()

        End Using

    End Sub

End Class