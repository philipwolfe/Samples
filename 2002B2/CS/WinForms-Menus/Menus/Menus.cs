using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Menus
{
	/// <summary>
	/// Summary description for Menus.
	/// </summary>
	public class Menus : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ContextMenu label1ContextMenu;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		// Comment out this structure to view menus.cs in the WinForms Designer.
		// Remember not to edit the menus in the designer. It will conflict
		// with the hand-written menu code. Remember to uncomment this
		// structure when you are finished.
		private struct FontSizes 
		{
			public static float Small = 8f;
			public static float Medium = 12f;
			public static float Large = 24f;
		}

		//Font face and size
		private float fontSize = FontSizes.Medium;

		//Used to track which menu items are checked/unchecked
		private MenuItem mmiSansSerif;
		private MenuItem mmiSerif;
		private MenuItem mmiMonoSpace;

		private MenuItem mmiSmall;
		private MenuItem mmiMedium;
		private MenuItem mmiLarge;

		private MenuItem cmiSansSerif;
		private MenuItem cmiSerif;
		private MenuItem cmiMonoSpace;

		private MenuItem cmiSmall;
		private MenuItem cmiMedium;
		private MenuItem cmiLarge;

		private MenuItem miMainFormatFontChecked ;
		private MenuItem miMainFormatSizeChecked ;
		private MenuItem miContextFormatFontChecked ;
		private MenuItem miContextFormatSizeChecked ;

		private FontFamily currentFontFamily ;
		private FontFamily monoSpaceFontFamily;
		private FontFamily sansSerifFontFamily;
		private FontFamily serifFontFamily;

		public Menus()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Initialize Fonts - use generic fonts to avoid problems across
			// different versions of the OS
			monoSpaceFontFamily = new FontFamily (GenericFontFamilies.Monospace);
			sansSerifFontFamily = new FontFamily (GenericFontFamilies.SansSerif);
			serifFontFamily = new FontFamily (GenericFontFamilies.Serif);
			currentFontFamily = sansSerifFontFamily;

			//Add File Menu
			MenuItem miFile = mainMenu.MenuItems.Add("&File");
			miFile.MenuItems.Add(new MenuItem("&Open...", new EventHandler(this.FileOpen_Clicked), Shortcut.CtrlO));
			miFile.MenuItems.Add("-");     // Gives us a seperator
			miFile.MenuItems.Add(new MenuItem("E&xit", new EventHandler(this.FileExit_Clicked), Shortcut.CtrlX));

			//Add Format Menu
			MenuItem miFormat = mainMenu.MenuItems.Add("F&ormat");

			//Font Face sub-menu
			mmiSansSerif = new MenuItem("&1. " + sansSerifFontFamily.Name, new EventHandler(this.FormatFont_Clicked));
			mmiSansSerif.Checked = true ;
			mmiSansSerif.DefaultItem = true ;
			mmiSerif = new MenuItem("&2. " + serifFontFamily.Name, new EventHandler(this.FormatFont_Clicked));
			mmiMonoSpace = new MenuItem("&3. " + monoSpaceFontFamily.Name, new EventHandler(this.FormatFont_Clicked));

			miFormat.MenuItems.Add( "Font &Face",
				(new MenuItem[]{ mmiSansSerif, mmiSerif, mmiMonoSpace })
				);

			//Font Size sub-menu
			mmiSmall = new MenuItem("&Small", new EventHandler(this.FormatSize_Clicked));
			mmiMedium = new MenuItem("&Medium", new EventHandler(this.FormatSize_Clicked));
			mmiMedium.Checked = true ;
			mmiMedium.DefaultItem = true ;
			mmiLarge = new MenuItem("&Large", new EventHandler(this.FormatSize_Clicked));

			miFormat.MenuItems.Add( "Font &Size",
				(new MenuItem[]{ mmiSmall, mmiMedium, mmiLarge })
				);

			//Add Format to label context menu
			//Note have to add a clone because menus can't belong to 2 parents
			label1ContextMenu.MenuItems.Add(miFormat.CloneMenu());

			// Set up the context menu items - we use these to check and uncheck items
			cmiSansSerif = label1ContextMenu.MenuItems[0].MenuItems[0].MenuItems[0];
			cmiSerif = label1ContextMenu.MenuItems[0].MenuItems[0].MenuItems[1];
			cmiMonoSpace = label1ContextMenu.MenuItems[0].MenuItems[0].MenuItems[2];
			cmiSmall = label1ContextMenu.MenuItems[0].MenuItems[1].MenuItems[0];
			cmiMedium = label1ContextMenu.MenuItems[0].MenuItems[1].MenuItems[1];
			cmiLarge = label1ContextMenu.MenuItems[0].MenuItems[1].MenuItems[2];

			//We use these to track which menu items are checked
			//This is made more complex because we have both a menu and a context menu
			miMainFormatFontChecked = mmiSansSerif;
			miMainFormatSizeChecked = mmiMedium;
			miContextFormatFontChecked = cmiSansSerif;
			miContextFormatSizeChecked = cmiMedium;
		}

		//File->Exit Menu item handler
		private void FileExit_Clicked(object sender, System.EventArgs e) 
		{
			this.Close();
		}

		//File->Open Menu item handler
		private void FileOpen_Clicked(object sender, System.EventArgs e) 
		{
			MessageBox.Show("And why would this open a file?");
		}

		//Format->Font Menu item handler
		private void FormatFont_Clicked(object sender, System.EventArgs e) 
		{
			MenuItem miClicked = (MenuItem)sender;

			miMainFormatFontChecked.Checked = false;
			miContextFormatFontChecked.Checked = false;

			if ( miClicked == mmiSansSerif || miClicked == cmiSansSerif ) 
			{
				miMainFormatFontChecked = mmiSansSerif;
				miContextFormatFontChecked = cmiSansSerif;
				currentFontFamily = sansSerifFontFamily;
			} 
			else if (miClicked == mmiSerif || miClicked == cmiSerif) 
			{
				miMainFormatFontChecked = mmiSerif;
				miContextFormatFontChecked = cmiSerif;
				currentFontFamily = serifFontFamily;
			} 
			else 
			{
				miMainFormatFontChecked = mmiMonoSpace;
				miContextFormatFontChecked = cmiMonoSpace;
				currentFontFamily = monoSpaceFontFamily;
			}

			miMainFormatFontChecked.Checked = true;
			miContextFormatFontChecked.Checked = true;

			label1.Font = new Font(currentFontFamily, fontSize);
		}

		//Format->Size Menu item handler
		private void FormatSize_Clicked(object sender, System.EventArgs e) 
		{

			MenuItem miClicked = (MenuItem)sender;

			miMainFormatSizeChecked.Checked = false;
			miContextFormatSizeChecked.Checked = false;

			string fontSizeString = ((MenuItem)sender).Text;

			if (fontSizeString == "&Small") 
			{
				miMainFormatSizeChecked = mmiSmall;
				miContextFormatSizeChecked = cmiSmall;
				fontSize = FontSizes.Small ;
			} 
			else if (fontSizeString == "&Large") 
			{
				miMainFormatSizeChecked = mmiLarge;
				miContextFormatSizeChecked = cmiLarge;
				fontSize = FontSizes.Large ;
			} 
			else 
			{
				miMainFormatSizeChecked = mmiMedium;
				miContextFormatSizeChecked = cmiMedium;
				fontSize = FontSizes.Medium ;
			}

			miMainFormatSizeChecked.Checked = true;
			miContextFormatSizeChecked.Checked = true;

			label1.Font = new Font(currentFontFamily, fontSize);
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Menus());
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1ContextMenu = new System.Windows.Forms.ContextMenu();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.label1 = new System.Windows.Forms.Label();
			this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.label1.ContextMenu = this.label1ContextMenu;
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Size = new System.Drawing.Size(360, 50);
			this.label1.TabIndex = 0;
			this.label1.Text = "Right Click on me - I have a context menu!";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 117);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.label1});
			this.Menu = this.mainMenu;
			this.Text = "Menus \'R Us";
		}
		#endregion
	}
}
