'*************************************** Bismillah **************************************************
Imports System.Data.SqlClient
Public Class ManualReturn

    Private PluID As Integer
    Private PluNm As String
    Private Edit As Boolean = False
    Private Rpt As New RptManualReturn
    Private isAutomatic As Boolean = False

    Private Sub ManualReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.F2
                btnSave.PerformClick()
            Case Keys.F3
                btnEdit.PerformClick()
            Case Keys.F5
                btnReset.PerformClick()
            Case Keys.F12
                chkLC.Enabled = True
            Case Keys.Escape
                If pnlFrieght.Visible = True Then pnlFrieght.Visible = False : Exit Sub
                If pnlGList.Visible = True Then pnlGList.Visible = False : Exit Sub
                btnClose.PerformClick()
            Case Keys.Enter
                If Me.ActiveControl.Tag <> "1" Then
                    e.SuppressKeyPress = True
                    Me.ProcessTabKey(True)
                End If

        End Select

    End Sub

    Private Sub ManualReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadTransportDetails()
        LoadVendors()
        GenerateReturnID()
        mebVchDt.Text = Format(Now.Date, "dd-MM-yyyy")
        cmbVendor.Select()

        TG.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        TG.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        TG.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        ESSA.AlignHeader(TG, 7, DataGridViewContentAlignment.MiddleCenter)
        ESSA.AlignHeader(TG, 8, DataGridViewContentAlignment.MiddleRight)
        ESSA.AlignHeader(TG, 9, DataGridViewContentAlignment.MiddleRight)
        ESSA.AlignHeader(TG, 10, DataGridViewContentAlignment.MiddleCenter)

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVdr, SQL, "vendorname", "vendorid", "All Vendor(s)")

        cmbVendor.Select()
        cmbCTax.SelectedIndex = 0
        cmbTransport.SelectedIndex = cmbTransport.FindStringExact("UNSPECIFIED")
        cmbCourier.SelectedIndex = cmbCourier.FindStringExact("UNSPECIFIED")

    End Sub

    Private Sub LoadTransportDetails()

        SQL = "SELECT DISTINCT COURIER FROM RVCHMASTER WHERE LEN(COURIER)>0 ORDER BY COURIER"
        ESSA.LoadCombo(cmbCourier, SQL, "COURIER")

        SQL = "SELECT DISTINCT COURIER FROM RVCHMASTER WHERE LEN(COURIER)>0 ORDER BY COURIER"
        ESSA.LoadCombo(cmbCourier2, SQL, "COURIER")

        SQL = "SELECT DISTINCT TRANSPORT FROM RVCHMASTER WHERE LEN(TRANSPORT)>0 ORDER BY TRANSPORT"
        ESSA.LoadCombo(cmbTransport, SQL, "TRANSPORT")

        SQL = "SELECT DISTINCT TRANSPORT FROM RVCHMASTER WHERE LEN(TRANSPORT)>0 ORDER BY TRANSPORT"
        ESSA.LoadCombo(cmbTransport2, SQL, "TRANSPORT")

    End Sub

    Private Sub LoadVendors()

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid")

    End Sub

    Private Sub GenerateReturnID()

        SQL = "select max(vchno) from rvchmaster"
        txtVchNo.Text = ESSA.GenerateID(SQL)

    End Sub

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            If Not CheckVendorId() Then
                    TTip.Show("Please choose correct vendor..!", txtCode, 0, 25, 2000)
                    cmbVendor.Focus()
                    Exit Sub
                End If

                SQL = "select p.pluid,plucode,pluname,costprice,v.stock from productmaster p,v_stockpos v where p.pluid=v.pluid and plucode='" & txtCode.Text.Trim & "'"
                With ESSA.OpenReader(SQL)
                If .Read Then
                    PluID = .Item(0)
                    txtCode.Text = .GetString(1)
                    PluNm = .GetString(2)
                    txtRate.Text = Format(.Item(3), "0.000")
                    txtStock.Text = .Item(4)

                    If cmbVendor.SelectedValue = 1 Then
                        txtRQty.Text = 1
                        AutomatedEntry()
                    Else
                        txtRQty.Focus()
                    End If
                Else
                    TTip.Show("Sorry, Product code not found..!", txtCode, 0, 25, 2000)
                    End If
                    .Close()
                End With

            End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub CalulateTotal()

        Dim TQty As Double = 0
        Dim TAmt As Double = 0
        Dim NAmt As Double = 0
        Dim TaxAmt As Double = 0

        For i As Short = 0 To TG.Rows.Count - 1

            TQty += Val(TG.Item(4, i).Value)
            TAmt += Val(TG.Item(6, i).Value)
            TaxAmt += Val(TG.Item(8, i).Value)
            NAmt += Val(TG.Item(9, i).Value)

        Next

        lblTQty.Text = TQty
        lblTAmt.Text = Format(TAmt, "0.00")
        lblTaxAmt.Text = Format(TaxAmt, "0.00")
        lblNAmt.Text = Format(NAmt, "0.00")

    End Sub

    Private Sub TG_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TG.RowsRemoved

        CalulateTotal()
        ResetSerial()

    End Sub

    Private Sub ResetSerial()

        For i As Short = 0 To TG.Rows.Count - 1
            TG.Item(1, i).Value = i + 1
        Next

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        LoadVendors()
        RefreshForms()

    End Sub

    Private Sub RefreshForms()

        chkLC.Enabled = False
        TG.Rows.Clear()
        lblTAmt.Text = "0.00"
        lblTQty.Text = "0"

        txtCode.Clear()
        txtRmrks.Clear()
        txtRQty.Clear()
        txtStock.Clear()

        cmbVendor.Focus()
        cmbTransport.SelectedIndex = cmbTransport.FindStringExact("UNSPECIFIED")
        cmbCourier.SelectedIndex = cmbCourier.FindStringExact("UNSPECIFIED")

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If cmbVendor.SelectedIndex = -1 Then
            TTip.Show("Vendor not selected..!", cmbVendor, 0, 25, 2000)
            cmbVendor.Focus()
            Exit Sub
        ElseIf IsDate(mebVchDt.Text) = False Then
            TTip.Show("Incorrect voucher date..!", mebVchDt, 0, 25, 2000)
            mebVchDt.Focus()
            Exit Sub
        ElseIf TG.Rows.Count = 0 Then
            TTip.Show("No products to save..!", btnSave, 0, 25, 2000)
            Exit Sub
        End If

        If Isa.Msg.ShowSaveQuestion = MsgBoxResult.No Then Exit Sub

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction
        Cmd.Transaction = Trn

        Try

            If Edit = True Then
                SQL = "delete from rvchmaster where vchno=" & Val(txtVchNo.Text) & ";" _
                    & "delete from rvchdetails where vchno=" & Val(txtVchNo.Text)
                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()
            Else
                GenerateReturnID()
            End If

            SQL = "insert into rvchmaster values (" _
                & Val(txtVchNo.Text) & ",'" _
                & Format(CDate(mebVchDt.Text).Date, "yyyy-MM-dd") & "'," _
                & cmbVendor.SelectedValue & ",'" _
                & txtRmrks.Text.Trim & "'," _
                & Val(lblTQty.Text) & "," _
                & Val(lblTAmt.Text) & "," _
                & Val(lblTaxAmt.Text) & "," _
                & Val(lblNAmt.Text) & "," _
                & ShopID & "," _
                & UserID & ",0," _
                & IIf(chkLC.Checked = True, 1, 0) & ",'" _
                & cmbCourier.Text.Trim & "','" _
                & txtPOD.Text.Trim & "','" _
                & Format(dtpPOD.Value, "yyyy-MM-dd") & "','" _
                & cmbTransport.Text.Trim & "','" _
                & txtLRNo.Text.Trim & "','" _
                & Format(dtpLRDt.Value, "yyyy-MM-dd") & "')"

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            For i As Short = 0 To TG.Rows.Count - 1

                SQL = "insert into rvchdetails values (" _
                    & Val(txtVchNo.Text) & "," _
                    & Val(TG.Item(0, i).Value) & "," _
                    & Val(TG.Item(4, i).Value) & "," _
                    & Val(TG.Item(5, i).Value) & "," _
                    & IIf(Trim(TG.Item(10, i).Value) = "YES", 1, 0) & "," _
                    & Val(TG.Item(7, i).Value) & "," _
                    & Val(TG.Item(8, i).Value) & "," _
                    & Val(TG.Item(11, i).Value) & "," _
                    & Val(TG.Item(12, i).Value) & "," _
                    & Val(TG.Item(1, i).Value) & ")"

                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()

            Next

            Trn.Commit()
            Con.Close()

            MsgBox("Purchase return saved successfully..!", MsgBoxStyle.Exclamation)
            'xMessageBox.ShowMessage("Entry saved successfully..!", "Congratulations..!", xMessageBox.MessageBoxStyle.OKOnly)
            RefreshForms()

        Catch ex As Exception
            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        pnlGList.Visible = True
        cmbVdr.Focus()

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click

        TGGrn.Rows.Clear()

        SQL = "select m.vchno,m.vchdt,v.vendorname,m.quantity,m.netamt,m.podno from " _
            & "rvchmaster m,vendors v where m.vendorid=v.vendorid"

        If cmbVdr.SelectedIndex > 0 Then
            SQL &= " and m.vendorid=" & cmbVdr.SelectedValue
        End If

        SQL &= " order by m.vchno desc"

        With ESSA.OpenReader(SQL)
            While .Read
                TGGrn.Rows.Add()
                TGGrn.Item(0, TGGrn.Rows.Count - 1).Value = .Item(0)
                TGGrn.Item(1, TGGrn.Rows.Count - 1).Value = Format(.GetDateTime(1).Date, "dd-MMM-yyyy")
                TGGrn.Item(2, TGGrn.Rows.Count - 1).Value = .GetString(2)
                TGGrn.Item(3, TGGrn.Rows.Count - 1).Value = .Item(3)
                TGGrn.Item(4, TGGrn.Rows.Count - 1).Value = Format(.Item(4), "0.00")
                TGGrn.Item(5, TGGrn.Rows.Count - 1).Value = .GetString(5).Trim
            End While
            .Close()
        End With

    End Sub

    Private Sub PrintPurchaseOrder(ByVal iVchNo As Short)

        'SQL = "SELECT M.VCHNO,M.VCHDT,V.VENDORNAME,M.REMARKS,P.PLUCODE,P.PLUNAME,D.QTY QUANTITY,D.RATE,(D.QTY*D.RATE) AMOUNT FROM " _
        '    & "RVCHMASTER M,RVCHDETAILS D,VENDORS V,PRODUCTMASTER P WHERE M.VCHNO=D.VCHNO AND M.VENDORID=V.VENDORID AND " _
        '    & "D.PLUID=P.PLUID AND M.VCHNO=" & iVchNo & " ORDER BY D.SNO"

        SQL = "SELECT M.VCHNO,M.VCHDT,V.VENDORNAME,M.REMARKS,P.Plucode,P.PluName + '-' + P.Id Pluname,D.QTY Quantity,D.Rate,(D.QTY*D.RATE) Amount," _
            & "M.COURIER,M.PODNO,M.PODDT,M.TRANSPORT,M.LRNO,M.LRDT,D.TAXPERC,D.IGST,D.TAXAMT,D.DisPerc " _
            & "FROM RVCHMASTER M,RVCHDETAILS D,VENDORS V,PRODUCTMASTER P WHERE M.VCHNO=D.VCHNO AND M.VENDORID=V.VENDORID AND " _
            & "D.PLUID=P.PLUID AND M.VCHNO=" & iVchNo & " ORDER BY D.SNO"

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                Rpt.SetDataSource(Tbl)
                Rpt.SetParameterValue("ReportHead", "Packing Slip - Return Goods")
                ReportViewer.CViewer.ReportSource = Rpt
                ReportViewer.Text = "Purchase Return Challan"
                ReportViewer.Show()
            End Using
        End Using
        Con.Close()

    End Sub

    Private Sub TGGrn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TGGrn.CellClick


        'If IsAdmin = True Then
        '    SQL = "UPDATE RVCHMASTER SET LOCALRETURN=1 WHERE VCHNO=" & Val(TGGrn.Item(0, e.RowIndex).Value)
        '    ESSA.Execute(SQL)
        '    MsgBox("Updated Successfully..!", MsgBoxStyle.Information)
        'Else
        '    MsgBox("Access Denied..!", MsgBoxStyle.Critical)
        'End If

        If e.ColumnIndex = 6 Then
            PrintPurchaseOrder(TGGrn.Item(0, e.RowIndex).Value)
        ElseIf e.ColumnIndex = 7 Then
            pnlFrieght.Visible = True
            pnlFrieght.BringToFront()
            cmbCourier2.Focus()
            lblRefNo.Text = TGGrn.Item(0, e.RowIndex).Value
            GetFreightDetails(Val(lblRefNo.Text))
        ElseIf e.ColumnIndex = 8 Then
            If IsAdmin = False Then Exit Sub
            If MsgBox("Do you want to delete..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            SQL = "delete from rvchmaster where vchno=" & Val(TGGrn.Item(0, e.RowIndex).Value) & ";" _
                & "delete from rvchdetails where vchno=" & Val(TGGrn.Item(0, e.RowIndex).Value)
            ESSA.Execute(SQL)
            MsgBox("Entry deleted successfully..!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub GetFreightDetails(iVchNo As Integer)

        SQL = "SELECT COURIER,PODNO,PODDT,TRANSPORT,LRNO,LRDT,REMARKS FROM RVCHMASTER WHERE VCHNO=" & iVchNo
        With ESSA.OpenReader(SQL)
            If .Read Then
                cmbCourier2.SelectedIndex = cmbCourier2.FindStringExact(.GetString(0).Trim)
                txtPODNo2.Text = .GetString(1).Trim
                dtpPOD2.Value = .GetDateTime(2).Date
                cmbTransport2.SelectedIndex = cmbTransport2.FindStringExact(.GetString(3).Trim)
                txtLRNo2.Text = .GetString(4).Trim
                dtpLRDt2.Value = .GetDateTime(5).Date
                txtRemarks.Text = .GetString(6).Trim
            End If
            .Close()
        End With

    End Sub

    Private Sub ManualReturn_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlGList, Me)

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        SQL = "UPDATE RVCHMASTER SET COURIER='{0}', PODNO='{1}', PODDT='{2}', TRANSPORT='{3}', LRNO='{4}', LRDT='{5}', REMARKS = '{7}'  WHERE VCHNO={6}"
        SQL = String.Format(SQL, cmbCourier2.Text.Trim, txtPODNo2.Text.Trim, Format(dtpPOD2.Value, "yyyy-MM-dd"), cmbTransport2.Text.Trim, txtLRNo2.Text.Trim, Format(dtpLRDt2.Value, "yyyy-MM-dd"), Val(TGGrn.Item(0, TGGrn.CurrentRow.Index).Value), txtRemarks.Text.Trim)
        ESSA.Execute(SQL)
        MsgBox("Freight info updated successfully..!", MsgBoxStyle.Information)
        pnlFrieght.Visible = False
        LoadTransportDetails()

    End Sub

    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click

        pnlFrieght.Visible = False

    End Sub

    Private Sub cmbCTax_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCTax.KeyDown

        AutomatedEntry()

    End Sub

    Private Sub TGGrn_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles TGGrn.CellFormatting

        For i As Integer = 0 To TGGrn.Rows.Count - 1
            If TGGrn.Item(5, i).Value.ToString = "" And Val(TGGrn.Item(0, i).Value) > 4549 Then
                TGGrn.Rows(i).Cells(2).Style.Font = New Font(TGGrn.DefaultCellStyle.Font, FontStyle.Bold)
            End If
        Next

    End Sub

    Private Function CheckVendorId() As Boolean

        CheckVendorId = True

        SQL = "SELECT VendorId FROM ProductMaster WHERE PluCode = '" & txtCode.Text.Trim & "'"

        With ESSA.OpenReader(SQL)

            If .Read Then
                If cmbVendor.SelectedValue <> Val(.Item(0)) Then
                    CheckVendorId = False
                End If
            End If
            .Close()

        End With

        Return CheckVendorId

    End Function

    Private Sub btnHideEditPnl_Click(sender As Object, e As EventArgs) Handles btnHideEditPnl.Click

        pnlGList.Hide()

    End Sub
    Private Sub AutomatedEntry()

        Dim NRI = ESSA.FindGridIndex(TG, 0, PluID)

        If NRI = -1 Then

            If Val(txtRQty.Text) > Val(txtStock.Text) Then
                TTip.Show("Insufficient Stock..!", txtRQty, 0, 25, 2000)
                Exit Sub
            End If

        Else

            If Val(TG.Item(4, NRI).Value) + Val(txtRQty.Text) > Val(txtStock.Text) Then
                TTip.Show("Insufficient Stock..!", txtRQty, 0, 25, 2000)
                Exit Sub
            End If

        End If
        If Isa.FoundInList(cmbCTax) = False Then
            TTip.Show("Choose Yes or No", cmbCTax, 0, 25, 2000)
            Exit Sub
        End If

        Dim Amount As Double = 0
        Dim TaxAmt As Double = 0
        Dim DisAmt As Double = 0

        If NRI = -1 Then NRI = TG.Rows.Add

        TG.Item(0, NRI).Value = PluID
        TG.Item(1, NRI).Value = NRI + 1
        TG.Item(2, NRI).Value = txtCode.Text
        TG.Item(3, NRI).Value = PluNm
        TG.Item(4, NRI).Value = Val(TG.Item(4, NRI).Value) + Val(txtRQty.Text)
        TG.Item(5, NRI).Value = Format(Val(txtRate.Text), "0.000")

        Amount = Val(TG.Item(4, NRI).Value) * Val(txtRate.Text)

        DisAmt = (Amount / 100) * Val(txtDisPerc.Text)

        TaxAmt = (((Amount - DisAmt) * Val(txtTax.Text)) / 100)

        TG.Item(6, NRI).Value = Format(Amount, "0.00")
        TG.Item(7, NRI).Value = Format(Val(txtTax.Text), "0.0")
        TG.Item(8, NRI).Value = Format(TaxAmt, "0.00")
        TG.Item(9, NRI).Value = Format((Amount - DisAmt) + TaxAmt, "0.00")
        TG.Item(10, NRI).Value = cmbCTax.Text.Trim

        TG.Item(11, NRI).Value = Format(Val(txtDisPerc.Text), "0.0")
        TG.Item(12, NRI).Value = Format(DisAmt, "0.00")

        txtCode.Clear()
        txtStock.Clear()
        txtRate.Clear()
        txtRQty.Clear()
        txtCode.Focus()
        txtTax.Clear()

        CalulateTotal()

    End Sub

    Private Sub cmbVendor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVendor.SelectedValueChanged

        'for essa garments vendor only
        If cmbVendor.SelectedValue = 1 Then
            txtRQty.Enabled = False
            txtDisPerc.Enabled = False
            txtTax.Enabled = False
            cmbCTax.SelectedIndex = 1  'making igst false
        Else
            txtRQty.Enabled = True
            txtDisPerc.Enabled = True
            txtTax.Enabled = True
            cmbCTax.SelectedIndex = 0
        End If
    End Sub
End Class