Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports Microsoft.Win32

Namespace TailoringERP.DB
    '211222
    Public Enum SpType
        StoredProcedure = 0
        SQL = 1
    End Enum

    Public Enum Dtype
        varchar = 1
        character = 2
        int = 3
        float = 4
        Bit = 5
        Doubl = 6
        DateTime = 7
        Bool = 8
        Money = 9
        img = 10
        nvarchar = 11
        smallInt = 12
    End Enum

    Public Enum ParaDirection
        Input
        InputOutPut
        OutPut
        ReturnValue
    End Enum

    Public Class DBManager

        Public con As New SqlClient.SqlConnection
        Public cmd As New SqlClient.SqlCommand
        Public cmdImg As New SqlClient.SqlCommand
        Dim dr As SqlClient.SqlDataReader
        Dim connectionstring As String

        Public con_Excel As New OleDb.OleDbConnection
        Public cn_Excel As New OleDb.OleDbConnection
        Dim cmd_Excel As New OleDb.OleDbCommand
        Dim dr_Excel As OleDb.OleDbDataReader

        Public cnnstring_Excel As String
        Public cnstring_Excel As String
        Public connectionstring_Excel As String

        Public Sub LogError(errorMessage As String, stackTrace As String)
            Prepare("Insert_LogError", SpType.StoredProcedure)
            AddCmdParameter("@ErrorDate", Dtype.DateTime, Format(Date.Now, "dd/MM/yyyy HH:mm"), ParaDirection.Input, True)
            AddCmdParameter("@ErrorMessage", Dtype.nvarchar, errorMessage, ParaDirection.Input, True)
            AddCmdParameter("@StackTrace", Dtype.nvarchar, stackTrace, ParaDirection.Input, True)
            ExecuteCommand()
        End Sub

        Public Sub openconnection()
            connectionstring = Application.StartupPath & "\conpath.ini"
            If Dir(connectionstring) = "" Then
                MsgBox("connection file missing", MsgBoxStyle.Critical)
                End
            End If

            Dim conpathfileno As Integer
            conpathfileno = FreeFile()
            FileOpen(conpathfileno, connectionstring, OpenMode.Input)
            Input(conpathfileno, connectionstring)
            FileClose(conpathfileno)
            conpathfileno = 0

            If connectionstring.Contains(";pwd=") Then
                connectionstring = connectionstring
            Else
                connectionstring = connectionstring & ";pwd=" & pwd
            End If

            'connectionstring = connectionstring

            ''If CheckLocalDBExists() = True Then
            ''    'connectionstring = "Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=dbSTE_Demo;Integrated Security=SSPI;AttachDbFilename=" & Application.StartupPath & "\SSD_DB\dbSTE_Demo.mdf;"
            ''    connectionstring = "Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=dbSTE_Demo_Traditional;Integrated Security=SSPI;AttachDbFilename=" & Application.StartupPath & "\SSD_DB\dbSTE_Demo_Traditional.mdf;"
            ''End If

            If connectionstring.Contains("103.10.234.153") Then 'Update Cloud Conpath if Cloud User
                connectionstring = connectionstring.Replace("103.10.234.153", "198.38.87.17")
                Dim Line As List(Of String) = File.ReadAllLines(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\conpath.ini").ToList()
                If Line.Count > 0 Then
                    If Line(0).Contains("103.10.234.153") = True Then
                        Line(0) = Line(0).Replace("103.10.234.153", "198.38.87.17")
                        File.WriteAllLines(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\conpath.ini", Line)
                    End If
                End If
            End If

            If con.State Then
                con.Close()
            End If
            M_Stumul_ConnectionString = connectionstring
            con = New SqlConnection(connectionstring)
            con.Open()
        End Sub

        Public Sub ChangeSQLpassword()
            connectionstring = File.ReadLines(Application.StartupPath & "\conpath.ini").First()
            If connectionstring.Contains(";pwd=") Then
                connectionstring = connectionstring
            Else
                connectionstring = connectionstring & ";pwd=Ss.d@2017"
            End If

            Try
                con = New SqlConnection(connectionstring)
                con.Open()
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "ALTER LOGIN [SA] With PASSWORD ='SunriseDb@2025'"
                cmd.CommandType = CommandType.Text
                cmd.ExecuteScalar()
                con.Close()
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function CheckLocalDBExists() As Boolean
            Dim s As String = ""
            Dim reg As RegistryKey
            Dim rtn As Boolean = False
            reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions\11.0", True)
            Try
                s = reg.GetValue("ParentInstance", "").ToString()
                reg.Close()
            Catch ex As Exception
                s = Nothing
            End Try

            If s = "MSSQL11E.LOCALDB" Then
                Dim oProcess As Process = New Process()
                Dim oStartInfo As ProcessStartInfo = New ProcessStartInfo("C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SqlLocalDB.exe", "info MSSQLLocalDB")
                oStartInfo.UseShellExecute = False
                oStartInfo.RedirectStandardOutput = True
                oProcess.StartInfo = oStartInfo
                oProcess.Start()
                Dim sOutput As String

                Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
                    sOutput = oStreamReader.ReadToEnd()
                End Using

                If sOutput.ToUpper().Contains("DOESN'T EXIST") Then
                    Try
                        Process.Start("C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SqlLocalDB.exe", "create MSSQLLocalDb")
                        rtn = True
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString())
                        rtn = False
                    End Try
                Else
                    rtn = True
                End If
            Else
                MessageBox.Show("Please Install Sql...")
                rtn = False
            End If

            Return rtn
        End Function

        Public Sub openconnection_Excel(ByVal _fileName As String)
            connectionstring_Excel = _fileName
            cn_Excel = New OleDb.OleDbConnection(connectionstring_Excel)
            cn_Excel.Open()
        End Sub

        Public Function QueryExecute(ByVal sqlstr As String) As Boolean
            Try
                If con.State = ConnectionState.Closed Then openconnection()
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = sqlstr
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstr)
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        End Function

        Public Function QueryExecute_Script(ByVal sqlstr As String) As Boolean
            Try
                If con.State = ConnectionState.Closed Then openconnection()
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = sqlstr
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstr)
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        End Function

        Protected Sub Execute(ByVal cm As SqlCommand)
            Try
                If con.State = ConnectionState.Closed Then openconnection()
                cm.Connection = con
                cm.ExecuteNonQuery()
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End Sub

        Public Function QueryExecuteImage(ByVal sqlstr As String, ByVal filePath As String) As Boolean
            Try
                'con.Close()
                If con.State = ConnectionState.Closed Then openconnection()
                cmdImg = New SqlCommand
                cmdImg.Connection = con
                cmdImg.CommandText = sqlstr
                cmdImg.CommandType = CommandType.Text

                Dim imgByteArray() As Byte
                Dim stream As New MemoryStream
                Dim bmp As New Bitmap(filePath)

                bmp.Save(stream, ImageFormat.Jpeg)
                imgByteArray = stream.ToArray()
                stream.Close()

                cmdImg.Parameters.AddWithValue("@Image", imgByteArray)
                cmdImg.ExecuteNonQuery()
                'con.Close()
                Return True
            Catch ex As Exception
                'Throw ex
                'MsgBox("Data of This Record Exist In Another Table", MsgBoxStyle.Critical)
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstr)
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        End Function

        Public Function ScalarExecute(ByVal sqlstr As String) As Object
            Try
                'con.Close()
                'openconnection()
                If con.State = ConnectionState.Closed Then openconnection()
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = sqlstr
                cmd.CommandType = CommandType.Text
                Return cmd.ExecuteScalar
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstr & vbCrLf & ex.Message & vbCrLf & Err.Description, MsgBoxStyle.Critical)
            End Try
        End Function

        Public Function LoadData123(ByVal sqlstring As String, ByVal Dt As DataSet) As DataSet
            'cmd = New SqlCommand
            Dim da As New SqlDataAdapter
            If con.State = ConnectionState.Closed Then openconnection()
            'cmd.Connection = con
            'cmd = New SqlClient.SqlCommand
            cmd.Connection = con
            cmd.CommandText = sqlstring
            cmd.CommandType = CommandType.StoredProcedure
            da = New SqlDataAdapter(cmd)
            Try
                da.Fill(Dt)
                Return Dt
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstring, MsgBoxStyle.Critical)
                MsgBox(Err.Description, MsgBoxStyle.Critical)
                Return Nothing
            End Try
        End Function

        Public Function LoadData(ByVal sqlstring As String, ByVal Dt As DataSet) As DataSet
            If con.State = ConnectionState.Closed Then openconnection()
            Dim da As New SqlDataAdapter

            cmd.Connection = con
            cmd.CommandText = sqlstring
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 120
            'da = New SqlDataAdapter(sqlstring, con)
            da = New SqlDataAdapter(cmd)
            Try
                da.Fill(Dt)
                Return Dt
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstring, MsgBoxStyle.Critical)
                MsgBox(Err.Description, MsgBoxStyle.Critical)
                Return Nothing
            End Try
        End Function

        Public Sub Prepare(ByVal CmdName As String, ByVal CmdType As SpType)
            cmd = New SqlCommand(CmdName, con)
            If CmdType = SpType.StoredProcedure Then
                cmd.CommandType = CommandType.StoredProcedure
            Else
                cmd.CommandType = CommandType.Text
            End If
        End Sub

        Public Function Read() As Boolean
            Return dr.Read()
        End Function

        Public Sub AddCmdParameter(ByVal pName As String, ByVal dtype As Dtype, ByVal val As Object, ByVal Direction As ParaDirection, ByVal isNull As Boolean)
            Dim len As Integer
            Dim datatype As SqlDbType
            len = 0
            datatype = SqlDbType.VarChar
            Select Case dtype

                Case dtype.Bool : datatype = SqlDbType.Bit

                Case dtype.character : datatype = SqlDbType.Char

                Case dtype.DateTime : datatype = SqlDbType.DateTime

                Case dtype.float : datatype = SqlDbType.Float

                Case dtype.int : datatype = SqlDbType.Int

                Case dtype.Money : datatype = SqlDbType.Money

                Case dtype.varchar : datatype = SqlDbType.VarChar

                Case dtype.nvarchar : datatype = SqlDbType.NVarChar

                Case dtype.img : datatype = SqlDbType.Image

                Case dtype.smallInt : datatype = SqlDbType.SmallInt

            End Select
            'If val = isNull Then val = ""
            Dim dire As ParameterDirection
            dire = ParameterDirection.Input
            Select Case Direction

                Case ParaDirection.Input : dire = ParameterDirection.Input

                Case ParaDirection.InputOutPut : dire = ParameterDirection.InputOutput

                Case ParaDirection.OutPut : dire = ParameterDirection.Output

                Case ParaDirection.ReturnValue : dire = ParameterDirection.ReturnValue

            End Select
            Dim SP As SqlParameter
            SP = New SqlParameter(pName, datatype, len, dire, isNull, 0, 0, "", DataRowVersion.Current, val)
            cmd.Parameters.Add(SP)
        End Sub

        Public Sub ExecuteCommand()
            Try
                If con.State = ConnectionState.Closed Then
                    openconnection()
                End If
                cmd.Connection = con 'Added on 14-09-17
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(ex.Message)
                Throw ex
            End Try
        End Sub

        Public Function ExecuteCommand_GET() As Object
            Try
                If con.State = ConnectionState.Closed Then
                    openconnection()
                End If
                cmd.Connection = con 'Added on 14-09-17
                Return cmd.ExecuteScalar()
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(ex.Message)
                Throw ex
            End Try
        End Function

        Public Function ExecuteReturnCommand(ByVal pr As String) As Integer
            Dim a As Double = 0
            Try
                'openconnection()
                cmd.ExecuteNonQuery()
                a = Val(cmd.Parameters(pr).Value.ToString())
                Return a
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(ex.Message)
                Throw ex

            End Try
        End Function

        Public Function LoadData_Excel(ByVal sqlstring As String, ByVal Dt As DataSet, ByVal _fileName As String) As DataSet

            If con_Excel.State = ConnectionState.Closed Then openconnection_Excel(_fileName)
            Dim da As New OleDb.OleDbDataAdapter
            da = New OleDb.OleDbDataAdapter(sqlstring, _fileName)
            Try
                da.Fill(Dt)
                cn_Excel.Close()
                cn_Excel.Dispose()
                Return Dt
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstring, MsgBoxStyle.Critical)
                MsgBox(Err.Description, MsgBoxStyle.Critical)
                Return Nothing
            End Try
        End Function

        '-----------other database
        Public ParallelCon As String
        Dim con1 As New SqlClient.SqlConnection
        Dim cn1 As New SqlClient.SqlConnection

        Public Sub openconnection_CRM()
            ParallelCon = Application.StartupPath & "\ConPath1.ini"

            If Dir(ParallelCon) = "" Then
                MsgBox("Connection File Missing", MsgBoxStyle.Critical)
                End 'Ends Entire Application
            End If
            Dim conPathFileNo As Integer
            conPathFileNo = FreeFile()
            FileOpen(conPathFileNo, ParallelCon, OpenMode.Input)
            Input(conPathFileNo, ParallelCon)
            FileClose(conPathFileNo)
            conPathFileNo = 0

            If ParallelCon.Contains(";pwd=") Then
                ParallelCon = ParallelCon
            Else
                ParallelCon = ParallelCon & ";pwd=" & pwd
            End If

            If ParallelCon.Contains("103.10.234.153") Then 'Update Cloud Conpath if Cloud User
                ParallelCon = ParallelCon.Replace("103.10.234.153", "198.38.87.17")
                Dim Line As List(Of String) = File.ReadAllLines(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\conpath1.ini").ToList()
                If Line.Count > 0 Then
                    If Line(0).Contains("103.10.234.153") = True Then
                        Line(0) = Line(0).Replace("103.10.234.153", "198.38.87.17")
                        File.WriteAllLines(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\conpath1.ini", Line)
                    End If
                End If
            End If

            If cn1.State Then
                cn1.Close()
            End If

            cn1 = New SqlConnection(ParallelCon)
            cn1.Open()

            If ConStr = "" Then Exit Sub

            If con1.State Then
                con1.Close()
            End If

            con1 = New SqlConnection(ParallelCon)
            con1.Open()

        End Sub

        Public Function LoadData_CRM(ByVal sqlstring As String, ByVal Dt As DataSet) As DataSet

            If con1.State = ConnectionState.Closed Then openconnection_CRM()
            Dim da1 As New SqlDataAdapter
            da1 = New SqlDataAdapter(sqlstring, con1)
            Try
                da1.Fill(Dt)
                Return Dt
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstring, MsgBoxStyle.Critical)
                MsgBox(Err.Description, MsgBoxStyle.Critical)
                Return Nothing
            End Try
        End Function


        'For Naresh Fashion Server Connection
        Public NareshFashionCon As String
        Dim connf As New SqlClient.SqlConnection
        Dim cnnf As New SqlClient.SqlConnection

        Public Sub openconnection_NF()
            'NareshFashionCon = Application.StartupPath & "\ConPath2.ini"

            'If Dir(NareshFashionCon) = "" Then
            '    MsgBox("Connection File Missing", MsgBoxStyle.Critical)
            '    End 'Ends Entire Application
            'End If
            'Dim conPathFileNo As Integer
            'conPathFileNo = FreeFile()
            'FileOpen(conPathFileNo, NareshFashionCon, OpenMode.Input)
            'Input(conPathFileNo, NareshFashionCon)
            'FileClose(conPathFileNo)
            'conPathFileNo = 0

            NareshFashionCon = M_GenisysConpath

            If NareshFashionCon.Contains(";pwd=") Then
                NareshFashionCon = NareshFashionCon
            Else
                NareshFashionCon = NareshFashionCon & ";pwd=" & pwd
            End If

            If cnnf.State Then
                cnnf.Close()
            End If

            cnnf = New SqlConnection(NareshFashionCon)
            cnnf.Open()

            If ConStr = "" Then Exit Sub
            If connf.State Then
                connf.Close()
            End If

            connf = New SqlConnection(NareshFashionCon)
            connf.Open()
        End Sub

        Public Function LoadData_NF(ByVal sqlstring As String, ByVal Dt As DataSet) As DataSet
            If connf.State = ConnectionState.Closed Then openconnection_NF()
            Dim da1 As New SqlDataAdapter
            da1 = New SqlDataAdapter(sqlstring, connf)
            Try
                da1.Fill(Dt)
                Return Dt
            Catch ex As Exception
                LogError(ex.Message, ex.StackTrace)

                MsgBox(sqlstring, MsgBoxStyle.Critical)
                MsgBox(Err.Description, MsgBoxStyle.Critical)
                Return Nothing
            End Try
        End Function

    End Class

End Namespace


