namespace ExplorerTreeViewTest
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;

    /// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.StatusBar statusBar1;
        private ExplorerTreeViewTest.ExplorerTreeView treeView1;
        private ExplorerTreeViewTest.RootComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

            // Establish the root of the Explorer view
            this.treeView1.SpecialFolder = Environment.SpecialFolder.Desktop;

            // We want to know when a name is selected
            this.treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);

            // Add a special drive
            this.comboBox1.AddNode(Environment.SpecialFolder.MyMusic);

            // We want to know when a path is selected
            this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.statusBar1.Text = String.Format("selected {0}", this.comboBox1.SelectedNode);
 
            // Establish the root of the Explorer view
            RootComboBox.Node node = this.comboBox1.SelectedNode;
            if (node is RootComboBox.PathNode)
                this.treeView1.Root = node.path;
            else if (node is RootComboBox.SpecialFolderNode)
                this.treeView1.SpecialFolder = (Environment.SpecialFolder)node.id;
            else if (node is RootComboBox.PidlNode)
                this.treeView1.Pidl = (ShellIcon.CSIDL)node.id;

            this.Cursor = Cursors.Default;
        }

        void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)e.Node;
                this.statusBar1.Text = String.Format("selected {0}", node.FullName);
            }
            else
            {
                this.statusBar1.Text = String.Format("selected {0}", e.Node.Text);
            }
        }

        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.treeView1 = new ExplorerTreeViewTest.ExplorerTreeView();
            this.comboBox1 = new ExplorerTreeViewTest.RootComboBox();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 424);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(216, 22);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "Ready";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(2, 32);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(210, 384);
            this.treeView1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top ) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Location = new System.Drawing.Point(2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(216, 446);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.statusBar1);
            this.Name = "Form1";
            this.Text = "ExplorerTreeView";
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Application.DoEvents();
			Application.Run(new Form1());
		}
	}
}
