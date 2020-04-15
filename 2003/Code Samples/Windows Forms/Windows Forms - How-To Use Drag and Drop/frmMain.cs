//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.Windows.Forms;
using System.Drawing;

public class frmMain: System.Windows.Forms.Form 
{

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

	public frmMain() 
		{

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.

		AssemblyInfo ainfo = new AssemblyInfo();

		this.Text = ainfo.Title;

		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

	}

	//Form overrides dispose to clean up the component list.

	protected override void Dispose(bool disposing) {

		if (disposing) {
			if (components != null) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.

	private System.Windows.Forms.MainMenu mnuMain;
	private System.Windows.Forms.MenuItem mnuFile;
	private System.Windows.Forms.MenuItem mnuExit;
	private System.Windows.Forms.MenuItem mnuHelp;
	private System.Windows.Forms.MenuItem mnuAbout;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.Label Label6;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.TextBox txtUpperRight;
    private System.Windows.Forms.TextBox txtLowerRight;
    private System.Windows.Forms.TreeView tvwLeft;
    private System.Windows.Forms.TreeView tvwRight;
    private System.Windows.Forms.Label Label7;
    private System.Windows.Forms.Label Label8;
    private System.Windows.Forms.Label Label9;
    private System.Windows.Forms.PictureBox picLeft;
    private System.Windows.Forms.PictureBox picRight;
    private System.Windows.Forms.TextBox txtLeft;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.Label5 = new System.Windows.Forms.Label();

        this.Label6 = new System.Windows.Forms.Label();

        this.Label2 = new System.Windows.Forms.Label();

        this.tvwLeft = new System.Windows.Forms.TreeView();

        this.Label4 = new System.Windows.Forms.Label();

        this.Label3 = new System.Windows.Forms.Label();

        this.txtUpperRight = new System.Windows.Forms.TextBox();

        this.txtLowerRight = new System.Windows.Forms.TextBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.tvwRight = new System.Windows.Forms.TreeView();

        this.Label7 = new System.Windows.Forms.Label();

        this.Label8 = new System.Windows.Forms.Label();

        this.Label9 = new System.Windows.Forms.Label();

        this.picLeft = new System.Windows.Forms.PictureBox();

        this.picRight = new System.Windows.Forms.PictureBox();

        this.txtLeft = new System.Windows.Forms.TextBox();

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

        //

        //mnuFile

        //

        this.mnuFile.Index = 0;

        this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.mnuFile.Text = "&File";

        //

        //mnuExit

        //

        this.mnuExit.Index = 0;

        this.mnuExit.Text = "E&xit";

        //

        //mnuHelp

        //

        this.mnuHelp.Index = 1;

        this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.mnuHelp.Text = "&Help";

        //

        //mnuAbout

        //

        this.mnuAbout.Index = 0;

        this.mnuAbout.Text = "Text Comes from AssemblyInfo";

        //

        //Label5

        //

        this.Label5.AccessibleDescription = "Label with instructional text on dropping node onto TreeView";

        this.Label5.AccessibleName = "Instructional Text Label for Example 2, drag target";

        this.Label5.Location = new System.Drawing.Point(261, 176);

        this.Label5.Name = "Label5";

        this.Label5.Size = new System.Drawing.Size(208, 48);

        this.Label5.TabIndex = 10;

        this.Label5.Text = "Drop the node onto an existing node. Notice that any child nodes are also dropped.";

        //

        //Label6

        //

        this.Label6.AccessibleDescription = "Label with instructional text on dragging a node to the other TreeView.";

        this.Label6.AccessibleName = "Instructional Text Label for Example 2, drag source";

        this.Label6.Location = new System.Drawing.Point(13, 176);

        this.Label6.Name = "Label6";

        this.Label6.Size = new System.Drawing.Size(216, 48);

        this.Label6.TabIndex = 9;

        this.Label6.Text = "Click a node and drag it to the right TreeView control.";

        //

        //Label2

        //

        this.Label2.AccessibleDescription = @"Label with text: ""Example 1:...""";

        this.Label2.AccessibleName = "Example 1 Title Label";

        this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)8.25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (Byte) 0);

        this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;

        this.Label2.Location = new System.Drawing.Point(13, 0);

        this.Label2.Name = "Label2";

        this.Label2.Size = new System.Drawing.Size(456, 23);

        this.Label2.TabIndex = 5;

        this.Label2.Text = "Example 1: drag-and-drop using TextBox Controls";

        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //tvwLeft

