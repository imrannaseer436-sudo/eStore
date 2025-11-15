Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Class frmSalesCommission

    Private modalPanel As Panel
    Private txtModalBarcode As TextBox
    Private txtModalValue As TextBox
    Private btnModalOK As Button
    Private btnModalCancel As Button

    Private CommissionId As Integer = 0

    Private Sub ModalOK(sender As Object, e As EventArgs)

        If txtModalBarcode.Text.Trim() = "" Then
            MessageBox.Show("Barcode is required.")
            Return
        End If

        If Not IsNumeric(txtModalValue.Text) Then
            MessageBox.Show("Enter a numeric value.")
            Return
        End If

        If ESSA.FindAndSelectReturnStatus(dgvDetails, 0, txtModalBarcode.Text.Trim) Then
            MessageBox.Show("Barcode already exists")
            Return
        End If

        dgvDetails.Rows.Add(
        txtModalBarcode.Text.Trim(),
        cmbType.Text,
        Decimal.Parse(txtModalValue.Text)
    )

        modalPanel.Visible = False

    End Sub

    Private Sub ModalCancel(sender As Object, e As EventArgs)
        modalPanel.Visible = False
    End Sub

    Private Sub CreateInlineModal()


        ' === Modal ===
        modalPanel = New Panel()
        modalPanel.Size = New Size(320, 150)
        modalPanel.BackColor = Color.White
        modalPanel.BorderStyle = BorderStyle.FixedSingle

        Me.Controls.Add(modalPanel)

        ' === Fields ===
        Dim lbl1 As New Label() With {.Text = "Barcode:", .Left = 20, .Top = 20, .Width = 100}
        txtModalBarcode = New TextBox() With {.Left = 120, .Top = 18, .Width = 170}

        Dim lbl2 As New Label() With {.Text = "Value:", .Left = 20, .Top = 60, .Width = 100}
        txtModalValue = New TextBox() With {.Left = 120, .Top = 58, .Width = 170}

        btnModalOK = New Button() With {.Text = "OK", .Left = 120, .Top = 100, .Width = 70, .BackColor = Color.FromArgb(37, 121, 50), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat}
        btnModalCancel = New Button() With {.Text = "Cancel", .Left = 210, .Top = 100, .Width = 70, .BackColor = Color.FromArgb(192, 64, 0), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat}

        AddHandler btnModalOK.Click, AddressOf ModalOK
        AddHandler btnModalCancel.Click, AddressOf ModalCancel

        modalPanel.Controls.AddRange({lbl1, txtModalBarcode, lbl2, txtModalValue, btnModalOK, btnModalCancel})

        CenterModal()

        ' Re-center on resize
        AddHandler Me.Resize, Sub() CenterModal()

    End Sub

    Private Sub CenterModal()
        If modalPanel Is Nothing Then Exit Sub

        modalPanel.Left = (Me.Width - modalPanel.Width) \ 2
        modalPanel.Top = (Me.Height - modalPanel.Height) \ 2

        pnlList.Left = (Me.Width - pnlList.Width) \ 2
        pnlList.Top = (Me.Height - pnlList.Height) \ 2

        pnlLoading.Left = (Me.Width - pnlLoading.Width) \ 2
        pnlLoading.Top = (Me.Height - pnlLoading.Height) \ 2

    End Sub

    Private Sub btnManual_Click(sender As Object, e As EventArgs) Handles btnManual.Click
        If cmbType.FindStringExact(cmbType.Text) = -1 Then
            MessageBox.Show("Please select commission type.")
            Return
        End If

        txtModalBarcode.Text = ""
        txtModalValue.Text = ""

        modalPanel.Visible = True
        modalPanel.BringToFront()

        modalPanel.PerformLayout()
        Me.PerformLayout()
        CenterModal()
    End Sub


    Private Async Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Excel Files|*.xls;*.xlsx"
            If ofd.ShowDialog() <> DialogResult.OK Then Return

            pnlLoading.Visible = True
            pBar.Style = ProgressBarStyle.Marquee
            pBar.MarqueeAnimationSpeed = 30

            Dim excelPath = ofd.FileName

            ' STEP 1: Read Excel in background
            Dim excelRows As List(Of (Barcode As String, Value As Decimal)) =
            Await Task.Run(Function() ReadExcelDeduped(excelPath))

            ' STEP 2: Filter duplicates against existing dgvDetails
            Dim existing As New HashSet(Of String)(
            dgvDetails.Rows.
            Cast(Of DataGridViewRow)().
            Where(Function(r) Not r.IsNewRow).
            Select(Function(r) r.Cells("Barcode").Value.ToString().Trim())
        )

            Dim finalRows As New List(Of (Barcode As String, Value As Decimal))()

            For Each r In excelRows
                If Not existing.Contains(r.Barcode) Then
                    finalRows.Add(r)
                    existing.Add(r.Barcode)  ' Add so further duplicates are blocked
                End If
            Next

            ' STEP 3: Populate grid with progress
            If finalRows.Count > 0 Then
                pBar.Style = ProgressBarStyle.Continuous
                pBar.Minimum = 0
                pBar.Maximum = finalRows.Count
                pBar.Value = 0

                Await Task.Run(Sub()
                                   For i As Integer = 0 To finalRows.Count - 1
                                       Dim r = finalRows(i)
                                       dgvDetails.Invoke(Sub()
                                                             dgvDetails.Rows.Add(r.Barcode,
                                                                             cmbType.Text,
                                                                             r.Value.ToString(),
                                                                             "EXCEL")
                                                             pBar.Value = i + 1
                                                         End Sub)
                                   Next
                               End Sub)
            End If

            pnlLoading.Visible = False

            MessageBox.Show(
            $"Excel Upload Completed!" & vbCrLf &
            $"Total Rows in Excel: {excelRows.Count}" & vbCrLf &
            $"Added to Grid: {finalRows.Count}" & vbCrLf &
            $"Skipped (Duplicates): {excelRows.Count - finalRows.Count}",
            "Upload Summary",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
        End Using
    End Sub

    Private Function ReadExcelDeduped(path As String) As List(Of (Barcode As String, Value As Decimal))
        Dim connStr As String

        If System.IO.Path.GetExtension(path).ToLower() = ".xls" Then
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & ";Extended Properties='Excel 8.0;HDR=YES;'"
        Else
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
        End If

        Dim dt As New DataTable()

        Using conn As New OleDbConnection(connStr)
            conn.Open()
            Dim sheet = conn.GetSchema("Tables").Rows(0)("TABLE_NAME").ToString()
            Dim cmd As New OleDbCommand("SELECT * FROM [" & sheet & "]", conn)
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
        End Using

        Dim uniqueSet As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim result As New List(Of (Barcode As String, Value As Decimal))

        For Each row As DataRow In dt.Rows
            Dim barcode = row("barcode").ToString().Trim()
            If barcode = "" Then Continue For

            If Not uniqueSet.Contains(barcode) Then
                uniqueSet.Add(barcode)

                Dim v As Decimal = 0
                If dt.Columns.Contains("value") Then Decimal.TryParse(row("value").ToString(), v)

                result.Add((barcode, v))
            End If
        Next

        Return result
    End Function


    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If dgvDetails.Rows.Count = 0 Then
            MessageBox.Show("No commission details to save.")
            Return
        End If

        pnlLoading.Visible = True
        pBar.Style = ProgressBarStyle.Continuous
        pBar.Value = 0

        ' STEP 0: Build list from grid (UI thread)
        Dim detailRows As New List(Of (Barcode As String, ComType As String, CValue As Decimal))()

        For Each row As DataGridViewRow In dgvDetails.Rows
            If row.IsNewRow Then Continue For

            Dim barcode = row.Cells("Barcode").Value.ToString()
            Dim comtype = row.Cells("CommissionType").Value.ToString()

            Dim cval As Decimal = 0
            Decimal.TryParse(row.Cells("CommissionValue").Value.ToString(), cval)

            detailRows.Add((barcode, comtype, cval))
        Next

        Dim totalRows = detailRows.Count
        pBar.Maximum = totalRows


        ' STEP 1: Run database work in background
        Dim result As String = Await Task.Run(Function() SaveCommissionWithBulk(detailRows))

        pnlLoading.Visible = False
        pBar.Value = 0

        If result = "OK" Then
            MessageBox.Show("Commission saved successfully!")
            btnReset.PerformClick()
        Else
            MessageBox.Show("Error while saving commission:" & vbCrLf & result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Function SaveCommissionWithBulk(detailRows As List(Of (Barcode As String, ComType As String, CValue As Decimal))) As String
        Try
            Using conn As New SqlConnection(ConStr)
                conn.Open()

                Using tx = conn.BeginTransaction()

                    Dim newID As Integer = 0

                    If CommissionId = 0 Then

                        ' ===== Insert Master =====
                        Using cmdMaster As New SqlCommand("
                    INSERT INTO CommissionMaster 
                    (CommissionName, StartDate, EndDate, ShopId, Status, CreatedBy, CreatedDate)
                    OUTPUT INSERTED.CommissionID
                    VALUES (@Name, @Start, @End, @ShopId, @Status, @By, GETDATE())",
                    conn, tx)

                            ' Safe UI access
                            cmdMaster.Parameters.AddWithValue("@Name", txtName.Invoke(Function() txtName.Text))
                            cmdMaster.Parameters.AddWithValue("@Start", dtStart.Invoke(Function() dtStart.Value.Date))
                            cmdMaster.Parameters.AddWithValue("@End", dtEnd.Invoke(Function() dtEnd.Value.Date))
                            cmdMaster.Parameters.AddWithValue("@ShopId", cmbShop.Invoke(Function() cmbShop.SelectedValue))
                            cmdMaster.Parameters.AddWithValue("@Status", chkActive.Invoke(Function() chkActive.Checked))
                            cmdMaster.Parameters.AddWithValue("@By", UserID)

                            newID = Convert.ToInt32(cmdMaster.ExecuteScalar())
                        End Using

                    Else

                        ' ===== Update Master =====
                        Using cmdMaster As New SqlCommand("
                        UPDATE CommissionMaster SET
                        CommissionName=@Name, StartDate=@Start, EndDate=@End, ShopId=@ShopId, Status=@Status, UpdatedBy=@By, UpdatedDate=GETDATE()
                        WHERE CommissionId=@Id",
                        conn, tx)

                            ' Safe UI access
                            cmdMaster.Parameters.AddWithValue("@Name", txtName.Invoke(Function() txtName.Text))
                            cmdMaster.Parameters.AddWithValue("@Start", dtStart.Invoke(Function() dtStart.Value.Date))
                            cmdMaster.Parameters.AddWithValue("@End", dtEnd.Invoke(Function() dtEnd.Value.Date))
                            cmdMaster.Parameters.AddWithValue("@ShopId", cmbShop.Invoke(Function() cmbShop.SelectedValue))
                            cmdMaster.Parameters.AddWithValue("@Status", chkActive.Invoke(Function() chkActive.Checked))
                            cmdMaster.Parameters.AddWithValue("@By", UserID)
                            cmdMaster.Parameters.AddWithValue("@Id", CommissionId)

                            cmdMaster.ExecuteNonQuery()
                        End Using

                        newID = CommissionId

                        ' ===== Delete existing details =====
                        Using cmdDel As New SqlCommand("DELETE FROM CommissionDetails WHERE CommissionId=@Id", conn, tx)
                            cmdDel.Parameters.AddWithValue("@Id", CommissionId)
                            cmdDel.ExecuteNonQuery()
                        End Using


                    End If

                    ' ===== Build DataTable for Bulk Copy =====
                    Dim dtDetails As New DataTable()
                    dtDetails.Columns.Add("CommissionId", GetType(Integer))
                    dtDetails.Columns.Add("Barcode", GetType(String))
                    dtDetails.Columns.Add("CommissionType", GetType(String))
                    dtDetails.Columns.Add("CommissionValue", GetType(Decimal))

                    For Each item In detailRows
                        dtDetails.Rows.Add(newID, item.Barcode, item.ComType, item.CValue)
                    Next


                    ' ===== Bulk Insert with Transaction =====
                    Using bulk As New SqlBulkCopy(conn, SqlBulkCopyOptions.CheckConstraints Or SqlBulkCopyOptions.FireTriggers, tx)

                        bulk.DestinationTableName = "CommissionDetails"
                        bulk.ColumnMappings.Add("CommissionId", "CommissionId")
                        bulk.ColumnMappings.Add("Barcode", "Barcode")
                        bulk.ColumnMappings.Add("CommissionType", "CommissionType")
                        bulk.ColumnMappings.Add("CommissionValue", "CommissionValue")

                        bulk.BulkCopyTimeout = 0
                        bulk.NotifyAfter = 200

                        AddHandler bulk.SqlRowsCopied,
                        Sub(s, args)
                            ' Update progress on UI thread
                            pBar.Invoke(Sub()
                                            pBar.Value = Math.Min(args.RowsCopied, pBar.Maximum)
                                        End Sub)
                        End Sub

                        ' This is the actual heavy insert
                        bulk.WriteToServer(dtDetails)
                    End Using


                    ' ===== COMMIT =====
                    tx.Commit()
                    Return "OK"

                End Using
            End Using

        Catch ex As Exception
            ' Tell UI what failed
            Return ex.Message
        End Try

    End Function



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmSalesCommission_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CreateInlineModal()

        SQL = "select shopid, (shopname +' - '+shopcode) shopdesc from shops where shopid<>" & ShopID & " order by shopid"
                                ESSA.LoadCombo(cmbShop, SQL, "shopdesc", "shopid")
        cmbType.SelectedIndex = 0

    End Sub

    Private Sub frmCommissionMaster_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        CenterModal()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        cmbShop.SelectedIndex = 0
        dtStart.Value = DateTime.Now
        dtEnd.Value = DateTime.Now
        chkActive.Checked = True
        cmbType.SelectedIndex = 0
        txtName.Text = String.Empty
        dgvDetails.Rows.Clear()
        CommissionId = 0

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        pnlList.Visible = False
        dgvList.Rows.Clear()
        SQL = "SELECT CM.CommissionId, CM.CommissionName, CM.StartDate, CM.EndDate, S.ShopName, CM.Status, U.UserName 
        FROM CommissionMaster CM
        JOIN CommissionDetails CD ON CM.CommissionId = CD.CommissionId
        JOIN Shops S ON S.ShopID = CM.ShopId
        JOIN Users U ON U.UserID = CM.CreatedBy
        GROUP BY CM.CommissionId, CM.CommissionName, CM.StartDate, CM.EndDate, S.ShopName, CM.Status, U.UserName"

        With ESSA.OpenReader(SQL)
            While .Read
                Dim row As String() = {
                    .GetInt32(.GetOrdinal("CommissionId")).ToString(),
                    .GetString(.GetOrdinal("CommissionName")).ToUpper,
                    Format(.GetDateTime(.GetOrdinal("StartDate")), "dd-MM-yyyy") & " - " &
                    Format(.GetDateTime(.GetOrdinal("EndDate")), "dd-MM-yyyy"),
                    .GetString(.GetOrdinal("ShopName")),
                    If(.GetBoolean(.GetOrdinal("Status")), "Yes", "No").ToUpper,
                    .GetString(.GetOrdinal("UserName")).ToUpper
                }

                Dim dgvRow As New DataGridViewRow()
                dgvRow.CreateCells(dgvList, row)
                dgvList.Rows.Add(dgvRow)
            End While
        End With

        pnlList.Show()

    End Sub

    Private Sub btnHideGRN_Click(sender As Object, e As EventArgs) Handles btnHideGRN.Click
        pnlList.Hide()
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick

        If e.RowIndex = -1 Then Return

        If e.ColumnIndex = 6 Then
            CommissionId = Integer.Parse(dgvList.Rows(e.RowIndex).Cells("ColumnId").Value.ToString())
            dgvDetails.Rows.Clear()

            'Get Master Info
            SQL = "SELECT CommissionName, StartDate, EndDate, ShopId, Status FROM CommissionMaster WHERE CommissionId=" & CommissionId
            With ESSA.OpenReader(SQL)
                If .Read Then
                    txtName.Text = .GetString(.GetOrdinal("CommissionName"))
                    dtStart.Value = .GetDateTime(.GetOrdinal("StartDate"))
                    dtEnd.Value = .GetDateTime(.GetOrdinal("EndDate"))
                    cmbShop.SelectedValue = .GetInt16(.GetOrdinal("ShopId"))
                    chkActive.Checked = .GetBoolean(.GetOrdinal("Status"))
                End If
            End With

            SQL = "SELECT Barcode, CommissionType, CommissionValue FROM CommissionDetails WHERE CommissionId=" & CommissionId
            With ESSA.OpenReader(SQL)
                While .Read
                    dgvDetails.Rows.Add(
                    .GetString(.GetOrdinal("Barcode")),
                    .GetString(.GetOrdinal("CommissionType")),
                    .GetDecimal(.GetOrdinal("CommissionValue"))
                )
                End While
            End With

            pnlList.Hide()
        End If

        If e.ColumnIndex = 7 Then
            ' Delete Button Clicked
            If MessageBox.Show("Are you sure you want to delete this commission?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Dim delCommissionId As Integer = Integer.Parse(dgvList.Rows(e.RowIndex).Cells("ColumnId").Value.ToString())
                SQL = "DELETE FROM CommissionMaster WHERE CommissionId=" & delCommissionId
                ESSA.Execute(SQL)
                MessageBox.Show("Commission deleted successfully.")
                dgvList.Rows.RemoveAt(e.RowIndex)
            End If
            Return
        End If

    End Sub
End Class