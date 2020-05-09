using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace Ironring.Management.MMC
{
	/// <summary>
	/// All MMC snapin Nodes derive from BaseNode to provided basic services and 
	/// communication with the SnapinBase class.
	/// </summary>
	public class BaseNode
	{
        /// <summary>
        /// Back reference to my snapin
        /// </summary>
		protected SnapinBase m_Snapin;

        /// <summary>
        /// The guid type for this node 
        /// //TBD not really used right now!
        /// </summary>
        protected Guid m_guid;

		/// <summary>
		/// added by Roman Kiss
		/// The node tag (for general purposes) 
		/// //general purpose
		/// </summary>
		protected object m_tag;

        /// <summary>
        /// collection of children nodes
        /// </summary>
		protected ArrayList m_ChildNodes;

        /// <summary>
        /// The display name appears in the scope pane (tree)
        /// </summary>
		protected string m_sDisplayName;

	        /// <summary>
        /// Out opaque id we assign and pass to MMC
        /// </summary>
		protected int m_iCookie;              

        /// <summary>
        /// MMC's unique identifier for this object 
        /// </summary>
		protected int m_iHScopeItem;          

        /// <summary>
        /// MMC's unique identifier for the parent
        /// </summary>
		protected int m_iParentHScopeItem;    

        /// <summary>
        /// Collection of images to use for this node's result pane
        /// </summary>
		protected ImageList m_Images = null;

        /// <summary>
        /// Default collection of images to use for result pane
        /// </summary>
        protected static ImageList s_DefaultImages = null;


        /// <summary>
        /// Index into ImageCollection
        /// </summary>
        protected int m_nClosedImage = 0;
        
        /// <summary>
        /// Index into ImageCollection
        /// </summary>
        protected int m_nOpenImage = 1;

        /// <summary>
        /// Index into ImageCollection
        /// </summary>
        protected int m_nSmallImage  = 0;

        /// <summary>
        /// Index into ImageCollection
        /// </summary>
        protected int m_nLargeImage  = 1;
        

        /// <summary>
        /// primary index of all menuitems, All other types are duplicated here
        /// to make it easy to find them again when MMC invoke one.
        /// </summary>
		protected ArrayList m_MenuItems = null;	   

        /// <summary>
        /// All "Top" menu items
        /// </summary>
		protected ArrayList m_TopMenuItems = null;
        
        /// <summary>
        /// All "New" menu items
        /// </summary>
        protected ArrayList m_NewMenuItems = null;
        
        /// <summary>
        /// All "Task" menu items
        /// </summary>
        protected ArrayList m_TaskMenuItems = null;
        
        /// <summary>
        /// All "View" menu items
        /// </summary>
        protected ArrayList m_ViewMenuItems = null;
		
        /// <summary>
        /// Collection of property pages for this node
        /// </summary>
		protected ArrayList m_propertyPages = new ArrayList();        

		/// <summary>
		/// The optional property sheet for this node
		/// </summary>
		protected PropertySheet m_propSheet;

        /// <summary>
        /// Implements a spare collection of events to save space 
        /// when the common case is now one registers.
        /// </summary>
        protected EventHandlerSet m_events = new EventHandlerSet();

        /// <summary>
        /// The events prublished by all nodes.  These keys are used to 
        /// identify the event notification type.
        /// </summary>
        protected static object OnActivateKey = new object();
        protected static object OnAddScopePaneImagesKey = new object();
        protected static object OnAddResultPaneImagesKey = new object();
        protected static object OnBtnClickKey = new object();
        protected static object OnClickKey = new object();
        protected static object OnColumnClickKey = new object();
        protected static object OnCutOrRemoveKey = new object();
        protected static object OnDblClickKey = new object();
        protected static object OnDeleteKey = new object();
        protected static object OnDeselectAllKey = new object();
        protected static object OnExpandKey = new object();
        protected static object OnCollapseKey = new object();
        protected static object OnInitOcxKey = new object();
        protected static object OnMenuBtnClickKey = new object();
        protected static object OnMaximizedKey = new object();
        protected static object OnMinimizedKey = new object();
        protected static object OnQueryPasteKey = new object();
        protected static object OnRefreshKey = new object();
        protected static object OnRemoveChildrenKey = new object();
        protected static object OnRenameKey = new object();
        protected static object OnSelectScopeKey = new object();
        protected static object OnDeselectScopeKey = new object();
        protected static object OnSelectResultKey = new object();
        protected static object OnDeselectResultKey = new object();
        protected static object OnShowKey = new object();
        protected static object OnViewChangeScopeKey = new object();
        protected static object OnViewChangeResultKey = new object();
        protected static object OnContextHelpKey = new object();
				//---added by Roman Kiss
				protected static object OnUserKey = new object();
				//---added by Roman Kiss
				protected static object OnQueryPropertiesKey = new object();
		

        ////////////////////////////////////////////////////////////////////////////
        ///
        /// Implementation
        ///
        

        /// <summary>
        /// Base ctor must be called by all derivatives to register ourselves 
        /// with the snapinbase.  This process assigned the cookie
        /// </summary>
        /// <param name="snapin"></param>
		public BaseNode(SnapinBase snapin)
		{
			m_Snapin = snapin;
			m_iCookie = snapin.Register(this);

			m_iHScopeItem = 0;
			m_iParentHScopeItem = 0;

			m_ChildNodes = new ArrayList(8);
		}

        /// <summary>
        /// finalizer cleanup
        /// </summary>
		~BaseNode()
		{
            // TBD: any unmanged resources?  IDisposable
		}


        /// <summary>
        /// our unique id - opaque don't infer a thing from it! 
        /// </summary>
		public int Cookie
		{
			get { return m_iCookie; }
			set { m_iCookie = value; }
		}

        /// <summary>
        /// back reference to the snapin this node belongs to 
        /// </summary>
		public SnapinBase Snapin
		{
			get { return m_Snapin; }
		}

        /// <summary>
        /// whether or not property pages are supported, default false
        /// </summary>
		public bool HavePropertyPages
		{
			get { return m_propertyPages.Count != 0; }
		}

        /// <summary>
        /// MMC's unique id for this node's parent 
        /// </summary>
		public int ParentHScopeItem
		{
			get { return m_iParentHScopeItem; }
			set { m_iParentHScopeItem = value; }
		}

        /// <summary>
        /// MMC's unique id for this node 
        /// </summary>
		public int HScopeItem
		{
			get { return m_iHScopeItem; }
			set { m_iHScopeItem = value; }
		}

        /// <summary>
        /// The name of this Node
        /// </summary>
        public string DisplayName
		{
			get { return m_sDisplayName; }
			set { m_sDisplayName = value; }
		}

        /// <summary>
        /// Set or get the result view image colleciton for this node.
        /// The images are indexed by the overridable GetResultViewImageIndex
        /// method.  Many nodes can share the same image index.
        /// </summary>
        /// <param name="iconResourceName"></param>
        public ImageList ResultPaneImages
        {
            get 
            { 
                if (m_Images == null)
                    return s_DefaultImages;
                return m_Images;
            }
            set { m_Images = value; }
        }

        /// <summary>
        /// Set or get the default result view image colleciton.
        /// The images are indexed by the overridable GetResultViewImageIndex
        /// method.  Many nodes can share the same image index.
        /// </summary>
        public static ImageList DefaultResultPaneImages
        {
            get { return s_DefaultImages; }
            set { s_DefaultImages = value; }
        }
        

        /// <summary>
        /// index into the ImageCollection
        /// </summary>
        public int ClosedImageIndex
        {
            get { return m_nClosedImage; }
            set { m_nClosedImage = value; }
        }

        /// <summary>
        /// index into the ImageCollection
        /// </summary>
        public int OpenImageIndex
        {
            get { return m_nOpenImage; }
            set { m_nOpenImage = value; }
        }

        /// <summary>
        /// index into the ImageCollection
        /// </summary>
        public int SmallImageIndex
        {
            get { return m_nSmallImage; }
            set { m_nSmallImage = value; }
        }

        /// <summary>
        /// index into the ImageCollection
        /// </summary>
        public int LargeImageIndex
        {
            get { return m_nLargeImage; }
            set { m_nLargeImage = value; }
        }

        /// <summary>
        /// The guid or this node type - used in DataObject
        /// </summary>
		public Guid Guid
		{
			get { return m_guid; }
			set { m_guid = value; }
		}

		
		/// <summary>
		/// added by Roman Kiss
		/// The node tag for general purposes.
		/// </summary>
		public object Tag
		{
			get { return m_tag; }
			set { m_tag = value; }
		}

        /// <summary>
        /// how many children do we have, if any?
        /// </summary>
		public int NumChildren
		{
			get { return (m_ChildNodes == null) ?  0 : m_ChildNodes.Count; }
		}

        /// <summary>
        /// Return the children collection as an array
        /// </summary>
		public BaseNode[] Children
		{
			get { return (BaseNode[])m_ChildNodes.ToArray(); }
		}


        //////////////////////////////////////////////////////////////////
        ///
        /// Methods
        ///
        

        /// <summary>
        /// called after creation to perform one time init tasks
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Add a node to the child colleciton
        /// </summary>
        /// <param name="node"></param>
		public void AddChild(BaseNode node)
		{
			m_ChildNodes.Add(node);
		}

        /// <summary>
        /// insert this node into the console namespace
        /// </summary>
        /// <param name="parent"></param>
		public void Insert(BaseNode parent)
		{
			IConsoleNameSpace2 cns = Snapin.ConsoleNameSpace;

			SCOPEDATAITEM sdi = new SCOPEDATAITEM();
			
			sdi.mask =	(uint)SDI.STR		|   
						(uint)SDI.PARAM     |   
						(uint)SDI.PARENT    |
						(uint)SDI.IMAGE     |
						(uint)SDI.OPENIMAGE |
						(uint)SDI.CHILDREN;

            // TBD: consider doing the dynamic update of images using 
            // IConsoleNameSpace2::SetItem

			// The image index is going to be the same as the cookie value
			sdi.nImage      = ClosedImageIndex;

			// The open image is the same as the closed image
			sdi.nOpenImage  = OpenImageIndex;

			sdi.relativeID  = parent.HScopeItem;
			// We set displayname to -1 to initiate a callback for the string
			// (We need to do it this way... it's an MMCism)
			sdi.displayname = (IntPtr)(-1);
    
			sdi.lParam      = Cookie;

			// The children field is set to either 0 or 1 (if it has children or not)
			sdi.cChildren   = NumChildren == 0 ? 0 : 1; 
    
			cns.InsertItem(ref sdi);

			// Once the item has been inserted, we're given the HScopeItem value for the node
			// MMC uses this value to uniquely identify the node. We'll store it for future
			// use.
			HScopeItem = sdi.ID;
			
			// We'll also put in the parent's HScopeItem
			ParentHScopeItem = parent.HScopeItem;
		}

        /// <summary>
        /// This function adds all the node's children to MMC
        /// </summary>
		public void InsertChildren()
		{
			foreach (BaseNode node in m_ChildNodes)
				node.Insert(this);
		}

        /// <summary>
        /// Dynamically add menu items to the context menus 
        /// </summary>
        /// <param name="piCallback"></param>
        /// <param name="pInsertionAllowed"></param>
		public virtual void AddMenuItems(IContextMenuCallback piCallback, ref int pInsertionAllowed)
		{
			// Conditionally add our menu items
			if ((pInsertionAllowed & (int)CCM.INSERTIONALLOWED_TOP) > 0)
				OnAddTopMenu(piCallback);
			
			if ((pInsertionAllowed & (int)CCM.INSERTIONALLOWED_NEW) > 0)
				OnAddNewMenu(piCallback);

			if ((pInsertionAllowed & (int)CCM.INSERTIONALLOWED_TASK) > 0)
				OnAddTaskMenu(piCallback);

			if ((pInsertionAllowed & (int)CCM.INSERTIONALLOWED_VIEW) > 0)
				OnAddViewMenu(piCallback);
		}

        /// <summary>
        /// Add a property page to the node.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="userControlType"></param>
        public void AddPropertyPage(string title, Type userControlType)
        {
            PropertyPage page = new PropertyPage(title, this);
            page.ControlType = userControlType;
            m_propertyPages.Add(page);
        }


        /// <summary>
		/// Virtual method to provide Result view configuration information
		/// </summary>
		/// <param name="pViewOptions"></param>
		/// <returns></returns>
		public virtual string GetResultViewType(ref int pViewOptions)
		{
			// the default for std list views
			pViewOptions = 0;
			return string.Empty;		
		}


        /// <summary>
        /// This function will provide MMC with information on how
        /// to display data items in the result pane. This function
        /// is used to get data both for a column view and a list view.
        /// TBD: trim down for basic list view only - reporting stuff is in reportnode
        /// </summary>
        /// <param name="ResultDataItem"></param>
		public virtual void GetDisplayInfo(ref RESULTDATAITEM ResultDataItem)
		{
			// If we need a display name
			if ((ResultDataItem.mask & (uint)RDI.STR) > 0)
				ResultDataItem.str = Marshal.StringToCoTaskMemUni(m_sDisplayName);

			// return the image current index for the image on the result pane
			if ((ResultDataItem.mask & (uint)RDI.IMAGE) > 0)
				ResultDataItem.nImage = (Cookie << 16) + GetResultViewImageIndex();

			if ((ResultDataItem.mask & (uint)RDI.PARAM) > 0)
				ResultDataItem.lParam = m_iCookie;

			// Don't know what this field is for, MSDN isn't clear
			// on it... just set it to 0 if we need to
			if ((ResultDataItem.mask & (uint)RDI.INDEX) > 0)
				ResultDataItem.nIndex = 0;
            
			// Reserved
			if ((ResultDataItem.mask & (uint)RDI.INDENT) > 0)
				ResultDataItem.iIndent = 0;
		}

        /// <summary>
        /// provides scope pane infor to MMC  
        /// </summary>
        /// <param name="sdi"></param>
		public virtual void GetDisplayInfo(ref SCOPEDATAITEM sdi)
		{
			// See if they want the display name
			if ((sdi.mask & (uint)SDI.STR) > 0)
				sdi.displayname = Marshal.StringToCoTaskMemUni(DisplayName);

			// We shouldn't need to set this.... but if we need to...
			if ((sdi.mask & (uint)SDI.STATE) > 0)
				sdi.nState = 0; 

			// If we're inquiring about children....
			if ((sdi.mask & (uint)SDI.CHILDREN) > 0)
				sdi.cChildren = NumChildren;
		}

        /// <summary>
        /// This function will create property sheet pages based 
        /// on the information stored in its m_propertyPages field.
        /// It registers the property page along with the callback
        /// functions.
        /// </summary>
        /// <param name="lpProvider"></param>
        /// <param name="handle"></param>
		virtual public void CreatePropertyPages(IPropertySheetCallback lpProvider, IntPtr handle)
		{
			if (!HavePropertyPages)
				return;

			if (this.m_propSheet == null || m_propSheet.isClosed)
			{   
				// We need to spin off a new thread for this.
				// Why?
				// For winforms forms to work correctly (including accelerators, etc)
				// we need to use a winforms message pump. We can accomplish that
				// by showing our form using Form.ShowDialog().
				// However, this blocks the thread's execution until the dialog
				// is dismissed. We'll get around this by spinning off another thread
				// to handle the form.
				new Thread(new ThreadStart(CreatePropertySheet)).Start();
			}
			else
			{
				m_propSheet.Activate();
			}
		}

		/// <summary>
		/// This function should be called on the non-MMC thread.  We need 
		/// to create the property sheet on the thread that will be used to host 
		/// the property sheet.
		/// </summary>
		private void CreatePropertySheet()
		{
			m_propSheet = new PropertySheet(this);
			foreach (PropertyPage page in m_propertyPages)
				m_propSheet.Pages.Add(page);

			m_propSheet.Text = DisplayName + " Properties";
			m_propSheet.ShowDialog();
		}
        
        
        ///////////////////////////////////////////////////////////////////////
		///
		/// Notification methdos
		///



        /// <summary>
        /// Is sent when a window is being activated or deactivated, the 
        /// flag indicates which.
        /// </summary>
        /// <param name="bActivate"></param>
		public virtual void OnActivate(bool bActivate)
		{
            m_events.Fire(OnActivateKey, this, new ActivateArgs(bActivate));
		}

        /// <summary>
        /// called to add scope (tree) pane images to the MMC 
        /// provided image list. 
        /// By default we don't add any images but delegate to our children
        /// because they might want to.
        /// if you override this method call this to delegate to children.
        /// </summary>
        /// <param name="il"></param>
		public virtual void OnAddScopePaneImages(IImageList il)
		{
			foreach(BaseNode node in m_ChildNodes)
				node.OnAddScopePaneImages(il);

            m_events.Fire(OnAddScopePaneImagesKey, this, new AddImagesArgs(il));
		}

        /// <summary>
        /// called to add result pane images to the MMC 
        /// provided image list. 
        /// </summary>
        /// <param name="il"></param>
        public virtual void OnAddResultPaneImages(IImageList il)
        {
            if (ResultPaneImages != null)
                ResultPaneImages.LoadImageList(il, m_iCookie);


            // Now add all the children images
            foreach(BaseNode node in m_ChildNodes)
                node.OnAddResultPaneImages(il);

            m_events.Fire(OnAddResultPaneImagesKey, this, new AddImagesArgs(il));
        }

        /// <summary>
        /// Called when user clicks on a ControlBar button
        /// </summary>
        /// <param name="CmdId">ID assigned to button</param>
		public virtual void OnBtnClick(int CmdId)
		{
            m_events.Fire(OnBtnClickKey, this, new CommandArgs(CmdId));
		}

        /// <summary>
        /// TBD: huh?
        /// </summary>
		public virtual void OnClick()
		{
            m_events.Fire(OnClickKey, this, null);
        }

        /// <summary>
        /// user clicks on a result listview column header
        /// </summary>
        /// <param name="nCol">column number</param>
        /// <param name="bAscending"></param>
		public virtual void OnColumnClick(int nCol, bool bAscending)
		{
        }

        /// <summary>
        /// Cut or remove clipboard operation
        /// </summary>
		public virtual void OnCutOrRemove()
		{
            m_events.Fire(OnCutOrRemoveKey, this, null);
        }

        /// <summary>
        /// Double clicked on a node.
        /// </summary>
		public virtual void OnDblClick()
		{
            m_events.Fire(OnDblClickKey, this, null);
        }

        /// <summary>
        /// Sent to inform the snapin that the user wants to delete the node. 
        /// </summary>
		public virtual void OnDelete()
		{
            m_events.Fire(OnDeleteKey, this, null);
        }

        /// <summary>
        /// This message is sent when all items of an owner-data result pane
        //	are deselected.
        /// </summary>
		public virtual void OnDeselectAll()
		{
            m_events.Fire(OnDeselectAllKey, this, null);
        }

        /// <summary>
        /// called when node is expanding 
        /// </summary>
		public virtual void OnExpand()
		{
			InsertChildren();
            m_events.Fire(OnExpandKey, this, null);
        }
        
        /// <summary>
        /// Called when node is collapsing
        /// </summary>
		public virtual void OnCollapse()
		{
            m_events.Fire(OnCollapseKey, this, null);
        }

        /// <summary>
        /// Sent to a snap-in when its custom OCX is initialized for the first time.
        /// </summary>
        /// <param name="objOCX">The control IUnknown</param>
        /// <returns></returns>
        public virtual bool OnInitOcx(object objOCX)
        {
            m_events.Fire(OnInitOcxKey, this, new ObjectArgs(objOCX));
            return false;
        }

		/// <summary>
		/// added by Roman Kiss
		/// Sent to a snap-in by user application.
		/// </summary>
		/// <param name="obj">general object</param>
		public virtual void OnUser(string key, object val)
		{
			m_events.Fire(OnUserKey, this, new NameValueArgs(key, val));
		}

		/// <summary>
		/// added by Roman Kiss
		/// Sent by a snap-in when it query for properties pages.
		/// </summary>
		public virtual void OnQueryProperties()
		{
			m_events.Fire(OnQueryPropertiesKey, this, null);
		}
		
        /// <summary>
        /// This message is sent when a user clicks on a button.
        /// </summary>
        /// <param name="CmdId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
		public virtual void OnMenuBtnClick(int CmdId, int x, int y)
		{
		}

        /// <summary>
        /// Window is being maximized
        /// </summary>
		public virtual void OnMaximized()
		{
            m_events.Fire(OnMaximizedKey, this, null);
        }

        /// <summary>
        /// Window is being minimized
        /// </summary>
		public virtual void OnMinimized()
		{
            m_events.Fire(OnMinimizedKey, this, null);
        }

        /// <summary>
        /// Can the ido item be pasted?
        /// </summary>
        /// <param name="ido">IDataObject of item to be pasted</param>
        /// <returns></returns>
		public virtual bool OnQueryPaste(IDataObject ido)
		{
			return false;
		}

        /// <summary>
        /// Result view is refreshed
        /// </summary>
		public virtual void OnRefresh()
		{
            m_events.Fire(OnRefreshKey, this, null);
        }

        /// <summary>
        /// Informs the snapin to delete all the cookies it has added below.
        /// </summary>
		public virtual void OnRemoveChildren()
		{
            m_events.Fire(OnRemoveChildrenKey, this, null);
        }

        /// <summary>
        ///  Calle dto see if the node can be renamed
        /// </summary>
        /// <returns></returns>
		public virtual bool OnTryRename()
		{
			return false;
		}

        /// <summary>
        /// Called to supply the renamed value.  Return true if successful
        /// </summary>
        /// <param name="newName"></param>
        /// <returns></returns>
		public virtual bool OnRename(string newName)
		{
            m_events.Fire(OnRenameKey, this, null);
            return false;
		}

        /// <summary>
        /// Called when node is selected in the scope pane
        /// </summary>
        /// <param name="console"></param>
		public virtual void OnSelectScope()
		{
			// Get the IConsoleVerb interface from MMC

			IConsoleVerb icv;       
			Snapin.ResultViewConsole.QueryConsoleVerb(out icv);

			// See if we need to enable then property sheets item on the popup menu
			if (HavePropertyPages)
				icv.SetVerbState(MMC_VERB.PROPERTIES, MMC_BUTTON_STATE.ENABLED, 1);
			else
				icv.SetVerbState(MMC_VERB.PROPERTIES, MMC_BUTTON_STATE.ENABLED, 0);

            m_events.Fire(OnSelectScopeKey, this, null);
        }

        /// <summary>
        /// Called when node is deselected in the scope pane
        /// </summary>
        /// <param name="console"></param>
        public virtual void OnDeselectScope()
        {
            m_events.Fire(OnDeselectScopeKey, this, null);
        }

        /// <summary>
        /// Called when node is selected in the result pane
        /// </summary>
        public virtual void OnSelectResult()
        {
            m_events.Fire(OnSelectResultKey, this, null);
        }
        
        /// <summary>
        /// Called when node is deselected in the result pane
        /// </summary>
        public virtual void OnDeselectResult()
        {
            m_events.Fire(OnDeselectResultKey, this, null);
        }

        /// <summary>
        /// Show the Node
        /// </summary>
        /// <param name="console"></param>
		public virtual void OnShow()
		{
            m_events.Fire(OnShowKey, this, null);
        }


		public virtual void OnViewChangeScope(BaseNode node)
		{
            m_events.Fire(OnViewChangeScopeKey, this, null);
        }
        
        public virtual void OnViewChangeResult(BaseNode node)
        {
            m_events.Fire(OnViewChangeResultKey, this, null);
        }
        
        public virtual void OnContextHelp()
		{
            m_events.Fire(OnContextHelpKey, this, null);
        }



        //////////////////////////////////////////////////////////////////////
        ///
        /// Published Events
        ///

        public event NodeNotificationHandler OnActivateEvent
        {
            add { m_events.AddHandler(OnActivateKey, value); }
            remove { m_events.RemoveHandler(OnActivateKey, value); }
        }

        public event NodeNotificationHandler OnAddScopePaneImagesEvent
        {
            add { m_events.AddHandler(OnAddScopePaneImagesKey, value); }
            remove { m_events.RemoveHandler(OnAddScopePaneImagesKey, value); }
        }

        public event NodeNotificationHandler OnAddResultPaneImagesEvent
        {
            add { m_events.AddHandler(OnAddResultPaneImagesKey, value); }
            remove { m_events.RemoveHandler(OnAddResultPaneImagesKey, value); }
        }

        public event NodeNotificationHandler OnBtnClickEvent
        {
            add { m_events.AddHandler(OnBtnClickKey, value); }
            remove { m_events.RemoveHandler(OnBtnClickKey, value); }
        }

        public event NodeNotificationHandler OnClickEvent
        {
            add { m_events.AddHandler(OnClickKey, value); }
            remove { m_events.RemoveHandler(OnClickKey, value); }
        }

        public event NodeNotificationHandler OnColumnClickEvent
        {
            add { m_events.AddHandler(OnColumnClickKey, value); }
            remove { m_events.RemoveHandler(OnColumnClickKey, value); }
        }

        public event NodeNotificationHandler OnCutOrRemoveEvent
        {
            add { m_events.AddHandler(OnCutOrRemoveKey, value); }
            remove { m_events.RemoveHandler(OnCutOrRemoveKey, value); }
        }

        public event NodeNotificationHandler OnDblClickEvent
        {
            add { m_events.AddHandler(OnDblClickKey, value); }
            remove { m_events.RemoveHandler(OnDblClickKey, value); }
        }

        public event NodeNotificationHandler OnDeleteEvent
        {
            add { m_events.AddHandler(OnDeleteKey, value); }
            remove { m_events.RemoveHandler(OnDeleteKey, value); }
        }

        public event NodeNotificationHandler OnDeselectAllEvent
        {
            add { m_events.AddHandler(OnDeselectAllKey, value); }
            remove { m_events.RemoveHandler(OnDeselectAllKey, value); }
        }

        public event NodeNotificationHandler OnExpandEvent
        {
            add { m_events.AddHandler(OnExpandKey, value); }
            remove { m_events.RemoveHandler(OnExpandKey, value); }
        }

        public event NodeNotificationHandler OnCollapseEvent
        {
            add { m_events.AddHandler(OnCollapseKey, value); }
            remove { m_events.RemoveHandler(OnCollapseKey, value); }
        }

        public event NodeNotificationHandler OnInitOcxEvent
        {
            add { m_events.AddHandler(OnInitOcxKey, value); }
            remove { m_events.RemoveHandler(OnInitOcxKey, value); }
        }

		//--added by Roman Kiss
		public event NodeNotificationHandler OnUserEvent
		{
			add { m_events.AddHandler(OnUserKey, value); }
			remove { m_events.RemoveHandler(OnUserKey, value); }
		}

		//--added by Roman Kiss
		public event NodeNotificationHandler OnQueryPropertiesEvent
		{
			add { m_events.AddHandler(OnQueryPropertiesKey, value); }
			remove { m_events.RemoveHandler(OnQueryPropertiesKey, value); }
		}
		
        public event NodeNotificationHandler OnMenuBtnClickEvent
        {
            add { m_events.AddHandler(OnMenuBtnClickKey, value); }
            remove { m_events.RemoveHandler(OnMenuBtnClickKey, value); }
        }

        public event NodeNotificationHandler OnMaximizedEvent
        {
            add { m_events.AddHandler(OnMaximizedKey, value); }
            remove { m_events.RemoveHandler(OnMaximizedKey, value); }
        }

        public event NodeNotificationHandler OnMinimizedEvent
        {
            add { m_events.AddHandler(OnMinimizedKey, value); }
            remove { m_events.RemoveHandler(OnMinimizedKey, value); }
        }

        public event NodeNotificationHandler OnQueryPasteEvent
        {
            add { m_events.AddHandler(OnQueryPasteKey, value); }
            remove { m_events.RemoveHandler(OnQueryPasteKey, value); }
        }

        public event NodeNotificationHandler OnRefreshEvent
        {
            add { m_events.AddHandler(OnRefreshKey, value); }
            remove { m_events.RemoveHandler(OnRefreshKey, value); }
        }

        public event NodeNotificationHandler OnRemoveChildrenEvent
        {
            add { m_events.AddHandler(OnRemoveChildrenKey, value); }
            remove { m_events.RemoveHandler(OnRemoveChildrenKey, value); }
        }

        public event NodeNotificationHandler OnRenameEvent
        {
            add { m_events.AddHandler(OnRenameKey, value); }
            remove { m_events.RemoveHandler(OnRenameKey, value); }
        }

        public event NodeNotificationHandler OnSelectScopeEvent
        {
            add { m_events.AddHandler(OnSelectScopeKey, value); }
            remove { m_events.RemoveHandler(OnSelectScopeKey, value); }
        }

        public event NodeNotificationHandler OnDeselectScopeEvent
        {
            add { m_events.AddHandler(OnDeselectScopeKey, value); }
            remove { m_events.RemoveHandler(OnDeselectScopeKey, value); }
        }

        public event NodeNotificationHandler OnSelectResultEvent
        {
            add { m_events.AddHandler(OnSelectResultKey, value); }
            remove { m_events.RemoveHandler(OnSelectResultKey, value); }
        }

        public event NodeNotificationHandler OnDeselectResultEvent
        {
            add { m_events.AddHandler(OnDeselectResultKey, value); }
            remove { m_events.RemoveHandler(OnDeselectResultKey, value); }
        }

        public event NodeNotificationHandler OnShowEvent
        {
            add { m_events.AddHandler(OnShowKey, value); }
            remove { m_events.RemoveHandler(OnShowKey, value); }
        }

        public event NodeNotificationHandler OnViewChangeScopeEvent
        {
            add { m_events.AddHandler(OnViewChangeScopeKey, value); }
            remove { m_events.RemoveHandler(OnViewChangeScopeKey, value); }
        }

        public event NodeNotificationHandler OnViewChangeResultEvent
        {
            add { m_events.AddHandler(OnViewChangeResultKey, value); }
            remove { m_events.RemoveHandler(OnViewChangeResultKey, value); }
        }

        public event NodeNotificationHandler OnContextHelpEvent
        {
            add { m_events.AddHandler(OnContextHelpKey, value); }
            remove { m_events.RemoveHandler(OnContextHelpKey, value); }
        }

		
		//////////////////////////////////////////////////////////////////////
		///
		/// Context Menu Management
		///

		//---added by Roman Kiss
		public MenuItem GetMenuItem(uint intCCM, string strItemName) 
		{
			ArrayList selArraList = null;

			//---find the properly menu container
			if(intCCM == CCM.INSERTIONALLOWED_TOP) 
				selArraList = m_TopMenuItems;
			else 
			if(intCCM == CCM.INSERTIONALLOWED_NEW) 
				selArraList = m_NewMenuItems;
			else
			if(intCCM == CCM.INSERTIONALLOWED_TASK) 
				selArraList = m_TaskMenuItems;
			else
			if(intCCM == CCM.INSERTIONALLOWED_VIEW) 
				selArraList = m_ViewMenuItems;
			else
				return null;

			//---find the item in the menu
			foreach(object obj in selArraList) 
			{
				MenuItem mi = obj as MenuItem;
				if(mi.Name == strItemName)
					return mi;
			}

			//---no exist
			return null;
		}

		public void Command(int nCommandId)
		{		
			if (nCommandId >= 0 && nCommandId < MenuItemIndex.Count)
			{
				MenuItem item = (MenuItem)MenuItemIndex[nCommandId];
				item.Command(this);
			}
		}

		public void AddTopMenuItem(MenuItem item)
		{
			if (m_TopMenuItems == null)
				m_TopMenuItems = new ArrayList();

			// set the command Id so we can retreive this item later
			item.CommandId = MenuItemIndex.Count;
			MenuItemIndex.Add(item);

			m_TopMenuItems.Add(item);
		}
		
		public void AddNewMenuItem(MenuItem item)
		{
			if (m_NewMenuItems == null)
				m_NewMenuItems = new ArrayList();

			item.CommandId = MenuItemIndex.Count;
			MenuItemIndex.Add(item);

			m_NewMenuItems.Add(item);
		}
		public void AddTaskMenuItem(MenuItem item)
		{
			if (m_TaskMenuItems == null)
				m_TaskMenuItems = new ArrayList();

			item.CommandId = MenuItemIndex.Count;
			MenuItemIndex.Add(item);

			m_TaskMenuItems.Add(item);
		}
		public void AddViewMenuItem(MenuItem item)
		{
			if (m_ViewMenuItems == null)
				m_ViewMenuItems = new ArrayList();

			item.CommandId = MenuItemIndex.Count;
			MenuItemIndex.Add(item);

			m_ViewMenuItems.Add(item);
		}
		
		protected ArrayList MenuItemIndex 
		{
			get 
			{
				if (m_MenuItems == null)
					m_MenuItems = new ArrayList();
	
				return m_MenuItems;
			}
		}

		protected virtual void OnAddTopMenu(IContextMenuCallback piCallback)
		{
         if (m_TopMenuItems != null)
         {
            foreach(MenuItem item in m_TopMenuItems)
            {
							if(item.Visible) 
							{
								// Let's add "Refresh Page" the the "view" menu
								CONTEXTMENUITEM newitem = new CONTEXTMENUITEM();

								newitem.strName = item.Name;
								newitem.strStatusBarText = item.StatusText;
								newitem.lCommandID = item.CommandId;
								newitem.lInsertionPointID = CCM.INSERTIONPOINTID_PRIMARY_TOP;
								newitem.fFlags = 0;
								newitem.fSpecialFlags=0;

								// Now add this item through the callback
								piCallback.AddItem(ref newitem);
							}
            }
         }
		}

		/// <summary>
		/// Called by the framework wo add menu items to the MMC "Top Menu"
		/// </summary>
		/// <param name="piCallback"></param>
		protected virtual void OnAddNewMenu(IContextMenuCallback piCallback)
		{
         if (m_NewMenuItems != null)
         {
            foreach(MenuItem item in m_NewMenuItems)
            {
							if(item.Visible) 
							{
								// Let's add "Refresh Page" the the "view" menu
								CONTEXTMENUITEM newitem = new CONTEXTMENUITEM();

								newitem.strName = item.Name;
								newitem.strStatusBarText = item.StatusText;
								newitem.lCommandID = item.CommandId;
								newitem.lInsertionPointID = CCM.INSERTIONPOINTID_PRIMARY_NEW;
								newitem.fFlags = 0;
								newitem.fSpecialFlags=0;

								// Now add this item through the callback
								piCallback.AddItem(ref newitem);
							}
            }
         }
		}

		/// <summary>
		/// Called by the framework wo add menu items to the MMC "Task Menu"
		/// </summary>
		/// <param name="piCallback"></param>
		protected virtual void OnAddTaskMenu(IContextMenuCallback piCallback)
		{
         if (m_TaskMenuItems != null)
         {
            foreach(MenuItem item in m_TaskMenuItems)
            {
							if(item.Visible) 
							{
								// Let's add "Refresh Page" the the "view" menu
								CONTEXTMENUITEM newitem = new CONTEXTMENUITEM();

								newitem.strName = item.Name;
								newitem.strStatusBarText = item.StatusText;
								newitem.lCommandID = item.CommandId;
								newitem.lInsertionPointID = CCM.INSERTIONPOINTID_PRIMARY_TASK;
								newitem.fFlags = 0;
								newitem.fSpecialFlags=0;

								// Now add this item through the callback
								piCallback.AddItem(ref newitem);
							}
            }
         }
		}

		/// <summary>
		/// Called by the framework wo add menu items to the MMC "View Menu"
		/// </summary>
		/// <param name="piCallback"></param>
		protected virtual void OnAddViewMenu(IContextMenuCallback piCallback)
		{
         if (m_ViewMenuItems != null)
         {
            foreach(MenuItem item in m_ViewMenuItems)
            {
							if(item.Visible) 
							{
								// Let's add "Refresh Page" the the "view" menu
								CONTEXTMENUITEM newitem = new CONTEXTMENUITEM();

								newitem.strName = item.Name;
								newitem.strStatusBarText = item.StatusText;
								newitem.lCommandID = item.CommandId;
								newitem.lInsertionPointID = CCM.INSERTIONPOINTID_PRIMARY_VIEW;
								newitem.fFlags = 0;
								newitem.fSpecialFlags=0;

								// Now add this item through the callback
								piCallback.AddItem(ref newitem);
							}
            }
         }
		}

        protected virtual int GetResultViewImageIndex()
        {
            if (IsUSeSmallIcons())
                return SmallImageIndex;

            return LargeImageIndex;
        }

        /// <summary>
        /// Helper method to determine if the result view for this node
        /// is in large icon or small icon view.  Based on what the component
        /// IConsole2 interface says
        /// </summary>
        /// <returns></returns>
        protected bool IsUSeSmallIcons()
        {
            IConsole2 console = Snapin.ResultViewConsole;

            if (console != null)
            {
                IResultData rdata = console as IResultData;
                if (rdata != null)
                {
                    int nViewType = 0;
                    rdata.GetViewMode(out nViewType);
                    return nViewType != 0;
                }
            }
            // default to small icons
            return true;
        }
	}

}
