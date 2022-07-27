Imports System.Data.SqlClient
Imports System.Configuration



Public Class Form1


    Dim table1 As New DataTable

        Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim conn As New DBConnection

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        con = New SqlConnection
        con.ConnectionString = ("Data Source=LAPTOP-DCJ10BPM;Initial Catalog=Egg;Integrated Security=True")
        Dim reader As SqlDataReader
        Try
            con.Open()
            Dim getDate As Date = Date.Now
            Dim addDate As String = getDate.ToString(" yyyy-MM-dd ")
            Dim query As String
            query = "INSERT into egg values ('" & 1 & "','" & TextSANo.Text & "','" & addDate & "','" & ComboCompany.Text & "','" & ComboLocation.Text & "','" & TextRemark.Text & "','" & ComboEggCategory.Text & "','" & TextQty.Text & "')"
            cmd = New SqlCommand(query, con)
            reader = cmd.ExecuteReader
            MsgBox("Department added successfully")

            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            TextSANo.Text = String.Empty
            ComboCompany.Text = String.Empty
            ComboLocation.Text = String.Empty
            TextRemark.Text = String.Empty
            ComboEggCategory.Text = String.Empty
            TextQty.Text = String.Empty

            con.Dispose()
        End Try
    End Sub




    Private Sub data()
            Dim query As String = "SELECT * FROM egg"
            Using connection As SqlConnection = New SqlConnection("Data Source=LAPTOP-DCJ10BPM;Initial Catalog=Egg;Integrated Security=True")
                Using cmd As SqlCommand = New SqlCommand(query, connection)
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

    'GridView Form------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        table1.Columns.Add("SA No", Type.GetType("System.Int32"))
        table1.Columns.Add("Company", Type.GetType("System.String"))
        table1.Columns.Add("Location", Type.GetType("System.String"))
        table1.Columns.Add("Date", Type.GetType("System.String"))
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
            table1.Rows.Add(Nothing, ComboCompany.Text.Trim, ComboLocation.Text.Trim, dpt.Value, TextRemark.Text.Trim, ComboEggCategory.Text.Trim, TextQty.Text.Trim)
            DataGridView1.DataSource = table1
        End Sub

        'To Close Btn
        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnExit.Click
            Me.Close()
        End Sub



        Private Sub Form1_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged
            Dim query As String = "SELECT * FROM egg WHERE FIRST"
        End Sub


        'New Button-------------------
        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            TextSANo.Text = ""
            TextRemark.Text = ""
            TextQty.Text = ""
            ComboCompany.Text = ""
            ComboLocation.Text = ""
            ComboEggCategory.Text = ""
        End Sub


        'Date Button-------------------
        Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
            Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
            dpt.Text = todaysdate
        End Sub

   
End Class

