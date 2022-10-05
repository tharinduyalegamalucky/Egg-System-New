
Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class DBAccess

#Region "Constants"

#Const DalSQL = True
#Const DalOLEDb = False
#Const Dev = False

#End Region

#Region "Public var"
    Public doTrace As Boolean = False
#End Region

#Region "Private var"
    Private logFile As String = "\\Dbserver\e\SQLServer\MSSQL\dal\dbaccesslog.txt"
    Private aLog As String
    Private sw As StreamWriter
    Private cn As SqlConnection
    Private dStartTime As Date
    Private dEndTime As Date
    Private iStartTime As Single
    Private iEndTime As Single

    Private serverName As String
    Private dataBaseName As String
#End Region

#Region "Connection"

    Public Function Connect(ByVal sServer As String, ByVal dbName As String) As Boolean

        Try
            cn = New SqlConnection
            cn.ConnectionString = "server =" & sServer & "; Database=" & dbName & ";integrated security=true"

            If doTrace = True Then
                sw = File.AppendText(logFile)
                sw.WriteLine("Connecting to database " & sServer & "\" & dbName)
                sw.Flush()
                sw.Close()
            End If

            cn.Open()

            If doTrace = True Then
                sw = File.AppendText(logFile)
                sw.WriteLine("Connected" & " - " & Now)
                sw.Flush()
                sw.Close()
            End If

            serverName = sServer
            dataBaseName = dbName

            Return True

        Catch ex As Exception 'If cn.State = ConnectionState.Closed Then

            If doTrace = True Then
                sw = File.AppendText(logFile)
                sw.WriteLine("Connection faild" & " - " & Now)
                sw.Flush()
                sw.Close()
            End If

            Err.Raise(vbObjectError + 512 + 1, , "Connecting to SQL Server faild!", "HelpFile.hlp", 101)
            Return False

        End Try

    End Function

#End Region

    'Private Function AddSANDetails() ByVal SA_No As Integer, ByVal Loc_Id As Integer, ByVal Com_Id As Integer, ByVal Remark As Char, ByVal SysDateTime As Date, ByVal User_Id As Integer
    '    Dim SQLParam() As System.Data.SqlClient.SqlParameter

    'End Function

#Region "Disconnection"

    Public Function Disconnect() As Boolean
        cn.Close()

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("Disconnected from " & serverName & "\" & dataBaseName & " - " & Now)
            sw.Flush()
            sw.Close()
        End If

        cn = Nothing
    End Function

#End Region

#Region "Excecution"

    Public Function GetExcTo_DataSet(ByVal spname As String, Optional ByVal params() As System.Data.SqlClient.SqlParameter = Nothing) As System.Data.DataSet
        'Dim cn As New System.Data.SqlClient.SqlConnection
        Dim ds As DataSet
        Dim da As SqlDataAdapter
        Dim param As SqlParameter
        Dim cmd As SqlCommand

        cmd = New SqlCommand ' create command object
        'get parameters
        If Not params Is Nothing Then
            For Each param In params
                cmd.Parameters.Add(param)
            Next
        End If

        cmd.CommandText = spname ' set sp name
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Connection = cn 'connect to database
        'Fill DataSet from DataAdapter
        da = New SqlDataAdapter
        da.SelectCommand = cmd
        ds = New DataSet

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("DB Access - start = " & Now & " proc = " & spname & " " & aLog)
            dStartTime = Now
            iStartTime = CSng(Timer)
            sw.Flush()
            sw.Close()
        End If

        da.Fill(ds)

        If doTrace = True Then
            dEndTime = Now
            iEndTime = CSng(Timer)
        End If

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("DB Access - start = " & dStartTime & " end = " & dEndTime & " time = " & Format(iEndTime - iStartTime, "##0.000000") & " secs, proc = " & spname)
            sw.Flush()
            sw.Close()
        End If

        ' clear up
        da = Nothing
        cmd = Nothing

        Return ds
    End Function

    Public Function GetExcTo_Cmd(ByVal spname As String, Optional ByVal params() As System.Data.SqlClient.SqlParameter = Nothing) As System.Data.SqlClient.SqlCommand
        'Dim cn As System.Data.SqlClient.SqlConnection
        Dim param As SqlParameter
        Dim cmd As SqlCommand

        ' create command object
        cmd = New SqlCommand
        'get parameters
        If Not params Is Nothing Then
            For Each param In params
                cmd.Parameters.Add(param)
            Next
        End If

        ' set sp name
        cmd.CommandText = spname
        cmd.CommandType = CommandType.StoredProcedure
        ' connect to database
        'cn = OpensqlConnection()
        cmd.Connection = cn

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("DB Access - start = " & Now & " proc = " & spname & " " & aLog)
            dStartTime = Now
            iStartTime = CSng(Timer)
            sw.Flush()
            sw.Close()
        End If

        cmd.ExecuteNonQuery()

        If doTrace = True Then
            dEndTime = Now
            iEndTime = CSng(Timer)
        End If

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("DB Access - start = " & dStartTime & " end = " & dEndTime & " time = " & Format(iEndTime - iStartTime, "##0.000000") & " secs, proc = " & spname)
            sw.Flush()
            sw.Close()
        End If

        Return cmd
    End Function


    Private Function btnSave_Click(ByVal SA_No As Integer, ByVal Loc_Id As Integer, ByVal Com_Id As Integer, ByVal Remark As Char, ByVal SysDateTime As Date, ByVal User_Id As Integer, ByVal Egg_Category_Id As Integer, ByVal Qty As Integer)

    End Function

    Public Function GetExcTo_DataReader(ByVal spname As String, Optional ByVal params() As System.Data.SqlClient.SqlParameter = Nothing) As System.Data.SqlClient.SqlDataReader
        'Dim cn As System.Data.SqlClient.SqlConnection
        Dim param As SqlParameter
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        ' create command object
        cmd = New SqlCommand
        'get parameters
        If Not params Is Nothing Then
            For Each param In params
                cmd.Parameters.Add(param)
            Next
        End If

        cmd.CommandText = spname ' set sp name
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Connection = cn 'connect to database

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("DB Access - start = " & Now & " proc = " & spname & " " & aLog)
            sw.Flush()
            sw.Close()
            dStartTime = Now
            iStartTime = CSng(Timer)
        End If

        dr = cmd.ExecuteReader

        If doTrace = True Then
            dEndTime = Now
            iEndTime = CSng(Timer)
        End If

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("DB Access - start = " & dStartTime & " end = " & dEndTime & " time = " & Format(iEndTime - iStartTime, "##0.000000") & " secs, proc = " & spname)
            sw.Flush()
            sw.Close()
        End If

        Return dr
    End Function

#End Region

#Region "Parameterizing"

    Public Function Param(ByVal pName As String, ByVal pType As SqlDbType, ByVal pValue As String, ByVal pLength As Integer, ByVal pDirection As String) As System.Data.SqlClient.SqlParameter
        Dim oParam As New SqlParameter
        If pDirection = "out" Then
            oParam.Direction = ParameterDirection.InputOutput
        ElseIf pDirection = "rtn" Then
            oParam.Direction = ParameterDirection.ReturnValue
        Else
            oParam.Direction = ParameterDirection.Input
        End If

        aLog = aLog & CStr(IIf(aLog <> "", ",", ""))
        If pType = 2 Then
            oParam.Value = CBool(pValue)
        ElseIf pType = 3 Or pType = 22 Then
            oParam.Value = CStr(pValue)
            aLog = aLog & "'" & pValue & "'"
        ElseIf pType = 19 Or pType = 4 Then
            oParam.Value = CDate(pValue)
            aLog = aLog & "'" & Format(pValue, "ddmmyyyy hh:nn:ss") & "'"
        Else
            oParam.Value = Val(pValue)
            aLog = aLog & pValue
        End If

        oParam.Size = pLength
        oParam.SqlDbType = pType
        oParam.ParameterName = pName
        'oParam.Value = pValue
        Return oParam
    End Function

#End Region

#Region "Transaction handling"

    Public Sub BeginTran()
        Dim Cmd As New SqlCommand
        Cmd.Connection = cn
        Cmd.CommandText = "Begin tran"
        Cmd.CommandType = CommandType.Text
        Cmd.ExecuteNonQuery()
        Cmd = Nothing
    End Sub

    Public Sub CommitTran()

        Dim Cmd As New SqlCommand
        Cmd.Connection = cn
        Cmd.CommandText = "Commit tran"
        Cmd.CommandType = CommandType.Text
        Cmd.ExecuteNonQuery()
        Cmd = Nothing

    End Sub

    Public Sub RollbackTran()

        Dim Cmd As New SqlCommand
        Cmd.Connection = cn
        Cmd.CommandText = "rollback tran"
        Cmd.CommandType = CommandType.Text
        Cmd.ExecuteNonQuery()
        Cmd = Nothing

    End Sub

    Public Sub Exc_Command(ByVal cmdTxt As String)
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = cmdTxt
        cmd.CommandType = CommandType.Text
        ' connect to database

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("DB Access - start = " & Now & " command = " & cmdTxt & " " & aLog)
            dStartTime = Now
            iStartTime = CSng(Timer)
            sw.Flush()
            sw.Close()
        End If

        cmd.ExecuteNonQuery()

        If doTrace = True Then
            dEndTime = Now
            iEndTime = CSng(Timer)
        End If

        If doTrace = True Then
            sw = File.AppendText(logFile)
            sw.WriteLine("DB Access - start = " & dStartTime & " end = " & dEndTime & " time = " & Format(iEndTime - iStartTime, "##0.000000") & " secs, command = " & cmdTxt)
            sw.Flush()
            sw.Close()
        End If

        cmd = Nothing

    End Sub

#End Region

End Class





