using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.Util;

namespace TemplateControlSamples {

    public class RepeaterItemCollection : ICollection {

        private ArrayList items;

        public RepeaterItemCollection(ArrayList items) {
            this.items = items;
        }

        public RepeaterItem[] All {
            get {
                return (RepeaterItem[])items.ToArray();
            }
        }

        public int Count {
            get {
                return items.Count;
            }
        }

        public bool IsReadOnly {
            get {
                return false;
            }
        }

        public bool IsSynchronized {
            get {
                return false;
            }
        }

        public object SyncRoot {
            get {
                return this;
            }
        }

        public RepeaterItem this[int index] {
            get {
                return (RepeaterItem)items[index];
            }
        }
        
        public void CopyTo(Array array, int index) {
            for (IEnumerator e = this.GetEnumerator(); e.MoveNext();)
                array.SetValue(e.Current, index++);
        }

        public IEnumerator GetEnumerator() {
            return items.GetEnumerator(); 
        }
    }
}