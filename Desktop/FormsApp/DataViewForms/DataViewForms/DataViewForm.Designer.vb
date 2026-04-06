<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataViewForm
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Delete = New System.Windows.Forms.Button()
        Me.Save = New System.Windows.Forms.Button()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.EmployeeRecordData1 = New DataViewForms.EmployeeRecordData()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(675, 532)
        Me.Panel2.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Delete)
        Me.Panel4.Controls.Add(Me.Save)
        Me.Panel4.Controls.Add(Me.CloseBtn)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(481, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(194, 532)
        Me.Panel4.TabIndex = 2
        '
        'Delete
        '
        Me.Delete.BackColor = System.Drawing.Color.Blue
        Me.Delete.ForeColor = System.Drawing.Color.White
        Me.Delete.Location = New System.Drawing.Point(33, 81)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(122, 39)
        Me.Delete.TabIndex = 2
        Me.Delete.Text = "&Delete"
        Me.Delete.UseVisualStyleBackColor = False
        '
        'Save
        '
        Me.Save.BackColor = System.Drawing.Color.Blue
        Me.Save.ForeColor = System.Drawing.Color.White
        Me.Save.Location = New System.Drawing.Point(33, 23)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(122, 39)
        Me.Save.TabIndex = 1
        Me.Save.Text = "&Save"
        Me.Save.UseVisualStyleBackColor = False
        '
        'CloseBtn
        '
        Me.CloseBtn.BackColor = System.Drawing.Color.Blue
        Me.CloseBtn.ForeColor = System.Drawing.Color.White
        Me.CloseBtn.Location = New System.Drawing.Point(33, 140)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(122, 39)
        Me.CloseBtn.TabIndex = 0
        Me.CloseBtn.Text = "&Close"
        Me.CloseBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(481, 532)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.EmployeeRecordData1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(481, 532)
        Me.Panel3.TabIndex = 1
        '
        'EmployeeRecordData1
        '
        Me.EmployeeRecordData1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EmployeeRecordData1.Location = New System.Drawing.Point(0, 0)
        Me.EmployeeRecordData1.Name = "EmployeeRecordData1"
        Me.EmployeeRecordData1.Size = New System.Drawing.Size(481, 532)
        Me.EmployeeRecordData1.TabIndex = 1
        '
        'DataViewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 532)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "DataViewForm"
        Me.Text = "Data View Form"
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Delete As Button
    Friend WithEvents Save As Button
    Friend WithEvents CloseBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents EmployeeRecordData1 As EmployeeRecordData
End Class
