Public Class frmTaskManager
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents btnModules As System.Windows.Forms.Button
    Friend WithEvents txtTotalProcessorTime As System.Windows.Forms.TextBox
    Friend WithEvents txtStartTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMinWorkingSet As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxWorkingSet As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfThreads As System.Windows.Forms.TextBox
    Friend WithEvents txtPriority As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents cboCurrentProcesses As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnModules = New System.Windows.Forms.Button()
        Me.txtTotalProcessorTime = New System.Windows.Forms.TextBox()
        Me.txtStartTime = New System.Windows.Forms.TextBox()
        Me.txtMinWorkingSet = New System.Windows.Forms.TextBox()
        Me.txtMaxWorkingSet = New System.Windows.Forms.TextBox()
        Me.txtNumberOfThreads = New System.Windows.Forms.TextBox()
        Me.txtPriority = New System.Windows.Forms.TextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cboCurrentProcesses = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnModules
        '
        Me.btnModules.Location = New System.Drawing.Point(224, 272)
        Me.btnModules.Name = "btnModules"
        Me.btnModules.TabIndex = 14
        Me.btnModules.Text = "Modules"
        '
        'txtTotalProcessorTime
        '
        Me.txtTotalProcessorTime.Location = New System.Drawing.Point(120, 224)
        Me.txtTotalProcessorTime.Name = "txtTotalProcessorTime"
        Me.txtTotalProcessorTime.Size = New System.Drawing.Size(184, 20)
        Me.txtTotalProcessorTime.TabIndex = 13
        Me.txtTotalProcessorTime.Text = ""
        Me.txtTotalProcessorTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStartTime
        '
        Me.txtStartTime.Location = New System.Drawing.Point(120, 192)
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.Size = New System.Drawing.Size(184, 20)
        Me.txtStartTime.TabIndex = 11
        Me.txtStartTime.Text = ""
        Me.txtStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinWorkingSet
        '
        Me.txtMinWorkingSet.Location = New System.Drawing.Point(120, 160)
        Me.txtMinWorkingSet.Name = "txtMinWorkingSet"
        Me.txtMinWorkingSet.Size = New System.Drawing.Size(184, 20)
        Me.txtMinWorkingSet.TabIndex = 9
        Me.txtMinWorkingSet.Text = ""
        Me.txtMinWorkingSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMaxWorkingSet
        '
        Me.txtMaxWorkingSet.Location = New System.Drawing.Point(120, 128)
        Me.txtMaxWorkingSet.Name = "txtMaxWorkingSet"
        Me.txtMaxWorkingSet.Size = New System.Drawing.Size(184, 20)
        Me.txtMaxWorkingSet.TabIndex = 7
        Me.txtMaxWorkingSet.Text = ""
        Me.txtMaxWorkingSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberOfThreads
        '
        Me.txtNumberOfThreads.Location = New System.Drawing.Point(120, 96)
        Me.txtNumberOfThreads.Name = "txtNumberOfThreads"
        Me.txtNumberOfThreads.Size = New System.Drawing.Size(184, 20)
        Me.txtNumberOfThreads.TabIndex = 5
        Me.txtNumberOfThreads.Text = ""
        Me.txtNumberOfThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPriority
        '
        Me.txtPriority.Location = New System.Drawing.Point(120, 64)
        Me.txtPriority.Name = "txtPriority"
        Me.txtPriority.Size = New System.Drawing.Size(184, 20)
        Me.txtPriority.TabIndex = 3
        Me.txtPriority.Text = ""
        Me.txtPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(8, 224)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(104, 32)
        Me.label7.TabIndex = 12
        Me.label7.Text = "Total Processor Time"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(8, 192)
        Me.label6.Name = "label6"
        Me.label6.TabIndex = 10
        Me.label6.Text = "Start Time"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(8, 160)
        Me.label5.Name = "label5"
        Me.label5.TabIndex = 8
        Me.label5.Text = "Min Working Set"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(8, 128)
        Me.label4.Name = "label4"
        Me.label4.TabIndex = 6
        Me.label4.Text = "Max Working Set"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(8, 96)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(104, 23)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Number of Threads"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(8, 64)
        Me.label2.Name = "label2"
        Me.label2.TabIndex = 2
        Me.label2.Text = "Priority"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(104, 23)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Current Processes:"
        '
        'cboCurrentProcesses
        '
        Me.cboCurrentProcesses.Location = New System.Drawing.Point(120, 16)
        Me.cboCurrentProcesses.Name = "cboCurrentProcesses"
        Me.cboCurrentProcesses.Size = New System.Drawing.Size(192, 21)
        Me.cboCurrentProcesses.TabIndex = 1
        '
        'frmTaskManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 318)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnModules, Me.txtTotalProcessorTime, Me.txtStartTime, Me.txtMinWorkingSet, Me.txtMaxWorkingSet, Me.txtNumberOfThreads, Me.txtPriority, Me.label7, Me.label6, Me.label5, Me.label4, Me.label3, Me.label2, Me.label1, Me.cboCurrentProcesses})
        Me.Name = "frmTaskManager"
        Me.Text = "Simple Process Manager"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' List of processes currently running
    Dim ProcessList As New ArrayList()

    Private Sub btnModules_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModules.Click

        ' Get the item that is currently selected in the combo box.  Then all of the modules
        ' for that process are displayed to the user via the richTextBox on frmModules.
        Dim ProcID As Integer

        Dim ProcessListIndex As Int32 = cboCurrentProcesses.SelectedIndex
        ProcID = CInt(ProcessList(ProcessListIndex))
        Dim frmMod As New frmModules()
        frmMod.ProcessID = ProcID
        frmMod.Show()
    End Sub

    Private Sub frmTaskManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Loop through all the running process, and add them to the combo
            ' box so that the user can select a process and see the information
            ' for that process.
            Dim ProcessInfo As Process
            For Each ProcessInfo In Process.GetProcesses()
                'Devenv is the Visual Studio Development Environment.  You will see one entry 
                'for each instance of the development environment that you have open.
                If ProcessInfo.ProcessName = "EXPLORER" Or ProcessInfo.ProcessName = "devenv" Then
                    cboCurrentProcesses.Items.Add(ProcessInfo.ProcessName)
                    ProcessList.Add(ProcessInfo.Id)
                End If
            Next
            cboCurrentProcesses.SelectedIndex = 0
            If btnModules.Enabled = False Then
                btnModules.Enabled = True
            End If
        Catch exc As Exception
            MessageBox.Show("Unable to load process names:" & vbCrLf & exc.Message & vbCrLf & "Please choose another process.", _
                "frmTaskManager", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            btnModules.Enabled = False
        End Try
    End Sub

    Private Sub cboCurrentProcesses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCurrentProcesses.SelectedIndexChanged
        Dim ProcessID As Int32

        Try

            ' Retrieve the information for the process based on the item that the
            ' user has selected in the combo box.
            Dim ProcessListIndex As Int32 = cboCurrentProcesses.SelectedIndex
            ProcessID = CInt(ProcessList(ProcessListIndex))
            Dim ProcessInfo As Process = _
                Process.GetProcessById(ProcessID)

            'Information is displayed about the currently selected process.
            txtPriority.Text = ProcessInfo.BasePriority.ToString()
            txtNumberOfThreads.Text = ProcessInfo.Threads.Count.ToString()
            txtMaxWorkingSet.Text = ProcessInfo.MaxWorkingSet.ToString()
            txtMinWorkingSet.Text = ProcessInfo.MinWorkingSet.ToString()
            txtStartTime.Text = ProcessInfo.StartTime.ToLongTimeString()
            txtTotalProcessorTime.Text = ProcessInfo.TotalProcessorTime.ToString()
        Catch exc As Exception
            MessageBox.Show( _
                "Unable to retrieve information for ProcessID : " & ProcessID & vbCrLf & exc.Message, _
                "frmTaskManager", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub
End Class
