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

    Public Class MainForm
        Inherits System.Windows.Forms.Form

        Private windowCount As Integer = 0

        Public Sub New()

            MyBase.New()

            MainForm = Me

            'This call is required by the Win Form Designer.
            InitializeComponent()

            'TODO: Add any initialization after the InitializeComponent() call            

            'Setup MDI stuff
            Me.IsMdiContainer = True
            AddHandler Me.MDIChildActivate, AddressOf Me.MDIChildActivated

            'Add File Menu
            Dim miFile As MenuItem = mainMenu.MenuItems.Add("&File")
            miFile.MergeOrder = 0
            miFile.MergeType = MenuMerge.MergeItems

            Dim miAddDoc As MenuItem = New MenuItem("&Add Document", New EventHandler(AddressOf Me.FileAdd_Clicked), Shortcut.CtrlA)
            miAddDoc.MergeOrder = 100

            Dim miExit As MenuItem = New MenuItem("E&xit", New EventHandler(AddressOf Me.FileExit_Clicked), Shortcut.CtrlX)
            miExit.MergeOrder = 110

            miFile.MenuItems.Add(miAddDoc)
            miFile.MenuItems.Add("-")     ' Gives us a seperator
            miFile.MenuItems.Add(miExit)

            'Add Window Menu
            Dim miWindow As MenuItem = mainMenu.MenuItems.Add("&Window")
            miWindow.MergeOrder = 10
            miWindow.MenuItems.Add("&Cascade", New EventHandler(AddressOf Me.WindowCascade_Clicked))
            miWindow.MenuItems.Add("Tile &Horizontal", New EventHandler(AddressOf Me.WindowTileH_Clicked))
            miWindow.MenuItems.Add("Tile &Vertical", New EventHandler(AddressOf Me.WindowTileV_Clicked))
            miWindow.MdiList = True  'Adds the MDI Window List to the bottom of the menu


            AddDocument() 'Add an initial doc
        End Sub


        'Add a browser document 
        Private Sub AddDocument()
            windowCount = windowCount + 1
            'Create the form
            Dim doc As Document = New Document("Document " + windowCount.ToString())
            doc.MdiParent = Me                   'Set its MDI parent to this form
            doc.Show()                           'Show the form
        End Sub


        'File->Add Menu item handler
        Private Sub FileAdd_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            AddDocument()
        End Sub


        'File->Exit Menu item handler
        Private Sub FileExit_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.Close()
        End Sub


        'One of the MDI Child windows has been activated - set the status bar
        'text to the window title
        Private Sub MDIChildActivated(ByVal sender As Object, ByVal e As System.EventArgs)
            If (Me.ActiveMdiChild Is Nothing) Then
                statusBar1.Text = ""
            Else
                statusBar1.Text = Me.ActiveMdiChild.Text
            End If
        End Sub

        'Window->Cascade Menu item handler
        Private Sub WindowCascade_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.LayoutMdi(MdiLayout.Cascade)
        End Sub


        'Window->Tile Horizontally Menu item handler
        Private Sub WindowTileH_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.LayoutMdi(MdiLayout.TileHorizontal)
        End Sub


        'Window->Tile Vertically Menu item handler
        Private Sub WindowTileV_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.LayoutMdi(MdiLayout.TileVertical)
        End Sub

        'Form overrides dispose to clean up the component list.        
        Public Overrides Sub Dispose()
            MyBase.Dispose()
            ' components.Dispose()
        End Sub

#Region " Windows Form Designer generated code "

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.Container

        Private mainMenu As System.Windows.Forms.MainMenu
        Private WithEvents statusBar1 As System.Windows.Forms.StatusBar

        Private WithEvents MainForm As System.Windows.Forms.Form

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.        
        Private Sub InitializeComponent()
            Me.statusBar1 = New System.Windows.Forms.StatusBar()
            Me.mainMenu = New System.Windows.Forms.MainMenu()
            Me.SuspendLayout()
            '
            'statusBar1
            '
            Me.statusBar1.BackColor = System.Drawing.SystemColors.Control
            Me.statusBar1.Location = New System.Drawing.Point(0, 180)
            Me.statusBar1.Name = "statusBar1"
            Me.statusBar1.Size = New System.Drawing.Size(450, 20)
            Me.statusBar1.TabIndex = 1
            '
            'mainMenu
            '
            '
            'MainForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(450, 200)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.statusBar1})
            Me.Menu = Me.mainMenu
            Me.Name = "MainForm"
            Me.Text = "MDI Example"
            Me.ResumeLayout(False)

        End Sub

#End Region

        'Run the application
        'The main entry point for the application
        <STAThread()> Shared Sub Main()
            System.Windows.Forms.Application.Run(New MainForm())
        End Sub

    End Class

End Namespace


