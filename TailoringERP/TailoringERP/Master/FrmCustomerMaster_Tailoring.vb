Imports Sunrise.TailoringERP.DB
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports RestSharp
Imports Newtonsoft.Json
Imports DevExpress.XtraSplashScreen
Imports Stimulsoft.Report
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.Utils
Imports AForge.Video.DirectShow
Imports AForge.Video
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors
Imports TailoringERP.TailoringERP.DB

Public Class FrmCustomerMaster_Tailoring

#Region "Comments"
    'Name:TailoringERP
    'Created By:Bhavesh
    'Form:FrmCustomerMaster
    'Date:17/01/2019
#End Region

#Region "Declaration"
    Dim dsComboGM As New Data.DataSet 'GroupMaster
    Dim dsCmbItem As New Data.DataSet
    Dim obj As New DBManager
    Dim sql_query As String
    Dim edit_ins As Integer = -1
    Dim existLedgerCode As String
    Dim oldLedgerCode As String 'Leddger name Maintained Uniquely
    Dim point As Boolean = False
    Dim _LedgerCodeInitial As String = ""

    Dim tmpHalf As String = "½"
    Dim tmpOneForth As String = "¼"
    Dim tmpThreeForth As String = "¾"

    Dim flg_Synch As Boolean = False
    Dim LedgerId_Synch As Integer

    Dim dtAppPara As DataTable
    Dim dsUISetting As New Data.DataSet
#End Region

