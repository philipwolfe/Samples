using System;
using System.Collections;

namespace TestSubject
{
	/// <summary>
	/// Summary description for Warehouse.
	/// </summary>
	public class Warehouse : IWarehouse
	{

		private Hashtable _Inventory = new Hashtable();

		private Hashtable Inventory {
			get 
			{
				return _Inventory;
			}
			set 
			{
				_Inventory = value;
			}
		}
		
		#region IWarehouse Members

		public bool HasInventory(InventoryItem inventoryItem, int amount)
		{
			if (this.Inventory.Contains(inventoryItem))
			{
				return (int) this.Inventory[inventoryItem] >= amount;
			}
			return false;
		}

		public void Remove(InventoryItem inventoryItem, int amount)
		{
			if (this.HasInventory(inventoryItem, amount)) 
			{
				if ((int) this.Inventory[inventoryItem] == amount)
				{
					this.Inventory.Remove(inventoryItem);
				}
				else
				{
					this.Inventory[inventoryItem] = (int) this.Inventory[inventoryItem] - amount;
				}
			}
			else
			{
				throw new InvalidOperationException("The warehouse does not have that item or enough of it");
			}
		}

		public void Add(InventoryItem inventoryItem, int amount)
		{
			if (this.HasInventory(inventoryItem, amount)) 
			{
				this.Inventory[inventoryItem] = (int) this.Inventory[inventoryItem] + amount;
			}
			else
			{
				this.Inventory[inventoryItem] = amount;
			}
		}

		#endregion
	}
}
