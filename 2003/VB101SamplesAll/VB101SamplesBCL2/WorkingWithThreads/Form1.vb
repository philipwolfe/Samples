Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading

Partial Public Class Form1
    Inherits Form

#Region " Declarations "

    Private cr As String = Environment.NewLine
    Private foregroundLoops As Integer = 0
    Private backgroundLoops As Integer = 0
    Private numberToDouble As Integer = 0
    Private timesToDouble As Integer = 0

    ' The AutoResetEvent class is used to notify a thread that an event
    ' has occurred. This one is used to indicate that the user has chosen
    ' to cancel the current operation.
    Private haltProcessing As AutoResetEvent = New AutoResetEvent(False)

    ' These are delegates for calling back into the user interface. The first
    ' line declares a delegate type, along with the parameters it will expect,
    ' which must match the parameters of the procedure it will eventually point
    ' to. The second line declares a field, that will later become an instance
    ' of the delegate (see the Form's constructor). Once a delegate type has
    ' been declared, you can create multiple instances of that type.
    '
    Public Delegate Sub BooleanCallback(ByVal enable As Boolean) ' delegate type
    Private handleButtonsDelegate As BooleanCallback             ' delegate field

    Public Delegate Sub StringCallback(ByVal tb As TextBox, ByVal msg As String)
    Private updateResultsDelegate As StringCallback

#End Region

#Region " Constructor "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        ' Instantiate delegates for calling back into the user interface.
        ' Each delegate points to a specific procedure it will invoke.
        handleButtonsDelegate = New BooleanCallback(AddressOf HandleButtons)
        updateResultsDelegate = New StringCallback(AddressOf UpdateResults)
    End Sub

#End Region

#Region " Event Procedures "

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        HandleButtons(True)
        foregroundLoopsComboBox.SelectedIndex = 1
        backgroundLoopsComboBox.SelectedIndex = 1
        numberToDoubleComboBox.SelectedIndex = 0
        timesToDoubleComboBox.SelectedIndex = 1
    End Sub

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

#End Region

#Region "Basic Threading "

    ' This is the procedure that will be invoked on the background thread.
    Private Sub BackgroundProcedure(ByVal numLoops As Object)
        Dim cr As String = Environment.NewLine
        ' Code in a background thread has no direct access to the
        ' user interface, but the UpdateResults method is written
        ' to handle cross-thread communication.
        UpdateResults(resultsTextBoxBackground, "Background processing beginning" & cr)
        Dim howManyTimes As Integer = CType(numLoops, Integer)
        Dim i As Integer = 1
        Do While (i <= howManyTimes)
            ' Simulate work being done.
            Application.DoEvents()
            ' Wait one second to see if the user chooses to cancel.
            If haltProcessing.WaitOne(1000, False) Then
                Exit Do
            End If
            UpdateResults(resultsTextBoxBackground, "Background processing " _
                            & i & cr)
            i += 1
        Loop
        UpdateResults(resultsTextBoxBackground, "Background processing complete " & cr)
        HandleButtons(True)
    End Sub

    Private Sub beginButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles beginButton.Click
        clearResultsButton.Enabled = False
        ' Main thread processing prior to activating background processing.
        UpdateResults(resultsTextBoxMain, "Main processing beginning" & cr)
        Dim i As Integer = 1
        Do While (i <= foregroundLoops)
            UpdateResults(resultsTextBoxMain, "Main processing " & i & cr)
            DoNothing(1)
            Application.DoEvents()
            i += 1
        Loop
        HandleButtons(False)
        ' Call the background procedure on a new thread from the application's
        ' thread pool. Using the thread pool makes handling of the thread far
        ' easier than if you instantiated a thread of your own.
        Dim async As WaitCallback = New WaitCallback(AddressOf BackgroundProcedure)
        ThreadPool.QueueUserWorkItem(async, backgroundLoops)
        ' Main thread processing after the background thread has been activated.
        ' At this point, both threads are operating simultaneously, as you will
        ' note in the results text boxes. If you need your main thread to pause
        ' and wait for the background thread to complete, you will need to create
        ' your own thread, rather than using the thread pool.
        UpdateResults(resultsTextBoxMain, cr & "Further main processing beginning" & cr)

        i = 1
        Do While i <= foregroundLoops
            UpdateResults(resultsTextBoxMain, "Further main processing " & i & cr)
            DoNothing(1)
            Application.DoEvents()
            i += 1
        Loop
        UpdateResults(resultsTextBoxMain, cr & "Main processing complete" & cr)
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelButton.Click
        ' Set the AutoResetEvent, notifying the thread in question.
        haltProcessing.Set()
        HandleButtons(False)
    End Sub

    Private Sub clearResultsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearResultsButton.Click
        resultsTextBoxMain.Clear()
        resultsTextBoxBackground.Clear()
    End Sub

    Private Sub HandleButtons(ByVal enable As Boolean)
        ' If HandleButtons is called from a thread other than the main thread,
        ' InvokeRequired will be true. HandleButtons will then call itself via
        ' the handleButtonsDelegate delegate, using the BeginInvoke method, and
        ' passing an object array containing parameters.
        If InvokeRequired Then
            BeginInvoke(handleButtonsDelegate, New Object() {enable})
            Return
        End If
        beginButton.Enabled = enable
        clearResultsButton.Enabled = enable
        cancelButton.Enabled = Not enable
    End Sub

    Private Sub UpdateResults(ByVal tb As TextBox, ByVal message As String)
        ' UpdateResults uses the same principle as HandleButtons, above. If
        ' it is called from the main thread, InvokeRequired will be false,
        ' and processing will continue.
        If InvokeRequired Then
            BeginInvoke(updateResultsDelegate, New Object() {tb, message})
            Return
        End If
        tb.Text &= message
    End Sub

    ' A procedure for simulating processing.
    Private Sub DoNothing(ByVal howLong As Double)
        Dim stopTime As DateTime = DateTime.Now.AddSeconds(howLong)
        Application.DoEvents()

        While (DateTime.Now < stopTime)

        End While
    End Sub

    Private Sub foregroundLoopsComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles foregroundLoopsComboBox.SelectedIndexChanged
        foregroundLoops = Convert.ToInt32(foregroundLoopsComboBox.SelectedItem)
    End Sub

    Private Sub backgroundLoopsComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles backgroundLoopsComboBox.SelectedIndexChanged
        backgroundLoops = Convert.ToInt32(backgroundLoopsComboBox.SelectedItem)
    End Sub

