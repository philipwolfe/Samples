using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;


namespace Ironring.Management.MMC
{

	/// <summary>
	/// This implements the equivalent of a Win32 PropertySheet 
	/// </summary>
	public class PropertySheet : Form
	{
		// Controls on the page        

		/// <summary>
		/// The OK button
		/// </summary>
		Button m_btnOk;        

		/// <summary>
		/// The Cancel button
		/// </summary>
		Button m_btnCancel;    

		/// <summary>
		/// Apply button
		/// </summary>
		Button m_btnApply;     

		/// <summary>
		/// The tab control
		/// </summary>
		PropertySheetTabControl m_tc;           


		/// <summary>
		/// The node that we represent properties for
		/// </summary>
		BaseNode m_ParentNode; 

		/// <summary>
		/// Typed collection of PropertyPages to display
		/// </summary>
		PropertyPageList m_alPages = new PropertyPageList();

		/// <summary>
		/// closed flag used to hide and not dispose of the form
		/// </summary>
		bool m_fClosed;        


		/// <summary>
		/// Construct provides linkage to the snapin node 
		/// </summary>
		/// <param name="node"></param>
		public PropertySheet(BaseNode node)
		{
			m_ParentNode = node;

			// Make sure nobody can resize this form
			FormBorderStyle = FormBorderStyle.FixedDialog;
			
			Icon = null;
			ShowInTaskbar = false;
			MaximizeBox = false;
			MinimizeBox = false;
			
			m_fClosed = false;
		}


		/// <summary>
		/// The Typed pages collection we display
		/// </summary>
		public PropertyPageList Pages
		{
			get{ return m_alPages; }
		}

		/// <summary>
		/// the node this propertysheet represents
		/// </summary>
		public BaseNode Node
		{
			get { return m_ParentNode; }
		}
		 
		/// <summary>
		/// Is the fake closed flag enabled on?  i.e. is the form hidden?
		/// </summary>
		public bool isClosed
		{
			get { return m_fClosed; }
		}


		/// <summary>
		/// Prepares the property sheet to be shown and then displays it
		/// </summary>
		public new void ShowDialog()
		{
			
			Controls.Clear();

			// Figure out how big to make the tab control 
			// by sizing to the largest UserControl

			int nWidth = 240; 
			int nHeight = 0;  

			// We'll be as wide as the widest and tall as the tallest page
			foreach (PropertyPage page in m_alPages)
			{
				if (page.Size.Width > nWidth)
					nWidth = page.Size.Width;
				if (page.Size.Height> nHeight)
					nHeight = page.Size.Height;
			}

			// Tab Control should be on the top...
			m_tc = new PropertySheetTabControl();

			// Add the pages to the sheet
			foreach (PropertyPage page in m_alPages)
			{
				// Initialize the Property Pages
				page.PropertySheet = this;
				// Create a Tab page that we can use
				m_tc.TabPages.Add(page.CreateTabPage());
			}

			// Add the height of the tab thingy and the indentation
			m_tc.Location = new Point(4, 5);
			m_tc.SelectedIndexChanging += new CheckValidation(onTabPageChanged);

			m_tc.TabIndex = 0;
			Controls.Add(m_tc);

			// Adjust the height of of the tab control to account for the
			// margin and the tabs up top.

			// We need to do this so the Tab Control gets created on the Win32 side of
			// things, which makes m_tc.ItemSize.Height valid.
			IntPtr handle = m_tc.Handle;

			nHeight += m_tc.Location.Y + m_tc.ItemSize.Height;

			m_tc.Size = new System.Drawing.Size(nWidth, nHeight);


			// Now put the Ok, Cancel, and Apply buttons on the page.

			// We'll have a 15 pixel buffer between the tab control and the buttons
			nHeight += 15;

			m_btnApply = new Button();
			m_btnApply.Size = new System.Drawing.Size(75, 23);
			m_btnApply.Location = new Point(nWidth-m_btnApply.Width+4, nHeight);
			m_btnApply.Text = "Apply";
			m_btnApply.Enabled = false;
			m_btnApply.TabIndex = 3;
			m_btnApply.Click += new EventHandler(onApplyClick);
			Controls.Add(m_btnApply);

			m_btnCancel = new Button();
			m_btnCancel.Size = new System.Drawing.Size(75, 23);
			m_btnCancel.Location = new Point(m_btnApply.Location.X - m_btnCancel.Width-5, nHeight);
			m_btnCancel.Text = "Cancel";
			m_btnCancel.Click += new EventHandler(onCancelClick);
			m_btnCancel.TabIndex = 2;
			Controls.Add(m_btnCancel);

			m_btnOk = new Button();
			m_btnOk.Size = new System.Drawing.Size(75, 23);
			m_btnOk.Location = new Point(m_btnCancel.Location.X - m_btnOk.Width - 5, nHeight);
			m_btnOk.Text = "OK";
			m_btnOk.TabIndex = 1;
			m_btnOk.Click += new EventHandler(onOkClick);
			Controls.Add(m_btnOk);


			// Make sure we account for the height of the button
			nHeight +=m_btnOk.Height;
            
			// We have a 4 pixel margin on each side of the tab control, and a 5 pixel margin
			// between the buttons and the bottom of the page
			ClientSize = new System.Drawing.Size(nWidth + 8, nHeight + 5);
			this.AcceptButton = m_btnOk;
			this.CancelButton = m_btnCancel;
            
			// And finally, make us actually show
			base.ShowDialog();
		}

