'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

    'Will be used in the Interface-based callback
    Implements ICallback

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
	Friend WithEvents cmdBuiltInCallback As System.Windows.Forms.Button
	Friend WithEvents cmdAsyncDelegateCallback As System.Windows.Forms.Button
    Friend WithEvents cmdDelegateCallback As System.Windows.Forms.Button
    Friend WithEvents cmdInterfaceCallback As System.Windows.Forms.Button
	Friend WithEvents grpOptions As System.Windows.Forms.GroupBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.grpOptions = New System.Windows.Forms.GroupBox()
		Me.cmdBuiltInCallback = New System.Windows.Forms.Button()
		Me.cmdAsyncDelegateCallback = New System.Windows.Forms.Button()
		Me.cmdDelegateCallback = New System.Windows.Forms.Button()
		Me.cmdInterfaceCallback = New System.Windows.Forms.Button()
		Me.grpOptions.SuspendLayout()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
		Me.mnuFile.Text = "&File"
		'
		'mnuExit
		'
		Me.mnuExit.Index = 0
		Me.mnuExit.Text = "E&xit"
		'
		'mnuHelp
		'
		Me.mnuHelp.Index = 1
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
		Me.mnuHelp.Text = "&Help"
		'
		'mnuAbout
		'
		Me.mnuAbout.Index = 0
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		'
		'grpOptions
		'
		Me.grpOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdBuiltInCallback, Me.cmdAsyncDelegateCallback, Me.cmdDelegateCallback, Me.cmdInterfaceCallback})
		Me.grpOptions.Location = New System.Drawing.Point(16, 16)
		Me.grpOptions.Name = "grpOptions"
		Me.grpOptions.Size = New System.Drawing.Size(232, 152)
		Me.grpOptions.TabIndex = 8
		Me.grpOptions.TabStop = False
		'
		'cmdBuiltInCallback
		'
		Me.cmdBuiltInCallback.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdBuiltInCallback.Location = New System.Drawing.Point(16, 113)
		Me.cmdBuiltInCallback.Name = "cmdBuiltInCallback"
		Me.cmdBuiltInCallback.Size = New System.Drawing.Size(200, 23)
		Me.cmdBuiltInCallback.TabIndex = 3
		Me.cmdBuiltInCallback.Text = "&Built-in async callback Delegate"
		'
		'cmdAsyncDelegateCallback
		'
		Me.cmdAsyncDelegateCallback.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdAsyncDelegateCallback.Location = New System.Drawing.Point(16, 81)
		Me.cmdAsyncDelegateCallback.Name = "cmdAsyncDelegateCallback"
		Me.cmdAsyncDelegateCallback.Size = New System.Drawing.Size(200, 23)
		Me.cmdAsyncDelegateCallback.TabIndex = 2
		Me.cmdAsyncDelegateCallback.Text = "&Async callback using a Delegate"
		'
		'cmdDelegateCallback
		'
		Me.cmdDelegateCallback.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdDelegateCallback.Location = New System.Drawing.Point(16, 49)
		Me.cmdDelegateCallback.Name = "cmdDelegateCallback"
		Me.cmdDelegateCallback.Size = New System.Drawing.Size(200, 23)
		Me.cmdDelegateCallback.TabIndex = 1
		Me.cmdDelegateCallback.Text = "Callback using a &Delegate"
		'
		'cmdInterfaceCallback
		'
		Me.cmdInterfaceCallback.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdInterfaceCallback.Location = New System.Drawing.Point(16, 17)
		Me.cmdInterfaceCallback.Name = "cmdInterfaceCallback"
		Me.cmdInterfaceCallback.Size = New System.Drawing.Size(200, 23)
		Me.cmdInterfaceCallback.TabIndex = 0
		Me.cmdInterfaceCallback.Text = "Callback using an &Interface"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(266, 179)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpOptions})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.grpOptions.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Close the current form
		Me.Close()
	End Sub