#End Region

#Region " BackgroundWorker"

    ' The procedure to be executed on the background thread. It accepts a
    ' number, then doubles it repeatedly.
    '
    ' As this procedure progresses, it is able to update the user interface,
    ' because it is being passed a reference to the BackgroundWorker objcet,
    ' which has a ProgressChanged event procedure that runs on the main thread.
    '
    ' It also receives a reference to the DoWorkEventArgs object from the
    ' BackgroundWorker's DoWork event procedure, so it can be canceled at any
    ' time.
    Private Function BackgroundProcedureBGW(ByVal numberToCompute As Object, ByVal timesToCompute As Object, ByVal bgworker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Integer
        Dim answer As Integer = Convert.ToInt32(numberToCompute)
        Dim numLoops As Integer = Convert.ToInt32(timesToCompute)
        Dim i As Integer = 1
        Do While (i <= numLoops)
            ' Simulate work being done.
            Thread.Sleep(500)
            ' This is how the BackgroundWorker component lets you report
            ' progress to the main thread.
            Dim progress As Integer = Convert.ToInt32(CType(i, Single) _
                            / CType(numLoops, Single) * 100)
            bgworker.ReportProgress(progress)
            ' Double the number.
            answer = (answer * 2)
            ' Check to see if the user has cancelled the background task.
            If bgworker.CancellationPending Then
                e.Cancel = True
                Exit Do
            End If
            i += 1
        Loop
        Return answer
    End Function

    Private Sub beginButtonBGW_Click(ByVal sender As Object, ByVal e As EventArgs) Handles beginButtonBGW.Click
        resultsTextBoxBGW.Text = ("Processing started" _
                    & (cr & cr))
        ' Start the background process, passing it an object containing an array of numbers.
        backgroundWorker1.RunWorkerAsync(New Integer() {numberToDouble, timesToDouble})
        cancelButtonBGW.Enabled = True
    End Sub

    ' The BackgroundWorker object does its work in this procedure.
    ' Include here any code you want to run in the background.
    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles backgroundWorker1.DoWork
        ' Get a Reference to the BackgroundWorker object.
        Dim bgw As BackgroundWorker = CType(sender, BackgroundWorker)
        ' Invoke the procedure for doing the calculation needed.
        ' The result will be stored in e.Result, and will be available to the
        ' RunWorkerCompleted event procedure.
        '
        ' e.Argument contains the object parameter passed to this procedure.
        ' In this case the object contains an array of numbers. The object must
        ' be cast to an array, then the elements extracted, to be passed to
        ' the background procedure.
        Dim args() As Integer = CType(e.Argument, Integer())
        e.Result = BackgroundProcedureBGW(args(0), args(1), bgw, e)
    End Sub

    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles backgroundWorker1.ProgressChanged
        ' Update the user interface.
        resultsTextBoxBGW.Text &= e.ProgressPercentage & "% progress" & cr
        progressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then
            resultsTextBoxBGW.Text &= cr & "Processing aborted" & cr
        Else
            resultsTextBoxBGW.Text &= cr & "Processing completed" & cr
            exponentResultTextBox.Text = Convert.ToInt32(e.Result).ToString
        End If
    End Sub

    Private Sub cancelButtonBGW_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelButtonBGW.Click
        backgroundWorker1.CancelAsync()
        cancelButtonBGW.Enabled = False
    End Sub

    Private Sub clearResultsBGW_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearResultsBGW.Click
        resultsTextBoxBGW.Clear()
        exponentResultTextBox.Clear()
        progressBar1.Value = 0
    End Sub

    Private Sub numberForExponentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numberToDoubleComboBox.SelectedIndexChanged
        numberToDouble = Convert.ToInt32(numberToDoubleComboBox.SelectedItem)
    End Sub

    Private Sub timesToDoubleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles timesToDoubleComboBox.SelectedIndexChanged
        timesToDouble = Convert.ToInt32(timesToDoubleComboBox.SelectedItem)
    End Sub

#End Region

End Class

