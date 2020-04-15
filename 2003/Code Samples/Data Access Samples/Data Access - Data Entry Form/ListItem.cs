
//  This class is used to store the text and primary key of a record
//  that you want to list in list box.
using System;


public class ListItem
{

    private string mValue;    //Stores a named description of the item;

    private int mID;      //Stores a primary key to the record;

    public ListItem(string strValue , int intID )
	{

        mValue = strValue;

        mID = intID;

    }

    public ListItem() 
	{

        mValue = string.Empty;
        mID = 0;
    }

    public int ID
	{

        get 
		{

            return mID;
        }

        set
		{
            mID = value;
        }

    }

    public string Value 
	{

        get 
		{

            return mValue;

        }

        set {

            mValue = value;

        }

    }

    // When a list box displays an item in its collection
    // it calls the Tostring method to get the value to
    // display so we will need to override this method
    // so our class will return mValue.

    public override string ToString()
	{

        return mValue;

    }

}

