<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FollowerForm
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
        Me.pbFollower = New System.Windows.Forms.PictureBox
        Me.lblH = New System.Windows.Forms.Label
        Me.lblM = New System.Windows.Forms.Label
        Me.lblS = New System.Windows.Forms.Label
        Me.lblT = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.pbFollower, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbFollower
        '
        Me.pbFollower.BackColor = System.Drawing.Color.Red
        Me.pbFollower.Location = New System.Drawing.Point(311, 180)
        Me.pbFollower.Name = "pbFollower"
        Me.pbFollower.Size = New System.Drawing.Size(22, 21)
        Me.pbFollower.TabIndex = 0
        Me.pbFollower.TabStop = False
        '
        'lblH
        '
        Me.lblH.BackColor = System.Drawing.Color.Transparent
        Me.lblH.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblH.Location = New System.Drawing.Point(20, 29)
        Me.lblH.Name = "lblH"
        Me.lblH.Size = New System.Drawing.Size(47, 25)
        Me.lblH.TabIndex = 1
        Me.lblH.Text = "H"
        '
        'lblM
        '
        Me.lblM.BackColor = System.Drawing.Color.Transparent
        Me.lblM.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblM.Location = New System.Drawing.Point(73, 29)
        Me.lblM.Name = "lblM"
        Me.lblM.Size = New System.Drawing.Size(38, 25)
        Me.lblM.TabIndex = 1
        Me.lblM.Text = "M"
        '
        'lblS
        '
        Me.lblS.BackColor = System.Drawing.Color.Transparent
        Me.lblS.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblS.Location = New System.Drawing.Point(117, 29)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(38, 25)
        Me.lblS.TabIndex = 1
        Me.lblS.Text = "S"
        '
        'lblT
        '
        Me.lblT.BackColor = System.Drawing.Color.Transparent
        Me.lblT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT.Location = New System.Drawing.Point(150, 30)
        Me.lblT.Name = "lblT"
        Me.lblT.Size = New System.Drawing.Size(38, 25)
        Me.lblT.TabIndex = 1
        Me.lblT.Text = "T"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(142, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 25)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(54, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 25)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(98, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 25)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = ":"
        '
        'FollowerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 461)
        Me.Controls.Add(Me.pbFollower)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblT)
        Me.Controls.Add(Me.lblS)
        Me.Controls.Add(Me.lblM)
        Me.Controls.Add(Me.lblH)
        Me.Name = "FollowerForm"
        Me.Text = "FollowerForm"
        CType(Me.pbFollower, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbFollower As System.Windows.Forms.PictureBox
    Friend WithEvents lblH As System.Windows.Forms.Label
    Friend WithEvents lblM As System.Windows.Forms.Label
    Friend WithEvents lblS As System.Windows.Forms.Label
    Friend WithEvents lblT As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
