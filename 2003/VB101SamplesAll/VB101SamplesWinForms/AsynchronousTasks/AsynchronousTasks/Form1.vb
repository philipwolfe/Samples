Imports System.ComponentModel

Public Class MainForm
    Private backgroundCalculator As System.ComponentModel.BackgroundWorker

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Prepare the background worker for asynchronous prime number calculation
        backgroundCalculator = New BackgroundWorker()
        ' Specify that the background worker provides progress notifications
        backgroundCalculator.WorkerReportsProgress = True
        ' Specify that the background worker supports cancellation
        backgroundCalculator.WorkerSupportsCancellation = True
        ' The DoWork event handler is the main work function of the background thread
        AddHandler backgroundCalculator.DoWork, New DoWorkEventHandler(AddressOf backgroundCalculator_DoWork)
        ' Specify the function to use to handle progress notifications
        AddHandler backgroundCalculator.ProgressChanged, New ProgressChangedEventHandler(AddressOf backgroundCalculator_ProgressChanged)
        ' Specify the function to run when the background worker finishes
        ' There are three conditions possible that should be handled in this function:
        ' 1. The work completed successfully
        ' 2. The work aborted with errors
        ' 3. The user cancelled the process
        AddHandler backgroundCalculator.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf backgroundCalculator_RunWorkerCompleted)

        updateStatus(String.Empty)

    End Sub

    ' This region implements calculating primes in a synchronous fashion
#Region "Synchronous calculation"


    ' Synchronously calculate the next prime number, 
    ' starting with a specified number.
    Private Function getNextPrimeSync(ByVal start As Integer) As Integer

        Dim percentComplete As Integer = 0

        start += 1
        While isPrime(start) = False

            ' start was not prime.  Try next number higher.
            start += 1

            ' Report progress
            percentComplete += 1

            ' With prime number calculation, there is no way to determine
            ' how far along you are, so simply move the progress bar
            ' and reset as needed
            updateProgress(percentComplete Mod 100)
        End While
        Return start
    End Function

    Private Sub nextPrimeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextPrimeButton.Click
        enableCalcButtons(False)
        updateStatus("Calculating...")

        Dim start As Integer
        Integer.TryParse(textBoxPrime.Text, start)

        If start = 0 Then
            reportError("The Prime number must be a valid integer")
        Else
            Try
                Dim prime As Integer = getNextPrimeSync(start)
                reportPrime(prime)
            Catch err As ApplicationException
                reportError(err)
            End Try
            calcProgress.Value = 0
        End If

        ' re-enable the calculation buttons
        enableCalcButtons(True)

    End Sub
#End Region

    ' This region implements calculating primes in an asynchronous fashion
#Region "Asynchronous calculation"

    ' The main worker function for calculating the next prime number
    ' It is identical to the synchronous version, except that 
    ' it checks for user cancellation, 
    ' and it reports progress using the BackgroundWorker.ReportProgress delegate.
    Private Function getNextPrimeAsync(ByVal start As Integer, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Integer

        Dim percentComplete As Integer = 0

        start += 1

        While isPrime(start) = False

            ' Check for cancellation
            If worker.CancellationPending = True Then
                e.Cancel = True
                Exit While
            Else
                ' start was not prime.  Try next number higher.
                start += 1

                ' Report progress
                percentComplete += 1

                ' With prime number calculation, there is no way to determine
                ' how far along you are, so simply move the progress bar
                ' and reset as needed
                worker.ReportProgress(percentComplete Mod 100)
            End If
        End While

        Return start
    End Function

    Sub backgroundCalculator_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)

        If e.Cancelled Then
            updateStatus("Cancelled.")
        ElseIf e.Error IsNot Nothing Then
            reportError(e.Error)
        Else
            reportPrime(CInt(e.Result))
        End If

        calcProgress.Value = 0
        ' re-enable the calculation buttons, disable "Cancel" button
        enableCalcButtons(True)
        cancelPrimeButton.Enabled = False
    End Sub

    Sub backgroundCalculator_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        updateProgress(e.ProgressPercentage)
    End Sub

    ' The DoWork method runs on another thread, and hence
    ' cannot access form elements generated on the UI
    ' thread.  Attempting to access such UI elements will
    ' throw an exception.
    Sub backgroundCalculator_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim start As Integer = CInt(e.Argument)
        e.Result = getNextPrimeAsync(start, CType(sender, BackgroundWorker), e)
    End Sub

    Private Sub nextPrimeAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextPrimeAsyncButton.Click
        enableCalcButtons(False)
        cancelPrimeButton.Enabled = True
        updateStatus("Calculating...")

        Dim start As Integer
        Integer.TryParse(textBoxPrime.Text, start)

        If start = 0 Then
            reportError("The Prime Number must be a valid integer")
        Else
            ' Kick off the background worker process
            backgroundCalculator.RunWorkerAsync(start)
        End If


    End Sub

    Private Sub cancelPrimeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelPrimeButton.Click
        If backgroundCalculator.IsBusy Then
            updateStatus("Cancelling...")
            backgroundCalculator.CancelAsync()
        End If
    End Sub
#End Region

    ' User Interface feedback
#Region "User Feedback"

    ' Update the Status label
    Private Sub updateStatus(ByVal status As String)
        calcStatus.Text = status
    End Sub

    ' Indicate progress using progress bar
    Private Sub updateProgress(ByVal percentComplete As Integer)
        calcProgress.Value = percentComplete
    End Sub

    ' Display the prime number
    Private Sub reportPrime(ByVal prime As Integer)
        textBoxPrime.Text = prime.ToString()
        updateStatus("Done!")
    End Sub

    ' Report an error
    Private Sub reportError(ByVal e As Exception)
        updateStatus("Error!")
        MessageBox.Show("The following error occurred: " + ControlChars.CrLf + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub reportError(ByVal message As String)
        updateStatus("Error!")
        MessageBox.Show("The following error occurred: " + ControlChars.CrLf + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' disable or enable the calculate buttons and textbox during and after a calculation, respectively
    Private Sub enableCalcButtons(ByVal bEnable As Boolean)
        nextPrimeAsyncButton.Enabled = bEnable
        nextPrimeButton.Enabled = bEnable
        textBoxPrime.Enabled = bEnable
    End Sub

#End Region

    ' Tries dividing by successively higher numbers 
    ' to check for primeness
    Private Function isPrime(ByVal candidate As Integer) As Boolean

        Dim retVal As Boolean = True

        ' It is more efficient to calculate using increasing numbers,
        ' but using decreasing numbers allows for a better demonstration
        ' of BackgroundWorkder cancellation.
        'For i As Integer = 2 to candidate / 2 + 1 
        For i As Integer = candidate / 2 + 1 To 2 Step -1

            If candidate Mod i = 0 Then
                retVal = False
                Exit For
            End If
        Next

        Return retVal
    End Function
End Class
