Imports Sunrise.TailoringERP.DB
Imports TailoringERP.TailoringERP.DB
'
Public Class FrmHelpMiscList

#Region "Comments"
    'Name:TailoringERP
    'Created By:Bhavesh
    'Form:FrmHelpMiscList
    'Date:18/09/2017
#End Region

#Region "Declaration"
    Dim ds As New Data.DataSet
    Dim obj As New DBManager
    Dim sql_query As String
#End Region

#Region "Method"

    Public Sub insertMiscMaster(ByVal _MiscType As String, ByVal _MiscName As String)
        obj.Prepare("SP_InsertMiscMaster", SpType.StoredProcedure)
        obj.AddCmdParameter("@InsMiscType", Dtype.nvarchar, _MiscType, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMiscName", Dtype.nvarchar, _MiscName, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsData1", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsData2", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsDispSrNo", Dtype.int, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsIsActive", Dtype.Bit, "True", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCId", Dtype.int, M_CId, ParaDirection.Input, True)
        obj.ExecuteCommand()

        MsgBox(_MiscType & " Added Successfully", MsgBoxStyle.Information)
        gridfill()
    End Sub

    Public Sub gridfill()
        Dim _filter As String = ""
        If M_CompanyWiseMiscMaster = "Yes" Then
            _filter = " And CId = " & M_CId
        End If

        Select Case M_callingForm_MiscHelp
            Case ""

                Exit Select
            'Case "frmInvoiceMaster_MeasurementBy", "frmInvoiceMaster_ForMeasurement_MeasurementBy", "frmInvoiceMaster_SBOSS_MeasurementBy"
            Case "frmInvoiceMaster_ForMeasurement_MeasurementBy", "frmInvoiceMaster_SBOSS_MeasurementBy"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where CId = " & M_CId & " And MiscType = 'Measurement By' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select
            Case "frmInvoiceMaster_MeasurementBy" ' For Julie
                ds.Clear()
                'sql_query = "select LedgerId AS MiscId, LedgerName AS MiscName, '' AS MiscType, CId, cast(1 AS Bit) AS IsActive, '' AS Data1, '' AS Data2, 0 As DispSrNo, '' AS CName from View_LedgerMaster Where CId = " & M_CId & " And G_Id in (30,39) And (LedgerName Like '" & Trim(txtMiscName.Text) & "%' Or Code Like '" & Trim(txtMiscName.Text) & "' )" & _filter & " order by DispSrNo"
                sql_query = "SP_GetWorkerList"
                Exit Select
            Case "FrmPurchase_WfsNew_ItemType"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where MiscType = 'ItemType' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select
            Case "FrmPurchase_WfsNew_ItemCategory"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where MiscType = 'ItemCategory' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select
            Case "FrmPurchase_WfsNew_MfgName"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where MiscType = 'MfgName' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select
            Case "IssueFor", "IssueFor_WorkIssueReturn"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where MiscType = 'Issue For' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select
            Case "WorkIssuance_IssueFor", "WorkIssuanceDX_IssueFor"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where MiscType = 'Issue For' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select
            Case "FrmView_JobWorkRegister_Status"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where MiscType = 'Jobwork Entry Status' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select
            Case "Notes Help", "Notes Help (Customer)", "Notes Help (VAT)", "Notes Help Lazaro", "Notes Help (Customer) With Image", "Notes Help (Customer) AM"
                ds.Clear()
                Select Case M_callingForm_MiscHelp
                    Case "Notes Help"
                        sql_query = "select * from View_MiscMaster Where Upper(MiscType) = 'Notes' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                        'sql_query = "select * from View_MiscMaster Where Upper(MiscType) = '" & UCase(FrmInvoiceMaster.cmbItemName.Text) & " STYLE' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                        Exit Select
                    Case "Notes Help (Customer)"
                        sql_query = "select * from View_MiscMaster Where Upper(MiscType) = N'" & UCase(FrmCustomerMaster_Tailoring.grdItems.CurrentRow.Cells("TItemName").Value) & " STYLE' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                        Exit Select
                End Select
                Exit Select
            Case "frmInvoiceMaster_SBOSS_SalesPerson1", "frmInvoiceMasterProduction_SalesPerson", "frmInvoiceMasterSales_SalesPerson1", "frmInvoiceMaster_SalesPerson1", "frmInvoiceMasterVAT_SalesPerson", "frmInvoiceMasterLazaro_SalesPerson", "frmInvoiceMaster_SalesPerson_Traditional"
                ds.Clear()
                'sql_query = "select * from View_MiscMaster Where CId = " & M_CId & " And MiscType = 'Sales Person' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                sql_query = "select * from ( " _
                          & " select * from View_MiscMaster Where CId = 1 And MiscType = 'Sales Person' And MiscName Like '%' " _
                          & " Union All " _
                          & " select LedgerName As MiscName, 'Sales Person' As MiscType, CId, IsActive, LedgerId AS MiscId, '' As Data1, '' As Data2, 0 As DispSrNo, '' AS CName from View_LedgerMaster where G_Id = 40 " _
                          & " ) As SalesManList " _
                          & " Where MiscType = 'Sales Person' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select 'CId = " & M_CId & " And
            Case "frmInvoiceMaster_SalesPerson2", "frmInvoiceMasterSales_SalesPerson2", "frmInvoiceMaster_SBOSS_SalesPerson2"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where CId = " & M_CId & " And MiscType = 'Manager Sales Person' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select
            Case "CITYHelp", "BusinessProfileCITYHelp", "CITY_CorporateHelp", "CITYCorporateEmployeeHelp"
                ds.Clear()
                If Trim(txtMiscName.Text) = "" Then
                    sql_query = "select * from View_MiscMaster Where MiscType = 'City' " & _filter & " order by DispSrNo"
                Else
                    sql_query = "select * from View_MiscMaster Where MiscType = 'City' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                End If
                Exit Select

            Case "State_CorporateEmployeeHelp", "State_CorporateCustomerHelp", "State_CustomerHelp", "State_VendorHelp", "State_LedgerHelp", "State_CompanyHelp", "State_WorkerHelp", "State_Customer_WithImageHelp", "State_CustomerHelp_AM", "BusinessProfileStateHelp"
                ds.Clear()
                sql_query = "select * from View_MiscMaster Where MiscType = 'State' And MiscName Like '%" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                Exit Select

            Case "COUNTRYHelp", "Country_CustomerHelp", "BusinessProfileCOUNTRYHelp", "Country_CorporateCustomerHelp", "Country_CorporateEmployeeHelp"
                ds.Clear()
                If Trim(txtMiscName.Text) = "" Then
                    sql_query = "select * from View_MiscMaster Where MiscType = 'Country' " & _filter & " order by DispSrNo"
                Else
                    sql_query = "select * from View_MiscMaster Where MiscType = 'Country' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                End If
                Exit Select
            Case "InvoiceMaster_Worker", "InvoiceMaster_Worker_Traditional"
                ds.Clear()
                If Trim(txtMiscName.Text) = "" Then
                    sql_query = "select * from View_MiscMaster Where MiscType = 'Worker' " & _filter & " order by DispSrNo"
                Else
                    sql_query = "select * from View_MiscMaster Where MiscType = 'Worker' And MiscName Like '" & Trim(txtMiscName.Text) & "%' " & _filter & " order by DispSrNo"
                End If
                Exit Select
        End Select

        Select Case M_callingForm_MiscHelp
            Case "frmInvoiceMaster_MeasurementBy"
                '" CId = " & M_CId & " And G_Id in (30,39) And (LedgerName Like '" & Trim(txtMiscName.Text) & "%' Or Code Like '" & Trim(txtMiscName.Text) & "' )" & _filter & " order by DispSrNo"
                If M_DbName = "dbSTE_Julie2024" Then
                    obj.AddCmdParameter("@Filter", Dtype.varchar, " And CId = " & M_CId & " And (LedgerName Like '" & Trim(txtMiscName.Text) & "%' Or Code Like '%" & Trim(txtMiscName.Text) & "%' )" & _filter, ParaDirection.Input, True)
                Else
                    obj.AddCmdParameter("@Filter", Dtype.varchar, " And CId = " & M_CId & " And MiscName Like '%" & Trim(txtMiscName.Text) & "%' " & _filter, ParaDirection.Input, True)
                End If
                obj.Prepare(sql_query, SpType.StoredProcedure)
                obj.LoadData123("SP_GetWorkerList", ds)
                grdData.DataSource = ds.Tables(0).DefaultView
                Exit Select
            Case Else
                obj.LoadData(sql_query, ds)
                grdData.DataSource = ds.Tables(0).DefaultView
                Exit Select
        End Select

        Select Case M_callingForm_MiscHelp
            'Case "frmInvoiceMaster_MeasurementBy", "frmInvoiceMaster_ForMeasurement_MeasurementBy", "frmInvoiceMaster_SBOSS_MeasurementBy"
            Case "frmInvoiceMaster_ForMeasurement_MeasurementBy", "frmInvoiceMaster_SBOSS_MeasurementBy"
                grdData.Columns("MiscName").HeaderText = "Measurement By"
                Exit Select
            Case "frmInvoiceMaster_MeasurementBy"
                grdData.Columns("MiscName").HeaderText = "Worker Name"
                Exit Select
            Case "IssueFor", "IssueFor_WorkIssueReturn", "WorkIssuance_IssueFor", "WorkIssuanceDX_IssueFor"
                grdData.Columns("MiscName").HeaderText = "Work Type"
                Exit Select
            Case "Notes Help", "Notes Help (Customer)", "Notes Help (VAT)", "Notes Help Lazaro", "Notes Help (Customer) With Image", "Notes Help (Customer) AM"
                grdData.Columns("MiscName").HeaderText = "Notes / Style"
                Exit Select
            Case "frmInvoiceMaster_SBOSS_SalesPerson2", "frmInvoiceMasterSales_SalesPerson2", "frmInvoiceMaster_SalesPerson2"
                grdData.Columns("MiscName").HeaderText = "Manager Sales Person"
                Exit Select
            Case "frmInvoiceMaster_SBOSS_SalesPerson1", "frmInvoiceMasterProduction_SalesPerson", "frmInvoiceMasterSales_SalesPerson1", "frmInvoiceMaster_SalesPerson1", "frmInvoiceMasterVAT_SalesPerson", "frmInvoiceMasterLazaro_SalesPerson", "frmInvoiceMaster_SalesPerson_Traditional"
                grdData.Columns("MiscName").HeaderText = "Sales Person"
                Exit Select
            Case "CITYHelp", "BusinessProfileCITYHelp", "CITY_CorporateHelp", "CITYCorporateEmployeeHelp"
                grdData.Columns("MiscName").HeaderText = "City"
                Exit Select
            Case "State_CorporateEmployeeHelp", "State_CorporateCustomerHelp", "State_CustomerHelp", "State_VendorHelp", "State_LedgerHelp", "State_CompanyHelp", "State_WorkerHelp", "State_Customer_WithImageHelp", "State_CustomerHelp_AM", "BusinessProfileStateHelp"
                grdData.Columns("MiscName").HeaderText = "State"
                Exit Select
            Case "COUNTRYHelp", "Country_CustomerHelp", "BusinessProfileCOUNTRYHelp", "Country_CorporateCustomerHelp", "Country_CorporateEmployeeHelp"
                grdData.Columns("MiscName").HeaderText = "Country"
                Exit Select
            Case "InvoiceMaster_Worker", "InvoiceMaster_Worker_Traditional"
                grdData.Columns("MiscName").HeaderText = "Status"
                Exit Select
            Case "LedgerWeight"
                'grdData.Columns("MiscName").HeaderText = "Status"
                Exit Select
            Case Else
                ' grdData.Columns("MiscName").HeaderText = "Notes / Style"
                Exit Select
        End Select

        Select Case M_callingForm_MiscHelp
            Case "LedgerWeight"
                '
                Exit Select
            Case "COUNTRYHelp", "Country_CustomerHelp", "BusinessProfileCOUNTRYHelp", "Country_CorporateCustomerHelp", "Country_CorporateEmployeeHelp"
                grdData.Columns("Data1").HeaderText = "Country Code"
                grdData.Columns("MiscId").Visible = False
                grdData.Columns("MiscName").Width = 200
                grdData.Columns("MiscType").Visible = False
                grdData.Columns("Data2").Visible = False
                grdData.Columns("DispSrNo").Visible = False
                grdData.Columns("CId").Visible = False
                grdData.Columns("CName").Visible = False
                grdData.Columns("IsActive").Visible = False
                Exit Select
            Case Else
                grdData.Columns("MiscId").Visible = False
                grdData.Columns("MiscName").Width = 300
                grdData.Columns("MiscType").Visible = False
                grdData.Columns("Data1").Visible = False
                grdData.Columns("Data2").Visible = False
                grdData.Columns("DispSrNo").Visible = False
                grdData.Columns("CId").Visible = False
                grdData.Columns("CName").Visible = False
                grdData.Columns("IsActive").Visible = False
                Exit Select
        End Select
    End Sub

    Public Sub setValue()
        Select Case M_callingForm_MiscHelp
            Case 1
                FrmCustomerMaster_Tailoring.txtState.Text = grdData.CurrentRow.Cells("MiscName").Value
                Me.Close()
            Case "Notes Help (Customer)"
                FrmCustomerMaster_Tailoring.grdParaList.CurrentRow.Cells("Notes").Value = grdData.CurrentRow.Cells("MiscName").Value
                Me.Close()
                Exit Select
            Case "Notes Help (Customer) With Image"
                FrmCustomerMaster_Tailoring.grdParaList.CurrentRow.Cells("Notes").Value = grdData.CurrentRow.Cells("MiscName").Value
                Me.Close()
                Exit Select
            Case "State_Customer_WithImageHelp"
                FrmCustomerMaster_Tailoring.txtState.Text = grdData.CurrentRow.Cells("MiscName").Value
                Me.Close()
                Exit Select
            Case "State_CustomerHelp"
                FrmCustomerMaster_Tailoring.txtState.Text = grdData.CurrentRow.Cells("MiscName").Value
                Me.Close()
                Exit Select
            Case "Country_CustomerHelp"
                FrmCustomerMaster_Tailoring.txtCountryCode.Text = grdData.CurrentRow.Cells("Data1").Value
                FrmCustomerMaster_Tailoring.txtCountry.Text = grdData.CurrentRow.Cells("MiscName").Value
                Me.Close()
                Exit Select

                    ''Case "frmInvoiceMaster_MeasurementBy"
                    ''    FrmInvoiceMaster.txtRemark1.Text = grdData.CurrentRow.Cells("MiscName").Value
                    ''    Me.Close()
                    ''    Exit Select

            Case "Notes Help (Customer)"
                For i As Integer = 0 To grdData.SelectedRows.Count - 1
                    'FrmCustomerMaster_WithImage.grdParaList.Rows(i).Cells("Notes").Value = grdData.SelectedRows(i).Cells("MiscName").Value
                    FrmCustomerMaster_Tailoring.grdParaList.Rows(i).Cells("Notes").Value = grdData.SelectedRows(grdData.SelectedRows.Count - 1 - i).Cells("MiscName").Value
                Next
                Me.Close()
                Exit Select
            Case "Notes Help (Customer) With Image"
                For i As Integer = 0 To grdData.SelectedRows.Count - 1
                    FrmCustomerMaster_Tailoring.grdParaList.Rows(i).Cells("Notes").Value = grdData.SelectedRows(grdData.SelectedRows.Count - 1 - i).Cells("MiscName").Value
                Next
                Me.Close()
                Exit Select
        End Select
    End Sub

