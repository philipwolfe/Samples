Public Class frmIconModMenu
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
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIconModMenu))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        '
        'mnuMain
        '
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'frmIconModMenu
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmIconModMenu"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)

    End Sub

#End Region

    Private Sub frmIconModMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Section #1

        ' Basic Menu Items with Icons

        mnuMain.MenuItems.Add("&File")
        Dim miFile As MenuItem = mnuMain.MenuItems(0)
        Dim handlerFile As EventHandler = New EventHandler(AddressOf MenuItemFileClick)

        ' By using this constructor the menu items will show up in whatever system
        ' colors are chosen by the user in control panel or by their theme choice.
        miFile.MenuItems.Add(New IconMenuItem("&Open", New Icon("..\open.ico"), _
            handlerFile, Shortcut.CtrlO))
        miFile.MenuItems.Add(New IconMenuItem("&Save", New Icon("..\save.ico"), _
            handlerFile, Shortcut.CtrlS))
        miFile.MenuItems.Add(New MenuItem("-"))
        miFile.MenuItems.Add(New IconMenuItem("&Exit", New Icon("..\exit.ico"), _
            handlerFile, Shortcut.None))

        ' If you want you can uncomment section one above and uncomment Section #2 below.
        ' This second section will display the menu items with a custom color gradient as a 
        ' background color.
        ' For more information on how this is done see the IconMenuItem class definition.

        ' Section #2

        ' Menu Items with Custom Gradient and Icons

        'mnuMain.MenuItems.Add("&File")
        'Dim miEdit As MenuItem = mnuMain.MenuItems(0)
        'Dim handlerPrograms As EventHandler = New EventHandler(AddressOf MenuItemProgramsClick)

        '' By using this constructor the menu items will show up with a color gradient
        '' based on the two color values passed to the constructor.
        'miEdit.MenuItems.Add(New IconMenuItem("&Open", Color.LightBlue, Color.Yellow, _
        '    New Icon("..\open.ico"), handlerPrograms, Shortcut.CtrlO))
        'miEdit.MenuItems.Add(New IconMenuItem("&Save", Color.LightBlue, Color.Yellow, _
        '    New Icon("..\save.ico"), handlerPrograms, Shortcut.CtrlS))
        'miEdit.MenuItems.Add(New MenuItem("-"))
        'miEdit.MenuItems.Add(New IconMenuItem("&Exit", Color.LightBlue, Color.Yellow, _
        '    New Icon("..\exit.ico"), handlerPrograms, Shortcut.None))

    End Sub

    Private Sub MenuItemFileClick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case CType(sender, MenuItem).Index
            Case 0    ' Open
                MessageBox.Show("You selected open")
            Case 1    ' Save
                MessageBox.Show("You selected save")
            Case 3    ' Exit
                Close()
        End Select
    End Sub

End Class
