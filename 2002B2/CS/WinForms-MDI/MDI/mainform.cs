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
    using System.Windows.Forms;

    public class MainForm : System.Windows.Forms.Form {
        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;
        private System.Windows.Forms.MainMenu mainMenu;
        protected internal System.Windows.Forms.StatusBar statusBar1;

        private int windowCount = 0 ;

        public MainForm() {
            
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            //Setup MDI stuff
            this.IsMdiContainer = true;
            this.MdiChildActivate += new EventHandler(this.MDIChildActivated);

            //Add File Menu
            MenuItem miFile = mainMenu.MenuItems.Add("&File");
            miFile.MergeOrder=0;
            miFile.MergeType = MenuMerge.MergeItems;

            MenuItem miAddDoc = new MenuItem("&Add Document", new EventHandler(this.FileAdd_Clicked), Shortcut.CtrlA);
            miAddDoc.MergeOrder=100;

            MenuItem miExit = new MenuItem("E&xit", new EventHandler(this.FileExit_Clicked), Shortcut.CtrlX);
            miExit.MergeOrder=110;

            miFile.MenuItems.Add(miAddDoc);
            miFile.MenuItems.Add("-");     // Gives us a seperator
            miFile.MenuItems.Add(miExit);

            //Add Window Menu
            MenuItem miWindow = mainMenu.MenuItems.Add("&Window");
            miWindow.MergeOrder = 10;
            miWindow.MenuItems.Add("&Cascade", new EventHandler(this.WindowCascade_Clicked));
            miWindow.MenuItems.Add("Tile &Horizontal", new EventHandler(this.WindowTileH_Clicked));
            miWindow.MenuItems.Add("Tile &Vertical", new EventHandler(this.WindowTileV_Clicked));
            miWindow.MdiList = true ; //Adds the MDI Window List to the bottom of the menu

            AddDocument(); //Add an initial doc
        }


        //Add a document 
        private void AddDocument() {
            windowCount++ ;
            Document doc = new Document("Document " + windowCount);
            doc.MdiParent = this;
            doc.Show();
        }


        //File->Add Menu item handler
        protected void FileAdd_Clicked(object sender, System.EventArgs e) {
            AddDocument() ;
        }


        //File->Exit Menu item handler
        protected void FileExit_Clicked(object sender, System.EventArgs e) {
            this.Close();
        }


        //One of the MDI Child windows has been activated
        protected void MDIChildActivated(object sender, System.EventArgs e) {
            if (null == this.ActiveMdiChild) {
                statusBar1.Text = "";
            } else {
                statusBar1.Text = this.ActiveMdiChild.Text;
            }
        }

        //Window->Cascade Menu item handler
        protected void WindowCascade_Clicked(object sender, System.EventArgs e) {
            this.LayoutMdi(MdiLayout.Cascade);   
        }


        //Window->Tile Horizontally Menu item handler
        protected void WindowTileH_Clicked(object sender, System.EventArgs e) {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }


        //Window->Tile Vertically Menu item handler
        protected void WindowTileV_Clicked(object sender, System.EventArgs e) {
            this.LayoutMdi(MdiLayout.TileVertical);
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
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container ();
            this.mainMenu = new System.Windows.Forms.MainMenu ();
            this.statusBar1 = new System.Windows.Forms.StatusBar ();
            //@this.TrayLargeIcon = false;
            //@this.TrayAutoArrange = true;
            //@this.TrayHeight = 90;
            this.Text = "MDI Example";
            this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
            this.Menu = this.mainMenu;
            this.ClientSize = new System.Drawing.Size (450, 200);
            //@mainMenu.SetLocation (new System.Drawing.Point (7, 7));
            statusBar1.BackColor = System.Drawing.SystemColors.Control;
            statusBar1.Location = new System.Drawing.Point (0, 180);
            statusBar1.Size = new System.Drawing.Size (450, 20);
            statusBar1.TabIndex = 1;
            this.Controls.Add (this.statusBar1);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args) {
            Application.Run(new MainForm());
        }

    }
}










