using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BE.pinvoke2006.WebService;

namespace BE.pinvoke2006
{
    public partial class DownloadForm : Form
    {
        public DownloadForm()
        {
            InitializeComponent();

            Program.StateChanged += new EventHandler(Program_StateChanged);
            Program.ContentChanged += new EventHandler(Program_ContentChanged);
            Program.CurrentLanguageChanged += new EventHandler(Program_CurrentLanguageChanged);
            Program.CurrentSignatureChanged += new EventHandler(Program_CurrentSignatureChanged);
        }

        void Program_CurrentSignatureChanged(object sender, EventArgs e)
        {
            insertButton.Enabled = (Program.CurrentSignature != null);
        }

        void Program_CurrentLanguageChanged(object sender, EventArgs e)
        {
            this.UpdateContent();
        }

        void Program_StateChanged(object sender, EventArgs e)
        {
            if (Program.State == State.Searching)
            {
                this.contentTabControl.TabPages.Clear();

                TabPage tab = new TabPage("Searching...");
                this.contentTabControl.TabPages.Add(tab);

                ProgressBar pb = new ProgressBar();
                pb.Style = ProgressBarStyle.Marquee;
                pb.Width = tab.Width / 2;
                pb.Top = tab.Height / 2 - pb.Height / 2;
                pb.Left = tab.Width / 2 - pb.Width / 2;
                pb.MarqueeAnimationSpeed = 40;
                tab.Controls.Add(pb);
            }
            else if (Program.State == State.SearchingError)
            {
                this.contentTabControl.TabPages.Clear();

                TabPage tab = new TabPage("Search Result");
                this.contentTabControl.TabPages.Add(tab);

                Label txt = new Label();
                txt.Dock = DockStyle.Fill;
                txt.TextAlign = ContentAlignment.MiddleCenter;
                
                if (Program.Error.InnerException != null)
                {
                    txt.Text = Program.Error.InnerException.Message;
                }
                else
                {
                    txt.Text = Program.Error.Message;
                }
                
                
                tab.Controls.Add(txt);
            }
        }


        void Program_ContentChanged(object sender, EventArgs e)
        {
            UpdateLanguages();
            UpdateContent();
        }

        private void UpdateLanguages()
        {
            this.languageCombo.Items.Clear();

            this.languageCombo.Visible = this.languageLabel.Visible = (Program.Content.Length > 0);

            if (Program.Content.Length == 0)
                return;

            string allItem = "(All)";
            this.languageCombo.Items.Add(allItem);
        
            foreach (SignatureInfo info in Program.Content)
            {
                if (!languageCombo.Items.Contains(info.Language))
                {
                    languageCombo.Items.Add(info.Language);
                }
            }

            this.languageCombo.SelectedItem = Program.CurrentLanguage;
        }

        void UpdateContent()
        {
            this.contentTabControl.TabPages.Clear();
            
            if (Program.Content.Length == 0)
                return;

            string allItem = "(All)";
      
            SignatureInfo previous = null;
            SignatureList list = null;

            foreach (SignatureInfo info in Program.Content)
            {
                if (Program.CurrentLanguage != allItem && Program.CurrentLanguage != info.Language)
                    continue;

                if (previous == null || previous.Module != info.Module)
                {

                    TabPage page = new TabPage(info.Module);
                    this.contentTabControl.TabPages.Add(page);

                    list = new SignatureList();
                    list.ModuleDescription = info.Summary;
                    page.Controls.Add(list);
                    list.Dock = DockStyle.Fill;
                }

                SignatureControl signatureControl = new SignatureControl(info);
                list.AddSignature(signatureControl);

                previous = info;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string function = this.functionTextBox.Text;
            string module = this.moduleTextBox.Text;

            Program.FindFunction(function, module);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void languageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.CurrentLanguage = languageCombo.SelectedItem.ToString();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void pinvokelogo_Click(object sender, EventArgs e)
        {
            Program.BrowseTo(Properties.Resources.wwwpinvokenet);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pinvokelogo_Click(null, null);
        }

        private void DownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.StateChanged -= new EventHandler(Program_StateChanged);
            Program.ContentChanged -= new EventHandler(Program_ContentChanged);
            Program.CurrentLanguageChanged -= new EventHandler(Program_CurrentLanguageChanged);
            Program.CurrentSignatureChanged -= new EventHandler(Program_CurrentSignatureChanged);
        }
    }
}