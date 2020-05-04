using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BE.pinvoke2006
{
    public partial class SignatureList : UserControl
    {
        public SignatureList()
        {
            InitializeComponent();
            Program.CurrentSignatureChanged += new EventHandler(Program_CurrentSignatureChanged);
            this.Disposed += new EventHandler(SignatureList_Disposed);
        }

        void SignatureList_Disposed(object sender, EventArgs e)
        {
            Program.CurrentSignatureChanged -= new EventHandler(Program_CurrentSignatureChanged);
        }

        

        void Program_CurrentSignatureChanged(object sender, EventArgs e)
        {
            if (Program.CurrentSignature == null)
            {
                alternativeApiLabel.Text = "";
                return;
            }

            alternativeApiLabel.Text = Program.ConvertString(Program.CurrentSignature.AlternativeManagedAPI);
        }

        public string ModuleDescription
        {
            get
            {
                return moduleDescriptionLabel.Text;
            }
            set
            {
                moduleDescriptionLabel.Text = value;
            }
        }

        public void AddSignature(SignatureControl sc)
        {
            this.signaturesPanel.Controls.Add(sc);
            sc.Width = this.signaturesPanel.Width - this.signaturesPanel.Margin.Left - this.signaturesPanel.Margin.Right;
        }
    }
}
