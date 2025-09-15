'********************************************** Bismillah ***************************************
Imports System.Data.SqlClient
Imports System.Xml
Public Class Login

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        SQL = "select userid,username,isadmin from users where username='" _
            & txtUser.Text.Trim & "' and password='" & ClsEncodeDecode.Encode(txtPass.Text) & "'"

        With ESSA.OpenReader(SQL)
            If .Read Then
                UserID = .Item(0)
                UserName = .GetString(1).Trim
                IsAdmin = IIf(.Item(2) = 0, False, True)
                MainWindowX.Show()
                Me.Close()
            Else
                TTip.Show("Incorrect username or password..!", txtPass, 0, 25, 2000)
                txtPass.Clear()
                txtPass.Focus()
                Exit Sub
            End If

            .Close()

        End With

        LoadSettings()

    End Sub

    Private Sub LoadSettings()

        SQL = "select * from settings"
        With ESSA.OpenReader(SQL)
            While .Read
                If .GetString(0) = "LableFormat" Then
                    BarcodeFormat = .GetString(1).Trim
                ElseIf .GetString(0) = "BarcodeFileLocation" Then
                    BarcodeFileLocation = .GetString(1).Trim
                ElseIf .GetString(0) = "BarcodeBatchLocation" Then
                    BarcodeBatchLocation = .GetString(1).Trim
                ElseIf .GetString(0) = "POSPrinterName" Then
                    POSPrinterName = .GetString(1).Trim
                ElseIf .GetString(0) = "ExportFileLocation" Then
                    ExportFileLocation = .GetString(1).Trim
                ElseIf .GetString(0) = "BeginDate" Then
                    SDate = CDate(.GetString(1)).Date
                ElseIf .GetString(0) = "EndDate" Then
                    EDate = CDate(.GetString(1)).Date
                ElseIf .GetString(0) = "TaxVersion" Then
                    TaxVersion = CShort(.GetString(1))
                    'Using IsUpdated column for tax revisions
                End If
            End While
            .Close()
        End With

    End Sub

    Private Sub txtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtPass.Focus()
        End If

    End Sub

    Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If

    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblVer.Text = "Build Version " & My.Application.AppVersion

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\StoreSettings.xml") = True Then

            Dim xDoc As XmlReader = XmlReader.Create(My.Application.Info.DirectoryPath & "\StoreSettings.xml")
            While xDoc.Read
                If xDoc.Name = "DBSettings" Then
                    ConStr = ClsEncodeDecode.DCode(xDoc.ReadElementString("DBSettings"))
                ElseIf xDoc.Name = "ShopCode" Then
                    ShopCode = xDoc.ReadElementString("ShopCode")
                End If
            End While
            xDoc.Close()

            If ConStr.Trim.Length > 0 Then
                SQL = "select count(*) from users"
                Dim Tmp = ESSA.GenerateID(SQL)
                If Tmp = 1 Then
                    btnNewUser.Visible = True
                End If
                SQL = "select count(*) from shops"
                Tmp = ESSA.GenerateID(SQL)
                If Tmp = 1 Then
                    BtnLocation.Visible = True
                End If
            End If

        Else

            DatabaseSettings.Show()
            Me.Close()

        End If

    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click

        DatabaseSettings.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ImportTools.Show()

    End Sub

    Private Sub btnNewUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUser.Click

        SQL = "select max(userid) from users"

        If ESSA.GenerateID(SQL) = 1 Then

            Users.Show()
            Me.Close()

        Else

            MsgBox("Access Denied..!", vbCritical)

        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles BtnLocation.Click

        SQL = "select max(shopid) from shops"

        If ESSA.GenerateID(SQL) = 1 Then

            Shop.Show()
            Me.Close()

        Else

            MsgBox("Access Denied..!", vbCritical)

        End If

    End Sub
End Class