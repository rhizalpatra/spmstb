<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageSender
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
        Me.txtSenderName = New System.Windows.Forms.TextBox
        Me.txtMsgType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.btnOneMessage = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkRepeat = New System.Windows.Forms.CheckBox
        Me.lblRunningLight = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbInterval = New System.Windows.Forms.ComboBox
        Me.btnSetName = New System.Windows.Forms.Button
        Me.lblSentCount = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSenderName
        '
        Me.txtSenderName.Location = New System.Drawing.Point(129, 12)
        Me.txtSenderName.Name = "txtSenderName"
        Me.txtSenderName.Size = New System.Drawing.Size(189, 20)
        Me.txtSenderName.TabIndex = 0
        '
        'txtMsgType
        '
        Me.txtMsgType.Location = New System.Drawing.Point(129, 38)
        Me.txtMsgType.Name = "txtMsgType"
        Me.txtMsgType.Size = New System.Drawing.Size(189, 20)
        Me.txtMsgType.TabIndex = 0
        Me.txtMsgType.Text = "MSG"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sender role"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Message type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Message content"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(129, 69)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(189, 20)
        Me.txtMessage.TabIndex = 0
        '
        'btnOneMessage
        '
        Me.btnOneMessage.Enabled = False
        Me.btnOneMessage.Location = New System.Drawing.Point(274, 120)
        Me.btnOneMessage.Name = "btnOneMessage"
        Me.btnOneMessage.Size = New System.Drawing.Size(128, 26)
        Me.btnOneMessage.TabIndex = 2
        Me.btnOneMessage.Text = "Send one message"
        Me.btnOneMessage.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkRepeat)
        Me.GroupBox1.Controls.Add(Me.lblRunningLight)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbInterval)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 135)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Repeat sending"
        '
        'chkRepeat
        '
        Me.chkRepeat.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRepeat.Enabled = False
        Me.chkRepeat.Location = New System.Drawing.Point(67, 86)
        Me.chkRepeat.Name = "chkRepeat"
        Me.chkRepeat.Size = New System.Drawing.Size(64, 20)
        Me.chkRepeat.TabIndex = 3
        Me.chkRepeat.Text = "RUN"
        Me.chkRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRepeat.UseVisualStyleBackColor = True
        '
        'lblRunningLight
        '
        Me.lblRunningLight.BackColor = System.Drawing.Color.LightCoral
        Me.lblRunningLight.Location = New System.Drawing.Point(54, 76)
        Me.lblRunningLight.Name = "lblRunningLight"
        Me.lblRunningLight.Size = New System.Drawing.Size(94, 42)
        Me.lblRunningLight.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(127, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "seconds"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Every"
        '
        'cmbInterval
        '
        Me.cmbInterval.FormattingEnabled = True
        Me.cmbInterval.Items.AddRange(New Object() {"0.1", "0.5", "1", "1.5", "2", "3", "4", "5"})
        Me.cmbInterval.Location = New System.Drawing.Point(82, 35)
        Me.cmbInterval.Name = "cmbInterval"
        Me.cmbInterval.Size = New System.Drawing.Size(39, 21)
        Me.cmbInterval.TabIndex = 0
        Me.cmbInterval.Text = "1"
        '
        'btnSetName
        '
        Me.btnSetName.Location = New System.Drawing.Point(324, 12)
        Me.btnSetName.Name = "btnSetName"
        Me.btnSetName.Size = New System.Drawing.Size(81, 19)
        Me.btnSetName.TabIndex = 4
        Me.btnSetName.Text = "Set Name"
        Me.btnSetName.UseVisualStyleBackColor = True
        '
        'lblSentCount
        '
        Me.lblSentCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSentCount.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSentCount.Location = New System.Drawing.Point(253, 184)
        Me.lblSentCount.Name = "lblSentCount"
        Me.lblSentCount.Size = New System.Drawing.Size(83, 20)
        Me.lblSentCount.TabIndex = 5
        Me.lblSentCount.Text = "0"
        Me.lblSentCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(342, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "sent"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'MessageSender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 299)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblSentCount)
        Me.Controls.Add(Me.btnSetName)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOneMessage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.txtMsgType)
        Me.Controls.Add(Me.txtSenderName)
        Me.Name = "MessageSender"
        Me.Text = "Message SenderRole"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSenderName As System.Windows.Forms.TextBox
    Friend WithEvents txtMsgType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnOneMessage As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRepeat As System.Windows.Forms.CheckBox
    Friend WithEvents lblRunningLight As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbInterval As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetName As System.Windows.Forms.Button
    Friend WithEvents lblSentCount As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
