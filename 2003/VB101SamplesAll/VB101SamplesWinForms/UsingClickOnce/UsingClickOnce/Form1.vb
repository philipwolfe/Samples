Imports System.Text
Imports System.Deployment.Application
Imports System.ComponentModel

Public Class Form1
    Private appDeployment As System.Deployment.Application.ApplicationDeployment

    Public Sub New()
        InitializeComponent()

        ' Retrieve the current deployment.
        ' An InvalidDeploymentException is thrown if the application hasn't been deployed
        ' as, for instance, when running in debug mode.
        Try
            appDeployment = System.Deployment.Application.ApplicationDeployment.CurrentDeployment

            ' Add event handlers for asynchronous operations

            ' Handler for when an asynchroimpokjkrtsmkkn nous check for updates completes
            AddHandler appDeployment.CheckForUpdateCompleted, AddressOf appDeployment_CheckForUpdateCompleted
            ' Handler for asynchronous checks progress reports
            AddHandler appDeployment.CheckForUpdateProgressChanged, AddressOf appDeployment_CheckForUpdateProgressChanged

            ' Handler for when an asynchronous update completes
            AddHandler appDeployment.UpdateCompleted, AddressOf appDeployment_UpdateCompleted
            ' Handler for asynchronous update progress reports
            AddHandler appDeployment.UpdateProgressChanged, AddressOf appDeployment_UpdateProgressChanged

        Catch ex As System.Deployment.Application.DeploymentException
            MessageBox.Show(Me, "This sample will not run in debug mode.  In Visual Studio 2005, use ClickOnce to deploy the compiled sample, then run the sample.  View the sample ReadMe for details.", Me.Text)
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' appDeployment == nothing if running in Visual Studio 2005.
        ' This sample will not run in Visual Studio 2005.  
        If appDeployment IsNot Nothing Then
            ' Display the version number
            ' The ApplicationDeployment.CurrentVersion is the version
            ' in the Publish tab of the Project Properties window.
            Me.versionLabel.Text += appDeployment.CurrentVersion.ToString()

            ' Display when the application last checked for an update.
            ' Time is given in Universal Time.
            Me.timeOfLastCheckLabel.Text += appDeployment.TimeOfLastUpdateCheck.ToString()
        End If
    End Sub

    Public Sub FeedbackNoUpdateAvailable()
        ' Provide feedback that no update is available
        MessageBox.Show(Me, "The application is up to date.", "No update available.")
    End Sub

    Public Sub FeedbackUpdateAvailable(ByVal availableVersion As Version, ByVal isUpdateRequired As Boolean, ByVal minimumRequiredVersion As Version, ByVal updateSizeBytes As Long)
        ' Provide details about the available update
        Dim Message As New StringBuilder()
        Message.AppendLine("An update is available.")
        Message.AppendLine("Details:")
        Message.AppendLine("   Available version: " + availableVersion.ToString())

        Dim updateRequired As String = " "
        If Not isUpdateRequired Then
            updateRequired = "not "
        End If

        Message.AppendLine("   The update is " + updateRequired + "required.")
        If minimumRequiredVersion Is Nothing Then
            Message.AppendLine("   Minimum version required: None")
        Else
            Message.AppendLine("   Minimum version required: " + minimumRequiredVersion.ToString())
        End If
        Message.AppendLine("   Update size: " + updateSizeBytes.ToString() + " bytes")

        MessageBox.Show(Me, Message.ToString(), "Update available.")
    End Sub

    Public Sub QueryRestart()
        ' Once an update has been installed,
        ' the application must be restarted to see the new version.
        ' Query the user to restart now.  If don't restart now,
        ' the next time the application is run, it will install the update.
        If DialogResult.Yes = MessageBox.Show("The application must be restarted to see the changes.  You can restart now, or continue working and restart it later.  Restart now?", "Restart Application?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) Then
            Application.Restart()
        End If
    End Sub

    Public Sub ShowError(ByVal ex As Exception)
        MessageBox.Show("The following error occurred: " + ex.Message, ex.GetType().ToString())
    End Sub

    Private Sub checkForUpdatesLinkLabel_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles checkForUpdatesLinkLabel.LinkClicked
        ' There are two methods for checking for updates synchronously:
        '   CheckForUpdate()
        '   CheckForDetailedUpdate()
        ' This sample uses CheckForDetailedUpdate().

        ' CheckForUpdate() checks for an update, but retrieves no details, 
        ' and returns a boolean indicating whether an update is available.
        ' Use CheckForUpdate() if details are not desired.

        ' CheckForDetailedUpdate() checks for an update, and retrieves details about it
        Try
            Dim updateInfo As UpdateCheckInfo = appDeployment.CheckForDetailedUpdate()
            If updateInfo.UpdateAvailable Then
                FeedbackUpdateAvailable(updateInfo.AvailableVersion, updateInfo.IsUpdateRequired, updateInfo.MinimumRequiredVersion, updateInfo.UpdateSizeBytes)
            Else
                FeedbackNoUpdateAvailable()
            End If
        Catch deployEx As System.Deployment.Application.DeploymentException
            ShowError(deployEx)
        Catch invalidEx As InvalidOperationException
            ' If an Async operation is already in place,
            ' an InvalidOperationException will be thrown.
            ShowError(invalidEx)
        Catch ex As ApplicationException
            ShowError(ex)
        End Try
    End Sub

    Private Sub asyncCheckForUpdatesLinkLabel_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles asyncCheckForUpdatesLinkLabel.LinkClicked
        asyncCheckStatusLabel.Text = "Checking..."

        Try
            ' Initiate an asynchronous process to check for application updates
            appDeployment.CheckForUpdateAsync()
        Catch deployEx As DeploymentException
            ShowError(deployEx)
        Catch invalidEx As InvalidOperationException
            ' If an Async operation is already in place,
            ' an InvalidOperationException will be thrown.
            ShowError(invalidEx)
        Catch ex As ApplicationException
            ShowError(ex)
        End Try
    End Sub

    Private Sub stopAsyncCheckLinkLabel_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles stopAsyncCheckLinkLabel.LinkClicked
        ' Cancel the asynchronous check for application updates
        appDeployment.CheckForUpdateAsyncCancel()
    End Sub

    Private Sub updateLinkLabel_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles updateLinkLabel.LinkClicked
        Try
            ' Synchronously update the application
            If Not appDeployment.Update() Then
                ' ApplicationDeployment.Update() will return false if no update is available.
                ' 
                FeedbackNoUpdateAvailable()
            Else
                ' The update has been installed
                ' Must restart the application to see the update
                QueryRestart()
            End If
        Catch deployEx As System.Deployment.Application.DeploymentException
            ShowError(deployEx)
        Catch invalidEx As InvalidOperationException
            ' If an Async operation is already in place,
            ' an InvalidOperationException will be thrown.
            ShowError(invalidEx)
        Catch ex As ApplicationException
            ShowError(ex)
        End Try
    End Sub

    Private Sub updateAsyncLinkLabel_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles updateAsyncLinkLabel.LinkClicked
        asyncUpdateStatusLabel.Text = "Updating..."

        Try
            ' Initiate asynchronous process to update the application
            appDeployment.UpdateAsync()
        Catch deployEx As DeploymentException
            ShowError(deployEx)
        Catch invalidEx As InvalidOperationException
            ' If an Async operation is already in place,
            ' an InvalidOperationException will be thrown.
            ShowError(invalidEx)
        Catch ex As ApplicationException
            ShowError(ex)
        End Try
    End Sub

    Private Sub appDeployment_UpdateProgressChanged(ByVal sender As Object, ByVal e As DeploymentProgressChangedEventArgs)
        ' Report progress on the asynchronous Update
        asyncUpdateStatusLabel.Text = e.ProgressPercentage.ToString() + "% " + "[" + e.BytesCompleted.ToString() + " bytes]"
    End Sub

    Private Sub appDeployment_UpdateCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        ' Asynchronous update complete.  Report results.
        ' An update download can be cancelled...
        If e.Cancelled Then
            asyncUpdateStatusLabel.Text = "Cancelled."
            ' complete with errors...
        ElseIf e.Error IsNot Nothing Then
            asyncCheckStatusLabel.Text = "ERROR: " + e.Error.Message
            ' or complete successfully
        Else
            asyncCheckStatusLabel.Text = "Complete."

            ' UpdateAsync() will indicate success even if no
            ' update is available.  Use ApplicationDeployment.UpdatedVersion
            ' to check the versions.
            If appDeployment.UpdatedVersion = appDeployment.CurrentVersion Then
                FeedbackNoUpdateAvailable()
            Else
                ' Must restart the application to see the changes
                QueryRestart()
            End If
        End If
    End Sub

    Private Sub appDeployment_CheckForUpdateProgressChanged(ByVal sender As Object, ByVal e As DeploymentProgressChangedEventArgs)
        ' Report progress on the asynchronous CheckForUpdate call
        asyncCheckStatusLabel.Text = e.ProgressPercentage.ToString() + "% " + "[" + e.BytesCompleted.ToString() + " bytes]"
    End Sub

    Private Sub appDeployment_CheckForUpdateCompleted(ByVal sender As Object, ByVal e As CheckForUpdateCompletedEventArgs)
        ' Asynchronous CheckForUpdate call complete.  Report results.
        ' CheckForUpdateAsync can be cancelled...
        If (e.Cancelled) Then
            asyncCheckStatusLabel.Text = "Cancelled."
            ' complete with errors...
        ElseIf (e.Error IsNot Nothing) Then
            asyncCheckStatusLabel.Text = "ERROR: " + e.Error.Message
            ' or complete successfully
        Else
            asyncCheckStatusLabel.Text = "Complete."

            ' Provide details on results of the check
            If e.UpdateAvailable Then
                FeedbackUpdateAvailable(e.AvailableVersion, e.IsUpdateRequired, e.MinimumRequiredVersion, e.UpdateSizeBytes)
            Else
                FeedbackNoUpdateAvailable()
            End If
        End If
    End Sub

    Private Sub stopAsyncUpdateLinkLabel_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles stopAsyncUpdateLinkLabel.LinkClicked
        ' Cancel the asynchronous update.
        appDeployment.UpdateAsyncCancel()
    End Sub

End Class
