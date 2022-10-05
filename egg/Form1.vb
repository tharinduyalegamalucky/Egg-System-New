Imports System.Data.SqlClient
Imports DAL

Public Class Form2
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

        ' combo load-----------

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

        DataGridView1.Rows.Add(ComboEggCategory.Text, Lbl_Egg_Id.Text, TextQty.Text)

    End Sub

    'Save Btn--------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        DAL_Obj.BeginTran()

        If (Save_HEADER(lbl_com_id.Text, Lbl_Loc_Id.Text, TextRemark.Text, TextId.Text, dpt.Text)) = False Then
            DAL_Obj.RollbackTran()
            MsgBox("record not saved")
            Exit Sub
        End If

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(1).Value <> "" Then
                If (Save_detals(TextSANo.Text, DataGridView1.Rows(i).Cells(1).Value, DataGridView1.Rows(i).Cells(2).Value)) = False Then
                    DAL_Obj.RollbackTran()
                    MsgBox("record not saved")
                    Exit Sub
                End If
            End If


        Next

        MsgBox("record saved")


        DAL_Obj.CommitTran()

    End Sub
    Public Function Save_HEADER(ByVal com_id As Integer, ByVal loc_id As Integer, ByVal remark As String, ByVal user_id As Integer, ByVal dateD As String) As Boolean
        Try


            Dim SQLParam() As System.Data.SqlClient.SqlParameter
            Dim SQLComm As System.Data.SqlClient.SqlCommand

            ReDim Preserve SQLParam(0)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@SA_No1", SqlDbType.Int, 0, 1, "out")
            ReDim Preserve SQLParam(1)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Loc_Id", SqlDbType.Int, loc_id, 10, "in")
            ReDim Preserve SQLParam(2)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Com_Id", SqlDbType.Int, com_id, 10, "in")
            ReDim Preserve SQLParam(3)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Remark", SqlDbType.VarChar, remark, 10, "in")
            ReDim Preserve SQLParam(4)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@SysDateTime", SqlDbType.DateTime, dateD, 10, "in")
            ReDim Preserve SQLParam(5)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@User_Id", SqlDbType.Int, user_id, 10, "in")
            ReDim Preserve SQLParam(6)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@RET", SqlDbType.Int, 0, 1, "out")


            SQLComm = DAL_Obj.GetExcTo_Cmd("insertpro", SQLParam)

            If (SQLComm.Parameters("@RET").Value = 1) Then
                Return False
            Else
                TextSANo.Text = SQLComm.Parameters("@SA_No1").Value
                Return True
            End If

            ' MessageBox.Show("Successfully Data Addedd.....")

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function Save_detals(ByVal SA_no As Integer, ByVal cat_id As Integer, ByVal qty As Integer) As Boolean
        Try


            Dim SQLParam() As System.Data.SqlClient.SqlParameter
            Dim SQLComm As System.Data.SqlClient.SqlCommand


            ReDim Preserve SQLParam(0)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@SA_No1", SqlDbType.Int, SA_no, 20, "in")
            ReDim Preserve SQLParam(1)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Cat_Id", SqlDbType.Int, cat_id, 10, "in")
            ReDim Preserve SQLParam(2)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@Qty", SqlDbType.Int, qty, 10, "in")
            ReDim Preserve SQLParam(3)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@User_Id", SqlDbType.Int, TextId.Text, 10, "in")
            ReDim Preserve SQLParam(4)
            SQLParam(UBound(SQLParam)) = DAL_Obj.Param("@RET", SqlDbType.Int, 0, 10, "out")

            SQLComm = DAL_Obj.GetExcTo_Cmd("addpro", SQLParam)

            If (SQLComm.Parameters("@RET").Value = 1) Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function


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
