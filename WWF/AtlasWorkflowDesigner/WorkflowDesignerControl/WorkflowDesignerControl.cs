//Copyright (c) 2006 Jon Flanders - http://www.masteringbiztalk.com/
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
//associated documentation files (the "Software"), to deal in the Software without restriction, 
//including without limitation the rights to use, copy, modify, merge, publish, distribute, 
//sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
//is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included 
//in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
//FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Activities;
using System.Workflow.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Workflow.ComponentModel.Serialization;
using System.Xml;
using System.CodeDom.Compiler;
using System.Workflow.Runtime;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Reflection;
using System.Diagnostics;

namespace WorkflowDesignerControl
{
    public partial class WorkflowDesignerControl : UserControl, IDisposable, IServiceProvider
    {
        public static Image GetToolboxImage(string name)
        {
            if (_toolbox.ContainsKey(name))
                return _toolbox[name].Bitmap;
            else
                return null;
        }
        public static List<string> ToolboxItems
        {
            get
            {
                List<string> ret = new List<string>();
                foreach (KeyValuePair<string, ToolboxItem> p in _toolbox)
                    ret.Add(p.Key);
                return ret;
            }
        }
        private WorkflowView _view;
        private DesignSurface _surface;
        private WorkflowLoader _loader;
        internal static readonly string XomlExample = @"<SequentialWorkflowActivity x:Class=""HelloWorld.HelloWorldWorkflow"" x:Name=""HelloWorldWorkflow"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/workflow"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                                                <CodeActivity x:Name=""CodeActivity1"" ExecuteCode=""CodeActivity1_ExecuteCode""/>
                                                <x:Code>
                                                <![CDATA[
                                                void CodeActivity1_ExecuteCode(object o,EventArgs e)
                                                {
	                                                System.Console.WriteLine(""Hello World"");
                                                }
                                                ]]>
                                                </x:Code>
                                                </SequentialWorkflowActivity>";



        public WorkflowDesignerControl()
        {
            InitializeComponent();
            WorkflowTheme.CurrentTheme.ReadOnly = false;
        }
        static Dictionary<string, ToolboxItem> _toolbox = InitToolBox();

        private static Dictionary<string, ToolboxItem> InitToolBox()
        {
            Dictionary<string, ToolboxItem> ret = new Dictionary<string, ToolboxItem>();
            Type[] types = new Type[] { typeof(DelayActivity), typeof(Activity) };
            foreach (Type at in types)
            {
                Assembly a = at.Assembly;

                foreach (Type t in a.GetTypes())
                {
                    try
                    {
                        ToolboxItem tbi = ToolboxService.GetToolboxItem(t, true);
                        if (tbi != null)
                            ret.Add(tbi.DisplayName, tbi);
                    }
                    catch { }


                }
            }
            return ret;
        }


        public void SaveWorkflowImage(Stream s, ImageFormat format)
        {
            this._view.FitToScreenSize();
            this._view.SaveWorkflowImage(s, format);
        }


        

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                UnloadWorkflow();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        new public object GetService(Type serviceType)
        {
            return (this._view != null) ? ((IServiceProvider)this._view).GetService(serviceType) : null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public void LoadWorkflow(string xoml)
        {
            SuspendLayout();
            DesignSurface designSurface = new DesignSurface();
            WorkflowLoader loader = new WorkflowLoader();
            loader.Xoml = xoml;
            designSurface.BeginLoad(loader);

            IDesignerHost designerHost = designSurface.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null && designerHost.RootComponent != null)
            {
                IRootDesigner rootDesigner = designerHost.GetDesigner(designerHost.RootComponent) as IRootDesigner;
                if (rootDesigner != null)
                {
                    UnloadWorkflow();

                    this._surface = designSurface;
                    this._loader = loader;
                    this._view = rootDesigner.GetView(ViewTechnology.Default) as WorkflowView;
                    this.pnlDesigner.Controls.Add(this._view);
                    //this._view.Dock = DockStyle.Fill;
                    this._view.Height = 600;

                    this._view.Width = 600;
                    this._view.TabIndex = 1;
                    this._view.TabStop = true;
                    this._view.HScrollBar.TabStop = false;
                    this._view.VScrollBar.TabStop = false;
                    this._view.Focus();
                    MyWorkflowDesignerMessageFilter mf = new MyWorkflowDesignerMessageFilter();
                    this._view.AddDesignerMessageFilter(mf);
                }
            }
            //get activities for ComboBox
            ResumeLayout(true);
        }