        //

        this.tvwLeft.AccessibleDescription = "Left TreeView control with various foods listed";

        this.tvwLeft.AccessibleName = "Drag Source TreeView";

        this.tvwLeft.AllowDrop = true;

        this.tvwLeft.ImageIndex = -1;

        this.tvwLeft.Location = new System.Drawing.Point(13, 224);

        this.tvwLeft.Name = "tvwLeft";

        this.tvwLeft.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {new System.Windows.Forms.TreeNode("Bowtie pasta"), new System.Windows.Forms.TreeNode("Calamari"), new System.Windows.Forms.TreeNode("Ketchup"), new System.Windows.Forms.TreeNode("Mustard", new System.Windows.Forms.TreeNode[] {new System.Windows.Forms.TreeNode("Spicy Brown Mustard"), new System.Windows.Forms.TreeNode("Yellow Mustard"), new System.Windows.Forms.TreeNode("Hot Mustard")})});

        this.tvwLeft.SelectedImageIndex = -1;

        this.tvwLeft.Size = new System.Drawing.Size(216, 136);

        this.tvwLeft.TabIndex = 3;

        //

        //Label4

        //

        this.Label4.AccessibleDescription = "Label with instructional text on dropping text onto TextBox controls";

        this.Label4.AccessibleName = "Instructional Text Label for Example 1, drag targets";

        this.Label4.Location = new System.Drawing.Point(261, 26);

        this.Label4.Name = "Label4";

        this.Label4.Size = new System.Drawing.Size(208, 48);

        this.Label4.TabIndex = 7;

        this.Label4.Text = "Drop the text onto one of the TextBox controls. Only the TextBox with AllowDrop=True will receive the text.";

        //

        //Label3

        //

        this.Label3.AccessibleDescription = "Label with instructional text on dragging text to another TextBox";

        this.Label3.AccessibleName = "Instructional Text Label for Example 1, drag source";

        this.Label3.Location = new System.Drawing.Point(13, 25);

        this.Label3.Name = "Label3";

        this.Label3.Size = new System.Drawing.Size(216, 55);

        this.Label3.TabIndex = 6;

        this.Label3.Text = "Click into the TextBox and drag the text to one of the TextBox controls on the right. This will perform a Move-Drop. Press Ctrl and drag for a Copy-Drop. ";

        //

        //txtUpperRight

        //

        this.txtUpperRight.AccessibleDescription = @"TextBox with ""AllowDrop = false""";

        this.txtUpperRight.AccessibleName = "Drag Target TextBox that doesn't allow drop";

        this.txtUpperRight.Location = new System.Drawing.Point(261, 80);

        this.txtUpperRight.Name = "txtUpperRight";

        this.txtUpperRight.Size = new System.Drawing.Size(208, 20);

        this.txtUpperRight.TabIndex = 1;

        this.txtUpperRight.Text = "AllowDrop = false";

        //

        //txtLowerRight

        //

        this.txtLowerRight.AccessibleDescription = @"TextBox with ""AllowDrop = true""";

        this.txtLowerRight.AccessibleName = "Drag Target TextBox that allows drop";

        this.txtLowerRight.AllowDrop = true;

        this.txtLowerRight.Location = new System.Drawing.Point(261, 112);

        this.txtLowerRight.Name = "txtLowerRight";

        this.txtLowerRight.Size = new System.Drawing.Size(208, 20);

        this.txtLowerRight.TabIndex = 2;

        this.txtLowerRight.Text = "AllowDrop = true";

        //

        //Label1

        //

        this.Label1.AccessibleDescription = @"Label with text: ""Example 2:...""";

        this.Label1.AccessibleName = "Example 2 Title Label";

        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)8.25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (Byte) 0) ;

        this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;

        this.Label1.Location = new System.Drawing.Point(13, 144);

        this.Label1.Name = "Label1";

        this.Label1.Size = new System.Drawing.Size(456, 23);

        this.Label1.TabIndex = 8;

        this.Label1.Text = "Example 2: drag-and-drop using TreeView Controls";

        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //tvwRight

        //

        this.tvwRight.AccessibleDescription = "Right TreeView control with various foods listed";

        this.tvwRight.AccessibleName = "Drag Target TreeView";

        this.tvwRight.AllowDrop = true;

        this.tvwRight.ImageIndex = -1;

        this.tvwRight.Location = new System.Drawing.Point(261, 224);

        this.tvwRight.Name = "tvwRight";

        this.tvwRight.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {new System.Windows.Forms.TreeNode("Hot Sauce"), new System.Windows.Forms.TreeNode("Seafood", new System.Windows.Forms.TreeNode[] {new System.Windows.Forms.TreeNode("Fish", new System.Windows.Forms.TreeNode[] {new System.Windows.Forms.TreeNode("Cod"), new System.Windows.Forms.TreeNode("Salmon"), new System.Windows.Forms.TreeNode("Catfish")}), new System.Windows.Forms.TreeNode("Crab"), new System.Windows.Forms.TreeNode("Lobster")}), new System.Windows.Forms.TreeNode("Pasta", new System.Windows.Forms.TreeNode[] {new System.Windows.Forms.TreeNode("Spaghetti"), new System.Windows.Forms.TreeNode("Fettuccini")}), new System.Windows.Forms.TreeNode("Garnishes")});

        this.tvwRight.SelectedImageIndex = -1;

        this.tvwRight.Size = new System.Drawing.Size(208, 136);

        this.tvwRight.TabIndex = 4;

        //

        //Label7

        //

        this.Label7.AccessibleDescription = "Label with instructional text on dropping the picture to the other PictureBox control.";

        this.Label7.AccessibleName = "Instructional Text Label for Example 3, drag target";

        this.Label7.Location = new System.Drawing.Point(264, 400);

        this.Label7.Name = "Label7";

        this.Label7.Size = new System.Drawing.Size(208, 48);

        this.Label7.TabIndex = 13;

        this.Label7.Text = "Drop the image into the PictureBox control. Next, drag it back to the left PictureBox control.";

        //

        //Label8

        //

        this.Label8.AccessibleDescription = "Label with instructional text on dragging a picture to the other PictureBox control.";

        this.Label8.AccessibleName = "Instructional Text Label for Example 3, drag source";

        this.Label8.Location = new System.Drawing.Point(16, 400);

        this.Label8.Name = "Label8";

        this.Label8.Size = new System.Drawing.Size(216, 48);

        this.Label8.TabIndex = 12;

        this.Label8.Text = "Click and drag the image to the right PictureBox control. The code for this is ve" +

        "ry similar to the code for Example 1.";

        //

        //Label9

        //

        this.Label9.AccessibleDescription = @"Label with text: ""Example 3:...""";

        this.Label9.AccessibleName = "Example 3 Title Label";

        this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)8.25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (Byte) 0);

        this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;

        this.Label9.Location = new System.Drawing.Point(16, 368);

        this.Label9.Name = "Label9";

        this.Label9.Size = new System.Drawing.Size(456, 23);

        this.Label9.TabIndex = 11;

        this.Label9.Text = "Example 3: drag-and-drop using PictureBox Controls";

        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        //

        //picLeft

        //

        this.picLeft.AccessibleDescription = "PictureBox with Beany.bmp drag source";

        this.picLeft.AccessibleName = "Drag Source PictureBox control";

        this.picLeft.BackColor = System.Drawing.SystemColors.Window;

        this.picLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.picLeft.Image = (System.Drawing.Bitmap) resources.GetObject("picLeft.Image");

        this.picLeft.Location = new System.Drawing.Point(88, 448);

        this.picLeft.Name = "picLeft";

        this.picLeft.Size = new System.Drawing.Size(64, 56);

        this.picLeft.TabIndex = 28;

        this.picLeft.TabStop = false;

        //

        //picRight

        //

        this.picRight.AccessibleDescription = "Empty PictureBox drag target";

        this.picRight.AccessibleName = "Drag Target PictureBox control";

        this.picRight.BackColor = System.Drawing.SystemColors.Window;

        this.picRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.picRight.Location = new System.Drawing.Point(328, 448);

        this.picRight.Name = "picRight";

        this.picRight.Size = new System.Drawing.Size(64, 56);

        this.picRight.TabIndex = 29;

        this.picRight.TabStop = false;

        //

        //txtLeft

        //

        this.txtLeft.AccessibleDescription = @"TextBox with ""Source Text""";

        this.txtLeft.AccessibleName = "Drag Source TextBox";

        this.txtLeft.AllowDrop = true;

        this.txtLeft.Location = new System.Drawing.Point(16, 80);

        this.txtLeft.Name = "txtLeft";

        this.txtLeft.Size = new System.Drawing.Size(192, 20);

        this.txtLeft.TabIndex = 0;

        this.txtLeft.Text = "Source Text";

        //

        //frmMain

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(482, 531);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtLeft, this.picRight, this.picLeft, this.Label7, this.Label8, this.Label9, this.Label5, this.Label6, this.Label2, this.tvwLeft, this.Label4, this.Label3, this.txtUpperRight, this.txtLowerRight, this.Label1, this.tvwRight});

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.MaximizeBox = false;

        this.Menu = this.mnuMain;

        this.Name = "frmMain";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        this.Text = "Title Comes from Assembly Info";

        this.ResumeLayout(false);
		
		this.Load +=new EventHandler(frmMain_Load);
		this.txtLeft.MouseDown +=new MouseEventHandler(TextBoxLeft_MouseDown);
		this.txtLowerRight.DragDrop +=new DragEventHandler(TextBoxLowerRight_DragDrop);
		this.txtLowerRight.DragEnter +=new DragEventHandler(TextBoxLowerRight_DragEnter);
		this.picLeft.MouseDown +=new MouseEventHandler(PictureBox_MouseDown);
		this.picRight.MouseDown +=new MouseEventHandler(PictureBox_MouseDown);
		this.picLeft.DragEnter +=new DragEventHandler(PictureBox_DragEnter);
		this.picRight.DragEnter +=new DragEventHandler(PictureBox_DragEnter);
		this.picLeft.DragDrop +=new DragEventHandler(PictureBox_DragDrop);
		this.picRight.DragDrop +=new DragEventHandler(PictureBox_DragDrop);
		this.tvwLeft.DragDrop +=new DragEventHandler(TreeView_DragDrop);
		this.tvwRight.DragDrop +=new DragEventHandler(TreeView_DragDrop);
		this.tvwLeft.DragEnter +=new DragEventHandler(TreeView_DragEnter);
		this.tvwRight.DragEnter +=new DragEventHandler(TreeView_DragEnter);
		this.tvwRight.ItemDrag +=new ItemDragEventHandler(TreeView_ItemDrag);
		this.tvwLeft.ItemDrag +=new ItemDragEventHandler(TreeView_ItemDrag);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
    }

