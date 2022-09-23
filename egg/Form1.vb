Imports System.Data.SqlClient
Imports DAL

Public Class Form1
    Dim DT As DataTable
    Dim DS As DataSet
    Dim query As String
    Dim con As New SqlConnection

    Public DAL_Obj As New DAL.DBAccess
    Public Property SaveButtonDetails As Object




    'Egg Category Details---------
    'Combo Company Loading Details--------
    'DAL Connection------
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DAL_Obj.Connect("CNG-5", "Eggs")

        '' egg category load ------

        ' Dim SqlStrings As String

        DS = DAL_Obj.GetExcTo_DataSet("Egg_cat", Nothing)

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            ComboEggCategory.Items.Add(DS.Tables(0).Rows(i).Item(1).ToString)
            ComboEggCategory.AutoCompleteCustomSource.Add(DS.Tables(0).Rows(i).Item(0).ToString)
        Next

        ''''' combo load'''
        ' Dim SqlString As String

        DS = DAL_Obj.GetExcTo_DataSet("Com_Details", Nothing)

        For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
            ComboCompany.Items.Add(DS.Tables(0).Rows(i).Item(1).ToString)
            ComboCompany.AutoCompleteCustomSource.Add(DS.Tables(0).Rows(i).Item(0).ToString)
        Next


    End Sub


    'Comapany Category---------
    Private Sub ComboCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCompany.SelectedIndexChanged

        If ComboCompany.SelectedIndex <> -1 Then
            lbl_com_id.Text = ComboCompany.AutoCompleteCustomSource(ComboCompany.SelectedIndex)
            ComboLocation.Items.Clear()
            Lbl_Loc_Id.Text = ""

            Dim SQLParam() As System.Data.SqlClient.SqlParameter
            'Dim SQLComm As System.Data.SqlClient.SqlCommand

            ReDim Preserve SQLParam(0)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@COM_ID", SqlDbType.Int, lbl_com_id.Text, 10, "in")

            DS = DAL_Obj.GetExcTo_DataSet("Loc_cat", SQLParam)

            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                ComboLocation.Items.Add(DS.Tables(0).Rows(i).Item(1).ToString)
                ComboLocation.AutoCompleteCustomSource.Add(DS.Tables(0).Rows(i).Item(0).ToString)
            Next
        End If
    End Sub


    'GridView Form--------
    'Add Button ----------
    'EggCategory DataBase Details
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Message Box-------
        If TextId.Text = "" Then
            MessageBox.Show("Not Selected the User ID")
            Exit Sub
        End If

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



        If DataGridView1.Rows.Count > 0 Then
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If ComboEggCategory.Text = DataGridView1.Rows(i).Cells(0).Value Then
                    MessageBox.Show("Allready in your list")
                    Exit Sub
                End If
            Next
        End If
        Dim SQLParam() As System.Data.SqlClient.SqlParameter
        Dim SQLComm As System.Data.SqlClient.SqlCommand


        ReDim Preserve SQLParam(0)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@SA_No1", SqlDbType.Int, 0, 1, "out")
        ReDim Preserve SQLParam(1)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Cat_Id", SqlDbType.Int, Lbl_Egg_Id.Text, 10, "in")
        ReDim Preserve SQLParam(2)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Qty", SqlDbType.Int, TextQty.Text, 10, "in")
        ReDim Preserve SQLParam(3)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@User_Id", SqlDbType.Int, TextId.Text, 10, "in")

        Try
            SQLComm = DAL_Obj.GetExcTo_Cmd("addpro", SQLParam)
            TextSANo.Text = SQLComm.Parameters("@SA_No1").Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        DataGridView1.Rows.Add(ComboEggCategory.Text, TextQty.Text)




    End Sub


    'Save Btn--------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim SQLParam() As System.Data.SqlClient.SqlParameter
        Dim SQLComm As System.Data.SqlClient.SqlCommand

        ReDim Preserve SQLParam(0)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@SA_No1", SqlDbType.Int, 0, 1, "out")
        ReDim Preserve SQLParam(1)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Loc_Id", SqlDbType.Int, Lbl_Loc_Id.Text, 10, "in")
        ReDim Preserve SQLParam(2)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Com_Id", SqlDbType.Int, lbl_com_id.Text, 10, "in")
        ReDim Preserve SQLParam(3)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Remark", SqlDbType.VarChar, TextRemark.Text, 10, "in")
        ReDim Preserve SQLParam(4)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@SysDateTime", SqlDbType.DateTime, dpt.Text, 10, "in")
        ReDim Preserve SQLParam(5)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Egg_Category_Id", SqlDbType.Int, Lbl_Egg_Id.Text, 10, "in")
        ReDim Preserve SQLParam(6)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Qty", SqlDbType.Int, TextQty.Text, 10, "in")
        ReDim Preserve SQLParam(7)
        SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@User_Id", SqlDbType.Int, TextId.Text, 10, "in")

        Try
            SQLComm = DAL_Obj.GetExcTo_Cmd("insertpro", SQLParam)
            TextSANo.Text = SQLComm.Parameters("@SA_No1").Value
            MessageBox.Show("Successfully Data Addedd.....")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub



    'All Clear Details------
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboCompany.SelectedIndex = -1
        ComboLocation.SelectedIndex = -1
        ComboEggCategory.SelectedIndex = -1
        TextSANo.Text = ""
        TextId.Text = ""
        TextRemark.Text = ""
        TextQty.Text = ""
        lbl_com_id.Text = ""
        Lbl_Loc_Id.Text = ""
        Lbl_Egg_Id.Text = ""
    End Sub


    'Exit Btn----------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'Location Category---------
    Private Sub ComboLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboLocation.SelectedIndexChanged
        If ComboLocation.SelectedIndex <> -1 Then
            Lbl_Loc_Id.Text = ComboLocation.AutoCompleteCustomSource(ComboLocation.SelectedIndex)
        End If

    End Sub


    'Egg Category load--------
    Private Sub ComboEggCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboEggCategory.SelectedIndexChanged
        If ComboEggCategory.SelectedIndex <> -1 Then
            Lbl_Egg_Id.Text = ComboEggCategory.AutoCompleteCustomSource(ComboEggCategory.SelectedIndex)
        End If
    End Sub

End Class
