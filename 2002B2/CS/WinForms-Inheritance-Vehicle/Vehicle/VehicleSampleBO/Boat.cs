using System;

namespace VehicleDemo
{
	//For boats we need to override the implementation of the ComputeRange function
	
	/// <summary>
	/// Summary description for Boat.
	/// </summary>
	public class Boat : Vehicle
	{
		//We need to override the ComputeRange function to add support for boats
		//For boats we want to double the couputed range.  We will call the
		//ComputeRange function on MyBase which is the Vehicle class
		public override int ComputeRange()
		{
			//This is a boat so we double the calculated range
			return base.ComputeRange() * 2;
		}
			public Boat()
			{
				//
				// TODO: Add constructor logic here
				//
			}
	}
}
