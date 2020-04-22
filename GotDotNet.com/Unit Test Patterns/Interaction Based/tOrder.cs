using System;
using NMock;
using NMock.Constraints;
using NMock.Dynamic;
using MbUnit.Core.Framework;
using MbUnit.Framework;
using TestSubject;

namespace InteractionBased.Tests
{
	[TestFixture]
	public class tOrder
	{
	
		[Test]
		public void tFillWithInventory()
		{
			Mock MockWarehouse = new DynamicMock(typeof(IWarehouse));
			InventoryItem OrderItem = new InventoryItem("TestItem");
			int OrderAmount = 2;
			Order OrderTestSubject = new Order(OrderItem, OrderAmount);
			
			MockWarehouse.ExpectAndReturn("HasInventory", true, new IsEqual(OrderItem), new IsEqual(OrderAmount));
			MockWarehouse.Expect("Remove", new IsEqual(OrderItem), new IsEqual(OrderAmount));

			OrderTestSubject.Fill((IWarehouse)MockWarehouse.MockInstance);

			MockWarehouse.Verify();
			Assert.IsTrue(OrderTestSubject.IsFilled);
		}

		[Test]
		public void tFillWithOutInventory()
		{
			Mock MockWarehouse = new DynamicMock(typeof(IWarehouse));
			InventoryItem OrderItem = new InventoryItem("TestItem");
			int OrderAmount = 2;
			Order OrderTestSubject = new Order(OrderItem, OrderAmount);
			
			MockWarehouse.ExpectAndReturn("HasInventory", false, new IsEqual(OrderItem), new IsEqual(OrderAmount));
			MockWarehouse.ExpectNoCall("Remove", typeof(InventoryItem), typeof(int));

			OrderTestSubject.Fill((IWarehouse)MockWarehouse.MockInstance);

			MockWarehouse.Verify();
			Assert.IsFalse(OrderTestSubject.IsFilled);
		}
	}

}
