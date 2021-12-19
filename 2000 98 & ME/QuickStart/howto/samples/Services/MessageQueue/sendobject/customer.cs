using System;

public class Customer
{
	protected string lastName;
	protected string firstName;
	
	public string LastName{
		get{
			return this.lastName;
		}
		set{
			this.lastName = value;
		}
	}

	public string FirstName{
		get{
			return this.firstName;
		}
		set{
			this.firstName = value;
		}
	}	

	public string FullName{
		get{
			return (FirstName + LastName);
		}
	}
}