#End Region

    Private Sub FrmHelpMiscList_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub FrmHelpMiscList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtMiscName.Text = M_SearchText
        txtMiscName.Select(txtMiscName.Text.Length, 0)
        M_SearchText = ""

        gridfill()

        'If M_callingForm_MiscHelp = "Notes Help" Or M_callingForm_MiscHelp = "Notes Help (VAT)" Or M_callingForm_MiscHelp = "Notes Help (Customer)" Then
        '    sql_query = "Select MiscName From tbl_MiscMaster Where MiscType = 'Notes Font'"
        '    _font = obj.ScalarExecute(sql_query)

        '    sql_query = "Select MiscName From tbl_MiscMaster Where MiscType = 'Notes Font Size'"
        '    _fontSize = obj.ScalarExecute(sql_query)

        '    grdData.Columns("MiscName").DefaultCellStyle.Font = New Font(_font, _fontSize, FontStyle.Regular)
        'End If
        Select Case M_callingForm_MiscHelp
            Case "LedgerWeight"
                Exit Sub
                Exit Select
        End Select

        Dim _sz As Integer = M_NotesFontSize
        grdData.Columns("MiscName").DefaultCellStyle.Font = New Font(M_NotesFontName, _sz, FontStyle.Regular)

        If M_NotesStyle = "Style" Then
            grdData.MultiSelect = True
        End If
    End Sub

    Private Sub txtMiscName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMiscName.TextChanged
        gridfill()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If grdData.Rows.Count > 0 Then
            grdData.Rows(0).Selected = True
            setValue()
        Else
            If Trim(txtMiscName.Text) = "" Then
                MsgBox("Please Specify " & M_callingForm_MiscHelp, MsgBoxStyle.Information)
                Exit Sub
            End If

            Select Case M_callingForm_MiscHelp
                Case "frmInvoiceMaster_MeasurementBy", "frmInvoiceMaster_ForMeasurement_MeasurementBy", "frmInvoiceMaster_SBOSS_MeasurementBy"
                    insertMiscMaster("Measurement By", Trim(txtMiscName.Text))
                    Exit Select
                Case "IssueFor", "IssueFor_WorkIssueReturn"
                    insertMiscMaster("IssueFor", Trim(txtMiscName.Text))
                    Exit Select
                Case "WorkIssuance_IssueFor", "WorkIssuanceDX_IssueFor"
                    insertMiscMaster("IssueFor", Trim(txtMiscName.Text))
                    Exit Select
                Case "FrmView_JobWorkRegister_Status"
                    insertMiscMaster("Jobwork Entry Status", Trim(txtMiscName.Text))
                    Exit Select
                Case "frmInvoiceMaster_SBOSS_SalesPerson2", "frmInvoiceMasterSales_SalesPerson2", "frmInvoiceMaster_SalesPerson2"
                    insertMiscMaster("Manager Sales Person", Trim(txtMiscName.Text))
                    Exit Select
                Case "frmInvoiceMaster_SBOSS_SalesPerson1", "frmInvoiceMasterProduction_SalesPerson", "frmInvoiceMasterSales_SalesPerson1", "frmInvoiceMaster_SalesPerson1", "frmInvoiceMasterVAT_SalesPerson", "frmInvoiceMasterLazaro_SalesPerson", "frmInvoiceMaster_SalesPerson_Traditional"
                    insertMiscMaster("Sales Person", Trim(txtMiscName.Text))
                    Exit Select
            End Select
        End If
        setValue()
    End Sub

    Private Sub grdParaList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdData.CellDoubleClick
        setValue()
    End Sub

    Private Sub grdParaList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdData.KeyDown
        If e.KeyCode = Keys.Enter Then
            setValue()
        End If
    End Sub

    Private Sub txtMiscName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiscName.KeyPress
        If e.KeyChar = Chr(13) Then
            Select Case grdData.Rows.Count
                Case 1
                    grdData.Focus()
                    grdData.Rows(0).Selected = True
                    setValue()
                    Exit Select
                Case Is > 1
                    grdData.Focus()
                    Exit Select
                Case 0
                    Select Case M_callingForm_MiscHelp

                        Case "Notes Help (Customer)"
                            FrmCustomerMaster_Tailoring.grdParaList.CurrentRow.Cells("Notes").Value = Trim(txtMiscName.Text)
                            Me.Close()
                            Exit Select
                        Case "Notes Help (Customer) With Image"
                            FrmCustomerMaster_Tailoring.grdParaList.CurrentRow.Cells("Notes").Value = Trim(txtMiscName.Text)
                            Me.Close()
                            Exit Select
                    End Select
                    Exit Select
            End Select
        End If
    End Sub

    Private Sub txtMiscName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMiscName.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                If Trim(txtMiscName.Text) = "" Then
                    MsgBox("Please Specify " & M_callingForm_MiscHelp, MsgBoxStyle.Information)
                    Exit Sub
                End If

                Select Case M_callingForm_MiscHelp
                    Case "frmInvoiceMaster_MeasurementBy", "frmInvoiceMaster_ForMeasurement_MeasurementBy", "frmInvoiceMaster_SBOSS_MeasurementBy"
                        insertMiscMaster("Measurement By", Trim(txtMiscName.Text))
                        Exit Select
                    Case "IssueFor"
                        insertMiscMaster("IssueFor", Trim(txtMiscName.Text))
                        Exit Select
                    Case "WorkIssuance_IssueFor", "WorkIssuanceDX_IssueFor"
                        insertMiscMaster("IssueFor", Trim(txtMiscName.Text))
                        Exit Select
                    Case "FrmView_JobWorkRegister_Status"
                        insertMiscMaster("Jobwork Entry Status", Trim(txtMiscName.Text))
                        Exit Select
                    Case "frmInvoiceMaster_SBOSS_SalesPerson2", "frmInvoiceMasterSales_SalesPerson2", "frmInvoiceMaster_SalesPerson2"
                        insertMiscMaster("Manager Sales Person", Trim(txtMiscName.Text))
                        Exit Select
                    Case "frmInvoiceMaster_SBOSS_SalesPerson1", "frmInvoiceMasterProduction_SalesPerson", "frmInvoiceMasterSales_SalesPerson1", "frmInvoiceMaster_SalesPerson1", "frmInvoiceMasterVAT_SalesPerson", "frmInvoiceMasterLazaro_SalesPerson", "frmInvoiceMaster_SalesPerson_Traditional"
                        insertMiscMaster("Sales Person", Trim(txtMiscName.Text))
                        Exit Select
                End Select
                Exit Select
            Case Keys.Down
                grdData.Focus()
                Exit Select
        End Select
    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        Me.Close()
    End Sub

End Class