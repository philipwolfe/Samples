using System;
using System.Collections;
using System.Web;
using System.Web.UI;

namespace TemplateControlSamples {

    public class Repeater2 : Control, INamingContainer {

        private ITemplate              _itemTemplate    = null;      
        private ICollection            _dataSource      = null;  
        private RepeaterItemCollection _repeaterItems   = null;

        public ICollection DataSource {
            get {
                return _dataSource;
            }
            set {
                _dataSource = value;
            }
        }

        [
            Template(typeof(RepeaterItem))
        ]
        public ITemplate ItemTemplate {
            get {
                return _itemTemplate;
            }
            set {
                _itemTemplate = value;
            }
        }

        public RepeaterItemCollection Items {
            get {
                return _repeaterItems;
            }
        }

        // override to prevent literal controls from being added as children
        public override void AddParsedSubObject(object o) {
        }

        // override to create repeated items
        protected override void CreateChildControls() {
            object o = State["NumItems"];
            if (o != null) {
               // clear any existing child controls
               Controls.Clear();

                ArrayList items = new ArrayList();
                int numItems = (int)o;
                for (int i=0; i < numItems; i++) {
                    // create item
                    RepeaterItem item = new RepeaterItem(i, null);
                    // initialize item from template
                    ItemTemplate.Initialize(item);
                    // add item to the child controls collection
                    Controls.Add(item);
                    // save item in ArrayList to update the Items collection
                    items.Add(item);
                }
                // update the Items collection with newly added items
                _repeaterItems = new RepeaterItemCollection(items);
            }
        }

        // override to create repeated items from DataSource
        protected override void OnDataBinding(EventArgs e) {

            if (DataSource != null) {
                // clear any existing child controls
                Controls.Clear();
                // clear any previous viewstate for existing child controls
                ClearChildViewState();

                ArrayList items = new ArrayList();
                // iterate DataSource creating a new item for each data item
                IEnumerator dataEnum = DataSource.GetEnumerator();
                int i = 0;
                while(dataEnum.MoveNext()) {

                    // create item
                    RepeaterItem item = new RepeaterItem(i, dataEnum.Current);
                    // initialize item from template
                    ItemTemplate.Initialize(item);
                    // add item to the child controls collection
                    Controls.Add(item);
                    // save item in ArrayList to update the Items collection
                    items.Add(item);

                    i++;         
                }

                // update the Items collection with newly added items
                _repeaterItems = new RepeaterItemCollection(items);
                // prevent child controls from being created again
                ChildControlsCreated = true;
                // store the number of items created in viewstate for postback scenarios
                State["NumItems"] = i;
            }
        }    

    }    
}