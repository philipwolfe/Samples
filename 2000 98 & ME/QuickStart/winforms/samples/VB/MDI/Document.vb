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

Namespace Microsoft.Samples.WinForms.VB.MDI 

    Public Class Document 
        Inherits System.WinForms.Form 
        
        'Required by the Windows Forms Designer   
        Private components As System.ComponentModel.Container
        Private richTextBox1 As System.WinForms.RichTextBox 
        Private mainMenu As System.WinForms.MainMenu 

        Private Class FontSizes 
            public shared Small As Single = 8f
            public shared Medium As Single = 12f
            public shared Large As Single = 24f
        End Class

        private fontFace as String = "Arial"
        private fontSize as Single = FontSizes.Medium
        private miFormatFontChecked As MenuItem
        private miFormatSizeChecked As MenuItem

        Public Sub New(docName As String) 
            
            MyBase.New
                                                    
            ' Required by the Windows Forms Designer
            InitializeComponent

            ' TODO: Add any constructor code after InitializeComponent call
            Me.Text = docName
            richTextBox1.Text = docName

            'Add File Menu
            Dim miFile As MenuItem = mainMenu.MenuItems.Add("&File")
            miFile.MergeType = MenuMerge.MergeItems
            miFile.MergeOrder = 0
            
            Dim miLoadDoc As MenuItem = miFile.MenuItems.Add("&Load Document (" + docName + ")", AddressOf Me.LoadDocument_Clicked)
            miLoadDoc.MergeOrder = 105

            'Add Formatting Menu
            Dim miFormat As MenuItem = mainMenu.MenuItems.Add("F&ormat (" + docName + ")")
            miFormat.MergeType = MenuMerge.Add
            miFormat.MergeOrder = 5

            'Font Face sub-menu
            Dim miArial As MenuItem  = new MenuItem("&Arial", AddressOf Me.FormatFont_Clicked)
            Dim miTimesNewRoman As MenuItem  = new MenuItem("&Times New Roman", AddressOf Me.FormatFont_Clicked)
            Dim miCourier As MenuItem = new MenuItem("&Courier New", AddressOf Me.FormatFont_Clicked)
            miArial.Checked = true 
            miFormatFontChecked = miArial 
            miArial.DefaultItem = true 

            miFormat.MenuItems.Add( "Font &Face" _
                      , new EventHandler(AddressOf Me.FormatFont_Clicked)  _
                      , (new MenuItem() {miArial, miTimesNewRoman, miCourier }))

            'Font Size sub-menu
            Dim miSmall As MenuItem  = new MenuItem("&Small", AddressOf Me.FormatSize_Clicked)
            Dim miMedium As MenuItem = new MenuItem("&Medium", AddressOf Me.FormatSize_Clicked)
            Dim miLarge As MenuItem = new MenuItem("&Large", AddressOf Me.FormatSize_Clicked)
            miMedium.Checked = true 
            miMedium.DefaultItem = true 
            miFormatSizeChecked = miMedium 

            miFormat.MenuItems.Add( "Font &Size" _
                      , new EventHandler(AddressOf Me.FormatSize_Clicked) _
                      , (new MenuItem() { miSmall, miMedium, miLarge }))

        End Sub

        'File->Load Document Menu item handler
        Protected Sub LoadDocument_Clicked(sender As object, e As System.EventArgs)
            MessageBox.Show(Me.Text) 
        End Sub
                 
                 
        'Format->Font Menu item handler
        Protected Sub FormatFont_Clicked(sender As object, e As System.EventArgs)
            Dim miClicked As MenuItem = CType(sender, MenuItem)
            miClicked.Checked = true
            miFormatFontChecked.Checked = false
            miFormatFontChecked = miClicked 
            fontFace = miClicked.Text.Remove(0,1) 'Strip off & from menu item text
            richTextBox1.Font = new Font(fontFace, fontSize)
        End Sub

        'Format->Size Menu item handler
        Protected Sub FormatSize_Clicked(sender As object, e As System.EventArgs)
            Dim miClicked As MenuItem = CType(sender, MenuItem)
            miClicked.Checked = true
            miFormatSizeChecked.Checked = false
            miFormatSizeChecked = miClicked 
            Dim fontSizeString As String = miClicked.Text
            if (fontSizeString = "&Small") Then
                fontSize = FontSizes.Small 
            else if (fontSizeString = "&Large") 
                fontSize = FontSizes.Large 
            else 
                fontSize = FontSizes.Medium 
            End If 

            richTextBox1.Font = new Font(fontFace, fontSize)
        End Sub

        'Clean up any resources being used
        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub 

        Protected Sub InitializeComponent() 

            Me.components = new System.ComponentModel.Container()
            Me.richTextBox1 = new System.WinForms.RichTextBox()
            Me.mainMenu = new System.WinForms.MainMenu()

            richTextBox1.Text = ""
            richTextBox1.Size = new System.Drawing.Size(292, 273)
            richTextBox1.TabIndex = 0
            richTextBox1.Dock = System.WinForms.DockStyle.Fill
            richTextBox1.Font = new System.Drawing.Font("TAHOMA", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)

            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.Text = ""
            Me.ClientSize = new System.Drawing.Size(392, 117)
            Me.Menu = mainMenu

            Me.Controls.Add(richTextBox1)
	    End Sub

    End Class
    
End Namespace









