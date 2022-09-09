Imports System.Data.SqlClient
Imports egg.DBConnection



Public Class Form1

    Dim table1 As New DataTable
    Dim con As New SqlConnection
    Dim query As String
    Dim DT As DataTable
    Dim DS As DataRow


    'DataGridView Details-----
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConnection.connect()

        ' egg category load ------
        Dim SqlStrings As String
        SqlStrings = "SELECT [Cat_Id],[Cat_Name],[SysDateTime] FROM [dbo].[Egg Category Tbl]"
        DT = DBConnection.GenerateResultSet(SqlStrings)
        For i As Integer = 0 To DT.Rows.Count - 1
            'MessageBox.Show(DT.Rows(i).Item(0).ToString)
            ComboEggCategory.Items.Add(DT.Rows(i).Item(1).ToString)
            ComboEggCategory.AutoCompleteCustomSource.Add(DT.Rows(i).Item(0).ToString)
        Next

        '''' combo load'''
        Dim SqlString As String
        SqlString = "SELECT [com_id],[com_name],[SysDateTime] FROM [dbo].[Company Tbl]"
        DT = DBConnection.GenerateResultSet(SqlString)
        For i As Integer = 0 To DT.Rows.Count - 1
            ComboCompany.Items.Add(DT.Rows(i).Item(1).ToString)
            ComboCompany.AutoCompleteCustomSource.Add(DT.Rows(i).Item(0).ToString)
        Next


    End Sub

    Private Sub ComboCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCompany.SelectedIndexChanged

        If ComboCompany.SelectedIndex <> -1 Then
            ComboLocation.Items.Clear()
            Dim SqlString As String
            SqlString = "SELECT [Loc_id],[Loc_Name],[SysDateTime],[com_id] FROM [dbo].[Location Tbl] WHERE com_id ='" + ComboCompany.AutoCompleteCustomSource(ComboCompany.SelectedIndex) + "'   "
            DT = DBConnection.GenerateResultSet(SqlString)
            For i As Integer = 0 To DT.Rows.Count - 1
                'MessageBox.Show(DT.Rows(i).Item(0).ToString)
                ComboLocation.Items.Add(DT.Rows(i).Item(1).ToString)
                ComboLocation.AutoCompleteCustomSource.Add(DT.Rows(i).Item(0).ToString)
            Next
        End If


    End Sub


    'save button
    'Insert,Save Query
    'Date & DataBase Query
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim getDate As Date = Date.Now
        Dim addDate As String = getDate.ToString(" yyyy-MM-dd ")
        query = "INSERT into Stock Header Tbl values ((Select ISNULL(MAX(SA_No)+1,1) From Stock Header Tbl),'" & ComboLocation.Text & "','" & ComboCompany.Text & "','" & TextRemark.Text & "','" & addDate & "')"
        If (DBConnection.ExecuteSql(query)) Then
            MsgBox("Save To Details")
        End If
    End Sub

    'GridView Form--------
    'Add Button ----------
    'EggCategory DataBase Details
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ' Message Box-------
        If ComboCompany.Text = "" Then
            MessageBox.Show("Not Selected the Company")
            Exit Sub
        End If

        If ComboLocation.Text = "" Then
            MessageBox.Show("Not Selected the Company Location")
            Exit Sub
        End If

        If TextRemark.Text = "" Then
            MessageBox.Show("Not Completed the Remark ")
            Exit Sub
        End If

        If ComboEggCategory.Text = "" Then
            MessageBox.Show("Not Selected the Egg Category")
            Exit Sub
        End If

        If TextQty.Text = "" Then
            MessageBox.Show("Qty Can't be 0 or blank")
            Exit Sub
        End If

        DataGridView1.Rows.Add(ComboEggCategory.Text, TextQty.Text)

        query = "INSERT INTO [dbo].[Stock Details Tbl] VALUES ( '" & ComboEggCategory.Text & "', '" & TextQty.Text & "')"
        If (DBConnection.ExecuteSql(query)) Then
        End If
    End Sub

    'To Close Btn
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    'New Button----------
    'Clear to All Details
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Clear ------

        ComboCompany.SelectedIndex = -1
        ComboLocation.SelectedIndex = -1
        ComboEggCategory.SelectedIndex = -1
        TextSANo.Text = ""
        TextRemark.Text = ""
        TextQty.Text = ""
    End Sub



End Class

