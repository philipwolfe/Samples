using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using Microsoft.Workflow.Samples.Administration;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    public enum DataSelectionType : int { None, Tracked, Live };

    //any class that will be providing information about the workflow instance
    //should implement this interface
    public interface IWorkflowInstance
    {
        Guid InstanceId { get; }
        DateTime ActivationTime { get; }
        string Type { get; }
        ActivityExecutionStatus State { get; }
        bool Completed { get; }
        bool Suspended { get; }

        string Title { get; }
        string Xoml { get; }
        List<TrackedActivity> ActivityStateList { get; }
    }

    public class AssemblyLoadedEventArgs : EventArgs
    {
        private string path;

        public AssemblyLoadedEventArgs(string path)
        {
            this.path = path;
        }

        public string Path
        {
            get { return this.path; }
        }
    }

    //this class will manage live and tracked workflow providers 
    //based on the data source selection and grouping it will update the 
    //list of the workflows visible (grouping parent can show/hide it's children)
    public class WorkflowInstanceManager : IBindingList
    {
        private static WorkflowInstanceManager singleton = null;

        public static EventHandler NewAssemblyLoaded;

        private string[] dataSelectionTypeDescr = new string[] { "Workflows", "Tracked Instances", "Live Instances" };
        private List<TwoLineGridRowItem> items = new List<TwoLineGridRowItem>();
        private ListChangedEventHandler listChangedEventHandler;

        private string connectionString = null;//"Initial Catalog=MyTrackingDb;Data Source=localhost;Integrated Security=SSPI;";

        private AdministrationServiceProxy liveProvider = null;
        private SQLTrackingDataProvider trackedProvider = null;

        private DataSelectionType dataSelectionType = DataSelectionType.None;

        private Control uiControl;//events from runtime need to be marshalled to the ui thread, we need a ui control reference for that
        private List<string> loadedAssemblies;//assemblies loaded in the RT
        private List<string> referencedAssemblies;//assemblies referenced in the config file

        public static WorkflowInstanceManager GetWorkflowInstanceManager(Control uiControl)
        {
            if (WorkflowInstanceManager.singleton == null)
            {
                WorkflowInstanceManager.singleton = new WorkflowInstanceManager(uiControl);
            }
            return WorkflowInstanceManager.singleton;
        }

        private WorkflowInstanceManager(Control uiControl)
        {
            this.referencedAssemblies = new List<string>();
            ReadConfiguration();

            this.loadedAssemblies = new List<string>();
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            this.uiControl = uiControl;
        }

        private void ReadConfiguration()
        {
            //getting connection string for the app to read instance data
            try
            {
                SqlConnectionInfo instanceDataProviderTrackingDatabase = ConfigurationManager.GetSection("Microsoft.Workflow.Samples.DynamicUpdate/instanceDataProviderTrackingDatabase") as SqlConnectionInfo;
                if (instanceDataProviderTrackingDatabase != null && instanceDataProviderTrackingDatabase.ConnectionString != null && instanceDataProviderTrackingDatabase.ConnectionString.Length > 0)
                    this.connectionString = instanceDataProviderTrackingDatabase.ConnectionString;
            }
            catch
            {
                this.connectionString = null;
            }

            //try to use the default one if there is no valid connection string provided in the config file
            if (this.connectionString == null || this.connectionString.Length == 0)
                this.connectionString = "Initial Catalog=MyTrackingDb;Data Source=localhost;Integrated Security=SSPI;";

            try
            {
                List<ReferenceAssembly> assemblyReferences = ConfigurationManager.GetSection("Microsoft.Workflow.Samples.DynamicUpdate/assemblyReferences") as List<ReferenceAssembly>;
                if (assemblyReferences != null)
                {
                    foreach (ReferenceAssembly referenceAssembly in assemblyReferences)
                    {
                        string refpath = Path.GetFullPath(referenceAssembly.AssemblyPath);
                        if (File.Exists(refpath))
                            this.referencedAssemblies.Add(refpath);
                    }
                }
            }
            catch
            {
            }
        }

        public static string[] GetLoadedAssemblies()
        {
            return WorkflowInstanceManager.singleton.loadedAssemblies.ToArray();
        }

        public static void UpdateLoadedAssemlbiesList()
        {
            if (WorkflowInstanceManager.singleton != null && WorkflowInstanceManager.singleton.liveProvider != null)
                WorkflowInstanceManager.singleton.UpdateLoadedAssemlbiesList(WorkflowInstanceManager.singleton.liveProvider.GetLoadedAssemblies());
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //first try to use list of assemblies loaded in the RT
            lock (this.loadedAssemblies)
            {
                foreach (string assemblyName in this.loadedAssemblies)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(assemblyName);
                        if (assembly.FullName == args.Name)
                            return assembly;
                    }
                    catch
                    {
                        //ignore assembly load errors
                    }
                }
            }

            //if it fail, try to use the list of referenced assemblies provieded in the config file
            lock (this.referencedAssemblies)
            {
                foreach (string assemblyName in this.referencedAssemblies)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(assemblyName);
                        if (assembly.FullName == args.Name)
                            return assembly;
                    }
                    catch
                    {
                        //ignore assembly load errors
                    }
                }
            }
            //nothing was found...
            return null;
        }

        public DataSelectionType SelectionType
        {
            get { return this.dataSelectionType; }
            set
            {
                if (this.dataSelectionType == value)
                    return;

                this.dataSelectionType = value;
                this.items.Clear();

                List<IWorkflowInstance> instances = null;
                string instanceTypeSuffix = "Tracked";

                switch (this.dataSelectionType)
                {
                    case DataSelectionType.None:
                        break;
                    case DataSelectionType.Live:
                        instances = EnumerateLive();
                        instanceTypeSuffix = "Live";
                        break;
                    case DataSelectionType.Tracked:
                        instances = EnumerateTracked();
                        instanceTypeSuffix = "Tracked";
                        break;
                }

                if (instances != null)
                {
                    foreach (IWorkflowInstance instance in instances)
                    {
                        TwoLineGridRowItem item = WrapIWorkflowInstance(instance, instanceTypeSuffix);
                        this.items.Add(item);
                    }
                }

                FireListRefresh();
            }
        }

        private TwoLineGridRowItem WrapIWorkflowInstance(IWorkflowInstance instance, string instanceTypeSuffix)
        {
            TwoLineGridRowItem item = TwoLineGridRowItem.CreateTwoLineRowItem(instance, instanceTypeSuffix);
            return item;
        }

        public string SelectionDescription
        {
            get { return this.dataSelectionTypeDescr[(int)SelectionType]; }
        }

        private void UpdateLoadedAssemlbiesList(string[] assemblies)
        {
            lock (this.loadedAssemblies)
            {
                foreach (string assembly in assemblies)
                {
                    if (!this.loadedAssemblies.Contains(assembly))
                    {
                        this.loadedAssemblies.Add(assembly);
                        if (WorkflowInstanceManager.NewAssemblyLoaded != null)
                            WorkflowInstanceManager.NewAssemblyLoaded(this, new AssemblyLoadedEventArgs(assembly));
                    }
                }
            }
        }

        private List<IWorkflowInstance> EnumerateLive()
        {
            try
            {
                if (this.liveProvider == null)
                    this.liveProvider = AdministrationServiceProxy.EstablishLiveConnection(new LiveProxyInstanceCreator());

                this.liveProvider.OnInstanceStateChanged += new EventHandler(liveProvider_OnInstanceStateChanged);

                UpdateLoadedAssemlbiesList(this.liveProvider.GetLoadedAssemblies());

                List<IWorkflowInstance> adminInstances = new List<IWorkflowInstance>();
                if (this.liveProvider != null)
                {
                    foreach (IWorkflowInstance workflowInstance in this.liveProvider.GetWorkflowInstances())
                        adminInstances.Add(workflowInstance);
                }

                //now sort them by creation time
                WorkflowInstanceSorter.Sort(adminInstances);

                return adminInstances;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Could not connect to the Runtime Administration Interface\n" + exc.Message, "Error Establishing Connection");
            }
            return null;
        }

        private List<IWorkflowInstance> EnumerateTracked()
        {
            try
            {
                //stop receiving live events for now, but keep the connection opened
                if (this.liveProvider != null)
                    this.liveProvider.OnInstanceStateChanged -= new EventHandler(liveProvider_OnInstanceStateChanged);

                if (this.trackedProvider == null)
                    this.trackedProvider = new SQLTrackingDataProvider(connectionString);

                List<IWorkflowInstance> adminInstances = new List<IWorkflowInstance>();
                foreach (IWorkflowInstance workflowInstance in this.trackedProvider.Enumerate(typeof(TrackedWorkflowInstance)))
                    adminInstances.Add(workflowInstance);

                return adminInstances;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Could not connect to the tracking data provider\n" + exc.Message);
            }
            return null;
        }

        private void AddNewItem(TwoLineGridRowItem newItem)
        {
            lock (this.syncRoot)
            {
                this.items.Add(newItem);
                int index = this.items.Count - 1;//the last item in the list
                FireListNewItem(index);
            }
        }

        private IStateChangeEventCallback DeleteCompletedItem(Guid id)
        {
            for (int index = 0; index < this.items.Count; index++)
            {
                TwoLineGridRowItem item = this.items[index];
                IWorkflowInstance instance = item.Instance;

                if (instance.InstanceId == id)
                {
                    lock (this.syncRoot)
                    {
                        this.items.RemoveAt(index);
                        FireListItemDeleted(index);
                    }
                    return instance as IStateChangeEventCallback;
                }
            }
            return null;
        }

        private IStateChangeEventCallback GetCachedInstanceByID(Guid id)
        {
            for (int index = 0; index < this.items.Count; index++)
            {
                TwoLineGridRowItem item = this.items[index];
                IWorkflowInstance instance = item.Instance;

                if (instance.InstanceId == id)
                    return instance as IStateChangeEventCallback;
            }
            return null;
        }

        private void FireListRefresh()
        {
            this.uiControl.BeginInvoke(new ListChangedEventHandler(FireListChangedEvent), new object[] { this, new ListChangedEventArgs(ListChangedType.Reset, 0) });
        }

        private void FireListNewItem(int index)
        {
            this.uiControl.BeginInvoke(new ListChangedEventHandler(FireListChangedEvent), new object[] { this, new ListChangedEventArgs(ListChangedType.ItemAdded, index) });
        }

        private void FireListItemDeleted(int index)
        {
            this.uiControl.BeginInvoke(new ListChangedEventHandler(FireListChangedEvent), new object[] { this, new ListChangedEventArgs(ListChangedType.ItemDeleted, index) });
        }

        private void FireListChangedEvent(object sender, ListChangedEventArgs e)
        {
            //bound data changed events have to be marshalled to the ui thread...
            if (this.listChangedEventHandler != null)
                this.listChangedEventHandler(this, e);
        }

        private void liveProvider_OnInstanceStateChanged(object sender, EventArgs e)
        {
            InstanceStateChangeEventArgs args = e as InstanceStateChangeEventArgs;
            IStateChangeEventCallback instance = null;
            if (args != null)
            {
                switch (args.ChangeType)
                {
                    case InstanceStateChangeType.Created:
                        instance = this.liveProvider.GetWorkflowInstance(args.InstanceId);
                        AddNewItem(WrapIWorkflowInstance(instance as IWorkflowInstance, "Live"));
                        LiveInstanceProxy proxy = instance as LiveInstanceProxy;
                        proxy.OnInstanceStateChanged += new EventHandler(liveProvider_OnInstanceStateChanged);
                        break;

                    case InstanceStateChangeType.Completed:
                    case InstanceStateChangeType.Terminated:
                        instance = DeleteCompletedItem(args.InstanceId);
                        break;
                }


                if (this.uiControl != null)
                    this.uiControl.BeginInvoke(new EventHandler(InvalidateUIControl));
            }
        }
        private void InvalidateUIControl(object sender, EventArgs e)
        {
            this.uiControl.Invalidate();
        }

        #region IWorkflowInstance Sorter
        internal sealed class WorkflowInstanceSorter : IComparer<IWorkflowInstance>
        {
            private WorkflowInstanceSorter()
            {
            }

            public static void Sort(List<IWorkflowInstance> instances)
            {
                WorkflowInstanceSorter sorter = new WorkflowInstanceSorter();
                instances.Sort(sorter);
            }

            int IComparer<IWorkflowInstance>.Compare(IWorkflowInstance lhs, IWorkflowInstance rhs)
            {
                if (lhs.InstanceId == rhs.InstanceId)
                    return 0;

                return DateTime.Compare(lhs.ActivationTime, rhs.ActivationTime);
            }
        }
        #endregion

        #region IBindingList Members

        void IBindingList.AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        object IBindingList.AddNew()
        {
            throw new NotImplementedException();
        }

        bool IBindingList.AllowEdit
        {
            get { return false; }
        }

        bool IBindingList.AllowNew
        {
            get { return false; }
        }

        bool IBindingList.AllowRemove
        {
            get { return false; }
        }

        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        int IBindingList.Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        bool IBindingList.IsSorted
        {
            get { return false; }
        }

        event ListChangedEventHandler IBindingList.ListChanged
        {
            add { this.listChangedEventHandler += value; }
            remove { this.listChangedEventHandler -= value; }
        }

        void IBindingList.RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        void IBindingList.RemoveSort()
        {
            throw new NotImplementedException();
        }

        ListSortDirection IBindingList.SortDirection
        {
            get { throw new NotImplementedException(); }
        }

        PropertyDescriptor IBindingList.SortProperty
        {
            get { throw new NotImplementedException(); }
        }

        bool IBindingList.SupportsChangeNotification
        {
            get { return true; }
        }

        bool IBindingList.SupportsSearching
        {
            get { return false; }
        }

        bool IBindingList.SupportsSorting
        {
            get { return false; }
        }

        #endregion

        #region IList Members

        int System.Collections.IList.Add(object value)
        {
            throw new NotImplementedException();
        }

        void System.Collections.IList.Clear()
        {
            throw new NotImplementedException();
        }

        bool System.Collections.IList.Contains(object value)
        {
            return this.items.Contains(value as TwoLineGridRowItem);
        }

        int System.Collections.IList.IndexOf(object value)
        {
            return this.items.IndexOf(value as TwoLineGridRowItem);
        }

        void System.Collections.IList.Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        bool System.Collections.IList.IsFixedSize
        {
            get { return false; }
        }

        bool System.Collections.IList.IsReadOnly
        {
            get { return true; }
        }

        object System.Collections.IList.this[int index]
        {
            get { return this.items[index]; }
            set { throw new NotImplementedException(); }
        }

        void System.Collections.IList.Remove(object value)
        {
            throw new NotImplementedException();
        }

        void System.Collections.IList.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICollection Members

        void System.Collections.ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        int System.Collections.ICollection.Count
        {
            get { return this.items.Count; }
        }

        bool System.Collections.ICollection.IsSynchronized
        {
            get { return true; }
        }

        private object syncRoot = new object();
        object System.Collections.ICollection.SyncRoot
        {
            get { return this.syncRoot; }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        #endregion
    }
}