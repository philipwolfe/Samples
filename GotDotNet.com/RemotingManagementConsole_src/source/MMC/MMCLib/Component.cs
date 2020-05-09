using System;
using System.Runtime.InteropServices;


namespace Ironring.Management.MMC
{
    /// <summary>
    /// Componentimplements the IComponent, IExtendContextMenu and IExtendControlbar
    ///  interfaces that control the result view side of the MMC control.  
    ///  Many event notifications pass through this class on the way to the node
    /// </summary>
    public class Component : 
            IComponent, 
            IExtendContextMenu,
            IExtendControlbar
    {
        /// <summary>
        /// cache the MMC Console interface 
        /// </summary>
        protected IConsole2 m_Console;        
    	
        /// <summary>
        /// The control bar set by MMC when each node is selected
        /// Careful since it can go null!
        /// </summary>
        protected IControlbar m_pControlbar;

        /// <summary>
        /// Back reference ot the Snapin Base object 
        /// </summary>
	    protected SnapinBase m_Snapin;


        //////////////////////////////////////////////////////////////
        ///
        /// Implementation
        ///

        
        /// <summary>
        /// ctor with a back ref to the base snapin
        /// </summary>
        /// <param name="snapin"></param>
        public Component(SnapinBase snapin)
        {
		    m_Snapin = snapin;
        }


        /// <summary>
        /// return the cached console reference
        /// </summary>
        public IConsole2 Console 
        {
            get { return m_Console; }
        }


        /// <summary>
        /// Return the controlbar.  It may be null 
        /// </summary>
        public IControlbar ControlBar 
        {
            get { return m_pControlbar; }
        }

        //////////////////////////////////////////////////////////////
        ///
        /// IComponent Implementation
        ///

        /// <summary>
        /// Called by MMC on startup
        /// </summary>
        /// <param name="pConsole"></param>
        public void Initialize(Object pConsole)
        { 
            m_Console = pConsole as IConsole2;
        }

        
        /// <summary>
        /// THis is the primary MMC communication chanel concerning, it will 
        /// call Notify, we will delegate to the relevent node or handle it directly
        /// </summary>
        /// <param name="lpDataObject"></param>
        /// <param name="aevent"></param>
        /// <param name="arg"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Notify(IntPtr lpDataObject, uint aevent, IntPtr arg, IntPtr param)
        {
            int hr = HRESULT.S_FALSE;

            try
            {

                // There are some sneaky values for the IDataObject parameters that make 
                // interop with this interface a little trick.  This is why lpDataObject is an IntPtr
                // not an actual IDataObject interface.

                if (lpDataObject == (IntPtr)DataObject.CUSTOMOCX || lpDataObject == (IntPtr)DataObject.CUSTOMWEB)
                    return hr;

                // marshal the IDataObject interfacer now that we know its likely a valid interface pointer

                IDataObject ido = null;
                if (lpDataObject != (IntPtr)0)
                    ido = (IDataObject)Marshal.GetObjectForIUnknown(lpDataObject);
                   
                //TBD: this may fail for "multiselect" notificatyions
                hr = HRESULT.S_OK;

                // Do the same old trick - since we only hand out DataObject we can cast back if it non-null.
                // if the IDataObject is null MMC is signalling us to operate on the root/static node.

                BaseNode node = (ido == null) ? m_Snapin.RootNode : ((DataObject)ido).Node;

                // dispatch the evnt to the node
                MMCN_Notifiy notify = (MMCN_Notifiy)aevent;
                System.Diagnostics.Debug.WriteLine("IComponent::Notify - " + notify.ToString());

                switch(notify)
                {

                    case MMCN_Notifiy.ACTIVATE:
                    {
                        bool bActivate = arg.ToInt32() != 0;
                        node.OnActivate(bActivate);
                        break;
                    }
                    case MMCN_Notifiy.ADD_IMAGES:
                    {
                        // arg actually contains the IImageList interface. We need to 
                        // marshall that manually as well.

                        IImageList il = (IImageList)Marshal.GetObjectForIUnknown(arg);

                        // param contains the HScopeItem. Let's get the node it represents
                        BaseNode nLuckyGuy = m_Snapin.FindNodeByHScope((int)param);
           				
                        // TBD: what is the diff between nLuckyGuy and node
                        nLuckyGuy.OnAddResultPaneImages(il);

                        break;
                    }
                    case MMCN_Notifiy.BTN_CLICK:
                    {
                        // CmdID of the button equal to a value of the MMC_COMMANDS enum type.
                        int cmdid = param.ToInt32();
                        node.OnBtnClick(cmdid);
                        break;
                    }
                    case MMCN_Notifiy.CLICK:
                    {
                        node.OnClick();
                        break;
                    }
                    case MMCN_Notifiy.COLUMN_CLICK:
                    {
                        int nCol = (int)arg;
                        bool bAscending = (int)param == 0;
                        node.OnColumnClick(nCol, bAscending);
                        break;
                    }
                    case MMCN_Notifiy.CUTORMOVE:
                    {
                        // TBD: arg is IDataObject
                        node.OnCutOrRemove();
                        break;
                    }
                    case MMCN_Notifiy.DBLCLICK:
                    {
                        node.OnDblClick();
                        break;
                    }
                    case MMCN_Notifiy.DELETE:
                    {
                        node.OnDelete();
                        break;
                    }
                    case MMCN_Notifiy.DESELECT_ALL:
                    {
                        node.OnDeselectAll();
                        break;
                    }
                    case MMCN_Notifiy.EXPAND:
                    {
                        if ((int)arg == 0)
                            node.OnExpand();
                        else
                            node.OnCollapse();
                        break;
                    }
                    case MMCN_Notifiy.MENU_BTNCLICK:
                    {
                        MENUBUTTONDATA data = (MENUBUTTONDATA)(Marshal.PtrToStructure(param, typeof(MENUBUTTONDATA)));
                        node.OnMenuBtnClick(data.idCommand, data.x, data.y);
                        break;
                    }
                    case MMCN_Notifiy.MINIMIZED:
                    {
                        if (arg.ToInt32() == 0)
                            node.OnMaximized();
                        else
                            node.OnMinimized();
                        break;
                    }
                    case MMCN_Notifiy.PASTE:
                    {
                        // TBD: arg = IDataObject for multi select
                        // param = NULL for move as opposed to cut
                        //       = BOOL* for for single item pasting...return TRUE if good
                        //       = IDataObject for multiselect paste
                        // return S_FALSE for no can do or S_OK if...OK
                        //				node.OnPaste();
                        hr = HRESULT.S_FALSE;
                        break;
                    }
                    case MMCN_Notifiy.PROPERTY_CHANGE:
                    {
                        // lParam = user object
                        // node == null

                        //node.OnPropertyChange();
                        break;
                    }
                    case MMCN_Notifiy.QUERY_PASTE:
                    {
                        // TBD: arg = IDataObject for multi select
                        // return S_FALSE for no can do or S_OK if...OK
                        IDataObject anido = (IDataObject)Marshal.GetObjectForIUnknown(arg);
                        if (!node.OnQueryPaste(anido))
                            hr = HRESULT.S_FALSE;

                        break;
                    }
                    case MMCN_Notifiy.REFRESH:
                    {
                        node.OnRefresh();
                        break;
                    }
                    case MMCN_Notifiy.REMOVE_CHILDREN:
                    {
                        BaseNode thenode = m_Snapin.FindNodeByHScope((int)arg);
                        thenode.OnRemoveChildren();
                        break;
                    }
                    case MMCN_Notifiy.RENAME:
                    {
                        // can we rename?
                        if ((int)arg == 0)
                        {
                            // can we rename?
                            if (!node.OnTryRename())
                                hr = HRESULT.S_FALSE;
                        }
                            // rename editing complete - here is the string
                        else // arg == 1
                        {
                            // is the renamed value ok?
                            if (!node.OnRename(Marshal.PtrToStringAuto(param)))
                                hr = HRESULT.S_FALSE;
                        }

                        break;
                    }
                        // If an item is selected, we should set flags for verbs available
                        // for the item (from the dropdown menu)
                    case MMCN_Notifiy.SELECT:
                    {
                        // low word - scope pane or result
                        bool bScope = ((short)arg) != 0;
                        // high word - selected or not
                        bool bSelect = ((((int)arg) >> 16) & 0xffff) != 0;

                        if (bScope)
                        {
                            if (bSelect)
                                node.OnSelectScope();
                            else
                                node.OnDeselectScope();
                        }
                        else
                        {
                            if (bSelect)
                                node.OnSelectResult();
                            else
                                node.OnDeselectResult();
                        }

                        break;
                    }
                    case MMCN_Notifiy.SHOW:
                    {
                        // TDB: am I sure this property has been set yet?

                        BaseNode theNode = m_Snapin.FindNodeByHScope((int)param);
                        bool bSelecting = (int)arg != 0;
                        // TBD: not sure if i should pass through if we are not selecting
                        if (bSelecting)
                            theNode.OnShow();

                        break;
                    }
                    case MMCN_Notifiy.VIEW_CHANGE:
                    {
                        bool bScope = (int)arg != 0;
                        IDataObject anido = (IDataObject)Marshal.GetObjectForIUnknown(param);

                        BaseNode nodeChanged = (anido == null) ? m_Snapin.RootNode : ((DataObject)anido).Node;

                        if (bScope)
                            node.OnViewChangeScope(nodeChanged);
                        else
                            node.OnViewChangeResult(nodeChanged);

                        break;
                    }
                    case MMCN_Notifiy.SNAPINHELP:
                    {
                        //m_snapin.OnHelp();
                        hr = HRESULT.S_FALSE;
                        break;
                    }
                    case MMCN_Notifiy.CONTEXTHELP:
                    {
                        node.OnContextHelp();
                        break;
                    }
                    case MMCN_Notifiy.INITOCX:
                    {
                        // param is the IUnknown of the OCX
                        object objOCX = Marshal.GetObjectForIUnknown(param);
                        if (node.OnInitOcx(objOCX))
                            hr = HRESULT.S_OK;
                        else
                            hr = HRESULT.S_FALSE;
                        break;
                    }
                    case MMCN_Notifiy.FILTER_CHANGE:
                    {
                        //				node.OnFilterChange();
                        hr = HRESULT.S_FALSE;
                        break;
                    }
                    case MMCN_Notifiy.GET_FILTER_MENU:
                    {
                        //				node.OnGetFilterMenu();
                        hr = HRESULT.S_FALSE;
                        break;
                    }
                    case MMCN_Notifiy.FILTER_OPERATOR:
                    {
                        hr = HRESULT.S_FALSE;
                        //				node.OnFilterOperator();
                        break;
                    }
                    default:
                    {
                        // We don't support the Notification message we got
                        hr = HRESULT.S_FALSE;
                        break;
                    }
                }
            }
            catch(SnapinException e)
            {
                hr = HRESULT.S_FALSE;
                System.Diagnostics.Debug.WriteLine("IComponent::Notify SnapinException - " + e.ToString());
                // eat the exception and return s_false indicating that 
                // we didn't handle the notification
            }
            catch(Exception e)
            {
                hr = HRESULT.S_FALSE;
                System.Diagnostics.Debug.WriteLine("IComponent::Notify Exception - " + e.ToString());
//                throw e;
            }
               
            return hr;
        }

        /// <summary>
        /// Called at shutdown
        /// </summary>
        /// <param name="i"></param>
        public void Destroy(int i)
        {
        }
        
        /// <summary>
        /// Called when MMC wants an IDataObject for a node by cookie 
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="type"></param>
        /// <param name="ppDataObject"></param>
        public void QueryDataObject(int cookie, uint type, out IDataObject ppDataObject)
        {
            ppDataObject = new DataObject(m_Snapin.FindNode(cookie)); 
        }
        
        /// <summary>
        /// Called to get Result view type information.
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="ppViewType"></param>
        /// <param name="pViewOptions"></param>
        /// <returns></returns>
        public int GetResultViewType(int cookie, out IntPtr ppViewType, out int pViewOptions)
        {
		    pViewOptions = 0;

		    BaseNode node = m_Snapin.FindNode(cookie);
		    if (node != null)
		    {
			    string viewType = node.GetResultViewType(ref pViewOptions);
			    ppViewType = Marshal.StringToCoTaskMemUni(viewType);
			    return HRESULT.S_OK;
		    }
		    else
            {
                ppViewType = IntPtr.Zero;
                return HRESULT.S_FALSE;
            }
		    // TBD: When switching from a standard list view to a custom view, the snap-in must call 
		    // IConsole2::SelectScopeItem to reselect the item and force MMC to call GetResultViewType again
        }


        /// <summary>
        /// Called to get result view information.
        /// </summary>
        /// <param name="ResultDataItem"></param>
        public void GetDisplayInfo(ref RESULTDATAITEM ResultDataItem)
        {
            // The low word in the lParam contains the index of the node
            // we're interested in.  If we are in report view we mash in the row
		    // nu,ber is the high word.
            BaseNode NodeWeWant = m_Snapin.FindNode((int)ResultDataItem.lParam);

            // We'll let the node take care of its own Result Data
            NodeWeWant.GetDisplayInfo(ref ResultDataItem);
        }
        

        /// <summary>
        /// Called to compare 2 nodes - we use cookie values to test equality
        /// </summary>
        /// <param name="lpDataObjectA"></param>
        /// <param name="lpDataObjectB"></param>
        /// <returns></returns>
        public int CompareObjects(IDataObject lpDataObjectA, IDataObject lpDataObjectB)
        {
            DataObject doItem1, doItem2;

            // These data items should be DataObject's in disguise.....
            doItem1 = (DataObject)lpDataObjectA;
            doItem2 = (DataObject)lpDataObjectB;
            
            if (doItem1.Node.Cookie != doItem2.Node.Cookie)
            {
                // These are different objects. We need to return S_FALSE
            return HRESULT.S_FALSE;
            }

            return HRESULT.S_OK;
        }


        
        //////////////////////////////////////////////////////////////
        ///
        /// IExtendContextMenu Implementation
        ///


        /// <summary>
        /// This function allows us to add items to the context menus 
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
        /// Called menu item is invoked.  We delegate to the node 
        /// to let it handle it.
        /// </summary>
        /// <param name="lCommandID"></param>
        /// <param name="piDataObject"></param>
        public void Command(int lCommandID, IDataObject piDataObject)
        {
		    DataObject item = (DataObject)piDataObject;
		    if (item.Node != null)
			    item.Node.Command(lCommandID);
    	
        }


        //////////////////////////////////////////////////////////////
        ///
        /// IExtendControlbar Implementation
        ///

        /// <summary>
        /// Called to set and reset the control bar interface.
        /// </summary>
        /// <param name="pControlbar">Can be null to reset</param>
        public void SetControlbar(IControlbar pControlbar)
        {
            m_pControlbar = pControlbar;
        }

        /// <summary>
        /// Called when nodes are selected and controlbar commands fire.
        /// </summary>
        /// <param name="aevent"></param>
        /// <param name="arg"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int ControlbarNotify(uint aevent, IntPtr arg, IntPtr param)
        {
            int hr = HRESULT.S_OK;

            MMCN_Notifiy notify = (MMCN_Notifiy)aevent;

            switch(notify)
            {
                case MMCN_Notifiy.SELECT:
                {
                    // low word - scope pane or result
                    bool bScope = ((short)arg) != 0;
                    // high word - selected or not
                    bool bSelect = ((((int)arg) >> 16) & 0xffff) != 0;

                    // null or < 0 (bad juju) is passed when selecting resultviews
                    if ((int)param > 0)
                    {
                        IDataObject ido = (IDataObject)Marshal.GetObjectForIUnknown(param);
                        BaseNode node = (ido == null) ? m_Snapin.RootNode : ((DataObject)ido).Node;

                        if (bScope)
                        {
                            if (bSelect)
                                node.OnSelectScope();
                            else
                                node.OnDeselectScope();
                        }
                        else
                        {
                            if (bSelect)
                                node.OnSelectResult();
                            else
                                node.OnDeselectResult();
                        }
                    }
                    break;
                }
                default:
                {
                    hr = HRESULT.S_FALSE;
                    break;
                }
            }

            return hr;
        }
    }
}
