using System;
using MbUnit.Core.Framework;
using MbUnit.Framework;
using TestSubject;
using AssertionStint;

namespace TestOfStint
{
	[TestFixture]
	public class tWarehouse
	{
		[Test]
		public void tAdd()
		{
			IWarehouse WarehouseTestSubject = new StintedWarehouse();
			InventoryItem TestItem = new InventoryItem("TestItem");
			WarehouseTestSubject.Add(TestItem, 5);
		}

		//this will fail, but notice the stack trace, it should the offending code is in HasInventory
		[Test]
		public void tRemove()
		{
			IWarehouse WarehouseTestSubject = new StintedWarehouse();
			InventoryItem TestItem = new InventoryItem("TestItem");
			WarehouseTestSubject.Add(TestItem, 5);
			WarehouseTestSubject.Remove(TestItem, 5);
		}

		//this will fail because there is a bug in HasInventory
		[Test]
		public void tHasInventory()
		{
			IWarehouse WarehouseTestSubject = new StintedWarehouse();
			InventoryItem TestItem = new InventoryItem("TestItem");
			WarehouseTestSubject.Add(TestItem, 5);
			bool HasInventory = false;
			HasInventory = WarehouseTestSubject.HasInventory(TestItem, 5);
			Assert.IsTrue(HasInventory, "Expected the inventory to be reported there.");
		}
	}
}