		/// <summary>
		/// Event handler that pops up when the user tries to  
		/// change property pages. Make sure that the data on the
		/// page they're leaving is correct.
		/// </summary>
		/// <returns></returns>
		bool onTabPageChanged()
		{   
			PropertyPage page = m_alPages[m_tc.SelectedIndex];
			return page.ValidateData();
		}

		/// <summary>
		/// The user clicked ok. Treat it as an Apply, and then close the page
		/// </summary>
		/// <param name="o"></param>
		/// <param name="e"></param>
		void onOkClick(Object o, EventArgs e)
		{
			PropertyPage page = m_alPages[m_tc.SelectedIndex];
            
			if (page.ValidateData())
			{
				onApplyClick(o, e);
				FakeClose();
			}
		}


		/// <summary>
		/// The user clicked cancel. 
		/// </summary>
		/// <param name="o"></param>
		/// <param name="e"></param>
		void onCancelClick(Object o, EventArgs e)
		{
			foreach(PropertyPage page in m_alPages)
				page.onCancel();
			FakeClose();
		}


		/// <summary>
		/// The user clicked apply. Validate the current page's 
		/// data, and then send an apply message to every page
		/// </summary>
		/// <param name="o"></param>
		/// <param name="e"></param>
		void onApplyClick(Object o, EventArgs e)
		{
			PropertyPage psp = m_alPages[m_tc.SelectedIndex];
            
			if (psp.ValidateData())
			{
				SendApplyToAll();
				m_btnApply.Enabled = false;
			}
		}

		/// <summary>
		/// Turn on the apply button 
		/// </summary>
		public void ActivateApplyButton()
		{   
			if (m_btnApply != null)
				m_btnApply.Enabled = true;
		}


		/// <summary>
		/// This sends the apply message to every 
		/// </summary>
		private void SendApplyToAll()
		{
			foreach(PropertyPage page in m_alPages)
				page.onApply();
		}


		/// <summary>
		/// We need to close this page (make it invisible), but
		/// we don't want it to dispose itself. Instead, we'll
		/// just muck with the form so the next time it's made visible,
		/// it looks brand new
		/// </summary>
		private void FakeClose()
		{
			m_fClosed = true;
			Close();
		}
	}






	/// <summary>
	/// This implements the equivalent of a Win32 PropertyPage 
	/// </summary>
	public class PropertyPage
	{
		/// <summary>
		/// The node we're associated with
		/// </summary>
		protected BaseNode m_Node;         
 
		/// <summary>
		/// The property sheet we belong to
		/// </summary>
		protected PropertySheet m_PropSheet;    

		/// <summary>
		/// The title of our page - string on the tab
		/// </summary>
		protected String m_sTitle;       
	
		/// <summary>
		/// the type of control to activate int he page client area
		/// </summary>
		protected Type m_ControlType;     

		/// <summary>
		/// the instance of the control once activated 
		/// </summary>
		protected UserControl m_Control = null;        


		/// <summary>
		/// Event fires when page must validate page contents
		/// </summary>
		public event EventHandler validate;

		/// <summary>
		/// Fires when page must apply page contents
		/// </summary>
		public event EventHandler apply;

	
		/// <summary>
		/// Fires when user cancels the propsheet
		/// </summary>
		public event EventHandler cancel;



		/// <summary>
		/// constructor provides context
		/// </summary>
		/// <param name="title"></param>
		/// <param name="node"></param>
		public PropertyPage(string title, BaseNode node)
		{
			m_sTitle = title;
			m_Node = node;
		}

		/// <summary>
		/// Set the type of User Control to serve as the property page guts
		/// </summary>
		public Type ControlType
		{
			get { return m_ControlType; } 
			set { m_ControlType = value; }
		}


