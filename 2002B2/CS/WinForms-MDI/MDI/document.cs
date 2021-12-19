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
    using System.Drawing.Text;
    using System.Windows.Forms;

	public class Document : System.Windows.Forms.Form {
        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;
        private System.Windows.Forms.MainMenu mainMenu;
        protected internal System.Windows.Forms.RichTextBox richTextBox1;

        private struct FontSizes {
            public static float Small = 8f;
            public static float Medium = 12f;
            public static float Large = 24f;
        }

        private float fontSize = FontSizes.Medium;
        
        private MenuItem miFormatFontChecked;
        private MenuItem miFormatSizeChecked;
        
        private MenuItem miSmall ;
        private MenuItem miMedium ;
        private MenuItem miLarge ;

        private MenuItem miSansSerif ;
        private MenuItem miSerif ;
        private MenuItem miMonoSpace ;

        private FontFamily currentFontFamily ;
        private FontFamily monoSpaceFontFamily;
        private FontFamily sansSerifFontFamily;
        private FontFamily serifFontFamily;

        public Document(string docName) : base() {

            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // Initialize Fonts - use generic fonts to avoid problems across
            // different versions of the OS
            monoSpaceFontFamily = new FontFamily (GenericFontFamilies.Monospace);
            sansSerifFontFamily = new FontFamily (GenericFontFamilies.SansSerif);
            serifFontFamily = new FontFamily (GenericFontFamilies.Serif);
            currentFontFamily = sansSerifFontFamily;
            
            this.Text = docName;

            richTextBox1.Font = new System.Drawing.Font(currentFontFamily, fontSize);
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
            miSansSerif = new MenuItem("&1." + sansSerifFontFamily.Name, new EventHandler(this.FormatFont_Clicked));
            miSerif = new MenuItem("&2." + serifFontFamily.Name, new EventHandler(this.FormatFont_Clicked));
            miMonoSpace = new MenuItem("&3." + monoSpaceFontFamily.Name, new EventHandler(this.FormatFont_Clicked));
            miSansSerif.Checked = true ;
            miFormatFontChecked = miSansSerif ;
            miSansSerif.DefaultItem = true ;

            miFormat.MenuItems.Add( "Font &Face"
                        , (new MenuItem[]{ miSansSerif, miSerif, miMonoSpace })
                        );

            //Font Size sub-menu
            miSmall = new MenuItem("&Small", new EventHandler(this.FormatSize_Clicked));
            miMedium = new MenuItem("&Medium", new EventHandler(this.FormatSize_Clicked));
            miLarge = new MenuItem("&Large", new EventHandler(this.FormatSize_Clicked));
            miMedium.Checked = true ;
            miMedium.DefaultItem = true ;
            miFormatSizeChecked = miMedium ;

            miFormat.MenuItems.Add( "Font &Size"
                        , (new MenuItem[]{ miSmall, miMedium, miLarge })
                        );
        }

        //File->Load Document Menu item handler
        protected void LoadDocument_Clicked(object sender, System.EventArgs e)
		{
            MessageBox.Show(this.Text) ;
        }

        //Format->Font Menu item handler
        protected void FormatFont_Clicked(object sender, System.EventArgs e) {
            MenuItem miClicked = (MenuItem)sender;
            miClicked.Checked = true;
            miFormatFontChecked.Checked = false;
            miFormatFontChecked = miClicked ;
            
            if (miClicked == miSansSerif) {        
                currentFontFamily = sansSerifFontFamily ;
            } else if (miClicked == miSerif) {
                currentFontFamily = serifFontFamily ;
            } else {
                currentFontFamily = monoSpaceFontFamily ;
            }
            
            richTextBox1.Font = new Font(currentFontFamily, fontSize);
        }

        //Format->Size Menu item handler
        protected void FormatSize_Clicked(object sender, System.EventArgs e) {
            MenuItem miClicked = (MenuItem)sender;
            miClicked.Checked = true;
            miFormatSizeChecked.Checked = false;
            miFormatSizeChecked = miClicked;
            
            if (miClicked == miSmall) {
                fontSize = FontSizes.Small ;
            } else if (miClicked == miLarge) {
                fontSize = FontSizes.Large ;
            } else {
                fontSize = FontSizes.Medium ;
            }

            richTextBox1.Font = new Font(currentFontFamily, fontSize);
        }

        /// <summary>
        ///    Clean up any resources being used.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            components.Dispose();
        }

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.mainMenu = new System.Windows.Forms.MainMenu();

            richTextBox1.Text = "";
            richTextBox1.Size = new System.Drawing.Size(292, 273);
            richTextBox1.TabIndex = 0;
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "";
            this.ClientSize = new System.Drawing.Size(392, 117);
            this.Menu = mainMenu;

            this.Controls.Add(richTextBox1);

        }
    }
}










