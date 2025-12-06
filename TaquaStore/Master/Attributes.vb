Imports System.Data.SqlClient

Public Class Attributes

    Private tableTypes As New DataTable

    Private Sub Attributes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CreateAttributesTypes()
        LoadAttributeTypes()

    End Sub

    Private Sub CreateAttributesTypes()

        'Create columns

        tableTypes.Columns.Add("Id", GetType(Byte))
        tableTypes.Columns.Add("Name", GetType(String))
        tableTypes.Columns.Add("FieldName", GetType(String))
        tableTypes.Columns.Add("TableName", GetType(String))
        tableTypes.Columns.Add("FieldDesc", GetType(String))

        'Insert data

        With tableTypes
            .Rows.Add({0, "Brand", "BrandId", "TSBrand", "Brand"})
            .Rows.Add({1, "Catalog", "CatalogId", "TSCatalog", "Catalog"})
            .Rows.Add({2, "Category", "CatId", "TSCategory", "Category"})
            .Rows.Add({3, "Department", "DeptId", "TSDepartment", "Department"})
            .Rows.Add({4, "Material", "MaterialId", "TSMaterial", "Material"})
            .Rows.Add({5, "Pattern", "PatternId", "TSPattern", "Pattern"})
            .Rows.Add({6, "Sleeve", "SleeveId", "TSSleeve", "Sleeve"})
            .Rows.Add({7, "Style", "StyleId", "TSStyle", "Style"})
            .Rows.Add({8, "Type", "TypeId", "TSType", "Type"})
        End With

    End Sub

    Private Sub LoadAttributeTypes()

        cmbGroup.DataSource = tableTypes
        cmbGroup.DisplayMember = "Name"
        cmbGroup.ValueMember = "Id"

    End Sub

    Private attributeId As Short = 0
    Private attributeName As String = ""
    Private isActive As Byte = 1

    Private fieldName As String = ""
    Private fieldDesc As String = ""
    Private tableName As String = ""

    Private Function AddAttribute() As Boolean

        AddAttribute = True

        SQL = "Select MAX(" & fieldName & ") FROM " & tableName
        attributeId = ESSA.GenerateID(SQL)
        attributeName = txtName.Text.Trim

        SQL = "INSERT INTO {0} VALUES (" _
            & attributeId & ",'" _
            & attributeName & "'," _
            & isActive & "," _
            & UserID & ")"

        Try

            Using nCon As New SqlConnection(ConStr)
                nCon.Open()
                Using Cmd As New SqlCommand(String.Format(SQL, tableName), nCon)
                    Cmd.ExecuteNonQuery()
                End Using
                nCon.Close()
            End Using

        Catch ex As SqlException
            AddAttribute = False
            If ex.Message.Contains("duplicate") Then
                MsgBox(cmbGroup.Text & " name already exists..!", MsgBoxStyle.Critical)
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If
        End Try

    End Function

    Private Function UpdateAttribute() As Boolean

        UpdateAttribute = True

        SQL = "UPDATE {0} SET {1} = '{2}', IsActive = {3} " _
            & "WHERE {4} = {5}"

        SQL = String.Format(SQL,
                            tableName,
                            fieldDesc,
                            txtEdit.Text.Trim,
                            IIf(chkActive.Checked, "1", "0"),
                            fieldName,
                            attributeId)

        Try

            Using nCon As New SqlConnection(ConStr)
                nCon.Open()
                Using Cmd As New SqlCommand(SQL, nCon)
                    Cmd.ExecuteNonQuery()
                End Using
                nCon.Close()
            End Using

        Catch ex As SqlException
            UpdateAttribute = False
            If ex.Message.Contains("duplicate") Then
                MsgBox(cmbGroup.Text & " name already exists..!", MsgBoxStyle.Critical)
            End If
        End Try

    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If txtName.Text.Trim = "" Then txtName.Focus() : Exit Sub

        If AddAttribute() Then
            UpdateDataGrid() : txtName.Clear() : txtName.Focus()
        End If

    End Sub

    Private Sub UpdateDataGrid()

        dataGrid.Rows.Add(attributeId, attributeName)

    End Sub

    Private Sub LoadDataGrid()

        SQL = "SELECT * FROM " & tableName & " ORDER BY " & fieldDesc
        dataGrid.Rows.Clear()
        With ESSA.OpenReader(SQL)
            While .Read
                dataGrid.Rows.Add(.Item(0), .GetString(1).Trim, .Item(2))
            End While
            .Close()
        End With

    End Sub

    Private Sub cmbGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGroup.SelectedIndexChanged

        If cmbGroup.SelectedIndex = -1 Then Exit Sub

        fieldName = tableTypes.Rows(cmbGroup.SelectedIndex).Item(2).ToString
        tableName = tableTypes.Rows(cmbGroup.SelectedIndex).Item(3).ToString
        fieldDesc = tableTypes.Rows(cmbGroup.SelectedIndex).Item(4).ToString

        LoadDataGrid()
        txtName.Focus()

    End Sub

    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click

        pnlEdit.Hide()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If txtEdit.Text.Trim = "" Then txtEdit.Focus() : Exit Sub

        If Not UpdateAttribute() Then
            txtEdit.Focus()
            Exit Sub
        End If

        pnlEdit.Hide()
        LoadDataGrid()

    End Sub

    Private Sub dataGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGrid.CellClick

        If e.RowIndex = -1 Then Exit Sub

        If e.ColumnIndex = 3 Then
            attributeId = Val(dataGrid.Item(0, e.RowIndex).Value)
            txtEdit.Text = Trim(dataGrid.Item(1, e.RowIndex).Value)
            chkActive.Checked = IIf(Val(dataGrid.Item(2, e.RowIndex).Value) = 1, True, False)
            pnlEdit.Show()
            txtEdit.Focus()
        End If

    End Sub

    Private Sub btnRevert_Click(sender As Object, e As EventArgs) Handles btnRevert.Click

        txtEdit.Text = Trim(dataGrid.Item(1, dataGrid.CurrentRow.Index).Value)

    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnAdd.PerformClick()
        End If

    End Sub

End Class
