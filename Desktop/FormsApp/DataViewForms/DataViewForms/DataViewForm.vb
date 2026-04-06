Public Class DataViewForm

    Private DataContext As New NorthwindEntities


    Public Sub New(ByVal EmpID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EmployeeRecordData1.RefreshData(EmpID, DataContext)
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click

        EmployeeRecordData1.Save()


    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click

        EmployeeRecordData1.Delete()

    End Sub

    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click

        EmployeeRecordData1.Cleanup()

        Me.Close()

    End Sub
End Class
