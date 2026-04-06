Imports System.ComponentModel
Imports Microsoft.Win32
Public Class EncryptRegistryLicense
    Inherits LicenseProvider


    Public Overrides Function GetLicense(context As LicenseContext, type As Type, instance As Object, allowExceptions As Boolean) As License
        Dim sSoftwareKey As String = String.Empty
        If context.UsageMode = LicenseUsageMode.Designtime Then
            sSoftwareKey = context.GetSavedLicenseKey(type, Nothing)
        Else
            Dim rSoftware As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", False)
            Dim rYourCompany As RegistryKey = rSoftware.OpenSubKey("Chirag Doshi\EncryptionControl", False)
            If Not rYourCompany Is Nothing Then
                sSoftwareKey = rYourCompany.GetValue("Key", "")
                context.SetSavedLicenseKey(type, sSoftwareKey)
            End If
            rYourCompany.Close()
            rSoftware.Close()
        End If

        If sSoftwareKey.Length < 1 And allowExceptions = False Then
            Throw New LicenseException(type)
        Else
            If IsKeyValid(sSoftwareKey) Then
                Return New EncryptedLicense(sSoftwareKey)
            Else
                Throw New LicenseException(type)
            End If
        End If
    End Function


    Protected Function IsKeyValid(ByVal sCheckKey As String) As Boolean
        Dim iKey As Integer

        iKey = Val(sCheckKey.Substring(0, 2)) + Val(sCheckKey.Substring(10, 2))
        Dim iTest As Integer = iKey Mod 14

        If iTest = 10 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
