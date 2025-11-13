'****************************************** Bismillah *************************************************
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports CrystalDecisions.Shared
Public Class DeliveryChallanReport


    Private Rpt1 As New RptProductDeliveryReport

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub DeliveryChallanReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SQL = "select shopid,(shopname + ' - ' + shopcode) sname from shops where shopid<>" & ShopID _
            & " order by shopid"
        ESSA.LoadCombo(cmbDLoc, SQL, "sname", "shopid", "All Shops(s)")

        SQL = "select vendorid,vendorname from vendors order by vendorname"
        ESSA.LoadCombo(cmbVendor, SQL, "vendorname", "vendorid", "All Vendor(s)")

        Dim OBTbl As New DataTable
        OBTbl.Columns.Add("OBID")
        OBTbl.Columns.Add("OBNAME")

        Dim DR = OBTbl.NewRow
        DR("OBID") = "deliverydate"
        DR("OBNAME") = "D.C Da"
        OBTbl.Rows.Add(DR)

        DR = OBTbl.NewRow
        DR("OBID") = "plucode"
        DR("OBNAME") = "CODE"
        OBTbl.Rows.Add(DR)

        cmbOrderBy.DataSource = OBTbl
        cmbOrderBy.DisplayMember = "OBNAME"
        cmbOrderBy.ValueMember = "OBID"

        ESSA.EnableContainsFilterForAll(Me)

    End Sub

    Private Sub cmbDLoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDLoc.SelectedIndexChanged

        If cmbDLoc.SelectedIndex = -1 Then Exit Sub

        SQL = "select deliverycode from deliverymaster"
        If cmbDLoc.SelectedIndex > 0 Then
            SQL &= " where deliveryto=" & IIf(cmbDLoc.SelectedValue.ToString.Contains("DataRow"), 0, cmbDLoc.SelectedValue)
        End If
        SQL &= " order by deliverydate"

        ESSA.LoadCombo(cmbDCode, SQL, "deliverycode", "")

    End Sub

    Private Sub LoadDeliveryReportVendorWise()

        If cmbDLoc.SelectedIndex <= 0 Then
            MsgBox("Please select a delivery location..!", MsgBoxStyle.Information)
            Exit Sub
        End If

        SQL = "select m.deliverycode,m.deliverydate,p.plucode,d.quantity,a.category as scatdesc1 from deliverymaster m,deliverydetails d,productmaster p,productattributes a where " _
            & "m.id=d.id and d.pluid=p.pluid and p.pluid=a.pluid and m.deliveryfrom=" & ShopID & " and m.deliveryto=" & cmbDLoc.SelectedValue

        If cmbVendor.SelectedIndex > 0 Then
            SQL &= " and p.vendorid=" & cmbVendor.SelectedValue
        End If

        If cmbDCode.SelectedIndex > 0 Then
            SQL &= " and m.deliverycode='" & cmbDCode.Text.Trim & "'"
        End If

        If txtCode.Text.Trim.Length > 0 Then
            SQL &= " and p.plucode='" & txtCode.Text.Trim & "'"
        End If

        SQL &= " order by " & cmbOrderBy.SelectedValue

        ESSA.OpenConnection()

        Using Adp As New SqlDataAdapter(SQL, Con)

            Using Tbl As New DataTable

                Adp.Fill(Tbl)
                Rpt1.SetDataSource(Tbl)
                Rpt1.SetParameterValue("Location", cmbDLoc.Text)
                CRpt.ReportSource = Rpt1

            End Using

        End Using

        Con.Close()

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        If chkVBR.Checked = True Then

            LoadDeliveryReportVendorWise()

        ElseIf chkBranchTransfer.Checked Then

            If cmbDCode.SelectedIndex = -1 Then
                MsgBox("Delivery code not found..!", MsgBoxStyle.Information)
                Exit Sub
            End If

            'GenerateInvoice(cmbDCode.Text.Trim)
            GenerateTransferReceipt(cmbDCode.Text.Trim)

        Else

            If cmbDCode.SelectedIndex = -1 Then
                MsgBox("Delivery code not found..!", MsgBoxStyle.Information)
                Exit Sub
            End If

            PrintDeliveryChallan(cmbDCode.Text.Trim)

        End If

    End Sub

    Private Rpt As New RptDeliveryChallan
    Private Sub PrintDeliveryChallan(deliveryCode As String)

        Using nCon As New SqlConnection(ConStr)

            nCon.Open()

            Try

                SQL = "select s.alias,s.city,m.deliverycode,m.deliverydate,p.plucode,p.pluname,p.units,d.quantity," _
                    & "s1.shopname dfrom,s2.shopname dto,a.category,m.remarks,p.id Size from deliverymaster m,shops s,shops s1,shops s2,deliverydetails d,productmaster p,productattributes a where p.pluid=a.pluid and " _
                    & "m.deliveryfrom = s.shopid And m.id = d.id And d.pluid = p.pluid And m.deliveryfrom = s1.shopid " _
                    & " And m.deliveryto = s2.shopid and m.deliverycode='" & deliveryCode & "' order by d.sno"

                Using Adp As New SqlDataAdapter(SQL, nCon)

                    Using Tbl As New DataTable
                        Adp.Fill(Tbl)
                        Rpt.SetDataSource(Tbl)
                        CRpt.ReportSource = Rpt
                    End Using

                End Using

            Catch ex As SqlException

                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try

            nCon.Close()

        End Using

    End Sub

    Private Sub GenerateInvoice(DeliveryCode As String)

        Dim InvoiceRpt As New Invoice

        Using nCon As New SqlConnection(ConStr)
            Try
                nCon.Open()

                Dim fromShopName, fromShopAddress, fromShopGst, fromShopMobile As String
                Dim toShopName, toShopAddress, toShopGst, toShopMobile As String
                Dim invNo, invDt As String

                ' Fetch header details
                SQL = "SELECT DM.DeliveryCode, DM.DeliveryDate, 
                   S1.Alias [FCName], S1.Address1 + ' ' + S1.Address2 + ' ' + S1.City + ', ' + S1.State [FCAddress], S1.Phone [FCPhone], S1.CST [FCGst],
                   S2.Alias [TCName], S2.Address1 + S2.Address2 + S2.City + ',' + S2.State [TCAddress],S2.Phone [TCPhone], S2.CST [TCGst]
                   FROM DeliveryMaster DM
                   INNER JOIN Shops S1 ON DM.DeliveryFrom = S1.ShopID
                   INNER JOIN Shops S2 ON DM.DeliveryTo = S2.ShopID
                   WHERE DM.DeliveryCode = @DeliveryCode"

                Using cmd As New SqlCommand(SQL, nCon)
                    cmd.Parameters.AddWithValue("@DeliveryCode", DeliveryCode)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            fromShopName = reader("FCName").ToString()
                            fromShopAddress = reader("FCAddress").ToString()
                            fromShopGst = reader("FCGst").ToString()
                            fromShopMobile = reader("FCPhone").ToString()
                            toShopName = reader("TCName").ToString()
                            toShopAddress = reader("TCAddress").ToString()
                            toShopGst = reader("TCGst").ToString()
                            toShopMobile = reader("TCPhone").ToString()
                            invNo = reader("DeliveryCode").ToString()
                            invDt = Format(reader("DeliveryDate"), "dd-MM-yyyy")
                        End If
                    End Using
                End Using

                ' Fetch tax data for subreport
                SQL = "SELECT 
                    TaxType,
                    SUM(Taxable) AS Taxable,
                    TaxPerc
                FROM
                (
                    -- Intra-state: CGST
                    SELECT 
                        'CGST' AS TaxType,
                        SUM(DD.Quantity * DD.CostPrice) AS Taxable,
                        (CASE WHEN DD.CostPrice > PT.Val THEN PT.Mx ELSE PT.Mn END) / 2 AS TaxPerc
                    FROM DeliveryMaster DM
                    JOIN DeliveryDetails DD ON DM.Id = DD.Id 
                        AND DM.DeliveryCode = @DeliveryCode
                    JOIN ProductAttributes PA ON PA.PluId = DD.PluID
                    JOIN ProductTax PT ON PT.DeptId = PA.DeptId AND PT.CatId = PA.CatId AND PT.MatId = PA.MaterialId
                    AND PT.IsUpdated = @TaxVersion
                    JOIN Shops S1 ON S1.ShopID = DM.DeliveryFrom
                    JOIN Shops S2 ON S2.ShopID = DM.DeliveryTo
                    WHERE S1.State = S2.State
                    GROUP BY S1.State, S2.State, DD.CostPrice, PT.Val, PT.Mx, PT.Mn

                    UNION ALL

                    -- Intra-state: SGST
                    SELECT 
                        'SGST' AS TaxType,
                        SUM(DD.Quantity * DD.CostPrice) AS Taxable,
                        (CASE WHEN DD.CostPrice > PT.Val THEN PT.Mx ELSE PT.Mn END) / 2 AS TaxPerc
                    FROM DeliveryMaster DM
                    JOIN DeliveryDetails DD ON DM.Id = DD.Id 
                        AND DM.DeliveryCode = @DeliveryCode
                    JOIN ProductAttributes PA ON PA.PluId = DD.PluID
                    JOIN ProductTax PT ON PT.DeptId = PA.DeptId AND PT.CatId = PA.CatId AND PT.MatId = PA.MaterialId
                    AND PT.IsUpdated = @TaxVersion
                    JOIN Shops S1 ON S1.ShopID = DM.DeliveryFrom
                    JOIN Shops S2 ON S2.ShopID = DM.DeliveryTo
                    WHERE S1.State = S2.State
                    GROUP BY S1.State, S2.State, DD.CostPrice, PT.Val, PT.Mx, PT.Mn

                    UNION ALL

                    -- Inter-state: IGST
                    SELECT 
                        'IGST' AS TaxType,
                        SUM(DD.Quantity * DD.CostPrice) AS Taxable,
                        (CASE WHEN DD.CostPrice > PT.Val THEN PT.Mx ELSE PT.Mn END) AS TaxPerc
                    FROM DeliveryMaster DM
                    JOIN DeliveryDetails DD ON DM.Id = DD.Id 
                        AND DM.DeliveryCode = @DeliveryCode
                    JOIN ProductAttributes PA ON PA.PluId = DD.PluID
                    JOIN ProductTax PT ON PT.DeptId = PA.DeptId AND PT.CatId = PA.CatId AND PT.MatId = PA.MaterialId
                    AND PT.IsUpdated = @TaxVersion
                    JOIN Shops S1 ON S1.ShopID = DM.DeliveryFrom
                    JOIN Shops S2 ON S2.ShopID = DM.DeliveryTo
                    WHERE S1.State <> S2.State
                    GROUP BY S1.State, S2.State, DD.CostPrice, PT.Val, PT.Mx, PT.Mn
                ) AS SUB
                GROUP BY TaxType, TaxPerc"

                Using cmd As New SqlCommand(SQL, nCon)
                    cmd.Parameters.AddWithValue("@TaxVersion", TaxVersion)
                    cmd.Parameters.AddWithValue("@DeliveryCode", DeliveryCode)
                    Using Adp As New SqlDataAdapter(cmd)
                        Dim Tbl As New DataTable()
                        Adp.Fill(Tbl)
                        ' Verify if subreports exist
                        If InvoiceRpt.Subreports.Count > 0 Then
                            Dim subRpt = InvoiceRpt.Subreports("TaxBreakup")
                            If subRpt IsNot Nothing Then
                                subRpt.SetDataSource(Tbl)
                            Else
                                MsgBox("Subreport 'TaxBreakup' not found.")
                            End If
                        Else
                            MsgBox("No subreports found in the main report.")
                        End If
                    End Using
                End Using

                ' Fetch main invoice data
                SQL = "SELECT Description, HSN, Pcs, Rate, [Dis%], [GST%] FROM (SELECT DM.DeliveryCode,A.Category [Description],    
                    T.HSN, SUM(DD.Quantity) Pcs, DD.CostPrice [Rate], 0 [Dis%],        
                    CASE WHEN DD.CostPrice > T.Val    
                    THEN T.Mx    
                    ELSE T.Mn    
                    END AS [GST%]   
                    FROM DeliveryMaster DM    
                    INNER JOIN DeliveryDetails DD ON DM.Id = DD.Id       
                    INNER JOIN ProductAttributes A ON A.PluId = DD.PluID    
                    INNER JOIN ProductTax T ON T.DeptId = A.DeptId AND T.CatId = A.CatId AND     
                    T.MatId = A.MaterialId AND T.IsUpdated = @TaxVersion   
                    WHERE DM.DeliveryCode = @DeliveryCode
                    GROUP BY DM.DeliveryCode, A.Category, T.HSN, DD.CostPrice, T.Val, T.Mx, T.Mn) A"
                Using cmd As New SqlCommand(SQL, nCon)
                    cmd.Parameters.AddWithValue("@TaxVersion", TaxVersion)
                    cmd.Parameters.AddWithValue("@DeliveryCode", DeliveryCode)
                    Using Adp As New SqlDataAdapter(cmd)
                        Dim Tbl As New DataTable()
                        Adp.Fill(Tbl)
                        InvoiceRpt.SetDataSource(Tbl)
                        InvoiceRpt.SetParameterValue("FromCompanyName", fromShopName)
                        InvoiceRpt.SetParameterValue("FromCompanyAddress", fromShopAddress)
                        InvoiceRpt.SetParameterValue("FromCompanyGST", "GSTIN : " + fromShopGst)
                        InvoiceRpt.SetParameterValue("FromCompanyMobile", "Mobile : " + fromShopMobile)
                        InvoiceRpt.SetParameterValue("ToCompanyName", toShopName)
                        InvoiceRpt.SetParameterValue("ToCompanyAddress", toShopAddress)
                        InvoiceRpt.SetParameterValue("ToCompanyGST", "GSTIN : " + toShopGst)
                        InvoiceRpt.SetParameterValue("ToCompanyMobile", "Mobile : " + toShopMobile)
                        InvoiceRpt.SetParameterValue("InvNo", invNo)
                        InvoiceRpt.SetParameterValue("InvDate", invDt)
                        CRpt.ReportSource = InvoiceRpt
                    End Using
                End Using

            Catch ex As SqlException
                MsgBox($"SQL Error: {ex.Message}", MsgBoxStyle.Critical)
            Catch ex As Exception
                MsgBox($"Unexpected Error: {ex.Message}", MsgBoxStyle.Critical)
            Finally
                If nCon.State = ConnectionState.Open Then nCon.Close()
            End Try
        End Using
    End Sub


    Private Sub GenerateTransferReceipt(DeliveryCode As String)

        Dim TransferRpt As New BranchTransfer

        Using nCon As New SqlConnection(ConStr)
            Try
                nCon.Open()

                Dim fromShopName, fromShopAddress, fromShopGst, fromShopMobile As String
                Dim toShopName, toShopAddress, toShopGst, toShopMobile As String
                Dim invNo, invDt As String

                ' Fetch header details
                SQL = "SELECT DM.DeliveryCode, DM.DeliveryDate, 
                   S1.Alias [FCName], S1.Address1 + ' ' + S1.Address2 + ' ' + S1.City + ', ' + S1.State [FCAddress], S1.Phone [FCPhone], S1.CST [FCGst],
                   S2.Alias [TCName], S2.Address1 + S2.Address2 + S2.City + ',' + S2.State [TCAddress],S2.Phone [TCPhone], S2.CST [TCGst]
                   FROM DeliveryMaster DM
                   INNER JOIN Shops S1 ON DM.DeliveryFrom = S1.ShopID
                   INNER JOIN Shops S2 ON DM.DeliveryTo = S2.ShopID
                   WHERE DM.DeliveryCode = @DeliveryCode"

                Using cmd As New SqlCommand(SQL, nCon)
                    cmd.Parameters.AddWithValue("@DeliveryCode", DeliveryCode)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            fromShopName = reader("FCName").ToString()
                            fromShopAddress = reader("FCAddress").ToString()
                            fromShopGst = reader("FCGst").ToString()
                            fromShopMobile = reader("FCPhone").ToString()
                            toShopName = reader("TCName").ToString()
                            toShopAddress = reader("TCAddress").ToString()
                            toShopGst = reader("TCGst").ToString()
                            toShopMobile = reader("TCPhone").ToString()
                            invNo = reader("DeliveryCode").ToString()
                            invDt = Format(reader("DeliveryDate"), "dd-MM-yyyy")
                        End If
                    End Using
                End Using

                ' Fetch tax data for subreport
                SQL = "SELECT 
                    TaxType,
                    SUM(Taxable) AS Taxable,
                    TaxPerc
                FROM
                (
                    -- Intra-state: CGST
                    SELECT 
                        'CGST' AS TaxType,
                        SUM(DD.Quantity * DD.CostPrice) AS Taxable,
                        (CASE WHEN DD.CostPrice > PT.Val THEN PT.Mx ELSE PT.Mn END) / 2 AS TaxPerc
                    FROM DeliveryMaster DM
                    JOIN DeliveryDetails DD ON DM.Id = DD.Id 
                        AND DM.DeliveryCode = @DeliveryCode
                    JOIN ProductAttributes PA ON PA.PluId = DD.PluID
                    JOIN ProductTax PT ON PT.DeptId = PA.DeptId AND PT.CatId = PA.CatId AND PT.MatId = PA.MaterialId
                    AND PT.IsUpdated = @TaxVersion
                    JOIN Shops S1 ON S1.ShopID = DM.DeliveryFrom
                    JOIN Shops S2 ON S2.ShopID = DM.DeliveryTo
                    WHERE S1.State = S2.State
                    GROUP BY S1.State, S2.State, DD.CostPrice, PT.Val, PT.Mx, PT.Mn

                    UNION ALL

                    -- Intra-state: SGST
                    SELECT 
                        'SGST' AS TaxType,
                        SUM(DD.Quantity * DD.CostPrice) AS Taxable,
                        (CASE WHEN DD.CostPrice > PT.Val THEN PT.Mx ELSE PT.Mn END) / 2 AS TaxPerc
                    FROM DeliveryMaster DM
                    JOIN DeliveryDetails DD ON DM.Id = DD.Id 
                        AND DM.DeliveryCode = @DeliveryCode
                    JOIN ProductAttributes PA ON PA.PluId = DD.PluID
                    JOIN ProductTax PT ON PT.DeptId = PA.DeptId AND PT.CatId = PA.CatId AND PT.MatId = PA.MaterialId
                    AND PT.IsUpdated = @TaxVersion
                    JOIN Shops S1 ON S1.ShopID = DM.DeliveryFrom
                    JOIN Shops S2 ON S2.ShopID = DM.DeliveryTo
                    WHERE S1.State = S2.State
                    GROUP BY S1.State, S2.State, DD.CostPrice, PT.Val, PT.Mx, PT.Mn

                    UNION ALL

                    -- Inter-state: IGST
                    SELECT 
                        'IGST' AS TaxType,
                        SUM(DD.Quantity * DD.CostPrice) AS Taxable,
                        (CASE WHEN DD.CostPrice > PT.Val THEN PT.Mx ELSE PT.Mn END) AS TaxPerc
                    FROM DeliveryMaster DM
                    JOIN DeliveryDetails DD ON DM.Id = DD.Id 
                        AND DM.DeliveryCode = @DeliveryCode
                    JOIN ProductAttributes PA ON PA.PluId = DD.PluID
                    JOIN ProductTax PT ON PT.DeptId = PA.DeptId AND PT.CatId = PA.CatId AND PT.MatId = PA.MaterialId
                    AND PT.IsUpdated = @TaxVersion
                    JOIN Shops S1 ON S1.ShopID = DM.DeliveryFrom
                    JOIN Shops S2 ON S2.ShopID = DM.DeliveryTo
                    WHERE S1.State <> S2.State
                    GROUP BY S1.State, S2.State, DD.CostPrice, PT.Val, PT.Mx, PT.Mn
                ) AS SUB
                GROUP BY TaxType, TaxPerc"

                Using cmd As New SqlCommand(SQL, nCon)
                    cmd.Parameters.AddWithValue("@TaxVersion", TaxVersion)
                    cmd.Parameters.AddWithValue("@DeliveryCode", DeliveryCode)
                    Using Adp As New SqlDataAdapter(cmd)
                        Dim Tbl As New DataTable()
                        Adp.Fill(Tbl)
                        ' Verify if subreports exist
                        If TransferRpt.Subreports.Count > 0 Then
                            Dim subRpt = TransferRpt.Subreports("TaxBreakup")
                            If subRpt IsNot Nothing Then
                                subRpt.SetDataSource(Tbl)
                            Else
                                MsgBox("Subreport 'TaxBreakup' not found.")
                            End If
                        Else
                            MsgBox("No subreports found in the main report.")
                        End If
                    End Using
                End Using

                ' Fetch main invoice data
                SQL = "SELECT Description, HSN, Pcs, Rate, [Dis%], [GST%] FROM (SELECT DM.DeliveryCode,A.Category [Description],    
                    T.HSN, SUM(DD.Quantity) Pcs, DD.CostPrice [Rate], 0 [Dis%],        
                    CASE WHEN DD.CostPrice > T.Val    
                    THEN T.Mx    
                    ELSE T.Mn    
                    END AS [GST%]   
                    FROM DeliveryMaster DM    
                    INNER JOIN DeliveryDetails DD ON DM.Id = DD.Id       
                    INNER JOIN ProductAttributes A ON A.PluId = DD.PluID    
                    INNER JOIN ProductTax T ON T.DeptId = A.DeptId AND T.CatId = A.CatId AND     
                    T.MatId = A.MaterialId AND T.IsUpdated = @TaxVersion   
                    WHERE DM.DeliveryCode = @DeliveryCode
                    GROUP BY DM.DeliveryCode, A.Category, T.HSN, DD.CostPrice, T.Val, T.Mx, T.Mn) A"
                Using cmd As New SqlCommand(SQL, nCon)
                    cmd.Parameters.AddWithValue("@TaxVersion", TaxVersion)
                    cmd.Parameters.AddWithValue("@DeliveryCode", DeliveryCode)
                    Using Adp As New SqlDataAdapter(cmd)
                        Dim Tbl As New DataTable()
                        Adp.Fill(Tbl)
                        TransferRpt.SetDataSource(Tbl)
                        TransferRpt.SetParameterValue("FromCompanyName", fromShopName)
                        TransferRpt.SetParameterValue("FromCompanyAddress", fromShopAddress)
                        TransferRpt.SetParameterValue("FromCompanyGST", "GSTIN : " + fromShopGst)
                        TransferRpt.SetParameterValue("FromCompanyMobile", "Mobile : " + fromShopMobile)
                        TransferRpt.SetParameterValue("ToCompanyName", toShopName)
                        TransferRpt.SetParameterValue("ToCompanyAddress", toShopAddress)
                        TransferRpt.SetParameterValue("ToCompanyGST", "GSTIN : " + toShopGst)
                        TransferRpt.SetParameterValue("ToCompanyMobile", "Mobile : " + toShopMobile)
                        TransferRpt.SetParameterValue("InvNo", invNo)
                        TransferRpt.SetParameterValue("InvDate", invDt)
                        CRpt.ReportSource = TransferRpt
                    End Using
                End Using

            Catch ex As SqlException
                MsgBox($"SQL Error: {ex.Message}", MsgBoxStyle.Critical)
            Catch ex As Exception
                MsgBox($"Unexpected Error: {ex.Message}", MsgBoxStyle.Critical)
            Finally
                If nCon.State = ConnectionState.Open Then nCon.Close()
            End Try
        End Using
    End Sub

End Class