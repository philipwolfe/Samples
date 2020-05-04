using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BE.pinvoke2006
{
    public class SignatureListControl : FlowLayoutPanel
    {
        // public FunctionListControl Function
        public SignatureListControl()
        {
            this.AutoScroll = true;
            this.FlowDirection = FlowDirection.TopDown;
            this.WrapContents = false;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            UpdateChildWidth(e.Control);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            UpdateChildWidth();
        }

        void UpdateChildWidth()
        {
            foreach (Control c in this.Controls)
                UpdateChildWidth(c);
        }

        void UpdateChildWidth(Control c)
        {
            c.Width = this.Width - this.Margin.Left - this.Margin.Right;
        }
    }
}
