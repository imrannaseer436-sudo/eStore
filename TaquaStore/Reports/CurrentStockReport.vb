'*********************************** Bismillah ******************************************
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class CurrentStockReport

    Private CatLvl As Short
    Private CatID(0 To 5) As Short
    Private CatDesc(0 To 5) As String
    Private Rpt As New RptStockReport

    Private Sub CurrentStockReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'ESSA.PopulateTreeview(tvCat)

        SQL = "select shopid,(shopname + ' - ' + shopcode) sname from shops" _
            & " order by shopid"
        ESSA.LoadCombo(cmbLoc, SQL, "sname", "shopid")

        cmbLoc.SelectedValue = ShopID

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid", "All Vendor(s)")

        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Sub tvCat_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvCat.AfterSelect

        If e.Node Is Nothing Then Exit Sub

        txtCat.Text = e.Node.FullPath
        CatLvl = e.Node.Level

        For i As Byte = 0 To 5
            CatID(i) = 0
            CatDesc(i) = ""
        Next

        CatID(e.Node.Level) = e.Node.Name

        Dim t = e.Node.Parent
        Do Until t Is Nothing

            CatID(t.Level) = t.Name
            CatDesc(t.Level) = t.Text
            t = t.Parent

        Loop

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        Dim StockTable As String = "v_stockpos"

        'If cmbLoc.SelectedIndex = 1 Then
        '    StockTable = "rserver.taquapos1314.dbo.v_stockpos"
        'ElseIf cmbLoc.SelectedIndex = 2 Then
        '    StockTable = "tserver.taquapos1314.dbo.v_stockpos"
        'End If

        pnlCat.Visible = False

        SQL = "select plucode,pluname,units,m.ID,v.stock,m.costprice,l.department catdesc,l.category scatdesc1,l.material scatdesc2,vm.vendorname from productmaster m,productattributes l," & StockTable & " v,vendors vm where m.pluid=v.pluid and m.pluid=l.pluid and m.pluid>0 and vm.vendorid=m.vendorid and v.location_id = " & cmbLoc.SelectedValue & ""

        If chkIZQ.Checked = False Then
            SQL &= " and v.stock>0"
        End If

        If txtCode.Text.Length > 0 Then
            SQL &= " and plucode like '%" & txtCode.Text & "%'"
        End If

        If cmbVendor.SelectedIndex > 0 Then
            SQL &= " and m.vendorid=" & cmbVendor.SelectedValue
        End If

        'If txtCat.Text <> "All Category(s)" Then

        '    If CatID(0) > 0 Then SQL &= " and catid=" & CatID(0)

        '    If CatID(1) > 0 Then SQL &= " and scatid1=" & CatID(1)

        '    If CatID(2) > 0 Then SQL &= " and scatid2=" & CatID(2)

        '    If CatID(3) > 0 Then SQL &= " and scatid3=" & CatID(3)

        '    If CatID(4) > 0 Then SQL &= " and scatid4=" & CatID(4)

        '    If CatID(5) > 0 Then SQL &= " and scatid5=" & CatID(5)

        'End If

        SQL &= " order by m.pluid"

        Using nCon As New SqlConnection(ConStr)

            nCon.Open()

            Try

                Using Adp As New SqlDataAdapter(SQL, nCon)

                    Adp.SelectCommand.CommandTimeout = 300

                    Using Tbl As New DataTable
                        Adp.Fill(Tbl)
                        Rpt.SetDataSource(Tbl)
                        Rpt.SetParameterValue("Location", ShopNm)
                        CRpt.ReportSource = Rpt
                    End Using

                End Using

            Catch ex As SqlException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

            nCon.Close()

        End Using

    End Sub

    Private Sub btnPick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPick.Click

        pnlCat.Visible = True
        tvCat.Focus()

    End Sub

    Private Sub btnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAll.Click

        txtCat.Text = "All Category(s)"

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

End Class