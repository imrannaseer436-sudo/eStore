'*********************************************** Bismillah ****************************************
Public Class Users

    Private UID As SByte
    Private Edit As Boolean = False

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click

        If txtUsername.Text.Trim = "" Then
            'TTip.Show("Username should not be empty..!", txtUsername, 0, 25, 2000)
            xMessage.ShowMsg("  Username should not be empty..!", False, frmMainScreen, 0, xMessage.MsgStyle.iError)
            txtUsername.Focus()
            Exit Sub
        ElseIf ESSA.ISFound("select userid from users where username='" & txtUsername.Text.Trim & "'" & IIf(Edit = True, " and userid<>" & UserID, "")) = True Then
            'TTip.Show("Username already exists..!", txtUsername, 0, 25, 2000)
            xMessage.ShowMsg("  Username already exists..!", False, frmMainScreen, 0, xMessage.MsgStyle.iError)
            txtUsername.SelectAll()
            txtUsername.Focus()
            Exit Sub
        ElseIf txtPassword.Text <> txtRtype.Text Then
            'TTip.Show("Mismatch retype password..!", txtRtype, 0, 25, 2000)
            xMessage.ShowMsg("  Mismatch retype password..!", False, frmMainScreen, 0, xMessage.MsgStyle.iError)
            txtRtype.Clear()
            txtRtype.Focus()
            Exit Sub
        ElseIf Not IsAdmin Then
            xMessage.ShowMsg("  Please Contact Admin..!", False, frmMainScreen, 0, xMessage.MsgStyle.iError)
            Exit Sub
        End If

        If xMessage.ShowMsg("Do you want to save..?", True, frmMainScreen, 0, xMessage.MsgStyle.Question) = False Then Exit Sub

        ESSA.OpenConnection()
        Dim Cmd = Con.CreateCommand
        Dim Trn = Con.BeginTransaction
        Cmd.Transaction = Trn

        Try

            If Edit = True Then
                SQL = "delete from users where userid=" & UserID
                Cmd.CommandText = SQL
                Cmd.ExecuteNonQuery()
            Else
                GenerateUserID()
            End If

            SQL = "insert into users values (" _
                & UID & ",'" _
                & txtUsername.Text.Trim & "','" _
                & ClsEncodeDecode.Encode(txtPassword.Text) & "'," _
                & IIf(rdoAdmin.Checked = True, 1, 0) & ",0,0,0,0,'" _
                & Format(Now, "yyyy-MM-dd hh:mm:ssss") & "'," _
                & ShopID & "," _
                & UserID & ")"

            Cmd.CommandText = SQL
            Cmd.ExecuteNonQuery()

            Trn.Commit()
            Con.Close()
            xMessage.ShowMsg("User details updated successfully..!", False, frmMainScreen, 0, xMessage.MsgStyle.Exclamation)
            'MsgBox("User details updated successfully..!", vbExclamation)
            RefreshForm()

        Catch ex As Exception
            Trn.Rollback()
            Con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub GenerateUserID()

        SQL = "select max(userid) from users"
        UID = ESSA.GenerateID(SQL)

    End Sub

    Private Sub RefreshForm()

        Edit = False
        txtUsername.Clear()
        txtPassword.Clear()
        txtRtype.Clear()
        txtUsername.Focus()

    End Sub

    Private Sub Users_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Close()
            Case Keys.Enter
                If Me.ActiveControl.Tag <> "1" Then
                    e.SuppressKeyPress = True
                    Me.ProcessTabKey(True)
                End If

        End Select

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If xMessage.ShowMsg("Do you want to exit..?", True, frmMainScreen, 0, xMessage.MsgStyle.iExit) = False Then Exit Sub
        MainWindowX.CloseTab(Me.Name)
        If Not MainWindowX.TabExists(Me.Name) Then
            Me.Close()
        End If

    End Sub

End Class