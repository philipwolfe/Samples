using System;
using System.Drawing;
using System.Windows.Forms;

public class frmTextModMenu: System.Windows.Forms.Form {

    const int pointSize  = 18;
    private MenuItem miFaceName;

#region " Windows Form Designer generated code "

    public frmTextModMenu() {

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
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

    //Do ! modify it using the code editor.

    private System.Windows.Forms.MainMenu mnuMain;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTextModMenu));
        this.mnuMain = new System.Windows.Forms.MainMenu();

        //

        //mnuMain

        //

        this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

        //

        //frmTextModMenu

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

        this.Name = "frmTextModMenu";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");
		this.Load +=new EventHandler(frmTextModMenu_Load);
    }

#endregion

    // This example draws a simple menu that contains three text items.

    // The menu item is drawn at a size that is appropriate for the menu items

    // See the frmIconModMenu for a form that includes a menu with the option

    // for a custom color background well the use of icons.

    private void frmTextModMenu_Load(object sender, System.EventArgs e)
{
        // Create the main menu item and add the subitems to the menu.

        mnuMain.MenuItems.Add("&Choose a Font");
        string[] menuItemsText = new string[]{"&TimesnewRoman", "&Courier new", "&MS Sans Serif"};
        MenuItem[] menuItems = new MenuItem[menuItemsText.Length];
        int menuItemCount = (int)(menuItems.Length);
        EventHandler evOnClick = new EventHandler(MenuFaceNameOnClick);
        MeasureItemEventHandler evOnMeasure = new MeasureItemEventHandler(MenuFaceNameOnMeasureItem);
		DrawItemEventHandler evDrawItem = new DrawItemEventHandler(MenuFaceNameOnDrawItem);

		for (int i=0;i<menuItemCount;i++)
			{

            menuItems[i] = new MenuItem(menuItemsText[i]);

            // Enables the firing of the OnMeasureItem and OnDrawnItem events.
            menuItems[i].OwnerDraw = true;
            // Add event handlers to each menu item for key events.

			menuItems[i].Click += new EventHandler(evOnClick);
			menuItems[i].MeasureItem += new MeasureItemEventHandler(evOnMeasure);
			menuItems[i].DrawItem += new DrawItemEventHandler(evDrawItem);
        }
        mnuMain.MenuItems[0].MenuItems.AddRange(menuItems);
    }

    private void MenuFaceNameOnClick(object sender, EventArgs e) {

        // Simply lets the user know which menu item was clicked.

        miFaceName = (MenuItem) sender;

        miFaceName.Checked = true;

        MessageBox.Show("Menu Clicked: " + miFaceName.Text.Substring(1));

    }

    private void MenuFaceNameOnMeasureItem(object sender, MeasureItemEventArgs miea)
		{
        // The MeasureItem event along with the OnDrawItem event are the two key events
        // that need to be handled in order to create owner drawn menus.

        MenuItem mi = (MenuItem) sender;
        Font f = new Font(mi.Text.Substring(1), pointSize);

        // Measure the string that makes up a given menu item and use it to set the 
        // size of the menu item being drawn.

        SizeF siF = miea.Graphics.MeasureString(mi.Text, f);
        miea.ItemWidth = (int)(Math.Ceiling(siF.Width));
        miea.ItemHeight = (int)(Math.Ceiling(siF.Height));

    }

    private void MenuFaceNameOnDrawItem(object sender, DrawItemEventArgs diea)
	{

        // After you have established the size of the menu with the OnMeasureItem event you can 
        // then go ahead and drawn the item.
        // A graphics object is passed to the OnDrawItem event that you can use to 
        // draw the menu item.

        MenuItem mi = (MenuItem) sender;
        Graphics grfx = diea.Graphics;
        Brush br;
        Font f = new Font(mi.Text.Substring(1), pointSize);

        // Shows the accelerator key

        StringFormat strFrmt =  new StringFormat();
        strFrmt.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
        Rectangle rectCheck = diea.Bounds;
        Double d = SystemInformation.MenuCheckSize.Width * rectCheck.Height / SystemInformation.MenuCheckSize.Width;
        rectCheck.Width = (int)(d);
        Rectangle recText = diea.Bounds;

        // Leave enough room for a checkmark
        recText.X += rectCheck.Width;
        diea.DrawBackground();

        // Highlight the menu item the user moves over it.

		if ((diea.State & DrawItemState.Selected) != 0) 
		{

			br = SystemBrushes.HighlightText;
		}
		else 
		{

			br = SystemBrushes.FromSystemColor(SystemColors.MenuText);

		}

        // Draws the string leaving room for the accelerator key

        grfx.DrawString(mi.Text, f, br, recText.Left, recText.Top, strFrmt);

    }

}

