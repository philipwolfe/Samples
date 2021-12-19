namespace UserControlSample
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	/// <summary>
	///		Summary description for PairedListBox.
	/// </summary>
	public class PairedListBox : System.Web.UI.UserControl
	{
		ArrayList alList1;
		ArrayList alList2;
    
		//Private variables to store control property values (with default values)
		private string strLabel1 = "ListBox1" ;           //Label over first listbox
		private string strLabel2 = "ListBox2";            //Label over second listbox
		private string strAddButtonText = "Add" ;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divLabel1;
		protected System.Web.UI.WebControls.ListBox ListBox1;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.ListBox ListBox2;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divLabel2;         //Caption for top button
		private string strRemoveButtonText = "Remove" ;   //Caption for bottom button

		//Property to reference values in the first listbox
		public ArrayList List1Values
		{
			get
			{
				alList1 = GetValues(ListBox1);
				return alList1;
			}
			set
			{
				alList1 = value;
				SetList1Values();
			}
		}

		public ArrayList List2Values
		{
			//Property to reference values in the second listbox
			get
			{
				alList2 = GetValues(ListBox2);
				return alList2;
			}
		}

		public string Label1
		{
			//Property for the text of the label over the first listbox
			get
			{
				return strLabel1;
			}
			set
			{
				strLabel1 = value;
				SetProperties();
			}											
		}		
		
		public string Label2
		{
			//Property for the text of the label over the second listbox
			get
			{
				return strLabel2;
			}
			set
			{
				strLabel2 = value;
				SetProperties();
			}
		}				
		
		public string AddButtonText
		{
			//Property for the text of the top button which moves a value from the
			//first listbox to the second listbox
			get
			{
				return strAddButtonText;
			}
			set
			{
				strAddButtonText = value;
				SetProperties();
			}
		}


		public string RemoveButtonText
		{
			//Property for the text of the bottom button which moves a value from the
			//second listbox to the first listbox
			get
			{
				return strRemoveButtonText;
			}
			set
			{
				strRemoveButtonText = value;
				SetProperties();
			}
		}
							



		/// <summary>
		public PairedListBox()
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(this.IsPostBack != true)
			{
				SetProperties();
				this.ListBox1.Items.Add("Blue");
				this.ListBox1.Items.Add("Red");
				this.ListBox1.Items.Add("Green");
				this.ListBox1.Items.Add("Yellow");
			}
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Move(this.ListBox1, this.ListBox2); 
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			Move(this.ListBox2, this.ListBox1); 
		}

		private void Move(ListBox lstFrom, ListBox lstTo)
		{
			//Moves a value from the "From" listbox to the "To" listbox
			string strItem;
			int intIndex;
			
        
			if (lstFrom.SelectedIndex > -1)
			{
				strItem = lstFrom.SelectedItem.Text;
				//Remove the value from the "From" listbox            
				lstFrom.Items.Remove(strItem);
				//'Find the correct position in the "To" listbox to maintain alphabetical order
				for (intIndex = 0; intIndex<=(lstTo.Items.Count - 1);intIndex++)
				{
					if(strItem.CompareTo(lstTo.Items[intIndex].Text)<0)
					{
						break;
					}
				}
            //'Insert the value in the "To" listbox
				lstTo.Items.Insert(intIndex, strItem);
			}
		}
		
		private ArrayList GetValues(ListBox lstControl) 
		{
			//Retrieves values from a listbox and puts them in an ArrayList
			ArrayList al = new ArrayList();
			int intIndex;
        
			for (intIndex = 0; intIndex < lstControl.Items.Count;intIndex++)
			{
				al.Add(lstControl.Items[intIndex].Text);
			}
			return al;
		}

		private void SetProperties()
		{
			//Set properties of the constituent controls that can be modified by the user control container
			divLabel1.InnerText = strLabel1;
			divLabel2.InnerText = strLabel2;
			btnAdd.Text = strAddButtonText;
			btnRemove.Text = strRemoveButtonText;
		}

		private void SetList1Values()
		{
			//Populate the first listbox with values from an ArrayList        
			       
			ListBox1.Items.Clear();
			for (int intIndex = 0; intIndex < alList1.Count;intIndex++)
			{
				ListBox1.Items.Add(alList1[intIndex].ToString());
			}
		}    
					
	}
}
