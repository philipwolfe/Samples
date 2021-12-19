using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace VehicleSampleBaseClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 
	public class Form1 : System.Windows.Forms.Form
	{

		private System.Windows.Forms.ComboBox cboVehicleType;
		private System.Windows.Forms.Button cmdComputeRange;
		private System.Windows.Forms.TextBox txtMilesPerGallon;
		private System.Windows.Forms.TextBox txtFuelCapacity;
		private System.Windows.Forms.Label lblComputedRange;
		private System.Windows.Forms.Label lblFuelCapacity;
		private System.Windows.Forms.Label lblMilesPerGallon;
		private System.Windows.Forms.CheckBox chxSailboat;
		private System.Windows.Forms.Label lblVehicleType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//this.cboVehicleType.SelectedIndex = 0;
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.cmdComputeRange = new System.Windows.Forms.Button();
			this.txtMilesPerGallon = new System.Windows.Forms.TextBox();
			this.txtFuelCapacity = new System.Windows.Forms.TextBox();
			this.lblMilesPerGallon = new System.Windows.Forms.Label();
			this.lblComputedRange = new System.Windows.Forms.Label();
			this.lblFuelCapacity = new System.Windows.Forms.Label();
			this.cboVehicleType = new System.Windows.Forms.ComboBox();
			this.chxSailboat = new System.Windows.Forms.CheckBox();
			this.lblVehicleType = new System.Windows.Forms.Label();
			this.cmdComputeRange.Location = new System.Drawing.Point(144, 192);
			this.cmdComputeRange.Size = new System.Drawing.Size(96, 23);
			this.cmdComputeRange.TabIndex = 8;
			this.cmdComputeRange.Text = "Compute Range";
			this.cmdComputeRange.Click += new System.EventHandler(this.cmdComputeRange_Click);
			this.txtMilesPerGallon.Location = new System.Drawing.Point(136, 88);
			this.txtMilesPerGallon.Size = new System.Drawing.Size(104, 20);
			this.txtMilesPerGallon.TabIndex = 5;
			this.txtMilesPerGallon.Text = "";
			this.txtFuelCapacity.Location = new System.Drawing.Point(136, 128);
			this.txtFuelCapacity.Size = new System.Drawing.Size(104, 20);
			this.txtFuelCapacity.TabIndex = 6;
			this.txtFuelCapacity.Text = "";
			this.lblMilesPerGallon.Location = new System.Drawing.Point(16, 88);
			this.lblMilesPerGallon.TabIndex = 1;
			this.lblMilesPerGallon.Text = "Miles Per Gallon:";
			this.lblComputedRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
			this.lblComputedRange.ForeColor = System.Drawing.Color.Red;
			this.lblComputedRange.Location = new System.Drawing.Point(8, 216);
			this.lblComputedRange.Size = new System.Drawing.Size(280, 56);
			this.lblComputedRange.TabIndex = 7;
			this.lblComputedRange.Text = "Click Compute Range To See Your Vehicle\'s Range";
			this.lblFuelCapacity.Location = new System.Drawing.Point(16, 136);
			this.lblFuelCapacity.TabIndex = 2;
			this.lblFuelCapacity.Text = "Fuel Capacity:";
			this.cboVehicleType.DropDownWidth = 104;
			this.cboVehicleType.Items.AddRange(new object[] {"Boat",
																"Car"});
			this.cboVehicleType.Location = new System.Drawing.Point(136, 40);
			this.cboVehicleType.Size = new System.Drawing.Size(104, 21);
			this.cboVehicleType.TabIndex = 3;
			this.cboVehicleType.SelectedIndexChanged += new System.EventHandler(this.cboVehicleType_SelectedIndexChanged);
			this.chxSailboat.Location = new System.Drawing.Point(144, 160);
			this.chxSailboat.TabIndex = 4;
			this.chxSailboat.Text = "Sailboat";
			this.lblVehicleType.Location = new System.Drawing.Point(16, 40);
			this.lblVehicleType.TabIndex = 0;
			this.lblVehicleType.Text = "Vehicle Type:";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdComputeRange,
																		  this.lblComputedRange,
																		  this.txtFuelCapacity,
																		  this.txtMilesPerGallon,
																		  this.chxSailboat,
																		  this.cboVehicleType,
																		  this.lblFuelCapacity,
																		  this.lblMilesPerGallon,
																		  this.lblVehicleType});
			this.Text = "frmMain";

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
		private void cboVehicleType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Enable/Disable the Sailboat checkbox depending on the VehicleType
        
			if (this.cboVehicleType.Text == "Boat")
			{
				this.chxSailboat.Enabled = true;
			}
			else
			{
				this.chxSailboat.Enabled = false;
			}

		}

		private void cmdComputeRange_Click(object sender, System.EventArgs e)
		{
			int range;

			//Create the object type based on the type of vehicle specified.
			//We are late binding the objVehicle object, so we can create it as either a
			//car or a boat.
			if (this.cboVehicleType.Text == "Boat")
			{			
				if (this.chxSailboat.Checked) 
				{
					VehicleDemo.SailBoat sailboat = new VehicleDemo.SailBoat();
					//Set the FuelCapacity and MilesPerGallon properties
					//These calls are the same regardless of the type of vehicle
					sailboat.FuelCapacity = System.Convert.ToInt16(this.txtFuelCapacity.Text);
					sailboat.MilesPerGallon = System.Convert.ToInt16(this.txtMilesPerGallon.Text);
					//Call the ComputeRange function.  Note that we will execute different implementations
					//of this method depending on the vehicle type.
					range = sailboat.ComputeRange();
				}
				else 
				{
					VehicleDemo.Boat boat = new VehicleDemo.Boat();			
					//Set the FuelCapacity and MilesPerGallon properties
					//These calls are the same regardless of the type of vehicle
					boat.FuelCapacity = System.Convert.ToInt16(this.txtFuelCapacity.Text);
					boat.MilesPerGallon = System.Convert.ToInt16(this.txtMilesPerGallon.Text);
					//Call the ComputeRange function.  Note that we will execute different implementations
					//of this method depending on the vehicle type.
					range = boat.ComputeRange();
				}
			}
			else
			{
				VehicleDemo.Car car = new VehicleDemo.Car();			
				//Set the FuelCapacity and MilesPerGallon properties
				//These calls are the same regardless of the type of vehicle
				car.FuelCapacity = System.Convert.ToInt16(this.txtFuelCapacity.Text);
				car.MilesPerGallon = System.Convert.ToInt16(this.txtMilesPerGallon.Text);
				//Call the ComputeRange function.  Note that we will execute different implementations
				//of this method depending on the vehicle type.
				range = car.ComputeRange();
			}
      
			//Display the computed range
			this.lblComputedRange.Text = "Your Vehicle's Range is: " + System.Convert.ToString(range);

		}
	
	}
}
