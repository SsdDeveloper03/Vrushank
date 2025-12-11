<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportViewer_Stimul
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportViewer_Stimul))
        Me.pnlReport = New System.Windows.Forms.Panel()
        Me.StiViwerControl = New Stimulsoft.Report.Viewer.StiViewerControl()
        Me.pnlReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlReport
        '
        Me.pnlReport.Controls.Add(Me.StiViwerControl)
        Me.pnlReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlReport.Location = New System.Drawing.Point(0, 0)
        Me.pnlReport.Name = "pnlReport"
        Me.pnlReport.Size = New System.Drawing.Size(994, 622)
        Me.pnlReport.TabIndex = 5
        '
        'StiViwerControl
        '
        Me.StiViwerControl.AllowDrop = True
        Me.StiViwerControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StiViwerControl.IgnoreApplyStyle = False
        Me.StiViwerControl.Location = New System.Drawing.Point(0, 0)
        Me.StiViwerControl.Name = "StiViwerControl"
        Me.StiViwerControl.Report = Nothing
        Me.StiViwerControl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StiViwerControl.ShowCloseButton = False
        Me.StiViwerControl.ShowZoom = True
        Me.StiViwerControl.Size = New System.Drawing.Size(994, 622)
        Me.StiViwerControl.TabIndex = 0
        '
        'FrmReportViewer_Stimul
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 622)
        Me.Controls.Add(Me.pnlReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportViewer_Stimul"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Viewer"
        Me.pnlReport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlReport As System.Windows.Forms.Panel
    Friend WithEvents StiViwerControl As Stimulsoft.Report.Viewer.StiViewerControl
End Class
