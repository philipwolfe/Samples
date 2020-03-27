using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace How_To_Service_Manager
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }
        // Note: Because this form is opened by frmMain using the ShowDialog command, we simply set the

	// DialogResult property of cmdOK to OK which causes the form to close when clicked.

        private void frmAbout_Load(object sender, System.EventArgs e)
        {

            try
            {

                // Set this Form's Text + Icon properties by using values from the parent form

                this.Text = "About " + this.Owner.Text;

                this.Icon = this.Owner.Icon;

                // Set this Form's Picture Box's image using the parent's icon 

                // However, we need to convert it to a Bitmap since the Picture Box Control

                // will not accept a raw Icon.

                this.pbIcon.Image = this.Owner.Icon.ToBitmap();

                // Set the labels identitying the Title, Version, and Description by

                // reading Assembly meta-data originally entered in the AssemblyInfo.cs file

                // using the AssemblyInfo class defined in the same file

                AssemblyInfo ainfo = new AssemblyInfo();

                this.lblTitle.Text = ainfo.Title;

                this.lblVersion.Text = string.Format("Version {0}", ainfo.Version);

                this.lblCopyright.Text = ainfo.Copyright;

                this.lblDescription.Text = ainfo.Description;

                this.lblCodebase.Text = ainfo.CodeBase;

            }
            catch (System.Exception exp)
            {

                // This catch will trap any unexpected error.

                MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}