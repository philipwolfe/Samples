// This is the main project file for VC++ application project 
// generated using an Application Wizard.
//

#include <stdlib.h>

#using <mscorlib.dll>

using namespace System;

__gc class Item
{
public:
	Item()
	{
		m_dCost = 0.0;
		m_blnFaulty = false;
	}

    // A write-only property called Faulty
    __property void set_Faulty(bool value)
    {
        m_blnFaulty = value;
    }

    // A read/write propert called Cost.
    __property double get_Cost()
    {
        return m_dCost;
    }
    __property void set_Cost(double cost)
    {
        if (cost > 0)
            m_dCost = cost;
        else
            m_dCost = 0;
    }

    // A read only property called Size
    __property int get_Size()
    {
        return 100;
    }

	// Indexed property - Get
	__property int get_Stock(String* State, String* City)   
	{
		// For this demo we return a random value only.
		return abs(State->GetHashCode() * City->GetHashCode()) % 50;
	}

	// Indexed property - Set
	__property void set_Stock(String* State, String* City, int value) 
	{
		// assign 'value' to the location at State,City
	}


private:
    double  m_dCost;
    bool    m_blnFaulty;
};

// This is the entry point for this application
int main(void)
{
	Item* item = new Item();

	// Access the Read-only property as if it were a field
	Console::WriteLine("item::Size = {0}", item->Size.ToString());

	// Access the Write-only property as if it were a field
	Console::WriteLine("Setting Item::Faulty to true");
	item->Faulty = true;
	// The following line will not compile, since we are trying to access
	// Faulty as a readable property, when it is write-only.
	//Console::WriteLine("Item::Faulty = {0}", item->Faulty.ToString());

	// Access the Read/Write property as if it were a field
	Console::WriteLine("Setting Item::Cost to -4 (will be clipped to 0)");
	item->Cost = -4;
	Console::WriteLine("Item::Cost = {0}", item->Cost.ToString());


	// Access the indexed property
	Console::WriteLine("Setting Item::Stock at Seattle, WA to 1");
	item->Stock["Seattle"]["WA"] = 1;

	// Get Item::Stock at Toronto, ON
	int nStock = item->Stock["Toronto"]["ON"];
	Console::WriteLine("Stock at Toronto, ON is {0}", nStock.ToString());


	Console::Write("Press Enter to continue");
	Console::ReadLine();

	return 0;
}