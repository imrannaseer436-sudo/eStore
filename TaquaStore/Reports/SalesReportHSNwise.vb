Imports System.Data.SqlClient
Imports OfficeOpenXml

Public Class SalesReportHSNwise
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQL = "SELECT ShopId, ShopName + '-' + ShopCode ShopDesc FROM Shops WHERE ShopType = 'Retail' ORDER BY ShopId"
        ESSA.LoadCombo(cmbLocation, SQL, "ShopDesc", "ShopId")

    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        lblLoading.Visible = True
        lblLoading.Refresh()

        'If chkReturn.Checked Then

        '    SQL = "SELECT DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], " _
        '  & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], " _
        '  & "IIf(BD.Rate >= 1000,(100 * BD.Amount )/(100 + PT.Mx),(100 * BD.Amount )/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200) [CGST Amt], " _
        '  & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], " _
        '  & "IIf(BD.Rate >= 1000,(100 * BD.Amount )/(100 + PT.Mx),(100 * BD.Amount )/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200) [SGST Amt], " _
        '  & "IIf(BD.Rate >= 1000,(100 * BD.Amount )/(100 + PT.Mx),(100 * BD.Amount )/ (100 + PT.Mn)) Taxable , " _
        '  & "PM.Catlink Category,PM.Units [UOM],BD.PluId " _
        '  & "FROM BILLMASTER BM,BillDetails BD,ProductMaster PM,ProductAttributes PA,ProductTax PT " _
        '  & "WHERE BM.BillID = BD.BillID AND BD.PluID = PM.PluID AND PM.PluID = PA.PluId AND PA.DeptId = PT.DeptId " _
        '  & "And PA.CatId = PT.CatId And PA.MaterialId = PT.MatId AND BD.Qty < 0 AND BD.BillDt BETWEEN '" _
        '  & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BD.ShopId = " _
        '  & cmbLocation.SelectedValue & " ORDER BY BM.BillNo"

        'Else

        '    SQL = "SELECT DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], " _
        '    & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], " _
        '    & "IIf(BD.Rate >= 1000,(100 * BD.Amount )/(100 + PT.Mx),(100 * BD.Amount )/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200) [CGST Amt], " _
        '    & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], " _
        '    & "IIf(BD.Rate >= 1000,(100 * BD.Amount )/(100 + PT.Mx),(100 * BD.Amount )/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200) [SGST Amt], " _
        '    & "IIf(BD.Rate >= 1000,(100 * BD.Amount )/(100 + PT.Mx),(100 * BD.Amount )/ (100 + PT.Mn)) Taxable , " _
        '    & "PM.CatLink Category,PM.Units [UOM],BD.PluId " _
        '    & "FROM BILLMASTER BM,BillDetails BD,ProductMaster PM,ProductAttributes PA,ProductTax PT " _
        '    & "WHERE BM.BillID = BD.BillID AND BD.PluID = PM.PluID AND PM.PluID = PA.PluId AND PA.DeptId = PT.DeptId " _
        '    & "And PA.CatId = PT.CatId And PA.MaterialId = PT.MatId AND BD.Qty > 0 AND BM.CustomerId = 1 AND BD.BillDt BETWEEN '" _
        '    & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BD.ShopId = " _
        '    & cmbLocation.SelectedValue & " ORDER BY BM.BillNo"

        'End If

        If rbNormal.Checked Then

            'SQL = "SELECT DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], " _
            '    & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [CGST Amt], " _
            '    & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [SGST Amt], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)),2) Taxable , " _
            '    & "PM.CatLink Category,PM.Units [UOM],BD.PluId " _
            '    & "FROM " & GetDatatable("Master") & " BM," & GetDatatable("Details") & " BD,ProductMaster PM,ProductAttributes PA,ProductTax PT " _
            '    & "WHERE BM.BillID = BD.BillID AND BD.PluID = PM.PluID AND PM.PluID = PA.PluId AND PA.DeptId = PT.DeptId " _
            '    & "And PA.CatId = PT.CatId And PA.MaterialId = PT.MatId AND BD.Qty > 0 AND BM.CustomerId = 1 AND BD.BillDt BETWEEN '" _
            '    & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BD.ShopId = " _
            '    & cmbLocation.SelectedValue & " ORDER BY BM.BillNo"

            SQL = "SELECT DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [CGST Amt], IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [SGST Amt], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)),2) Taxable , PM.CatLink Category,PM.Units [UOM],BD.PluId " _
            & "FROM BillMaster BM " _
            & "INNER JOIN BillDetails BD On BD.BillID = BM.BillID And BD.Qty > 0 And BM.CustomerId = 1 And BM.BillDt BETWEEN '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BM.ShopId = " & cmbLocation.SelectedValue & " " _
            & "INNER JOIN ProductMaster PM ON PM.PluID = BD.PluID " _
            & "INNER JOIN ProductAttributes PA ON PA.PluId = PM.PluID " _
            & "INNER JOIN ProductTax PT ON PT.DeptId = PA.DeptId And PT.CatId = PA.CatId And PT.MatId = PA.MaterialId " _
            & "AND PT.IsUpdated = BM.IsUpdated " _ 'to work based on tax version
            & "ORDER BY BM.BillNo "

        ElseIf rbGST.Checked Then

            'SQL = "Select DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], " _
            '    & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount As MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount As MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [CGST Amt], " _
            '    & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount As MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount As MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [SGST Amt], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount As MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount As MONEY))/ (100 + PT.Mn)),2) Taxable , " _
            '    & "PM.CatLink Category,PM.Units [UOM],BD.PluId " _
            '    & "FROM " & GetDatatable("Master") & " BM," & GetDatatable("Details") & " BD,ProductMaster PM,ProductAttributes PA,ProductTax PT " _
            '    & "WHERE BM.BillID = BD.BillID And BD.PluID = PM.PluID And PM.PluID = PA.PluId And PA.DeptId = PT.DeptId " _
            '    & "And PA.CatId = PT.CatId And PA.MaterialId = PT.MatId And BD.Qty > 0 And BM.CustomerId <> 1 And BD.BillDt BETWEEN '" _
            '    & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BD.ShopId = " _
            '    & cmbLocation.SelectedValue & " ORDER BY BM.BillNo"

            SQL = "SELECT DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [CGST Amt], IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [SGST Amt], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)),2) Taxable , PM.CatLink Category,PM.Units [UOM],BD.PluId " _
            & "FROM BillMaster BM " _
            & "INNER JOIN BillDetails BD On BD.BillID = BM.BillID And BD.Qty > 0 And BM.CustomerId <> 1 And BM.BillDt BETWEEN '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BM.ShopId = " & cmbLocation.SelectedValue & " " _
            & "INNER JOIN ProductMaster PM ON PM.PluID = BD.PluID " _
            & "INNER JOIN ProductAttributes PA ON PA.PluId = PM.PluID " _
            & "INNER JOIN ProductTax PT ON PT.DeptId = PA.DeptId And PT.CatId = PA.CatId And PT.MatId = PA.MaterialId " _
            & "AND PT.IsUpdated = BM.IsUpdated " _ 'to work based on tax version
            & "ORDER BY BM.BillNo "

        ElseIf rbReturn.Checked Then

            'SQL = "SELECT DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], " _
            '    & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [CGST Amt], " _
            '    & "IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [SGST Amt], " _
            '    & "ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)),2) Taxable , " _
            '    & "PM.Catlink Category,PM.Units [UOM],BD.PluId " _
            '    & "FROM " & GetDatatable("Master") & " BM," & GetDatatable("Details") & " BD,ProductMaster PM,ProductAttributes PA,ProductTax PT " _
            '    & "WHERE BM.BillID = BD.BillID AND BD.PluID = PM.PluID AND PM.PluID = PA.PluId AND PA.DeptId = PT.DeptId " _
            '    & "And PA.CatId = PT.CatId And PA.MaterialId = PT.MatId AND BD.Qty < 0 AND BD.BillDt BETWEEN '" _
            '    & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BD.ShopId = " _
            '    & cmbLocation.SelectedValue & " ORDER BY BM.BillNo"

            SQL = "SELECT DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [CGST Amt], IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [SGST Amt], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)),2) Taxable , PM.CatLink Category,PM.Units [UOM],BD.PluId " _
           & "FROM BillMaster BM " _
           & "INNER JOIN BillDetails BD On BD.BillID = BM.BillID And BD.Qty < 0 And BM.BillDt BETWEEN '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BM.ShopId = " & cmbLocation.SelectedValue & " " _
           & "INNER JOIN ProductMaster PM ON PM.PluID = BD.PluID " _
           & "INNER JOIN ProductAttributes PA ON PA.PluId = PM.PluID " _
           & "INNER JOIN ProductTax PT ON PT.DeptId = PA.DeptId And PT.CatId = PA.CatId And PT.MatId = PA.MaterialId " _
           & "AND PT.IsUpdated = BM.IsUpdated " _ 'to work based on tax version
           & "ORDER BY BM.BillNo "

        ElseIf rbTotal.Checked Then

            SQL = "SELECT DISTINCT BM.BillNo [Bill No],BD.TermId [Term Id],BD.BillDt [Date],PM.Plucode [Item Code],PM.HSNCode [HSN],BD.Qty [Qty],BD.Rate [Rate],BD.Amount [Amount], IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [CGST], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [CGST Amt], IIF(BD.Rate >= 1000,PT.Mx/2,PT.Mn/2) [SGST], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/200,PT.Mn/200),2) [SGST Amt], ROUND(IIf(BD.Rate >= 1000,(100 * CAST(BD.Amount AS MONEY))/(100 + PT.Mx),(100 * CAST(BD.Amount AS MONEY))/ (100 + PT.Mn)),2) Taxable , PM.CatLink Category,PM.Units [UOM],BD.PluId " _
            & "FROM BillMaster BM " _
            & "INNER JOIN BillDetails BD On BD.BillID = BM.BillID And BM.BillDt BETWEEN '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BM.ShopId = " & cmbLocation.SelectedValue & " " _
            & "INNER JOIN ProductMaster PM ON PM.PluID = BD.PluID " _
            & "INNER JOIN ProductAttributes PA ON PA.PluId = PM.PluID " _
            & "INNER JOIN ProductTax PT ON PT.DeptId = PA.DeptId And PT.CatId = PA.CatId And PT.MatId = PA.MaterialId " _
            & "AND PT.IsUpdated = BM.IsUpdated " _ 'to work based on tax version
            & "ORDER BY BM.BillNo "

        End If

        'dgvReport.Rows.Clear()
        'With LoadReader(Qry)
        '    While .Read
        '        Dim row = dgvReport.Rows.Add()
        '        dgvReport.Item(0, row).Value = .Item(0)
        '        dgvReport.Item(1, row).Value = Format(.GetDateTime(1), "dd-MM-yyyy")
        '        dgvReport.Item(2, row).Value = .GetString(2)
        '        dgvReport.Item(3, row).Value = .GetString(3)
        '        dgvReport.Item(4, row).Value = .Item(4)
        '        dgvReport.Item(5, row).Value = Format(.Item(5), "0.00")
        '        dgvReport.Item(6, row).Value = Format(.Item(6), "0.00")
        '        dgvReport.Item(7, row).Value = .Item(7)
        '        dgvReport.Item(8, row).Value = Format(.Item(8), "0.00")
        '        dgvReport.Item(9, row).Value = .Item(9)
        '        dgvReport.Item(10, row).Value = Format(.Item(10), "0.00")
        '        dgvReport.Item(11, row).Value = Format(.Item(11), "0.00")
        '        dgvReport.Item(12, row).Value = .GetString(12)
        '        dgvReport.Item(13, row).Value = .GetString(13)
        '    End While
        '    .Close()
        'End With

        dgvReport.Columns.Clear()

        Try
            LoadDataGrid(dgvReport, SQL)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        dgvReport.Columns(0).Width = 60
        dgvReport.Columns(1).Width = 50
        dgvReport.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvReport.Columns(2).Width = 75
        dgvReport.Columns(2).DefaultCellStyle.Format = "dd-MM-yyyy"
        dgvReport.Columns(3).Width = 85
        dgvReport.Columns(4).Width = 75
        dgvReport.Columns(5).Width = 40
        dgvReport.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReport.Columns(6).Width = 75
        dgvReport.Columns(6).DefaultCellStyle.Format = "N2"
        dgvReport.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReport.Columns(7).Width = 75
        dgvReport.Columns(7).DefaultCellStyle.Format = "N2"
        dgvReport.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReport.Columns(8).Width = 40
        dgvReport.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReport.Columns(9).Width = 60
        dgvReport.Columns(9).DefaultCellStyle.Format = "N2"
        dgvReport.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReport.Columns(10).Width = 40
        dgvReport.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReport.Columns(11).Width = 60
        dgvReport.Columns(11).DefaultCellStyle.Format = "N2"
        dgvReport.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReport.Columns(12).Width = 75
        dgvReport.Columns(12).DefaultCellStyle.Format = "N2"
        dgvReport.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReport.Columns(13).Width = 235
        dgvReport.Columns(14).Width = 40
        dgvReport.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvReport.Columns(15).Visible = False


        'Qry = "SELECT DISTINCT IIF(BD.Rate >= 1000,PT.Mx,PT.Mn) TaxPerc, " _
        '    & "SUM(IIf(BD.Rate >= 1000,(100 * BD.Amount )/(100 + PT.Mx),(100 * BD.Amount )/ (100 + PT.Mn))) TaxableValue , " _
        '    & "SUM(IIf(BD.Rate >= 1000,(100 * BD.Amount )/(100 + PT.Mx),(100 * BD.Amount )/ (100 + PT.Mn)) * IIF(BD.Rate >= 1000,PT.Mx/100,PT.Mn/100)) TaxValue, " _
        '    & "SUM(BD.Amount) Total " _
        '    & "FROM BILLMASTER BM,BillDetails BD,ProductMaster PM,ProductAttributes PA,ProductTax PT " _
        '    & "WHERE BM.BillID = BD.BillID And BD.PluID = PM.PluID And PM.PluID = PA.PluId And " _
        '    & "PA.DeptId = PT.DeptId And PA.CatId = PT.CatId And PA.MaterialId = PT.MatId AND PM.HSNCode = PT.HSN AND " _
        '    & "BD.BillDt BETWEEN '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BD.ShopId = " & cmbLocation.SelectedValue & "  " _
        '    & "GROUP BY IIF(BD.Rate >= 1000,PT.Mx,PT.Mn)"

        'With LoadReader(Qry)
        '    dgvSummary.Rows.Clear()
        '    dgvSummary.Visible = True
        '    While .Read
        '        Dim row2 = dgvSummary.Rows.Add()
        '        dgvSummary.Item(0, row2).Value = .Item(1)
        '        dgvSummary.Item(1, row2).Value = Format(.Item(0), "0.00")
        '        dgvSummary.Item(2, row2).Value = Format(.Item(2), "0.00")
        '        dgvSummary.Item(3, row2).Value = Format(.Item(3), "0.00")
        '    End While
        '    .Close()
        'End With
        Try
            CalculateSummary()
            dgvSummary.Visible = True
            lblLoading.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub CalculateSummary()

        'SQL = "SELECT DISTINCT IIF(BD.Rate >= 1000,PT.Mx,PT.Mn) " _
        '    & "FROM " & GetDatatable("Master") & " BM," & GetDatatable("Details") & " BD,ProductMaster PM,ProductAttributes PA,ProductTax PT " _
        '    & "WHERE BM.BillID = BD.BillID AND BD.PluID = PM.PluID AND PM.PluID = PA.PluId AND " _
        '    & "PA.DeptId = PT.DeptId And PA.CatId = PT.CatId And PA.MaterialId = PT.MatId And  " _
        '    & "BD.BillDt BETWEEN '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BD.ShopId = " & cmbLocation.SelectedValue & ""

        SQL = "SELECT DISTINCT IIF(BD.Rate >= 1000,PT.Mx,PT.Mn) " _
            & "FROM BillMaster BM " _
            & "INNER JOIN BillDetails BD ON BD.BillId = BM.BillID AND BM.BillDt BETWEEN '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' AND BM.ShopID = " & cmbLocation.SelectedValue & "" _
            & "INNER JOIN ProductAttributes PA On PA.PluId = BD.PluID " _
            & "INNER JOIN ProductTax PT ON PT.DeptId = PA.DeptId AND PT.CatId = PA.CatId AND PT.MatId = PA.MaterialId  " _
            & "AND PT.IsUpdated = BM.IsUpdated"  'to work based on tax version


        dgvSummary.Rows.Clear()
        With ESSA.OpenReader(SQL)
            While .Read
                Dim row = dgvSummary.Rows.Add()
                dgvSummary.Item(1, row).Value = .Item(0)
            End While
            .Close()
        End With

        Dim taxableValue1 As Decimal = 0
        Dim taxValue1 As Decimal = 0
        Dim total1 As Decimal = 0
        Dim taxableValue2 As Decimal = 0
        Dim taxValue2 As Decimal = 0
        Dim total2 As Decimal = 0
        Dim taxableValue3 As Decimal = 0
        Dim taxValue3 As Decimal = 0
        Dim total3 As Decimal = 0
        Dim taxableValue4 As Decimal = 0
        Dim taxValue4 As Decimal = 0
        Dim total4 As Decimal = 0

        For i As Integer = 0 To dgvSummary.Rows.Count - 1
            For j As Integer = 0 To dgvReport.Rows.Count - 1
                Select Case Val(dgvSummary.Item(1, i).Value)
                    Case 3
                        If dgvReport.Item(8, j).Value = 1.5 Then
                            taxableValue1 += Val(dgvReport.Item(12, j).Value)
                            taxValue1 += Val(dgvReport.Item(9, j).Value) * 2
                            total1 += Val(dgvReport.Item(7, j).Value)
                        End If
                    Case 5
                        If dgvReport.Item(8, j).Value = 2.5 Then
                            taxableValue2 += Val(dgvReport.Item(12, j).Value)
                            taxValue2 += Val(dgvReport.Item(9, j).Value) * 2
                            total2 += Val(dgvReport.Item(7, j).Value)
                        End If
                    Case 12
                        If dgvReport.Item(8, j).Value = 6 Then
                            taxableValue3 += Val(dgvReport.Item(12, j).Value)
                            taxValue3 += Val(dgvReport.Item(9, j).Value) * 2
                            total3 += Val(dgvReport.Item(7, j).Value)
                        End If
                    Case 18
                        If dgvReport.Item(8, j).Value = 9 Then
                            taxableValue4 += Val(dgvReport.Item(12, j).Value)
                            taxValue4 += Val(dgvReport.Item(9, j).Value) * 2
                            total4 += Val(dgvReport.Item(7, j).Value)
                        End If
                End Select

                If dgvSummary.Item(1, i).Value = 3 Then
                    dgvSummary.Item(0, i).Value = Format(taxableValue1, "0.00")
                    dgvSummary.Item(2, i).Value = Format(taxValue1, "0.00")
                    dgvSummary.Item(3, i).Value = Format(total1, "0.00")
                ElseIf dgvSummary.Item(1, i).Value = 5 Then
                    dgvSummary.Item(0, i).Value = Format(taxableValue2, "0.00")
                    dgvSummary.Item(2, i).Value = Format(taxValue2, "0.00")
                    dgvSummary.Item(3, i).Value = Format(total2, "0.00")
                ElseIf dgvSummary.Item(1, i).Value = 12 Then
                    dgvSummary.Item(0, i).Value = Format(taxableValue3, "0.00")
                    dgvSummary.Item(2, i).Value = Format(taxValue3, "0.00")
                    dgvSummary.Item(3, i).Value = Format(total3, "0.00")
                ElseIf dgvSummary.Item(1, i).Value = 18 Then
                    dgvSummary.Item(0, i).Value = Format(taxableValue4, "0.00")
                    dgvSummary.Item(2, i).Value = Format(taxValue4, "0.00")
                    dgvSummary.Item(3, i).Value = Format(total4, "0.00")
                End If
            Next
        Next

        Dim summaryRow = dgvSummary.Rows.Add()
        Dim taxableTotal As Double
        Dim taxTotal As Double
        Dim grossTotal As Double
        For i As Short = 0 To dgvSummary.Rows.Count - 1
            taxableTotal += Val(dgvSummary.Item(0, i).Value)
            taxTotal += Val(dgvSummary.Item(2, i).Value)
            grossTotal += Val(dgvSummary.Item(3, i).Value)
        Next

        dgvSummary.Item(0, summaryRow).Value = taxableTotal
        dgvSummary.Item(2, summaryRow).Value = taxTotal
        dgvSummary.Item(3, summaryRow).Value = grossTotal

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        If dgvReport.Rows.Count = 0 Then Exit Sub

        Dim sfd1 As New SaveFileDialog
        sfd1.Title = "Please select export location"
        sfd1.FileName = "Sales Report  " & Format(dtpFrom.Value, "dd-MM-yyyy") & " to " & Format(dtpTo.Value, "dd-MM-yyyy")
        sfd1.Filter = "Excel Files (*.xlsx)|*.xlsx"
        If sfd1.ShowDialog = DialogResult.Cancel Then Exit Sub

        Dim fileName = sfd1.FileName
        Dim tableData As New DataTable
        tableData = CType(dgvReport.DataSource, DataTable)

        Try
            Using package As New ExcelPackage(New IO.FileInfo(fileName))
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet1")
                ws.Cells("A1").LoadFromDataTable(tableData, True)
                ws.Column(3).Style.Numberformat.Format = "dd-MM-yyyy"
                ws.Column(3).Width = 12
                ws.Column(4).Width = 12
                ws.Column(5).Width = 12
                ws.Column(10).Style.Numberformat.Format = "#.##"
                ws.Column(12).Style.Numberformat.Format = "#.##"
                ws.Column(13).Style.Numberformat.Format = "#.##"
                ws.Column(14).Width = 40
                ws.DeleteColumn(16)
                'ws.Column(15).Hidden = True
                package.Save()
                MsgBox("Exported successfully..!", MsgBoxStyle.Information)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub


    Public Shared Sub LoadDataGrid(ByVal DGV As DataGridView, ByVal Qry As String)

        ESSA.OpenConnection()
        Using Adp As New SqlDataAdapter(Qry, Con)
            Adp.SelectCommand.CommandTimeout = 0
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                DGV.DataSource = Nothing
                DGV.DataSource = Tbl
            End Using
        End Using
        Con.Close()

    End Sub

    Private Sub btnUpdate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnUpdate.LinkClicked

        lblLoading.Visible = True
        lblLoading.Refresh()
        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim trn = Con.BeginTransaction
        Cmd.Transaction = trn

        'SQL = "EXEC SP_UpdateCustomerId"
        Try
            Cmd.CommandTimeout = 0
            Cmd.CommandText = "SP_UpdateCustomerId"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.ExecuteNonQuery()
            trn.Commit()
            Con.Close()
            MsgBox("Updated Successfully..!", MsgBoxStyle.Information)
            'Execute(SQL)
        Catch ex As Exception
            trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        lblLoading.Visible = False

    End Sub

    Public Shared Function Execute(ByVal Qry As String) As Integer

        Execute = 0

        Try
            Using nCon As New SqlConnection(ConStr)
                nCon.Open()
                Using Cmd As New SqlCommand(Qry, nCon)
                    Cmd.CommandTimeout = 0
                    Execute = Cmd.ExecuteNonQuery
                End Using
                nCon.Close()
            End Using
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

    Public Function GetDatatable(Name As String) As String

        GetDatatable = ""

        If Name = "Master" Then

            If cmbLocation.SelectedValue = 2 Then
                GetDatatable = "BillMaster_L01"
            ElseIf cmbLocation.SelectedValue = 3 Then
                GetDatatable = "BillMaster_L02"
            ElseIf cmbLocation.SelectedValue = 4 Then
                GetDatatable = "BillMaster_L03"
            ElseIf cmbLocation.SelectedValue = 5 Then
                GetDatatable = "BillMaster_L04"
            ElseIf cmbLocation.SelectedValue = 6 Then
                GetDatatable = "BillMaster_L05"
            End If

        ElseIf Name = "Details" Then

            If cmbLocation.SelectedValue = 2 Then
                GetDatatable = "BillDetails_L01"
            ElseIf cmbLocation.SelectedValue = 3 Then
                GetDatatable = "BillDetails_L02"
            ElseIf cmbLocation.SelectedValue = 4 Then
                GetDatatable = "BillDetails_L03"
            ElseIf cmbLocation.SelectedValue = 5 Then
                GetDatatable = "BillDetails_L04"
            ElseIf cmbLocation.SelectedValue = 6 Then
                GetDatatable = "BillDetails_L05"
            End If

        ElseIf Name = "Customers" Then

            If cmbLocation.SelectedValue = 3 Then
                GetDatatable = "V_CustomersL2"
            ElseIf cmbLocation.SelectedValue = 5 Then
                GetDatatable = "V_CustomersL4"
            End If

        End If

        Return GetDatatable

    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub VIEWBILLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VIEWBILLToolStripMenuItem.Click

        Dim BillId As Long
        BillId = GetBillId(dgvReport.Item(1, dgvReport.CurrentRow.Index).Value, dgvReport.Item(0, dgvReport.CurrentRow.Index).Value, dgvReport.Item(2, dgvReport.CurrentRow.Index).Value)
        PrintGSTBillNew(BillId, CheckForIGST(BillId))

    End Sub

    Private Rpt2 As New rptGSTBill2
    Private Rpt3 As New rptGSTBill3
    Private Rpt4 As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub PrintGSTBillNew(iBillID As Long, IGST As Boolean)

        Rpt4 = IIf(IGST, Rpt3, Rpt2)

        'SQL = "select distinct s.address1,s.address2,s.city,s.phone,s.cst," _
        '    & "c.customername,c.address1 caddress1,c.address2 caddress2,c.city ccity," _
        '    & "c.phone cphone,c.mobile cmobile," _
        '    & "(convert(varchar,bm.termid) + '-' + convert(varchar,bm.billno)) billno,bm.billdt," _
        '    & "p.pluname as plucode,p.hsncode,p.utax,bd.Qty,bd.Amount,bd.rate,bd.pluid,t.mn,t.mx,t.val,bd.sno,c.state cstate " _
        '    & "from shops s,customers c,billmaster bm,billdetails bd,productmaster p,productattributes a,producttax t " _
        '    & "where bm.billid=bd.billid and bd.pluid=p.pluid and p.pluid = a.pluid and a.deptid = t.deptid and a.catid = t.catid and a.materialid= t.matid and bm.billid={0} " _
        '    & "and bm.shopid=s.shopid and bm.customerid=c.customerid " _
        '    & "order by bd.sno"

        SQL = "select distinct s.address1,s.address2,s.city,s.phone,s.cst," _
            & "c.customername,c.address1 caddress1,c.address2 caddress2,c.city ccity," _
            & "c.phone cphone,c.mobile cmobile," _
            & "(convert(varchar,bm.termid) + '-' + convert(varchar,bm.billno)) billno,bm.billdt," _
            & "p.pluname as plucode,p.hsncode,p.utax,bd.Qty,bd.Amount,bd.rate,bd.pluid,t.mn,t.mx,t.val,bd.sno,c.state cstate " _
            & "from shops s,Customers c,BillMaster bm,BillDetails bd,productmaster p,productattributes a,producttax t " _
            & "where bm.billid=bd.billid and bd.pluid=p.pluid and p.pluid = a.pluid and a.deptid = t.deptid and a.catid = t.catid and a.materialid= t.matid and t.isupdated = bm.isupdated and bm.billid={0} " _
            & "and bm.shopid=s.shopid and bm.customerid=c.customerid " _
            & "order by bd.sno"

        SQL = String.Format(SQL, iBillID)

        Try
            ESSA.OpenConnection()
            Using Adp As New SqlDataAdapter(SQL, Con)
                Using Tbl As New DataTable
                    Adp.Fill(Tbl)
                    Rpt4.SetDataSource(Tbl)
                    ReportViewer.CViewer.ReportSource = Rpt4
                    ReportViewer.Visible = False
                    ReportViewer.Show()
                End Using
            End Using
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Con.Close()
        End Try

    End Sub

    Public Function GetBillId(termid As Short, billno As Integer, billdate As Date) As Long

        GetBillId = 0

        SQL = "SELECT BillId FROM BillMaster WHERE TermId = " & termid & " AND BillNo =" & billno & " AND BillDt ='" & Format(billdate, "yyyy-MM-dd") & "'"
        With ESSA.OpenReader(SQL)
            If .Read Then
                GetBillId = .Item(0)
            End If
        End With
        Return GetBillId

    End Function

    Private Function CheckForIGST(billid As Long) As Boolean

        CheckForIGST = False
        SQL = "SELECT Remarks FROM BillMaster WHERE BillId = " & billid
        With ESSA.OpenReader(SQL)
            If .Read Then
                If .GetString(0).Contains("IGST") Then
                    CheckForIGST = True
                End If
            End If
        End With
        Return CheckForIGST

    End Function

    Private Sub dgvReports_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvReport.CellMouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
                Me.dgvReport.ClearSelection()
                Dim cell = Me.dgvReport.Item(e.ColumnIndex, e.RowIndex)
                Me.dgvReport.CurrentCell = cell
                cell.Selected = True 'Needed if you right click twice on the same cell
                dgvReport.ContextMenuStrip = ContextMenuStrip1
            End If
        End If

    End Sub

End Class
