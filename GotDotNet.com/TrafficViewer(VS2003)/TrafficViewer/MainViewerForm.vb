Option Strict On
Public Class MainViewerForm
    Inherits System.Windows.Forms.Form
    Private WebAddress As New System.Text.StringBuilder
    Private Index, CameraIndex, Interval As Integer
    Protected Friend SRLabel As Label
    Private SRLabels() As Label
    Private TopOfLabels(16) As Integer
    Private NewImageSelected, Connected, LoadingImage As Boolean
    Private AutoResize As Boolean = True
    Friend MapRegion As String = "NW"
    Private LoadThread As Threading.Thread
    Protected Friend CheckThread As Threading.Thread
    Private ErrorImage As IO.MemoryStream
    Private Client As New Net.WebClient
    Private Reader As IO.StreamReader
    Private DataStream As IO.Stream
    Private Writer As IO.StreamWriter
    Private SettingsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\Settings.dat"
    Friend Shared ThisExe As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly
    Friend Shared ThisExeName As String = ThisExe.GetName.Name
    Private ThisExePath As String = Windows.Forms.Application.ExecutablePath
    Private Tools As New ApplicationTools
    Private Request As Net.WebRequest
    Protected Friend Shared MainForm As MainViewerForm
    Private AboutForm As AboutForm
    Private SeattleForm As Seattle
    Private BellevueForm As Bellevue
    Private KingCountyForm As KingCounty
    Private Map As New RegionMap
    Private LoadedImage As Drawing.Image
    Private Delegate Sub SetImage()
    Private SetNewImage As New SetImage(AddressOf Set_Image)
    Private Delegate Sub ShowLabel()
    Private ShowLabelDelegate As New ShowLabel(AddressOf ShowNewVersionAvailable)
    Protected Friend CPU_Info As String
    Protected Friend CPU_Speed As String
    Private r As Rect
    Const WM_SIZING As Long = &H214
    Const WMSZ_LEFT As Integer = 1
    Const WMSZ_RIGHT As Integer = 2
    Const WMSZ_TOP As Integer = 3
    Const WMSZ_TOPLEFT As Integer = 4
    Const WMSZ_TOPRIGHT As Integer = 5
    Const WMSZ_BOTTOM As Integer = 6
    Const WMSZ_BOTTOMLEFT As Integer = 7
    Const WMSZ_BOTTOMRIGHT As Integer = 8

    Public Structure Rect
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'Enable visual styles for systems running Windows XP.
        If Environment.OSVersion.Platform = PlatformID.Win32NT AndAlso Environment.OSVersion.Version.Major >= 5 _
        AndAlso Environment.OSVersion.Version.Minor > 0 Then
            If OSFeature.Feature.IsPresent(OSFeature.Themes) Then
                Application.EnableVisualStyles()
            End If
            Application.DoEvents()
        End If
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
    Friend WithEvents CameraImage As System.Windows.Forms.PictureBox
    Friend WithEvents CameraList As System.Windows.Forms.ListBox
    Friend WithEvents AutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents ReloadButton As System.Windows.Forms.Button
    Friend WithEvents VScrollRoutes As System.Windows.Forms.VScrollBar
    Friend WithEvents ChangeRegion As System.Windows.Forms.PictureBox
    Friend WithEvents NW As System.Windows.Forms.Label
    Friend WithEvents NE As System.Windows.Forms.Label
    Friend WithEvents SW As System.Windows.Forms.Label
    Friend WithEvents SE As System.Windows.Forms.Label
    Friend WithEvents ShowMapOption As System.Windows.Forms.CheckBox
    Friend WithEvents MenuMain As System.Windows.Forms.MainMenu
    Friend WithEvents File As System.Windows.Forms.MenuItem
    Friend WithEvents ExitMenu As System.Windows.Forms.MenuItem
    Friend WithEvents Help As System.Windows.Forms.MenuItem
    Friend WithEvents About As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents LabelsBackColor As System.Windows.Forms.MenuItem
    Friend WithEvents FloralWhiteColor As System.Windows.Forms.MenuItem
    Friend WithEvents SystemInfoColor As System.Windows.Forms.MenuItem
    Friend WithEvents WindowForeColor As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents DownloadUpdate As System.Windows.Forms.MenuItem
    Friend WithEvents ReloadTimer As System.Windows.Forms.Timer
    Friend WithEvents ImageMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents Save As System.Windows.Forms.MenuItem
    Friend WithEvents CopyPicture As System.Windows.Forms.MenuItem
    Friend WithEvents CopyLink As System.Windows.Forms.MenuItem
    Friend WithEvents SRLabel_0 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_3 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_6 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_7 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_4 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_1 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_5 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_2 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_8 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_9 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_12 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_10 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_13 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_11 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_14 As System.Windows.Forms.Label
    Friend WithEvents SRBackground As System.Windows.Forms.Panel
    Friend WithEvents SRLabel_15 As System.Windows.Forms.Label
    Friend WithEvents SRLabel_16 As System.Windows.Forms.Label
    Friend WithEvents King As System.Windows.Forms.LinkLabel
    Friend WithEvents Seattle As System.Windows.Forms.LinkLabel
    Friend WithEvents Bellevue As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CopyPictureMain As System.Windows.Forms.MenuItem
    Friend WithEvents SaveMain As System.Windows.Forms.MenuItem
    Friend WithEvents CopyLinkMain As System.Windows.Forms.MenuItem
    ' Friend WithEvents NewVersionAvailable As System.Windows.Forms.Label
    Friend WithEvents HideRegion As System.Windows.Forms.Timer
    Friend WithEvents OtherMaps As System.Windows.Forms.GroupBox
    Friend WithEvents NewVersionAvailable As System.Windows.Forms.Label
    Friend WithEvents MainStatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents Caption As System.Windows.Forms.StatusBarPanel
    Friend WithEvents AutoSize As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents SendPicture As System.Windows.Forms.MenuItem
    Friend WithEvents HelpTopics As System.Windows.Forms.MenuItem
    Friend WithEvents Tacoma As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainViewerForm))
        Me.CameraImage = New System.Windows.Forms.PictureBox
        Me.ImageMenu = New System.Windows.Forms.ContextMenu
        Me.CopyPicture = New System.Windows.Forms.MenuItem
        Me.Save = New System.Windows.Forms.MenuItem
        Me.CopyLink = New System.Windows.Forms.MenuItem
        Me.CameraList = New System.Windows.Forms.ListBox
        Me.AutoRefresh = New System.Windows.Forms.CheckBox
        Me.ReloadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ReloadButton = New System.Windows.Forms.Button
        Me.SRLabel_0 = New System.Windows.Forms.Label
        Me.SRLabel_3 = New System.Windows.Forms.Label
        Me.SRLabel_6 = New System.Windows.Forms.Label
        Me.SRLabel_7 = New System.Windows.Forms.Label
        Me.SRLabel_4 = New System.Windows.Forms.Label
        Me.SRLabel_1 = New System.Windows.Forms.Label
        Me.SRLabel_5 = New System.Windows.Forms.Label
        Me.SRLabel_2 = New System.Windows.Forms.Label
        Me.VScrollRoutes = New System.Windows.Forms.VScrollBar
        Me.SRLabel_8 = New System.Windows.Forms.Label
        Me.SRLabel_9 = New System.Windows.Forms.Label
        Me.SRLabel_12 = New System.Windows.Forms.Label
        Me.SRLabel_10 = New System.Windows.Forms.Label
        Me.SRLabel_13 = New System.Windows.Forms.Label
        Me.SRLabel_11 = New System.Windows.Forms.Label
        Me.SRLabel_14 = New System.Windows.Forms.Label
        Me.ChangeRegion = New System.Windows.Forms.PictureBox
        Me.NW = New System.Windows.Forms.Label
        Me.NE = New System.Windows.Forms.Label
        Me.SW = New System.Windows.Forms.Label
        Me.SE = New System.Windows.Forms.Label
        Me.ShowMapOption = New System.Windows.Forms.CheckBox
        Me.MenuMain = New System.Windows.Forms.MainMenu
        Me.File = New System.Windows.Forms.MenuItem
        Me.SaveMain = New System.Windows.Forms.MenuItem
        Me.CopyPictureMain = New System.Windows.Forms.MenuItem
        Me.CopyLinkMain = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.SendPicture = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.ExitMenu = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.LabelsBackColor = New System.Windows.Forms.MenuItem
        Me.FloralWhiteColor = New System.Windows.Forms.MenuItem
        Me.SystemInfoColor = New System.Windows.Forms.MenuItem
        Me.WindowForeColor = New System.Windows.Forms.MenuItem
        Me.AutoSize = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.DownloadUpdate = New System.Windows.Forms.MenuItem
        Me.Help = New System.Windows.Forms.MenuItem
        Me.HelpTopics = New System.Windows.Forms.MenuItem
        Me.About = New System.Windows.Forms.MenuItem
        Me.HideRegion = New System.Windows.Forms.Timer(Me.components)
        Me.SRBackground = New System.Windows.Forms.Panel
        Me.SRLabel_15 = New System.Windows.Forms.Label
        Me.SRLabel_16 = New System.Windows.Forms.Label
        Me.King = New System.Windows.Forms.LinkLabel
        Me.Seattle = New System.Windows.Forms.LinkLabel
        Me.Bellevue = New System.Windows.Forms.LinkLabel
        Me.OtherMaps = New System.Windows.Forms.GroupBox
        Me.Tacoma = New System.Windows.Forms.LinkLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.NewVersionAvailable = New System.Windows.Forms.Label
        Me.MainStatusBar = New System.Windows.Forms.StatusBar
        Me.Caption = New System.Windows.Forms.StatusBarPanel
        Me.SRBackground.SuspendLayout()
        Me.OtherMaps.SuspendLayout()
        CType(Me.Caption, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CameraImage
        '
        Me.CameraImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CameraImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CameraImage.ContextMenu = Me.ImageMenu
        Me.CameraImage.Location = New System.Drawing.Point(1, 59)
        Me.CameraImage.Name = "CameraImage"
        Me.CameraImage.Size = New System.Drawing.Size(482, 400)
        Me.CameraImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CameraImage.TabIndex = 0
        Me.CameraImage.TabStop = False
        '
        'ImageMenu
        '
        Me.ImageMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.CopyPicture, Me.Save, Me.CopyLink})
        '
        'CopyPicture
        '
        Me.CopyPicture.Index = 0
        Me.CopyPicture.Text = "Copy Picture"
        '
        'Save
        '
        Me.Save.Index = 1
        Me.Save.Text = "Save Picture As..."
        '
        'CopyLink
        '
        Me.CopyLink.Index = 2
        Me.CopyLink.Text = "Copy Link"
        '
        'CameraList
        '
        Me.CameraList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CameraList.BackColor = System.Drawing.SystemColors.Window
        Me.CameraList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CameraList.IntegralHeight = False
        Me.CameraList.Location = New System.Drawing.Point(487, 155)
        Me.CameraList.Name = "CameraList"
        Me.CameraList.Size = New System.Drawing.Size(250, 304)
        Me.CameraList.TabIndex = 1
        '
        'AutoRefresh
        '
        Me.AutoRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AutoRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoRefresh.Location = New System.Drawing.Point(495, 130)
        Me.AutoRefresh.Name = "AutoRefresh"
        Me.AutoRefresh.Size = New System.Drawing.Size(161, 16)
        Me.AutoRefresh.TabIndex = 3
        Me.AutoRefresh.Text = "Reload image every minute"
        '
        'ReloadTimer
        '
        Me.ReloadTimer.Enabled = True
        Me.ReloadTimer.Interval = 1200
        '
        'ReloadButton
        '
        Me.ReloadButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReloadButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ReloadButton.Location = New System.Drawing.Point(651, 126)
        Me.ReloadButton.Name = "ReloadButton"
        Me.ReloadButton.Size = New System.Drawing.Size(80, 24)
        Me.ReloadButton.TabIndex = 6
        Me.ReloadButton.Text = "Reload"
        '
        'SRLabel_0
        '
        Me.SRLabel_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_0.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_0.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_0.Location = New System.Drawing.Point(4, 5)
        Me.SRLabel_0.Name = "SRLabel_0"
        Me.SRLabel_0.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_0.TabIndex = 100
        Me.SRLabel_0.Tag = ""
        Me.SRLabel_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_3
        '
        Me.SRLabel_3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_3.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_3.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_3.Location = New System.Drawing.Point(4, 30)
        Me.SRLabel_3.Name = "SRLabel_3"
        Me.SRLabel_3.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_3.TabIndex = 103
        Me.SRLabel_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_6
        '
        Me.SRLabel_6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_6.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_6.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_6.Location = New System.Drawing.Point(4, 55)
        Me.SRLabel_6.Name = "SRLabel_6"
        Me.SRLabel_6.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_6.TabIndex = 106
        Me.SRLabel_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_7
        '
        Me.SRLabel_7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_7.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_7.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_7.Location = New System.Drawing.Point(80, 55)
        Me.SRLabel_7.Name = "SRLabel_7"
        Me.SRLabel_7.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_7.TabIndex = 107
        Me.SRLabel_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_4
        '
        Me.SRLabel_4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_4.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_4.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_4.Location = New System.Drawing.Point(80, 30)
        Me.SRLabel_4.Name = "SRLabel_4"
        Me.SRLabel_4.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_4.TabIndex = 104
        Me.SRLabel_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_1
        '
        Me.SRLabel_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_1.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_1.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_1.Location = New System.Drawing.Point(80, 5)
        Me.SRLabel_1.Name = "SRLabel_1"
        Me.SRLabel_1.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_1.TabIndex = 101
        Me.SRLabel_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_5
        '
        Me.SRLabel_5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_5.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_5.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_5.Location = New System.Drawing.Point(156, 30)
        Me.SRLabel_5.Name = "SRLabel_5"
        Me.SRLabel_5.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_5.TabIndex = 105
        Me.SRLabel_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_2
        '
        Me.SRLabel_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_2.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_2.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_2.Location = New System.Drawing.Point(156, 5)
        Me.SRLabel_2.Name = "SRLabel_2"
        Me.SRLabel_2.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_2.TabIndex = 102
        Me.SRLabel_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VScrollRoutes
        '
        Me.VScrollRoutes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollRoutes.Location = New System.Drawing.Point(230, 0)
        Me.VScrollRoutes.Maximum = 20
        Me.VScrollRoutes.Name = "VScrollRoutes"
        Me.VScrollRoutes.Size = New System.Drawing.Size(16, 115)
        Me.VScrollRoutes.TabIndex = 23
        '
        'SRLabel_8
        '
        Me.SRLabel_8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_8.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_8.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_8.Location = New System.Drawing.Point(156, 55)
        Me.SRLabel_8.Name = "SRLabel_8"
        Me.SRLabel_8.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_8.TabIndex = 24
        Me.SRLabel_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_9
        '
        Me.SRLabel_9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_9.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_9.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_9.Location = New System.Drawing.Point(4, 80)
        Me.SRLabel_9.Name = "SRLabel_9"
        Me.SRLabel_9.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_9.TabIndex = 25
        Me.SRLabel_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_12
        '
        Me.SRLabel_12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_12.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_12.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_12.Location = New System.Drawing.Point(4, 105)
        Me.SRLabel_12.Name = "SRLabel_12"
        Me.SRLabel_12.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_12.TabIndex = 26
        Me.SRLabel_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SRLabel_12.Visible = False
        '
        'SRLabel_10
        '
        Me.SRLabel_10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_10.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_10.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_10.Location = New System.Drawing.Point(80, 80)
        Me.SRLabel_10.Name = "SRLabel_10"
        Me.SRLabel_10.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_10.TabIndex = 28
        Me.SRLabel_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_13
        '
        Me.SRLabel_13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_13.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_13.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_13.Location = New System.Drawing.Point(80, 105)
        Me.SRLabel_13.Name = "SRLabel_13"
        Me.SRLabel_13.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_13.TabIndex = 29
        Me.SRLabel_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SRLabel_13.Visible = False
        '
        'SRLabel_11
        '
        Me.SRLabel_11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_11.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_11.Font = New System.Drawing.Font("Arial", 13.15!)
        Me.SRLabel_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SRLabel_11.Location = New System.Drawing.Point(156, 80)
        Me.SRLabel_11.Name = "SRLabel_11"
        Me.SRLabel_11.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_11.TabIndex = 31
        Me.SRLabel_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_14
        '
        Me.SRLabel_14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_14.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SRLabel_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SRLabel_14.Location = New System.Drawing.Point(156, 105)
        Me.SRLabel_14.Name = "SRLabel_14"
        Me.SRLabel_14.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_14.TabIndex = 32
        Me.SRLabel_14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SRLabel_14.Visible = False
        '
        'ChangeRegion
        '
        Me.ChangeRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ChangeRegion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChangeRegion.Image = CType(resources.GetObject("ChangeRegion.Image"), System.Drawing.Image)
        Me.ChangeRegion.Location = New System.Drawing.Point(318, 12)
        Me.ChangeRegion.Name = "ChangeRegion"
        Me.ChangeRegion.Size = New System.Drawing.Size(68, 40)
        Me.ChangeRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ChangeRegion.TabIndex = 108
        Me.ChangeRegion.TabStop = False
        '
        'NW
        '
        Me.NW.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NW.BackColor = System.Drawing.SystemColors.Info
        Me.NW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NW.Location = New System.Drawing.Point(320, 14)
        Me.NW.Name = "NW"
        Me.NW.Size = New System.Drawing.Size(30, 17)
        Me.NW.TabIndex = 109
        Me.NW.Text = "NW"
        Me.NW.Visible = False
        '
        'NE
        '
        Me.NE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NE.BackColor = System.Drawing.SystemColors.Info
        Me.NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NE.Location = New System.Drawing.Point(354, 14)
        Me.NE.Name = "NE"
        Me.NE.Size = New System.Drawing.Size(30, 17)
        Me.NE.TabIndex = 110
        Me.NE.Text = "NE"
        Me.NE.Visible = False
        '
        'SW
        '
        Me.SW.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SW.BackColor = System.Drawing.SystemColors.Info
        Me.SW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SW.Location = New System.Drawing.Point(320, 33)
        Me.SW.Name = "SW"
        Me.SW.Size = New System.Drawing.Size(30, 17)
        Me.SW.TabIndex = 111
        Me.SW.Text = "SW"
        Me.SW.Visible = False
        '
        'SE
        '
        Me.SE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SE.BackColor = System.Drawing.SystemColors.Info
        Me.SE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SE.Location = New System.Drawing.Point(354, 33)
        Me.SE.Name = "SE"
        Me.SE.Size = New System.Drawing.Size(30, 17)
        Me.SE.TabIndex = 112
        Me.SE.Text = "SE"
        Me.SE.Visible = False
        '
        'ShowMapOption
        '
        Me.ShowMapOption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShowMapOption.Font = New System.Drawing.Font("Arial", 8.7!)
        Me.ShowMapOption.Location = New System.Drawing.Point(392, 11)
        Me.ShowMapOption.Name = "ShowMapOption"
        Me.ShowMapOption.Size = New System.Drawing.Size(83, 32)
        Me.ShowMapOption.TabIndex = 113
        Me.ShowMapOption.Text = "Show large map"
        Me.ShowMapOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuMain
        '
        Me.MenuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.File, Me.MenuItem1, Me.MenuItem2, Me.Help})
        '
        'File
        '
        Me.File.Index = 0
        Me.File.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.SaveMain, Me.CopyPictureMain, Me.CopyLinkMain, Me.MenuItem4, Me.SendPicture, Me.MenuItem5, Me.ExitMenu})
        Me.File.Text = "&File"
        '
        'SaveMain
        '
        Me.SaveMain.Index = 0
        Me.SaveMain.Text = "Save Picture As..."
        '
        'CopyPictureMain
        '
        Me.CopyPictureMain.Index = 1
        Me.CopyPictureMain.Text = "Copy Picture"
        '
        'CopyLinkMain
        '
        Me.CopyLinkMain.Index = 2
        Me.CopyLinkMain.Text = "Copy Link"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "-"
        '
        'SendPicture
        '
        Me.SendPicture.Index = 4
        Me.SendPicture.Text = "Send Picture..."
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 5
        Me.MenuItem5.Text = "-"
        '
        'ExitMenu
        '
        Me.ExitMenu.Index = 6
        Me.ExitMenu.Text = "E&xit"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.LabelsBackColor, Me.AutoSize})
        Me.MenuItem1.Text = "&Settings"
        '
        'LabelsBackColor
        '
        Me.LabelsBackColor.Index = 0
        Me.LabelsBackColor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FloralWhiteColor, Me.SystemInfoColor, Me.WindowForeColor})
        Me.LabelsBackColor.Text = "Label &Colors"
        '
        'FloralWhiteColor
        '
        Me.FloralWhiteColor.Index = 0
        Me.FloralWhiteColor.Text = "&Floral White"
        '
        'SystemInfoColor
        '
        Me.SystemInfoColor.Index = 1
        Me.SystemInfoColor.Text = "&Light Beige"
        '
        'WindowForeColor
        '
        Me.WindowForeColor.Index = 2
        Me.WindowForeColor.Text = "&Windows Default"
        '
        'AutoSize
        '
        Me.AutoSize.Checked = True
        Me.AutoSize.Index = 1
        Me.AutoSize.Text = "Resize form to Keep Image Ratio"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.DownloadUpdate})
        Me.MenuItem2.Text = "&Tools"
        '
        'DownloadUpdate
        '
        Me.DownloadUpdate.Index = 0
        Me.DownloadUpdate.Text = "Get Newest Version..."
        '
        'Help
        '
        Me.Help.Index = 3
        Me.Help.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.HelpTopics, Me.About})
        Me.Help.Text = "&Help"
        '
        'HelpTopics
        '
        Me.HelpTopics.Index = 0
        Me.HelpTopics.Text = "&Help Topics"
        '
        'About
        '
        Me.About.Index = 1
        Me.About.Text = "&About Traffic Viewer"
        '
        'HideRegion
        '
        Me.HideRegion.Interval = 2000
        '
        'SRBackground
        '
        Me.SRBackground.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRBackground.BackColor = System.Drawing.SystemColors.Window
        Me.SRBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SRBackground.Controls.Add(Me.SRLabel_15)
        Me.SRBackground.Controls.Add(Me.SRLabel_16)
        Me.SRBackground.Controls.Add(Me.VScrollRoutes)
        Me.SRBackground.Controls.Add(Me.SRLabel_5)
        Me.SRBackground.Controls.Add(Me.SRLabel_2)
        Me.SRBackground.Controls.Add(Me.SRLabel_8)
        Me.SRBackground.Controls.Add(Me.SRLabel_9)
        Me.SRBackground.Controls.Add(Me.SRLabel_12)
        Me.SRBackground.Controls.Add(Me.SRLabel_10)
        Me.SRBackground.Controls.Add(Me.SRLabel_13)
        Me.SRBackground.Controls.Add(Me.SRLabel_11)
        Me.SRBackground.Controls.Add(Me.SRLabel_0)
        Me.SRBackground.Controls.Add(Me.SRLabel_4)
        Me.SRBackground.Controls.Add(Me.SRLabel_14)
        Me.SRBackground.Controls.Add(Me.SRLabel_3)
        Me.SRBackground.Controls.Add(Me.SRLabel_6)
        Me.SRBackground.Controls.Add(Me.SRLabel_7)
        Me.SRBackground.Controls.Add(Me.SRLabel_1)
        Me.SRBackground.Location = New System.Drawing.Point(487, 3)
        Me.SRBackground.Name = "SRBackground"
        Me.SRBackground.Size = New System.Drawing.Size(250, 119)
        Me.SRBackground.TabIndex = 128
        '
        'SRLabel_15
        '
        Me.SRLabel_15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_15.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SRLabel_15.Location = New System.Drawing.Point(4, 130)
        Me.SRLabel_15.Name = "SRLabel_15"
        Me.SRLabel_15.Size = New System.Drawing.Size(70, 20)
        Me.SRLabel_15.TabIndex = 108
        Me.SRLabel_15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SRLabel_16
        '
        Me.SRLabel_16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SRLabel_16.BackColor = System.Drawing.SystemColors.Window
        Me.SRLabel_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SRLabel_16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SRLabel_16.Location = New System.Drawing.Point(80, 130)
        Me.SRLabel_16.Name = "SRLabel_16"
        Me.SRLabel_16.Size = New System.Drawing.Size(71, 20)
        Me.SRLabel_16.TabIndex = 109
        Me.SRLabel_16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'King
        '
        Me.King.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.King.LinkColor = System.Drawing.SystemColors.Desktop
        Me.King.Location = New System.Drawing.Point(20, 16)
        Me.King.Name = "King"
        Me.King.Size = New System.Drawing.Size(78, 19)
        Me.King.TabIndex = 125
        Me.King.TabStop = True
        Me.King.Text = "King County"
        '
        'Seattle
        '
        Me.Seattle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seattle.LinkColor = System.Drawing.SystemColors.Desktop
        Me.Seattle.Location = New System.Drawing.Point(108, 16)
        Me.Seattle.Name = "Seattle"
        Me.Seattle.Size = New System.Drawing.Size(50, 19)
        Me.Seattle.TabIndex = 129
        Me.Seattle.TabStop = True
        Me.Seattle.Text = "Seattle"
        '
        'Bellevue
        '
        Me.Bellevue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bellevue.LinkColor = System.Drawing.SystemColors.Desktop
        Me.Bellevue.Location = New System.Drawing.Point(168, 16)
        Me.Bellevue.Name = "Bellevue"
        Me.Bellevue.Size = New System.Drawing.Size(56, 19)
        Me.Bellevue.TabIndex = 130
        Me.Bellevue.TabStop = True
        Me.Bellevue.Text = "Bellevue"
        '
        'OtherMaps
        '
        Me.OtherMaps.Controls.Add(Me.Bellevue)
        Me.OtherMaps.Controls.Add(Me.Seattle)
        Me.OtherMaps.Controls.Add(Me.King)
        Me.OtherMaps.Location = New System.Drawing.Point(3, 7)
        Me.OtherMaps.Name = "OtherMaps"
        Me.OtherMaps.Size = New System.Drawing.Size(229, 40)
        Me.OtherMaps.TabIndex = 131
        Me.OtherMaps.TabStop = False
        Me.OtherMaps.Text = "City and County Maps"
        '
        'Tacoma
        '
        Me.Tacoma.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tacoma.LinkColor = System.Drawing.SystemColors.Desktop
        Me.Tacoma.Location = New System.Drawing.Point(38, 69)
        Me.Tacoma.Name = "Tacoma"
        Me.Tacoma.Size = New System.Drawing.Size(184, 19)
        Me.Tacoma.TabIndex = 131
        Me.Tacoma.TabStop = True
        Me.Tacoma.Text = "Tacoma form not finished yet"
        Me.Tacoma.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 6.4!)
        Me.GroupBox2.Location = New System.Drawing.Point(309, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(173, 58)
        Me.GroupBox2.TabIndex = 132
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Washington Map"
        '
        'NewVersionAvailable
        '
        Me.NewVersionAvailable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewVersionAvailable.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(237, Byte))
        Me.NewVersionAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NewVersionAvailable.Location = New System.Drawing.Point(400, 464)
        Me.NewVersionAvailable.Name = "NewVersionAvailable"
        Me.NewVersionAvailable.Size = New System.Drawing.Size(317, 18)
        Me.NewVersionAvailable.TabIndex = 134
        Me.NewVersionAvailable.Text = "An Update is available for download.  Click here for more info."
        '
        'MainStatusBar
        '
        Me.MainStatusBar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainStatusBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MainStatusBar.Location = New System.Drawing.Point(2, 459)
        Me.MainStatusBar.Name = "MainStatusBar"
        Me.MainStatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Caption})
        Me.MainStatusBar.ShowPanels = True
        Me.MainStatusBar.Size = New System.Drawing.Size(735, 25)
        Me.MainStatusBar.TabIndex = 135
        '
        'Caption
        '
        Me.Caption.Width = 8000
        '
        'MainViewerForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(737, 484)
        Me.Controls.Add(Me.Tacoma)
        Me.Controls.Add(Me.NewVersionAvailable)
        Me.Controls.Add(Me.MainStatusBar)
        Me.Controls.Add(Me.SRBackground)
        Me.Controls.Add(Me.CameraList)
        Me.Controls.Add(Me.CameraImage)
        Me.Controls.Add(Me.ReloadButton)
        Me.Controls.Add(Me.AutoRefresh)
        Me.Controls.Add(Me.NW)
        Me.Controls.Add(Me.NE)
        Me.Controls.Add(Me.SW)
        Me.Controls.Add(Me.SE)
        Me.Controls.Add(Me.ChangeRegion)
        Me.Controls.Add(Me.ShowMapOption)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.OtherMaps)
        Me.DockPadding.Left = 2
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MenuMain
        Me.MinimumSize = New System.Drawing.Size(460, 350)
        Me.Name = "MainViewerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Traffic Viewer"
        Me.SRBackground.ResumeLayout(False)
        Me.OtherMaps.ResumeLayout(False)
        CType(Me.Caption, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Internet Connection "
    Private ConnectionStarted As Integer 'Stores a value if modem connection started from this app.
    Private Const SHOW_DIALUP_PROMPT As Integer = &H2000 'Flag to show dialup dialog box to user.

    'Check for internet connection. To work properly, this
    'function needs IE to be configured for internet use.

    'This API call was removed, because it returned an erroneous connected state on several machines.
    '
    'Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Int32, _
    'ByVal dwReserved As Int32) As Boolean

    'Open Dial-Up dialog to connect with modem.
    Private Declare Sub InternetDial Lib "Wininet.dll" (ByVal hwndParent As IntPtr, _
    ByVal lpszConnectoid As String, ByVal dwFlags As Int32, ByRef lpdwConnection As Int32, _
    ByVal dwReserved As Int32)

    'Hang up modem.
    Private Declare Function InternetHangUp Lib "Wininet.dll" (ByVal Connection As Int32) As Int32

    Private Function ConnectedToInternet() As Boolean
        Try
            'check connection by making a web request to yahoo
            Request = Request.Create("http://www.yahoo.com/")
            Request.Credentials = Net.CredentialCache.DefaultCredentials
            Request.Timeout = 1000
            Request.GetResponse() 'any response indicates connection is working
            Connected = True
            If MainStatusBar.Text Is Nothing Then MainStatusBar.Panels(0).Text = "Loading..."
        Catch ex As System.Net.WebException
            Try ' try google
                Request = Request.Create("http://www.google.com/")
                Request.Credentials = Net.CredentialCache.DefaultCredentials
                Request.Timeout = 4000 'allow for longer timeout
                Request.GetResponse() 'any response indicates connection is working
                Connected = True
            Catch ex2 As System.Net.WebException
                'not connected to internet, or user has a very 
                'slow connection, or both yahoo and google websites are down
                Connected = False
            End Try
        Finally
            Request = Nothing
        End Try
        Return Connected
    End Function
#End Region

#Region " Exception Handler "
    'exit the application if unhandled exception occurs, give user option to restart this app.
    Friend Sub Exception_Handler(ByVal Sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        Try
            Dim ErrorMessage, VerboseErrorMessage As String
            If Not e Is Nothing Then
                VerboseErrorMessage = e.Exception.ToString
                ErrorMessage = e.Exception.Message
            Else
                ErrorMessage = "Unknown exception."
                VerboseErrorMessage = "No information available."
            End If
            Dim Answer As Integer
            Answer = MessageBox.Show("TrafficViewer has generated an error and needs to close." & _
            Environment.NewLine & Environment.NewLine & "Error: " & ErrorMessage & Environment.NewLine & _
            "----------------------------------------------------------------------------------------------------------" & _
            Environment.NewLine & "Error info:  " & VerboseErrorMessage & Environment.NewLine & _
            "----------------------------------------------------------------------------------------------------------" & _
            Environment.NewLine & Environment.NewLine & "Restart program after it closes?", "Fatal Exception.", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If Answer = DialogResult.Yes Then
                Application.Exit()
                System.Diagnostics.Process.Start(ThisExePath)
            Else
                Application.Exit()
            End If
        Catch
            Application.Exit()
        End Try
    End Sub
#End Region
    Friend Sub OpenLink(ByVal LinkName As String)
        Try
            Select Case LinkName
                Case "King County"
                    Diagnostics.Process.Start("iexplore", "http://apps01.metrokc.gov/www/kcdot/mycommute/index.cfm")
                Case "Seattle"
                    Diagnostics.Process.Start("iexplore", "http://www.seattle.gov/trafficcams/")
                Case "Bellevue"
                    Diagnostics.Process.Start("iexplore", "http://www.cityofbellevue.org/trafficcam/")
            End Select
        Catch ex As IO.IOException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    <STAThread()> Friend Shared Sub Main() 'set Single Threaded Aparment state
        Dim F_Main As New MainViewerForm
        AddHandler Application.ThreadException, AddressOf F_Main.Exception_Handler
        'Enable double buffering and update the control style for the form.
        'Set the value of the double-buffering style bits to true.
        F_Main.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint _
        Or ControlStyles.AllPaintingInWmPaint, True)
        F_Main.UpdateStyles()
        Application.Run(F_Main)
    End Sub

    Private Sub ShowNewVersionAvailable()
        NewVersionAvailable.Show()
    End Sub

    Private Sub CheckVersion_GetAboutFormInfo()
        CheckThread.Sleep(150)
        Dim CPU_Inf As Management.ManagementClass
        CPU_Inf = New Management.ManagementClass("Win32_Processor")
        Dim ClassObject As New Management.ManagementObject
        Dim SetOptions As New Management.EnumerationOptions
        'set query options for best possible performance
        With SetOptions
            .DirectRead = True
            .Rewindable = False
        End With
        For Each ClassObject In CPU_Inf.GetInstances(SetOptions)
            CPU_Info = "      Processor Type:" & "  " & ClassObject("Name").ToString.Trim
            CPU_Speed = "     Processor Speed:  " & Convert.ToDouble(ClassObject("CurrentClockSpeed").ToString.Trim) / 1000 & " GHz"
            Exit For 'in case of multiple cpu's, only show first cpu info
        Next
        CheckThread.Sleep(2000)
        If Tools.NewerVersionCheck Then
            Me.Invoke(ShowLabelDelegate)
        End If
        CPU_Inf.Dispose()
        ClassObject.Dispose()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainForm = Me
        NewVersionAvailable.Visible = False
        CameraIndex = 21
        'set map form Main to this form 
        MainForm = Me
        'Fill SRLabels array with each state route label on the form.
        SRLabels = New Label() {SRLabel_0, SRLabel_1, SRLabel_2, SRLabel_3, SRLabel_4, SRLabel_5, _
                                SRLabel_6, SRLabel_7, SRLabel_8, SRLabel_9, SRLabel_10, SRLabel_11, _
                                SRLabel_12, SRLabel_13, SRLabel_14, SRLabel_15, SRLabel_16}
        'Record the top value of each state route label. Used when scrolling.
        For Index = 0 To SRLabels.GetUpperBound(0)
            TopOfLabels(Index) = SRLabels(Index).Top
        Next
        'Get user selected color, or else clear temp files from installation upgrade.
        Try
            If IO.File.Exists(SettingsFile) Then
                Reader = New IO.StreamReader(SettingsFile)
                Dim selectedColor As String
                selectedColor = Reader.ReadLine
                Reader.Close()
                If selectedColor.Trim = "TempFilesDirty" Then
                    SaveSelectedColor()
                    Dim DelTemp As New ApplicationTools
                    DelTemp.DeleteTempFiles()
                    DelTemp.Dispose()
                Else
                    CameraList.BackColor = Color.FromName(selectedColor)
                    SRBackground.BackColor = CameraList.BackColor
                    For Index = 0 To SRLabels.GetUpperBound(0)
                        SRLabels(Index).BackColor = CameraList.BackColor
                    Next
                End If
            End If
        Catch ex As System.ArgumentException
            CameraList.BackColor = SystemColors.Window
            SaveSelectedColor()
        Catch ex As IO.IOException
            CameraList.BackColor = SystemColors.Window
            SaveSelectedColor()
        End Try
        'Set SRLabel to first label.
        SRLabel = SRLabel_0
        Set_SRLabels(MapRegion)
        StateRouteLabels_MouseDown(SRLabel_0, Nothing)
        Refresh()
        LoadThread = New Threading.Thread(AddressOf FormLoad)
        'Set thread as background. 
        LoadThread.IsBackground = True
        LoadThread.Start()
    End Sub

    Private Sub FormLoad()
        Invalidate()
        If Not ConnectedToInternet() Then
            MainStatusBar.Panels(0).Text = "Connection Not Found"
            'Give user option to open dial up prompt if internet connection not detected.
            If MessageBox.Show(Me, "Internet connection not detected.  Start dial-up connection?", _
            "Connection Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                InternetDial(Me.Handle, "My Connection", SHOW_DIALUP_PROMPT, ConnectionStarted, 0)
            End If
        End If
        LoadingImage = False
        'added here so loadimage does not fire before dialup, if dialup is needed.
        AddHandler CameraList.SelectedIndexChanged, AddressOf CameraList_SelectedIndexChanged
        LoadImage()
        'check for new version of trafficviewer
        CheckThread = New Threading.Thread(AddressOf CheckVersion_GetAboutFormInfo)
        CheckThread.Priority = Threading.ThreadPriority.Lowest
        CheckThread.IsBackground = True
        CheckThread.Start()
    End Sub

    Private Sub LoadCameraList(ByVal StateRoute As String, ByVal Area As String)
        CameraList.Items.Clear()
        'Fill camera list.
        Reader = New IO.StreamReader(ThisExe.GetManifestResourceStream(ThisExeName & "." & "Desc" & Area & StateRoute & ".txt"))
        Do Until Reader.Peek = -1
            CameraList.Items.Add(Reader.ReadLine)
        Loop
        Reader.Close()
        'Select Seattle area camera if Washington NW I-5 selected.
        If StateRoute = "I-5" AndAlso Me.MapRegion = "NW" Then
            CameraList.SelectedIndex = 21
        Else
            CameraList.SelectedIndex = 0
        End If
    End Sub

    Private Sub CameraList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AutoRefresh.Checked = False
        CameraIndex = CameraList.SelectedIndex
        If Not LoadingImage Then
            MainStatusBar.Panels(0).Text = "Loading..."
            LoadThread = New Threading.Thread(AddressOf LoadImage)
            LoadThread.Start()
        Else
            NewImageSelected = True
        End If
    End Sub

    Sub Set_Image()
        CameraImage.Image = LoadedImage
        MainStatusBar.Panels(0).Text = WebAddress.ToString
        If WebAddress.ToString.IndexOf("Image not available") > -1 Then
            AutoRefresh.Checked = False
        End If
    End Sub

    Private Sub LoadImage()
        'Prevent multiple instances of this sub.
        If LoadingImage Then Exit Sub
        LoadingImage = True
Reload:  'reload when a new image was selected
        WebAddress.Remove(0, WebAddress.Length)
        DataStream = ThisExe.GetManifestResourceStream(ThisExeName & "." & MapRegion & SRLabel.Text & ".txt")
        Reader = New IO.StreamReader(DataStream)
        'Move the filestream pointer to the appropriate line.
        DataStream.Seek(CameraIndex * 100, IO.SeekOrigin.Current)
        WebAddress.Append(Reader.ReadLine.TrimEnd)
        Reader.Close()
        Try
            LoadedImage = Image.FromStream(New IO.MemoryStream(Client.DownloadData(WebAddress.ToString)))
            Me.Invoke(Me.SetNewImage)
        Catch ex As ArgumentException 'can happen if downloaded image is corrupt or image was not completely finished being uploaded
            NewImageSelected = False
            If MainStatusBar.Panels(0).Text = "Reloading..." Then
                WebAddress.Remove(0, WebAddress.Length)
                WebAddress.Append("Reload failed.")
                LoadedImage = Nothing
                Me.Invoke(Me.SetNewImage)
            Else
                WebAddress.Remove(0, WebAddress.Length)
                WebAddress.Append("Image not available.")
                LoadedImage = Nothing
                Me.Invoke(Me.SetNewImage)
            End If
        Catch ex As Net.WebException
            If ex.ToString.IndexOf("404") > -1 Then
                'display  "404 Not Found" image
                LoadedImage = Image.FromStream(ThisExe.GetManifestResourceStream(ThisExeName & "." & "WebError404.bmp"))
                WebAddress.Remove(0, WebAddress.Length)
                WebAddress.Append("Image not available.")
                Me.Invoke(Me.SetNewImage)
            ElseIf MainStatusBar.Panels(0).Text = "Reloading..." Then
                WebAddress.Remove(0, WebAddress.Length)
                WebAddress.Append("Reload failed.")
                LoadedImage = Nothing
                Me.Invoke(Me.SetNewImage)
            Else
                WebAddress.Remove(0, WebAddress.Length)
                WebAddress.Append("Image not available.")
                LoadedImage = Nothing
                Me.Invoke(Me.SetNewImage)
            End If
        End Try
        'Load image again if user has scrolled to another camera before 
        'Loadthread finished.  Typical when speed browsing cameralist.
        If NewImageSelected Then
            NewImageSelected = False
            GoTo Reload
        End If
        'reset boolean
        LoadingImage = False
    End Sub

    Private Sub ReloadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadTimer.Tick
        'Reload image if auto-refreshing, or if there is no image loaded when there should be.
        If AutoRefresh.Checked Then
            Interval += 1
            If Interval > 49 Then
                Interval = 0
                If LoadThread.ThreadState = Threading.ThreadState.Stopped AndAlso Not MainStatusBar.Panels(0).Text = "Image not available." Then
                    LoadingImage = False
                    MainStatusBar.Panels(0).Text = "Reloading..."
                    LoadImage()
                End If
            End If
        ElseIf CameraImage.Image Is Nothing Then
            If LoadThread.ThreadState = Threading.ThreadState.Stopped AndAlso Not MainStatusBar.Panels(0).Text = "Image not available." Then
                LoadingImage = False
                MainStatusBar.Panels(0).Text = "Reloading..."
                LoadImage()
            End If
        End If
    End Sub

    Private Sub ReloadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadButton.Click
        If Not LoadingImage Then
            MainStatusBar.Panels(0).Text = "Reloading..."
            LoadThread = New Threading.Thread(AddressOf LoadImage)
            LoadThread.Start()
        Else
            NewImageSelected = True
        End If
        CameraList.Select()
    End Sub

    Protected Friend Sub StateRouteLabels_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _
    SRLabel_0.MouseDown, SRLabel_1.MouseDown, SRLabel_2.MouseDown, SRLabel_3.MouseDown, SRLabel_4.MouseDown, SRLabel_5.MouseDown, _
    SRLabel_6.MouseDown, SRLabel_7.MouseDown, SRLabel_8.MouseDown, SRLabel_9.MouseDown, SRLabel_10.MouseDown, SRLabel_11.MouseDown, _
    SRLabel_12.MouseDown, SRLabel_13.MouseDown, SRLabel_14.MouseDown, SRLabel_15.MouseDown, SRLabel_16.MouseDown
        AutoRefresh.Checked = False
        'De-select previous label.
        SRLabel.BackColor = SRBackground.BackColor
        SRLabel.ForeColor = SystemColors.ControlText
        'Select new label.
        SRLabel = DirectCast(sender, Label)
        SRLabel.BackColor = SystemColors.Highlight
        SRLabel.ForeColor = SystemColors.ActiveCaptionText
        LoadCameraList(SRLabel.Text, MapRegion)
    End Sub

    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Prompt user to disconnect modem, if connection started from this application.
        If ConnectionStarted <> 0 Then
            If MessageBox.Show("Disconnect internet connection?", "Dial-Up Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MainStatusBar.Panels(0).Text = "Disconnecting modem..."
                If InternetHangUp(ConnectionStarted) <> 0 Then
                    MessageBox.Show("Unable to disconnect modem from internet, due to an unexpected error.", _
                    "Disconnect Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub SaveSelectedColor()
        'Create directory, if needed.
        IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer")
        'Save selected color.
        Writer = New IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\Settings.dat", False)
        Writer.WriteLine(CameraList.BackColor.ToKnownColor.ToString)
        Writer.Close()
    End Sub

    Protected Friend Sub Set_SRLabels(ByVal SelectedRegion As String)
        'Reset scrollbar to top, to set label positions properly for when scrollbar goes away.
        Dim LastItem As Integer
        If VScrollRoutes.Visible Then VScrollRoutes.Value = 0
        Reader = New IO.StreamReader(ThisExe.GetManifestResourceStream(ThisExeName & "." & "Washington" & SelectedRegion & ".txt"))
        LastItem = Convert.ToInt32(Reader.ReadLine)
        For Index = 0 To LastItem
            SRLabels(Index).Text = Reader.ReadLine
            SRLabels(Index).Show()
        Next
        Reader.Close()
        'Hide unused state route labels.
        If LastItem < SRLabels.GetUpperBound(0) Then
            For Index = LastItem + 1 To SRLabels.GetUpperBound(0)
                SRLabels(Index).Hide()
            Next
        End If
        'Hide or show scrollbar as needed.
        If LastItem > 11 Then
            VScrollRoutes.Show()
        Else
            VScrollRoutes.Hide()
        End If
    End Sub

    Private Sub ShowRegionLabel()
        Select Case MapRegion
            Case "NW"
                NW.Show()
                NE.Hide()
                SE.Hide()
                SW.Hide()
                NW.Refresh()
            Case "NE"
                NE.Show()
                NW.Hide()
                SE.Hide()
                SW.Hide()
                NE.Refresh()
            Case "SW"
                SW.Show()
                NE.Hide()
                SE.Hide()
                NW.Hide()
                SW.Refresh()
            Case "SE"
                SE.Show()
                NW.Hide()
                NE.Hide()
                SW.Hide()
                SE.Refresh()
        End Select
    End Sub

    Private Sub VScrollRoutes_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollRoutes.ValueChanged
        For Index = 0 To SRLabels.GetUpperBound(0)
            SRLabels(Index).Top = TopOfLabels(Index) - (VScrollRoutes.Value * 4)
        Next
    End Sub

    Private Sub ChangeRegion_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ChangeRegion.MouseDown
        If ShowMapOption.Checked Then
            Map.ShowDialog()
        Else
            Select Case True
                Case MousePosition.X > Left + ChangeRegion.Left + Convert.ToInt32(ChangeRegion.Width / 2) _
                AndAlso MousePosition.Y - 41 > Top + ChangeRegion.Top + Convert.ToInt32(ChangeRegion.Height / 2)
                    MapRegion = "SE"
                Case MousePosition.X <= Left + ChangeRegion.Left + Convert.ToInt32(ChangeRegion.Width / 2) _
                AndAlso MousePosition.Y - 41 > Top + ChangeRegion.Top + Convert.ToInt32(ChangeRegion.Height / 2)
                    MapRegion = "SW"
                Case MousePosition.X >= Left + ChangeRegion.Left + Convert.ToInt32(ChangeRegion.Width / 2) _
                AndAlso MousePosition.Y - 41 <= Top + ChangeRegion.Top + Convert.ToInt32(ChangeRegion.Height / 2)
                    MapRegion = "NE"
                Case MousePosition.X <= Left + ChangeRegion.Left + Convert.ToInt32(ChangeRegion.Width / 2) _
                AndAlso MousePosition.Y - 41 <= Top + ChangeRegion.Top + Convert.ToInt32(ChangeRegion.Height / 2)
                    MapRegion = "NW"
                Case Else
                    MapRegion = "NW"
            End Select
        End If
        ShowRegionLabel()
        If ShowMapOption.Checked Then
            HideRegion.Start()
        End If
        Set_SRLabels(MapRegion)
        Refresh()
        StateRouteLabels_MouseDown(SRLabel_0, Nothing)
        LoadImage()
        Refresh()
    End Sub

    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About.Click
        If AboutForm Is Nothing Then
            AboutForm = New AboutForm
            With AboutForm.SetOptions 'query options set for best possible performance
                .DirectRead = True
                .Rewindable = False
            End With
        End If
        If CPU_Speed = "" Then
            MessageBox.Show("Please wait for form to finish loading.", "About Form Not Ready")
            Exit Sub
        End If
        AboutForm.ShowDialog()
    End Sub

    Private Sub ExitMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitMenu.Click
        Application.Exit()
    End Sub

    Private Sub ChangeRegion_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeRegion.MouseEnter
        ShowRegionLabel()
    End Sub

    Private Sub ChangeRegion_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeRegion.MouseLeave
        NW.Hide()
        SW.Hide()
        NE.Hide()
        SE.Hide()
    End Sub

    Private Sub Apply_SelectedColor(ByVal SelectedColor As Color)
        For Index = 0 To SRLabels.GetUpperBound(0)
            SRLabels(Index).BackColor = SelectedColor
        Next
        SRLabel.BackColor = SystemColors.Highlight
        CameraList.BackColor = SelectedColor
        SRBackground.BackColor = SelectedColor
    End Sub

    Private Sub FloralWhiteColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FloralWhiteColor.Click
        Apply_SelectedColor(Color.FloralWhite)
        SaveSelectedColor()
    End Sub

    Private Sub SystemInfoColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemInfoColor.Click
        Apply_SelectedColor(SystemColors.Info)
        SaveSelectedColor()
    End Sub

    Private Sub WhiteColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowForeColor.Click
        Apply_SelectedColor(SystemColors.Window)
        SaveSelectedColor()
    End Sub

    Private Sub DownloadUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadUpdate.Click
        If Tools Is Nothing Then Tools = New ApplicationTools
        If Tools.NewerVersionCheck() Then
            If MessageBox.Show("A newer version exists on the web server.  Would you like to download and install the new version?", _
            "New Version Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'record application path
                Dim Key As Microsoft.Win32.RegistryKey
                Try
                    Key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software", True)
                    With Key.CreateSubKey("TrafficViewer")
                        .SetValue("Path", Application.StartupPath)
                    End With
                    Key.Close()
                Catch ex As Security.SecurityException
                    MessageBox.Show(ex.Message & Environment.NewLine & "The current application path could not be recorded.")
                End Try
                Tools.StartUpdate()
            End If
        ElseIf Tools.ErrorReturn = False Then
            MessageBox.Show("This version is the newest one.", "Traffic Viewer " & Application.ProductVersion.Substring(0, 3))
            Tools.Dispose()
        ElseIf Tools.ErrorReturn = True Then
            MessageBox.Show("Unable to check for the newest version at this time", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tools.Dispose()
        End If
    End Sub

    Private Sub HideRegion_CheckVersion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideRegion.Tick
        NE.Hide()
        NW.Hide()
        SE.Hide()
        SW.Hide()
        HideRegion.Stop()
    End Sub

    Private Sub CopyPictureMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyPictureMain.Click
        CopyPicture.PerformClick()
    End Sub

    Private Sub SaveMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMain.Click
        Save.PerformClick()
    End Sub

    Private Sub CopyLinkMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyLinkMain.Click
        CopyLink.PerformClick()
    End Sub

    Private Sub CopyPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyPicture.Click
        If Not CameraImage.Image Is Nothing Then
            Clipboard.SetDataObject(CameraImage.Image)
        End If
    End Sub

    Private Sub CopyLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyLink.Click
        If Not CameraImage.Image Is Nothing Then
            Clipboard.SetDataObject(MainStatusBar.Panels(0).Text)
        End If
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        If Not CameraImage.Image Is Nothing Then
            Dim SaveDialog As New SaveFileDialog
            Dim SaveString As String
            'remove invalid chars from initial file name for savedialog
            Dim InvalidChars As New System.Text.RegularExpressions.Regex("\x5c|\x2f|\x3a|\x2a|\x3f|\x22|\x3e|\x3c|\x7c|\x2e")
            Try
                'When the last char is a number, get substring to the last space char, and trim trailing spaces.
                If MapRegion = "NW" AndAlso SRLabel.Text = "I-5" AndAlso Char.IsNumber(Convert.ToChar _
                (CameraList.SelectedItem.ToString.Substring(CameraList.SelectedItem.ToString.Length - 1))) Then
                    SaveString = CameraList.SelectedItem.ToString.Substring _
                    (0, CameraList.SelectedItem.ToString.LastIndexOf _
                    (" ")).TrimEnd
                Else
                    SaveString = CameraList.SelectedItem.ToString
                End If
                SaveString = InvalidChars.Replace(SaveString, " ")
                'Replace any triple or double spaces with single space.
                SaveString = SaveString.Replace("   ", " ").Replace("  ", " ")
                With SaveDialog
                    .FileName = SaveString
                    .Filter = "JPEG (*.jpg)|*.jpg"
                    .CheckPathExists = True
                    .ValidateNames = True
                    .AddExtension = True
                End With
                If SaveDialog.ShowDialog() = DialogResult.OK Then
                    CameraImage.Image.Save(SaveDialog.FileName, Imaging.ImageFormat.Jpeg)
                End If
            Catch ex As IO.IOException
                MessageBox.Show(ex.Message, "Error")
            Catch ex As Security.SecurityException
                MessageBox.Show(ex.Message, "Error")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error")
            Finally
                InvalidChars = Nothing
                SaveString = Nothing
                SaveDialog.Dispose()
            End Try
        End If
    End Sub

    Protected Friend Sub SetNWRegion(ByVal RouteLabel As Label)
        MapRegion = "NW"
        SRLabel.BackColor = SRBackground.BackColor
        SRLabel.ForeColor = SystemColors.ControlText
        'Select new label.
        SRLabel = RouteLabel
        SRLabel.BackColor = SystemColors.Highlight
        SRLabel.ForeColor = SystemColors.ActiveCaptionText
        Set_SRLabels(MapRegion)
        StateRouteLabels_MouseDown(SRLabel, Nothing)
    End Sub


    Private Sub OtherMaps_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _
    King.LinkClicked, Seattle.LinkClicked, Bellevue.LinkClicked
        VScrollRoutes.Value = 11
        Select Case DirectCast(sender, LinkLabel).Text
            Case "King County"
                If Not MapRegion = "NW" Then
                    SetNWRegion(SRLabel_16)
                ElseIf Not SRLabel Is SRLabel_16 Then
                    StateRouteLabels_MouseDown(SRLabel_16, Nothing)
                End If
                If KingCountyForm Is Nothing Then
                    KingCountyForm = New KingCounty
                End If
                If Not KingCountyForm.Visible Then
                    KingCountyForm.Show()
                ElseIf KingCountyForm.WindowState = FormWindowState.Minimized Then
                    KingCountyForm.WindowState = FormWindowState.Normal
                    KingCountyForm.Activate()
                ElseIf KingCountyForm.WindowState = FormWindowState.Normal Then
                    KingCountyForm.Activate()
                End If
            Case "Seattle"
                If Not MapRegion = "NW" Then
                    SetNWRegion(SRLabel_14)
                ElseIf Not SRLabel Is SRLabel_14 Then
                    StateRouteLabels_MouseDown(SRLabel_14, Nothing)
                End If
                If SeattleForm Is Nothing Then
                    SeattleForm = New Seattle
                End If
                If Not SeattleForm.Visible Then
                    SeattleForm.Show()
                ElseIf SeattleForm.WindowState = FormWindowState.Minimized Then
                    SeattleForm.WindowState = FormWindowState.Normal
                    SeattleForm.Activate()
                ElseIf SeattleForm.WindowState = FormWindowState.Normal Then
                    SeattleForm.Activate()
                End If
            Case "Bellevue"
                If Not MapRegion = "NW" Then
                    SetNWRegion(SRLabel_15)
                ElseIf Not SRLabel Is SRLabel_15 Then
                    StateRouteLabels_MouseDown(SRLabel_15, Nothing)
                End If
                If BellevueForm Is Nothing Then
                    BellevueForm = New Bellevue
                End If
                If Not BellevueForm.Visible Then
                    BellevueForm.Show()
                ElseIf BellevueForm.WindowState = FormWindowState.Minimized Then
                    BellevueForm.WindowState = FormWindowState.Normal
                    BellevueForm.Activate()
                ElseIf BellevueForm.WindowState = FormWindowState.Normal Then
                    BellevueForm.Activate()
                End If
        End Select
    End Sub

    Private Sub NewVersionAvailable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewVersionAvailable.Click
        NewVersionAvailable.Hide()
        If MessageBox.Show("A newer version exists on the web server.  Would you like to download and install the new version?", _
                           "New Version Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim Key As Microsoft.Win32.RegistryKey
            Try
                Key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software", True)
                With Key.CreateSubKey("TrafficViewer")
                    .SetValue("Path", Application.StartupPath)
                End With
                Key.Close()
            Catch ex As Security.SecurityException
                MessageBox.Show(ex.Message & Environment.NewLine & "The current application path could not be recorded.")
            Catch ex As InvalidOperationException 'subkey already exits, and someone added child subkeys
                MessageBox.Show(ex.Message & Environment.NewLine & "The current application path could not be recorded.")
            End Try
            If tools Is Nothing Then tools = New ApplicationTools
            Tools.StartUpdate()
        End If
    End Sub

    Private Sub AutoSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSize.Click
        AutoSize.Checked = Not AutoSize.Checked
        AutoResize = AutoSize.Checked
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'Keep aspect ratio of the form when resizing, taken from sample at VB-Helper.com; http://www.gotdotnet.com/Community/MessageBoard/Thread.aspx?id=361915
        Static first_time As Boolean = True
        Static aspect_ratio As Double
        If AutoResize AndAlso m.Msg = WM_SIZING AndAlso m.HWnd.ToInt64 = Me.Handle.ToInt64 Then
            ' Turn the message's lParam into a Rect.
            r = DirectCast(System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(Rect)), Rect)
            ' The first time, save the form's aspect ratio.
            If first_time Then
                first_time = False
                aspect_ratio = (r.bottom - r.top) / (r.right - r.left)
            End If
            ' Get the current dimensions.
            Dim wid As Double = r.right - r.left
            Dim hgt As Double = r.bottom - r.top
            ' Enlarge if necessary to preserve the aspect ratio.
            If hgt / wid > aspect_ratio Then
                ' It's too tall and thin. Make it wider.
                wid = hgt / aspect_ratio
            Else
                ' It's too short and wide. Make it taller.
                hgt = wid * aspect_ratio
            End If
            ' See if the user is dragging the top edge.
            If m.WParam.ToInt32 = WMSZ_TOP OrElse m.WParam.ToInt32 = WMSZ_TOPLEFT OrElse m.WParam.ToInt32 = WMSZ_TOPRIGHT Then
                ' Reset the top.
                r.top = r.bottom - CInt(hgt)
            Else
                ' Reset the height to the saved value.
                r.bottom = r.top + CInt(hgt)
            End If
            ' See if the user is dragging the left edge.
            If m.WParam.ToInt32 = WMSZ_LEFT OrElse m.WParam.ToInt32 = WMSZ_TOPLEFT OrElse m.WParam.ToInt32 = WMSZ_BOTTOMLEFT Then
                ' Reset the left.
                r.left = r.right - CInt(wid)
            Else
                ' Reset the width to the saved value.
                r.right = r.left + CInt(wid)
            End If
            ' Update the Message object's LParam field.
            System.Runtime.InteropServices.Marshal.StructureToPtr(r, m.LParam, True)
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub SendPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendPicture.Click
        Dim SaveString As String
        Dim SaveDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\Temp\"
        Try
            'create directory as needed 
            IO.Directory.CreateDirectory(SaveDir)
            'remove any invalid chars from cameralist selected camera
            Dim InvalidChars As New System.Text.RegularExpressions.Regex("\x5c|\x2f|\x3a|\x2a|\x3f|\x22|\x3e|\x3c|\x7c|\x2e")
            'When the last char is a number, get substring to the last space char, and trim trailing spaces.
            If MapRegion = "NW" AndAlso SRLabel.Text = "I-5" AndAlso Char.IsNumber(Convert.ToChar _
                                       (CameraList.SelectedItem.ToString.Substring(CameraList.SelectedItem.ToString.Length - 1))) Then
                SaveString = CameraList.SelectedItem.ToString.Substring(0, CameraList.SelectedItem.ToString.LastIndexOf(" ")).TrimEnd
            Else
                SaveString = CameraList.SelectedItem.ToString
            End If
            'replace any invalid characters with a space
            SaveString = InvalidChars.Replace(SaveString, " ")
            'Replace any triple or double spaces with single space.
            SaveString = SaveString.Replace("   ", " ").Replace("  ", " ")
            'add file extension
            SaveString &= ".jpg"
            CameraImage.Image.Save(SaveDir & SaveString, Imaging.ImageFormat.Jpeg)
            System.Diagnostics.Process.Start("mailto:" & "&body=" & """" & SaveDir & SaveString & """")
            Dim w As New IO.StreamWriter(SaveDir.Replace("Temp\", "") & "Settings.dat")
            w.Write("TempFilesDirty")
            w.Close()
        Catch ex As IO.IOException
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Sub Make_Help_File()
        Dim CreateHelp As New MakeHelpFile
        CreateHelp.SaveEmbeddedHelpFile()
    End Sub

    Private Sub HelpTopics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpTopics.Click
        ' Help file could be placed in a global user folder, but it is a very small file, and a per user folder 
        ' already exits, so it is saved to the same folder as the Settings.dat file.
        Dim HelpFile As String = SettingsFile.Replace("Settings.dat", "TrafficViewerHelp.htm")
        If IO.File.Exists(HelpFile) Then
            Diagnostics.Process.Start(HelpFile)
        Else
            Dim CreateHelp As New MakeHelpFile
            If CreateHelp.SaveEmbeddedHelpFile() Then
                Diagnostics.Process.Start(HelpFile)
            Else
                MessageBox.Show("Unable to Create the help file.", "Error Copying Embedded Helpfile", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub NW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NW.Click

    End Sub

    Private Sub Tacoma_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Tacoma.LinkClicked
        Dim TacomaForm As New Tacoma
        TacomaForm.Show()
    End Sub
End Class