#Region "Method"


    Public Sub Get_Dt_AppParameter()
        dtAppPara = New DataTable()
        dtAppPara.Columns.Add("CDId", GetType(Integer))
        dtAppPara.Columns.Add("LedgerId", GetType(Integer))
        dtAppPara.Columns.Add("TItemId", GetType(Integer))
        dtAppPara.Columns.Add("ParaId", GetType(Integer))
        dtAppPara.Columns.Add("ParaValue", GetType(String))
        dtAppPara.Columns.Add("ParaValue2", GetType(String))
        dtAppPara.Columns.Add("Notes", GetType(String))
    End Sub

    Public Sub formatGrid()
        gvData.Columns("LedgerId").Visible = False
        gvData.Columns("Code").Visible = False
        gvData.Columns("Code").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        gvData.Columns("LedgerCode").Caption = "Code"
        gvData.Columns("LedgerName").Caption = "Customer Name"
        gvData.Columns("G_Id").Visible = False
        gvData.Columns("G_Name").Caption = "Group Name"
        gvData.Columns("PinCode").Visible = False
        gvData.Columns("State").Visible = False
        gvData.Columns("Country").Visible = False
        gvData.Columns("PhoneNo").Visible = False
        gvData.Columns("FaxNo").Caption = "Type/Group"
        gvData.Columns("EMail").Visible = False
        gvData.Columns("BirthDate").Visible = False
        gvData.Columns("AnniDate").Visible = False
        gvData.Columns("BeneficiaryName").Caption = "Weight"
        gvData.Columns("BankAcType").Visible = False
        gvData.Columns("BankAcNo").Visible = False
        gvData.Columns("IFSCCode").Visible = False
        gvData.Columns("MICRCode").Visible = False
        gvData.Columns("BankName").Visible = False
        gvData.Columns("BankAddress").Visible = False
        gvData.Columns("AcContactPerson").Visible = False
        gvData.Columns("AcContactNo").Visible = False
        gvData.Columns("AcEmailId").Visible = False
        gvData.Columns("TranSMS").Visible = False
        gvData.Columns("PromoSMS").Visible = False
        gvData.Columns("CId").Visible = False
        gvData.Columns("IsActive").Visible = False
    End Sub

    'Public Sub gridfill(ByVal topRows As String, ByVal orderBy As String)
    '    Dim _filter As String = ""
    '    If Val(txtF_Code.Text) > 0 Then
    '        _filter = _filter & " And Code = " & Val(txtF_Code.Text)
    '    End If

    '    ds.Clear()
    '    Select Case UCase(M_TIHelpLedgerList)
    '        Case "ALL COMPANY"
    '            If txtF_LedgerName.Text.StartsWith("*") = True And Trim(txtF_LedgerName.Text.Length) > 1 Then
    '                sql_query = "Select " & topRows & " * From  View_LedgerMaster" _
    '                & " Where G_Id = 11 And (LedgerName Like N'" & Trim(Strings.Replace(Trim(txtF_LedgerName.Text).Substring(1), "'", "''")) & "%' Or LedgerCode Like '" & Trim(Strings.Replace(Trim(txtF_LedgerName.Text).Substring(1), "'", "''")) & "%') " _
    '                & " And (MobileNo Like '" & Trim(Strings.Replace(Trim(txtF_Mobile.Text).Substring(1), "'", "''")) & "%' Or MobileNo2 Like '" & Trim(Strings.Replace(Trim(txtF_Mobile.Text).Substring(1), "'", "''")) & "%') " & _filter & orderBy
    '            Else
    '                sql_query = "Select " & topRows & " * From  View_LedgerMaster" _
    '                & " Where G_Id = 11 And (LedgerName Like N'" & (Trim(txtF_LedgerName.Text) & "%' Or LedgerCode Like '" & Trim(txtF_LedgerName.Text)) & "%') " _
    '                & " And (MobileNo Like '" & (Trim(txtF_Mobile.Text)) & "%' Or MobileNo2 Like '" & (Trim(txtF_Mobile.Text)) & "%') " & _filter & orderBy
    '            End If
    '            Exit Select
    '        Case "SAME COMPANY"
    '            If txtF_LedgerName.Text.StartsWith("*") = True And Trim(txtF_LedgerName.Text.Length) > 1 Then
    '                sql_query = "Select " & topRows & " * From  View_LedgerMaster " _
    '                & " Where CId = " & M_CId & " And G_Id = 11 And (LedgerName Like N'" & Trim(Strings.Replace(Trim(txtF_LedgerName.Text).Substring(1), "'", "''")) & "%' Or LedgerCode Like '" & Trim(Strings.Replace(Trim(txtF_LedgerName.Text).Substring(1), "'", "''")) & "%') " _
    '                & " And (MobileNo Like '" & Trim(Strings.Replace(Trim(txtF_Mobile.Text).Substring(1), "'", "''")) & "%' Or MobileNo2 Like '" & Trim(Strings.Replace(Trim(txtF_Mobile.Text).Substring(1), "'", "''")) & "%') " & _filter & orderBy
    '            Else
    '                sql_query = "Select " & topRows & " * From  View_LedgerMaster " _
    '                & " Where CId = " & M_CId & " And G_Id = 11 And (LedgerName Like N'" & (Trim(txtF_LedgerName.Text)) & "%' Or LedgerCode Like '" & (Trim(txtF_LedgerName.Text)) & "%') " _
    '                & " And (MobileNo Like '" & (Trim(txtF_Mobile.Text)) & "%' Or MobileNo2 Like '" & (Trim(txtF_Mobile.Text)) & "%') " & _filter & orderBy
    '            End If
    '            Exit Select
    '    End Select

    '    obj.LoadData(sql_query, ds)
    '    gcData.DataSource = ds.Tables(0).DefaultView

    '    gvData.OptionsView.ColumnAutoWidth = False
    '    gvData.BestFitColumns()

    '    lblRecords.Text = "Records: " & gvData.RowCount
    '    RestoreLayout(gvData, "FrmCustomerMaster_Tailoring")

    '    If checkRightsToLoad("HIDE CUSTOMER CONTACT NO") = True Then
    '        gvData.Columns("MobileNo").Visible = False
    '        gvData.Columns("PhoneNo").Visible = False
    '    End If

    '    If checkRightsToLoad("HIDE CUSTOMER ADDRESS") = True Then
    '        gvData.Columns("Address1").Visible = False
    '        gvData.Columns("Address2").Visible = False
    '    End If
    'End Sub

    Public Sub gridfill(flg As Boolean)
        If flg = True Then
            loadLedgerMaster()
        End If


        gcData.DataSource = dsLedgerMaster.Tables(0).DefaultView
        gvData.OptionsView.ColumnAutoWidth = False
        gvData.BestFitColumns()

        Try
            gvData.Columns("Sys_Time").DisplayFormat.FormatType = FormatType.DateTime
            gvData.Columns("Sys_Time").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
        Catch ex As Exception

        End Try


        gvData.Columns("G_Id").FilterInfo = New ColumnFilterInfo("[G_Id] = 11")

        Select Case UCase(M_TIHelpLedgerList)
            Case "ALL COMPANY"

                Exit Select
            Case "SAME COMPANY"
                gvData.Columns("CId").FilterInfo = New ColumnFilterInfo("[CId] = " & M_CId)
                Exit Select
        End Select

        RestoreLayout(gvData, "FrmCustomerMaster_Tailoring")

        If checkRightsToLoad("HIDE CUSTOMER CONTACT NO") = True Then
            gvData.Columns("MobileNo").Visible = False
            gvData.Columns("PhoneNo").Visible = False
        End If

        If checkRightsToLoad("HIDE CUSTOMER ADDRESS") = True Then
            gvData.Columns("Address1").Visible = False
            gvData.Columns("Address2").Visible = False
        End If

        ' Sort the "LedgerId" column in descending order
        gvData.Columns("LedgerId").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
    End Sub

    Public Sub ComboFill(ByVal cmb As System.Windows.Forms.ComboBox, ByVal sql As String)
        Dim dsCmb As New Data.DataSet
        dsCmb.Clear()
        sql_query = sql
        obj.LoadData(sql_query, dsCmb)
        obj.LoadData(sql_query, dsCmbItem)
        cmb.DataSource = dsCmb.Tables(0).DefaultView
        cmb.ValueMember = dsCmb.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsCmb.Tables(0).Columns(1).ToString
        dsCmb.Dispose()
    End Sub

    Public Sub loadParaList()
        grdParaList.Rows.Clear()
        Dim tmpDs As New DataSet
        sql_query = "Select * From tbl_TItemParameter Where TItemId = " & grdItems.CurrentRow.Cells("TItemId").Value & " Order By PrintOrder"
        obj.LoadData(sql_query, tmpDs)

        For i As Integer = 0 To tmpDs.Tables(0).Rows.Count - 1
            grdParaList.Rows.Add()
            grdParaList.Rows(i).Cells("ParaId").Value = tmpDs.Tables(0).Rows(i)("ParaId")
            grdParaList.Rows(i).Cells("ParaName").Value = tmpDs.Tables(0).Rows(i)("ParaName")
            grdParaList.Rows(i).Cells("ItemId2").Value = tmpDs.Tables(0).Rows(i)("TItemId")
            grdParaList.Rows(i).Cells("PrintOrder").Value = tmpDs.Tables(0).Rows(i)("PrintOrder")
        Next

        sql_query = "Select Count(*) From View_CustomerDetail Where TItemId = " & grdItems.CurrentRow.Cells("TItemId").Value & " And LedgerId = " & Val(lblLedgerId.Text)
        If obj.ScalarExecute(sql_query) > 0 Then
            Dim _ds As New Data.DataSet
            sql_query = "Select * From View_CustomerDetail Where TItemId = " & grdItems.CurrentRow.Cells("TItemId").Value & " And LedgerId = " & Val(lblLedgerId.Text)
            obj.LoadData(sql_query, _ds)
            For i As Integer = 0 To _ds.Tables(0).Rows.Count - 1
                For j As Integer = 0 To grdParaList.Rows.Count - 1
                    If _ds.Tables(0).Rows(i)("ParaId") = grdParaList.Rows(j).Cells("ParaId").Value Then
                        grdParaList.Rows(j).Cells("ParaValue").Value = _ds.Tables(0).Rows(i)("ParaValue")
                        grdParaList.Rows(j).Cells("ParaValue2").Value = IIf(IsDBNull(_ds.Tables(0).Rows(i)("ParaValue2")), "", _ds.Tables(0).Rows(i)("ParaValue2"))
                        grdParaList.Rows(j).Cells("Notes").Value = _ds.Tables(0).Rows(i)("Notes")
                        Exit For
                    End If
                Next
            Next
        End If


        Select Case M_MeasurementFetchSetting
            Case "General"
                For i As Integer = 0 To grdParaList.Rows.Count - 1
                    If grdParaList.Rows(i).Cells("ParaValue").Value = "" Then
                        sql_query = "Select ParaValue From View_CustomerDetailNew " _
                            & " Where LedgerId = " & Val(lblLedgerId.Text) _
                            & " And ParaName = N'" & grdParaList.Rows(i).Cells("ParaName").Value & "'"
                        grdParaList.Rows(i).Cells("ParaValue").Value = obj.ScalarExecute(sql_query)
                    End If
                Next
                Exit Select
            Case Else
                For i As Integer = 0 To grdParaList.Rows.Count - 1
                    If grdParaList.Rows(i).Cells("ParaValue").Value = "" Then
                        sql_query = "Select Count(*) From tbl_MiscMaster Where MiscType = 'Common Measurements' And MiscName = '" & grdParaList.Rows(i).Cells("ParaName").Value & "'"
                        If obj.ScalarExecute(sql_query) > 0 Then
                            sql_query = "Select ParaValue From View_CustomerDetailNew " _
                            & " Where LedgerId = " & Val(lblLedgerId.Text) _
                            & " And ParaName = N'" & grdParaList.Rows(i).Cells("ParaName").Value & "'"
                            grdParaList.Rows(i).Cells("ParaValue").Value = obj.ScalarExecute(sql_query)
                        End If
                    End If
                Next
                Exit Select
        End Select
    End Sub

    Public Sub insert()
        If M_GenerateCustomerNumberSaveTime = "Yes" Then
            getLedgerCode()
        End If

        If checkLedgerCode() = True Then
            MsgBox("Same Customer Number Found, Get New Number", MsgBoxStyle.Critical)
            getLedgerCode()
        End If

        obj.Prepare("SP_InsertLedgerMaster_0507", SpType.StoredProcedure)
        obj.AddCmdParameter("@InsCode", Dtype.int, Val(txtLedgerCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsLedgerCode", Dtype.varchar, Trim(txtLedgerCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsLedgerName", Dtype.nvarchar, Trim(txtLedgerName.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsG_Id", Dtype.int, 11, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAddress1", Dtype.nvarchar, Trim(txtAddress1.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAddress2", Dtype.nvarchar, Trim(txtAddress2.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCity", Dtype.nvarchar, Trim(txtCity.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPinCode", Dtype.varchar, Trim(txtPincode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsState", Dtype.nvarchar, Trim(txtState.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCountry", Dtype.nvarchar, Trim(txtCountry.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPhoneNo", Dtype.varchar, Trim(txtPhone.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMobileNo", Dtype.varchar, Trim(txtMobile.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsFaxNo", Dtype.varchar, Trim(txtFax.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsEMail", Dtype.varchar, Trim(txtEMail.Text), ParaDirection.Input, True)
        If dtpBirthDate.Checked = True Then
            obj.AddCmdParameter("@InsBirthDate", Dtype.DateTime, Format(dtpBirthDate.Value, M_DTMforSP), ParaDirection.Input, True)
        Else
            obj.AddCmdParameter("@InsBirthDate", Dtype.DateTime, DBNull.Value, ParaDirection.Input, True)
        End If
        If dtpAnniDate.Checked = True Then
            obj.AddCmdParameter("@InsAnniDate", Dtype.DateTime, Format(dtpAnniDate.Value, M_DTMforSP), ParaDirection.Input, True)
        Else
            obj.AddCmdParameter("@InsAnniDate", Dtype.DateTime, DBNull.Value, ParaDirection.Input, True)
        End If

        obj.AddCmdParameter("@InsCustType", Dtype.nvarchar, cmbCustType.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMobileNo2", Dtype.varchar, Trim(txtMobileNo2.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsBeneficiaryName", Dtype.nvarchar, Trim(txtBeneficiaryName.Text), ParaDirection.Input, True) 'weight
        obj.AddCmdParameter("@InsBankAcType", Dtype.nvarchar, Trim(txtBankAcType.Text), ParaDirection.Input, True) 'Age
        obj.AddCmdParameter("@InsBankAcNo", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsIFSCCode", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMICRCode", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsBankName", Dtype.nvarchar, Trim(txtIsBlock.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsBankAddress", Dtype.nvarchar, Trim(txtBlackListReason.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAcContactPerson", Dtype.nvarchar, Trim(txtAcContactPerson.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAcContactNo", Dtype.varchar, Trim(txtAcContactNo.Text), ParaDirection.Input, True)

        ' Maintain App LedgerId For Reference
        If flg_Synch Then
            obj.AddCmdParameter("@InsAcEmailId", Dtype.varchar, LedgerId_Synch.ToString(), ParaDirection.Input, True)
        Else
            obj.AddCmdParameter("@InsAcEmailId", Dtype.varchar, "", ParaDirection.Input, True)
        End If

        obj.AddCmdParameter("@InsTranSMS", Dtype.varchar, cmbTranSMS.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPromoSMS", Dtype.varchar, cmbPromoSMS.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsGSTNo", Dtype.varchar, Trim(txtGSTNo.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPANNo", Dtype.varchar, Trim(txtPANNo.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsTaxation", Dtype.varchar, cmbTaxation.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCId", Dtype.int, M_CId, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSys_Name", Dtype.varchar, My.Computer.Name, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSys_Time", Dtype.DateTime, Date.Now.ToString(M_DTMforSP & " HH:mm:ss tt"), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCurrUsr", Dtype.nvarchar, loggedUser, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsIsActive", Dtype.Bit, "True", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCountryCode", Dtype.varchar, Trim(txtCountryCode.Text), ParaDirection.Input, True)
        obj.ExecuteCommand()

        If Val(txtOpBal.Text) <> 0 Then
            sql_query = "Select IsNull(Max(LedgerId),0) From tbl_LedgerMaster Where LedgerCode = '" & Trim(txtLedgerCode.Text) & "'"
            setOpeningBalance(obj.ScalarExecute(sql_query))
        End If

        sql_query = "Select IsNull(Max(LedgerId),0) From tbl_LedgerMaster Where LedgerCode = '" & Trim(txtLedgerCode.Text) & "'"
        lblLedgerId.Text = obj.ScalarExecute(sql_query)

        InsertCustomerImage(Val(lblLedgerId.Text))
        'sql_query = "update tbl_ledgerMaster set ledgercode = 'L' + left('0000000',(6-len(ledgerid))) + convert(varchar,ledgerid) where ledgerid In (select top 2 LedgerId from tbl_ledgerMaster order by ledgerId desc)"
        'obj.QueryExecute(sql_query)
    End Sub

    Public Sub insert_CustomerDetail()
        If grdParaList.Rows.Count > 0 Then
            sql_query = "Delete from tbl_CustomerDetail Where LedgerId = " & Val(lblLedgerId.Text) & " And TItemId = " & grdItems.CurrentRow.Cells("TItemId").Value
            obj.QueryExecute(sql_query)
        End If

        For i As Integer = 0 To grdParaList.Rows.Count - 1
            Dim convertQuotes As String = ""
            If IsNothing(grdParaList.Rows(i).Cells("Notes").Value) = False Then
                Dim field1 As String = grdParaList.Rows(i).Cells("Notes").Value
                convertQuotes = field1.Replace("'", " ")
            End If

            sql_query = "Insert Into tbl_CustomerDetail (" _
            & "LedgerId, TItemId, ParaId, ParaValue, Notes, ParaValue2) " _
            & "values (" & Val(lblLedgerId.Text) _
            & ", " & grdItems.CurrentRow.Cells("TItemId").Value _
            & ", " & grdParaList.Rows(i).Cells("ParaId").Value _
            & ", N'" & IIf(IsNothing(grdParaList.Rows(i).Cells("ParaValue").Value), "", grdParaList.Rows(i).Cells("ParaValue").Value) & "'" _
            & ", N'" & convertQuotes & "'" _
            & ", N'" & IIf(IsNothing(grdParaList.Rows(i).Cells("ParaValue2").Value), "", grdParaList.Rows(i).Cells("ParaValue2").Value) & "' )"

            obj.QueryExecute(sql_query)

            If M_MeasurementFetchSetting = "General" Then
                sql_query = "Update tbl_CustomerDetail Set ParaValue = N'" & IIf(IsNothing(grdParaList.Rows(i).Cells("ParaValue").Value), "", grdParaList.Rows(i).Cells("ParaValue").Value) & "', " _
                        & " ParaValue2 = N'" & IIf(IsNothing(grdParaList.Rows(i).Cells("ParaValue2").Value), "", grdParaList.Rows(i).Cells("ParaValue2").Value) & "', " _
                        & " Notes = N'" & IIf(IsNothing(grdParaList.Rows(i).Cells("Notes").Value), "", grdParaList.Rows(i).Cells("Notes").Value) & "' " _
                        & " Where LedgerId = " & Val(lblLedgerId.Text) _
                        & " And ParaId In (Select ParaId From tbl_TItemParameter Where ParaName = N'" & grdParaList.Rows(i).Cells("ParaName").Value & "')"
                obj.QueryExecute(sql_query)
            End If
        Next
    End Sub

    Public Sub setOpeningBalance(ByVal ledgerId As Integer)
        Dim _YrTo As String = "_2025" '& M_dsFinYr.Tables(0).Rows(M_FinYrIndx)("YrSuffix")
        If edit_ins = 0 Then
            sql_query = "Delete from tbl_LedgerOpeningBalance" & _YrTo & " Where LedgerId = " & ledgerId
            obj.QueryExecute(sql_query)
        End If

        Select Case Val(txtOpBal.Text)
            Case Is > 0
                sql_query = "Insert Into tbl_LedgerOpeningBalance" & _YrTo & " (LedgerId, DrOpening, CrOpening, DrCr, LastYrDr, LastYrCr, Remark) Values(" _
                    & ledgerId & "," & Math.Abs(Val(txtOpBal.Text)) & ",0,'Dr',0,0,0)"
                obj.QueryExecute(sql_query)
                Exit Select
            Case Is < 0
                sql_query = "Insert Into tbl_LedgerOpeningBalance" & _YrTo & " (LedgerId, DrOpening, CrOpening, DrCr, LastYrDr, LastYrCr, Remark) Values(" _
                    & ledgerId & ",0," & Math.Abs(Val(txtOpBal.Text)) & ",'Cr',0,0,0)"
                obj.QueryExecute(sql_query)
                Exit Select
        End Select
    End Sub

    Public Sub insertMiscMaster(ByVal _MiscType As String, ByVal _MiscName As String)
        sql_query = "Insert into tbl_MiscMaster (MiscType, MiscName, CId, IsActive, Data1, Data2, DispSrNo) values ('" & _MiscType & "','" & _MiscName & "'," & M_CId & ",'True','','',0)"
        obj.QueryExecute(sql_query)
    End Sub

    Public Sub InsertCustomerImage(ByVal ledgerId As Integer)
        obj.Prepare("SP_InsertImageMaster", SpType.StoredProcedure)
        obj.AddCmdParameter("@InsImageType", Dtype.varchar, "CustomerImage", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMasterId", Dtype.int, ledgerId, ParaDirection.Input, True)

        If IsNothing(pbImg1.Image) = True Then
            obj.AddCmdParameter("@InsImage1", Dtype.img, DBNull.Value, ParaDirection.Input, True)
        Else
            Dim imgByteArray() As Byte
            Dim stream As New MemoryStream
            Dim bmp As New Bitmap(Trim(txtImgPath1.Text))

            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
            imgByteArray = stream.ToArray()
            stream.Close()
            obj.AddCmdParameter("@InsImage1", Dtype.img, imgByteArray, ParaDirection.Input, True)
        End If

        obj.AddCmdParameter("@InsImage2", Dtype.img, DBNull.Value, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsImage3", Dtype.img, DBNull.Value, ParaDirection.Input, True)
        obj.ExecuteCommand()
    End Sub

    Public Sub edit() 'Company Id is not Updated
        obj.Prepare("SP_UpdateLedgerMaster_0507", SpType.StoredProcedure) 'SP_UpdateLedgerMaster_CustMast
        obj.AddCmdParameter("@UpCode", Dtype.int, Val(txtLedgerCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpLedgerCode", Dtype.varchar, Trim(txtLedgerCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpLedgerName", Dtype.nvarchar, Trim(txtLedgerName.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpG_Id", Dtype.int, 11, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAddress1", Dtype.nvarchar, Trim(txtAddress1.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAddress2", Dtype.nvarchar, Trim(txtAddress2.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpCity", Dtype.nvarchar, Trim(txtCity.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpPinCode", Dtype.varchar, Trim(txtPincode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpState", Dtype.nvarchar, Trim(txtState.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpCountry", Dtype.nvarchar, Trim(txtCountry.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpPhoneNo", Dtype.varchar, Trim(txtPhone.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpMobileNo", Dtype.varchar, Trim(txtMobile.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpFaxNo", Dtype.varchar, Trim(txtFax.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpEMail", Dtype.varchar, Trim(txtEMail.Text), ParaDirection.Input, True)
        If dtpBirthDate.Checked = True Then
            obj.AddCmdParameter("@UpBirthDate", Dtype.DateTime, Format(dtpBirthDate.Value, M_DTMforSP), ParaDirection.Input, True)
        Else
            obj.AddCmdParameter("@UpBirthDate", Dtype.DateTime, DBNull.Value, ParaDirection.Input, True)
        End If
        If dtpAnniDate.Checked = True Then
            obj.AddCmdParameter("@UpAnniDate", Dtype.DateTime, Format(dtpAnniDate.Value, M_DTMforSP), ParaDirection.Input, True)
        Else
            obj.AddCmdParameter("@UpAnniDate", Dtype.DateTime, DBNull.Value, ParaDirection.Input, True)
        End If

        obj.AddCmdParameter("@UpCustType", Dtype.nvarchar, cmbCustType.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpMobileNo2", Dtype.varchar, Trim(txtMobileNo2.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpBeneficiaryName", Dtype.nvarchar, Trim(txtBeneficiaryName.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpBankAcType", Dtype.nvarchar, Trim(txtBankAcType.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpBankAcNo", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpIFSCCode", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpMICRCode", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpBankName", Dtype.nvarchar, Trim(txtIsBlock.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpBankAddress", Dtype.nvarchar, Trim(txtBlackListReason.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAcContactPerson", Dtype.nvarchar, Trim(txtAcContactPerson.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAcContactNo", Dtype.varchar, Trim(txtAcContactNo.Text), ParaDirection.Input, True)

        ' Maintain App LedgerId in Desktop App. for Update and Reference
        If flg_Synch Then
            obj.AddCmdParameter("@UpAcEmailId", Dtype.varchar, LedgerId_Synch.ToString(), ParaDirection.Input, True)
        Else
            obj.AddCmdParameter("@UpAcEmailId", Dtype.varchar, "", ParaDirection.Input, True)
        End If

        obj.AddCmdParameter("@UpTranSMS", Dtype.varchar, cmbTranSMS.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpPromoSMS", Dtype.varchar, cmbPromoSMS.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpGSTNo", Dtype.varchar, Trim(txtGSTNo.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpPANNo", Dtype.varchar, Trim(txtPANNo.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpTaxation", Dtype.varchar, cmbTaxation.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpCId", Dtype.int, M_CId, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpIsActive", Dtype.Bit, "True", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpCountryCode", Dtype.varchar, Trim(txtCountryCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpLedgerId", Dtype.int, Val(lblLedgerId.Text), ParaDirection.Input, True)
        obj.ExecuteCommand()

        setOpeningBalance(Val(lblLedgerId.Text))

    End Sub

    Public Sub del()
        sql_query = "Delete from tbl_ImageMaster where MasterId = " & Val(lblLedgerId.Text) & " And ImageType = 'CustomerImage'"
        obj.QueryExecute(sql_query)

        sql_query = "Delete from tbl_CustomerDetail Where LedgerId = " & Val(lblLedgerId.Text) '& " And TItemId = " & cmbItemName.SelectedValue
        obj.QueryExecute(sql_query)

        sql_query = "delete from tbl_LedgerMaster where LedgerId=" & Val(lblLedgerId.Text)
        obj.QueryExecute(sql_query)
    End Sub

    Public Sub getItemName()
        Dim orderBy As String

        Select Case UCase(M_TailoringItemSorting)
            Case "CODE"
                orderBy = " Order By Convert(int, TItemCode)"
                Exit Select
            Case "NAME"
                orderBy = " Order By TItemName"
                Exit Select
            Case Else
                orderBy = " Order By TItemName"
                Exit Select
        End Select

        Dim tmpds As New Data.DataSet
        If M_TailoringItemList = "Same Company" Then
            sql_query = "Select TItemId , TItemName, TItemRate From Tbl_TItemMaster Where CId = " & M_CId & " And ItemSubType = 'Tailoring' " & orderBy ' And ItemType = '' " & orderBy
            obj.LoadData(sql_query, tmpds)
        Else
            sql_query = "Select TItemId , TItemName, TItemRate From Tbl_TItemMaster Where  ItemSubType = 'Tailoring' " & orderBy ' And ItemType = '' " & orderBy
            obj.LoadData(sql_query, tmpds)
        End If
        'sql_query = "Select TItemId , TItemName, TItemRate From Tbl_TItemMaster Where CId = " & M_CId & " And ItemSubType = 'Tailoring' And ItemType = '' " & orderBy

        grdItems.Rows.Clear()
        For i As Integer = 0 To tmpds.Tables(0).Rows.Count - 1
            grdItems.Rows.Add()
            grdItems.Rows(i).Cells("TItemId").Value = tmpds.Tables(0).Rows(i)("TItemId")
            grdItems.Rows(i).Cells("TItemName").Value = tmpds.Tables(0).Rows(i)("TItemName")
        Next
    End Sub

    Public Sub loadTime()
        '_LedgerCodeInitial = "L"

        gridfill(False)
        'formatGrid()
        getItemName()
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
        gcData.Enabled = True
        gbMainDetail.Enabled = False
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

        If M_GenerateCustomerNumberSaveTime = "Yes" Then
            'Generate Customer Number Save Time
        Else
            getLedgerCode()
        End If

        'txtLedgerCode.Focus()
        dtpBirthDate.Checked = False
        dtpAnniDate.Checked = False

        txtState.Text = M_CState
        txtCountry.Text = M_CCountry

        sql_query = "Select Data1 From tbl_MiscMaster Where MiscName = '" & Trim(txtCountry.Text) & "'"
        txtCountryCode.Text = obj.ScalarExecute(sql_query)
        setTaxation()
        edit_ins = 1
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
        oldLedgerCode = Trim(txtLedgerCode.Text)
        txtLedgerName.Focus()
        LinkLabel1.Visible = True
    End Sub

    Public Sub saveClickTime()
        If UpdFromExcel = False Then
            gridfill(True)
        End If

        gbMainDetail.Enabled = False
        gcData.Enabled = True

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
        btnAdd.Focus()

        txtLedgerCode.Clear()
        txtLedgerName.Clear()
        'cmbUnder.SelectedIndex = -1
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtAcContactNo.Clear()
        txtCity.Clear()
        txtPincode.Clear()
        txtState.Clear()
        txtGSTNo.Clear()
        txtPANNo.Clear()
        cmbTaxation.SelectedIndex = 0
        txtCountry.Clear()
        txtPhone.Clear()
        txtMobile.Clear()
        txtFax.Clear()

        txtMobileNo2.Clear()
        cmbTranSMS.SelectedIndex = -1
        cmbPromoSMS.SelectedIndex = -1
        txtOpBal.Clear()
        txtAcContactPerson.Clear()
        cmbCustType.SelectedIndex = 0
        txtBeneficiaryName.Clear()
        txtBankAcType.Clear()
        txtIsBlock.Clear()
        txtBlackListReason.Clear()
        txtCountryCode.Clear()

        lblLedgerId.Text = "LedgerId"
        grdParaList.Rows.Clear()

        pbImg1.Image = Nothing
        txtImgPath1.Clear()
        LinkLabel1.Visible = False
        edit_ins = -1
    End Sub

    Public Sub deleteClickTime()
        gridfill(True)
        gbMainDetail.Enabled = False
        gcData.Enabled = True

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
        btnAdd.Focus()

        txtLedgerCode.Clear()
        txtLedgerName.Clear()
        'cmbUnder.SelectedIndex = -1
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtAcContactNo.Clear()
        txtCity.Clear()
        txtPincode.Clear()
        txtState.Clear()
        txtGSTNo.Clear()
        txtPANNo.Clear()
        cmbTaxation.SelectedIndex = 0
        txtCountry.Clear()
        txtPhone.Clear()
        txtMobile.Clear()
        txtFax.Clear()

        txtMobileNo2.Clear()
        cmbTranSMS.SelectedIndex = -1
        cmbPromoSMS.SelectedIndex = -1
        txtOpBal.Clear()
        txtAcContactPerson.Clear()
        cmbCustType.SelectedIndex = 0
        txtBeneficiaryName.Clear()
        txtBankAcType.Clear()
        txtIsBlock.Clear()
        txtBlackListReason.Clear()
        txtCountryCode.Clear()

        lblLedgerId.Text = "LedgerId"
        grdParaList.Rows.Clear()

        pbImg1.Image = Nothing
        txtImgPath1.Clear()
        LinkLabel1.Visible = False

        edit_ins = -1
    End Sub

    Public Sub cancelClickTime()
        gbMainDetail.Enabled = False
        gcData.Enabled = True

        btnAdd.Enabled = True
        btnAdd.Focus()
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = False
        btnExit.Enabled = True

        edit_ins = -1

        txtLedgerCode.Clear()
        txtLedgerName.Clear()
        'cmbUnder.SelectedIndex = -1
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtAcContactNo.Clear()
        txtCity.Clear()
        txtPincode.Clear()
        txtState.Clear()
        txtGSTNo.Clear()
        txtPANNo.Clear()
        cmbTaxation.SelectedIndex = 0
        txtCountry.Clear()
        txtPhone.Clear()
        txtMobile.Clear()
        txtFax.Clear()
        txtCountryCode.Clear()

        txtMobileNo2.Clear()
        cmbTranSMS.SelectedIndex = -1
        cmbPromoSMS.SelectedIndex = -1
        txtOpBal.Clear()
        txtAcContactPerson.Clear()
        cmbCustType.SelectedIndex = 0
        txtBeneficiaryName.Clear()
        txtBankAcType.Clear()

        txtIsBlock.Clear()
        txtBlackListReason.Clear()
        lblLedgerId.Text = "LedgerId"
        grdParaList.Rows.Clear()

        pbImg1.Image = Nothing
        txtImgPath1.Clear()
        LinkLabel1.Visible = False

    End Sub

    Public Sub exitClickTime()
        If edit_ins = -1 Then
            Me.Close()
        Else
            Dim dr As DialogResult
            dr = MsgBox("Sure To Exit Without Saving Data ?", MsgBoxStyle.YesNo)
            If dr = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If
        M_LedgerMasterF2 = False
    End Sub

    Public Sub fillData()
        If gvData.FocusedRowHandle < 0 Then
            Exit Sub
        End If

        lblLedgerId.Text = gvData.GetFocusedRowCellValue("LedgerId")
        txtLedgerCode.Text = gvData.GetFocusedRowCellValue("LedgerCode")
        txtLedgerName.Text = gvData.GetFocusedRowCellValue("LedgerName")
        txtAddress1.Text = gvData.GetFocusedRowCellValue("Address1")
        txtAddress2.Text = gvData.GetFocusedRowCellValue("Address2")
        txtAcContactNo.Text = gvData.GetFocusedRowCellValue("AcContactNo")
        txtCity.Text = gvData.GetFocusedRowCellValue("City")
        txtPincode.Text = gvData.GetFocusedRowCellValue("PinCode")
        txtState.Text = gvData.GetFocusedRowCellValue("State")
        txtCountryCode.Text = gvData.GetFocusedRowCellValue("CountryCode")
        txtCountry.Text = gvData.GetFocusedRowCellValue("Country")
        txtGSTNo.Text = gvData.GetFocusedRowCellValue("GSTNo")
        txtPANNo.Text = gvData.GetFocusedRowCellValue("PANNo")
        cmbTaxation.Text = gvData.GetFocusedRowCellValue("Taxation")
        txtPhone.Text = gvData.GetFocusedRowCellValue("PhoneNo")
        txtMobile.Text = gvData.GetFocusedRowCellValue("MobileNo")
        txtFax.Text = gvData.GetFocusedRowCellValue("FaxNo")
        If IsDBNull(gvData.GetFocusedRowCellValue("BirthDate")) = True Then
            dtpBirthDate.Checked = False
        Else
            dtpBirthDate.Checked = True
            dtpBirthDate.Value = gvData.GetFocusedRowCellValue("BirthDate")
        End If

        If IsDBNull(gvData.GetFocusedRowCellValue("AnniDate")) = True Then
            dtpAnniDate.Checked = False
        Else
            dtpAnniDate.Checked = True
            dtpAnniDate.Value = gvData.GetFocusedRowCellValue("AnniDate")
        End If

        txtMobileNo2.Text = gvData.GetFocusedRowCellValue("MobileNo2")
        cmbTranSMS.Text = gvData.GetFocusedRowCellValue("TranSMS")
        cmbPromoSMS.Text = gvData.GetFocusedRowCellValue("PromoSMS")
        txtAcContactPerson.Text = gvData.GetFocusedRowCellValue("AcContactPerson")
        txtBeneficiaryName.Text = gvData.GetFocusedRowCellValue("BeneficiaryName")
        txtBankAcType.Text = gvData.GetFocusedRowCellValue("BankAcType")
        cmbCustType.Text = gvData.GetFocusedRowCellValue("CustType")

        txtIsBlock.Text = gvData.GetFocusedRowCellValue("BankName")
        txtBlackListReason.Text = gvData.GetFocusedRowCellValue("BankAddress")

        txtEMail.Text = gvData.GetFocusedRowCellValue("EMail")

        Dim _YrTo As String = "_2025"
        sql_query = "Select DrOpening - CrOpening From tbl_LedgerOpeningBalance" & _YrTo & " Where LedgerId = " & Val(lblLedgerId.Text)
        txtOpBal.Text = obj.ScalarExecute(sql_query)

        Dim tmpds As New Data.DataSet
        sql_query = "Select Id,Image1 from tbl_ImageMaster where MasterId = " & Val(lblLedgerId.Text) & ""
        obj.LoadData(sql_query, tmpds)

        If tmpds.Tables(0).Rows.Count > 0 Then
            If IsDBNull(tmpds.Tables(0).Rows(0)("Image1")) = False Then
                Dim imgByteArray() As Byte
                imgByteArray = CType(tmpds.Tables(0).Rows(0)("Image1"), Byte())
                Dim stream As New MemoryStream(imgByteArray)
                Dim bmp As New Bitmap(stream)
                stream.Close()
                pbImg1.Image = bmp
            Else
                pbImg1.Image = Nothing
            End If
        Else
            pbImg1.Image = Nothing
        End If
    End Sub

    Public Sub getLedgerCode()
        'lblCode.Text = obj.ScalarExecute("Select IsNull(Max(Code),0) + 1 From Tbl_LedgerMaster Where G_Id = 11 And CId = " & M_CId)
        ''txtLedgerCode.Text = "C" & StrDup(5 - Trim(lblCode.Text).Length, "0") & Trim(lblCode.Text)
        'txtLedgerCode.Text = lblCode.Text

        txtLedgerCode.Text = obj.ScalarExecute("Select IsNull(Max(Code),0) + 1 From Tbl_LedgerMaster Where G_Id = 11 And CId = " & M_CId)
    End Sub

    Public Sub setTaxation()
        Select Case M_TaxCalculation
            Case "GST"
                If UCase(M_CState) = UCase(txtState.Text) Then
                    cmbTaxation.Text = "SGST+CGST"
                Else
                    cmbTaxation.Text = "IGST"
                End If
                Exit Select
            Case "VAT"
                cmbTaxation.Text = "VAT"
                Exit Select
            Case Else
                If UCase(M_CState) = UCase(txtState.Text) Then
                    cmbTaxation.Text = "SGST+CGST"
                Else
                    cmbTaxation.Text = "IGST"
                End If
                Exit Select
        End Select

    End Sub

#End Region

#Region "function"

    Public Function checkLedgerCode() As Boolean
        If M_AllwDupLcode = "Yes" Then
            Return False
        End If

        If edit_ins = 1 Then
            existLedgerCode = obj.ScalarExecute("select LedgerCode from tbl_LedgerMaster where CId = " & M_CId & " And LedgerCode='" & Trim(txtLedgerCode.Text) & "'")
            If Trim(txtLedgerCode.Text) = existLedgerCode Then
                Return True
            Else
                Return False
            End If
        Else
            existLedgerCode = obj.ScalarExecute("select LedgerCode from tbl_LedgerMaster where CId = " & M_CId & " And LedgerId <>" & Val(lblLedgerId.Text) & " and LedgerCode='" & Trim(txtLedgerCode.Text) & "'")
            If Trim(txtLedgerCode.Text) = existLedgerCode Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function validationOk() As Boolean
        If M_GenerateCustomerNumberSaveTime = "Yes" Then

        Else
            If Trim(txtLedgerCode.Text) = "" Then
                MsgBox("Please Specify Customer Code", MsgBoxStyle.Information)
                txtLedgerCode.Focus()
                Return False
            End If
        End If
        If Trim(txtLedgerName.Text) = "" Then
            MsgBox("Please Specify Customer Name", MsgBoxStyle.Information)
            txtLedgerName.Focus()
            Return False
        End If
        If checkLedgerCode() = True Then
            MsgBox("Customer Code Already Exists, Please Specify Another One", MsgBoxStyle.Critical)
            txtLedgerCode.Focus()
            Return False
        End If

        If Trim(txtMobile.Text) = "" Then
            Dim dr1 As DialogResult
            dr1 = MsgBox("Mobile Number Not Specify. Do You Want to Save ?", MsgBoxStyle.YesNo)
            If dr1 = Windows.Forms.DialogResult.Yes Then
            Else
                txtMobile.Focus()
                Return False
            End If
        Else
            If UCase(M_ValidateMobileNoLength) = "YES" Then
                If Trim(txtMobile.Text.Length) <> Val(M_MobileNoLength) Then
                    MsgBox("Please Specify Correct Mobile Number (" & M_MobileNoLength & " Digits Required)", MsgBoxStyle.Information)
                    txtMobile.Focus()
                    Return False
                End If
            End If
        End If

        If Trim(txtState.Text) = "" Then
            MsgBox("Please Select State", MsgBoxStyle.Information)
            txtState.Focus()
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Events"

    Private Sub FrmLedgerMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UCase(M_ValidateMobileNoLength) = "YES" Then
            txtMobile.MaxLength = Val(M_MobileNoLength)
            txtMobileNo2.MaxLength = Val(M_MobileNoLength)
        End If

        If M_GenerateCustomerNumberSaveTime = "Yes" Then
            txtLedgerCode.ReadOnly = True
            txtLedgerCode.TabStop = False
        End If

        If UCase(M_AllowWebcamCaptureImage) = "YES" Then
            btnStart.Visible = True
        Else
            btnStart.Visible = False
        End If

        Select Case M_TaxCalculation
            Case "GST"
                lblGSTNo.Text = "GST No."
                cmbTaxation.Items.Add("-")
                cmbTaxation.Items.Add("SGST+CGST")
                cmbTaxation.Items.Add("IGST")
                Exit Select
            Case "VAT"
                lblGSTNo.Text = "VAT No."
                cmbTaxation.Items.Add("-")
                cmbTaxation.Items.Add("VAT")
                Exit Select
            Case Else
                lblGSTNo.Text = "GST No."
                cmbTaxation.Items.Add("-")
                cmbTaxation.Items.Add("SGST+CGST")
                cmbTaxation.Items.Add("IGST")
                Exit Select
        End Select

        If M_CompanyWiseMiscMaster = "Yes" Then
            ComboFill(cmbCustType, "Select MiscId , MiscName From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'Customer Type' Order By MiscName")
        Else
            ComboFill(cmbCustType, "Select MiscId , MiscName From Tbl_MiscMaster Where MiscType = 'Customer Type' Order By MiscName")
        End If

        Select Case M_LedgerMasterF2
            Case True
                loadTime()
                addClickTime()
                Exit Select
            Case False
                loadTime()
                Exit Select
        End Select

        'Allwin
        Select Case UCase(M_CustNameCharCasing)
            Case "UPPER"
                txtLedgerName.CharacterCasing = CharacterCasing.Upper
                Exit Select
            Case "LOWER"
                txtLedgerName.CharacterCasing = CharacterCasing.Lower
                Exit Select
            Case "NORMAL"
                txtLedgerName.CharacterCasing = CharacterCasing.Normal
                Exit Select
            Case Else
                txtLedgerName.CharacterCasing = CharacterCasing.Upper
                Exit Select
        End Select

        txtAddress1.CharacterCasing = CharacterCasing.Upper
        txtAddress2.CharacterCasing = CharacterCasing.Upper
        txtAcContactNo.CharacterCasing = CharacterCasing.Upper
        txtCity.CharacterCasing = CharacterCasing.Upper
        txtCountry.CharacterCasing = CharacterCasing.Upper


    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If checkRightsToAdd("CUSTOMER MASTER") = False Then
            MsgBox("Unable To Add New Record", MsgBoxStyle.Information)
            Exit Sub
        End If

        'If M_IsDemoSetup = True Then'====
        '    sql_query = "Select Count(*) From Tbl_LedgerMaster Where G_Id In (11) And CId = " & M_CId
        '    If M_LedgerLimit < obj.ScalarExecute(sql_query) Then
        '        MsgBox("Unable to Add Customer Entry" & vbCrLf & "Please Contact Software Developer to Exceed Limit", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If
        'End If

        addClickTime()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If checkRightsToEdit("CUSTOMER MASTER") = False Then
            MsgBox("Unable To Edit Record", MsgBoxStyle.Information)
            Exit Sub
        End If

        editClickTime()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If M_GenerateCustomerNumberSaveTime = "Yes" Then

        Else
            If Trim(txtLedgerCode.Text) = "" Then
                MsgBox("Please Specify Customer Code", MsgBoxStyle.Information)
                txtLedgerCode.Focus()
                Exit Sub
            End If
        End If
        If cmbCustType.SelectedIndex = -1 Then
            MsgBox("Please Select Customer Type", MsgBoxStyle.Information)
            cmbCustType.Focus()
            Exit Sub
        End If

        If Trim(txtLedgerName.Text) = "" Then
            MsgBox("Please Specify Customer Name", MsgBoxStyle.Information)
            txtLedgerName.Focus()
            Exit Sub
        End If

        If UpdFromExcel = False Then
            If checkLedgerCode() = True Then
                MsgBox("Customer Code Already Exists, Please Specify Another One", MsgBoxStyle.Critical)
                txtLedgerCode.Focus()
                Exit Sub
            End If

            If Trim(txtMobile.Text) = "" Then
                Dim dr1 As DialogResult
                dr1 = MsgBox("Mobile Number Not Specify. Do You Want to Save ?", MsgBoxStyle.YesNo)
                If dr1 = Windows.Forms.DialogResult.Yes Then
                Else
                    txtMobile.Focus()
                    Exit Sub
                End If
            Else
                If UCase(M_ValidateMobileNoLength) = "YES" Then
                    If Trim(txtMobile.Text.Length) <> Val(M_MobileNoLength) Then
                        MsgBox("Please Specify Correct Mobile Number (" & M_MobileNoLength & " Digits Required)", MsgBoxStyle.Information)
                        txtMobile.Focus()
                        Exit Sub
                    End If
                End If
            End If
        End If


        'If Trim(txtMobile.Text) <> "" And Trim(txtMobile.Text.Length) <> 10 Then
        '    MsgBox("Please Specify Correct Mobile Number (10 Digits Required)", MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        If Trim(txtState.Text) = "" Then
            MsgBox("Please Select State", MsgBoxStyle.Information)
            txtState.Focus()
            Exit Sub
        End If

        If Trim(txtCountryCode.Text) = "" Then
            MsgBox("Please Select Country Code", MsgBoxStyle.Information)
            txtCountryCode.Focus()
            Exit Sub
        End If
        If cmbTaxation.SelectedIndex = -1 Or Trim(cmbTaxation.Text) = "" Then
            MsgBox("Please Select Taxation", MsgBoxStyle.Information)
            cmbTaxation.Focus()
            Exit Sub
        End If


        If gvData.RowCount >= 1 And edit_ins = 1 Then
            If Trim(txtMobile.Text) <> "" Then
                If Trim(txtMobile.Text) = gvData.GetRowCellValue(0, "MobileNo") Or Trim(txtMobile.Text) = gvData.GetRowCellValue(0, "MobileNo2") Then
                    Dim dr As DialogResult
                    dr = MsgBox("Seems Duplicate Record, Sure To Save ?", MsgBoxStyle.YesNo)
                    If dr = Windows.Forms.DialogResult.Yes Then
                        txtLedgerName.Focus()
                    Else
                        Exit Sub
                    End If
                End If
            End If
        End If


        If edit_ins = 1 Then
            insert()
        Else
            edit()
        End If

        saveClickTime()
    End Sub

    Private Sub btnSaveMsrmnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveMsrmnt.Click
        'If cmbItemName.SelectedIndex = -1 Then
        '    MsgBox("Please Select Item Name Properly", MsgBoxStyle.Information)
        '    cmbItemName.Focus()
        '    Exit Sub
        'End If

        If edit_ins = 1 Then
            If validationOk() = False Then
                Exit Sub
            End If

            insert()

            sql_query = "Select Max(LedgerId) From Tbl_LedgerMaster Where CId = " & M_CId 'Where LedgerName = 'N" & Trim(txtLedgerName.Text) & "' "
            lblLedgerId.Text = obj.ScalarExecute(sql_query)

            sql_query = "Insert Into tbl_CustomerDetail (LedgerId, TItemId, ParaId, ParaValue, Notes, ParaValue2) (Select " & lblLedgerId.Text & ", " & M_GeneralMeasurementTItemId & ", ParaId, '', '', '' From tbl_TItemParameter where TItemId = " & M_GeneralMeasurementTItemId & ")"
            obj.QueryExecute(sql_query)

            insert_CustomerDetail()
            edit_ins = 0

            MsgBox("Customer Created and Measurement Details Saved Successfully", MsgBoxStyle.Information)
            gridfill(True)
        Else
            sql_query = "Select Count(*) From tbl_CustomerDetail Where LedgerId = " & Val(lblLedgerId.Text) & " And TItemId = " & M_GeneralMeasurementTItemId
            If obj.ScalarExecute(sql_query) = 0 Then
                sql_query = "Insert Into tbl_CustomerDetail (LedgerId, TItemId, ParaId, ParaValue, Notes, ParaValue2) (Select " & Val(lblLedgerId.Text) & ", " & M_GeneralMeasurementTItemId & ", ParaId, '', '', '' From tbl_TItemParameter where TItemId = " & M_GeneralMeasurementTItemId & ")"
                obj.QueryExecute(sql_query)
            End If

            insert_CustomerDetail()
            If UpdFromExcel = False Then
                MsgBox("Measurement Details Saved Successfully", MsgBoxStyle.Information)
            Else
                sql_query = "Update tbl_LedgerMaster set EMail = '-' where LedgerId = " & Val(lblLedgerId.Text)
                obj.QueryExecute(sql_query)
            End If
        End If

        grdItems.Focus()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If checkRightsToDelete("CUSTOMER MASTER") = False Then
            MsgBox("Unable To Delete Record", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim dr As DialogResult
        dr = MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            sql_query = "Select Count(*) From tbl_InvoiceMaster Where LedgerId = " & Val(lblLedgerId.Text)
            If obj.ScalarExecute(sql_query) > 0 Then
                MsgBox("Unable To Delete. Invoice Entry Exist", MsgBoxStyle.Information)
                Exit Sub
            End If

            sql_query = "Select Count(*) From tbl_VoucherEntryMast Where DrLedgerId = " & Val(lblLedgerId.Text) & " Or CrLedgerId = " & Val(lblLedgerId.Text)
            If obj.ScalarExecute(sql_query) > 0 Then
                MsgBox("Unable To Delete. A/c Entry Exist", MsgBoxStyle.Information)
                Exit Sub
            End If

            sql_query = "Select Count(*) From tbl_SalesMaster Where LedgerId = " & Val(lblLedgerId.Text) & " "
            If obj.ScalarExecute(sql_query) > 0 Then
                MsgBox("Unable To Delete Customer, Reference Records Found", MsgBoxStyle.Information)
                Exit Sub
            End If

            del()
            deleteClickTime()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        cancelClickTime()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        exitClickTime()
    End Sub

    Private Sub txtImgPath1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtImgPath1.DoubleClick
        txtImgPath1.Text = M_getImagePath(Me)
        pbImg1.ImageLocation = txtImgPath1.Text
    End Sub

    Private Sub txtImgPath1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtImgPath1.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                txtImgPath1.Text = M_getImagePath(Me)
                pbImg1.ImageLocation = txtImgPath1.Text
                Exit Select
            Case Keys.Delete
                Dim dr As DialogResult
                dr = MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo)
                If dr = Windows.Forms.DialogResult.Yes Then
                    pbImg1.Image = Nothing
                    txtImgPath1.Clear()
                    sql_query = "Delete from tbl_ImageMaster where MasterId = " & Val(lblLedgerId.Text) & " And ImageType = 'CustomerImage'"
                    obj.QueryExecute(sql_query)
                    cancelClickTime()
                End If
                Exit Select
        End Select
    End Sub

    Private Sub txtImgPath1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtImgPath1.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Trim(txtImgPath1.Text).Length > 0 Then
            sql_query = "Delete from tbl_ImageMaster where MasterId = " & Val(lblLedgerId.Text) & " And ImageType = 'CustomerImage'"
            obj.QueryExecute(sql_query)

            InsertCustomerImage(Val(lblLedgerId.Text))
            'sql_query = "Insert Into tbl_ImageMaster (MasterId, Image1) Values (@Image) Where MasterId = " & Val(lblLedgerId.Text)
            'obj.QueryExecuteImage(sql_query, pbImg1.ImageLocation)
        Else
            MsgBox("Please Select Image Proper!", MsgBoxStyle.Information)
            Exit Sub
        End If
        cancelClickTime()
        gridfill(True)

    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If gvData.SelectedRowsCount = 0 Then
            MsgBox("Please Select Item Name", MsgBoxStyle.Information)
            Exit Sub
        End If

        If Val(lblLedgerId.Text) <= 0 Then
            MsgBox("Please Select Proper Record", MsgBoxStyle.Information)
            Exit Sub
        End If

        Select Case M_MeasurementSlipType
            Case "Traditional"
                'prepare_MeasurementSheet_Traditional(Val(lblLedgerId.Text), False, grdItems.CurrentRow.Cells("TItemId").Value)
                Exit Select
            Case Else
                prepare_CustomerMasterMeasurement(Val(lblLedgerId.Text), False, grdItems.CurrentRow.Cells("TItemId").Value)
                Exit Select
        End Select
    End Sub


    Public Sub prepare_CustomerMasterMeasurement(ByVal _LedgerId As Integer, ByVal print As Boolean, ByVal extraQry As String)
        Dim stiRptV As New StiReport()
        stiRptV.Load(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\" & M_CustMaster_MeasurementRptFile) 'CustMaster_MeasurementSheet.mrt
        stiRptV.Compile()

        For Each item As Stimulsoft.Report.Dictionary.StiSqlDatabase In stiRptV.CompiledReport.Dictionary.Databases
            item.ConnectionString = M_Stumul_ConnectionString
        Next

        stiRptV.Item("CName") = M_CName
        stiRptV.Item("CId") = " CId = " & M_CId
        stiRptV.Item("Filter") = " LedgerId = " & _LedgerId & " And TItemId = " & extraQry & ""

        stiRptV.Render(False)
        stiRptV.Dictionary.Synchronize()

        Dim frmRpt As New FrmReportViewer_Stimul("", Nothing, "", print)
        frmRpt.StiViwerControl.Report = stiRptV
        frmRpt.StiViwerControl.Refresh()
        frmRpt.MdiParent = FrmMDIMain
        If print = True Then
            stiRptV.Print(True)
        Else
            frmRpt.Show()
        End If

        'Dim tmpDs As New Data.DataSet

        'sql_query = "Select * From View_CustomerMaster_MeasurementPrint Where LedgerId = " & _LedgerId & " And TItemId = " & extraQry & ""
        'obj.LoadData(sql_query, tmpDs)

        'If tmpDs.Tables(0).Rows.Count = 0 Then
        '    MsgBox("Please Save Measurements for Selected Item", MsgBoxStyle.Information)
        '    btnSaveMsrmnt.Focus()
        '    Exit Sub
        'End If

        'Dim _ds As New DataSet1
        'For i As Integer = 0 To tmpDs.Tables(0).Rows.Count - 1
        '    _ds.Tables("View_CustomerMaster_MeasurementPrint").Rows.Add()
        '    For j As Integer = 0 To tmpDs.Tables(0).Columns.Count - 1
        '        _ds.Tables("View_CustomerMaster_MeasurementPrint").Rows(i)(j) = tmpDs.Tables(0).Rows(i)(j)
        '    Next
        'Next

        'Dim cryRpt As New ReportDocument
        'cryRpt.Load(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\rptCustMast_Measurement_AM1.rpt")
        'cryRpt.SetDataSource(_ds)

        'Dim froms As ParameterFieldDefinitions
        'Dim from As ParameterFieldDefinition
        'Dim pv As New ParameterValues
        'Dim pdv As New ParameterDiscreteValue

        'pdv.Value = M_NotesFontName '_font
        'froms = cryRpt.DataDefinition.ParameterFields
        'from = froms.Item("FontName")
        'pv = from.CurrentValues
        'pv.Clear()
        'pv.Add(pdv)
        'from.ApplyCurrentValues(pv)

        'pdv.Value = M_NotesFontSize '_fontSize
        'froms = cryRpt.DataDefinition.ParameterFields
        'from = froms.Item("FontSize")
        'pv = from.CurrentValues
        'pv.Clear()
        'pv.Add(pdv)
        'from.ApplyCurrentValues(pv)

        'pdv.Value = M_ShowCustNameInMeasurementSheet
        'froms = cryRpt.DataDefinition.ParameterFields
        'from = froms.Item("ShowCustName")
        'pv = from.CurrentValues
        'pv.Clear()
        'pv.Add(pdv)
        'from.ApplyCurrentValues(pv)

        'pdv.Value = M_ShowCustMobNoInMeasurementSheet
        'froms = cryRpt.DataDefinition.ParameterFields
        'from = froms.Item("ShowMobNo")
        'pv = from.CurrentValues
        'pv.Clear()
        'pv.Add(pdv)
        'from.ApplyCurrentValues(pv)

        'pdv.Value = M_CName
        'froms = cryRpt.DataDefinition.ParameterFields
        'from = froms.Item("CName")
        'pv = from.CurrentValues
        'pv.Clear()
        'pv.Add(pdv)
        'from.ApplyCurrentValues(pv)

        'FrmRptViewer_CR.CrystalReportViewer1.ReportSource = cryRpt
        'FrmRptViewer_CR.CrystalReportViewer1.Refresh()
        'FrmRptViewer_CR.Show()       
    End Sub

#End Region

#Region "Navigation"

    Private Sub txtLedgerCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLedgerCode.KeyPress
        If e.KeyChar = Chr(13) Then
            If Trim(txtLedgerCode.Text) = "" Then
                Exit Sub
            End If
            txtLedgerName.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            grdItems.Focus()
        End If
    End Sub

    Private Sub txtLedgerName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLedgerName.KeyPress
        If e.KeyChar = Chr(13) Then
            If Trim(txtLedgerName.Text) = "" Then
                Exit Sub
            End If
            SendKeys.Send("{Tab}")
        End If

        If e.KeyChar = Chr(27) Then
            grdItems.Focus()
        End If
    End Sub

    Private Sub cmbUnder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTranSMS.KeyPress, cmbPromoSMS.KeyPress, cmbCustType.KeyPress
        If e.KeyChar = Chr(13) Then
            If sender.SelectedIndex = -1 Or Trim(sender.Text) = "" Then
                Exit Sub
            End If
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtCity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCity.KeyPress, txtAddress1.KeyPress, txtAddress2.KeyPress, txtPincode.KeyPress, txtPhone.KeyPress, txtFax.KeyPress, txtEMail.KeyPress, dtpBirthDate.KeyPress, dtpAnniDate.KeyPress, txtGSTNo.KeyPress, txtPANNo.KeyPress, cmbTaxation.KeyPress, txtOpBal.KeyPress, txtBeneficiaryName.KeyPress, txtBankAcType.KeyPress, txtIsBlock.KeyPress, txtCountryCode.KeyPress, txtAcContactNo.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If

        If e.KeyChar = Chr(27) Then
            grdItems.Focus()
        End If
    End Sub

    Private Sub txtState_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtState.KeyPress, txtCountry.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
        If (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Then
            M_SearchText = e.KeyChar
            M_callingForm_MiscHelp = sender.tag & "Help"
            FrmHelpMiscList.ShowDialog()
        End If

        If e.KeyChar = Chr(27) Then
            grdItems.Focus()
        End If
    End Sub

    Private Sub txtMobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMobile.KeyPress, txtMobileNo2.KeyPress, txtF_MobileNo.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
        If e.KeyChar = Chr(8) Then
            Exit Sub
        End If

        If e.KeyChar = Chr(27) Then
            grdItems.Focus()
        End If

        'If checkNumber(Asc(e.KeyChar)) = False Then
        '    e.KeyChar = Chr(0)
        'End If
    End Sub

    Private Sub cmbUnder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPromoSMS.Enter, cmbTaxation.Enter, cmbCustType.Enter
        sender.DroppedDown = True
        If sender.SelectedIndex = -1 And sender.Items.Count > 0 Then
            sender.SelectedIndex = 0
        End If
    End Sub

#Region "City/State/Country Help"

    Private Sub txtState_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtState.KeyDown, txtCity.KeyDown, txtCountry.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                M_callingForm_MiscHelp = sender.tag & "Help"
                FrmHelpMiscList.ShowDialog()
                Exit Select
            Case Keys.F2
                If Trim(sender.Text) = "" Then
                    MsgBox("Please Specify " & sender.Tag, MsgBoxStyle.Information)
                    Exit Sub
                End If

                If M_checkMiscMaster(sender.Tag, Trim(sender.Text)) = False Then
                    insertMiscMaster(sender.Tag, Trim(sender.Text))
                    MsgBox(sender.Tag & " Added Successfully", MsgBoxStyle.Information)
                Else
                    MsgBox(sender.Tag & " Already Exist", MsgBoxStyle.Information)
                End If
                Exit Select
        End Select
    End Sub

    Private Sub txtState_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtState.DoubleClick, txtCity.DoubleClick, txtCountry.DoubleClick
        M_callingForm_MiscHelp = sender.tag & "Help"
        FrmHelpMiscList.ShowDialog()
    End Sub

#End Region

    Private Sub txtState_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtState.Validating
        'If UCase(M_CState) = UCase(txtState.Text) Then
        '    cmbTaxation.Text = "SGST+CGST"
        'Else
        '    cmbTaxation.Text = "IGST"
        'End If
        setTaxation()
    End Sub

    Private Sub grdParaList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdParaList.CellDoubleClick
        If grdParaList.Columns(grdParaList.CurrentCell.ColumnIndex).Name = "Notes" Then
            Select Case M_NotesStyle
                Case "Notes"
                    M_callingForm_MiscHelp = "Notes Help (Customer)"
                    FrmHelpMiscList.ShowDialog()
                    Exit Select
            End Select
        End If
    End Sub

    Private Sub grdParaList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdParaList.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                If grdParaList.Columns(grdParaList.CurrentCell.ColumnIndex).Name = "Notes" Then
                    grdParaList.CurrentCell.Value = ""
                End If
                Exit Select
            Case Keys.F1
                If grdParaList.Columns(grdParaList.CurrentCell.ColumnIndex).Name = "Notes" Then
                    Select Case M_NotesStyle
                        Case "Notes"
                            M_callingForm_MiscHelp = "Notes Help (Customer)"
                            FrmHelpMiscList.ShowDialog()
                            Exit Select
                        Case "Style"

                            Exit Select
                    End Select

                End If
                Exit Select
            Case Keys.F2
                If grdParaList.Columns(grdParaList.CurrentCell.ColumnIndex).Name = "Notes" Then
                    If Trim(grdParaList.CurrentCell.Value) = "" Then
                        MsgBox("Please Specify Parameter Notes", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Select Case M_NotesStyle
                        Case "Notes"
                            If M_checkMiscMaster("Notes", Trim(grdParaList.CurrentCell.Value)) = False Then
                                insertMiscMaster("Notes", Trim(grdParaList.CurrentCell.Value))
                                MsgBox("Parameter Notes Added Successfully", MsgBoxStyle.Information)
                            Else
                                MsgBox("Parameter Notes Already Exist", MsgBoxStyle.Information)
                            End If
                            Exit Select
                        Case "Style"
                            If M_checkMiscMaster(UCase(grdItems.CurrentRow.Cells("TItemName").Value) & " STYLE", Trim(grdParaList.CurrentCell.Value)) = False Then
                                insertMiscMaster(UCase(grdItems.CurrentRow.Cells("TItemName").Value) & " STYLE", Trim(grdParaList.CurrentCell.Value))
                                MsgBox("Style Added Successfully", MsgBoxStyle.Information)
                            Else
                                MsgBox("Style Already Exist", MsgBoxStyle.Information)
                            End If
                            Exit Select
                        Case Else
                            MsgBox("Please Set Notes/Style Setting (Notes or Style)", MsgBoxStyle.Information)
                            Exit Select
                    End Select

                End If
                Exit Select
            Case Keys.F6

                Exit Select
        End Select
    End Sub

    Private Sub grdParaList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdParaList.KeyPress
        If (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Then
            If grdParaList.Columns(grdParaList.CurrentCell.ColumnIndex).Name = "Notes" Then
                M_SearchText = e.KeyChar
                Select Case M_NotesStyle
                    Case "Notes"
                        M_callingForm_MiscHelp = "Notes Help (Customer)"
                        FrmHelpMiscList.ShowDialog()
                        Exit Select
                End Select
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        gridfill(True)
    End Sub

    Private Sub gvData_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvData.KeyDown
        If e.KeyCode = Keys.X Then
            Try
                Dim tmpFileName As String = ""
                Dim ofd As New FolderBrowserDialog()
                If ofd.ShowDialog() = DialogResult.OK Then
                    If Trim(ofd.SelectedPath) <> "" Then
                        UpdFromExcel = True
                        SplashScreenManager.ShowForm(GetType(WaitForm1))
                        For Each foundFile As String In My.Computer.FileSystem.GetFiles(ofd.SelectedPath)
                            Dim FileExtension As String = Path.GetExtension(foundFile)
                            Try
                                If FileExtension.ToLower() = ".xls" Then
                                    tmpFileName = foundFile
                                    Dim dsExcel As New DataSet
                                    obj.LoadData_Excel("SELECT * FROM [Sheet1$]", dsExcel, "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & foundFile & "; Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
                                    If dsExcel.Tables(0).Rows.Count > 0 Then

                                        'SplashScreenManager.Default.SetWaitFormDescription("Measurement Of " & txtF_LedgerName.Text)

                                        If gvData.RowCount > 0 Then
                                            sql_query = "Update tbl_LedgerMaster set EMail= '" & foundFile & "' where LedgerId = " & Val(gvData.GetRowCellValue(0, "LedgerId"))
                                            obj.QueryExecute(sql_query)

                                            sql_query = "Insert Into tbl_SMSTrail (InvId, SmsType, SmsDtm) Values (" & Val(gvData.GetRowCellValue(0, "LedgerId")) & ", '" & foundFile & "', NULL)"
                                            obj.QueryExecute(sql_query)
                                        End If
                                        'If grdData.Rows.Count > 0 Then

                                        '    Try
                                        '        'sql_query = "select count(0) from tbl_LedgerMaster where LedgerId = " & Val(lblLedgerId.Text) & " and EMail = '' "
                                        '        'If obj.ScalarExecute(sql_query) > 0 Then
                                        '        grdData.Rows(0).Selected = True
                                        '        grdData_CellClick(Nothing, Nothing)
                                        '        btnEdit_Click(Nothing, Nothing)
                                        '        grdItems.Rows(0).Selected = True
                                        '        grdItems_CellDoubleClick(Nothing, Nothing)

                                        '        grdParaList.Rows(0).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(9)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(9)(7)))
                                        '        grdParaList.Rows(1).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(9)(8) Is DBNull.Value, "", dsExcel.Tables(0).Rows(9)(8)))
                                        '        grdParaList.Rows(2).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(11)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(11)(1)))
                                        '        grdParaList.Rows(3).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(12)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(12)(1)))
                                        '        grdParaList.Rows(4).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(13)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(13)(1)))
                                        '        grdParaList.Rows(5).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(14)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(14)(1)))
                                        '        grdParaList.Rows(6).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(15)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(15)(1)))
                                        '        grdParaList.Rows(7).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(11)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(11)(2)))
                                        '        grdParaList.Rows(8).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(11)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(11)(3)))
                                        '        grdParaList.Rows(9).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(13)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(13)(3)))
                                        '        grdParaList.Rows(10).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(14)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(14)(3)))
                                        '        grdParaList.Rows(11).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(11)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(11)(4)))
                                        '        grdParaList.Rows(12).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(11)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(11)(5)))
                                        '        grdParaList.Rows(13).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(12)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(12)(5)))
                                        '        grdParaList.Rows(14).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(13)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(13)(5)))
                                        '        grdParaList.Rows(15).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(14)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(14)(5)))
                                        '        grdParaList.Rows(16).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(11)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(11)(6)))
                                        '        grdParaList.Rows(17).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(11)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(11)(7)))
                                        '        grdParaList.Rows(18).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(12)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(12)(7)))
                                        '        grdParaList.Rows(19).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(16)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(16)(6)))
                                        '        grdParaList.Rows(20).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(17)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(17)(6)))
                                        '        grdParaList.Rows(21).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(18)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(18)(6)))
                                        '        grdParaList.Rows(22).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(19)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(19)(6)))
                                        '        grdParaList.Rows(23).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(20)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(20)(6)))
                                        '        grdParaList.Rows(24).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(26)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(26)(1)))
                                        '        grdParaList.Rows(25).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(27)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(27)(1)))
                                        '        grdParaList.Rows(26).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(28)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(28)(1)))
                                        '        grdParaList.Rows(27).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(27)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(27)(2)))
                                        '        grdParaList.Rows(28).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(27)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(27)(3)))
                                        '        grdParaList.Rows(29).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(27)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(27)(4)))
                                        '        grdParaList.Rows(30).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(27)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(27)(5)))
                                        '        grdParaList.Rows(31).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(28)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(28)(5)))
                                        '        grdParaList.Rows(32).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(29)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(29)(5)))
                                        '        grdParaList.Rows(33).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(27)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(27)(6)))
                                        '        grdParaList.Rows(34).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(28)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(28)(6)))
                                        '        grdParaList.Rows(35).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(29)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(29)(6)))
                                        '        grdParaList.Rows(36).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(27)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(27)(7)))
                                        '        grdParaList.Rows(37).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(28)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(28)(7)))
                                        '        grdParaList.Rows(38).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(29)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(29)(7)))
                                        '        grdParaList.Rows(39).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(31)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(31)(5)))
                                        '        grdParaList.Rows(40).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(32)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(32)(5)))
                                        '        grdParaList.Rows(41).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(33)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(33)(5)))
                                        '        grdParaList.Rows(42).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(34)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(34)(5)))
                                        '        grdParaList.Rows(43).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(35)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(35)(5)))
                                        '        grdParaList.Rows(44).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(31)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(31)(6)))
                                        '        grdParaList.Rows(45).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(32)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(32)(6)))
                                        '        grdParaList.Rows(46).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(33)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(33)(6)))
                                        '        grdParaList.Rows(47).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(34)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(34)(6)))
                                        '        grdParaList.Rows(48).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(35)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(35)(6)))
                                        '        grdParaList.Rows(49).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(31)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(31)(7)))
                                        '        grdParaList.Rows(50).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(32)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(32)(7)))
                                        '        grdParaList.Rows(51).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(33)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(33)(7)))
                                        '        grdParaList.Rows(52).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(34)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(34)(7)))
                                        '        grdParaList.Rows(53).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(35)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(35)(7)))
                                        '        grdParaList.Rows(54).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(58)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(58)(1)))
                                        '        grdParaList.Rows(55).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(59)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(59)(1)))
                                        '        grdParaList.Rows(56).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(60)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(60)(1)))
                                        '        grdParaList.Rows(57).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(58)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(58)(2)))
                                        '        grdParaList.Rows(58).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(58)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(58)(3)))
                                        '        grdParaList.Rows(59).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(58)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(58)(4)))
                                        '        grdParaList.Rows(60).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(58)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(58)(5)))
                                        '        grdParaList.Rows(61).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(59)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(59)(5)))
                                        '        grdParaList.Rows(62).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(58)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(58)(6)))
                                        '        grdParaList.Rows(63).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(61)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(61)(4)))
                                        '        grdParaList.Rows(64).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(62)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(62)(4)))
                                        '        grdParaList.Rows(65).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(63)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(63)(4)))
                                        '        grdParaList.Rows(66).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(64)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(64)(4)))
                                        '        grdParaList.Rows(67).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(65)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(65)(4)))
                                        '        grdParaList.Rows(68).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(61)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(61)(5)))
                                        '        grdParaList.Rows(69).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(62)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(62)(5)))
                                        '        grdParaList.Rows(70).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(63)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(63)(5)))
                                        '        grdParaList.Rows(71).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(64)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(64)(5)))
                                        '        grdParaList.Rows(72).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(64)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(64)(5)))
                                        '        grdParaList.Rows(73).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(61)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(61)(6)))
                                        '        grdParaList.Rows(74).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(62)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(62)(6)))
                                        '        grdParaList.Rows(75).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(63)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(63)(6)))
                                        '        grdParaList.Rows(76).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(64)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(64)(6)))
                                        '        grdParaList.Rows(77).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(65)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(65)(6)))
                                        '        grdParaList.Rows(78).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(71)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(71)(1)))
                                        '        grdParaList.Rows(79).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(72)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(72)(1)))
                                        '        grdParaList.Rows(80).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(73)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(73)(1)))
                                        '        grdParaList.Rows(81).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(74)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(74)(1)))
                                        '        grdParaList.Rows(82).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(75)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(75)(1)))
                                        '        grdParaList.Rows(83).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(76)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(76)(1)))
                                        '        grdParaList.Rows(84).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(77)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(77)(1)))
                                        '        grdParaList.Rows(85).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(71)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(71)(2)))
                                        '        grdParaList.Rows(86).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(72)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(72)(2)))
                                        '        grdParaList.Rows(87).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(71)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(71)(3)))
                                        '        grdParaList.Rows(88).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(72)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(72)(3)))
                                        '        grdParaList.Rows(89).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(73)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(73)(3)))
                                        '        grdParaList.Rows(90).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(74)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(74)(3)))
                                        '        grdParaList.Rows(91).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(75)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(75)(3)))
                                        '        grdParaList.Rows(92).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(71)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(71)(4)))
                                        '        grdParaList.Rows(93).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(72)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(72)(4)))
                                        '        grdParaList.Rows(94).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(71)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(71)(5)))
                                        '        grdParaList.Rows(95).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(72)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(72)(5)))
                                        '        grdParaList.Rows(96).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(73)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(73)(5)))
                                        '        grdParaList.Rows(97).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(74)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(74)(5)))
                                        '        grdParaList.Rows(98).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(75)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(75)(5)))
                                        '        grdParaList.Rows(99).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(77)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(77)(5)))
                                        '        grdParaList.Rows(100).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(78)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(78)(5)))
                                        '        grdParaList.Rows(101).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(79)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(79)(5)))
                                        '        grdParaList.Rows(102).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(80)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(80)(5)))
                                        '        grdParaList.Rows(103).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(81)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(81)(5)))
                                        '        grdParaList.Rows(104).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(71)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(71)(6)))
                                        '        grdParaList.Rows(105).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(72)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(72)(6)))
                                        '        grdParaList.Rows(106).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(77)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(77)(6)))
                                        '        grdParaList.Rows(107).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(78)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(78)(6)))
                                        '        grdParaList.Rows(108).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(79)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(79)(6)))
                                        '        grdParaList.Rows(109).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(80)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(80)(6)))
                                        '        grdParaList.Rows(110).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(81)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(81)(6)))
                                        '        grdParaList.Rows(111).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(71)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(71)(7)))
                                        '        grdParaList.Rows(112).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(72)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(72)(7)))
                                        '        grdParaList.Rows(113).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(73)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(73)(7)))
                                        '        grdParaList.Rows(114).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(86)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(86)(1)))
                                        '        grdParaList.Rows(115).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(87)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(87)(1)))
                                        '        grdParaList.Rows(116).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(88)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(88)(1)))
                                        '        grdParaList.Rows(117).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(89)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(89)(1)))
                                        '        grdParaList.Rows(118).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(90)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(90)(1)))
                                        '        grdParaList.Rows(119).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(86)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(86)(2)))
                                        '        grdParaList.Rows(120).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(87)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(87)(2)))
                                        '        grdParaList.Rows(121).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(88)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(88)(2)))
                                        '        grdParaList.Rows(122).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(89)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(89)(2)))
                                        '        grdParaList.Rows(123).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(90)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(90)(2)))
                                        '        grdParaList.Rows(124).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(86)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(86)(3)))
                                        '        grdParaList.Rows(125).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(88)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(88)(3)))
                                        '        grdParaList.Rows(126).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(89)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(89)(3)))
                                        '        grdParaList.Rows(127).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(86)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(86)(4)))
                                        '        grdParaList.Rows(128).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(86)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(86)(5)))
                                        '        grdParaList.Rows(129).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(87)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(87)(5)))
                                        '        grdParaList.Rows(130).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(88)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(88)(5)))
                                        '        grdParaList.Rows(131).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(89)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(89)(5)))
                                        '        grdParaList.Rows(132).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(86)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(86)(6)))
                                        '        grdParaList.Rows(133).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(91)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(91)(6)))
                                        '        grdParaList.Rows(134).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(92)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(92)(6)))
                                        '        grdParaList.Rows(135).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(93)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(93)(6)))
                                        '        grdParaList.Rows(136).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(94)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(94)(6)))
                                        '        grdParaList.Rows(137).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(95)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(95)(6)))
                                        '        grdParaList.Rows(138).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(86)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(86)(7)))
                                        '        grdParaList.Rows(139).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(87)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(87)(7)))

                                        '        grdParaList.Rows(140).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(107)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(107)(1)))
                                        '        grdParaList.Rows(141).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(108)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(108)(1)))
                                        '        grdParaList.Rows(142).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(109)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(109)(1)))
                                        '        grdParaList.Rows(143).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(108)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(108)(2)))
                                        '        grdParaList.Rows(144).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(108)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(108)(3)))
                                        '        grdParaList.Rows(145).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(108)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(108)(4)))
                                        '        grdParaList.Rows(146).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(108)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(108)(5)))
                                        '        grdParaList.Rows(147).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(109)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(109)(5)))
                                        '        grdParaList.Rows(148).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(110)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(110)(5)))
                                        '        grdParaList.Rows(149).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(112)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(112)(5)))
                                        '        grdParaList.Rows(150).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(113)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(113)(5)))
                                        '        grdParaList.Rows(151).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(114)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(114)(5)))
                                        '        grdParaList.Rows(152).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(115)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(115)(5)))
                                        '        grdParaList.Rows(153).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(116)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(116)(5)))
                                        '        grdParaList.Rows(154).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(108)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(108)(6)))
                                        '        grdParaList.Rows(155).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(109)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(109)(6)))
                                        '        grdParaList.Rows(156).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(101)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(101)(6)))
                                        '        grdParaList.Rows(157).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(112)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(112)(6)))
                                        '        grdParaList.Rows(158).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(113)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(113)(6)))
                                        '        grdParaList.Rows(159).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(114)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(114)(6)))
                                        '        grdParaList.Rows(160).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(115)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(115)(6)))
                                        '        grdParaList.Rows(161).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(116)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(116)(6)))
                                        '        grdParaList.Rows(162).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(108)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(108)(7)))
                                        '        grdParaList.Rows(163).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(109)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(109)(7)))
                                        '        grdParaList.Rows(164).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(110)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(110)(7)))
                                        '        grdParaList.Rows(165).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(112)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(112)(7)))
                                        '        grdParaList.Rows(166).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(113)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(113)(7)))
                                        '        grdParaList.Rows(167).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(114)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(114)(7)))
                                        '        grdParaList.Rows(168).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(115)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(115)(7)))
                                        '        grdParaList.Rows(169).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(116)(7) Is DBNull.Value, "", dsExcel.Tables(0).Rows(116)(7)))
                                        '        grdParaList.Rows(170).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(122)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(122)(1)))
                                        '        grdParaList.Rows(171).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(123)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(123)(1)))
                                        '        grdParaList.Rows(172).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(123)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(123)(2)))
                                        '        grdParaList.Rows(173).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(123)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(123)(3)))
                                        '        grdParaList.Rows(174).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(123)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(123)(4)))
                                        '        grdParaList.Rows(175).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(123)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(123)(5)))
                                        '        grdParaList.Rows(176).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(126)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(126)(5)))
                                        '        grdParaList.Rows(177).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(127)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(127)(5)))
                                        '        grdParaList.Rows(178).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(128)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(128)(5)))
                                        '        grdParaList.Rows(179).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(129)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(129)(5)))
                                        '        grdParaList.Rows(180).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(130)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(130)(5)))
                                        '        grdParaList.Rows(181).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(131)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(131)(5)))
                                        '        grdParaList.Rows(182).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(123)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(123)(6)))
                                        '        grdParaList.Rows(183).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(136)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(136)(1)))
                                        '        grdParaList.Rows(184).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(137)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(137)(1)))
                                        '        grdParaList.Rows(185).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(137)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(137)(2)))
                                        '        grdParaList.Rows(186).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(137)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(137)(3)))
                                        '        grdParaList.Rows(187).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(137)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(137)(4)))
                                        '        grdParaList.Rows(188).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(137)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(137)(5)))
                                        '        grdParaList.Rows(189).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(140)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(140)(5)))
                                        '        grdParaList.Rows(190).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(141)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(141)(5)))
                                        '        grdParaList.Rows(191).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(142)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(142)(5)))
                                        '        grdParaList.Rows(192).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(143)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(143)(5)))
                                        '        grdParaList.Rows(193).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(144)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(144)(5)))
                                        '        grdParaList.Rows(194).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(137)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(137)(6)))
                                        '        grdParaList.Rows(195).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(158)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(158)(1)))
                                        '        grdParaList.Rows(196).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(159)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(159)(1)))
                                        '        grdParaList.Rows(197).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(160)(1) Is DBNull.Value, "", dsExcel.Tables(0).Rows(160)(1)))
                                        '        grdParaList.Rows(198).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(159)(2) Is DBNull.Value, "", dsExcel.Tables(0).Rows(159)(2)))
                                        '        grdParaList.Rows(199).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(159)(3) Is DBNull.Value, "", dsExcel.Tables(0).Rows(159)(3)))
                                        '        grdParaList.Rows(200).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(159)(4) Is DBNull.Value, "", dsExcel.Tables(0).Rows(159)(4)))
                                        '        grdParaList.Rows(201).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(159)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(159)(5)))
                                        '        grdParaList.Rows(202).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(160)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(160)(5)))
                                        '        grdParaList.Rows(203).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(161)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(161)(5)))
                                        '        grdParaList.Rows(204).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(163)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(163)(5)))
                                        '        grdParaList.Rows(205).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(164)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(164)(5)))
                                        '        grdParaList.Rows(206).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(165)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(165)(5)))
                                        '        grdParaList.Rows(207).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(166)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(166)(5)))
                                        '        grdParaList.Rows(208).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(167)(5) Is DBNull.Value, "", dsExcel.Tables(0).Rows(167)(5)))
                                        '        grdParaList.Rows(209).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(159)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(159)(6)))
                                        '        grdParaList.Rows(210).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(160)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(160)(6)))
                                        '        grdParaList.Rows(211).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(161)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(161)(6)))
                                        '        grdParaList.Rows(212).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(159)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(159)(6)))
                                        '        grdParaList.Rows(213).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(160)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(160)(6)))
                                        '        grdParaList.Rows(214).Cells("ParaValue").Value = CStr(IIf(dsExcel.Tables(0).Rows(161)(6) Is DBNull.Value, "", dsExcel.Tables(0).Rows(161)(6)))

                                        '        btnSaveMsrmnt.PerformClick()
                                        '        btnCancel.PerformClick()
                                        '        ' End If

                                        '    Catch ex As Exception
                                        '        txtF_LedgerName.Clear()
                                        '    Finally
                                        '        btnSaveMsrmnt.PerformClick()
                                        '        btnCancel.PerformClick()
                                        '    End Try

                                        'End If
                                    End If
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.Message.ToString() & vbCrLf & " File Name" & tmpFileName)
                            End Try
                        Next
                        UpdFromExcel = False
                        cancelClickTime()
                        btnRefresh.PerformClick()
                        SplashScreenManager.CloseForm()
                        MsgBox("Done", MsgBoxStyle.Information)
                    Else
                        MsgBox("Please Select Proper Folder", MsgBoxStyle.Information)
                    End If
                End If

            Catch ex As Exception
                SplashScreenManager.CloseForm()
            End Try
        End If

        Select Case e.KeyCode
            Case Keys.F2
                gvData.FocusedColumn.Caption = InputBox("Column Header Text", "Field Name", gvData.FocusedColumn.FieldName)
                Exit Select
        End Select
    End Sub

    Private Sub grdItems_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItems.CellClick
        loadParaList()
    End Sub

    Private Sub grdItems_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItems.CellDoubleClick
        loadParaList()
        If grdParaList.Rows.Count > 0 Then
            grdParaList.Focus()
            grdParaList.Rows(0).Cells("ParaValue").Selected = True
        End If
    End Sub


    Private Sub grdItems_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdItems.KeyDown
        If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Right Then
            If grdParaList.Rows.Count > 0 Then
                grdParaList.Focus()
                grdParaList.Rows(0).Cells("ParaValue").Selected = True
            End If
        End If
    End Sub

    Private Sub grdParaList_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdParaList.CellEndEdit
        If UCase(M_FractionMeasurementInput) = "YES" Then
            For i As Integer = 1 To 3
                If grdParaList.Columns(grdParaList.CurrentCell.ColumnIndex).Name = "ParaValue" Then
                    If grdParaList.CurrentCell.Value.ToString.Contains("///") Then
                        grdParaList.CurrentCell.Value = grdParaList.CurrentCell.Value.ToString.Replace("///", "-" & tmpThreeForth)
                    Else
                        If grdParaList.CurrentCell.Value.ToString.Contains("//") Then
                            grdParaList.CurrentCell.Value = grdParaList.CurrentCell.Value.ToString.Replace("//", "-" & tmpHalf)
                        Else
                            If grdParaList.CurrentCell.Value.ToString.Contains("/") Then
                                grdParaList.CurrentCell.Value = grdParaList.CurrentCell.Value.ToString.Replace("/", "-" & tmpOneForth)
                            End If
                        End If
                    End If
                    'grdParaList.CurrentCell.Value = grdParaList.CurrentCell.Value.ToString.Replace("/", "")
                End If
            Next
        End If
    End Sub

    Private Sub txtLedgerCode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLedgerName.Enter, txtPincode.Enter, txtPhone.Enter, txtPANNo.Enter, txtOpBal.Enter, txtMobileNo2.Enter, txtMobile.Enter, txtLedgerCode.Enter, txtGSTNo.Enter, txtFax.Enter, txtEMail.Enter, txtCountry.Enter, txtCity.Enter, txtAddress2.Enter, txtAddress1.Enter, txtAcContactPerson.Enter, txtBeneficiaryName.Enter, txtBankAcType.Enter, txtIsBlock.Enter, txtAcContactNo.Enter
        sender.BackColor = Color.Aquamarine
    End Sub

    Private Sub txtLedgerCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLedgerName.Enter, txtPincode.Leave, txtPhone.Leave, txtPANNo.Leave, txtOpBal.Leave, txtMobileNo2.Leave, txtMobile.Leave, txtLedgerCode.Leave, txtGSTNo.Leave, txtFax.Leave, txtEMail.Leave, txtCountry.Leave, txtCity.Leave, txtAddress2.Leave, txtAddress1.Leave, txtAcContactPerson.Leave, txtBeneficiaryName.Leave, txtBankAcType.Leave, txtIsBlock.Leave, txtAcContactNo.Leave
        sender.BackColor = Color.White
    End Sub

    Dim UpdFromExcel As Boolean = False
    Private Sub btnSynch_Click(sender As Object, e As EventArgs) Handles btnSynch.Click

        ''If Val(M_QT_Company_ID) > 0 Then
        ''    If MessageBox.Show("Sure To Synch Data From App", "Synch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
        ''        Exit Sub
        ''    End If
        ''    Dim pnt As New Point(Me.Location.X + 500, Me.Location.Y + 300)
        ''    pnlSynch.Location = pnt
        ''    pnlSynch.Visible = True
        ''    dtpFromSynch.Focus()
        ''    lblLedgerOrMeas.Text = "Ledger"
        ''Else
        ''    MessageBox.Show("Please Subscribe First, For Use This Feature.", "Synch", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''End If
    End Sub

    Private Sub btnSynchOk_Click(sender As Object, e As EventArgs) Handles btnSynchOk.Click

        'flg_Synch = True

        'If lblLedgerOrMeas.Text = "Ledger" Then
        '    ' For Ledger
        '    SplashScreenManager.ShowForm(GetType(WaitForm1))

        '    Dim Search_Mobile As String = ""
        '    Dim Search_Name As String = ""

        '    Dim client = New RestClient("http://sunrisesoftware.in/sunrise_tailoring/api/ledger/getCustomerList")
        '    client.Timeout = -1
        '    Dim request = New RestRequest(Method.POST)
        '    request.AddHeader("Content-Type", "application/json")
        '    'request.AddHeader("Cookie", "ci_session=b26dfa182c8470c928b70a68df020fa5d19446fc")
        '    Dim body = "{
        '           " & vbLf & "    ""CId"":""" & M_QT_Company_ID & """,
        '           " & vbLf & "    ""from_date"":""" & dtpFromSynch.Value.ToString("dd-MM-yyyy") & """,
        '           " & vbLf & "    ""to_date"":""" & dtpToSynch.Value.ToString("dd-MM-yyyy") & """,
        '           " & vbLf & "    ""mobile_number"":""" & Search_Mobile & """,
        '           " & vbLf & "    ""name"":""" & Search_Name & """
        '           " & vbLf & "}"
        '    request.AddParameter("application/json", body, RestSharp.ParameterType.RequestBody)
        '    Dim response As IRestResponse = client.Execute(request)

        '    If response.Content.Contains("Record not found") Then
        '        SplashScreenManager.CloseForm()
        '        MsgBox("Record not found", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If

        '    Dim List As API_Class.Data_List = JsonConvert.DeserializeObject(Of API_Class.Data_List)(response.Content)
        '    'Console.WriteLine(response.Content)

        '    If List.data.Count > 0 Then
        '        If MessageBox.Show(List.data.Count.ToString() & " : Record Found. Sure To Proceed ?", "Synch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '            For ll As Integer = 0 To List.data.Count - 1

        '                LedgerId_Synch = 0

        '                txtF_LedgerName.Text = List.data(ll).ContactNo1.ToString()

        '                If gvData.RowCount = 0 Then

        '                    SplashScreenManager.Default.SetWaitFormDescription("Adding : " & List.data(ll).LedgerName)

        '                    ' Add New Record
        '                    btnAdd.PerformClick()

        '                    'txtLedgerCode.Text = List.data(ll).LedgerCode
        '                    LedgerId_Synch = Val(List.data(ll).LedgerId)
        '                    txtLedgerName.Text = List.data(ll).LedgerName
        '                    txtMobile.Text = List.data(ll).ContactNo1
        '                    txtMobileNo2.Text = List.data(ll).ContactNo2
        '                    txtAdd1.Text = List.data(ll).Address
        '                    txtAdd2.Text = ""
        '                    txtPhone.Text = ""
        '                    txtEMailId.Text = List.data(ll).Email1
        '                    txtCity.Text = List.data(ll).City
        '                    txtPincode.Text = List.data(ll).Pincode
        '                    txtState.Text = List.data(ll).State
        '                    txtGSTNo.Text = List.data(ll).GSTNo
        '                    txtCountry.Text = List.data(ll).Country
        '                    txtFax.Text = ""
        '                    If List.data(ll).BirthDate = "" Then
        '                        dtpBirthDate.Checked = False
        '                    Else
        '                        dtpBirthDate.Checked = True
        '                        dtpBirthDate.Text = CDate(List.data(ll).BirthDate)
        '                    End If

        '                    If List.data(ll).AnniDate = "" Then
        '                        dtpAnniDate.Checked = False
        '                    Else
        '                        dtpAnniDate.Checked = True
        '                        dtpAnniDate.Text = CDate(List.data(ll).AnniDate)
        '                    End If

        '                    cmbTaxation.Text = List.data(ll).Taxation
        '                    cmbTranSMS.Text = List.data(ll).TranSMS
        '                    cmbPromoSMS.Text = List.data(ll).PromoSMS
        '                    txtOpBal.Text = List.data(ll).balance
        '                    cmbCustType.Text = List.data(ll).CustType
        '                    txtBeneficiaryName.Text = List.data(ll).BeneficiaryName
        '                    txtBankAcType.Text = List.data(ll).BankAcType
        '                    txtImgPath1.Text = ""

        '                    btnSave.PerformClick()

        '                    SplashScreenManager.Default.SetWaitFormDescription("Adding Measurement For : " & List.data(ll).LedgerName)

        '                    Try
        '                        Dim client_MM = New RestClient("http://sunrisesoftware.in/sunrise_tailoring/api/ledger/getCustomerMeasurement")
        '                        client_MM.Timeout = -1
        '                        Dim request_MM = New RestRequest(Method.POST)
        '                        request_MM.AddHeader("Content-Type", "application/json")
        '                        Dim body_mm = "{
        '                                      " & vbLf & "    ""CId"":""" & M_QT_Company_ID & """,
        '                                      " & vbLf & "    ""customer_id"":""" & List.data(ll).LedgerId & """,
        '                                      " & vbLf & "    ""mobile_number"":""" & List.data(ll).ContactNo1 & """,
        '                                      " & vbLf & "    ""name"":""" & "" & """
        '                                      " & vbLf & "}"
        '                        request_MM.AddParameter("application/json", body_mm, RestSharp.ParameterType.RequestBody)
        '                        Dim response_mm As IRestResponse = client_MM.Execute(request)

        '                        If response_mm.Content.Contains("Record not found") Then
        '                            Continue For
        '                        End If

        '                        Dim List_MM As API_Class.Data_Measurement = JsonConvert.DeserializeObject(Of API_Class.Data_Measurement)(response_mm.Content)
        '                        Dim maxLedgerId As Integer = obj.ScalarExecute("select Max(LedgerId) from tbl_LedgerMaster")

        '                        Get_Dt_AppParameter()

        '                        For i As Integer = 0 To List_MM.data.Count - 1
        '                            For j As Integer = 0 To List_MM.data(i).measurements.Count - 1
        '                                sql_query = "select count(0) from tbl_TItemParameter where ParaName = N'" & Trim(List_MM.data(i).measurements(j).Name) & "'"
        '                                If obj.ScalarExecute(sql_query) > 0 Then
        '                                    Dim dstmpPara As New DataSet()
        '                                    sql_query = "select * from tbl_TItemParameter where ParaName = N'" & Trim(List_MM.data(i).measurements(j).Name) & "'"
        '                                    obj.LoadData(sql_query, dstmpPara)

        '                                    sql_query = "insert into tbl_CustomerDetail values(" & maxLedgerId & "," & dstmpPara.Tables(0).Rows(0)("TItemId") & ", " & dstmpPara.Tables(0).Rows(0)("ParaId") & ", N'" & Trim(List_MM.data(i).measurements(j).Name) & "', N'" & Trim(List_MM.data(i).measurements(j).Paravalue) & "' )"
        '                                    obj.QueryExecute(sql_query)

        '                                End If

        '                            Next
        '                        Next

        '                    Catch ex As Exception

        '                    End Try

        '                Else
        '                    ' Edit Existing Record.

        '                    SplashScreenManager.Default.SetWaitFormDescription("Updating : " & List.data(ll).LedgerName)

        '                    gvData.GetRow(0).Selected = True
        '                    fillData()

        '                    btnEdit.PerformClick()
        '                    LedgerId_Synch = Val(List.data(ll).LedgerId)
        '                    'txtLedgerCode.Text = List.data(ll).LedgerCode
        '                    txtLedgerName.Text = List.data(ll).LedgerName
        '                    txtMobile.Text = List.data(ll).ContactNo1
        '                    txtMobileNo2.Text = List.data(ll).ContactNo2
        '                    txtAdd1.Text = List.data(ll).Address
        '                    txtAdd2.Text = ""
        '                    txtPhone.Text = ""
        '                    txtEMailId.Text = List.data(ll).Email1
        '                    'txtCity.Text = List.data(ll).City
        '                    'txtPincode.Text = List.data(ll).Pincode
        '                    'txtState.Text = List.data(ll).State
        '                    'txtGSTNo.Text = List.data(ll).GSTNo
        '                    'txtCountry.Text = List.data(ll).Country
        '                    'txtFax.Text = ""
        '                    If List.data(ll).BirthDate = "" Then
        '                        dtpBirthDate.Checked = False
        '                    Else
        '                        dtpBirthDate.Checked = True
        '                        dtpBirthDate.Text = CDate(List.data(ll).BirthDate)
        '                    End If

        '                    If List.data(ll).AnniDate = "" Then
        '                        dtpAnniDate.Checked = False
        '                    Else
        '                        dtpAnniDate.Checked = True
        '                        dtpAnniDate.Text = CDate(List.data(ll).AnniDate)
        '                    End If
        '                    'dtpBirthDate.Text = CDate(List.data(ll).BirthDate)
        '                    'dtpAnniDate.Text = CDate(List.data(ll).AnniDate)
        '                    'cmbTaxation.Text = List.data(ll).Taxation
        '                    'cmbTranSMS.Text = List.data(ll).TranSMS
        '                    'cmbPromoSMS.Text = List.data(ll).PromoSMS
        '                    'txtOpBal.Text = List.data(ll).balance
        '                    'cmbCustType.Text = List.data(ll).CustType
        '                    'txtBeneficiaryName.Text = List.data(ll).BeneficiaryName
        '                    'txtImgPath1.Text = ""

        '                    btnSave.PerformClick()
        '                End If

        '            Next
        '            txtF_LedgerName.Text = ""
        '            SplashScreenManager.CloseForm()
        '            pnlSynch.Visible = False
        '        End If
        '    Else
        '        SplashScreenManager.CloseForm()
        '        MessageBox.Show("No Record Found", "Synch Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Else
        '    ' For Measurement

        '    Dim Search_Mobile As String = ""
        '    Dim Search_Name As String = ""

        '    Dim client = New RestClient("http://sunrisesoftware.in/sunrise_tailoring/api/ledger/getCustomerMeasurement")
        '    client.Timeout = -1
        '    Dim request = New RestRequest(Method.POST)
        '    request.AddHeader("Content-Type", "application/json")
        '    Dim body = "{
        '           " & vbLf & "    ""CId"":""" & M_QT_Company_ID & """,
        '           " & vbLf & "    ""customer_id"":""" & dtpFromSynch.Value.ToString("dd-MM-yyyy") & """,
        '           " & vbLf & "    ""mobile_number"":""" & Search_Mobile & """,
        '           " & vbLf & "    ""name"":""" & Search_Name & """
        '           " & vbLf & "}"
        '    request.AddParameter("application/json", body, RestSharp.ParameterType.RequestBody)
        '    Dim response As IRestResponse = client.Execute(request)

        '    If response.Content.Contains("Record not found") Then
        '        SplashScreenManager.CloseForm()
        '        MsgBox("Record not found", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If

        '    Dim List As API_Class.Data_List = JsonConvert.DeserializeObject(Of API_Class.Data_List)(response.Content)

        'End If

        'flg_Synch = False
        'LedgerId_Synch = 0

    End Sub

    Private Sub btnSynchMeas_Click(sender As Object, e As EventArgs) Handles btnSynchMeas.Click
        If Val(M_QT_Company_ID) > 0 Then
            If MessageBox.Show("Sure To Synch Measurement Data From App", "Synch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
            Dim pnt As New Point(Me.Location.X + 500, Me.Location.Y + 300)
            pnlSynch.Location = pnt
            pnlSynch.Visible = True
            dtpFromSynch.Focus()
            lblLedgerOrMeas.Text = "Measurement"
        Else
            MessageBox.Show("Please Subscribe First, For Use This Feature.", "Synch", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtAcContactPerson_TextChanged(sender As Object, e As EventArgs) Handles txtAcContactPerson.TextChanged

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        txtImgPath1.Text = M_getImagePath(Me)
        pbImg1.ImageLocation = txtImgPath1.Text
    End Sub

    Private Sub DownloadTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadTemplateToolStripMenuItem.Click
        If File.Exists(Application.StartupPath & "\ExcelTemplates\CustomerUploadTemplate.csv") Then
            If MessageBox.Show("Sure To Download Template", "Customer Template", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim sfd As New SaveFileDialog()
                If sfd.ShowDialog() = DialogResult.OK Then
                    File.Copy(Application.StartupPath & "\ExcelTemplates\CustomerUploadTemplate.csv", sfd.FileName & ".csv", True)
                End If
            End If
        Else
            MsgBox("Template Not Found, Please Contact To Service Provider")
        End If
    End Sub

    Private Sub UploadCustomerUsingExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadCustomerUsingExcelToolStripMenuItem.Click
        ProcessCSVFile()

        Exit Sub
        Dim ofd As New OpenFileDialog()
        If ofd.ShowDialog() = DialogResult.OK Then
            If Trim(ofd.FileName) <> "" Then
                Dim ds_Excel As New Data.DataSet
                ds_Excel.Clear()
                obj.LoadData_Excel("SELECT * FROM [Sheet1$]", ds_Excel, "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & ofd.FileName & "; Extended Properties=""Excel 8.0; HDR=Yes; IMEX=1""")

                If ds_Excel.Tables(0).Rows.Count() > 0 Then
                    ' Check  LedgerName 
                    If ds_Excel.Tables(0).Select("isnull(LedgerName, '') = ''", "").Count() > 0 Then
                        MsgBox("Ledger Name Not Found In : " & ds_Excel.Tables(0).Select("isnull(LedgerName, '') = ''", "").Count() & " Rows", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    For i As Integer = 0 To ds_Excel.Tables(0).Rows.Count() - 1
                        sql_query = "select count(0) from tbl_LedgerMaster where LedgerName = '" & Trim(ds_Excel.Tables(0).Rows(i)("LedgerName")) & "' And G_Id = 11 "
                        If obj.ScalarExecute(sql_query) > 0 Then
                            MsgBox("Customer Name : " & Trim(ds_Excel.Tables(0).Rows(i)("LedgerName")) & " Already Exist.", MsgBoxStyle.Information)
                            Exit Sub
                        End If
                    Next

                    If ds_Excel.Tables(0).Select("isnull(State, '') = ''", "").Count() > 0 Then
                        MsgBox("State Not Found In : " & ds_Excel.Tables(0).Select("isnull(State, '') = ''", "").Count() & " Rows", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Dim newRecords As Integer = 0
                    For i As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
                        lblLedgerId.Text = 0
                        btnAdd_Click(sender, e)

                        txtLedgerCode.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("LedgerCode")), "", ds_Excel.Tables(0).Rows(i)("LedgerCode"))
                        txtLedgerName.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("LedgerName")), "", ds_Excel.Tables(0).Rows(i)("LedgerName"))
                        txtMobile.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("MobileNo")), "", ds_Excel.Tables(0).Rows(i)("MobileNo"))
                        txtMobileNo2.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("MobileNo2")), "", ds_Excel.Tables(0).Rows(i)("MobileNo2"))
                        txtAddress1.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("Address1")), "", ds_Excel.Tables(0).Rows(i)("Address1"))
                        txtAddress2.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("Address2")), "", ds_Excel.Tables(0).Rows(i)("Address2"))
                        txtPhone.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("Phone")), "", ds_Excel.Tables(0).Rows(i)("Phone"))
                        txtEMail.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("EMailId")), "", ds_Excel.Tables(0).Rows(i)("EMailId"))
                        txtCity.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("City")), "", ds_Excel.Tables(0).Rows(i)("City"))
                        txtPincode.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("PinCode")), "", ds_Excel.Tables(0).Rows(i)("PinCode"))
                        txtState.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("State")), "", ds_Excel.Tables(0).Rows(i)("State"))
                        txtGSTNo.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("GSTNo")), "", ds_Excel.Tables(0).Rows(i)("GSTNo"))
                        txtCountryCode.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("CountryCode")), "", ds_Excel.Tables(0).Rows(i)("CountryCode"))
                        txtCountry.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("Country")), "", ds_Excel.Tables(0).Rows(i)("Country"))
                        setTaxation()
                        txtPANNo.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("PANNo")), "", ds_Excel.Tables(0).Rows(i)("PANNo"))
                        dtpBirthDate.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("BirthDate")), "", ds_Excel.Tables(0).Rows(i)("BirthDate"))
                        dtpAnniDate.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("AnniDate")), "", ds_Excel.Tables(0).Rows(i)("AnniDate"))
                        txtBankAcType.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("Age")), "", ds_Excel.Tables(0).Rows(i)("Age"))

                        txtOpBal.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("OpBal")), "", ds_Excel.Tables(0).Rows(i)("OpBal"))
                        cmbCustType.Text = "-"
                        txtBeneficiaryName.Text = IIf(IsDBNull(ds_Excel.Tables(0).Rows(i)("Weight")), "", ds_Excel.Tables(0).Rows(i)("Weight"))
                        btnSave_Click(sender, e)
                        newRecords = newRecords + 1
                    Next

                    MsgBox("Data Saved Successfully" & vbCrLf & "New Records: " & newRecords, MsgBoxStyle.Information)
                    gridfill(True)
                End If

            End If
        End If
    End Sub

    Private Sub ProcessCSVFile()
        UpdFromExcel = True

        Dim ofd As New OpenFileDialog()
        If ofd.ShowDialog() = DialogResult.OK Then
            If Trim(ofd.FileName) <> "" Then
                Using reader As New StreamReader(ofd.FileName)
                    Dim firstLine = reader.ReadLine()  ' Read header line (optional)
                    Dim headers As String() = firstLine?.Split(","c)  ' Split header into an array (optional)
                    Dim indx As Integer

                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine()
                        Dim values As String() = line.Split(","c)

                        'Insert

                        btnCancel.PerformClick()
                        btnAdd.PerformClick()

                        indx = Array.IndexOf(headers, "LedgerCode")
                        txtLedgerCode.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "LedgerName")
                        txtLedgerName.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "Address1")
                        txtAddress1.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "Address2")
                        txtAddress2.Text = gvData.GetFocusedRowCellValue("Address2")
                        indx = Array.IndexOf(headers, "City")
                        txtCity.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "PinCode")
                        txtPincode.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "State")
                        txtState.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "Country")
                        txtCountry.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "GSTNo")
                        txtGSTNo.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "PANNo")
                        txtPANNo.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        setTaxation()
                        indx = Array.IndexOf(headers, "PhoneNo")
                        txtPhone.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "MobileNo")
                        txtMobile.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "Grouping")
                        txtFax.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        dtpBirthDate.Checked = False
                        dtpAnniDate.Checked = False
                        indx = Array.IndexOf(headers, "MobileNo2")
                        txtMobileNo2.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "Weight")
                        txtBeneficiaryName.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "TranSMS")
                        cmbTranSMS.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "PromoSMS")
                        cmbPromoSMS.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "OpeningBalance")
                        txtOpBal.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        indx = Array.IndexOf(headers, "ReferenceName")
                        txtAcContactNo.Text = IIf(IsDBNull(values(indx)), "", values(indx))
                        btnSave.PerformClick()
                    End While
                End Using

                MsgBox("Data Saved Successfully", MsgBoxStyle.Information)
                cancelClickTime()
                gvData.ClearColumnsFilter()

                gridfill(True)
            End If
        End If

        UpdFromExcel = False
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        Using saveDialog = New SaveFileDialog()
            saveDialog.Filter = "Excel (.xlsx)|*.xlsx"
            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim printingSystem = New PrintingSystemBase()
                Dim compositeLink = New CompositeLinkBase()
                compositeLink.PrintingSystemBase = printingSystem

                Dim link1 = New PrintableComponentLinkBase()
                link1.Component = gcData

                compositeLink.Links.Add(link1)

                Dim options = New XlsxExportOptions()
                options.ExportMode = XlsxExportMode.SingleFilePageByPage

                compositeLink.CreatePageForEachLink()
                compositeLink.ExportToXlsx(saveDialog.FileName, options)
            End If
        End Using
    End Sub

    Private Sub gvData_Click(sender As Object, e As EventArgs) Handles gvData.Click
        Dim selectedRows() As Integer = gvData.GetSelectedRows

        If selectedRows.Length = 0 Then
            Exit Sub
        End If

        fillData()
        btnCancel.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = False
        btnAdd.Enabled = False
    End Sub

    Private Sub gvData_KeyUp(sender As Object, e As KeyEventArgs) Handles gvData.KeyUp
        Dim selectedRows() As Integer = gvData.GetSelectedRows

        If selectedRows.Length = 0 Then
            Exit Sub
        End If

        fillData()
        btnCancel.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = False
        btnAdd.Enabled = False
    End Sub

    Private Sub gvData_DoubleClick(sender As Object, e As EventArgs) Handles gvData.DoubleClick
        Dim selectedRows() As Integer = gvData.GetSelectedRows

        If selectedRows.Length = 0 Then
            Exit Sub
        End If

        fillData()
        btnCancel.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = False
        btnAdd.Enabled = False

        If checkRightsToEdit("CUSTOMER MASTER") = False Then
            MsgBox("Unable To Edit Record", MsgBoxStyle.Information)
            Exit Sub
        End If
        editClickTime()
    End Sub

    Private Sub SaveLayoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveLayoutToolStripMenuItem.Click
        SaveLayout(gvData, "FrmCustomerMaster_Tailoring", Me)
    End Sub

    '========================
    Dim CAMERA As VideoCaptureDevice
    Dim bmp As Bitmap

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        pnlImageCapture.Visible = True

        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras.ShowDialog = Windows.Forms.DialogResult.OK Then
            CAMERA = cameras.VideoDevice
            AddHandler CAMERA.NewFrame, New NewFrameEventHandler(AddressOf Captured)
            CAMERA.Start()
        End If
    End Sub

    Private Sub Captured(sender As Object, eventArgs As NewFrameEventArgs)
        bmp = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        pbCapturedImg.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        pbImg1.Image = pbCapturedImg.Image

        Dim FilePath As String = Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "WebCamImage\" & "CI_" & DateTime.Now.ToString("ddMMyyyhhmmssfff") & ".jpeg"
        pbImg1.Image.Save(FilePath)

        txtImgPath1.Text = FilePath

        pnlImageCapture.Visible = False
        CAMERA.Stop()
    End Sub

    Private Sub btnImageClose_Click(sender As Object, e As EventArgs) Handles btnImageClose.Click
        CAMERA.Stop()
        pnlImageCapture.Visible = False
    End Sub

    Private Sub FrmCustomerMaster_Tailoring_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        sql_query = "Select * From tbl_UISettings Where ObjectName = 'CUSTOMER MASTER'"
        obj.LoadData(sql_query, dsUISetting)

        For i As Integer = 0 To dsUISetting.Tables(0).Rows.Count - 1
            Select Case dsUISetting.Tables(0).Rows(i)("FieldName")
                Case "Address1"
                    lblAddress1.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
                    txtAddress1.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
                    txtAddress1.ReadOnly = dsUISetting.Tables(0).Rows(i)("ReadOnly")
                    Exit Select
                Case "Address2"
                    lblAddress2.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
                    txtAddress2.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
                    txtAddress2.ReadOnly = dsUISetting.Tables(0).Rows(i)("ReadOnly")
                    Exit Select
                Case "EMail"
                    lblEMail.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
                    txtEMail.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
                    txtEMail.ReadOnly = dsUISetting.Tables(0).Rows(i)("ReadOnly")
                    Exit Select
            End Select
        Next
    End Sub

    Private Sub RenameColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameColumnToolStripMenuItem.Click
        gvData.FocusedColumn.Caption = InputBox("Column Header Text", "Field Name", gvData.FocusedColumn.FieldName)
    End Sub

    Private Sub GroupByColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GroupByColumnToolStripMenuItem.Click
        gvData.Columns(gvData.FocusedColumn.FieldName).Group()
        gvData.ExpandAllGroups()
    End Sub

    Private Sub ClearGroupingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearGroupingToolStripMenuItem.Click
        gvData.ClearGrouping()
    End Sub

    Private Sub txtF_LedgerName_TextChanged(sender As Object, e As EventArgs) Handles txtF_LedgerName.TextChanged
        gvData.Columns("LedgerName").FilterInfo = New ColumnFilterInfo("[LedgerName] LIKE '%" & txtF_LedgerName.Text & "%'")
    End Sub

    Private Sub txtF_LedgerName_GotFocus(sender As Object, e As EventArgs) Handles txtF_LedgerName.GotFocus, txtF_MobileNo.GotFocus
        txtF_LedgerName.BackColor = Color.Aqua
        txtF_MobileNo.BackColor = Color.Aqua
    End Sub

    Private Sub txtF_LedgerName_Leave(sender As Object, e As EventArgs) Handles txtF_LedgerName.Leave, txtF_MobileNo.Leave
        txtF_LedgerName.BackColor = Color.White
        txtF_MobileNo.BackColor = Color.White
    End Sub

    Private Sub txtF_MobileNo_TextChanged(sender As Object, e As EventArgs) Handles txtF_MobileNo.TextChanged
        gvData.Columns("MobileNo").FilterInfo = New ColumnFilterInfo("[MobileNo] LIKE '%" & txtF_MobileNo.Text & "%'")
    End Sub

    Private Sub txtMobile_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMobile.Validating
        If M_DupMobGenMessage = "Yes" Then
            sql_query = "Select * From tbl_LedgerMaster Where G_Id = 11 And MobileNo = '" & Trim(txtMobile.Text) & "' And CId = " & M_CId
            If obj.ScalarExecute(sql_query) > 0 Then
                Dim dr As DialogResult
                ' dr = MsgBox("Duplicate MobileNo Sure To Save?", MsgBoxStyle.YesNo, vbMsgBoxHelp.Critical)
                dr = XtraMessageBox.Show("Duplicate MobileNo Sure To Save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If dr = Windows.Forms.DialogResult.No Then
                    txtMobile.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub txtLedgerName_TextChanged(sender As Object, e As EventArgs) Handles txtLedgerName.TextChanged
        If edit_ins = 1 Then
            gvData.Columns("LedgerName").FilterInfo = New ColumnFilterInfo("[LedgerName] LIKE '%" & txtLedgerName.Text & "%'")
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        ExportContectListToolStripMenuItem.Visible = checkRightsToLoad("CUSTOMER PHONE BOOK")
    End Sub


#End Region

End Class