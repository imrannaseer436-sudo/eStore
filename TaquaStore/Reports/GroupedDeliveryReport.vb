'******************************** In the name of Allah, Most Merciful, Most Compassionate **************************
Imports System.Data.SqlClient

Public Class GroupedDeliveryReport

    Private Rpt As New DeliveryValueReport
    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        If cmbLocation.SelectedIndex = -1 Then
            MsgBox("Delivery Location not found..!", MsgBoxStyle.Information)
            Exit Sub
        ElseIf cmbTNo.FindStringExact(cmbTNo.Text) = -1 Then
            MsgBox("Select valid transfer no..!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim fromShopName As String = ""
        Dim fromShopAddress As String = ""
        Dim fromShopGst As String = ""
        Dim fromShopMobile As String = ""
        Dim toShopName As String = ""
        Dim toShopAddress As String = ""
        Dim toShopGst As String = ""
        Dim toShopMobile As String = ""
        Dim tDate As Date = Now.Date

        Using nCon As New SqlConnection(ConStr)

            nCon.Open()

            Try
                Try
                    Dim shopSQL As String = $"
                                        SELECT  
                                        S1.Alias AS FCName,
                                        S1.Address1 + ' ' + S1.Address2 + ' ' + S1.City + ', ' + S1.State AS FCAddress,
                                        S1.Phone AS FCPhone,
                                        S1.CST AS FCGst,
                                        S2.Alias AS TCName,
                                        S2.Address1 + ' ' + S2.Address2 + ' ' + S2.City + ', ' + S2.State AS TCAddress,
                                        S2.Phone AS TCPhone,
                                        S2.CST AS TCGst
                                        FROM Shops S1
                                        CROSS JOIN Shops S2
                                        WHERE S1.ShopId = {ShopID}
                                        AND S2.ShopId = {cmbLocation.SelectedValue}; 
                                        SELECT CreatedAt FROM GroupedDeliveryMaster WHERE Id= {CInt(cmbTNo.Text)}"

                    Using r = ESSA.OpenReader(shopSQL)
                        If r.Read() Then
                            fromShopName = r("FCName").ToString()
                            fromShopAddress = r("FCAddress").ToString()
                            fromShopGst = r("FCGst").ToString()
                            fromShopMobile = r("FCPhone").ToString()
                            toShopName = r("TCName").ToString()
                            toShopAddress = r("TCAddress").ToString()
                            toShopGst = r("TCGst").ToString()
                            toShopMobile = r("TCPhone").ToString()

                            r.NextResult()

                            If r.Read() Then
                                tDate = CDate(r("CreatedAt"))
                            End If

                        End If
                    End Using

                Catch ex As Exception
                    MessageBox.Show("Failed fetching shop details: " & ex.Message)
                    Exit Sub
                End Try

                Try
                    Dim detailSQL As String = $"
                    SELECT DeliveryCode,
                           GETDATE() AS DeliveryDate,
                           '' AS ShopName,
                           Quantity AS TotalQty,
                           TotalCost AS TotalCP,
                           0 AS TotalRP,
                           '' AS UserName
                    FROM GroupedDeliveryDetails
                    WHERE GroupedDeliveryMasterId = {cmbTNo.Text}"

                    Using Adp As New SqlDataAdapter(detailSQL, nCon)
                        Using Tbl As New DataTable
                            Adp.Fill(Tbl)

                            Rpt.SetDataSource(Tbl)

                            Rpt.SetParameterValue("TNo", cmbTNo.Text)
                            Rpt.SetParameterValue("TDate", Format(tDate, "dd-MM-yyyy"))
                            Rpt.SetParameterValue("FromCompanyName", fromShopName)
                            Rpt.SetParameterValue("FromCompanyAddress", fromShopAddress)
                            Rpt.SetParameterValue("FromCompanyGST", "GSTIN : " & fromShopGst)
                            Rpt.SetParameterValue("FromCompanyMobile", "Mobile : " & fromShopMobile)
                            Rpt.SetParameterValue("ToCompanyName", toShopName)
                            Rpt.SetParameterValue("ToCompanyAddress", toShopAddress)
                            Rpt.SetParameterValue("ToCompanyGST", "GSTIN : " & toShopGst)
                            Rpt.SetParameterValue("ToCompanyMobile", "Mobile : " & toShopMobile)

                            CRpt.ReportSource = Rpt
                        End Using
                    End Using

                Catch ex As Exception
                    MessageBox.Show("Error loading report: " & ex.Message)
                    Exit Sub
                End Try

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

    Private Sub cmbLocation_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbLocation.SelectedValueChanged

        If cmbLocation.SelectedIndex = -1 Then
            Return
        End If

        ESSA.LoadCombo(cmbTNo, $"SELECT Id FROM GroupedDeliveryMaster WHERE FromShopId = {ShopID} AND ToShopId = {cmbLocation.SelectedValue} ORDER BY Id Desc", "Id", "Id")

    End Sub
End Class