<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatsForm
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
        Me.components = New System.ComponentModel.Container
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btnRequestStats = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnClearList = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(5, 21)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(525, 368)
        Me.ListBox1.TabIndex = 0
        '
        'btnRequestStats
        '
        Me.btnRequestStats.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRequestStats.Location = New System.Drawing.Point(546, 21)
        Me.btnRequestStats.Name = "btnRequestStats"
        Me.btnRequestStats.Size = New System.Drawing.Size(139, 24)
        Me.btnRequestStats.TabIndex = 1
        Me.btnRequestStats.Text = "Request stats"
        Me.btnRequestStats.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'btnClearList
        '
        Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearList.Location = New System.Drawing.Point(546, 51)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(139, 32)
        Me.btnClearList.TabIndex = 2
        Me.btnClearList.Text = "Clear list"
        Me.btnClearList.UseVisualStyleBackColor = True
        '
        'StatsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 400)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.btnRequestStats)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "StatsForm"
        Me.Text = "StatsForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnRequestStats As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnClearList As System.Windows.Forms.Button
End Class
