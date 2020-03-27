//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.ServiceProcess;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace How_To_Service_Manager
{
    public partial class frmMain : Form
    {
        // Used to access an instance of the selected service.
        private ServiceController msvc;
        private ListViewItem ViewItem;

        private Hashtable mcolSvcs = new Hashtable();

        // Used to control UI updates.

        private bool fUpdatingUI;

        public frmMain()
        {
            InitializeComponent();
            //Add any initialization after the InitializeComponent() call
            // So that we only need to set the title of the application once,
            // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
            // to read the AssemblyTitle attribute.
            AssemblyInfo ainfo = new AssemblyInfo();
            this.Text = ainfo.Title;
            this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
        }


        #region " Standard Menu Code "
        // This code simply shows the About form.

        private void mnuAbout_Click(object sender, System.EventArgs e)
        {

            // Open the About form in Dialog Mode

            frmAbout frm = new frmAbout();

            frm.ShowDialog(this);

            frm.Dispose();

        }

        // This code will close the form.

        private void mnuExit_Click(object sender, System.EventArgs e)
        {

            // Close the current form

            this.Close();

        }

        #endregion

        private void chkAutoRefresh_CheckedChanged(object sender, System.EventArgs e)
        {
            // Turn the timer on or off
            if (this.chkAutoRefresh.CheckState == CheckState.Checked)
            {
                this.tmrStatus.Enabled = true;
            }
            else
            {
                this.tmrStatus.Enabled = false;
            }
        }

        private void cmdPause_Click(object sender, System.EventArgs e)
        {
            try
            {
                msvc.Pause();
                fUpdatingUI = true;
                UpdateUIForSelectedService();
                fUpdatingUI = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdResume_Click(object sender, System.EventArgs e)
        {
            try
            {
                msvc.Continue();
                fUpdatingUI = true;
                UpdateUIForSelectedService();
                fUpdatingUI = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdStart_Click(object sender, System.EventArgs e)
        {
            try
            {
                msvc.Start();
                fUpdatingUI = true;
                UpdateUIForSelectedService();
                fUpdatingUI = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdStop_Click(object sender, System.EventArgs e)
        {
            try
            {
                msvc.Stop();
                fUpdatingUI = true;
                UpdateUIForSelectedService();
                fUpdatingUI = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            EnumServices();
        }

        private void lvServices_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fUpdatingUI = true;
            UpdateUIForSelectedService();
            fUpdatingUI = false;
        }

        private void tmrStatus_Tick(object sender, System.EventArgs e)
        {
            if (!fUpdatingUI)
            {
                UpdateServiceStatus();
            }
        }

        private void EnumServices()
        {
            // Get the list of available services and
            // load the list view control with the information
            try
            {
                fUpdatingUI = true;
                this.sbInfo.Text = "Loading Service List, pleasse wait";
                this.sbInfo.Refresh();
                this.lvServices.Items.Clear();
                if (!(mcolSvcs == null))
                {
                    mcolSvcs = new Hashtable();
                }

                //svcs  = new ServiceController[];
                ServiceController[] svcs = ServiceController.GetServices();

                foreach (ServiceController svc in svcs)
                {
                    ViewItem = this.lvServices.Items.Add(svc.DisplayName);
                    ViewItem.SubItems.Add(svc.Status.ToString());
                    ViewItem.SubItems.Add(svc.ServiceType.ToString());


                    //mcolSvcs.Add(svc, svc.DisplayName);
                    mcolSvcs.Add(svc.DisplayName, svc);

                    //Next svc++;
                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.sbInfo.Text = "Ready";
                fUpdatingUI = false;
            }
        }

        private void UpdateServiceStatus()
        {
            // Check each service
            try
            {
                fUpdatingUI = true;
                this.sbInfo.Text = "Checking Service Status . . ";
                this.sbInfo.Refresh();

                // We could walk through the collection of services
                // two ways. One would be to enumerate all the services
                // via mcolSvc and then find the particular item in the
                // list view control to update its status.
                // The second method is to do the following code which
                // seems a bit easier since the collection is keyed by
                // the service display name which we get from the list view 
                // control.

                foreach (ListViewItem lvi in this.lvServices.Items)
                {
                    msvc = ((ServiceController)(mcolSvcs[lvi.Text]));
                    msvc.Refresh();
                    lvi.SubItems[1].Text = msvc.Status.ToString();
                    //Next lvi;
                }
                UpdateUIForSelectedService();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.sbInfo.Text = "Ready";
                fUpdatingUI = false;
            }
        }

        private void UpdateUIForSelectedService()
        {
            // Update the command buttons for the selected service.
            string strName;
            int ItemIndex;

            try
            {
                if (this.lvServices.SelectedItems.Count == 1)
                {

                    strName = this.lvServices.SelectedItems[0].SubItems[0].Text;
                    ItemIndex = this.lvServices.FocusedItem.Index;
                    msvc = ((ServiceController)(mcolSvcs[strName]));
                    //msvc = ((ServiceController) (mcolSvcs[ItemIndex]) );

                    // if it's stopped, we should be able to start it
                    this.cmdStart.Enabled = (msvc.Status == ServiceControllerStatus.Stopped);

                    // Check if we're allowed to try and stop it and make sure it's not
                    // already stopped.
                    this.cmdStop.Enabled = (msvc.CanStop && (!(msvc.Status == ServiceControllerStatus.Stopped)));

                    // Check if we're allowed to pause it and see if it is not paused
                    // already.
                    this.cmdPause.Enabled = (msvc.CanPauseAndContinue && (!(msvc.Status == ServiceControllerStatus.Paused)));

                    // if it's paused, we must be able to resume it.
                    this.cmdResume.Enabled = (msvc.Status == ServiceControllerStatus.Paused);
                }

            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRefresh_Click(object sender, System.EventArgs e)
        {
            if (!fUpdatingUI)
            {
                UpdateServiceStatus();
            }
        }

        private void mnuRelist_Click(object sender, System.EventArgs e)
        {
            if (!fUpdatingUI)
            {
                EnumServices();
            }
        }

        private void pnlCommands_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}