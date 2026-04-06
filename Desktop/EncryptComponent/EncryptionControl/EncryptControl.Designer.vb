<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EncryptControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If

            If Not (_License Is Nothing) Then
                _License.Dispose()
                _License = Nothing
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
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.cmdPasssword = New System.Windows.Forms.Button()
        Me.tbFile = New System.Windows.Forms.TextBox()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lbEncrypted = New System.Windows.Forms.ListBox()
        Me.CmdFile = New System.Windows.Forms.Button()
        Me.cbFile = New System.Windows.Forms.CheckBox()
        Me.ofdFile = New System.Windows.Forms.OpenFileDialog()
        Me.lblEncrypt = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(32, 57)
        Me.tbPassword.MaxLength = 8
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(100, 20)
        Me.tbPassword.TabIndex = 0
        '
        'cmdPasssword
        '
        Me.cmdPasssword.Location = New System.Drawing.Point(153, 57)
        Me.cmdPasssword.Name = "cmdPasssword"
        Me.cmdPasssword.Size = New System.Drawing.Size(75, 23)
        Me.cmdPasssword.TabIndex = 1
        Me.cmdPasssword.Text = "&Authenticate"
        Me.cmdPasssword.UseVisualStyleBackColor = True
        '
        'tbFile
        '
        Me.tbFile.Location = New System.Drawing.Point(32, 106)
        Me.tbFile.Name = "tbFile"
        Me.tbFile.Size = New System.Drawing.Size(196, 20)
        Me.tbFile.TabIndex = 2
        '
        'cmdProcess
        '
        Me.cmdProcess.Location = New System.Drawing.Point(90, 149)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(75, 23)
        Me.cmdProcess.TabIndex = 3
        Me.cmdProcess.Text = "Process"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDescription)
        Me.GroupBox1.Controls.Add(Me.lbEncrypted)
        Me.GroupBox1.Controls.Add(Me.CmdFile)
        Me.GroupBox1.Controls.Add(Me.cbFile)
        Me.GroupBox1.Location = New System.Drawing.Point(263, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 165)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(19, 53)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(79, 13)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "Encrypted Files"
        '
        'lbEncrypted
        '
        Me.lbEncrypted.FormattingEnabled = True
        Me.lbEncrypted.Location = New System.Drawing.Point(19, 72)
        Me.lbEncrypted.Name = "lbEncrypted"
        Me.lbEncrypted.Size = New System.Drawing.Size(223, 69)
        Me.lbEncrypted.TabIndex = 2
        '
        'CmdFile
        '
        Me.CmdFile.Location = New System.Drawing.Point(191, 15)
        Me.CmdFile.Name = "CmdFile"
        Me.CmdFile.Size = New System.Drawing.Size(51, 25)
        Me.CmdFile.TabIndex = 1
        Me.CmdFile.Text = "File"
        Me.CmdFile.UseVisualStyleBackColor = True
        '
        'cbFile
        '
        Me.cbFile.AutoSize = True
        Me.cbFile.Checked = True
        Me.cbFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbFile.Location = New System.Drawing.Point(19, 20)
        Me.cbFile.Name = "cbFile"
        Me.cbFile.Size = New System.Drawing.Size(81, 17)
        Me.cbFile.TabIndex = 0
        Me.cbFile.Text = "Encrypt File"
        Me.cbFile.UseVisualStyleBackColor = True
        '
        'ofdFile
        '
        Me.ofdFile.FileName = "OpenFileDialog1"
        '
        'lblEncrypt
        '
        Me.lblEncrypt.AutoSize = True
        Me.lblEncrypt.Location = New System.Drawing.Point(32, 16)
        Me.lblEncrypt.Name = "lblEncrypt"
        Me.lblEncrypt.Size = New System.Drawing.Size(46, 13)
        Me.lblEncrypt.TabIndex = 5
        Me.lblEncrypt.Text = "Encrypt "
        '
        'EncryptControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblEncrypt)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.tbFile)
        Me.Controls.Add(Me.cmdPasssword)
        Me.Controls.Add(Me.tbPassword)
        Me.Name = "EncryptControl"
        Me.Size = New System.Drawing.Size(559, 199)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents cmdPasssword As System.Windows.Forms.Button
    Friend WithEvents tbFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lbEncrypted As System.Windows.Forms.ListBox
    Friend WithEvents CmdFile As System.Windows.Forms.Button
    Friend WithEvents cbFile As System.Windows.Forms.CheckBox
    Friend WithEvents ofdFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblEncrypt As System.Windows.Forms.Label
End Class
