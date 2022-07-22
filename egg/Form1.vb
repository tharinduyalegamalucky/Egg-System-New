Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class Form1

    'Dim con As New SqlConnection("Data Source=LAPTOP-DCJ10BPM;Initial Catalog=Egg;Integrated Security=True")
    Dim table1 As New DataTable

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim query As String = "insert into egg values(@SANo,@Company,@Location,@cudate,@Remark,@Eggcategory,@Qty)"
        Using con As SqlConnection = New SqlConnection("Data Source=LAPTOP-DCJ10BPM;Initial Catalog=Egg;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("SANo", TextSANo.Text)
                cmd.Parameters.AddWithValue("Company", ComboCompany.Text)
                cmd.Parameters.AddWithValue("Location", ComboLocation.Text)
                cmd.Parameters.AddWithValue("cudate", dpt.Text)
                cmd.Parameters.AddWithValue("Remark", dpt.Text)
                cmd.Parameters.AddWithValue("Eggcategory", ComboEggCategory.Text)
                cmd.Parameters.AddWithValue("Qty", TextQty.Text)

                con.Open()
                'cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        MessageBox.Show("Data Addedd")

    End Sub

    Private Sub data()
        Dim query As String = "select * from egg"
        Using con As SqlConnection = New SqlConnection("Data Source=LAPTOP-DCJ10BPM;Initial Catalog=Egg;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Function getDataLists(selectQuery As String) As Object
        Throw New NotImplementedException()
    End Function

    Private Sub ExecuteQuery(addQuery As String)
        Throw New NotImplementedException()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        table1.Columns.Add("SA No", Type.GetType("System.Int32"))
        table1.Columns.Add("Company", Type.GetType("System.String"))
        table1.Columns.Add("Location", Type.GetType("System.String"))
        table1.Columns.Add("Remark", Type.GetType("System.String"))
        table1.Columns.Add("Egg Category", Type.GetType("System.String"))
        table1.Columns.Add("Qty", Type.GetType("System.String"))

        DataGridView1.DataSource = table1

        If con.State = ConnectionState.Open Then
            con.Close()
        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        table1.Columns("SA No").AutoIncrement = True
        table1.Columns("SA No").AutoIncrementSeed = 1
        table1.Columns("SA No").AutoIncrementStep = 1
        table1.Rows.Add(Nothing, ComboCompany.Text.Trim, ComboLocation.Text.Trim, TextRemark.Text.Trim, ComboEggCategory.Text.Trim, TextQty.Text.Trim)
        DataGridView1.DataSource = table1
    End Sub

    'To Close Btn
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub



    Private Sub Form1_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged
        Dim query As String = "SELECT * FROM egg WHERE FIRST"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextSANo.Text = ""
        TextRemark.Text = ""
        TextQty.Text = ""
        ComboCompany.Text = ""
        ComboLocation.Text = ""
        ComboEggCategory.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles dpt.TextChanged
        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        dpt.Text = todaysdate
    End Sub
End Class
