Imports System.IO
Imports Sunrise.TailoringERP.DB
Imports DevExpress.Utils
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Columns
Imports TailoringERP.TailoringERP.DB
Imports System.Data.SqlClient

Public Class FrmContactMaster
#Region "Declerations"
    Dim con As New SqlClient.SqlConnection("Data Source=LAPTOP-1JDD0U0U\SUNRISE;Initial Catalog=dbSTE_Demo;Integrated Security=True;TrustServerCertificate=True;")
    Dim cmd As New SqlClient.SqlCommand()
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim obj As New DBManager
    Dim sql_query As String
    Dim edit_ins As Integer = -1   ' 1 ->  add    0-> edit   -1 -> default
    Dim dtGridSource As New DataTable

    'Dim existCode, existBarCode, existDesignNo As String
    'Dim oldCode As String
    'Dim point As Boolean = False
    'Dim minus As Boolean = False
    'Dim dsUISetting As New Data.DataSet
    'Dim prnCode, LabelText As String
    'Dim flgIsAll As Boolean = False
    'Dim dsReportQuery As New Data.DataSet

    'Dim dsItemType As DataSet
    'Dim dsItemCategory As New DataSet
    'Dim dsItemSubCategory As New DataSet
    'Dim dsMfgName As DataSet
    'Dim dsSupplier As DataSet
    'Dim dsItemSize As DataSet
    'Dim dsItemSizeRange As DataSet
    'Dim dsItemColor As New DataSet
    'Dim ItemFormula, MiscItemFormula, MiscItemFormula_Text As String
    'Dim dtBWRate As DataTable

    Public strParam As String = ""
    Public strInitial As String = ""

    ''Public uploadExcel As Boolean = False
    ''Dim dvMiscMaster As New DataView(dsMiscMaster.Tables(0))
    ''Dim uploadType As String
    ''Dim UpdFromExcel As Boolean = False

#End Region



