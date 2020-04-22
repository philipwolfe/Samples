using System;
using System.Collections;
using TestSubject;

namespace AssertionStint
{
	/// <summary>
	/// Summary description for Warehouse.
	/// </summary>
	public class StintedWarehouse : IWarehouse
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

		public bool HasInventory(InventoryItem inventoryItem, int amount)
		{
			bool Avalible = false;
			if (this.Inventory.Contains(inventoryItem))
			{
				//see the bug: it should be greater than or equal to not just greater than
				Avalible = (int) this.Inventory[inventoryItem] > amount;
				System.Diagnostics.Debug.Assert(Avalible == (int) this.Inventory[inventoryItem] >= amount);
			}
			return Avalible;
		}

		public void Remove(InventoryItem inventoryItem, int amount)
		{
			if (this.HasInventory(inventoryItem, amount)) 
			{
				if ((int) this.Inventory[inventoryItem] == amount)
				{
					this.Inventory.Remove(inventoryItem);
					System.Diagnostics.Debug.Assert(this.Inventory.Contains(inventoryItem) == false, "There should be not inventory for it item.");
				}
				else
				{
					int PreviousInventoryAmount = (int) this.Inventory[inventoryItem];
					this.Inventory[inventoryItem] = (int) this.Inventory[inventoryItem] - amount;
					System.Diagnostics.Debug.Assert((int) this.Inventory[inventoryItem] == PreviousInventoryAmount - amount, "There should be less than the previous inventory amount.");
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
				System.Diagnostics.Debug.Assert((int) this.Inventory[inventoryItem] > amount, "The inventory should be more than the amount that was just added.");
			}
			else
			{
				this.Inventory[inventoryItem] = amount;
				System.Diagnostics.Debug.Assert((int) this.Inventory[inventoryItem] == amount, "The inventory should be the same as what was just added.");
			}
		}
	}
}
