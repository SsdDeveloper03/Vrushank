Imports System.IO
Imports System.Drawing.Imaging
Imports Sunrise.TailoringERP.DB
Imports DevExpress.Utils
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Columns
Imports TailoringERP.TailoringERP.DB
'
Public Class FrmSalesItemMaster

#Region "Comments"
    'Name:TailoringERP
    'Created By:Bhavesh
    'Form:FrmItemMaster
    'Date:09/07/2016
#End Region

#Region "Declaration"
    Dim dsDetail As New Data.DataSet
    Dim obj As New DBManager
    Dim sql_query As String
    Dim edit_ins As Integer = -1
    Dim existCode, existBarCode, existDesignNo As String
    Dim oldCode As String
    Dim point As Boolean = False
    Dim minus As Boolean = False
    Dim dsUISetting As New Data.DataSet
    Dim prnCode, LabelText As String
    Dim flgIsAll As Boolean = False
    Dim dsReportQuery As New Data.DataSet

    Dim dsItemType As DataSet
    Dim dsItemCategory As New DataSet
    Dim dsItemSubCategory As New DataSet
    Dim dsMfgName As DataSet
    Dim dsSupplier As DataSet
    Dim dsItemSize As DataSet
    Dim dsItemSizeRange As DataSet
    Dim dsItemColor As New DataSet
    Dim ItemFormula, MiscItemFormula, MiscItemFormula_Text As String
    Dim dtBWRate As DataTable

    Public strParam As String = ""
    Public strInitial As String = ""
    Public uploadExcel As Boolean = False
    Dim dvMiscMaster As New DataView(dsMiscMaster.Tables(0))
    Dim uploadType As String
    Dim UpdFromExcel As Boolean = False

#End Region

