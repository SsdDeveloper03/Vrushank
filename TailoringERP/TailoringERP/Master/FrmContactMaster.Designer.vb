<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmContactMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContactMaster))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.cmbDesignation = New System.Windows.Forms.ComboBox()
        Me.txtContactNo = New System.Windows.Forms.TextBox()
        Me.lblBarCode = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.lblTItemName1 = New System.Windows.Forms.Label()
        Me.cmbContactType = New System.Windows.Forms.ComboBox()
        Me.gbMainDetail = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.txtRemark1 = New System.Windows.Forms.TextBox()
        Me.txtRemark2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbBroadcast = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbLedgerID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblContactId = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtworkNotes = New System.Windows.Forms.TextBox()
        Me.txtEmailID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSMobileNo = New System.Windows.Forms.TextBox()
        Me.txtSName = New System.Windows.Forms.TextBox()
        Me.lblF_LedgerName = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.gbMainDetail.SuspendLayout()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 23)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Name"
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(180, 24)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(595, 30)
        Me.txtName.TabIndex = 0
        '
        'lblItemType
        '
        Me.lblItemType.AutoSize = True
        Me.lblItemType.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemType.ForeColor = System.Drawing.Color.Black
        Me.lblItemType.Location = New System.Drawing.Point(440, 119)
        Me.lblItemType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(102, 23)
        Me.lblItemType.TabIndex = 96
        Me.lblItemType.Text = "Designation"
        '
        'cmbDesignation
        '
        Me.cmbDesignation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDesignation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDesignation.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDesignation.FormattingEnabled = True
        Me.cmbDesignation.Location = New System.Drawing.Point(572, 111)
        Me.cmbDesignation.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDesignation.Name = "cmbDesignation"
        Me.cmbDesignation.Size = New System.Drawing.Size(203, 31)
        Me.cmbDesignation.TabIndex = 4
        Me.cmbDesignation.Tag = "ItemType"
        '
        'txtContactNo
        '
        Me.txtContactNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactNo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNo.Location = New System.Drawing.Point(182, 69)
        Me.txtContactNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContactNo.MaxLength = 10
        Me.txtContactNo.Name = "txtContactNo"
        Me.txtContactNo.Size = New System.Drawing.Size(219, 30)
        Me.txtContactNo.TabIndex = 1
        '
        'lblBarCode
        '
        Me.lblBarCode.AutoSize = True
        Me.lblBarCode.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarCode.ForeColor = System.Drawing.Color.Black
        Me.lblBarCode.Location = New System.Drawing.Point(433, 76)
        Me.lblBarCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBarCode.Name = "lblBarCode"
        Me.lblBarCode.Size = New System.Drawing.Size(109, 23)
        Me.lblBarCode.TabIndex = 137
        Me.lblBarCode.Text = "Contact Type"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompanyName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyName.Location = New System.Drawing.Point(180, 110)
        Me.txtCompanyName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCompanyName.MaxLength = 50
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(221, 30)
        Me.txtCompanyName.TabIndex = 3
        '
        'lblTItemName1
        '
        Me.lblTItemName1.AutoSize = True
        Me.lblTItemName1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTItemName1.ForeColor = System.Drawing.Color.Black
        Me.lblTItemName1.Location = New System.Drawing.Point(12, 114)
        Me.lblTItemName1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTItemName1.Name = "lblTItemName1"
        Me.lblTItemName1.Size = New System.Drawing.Size(132, 23)
        Me.lblTItemName1.TabIndex = 150
        Me.lblTItemName1.Text = "Company Name"
        '
        'cmbContactType
        '
        Me.cmbContactType.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.cmbContactType.FormattingEnabled = True
        Me.cmbContactType.Location = New System.Drawing.Point(569, 70)
        Me.cmbContactType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbContactType.Name = "cmbContactType"
        Me.cmbContactType.Size = New System.Drawing.Size(206, 31)
        Me.cmbContactType.TabIndex = 2
        Me.cmbContactType.Tag = ""
        '
        'gbMainDetail
        '
        Me.gbMainDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMainDetail.Controls.Add(Me.Label11)
        Me.gbMainDetail.Controls.Add(Me.dtpBirthDate)
        Me.gbMainDetail.Controls.Add(Me.txtRemark1)
        Me.gbMainDetail.Controls.Add(Me.txtRemark2)
        Me.gbMainDetail.Controls.Add(Me.Label7)
        Me.gbMainDetail.Controls.Add(Me.Label8)
        Me.gbMainDetail.Controls.Add(Me.cmbBroadcast)
        Me.gbMainDetail.Controls.Add(Me.Label10)
        Me.gbMainDetail.Controls.Add(Me.Label6)
        Me.gbMainDetail.Controls.Add(Me.cmbLedgerID)
        Me.gbMainDetail.Controls.Add(Me.Label5)
        Me.gbMainDetail.Controls.Add(Me.Label4)
        Me.gbMainDetail.Controls.Add(Me.lblContactId)
        Me.gbMainDetail.Controls.Add(Me.Label3)
        Me.gbMainDetail.Controls.Add(Me.txtworkNotes)
        Me.gbMainDetail.Controls.Add(Me.txtEmailID)
        Me.gbMainDetail.Controls.Add(Me.Label1)
        Me.gbMainDetail.Controls.Add(Me.cmbContactType)
        Me.gbMainDetail.Controls.Add(Me.lblTItemName1)
        Me.gbMainDetail.Controls.Add(Me.txtCompanyName)
        Me.gbMainDetail.Controls.Add(Me.lblBarCode)
        Me.gbMainDetail.Controls.Add(Me.txtContactNo)
        Me.gbMainDetail.Controls.Add(Me.cmbDesignation)
        Me.gbMainDetail.Controls.Add(Me.lblItemType)
        Me.gbMainDetail.Controls.Add(Me.txtName)
        Me.gbMainDetail.Controls.Add(Me.Label2)
        Me.gbMainDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMainDetail.Location = New System.Drawing.Point(13, 8)
        Me.gbMainDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.gbMainDetail.Name = "gbMainDetail"
        Me.gbMainDetail.Padding = New System.Windows.Forms.Padding(4)
        Me.gbMainDetail.Size = New System.Drawing.Size(1429, 287)
        Me.gbMainDetail.TabIndex = 2
        Me.gbMainDetail.TabStop = False
        Me.gbMainDetail.Text = "Contact Details"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(834, 726)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 21)
        Me.Label11.TabIndex = 288
        Me.Label11.Text = "Mobile No."
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.dtpBirthDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBirthDate.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBirthDate.Location = New System.Drawing.Point(572, 152)
        Me.dtpBirthDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(203, 32)
        Me.dtpBirthDate.TabIndex = 6
        '
        'txtRemark1
        '
        Me.txtRemark1.AcceptsReturn = True
        Me.txtRemark1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark1.Location = New System.Drawing.Point(964, 116)
        Me.txtRemark1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRemark1.MaxLength = 50
        Me.txtRemark1.Multiline = True
        Me.txtRemark1.Name = "txtRemark1"
        Me.txtRemark1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemark1.Size = New System.Drawing.Size(335, 68)
        Me.txtRemark1.TabIndex = 10
        '
        'txtRemark2
        '
        Me.txtRemark2.AcceptsReturn = True
        Me.txtRemark2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark2.Location = New System.Drawing.Point(965, 210)
        Me.txtRemark2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRemark2.MaxLength = 50
        Me.txtRemark2.Multiline = True
        Me.txtRemark2.Name = "txtRemark2"
        Me.txtRemark2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemark2.Size = New System.Drawing.Size(335, 68)
        Me.txtRemark2.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(834, 213)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 23)
        Me.Label7.TabIndex = 163
        Me.Label7.Text = "Remark 2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(834, 119)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 23)
        Me.Label8.TabIndex = 161
        Me.Label8.Text = "Remark 1"
        '
        'cmbBroadcast
        '
        Me.cmbBroadcast.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBroadcast.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBroadcast.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBroadcast.FormattingEnabled = True
        Me.cmbBroadcast.Location = New System.Drawing.Point(572, 197)
        Me.cmbBroadcast.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBroadcast.Name = "cmbBroadcast"
        Me.cmbBroadcast.Size = New System.Drawing.Size(203, 31)
        Me.cmbBroadcast.TabIndex = 8
        Me.cmbBroadcast.Tag = "ItemType"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(455, 159)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 23)
        Me.Label10.TabIndex = 159
        Me.Label10.Text = "Birth Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(455, 200)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 23)
        Me.Label6.TabIndex = 159
        Me.Label6.Text = "Broadcast"
        '
        'cmbLedgerID
        '
        Me.cmbLedgerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLedgerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLedgerID.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLedgerID.FormattingEnabled = True
        Me.cmbLedgerID.Location = New System.Drawing.Point(180, 199)
        Me.cmbLedgerID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLedgerID.Name = "cmbLedgerID"
        Me.cmbLedgerID.Size = New System.Drawing.Size(221, 31)
        Me.cmbLedgerID.TabIndex = 7
        Me.cmbLedgerID.Tag = "ItemType"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 199)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 23)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "Ledger ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 73)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Contact No."
        '
        'lblContactId
        '
        Me.lblContactId.AutoEllipsis = True
        Me.lblContactId.AutoSize = True
        Me.lblContactId.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactId.ForeColor = System.Drawing.Color.Black
        Me.lblContactId.Location = New System.Drawing.Point(516, 251)
        Me.lblContactId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblContactId.Name = "lblContactId"
        Me.lblContactId.Size = New System.Drawing.Size(85, 23)
        Me.lblContactId.TabIndex = 154
        Me.lblContactId.Text = "contact id"
        Me.lblContactId.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(820, 31)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 23)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "WorkNotes"
        '
        'txtworkNotes
        '
        Me.txtworkNotes.AcceptsReturn = True
        Me.txtworkNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtworkNotes.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtworkNotes.Location = New System.Drawing.Point(964, 25)
        Me.txtworkNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.txtworkNotes.MaxLength = 50
        Me.txtworkNotes.Multiline = True
        Me.txtworkNotes.Name = "txtworkNotes"
        Me.txtworkNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtworkNotes.Size = New System.Drawing.Size(335, 68)
        Me.txtworkNotes.TabIndex = 9
        '
        'txtEmailID
        '
        Me.txtEmailID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmailID.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailID.Location = New System.Drawing.Point(182, 152)
        Me.txtEmailID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmailID.MaxLength = 50
        Me.txtEmailID.Name = "txtEmailID"
        Me.txtEmailID.Size = New System.Drawing.Size(219, 30)
        Me.txtEmailID.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 155)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 23)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "EmailID"
        '
        'gcData
        '
        Me.gcData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcData.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gcData.Location = New System.Drawing.Point(13, 303)
        Me.gcData.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.gcData.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gcData.MainView = Me.gvData
        Me.gcData.Margin = New System.Windows.Forms.Padding(4)
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(1429, 386)
        Me.gcData.TabIndex = 9
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'gvData
        '
        Me.gvData.Appearance.FooterPanel.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.gvData.Appearance.FooterPanel.Options.UseFont = True
        Me.gvData.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvData.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvData.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvData.Appearance.Row.Options.UseFont = True
        Me.gvData.GridControl = Me.gcData
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsBehavior.Editable = False
        Me.gvData.OptionsBehavior.ReadOnly = True
        Me.gvData.OptionsLayout.Columns.StoreAllOptions = True
        Me.gvData.OptionsView.ShowAutoFilterRow = True
        Me.gvData.OptionsView.ShowFooter = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        Me.gvData.RowHeight = 30
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(870, 704)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 21)
        Me.Label9.TabIndex = 288
        Me.Label9.Text = "Mobile No."
        '
        'txtSMobileNo
        '
        Me.txtSMobileNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSMobileNo.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMobileNo.Location = New System.Drawing.Point(977, 699)
        Me.txtSMobileNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSMobileNo.MaxLength = 50
        Me.txtSMobileNo.Name = "txtSMobileNo"
        Me.txtSMobileNo.Size = New System.Drawing.Size(156, 30)
        Me.txtSMobileNo.TabIndex = 7
        '
        'txtSName
        '
        Me.txtSName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSName.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSName.Location = New System.Drawing.Point(652, 699)
        Me.txtSName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSName.MaxLength = 50
        Me.txtSName.Name = "txtSName"
        Me.txtSName.Size = New System.Drawing.Size(180, 30)
        Me.txtSName.TabIndex = 6
        '
        'lblF_LedgerName
        '
        Me.lblF_LedgerName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblF_LedgerName.AutoSize = True
        Me.lblF_LedgerName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblF_LedgerName.ForeColor = System.Drawing.Color.Black
        Me.lblF_LedgerName.Location = New System.Drawing.Point(589, 704)
        Me.lblF_LedgerName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblF_LedgerName.Name = "lblF_LedgerName"
        Me.lblF_LedgerName.Size = New System.Drawing.Size(55, 21)
        Me.lblF_LedgerName.TabIndex = 286
        Me.lblF_LedgerName.Text = "Name "
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1337, 696)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 36)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Re&fresh"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(483, 696)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 36)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Cl&ose"
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Location = New System.Drawing.Point(382, 696)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 36)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.Red
        Me.btnDelete.Location = New System.Drawing.Point(283, 696)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 36)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnSave.Location = New System.Drawing.Point(195, 696)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 36)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.Maroon
        Me.btnEdit.Location = New System.Drawing.Point(96, 696)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(96, 36)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Modify"
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Blue
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(14, 696)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(81, 36)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "&New"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'FrmContactMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1455, 739)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.gcData)
        Me.Controls.Add(Me.txtSMobileNo)
        Me.Controls.Add(Me.gbMainDetail)
        Me.Controls.Add(Me.txtSName)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblF_LedgerName)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "FrmContactMaster"
        Me.Text = "Contact Master"
        Me.gbMainDetail.ResumeLayout(False)
        Me.gbMainDetail.PerformLayout()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblItemType As Label
    Friend WithEvents cmbDesignation As ComboBox
    Friend WithEvents txtContactNo As TextBox
    Friend WithEvents lblBarCode As Label
    Friend WithEvents txtCompanyName As TextBox
    Friend WithEvents lblTItemName1 As Label
    Friend WithEvents cmbContactType As ComboBox
    Friend WithEvents gbMainDetail As GroupBox
    Friend WithEvents cmbBroadcast As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbLedgerID As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtworkNotes As TextBox
    Friend WithEvents txtEmailID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRemark1 As TextBox
    Friend WithEvents txtRemark2 As TextBox
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSMobileNo As TextBox
    Friend WithEvents txtSName As TextBox
    Friend WithEvents lblF_LedgerName As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents dtpBirthDate As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents lblContactId As Label
    Friend WithEvents Label11 As Label
End Class
