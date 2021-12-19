//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.Menus {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    public class Menus : System.WinForms.Form {
        private System.ComponentModel.Container components;
        private System.WinForms.Label label1;
        private System.WinForms.MainMenu mainMenu;
        private System.WinForms.ContextMenu label1ContextMenu;

        private struct FontSizes {
            public static float Small = 8f;
            public static float Medium = 12f;
            public static float Large = 24f;
        }

        //Font face and size
        private string fontFace = "Arial";
        private float fontSize = FontSizes.Medium;

        //Used to track which menu items are checked/unchecked
        private MenuItem mmiArial;
        private MenuItem mmiTimesNewRoman;
        private MenuItem mmiCourier;
        private MenuItem mmiSmall;
        private MenuItem mmiMedium;
        private MenuItem mmiLarge;
        private MenuItem cmiArial;
        private MenuItem cmiTimesNewRoman;
        private MenuItem cmiCourier;
        private MenuItem cmiSmall;
        private MenuItem cmiMedium;
        private MenuItem cmiLarge;

        private MenuItem miMainFormatFontChecked ;
        private MenuItem miMainFormatSizeChecked ;
        private MenuItem miContextFormatFontChecked ;
        private MenuItem miContextFormatSizeChecked ;

        public Menus() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call

            label1.Font = new Font(fontFace, fontSize);

            //Add File Menu
            MenuItem miFile = mainMenu.MenuItems.Add("&File");
	        miFile.MenuItems.Add(new MenuItem("&Open...", new EventHandler(this.FileOpen_Clicked), Shortcut.CtrlO));
            miFile.MenuItems.Add("-");     // Gives us a seperator
            miFile.MenuItems.Add(new MenuItem("E&xit", new EventHandler(this.FileExit_Clicked), Shortcut.CtrlX));

            //Add Format Menu
            MenuItem miFormat = mainMenu.MenuItems.Add("F&ormat");

            //Font Face sub-menu
            mmiArial = new MenuItem("&Arial", new EventHandler(this.FormatFont_Clicked));
            mmiArial.Checked = true ;
            mmiArial.DefaultItem = true ;
            mmiTimesNewRoman = new MenuItem("&Times New Roman", new EventHandler(this.FormatFont_Clicked));
            mmiCourier = new MenuItem("&Courier New", new EventHandler(this.FormatFont_Clicked));

            miFormat.MenuItems.Add( "Font &Face"
                                  , new EventHandler(this.FormatFont_Clicked) 
                                  , (new MenuItem[]{ mmiArial, mmiTimesNewRoman, mmiCourier })
                                  );

            //Font Size sub-menu
            mmiSmall = new MenuItem("&Small", new EventHandler(this.FormatSize_Clicked));
            mmiMedium = new MenuItem("&Medium", new EventHandler(this.FormatSize_Clicked));
            mmiMedium.Checked = true ;
            mmiMedium.DefaultItem = true ;
            mmiLarge = new MenuItem("&Large", new EventHandler(this.FormatSize_Clicked));

            miFormat.MenuItems.Add( "Font &Size"
                                  , new EventHandler(this.FormatSize_Clicked) //?????
                                  , (new MenuItem[]{ mmiSmall, mmiMedium, mmiLarge })
                                  );

            //Add Format to label context menu
            //Note have to add a clone because menus can't belong to 2 parents
            label1ContextMenu.MenuItems.Add(miFormat.CloneMenu());
	
	        // Set up the context menu items - we use these to check and uncheck items
            cmiArial = label1ContextMenu.MenuItems[0].MenuItems[0].MenuItems[0];
            cmiTimesNewRoman = label1ContextMenu.MenuItems[0].MenuItems[0].MenuItems[1];
            cmiCourier = label1ContextMenu.MenuItems[0].MenuItems[0].MenuItems[2];
            cmiSmall = label1ContextMenu.MenuItems[0].MenuItems[1].MenuItems[0];
            cmiMedium = label1ContextMenu.MenuItems[0].MenuItems[1].MenuItems[1];        
            cmiLarge = label1ContextMenu.MenuItems[0].MenuItems[1].MenuItems[2];

            //We use these to track which menu items are checked
            //This is made more complex because we have both a menu and a context menu
            miMainFormatFontChecked = mmiArial;
            miMainFormatSizeChecked = mmiMedium;
            miContextFormatFontChecked = cmiArial;
            miContextFormatSizeChecked = cmiMedium;

        }

        //File->Exit Menu item handler
        private void FileExit_Clicked(object sender, System.EventArgs e) {
            this.Close();
        }

        //File->Open Menu item handler
        private void FileOpen_Clicked(object sender, System.EventArgs e) {
            MessageBox.Show("And why would this open a file?");
        }

        //Format->Font Menu item handler
        private void FormatFont_Clicked(object sender, System.EventArgs e) {
            MenuItem miClicked = (MenuItem)sender;

            miMainFormatFontChecked.Checked = false;
            miContextFormatFontChecked.Checked = false;

            fontFace = miClicked.Text.Remove(0,1); //Strip off & from menu item text

	        if (fontFace == "Arial") {
                miMainFormatFontChecked = mmiArial;
                miContextFormatFontChecked = cmiArial;
            } else if (fontFace == "Times New Roman") {
                miMainFormatFontChecked = mmiTimesNewRoman;
                miContextFormatFontChecked = cmiTimesNewRoman;
            } else {
                miMainFormatFontChecked = mmiCourier;
                miContextFormatFontChecked = cmiCourier;
            }

            miMainFormatFontChecked.Checked = true;
            miContextFormatFontChecked.Checked = true;

            label1.Font = new Font(fontFace, fontSize);
        }

        //Format->Size Menu item handler
        private void FormatSize_Clicked(object sender, System.EventArgs e) {

            MenuItem miClicked = (MenuItem)sender;

	        miMainFormatSizeChecked.Checked = false;
            miContextFormatSizeChecked.Checked = false;

	        string fontSizeString = ((MenuItem)sender).Text;
            
	        if (fontSizeString == "&Small") {
                miMainFormatSizeChecked = mmiSmall;
                miContextFormatSizeChecked = cmiSmall;
		        fontSize = FontSizes.Small ;
            } else if (fontSizeString == "&Large") {
                miMainFormatSizeChecked = mmiLarge;
                miContextFormatSizeChecked = cmiLarge;
		        fontSize = FontSizes.Large ;
            } else {
                miMainFormatSizeChecked = mmiMedium;
                miContextFormatSizeChecked = cmiMedium;
                fontSize = FontSizes.Medium ;
            }

	        miMainFormatSizeChecked.Checked = true;
            miContextFormatSizeChecked.Checked = true;

            label1.Font = new Font(fontFace, fontSize);
        }



        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {

            this.components = new System.ComponentModel.Container();
            this.label1 = new System.WinForms.Label();
            this.mainMenu = new System.WinForms.MainMenu();
            this.label1ContextMenu = new System.WinForms.ContextMenu();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Menus 'R Us";
            this.Menu = mainMenu;
            this.ClientSize = new System.Drawing.Size(392, 117);

            label1.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
    		label1.BackColor = System.Drawing.Color.LightSteelBlue;
            label1.ContextMenu = label1ContextMenu;
            label1.Location = new System.Drawing.Point(16, 24);
            label1.Text = "Right Click on me - I have a context menu!";
            label1.TabIndex = 0;
            label1.Size = new System.Drawing.Size(360, 50);

            this.Controls.Add(label1);
	    }


        public static void Main(string[] args) {
            Application.Run(new Menus());
        }

    }
}











