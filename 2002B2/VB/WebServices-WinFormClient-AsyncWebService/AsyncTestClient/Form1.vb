Imports System.Runtime.Remoting.Messaging

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub
    Friend WithEvents cmbCallWebService As System.Windows.Forms.Button
    Friend WithEvents cmdWebServAsync As System.Windows.Forms.Button
    Friend WithEvents txtDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdWebServAsync = New System.Windows.Forms.Button()
        Me.txtDelay = New System.Windows.Forms.TextBox()
        Me.cmbCallWebService = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdWebServAsync
        '
        Me.cmdWebServAsync.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdWebServAsync.Location = New System.Drawing.Point(136, 80)
        Me.cmdWebServAsync.Name = "cmdWebServAsync"
        Me.cmdWebServAsync.Size = New System.Drawing.Size(144, 24)
        Me.cmdWebServAsync.TabIndex = 0
        Me.cmdWebServAsync.Text = "Call Web Service Async"
        '
        'txtDelay
        '
        Me.txtDelay.Location = New System.Drawing.Point(136, 8)
        Me.txtDelay.Name = "txtDelay"
        Me.txtDelay.Size = New System.Drawing.Size(48, 20)
        Me.txtDelay.TabIndex = 1
        Me.txtDelay.Text = "1000"
        '
        'cmbCallWebService
        '
        Me.cmbCallWebService.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCallWebService.Location = New System.Drawing.Point(136, 40)
        Me.cmbCallWebService.Name = "cmbCallWebService"
        Me.cmbCallWebService.Size = New System.Drawing.Size(144, 24)
        Me.cmbCallWebService.TabIndex = 0
        Me.cmbCallWebService.Text = "Call Web Service Sync"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 56)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Specify milliseconds delay before web service completes:"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(328, 133)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.txtDelay, Me.cmdWebServAsync, Me.cmbCallWebService})
        Me.Name = "Form1"
        Me.Text = "Web Service Client"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmbCallWebService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCallWebService.Click

        'Create instance of web service proxy
        Dim WebServ As New localhost.Service1()

        'Call the web service synchronously and display the results in a message box.
        MessageBox.Show("Return Value: " & WebServ.DoSomeWork(Int32.Parse(txtDelay.Text)), "Synchronous Call")

    End Sub

    Public Delegate Function myAsyncDelegate(ByVal intReturn As Integer) As Integer

    Private Sub cmdWebServAsync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWebServAsync.Click

        'Create instance of web service proxy

        'Call the method "DoSomeWork" asyncronously.  The first parameter is the value
        'for the actual method call parameter and the second parameter is the address of the
        'function to be called when the method completes execution.
        'WebServ.BeginDoSomeWork(Int32.Parse(txtDelay.Text), New AsyncCallback(AddressOf Me.MyCallBack), Nothing)

        'Create instance of web service proxy
        Dim WebServ As New localhost.Service1()
        Dim AsyncCallback As New AsyncCallback(AddressOf Me.MyCallBack)
        Dim AsyncDelegate As New myAsyncDelegate(AddressOf WebServ.DoSomeWork)
        Dim AsyncResult As IAsyncResult

        'Call the web service asynchronously and display the results in a message box.
        AsyncResult = AsyncDelegate.BeginInvoke(Int32.Parse(txtDelay.Text), AsyncCallback, Nothing)
        MessageBox.Show("Async call started", "Asynchronous Call")

    End Sub

    Private Shared Sub MyCallBack(ByVal ar As System.IAsyncResult)

        Dim AsyncDelegate As myAsyncDelegate
        Dim AsyncResult As AsyncResult
        Dim Result As Integer = 0
        Dim ReturnValue As Integer

        AsyncResult = CType(ar, AsyncResult)
        AsyncDelegate = AsyncResult.AsyncDelegate()

        'End async call
        ReturnValue = AsyncDelegate.EndInvoke(Result, AsyncResult)

        MessageBox.Show("Asynchronous response has returned with the value: " & ReturnValue.ToString)

    End Sub

End Class
