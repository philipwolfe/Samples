using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using Microsoft.Workflow.Samples.WorkflowManager.DesignerHosting;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    #region Class ViewHost
    public sealed class ViewHost : Panel, IServiceProvider
    {
        public event OnPrepareContextMenu OnPrepareContextMenu;

        #region Members and Constructor
        private Loader loader;

        private WorkflowDesignSurface surface;
        private MyWorkflowView workflowView;

        public ViewHost()
        {
            BackColor = System.Drawing.SystemColors.Window;
            Dock = DockStyle.Fill;
            BackColor = SystemColors.Control;
            BorderStyle = BorderStyle.FixedSingle;

            Name = "ViewHost";

            WorkflowTheme theme = WorkflowTheme.CreateStandardTheme(ThemeType.Default);
            theme.AmbientTheme.ShowConfigErrors = false;
            WorkflowTheme.CurrentTheme = theme;
        }
        #endregion

        public void ProfferService(Type type, object service)
        {
            IServiceContainer container = GetService(typeof(IServiceContainer)) as IServiceContainer;
            if (container != null)
            {
                if (container.GetService(type) != null)
                    container.RemoveService(type);

                container.AddService(type, service);
            }
        }

        public Activity GetRootActivity()
        {
            return this.workflowView.RootDesigner.Activity;
        }

        #region Properties and Methods
        internal WorkflowView WorkflowView
        {
            get { return this.workflowView; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Clear();

            base.Dispose(disposing);
        }

        protected override object GetService(Type serviceType)
        {
            if (serviceType == typeof(Loader))
                return this.loader;
            else if (this.surface != null)
                return this.surface.GetService(serviceType);
            else
                return null;
        }

        internal void InvokeStandardCommand(CommandID cmd)
        {
            try
            {
                IMenuCommandService menuService = GetService(typeof(IMenuCommandService)) as IMenuCommandService;
                if (menuService != null)
                    menuService.GlobalInvoke(cmd);
            }
            catch
            {
                //We eat exceptions as some of the operations are not supported in samples
            }
        }

        /// <summary>
        /// Function loads workflow from preexsting XOML file.
        /// </summary>
        /// <param name="filePath"></param>
        internal void Open(string xomlDoc, bool readOnly)
        {
            Clear();
            Initialize();

            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (host == null)
                return;

            if (this.surface == null)
                return;

            //Set the loader parameters and load the design surface
            this.surface.ReadOnly = readOnly;
            this.loader.XomlDocument = xomlDoc;
            this.loader.AllowDynamicUpdates = !readOnly;
            this.surface.BeginLoad(this.loader);

            //Create workflowview and pass design surface
            this.workflowView = new MyWorkflowView(this.surface as IServiceProvider);
            this.workflowView.OnPrepareContextMenu += new OnPrepareContextMenu(workflowView_OnPrepareContextMenu);

            IDesignerGlyphProviderService glyphService = this.surface.GetService(typeof(IDesignerGlyphProviderService)) as IDesignerGlyphProviderService;
            WorkflowMonitorDesignerGlyphProvider glyphProvider = new WorkflowMonitorDesignerGlyphProvider(this);
            glyphService.AddGlyphProvider(glyphProvider);

            this.workflowView.Dock = DockStyle.Fill;
            host.Activate();
            if (this.workflowView.RootDesigner != null)
                Controls.Add(this.workflowView);

            //set the default selection on the root
            ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
            if (selectionService != null && host.RootComponent != null)
            {
                IComponent[] selection = new IComponent[] { host.RootComponent as IComponent };
                selectionService.SetSelectedComponents(selection);
            }
        }

        private void Initialize()
        {
            this.loader = new Loader();
            this.surface = new WorkflowDesignSurface(this);
        }

        private void Clear()
        {
            if (this.surface == null)
                return;

            if (this.workflowView != null && Controls.Contains(this.workflowView))
                Controls.Remove(this.workflowView);
            this.workflowView.OnPrepareContextMenu -= new OnPrepareContextMenu(workflowView_OnPrepareContextMenu);
            this.workflowView = null;

            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (host != null)
            {
                if (host.RootComponent != null)
                    Loader.RemoveActivityFromDesigner(host, host.RootComponent as Activity);
            }

            if (this.surface != null)
                this.surface.Dispose();

            this.surface = null;
            this.loader = null;
        }
        #endregion

        #region IServiceProvider Members
        object System.IServiceProvider.GetService(Type serviceType)
        {
            return GetService(serviceType);
        }
        #endregion

        private class MyWorkflowView : WorkflowView
        {
            public event OnPrepareContextMenu OnPrepareContextMenu;

            public MyWorkflowView(IServiceProvider provider)
                : base(provider)
            {
                WorkflowTheme theme = WorkflowTheme.CreateStandardTheme(ThemeType.Default);
                theme.AmbientTheme.ShowConfigErrors = false;
                WorkflowTheme.CurrentTheme = theme;
            }

            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            [UIPermission(SecurityAction.Assert, Window = UIPermissionWindow.AllWindows)]
            protected override void WndProc(ref Message m)
            {
                const int WM_CONTEXTMENU = 0x007B;
                if (m.Msg == WM_CONTEXTMENU)
                {
                    int LParam = (int)m.LParam;
                    Point location = (LParam != -1) ? new Point(LParam) : Control.MousePosition;

                    ArrayList menuItems = new ArrayList();
                    if (this.OnPrepareContextMenu != null)
                    {
                        ArrayList selectedActivities = new ArrayList();//selected activities
                        ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
                        if (selectionService != null && selectionService.SelectionCount > 0)
                        {
                            ArrayList selectedComponents = new ArrayList(selectionService.GetSelectedComponents());
                            for (int i = 0; i < selectedComponents.Count; i++)
                            {
                                if (selectedComponents[i] is Activity)
                                    selectedActivities.Add(selectedComponents[i]);
                            }
                        }
                        this.OnPrepareContextMenu.DynamicInvoke(new object[] { selectedActivities.ToArray(typeof(Activity)), menuItems });
                    }

                    //somebody requested to show an item
                    if (menuItems.Count > 0)
                    {
                        this.ContextMenu = new ContextMenu(menuItems.ToArray(typeof(MenuItem)) as MenuItem[]);
                        this.ContextMenu.Show(this, this.PointToClient(Control.MousePosition));
                    }

                    //mark the message handled
                    m.Result = IntPtr.Zero;

                    //dont pass the message to the base but return immediatly
                    return;
                }

                base.WndProc(ref m);
            }
        }

        void workflowView_OnPrepareContextMenu(Activity[] selectedActivities, ArrayList menuItems)
        {
            if (this.OnPrepareContextMenu != null)
                this.OnPrepareContextMenu.DynamicInvoke(new object[] { selectedActivities, menuItems });
        }
    }
    #endregion
}