'******************************************** Bismillah ********************************************
Imports System.Data.SqlClient
Public Class MainWindowX

    Private Sub ReleaseForm()

        For Each ctl As Control In SplitContainer1.Panel2.Controls
            ctl.Dispose()
        Next

    End Sub

    Private Sub MainWindowX_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ReleaseForm()

    End Sub

    Private Sub MainWindowX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SQL = "select distinct icon,headname,headid from menulist order by headid"
        With ESSA.OpenReader(SQL)
            MenuList.Rows.Clear()
            While .Read
                MenuList.Rows.Add()
                MenuList.Item(2, MenuList.Rows.Count - 1).Value = .Item(0)
                MenuList.Item(3, MenuList.Rows.Count - 1).Value = .GetString(1)
                SQL = "select menuid,menuname,headid from menulist where headid=" & .Item(2) _
                    & " order by menuid"
                With ESSA.OpenReader(SQL)
                    While .Read
                        MenuList.Rows.Add()
                        MenuList.Rows(MenuList.Rows.Count - 1).DefaultCellStyle.Font = New Font("Segoe UI", 8)
                        MenuList.Item(0, MenuList.Rows.Count - 1).Value = .Item(0)
                        MenuList.Item(3, MenuList.Rows.Count - 1).Value = .GetString(1)
                        MenuList.Item(4, MenuList.Rows.Count - 1).Value = .Item(2)
                        MenuList.Rows(MenuList.Rows.Count - 1).Visible = False
                    End While
                    .Close()
                End With
            End While
            .Close()
        End With

        btnUser.Text = "Welcome, " & UserName & " "

        SQL = "select shopid,shopname from shops where shopcode='" & ShopCode & "'"
        With ESSA.OpenReader(SQL)
            If .Read Then
                ShopID = .Item(0)
                ShopNm = .GetString(1)
                lblShopName.Text = .GetString(1).Trim & " (" & ShopCode & ")"
                .Close()
            Else
                .Close()
                MsgBox("Shopcode not found..!", MsgBoxStyle.Critical)
                Me.Close()
            End If
        End With

    End Sub

    Public Sub CloseTab(ByVal FormTag As String)

        For Each tp As Dotnetrix.Controls.TabPageEX In tabMain.TabPages

            If tp.Name = FormTag Then
                tp.Dispose()
                Exit For
            End If

        Next

    End Sub

    Public Function TabExists(ByVal FormTag As String) As Boolean

        TabExists = False
        For Each tp As Dotnetrix.Controls.TabPageEX In tabMain.TabPages

            If tp.Name = FormTag Then
                TabExists = True
                Exit For
            End If

        Next

        Return TabExists
    End Function

    Private Sub LaunchForm(ByVal TagID As String)

        Select Case TagID

            Case "1"
                'AddTab(Products)
                AddTab(Products3)
            Case "2"
                AddTab(Category)
            Case "3"
                'AddTab(Agents)
                AddTab(Agents2)
            Case "4"
                AddTab(Customer)
            Case "5"
                Vendors2.Close()
                Vendors2.Show(Me)
            Case "6"
                AddTab(Shop)
            Case "7"
                AddTab(Shop)
            Case "8"
                'If IsAdmin = False Then
                '    MsgBox("Access Denied..!", vbCritical)
                '    Exit Sub
                'End If
                AddTab(Users)
            Case "9"
                AddTab(ProductDeliveryMaster)
            Case "10"
                AddTab(ProductReceived)
            Case "11"

            Case "12"
                AddTab(StockUpdater)
            Case "13"
                AddTab(Godown)
            Case "14"
                AddTab(PurchaseOrder)
            Case "15"
                AddTab(PurchaseReturn)
            Case "16"
                AddTab(DirectGRN)
                'AddTab(DirectGRN2)
            Case "17"
                AddTab(Ledger)
            Case "18"
                AddTab(ProductBatch)
            Case "19"
                AddTab(DeliveryChallanReport)
            Case "20"
                AddTab(LablePrinting)
            Case "21"
                AddTab(CurrentStockReport)
            Case "22"
                AddTab(ProductDelivery)
            Case "23"
                AddTab(ManualReturn)
            Case "24"
                AddTab(OpeningStock)
            Case "25"
                AddTab(frmProductEdit2)
            Case "26"
                AddTab(SalesSummaryReport)
            Case "27"
                AddTab(StockReportLocationWise)
            Case "28"
                AddTab(SalesQuantityReport)
            Case "29"
                AddTab(SalesQuantityReportCW)
            Case "30"
                AddTab(DeliveryValueReportT)
            Case "31"
                AddTab(GeneralDelivery)
            Case "32"
                AddTab(ProductStatusReport2)
            Case "33"
                DeliveryUpdaters.Visible = False
                DeliveryUpdaters.Show(Me)
            Case "34"
                AddTab(BillGenerator)
            Case "35"
                BillUpdater.Visible = False
                BillUpdater.Show(Me)
            Case "36"
                AddTab(BillSummaryReport)
            Case "37"
                VendorUpdater.Visible = False
                VendorUpdater.Show(Me)
            Case "38"
                CategoryUpdater.Visible = False
                CategoryUpdater.Show(Me)
            Case "39"
                AddTab(PurchaseOrderNew)
            Case "40"
                ReturnVerifier.Visible = False
                ReturnVerifier.Show(Me)
            Case "41"
                PriceUpdaterGRNWise.Visible = False
                PriceUpdaterGRNWise.Show(Me)
            Case "42"
                ImportTool.Visible = False
                ImportTool.Show(Me)
            Case "43"
                PriceUpdater.Visible = False
                PriceUpdater.Show(Me)
            Case "44"
                AddTab(DeliveryQuantityReport)
                'DeliveryReportDateWise.Visible = False
                'DeliveryReportDateWise.Show(Me)
            Case "45"
                AddTab(GeneralReceived)
            Case "46"
                UnusedProducts.Visible = False
                UnusedProducts.Show(Me)
            Case "47"
                NewBillGenerator.Visible = False
                NewBillGenerator.Show(Me)
            Case "48"
                AddTab(ProductReturnReport)
            Case "49"
                AddTab(SalesReturnReport)
            Case "50"
                AddTab(GeneralDeliveryReceivedReport)
            Case "51"
                AddTab(ReceivedChallanReport)
            Case "52"
                ChangePassword.ShowDialog()
            Case "53"
                AddTab(frmProductStatusReport2)
            Case "54"
                frmNewCategory.Visible = False
                frmNewCategory.Show(Me)
            Case "55"
                AddTab(frmCategoryUpdaterNew)
            Case "56"
                frmBankRegister.Visible = False
                frmBankRegister.Show(Me)
            Case "57"
                frmBankRegisterMultiple.Visible = False
                frmBankRegisterMultiple.Show(Me)
            Case "58"
                frmPaymentRegister.Visible = False
                frmPaymentRegister.Show(Me)
            Case "59"
                frmHSN2021.Visible = False
                frmHSN2021.Show(Me)
            Case "60"
                AddTab(frmAdvancePayment)
            Case "61"
                frmCategorywise_Bill.Visible = False
                frmCategorywise_Bill.Show(Me)
            Case "62"
                AddTab(StockReportSW)
            Case "63"
                'SalesReportHSNwise.Visible = False
                'SalesReportHSNwise.Show(Me)
                AddTab(SalesReportHSNwise)
            Case "64"
                AddTab(frmChequeDetails)
            Case "65"
                Verifier.Visible = False
                Verifier.Show(Me)
            Case "66"
                AddTab(DeliveryWiseSalesAndStockReport)
            Case "67"
                AddTab(ProductStatusReport)
            Case "68"
                AddTab(GroupedDeliveryReport)
        End Select

    End Sub

    Private Sub MenuList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MenuList.CellDoubleClick

        If Val(MenuList.Item(0, e.RowIndex).Value) = 0 Then

            For j As Short = 0 To MenuList.Rows.Count - 1
                If Val(MenuList.Item(0, j).Value) > 0 Then
                    MenuList.Rows(j).Visible = False
                End If
            Next

            For i As Short = e.RowIndex + 1 To MenuList.Rows.Count - 1

                If Val(MenuList.Item(0, i).Value) = 0 Then
                    Exit For
                Else
                    MenuList.Rows(i).Visible = True
                End If

            Next

        ElseIf Val(MenuList.Item(0, e.RowIndex).Value) > 0 Then
            LaunchForm(Val(MenuList.Item(0, e.RowIndex).Value))
        End If

    End Sub

    Public Sub AddTab(ByVal MyForm As Form)

        For Each tn As Dotnetrix.Controls.TabPageEX In tabMain.TabPages
            If tn.Name = MyForm.Name Then
                tabMain.SelectedTab = tn
                Exit Sub
                Exit For
            End If
        Next

        Dim tb As New Dotnetrix.Controls.TabPageEX
        tb.Name = MyForm.Name
        tb.Text = MyForm.Text & " "
        MyForm.TopLevel = False
        MyForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        tb.Controls.Add(MyForm)
        MyForm.Dock = DockStyle.Fill
        tabMain.TabPages.Add(tb)
        tabMain.SelectedTab = tb
        MyForm.Show()

    End Sub

    Private Sub btnSignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOut.Click

        'ManualReturn2.Show()

        If MsgBox("Are you sure, do you want to sign out..!", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Login.Show()
        Me.Close()

    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click

        SettingsNew.Show(Me)

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        pnlReports.Visible = True

    End Sub

    Private Sub btnDayEnd_Click(sender As Object, e As EventArgs) Handles btnDayEnd.Click

        pnlQV.Visible = True
        btnDayEnd2.Focus()

    End Sub

    Private Sub btnHideMe_Click(sender As Object, e As EventArgs) Handles btnHideMe.Click

        pnlQV.Visible = False

    End Sub

    Private Sub btnDayEnd2_Click(sender As Object, e As EventArgs) Handles btnDayEnd2.Click

        DiscountAssigner.Visible = False
        DiscountAssigner.Show(Me)

        pnlQV.Visible = False

    End Sub

    Private Sub btnVendor_Click(sender As Object, e As EventArgs) Handles btnVendor.Click

        VendorViewer.Visible = False
        VendorViewer.Show(Me)

        pnlQV.Visible = False

    End Sub

    Private Sub btnCodeReader_Click(sender As Object, e As EventArgs) Handles btnCodeReader.Click

        CodeReaderAdv.Visible = False
        CodeReaderAdv.Show(Me)

        pnlQV.Visible = False

    End Sub

    Private Sub btnCodeFinder_Click(sender As Object, e As EventArgs) Handles btnCodeFinder.Click

        frmCodeViewer.Visible = False
        frmCodeViewer.Show(Me)

        pnlQV.Visible = False

    End Sub

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click

        'frmHSNUpdater.Show()

    End Sub

    Private Sub btnAttributes_Click(sender As Object, e As EventArgs) Handles btnAttributes.Click

        Attributes.Visible = False
        Attributes.Show(Me)

        pnlQV.Visible = False

    End Sub

    Private Sub btnCodeConvertor_Click(sender As Object, e As EventArgs) Handles btnCodeConvertor.Click

        frmCodeConvertor.Visible = False
        frmCodeConvertor.Show(Me)

        pnlQV.Visible = False

    End Sub

    Private Sub btnColorRegister_Click(sender As Object, e As EventArgs) Handles btnColorRegister.Click

        Colors.Visible = False
        Colors.Show(Me)

        pnlQV.Visible = False

    End Sub

    Private Sub btnColorUpdater_Click(sender As Object, e As EventArgs) Handles btnColorUpdater.Click

        frmColorUpdater.Visible = False
        frmColorUpdater.Show(Me)

        pnlQV.Visible = False

    End Sub

    Private Sub mnuHideReports_Click(sender As Object, e As EventArgs) Handles mnuHideReports.Click

        pnlReports.Hide()

    End Sub

    Private Sub mnuSalesReport_Click(sender As Object, e As EventArgs) Handles mnuSalesReport.Click

        AddTab(FrmSalesQuantityReport)
        pnlReports.Hide()

    End Sub

    Private Sub mnuPurchaseReport_Click(sender As Object, e As EventArgs) Handles mnuPurchaseReport.Click

        AddTab(frmPurchaseReport)
        pnlReports.Hide()

        'frmPurchaseReport.Show()
        'pnlReports.Hide()

    End Sub

    Private Sub mnuProductSearch_Click(sender As Object, e As EventArgs) Handles mnuProductSearch.Click

        AddTab(ProductSearch2)
        pnlReports.Hide()

    End Sub

    Private Sub mnuStockReport_Click(sender As Object, e As EventArgs) Handles mnuStockReport.Click

        AddTab(frmStockReportNew)
        pnlReports.Hide()

    End Sub

    Private Sub mnuPendingReport_Click(sender As Object, e As EventArgs) Handles mnuPendingReport.Click

        AddTab(frmPendingReport)
        pnlReports.Hide()

    End Sub

    Private Sub mnuDueReport_Click(sender As Object, e As EventArgs) Handles mnuDueReport.Click

        AddTab(frmDueReport)
        pnlReports.Hide()

    End Sub

    Private Sub MenuList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MenuList.CellContentClick

    End Sub

    Private Sub MnuVendorRpt_Click(sender As Object, e As EventArgs) Handles MnuVendorRpt.Click

        AddTab(FrmVendorwiseReport)
        pnlReports.Hide()

    End Sub

    Private Sub MnuStockReportIW_Click(sender As Object, e As EventArgs) Handles MnuStockReportIW.Click

        AddTab(frmInvBasedStock)
        pnlReports.Hide()

    End Sub

    Private Sub MnuDebitReport_Click(sender As Object, e As EventArgs) Handles MnuDebitReport.Click

        AddTab(frmDebitReport)
        pnlReports.Hide()

    End Sub

    Private Sub btnCommission_Click(sender As Object, e As EventArgs) Handles btnCommission.Click

        frmSalesCommission.Visible = False
        frmSalesCommission.Show(Me)

        pnlQV.Hide()

    End Sub
End Class