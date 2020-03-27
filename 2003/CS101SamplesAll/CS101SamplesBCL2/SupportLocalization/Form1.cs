using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SupportLocalization
{

    public partial class Form1 : Form
    {
        /// Flag to toggle CultureInfo from one locale to another
        /// in order to affect the language change on the form
        private static bool isChange = false;

        public Form1()
        {
            InitializeComponent();
        }
  
        /// When the button is clicked, the CultureInfo is toggled back and
        /// forth between language display on the form.  The ComponentResourceManager
        /// is used to load the appropriate resource for the specified CultureInfo.
        /// The mechanisim appends the locale to the resource file name to select the
        /// proper resource.  For example; an empty string causes the default Resource1.resx
        /// to be applied and constructing a CultureInfo with the "de" culture name causes the 
        /// Resource1.de.resx file to be used.  When ApplyResources is called on a particular component 
        /// with the current CultureInfo, reflection is used to extract the properties
        /// from the resource file and apply it to the component.  Typically, the CultureInfo would
        /// be extracted from system settings.
        private void button1_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(""); //invariant culture
            isChange = !isChange;
            if( isChange ) 
                ci = new CultureInfo("de");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resource1));
            resources.ApplyResources(this.button1, "button1", ci);
            resources.ApplyResources(this.label1, "label1", ci);
            resources.ApplyResources(this.radioButton1, "radioButton1", ci);
            resources.ApplyResources(this.textBox1, "textBox1", ci);
        }
    }
}