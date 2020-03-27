using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace WorkingWithTheActionsPane
{
    public partial class ThisDocument
    {
        ProductLookupUserControl uc;
        Button b1, b2;

        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            // Create a new instance of the user control
            uc = new ProductLookupUserControl();
            
            // Create a test button
            b1 = new Button();
            b1.Text = "Button 1";
            b1.Click += new EventHandler(b1_Click);

            // Create another test button
            b2 = new Button();
            b2.Text = "Button 2";
            b2.Click += new EventHandler(b2_Click);

            // Add all three controls to the ActionsPane, show it, then
            // add an event handler to fire if the orientation of the
            // ActionsPane changes.
            this.ActionsPane.Controls.AddRange(new Control[] { uc, b1, b2 });
            this.ActionsPane.Show();
            this.ActionsPane.OrientationChanged += new EventHandler(ActionsPane_OrientationChanged);
        }

        void b1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked button 1");
        }

        void b2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked button 2");
        }

        /// <summary>
        /// If the toolbar is docked from side to top or bottom, the controls can
        /// be laid out left-to-right instead of top-to-bottom.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ActionsPane_OrientationChanged(object sender, EventArgs e)
        {
            if (this.ActionsPane.Orientation == Orientation.Vertical)
            {
                this.ActionsPane.StackOrder = Microsoft.Office.Tools.StackStyle.FromTop;
            }
            else
            {
                this.ActionsPane.StackOrder = Microsoft.Office.Tools.StackStyle.FromLeft;
            }
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
