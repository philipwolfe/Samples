'------------------------------------------------------------------------------
'/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'/       
'/    This source code is intended only as a supplement to Microsoft
'/    Development Tools and/or on-line documentation.  See these other
'/    materials for detailed information regarding Microsoft code samples.
'/
'/ </copyright>                                                                
'------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Microsoft.Samples.Windows.Forms.VB.MDI

    Public Class Document
        Inherits System.Windows.Forms.Form

        Private Class FontSizes
            Public Shared Small As Single = 8F
            Public Shared Medium As Single = 12F
            Public Shared Large As Single = 24F
        End Class

        Private fontFace As String = "Arial"
        Private fontSize As Single = FontSizes.Medium
        Private miFormatFontChecked As System.Windows.Forms.MenuItem
        Private miFormatSizeChecked As System.Windows.Forms.MenuItem

        Public Sub New(ByVal docName As String)

            MyBase.New()

            Document = Me

            'This call is required by the Win Form Designer.
            InitializeComponent()

            'TODO: Add any initialization after the InitializeComponent() call
            Me.Text = docName

            richTextBox1.Text = docName
            richTextBox1.Font = New System.Drawing.Font(fontFace, fontSize)

            'Add File Menu
            Dim miFile As MenuItem = mainMenu.MenuItems.Add("&File")
            miFile.MergeType = MenuMerge.MergeItems
            miFile.MergeOrder = 0

            Dim miLoadDoc As MenuItem = miFile.MenuItems.Add("&Load Document (" + docName + ")", New EventHandler(AddressOf Me.LoadDocument_Clicked))
            miLoadDoc.MergeOrder = 105

            'Add Formatting Menu
            Dim miFormat As MenuItem = mainMenu.MenuItems.Add("F&ormat (" + docName + ")")
            miFormat.MergeType = MenuMerge.Add
            miFormat.MergeOrder = 5

            'Font Face sub-menu
            Dim miFonts(2) As MenuItem
            miFonts(0) = New MenuItem("&Arial", New EventHandler(AddressOf Me.FormatFont_Clicked))
            miFonts(1) = New MenuItem("&Times New Roman", New EventHandler(AddressOf Me.FormatFont_Clicked))
            miFonts(2) = New MenuItem("&Courier New", New EventHandler(AddressOf Me.FormatFont_Clicked))
            miFonts(0).Checked = True
            miFormatFontChecked = miFonts(0)
            miFonts(0).DefaultItem = True

            'Add all of the items to the font submenu
            miFormat.MenuItems.Add("Font &Face", miFonts)

            'Font Size sub-menu
            Dim miFontSize(2) As MenuItem
            miFontSize(0) = New MenuItem("&Small", New EventHandler(AddressOf Me.FormatSize_Clicked))
            miFontSize(1) = New MenuItem("&Medium", New EventHandler(AddressOf Me.FormatSize_Clicked))
            miFontSize(2) = New MenuItem("&Large", New EventHandler(AddressOf Me.FormatSize_Clicked))
            miFontSize(1).Checked = True
            miFontSize(1).DefaultItem = True
            miFormatSizeChecked = miFontSize(1)

            'Add all of the items to the font size submenu
            miFormat.MenuItems.Add("Font &Size", miFontSize)

        End Sub

        'File->Load Document Menu item handler
        Protected Sub LoadDocument_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            MessageBox.Show(Me.Text)
        End Sub


        'Format->Font Menu item handler
        Protected Sub FormatFont_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim miClicked As MenuItem = CType(sender, MenuItem)
            miClicked.Checked = True
            miFormatFontChecked.Checked = False
            miFormatFontChecked = miClicked
            fontFace = miClicked.Text.Remove(0, 1) 'Strip off & from menu item text
            richTextBox1.Font = New Font(fontFace, fontSize)
        End Sub

        'Format->Size Menu item handler
        Protected Sub FormatSize_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim miClicked As MenuItem = CType(sender, MenuItem)
            miClicked.Checked = True
            miFormatSizeChecked.Checked = False
            miFormatSizeChecked = miClicked
            Dim fontSizeString As String = miClicked.Text
            If (fontSizeString = "&Small") Then
                fontSize = FontSizes.Small
            ElseIf (fontSizeString = "&Large") Then
                fontSize = FontSizes.Large
            Else
                fontSize = FontSizes.Medium
            End If

            richTextBox1.Font = New Font(fontFace, fontSize)
        End Sub

        'Form overrides dispose to clean up the component list.
        Public Overrides Sub Dispose()
            MyBase.Dispose()
            components.Dispose()
        End Sub

#Region " Windows Form Designer generated code "

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.Container
        Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
        Private mainMenu As System.Windows.Forms.MainMenu

        Private WithEvents Document As System.Windows.Forms.Form

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.        
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
            Me.mainMenu = New System.Windows.Forms.MainMenu()

            '@design Me.TrayLargeIcon = False
            '@design Me.TrayAutoArrange = True
            '@design Me.TrayHeight = 90
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.Menu = mainMenu
            Me.ClientSize = New System.Drawing.Size(392, 117)

            richTextBox1.Size = New System.Drawing.Size(292, 273)
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
            richTextBox1.Font = New System.Drawing.Font("Tahoma", 13!, System.Drawing.FontStyle.Bold)
            richTextBox1.TabIndex = 0

            '@design mainMenu.SetLocation(New System.Drawing.Point(7, 7))
            Me.Controls.Add(richTextBox1)
        End Sub

#End Region

    End Class

End Namespace
