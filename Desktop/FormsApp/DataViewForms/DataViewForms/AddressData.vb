Public Class AddressData

    Public Sub SetDataContext(ByRef Data As Employee)

        Me.EmployeeBindingSource.DataSource = Data
        Me.EmployeeBindingSource.ResetBindings(False)

    End Sub

End Class
