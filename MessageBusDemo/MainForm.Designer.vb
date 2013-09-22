<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnNewReceiver = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnStatsRequest = New System.Windows.Forms.Button
        Me.btnStart10Senders = New System.Windows.Forms.Button
        Me.btnFormulas = New System.Windows.Forms.Button
        Me.btnOpenFollower = New System.Windows.Forms.Button
        Me.GUIThread = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(29, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 39)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "New Message Sender"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnNewReceiver
        '
        Me.btnNewReceiver.Location = New System.Drawing.Point(29, 156)
        Me.btnNewReceiver.Name = "btnNewReceiver"
        Me.btnNewReceiver.Size = New System.Drawing.Size(134, 38)
        Me.btnNewReceiver.TabIndex = 1
        Me.btnNewReceiver.Text = "New Message Receiver"
        Me.btnNewReceiver.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(279, 24)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(118, 36)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnStatsRequest
        '
        Me.btnStatsRequest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStatsRequest.Location = New System.Drawing.Point(283, 86)
        Me.btnStatsRequest.Name = "btnStatsRequest"
        Me.btnStatsRequest.Size = New System.Drawing.Size(114, 32)
        Me.btnStatsRequest.TabIndex = 3
        Me.btnStatsRequest.Text = "Status request"
        Me.btnStatsRequest.UseVisualStyleBackColor = True
        '
        'btnStart10Senders
        '
        Me.btnStart10Senders.Location = New System.Drawing.Point(28, 69)
        Me.btnStart10Senders.Name = "btnStart10Senders"
        Me.btnStart10Senders.Size = New System.Drawing.Size(95, 63)
        Me.btnStart10Senders.TabIndex = 4
        Me.btnStart10Senders.Text = "Start 10 new senders"
        Me.btnStart10Senders.UseVisualStyleBackColor = True
        '
        'btnFormulas
        '
        Me.btnFormulas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFormulas.Location = New System.Drawing.Point(283, 124)
        Me.btnFormulas.Name = "btnFormulas"
        Me.btnFormulas.Size = New System.Drawing.Size(114, 32)
        Me.btnFormulas.TabIndex = 3
        Me.btnFormulas.Text = "Tracker"
        Me.btnFormulas.UseVisualStyleBackColor = True
        '
        'btnOpenFollower
        '
        Me.btnOpenFollower.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOpenFollower.Location = New System.Drawing.Point(283, 162)
        Me.btnOpenFollower.Name = "btnOpenFollower"
        Me.btnOpenFollower.Size = New System.Drawing.Size(114, 32)
        Me.btnOpenFollower.TabIndex = 3
        Me.btnOpenFollower.Text = "Open follower"
        Me.btnOpenFollower.UseVisualStyleBackColor = True
        '
        'GUIThread
        '
        Me.GUIThread.Enabled = True
        Me.GUIThread.Interval = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 225)
        Me.Controls.Add(Me.btnStart10Senders)
        Me.Controls.Add(Me.btnOpenFollower)
        Me.Controls.Add(Me.btnFormulas)
        Me.Controls.Add(Me.btnStatsRequest)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnNewReceiver)
        Me.Controls.Add(Me.Button1)
        Me.Name = "MainForm"
        Me.Text = "Message Bus Tester"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnNewReceiver As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnStatsRequest As System.Windows.Forms.Button
    Friend WithEvents btnStart10Senders As System.Windows.Forms.Button
    Friend WithEvents btnFormulas As System.Windows.Forms.Button
    Friend WithEvents btnOpenFollower As System.Windows.Forms.Button
    Public WithEvents GUIThread As System.Windows.Forms.Timer

End Class