#End Region

    Public Sub CallbackMethod() Implements ICallback.CallbackMethod
        'This method is called from Class1 after the form is registered
        'with the instance. 

		MessageBox.Show("In the callback method", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub cmdInterfaceCallback_Click(ByVal sender As System.Object, _
                                       ByVal e As System.EventArgs) _
                                       Handles cmdInterfaceCallback.Click
        'This method calls into a method of a Class1 instance, which in turn 
        'calls back into the client via ICallback.

        Dim refClass1 As New Class1()

        'Register the client, passing a reference to itself
        refClass1.RegisterInterFaceForCallback(Me)

        'Call the method which will in turn call back into the client
        refClass1.UseInterfaceCallback()

        'Unregister the client
        refClass1.UnRegisterInterfaceForCallback()

    End Sub

    Private Sub cmdDelegateCallback_Click(ByVal sender As System.Object, _
                                      ByVal e As System.EventArgs) _
                                      Handles cmdDelegateCallback.Click
        'This method calls into a method of a Class1 instance, which in turn 
        'calls back into the client via a delegate.

        Dim refClass1 As New Class1()

        'Create an instance of a delegate to represent the callback method
        Dim d As New Delegate1(AddressOf Me.CallbackMethod)

        'Register the client, passing a reference to the delegate instance
        refClass1.RegisterDelegateForCallback(d)

        'Call the method which will in turn call back into the client
        refClass1.UseDelegateCallback()

        'Unregister the client
        refClass1.UnRegisterDelegateForCallback()

    End Sub

    Private Sub cmdAsyncDelegateCallback_Click(ByVal sender As System.Object, _
                                           ByVal e As System.EventArgs) _
                                           Handles cmdAsyncDelegateCallback.Click
        'This method calls into a method of a Class1 instance, which in turn 
        'calls back asynchronously into the client via a delegate. Note that 
        'the registration calls are identical, whether the callback will be
        'asynchronous or not.

        Dim refClass1 As New Class1()

        'Create an instance of a delegate to represent the callback method
        Dim d As New Delegate1(AddressOf Me.CallbackMethod)

        'Register the client, passing a reference to the delegate instance
        refClass1.RegisterDelegateForCallback(d)

        'Call the method which will in turn call back asynchronously into the client
        refClass1.UseAsyncDelegateCallback()

        'Unregister the client
        refClass1.UnRegisterDelegateForCallback()

    End Sub

    Private Sub cmdBuiltInCallback_Click(ByVal sender As System.Object, _
                                     ByVal e As System.EventArgs) _
                                     Handles cmdBuiltInCallback.Click
        'Delegates have a built-in mechanism to call back into the client. The 
        'method to be called back into must have a specific signature, however.
        'This method will use the built-in callback of an asynchronous invocation
        'on a delegate, and will call into the BuiltInCallback method below this one.
        'Note that no user registration is needed.

        Dim refClass1 As New Class1()

        'Create an instance of a delegate to represent the callback method
        Dim d As New Delegate1(AddressOf refClass1.UseBuiltInDelegateCallback)

        'Now create a second delegate to pass to the callee. The callee will use
        'This second delegate to call back into the client. AsyncCallback is 
        'defined in the CLR specifically for calling back after an asynchronous
        'invocation of a delegate.
        Dim ac As New AsyncCallback(AddressOf Me.BuiltInCallback)

        'Invoke the class one method. Note that this invocation is asynchronous,
        'and will be carried out on a worker thread from the CLR thread pool. The
        'resulting callback will also be performed by the worker thread. The
        'callback delegate is passed in as an argument, so no explicit registration
        'is needed.
        d.BeginInvoke(ac, Nothing)

    End Sub

    Private Sub BuiltInCallback(ByVal ia As IAsyncResult)
        'This method is called using the AsyncCallback delegate that is passed into
        'the BeginInvoke method in the BuiltInCallback routine above. Note that the 
        'signature includes an IAsyncResult, which associates the callback with a 
        'specific asynchronous invocation.

		MessageBox.Show("In the BuiltInCallback routine", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class