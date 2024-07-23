'********************************* In the name of Allah, Most Merciful, Most Compassionate **************************
Imports System.Data.SqlClient
Public Class GeneralDelivery

    Private PluID As Integer
    Private Edit As Boolean = False
    Private Rpt As New RptGeneralDelivery

    Private Sub GenerateEntryID()

        SQL = "select max(vchno) from DCMast"
        txtClnNo.Text = ESSA.GenerateID(SQL)

    End Sub

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            SQL = "select p.pluid,plucode,pluname,retailprice,stock from productmaster p,v_stockpos v " _
                & "where p.pluid=v.pluid and v.location_id = " & ShopID & " and plucode='" & txtCode.Text.Trim & "'"

            With ESSA.OpenReader(SQL)
                If .Read Then
                    PluID = .Item(0)
                    txtCode.Text = .GetString(1).Trim
                    txtPlunm.Text = .GetString(2)
                    txtRate.Text = Format(.Item(3), "0.00")
                    lblStock.Text = .Item(4)
                    txtQty.Text = 1
                    txtQty.Focus()
                Else
                    TTip.Show("Sorry, Product code not found..!", txtCode, 0, 25, 2000)
                    txtCode.SelectAll()
                    Exit Sub
                End If
                .Close()
            End With

        End If

    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Val(txtQty.Text) > Val(lblStock.Text) Then
                TTip.Show("Insufficient Stock..!", txtQty, 0, 25, 2000)
                Exit Sub
            End If

            Dim NRI = ESSA.FindGridIndex(TG, 0, PluID)
            If NRI = -1 Then NRI = TG.Rows.Add

            If Not NRI = -1 Then
                If Val(TG.Item(4, NRI).Value) + Val(txtQty.Text) > Val(lblStock.Text) Then
                    TTip.Show("Already entered..!", txtQty, 0, 25, 2000)
                    Exit Sub
                End If
            End If

            TG.Item(0, NRI).Value = PluID
            TG.Item(1, NRI).Value = txtCode.Text.Trim
            TG.Item(2, NRI).Value = txtPlunm.Text.Trim
            TG.Item(3, NRI).Value = Format(Val(txtRate.Text), "0.00")
            TG.Item(4, NRI).Value = Val(TG.Item(4, NRI).Value) + Val(txtQty.Text)
            TG.Item(5, NRI).Value = Format(Val(txtRate.Text) * Val(TG.Item(4, NRI).Value), "0.00")

            lblTQty.Text = ESSA.GetColTotal(TG, 4)
            lblTAmt.Text = Format(ESSA.GetColTotal(TG, 5), "0.00")

            txtCode.Clear()
            txtRate.Clear()
            txtPlunm.Clear()
            txtQty.Clear()
            lblStock.Text = "0.00"
            txtCode.Focus()

        End If

    End Sub

    Private Sub GeneralDelivery_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.F2
                btnSave.PerformClick()
            Case Keys.F3
                ' btnEdit.PerformClick()
            Case Keys.F5
                btnReset.PerformClick()
            Case Keys.Escape
                btnClose.PerformClick()
            Case Keys.Enter
                If Me.ActiveControl.Tag <> "1" Then
                    e.SuppressKeyPress = True
                    Me.ProcessTabKey(True)
                End If

        End Select

    End Sub

    Private Sub RefreshForm()

        Edit = False
        ESSA.ClearTextBox(Panel1)
        TG.Rows.Clear()
        lblTQty.Text = "0"
        lblStock.Text = "0"
        lblTAmt.Text = "0.00"
        GenerateEntryID()
        cmbCust.Focus()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If cmbCust.SelectedIndex = -1 Then
            TTip.Show("Customer name not selected..!", cmbCust, 0, 25, 2000)
            cmbCust.Focus()
            Exit Sub
        ElseIf TG.Rows.Count = 0 Then
            TTip.Show("No products to save..!", btnSave, 0, 25, 2000)
            Exit Sub
        End If

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction
        Cmd.Transaction = Trn

        Try

            If Edit = False Then
                GenerateEntryID()
            Else
                SQL = "delete from DCMast where VchNo=" & Val(txtClnNo.Text) & ";" _
                    & "delete from DCDet where VchNo=" & Val(txtClnNo.Text)
                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()
            End If

            SQL = "insert into DCMast values (" _
                & Val(txtClnNo.Text) & ",'" _
                & Format(CDate(mebClnDt.Text), "yyyy-MM-dd") & "'," _
                & cmbCust.SelectedValue & ",'" _
                & txtRemarks.Text.Trim & "'," _
                & Val(lblTQty.Text) & "," _
                & Val(lblTAmt.Text) & "," _
                & UserID & ")"

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            For i As Short = 0 To TG.Rows.Count - 1

                SQL = "insert into DCDet values (" _
                    & Val(txtClnNo.Text) & "," _
                    & Val(TG.Item(0, i).Value) & "," _
                    & Val(TG.Item(4, i).Value) & "," _
                    & Val(TG.Item(3, i).Value) & "," _
                    & i + 1 & ")"

                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()

                If isReceivable() Then

                    SQL = "INSERT INTO GDeliveryVerify VALUES (" _
                    & Val(txtClnNo.Text) & "," _
                    & Val(TG.Item(0, i).Value) & "," _
                    & Val(TG.Item(4, i).Value) & ",0)"

                    Cmd.CommandText = SQL
                    Cmd.ExecuteNonQuery()

                End If

            Next

            Trn.Commit()
            Con.Close()

        Catch ex As Exception
            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        If MsgBox("Entry saved successfully, Do you want to print..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            PrintBill(Val(txtClnNo.Text), CDate(mebClnDt.Text).Date, cmbCust.Text)
        End If

        RefreshForm()

    End Sub

    Private Sub AlterBill()

        SQL = "select vchno,vchdt,custid,remarks from dcmast where vchno=" & TGAlter.Item(0, TGAlter.CurrentRow.Index).Value & ";" _
            & "select d.pluid,p.plucode,p.pluname,d.rate,d.qty,sum(d.qty*d.rate) from " _
            & "productmaster p,dcdet d where p.pluid=d.pluid and d.vchno=" & TGAlter.Item(0, TGAlter.CurrentRow.Index).Value & " group by d.pluid,p.plucode,p.pluname,d.rate,d.qty,d.sno " _
            & "order by d.sno"

        With ESSA.OpenReader(SQL)

            If .Read Then

                Edit = True
                txtClnNo.Text = .Item(0)
                mebClnDt.Text = Format(.GetDateTime(1).Date, "dd-MM-yyyy")
                cmbCust.SelectedValue = .Item(2)
                txtRemarks.Text = .GetString(3).Trim

            End If

            .NextResult()

            TG.Rows.Clear()
            While .Read

                TG.Rows.Add()
                TG.Item(0, TG.Rows.Count - 1).Value = .Item(0)
                TG.Item(1, TG.Rows.Count - 1).Value = .GetString(1)
                TG.Item(2, TG.Rows.Count - 1).Value = .GetString(2)
                TG.Item(3, TG.Rows.Count - 1).Value = Format(.Item(3), "0.00")
                TG.Item(4, TG.Rows.Count - 1).Value = .Item(4)
                TG.Item(5, TG.Rows.Count - 1).Value = Format(.Item(5), "0.00")

            End While
            .Close()

        End With

        GetTotal()

        pnlAlter.Visible = False

    End Sub

    Private Sub GetTotal()

        lblTQty.Text = ESSA.GetColTotal(TG, 4)
        lblTAmt.Text = Format(ESSA.GetColTotal(TG, 5), "0.00")

    End Sub

    Private Sub GeneralDelivery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GenerateEntryID()
        ESSA.LoadCustomers(cmbCust)
        mebClnDt.Text = Format(Now.Date, "dd-MM-yyyy")
        cmbCust.Select()

        ESSA.AlignHeader(TG, 3, DataGridViewContentAlignment.MiddleRight)
        ESSA.AlignHeader(TG, 4, DataGridViewContentAlignment.MiddleRight)
        ESSA.AlignHeader(TG, 5, DataGridViewContentAlignment.MiddleRight)

        ESSA.AlignHeader(TGAlter, 3, DataGridViewContentAlignment.MiddleRight)
        ESSA.AlignHeader(TGAlter, 4, DataGridViewContentAlignment.MiddleRight)

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        ESSA.LoadCustomers(cmbCust)
        mebClnDt.Text = Format(Now.Date, "dd-MM-yyyy")
        RefreshForm()

    End Sub

    Private Sub TG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TG.KeyUp

        If e.KeyCode = Keys.F9 Then
            TG.Rows.RemoveAt(TG.CurrentRow.Index)
        End If

    End Sub

    Private Sub TG_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles TG.RowsRemoved

        GetTotal()

    End Sub

    Private Sub GeneralDelivery_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlAlter, Me)

    End Sub

    Private Sub btnAlter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlter.Click

        SQL = "select m.vchno,m.vchdt,c.customername,m.totqty,m.totamt from " _
            & "dcmast m,customers c where m.custid=c.customerid order by m.vchno"

        TGAlter.Rows.Clear()
        With ESSA.OpenReader(SQL)
            While .Read
                TGAlter.Rows.Add()
                TGAlter.Item(0, TGAlter.Rows.Count - 1).Value = .Item(0)
                TGAlter.Item(1, TGAlter.Rows.Count - 1).Value = Format(.GetDateTime(1).Date, "dd-MM-yyyy")
                TGAlter.Item(2, TGAlter.Rows.Count - 1).Value = .GetString(2).Trim
                TGAlter.Item(3, TGAlter.Rows.Count - 1).Value = .Item(3)
                TGAlter.Item(4, TGAlter.Rows.Count - 1).Value = Format(.Item(4), "0.00")
            End While
            .Close()
        End With

        If TGAlter.Rows.Count > 0 Then
            pnlAlter.Visible = True
            TGAlter.Focus()
        End If

    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click

        pnlAlter.Visible = False

    End Sub

    Private Sub PrintBill(ByVal iVchNo As Short, ByVal iVchDt As Date, ByVal Cust As String)

        If chkCostPrice.Checked Then
            SQL = "select p.plucode,p.pluname,p.costprice rate,d.qty from " _
            & "productmaster p,dcdet d where p.pluid=d.pluid and d.vchno=" & iVchNo & " order by d.sno"
        Else
            SQL = "select p.plucode,p.pluname,d.rate,d.qty from " _
            & "productmaster p,dcdet d where p.pluid=d.pluid and d.vchno=" & iVchNo & " order by d.sno"
        End If

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                Rpt.SetDataSource(Tbl)
                Rpt.SetParameterValue("VchNo", iVchNo)
                Rpt.SetParameterValue("VchDt", Format(iVchDt, "dd-MM-yyyy"))
                Rpt.SetParameterValue("Customer", Cust)
                ReportViewer.CViewer.ReportSource = Rpt
                ReportViewer.Show()
            End Using
        End Using
        Con.Close()

    End Sub

    Private Sub TGAlter_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TGAlter.CellClick

        If e.ColumnIndex = 5 Then
            AlterBill()
        ElseIf e.ColumnIndex = 6 Then
            PrintBill(TGAlter.Item(0, e.RowIndex).Value, CDate(TGAlter.Item(1, e.RowIndex).Value).Date, TGAlter.Item(2, e.RowIndex).Value)
            btnHide.PerformClick()
        End If

    End Sub

    Private Sub TG_KeyDown(sender As Object, e As KeyEventArgs) Handles TG.KeyDown

        If e.KeyCode = Keys.Delete Then
            TG.Rows.RemoveAt(TG.CurrentRow.Index)
        End If

    End Sub

    Private Function isReceivable() As Boolean

        isReceivable = False

        SQL = "SELECT isReceivable FROM Customers WHERE CustomerId = " & cmbCust.SelectedValue

        With ESSA.OpenReader(SQL)
            If .Read Then
                If Val(.Item(0)) = 1 Then
                    isReceivable = True
                End If
            End If
            .Close()
        End With

    End Function

End Class