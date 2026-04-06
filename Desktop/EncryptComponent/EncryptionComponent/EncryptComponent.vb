Imports System.Text
Imports System.Text.UnicodeEncoding
Imports System.Security.Cryptography
Imports System.Resources
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Windows.Forms
Imports EncryptionComponent.HelperRoutines
Public Class EncryptComponent

    Private sPasswordHashFromResource As String = String.Empty
    Private sPasswordString As String = String.Empty
    Private sUserPasswordFirstTry As String = String.Empty
    Private sUserPasswordSecondTry As String = String.Empty
    Private bInitialized As Boolean = False
    Private bMessageToHost As Boolean = False
    Const Title As String = "Security Component"
    Private pdp As PasswordDeriveBytes


    Public Event EncryptMessage(ByVal sMessage As String)
    Public Event EncryptErrMessage(ByVal sMessage As String)

    Public Property MessagesToHost() As Boolean
        Get
            Return bMessageToHost
        End Get
        Set(value As Boolean)
            bMessageToHost = value
        End Set
    End Property

    Public Sub Password(ByVal sPassword As String)
        If PasswordIsValid(sPassword) Then
            If AuthenticateUser(sPassword) Then
                sPasswordString = sPassword
            End If
        End If
    End Sub


#Region "Public methods"

    Public Function ReturnEncryptedFiles() As ArrayList
        Return updateFileCollection()
    End Function

    Public Function IsEncryptionInitialized() As Boolean
        Return bInitialized
    End Function

    Public Function DoesPasswordExist() As Boolean
        Return Not (Len(sPasswordHashFromResource) = 0)
    End Function

    Public Function CreateNewPasswordFirstTry(ByVal sPassword As String) As Boolean
        If sPasswordHashFromResource <> "" Then
            RaiseEvent EncryptErrMessage("A password already exists")
            Return False
        End If

        If Not PasswordIsValid(sPassword) Then
            Return False
        Else
            sUserPasswordFirstTry = sPassword
            Return True
        End If


    End Function

    Public Function CreateNewPasswordSecondTry(ByVal sPassword As String) As Boolean
        If sPasswordHashFromResource <> "" Then
            RaiseEvent EncryptErrMessage("A password already exists")
            Return False
        End If

        If Not PasswordIsValid(sPassword) Then
            Return False
        Else
            sUserPasswordSecondTry = sPassword
        End If


        If MatchNewPasswords(sUserPasswordFirstTry, sUserPasswordSecondTry) = True Then
            Dim sNewPWHash As String = hashString(sPassword)

            Dim rwResourceWriter As IResourceWriter
            rwResourceWriter = New ResourceWriter("Security.resources")

            With rwResourceWriter
                .AddResource("PasswordHash", sNewPWHash)
                .Close()
            End With

            Initialize(sNewPWHash)
            RaiseEvent EncryptMessage("Pass Phrase Successfully Created.")
            bInitialized = True
            Return True
        Else
            Return False
        End If

    End Function


    Public Function MatchNewPasswords(ByVal sFirstTry As String, ByVal sSecondTry As String) As Boolean
        If Not PasswordIsValid(sFirstTry) Then Return False
        If Not PasswordIsValid(sSecondTry) Then Return False

        If Not sFirstTry.Equals(sSecondTry) Then
            RaiseEvent EncryptErrMessage("The passwords do not match")
            Return False
        Else
            Return True
        End If
    End Function

    Public Function EncryptFile(ByVal sFile As String) As Boolean
        Dim sMessage As String = EncryptTheFile(sFile)
        If sMessage = "" Then
            RaiseEvent EncryptMessage("File '" & sFile & "' encrypted successfully.")
            Return True
        Else
            RaiseEvent EncryptErrMessage(sMessage)
            Return False
        End If
    End Function

    Public Function DecryptFile(ByVal sFile As String) As Boolean
        Dim sMessage As String = DecryptTheFile(sFile)
        If sMessage = "" Then
            RaiseEvent EncryptMessage("File '" & sFile & "' decrypted successfully.")
            Return True
        Else
            RaiseEvent EncryptErrMessage(sMessage)
            Return False
        End If
    End Function


    Public Function PasswordIsValid(ByVal sPassword As String) As Boolean
        If Not Regex.IsMatch(sPassword, "^\s*(\w){8}\s*$") Then
            RaiseEvent EncryptErrMessage("Enter an 8-digit password consisting of both  numbers and/or letters.")
            Return False
        Else
            Return True
        End If
    End Function



#End Region

#Region "Private Helper Password Routines"
    Private Function AuthenticateUser(ByVal sPassword As String) As Boolean
        If sPasswordHashFromResource = "" Then
            RaiseEvent EncryptErrMessage("No Password Exists on file, Please create a new password.")
            Return False
        End If

        Dim sUserEnteredPW As String = hashString(sPassword)

        If sUserEnteredPW.Equals(sPasswordHashFromResource) Then
            Initialize(sUserEnteredPW)
            bInitialized = True
            RaiseEvent EncryptMessage("Encryption Algorithm successfully initialized")
            Return True
        Else
            RaiseEvent EncryptErrMessage("Invalid Password.")
            Return False
        End If

    End Function

    Private Function getPasswordFromResource() As String
        Dim rmResMgr As ResourceManager = ResourceManager.CreateFileBasedResourceManager("Security", ".", Nothing)
        Try
            Dim sPWfromResource As String = rmResMgr.GetString("PasswordHash")
            rmResMgr.ReleaseAllResources()
            Return sPWfromResource
        Catch ex As Exception
            Return ""

        Finally
            rmResMgr.ReleaseAllResources()
        End Try
    End Function
#End Region
End Class
