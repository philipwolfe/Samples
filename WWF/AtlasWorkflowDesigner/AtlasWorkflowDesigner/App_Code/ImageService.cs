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
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using WorkflowDesignerControl;
using System.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel.Compiler;
using Flanders.Workflow.Designer.Web;
using XAMLDataSetTableAdapters;

namespace WorkflowAtlasDesigner
{
    /// <summary>
    /// Summary description for ImageService
    /// </summary>
    [WebService(Namespace = "http://www.flandersconsulting.com/schemas/webservices/WFDesignerService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ImageService : System.Web.Services.WebService
    {

        public ImageService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod(EnableSession = true)]
        public ResponseData SaveWorkflow(string controlid,string id)
        {

            ResponseData rd = new ResponseData();
            workflowTableAdapter t = new workflowTableAdapter();
            XAMLDataSet.workflowDataTable dt = t.GetData();
            Guid wfid = new Guid(id);
            XAMLDataSet.workflowRow r = dt.FindByworkflow_id(wfid);
            r.workflow_xaml = Session["xoml"].ToString();
            if(Session["rulexaml"]!=null)
                r.workflow_rules = Session["rulexaml"].ToString();
            t.Update(r);
            rd.Id = controlid;
            rd.UUID = Guid.NewGuid().ToString();
            return rd;
        }
        [WebMethod(EnableSession = true)]
        public ResponseData SaveWorkflowAs(string controlid, string id, string newname)
        {

            ResponseData rd = new ResponseData();
            rd.UUID = Guid.NewGuid().ToString();
            return rd;
        }
        [WebMethod(EnableSession = true)]
        public MenuItem[] GetWorkflows(string controlid)
        {
            workflowTableAdapter t = new workflowTableAdapter();
            XAMLDataSet.workflowDataTable dt = t.GetData();
            List<MenuItem> items = new List<MenuItem>();
            MenuItem mi = null;
            foreach (XAMLDataSet.workflowRow r in dt.Rows)
            {
                mi = new MenuItem();
                mi.Name = r.workflow_name;
                mi.Cmd.Args = new string[] { r.workflow_id.ToString() };
                mi.Cmd.ObjRef = "wfimagedesignerImage";
                mi.Cmd.Name = "openWorkflowById";
                items.Add(mi);
            }
            return items.ToArray();
        }
        [WebMethod(EnableSession = true)]
        public ResponseData NewWorkflow(string controlid)
        {
            ResponseData rd = new ResponseData();

            //reset
            Session["xoml"] = null;
            Session["rulexaml"] = null;

            rd.Id = controlid;
            rd.UUID = Guid.NewGuid().ToString();
            return rd;
        }
        [WebMethod(EnableSession = true)]
        public string SaveNewWorkflow(string controlid,string name)
        {
            ResponseData rd = new ResponseData();
            workflowTableAdapter t = new workflowTableAdapter();
            Guid g = Guid.NewGuid();
            t.Insert(g, name, "", "1.0.0.0", Session["xoml"].ToString(), Session["rulexaml"], HttpContext.Current.User.Identity.Name, DateTime.Now);

            return g.ToString();
        }
        [WebMethod(EnableSession = true)]
        public ResponseData ChangeWorkflow(string controlid, string wfid)
        {
            ResponseData rd = new ResponseData();
            Guid g = new Guid(wfid);
            workflowTableAdapter t = new workflowTableAdapter();
          
            XAMLDataSet.workflowDataTable dt = t.GetData();
          
            XAMLDataSet.workflowRow r = dt.FindByworkflow_id(g);
            Session["xoml"] = r.workflow_xaml;
            if (!r.Isworkflow_rulesNull())
            {
                Session["rulexaml"] = r.workflow_rules;
            }
            else
                Session["rulexaml"] = null;
            rd.Id = controlid;
            rd.UUID = Guid.NewGuid().ToString();
            return rd;
        }
        [WebMethod(EnableSession = true)]
        public PropertyResponse GetProperties(string id, string actName)
        {
            List<Property> data = new List<Property>();

            string xoml = HttpContext.Current.Session["xoml"] as string;
            if (xoml != null)
            {
                WorkflowMarkupSerializer s = new WorkflowMarkupSerializer();
                CompositeActivity ca = s.Deserialize(System.Xml.XmlReader.Create(new StringReader(xoml))) as CompositeActivity;
                if (ca != null)
                {
                    Activity a = GetActivity(ca, actName);

                    if (a != null)
                    {
                        if (a != null)
                        {
                            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(a, new Attribute[] { BrowsableAttribute.Yes });
                            for (int i = 0; i < pdc.Count; i++)
                            {
                                Property sr = new Property(pdc[i].Name, GetPropertyValue(a, pdc[i]));
                                data.Add(sr);
                            }
                        }

                    }
                }
            }
            else
            {

            }

            PropertyResponse resp = new PropertyResponse();
            resp.UUID = Guid.NewGuid().ToString();
            resp.Id = id;
            resp.props = data.ToArray();
            return resp;

        }

        private static string GetPropertyValue(Activity a, PropertyDescriptor pd)
        {
            string ret = pd.GetValue(a) == null ? "" : pd.GetValue(a).ToString();
            if (pd.PropertyType == typeof(System.Workflow.ComponentModel.ActivityCondition))
            {
                //we assume RuleConditionReference only
                RuleConditionReference rcr = pd.GetValue(a) as RuleConditionReference;
                if (rcr != null)
                {
                    RuleCondition r = GetRule(rcr.ConditionName);
                    if (r != null)
                        ret = r.ToString();
                }
            }
            return ret;
        }
        static void AddRuleCondition(RuleCondition rc)
        {

            AddOrReplace(rc);
        }
        private static void AddOrReplace(RuleCondition rc)
        {
            RuleDefinitions rd = GetRuleDef();
            RuleCondition exists = GetRule(rc.Name);
            if (exists != null)
                rd.Conditions.Remove(exists);
            rd.Conditions.Add(rc);
            SaveRuleDef(rd);
        }
        private static RuleCondition GetRule(string p)
        {
            RuleDefinitions rd = GetRuleDef();
            RuleCondition r = null;
            foreach (RuleCondition ir in rd.Conditions)
            {
                if (ir.Name == p)
                    r = ir;
            }
            return r;
        }
        Activity GetActivity(CompositeActivity parent, string name)
        {
            Activity a = null;
            a = parent.GetActivityByName(name);
            if (a == null)
                a = parent.Activities[name];
            if (a == null)
            {
                //try all the children
                foreach (Activity ca in parent.Activities)
                {
                    if (ca is CompositeActivity)
                    {
                        a = GetActivity((CompositeActivity)ca, name);
                        if (a != null)
                            break;
                    }
                }
            }
            return a;

        }
        [WebMethod(EnableSession = true)]
        public PropertyResponse SetProperties(string id, string actName, Property[] props)
        {
            string xoml = HttpContext.Current.Session["xoml"] as string;
            if (xoml != null)
            {
                WorkflowMarkupSerializer s = new WorkflowMarkupSerializer();
                CompositeActivity ca = s.Deserialize(System.Xml.XmlReader.Create(new StringReader(xoml))) as CompositeActivity;
                if (ca != null)
                {
                    Activity a = GetActivity(ca, actName);
                    if (a != null)
                    {
                        PropertyDescriptorCollection pdc = GetPropertyDescriptor(actName);
                        PropertyDescriptorCollection rpdc = GetRealPropDescriptors(a);
                        foreach (Property p in props)
                        {
                            PropertyDescriptor pd = pdc[p.Name];
                            if (p.Name == "Name")
                            {
                                actName = p.Value;
                                a.Name = p.Value;
                                pd = null;
                            }
                            if (pd != null)
                            {
                                try
                                {
                                    Type pt = pd.PropertyType;
                                    switch (pt.ToString())
                                    {
                                        case "System.Workflow.ComponentModel.ActivityCondition":
                                            //assuming XAML only workflow design and will convert string from
                                            //"HTML property grid" and turn it into a rule Condtion
                                            //System.Workflow.ComponentModel.Design.ConditionTypeConverter is internal so have to use this technique
                                            Type t = Type.GetType("System.Workflow.ComponentModel.Design.ConditionTypeConverter, System.Workflow.ComponentModel, Version=3.0.0.0 ,Culture=neutral,PublicKeyToken=31bf3856ad364e35");

                                            if (pd.Converter.GetType() == t)
                                            {
                                                string conditionname = "Condition1";
                                                RuleExpressionCondition rc = new RuleExpressionCondition(conditionname);
                                                rc.Expression = new System.CodeDom.CodePrimitiveExpression(Boolean.Parse(p.Value));
                                                RuleConditionReference rcr = new RuleConditionReference();
                                                rcr.ConditionName = conditionname;
                                                pd.SetValue(a, rcr);
                                                AddOrReplace(rc);

                                            }
                                            break;
                                        case "System.Type":
                                            Type pvt = Type.GetType(p.Value);
                                            if (pvt != null)
                                                pd.SetValue(a, pvt);
                                            break;
                                        default:


                                            try
                                            {
                                                pd.SetValue(a, pd.Converter.ConvertFromString(p.Value));
                                            }
                                            catch (Exception ex)
                                            {
                                                if (pd.PropertyType == typeof(String))
                                                {
                                                    pd.SetValue(a, p.Value);
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        rpdc[p.Name].SetValue(a, rpdc[p.Name].Converter.ConvertFromString(p.Value));
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }
                                            break;
                                    }


                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("Unabled to convert property " + p.Name + " with value " + p.Name + " exception " + ex.ToString());

                                }
                            }
                        }

                    }
                }

                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                s.Serialize(XmlWriter.Create(sw), ca);
                HttpContext.Current.Session["xoml"] = sb.ToString();
            }

            return GetProperties(id, actName);

        }
        private PropertyDescriptorCollection GetRealPropDescriptors(Activity a)
        {
            return  TypeDescriptor.GetProperties(a, null, true);
        }
        private PropertyDescriptorCollection GetPropertyDescriptor(string actName)
        {
            PropertyDescriptorCollection ret = null;
            //TypeDescriptor.GetProperties(a, null, true);
            Dictionary<string, PropertyDescriptorCollection> props = HttpContext.Current.Session["wfproperties"] as Dictionary<string, PropertyDescriptorCollection>;
            if (props != null)
            {
                if (props.ContainsKey(actName))
                {
                    ret = props[actName];
                }
            }
            return ret;
        }
        static RuleDefinitions GetRuleDef()
        {
            RuleDefinitions rd = new RuleDefinitions();//empty if no rules  yet
            object rx = HttpContext.Current.Session["rulexaml"];
            if (rx != null)
            {
                WorkflowMarkupSerializer s = new WorkflowMarkupSerializer();
                string xaml = rx.ToString();
                object o = s.Deserialize(XmlReader.Create(new StringReader(xaml)));
                if (o != null)
                {
                    rd = o as RuleDefinitions;
                }
            }
            return rd;
        }
        static void SaveRuleDef(RuleDefinitions rdef)
        {

            WorkflowMarkupSerializer s = new WorkflowMarkupSerializer();
            StringBuilder rulexaml = new StringBuilder();
            XmlWriter xw = XmlWriter.Create(new StringWriter(rulexaml));
            s.Serialize(xw, rdef);
            HttpContext.Current.Session["rulexaml"] = rulexaml.ToString();
        }
        [WebMethod(EnableSession = true)]
        public Error[] GetValidationErrors()
        {
            List<Error> ret = new List<Error>();
            object vo = HttpContext.Current.Session["wferrors"];
            string act = null;
            if (vo != null)
            {
                System.Workflow.ComponentModel.Compiler.ValidationErrorCollection c = vo as System.Workflow.ComponentModel.Compiler.ValidationErrorCollection;
                if (c != null)
                {
                    foreach (ValidationError ve in c)
                    {
                        foreach (object k in ve.UserData.Values)
                        {
                            if (k is Activity)
                            {
                                act = ((Activity)k).Name;
                            }
                        }
                        ret.Add(new Error(act, ve.ErrorText, ve.PropertyName));
                    }
                }
            }
            return ret.ToArray();
        }
        [WebMethod(EnableSession = true)]
        public ResponseData ImageOperation(string cid, string cmd, string actData, int x, int y)
        {
            HttpContext.Current.Session["Cmd"] = cmd;
            HttpContext.Current.Session["actData"] = actData.Trim();
            HttpContext.Current.Session["x"] = x;
            HttpContext.Current.Session["y"] = y;
            ResponseData rd = new ResponseData();
            rd.UUID = Guid.NewGuid().ToString();
            rd.Id = cid;
            return rd;
        }

        [WebMethod(EnableSession = true)]
        public HotSpot[] GetHotSpots(string id)
        {
            List<HotSpot> spots = new List<HotSpot>();
            Dictionary<string, DesignerData> bounds = HttpContext.Current.Session["wfbounds"] as Dictionary<string, DesignerData>;
            if (bounds != null)
            {
                foreach (KeyValuePair<string, DesignerData> kvp in bounds)
                {
                    HotSpot hs = new HotSpot();
                    hs.altText = kvp.Key;
                    hs.Cmd.Name = "getProperties";
                    hs.Cmd.Args = new string[] { kvp.Key };
                    hs.Name = kvp.Key;
                    hs.Left = kvp.Value.Bounds.X;
                    hs.Top = kvp.Value.Bounds.Y;
                    hs.Bottom = (kvp.Value.Bounds.Y + 20);
                    hs.Right = (kvp.Value.Bounds.X + kvp.Value.Bounds.Width);
                    hs.shape = Shapes.rect;
                    List<MenuItem> items = new List<MenuItem>();
                    MenuItem mi = new MenuItem();
                    mi.Name = "Copy";
                    mi.Cmd.Name = "copyActivity";
                    mi.Cmd.ObjRef = "wfimagedesignerImage";
                    mi.Cmd.Args = new string[] { kvp.Key };
                    items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "Cut";
                    mi.Cmd.Name = "cutActivity";
                    mi.Cmd.ObjRef = "wfimagedesignerImage";
                    mi.Cmd.Args = new string[] { kvp.Key };
                    items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "Delete";
                    mi.Cmd.Name = "deleteActivity";
                    mi.Cmd.ObjRef = "wfimagedesignerImage";
                    mi.Cmd.Args = new string[] { kvp.Key };
                    items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "Help";
                    mi.Cmd.Name = "showHelp";
                    mi.Cmd.ObjRef = "wfimagedesignerImage";
                    mi.Cmd.Args = new string[] { kvp.Key };
                    items.Add(mi);
                    foreach (string v in kvp.Value.Views)
                    {
                        mi = new MenuItem();
                        mi.Name = v;
                        mi.Cmd.Name = "showView";
                        mi.Cmd.ObjRef = "wfimagedesignerImage";
                        List<string> args = new List<string>();
                        args.Add(kvp.Key);
                        args.Add(v);
                        mi.Cmd.Args = args.ToArray();
                        items.Add(mi);
                    }
                    hs.ContextMenuItems = items.ToArray();
                    spots.Add(hs);
                }
            }
            return spots.ToArray();
        }

    }
    public class Error
    {
        public Error()
        {

        }
        public Error(string a, string e, string p)
        {
            this.ActName = a;
            this.Err = e;
            this.Property = p;
        }
        public string ActName;
        public string Err;
        public string Property;
    }
    public class Property
    {
        public Property()
        {

        }
        public Property(string name, string value)
        {
            Name = name;
            Value = value;

        }
        public string Name;
        public string Value;
    }
    public class ResponseData
    {
        public string UUID;
        public string Id;
    }
    public class PropertyResponse
    {
        public string UUID;
        public string Id;
        public Property[] props;
    }
    //this defines each activity designer in the html client
    public class HotSpot
    {
        public string altText;
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public Shapes shape;
        public Command Cmd = new Command();//this is the javascript that will get executed when the designer element is clicked on
        public MenuItem[] ContextMenuItems;//these are items to be show in the context menu for that element
        public string Name;

    }
    public class Command
    {
        public string Name;
        public string ObjRef;
        public string[] Args;
    }

    public class MenuItem
    {
        public string Name;
        public Command Cmd = new Command();
        //public string ObjRef;
    }
    public enum Shapes
    {
        circle,
        rect,
        poly
    }
    public class Point
    {
        public int x;
        public int y;
        public override string ToString()
        {
            return String.Format("Point: {0},{1}", x, y);
        }
    }
}