        private void UnloadWorkflow()
        {
            IDesignerHost designerHost = GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null && designerHost.Container.Components.Count > 0)
                _loader.RemoveActivityFromDesigner(designerHost.RootComponent as Activity);

            if (this._surface != null)
            {
                this._surface.Dispose();
                this._surface = null;
            }

            if (this._view != null)
            {
                Controls.Remove(this._view);
                this._view.Dispose();
                this._view = null;
            }
        }

        //private void ShowDefaultWorkflow()
        //{

        //    this.Xoml = XomlExample;

        //}
        public ValidationErrorCollection ValidateWF()
        {
            IDesignerHost designerHost = _surface.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null)
            {
                CompositeActivityDesigner root = designerHost.GetDesigner(designerHost.RootComponent) as CompositeActivityDesigner;
                if (root != null)
                {
                    object[] oa = root.Activity.GetType().GetCustomAttributes(typeof(ActivityValidatorAttribute), true);
                    if (oa != null && oa.Length == 1)
                    {

                    }
                }
            }
            return null;
        }
        public void ChangeView(string actName, string view)
        {
            ISelectionService selectionService = (ISelectionService)_surface.GetService(typeof(ISelectionService));
            IReferenceService referenceService = (IReferenceService)_surface.GetService(typeof(IReferenceService));
            if (selectionService != null && referenceService != null)
            {
                Activity act = (Activity)referenceService.GetReference(actName);
                if (act!=null)
                {
                    IDesignerHost designerHost = _surface.GetService(typeof(IDesignerHost)) as IDesignerHost;
                   
                    StructuredCompositeActivityDesigner sd = designerHost.GetDesigner(act) as StructuredCompositeActivityDesigner;
                    if (sd != null)
                    {
                        //find the view
                        DesignerView theView = null;
                        foreach (DesignerView dv in sd.Views)
                        {
                            if (dv.Text == view)
                            {
                                theView = dv;
                            }
                        }
                        if (theView != null)
                        {
                            sd.ActiveView = theView;
                            HighlightActivity(theView.AssociatedDesigner.Activity.Name);

                        }
                    } 
                }
                               
            }

        }
        public Dictionary<string, DesignerData> GetBounds()
        {
            Dictionary<string, DesignerData> ret = new Dictionary<string, DesignerData>();
            if (_surface != null)
            {
                IDesignerHost designerHost = _surface.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (designerHost != null)
                {
                    CompositeActivityDesigner root = designerHost.GetDesigner(designerHost.RootComponent) as CompositeActivityDesigner;
                    if (root != null)
                    {
                        AddContained(root, ret);
                    }
                }
            }
            return ret;

        }
        void AddContained(CompositeActivityDesigner root, Dictionary<string, DesignerData> ret)
        {
            foreach (ActivityDesigner ad in root.ContainedDesigners)
            {

                DesignerData d = new DesignerData();
                d.Bounds = ad.Bounds;
                StructuredCompositeActivityDesigner sad = ad as StructuredCompositeActivityDesigner;
                if (sad != null)
                {
                    foreach (DesignerView dv in sad.Views)
                    {

                        d.Views.Add(dv.Text);
                    }
                }
                ret.Add(ad.Activity.Name, d);
                if (ad is CompositeActivityDesigner)
                    AddContained((CompositeActivityDesigner)ad, ret);
            }
        }
        T GetService<T>()
        {
            return (T)_surface.GetService(typeof(T));
        }
        public string CutActivity(string name, out Activity[] act)
        {
            Activity[] a = RemoveAct(name);
            act = a;
            return GetCurrentXAML();
        }
        public string DeleteActivity(string name)
        {
            RemoveAct(name);
            return GetCurrentXAML();
        }
        Activity[] RemoveAct(string name)
        {
            IDesignerHost designerHost = GetService<IDesignerHost>();
            IReferenceService refService = GetService<IReferenceService>();
            ISelectionService selService = GetService<ISelectionService>();
            object o = refService.GetReference(name);
            HighlightActivity(name);
            ICollection acts = selService.GetSelectedComponents();
            Activity a = o as Activity;
            List<Activity> lacts = new List<Activity>();
            foreach (Activity sa in acts)
                lacts.Add(sa);
            CompositeActivity ca = designerHost.RootComponent as CompositeActivity;
            if (ca != null)
            {
               RemoveRecursive(ca,a);
                _loader.RemoveActivityFromDesigner(a);
            }

            return lacts.ToArray();
        }
        void RemoveRecursive(CompositeActivity ca, Activity a)
        {
            bool removed = ca.Activities.Remove(a);
            if (!removed)
            {
                foreach (Activity cca in ca.Activities)
                {
                    if(cca is CompositeActivity)
                        RemoveRecursive((CompositeActivity)cca, a);
                }
            }
        }
        public string CopyActivity(string name, int x, int y)
        {
            IDesignerHost designerHost = GetService<IDesignerHost>();
            IReferenceService refService = GetService<IReferenceService>();
            ISelectionService selService = GetService<ISelectionService>();
            object o = refService.GetReference(name);
            HighlightActivity(name);
            ICollection cacts = selService.GetSelectedComponents();
            List<Activity> lacts = new List<Activity>();
            foreach (Activity sa in cacts)
                lacts.Add(sa);
            IDataObject ido = CompositeActivityDesigner.SerializeActivitiesToDataObject(this._surface, lacts.ToArray());
            Activity[] acts = CompositeActivityDesigner.DeserializeActivitiesFromDataObject(this._surface, ido);
            string oname;
            AddActivies(acts, x, y, "", out oname);
            return GetCurrentXAML();

        }
        public string MoveActivity(string name, int x, int y)
        {
            Activity[] a = RemoveAct(name);
            string oname;
            AddActivies(a, x, y, "", out oname);
            return GetCurrentXAML();
        }
        public string AddActivity(Activity[] a, int x, int y)
        {
            string oname;
            AddActivies(a, x, y, "", out oname);
            return GetCurrentXAML();
        }
        void AddActivies(Activity[] activities, int x, int y, string lastact, out string name)
        {
            name = string.Empty;
            IDesignerHost designerHost = GetService<IDesignerHost>();
            CompositeActivityDesigner root = designerHost.GetDesigner(designerHost.RootComponent) as CompositeActivityDesigner;
            int newx = x;//-200;
            int newy = y;// 20;
            if (newx < root.Bounds.X)
                newx = root.Bounds.X;
            if (newy < root.Bounds.Y)
                newy = root.Bounds.Y;
            Point point1 = new Point(newx, newy);

            HitTestInfo hti = root.HitTest(point1);// root.HitTest(point1);// new HitTestInfo(root, HitTestLocations.Designer);
            List<Activity> lacts = new List<Activity>();
            lacts.AddRange(activities);
            ReadOnlyCollection<Activity> acts = new ReadOnlyCollection<Activity>(lacts);
            if (hti.AssociatedDesigner != null)
            {
                CompositeActivityDesigner cad = hti.AssociatedDesigner as CompositeActivityDesigner;
                if (cad != null)
                    root = cad;
            }
            if (root.CanInsertActivities(hti, acts))
            {
                CompositeActivityDesigner.InsertActivities(root, hti, acts, "");
                this.HighlightActivity(hti.AssociatedDesigner.Activity.Name);
                name = acts[0].Name;
            }

        }
        string GetCurrentXAML()
        {
            IDesignerHost designerHost = _surface.GetService(typeof(IDesignerHost)) as IDesignerHost;

            WorkflowMarkupSerializer s = new WorkflowMarkupSerializer();
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            s.Serialize(XmlWriter.Create(sw), designerHost.RootComponent);

            _loader.Xoml = sb.ToString();
            LoadWorkflow(_loader.Xoml);
            return _loader.Xoml;
        }
        public string AddActivity(string activityName, int x, int y, string lastact, out string name)
        {
            IDesignerHost designerHost = _surface.GetService(typeof(IDesignerHost)) as IDesignerHost;
            name = string.Empty;
            if (activityName != null)
            {
                Activity[] lacts = GetFromToolbox(activityName);
                AddActivies(lacts, x, y, lastact, out name);

            }
            return GetCurrentXAML();

        }
        Activity[] GetFromToolbox(string activityName)
        {
            List<Activity> lacts = new List<Activity>();
            if (_toolbox.ContainsKey(activityName))
            {
                ToolboxItem tbi = _toolbox[activityName];
                IComponent[] c = tbi.CreateComponents();
                if (c != null)
                {

                    foreach (IComponent ic in c)
                        lacts.Add((Activity)ic);
                }
            }
            return lacts.ToArray();
        }




        internal Activity GetRoot(Activity child)
        {
            Activity temp = child;
            while (temp.Parent != null)
            {
                temp = temp.Parent;
            }
            return temp;


        }
        internal Activity[] GetStateParentActivity(Activity child)
        {
            if (child.Parent == null)
                return new Activity[] { null, null };
            Activity activity1 = child;
            Activity temp = null;
            while (activity1.GetType() != typeof(StateActivity) || activity1.Parent == null)
            {
                temp = activity1;
                activity1 = activity1.Parent;

            }
            return new Activity[] { activity1, temp };

        }
        public void HighlightActivity(string activityName)
        {
            ISelectionService selectionService = (ISelectionService)_surface.GetService(typeof(ISelectionService));
            IReferenceService referenceService = (IReferenceService)_surface.GetService(typeof(IReferenceService));
            if (selectionService != null && referenceService != null)
            {
                Activity activityComponent = (Activity)referenceService.GetReference(activityName);

                if (activityComponent != null)
                {

                    IDesignerHost designerHost = _surface.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (designerHost != null)
                    {

                        Activity root = GetRoot(activityComponent);
                        bool statemachine = root is StateMachineWorkflowActivity;
                        if (statemachine)
                        {
                            Activity[] parents = GetStateParentActivity(activityComponent);
                            Activity state = parents[1];
                            Activity pstate = parents[0];
                            if (state != null && pstate != null)
                            {
                                ActivityDesigner sd = designerHost.GetDesigner(state) as ActivityDesigner;
                                FreeformActivityDesigner parentd = designerHost.GetDesigner(pstate) as FreeformActivityDesigner;
                                parentd.EnsureVisibleContainedDesigner(sd);
                            }
                        }
                        ActivityDesigner ad = designerHost.GetDesigner(activityComponent) as ActivityDesigner;

                        //ad.DesignerTheme.BackColorEnd = Color.OrangeRed;
                        //ad.DesignerTheme.BackColorStart = Color.OrangeRed;
                        selectionService.SetSelectedComponents(new IComponent[] { activityComponent as IComponent }, SelectionTypes.Primary);
                        _view.PerformLayout(true);

                    }
                }
            }
        }



        public Dictionary<string,PropertyDescriptorCollection> GetProperties()
        {
            Dictionary<string, PropertyDescriptorCollection> ret = new Dictionary<string, PropertyDescriptorCollection>();
            IDesignerHost designerHost = _surface.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null)
            {
                CompositeActivity act = designerHost.RootComponent as CompositeActivity;
                if (act != null)
                {
                    AddChildProperties(act, ret);
                }
            }
            return ret;
        }
        void AddChildProperties(CompositeActivity parent, Dictionary<string, PropertyDescriptorCollection> props)
        {
            foreach (Activity a in parent.Activities)
            {
                props.Add(a.Name, TypeDescriptor.GetProperties(a));
                if (a is CompositeActivity)
                    AddChildProperties((CompositeActivity)a, props);
            }
        }
    }
    //TODO:Hmmmm
    public class DesignerData
    {
        private List<string> _views = new List<string>();

        public List<string> Views
        {
            get { return _views; }
        }

        private Rectangle _bounds;

        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

    }
    public class MyWorkflowDesignerMessageFilter : WorkflowDesignerMessageFilter
    {
        public MyWorkflowDesignerMessageFilter()
        {

        }
        protected override bool OnDragDrop(DragEventArgs eventArgs)
        {
            Debug.WriteLine(String.Format("x : {0} y: {1} ae: {2} e: {3} k: {4}", eventArgs.X, eventArgs.Y, eventArgs.AllowedEffect, eventArgs.Effect, eventArgs.KeyState));
            return false;
        }
    }

}
