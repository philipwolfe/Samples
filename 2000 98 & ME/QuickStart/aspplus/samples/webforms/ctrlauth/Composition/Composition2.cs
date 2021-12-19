using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompositionSampleControls {

    public class Composition2 : Control, INamingContainer {

        public int Value {
           get {
               return Int32.Parse(((TextBox)Controls[1]).Text);
           }
           set {
               ((TextBox)Controls[1]).Text = value.ToString();
           }
        }

        protected override void CreateChildControls() {

           // Add Literal Control

           this.Controls.Add(new LiteralControl("<h3>Value: "));

           // Add Textbox

           TextBox box = new TextBox();
           box.Text = "0";
           this.Controls.Add(box);

           // Add Literal Control

           this.Controls.Add(new LiteralControl("</h3>"));

           // Add "Add" Button

           Button addButton = new Button();
           addButton.Text = "Add";
           addButton.Click += new EventHandler(this.AddBtn_Click);
           this.Controls.Add(addButton);

           // Add Literal Control

           this.Controls.Add(new LiteralControl(" | "));

           // Add "Subtract" Button

           Button subtractButton = new Button();
           subtractButton.Text = "Subtract";
           subtractButton.Click += new EventHandler(this.SubtractBtn_Click);
           this.Controls.Add(subtractButton);

        }

        private void AddBtn_Click(Object sender, EventArgs e) {
           this.Value++;
        }

        private void SubtractBtn_Click(Object sender, EventArgs e) {
           this.Value--;
        }        
    }    
}