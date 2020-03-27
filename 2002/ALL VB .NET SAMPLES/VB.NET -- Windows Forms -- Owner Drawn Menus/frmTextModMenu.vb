
Public Class frmTextModMenu
    Inherits System.Windows.Forms.Form
    Const pointSize As Integer = 18

    Private miFaceName As MenuItem

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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTextModMenu))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        '
        'mnuMain
        '
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'frmTextModMenu
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
        Me.Name = "frmTextModMenu"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)

    End Sub

#End Region

    ' This example draws a simple menu that contains three text items.
    ' The menu item is drawn at a size that is appropriate for the menu items
    ' See the frmIconModMenu for a form that includes a menu with the option
    ' for a custom color background as well as the use of icons.

    Private Sub frmTextModMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Create the main menu item and add the subitems to the menu.
        mnuMain.MenuItems.Add("&Choose a Font")
        Dim menuItemsText() As String = {"&TimesNewRoman", "&Courier New", "&MS Sans Serif"}
        Dim menuItems(menuItemsText.Length - 1) As MenuItem
        Dim menuItemCount As Integer = CInt(menuItems.Length)
        Dim evOnClick As New EventHandler(AddressOf MenuFaceNameOnClick)
        Dim evOnMeasure As New MeasureItemEventHandler(AddressOf MenuFaceNameOnMeasureItem)
        Dim evDrawItem As New DrawItemEventHandler(AddressOf MenuFaceNameOnDrawItem)

        Dim i As Integer = 0
        For i = 0 To menuItemCount - 1 Step 1
            menuItems(i) = New MenuItem(menuItemsText(i))
            ' Enables the firing of the OnMeasureItem and OnDrawnItem events.
            menuItems(i).OwnerDraw = True
            ' Add even handlers to each menu item for key events.
            AddHandler menuItems(i).Click, evOnClick
            AddHandler menuItems(i).MeasureItem, evOnMeasure
            AddHandler menuItems(i).DrawItem, evDrawItem
        Next

        mnuMain.MenuItems(0).MenuItems.AddRange(menuItems)

    End Sub

    Private Sub MenuFaceNameOnClick(ByVal sender As Object, ByVal e As EventArgs)
        ' Simply lets the user know which menu item was clicked.
        miFaceName = CType(sender, MenuItem)
        miFaceName.Checked = True
        MessageBox.Show("Menu Clicked: " & miFaceName.Text.Substring(1))
    End Sub

    Private Sub MenuFaceNameOnMeasureItem(ByVal sender As Object, ByVal miea As MeasureItemEventArgs)
        ' The MeasureItem event along with the OnDrawItem event are the two key events
        ' that need to be handled in order to create owner drawn menus.
        Dim mi As MenuItem = CType(sender, MenuItem)
        Dim f As New Font(mi.Text.Substring(1), pointSize)
        ' Measure the string that makes up a given menu item and use it to set the 
        ' size of the menu item being drawn.
        Dim siF As SizeF = miea.Graphics.MeasureString(mi.Text, f)
        miea.ItemWidth = CInt(Math.Ceiling(siF.Width))
        miea.ItemHeight = CInt(Math.Ceiling(siF.Height))
    End Sub

    Private Sub MenuFaceNameOnDrawItem(ByVal sender As Object, ByVal diea As DrawItemEventArgs)

        ' After you have established the size of the menu with the OnMeasureItem event you can 
        ' then go ahead and drawn the item.
        ' A graphics object is passed to the OnDrawItem event that you can use to 
        ' draw the menu item.
        Dim mi As MenuItem = CType(sender, MenuItem)
        Dim grfx As Graphics = diea.Graphics
        Dim br As Brush
        Dim f As New Font(mi.Text.Substring(1), pointSize)

        ' Shows the accelerator key
        Dim strFrmt As New StringFormat()
        strFrmt.HotkeyPrefix = Drawing.Text.HotkeyPrefix.Show

        Dim rectCheck As Rectangle = diea.Bounds
        Dim d As Double = SystemInformation.MenuCheckSize.Width * rectCheck.Height / SystemInformation.MenuCheckSize.Width
        rectCheck.Width = CInt(d)

        Dim recText As Rectangle = diea.Bounds

        ' Leave enough room for a checkmark
        recText.X += rectCheck.Width

        diea.DrawBackground()

        ' Highlight the menu item as the user moves over it.
        If ((diea.State And DrawItemState.Selected) <> 0) Then
            br = SystemBrushes.HighlightText
        Else
            br = SystemBrushes.FromSystemColor(SystemColors.MenuText)
        End If

        ' Draws the string leaving room for the accelerator key
        grfx.DrawString(mi.Text, f, br, recText.Left, recText.Top, strFrmt)

    End Sub

End Class
