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
namespace Microsoft.Samples.WinForms.Cs.MDI {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    public class Document : System.WinForms.Form {
        private System.ComponentModel.Container components;
        private System.WinForms.RichTextBox richTextBox1;
        private System.WinForms.MainMenu mainMenu;

        private struct FontSizes {
            public static float Small = 8f;
            public static float Medium = 12f;
            public static float Large = 24f;
        }

        private string fontFace = "Arial";
        private float fontSize = FontSizes.Medium;
        private MenuItem miFormatFontChecked ;
        private MenuItem miFormatSizeChecked ;

        public Document(string docName) : base() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
            this.Text = docName;
            richTextBox1.Text = docName;
             
            //Add File Menu
            MenuItem miFile = mainMenu.MenuItems.Add("&File");
            miFile.MergeType = MenuMerge.MergeItems;
            miFile.MergeOrder = 0;
            
            MenuItem miLoadDoc = miFile.MenuItems.Add("&Load Document (" + docName + ")", new EventHandler(this.LoadDocument_Clicked));
            miLoadDoc.MergeOrder = 105;

            //Add Formatting Menu
            MenuItem miFormat = mainMenu.MenuItems.Add("F&ormat (" + docName + ")");
            miFormat.MergeType = MenuMerge.Add;
            miFormat.MergeOrder = 5;

            //Font Face sub-menu
            MenuItem miArial = new MenuItem("&Arial", new EventHandler(this.FormatFont_Clicked));
            MenuItem miTimesNewRoman = new MenuItem("&Times New Roman", new EventHandler(this.FormatFont_Clicked));
            MenuItem miTahoma = new MenuItem("&Courier New", new EventHandler(this.FormatFont_Clicked));
            miArial.Checked = true ;
            miFormatFontChecked = miArial ;
            miArial.DefaultItem = true ;

            miFormat.MenuItems.Add( "Font &Face"
                      , new EventHandler(this.FormatFont_Clicked)  
                      , (new MenuItem[]{ miArial, miTimesNewRoman, miTahoma })
                      );

            //Font Size sub-menu
            MenuItem miSmall = new MenuItem("&Small", new EventHandler(this.FormatSize_Clicked));
            MenuItem miMedium = new MenuItem("&Medium", new EventHandler(this.FormatSize_Clicked));
            MenuItem miLarge = new MenuItem("&Large", new EventHandler(this.FormatSize_Clicked));
            miMedium.Checked = true ;
            miMedium.DefaultItem = true ;
            miFormatSizeChecked = miMedium ;

            miFormat.MenuItems.Add( "Font &Size"
                      , new EventHandler(this.FormatSize_Clicked) 
                      , (new MenuItem[]{ miSmall, miMedium, miLarge })
                      );

        }

        //File->Load Document Menu item handler
        protected void LoadDocument_Clicked(object sender, System.EventArgs e) {
            MessageBox.Show(this.Text) ;
        }


        //Format->Font Menu item handler
        protected void FormatFont_Clicked(object sender, System.EventArgs e) {
            MenuItem miClicked = (MenuItem)sender;
            miClicked.Checked = true;
            miFormatFontChecked.Checked = false;
            miFormatFontChecked = miClicked ;
            fontFace = miClicked.Text.Remove(0,1); //Strip off & from menu item text
            richTextBox1.Font = new Font(fontFace, fontSize);
        }

        //Format->Size Menu item handler
        protected void FormatSize_Clicked(object sender, System.EventArgs e) {
            MenuItem miClicked = (MenuItem)sender;
            miClicked.Checked = true;
            miFormatSizeChecked.Checked = false;
            miFormatSizeChecked = miClicked ;
            string fontSizeString = miClicked.Text;
            if (fontSizeString == "&Small") {
                fontSize = FontSizes.Small ;
            } else if (fontSizeString == "&Large") {
                fontSize = FontSizes.Large ;
            } else {
                fontSize = FontSizes.Medium ;
            }

            richTextBox1.Font = new Font(fontFace, fontSize);
        }


        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {

            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.WinForms.RichTextBox();
            this.mainMenu = new System.WinForms.MainMenu();

            richTextBox1.Text = "";
            richTextBox1.Size = new System.Drawing.Size(292, 273);
            richTextBox1.TabIndex = 0;
            richTextBox1.Dock = System.WinForms.DockStyle.Fill;
            richTextBox1.Font = new System.Drawing.Font("TAHOMA", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "";
            this.ClientSize = new System.Drawing.Size(392, 117);
            this.Menu = mainMenu;

            this.Controls.Add(richTextBox1);
	    }

    }
}










