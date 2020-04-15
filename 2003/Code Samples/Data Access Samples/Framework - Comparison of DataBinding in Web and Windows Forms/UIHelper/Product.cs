//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// The Product class is a custom type that is used for databinding to a ComboBox.
// Notice the use of public properties instead of merely public fields. You might
// think you could use the following construct:
//
//   public class Product
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

public class Product
{
    int _ID;

    string _Name;

    public Product(int intID ,string strName )
	{
        _ID = intID;
        _Name = strName;
    }

    public int ID
	{
        get {
            return _ID;
        }
    }

    public string Name
	{
        get {
            return _Name;
        }
    }

}

