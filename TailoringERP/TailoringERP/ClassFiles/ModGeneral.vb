Imports System.Net
Imports System.IO
Imports Sunrise.TailoringERP.DB
Imports System.Web
Imports System.Text
Imports notificationDll
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text.RegularExpressions
Imports System.Net.NetworkInformation
Imports DevExpress.XtraSplashScreen
Imports System.Net.Mail
Imports System.Threading
Imports System.Data.SqlClient
Imports TailoringERP.TailoringERP.DB
Imports RestSharp.Extensions.MonoHttp

Module ModGeneral
    '
#Region "Declaration"

    '==================================================================

    Public M_SoftType As String = "ERP"
    Public M_BusinessType As String
    Public M_OnlyCustomerManagement As String = ""
    'Public M_LightVersion As String = "YES"
    'Public M_LightVersion As String = "NO"

    'Public M_IsDemoSetup As Boolean = True
    'Public M_IsDemoSetup As Boolean = False

    'Public M_IsPaymentPending As Boolean = True
    'Public M_IsPaymentPending As Boolean = False

    'Public M_UserWiseCompany As Boolean = True 'ALLWIN
    Public M_UserWiseCompany As Boolean = False

    'Public M_MacIPWiseLogin As Boolean = True
    Public M_MacIPWiseLogin As Boolean = False

    Dim sql_query As String
    Dim obj As New DBManager
    Public ConStr As String
    Public M_DbName As String

    'Public pwd As String = "Ss.d@2017"
    Public pwd As String = "SunriseDb@2025"
    Public DbFileNo As Integer
    'Public pwd As String = "123456789" kora
    'Public pwd As String = "Admin@123" 'MUKUND
    'Public pwd As String = "Demo@12345"
    'Public ConStr As String = "dbTailoringERP"
    'Public pwd As String = "erpctxls"
    'Public pwd As String = "erpctxls@2017"
    'Public pwd As String = "erpctxls@2014"
    'Public pwd As Stringc = "user_dbTailoring???"
    'Public pwd As String = "ssdAzure.2019"
    'Public pwd As String = "demo.2018"
    'Public pwd As String = "lazaroHBD@000"
    'Public pwd As String = "amazon@2018"
    'Public pwd As String = "OPTICAL"
    'Public pwd As String = "sa@123" 'NareshFashion
    'Public pwd As String = "ciplPayroll@2019"

    Public servername As String
    Public loggedUserId, loggedDeptId As Integer
    Public loggedUser As String
    Public M_dsUserRights As New Data.DataSet

    Public M_callingForm_StyleHelp As String
    Public M_callingForm_MiscHelp As String
    Public M_callingForm_LedgerHelp As String
    Public M_callingForm_ProductHelp As String
    Public M_callingForm_WorkIssuePopup As String
    Public M_callingForm_Feedback As String
    Public M_callingForm_FabricAttachment As String
    Public M_callingForm_TailoringItemAttachment As String
    Public M_callingForm_LoyaltyPoints As String
    Public M_callingForm_ParaValue As String
    Public M_callingForm_SizeSelection_Sales As String
    Public M_callingForm_SettingHelp As String
    Public M_callingForm_PaymentHelp As String
    Public M_callingForm_MeasurementVenus As String
    Public M_callingForm_WebcamImageCap As String

    Public M_YrStart, M_YrEnd, M_StockYrStart As Date
    Public M_FinYrIndx As Integer
    Public M_YrStartWH, M_YrEndWH As Date

    Public M_dsCompany As New Data.DataSet
    Public M_dsSettings As New Data.DataSet
    Public M_dsFieldSettings As New Data.DataSet
    Public M_dsFinYr As New Data.DataSet
    Public M_dsDashboard As New Data.DataSet
    Public dsCRMDetails_Local As New Data.DataSet

    Dim strFileName As String
    'Dim excel As New Excel.Application
    Dim excel As Excel.Application
    Dim wBook As Excel.Workbook
    Dim wSheet As Excel.Worksheet

    Public M_CallFromTB_LeAcRpt As Boolean = False
    Public M_LedgerId_View_LedgerAcRpt As Integer
    Public M_LedgerName_View_LedgerAcRpt As String
    Public M_CId, M_StockYrId As Integer
    Public M_CName, M_CAddress, M_CState, M_CContact, M_PhNo, M_Invoice, M_CCity, M_CCountry, M_TC1, M_TC2, M_TC3, M_TC4, M_TC5, M_TC6, M_TC7, M_ForCo As String

    Public M_SearchText As String
    Public M_LedgerMasterF2 As Boolean = False
    Public M_SalesItemMasterF2 As Boolean = False
    Public M_DiscountTran As Boolean = False
    Public M_CallingFormLedgerCreation, M_CallingFormLedgerUpdation, M_TailoringInvoiceOpenedFrom, M_CallingFormItemCreation, M_CallingFormMiscMaster As String
    Public M_CallingFormStockStatement, M_CallingFormPurchase As String
    Public M_GeneralPurchaseOpenedFrom, M_CreditNoteOpenedFrom, M_callingForm_UISettingHelp As String
    Public M_PurchaseReturnId, M_SalesReturnId As Integer

    Public M_MeasurementSheetPrint, M_SalesBillPrintCopies, M_InvPrintCopy, M_InvRptFile, M_PurchaseForBranch, M_OnSavePrint, M_TailoringInvoicePrintCopies, M_DirectInvoicePrintCopy, M_OnSavePrint_TailoringInv, M_OnSavePrint_RentalInv, M_OnSavePrint_SalesBill, M_ShowHistoryTailoringInvoice, M_InvNumbering, M_NotesStyle, M_TrialDateRqrd, M_WorkDaysTabStop, M_PrintPcWiseMSlip, M_AllowZeroRate, M_UserWiseInvoicePrefix, M_CloseDay, M_DobInQuickLedgerCreation, M_JobWorkReport, M_TailoringInvRptFile, M_RentalInvRptFile, M_RentalInvRptFile_GST, M_RentalInvGSTApp, M_RetailWantItemWiseBranding, M_DynamicRepLayout, M_WorkerWorkEntryRptFile, M_ShowRatesInStockStatement, M_IgnoreSalesQtyInStockStatement, M_IgnoreMaterialIssueQtyInStockStatement, M_WorkManagementModule, M_SalesBillRptFile, M_DirectInvRptFile, M_MeasurementRptFile, M_CustMaster_MeasurementRptFile, M_MeasurementSlipType, M_SMSSenderNo, M_SMSSenderPwd, M_SMSSenderId, M_SMSEnabled, M_WhatsAppEnabled, M_SMSOnSaveTI, M_AllwDupLcode, M_AllwDupSIcode, M_AllwDupTIcode, M_SMSOWrkrWrk, M_PreviewSMS, M_PreviewWhatsApp, M_ShowCustNameInMeasurementSheet, M_ShowCustMobNoInMeasurementSheet, M_BgImg, M_BackgroundImageLayout, M_DashboardOnStartUp, M_BarcodeLabelFileName, M_BarcodeSheetFileName, M_PurchaseBarcodeSheetFileName, M_BarcodeLabelSheet, M_WorkAllocationSlipReportFileName, M_WebAPIEnabled, M_WorkRtnAutoPostEntry, M_WorkRtnAutoPostStatus, M_DefaultWorkDays, M_MinimumWorkDays, M_DefaultTrialDays, M_CustNameCharCasing, M_TItemNameCharCasing, M_SalesItemCharCasing, M_DefaultInvoiceView, M_SalesItemSelectionMode, M_CustomModeValue, M_CustomTextInInvoice, M_PritableInvoiceItems, M_TailoringInvoiceOnStartUp, M_HelpLedgerList, M_InvoicePrintAfterChangeAmt, M_BarcodeSetting, M_TopRows, M_FieldSetting, M_SalesModule, M_PurchaseModule, M_TailoringOrderModule, M_BarcodeCreation, M_ShowLedgerBalanceInInvoice, M_CashCreditLedgerId, M_SalesTypeCash, M_SalesTypeCredit, M_SalesTypeCard, M_SalesTypeWallet, M_OnSavePrint_BarcodeLabel, M_TailoringLedger, M_SalesPersonCompulsoryInTailoringInv, M_CustomerWeightCompulsoryInTailoringInv, M_CustAddMsgForDueBill, M_SpecifyProfitPerForMRPInPurchase, M_DefaultProfitPerForMRPInPurchase, M_ConsiderGSTForProfitPer, M_OfferRateApplicableTI, M_OfferRateApplicableSI, M_WorkerWiseItemRates, M_LedgerIdOpeningStock, M_PurchaseIdOpeningStock, M_PostEntryInPurchaseDetailForOpeningStock, M_PrnCmd, M_TailoringInvoiceSeries, M_ShowTrialQtyInTailoringOrder, M_ShowProductionNoInTailoringOrder, M_WorkerWorkDirectEntry, M_ItemNameWithRemark, M_TailoringBarcodeFileName, M_TailoringOrderRptFile, M_TailoringInvRptFile_GST, M_OnSaveTailoringBarcodePrint, M_MeasurementByCompulsoryInTailoringInv, M_WorkerPaymentSlipRptFile, M_DayEmpPmtEntry, M_DaySalesCommissionPmtEntry, M_ShowWorkerOnTailoringItemDelivery, M_ShowWorkIssueCompanyWise, M_OnSavePrint_TailoringMeas, M_DupMobGenMessage, M_OutstandingPayRptFile, M_DefaultReciptType, M_DeliveryItemRptFile, M_ShowDeliItemReport As String
    Public M_SMSAPI, M_GetSMSBalAPI As String

    Public M_InputCGST, M_InputSGST, M_InputIGST, M_OutputCGST, M_OutputSGST, M_OutputIGST, M_PurchaseDefaultTaxation, M_SalesDefaultTaxation, M_PurchaseDefaultBillType, M_SalesDefaultBillType, M_TaxCalculation As String
    Public M_PurchaseEntryGSTCalculationOn, M_SalesEntryGSTCalculationOn, M_PurchaseItemWiseGSTRounding, M_SalesItemWiseGSTRounding, M_PurchaseBillGSTRounding, M_SalesBillGSTRounding, M_AQtyRoundnig, M_SqMtrRoundnig, M_PurchaseBillAmtRounding, M_SalesBillAmtRounding, M_PurchaseItemDiscountRounding, M_SalesItemDiscountRounding, M_PurchaseBillDiscountRounding, M_SalesBillDiscountRounding, M_StockCalcField, M_StockQtyRounding, M_SqFtRoundnig, M_RFRoundnig, M_SqFtDF, M_SqMtrDV, M_RFtDF, M_FabricMargine, M_ShowMeasurmentPanelinTailoringOrder, M_BillEditOTP, M_BillDeleteOTP, M_ResetSalesInvoiceNumberOnDailyBasis, M_WhatsappOnSaveTimeTextPDF, M_WhatsappOnSaveTimeRITextPDF, M_TIRightClickBookingWhatsApp, M_AllowPurchaserateZero As String
    Public M_PurchaseRateEI, M_SalesRateEI, M_PurchaseHelpLedgerList, M_SalesHelpLedgerList, M_PurchaseItemTotalRounding, M_SalesItemTotalRounding, M_ItemHelpList, M_UpdateSalesRateInItemMasterWhilePurchaseEntry, M_VGrpForLacAmt, M_BarcodeText, M_CompanyWiseMiscMaster, M_CompanyWisePurchase, M_TIHelpLedgerList, M_TailoringItemList As String
    Public M_TIRightClickBookingSMS, M_TIRightClickReadySMS, M_TIRightClickTrialSMS, M_TIRightClickDeliverySMS, M_TIRightClickDueSMS, M_WorkerWorkEntry, M_ProductionOutputLedgerId, M_ProductionOutputPurchaseId, M_TIRightClickFeedback, M_TIRightClickViewImageSheet, M_TIRightClickAttachment, M_TIRightClickItemLabelPrint, M_TIRightClickViewOrder, M_TIRightClickViewTailoringBarcode, M_TailoringItemImagePath, M_TIRightClickTrackBarcode, M_SMS_DeliveryTime, M_TIRightClickUpdateTrialAndDeliveryDate, M_UseNotifyPendingDelivery, M_TimerInterval, M_CallingOrderStatus As String
    Public M_BarcodePrinterName, M_RegularPrinterName, M_MeasurmentPrinterName, M_ItemCodeSearching, M_BarcodeSearching, M_TailoringItemSorting As String
    Public M_NotesFontName, M_NotesFontSize, M_ParaFontName, M_ParaFontSize, M_ParaColWidth As String
    Public M_TailoringItemMaster, M_UpdateReadyQtyAfter, M_TINumbering, M_Old_TailoringInvoiceFormName, M_GeneralMeasurementTItemId, M_MeasurementFetchSetting, M_MobileNoLength, M_ValidateMobileNoLength, M_Language, M_GenInvNumSeparately, M_WorkIssueSlipRequired, M_PurchasePriceCode, M_WorkWiseWorker, M_FractionMeasurementInput, M_FractionNotesInput, M_OnSavePaymentExpenseSlipPrint, M_QtyUpdateInTailoringInvoice, M_AutobackupFilePath, M_TrialWhatsAppSentOnWorkDone, M_ReadyWhatsAppSentOnWorkDone, M_WhatsAppOnCollectPaymentTime, M_SendWhatsAppWorkSlip, M_FocusOnOkButtonAfterMobileAddress, M_CustomerTypeShow, M_DTMforSP, M_PCDTM, M_DTMforQuery, M_HideGSTColumns, M_Dashboard_ItemType, M_DashboardShowCompleteOrdersOnly, M_InvoiceMasterInShowLedgerCloBal, M_AdjustAmtInExtraChargeForWorker, M_Dashboard_ItemSubType, M_ProfitGroupPanelShowInDashboard, M_ShowTotalDueAmtInInvoice, M_SalesGlassQtySqMtrSqFt, M_WhatsappInstanceId, M_WhatsAppLoginPassword, M_WhatsAppRegisteredMobileNo, M_DeliveryDateLessDaysForWorker, M_NotifyCustChangeDeliDate, M_CustCreationNameRqrd, M_CustCreationMobileRqrd, M_FabricIssueToWorker, M_MeasurementImgPath, M_StyleImgPath As String

    Public M_MinDate As Date
    Public M_MaxDate As Date

    Public M_MinDate1 As Date
    Public M_MaxDate1 As Date

    Public M_InvLimit As Integer
    Public M_TranLimit As Integer
    Public M_LedgerLimit As Integer

    Public M_LiveStock As Double

    'Public _font As String
    'Public _fontSize As Integer

    Dim cntSMS As Integer = 0
    Public loggedIP As String

    Public M_AutoAddSalesItem, M_DefaultSalesItemQty, M_AutoBankReco, M_DefaultCustRequired, M_InvoiceNumberReadOnly, M_RequiredReceiptDetailsInSales, M_TabStopSalesInvDate, M_TabStopSalesBillType, M_TabStopSalesCreditDays, M_TabStopSalesBillNo As String
    Public M_DefaultCustLedgerId, M_DefaultProductionLedgerId, M_AllowNegativeSales, M_SalesDefaultType, M_SalesId, M_SalesOpenReason, M_CashBankOpenReason, M_ChequeBookDetailOpenReason, M_WorkIssueReturnOpenReason, M_PendingWorkIssuanceOpenReason, M_TailoringOrder, M_WorkIssuanceOpenReason, M_WorkDoneOpenReason, M_TabStopSalesRef, M_TabStopSalesType, M_AutoGenSubItems, M_EnableMaterialAndWorkIssue, M_UseOtherDatabase, M_ItemRateReadOnly, M_GSTLedgerList, M_GroupList_GPCrLedger, M_GroupList_GPDrLedger, M_GroupList_GPRCrLedger As String
    Public M_EnableLoyaltiPointProgram, M_LoyaltiPointBase, M_1LoyaltiPointEqualTo, M_1LoyaltiPointRedemptionEqualTo, M_MinLoyaltiPointsRedemptionEqualTo, M_LoyaltiPointsValidity, M_PendingWorkIssue_DefaultWorkIssueType, M_CheckProductionLimit, M_ProdLimit_ItemGroupWise, M_WorkIssueQuantityReadOnly, M_DefaultWorkIssueQuantity, M_CustomerMaster, M_GenerateOrderNumberSaveTime, M_GenerateCustomerNumberSaveTime, M_SalesItemMaster As String
    Public M_ReferralProgramEnabled, M_ReferralPointBase, M_1ReferralPointEqualTo, M_1ReferralPointRedemptionEqualTo, M_MinReferralPointsRedemptionEqualTo, M_ReferralPointsValidity, M_MinimumReferralAmount As String
    Public M_Purchase_GSTCredit, M_Sales_GSTDebit, M_TI_ReadyQty_ReadOnly, M_TI_DeliveryQty_ReadOnly, M_AllowAdvanceAmount, M_ManualInvoiceNoAndDate, M_TabStopSalesItemRate, M_TabStopSalesItemQty, M_TabStopPurchaseDocumentDate, M_TabStopPurchaseCreditDays, M_DefaultTransport, M_DefaultTransportLedgerId, M_CustCodeRequired, M_RefRequiredInTailoringOrder, M_DefaultSalesItemQuantity, M_TabStopSalesItemDiscount, M_TabStopSalesRequiredOnInvoiceYesNo, M_NewInvoiceNumberGenerationDate, M_TabStopSalesQuantityYesNo, M_PrintBlankMeasurementInMSlip, M_TailoringOrderList, M_ConsiderRateWiseGSTInSales, M_ConsiderRateWiseGSTInPurchase, M_ConsiderRateWiseGSTInTailoring, M_ShowMultiplePaymentMode, M_GetSalesVId, M_ShowStandardQtyInMaterialIssuance, M_SalesBrokerageCalcOn, M_BrokerageRounding, M_SaveProductDetailsInBillNo_BillDt, M_BrokerageExp, M_AllwDupInvoiceNo, M_ImageCollPath, M_StockStatement As String

    'Public imageData As String
    Public imgData(20) As String
    Public M_FYId As Integer
    Public M_Flag As Boolean = False

    Public M_LedgerAcOpenReason, M_TailoringReportsOpenReason, M_AutoFillReceiptAmtOnFocus As String
    Public M_AllParaValue, M_AllParaValue_Text As String
    Public M_CaptureImageOpenReason As String

    'Debit Vouchers
    Public M_TC_ThresHold_DebitVouchers, M_TC_NettRate_DebitVouchers As Double

    '10/03/2021 
    Public M_TSExpenseId As Integer
    Public M_NonGSTsupplyLedgerId As String

    Public M_Yr As String = ""
    'M_CountryCode,
    Public M_Stumul_ConnectionString As String = ""
    Public M_QT_Company_ID As String = ""
    Public M_CustomerCompanies, M_TailoringItemCompanies, M_SalesItemCompanies, M_MainStoreCIdList, M_UseTailoringBarcodes, M_TailoringBarcodeStartFrom, M_LoggedLedgerId, M_LoggedLedgerName, M_Barcode_CIdList, M_GSTPerChangeOnNonTailoringItem, M_CreateNewBarcodeOnPurchaseTime, M_Dashboard_ShowDeliverdItem, M_ManageWR_Item_Salary_Wise, M_DeliveryDate_AsPer_ItemGroup, M_Block_BlackListCustomer, M_ImageUploadSize, M_ItemMasterImageUploadSize, M_ItemMasterItemImagePath, M_SalesItemList, M_LedgerList, M_CCWhatsappWhatsappOnSaveTimeSendInvoice, M_CCWhatsappWhatsappOnSaveTimeSendText, M_CCWhatsappMobileNo, M_CCWhatsappWhatsappOnAfterReadyQtyUpdate, M_PrintTailoringTag, M_AddBlankBarcode, M_UserWiseCompanies, M_LoggedMobileNo, M_LoggedIsOTPRequired, M_CombineItemRatexMtrPcs, M_DashboardMergeRptFile, M_QuickWorkAllocation, M_WorkAssignQty As String

    Public M_UploadDocFilePath As String = ""
    Public M_UseBarcodeWiseMeasurmentSheet As String = ""
    Public M_SesssionId As Integer

    Public M_Help_CategoryOrItem As String = ""
    Public M_AppLogoutExitTimeBackUp As String = ""
    Public M_EmpSalaryDays As String = ""
    Public M_ShowDeletedRecord As String = ""
    Public M_GridRowBackColor, M_GridCellBackColor, M_GridRowForeColor, M_GridCellForeColor, M_CheckReferenceInTI, M_CommonCashBankLedgerId, M_OutStandingReportMsgType, M_OutStandingDeliDone As String
    Public M_Barcode_Based_Workshop_Management As String = ""
    Public M_BranchWiseSalesRate As String
    Public M_FinishingMeasurement, M_SelectFabricAfterTailoringItem, M_AllowTailoringItemSelectionInSales, M_UseCuttingFormula, M_CustomerTypeRequired, M_LessDaysForFromYear, M_PendingDeliveryReportFileName, M_OrderByLedger, M_CompanyWiseCustomerLoad, M_PrevDayBillEditDelete, M_PurchaseTimeBarcodePCSWise, M_PurchaseTimeUniqueBarcodeStartFrom As String
    Public M_PurchaseRefItemAuto, M_UseDharaFromLedgerMasterForPurchase, M_WorkIR_Module, M_SalesItemMasterProduct, M_SalesmanPaymentSlipRptFile, M_SalesmanCommissionBillWiseItemWise, M_UsePurchaseOrder, M_PurchaseOrderReportFile, M_POForBranchReportFile, M_CustStichDetailReportFile, M_TIRightClickViewStitchingDetail, M_AllowMultiCountryMobileSeries, M_CashBankReportFileName, M_AllowChequePrint, M_AllowExpensePrint, M_AllowReceiptPrint, M_WorkIssueChallanReportFileName, M_WhatsappOnDeliveryTime, M_WorkIssueSlipFileName, M_TodaydateOnAddClickTime, M_WhatsAppOnLoyaltyPointGeneration, M_WhatsAppOnRefferalPointGeneration, M_FilterTailoringItem, M_FilterProductItem, M_SendWhatsappToOnwnerNo, M_ConsiderStockDataAfter, M_AllowZeroWages, M_DebitNoteRptFile, M_CreditNoteRptFile, M_StockTransferRptFile, M_AllowWebcamCaptureImage, M_DivideByInMeasurementSlip, M_WorkersCIdList, M_GenisysConpath, M_DashboardReceiptPrintDetailFileName, M_DashboardReceiptPrintSummaryFileName, M_DeliveryDateOptional, M_WorkerManagement, M_NotesStyleReadOnly, M_NotesStyleChargesReadOnly, M_StockStatementIgnorePRODUCTQty As String

    Public M_DsUserWiseTranCIdList As DataSet
    Public M_DsCustomReporting As DataSet
    Public TI_CIdList_Customer, TI_CIdList_TailoringItems, TI_CIdList_SalesItems, WI_CIdList_WorkerList, WI_CIdList_ProcessList, WI_CIdList_View_WorkInProcess, WI_CIdList_View_WorkCompleted, ST_CIdList, SR_CIdList, StockStatement_CIdList, Purchase_CIdList_Vendor, Purchase_CIdList_ItemList As String
    Public tmpdrCr As String = ""
    Public closingBal As Double = 0

    Public M_SelectedCompanies As String = ""
    Public M_CommonCIdList As String = ""
    Public M_DateChange As String = ""
    'Public ClsNotificationApp_I As ClsNotificationApp
    Public M_GridToExcel As String
    Public M_EwayCompGST, M_EwayUserName, M_EwayPwd, M_EwayUrl As String
    Public emailStatus As String
#End Region

