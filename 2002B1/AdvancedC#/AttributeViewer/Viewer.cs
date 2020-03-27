namespace AttributeViewer
{
	using System;
	using System.Drawing;
	using System.Collections;
	using System.ComponentModel;
	using System.WinForms;
	using System.Data;
	using System.Diagnostics;

	/// <summary>
	/// A simple Win Form that displays any Help and Programming Note 
	/// attributes attached to types.
	/// </summary>
	public class Viewer: System.WinForms.Form
	{
		/// <summary> 
		/// Required designer variable
		/// </summary>
		private System.ComponentModel.Container components;
		private System.WinForms.LinkLabel linkLabel1;
		private System.WinForms.Label label2;
		private System.WinForms.TextBox textBox1;
		private System.WinForms.Label label1;
		private AxSHDocVw.AxWebBrowser AxWebBrowser1;
		private System.WinForms.ListBox notesLB;
		private System.WinForms.Button displayPB;

		private System.WinForms.Panel panel1;

		/// <summary>
		/// Constructor for the Viewer form.
		/// </summary>
		public Viewer()
		{
			//
			// Required for Win Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			components.Dispose();
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.WinForms.Label();
			this.displayPB = new System.WinForms.Button();
			this.label2 = new System.WinForms.Label();
			this.notesLB = new System.WinForms.ListBox();
			this.textBox1 = new System.WinForms.TextBox();
			this.linkLabel1 = new System.WinForms.LinkLabel();
			this.AxWebBrowser1 = new AxSHDocVw.AxWebBrowser();
			this.panel1 = new System.WinForms.Panel();
			
			AxWebBrowser1.BeginInit();
			
			label1.Location = new System.Drawing.Point(0, 80);
			label1.Text = "Programming Notes";
			label1.Size = new System.Drawing.Size(152, 64);
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			label1.TabIndex = 3;
			
			this.AutoScaleBaseSize = new System.Drawing.Size(11, 25);
			this.Text = "AttributeViewer";
			//@design this.TrayLargeIcon = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 22f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.AcceptButton = displayPB;
			//@design this.TrayHeight = 0;
			this.ClientSize = new System.Drawing.Size(616, 405);
			this.WindowState = FormWindowState.Maximized;
			
			displayPB.Location = new System.Drawing.Point(376, 0);
			displayPB.Dock = System.WinForms.DockStyle.Right;
			displayPB.Size = new System.Drawing.Size(240, 32);
			displayPB.TabIndex = 1;
			displayPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 22f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			displayPB.Text = "Get Information";
			displayPB.Click += new System.EventHandler(displayPB_Click);
			
			label2.Location = new System.Drawing.Point(0, 40);
			label2.Text = "Help URL";
			label2.Size = new System.Drawing.Size(120, 24);
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			label2.TabIndex = 4;
			
			notesLB.Location = new System.Drawing.Point(152, 72);
			notesLB.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
			notesLB.Size = new System.Drawing.Size(456, 82);
			notesLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 22f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			notesLB.TabIndex = 1;
			
			textBox1.Text = "MyClass";
			textBox1.Dock = System.WinForms.DockStyle.Fill;
			textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			textBox1.TabIndex = 3;
			textBox1.Size = new System.Drawing.Size(376, 32);
			
			linkLabel1.Location = new System.Drawing.Point(160, 40);
			linkLabel1.Text = "";
			linkLabel1.Anchor = System.WinForms.AnchorStyles.TopLeftRight;
			linkLabel1.Size = new System.Drawing.Size(448, 24);
			linkLabel1.LinkBehavior = System.WinForms.LinkBehavior.AlwaysUnderline;
			linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			linkLabel1.TabIndex = 5;
			linkLabel1.Click += new System.EventHandler(Link_Click);
			
			AxWebBrowser1.Anchor = System.WinForms.AnchorStyles.All;
			AxWebBrowser1.Location = new System.Drawing.Point(8, 160);
			AxWebBrowser1.Size = new System.Drawing.Size(600, 240);
			AxWebBrowser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			AxWebBrowser1.TabIndex = 0;
			
			panel1.Dock = System.WinForms.DockStyle.Top;
			panel1.Size = new System.Drawing.Size(616, 32);
			panel1.TabIndex = 0;
			panel1.Text = "panel1";
			
			panel1.Controls.Add(displayPB);
			panel1.Controls.Add(textBox1);
			this.Controls.Add(linkLabel1);
			this.Controls.Add(label2);
			this.Controls.Add(AxWebBrowser1);
			this.Controls.Add(label1);
			this.Controls.Add(notesLB);
			this.Controls.Add(panel1);
			
			AxWebBrowser1.EndInit();
		}


		/// <summary>
		/// Handle the click on the LinkLabel control
		/// </summary>
		/// <param name="sender"> The sender of the event</param>
		/// <param name="e"> The argument to the event</param>
		protected void Link_Click(object sender, System.EventArgs e)
		{
			string htmlFile = Environment.CurrentDirectory + "\\" +
				              linkLabel1.Text;

			Navigate( htmlFile );
		}

		/// <summary>
		/// Navigate to the specified Url.
		/// </summary>
		/// <param name="url"> The url to navigate to</param>
		protected void Navigate(string url)
		{
			if ( url == null || url == "" )
			{
				url = "about:blank";
			}

			object arg1 = 0; 
			object arg2 = ""; 
			object arg3 = ""; 
			object arg4 = "";

			AxWebBrowser1.Navigate(url, ref arg1, ref arg2, ref arg3, ref arg4);
		}

		/// <summary>
		/// Handle the click of the GetInfo button
		/// </summary>
		/// <param name="sender"> The sender of the event</param>
		/// <param name="e"> The argument to the event</param>
		protected void displayPB_Click(object sender, System.EventArgs e)
		{
			ShowDetails( textBox1.Text );		
		}

		/// <summary>
		/// Show the details for the passed type 
		/// </summary>
		/// <param name="typeName">The name of the type to show details</param>
		private void ShowDetails(string typeName)
		{
			linkLabel1.Text = "";
			notesLB.Items.Clear();
			Navigate("");

			Type type = Type.GetType(typeName);

			if ( type == null )
			{
				MessageBox.Show("Type [" + typeName + "] Not Found!");
			}
			else
			{
				// Populate the dialog with the class information
				foreach (object attribute in type.GetCustomAttributes() )
				{
					if ( attribute is HelpUrlAttribute )
					{
						HelpUrlAttribute ha = (HelpUrlAttribute) attribute;

						linkLabel1.Text = ha.Url;
						linkLabel1.LinkArea = new Point(0, ha.Url.Length ); 
					}

					if ( attribute is ProgrammingNoteAttribute )
					{
						ProgrammingNoteAttribute pa = (ProgrammingNoteAttribute) attribute;

						notesLB.Items.Add( pa.Note );
					}
				}
			}
		}

		/// <summary>
		/// Run the Viewer window.
		/// </summary>
		public static void Main() 
		{
			Application.Run(new Viewer());
		}
	}
}
