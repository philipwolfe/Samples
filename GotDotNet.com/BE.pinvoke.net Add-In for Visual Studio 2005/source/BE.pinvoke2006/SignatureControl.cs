using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BE.pinvoke2006.WebService;

namespace BE.pinvoke2006
{
    public partial class SignatureControl : UserControl
    {
        SignatureInfo signature;

        public SignatureControl()
        {
            InitializeComponent();
            this.Disposed += new EventHandler(SignatureControl_Disposed);
            Program.CurrentSignatureChanged += new EventHandler(Program_CurrentSignatureChanged);
        }

        void SignatureControl_Disposed(object sender, EventArgs e)
        {
            Program.CurrentSignatureChanged -= new EventHandler(Program_CurrentSignatureChanged);
        }

        void Program_CurrentSignatureChanged(object sender, EventArgs e)
        {
            if (this.signature != Program.CurrentSignature && this.checkRadioButton.Checked)
                this.checkRadioButton.Checked = false;
        }

        public SignatureControl(SignatureInfo info) : this()
        {
            this.signature = info;

            this.checkRadioButton.Text = this.signature.Language;
            this.updatedLabel.Text = string.Format("Last updated by {0} on {1}", info.LastAuthor, info.LastModified);
            this.signatureTextBox.Text = Program.ConvertString(info.Signature);
            this.toolTip.SetToolTip(this.btnOnline, string.Format("Go to {0}", info.Url));
        }

        private void checkRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(checkRadioButton.Checked)
                Program.CurrentSignature = this.signature;
        }

        bool isMouseEnter;

        private void SignatureControl_MouseEnter(object sender, EventArgs e)
        {
            timerDelay.Stop();
            isMouseEnter = true;
            timerDelay.Start();
          
        }

        private void SignatureControl_MouseLeave(object sender, EventArgs e)
        {
            timerDelay.Stop();
            isMouseEnter = false;
            timerDelay.Start();
        }

        private void timerDelay_Tick(object sender, EventArgs e)
        {
            timerDelay.Stop();
            if (isMouseEnter)
            {
                this.BackColor = Color.FromArgb(49, 106, 197);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 223, 140);
                this.ForeColor = Color.Black;
            }
        }

        private void SignatureControl_Click(object sender, EventArgs e)
        {
            this.checkRadioButton.Checked = true;
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            Program.BrowseTo(signature.Url);
        }
    }
}
