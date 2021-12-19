Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Microsoft.Samples.Windows.Forms.VB.Menus

    Public Class Menus
        Inherits System.Windows.Forms.Form

        Private Class FontSizes
            Public Shared Small As Single = 8F
            Public Shared Medium As Single = 12F
            Public Shared Large As Single = 24F
        End Class

        'Font face and size
        Private fontFace As String = "Arial"
        Private fontSize As Single = FontSizes.Medium

        'Used to track which menu items are checked/unchecked
        Private mmiFont(2) As MenuItem  ' array of fonts
        Private mmiSize(2) As MenuItem  ' array of font sizes
        Private cmiArial As MenuItem
        Private cmiTimesNewRoman As MenuItem
        Private cmiCourier As MenuItem
        Private cmiSmall As MenuItem
        Private cmiMedium As MenuItem
        Private cmiLarge As MenuItem

        Private miMainFormatFontChecked As MenuItem
        Private miMainFormatSizeChecked As MenuItem
        Private miContextFormatFontChecked As MenuItem
        Private miContextFormatSizeChecked As MenuItem

        Public Sub New()

            MyBase.New()

            Menus = Me

            'This call is required by the Win Form Designer.
            InitializeComponent()

            'TODO: Add any initialization after the InitializeComponent() call

            label1.Font = New Font(fontFace, fontSize)

            'Add File Menu
            Dim miFile As MenuItem = mainMenu.MenuItems.Add("&File")
            miFile.MenuItems.Add(New MenuItem("&Open...", New EventHandler(AddressOf Me.FileOpen_Clicked), Shortcut.CtrlO))
            miFile.MenuItems.Add("-")     ' Gives us a seperator
            miFile.MenuItems.Add(New MenuItem("E&xit", New EventHandler(AddressOf Me.FileExit_Clicked), Shortcut.CtrlX))

            'Add Format Menu
            Dim miFormat As MenuItem = mainMenu.MenuItems.Add("F&ormat")

            'Font Face sub-menu
            mmiFont(0) = New MenuItem("&Arial", New EventHandler(AddressOf Me.FormatFont_Clicked))
            mmiFont(0).Checked = True
            mmiFont(0).DefaultItem = True
            mmiFont(1) = New MenuItem("&Times New Roman", New EventHandler(AddressOf Me.FormatFont_Clicked))
            mmiFont(2) = New MenuItem("&Courier New", New EventHandler(AddressOf Me.FormatFont_Clicked))

            miFormat.MenuItems.Add("Font &Face", mmiFont)
            ', New EventHandler(AddressOf Me.FormatFont_Clicked) _
            'Font Size sub-menu
            mmiSize(0) = New MenuItem("&Small", New EventHandler(AddressOf Me.FormatSize_Clicked))
            mmiSize(1) = New MenuItem("&Medium", New EventHandler(AddressOf Me.FormatSize_Clicked))
            mmiSize(1).Checked = True
            mmiSize(1).DefaultItem = True
            mmiSize(2) = New MenuItem("&Large", New EventHandler(AddressOf Me.FormatSize_Clicked))

            miFormat.MenuItems.Add("Font &Size", mmiSize)
            ', (New MenuItem() {mmiSmall, mmiMedium, mmiLarge}))

            'Add Format to label context menu
            'Note have to add a clone because menus can't belong to 2 parents
            label1ContextMenu.MenuItems.Add(miFormat.CloneMenu)

            ' Set up the context menu items - we use these to check and uncheck items
            cmiArial = label1ContextMenu.MenuItems(0).MenuItems(0).MenuItems(0)
            cmiTimesNewRoman = label1ContextMenu.MenuItems(0).MenuItems(0).MenuItems(1)
            cmiCourier = label1ContextMenu.MenuItems(0).MenuItems(0).MenuItems(2)
            cmiSmall = label1ContextMenu.MenuItems(0).MenuItems(1).MenuItems(0)
            cmiMedium = label1ContextMenu.MenuItems(0).MenuItems(1).MenuItems(1)
            cmiLarge = label1ContextMenu.MenuItems(0).MenuItems(1).MenuItems(2)

            'We use these to track which menu items are checked
            'This is made more complex because we have both a menu and a context menu
            miMainFormatFontChecked = mmiFont(0)
            miMainFormatSizeChecked = mmiSize(1)
            miContextFormatFontChecked = mmiFont(0)
            miContextFormatSizeChecked = cmiMedium

        End Sub

        'File->Exit Menu item handler
        Private Sub FileExit_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.Close()
        End Sub

        'File->Open Menu item handler
        Private Sub FileOpen_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            MessageBox.Show("And why would this open a file?")
        End Sub

        'Format->Font Menu item handler
        Private Sub FormatFont_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)

            Dim miClicked As MenuItem = CType(sender, MenuItem)

            miMainFormatFontChecked.Checked = False
            miContextFormatFontChecked.Checked = False

            fontFace = miClicked.Text.Remove(0, 1) 'Strip off & from menu item text

            If (fontFace = "Arial") Then
                miMainFormatFontChecked = mmiFont(0)
                miContextFormatFontChecked = cmiArial
            ElseIf (fontFace = "Times New Roman") Then
                miMainFormatFontChecked = mmiFont(1)
                miContextFormatFontChecked = cmiTimesNewRoman
            Else
                miMainFormatFontChecked = mmiFont(2)
                miContextFormatFontChecked = cmiCourier
            End If

            miMainFormatFontChecked.Checked = True
            miContextFormatFontChecked.Checked = True

            label1.Font = New Font(fontFace, fontSize)

        End Sub

        'Format->Size Menu item handler
        Private Sub FormatSize_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)

            Dim miClicked As MenuItem = CType(sender, MenuItem)

            miMainFormatSizeChecked.Checked = False
            miContextFormatSizeChecked.Checked = False

            Dim fontSizeString As String = miClicked.Text

            If (fontSizeString = "&Small") Then
                miMainFormatSizeChecked = mmiSize(0)
                miContextFormatSizeChecked = cmiSmall
                fontSize = FontSizes.Small
            ElseIf (fontSizeString = "&Large") Then
                miMainFormatSizeChecked = mmiSize(2)
                miContextFormatSizeChecked = cmiLarge
                fontSize = FontSizes.Large
            Else
                miMainFormatSizeChecked = mmiSize(1)
                miContextFormatSizeChecked = cmiMedium
                fontSize = FontSizes.Medium
            End If

            miMainFormatSizeChecked.Checked = True
            miContextFormatSizeChecked.Checked = True

            label1.Font = New Font(fontFace, fontSize)
        End Sub

        'Form overrides dispose to clean up the component list.
        Public Overloads Overrides Sub Dispose()
            MyBase.Dispose()
            components.Dispose()
        End Sub

