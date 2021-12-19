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
Imports System.WinForms

Namespace Microsoft.Samples.WinForms.VB.Menus 

    Public Class Menus 
        Inherits System.WinForms.Form 
        
        Private components As System.ComponentModel.Container 
        Private label1 As System.WinForms.Label 
        Private mainMenu As System.WinForms.MainMenu 
        Private label1ContextMenu As System.WinForms.ContextMenu 

        Private Class FontSizes 
            public shared Small As Single = 8f
            public shared Medium As Single = 12f
            public shared Large As Single = 24f
        End Class

        'Font face and size
        Private fontFace As String  = "Arial" 
        Private fontSize As Single = FontSizes.Medium 

        'Used to track which menu items are checked/unchecked
        Private mmiArial As MenuItem 
        Private mmiTimesNewRoman As MenuItem 
        Private mmiCourier As MenuItem 
        Private mmiSmall As MenuItem 
        Private mmiMedium As MenuItem 
        Private mmiLarge As MenuItem 
        Private cmiArial As MenuItem 
        Private cmiTimesNewRoman As MenuItem 
        Private cmiCourier As MenuItem 
        Private cmiSmall As MenuItem 
        Private cmiMedium As MenuItem 
        Private cmiLarge As MenuItem 

        Private miMainFormatFontChecked  As MenuItem 
        Private miMainFormatSizeChecked  As MenuItem 
        Private miContextFormatFontChecked  As MenuItem 
        Private miContextFormatSizeChecked  As MenuItem 

        Public Sub New() 
            
            MyBase.New
                                                    
            ' Required by the Windows Forms Designer
            InitializeComponent

            ' TODO: Add any constructor code after InitializeComponent call

            label1.Font = new Font(fontFace, fontSize)

            'Add File Menu
            Dim miFile As MenuItem = mainMenu.MenuItems.Add("&File")
	        miFile.MenuItems.Add(new MenuItem("&Open...", new EventHandler(AddressOf Me.FileOpen_Clicked), Shortcut.CtrlO))
            miFile.MenuItems.Add("-")     ' Gives us a seperator
            miFile.MenuItems.Add(new MenuItem("E&xit", new EventHandler(AddressOf Me.FileExit_Clicked), Shortcut.CtrlX))

            'Add Format Menu
            Dim miFormat As MenuItem = mainMenu.MenuItems.Add("F&ormat")

            'Font Face sub-menu
            mmiArial = new MenuItem("&Arial", AddressOf Me.FormatFont_Clicked)
            mmiArial.Checked = true 
            mmiArial.DefaultItem = true 
            mmiTimesNewRoman = new MenuItem("&Times New Roman", AddressOf Me.FormatFont_Clicked)
            mmiCourier = new MenuItem("&Courier New", AddressOf Me.FormatFont_Clicked)

            miFormat.MenuItems.Add( "Font &Face"  _
                                  , new EventHandler(AddressOf Me.FormatFont_Clicked) _
                                  , (new MenuItem(){ mmiArial, mmiTimesNewRoman, mmiCourier }))

            'Font Size sub-menu
            mmiSmall = new MenuItem("&Small", AddressOf Me.FormatSize_Clicked)
            mmiMedium = new MenuItem("&Medium", AddressOf Me.FormatSize_Clicked)
            mmiMedium.Checked = true 
            mmiMedium.DefaultItem = true 
            mmiLarge = new MenuItem("&Large", AddressOf Me.FormatSize_Clicked)

            miFormat.MenuItems.Add( "Font &Size" _
                                  , new EventHandler(AddressOf Me.FormatSize_Clicked) _
                                  , (new MenuItem(){ mmiSmall, mmiMedium, mmiLarge }))

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
            miMainFormatFontChecked = mmiArial
            miMainFormatSizeChecked = mmiMedium
            miContextFormatFontChecked = cmiArial
            miContextFormatSizeChecked = cmiMedium

        End Sub

        'File->Exit Menu item handler
        Private Sub FileExit_Clicked(sender As object, e As System.EventArgs)
            Me.Close
        End Sub

        'File->Open Menu item handler
        Private Sub FileOpen_Clicked(sender As object, e As System.EventArgs)
            MessageBox.Show("And why would this open a file?")
        End Sub

        'Format->Font Menu item handler
        Private Sub FormatFont_Clicked(sender As object, e As System.EventArgs)
        
            Dim miClicked As MenuItem = CType(sender, MenuItem)

            miMainFormatFontChecked.Checked = false
            miContextFormatFontChecked.Checked = false

            fontFace = miClicked.Text.Remove(0,1) 'Strip off & from menu item text

	        If (fontFace = "Arial") Then
                miMainFormatFontChecked = mmiArial
                miContextFormatFontChecked = cmiArial
            Else If (fontFace = "Times New Roman") Then
                miMainFormatFontChecked = mmiTimesNewRoman
                miContextFormatFontChecked = cmiTimesNewRoman
            Else
                miMainFormatFontChecked = mmiCourier
                miContextFormatFontChecked = cmiCourier
            End If

            miMainFormatFontChecked.Checked = true
            miContextFormatFontChecked.Checked = true

            label1.Font = new Font(fontFace, fontSize)
            
        End Sub

        'Format->Size Menu item handler
        Private Sub FormatSize_Clicked(sender As object, e As System.EventArgs)

            Dim miClicked As MenuItem = CType(sender, MenuItem)

	        miMainFormatSizeChecked.Checked = false
            miContextFormatSizeChecked.Checked = false

	        Dim fontSizeString As String = miClicked.Text
            
	        If (fontSizeString = "&Small") Then
                miMainFormatSizeChecked = mmiSmall
                miContextFormatSizeChecked = cmiSmall
		        fontSize = FontSizes.Small 
            Else If (fontSizeString = "&Large") 
                miMainFormatSizeChecked = mmiLarge
                miContextFormatSizeChecked = cmiLarge
		        fontSize = FontSizes.Large 
            Else 
                miMainFormatSizeChecked = mmiMedium
                miContextFormatSizeChecked = cmiMedium
                fontSize = FontSizes.Medium 
            End If

	        miMainFormatSizeChecked.Checked = true
            miContextFormatSizeChecked.Checked = true

            label1.Font = new Font(fontFace, fontSize)
        End Sub

        
        'Clean up any resources being used
        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub 

        
        Private Sub InitializeComponent() 

            Me.components = new System.ComponentModel.Container()
            Me.label1 = new System.WinForms.Label()
            Me.mainMenu = new System.WinForms.MainMenu()
            Me.label1ContextMenu = new System.WinForms.ContextMenu()

            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.Text = "Menus 'R Us"
            Me.Menu = mainMenu
            Me.ClientSize = new System.Drawing.Size(392, 117)

            label1.Anchor = System.WinForms.AnchorStyles.TopLeftRight
    		label1.BackColor = System.Drawing.Color.LightSteelBlue
            label1.ContextMenu = label1ContextMenu
            label1.Location = new System.Drawing.Point(16, 24)
            label1.Text = "Right Click on me - I have a context menu!"
            label1.TabIndex = 0
            label1.Size = new System.Drawing.Size(360, 50)

            Me.Controls.Add(label1)
	    End Sub


        'Run the application
        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New Menus())
        End Sub

    End Class
    
End Namespace











