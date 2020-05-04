using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region SFSetup
	public class SFSetup : System.Windows.Forms.Form
	{
		#region class variables
		public System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		
		private System.ComponentModel.Container components = null;
		private StringList DelList;
		#endregion

		#region constructor
		public SFSetup()
		{
			InitializeComponent();
		}
		#endregion

		#region destructor
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ContextMenu = this.contextMenu1;
			this.listBox1.Location = new System.Drawing.Point(8, 32);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(73, 121);
			this.listBox1.TabIndex = 0;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Shortcut = System.Windows.Forms.Shortcut.Ins;
			this.menuItem1.Text = "Add";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuItem2.Text = "Remove";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Extensions";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(88, 32);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(112, 40);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Register as default editor";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(96, 80);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "&OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(96, 128);
			this.button2.Name = "button2";
			this.button2.TabIndex = 4;
			this.button2.Text = "&Cancel";
			// 
			// SFSetup
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(208, 166);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.button1,
																		  this.checkBox1,
																		  this.label1,
																		  this.listBox1});
			this.Name = "SFSetup";
			this.ShowInTaskbar = false;
			this.Text = "Preferences";
			this.Load += new System.EventHandler(this.SFSetup_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		public void button1_Click(object sender, System.EventArgs e)
		{
			RegistryKey reg;
			for(int i=0;i<DelList.Count;i++)
			{
				Registry.ClassesRoot.DeleteSubKey("."+DelList.GetString(i),false);
			}
			for(int i=0;i<listBox1.Items.Count;i++)
			{
				reg=Registry.ClassesRoot.OpenSubKey("."+listBox1.Items[i].ToString(),true);
				if(reg==null)
					reg=Registry.ClassesRoot.CreateSubKey("."+(string)listBox1.Items[i]);
				reg.SetValue("","EditorTemplate");
			}
			if(checkBox1.Checked)
			{
				reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate",true);
				if(reg==null)
					reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate");
				reg.SetValue("","Report Template");

				reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\DefaultIcon",true);
				if(reg==null)
					reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\DefaultIcon");
				reg.SetValue("","\""+Application.ExecutablePath+"\""+",0");

				reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\DefaultIcon",true);
				if(reg==null)
					reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\DefaultIcon");
				reg.SetValue("","\""+Application.ExecutablePath+"\""+",0");

				reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\Shell\\Open\\Command",true);
				if(reg==null)
					reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\Shell\\Open\\Command");
				reg.SetValue("","\""+Application.ExecutablePath+"\""+" %1");

				reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\Shell\\Print\\Command",true);
				if(reg==null)
					reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\Shell\\Print\\Command");
				reg.SetValue("","\""+Application.ExecutablePath+"\""+" /p %1");

				reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\Shell\\View\\Command",true);
				if(reg==null)
					reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\Shell\\View\\Command");
				reg.SetValue("","\""+Application.ExecutablePath+"\""+" /v %1");
			}
			else
			{
				Registry.ClassesRoot.DeleteSubKeyTree("EditorTemplate");
			}
		}

		private void SFSetup_Load(object sender, System.EventArgs e)
		{
			DelList=new StringList("PreferecesDlg.DelList");
			RegistryKey reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate",false);
			if(reg==null)
                checkBox1.Checked=false;
			else
				checkBox1.Checked=true;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			inputbox d=new inputbox();
			d.Text="New file type";
			if(d.ShowDialog()==DialogResult.OK)
			{
				listBox1.Items.Add(d.textBox1.Text);
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if(listBox1.SelectedItem!=null)
			{
				DelList.Add((string)listBox1.SelectedItem);
				listBox1.Items.Remove(listBox1.SelectedItem);
			}
		}
		#endregion

		#region class properties
		public StringList ExtList
		{
			get
			{
				StringList fextlist=new StringList("");
				for(int i=0;i<listBox1.Items.Count;i++)
				{
					fextlist.Add((string)listBox1.Items[i]);
				}
				return fextlist;
			}
		}
		#endregion
	}
	#endregion
}
