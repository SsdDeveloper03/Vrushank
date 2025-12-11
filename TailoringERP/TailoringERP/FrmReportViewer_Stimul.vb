Imports Sunrise.TailoringERP.DB
Imports Stimulsoft.Report
Imports TailoringERP.TailoringERP.DB

Public Class FrmReportViewer_Stimul
    '11/05/2024
#Region "Comments"
    'Name:TailoringSoftware
    'Created By:Mahesh
    'Form:FrmReportViewer
    'Date:20/10/2020
#End Region

#Region "Declaration"

    Dim _ds As New Data.DataSet
    Dim obj As New DBManager
    Dim sql_query As String
    Dim RptFileName As String = ""
    Dim ReportType As String = ""
    Dim IsDirectPrint As Boolean = False

    Public _rptTitle As String = ""
    Public oldFabValue As Double = 0.0
#End Region

#Region "Methods"

#End Region

#Region "Events"

    Public Sub New(ByVal _RptFileName As String, ByVal DataSet As DataSet, ByVal _ReportType As String, Optional ByVal _IsDirectPrint As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()
        RptFileName = _RptFileName
        _ds = DataSet
        ReportType = _ReportType
        IsDirectPrint = _IsDirectPrint
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FrmSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If RptFileName.Trim() = "" Then

        Else
            Dim dsComp As New DataSet()
            obj.LoadData("select * from tbl_CompanyMaster where CId = " & M_CId, dsComp)
            Dim stiRptV As New StiReport()
            stiRptV.Load(Strings.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Report\" & RptFileName)
            stiRptV.Compile()

            Select Case ReportType
                Case "T_INVOICE"
                    stiRptV.RegData("CompMaster", dsComp.Tables(0))
                    stiRptV.Item("OldFabricAmt") = oldFabValue
                    stiRptV.RegData("View_TailoringInvoiceGST", _ds.Tables("View_TailoringInvoiceGST"))
                    Exit Select
                Case "MEASUREMENT SLIP"
                    stiRptV.RegData("CompMaster", dsComp.Tables(0))
                    stiRptV.RegData("View_TraditionalMSlip", _ds.Tables("View_MeasurementSheetNew")) '' View_TraditionalMSlip
                    Exit Select
                Case "LABEL ITEM MASTER"
                    stiRptV.RegData("Label_ItemMaster", _ds.Tables("Label_ItemMaster"))
                    Exit Select
                Case "Item Label"
                    stiRptV.RegData("Barcode_Salrio", _ds.Tables("Barcode_Salrio"))
                    Exit Select
                Case "CHEQUE PRINT"
                    stiRptV.RegData("ChequePrint", _ds.Tables(0))
                    Exit Select
            End Select

            If IsDirectPrint Then
                stiRptV.Print(True)
            Else
                stiRptV.Render(False)
                stiRptV.Dictionary.Synchronize()
                StiViwerControl.Report = stiRptV
                StiViwerControl.Refresh()
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


#End Region

End Class