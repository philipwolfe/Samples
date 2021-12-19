//===========================================================================
//	File:		MessageForm.cs
//
//	Summary:	The form that displays the contents of an e-mail message.
//
//---------------------------------------------------------------------------
//	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
//===========================================================================
using System.ComponentModel;
using System.Diagnostics;
using System;
using System.WinForms;
using System.Drawing;

public class MessageForm : Form
{
	private Container components;
	private Label labelSubject;
	private Label labelSent;
	private Label labelCC;
	private Label labelTo;
	private Label labelFrom;
	private RichTextBox richTextBox1;

	private string subject;
	private string sent;
	private string cc;
	private string to;
	private string from;
	private string text;
        
	public MessageForm(string subject, string sent, string cc, string to, string from, string text) 
	{
		this.subject = subject;
		this.sent = sent;
		this.cc = cc;
		this.to = to;
		this.from = from;
		this.text = text;

		// Required for WFC Form Designer support
		InitializeComponent();
	}

	//
	// MessageForm overrides dispose so it can clean up the component list.
	//
	public override void Dispose() 
	{
		base.Dispose();
		components.Dispose();
	}

	private void InitializeComponent()
	{
		this.components = new Container();
		this.labelFrom = new Label();
		this.richTextBox1 = new RichTextBox();
		this.labelSubject = new Label();
		this.labelCC = new Label();
		this.labelTo = new Label();
		this.labelSent = new Label();

		this.AutoScaleBaseSize = new Size(5, 13);
		this.Text = subject;
		this.ClientSize = new Size(600, 517);
		
		labelFrom.Location = new Point(8, 8);
		labelFrom.Text = "From: " + from;
		labelFrom.Width = this.ClientSize.Width - 16;
		labelFrom.Height = 16;
		labelFrom.TabIndex = 0;
		labelFrom.UseMnemonic = false;
		
		richTextBox1.Text = text;
		richTextBox1.Location = new Point(8, 128);
		richTextBox1.Width = this.ClientSize.Width - 16;
		richTextBox1.Height = this.ClientSize.Height - richTextBox1.Top - 8;
		richTextBox1.TabIndex = 1;
		
		labelSubject.Location = new Point(8, 104);
		labelSubject.Text = "Subject: " + subject;
		labelSubject.Width = this.ClientSize.Width - 16;
		labelSubject.Height = 16;
		labelSubject.BorderStyle = System.WinForms.BorderStyle.FixedSingle;
		labelSubject.ForeColor = Color.Olive;
		labelSubject.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.World);
		labelSubject.TabIndex = 5;
		labelSubject.BackColor = Color.Gold;
		labelSubject.UseMnemonic = false;
		
		labelCC.Location = new Point(8, 56);
		labelCC.Text = "Cc: " + cc;
		labelCC.Width = this.ClientSize.Width - 16;
		labelCC.Height = 16;
		labelCC.TabIndex = 3;
		labelCC.UseMnemonic = false;

		labelTo.Location = new Point(8, 32);
		labelTo.Text = "To: " + to;
		labelTo.Width = this.ClientSize.Width - 16;
		labelTo.Height = 16;
		labelTo.TabIndex = 2;
		labelTo.UseMnemonic = false;

		labelSent.Location = new Point(8, 80);
		labelSent.Text = "Sent: " + sent;
		labelSent.Width = this.ClientSize.Width - 16;
		labelSent.Height = 16;
		labelSent.TabIndex = 4;
		labelSent.UseMnemonic = false;

		this.Controls.Add(labelSubject);
		this.Controls.Add(labelSent);
		this.Controls.Add(labelCC);
		this.Controls.Add(labelTo);
		this.Controls.Add(labelFrom);
		this.Controls.Add(richTextBox1);

		this.AddOnResize(new System.EventHandler(MessageForm_Resize));
	}

	private void MessageForm_Resize(object sender, System.EventArgs e)
	{
		labelSubject.Width = this.ClientSize.Width - 16;
		labelSent.Width = this.ClientSize.Width - 16;
		labelCC.Width = this.ClientSize.Width - 16;
		labelTo.Width = this.ClientSize.Width - 16;
		labelFrom.Width = this.ClientSize.Width - 16;
		richTextBox1.Width = this.ClientSize.Width - 16;
		richTextBox1.Height = this.ClientSize.Height - richTextBox1.Top - 8;
	}
}