#Region "Methods"

    Private Function validateData() As Boolean

        Dim contact As String = txtContactNo.Text.Trim()

        If contact = "" Then
            MsgBox("Contact Number is required.", MsgBoxStyle.Exclamation)
            txtContactNo.Focus()
            Return False
        End If

        If Not IsNumeric(contact) Then
            MsgBox("Contact Number must contain digits only.", MsgBoxStyle.Exclamation)
            txtContactNo.Focus()
            Return False
        End If

        If contact.Length <> 10 Then
            MsgBox("Contact Number must be exactly 10 digits.", MsgBoxStyle.Exclamation)
            txtContactNo.Focus()
            Return False
        End If


        If txtName.Text.Trim() = "" Then
            MsgBox("Person Name is required.", MsgBoxStyle.Exclamation)
            txtName.Focus()
            Return False
        End If



        If txtEmailID.Text.Trim() <> "" AndAlso Not txtEmailID.Text.Contains("@") Then
            MsgBox("Invalid Email ID.", MsgBoxStyle.Exclamation)
            txtEmailID.Focus()
            Return False
        End If

        Return True

    End Function

    Public Sub saveData()
        If edit_ins = -1 Then Exit Sub
        If Not validateData() Then Exit Sub

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim Birthday As Object = If(dtpBirthDate.Checked, dtpBirthDate.Value.Date, DBNull.Value)
            Dim LedgerID As Object = If(cmbLedgerID.SelectedIndex >= 0, Val(cmbLedgerID.SelectedValue), DBNull.Value)

            If edit_ins = 1 Then

                sql_query = "
                INSERT INTO ContactMaster
                (ContactNo, PersonName, CompanyName, Designation, EmailId,
                 WorkNotes, LedgerID, Birthday, Remark1, Remark2,
                 ContactType, Broadcast, CreatedBy, CreatedOn, CreatedFrom)
                VALUES
                (@ContactNo, @PersonName, @CompanyName, @Designation, @EmailId,
                 @WorkNotes, @LedgerID, @Birthday, @Remark1, @Remark2,
                 @ContactType, @Broadcast, @CreatedBy, @CreatedOn, @CreatedFrom)
            "

                cmd = New SqlCommand(sql_query, con)
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim())
                cmd.Parameters.AddWithValue("@PersonName", txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.Trim())
                cmd.Parameters.AddWithValue("@Designation", cmbDesignation.Text)
                cmd.Parameters.AddWithValue("@EmailId", txtEmailID.Text.Trim())
                cmd.Parameters.AddWithValue("@WorkNotes", txtworkNotes.Text.Trim())
                cmd.Parameters.AddWithValue("@LedgerID", LedgerID)
                cmd.Parameters.AddWithValue("@Birthday", Birthday)
                cmd.Parameters.AddWithValue("@Remark1", txtRemark1.Text.Trim())
                cmd.Parameters.AddWithValue("@Remark2", txtRemark2.Text.Trim())
                cmd.Parameters.AddWithValue("@ContactType", cmbContactType.Text)
                cmd.Parameters.AddWithValue("@Broadcast", cmbBroadcast.Text)
                cmd.Parameters.AddWithValue("@CreatedBy", 1) ' USER ID
                cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now)
                cmd.Parameters.AddWithValue("@CreatedFrom", Environment.MachineName)

                cmd.ExecuteNonQuery()
                MsgBox("Contact saved successfully.", MsgBoxStyle.Information)

            End If


            If edit_ins = 0 Then

                If lblContactId.Text.Trim() = "" Then
                    MsgBox("Invalid record selected.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                sql_query = "
                UPDATE ContactMaster SET
                    ContactNo = @ContactNo,
                    PersonName = @PersonName,
                    CompanyName = @CompanyName,
                    Designation = @Designation,
                    EmailId = @EmailId,
                    WorkNotes = @WorkNotes,
                    LedgerID = @LedgerID,
                    Birthday = @Birthday,
                    Remark1 = @Remark1,
                    Remark2 = @Remark2,
                    ContactType = @ContactType,
                    Broadcast = @Broadcast
                WHERE ContactId = @ContactId
            "

                cmd = New SqlCommand(sql_query, con)
                cmd.Parameters.AddWithValue("@ContactId", lblContactId.Text)
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim())
                cmd.Parameters.AddWithValue("@PersonName", txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.Trim())
                cmd.Parameters.AddWithValue("@Designation", cmbDesignation.Text)
                cmd.Parameters.AddWithValue("@EmailId", txtEmailID.Text.Trim())
                cmd.Parameters.AddWithValue("@WorkNotes", txtworkNotes.Text.Trim())
                cmd.Parameters.AddWithValue("@LedgerID", LedgerID)
                cmd.Parameters.AddWithValue("@Birthday", Birthday)
                cmd.Parameters.AddWithValue("@Remark1", txtRemark1.Text.Trim())
                cmd.Parameters.AddWithValue("@Remark2", txtRemark2.Text.Trim())
                cmd.Parameters.AddWithValue("@ContactType", cmbContactType.Text)
                cmd.Parameters.AddWithValue("@Broadcast", cmbBroadcast.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Contact updated successfully.", MsgBoxStyle.Information)

            End If

        Catch ex As Exception
            MsgBox("Error saving data: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try


    End Sub

    Public Sub LoadLedgerCombo()

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sql As String =
            "SELECT LedgerId, LedgerName 
             FROM tbl_LedgerMaster 
             WHERE IsActive = 1 OR IsActive IS NULL 
             ORDER BY LedgerName"

            Dim dtLedger As New DataTable
            Using daLedger As New SqlDataAdapter(sql, con)
                daLedger.Fill(dtLedger)
            End Using

            cmbLedgerID.DataSource = dtLedger
            cmbLedgerID.DisplayMember = "LedgerName"
            cmbLedgerID.ValueMember = "LedgerId"
            cmbLedgerID.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("Error loading ledger list: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try

    End Sub

    Public Sub LoadCombo(cmb As ComboBox, values As String())

        cmb.DataSource = Nothing
        cmb.Items.Clear()

        cmb.Items.AddRange(values)

        cmb.SelectedIndex = 0   ' Default selection

    End Sub

    Public Sub ReloadGridData()

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sql As String =
            "SELECT ContactId, PersonName, ContactNo, CompanyName,
                    Designation, ContactType, Broadcast, LedgerID
             FROM ContactMaster
             ORDER BY PersonName"

            Using da As New SqlDataAdapter(sql, con)
                dtGridSource.Clear()
                da.Fill(dtGridSource)
            End Using

            gcData.DataSource = dtGridSource
            gvData.BestFitColumns()

        Catch ex As Exception
            MsgBox("Error reloading grid data: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try

    End Sub




    Public Sub DeleteData()

        If lblContactId.Text.Trim() = "" Then
            MsgBox("Please select a record to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim dr As DialogResult =
        MsgBox("Are you sure you want to delete this contact?",
               MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        If dr = DialogResult.No Then Exit Sub

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sql As String = "DELETE FROM ContactMaster WHERE ContactId = @ContactId"

            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@ContactId", lblContactId.Text)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Contact deleted successfully.", MsgBoxStyle.Information)

            clearFields_NewState()
            loadGridData()

        Catch ex As Exception
            MsgBox("Error deleting record: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try

    End Sub


    Public Sub loadGridData()

        Try
            da = New SqlDataAdapter("
            SELECT ContactId, PersonName, ContactNo, CompanyName,
                   Designation, ContactType, Broadcast
            FROM ContactMaster
            ORDER BY PersonName", con)

            dt = New DataTable
            da.Fill(dt)
            gcData.DataSource = dt

            gvData.Columns("ContactId").Visible = False
        Catch ex As Exception
            MsgBox("Error loading grid: " & ex.Message)
        End Try


    End Sub


    Public Sub clearFields_NewState()
        edit_ins = -1

        gbMainDetail.Enabled = False
        gcData.Enabled = True

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
        btnAdd.Focus()

        txtName.Clear()
        txtContactNo.Clear()
        txtCompanyName.Clear()
        txtEmailID.Clear()
        txtworkNotes.Clear()
        txtRemark1.Clear()
        txtRemark2.Clear()

        dtpBirthDate.ResetText()
        If cmbContactType.Items.Count > 0 Then cmbContactType.SelectedIndex = 0
        If cmbDesignation.Items.Count > 0 Then cmbDesignation.SelectedIndex = 0
        If cmbLedgerID.Items.Count > 0 Then cmbLedgerID.SelectedIndex = 0
        If cmbBroadcast.Items.Count > 0 Then cmbBroadcast.SelectedIndex = 0




        Try


        Catch ex As Exception

        End Try
    End Sub

    Public Sub closeClickTime()
        If edit_ins = -1 Then
            Me.Close()
        Else
            Dim dr As DialogResult
            dr = MsgBox("Sure To Exit Without Saving Data ?", MsgBoxStyle.YesNo)
            If dr = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If
        M_SalesItemMasterF2 = False
    End Sub

    Public Sub cancelClickTime()
        clearFields_NewState()
    End Sub

    Public Sub saveClickTime()
        SaveData()
        clearFields_NewState()
    End Sub

    Public Sub addClickTime()


        gbMainDetail.Enabled = True
        gcData.Enabled = False

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True

        edit_ins = 1
    End Sub

    Public Sub deleteClickTime()
        DeleteData()
        clearFields_NewState()
    End Sub

    Public Sub editClickTime()
        gbMainDetail.Enabled = True
        gcData.Enabled = False

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
        edit_ins = 0
        'oldCode = Trim(txtTItemCode.Text)
    End Sub

    Public Sub ClearSearch()
        txtSName.Clear()
        txtSMobileNo.Clear()
        gcData.DataSource = dtGridSource

    End Sub

    Private Sub ApplySearchFilter()

        If dtGridSource.Rows.Count = 0 Then Exit Sub

        Dim filter As String = "1=1"

        'Search by Name
        If txtSName.Text.Trim() <> "" Then
            filter &= " AND PersonName LIKE '%" &
                  txtSName.Text.Trim().Replace("'", "''") & "%'"
        End If

        'Search by Mobile No
        If txtSMobileNo.Text.Trim() <> "" Then
            filter &= " AND ContactNo LIKE '%" &
                  txtSMobileNo.Text.Trim().Replace("'", "''") & "%'"
        End If

        Dim dv As New DataView(dtGridSource)
        dv.RowFilter = filter
        gcData.DataSource = dv

    End Sub





#End Region

#Region "Events"



    Private Sub FrmContactMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombo(cmbContactType, {"-- Select --", "Customer", "Supplier", "Employee", "Other"})
        LoadCombo(cmbDesignation, {"-- Select --", "Manager", "Sales", "Accountant", "Admin"})
        LoadCombo(cmbBroadcast, {"-- Select --", "Broadcast 1", "Broadcast 2", "Broadcast 3", "broadcast 4", "No Broadcast"})

        LoadLedgerCombo()

        loadGridData()
        clearFields_NewState()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        addClickTime()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        editClickTime()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveClickTime()
        ReloadGridData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        deleteClickTime()
        ReloadGridData()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cancelClickTime()
        ClearSearch()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        closeClickTime()
    End Sub




    Private Sub gvData_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles gvData.RowClick

        If gvData.FocusedRowHandle < 0 Then Exit Sub

        lblContactId.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "ContactId").ToString()
        txtName.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "PersonName").ToString()
        txtContactNo.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "ContactNo").ToString()
        txtCompanyName.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "CompanyName").ToString()
        cmbDesignation.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "Designation").ToString()
        cmbContactType.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "ContactType").ToString()
        cmbBroadcast.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "Broadcast").ToString()

        btnEdit.Enabled = True
        btnDelete.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReloadGridData()
        ClearSearch()
    End Sub

    Private Sub txtSName_TextChanged(sender As Object, e As EventArgs) Handles txtSName.TextChanged
        ApplySearchFilter()
    End Sub

    Private Sub txtSMobileNo_TextChanged(sender As Object, e As EventArgs) Handles txtSMobileNo.TextChanged
        ApplySearchFilter()
    End Sub






#End Region
End Class