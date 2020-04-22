using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventViewer
{
	public partial class FormEventViewer : Form
	{
		const string moduleName = "Event Viewer";
		System.Timers.Timer timer = new System.Timers.Timer();
		static MessageViewer mv = null;
		object[] o = new object[5];

		public FormEventViewer()
		{
			InitializeComponent();
			timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
			timer.Interval = 60000;			// milliseconds
			timer.AutoReset = false;			// must do a .Start() every time
			timer.Enabled = true;
		}

		private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
		{
			System.Diagnostics.EventLogEntry ele = (System.Diagnostics.EventLogEntry) e.Entry;
			o[0] = ele.TimeGenerated.ToString();
			o[1] = ele.MachineName;
			o[2] = ele.EntryType;
			o[3] = ele.Source;
			o[4] = ele.Message;
			dataGridViewEventViewer.Rows.Insert(0,o);
			if (dataGridViewEventViewer.Rows.Count > EventViewer.Properties.Settings.Default.MaximumNumberOfRowsDisplayed)
				dataGridViewEventViewer.Rows.RemoveAt(dataGridViewEventViewer.Rows.Count - 1);		// remove bottom row
			notifyIcon1.Text = moduleName + ": New " + o[2] + " message from " + o[3].ToString() + " on " + o[1].ToString();
			timer.Start();			// start timer that resets text to just the module name
		}

		private void OnTimer(object source, System.Timers.ElapsedEventArgs e)
		{
			notifyIcon1.Text = moduleName;			// reset to just the name after time expires
			timer.Enabled = true;
		}

		private void dataGridViewEventViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow vr = dataGridViewEventViewer.Rows[e.RowIndex];		// get the clicked on row
			mv = new MessageViewer(vr.Cells[0].Value.ToString(), vr.Cells[1].Value.ToString(), vr.Cells[2].Value.ToString(), vr.Cells[3].Value.ToString(), vr.Cells[4].Value.ToString());
			mv.Show();
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
		}

		private void FormEventViewer_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;		// stop the form from closing
			this.Hide();			// hide it; it's in the System Tray
			if (mv != null)			// hide the detail window if one exists
				mv.Hide();
		}
	}
}