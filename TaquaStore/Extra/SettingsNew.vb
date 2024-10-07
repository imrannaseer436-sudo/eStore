'*************************************** Bismillah ******************************************
Public Class SettingsNew

    Private Sub Settings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadSettings()

    End Sub

    Private Sub LoadSettings()

        SQL = "SELECT * FROM settings;" &
          "SELECT DISTINCT LEFT(plucode, LEN(plucode) - 6) Prefix " &
          "FROM productmaster;"

        With ESSA.OpenReader(SQL)
            ' First result set: settings table
            While .Read
                If .GetString(0) = "BarcodePrefix" Then
                    txtBarcodePrefix.Text = .GetString(1).Trim.ToUpper
                End If
            End While

            ' Move to next result set: productmaster table
            .NextResult()

            Dim Prefixes = ""
            While .Read
                Prefixes &= .Item(0) & ", "
            End While

            ' Trim the trailing comma
            If Prefixes.Length > 0 Then
                Prefixes = Prefixes.TrimEnd(", ".ToCharArray())
            End If

            txtPrevPrefix.Text = Prefixes
            .Close()
        End With

    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        If IsAdmin Then
            SQL = "update settings set param_value='" & txtBarcodePrefix.Text.Trim.ToUpper & "'" _
            & " where param_name='BarcodePrefix';"

            ESSA.Execute(SQL)
            MsgBox("Updated successfully..!", vbInformation)
        Else
            MsgBox("Contact Admin..!", vbInformation)
        End If


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub

    Private Sub lblImportTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ImportTools.Show()

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LocationSettings.Show()

    End Sub

End Class