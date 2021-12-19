using System;

public class Order
{
	protected Int64 orderId;
	protected string itemDescription;
	
	public Int64 OrderId{
		get{
			return this.orderId;
		}
		set{
			this.orderId = value;
		}
	}

	public string ItemDescription{
		get{
			return this.itemDescription;
		}
		set{
			this.itemDescription= value;
		}
	}	
}