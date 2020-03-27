using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace How_To_Process_Viewer
{
    public partial class frmModules : Form
    {
        public frmModules()
        {
            InitializeComponent();
        }
        private Process m_ParentProcess;

        private ListView.ListViewItemCollection mits;

        private List<ProcessModule> _mcolModules = new List<ProcessModule>();

        public Process ParentProcess
        {
            get
            {
                return ParentProcess;
            }
            set
            {
                m_ParentProcess = value;

                if (m_ParentProcess == null)
                {
                    _mcolModules = null;
                }

            }

        }

        private void EnumModules()
        {
            try
            {
                this.lvModules.Items.Clear();

                if (!(_mcolModules == null))
                {
                    _mcolModules = new List<ProcessModule>();
                }

                foreach (ProcessModule m in m_ParentProcess.Modules)
                {
                    this.lvModules.Items.Add(m.ModuleName);
                    try
                    {
                        _mcolModules.Add(m);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshModules()
        {
            this.sbInfo.Text = "Process = " + m_ParentProcess.ProcessName;
            this.lvModDetail.Items.Clear();
            EnumModules();
        }

        private void mnuClose_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void EnumModule(ProcessModule m)
        {
            this.lvModDetail.Items.Clear();
            mits = this.lvModDetail.Items;
            try
            {
                AddNameValuePair("Base Address", m.BaseAddress.ToInt32().ToString("x").ToLower());
                AddNameValuePair("Entry Point Address", m.EntryPointAddress.ToInt32().ToString("x").ToLower());
                AddNameValuePair("File Name", m.FileName);
                AddNameValuePair("File Version", m.FileVersionInfo.FileVersion.ToString());
                AddNameValuePair("File Description", m.FileVersionInfo.FileDescription);
                AddNameValuePair("Memory Size", m.ModuleMemorySize.ToString("N0"));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNameValuePair(string Item, string voidItem)
        {
            mits.Add(Item).SubItems.Add(voidItem);
        }

        private void lvModules_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                ListView lv = ((ListView)sender);
                if (lv.SelectedItems.Count == 1)
                {
                    string strMod = lv.SelectedItems[0].Text;
                    int ItemIndex = lv.FocusedItem.Index;
                    ProcessModule m = ((ProcessModule)(_mcolModules[ItemIndex]));
                       
                    EnumModule(m);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}