using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
[assembly:WebResource("WorkflowVisibilityControl.wf.png","image/png")]
[assembly: WebResource("WorkflowVisibilityControl.WorkflowDesignerControl.dll", "application/x-msdownload")]
namespace WorkflowVisibilityControl
{
   
    [ToolboxData("<{0}:WorkflowVisibilityControl runat=server></{0}:WorkflowVisibilityControl>")]
    
    public class WorkflowVisibilityControlImageMap : CompositeControl ,IPostBackEventHandler
    {
        private string _activity;

        public string Activity
        {
            get { return _activity; }
            set { _activity = value; }
        }
        private string _workflowType;

        public string WorkflowType
        {
            get { return _workflowType; }
            set { _workflowType = value; }
        }
        private string _handlerURL;

        public string HandlerURL
        {
            get { return _handlerURL; }
            set { _handlerURL = value; }
        }

       

        ImageMap _im;
        public WorkflowVisibilityControlImageMap()
        {
            _im = new ImageMap();
            _im.ID = "MyMap";
        }
        protected override void CreateChildControls()
        {
            
            _im.Click += new ImageMapEventHandler(_im_Click);
            _im.ImageUrl = String.Format("{0}?act={1}&type={2}&e={3}", HandlerURL, Activity, WorkflowType,Guid.NewGuid().ToString());
            _im.HotSpotMode = HotSpotMode.PostBack;           
            RectangleHotSpot hs = new RectangleHotSpot();
            hs.Bottom=100;
            hs.Right = 697;

            _im.HotSpots.Add(hs);
            hs = new RectangleHotSpot();
            hs.Top = 101;
            hs.Bottom = 200;
            hs.Right = 697;
            _im.HotSpots.Add(hs);
            this.Controls.Add(_im);
            base.CreateChildControls();
        }
        public event ImageMapEventHandler  Click
        {
            add { _im.Click += value; }
            remove { _im.Click -= value; }
        }
        void _im_Click(object sender, ImageMapEventArgs e)
        {
            

        }


        #region IPostBackEventHandler Members

        public void RaisePostBackEvent(string eventArgument)
        {
            ((IPostBackEventHandler)_im).RaisePostBackEvent(eventArgument);
        }

        #endregion
    }
}
