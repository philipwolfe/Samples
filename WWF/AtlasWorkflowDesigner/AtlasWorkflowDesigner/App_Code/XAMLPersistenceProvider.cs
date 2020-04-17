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
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Drawing;

namespace Flanders.Workflow.Designer.Web
{
    //TODO:Build out this part
    public abstract class XAMLProvider
    {


        public abstract WorkflowData CurrentWorkflow
        {
            get;
            set;
        }

        public abstract WorkflowData GetWorfklow(Guid wid);
        public abstract void SaveWorkflow(WorkflowData wd, bool autoversion);
        public abstract List<WorkflowData> GetAllWorkflows();
        public abstract Dictionary<string, ActivityDesignerData> ActivityDesignerData
        {
            get;
            set;
        }
        public abstract void AddNewActivity(NewActivityData data);


    }
    public class ActivityDesignerData
    {
        private List<string> _views;

        public List<string> Views
        {
            get { return _views; }
            set { _views = value; }
        }
	
        private List<string> _verbs;

        public List<string> Verbs
        {
            get { return _verbs; }
            set { _verbs = value; }
        }
	
        private Rectangle _rectangle;

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }
	
    }
    public class NewActivityData
    {
        private Point _point;

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }
	
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
	
    }
    public class WorkflowData
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
	
        private string _rules;

        public string Rules
        {
            get { return _rules; }
            set { _rules = value; }
        }
	
        private string _xaml;

        public string XAML
        {
            get { return _xaml; }
            set { _xaml = value; }
        }
	
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
	
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
	
        private Version _version;

        public Version Version
        {
            get { return _version; }
            set { _version = value; }
        }
	

    }
}
