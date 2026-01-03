Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader

Public Class DiscountAssignerNew

    Private ReasonProvided As Boolean = False
    Private LSERVER As String = "LIVESERVER"
    Private LDatabase As String = "EWarehouse1213"

    Private Sub DiscountAssigner_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        'If e.KeyCode = Keys.F2 Then

        '    Dim Tmp As Integer = 0
        '    Dim TMd As SByte = 0
        '    Dim DVal = Val(InputBox("Enter discount percentage..!"))

        '    For i As Integer = 0 To TG.Rows.Count - 1
        '        TG.Item(5, i).Value = Format(DVal, "00.0")
        '        Tmp = Int(Val(TG.Item(4, i).Value) - ((Val(TG.Item(4, i).Value) * DVal) / 100))
        '        TMd = Tmp Mod 5
        '        If TMd > 0 Then
        '            Tmp = Tmp + (5 - TMd)
        '        End If

        '        If chkLWR.Checked = True Then
        '            Tmp = RoundOff(Tmp)
        '        End If

        '        TG.Item(6, i).Value = Format(Tmp, "0.00")
        '    Next

        'ElseIf e.KeyCode = Keys.F3 Then

        '    Dim DVal = Val(InputBox("Enter new rate..!"))
        '    For i As Integer = 0 To TG.Rows.Count - 1
        '        TG.Item(6, i).Value = Format(DVal, "00.00")
        '    Next

        'ElseIf e.KeyCode = Keys.F6 Then

        '    ApplyFlag(TG, 10, "YES")

        'ElseIf e.KeyCode = Keys.F7 Then

        '    ApplyFlag(TG, 10, "NO")

        'ElseIf e.KeyCode = Keys.F8 Then

        '    If MsgBox("Do you want to show discount percentage..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        '    Dim revDiscount As Double = 0

        '    For i As Integer = 0 To TG.Rows.Count - 1

        '        revDiscount = (Val(TG.Item(6, i).Value) / Val(TG.Item(4, i).Value)) * 100
        '        TG.Item(5, i).Value = Format(revDiscount, "0.0")

        '    Next

        'ElseIf e.KeyCode = Keys.F9 Then

        '    If TG.CurrentRow Is Nothing Then Exit Sub
        '    TG.Rows.RemoveAt(TG.CurrentRow.Index)

        'End If

    End Sub

    Private Sub ApplyFlag(dgv As DataGridView, columnindex As SByte, value As String)

        For i As Integer = 0 To dgv.Rows.Count - 1
            dgv.Item(columnindex, i).Value = value
        Next

    End Sub

    Private Sub DiscountAssigner_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MainWindowX.pnlQV.Visible = False

        TG.ColumnHeadersDefaultCellStyle.Font = New Font(TG.Font, FontStyle.Bold)

        ESSA.AlignHeader(TG, 4, DataGridViewContentAlignment.MiddleRight)
        ESSA.AlignHeader(TG, 5, DataGridViewContentAlignment.MiddleCenter)
        ESSA.AlignHeader(TG, 6, DataGridViewContentAlignment.MiddleRight)
        ESSA.AlignHeader(TG, 10, DataGridViewContentAlignment.MiddleCenter)

        Try
            SQL = "SELECT ShopID,ShopName FROM SHOPS ORDER BY ShopId"
            ESSA.LoadCombo(CmbShop, SQL, "ShopName", "ShopID")
            cmbLableFormat.Items.Clear()
            Dim DI As New IO.DirectoryInfo(My.Application.Info.DirectoryPath & "\Lables\")
            Dim Fl As IO.FileInfo() = DI.GetFiles()
            For Each nfl In Fl
                cmbLableFormat.Items.Add(nfl.Name.Trim)
            Next
            If cmbLableFormat.Items.Count > 0 Then
                cmbLableFormat.SelectedIndex = 0
            End If
        Catch ex As IO.DirectoryNotFoundException
            MsgBox("Sorry, Lable Format Directory not defined..!", MsgBoxStyle.Information)
        End Try


    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        OFD.ShowDialog()
        txtFileName.Text = OFD.FileName

        If txtFileName.Text.Trim.Length > 0 Then

            lblLoad.Visible = True
            lblLoad.Refresh()

            Try

                Dim connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFileName.Text + ";Extended Properties=""Excel 8.0;HDR=YES;"""
                TG.Rows.Clear()

                Dim sql As String = ""

                If chkRateUpdate.Checked Then
                    If chkLESWQ.Checked Then
                        sql = "SELECT code, SUM(qty) AS qty1, rate FROM [sheet1$] GROUP BY code, rate"
                    Else
                        sql = "SELECT code, COUNT(code) AS qty, rate FROM [sheet1$] GROUP BY code, rate"
                    End If
                Else
                    If chkLESWQ.Checked Then
                        sql = "SELECT code, SUM(qty) AS qty1 FROM [sheet1$] GROUP BY code"
                    Else
                        sql = "SELECT code, COUNT(code) AS qty FROM [sheet1$] GROUP BY code"
                    End If
                End If

                Using icon As New OleDbConnection(connectionString)
                    icon.Open()
                    Using Cmd As New OleDbCommand(sql, icon)
                        Using Rs = Cmd.ExecuteReader()
                            While Rs.Read
                                TG.Rows.Add()
                                TG.Item(1, TG.Rows.Count - 1).Value = TG.Rows.Count
                                TG.Item(2, TG.Rows.Count - 1).Value = Rs.GetString(0)
                                TG.Item(7, TG.Rows.Count - 1).Value = Rs.Item(1)
                                TG.Item(10, TG.Rows.Count - 1).Value = "NO"

                                ' Only when RateUpdate is checked
                                If chkRateUpdate.Checked Then
                                    TG.Item(6, TG.Rows.Count - 1).Value = Format(Rs.Item(2), "0.00")
                                End If
                            End While
                        End Using
                    End Using
                End Using

            Catch ex As Exception

                If ex.Message.Contains("valid name") Then
                    MsgBox("Worksheet name should be Sheet1", MsgBoxStyle.Critical)
                    pnlHint.Visible = True
                Else
                    MsgBox(ex.Message)
                    pnlHint.Visible = True
                End If
                lblLoad.Visible = False
                Exit Sub

            End Try

        End If

        UpdateRate()

        btnUpdate.Enabled = True
        lblLoad.Visible = False

    End Sub

    Private Function RoundOff(ByVal Amt As Double) As Double

        RoundOff = Amt
        Amt = Amt Mod 10

        If Amt > 0 Then
            RoundOff += IIf(Amt >= 5, 10 - Amt, -Amt)
        End If

    End Function

    Private Sub UpdateRate()

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Rs As SqlDataReader
        Dim Amt As Double = 0

        For i As Integer = 0 To TG.Rows.Count - 1

            SQL = "select m.pluid,pluname+'-'+id,pm.costprice,pm.retailprice,id,substring(a.department,1,len(a.department) - 4) + '-' + a.category,a.style,a.material,a.color,pm.discount from productmaster m,productattributes a,pricemaster pm where m.pluid = a.pluid and m.pluid = pm.pluid and pm.shopid = " & CmbShop.SelectedValue & " and m.plucode='" & TG.Item(2, i).Value & "'"
            Cmd.CommandText = SQL
            Rs = Cmd.ExecuteReader()
            With Rs
                If .Read Then

                    TG.Item(0, i).Value = .Item(0)
                    TG.Item(3, i).Value = .GetString(1)

                    If chkLoadCostPrice.Checked = True Then

                        Amt = .Item(2)

                        'If chkLWR.Checked = True Then
                        '    TG.Item(4, i).Value = Format(RoundOff(Amt), "0.00")
                        'Else
                        TG.Item(4, i).Value = Format(Amt, "0.00")
                        'End If

                    Else

                        Amt = .Item(3)

                        'If chkLWR.Checked = True Then
                        '    TG.Item(4, i).Value = Format(RoundOff(Amt), "0.00")
                        'Else
                        TG.Item(4, i).Value = Format(Amt, "0.00")
                        'End If

                    End If

                    TG.Item(9, i).Value = .GetString(4)
                    TG.Item(12, i).Value = .GetString(5).Trim
                    TG.Item(13, i).Value = .GetString(6)
                    TG.Item(14, i).Value = .GetString(7)
                    TG.Item(15, i).Value = .GetString(8)
                    TG.Item(5, i).Value = Val(.Item(9))

                End If
                .Close()
            End With

        Next

        Cmd.Dispose()
        Con.Close()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If ReasonProvided = False Then

            MsgBox("Please select valid reason..!", vbCritical)
            Exit Sub

        End If

        If MsgBox("Do you want to save..!", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction
        Cmd.Transaction = Trn

        Try

            Dim ENo = ESSA.GenerateID("select max(eno) from discountassigner")
            Dim Id = ESSA.GenerateID("SELECT Max(Id) FROM DiscountMaster")

            SQL = "INSERT INTO DiscountMaster VALUES( " _
                & Id & ",'" _
                & CmbReason.Text.Trim & "', GetDate()," _
                & CmbShop.SelectedValue & "," _
                & UserID & ")"

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            For i As Integer = 0 To TG.Rows.Count - 1

                If Val(TG.Item(0, i).Value) > 0 Then

                    If TG.Item(10, i).Value = "NO" Then

                        SQL = "UPDATE ProductMaster SET RetailPrice={0}, WholeSalePrice={2}, MRP={2}, ISUpdated=0 WHERE PluID={1}"
                        SQL = String.Format(SQL, Val(TG.Item(6, i).Value), Val(TG.Item(0, i).Value), Val(TG.Item(4, i).Value))

                        Cmd.CommandText = SQL
                        Cmd.ExecuteNonQuery()

                        SQL = "UPDATE PriceMaster SET RetailPrice={0}, WholeSalePrice={5}, MRP={5},UpdatedBy = {3},UpdatedAt = '{4}'  WHERE ShopID = {2} AND PluID={1}"
                        SQL = String.Format(SQL, Val(TG.Item(6, i).Value), Val(TG.Item(0, i).Value), CmbShop.SelectedValue, UserID, Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss"), Val(TG.Item(4, i).Value))

                        Cmd.CommandText = SQL
                        Cmd.ExecuteNonQuery()

                    Else

                        SQL = "UPDATE ProductMaster SET Discount = {0} WHERE PluID={1}"
                        SQL = String.Format(SQL, Val(TG.Item(5, i).Value), Val(TG.Item(0, i).Value))

                        Cmd.CommandText = SQL
                        Cmd.ExecuteNonQuery()

                        SQL = "UPDATE PriceMaster SET Discount = {0},UpdatedBy = {3},UpdatedAt = '{4}'  WHERE ShopID = {2} AND PluID={1}"
                        SQL = String.Format(SQL, Val(TG.Item(5, i).Value), Val(TG.Item(0, i).Value), CmbShop.SelectedValue, UserID, Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss"))

                        Cmd.CommandText = SQL
                        Cmd.ExecuteNonQuery()

                    End If


                    SQL = "insert into discountassigner values (" _
                        & ENo & ",'" _
                        & Format(Now, "yyyy-MM-dd HH:ss:mm") & "'," _
                        & Val(TG.Item(0, i).Value) & "," _
                        & Val(TG.Item(4, i).Value) & "," _
                        & Val(TG.Item(5, i).Value) & "," _
                        & Val(TG.Item(6, i).Value) & "," _
                        & i + 1 & ")"

                    Cmd.CommandText = SQL
                    Cmd.ExecuteNonQuery()

                    SQL = "select max(batchid) from productbatch where pluid=" & Val(TG.Item(0, i).Value)
                    Cmd.CommandText = SQL
                    Dim Tmp = Cmd.ExecuteScalar
                    If IsDBNull(Tmp) = False Then
                        Tmp = Int(Tmp) + 1
                    Else
                        Tmp = 1
                    End If

                    SQL = "insert into productbatch values (" _
                        & Tmp & "," _
                        & Val(TG.Item(0, i).Value) & "," _
                        & Val(TG.Item(6, i).Value) & "," _
                        & Val(TG.Item(4, i).Value) & ",0,'" _
                        & Format(Now.Date, "yyyy-MM-dd HH:mm:ss") & "'," _
                        & CmbShop.SelectedValue & "," _ 'ShopId
                        & UserID & ")"

                    Cmd.CommandText = SQL
                    Cmd.ExecuteNonQuery()

                    SQL = "INSERT INTO DiscountDetails VALUES( " _
                        & Id & "," _
                        & TG.Item(0, i).Value & "," _
                        & TG.Item(4, i).Value & "," _
                        & TG.Item(6, i).Value & ")"

                    Cmd.CommandText = SQL
                    Cmd.ExecuteNonQuery()

                End If

            Next

            Trn.Commit()
            Con.Close()
            MsgBox("Updated successfully..!", MsgBoxStyle.Information)
            btnUpdate.Enabled = False
            ReasonProvided = False

        Catch ex As SqlException

            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub
    Private Sub TG_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles TG.CellEndEdit

        If e.ColumnIndex = 2 Then

            SQL = "select m.pluid,m.pluname + '-' + m.id,pm.retailprice,m.id,substring(a.department,1,len(a.department) - 4) + '-' + a.category,a.style,a.material,a.color,pm.discount from productmaster m,productattributes a,pricemaster pm where pm.pluid = m.pluid and pm.shopid = " & CmbShop.SelectedValue & " and a.pluid = m.pluid and m.plucode='" & TG.Item(2, e.RowIndex).Value & "'"
            With ESSA.OpenReader(SQL)
                If .Read Then
                    TG.Item(0, e.RowIndex).Value = .Item(0)
                    TG.Item(3, e.RowIndex).Value = .GetString(1)
                    TG.Item(4, e.RowIndex).Value = Format(.Item(2), "0.00")
                    TG.Item(7, e.RowIndex).Value = 1
                    TG.Item(9, e.RowIndex).Value = .GetString(3)
                    TG.Item(12, e.RowIndex).Value = .GetString(4)
                    TG.Item(13, e.RowIndex).Value = .GetString(5)
                    TG.Item(14, e.RowIndex).Value = .GetString(6)
                    TG.Item(15, e.RowIndex).Value = .GetString(7)
                    TG.Item(5, e.RowIndex).Value = Val(.Item(8))
                    TG.CurrentCell = TG.Item(5, e.RowIndex)
                End If
                .Close()
            End With

            Exit Sub

        End If

        'TG.Item(5, i).Value = Format(DVal, "00.0")

        'Tmp = Int(Val(TG.Item(4, i).Value) - ((Val(TG.Item(4, i).Value) * DVal) / 100))
        'TMd = Tmp Mod 5

        'If TMd > 0 Then
        '    Tmp = Tmp + (5 - TMd)
        'End If

        'TG.Item(6, i).Value = Format(Tmp, "0.00")
        '    Next

        If chkRate.Checked = False Then

            Dim Tmp = Int(Val(TG.Item(4, e.RowIndex).Value) - (Val(TG.Item(4, e.RowIndex).Value) * Val(TG.Item(5, e.RowIndex).Value) / 100))
            Dim TMd = Tmp Mod 5

            If TMd > 0 Then
                Tmp = Tmp + (5 - TMd)
            End If

            If chkLWR.Checked = True Then
                Tmp = RoundOff(Tmp)
            End If

            TG.Item(6, e.RowIndex).Value = Format(Tmp, "0.00")

        Else

            Dim Tmp = Val(TG.Item(4, e.RowIndex).Value) - Val(TG.Item(5, e.RowIndex).Value)
            TG.Item(6, e.RowIndex).Value = Format(Tmp, "0.00")

        End If

        'ESSA.MoveNextCell(TG, 2, 7, True)

        'TG.Item(6, e.RowIndex).Value = Format((Val(TG.Item(4, e.RowIndex).Value) * Val(TG.Item(5, e.RowIndex).Value)) / 100, "0.00")

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        pnlHint.Visible = False

    End Sub


    Private PLUCODE_1 As String = ""
    Private PLUCODE_2 As String = ""
    Private PLUNAME_1 As String = ""
    Private PLUNAME_2 As String = ""
    Private RTPRICE_1 As String = ""
    Private RTPRICE_2 As String = ""
    Private DESCRPN_1 As String = ""
    Private DESCRPN_2 As String = ""
    Private MFDDATE_1 As String = ""
    Private MFDDATE_2 As String = ""
    Private OPPRICE_1 As String = ""
    Private OPPRICE_2 As String = ""
    Private DISCONT_1 As String = ""
    Private DISCONT_2 As String = ""

    Private Sub PrintBarcode()

        Dim xStr As String()
        Dim xTmp As String = ""

        xStr = System.IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\Lables\" & cmbLableFormat.Text.Trim)

        For i As Short = 0 To TGTMP.Rows.Count - 1 Step 2

            PLUCODE_1 = TGTMP.Item(0, i).Value
            If i < TGTMP.Rows.Count - 1 Then
                PLUCODE_2 = TGTMP.Item(0, i + 1).Value
            Else
                PLUCODE_2 = ""
            End If

            PLUNAME_1 = TGTMP.Item(1, i).Value
            If i < TGTMP.Rows.Count - 1 Then
                PLUNAME_2 = TGTMP.Item(1, i + 1).Value
            Else
                PLUNAME_2 = ""
            End If

            RTPRICE_1 = Format(Val(TGTMP.Item(4, i).Value), "0")
            If i < TGTMP.Rows.Count - 1 Then
                RTPRICE_2 = Format(Val(TGTMP.Item(4, i + 1).Value), "0")
            Else
                RTPRICE_2 = ""
            End If

            DISCONT_1 = Format(Val(TGTMP.Item(3, i).Value), "0")
            If i < TGTMP.Rows.Count - 1 Then
                DISCONT_2 = Format(Val(TGTMP.Item(3, i + 1).Value), "0")
            Else
                DISCONT_2 = ""
            End If

            OPPRICE_1 = Format(Val(TGTMP.Item(2, i).Value), "0")
            If i < TGTMP.Rows.Count - 1 Then
                OPPRICE_2 = Format(Val(TGTMP.Item(2, i + 1).Value), "0")
            Else
                OPPRICE_2 = ""
            End If

            DESCRPN_1 = TGTMP.Item(5, i).Value
            If i < TGTMP.Rows.Count - 1 Then
                DESCRPN_2 = TGTMP.Item(5, i + 1).Value
            Else
                DESCRPN_2 = ""
            End If

            MFDDATE_1 = txtDate.Text
            If i < TGTMP.Rows.Count - 1 Then
                MFDDATE_2 = txtDate.Text
            Else
                MFDDATE_2 = ""
            End If

            For Each Ln As String In xStr

                If Ln.Contains("&PLUCODE_1") = True Then
                    xTmp &= Ln.Replace("&PLUCODE_1", PLUCODE_1) + Environment.NewLine
                ElseIf Ln.Contains("&PLUCODE_2") = True Then
                    xTmp &= Ln.Replace("&PLUCODE_2", PLUCODE_2) + Environment.NewLine
                ElseIf Ln.Contains("&PLUNAME_1") = True Then
                    xTmp &= Ln.Replace("&PLUNAME_1", PLUNAME_1) + Environment.NewLine
                ElseIf Ln.Contains("&PLUNAME_2") = True Then
                    xTmp &= Ln.Replace("&PLUNAME_2", PLUNAME_2) + Environment.NewLine
                ElseIf Ln.Contains("&RTPRICE_1") = True Then
                    xTmp &= Ln.Replace("&RTPRICE_1", RTPRICE_1) + Environment.NewLine
                ElseIf Ln.Contains("&RTPRICE_2") = True Then
                    xTmp &= Ln.Replace("&RTPRICE_2", RTPRICE_2) + Environment.NewLine
                ElseIf Ln.Contains("&DESCRPN_1") = True Then
                    xTmp &= Ln.Replace("&DESCRPN_1", DESCRPN_1) + Environment.NewLine
                ElseIf Ln.Contains("&DESCRPN_2") = True Then
                    xTmp &= Ln.Replace("&DESCRPN_2", DESCRPN_2) + Environment.NewLine
                ElseIf Ln.Contains("&MFD_1") = True Then
                    xTmp &= Ln.Replace("&MFD_1", MFDDATE_1) + Environment.NewLine
                ElseIf Ln.Contains("&MFD_2") = True Then
                    xTmp &= Ln.Replace("&MFD_2", MFDDATE_2) + Environment.NewLine
                ElseIf Ln.Contains("&OPPRICE_1") = True Then
                    xTmp &= Ln.Replace("&OPPRICE_1", OPPRICE_1) + Environment.NewLine
                ElseIf Ln.Contains("&OPPRICE_2") = True Then
                    xTmp &= Ln.Replace("&OPPRICE_2", OPPRICE_2) + Environment.NewLine
                ElseIf Ln.Contains("&DISCONT_1") = True Then
                    xTmp &= Ln.Replace("&DISCONT_1", DISCONT_1) + Environment.NewLine
                ElseIf Ln.Contains("&DISCONT_2") = True Then
                    xTmp &= Ln.Replace("&DISCONT_2", DISCONT_2) + Environment.NewLine
                Else
                    xTmp &= Ln + Environment.NewLine
                End If

            Next

            xTmp &= "" + Environment.NewLine

        Next

        FileOpen(1, BarcodeFileLocation, OpenMode.Output, OpenAccess.Write)
        Print(1, xTmp)
        FileClose(1)
        Process.Start(BarcodeBatchLocation)

        MsgBox("Lable send to printer successfully..!", vbExclamation)


    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        If TG.Rows.Count = 0 Then
            MsgBox("No details to send..!", vbCritical)
            Exit Sub
        ElseIf txtDate.Text.Trim.Length = 0 Then
            If MsgBox("Date not specified, Do you want to send..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If

        TGTMP.Rows.Clear()

        For i As Integer = 0 To TG.Rows.Count - 1

            For j As Short = 1 To Val(TG.Item(7, i).Value)

                TGTMP.Rows.Add()
                TGTMP.Item(0, TGTMP.Rows.Count - 1).Value = TG.Item(2, i).Value
                TGTMP.Item(1, TGTMP.Rows.Count - 1).Value = TG.Item(3, i).Value
                TGTMP.Item(2, TGTMP.Rows.Count - 1).Value = TG.Item(4, i).Value
                TGTMP.Item(3, TGTMP.Rows.Count - 1).Value = TG.Item(5, i).Value
                TGTMP.Item(4, TGTMP.Rows.Count - 1).Value = TG.Item(6, i).Value
                TGTMP.Item(5, TGTMP.Rows.Count - 1).Value = TG.Item(0, i).Value
                TGTMP.Item(6, TGTMP.Rows.Count - 1).Value = TG.Item(9, i).Value
                TGTMP.Item(7, TGTMP.Rows.Count - 1).Value = TG.Item(12, i).Value
                TGTMP.Item(8, TGTMP.Rows.Count - 1).Value = TG.Item(13, i).Value
                TGTMP.Item(9, TGTMP.Rows.Count - 1).Value = TG.Item(14, i).Value
                TGTMP.Item(10, TGTMP.Rows.Count - 1).Value = TG.Item(15, i).Value

            Next

        Next

        SendLabel()
        'PrintBarcode()

    End Sub

    Private Sub TG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles TG.CellContentClick

    End Sub

    Private Sub TG_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TG.PreviewKeyDown

        If e.KeyCode = Keys.Enter Then
            ESSA.MoveNextCell(TG, 2, 7, True)
        ElseIf e.KeyCode = Keys.Y Then
            If TG.CurrentCell.ColumnIndex = 10 Then
                TG.Item(10, TG.CurrentRow.Index).Value = "YES"
            End If
        ElseIf e.KeyCode = Keys.N Then
            If TG.CurrentCell.ColumnIndex = 10 Then
                TG.Item(10, TG.CurrentRow.Index).Value = "NO"
            End If
        End If

    End Sub

    Private Sub TG_Enter(sender As Object, e As EventArgs) Handles TG.Enter

        If TG.Rows.Count = 0 Then
            TG.Rows.Add()
            TG.CurrentCell = TG.Item(2, 0)
        End If

    End Sub

    Private Sub TG_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles TG.RowsAdded

        TG.Item(1, TG.Rows.Count - 1).Value = TG.Rows.Count
        TG.Item(10, TG.Rows.Count - 1).Value = "NO"

    End Sub

    Private Sub btnCle_Click(sender As Object, e As EventArgs) Handles btnCle.Click

        TG.Rows.Clear()
        TGTMP.Rows.Clear()
        btnUpdate.Enabled = True

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

        If MsgBox("Do you want to update ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Dim tAmount As Double = 0

        For i As Short = 0 To TG.Rows.Count - 1

            If cmbMode.SelectedIndex = 0 Then

                If cmbType.SelectedIndex = 0 Then
                    TG.Item(4, i).Value = Format(Val(TG.Item(4, i).Value) + Val(txtAmt.Text), "0.00")
                Else
                    tAmount = Val(TG.Item(4, i).Value) + (Val(TG.Item(4, i).Value) * Val(txtAmt.Text)) / 100
                    TG.Item(4, i).Value = Format(tAmount, "0.00")
                End If

                If chkLWR.Checked = True Then
                    TG.Item(4, i).Value = Format(RoundOff(Val(TG.Item(4, i).Value)), "0.00")
                End If

            Else

                If cmbType.SelectedIndex = 0 Then
                    TG.Item(4, i).Value = Format(Val(TG.Item(4, i).Value) - Val(txtAmt.Text), "0.00")
                Else
                    tAmount = Val(TG.Item(4, i).Value) - (Val(TG.Item(4, i).Value) * Val(txtAmt.Text)) / 100
                    TG.Item(4, i).Value = Format(tAmount, "0.00")
                End If

                If chkLWR.Checked = True Then
                    TG.Item(4, i).Value = Format(RoundOff(Val(TG.Item(4, i).Value)), "0.00")
                End If

            End If

        Next

    End Sub

    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click

        pnlRM.Visible = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnHide2.Click

        PnlDisReason.Visible = False

    End Sub

    Private Sub BtnApply2_Click(sender As Object, e As EventArgs) Handles BtnApply2.Click

        If CmbReason.Text.Trim = "" Then

            MsgBox("please fill in reason for rate change..!", MsgBoxStyle.Critical)
            Exit Sub

        End If

        ReasonProvided = True
        BtnHide2.PerformClick()

    End Sub

    Private Sub BtnReason_Click(sender As Object, e As EventArgs) Handles BtnReason.Click

        ESSA.MovetoCenter(PnlDisReason, Me)
        PnlDisReason.Visible = True
        ESSA.LoadCombo(CmbReason, "SELECT DISTINCT Reason FROM DiscountMaster ORDER BY Reason", "Reason")
        CmbReason.Focus()
        'CmbReason.SelectedIndex = 0

    End Sub

    Private Sub SendLabel()

        Dim PrintId As Integer = Val(InputBox("Enter Id", "Lable Printing"))

        If PrintId <> 0 Then

            ESSA.OpenConnection()
            Dim Cmd = Con.CreateCommand
            Dim trn = Con.BeginTransaction
            Cmd.Transaction = trn
            Try

                SQL = "DELETE FROM LablePrint WHERE Id =" & PrintId

                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()

                For i As Integer = 0 To TGTMP.Rows.Count - 1

                    SQL = "INSERT INTO LablePrint (Id,Plucode,Pluname,Size,ORate,Retail_Price,Ref,Product,Style,Material,Color) VALUES( " _
                    & PrintId & ",'" _
                    & TGTMP.Item(0, i).Value & "','" _
                    & TGTMP.Item(1, i).Value & "','" _
                    & TGTMP.Item(6, i).Value & "'," _
                    & Format(Val(TGTMP.Item(2, i).Value), "0.00") & "," _
                    & Format(Val(TGTMP.Item(4, i).Value), "0.00") & ",'" _
                    & txtDate.Text.Trim & "','" _
                    & TGTMP.Item(7, i).Value & "','" _
                    & TGTMP.Item(8, i).Value & "','" _
                    & TGTMP.Item(9, i).Value & "','" _
                    & TGTMP.Item(10, i).Value & "')"

                    Cmd.CommandText = SQL
                    Cmd.ExecuteNonQuery()

                Next

                trn.Commit()
                Con.Close()
                If MsgBox("Lable send to printer successfully, Do you want clear entries..!", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    TG.Rows.Clear()
                    txtDate.Clear()
                Else
                    txtFileName.Focus()
                End If

            Catch ex As Exception

                trn.Rollback()
                Con.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try

        Else

            MsgBox("Please enter id..!", MsgBoxStyle.Critical)
            Exit Sub

        End If

    End Sub

    Private Sub btnDisAssignerClose_Click(sender As Object, e As EventArgs) Handles btnDisAssignerClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub DiscountAssignerNew_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlHint, Me)
        ESSA.MovetoCenter(pnlRM, Me)
        ESSA.MovetoCenter(PnlDisReason, Me)
        ESSA.MovetoCenter(lblLoad, Me)

    End Sub

    Private Sub btnRateModifier_Click(sender As Object, e As EventArgs) Handles btnRateModifier.Click

        If TG.Rows.Count = 0 Then Exit Sub
        pnlRM.Visible = True
        cmbMode.SelectedIndex = 0
        cmbType.SelectedIndex = 0
        cmbMode.Focus()

    End Sub

    Private Sub btnF2Discount_Click(sender As Object, e As EventArgs) Handles btnF2Discount.Click

        Dim Tmp As Integer = 0
        Dim TMd As SByte = 0
        Dim DVal = Val(InputBox("Enter discount percentage..!"))

        For i As Integer = 0 To TG.Rows.Count - 1
            TG.Item(5, i).Value = Format(DVal, "00.0")
            Tmp = Int(Val(TG.Item(4, i).Value) - ((Val(TG.Item(4, i).Value) * DVal) / 100))
            TMd = Tmp Mod 5
            If TMd > 0 Then
                Tmp = Tmp + (5 - TMd)
            End If

            If chkLWR.Checked = True Then
                Tmp = RoundOff(Tmp)
            End If

            TG.Item(6, i).Value = Format(Tmp, "0.00")
        Next

    End Sub

    Private Sub btnF3Rate_Click(sender As Object, e As EventArgs) Handles btnF3Rate.Click

        Dim DVal = Val(InputBox("Enter new rate..!"))
        For i As Integer = 0 To TG.Rows.Count - 1
            TG.Item(6, i).Value = Format(DVal, "00.00")
        Next

    End Sub

    Private Sub btnF6Yes_Click(sender As Object, e As EventArgs) Handles btnF6Yes.Click

        ApplyFlag(TG, 10, "YES")

    End Sub

    Private Sub btnF7No_Click(sender As Object, e As EventArgs) Handles btnF7No.Click

        ApplyFlag(TG, 10, "NO")

    End Sub

    Private Sub btnF8SDV_Click(sender As Object, e As EventArgs) Handles btnF8SDV.Click

        If MsgBox("Do you want to show discount percentage..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Dim revDiscount As Double = 0

        For i As Integer = 0 To TG.Rows.Count - 1

            revDiscount = (Val(TG.Item(6, i).Value) / Val(TG.Item(4, i).Value)) * 100
            TG.Item(5, i).Value = Format(revDiscount, "0.0")

        Next

    End Sub

    Private Sub btnF9DeleteRow_Click(sender As Object, e As EventArgs) Handles btnF9DeleteRow.Click

        If TG.CurrentRow Is Nothing Then Exit Sub
        TG.Rows.RemoveAt(TG.CurrentRow.Index)

    End Sub
End Class