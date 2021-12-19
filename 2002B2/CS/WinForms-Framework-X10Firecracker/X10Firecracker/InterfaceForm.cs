using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace X10FirecrackerInterface
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OffSwitch;
		private System.Windows.Forms.Label HouseCodeLabel1;
		private System.Windows.Forms.Label HouseCodeLabel2;
		private System.Windows.Forms.Label CommPortLabel1;
		private System.Windows.Forms.ListBox DeviceCodeList;
		private System.Windows.Forms.Button DimmerSwitch;
		private System.Windows.Forms.Label CommPortLabel2;
		private System.Windows.Forms.Button BrighterSwitch;
		private System.Windows.Forms.ListBox HouseCodeList;
		private System.Windows.Forms.Label DeviceCodeLabel1;
		private System.Windows.Forms.ListBox CommPortList;
		private System.Windows.Forms.Button OnSwitch;
		private System.Windows.Forms.Label DeviceCodeLabel2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		private X10Firecracker mFirecracker  = new X10Firecracker();

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			CommPortList.SelectedIndex = 0;
			HouseCodeList.SelectedIndex = 0;
			DeviceCodeList.SelectedIndex = 0;

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.OffSwitch = new System.Windows.Forms.Button();
			this.HouseCodeLabel1 = new System.Windows.Forms.Label();
			this.HouseCodeLabel2 = new System.Windows.Forms.Label();
			this.CommPortLabel1 = new System.Windows.Forms.Label();
			this.DeviceCodeList = new System.Windows.Forms.ListBox();
			this.DimmerSwitch = new System.Windows.Forms.Button();
			this.CommPortLabel2 = new System.Windows.Forms.Label();
			this.BrighterSwitch = new System.Windows.Forms.Button();
			this.HouseCodeList = new System.Windows.Forms.ListBox();
			this.DeviceCodeLabel1 = new System.Windows.Forms.Label();
			this.CommPortList = new System.Windows.Forms.ListBox();
			this.OnSwitch = new System.Windows.Forms.Button();
			this.DeviceCodeLabel2 = new System.Windows.Forms.Label();
			this.OffSwitch.CausesValidation = false;
			this.OffSwitch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.OffSwitch.Location = new System.Drawing.Point(164, 72);
			this.OffSwitch.Size = new System.Drawing.Size(68, 23);
			this.OffSwitch.TabIndex = 10;
			this.OffSwitch.Text = "O&ff";
			this.OffSwitch.Click += new System.EventHandler(this.OffSwitch_Click);
			this.HouseCodeLabel1.AutoSize = true;
			this.HouseCodeLabel1.Location = new System.Drawing.Point(60, 8);
			this.HouseCodeLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HouseCodeLabel1.Size = new System.Drawing.Size(37, 13);
			this.HouseCodeLabel1.TabIndex = 3;
			this.HouseCodeLabel1.Text = "&House";
			this.HouseCodeLabel2.AutoSize = true;
			this.HouseCodeLabel2.Location = new System.Drawing.Point(60, 24);
			this.HouseCodeLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HouseCodeLabel2.Size = new System.Drawing.Size(34, 13);
			this.HouseCodeLabel2.TabIndex = 4;
			this.HouseCodeLabel2.Text = "Code:";
			this.CommPortLabel1.AutoSize = true;
			this.CommPortLabel1.Location = new System.Drawing.Point(8, 8);
			this.CommPortLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CommPortLabel1.Size = new System.Drawing.Size(41, 13);
			this.CommPortLabel1.TabIndex = 0;
			this.CommPortLabel1.Text = "&Comm.";
			this.DeviceCodeList.CausesValidation = false;
			this.DeviceCodeList.IntegralHeight = false;
			this.DeviceCodeList.Items.AddRange(new object[] {"1",
																"2",
																"3",
																"4",
																"5",
																"6",
																"7",
																"8",
																"9",
																"10",
																"11",
																"12",
																"13",
																"14",
																"15",
																"16"});
			this.DeviceCodeList.Location = new System.Drawing.Point(112, 40);
			this.DeviceCodeList.Size = new System.Drawing.Size(44, 214);
			this.DeviceCodeList.TabIndex = 8;
			this.DimmerSwitch.CausesValidation = false;
			this.DimmerSwitch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.DimmerSwitch.Location = new System.Drawing.Point(164, 144);
			this.DimmerSwitch.Size = new System.Drawing.Size(68, 23);
			this.DimmerSwitch.TabIndex = 12;
			this.DimmerSwitch.Text = "&Dimmer";
			this.DimmerSwitch.Click += new System.EventHandler(this.DimmerSwitch_Click);
			this.CommPortLabel2.AutoSize = true;
			this.CommPortLabel2.Location = new System.Drawing.Point(8, 24);
			this.CommPortLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CommPortLabel2.Size = new System.Drawing.Size(28, 13);
			this.CommPortLabel2.TabIndex = 1;
			this.CommPortLabel2.Text = "Port:";
			this.BrighterSwitch.CausesValidation = false;
			this.BrighterSwitch.Location = new System.Drawing.Point(164, 112);
			this.BrighterSwitch.Size = new System.Drawing.Size(68, 23);
			this.BrighterSwitch.TabIndex = 11;
			this.BrighterSwitch.Text = "&Brighter";
			this.BrighterSwitch.Click += new System.EventHandler(this.BrighterSwitch_Click);
			this.HouseCodeList.CausesValidation = false;
			this.HouseCodeList.IntegralHeight = false;
			this.HouseCodeList.Items.AddRange(new object[] {"A",
															   "B",
															   "C",
															   "D",
															   "E",
															   "F",
															   "G",
															   "H",
															   "I",
															   "J",
															   "K",
															   "L",
															   "M",
															   "N",
															   "O",
															   "P"});
			this.HouseCodeList.Location = new System.Drawing.Point(60, 40);
			this.HouseCodeList.Size = new System.Drawing.Size(44, 214);
			this.HouseCodeList.TabIndex = 5;
			this.DeviceCodeLabel1.AutoSize = true;
			this.DeviceCodeLabel1.Location = new System.Drawing.Point(112, 8);
			this.DeviceCodeLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DeviceCodeLabel1.Size = new System.Drawing.Size(24, 13);
			this.DeviceCodeLabel1.TabIndex = 6;
			this.DeviceCodeLabel1.Text = "&Unit";
			this.CommPortList.CausesValidation = false;
			this.CommPortList.IntegralHeight = false;
			this.CommPortList.Items.AddRange(new object[] {"1",
															   "2",
															   "3",
															   "4",
															   "5",
															   "6",
															   "7",
															   "8"});
			this.CommPortList.Location = new System.Drawing.Point(8, 40);
			this.CommPortList.Size = new System.Drawing.Size(44, 214);
			this.CommPortList.TabIndex = 2;
			this.CommPortList.SelectedIndexChanged += new System.EventHandler(this.CommPortList_SelectedIndexChanged);
			this.OnSwitch.CausesValidation = false;
			this.OnSwitch.Location = new System.Drawing.Point(164, 40);
			this.OnSwitch.Size = new System.Drawing.Size(68, 23);
			this.OnSwitch.TabIndex = 9;
			this.OnSwitch.Text = "&On";
			this.OnSwitch.Click += new System.EventHandler(this.OnSwitch_Click);
			this.DeviceCodeLabel2.AutoSize = true;
			this.DeviceCodeLabel2.Location = new System.Drawing.Point(112, 24);
			this.DeviceCodeLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DeviceCodeLabel2.Size = new System.Drawing.Size(19, 13);
			this.DeviceCodeLabel2.TabIndex = 7;
			this.DeviceCodeLabel2.Text = "ID:";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(238, 263);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.DeviceCodeList,
																		  this.DeviceCodeLabel2,
																		  this.OnSwitch,
																		  this.CommPortList,
																		  this.DeviceCodeLabel1,
																		  this.HouseCodeList,
																		  this.BrighterSwitch,
																		  this.CommPortLabel2,
																		  this.DimmerSwitch,
																		  this.CommPortLabel1,
																		  this.HouseCodeLabel2,
																		  this.HouseCodeLabel1,
																		  this.OffSwitch});
			this.Text = "X10 Firecracker Interface";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void OnSwitch_Click(object sender, System.EventArgs e)
		{
			if (!mFirecracker.SendCommand(Convert.ToChar(HouseCodeList.SelectedItem), Convert.ToInt16(DeviceCodeList.SelectedItem), X10Firecracker.Commands.TurnOn))
			{
				System.Windows.Forms.MessageBox.Show("The on command could not be sent to the specified communications port.", "Command Failed");
			}
		}

		private void OffSwitch_Click(object sender, System.EventArgs e)
		{
			if (!mFirecracker.SendCommand(Convert.ToChar(HouseCodeList.SelectedItem), Convert.ToInt16(DeviceCodeList.SelectedItem), X10Firecracker.Commands.TurnOff))
			{
				System.Windows.Forms.MessageBox.Show("The off command could not be sent to the specified communications port.","Command Failed");
			}
		}

		private void BrighterSwitch_Click(object sender, System.EventArgs e)
		{
			if (!mFirecracker.SendCommand(Convert.ToChar(HouseCodeList.SelectedItem), Convert.ToInt16(DeviceCodeList.SelectedItem), X10Firecracker.Commands.MakeBrighter))
			{
				System.Windows.Forms.MessageBox.Show("The brighten command could not be sent to the specified communications port.", "Command Failed");
			}
		}

		private void DimmerSwitch_Click(object sender, System.EventArgs e)
		{	
			if (!mFirecracker.SendCommand(Convert.ToChar(HouseCodeList.SelectedItem),Convert.ToInt16(DeviceCodeList.SelectedItem), X10Firecracker.Commands.MakeDimmer))
			{
				System.Windows.Forms.MessageBox.Show("The dim command could not be sent to the specified communications port.", "Command Failed");
			}
		}

		private void CommPortList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			mFirecracker.CommPort = Convert.ToInt16(CommPortList.SelectedItem);
		}

	
	}
}
