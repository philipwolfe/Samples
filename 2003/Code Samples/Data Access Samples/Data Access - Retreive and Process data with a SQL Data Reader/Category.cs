// The Category class is a custom type that is used for databinding to a ComboBox.
// Notice the use of public properties instead of merely public fields. You might
// think you could use the following construct:
//
//   public class Category
//       public ID int
//       public Name string
//       void new(intID int, strName string)
//           ID = intID
//           Name = strName
//       }
//   }
//
// This will, however, throw a runtime InvalidArgumentException stating that it 
// can! bind to the new DisplayMember. The DATA_TYPE_HERE does not have to be 
// ReadOnly.

class Category
{

    int _ID;

    string _Name;

    public Category(int intID, string strName)
	{
        _ID = intID;
        _Name = strName;
    }

    public int ID
	{

        get 
		{
            return _ID;
        }

    }

    public string Name
	{

        get 
		{
            return _Name;
        }

    }

}

