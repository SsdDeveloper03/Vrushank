Imports Sunrise.TailoringERP.DB
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen
Imports TailoringERP.TailoringERP.DB
'
Module ModVersion

    Public M_PCs As Integer = 1
    Public M_Users As Integer = 1
    Public pcWise As String = "Yes"
    Public userWise As String = "No"

    Dim M_ValidUpto As Date
    Public M_NewSettingFound As Boolean = False
    Public M_LoyaltyEnabled As Boolean = False
    Public M_RefferalEnabled As Boolean = False
    Public M_ProductionOrderEnabled As Boolean = False 'D : \PROJECTS\BhavikaGit17\TailoringERP\TailoringERP\ClassFiles\ModVersion.vb
    Dim obj As New DBManager
    Dim sql_query As String

    'if update customer this variable set false
    Public M_MyPc As Boolean = True
    'Public M_MyPc As Boolean = False

    Public M_HDSNumber As String '= "20246G446307"
    Public M_MacIP As String '= "50-65-F3-1B-E7-7A"
    Public M_IPAddress As String '= "192.168.5.205"
    Public dsLedgerMaster As New Data.DataSet
    Public dsMiscMaster As New Data.DataSet
    Public dsItemMaster As New Data.DataSet
    Public dsTailoringItems As New Data.DataSet
    Public dsUISettings As New Data.DataSet
    Public dsVoucherMaster As New Data.DataSet
    Public dsUserRights As New Data.DataSet
    Public dsPrintLayout As New Data.DataSet
    Public dsCuttingFormula As New Data.DataSet
    Public dsTSubItems As New Data.DataSet
    Public dsTaxStructureMaster As New Data.DataSet
    Public dsSettings As New Data.DataSet

    Public dvSettings As DataView


    Public Sub loadVoucherMaster()
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Vouchers...")

        dsVoucherMaster.Clear()
        sql_query = "Select * From tbl_VoucherMaster" ' Order By LedgerName
        obj.LoadData(sql_query, dsVoucherMaster)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadCuttingFormula()
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Cutting Formula...")

        dsCuttingFormula.Clear()
        sql_query = "Select * From tbl_CuttingFormula" ' Order By LedgerName
        obj.LoadData(sql_query, dsCuttingFormula)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadLedgerMaster()
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Ledger Data...")

        dsLedgerMaster.Clear()
        sql_query = "Select * From View_LedgerHelp" ' Order By LedgerName
        obj.LoadData(sql_query, dsLedgerMaster)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadMiscMaster()
        SplashScreenManager.CloseForm(False)
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Misc Data...")

        dsMiscMaster.Clear()
        sql_query = "Select * From tbl_MiscMaster" ' Order By MiscType, MiscName
        obj.LoadData(sql_query, dsMiscMaster)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadItemMaster()
        SplashScreenManager.CloseForm(False)
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Item Data...")

        dsItemMaster.Clear()
        sql_query = "Select Cast(0 as bit) As YN, * From tbl_TItemMaster Where ItemSubType = 'Sales'" ' Order By Barcode, TItemName"
        obj.LoadData(sql_query, dsItemMaster)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadTailoringItems()
        SplashScreenManager.CloseForm(False)
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Tailoring Items...")

        dsTailoringItems.Clear()
        sql_query = "Select * From View_TailoringItems Where IsActive = 'True' And ItemSubType = 'Tailoring'"
        obj.LoadData(sql_query, dsTailoringItems)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadTSubItems()
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Tailoring Sub-Items...")

        dsTSubItems.Clear()
        sql_query = "Select * From tbl_TSubItems "
        obj.LoadData(sql_query, dsTSubItems)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadTaxStructureMaster()
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Tax Structure Master...")

        dsTaxStructureMaster.Clear()
        sql_query = "Select * From tbl_TaxStructureMaster "
        obj.LoadData(sql_query, dsTaxStructureMaster)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadSettings()
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Settings...")

        dsSettings.Clear()
        sql_query = "Select * From tbl_Settings "
        obj.LoadData(sql_query, dsSettings)

        dvSettings = New DataView(dsSettings.Tables(0))

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadUISettings()
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading UiSettings...")

        dsUISettings.Clear()
        sql_query = "Select * From tbl_UISettings"
        obj.LoadData(sql_query, dsUISettings)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadUserRights()
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading User Rights...")

        dsUserRights.Clear()
        sql_query = "Select * from View_UserRightsDashboard"
        obj.LoadData(sql_query, dsUserRights)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub loadPrintLayout()
        SplashScreenManager.CloseForm(False)
        SplashScreenManager.ShowForm(GetType(WaitForm1))
        SplashScreenManager.Default.SetWaitFormDescription("Reloading Report Layout...")

        dsPrintLayout.Clear()
        sql_query = "Select * From tbl_PrintLayoutSelection Where IsActive = 'True'"
        obj.LoadData(sql_query, dsPrintLayout)

        SplashScreenManager.CloseForm()
    End Sub

    Public Sub CheckCloudVersionDate()
        Dim tmpdate1 As String = ""
        tmpdate1 = dsCRMDetails_Local.Tables(0).Rows(0)("DemoDate")

        M_ValidUpto = tmpdate1
        M_MaxDate = Format(M_ValidUpto, M_PCDTM)

        If DateDiff(DateInterval.Day, Today, M_MaxDate) < 7 Then
            MsgBox("Days Left: " & DateDiff(DateInterval.Day, Today, M_MaxDate) & vbCrLf & " Cloud Validity Expire Soon..", MsgBoxStyle.Information)
        End If

        If DateTime.Now > M_MaxDate Then
            MsgBox("Cloud Validity Expire Please Contect With Software Support Team", MsgBoxStyle.Information)
            End
        End If

    End Sub

    Public Sub setVersionAndDate()
        sql_query = "Select SettingValue from tbl_Settings Where SettingName = 'PC DTM'"
        M_PCDTM = obj.ScalarExecute(sql_query)

        Dim tmpDate As String = ""
        If M_DbName.Contains("dbSTE_Demo") Then 'If M_DbName = "dbSTE_Demo" Then
            sql_query = "Select MiscName From tbl_miscmaster Where misctype = 'V'" 'JWONWOANAJ
            tmpDate = obj.ScalarExecute(sql_query)
        Else
            tmpDate = dsCRMDetails_Local.Tables(0).Rows(0)("Reason")
            'DemoDate In Store Cloud DiscontinueDate If Use
            If IsDBNull(dsCRMDetails_Local.Tables(0).Rows(0)("DemoDate")) = False Then
                CheckCloudVersionDate()
            End If
        End If

        tmpDate = tmpDate.Replace("J", "1")
        tmpDate = tmpDate.Replace("A", "2")
        tmpDate = tmpDate.Replace("I", "3")
        tmpDate = tmpDate.Replace("S", "4")
        tmpDate = tmpDate.Replace("W", "5")
        tmpDate = tmpDate.Replace("M", "6")
        tmpDate = tmpDate.Replace("N", "7")
        tmpDate = tmpDate.Replace("R", "8")
        tmpDate = tmpDate.Replace("Y", "9")
        tmpDate = tmpDate.Replace("B", "0")
        tmpDate = tmpDate.Replace("G", "/")

        M_ValidUpto = tmpDate
        M_MaxDate = Format(M_ValidUpto, M_PCDTM)

        Select Case M_DbName
            Case "dbSTE_Demo"
                M_HDSNumber = "" '20246G446307
                M_MacIP = "" '5065F31BE77A
                M_IPAddress = "192.168.5.205"
                M_SoftType = "ERP"
                M_PCs = 0
                'M_ValidUpto = "15/05/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)
                M_LoyaltyEnabled = True
                M_RefferalEnabled = True
                M_ProductionOrderEnabled = True
                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Rathore"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "02/05/2024"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_SBJ"  ' 25/04/2024
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_INDISTICHED"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_MASTER"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_LuckySons"  ' 19/07/2024
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_RajFashion"
                'Purchase Date : "08/03/2024"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Fsd"
                'Purchase Date : "08/03/2024"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Highcraze"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "07/02/2024"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_HollyWood"
                'Purchase Date : "27/01/2024"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_StyleBU"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Shree"
                'Purchase Date : "06/11/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
            Case "dbSTE_YSA" 'Purchase Date: 13-10-2023
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Gaylord"
                'Purchase Date : "23/10/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
            Case "dbSTL_Srivarna"
                'Purchase Date : "04/09/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
            Case "dbSTS_ImageDressnew"
                'Purchase Date : "08/09/2023"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_ShadowX"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_MensStyle"
                'Purchase Date : "08/09/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_King" 'Purchase Date: 28-03-2024
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Greets" 'Purchase Date: 05-09-2023
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Rangoli"
                'Purchase Date : "01/08/2023"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
            Case "dbSTE_HTF"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_LR_SindhuBhavan", "dbSTE_LR_Citylight", "dbSTE_LR_Udaipur"
                M_SoftType = "ERP"
                M_PCs = 1
                'Purchase Date : "10/08/2023"

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
            Case "dbSTE_BOSS"
                M_SoftType = "ERP"
                M_PCs = 1
                'Purchase Date : "10/08/2023"

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
            Case "dbSTS_AK"
                'Purchase Date : "01/08/2023"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Asta"
                'Purchase Date : "01/06/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_SMB"
                'Purchase Date : "05/04/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_AANCHAL"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "20/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_PRT"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "20/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
            Case "dbTailoringERP_NewPunjab"
                M_HDSNumber = ""
                M_MacIP = ""
                M_IPAddress = ""
                M_SoftType = "ERP"
                M_PCs = 0
                'M_ValidUpto = "15/05/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)
                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False
                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Allwin" 'Sunilbhai Allwin Tailor - Surat
                M_HDSNumber = "WDWXC1A25R1NY3"
                M_MacIP = "2C600CAB3EAD"
                M_IPAddress = "192.168.137.1"
                'Purchase Date : 01/04/2016

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "31/03/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_KSons"
                'Purchase Date : "30/05/2023"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SRBT"
                'Purchase Date : "12/04/2023"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SSSM"
                'Purchase Date : "20/01/2023"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SSVC"
                'Purchase Date : "12/10/2021"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_VastraLok"
                'Purchase Date : "12/10/2021"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_NurNogori"
                'Purchase Date : "12/10/2021"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Supriya"
                'Purchase Date : "19/09/2022"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Sarita"
                'Purchase Date : "19/09/2022"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SevenArt"

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Bhagwani"
                'Purchase Date : "20/05/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Muktsari"
                'Purchase Date : "11/05/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_AmruthaFS"
                'Purchase Date : "10/05/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Aayna"
                M_OnlyCustomerManagement = "YES"
                'Purchase Date : "03/05/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_BSH"

                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_HighSteech"
                'Purchase Date : "29/04/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            'Case "dbSTL_TRENDZDECK"
            '    'Purchase Date : "19/09/2022"
            '    'M_SoftType = "TAILORING-LITE"

            '    M_PCs = 1
            '    'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

            '    M_LoyaltyEnabled = False
            '    M_RefferalEnabled = False
            '    M_ProductionOrderEnabled = False

            '    M_NewSettingFound = True
            '    Exit Select
            Case "dbSTL_Trendzdeck"
                'Purchase Date : "26/09/2022"
                'M_SoftType = "TAILORING-LITE"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_TUFF"
                'Purchase Date : "09/01/2023"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_DMTOUCH"
                'Purchase Date : "19/09/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Flair"
                'Purchase Date : "26/09/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Rolax"
                'Purchase Date : "19/09/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Flair"
                'Purchase Date : "26/09/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_MCS"
                'Purchase Date : "01/10/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_DSC"
                'Purchase Date : "02/10/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_ChhaganlalG"
                'Purchase Date : "30/10/2021"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Roopam" 'ROOPAM TAILOR Navin Soneja Maharastra
                M_HDSNumber = "PNY29202007160207EDE"
                M_MacIP = "00E04CF0128D"

                'Purchase Date : "06/02/2021"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "06/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Upkar"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "20/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Shalimar"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "24/09/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_SBOSS"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_JaiHind"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "20/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SUITOHOLIC"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SUITOHOLIC_SURAT"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_MLC" 'dbSTS_MLC To dbSTE_MLC At 30/06/2025
                'PurchaseDate = 30/03/2017
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "31/03/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Famous"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_GMW"

                'Purchase Date : 06/03/2018

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = ""
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_VIP"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "05/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SKumar"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SOFine" 'SO FINE TAILOR & EMPORIUM HARJOT Panjab
                'PurchaseDate = '29/04/2020'
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "06/04/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Sunny" 'SUNIL DODEJA-SUNNY APPREL - PUNE
                M_HDSNumber = "WDWX61A48H2C3K"
                M_MacIP = "8C1645C49D56"
                M_IPAddress = ""
                'Purchase Date: "17/10/2020"

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "17/10/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_VCD" ' Prathyusha Mam VCD - Channai - Tammilnadu
                M_HDSNumber = "2020202020202020585731"
                M_MacIP = "142D278207AA"
                M_IPAddress = ""
                'Purchase Date: "17/10/2020"

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Badasaab" 'JATIN RAWAL-BADASAAB TAILOR - RAJASTHAN
                M_HDSNumber = ""
                M_MacIP = "DC0EA191E310"
                M_IPAddress = "192.168.1.174"

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_18FOREWERRR"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/10/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Rehmat"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = ""
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Fakhruddin" 'YUSUF KAPADIA -FAKHRUDDIN & SONS - MUMBAI
                M_HDSNumber = "193723C67C6A"
                M_MacIP = "F04DA2B8A71C"
                'Purchase Date: 

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/12/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Riya"
                'Purchase Date: "2021"

                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/12/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_RAJ" ' Lite To STD Dt:-10/12/2024
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "31/12/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_LeeMan"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "30/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "STL_Popular"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Trimurti"
                'M_SoftType = "TAILORING-LITE"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "02/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Caliber"
                'M_SoftType = "TAILORING-STD"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "14/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Parampara" 'Parampara Setu Sir
                M_HDSNumber = "HBSB19142000029"
                M_MacIP = "9C7BEF1DD209"
                M_IPAddress = "192.168.1.174"
                'Purchase Date : 24/09/2019

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/11/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Parampara_RamMandir" 'Parampara Setu Sir

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/11/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Julie2024"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = ""
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_EVogue"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_HeeralUniform"
                M_SoftType = ""
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Vishal" 'VISHAL MODH VISHAL MODH - JAMNAGAR               
                M_HDSNumber = "2K42291ACEJC"
                M_MacIP = "3863BB81692B"
                'MacIP: 
                'Purchase Date:30/03/2017 

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "05/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Prime" 'VISHNU CHAVAN PRIME MTM -                 
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "17/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_RetailJoy"
                M_HDSNumber = ""
                M_MacIP = ""
                M_IPAddress = ""
                'PurchaseDate : "28/08/2020"

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "28/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Salrio" ' Kaizad irani salrio Nasik
                M_HDSNumber = "15VYC9UYT"
                M_MacIP = "ACD1B8D36782"
                M_IPAddress = "192.168.0.115"
                'Purchase Date : 

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True

                Exit Select
            Case "dbSTS_SJivraj"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/01/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Yoland"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Mankamna_2021"
                'Purchase Date = 09/06/2017
                M_HDSNumber = ""
                M_MacIP = ""
                M_IPAddress = ""
                'M_ValidUpto = "01/08/2021"

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_SIA"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_HiTone"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select

            Case "dbSTE_SHUBHKAMNA" 'dbTailoringERP_Shubhkamna
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/11/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Lucky" 'PRADEEP PAL LUCKY TAILOR - GWALIOR
                M_HDSNumber = "002538A801C7279D"
                M_MacIP = "F80DAC56BB6D"
                M_IPAddress = "192.168.29.147"

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Yesha_0712"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_MISHKAAT"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Navarachna" 'ARVIND PILOT -NAVARACHNA DESIGNER STUDIO - TRICHY               
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "08/03/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Pariwar" 'RAVI KHEMKA -PARIWAR TAILOR - VARANASI
                M_HDSNumber = "Z9AFMR3A"
                M_MacIP = "509A4C142F6B"
                M_IPAddress = "192.168.29.147"
                'Purchase Date:24/12/2020 

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "24/12/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Royal"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Royal" 'GIRIRAJ PRAJAPATI-ROYAL TAILOR - SHEOPUR
                M_HDSNumber = "5VVAJZQ3"
                M_MacIP = "A41F72969916"
                M_IPAddress = ""
                'Purchase Date: 

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/01/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_ShreeSagar" 'ISHWAR GAURALLA-SHREE SAGAR MENS WEAR - THANE-MUMBAI              
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "23/10/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_GMW"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "23/10/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Tulshi_Fashion"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "15/09/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
                Exit Select
            Case "dbSTE_Personage"
                'M_HDSNumber = "5VVAJZQ3"
                'M_MacIP = "A41F72969916"
                'M_IPAddress = ""
                'Purchase Date: "05/02/2021"

                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "05/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_BeautyTailors"
                M_HDSNumber = ""
                M_MacIP = ""
                M_IPAddress = ""

                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Maurya"
                M_HDSNumber = ""
                M_MacIP = ""
                M_IPAddress = ""

                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "26/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_TRS" 'TRS DRESS MAKERS - ADITYA-PAUL - PALAKKAD - KERALA
                M_HDSNumber = "2020202020204547324b3"
                M_MacIP = "0023124E795C"
                M_IPAddress = "192.168.1.22"

                'Purchase Date : 12/02/2021

                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "12/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_ImageDress" ' Image Dress Paul (STD-To-ERP 07/08/2025)
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/09/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_BR" 'ARIF IMANDAR BR MENS WEAR - MUMBAI              
                'PurchaseDate : 01/01/2020
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "31/12/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Dharmesh"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_RSTextile0822"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_RSTextile"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Badasaab"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Lazaro"
                'Purchase Date = 09/11/2017
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/11/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_National" 'Vazid Salim National Tailor
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "20/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_AthreyaBlouses"
                'Purchase Date = 01/02/2018
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/04/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_President"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_AlMoazzam"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "30/12/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Elite"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/06/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_MyChoise"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "03/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Yakin"
                'Purchase Date = 01/04/2018
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/04/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Gohil"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/12/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_PITHADIYA" '"dbTailoringERP_Pithadiya"
                'Purchase Date = 27/04/2016
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_RUTVA" ' Rakesh Darji Ahmedabad Lite To ERP At 12/07/2025
                'Purchase Date - 23/09/2020
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "1/10/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Officer"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "31/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Fashion" 'Lite To STD 04/11/2025
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "25/11/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Nizam"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "11/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_NewIndia" 'Afsar Khan 
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/04/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Vimlai"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/10/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_MC"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "05/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Stitchers"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "03/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_GURUDEV"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "04/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Eternity"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "26/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbTailoringERP_Maruti" 'Maheshbhai, Maruti Ladies Tailors, Bhuj (Purchase Date: July 2018, AMC Clear Upto: June 2020)
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "30/09/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_LAVANYA"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/11/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Pakiza"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "24/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_WonderCollection"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Mayuri"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "20/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_INDIA"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_ShiningStar"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "19/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Colours"
                'M_SoftType = "TAILORING-STD"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "31/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_FamousNeha"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "31/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Stylo"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "31/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Diya"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "31/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Monarch"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "31/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Sanjay"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "20/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Prasang"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_NareshFashion1"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_NareshFashion2"
                M_HDSNumber = "20246G446307"
                M_MacIP = "5065F31BE77A"
                M_IPAddress = "192.168.5.205"

                M_SoftType = "ERP"
                M_PCs = 0
                'M_ValidUpto = "15/05/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbBilling_Ambika"
                M_SoftType = "SALES"
                M_PCs = 0
                'M_ValidUpto = "15/05/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Shakir"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "20/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_UshaBagri" ' "dbSTS_UshaBagri"
                'Purchase Date : "09/12/2021"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/12/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_SinghCloth"
                'Purchase Date : "09/12/2021"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "15/01/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Shukala"
                'Purchase Date : "09/12/2021"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/12/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Swaraj" ' Change LITE To ERP 09/09/2025
                'Purchase Date : "06/10/2021"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Angles"
                'Purchase Date : "14/12/2021"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "15/01/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Atish"
                'Purchase Date : "24/12/2021"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "25/01/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Harnek"
                'Purchase Date : "10/04/2022"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "25/01/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_JKPlus"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Tailorstitch"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "13/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_TheTailorShop"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_GrabIt"
                'Purchase Date : "15/01/2022"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "28/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_MC"
                'Purchase Date : 
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "31/03/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_MKumar"
                'Purchase Date : "09/02/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "10/03/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "STS_Milantique"
                'Purchase Date : "02/02/2022"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "31/03/2022"

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_KFL2024"
                'Purchase Date : "15/01/2022"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "28/02/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_TR"
                'Purchase Date : "28/02/2022"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "28/03/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Maroon"
                'Purchase Date : "12/03/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "10/03/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Guruprasad" 'SUNIL DODEJA-SUNNY APPREL - PUNE
                'Purchase Date : "28/02/2022"
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "28/03/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Hamsa"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Yuva"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_SecretFashions"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Surbhi"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Sisws"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_NewSardar"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_MASTERPOINT"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_MAHARAJA"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_MK"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Shigasa" 'Vinay Patel
                'Purchase Date : "17/04/2022"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_SHAKIR"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_SeemaBrothers"
                'Purchase Date : "24/06/2022"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = True
                M_RefferalEnabled = True
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Expo"
                'Purchase Date : "27/06/2022"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Stylecottage"
                'Purchase Date : "28/06/2022"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Gloria"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_TrimBrim"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/01/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_AV"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_APML"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Cezors"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Victory"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Rolax"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_RatanlalS"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Ajanta"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_SUITOHOLIC_SURAT"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_CanvasStitches"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_Qmaa2024"
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Mayfair"
                'Purchase Date : "20/01/2023"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_DTailorStudio" '20/03/2024
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_AWAZ" 'Ahesan Subhni 11/03/2024
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = True
                M_RefferalEnabled = True
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Tryme" ' 11/04/2024
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_PBC"  ' 11/04/2024
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_JHT"  ' 12/04/2024
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSSS_Studio"  '12/09/2024
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'purchase 10/09/2024
                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_LuckyPos"  '26/09/2024
                M_SoftType = "SALES"
                M_PCs = 1
                'purchase 10/09/2024
                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Shtuthi" '14/05/2024
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_VMS"
                M_SoftType = "ERP"
                M_PCs = 1

                ' purchase Date:-17/5/2024
                ' Next update Date- 16/06/2024

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Priyanka" '18/11/2024
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                ' purchase Date:-12/11/2024
                ' Next update Date- 01/11/2024

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_SreeSrungar" '19/11/2024
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                ' purchase Date:-15/11/2024
                ' Next update Date- 

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select

            Case "dbSTL_Chandan" '17/12/2024
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1

                ' purchase Date:-17/12/2024
                ' Next update Date- 

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select

            Case "dbSTE_AliSons" '18/12/2024
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = True
                M_RefferalEnabled = True
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_GALAXY" '18/03/2025
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "01/07/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Kolony" '19/04/2025
                M_OnlyCustomerManagement = "YES"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "31/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Venus" '28/05/2025
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_ValidUpto = "31/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_DarAlDhahabi" 'Added 19/06/2025
                M_SoftType = "ERP"
                M_PCs = 1
                'M_ValidUpto = "20/08/2021"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_ARETE"
                'Purchase Date : "05/08/2025"
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTL_Goonj" 'Added 20/08/2025
                M_SoftType = "TAILORING-LITE"
                M_PCs = 1
                'M_ValidUpto = "01/10/2022"
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_PinkHanger" 'Added 17/10/2025
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTE_TailorMan" 'Added 17/10/2025
                M_SoftType = "ERP"
                M_PCs = 1

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Coatwala"
                'Purchase Date : "29/10/2025"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
            Case "dbSTS_Satish"
                'Purchase Date : "19/11/2025"
                M_SoftType = "TAILORING-STD"
                M_PCs = 1
                'M_MaxDate = Format(M_ValidUpto, M_PCDTM)

                M_LoyaltyEnabled = False
                M_RefferalEnabled = False
                M_ProductionOrderEnabled = False

                M_NewSettingFound = True
                Exit Select
        End Select
    End Sub

    Public Function getSettingValue(ByVal _SettingName As String) As String
        Dim tmpDT As New DataTable
        dvSettings.RowFilter = " SettingName = '" & _SettingName & "' And CId = " & M_CId
        tmpDT = dvSettings.ToTable

        Return tmpDT.Rows(0)("SettingValue")

        'sql_query = "Select V_Id From tbl_VoucherMaster Where V_Group = '" & V_Group & "'"
        'Return obj.ScalarExecute(sql_query)
    End Function

End Module
