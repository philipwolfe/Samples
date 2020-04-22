using System;
using MbUnit.Core.Framework;
using MbUnit.Framework;
using TestSubject;

namespace State_Based
{
	
	[TestFixture]
	public class tOrder
	{
		
		[Test]
		public void tFillWithInventory()
		{
			InventoryItem TestItem = new InventoryItem("TestItem");
			IWarehouse warehouse = new Warehouse();
			warehouse.Add(TestItem, 5);
			Order TestOrder = new Order(TestItem, 5);
			TestOrder.Fill(warehouse);
			Assert.IsTrue(TestOrder.IsFilled);
		}

		[Test]
		public void tFillWithOutInventory()
		{
			InventoryItem TestItem = new InventoryItem("TestItem");
			IWarehouse warehouse = new Warehouse();
			warehouse.Add(TestItem, 2);
			Order TestOrder = new Order(TestItem, 5);
			TestOrder.Fill(warehouse);
			Assert.IsFalse(TestOrder.IsFilled);
		}
	}
}
