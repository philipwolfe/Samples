using System;
using System.Windows.Forms;
using System.Drawing;

public class frmIconModMenu: System.Windows.Forms.Form 
{

	#region " Windows Form Designer generated code "

	public frmIconModMenu() 
{

	//This call is required by the Windows Form Designer.
	InitializeComponent();
	//Add any initialization after the InitializeComponent() call

}

    //Form overrides dispose to clean up the component list.

protected override void Dispose(bool disposing) 
{

if (disposing) 
{

if (components != null) 
{

components.Dispose();

}

}

base.Dispose(disposing);

}

    //Required by the Windows Form Designer

private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer

    //It can be modified using the Windows Form Designer.  

    //Do ! modify it using the code editor.

private System.Windows.Forms.MainMenu mnuMain;

private void InitializeComponent() 
{

System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIconModMenu));

this.mnuMain = new System.Windows.Forms.MainMenu();
        //
        //mnuMain
        //
this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

        //

        //frmIconModMenu

        //

this.AccessibleDescription = (string) resources.GetObject("$this.AccessibleDescription");

this.AccessibleName = (string) resources.GetObject("$this.AccessibleName");

this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

this.Enabled = (bool) resources.GetObject("$this.Enabled");

this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

this.Menu = this.mnuMain;

this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

this.Name = "frmIconModMenu";

this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

this.Text = resources.GetString("$this.Text");

this.Visible = (bool) resources.GetObject("$this.Visible");
	this.Load +=new EventHandler(frmIconModMenu_Load);

}

#endregion

private void frmIconModMenu_Load(object sender, System.EventArgs e)
{
        // Section #1
        // Basic Menu Items with Icons
		mnuMain.MenuItems.Add("&File");
		MenuItem miFile = mnuMain.MenuItems[0];
		EventHandler handlerFile = new EventHandler(MenuItemFileClick);
				// By using this constructor the menu items will show up in whatever system
				// colors are chosen by the user in control panel or by their theme choice.
		miFile.MenuItems.Add(new IconMenuItem("&Open", new Icon(@"..\..\open.ico"),handlerFile, Shortcut.CtrlO));
		miFile.MenuItems.Add(new IconMenuItem("&Save", new Icon(@"..\..\save.ico"),handlerFile, Shortcut.CtrlS));
		miFile.MenuItems.Add(new MenuItem("-"));
		miFile.MenuItems.Add(new IconMenuItem("&Exit", new Icon(@"..\..\exit.ico"), handlerFile, Shortcut.None));
        // if you want you can uncomment section one above and uncomment Section #2 below.
        // This second section will display the menu items with a custom color gradient a 
        // background color.
        // For more information on how this is done see the IconMenuItem class definition.
        // Section #2
        // Menu Items with Custom Gradient and Icons
        //mnuMain.MenuItems.Add("&File")
        //miEdit MenuItem = mnuMain.MenuItems(0)
        //handlerPrograms EventHandler = new EventHandler(AddressOf MenuItemProgramsClick)
        //' By using this constructor the menu items will show up with a color gradient
        //' based on the two color values passed to the constructor.
        //miEdit.MenuItems.Add(new IconMenuItem("&Open", Color.LightBlue, Color.Yellow, _
        //    new Icon("..\open.ico"), handlerPrograms, Shortcut.CtrlO))
        //miEdit.MenuItems.Add(new IconMenuItem("&Save", Color.LightBlue, Color.Yellow, _
        //    new Icon("..\save.ico"), handlerPrograms, Shortcut.CtrlS))
        //miEdit.MenuItems.Add(new MenuItem("-"))
        //miEdit.MenuItems.Add(new IconMenuItem("&Exit", Color.LightBlue, Color.Yellow, _
        //    new Icon("..\exit.ico"), handlerPrograms, Shortcut.None))
}

private void MenuItemFileClick(object sender, EventArgs e) 
{

switch(( (MenuItem)(sender)).Index)
{
case 0:    // Open;
{
MessageBox.Show("You selected open");
break;
}

case 1:    // Save;
{
MessageBox.Show("You selected save");
break;
}
case 3:    // Exit;
{
Close();
break;
}

}

}

}

