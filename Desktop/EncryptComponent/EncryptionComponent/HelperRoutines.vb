Imports System.Text
Imports System.Windows.Forms
Imports System.Text.UnicodeEncoding
Imports System.Security.Cryptography
Imports System.IO
Imports System.IO.IsolatedStorage
Imports EncryptionComponent.EncryptComponent

Module HelperRoutines
    Const title As String = "Security Component"
    Private sFileName As String = String.Empty
    Private sEncryptedDirectory As String = String.Empty
    Private sPasswordHash As String = String.Empty
    Private RijndaelEncryption As New RijndaelManaged()

    Private bKey(15) As Byte
    Private bIV(15) As Byte

    Private bInitialized As Boolean = False

    Private isoStore As IsolatedStorageFile
    Private aFileList As New ArrayList()

    Public Sub Initialize(ByVal sPWH As String)
        RijndaelEncryption = New RijndaelManaged()

        Dim md5 As New MD5CryptoServiceProvider()

        Dim bSalt() As Byte = md5.ComputeHash(convertStringToBytes(sPWH))

        Dim pdb As PasswordDeriveBytes = New PasswordDeriveBytes(sPWH, bSalt)
        bKey = pdb.GetBytes(32)

        Dim sIV As String = convertBytesToString(bKey)

        bIV = Encoding.ASCII.GetBytes(sIV.Substring(0, 16))

        With RijndaelEncryption
            .Key = bKey
            .IV = bIV
            .BlockSize = 128
            .Padding = PaddingMode.PKCS7
        End With

        bInitialized = True

        isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing, Nothing)

        updateFileCollection()
    End Sub

    Public Function EncryptTheFile(ByVal sFileName As String) As String
        If Not bInitialized Then
            Return "A valid pass phrase is required to encrypt/decrypt."
        End If

        If Not File.Exists(sFileName) Then
            Return "The file '" & sFileName & "' does not exist"
            Return False
        End If

        Dim fInfo As New FileInfo(sFileName)

        Dim sOutFileName As String = fInfo.Name

        If doesFileExistInStore(sOutFileName) Then
            Return "File: " & sFileName & " is already encrypted."
        End If

        If EncryptFile(sFileName, sOutFileName) = True Then
            Return ""

        Else
            Return "Error Encrypting File " & sFileName
        End If


    End Function


    Public Function DecryptTheFile(ByVal sFileName As String) As String

        If Not doesFileExistInStore(sFileName) Then
            Return "File: " & sFileName & "does not exist in encrypted store."
        End If

        Dim sOutFileName As String = "C:\Users\Chirag\Documents\Chirag\Current\" & sFileName


        If DecryptFile(sFileName, sOutFileName) = True Then
            Return ""
        Else
            Return "Error decrypting File " & sFileName
        End If


    End Function

    Friend Function hashString(ByVal sString As String)
        Dim aBytes() As Byte = New UnicodeEncoding().GetBytes(sString)
        Dim sha As New SHA1CryptoServiceProvider()
        Dim hHash As Byte() = sha.ComputeHash(aBytes)
        Return convertBytesToHexString(hHash)
    End Function

    Friend Function convertBytesToHexString(ByVal bBytes() As Byte) As String
        Dim sStringBuilder As New StringBuilder(40)
        Dim bByte As Byte
        For Each bByte In bBytes
            sStringBuilder.AppendFormat(Hex(bByte.ToString))
        Next

        Return sStringBuilder.ToString
    End Function

    Friend Function convertStringToBytes(ByVal sString As String) As Byte()
        Dim aBytes() As Byte = New UnicodeEncoding().GetBytes(sString)
        Return aBytes
    End Function

    Friend Function convertBytesToString(ByVal bBytes() As Byte) As String
        Return System.Convert.ToBase64String(bBytes, 0, bBytes.Length)
    End Function

    Public Function EncryptFile(ByVal sInFile As String, ByVal sOutFile As String) As String
        Dim fsStreamIn As New FileStream(sInFile, FileMode.Open, FileAccess.Read)

        Dim fsStreamOut As IsolatedStorageFileStream
        fsStreamOut = New IsolatedStorageFileStream(sOutFile, FileMode.Create, isoStore)
        fsStreamOut.SetLength(0)


        Dim bBuffer(4096) As Byte
        Dim lBytesWritten As Long = 8
        Dim lFileLength As Long = fsStreamIn.Length
        Dim lNumBytesToWrite As Integer = 0
        Dim encryptionStream As CryptoStream
        Dim bSuccessfulTransform As Boolean = False

        encryptionStream = New CryptoStream(fsStreamOut, RijndaelEncryption.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write)

        Try
            While lBytesWritten < lFileLength
                Array.Clear(bBuffer, 0, 4096)
                lNumBytesToWrite = fsStreamIn.Read(bBuffer, 0, 4096)
                encryptionStream.Write(bBuffer, 0, 4096)
                lBytesWritten = System.Convert.ToInt32(lBytesWritten + lNumBytesToWrite / RijndaelEncryption.BlockSize * RijndaelEncryption.BlockSize)
            End While


            bSuccessfulTransform = True

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            fsStreamIn.Close()
            fsStreamOut.Flush()
            fsStreamOut.Close()
        End Try

        If bSuccessfulTransform Then
            File.Delete(sInFile)
            Return True
        Else
            Return False
        End If

    End Function

    Public Function DecryptFile(ByVal sInFile As String, ByVal sOutFile As String) As String

        Dim fsStreamIn As IsolatedStorageFileStream
        fsStreamIn = New IsolatedStorageFileStream(sInFile, FileMode.Open, isoStore)

        Dim fsStreamOut As New FileStream(sOutFile, FileMode.OpenOrCreate, FileAccess.Write)

        fsStreamOut.SetLength(0)


        Dim bBuffer(4096) As Byte
        Dim lBytesWritten As Long = 8
        Dim lFileLength As Long = fsStreamIn.Length
        Dim lNumBytesToWrite As Integer = 0
        Dim encryptionStream As CryptoStream
        Dim bSuccessfulTransform As Boolean = False

        encryptionStream = New CryptoStream(fsStreamOut, RijndaelEncryption.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write)

        Try
            While lBytesWritten < lFileLength
                Array.Clear(bBuffer, 0, 4096)
                lNumBytesToWrite = fsStreamIn.Read(bBuffer, 0, 4096)
                encryptionStream.Write(bBuffer, 0, 4096)
                lBytesWritten = System.Convert.ToInt32(lBytesWritten + lNumBytesToWrite / RijndaelEncryption.BlockSize * RijndaelEncryption.BlockSize)
            End While

            fsStreamIn.Flush()
            fsStreamIn.Close()

            isoStore.DeleteFile(sInFile)
            bSuccessfulTransform = True

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally

            fsStreamOut.Flush()
            fsStreamOut.Close()
        End Try

        If bSuccessfulTransform Then
            File.Delete(sInFile)
            Return True
        Else
            Return False
        End If

    End Function

    Public Function updateFileCollection() As ArrayList
        Dim directoryList As New ArrayList()
        Dim directory As String = String.Empty
        Dim file As String = String.Empty

        aFileList.Clear()
        directoryList.Add("*")

        For Each directory In directoryList
            Dim files As String()
            files = isoStore.GetFileNames(directory + "*")
            For Each file In files
                aFileList.Add(file)
            Next
        Next

        Return aFileList
    End Function

    Private Function doesFileExistInStore(ByVal sFileName As String) As Boolean
        Dim filenames As String()
        filenames = isoStore.GetFileNames(sFileName)

        Dim file As String
        For Each file In filenames
            If file.Equals(sFileName) Then
                Return True
            End If
        Next

        Return False
    End Function










End Module
