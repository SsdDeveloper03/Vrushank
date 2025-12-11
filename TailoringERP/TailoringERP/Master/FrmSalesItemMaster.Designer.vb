<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSalesItemMaster
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSalesItemMaster))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.gbMainDetail = New System.Windows.Forms.GroupBox()
        Me.btnRemoveImg = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblBrowseimg = New System.Windows.Forms.LinkLabel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cmbBarcodeType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSalesRateA = New System.Windows.Forms.TextBox()
        Me.cmbItemSizeRange = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMRP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRackRate = New System.Windows.Forms.Label()
        Me.txtCommissionAmt = New System.Windows.Forms.TextBox()
        Me.lblCommissionAmt = New System.Windows.Forms.Label()
        Me.txtCommissionPer = New System.Windows.Forms.TextBox()
        Me.lblCommissionPer = New System.Windows.Forms.Label()
        Me.lblSalesDiscPer = New System.Windows.Forms.Label()
        Me.lblPurchaseDiscPer = New System.Windows.Forms.Label()
        Me.txtSalesDiscPer = New System.Windows.Forms.TextBox()
        Me.txtPurchaseDiscPer = New System.Windows.Forms.TextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblCatalogName = New System.Windows.Forms.Label()
        Me.txtCatalogName = New System.Windows.Forms.TextBox()
        Me.txtDesignNo = New System.Windows.Forms.TextBox()
        Me.lblDesignNo = New System.Windows.Forms.Label()
        Me.chkManageStock = New System.Windows.Forms.CheckBox()
        Me.cmbItemColor = New System.Windows.Forms.ComboBox()
        Me.lblItemColor = New System.Windows.Forms.Label()
        Me.lblPurchaseRate = New System.Windows.Forms.Label()
        Me.lblTItemName1 = New System.Windows.Forms.Label()
        Me.txtTItemName1 = New System.Windows.Forms.TextBox()
        Me.lblTaxPer = New System.Windows.Forms.Label()
        Me.txtTaxPer = New System.Windows.Forms.TextBox()
        Me.lblHSNCode = New System.Windows.Forms.Label()
        Me.txtHSNCode = New System.Windows.Forms.TextBox()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtPurchaseRate = New System.Windows.Forms.TextBox()
        Me.cmbItemSize = New System.Windows.Forms.ComboBox()
        Me.lblItemSize = New System.Windows.Forms.Label()
        Me.lblBarCode = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtOpStk = New System.Windows.Forms.TextBox()
        Me.lblOpStk = New System.Windows.Forms.Label()
        Me.txtReorderLevel = New System.Windows.Forms.TextBox()
        Me.lblReorderLevel = New System.Windows.Forms.Label()
        Me.pbImg = New System.Windows.Forms.PictureBox()
        Me.CMSImage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtImgPath = New System.Windows.Forms.TextBox()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSalesRate = New System.Windows.Forms.TextBox()
        Me.cmbUOM = New System.Windows.Forms.ComboBox()
        Me.cmbSupplierName = New System.Windows.Forms.ComboBox()
        Me.lblSupplierName = New System.Windows.Forms.Label()
        Me.cmbMfgName = New System.Windows.Forms.ComboBox()
        Me.lblMfgName = New System.Windows.Forms.Label()
        Me.cmbItemSubCategory = New System.Windows.Forms.ComboBox()
        Me.lblItemSubCategory = New System.Windows.Forms.Label()
        Me.cmbItemCategory = New System.Windows.Forms.ComboBox()
        Me.lblItemCategory = New System.Windows.Forms.Label()
        Me.cmbItemType = New System.Windows.Forms.ComboBox()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.txtTItemName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTItemCode = New System.Windows.Forms.TextBox()
        Me.lblTItemCode = New System.Windows.Forms.Label()
        Me.btnUpdateRates = New System.Windows.Forms.Button()
        Me.gcDetail = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.gvDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.YN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repYN = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.TItemId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RackPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DiscPer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateItemInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadOpeningStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviewBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectSubItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UncheckAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UISettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTItemId = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPrintCopies = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.gcData = New DevExpress.XtraGrid.GridControl()
        Me.gvData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnStockCheck = New System.Windows.Forms.Button()
        Me.cmbF_Company = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtF_ItemName = New System.Windows.Forms.TextBox()
        Me.txtF_BarcodeFrom = New System.Windows.Forms.TextBox()
        Me.lblBranch = New System.Windows.Forms.Label()
        Me.txtF_BarcodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrintItemBarcodes = New System.Windows.Forms.Button()
        Me.gbMainDetail.SuspendLayout()
        CType(Me.pbImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSImage.SuspendLayout()
        CType(Me.gcDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repYN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbF_Company.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbMainDetail
        '
        Me.gbMainDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMainDetail.Controls.Add(Me.btnRemoveImg)
        Me.gbMainDetail.Controls.Add(Me.btnStart)
        Me.gbMainDetail.Controls.Add(Me.lblBrowseimg)
        Me.gbMainDetail.Controls.Add(Me.Label34)
        Me.gbMainDetail.Controls.Add(Me.cmbBarcodeType)
        Me.gbMainDetail.Controls.Add(Me.Label7)
        Me.gbMainDetail.Controls.Add(Me.txtSalesRateA)
        Me.gbMainDetail.Controls.Add(Me.cmbItemSizeRange)
        Me.gbMainDetail.Controls.Add(Me.Label4)
        Me.gbMainDetail.Controls.Add(Me.txtMRP)
        Me.gbMainDetail.Controls.Add(Me.Label3)
        Me.gbMainDetail.Controls.Add(Me.lblRackRate)
        Me.gbMainDetail.Controls.Add(Me.txtCommissionAmt)
        Me.gbMainDetail.Controls.Add(Me.lblCommissionAmt)
        Me.gbMainDetail.Controls.Add(Me.txtCommissionPer)
        Me.gbMainDetail.Controls.Add(Me.lblCommissionPer)
        Me.gbMainDetail.Controls.Add(Me.lblSalesDiscPer)
        Me.gbMainDetail.Controls.Add(Me.lblPurchaseDiscPer)
        Me.gbMainDetail.Controls.Add(Me.txtSalesDiscPer)
        Me.gbMainDetail.Controls.Add(Me.txtPurchaseDiscPer)
        Me.gbMainDetail.Controls.Add(Me.lblLocation)
        Me.gbMainDetail.Controls.Add(Me.txtLocation)
        Me.gbMainDetail.Controls.Add(Me.lblCatalogName)
        Me.gbMainDetail.Controls.Add(Me.txtCatalogName)
        Me.gbMainDetail.Controls.Add(Me.txtDesignNo)
        Me.gbMainDetail.Controls.Add(Me.lblDesignNo)
        Me.gbMainDetail.Controls.Add(Me.chkManageStock)
        Me.gbMainDetail.Controls.Add(Me.cmbItemColor)
        Me.gbMainDetail.Controls.Add(Me.lblItemColor)
        Me.gbMainDetail.Controls.Add(Me.lblPurchaseRate)
        Me.gbMainDetail.Controls.Add(Me.lblTItemName1)
        Me.gbMainDetail.Controls.Add(Me.txtTItemName1)
        Me.gbMainDetail.Controls.Add(Me.lblTaxPer)
        Me.gbMainDetail.Controls.Add(Me.txtTaxPer)
        Me.gbMainDetail.Controls.Add(Me.lblHSNCode)
        Me.gbMainDetail.Controls.Add(Me.txtHSNCode)
        Me.gbMainDetail.Controls.Add(Me.txtValue)
        Me.gbMainDetail.Controls.Add(Me.lblValue)
        Me.gbMainDetail.Controls.Add(Me.txtPurchaseRate)
        Me.gbMainDetail.Controls.Add(Me.cmbItemSize)
        Me.gbMainDetail.Controls.Add(Me.lblItemSize)
        Me.gbMainDetail.Controls.Add(Me.lblBarCode)
        Me.gbMainDetail.Controls.Add(Me.txtBarcode)
        Me.gbMainDetail.Controls.Add(Me.txtOpStk)
        Me.gbMainDetail.Controls.Add(Me.lblOpStk)
        Me.gbMainDetail.Controls.Add(Me.txtReorderLevel)
        Me.gbMainDetail.Controls.Add(Me.lblReorderLevel)
        Me.gbMainDetail.Controls.Add(Me.pbImg)
        Me.gbMainDetail.Controls.Add(Me.Label15)
        Me.gbMainDetail.Controls.Add(Me.txtImgPath)
        Me.gbMainDetail.Controls.Add(Me.chkIsActive)
        Me.gbMainDetail.Controls.Add(Me.Label6)
        Me.gbMainDetail.Controls.Add(Me.txtSalesRate)
        Me.gbMainDetail.Controls.Add(Me.cmbUOM)
        Me.gbMainDetail.Controls.Add(Me.cmbSupplierName)
        Me.gbMainDetail.Controls.Add(Me.lblSupplierName)
        Me.gbMainDetail.Controls.Add(Me.cmbMfgName)
        Me.gbMainDetail.Controls.Add(Me.lblMfgName)
        Me.gbMainDetail.Controls.Add(Me.cmbItemSubCategory)
        Me.gbMainDetail.Controls.Add(Me.lblItemSubCategory)
        Me.gbMainDetail.Controls.Add(Me.cmbItemCategory)
        Me.gbMainDetail.Controls.Add(Me.lblItemCategory)
        Me.gbMainDetail.Controls.Add(Me.cmbItemType)
        Me.gbMainDetail.Controls.Add(Me.lblItemType)
        Me.gbMainDetail.Controls.Add(Me.txtTItemName)
        Me.gbMainDetail.Controls.Add(Me.Label2)
        Me.gbMainDetail.Controls.Add(Me.txtTItemCode)
        Me.gbMainDetail.Controls.Add(Me.lblTItemCode)
        Me.gbMainDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMainDetail.Location = New System.Drawing.Point(11, 5)
        Me.gbMainDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.gbMainDetail.Name = "gbMainDetail"
        Me.gbMainDetail.Padding = New System.Windows.Forms.Padding(4)
        Me.gbMainDetail.Size = New System.Drawing.Size(1231, 457)
        Me.gbMainDetail.TabIndex = 1
        Me.gbMainDetail.TabStop = False
        Me.gbMainDetail.Text = "Product Details"
        '
        'btnRemoveImg
        '
        Me.btnRemoveImg.BackColor = System.Drawing.SystemColors.Control
        Me.btnRemoveImg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveImg.Image = CType(resources.GetObject("btnRemoveImg.Image"), System.Drawing.Image)
        Me.btnRemoveImg.Location = New System.Drawing.Point(1081, 190)
        Me.btnRemoveImg.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveImg.Name = "btnRemoveImg"
        Me.btnRemoveImg.Size = New System.Drawing.Size(116, 36)
        Me.btnRemoveImg.TabIndex = 194
        Me.btnRemoveImg.Text = "Remove"
        Me.btnRemoveImg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemoveImg.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.SystemColors.Control
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Image = CType(resources.GetObject("btnStart.Image"), System.Drawing.Image)
        Me.btnStart.Location = New System.Drawing.Point(1167, 15)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(52, 34)
        Me.btnStart.TabIndex = 296
        Me.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'lblBrowseimg
        '
        Me.lblBrowseimg.AutoSize = True
        Me.lblBrowseimg.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBrowseimg.Location = New System.Drawing.Point(1057, 21)
        Me.lblBrowseimg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBrowseimg.Name = "lblBrowseimg"
        Me.lblBrowseimg.Size = New System.Drawing.Size(103, 23)
        Me.lblBrowseimg.TabIndex = 192
        Me.lblBrowseimg.TabStop = True
        Me.lblBrowseimg.Text = "Browse Img"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(9, 26)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(113, 23)
        Me.Label34.TabIndex = 191
        Me.Label34.Text = "Barcode Type"
        '
        'cmbBarcodeType
        '
        Me.cmbBarcodeType.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.cmbBarcodeType.FormattingEnabled = True
        Me.cmbBarcodeType.Items.AddRange(New Object() {"Item Master", "Purchase Time", "Piece Wise", "Vendor Barcode"})
        Me.cmbBarcodeType.Location = New System.Drawing.Point(144, 23)
        Me.cmbBarcodeType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBarcodeType.Name = "cmbBarcodeType"
        Me.cmbBarcodeType.Size = New System.Drawing.Size(221, 31)
        Me.cmbBarcodeType.TabIndex = 0
        Me.cmbBarcodeType.Tag = ""
        Me.cmbBarcodeType.Text = "Item Master"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(435, 181)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 23)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "Sales Rate - 2"
        '
        'txtSalesRateA
        '
        Me.txtSalesRateA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesRateA.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesRateA.Location = New System.Drawing.Point(561, 176)
        Me.txtSalesRateA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSalesRateA.MaxLength = 12
        Me.txtSalesRateA.Name = "txtSalesRateA"
        Me.txtSalesRateA.Size = New System.Drawing.Size(113, 30)
        Me.txtSalesRateA.TabIndex = 8
        Me.txtSalesRateA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbItemSizeRange
        '
        Me.cmbItemSizeRange.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.cmbItemSizeRange.FormattingEnabled = True
        Me.cmbItemSizeRange.Location = New System.Drawing.Point(931, 62)
        Me.cmbItemSizeRange.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbItemSizeRange.Name = "cmbItemSizeRange"
        Me.cmbItemSizeRange.Size = New System.Drawing.Size(119, 31)
        Me.cmbItemSizeRange.TabIndex = 19
        Me.cmbItemSizeRange.Tag = "ItemSizeRange"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(9, 222)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 23)
        Me.Label4.TabIndex = 187
        Me.Label4.Text = "MRP"
        '
        'txtMRP
        '
        Me.txtMRP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMRP.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMRP.Location = New System.Drawing.Point(144, 217)
        Me.txtMRP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMRP.MaxLength = 12
        Me.txtMRP.Name = "txtMRP"
        Me.txtMRP.Size = New System.Drawing.Size(113, 30)
        Me.txtMRP.TabIndex = 9
        Me.txtMRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(265, 143)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 23)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "Unit"
        '
        'lblRackRate
        '
        Me.lblRackRate.AutoSize = True
        Me.lblRackRate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRackRate.ForeColor = System.Drawing.Color.Black
        Me.lblRackRate.Location = New System.Drawing.Point(1059, 300)
        Me.lblRackRate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRackRate.Name = "lblRackRate"
        Me.lblRackRate.Size = New System.Drawing.Size(80, 23)
        Me.lblRackRate.TabIndex = 184
        Me.lblRackRate.Text = "RackRate"
        '
        'txtCommissionAmt
        '
        Me.txtCommissionAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCommissionAmt.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.txtCommissionAmt.Location = New System.Drawing.Point(824, 217)
        Me.txtCommissionAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCommissionAmt.MaxLength = 6
        Me.txtCommissionAmt.Name = "txtCommissionAmt"
        Me.txtCommissionAmt.Size = New System.Drawing.Size(159, 30)
        Me.txtCommissionAmt.TabIndex = 23
        Me.txtCommissionAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCommissionAmt
        '
        Me.lblCommissionAmt.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblCommissionAmt.ForeColor = System.Drawing.Color.Black
        Me.lblCommissionAmt.Location = New System.Drawing.Point(685, 222)
        Me.lblCommissionAmt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCommissionAmt.Name = "lblCommissionAmt"
        Me.lblCommissionAmt.Size = New System.Drawing.Size(129, 22)
        Me.lblCommissionAmt.TabIndex = 183
        Me.lblCommissionAmt.Text = "Comm. Amt"
        Me.lblCommissionAmt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtCommissionPer
        '
        Me.txtCommissionPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCommissionPer.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.txtCommissionPer.Location = New System.Drawing.Point(824, 178)
        Me.txtCommissionPer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCommissionPer.MaxLength = 6
        Me.txtCommissionPer.Name = "txtCommissionPer"
        Me.txtCommissionPer.Size = New System.Drawing.Size(159, 30)
        Me.txtCommissionPer.TabIndex = 22
        Me.txtCommissionPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCommissionPer
        '
        Me.lblCommissionPer.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblCommissionPer.ForeColor = System.Drawing.Color.Black
        Me.lblCommissionPer.Location = New System.Drawing.Point(685, 183)
        Me.lblCommissionPer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCommissionPer.Name = "lblCommissionPer"
        Me.lblCommissionPer.Size = New System.Drawing.Size(129, 22)
        Me.lblCommissionPer.TabIndex = 182
        Me.lblCommissionPer.Text = "Comm. (%)"
        Me.lblCommissionPer.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSalesDiscPer
        '
        Me.lblSalesDiscPer.AutoSize = True
        Me.lblSalesDiscPer.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalesDiscPer.ForeColor = System.Drawing.Color.Black
        Me.lblSalesDiscPer.Location = New System.Drawing.Point(491, 222)
        Me.lblSalesDiscPer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSalesDiscPer.Name = "lblSalesDiscPer"
        Me.lblSalesDiscPer.Size = New System.Drawing.Size(60, 23)
        Me.lblSalesDiscPer.TabIndex = 179
        Me.lblSalesDiscPer.Text = "Disc %"
        '
        'lblPurchaseDiscPer
        '
        Me.lblPurchaseDiscPer.AutoSize = True
        Me.lblPurchaseDiscPer.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurchaseDiscPer.ForeColor = System.Drawing.Color.Black
        Me.lblPurchaseDiscPer.Location = New System.Drawing.Point(412, 143)
        Me.lblPurchaseDiscPer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPurchaseDiscPer.Name = "lblPurchaseDiscPer"
        Me.lblPurchaseDiscPer.Size = New System.Drawing.Size(135, 23)
        Me.lblPurchaseDiscPer.TabIndex = 178
        Me.lblPurchaseDiscPer.Text = "Purchase Disc %"
        '
        'txtSalesDiscPer
        '
        Me.txtSalesDiscPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesDiscPer.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesDiscPer.Location = New System.Drawing.Point(561, 217)
        Me.txtSalesDiscPer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSalesDiscPer.MaxLength = 6
        Me.txtSalesDiscPer.Name = "txtSalesDiscPer"
        Me.txtSalesDiscPer.Size = New System.Drawing.Size(113, 30)
        Me.txtSalesDiscPer.TabIndex = 10
        Me.txtSalesDiscPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPurchaseDiscPer
        '
        Me.txtPurchaseDiscPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseDiscPer.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurchaseDiscPer.Location = New System.Drawing.Point(561, 138)
        Me.txtPurchaseDiscPer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPurchaseDiscPer.MaxLength = 6
        Me.txtPurchaseDiscPer.Name = "txtPurchaseDiscPer"
        Me.txtPurchaseDiscPer.Size = New System.Drawing.Size(113, 30)
        Me.txtPurchaseDiscPer.TabIndex = 6
        Me.txtPurchaseDiscPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLocation
        '
        Me.lblLocation.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.Black
        Me.lblLocation.Location = New System.Drawing.Point(685, 143)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(129, 22)
        Me.lblLocation.TabIndex = 175
        Me.lblLocation.Text = "Location"
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLocation
        '
        Me.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocation.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(824, 138)
        Me.txtLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLocation.MaxLength = 25
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(225, 30)
        Me.txtLocation.TabIndex = 21
        '
        'lblCatalogName
        '
        Me.lblCatalogName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCatalogName.ForeColor = System.Drawing.Color.Black
        Me.lblCatalogName.Location = New System.Drawing.Point(685, 300)
        Me.lblCatalogName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCatalogName.Name = "lblCatalogName"
        Me.lblCatalogName.Size = New System.Drawing.Size(129, 22)
        Me.lblCatalogName.TabIndex = 173
        Me.lblCatalogName.Text = "Catalog"
        Me.lblCatalogName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtCatalogName
        '
        Me.txtCatalogName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCatalogName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCatalogName.Location = New System.Drawing.Point(824, 295)
        Me.txtCatalogName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCatalogName.MaxLength = 20
        Me.txtCatalogName.Name = "txtCatalogName"
        Me.txtCatalogName.Size = New System.Drawing.Size(225, 30)
        Me.txtCatalogName.TabIndex = 25
        '
        'txtDesignNo
        '
        Me.txtDesignNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesignNo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesignNo.Location = New System.Drawing.Point(824, 98)
        Me.txtDesignNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDesignNo.MaxLength = 20
        Me.txtDesignNo.Name = "txtDesignNo"
        Me.txtDesignNo.Size = New System.Drawing.Size(225, 30)
        Me.txtDesignNo.TabIndex = 20
        '
        'lblDesignNo
        '
        Me.lblDesignNo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignNo.ForeColor = System.Drawing.Color.Black
        Me.lblDesignNo.Location = New System.Drawing.Point(685, 103)
        Me.lblDesignNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDesignNo.Name = "lblDesignNo"
        Me.lblDesignNo.Size = New System.Drawing.Size(129, 22)
        Me.lblDesignNo.TabIndex = 171
        Me.lblDesignNo.Text = "Design No"
        Me.lblDesignNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkManageStock
        '
        Me.chkManageStock.AutoSize = True
        Me.chkManageStock.Checked = True
        Me.chkManageStock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkManageStock.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkManageStock.Location = New System.Drawing.Point(937, 338)
        Me.chkManageStock.Margin = New System.Windows.Forms.Padding(4)
        Me.chkManageStock.Name = "chkManageStock"
        Me.chkManageStock.Size = New System.Drawing.Size(143, 27)
        Me.chkManageStock.TabIndex = 27
        Me.chkManageStock.TabStop = False
        Me.chkManageStock.Text = "Manage Stock"
        Me.chkManageStock.UseVisualStyleBackColor = True
        '
        'cmbItemColor
        '
        Me.cmbItemColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbItemColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItemColor.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItemColor.FormattingEnabled = True
        Me.cmbItemColor.Location = New System.Drawing.Point(824, 257)
        Me.cmbItemColor.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbItemColor.Name = "cmbItemColor"
        Me.cmbItemColor.Size = New System.Drawing.Size(159, 31)
        Me.cmbItemColor.TabIndex = 24
        Me.cmbItemColor.Tag = "ItemColor"
        '
        'lblItemColor
        '
        Me.lblItemColor.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemColor.ForeColor = System.Drawing.Color.Black
        Me.lblItemColor.Location = New System.Drawing.Point(685, 262)
        Me.lblItemColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemColor.Name = "lblItemColor"
        Me.lblItemColor.Size = New System.Drawing.Size(129, 22)
        Me.lblItemColor.TabIndex = 163
        Me.lblItemColor.Text = "Color"
        Me.lblItemColor.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPurchaseRate
        '
        Me.lblPurchaseRate.AutoSize = True
        Me.lblPurchaseRate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurchaseRate.ForeColor = System.Drawing.Color.Black
        Me.lblPurchaseRate.Location = New System.Drawing.Point(9, 143)
        Me.lblPurchaseRate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPurchaseRate.Name = "lblPurchaseRate"
        Me.lblPurchaseRate.Size = New System.Drawing.Size(119, 23)
        Me.lblPurchaseRate.TabIndex = 161
        Me.lblPurchaseRate.Text = "Purchase Rate"
        '
        'lblTItemName1
        '
        Me.lblTItemName1.AutoSize = True
        Me.lblTItemName1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTItemName1.ForeColor = System.Drawing.Color.Black
        Me.lblTItemName1.Location = New System.Drawing.Point(9, 103)
        Me.lblTItemName1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTItemName1.Name = "lblTItemName1"
        Me.lblTItemName1.Size = New System.Drawing.Size(98, 23)
        Me.lblTItemName1.TabIndex = 150
        Me.lblTItemName1.Text = "Alias / Print"
        '
        'txtTItemName1
        '
        Me.txtTItemName1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTItemName1.Location = New System.Drawing.Point(144, 98)
        Me.txtTItemName1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTItemName1.MaxLength = 50
        Me.txtTItemName1.Name = "txtTItemName1"
        Me.txtTItemName1.Size = New System.Drawing.Size(532, 30)
        Me.txtTItemName1.TabIndex = 3
        '
        'lblTaxPer
        '
        Me.lblTaxPer.AutoSize = True
        Me.lblTaxPer.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxPer.ForeColor = System.Drawing.Color.Black
        Me.lblTaxPer.Location = New System.Drawing.Point(451, 260)
        Me.lblTaxPer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTaxPer.Name = "lblTaxPer"
        Me.lblTaxPer.Size = New System.Drawing.Size(98, 23)
        Me.lblTaxPer.TabIndex = 147
        Me.lblTaxPer.Text = "Tax / GST %"
        '
        'txtTaxPer
        '
        Me.txtTaxPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxPer.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxPer.Location = New System.Drawing.Point(560, 255)
        Me.txtTaxPer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTaxPer.MaxLength = 5
        Me.txtTaxPer.Name = "txtTaxPer"
        Me.txtTaxPer.Size = New System.Drawing.Size(113, 30)
        Me.txtTaxPer.TabIndex = 12
        Me.txtTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblHSNCode
        '
        Me.lblHSNCode.AutoSize = True
        Me.lblHSNCode.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHSNCode.ForeColor = System.Drawing.Color.Black
        Me.lblHSNCode.Location = New System.Drawing.Point(9, 260)
        Me.lblHSNCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHSNCode.Name = "lblHSNCode"
        Me.lblHSNCode.Size = New System.Drawing.Size(86, 23)
        Me.lblHSNCode.TabIndex = 146
        Me.lblHSNCode.Text = "HSN Code"
        '
        'txtHSNCode
        '
        Me.txtHSNCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHSNCode.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHSNCode.Location = New System.Drawing.Point(144, 255)
        Me.txtHSNCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHSNCode.MaxLength = 20
        Me.txtHSNCode.Name = "txtHSNCode"
        Me.txtHSNCode.Size = New System.Drawing.Size(185, 30)
        Me.txtHSNCode.TabIndex = 11
        Me.txtHSNCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtValue
        '
        Me.txtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValue.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValue.Location = New System.Drawing.Point(1059, 375)
        Me.txtValue.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValue.MaxLength = 6
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(104, 30)
        Me.txtValue.TabIndex = 29
        Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.ForeColor = System.Drawing.Color.Black
        Me.lblValue.Location = New System.Drawing.Point(945, 380)
        Me.lblValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(98, 23)
        Me.lblValue.TabIndex = 143
        Me.lblValue.Text = "Stock Value"
        '
        'txtPurchaseRate
        '
        Me.txtPurchaseRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseRate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurchaseRate.Location = New System.Drawing.Point(144, 138)
        Me.txtPurchaseRate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPurchaseRate.MaxLength = 6
        Me.txtPurchaseRate.Name = "txtPurchaseRate"
        Me.txtPurchaseRate.Size = New System.Drawing.Size(113, 30)
        Me.txtPurchaseRate.TabIndex = 4
        Me.txtPurchaseRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbItemSize
        '
        Me.cmbItemSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbItemSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItemSize.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItemSize.FormattingEnabled = True
        Me.cmbItemSize.Location = New System.Drawing.Point(824, 62)
        Me.cmbItemSize.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbItemSize.Name = "cmbItemSize"
        Me.cmbItemSize.Size = New System.Drawing.Size(100, 31)
        Me.cmbItemSize.TabIndex = 18
        Me.cmbItemSize.Tag = "ItemSize"
        '
        'lblItemSize
        '
        Me.lblItemSize.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemSize.ForeColor = System.Drawing.Color.Black
        Me.lblItemSize.Location = New System.Drawing.Point(685, 66)
        Me.lblItemSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemSize.Name = "lblItemSize"
        Me.lblItemSize.Size = New System.Drawing.Size(129, 22)
        Me.lblItemSize.TabIndex = 139
        Me.lblItemSize.Text = "Size"
        Me.lblItemSize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBarCode
        '
        Me.lblBarCode.AutoSize = True
        Me.lblBarCode.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarCode.ForeColor = System.Drawing.Color.Black
        Me.lblBarCode.Location = New System.Drawing.Point(379, 26)
        Me.lblBarCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBarCode.Name = "lblBarCode"
        Me.lblBarCode.Size = New System.Drawing.Size(80, 23)
        Me.lblBarCode.TabIndex = 137
        Me.lblBarCode.Text = "Bar-Code"
        '
        'txtBarcode
        '
        Me.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcode.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(473, 21)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBarcode.MaxLength = 50
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(203, 30)
        Me.txtBarcode.TabIndex = 1
        '
        'txtOpStk
        '
        Me.txtOpStk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOpStk.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpStk.Location = New System.Drawing.Point(824, 375)
        Me.txtOpStk.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOpStk.MaxLength = 6
        Me.txtOpStk.Name = "txtOpStk"
        Me.txtOpStk.Size = New System.Drawing.Size(104, 30)
        Me.txtOpStk.TabIndex = 28
        Me.txtOpStk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOpStk
        '
        Me.lblOpStk.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpStk.ForeColor = System.Drawing.Color.Black
        Me.lblOpStk.Location = New System.Drawing.Point(685, 380)
        Me.lblOpStk.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOpStk.Name = "lblOpStk"
        Me.lblOpStk.Size = New System.Drawing.Size(129, 22)
        Me.lblOpStk.TabIndex = 135
        Me.lblOpStk.Text = "Opening Stock"
        Me.lblOpStk.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtReorderLevel
        '
        Me.txtReorderLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReorderLevel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReorderLevel.Location = New System.Drawing.Point(824, 414)
        Me.txtReorderLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReorderLevel.MaxLength = 6
        Me.txtReorderLevel.Name = "txtReorderLevel"
        Me.txtReorderLevel.Size = New System.Drawing.Size(104, 30)
        Me.txtReorderLevel.TabIndex = 30
        Me.txtReorderLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblReorderLevel
        '
        Me.lblReorderLevel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReorderLevel.ForeColor = System.Drawing.Color.Black
        Me.lblReorderLevel.Location = New System.Drawing.Point(685, 418)
        Me.lblReorderLevel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReorderLevel.Name = "lblReorderLevel"
        Me.lblReorderLevel.Size = New System.Drawing.Size(129, 22)
        Me.lblReorderLevel.TabIndex = 133
        Me.lblReorderLevel.Text = "Reorder Level"
        Me.lblReorderLevel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pbImg
        '
        Me.pbImg.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pbImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbImg.ContextMenuStrip = Me.CMSImage
        Me.pbImg.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pbImg.InitialImage = CType(resources.GetObject("pbImg.InitialImage"), System.Drawing.Image)
        Me.pbImg.Location = New System.Drawing.Point(1059, 50)
        Me.pbImg.Margin = New System.Windows.Forms.Padding(4)
        Me.pbImg.Name = "pbImg"
        Me.pbImg.Size = New System.Drawing.Size(159, 135)
        Me.pbImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImg.TabIndex = 129
        Me.pbImg.TabStop = False
        '
        'CMSImage
        '
        Me.CMSImage.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CMSImage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviewToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMSImage.Name = "ContextMenuStrip1"
        Me.CMSImage.Size = New System.Drawing.Size(148, 64)
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(147, 30)
        Me.PreviewToolStripMenuItem.Text = "Preview"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(147, 30)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(1055, 223)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 23)
        Me.Label15.TabIndex = 128
        Me.Label15.Text = "Select Image"
        '
        'txtImgPath
        '
        Me.txtImgPath.AllowDrop = True
        Me.txtImgPath.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.txtImgPath.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImgPath.Location = New System.Drawing.Point(1059, 249)
        Me.txtImgPath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtImgPath.MaxLength = 500
        Me.txtImgPath.Name = "txtImgPath"
        Me.txtImgPath.ReadOnly = True
        Me.txtImgPath.Size = New System.Drawing.Size(159, 30)
        Me.txtImgPath.TabIndex = 31
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(824, 338)
        Me.chkIsActive.Margin = New System.Windows.Forms.Padding(4)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(99, 27)
        Me.chkIsActive.TabIndex = 26
        Me.chkIsActive.TabStop = False
        Me.chkIsActive.Text = "Is Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 182)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 23)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Sales Rate"
        '
        'txtSalesRate
        '
        Me.txtSalesRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesRate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesRate.Location = New System.Drawing.Point(144, 177)
        Me.txtSalesRate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSalesRate.MaxLength = 12
        Me.txtSalesRate.Name = "txtSalesRate"
        Me.txtSalesRate.Size = New System.Drawing.Size(113, 30)
        Me.txtSalesRate.TabIndex = 7
        Me.txtSalesRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbUOM
        '
        Me.cmbUOM.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUOM.FormattingEnabled = True
        Me.cmbUOM.Location = New System.Drawing.Point(316, 138)
        Me.cmbUOM.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbUOM.Name = "cmbUOM"
        Me.cmbUOM.Size = New System.Drawing.Size(87, 31)
        Me.cmbUOM.TabIndex = 5
        Me.cmbUOM.Tag = "UOM"
        '
        'cmbSupplierName
        '
        Me.cmbSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSupplierName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupplierName.FormattingEnabled = True
        Me.cmbSupplierName.Location = New System.Drawing.Point(144, 412)
        Me.cmbSupplierName.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSupplierName.Name = "cmbSupplierName"
        Me.cmbSupplierName.Size = New System.Drawing.Size(532, 31)
        Me.cmbSupplierName.TabIndex = 17
        Me.cmbSupplierName.Tag = "SupplierName"
        '
        'lblSupplierName
        '
        Me.lblSupplierName.AutoSize = True
        Me.lblSupplierName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplierName.ForeColor = System.Drawing.Color.Black
        Me.lblSupplierName.Location = New System.Drawing.Point(9, 417)
        Me.lblSupplierName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(73, 23)
        Me.lblSupplierName.TabIndex = 100
        Me.lblSupplierName.Text = "Supplier"
        '
        'cmbMfgName
        '
        Me.cmbMfgName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMfgName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMfgName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMfgName.FormattingEnabled = True
        Me.cmbMfgName.Location = New System.Drawing.Point(144, 373)
        Me.cmbMfgName.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMfgName.Name = "cmbMfgName"
        Me.cmbMfgName.Size = New System.Drawing.Size(532, 31)
        Me.cmbMfgName.TabIndex = 16
        Me.cmbMfgName.Tag = "MfgName"
        '
        'lblMfgName
        '
        Me.lblMfgName.AutoSize = True
        Me.lblMfgName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMfgName.ForeColor = System.Drawing.Color.Black
        Me.lblMfgName.Location = New System.Drawing.Point(9, 378)
        Me.lblMfgName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMfgName.Name = "lblMfgName"
        Me.lblMfgName.Size = New System.Drawing.Size(125, 23)
        Me.lblMfgName.TabIndex = 100
        Me.lblMfgName.Text = "Mfg./Company"
        '
        'cmbItemSubCategory
        '
        Me.cmbItemSubCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbItemSubCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItemSubCategory.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItemSubCategory.FormattingEnabled = True
        Me.cmbItemSubCategory.Location = New System.Drawing.Point(472, 331)
        Me.cmbItemSubCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbItemSubCategory.Name = "cmbItemSubCategory"
        Me.cmbItemSubCategory.Size = New System.Drawing.Size(203, 31)
        Me.cmbItemSubCategory.TabIndex = 15
        Me.cmbItemSubCategory.Tag = "ItemSubCategory"
        '
        'lblItemSubCategory
        '
        Me.lblItemSubCategory.AutoSize = True
        Me.lblItemSubCategory.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemSubCategory.ForeColor = System.Drawing.Color.Black
        Me.lblItemSubCategory.Location = New System.Drawing.Point(343, 335)
        Me.lblItemSubCategory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemSubCategory.Name = "lblItemSubCategory"
        Me.lblItemSubCategory.Size = New System.Drawing.Size(114, 23)
        Me.lblItemSubCategory.TabIndex = 98
        Me.lblItemSubCategory.Text = "Sub-Category"
        '
        'cmbItemCategory
        '
        Me.cmbItemCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbItemCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItemCategory.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItemCategory.FormattingEnabled = True
        Me.cmbItemCategory.Location = New System.Drawing.Point(144, 331)
        Me.cmbItemCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbItemCategory.Name = "cmbItemCategory"
        Me.cmbItemCategory.Size = New System.Drawing.Size(185, 31)
        Me.cmbItemCategory.TabIndex = 14
        Me.cmbItemCategory.Tag = "ItemCategory"
        '
        'lblItemCategory
        '
        Me.lblItemCategory.AutoSize = True
        Me.lblItemCategory.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCategory.ForeColor = System.Drawing.Color.Black
        Me.lblItemCategory.Location = New System.Drawing.Point(9, 336)
        Me.lblItemCategory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemCategory.Name = "lblItemCategory"
        Me.lblItemCategory.Size = New System.Drawing.Size(79, 23)
        Me.lblItemCategory.TabIndex = 98
        Me.lblItemCategory.Text = "Category"
        '
        'cmbItemType
        '
        Me.cmbItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItemType.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItemType.FormattingEnabled = True
        Me.cmbItemType.Location = New System.Drawing.Point(144, 293)
        Me.cmbItemType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbItemType.Name = "cmbItemType"
        Me.cmbItemType.Size = New System.Drawing.Size(532, 31)
        Me.cmbItemType.TabIndex = 13
        Me.cmbItemType.Tag = "ItemType"
        '
        'lblItemType
        '
        Me.lblItemType.AutoSize = True
        Me.lblItemType.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemType.ForeColor = System.Drawing.Color.Black
        Me.lblItemType.Location = New System.Drawing.Point(9, 297)
        Me.lblItemType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(46, 23)
        Me.lblItemType.TabIndex = 96
        Me.lblItemType.Text = "Type"
        '
        'txtTItemName
        '
        Me.txtTItemName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTItemName.Location = New System.Drawing.Point(144, 59)
        Me.txtTItemName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTItemName.MaxLength = 50
        Me.txtTItemName.Name = "txtTItemName"
        Me.txtTItemName.Size = New System.Drawing.Size(532, 30)
        Me.txtTItemName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 23)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Name"
        '
        'txtTItemCode
        '
        Me.txtTItemCode.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.txtTItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTItemCode.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTItemCode.Location = New System.Drawing.Point(824, 21)
        Me.txtTItemCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTItemCode.MaxLength = 50
        Me.txtTItemCode.Name = "txtTItemCode"
        Me.txtTItemCode.Size = New System.Drawing.Size(220, 30)
        Me.txtTItemCode.TabIndex = 1
        '
        'lblTItemCode
        '
        Me.lblTItemCode.AutoSize = True
        Me.lblTItemCode.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTItemCode.ForeColor = System.Drawing.Color.Black
        Me.lblTItemCode.Location = New System.Drawing.Point(725, 26)
        Me.lblTItemCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTItemCode.Name = "lblTItemCode"
        Me.lblTItemCode.Size = New System.Drawing.Size(89, 23)
        Me.lblTItemCode.TabIndex = 28
        Me.lblTItemCode.Text = "Item Code"
        '
        'btnUpdateRates
        '
        Me.btnUpdateRates.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpdateRates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateRates.Location = New System.Drawing.Point(1249, 386)
        Me.btnUpdateRates.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdateRates.Name = "btnUpdateRates"
        Me.btnUpdateRates.Size = New System.Drawing.Size(168, 36)
        Me.btnUpdateRates.TabIndex = 189
        Me.btnUpdateRates.Text = "Update Rates"
        Me.btnUpdateRates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdateRates.UseVisualStyleBackColor = False
        Me.btnUpdateRates.Visible = False
        '
        'gcDetail
        '
        Me.gcDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcDetail.ContextMenuStrip = Me.ContextMenuStrip2
        Me.gcDetail.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gcDetail.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.gcDetail.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.gcDetail.Location = New System.Drawing.Point(1249, 15)
        Me.gcDetail.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.gcDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gcDetail.MainView = Me.gvDetail
        Me.gcDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.gcDetail.Name = "gcDetail"
        Me.gcDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repYN})
        Me.gcDetail.Size = New System.Drawing.Size(269, 364)
        Me.gcDetail.TabIndex = 188
        Me.gcDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetail})
        Me.gcDetail.Visible = False
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripMenuItem3, Me.ToolStripMenuItem7})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(208, 124)
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(207, 30)
        Me.ToolStripMenuItem8.Text = "Check All"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(207, 30)
        Me.ToolStripMenuItem9.Text = "Uncheck All"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(207, 30)
        Me.ToolStripMenuItem3.Text = "Export To Excel"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(207, 30)
        Me.ToolStripMenuItem7.Text = "Save Layout"
        '
        'gvDetail
        '
        Me.gvDetail.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.gvDetail.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvDetail.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.gvDetail.Appearance.Row.Options.UseFont = True
        Me.gvDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.YN, Me.TItemId, Me.TItemName, Me.RackPrice, Me.DiscPer})
        Me.gvDetail.GridControl = Me.gcDetail
        Me.gvDetail.GroupPanelText = "All Department "
        Me.gvDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Nothing, "")})
        Me.gvDetail.Name = "gvDetail"
        Me.gvDetail.OptionsCustomization.AllowGroup = False
        Me.gvDetail.OptionsMenu.EnableFooterMenu = False
        Me.gvDetail.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.gvDetail.OptionsView.ColumnAutoWidth = False
        Me.gvDetail.OptionsView.ShowFooter = True
        Me.gvDetail.OptionsView.ShowGroupPanel = False
        '
        'YN
        '
        Me.YN.Caption = "Print"
        Me.YN.ColumnEdit = Me.repYN
        Me.YN.FieldName = "YN"
        Me.YN.Name = "YN"
        Me.YN.Visible = True
        Me.YN.VisibleIndex = 3
        Me.YN.Width = 67
        '
        'repYN
        '
        Me.repYN.AutoHeight = False
        Me.repYN.Name = "repYN"
        '
        'TItemId
        '
        Me.TItemId.Caption = "TItemId"
        Me.TItemId.FieldName = "TItemId"
        Me.TItemId.Name = "TItemId"
        '
        'TItemName
        '
        Me.TItemName.Caption = "Tailoring Item"
        Me.TItemName.FieldName = "TItemName"
        Me.TItemName.Name = "TItemName"
        Me.TItemName.OptionsColumn.ReadOnly = True
        Me.TItemName.Visible = True
        Me.TItemName.VisibleIndex = 0
        Me.TItemName.Width = 252
        '
        'RackPrice
        '
        Me.RackPrice.Caption = "Price"
        Me.RackPrice.FieldName = "RackPrice"
        Me.RackPrice.Name = "RackPrice"
        Me.RackPrice.Visible = True
        Me.RackPrice.VisibleIndex = 1
        Me.RackPrice.Width = 89
        '
        'DiscPer
        '
        Me.DiscPer.Caption = "Disc %"
        Me.DiscPer.FieldName = "DiscPer"
        Me.DiscPer.Name = "DiscPer"
        Me.DiscPer.Visible = True
        Me.DiscPer.VisibleIndex = 2
        Me.DiscPer.Width = 74
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem, Me.ImportToolStripMenuItem, Me.DownloadTemplateToolStripMenuItem, Me.UpdateItemInfoToolStripMenuItem, Me.UploadOpeningStockToolStripMenuItem, Me.PreviewBarcodeToolStripMenuItem, Me.SelectSubItemsToolStripMenuItem, Me.PrintBarcodeToolStripMenuItem, Me.CheckAllToolStripMenuItem, Me.UncheckAllToolStripMenuItem, Me.RenameColumnToolStripMenuItem, Me.UISettingToolStripMenuItem, Me.SaveLayoutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(273, 394)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.ExportToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.ImportToolStripMenuItem.Text = "Import From Excel"
        '
        'DownloadTemplateToolStripMenuItem
        '
        Me.DownloadTemplateToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownloadTemplateToolStripMenuItem.Name = "DownloadTemplateToolStripMenuItem"
        Me.DownloadTemplateToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.DownloadTemplateToolStripMenuItem.Text = "Download Template"
        '
        'UpdateItemInfoToolStripMenuItem
        '
        Me.UpdateItemInfoToolStripMenuItem.Name = "UpdateItemInfoToolStripMenuItem"
        Me.UpdateItemInfoToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.UpdateItemInfoToolStripMenuItem.Text = "Update Item Info"
        '
        'UploadOpeningStockToolStripMenuItem
        '
        Me.UploadOpeningStockToolStripMenuItem.Name = "UploadOpeningStockToolStripMenuItem"
        Me.UploadOpeningStockToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.UploadOpeningStockToolStripMenuItem.Text = "Upload Opening Stock"
        '
        'PreviewBarcodeToolStripMenuItem
        '
        Me.PreviewBarcodeToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreviewBarcodeToolStripMenuItem.Name = "PreviewBarcodeToolStripMenuItem"
        Me.PreviewBarcodeToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.PreviewBarcodeToolStripMenuItem.Text = "Preview Barcode"
        '
        'SelectSubItemsToolStripMenuItem
        '
        Me.SelectSubItemsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectSubItemsToolStripMenuItem.Name = "SelectSubItemsToolStripMenuItem"
        Me.SelectSubItemsToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.SelectSubItemsToolStripMenuItem.Text = "Select Sub Items"
        Me.SelectSubItemsToolStripMenuItem.Visible = False
        '
        'PrintBarcodeToolStripMenuItem
        '
        Me.PrintBarcodeToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintBarcodeToolStripMenuItem.Name = "PrintBarcodeToolStripMenuItem"
        Me.PrintBarcodeToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.PrintBarcodeToolStripMenuItem.Text = "Print Barcode"
        '
        'CheckAllToolStripMenuItem
        '
        Me.CheckAllToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckAllToolStripMenuItem.Name = "CheckAllToolStripMenuItem"
        Me.CheckAllToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.CheckAllToolStripMenuItem.Text = "Check All"
        '
        'UncheckAllToolStripMenuItem
        '
        Me.UncheckAllToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UncheckAllToolStripMenuItem.Name = "UncheckAllToolStripMenuItem"
        Me.UncheckAllToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.UncheckAllToolStripMenuItem.Text = "Uncheck All"
        '
        'RenameColumnToolStripMenuItem
        '
        Me.RenameColumnToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.RenameColumnToolStripMenuItem.Name = "RenameColumnToolStripMenuItem"
        Me.RenameColumnToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.RenameColumnToolStripMenuItem.Text = "Rename Column"
        '
        'UISettingToolStripMenuItem
        '
        Me.UISettingToolStripMenuItem.Name = "UISettingToolStripMenuItem"
        Me.UISettingToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.UISettingToolStripMenuItem.Text = "UI Settings"
        Me.UISettingToolStripMenuItem.Visible = False
        '
        'SaveLayoutToolStripMenuItem
        '
        Me.SaveLayoutToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveLayoutToolStripMenuItem.Name = "SaveLayoutToolStripMenuItem"
        Me.SaveLayoutToolStripMenuItem.Size = New System.Drawing.Size(272, 30)
        Me.SaveLayoutToolStripMenuItem.Text = "Save Layout"
        '
        'lblTItemId
        '
        Me.lblTItemId.AutoSize = True
        Me.lblTItemId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTItemId.ForeColor = System.Drawing.Color.Black
        Me.lblTItemId.Location = New System.Drawing.Point(405, 603)
        Me.lblTItemId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTItemId.Name = "lblTItemId"
        Me.lblTItemId.Size = New System.Drawing.Size(63, 17)
        Me.lblTItemId.TabIndex = 73
        Me.lblTItemId.Text = "TItemId"
        Me.lblTItemId.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(480, 693)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 39)
        Me.btnExit.TabIndex = 6
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
        Me.btnCancel.Location = New System.Drawing.Point(379, 693)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 39)
        Me.btnCancel.TabIndex = 5
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
        Me.btnDelete.Location = New System.Drawing.Point(280, 693)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 39)
        Me.btnDelete.TabIndex = 4
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
        Me.btnSave.Location = New System.Drawing.Point(189, 693)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 39)
        Me.btnSave.TabIndex = 3
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
        Me.btnEdit.Location = New System.Drawing.Point(91, 693)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(96, 39)
        Me.btnEdit.TabIndex = 2
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
        Me.btnAdd.Location = New System.Drawing.Point(5, 693)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(83, 39)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "&New"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.SystemColors.Control
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(1409, 697)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(105, 36)
        Me.btnRefresh.TabIndex = 14
        Me.btnRefresh.Text = "Re&fresh"
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1135, 684)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 17)
        Me.Label8.TabIndex = 157
        Me.Label8.Text = "Print Mode"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Fabric", "Readymade", "PRN", "Crystal"})
        Me.ComboBox1.Location = New System.Drawing.Point(1139, 704)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(112, 25)
        Me.ComboBox1.TabIndex = 11
        Me.ComboBox1.Tag = "ItemSize"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(1319, 697)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 36)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(1252, 684)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 17)
        Me.Label5.TabIndex = 159
        Me.Label5.Text = "Copies"
        '
        'txtPrintCopies
        '
        Me.txtPrintCopies.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrintCopies.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrintCopies.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrintCopies.Location = New System.Drawing.Point(1256, 704)
        Me.txtPrintCopies.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrintCopies.MaxLength = 3
        Me.txtPrintCopies.Name = "txtPrintCopies"
        Me.txtPrintCopies.Size = New System.Drawing.Size(56, 24)
        Me.txtPrintCopies.TabIndex = 12
        Me.txtPrintCopies.Text = "1"
        Me.txtPrintCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'gcData
        '
        Me.gcData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gcData.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gcData.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcData.Location = New System.Drawing.Point(11, 469)
        Me.gcData.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.gcData.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gcData.MainView = Me.gvData
        Me.gcData.Margin = New System.Windows.Forms.Padding(4)
        Me.gcData.Name = "gcData"
        Me.gcData.Size = New System.Drawing.Size(1504, 191)
        Me.gcData.TabIndex = 12
        Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvData})
        '
        'gvData
        '
        Me.gvData.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvData.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvData.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvData.Appearance.Row.Options.UseFont = True
        Me.gvData.GridControl = Me.gcData
        Me.gvData.GroupPanelText = "All Department "
        Me.gvData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Nothing, "")})
        Me.gvData.Name = "gvData"
        Me.gvData.OptionsCustomization.AllowGroup = False
        Me.gvData.OptionsLayout.Columns.StoreAllOptions = True
        Me.gvData.OptionsLayout.StoreAllOptions = True
        Me.gvData.OptionsMenu.EnableFooterMenu = False
        Me.gvData.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.gvData.OptionsView.ShowAutoFilterRow = True
        Me.gvData.OptionsView.ShowFooter = True
        Me.gvData.OptionsView.ShowGroupPanel = False
        '
        'btnStockCheck
        '
        Me.btnStockCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStockCheck.BackColor = System.Drawing.SystemColors.Control
        Me.btnStockCheck.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockCheck.Location = New System.Drawing.Point(1449, 667)
        Me.btnStockCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.btnStockCheck.Name = "btnStockCheck"
        Me.btnStockCheck.Size = New System.Drawing.Size(65, 36)
        Me.btnStockCheck.TabIndex = 10
        Me.btnStockCheck.Text = "Stock"
        Me.btnStockCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStockCheck.UseVisualStyleBackColor = False
        Me.btnStockCheck.Visible = False
        '
        'cmbF_Company
        '
        Me.cmbF_Company.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbF_Company.EnterMoveNextControl = True
        Me.cmbF_Company.Location = New System.Drawing.Point(576, 700)
        Me.cmbF_Company.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbF_Company.Name = "cmbF_Company"
        Me.cmbF_Company.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbF_Company.Properties.Appearance.Options.UseFont = True
        Me.cmbF_Company.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.cmbF_Company.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cmbF_Company.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbF_Company.Properties.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.cmbF_Company.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbF_Company.Properties.NullText = ""
        Me.cmbF_Company.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cmbF_Company.Size = New System.Drawing.Size(181, 30)
        Me.cmbF_Company.TabIndex = 7
        Me.cmbF_Company.Tag = ""
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(995, 678)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 17)
        Me.Label17.TabIndex = 190
        Me.Label17.Text = "Item Name"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(761, 678)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 17)
        Me.Label16.TabIndex = 189
        Me.Label16.Text = "Barcode From"
        '
        'txtF_ItemName
        '
        Me.txtF_ItemName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtF_ItemName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtF_ItemName.Location = New System.Drawing.Point(999, 698)
        Me.txtF_ItemName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtF_ItemName.MaxLength = 50
        Me.txtF_ItemName.Name = "txtF_ItemName"
        Me.txtF_ItemName.Size = New System.Drawing.Size(132, 30)
        Me.txtF_ItemName.TabIndex = 10
        '
        'txtF_BarcodeFrom
        '
        Me.txtF_BarcodeFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtF_BarcodeFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtF_BarcodeFrom.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtF_BarcodeFrom.Location = New System.Drawing.Point(765, 698)
        Me.txtF_BarcodeFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.txtF_BarcodeFrom.MaxLength = 50
        Me.txtF_BarcodeFrom.Name = "txtF_BarcodeFrom"
        Me.txtF_BarcodeFrom.Size = New System.Drawing.Size(109, 30)
        Me.txtF_BarcodeFrom.TabIndex = 8
        '
        'lblBranch
        '
        Me.lblBranch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBranch.AutoSize = True
        Me.lblBranch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranch.ForeColor = System.Drawing.Color.Black
        Me.lblBranch.Location = New System.Drawing.Point(572, 678)
        Me.lblBranch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.Size = New System.Drawing.Size(57, 17)
        Me.lblBranch.TabIndex = 191
        Me.lblBranch.Text = "Branch"
        '
        'txtF_BarcodeTo
        '
        Me.txtF_BarcodeTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtF_BarcodeTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtF_BarcodeTo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtF_BarcodeTo.Location = New System.Drawing.Point(883, 698)
        Me.txtF_BarcodeTo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtF_BarcodeTo.MaxLength = 50
        Me.txtF_BarcodeTo.Name = "txtF_BarcodeTo"
        Me.txtF_BarcodeTo.Size = New System.Drawing.Size(101, 30)
        Me.txtF_BarcodeTo.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(879, 678)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 17)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "To"
        '
        'btnPrintItemBarcodes
        '
        Me.btnPrintItemBarcodes.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrintItemBarcodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintItemBarcodes.Location = New System.Drawing.Point(1423, 386)
        Me.btnPrintItemBarcodes.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrintItemBarcodes.Name = "btnPrintItemBarcodes"
        Me.btnPrintItemBarcodes.Size = New System.Drawing.Size(223, 36)
        Me.btnPrintItemBarcodes.TabIndex = 193
        Me.btnPrintItemBarcodes.Text = "Print Product Barcode"
        Me.btnPrintItemBarcodes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintItemBarcodes.UseVisualStyleBackColor = False
        '
        'FrmSalesItemMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1525, 740)
        Me.Controls.Add(Me.btnPrintItemBarcodes)
        Me.Controls.Add(Me.btnUpdateRates)
        Me.Controls.Add(Me.gcDetail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtF_BarcodeTo)
        Me.Controls.Add(Me.lblBranch)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtF_ItemName)
        Me.Controls.Add(Me.txtF_BarcodeFrom)
        Me.Controls.Add(Me.cmbF_Company)
        Me.Controls.Add(Me.btnStockCheck)
        Me.Controls.Add(Me.lblTItemId)
        Me.Controls.Add(Me.gcData)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPrintCopies)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.gbMainDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "FrmSalesItemMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fabric / Readymade Item Master"
        Me.gbMainDetail.ResumeLayout(False)
        Me.gbMainDetail.PerformLayout()
        CType(Me.pbImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSImage.ResumeLayout(False)
        CType(Me.gcDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repYN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbF_Company.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbMainDetail As System.Windows.Forms.GroupBox
    Friend WithEvents lblTItemId As System.Windows.Forms.Label
    Friend WithEvents txtTItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lblTItemCode As System.Windows.Forms.Label
    Friend WithEvents cmbMfgName As System.Windows.Forms.ComboBox
    Friend WithEvents lblMfgName As System.Windows.Forms.Label
    Friend WithEvents cmbItemCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemCategory As System.Windows.Forms.Label
    Friend WithEvents cmbItemType As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemType As System.Windows.Forms.Label
    Friend WithEvents cmbUOM As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSalesRate As System.Windows.Forms.TextBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents pbImg As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtImgPath As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents txtReorderLevel As System.Windows.Forms.TextBox
    Friend WithEvents lblReorderLevel As System.Windows.Forms.Label
    Friend WithEvents txtOpStk As System.Windows.Forms.TextBox
    Friend WithEvents lblOpStk As System.Windows.Forms.Label
    Friend WithEvents lblBarCode As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents cmbItemSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemSize As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtPurchaseRate As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxPer As System.Windows.Forms.Label
    Friend WithEvents txtTaxPer As System.Windows.Forms.TextBox
    Friend WithEvents lblHSNCode As System.Windows.Forms.Label
    Friend WithEvents txtHSNCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrintCopies As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTItemName1 As System.Windows.Forms.TextBox
    Friend WithEvents lblTItemName1 As System.Windows.Forms.Label
    Friend WithEvents lblPurchaseRate As System.Windows.Forms.Label
    Friend WithEvents cmbItemColor As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemColor As System.Windows.Forms.Label
    Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkManageStock As System.Windows.Forms.CheckBox
    Friend WithEvents btnStockCheck As Button
    Friend WithEvents lblLocation As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents lblCatalogName As Label
    Friend WithEvents txtCatalogName As TextBox
    Friend WithEvents txtDesignNo As TextBox
    Friend WithEvents lblDesignNo As Label
    Friend WithEvents ExportToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveLayoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbItemSubCategory As ComboBox
    Friend WithEvents lblItemSubCategory As Label
    Friend WithEvents cmbSupplierName As ComboBox
    Friend WithEvents lblSupplierName As Label
    Friend WithEvents SelectSubItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbF_Company As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtSalesDiscPer As TextBox
    Friend WithEvents txtPurchaseDiscPer As TextBox
    Friend WithEvents lblSalesDiscPer As Label
    Friend WithEvents lblPurchaseDiscPer As Label
    Friend WithEvents txtCommissionAmt As TextBox
    Friend WithEvents lblCommissionAmt As Label
    Friend WithEvents txtCommissionPer As TextBox
    Friend WithEvents lblCommissionPer As Label
    Friend WithEvents PreviewBarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintBarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblRackRate As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtF_ItemName As TextBox
    Friend WithEvents txtF_BarcodeFrom As TextBox
    Friend WithEvents lblBranch As Label
    Friend WithEvents txtF_BarcodeTo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UncheckAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMRP As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents gcDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TItemId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RackPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiscPer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnUpdateRates As Button
    Friend WithEvents btnPrintItemBarcodes As Button
    Friend WithEvents cmbItemSizeRange As ComboBox
    Friend WithEvents YN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repYN As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem8 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripMenuItem
    Friend WithEvents RenameColumnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSalesRateA As TextBox
    Friend WithEvents UpdateItemInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadOpeningStockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label34 As Label
    Friend WithEvents cmbBarcodeType As ComboBox
    Friend WithEvents lblBrowseimg As LinkLabel
    Friend WithEvents btnStart As Button
    Friend WithEvents btnRemoveImg As Button
    Friend WithEvents CMSImage As ContextMenuStrip
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UISettingToolStripMenuItem As ToolStripMenuItem
End Class
