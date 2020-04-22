using System;

namespace TestSubject
{
	/// <summary>
	/// Summary description for Order.
	/// </summary>
	public class Order
	{
		
		private bool _IsFilled;
		private int _Amount;
		private InventoryItem _Item;
		
		public int Amount {
			get
			{
				return _Amount;
			}
			set
			{
				_Amount = value;
			}
		}

		public InventoryItem Item {
			get
			{
				return _Item;
			}
			set
			{
				_Item = value;
			}
		}

		public bool IsFilled {
			get
			{
				return _IsFilled;
			}
			set
			{
				_IsFilled = value;
			}
		}

		public Order(InventoryItem inventoryItem, int amount)
		{
			this.Item = inventoryItem;
			this.Amount = amount;
		}

		public void Fill(IWarehouse warehouse)
		{
			bool IsAvalible = false;
			IsAvalible = warehouse.HasInventory(this.Item, this.Amount);
			if (IsAvalible)
			{
				warehouse.Remove(this.Item, this.Amount);
				this.IsFilled = true;
			}
		}

	}
}
