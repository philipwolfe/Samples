Imports System.IO

Public Class Form1



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' My.Application

        Me.Text = My.Application.Info.ProductName + "." + Me.Name

        ' Display a list of all the open forms
        RefreshOpenFormsList()

        ' My.Computer

        Me.computerNameLabel.Text = My.Computer.Name
        Me.clockLabel.Text = My.Computer.Clock.LocalTime.ToString("MM/dd/yyyy hh:mm")
        Me.currentDirTextBox.Text = My.Computer.FileSystem.CurrentDirectory

        ' Drive information
        AddHandler drivesDataGridView.DataError, AddressOf drivesDataGridView_DataError
        Me.drivesDataGridView.DataSource = My.Computer.FileSystem.Drives
        Me.drivesDataGridView.AutoGenerateColumns = True

        Me.soundsComboBox.Items.AddRange(New String() {"Asterisk", "Beep", "Exclamation", "Hand", "Question"})
        Me.computerInfoPropertyGrid.SelectedObject = My.Computer.Info

        ' My.Forms

        ' All the forms in an application are available via the My.Forms namespace
        AddHandler form2Button.Click, AddressOf form2Button_Click
        AddHandler form3Button.Click, AddressOf form3Button_Click

        ' My.Resources
        ' Image resources added at design time are available 
        ' as properties in the My.Resources namespace
        Me.PictureBox1.Image = My.Resources.Back
        Me.PictureBox2.Image = My.Resources.Forward
        Me.stringResource1TextBox.Text = My.Resources.StringResource1

        ' My.Settings
        Me.appSetting1TextBox.Text = My.Settings.AppSetting1
        Me.appSetting2TextBox.Text = My.Settings.AppSetting2

        ' My.User
        Me.userNameLabel.Text = My.User.Name
        If My.User.IsInRole("Administrators") Then
            Me.userNameLabel.ForeColor = Color.Red
        End If

    End Sub

    Public Sub RefreshOpenFormsList()
        Me.openFormsListBox.Items.Clear()

        Dim forms As IEnumerator = My.Application.OpenForms.GetEnumerator
        While (forms.MoveNext = True)
            Me.openFormsListBox.Items.Add(forms.Current)
        End While
        Me.openFormsListBox.DisplayMember = "Text"

    End Sub


    Private Sub form2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Forms.Form2 Is Nothing Then
            My.Forms.Form2.Show()
        End If
        RefreshOpenFormsList()

    End Sub

    Private Sub form3Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Forms.Form3 Is Nothing Then
            My.Forms.Form3.Show()
        End If
        RefreshOpenFormsList()

    End Sub

    Private Sub refreshFormsListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refreshFormsListButton.Click
        RefreshOpenFormsList()

    End Sub

    Private Sub playSoundButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles playSoundButton.Click
        Select Case CType(Me.soundsComboBox.SelectedItem, String)
            Case "Asterisk"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
            Case "Beep"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
            Case "Exclamation"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
            Case "Hand"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
            Case "Question"
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Question)
            Case Else
                'ignore
        End Select

    End Sub

    Private Sub drivesDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        ' Not all drive information is available
        ' Ignore errors
    End Sub
End Class
