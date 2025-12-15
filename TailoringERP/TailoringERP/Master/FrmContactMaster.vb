Imports System.IO
Imports System.Data
Imports Sunrise.TailoringERP.DB
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports TailoringERP.TailoringERP.DB
Imports System.Windows.Forms

Public Class FrmContactMaster

#Region "Declerations"
    Dim sql_query As String
    Dim obj As New DBManager
    Dim dtGridSource As New DataTable
    Dim edit_ins As Integer = -1 '1 -> add, 0 -> edit, -1 -> idle
    Dim clickedColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
#End Region

#Region "Methods / Functions"

    'Private Sub cmbMiscMaster()
    '    Dim data As New Dictionary(Of String, String()) From {
    '        {"ContactType", New String() {"Customer", "Supplier", "Employee", "Other"}},
    '        {"Broadcast", New String() {"Broadcast 1", "Broadcast 2", "Broadcast 3", "No Broadcast"}},
    '        {"Designation", New String() {"Manager", "Sales", "Accountant", "Admin"}}
    '    }

    '    For Each item In data
    '        For i As Integer = 0 To item.Value.Length - 1
    '            obj.Prepare(" IF NOT EXISTS (SELECT 1 FROM tbl_MiscMaster WHERE MiscType = @MiscType AND MiscName = @MiscName)INSERT INTO tbl_MiscMaster (MiscType, MiscName, DispSrNo, IsActive) VALUES (@MiscType, @MiscName, @DispSrNo, 1)", SpType.SQL)

    '            obj.AddCmdParameter("@MiscType", Dtype.nvarchar, item.Key, ParaDirection.Input, True)
    '            obj.AddCmdParameter("@MiscName", Dtype.nvarchar, item.Value(i), ParaDirection.Input, True)
    '            obj.AddCmdParameter("@DispSrNo", Dtype.int, i + 1, ParaDirection.Input, True)

    '            obj.ExecuteCommand()
    '        Next
    '    Next

    'End Sub

    'Private Sub cmbLoadMiscMater(cmb As ComboBox, miscType As String)
    '    Dim ds As New DataSet

    '    obj.Prepare("SELECT MiscId, MiscName FROM tbl_MiscMaster Where MiscType = @MiscType AND isActive = 1 ORDER BY DispSrNo, MiscName", SpType.SQL)
    '    obj.AddCmdParameter("@MiscType", Dtype.nvarchar, miscType, ParaDirection.Input, True)
    '    'obj.LoadData123("SELECT", ds)
    '    obj.ExecuteCommand()

    '    cmb.DataSource = Nothing

    '    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
    '        cmb.DataSource = ds.Tables(0)
    '        cmb.DisplayMember = "MiscName"
    '        cmb.ValueMember = "MiscId"
    '        cmb.SelectedIndex = -1
    '    End If
    'End 

    Private Sub comboFill(ByVal cmb As ComboBox, ByVal sql As String)
        Dim dsItemType As New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsItemType)
        cmb.DataSource = dsItemType.Tables(0).DefaultView
        cmb.ValueMember = dsItemType.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsItemType.Tables(0).Columns(1).ToString
    End Sub



    Private Function IsDuplicateContact(contactNo As String, Optional contactId As Integer = 0) As Boolean
        'sql_query = "SELECT COUNT(*) FROM ContactMaster WHERE ContactNo = @ContactNo AND ContactId <> @ContactId"
        obj.Prepare("SELECT COUNT(*) FROM ContactMaster WHERE ContactNo = @ContactNo AND ContactId <> @ContactId", SpType.SQL)
        obj.AddCmdParameter("@ContactNo", Dtype.varchar, contactNo, ParaDirection.Input, True)
        obj.AddCmdParameter("@ContactId", Dtype.int, contactId, ParaDirection.Input, True)
        'Dim count = obj.ScalarExecute(sql_query)
        Dim count = obj.ExecuteCommand_GET()
        Return count > 0
    End Function

    Private Function IsDuplicateName(name As String, Optional contactId As Integer = 0) As Boolean
        'sql_query = "SELECT COUNT(*) FROM ContactMaster WHERE PersonName = @PersonName AND ContactId <> @ContactId"
        obj.Prepare("SELECT COUNT(*) FROM ContactMaster WHERE PersonName = @PersonName AND ContactId <> @ContactId", SpType.SQL)
        obj.AddCmdParameter("@PersonName", Dtype.nvarchar, name, ParaDirection.Input, True)
        obj.AddCmdParameter("@ContactId", Dtype.int, contactId, ParaDirection.Input, True)
        'Dim count = obj.ScalarExecute(sql_query)
        Dim count = obj.ExecuteCommand_get()
        Return count > 0
    End Function

    Private Function ValidateData() As Boolean
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
            MsgBox("Please Specify 10 digits mobile number.", MsgBoxStyle.Exclamation)
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

        If IsDuplicateContact(contact, Val(lblContactId.Text)) Then
            MsgBox("This Contact Number already exists!", MsgBoxStyle.Critical)
            txtContactNo.Focus()
            Return False
        End If

        If IsDuplicateName(txtName.Text.Trim(), Val(lblContactId.Text)) Then
            MsgBox("This Name already exists!", MsgBoxStyle.Critical)

            If MsgBox("The Name Already exists Do You want to change Existing data?", MsgBoxStyle.YesNo) = DialogResult.Yes Then

            End If
            txtName.Focus()
                Return False
            End If

            Return True
    End Function

    Private Function GetBirthDateValue() As Object
        Return If(dtpBirthDate.Checked, CType(dtpBirthDate.Value, Object), DBNull.Value)
    End Function

    Private Function GetLedgerIdValue() As Object
        If cmbLedgerID.SelectedIndex >= 0 AndAlso cmbLedgerID.SelectedValue IsNot Nothing Then
            Return cmbLedgerID.SelectedValue
        End If
        Return DBNull.Value
    End Function

    Private Sub LoadCombo(cmb As ComboBox, values As String())
        cmb.DataSource = Nothing
        cmb.Items.Clear()
        cmb.Items.AddRange(values)
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
    End Sub

    Private Sub LoadLedgerCombo()
        Dim ds As New DataSet
        obj.Prepare("SELECT LedgerId, LedgerName FROM tbl_LedgerMaster WHERE G_Id = 11 ORDER BY LedgerName", SpType.SQL)
        obj.LoadData("SELECT LedgerId, LedgerName FROM tbl_LedgerMaster WHERE G_Id = 11 ORDER BY LedgerName", ds)
        If ds.Tables.Count > 0 Then
            cmbLedgerID.DataSource = ds.Tables(0)
            cmbLedgerID.DisplayMember = "LedgerName"
            cmbLedgerID.ValueMember = "LedgerId"
            cmbLedgerID.SelectedIndex = -1
        End If
    End Sub

    Private Sub SaveData()
        If edit_ins = -1 Then Exit Sub
        'If Not ValidateData() Then Exit Sub

        Try
            If edit_ins = 1 Then
                obj.Prepare("SP_ContactMaster_Insert", SpType.StoredProcedure)
                obj.AddCmdParameter("@ContactNo", Dtype.varchar, txtContactNo.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@PersonName", Dtype.nvarchar, txtName.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@CompanyName", Dtype.nvarchar, txtCompanyName.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Designation", Dtype.varchar, cmbDesignation.Text, ParaDirection.Input, True)
                obj.AddCmdParameter("@EmailId", Dtype.varchar, txtEmailID.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@WorkNotes", Dtype.nvarchar, txtworkNotes.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@LedgerId", Dtype.int, GetLedgerIdValue(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Birthday", Dtype.DateTime, GetBirthDateValue(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Remark1", Dtype.nvarchar, txtRemark1.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Remark2", Dtype.nvarchar, txtRemark2.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@ContactType", Dtype.nvarchar, cmbContactType.Text, ParaDirection.Input, True)
                obj.AddCmdParameter("@Broadcast", Dtype.nvarchar, cmbBroadcast.Text, ParaDirection.Input, True)
                obj.AddCmdParameter("@CreatedBy", Dtype.int, loggedUserId, ParaDirection.Input, True)
                obj.AddCmdParameter("@CreatedOn", Dtype.DateTime, Date.Now, ParaDirection.Input, True)
                obj.AddCmdParameter("@CreatedFrom", Dtype.nvarchar, Environment.MachineName, ParaDirection.Input, True)
            Else
                If lblContactId.Text.Trim() = "" Then
                    MsgBox("Invalid record selected.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                obj.Prepare("SP_ContactMaster_Update", SpType.StoredProcedure)
                obj.AddCmdParameter("@ContactId", Dtype.int, Val(lblContactId.Text), ParaDirection.Input, True)
                obj.AddCmdParameter("@ContactNo", Dtype.varchar, txtContactNo.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@PersonName", Dtype.nvarchar, txtName.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@CompanyName", Dtype.nvarchar, txtCompanyName.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Designation", Dtype.varchar, cmbDesignation.Text, ParaDirection.Input, True)
                obj.AddCmdParameter("@EmailId", Dtype.varchar, txtEmailID.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@WorkNotes", Dtype.nvarchar, txtworkNotes.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@LedgerId", Dtype.int, GetLedgerIdValue(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Birthday", Dtype.DateTime, GetBirthDateValue(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Remark1", Dtype.nvarchar, txtRemark1.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Remark2", Dtype.nvarchar, txtRemark2.Text.Trim(), ParaDirection.Input, True)
                obj.AddCmdParameter("@ContactType", Dtype.nvarchar, cmbContactType.Text, ParaDirection.Input, True)
                obj.AddCmdParameter("@Broadcast", Dtype.nvarchar, cmbBroadcast.Text, ParaDirection.Input, True)
            End If

            obj.ExecuteCommand()
            MsgBox("Contact saved successfully.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error saving data: " & ex.Message, MsgBoxStyle.Critical)
            obj.LogError(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub DeleteData()
        If lblContactId.Text.Trim() = "" Then
            MsgBox("Please select a record to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this contact?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            obj.Prepare("SP_ContactMaster_Delete", SpType.StoredProcedure)
            obj.AddCmdParameter("@ContactId", Dtype.int, Val(lblContactId.Text), ParaDirection.Input, True)
            obj.ExecuteCommand()
            MsgBox("Contact deleted successfully.", MsgBoxStyle.Information)
            ClearFieldsNewState()
            LoadGridData()
        Catch ex As Exception
            MsgBox("Error deleting record: " & ex.Message, MsgBoxStyle.Critical)
            obj.LogError(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridData()

        Dim ds As New DataSet
        obj.Prepare("SP_ContactMaster_Select", SpType.StoredProcedure)
        obj.AddCmdParameter("@Name", Dtype.nvarchar, txtSName.Text.Trim(), ParaDirection.Input, True)
        obj.AddCmdParameter("@Mobile", Dtype.varchar, txtSMobileNo.Text.Trim(), ParaDirection.Input, True)
        obj.LoadData123("SP_ContactMaster_Select", ds)


        If ds.Tables.Count > 0 Then
            dtGridSource = ds.Tables(0)
            gcData.DataSource = dtGridSource
            RestoreLayout(gvData, "Sales_Item_Master_Grid")
            gvData.BestFitColumns()
            If gvData.Columns("ContactId") IsNot Nothing Then
                gvData.Columns("ContactId").Visible = False
            End If
        End If
    End Sub

    Private Sub ClearFieldsNewState()
        edit_ins = -1

        gbMainDetail.Enabled = False
        gcData.Enabled = True

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True

        lblContactId.Text = ""
        txtName.Clear()
        txtContactNo.Clear()
        txtCompanyName.Clear()
        txtEmailID.Clear()
        txtworkNotes.Clear()
        txtRemark1.Clear()
        txtRemark2.Clear()
        dtpBirthDate.Checked = False
        cmbContactType.SelectedIndex = -1
        cmbDesignation.SelectedIndex = -1
        cmbLedgerID.SelectedIndex = -1
        cmbBroadcast.SelectedIndex = -1
    End Sub

    Private Sub SetAddState()
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

    Private Sub SetEditState()
        gbMainDetail.Enabled = True
        gcData.Enabled = False

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True

        edit_ins = 0
    End Sub

    Private Sub FillFormFromRow(rowHandle As Integer)
        If rowHandle < 0 Then Exit Sub
        lblContactId.Text = gvData.GetRowCellValue(rowHandle, "ContactId").ToString()
        txtName.Text = gvData.GetRowCellValue(rowHandle, "PersonName").ToString()
        txtContactNo.Text = gvData.GetRowCellValue(rowHandle, "ContactNo").ToString()
        txtCompanyName.Text = gvData.GetRowCellValue(rowHandle, "CompanyName").ToString()
        cmbDesignation.Text = gvData.GetRowCellValue(rowHandle, "Designation").ToString()
        cmbContactType.Text = gvData.GetRowCellValue(rowHandle, "ContactType").ToString()
        cmbBroadcast.Text = gvData.GetRowCellValue(rowHandle, "Broadcast").ToString()

        If dtGridSource.Columns.Contains("EmailId") Then
            txtEmailID.Text = gvData.GetRowCellValue(rowHandle, "EmailId").ToString()
        End If
        If dtGridSource.Columns.Contains("WorkNotes") Then
            txtworkNotes.Text = gvData.GetRowCellValue(rowHandle, "WorkNotes").ToString()
        End If
        If dtGridSource.Columns.Contains("Remark1") Then
            txtRemark1.Text = gvData.GetRowCellValue(rowHandle, "Remark1").ToString()
        End If
        If dtGridSource.Columns.Contains("Remark2") Then
            txtRemark2.Text = gvData.GetRowCellValue(rowHandle, "Remark2").ToString()
        End If
    End Sub

    Private Sub ClearSearch()
        txtSName.Clear()
        txtSMobileNo.Clear()
        gcData.DataSource = dtGridSource
    End Sub

#End Region

#Region "Events"
    Private Sub FrmContactMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        comboFill(cmbContactType, "SELECT MiscId, MiscName FROM tbl_MiscMaster WHERE MiscType = 'ContactType' ORDER BY DispSrNo, MiscName")
        comboFill(cmbBroadcast, "SELECT MiscId, MiscName FROM tbl_MiscMaster WHERE MiscType = 'Broadcast' ORDER BY DispSrNo, MiscName")
        comboFill(cmbDesignation, "SELECT MiscId, MiscName FROM tbl_MiscMaster WHERE MiscType = 'Designation' ORDER BY DispSrNo, MiscName")

        ClearSearch()
        LoadGridData()
        LoadLedgerCombo()
        ClearFieldsNewState()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        SetAddState()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        SetEditState()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateData() = False Then
            Exit Sub
        End If
        SaveData()
        LoadGridData()
        ClearFieldsNewState()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteData()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearFieldsNewState()
        LoadGridData()
        ClearSearch()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If edit_ins = -1 Then
            Me.Close()
        Else
            If MsgBox("Sure To Exit Without Saving Data ?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Me.Close()
            End If
        End If
        M_SalesItemMasterF2 = False
    End Sub

    Private Sub gcData_MouseDown(sender As Object, e As MouseEventArgs) Handles gcData.MouseDown
        If e.Button = MouseButtons.Right Then
            cmsContactMaster.Show(gcData, e.Location)
        End If
    End Sub

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As Keys) As Boolean
    '    If keyData = Keys.Enter Then
    '        Dim currentCtrl As Control = Me.ActiveControl
    '        Me.SelectNextControl(currentCtrl, True, True, True, True)
    '        Dim nextCtrl As Control = Me.ActiveControl

    '        Dim guard As Integer = 0
    '        While nextCtrl IsNot Nothing AndAlso TypeOf nextCtrl Is Button AndAlso guard < Me.Controls.Count
    '            Me.SelectNextControl(nextCtrl, True, True, True, True)
    '            nextCtrl = Me.ActiveControl
    '            guard += 1
    '        End While

    '        If nextCtrl Is Nothing OrElse TypeOf nextCtrl Is Button Then
    '            txtName.Focus()
    '        End If

    '        Return True
    '    End If

    '    Return MyBase.ProcessCmdKey(msg, keyData)
    'End Function
    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress, txtContactNo.KeyPress, cmbContactType.KeyPress, txtCompanyName.KeyPress, cmbDesignation.KeyPress, txtEmailID.KeyPress, dtpBirthDate.KeyPress, cmbLedgerID.KeyPress, cmbBroadcast.KeyPress, txtworkNotes.KeyPress, txtRemark1.KeyPress, txtRemark2.KeyPress, txtSName.KeyPress, txtSMobileNo.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub gvData_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles gvData.RowClick
        If e.Clicks > 1 OrElse edit_ins = 0 Then Exit Sub
        If gvData.FocusedRowHandle < 0 Then Exit Sub

        FillFormFromRow(gvData.FocusedRowHandle)
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnAdd.Enabled = False
    End Sub

    Private Sub gvData_DoubleClick(sender As Object, e As EventArgs) Handles gvData.DoubleClick
        If gvData.FocusedRowHandle < 0 Then Exit Sub
        FillFormFromRow(gvData.FocusedRowHandle)
        SetEditState()
        txtName.Focus()
    End Sub

    Private Sub txtSName_TextChanged(sender As Object, e As EventArgs) Handles txtSName.TextChanged
        LoadGridData()
    End Sub

    Private Sub txtSMobileNo_TextChanged(sender As Object, e As EventArgs) Handles txtSMobileNo.TextChanged
        LoadGridData()
    End Sub

    Private Sub txtSMobileNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSMobileNo.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNo.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnRefresh_click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSMobileNo.Text = ""
        txtSName.Text = ""
        ClearSearch()
        LoadGridData()
    End Sub

    Private Sub cmsRefresh_click(sender As Object, e As EventArgs) Handles cmsRefresh.Click
        txtSMobileNo.Text = ""
        txtSName.Text = ""
        ClearSearch()
        LoadGridData()
    End Sub

    Private Sub cmsSave_Click(sender As Object, e As EventArgs) Handles cmsSave.Click
        SaveLayout(gvData, "Sales_Item_Master_Grid", Me)
    End Sub

    Private Sub cmsRename_Click(sender As Object, e As EventArgs) Handles cmsRename.Click
        gvData.FocusedColumn.Caption = InputBox("Column Header Text", "Field Name", gvData.FocusedColumn.FieldName)
    End Sub


#End Region
End Class

