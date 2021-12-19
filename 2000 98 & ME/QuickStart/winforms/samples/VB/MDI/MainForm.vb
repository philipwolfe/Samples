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
   
    Public Class MainForm
        Inherits System.WinForms.Form
      
        'Required by the Windows Forms Designer   
        Private components As System.ComponentModel.Container
        Private mainMenu As System.WinForms.MainMenu
        Private statusBar1 As System.WinForms.StatusBar

        private windowCount As Integer = 0 

        Public Sub New()
            MyBase.New
    
            'This call is required by the Windows Forms Designer.
            InitializeComponent

            'Setup MDI stuff
            Me.IsMDIContainer = true
            AddHandler Me.MDIChildActivate, AddressOf Me.MDIChildActivated

            'Add File Menu
            Dim miFile As MenuItem = mainMenu.MenuItems.Add("&File")
            miFile.MergeOrder=0
            miFile.MergeType = MenuMerge.MergeItems
            
            Dim miAddDoc As MenuItem = new MenuItem("&Add Document", new EventHandler(AddressOf Me.FileAdd_Clicked), Shortcut.CtrlA)
            miAddDoc.MergeOrder=100

            Dim miExit As MenuItem = new MenuItem("E&xit", new EventHandler(AddressOf Me.FileExit_Clicked), Shortcut.CtrlX)
            miExit.MergeOrder=110

            miFile.MenuItems.Add(miAddDoc)
            miFile.MenuItems.Add("-")     ' Gives us a seperator
            miFile.MenuItems.Add(miExit)

            'Add Window Menu
            Dim miWindow As MenuItem = mainMenu.MenuItems.Add("&Window")
            miWindow.MergeOrder = 10
            miWindow.MenuItems.Add("&Cascade", new EventHandler(AddressOf Me.WindowCascade_Clicked))
            miWindow.MenuItems.Add("Tile &Horizontal", new EventHandler(AddressOf Me.WindowTileH_Clicked))
            miWindow.MenuItems.Add("Tile &Vertical", new EventHandler(AddressOf Me.WindowTileV_Clicked))
            miWindow.MDIList = true  'Adds the MDI Window List to the bottom of the menu


            AddDocument() 'Add an initial doc
        End Sub
              

        'Add a browser document 
        Private Sub AddDocument() 
            windowCount = windowCount + 1
                                                'Create the form
            Dim doc As Document = new Document("Document " + windowCount.ToString()) 
            doc.MDIParent = Me                   'Set its MDI parent to this form
            doc.Show()                           'Show the form
        End Sub


        'File->Add Menu item handler
        Protected Sub FileAdd_Clicked(sender As object, e As System.EventArgs)
            AddDocument() 
        End Sub


        'File->Exit Menu item handler
        Protected Sub FileExit_Clicked(sender As object, e As System.EventArgs)
            Me.Close
        End Sub


        'One of the MDI Child windows has been activated - set the status bar
        'text to the window title
        Protected Sub MDIChildActivated(sender As object, e As System.EventArgs)
            If (Me.ActiveMDIChild Is Nothing) Then
                statusBar1.Text = ""
            Else
                statusBar1.Text = Me.ActiveMDIChild.Text
            End If 
        End Sub

        'Window->Cascade Menu item handler
        Protected Sub WindowCascade_Clicked(sender As object, e As System.EventArgs)
            Me.LayoutMDI(MDILayout.Cascade)   
        End Sub


        'Window->Tile Horizontally Menu item handler
        Protected Sub WindowTileH_Clicked(sender As object, e As System.EventArgs)
            Me.LayoutMDI(MDILayout.TileHorizontal)
        End Sub


        'Window->Tile Vertically Menu item handler
        Protected Sub WindowTileV_Clicked(sender As object, e As System.EventArgs)
            Me.LayoutMDI(MDILayout.TileVertical)
        End Sub


        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub

        Protected Sub InitializeComponent()

            Me.components = new System.ComponentModel.Container()
            Me.mainMenu = new System.WinForms.MainMenu()
            Me.statusBar1 = new System.WinForms.StatusBar()

            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.Text = "MDI Example"
            Me.Menu = mainMenu
            Me.ClientSize = new System.Drawing.Size(450, 200)

            statusBar1.BackColor = System.Drawing.SystemColors.Control
            statusBar1.Size = new System.Drawing.Size(496, 20)
            statusBar1.TabIndex = 1
            statusBar1.Text = ""
            statusBar1.Location = new System.Drawing.Point(0, 273)

            Me.Controls.Add(statusBar1)
	    End Sub

        'Run the application
        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New MainForm())
        End Sub


    End Class

End NameSpace


