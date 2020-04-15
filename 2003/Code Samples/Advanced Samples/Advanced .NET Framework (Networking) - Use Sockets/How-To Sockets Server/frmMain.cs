//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;

public class frmMain : System.Windows.Forms.Form 
{

#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    public frmMain() 
	{
        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.
        AssemblyInfo ainfo = new AssemblyInfo();
        this.Text = ainfo.Title;
        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
    }

    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing) {
        if (disposing) {
            if (components != null) {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }
    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components = null;
    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    private System.Windows.Forms.MainMenu mnuMain;

    private System.Windows.Forms.MenuItem mnuFile;

    private System.Windows.Forms.MenuItem mnuExit;

    private System.Windows.Forms.MenuItem mnuHelp;

    private System.Windows.Forms.MenuItem mnuAbout;

    private System.Windows.Forms.ListBox lstStatus;

    private System.Windows.Forms.Button btnBroadcast;

    private System.Windows.Forms.TextBox txtBroadcast;

    private System.Windows.Forms.Label lblInstructions;

    private System.Windows.Forms.Label Label1;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.lstStatus = new System.Windows.Forms.ListBox();
		this.txtBroadcast = new System.Windows.Forms.TextBox();
		this.btnBroadcast = new System.Windows.Forms.Button();
		this.lblInstructions = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuHelp});
		this.mnuMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mnuMain.RightToLeft")));
		// 
		// mnuFile
		// 
		this.mnuFile.Enabled = ((bool)(resources.GetObject("mnuFile.Enabled")));
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuExit});
		this.mnuFile.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuFile.Shortcut")));
		this.mnuFile.ShowShortcut = ((bool)(resources.GetObject("mnuFile.ShowShortcut")));
		this.mnuFile.Text = resources.GetString("mnuFile.Text");
		this.mnuFile.Visible = ((bool)(resources.GetObject("mnuFile.Visible")));
		// 
		// mnuExit
		// 
		this.mnuExit.Enabled = ((bool)(resources.GetObject("mnuExit.Enabled")));
		this.mnuExit.Index = 0;
		this.mnuExit.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuExit.Shortcut")));
		this.mnuExit.ShowShortcut = ((bool)(resources.GetObject("mnuExit.ShowShortcut")));
		this.mnuExit.Text = resources.GetString("mnuExit.Text");
		this.mnuExit.Visible = ((bool)(resources.GetObject("mnuExit.Visible")));
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Enabled = ((bool)(resources.GetObject("mnuHelp.Enabled")));
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuAbout});
		this.mnuHelp.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuHelp.Shortcut")));
		this.mnuHelp.ShowShortcut = ((bool)(resources.GetObject("mnuHelp.ShowShortcut")));
		this.mnuHelp.Text = resources.GetString("mnuHelp.Text");
		this.mnuHelp.Visible = ((bool)(resources.GetObject("mnuHelp.Visible")));
		// 
		// mnuAbout
		// 
		this.mnuAbout.Enabled = ((bool)(resources.GetObject("mnuAbout.Enabled")));
		this.mnuAbout.Index = 0;
		this.mnuAbout.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuAbout.Shortcut")));
		this.mnuAbout.ShowShortcut = ((bool)(resources.GetObject("mnuAbout.ShowShortcut")));
		this.mnuAbout.Text = resources.GetString("mnuAbout.Text");
		this.mnuAbout.Visible = ((bool)(resources.GetObject("mnuAbout.Visible")));
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		// 
		// lstStatus
		// 
		this.lstStatus.AccessibleDescription = resources.GetString("lstStatus.AccessibleDescription");
		this.lstStatus.AccessibleName = resources.GetString("lstStatus.AccessibleName");
		this.lstStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lstStatus.Anchor")));
		this.lstStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lstStatus.BackgroundImage")));
		this.lstStatus.ColumnWidth = ((int)(resources.GetObject("lstStatus.ColumnWidth")));
		this.lstStatus.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lstStatus.Dock")));
		this.lstStatus.Enabled = ((bool)(resources.GetObject("lstStatus.Enabled")));
		this.lstStatus.Font = ((System.Drawing.Font)(resources.GetObject("lstStatus.Font")));
		this.lstStatus.HorizontalExtent = ((int)(resources.GetObject("lstStatus.HorizontalExtent")));
		this.lstStatus.HorizontalScrollbar = ((bool)(resources.GetObject("lstStatus.HorizontalScrollbar")));
		this.lstStatus.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lstStatus.ImeMode")));
		this.lstStatus.IntegralHeight = ((bool)(resources.GetObject("lstStatus.IntegralHeight")));
		this.lstStatus.ItemHeight = ((int)(resources.GetObject("lstStatus.ItemHeight")));
		this.lstStatus.Location = ((System.Drawing.Point)(resources.GetObject("lstStatus.Location")));
		this.lstStatus.Name = "lstStatus";
		this.lstStatus.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lstStatus.RightToLeft")));
		this.lstStatus.ScrollAlwaysVisible = ((bool)(resources.GetObject("lstStatus.ScrollAlwaysVisible")));
		this.lstStatus.Size = ((System.Drawing.Size)(resources.GetObject("lstStatus.Size")));
		this.lstStatus.TabIndex = ((int)(resources.GetObject("lstStatus.TabIndex")));
		this.lstStatus.Visible = ((bool)(resources.GetObject("lstStatus.Visible")));
		// 
		// txtBroadcast
		// 
		this.txtBroadcast.AccessibleDescription = resources.GetString("txtBroadcast.AccessibleDescription");
		this.txtBroadcast.AccessibleName = resources.GetString("txtBroadcast.AccessibleName");
		this.txtBroadcast.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtBroadcast.Anchor")));
		this.txtBroadcast.AutoSize = ((bool)(resources.GetObject("txtBroadcast.AutoSize")));
		this.txtBroadcast.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtBroadcast.BackgroundImage")));
		this.txtBroadcast.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtBroadcast.Dock")));
		this.txtBroadcast.Enabled = ((bool)(resources.GetObject("txtBroadcast.Enabled")));
		this.txtBroadcast.Font = ((System.Drawing.Font)(resources.GetObject("txtBroadcast.Font")));
		this.txtBroadcast.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtBroadcast.ImeMode")));
		this.txtBroadcast.Location = ((System.Drawing.Point)(resources.GetObject("txtBroadcast.Location")));
		this.txtBroadcast.MaxLength = ((int)(resources.GetObject("txtBroadcast.MaxLength")));
		this.txtBroadcast.Multiline = ((bool)(resources.GetObject("txtBroadcast.Multiline")));
		this.txtBroadcast.Name = "txtBroadcast";
		this.txtBroadcast.PasswordChar = ((char)(resources.GetObject("txtBroadcast.PasswordChar")));
		this.txtBroadcast.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtBroadcast.RightToLeft")));
		this.txtBroadcast.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtBroadcast.ScrollBars")));
		this.txtBroadcast.Size = ((System.Drawing.Size)(resources.GetObject("txtBroadcast.Size")));
		this.txtBroadcast.TabIndex = ((int)(resources.GetObject("txtBroadcast.TabIndex")));
		this.txtBroadcast.Text = resources.GetString("txtBroadcast.Text");
		this.txtBroadcast.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtBroadcast.TextAlign")));
		this.txtBroadcast.Visible = ((bool)(resources.GetObject("txtBroadcast.Visible")));
		this.txtBroadcast.WordWrap = ((bool)(resources.GetObject("txtBroadcast.WordWrap")));
		// 
		// btnBroadcast
		// 
		this.btnBroadcast.AccessibleDescription = resources.GetString("btnBroadcast.AccessibleDescription");
		this.btnBroadcast.AccessibleName = resources.GetString("btnBroadcast.AccessibleName");
		this.btnBroadcast.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnBroadcast.Anchor")));
		this.btnBroadcast.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBroadcast.BackgroundImage")));
		this.btnBroadcast.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnBroadcast.Dock")));
		this.btnBroadcast.Enabled = ((bool)(resources.GetObject("btnBroadcast.Enabled")));
		this.btnBroadcast.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnBroadcast.FlatStyle")));
		this.btnBroadcast.Font = ((System.Drawing.Font)(resources.GetObject("btnBroadcast.Font")));
		this.btnBroadcast.Image = ((System.Drawing.Image)(resources.GetObject("btnBroadcast.Image")));
		this.btnBroadcast.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBroadcast.ImageAlign")));
		this.btnBroadcast.ImageIndex = ((int)(resources.GetObject("btnBroadcast.ImageIndex")));
		this.btnBroadcast.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnBroadcast.ImeMode")));
		this.btnBroadcast.Location = ((System.Drawing.Point)(resources.GetObject("btnBroadcast.Location")));
		this.btnBroadcast.Name = "btnBroadcast";
		this.btnBroadcast.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnBroadcast.RightToLeft")));
		this.btnBroadcast.Size = ((System.Drawing.Size)(resources.GetObject("btnBroadcast.Size")));
		this.btnBroadcast.TabIndex = ((int)(resources.GetObject("btnBroadcast.TabIndex")));
		this.btnBroadcast.Text = resources.GetString("btnBroadcast.Text");
		this.btnBroadcast.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBroadcast.TextAlign")));
		this.btnBroadcast.Visible = ((bool)(resources.GetObject("btnBroadcast.Visible")));
		this.btnBroadcast.Click += new System.EventHandler(this.btnBroadcast_Click);
		// 
		// lblInstructions
		// 
		this.lblInstructions.AccessibleDescription = resources.GetString("lblInstructions.AccessibleDescription");
		this.lblInstructions.AccessibleName = resources.GetString("lblInstructions.AccessibleName");
		this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblInstructions.Anchor")));
		this.lblInstructions.AutoSize = ((bool)(resources.GetObject("lblInstructions.AutoSize")));
		this.lblInstructions.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblInstructions.Dock")));
		this.lblInstructions.Enabled = ((bool)(resources.GetObject("lblInstructions.Enabled")));
		this.lblInstructions.Font = ((System.Drawing.Font)(resources.GetObject("lblInstructions.Font")));
		this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
		this.lblInstructions.Image = ((System.Drawing.Image)(resources.GetObject("lblInstructions.Image")));
		this.lblInstructions.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions.ImageAlign")));
		this.lblInstructions.ImageIndex = ((int)(resources.GetObject("lblInstructions.ImageIndex")));
		this.lblInstructions.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblInstructions.ImeMode")));
		this.lblInstructions.Location = ((System.Drawing.Point)(resources.GetObject("lblInstructions.Location")));
		this.lblInstructions.Name = "lblInstructions";
		this.lblInstructions.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblInstructions.RightToLeft")));
		this.lblInstructions.Size = ((System.Drawing.Size)(resources.GetObject("lblInstructions.Size")));
		this.lblInstructions.TabIndex = ((int)(resources.GetObject("lblInstructions.TabIndex")));
		this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
		this.lblInstructions.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions.TextAlign")));
		this.lblInstructions.Visible = ((bool)(resources.GetObject("lblInstructions.Visible")));
		// 
		// Label1
		// 
		this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");
		this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");
		this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label1.Anchor")));
		this.Label1.AutoSize = ((bool)(resources.GetObject("Label1.AutoSize")));
		this.Label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label1.Dock")));
		this.Label1.Enabled = ((bool)(resources.GetObject("Label1.Enabled")));
		this.Label1.Font = ((System.Drawing.Font)(resources.GetObject("Label1.Font")));
		this.Label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
		this.Label1.Image = ((System.Drawing.Image)(resources.GetObject("Label1.Image")));
		this.Label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.ImageAlign")));
		this.Label1.ImageIndex = ((int)(resources.GetObject("Label1.ImageIndex")));
		this.Label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label1.ImeMode")));
		this.Label1.Location = ((System.Drawing.Point)(resources.GetObject("Label1.Location")));
		this.Label1.Name = "Label1";
		this.Label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label1.RightToLeft")));
		this.Label1.Size = ((System.Drawing.Size)(resources.GetObject("Label1.Size")));
		this.Label1.TabIndex = ((int)(resources.GetObject("Label1.TabIndex")));
		this.Label1.Text = resources.GetString("Label1.Text");
		this.Label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.TextAlign")));
		this.Label1.Visible = ((bool)(resources.GetObject("Label1.Visible")));
		// 
		// frmMain
		// 
		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
		this.AccessibleName = resources.GetString("$this.AccessibleName");
		this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
		this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
		this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
		this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
		this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
		this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.lblInstructions);
		this.Controls.Add(this.btnBroadcast);
		this.Controls.Add(this.txtBroadcast);
		this.Controls.Add(this.lstStatus);
		this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
		this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
		this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
		this.MaximizeBox = false;
		this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
		this.Menu = this.mnuMain;
		this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
		this.Name = "frmMain";
		this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
		this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
		this.Text = resources.GetString("$this.Text");
		this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
		this.Load += new System.EventHandler(this.frmMain_Load);
		this.ResumeLayout(false);

	}

