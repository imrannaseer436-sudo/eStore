Imports System.Data.SqlClient
Imports Syncfusion.Windows.Forms.Tools

Public Class Verifier

    Private Sub LoadMultiSelectComboBox(ByVal Cmb As MultiSelectionComboBox, ByVal Qry As String, ByVal Name As String, Optional ByVal ID As String = "", Optional ByVal Header As String = "")

        Using nCon As New SqlConnection(ConStr)
            nCon.Open()
            Using Adp As New SqlDataAdapter(Qry, nCon)
                Using Tbl As New DataSet
                    Adp.Fill(Tbl)

                    If Header <> "" Then
                        Dim Tr As DataRow
                        Tr = Tbl.Tables(0).NewRow
                        Tr(Name) = Header
                        Tbl.Tables(0).Rows.InsertAt(Tr, 0)
                    End If

                    Cmb.DataSource = Tbl.Tables(0)
                    Cmb.DisplayMember = Name
                    Cmb.ValueMember = ID
                End Using
            End Using
            nCon.Close()
        End Using

    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click

        Dim list As String = Mid(CmbDeliveryCodes.Text, 1, CmbDeliveryCodes.Text.Length - 1)

        SQL = $"select dd.pluid,pm.plucode,sum(dd.quantity) quantity,0 received 
        from deliverymaster dm
        inner join deliverydetails dd on dm.id = dd.id and dm.deliverycode in ({list})
        inner join productmaster pm on pm.pluid = dd.pluid
        group by dd.pluid,pm.plucode"

        DgVerifier.Rows.Clear()
        With ESSA.OpenReader(SQL)
            While .Read
                Dim row = DgVerifier.Rows.Add
                DgVerifier.Item(0, row).Value = .Item("pluid")
                DgVerifier.Item(1, row).Value = .Item("plucode")
                DgVerifier.Item(2, row).Value = .Item("quantity")
                DgVerifier.Item(3, row).Value = .Item("received")
                DgVerifier.Item(4, row).Value = .Item("quantity")
            End While
            .Close()
        End With
        CalculateVariation()
        TxtCode.Focus()

    End Sub

    Private Sub CalculateVariation()

        For i As Integer = 0 To DgVerifier.Rows.Count - 1

            DgVerifier.Item(4, i).Value = Val(DgVerifier.Item(2, i).Value) - Val(DgVerifier.Item(3, i).Value)

            If Val(DgVerifier.Item(4, i).Value) <> 0 Then
                DgVerifier.Item(4, i).Style.BackColor = Color.Crimson
                DgVerifier.Item(4, i).Style.ForeColor = Color.White
            Else
                DgVerifier.Item(4, i).Style.BackColor = Color.White
                DgVerifier.Item(4, i).Style.ForeColor = Color.Black
            End If

        Next

    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown

        If e.KeyCode = Keys.Enter Then

            If TxtCode.Text = String.Empty Then Exit Sub
            If DgVerifier.Rows.Count = 0 Then Exit Sub
            Dim rowIndex = ESSA.FindGridIndex(DgVerifier, 1, TxtCode.Text.Trim)
            If rowIndex = -1 Then
                MsgBox("Code not found", MsgBoxStyle.Critical)
                Exit Sub
            End If
            DgVerifier.Item(3, rowIndex).Value += 1
            CalculateVariation()
            TxtCode.Clear()
            TxtCode.Focus()

        End If

    End Sub

    Private Sub DgVerifier_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgVerifier.CellEndEdit

        CalculateVariation()

    End Sub

    Private Sub Verifier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQL = $"select id,'''' + deliverycode + '''' deliverycode 
        from deliverymaster 
        where deliveryto = {ShopID} and status = 0
        order by deliverycode"

        LoadMultiSelectComboBox(CmbDeliveryCodes, SQL, "deliverycode", "id")

    End Sub

    Private Sub Verifier_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If MessageBox.Show("Are you sure you want to close the form?", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            ' Cancel the Closing event
            e.Cancel = True
        End If

    End Sub

    Private Async Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        If DgVerifier.Rows.Count = 0 Then Exit Sub

        Dim id = Val(InputBox("Please enter id"))
        If id <= 0 Then Exit Sub
        Dim executed As Boolean

        SQL = $"delete from verify_details where id = {id}"
        ESSA.Execute(SQL)

        For i As Integer = 0 To DgVerifier.Rows.Count - 1

            SQL = $"insert into verify_details values (
            {id},
            {DgVerifier.Item(0, i).Value},
            {DgVerifier.Item(3, i).Value})"

            executed = Await ESSA.ExecuteAsync(SQL)

        Next

        If executed Then
            MsgBox("Saved", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub BtnFetch_Click(sender As Object, e As EventArgs) Handles BtnFetch.Click

        If DgVerifier.Rows.Count = 0 Then Exit Sub
        Dim Id = Val(InputBox("Enter Id"))

        SQL = $"select * 
        from verify_details where id = {Id}"

        With ESSA.OpenReader(SQL)

            While .Read

                Dim NRI As Integer = ESSA.FindGridIndex(DgVerifier, 0, .Item(1))
                If NRI <> -1 Then
                    DgVerifier.Item(3, NRI).Value = .Item(2)
                End If

            End While
            .Close()
        End With

        CalculateVariation()

    End Sub

End Class