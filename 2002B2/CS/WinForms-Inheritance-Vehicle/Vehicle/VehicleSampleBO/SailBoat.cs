using System;

namespace VehicleDemo
{
	/// <summary>
	/// Summary description for SailBoat.
	/// </summary>
	public class SailBoat : Vehicle
	{
		//We need to override the ComputeRange function to add support for sailboats
		//For sailboats we want to triple the couputed range.  We will call the
		//ComputeRange function on MyBase which is the Vehicle class
		public override int ComputeRange()
		{
			//This is a sailboat so we triple the calculated range
			return base.ComputeRange() * 3;
		}

		public SailBoat()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
