<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageReceiver
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
        Me.txtSRFilter = New System.Windows.Forms.TextBox
        Me.txtTFilter = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnClear = New System.Windows.Forms.Button
        Me.chkShowMsgs = New System.Windows.Forms.CheckBox
        Me.btnReceiveForInterval = New System.Windows.Forms.Button
        Me.ReceiveIntervalTimer = New System.Windows.Forms.Timer(Me.components)
        Me.txtSFilter = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 113)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(562, 264)
        Me.ListBox1.TabIndex = 0
        '
        'txtSRFilter
        '
        Me.txtSRFilter.Location = New System.Drawing.Point(124, 9)
        Me.txtSRFilter.Name = "txtSRFilter"
        Me.txtSRFilter.Size = New System.Drawing.Size(182, 20)
        Me.txtSRFilter.TabIndex = 1
        '
        'txtTFilter
        '
        Me.txtTFilter.Location = New System.Drawing.Point(124, 38)
        Me.txtTFilter.Name = "txtTFilter"
        Me.txtTFilter.Size = New System.Drawing.Size(182, 20)
        Me.txtTFilter.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SenderRole filter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type Filter"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(500, 55)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(73, 32)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'chkShowMsgs
        '
        Me.chkShowMsgs.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkShowMsgs.AutoSize = True
        Me.chkShowMsgs.Location = New System.Drawing.Point(362, 52)
        Me.chkShowMsgs.Name = "chkShowMsgs"
        Me.chkShowMsgs.Size = New System.Drawing.Size(120, 23)
        Me.chkShowMsgs.TabIndex = 4
        Me.chkShowMsgs.Text = "Show messages in list"
        Me.chkShowMsgs.UseVisualStyleBackColor = True
        '
        'btnReceiveForInterval
        '
        Me.btnReceiveForInterval.Location = New System.Drawing.Point(500, 12)
        Me.btnReceiveForInterval.Name = "btnReceiveForInterval"
        Me.btnReceiveForInterval.Size = New System.Drawing.Size(74, 37)
        Me.btnReceiveForInterval.TabIndex = 5
        Me.btnReceiveForInterval.Text = "Receive for 10 secs"
        Me.btnReceiveForInterval.UseVisualStyleBackColor = True
        '
        'ReceiveIntervalTimer
        '
        Me.ReceiveIntervalTimer.Interval = 10000
        '
        'txtSFilter
        '
        Me.txtSFilter.Location = New System.Drawing.Point(124, 71)
        Me.txtSFilter.Name = "txtSFilter"
        Me.txtSFilter.Size = New System.Drawing.Size(182, 20)
        Me.txtSFilter.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Subject Filter"
        '
        'MessageReceiver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 391)
        Me.Controls.Add(Me.btnReceiveForInterval)
        Me.Controls.Add(Me.chkShowMsgs)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSFilter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTFilter)
        Me.Controls.Add(Me.txtSRFilter)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "MessageReceiver"
        Me.Text = "Message Receiver"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents txtSRFilter As System.Windows.Forms.TextBox
    Friend WithEvents txtTFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents chkShowMsgs As System.Windows.Forms.CheckBox
    Friend WithEvents btnReceiveForInterval As System.Windows.Forms.Button
    Friend WithEvents ReceiveIntervalTimer As System.Windows.Forms.Timer
    Friend WithEvents txtSFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
