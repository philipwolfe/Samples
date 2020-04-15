using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

/*
 *	This class is designed to emulate the VB
 *	InputBox dialog
 */
public class InputDialog : System.Windows.Forms.Form
{
	//	These need to be available to the other classes
	//	for read-write access.
	internal System.Windows.Forms.Label lblText;
	internal System.Windows.Forms.TextBox txtInput;
	
	private System.Windows.Forms.Button btnOK;
	private System.Windows.Forms.Button btnCancel;
	private System.ComponentModel.Container components = null;

	public InputDialog()
	{
		InitializeComponent();
	}

	public InputDialog(string myTitle, string myLabel, string myText)
	{
		InitializeComponent();
		this.Text = myTitle;
		lblText.Text = myLabel;
		txtInput.Text = myText;
	}


	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	protected override void Dispose( bool disposing )
	{
		if( disposing )
		{
			if(components != null)
			{
				components.Dispose();
			}
		}
		base.Dispose( disposing );
	}

	#region Windows Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		this.txtInput = new System.Windows.Forms.TextBox();
		this.btnOK = new System.Windows.Forms.Button();
		this.lblText = new System.Windows.Forms.Label();
		this.btnCancel = new System.Windows.Forms.Button();
		this.SuspendLayout();
		// 
		// txtInput
		// 
		this.txtInput.Location = new System.Drawing.Point(8, 96);
		this.txtInput.Name = "txtInput";
		this.txtInput.Size = new System.Drawing.Size(272, 20);
		this.txtInput.TabIndex = 1;
		this.txtInput.Text = "";
		// 
		// btnOK
		// 
		this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOK.Location = new System.Drawing.Point(232, 8);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new System.Drawing.Size(56, 24);
		this.btnOK.TabIndex = 2;
		this.btnOK.Text = "OK";
		// 
		// lblText
		// 
		this.lblText.Location = new System.Drawing.Point(7, 8);
		this.lblText.Name = "lblText";
		this.lblText.Size = new System.Drawing.Size(217, 32);
		this.lblText.TabIndex = 0;
		// 
		// btnCancel
		// 
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(232, 48);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(56, 23);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "Cancel";
		// 
		// InputDialog
		// 
		this.AcceptButton = this.btnOK;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(298, 128);
		this.ControlBox = false;
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.lblText);
		this.Controls.Add(this.txtInput);
		this.Controls.Add(this.btnOK);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "InputDialog";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Input Dialog";
		this.ResumeLayout(false);

	}
	#endregion

	public static string ShowInputBox(string myTitle, string myLabel, string myText)
	{
		InputDialog box = new InputDialog(myTitle,myLabel,myText);
		box.ShowDialog();
		return box.txtInput.Text;
	} 

}
