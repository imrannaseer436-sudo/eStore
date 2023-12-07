Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports OfficeOpenXml
Public Class NewBillGenerator

    Private Rpt As New PaymentBillSummary
    Private Rpt1 As New RptPaymentSummarySW
    Private Rpt2 As New RptGrnWiseStatus
    Private Rpt3 As New RptProductStatusReport2
    Private VchNo As String = ""
    Private AdvEntryNo As String = ""
    Private EditNotes As Boolean = False
    'Private EnableRemarks As Boolean = False

    Private Sub NewBillGenerator_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                btnRefresh.PerformClick()
            Case Keys.Enter

                If Me.ActiveControl.Tag <> "1" Then
                    e.SuppressKeyPress = True
                    Me.ProcessTabKey(True)
                End If

        End Select


    End Sub

    Private Sub GenerateBillNo()

        SQL = "select max(billno) from paymentmaster"
        txtBillNo.Text = ESSA.GenerateID(SQL)

    End Sub

    Private Sub NewBillGenerator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GenerateBillNo()

        SQL = "select vendorid,vendorname from vendors where vendorid in (select distinct vendorid from  " _
            & "grnmaster where billno=0) order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid")

        SQL = "select vendorid,vendorname from vendors where vendorid in (select distinct vendorid from  " _
          & "paymentmaster) order by vendorname"
        ESSA.LoadCombo(cmbVendor2, SQL, "vendorname", "vendorid", "All Vendor(s)")

        'old
        'SQL = "select ledgerid,ledgername from ledger where groupid=5 order by ledgername"

        SQL = "select ledgerid,ledgername from ledger order by ledgername"

        ESSA.LoadCombo(cmbLedger, SQL, "ledgername", "ledgerid")

        cmbMode.SelectedIndex = 0

        Dim NCI As SByte
        Dim id As String = ""

        TG.Columns.Clear()

        NCI = TG.Columns.Add("", "Inv No")
        TG.Columns(NCI).Width = 60

        NCI = TG.Columns.Add("", "Date")
        TG.Columns(NCI).Width = 70

        NCI = TG.Columns.Add("", "R.Date")
        TG.Columns(NCI).Width = 70

        NCI = TG.Columns.Add("", "Material Name")
        TG.Columns(NCI).Width = TG.Width - 1241

        For I As Short = 0 To 18

            id = GetSize(I)
            NCI = TG.Columns.Add("", id)
            TG.Columns(NCI).Width = 45
            TG.Columns(NCI).SortMode = DataGridViewColumnSortMode.NotSortable
            TG.Columns(NCI).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

        Next

        AddColumn("Quantity", 19, 50, DataGridViewContentAlignment.MiddleRight)
        AddColumn("Rate", 19, 50, DataGridViewContentAlignment.MiddleRight)
        AddColumn("Amount", 19, 70, DataGridViewContentAlignment.MiddleRight)
        AddColumn("", 19, 15, DataGridViewContentAlignment.MiddleRight)

        TGBank.ColumnHeadersDefaultCellStyle.Font = New Font(TGBank.Font, FontStyle.Bold)

    End Sub

    Private Sub CalculateTax()

        Dim Tmp As Double = 0
        Dim Tmp1 As Double = 0

        For i As SByte = 0 To TGTax.Rows.Count - 1
            Tmp += Val(TGTax.Item(5, i).Value)
        Next

        For j As Short = 0 To TG.Rows.Count - 1
            Tmp1 += Val(TG.Item(TG.Columns.Count - 2, j).Value)
        Next

        lblBillAmt.Text = Format(Tmp1, "0.00")
        Tmp += Tmp1 - (Val(lblDebit.Text) + Val(lblAdvance.Text))
        lblAmt.Text = Format(Tmp, "0.00")
        lblNett.Text = Format(Tmp, "0.00")

    End Sub

    Private Sub AddColumn(ByVal HeaderText As String, ByVal ColumnIndex As SByte, ByVal Width As Integer, ByVal Align As DataGridViewContentAlignment)

        ColumnIndex = TG.Columns.Add("", HeaderText)
        TG.Columns(ColumnIndex).Width = Width
        TG.Columns(ColumnIndex).SortMode = DataGridViewColumnSortMode.NotSortable
        TG.Columns(ColumnIndex).HeaderCell.Style.Alignment = Align

    End Sub

    'Private Function GetSize(ByVal id As String) As String

    '    Select Case id

    '        Case 1
    '            GetSize = 22
    '        Case 2
    '            GetSize = 24
    '        Case 3
    '            GetSize = 26
    '        Case 4
    '            GetSize = 28
    '        Case 5
    '            GetSize = 30
    '        Case 6
    '            GetSize = 32
    '        Case 7
    '            GetSize = 34
    '        Case 8
    '            GetSize = 36
    '        Case 9
    '            GetSize = 38 & vbCrLf & "S"
    '        Case 10
    '            GetSize = 40 & vbCrLf & "M"
    '        Case 12
    '            GetSize = 42 & vbCrLf & "L"
    '        Case 14
    '            GetSize = 44 & vbCrLf & "XL"
    '        Case 16
    '            GetSize = 46 & vbCrLf & "2XL"
    '        Case 18
    '            GetSize = 48 & vbCrLf & "3XL"
    '        Case 20
    '            GetSize = 0 & vbCrLf & "4XL"
    '        Case Else
    '            GetSize = ""

    '    End Select

    'End Function

    Private Function GetSize(ByVal iID As String) As String

        GetSize = ""

        Select Case iID

            Case 0
                GetSize = "0" & vbCrLf & "12" & vbCrLf & "35"
            Case 1
                GetSize = "1" & vbCrLf & "14" & vbCrLf & "40"
            Case 2
                GetSize = "2" & vbCrLf & "16" & vbCrLf & "45"
            Case 3
                GetSize = "3" & vbCrLf & "18" & vbCrLf & "50"
            Case 4
                GetSize = "4" & vbCrLf & "20" & vbCrLf & "55"
            Case 5
                GetSize = "5" & vbCrLf & "22" & vbCrLf & "60"
            Case 6
                GetSize = "6" & vbCrLf & "24" & vbCrLf & "65"
            Case 7
                GetSize = "7" & vbCrLf & "26" & vbCrLf & "70"
            Case 8
                GetSize = "8" & vbCrLf & "28" & vbCrLf & "75"
            Case 9
                GetSize = "9" & vbCrLf & "30" & vbCrLf & "80"
            Case 10
                GetSize = "10" & vbCrLf & "32" & vbCrLf & "85"
            Case 11
                GetSize = "11" & vbCrLf & "34" & vbCrLf & "90"
            Case 12
                GetSize = "S" & vbCrLf & "36" & vbCrLf & "95"
            Case 13
                GetSize = "M" & vbCrLf & "38" & vbCrLf & "100"
            Case 14
                GetSize = "L" & vbCrLf & "40" & vbCrLf & "105"
            Case 15
                GetSize = "XL" & vbCrLf & "42" & vbCrLf & "110"
            Case 16
                GetSize = "XXL" & vbCrLf & "44" & vbCrLf & "115"
            Case 17
                GetSize = "XXXL" & vbCrLf & "46" & vbCrLf & "120"
            Case 18
                GetSize = "XXXXL" & vbCrLf & "48" & vbCrLf & "125"

        End Select

    End Function

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        If chkDBL.Checked = True Then

            SQL = "select invno,invdt,grnno from grnmaster where billno=0 and " _
                & "VENDORID=" & cmbVendor.SelectedValue _
                & " AND INVDT BETWEEN '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd") & "' ORDER BY GRNNO"

            TGBill.Rows.Clear()
            With ESSA.OpenReader(SQL)
                While .Read
                    TGBill.Rows.Add()
                    TGBill.Item(1, TGBill.Rows.Count - 1).Value = .Item(0)
                    TGBill.Item(2, TGBill.Rows.Count - 1).Value = Format(.GetDateTime(1).Date, "dd-MM-yyyy")
                    TGBill.Item(4, TGBill.Rows.Count - 1).Value = .Item(2)
                End While
                .Close()
            End With

            If TGBill.Rows.Count > 0 Then
                pnlBill.Visible = True
                TGBill.Focus()
            Else
                MsgBox("No pending bills..!", MsgBoxStyle.Information)
            End If

            Exit Sub

        End If

        LoadBillDetails()

    End Sub

    Private Sub LoadBillDetails()

        Dim FGRN As String = GetGRNNo()

        If chkDBL.Checked = True And FGRN.Length <= 0 Then
            MsgBox("Sorry, Bill number not selected..!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim Qty As Double = 0
        Dim NCI As Short
        Dim at As Double = 0
        Dim id As String = ""
        Dim Fr As Boolean = True
        Dim Tt As Double = 0
        Dim GNo As Short = 0

        id = ""

        If chkDBL.Checked = True Then

            SQL = "SELECT M.GRNNO,L.CATEGORY,SUM(D.QTY) PQTY,D.COSTPRICE,V.NID,M.REFDT,M.INVNO,M.INVDT FROM GRNDETAILS D,PRODUCTATTRIBUTES L,GRNMASTER M,V_CODEWITHNID V " _
                & "WHERE L.PLUID=D.PLUID AND M.GRNNO=D.GRNNO AND D.PLUID=V.PLUID AND M.BILLNO=0 AND M.GRNNO IN (" & FGRN & ")" _
                & " GROUP BY M.GRNNO,L.CATEGORY,D.COSTPRICE,V.NID,M.REFDT,M.INVNO,M.INVDT ORDER BY M.GRNNO,D.COSTPRICE"

        Else

            SQL = "SELECT M.GRNNO,L.CATEGORY,SUM(D.QTY) PQTY,D.COSTPRICE,V.NID,M.REFDT,M.INVNO,M.INVDT FROM GRNDETAILS D,PRODUCTATTRIBUTES L,GRNMASTER M,V_CODEWITHNID V " _
                & "WHERE L.PLUID=D.PLUID AND M.GRNNO=D.GRNNO AND D.PLUID=V.PLUID AND M.BILLNO=0 AND M.VENDORID=" & cmbVendor.SelectedValue _
                & " AND M.INVDT BETWEEN '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(mebTo.Value, "yyyy-MM-dd") & "'" _
                & " GROUP BY M.GRNNO,L.CATEGORY,D.COSTPRICE,V.NID,M.REFDT,M.INVNO,M.INVDT ORDER BY M.GRNNO,D.COSTPRICE"

        End If


        at = 0
        Tt = 0
        Fr = True

        TG.Rows.Clear()
        LstGRN.Items.Clear()

        With ESSA.OpenReader(SQL)

            While .Read

                If GNo <> .Item(0) Then
                    LstGRN.Items.Add(.Item(0))
                    GNo = .Item(0)
                End If

                If at <> .Item(3) Then
                    If Fr = False Then
                        TG.Item(TG.Columns.Count - 4, NCI).Value = Tt
                        TG.Item(TG.Columns.Count - 2, NCI).Value = Format(Tt * Val(TG.Item(TG.Columns.Count - 3, NCI).Value), "0.00")
                        Tt = 0
                    End If
                    Fr = False
                    NCI = TG.Rows.Add()
                    TG.Item(0, NCI).Value = .Item(6)
                    TG.Item(1, NCI).Value = Format(.GetDateTime(7).Date, "dd-MM-yyyy")
                    TG.Item(2, NCI).Value = Format(.GetDateTime(5).Date, "dd-MM-yyyy")
                    TG.Item(3, NCI).Value = .GetString(1)
                    TG.Item(TG.Columns.Count - 3, NCI).Value = Format(.Item(3), "0.000")

                    at = .Item(3)
                End If
                TG.Item(GetColIndex(.Item(4)), NCI).Value = .Item(2)
                Tt += .Item(2)
                Qty += .Item(2)

            End While

            If TG.Rows.Count > 0 Then
                TG.Item(TG.Columns.Count - 4, NCI).Value = Tt
                TG.Item(TG.Columns.Count - 2, NCI).Value = Format(Tt * Val(TG.Item(TG.Columns.Count - 3, NCI).Value), "0.00")
            End If

            .Close()

        End With

        SQL = "SELECT EntryNo,SUM(TotalAmount) FROM AdvPaymentMaster WHERE EntryDate <= " _
            & " GetDate() AND VendorId = " _
            & cmbVendor.SelectedValue & " AND BILLNO = 0 GROUP BY EntryNo"

        Dim advAmount As Double = 0
        AdvEntryNo = ""

        With ESSA.OpenReader(SQL)
            While .Read
                AdvEntryNo &= .Item(0) & ","
                advAmount += Val(.Item(1))
            End While
            .Close()
        End With

        lblAdvance.Text = Format(advAmount, "0.00")
        If AdvEntryNo.Trim.Length > 0 Then
            AdvEntryNo = Mid(AdvEntryNo, 1, AdvEntryNo.Length - 1)
        End If

        If chkLCDA.Checked = True Then

            SQL = "select vchno,sum(netamt) from rvchmaster where vchdt<='" _
                & Format(Now.Date, "yyyy-MM-dd") & "' and vendorid=" & cmbVendor.SelectedValue _
                & " and billno=0 and LocalReturn=0 group by vchno"

        Else

            SQL = "select vchno,sum(netamt) from rvchmaster where vchdt<='" _
                & Format(mebTo.Value, "yyyy-MM-dd") & "' and vendorid=" & cmbVendor.SelectedValue _
                & " and billno=0 and LocalReturn=0 group by vchno"

        End If

        Dim Tmp As Double = 0
        VchNo = ""

        With ESSA.OpenReader(SQL)

            While .Read

                VchNo &= .Item(0) & ","
                Tmp += Val(.Item(1))

            End While
            .Close()
        End With

        lblQty.Text = Qty
        lblDebit.Text = Format(Tmp, "0.00")
        If VchNo.Trim.Length > 0 Then
            VchNo = Mid(VchNo, 1, VchNo.Length - 1)
        End If

        pnlBill.Visible = False
        CalculateTax()

    End Sub

    Private Function GetColIndex(ByVal iSize As String) As SByte

        GetColIndex = 0

        Select Case iSize

            Case "0"
                GetColIndex = 4
            Case "1"
                GetColIndex = 5
            Case "2"
                GetColIndex = 6
            Case "3"
                GetColIndex = 7
            Case "4"
                GetColIndex = 8
            Case "5"
                GetColIndex = 9
            Case "6"
                GetColIndex = 10
            Case "7"
                GetColIndex = 11
            Case "8"
                GetColIndex = 12
            Case "9"
                GetColIndex = 13
            Case "10"
                GetColIndex = 14
            Case "11"
                GetColIndex = 15
            Case "S"
                GetColIndex = 16
            Case "M"
                GetColIndex = 17
            Case "L"
                GetColIndex = 18
            Case "XL"
                GetColIndex = 19
            Case "XXL"
                GetColIndex = 20
            Case "XXXL"
                GetColIndex = 21
            Case "XXXXL"
                GetColIndex = 22

        End Select

    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        RefreshBill()

    End Sub

    Private Sub cmbMode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMode.KeyPress

        e.Handled = False

    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            Dim NRI = ESSA.FindGridIndex(TGTax, 0, cmbLedger.SelectedValue)
            If NRI = -1 Then NRI = TGTax.Rows.Add

            TGTax.Item(0, NRI).Value = cmbLedger.SelectedValue
            TGTax.Item(1, NRI).Value = cmbLedger.Text
            TGTax.Item(2, NRI).Value = cmbMode.Text
            TGTax.Item(3, NRI).Value = Format(Val(txtPerc.Text), "0.00")
            TGTax.Item(4, NRI).Value = Format(Val(txtAmount.Text), "0.00")
            If cmbMode.SelectedIndex = 0 Then
                TGTax.Item(5, NRI).Value = Format(Val(txtAmount.Text), "0.00")
            Else
                TGTax.Item(5, NRI).Value = Format(-Val(txtAmount.Text), "0.00")
            End If

            CalculateTax()

            txtAmount.Clear()
            txtPerc.Clear()
            cmbLedger.Focus()

        End If

    End Sub

    Private Sub txtPerc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPerc.KeyUp

        txtAmount.Text = Format((Val(lblBillAmt.Text) * Val(txtPerc.Text)) / 100, "0.00")

    End Sub

    Private Sub NewBillGenerator_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlTax, Me)

        ESSA.MovetoCenter(pnlAlter, Me)

        ESSA.MovetoCenter(pnlBankList, Me)

        ESSA.MovetoCenter(pnlExcelExport, Me)

    End Sub

    Private Sub btnATax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnATax.Click

        pnlTax.Visible = True
        cmbLedger.Focus()

    End Sub

    Private Sub LoadBankList(iVendorId As Integer)

        SQL = "select r.sno,b.bankname,r.acno,r.acname,r.ifsc,r.actype,r.bankid from bankregister r,banklist b " _
            & "where r.bankid=b.bankid and r.vendorid={0} order by r.sno"

        With ESSA.OpenReader(String.Format(SQL, iVendorId))
            TGBank.Rows.Clear()
            While .Read
                TGBank.Rows.Add()
                TGBank.Item(0, TGBank.Rows.Count - 1).Value = .Item(0)
                TGBank.Item(1, TGBank.Rows.Count - 1).Value = TGBank.Rows.Count
                TGBank.Item(2, TGBank.Rows.Count - 1).Value = .GetString(1).Trim
                TGBank.Item(3, TGBank.Rows.Count - 1).Value = .GetString(2).Trim
                TGBank.Item(4, TGBank.Rows.Count - 1).Value = .GetString(3).Trim
                TGBank.Item(5, TGBank.Rows.Count - 1).Value = .GetString(4).Trim
                TGBank.Item(6, TGBank.Rows.Count - 1).Value = .Item(5)
                TGBank.Item(7, TGBank.Rows.Count - 1).Value = .Item(6)
            End While
            .Close()
        End With

    End Sub

    Private Sub SaveEntry()

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction
        Cmd.Transaction = Trn

        Try

            GenerateBillNo()
            SQL = "insert into paymentmaster values (" _
                & Val(txtBillNo.Text) & ",'" _
                & Format(CDate(mebBillDt.Text).Date, "yyyy-MM-dd") & "','" _
                & Format(mebFrom.Value, "yyyy-MM-dd") & "','" _
                & Format(mebTo.Value, "yyyy-MM-dd") & "'," _
                & cmbVendor.SelectedValue & "," _
                & Val(lblAdvance.Text) & "," _
                & Val(lblDebit.Text) & "," _
                & Val(lblNett.Text) & "," _
                & UserID & ",'" _
                & AdvEntryNo & "','" _
                & VchNo & "'," _
                & BKID & ",'" _
                & AcNo & "','" _
                & AcNm & "','" _
                & IFSC & "'," _
                & ACTy & ")"

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            'Dim GNo As Short = 0

            'For i As Short = 0 To TG.Rows.Count - 1

            '    If GNo <> Val(TG.Item(0, i).Value) Then

            '        SQL = "update grnmaster set billno=" & Val(txtBillNo.Text) _
            '            & " where grnno=" & Val(TG.Item(0, i).Value)

            '        Cmd.CommandText = SQL
            '        Cmd.ExecuteNonQuery()

            '        GNo = Val(TG.Item(0, i).Value)

            '    End If

            'Next


            For k As SByte = 0 To LstGRN.Items.Count - 1

                'SQL = "update grnmaster set billno={0},bankid={1},acno='{2}'," _
                '    & "acname='{3}',ifsc='{4}',actype={5} " _
                '    & "where grnno={6}"

                'SQL = String.Format(SQL, Val(txtBillNo.Text), BKID, AcNo, AcNm, IFSC, ACTy, LstGRN.Items(k))

                SQL = "update grnmaster set billno=" & Val(txtBillNo.Text) _
                      & " where grnno=" & LstGRN.Items(k)

                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()

            Next

            SQL = "update AdvPaymentMaster set billno=" & Val(txtBillNo.Text) & " where EntryDate <= GetDate() " _
                    & " and vendorid=" & cmbVendor.SelectedValue _
                    & " and billno=0"

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            If chkLCDA.Checked = True Then

                SQL = "update rvchmaster set billno=" & Val(txtBillNo.Text) & " where vchdt <= GetDate() " _
                    & " and vendorid=" & cmbVendor.SelectedValue _
                    & " and billno=0"

            Else

                SQL = "update rvchmaster set billno=" & Val(txtBillNo.Text) & " where vchdt<='" _
                    & Format(mebTo.Value, "yyyy-MM-dd") & "' and vendorid=" & cmbVendor.SelectedValue _
                    & " and billno=0"

            End If

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            For i As Short = 0 To TGTax.Rows.Count - 1

                SQL = "INSERT INTO PAYMENTTAX VALUES (" _
                    & Val(txtBillNo.Text) & "," _
                    & Val(TGTax.Item(0, i).Value) & "," _
                    & Val(TGTax.Item(3, i).Value) & "," _
                    & Val(TGTax.Item(5, i).Value) & "," _
                    & i + 1 & ")"

                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()

            Next

            Trn.Commit()
            Con.Close()

        Catch ex As SqlException
            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        If MsgBox("Bill generated successfully, do you want to print..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ViewBillSummaryNew(txtBillNo.Text, cmbVendor.Text, Format(mebFrom.Value, "dd-MM-yyyy") & " to " & Format(mebTo.Value, "dd-MM-yyyy"), Format(mebBillDt.Value, "dd-MM-yyyy"), Val(lblDebit.Text), Val(lblAdvance.Text))
        End If
        RefreshBill()

    End Sub

    Private Sub ViewBillSummary(ByVal iBillNo As Short, ByVal iVendor As String, ByVal iDuration As String, ByVal iBillDt As String, ByVal iDebit As Double)

        Dim NetAmt As Double = 0

        SQL = "SELECT L.LEDGERNAME,T.PERC,T.AMOUNT,M.NETAMT FROM LEDGER L,PAYMENTTAX T,PAYMENTMASTER M WHERE " _
            & "L.LEDGERID=T.LEDGERID AND T.BILLNO=" & iBillNo & " AND M.BILLNO=T.BILLNO ORDER BY T.SNO"

        With ESSA.OpenReader(SQL)
            If .Read Then
                NetAmt = .Item(3)
            End If
            .Close()
        End With

        'SQL = "select GrnNo,GrnDt,InvNo,InvDt,TotalAmount BillAmt,DebitAmt,(BillAmt-DebitAmt) NetAmt from grnmaster g,paymentmaster p where g.billno=p.billno and g.billno=" _
        '    & iBillNo & " order by GrnNo"

        ''SQL = "SELECT L.LEDGERNAME,T.AMOUNT FROM LEDGER L,PAYMENTTAX T " _
        ''    & "WHERE L.LEDGERID=T.LEDGERID ORDER BY T.SNO"

        Dim STbl As New DataTable
        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Adp.Fill(STbl)
        End Using
        Con.Close()

        SQL = "SELECT A.GRNNO,A.GRNDT,A.INVNO,A.REFNO,ISNULL(B.PERC,0) DEBITAMT,A.NETAMT,ISNULL(B.DIS,0) DISCOUNT,A.BILLAMT FROM (" _
            & "SELECT GRNNO,GRNDT,INVNO,INVDT,REFNO,REFDT,NETTAMOUNT NETAMT,TOTALAMOUNT BILLAMT FROM" _
            & " GRNMASTER WHERE BILLNO=" & iBillNo & ") A LEFT OUTER JOIN " _
            & "(SELECT T.PERC,M.GRNNO,SUM(-T.AMOUNT) DIS FROM GRNTAX T,GRNMASTER M WHERE M.GRNNO=T.GRNNO " _
            & "AND M.BILLNO=" & iBillNo & " AND T.LEDGERID=4 GROUP BY M.GRNNO,T.PERC) B ON A.GRNNO=B.GRNNO ORDER BY A.GRNNO"

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                Rpt.SetDataSource(Tbl)
                Rpt.Subreports.Item(0).SetDataSource(STbl)
                'Rpt.Subreports.Item(0).SetParameterValue("GTotal", NetAmt)
                Rpt.SetParameterValue("Vendor", iVendor)
                Rpt.SetParameterValue("BillNo", iBillNo)
                Rpt.SetParameterValue("BillDt", iBillDt)
                Rpt.SetParameterValue("Duration", iDuration)
                Rpt.SetParameterValue("Debit", iDebit)
                ReportViewer.CViewer.ReportSource = Rpt
                ReportViewer.Show()
            End Using
        End Using
        Con.Close()

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        LoadBankList(cmbVendor.SelectedValue)
        pnlTax.Visible = False
        pnlBankList.Visible = True
        pnlBankList.BringToFront()

    End Sub

    Private Sub ViewBillSummaryNew(ByVal iBillNo As Short, ByVal iVendor As String, ByVal iDuration As String, ByVal iBillDt As String, ByVal iDebit As Double, ByVal iAdvance As Double)

        Dim NetAmt As Double = 0
        Dim DbtDes As String = ""
        Dim AdvDes As String = ""
        Dim RefNo As String = ""
        Dim ChqNo As String = ""
        Dim ChqDate As String = ""
        Dim Remarks As String = ""
        Dim PartyReturn As Double = 0

        SQL = "SELECT ChequeNo,ChequeDate,Notes FROM PaymentNotes WHERE BillNo =" & iBillNo

        With ESSA.OpenReader(SQL)
            While .Read
                ChqNo &= .GetString(0).Trim & ","
                ChqDate &= Format(.GetDateTime(1), "dd-MM-yyyy") & ","
                Remarks &= .GetString(2).Trim & ","
            End While
            .Close()
        End With

        If ChqNo.Length > 0 Then
            ChqNo = Mid(ChqNo, 1, ChqNo.Length - 1)
        End If
        If ChqDate.Length > 0 Then
            ChqDate = Mid(ChqDate, 1, ChqDate.Length - 1)
        End If
        If Remarks.Length > 0 Then
            Remarks = Mid(Remarks, 1, Remarks.Length - 1)
        End If

        SQL = "SELECT DISTINCT REFNO FROM GRNMASTER WHERE BILLNO=" & iBillNo
        With ESSA.OpenReader(SQL)
            While .Read
                RefNo &= .GetString(0).Trim & ","
            End While
            .Close()
        End With

        If RefNo.Length > 0 Then
            RefNo = Mid(RefNo, 1, RefNo.Length - 1)
        End If

        SQL = "SELECT L.LEDGERNAME,T.PERC,T.AMOUNT,M.NETAMT,M.DBTDESC,ISNULL(M.AdvDesc,'') FROM LEDGER L,PAYMENTTAX T,PAYMENTMASTER M WHERE " _
            & "L.LEDGERID=T.LEDGERID AND T.BILLNO=" & iBillNo & " AND M.BILLNO=T.BILLNO ORDER BY T.SNO"

        With ESSA.OpenReader(SQL)
            If .Read Then
                NetAmt = .Item(3)
                DbtDes = .GetString(4)
                AdvDes = .GetString(5)
            End If
            .Close()
        End With

        SQL = "SELECT L.LEDGERNAME,T.PERC,T.AMOUNT,M.NETAMT,M.DBTDESC FROM LEDGER L,PAYMENTTAX T,PAYMENTMASTER M WHERE " _
          & "L.LEDGERID=T.LEDGERID AND T.BILLNO=" & iBillNo & " AND M.BILLNO=T.BILLNO ORDER BY T.SNO"

        Dim STbl As New DataTable
        Dim DSet As New DataSet
        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Adp.Fill(STbl)
            Adp.Fill(DSet)
        End Using
        Con.Close()

        Dim iGRNNo As String = ""

        SQL = "select grnno from grnmaster where billno=" & iBillNo & " order by grnno"
        With ESSA.OpenReader(SQL)
            While .Read
                iGRNNo &= .Item(0) & ","
            End While
        End With

        If iGRNNo.Length > 0 Then
            iGRNNo = Mid(iGRNNo, 1, iGRNNo.Length - 1)
        End If

        'SQL = "SELECT A.GRNNO,A.GRNDT,B.SCATDESC1,A.PQTY,SUM(B.D1) DC1,SUM(B.S1) SLS1,SUM(B.K1) STK1,SUM(B.D2) DC2,SUM(B.S2) SLS2,SUM(B.K2) STK2 FROM " _
        '    & "(SELECT GRNNO,GRNDT,TOTALQUANTITY PQTY FROM GRNMASTER WHERE GRNNO in (" & iGRNNo & ")) A " _
        '    & "LEFT OUTER JOIN " _
        '    & "(SELECT V.GRNNO,V.GRNDT,V.SCATDESC1,SUM(V.DC) D1,SUM(V.SALES) S1,SUM((V.DC-V.SALES)+V.RTN) K1,0 D2,0 S2,0 K2 " _
        '    & "FROM V_GRNWISESTATUS V WHERE V.DELIVERYTO=2 AND GRNNO in (" & iGRNNo & ") GROUP BY V.GRNNO,V.GRNDT,V.SCATDESC1 " _
        '    & "UNION ALL " _
        '    & "SELECT V.GRNNO,V.GRNDT,V.SCATDESC1,0,0,0,SUM(V.DC),SUM(V.SALES),SUM((V.DC-V.SALES)+V.RTN) " _
        '    & "FROM V_GRNWISESTATUS V WHERE V.DELIVERYTO=3 AND GRNNO in (" & iGRNNo & ") GROUP BY V.GRNNO,V.GRNDT,V.SCATDESC1) B ON A.GRNNO=B.GRNNO " _
        '    & "GROUP BY A.GRNNO,A.GRNDT,B.SCATDESC1,A.PQTY"

        'Dim STbl2 As New DataTable
        'ESSA.OpenConnection()
        'Using Adp As New SqlDataAdapter(SQL, Con)
        '    Adp.Fill(STbl2)
        'End Using
        'Con.Close()

        'SQL = "SELECT ISNULL(SUM(Quantity),0) FROM RvchMaster WHERE BillNo = " & iBillNo

        SQL = "SELECT ISNULL(SUM(D.Qty),0) FROM rvchmaster M, rvchdetails D,GRNMaster GM, GRNDetails GD " _
            & "WHERE M.vchno = D.vchno AND GM.GrnNo = GD.GRNNo AND M.billno = GM.BillNo AND D.pluid = GD.PluID AND M.billno = " & iBillNo

        With ESSA.OpenReader(SQL)

            If .Read Then
                PartyReturn = .Item(0)
            End If
            .Close()
        End With

        'YASEEN QUERY

        'SQL = "SELECT S.SHOPNAME,SUM(M.A) PURCHASE,SUM(M.B) DELIVERY,SUM(M.C) SALES,SUM(M.B-M.C) STOCK FROM SHOPS S," _
        '    & "(SELECT DISTINCT M.SHOPID,M.TotalQuantity A,0 B,0 C, M.InvNo FROM GRNDETAILS D,GRNMASTER M,PSR_PRODUCTGRNWISE V,PAYMENTMASTER P " _
        '    & "WHERE M.GRNNO=D.GRNNO AND D.PLUID=V.PLUID AND M.BILLNO=P.BILLNO AND P.BILLNO={0} " _
        '    & "UNION ALL " _
        '    & "SELECT M.DELIVERYTO,0,SUM(D.QUANTITY),0,0 FROM DELIVERYMASTER M,DELIVERYDETAILS D " _
        '    & "WHERE M.DELIVERYCODE=D.DELIVERYCODE AND D.PluID IN (SELECT DISTINCT PluID FROM GRNDetails GD,GRNMaster GM WHERE GD.GRNNo = GM.GrnNo AND GM.BillNo = {0}) " _
        '    & "GROUP BY M.DELIVERYTO " _
        '    & "UNION ALL " _
        '    & "SELECT M.DELIVERYFROM,0,SUM(-D.QUANTITY),0,0 FROM RECEIVEDMASTER M,RECEIVEDDETAILS D " _
        '    & "WHERE M.DELIVERYCODE=D.DELIVERYCODE AND D.PluID IN (SELECT DISTINCT PluID FROM GRNDetails GD,GRNMaster GM WHERE GD.GRNNo = GM.GrnNo AND GM.BillNo = {0}) " _
        '    & "GROUP BY M.DELIVERYFROM " _
        '    & "UNION ALL " _
        '    & "SELECT D.SHOPID,0,0,SUM(D.QTY),0 FROM BILLDETAILS D " _
        '    & "WHERE D.PluID IN (SELECT DISTINCT PluID FROM GRNDetails GD,GRNMaster GM WHERE GD.GRNNo = GM.GrnNo AND GM.BillNo = {0}) " _
        '    & "GROUP BY D.SHOPID) M WHERE M.SHOPID=S.SHOPID " _
        '    & "GROUP BY S.SHOPNAME,S.SHOPID ORDER BY S.SHOPID DESC"

        'SQL = "SELECT S.SHOPNAME,SUM(M.A) PURCHASE,SUM(M.B) DELIVERY,SUM(M.C) SALES,SUM(M.B-M.C) STOCK FROM SHOPS S," _
        '    & "(SELECT DISTINCT M.SHOPID,M.TotalQuantity A,0 B,0 C, M.InvNo FROM GRNDETAILS D,GRNMASTER M,PSR_PRODUCTGRNWISE V,PAYMENTMASTER P " _
        '    & "WHERE M.GRNNO=D.GRNNO AND D.PLUID=V.PLUID AND M.BILLNO=P.BILLNO AND P.BILLNO={0} " _
        '    & "UNION ALL " _
        '    & "SELECT M.DELIVERYTO,0,SUM(D.QUANTITY),0,0 FROM DELIVERYMASTER M,DELIVERYDETAILS D,PSR_PRODUCTGRNWISE V " _
        '    & "WHERE M.DELIVERYCODE=D.DELIVERYCODE AND D.PLUID=V.PLUID AND V.BILLNO={0} " _
        '    & "GROUP BY M.DELIVERYTO " _
        '    & "UNION ALL " _
        '    & "SELECT M.DELIVERYFROM,0,SUM(-D.QUANTITY),0,0 FROM RECEIVEDMASTER M,RECEIVEDDETAILS D,PSR_PRODUCTGRNWISE V " _
        '    & "WHERE M.DELIVERYCODE=D.DELIVERYCODE AND D.PLUID=V.PLUID AND V.BILLNO={0} " _
        '    & "GROUP BY M.DELIVERYFROM " _
        '    & "UNION ALL " _
        '    & "SELECT D.SHOPID,0,0,SUM(D.QTY),0 FROM BILLDETAILS D,PSR_PRODUCTGRNWISE V " _
        '    & "WHERE D.PLUID=V.PLUID AND V.BILLNO={0} " _
        '    & "GROUP BY D.SHOPID) M WHERE M.SHOPID=S.SHOPID " _
        '    & "GROUP BY S.SHOPNAME,S.SHOPID ORDER BY S.SHOPID DESC"

        'SERVER ABU QUERY

        'SQL = "SELECT S.SHOPNAME,SUM(M.A) PURCHASE,SUM(M.B) DELIVERY,SUM(M.C) SALES,SUM(M.B-M.C) STOCK FROM SHOPS S," _
        '    & "(SELECT M.SHOPID,SUM(D.Qty) A,0 B,0 C FROM GRNDETAILS D,GRNMASTER M,PSR_PRODUCTGRNWISE V,PAYMENTMASTER P " _
        '    & "WHERE M.GRNNO=D.GRNNO AND D.PLUID=V.PLUID AND M.BILLNO=P.BILLNO AND P.BILLNO={0} GROUP BY M.SHOPID " _
        '    & "UNION ALL " _
        '    & "SELECT M.DELIVERYTO,0,SUM(D.QUANTITY),0 FROM DELIVERYMASTER M,DELIVERYDETAILS D,PSR_PRODUCTGRNWISE V " _
        '    & "WHERE M.DELIVERYCODE=D.DELIVERYCODE AND D.PLUID=V.PLUID AND V.BILLNO={0} " _
        '    & "GROUP BY M.DELIVERYTO " _
        '    & "UNION ALL " _
        '    & "SELECT M.DELIVERYFROM,0,SUM(-D.QUANTITY),0 FROM RECEIVEDMASTER M,RECEIVEDDETAILS D,PSR_PRODUCTGRNWISE V " _
        '    & "WHERE M.DELIVERYCODE=D.DELIVERYCODE AND D.PLUID=V.PLUID AND V.BILLNO={0} " _
        '    & "GROUP BY M.DELIVERYFROM " _
        '    & "UNION ALL " _
        '    & "SELECT D.SHOPID,0,0,SUM(D.QTY) FROM BILLDETAILS D,PSR_PRODUCTGRNWISE V " _
        '    & "WHERE D.PLUID=V.PLUID AND V.BILLNO={0} " _
        '    & "GROUP BY D.SHOPID) M WHERE M.SHOPID=S.SHOPID " _
        '    & "GROUP BY S.SHOPNAME,S.SHOPID ORDER BY S.SHOPID DESC"

        'YASEEN QUERY FOR eStore

        SQL = $"SELECT S.SHOPNAME,SUM(M.Purchase) PURCHASE,SUM(M.Received) DELIVERY,SUM(M.Sales) SALES,
                CASE S.ShopID
                WHEN 1 THEN  
                SUM(M.Purchase-M.Delivery+M.Received)
                ELSE SUM(M.Received-M.Sales-M.Delivery) END AS STOCK 
                FROM SHOPS S,(SELECT M.SHOPID,SUM(D.Qty) Purchase,0 Delivery,0 Received,0 Sales
                FROM GRNDETAILS D,GRNMASTER M,PSR_PRODUCTGRNWISE V,PAYMENTMASTER P 
                WHERE M.GRNNO=D.GRNNO AND D.PLUID=V.PLUID AND M.BILLNO=P.BILLNO AND P.BILLNO={iBillNo} 
                GROUP BY M.SHOPID 
                UNION ALL 
                SELECT M.DELIVERYTO,0,0,SUM(D.QUANTITY),0
                FROM DELIVERYMASTER M,DELIVERYDETAILS D,PSR_PRODUCTGRNWISE V 
                WHERE M.ID=D.ID AND D.PLUID=V.PLUID AND V.BILLNO={iBillNo}
                GROUP BY M.DELIVERYTO 
                UNION ALL 
                SELECT M.DELIVERYFROM,0,SUM(D.QUANTITY),0,0 
                FROM DELIVERYMASTER M,DELIVERYDETAILS D,PSR_PRODUCTGRNWISE V 
                WHERE M.ID=D.ID AND D.PLUID=V.PLUID AND V.BILLNO={iBillNo}
                GROUP BY M.DELIVERYFROM 
                UNION ALL 
                SELECT D.SHOPID,0,0,0,SUM(D.QTY) 
                FROM BILLDETAILS D,PSR_PRODUCTGRNWISE V 
                WHERE D.PLUID=V.PLUID AND V.BILLNO={iBillNo} 
                GROUP BY D.SHOPID
                ) M WHERE M.SHOPID=S.SHOPID 
                GROUP BY S.SHOPNAME,S.SHOPID ORDER BY S.SHOPID DESC"

        'SQL = String.Format(SQL, iBillNo)

        Dim nTbl As New DataTable

        ESSA.OpenConnection()
        Using Adp2 As New SqlDataAdapter(SQL, Con)
            nTbl.Clear()
            Adp2.Fill(nTbl)
        End Using
        Con.Close()

        'SQL = "SELECT INVNO,INVDT,REFDT,SUBCATDESC1,ISNULL([0],0) [0],	ISNULL([1],0) [1],	ISNULL([2],0) [2],	ISNULL([3],0) [3],	ISNULL([4],0) [4],	ISNULL([5],0) [5],	ISNULL([6],0) [6],	ISNULL([7],0) [7],	ISNULL([8],0) [8],	ISNULL([9],0) [9],	ISNULL([10],0) [10],	ISNULL([11],0) [11],	ISNULL([S],0) [S],	ISNULL([M],0) [M],	ISNULL([L],0) [L],	ISNULL([XL],0) [XL],	ISNULL([XXL],0) [XXL],	ISNULL([XXXL],0) [XXXL],	ISNULL([XXXXL],0) [XXXXL],COSTPRICE FROM " _
        '    & "(SELECT M.GRNNO,L.SCATDESC1 SUBCATDESC1,D.QTY,D.COSTPRICE,V.NID,M.REFDT,M.INVNO,M.INVDT,S.ISNO FROM GRNDETAILS D,PRODUCTLEVELS L,GRNMASTER M,V_CODEWITHNID V,V_GRNLISTSNOWISE S " _
        '    & "WHERE M.GRNNO=S.GRNNO AND D.COSTPRICE=S.COSTPRICE AND L.PLUID=D.PLUID AND M.GRNNO=D.GRNNO AND D.PLUID=V.PLUID AND M.BILLNO=" & iBillNo & ") B PIVOT " _
        '    & "(sum(qty) for NID in ([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[S],[M],[L],[XL],[XXL],[XXXL],[XXXXL])) A ORDER BY GRNNO,COSTPRICE,ISNO"

        SQL = "SELECT INVNO,INVDT,REFDT,SUBCATDESC1,ISNULL([0],0) [0],	ISNULL([1],0) [1],	ISNULL([2],0) [2],	ISNULL([3],0) [3],	ISNULL([4],0) [4],	ISNULL([5],0) [5],	ISNULL([6],0) [6],	ISNULL([7],0) [7],	ISNULL([8],0) [8],	ISNULL([9],0) [9],	ISNULL([10],0) [10],	ISNULL([11],0) [11],	ISNULL([S],0) [S],	ISNULL([M],0) [M],	ISNULL([L],0) [L],	ISNULL([XL],0) [XL],	ISNULL([XXL],0) [XXL],	ISNULL([XXXL],0) [XXXL],	ISNULL([XXXXL],0) [XXXXL],COSTPRICE FROM " _
            & "(SELECT M.GRNNO,L.CATEGORY SUBCATDESC1,D.QTY,D.COSTPRICE,V.NID,M.REFDT,M.INVNO,M.INVDT,S.ISNO FROM GRNDETAILS D,PRODUCTATTRIBUTES L,GRNMASTER M,V_CODEWITHNID V,V_GRNLISTSNOWISE S " _
            & "WHERE M.GRNNO=S.GRNNO AND D.COSTPRICE=S.COSTPRICE AND L.PLUID=D.PLUID AND M.GRNNO=D.GRNNO AND D.PLUID=V.PLUID AND M.BILLNO=" & iBillNo & ") B PIVOT " _
            & "(sum(qty) for NID in ([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[S],[M],[L],[XL],[XXL],[XXXL],[XXXXL])) A ORDER BY GRNNO,COSTPRICE,ISNO"

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable

                Adp.Fill(Tbl)
                Rpt1.SetDataSource(Tbl)
                Rpt1.Subreports.Item(0).SetDataSource(STbl)
                Rpt1.Subreports.Item(1).SetDataSource(nTbl)
                Rpt1.SetParameterValue("PartyReturn", PartyReturn, "RptProductStatusReport2.rpt")
                Rpt1.SetParameterValue("Vendor", iVendor)
                Rpt1.SetParameterValue("BillNo", iBillNo)
                Rpt1.SetParameterValue("BillDt", iBillDt)
                Rpt1.SetParameterValue("Duration", iDuration)
                Rpt1.SetParameterValue("Advance", iAdvance)
                Rpt1.SetParameterValue("Debit", iDebit)
                Rpt1.SetParameterValue("AdvDesc", AdvDes)
                Rpt1.SetParameterValue("DbtDesc", DbtDes)
                Rpt1.SetParameterValue("RefNo", RefNo)
                Rpt1.SetParameterValue("ChequeNo", ChqNo)
                Rpt1.SetParameterValue("Date", ChqDate)
                Rpt1.SetParameterValue("Remarks", Remarks)
                ReportViewer.CViewer.ReportSource = Rpt1
                ReportViewer.Show()

            End Using
        End Using
        Con.Close()

    End Sub

    Private Sub RefreshBill()

        pnlTax.Visible = False
        lblAdvance.Text = "0.00"
        lblDebit.Text = "0.00"
        lblAmt.Text = "0.00"
        lblQty.Text = "0.00"
        TG.Rows.Clear()
        TGTax.Rows.Clear()
        CalculateTax()
        GenerateBillNo()
        cmbVendor.Focus()

    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click

        pnlTax.Visible = False

    End Sub

    Private Sub TGTax_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TGTax.KeyUp

        If e.KeyCode = Keys.F9 Then
            TGTax.Rows.RemoveAt(TGTax.CurrentRow.Index)
            CalculateTax()
        End If

    End Sub

    Private Sub btnAlter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlter.Click

        pnlAlter.Visible = True
        cmbVendor2.Focus()

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click


        SQL = "select p.billno,p.billdt,v.vendorname,p.netamt,p.frdt,p.todt,p.debitamt,p.vendorid,isnull(p.AdvAmount,0) from vendors v,paymentmaster p where v.vendorid=p.vendorid"

        If cmbVendor2.SelectedIndex > 0 Then
            SQL &= " and p.vendorid=" & cmbVendor2.SelectedValue
        End If

        SQL &= " order by billno desc"

        With ESSA.OpenReader(SQL)

            TGEdt.Rows.Clear()
            While .Read
                TGEdt.Rows.Add()
                TGEdt.Item(0, TGEdt.Rows.Count - 1).Value = .Item(0)
                TGEdt.Item(1, TGEdt.Rows.Count - 1).Value = Format(.GetDateTime(1).Date, "dd-MM-yyyy")
                TGEdt.Item(2, TGEdt.Rows.Count - 1).Value = .GetString(2).Trim
                TGEdt.Item(3, TGEdt.Rows.Count - 1).Value = Format(.Item(3), "0.00")
                TGEdt.Item(9, TGEdt.Rows.Count - 1).Value = Format(.GetDateTime(4).Date, "dd-MM-yyyy")
                TGEdt.Item(10, TGEdt.Rows.Count - 1).Value = Format(.GetDateTime(5).Date, "dd-MM-yyyy")
                TGEdt.Item(11, TGEdt.Rows.Count - 1).Value = Format(.Item(6), "0.00")
                TGEdt.Item(12, TGEdt.Rows.Count - 1).Value = .Item(7)
                TGEdt.Item(13, TGEdt.Rows.Count - 1).Value = Format(.Item(8), "0.00")
            End While

            .Close()

        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        pnlAlter.Visible = False

    End Sub

    Private Sub TGEdt_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TGEdt.CellClick

        If e.RowIndex = -1 Then Exit Sub

        If e.ColumnIndex = 4 Then
            ViewBillSummaryNew(Val(TGEdt.Item(0, e.RowIndex).Value), TGEdt.Item(2, e.RowIndex).Value, TGEdt.Item(9, e.RowIndex).Value & " to " & TGEdt.Item(10, e.RowIndex).Value, TGEdt.Item(1, e.RowIndex).Value, TGEdt.Item(11, e.RowIndex).Value, TGEdt.Item(13, e.RowIndex).Value)
        ElseIf e.ColumnIndex = 5 Then

            If IsAdmin = False Then
                MsgBox("Access denied..!", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("Are you sure, do you want to delete this bill..!", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            SQL = "delete from paymentmaster where billno=" & Val(TGEdt.Item(0, e.RowIndex).Value) & ";" _
                & "update grnmaster set billno=0 where billno=" & Val(TGEdt.Item(0, e.RowIndex).Value) & ";" _
                & "update rvchmaster set billno=0 where billno=" & Val(TGEdt.Item(0, e.RowIndex).Value) & ";" _
                & "update advpaymentmaster set billno=0 where billno=" & Val(TGEdt.Item(0, e.RowIndex).Value) & ";" _
                & "delete from paymenttax where billno=" & Val(TGEdt.Item(0, e.RowIndex).Value) & ";" _
                & "DELETE FROM PaymentNotes WHERE BillNo =" & Val(TGEdt.Item(0, e.RowIndex).Value)

            ESSA.Execute(SQL)
            MsgBox("Bill entry has been removed successfully..!", MsgBoxStyle.Exclamation)
            'xMessageBox.ShowMessage("Entry deleted successfully..!", "Taqua Store", vbOK)
            TGEdt.Rows.RemoveAt(e.RowIndex)

        ElseIf e.ColumnIndex = 6 Then

            Dim iGRNNo As String = ""

            SQL = "select grnno from grnmaster where billno=" & Val(TGEdt.Item(0, e.RowIndex).Value) & " order by grnno"
            With ESSA.OpenReader(SQL)
                While .Read
                    iGRNNo &= .Item(0) & ","
                End While
            End With

            If iGRNNo.Length > 0 Then
                iGRNNo = Mid(iGRNNo, 1, iGRNNo.Length - 1)
            End If

            SQL = "SELECT A.GRNNO,A.GRNDT,B.Category,A.PQTY,SUM(B.D1) DC1,SUM(B.S1) SLS1,SUM(B.K1) STK1,SUM(B.D2) DC2,SUM(B.S2) SLS2,SUM(B.K2) STK2 FROM " _
                & "(SELECT GRNNO,GRNDT,TotalQuantity PQTY FROM GrnMaster WHERE GRNNO in (" & iGRNNo & ")) A " _
                & "LEFT OUTER JOIN " _
                & "(SELECT V.GRNNO,V.GRNDT,V.Category,SUM(V.DC) D1,SUM(V.SALES) S1,SUM((V.DC-V.SALES)+V.RTN) K1,0 D2,0 S2,0 K2 " _
                & "FROM V_GRNWISESTATUS V WHERE V.DELIVERYTO=3 AND GRNNO in (" & iGRNNo & ") GROUP BY V.GRNNO,V.GRNDT,V.Category " _
                & "UNION ALL " _
                & "SELECT V.GRNNO,V.GRNDT,V.Category,0,0,0,SUM(V.DC),SUM(V.SALES),SUM((V.DC-V.SALES)+V.RTN) " _
                & "FROM V_GRNWISESTATUS V WHERE V.DELIVERYTO=5 AND GRNNO in (" & iGRNNo & ") GROUP BY V.GRNNO,V.GRNDT,V.Category) B ON A.GRNNO=B.GRNNO " _
                & "GROUP BY A.GRNNO,A.GRNDT,B.Category,A.PQTY"

            ESSA.OpenConnection()
            Using Adp As New SqlDataAdapter(SQL, Con)
                Using STbl2 As New DataTable
                    Adp.Fill(STbl2)
                    Rpt2.SetDataSource(STbl2)
                    ReportViewer.CViewer.ReportSource = Rpt2
                    ReportViewer.Show()
                End Using
            End Using
            Con.Close()

        ElseIf e.ColumnIndex = 7 Then

            'If UserID = 9 Then
            '    EnableRemarks = True
            'End If

            'Select Case UserID
            '    Case 10
            '        EnableRemarks = True
            '    Case 14
            '        EnableRemarks = True
            '    Case 1
            '        EnableRemarks = True
            '    Case Else
            '        EnableRemarks = False
            'End Select

            txtNotes.Clear()
            txtCheque.Clear()
            dtpCheque.ResetText()

            SQL = "SELECT BillNo,Notes,ChequeNo,ChequeDate FROM PaymentNotes WHERE BillNo = " & TGEdt.Item(0, e.RowIndex).Value

            With ESSA.OpenReader(SQL)
                If .Read Then
                    txtNotes.Text = .GetString(1).Trim
                    txtCheque.Text = .GetString(2).Trim
                    dtpCheque.Value = Format(.GetDateTime(3), "dd-MM-yyyy")
                    EditNotes = True
                End If
                .Close()
            End With

            lblVendor.Text = TGEdt.Item(2, e.RowIndex).Value
            lblBillNo.Text = TGEdt.Item(0, e.RowIndex).Value
            lblBillDate.Text = TGEdt.Item(1, e.RowIndex).Value
            pnlRemarks.Visible = True
            pnlRemarks.BringToFront()
            txtNotes.Select()


        End If

    End Sub

    Private Sub mebTo_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mebTo.ValueChanged

        SQL = "select vendorid,vendorname from vendors where vendorid in (select distinct vendorid from  " _
         & "grnmaster where billno=0 and invdt between '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' and '" _
         & Format(mebTo.Value, "yyyy-MM-dd") & "') order by vendorname"

        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid")

    End Sub

    Private Sub btnHide2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide2.Click

        pnlBill.Visible = False

    End Sub

    Private Sub btnPick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPick.Click

        LoadBillDetails()

    End Sub


    Private Function GetGRNNo() As String

        GetGRNNo = ""

        For i As SByte = 0 To TGBill.Rows.Count - 1

            If Val(TGBill.Item(0, i).Value) = 1 Then

                GetGRNNo &= TGBill.Item(4, i).Value & ","

            End If

        Next

        If GetGRNNo.Length > 0 Then
            GetGRNNo = Mid(GetGRNNo, 1, GetGRNNo.Length - 1)
        End If

    End Function

    Private Sub lblDebit_Click(sender As Object, e As EventArgs) Handles lblDebit.Click, lblAdvance.Click

        'Dim iRpt As New RptGrnWiseStatus

        'SQL = "SELECT A.GRNNO,A.GRNDT,B.SCATDESC1,A.PQTY,B.DC1,B.SLS1,B.STK1,B.DC2,B.SLS2,B.STK2 FROM " _
        '    & "(SELECT GRNNO,GRNDT,TOTALQUANTITY PQTY FROM GRNMASTER WHERE GRNNO=1767) A " _
        '    & "LEFT OUTER JOIN " _
        '    & "(SELECT V.GRNNO,V.GRNDT,V.SCATDESC1,SUM(V.DC) DC1,SUM(V.SALES) SLS1,SUM((V.DC-V.SALES)+V.RTN) STK1,0 DC2,0 SLS2,0 STK2 " _
        '    & "FROM V_GRNWISESTATUS V WHERE V.DELIVERYTO=2 AND GRNNO=1767 GROUP BY V.GRNNO,V.GRNDT,V.SCATDESC1 " _
        '    & "UNION ALL " _
        '    & "SELECT V.GRNNO,V.GRNDT,V.SCATDESC1,0,0,0,SUM(V.DC),SUM(V.SALES),SUM((V.DC-V.SALES)+V.RTN) " _
        '    & "FROM V_GRNWISESTATUS V WHERE V.DELIVERYTO=3 AND GRNNO=1767 GROUP BY V.GRNNO,V.GRNDT,V.SCATDESC1) B ON A.GRNNO=B.GRNNO"

        'ESSA.OpenConnection()
        'Using Adp As New SqlDataAdapter(SQL, Con)
        '    Using Tbl As New DataTable
        '        Adp.Fill(Tbl)
        '        iRpt.SetDataSource(Tbl)
        '        ReportViewer.CViewer.ReportSource = iRpt
        '        ReportViewer.Show()
        '    End Using
        'End Using
        'Con.Close()

    End Sub

    Private Sub btnHide3_Click(sender As Object, e As EventArgs) Handles btnHide3.Click

        pnlBankList.Visible = False
        updateMode = False
        iBillNo = 0

    End Sub

    Private MBID As Short = 0
    Private AcNo As String = ""
    Private AcNm As String = ""
    Private IFSC As String = ""
    Private ACTy As SByte = 0
    Private BKID As SByte = 0

    Private Sub SetBankInfo(iRowIndex As SByte, updateMode As Boolean, iBillNo As Integer)

        MBID = Val(TGBank.Item(0, iRowIndex).Value)
        AcNo = Trim(TGBank.Item(3, iRowIndex).Value)
        AcNm = Trim(TGBank.Item(4, iRowIndex).Value)
        IFSC = Trim(TGBank.Item(5, iRowIndex).Value)
        ACTy = Val(TGBank.Item(6, iRowIndex).Value)
        BKID = Val(TGBank.Item(7, iRowIndex).Value)

        If updateMode = False Then

            If TG.Rows.Count = 0 Then Exit Sub
            If MsgBox("Are you sure, do you want to save..!", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            SaveEntry()

        Else

            SQL = "update paymentmaster set bankid={1},acno='{2}'," _
                    & "acname='{3}',ifsc='{4}',actype={5} " _
                    & "where billno={6}"

            SQL = String.Format(SQL, Val(txtBillNo.Text), BKID, AcNo, AcNm, IFSC, ACTy, iBillNo)
            ESSA.Execute(SQL)
            MsgBox("Bank info updated successfully..!", MsgBoxStyle.Exclamation)

        End If

        pnlBankList.Visible = False
        updateMode = False
        iBillNo = 0

    End Sub

    Private Sub SetCashInfo()

        MBID = 0
        AcNo = ""
        AcNm = ""
        IFSC = ""
        ACTy = 0
        BKID = 52

        If updateMode = False Then

            If TG.Rows.Count = 0 Then Exit Sub
            If MsgBox("Are you sure, do you want to save..!", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            SaveEntry()

        Else

            SQL = "update paymentmaster set bankid={1},acno='{2}'," _
               & "acname='{3}',ifsc='{4}',actype={5} " _
               & "where billno={6}"

            SQL = String.Format(SQL, Val(txtBillNo.Text), BKID, AcNo, AcNm, IFSC, ACTy, iBillNo)
            ESSA.Execute(SQL)
            MsgBox("Bank info updated successfully..!", MsgBoxStyle.Exclamation)

        End If

        updateMode = False
        iBillNo = 0
        pnlBankList.Visible = False

    End Sub

    Private updateMode As Boolean = False
    Private iBillNo As Integer = 0

    Private Sub TGBank_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles TGBank.CellClick

        If e.RowIndex = -1 Then Exit Sub

        If e.ColumnIndex = 8 Then
            SetBankInfo(e.RowIndex, updateMode, iBillNo)
        End If

    End Sub

    Private Sub btnCashOnly_Click(sender As Object, e As EventArgs) Handles btnCashOnly.Click

        SetCashInfo()

    End Sub

    Private Sub btnHide4_Click(sender As Object, e As EventArgs) Handles btnHide4.Click

        pnlExcelExport.Hide()

    End Sub

    Private Sub btnExcelToExport_Click(sender As Object, e As EventArgs) Handles btnExcelToExport.Click

        pnlExcelExport.Visible = True

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        SQL = "SELECT V.VENDORNAME,B.BANKNAME,P.ACNO,P.ACNAME,P.IFSC,P.ACTYPE,P.NETAMT " _
            & "FROM VENDORS V,BANKLIST B,PAYMENTMASTER P " _
            & "WHERE V.VENDORID = P.VENDORID AND P.BANKID = B.BANKID " _
            & "AND P.BILLDT BETWEEN '{0}' AND '{1}' ORDER BY P.BILLNO"

        SQL = String.Format(SQL, Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))

        Dim excelApp = New ExcelPackage()
        Dim workSheet = excelApp.Workbook.Worksheets.Add("Sheet1")

        Dim RowIdx As Short = 2

        workSheet.Cells(1, 1).Value = "Vendor Name"
        workSheet.Cells(1, 2).Value = "Bank"
        workSheet.Cells(1, 3).Value = "Acc No"
        workSheet.Cells(1, 4).Value = "Acc Name"
        workSheet.Cells(1, 5).Value = "IFSC"
        workSheet.Cells(1, 6).Value = "Type"
        workSheet.Cells(1, 7).Value = "Amount"

        With ESSA.OpenReader(SQL)

            While .Read

                workSheet.Cells(RowIdx, 1).Value = .GetString(0).Trim
                workSheet.Cells(RowIdx, 2).Value = .GetString(1).Trim
                workSheet.Cells(RowIdx, 3).Value = .GetString(2).Trim
                workSheet.Cells(RowIdx, 4).Value = .GetString(3).Trim
                workSheet.Cells(RowIdx, 5).Value = .GetString(4).Trim
                workSheet.Cells(RowIdx, 6).Value = .Item(5)
                workSheet.Cells(RowIdx, 7).Value = .Item(6)
                RowIdx += 1

            End While

            .Close()

        End With

        Dim Range = workSheet.Cells(1, 1, RowIdx, 7)

        workSheet.Cells(1, 1, 1, 7).Style.Font.Bold = True

        workSheet.Column(7).Style.Numberformat.Format = "#0.00"

        Range.AutoFitColumns(0)

        SaveDiag.FileName = "BankList_" & Format(Now.Date, "yyyyMMdd") & ".xlsx"
        If SaveDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
            excelApp.SaveAs(New System.IO.FileInfo(SaveDiag.FileName))
            excelApp.Dispose()
            MsgBox("File Exporting Successfully..!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        MsgBox("File Exporting Cancelled..!", MsgBoxStyle.Critical)

    End Sub

    Private Sub TGEdt_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles TGEdt.CellDoubleClick

        If e.RowIndex = -1 Then Exit Sub
        updateMode = True
        iBillNo = Val(TGEdt.Item(0, e.RowIndex).Value)
        LoadBankList(Val(TGEdt.Item(12, e.RowIndex).Value))
        pnlBankList.Visible = True
        pnlBankList.BringToFront()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ESSA.OpenConnection()
        Dim cmd = Con.CreateCommand
        Dim trn = Con.BeginTransaction
        cmd.Transaction = trn

        Try
            If EditNotes = True Then
                SQL = "DELETE FROM PaymentNotes WHERE BillNo = " & TGEdt.Item(0, TGEdt.CurrentRow.Index).Value
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
            End If

            'Dim Notes As String = ""
            'For Each line In txtNotes.Lines
            '    Notes = line.TrimEnd & Environment.NewLine
            'Next

            SQL = "INSERT INTO PaymentNotes VALUES (" _
                & TGEdt.Item(0, TGEdt.CurrentRow.Index).Value & ",'" _
                & txtNotes.Text.Trim & "','" _
                & txtCheque.Text.Trim & "','" _
                & Format(dtpCheque.Value, "yyyy-MM-dd") & "','" _
                & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',0," _
                & UserID & ")"

            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
            trn.Commit()
            Con.Close()
            MsgBox("Updated Successfully", MsgBoxStyle.Information)
            pnlRemarks.Hide()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            trn.Rollback()
            Con.Close()
        End Try

    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click

        If pnlRemarks.Visible = True Then
            pnlRemarks.Hide()
        End If

    End Sub

    Private Sub btnRefBankList_Click(sender As Object, e As EventArgs) Handles btnRefBankList.Click

        LoadBankList(cmbVendor.SelectedValue)

    End Sub

    Private Sub mebFrom_ValueChanged(sender As Object, e As EventArgs) Handles mebFrom.ValueChanged

        SQL = "select vendorid,vendorname from vendors where vendorid in (select distinct vendorid from  " _
             & "grnmaster where billno=0 and invdt between '" & Format(mebFrom.Value, "yyyy-MM-dd") & "' and '" _
             & Format(mebTo.Value, "yyyy-MM-dd") & "') order by vendorname"

        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid")

    End Sub

    'Private Sub TGEdt_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles TGEdt.CellFormatting

    '    For i As Integer = 0 To TGEdt.Rows.Count - 1

    '        'If TGEdt.Item(1, i).Value > "31-12-2020" Then

    '        If ifExist(Val(TGEdt.Item(0, i).Value)) Then
    '            TGEdt.Item(0, i).Style.Font = New Font(TGEdt.DefaultCellStyle.Font, FontStyle.Bold)
    '        End If

    '        'End If

    '    Next

    'End Sub

    'Private Function ifExist(ibillno As Integer) As Boolean

    '    ifExist = False
    '    SQL = "SELECT " & ibillno & " FROM PaymentNotes"
    '    With ESSA.OpenReader(SQL)
    '        If .Read Then
    '            ifExist = True
    '        End If
    '        .Close()
    '    End With

    'End Function


End Class


