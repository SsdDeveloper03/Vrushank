Imports notificationDll
Imports Sunrise.TailoringERP.DB
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Management
Imports System.Text
Imports TailoringERP.TailoringERP.DB

Public Class FrmLogin
    ''' <summary>
    ''' 
    ''' </summary>  
#Region "Comments"
    'Name:Tailoring
    'Created By:Bhavesh
    'Form:FrmUserLogin 
    'Date:29/11/2011
#End Region

#Region "Declaration"
    Dim version As String = "(Version: 05.12.25)"
    Dim obj As New DBManager
    Dim sql_Query As String
    Dim ds As New Data.DataSet
    Dim ds1 As New DataSet
    Dim validUser As Boolean = False
    Private sb As StringBuilder = New StringBuilder()

    Dim currentMacIp As String = ""
    Dim SmsTextOTP, SmsText, whatsappTextOTP As String
    Dim dsUserData As DataSet
    Dim dsCRMDetails_Server As New Data.DataSet
    Dim ssdPC As Boolean = False
#End Region

#Region "Method"

    Public Sub getDept()
        Dim tmpDs As New Data.DataSet
        If txtUserName.Text = "ADMIN" Then
            sql_Query = "Select * From View_UserMaster WHERE UserName= N'" & txtUserName.Text & "' AND 'ADMIN' + UserPwd= N'" & txtPwd.Text & "'"
        Else
            sql_Query = "Select * From View_UserMaster WHERE UserName= N'" & txtUserName.Text & "' AND UserPwd= N'" & txtPwd.Text & "' And DeptType = 'ERP'"
        End If

        obj.LoadData(sql_Query, tmpDs)

        Select Case tmpDs.Tables(0).Rows.Count
            Case 0
                MsgBox("0 Record Retrieved", MsgBoxStyle.Information)
                Exit Select
            Case 1
                cmbDept.Items.Clear()
                cmbDept.Items.Add(tmpDs.Tables(0).Rows(0)("DeptName"))
                cmbDept.SelectedIndex = 0
                loggedDeptId = tmpDs.Tables(0).Rows(0)("DeptId")
                loggedUserId = tmpDs.Tables(0).Rows(0)("UserId")
                M_LoggedLedgerId = tmpDs.Tables(0).Rows(0)("LedgerId")
                M_LoggedLedgerName = tmpDs.Tables(0).Rows(0)("LedgerName")
                M_Barcode_CIdList = tmpDs.Tables(0).Rows(0)("Barcode_CIdList")
                M_LoggedMobileNo = tmpDs.Tables(0).Rows(0)("MobileNo")
                M_LoggedIsOTPRequired = tmpDs.Tables(0).Rows(0)("IsOTPRequired")

                sql_Query = "Select CIdList From tbl_TranUserWiseCIdList Where TranType = 'User Wise Companies' And UserId = " & loggedUserId
                M_UserWiseCompanies = obj.ScalarExecute(sql_Query)
                Exit Select
            Case Is > 1
                MsgBox(">1 Records Retrieved", MsgBoxStyle.Information)
                Exit Select
        End Select

        'sql_Query = "SELECT DeptName FROM tbl_DeptMaster INNER JOIN tbl_UserMaster ON tbl_DeptMaster.DeptId = tbl_UserMaster.DeptId WHERE (((UserName)='" & txtUserName1.Text & "') AND ((UserPwd)='" & txtPwd1.Text & "'))"
        'cmbDept.Items.Clear()
        'cmbDept.Items.Add(obj.ScalarExecute(sql_Query))
        'cmbDept.SelectedIndex = 0
        'sql_Query = "SELECT tbl_DeptMaster.DeptId FROM tbl_DeptMaster INNER JOIN tbl_UserMaster ON tbl_DeptMaster.DeptId = tbl_UserMaster.DeptId WHERE (((UserName)='" & txtUserName1.Text & "') AND ((UserPwd)='" & txtPwd1.Text & "'))"
        'loggedDeptId = obj.ScalarExecute(sql_Query)
    End Sub

    Public Sub Insert_Audit_Session()
        obj.Prepare("InsertAudit_Session", SpType.StoredProcedure)
        obj.AddCmdParameter("@InsUserId", Dtype.int, loggedUserId, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsBeginTimeStamp", Dtype.DateTime, M_GetServerDTM_SP(), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPCName", Dtype.varchar, M_GetPCName(), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPCIPAddress", Dtype.varchar, M_GetPCIPAddress(), ParaDirection.Input, True)
        obj.ExecuteCommand()
    End Sub

    Public Sub Obtain_SessionId()
        sql_Query = "Exec SelectAudit_Session " & loggedUserId
        M_SesssionId = obj.ScalarExecute(sql_Query)
    End Sub

    Public Sub insert_CRMDetails()
        Try
            fetchDetailsFromServer()

            If dsCRMDetails_Server.Tables(0).Rows.Count = 0 Then
                MsgBox("Please Check & Correct Subscription Details", MsgBoxStyle.Information)
                End
            End If

            sql_Query = "Delete From tbl_CRMDetails"
            obj.QueryExecute(sql_Query)

            obj.Prepare("SP_InsertCRMDetails", SpType.StoredProcedure)
            obj.AddCmdParameter("@InsCode", Dtype.int, dsCRMDetails_Server.Tables(0).Rows(0)("Code"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsLedgerCode", Dtype.varchar, dsCRMDetails_Server.Tables(0).Rows(0)("LedgerCode"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsLedgerName", Dtype.varchar, dsCRMDetails_Server.Tables(0).Rows(0)("LedgerName"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsBusinessName", Dtype.varchar, dsCRMDetails_Server.Tables(0).Rows(0)("BusinessName"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsSoftwareName", Dtype.varchar, dsCRMDetails_Server.Tables(0).Rows(0)("SoftwareName"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsDemoDate", Dtype.DateTime, dsCRMDetails_Server.Tables(0).Rows(0)("DemoDate"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsPurchaseDate", Dtype.DateTime, dsCRMDetails_Server.Tables(0).Rows(0)("PurchaseDate"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsAMCStartDate", Dtype.DateTime, dsCRMDetails_Server.Tables(0).Rows(0)("AMCStartDate"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsAMCPaidUpto", Dtype.DateTime, dsCRMDetails_Server.Tables(0).Rows(0)("AMCPaidUpto"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsDiscontinueDate", Dtype.DateTime, dsCRMDetails_Server.Tables(0).Rows(0)("DiscontinueDate"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsReason", Dtype.nvarchar, dsCRMDetails_Server.Tables(0).Rows(0)("Reason"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsTotalLicense", Dtype.int, dsCRMDetails_Server.Tables(0).Rows(0)("TotalLicense"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsMacIdList", Dtype.nvarchar, dsCRMDetails_Server.Tables(0).Rows(0)("MacIdList"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsHDDList", Dtype.nvarchar, dsCRMDetails_Server.Tables(0).Rows(0)("HDDList"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsSoftwareUpdateDate", Dtype.DateTime, dsCRMDetails_Server.Tables(0).Rows(0)("SoftwareUpdateDate"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsDatabaseUpdateDate", Dtype.DateTime, dsCRMDetails_Server.Tables(0).Rows(0)("DatabaseUpdateDate"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsDatabaseCounter", Dtype.float, dsCRMDetails_Server.Tables(0).Rows(0)("DatabaseCounter"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsLastOnlineDate", Dtype.DateTime, dsCRMDetails_Server.Tables(0).Rows(0)("LastOnlineDate"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsServerHDDNo", Dtype.nvarchar, dsCRMDetails_Server.Tables(0).Rows(0)("ServerHDDNo"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsServerMacId", Dtype.nvarchar, dsCRMDetails_Server.Tables(0).Rows(0)("ServerMacId"), ParaDirection.Input, True)
            obj.AddCmdParameter("@InsSys_Name", Dtype.varchar, M_GetPCName, ParaDirection.Input, True)
            obj.AddCmdParameter("@InsSys_Time", Dtype.DateTime, M_GetServerDTM_SP, ParaDirection.Input, True)
            obj.AddCmdParameter("@InsCurrUsr", Dtype.varchar, "", ParaDirection.Input, True)
            obj.ExecuteCommand()

            dsCRMDetails_Local.Clear()
            sql_Query = "Select Top 1 * from tbl_CRMDetails order by Id desc"
            obj.LoadData(sql_Query, dsCRMDetails_Local)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub checkHDDSrNumber()
        If M_DbName.Contains("dbSTE_Demo") Then
            'Add 18-02-21        
            setVersionAndDate()
            'Do Nothing
        Else
            'Fetch from Database: Everytime
            'Dim dsCRMDetails_Local As New Data.DataSet
            dsCRMDetails_Local.Clear()
            sql_Query = "Select Top 1 * from tbl_CRMDetails order by Id desc"
            obj.LoadData(sql_Query, dsCRMDetails_Local)

            If dsCRMDetails_Local.Tables(0).Rows.Count = 0 Then
                fetchDetailsFromServer()

                If dsCRMDetails_Server.Tables(0).Rows.Count = 0 Then
                    MsgBox("Please Check & Correct Subscription Details", MsgBoxStyle.Information)
                    End
                End If

                If dsCRMDetails_Server.Tables(0).Rows.Count = 1 Then
                    insert_CRMDetails()
                Else
                    MsgBox("Please Inform Software Developer, Multiple Entries in CRM", MsgBoxStyle.Information)
                    End
                End If

                dsCRMDetails_Local.Clear()
                sql_Query = "Select Top 1 * from tbl_CRMDetails order by Id desc"
                obj.LoadData(sql_Query, dsCRMDetails_Local)
            End If

            If dsCRMDetails_Local.Tables(0).Rows.Count = 0 Then
                MsgBox("Please Update Subscription Details", MsgBoxStyle.Information)
                Exit Sub
            Else
                Try
                    'Fetch from Server: Only Login from SQL PC
                    Dim mos As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
                    For Each mo As ManagementObject In mos.Get()
                        Dim serial As String = mo("SerialNumber").ToString() 'If Login from Server PC                       
                        If Trim(serial) = dsCRMDetails_Local.Tables(0).Rows(0)("ServerHDDNo") Then 'If This is Server PC                            
                            sql_Query = "Select Top 1 datediff(d, Sys_Time , getdate()) from tbl_CRMDetails Order by Id desc"
                            If obj.ScalarExecute(sql_Query) > 40 Then
                                fetchDetailsFromServer()

                                'Copy into Local: Only Login from SQL PC
                                If dsCRMDetails_Server.Tables(0).Rows.Count = 1 Then 'Or dsCRMDetails_Server.Tables(0).Rows.Count = 0 
                                    insert_CRMDetails()
                                Else
                                    MsgBox("Please Inform Software Developer, Multiple Entries in CRM", MsgBoxStyle.Information)
                                End If
                                'End If
                            End If
                        End If
                    Next

                    'Compare Local Data: Everytime
                    If dsCRMDetails_Local.Tables(0).Rows(0)("HDDList") <> "" Then 'Fix PCs = Compare HDD Number
                        For Each mo As ManagementObject In mos.Get()
                            Dim serial As String = mo("SerialNumber").ToString()
                            Dim srNumber As String = dsCRMDetails_Local.Tables(0).Rows(0)("HDDList")
                            Dim tmpArray() As String = Strings.Split(Trim(srNumber), ",")

                            Dim flag As Boolean = False
                            'For i As Integer = 0 To tmpArray.GetUpperBound(0)
                            '    If serial = tmpArray(i) Then
                            '        flag = True
                            '    End If
                            'Next

                            Select Case Trim(serial)
                                Case "20246G446307", "WD-WCAV9CF21761", "1806AD806956", "30023210682", "11ENC2L7T", "JA1086SB03MB9T", "00A0_7501_325D_8688.", "S3T6NX0KB57755", "0026111030DS", "UB202309221900000242", "UB202309221900000242", "WD-WXC1EC85608S"
                                    ssdPC = True
                                    flag = True
                                    Exit Select
                            End Select

                            For i As Integer = 0 To tmpArray.Length - 1
                                'MsgBox("[" & Trim(serial) & "]" & vbCrLf & "[" & tmpArray(i) & "]")
                                If Trim(serial) = tmpArray(i) Then
                                    flag = True
                                End If
                            Next

                            'Pakiza Error
                            If dsCRMDetails_Local.Tables(0).Rows(0)("ServerHDDNo") = "ERROR" Then
                                flag = True
                            End If

                            If flag = False Then
                                MsgBox("System Error" & vbCrLf & " Serial Number Mismatch!.", MsgBoxStyle.Information)
                                End
                            End If
                        Next
                    End If

                    'If dsCRMDetails_Local.Tables(0).Rows(0)("TotalLicense") > 0 Then 'Unlimited PC and Fix Live Users
                    '    Dim tmpLoggedUsers As Integer
                    '    sql_Query = "Select Count(*) From tbl_Audit_Session where EndTimeStamp Is Null "
                    '    tmpLoggedUsers = obj.ScalarExecute(sql_Query)

                    '    If dsCRMDetails_Local.Tables(0).Rows(0)("TotalLicense") < (tmpLoggedUsers + 1) Then
                    '        MsgBox("Already " & tmpLoggedUsers & " Users Are Active, Please Logout Idle Users", MsgBoxStyle.Information)
                    '        End
                    '    End If
                    'End If

                Catch ex As Exception
                    MsgBox("Error in DOS Command", MsgBoxStyle.Information)
                End Try

                '============COMMENTED FOR RANGOLI RITESH KRIPLANI============
                'sql_Query = "Select Top 1 datediff( d, Sys_Time , getdate()) from tbl_CRMDetails Order by Id desc"
                'If obj.ScalarExecute(sql_Query) > 30 Then
                '    MsgBox("Please Update Software Subscription Details", MsgBoxStyle.Information)
                'End If

                'If obj.ScalarExecute(sql_Query) > 40 Then
                '    MsgBox("Software Subscription Details Not Updated", MsgBoxStyle.Information)
                '    End
                'End If
            End If

            'Add 18-02-21        
            setVersionAndDate()
        End If
    End Sub

#End Region

#Region "Function"

    Function getMacAddress()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Return nics(1).GetPhysicalAddress.ToString
    End Function

    Public Function validatePassword() As Boolean
        'If M_IsDemoSetup = True And txtUserName1.Text = "ADMIN" Then
        '    MsgBox("INVALID USERNAME OR PASSWORD", MsgBoxStyle.Critical)
        '    Return False
        'End If

        If txtUserName.Text = "ADMIN" Then
            'sql_Query = "select count(*) from tbl_UserMaster where userName='" & txtUserName.Text & "' and 'ADMIN' + UserPwd='" & txtPwd.Text & "'"
            sql_Query = "select count(*) from tbl_UserMaster where userName= N'" & txtUserName.Text & "' and 'ADMIN' + UserPwd= N'" & txtPwd.Text & "'"
        Else
            'sql_Query = "select count(*) from tbl_UserMaster where userName='" & txtUserName.Text & "' and UserPwd='" & txtPwd.Text & "'"
            sql_Query = "select count(*) from tbl_UserMaster where userName= N'" & txtUserName.Text & "' and UserPwd= N'" & txtPwd.Text & "'"
        End If
        Dim cnt As Integer = 0
        cnt = obj.ScalarExecute(sql_Query)
        Select Case cnt
            Case 0
                Return False 'Invalid User Name or Password
                Exit Select
            Case 1
                Return True 'User Name and Password Is Valid
                Exit Select
            Case Is > 1
                MsgBox("Problem In Table : User Master", MsgBoxStyle.Information)
                Return False
        End Select
    End Function

    Public Sub UpdateDB()
        Try
            If Not Directory.Exists(Application.StartupPath & "\UpdateSQL") Then
                Directory.CreateDirectory(Application.StartupPath & "\UpdateSQL")
            End If

            Dim cnt As Integer = 0
            Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\Upd.txt")
            Dim updFolderSrt As String = ""
            While reader.Peek <> -1
                If cnt > 1 Then
                    updFolderSrt = reader.ReadLine()
                End If
                cnt += 1
            End While
            reader.Close()
            Dim LastFileNo As String = obj.ScalarExecute("SELECT ConfigValue FROM dbo.tbl_Config WHERE ConfigId = 3")
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\UpdateSQL\SQLScript\" & updFolderSrt)
                Dim FileExtension As String = Path.GetExtension(foundFile)
                Try
                    If FileExtension.ToLower() = ".sql" Then
                        Using sr As StreamReader = New StreamReader(foundFile)
                            Dim FileNo As String = Path.GetFileNameWithoutExtension(foundFile)

                            If Convert.ToInt16(FileNo) > Convert.ToInt16(LastFileNo) Then
                                ' ''Dim strQry As String = ""
                                ' ''strQry = sr.ReadToEnd()
                                ' ''Dim retVal As Integer = objIM.Execute_Query(strQry)
                                Dim script As String = File.ReadAllText(foundFile)

                                Dim commandStrings As IEnumerable(Of String) = Regex.Split(script, "^\s*GO\s*$", RegexOptions.Multiline Or RegexOptions.IgnoreCase)

                                For Each commandString As String In commandStrings
                                    If commandString.Trim() <> "" Then
                                        If Not obj.QueryExecute_Script(commandString) Then
                                            Exit Sub
                                        End If
                                    End If
                                Next

                                obj.QueryExecute("UPDATE tbl_Config SET ConfigValue = " + FileNo + " WHERE ConfigId = 3")
                                LastFileNo = obj.ScalarExecute("SELECT ConfigValue FROM dbo.tbl_Config WHERE ConfigId = 3")
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString())
                End Try
            Next

            'MessageBox.Show("Database Updated Successfully.", "DB Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'txtConfirm1.Text = ""
            'pnlDbUpdateConfirm.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Public Sub generateOTP()
        Dim MaxNo As Integer = 9999
        Dim MinNo As Integer = 1000
        Dim OTPText As String = CInt(Math.Floor((MaxNo - MinNo + 1) * Rnd())) + MinNo + DateTime.Now.Second + DateTime.Now.Minute
        Dim ValidLimit As Integer = 5

        obj.Prepare("SP_Insert_OTPLogs", SpType.StoredProcedure)
        obj.AddCmdParameter("@OTPText", Dtype.varchar, OTPText, ParaDirection.Input, True)
        obj.AddCmdParameter("@GenTime", Dtype.DateTime, DateTime.Now, ParaDirection.Input, True)
        obj.AddCmdParameter("@ValidUpto", Dtype.DateTime, DateTime.Now.AddMinutes(ValidLimit), ParaDirection.Input, True)
        obj.AddCmdParameter("@TranType", Dtype.varchar, "Login OTP", ParaDirection.Input, True)
        obj.AddCmdParameter("@UserId", Dtype.int, loggedUserId, ParaDirection.Input, True)
        obj.AddCmdParameter("@IPAddress", Dtype.varchar, M_GetPCIPAddress(), ParaDirection.Input, True)
        obj.AddCmdParameter("@Sys_Time", Dtype.DateTime, DateTime.Now, ParaDirection.Input, True)
        obj.AddCmdParameter("@ValidateDtm", Dtype.int, DBNull.Value, ParaDirection.Input, True)
        obj.ExecuteCommand()

        ' Send SMS To Receiver

        If Not isInternetOn() Then
            MsgBox("Please Check Internet Connectivity for OTP Generation", MsgBoxStyle.Information)
            Exit Sub
        End If

        If UCase(M_SMSEnabled) = "YES" Then
            SmsTextOTP = obj.ScalarExecute("Select MiscName From tbl_MiscMaster Where MiscType = 'SMS (LOGIN OTP)'")
            prepareOTPSMS(OTPText)

            sendSMS(dsUserData.Tables(0).Rows(0)("MobileNo"), SmsText, Val(dsUserData.Tables(0).Rows(0)("EmailId")), "OTP")
        End If

        If UCase(M_WhatsAppEnabled) = "YES" Then
            whatsappTextOTP = "Your OTP Is " & OTPText & " For Login"

            sendWhatsApp_SendText(M_LoggedMobileNo, whatsappTextOTP, "", "No")
        End If
    End Sub

    Public Sub prepareOTPSMS(tmpOTP As String)
        SmsText = SmsTextOTP
        Dim _field, _replace As String
        While SmsText.Contains("{")
            _field = SmsText.Substring(SmsText.IndexOf("{") + 1, SmsText.IndexOf("}") - SmsText.IndexOf("{") - 1)
            _replace = SmsText.Substring(SmsText.IndexOf("{"), SmsText.IndexOf("}") - SmsText.IndexOf("{") + 1)
            Select Case _replace
                Case "{EmpName}"
                    SmsText = SmsText.Replace(_replace, loggedUser)
                    Exit Select
                Case "{OTP}"
                    SmsText = SmsText.Replace(_replace, tmpOTP)
                    Exit Select
            End Select
        End While
    End Sub

#End Region

#Region "Events"

    Private Sub txtUserName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If e.KeyChar = Chr(13) Then
            If Trim(txtUserName.Text) = "" Then
                Exit Sub
            End If
            txtPwd.Focus()
        End If
        If Not ((Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58) Or (Asc(e.KeyChar) > 64 And Asc(e.KeyChar) < 91) Or (Asc(e.KeyChar) > 96 And Asc(e.KeyChar) < 123) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            Beep()
        End If
    End Sub

    Private Sub txtPwd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPwd.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
        'If e.KeyChar = Chr(13) Then 
        '    If validatePassword() = True Then
        '        validUser = True
        '        getDept()
        '        btnLogin.Focus()
        '        'cmbDept.Focus()
        '    Else
        '        MsgBox("Invalid User Name or Password", MsgBoxStyle.Critical)
        '        txtUserName.Focus()
        '    End If
        'End If
    End Sub

    Private Sub txtPwd_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtPwd.Validating
        If validatePassword() = True Then
            validUser = True
            getDept()

            sql_Query = "Select CId from tbl_UserMaster Where UserId = " & loggedUserId
            M_CId = obj.ScalarExecute(sql_Query)

            M_LoadSettings()

            'GENERATE OTP
            If UCase(M_LoggedIsOTPRequired) = "TRUE" And M_LoggedMobileNo <> "" And ssdPC = False Then
                txtOTP.Visible = True
                generateOTP()
                txtOTP.Focus()
            Else
                btnLogin.Focus()
            End If

            'btnLogin.Focus()
            'SendKeys.Send("{Tab}")
        Else
            MsgBox("Invalid User Name or Password", MsgBoxStyle.Critical)
            txtUserName.Focus()
        End If
    End Sub

    Private Sub cmbDept_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDept.KeyPress
        If e.KeyChar = Chr(13) Then
            If Trim(cmbDept.Text) = "" Or cmbDept.SelectedIndex = -1 Then
                Exit Sub
            End If
            btnLogin.Focus()
        End If
    End Sub

    Private Sub cmbDept_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.Enter
        If validatePassword() = True Then
            validUser = True
            getDept()
            cmbDept.Focus()
        Else
            MsgBox("Invalid User Name or Password", MsgBoxStyle.Critical)
            txtUserName.Focus()
        End If
        cmbDept.DroppedDown = True
    End Sub

    Public Sub Insert_Audit_Logon(ByVal strAction As String)
        obj.Prepare("InsertAudit_Logon", SpType.StoredProcedure)
        obj.AddCmdParameter("@InsErrTimeStamp", Dtype.DateTime, M_GetServerDTM_SP(), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPCName", Dtype.varchar, M_GetPCName(), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPCIPAddress", Dtype.varchar, M_GetPCIPAddress() & "-" & currentMacIp, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsUserName", Dtype.varchar, txtUserName.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsUserPwd", Dtype.varchar, txtPwd.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAction", Dtype.varchar, strAction, ParaDirection.Input, True)
        obj.ExecuteCommand()
    End Sub

    Public Sub fetchDetailsFromServer()
        If isInternetOn() = True Then
            dsCRMDetails_Server.Clear()
            sql_Query = "Select * from tbl_LedgerMaster where DBName = '" & M_DbName & "'"
            obj.LoadData_CRM(sql_Query, dsCRMDetails_Server)
        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If validUser = True Then
            If Trim(cmbDept.Text) = "" Or cmbDept.SelectedIndex = -1 Then
                cmbDept.Focus()
                Exit Sub
            End If
            loggedUser = Trim(txtUserName.Text)

            If txtOTP.Visible = True Then
                sql_Query = "select count(0) from tbl_OTPLogs where '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:fff") & "' between GenTime and ValidUpto and TranType = 'Login OTP' and UserId = " & loggedUserId & " AND ValidateDtm IS NULL AND OTPText = '" & txtOTP.Text & "'"
                If obj.ScalarExecute(sql_Query) > 0 Then
                    sql_Query = "update tbl_OTPLogs set ValidateDtm = getdate() where '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:fff") & "' between GenTime and ValidUpto and TranType = 'Login OTP' and UserId = " & loggedUserId
                    obj.QueryExecute(sql_Query)
                Else
                    Exit Sub
                End If
            End If

            'UpdateDB()
            Insert_Audit_Session() 'Audit Trail
            Obtain_SessionId() 'Audit Trail            
            checkHDDSrNumber()
            '===
            Select Case M_SoftType
                Case "TAILORING-STD"
                    If M_DbName <> "dbSTE_Demo" Then
                        FrmMDIMain.Text = "Sunrise Tailoring Software - [" & txtUserName.Text & " @ " & cmbDept.Text & "] " & version
                    Else
                        FrmMDIMain.Text = "Sunrise Tailoring Software (Demo Version) - [" & txtUserName.Text & " @ " & cmbDept.Text & "] " & version
                    End If
                    Exit Select
                Case "TAILORING-LITE"
                    If M_DbName <> "dbSTE_Demo" Then
                        FrmMDIMain.Text = "Sunrise Tailoring Software (Lite) - [" & txtUserName.Text & " @ " & cmbDept.Text & "] " & version
                    Else
                        FrmMDIMain.Text = "Sunrise Tailoring Software (Lite) (Demo Version) - [" & txtUserName.Text & " @ " & cmbDept.Text & "] " & version
                    End If
                    Exit Select
                Case "ERP"
                    Select Case M_DbName
                        Case "dbSTE_SunriseLive"
                            FrmMDIMain.Text = "Sunrise ERP - [" & txtUserName.Text & "] " & version
                            Exit Select
                        Case Else
                            If M_DbName <> "dbSTE_Demo" Then
                                FrmMDIMain.Text = "Sunrise Tailoring ERP - [" & txtUserName.Text & " @ " & cmbDept.Text & "] " & version
                            Else
                                FrmMDIMain.Text = "Sunrise Tailoring ERP (Demo Version) - [" & txtUserName.Text & " @ " & cmbDept.Text & "] " & version
                            End If
                            Exit Select
                    End Select
                    Exit Select
                Case "SALES"
                    If M_DbName <> "dbSTE_Demo" Then
                        FrmMDIMain.Text = "Sunrise Billing Software - [" & txtUserName.Text & " @ " & cmbDept.Text & "] " & version
                    Else
                        FrmMDIMain.Text = "Sunrise Billing Software (Demo Version) - [" & txtUserName.Text & " @ " & cmbDept.Text & "] " & version
                    End If
                    Exit Select
            End Select

            If DateDiff(DateInterval.Day, Today, M_MaxDate) < 15 Then
                FrmMDIMain.Text = FrmMDIMain.Text & "                                     Days Left: " & DateDiff(DateInterval.Day, Today, M_MaxDate)
            End If

            If DateDiff(DateInterval.Day, Today, M_MaxDate) < 7 Then
                MsgBox("Days Left: " & DateDiff(DateInterval.Day, Today, M_MaxDate) & vbCrLf & "Please Contact Software Support Team", MsgBoxStyle.Information)
            End If

            If DateTime.Now > M_MaxDate Then
                insert_CRMDetails()
                setVersionAndDate()
                If DateTime.Now > M_MaxDate Then
                    MsgBox("Please Check Software Validity With Software Support Team", MsgBoxStyle.Information)
                    End
                End If
            End If

            Me.Hide()
            FrmMDIMain.Show()
            'FrmAI.Show()
        Else
            txtUserName.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim dr As DialogResult
        'dr = MsgBox("Sure To Exit ?", MsgBoxStyle.YesNo, M_TitleBarText)
        dr = MsgBox("Sure To Exit ?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            End
        Else
            txtUserName.Focus()
        End If
    End Sub

    Private Sub txtUserName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.GotFocus, txtPwd.GotFocus, cmbDept.GotFocus
        'sender.BackColor = Color.YellowGreen
    End Sub

    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' FrmPooja.Show()
        'frmSmit.Show()


        Dim dbFilePath As String = Application.StartupPath & "\Db.ini"
        If Dir(Application.StartupPath & "\Db.ini") = "" Then
            MsgBox("Db File Missing", MsgBoxStyle.Critical)
            End
        End If
        Dim dbFileNo As Integer
        dbFileNo = FreeFile()
        FileOpen(dbFileNo, dbFilePath, OpenMode.Input)
        Input(dbFileNo, dbFilePath)
        FileClose(dbFileNo)
        dbFileNo = 0

        ConStr = dbFilePath
        M_DbName = dbFilePath

        ''Add 18-02-21        
        'setVersionAndDate()

        Select Case M_SoftType
            Case "TAILORING-STD"
                Me.Text = "Sunrise Tailoring Software [User Login]"
                Exit Select
            Case "TAILORING-LITE"
                Me.Text = "Sunrise Tailoring Software (Lite) [User Login]"
                Exit Select
            Case "ERP"
                Me.Text = "Sunrise Tailoring ERP [User Login]"
                Exit Select
            Case "SALES"
                Me.Text = "Sunrise Billing Software [User Login]"
                Exit Select
        End Select

        'Comment 12/12/2024 Bcz If Connectionstring Not Proper So Login Screen not show
        '    Dim softUpDate As String = "2108"
        '    If softUpDate <> obj.ScalarExecute("Select ConfigValue From Tbl_Config Where ConfigType = 'Software Update Date' And IsActive = 'True'") Then
        '        MsgBox("Software Version Updated, Please Update Once", MsgBoxStyle.Information)
        '        'End
        '    End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub llWebsite_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llWebsite.LinkClicked
        llWebsite.LinkVisited = True
        System.Diagnostics.Process.Start("https://www.sunrisesoftware.in")
    End Sub

    Private Sub UpdateSoftwareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateSoftwareToolStripMenuItem.Click

        M_UpdateSoftware()


        'Dim dr As DialogResult
        'dr = MsgBox("Sure To Update Software ?", MsgBoxStyle.YesNo)
        'If dr = Windows.Forms.DialogResult.Yes Then
        '    If Not Directory.Exists(Application.StartupPath & "\UpdateExe") Then
        '        Directory.CreateDirectory(Application.StartupPath & "\UpdateExe")
        '    End If

        '    If Not Directory.Exists(Application.StartupPath & "\UpdateSQL") Then
        '        Directory.CreateDirectory(Application.StartupPath & "\UpdateSQL")
        '    End If

        '    If Not Directory.Exists(Application.StartupPath & "\UpdateReport") Then
        '        Directory.CreateDirectory(Application.StartupPath & "\UpdateReport")
        '    End If

        '    For Each filepath As String In Directory.GetFiles(Application.StartupPath & "\UpdateExe")
        '        File.Delete(filepath)
        '    Next

        '    For Each dir As String In Directory.GetDirectories(Application.StartupPath & "\UpdateExe")
        '        Directory.Delete(dir, True)
        '    Next

        '    For Each filepath As String In Directory.GetFiles(Application.StartupPath & "\UpdateSQL")
        '        File.Delete(filepath)
        '    Next

        '    For Each dir As String In Directory.GetDirectories(Application.StartupPath & "\UpdateSQL")
        '        Directory.Delete(dir, True)
        '    Next

        '    For Each filepath As String In Directory.GetFiles(Application.StartupPath & "\UpdateReport")
        '        File.Delete(filepath)
        '    Next

        '    For Each dir As String In Directory.GetDirectories(Application.StartupPath & "\UpdateReport")
        '        Directory.Delete(dir, True)
        '    Next

        '    Dim updFolderExe As String = ""
        '    Dim updFolderSrt As String = ""
        '    Dim updFolderRpt As String = ""
        '    Dim killExeName As String = ""
        '    Dim cnt As Integer = 0
        '    Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\Upd.txt")

        '    While reader.Peek <> -1
        '        If cnt = 0 Then
        '            killExeName = reader.ReadLine()
        '        ElseIf cnt = 1 Then
        '            updFolderExe = reader.ReadLine()
        '        ElseIf cnt = 2 Then
        '            updFolderSrt = reader.ReadLine()
        '        Else
        '            updFolderRpt = reader.ReadLine()
        '        End If
        '        cnt += 1
        '    End While

        '    reader.Close()
        '    Dim filename As String = Path.Combine(Application.StartupPath, "SmartUpdate.exe")
        '    Dim proc = System.Diagnostics.Process.Start(filename, killExeName & " " & updFolderExe & " " & updFolderSrt & " " & updFolderRpt)
        'End If
    End Sub

    Private Sub UpdateDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateDatabseToolStripMenuItem.Click
        M_UpdateDatabase()

        'Dim dr As DialogResult
        'dr = MsgBox("Sure To Update Database ?", MsgBoxStyle.YesNo)
        'If dr = Windows.Forms.DialogResult.Yes Then
        '    If Not Directory.Exists(Application.StartupPath & "\UpdateSQL") Then
        '        Directory.CreateDirectory(Application.StartupPath & "\UpdateSQL")
        '    End If

        '    Dim cnt As Integer = 0
        '    Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\Upd.txt")
        '    Dim updFolderSrt As String = ""
        '    Dim updFolderExe As String = ""
        '    Dim updFolderRpt As String = ""
        '    Dim killExeName As String = ""

        '    'While reader.Peek <> -1
        '    '    If cnt > 1 Then
        '    '        updFolderSrt = reader.ReadLine()
        '    '    End If
        '    '    cnt += 1
        '    'End While

        '    While reader.Peek <> -1
        '        If cnt = 0 Then
        '            killExeName = reader.ReadLine()
        '        ElseIf cnt = 1 Then
        '            updFolderExe = reader.ReadLine()
        '        ElseIf cnt = 2 Then
        '            updFolderSrt = reader.ReadLine()
        '        Else
        '            updFolderRpt = reader.ReadLine()
        '        End If
        '        cnt += 1
        '    End While

        '    reader.Close()

        '    For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\UpdateSQL\SQLScript\" & updFolderSrt)
        '        Dim FileExtension As String = Path.GetExtension(foundFile)
        '        Try
        '            If FileExtension.ToLower() = ".sql" Then
        '                Using sr As StreamReader = New StreamReader(foundFile)
        '                    Dim FileNo As String = Path.GetFileNameWithoutExtension(foundFile)
        '                    Dim LastFileNo As String = obj.ScalarExecute("SELECT ConfigValue FROM dbo.tbl_Config WHERE ConfigId = 3")
        '                    If Convert.ToInt16(FileNo) > Convert.ToInt16(LastFileNo) Then
        '                        Dim script As String = File.ReadAllText(foundFile)

        '                        Dim commandStrings As IEnumerable(Of String) = Regex.Split(script, "^\s*GO\s*$", RegexOptions.Multiline Or RegexOptions.IgnoreCase)

        '                        For Each commandString As String In commandStrings
        '                            If commandString.Trim() <> "" Then
        '                                If Not obj.QueryExecute_Script(commandString) Then
        '                                    Exit Sub
        '                                End If
        '                            End If
        '                        Next

        '                        obj.QueryExecute("UPDATE tbl_Config SET ConfigValue = " + FileNo + " WHERE ConfigId = 3")
        '                    End If
        '                End Using
        '            End If
        '        Catch ex As Exception
        '            MessageBox.Show(ex.Message.ToString())
        '        End Try
        '    Next

        '    MessageBox.Show("Database Updated Successfully.", "DB Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub SyncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SyncToolStripMenuItem.Click
        insert_CRMDetails()
        MessageBox.Show("Done", "Update Subscription Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub UpdateReportFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateReportFileToolStripMenuItem.Click
        M_UpdateReport()

        'Dim dr As DialogResult
        'dr = MsgBox("Sure To Update Report File ?", MsgBoxStyle.YesNo)
        'If dr = Windows.Forms.DialogResult.Yes Then
        '    If Not Directory.Exists(Application.StartupPath & "\UpdateReport") Then
        '        Directory.CreateDirectory(Application.StartupPath & "\UpdateReport")
        '    End If

        '    Dim cnt As Integer = 0
        '    Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\Upd.txt")
        '    Dim updFolderRpt As String = ""
        '    While reader.Peek <> -1
        '        If cnt > 1 Then
        '            updFolderRpt = reader.ReadLine()
        '        End If
        '        cnt += 1
        '    End While
        '    reader.Close()

        '    For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\UpdateReport\ReportFile\" & updFolderRpt)
        '        Dim FileExtension As String = Path.GetExtension(foundFile)
        '        Try
        '            If FileExtension.ToLower() = ".mrt" Or FileExtension.ToLower() = ".rpt" Or FileExtension.ToLower() = ".xml" Then
        '                If FileExtension.ToLower() = ".xml" Then
        '                    File.Copy(foundFile, Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "Report\GridLayout" & "\\" + Path.GetFileName(foundFile), True)
        '                Else
        '                    File.Copy(foundFile, Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "Report" & "\\" + Path.GetFileName(foundFile), True)
        '                End If

        '            End If
        '        Catch ex As Exception
        '            MessageBox.Show(ex.Message.ToString())
        '        End Try
        '    Next
        '    MessageBox.Show("Report File Updated Successfully.", "Report File Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub Extend20252026ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Extend20252026ToolStripMenuItem.Click
        sql_Query = "Select Count(*) From tbl_FinancialYearMaster Where YrText = '2025 - 2026'"
        If obj.ScalarExecute(sql_Query) = 0 Then
            sql_Query = " CREATE TABLE [dbo].[tbl_LedgerOpeningBalance_2025]( " _
                & " [LedgerId] [int] NOT NULL, " _
                & " [DrOpening] [float] NULL, " _
                & " [CrOpening] [float] NULL, " _
                & " [DrCr] [varchar](2) NULL, " _
                & " [LastYrDr] [float] NULL, " _
                & " [LastYrCr] [float] NULL, " _
                & " [Remark] [varchar](50) NULL, " _
                & "  CONSTRAINT [PK_tbl_LedgerOpeningBalance_2025] PRIMARY KEY CLUSTERED  " _
                & " ([LedgerId] ASC) " _
                & " WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] " _
                & "  "
            obj.QueryExecute(sql_Query)

            sql_Query = "update tbl_FinancialYearMaster set DispOrder = DispOrder + 1"
            obj.QueryExecute(sql_Query)

            sql_Query = "insert into tbl_FinancialYearMaster " _
                & " (FinYrFrom, FinYrTo, FinYrFrom_WH, FinYrTo_WH, YrText, YrSuffix, DeptName, DispOrder, StockYrId, StockYrFrom) values " _
                & " ('04/01/2025', '03/31/2026', '01/01/2025', '12/31/2025', '2025 - 2026', '2025', 'ACCOUNTS', '0', 9, '01/01/2021') "
            obj.QueryExecute(sql_Query)

            sql_Query = "update tbl_settings " _
                & " set SettingValue ='01/04/2025' " _
                & " where settingname = 'New Invoice Number Generation Date (dd/MM/yyyy)' And SettingValue ='01/04/2024'"
            obj.QueryExecute(sql_Query)

            MsgBox("Done", MsgBoxStyle.Information)
        Else
            MsgBox("Might Be Done, Please Check", MsgBoxStyle.Information)
        End If
    End Sub


    Private Sub Extend20242025ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Extend20242025ToolStripMenuItem.Click
        sql_Query = "Select Count(*) From tbl_FinancialYearMaster Where YrText = '2024 - 2025'"
        If obj.ScalarExecute(sql_Query) = 0 Then
            sql_Query = " CREATE TABLE [dbo].[tbl_LedgerOpeningBalance_2024]( " _
                & " [LedgerId] [int] NOT NULL, " _
                & " [DrOpening] [float] NULL, " _
                & " [CrOpening] [float] NULL, " _
                & " [DrCr] [varchar](2) NULL, " _
                & " [LastYrDr] [float] NULL, " _
                & " [LastYrCr] [float] NULL, " _
                & " [Remark] [varchar](50) NULL, " _
                & "  CONSTRAINT [PK_tbl_LedgerOpeningBalance_2024] PRIMARY KEY CLUSTERED  " _
                & " ([LedgerId] ASC) " _
                & " WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] " _
                & "  "
            obj.QueryExecute(sql_Query)

            sql_Query = "update tbl_FinancialYearMaster set DispOrder = DispOrder + 1"
            obj.QueryExecute(sql_Query)

            sql_Query = "insert into tbl_FinancialYearMaster " _
                & " (FinYrFrom, FinYrTo, FinYrFrom_WH, FinYrTo_WH, YrText, YrSuffix, DeptName, DispOrder, StockYrId, StockYrFrom) values " _
                & " ('04/01/2024', '03/31/2025', '01/01/2024', '12/31/2024', '2024 - 2025', '2024', 'ACCOUNTS', '0', 9, '01/01/2021') "
            obj.QueryExecute(sql_Query)

            sql_Query = "update tbl_settings " _
                & " set SettingValue ='01/04/2024' " _
                & " where settingname = 'New Invoice Number Generation Date (dd/MM/yyyy)' And SettingValue ='01/04/2023'"
            obj.QueryExecute(sql_Query)

            MsgBox("Done", MsgBoxStyle.Information)
        Else
            MsgBox("Might Be Done, Please Check", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtOTP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOTP.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtUserName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUserName.Validating
        If txtUserName.Text = "SQLINSTALL" Then
            Dim dr As DialogResult
            dr = MsgBox("Sure To Install ?", MsgBoxStyle.YesNo)
            If dr = Windows.Forms.DialogResult.Yes Then
                installSQL()
            Else
                txtUserName.Text = ""
            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ContextMenuStrip1.Show()
    End Sub



    Private Sub txtConfirm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Public Sub installSQL()
        ' Specify the path to the SQL Server installer
        Dim sqlServerInstallerPath As String = Application.StartupPath & "\SQL2019-SSEI-Expr.exe"

        ' Specify the path to the configuration file
        Dim configFile As String = Application.StartupPath & "\SQLExpress_Configuration.ini"

        ' Start the SQL Server installer process
        Dim processInfo As New ProcessStartInfo()
        processInfo.FileName = sqlServerInstallerPath
        processInfo.Arguments = $"/q /ConfigurationFile={configFile}"
        processInfo.WindowStyle = ProcessWindowStyle.Hidden ' Hide the installer window

        Try
            Dim installProcess As Process = Process.Start(processInfo)
            installProcess.WaitForExit() ' Wait for the installation process to complete

            MessageBox.Show("SQL Server installation completed successfully.", "Installation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error occurred while installing SQL Server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region


End Class