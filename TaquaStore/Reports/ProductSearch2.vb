Imports System.Data.SqlClient

Public Class ProductSearch2

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click

        SQL = "SELECT " _
            & "P.PluId, P.Plucode Code, P.Pluname Name, P.CostPrice [C.Price], P.RetailPrice [R.Price]," _
            & "V.VendorName [Vendor], A.Department, A.Category, A.Style, S.Stock [Stock] " _
            & "FROM ProductMaster P, Vendors V, ProductAttributes A,V_StockPOS S " _
            & "WHERE P.VendorID = V.VendorID AND P.PluID = A.PluId AND S.Pluid = P.Pluid AND S.Location_Id = " & ShopID & ""

        If txtCode.Text.Trim.Length > 0 Then
            SQL &= " AND P.Plucode LIKE '%" & txtCode.Text.Trim & "%'"
        End If

        If txtName.Text.Trim.Length > 0 Then
            SQL &= " AND P.Pluname LIKE '%" & txtName.Text.Trim & "%'"
        End If

        SQL &= " ORDER BY P.Plucode"
        TG.SuspendLayout()
        ESSA.OpenConnection()

        Using Adp As New SqlDataAdapter(SQL, Con)
            Using Tbl As New DataTable
                Adp.Fill(Tbl)
                TG.DataSource = Nothing
                TG.DataSource = Tbl
                TG.Columns(0).Visible = False
            End Using
        End Using
        Con.Close()
        TG.ResumeLayout()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        If MsgBox("Are you sure, do you want to close..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MainWindowX.CloseTab(Me.Name)

    End Sub

    Private Sub lblClearCode_Click(sender As Object, e As EventArgs) Handles lblClearCode.Click

        txtCode.Clear()
        txtCode.Focus()

    End Sub

    Private Sub lblClearName_Click(sender As Object, e As EventArgs) Handles lblClearName.Click

        txtName.Clear()
        txtName.Focus()

    End Sub

    Private Sub ProductSearch2_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        ESSA.MovetoCenter(pnlLOG, Me)

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub TG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles TG.CellContentClick

    End Sub

    Private Sub TG_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles TG.CellDoubleClick

        If e.ColumnIndex = -1 Then Exit Sub

        'SQL = "SELECT DISTINCT M.GRNNO,M.GRNDT FROM GRNMASTER M,GRNDETAILS D,PRODUCTMASTER P " _
        '    & "WHERE M.GRNNO=D.GRNNO AND D.PLUID=P.PLUID AND P.PLUCODE='" & TG.Item(0, e.RowIndex).Value & "'" _
        '    & " ORDER BY M.GRNNO,M.GRNDT"

        SQL = "SELECT DISTINCT M.GRNNO,M.GRNDT FROM GRNMASTER M,GRNDETAILS D,PRODUCTMASTER P " _
            & "WHERE M.GRNNO = D.GRNNO AND D.PLUID = P.SIZE AND P.PLUID =" & Val(TG.Item(0, e.RowIndex).Value) _
            & " ORDER BY M.GRNNO,M.GRNDT"

        With ESSA.OpenReader(SQL)
            TGGrn.Rows.Clear()
            While .Read
                TGGrn.Rows.Add()
                TGGrn.Item(0, TGGrn.Rows.Count - 1).Value = .Item(0)
                TGGrn.Item(1, TGGrn.Rows.Count - 1).Value = Format(.GetDateTime(1).Date, "dd-MM-yyyy")
            End While
            .Close()
        End With

        If TGGrn.Rows.Count > 0 Then
            pnlLOG.Visible = True
            TGGrn.Focus()
        Else
            MsgBox("No grn details found!", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click

        pnlLOG.Hide()

    End Sub

End Class