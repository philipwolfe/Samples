using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;
using System.Reflection;

namespace ContextEnabledForm
{
    public partial class Form1 : Form
    {
        PenInputPanel penInputPanel;
        SortedList<string, string> factoidNameValues = new SortedList<string, string>();

        public Form1()
        {
            InitializeComponent();

            //Attach the programmable PenInputPanel to the control
            penInputPanel = new PenInputPanel(textBox1);

            //Add all supported Factoids to the checked list box
            AddAllFactoids(listBox1.Items);

            //Add behavior to factoid items
            listBox1.SelectedIndexChanged += delegate(object sender, EventArgs e)
            {
                if (listBox1.SelectedItems.Count == 0)
                {
                    //If none selected, set Factoid to default
                    penInputPanel.Factoid = Factoid.Default;
                }

                //Get selected name of Factoid
                string factoidName = (string) listBox1.SelectedItem;

                //Retrieve factoid value
                string factoidValue = factoidNameValues[factoidName];

                try
                {
                    //Set context
                    penInputPanel.Factoid = factoidValue;
                }
                catch (Exception)
                {
                    //Not all systems support all factoids
                    MessageBox.Show("Factoid not supported on this system");

                    //Set the factoid to default
                    penInputPanel.Factoid = Factoid.Default;
                    listBox1.SelectedIndex = 1;
                    listBox1.Items.Remove(factoidName);
                    listBox1.Invalidate();
                }
            };

            //Enable or Disable Context Awareness within TextBox1
            checkBox1.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if (checkBox1.Checked)
                {
                    listBox1.Enabled = true;
                }
                else
                {
                    listBox1.Enabled = false;
                    penInputPanel.Factoid = Factoid.Default;
                }
            };
        }

        private void AddAllFactoids(ListBox.ObjectCollection objectCollection)
        {
            //Factoids are defined as static, public string constant fields in the Factoid object
            Type factoidType = typeof(Factoid);
            foreach(FieldInfo field in factoidType.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                //Retrieve the name of the Factoid
                string fieldName = field.Name;

                //"WordList" factoid is not supported for PenInputPanel
                if (fieldName == "WordList")
                {
                    continue;
                }
                
                //Retrieve the value of the Factoid (generally, but not always, the Name in uppercase
                string fieldValue= (string) field.GetValue(factoidType);

                //Add the name to the checked list box
                objectCollection.Add(fieldName);

                //Store the value so it can be retrieved when the list box is manipulated
                factoidNameValues.Add(fieldName, fieldValue);
            }
        }
    }
}