#Region "Function"


    Public Function isInternetOn() As Boolean
        Select Case M_DbName
            Case "dbSTS_NareshFashion1", "dbSTS_NareshFashion2"
                'Not check internet Connectivity
                Return True
                Exit Select
            Case Else
                Try
                    Using client = New WebClient()
                        Using stream = client.OpenRead("https://www.google.com")
                            'MessageBox.Show("Internet is available.")
                            Return True
                        End Using
                    End Using
                Catch
                    MessageBox.Show("Internet is not available.")
                    Return False
                End Try
                Exit Select
        End Select
    End Function

    Public Function IsInternetConnected() As Boolean
        Try
            Return New Ping().Send("www.google.com").Status = IPStatus.Success
        Catch ex As Exception
            MessageBox.Show("Check Internet Settings")
            Return False
        End Try

    End Function

    Public Function M_GetClosingBalance(ByVal ledgerId As Integer) As String
        Dim _Filter As String = "_" & M_dsFinYr.Tables(0).Rows(M_FinYrIndx)("YrSuffix")
        Dim _Filter1 As String = Format(M_YrStart, M_DTMforQuery)
        Dim _Filter2 As String = Format(M_YrEnd, M_DTMforQuery)

        Dim drOp, crOp, drTot, crTot As Double

        sql_query = "select isnull(sum(drOpening),0) from tbl_LedgerOpeningBalance" & _Filter & " where LedgerId in (select ledgerid from view_ledgername_groupname where LedgerId = " & ledgerId & ")"
        drOp = Format(Val(obj.ScalarExecute(sql_query)), "0.00")

        sql_query = "select isnull(sum(crOpening),0) from tbl_LedgerOpeningBalance" & _Filter & " where LedgerId in (select ledgerid from view_ledgername_groupname where LedgerId = " & ledgerId & ")"
        crOp = Format(Val(obj.ScalarExecute(sql_query)), "0.00")

        'Debit / Credit Amt
        sql_query = "select isnull(sum (dramt),0) from tbl_voucherentrymast where drledgerid in (select ledgerid from view_ledgername_groupname where LedgerId = " & ledgerId & ") And VDocDate >= '" & _Filter1 & "' And VDocDate <= '" & _Filter2 & "'"
        drTot = Format(Val(obj.ScalarExecute(sql_query)), "0.00")

        sql_query = "select isnull(sum (cramt),0) from tbl_voucherentrymast where crledgerid in (select ledgerid from view_ledgername_groupname where LedgerId = " & ledgerId & ") And VDocDate >= '" & _Filter1 & "' And VDocDate <= '" & _Filter2 & "'"
        crTot = Format(Val(obj.ScalarExecute(sql_query)), "0.00")

        If (drOp + drTot) > (crOp + crTot) Then
            Return Format((drOp + drTot) - (crOp + crTot), "0.00") & " Dr"
        End If

        If (crOp + crTot) > (drOp + drTot) Then
            Return Format((crOp + crTot) - (drOp + drTot), "0.00") & " Cr"
        End If

        If (drOp + drTot) = (crOp + crTot) Then
            Return Format(0, "0.00")
        End If
    End Function

    Public Function M_GetClosingBalance1(ByVal ledgerId As Integer) As String
        Dim _Filter As String = "_" & M_dsFinYr.Tables(0).Rows(M_FinYrIndx)("YrSuffix")
        Dim _Filter1 As String = Format(M_YrStart, M_DTMforQuery)
        Dim _Filter2 As String = Format(M_YrEnd, M_DTMforQuery)

        Dim drOp, crOp, drTot, crTot As Double

        sql_query = "select isnull(sum(drOpening),0) from tbl_LedgerOpeningBalance" & _Filter & " where LedgerId in (select ledgerid from view_ledgername_groupname where LedgerId = " & ledgerId & ")"
        drOp = Format(Val(obj.ScalarExecute(sql_query)), "0.00")

        sql_query = "select isnull(sum(crOpening),0) from tbl_LedgerOpeningBalance" & _Filter & " where LedgerId in (select ledgerid from view_ledgername_groupname where LedgerId = " & ledgerId & ")"
        crOp = Format(Val(obj.ScalarExecute(sql_query)), "0.00")

        'Debit / Credit Amt
        sql_query = "select isnull(sum (dramt),0) from tbl_voucherentrymast where drledgerid in (select ledgerid from view_ledgername_groupname where LedgerId = " & ledgerId & ") And VDocDate >= '" & _Filter1 & "' And VDocDate <= '" & _Filter2 & "'"
        drTot = Format(Val(obj.ScalarExecute(sql_query)), "0.00")

        sql_query = "select isnull(sum (cramt),0) from tbl_voucherentrymast where crledgerid in (select ledgerid from view_ledgername_groupname where LedgerId = " & ledgerId & ") And VDocDate >= '" & _Filter1 & "' And VDocDate <= '" & _Filter2 & "'"
        crTot = Format(Val(obj.ScalarExecute(sql_query)), "0.00")

        If (drOp + drTot) > (crOp + crTot) Then
            Return Format((drOp + drTot) - (crOp + crTot), "0.00")
        End If

        If (crOp + crTot) > (drOp + drTot) Then
            Return Format((crOp + crTot) - (drOp + drTot), "0.00")
        End If

        If (drOp + drTot) = (crOp + crTot) Then
            Return Format(0, "0.00")
        End If
    End Function

    Public Sub M_GetClosingBalance_New(ByVal ledgerId As Integer, ledgerType As String, gId As Integer, startDate As DateTime, endDate As DateTime)
        Dim _Filter As String = "_" & M_dsFinYr.Tables(0).Rows(M_FinYrIndx)("YrSuffix")
        Dim _Filter1 As String = Format(startDate, M_DTMforQuery)
        Dim _Filter2 As String = Format(endDate, M_DTMforQuery)

        Dim ds123 As New Data.DataSet

        obj.Prepare("Get_Ledger_Closing", SpType.StoredProcedure)
        obj.AddCmdParameter("@ledgerId", Dtype.int, ledgerId, ParaDirection.Input, True)
        obj.AddCmdParameter("@gId", Dtype.int, gId, ParaDirection.Input, True)
        obj.AddCmdParameter("@_Filter", Dtype.varchar, _Filter, ParaDirection.Input, True)
        obj.AddCmdParameter("@_Filter1", Dtype.varchar, _Filter1, ParaDirection.Input, True)
        obj.AddCmdParameter("@_Filter2", Dtype.varchar, _Filter2, ParaDirection.Input, True)
        obj.AddCmdParameter("@M_VGrpForLacAmt", Dtype.varchar, M_VGrpForLacAmt, ParaDirection.Input, True)
        obj.AddCmdParameter("@M_CId", Dtype.int, M_CId, ParaDirection.Input, True)
        obj.AddCmdParameter("@tbl_LedgerOpeningBalance", Dtype.varchar, "", ParaDirection.Input, True)
        obj.AddCmdParameter("@YearID", Dtype.int, "", ParaDirection.Input, True)
        obj.LoadData123("Get_Ledger_Closing", ds123)

        If ds123.Tables(0).Rows.Count > 0 Then
            tmpdrCr = ds123.Tables(0).Rows(0)("DrCr")
            closingBal = Format(ds123.Tables(0).Rows(0)("Closing"), "0.00")
        End If
    End Sub

    Public Function getServerDTM() As Date
        sql_query = "Select GetDate()"
        Return obj.ScalarExecute(sql_query)
    End Function

    Public Function checkNumber(ByVal e As Integer) As Boolean
        If e > 32 And e < 127 Then
            If Not (e > 47 And e < 58) Then
                Beep()
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Public Function checkAlphabet(ByVal e As Integer) As Boolean
        If e > 32 And e < 127 Then
            If (e > 64 And e < 91) Or (e > 96 And e < 123) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function PlaceInMiddle(ByVal txt As String, ByVal RequiredLength As Integer) As String
        If Len(txt) < RequiredLength Then
            PlaceInMiddle = Strings.StrDup(Convert.ToInt16(Val(RequiredLength / 2) - Val(txt.Length / 2)), " ") & txt
            PlaceInMiddle = PlaceInMiddle & StrDup(RequiredLength - PlaceInMiddle.Length, " ")
        Else
            PlaceInMiddle = txt
        End If
    End Function

    Public Function AddSpaces(ByVal txt As String, ByVal RequiredLength As Integer, ByVal bBeforeText As Boolean) As String
        If Len(txt) < RequiredLength Then
            If bBeforeText Then
                AddSpaces = Strings.StrDup(RequiredLength - Len(txt), " ") & txt
            Else
                AddSpaces = txt & Strings.StrDup(RequiredLength - Len(txt), " ")
            End If
        Else
            AddSpaces = txt
        End If
    End Function

    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String
        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        Dim i As Integer
        strReplicate = ""
        For i = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate
    End Function

    Function AmtInWord(ByVal Num As Decimal) As String
        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Paise" + cWord3(CDbl(strNumDec)), "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " ") + NumToWord(CDbl(strNum))
        End If
        AmtInWord = StrWord & " Only"
        Return AmtInWord
    End Function

    Function NumToWord(ByVal Num As Decimal) As String
        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord
    End Function

    Function cWordG3(ByVal Num As Decimal) As String
        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3
    End Function

    Function cWord3(ByVal Num As Decimal) As String
        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3
    End Function

    Function retWord(ByVal Num As Double) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"},
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"},
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"},
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"},
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"},
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        Dim i As Integer
        For i = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord
    End Function

    Public Function M_GetFormViewId(ByVal _FormViewName As String) As Integer
        Dim dv As New DataView(dsUserRights.Tables(0))
        dv.RowFilter = " AllowAccess = 'True' And FormViewName = '" & _FormViewName & "' And UserId = '" & loggedUserId & "' "

        Dim tmpDT As New DataTable
        tmpDT = dv.ToTable

        If tmpDT.Rows.Count = 0 Then
            Return 0
        Else
            Return Val(tmpDT.Rows(0)("FormViewId"))
        End If
    End Function

    Public Function checkRightsToLoad(ByVal _FormViewName As String) As Boolean
        'For i As Integer = 0 To M_dsUserRights.Tables(0).Rows.Count - 1
        '    If M_dsUserRights.Tables(0).Rows(i)("AllowAccess") = True And M_dsUserRights.Tables(0).Rows(i)("FormViewName") = _FormViewName Then
        '        Return True
        '        Exit For
        '    End If
        'Next
        'Return False


        '=============

        Dim dv As New DataView(dsUserRights.Tables(0))
        dv.RowFilter = " AllowAccess = 'True' And FormViewName = '" & _FormViewName & "' And UserId = '" & loggedUserId & "' "

        Dim tmpDT As New DataTable
        tmpDT = dv.ToTable

        If tmpDT.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function checkRightsToAdd(ByVal _FormViewName As String) As Boolean
        'For i As Integer = 0 To M_dsUserRights.Tables(0).Rows.Count - 1
        '    If M_dsUserRights.Tables(0).Rows(i)("NewRecord") = True And M_dsUserRights.Tables(0).Rows(i)("FormViewName") = _FormViewName Then
        '        Return True
        '        Exit For
        '    End If
        'Next
        'Return False

        '=============

        Dim dv As New DataView(dsUserRights.Tables(0))
        dv.RowFilter = " NewRecord = 'True' And FormViewName = '" & _FormViewName & "' And UserId = '" & loggedUserId & "'  "

        Dim tmpDT As New DataTable
        tmpDT = dv.ToTable

        If tmpDT.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function checkRightsToEdit(ByVal _FormViewName As String) As Boolean
        'For i As Integer = 0 To M_dsUserRights.Tables(0).Rows.Count - 1
        '    If M_dsUserRights.Tables(0).Rows(i)("ModifyRecord") = True And M_dsUserRights.Tables(0).Rows(i)("FormViewName") = _FormViewName Then
        '        Return True
        '        Exit For
        '    End If
        'Next
        'Return False

        '=============

        Dim dv As New DataView(dsUserRights.Tables(0))
        dv.RowFilter = " ModifyRecord = 'True' And FormViewName = '" & _FormViewName & "' And UserId = '" & loggedUserId & "' "

        Dim tmpDT As New DataTable
        tmpDT = dv.ToTable

        If tmpDT.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function checkRightsToDelete(ByVal _FormViewName As String) As Boolean
        'For i As Integer = 0 To M_dsUserRights.Tables(0).Rows.Count - 1
        '    If M_dsUserRights.Tables(0).Rows(i)("DeleteRecord") = True And M_dsUserRights.Tables(0).Rows(i)("FormViewName") = _FormViewName Then
        '        Return True
        '        Exit For
        '    End If
        'Next
        'Return False

        '=============

        Dim dv As New DataView(dsUserRights.Tables(0))
        dv.RowFilter = " DeleteRecord = 'True' And FormViewName = '" & _FormViewName & "' And UserId = '" & loggedUserId & "' "

        Dim tmpDT As New DataTable
        tmpDT = dv.ToTable

        If tmpDT.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function M_getImagePath(ByVal frm As Form) As String
        Dim OpenFileDialog As New OpenFileDialog
        'OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "All Files (*.*)|*.*|Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg"
        If (OpenFileDialog.ShowDialog(frm) = System.Windows.Forms.DialogResult.OK) Then
            Return OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Function

    Public Function M_ByteToImage(ByVal Imgbyte() As Byte) As Image
        Dim ms As New MemoryStream(Imgbyte)
        Return Image.FromStream(ms)
    End Function

    Public Function M_ImageToByte(ByVal img As Image) As Byte()
        Dim ms As New MemoryStream
        Dim bmp As New Bitmap(img)
        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Function M_FixImageRotation(Img As Image) As Image
        If Img Is Nothing Then Return Nothing

        Try

            For Each prop As Imaging.PropertyItem In Img.PropertyItems
                If prop.Id = &H112 Then ' Orientation tag
                    Dim orientation As Integer = BitConverter.ToInt16(prop.Value, 0)
                    Select Case orientation
                        Case 3
                            Img.RotateFlip(RotateFlipType.Rotate180FlipNone)
                        Case 6
                            Img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                        Case 8
                            Img.RotateFlip(RotateFlipType.Rotate270FlipNone)
                    End Select
                    ' Reset orientation tag so it won't rotate again
                    prop.Value = BitConverter.GetBytes(1S)
                    Exit For
                End If
            Next
        Catch ex As Exception
            Return Nothing
        End Try

        Return Img
    End Function

    'Public Function M_ImagePathToByte(ByVal tmpfilepath As String) As Byte()
    '    Dim imgByteArray() As Byte
    '    Dim stream As New MemoryStream
    '    Dim bmp As New Bitmap(tmpfilepath)
    '    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)

    '    Return stream.ToArray()
    'End Function

    Public Function M_checkMiscMaster(ByVal _MiscType As String, ByVal _MiscName As String) As Boolean
        Dim existRecords As Integer
        If M_CompanyWiseMiscMaster = "Yes" Then
            sql_query = "Select Count(*) from tbl_MiscMaster where CId = " & M_CId & " And MiscType = '" & _MiscType & "' And MiscName = '" & _MiscName & "'"
        Else
            sql_query = "Select Count(*) from tbl_MiscMaster where MiscType = '" & _MiscType & "' And MiscName = '" & _MiscName & "'"
        End If
        existRecords = obj.ScalarExecute(sql_query)
        If existRecords >= 1 Then
            Return True
        End If
        Return False
    End Function

    Public Function checkDateFormat(ByVal dt As String) As Boolean
        If dt.Length = 10 Then
            For i As Integer = 0 To dt.Length - 1
                If Not (i = 2 Or i = 5) Then
                    If Not IsNumeric(dt.Substring(i, 1)) Then
                        'MsgBox("Invalid Date Format", MsgBoxStyle.Information)
                        Return False
                        Exit Function
                    End If
                End If
            Next
            If IsDate(dt.Substring(0, 2) & "/" & dt.Substring(3, 2) & "/" & dt.Substring(6, 4)) = True Then
                'MsgBox("Ok")
            Else
                'MsgBox("Invalid Date Format", MsgBoxStyle.Information)
                Return False
                Exit Function
            End If
        Else
            'MsgBox("Invalid Date Format", MsgBoxStyle.Information)
            Return False
            Exit Function
        End If
        Return True
    End Function

#End Region

