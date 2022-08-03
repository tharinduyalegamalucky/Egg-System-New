Imports System.Data.SqlClient
Imports System.Data
Public Class DBConnection
    Shared cn As SqlConnection
    Shared cmd As SqlCommand
    Shared sqlTrans As SqlTransaction

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
End Class
