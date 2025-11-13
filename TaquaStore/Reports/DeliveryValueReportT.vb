'******************************** In the name of Allah, Most Merciful, Most Compassionate **************************
Imports System.Data.SqlClient
Imports System.Windows
Imports CrystalDecisions.Shared
Public Class DeliveryValueReportT

    Private Rpt1 As New RptDeliveryValueReport
    Private Rpt2 As New RptDeliveryValueReportNew
    Private RptNew As New DeliveryValueReport
    Private Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        If cmbLocation.SelectedIndex = -1 Then
            MsgBox("Delivery Location not found..!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim fromShopName, fromShopAddress, fromShopGst, fromShopMobile As String
        Dim toShopName, toShopAddress, toShopGst, toShopMobile As String

        Using nCon As New SqlConnection(ConStr)

            nCon.Open()

            Try

                Rpt = IIf(chkOmitCP.Checked, Rpt2, RptNew)

                If chkOmitCP.Checked Then

                    SQL = "SELECT M.DeliveryCode,M.DeliveryDate,P.Category,SUM(D.Quantity) Qty,SUM(D.Quantity * D.RetailPrice) TotalRP,U.UserName " _
                    & "FROM DeliveryMaster M, DeliveryDetails D, Users U,ProductAttributes P " _
                    & "WHERE M.Id = D.Id AND M.UserID = U.UserID AND D.PluID = P.PluId AND M.DeliveryTo = " & cmbLocation.SelectedValue & " AND M.DeliveryDate BETWEEN '" _
                    & Format(mebFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd") & "' " _
                    & "GROUP BY M.DeliveryCode,M.DeliveryDate,P.Category,U.UserName ORDER BY M.DeliveryCode"

                    'SQL = "SELECT M.DeliveryCode,M.DeliveryDate,P.Category,SUM(D.Quantity) Qty,SUM(D.Quantity * D.RetailPrice) TotalRP,U.UserName " _
                    '& "FROM DeliveryMaster M, DeliveryDetails D, Users U,ProductAttributes P " _
                    '& "WHERE M.Id = D.Id AND M.UserID = U.UserID AND D.PluID = P.PluId AND M.DeliveryTo = " & cmbLocation.SelectedValue & " AND M.DeliveryDate BETWEEN '" _
                    '& Format(mebFrom.Value, "yyyy-MM-dd HH:mm") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd HH:mm") & "' " _
                    '& "GROUP BY M.DeliveryCode,M.DeliveryDate,P.Category,U.UserName ORDER BY M.DeliveryCode"

                Else

                    SQL = $"SELECT  
                   S1.Alias [FCName], S1.Address1 + ' ' + S1.Address2 + ' ' + S1.City + ', ' + S1.State [FCAddress], S1.Phone [FCPhone], S1.CST [FCGst],
                   S2.Alias [TCName], S2.Address1 + S2.Address2 + S2.City + ',' + S2.State [TCAddress],S2.Phone [TCPhone], S2.CST [TCGst]
                   FROM Shops S1  
                   INNER JOIN Shops S2 ON S1.ShopId = {ShopID} AND S2.ShopId = {cmbLocation.SelectedValue}"

                    Using cmd As New SqlCommand(SQL, nCon)
                        Using reader As SqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                fromShopName = reader("FCName").ToString()
                                fromShopAddress = reader("FCAddress").ToString()
                                fromShopGst = reader("FCGst").ToString()
                                fromShopMobile = reader("FCPhone").ToString()
                                toShopName = reader("TCName").ToString()
                                toShopAddress = reader("TCAddress").ToString()
                                toShopGst = reader("TCGst").ToString()
                                toShopMobile = reader("TCPhone").ToString()
                            End If
                        End Using
                    End Using


                    SQL = "select deliverycode,deliverydate,Totalqty,totcp TotalCP,totrp TotalRP,U.UserName from deliverymaster,Users U where DeliveryMaster.UserID = U.UserID AND deliveryto=" _
                    & cmbLocation.SelectedValue & " and deliverydate " _
                    & "between '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' and '" & Format(mebTo.Value, "yyyy-MM-dd") & "'" _
                    & " order by deliverydate"

                End If


                Using Adp As New SqlDataAdapter(SQL, nCon)

                    Using Tbl As New DataTable
                        Adp.Fill(Tbl)
                        Rpt.SetDataSource(Tbl)

                        If chkOmitCP.Checked Then
                            Rpt.SetParameterValue("Location", cmbLocation.Text.Trim)
                            Rpt.SetParameterValue("Duration", Format(mebFrom.Value, "dd-MM-yyyy") & " to " & Format(mebTo.Value, " dd-MM-yyyy"))
                        Else
                            Rpt.SetParameterValue("FromDate", Format(mebFrom.Value, "dd-MM-yyyy"))
                            Rpt.SetParameterValue("ToDate", Format(mebTo.Value, "dd-MM-yyyy"))
                            Rpt.SetParameterValue("FromCompanyName", fromShopName)
                            Rpt.SetParameterValue("FromCompanyAddress", fromShopAddress)
                            Rpt.SetParameterValue("FromCompanyGST", "GSTIN : " + fromShopGst)
                            Rpt.SetParameterValue("FromCompanyMobile", "Mobile : " + fromShopMobile)
                            Rpt.SetParameterValue("ToCompanyName", toShopName)
                            Rpt.SetParameterValue("ToCompanyAddress", toShopAddress)
                            Rpt.SetParameterValue("ToCompanyGST", "GSTIN : " + toShopGst)
                            Rpt.SetParameterValue("ToCompanyMobile", "Mobile : " + toShopMobile)
                        End If
                        'Rpt.SetParameterValue("Duration", Format(mebFrom.Value, "dd-MM-yyyy HH:mm") & " to " & Format(mebTo.Value, " dd-MM-yyyy HH:mm"))
                        CRpt.ReportSource = Rpt
                    End Using

                End Using

            Catch ex As SqlException
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

            nCon.Close()

        End Using

    End Sub

    Private Sub DeliveryValueReportT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SQL = "select shopid,(shopname + ' - ' + shopcode) sname from shops where shopid<>" & ShopID _
            & " order by shopid"
        ESSA.LoadCombo(cmbLocation, SQL, "sname", "shopid")

        'mebFrom.CustomFormat = "dd-MM-yyyy HH:mm"
        'mebTo.CustomFormat = "dd-MM-yyyy HH:mm"

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

End Class