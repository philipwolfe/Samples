Option Strict On
Imports System.Management
Public Class AboutForm
    Inherits System.Windows.Forms.Form
    Private SystemInfo As ManagementClass
    Private ClassObject As ManagementObject
    Protected Friend SetOptions As New EnumerationOptions
    Private RamValue As Double
    Protected Friend FirstRun As Boolean = True

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
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents TotalMemory As System.Windows.Forms.Label
    Friend WithEvents CPU_Info As System.Windows.Forms.Label
    Friend WithEvents AvailableMemory As System.Windows.Forms.Label
    Friend WithEvents WinVersion As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents TotalRAM As System.Windows.Forms.Label
    Friend WithEvents AvailRAM As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CPU_Speed As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SystemInfoGroup As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MailLink As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OK = New System.Windows.Forms.Button
        Me.lblTitle = New System.Windows.Forms.Label
        Me.AvailableMemory = New System.Windows.Forms.Label
        Me.TotalRAM = New System.Windows.Forms.Label
        Me.AvailRAM = New System.Windows.Forms.Label
        Me.TotalMemory = New System.Windows.Forms.Label
        Me.WinVersion = New System.Windows.Forms.Label
        Me.Version = New System.Windows.Forms.Label
        Me.CPU_Info = New System.Windows.Forms.Label
        Me.SystemInfoGroup = New System.Windows.Forms.GroupBox
        Me.CPU_Speed = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.MailLink = New System.Windows.Forms.LinkLabel
        Me.SystemInfoGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.SystemColors.Control
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.Location = New System.Drawing.Point(283, 242)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(74, 27)
        Me.OK.TabIndex = 2
        Me.OK.Text = "OK"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(42, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(117, 18)
        Me.lblTitle.TabIndex = 57
        Me.lblTitle.Text = "Traffic Viewer,"
        '
        'AvailableMemory
        '
        Me.AvailableMemory.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AvailableMemory.Location = New System.Drawing.Point(213, 103)
        Me.AvailableMemory.Name = "AvailableMemory"
        Me.AvailableMemory.Size = New System.Drawing.Size(90, 20)
        Me.AvailableMemory.TabIndex = 69
        '
        'TotalRAM
        '
        Me.TotalRAM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalRAM.Location = New System.Drawing.Point(75, 83)
        Me.TotalRAM.Name = "TotalRAM"
        Me.TotalRAM.Size = New System.Drawing.Size(133, 20)
        Me.TotalRAM.TabIndex = 70
        Me.TotalRAM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AvailRAM
        '
        Me.AvailRAM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AvailRAM.Location = New System.Drawing.Point(50, 103)
        Me.AvailRAM.Name = "AvailRAM"
        Me.AvailRAM.Size = New System.Drawing.Size(158, 20)
        Me.AvailRAM.TabIndex = 71
        Me.AvailRAM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TotalMemory
        '
        Me.TotalMemory.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalMemory.Location = New System.Drawing.Point(213, 83)
        Me.TotalMemory.Name = "TotalMemory"
        Me.TotalMemory.Size = New System.Drawing.Size(98, 20)
        Me.TotalMemory.TabIndex = 66
        '
        'WinVersion
        '
        Me.WinVersion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WinVersion.Location = New System.Drawing.Point(8, 17)
        Me.WinVersion.Name = "WinVersion"
        Me.WinVersion.Size = New System.Drawing.Size(338, 17)
        Me.WinVersion.TabIndex = 65
        '
        'Version
        '
        Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.15!, System.Drawing.FontStyle.Bold)
        Me.Version.Location = New System.Drawing.Point(155, 8)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(172, 18)
        Me.Version.TabIndex = 64
        Me.Version.Text = "Version "
        '
        'CPU_Info
        '
        Me.CPU_Info.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CPU_Info.Location = New System.Drawing.Point(7, 37)
        Me.CPU_Info.Name = "CPU_Info"
        Me.CPU_Info.Size = New System.Drawing.Size(340, 17)
        Me.CPU_Info.TabIndex = 72
        '
        'SystemInfoGroup
        '
        Me.SystemInfoGroup.Controls.Add(Me.CPU_Speed)
        Me.SystemInfoGroup.Controls.Add(Me.TotalRAM)
        Me.SystemInfoGroup.Controls.Add(Me.AvailRAM)
        Me.SystemInfoGroup.Controls.Add(Me.CPU_Info)
        Me.SystemInfoGroup.Controls.Add(Me.TotalMemory)
        Me.SystemInfoGroup.Controls.Add(Me.AvailableMemory)
        Me.SystemInfoGroup.Controls.Add(Me.WinVersion)
        Me.SystemInfoGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemInfoGroup.Location = New System.Drawing.Point(9, 101)
        Me.SystemInfoGroup.Name = "SystemInfoGroup"
        Me.SystemInfoGroup.Size = New System.Drawing.Size(350, 130)
        Me.SystemInfoGroup.TabIndex = 74
        Me.SystemInfoGroup.TabStop = False
        Me.SystemInfoGroup.Text = "System Info."
        '
        'CPU_Speed
        '
        Me.CPU_Speed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CPU_Speed.Location = New System.Drawing.Point(5, 57)
        Me.CPU_Speed.Name = "CPU_Speed"
        Me.CPU_Speed.Size = New System.Drawing.Size(340, 17)
        Me.CPU_Speed.TabIndex = 73
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(276, 16)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "(Microsoft .NET Framework platform dependent)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(316, 33)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = """The most complete collection of Washington traffic cameras available."""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 237)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(250, 25)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "For technical support, contact: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MailLink
        '
        Me.MailLink.Location = New System.Drawing.Point(92, 257)
        Me.MailLink.Name = "MailLink"
        Me.MailLink.Size = New System.Drawing.Size(142, 21)
        Me.MailLink.TabIndex = 78
        Me.MailLink.TabStop = True
        Me.MailLink.Text = "TrafficViewer@yahoo.com"
        '
        'AboutForm
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(371, 278)
        Me.Controls.Add(Me.MailLink)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SystemInfoGroup)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label3)
        Me.DockPadding.Bottom = 80
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About Traffic Viewer"
        Me.SystemInfoGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AboutForm_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            GetSystemInfo()
        End If
    End Sub

    Protected Friend Sub GetSystemInfo()
        If SystemInfo Is Nothing Then
            'Bind SystemInfo to WMI Operating System path 
            SystemInfo = New ManagementClass("Win32_OperatingSystem")
        End If
        If Not FirstRun Then
            'get free physical memory and convert to megabytes
            For Each ClassObject In SystemInfo.GetInstances(SetOptions)
                RamValue = Convert.ToDouble(ClassObject("FreePhysicalMemory").ToString) / 1024
                AvailRAM.Text = "Physical memory available:"
                AvailableMemory.Text = RamValue.ToString("########.##") & " MB"
            Next
        Else
            FirstRun = False
            CPU_Info.Text = MainViewerForm.MainForm.CPU_Info
            CPU_Speed.Text = MainViewerForm.MainForm.CPU_Speed
            Version.Text &= Application.ProductVersion
            'set class and get instances
            For Each ClassObject In SystemInfo.GetInstances(SetOptions)
                'get windows version
                WinVersion.Text = "  Operating System:" & "  " & ClassObject.Properties.Item("Caption").Value.ToString.Trim
                ' get total visible memory and convert to megabytes
                RamValue = Convert.ToDouble(ClassObject.Properties.Item("TotalVisibleMemorySize").Value) / 1024
                TotalRAM.Text = "Total physical memory:"
                TotalMemory.Text = RamValue.ToString("########.##") & " MB"
                ' get free physical memory and convert to megabytes
                RamValue = Convert.ToDouble(ClassObject.Properties.Item("FreePhysicalMemory").Value) / 1024
                AvailRAM.Text = "Physical memory available:"
                AvailableMemory.Text = RamValue.ToString("########.##") & " MB"
            Next
        End If
        Me.Invalidate()
        ClassObject.Dispose()
        SystemInfo.Dispose()
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Hide()
    End Sub

    Private Sub AboutForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'keep form opened
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub MailLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles MailLink.LinkClicked
        Try
            System.Diagnostics.Process.Start("mailto:" & MailLink.Text & "&subject=TrafficViewer Feedback")
        Catch ex As IO.IOException
            MessageBox.Show(ex.Message)
        Catch ex As Security.SecurityException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
