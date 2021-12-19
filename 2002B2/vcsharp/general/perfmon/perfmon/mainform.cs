
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PerfMon
{
	/// <summary>
	/// Summary description for Form1.
	/// Main application window.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		//The controls added to the form
		private System.Windows.Forms.GroupBox groupBox1;
		
		//The counters treeview control
		private System.Windows.Forms.TreeView CountersTree;
		private System.Windows.Forms.TextBox MachineNameText;
		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.Button RefreshButton;
		//The TabControl which will hold all the graphics
		private System.Windows.Forms.TabControl GraphicTabControl;
		private string MachineName=null;
		//The progressBar control which will show the progress on tree load
		private System.Windows.Forms.ProgressBar TreeProgress;
		//Controls Labels 
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		//Display properties selectors
		private System.Windows.Forms.ComboBox Rows;
		private System.Windows.Forms.ComboBox Columns;
		private System.Windows.Forms.ComboBox Frequency;
		private System.Windows.Forms.ComboBox Thickness;
		private System.Windows.Forms.ComboBox Density;
		//Number of counters on the monitored machine
		private int NoOfCounters=0;
		//Main menu and its items (options)
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem MenuExit;
		private System.Windows.Forms.MenuItem MenuStopGraphics;
		private System.Windows.Forms.MenuItem MenuStartGraphics;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		
		public Form1()
		{
			InitializeComponent();
			InitControls();
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
			this.label3 = new System.Windows.Forms.Label();
			this.MenuStartGraphics = new System.Windows.Forms.MenuItem();
			this.MachineNameText = new System.Windows.Forms.TextBox();
			this.Rows = new System.Windows.Forms.ComboBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.MenuStopGraphics = new System.Windows.Forms.MenuItem();
			this.MenuExit = new System.Windows.Forms.MenuItem();
			this.Thickness = new System.Windows.Forms.ComboBox();
			this.CountersTree = new System.Windows.Forms.TreeView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Density = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.Frequency = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.Columns = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.LoadButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.GraphicTabControl = new System.Windows.Forms.TabControl();
			this.TreeProgress = new System.Windows.Forms.ProgressBar();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.label3.Location = new System.Drawing.Point(320, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Rows";
			// 
			// MenuStartGraphics
			// 
			this.MenuStartGraphics.Index = 1;
			this.MenuStartGraphics.Text = "Sta&rt Graphics";
			this.MenuStartGraphics.Click += new System.EventHandler(this.MenuStartGraphics_Click);
			// 
			// MachineNameText
			// 
			this.MachineNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.MachineNameText.Location = new System.Drawing.Point(104, 24);
			this.MachineNameText.Name = "MachineNameText";
			this.MachineNameText.Size = new System.Drawing.Size(120, 20);
			this.MachineNameText.TabIndex = 1;
			this.MachineNameText.Text = "";
			// 
			// Rows
			// 
			this.Rows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Rows.DropDownWidth = 117;
			this.Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.Rows.Items.AddRange(new object[] {"1",
													  "2",
													  "3",
													  "4",
													  "5",
													  "6"});
			this.Rows.Location = new System.Drawing.Point(312, 48);
			this.Rows.Name = "Rows";
			this.Rows.Size = new System.Drawing.Size(56, 21);
			this.Rows.TabIndex = 7;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuStopGraphics,
																					  this.MenuStartGraphics,
																					  this.MenuExit});
			this.menuItem1.Text = "&Options";
			// 
			// MenuStopGraphics
			// 
			this.MenuStopGraphics.Index = 0;
			this.MenuStopGraphics.Text = "&Stop Graphics";
			this.MenuStopGraphics.Click += new System.EventHandler(this.MenuStopGraphics_Click);
			// 
			// MenuExit
			// 
			this.MenuExit.Index = 2;
			this.MenuExit.Text = "&Exit";
			this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
			// 
			// Thickness
			// 
			this.Thickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Thickness.DropDownWidth = 120;
			this.Thickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.Thickness.Items.AddRange(new object[] {"1",
														   "2",
														   "3",
														   "4",
														   "5"});
			this.Thickness.Location = new System.Drawing.Point(240, 48);
			this.Thickness.Name = "Thickness";
			this.Thickness.Size = new System.Drawing.Size(56, 21);
			this.Thickness.TabIndex = 5;
			// 
			// CountersTree
			// 
			this.CountersTree.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.CountersTree.CheckBoxes = true;
			this.CountersTree.ImageIndex = -1;
			this.CountersTree.Location = new System.Drawing.Point(8, 88);
			this.CountersTree.Name = "CountersTree";
			this.CountersTree.SelectedImageIndex = -1;
			this.CountersTree.Size = new System.Drawing.Size(240, 292);
			this.CountersTree.TabIndex = 0;
			this.CountersTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.CountersTree_AfterCheck);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.Density,
																					this.label6,
																					this.Frequency,
																					this.label5,
																					this.Columns,
																					this.label4,
																					this.label3,
																					this.Rows,
																					this.label2,
																					this.Thickness,
																					this.RefreshButton,
																					this.LoadButton,
																					this.label1,
																					this.MachineNameText});
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.groupBox1.Location = new System.Drawing.Point(8, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(592, 80);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Controls";
			// 
			// Density
			// 
			this.Density.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Density.DropDownWidth = 64;
			this.Density.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.Density.Items.AddRange(new object[] {"20 pts.",
														 "30 pts.",
														 "40 pts.",
														 "50 pts.",
														 "60 pts.",
														 "70 pts.",
														 "80 pts.",
														 "90 pts.",
														 "100 pts."});
			this.Density.Location = new System.Drawing.Point(528, 48);
			this.Density.Name = "Density";
			this.Density.Size = new System.Drawing.Size(56, 21);
			this.Density.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.label6.Location = new System.Drawing.Point(528, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Density";
			// 
			// Frequency
			// 
			this.Frequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Frequency.DropDownWidth = 120;
			this.Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.Frequency.Items.AddRange(new object[] {"1 sec.",
														   "2 sec.",
														   "3 sec.",
														   "4 sec.",
														   "5 sec."});
			this.Frequency.Location = new System.Drawing.Point(456, 48);
			this.Frequency.Name = "Frequency";
			this.Frequency.Size = new System.Drawing.Size(56, 21);
			this.Frequency.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.label5.Location = new System.Drawing.Point(456, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "Frequency";
			// 
			// Columns
			// 
			this.Columns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Columns.DropDownWidth = 128;
			this.Columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.Columns.Items.AddRange(new object[] {"1",
														 "2",
														 "3",
														 "4",
														 "5"});
			this.Columns.Location = new System.Drawing.Point(384, 48);
			this.Columns.Name = "Columns";
			this.Columns.Size = new System.Drawing.Size(56, 21);
			this.Columns.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.label4.Location = new System.Drawing.Point(384, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Columns";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.label2.Location = new System.Drawing.Point(232, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 14);
			this.label2.TabIndex = 6;
			this.label2.Text = "Line Thickness";
			// 
			// RefreshButton
			// 
			this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.RefreshButton.Location = new System.Drawing.Point(120, 50);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(104, 24);
			this.RefreshButton.TabIndex = 4;
			this.RefreshButton.Text = "&Refresh Display";
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// LoadButton
			// 
			this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.LoadButton.Location = new System.Drawing.Point(8, 50);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(96, 24);
			this.LoadButton.TabIndex = 3;
			this.LoadButton.Text = "&Load Counters";
			this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.label1.Location = new System.Drawing.Point(8, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "Machine Name";
			// 
			// GraphicTabControl
			// 
			this.GraphicTabControl.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.GraphicTabControl.Location = new System.Drawing.Point(256, 88);
			this.GraphicTabControl.Name = "GraphicTabControl";
			this.GraphicTabControl.SelectedIndex = 0;
			this.GraphicTabControl.Size = new System.Drawing.Size(344, 292);
			this.GraphicTabControl.TabIndex = 4;
			this.GraphicTabControl.Resize += new System.EventHandler(this.GraphicTabControl_Resize);
			// 
			// TreeProgress
			// 
			this.TreeProgress.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.TreeProgress.Location = new System.Drawing.Point(8, 383);
			this.TreeProgress.Name = "TreeProgress";
			this.TreeProgress.Size = new System.Drawing.Size(592, 13);
			this.TreeProgress.TabIndex = 5;
			this.TreeProgress.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(603, 396);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.TreeProgress,
																		  this.GraphicTabControl,
																		  this.groupBox1,
																		  this.CountersTree});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		

		//Set the initial values for the controls
		private void InitControls()
		{
			Rows.SelectedIndex=1;
			Columns.SelectedIndex=1;
			Thickness.SelectedIndex=0;
			Frequency.SelectedIndex=0;
			Density.SelectedIndex=1;
		}
		//The load button is in charge of filling up the treeview
		private void LoadButton_Click(object sender, System.EventArgs e)
		{
			ClearDisplay();
			LoadTreeView();
		}

		//Eliminate the old data
		private void ClearDisplay()
		{
			foreach(GraphicTab GT in GraphicTabControl.TabPages)
				GT.Controls.Clear();
			GraphicTabControl.TabPages.Clear();
			
			
		}
		//Load the treeView nodes
		private void LoadTreeView()
		{
			int NoOfNodes=0;
			System.Windows.Forms.TreeNode Root=null;
			LoadButton.Enabled=false;

			
			if (MachineNameText.Text.Equals(""))MachineNameText.Text=Environment.MachineName;
			MachineName=MachineNameText.Text;

			//Get the progressBar max val.
			NoOfNodes=CountNodes();
			if (NoOfNodes==-1)
			{
				//The machine is not accessible
				Root = new System.Windows.Forms.TreeNode(MachineName + " cannot be accessed !");
				CountersTree.Nodes.Clear();
				CountersTree.Nodes.Add(Root);
				LoadButton.Enabled=true;
				return;
			}
			TreeProgress.Maximum=NoOfNodes;
			TreeProgress.Value=0;
			TreeProgress.Visible=true;
			System.Diagnostics.PerformanceCounterCategory [] PCCategories=null;

			//Read all categories
			try
			{
				PCCategories = System.Diagnostics.PerformanceCounterCategory.GetCategories(MachineName);
			}
			catch{
				//Are you an admin on the machine ?
				MessageBox.Show("Could Not Load Data On: " + MachineName);
				LoadButton.Enabled=true;
				return;
			}
			//Sort the categories alphabetically
			string [] TmpCategNames = new String[PCCategories.Length];
			int Index =0;
			foreach(System.Diagnostics.PerformanceCounterCategory PCC in PCCategories )TmpCategNames[Index++]=PCC.CategoryName;
			System.Array.Sort(TmpCategNames,PCCategories,0,PCCategories.Length);
			//Create the tree root
			Root = new System.Windows.Forms.TreeNode(MachineName + " *** No. of Counters = " + NoOfCounters.ToString());
			this.Text=MachineName;
			//Whipe out of the old nodes
			CountersTree.Nodes.Clear();
			//Start filling out the new data
			CountersTree.Nodes.Add(Root);

			foreach (System.Diagnostics.PerformanceCounterCategory PCC in PCCategories )
			{//Create a node in the tree
				System.Windows.Forms.TreeNode CategoryNode = new System.Windows.Forms.TreeNode(PCC.CategoryName);
				Root.Nodes.Add(CategoryNode);
				TreeProgress.Value++;
				string [] InstanceNames = PCC.GetInstanceNames();
				if (InstanceNames.Length>0 )//Need the instance nodes
				{
					foreach(string InstanceName in InstanceNames)
					{//Create another node in the tree
						System.Windows.Forms.TreeNode InstanceNode = new System.Windows.Forms.TreeNode(InstanceName);
						//Don't block the system by loading data
						//Some machines have a huge number of counters
						System.Windows.Forms.Application.DoEvents();
						CategoryNode.Nodes.Add (InstanceNode);
						TreeProgress.Value++;
						try
						{
							foreach(System.Diagnostics.PerformanceCounter PC in PCC.GetCounters(InstanceName) )
							{
								InstanceNode.Nodes.Add(PC.CounterName);
								TreeProgress.Value++;
							}
						}
						catch
						{
							Console.WriteLine("PC Wrongly built. Missing InstanceName: " + InstanceName) ;//Some Category didn't have this InstanceName
						}
					}
				}
				else
				{
					foreach(System.Diagnostics.PerformanceCounter PC in PCC.GetCounters())
					{//Insert a leaf in the tree
						CategoryNode.Nodes.Add(PC.CounterName);
						TreeProgress.Value++;
					}
				}
				
			}
			TreeProgress.Visible=false;
			Root.Expand();
			LoadButton.Enabled=true;
		}

		//Check or uncheck a node in the tree
		//If the node is a leaf then it represents a counter so:
		// Either Insert a display for the counter
		//Either remove a display
		private void CountersTree_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			

			System.Diagnostics.PerformanceCounter PC=null;
			//See if this is a leaf node in the tree
			if (e.Node.Nodes.Count>0 )
			{
				//If it's not a leaf we don't have all the details to build a PerfCounter
				e.Node.Checked=false;
			}
			else
			{
				//Check whether there is an InstanceName or not (CounterName is always the leaf)
				int Parents=0;
				System.Windows.Forms.TreeNode tmpNode = e.Node;
				while (tmpNode!=null)
				{
					tmpNode=tmpNode.Parent;
					Parents++;
				}
				tmpNode=e.Node;
				
				if(Parents ==3)//There is no InstanceName
		
						
					PC = new System.Diagnostics.PerformanceCounter( tmpNode.Parent.Text,tmpNode.Text);
		
				else
					
					PC = new System.Diagnostics.PerformanceCounter(tmpNode.Parent.Parent.Text,tmpNode.Text,tmpNode.Parent.Text,MachineName );
					

				if(e.Node.Checked)//Insert the Display
					InsertCounter(PC);
				else //remove display
					RemoveCounter(PC,tmpNode);
			
			}
		}

		//Create a GraphicTab if needed
		//Insert a new counter on the TabControl
		private void InsertCounter(System.Diagnostics.PerformanceCounter PC)
		{
			bool CategoryExist=false;
			GraphicTab GT = null;
			DisplayPanel DP=null;

		//Check whether there is a tab for the category
			foreach(GraphicTab tmpGT in GraphicTabControl.TabPages )
			{
				if (tmpGT.Text.Equals(PC.CategoryName ))
				{
					CategoryExist=true;
					GT=tmpGT;
					break;
				}
			}
		
			if(!CategoryExist)//Create a TabPage for the category
			{
				int tmpRow= Rows.SelectedIndex+1;
				int tmpCols = Columns.SelectedIndex+1;
				int tmpTick = Thickness.SelectedIndex+1;
				string tmpVal = Frequency.SelectedItem.ToString().Substring(0,Frequency.SelectedItem.ToString().IndexOf(" "));
				int tmpFreq = int.Parse( tmpVal);
				tmpVal =  Density.SelectedItem.ToString().Substring(0,Density.SelectedItem.ToString().IndexOf(" "));
				int tmpDensity= int.Parse(tmpVal);
				//Create a GraphicTab and set its initial members values
				GT= new GraphicTab(PC.CategoryName,tmpTick ,tmpRow, tmpCols,tmpFreq,tmpDensity );
				GraphicTabControl.TabPages.Add(GT );
				GT.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
					| System.Windows.Forms.AnchorStyles.Left);	
			}

			DP = new DisplayPanel(PC,GT );
			GT.Controls.Add(DP);
			GraphicTabControl.SelectedIndex=GT.TabIndex;
		}

		//Remove a PerfCounter display from a tab
		private void RemoveCounter(System.Diagnostics.PerformanceCounter PC,System.Windows.Forms.TreeNode Node )
		{
			GraphicTab GT = null;
			string key=PC.CategoryName + PC.CounterName+PC.InstanceName;

			foreach(GraphicTab tmpGT in GraphicTabControl.TabPages )
			{
				if (tmpGT.Text.Equals(PC.CategoryName) )
				{
					GT = tmpGT;
					break;
				}
			}
			GT.RemoveDisplay(key);
			//No need to keep the tab anymore
			if (GT.Controls.Count==0 )GraphicTabControl.TabPages.Remove(GT);
			
		}
		//Count the number of nodes that will populate the treeView
		//Used to get the ProgressBar maxcount value
		private int CountNodes()
		{
			int result =0;
			NoOfCounters=0;
			string [] InstanceNames=null;
			try
			{
				//To get the number of nodes to be loaded in the tree
				System.Diagnostics.PerformanceCounterCategory[] PCCs = System.Diagnostics.PerformanceCounterCategory.GetCategories(MachineName);
				result +=PCCs.Length;
				foreach(System.Diagnostics.PerformanceCounterCategory pcc in PCCs )
				{
					InstanceNames = pcc.GetInstanceNames();
					result+=InstanceNames.Length;
					if (InstanceNames.Length>0) 
					{
						result += InstanceNames.Length * pcc.GetCounters(InstanceNames[0]).Length;
						NoOfCounters +=InstanceNames.Length * pcc.GetCounters(InstanceNames[0]).Length;
					}
					else 
					{
						result += pcc.GetCounters().Length;
						NoOfCounters +=pcc.GetCounters().Length;
					}
				}
			}
			catch{
				//Cannot access the machine
				result=-1;	
			}
			return result;
		}

		//Get the new values selected by the user and redraw the displays
		private void RefreshButton_Click(object sender, System.EventArgs e)
		{
			RedrawDisplay();	
		}

		//Clear all the controls and exit
		private void MenuExit_Click(object sender, System.EventArgs e)
		{
			CountersTree.Nodes.Clear();
			GraphicTabControl.TabPages.Clear();
			this.Close();
			Application.Exit();
		}

		//Stop the Clocks in each GraphicTab
		private void MenuStopGraphics_Click(object sender, System.EventArgs e)
		{
			foreach(GraphicTab GT in this.GraphicTabControl.TabPages )
				GT.Ticker.Enabled=false;
		}

		//Start the Clocks in each GraphicTab
		private void MenuStartGraphics_Click(object sender, System.EventArgs e)
		{
			foreach(GraphicTab GT in this.GraphicTabControl.TabPages )
				GT.Ticker.Enabled=true;
		}

		//Get the new values selected by the user and redraw the displays
		private void GraphicTabControl_Resize(object sender, System.EventArgs e)
		{
			RedrawDisplay();
		}

		//Read the selected display values and reset all the displays
		private void RedrawDisplay()
		{
			int tmpRow= Rows.SelectedIndex+1;
			int tmpCols = Columns.SelectedIndex+1;
			int tmpTick = Thickness.SelectedIndex+1;
			string tmpVal = Frequency.SelectedItem.ToString().Substring(0,Frequency.SelectedItem.ToString().IndexOf(" "));
			int tmpFreq = int.Parse( tmpVal);
			tmpVal =  Density.SelectedItem.ToString().Substring(0,Density.SelectedItem.ToString().IndexOf(" "));
			int tmpDensity= int.Parse(tmpVal);
			foreach(GraphicTab GT in GraphicTabControl.TabPages)
			{
				GT.SetDisplayProperties(tmpTick,tmpRow,tmpCols,tmpFreq,tmpDensity);
				GT.ResizeDisplays();
			}
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			RedrawDisplay();
		}
	}
}
