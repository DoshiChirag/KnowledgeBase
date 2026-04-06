Imports System.ComponentModel
Imports EncryptionComponent
Imports System.Windows.Forms
<LicenseProvider(GetType(EncryptRegistryLicense))>
Public Class EncryptControl

    Const title As String = "Security Component"
    Dim WithEvents Enc As New EncryptComponent()

    Private _License As License = Nothing
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        _License = LicenseManager.Validate(Me.GetType(), Me)
        ' Add any initialization after the InitializeComponent() call.
        If Enc.DoesPasswordExist() = False Then
            lblEncrypt.Text = "Please create a password"
        Else
            lblEncrypt.Text = "Please enter your password"
        End If

        enableControls(False)

        tbPassword.Focus()

    End Sub


    Private Sub enableControls(ByVal bEnabled As Boolean)
        GroupBox1.Enabled = bEnabled
        cmdProcess.Enabled = bEnabled
        tbFile.Enabled = bEnabled
        lblEncrypt.Enabled = bEnabled
        tbPassword.Enabled = Not bEnabled
        cmdPasssword.Enabled = Not bEnabled
    End Sub

    Public Sub createPassword()
        Static bSecondPasswordTry As Boolean = False

        If Not bSecondPasswordTry Then
            If Enc.CreateNewPasswordFirstTry(tbPassword.Text.Trim()) = True Then
                lblEncrypt.Text = "Please re-enter password"
                tbPassword.Text = ""
                bSecondPasswordTry = True
                tbPassword.Focus()
                Exit Sub
            End If
        Else
            If Enc.CreateNewPasswordSecondTry(tbPassword.Text.Trim()) = True Then
                lblEncrypt.Text = ""
                tbPassword.Text = ""
            Else
                bSecondPasswordTry = False
                Exit Sub
            End If
        End If


        MessageBox.Show(Me.FindForm(), "Pass Phrase successfully created", title, MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub cbFile_CheckedChanged(sender As Object, e As EventArgs) Handles cbFile.CheckedChanged
        If cbFile.Checked Then
            CmdFile.Enabled = True
            cbFile.Text = "Encrypt File"
            lbEncrypted.Enabled = False
        Else
            CmdFile.Enabled = False
            cbFile.Text = "Decrypt File"
            lbEncrypted.Enabled = True
        End If
    End Sub

    Private Sub CmdFile_Click(sender As Object, e As EventArgs) Handles CmdFile.Click
        With ofdFile
            .InitialDirectory = "C:\"
            .Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            .FilterIndex = 2
            .RestoreDirectory = True
            .Title = "Select file to encrypt."
        End With

        If ofdFile.ShowDialog() = DialogResult.OK Then
            tbFile.Text = ofdFile.FileName
        Else
            tbFile.Text = ""
        End If
    End Sub

    Private Sub cmdPasssword_Click(sender As Object, e As EventArgs) Handles cmdPasssword.Click
        If Enc.DoesPasswordExist = False Then
            createPassword()
        Else
            Enc.Password(tbPassword.Text)
        End If

        If Enc.IsEncryptionInitialized = True Then
            enableControls(True)
            lbEncrypted.Enabled = False
            updateEncryptedFiles()
            lblEncrypt.Text = "select file to en/decrypt"
        End If
    End Sub


    Private Sub updateEncryptedFiles()
        Dim aArrayList As ArrayList
        aArrayList = CType(Enc.ReturnEncryptedFiles(), ArrayList)

        With lbEncrypted
            .Sorted = True
            .Items.Clear()
        End With

        Dim iIndex As Integer
        For iIndex = 0 To aArrayList.Count - 1
            lbEncrypted.Items.Add(aArrayList(iIndex))
        Next
    End Sub
    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        If tbFile.Text.Equals("") Then
            MessageBox.Show(Me.FindForm(), "Please enter a file", title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If cbFile.Checked Then
            If Enc.EncryptFile(tbFile.Text.Trim()) = True Then
                updateEncryptedFiles()
                lbEncrypted.Enabled = False
            End If
        Else
            If Enc.DecryptFile(tbFile.Text.Trim()) = True Then
                updateEncryptedFiles()
                lbEncrypted.Enabled = True
            End If
        End If

        tbFile.Text = ""
    End Sub

    Private Sub processNormalEvent(ByVal sMessage As String) Handles Enc.EncryptMessage
        MessageBox.Show(Me.FindForm(), sMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub processErrorEvent(ByVal sMessage As String) Handles Enc.EncryptErrMessage
        MessageBox.Show(Me.FindForm(), sMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub lbEncrypted_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbEncrypted.SelectedIndexChanged
        tbFile.Text = lbEncrypted.SelectedItem
    End Sub

    Private Sub EncryptControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbPassword.Focus()
    End Sub


End Class
