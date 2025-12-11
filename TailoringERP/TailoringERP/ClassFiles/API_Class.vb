Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports Microsoft.Win32

Namespace API_Class
    '
    Public Class Data_List
        Public Property status As Boolean
        Public Property data As IList(Of CustomerList)
        Public Property message As String
    End Class

    Public Class CustomerList
        'Public Property ky As String
        'Public Property vl As String
        Public Property LedgerId As Integer
        Public Property CId As Integer
        Public Property GId As Integer
        Public Property country_id As Integer
        Public Property LedgerCode As String
        Public Property LedgerName As String
        Public Property Address As String
        Public Property City As String
        Public Property State As String
        Public Property Country As String
        Public Property Pincode As String
        Public Property ContactNo1 As String
        Public Property ContactNo2 As String
        Public Property Email1 As String
        Public Property Email2 As String
        Public Property Reference As String
        Public Property BirthDate As String
        Public Property AnniDate As String
        Public Property CustType As String
        Public Property GSTNo As String
        Public Property PANNo As String
        Public Property Taxation As String
        Public Property BeneficiaryName As String
        Public Property BankName As String
        Public Property BankAcNo As String
        Public Property BankAcType As String
        Public Property IFSC As String
        Public Property TranSMS As String
        Public Property PromoSMS As String
        Public Property balance As String
        Public Property IsActive As String
        Public Property image As String
        Public Property created_at As String
        Public Property DispOrder As String
    End Class


    Public Class Data_Measurement
        Public Property status As Boolean
        Public Property data As IList(Of CustomerData)
        Public Property message As String
    End Class

    Public Class CustomerData
        Public Property LedgerName As String
        Public Property LedgerId As String
        Public Property ContactNo1 As String
        Public Property CId As String
        Public Property measurements As IList(Of Measurement_List)
    End Class

    Public Class Measurement_List
        Public Property MId As String
        Public Property EntryDTM As String
        Public Property Paravalue As String
        Public Property Notes As String
        Public Property IsActive As String
        Public Property Name As String
    End Class

End Namespace