		/// <summary>
		/// Sets the PropertySheet we're the property page of 
		/// </summary>
		/// <param name="ps"></param>
		public PropertySheet PropertySheet
		{
			set	{ m_PropSheet = value; }
			get { return m_PropSheet; }
		}


		protected UserControl MainControl 
		{
			get 
			{ 
				try
				{
					if (m_Control == null)
					{
						m_Control = (UserControl)Activator.CreateInstance(ControlType);

						// check if the usercontrol implements IPropertyPageContext
						// if so provide a back reference to ourselves.
						IPropertyPageContext ctx = m_Control as IPropertyPageContext;
						if(ctx != null)
							ctx.PropertyPage = this;
					}
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine("PropertyPage Exception - " + e.ToString());
					throw new SnapinException ("Failed to create user control", e);
				}
				return m_Control;
			}
		}


		/// <summary>
		/// Generate the actual TabPage that will  used in the PropertySheet.
		/// We don't keep re-using the same TabPage each time
		/// the property page is created because it makes the 
		/// updating of the property pages a little difficult.
		/// Creating a new one each time makes sure we have fresh
		/// data in the property page.
		/// </summary>
		/// <returns>the actual window used as the propertypage</returns>
		public TabPage CreateTabPage()
		{   
			TabPage tp = new TabPage();

			UserControl ctrl = MainControl;

			ctrl.Location = new Point(0, 0);
			ctrl.Size = Size;
			ctrl.TabIndex = 0;

			// Parent this control to our user control
			tp.Controls.Add(ctrl);

			tp.Size = Size;
			tp.Text = Title;
		
			return tp;
		}



		/// <summary>
		/// The string displayed int he tab
		/// </summary>
		public String Title
		{
			get { return m_sTitle; }
			set { m_sTitle = value; }
		}
      

		/// <summary>
		/// size of the property sheet page
		/// </summary>
		public Size Size
		{
			get { return MainControl.Size; }
			set { MainControl.Size = value; }
		}


		/// <summary>
		/// Method that gets called to validate the values in the TabPage 
		/// </summary>
		/// <returns></returns>
		public virtual bool ValidateData()
		{   
			if (validate != null)
			{
				ValidateEventArgs args = new ValidateEventArgs();
				validate(this, args);
				
				// if no one set the invalid page all is good
				return args.Valid;
			}

			return true;
		}

		/// <summary>
		/// Method that gets called to apply the values in the TabPage 
		/// </summary>
		public virtual void onApply()
		{
			if (apply != null)
				apply(this, null);
		}

		/// <summary>
		/// Method that gets called when cancel is clicked
		/// </summary>
		public virtual void onCancel()
		{
			if (cancel != null)
				cancel(this, null);
		}

		/// <summary>
		/// Method to call that turns on the apply button 
		/// </summary>
		protected void ActivateApply()
		{
			m_PropSheet.ActivateApplyButton();
		}

	}


	public class ValidateEventArgs : System.EventArgs
	{
		protected bool valid = true;

		public bool Valid
		{
			get { return valid; }
			set { valid = value; }
		}
	}


	public delegate bool CheckValidation(); 

	/// <summary>
	/// Custom TabControl to simulate a property sheet tabs
	/// </summary>
	public class PropertySheetTabControl : TabControl
	{
		private CheckValidation onSelectedIndexChanging;

		public event CheckValidation SelectedIndexChanging 
		{
			add 
			{
				onSelectedIndexChanging += value;
			}
			remove 
			{
				onSelectedIndexChanging -= value;
			}
		}

		protected override void WndProc(ref Message m)
		{
			try
			{
				// See if this is a special Winforms notify message
				if (m.Msg == ((int)WM.NOTIFY + 0x0400 + 0x1C00)) // WM_USER + WM_REFLECT
				{
					// lParam really is a pointer to a NMHDR structure....
					NMHDR nm = new NMHDR();
					nm = (NMHDR)Marshal.PtrToStructure(m.LParam, nm.GetType());

					// See if this is our command
					if (nm.code == unchecked((0U-550U)-2))  // TCN_SELCHANGING  = TCN_FIRST - 2
					{
						if (onSelectedIndexChanging != null) 
							if (!onSelectedIndexChanging())       
							{
								m.Result = (IntPtr)1;
								return;
							}
					}
				}
				base.WndProc(ref m);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Erro rin winProc: " + e.Message);

			}
		}
	}



	/// <summary>
	/// Typed collection of PropertyPage objects to help out PropertySheet
	/// </summary>
	public class PropertyPageList : ArrayList
	{
		public new PropertyPage this[int index]
		{
			get
			{
				return (PropertyPage)(base[index]);
			}
		}
	}


}
