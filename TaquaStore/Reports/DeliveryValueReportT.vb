'******************************** In the name of Allah, Most Merciful, Most Compassionate **************************
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
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

        Using nCon As New SqlConnection(ConStr)

            nCon.Open()

            Try

                Rpt = IIf(chkOmitCP.Checked, Rpt2, Rpt1)

                If chkOmitCP.Checked Then

                    SQL = "SELECT M.DeliveryCode,M.DeliveryDate,P.Category,SUM(D.Quantity) Qty,SUM(D.Quantity * D.RetailPrice) TotalRP,U.UserName " _
                    & "FROM DeliveryMaster M, DeliveryDetails D, Users U,ProductAttributes P " _
                    & "WHERE M.Id = D.Id AND M.UserID = U.UserID AND D.PluID = P.PluId AND M.DeliveryFrom = " & ShopID & " AND M.DeliveryTo = " & cmbLocation.SelectedValue & " AND M.DeliveryDate BETWEEN '" _
                    & Format(mebFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd") & "' " _
                    & "GROUP BY M.DeliveryCode,M.DeliveryDate,P.Category,U.UserName ORDER BY M.DeliveryCode"

                    'SQL = "SELECT M.DeliveryCode,M.DeliveryDate,P.Category,SUM(D.Quantity) Qty,SUM(D.Quantity * D.RetailPrice) TotalRP,U.UserName " _
                    '& "FROM DeliveryMaster M, DeliveryDetails D, Users U,ProductAttributes P " _
                    '& "WHERE M.Id = D.Id AND M.UserID = U.UserID AND D.PluID = P.PluId AND M.DeliveryTo = " & cmbLocation.SelectedValue & " AND M.DeliveryDate BETWEEN '" _
                    '& Format(mebFrom.Value, "yyyy-MM-dd HH:mm") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd HH:mm") & "' " _
                    '& "GROUP BY M.DeliveryCode,M.DeliveryDate,P.Category,U.UserName ORDER BY M.DeliveryCode"

                Else

                    SQL = "select deliverycode,deliverydate,Totalqty,totcp TotalCP,totrp TotalRP,U.UserName from deliverymaster,Users U where DeliveryMaster.UserID = U.UserID AND deliveryto=" _
                    & cmbLocation.SelectedValue & " and deliveryfrom = " & ShopID & " and deliverydate " _
                    & "between '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' and '" & Format(mebTo.Value, "yyyy-MM-dd") & "'" _
                    & " order by deliverydate"

                End If


                Using Adp As New SqlDataAdapter(SQL, nCon)

                    Using Tbl As New DataTable
                        Adp.Fill(Tbl)
                        Rpt.SetDataSource(Tbl)

                        Rpt.SetParameterValue("Location", cmbLocation.Text.Trim)
                        Rpt.SetParameterValue("Duration", Format(mebFrom.Value, "dd-MM-yyyy") & " to " & Format(mebTo.Value, " dd-MM-yyyy"))

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

    Private Sub btnTransferReceipt_Click(sender As Object, e As EventArgs) Handles btnTransferReceipt.Click

        If cmbLocation.SelectedIndex = -1 Then
            MsgBox("Delivery Location not found..!", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Are you sure, do you want to generate transfer receipt..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        btnTransferReceipt.Enabled = False

        Dim generatedId As Integer = 0
        Dim fromShopName As String = ""
        Dim fromShopAddress As String = ""
        Dim fromShopGst As String = ""
        Dim fromShopMobile As String = ""
        Dim toShopName As String = ""
        Dim toShopAddress As String = ""
        Dim toShopGst As String = ""
        Dim toShopMobile As String = ""

        ' ---------------------------------------------
        ' 1️.  Insert Master + Details (WITH TRANSACTION)
        ' ---------------------------------------------
        Try
            Using connection As New SqlConnection(ConStr)
                connection.Open()

                Using transaction = connection.BeginTransaction()
                    Using cmd As SqlCommand = connection.CreateCommand()
                        cmd.Transaction = transaction

                        Try
                            ' ---------------------------------------------
                            ' Insert into GroupedDeliveryMaster
                            ' ---------------------------------------------
                            cmd.CommandText = "
                            INSERT INTO GroupedDeliveryMaster
                            (FromShopId, ToShopId, FromDate, ToDate, CreatedBy, CreatedAt)
                            OUTPUT INSERTED.Id
                            VALUES (@FromShopId, @ToShopId, @FromDate, @ToDate, @UserId, @CreatedAt)
                        "

                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@FromShopId", ShopID)
                            cmd.Parameters.AddWithValue("@ToShopId", cmbLocation.SelectedValue)
                            cmd.Parameters.AddWithValue("@FromDate", mebFrom.Value.Date)
                            cmd.Parameters.AddWithValue("@ToDate", mebTo.Value.Date)
                            cmd.Parameters.AddWithValue("@UserId", UserID)
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now)

                            generatedId = CInt(cmd.ExecuteScalar())

                            ' ---------------------------------------------
                            ' Insert into GroupedDeliveryDetails
                            ' ---------------------------------------------
                            cmd.CommandText = "
                            INSERT INTO GroupedDeliveryDetails
                            (GroupedDeliveryMasterId, DeliveryCode, Quantity, TotalCost)
                            SELECT @MasterId, DeliveryCode, TotalQty, TotCP
                            FROM DeliveryMaster
                            WHERE DeliveryTo = @ToShop
                              AND DeliveryFrom = @FromShop
                              AND DeliveryDate BETWEEN @FromDate AND @ToDate
                        "

                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@MasterId", generatedId)
                            cmd.Parameters.AddWithValue("@ToShop", cmbLocation.SelectedValue)
                            cmd.Parameters.AddWithValue("@FromShop", ShopID)
                            cmd.Parameters.AddWithValue("@FromDate", mebFrom.Value.Date)
                            cmd.Parameters.AddWithValue("@ToDate", mebTo.Value.Date)

                            cmd.ExecuteNonQuery()

                            ' COMMIT
                            transaction.Commit()

                        Catch ex As Exception
                            transaction.Rollback()
                            Throw
                        End Try

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' ---------------------------------------------
        ' 2️.  Get From & To shop details
        ' ---------------------------------------------
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
              AND S2.ShopId = {cmbLocation.SelectedValue}
        "

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
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Failed fetching shop details: " & ex.Message)
            Exit Sub
        End Try

        ' ---------------------------------------------
        ' 3️.  Load Data + Set Crystal Report Parameters
        ' ---------------------------------------------
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
            WHERE GroupedDeliveryMasterId = {generatedId}
        "

            Using nCon As New SqlConnection(ConStr)
                nCon.Open()

                Using Adp As New SqlDataAdapter(detailSQL, nCon)
                    Using Tbl As New DataTable
                        Adp.Fill(Tbl)

                        RptNew.SetDataSource(Tbl)

                        RptNew.SetParameterValue("TNo", generatedId)
                        RptNew.SetParameterValue("TDate", Format(Now.Date, "dd-MM-yyyy"))
                        RptNew.SetParameterValue("FromCompanyName", fromShopName)
                        RptNew.SetParameterValue("FromCompanyAddress", fromShopAddress)
                        RptNew.SetParameterValue("FromCompanyGST", "GSTIN : " & fromShopGst)
                        RptNew.SetParameterValue("FromCompanyMobile", "Mobile : " & fromShopMobile)
                        RptNew.SetParameterValue("ToCompanyName", toShopName)
                        RptNew.SetParameterValue("ToCompanyAddress", toShopAddress)
                        RptNew.SetParameterValue("ToCompanyGST", "GSTIN : " & toShopGst)
                        RptNew.SetParameterValue("ToCompanyMobile", "Mobile : " & toShopMobile)

                        CRpt.ReportSource = RptNew
                    End Using
                End Using
            End Using

            btnTransferReceipt.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Error loading report: " & ex.Message)
            Exit Sub
        End Try

    End Sub

End Class