using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Ironring.Management.MMC;


namespace Ironring.Management.MMC
{
	/// <summary>
	/// The Base class for the snapin object implements the IComponentData interface that is the primary
	/// communication conduit to MMC.  Contains our IComponent implementation as well to handle the other
	/// part of the MMC dialog.  This class also contains the master collection of Nodes and will dispatch
	/// to the appropriate Node when notifications arrive.  All nodes must register back to this class on 
	/// creation for registration in the master collection.  This happen automatically in the BaseNode 
	/// contructor.
	/// </summary>
	public class SnapinBase : 
		IComponentData,
		IExtendContextMenu,
		IExtendPropertySheet
	{
		/// <summary>
		/// Contained object that implements IComponent on our behalf
		/// </summary>
		protected Component m_Component = null;        

		/// <summary>
		/// A cached reference to the MMC console 
		/// </summary>
		protected IConsole2 m_Console = null;          

		/// <summary>
		/// A cached reference to the MMC console namespace 
		/// </summary>
		protected IConsoleNameSpace2 m_ConsoleNameSpace = null; 

		/// <summary>
		/// Master list of all Nodes displayed in the snapin 
		/// this collection "owns" them and assignes cookie values
		/// </summary>
		//protected ArrayList m_Nodes = new ArrayList(16);				
		protected HybridDictionary m_Nodes = new HybridDictionary(8);
		protected int m_NodeId = 0;


		/// <summary>
		/// global images collection 
		/// </summary>
		protected ImageList m_Images = new ImageList();



		//////////////////////////////////////////////////////////////////////////
		///
		/// SnapinBase Implementation
		///
        
        
		/// <summary>
		/// Default Constructor
		/// </summary>
		public SnapinBase()
		{
		}

		/// <summary>
		/// return the guid for the snapin - dig it out of the Guid attribute in the base class!
		/// Gotta love reflection.
		/// </summary>
		public Guid Guid
		{
			get 
			{
				object[] attrs = GetType().GetCustomAttributes(typeof(GuidAttribute), true);
				if (attrs.Length == 0)
					throw new SnapinException("Failed ot find GuidAttribute on SnapinBase class");

				return new Guid(((GuidAttribute)attrs[0]).Value);
			}
		}

		/// <summary>
		/// get/set the root node - this starts off the population of the entire
		/// namespace.  The RootNode is also known as the static node in MMC.  It 
		/// will be queried for its children.
		/// </summary>
		public BaseNode RootNode
		{
			get { return (BaseNode)m_Nodes[0]; }
			set { m_Nodes[0] = value; }
		}

		/// <summary>
		/// Return the Componenet's console
		/// </summary>
		public IConsole2 ResultViewConsole
		{
			get { return m_Component.Console; }
		}

		/// <summary>
		/// Return the cached member variable to get at MMC
		/// </summary>
		public IConsole2 Console
		{
			get { return m_Console; }
		}

		/// <summary>
		/// Return the cached member variable to get at MMC
		/// </summary>
		public IConsoleNameSpace2 ConsoleNameSpace
		{
			get { return m_ConsoleNameSpace; }
		}

		/// <summary>
		/// Return the cached member variable to get at MMC
		/// </summary>
		public IHeaderCtrl2 HeaderCtrl
		{
			get { return (IHeaderCtrl2)m_Console; }
		}

		/// <summary>
		/// find a node with the given cookie in our master index
		/// </summary>
		/// <param name="cookie"></param>
		/// <returns></returns>
		public BaseNode FindNode(int cookie)
		{
			// some nodes use the high order word for item id
			// so mask off this word to get the "real" cookie.
			int cleanCookie = cookie & 0xffff;
			BaseNode node = (BaseNode)m_Nodes[cleanCookie];
			if (node == null)
				throw new SnapinException("Failed to find Node with cookie " + cleanCookie.ToString());

			return node;
		}
		
		/// <summary>
		/// find a node by the MMC defined HScopeID 
		/// </summary>
		/// <param name="HScopeID"></param>
		/// <returns></returns>
		public BaseNode FindNodeByHScope(int HScopeID)
		{

			foreach(BaseNode node in m_Nodes.Values)
			{
				if (node.HScopeItem == HScopeID)
					return node;
			}
			
			return null;
		}

		/// <summary>
		/// called be BaseNode constructor to register itself back here for  
		/// centralized lookup when MMC want to talk to a Node
		/// </summary>
		/// <param name="newNode"></param>
		/// <returns></returns>
		public int Register(BaseNode newNode)
		{
			// return the index in the array - that is opaque to the node - it shouldn't 
			// make any assumptions about the value - thats our job in this class.
			// We may change the collection strategy in the future if we need to 
			// support bigger node sets.
			int id = m_NodeId;
			m_Nodes.Add(id, newNode);
			m_NodeId++;
			return id;
		}

		/// <summary>
		/// Add a string representing the embedded resource name of an icon to
		/// the snapin's global image coolection
		/// </summary>
		/// <param name="iconResourceName"></param>
		public int AddImage(string iconResourceName)
		{
			return m_Images.Add(iconResourceName);
		}

		/// <summary>
		/// Add a loaded and initialized icon to the snapin global image collection
		/// </summary>
		/// <param name="icon"></param>
		public int AddImage(Icon icon)
		{
			return m_Images.Add(icon);
		}


		//////////////////////////////////////////////////////////////////////
		///
		/// IComponentData implementation
		///


		/// <summary>
		/// Called by MMC with the Console interface on startup we do snapin one time init stuff here 
		/// </summary>
		/// <param name="pUnknown">Implements IConsole()2 and IConsoleNameSpace2 interfaces</param>
		public void Initialize(Object pUnknown)
		{
			try
			{
				// cache references to MMC interfaces
				m_Console = (IConsole2)pUnknown;
				m_ConsoleNameSpace = (IConsoleNameSpace2)pUnknown;

				// alow startup init for each node
				foreach(BaseNode node in m_Nodes.Values)
					node.Initialize();

				// Now we'll add the images we need for the snapin
				IImageList il = null;
				m_Console.QueryScopeImageList(out il);
            
				// add the snapin - global images to the scope pane
				m_Images.LoadImageList(il);


				// forward to the root node to see if any nodes care to add their node specific 
				// icons to the image list
				RootNode.OnAddScopePaneImages(il);
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Initialize failed - " + e.Message);
				throw e;
			}
		}

		/// <summary>
		/// Give MMC our IComponent implementation when asked
		/// </summary>
		/// <param name="ppComponent">a pointer to out Component object</param>
		public void CreateComponent(out IComponent ppComponent)
		{
			// Make sure we don't already have a component created
			if (m_Component == null)
				m_Component = new Component(this);

			ppComponent = m_Component;
		}

		/// <summary>
		/// This notify is primarily responsible for inserting data items into 
		/// the console namespace.
		/// </summary>
		/// <param name="lpDataObject">the node to notify</param>
		/// <param name="aevent">notification type</param>
		/// <param name="arg">optional event context</param>
		/// <param name="param">optional event context</param>
		/// <returns></returns>
		public int Notify(IDataObject lpDataObject, uint aevent, IntPtr arg, IntPtr param)
		{
			int hr = HRESULT.S_OK;

			try
			{
				DataObject test = (DataObject)lpDataObject;
				BaseNode node = (test == null) ? RootNode : test.Node;

				// TBD: add more events and dispatch to virtual methods instead? or event fire events?

				MMCN_Notifiy notify = (MMCN_Notifiy)aevent;

				System.Diagnostics.Debug.WriteLine("IComponentData::Notify - " + notify.ToString());

				switch(notify)
				{
						// If a data item is expanding, we need to tell MMC about it's children.
						// Note, this case doesn't necessarily mean the data item is expanding
						// visually.... MMC is just requesting information about it.
					case MMCN_Notifiy.EXPAND:
					{
						if ((int)arg != 0)
						{
							if (node.HScopeItem == 0)
								node.HScopeItem = (int)param;
							node.OnExpand();
						}
						else
						{
							node.OnCollapse();
						}
						break;
					}
					//---added by Roman Kiss
					case MMCN_Notifiy.DELETE:
					{
						node.OnDelete();
						break;
					}
					default:
					{
						// We didn't handle the message
						hr = HRESULT.S_FALSE;
						break;
					}
				}
			}
            
			catch(SnapinException)
			{
				hr = HRESULT.S_FALSE;
			}
			catch(Exception e)
			{
				throw e;
			}

			return hr;
		}

		/// <summary>
		///  Called by MMC to cleanup 
		///  TBD: call Dispose - after that pattern is more pervaisivly used
		/// </summary>
		public void Destroy()
		{
		}

		/// <summary>
		/// When MMC wants a data object for a specific node 
		/// </summary>
		/// <param name="cookie"></param>
		/// <param name="type"></param>
		/// <param name="ppDataObject"></param>
		public void QueryDataObject(int cookie, uint type, out IDataObject ppDataObject)
		{
			ppDataObject = new DataObject(FindNode(cookie)); 
		}

		/// <summary>
		/// provides scope pane info to MMC  
		/// </summary>
		/// <param name="sdi"></param>
		public virtual void GetDisplayInfo(ref SCOPEDATAITEM sdi)
		{
			// First let's find this node we want info on....
			BaseNode NodeWeWant = FindNode(sdi.lParam);
			NodeWeWant.GetDisplayInfo(ref sdi);
		}

   		
		/// <summary>
		/// This method will compare two data objects based on underlying cookie value 
		/// that the nodes contain
		/// </summary>
		/// <param name="lpDataObjectA"></param>
		/// <param name="lpDataObjectB"></param>
		/// <returns></returns>
		public int CompareObjects(IDataObject lpDataObjectA, IDataObject lpDataObjectB)
		{
			// since this is the only type we hand out it should be the only type 
			// provided here and the cast should "always" work.

			DataObject doItem1 = (DataObject)lpDataObjectA;
			DataObject doItem2 = (DataObject)lpDataObjectB;

			// TBD: implement IComparable on Node and compare cookies.

			// These are different objects. We need to return S_FALSE
			if (doItem1.Node.Cookie != doItem2.Node.Cookie)
				return HRESULT.S_FALSE;

			return HRESULT.S_OK;
		}



		//////////////////////////////////////////////////////////////////////
		// IExtendPropertySheet implementation

		/// <summary>
		/// MMC wants a property sheet created of the given node 
		/// </summary>
		/// <param name="lpProvider"></param>
		/// <param name="handle"></param>
		/// <param name="lpDataObject"></param>
		/// <returns></returns>
		public int CreatePropertyPages(IPropertySheetCallback lpProvider, IntPtr handle, IDataObject lpDataObject)
		{
			DataObject dataObject = (DataObject)lpDataObject;
	    
			// Let's see if this node has property pages
			if (dataObject.Node.HavePropertyPages)
				dataObject.Node.CreatePropertyPages(lpProvider, handle);

			// don't use the MMC property page facilities - just roll our own.
			return HRESULT.S_FALSE;
		}


		/// <summary>
		/// MMC calls this at initialization time to find out if the node  
		/// supports property pages - this is the one and only time to respond.
		/// </summary>
		/// <param name="lpDataObject">IdataObject for Node in question</param>
		/// <returns></returns>
		public int QueryPagesFor(IDataObject lpDataObject)
		{
			// This snapin does have property pages, so we should return S_OK
			// (which will happen automatically). If the snapin didn't have
			// any property pages, then we should return S_FALSE

			DataObject dataObject = (DataObject)lpDataObject;
	    
			//---added by Roman Kiss
			dataObject.Node.OnQueryProperties();

			// Let's see if this node has property pages
			if (dataObject.Node.HavePropertyPages)
				return HRESULT.S_OK;

			return HRESULT.S_FALSE;
		}


		/// <summary>
		/// Add menu items based on MMC's insertion rules 
		/// </summary>
		/// <param name="piDataObject"></param>
		/// <param name="piCallback"></param>
		/// <param name="pInsertionAllowed"></param>
		public void AddMenuItems(IDataObject piDataObject, IContextMenuCallback piCallback, ref int pInsertionAllowed)
		{
			// The piDataObject is really a DataObject is disguise....
			DataObject item = (DataObject)piDataObject;
			if (item.Node != null)
				item.Node.AddMenuItems(piCallback, ref pInsertionAllowed);
		}

		/// <summary>
		/// Called when user invokes a menu command
		/// </summary>
		/// <param name="lCommandID"></param>
		/// <param name="piDataObject"></param>
		public void Command(int lCommandID, IDataObject piDataObject)
		{
			// pass the command on to the node
			DataObject item = (DataObject)piDataObject;
			if (item.Node != null)
				item.Node.Command(lCommandID);
		}

		/// <summary>
		/// Auto Register the snap-in with MMC 
		/// </summary>
		[ComRegisterFunction()]
		public static void RegisterSnapIn(Type t)
		{
			SnapinRegistrar.Register(t.Assembly);
		}

		/// <summary>
		/// Unregister the snap-in with MMC
		/// </summary>
		[ComUnregisterFunction()]
		public static void UnregisterSnapIn(Type t)
		{
			SnapinRegistrar.UnRegister(t.Assembly);
		}
	}
}
