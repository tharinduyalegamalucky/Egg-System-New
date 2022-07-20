Imports System.Data.SqlClient
Imports System.Data


Public Class Form1

    Dim table1 As New DataTable
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        table1.Columns.Add("SA No", Type.GetType("System.Int32"))
        table1.Columns.Add("Company", Type.GetType("System.String"))
        table1.Columns.Add("Location", Type.GetType("System.String"))
        table1.Columns.Add("Remark", Type.GetType("System.String"))
        table1.Columns.Add("Egg Category", Type.GetType("System.String"))
        table1.Columns.Add("Qty", Type.GetType("System.String"))

        DataGridView1.DataSource = table1

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        table1.Columns("SA No").AutoIncrement = True
        table1.Columns("SA No").AutoIncrementSeed = 1
        table1.Columns("SA No").AutoIncrementStep = 1
        table1.Rows.Add(Nothing, ComboCompany.Text.Trim, ComboLocation.Text.Trim, TextRemark.Text.Trim, ComboEggCategory.Text.Trim, TextQty.Text.Trim)
        DataGridView1.DataSource = table1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=LAPTOP-DCJ10BPM;Initial Catalog=Egg;User Id=sa;Password=000000;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand("select * from Egg where SANo='" + TextSANo.Text + "' and Company='" + ComboCompany.SelectedItem.ToString() + "' and Location='" + ComboLocation.SelectedItem.ToString() + "' and cudate='" + dpt1.Text + "' and Remark='" + TextRemark.Text + "' and Eggcategory= '" + ComboEggCategory.SelectedItem.ToString() + "' and Qty='" + TextQty.Text + "'", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        MessageBox.Show("Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Form1_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged
        Dim query As String = "SELECT * FROM egg WHERE FIRST"
    End Sub
End Class
