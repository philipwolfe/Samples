'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

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
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUpperRight As System.Windows.Forms.TextBox
    Friend WithEvents txtLowerRight As System.Windows.Forms.TextBox
    Friend WithEvents tvwLeft As System.Windows.Forms.TreeView
    Friend WithEvents tvwRight As System.Windows.Forms.TreeView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents picLeft As System.Windows.Forms.PictureBox
    Friend WithEvents picRight As System.Windows.Forms.PictureBox
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tvwLeft = New System.Windows.Forms.TreeView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUpperRight = New System.Windows.Forms.TextBox()
        Me.txtLowerRight = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tvwRight = New System.Windows.Forms.TreeView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.picLeft = New System.Windows.Forms.PictureBox()
        Me.picRight = New System.Windows.Forms.PictureBox()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 0
        Me.mnuExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = "Label with instructional text on dropping node onto TreeView"
        Me.Label5.AccessibleName = "Instructional Text Label for Example 2, drag target"
        Me.Label5.Location = New System.Drawing.Point(261, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(208, 48)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Drop the node onto an existing node. Notice that any child nodes are also dropped" & _
        "."
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = "Label with instructional text on dragging a node to the other TreeView."
        Me.Label6.AccessibleName = "Instructional Text Label for Example 2, drag source"
        Me.Label6.Location = New System.Drawing.Point(13, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(216, 48)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Click a node and drag it to the right TreeView control."
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = "Label with text: ""Example 1:..."""
        Me.Label2.AccessibleName = "Example 1 Title Label"
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(13, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(456, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Example 1: drag-and-drop using TextBox Controls"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tvwLeft
        '
        Me.tvwLeft.AccessibleDescription = "Left TreeView control with various foods listed"
        Me.tvwLeft.AccessibleName = "Drag Source TreeView"
        Me.tvwLeft.AllowDrop = True
        Me.tvwLeft.ImageIndex = -1
        Me.tvwLeft.Location = New System.Drawing.Point(13, 224)
        Me.tvwLeft.Name = "tvwLeft"
        Me.tvwLeft.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Bowtie pasta"), New System.Windows.Forms.TreeNode("Calamari"), New System.Windows.Forms.TreeNode("Ketchup"), New System.Windows.Forms.TreeNode("Mustard", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Spicy Brown Mustard"), New System.Windows.Forms.TreeNode("Yellow Mustard"), New System.Windows.Forms.TreeNode("Hot Mustard")})})
        Me.tvwLeft.SelectedImageIndex = -1
        Me.tvwLeft.Size = New System.Drawing.Size(216, 136)
        Me.tvwLeft.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = "Label with instructional text on dropping text onto TextBox controls"
        Me.Label4.AccessibleName = "Instructional Text Label for Example 1, drag targets"
        Me.Label4.Location = New System.Drawing.Point(261, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 48)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Drop the text onto one of the TextBox controls. Only the TextBox with AllowDrop=T" & _
        "rue will receive the text."
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = "Label with instructional text on dragging text to another TextBox"
        Me.Label3.AccessibleName = "Instructional Text Label for Example 1, drag source"
        Me.Label3.Location = New System.Drawing.Point(13, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 55)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Click into the TextBox and drag the text to one of the TextBox controls on the ri" & _
        "ght. This will perform a Move-Drop. Press Ctrl and drag for a Copy-Drop. "
        '
        'txtUpperRight
        '
        Me.txtUpperRight.AccessibleDescription = "TextBox with ""AllowDrop = False"""
        Me.txtUpperRight.AccessibleName = "Drag Target TextBox that doesn't allow drop"
        Me.txtUpperRight.Location = New System.Drawing.Point(261, 80)
        Me.txtUpperRight.Name = "txtUpperRight"
        Me.txtUpperRight.Size = New System.Drawing.Size(208, 20)
        Me.txtUpperRight.TabIndex = 1
        Me.txtUpperRight.Text = "AllowDrop = False"
        '
        'txtLowerRight
        '
        Me.txtLowerRight.AccessibleDescription = "TextBox with ""AllowDrop = True"""
        Me.txtLowerRight.AccessibleName = "Drag Target TextBox that allows drop"
        Me.txtLowerRight.AllowDrop = True
        Me.txtLowerRight.Location = New System.Drawing.Point(261, 112)
        Me.txtLowerRight.Name = "txtLowerRight"
        Me.txtLowerRight.Size = New System.Drawing.Size(208, 20)
        Me.txtLowerRight.TabIndex = 2
        Me.txtLowerRight.Text = "AllowDrop = True"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "Label with text: ""Example 2:..."""
        Me.Label1.AccessibleName = "Example 2 Title Label"
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(13, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(456, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Example 2: drag-and-drop using TreeView Controls"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tvwRight
        '
        Me.tvwRight.AccessibleDescription = "Right TreeView control with various foods listed"
        Me.tvwRight.AccessibleName = "Drag Target TreeView"
        Me.tvwRight.AllowDrop = True
        Me.tvwRight.ImageIndex = -1
        Me.tvwRight.Location = New System.Drawing.Point(261, 224)
        Me.tvwRight.Name = "tvwRight"
        Me.tvwRight.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Hot Sauce"), New System.Windows.Forms.TreeNode("Seafood", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Fish", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Cod"), New System.Windows.Forms.TreeNode("Salmon"), New System.Windows.Forms.TreeNode("Catfish")}), New System.Windows.Forms.TreeNode("Crab"), New System.Windows.Forms.TreeNode("Lobster")}), New System.Windows.Forms.TreeNode("Pasta", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Spaghetti"), New System.Windows.Forms.TreeNode("Fettuccini")}), New System.Windows.Forms.TreeNode("Garnishes")})
        Me.tvwRight.SelectedImageIndex = -1
        Me.tvwRight.Size = New System.Drawing.Size(208, 136)
        Me.tvwRight.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = "Label with instructional text on dropping the picture to the other PictureBox con" & _
        "trol."
        Me.Label7.AccessibleName = "Instructional Text Label for Example 3, drag target"
        Me.Label7.Location = New System.Drawing.Point(264, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(208, 48)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Drop the image into the PictureBox control. Next, drag it back to the left Pictur" & _
        "eBox control."
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = "Label with instructional text on dragging a picture to the other PictureBox contr" & _
        "ol."
        Me.Label8.AccessibleName = "Instructional Text Label for Example 3, drag source"
        Me.Label8.Location = New System.Drawing.Point(16, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(216, 48)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Click and drag the image to the right PictureBox control. The code for this is ve" & _
        "ry similar to the code for Example 1."
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = "Label with text: ""Example 3:..."""
        Me.Label9.AccessibleName = "Example 3 Title Label"
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 368)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(456, 23)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Example 3: drag-and-drop using PictureBox Controls"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picLeft
        '
        Me.picLeft.AccessibleDescription = "PictureBox with Beany.bmp as drag source"
        Me.picLeft.AccessibleName = "Drag Source PictureBox control"
        Me.picLeft.BackColor = System.Drawing.SystemColors.Window
        Me.picLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLeft.Image = CType(resources.GetObject("picLeft.Image"), System.Drawing.Bitmap)
        Me.picLeft.Location = New System.Drawing.Point(88, 448)
        Me.picLeft.Name = "picLeft"
        Me.picLeft.Size = New System.Drawing.Size(64, 56)
        Me.picLeft.TabIndex = 28
        Me.picLeft.TabStop = False
        '
        'picRight
        '
        Me.picRight.AccessibleDescription = "Empty PictureBox as drag target"
        Me.picRight.AccessibleName = "Drag Target PictureBox control"
        Me.picRight.BackColor = System.Drawing.SystemColors.Window
        Me.picRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picRight.Location = New System.Drawing.Point(328, 448)
        Me.picRight.Name = "picRight"
        Me.picRight.Size = New System.Drawing.Size(64, 56)
        Me.picRight.TabIndex = 29
        Me.picRight.TabStop = False
        '
        'txtLeft
        '
        Me.txtLeft.AccessibleDescription = "TextBox with ""Source Text"""
        Me.txtLeft.AccessibleName = "Drag Source TextBox"
        Me.txtLeft.AllowDrop = True
        Me.txtLeft.Location = New System.Drawing.Point(16, 80)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(192, 20)
        Me.txtLeft.TabIndex = 0
        Me.txtLeft.Text = "Source Text"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(482, 531)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtLeft, Me.picRight, Me.picLeft, Me.Label7, Me.Label8, Me.Label9, Me.Label5, Me.Label6, Me.Label2, Me.tvwLeft, Me.Label4, Me.Label3, Me.txtUpperRight, Me.txtLowerRight, Me.Label1, Me.tvwRight})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Standard Menu Code "
    ' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
    ' not the focus of the demo. Remove them if you wish to debug the procedures.
    ' This code simply shows the About form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        ' Open the About form in Dialog Mode
        Dim frm As New frmAbout()
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

    ' This code will close the form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        ' Close the current form
        Me.Close()
    End Sub
