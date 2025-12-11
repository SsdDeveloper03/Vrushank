<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.cmbDept = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtUserName = New DevExpress.XtraEditors.TextEdit()
        Me.txtPwd = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.llWebsite = New System.Windows.Forms.LinkLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateSoftwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateDatabseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateReportFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Extend20252026ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Extend20242025ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateConpathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQLInstalltionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtOTP = New DevExpress.XtraEditors.TextEdit()
        Me.lblOTP = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.txtOTP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.White
        Me.cmbDept.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDept.ForeColor = System.Drawing.Color.Black
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(144, 437)
        Me.cmbDept.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(233, 27)
        Me.cmbDept.TabIndex = 2
        Me.cmbDept.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(35, 438)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Department"
        Me.Label3.Visible = False
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Appearance.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnLogin.Appearance.Options.UseFont = True
        Me.btnLogin.Appearance.Options.UseForeColor = True
        Me.btnLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.btnLogin.ImageOptions.Image = CType(resources.GetObject("btnLogin.ImageOptions.Image"), System.Drawing.Image)
        Me.btnLogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnLogin.Location = New System.Drawing.Point(487, 305)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(109, 53)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "&Login"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.Appearance.Options.UseForeColor = True
        Me.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.btnCancel.ImageOptions.Image = CType(resources.GetObject("btnCancel.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(604, 304)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(124, 53)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'txtUserName
        '
        Me.txtUserName.EditValue = ""
        Me.txtUserName.Location = New System.Drawing.Point(487, 212)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtUserName.Properties.Appearance.Options.UseFont = True
        Me.txtUserName.Properties.Appearance.Options.UseForeColor = True
        Me.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtUserName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserName.Properties.LookAndFeel.SkinName = "Seven Classic"
        Me.txtUserName.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtUserName.Properties.MaxLength = 15
        Me.txtUserName.Size = New System.Drawing.Size(240, 38)
        Me.txtUserName.TabIndex = 0
        '
        'txtPwd
        '
        Me.txtPwd.EditValue = ""
        Me.txtPwd.Location = New System.Drawing.Point(487, 258)
        Me.txtPwd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPwd.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtPwd.Properties.Appearance.Options.UseFont = True
        Me.txtPwd.Properties.Appearance.Options.UseForeColor = True
        Me.txtPwd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtPwd.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPwd.Properties.LookAndFeel.SkinName = "Seven Classic"
        Me.txtPwd.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtPwd.Properties.MaxLength = 15
        Me.txtPwd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(240, 38)
        Me.txtPwd.TabIndex = 1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(693, 213)
        Me.SimpleButton1.LookAndFeel.SkinName = "Visual Studio 2013 Dark"
        Me.SimpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(33, 37)
        Me.SimpleButton1.TabIndex = 9
        Me.SimpleButton1.TabStop = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(693, 260)
        Me.SimpleButton2.LookAndFeel.SkinName = "Visual Studio 2013 Dark"
        Me.SimpleButton2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(33, 37)
        Me.SimpleButton2.TabIndex = 10
        Me.SimpleButton2.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(1147, 5)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 37)
        Me.btnClose.TabIndex = 12
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'llWebsite
        '
        Me.llWebsite.AutoSize = True
        Me.llWebsite.BackColor = System.Drawing.Color.Transparent
        Me.llWebsite.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llWebsite.ForeColor = System.Drawing.SystemColors.Desktop
        Me.llWebsite.LinkColor = System.Drawing.Color.White
        Me.llWebsite.Location = New System.Drawing.Point(836, 572)
        Me.llWebsite.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.llWebsite.Name = "llWebsite"
        Me.llWebsite.Size = New System.Drawing.Size(265, 23)
        Me.llWebsite.TabIndex = 13
        Me.llWebsite.TabStop = True
        Me.llWebsite.Text = "https://www.sunrisesoftware.in"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateSoftwareToolStripMenuItem, Me.UpdateDatabseToolStripMenuItem, Me.UpdateReportFileToolStripMenuItem, Me.Extend20252026ToolStripMenuItem, Me.Extend20242025ToolStripMenuItem, Me.QueryToolStripMenuItem, Me.SQLInstalltionToolStripMenuItem, Me.SyncToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(272, 260)
        '
        'UpdateSoftwareToolStripMenuItem
        '
        Me.UpdateSoftwareToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.UpdateSoftwareToolStripMenuItem.Name = "UpdateSoftwareToolStripMenuItem"
        Me.UpdateSoftwareToolStripMenuItem.Size = New System.Drawing.Size(271, 32)
        Me.UpdateSoftwareToolStripMenuItem.Text = "Update Software"
        '
        'UpdateDatabseToolStripMenuItem
        '
        Me.UpdateDatabseToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.UpdateDatabseToolStripMenuItem.Name = "UpdateDatabseToolStripMenuItem"
        Me.UpdateDatabseToolStripMenuItem.Size = New System.Drawing.Size(271, 32)
        Me.UpdateDatabseToolStripMenuItem.Text = "Update Databse"
        '
        'UpdateReportFileToolStripMenuItem
        '
        Me.UpdateReportFileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.UpdateReportFileToolStripMenuItem.Name = "UpdateReportFileToolStripMenuItem"
        Me.UpdateReportFileToolStripMenuItem.Size = New System.Drawing.Size(271, 32)
        Me.UpdateReportFileToolStripMenuItem.Text = "Update Report File"
        '
        'Extend20252026ToolStripMenuItem
        '
        Me.Extend20252026ToolStripMenuItem.Name = "Extend20252026ToolStripMenuItem"
        Me.Extend20252026ToolStripMenuItem.Size = New System.Drawing.Size(271, 32)
        Me.Extend20252026ToolStripMenuItem.Text = "Extend 2025 - 2026"
        '
        'Extend20242025ToolStripMenuItem
        '
        Me.Extend20242025ToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Extend20242025ToolStripMenuItem.Name = "Extend20242025ToolStripMenuItem"
        Me.Extend20242025ToolStripMenuItem.Size = New System.Drawing.Size(271, 32)
        Me.Extend20242025ToolStripMenuItem.Text = "Extend 2024 - 2025"
        Me.Extend20242025ToolStripMenuItem.Visible = False
        '
        'QueryToolStripMenuItem
        '
        Me.QueryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateConpathToolStripMenuItem, Me.RestoreDatabaseToolStripMenuItem})
        Me.QueryToolStripMenuItem.Name = "QueryToolStripMenuItem"
        Me.QueryToolStripMenuItem.Size = New System.Drawing.Size(271, 32)
        Me.QueryToolStripMenuItem.Text = "Query"
        '
        'UpdateConpathToolStripMenuItem
        '
        Me.UpdateConpathToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateConpathToolStripMenuItem.Name = "UpdateConpathToolStripMenuItem"
        Me.UpdateConpathToolStripMenuItem.Size = New System.Drawing.Size(235, 32)
        Me.UpdateConpathToolStripMenuItem.Text = "Update Conpath"
        '
        'RestoreDatabaseToolStripMenuItem
        '
        Me.RestoreDatabaseToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RestoreDatabaseToolStripMenuItem.Name = "RestoreDatabaseToolStripMenuItem"
        Me.RestoreDatabaseToolStripMenuItem.Size = New System.Drawing.Size(235, 32)
        Me.RestoreDatabaseToolStripMenuItem.Text = "SQL Installtion"
        Me.RestoreDatabaseToolStripMenuItem.Visible = False
        '
        'SQLInstalltionToolStripMenuItem
        '
        Me.SQLInstalltionToolStripMenuItem.Name = "SQLInstalltionToolStripMenuItem"
        Me.SQLInstalltionToolStripMenuItem.Size = New System.Drawing.Size(271, 32)
        Me.SQLInstalltionToolStripMenuItem.Text = "SQL Installtion"
        '
        'SyncToolStripMenuItem
        '
        Me.SyncToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.SyncToolStripMenuItem.Name = "SyncToolStripMenuItem"
        Me.SyncToolStripMenuItem.Size = New System.Drawing.Size(271, 32)
        Me.SyncToolStripMenuItem.Text = "Sync"
        '
        'txtOTP
        '
        Me.txtOTP.EditValue = ""
        Me.txtOTP.Location = New System.Drawing.Point(604, 367)
        Me.txtOTP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOTP.Name = "txtOTP"
        Me.txtOTP.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOTP.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtOTP.Properties.Appearance.Options.UseFont = True
        Me.txtOTP.Properties.Appearance.Options.UseForeColor = True
        Me.txtOTP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtOTP.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOTP.Properties.LookAndFeel.SkinName = "Seven Classic"
        Me.txtOTP.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtOTP.Properties.MaxLength = 4
        Me.txtOTP.Size = New System.Drawing.Size(99, 38)
        Me.txtOTP.TabIndex = 2
        Me.txtOTP.Visible = False
        '
        'lblOTP
        '
        Me.lblOTP.AutoSize = True
        Me.lblOTP.BackColor = System.Drawing.Color.White
        Me.lblOTP.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOTP.ForeColor = System.Drawing.Color.Maroon
        Me.lblOTP.Location = New System.Drawing.Point(481, 372)
        Me.lblOTP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOTP.Name = "lblOTP"
        Me.lblOTP.Size = New System.Drawing.Size(52, 29)
        Me.lblOTP.TabIndex = 22
        Me.lblOTP.Text = "OTP"
        Me.lblOTP.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(16, 529)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(67, 62)
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1129, 606)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblOTP)
        Me.Controls.Add(Me.txtOTP)
        Me.Controls.Add(Me.llWebsite)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbDept)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tailoring Software [User Login]"
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.txtOTP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents llWebsite As System.Windows.Forms.LinkLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateSoftwareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents UpdateDatabseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SyncToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtOTP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblOTP As Label
    Friend WithEvents UpdateReportFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Extend20242025ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents QueryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateConpathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestoreDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Extend20252026ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SQLInstalltionToolStripMenuItem As ToolStripMenuItem
End Class
