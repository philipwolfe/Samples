using System;
using System.Drawing;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace PrintFile
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PrintingSample : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components;
		protected internal System.Windows.Forms.Button printButton;

		private Font printFont;
		private StreamReader streamToPrint;

		/// <summary>
		/// Required designer variable.
		/// </summary>

		public PrintingSample()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.printButton = new System.Windows.Forms.Button();
			this.printButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.printButton.Location = new System.Drawing.Point(32, 112);
			this.printButton.Size = new System.Drawing.Size(136, 40);
			this.printButton.TabIndex = 0;
			this.printButton.Text = "Print the file";
			this.printButton.Click += new System.EventHandler(this.printButton_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 381);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.printButton});
			this.Text = "Print Example 1";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PrintingSample());
		}

		private void printButton_Click(object sender, System.EventArgs e)
		{
			try 
			{

				streamToPrint = new StreamReader ("PrintMe.Txt");
				try 
				{
					printFont = new Font("Arial", 10);
					PrintDocument pd = new PrintDocument(); //Assumes the default printer
					pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
					pd.Print();
				} 
				finally 
				{
					streamToPrint.Close() ;
				}

			} 
			catch(Exception ex) 
			{
				MessageBox.Show("An error occurred printing the file - " + ex.Message);
			}
		}

		//Event fired for each page to print
		private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
		{
			float lpp = 0 ;
			float yPos =  0 ;
			int count = 0 ;
			float leftMargin = ev.MarginBounds.Left;
			float topMargin = ev.MarginBounds.Top;
			String line=null;

			//Work out the number of lines per page
			//Use the MarginBounds on the event to do this
			lpp = ev.MarginBounds.Height  / printFont.GetHeight(ev.Graphics) ;

			//Now iterate over the file printing out each line
			//NOTE WELL: This assumes that a single line is not wider than the page width
			//Check count first so that we don't read line that we won't print
			while (count < lpp && ((line=streamToPrint.ReadLine()) != null)) 
			{
				yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));

				ev.Graphics.DrawString (line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

				count++;
			}

			//If we have more lines then print another page
			if (line != null)
				ev.HasMorePages = true ;
			else
				ev.HasMorePages = false ;
		}


	}
}