#Region " Windows Form Designer generated code "

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.Container
        Private WithEvents label1 As System.Windows.Forms.Label
        Private mainMenu As System.Windows.Forms.mainMenu
        Private label1ContextMenu As System.Windows.Forms.ContextMenu

        Private WithEvents Menus As System.Windows.Forms.Form

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.        
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.mainMenu = New System.Windows.Forms.MainMenu()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label1ContextMenu = New System.Windows.Forms.ContextMenu()

            '@design Me.TrayLargeIcon = False
            '@design Me.TrayAutoArrange = True
            '@design Me.TrayHeight = 90
            Me.Text = "Menus 'R Us"
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.Menu = mainMenu
            Me.ClientSize = New System.Drawing.Size(392, 117)

            '@design mainMenu.SetLocation(New System.Drawing.Point(7, 7))

            label1.BackColor = System.Drawing.Color.LightSteelBlue
            label1.Location = New System.Drawing.Point(16, 24)
            label1.TabIndex = 0
            label1.Anchor = CType(13, System.Windows.Forms.AnchorStyles)
            label1.Size = New System.Drawing.Size(360, 50)
            label1.Text = "Right Click on me - I have a context menu!"
            label1.ContextMenu = label1ContextMenu

            '@design label1ContextMenu.SetLocation(New System.Drawing.Point(98, 7))

            Me.Controls.Add(label1)
        End Sub

#End Region

        'Run the application
        'The main entry point for the application
        <STAThread()> Shared Sub Main()
            System.Windows.Forms.Application.Run(New Menus())
        End Sub

    End Class

End Namespace