#Region "Method"

    Public Sub formatGrid()
        gvData.Columns("TItemId").Visible = False
        gvData.Columns("TItemCode").Caption = "Code"
        gvData.Columns("TItemCode").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        gvData.Columns("BarCode").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        gvData.Columns("TItemName").Caption = "Name"
        gvData.Columns("TItemRate").Visible = False
        gvData.Columns("CuttingRate").Visible = False
        gvData.Columns("SewingRate").Visible = False
        gvData.Columns("MaterialRate").Visible = False
        gvData.Columns("ItemType").Caption = "Type"
        gvData.Columns("ItemCategory").Caption = "Category"
        gvData.Columns("MfgName").Caption = "Manufacturer"
        gvData.Columns("ItemSize").Caption = "Size"
        gvData.Columns("ItemSizeRange").Visible = False
        gvData.Columns("ItemColor").Caption = "Color"
        gvData.Columns("ItemFor").Visible = False
        gvData.Columns("PurchaseRate").Caption = "P.Rate"
        gvData.Columns("PurchaseRate").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
        gvData.Columns("MRP").Visible = False
        gvData.Columns("UOM").Visible = False
        gvData.Columns("AUOM").Visible = False
        gvData.Columns("UOMValue").Visible = False
        gvData.Columns("AUOMValue").Visible = False
        gvData.Columns("SalesRate").Caption = "S.Rate"
        gvData.Columns("SalesRate").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
        gvData.Columns("SalesRateA").Visible = False
        'grdData.Columns("SalesRateA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gvData.Columns("HSNCode").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
        gvData.Columns("TaxPer").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
        gvData.Columns("SalesUOM").Visible = False
        gvData.Columns("ImgPath").Visible = False
        gvData.Columns("ItemImage").Visible = False
        gvData.Columns("ReOrderLevel").Visible = False
        gvData.Columns("ItemSubType").Visible = False
        gvData.Columns("HSNCode").Caption = "HSN Code"
        gvData.Columns("TaxPer").Caption = "Tax %"
        gvData.Columns("IsActive").Visible = False
        gvData.Columns("Sys_Name").Visible = False
        gvData.Columns("Sys_Time").Visible = False
        gvData.Columns("CurrUsr").Visible = False
        gvData.Columns("CId").Visible = False
        gvData.Columns("TItemName1").Visible = False
        gvData.Columns("TItemName1").Caption = "Alias Name"

        gvData.Columns("M1").Visible = False
        gvData.Columns("M2").Visible = False
        gvData.Columns("M3").Visible = False
        gvData.Columns("M4").Visible = False
        gvData.Columns("M5").Visible = False
        gvData.Columns("M6").Visible = False
        gvData.Columns("M7").Visible = False
        gvData.Columns("M8").Visible = False
        gvData.Columns("M9").Visible = False
        gvData.Columns("M10").Visible = False
        gvData.Columns("M11").Visible = False
        gvData.Columns("M12").Visible = False
        gvData.Columns("M13").Visible = False
        gvData.Columns("M14").Visible = False
        gvData.Columns("M15").Visible = False
        gvData.Columns("M16").Visible = False
        gvData.Columns("M17").Visible = False
        gvData.Columns("M18").Visible = False
        gvData.Columns("M19").Visible = False
        gvData.Columns("M20").Visible = False
        gvData.Columns("M21").Visible = False
        gvData.Columns("M22").Visible = False
        gvData.Columns("M23").Visible = False
        gvData.Columns("M24").Visible = False
        gvData.Columns("M25").Visible = False
        gvData.Columns("M26").Visible = False
        gvData.Columns("M27").Visible = False
        gvData.Columns("M28").Visible = False
        gvData.Columns("M29").Visible = False
        gvData.Columns("M30").Visible = False
        gvData.Columns("M31").Visible = False
        gvData.Columns("M32").Visible = False
        gvData.Columns("M33").Visible = False
        gvData.Columns("M34").Visible = False
        gvData.Columns("M35").Visible = False
        gvData.Columns("M36").Visible = False
        gvData.Columns("M37").Visible = False
        gvData.Columns("M38").Visible = False
        gvData.Columns("M39").Visible = False
        gvData.Columns("M40").Visible = False
        gvData.Columns("M41").Visible = False
        gvData.Columns("M42").Visible = False
        gvData.Columns("M43").Visible = False
        gvData.Columns("M44").Visible = False
        gvData.Columns("M45").Visible = False
        gvData.Columns("M46").Visible = False
        gvData.Columns("M47").Visible = False
        gvData.Columns("M48").Visible = False
        gvData.Columns("M49").Visible = False
        gvData.Columns("ManageStock").Visible = False
        'grdData.Columns("DesignNo").Visible = False
        'grdData.Columns("CatalogName").Visible = False
        'grdData.Columns("Location").Visible = False
        gvData.Columns("ItemGroupId").Visible = False
        gvData.Columns("OnePieceStitchingHrs").Visible = False
        gvData.Columns("AlterRate").Visible = False
        gvData.Columns("SewingRate_R").Visible = False
        gvData.Columns("SewingRate_Jw").Visible = False
        gvData.Columns("SewingRate_Jw_R").Visible = False
        gvData.Columns("AlterCharge").Visible = False
        gvData.Columns("AlterCharge_R").Visible = False
        gvData.Columns("CommissionPer").Visible = False
        gvData.Columns("CommissionAmt").Visible = False
        gvData.Columns("BarcodeType").Visible = False
        gvData.Columns("MainItemId").Visible = False
        gvData.Columns("ItemSubCategory").Visible = False
        gvData.Columns("SupplierName").Visible = False
        gvData.Columns("PurchaseDiscPer").Visible = False
        gvData.Columns("SalesDiscPer").Visible = False

        gvData.Columns("TItemName").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        gvData.Columns("TItemName").SummaryItem.DisplayFormat = "Records: {0}"

        For i As Integer = 0 To gvData.Columns.Count - 1
            gvData.Columns(i).OptionsColumn.AllowEdit = False
        Next

        gvData.Columns("YN").OptionsColumn.AllowEdit = True
    End Sub


    Public Sub gridfill2024()
        loadItemMaster()

        gcData.DataSource = dsItemMaster.Tables(0).DefaultView
        RestoreLayout(gvData, "Sales_Item_Master_Grid")

        gvData.OptionsBehavior.Editable = True
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvData.Columns
            If col.FieldName <> "YN" Then
                col.OptionsColumn.ReadOnly = True
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.ReadOnly = False
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        If M_SalesItemList = "Same Company" Then
            gvData.Columns("CId").FilterInfo = New ColumnFilterInfo("[CId] = " & M_CId)
        End If

        If Val(txtF_BarcodeFrom.Text) > 0 And Val(txtF_BarcodeTo.Text) > 0 Then
            For i As Integer = 0 To gvData.RowCount - 1
                gvData.SetRowCellValue(i, "YN", True)
            Next
        End If

        gvData.OptionsView.ColumnAutoWidth = False
        gvData.BestFitColumns()
    End Sub

    'Public Sub ComboFill(ByVal cmb As ComboBox, ByVal sql As String)
    '    Dim dsCmb As New Data.DataSet
    '    dsCmb.Clear()
    '    sql_query = sql
    '    obj.LoadData(sql_query, dsCmb)
    '    cmb.DataSource = dsCmb.Tables(0).DefaultView
    '    cmb.ValueMember = dsCmb.Tables(0).Columns(0).ToString
    '    cmb.DisplayMember = dsCmb.Tables(0).Columns(1).ToString
    '    dsCmb.Dispose()
    'End Sub

    Public Sub ComboFill(ByVal cmb As ComboBox, ByVal _RowFilter As String)
        dvMiscMaster.RowFilter = _RowFilter

        Dim tmpDT As New DataTable
        tmpDT = dvMiscMaster.ToTable

        cmb.DataSource = tmpDT.DefaultView
        cmb.ValueMember = tmpDT.Columns("MiscId").ToString
        cmb.DisplayMember = tmpDT.Columns("MiscName").ToString
    End Sub


    Public Sub ComboFill_ItemType(ByVal cmb As ComboBox, ByVal sql As String)
        dsItemType = New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsItemType)
        cmb.DataSource = dsItemType.Tables(0).DefaultView
        cmb.ValueMember = dsItemType.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsItemType.Tables(0).Columns(1).ToString
    End Sub

    Public Sub ComboFill_ItemCategory(ByVal cmb As ComboBox, ByVal sql As String)
        dsItemCategory = New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsItemCategory)
        cmb.DataSource = dsItemCategory.Tables(0).DefaultView
        cmb.ValueMember = dsItemCategory.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsItemCategory.Tables(0).Columns(1).ToString
    End Sub

    Public Sub ComboFill_ItemSubCategory(ByVal cmb As ComboBox, ByVal sql As String)
        dsItemSubCategory = New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsItemSubCategory)
        cmb.DataSource = dsItemSubCategory.Tables(0).DefaultView
        cmb.ValueMember = dsItemSubCategory.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsItemSubCategory.Tables(0).Columns(1).ToString
    End Sub

    Public Sub ComboFill_MfgName(ByVal cmb As ComboBox, ByVal sql As String)
        dsMfgName = New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsMfgName)
        cmb.DataSource = dsMfgName.Tables(0).DefaultView
        cmb.ValueMember = dsMfgName.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsMfgName.Tables(0).Columns(1).ToString
    End Sub

    Public Sub ComboFill_SupplierName(ByVal cmb As ComboBox, ByVal sql As String)
        dsSupplier = New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsSupplier)
        cmb.DataSource = dsSupplier.Tables(0).DefaultView
        cmb.ValueMember = dsSupplier.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsSupplier.Tables(0).Columns(1).ToString
    End Sub

    Public Sub ComboFill_ItemSize(ByVal cmb As ComboBox, ByVal sql As String)
        dsItemSize = New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsItemSize)
        cmb.DataSource = dsItemSize.Tables(0).DefaultView
        cmb.ValueMember = dsItemSize.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsItemSize.Tables(0).Columns(1).ToString
    End Sub

    Public Sub ComboFill_ItemSizeRange(ByVal cmb As ComboBox, ByVal sql As String)
        dsItemSizeRange = New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsItemSizeRange)
        cmb.DataSource = dsItemSizeRange.Tables(0).DefaultView
        cmb.ValueMember = dsItemSizeRange.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsItemSizeRange.Tables(0).Columns(1).ToString
    End Sub

    Public Sub ComboFill_ItemColor(ByVal cmb As ComboBox, ByVal sql As String)
        dsItemColor = New Data.DataSet
        sql_query = sql
        obj.LoadData(sql_query, dsItemColor)
        cmb.DataSource = dsItemColor.Tables(0).DefaultView
        cmb.ValueMember = dsItemColor.Tables(0).Columns(0).ToString
        cmb.DisplayMember = dsItemColor.Tables(0).Columns(1).ToString
    End Sub

    Public Sub ComboFill_Search(ByVal cmb As ComboBox, ByVal sql As String)
        Dim dsCmb As New Data.DataSet
        dsCmb.Clear()
        sql_query = sql
        obj.LoadData(sql_query, dsCmb)
        'cmb.DataSource = dsCmb.Tables(0).DefaultView
        cmb.Items.Add("ALL")
        For i As Integer = 0 To dsCmb.Tables(0).Rows.Count - 1
            cmb.Items.Add(dsCmb.Tables(0).Rows(i)(1))
        Next
        dsCmb.Dispose()
    End Sub

    Public Sub insertMiscMaster(ByVal _MiscType As String, ByVal _MiscName As String)
        'sql_query = "Insert into tbl_MiscMaster (MiscType, MiscName, CId, IsActive, Data1, Data2, DispSrNo) values ('" & _MiscType & "','" & _MiscName & "'," & M_CId & ",'True','','',0)"
        'obj.QueryExecute(sql_query)

        obj.Prepare("SP_InsertMiscMaster_281123", SpType.StoredProcedure)
        obj.AddCmdParameter("@InsMiscType", Dtype.nvarchar, _MiscType, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMiscName", Dtype.nvarchar, _MiscName, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsData1", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsData2", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsData3", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsDispSrNo", Dtype.int, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsIsActive", Dtype.Bit, "True", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCId", Dtype.int, M_CId, ParaDirection.Input, True)
        obj.ExecuteCommand()
    End Sub

    Public Sub insert()
        'obj.Prepare("SP_InsertTItemMaster_Sales_1908", SpType.StoredProcedure)
        obj.Prepare("SP_InsertTItemMaster_Sales_140922", SpType.StoredProcedure)
        obj.AddCmdParameter("@InsTItemCode", Dtype.varchar, Trim(txtTItemCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsBarCode", Dtype.varchar, Trim(txtBarcode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsTItemName", Dtype.nvarchar, Trim(txtTItemName.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsTItemRate", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCuttingRate", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSewingRate", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMaterialRate", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsItemType", Dtype.nvarchar, cmbItemType.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsItemCategory", Dtype.nvarchar, cmbItemCategory.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMfgName", Dtype.nvarchar, cmbMfgName.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsItemSize", Dtype.varchar, cmbItemSize.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsItemSizeRange", Dtype.varchar, cmbItemSizeRange.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsItemColor", Dtype.varchar, cmbItemColor.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsItemFor", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsUOM", Dtype.varchar, cmbUOM.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAUOM", Dtype.varchar, cmbUOM.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsUOMValue", Dtype.float, 1, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAUOMValue", Dtype.float, 1, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPurchaseRate", Dtype.float, Val(txtPurchaseRate.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMRP", Dtype.float, Val(txtMRP.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSalesRate", Dtype.float, Val(txtSalesRate.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSalesRateA", Dtype.float, Val(txtSalesRateA.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSalesUOM", Dtype.varchar, cmbUOM.Text, ParaDirection.Input, True)

        If IsNothing(pbImg.Image) = True Then
            obj.AddCmdParameter("@InsImgPath", Dtype.varchar, "", ParaDirection.Input, True)
        Else
            obj.AddCmdParameter("@InsImgPath", Dtype.varchar, M_ItemMasterItemImagePath & "\" & Path.GetFileName(txtImgPath.Text), ParaDirection.Input, True)
        End If

        'saad 27/09/2022
        If IsNothing(pbImg.Image) = True Then
            obj.AddCmdParameter("@InsItemImage", Dtype.img, DBNull.Value, ParaDirection.Input, True)
        Else
            Dim imgByteArray() As Byte
            Dim stream As New MemoryStream
            Dim bmp As New Bitmap(Trim(txtImgPath.Text))

            bmp.Save(stream, ImageFormat.Jpeg)
            imgByteArray = stream.ToArray()
            stream.Close()
            obj.AddCmdParameter("@InsItemImage", Dtype.img, imgByteArray, ParaDirection.Input, True)
        End If
        'obj.AddCmdParameter("@InsItemImage", Dtype.img, DBNull.Value, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsReOrderLevel", Dtype.float, Val(txtReorderLevel.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsItemSubType", Dtype.varchar, "Sales", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsIsActive", Dtype.Bit, chkIsActive.Checked, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsHSNCode", Dtype.varchar, Trim(txtHSNCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsTaxPer", Dtype.Doubl, Val(txtTaxPer.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCId", Dtype.int, M_CId, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSys_Name", Dtype.varchar, My.Computer.Name, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSys_Time", Dtype.DateTime, Date.Now.ToString(M_DTMforSP & " HH:mm:ss tt"), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCurrUsr", Dtype.varchar, loggedUser, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsTItemName1", Dtype.nvarchar, Trim(txtTItemName1.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsManageStock", Dtype.Bit, chkManageStock.Checked, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsDesignNo", Dtype.nvarchar, Trim(txtDesignNo.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCatalogName", Dtype.nvarchar, Trim(txtCatalogName.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsLocation", Dtype.nvarchar, Trim(txtLocation.Text), ParaDirection.Input, True)

        obj.AddCmdParameter("@InsItemGroupId", Dtype.int, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsOnePieceStitchingHrs", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAlterRate", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSewingRate_R", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSewingRate_Jw", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSewingRate_Jw_R", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAlterCharge", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsAlterCharge_R", Dtype.float, Val(0), ParaDirection.Input, True)

        obj.AddCmdParameter("@InsCommissionPer", Dtype.float, Val(txtCommissionPer.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsCommissionAmt", Dtype.float, Val(txtCommissionAmt.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsM1", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsM2", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsM48", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsM49", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@InsBarcodeType", Dtype.varchar, cmbBarcodeType.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsMainItemId", Dtype.int, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsItemSubCategory", Dtype.varchar, cmbItemSubCategory.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSupplierName", Dtype.varchar, cmbSupplierName.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@InsPurchaseDiscPer", Dtype.float, Val(txtPurchaseDiscPer.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@InsSalesDiscPer", Dtype.float, Val(txtSalesDiscPer.Text), ParaDirection.Input, True)
        obj.ExecuteCommand()

        Try
            File.Copy(txtImgPath.Text, M_ItemMasterItemImagePath & "\" & Path.GetFileName(txtImgPath.Text))
        Catch ex As Exception

        End Try

        sql_query = "Select IsNull(Max(TItemId),0) From tbl_TItemMaster Where TItemCode = '" & Trim(txtTItemCode.Text) & "'"
        lblTItemId.Text = obj.ScalarExecute(sql_query)

        setOpeningStock(Val(lblTItemId.Text))

        If M_PostEntryInPurchaseDetailForOpeningStock = "Yes" Then
            sql_query = "Insert Into tbl_PurchaseDetail (PurchaseId, ItemId, Qty, UOM, PurchaseRate, SalesPrice, ItemTotal, Remark, ImgPath, ItemImage, UId, Barcode, RateBoutique, RateRetailer, RateWholesaler, Pcs, AQty, AUOM, TS_Id, CST_Per, CST_Amt, CST_AddPer, CST_AddAmt, VAT_Per, VAT_Amt, VAT_AddPer, VAT_AddAmt, Length, Width, SqMtr)" _
                & "Values (" & M_PurchaseIdOpeningStock & ", " & Val(lblTItemId.Text) & ", " & Val(txtOpStk.Text) & ", '" & cmbUOM.Text & "', " & Val(txtPurchaseRate.Text) & ", " & Val(txtSalesRate.Text) & ", 0, '', '', NULL, " & Val(txtBarcode.Text) & ", '" & Val(txtBarcode.Text) & "', 0, 0, 0, 1, " & Val(txtOpStk.Text) & ", '" & cmbUOM.Text & "', 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)"
            obj.QueryExecute(sql_query)
        End If
    End Sub

    Public Sub edit()
        obj.Prepare("SP_UpdateTItemMaster_Sales_081022", SpType.StoredProcedure)
        obj.AddCmdParameter("@UpTItemCode", Dtype.varchar, Trim(txtTItemCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpBarCode", Dtype.varchar, Trim(txtBarcode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpTItemName", Dtype.nvarchar, Trim(txtTItemName.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpTItemRate", Dtype.float, Val(txtPurchaseRate.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpCuttingRate", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSewingRate", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpMaterialRate", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemType", Dtype.nvarchar, cmbItemType.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemCategory", Dtype.nvarchar, cmbItemCategory.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpMfgName", Dtype.nvarchar, cmbMfgName.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemSize", Dtype.varchar, cmbItemSize.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemSizeRange", Dtype.varchar, cmbItemSizeRange.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemColor", Dtype.varchar, cmbItemColor.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemFor", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpUOM", Dtype.varchar, cmbUOM.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAUOM", Dtype.varchar, cmbUOM.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpUOMValue", Dtype.float, 1, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAUOMValue", Dtype.float, 1, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpPurchaseRate", Dtype.float, Val(txtPurchaseRate.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpMRP", Dtype.float, Val(txtMRP.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSalesRate", Dtype.float, Val(txtSalesRate.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSalesRateA", Dtype.float, Val(txtSalesRateA.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSalesUOM", Dtype.varchar, cmbUOM.Text, ParaDirection.Input, True)
        'obj.AddCmdParameter("@UpImgPath", Dtype.varchar, Trim(txtImgPath.Text), ParaDirection.Input, True)

        If IsNothing(pbImg.Image) = True Then
            obj.AddCmdParameter("@UpImgPath", Dtype.varchar, "", ParaDirection.Input, True)
        Else
            obj.AddCmdParameter("@UpImgPath", Dtype.varchar, M_ItemMasterItemImagePath & "\" & Path.GetFileName(txtImgPath.Text), ParaDirection.Input, True)
        End If

        'Commented On 27/09/2022
        If IsNothing(pbImg.Image) = True Then
            obj.AddCmdParameter("@UpItemImage", Dtype.img, DBNull.Value, ParaDirection.Input, True)
        Else
            Dim imgByteArray() As Byte
            Dim bmp As New Bitmap(pbImg.Image)
            Dim stream As New MemoryStream
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
            imgByteArray = stream.ToArray()
            'Dim imgByteArray() As Byte
            'Dim stream As New MemoryStream
            'Dim bmp As New Bitmap(Trim(txtImgPath.Text))

            'bmp.Save(stream, ImageFormat.Jpeg)
            'imgByteArray = stream.ToArray()
            'stream.Close()
            obj.AddCmdParameter("@UpItemImage", Dtype.img, imgByteArray, ParaDirection.Input, True)
        End If
        'obj.AddCmdParameter("@UpItemImage", Dtype.img, DBNull.Value, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpReOrderLevel", Dtype.float, Val(txtReorderLevel.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemSubType", Dtype.varchar, "Sales", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpIsActive", Dtype.Bit, chkIsActive.Checked, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpHSNCode", Dtype.varchar, Trim(txtHSNCode.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpTaxPer", Dtype.Doubl, Val(txtTaxPer.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpTItemName1", Dtype.nvarchar, Trim(txtTItemName1.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpManageStock", Dtype.Bit, chkManageStock.Checked, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpDesignNo", Dtype.nvarchar, Trim(txtDesignNo.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpCatalogName", Dtype.nvarchar, Trim(txtCatalogName.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpLocation", Dtype.nvarchar, Trim(txtLocation.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemGroupId", Dtype.int, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpOnePieceStitchingHrs", Dtype.float, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAlterRate", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSewingRate_R", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSewingRate_Jw", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSewingRate_Jw_R", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAlterCharge", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpAlterCharge_R", Dtype.float, Val(0), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpCommissionPer", Dtype.float, Val(txtCommissionPer.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpCommissionAmt", Dtype.float, Val(txtCommissionAmt.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpM1", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpM2", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpM48", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpM49", Dtype.nvarchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@UpBarcodeType", Dtype.varchar, cmbBarcodeType.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpMainItemId", Dtype.int, 0, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpItemSubCategory", Dtype.varchar, cmbItemSubCategory.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSupplierName", Dtype.varchar, cmbSupplierName.Text, ParaDirection.Input, True)
        obj.AddCmdParameter("@UpPurchaseDiscPer", Dtype.float, Val(txtPurchaseDiscPer.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpSalesDiscPer", Dtype.float, Val(txtSalesDiscPer.Text), ParaDirection.Input, True)
        obj.AddCmdParameter("@UpTItemId", Dtype.int, Val(lblTItemId.Text), ParaDirection.Input, True)
        obj.ExecuteCommand()

        Try
            File.Copy(txtImgPath.Text, M_ItemMasterItemImagePath & "\" & Path.GetFileName(txtImgPath.Text))
        Catch ex As Exception

        End Try

        setOpeningStock(Val(lblTItemId.Text))

        If M_PostEntryInPurchaseDetailForOpeningStock = "Yes" Then
            sql_query = "Delete from tbl_PurchaseDetail Where PurchaseId = " & M_PurchaseIdOpeningStock & " And ItemId = " & Val(lblTItemId.Text)
            obj.QueryExecute(sql_query)

            sql_query = "Insert Into tbl_PurchaseDetail (PurchaseId, ItemId, Qty, UOM, PurchaseRate, SalesPrice, ItemTotal, Remark, ImgPath, ItemImage, UId, Barcode, RateBoutique, RateRetailer, RateWholesaler, Pcs, AQty, AUOM)" _
                & "Values (" & M_PurchaseIdOpeningStock & ", " & Val(lblTItemId.Text) & ", " & Val(txtOpStk.Text) & ", '" & cmbUOM.Text & "', " & Val(txtPurchaseRate.Text) & ", " & Val(txtSalesRate.Text) & ", 0, '', '', NULL, " & Val(txtBarcode.Text) & ", '" & Val(txtBarcode.Text) & "', 0, 0, 0, 1, " & Val(txtOpStk.Text) & ", '" & cmbUOM.Text & "')"
            obj.QueryExecute(sql_query)
        End If
    End Sub

    Public Sub setOpeningStock(ByVal itemId As Integer)
        sql_query = "Delete From tbl_OpeningStock Where ItemId = " & itemId & " And FinYrId = " & M_StockYrId 'FrmMDIMain.cmbFinYr.SelectedValue
        obj.QueryExecute(sql_query)

        sql_query = "Insert Into tbl_OpeningStock (ItemId, FinYrId, OpStk, Rate, Value) Values(" & itemId & ", " & M_StockYrId & ", " & Val(txtOpStk.Text) & ", " & Val(txtPurchaseRate.Text) & ", " & Val(txtValue.Text) & ")"
        obj.QueryExecute(sql_query)
    End Sub

    Public Sub del()
        sql_query = "Delete from tbl_TItemMaster Where TItemId = " & Val(lblTItemId.Text)
        obj.QueryExecute(sql_query)

        sql_query = "Delete From tbl_OpeningStock Where ItemId = " & Val(lblTItemId.Text) & " And FinYrId = " & M_StockYrId
        obj.QueryExecute(sql_query)

        sql_query = "Delete from tbl_PurchaseDetail Where PurchaseId = " & M_PurchaseIdOpeningStock & " And ItemId = " & Val(lblTItemId.Text)
        obj.QueryExecute(sql_query)
    End Sub

    'Public Sub allComboFill()
    '    If M_CompanyWiseMiscMaster = "Yes" Then
    '        ComboFill_ItemType(cmbItemType, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ItemType' Order By DispSrNo, MiscName")
    '        ComboFill_ItemCategory(cmbItemCategory, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ItemCategory' Order By DispSrNo, MiscName")
    '        ComboFill_ItemSubCategory(cmbItemSubCategory, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ItemSubCategory' Order By DispSrNo, MiscName")
    '        ComboFill_MfgName(cmbMfgName, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'MfgName' Order By DispSrNo, MiscName")
    '        ComboFill_SupplierName(cmbSupplierName, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'SupplierName' Order By DispSrNo, MiscName")
    '        ComboFill_ItemSize(cmbItemSize, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ItemSize' Order By DispSrNo, MiscName")
    '        ComboFill_ItemColor(cmbItemColor, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ItemColor' Order By DispSrNo, MiscName")
    '        ComboFill_ItemSizeRange(cmbItemSizeRange, "Select MiscId , MiscName From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ItemSizeRange' Order By MiscName")

    '        ComboFill(cmbUOM, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'UOM' Order By DispSrNo, MiscName")

    '        ItemFormula = obj.ScalarExecute("Select MiscName From tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ITEM NAME FORMULA' And IsActive = 'True'")
    '    Else
    '        ComboFill_ItemType(cmbItemType, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = 'ItemType' Order By DispSrNo, MiscName")
    '        ComboFill_ItemCategory(cmbItemCategory, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = 'ItemCategory' Order By DispSrNo, MiscName")
    '        ComboFill_ItemSubCategory(cmbItemSubCategory, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = 'ItemSubCategory' Order By DispSrNo, MiscName")
    '        ComboFill_MfgName(cmbMfgName, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = 'MfgName' Order By DispSrNo, MiscName")
    '        ComboFill_SupplierName(cmbSupplierName, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = 'SupplierName' Order By DispSrNo, MiscName")
    '        ComboFill_ItemSize(cmbItemSize, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = 'ItemSize' Order By DispSrNo, MiscName")
    '        ComboFill_ItemColor(cmbItemColor, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = 'ItemColor' Order By DispSrNo, MiscName")
    '        ComboFill_ItemSizeRange(cmbItemSizeRange, "Select MiscId , MiscName From Tbl_MiscMaster Where MiscType = 'ItemSizeRange' Order By MiscName")

    '        ComboFill(cmbUOM, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = 'UOM' Order By DispSrNo, MiscName")

    '        ItemFormula = obj.ScalarExecute("Select MiscName From tbl_MiscMaster Where MiscType = 'ITEM NAME FORMULA' And IsActive = 'True'")
    '    End If
    'End Sub

    Public Sub allComboFill()
        If M_CompanyWiseMiscMaster = "Yes" Then
            ComboFill(cmbItemType, " CId = " & M_CId & " And MiscType = 'ItemType'")
            ComboFill(cmbItemCategory, " CId = " & M_CId & " And MiscType = 'ItemCategory'")
            ComboFill(cmbItemSubCategory, "CId = " & M_CId & " And MiscType = 'ItemSubCategory'")
            ComboFill(cmbMfgName, " CId = " & M_CId & " And MiscType = 'MfgName' ")
            ComboFill(cmbSupplierName, " CId = " & M_CId & " And MiscType = 'SupplierName' ")
            ComboFill(cmbItemSize, " CId = " & M_CId & " And MiscType = 'ItemSize'")
            ComboFill(cmbItemColor, " CId = " & M_CId & " And MiscType = 'ItemColor'")
            ComboFill(cmbItemSizeRange, " CId = " & M_CId & " And MiscType = 'ItemSizeRange'")

            ComboFill(cmbUOM, " CId = " & M_CId & " And MiscType = 'UOM'")

            'ItemFormula = obj.ScalarExecute("Select MiscName From tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ITEM NAME FORMULA' And IsActive = 'True'")

            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'ITEM NAME FORMULA' And IsActive = 'True'"
            Dim tmpDT As New DataTable
            tmpDT = dvMiscMaster.ToTable

            ItemFormula = tmpDT.Rows(0)("MiscName")
        Else
            ComboFill(cmbItemType, " MiscType = 'ItemType' ")
            ComboFill(cmbItemCategory, " MiscType = 'ItemCategory'")
            ComboFill(cmbItemSubCategory, " MiscType = 'ItemSubCategory'")
            ComboFill(cmbMfgName, " MiscType = 'MfgName' ")
            ComboFill(cmbSupplierName, " MiscType = 'SupplierName'")
            ComboFill(cmbItemSize, " MiscType = 'ItemSize'")
            ComboFill(cmbItemColor, " MiscType = 'ItemColor'")
            ComboFill(cmbItemSizeRange, " MiscType = 'ItemSizeRange'")

            ComboFill(cmbUOM, " MiscType = 'UOM' ")

            'ItemFormula = obj.ScalarExecute("Select MiscName From tbl_MiscMaster Where MiscType = 'ITEM NAME FORMULA' And IsActive = 'True'")

            dvMiscMaster.RowFilter = "MiscType = 'ITEM NAME FORMULA' And IsActive = 'True'"
            Dim tmpDT As New DataTable
            tmpDT = dvMiscMaster.ToTable

            If tmpDT.Rows.Count = 0 Then
                ItemFormula = ""
            Else
                ItemFormula = tmpDT.Rows(0)("MiscName")
            End If

            ' ItemFormula = tmpDT.Rows(0)("MiscName")
        End If

        'For KFL (Previous Barcode)
        Dim dv As DataView = cmbItemCategory.DataSource
        dsItemCategory.Tables.Add(dv.ToTable.Copy())

        dv = cmbItemColor.DataSource
        dsItemColor.Tables.Add(dv.ToTable.Copy())
    End Sub

    Public Sub loadTime()
        allComboFill()

        If cmbF_Company.Visible = True Then
            comboFill_CName(cmbF_Company, "Select CId, CCode, CName, SettingValue From View_Settings Where SettingName = 'Barcode Sheet File Name' Order By CName", "Company")
            cmbF_Company.EditValue = M_CId
        End If

        gridfill2024()

        'formatGrid()

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
        gcData.Enabled = True
        gbMainDetail.Enabled = False
    End Sub

    Public Sub prepare_BarcodeStimule_Shubhkamna_Fabric(ByVal print As Boolean, ByVal onSaveTime As Boolean)
        Dim _ds As New DataSet1
        Dim rowCnt As Integer = 0

        If Val(txtPrintCopies.Text) > 0 Then
            If UCase(M_BarcodeLabelSheet) = "SHEET" Then
                Dim cntBlank As Integer = InputBox("Add Blank Barcode", "No Of Blank Barcode", "0")

                If cntBlank > 0 Then
                    For ti As Integer = 0 To cntBlank - 1
                        _ds.Tables("Barcode_Salrio").Rows.Add()
                        _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Barcode") = ""
                        rowCnt = rowCnt + 1
                    Next
                End If
            End If
            If onSaveTime = True Then
                Dim tmpPurchasePriceCode As String = ""
                tmpPurchasePriceCode = Val(txtPurchaseRate.Text)
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("1", M_PurchasePriceCode(0))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("2", M_PurchasePriceCode(1))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("3", M_PurchasePriceCode(2))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("4", M_PurchasePriceCode(3))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("5", M_PurchasePriceCode(4))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("6", M_PurchasePriceCode(5))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("7", M_PurchasePriceCode(6))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("8", M_PurchasePriceCode(7))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("9", M_PurchasePriceCode(8))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("0", M_PurchasePriceCode(9))
                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace(".", M_PurchasePriceCode(10))

                _ds.Tables("Barcode_Salrio").Rows.Add()
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemId") = Val(lblTItemId.Text)
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemCode") = txtTItemCode.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("BarCode") = txtBarcode.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemName") = txtTItemName.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemSize") = cmbItemSize.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemType") = cmbItemType.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("MfgName") = cmbMfgName.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemCategory") = cmbItemCategory.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PurchaseRate") = Val(txtPurchaseRate.Text)
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("SalesPrice") = Val(txtSalesRate.Text)
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("MRP") = Val(txtMRP.Text)
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PRCode") = tmpPurchasePriceCode
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PurchaseDate") = DateTime.Now
                '_ds.Tables("Barcode_Salrio").Rows(rowCnt)("BillNo") = ""
                '_ds.Tables("Barcode_Salrio").Rows(rowCnt)("SrNo") = ""
                '=======
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemColor") = cmbItemColor.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemName1") = txtTItemName1.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("DesignNo") = txtDesignNo.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("CatalogName") = txtCatalogName.Text
                '=======


                ' Only For KFL
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("BillNo") = strInitial
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("SrNo") = strParam

                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PartyName") = ""
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("CName") = M_CName
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("UOM") = cmbUOM.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Qty") = Val(txtOpStk.Text)
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Date") = ""
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Location") = txtLocation.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("HSNCode") = txtHSNCode.Text
                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("RackRate") = Val(lblRackRate.Text)
            Else
                For i As Integer = 0 To gvData.RowCount - 1
                    If gvData.GetRowCellValue(i, "YN") = True Then

                        gvData.FocusedRowHandle = i
                        grdData_Click(Nothing, Nothing)

                        For x As Integer = 1 To Val(txtPrintCopies.Text)

                            Dim arrMfgName As String() = cmbMfgName.Text.Split(" ")
                            Dim mfgShortName As String = ""
                            For Each s In arrMfgName
                                mfgShortName += s.Substring(0, 1)
                            Next

                            'For KFL
                            If M_DbName = "dbSTE_KFL2024" Then
                                strParam = Trim(dsItemCategory.Tables(0).Rows(cmbItemCategory.SelectedIndex)("Data1")) & "-" & Trim(dsItemColor.Tables(0).Rows(cmbItemColor.SelectedIndex)("Data1"))
                                If cmbItemCategory.Text = "SUITING" Or cmbItemCategory.Text = "SHIRTING" Then
                                    strInitial = IIf(Trim(dsItemCategory.Tables(0).Rows(cmbItemCategory.SelectedIndex)("Data1")) = "", "", Trim(dsItemCategory.Tables(0).Rows(cmbItemCategory.SelectedIndex)("Data1")) & "/") &
                                        IIf(mfgShortName = "", "", mfgShortName & "/") &
                                        IIf(cmbItemSize.Text = "", "", cmbItemSize.Text & "''/") &
                                        IIf(txtDesignNo.Text = "", "", txtDesignNo.Text & "/") &
                                        "NA" &
                                        "/001"
                                ElseIf cmbItemCategory.Text = "BIN - SH" OrElse cmbItemCategory.Text = "BIN - SU" Then
                                    strInitial = IIf(Trim(dsItemCategory.Tables(0).Rows(cmbItemCategory.SelectedIndex)("Data1")) = "", "", Trim(dsItemCategory.Tables(0).Rows(cmbItemCategory.SelectedIndex)("Data1")) & "/") &
                                        IIf(mfgShortName = "", "", mfgShortName & "/") &
                                        IIf(txtDesignNo.Text = "", "", txtDesignNo.Text & "/") &
                                        "NA" &
                                        "/001"
                                Else
                                    strInitial = IIf(Trim(dsItemCategory.Tables(0).Rows(cmbItemCategory.SelectedIndex)("Data1")) = "", "", Trim(dsItemCategory.Tables(0).Rows(cmbItemCategory.SelectedIndex)("Data1")) & "/") &
                                        IIf(mfgShortName = "", "", mfgShortName & "/") &
                                        IIf(txtDesignNo.Text = "", "", txtDesignNo.Text & "/") &
                                        "NA" &
                                        "/001"
                                End If
                            End If

                            If onSaveTime = True Then
                                Dim tmpPurchasePriceCode As String = ""
                                tmpPurchasePriceCode = Val(txtPurchaseRate.Text)
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("1", M_PurchasePriceCode(0))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("2", M_PurchasePriceCode(1))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("3", M_PurchasePriceCode(2))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("4", M_PurchasePriceCode(3))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("5", M_PurchasePriceCode(4))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("6", M_PurchasePriceCode(5))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("7", M_PurchasePriceCode(6))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("8", M_PurchasePriceCode(7))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("9", M_PurchasePriceCode(8))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("0", M_PurchasePriceCode(9))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace(".", M_PurchasePriceCode(10))

                                _ds.Tables("Barcode_Salrio").Rows.Add()
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemId") = Val(lblTItemId.Text)
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemCode") = txtTItemCode.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("BarCode") = txtBarcode.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemName") = txtTItemName.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemSize") = cmbItemSize.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemType") = cmbItemType.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("MfgName") = cmbMfgName.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemCategory") = cmbItemCategory.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PurchaseRate") = Val(txtPurchaseRate.Text)
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("SalesPrice") = Val(txtSalesRate.Text)
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("MRP") = Val(txtMRP.Text)
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PRCode") = tmpPurchasePriceCode
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PurchaseDate") = DateTime.Now
                                '_ds.Tables("Barcode_Salrio").Rows(rowCnt)("BillNo") = ""
                                '_ds.Tables("Barcode_Salrio").Rows(rowCnt)("SrNo") = ""
                                '=======
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemColor") = cmbItemColor.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemName1") = txtTItemName1.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("DesignNo") = txtDesignNo.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("CatalogName") = txtCatalogName.Text
                                '=======


                                ' Only For KFL
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("BillNo") = strInitial
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("SrNo") = strParam

                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PartyName") = ""
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("CName") = M_CName
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("UOM") = cmbUOM.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Qty") = Val(txtOpStk.Text)
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Date") = ""
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Location") = txtLocation.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("HSNCode") = txtHSNCode.Text
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("RackRate") = Val(lblRackRate.Text)
                            Else
                                Dim tmpPurchasePriceCode As String = ""
                                tmpPurchasePriceCode = Val(gvData.GetFocusedRowCellValue("PurchaseRate"))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("1", M_PurchasePriceCode(0))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("2", M_PurchasePriceCode(1))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("3", M_PurchasePriceCode(2))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("4", M_PurchasePriceCode(3))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("5", M_PurchasePriceCode(4))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("6", M_PurchasePriceCode(5))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("7", M_PurchasePriceCode(6))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("8", M_PurchasePriceCode(7))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("9", M_PurchasePriceCode(8))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("0", M_PurchasePriceCode(9))
                                tmpPurchasePriceCode = tmpPurchasePriceCode.Replace(".", M_PurchasePriceCode(10))

                                _ds.Tables("Barcode_Salrio").Rows.Add()
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemId") = gvData.GetRowCellValue(i, "TItemId")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemCode") = gvData.GetRowCellValue(i, "TItemCode")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("BarCode") = gvData.GetRowCellValue(i, "BarCode")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemName") = gvData.GetRowCellValue(i, "TItemName")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemSize") = gvData.GetRowCellValue(i, "ItemSize")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemType") = gvData.GetRowCellValue(i, "ItemType")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("MfgName") = gvData.GetRowCellValue(i, "MfgName")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemCategory") = gvData.GetRowCellValue(i, "ItemCategory")
                                '_ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemColor") = grdPurchaseDetail.Rows(i).Cells("ItemColor").Value
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PurchaseRate") = gvData.GetRowCellValue(i, "PurchaseRate")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("SalesPrice") = gvData.GetRowCellValue(i, "SalesRate")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("MRP") = gvData.GetRowCellValue(i, "MRP")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PRCode") = tmpPurchasePriceCode
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PurchaseDate") = DateTime.Now
                                '_ds.Tables("Barcode_Salrio").Rows(rowCnt)("BillNo") = ""
                                '_ds.Tables("Barcode_Salrio").Rows(rowCnt)("SrNo") = ""
                                '=======
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("ItemColor") = gvData.GetRowCellValue(i, "ItemColor")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("TItemName1") = gvData.GetRowCellValue(i, "TItemName1")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("DesignNo") = gvData.GetRowCellValue(i, "DesignNo")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("CatalogName") = gvData.GetRowCellValue(i, "CatalogName")
                                '=======


                                ' Only For KFL
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("BillNo") = strInitial
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("SrNo") = strParam

                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("PartyName") = ""
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("CName") = M_CName
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("UOM") = gvData.GetRowCellValue(i, "UOM")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Qty") = Val(txtOpStk.Text)
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Date") = ""
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("Location") = gvData.GetRowCellValue(i, "Location")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("HSNCode") = gvData.GetRowCellValue(i, "HSNCode")
                                _ds.Tables("Barcode_Salrio").Rows(rowCnt)("RackRate") = Val(lblRackRate.Text)
                            End If
                            rowCnt = rowCnt + 1
                        Next
                    End If
                Next
            End If
        End If

        Dim tmp_M_BarcodeSheetFileName As String = ""

        If M_DbName = "dbSTE_KFL2024" Then
            Dim strPrintSel As String = InputBox("Please Select Barcode Style" & vbCrLf & "1 Regular Barcode" & vbCrLf & "2 Combo Barcode" & vbCrLf & "3 BIN Barcode", "Barcode Selection", 1)
            If Val(strPrintSel) = 2 Then
                tmp_M_BarcodeSheetFileName = "Barcode_Purchase_Combo_KFL.mrt"
            ElseIf Val(strPrintSel) = 3 Then
                tmp_M_BarcodeSheetFileName = "Barcode_Purchase_BIN_KFL.mrt"
            End If
        End If

        If cmbF_Company.Visible = True Then
            Dim frmRpt As New FrmReportViewer_Stimul(IIf(Trim(tmp_M_BarcodeSheetFileName) = "", cmbF_Company.GetColumnValue("SettingValue"), tmp_M_BarcodeSheetFileName), _ds, "Item Label", print)
            frmRpt.Show()
            frmRpt.MdiParent = FrmMDIMain
            If print Then
                frmRpt.Close()
            End If
        Else
            Dim frmRpt As New FrmReportViewer_Stimul(IIf(Trim(tmp_M_BarcodeSheetFileName) = "", M_BarcodeSheetFileName, tmp_M_BarcodeSheetFileName), _ds, "Item Label", print)
            frmRpt.Show()
            frmRpt.MdiParent = FrmMDIMain
            If print Then
                frmRpt.Close()
            End If
        End If

        tmp_M_BarcodeSheetFileName = ""
    End Sub
    Public Sub loadTime_F2Time()
        allComboFill()

        If cmbF_Company.Visible = True Then
            comboFill_CName(cmbF_Company, "Select CId, CCode, CName, SettingValue From View_Settings Where SettingName = 'Barcode Sheet File Name' Order By CName", "Company")
            cmbF_Company.EditValue = M_CId
        End If

        gridfill2024()

        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
        gcData.Enabled = True
        gbMainDetail.Enabled = False
    End Sub

    Public Sub comboFill_CName(comboName As DevExpress.XtraEditors.LookUpEdit, qry As String, headerText As String)
        Dim dsCompany As New Data.DataSet
        sql_query = qry
        obj.LoadData(sql_query, dsCompany)
        comboName.Properties.DataSource = dsCompany.Tables(0)
        comboName.Properties.DisplayMember = "CName"
        comboName.Properties.ValueMember = "CId"
        comboName.Properties.PopulateColumns()
        comboName.Properties.Columns("CId").Visible = False
        comboName.Properties.Columns("CCode").Visible = False
        comboName.Properties.PopupWidth = 300
        'comboName.Properties.Columns("CCode").Caption = "Company Code"
        comboName.Properties.Columns("CName").Caption = "Company Name"
    End Sub

    Public Sub autoCompleteTextbox(ByVal sqlQry As String, ByVal txtName As TextBox)
        Dim collection As New AutoCompleteStringCollection()
        Dim tmpds As New Data.DataSet
        sql_query = sqlQry
        obj.LoadData(sql_query, tmpds)
        For i As Integer = 0 To tmpds.Tables(0).Rows.Count - 1
            collection.Add(tmpds.Tables(0).Rows(i)(0))
        Next

        txtName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtName.AutoCompleteCustomSource = collection
    End Sub

    Public Sub addClickTime()
        autoCompleteTextbox("Select Distinct TItemName from tbl_TItemMaster", txtTItemName)

        Try
            Dim dstmp As New DataSet()
            obj.LoadData("select top 1 * from Tbl_TItemMaster order by TItemId Desc", dstmp)

            If (dstmp.Tables(0).Rows.Count > 0) Then
                Dim str As String = dstmp.Tables(0).Rows(0)("TItemCode")
                str = str.Replace("I", "")
                str = (Val(str) + 1).ToString()
                txtTItemCode.Text = "I" & Trim(str)
            Else
                txtTItemCode.Text = obj.ScalarExecute("Select Count(TItemId) + 1 From Tbl_TItemMaster Where ItemSubType = 'Sales' And CId = " & M_CId & "")
                txtTItemCode.Text = "I" & StrDup(5 - Trim(txtTItemCode.Text).Length, "0") & Trim(txtTItemCode.Text)
            End If
        Catch ex As Exception

        End Try

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
        oldCode = Trim(txtTItemCode.Text)
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

        txtTItemCode.Clear()
        txtBarcode.Clear()
        txtTItemName.Clear()
        txtTItemName1.Clear()
        'txtSalesRate.Clear()
        txtImgPath.Clear()
        txtReorderLevel.Clear()
        txtPurchaseRate.Clear()
        txtCommissionPer.Clear()
        txtCommissionAmt.Clear()
        txtValue.Clear()
        txtOpStk.Clear()
        txtHSNCode.Clear()
        txtTaxPer.Clear()
        txtDesignNo.Clear()
        txtCatalogName.Clear()
        txtLocation.Clear()
        txtSalesDiscPer.Clear()
        txtPurchaseDiscPer.Clear()
        txtSalesRate.Clear()
        txtSalesRateA.Clear()
        txtMRP.Clear()

        'cmbItemCategory.SelectedIndex = 0
        'cmbItemSubCategory.SelectedIndex = 0
        'cmbItemColor.SelectedIndex = 0
        'cmbItemSize.SelectedIndex = 0
        'cmbItemType.SelectedIndex = 0
        'cmbMfgName.SelectedIndex = 0
        'cmbUOM.SelectedIndex = 0
        'cmbItemSubCategory.SelectedIndex = 0
        'cmbSupplierName.SelectedIndex = 0

        pbImg.Image = Nothing

        Try
            dsDetail.Clear()
            gcDetail.DataSource = dsDetail.Tables(0).DefaultView
        Catch ex As Exception

        End Try
    End Sub

    Public Sub saveClickTime()
        gridfill2024()
        clearFields_NewState()
    End Sub

    Public Sub deleteClickTime()
        gridfill2024()
        clearFields_NewState()
    End Sub

    Public Sub cancelClickTime()
        clearFields_NewState()
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
        M_SalesItemMasterF2 = False
    End Sub

    Public Sub fillData()
        If gvData.FocusedRowHandle < 0 Then
            Exit Sub
        End If

        If gvData.SelectedRowsCount > 0 Then
            lblTItemId.Text = gvData.GetFocusedRowCellValue("TItemId")
            txtTItemCode.Text = gvData.GetFocusedRowCellValue("TItemCode")
            txtBarcode.Text = gvData.GetFocusedRowCellValue("BarCode")
            cmbBarcodeType.Text = gvData.GetFocusedRowCellValue("BarcodeType")
            txtTItemName.Text = gvData.GetFocusedRowCellValue("TItemName")
            txtTItemName1.Text = gvData.GetFocusedRowCellValue("TItemName1")
            cmbItemType.Text = gvData.GetFocusedRowCellValue("ItemType")
            cmbItemCategory.Text = gvData.GetFocusedRowCellValue("ItemCategory")
            cmbItemSubCategory.Text = IIf(gvData.GetFocusedRowCellValue("ItemSubCategory") Is DBNull.Value, "", gvData.GetFocusedRowCellValue("ItemSubCategory"))
            cmbMfgName.Text = gvData.GetFocusedRowCellValue("MfgName")
            cmbItemSize.Text = gvData.GetFocusedRowCellValue("ItemSize")
            cmbItemSizeRange.Text = gvData.GetFocusedRowCellValue("ItemSizeRange")
            cmbItemColor.Text = gvData.GetFocusedRowCellValue("ItemColor")
            cmbUOM.Text = gvData.GetFocusedRowCellValue("UOM")
            txtSalesRate.Text = gvData.GetFocusedRowCellValue("SalesRate")
            txtSalesRateA.Text = gvData.GetFocusedRowCellValue("SalesRateA")
            txtMRP.Text = gvData.GetFocusedRowCellValue("MRP")
            txtPurchaseRate.Text = gvData.GetFocusedRowCellValue("PurchaseRate")
            txtImgPath.Text = gvData.GetFocusedRowCellValue("ImgPath")

            'txtImgPath.Text = grdData.GetFocusedRowCellValue("ImgPath")
            'Try
            '    pbImg.Image = Image.FromFile(txtImgPath.Text)
            'Catch ex As Exception
            '    pbImg.Image = Nothing
            'End Try

            Try
                If IsDBNull(gvData.GetFocusedRowCellValue("ItemImage")) = False Then
                    'Dim imgByteArray() As Byte
                    'imgByteArray = CType(gvData.GetFocusedRowCellValue("ItemImage"), Byte())
                    'Dim stream As New MemoryStream(imgByteArray)
                    'Dim bmp As New Bitmap(stream)
                    'stream.Close()
                    'pbImg.Image = bmp

                    Dim imgByteArray() As Byte
                    imgByteArray = CType(gvData.GetFocusedRowCellValue("ItemImage"), Byte())
                    pbImg.Image = M_ByteToImage(imgByteArray)
                    M_FixImageRotation(pbImg.Image)
                Else
                    pbImg.Image = Nothing
                End If
            Catch ex As Exception

            End Try
            chkIsActive.Checked = gvData.GetFocusedRowCellValue("IsActive")
            txtReorderLevel.Text = gvData.GetFocusedRowCellValue("ReOrderLevel")
            txtHSNCode.Text = gvData.GetFocusedRowCellValue("HSNCode")
            txtTaxPer.Text = gvData.GetFocusedRowCellValue("TaxPer")
            txtDesignNo.Text = gvData.GetFocusedRowCellValue("DesignNo")
            txtCatalogName.Text = gvData.GetFocusedRowCellValue("CatalogName")
            txtLocation.Text = gvData.GetFocusedRowCellValue("Location")
            txtPurchaseDiscPer.Text = gvData.GetFocusedRowCellValue("PurchaseDiscPer")
            txtSalesDiscPer.Text = gvData.GetFocusedRowCellValue("SalesDiscPer")
            txtCommissionPer.Text = gvData.GetFocusedRowCellValue("CommissionPer")
            txtCommissionAmt.Text = gvData.GetFocusedRowCellValue("CommissionAmt")

            cmbItemSubCategory.Text = IIf(gvData.GetFocusedRowCellValue("ItemSubCategory") Is DBNull.Value, "", gvData.GetFocusedRowCellValue("ItemSubCategory"))
            cmbSupplierName.Text = IIf(gvData.GetFocusedRowCellValue("SupplierName") Is DBNull.Value, "", gvData.GetFocusedRowCellValue("SupplierName"))

            sql_query = "Select OpStk From tbl_OpeningStock Where ItemId = " & Val(lblTItemId.Text) & " And FinYrId = " & M_StockYrId 'FrmMDIMain.cmbFinYr.SelectedValue
            txtOpStk.Text = obj.ScalarExecute(sql_query)

            'sql_query = "Select Rate From tbl_OpeningStock Where ItemId = " & Val(lblTItemId.Text) & " And FinYrId = " & M_StockYrId 'FrmMDIMain.cmbFinYr.SelectedValue
            'txtPurchaseRate.Text = obj.ScalarExecute(sql_query)

            sql_query = "Select Value From tbl_OpeningStock Where ItemId = " & Val(lblTItemId.Text) & " And FinYrId = " & M_StockYrId 'FrmMDIMain.cmbFinYr.SelectedValue
            txtValue.Text = obj.ScalarExecute(sql_query)

            sql_query = "select isnull(RackPrice, 0) from tbl_RackWiseRate where ItemColor = N'" & cmbItemColor.Text & "' "
            lblRackRate.Text = obj.ScalarExecute(sql_query)
        End If

        If gcDetail.Visible = True Then

            dsDetail.Clear()
            Select Case M_DbName
                Case "dbSTE_HTF"
                    sql_query = "Select Cast(1 as bit) As YN, TItemId, TItemName, 0 As RackPrice, 0 As DiscPer From tbl_TItemMaster Where ItemSubType = 'Tailoring' And CId = " & M_CId & " Order By TItemName"
                    obj.LoadData(sql_query, dsDetail)
                    gcDetail.DataSource = dsDetail.Tables(0)

                    Dim dsRackWiseRate As New Data.DataSet
                    sql_query = "Select * From tbl_RackWiseRate Where ItemColor = '" & txtBarcode.Text & "'"
                    obj.LoadData(sql_query, dsRackWiseRate)

                    For i As Integer = 0 To dsRackWiseRate.Tables(0).Rows.Count - 1
                        For j As Integer = 0 To gvDetail.RowCount - 1
                            If dsRackWiseRate.Tables(0).Rows(i)("TItemId") = gvDetail.GetRowCellValue(j, "TItemId") Then
                                gvDetail.SetRowCellValue(j, "RackPrice", dsRackWiseRate.Tables(0).Rows(i)("RackPrice"))
                                gvDetail.SetRowCellValue(j, "DiscPer", dsRackWiseRate.Tables(0).Rows(i)("DiscPer"))
                            End If
                        Next
                    Next
                    Exit Select
            End Select
        End If
    End Sub

#End Region

#Region "Function"

    Public Function checkCode() As Boolean
        If M_AllwDupSIcode = "Yes" Then
            Return False
        End If

        If edit_ins = 1 Then
            existCode = obj.ScalarExecute("select TItemCode from tbl_TItemMaster Where TItemCode = '" & Trim(txtTItemCode.Text) & "' And ItemSubType = 'Sales' And CId = " & M_CId & "")
            If Trim(txtTItemCode.Text) = existCode Then
                Return True
            Else
                Return False
            End If
        Else
            existCode = obj.ScalarExecute("select TItemCode from tbl_TItemMaster Where CId = " & M_CId & " And TItemId <>" & Val(lblTItemId.Text) & " And TItemCode = '" & Trim(txtTItemCode.Text) & "' And ItemSubType = 'Sales' And CId = " & M_CId & "")
            If Trim(txtTItemCode.Text) = existCode Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function checkBarCode() As Boolean
        If edit_ins = 1 Then
            sql_query = "select BarCode from tbl_TItemMaster Where BarCode = '" & Trim(txtBarcode.Text) & "' And BarcodeType = '" & cmbBarcodeType.Text & "' And ItemSubType = 'Sales' And CId = " & M_CId & ""
            existBarCode = obj.ScalarExecute(sql_query)
            If Trim(txtBarcode.Text) = existBarCode Then
                Return True
            Else
                Return False
            End If
        Else
            If M_SalesItemList = "Same Company" Then
                sql_query = "select BarCode from tbl_TItemMaster Where TItemId <>" & Val(lblTItemId.Text) & " And BarCode = '" & Trim(txtBarcode.Text) & "' And BarcodeType = '" & cmbBarcodeType.Text & "' And ItemSubType = 'Sales' And CId = " & M_CId & ""
                existBarCode = obj.ScalarExecute(sql_query)
                If Trim(txtBarcode.Text) = existBarCode Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        End If
    End Function

    Public Function checkDesignNo() As Boolean
        If edit_ins = 1 Then
            sql_query = "select DesignNo from tbl_TItemMaster Where DesignNo = '" & Trim(txtDesignNo.Text) & "' And ItemSubType = 'Sales' And CId = " & M_CId & ""
            existDesignNo = obj.ScalarExecute(sql_query)
            If Trim(txtDesignNo.Text) = existDesignNo Then
                Return True
            Else
                Return False
            End If
        Else
            If M_SalesItemList = "Same Company" Then
                sql_query = "select DesignNo from tbl_TItemMaster Where TItemId <>" & Val(lblTItemId.Text) & " And DesignNo = '" & Trim(txtDesignNo.Text) & "' And ItemSubType = 'Sales' And CId = " & M_CId & ""
                existDesignNo = obj.ScalarExecute(sql_query)
                If Trim(txtDesignNo.Text) = existDesignNo Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        End If
    End Function

#End Region

#Region "Events"

    'Private Sub FrmSalesItemMaster_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    sql_query = "Select * From tbl_UISettings Where ObjectName = 'ITEM MASTER'"
    '    obj.LoadData(sql_query, dsUISetting)


    '    For i As Integer = 0 To dsUISetting.Tables(0).Rows.Count - 1
    '        Select Case dsUISetting.Tables(0).Rows(i)("FieldName")
    '            Case "TItemCode"
    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblTItemCode.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                    'grdData.Columns("TItemCode").Caption = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                txtTItemCode.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                lblTItemCode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtTItemCode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "BarCode"
    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblBarCode.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                    'grdData.Columns("BarCode").Caption = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                txtBarcode.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                lblBarCode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtBarcode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "TaxPer"
    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblTaxPer.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                    'grdData.Columns("TaxPer").Caption = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                txtTaxPer.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                lblTaxPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtTaxPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "CompanyName"
    '                lblBranch.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                cmbF_Company.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbF_Company.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "PurchaseDiscPer"
    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblPurchaseDiscPer.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                    'grdData.Columns("PurchaseDiscPer").Caption = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                txtPurchaseDiscPer.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                lblPurchaseDiscPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtPurchaseDiscPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "SalesDiscPer"
    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblSalesDiscPer.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                    'grdData.Columns("SalesDiscPer").Caption = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                txtSalesDiscPer.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                lblSalesDiscPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtSalesDiscPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "ItemType"
    '                cmbItemType.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbItemType.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblItemType.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "MfgName"
    '                cmbMfgName.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbMfgName.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblMfgName.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "ItemCategory"
    '                cmbItemCategory.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbItemCategory.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblItemCategory.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "ItemSize"
    '                cmbItemSize.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbItemSize.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblItemSize.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "ItemColor"
    '                cmbItemColor.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbItemColor.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblItemColor.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "ItemSubCategory"
    '                cmbItemSubCategory.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbItemSubCategory.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblItemSubCategory.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "SupplierName"
    '                cmbSupplierName.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbSupplierName.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblSupplierName.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "TItemName1"
    '                txtTItemName1.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtTItemName1.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblTItemName1.Visible = dsUISetting.Tables(0).Rows(i)("Visible")

    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblTItemName1.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                Exit Select
    '            Case "CatalogName"
    '                txtCatalogName.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtCatalogName.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblCatalogName.Visible = dsUISetting.Tables(0).Rows(i)("Visible")

    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblCatalogName.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                Exit Select
    '            Case "DesignNo"
    '                txtDesignNo.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtDesignNo.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblDesignNo.Visible = dsUISetting.Tables(0).Rows(i)("Visible")

    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblDesignNo.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                Exit Select
    '            Case "CommissionPer"
    '                txtCommissionPer.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtCommissionPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblCommissionPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "CommissionAmt"
    '                txtCommissionAmt.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtCommissionAmt.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblCommissionAmt.Visible = dsUISetting.Tables(0).Rows(i)("Visible")

    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblCommissionAmt.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                Exit Select
    '            Case "Location"
    '                txtLocation.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtLocation.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblLocation.Visible = dsUISetting.Tables(0).Rows(i)("Visible")

    '                If dsUISetting.Tables(0).Rows(i)("FieldText") <> "." Then
    '                    lblLocation.Text = dsUISetting.Tables(0).Rows(i)("FieldText")
    '                End If
    '                Exit Select
    '            Case "OpStk"
    '                txtOpStk.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtOpStk.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblOpStk.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "OpStkValue"
    '                txtValue.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtValue.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblValue.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "ReOrderLevel"
    '                txtReorderLevel.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtReorderLevel.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblReorderLevel.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "ManageStock"
    '                chkManageStock.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                chkManageStock.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "HSNCode"
    '                txtHSNCode.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtHSNCode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtHSNCode.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                lblHSNCode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '            Case "UOM"
    '                cmbUOM.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                cmbUOM.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '            Case "Fabric Wise Tailoring Rates"
    '                btnUpdateRates.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                gcDetail.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '        End Select
    '    Next

    '    Select Case M_SalesItemMasterF2
    '        Case True
    '            txtF_BarcodeFrom.Text = FrmHelpItemSelection_CustomerOrderTime.grdData.GetFocusedRowCellValue("BarCode")
    '            FrmHelpItemSelection_CustomerOrderTime.Close()

    '            loadTime_F2Time()

    '            If M_CallingFormItemCreation = "PO" Then
    '                gvData.FocusedRowHandle = 0
    '                fillData()
    '            End If

    '            addClickTime()
    '            Exit Select
    '        Case False
    '            loadTime()
    '            Exit Select
    '    End Select

    '    If checkRightsToLoad("Show Purchase Rate") = False Then
    '        lblPurchaseRate.Visible = False
    '        txtPurchaseRate.Visible = False
    '        gvData.Columns("PurchaseRate").Visible = False
    '    Else
    '        lblPurchaseRate.Visible = True
    '        txtPurchaseRate.Visible = True
    '        gvData.Columns("PurchaseRate").Visible = True
    '    End If
    'End Sub

    Private Sub FrmSalesItemMaster_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Select Case M_BusinessType
            Case "SALON"
                Me.Text = "Product Master"
                Exit Select
        End Select

        Dim dv As New DataView(dsUISettings.Tables(0))
        dv.RowFilter = " ObjectName = 'ITEM MASTER' "

        Dim tmpDT As New DataTable
        tmpDT = dv.ToTable

        For i As Integer = 0 To tmpDT.Rows.Count - 1
            Select Case tmpDT.Rows(i)("FieldName")
                Case "TItemCode"
                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblTItemCode.Text = tmpDT.Rows(i)("FieldText")
                        'grdData.Columns("TItemCode").Caption = tmpDT.Rows(i)("FieldText")
                    End If
                    txtTItemCode.TabStop = tmpDT.Rows(i)("TabStop")
                    lblTItemCode.Visible = tmpDT.Rows(i)("Visible")
                    txtTItemCode.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "BarCode"
                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblBarCode.Text = tmpDT.Rows(i)("FieldText")
                        'grdData.Columns("BarCode").Caption = tmpDT.Rows(i)("FieldText")
                    End If
                    txtBarcode.TabStop = tmpDT.Rows(i)("TabStop")
                    lblBarCode.Visible = tmpDT.Rows(i)("Visible")
                    txtBarcode.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "TaxPer"
                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblTaxPer.Text = tmpDT.Rows(i)("FieldText")
                        'grdData.Columns("TaxPer").Caption = tmpDT.Rows(i)("FieldText")
                    End If
                    txtTaxPer.TabStop = tmpDT.Rows(i)("TabStop")
                    lblTaxPer.Visible = tmpDT.Rows(i)("Visible")
                    txtTaxPer.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "CompanyName"
                    lblBranch.Visible = tmpDT.Rows(i)("Visible")
                    cmbF_Company.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbF_Company.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "PurchaseDiscPer"
                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblPurchaseDiscPer.Text = tmpDT.Rows(i)("FieldText")
                        'grdData.Columns("PurchaseDiscPer").Caption = tmpDT.Rows(i)("FieldText")
                    End If
                    txtPurchaseDiscPer.TabStop = tmpDT.Rows(i)("TabStop")
                    lblPurchaseDiscPer.Visible = tmpDT.Rows(i)("Visible")
                    txtPurchaseDiscPer.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "SalesDiscPer"
                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblSalesDiscPer.Text = tmpDT.Rows(i)("FieldText")
                        'grdData.Columns("SalesDiscPer").Caption = tmpDT.Rows(i)("FieldText")
                    End If
                    txtSalesDiscPer.TabStop = tmpDT.Rows(i)("TabStop")
                    lblSalesDiscPer.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "ItemType"
                    cmbItemType.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbItemType.Visible = tmpDT.Rows(i)("Visible")
                    lblItemType.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "MfgName"
                    cmbMfgName.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbMfgName.Visible = tmpDT.Rows(i)("Visible")
                    lblMfgName.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "ItemCategory"
                    cmbItemCategory.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbItemCategory.Visible = tmpDT.Rows(i)("Visible")
                    lblItemCategory.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "ItemSize"
                    cmbItemSize.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbItemSize.Visible = tmpDT.Rows(i)("Visible")
                    lblItemSize.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "ItemColor"
                    cmbItemColor.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbItemColor.Visible = tmpDT.Rows(i)("Visible")
                    lblItemColor.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "ItemSubCategory"
                    cmbItemSubCategory.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbItemSubCategory.Visible = tmpDT.Rows(i)("Visible")
                    lblItemSubCategory.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "SupplierName"
                    cmbSupplierName.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbSupplierName.Visible = tmpDT.Rows(i)("Visible")
                    lblSupplierName.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "TItemName1"
                    txtTItemName1.TabStop = tmpDT.Rows(i)("TabStop")
                    txtTItemName1.Visible = tmpDT.Rows(i)("Visible")
                    lblTItemName1.Visible = tmpDT.Rows(i)("Visible")

                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblTItemName1.Text = tmpDT.Rows(i)("FieldText")
                    End If
                    Exit Select
                Case "CatalogName"
                    txtCatalogName.TabStop = tmpDT.Rows(i)("TabStop")
                    txtCatalogName.Visible = tmpDT.Rows(i)("Visible")
                    lblCatalogName.Visible = tmpDT.Rows(i)("Visible")

                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblCatalogName.Text = tmpDT.Rows(i)("FieldText")
                    End If
                    Exit Select
                Case "DesignNo"
                    txtDesignNo.TabStop = tmpDT.Rows(i)("TabStop")
                    txtDesignNo.Visible = tmpDT.Rows(i)("Visible")
                    lblDesignNo.Visible = tmpDT.Rows(i)("Visible")

                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblDesignNo.Text = tmpDT.Rows(i)("FieldText")
                    End If
                    Exit Select
                Case "CommissionPer"
                    txtCommissionPer.TabStop = tmpDT.Rows(i)("TabStop")
                    txtCommissionPer.Visible = tmpDT.Rows(i)("Visible")
                    lblCommissionPer.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "CommissionAmt"
                    txtCommissionAmt.TabStop = tmpDT.Rows(i)("TabStop")
                    txtCommissionAmt.Visible = tmpDT.Rows(i)("Visible")
                    lblCommissionAmt.Visible = tmpDT.Rows(i)("Visible")

                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblCommissionAmt.Text = tmpDT.Rows(i)("FieldText")
                    End If
                    Exit Select
                Case "Location"
                    txtLocation.TabStop = tmpDT.Rows(i)("TabStop")
                    txtLocation.Visible = tmpDT.Rows(i)("Visible")
                    lblLocation.Visible = tmpDT.Rows(i)("Visible")

                    If tmpDT.Rows(i)("FieldText") <> "." Then
                        lblLocation.Text = tmpDT.Rows(i)("FieldText")
                    End If
                    Exit Select
                Case "OpStk"
                    txtOpStk.TabStop = tmpDT.Rows(i)("TabStop")
                    txtOpStk.Visible = tmpDT.Rows(i)("Visible")
                    lblOpStk.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "OpStkValue"
                    txtValue.TabStop = tmpDT.Rows(i)("TabStop")
                    txtValue.Visible = tmpDT.Rows(i)("Visible")
                    lblValue.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "ReOrderLevel"
                    txtReorderLevel.TabStop = tmpDT.Rows(i)("TabStop")
                    txtReorderLevel.Visible = tmpDT.Rows(i)("Visible")
                    lblReorderLevel.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "ManageStock"
                    chkManageStock.TabStop = tmpDT.Rows(i)("TabStop")
                    chkManageStock.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "HSNCode"
                    txtHSNCode.TabStop = tmpDT.Rows(i)("TabStop")
                    txtHSNCode.Visible = tmpDT.Rows(i)("Visible")
                    txtHSNCode.Text = tmpDT.Rows(i)("DefaultValue")
                    lblHSNCode.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
                Case "UOM"
                    cmbUOM.TabStop = tmpDT.Rows(i)("TabStop")
                    cmbUOM.Visible = tmpDT.Rows(i)("Visible")
                Case "Fabric Wise Tailoring Rates"
                    btnUpdateRates.Visible = tmpDT.Rows(i)("Visible")
                    gcDetail.Visible = tmpDT.Rows(i)("Visible")
                    btnPrintItemBarcodes.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
            End Select
        Next

        Select Case M_SalesItemMasterF2
            Case True
                loadTime_F2Time()


                'loadTime_F2Time()

                If M_CallingFormItemCreation = "PO" Then
                    gvData.FocusedRowHandle = 0
                    fillData()
                End If

                addClickTime()
                Exit Select
            Case False
                loadTime()
                Exit Select
        End Select

        If checkRightsToLoad("Show Purchase Rate") = False Then
            lblPurchaseRate.Visible = False
            txtPurchaseRate.Visible = False
            gvData.Columns("PurchaseRate").Visible = False
        Else
            lblPurchaseRate.Visible = True
            txtPurchaseRate.Visible = True
            gvData.Columns("PurchaseRate").Visible = True
        End If
    End Sub

    Private Sub FrmGarmentMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case UCase(M_SalesItemCharCasing)
            Case "UPPER"
                txtTItemName.CharacterCasing = CharacterCasing.Upper
                txtTItemName1.CharacterCasing = CharacterCasing.Upper
                Exit Select
            Case "LOWER"
                txtTItemName.CharacterCasing = CharacterCasing.Lower
                txtTItemName1.CharacterCasing = CharacterCasing.Lower
                Exit Select
        End Select

        ComboBox1.Text = "Fabric"
    End Sub

    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    If checkRightsToAdd("ITEM MASTER") = False Then
    '        MsgBox("Unable To Add New Record", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If

    '    addClickTime()

    '    For i As Integer = 0 To dsUISetting.Tables(0).Rows.Count - 1
    '        Select Case dsUISetting.Tables(0).Rows(i)("FieldName")
    '            Case "TItemCode"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtTItemCode.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtTItemCode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtTItemCode.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")

    '                Exit Select
    '            Case "BarCode"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtBarcode.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtBarcode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtBarcode.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                Exit Select
    '            Case "TaxPer"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtTaxPer.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtTaxPer.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtTaxPer.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                Exit Select
    '            Case "TItemName"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtItemName.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtItemName.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtItemName.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                Exit Select
    '            Case "TItemName1"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtTItemName1.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtTItemName1.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtTItemName1.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                Exit Select
    '            Case "DesignNo"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtDesignNo.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtDesignNo.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtDesignNo.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                Exit Select
    '            Case "CatalogName"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtCatalogName.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtCatalogName.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtCatalogName.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                Exit Select
    '            Case "Location"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtLocation.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtLocation.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                txtLocation.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                Exit Select
    '            Case "HSNCode"
    '                If dsUISetting.Tables(0).Rows(i)("DefaultValue") <> "." Then
    '                    txtHSNCode.Text = dsUISetting.Tables(0).Rows(i)("DefaultValue")
    '                End If
    '                txtHSNCode.TabStop = dsUISetting.Tables(0).Rows(i)("TabStop")
    '                txtHSNCode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                lblHSNCode.Visible = dsUISetting.Tables(0).Rows(i)("Visible")
    '                Exit Select
    '        End Select
    '    Next
    'End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If checkRightsToAdd("ITEM MASTER") = False Then
            MsgBox("Unable To Add New Record", MsgBoxStyle.Information)
            Exit Sub
        End If

        addClickTime()

        Dim dv As New DataView(dsUISettings.Tables(0))
        dv.RowFilter = " ObjectName = 'ITEM MASTER' "

        Dim tmpDT As New DataTable
        tmpDT = dv.ToTable

        For i As Integer = 0 To tmpDT.Rows.Count - 1
            Select Case tmpDT.Rows(i)("FieldName")
                Case "TItemCode"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtTItemCode.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtTItemCode.Visible = tmpDT.Rows(i)("Visible")
                    txtTItemCode.TabStop = tmpDT.Rows(i)("TabStop")

                    Exit Select
                Case "BarCode"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtBarcode.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtBarcode.Visible = tmpDT.Rows(i)("Visible")
                    txtBarcode.TabStop = tmpDT.Rows(i)("TabStop")
                    Exit Select
                Case "TaxPer"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtTaxPer.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtTaxPer.Visible = tmpDT.Rows(i)("Visible")
                    txtTaxPer.TabStop = tmpDT.Rows(i)("TabStop")
                    Exit Select
                Case "TItemName"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtTItemName.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtTItemName.Visible = tmpDT.Rows(i)("Visible")
                    txtTItemName.TabStop = tmpDT.Rows(i)("TabStop")
                    Exit Select
                Case "TItemName1"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtTItemName1.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtTItemName1.Visible = tmpDT.Rows(i)("Visible")
                    txtTItemName1.TabStop = tmpDT.Rows(i)("TabStop")
                    Exit Select
                Case "DesignNo"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtDesignNo.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtDesignNo.Visible = tmpDT.Rows(i)("Visible")
                    txtDesignNo.TabStop = tmpDT.Rows(i)("TabStop")
                    Exit Select
                Case "CatalogName"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtCatalogName.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtCatalogName.Visible = tmpDT.Rows(i)("Visible")
                    txtCatalogName.TabStop = tmpDT.Rows(i)("TabStop")
                    Exit Select
                Case "Location"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtLocation.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtLocation.Visible = tmpDT.Rows(i)("Visible")
                    txtLocation.TabStop = tmpDT.Rows(i)("TabStop")
                    Exit Select
                Case "HSNCode"
                    If tmpDT.Rows(i)("DefaultValue") <> "." Then
                        txtHSNCode.Text = tmpDT.Rows(i)("DefaultValue")
                    End If
                    txtHSNCode.TabStop = tmpDT.Rows(i)("TabStop")
                    txtHSNCode.Visible = tmpDT.Rows(i)("Visible")
                    lblHSNCode.Visible = tmpDT.Rows(i)("Visible")
                    Exit Select
            End Select
        Next
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If checkRightsToEdit("ITEM MASTER") = False Then
            MsgBox("Unable To Edit Record", MsgBoxStyle.Information)
            Exit Sub
        End If

        If M_CId = gvData.GetFocusedRowCellValue("CId") Then
            editClickTime()
        Else
            MsgBox("Please Change Company and Try to Edit", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If Trim(txtTItemCode.Text) = "" Then
        '    MsgBox("Please Specify Code", MsgBoxStyle.Information)
        '    txtTItemCode.Focus()
        '    Exit Sub
        'End If
        If Trim(txtTItemName.Text) = "" Then
            MsgBox("Please Specify Item Name", MsgBoxStyle.Information)
            txtTItemName.Focus()
            Exit Sub
        End If
        If cmbItemType.SelectedIndex = -1 Then
            MsgBox("Please Select Type", MsgBoxStyle.Information)
            cmbItemType.Focus()
            Exit Sub
        End If
        If cmbItemCategory.SelectedIndex = -1 Then
            MsgBox("Please Select Category", MsgBoxStyle.Information)
            cmbItemCategory.Focus()
            Exit Sub
        End If
        'If cmbItemSubCategory.SelectedIndex = -1 Then
        '    MsgBox("Please Select Sub-Category", MsgBoxStyle.Information)
        '    cmbItemSubCategory.Focus()
        '    Exit Sub
        'End If
        If cmbMfgName.SelectedIndex = -1 Then
            MsgBox("Please Select Manufacturer", MsgBoxStyle.Information)
            cmbMfgName.Focus()
            Exit Sub
        End If
        If cmbItemSize.SelectedIndex = -1 Then
            MsgBox("Please Select Size", MsgBoxStyle.Information)
            cmbItemSize.Focus()
            Exit Sub
        End If
        If cmbItemSizeRange.SelectedIndex = -1 Then
            MsgBox("Please Select Size Range", MsgBoxStyle.Information)
            cmbItemSizeRange.Focus()
            Exit Sub
        End If
        If cmbItemColor.SelectedIndex = -1 Then
            MsgBox("Please Select Color", MsgBoxStyle.Information)
            cmbItemColor.Focus()
            Exit Sub
        End If
        If cmbUOM.SelectedIndex = -1 Then
            MsgBox("Please Select UOM", MsgBoxStyle.Information)
            cmbUOM.Focus()
            Exit Sub
        End If

        'If checkCode() = True Then
        '    MsgBox("Item Code Already Exists, Please Specify Another One", MsgBoxStyle.Critical)
        '    txtTItemCode.Focus()
        '    Exit Sub
        'End If

        If Trim(txtBarcode.Text) <> "" Then
            If Val(txtBarcode.Text) > 0 Then
                If checkBarCode() = True Then
                    MsgBox("Bar-Code Already Exists, Please Specify Another One", MsgBoxStyle.Critical)
                    txtBarcode.Focus()
                    Exit Sub
                End If
            End If
        End If

        If M_DbName = "dbSTE_HTF" Then
            If Trim(txtDesignNo.Text) <> "" Then
                If checkDesignNo() = True Then
                    MsgBox("Design No Already Exists, Please Specify Another One", MsgBoxStyle.Critical)
                    txtDesignNo.Focus()
                    Exit Sub
                End If
            End If
        End If

        'SHALIMAR
        'If Trim(txtImgPath.Text) <> "" Then
        '    Dim buffer() As Byte = IO.File.ReadAllBytes(txtImgPath.Text)

        '    Dim bytes As Long = 0
        '    bytes = M_ItemMasterImageUploadSize * 1024

        '    If buffer.Length > bytes Then
        '        MsgBox("Image Size Big", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If
        'End If

        If edit_ins = 1 Then
            insert()
        Else
            edit()
        End If

        If UCase(M_OnSavePrint_BarcodeLabel) = "YES" Then
            Dim dr As DialogResult
            dr = MsgBox("Want To Print Barcode ?", MsgBoxStyle.YesNo)
            If dr = Windows.Forms.DialogResult.Yes Then
                ' prepare_BarcodeStimule_Shubhkamna_Fabric(True, True)
            End If
        End If

        saveClickTime()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If checkRightsToDelete("ITEM MASTER") = False Then
            MsgBox("Unable To Delete Record", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim dr As DialogResult
        dr = MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            sql_query = "Select Count(*) From tbl_PurchaseDetail Where ItemId = " & Val(lblTItemId.Text)
            If obj.ScalarExecute(sql_query) > 0 Then
                MsgBox("Unable To Delete. Purchase Entry Exist", MsgBoxStyle.Information)
                Exit Sub
            End If

            sql_query = "Select Count(*) From tbl_SalesDetail Where ItemId = " & Val(lblTItemId.Text)
            If obj.ScalarExecute(sql_query) > 0 Then
                MsgBox("Unable To Delete. Sales Entry Exist", MsgBoxStyle.Information)
                Exit Sub
            End If

            sql_query = "Select Count(*) From tbl_InvoiceDetail Where TItemId = " & Val(lblTItemId.Text)
            If obj.ScalarExecute(sql_query) > 0 Then
                MsgBox("Unable To Delete. Invoice Entry Exist", MsgBoxStyle.Information)
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

    Private Sub grdData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvData.Click
        If gvData.FocusedRowHandle < 0 Then
            Exit Sub
        End If

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

    Private Sub grdData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvData.DoubleClick
        If gvData.FocusedRowHandle < 0 Then
            Exit Sub
        End If

        Dim selectedRows() As Integer = gvData.GetSelectedRows

        If selectedRows.Length = 0 Then
            Exit Sub
        End If
        fillData()

        If checkRightsToEdit("ITEM MASTER") = False Then
            MsgBox("Unable To Edit Record", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim dr As DialogResult
        dr = MsgBox("Sure To Create New Item With Reference?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            addClickTime()

            txtOpStk.Clear()
            txtValue.Clear()


            'txtTItemCode.Clear()

            'txtTItemCode.Text = obj.ScalarExecute("Select Count(TItemId) + 1 From Tbl_TItemMaster Where ItemSubType = 'Sales'")
            'txtTItemCode.Text = "I" & StrDup(5 - Trim(txtTItemCode.Text).Length, "0") & Trim(txtTItemCode.Text)

            'txtBarcode.Clear()
            'txtItemName.Clear()
            'txtTItemName1.Clear()
        End If

        'editClickTime()
    End Sub

    Private Sub grdData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvData.KeyUp
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

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        loadItemMaster()
    End Sub

    Private Sub txtF_Barcode_TextChanged(sender As Object, e As EventArgs) Handles txtF_ItemName.TextChanged, txtF_BarcodeFrom.TextChanged, txtF_BarcodeTo.TextChanged
        If Val(txtF_BarcodeFrom.Text) > 0 And Val(txtF_BarcodeTo.Text) > 0 Then
            gvData.Columns("BarCode").ClearFilter()
            Dim dataView As New DataView(dsItemMaster.Tables(0))
            dataView.RowFilter = "BarCode >= '" & txtF_BarcodeFrom.Text & "' And BarCode <= '" & Val(txtF_BarcodeTo.Text) & "'"
            gcData.DataSource = dataView
        ElseIf Val(txtF_BarcodeFrom.Text) = 0 And Val(txtF_BarcodeTo.Text) = 0 Then
            gvData.Columns("BarCode").ClearFilter()
            gridfill2024()
        Else
            gvData.Columns("BarCode").FilterInfo = New ColumnFilterInfo("[BarCode] = " & Val(txtF_BarcodeFrom.Text))
        End If

        gvData.Columns("TItemName1").FilterInfo = New ColumnFilterInfo("[ItemSubType] <> " & "'Material'")
        gvData.Columns("TItemName").FilterInfo = New ColumnFilterInfo("[TItemName] Like " & "'" & Trim(txtF_ItemName.Text) & "%'")
    End Sub

    Private Sub txtImgPath_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImgPath.DoubleClick, lblBrowseimg.Click
        txtImgPath.Text = M_getImagePath(Me)
        pbImg.ImageLocation = txtImgPath.Text
        M_FixImageRotation(pbImg.Image)
    End Sub

    Private Sub txtImgPath_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImgPath.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                txtImgPath.Text = M_getImagePath(Me)
                pbImg.ImageLocation = txtImgPath.Text
                Exit Select
            Case Keys.Delete
                pbImg.Image = Nothing
                txtImgPath.Clear()
                Exit Select
        End Select
    End Sub

    Private Sub cmbItemType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbUOM.KeyDown, cmbMfgName.KeyDown, cmbItemType.KeyDown, cmbItemCategory.KeyDown, cmbItemSize.KeyDown, cmbItemColor.KeyDown, cmbItemSubCategory.KeyDown, cmbSupplierName.KeyDown, cmbItemSizeRange.KeyDown, cmbBarcodeType.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                If Trim(sender.Text) = "" Then
                    MsgBox("Please Specify " & sender.Tag, MsgBoxStyle.Information)
                    Exit Sub
                End If

                If M_checkMiscMaster(sender.Tag, Trim(sender.Text)) = False Then
                    insertMiscMaster(sender.Tag, Trim(sender.Text))
                    MsgBox(sender.Tag & " Added Successfully", MsgBoxStyle.Information)

                    '    If M_CompanyWiseMiscMaster = "Yes" Then
                    '        'ComboFill(sender, "Select MiscId , MiscName From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    '        Select Case sender.Tag
                    '            Case "ItemType"
                    '                ComboFill(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "ItemCategory"
                    '                ComboFill_ItemCategory(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "ItemSubCategory"
                    '                ComboFill_ItemSubCategory(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "MfgName"
                    '                ComboFill_MfgName(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "SupplierName"
                    '                ComboFill_SupplierName(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "ItemSize"
                    '                ComboFill_ItemSize(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "ItemColor"
                    '                ComboFill_ItemColor(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '        End Select
                    '    Else
                    '        'ComboFill(sender, "Select MiscId , MiscName From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    '        Select Case sender.Tag
                    '            Case "ItemType"
                    '                ComboFill_ItemType(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "ItemCategory"
                    '                ComboFill_ItemCategory(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "ItemSubCategory"
                    '                ComboFill_ItemSubCategory(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "MfgName"
                    '                ComboFill_MfgName(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "SupplierName"
                    '                ComboFill_SupplierName(cmbSupplierName, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "ItemSize"
                    '                ComboFill_ItemSize(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '            Case "ItemColor"
                    '                ComboFill_ItemColor(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    '                Exit Select
                    '        End Select
                    '    End If
                    '    sender.DroppedDown = True
                    'Else
                    '    MsgBox(sender.Tag & " Already Exist", MsgBoxStyle.Information)
                    'End If

                    loadMiscMaster()
                    If M_CompanyWiseMiscMaster = "Yes" Then
                        'ComboFill(sender, "Select MiscId , MiscName From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                        Select Case sender.Tag
                            Case "ItemType"
                                ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "'")
                                Exit Select
                            Case "ItemCategory"
                                ComboFill(sender, "CId = " & M_CId & " And MiscType = '" & sender.Tag & "'")
                                Exit Select
                            Case "ItemSubCategory"
                                ComboFill(sender, "CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                                Exit Select
                            Case "MfgName"
                                ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                                Exit Select
                            Case "SupplierName"
                                ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "'")
                                Exit Select
                            Case "ItemSize"
                                ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                                Exit Select
                            Case "ItemColor"
                                ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                                Exit Select
                        End Select
                    Else
                        'ComboFill(sender, "Select MiscId , MiscName From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                        Select Case sender.Tag
                            Case "ItemType"
                                ComboFill(sender, " MiscType = '" & sender.Tag & "' ")
                                Exit Select
                            Case "ItemCategory"
                                ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                                Exit Select
                            Case "ItemSubCategory"
                                ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                                Exit Select
                            Case "MfgName"
                                ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                                Exit Select
                            Case "SupplierName"
                                ComboFill(cmbSupplierName, " MiscType = '" & sender.Tag & "' ")
                                Exit Select
                            Case "ItemSize"
                                ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                                Exit Select
                            Case "ItemColor"
                                ComboFill(sender, " MiscType = '" & sender.Tag & "' ")
                                Exit Select
                        End Select
                    End If
                    sender.DroppedDown = True
                Else
                    MsgBox(sender.Tag & " Already Exist", MsgBoxStyle.Information)
                End If

                Exit Select
            Case Keys.F5
                'If M_CompanyWiseMiscMaster = "Yes" Then
                '    'ComboFill(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                '    Select Case sender.Tag
                '        Case "ItemType"
                '            ComboFill_ItemType(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "ItemCategory"
                '            ComboFill_ItemCategory(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "ItemSubCategory"
                '            ComboFill_ItemSubCategory(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "MfgName"
                '            ComboFill_MfgName(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "SupplierName"
                '            ComboFill_SupplierName(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "ItemSize"
                '            ComboFill_ItemSize(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "ItemColor"
                '            ComboFill_ItemColor(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '    End Select
                'Else
                '    'ComboFill(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                '    Select Case sender.Tag
                '        Case "ItemType"
                '            ComboFill_ItemType(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "ItemCategory"
                '            ComboFill_ItemCategory(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "ItemCategory"
                '            ComboFill_ItemSubCategory(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "MfgName"
                '            ComboFill_MfgName(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "SupplierName"
                '            ComboFill_SupplierName(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "ItemSize"
                '            ComboFill_ItemSize(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '        Case "ItemColor"
                '            ComboFill_ItemColor(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                '            Exit Select
                '    End Select
                'End If

                If M_CompanyWiseMiscMaster = "Yes" Then
                    'ComboFill(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & sender.Tag & "' Order By MiscName")
                    Select Case sender.Tag
                        Case "ItemType"
                            ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                            Exit Select
                        Case "ItemCategory"
                            ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                            Exit Select
                        Case "ItemSubCategory"
                            ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                            Exit Select
                        Case "MfgName"
                            ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                            Exit Select
                        Case "SupplierName"
                            ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                            Exit Select
                        Case "ItemSize"
                            ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                            Exit Select
                        Case "ItemColor"
                            ComboFill(sender, " CId = " & M_CId & " And MiscType = '" & sender.Tag & "' ")
                            Exit Select
                    End Select
                Else
                    'ComboFill(sender, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where MiscType = '" & sender.Tag & "' Order By MiscName")
                    Select Case sender.Tag
                        Case "ItemType"
                            ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                            Exit Select
                        Case "ItemCategory"
                            ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                            Exit Select
                        Case "ItemCategory"
                            ComboFill(sender, "e MiscType = '" & sender.Tag & "'")
                            Exit Select
                        Case "MfgName"
                            ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                            Exit Select
                        Case "SupplierName"
                            ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                            Exit Select
                        Case "ItemSize"
                            ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                            Exit Select
                        Case "ItemColor"
                            ComboFill(sender, " MiscType = '" & sender.Tag & "'")
                            Exit Select
                    End Select
                End If
                sender.DroppedDown = True
                Exit Select
            Case Keys.Enter
                If e.KeyCode = Keys.Enter Then
                    SendKeys.Send("{Tab}")
                End If
                Exit Select
        End Select
    End Sub


#Region "Navigation"

    Private Sub txtItemCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTItemName1.KeyPress, txtTItemCode.KeyPress, txtImgPath.KeyPress, cmbUOM.KeyPress, chkIsActive.KeyPress, txtBarcode.KeyPress, txtDesignNo.KeyPress, txtCatalogName.KeyPress, txtLocation.KeyPress, cmbF_Company.KeyPress, chkManageStock.KeyPress, txtF_BarcodeFrom.KeyPress, txtF_BarcodeTo.KeyPress, txtPrintCopies.KeyPress, txtF_ItemName.KeyPress, ComboBox1.KeyPress, cmbItemSizeRange.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtHSNCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHSNCode.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
        'If e.KeyChar = Chr(8) Then
        '    Exit Sub
        'End If
        'If checkNumber(Asc(e.KeyChar)) = False Then
        '    e.KeyChar = Chr(0)
        'End If
    End Sub

    Private Sub txtOpStk_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpStk.KeyPress, txtSalesRate.KeyPress, txtSalesRateA.KeyPress, txtReorderLevel.KeyPress, txtPurchaseRate.KeyPress, txtValue.KeyPress, txtTaxPer.KeyPress, txtPurchaseDiscPer.KeyPress, txtSalesDiscPer.KeyPress, txtCommissionPer.KeyPress, txtCommissionAmt.KeyPress
        If e.KeyChar = Chr(13) Then
            If Trim(sender.Text) = "" Then
                sender.Text = "0"
            End If
            SendKeys.Send("{Tab}")
        End If

        If e.KeyChar = Chr(8) Then
            Exit Sub
        End If
        If Not sender.Text.Contains(".") Then
            point = False
        End If
        If Not sender.Text.Contains("-") Then
            minus = False
        End If


        If e.KeyChar = Chr(46) And point = False Then
            point = True
            Exit Sub
        End If
        If e.KeyChar = Chr(45) And minus = False Then
            minus = True
            Exit Sub
        End If


        If checkNumber(Asc(e.KeyChar)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub cmbItemType_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUOM.Enter, cmbItemType.Enter, cmbItemCategory.Enter, cmbItemSize.Enter, cmbMfgName.Enter, cmbItemColor.Enter, cmbItemSubCategory.Enter, cmbSupplierName.Enter, cmbItemSizeRange.Enter, cmbBarcodeType.Enter
        If sender.Items.Count > 0 Then
            sender.DroppedDown = True
            If sender.SelectedIndex = -1 Then
                sender.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub txtRate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPurchaseRate.Validating, txtOpStk.Validating
        txtValue.Text = Format(Val(txtPurchaseRate.Text) * Val(txtOpStk.Text), "0.00")

        If M_SalesItemMaster = "Retail" Or M_DbName = "dbSTE_HTF" Then
            Select Case Val(txtPurchaseRate.Text)
                Case >= 2500
                    txtTaxPer.Text = 18
                    Exit Select
                Case Else '<= 1000
                    txtTaxPer.Text = 5
                    Exit Select
            End Select
        End If
    End Sub

    Private Sub txtValue_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtValue.Validating
        If Val(txtValue.Text) > 0 And Val(txtOpStk.Text) > 0 Then
            txtPurchaseRate.Text = Format(Val(txtValue.Text) / Val(txtOpStk.Text), "0.00")
        End If
    End Sub

#End Region

    Private Sub PreviewBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewBarcodeToolStripMenuItem.Click
        prepare_BarcodeStimule_Shubhkamna_Fabric(False, False)
    End Sub

    Private Sub PrintBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintBarcodeToolStripMenuItem.Click
        'prepare_BarcodeStimule_Shubhkamna_Fabric(True, False)
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Select Case ComboBox1.Text
            Case "PRN"
                Select Case M_BarcodeLabelSheet
                    Case "StimulReport"
                        'prepare_label_PRN()
                        ' prepare_BarcodeStimule(gvData.FocusedRowHandle, True)
                        'prepare_PRN_Parampara_Stimule(grdData.FocusedRowHandle)
                        Exit Select
                    Case Else
                        prepare_label_PRN_AlMoazzam()
                        Exit Select
                End Select
                Exit Select
            Case "Fabric"
                Select Case M_BarcodeLabelSheet
                    Case "StimulReport"
                        'prepare_BarcodeStimule_Shubhkamna_Fabric(False, False)
                        Exit Select
                    Case Else
                        'prepare_BarcodeStimule_Shubhkamna_Fabric(False, False)
                        Exit Select
                End Select
                Exit Select
            Case "Readymade"
                prepare_label_PRN_Shubhkamna_Readymade()
                Exit Select
        End Select
    End Sub


    Public Sub prepare_label_PRN()
        Dim tmpQty As Integer = Val(txtPrintCopies.Text)

        Dim tmpFileName As String = ""
        Dim pgs As Integer = tmpQty

        tmpFileName = "PARAMPARA_" & tmpQty & ".prn"

        prnCode = obj.ScalarExecute("Select LabelCode From tbl_PRNLabels Where LabelType = 'Parampara'")

        'Select Case tmpQty
        '    Case 1
        '        prnCode = obj.ScalarExecute("Select LabelCode From tbl_PRNLabels Where LabelType = 'KC-1'")
        '        Exit Select
        '    Case 2
        '        prnCode = obj.ScalarExecute("Select LabelCode From tbl_PRNLabels Where LabelType = 'KC-2'")
        '        Exit Select
        '    Case Is > 2
        '        pgs = tmpQty / 2
        '        If tmpQty Mod 2 = 0 Then
        '            prnCode = obj.ScalarExecute("Select LabelCode From tbl_PRNLabels Where LabelType = 'KC-4'")
        '        Else
        '            prnCode = obj.ScalarExecute("Select LabelCode From tbl_PRNLabels Where LabelType = 'KC-3'")
        '        End If
        '        Exit Select
        'End Select

        Dim iFileNo As Integer
        iFileNo = FreeFile()
        FileOpen(iFileNo, Application.StartupPath & "\" & tmpFileName, OpenMode.Output)

        LabelText = prnCode

        Dim _field, _replace As String
        While LabelText.Contains("{")
            _field = LabelText.Substring(LabelText.IndexOf("{") + 1, LabelText.IndexOf("}") - LabelText.IndexOf("{") - 1)
            _replace = LabelText.Substring(LabelText.IndexOf("{"), LabelText.IndexOf("}") - LabelText.IndexOf("{") + 1)
            Select Case _replace
                Case "{Barcode}"
                    LabelText = LabelText.Replace(_replace, txtBarcode.Text)
                    Exit Select
                Case "{ItemName}"
                    LabelText = LabelText.Replace(_replace, txtTItemName.Text)
                    Exit Select
                Case "{MfgName}"
                    LabelText = LabelText.Replace(_replace, cmbMfgName.Text)
                    Exit Select
                Case "{TItemCode}"
                    LabelText = LabelText.Replace(_replace, txtTItemCode.Text)
                    Exit Select
                Case "{ItemCategory}"
                    LabelText = LabelText.Replace(_replace, cmbItemCategory.Text)
                    Exit Select
                Case "{ItemSubCategory}"
                    LabelText = LabelText.Replace(_replace, cmbItemSubCategory.Text)
                    Exit Select
                Case "{ItemColor}"
                    LabelText = LabelText.Replace(_replace, cmbItemColor.Text)
                    Exit Select
                Case "{ItemFor}"
                    LabelText = LabelText.Replace(_replace, "")
                    Exit Select
                Case "{ItemSize}"
                    LabelText = LabelText.Replace(_replace, cmbItemSize.Text)
                    Exit Select
                Case "{ItemSizeRange}"
                    LabelText = LabelText.Replace(_replace, "")
                    Exit Select
                Case "{UOM}"
                    LabelText = LabelText.Replace(_replace, cmbUOM.Text)
                    Exit Select
                Case "{PurchaseRate}"
                    LabelText = LabelText.Replace(_replace, txtPurchaseRate.Text)
                    Exit Select
                Case "{MRP}"
                    LabelText = LabelText.Replace(_replace, txtMRP.Text)
                    Exit Select
                Case "{SalesRate}"
                    LabelText = LabelText.Replace(_replace, txtSalesRate.Text)
                    Exit Select
                Case "{SalesRateA}"
                    LabelText = LabelText.Replace(_replace, txtSalesRate.Text)
                    Exit Select
                Case "{PurchasePriceCode}"
                    Dim tmpPurchasePriceCode As String = ""
                    tmpPurchasePriceCode = txtPurchaseRate.Text
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("1", M_PurchasePriceCode(0))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("2", M_PurchasePriceCode(1))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("3", M_PurchasePriceCode(2))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("4", M_PurchasePriceCode(3))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("5", M_PurchasePriceCode(4))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("6", M_PurchasePriceCode(5))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("7", M_PurchasePriceCode(6))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("8", M_PurchasePriceCode(7))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("9", M_PurchasePriceCode(8))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace("0", M_PurchasePriceCode(9))
                    tmpPurchasePriceCode = tmpPurchasePriceCode.Replace(".", M_PurchasePriceCode(10))

                    LabelText = LabelText.Replace(_replace, tmpPurchasePriceCode)
                    Exit Select
                Case "{pgs}"
                    LabelText = LabelText.Replace(_replace, pgs)
                    Exit Select
            End Select
        End While

        PrintLine(iFileNo, LabelText)
        Shell(Strings.Replace(M_PrnCmd, "{FILEPATH}", """" & Application.StartupPath & "\" & tmpFileName & """"), vbNormalFocus)

        FileClose(iFileNo)
    End Sub

    Public Sub prepare_label_PRN_AlMoazzam()
        Dim iFileNo As Integer
        iFileNo = FreeFile()
        FileOpen(iFileNo, Application.StartupPath & "\SalesItemMasterLabel.prn", OpenMode.Output)

        PrintLine(iFileNo, "SIZE 53 mm, 38 mm")
        PrintLine(iFileNo, "GAP 3 mm, 0 mm")
        PrintLine(iFileNo, "SPEED 4")
        PrintLine(iFileNo, "DENSITY 8")
        PrintLine(iFileNo, "SET RIBBON ON")
        PrintLine(iFileNo, "DIRECTION 0,0")
        PrintLine(iFileNo, "REFERENCE 0,0")
        PrintLine(iFileNo, "OFFSET 0 mm")
        PrintLine(iFileNo, "SET PEEL OFF")
        PrintLine(iFileNo, "SET CUTTER OFF")
        PrintLine(iFileNo, "SET PARTIAL_CUTTER OFF")
        PrintLine(iFileNo, "SET TEAR ON")
        PrintLine(iFileNo, "CLS")
        PrintLine(iFileNo, "CODEPAGE 1252")


        PrintLine(iFileNo, "TEXT 370,291,""0"",180,20,19,""AL MOAZZAM""")
        PrintLine(iFileNo, "TEXT 363,204,""0"",180,11,10,""D.NO""")
        PrintLine(iFileNo, "TEXT 363,147,""0"",180,15,10,""M.R.P.""")
        PrintLine(iFileNo, "TEXT 363,175,""0"",180,11,10,""SIZE""")
        PrintLine(iFileNo, "TEXT 363,232,""0"",180,9,10,""PRO.NAME")
        PrintLine(iFileNo, "TEXT 216,232,""0"",180,9,10,"":")
        PrintLine(iFileNo, "TEXT 216,204,""0"",180,9,10,"":")
        PrintLine(iFileNo, "TEXT 216,175,""0"",180,9,10,"":")
        PrintLine(iFileNo, "TEXT 216,147,""0"",180,9,10,"":")
        PrintLine(iFileNo, "TEXT 194,232,""0"",180,10,10,""" & txtTItemName.Text & """")
        PrintLine(iFileNo, "TEXT 194,204,""0"",180,9,10,""" & txtTItemCode.Text & """")
        PrintLine(iFileNo, "TEXT 194,175,""0"",180,9,10,""" & cmbItemSize.Text & """")
        PrintLine(iFileNo, "TEXT 194,147,""0"",180,10,11,""" & Format(Val(txtSalesRate.Text), "0.00") & """")
        PrintLine(iFileNo, "BARCODE 343,109,""128M"",67,0,180,3,6,""!105" & txtBarcode.Text & """")
        PrintLine(iFileNo, "TEXT 281,37,""ROMAN.TTF"",180,1,10,"" " & txtBarcode.Text & """")
        PrintLine(iFileNo, "TEXT 404,7,""0"",90,8,6,""(FIRST WASH DRY CLEAN)""")
        PrintLine(iFileNo, "PRINT 1," & Val(txtPrintCopies.Text) & "")



        'PrintLine(iFileNo, "TEXT 370,291,""0"",180,20,19,""AL MOAZZAM""")
        'PrintLine(iFileNo, "TEXT 363,204,""0"",180,11,10,""D.NO""")
        'PrintLine(iFileNo, "TEXT 363,147,""0"",180,15,10,""" & txtSalesRate.Text & """")
        'PrintLine(iFileNo, "TEXT 363,175,""0"",180,11,10,""" & cmbItemSize.Text & """")
        'PrintLine(iFileNo, "TEXT 363,232,""0"",180,9,10,""PRO.NAME")
        'PrintLine(iFileNo, "TEXT 216,232,""0"",180,9,10,"":")
        'PrintLine(iFileNo, "TEXT 216,204,""0"",180,9,10,"":")
        'PrintLine(iFileNo, "TEXT 216,175,""0"",180,9,10,"":")
        'PrintLine(iFileNo, "TEXT 216,147,""0"",180,9,10,"":")
        'PrintLine(iFileNo, "TEXT 194,232,""0"",180,10,10,""" & txtItemName.Text & """")
        'PrintLine(iFileNo, "TEXT 194,204,""0"",180,9,10,""" & txtTItemCode.Text & """")





        'PrintLine(iFileNo, "TEXT 744,222,""0"",180,8,8,""" & txtLedgerName.Text & """")
        'PrintLine(iFileNo, "BAR 559,201, 185, 1")
        'PrintLine(iFileNo, "TEXT 744,187,""0"",180,8,8,""" & grdInvDetail.Rows(i).Cells("ItemName1").Value & """")
        'PrintLine(iFileNo, "TEXT 744,148,""0"",180,8,8,""T. QUANTITY  -""")
        'PrintLine(iFileNo, "TEXT 523,148,""0"",180,8,8,""" & grdInvDetail.Rows(i).Cells("ItemQty1").Value & """")
        'PrintLine(iFileNo, "ERASE 439,255,282,54")
        'PrintLine(iFileNo, "TEXT 720,308,""0"",180,24,16,""SHEHNAII""")
        'PrintLine(iFileNo, "REVERSE 439,255,282,54")
        'PrintLine(iFileNo, "TEXT 744,104,""0"",180,8,8,""DATE OF DIL.-""")
        'PrintLine(iFileNo, "TEXT 530,104,""0"",180,8,8,""" & dtpDeliveryDate.Text & """")
        'PrintLine(iFileNo, "TEXT 744,60,""0"",180,8,8,""DATE of trial.-""")
        'PrintLine(iFileNo, "TEXT 530,60,""0"",180,8,8,""" & dtpTrialDate.Text & """")
        'PrintLine(iFileNo, "TEXT 373,187,""0"",180,8,8,""" & grdInvDetail.Rows(i).Cells("ItemName1").Value & """")
        'PrintLine(iFileNo, "TEXT 373,148,""0"",180,8,8,""T. QUANTITY  -""")
        'PrintLine(iFileNo, "TEXT 152,148,""0"",180,8,8,""" & grdInvDetail.Rows(i).Cells("ItemQty1").Value & """")
        'PrintLine(iFileNo, "ERASE 68,255,282,54")
        'PrintLine(iFileNo, "TEXT 349,308,""0"",180,24,16,""SHEHNAII""")
        'PrintLine(iFileNo, "REVERSE 68,255,282,54")
        'PrintLine(iFileNo, "TEXT 373,104,""0"",180,8,8,""DATE OF DIL.-""")
        'PrintLine(iFileNo, "TEXT 159,104,""0"",180,8,8,""" & dtpDeliveryDate.Text & """")
        'PrintLine(iFileNo, "TEXT 373,60,""0"",180,8,8,""DATE of trial.-""")
        'PrintLine(iFileNo, "TEXT 159,60,""0"",180,8,8,""" & dtpTrialDate.Text & """")
        'PrintLine(iFileNo, "TEXT 373,222,""0"",180,8,8,""CUSTOMER NAME""")
        'PrintLine(iFileNo, "BAR 188,201, 185, 1")
        'PrintLine(iFileNo, "PRINT 1,1")

        Shell(Strings.Replace(M_PrnCmd, "{FILEPATH}", """" & Application.StartupPath & "\SalesItemMasterLabel.prn" & """"), vbNormalFocus)

        FileClose(iFileNo)
    End Sub

    Public Sub prepare_label_PRN_Shubhkamna_Fabric()
        Dim iFileNo As Integer
        iFileNo = FreeFile()
        FileOpen(iFileNo, Application.StartupPath & "\Shubhkamna_Fabric.prn", OpenMode.Output)

        PrintLine(iFileNo, "SIZE 50 mm, 35 mm")
        PrintLine(iFileNo, "GAP 3 mm, 0 mm")
        PrintLine(iFileNo, "SPEED 4")
        PrintLine(iFileNo, "DENSITY 7")
        PrintLine(iFileNo, "DIRECTION 0,0")
        PrintLine(iFileNo, "REFERENCE 0,0")
        PrintLine(iFileNo, "OFFSET 0 mm")
        PrintLine(iFileNo, "SHIFT 0")
        PrintLine(iFileNo, "SET PEEL OFF")
        PrintLine(iFileNo, "SET CUTTER OFF")
        PrintLine(iFileNo, "SET TEAR ON")
        PrintLine(iFileNo, "CLS")
        PrintLine(iFileNo, "BOX 14,14,391,263,2")
        PrintLine(iFileNo, "BARCODE 319,255,""128M"",46,0,180,3,6,""!105" & txtBarcode.Text & """")
        PrintLine(iFileNo, "CODEPAGE 850")
        PrintLine(iFileNo, "TEXT 245,204,""ROMAN.TTF"",180,1,8,""" & txtBarcode.Text & """")
        PrintLine(iFileNo, "TEXT 383,171,""ROMAN.TTF"",180,1,12,""FABRIC  NO: " & txtTItemName.Text & """")
        PrintLine(iFileNo, "TEXT 383,125,""ROMAN.TTF"",180,1,8,""TYPE: " & cmbItemType.Text & """")
        PrintLine(iFileNo, "TEXT 383,93,""ROMAN.TTF"",180,1,8,""WIDTH: " & cmbItemSize.Text & """")
        PrintLine(iFileNo, "TEXT 383,61,""ROMAN.TTF"",180,1,8,""OPENING QTY: " & txtOpStk.Text & """")
        PrintLine(iFileNo, "TEXT 125,109,""ROMAN.TTF"",180,1,8,""Rate / Mtr.""")
        PrintLine(iFileNo, "TEXT 149,82,""ROMAN.TTF"",180,1,14,""" & txtSalesRate.Text & """")
        PrintLine(iFileNo, "TEXT 127,38,""ROMAN.TTF"",180,1,4,""(Inclusive of all Taxes)""")
        PrintLine(iFileNo, "PRINT 1," & Val(txtPrintCopies.Text) & "")

        Shell(Strings.Replace(M_PrnCmd, "{FILEPATH}", """" & Application.StartupPath & "\Shubhkamna_Fabric.prn" & """"), vbNormalFocus)

        FileClose(iFileNo)
    End Sub

    Public Sub prepare_label_PRN_Shubhkamna_Readymade()
        Dim iFileNo As Integer
        iFileNo = FreeFile()
        FileOpen(iFileNo, Application.StartupPath & "\Shubhkamna_ReadyMade.prn", OpenMode.Output)

        PrintLine(iFileNo, "SIZE 50 mm, 35 mm")
        PrintLine(iFileNo, "GAP 3 mm, 0 mm")
        PrintLine(iFileNo, "SPEED 4")
        PrintLine(iFileNo, "DENSITY 7")
        PrintLine(iFileNo, "DIRECTION 0,0")
        PrintLine(iFileNo, "REFERENCE 0,0")
        PrintLine(iFileNo, "OFFSET 0 mm")
        PrintLine(iFileNo, "SHIFT 0")
        PrintLine(iFileNo, "SET PEEL OFF")
        PrintLine(iFileNo, "SET CUTTER OFF")
        PrintLine(iFileNo, "SET TEAR ON")
        PrintLine(iFileNo, "CLS")
        PrintLine(iFileNo, "BOX 14,14,391,263,2")
        PrintLine(iFileNo, "BARCODE 319,255,""128M"",46,0,180,3,6,""!105" & txtBarcode.Text & """")
        PrintLine(iFileNo, "CODEPAGE 850")
        PrintLine(iFileNo, "TEXT 245,204,""ROMAN.TTF"",180,1,8,""" & txtBarcode.Text & """")
        PrintLine(iFileNo, "TEXT 383,173,""ROMAN.TTF"",180,1,8,""NAME - " & txtTItemName.Text & """")
        PrintLine(iFileNo, "TEXT 383,125,""ROMAN.TTF"",180,1,8,""TYPE - " & cmbItemType.Text & """")
        PrintLine(iFileNo, "TEXT 149,82,""ROMAN.TTF"",180,1,14,""" & txtSalesRate.Text & """")
        PrintLine(iFileNo, "TEXT 127,38,""ROMAN.TTF"",180,1,4,""(Inclusive of all Taxes)""")
        PrintLine(iFileNo, "TEXT 383,109,""ROMAN.TTF"",180,1,8,""CATEGORY - " & cmbItemCategory.Text & """")
        PrintLine(iFileNo, "TEXT 383,77,""ROMAN.TTF"",180,1,8,""MFG. - " & cmbMfgName.Text & """")
        PrintLine(iFileNo, "TEXT 383,45,""ROMAN.TTF"",180,1,8,""SIZE - " & cmbItemSize.Text & """")
        PrintLine(iFileNo, "TEXT 109,109,""ROMAN.TTF"",180,1,8,""MRP Rs.""")
        PrintLine(iFileNo, "PRINT 1," & Val(txtPrintCopies.Text) & "")

        Shell(Strings.Replace(M_PrnCmd, "{FILEPATH}", """" & Application.StartupPath & "\Shubhkamna_ReadyMade.prn" & """"), vbNormalFocus)

        FileClose(iFileNo)
    End Sub

    Private Sub cmbItemType_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmbItemType.Validating
        Select Case M_DbName
            Case "dbSTE_KFL2024"

                Exit Select
            Case "dbSTE_AANCHAL"
                Select Case cmbItemType.Text
                    Case "FABRIC"
                        txtTaxPer.Text = "5"
                        txtHSNCode.Text = "5407"
                        cmbUOM.Text = "MTR"
                        Exit Select
                    Case "READYMADE"
                        txtTaxPer.Text = "12"
                        txtHSNCode.Text = "6211"
                        cmbUOM.Text = "PCS"
                        Exit Select
                End Select
                Exit Select
            Case Else

                Exit Select
        End Select

        Dim tmpCIDfilter As String = ""
        If M_CompanyWiseMiscMaster = "Yes" Then
            tmpCIDfilter = " And CId = " & M_CId
        End If

        sql_query = "Select Count(*) From Tbl_MiscMaster Where MiscType = '" & cmbItemType.Text & " CATEGORY'"
        'If obj.ScalarExecute(sql_query) > 0 Then
        '    'cmbItemCategory.Items.Clear()
        '    'ComboFill(cmbItemCategory, "Select MiscId , MiscName From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & cmbItemType.Text & " CATEGORY' Order By MiscName")
        '    ComboFill_ItemCategory(cmbItemCategory, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where 1=1 " & tmpCIDfilter & " And MiscType = '" & cmbItemType.Text & " CATEGORY' Order By DispSrNo, MiscName")
        '    ComboFill_ItemSubCategory(cmbItemSubCategory, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where 1=1 " & tmpCIDfilter & " And MiscType = '" & cmbItemType.Text & " SUB CATEGORY' Order By DispSrNo, MiscName")
        'Else
        '    'ComboFill(cmbItemCategory, "Select MiscId , MiscName From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ItemCategory' Order By MiscName")
        '    ComboFill_ItemCategory(cmbItemCategory, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where 1=1 " & tmpCIDfilter & " And MiscType = 'ItemCategory' Order By DispSrNo, MiscName")
        '    ComboFill_ItemSubCategory(cmbItemSubCategory, "Select MiscId , MiscName, Data1 From Tbl_MiscMaster Where 1=1 " & tmpCIDfilter & " And MiscType = 'ItemSubCategory' Order By DispSrNo, MiscName")
        'End If

        If obj.ScalarExecute(sql_query) > 0 Then
            'cmbItemCategory.Items.Clear()
            'ComboFill(cmbItemCategory, "Select MiscId , MiscName From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = '" & cmbItemType.Text & " CATEGORY' Order By MiscName")
            ComboFill(cmbItemCategory, "1=1 " & tmpCIDfilter & " And MiscType = '" & cmbItemType.Text & " CATEGORY' ")
            ComboFill(cmbItemSubCategory, "1=1 " & tmpCIDfilter & " And MiscType = '" & cmbItemType.Text & " SUB CATEGORY'")
        Else
            'ComboFill(cmbItemCategory, "Select MiscId , MiscName From Tbl_MiscMaster Where CId = " & M_CId & " And MiscType = 'ItemCategory' Order By MiscName")
            ComboFill(cmbItemCategory, "1=1 " & tmpCIDfilter & " And MiscType = 'ItemCategory' ")
            ComboFill(cmbItemSubCategory, "1=1 " & tmpCIDfilter & " And MiscType = 'ItemSubCategory'")
        End If
    End Sub

    Private Sub txtBarcode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBarcode.TextChanged
        If edit_ins = 1 Then
            'txtF_Barcode.Text = txtBarcode.Text
        End If
    End Sub

    Private Sub txtItemName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTItemName.TextChanged
        If edit_ins = 1 Then
            'txtF_ItemName.Text = txtItemName.Text
        End If
    End Sub

    Private Sub btnStockCheck_Click(sender As Object, e As EventArgs) Handles btnStockCheck.Click
        M_callingForm_ProductHelp = "SalesItem_StockCheck"
        ' FrmHelpStockCheck.ShowDialog()
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog

        If sfd.ShowDialog() = DialogResult.OK Then
            gvData.ExportToXlsx(sfd.FileName & ".xlsx")
        End If
    End Sub

    Private Sub ProcessCSVFile()
        UpdFromExcel = True
        SplashScreenManager.CloseForm(True)
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Check Item Name")
        Dim ofd As New OpenFileDialog()
        If ofd.ShowDialog() = DialogResult.OK Then
            If Trim(ofd.FileName) <> "" Then
                Using reader As New StreamReader(ofd.FileName)
                    Dim firstLine = reader.ReadLine()  ' Read header line (optional)
                    Dim headers As String() = firstLine?.Split(","c)  ' Split header into an array (optional)
                    Dim indx As Integer

                    '================== Check Combo For Validation =======================

                    While Not reader.EndOfStream

                        Dim tmpItemtype, tmpItemCategory, tmpItemSubCategory, tmpSupplierName, tmpItemColor, tmpItemSize, tmpItemSizeRange, tmpMfgName As New DataTable
                        If M_CompanyWiseMiscMaster = "Yes" Then
                            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'ItemType'"
                            tmpItemtype = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'ItemCategory'"
                            tmpItemCategory = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'ItemSubCategory'"
                            tmpItemSubCategory = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'SupplierName'"
                            tmpSupplierName = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'ItemColor'"
                            tmpItemColor = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'ItemSize'"
                            tmpItemSize = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'ItemSizeRange'"
                            tmpItemSizeRange = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "CId = " & M_CId & " And MiscType = 'MfgName'"
                            tmpMfgName = dvMiscMaster.ToTable
                        Else
                            dvMiscMaster.RowFilter = "MiscType = 'ItemType'"
                            tmpItemtype = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "MiscType = 'ItemCategory'"
                            tmpItemCategory = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "MiscType = 'ItemSubCategory'"
                            tmpItemSubCategory = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "MiscType = 'SupplierName'"
                            tmpSupplierName = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "MiscType = 'ItemColor'"
                            tmpItemColor = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "MiscType = 'ItemSize'"
                            tmpItemSize = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "MiscType = 'ItemSizeRange'"
                            tmpItemSizeRange = dvMiscMaster.ToTable

                            dvMiscMaster.RowFilter = "MiscType = 'MfgName'"
                            tmpMfgName = dvMiscMaster.ToTable
                        End If

                        Dim line As String = reader.ReadLine()
                        Dim values As String() = line.Split(","c)


                        indx = Array.IndexOf(headers, "ItemType")
                        Dim IsFound As Boolean = False
                        For i As Integer = 0 To tmpItemtype.Rows.Count - 1
                            If tmpItemtype.Rows(i)("MiscName") = IIf(IsDBNull(values(indx)), "ItemType", values(indx)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemType", Trim(values(indx)))
                        End If

                        '===============
                        indx = Array.IndexOf(headers, "ItemCategory")
                        IsFound = False
                        For i As Integer = 0 To tmpItemCategory.Rows.Count - 1
                            If tmpItemCategory.Rows(i)("MiscName") = IIf(IsDBNull(values(indx)), "ItemCategory", values(indx)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemCategory", Trim(values(indx)))
                        End If

                        '===============

                        indx = Array.IndexOf(headers, "ItemSubCategory")
                        IsFound = False
                        For i As Integer = 0 To tmpItemSubCategory.Rows.Count - 1
                            If tmpItemSubCategory.Rows(i)("MiscName") = IIf(IsDBNull(values(indx)), "ItemSubCategory", values(indx)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemSubCategory", Trim(values(indx)))
                        End If

                        '===============

                        indx = Array.IndexOf(headers, "SupplierName")
                        IsFound = False
                        For i As Integer = 0 To tmpSupplierName.Rows.Count - 1
                            If tmpSupplierName.Rows(i)("MiscName") = IIf(IsDBNull(values(indx)), "SupplierName", values(indx)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("SupplierName", Trim(values(indx)))
                        End If

                        '===========

                        indx = Array.IndexOf(headers, "ItemSizeRange")
                        IsFound = False
                        For i As Integer = 0 To tmpItemSizeRange.Rows.Count - 1
                            If tmpItemSizeRange.Rows(i)("MiscName") = IIf(IsDBNull(values(indx)), "ItemSizeRange", values(indx)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemSizeRange", Trim(values(indx)))
                        End If

                        '===========

                        indx = Array.IndexOf(headers, "ItemSize")
                        IsFound = False
                        For i As Integer = 0 To tmpItemSize.Rows.Count - 1
                            If tmpItemSize.Rows(i)("MiscName") = IIf(IsDBNull(values(indx)), "ItemSize", values(indx)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemSize", Trim(values(indx)))
                        End If

                        '===============

                        indx = Array.IndexOf(headers, "ItemColor")
                        IsFound = False
                        For i As Integer = 0 To tmpItemColor.Rows.Count - 1
                            If tmpItemColor.Rows(i)("MiscName") = IIf(IsDBNull(values(indx)), "ItemColor", values(indx)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemColor", Trim(values(indx)))
                        End If

                        '===============

                        indx = Array.IndexOf(headers, "MfgName")
                        IsFound = False
                        For i As Integer = 0 To tmpMfgName.Rows.Count - 1
                            If tmpMfgName.Rows(i)("MiscName") = IIf(IsDBNull(values(indx)), "MfgName", values(indx)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("MfgName", Trim(values(indx)))
                        End If

                        loadMiscMaster()

                    End While
                    '============================================
                    allComboFill()

                    Dim reader1 As New StreamReader(ofd.FileName)
                    While Not reader1.EndOfStream
                        Dim line As String = reader1.ReadLine()
                        Dim values As String() = line.Split(","c)

                        indx = Array.IndexOf(headers, "BarCode")
                        gvData.Columns("BarCode").FilterInfo = New ColumnFilterInfo(IIf(IsDBNull(values(indx)), "", values(indx)))
                        If gvData.RowCount = 1 Then
                            gvData.FocusedRowHandle = 0
                            fillData()
                            editClickTime()
                        Else
                            btnCancel.PerformClick()
                            btnAdd.PerformClick()

                            indx = Array.IndexOf(headers, "TItemCode")
                            txtTItemCode.Text = IIf(IsDBNull(values(indx)), "TItemCode", values(indx))

                            indx = Array.IndexOf(headers, "BarCode")
                            txtBarcode.Text = IIf(IsDBNull(values(indx)), "BarCode", values(indx))

                            indx = Array.IndexOf(headers, "TItemName")
                            txtTItemName.Text = IIf(IsDBNull(values(indx)), "TItemName", values(indx))

                            indx = Array.IndexOf(headers, "TItemName1")
                            txtTItemName1.Text = IIf(IsDBNull(values(indx)), "TItemName1", values(indx))

                            indx = Array.IndexOf(headers, "PurchaseRate")
                            txtPurchaseRate.Text = IIf(IsDBNull(values(indx)), "PurchaseRate", values(indx))

                            indx = Array.IndexOf(headers, "UOM")
                            cmbUOM.Text = IIf(IsDBNull(values(indx)), "UOM", values(indx))

                            indx = Array.IndexOf(headers, "PurchaseDiscPer")
                            txtPurchaseDiscPer.Text = IIf(IsDBNull(values(indx)), "PurchaseDiscPer", values(indx))

                            indx = Array.IndexOf(headers, "SalesRate")
                            txtSalesRate.Text = IIf(IsDBNull(values(indx)), "SalesRate", values(indx))

                            indx = Array.IndexOf(headers, "SalesRateA")
                            txtSalesRateA.Text = IIf(IsDBNull(values(indx)), "SalesRateA", values(indx))

                            indx = Array.IndexOf(headers, "MRP")
                            txtMRP.Text = IIf(IsDBNull(values(indx)), "MRP", values(indx))

                            indx = Array.IndexOf(headers, "SalesDiscPer")
                            txtSalesDiscPer.Text = IIf(IsDBNull(values(indx)), "SalesDiscPer", values(indx))

                            indx = Array.IndexOf(headers, "HSNCode")
                            txtHSNCode.Text = IIf(IsDBNull(values(indx)), "HSNCode", values(indx))

                            indx = Array.IndexOf(headers, "TaxPer")
                            txtTaxPer.Text = IIf(IsDBNull(values(indx)), "TaxPer", values(indx))
                            '=====
                            indx = Array.IndexOf(headers, "ItemType")
                            cmbItemType.Text = IIf(IsDBNull(values(indx)), "ItemType", values(indx))
                            '=====
                            indx = Array.IndexOf(headers, "ItemCategory")
                            cmbItemCategory.Text = IIf(IsDBNull(values(indx)), "ItemCategory", values(indx))
                            '====
                            indx = Array.IndexOf(headers, "ItemSubCategory")
                            cmbItemSubCategory.Text = IIf(IsDBNull(values(indx)), "ItemSubCategory", values(indx))
                            '=====
                            indx = Array.IndexOf(headers, "MfgName")
                            cmbMfgName.Text = IIf(IsDBNull(values(indx)), "MfgName", values(indx))
                            '=====
                            indx = Array.IndexOf(headers, "SupplierName")
                            cmbSupplierName.Text = IIf(IsDBNull(values(indx)), "SupplierName", values(indx))

                            indx = Array.IndexOf(headers, "ItemSize")
                            cmbItemSize.Text = IIf(IsDBNull(values(indx)), "ItemSize", values(indx))

                            indx = Array.IndexOf(headers, "ItemSizeRange")
                            cmbItemSizeRange.Text = IIf(IsDBNull(values(indx)), "ItemSizeRange", values(indx))

                            indx = Array.IndexOf(headers, "DesignNo")
                            txtDesignNo.Text = IIf(IsDBNull(values(indx)), "DesignNo", values(indx))

                            indx = Array.IndexOf(headers, "Location")
                            txtLocation.Text = IIf(IsDBNull(values(indx)), "Location", values(indx))

                            indx = Array.IndexOf(headers, "CommissionPer")
                            txtCommissionPer.Text = IIf(IsDBNull(values(indx)), "CommissionPer", values(indx))

                            indx = Array.IndexOf(headers, "CommissionAmt")
                            txtCommissionAmt.Text = IIf(IsDBNull(values(indx)), "CommissionAmt", values(indx))

                            indx = Array.IndexOf(headers, "ItemColor")
                            cmbItemColor.Text = IIf(IsDBNull(values(indx)), "ItemColor", values(indx))

                            indx = Array.IndexOf(headers, "CatalogName")
                            txtCatalogName.Text = IIf(IsDBNull(values(indx)), "CatalogName", values(indx))

                            indx = Array.IndexOf(headers, "IsActive")
                            If values(indx).ToLower = "true" Or values(indx).ToLower = "yes" Then
                                chkIsActive.Checked = True
                            Else
                                chkIsActive.Checked = False
                            End If
                            'chkIsActive.Checked = IIf(IsDBNull(values(indx)), "IsActive", values(indx))

                            indx = Array.IndexOf(headers, "ManageStock")
                            If values(indx).ToLower = "true" Or values(indx).ToLower = "yes" Then
                                chkManageStock.Checked = True
                            Else
                                chkManageStock.Checked = False
                            End If
                            'chkManageStock.Checked = IIf(IsDBNull(values(indx)), "ManageStock", values(indx))

                            indx = Array.IndexOf(headers, "OpStk")
                            txtOpStk.Text = IIf(IsDBNull(values(indx)), "OpStk", values(indx))

                            indx = Array.IndexOf(headers, "OpStkValue")
                            txtValue.Text = IIf(IsDBNull(values(indx)), "OpStkValue", values(indx))

                            indx = Array.IndexOf(headers, "ReOrderLevel")
                            txtReorderLevel.Text = IIf(IsDBNull(values(indx)), "ReOrderLevel", values(indx))

                            btnSave.PerformClick()
                        End If
                    End While
                    SplashScreenManager.CloseForm()
                    MsgBox("Data Saved Successfully", MsgBoxStyle.Information)
                    cancelClickTime()
                    gvData.ClearColumnsFilter()

                    gridfill2024()
                End Using
            End If
        End If
    End Sub

    Public Sub ValidationFillCombo(ByVal cmb As ComboBox, ByVal _MiscType As String, ByVal ds As DataSet)
        ds.Clear()
        If M_CompanyWiseMiscMaster = "Yes" Then
            sql_query = "Select * From tbl_MiscMaster Where MiscType = '" & _MiscType & "' And CId = " & M_CId
        Else
            sql_query = "Select * From tbl_MiscMaster Where MiscType = '" & _MiscType & "'"
        End If
        obj.LoadData(sql_query, ds)
        cmb.DataSource = ds.Tables(0).DefaultView
    End Sub

    Public Sub UploadItemData()
        Dim dsItem As New Data.DataSet
        Dim dt As New DataTable
        'GridToDataset(dsItem, dt)

        '============= Check ComboFill Validation =================
        SplashScreenManager.CloseForm(False)
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Check Item Data")
        Dim tmpItemtype, tmpItemCategory, tmpItemSubCategory, tmpSupplierName, tmpItemColor, tmpItemSize, tmpItemSizeRange, tmpMfgName As New DataSet
        ValidationFillCombo(cmbItemType, "ItemType", tmpItemtype)
        ValidationFillCombo(cmbItemCategory, "ItemCategory", tmpItemCategory)
        ValidationFillCombo(cmbItemSubCategory, "ItemSubCategory", tmpItemSubCategory)
        ValidationFillCombo(cmbSupplierName, "SupplierName", tmpSupplierName)
        ValidationFillCombo(cmbItemColor, "ItemColor", tmpItemColor)
        ValidationFillCombo(cmbItemSize, "ItemSize", tmpItemSize)
        ValidationFillCombo(cmbItemSizeRange, "ItemSizeRange", tmpItemSizeRange)
        ValidationFillCombo(cmbMfgName, "MfgName", tmpMfgName)

        For i As Integer = 0 To dsItem.Tables(0).Rows.Count - 1

            For Each column In dsItem.Tables(0).Columns
                Dim columnName As String = column.ColumnName.Trim().ToLower()
                Select Case columnName
                    Case "titemname", "itemname"
                        If Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)) = "" Then
                            MsgBox("Please Enter ItemName Of BarCode = " & Trim(dsItem.Tables(0).Rows(i)("BarCode")))
                            Exit Sub
                        End If
                        Exit Select
                    Case "itemtype", "producttype"
                        Dim IsFound As Boolean = False
                        For j As Integer = 0 To tmpItemtype.Tables(0).Rows.Count - 1
                            If UCase(tmpItemtype.Tables(0).Rows(j)("MiscName")) = UCase(dsItem.Tables(0).Rows(i)(column.ColumnName)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemType", Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)))
                            ValidationFillCombo(cmbItemType, "ItemType", tmpItemtype)
                        End If
                        Exit Select
                    Case "itemcategory", "category"
                        Dim IsFound As Boolean = False
                        For j As Integer = 0 To tmpItemCategory.Tables(0).Rows.Count - 1
                            If UCase(tmpItemCategory.Tables(0).Rows(j)("MiscName")) = UCase(dsItem.Tables(0).Rows(i)(column.ColumnName)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemCategory", Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)))
                            ValidationFillCombo(cmbItemCategory, "ItemCategory", tmpItemCategory)
                        End If
                        Exit Select
                    Case "itemsubcategory", "subcategory"
                        Dim IsFound As Boolean = False
                        For j As Integer = 0 To tmpItemSubCategory.Tables(0).Rows.Count - 1
                            If UCase(tmpItemSubCategory.Tables(0).Rows(j)("MiscName")) = UCase(dsItem.Tables(0).Rows(i)(column.ColumnName)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemSubCategory", Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)))
                            ValidationFillCombo(cmbItemSubCategory, "ItemSubCategory", tmpItemSubCategory)
                        End If
                        Exit Select
                    Case "suppliername"
                        Dim IsFound As Boolean = False
                        For j As Integer = 0 To tmpSupplierName.Tables(0).Rows.Count - 1
                            If UCase(tmpSupplierName.Tables(0).Rows(j)("MiscName")) = UCase(dsItem.Tables(0).Rows(i)(column.ColumnName)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("SupplierName", Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)))
                            ValidationFillCombo(cmbSupplierName, "SupplierName", tmpSupplierName)
                        End If
                        Exit Select
                    Case "itemcolor", "color"
                        Dim IsFound As Boolean = False
                        For j As Integer = 0 To tmpItemColor.Tables(0).Rows.Count - 1
                            If UCase(tmpItemColor.Tables(0).Rows(j)("MiscName")) = UCase(dsItem.Tables(0).Rows(i)(column.ColumnName)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemColor", Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)))
                            ValidationFillCombo(cmbItemColor, "ItemColor", tmpItemColor)
                        End If
                        Exit Select
                    Case "itemsize", "size"
                        Dim IsFound As Boolean = False
                        For j As Integer = 0 To tmpItemSize.Tables(0).Rows.Count - 1
                            If UCase(tmpItemSize.Tables(0).Rows(j)("MiscName")) = UCase(dsItem.Tables(0).Rows(i)(column.ColumnName)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemSize", Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)))
                            ValidationFillCombo(cmbItemSize, "ItemSize", tmpItemSize)
                        End If
                        Exit Select
                    Case "itemsizerange", "sizerange"
                        Dim IsFound As Boolean = False
                        For j As Integer = 0 To tmpItemSizeRange.Tables(0).Rows.Count - 1
                            If UCase(tmpItemSizeRange.Tables(0).Rows(j)("MiscName")) = UCase(dsItem.Tables(0).Rows(i)(column.ColumnName)) Then
                                IsFound = True
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("ItemSizeRange", Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)))
                            ValidationFillCombo(cmbItemSizeRange, "ItemSizeRange", tmpItemSizeRange)
                        End If
                        Exit Select
                    Case "mfgname"
                        Dim IsFound As Boolean = False
                        For j As Integer = 0 To tmpMfgName.Tables(0).Rows.Count - 1
                            If UCase(tmpMfgName.Tables(0).Rows(j)("MiscName")) = UCase(dsItem.Tables(0).Rows(i)(column.ColumnName)) Then
                                IsFound = True
                                Exit Select
                            End If
                        Next
                        If IsFound = False Then
                            insertMiscMaster("MfgName", Trim(dsItem.Tables(0).Rows(i)(column.ColumnName)))
                            ValidationFillCombo(cmbMfgName, "MfgName", tmpMfgName)
                        End If
                        Exit Select
                End Select
            Next
        Next
        '====================== Upload Item  =====================
        SplashScreenManager.Default.SetWaitFormDescription("Upload Item Data")
        For j As Integer = 0 To dsItem.Tables(0).Rows.Count - 1

            gvData.Columns("BarCode").FilterInfo = New ColumnFilterInfo("[BarCode] = " & Trim(dsItem.Tables(0).Rows(j)("BarCode")))
            If gvData.RowCount = 1 Then
                gvData.FocusedRowHandle = 0
                fillData()
                editClickTime()
            Else
                btnCancel.PerformClick()
                btnAdd.PerformClick()
            End If

            For Each column In dsItem.Tables(0).Columns
                Dim columnName As String = column.ColumnName.Trim().ToLower()
                Select Case columnName
                    Case "titemcode", "code"
                        txtTItemCode.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "barcodetype"
                        cmbBarcodeType.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "barcode"
                        txtBarcode.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "titemname"
                        txtTItemName.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "titemname1"
                        txtTItemName1.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "purchaserate"
                        txtPurchaseRate.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "uom"
                        cmbUOM.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "purchasediscper"
                        txtPurchaseDiscPer.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "salesrate"
                        txtSalesRate.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "salesratea"
                        txtSalesRateA.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "mrp"
                        txtMRP.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "salesdiscper"
                        txtSalesDiscPer.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "hsncode"
                        txtHSNCode.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "taxper"
                        txtTaxPer.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "itemtype"
                        cmbItemType.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "itemcategory"
                        cmbItemCategory.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "itemsubcategory"
                        cmbItemSubCategory.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "mfgname"
                        cmbMfgName.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "suppliername"
                        cmbSupplierName.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "itemsize"
                        cmbItemSize.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "itemsizeRange"
                        cmbItemSizeRange.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "designno"
                        txtDesignNo.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "location"
                        txtLocation.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "commissionper"
                        txtCommissionPer.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "commissionamt"
                        txtCommissionAmt.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "itemcolor", "color"
                        cmbItemColor.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "catalogname"
                        txtCatalogName.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "isactive"
                        If Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)) = "True" Or Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)) = "Yes" Then
                            chkIsActive.Checked = True
                        Else
                            chkIsActive.Checked = False
                        End If
                    Case "managestock"
                        If Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)) = "True" Or Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)) = "Yes" Then
                            chkManageStock.Checked = True
                        Else
                            chkManageStock.Checked = False
                        End If
                        Exit Select
                    Case "opstk"
                        txtOpStk.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "opstkvalue"
                        txtValue.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                    Case "reorderlevel"
                        txtReorderLevel.Text = IIf(IsDBNull(Trim(dsItem.Tables(0).Rows(j)(column.ColumnName))), "", Trim(dsItem.Tables(0).Rows(j)(column.ColumnName)))
                        Exit Select
                End Select
            Next

            btnSave.PerformClick()
            gvData.ClearColumnsFilter()
        Next
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        'ProcessCSVFile()
        M_GridToExcel = "UploadFabricItem"
        'frmGridToExcel.Show()
        'frmGridToExcel.Activate()
        Exit Sub


        'MsgBox("Please Verify Below Things:" & vbCrLf _
        '    & "1. Excel File Template Is Exported from Software" & vbCrLf _
        '    & "2. No Columns Removed or Hide" & vbCrLf _
        '    & "3. Data Maintained In Sheet1" & vbCrLf _
        '    & "4. Field Values Are In Proper & Valid Format" & vbCrLf _
        '    & "5. Empty Columns and Rows Removed from Sheet" & vbCrLf _
        '    & "------------------------------------------------------" & vbCrLf _
        '    & "ADD ITEM: 0 Required In First Column" & vbCrLf _
        '    & "UPDATE ITEM: > 0 In First Column & It's Value Must Not Be Changed)", MsgBoxStyle.Information)

        Dim dr As DialogResult
        dr = MsgBox("Sure To Perform Add/Update Operation on Item Master Data?" & vbCrLf & "We Cannot Fetch Old Data After Data Updated", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            uploadType = "UploadItem"

            OpenFileDialog1.Filter = "Excel-2007 Files|*.xlsx|Excel-2003 Files|*.xls"
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.ShowDialog()
        End If
    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTItemName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmbItemCategory_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbItemCategory.Validating
        Select Case UCase(cmbItemCategory.Text)
            Case "READYMADE"
                cmbUOM.Text = "Pcs"
                txtTaxPer.Text = 12
                Exit Select
            Case "FABRIC"
                cmbUOM.Text = "Mtr"
                txtTaxPer.Text = 5
                Exit Select
        End Select
    End Sub

    Private Sub txtItemName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTItemName.Validating
        If M_DbName = "dbSTE_KFL2024" Then
            If edit_ins = 1 Then
                sql_query = "Select Top 1 SalesRate FROM tbl_TItemMaster Where TItemName = '" & Trim(txtTItemName.Text) & "' And CId = " & M_CId & " Order By TItemId Desc"
                txtSalesRate.Text = obj.ScalarExecute(sql_query)

                sql_query = "Select Top 1 UOM FROM tbl_TItemMaster Where TItemName = '" & Trim(txtTItemName.Text) & "' And CId = " & M_CId & " Order By TItemId Desc"
                cmbUOM.Text = obj.ScalarExecute(sql_query)
            End If
        End If
    End Sub

    Private Sub CheckAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckAllToolStripMenuItem.Click
        For i As Integer = 0 To gvData.RowCount - 1
            gvData.SetRowCellValue(i, "YN", True)
        Next
    End Sub

    Private Sub UncheckAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UncheckAllToolStripMenuItem.Click
        For i As Integer = 0 To gvData.RowCount - 1
            gvData.SetRowCellValue(i, "YN", False)
        Next
    End Sub

    Private Sub btnUpdateRates_Click(sender As Object, e As EventArgs) Handles btnUpdateRates.Click
        Select Case M_DbName
            Case "dbSTE_HTF"
                sql_query = "Delete From tbl_RackWiseRate Where ItemColor = '" & txtBarcode.Text & "'"
                obj.QueryExecute(sql_query)

                For i As Integer = 0 To gvDetail.RowCount - 1
                    obj.Prepare("SP_InsertRackWiseRate", SpType.StoredProcedure)
                    obj.AddCmdParameter("@InsTItemId", Dtype.int, Val(gvDetail.GetRowCellValue(i, "TItemId")), ParaDirection.Input, True)
                    obj.AddCmdParameter("@InsItemColor", Dtype.nvarchar, txtBarcode.Text, ParaDirection.Input, True)
                    obj.AddCmdParameter("@InsRackPrice", Dtype.float, Val(gvDetail.GetRowCellValue(i, "RackPrice")), ParaDirection.Input, True)
                    obj.AddCmdParameter("@InsDiscPer", Dtype.float, Val(gvDetail.GetRowCellValue(i, "DiscPer")), ParaDirection.Input, True)
                    obj.ExecuteCommand()
                Next

                MsgBox("Rates Updated Successfully", MsgBoxStyle.Information)
                Exit Select
        End Select
    End Sub

    Private Sub btnPrintItemBarcodes_Click(sender As Object, e As EventArgs) Handles btnPrintItemBarcodes.Click
        'prepare_ItemBarcodes(False, False)
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Select Case uploadType
            Case "UploadItem"
                uploadItemFromExcel()
                Exit Select
            Case "UpdateItemInfo"
                updateItemInfo()
                Exit Select
            Case "UploadOpStk"
                uploadOpStk()
                Exit Select
        End Select
    End Sub

    Public Sub uploadItemFromExcel()
        Dim ds_Excel As New Data.DataSet
        ds_Excel.Clear()
        obj.LoadData_Excel("SELECT * FROM [Sheet1$]", ds_Excel, "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & OpenFileDialog1.FileName & "; Extended Properties=""Excel 8.0; HDR=Yes; IMEX=1""")

        Dim cnt As Integer = 0

        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Check Item Name")

        If ds_Excel.Tables(0).Select("isnull(TItemName,'') = ''", "").Count() > 0 Then
            MsgBox("Item Name Not Found In " & ds_Excel.Tables(0).Select("isnull(TItemName,'') = ''", "").Count() & " Records", MsgBoxStyle.Information)
            SplashScreenManager.CloseForm()
            Exit Sub
        End If

        SplashScreenManager.Default.SetWaitFormDescription("Check Barcode")

        SplashScreenManager.Default.SetWaitFormDescription("Check Item Type")
        For i As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
            sql_query = "select count(0) from tbl_MiscMaster where MiscType = 'ItemType' And MiscName = '" & Trim(ds_Excel.Tables(0).Rows(i)("ItemType")).Replace("'", "''") & "'"
            If obj.ScalarExecute(sql_query) <= 0 Then
                insertMiscMaster("ItemType", Trim(ds_Excel.Tables(0).Rows(i)("ItemType")))
                cnt = cnt + 1
            End If
        Next

        SplashScreenManager.Default.SetWaitFormDescription("Check Item Category")
        For i As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
            sql_query = "select count(0) from tbl_MiscMaster where MiscType = 'ItemCategory' And MiscName = '" & Trim(ds_Excel.Tables(0).Rows(i)("ItemCategory")).Replace("'", "''") & "'"
            If obj.ScalarExecute(sql_query) <= 0 Then
                insertMiscMaster("ItemCategory", Trim(ds_Excel.Tables(0).Rows(i)("ItemCategory")))
                cnt = cnt + 1
            End If
        Next

        SplashScreenManager.Default.SetWaitFormDescription("Check Item MfgName")
        For i As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
            sql_query = "select count(0) from tbl_MiscMaster where MiscType = 'MfgName' and  MiscName = '" & Trim(ds_Excel.Tables(0).Rows(i)("MfgName")).Replace("'", "''") & "'"
            If obj.ScalarExecute(sql_query) <= 0 Then
                insertMiscMaster("MfgName", Trim(ds_Excel.Tables(0).Rows(i)("MfgName")))
                cnt = cnt + 1
            End If
        Next

        SplashScreenManager.Default.SetWaitFormDescription("Check Item Size")
        For i As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
            'sql_query = "select count(0) from tbl_TItemMaster where ItemSize = '" & Trim(ds_Excel.Tables(0).Rows(i)("ItemSize")) & "'"
            sql_query = "select count(0) from tbl_MiscMaster where MiscType = 'ItemSize' and MiscName = '" & Trim(ds_Excel.Tables(0).Rows(i)("ItemSize")).Replace("'", "''") & "'"
            If obj.ScalarExecute(sql_query) <= 0 Then
                insertMiscMaster("ItemSize", Trim(ds_Excel.Tables(0).Rows(i)("ItemSize")))
                cnt = cnt + 1
            End If
        Next

        SplashScreenManager.Default.SetWaitFormDescription("Check Item Color")
        For i As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
            sql_query = "select count(0) from tbl_MiscMaster where MiscType = 'ItemColor' and MiscName = '" & Trim(ds_Excel.Tables(0).Rows(i)("ItemColor")).Replace("'", "''") & "'"
            If obj.ScalarExecute(sql_query) <= 0 Then
                insertMiscMaster("ItemColor", Trim(ds_Excel.Tables(0).Rows(i)("ItemColor")))
                cnt = cnt + 1
            End If
        Next

        If cnt > 0 Then
            allComboFill()
        End If

        Dim newRecords As Integer = 0
        Dim upRecords As Integer = 0

        Try
            SplashScreenManager.Default.SetWaitFormDescription("Uploading Data")
            For i As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
                uploadExcel = True

                btnAdd.PerformClick()
                edit_ins = 1
                lblTItemId.Text = 0
                txtTItemCode.Text = IIf(ds_Excel.Tables(0).Rows(i)("TItemCode") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("TItemCode"))
                txtBarcode.Text = IIf(ds_Excel.Tables(0).Rows(i)("Barcode") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("Barcode"))

                If txtBarcode.Text = "" Then
                    If M_DbName = "dbSTE_KFL2024" Then
                        'sql_query = "Select IsNull(Max(CONVERT(float, Barcode)),0) + 1 From Tbl_TItemMaster Where Barcode NOT LIKE '%[A-Za-z]%' And CONVERT(float, Barcode) < 100000"
                        sql_query = "Select IsNull(Max(CONVERT(float, Barcode)),0) + 1 From Tbl_TItemMaster Where ISNUMERIC(barcode) = 1 And CONVERT(float, Barcode) < 100000"
                        txtBarcode.Text = obj.ScalarExecute(sql_query)
                    Else
                        Select Case M_BarcodeCreation
                            Case "Item Master"
                                sql_query = "Select IsNull(Max(CONVERT(float, Barcode)),0) + 1 From Tbl_TItemMaster Where CId = " & M_CId & " And Barcode NOT LIKE '%[A-Za-z]%'"
                                txtBarcode.Text = obj.ScalarExecute(sql_query)
                        End Select
                    End If
                End If

                txtTItemName.Text = IIf(ds_Excel.Tables(0).Rows(i)("TItemName") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("TItemName"))
                txtTItemName1.Text = IIf(ds_Excel.Tables(0).Rows(i)("TItemName1") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("TItemName1"))
                cmbItemType.Text = IIf(ds_Excel.Tables(0).Rows(i)("ItemType") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("ItemType"))
                cmbItemCategory.Text = IIf(ds_Excel.Tables(0).Rows(i)("ItemCategory") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("ItemCategory"))
                cmbMfgName.Text = IIf(ds_Excel.Tables(0).Rows(i)("MfgName") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("MfgName"))
                cmbItemSize.Text = IIf(ds_Excel.Tables(0).Rows(i)("ItemSize") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("ItemSize"))
                cmbItemColor.Text = IIf(ds_Excel.Tables(0).Rows(i)("ItemColor") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("ItemColor"))
                txtSalesRate.Text = IIf(ds_Excel.Tables(0).Rows(i)("SalesRate") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("SalesRate"))
                cmbUOM.Text = IIf(ds_Excel.Tables(0).Rows(i)("UOM") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("UOM"))
                txtPurchaseRate.Text = IIf(ds_Excel.Tables(0).Rows(i)("PurchaseRate") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("PurchaseRate"))
                txtHSNCode.Text = IIf(ds_Excel.Tables(0).Rows(i)("HSNCode") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("HSNCode"))
                txtTaxPer.Text = IIf(ds_Excel.Tables(0).Rows(i)("TaxPer") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("TaxPer"))
                txtOpStk.Text = IIf(ds_Excel.Tables(0).Rows(i)("OpStk") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("OpStk"))
                txtValue.Text = IIf(ds_Excel.Tables(0).Rows(i)("StockValue") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("StockValue"))
                txtReorderLevel.Text = IIf(ds_Excel.Tables(0).Rows(i)("ReOrderLevel") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("ReOrderLevel"))
                txtDesignNo.Text = IIf(ds_Excel.Tables(0).Rows(i)("DesignNo") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("DesignNo"))
                txtCatalogName.Text = IIf(ds_Excel.Tables(0).Rows(i)("CatalogName") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("CatalogName"))
                txtLocation.Text = IIf(ds_Excel.Tables(0).Rows(i)("Location") Is DBNull.Value, "", ds_Excel.Tables(0).Rows(i)("Location"))

                If Not ds_Excel.Tables(0).Rows(i)("Barcode") Is DBNull.Value Then
                    txtBarcode.Text = ds_Excel.Tables(0).Rows(i)("Barcode")
                End If

                btnSave.PerformClick()

                newRecords = newRecords + 1
            Next

            SplashScreenManager.CloseForm()
        Catch ex As Exception
            MsgBox(ex.Message)
            uploadExcel = False
            SplashScreenManager.CloseForm()
        End Try

        uploadExcel = False

        MsgBox("Data Processed Successfully" & vbCrLf & "New Records: " & newRecords, MsgBoxStyle.Information)
    End Sub

    Public Sub uploadOpStk()
        Dim ds_Excel As New Data.DataSet
        ds_Excel.Clear()
        obj.LoadData_Excel("SELECT * FROM [Sheet1$]", ds_Excel, "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & OpenFileDialog1.FileName & "; Extended Properties=""Excel 8.0; HDR=Yes; IMEX=1""")

        If ds_Excel.Tables(0).Rows.Count > 0 Then
            SplashScreenManager.ShowForm(GetType(WaitForm1))
            For r As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
                SplashScreenManager.Default.SetWaitFormDescription("Update Data For TItemId = " & ds_Excel.Tables(0).Rows(r)("ItemId"))

                sql_query = "Delete From tbl_OpeningStock Where ItemId = " & ds_Excel.Tables(0).Rows(r)("ItemId") & " And FinYrId = " & M_StockYrId 'FrmMDIMain.cmbFinYr.SelectedValue
                obj.QueryExecute(sql_query)

                sql_query = "Insert Into tbl_OpeningStock (ItemId, FinYrId, OpStk, Rate, Value) Values(" & ds_Excel.Tables(0).Rows(r)("ItemId") & ", " & M_StockYrId & ", " & ds_Excel.Tables(0).Rows(r)("OpStk") & ", " & ds_Excel.Tables(0).Rows(r)("Rate") & ", " & ds_Excel.Tables(0).Rows(r)("Value") & ")"
                obj.QueryExecute(sql_query)
            Next
            SplashScreenManager.CloseForm()
        End If
    End Sub

    Public Sub updateItemInfo()
        Dim ds_Excel As New Data.DataSet
        ds_Excel.Clear()
        obj.LoadData_Excel("SELECT * FROM [Sheet1$]", ds_Excel, "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & OpenFileDialog1.FileName & "; Extended Properties=""Excel 8.0; HDR=Yes; IMEX=1""")

        If ds_Excel.Tables(0).Rows.Count > 0 Then
            SplashScreenManager.ShowForm(GetType(WaitForm1))
            For r As Integer = 0 To ds_Excel.Tables(0).Rows.Count - 1
                SplashScreenManager.Default.SetWaitFormDescription("Update Data For TItemId = " & ds_Excel.Tables(0).Rows(r)("TItemId"))
                Dim wc As String = "TItemId = '" & ds_Excel.Tables(0).Rows(r)("TItemId") & "'"
                For c As Integer = 0 To ds_Excel.Tables(0).Columns.Count - 1
                    If c = 0 Then
                        ' Skip
                    Else
                        sql_query = "update tbl_TItemMaster set " & ds_Excel.Tables(0).Columns(c).ColumnName & " = '" & ds_Excel.Tables(0).Rows(r)(c) & "'" _
                                    & " where " & wc
                        obj.QueryExecute(sql_query)
                    End If
                Next
            Next
            SplashScreenManager.CloseForm()
        End If
        loadItemMaster()
        gridfill2024()
    End Sub

    Private Sub SaveLayoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveLayoutToolStripMenuItem.Click
        SaveLayout(gvData, "Sales_Item_Master_Grid", Me)
    End Sub

    Private Sub DownloadTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadTemplateToolStripMenuItem.Click
        If File.Exists(Application.StartupPath & "\ExcelTemplate\SalesItemUpload_Template.xlsx") Then
            If MessageBox.Show("Sure To Download Template", "Sales Template", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim sfd As New SaveFileDialog()
                If sfd.ShowDialog() = DialogResult.OK Then
                    File.Copy(Application.StartupPath & "\ExcelTemplate\SalesItemUpload_Template.xlsx", sfd.FileName & ".xlsx", True)
                End If
            End If
        Else
            MsgBox("Template Not Found, Please Contact To Service Provider")
        End If

    End Sub

    Private Sub SelectSubItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectSubItemsToolStripMenuItem.Click
        Try
            If gvData.FocusedRowHandle < 0 Then
                MsgBox("Please Select Proper Record.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If Val(lblTItemId.Text) <= 0 Then
                MsgBox("Please Select Proper Record.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Dim frmHelpSI As New FrmHelpSubItem(gvData.GetFocusedRowCellValue("TItemId"), "Tailoring")
            'frmHelpSI.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RenameColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameColumnToolStripMenuItem.Click
        gvData.FocusedColumn.Caption = InputBox("Column Header Text", "Field Name", gvData.FocusedColumn.FieldName)
    End Sub

    Private Sub UpdateItemInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateItemInfoToolStripMenuItem.Click
        uploadType = "UpdateItemInfo"

        OpenFileDialog1.Filter = "Excel-2007 Files|*.xlsx|Excel-2003 Files|*.xls"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub UploadOpeningStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadOpeningStockToolStripMenuItem.Click
        uploadType = "UploadOpStk"

        OpenFileDialog1.Filter = "Excel-2007 Files|*.xlsx|Excel-2003 Files|*.xls"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub cmbUOM_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbUOM.Validating
        Select Case UCase(cmbUOM.Text)
            Case "MTR", "METER"
                Dim dr As DialogResult
                dr = MsgBox("Generate Barcode Purchase Time ?", MsgBoxStyle.YesNo)
                If dr = Windows.Forms.DialogResult.Yes Then
                    cmbBarcodeType.Text = "Purchase Time"
                End If
                Exit Select
        End Select
    End Sub

    Private Sub cmbBarcodeType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbBarcodeType.Validating
        If edit_ins = 1 Then
            Select Case cmbBarcodeType.Text
                Case "Item Master"
                    If M_DbName = "dbSTE_KFL2024" Then
                        'sql_query = "Select IsNull(Max(CONVERT(float, Barcode)),0) + 1 From Tbl_TItemMaster Where BarcodeType = '" & cmbBarcodeType.Text & "' And Barcode NOT LIKE '%[A-Za-z]%' And CONVERT(float, Barcode) < 100000"
                        sql_query = "Select IsNull(Max(CONVERT(float, Barcode)),0) + 1 From Tbl_TItemMaster Where BarcodeType = '" & cmbBarcodeType.Text & "' And ISNUMERIC(barcode) = 1 And CONVERT(float, Barcode) < 100000"
                        txtBarcode.Text = obj.ScalarExecute(sql_query)
                    Else
                        sql_query = "Select IsNull(Max(CONVERT(float, Barcode)),0) + 1 From Tbl_TItemMaster Where BarcodeType = '" & cmbBarcodeType.Text & "' And CId = " & M_CId & " And Barcode NOT LIKE '%[A-Za-z]%'"
                        txtBarcode.Text = obj.ScalarExecute(sql_query)
                    End If
            End Select
        End If
    End Sub

    Private Sub btnRemoveImg_Click(sender As Object, e As EventArgs) Handles btnRemoveImg.Click
        pbImg.Image = Nothing
        txtImgPath.Clear()
    End Sub

    'Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
    '    M_callingForm_WebcamImageCap = "FrmSalesItemMaster"
    '    FrmWebCamImageCap.ShowDialog()
    'End Sub

    'Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
    '    FrmHelpPreviewImage.pbPreviewImg.Image = pbImg.Image
    '    FrmHelpPreviewImage.ShowDialog()
    'End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim dr As DialogResult
        dr = MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            pbImg.Image = Nothing
            txtImgPath.Text = ""
        End If
    End Sub

    Private Sub txtSalesRate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSalesRate.Validating
        If Val(txtSalesRateA.Text) = 0 Then
            txtSalesRateA.Text = txtSalesRate.Text
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        For i As Integer = 0 To gvDetail.RowCount - 1
            gvDetail.SetRowCellValue(i, "YN", True)
        Next
    End Sub

    Private Sub UISettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UISettingToolStripMenuItem.Click
        M_callingForm_UISettingHelp = "FrmTailoringItemMaster"
        'FrmUISettings.ShowDialog()
    End Sub

    Private Sub gbMainDetail_Enter(sender As Object, e As EventArgs) Handles gbMainDetail.Enter

    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        For i As Integer = 0 To gvDetail.RowCount - 1
            gvDetail.SetRowCellValue(i, "YN", False)
        Next
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim sfd As New SaveFileDialog

        If sfd.ShowDialog() = DialogResult.OK Then
            gvDetail.ExportToXlsx(sfd.FileName & ".xlsx")
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        SaveLayout(gvDetail, "Sales_Item_Master_DetailGrid", Me)
    End Sub

    ' Handle when something is dragged over the TextBox
    Private Sub txtImgPath_DragEnter(sender As Object, e As Windows.Forms.DragEventArgs) Handles txtImgPath.DragEnter
        ' Check if the data contains file(s)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ' Handle when something is dropped
    Private Sub txtImgPath_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles txtImgPath.DragDrop
        ' Get the files dropped
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        ' Show first file path in TextBox
        If files.Length > 0 Then
            txtImgPath.Text = files(0)
            pbImg.ImageLocation = txtImgPath.Text
        End If

    End Sub

#End Region

End Class
