//===========================================================================
//	File:		InboxViewerForm.cs
//
//	Summary:	The inbox form that displays the list of e-mail messages.
//
//---------------------------------------------------------------------------
//	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
//===========================================================================
using System.ComponentModel;
using System.Diagnostics;
using System;
using System.WinForms;
using System.Drawing;

public class InboxViewerForm : Form
{
	private Container components;
	private ColumnHeader columnReceived;
	private ColumnHeader columnSubject;
	private ColumnHeader columnFrom;
	public  ListView listView1;
        
	public InboxViewerForm() 
	{
		// Required for Form Designer support
		InitializeComponent();

		this.Show();

		try
		{
			// Create a new Session
			if (CDO.CreateNewSession() != null)
				CDO.FillInMessages(this);
		}
		catch (System.Runtime.InteropServices.COMException ex)
		{
			//
			// MAPI_E_USER_CANCEL = 0x80040113
			//
			if ((uint)ex.ErrorCode == 0x80040113)
				MessageBox.Show("Logon has been canceled, so the progam will now exit.", "InboxViewer");
			else
				MessageBox.Show("Unexpected Error: " + ex.ToString(), "InboxViewer");

			this.BeginInvoke(new MethodInvoker(Application.Exit));
		}
		catch (Exception ex)
		{
			// The user might have closed the window before we finished.
			if (this.Visible)
			{
				MessageBox.Show("Unexpected Error: " + ex.GetType().ToString() + ex.ToString(), "InboxViewer");
				this.BeginInvoke(new MethodInvoker(Application.Exit));
			}
			else 
			{
				Application.Exit();
			}
		}
	}

	//
 	// InboxViewerForm overrides dispose so it can clean up the component list.
	//
	public override void Dispose() 
	{
		base.Dispose();
		components.Dispose();
	}

	private void InitializeComponent()
	{
		this.components = new Container();
		this.columnFrom = new ColumnHeader();
		this.columnReceived = new ColumnHeader();
		this.listView1 = new ListView();
		this.columnSubject = new ColumnHeader();
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.Text = "C# Inbox Viewer";
		this.ClientSize = new System.Drawing.Size(592, 413);
		
		columnFrom.Text = "From";
		columnFrom.Width = 157;
		columnFrom.TextAlign = HorizontalAlignment.Left;
		
		columnReceived.Text = "Received";
		columnReceived.Width = 125;
		columnReceived.TextAlign = HorizontalAlignment.Left;

		columnSubject.Text = "Subject";
		columnSubject.Width = this.ClientSize.Width - columnFrom.Width - columnReceived.Width - 25;
		columnSubject.TextAlign = System.WinForms.HorizontalAlignment.Left;
		
		listView1.Text = "listView1";
		listView1.Size = new System.Drawing.Size(592, 416);
		listView1.ForeColor = System.Drawing.SystemColors.WindowText;
		listView1.TabIndex = 0;
		listView1.View = System.WinForms.View.Report;
		listView1.Columns.All = new ColumnHeader[] {columnFrom, columnSubject, columnReceived};
		listView1.FullRowSelect = true;
		listView1.MultiSelect = false;
		
		this.Controls.Add(listView1);

		// Event handlers
		this.AddOnResize(new System.EventHandler(InboxViewerForm_Resize));
		listView1.AddOnItemActivate(new System.EventHandler(listView1_ItemActivate));
	}

	private void InboxViewerForm_Resize(object sender, System.EventArgs e)
	{
		listView1.Width = this.ClientSize.Width;
		listView1.Height = this.ClientSize.Height;	
		columnSubject.Width = this.ClientSize.Width - columnFrom.Width - columnReceived.Width - 25;
	}

	private void listView1_ItemActivate(object sender, System.EventArgs e)
	{
		ListItem i = listView1.FocusedItem;

		// Get more details about the message from the ID
		string [] info = CDO.GetMessageDetails(i.GetSubItem(2));

		MessageForm form = new MessageForm(i.GetSubItem(0), info[3], info[2], info[1], i.Text, info[0]);
		form.Show();
	}

	//
	// The main entry point for the application.
	//
	public static void Main(string[] args)
	{
		try
		{
			Application.Run(new InboxViewerForm());
		}
		catch (Exception) {}
	}
}
