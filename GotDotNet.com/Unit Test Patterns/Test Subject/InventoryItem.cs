using System;

namespace TestSubject
{
	/// <summary>
	/// Summary description for InventoryItem.
	/// </summary>
	public class InventoryItem :IComparable
	{
		private string _Name;
		
		public string Name {
			get 
			{
				return _Name;
			}
			set 
			{
				_Name = value;
			}
		}

		public InventoryItem(){}

		public InventoryItem(string Name)
		{
			this.Name = Name;
		}

		public override bool Equals(object obj)
		{
			InventoryItem EqualTo = (InventoryItem) obj;
			return this.Name.Equals(EqualTo.Name);
		}


		public override int GetHashCode()
		{
			return this.Name.GetHashCode ();
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			InventoryItem CompareTo = (InventoryItem) obj;
			return this.Name.CompareTo(CompareTo.Name);
		}

		#endregion
	}
}
