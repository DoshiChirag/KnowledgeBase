Public Class EmployeeRecordData

    Private EntityContext As NorthwindEntities

    Public Sub RefreshData(ByVal EmployeeID As Integer, ByRef DataContext As NorthwindEntities)

        DataContext.Database.CommandTimeout = 60

        Dim Emp As Employee = DataContext.Employees.SingleOrDefault(Function(A) A.EmployeeID = EmployeeID)

        If Not Emp Is Nothing Then
            EmployeeBindingSource.DataSource = Emp
            EmployeeBindingSource.ResetBindings(False)
            AddressData1.SetDataContext(Emp)

        End If

        EntityContext = DataContext
    End Sub

    Public Sub Save()
        Dim Transaction As Entity.DbContextTransaction = Nothing

        Try


            Transaction = EntityContext.Database.BeginTransaction()
            Dim Emp As Employee = CType(EmployeeBindingSource.DataSource, Employee)
            Emp.HomePhone = HomePhone.Text

            Dim Count As Integer = EntityContext.SaveChanges()




            If Count = 1 Then
                Transaction.Commit()
            Else
                Transaction.Rollback()
                Dim Errors As List(Of Entity.Validation.DbEntityValidationResult) = EntityContext.GetValidationErrors().ToList()
                If (Errors.Count > 0) Then
                    Dim DataStr As String = Errors(0).ValidationErrors(0).ErrorMessage
                    MessageBox.Show(Me, DataStr, "Errors")

                End If
            End If


        Catch ex As Exception

            If Not Transaction Is Nothing Then
                Transaction.Rollback()
            End If

        Finally
            If Not Transaction Is Nothing Then
                Transaction.Dispose()
            End If


        End Try




    End Sub

    Public Sub Delete()

        Dim Transaction As Entity.DbContextTransaction = Nothing

        Try
            Transaction = EntityContext.Database.BeginTransaction()

            Dim Emp As Employee = CType(EmployeeBindingSource.DataSource, Employee)
            EntityContext.Employees.Remove(Emp)
            Dim Count As Integer = EntityContext.SaveChanges()


            If Count = 1 Then
                Transaction.Commit()
            Else

                Transaction.Rollback()

                Dim Errors As List(Of Entity.Validation.DbEntityValidationResult) = EntityContext.GetValidationErrors().ToList()
                If (Errors.Count > 0) Then
                    Dim DataStr As String = Errors(0).ValidationErrors(0).ErrorMessage
                    MessageBox.Show(Me, DataStr, "Errors")

                End If
            End If
        Catch ex As Exception

            If Not Transaction Is Nothing Then
                Transaction.Rollback()
            End If

        Finally
            If Not Transaction Is Nothing Then
                Transaction.Dispose()
            End If


        End Try

    End Sub

    Public Sub Cleanup()

        EntityContext.Database.Connection.Close()
        EntityContext.Database.Connection.Dispose()
        EntityContext.Dispose()

    End Sub

End Class
