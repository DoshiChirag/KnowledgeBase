Imports System.ComponentModel
Public Class EncryptedLicense
    Inherits License

    Private sSoftwareKey As String = String.Empty
    Public Overrides ReadOnly Property LicenseKey As String
        Get
            Return sSoftwareKey
        End Get
    End Property


    Public Sub New(ByVal sValidKey As String)
        sSoftwareKey = sValidKey
    End Sub
    Public Overrides Sub Dispose()

    End Sub
End Class