#endregion

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

    const int PORT_NUM = 10000;
    private Hashtable clients = new Hashtable();
    private TcpListener listener;
    private Thread listenerThread;

    // This subroutine sends a message to all attached clients
    private void Broadcast(string strMessage)
	{
		UserConnection client;
        // All entries in the clients Hashtable are UserConnection so it is possible
        // to assign it safely.
        foreach(DictionaryEntry entry in clients)
		{
            client = (UserConnection) entry.Value;
            client.SendData(strMessage);
        }
    }

    // This subroutine sends the contents of the Broadcast textbox to all clients, if
    // it is not empty, and clears the textbox
    private void btnBroadcast_Click(object sender, System.EventArgs e) 
	{
        if (txtBroadcast.Text != "")
		{
            UpdateStatus("Broadcasting: " + txtBroadcast.Text);
            Broadcast("BROAD|" + txtBroadcast.Text);
            txtBroadcast.Text = string.Empty;
        }
    }

    // This subroutine checks to see if username already exists in the clients 
    // Hashtable.  if it does, send a REFUSE message, otherwise confirm with a JOIN.
    private void ConnectUser(string userName, UserConnection sender)
	{
		if (clients.Contains(userName))
		{
			ReplyToSender("REFUSE", sender);
		}
		else 
		{
			sender.Name = userName;
			UpdateStatus(userName + " has joined the chat.");
			clients.Add(userName, sender);
			// Send a JOIN to sender, and notify all other clients that sender joined
			ReplyToSender("JOIN", sender);
			SendToClients("CHAT|" + sender.Name + " has joined the chat.", sender);
		}
    }

    // This subroutine notifies other clients that sender left the chat, and removes
    // the name from the clients Hashtable
    private void DisconnectUser(UserConnection sender)
	{
        UpdateStatus(sender.Name + " has left the chat.");
        SendToClients("CHAT|" + sender.Name + " has left the chat.", sender);
        clients.Remove(sender.Name);
    }

    // This subroutine is used a background listener thread to allow reading incoming
    // messages without lagging the user interface.
    private void DoListen()
	{
        try {
            // Listen for new connections.
            listener = new TcpListener(System.Net.IPAddress.Any, PORT_NUM);
            listener.Start();

			do
			{
				// Create a new user connection using TcpClient returned by
				// TcpListener.AcceptTcpClient()
				UserConnection client = new UserConnection(listener.AcceptTcpClient());
				// Create an event handler to allow the UserConnection to communicate
				// with the window.
				client.LineReceived += new LineReceive(OnLineReceived);
				//AddHandler client.LineReceived, AddressOf OnLineReceived;
				UpdateStatus("new connection found: waiting for log-in");
			}while(true);
        } 
		catch{
        }
    }

    // When the window closes, stop the listener.
    private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e) //base.Closing;
	{
        listener.Stop();
    }

    // Start the background listener thread.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        listenerThread = new Thread(new ThreadStart(DoListen));
        listenerThread.Start();
        UpdateStatus("Listener started");
    }

    // Concatenate all the client names and send them to the user who requested user list
    private void ListUsers(UserConnection sender)
	{
        UserConnection client;       
        string strUserList;
        UpdateStatus("Sending " + sender.Name + " a list of users online.");
        strUserList = "LISTUSERS";
        // All entries in the clients Hashtable are UserConnection so it is possible
        // to assign it safely.

        foreach(DictionaryEntry entry in clients)
		{
            client = (UserConnection) entry.Value;
            strUserList = strUserList + "|" + client.Name;
        }

        // Send the list to the sender.
        ReplyToSender(strUserList, sender);
    }

    // This is the event handler for the UserConnection when it receives a full line.
    // Parse the cammand and parameters and take appropriate action.
    private void OnLineReceived(UserConnection sender, string data)
	{
        string[] dataArray;
        // Message parts are divided by "|"  Break the string into an array accordingly.
        dataArray = data.Split((char) 124);

        // dataArray(0) is the command.
        switch( dataArray[0])
		{
            case "CONNECT":
                ConnectUser(dataArray[1], sender);
				break;
            case "CHAT":
                SendChat(dataArray[1], sender);
				break;
            case "DISCONNECT":
                DisconnectUser(sender);
				break;
            case "REQUESTUSERS":
                ListUsers(sender);
				break;
            default: 
                UpdateStatus("Unknown message:" + data);
				break;
        }
    }

    // This subroutine sends a response to the sender.
    private void ReplyToSender(string strMessage, UserConnection sender)
	{
        sender.SendData(strMessage);
    }

    // Send a chat message to all clients except sender.
    private void SendChat(string message, UserConnection sender)
	{
        UpdateStatus(sender.Name + ": " + message);
        SendToClients("CHAT|" + sender.Name + ": " + message, sender);
    }

    // This subroutine sends a message to all attached clients except the sender.
    private void SendToClients(string strMessage, UserConnection sender)
	{
        UserConnection client;
        // All entries in the clients Hashtable are UserConnection so it is possible
        // to assign it safely.
        foreach(DictionaryEntry entry in clients)
		{
            client = (UserConnection) entry.Value;
            // Exclude the sender.
            if (client.Name != sender.Name)
			{
                client.SendData(strMessage);
            }
        }
    }

    // This subroutine adds line to the Status listbox
    private void UpdateStatus(string statusMessage)
	{
        lstStatus.Items.Add(statusMessage);
    }
}