#End Region

    ' Declare constant for use in detecting whether the Ctrl key was pressed
    ' during the drag operation.
    Const CtrlMask As Byte = 8

    ' Handles the even that fires when the Form first loads.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' There is currently no way to set the AllowDrop property for a PictureBox
        ' in the Visual Studio designer, so they must be set explicitly in the code.
        picLeft.AllowDrop = True
        picRight.AllowDrop = True
    End Sub

    ' Handles the MouseDown event for the left TextBox. This event fires when the
    ' mouse is in the control's bounds and the mouse button is clicked.
    Private Sub TextBoxLeft_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLeft.MouseDown
        If e.Button = MouseButtons.Left Then
            txtLeft.SelectAll()
            'invoke the drag and drop operation
            txtLeft.DoDragDrop(txtLeft.SelectedText, DragDropEffects.Move Or DragDropEffects.Copy)
        End If
    End Sub

    ' Handles the DragDrop event for the lower right TextBox. This event fires
    ' when the mouse button is released, terminating the drag-and-drop operation.
    Private Sub TextBoxLowerRight_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtLowerRight.DragDrop
        txtLowerRight.Text = e.Data.GetData(DataFormats.Text).ToString

        ' If the Ctrl key was not pressed, remove the source text to effect a 
        ' drag-and-drop move.
        If (e.KeyState And CtrlMask) <> CtrlMask Then
            txtLeft.Text = ""
        End If
    End Sub

    ' Handles the DragEnter event for the lower right TextBox. DragEnter is the
    ' event that fires when an object is dragged into the control's bounds.
    Private Sub TextBoxLowerRight_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtLowerRight.DragEnter
        ' Check to be sure that the drag content is the correct type for this 
        ' control. If not, reject the drop.
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' If the Ctrl key was pressed during the drag operation then perform
            ' a Copy. If not, perform a Move.
            If (e.KeyState And CtrlMask) = CtrlMask Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ' Handles the MouseDown event for both PictureBox controls. This event fires 
    ' when the mouse is in the control's bounds and the mouse button is 
    ' clicked.
    Private Sub PictureBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picLeft.MouseDown, picRight.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim pic As PictureBox = CType(sender, PictureBox)
            'invoke the drag and drop operation
            If Not pic.Image Is Nothing Then
                pic.DoDragDrop(pic.Image, DragDropEffects.Move Or DragDropEffects.Copy)
            End If
        End If
    End Sub

    ' Handles the DragEnter event for both PictureBox controls. DragEnter is the
    ' event that fires when an object is dragged into the control's bounds.
    Private Sub PictureBox_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles picLeft.DragEnter, picRight.DragEnter
        ' Check to be sure that the drag content is the correct type for this 
        ' control. If not, reject the drop.
        If (e.Data.GetDataPresent(DataFormats.Bitmap)) Then
            ' If the Ctrl key was pressed during the drag operation then perform
            ' a Copy. If not, perform a Move.
            If (e.KeyState And CtrlMask) = CtrlMask Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ' Handles the DragDrop event for both PictureBox controls. One handler can be 
    ' used for both PictureBox controls by casting the sender and then checking the
    ' Name property to determine which control should remove the image.
    Private Sub PictureBox_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles picLeft.DragDrop, picRight.DragDrop
        Dim pic As PictureBox = CType(sender, PictureBox)
        pic.Image = CType(e.Data.GetData(DataFormats.Bitmap), Bitmap)

        ' Cause the image in the other PictureBox (that is, the PictureBox that was
        ' not the sender in the DragDrop event) to be removed if the Ctrl key was
        ' not pressed.
        If (e.KeyState And CtrlMask) <> CtrlMask Then
            If pic.Name = "picLeft" Then
                picRight.Image = Nothing
            Else
                picLeft.Image = Nothing
            End If
        End If
    End Sub

    ' Handles the DragDrop event for both TreeView controls.
    Private Sub TreeView_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvwLeft.DragDrop, tvwRight.DragDrop
        ' Initialize variable that holds the node dragged by the user.
        Dim OriginationNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

        ' Calling GetDataPresent is a little different for a TreeView than for an
        ' image or text because a TreeNode is not a member of the DataFormats
        ' class. That is, it's not a predefined type. As such, you need to use a
        ' different overload, one that takes the type as a string.
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", False) Then
            Dim pt As Point
            Dim DestinationNode As TreeNode

            ' Use PointToClient to compute the location of the mouse over the
            ' destination TreeView.
            pt = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
            ' Use this Point to get the closest node in the destination TreeView.
            DestinationNode = CType(sender, TreeView).GetNodeAt(pt)

            ' The If statement ensures that the user doesn't completely lose the
            ' node if they accidentally release the mouse button over the node they
            ' attempted to drag. Without a check to see if the original node is the
            ' same as the destination node, they could make the node disappear.
            If Not DestinationNode.TreeView Is OriginationNode.TreeView Then
                DestinationNode.Nodes.Add(CType(OriginationNode.Clone, TreeNode))
                ' Expand the parent node when adding the new node so that the drop
                ' is obvious. Without this, only a + symbol would appear.
                DestinationNode.Expand()
                ' If the Ctrl key was not pressed, remove the original node to 
                ' effect a drag-and-drop move.
                If (e.KeyState And CtrlMask) <> CtrlMask Then
                    OriginationNode.Remove()
                End If
            End If
        End If
    End Sub

    ' Handles the DragEnter event for both TreeView controls.
    Private Sub TreeView_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvwRight.DragEnter, tvwLeft.DragEnter
        ' Check to be sure that the drag content is the correct type for this 
        ' control. If not, reject the drop.
        If (e.Data.GetDataPresent("System.Windows.Forms.TreeNode")) Then
            ' If the Ctrl key was pressed during the drag operation then perform
            ' a Copy. If not, perform a Move.
            If (e.KeyState And CtrlMask) = CtrlMask Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ' Handles the ItemDrag event for both TreeView controls.
    Private Sub TreeView_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles tvwRight.ItemDrag, tvwLeft.ItemDrag
        If e.Button = MouseButtons.Left Then
            'invoke the drag and drop operation
            DoDragDrop(e.Item, DragDropEffects.Move Or DragDropEffects.Copy)
        End If
    End Sub

End Class