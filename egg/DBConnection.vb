Imports System.Data.SqlClient
Imports System.Data

Public Class DBConnection
    Shared cn As SqlConnection
    Shared cmd As SqlCommand
    Shared sqlTrans As SqlTransaction
    Shared da As SqlDataAdapter
    Shared dt As DataTable
    Private Shared intCommandTimeout As Integer = 100

    'Starting a database transaction to execute query batch
    Public Shared Sub BeginTrans()
        connect()
        sqlTrans = cn.BeginTransaction()
    End Sub

    'Commiting the transaction to update database
    Public Shared Sub CommitTrans()
        sqlTrans.Commit()
        sqlTrans = Nothing
    End Sub

    'Rolling back the current transaction
    Public Shared Sub RollbackTrans()
        sqlTrans.Rollback()
        sqlTrans = Nothing
    End Sub

    Shared Sub connect()
        cn = New SqlConnection("Data Source=LAPTOP-DCJ10BPM;Initial Catalog=Egg;Integrated Security=True")
    End Sub


    Shared Function ExecuteSql(ByVal Sql As String) As Boolean

        Try
            cmd = New SqlCommand(Sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Return True

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Shared Function GenerateResultSet(ByVal SQL As String) As DataTable
        da = New SqlDataAdapter
        dt = New DataTable
        Try
            cmd = New SqlCommand(SQL, cn)
            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)
            cn.Close()
            Return dt
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
            dt = Nothing
            Return dt
        End Try
    End Function


    'Add parameters to the SQLCommand object which is used for MSSQL databases
    '<param name="param">An array of parameters for MSSQL database query</param>
    Public Shared Sub AddParameters(param As SqlParameter())
        Try
            If param IsNot Nothing Then
                For i As Integer = 0 To param.Length - 1
                    If param(i) IsNot Nothing Then
                        cmd.Parameters.Add(param(i))
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Returns dataTable object consists of data by executing a SQL query
    '<param name="query">SQL query statement</param>
    '<returns>DataTable object</returns>
    Public Shared Function ReturnDataTable(query As String, cmdType As CommandType) As DataTable
        Try
            Return ReturnDataTable(query, cmdType)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Return a single Data Row by executing a SQL query with it's data parameters
    '<param name="query">SQL query statement</param>
    '<param name="param">Data Parameters to execute the query</param>
    '<returns>DataRow object</returns>
    Public Shared Function ReturnDataRow(query As String, param As SqlParameter()) As DataRow
        Dim ds As New DataSet
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = query
            cmd.Transaction = sqlTrans
            ''cmd.Connection = connect()
            AddParameters(param)
            Dim DAdapter As New SqlDataAdapter
            DAdapter.SelectCommand = cmd
            DAdapter.Fill(ds)

            If ds.Tables(0).Rows.Count <> 0 Then
                Return ds.Tables(0).Rows(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            cmd = Nothing
        End Try
    End Function

    'Return a single Data Row by executing a SQL query
    '<param name="query">SQL query statement</param>
    '<returns>DataRow object</returns>
    Public Shared Function ReturnDataRow(query As String) As DataRow
        Try
            Return ReturnDataRow(query, Nothing)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Return a scaler value
    '<param name="query">SQL query</param>
    '<returns>object that can be casted to a scaler type</returns>
    Public Shared Function ReturnScaler(query As String) As Object
        Try
            Return ReturnScaler(query)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function checkExistsRec(strSQL As String) As Boolean
        Try
            Dim obj As Object = ReturnScaler(strSQL)
            If obj IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

