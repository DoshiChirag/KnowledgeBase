<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeRecordData
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.AddressData1 = New DataViewForms.AddressData()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PhoneExt = New System.Windows.Forms.TextBox()
        Me.EmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.HomePhone = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HireDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BirthDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 528)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.AddressData1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 246)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(452, 282)
        Me.Panel3.TabIndex = 1
        '
        'AddressData1
        '
        Me.AddressData1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddressData1.Location = New System.Drawing.Point(0, 0)
        Me.AddressData1.Name = "AddressData1"
        Me.AddressData1.Size = New System.Drawing.Size(452, 282)
        Me.AddressData1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(452, 246)
        Me.Panel2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PhoneExt)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.HomePhone)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.HireDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.BirthDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LastName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.FirstName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(452, 246)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee Info"
        '
        'PhoneExt
        '
        Me.PhoneExt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "Extension", True))
        Me.PhoneExt.Location = New System.Drawing.Point(314, 187)
        Me.PhoneExt.Name = "PhoneExt"
        Me.PhoneExt.Size = New System.Drawing.Size(87, 20)
        Me.PhoneExt.TabIndex = 11
        '
        'EmployeeBindingSource
        '
        Me.EmployeeBindingSource.DataSource = GetType(DataViewForms.Employee)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(287, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Ext."
        '
        'HomePhone
        '
        Me.HomePhone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "HomePhone", True))
        Me.HomePhone.Location = New System.Drawing.Point(137, 187)
        Me.HomePhone.Name = "HomePhone"
        Me.HomePhone.Size = New System.Drawing.Size(134, 20)
        Me.HomePhone.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Home Phone"
        '
        'HireDate
        '
        Me.HireDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "HireDate", True))
        Me.HireDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EmployeeBindingSource, "HireDate", True))
        Me.HireDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.HireDate.Location = New System.Drawing.Point(137, 141)
        Me.HireDate.Name = "HireDate"
        Me.HireDate.Size = New System.Drawing.Size(134, 20)
        Me.HireDate.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Hire Date"
        '
        'BirthDate
        '
        Me.BirthDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "BirthDate", True))
        Me.BirthDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EmployeeBindingSource, "BirthDate", True))
        Me.BirthDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.BirthDate.Location = New System.Drawing.Point(137, 93)
        Me.BirthDate.Name = "BirthDate"
        Me.BirthDate.Size = New System.Drawing.Size(134, 20)
        Me.BirthDate.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Birth Date"
        '
        'LastName
        '
        Me.LastName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "FirstName", True))
        Me.LastName.Location = New System.Drawing.Point(137, 56)
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(264, 20)
        Me.LastName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Last Name"
        '
        'FirstName
        '
        Me.FirstName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "LastName", True))
        Me.FirstName.Location = New System.Drawing.Point(137, 17)
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(264, 20)
        Me.FirstName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name"
        '
        'EmployeeRecordData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EmployeeRecordData"
        Me.Size = New System.Drawing.Size(452, 528)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PhoneExt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents HomePhone As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents HireDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents BirthDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents LastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents FirstName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents AddressData1 As AddressData
    Friend WithEvents EmployeeBindingSource As BindingSource
End Class
