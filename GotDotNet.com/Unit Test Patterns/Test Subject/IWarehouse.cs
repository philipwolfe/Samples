using System;

namespace TestSubject
{
	/// <summary>
	/// Summary description for Warehouse.
	/// </summary>
	public interface IWarehouse
	{
		bool HasInventory(InventoryItem inventoryItem, int amount);

		void Remove(InventoryItem inventoryItem, int amount);
		void Add(InventoryItem inventoryItem, int amount);
	}
}
