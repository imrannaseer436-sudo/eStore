Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports Zuby.ADGV

Public Class frmDebitReport

    Dim bind As New BindingSource

    Private Sub frmPurchaseReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ESSA.LoadVendors(cmbVendor, "All Vendors")

    End Sub

    Private Sub GetSummary(qIndex As Byte, aIndex As Byte)

        Dim amount As Double = 0
        Dim quantity As Double = 0

        For i As Integer = 0 To dgvList.Rows.Count - 1
            quantity += Val(dgvList.Item(qIndex, i).Value)
            amount += Val(dgvList.Item(qIndex, i).Value) * Val(dgvList.Item(aIndex, i).Value)
        Next

        lblQty.Text = quantity
        lblAmount.Text = Format(amount, "0.00")

    End Sub


    Private Sub LoadData(iSql As String)

        ESSA.OpenConnection()
        Using adp As New SqlDataAdapter(iSql, Con)
            Using data2 As New DataTable
                adp.Fill(data2)
                bind.DataSource = Nothing
                bind.DataSource = data2
                dgvList.CleanFilterAndSort()
                dgvList.DataSource = Nothing
                dgvList.DataSource = bind.DataSource
            End Using
        End Using
        Con.Close()

    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        SQL = $"select m.vchno [Vch No], m.vchdt [Vch Dt], v.vendorname [Supplier], 
        m.remarks [Remarks], p.plucode [Barcode], p.pluname [Description],
        d.qty [Qty], d.rate [Rate], p.id [Size],
        a.department [Department], a.category [Category], a.style [Style],
        a.pattern [Pattern], a.material [Material], a.color [Color], a.sleeve [Sleeve],
        a.brand [Brand], a.catalog [Catalog]
        from rvchmaster m
        inner join rvchdetails d on m.vchno = d.vchno
        inner join vendors v on v.vendorid = m.vendorid
        inner join productmaster p on p.pluid = d.pluid
        inner join productattributes a on a.pluid = d.pluid
        where m.vchdt between '{Format(dtpBegin.Value, "yyyy-MM-dd")}' and '{Format(dtpEnd.Value, "yyyy-MM-dd")}'"

        If cmbVendor.SelectedIndex > 0 Then
            SQL &= $" AND m.vendorid = {cmbVendor.SelectedValue}"
        End If

        LoadData(SQL)
        GetSummary(6, 7)

    End Sub

    Private Sub dgvList_SortStringChanged(sender As Object, e As AdvancedDataGridView.SortEventArgs) Handles dgvList.SortStringChanged

        bind.Sort = dgvList.SortString

    End Sub

    Private Sub dgvList_FilterStringChanged(sender As Object, e As AdvancedDataGridView.FilterEventArgs) Handles dgvList.FilterStringChanged

        bind.Filter = dgvList.FilterString

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        If dgvList.Rows.Count = 0 Then Exit Sub

        Dim sfd1 As New SaveFileDialog
        sfd1.Title = "Please select export location"
        sfd1.FileName = "Debit Report"
        sfd1.Filter = "Excel Files (*.xlsx)|*.xlsx"
        If sfd1.ShowDialog = DialogResult.Cancel Then Exit Sub

        Dim fileName = sfd1.FileName & ".xlsx"
        Dim tableData As New DataTable
        tableData = CType(dgvList.DataSource, DataTable)

        Using package As New ExcelPackage(New IO.FileInfo(fileName))
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet1")
            ws.Cells("A1").LoadFromDataTable(tableData, True)
            package.Save()
        End Using

        MsgBox("File exported successfully..!", MsgBoxStyle.Exclamation)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        MainWindowX.CloseTab(Me.Tag)

    End Sub

End Class