#Region "Methods"

    'Public Sub M_loadUserRights()
    '    M_dsUserRights.Clear()
    '    sql_query = "Select * From View_UserRightsMaster Where UserName = '" & loggedUser & "'"
    '    obj.LoadData(sql_query, M_dsUserRights)
    'End Sub

    Public Sub M_loadUserRights_New()
        M_dsUserRights.Clear()
        sql_query = "Select * From View_UserRightsMasterNew Where UserName = '" & loggedUser & "'"
        obj.LoadData(sql_query, M_dsUserRights)
    End Sub

    Public Sub M_loadCompanyMaster()
        If M_UserWiseCompanies = "" Then
            'EXISTING
            M_dsCompany.Clear()

            sql_query = "Select SettingValue From tbl_Settings Where SettingName = 'User Wise Company (True / False)'"
            If obj.ScalarExecute(sql_query) = "True" Then
                obj.LoadData("Select * From View_CompanyMaster Where CId In (Select CId From Tbl_UserMaster Where UserId = " & loggedUserId & ") Order By CName", M_dsCompany)
            Else
                obj.LoadData("Select * From View_CompanyMaster Order By CName", M_dsCompany)
            End If
        Else
            'UDPATED
            M_dsCompany.Clear()
            obj.LoadData("Select * From View_CompanyMaster Where CId In (" & M_UserWiseCompanies & ") Order By CName", M_dsCompany)
        End If

    End Sub

    Public Sub M_LoadFieldSettings()
        M_dsFieldSettings.Clear()
        obj.LoadData("Select * From tbl_FieldSettings", M_dsFieldSettings)
    End Sub

    Public Sub M_loadGloabalParameters(ByVal rowIndx As Integer)
        M_CId = M_dsCompany.Tables(0).Rows(rowIndx)("CId")
        M_CName = M_dsCompany.Tables(0).Rows(rowIndx)("CName")
        M_CCity = UCase(M_dsCompany.Tables(0).Rows(rowIndx)("City"))
        M_CCountry = UCase(M_dsCompany.Tables(0).Rows(rowIndx)("Country"))
        M_CAddress = M_dsCompany.Tables(0).Rows(rowIndx)("Add1") & " " & M_dsCompany.Tables(0).Rows(rowIndx)("Add2") & ", " & M_dsCompany.Tables(0).Rows(rowIndx)("City") & ", " & M_dsCompany.Tables(0).Rows(rowIndx)("State")
        M_CState = Trim(M_dsCompany.Tables(0).Rows(rowIndx)("State"))
        M_CContact = "Contact : " & M_dsCompany.Tables(0).Rows(rowIndx)("PhNo") & " , EMail : " & M_dsCompany.Tables(0).Rows(rowIndx)("EMail")
        M_PhNo = M_dsCompany.Tables(0).Rows(rowIndx)("PhNo")
        M_TC1 = M_dsCompany.Tables(0).Rows(rowIndx)("TC1")
        M_TC2 = M_dsCompany.Tables(0).Rows(rowIndx)("TC2")
        M_TC3 = M_dsCompany.Tables(0).Rows(rowIndx)("TC3")
        M_TC4 = M_dsCompany.Tables(0).Rows(rowIndx)("TC4")
        M_TC5 = M_dsCompany.Tables(0).Rows(rowIndx)("TC5")
        M_TC6 = M_dsCompany.Tables(0).Rows(rowIndx)("TC6")
        M_TC7 = M_dsCompany.Tables(0).Rows(rowIndx)("TC7")
        M_Invoice = M_dsCompany.Tables(0).Rows(rowIndx)("Invoice")
        M_ForCo = M_dsCompany.Tables(0).Rows(rowIndx)("ForCo")
    End Sub

    Public Sub M_LoadSettings()
        M_dsSettings.Clear()
        obj.LoadData("Select * From Tbl_Settings Where CId = " & M_CId, M_dsSettings)

        For i As Integer = 0 To M_dsSettings.Tables(0).Rows.Count - 1
            Select Case M_dsSettings.Tables(0).Rows(i)("SettingName")
                Case "Measurement Sheet Print Copies"
                    M_MeasurementSheetPrint = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                    'Case "Sales Bill Print Copies"
                    '    M_SalesBillPrintCopies = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    '    Exit Select
                    'Case "Invoice Print Copy"
                    '    M_InvPrintCopy = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    '    Exit Select
                Case "Invoice Report File Name"
                    M_InvRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Print For Branch File Name"
                    M_PurchaseForBranch = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "On Save Print Needed"
                    M_OnSavePrint = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "On Save Print Needed (Tailoring Invoice)"
                    M_OnSavePrint_TailoringInv = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "On Save Print Needed (Barcode Label)"
                    M_OnSavePrint_BarcodeLabel = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "On Save Tailoring Order Print Barcode (Yes/No)"
                    M_OnSaveTailoringBarcodePrint = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show History in Tailoring Invoice"
                    'M_ShowHistoryTailoringInvoice = obj.ScalarExecute("Select SettingValue From Tbl_Settings Where SettingName = 'Show History in Tailoring Invoice'")
                    M_ShowHistoryTailoringInvoice = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Invoice Numbering"
                    'M_InvNumbering = obj.ScalarExecute("Select SettingValue From Tbl_Settings Where SettingName = 'Invoice Numbering'")
                    M_InvNumbering = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Notes/Style"
                    'M_NotesStyle = obj.ScalarExecute("Select SettingValue From Tbl_Settings Where SettingName = 'Notes/Style'")
                    M_NotesStyle = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice Print Copies" '"Textorium Inv #P"
                    M_TailoringInvoicePrintCopies = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                    'Case "Direct Invoice Print Copies"
                    '    M_DirectInvoicePrintCopy = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    '    Exit Select
                    'Case "On Save Print Needed (Sales Bill)"
                    '    M_OnSavePrint_SalesBill = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    '    Exit Select
                Case "Trial Date Required"
                    M_TrialDateRqrd = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Work Days (Yes/No)"
                    M_WorkDaysTabStop = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Print Piece Wise Measurement Slip"
                    M_PrintPcWiseMSlip = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "User Wise Invoice Prefix (Yes / No)"
                    M_UserWiseInvoicePrefix = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Zero Rate"
                    M_AllowZeroRate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Close Day"
                    M_CloseDay = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "DOB & Anni. Date in Quick Ledger Creation"
                    M_DobInQuickLedgerCreation = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice Report File Name"
                    M_TailoringInvRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice GST Report File Name"
                    M_TailoringInvRptFile_GST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "JobWork Report File Name"
                    M_JobWorkReport = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Order Report File Name"
                    M_TailoringOrderRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Bill Report File Name"
                    M_SalesBillRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Direct Invoice Report File Name"
                    M_DirectInvRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Measurement Report File Name"
                    M_MeasurementRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Master: Measurement Sheet File Name"
                    M_CustMaster_MeasurementRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                Case "Measurement Slip Type"
                    M_MeasurementSlipType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "SMS Sender Number"
                    M_SMSSenderNo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "SMS Sender Password"
                    M_SMSSenderPwd = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "SMS Sender Id"
                    M_SMSSenderId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "SMS Enabled"
                    M_SMSEnabled = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "SMS (On Save Tailoring Invoice)"
                    M_SMSOnSaveTI = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Duplicate Ledger Code"
                    M_AllwDupLcode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Duplicate Tailoring Item Code"
                    M_AllwDupTIcode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Duplicate Sales Item Code"
                    M_AllwDupSIcode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "SMS (On Save Worker Work Entry)"
                    M_SMSOWrkrWrk = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Preview SMS"
                    M_PreviewSMS = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Customer Name in Measurement Sheet"
                    M_ShowCustNameInMeasurementSheet = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Customer Mob. No. in Measurement Sheet"
                    M_ShowCustMobNoInMeasurementSheet = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Background Image"
                    M_BgImg = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Background Image Layout (None/Center/Stretch/Tile/Zoom)"
                    M_BackgroundImageLayout = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Dashboard At Startup"
                    M_DashboardOnStartUp = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Tailoring Invoice At Startup"
                    M_TailoringInvoiceOnStartUp = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Web API Enabled"
                    M_WebAPIEnabled = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Return: Auto Post Workers Work"
                    M_WorkRtnAutoPostEntry = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Return: Auto Post Status"
                    M_WorkRtnAutoPostStatus = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Barcode Label File Name"
                    M_BarcodeLabelFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Barcode Sheet File Name"
                    M_BarcodeSheetFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase: Barcode Sheet File Name"
                    M_PurchaseBarcodeSheetFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Barcode Label or Sheet"
                    M_BarcodeLabelSheet = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Allocation Slip Report File Name"
                    M_WorkAllocationSlipReportFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Work Days"
                    M_DefaultWorkDays = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Minimum Work Days"
                    M_MinimumWorkDays = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Trial Days"
                    M_DefaultTrialDays = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Name Character Casing"
                    M_CustNameCharCasing = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Item Character Casing"
                    M_TItemNameCharCasing = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Item Character Casing"
                    M_SalesItemCharCasing = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Invoice View (Tailoring/Sales)"
                    M_DefaultInvoiceView = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Item Selection Mode (Standard/Custom)"
                    M_SalesItemSelectionMode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Custom Mode: Code/Barcode/Purchase Barcode"
                    M_CustomModeValue = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Custom Text in Invoice"
                    M_CustomTextInInvoice = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Printable Items in Invoice"
                    M_PritableInvoiceItems = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Help Ledger List (Default/With Address)"
                    M_HelpLedgerList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Invoice Print After Confirming Change Amount"
                    M_InvoicePrintAfterChangeAmt = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Barcode Setting"
                    M_BarcodeSetting = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Top Rows"
                    M_TopRows = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Field Setting (Standard/Custom)"
                    M_FieldSetting = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Module" 'BSW, AURA, SSD
                    M_SalesModule = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Module" 'SSD1, BSW
                    M_PurchaseModule = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Order Module" 'SSD1, BSW
                    M_TailoringOrderModule = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Barcode Creation (Item Master/Purchase Entry)"
                    M_BarcodeCreation = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Ledger Balance In Invoice"
                    M_ShowLedgerBalanceInInvoice = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Cash Credit Sale Ledger Id"
                    M_CashCreditLedgerId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Type: CASH"
                    M_SalesTypeCash = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Type: CREDIT"
                    M_SalesTypeCredit = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Type: CARD"
                    M_SalesTypeCard = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Type: WALLET"
                    M_SalesTypeWallet = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TAILORING LEDGER"
                    M_TailoringLedger = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Person Compulsory in Tailoring Invoice"
                    M_SalesPersonCompulsoryInTailoringInv = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Address Message for Due Amount Bill"
                    M_CustAddMsgForDueBill = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Specify Profit % for MRP in Purchase"
                    M_SpecifyProfitPerForMRPInPurchase = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Profit % for MRP in Purchase"
                    M_DefaultProfitPerForMRPInPurchase = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Consider GST For Profit Per (Yes/No)"
                    M_ConsiderGSTForProfitPer = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                Case "Offer Rate Applicable: Tailoring Item (Yes/No)"
                    M_OfferRateApplicableTI = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Offer Rate Applicable: Sales Item (Yes/No)"
                    M_OfferRateApplicableSI = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Worker Wise Item Rates (Yes/No)"
                    M_WorkerWiseItemRates = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "LedgerId: Purchase Ledger (For First Time Data)"
                    M_LedgerIdOpeningStock = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "PurchaseId: Opening Stock Purchase Entry"
                    M_PurchaseIdOpeningStock = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Post Entry In PurchaseDetail for Opening Stock (Yes/No)"
                    M_PostEntryInPurchaseDetailForOpeningStock = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "INPUT CGST"
                    M_InputCGST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "INPUT SGST"
                    M_InputSGST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "INPUT IGST"
                    M_InputIGST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "OUTPUT CGST"
                    M_OutputCGST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "OUTPUT SGST"
                    M_OutputSGST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "OUTPUT IGST"
                    M_OutputIGST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Purchase Taxation"
                    M_PurchaseDefaultTaxation = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Sales Taxation"
                    M_SalesDefaultTaxation = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Purchase Bill Type"
                    M_PurchaseDefaultBillType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Sales Bill Type"
                    M_SalesDefaultBillType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Entry GST Calculation (Item Wise/Bill Wise)"
                    M_PurchaseEntryGSTCalculationOn = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Entry GST Calculation (Item Wise/Bill Wise)"
                    M_SalesEntryGSTCalculationOn = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Item Wise GST Amount Rounding"
                    M_PurchaseItemWiseGSTRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Item Wise GST Amount Rounding"
                    M_SalesItemWiseGSTRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Bill GST Amount Rounding"
                    M_PurchaseBillGSTRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Bill GST Amount Rounding"
                    M_SalesBillGSTRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "AQty Rounding"
                    M_AQtyRoundnig = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Bill Amount Rounding"
                    M_PurchaseBillAmtRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Bill Amount Rounding"
                    M_SalesBillAmtRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Item Discount Rounding"
                    M_SalesItemDiscountRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Item Discount Rounding"
                    M_PurchaseItemDiscountRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Bill Discount Rounding"
                    M_SalesBillDiscountRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Bill Discount Rounding"
                    M_PurchaseBillDiscountRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Square Meter Rounding"
                    M_SqMtrRoundnig = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Rate (Inclusive/Exclusive)"
                    M_PurchaseRateEI = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Rate (Inclusive/Exclusive)"
                    M_SalesRateEI = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase: Help Ledger List (NameMobile/MobileName)"
                    M_PurchaseHelpLedgerList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales: Help Ledger List (NameMobile/MobileName)"
                    M_SalesHelpLedgerList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Item Total Rounding"
                    M_PurchaseItemTotalRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Item Total Rounding"
                    M_SalesItemTotalRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Item Help List"
                    M_ItemHelpList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Stock Calculation Field (Qty/SqMtr)"
                    M_StockCalcField = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Stock Quantity Rounding"
                    M_StockQtyRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Update Sales Rate In Item Master While Saving Purchase Entry (Barcode Creation=Item Master)"
                    M_UpdateSalesRateInItemMasterWhilePurchaseEntry = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Voucher Groups for Ledger Account Report Amount Field"
                    M_VGrpForLacAmt = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Barcode Text (Numeric/Alpha Numeric)"
                    M_BarcodeText = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Company Wise Misc. Master"
                    M_CompanyWiseMiscMaster = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Company Wise Purchase (Yes/No)"
                    M_CompanyWisePurchase = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice: Help Ledger List (All Company/Same Company)"
                    M_TIHelpLedgerList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice: Tailoring Item List (All Company/Same Company)"
                    M_TailoringItemList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right Click: Send SMS (Booking)"
                    M_TIRightClickBookingSMS = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right Click: Send SMS (Ready)"
                    M_TIRightClickReadySMS = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right Click: Send SMS (Trial)"
                    M_TIRightClickTrialSMS = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right Click: Send SMS (Delivery)"
                    M_TIRightClickDeliverySMS = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right Click: Send SMS (Due)"
                    M_TIRightClickDueSMS = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: Item Lable Print"
                    M_TIRightClickItemLabelPrint = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Worker Work Entry (Invoice Wise/Remark Wise)"
                    M_WorkerWorkEntry = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Production Output LedgerId"
                    M_ProductionOutputLedgerId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Production Output PurchaseId"
                    M_ProductionOutputPurchaseId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: Feedback"
                    M_TIRightClickFeedback = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: View Image Sheet"
                    M_TIRightClickViewImageSheet = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: Attachment"
                    M_TIRightClickAttachment = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Printer Name (For Barcode)"
                    M_BarcodePrinterName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Printer Name (For Invoice)"
                    M_RegularPrinterName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Printer Name (For Measurement Sheet)"
                    M_MeasurmentPrinterName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Item Code Searching (Regular/Exact)"
                    M_ItemCodeSearching = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Barcode Searching (Regular/Exact)"
                    M_BarcodeSearching = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Item Sorting (Code/Name)"
                    M_TailoringItemSorting = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tax Calculation (GST/VAT)"
                    M_TaxCalculation = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Notes Font Name"
                    M_NotesFontName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Notes Font Size"
                    M_NotesFontSize = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Parameter Font Name"
                    M_ParaFontName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Parameter Font Size"
                    M_ParaFontSize = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Parameter Column Width"
                    M_ParaColWidth = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Item Master"
                    M_TailoringItemMaster = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Update Ready Qty After"
                    M_UpdateReadyQtyAfter = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice Numbering (Standard/Series)"
                    M_TINumbering = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Old Tailoring Invoice Form Name"
                    M_Old_TailoringInvoiceFormName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "General Measurements TItemId"
                    M_GeneralMeasurementTItemId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Measurement Fetch Setting (Default/General/Customer Master)"
                    M_MeasurementFetchSetting = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Mobile Number Length"
                    M_MobileNoLength = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Validate Mobile Number Length"
                    M_ValidateMobileNoLength = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Language (ENG/GK)"
                    M_Language = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Generate Invoice Number Separately"
                    M_GenInvNumSeparately = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: Attachment"
                    M_callingForm_FabricAttachment = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                    '---
                Case "Auto Add Sales Item On Enter or Barcode Scan (Yes/No)"
                    M_AutoAddSalesItem = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Sales Item Quantity"
                    M_DefaultSalesItemQty = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Auto Bank Reconciliation Entry (Yes/No)"
                    M_AutoBankReco = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Customer Required (Yes/No)"
                    M_DefaultCustRequired = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Invoice Number Read Only (Yes/No)"
                    M_InvoiceNumberReadOnly = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Required: Receipt Details in Sales (Yes/No)"
                    M_RequiredReceiptDetailsInSales = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Invoice Date (Yes/No)"
                    M_TabStopSalesInvDate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Bill Type (Yes/No)"
                    M_TabStopSalesBillType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Credit Days (Yes/No)"
                    M_TabStopSalesCreditDays = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Bill Number (Yes/No)"
                    M_TabStopSalesBillNo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Customer Ledger Id"
                    M_DefaultCustLedgerId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Sales Type"
                    M_SalesDefaultType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Ledger Id"
                    M_SalesId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Reference (Yes/No)"
                    M_TabStopSalesRef = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Type (Yes/No)"
                    M_TabStopSalesType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Auto Generate Sub Items In Invoice Detail"
                    M_AutoGenSubItems = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Enable Material & Work Issue"
                    M_EnableMaterialAndWorkIssue = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Loyalty Point Program Enable (Yes/No)"
                    M_EnableLoyaltiPointProgram = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Loyalty Point Base (TaxableAmt/InvAmt)"
                    M_LoyaltiPointBase = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "1 Loyalty Point Equal To"
                    M_1LoyaltiPointEqualTo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "1 Loyalty Point Redemption Equal To"
                    M_1LoyaltiPointRedemptionEqualTo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Minimum Loyalty Points Redemption Equal To"
                    M_MinLoyaltiPointsRedemptionEqualTo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Loyalty Points Validity In Days"
                    M_LoyaltiPointsValidity = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select

                Case "Referral Program Enabled (Yes/No)"
                    M_ReferralProgramEnabled = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Minimum Referral Amount"
                    M_MinimumReferralAmount = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Referral Point Base (TaxableAmt/InvAmt)"
                    M_ReferralPointBase = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "1 Referral Point Equal To"
                    M_1ReferralPointEqualTo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "1 Referral Point Redemption Equal To"
                    M_1ReferralPointRedemptionEqualTo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Minimum Referral Points Redemption Equal To"
                    M_MinReferralPointsRedemptionEqualTo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Referral Points Validity In Days"
                    M_ReferralPointsValidity = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select

                Case "Pending Work Issuance: Default Work Type"
                    M_PendingWorkIssue_DefaultWorkIssueType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Check Production Limit (Yes/No)"
                    M_CheckProductionLimit = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Production Limit (Item Wise / Group Wise)"
                    M_ProdLimit_ItemGroupWise = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Issue Quantity Read Only (Yes/No)"
                    M_WorkIssueQuantityReadOnly = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Work Issue Quantity"
                    M_DefaultWorkIssueQuantity = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Master"
                    M_CustomerMaster = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Generate Order Number Save Time (Yes/No)"
                    M_GenerateOrderNumberSaveTime = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Generate Customer Number Save Time (Yes/No)"
                    M_GenerateCustomerNumberSaveTime = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Worker Work Entry Report File Name"
                    M_WorkerWorkEntryRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Rates in Stock Statement (Yes/No)"
                    M_ShowRatesInStockStatement = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Ignore Sales Qty in Stock Statement (Yes/No)"
                    M_IgnoreSalesQtyInStockStatement = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Ignore Material Issue Qty in Stock Statement (Yes/No)"
                    M_IgnoreMaterialIssueQtyInStockStatement = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Management Module"
                    M_WorkManagementModule = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "PRN CMD"
                    M_PrnCmd = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice Series"
                    M_TailoringInvoiceSeries = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Trial Quantity In Tailoring Order (Yes/No)"
                    M_ShowTrialQtyInTailoringOrder = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Production No In Tailoring Order (Yes/No)"
                    M_ShowProductionNoInTailoringOrder = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Issue Slip Required"
                    M_WorkIssueSlipRequired = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Price Code"
                    M_PurchasePriceCode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Wise Worker(Yes/No)"
                    M_WorkWiseWorker = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Fraction Measurement Input (Yes/No)"
                    M_FractionMeasurementInput = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Focus On Ok Button After Mobile/Address"
                    M_FocusOnOkButtonAfterMobileAddress = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Type Show Yes/No"
                    M_CustomerTypeShow = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "DTM for SP"
                    M_DTMforSP = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "DTM for Query"
                    M_DTMforQuery = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "PC DTM"
                    M_PCDTM = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Hide GST Columns"
                    M_HideGSTColumns = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Dashboard ItemType"
                    M_Dashboard_ItemType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Dashboard ItemSubType"
                    M_Dashboard_ItemSubType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Item Master (Standard / Retail)"
                    M_SalesItemMaster = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase: GST Credit (Yes/No)"
                    M_Purchase_GSTCredit = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales: GST Debit (Yes/No)"
                    M_Sales_GSTDebit = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice Ready Qty: Read Only (Yes/No)"
                    M_TI_ReadyQty_ReadOnly = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Manual InvoiceNo And Date (Yes/No)"
                    M_ManualInvoiceNoAndDate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Item Rate (Yes/No)"
                    M_TabStopSalesItemRate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Item Qty (Yes/No)"
                    M_TabStopSalesItemQty = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Purchase Document Date (Yes/No)"
                    M_TabStopPurchaseDocumentDate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Purchase Credit Days (Yes/No)"
                    M_TabStopPurchaseCreditDays = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Transport (Yes/No)"
                    M_DefaultTransport = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Transport Ledger Id"
                    M_DefaultTransportLedgerId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Code Required (Yes/No)"
                    M_CustCodeRequired = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Reference Required in Tailoring Order (Yes/No)"
                    M_RefRequiredInTailoringOrder = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "User Wise Company (True / False)"
                    M_UserWiseCompany = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Item Discount (Yes/No)"
                    M_TabStopSalesItemDiscount = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tab Stop: Sales Required On Invoice (Yes/No)"
                    M_TabStopSalesRequiredOnInvoiceYesNo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "New Invoice Number Generation Date (dd/MM/yyyy)"
                    M_NewInvoiceNumberGenerationDate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Invoice Delivery Qty: Read Only (Yes/No)"
                    M_TI_DeliveryQty_ReadOnly = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Advance Amount(Yes/No)"
                    M_AllowAdvanceAmount = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Print Blank Measurement In MSlip (Yes/No)"
                    M_PrintBlankMeasurementInMSlip = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Order List (FinYear / 30 Days / 60 Days)"
                    M_TailoringOrderList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Workers Work (Direct Entry)"
                    M_WorkerWorkDirectEntry = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Item Name With Remark (Yes/No)"
                    M_ItemNameWithRemark = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Production Ledger Id"
                    M_DefaultProductionLedgerId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Negative Sales (Yes/No)"
                    M_AllowNegativeSales = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Use Other Database (Yes/No)"
                    M_UseOtherDatabase = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Item Rate ReadOnly (Yes/No)"
                    M_ItemRateReadOnly = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "GST Ledger Id List"
                    M_GSTLedgerList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Group List: General Purchase Credit Ledger"
                    M_GroupList_GPCrLedger = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Group List: General Purchase Debit Ledger"
                    M_GroupList_GPDrLedger = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Group List: General Purchase Return Credit Ledger"
                    M_GroupList_GPRCrLedger = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Return Ledger Id"
                    M_PurchaseReturnId = Val(M_dsSettings.Tables(0).Rows(i)("SettingValue"))
                    Exit Select
                Case "Sales Return Ledger Id"
                    M_SalesReturnId = Val(M_dsSettings.Tables(0).Rows(i)("SettingValue"))
                    Exit Select
                Case "Profit Group Panel Show in Dashboard (Yes/No)"
                    M_ProfitGroupPanelShowInDashboard = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Total Due Amt In Invoice (Yes/No)"
                    M_ShowTotalDueAmtInInvoice = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Non GST supply (LedgerId)"
                    M_NonGSTsupplyLedgerId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Transport Service Expense Id"
                    M_TSExpenseId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Consider Rate Wise GST In Sales (Yes/No)"
                    M_ConsiderRateWiseGSTInSales = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Consider Rate Wise GST In Purchase (Yes/No)"
                    M_ConsiderRateWiseGSTInPurchase = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Consider Rate Wise GST In Tailoring (Yes/No)"
                    M_ConsiderRateWiseGSTInTailoring = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Multiple Payment Mode(Yes/No)"
                    M_ShowMultiplePaymentMode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Get Sales VId"
                    M_GetSalesVId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Standard Qty In Material Issuance(Yes/No)"
                    M_ShowStandardQtyInMaterialIssuance = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Brokerage Calculate On (Sales)"
                    M_SalesBrokerageCalcOn = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Brokerage Rounding"
                    M_BrokerageRounding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Save Product Details In BillNo_BillDt (Yes/No)"
                    M_SaveProductDetailsInBillNo_BillDt = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Brokerage Expense Ledger Id"
                    M_BrokerageExp = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Duplicate Invoice No"
                    M_AllwDupInvoiceNo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Image Collection Path"
                    M_ImageCollPath = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Stock Statement"
                    M_StockStatement = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "SALES GLASS QTY (SqMtr/SqFt)"
                    M_SalesGlassQtySqMtrSqFt = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp Registered MobileNo"
                    M_WhatsAppRegisteredMobileNo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp Login Password"
                    M_WhatsAppLoginPassword = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Preview WhatsApp"
                    M_PreviewWhatsApp = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp Enabled"
                    M_WhatsAppEnabled = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Whatsapp Instance Id"
                    M_WhatsappInstanceId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp (On Save Tailoring Invoice: NA/Text/Text+PDF/PDF)"
                    M_WhatsappOnSaveTimeTextPDF = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "QT_CompanyMaster_CID"
                    M_QT_Company_ID = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Delivery Date (Less Days For Workers)"
                    M_DeliveryDateLessDaysForWorker = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Notify Customer: After Delivery Date Change (Yes/No)"
                    M_NotifyCustChangeDeliDate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                Case "Customer Creation: Name Required (Yes/No))"
                    M_CustCreationNameRqrd = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Creation: Mobile No Required (Yes/No))"
                    M_CustCreationMobileRqrd = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Square Feet Rounding"
                    M_SqFtRoundnig = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Running Feet Rounding"
                    M_RFRoundnig = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Square Feet Division Value"
                    M_SqFtDF = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Square Mtr Division Value"
                    M_SqMtrDV = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Running Feet Division Value"
                    M_RFtDF = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Fabric Margine"
                    M_FabricMargine = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Measurement Panel in Tailoring Order"
                    M_ShowMeasurmentPanelinTailoringOrder = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Bill Edit (OTP/Password/NA)"
                    M_BillEditOTP = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Bill Delete (OTP/Password/NA)"
                    M_BillDeleteOTP = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Reset Sales Invoice Number On Daily Basis (Yes/No)"
                    M_ResetSalesInvoiceNumberOnDailyBasis = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Barcode File Name"
                    M_TailoringBarcodeFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Companies"
                    M_CustomerCompanies = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Item Companies"
                    M_TailoringItemCompanies = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Item Companies"
                    M_SalesItemCompanies = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Main Store CId List"
                    M_MainStoreCIdList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Use Tailoring Barcodes (Yes/No)"
                    M_UseTailoringBarcodes = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Barcode Start From"
                    M_TailoringBarcodeStartFrom = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Upload Doc File Path"
                    M_UploadDocFilePath = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Use Barcode Wise Measurment Sheet (Yes/No)"
                    M_UseBarcodeWiseMeasurmentSheet = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                'Case "Country Code"
                '    M_CountryCode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                '    Exit Select
                Case "GST % Change On Non-Tailoring Item (Yes/No)"
                    M_GSTPerChangeOnNonTailoringItem = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Create New Barcode On Purchase Time (Yes/No)"
                    M_CreateNewBarcodeOnPurchaseTime = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: View Order"
                    M_TIRightClickViewOrder = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: View Tailoring Barcode"
                    M_TIRightClickViewTailoringBarcode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Tailoring Item Image Path"
                    M_TailoringItemImagePath = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: Track Barcode"
                    M_TIRightClickTrackBarcode = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Dashboard : Show Delivered Item (Yes/No)"
                    M_Dashboard_ShowDeliverdItem = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Send SMS : Delivery Time (Yes/No)"
                    M_SMS_DeliveryTime = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Application Logout Time BackUp(Yes/No)"
                    M_AppLogoutExitTimeBackUp = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Auto Fill Receipt Amt On Focus (Yes/No)"
                    M_AutoFillReceiptAmtOnFocus = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Manage Work Return Item / Salary Wise (Yes/No)"
                    M_ManageWR_Item_Salary_Wise = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Set Auto Delivery Date As Per Item Group (Yes/No)"
                    M_DeliveryDate_AsPer_ItemGroup = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Check Black List Customer (Yes/No)"
                    M_Block_BlackListCustomer = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Employee Active Salary Day(s) (MON Format)"
                    M_EmpSalaryDays = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show Deleted Record"
                    M_ShowDeletedRecord = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Master Grid Row Back Color"
                    M_GridRowBackColor = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Master Grid Cell Back Color"
                    M_GridCellBackColor = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Master Grid Row Fore Color"
                    M_GridRowForeColor = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Master Grid Cell Fore Color"
                    M_GridCellForeColor = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Check Reference Duplicate Reference In TI (Yes/No)"
                    M_CheckReferenceInTI = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Common Cash / Bank Ledger Id For All (Branch/Company)"
                    M_CommonCashBankLedgerId = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Whatsapp Msg Outstanding Type"
                    M_OutStandingReportMsgType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Whatsapp Msg Outstanding (Delivery Done)"
                    M_OutStandingDeliDone = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                    'Case "Dashboard : Show Delivered Item (Yes/No)"
                    '    M_Dashboard_ShowDeliverdItem = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    '    Exit Select

                    'Case "Dashboard : Show Delivered Item (Yes/No)"
                    '    M_Dashboard_ShowDeliverdItem = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    '    Exit Select
                Case "Image Upload Size In KB"
                    M_ImageUploadSize = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Barcode Based Workshop Management (Yes/No)"
                    M_Barcode_Based_Workshop_Management = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Measurement By Compulsory in Tailoring Invoice"
                    M_MeasurementByCompulsoryInTailoringInv = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Worker Payment Slip"
                    M_WorkerPaymentSlipRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Day: Employee Payment Entry"
                    M_DayEmpPmtEntry = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Day: Sales Commission Payment Entry"
                    M_DaySalesCommissionPmtEntry = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                Case "Branch Wise Sales Rate (Yes/No)"
                    M_BranchWiseSalesRate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Finishing Measurement (Yes/No)"
                    M_FinishingMeasurement = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Select Fabric After Tailoring Item (Yes/No)"
                    M_SelectFabricAfterTailoringItem = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Tailoring Item Selection in Sales (Yes/No)"
                    M_AllowTailoringItemSelectionInSales = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Use Cutting Formula (Yes/No)"
                    M_UseCuttingFormula = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Type Required (Yes/No)"
                    M_CustomerTypeRequired = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Less Days For From Year"
                    M_LessDaysForFromYear = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Pending Delivery Report File Name"
                    M_PendingDeliveryReportFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Ledger List Order By (Code/LedgerName)"
                    M_OrderByLedger = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Company Wise Customer Load (Yes/No)"
                    M_CompanyWiseCustomerLoad = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Previous Day Bill Allow Edit/Delete (Yes/No)"
                    M_PrevDayBillEditDelete = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Time Barcode PCS Wise (Regular/Unique)"
                    M_PurchaseTimeBarcodePCSWise = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Time Unique Barcode Start From"
                    M_PurchaseTimeUniqueBarcodeStartFrom = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Time Reference Item Auto Create(Yes/No)"
                    M_PurchaseRefItemAuto = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Use Dhara From Ledger Master For Purchase (Yes/No)"
                    M_UseDharaFromLedgerMasterForPurchase = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Issue / Receipt Module Name"
                    M_WorkIR_Module = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Salesman Payment Slip Report File"
                    M_SalesmanPaymentSlipRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Salesman Commission (Bill Wise/Item Wise)"
                    M_SalesmanCommissionBillWiseItemWise = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Use Purchase Order System (Yes/No)"
                    M_UsePurchaseOrder = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase Order Report File Name"
                    M_PurchaseOrderReportFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "PO For Branch Report File Name"
                    M_POForBranchReportFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Stitching Detail Report File Name"
                    M_CustStichDetailReportFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right CLick: View Stitchin Detail"
                    M_TIRightClickViewStitchingDetail = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Multi Country Mobile Series (Yes/No)"
                    M_AllowMultiCountryMobileSeries = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Cash/Bank Report File Name"
                    M_CashBankReportFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Cheque Print (Yes/No)"
                    M_AllowChequePrint = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Expense Print (Yes/No)"
                    M_AllowExpensePrint = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Filter Tailoring Item"
                    M_FilterTailoringItem = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Filter Product Item"
                    M_FilterProductItem = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Send Whatsapp To Onwner No"
                    M_SendWhatsappToOnwnerNo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right Click: Update Trial And Delivery Date (Yes/No)"
                    M_TIRightClickUpdateTrialAndDeliveryDate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Use Notify Pending Delivery (Yes/No)"
                    M_UseNotifyPendingDelivery = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Timer Interval In Minutes"
                    M_TimerInterval = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Customer Weight Compulsory In Tailoring Invoice"
                    M_CustomerWeightCompulsoryInTailoringInv = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Fraction Notes Input (Yes/No)"
                    M_FractionNotesInput = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "On Save Payment: Expense Slip Print (Yes/No)"
                    M_OnSavePaymentExpenseSlipPrint = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Qty Update In Tailoring Invoice (Yes/No)"
                    M_QtyUpdateInTailoringInvoice = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Autobackup File Path"
                    M_AutobackupFilePath = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Trial WhatsApp Sent On Work Done (Yes/No)"
                    M_TrialWhatsAppSentOnWorkDone = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Item Master: Item Image Path"
                    M_ItemMasterItemImagePath = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Sales Item List (All Company/Same Company)"
                    M_SalesItemList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "CC Whatsapp: Whatsapp On Save Time Send Invoice (Yes/No)"
                    M_CCWhatsappWhatsappOnSaveTimeSendInvoice = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "CC Whatsapp: Whatsapp On Save Time Send Text (Yes/No)"
                    M_CCWhatsappWhatsappOnSaveTimeSendText = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "CC Whatsapp: Mobile No"
                    M_CCWhatsappMobileNo = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "CC Whatsapp: Whatsapp On After Ready Qty Update (Yes/No)"
                    M_CCWhatsappWhatsappOnAfterReadyQtyUpdate = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Print Tailoring Tag (Yes/No)"
                    M_PrintTailoringTag = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Combine Item: Rate x (Mtr/Pcs)"
                    M_CombineItemRatexMtrPcs = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Dashboard : Merge Report File Name"
                    M_DashboardMergeRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "TI Right Click: Send Booking WhatsApp (NA/Text/Text+PDF/PDF)"
                    M_TIRightClickBookingWhatsApp = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Ready WhatsApp Sent On Work Done (Yes/No)"
                    M_ReadyWhatsAppSentOnWorkDone = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Ledger List (All Company/Same Company)"
                    M_LedgerList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp: On Collect Payment Time (Yes/No)"
                    M_WhatsAppOnCollectPaymentTime = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Reciept Print (Yes/No)"
                    M_AllowReceiptPrint = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Issue Challan Report File Name"
                    M_WorkIssueChallanReportFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp: On Delivery Time (Yes/No)"
                    M_WhatsappOnDeliveryTime = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp: On Loyalty Point Generation (Yes/No)"
                    M_WhatsAppOnLoyaltyPointGeneration = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp: On Refferal Point Generation (Yes/No)"
                    M_WhatsAppOnRefferalPointGeneration = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Issue Slip File Name"
                    M_WorkIssueSlipFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Today date On Add Click Time (Yes/No)"
                    M_TodaydateOnAddClickTime = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Consider Stock Data After"
                    M_ConsiderStockDataAfter = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Zero Wages (Yes/No)"
                    M_AllowZeroWages = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Debit Note Report File Name"
                    M_DebitNoteRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Credit Note Report File Name"
                    M_CreditNoteRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Stock Transfer Report File Name"
                    M_StockTransferRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Allow Webcam Capture Image (Yes/No)"
                    M_AllowWebcamCaptureImage = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Divide By: + In Measurement Slip"
                    M_DivideByInMeasurementSlip = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Workers CId List"
                    M_WorkersCIdList = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Genisys Conpath"
                    M_GenisysConpath = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Dashboard: Receipt Print Detail File Name"
                    M_DashboardReceiptPrintDetailFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Dashboard: Receipt Print Summary File Name"
                    M_DashboardReceiptPrintSummaryFileName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Delivery Date Optional"
                    M_DeliveryDateOptional = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Worker Management (Basic/IssueReturn)"
                    M_WorkerManagement = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Notes/Style Read Only (Yes/No)"
                    M_NotesStyleReadOnly = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Notes/Style Charges Read Only (Yes/No)"
                    M_NotesStyleChargesReadOnly = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Stock Statement: Ignore PRODUCT Qty (Yes/No)"
                    M_StockStatementIgnorePRODUCTQty = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    ' And UOM_SD <> 'PRODU' 
                    Exit Select
                Case "Show Worker On Tailoring Item Delivery (Yes/No)"
                    M_ShowWorkerOnTailoringItemDelivery = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Show WorkIssue Company Wise (Yes/No)"
                    M_ShowWorkIssueCompanyWise = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "On Save Print Needed (Tailoring Measurement)"
                    M_OnSavePrint_TailoringMeas = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Quick Work Allocation (Yes/No)"
                    M_QuickWorkAllocation = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Work Assign Qty (Default/Custom)"
                    M_WorkAssignQty = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                Case "EWay GSTN"
                    M_EwayCompGST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "EWay User Name"
                    M_EwayUserName = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "EWay Password"
                    M_EwayPwd = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "EWay URL"
                    M_EwayUrl = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Duplicate MobileNo Genrated Meassage (Yes/No)"
                    M_DupMobGenMessage = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Fabric Issue To Worker (Yes/No)"
                    M_FabricIssueToWorker = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Dashboard Show Complete Orders Only (Yes/No)"
                    M_DashboardShowCompleteOrdersOnly = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Invoice Master In Show Ledger Closing Balance (Yes/No)"
                    M_InvoiceMasterInShowLedgerCloBal = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "AdjustAmt In ExtraCharge For Worker Per(%)"
                    M_AdjustAmtInExtraChargeForWorker = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Measurement: Measurement Image Path"
                    M_MeasurementImgPath = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Styles: Styles Image Path"
                    M_StyleImgPath = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Send WhatsApp Work Slip (Yes/No)"
                    M_SendWhatsAppWorkSlip = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "WhatsApp (On Save Rental Invoice: NA/Text/Text+PDF/PDF)"
                    M_WhatsappOnSaveTimeRITextPDF = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "On Save Print Needed (Rental Invoice)"
                    M_OnSavePrint_RentalInv = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Rental Invoice Report File Name"
                    M_RentalInvRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Rental Invoice GST Report File Name"
                    M_RentalInvRptFile_GST = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Rental Invoice In GST Applicable (Yes/No)"
                    M_RentalInvGSTApp = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Retail: Want ItemWise Branding (Yes/No)"
                    M_RetailWantItemWiseBranding = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Dynamic Report Layouts"
                    M_DynamicRepLayout = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Delivery: Outstanding Payment Report File Name"
                    M_OutstandingPayRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Purchase: Allow PurchaseRate Zero (Yes/No)"
                    M_AllowPurchaserateZero = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Default Recipt Type"
                    M_DefaultReciptType = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Delivery: Show Deliverd Item Report (Yes/No)"
                    M_ShowDeliItemReport = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
                Case "Delivery: Deliverd Item Report File Name"
                    M_DeliveryItemRptFile = M_dsSettings.Tables(0).Rows(i)("SettingValue")
                    Exit Select
            End Select
        Next

        M_SMSAPI = obj.ScalarExecute("Select MiscName From tbl_MiscMaster Where MiscType = 'SMS API' And IsActive = 'True'")
        M_GetSMSBalAPI = obj.ScalarExecute("Select MiscName From tbl_MiscMaster Where MiscType = 'GET SMS BALANCE API' And IsActive = 'True'")
    End Sub

    Public Sub M_exportToExcel(ByVal grdData As DataGridView, ByVal frm As Form)
        If grdData.Rows.Count = 0 Then
            MsgBox("No Records Found", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim wBook As New Excel.Workbook

        '========================================================================================
        'Exporting to Excel
        '========================================================================================
        'Creating dataset to export
        Dim grd As DataGridView = grdData
        Dim visibleCols As Integer = 0
        Dim dset As New DataSet
        'add table to dataset
        dset.Tables.Add()
        'add column to that table
        For i As Integer = 0 To grd.ColumnCount - 1
            If grd.Columns(i).Visible = True Then
                dset.Tables(0).Columns.Add(grd.Columns(i).HeaderText)
                visibleCols = visibleCols + 1
            End If
        Next
        Dim colList(visibleCols - 1) As String
        Dim cnt As Integer = 0
        For i As Integer = 0 To grd.ColumnCount - 1
            If grd.Columns(i).Visible = True Then
                colList(cnt) = grd.Columns(i).Name
                cnt = cnt + 1
            End If
        Next
        'add rows to the table
        Dim dr1 As DataRow
        For i As Integer = 0 To grd.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            'For j As Integer = 0 To grd.Columns.Count - 1
            For j As Integer = 0 To colList.GetUpperBound(0)
                dr1(j) = grd.Rows(i).Cells(colList(j)).Value
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next

        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dset.Tables(0)
        Dim dc As System.Data.DataColumn
        Dim drow As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            excel.Cells(1, colIndex) = dc.ColumnName
        Next

        For Each drow In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                excel.Cells(rowIndex + 1, colIndex) = drow(dc.ColumnName)
            Next
        Next

        wSheet.Columns.AutoFit()
        wSheet.Range("A1", "AZ1").Font.Bold = True

        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All Files (*.*)|*.*"
        If (SaveFileDialog.ShowDialog(frm) = System.Windows.Forms.DialogResult.OK) Then
            strFileName = SaveFileDialog.FileName
            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If

            wBook.SaveAs(strFileName)

            MsgBox("Data Exported Successfully", MsgBoxStyle.Information)
        End If
    End Sub

    Public Sub sendSMS(ByVal toNum As String, ByVal msgTxt As String, ByVal invId As Integer, ByVal smsType As String, Optional ByVal templateId As String = "")
        If M_SMSAPI = Nothing Or M_SMSAPI = "" Then
            MsgBox("Please Specify SMS API Settings", MsgBoxStyle.Information)
            Exit Sub
        End If

        If isInternetOn() = False Then
            Exit Sub
        End If

        msgTxt = HttpUtility.UrlEncode(msgTxt)
        msgTxt = msgTxt & templateId

        Try
            Dim tmpSMSAPI As String = M_SMSAPI
            Dim _field, _replace As String
            While tmpSMSAPI.Contains("{")
                _field = tmpSMSAPI.Substring(tmpSMSAPI.IndexOf("{") + 1, tmpSMSAPI.IndexOf("}") - tmpSMSAPI.IndexOf("{") - 1)
                _replace = tmpSMSAPI.Substring(tmpSMSAPI.IndexOf("{"), tmpSMSAPI.IndexOf("}") - tmpSMSAPI.IndexOf("{") + 1)
                Select Case _replace
                    Case "{SenderNo}"
                        tmpSMSAPI = tmpSMSAPI.Replace(_replace, M_SMSSenderNo)
                        Exit Select
                    Case "{Pwd}"
                        tmpSMSAPI = tmpSMSAPI.Replace(_replace, M_SMSSenderPwd)
                        Exit Select
                    Case "{SenderId}"
                        tmpSMSAPI = tmpSMSAPI.Replace(_replace, M_SMSSenderId)
                        Exit Select
                    Case "{ToNo}"
                        tmpSMSAPI = tmpSMSAPI.Replace(_replace, toNum)
                        Exit Select
                    Case "{Msg}"
                        tmpSMSAPI = tmpSMSAPI.Replace(_replace, msgTxt)
                        Exit Select
                End Select
            End While

            ServicePointManager.SecurityProtocol = DirectCast(&HC0 Or &H300 Or &HC00, SecurityProtocolType)

            'Dim req As HttpWebRequest = WebRequest.Create("http://sms.sunrisesoftware.in/sendsms.aspx?mobile=" & M_SMSSenderNo & "&pass=" & M_SMSSenderPwd & "&senderid=" & M_SMSSenderId & "&to=" & toNum & "&msg=" & msgTxt)
            Dim req As HttpWebRequest = WebRequest.Create(tmpSMSAPI)
            Dim resp As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
            Dim respStrmRdr As New System.IO.StreamReader(resp.GetResponseStream())
            If toNum.Length > 10 Then
                MsgBox(respStrmRdr.ReadToEnd())
            Else
                cntSMS = cntSMS + 1
            End If
            respStrmRdr.Close()
            resp.Close()

            insert_SMSTrail(invId, smsType)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub sendWhatsApp_Text(ByVal toMoNum As String, ByVal msgTxt As String, ByVal filePath As String, ByVal captionText As String, ByVal countryCode As String)
        If M_WhatsappInstanceId = Nothing Or M_WhatsappInstanceId = "" Then
            MsgBox("Please Specify WhatsApp Instance Id", MsgBoxStyle.Information)
            Exit Sub
        End If

        If isInternetOn() = False Then
            Exit Sub
        End If

        If countryCode = "" Then
            countryCode = "91"
        End If

        'Create Instance On Application Startup:-
        Dim ClsNotificationApp_I As ClsNotificationApp

        ClsNotificationApp_I = New ClsNotificationApp(M_WhatsappInstanceId, "enotify.app") '"60ba1543ff77dd08602c3c51"

        Dim ApiResult As String = ""

        'To Send Text:-

        ApiResult = ClsNotificationApp_I.SendText(countryCode.Replace("+", "") & toMoNum, msgTxt) '"919727001838" ,"JSN"

        'To Send File:-
        'ApiResult = ClsNotificationApp_I.SendFile("91" & toMoNum, filePath) '"919727001838" ,"D:\Bhavika_SSD\Demo.pdf"

        'To Send File with Caption:-
        'ApiResult = ClsNotificationApp_I.SendFileWithText("91" & toMoNum, filePath, captionText) '"919727001838", "D:\Bhavika_SSD\436175.jpg","Caption_JSN"

        'To Send Contact:-
        'ApiResult = ClsNotificationApp_I.SendContact("919727001838", "ContactName", "ContactPhone")

        'To Send Location:-
        'ApiResult = ClsNotificationApp_I.SendLocation("919727001838", "Latitude", "Longitude", "LocationName", "LocationAddress", "URL")

        'To Get Balance:-
        'ApiResult = ClsNotificationApp_I.CheckBalance()

        'To Get QrCode:-
        'ApiResult = ClsNotificationApp_I.Get_QRCode()

        'To Get Message Status:-
        'ApiResult = ClsNotificationApp_I.Get_CampaignStatus("MessageId")

        ''To Get Delivery Report:-
        'ApiResult = ClsNotificationApp_I.Get_CampaignReport(CampaignType, CampaignStatus, "StartDate", "EndDate", NoOfMessage)
        ''CampaignType:- Quick/Bulk/All
        ''CampaignStatus:- Error_Status/Success_Status/All_Status
        ''StartDate/EndDate:- In dd-mm-yyyy Format Only

        ''To Get Inbox Report:-
        'ApiResult = ClsNotificationApp_I.ReadInbox("FromDate", "ToDate", True / False, "ReadFromMessageId", NoOfMessage)
        ''StartDate/EndDate:- In dd-mm-yyyy Format Only

        ''To Get Group List:-
        'ApiResult = ClsNotificationApp_I.Get_GroupList()

    End Sub

    Public Sub sendWhatsApp_SendText(ByVal toMoNum As String, ByVal msgTxt As String, ByVal countryCode As String, ByVal CCWhatsapp As String)
        If M_WhatsappInstanceId = Nothing Or M_WhatsappInstanceId = "" Then
            MsgBox("Please Specify WhatsApp Instance Id", MsgBoxStyle.Information)
            Exit Sub
        End If

        If isInternetOn() = False Then
            Exit Sub
        End If

        If countryCode = "" Then
            countryCode = "91"
        End If

        'Create Instance On Application Startup:-
        Dim ClsNotificationApp_I As ClsNotificationApp
        ClsNotificationApp_I = New ClsNotificationApp(M_WhatsappInstanceId, "enotify.app") '"60ba1543ff77dd08602c3c51"               

        Dim ApiResult As String = ""
        'To Send Text:-
        ApiResult = ClsNotificationApp_I.SendText(countryCode.Replace("+", "").Replace("+", "") & toMoNum, msgTxt) '"919727001838" ,"JSN"      

        '04/10/2022 send File to Owner number 
        Try
            If UCase(CCWhatsapp) = "YES" Then
                Dim ccMobileNo() As String = Strings.Split(Trim(M_CCWhatsappMobileNo), ",")

                For i As Integer = 0 To ccMobileNo.GetUpperBound(0)
                    ApiResult = ClsNotificationApp_I.SendText(ccMobileNo(i), msgTxt) '"919727001838", "D:\Bhavika_SSD\436175.jpg","Caption_JSN"
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub sendWhatsApp_SendFile(ByVal toMoNum As String, ByVal filePath As String, ByVal countryCode As String)
        If M_WhatsappInstanceId = Nothing Or M_WhatsappInstanceId = "" Then
            MsgBox("Please Specify WhatsApp Instance Id", MsgBoxStyle.Information)
            Exit Sub
        End If

        If isInternetOn() = False Then
            Exit Sub
        End If

        If countryCode = "" Then
            countryCode = "91"
        End If

        'Create Instance On Application Startup:-
        Dim ClsNotificationApp_I As ClsNotificationApp
        ClsNotificationApp_I = New ClsNotificationApp(M_WhatsappInstanceId, "enotify.app") '"60ba1543ff77dd08602c3c51"

        Dim ApiResult As String = ""
        'To Send File:-        
        ApiResult = ClsNotificationApp_I.SendFile(countryCode.Replace("+", "") & toMoNum, filePath) '"919727001838" ,"D:\Bhavika_SSD\Demo.pdf"     

        '04/10/2022 send File to Owner number 
        Try
            If UCase(M_CCWhatsappWhatsappOnSaveTimeSendInvoice) = "YES" Then
                Dim ccMobileNo() As String = Strings.Split(Trim(M_CCWhatsappMobileNo), ",")

                For i As Integer = 0 To ccMobileNo.GetUpperBound(0)
                    ApiResult = ClsNotificationApp_I.SendFile(ccMobileNo(i), filePath) '"919727001838", "D:\Bhavika_SSD\436175.jpg","Caption_JSN"
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub sendWhatsApp_SendFileWithText(ByVal toMoNum As String, ByVal filePath As String, ByVal captionText As String, ByVal countryCode As String)
        If M_WhatsappInstanceId = Nothing Or M_WhatsappInstanceId = "" Then
            MsgBox("Please Specify WhatsApp Instance Id", MsgBoxStyle.Information)
            Exit Sub
        End If

        If isInternetOn() = False Then
            Exit Sub
        End If

        If countryCode = "" Then
            countryCode = "91"
        End If

        'Create Instance On Application Startup:-
        Dim ClsNotificationApp_I As ClsNotificationApp

        ClsNotificationApp_I = New ClsNotificationApp(M_WhatsappInstanceId, "enotify.app") '"60ba1543ff77dd08602c3c51"

        Dim ApiResult As String = ""
        'To Send File with Caption:-
        Try
            ApiResult = ClsNotificationApp_I.SendFileWithText(countryCode.Replace("+", "") & toMoNum, filePath, captionText) '"919727001838", "D:\Bhavika_SSD\436175.jpg","Caption_JSN"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        '04/10/2022 send File to Owner number 
        Try
            If UCase(M_CCWhatsappWhatsappOnSaveTimeSendInvoice) = "YES" Then
                Dim ccMobileNo() As String = Strings.Split(Trim(M_CCWhatsappMobileNo), ",")

                For i As Integer = 0 To ccMobileNo.GetUpperBound(0)
                    ApiResult = ClsNotificationApp_I.SendFileWithText(ccMobileNo(i), filePath, captionText) '"919727001838", "D:\Bhavika_SSD\436175.jpg","Caption_JSN"
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub insert_SMSTrail(ByVal invId As Integer, ByVal smsType As String)
        sql_query = "Insert Into tbl_SMSTrail (InvId, SmsType, SmsDtm) Values (" & invId & ", '" & smsType & "', '" & Format(Date.Now, "MM/dd/yyyy HH:mm:ss tt") & "')"
        obj.QueryExecute(sql_query)
    End Sub

    Public Function M_GetServerDTM_SP() As String
        sql_query = "select getdate()"
        Return Format(obj.ScalarExecute(sql_query), "dd/MM/yyyy hh:mm:ss tt")
    End Function

    Public Function M_GetPCIPAddress() As String
        loggedIP = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName().ToString).AddressList(0).ToString()
        Return loggedIP
    End Function

    Public Function M_GetPCName() As String
        'Return System.Net.Dns.GetHostName().ToString()
        Return My.Computer.Name
    End Function

    Public Sub DocumentUpload(ByVal MasterId As Integer, ByVal DocType As String)
        If Trim(M_UploadDocFilePath) = "" Then
            MessageBox.Show("Setting Not Found, Please Check And Try Again", "File Upload", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If obj.ScalarExecute("select count(0) from tbl_DocumentMaster where MasterId = " & Val(MasterId) & " and DocType = '" & DocType & "'") > 0 Then
            If MessageBox.Show("Attachment Found, Sure to Edit ?", "File Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                sql_query = "delete from tbl_DocumentMaster where MasterId = " & Val(MasterId) & " and DocType = '" & DocType & "'"
                obj.QueryExecute(sql_query)
                DocUpload(MasterId, DocType)
            Else
                Process.Start(obj.ScalarExecute("select FilePath from tbl_DocumentMaster where MasterId = " & Val(MasterId) & " and DocType = '" & DocType & "'"))
            End If
        Else
            DocUpload(MasterId, DocType)
        End If
    End Sub

    Public Sub DocUpload(ByVal Master_Id As Integer, ByVal Doc_Type As String)
        Dim ofd As New OpenFileDialog()
        If ofd.ShowDialog() = DialogResult.OK Then
            If ofd.FileName.Trim() <> "" Then
                Dim filename As String = Path.GetFileName(ofd.FileName)
                Dim UploadPath = M_UploadDocFilePath & "\" & Trim(Master_Id).ToString() & "_" & filename
                obj.Prepare("SP_Insert_DocumentMaster", SpType.StoredProcedure)
                obj.AddCmdParameter("@MasterId", Dtype.int, Val(Master_Id), ParaDirection.Input, True)
                obj.AddCmdParameter("@DocType", Dtype.varchar, Doc_Type, ParaDirection.Input, True)
                obj.AddCmdParameter("@FilePath", Dtype.varchar, UploadPath, ParaDirection.Input, True)
                obj.AddCmdParameter("@Sys_Name", Dtype.varchar, M_GetPCName(), ParaDirection.Input, True)
                obj.AddCmdParameter("@Sys_Time", Dtype.DateTime, DateTime.Now, ParaDirection.Input, True)
                obj.AddCmdParameter("@CurrUsr", Dtype.varchar, loggedUser, ParaDirection.Input, True)
                obj.ExecuteCommand()

                File.Copy(ofd.FileName, UploadPath)
                MessageBox.Show("File Uploaded Sucessfully", "File Upload", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please Select Proper File Name And Try Again", "File Upload", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Public Sub SaveLayout(ByVal gvName As GridView, ByVal xmlFileName As String, ByVal frmName As Form)
        If Not Directory.Exists(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\GridLayout") Then
            Directory.CreateDirectory(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\GridLayout")
        End If

        If File.Exists(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\GridLayout\" & xmlFileName & ".xml") Then
            File.Delete(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\GridLayout\" & xmlFileName & ".xml")
        End If

        gvName.SaveLayoutToXml(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\GridLayout\" & xmlFileName & ".xml")
        MessageBox.Show("Layout Saved Successfully.", "Grid Layout Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'frmName.Close()

        'If Not Directory.Exists(Application.StartupPath & "\GridLayout") Then
        '    Directory.CreateDirectory(Application.StartupPath & "\GridLayout")
        'End If

        'If File.Exists(Application.StartupPath & "\GridLayout\" & xmlFileName & ".xml") Then
        '    File.Delete(Application.StartupPath & "\GridLayout\" & xmlFileName & ".xml")
        'End If

        'gvName.SaveLayoutToXml(Application.StartupPath & "\GridLayout\" & xmlFileName & ".xml")
        'MessageBox.Show("Layout Saved Successfully.", "Grid Layout Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'frmName.Close()
    End Sub

    Public Sub RestoreLayout(ByVal gvName As GridView, ByVal xmlFileName As String)
        If Not Directory.Exists(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\GridLayout") Then
            Exit Sub
        End If

        If Not File.Exists(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\GridLayout\" & xmlFileName & ".xml") Then
            Exit Sub
        End If
        gvName.RestoreLayoutFromXml(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\GridLayout\" & xmlFileName & ".xml")
    End Sub

    Public Sub RenameColumn(ByVal gvName As GridView)
        gvName.FocusedColumn.Caption = InputBox("Column Header Text", "Field Name", gvName.FocusedColumn.FieldName)
    End Sub

    Public Sub ExportToExcel(ByVal gvName As GridView)
        Dim sfd As New SaveFileDialog()
        If sfd.ShowDialog() = DialogResult.OK Then
            gvName.ExportToXls(sfd.FileName & ".xls")
        End If
    End Sub

    Public Sub M_prepare_StockStatement_ItemMaster(_barcode As String, _dateAfter As String)
        Dim ds As New Data.DataSet
        ds.Clear()

        sql_query = "Select *, 0.0 As tmpOpStk From tbl_TItemMaster Where  Barcode = '" & Trim(_barcode) & "' And " _
                & " ((CId In (" & M_CId & ")) " _
                & " OR " _
                & " TItemId In (Select Distinct ItemId From View_StockTransferDetail Where FromCId In (" & M_CId & ") Or ToCId In (" & M_CId & "))) " _
                & " And ItemSubType = 'Sales' And ManageStock = 'True' And ItemSize <> 'SHOE SIZE' And BarcodeType = 'Item Master' "

        obj.LoadData(sql_query, ds)

        'Dim dv As New DataView(ds.Tables(0))
        'dv.RowFilter = "CId = " & M_CId
        'Dim dt As DataTable = dv.ToTable
        'ds.Reset()
        'ds.Tables.Add(dt)
        If ds.Tables(0).Rows.Count = 1 Then

        Else
            Exit Sub
        End If

        Dim dsOpStk As New DataSet()

        sql_query = "Select * From tbl_OpeningStock Where FinYrId = " & M_StockYrId
        obj.LoadData(sql_query, dsOpStk)

        Dim dsPurchase As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsPurchase)

        Dim dsPurchaseRate As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select PurchaseRate, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Order By PurchaseId Desc"
        Else
            sql_query = "Select PurchaseRate, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Order By PurchaseId Desc"
        End If

        obj.LoadData(sql_query, dsPurchaseRate)

        Dim dsPurReturn As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType = 'Debit Note' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType = 'Debit Note' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsPurReturn)

        Dim dsSales As New DataSet()

        If _dateAfter <> "" Then
            If M_IgnoreSalesQtyInStockStatement = "Yes" Then

            Else
                If M_DbName = "dbSTE_Julie2024" Then
                    sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And InvDetailId Not In (Select FabricDetailId From tbl_InvoiceDetail) " _
                               & " And LIFlag <> 'DELETE' And UOM_SD <> 'PRODU' And SalesAcType Not In ('Production Order', 'Credit Note') And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
                    obj.LoadData(sql_query, dsSales)
                Else
                    ' sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And UOM_SD <> 'PRODU' And CId_IM = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
                    'Remove 'And UOM_SD <> 'PRODU'' For KFL 30/8/2024
                    sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
                    obj.LoadData(sql_query, dsSales)
                End If
            End If
        Else
            If M_IgnoreSalesQtyInStockStatement = "Yes" Then

            Else
                If M_DbName = "dbSTE_Julie2024" Then
                    sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And InvDetailId Not In (Select FabricDetailId From tbl_InvoiceDetail) " _
                               & " And LIFlag <> 'DELETE' And UOM_SD <> 'PRODU' And SalesAcType Not In ('Production Order', 'Credit Note') And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
                    obj.LoadData(sql_query, dsSales)
                Else
                    'sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And UOM_SD <> 'PRODU' And CId_IM = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
                    'Remove 'And UOM_SD <> 'PRODU'' For KFL 30/8/2024
                    sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And (CONVERT(Date,InvoiceDate) Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId" 'And Uom
                    obj.LoadData(sql_query, dsSales)
                End If
            End If
        End If

        Dim dsSalesReturn As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty, TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And SalesAcType = 'Credit Note' And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty, TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And SalesAcType = 'Credit Note' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsSalesReturn)

        Dim dsStockIn1 As New DataSet
        If M_SalesItemMaster = "AV" Then
            If _dateAfter <> "" Then
                sql_query = "Select IsNull(Sum(AcceptQty),0) As AcceptQty, ToItemId From View_StockTransferDetail Where ToCId = " & M_CId & " And ReceiveDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ToItemId"
            Else
                sql_query = "Select IsNull(Sum(AcceptQty),0) As AcceptQty, ToItemId From View_StockTransferDetail Where ToCId = " & M_CId & " And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ToItemId"
            End If
        Else
            If _dateAfter <> "" Then
                sql_query = "Select IsNull(Sum(AcceptQty),0) As AcceptQty, ItemId From View_StockTransferDetail Where ItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And ToCId = " & M_CId & " And ReceiveDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ItemId"
            Else
                sql_query = "Select IsNull(Sum(AcceptQty),0) As AcceptQty, ItemId From View_StockTransferDetail Where ItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And ToCId = " & M_CId & " And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ItemId"
            End If
        End If


        obj.LoadData(sql_query, dsStockIn1)

        Dim dsStockOut1 As New DataSet

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(TransferQty),0) As TransferQty, ItemId From View_StockTransferDetail Where ItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And FromCId = " & M_CId & " And TDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And TDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ItemId"
        Else
            sql_query = "Select IsNull(Sum(TransferQty),0) As TransferQty, ItemId From View_StockTransferDetail Where ItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And FromCId = " & M_CId & " And TDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ItemId"
        End If

        obj.LoadData(sql_query, dsStockOut1)

        Dim dsFabricCut As New DataSet

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(AQty),0) As AQty,TItemId From View_FabricCut Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' And LIFlag <> 'DELETE' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(AQty),0) As AQty,TItemId From View_FabricCut Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' And LIFlag <> 'DELETE' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsFabricCut)

        Dim dsProduction As New DataSet

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(ReturnQty),0) As ReturnQty,TItemId From View_WorkReturn Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And MarkAsReady = 'True' And ReturnDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (ReturnDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(ReturnQty),0) As ReturnQty,TItemId From View_WorkReturn Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And MarkAsReady = 'True' And (ReturnDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
        End If

        obj.LoadData(sql_query, dsProduction)
        Dim dsMatIssue As New DataSet

        If _dateAfter <> "" Then
            If M_IgnoreMaterialIssueQtyInStockStatement = "Yes" Then

            Else
                sql_query = "Select IsNull(Sum(IssueQty),0) As IssueQty,TItemId From View_MaterialIssuance Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And EntryDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (EntryDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
                obj.LoadData(sql_query, dsMatIssue)
            End If
        Else
            If M_IgnoreMaterialIssueQtyInStockStatement = "Yes" Then

            Else
                sql_query = "Select IsNull(Sum(IssueQty),0) As IssueQty,TItemId From View_MaterialIssuance Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And (EntryDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
                obj.LoadData(sql_query, dsMatIssue)
            End If
        End If

        '================== D:23/08/2024 Refrance View_StockAdjustMent============
        'Stock Adjust Add
        Dim dsStkAdjAdd As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From tbl_StockAdjustment Where CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'ADD' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From tbl_StockAdjustment Where CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'ADD' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsStkAdjAdd)

        'Stock Adjust Less
        Dim dsStkAdjLess As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From tbl_StockAdjustment Where CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'LESS' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From tbl_StockAdjustment Where CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'LESS' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsStkAdjLess)

        '============================================================


        Dim opStkQty, purchaseQty, purRate, salesQty, purchaseReturnQty, salesReturnQty As Double
        Dim stkIn1, stkOut1, fabricCut, production, matIssue, stkAdjAdd, stkAdjLess As Double
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim drOpStk As DataRow = dsOpStk.Tables(0).Select("ItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drRcpt As DataRow = dsPurchase.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drPurRate As DataRow = dsPurchaseRate.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drPRet As DataRow = dsPurReturn.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()

            Dim drIssue As DataRow
            If M_IgnoreSalesQtyInStockStatement = "Yes" Then

            Else
                drIssue = dsSales.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            End If


            Dim drSRet As DataRow = dsSalesReturn.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            '-----
            Dim drStkIn1 As DataRow
            If M_SalesItemMaster = "AV" Then
                drStkIn1 = dsStockIn1.Tables(0).Select("ToItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Else
                drStkIn1 = dsStockIn1.Tables(0).Select("ItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            End If

            Dim drStkOut1 As DataRow = dsStockOut1.Tables(0).Select("ItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drFC As DataRow '= dsFabricCut.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault() '23/08/2024
            Dim drProd As DataRow = dsProduction.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drMatIssue As DataRow = dsMatIssue.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drStkAdjAdd As DataRow = dsStkAdjAdd.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drStkAdjLess As DataRow = dsStkAdjLess.Tables(0).Select("TItemId=" & ds.Tables(0).Rows(i)("TItemId")).FirstOrDefault()

            If Not drOpStk Is Nothing Then
                If ds.Tables(0).Rows(i)("CId") = M_CId Then
                    opStkQty = Format(Val(drOpStk("OpStk")), M_StockQtyRounding)
                Else
                    opStkQty = 0
                End If

            Else
                opStkQty = 0
            End If


            If Not drRcpt Is Nothing Then
                If ds.Tables(0).Rows(i)("CId") = M_CId Then
                    purchaseQty = Format(Val(drRcpt("Qty")), M_StockQtyRounding)
                Else
                    purchaseQty = 0
                End If
            Else
                purchaseQty = 0
            End If

            If Not drPurRate Is Nothing Then
                purRate = Format(Val(drPurRate("PurchaseRate")), M_StockQtyRounding)
            Else
                purRate = ds.Tables(0).Rows(i)("PurchaseRate")
            End If

            If Not drIssue Is Nothing Then
                salesQty = Format(Val(drIssue("TItemQty")), M_StockQtyRounding)
            Else
                salesQty = 0
            End If

            If Not drPRet Is Nothing Then
                purchaseReturnQty = Format(Val(drPRet("Qty")), M_StockQtyRounding)
            Else
                purchaseReturnQty = 0
            End If

            If Not drSRet Is Nothing Then
                salesReturnQty = Format(Val(drSRet("TItemQty")), M_StockQtyRounding)
            Else
                salesReturnQty = 0
            End If
            '-------
            If Not drStkIn1 Is Nothing Then
                stkIn1 = Format(Val(drStkIn1("AcceptQty")), M_StockQtyRounding)
            Else
                stkIn1 = 0
            End If
            If Not drStkOut1 Is Nothing Then
                stkOut1 = Format(Val(drStkOut1("TransferQty")), M_StockQtyRounding)
            Else
                stkOut1 = 0
            End If
            If Not drFC Is Nothing Then
                fabricCut = Format(Val(drFC("AQty")), M_StockQtyRounding)
            Else
                fabricCut = 0
            End If
            If Not drProd Is Nothing Then
                production = Format(Val(drProd("ReturnQty")), M_StockQtyRounding)
            Else
                production = 0
            End If
            If Not drMatIssue Is Nothing Then
                matIssue = Format(Val(drMatIssue("IssueQty")), M_StockQtyRounding)
            Else
                matIssue = 0
            End If
            If Not drStkAdjAdd Is Nothing Then
                stkAdjAdd = Format(Val(drStkAdjAdd("Qty")), M_StockQtyRounding)
            Else
                stkAdjAdd = 0
            End If

            If Not drStkAdjLess Is Nothing Then
                stkAdjLess = Format(Val(drStkAdjLess("Qty")), M_StockQtyRounding)
            Else
                stkAdjLess = 0
            End If

            M_LiveStock = Format(opStkQty + purchaseQty + production + salesReturnQty + stkIn1 - salesQty - purchaseReturnQty - fabricCut - matIssue - stkOut1 + stkAdjAdd - stkAdjLess, M_StockQtyRounding)
        Next
    End Sub

    Public Sub M_prepare_StockStatement_ItemMaster_KFL(_barcode As String, _dateAfter As String)
        Dim ds As New Data.DataSet
        ds.Clear()

        sql_query = "Select *, 0.0 As tmpOpStk From tbl_TItemMaster Where  Barcode = '" & Trim(_barcode) & "' And " _
                & " (CId In (" & M_CId & "))  And ItemSubType = 'Sales' And ManageStock = 'True' And ItemSize <> 'SHOE SIZE' And BarcodeType = 'Item Master'"

        obj.LoadData(sql_query, ds)

        If ds.Tables(0).Rows.Count = 1 Then

        Else
            ds.Clear()

            sql_query = "Select *, 0.0 As tmpOpStk From tbl_TItemMaster Where " _
                    & " ((CId In (" & M_CId & ")) " _
                    & " OR " _
                    & " TItemId In (Select Distinct ItemId From View_StockTransferDetail Where FromCId In (" & M_CId & ") Or ToCId In (" & M_CId & "))) " _
                    & " And ItemSubType = 'Sales' And ManageStock = 'True' And ItemSize <> 'SHOE SIZE' And Barcode = '" & _barcode & "'" _
                    & " Order By TItemName"
            obj.LoadData(sql_query, ds)

            If ds.Tables(0).Rows.Count < 1 Then
                Exit Sub
            End If
        End If

        Dim dsOpStk As New DataSet()

        sql_query = "Select * From tbl_OpeningStock Where FinYrId = " & M_StockYrId
        obj.LoadData(sql_query, dsOpStk)

        Dim dsPurchase As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsPurchase)

        Dim dsPurchaseRate As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select PurchaseRate, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Order By PurchaseId Desc"
        Else
            sql_query = "Select PurchaseRate, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Order By PurchaseId Desc"
        End If

        obj.LoadData(sql_query, dsPurchaseRate)

        Dim dsPurReturn As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType = 'Debit Note' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From View_PurchaseBill Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType = 'Debit Note' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsPurReturn)

        Dim dsSales As New DataSet()

        If _dateAfter <> "" Then
            If M_IgnoreSalesQtyInStockStatement = "Yes" Then

            Else
                If M_DbName = "dbSTE_Julie2024" Then
                    sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And InvDetailId Not In (Select FabricDetailId From tbl_InvoiceDetail) " _
                               & " And LIFlag <> 'DELETE' And UOM_SD <> 'PRODU' And SalesAcType Not In ('Production Order', 'Credit Note') And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
                    obj.LoadData(sql_query, dsSales)
                Else
                    ' sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And UOM_SD <> 'PRODU' And CId_IM = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
                    'Remove 'And UOM_SD <> 'PRODU'' For KFL 30/8/2024
                    sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
                    obj.LoadData(sql_query, dsSales)
                End If
            End If
        Else
            If M_IgnoreSalesQtyInStockStatement = "Yes" Then

            Else
                If M_DbName = "dbSTE_Julie2024" Then
                    sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And InvDetailId Not In (Select FabricDetailId From tbl_InvoiceDetail) " _
                               & " And LIFlag <> 'DELETE' And UOM_SD <> 'PRODU' And SalesAcType Not In ('Production Order', 'Credit Note') And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
                    obj.LoadData(sql_query, dsSales)
                Else
                    'sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And UOM_SD <> 'PRODU' And CId_IM = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
                    'Remove 'And UOM_SD <> 'PRODU'' For KFL 30/8/2024
                    sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty,TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId" 'And Uom
                    obj.LoadData(sql_query, dsSales)
                End If
            End If
        End If

        Dim dsSalesReturn As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty, TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And SalesAcType = 'Credit Note' And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(TItemQty),0) As TItemQty, TItemId From View_TailoringInvoiceGST Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId_IM = " & M_CId & " And SalesAcType = 'Credit Note' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsSalesReturn)

        Dim dsStockIn1 As New DataSet
        If M_SalesItemMaster = "AV" Then
            If _dateAfter <> "" Then
                sql_query = "Select IsNull(Sum(AcceptQty),0) As AcceptQty, ToItemId From View_StockTransferDetail Where ToCId = " & M_CId & " And ReceiveDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ToItemId"
            Else
                sql_query = "Select IsNull(Sum(AcceptQty),0) As AcceptQty, ToItemId From View_StockTransferDetail Where ToCId = " & M_CId & " And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ToItemId"
            End If
        Else
            If _dateAfter <> "" Then
                sql_query = "Select IsNull(Sum(AcceptQty),0) As AcceptQty, ItemId From View_StockTransferDetail Where  ToCId = " & M_CId & " And ReceiveDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ItemId"
            Else
                sql_query = "Select IsNull(Sum(AcceptQty),0) As AcceptQty, ItemId From View_StockTransferDetail Where ToCId = " & M_CId & " And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ItemId"
            End If
        End If


        obj.LoadData(sql_query, dsStockIn1)

        Dim dsStockOut1 As New DataSet

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(TransferQty),0) As TransferQty, ItemId From View_StockTransferDetail Where  FromCId = " & M_CId & " And TDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And TDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ItemId"
        Else
            sql_query = "Select IsNull(Sum(TransferQty),0) As TransferQty, ItemId From View_StockTransferDetail Where FromCId = " & M_CId & " And TDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By ItemId"
        End If

        obj.LoadData(sql_query, dsStockOut1)

        Dim dsFabricCut As New DataSet

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(AQty),0) As AQty,TItemId From View_FabricCut Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And InvoiceDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' And LIFlag <> 'DELETE' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(AQty),0) As AQty,TItemId From View_FabricCut Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' And LIFlag <> 'DELETE' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsFabricCut)

        Dim dsProduction As New DataSet

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(ReturnQty),0) As ReturnQty,TItemId From View_WorkReturn Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And MarkAsReady = 'True' And ReturnDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (ReturnDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(ReturnQty),0) As ReturnQty,TItemId From View_WorkReturn Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And MarkAsReady = 'True' And (ReturnDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
        End If

        obj.LoadData(sql_query, dsProduction)
        Dim dsMatIssue As New DataSet

        If _dateAfter <> "" Then
            If M_IgnoreMaterialIssueQtyInStockStatement = "Yes" Then

            Else
                sql_query = "Select IsNull(Sum(IssueQty),0) As IssueQty,TItemId From View_MaterialIssuance Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And EntryDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (EntryDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
                obj.LoadData(sql_query, dsMatIssue)
            End If
        Else
            If M_IgnoreMaterialIssueQtyInStockStatement = "Yes" Then

            Else
                sql_query = "Select IsNull(Sum(IssueQty),0) As IssueQty,TItemId From View_MaterialIssuance Where TItemId = " & ds.Tables(0).Rows(0)("TItemId") & " And CId = " & M_CId & " And (EntryDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By TItemId"
                obj.LoadData(sql_query, dsMatIssue)
            End If
        End If

        '================== D:23/08/2024 Refrance View_StockAdjustMent============
        'Stock Adjust Add
        Dim dsStkAdjAdd As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From tbl_StockAdjustment Where CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'ADD' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From tbl_StockAdjustment Where CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'ADD' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsStkAdjAdd)

        'Stock Adjust Less
        Dim dsStkAdjLess As New DataSet()

        If _dateAfter <> "" Then
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From tbl_StockAdjustment Where CId = " & M_CId & " And DocDate >= '" & Format(CDate(_dateAfter), M_DTMforQuery) & "' And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'LESS' Group By TItemId"
        Else
            sql_query = "Select IsNull(Sum(Qty),0) As Qty, TItemId From tbl_StockAdjustment Where CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'LESS' Group By TItemId"
        End If

        obj.LoadData(sql_query, dsStkAdjLess)

        '============================================================
        Dim ds1 As New Data.DataSet
        ds.Clear()
        sql_query = "Select *, 0.0 As tmpOpStk From tbl_TItemMaster Where " _
                    & " ((CId In (" & M_CId & ")) " _
                    & " OR " _
                    & " TItemId In (Select Distinct ItemId From View_StockTransferDetail Where FromCId In (" & M_CId & ") Or ToCId In (" & M_CId & "))) " _
                    & " And ItemSubType = 'Sales' And ManageStock = 'True' And ItemSize <> 'SHOE SIZE'  And BarcodeType = 'Item Master' And Barcode = '" & _barcode & "' " _
                    & " Order By TItemName"

        obj.LoadData(sql_query, ds1)


        Dim opStkQty, purchaseQty, purRate, salesQty, purchaseReturnQty, salesReturnQty As Double
        Dim stkIn1, stkOut1, fabricCut, production, matIssue, stkAdjAdd, stkAdjLess As Double
        For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
            Dim drOpStk As DataRow = dsOpStk.Tables(0).Select("ItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drRcpt As DataRow = dsPurchase.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drPurRate As DataRow = dsPurchaseRate.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drPRet As DataRow = dsPurReturn.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()

            Dim drIssue As DataRow
            If M_IgnoreSalesQtyInStockStatement = "Yes" Then

            Else
                drIssue = dsSales.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            End If


            Dim drSRet As DataRow = dsSalesReturn.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            '-----
            Dim drStkIn1 As DataRow
            If M_SalesItemMaster = "AV" Then
                drStkIn1 = dsStockIn1.Tables(0).Select("ToItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Else
                drStkIn1 = dsStockIn1.Tables(0).Select("ItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            End If

            Dim drStkOut1 As DataRow = dsStockOut1.Tables(0).Select("ItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drFC As DataRow '= dsFabricCut.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault() '23/08/2024
            Dim drProd As DataRow = dsProduction.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drMatIssue As DataRow = dsMatIssue.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drStkAdjAdd As DataRow = dsStkAdjAdd.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()
            Dim drStkAdjLess As DataRow = dsStkAdjLess.Tables(0).Select("TItemId=" & ds1.Tables(0).Rows(i)("TItemId")).FirstOrDefault()

            If Not drOpStk Is Nothing Then
                If ds1.Tables(0).Rows(i)("CId") = M_CId Then
                    opStkQty = Val(opStkQty) + Format(Val(drOpStk("OpStk")), M_StockQtyRounding)
                Else
                    ' opStkQty = 0
                End If

            Else
                '  opStkQty = 0
            End If


            If Not drRcpt Is Nothing Then
                If ds1.Tables(0).Rows(i)("CId") = M_CId Then
                    purchaseQty = Val(purchaseQty) + Format(Val(drRcpt("Qty")), M_StockQtyRounding)
                Else
                    ' purchaseQty = 0
                End If
            Else
                ' purchaseQty = 0
            End If

            If Not drPurRate Is Nothing Then
                purRate = Val(purRate) + Format(Val(drPurRate("PurchaseRate")), M_StockQtyRounding)
            Else
                '   purRate = ds1.Tables(0).Rows(i)("PurchaseRate")
            End If

            If Not drIssue Is Nothing Then
                salesQty = Val(salesQty) + Format(Val(drIssue("TItemQty")), M_StockQtyRounding)
            Else
                '   salesQty = 0
            End If

            If Not drPRet Is Nothing Then
                purchaseReturnQty = Val(purchaseReturnQty) + Format(Val(drPRet("Qty")), M_StockQtyRounding)
            Else
                '    purchaseReturnQty = 0
            End If

            If Not drSRet Is Nothing Then
                salesReturnQty = Val(salesReturnQty) + Format(Val(drSRet("TItemQty")), M_StockQtyRounding)
            Else
                '     salesReturnQty = 0
            End If
            '-------
            If Not drStkIn1 Is Nothing Then
                stkIn1 = Val(stkIn1) + Format(Val(drStkIn1("AcceptQty")), M_StockQtyRounding)
            Else
                '  stkIn1 = 0
            End If
            If Not drStkOut1 Is Nothing Then
                stkOut1 = Val(stkOut1) + Format(Val(drStkOut1("TransferQty")), M_StockQtyRounding)
            Else
                '  stkOut1 = 0
            End If
            If Not drFC Is Nothing Then
                fabricCut = Val(fabricCut) + Format(Val(drFC("AQty")), M_StockQtyRounding)
            Else
                ' fabricCut = 0
            End If
            If Not drProd Is Nothing Then
                production = Val(production) + Format(Val(drProd("ReturnQty")), M_StockQtyRounding)
            Else
                '  production = 0
            End If
            If Not drMatIssue Is Nothing Then
                matIssue = Val(matIssue) + Format(Val(drMatIssue("IssueQty")), M_StockQtyRounding)
            Else
                ' matIssue = 0
            End If
            If Not drStkAdjAdd Is Nothing Then
                stkAdjAdd = Val(stkAdjAdd) + Format(Val(drStkAdjAdd("Qty")), M_StockQtyRounding)
            Else
                '  stkAdjAdd = 0
            End If

            If Not drStkAdjLess Is Nothing Then
                stkAdjLess = Val(stkAdjLess) + Format(Val(drStkAdjLess("Qty")), M_StockQtyRounding)
            Else
                '   stkAdjLess = 0
            End If

        Next

        M_LiveStock = Format(opStkQty + purchaseQty + production + salesReturnQty + stkIn1 - salesQty - purchaseReturnQty - fabricCut - matIssue - stkOut1 + stkAdjAdd - stkAdjLess, M_StockQtyRounding)

    End Sub


    Public Sub M_prepare_PieceWiseUniqueBarcode_JulieWorking(_barcode As String, calledFrom As String)
        Dim ds As New Data.DataSet
        ds.Clear()

        sql_query = "Select *, 0.0 As Purchase, 0.0 As Sales, 0.0 As TransferIn, 0.0 As TransferOut, 0.0 As PurRtn, 0.0 As SalesRtn, 0.0 As StockQty From View_ItemMaster_PurchaseBarcode " _
            & " Where Barcode = '" & _barcode & "'"

        obj.LoadData(sql_query, ds)

        Dim purchaseQty, purchaseRtnQty, salesQty, TransferIn, TransferOut, transfer, salesReturnQty, stockQty, opnStk, stockAdj As Double

        Dim dsPurchase As New Data.DataSet
        Dim dsSales As New Data.DataSet
        Dim dsPurchaseRtn As New Data.DataSet
        Dim dsSalesRtn As New Data.DataSet
        Dim dsTransferIn As New Data.DataSet
        Dim dsTransferOut As New Data.DataSet
        Dim dsTransfer As New Data.DataSet
        Dim dsStockAdj As New Data.DataSet

        If calledFrom = "Order" Then
            sql_query = "Select * From View_StockSt_PcsBarcode_Purchase Where CId = " & M_CId & " And PCS_Barcode = '" & _barcode & "'"
        Else
            sql_query = "Select * From View_StockSt_PcsBarcode_Purchase Where CId = " & M_CId & ""
        End If

        obj.LoadData(sql_query, dsPurchase)

        If calledFrom = "Order" Then
            sql_query = "Select * From tbl_StockAdjustment Where CId = " & M_CId & " And Barcode = '" & _barcode & "'"
        Else
            sql_query = "Select * From tbl_StockAdjustment Where CId = " & M_CId & ""
        End If

        obj.LoadData(sql_query, dsStockAdj)

        If calledFrom = "Order" Then
            sql_query = "Select * From View_StockSt_PcsBarcode_PurchaseReturn Where CId = " & M_CId & " And PCS_Barcode = '" & _barcode & "'"
        Else
            sql_query = "Select * From View_StockSt_PcsBarcode_PurchaseReturn Where CId = " & M_CId & ""
        End If

        obj.LoadData(sql_query, dsPurchaseRtn)

        If calledFrom = "Order" Then
            sql_query = "Select Sum(TItemQty) As TItemQty, PCS_Barcode From View_StockSt_PcsBarcode_Sales Where CId = " & M_CId & " And PCS_Barcode = '" & _barcode & "' Group By PCS_Barcode"
        Else
            sql_query = "Select Sum(TItemQty) As TItemQty, PCS_Barcode From View_StockSt_PcsBarcode_Sales Where CId = " & M_CId & " Group By PCS_Barcode"
        End If

        obj.LoadData(sql_query, dsSales)

        If calledFrom = "Order" Then
            sql_query = "Select * From View_StockSt_PcsBarcode_SalesReturn Where CId = " & M_CId & " And PCS_Barcode = '" & _barcode & "'"
        Else
            sql_query = "Select * From View_StockSt_PcsBarcode_SalesReturn Where CId = " & M_CId & ""
        End If

        obj.LoadData(sql_query, dsSalesRtn)

        If calledFrom = "Order" Then
            sql_query = "Select * From View_PurchaseBill Where CId = " & M_CId & " And PurchaseType = 'TRANSFER' And Barcode = '" & _barcode & "'"
        Else
            sql_query = "Select * From View_PurchaseBill Where CId = " & M_CId & " And PurchaseType = 'TRANSFER'"
        End If
        'TransferIn

        obj.LoadData(sql_query, dsTransferIn)

        If calledFrom = "Order" Then
            sql_query = "Select PCS_Barcode, TItemQty From View_StockSt_PcsBarcode_TransferOut Where CId = " & M_CId & " And PCS_Barcode = '" & _barcode & "'" _
                & " UNION " _
                & "Select PCS_Barcode, TItemQty From View_StockSt_PcsBarcode_Transfer Where CId = " & M_CId & ""
        Else
            sql_query = "Select PCS_Barcode, TItemQty From View_StockSt_PcsBarcode_TransferOut Where CId = " & M_CId & " And PCS_Barcode = '" & _barcode & "'" _
                & " UNION " _
                & "Select PCS_Barcode, TItemQty From View_StockSt_PcsBarcode_Transfer Where CId = " & M_CId & ""
        End If

        obj.LoadData(sql_query, dsTransferOut)

        Dim dsOpStk As New DataSet()

        If calledFrom = "Order" Then
            sql_query = "Select * From View_OpeningStock Where FinYrId = " & M_StockYrId & " And CId = " & M_CId & " And Barcode = '" & _barcode & "'"
        Else
            sql_query = "Select * From View_OpeningStock Where FinYrId = " & M_StockYrId & " And CId = " & M_CId
        End If

        obj.LoadData(sql_query, dsOpStk)


        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            purchaseQty = 0
            stockAdj = 0
            purchaseRtnQty = 0
            salesQty = 0
            TransferIn = 0
            TransferOut = 0
            salesReturnQty = 0
            stockQty = 0

            Dim drRcpt As DataRow = dsPurchase.Tables(0).Select("PCS_Barcode='" & ds.Tables(0).Rows(i)("Barcode") & "'").FirstOrDefault()
            Dim drStockAdj As DataRow = dsStockAdj.Tables(0).Select("Barcode='" & ds.Tables(0).Rows(i)("Barcode") & "'").FirstOrDefault()
            Dim drPRet As DataRow = dsPurchaseRtn.Tables(0).Select("PCS_Barcode='" & ds.Tables(0).Rows(i)("Barcode") & "'").FirstOrDefault()
            Dim drSales As DataRow = dsSales.Tables(0).Select("PCS_Barcode='" & ds.Tables(0).Rows(i)("Barcode") & "'").FirstOrDefault()
            Dim drSRet As DataRow = dsSalesRtn.Tables(0).Select("PCS_Barcode='" & ds.Tables(0).Rows(i)("Barcode") & "'").FirstOrDefault()
            Dim drStkIn1 As DataRow = dsTransferIn.Tables(0).Select("Barcode= '" & ds.Tables(0).Rows(i)("Barcode") & "'").FirstOrDefault()
            Dim drStkOut1 As DataRow = dsTransferOut.Tables(0).Select("PCS_Barcode='" & ds.Tables(0).Rows(i)("Barcode").ToString & "'").FirstOrDefault()
            'Dim drStkTrf As DataRow = dsTransfer.Tables(0).Select("PCS_Barcode='" & ds.Tables(0).Rows(i)("Barcode") & "'").FirstOrDefault()
            Dim drOpStk As DataRow = dsOpStk.Tables(0).Select("ItemId=" & ds.Tables(0).Rows(i)("TItemId") & " And CId=" & ds.Tables(0).Rows(i)("CId")).FirstOrDefault()

            If Not drOpStk Is Nothing Then
                opnStk = Format(Val(drOpStk("OpStk")), M_StockQtyRounding)
            Else
                opnStk = 0
            End If

            If Not drRcpt Is Nothing Then
                purchaseQty = Format(Val(drRcpt("Qty")), M_StockQtyRounding)
            Else
                purchaseQty = 0
            End If

            If Not drStockAdj Is Nothing Then
                stockAdj = Format(Val(drStockAdj("Qty")), M_StockQtyRounding)
            Else
                stockAdj = 0
            End If

            If Not drPRet Is Nothing Then
                purchaseRtnQty = Format(Val(drPRet("Qty")), M_StockQtyRounding)
            Else
                purchaseRtnQty = 0
            End If

            If Not drSales Is Nothing Then
                salesQty = Format(Val(drSales("TItemQty")), M_StockQtyRounding)
            Else
                salesQty = 0
            End If

            If Not drSRet Is Nothing Then
                salesReturnQty = Format(Val(drSRet("TItemQty")), M_StockQtyRounding)
            Else
                salesReturnQty = 0
            End If

            If Not drStkIn1 Is Nothing Then
                TransferIn = Format(Val(drStkIn1("Qty")), M_StockQtyRounding)
            Else
                TransferIn = 0
            End If

            If Not drStkOut1 Is Nothing Then
                TransferOut = Format(Val(drStkOut1("TItemQty")), M_StockQtyRounding)
            Else
                TransferOut = 0
            End If

            M_LiveStock = Format(opnStk + purchaseQty + salesReturnQty + TransferIn - salesQty - purchaseRtnQty - TransferOut + stockAdj, M_StockQtyRounding)
        Next
    End Sub

    Public Sub M_prepare_StockStatement_PurchaseBarCode_Alisons(_barcode As String, Filter As String)

        Dim ds As New Data.DataSet
        ds.Clear()

        sql_query = "Select *, 0.0 As Purchase, 0.0 As Sales, 0.0 As TransferIn, 0.0 As TransferOut, 0.0 As PurRtn, 0.0 As SalesRtn, 0.0 As StockQty From View_PurchaseBill " _
            & " Where Barcode = '" & _barcode & "'"

        obj.LoadData(sql_query, ds)

        Dim purchaseQty, purchaseRtnQty, salesQty, SalesRtnQty, MatIssueQty, StkAddQty, StkLessQty, StkInQty, StkOutQty As Double

        Dim dsPurchase As New Data.DataSet
        Dim dsPurchaseRtn As New Data.DataSet
        Dim dsSales As New Data.DataSet
        Dim dsSalesRtn As New Data.DataSet
        Dim dsSMatIssue As New Data.DataSet
        Dim dsstkAdjAdd As New Data.DataSet
        Dim dsstkAdjLess As New Data.DataSet
        Dim dsStockIn1 As New Data.DataSet
        Dim dsStockOut1 As New DataSet

        sql_query = "Select IsNull(Sum(Qty),0) As Qty, BarCode From View_PurchaseBill Where BarCode = '" & _barcode & "' And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType <> 'Debit Note' And PurchaseType <> 'Consignment Purchase' Group By BarCode"
        obj.LoadData(sql_query, dsPurchase)

        sql_query = "Select IsNull(Sum(Qty),0) As Qty, BarCode From View_PurchaseBill Where BarCode = '" & _barcode & "' And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And PurchaseAcType = 'Debit Note' Group By BarCode"
        obj.LoadData(sql_query, dsPurchaseRtn)

        sql_query = "Select IsNull(Sum(TItemQty),0) As Qty, UId As BarCode From View_TailoringInvoiceGST Where UId = '" & _barcode & "' And CId = " & M_CId & " And SalesAcType Not In ('Production Order', 'Credit Note') And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By UId" 'And Uom
        obj.LoadData(sql_query, dsSales)

        sql_query = "Select IsNull(Sum(TItemQty),0) As Qty, UId As BarCode From View_TailoringInvoiceGST Where UId = '" & _barcode & "' And CId = " & M_CId & " And SalesAcType = 'Credit Note' And (InvoiceDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And LIFlag <> 'DELETE' Group By UId" 'And Uom
        obj.LoadData(sql_query, dsSalesRtn)

        sql_query = "Select IsNull(Sum(IssueQty),0) As Qty, BarCode From View_MaterialIssuance Where BarCode = '" & _barcode & "' And CId = " & M_CId & " And (EntryDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') Group By BarCode"
        obj.LoadData(sql_query, dsSMatIssue)

        sql_query = "Select IsNull(Sum(Qty),0) As Qty, BarCode From tbl_StockAdjustment Where BarCode = '" & _barcode & "' And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'ADD' Group By BarCode"
        obj.LoadData(sql_query, dsstkAdjAdd)

        sql_query = "Select IsNull(Sum(Qty),0) As Qty, BarCode From tbl_StockAdjustment Where BarCode = '" & _barcode & "' And CId = " & M_CId & " And (DocDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "') And AddLess = 'LESS' Group By BarCode"
        obj.LoadData(sql_query, dsstkAdjLess)

        sql_query = "Select IsNull(Sum(AcceptQty),0) As Qty, BarCode From View_StockTransferDetail Where BarCode = '" & _barcode & "' And ToCId = " & M_CId & " And ReceiveDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By BarCode"
        obj.LoadData(sql_query, dsStockIn1)

        sql_query = "Select IsNull(Sum(TransferQty),0) As Qty, BarCode From View_StockTransferDetail Where BarCode = '" & _barcode & "' And FromCId = " & M_CId & " And TDate Between '" & Format(M_StockYrStart, M_DTMforQuery) & "' And '" & Format(Date.Now, M_DTMforQuery) & "' Group By BarCode"
        obj.LoadData(sql_query, dsStockOut1)


        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            purchaseQty = 0
            purchaseRtnQty = 0
            salesQty = 0
            SalesRtnQty = 0
            MatIssueQty = 0
            StkAddQty = 0
            StkLessQty = 0
            StkInQty = 0
            StkOutQty = 0

            Dim drPurchase As DataRow = dsPurchase.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()
            Dim drPurRtn As DataRow = dsPurchaseRtn.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()
            Dim drSale As DataRow = dsSales.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()
            Dim drSaleRtn As DataRow = dsSalesRtn.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()
            Dim drMatIssue As DataRow = dsSMatIssue.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()
            Dim drStkAdd As DataRow = dsstkAdjAdd.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()
            Dim drStkLess As DataRow = dsstkAdjLess.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()
            Dim drStkIn As DataRow = dsStockIn1.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()
            Dim drStkOut As DataRow = dsStockOut1.Tables(0).Select("Barcode='" & _barcode & "'").FirstOrDefault()

            If Not drPurchase Is Nothing Then
                purchaseQty = Format(Val(drPurchase("Qty")), M_StockQtyRounding)
            Else
                purchaseQty = 0
            End If

            If Not drPurRtn Is Nothing Then
                purchaseRtnQty = Format(Val(drPurRtn("Qty")), M_StockQtyRounding)
            Else
                purchaseRtnQty = 0
            End If

            If Not drSale Is Nothing Then
                salesQty = Format(Val(drSale("Qty")), M_StockQtyRounding)
            Else
                salesQty = 0
            End If

            If Not drSaleRtn Is Nothing Then
                SalesRtnQty = Format(Val(drSaleRtn("Qty")), M_StockQtyRounding)
            Else
                SalesRtnQty = 0
            End If

            If Not drMatIssue Is Nothing Then
                MatIssueQty = Format(Val(drMatIssue("Qty")), M_StockQtyRounding)
            Else
                MatIssueQty = 0
            End If

            If Not drStkAdd Is Nothing Then
                StkAddQty = Format(Val(drStkAdd("Qty")), M_StockQtyRounding)
            Else
                StkAddQty = 0
            End If

            If Not drStkLess Is Nothing Then
                StkLessQty = Format(Val(drStkLess("Qty")), M_StockQtyRounding)
            Else
                StkLessQty = 0
            End If

            If Not drStkIn Is Nothing Then
                StkInQty = Format(Val(drStkIn("Qty")), M_StockQtyRounding)
            Else
                StkInQty = 0
            End If

            If Not drStkOut Is Nothing Then
                StkOutQty = Format(Val(drStkOut("Qty")), M_StockQtyRounding)
            Else
                StkOutQty = 0
            End If

            M_LiveStock = Format(purchaseQty + SalesRtnQty + StkInQty + StkAddQty - purchaseRtnQty - salesQty - MatIssueQty - StkOutQty - StkLessQty, M_StockQtyRounding)
        Next
    End Sub

    Public Sub M_UpdateSoftware()
        Dim dr As DialogResult
        dr = MsgBox("Sure To Update Software ?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            If Not Directory.Exists(Application.StartupPath & "\UpdateExe") Then
                Directory.CreateDirectory(Application.StartupPath & "\UpdateExe")
            End If

            If Not Directory.Exists(Application.StartupPath & "\UpdateSQL") Then
                Directory.CreateDirectory(Application.StartupPath & "\UpdateSQL")
            End If

            If Not Directory.Exists(Application.StartupPath & "\UpdateReport") Then
                Directory.CreateDirectory(Application.StartupPath & "\UpdateReport")
            End If

            For Each filepath As String In Directory.GetFiles(Application.StartupPath & "\UpdateExe")
                File.Delete(filepath)
            Next

            For Each dir As String In Directory.GetDirectories(Application.StartupPath & "\UpdateExe")
                Directory.Delete(dir, True)
            Next

            For Each filepath As String In Directory.GetFiles(Application.StartupPath & "\UpdateSQL")
                File.Delete(filepath)
            Next

            For Each dir As String In Directory.GetDirectories(Application.StartupPath & "\UpdateSQL")
                Directory.Delete(dir, True)
            Next

            For Each filepath As String In Directory.GetFiles(Application.StartupPath & "\UpdateReport")
                File.Delete(filepath)
            Next

            For Each dir As String In Directory.GetDirectories(Application.StartupPath & "\UpdateReport")
                Directory.Delete(dir, True)
            Next

            Dim updFolderExe As String = ""
            Dim updFolderSrt As String = ""
            Dim updFolderRpt As String = ""
            Dim killExeName As String = ""
            Dim cnt As Integer = 0
            Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\Upd.txt")

            While reader.Peek <> -1
                If cnt = 0 Then
                    killExeName = reader.ReadLine()
                ElseIf cnt = 1 Then
                    updFolderExe = reader.ReadLine()
                ElseIf cnt = 2 Then
                    updFolderSrt = reader.ReadLine()
                Else
                    updFolderRpt = reader.ReadLine()
                End If
                cnt += 1
            End While

            reader.Close()
            Dim filename As String = Path.Combine(Application.StartupPath, "SmartUpdate.exe")
            Dim proc = System.Diagnostics.Process.Start(filename, killExeName & " " & updFolderExe & " " & updFolderSrt & " " & updFolderRpt)
        End If

    End Sub

    Public Sub M_UpdateDatabase()
        Dim dr As DialogResult
        dr = MsgBox("Sure To Update Database ?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            If Not Directory.Exists(Application.StartupPath & "\UpdateSQL") Then
                Directory.CreateDirectory(Application.StartupPath & "\UpdateSQL")
            End If
            obj.ChangeSQLpassword()
            Dim cnt As Integer = 0
            Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\Upd.txt")
            Dim updFolderSrt As String = ""
            Dim updFolderExe As String = ""
            Dim updFolderRpt As String = ""
            Dim killExeName As String = ""

            'While reader.Peek <> -1
            '    If cnt > 1 Then
            '        updFolderSrt = reader.ReadLine()
            '    End If
            '    cnt += 1
            'End While

            While reader.Peek <> -1
                If cnt = 0 Then
                    killExeName = reader.ReadLine()
                ElseIf cnt = 1 Then
                    updFolderExe = reader.ReadLine()
                ElseIf cnt = 2 Then
                    updFolderSrt = reader.ReadLine()
                Else
                    updFolderRpt = reader.ReadLine()
                End If
                cnt += 1
            End While

            reader.Close()

            SplashScreenManager.CloseForm(False)
            SplashScreenManager.ShowForm(GetType(WaitForm1))

            For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\UpdateSQL\SQLScript\" & updFolderSrt)
                Dim FileExtension As String = Path.GetExtension(foundFile)
                Try
                    If FileExtension.ToLower() = ".sql" Then
                        Using sr As StreamReader = New StreamReader(foundFile)
                            Dim FileNo As String = Path.GetFileNameWithoutExtension(foundFile)
                            Dim LastFileNo As String = obj.ScalarExecute("SELECT ConfigValue FROM dbo.tbl_Config WHERE UPPER(ConfigType) = 'SQL COUNTER'")

                            SplashScreenManager.Default.SetWaitFormDescription(LastFileNo)

                            If Convert.ToInt16(FileNo) > Convert.ToInt16(LastFileNo) Then
                                Dim script As String = File.ReadAllText(foundFile)

                                Dim commandStrings As IEnumerable(Of String) = Regex.Split(script, "^\s*GO\s*$", RegexOptions.Multiline Or RegexOptions.IgnoreCase)

                                For Each commandString As String In commandStrings
                                    If commandString.Trim() <> "" Then
                                        If Not obj.QueryExecute_Script(commandString) Then
                                            Exit Sub
                                        End If
                                    End If
                                Next
                                obj.QueryExecute("UPDATE tbl_Config SET ConfigValue = " + FileNo + " WHERE UPPER(ConfigType) = 'SQL COUNTER'")
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString())
                End Try
            Next

            SplashScreenManager.CloseForm()

            MessageBox.Show("Database Updated Successfully.", "DB Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub M_UpdateReport()
        Dim dr As DialogResult
        dr = MsgBox("Sure To Update Report File ?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            If Not Directory.Exists(Application.StartupPath & "\UpdateReport") Then
                Directory.CreateDirectory(Application.StartupPath & "\UpdateReport")
            End If

            Dim cnt As Integer = 0
            Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\Upd.txt")
            Dim updFolderRpt As String = ""
            While reader.Peek <> -1
                If cnt > 1 Then
                    updFolderRpt = reader.ReadLine()
                End If
                cnt += 1
            End While
            reader.Close()

            For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\UpdateReport\ReportFile\" & updFolderRpt)
                Dim FileExtension As String = Path.GetExtension(foundFile)
                Try
                    If FileExtension.ToLower() = ".mrt" Or FileExtension.ToLower() = ".rpt" Or FileExtension.ToLower() = ".xml" Then
                        If FileExtension.ToLower() = ".xml" Then
                            File.Copy(foundFile, Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "Report\GridLayout" & "\\" + Path.GetFileName(foundFile), True)
                        Else
                            File.Copy(foundFile, Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "Report" & "\\" + Path.GetFileName(foundFile), True)
                        End If

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString())
                End Try
            Next
            MessageBox.Show("Report File Updated Successfully.", "Report File Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub M_PushToServer(ByVal _soursqlquery As String, ByVal _destTable As String)
        ' Show splash screen
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Uploading data to server...")

        Try
            ' Load data from local Server
            Dim ds As New DataSet
            sql_query = _soursqlquery
            obj.LoadData(sql_query, ds)

            ' Push data to remote server
            If IsNothing(obj.ParallelCon) = True Then
                obj.openconnection_CRM()
            End If
            Dim ConpathServer As String = obj.ParallelCon.Replace("CRM_Sunrise", "dbOffline_Sync")

            Using ConServer As New SqlConnection(ConpathServer)
                ConServer.Open()

                ' Delete existing Data
                sql_query = "DELETE FROM " & _destTable & " WHERE DbName = '" & M_DbName & "' AND CId =  " & M_CId
                Using cmd As New SqlCommand(sql_query, ConServer)
                    cmd.ExecuteNonQuery()
                End Using

                ' Bulk insert new data 
                Using bulkCopy As New SqlBulkCopy(ConServer)
                    bulkCopy.DestinationTableName = _destTable
                    bulkCopy.BulkCopyTimeout = 0
                    bulkCopy.BatchSize = 5000

                    For Each col As DataColumn In ds.Tables(0).Columns
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
                    Next

                    bulkCopy.WriteToServer(ds.Tables(0))
                End Using
            End Using

            MsgBox("Data pushed successfully to server", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            SplashScreenManager.CloseForm()
        End Try
    End Sub


#End Region

#Region "GST"

    Public Function GenerateEINVNo(ByVal strarrSht1 As String, ByVal strarrSht2 As String, ByVal strarrSht3 As String, ByVal compid As Integer, ByVal BNo As String, ByVal YearId As Integer, ByVal BookVno As Integer, ByVal witheway As Integer, ByVal Optional TransTyp As String = "") As Boolean
        Try
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim token As String = GetToken(strarrSht1, strarrSht2, strarrSht3)

            Dim ds As New DataSet
            Dim dt As New DataTable
            'sql_query = "select * from View_CustInvoiceDetail_Vikas where SalesId = " + Val(BNo)
            '& "'N' as RegRev, '' AS EcmGstin, 'N' As IgstOnIntra, 'INV' as Typ, 'A1' + SalesBillNo as No, convert(varchar(10), " _
            'sql_query = "select '1.1' AS Version, 'GST' As TaxSch, Case When GSTNo = '' Then 'B2C' Else 'B2B' End As SupTyp, " _
            '          & "'N' as RegRev, '' AS EcmGstin, 'N' As IgstOnIntra, 'INV' as Typ, 'CCPL/' + '" & Format(M_YrStart, "yy") & "-" & Format(M_YrEnd, "yy") & "' + '/' + SalesBillNo as No, convert(varchar(10), " _
            '          & "SalesBillDate,103) As Dt, CGSTTinNo as Gstin, CName as LglNm, CName as TrdNm, CAdd1 As Addr1, CAdd2 As Addr2, " _
            '          & "CCity As Loc, CPincode As Pin, CStateCode As Stcd, CPhNo As Ph, CEMail As Em, GSTNo As B_Gstin, LedgerName As B_LglNm, " _
            '          & "LedgerName As B_TrdNm, SUBSTRING(State, 1, 2) As B_Pos, Address1 As B_Addr1	, Address2 As B_Addr2, " _
            '          & "City As B_Loc, PinCode As B_Pin,SUBSTRING(State, 1, 2) As B_Stcd, PhoneNo As B_Ph, EMail As B_Em, CName As D_Nm, " _
            '          & "CAdd1 As D_Addr1, CAdd2 As D_Addr2, CCity As D_Loc, CPincode As D_Pin, CState As D_Stcd, GSTNo As S_Gstin, " _
            '          & "LedgerName As S_LglNm, LedgerName As S_TrdNm, Address1 As S_Addr1, Address2 As S_Addr2, City As S_Loc, " _
            '          & "PinCode As S_Pin, SUBSTRING(State, 1, 2) As S_Stcd, ROW_NUMBER() OVER(ORDER BY SalesDetailId ASC) As SlNo, " _
            '          & "Remark1_D As PrdDesc, case when TItemName = 'COURIER / FREIGHT CHARGES' then 'Y' else 'N' END AS IsServc, " _
            '          & " case when TItemName = 'COURIER / FREIGHT CHARGES' THEN '996812' else HSNCode END AS HsnCd, '' AS Barcde, Qty, 0 AS FreeQty, 'PCS' AS Unit, " _
            '          & "SalesRate AS UnitPrice, TotalAmt_D as TotAmt, DiscAmt_D AS Discount, 0 as PreTaxVal, TaxableAmt_D as AssAmt, " _
            '          & "TaxPer as GstRt, IGST_Amt_D as IgstAmt, CGST_Amt_D as CgstAmt, SGST_Amt_D AS SgstAmt, 0 as CesRt, 0 as CesAmt," _
            '          & "0 as CesNonAdvlAmt, 0 as StateCesRt, 0 as StateCesAmt , 0 as StateCesNonAdvlAmt , 0 as OthChrg, ItemTotal as TotItemVal, " _
            '          & "'' as Bch_Nm, '' asBch_Expdt, '' as Bch_wrDt, '' as Attr_Nm, '' as Attr_Val, TaxableAmt As Val_AssVal, " _
            '          & "CGST_Amt AS Val_CgstVal, SGST_Amt As Val_SgstVal, IGST_Amt As Val_IgstVal, 0 AS Val_CesVal, " _
            '          & "0 AS Val_StCesVal, 0 AS Val_Discount , 0 AS Val_OthChrg, AdjustAmt AS Val_RndOffAmt, " _
            '          & "SalesBillAmt AS Val_TotInvVal, SalesBillAmt As Val_TotInvValFc, TGSTNo AS TransId, " _
            '          & "TransporterName AS TransName, LRNumber AS TransDocNo, 1 AS TransMode, 1 AS Distance, " _
            '          & "convert(varchar(10), SalesBillDate,103) as TransDocDt, Remark2 As VehNo, " _
            '          & "'R' As VehType  from View_SalesBill where SalesId = " & Val(BNo)

            'If (TransTyp = "DBN") Then
            '    sql_query = "select '1.1' AS Version, 'GST' As TaxSch, Case When GSTNo = '' Then 'B2C' Else 'B2B' End As SupTyp, " _
            '              & "'N' as RegRev, '' AS EcmGstin, 'N' As IgstOnIntra, Case When PurchaseType = 'Debit Note' then 'DBN' else 'INV' end as Typ, 'CCPL/' + '" & Format(M_YrStart, "yy") & "-" & Format(M_YrEnd, "yy") & "' + '/' + convert(varchar(10), PurchaseNo ,103) as No, convert(varchar(10), PurchaseBillDate ,103) As Dt, " _
            '              & "CGSTTinNo as Gstin, CName as LglNm, CName as TrdNm, CAdd1 As Addr1, CAdd2 As Addr2, " _
            '              & "CCity As Loc, CPincode As Pin, CStateCode As Stcd, CPhNo As Ph, CEMail As Em, GSTNo As B_Gstin, LedgerName As B_LglNm, " _
            '              & "LedgerName As B_TrdNm, SUBSTRING(State, 1, 2) As B_Pos, Address1 As B_Addr1	, Address2 As B_Addr2, " _
            '              & "City As B_Loc, PinCode As B_Pin,SUBSTRING(State, 1, 2) As B_Stcd, PhoneNo As B_Ph, EMail As B_Em, CName As D_Nm, " _
            '              & "CAdd1 As D_Addr1, CAdd2 As D_Addr2, CCity As D_Loc, CPincode As D_Pin, CState As D_Stcd, GSTNo As S_Gstin, " _
            '              & "LedgerName As S_LglNm, LedgerName As S_TrdNm, Address1 As S_Addr1, Address2 As S_Addr2, City As S_Loc, " _
            '              & "PinCode As S_Pin, SUBSTRING(State, 1, 2) As S_Stcd, ROW_NUMBER() OVER(ORDER BY PurchaseDetailId ASC) As SlNo, " _
            '              & "TItemName As PrdDesc, case when TItemName = 'COURIER / FREIGHT CHARGES' then 'Y' else 'N' END AS IsServc, " _
            '              & " case when TItemName = 'COURIER / FREIGHT CHARGES' THEN '996812' else HSNCode END AS HsnCd, '' AS Barcde, Qty, 0 AS FreeQty, 'PCS' AS Unit, " _
            '              & "PurchaseRate AS UnitPrice, TotalAmt_PD as TotAmt, DiscAmt_PD AS Discount, 0 as PreTaxVal, TaxableAmt_PD as AssAmt, " _
            '              & "TaxPer as GstRt, IGST_Amt_PD as IgstAmt, CGST_Amt_PD as CgstAmt, SGST_Amt_PD AS SgstAmt, 0 as CesRt, 0 as CesAmt,  " _
            '              & "0 as CesNonAdvlAmt, 0 as StateCesRt, 0 as StateCesAmt , 0 as StateCesNonAdvlAmt , 0 as OthChrg, ItemTotal_PD as TotItemVal, " _
            '              & "'' as Bch_Nm, '' asBch_Expdt, '' as Bch_wrDt, '' as Attr_Nm, '' as Attr_Val, TaxableAmt As Val_AssVal, " _
            '              & "CGST_Amt AS Val_CgstVal, SGST_Amt As Val_SgstVal, IGST_Amt As Val_IgstVal, 0 AS Val_CesVal, " _
            '              & "0 AS Val_StCesVal, 0 AS Val_Discount , 0 AS Val_OthChrg, AdjustAmt AS Val_RndOffAmt, " _
            '              & "PurchaseBillAmt AS Val_TotInvVal, PurchaseBillAmt As Val_TotInvValFc, TGSTNo AS TransId, " _
            '              & "TransporterName AS TransName, LRNumber AS TransDocNo, 1 AS TransMode, 0 AS Distance," _
            '              & "convert(varchar(10), PurchaseBillDate,103) as TransDocDt, Remark2 As VehNo, " _
            '              & "'R' As VehType  from View_PurchaseBill_EInvoice where PurchaseId = " & Val(BNo)

            'Else
            '    sql_query = "select '1.1' AS Version, 'GST' As TaxSch, Case When GSTNo = '' Then 'B2C' Else 'B2B' End As SupTyp, " _
            '                          & "'N' as RegRev, '' AS EcmGstin, 'N' As IgstOnIntra, Case When SalesType = 'Credit Note' then 'CRN' else 'INV' end as Typ, 'CCPL/' + '" & Format(M_YrStart, "yy") & "-" & Format(M_YrEnd, "yy") & "' + '/' + SalesBillNo as No, convert(varchar(10), " _
            '                          & "SalesBillDate,103) As Dt, CGSTTinNo as Gstin, CName as LglNm, CName as TrdNm, CAdd1 As Addr1, CAdd2 As Addr2, " _
            '                          & "CCity As Loc, CPincode As Pin, CStateCode As Stcd, CPhNo As Ph, CEMail As Em, GSTNo As B_Gstin, LedgerName As B_LglNm, " _
            '                          & "LedgerName As B_TrdNm, SUBSTRING(State, 1, 2) As B_Pos, Address1 As B_Addr1	, Address2 As B_Addr2, " _
            '                          & "City As B_Loc, PinCode As B_Pin,SUBSTRING(State, 1, 2) As B_Stcd, PhoneNo As B_Ph, EMail As B_Em, CName As D_Nm, " _
            '                          & "CAdd1 As D_Addr1, CAdd2 As D_Addr2, CCity As D_Loc, CPincode As D_Pin, CState As D_Stcd, GSTNo As S_Gstin, " _
            '                          & "LedgerName As S_LglNm, LedgerName As S_TrdNm, Address1 As S_Addr1, Address2 As S_Addr2, City As S_Loc, " _
            '                          & "PinCode As S_Pin, SUBSTRING(State, 1, 2) As S_Stcd, ROW_NUMBER() OVER(ORDER BY SalesDetailId ASC) As SlNo, " _
            '                          & "Remark1_D As PrdDesc, case when TItemName = 'COURIER / FREIGHT CHARGES' then 'Y' else 'N' END AS IsServc, " _
            '                          & " case when TItemName = 'COURIER / FREIGHT CHARGES' THEN '996812' else HSNCode END AS HsnCd, '' AS Barcde, Qty, 0 AS FreeQty, 'PCS' AS Unit, " _
            '                          & "SalesRate AS UnitPrice, TotalAmt_D as TotAmt, DiscAmt_D AS Discount, 0 as PreTaxVal, TaxableAmt_D as AssAmt, " _
            '                          & "TaxPer as GstRt, IGST_Amt_D as IgstAmt, CGST_Amt_D as CgstAmt, SGST_Amt_D AS SgstAmt, 0 as CesRt, 0 as CesAmt," _
            '                          & "0 as CesNonAdvlAmt, 0 as StateCesRt, 0 as StateCesAmt , 0 as StateCesNonAdvlAmt , 0 as OthChrg, ItemTotal as TotItemVal, " _
            '                          & "'' as Bch_Nm, '' asBch_Expdt, '' as Bch_wrDt, '' as Attr_Nm, '' as Attr_Val, TaxableAmt As Val_AssVal, " _
            '                          & "CGST_Amt AS Val_CgstVal, SGST_Amt As Val_SgstVal, IGST_Amt As Val_IgstVal, 0 AS Val_CesVal, " _
            '                          & "0 AS Val_StCesVal, 0 AS Val_Discount , 0 AS Val_OthChrg, AdjustAmt AS Val_RndOffAmt, " _
            '                          & "SalesBillAmt AS Val_TotInvVal, SalesBillAmt As Val_TotInvValFc, TGSTNo AS TransId, " _
            '                          & "TransporterName AS TransName, LRNumber AS TransDocNo, 1 AS TransMode, 1 AS Distance, " _
            '                          & "convert(varchar(10), SalesBillDate,103) as TransDocDt, Remark2 As VehNo, " _
            '                          & "'R' As VehType  from View_SalesBill where SalesId = " & Val(BNo)
            'End If

            sql_query = "select '1.1' AS Version, 'GST' As TaxSch, Case When GSTNo = '' Then 'B2C' Else 'B2B' End As SupTyp, " _
                      & "'N' as RegRev, '' AS EcmGstin, 'N' As IgstOnIntra, 'INV' as Typ, SalesBillNo as No, convert(varchar(10), SalesBillDate,103) As Dt, CGSTTinNo as Gstin, CName as LglNm, CName as TrdNm, CAdd1 As Addr1, CAdd2 As Addr2, " _
                      & "CCity As Loc, CPincode As Pin, CStateCode As Stcd, CPhNo As Ph, CEMail As Em, GSTNo As B_Gstin, LedgerName As B_LglNm,  " _
                      & "LedgerName As B_TrdNm, SUBSTRING(State, 1, 2) As B_Pos, Address1 As B_Addr1, Address2 As B_Addr2, " _
                      & "City As B_Loc, PinCode As B_Pin,SUBSTRING(State, 1, 2) As B_Stcd, PhoneNo As B_Ph, EMail As B_Em, CName As D_Nm,  " _
                      & "CAdd1 As D_Addr1, CAdd2 As D_Addr2, CCity As D_Loc, CPincode As D_Pin, CState As D_Stcd, GSTNo As S_Gstin," _
                      & "LedgerName As S_LglNm, LedgerName As S_TrdNm, Address1 As S_Addr1, Address2 As S_Addr2, City As S_Loc,  " _
                      & "PinCode As S_Pin, SUBSTRING(State, 1, 2) As S_Stcd, ROW_NUMBER() OVER(ORDER BY SalesDetailId ASC) As SlNo,  " _
                      & "TItemName As PrdDesc, case when ItemSubType = 'Tailoring' then 'Y' else 'N' END AS IsServc, " _
                      & " case when ItemSubType = 'Tailoring' THEN '996812' else HSNCode END AS HsnCd, '' AS Barcde, TItemQty As Qty, 0 AS FreeQty, UOM_M AS Unit,   " _
                      & "Rate AS UnitPrice, TotalAmt_D as TotAmt, DiscAmt_D AS Discount, 0 as PreTaxVal, TaxableAmt_D as AssAmt, " _
                      & "TaxPer as GstRt, IGSTAmt_SD as IgstAmt, CGSTAmt_SD as CgstAmt, SGSTAmt_SD AS SgstAmt, 0 as CesRt, 0 as CesAmt," _
                      & "0 as CesNonAdvlAmt, 0 as StateCesRt, 0 as StateCesAmt , 0 as StateCesNonAdvlAmt , 0 as OthChrg, ItemTotal as TotItemVal, " _
                      & "'' as Bch_Nm, '' asBch_Expdt, '' as Bch_wrDt, '' as Attr_Nm, '' as Attr_Val, TaxableAmt As Val_AssVal, " _
                      & "CGST_Amt AS Val_CgstVal, SGST_Amt As Val_SgstVal, IGST_Amt As Val_IgstVal, 0 AS Val_CesVal,  " _
                      & "0 AS Val_StCesVal, 0 AS Val_Discount , 0 AS Val_OthChrg, AdjustAmt AS Val_RndOffAmt,  " _
                      & "SalesBillAmt AS Val_TotInvVal, SalesBillAmt As Val_TotInvValFc, '' AS TransId,  " _
                      & "'' AS TransName, '' AS TransDocNo, 1 AS TransMode, 1 AS Distance,  " _
                      & "convert(varchar(10), SalesBillDate,103) as TransDocDt, Remark2 As VehNo, " _
                      & "'R' As VehType  from View_TailoringInvoiceGST_EINVOICE where InvId = " & Val(BNo)

            obj.LoadData(sql_query, ds)
            dt = ds.Tables(0)

            Dim invnoF As String = ""
            Dim EwayNo = New List(Of String)()

            For i As Integer = 0 To dt.Rows.Count - 1

                If invnoF = dt.Rows(i)("No").ToString().Trim() Then
                Else
                    invnoF = dt.Rows(i)("No").ToString().Trim()

                    If invnoF = "" Then
                    Else
                        Dim json As String = DataTableToJsonObjFOREINV(dt, i, witheway)
                        Dim EINV As String = GetEINVNo(token, json, strarrSht1, strarrSht2).Replace("{""ewayBillNo"":", "")

                        If EINV.ToUpper().Contains("DUPLICATE IRN") Then
                            Dim dupirn As String = EINV.Replace("DUPIRN", "#").Split("#"c)(1)
                            Dim strVal1 As String() = dupirn.Replace(",", "#").Split("#"c)
                            Dim AckNo As String = strVal1(1).Replace("AckNo", "#").Split("#"c)(1).ToString().Replace("""", "").Replace(":", "").Replace("\", "")
                            Dim IRN As String = strVal1(3).Replace("Irn", "#").Split("#"c)(1).ToString().Replace("""", "").Replace(":", "").Replace("\", "").Replace("}", "").Replace("]", "")
                            Dim SignedInvoice As String = ""
                            Dim SignedQRCode As String = ""
                            Dim path As String = AppDomain.CurrentDomain.BaseDirectory & "EINVNO.txt"
                            Dim Retval As Int64
                            ''Dim objMTrans As M_Trans = New M_Trans()
                            ''Retval = objMTrans.M_Trans_Update_EInvNo(compid, invnoF, AckNo, IRN, SignedInvoice, SignedQRCode, YearId, BookVno, "")

                            MessageBox.Show("IRN Already Generated Please read EinvMSG.txt File")
                            Return True
                        End If

                        If EINV.Contains("TOKEN EXPIRE") Then
                            MessageBox.Show("Please Try Again")
                            Return False
                        End If

                        Dim strVal As String() = EINV.Replace(",", "#").Split("#"c)

                        If strVal(0).ToString().Split(":"c)(1).ToString() = """1""" Then
                            Dim AckNo As String = strVal(1).Replace("AckNo", "#").Split("#"c)(1).ToString().Replace("""", "").Replace(":", "").Replace("\", "")
                            Dim IRN As String = strVal(3).Replace("Irn", "#").Split("#"c)(1).ToString().Replace("""", "").Replace(":", "").Replace("\", "")
                            Dim SignedInvoice As String = strVal(4).Replace("SignedInvoice", "#").Split("#"c)(1).ToString().Replace("""", "").Replace(":", "").Replace("\", "")
                            Dim SignedQRCode As String = strVal(5).Replace("SignedQRCode", "#").Split("#"c)(1).ToString().Replace("""", "").Replace(":", "").Replace("\", "")
                            Dim ewayno1 As String = ""

                            If witheway = 1 Then

                                If EINV.ToString().Contains("EWBERR") Then
                                    MessageBox.Show("Error In Ewaybill")
                                Else
                                    ewayno1 = strVal(7).Replace("EwbNo", "#").Split("#"c)(1).ToString().Replace("""", "").Replace(":", "").Replace("\", "")
                                End If
                            End If

                            Dim path As String = AppDomain.CurrentDomain.BaseDirectory & "EINVNO.txt"
                            Dim Retval As Int64
                            ''Dim objMTrans As M_Trans = New M_Trans()
                            '''Retval = objMTrans.M_Trans_Update_EInvNo(compid, invnoF, AckNo, IRN, SignedInvoice, SignedQRCode, YearId, BookVno, EwayNo)
                            ''Retval = objMTrans.M_Trans_Update_EInvNo(compid, invnoF, AckNo, IRN, SignedInvoice, SignedQRCode, YearId, BookVno, ewayno1)

                            If (TransTyp = "DBN") Then
                                obj.Prepare("SP_Insert_Purchase_E_Invoice", SpType.StoredProcedure)
                                obj.AddCmdParameter("@Insinv_purchase_id", Dtype.int, Val(BNo), ParaDirection.Input, True)
                                obj.AddCmdParameter("@Insinv_irn", Dtype.nvarchar, IRN, ParaDirection.Input, True)
                                obj.AddCmdParameter("@Insinv_acknowledgement", Dtype.nvarchar, AckNo, ParaDirection.Input, True)
                                obj.AddCmdParameter("@Insinv_qr_code", Dtype.nvarchar, SignedQRCode, ParaDirection.Input, True)
                                obj.AddCmdParameter("@Insinv_entry_date", Dtype.DateTime, DateTime.Now, ParaDirection.Input, True)
                                obj.ExecuteCommand()
                            Else
                                obj.Prepare("SP_InsertE_Invoice", SpType.StoredProcedure)
                                obj.AddCmdParameter("@Insinv_sales_id", Dtype.int, Val(BNo), ParaDirection.Input, True)
                                obj.AddCmdParameter("@Insinv_irn", Dtype.nvarchar, IRN, ParaDirection.Input, True)
                                obj.AddCmdParameter("@Insinv_acknowledgement", Dtype.nvarchar, AckNo, ParaDirection.Input, True)
                                obj.AddCmdParameter("@Insinv_qr_code", Dtype.nvarchar, SignedQRCode, ParaDirection.Input, True)
                                obj.AddCmdParameter("@Insinv_entry_date", Dtype.DateTime, DateTime.Now, ParaDirection.Input, True)
                                obj.ExecuteCommand()
                            End If

                        Else
                            Return False
                        End If
                    End If
                End If
            Next

            Return True
        Catch ex As Exception

            MessageBox.Show(ex.ToString())
            Return False
        End Try
    End Function

    Private Function GetToken(ByVal gstin As String, ByVal username As String, ByVal ewbpwd As String) As String
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim Token As String = ""
        Token = CheckToken(gstin, "Eway")

        If Token = "" Then

            Try
                backurl = getbackurl("einvapi")
            Catch ex As Exception
                backurl = "einvapi"
            End Try

            Dim URL As String = "https://" & M_EwayUrl & ".charteredinfo.com/eivital/dec/v1.04/auth?action=ACCESSTOKEN&aspid=1724692423&password=taxproCRM@123&Gstin=" & gstin.Trim() & "&user_name=" & username.Trim() & "&eInvPwd=" & ewbpwd.Trim()

            Try
                Dim client As WebClient = New WebClient()
                Dim data As Stream = client.OpenRead(URL)
                Dim reader As StreamReader = New StreamReader(data)
                Dim str As String = ""
                str = reader.ReadLine()

                If str IsNot Nothing Then
                    Dim strArr As String() = Nothing
                    strArr = str.Split(""""c)
                    Token = strArr(15).ToString()
                End If

                data.Close()
                Dim TokenWithTime = New List(Of String)()
                Dim path As String = AppDomain.CurrentDomain.BaseDirectory & gstin & "EwayToken.txt"
                TokenWithTime.Add(Token)
                TokenWithTime.Add(System.DateTime.Now.AddHours(5.45).ToString())
                File.WriteAllLines(path, TokenWithTime, Encoding.UTF8)
                Return Token
            Catch exp As WebException

                If exp.Response IsNot Nothing Then
                    Dim response As String = New StreamReader(exp.Response.GetResponseStream()).ReadToEnd()
                    MessageBox.Show(response)
                Else
                    MessageBox.Show(exp.Message)
                End If
            End Try
        End If

        Return Token
    End Function

    Public Function DataTableToJsonObjFOREINV(ByVal dt As DataTable, ByVal rowid As Integer, ByVal witheway As Integer) As String
        Dim ds As DataSet = New DataSet()
        ds.Merge(dt)
        Dim JsonString As StringBuilder = New StringBuilder()

        If ds IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
            Dim invno As String = ds.Tables(0).Rows(rowid)("No").ToString()
            JsonString.Append("{")
            JsonString.Append("""Version"":""" & ds.Tables(0).Rows(0)("Version").ToString() & """,")
            JsonString.Append("""TranDtls"": {")
            JsonString.Append("""TaxSch"":""" & ds.Tables(0).Rows(0)("TaxSch").ToString() & """,")
            JsonString.Append("""SupTyp"":""" & ds.Tables(0).Rows(0)("SupTyp").ToString() & """,")
            JsonString.Append("""RegRev"":""" & ds.Tables(0).Rows(0)("RegRev").ToString() & """,")
            JsonString.Append("""IgstOnIntra"":""" & ds.Tables(0).Rows(0)("IgstOnIntra").ToString() & """")
            JsonString.Append("},")
            JsonString.Append("""DocDtls"": {")
            JsonString.Append("""Typ"":""" & ds.Tables(0).Rows(0)("Typ").ToString() & """,")
            JsonString.Append("""No"":""" & ds.Tables(0).Rows(0)("No").ToString() & """,")
            JsonString.Append("""Dt"":""" & ds.Tables(0).Rows(0)("Dt").ToString() & """")
            JsonString.Append("},")
            JsonString.Append("""SellerDtls"": {")
            JsonString.Append("""Gstin"":""" & ds.Tables(0).Rows(0)("Gstin").ToString().Trim() & """,")
            JsonString.Append("""LglNm"":""" & ds.Tables(0).Rows(0)("LglNm").ToString().Trim() & """,")
            JsonString.Append("""TrdNm"":""" & ds.Tables(0).Rows(0)("TrdNm").ToString().Trim() & """,")
            JsonString.Append("""Addr1"":""" & ds.Tables(0).Rows(0)("Addr1").ToString().Trim() & """,")

            If ds.Tables(0).Rows(0)("Addr2").ToString().Trim() <> "" Then
                JsonString.Append("""Addr2"":""" & ds.Tables(0).Rows(0)("Addr2").ToString().Trim() & """,")
            End If

            JsonString.Append("""Loc"":""" & ds.Tables(0).Rows(0)("Loc").ToString().Trim() & """,")
            JsonString.Append("""Pin"":" & ds.Tables(0).Rows(0)("Pin").ToString().Trim() & ",")
            JsonString.Append("""Stcd"":""" & ds.Tables(0).Rows(0)("Stcd").ToString().Trim() & """,")

            If ds.Tables(0).Rows(0)("Ph").ToString().Trim() <> "" Then

                If ds.Tables(0).Rows(0)("Em").ToString().Trim() <> "" Then
                    JsonString.Append("""Ph"":""" & ds.Tables(0).Rows(0)("Ph").ToString().Trim() & """,")
                Else
                    JsonString.Append("""Ph"":""" & ds.Tables(0).Rows(0)("Ph").ToString().Trim() & """")
                End If
            Else

                If ds.Tables(0).Rows(0)("Em").ToString().Trim() <> "" Then
                    JsonString.Append("""Ph"":""" & "0000000000" & """,")
                Else
                    JsonString.Append("""Ph"":""" & "0000000000" & """")
                End If
            End If

            If ds.Tables(0).Rows(0)("Em").ToString().Trim() <> "" Then
                JsonString.Append("""Em"":""" & ds.Tables(0).Rows(0)("Em").ToString().Trim() & """")
            End If

            JsonString.Append("},")
            JsonString.Append("""BuyerDtls"": {")
            JsonString.Append("""Gstin"":""" & ds.Tables(0).Rows(0)("B_Gstin").ToString().Trim() & """,")
            JsonString.Append("""LglNm"":""" & ds.Tables(0).Rows(0)("B_LglNm").ToString().Trim() & """,")
            JsonString.Append("""TrdNm"":""" & ds.Tables(0).Rows(0)("B_TrdNm").ToString().Trim() & """,")
            JsonString.Append("""Pos"":""" & ds.Tables(0).Rows(0)("B_Pos").ToString().Trim() & """,")
            JsonString.Append("""Addr1"":""" & ds.Tables(0).Rows(0)("B_Addr1").ToString().Trim() & """,")

            If ds.Tables(0).Rows(0)("B_Addr2").ToString().Trim() <> "" Then
                JsonString.Append("""Addr2"":""" & ds.Tables(0).Rows(0)("B_Addr2").ToString().Trim() & """,")
            End If

            JsonString.Append("""Loc"":""" & ds.Tables(0).Rows(0)("B_Loc").ToString().Trim() & """,")
            JsonString.Append("""Pin"":" & ds.Tables(0).Rows(0)("B_Pin").ToString().Trim() & ",")
            JsonString.Append("""Stcd"":""" & ds.Tables(0).Rows(0)("B_Stcd").ToString().Trim() & """,")

            If ds.Tables(0).Rows(0)("B_Ph").ToString().Trim() <> "" Then
                JsonString.Append("""Ph"":""" & ds.Tables(0).Rows(0)("B_Ph").ToString().Trim() & """")
            Else
                JsonString.Append("""Ph"":""" & "0000000000" & """")
            End If

            JsonString.Append("},")

            If ds.Tables(0).Rows(0)("D_Nm").ToString() <> "" AndAlso ds.Tables(0).Rows(0)("D_Nm").ToString() <> ds.Tables(0).Rows(0)("LglNm").ToString().Trim() Then
                JsonString.Append("""DispDtls"":{")
                JsonString.Append("""Nm"":""" & ds.Tables(0).Rows(0)("D_Nm").ToString() & """,")
                JsonString.Append("""Addr1"":""" & ds.Tables(0).Rows(0)("D_Addr1").ToString().Trim() & """,")

                If ds.Tables(0).Rows(0)("D_Addr2").ToString().Trim() <> "" Then
                    JsonString.Append("""Addr2"":""" & ds.Tables(0).Rows(0)("D_Addr2").ToString().Trim() & """,")
                End If

                JsonString.Append("""Loc"":""" & ds.Tables(0).Rows(0)("D_Loc").ToString().Trim() & """,")
                JsonString.Append("""Pin"":" & ds.Tables(0).Rows(0)("D_Pin").ToString().Trim() & ",")
                JsonString.Append("""Stcd"":""" & ds.Tables(0).Rows(0)("D_Stcd").ToString().Trim() & """")
                JsonString.Append("},")
            End If

            If ds.Tables(0).Rows(0)("B_Gstin").ToString().Trim() <> ds.Tables(0).Rows(0)("S_Gstin").ToString().Trim() Then
                JsonString.Append("""ShipDtls"":{")
                JsonString.Append("""Gstin"":""" & ds.Tables(0).Rows(0)("S_Gstin").ToString().Trim() & """,")
                JsonString.Append("""LglNm"":""" & ds.Tables(0).Rows(0)("S_LglNm").ToString().Trim() & """,")
                JsonString.Append("""TrdNm"":""" & ds.Tables(0).Rows(0)("S_TrdNm").ToString().Trim() & """,")
                JsonString.Append("""Addr1"":""" & ds.Tables(0).Rows(0)("S_Addr1").ToString().Trim() & """,")

                If ds.Tables(0).Rows(0)("S_Addr2").ToString().Trim() <> "" Then
                    JsonString.Append("""Addr2"":""" & ds.Tables(0).Rows(0)("S_Addr2").ToString().Trim() & """,")
                End If

                JsonString.Append("""Loc"":""" & ds.Tables(0).Rows(0)("S_Loc").ToString().Trim() & """,")
                JsonString.Append("""Pin"":" & ds.Tables(0).Rows(0)("S_Pin").ToString().Trim() & ",")
                JsonString.Append("""Stcd"":""" & ds.Tables(0).Rows(0)("S_Stcd").ToString().Trim() & """")
                JsonString.Append("},")
            End If

            JsonString.Append("""itemList"": [")

            For i As Integer = rowid To ds.Tables(0).Rows.Count - 1

                If invno = ds.Tables(0).Rows(rowid)("No").ToString() Then
                Else
                    Exit For
                End If

                JsonString.Append("{")

                For j As Integer = 44 To 69 - 1

                    If j < 68 Then
                        Dim clmname As String = ds.Tables(0).Columns(j).ColumnName.ToString()

                        If clmname = "TotAmt" OrElse clmname = "TotItemVal" OrElse clmname = "OthChrg" OrElse clmname = "StateCesNonAdvlAmt" OrElse clmname = "StateCesAmt" OrElse clmname = "StateCesRt" OrElse clmname = "CesNonAdvlAmt" OrElse clmname = "CesAmt" OrElse clmname = "Qty" OrElse clmname = "FreeQty" OrElse clmname = "UnitPrice" OrElse clmname = "Discount" OrElse clmname = "PreTaxVal" OrElse clmname = "AssAmt" OrElse clmname = "GstRt" OrElse clmname = "IgstAmt" OrElse clmname = "CgstAmt" OrElse clmname = "SgstAmt" OrElse clmname = "CesRt" Then
                            JsonString.Append("""" & ds.Tables(0).Columns(j).ColumnName.ToString() & """:" + ds.Tables(0).Rows(i)(j).ToString() & ",")
                        ElseIf clmname = "Barcde" Then
                        Else
                            JsonString.Append("""" & ds.Tables(0).Columns(j).ColumnName.ToString() & """:" & """" + ds.Tables(0).Rows(i)(j).ToString() & """,")
                        End If
                    ElseIf j = 68 Then
                        JsonString.Append("""" & ds.Tables(0).Columns(j).ColumnName.ToString() & """:" + ds.Tables(0).Rows(i)(j).ToString())
                    End If
                Next

                JsonString.Append("},")
            Next

            Dim index = JsonString.ToString().LastIndexOf(","c)
            If index >= 0 Then JsonString.Remove(index, 1)
            JsonString.Append("], ")
            JsonString.Append("""ValDtls"": {")
            JsonString.Append("""AssVal"":" & ds.Tables(0).Rows(0)("Val_AssVal").ToString() & ",")
            JsonString.Append("""CgstVal"":" & ds.Tables(0).Rows(0)("Val_CgstVal").ToString() & ",")
            JsonString.Append("""SgstVal"":" & ds.Tables(0).Rows(0)("Val_SgstVal").ToString() & ",")
            JsonString.Append("""IgstVal"":" & ds.Tables(0).Rows(0)("Val_IgstVal").ToString() & ",")
            JsonString.Append("""CesVal"":" & ds.Tables(0).Rows(0)("Val_CesVal").ToString() & ",")
            JsonString.Append("""StCesVal"":" & ds.Tables(0).Rows(0)("Val_StCesVal").ToString() & ",")
            JsonString.Append("""Discount"":" & ds.Tables(0).Rows(0)("Val_Discount").ToString() & ",")
            JsonString.Append("""OthChrg"":" & ds.Tables(0).Rows(0)("Val_OthChrg").ToString() & ",")
            JsonString.Append("""RndOffAmt"":" & ds.Tables(0).Rows(0)("Val_RndOffAmt").ToString() & ",")
            JsonString.Append("""TotInvVal"":" & ds.Tables(0).Rows(0)("Val_TotInvVal").ToString() & ",")
            JsonString.Append("""TotInvValFc"":" & ds.Tables(0).Rows(0)("Val_TotInvValFc").ToString() & "")

            If witheway = 1 Then
                JsonString.Append("},")
                JsonString.Append("""EwbDtls"": {")

                If ds.Tables(0).Rows(0)("TransId").ToString().Trim() <> "" Then
                    JsonString.Append("""TransId"":""" & ds.Tables(0).Rows(0)("TransId").ToString() & """,")
                    JsonString.Append("""TransName"":""" & ds.Tables(0).Rows(0)("TransName").ToString() & """,")

                    If ds.Tables(0).Rows(0)("TransDocNo").ToString().Trim() <> "" Then
                        JsonString.Append("""TransDocNo"":""" & ds.Tables(0).Rows(0)("TransDocNo").ToString() & """,")
                    End If
                Else
                    JsonString.Append("""VehNo"":""" & ds.Tables(0).Rows(0)("VehNo").ToString() & """,")
                    JsonString.Append("""TransMode"":""" & ds.Tables(0).Rows(0)("TransMode").ToString() & """,")
                    JsonString.Append("""VehType"":""" & ds.Tables(0).Rows(0)("VehType").ToString() & """,")
                End If

                JsonString.Append("""Distance"":" & ds.Tables(0).Rows(0)("Distance").ToString() & "")
                JsonString.Append("}")
            Else
                JsonString.Append("}")
            End If

            JsonString.Append("}")
            Return JsonString.ToString()
        Else
            Return Nothing
        End If
    End Function

    Private Function GetEINVNo(ByVal authToken As String, ByVal json As String, ByVal gstin As String, ByVal username As String) As String
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        Try
            backurl = getbackurl("einvapi")
        Catch ex As Exception
            backurl = "einvapi"
        End Try

        Using webClient = New WebClient()
            Dim ewayUrl As String = ""

            Try
                Dim path As String = AppDomain.CurrentDomain.BaseDirectory & "EinvJson.txt"
                Dim jNo = New List(Of String)()
                jNo.Add(json)
                File.WriteAllLines(path, jNo, Encoding.UTF8)
                Dim cli = New WebClient()
                cli.Headers(HttpRequestHeader.ContentType) = "application/json"
                ewayUrl = "https://" & M_EwayUrl & ".charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1724692423&password=taxproCRM@123&gstin=" & gstin & "&AuthToken=" & authToken & "&user_name=" & username
                'Dim response As String = cli.UploadString("https://" & M_EwayUrl & ".charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1724692423&password=taxproCRM@123&gstin=" & gstin & "&AuthToken=" & authToken & "&user_name=" & username, json)

                Dim response As String = cli.UploadString("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1724692423&password=taxproCRM@123&gstin=" + gstin + "&AuthToken=" + authToken + "&user_name=" + username + "&QrCodeSize=250&[ParseIrnResp=0]", json)

                Dim path1 As String = AppDomain.CurrentDomain.BaseDirectory & "EinvMsg.txt"
                Dim jNo1 = New List(Of String)()
                jNo1.Add(response)
                File.WriteAllLines(path1, jNo1, Encoding.UTF8)

                If response.ToUpper().Contains("EXPIR") Then
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory & gstin & "EwayToken.txt")
                    response = "TOKEN EXPIRE"
                End If

                Return response
            Catch ex As WebException

                If ex.Response IsNot Nothing Then
                    Dim response As String = New StreamReader(ex.Response.GetResponseStream()).ReadToEnd()
                    Dim path1 As String = AppDomain.CurrentDomain.BaseDirectory & "EinvMsg.txt"
                    Dim jNo1 = New List(Of String)()
                    jNo1.Add(response)
                    File.WriteAllLines(path1, jNo1, Encoding.UTF8)
                    response = response & json & ewayUrl
                    Return response
                Else
                    Dim path1 As String = AppDomain.CurrentDomain.BaseDirectory & "EinvMsg.txt"
                    Dim jNo1 = New List(Of String)()
                    jNo1.Add(ex.Message)
                    File.WriteAllLines(path1, jNo1, Encoding.UTF8)
                    MessageBox.Show(ex.Message)
                End If
            End Try
        End Using

        Return ""
    End Function


    Dim TokenTime As DateTime
    Dim dtRtn As New DataTable()
    Dim backurl As String = "einvapi"

    Public Function CheckToken(ByVal gstin As String, ByVal TknType As String) As String
        Dim Token As String = ""
        Dim tokenFileName As String = ""

        If TknType = "Eway" Then
            tokenFileName = gstin & "EwayToken.txt"
        End If

        If TknType = "Gstr2a" Then
            tokenFileName = gstin & "Token.txt"
        End If

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & tokenFileName) = True Then
            Dim txtfilepath As String = AppDomain.CurrentDomain.BaseDirectory & tokenFileName
            Dim counter As Integer = 0
            Dim line1 As String
            Dim file As System.IO.StreamReader = New System.IO.StreamReader(txtfilepath)

            Dim a As String = ""
            Do
                a = file.ReadLine()
                If counter = 0 Then
                    Token = a
                End If
                If counter = 1 Then
                    TokenTime = DateTime.Parse(a.ToString())
                End If
                counter += 1
            Loop Until a Is Nothing

            file.Close()

            If TokenTime = Nothing OrElse System.DateTime.Now > TokenTime Then
                Token = ""
            Else
            End If
        End If

        Return Token
    End Function

    Public Function getbackurl(ByVal backurl As String) As String
        backurl = "einvapi"
        Return backurl
    End Function

#End Region

    Public Function Getwages(ByVal WorkerId As Integer, ByVal TitemId As Integer, ByVal ItemRate As String, ByVal IssueFor As String, ByVal EffectiveFrom As Date) As Integer
        'Get Wages WorkerId,TitemId,TitemRate,IssueFor,EffectiveFrom
        Dim Wages As New Integer
        Select Case M_WorkerWiseItemRates
            Case "Process Wise"
                '   txtWages.Text = dsProcess.Tables(0).Rows(cmbIssueFor.SelectedIndex)("Charges")
                Exit Select
            Case "Yes"
                Select Case M_TailoringItemMaster
                    Case <> "VCD"
                        ' sql_query = "Select Count(*) From tbl_WorkerItemWiseRate Where LedgerId = " & cmbIssueTo.SelectedValue & " And TItemId = " & Val(lblTItemId.Text) & " And WorkName = '" & cmbIssueFor.Text & "' And EffectiveFrom <= '" & Format(dtpIssueDate.Value, M_DTMforQuery) & "'"
                        sql_query = "Select Count(*) From tbl_WorkerItemWiseRate Where LedgerId = " & Val(WorkerId) & " And TItemId = " & Val(TitemId) & " And WorkName = '" & Trim(IssueFor) & "'"
                        Select Case obj.ScalarExecute(sql_query)
                            Case 0
                                MsgBox("Worker, Item and Work Wise Rate Not Maintained", MsgBoxStyle.Information)
                                Exit Select
                            Case Is > 0
                                Dim tmpDs As New Data.DataSet
                                sql_query = "Select Top(1) * From tbl_WorkerItemWiseRate Where LedgerId = " & Val(WorkerId) & " And TItemId = " & Val(TitemId) & " And WorkName = '" & Trim(IssueFor) & "' And EffectiveFrom <= '" & Format(EffectiveFrom, M_DTMforQuery) & "' Order By EffectiveFrom Desc"
                                obj.LoadData(sql_query, tmpDs)

                                Select Case tmpDs.Tables(0).Rows(0)("PerAmt")
                                    Case "%"
                                        Wages = Format(Val(ItemRate) * Val(tmpDs.Tables(0).Rows(0)("Rate")) / 100, "0.00")
                                    Case Else
                                        Wages = Val(tmpDs.Tables(0).Rows(0)("Rate"))
                                        Exit Select
                                End Select
                                Exit Select
                        End Select
                End Select
                Exit Select
            Case "No"
                Select Case M_TailoringItemMaster
                    Case "VCD"
                        sql_query = "Select Count(*) From tbl_WorkerItemWiseRate Where TItemId = " & Val(TitemId) & " And WorkName = '" & Trim(IssueFor) & "' And EffectiveFrom <= '" & Format(EffectiveFrom, M_DTMforQuery) & "'"
                        Select Case obj.ScalarExecute(sql_query)
                            Case 0
                                MsgBox("Worker, Item and Work Wise Rate Not Maintained", MsgBoxStyle.Information)
                                Exit Select
                            Case Is > 0
                                Dim tmpDs As New Data.DataSet
                                'sql_query = "Select Top(1) * From tbl_WorkerItemWiseRate Where TItemId = " & Val(lblTItemId.Text) & " And WorkName = '" & cmbIssueFor.Text & "' And EffectiveFrom <= '" & Format(dtpIssueDate.Value, M_DTMforQuery) & "' Order By EffectiveFrom Desc"
                                sql_query = "Select Top(1) * From tbl_WorkerItemWiseRate Where TItemId = " & Val(TitemId) & " And WorkName = '" & Trim(IssueFor) & "' Order By EffectiveFrom Desc"
                                obj.LoadData(sql_query, tmpDs)

                                Select Case tmpDs.Tables(0).Rows(0)("PerAmt")
                                    Case "%"
                                        Wages = Format(Val(ItemRate) * Val(tmpDs.Tables(0).Rows(0)("Rate")) / 100, "0.00")
                                        Exit Select
                                    Case Else
                                        Wages = Val(tmpDs.Tables(0).Rows(0)("Rate"))
                                        Exit Select
                                End Select
                                Exit Select
                        End Select
                        Exit Select
                    Case Else
                        Select Case UCase(Trim(IssueFor))
                            Case "CUTTING"
                                Wages = Val(obj.ScalarExecute("Select CuttingRate From tbl_TItemMaster Where TItemId = " & Val(TitemId)))
                                Exit Select
                            Case "SEWING", "STITCHING"
                                Wages = Val(obj.ScalarExecute("Select SewingRate From tbl_TItemMaster Where TItemId = " & Val(TitemId)))
                                Exit Select
                        End Select
                End Select
                Exit Select
        End Select

        Return Wages
    End Function

    Public Sub sendEmail(toEmail As String, emailSubject As String, emailBody As String, attachmentFilPath As String)
        Try
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False

            Smtp_Server.Credentials = New Net.NetworkCredential(getSettingValue("Email Id"), getSettingValue("Email Password"))
            Smtp_Server.Port = getSettingValue("Email SMTP Port")
            Smtp_Server.EnableSsl = getSettingValue("Email Enable SSL")
            Smtp_Server.Host = getSettingValue("Email SMTP Host")
            '========
            'System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
            '========

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(getSettingValue("Email Id"))
            e_mail.To.Add(toEmail)
            e_mail.Subject = emailSubject
            e_mail.IsBodyHtml = False
            e_mail.Body = emailBody

            e_mail.Priority = MailPriority.High

            If attachmentFilPath <> "" Then
                Dim attachment As Net.Mail.Attachment
                attachment = New Net.Mail.Attachment(attachmentFilPath)
                e_mail.Attachments.Add(attachment)
            End If

            Smtp_Server.Send(e_mail)

            emailStatus = "Sent"
        Catch ex As Exception
            MsgBox(ex.Message)
            emailStatus = "Failed"
        End Try
    End Sub

    ' Check PrintInvoice OR Etc... Count
    Public Sub M_Insert_BulkLog(ByVal tmpLogId As Integer, ByVal tmpLogType As String)
        sql_query = "INSERT INTO tbl_SMSTrail
                    ([InvId], [SmsType], [SmsDtm])
                    VALUES (" & tmpLogId & ", '" & tmpLogType & "', " & Format(Today, M_DTMforQuery) & ")"
        obj.QueryExecute(sql_query)
    End Sub

    Public Function M_CheckBulkLog(ByVal tmpLogId As Integer, ByVal tmpLogType As String) As Integer
        sql_query = "Select Count(*) From tbl_SMSTrail Where smsType = '" & tmpLogType & "' And InvId = " & tmpLogId
        Dim tmpprintTime = Val(obj.ScalarExecute(sql_query))
        Return tmpprintTime
    End Function

    ''======= Background Worker
    'Public tmpTimer As Timer
    'Public Sub BackServices()
    '    Dim period As Integer = 1 * 60 * 1000
    '    tmpTimer = New Timer(AddressOf Timerexecute, Nothing, period, period)
    'End Sub

    'Private Sub Timerexecute(state As Object)
    '    MsgBox("execute")
    'End Sub
End Module
