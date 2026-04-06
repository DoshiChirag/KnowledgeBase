Imports System.ComponentModel
Public Class EncryptionLicenseProvider
    Inherits LicFileLicenseProvider

    Protected Overrides Function IsKeyValid(key As String, type As Type) As Boolean
        Dim iKey As Integer

        iKey = Val(key.Substring(0, 2)) + Val(key.Substring(10, 2))
        Dim iTest As Integer = iKey Mod 14

        If iTest = 10 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
