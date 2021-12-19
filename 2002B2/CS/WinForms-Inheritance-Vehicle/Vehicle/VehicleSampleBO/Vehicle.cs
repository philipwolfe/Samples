using System;

namespace VehicleDemo
{
	/// <summary>
	/// Summary description for Vehicle.
	/// </summary>
	public abstract class  Vehicle
	{
		//Property holders
		private int milesPerGallon;
		private int fuelCapacity;
		
		
		public int FuelCapacity 
		{
			get 
			{
				return fuelCapacity;
			}
			set 
			{
				fuelCapacity = value;
			}
		}
   
		public int MilesPerGallon 
		{
			get 
			{
				return milesPerGallon;
			}
			set 
			{
				milesPerGallon = value;
			}
		}
       
		//The ComputeRange function is maked as Overridable which means that classes which 
		//inherit the Vehicle class can override the implementation of this function.
		public virtual int ComputeRange()
		{
			return milesPerGallon * fuelCapacity;

		}
	}
}