#endregion

#region " Standard Menu Code "

    // This code simply shows the About form.

    private void mnuAbout_Click(object sender, System.EventArgs e) 
		{

        // Open the About form in Dialog Mode
        frmAbout frm = new frmAbout();
        frm.ShowDialog(this);
        frm.Dispose();
    }

    // This code will close the form.

    private void mnuExit_Click(object sender, System.EventArgs e) 
		{

        // Close the current form

        this.Close();

    }

#endregion

    // Declare constant for use in detecting whether the Ctrl key was pressed
    // during the drag operation.

    const byte CtrlMask = 8;

    // the even that fires when the Form first loads.

    private void frmMain_Load(object sender, System.EventArgs e) 
		{

        // There is currently no way to set the AllowDrop property for a PictureBox
        // in the Visual Studio designer, so they must be set explicitly in the code.

        picLeft.AllowDrop = true;
        picRight.AllowDrop = true;

    }

    // the MouseDown event for the left TextBox. This event fires when the
    // mouse is in the control's bounds and the mouse button is clicked.

    private void TextBoxLeft_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
        if (e.Button == MouseButtons.Left)
			{
            txtLeft.SelectAll();
            //invoke the drag and drop operation
            txtLeft.DoDragDrop(txtLeft.SelectedText, DragDropEffects.Move | DragDropEffects.Copy);
        }
    }

    // the DragDrop event for the lower right TextBox. This event fires
    // when the mouse button is released, terminating the drag-and-drop operation.

    private void TextBoxLowerRight_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
        txtLowerRight.Text = e.Data.GetData(DataFormats.Text).ToString();

        // if the Ctrl key was not pressed, remove the source text to effect a 
        // drag-and-drop move.

        if ((e.KeyState & CtrlMask) != CtrlMask) {
            txtLeft.Text = "";
        }
    }

    // the DragEnter event for the lower right TextBox. DragEnter is the
    // event that fires when an object is dragged into the control's bounds.

    private void TextBoxLowerRight_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) 
		{
        // Check to be sure that the drag content is the correct type for this 
        // control. if not, reject the drop.

        if (e.Data.GetDataPresent(DataFormats.Text)) {
            // if the Ctrl key was pressed during the drag operation then perform
            // a Copy. if not, perform a Move.

            if ((e.KeyState & CtrlMask) == CtrlMask) 
				{
                e.Effect = DragDropEffects.Copy;
				}
            else {
                e.Effect = DragDropEffects.Move;
				}
			}
        else {
            e.Effect = DragDropEffects.None;
        }

    }

    // the MouseDown event for both PictureBox controls. This event fires 
    // when the mouse is in the control's bounds and the mouse button is 
    // clicked.

    private void PictureBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
        if (e.Button == MouseButtons.Left) 
			{
            PictureBox pic = (PictureBox) sender;

            //invoke the drag and drop operation

            if (pic.Image != null) 
				{
                pic.DoDragDrop(pic.Image, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }
    }

    // the DragEnter event for both PictureBox controls. DragEnter is the
    // event that fires when an object is dragged into the control's bounds.

    private void PictureBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) 
		{
        // Check to be sure that the drag content is the correct type for this 
        // control. if not, reject the drop.

        if (e.Data.GetDataPresent(DataFormats.Bitmap)) 
			{
            // if the Ctrl key was pressed during the drag operation then perform
            // a Copy. if not, perform a Move.

            if ((e.KeyState & CtrlMask) == CtrlMask) 
				{
                e.Effect = DragDropEffects.Copy;
				}
            else 
				{
                e.Effect = DragDropEffects.Move;
				}
			}
        else 
			{
            e.Effect = DragDropEffects.None;
			}

    }

    // the DragDrop event for both PictureBox controls. One handler can be 
    // used for both PictureBox controls by casting the sender and then checking the
    // Name property to determine which control should remove the image.

    private void PictureBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) 
		{
        PictureBox pic = (PictureBox) sender;
        pic.Image = (Bitmap) e.Data.GetData(DataFormats.Bitmap);

        // Cause the image in the other PictureBox (that is, the PictureBox that was
        // not the sender in the DragDrop event) to be removed if the Ctrl key was
        // not pressed.

        if ((e.KeyState & CtrlMask) != CtrlMask) 
			{
            if (pic.Name == "picLeft") 
				{
                picRight.Image = null;
				}
            else 
				{
                picLeft.Image = null;
            }

        }

    }

    // the DragDrop event for both TreeView controls.

    private void TreeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
        // Initialize variable that holds the node dragged by the user.

        TreeNode OriginationNode = (TreeNode) e.Data.GetData("System.Windows.Forms.TreeNode");

        // Calling GetDataPresent is a little different for a TreeView than for an
        // image or text because a TreeNode is not a member of the DataFormats
        // class. That is, it's not a predefined type. such, you need to use a
        // different overload, one that takes the type a string.

        if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false)) 
			{

            // Use PointToClient to compute the location of the mouse over the
            // destination TreeView.

            Point pt = ((TreeView) sender).PointToClient(new Point(e.X, e.Y));

            // Use this Point to get the closest node in the destination TreeView.

            TreeNode DestinationNode = ((TreeView) sender).GetNodeAt(pt);

            // The if statement ensures that the user doesn't completely lose the
            // node if they accidentally release the mouse button over the node they
            // attempted to drag. Without a check to see if the original node is the
            // same the destination node, they could make the node disappear.

            if (DestinationNode.TreeView != OriginationNode.TreeView) 
				{

                DestinationNode.Nodes.Add((TreeNode) OriginationNode.Clone());

                // Expand the parent node when adding the new node so that the drop
                // is obvious. Without this, only a + symbol would appear.

                DestinationNode.Expand();

                // if the Ctrl key was not pressed, remove the original node to 
                // effect a drag-and-drop move.

                if ((e.KeyState & CtrlMask) != CtrlMask) {
                    OriginationNode.Remove();
                }

            }

        }

    }

    // the DragEnter event for both TreeView controls.

    private void TreeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) 
		//tvwRight.DragEnter, tvwLeft.DragEnter;
		{
        // Check to be sure that the drag content is the correct type for this 
        // control. if not, reject the drop.

        if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode")) 
			{
            // if the Ctrl key was pressed during the drag operation then perform
            // a Copy. if not, perform a Move.

            if ((e.KeyState & CtrlMask) == CtrlMask) 
				{
                e.Effect = DragDropEffects.Copy;
				}
            else {
                e.Effect = DragDropEffects.Move;
					}
			}
        else 
			{
            e.Effect = DragDropEffects.None;
        }

    }

    // the ItemDrag event for both TreeView controls.

    private void TreeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e) 
		{
        if (e.Button == MouseButtons.Left) {

            //invoke the drag and drop operation

            DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy);

        }

    }

}

