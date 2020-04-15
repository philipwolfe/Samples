using System.Diagnostics;
using System;

// This class is used to store a counter, well define a
//   Tostring() method that can be used by a ComboBox to display the
//   instance and name of the counter.

// Note: This is an excellent way to define how a ComboBox displays
//   values.
public class CounterDisplayItem
{
    // Store an instance of the counter inside the class
    private PerformanceCounter m_Counter;

    // Define a constructor, that requires that the PerformanceCounter
    //   be passed.  Store the passed counter.
 
	public CounterDisplayItem(PerformanceCounter inCounter)
	{
        // Only store the passed value if it is, indeed, a counter.
		if (inCounter.GetType().Name == "PerformanceCounter")
		{
			m_Counter = inCounter;
		}
		else 
		{
			m_Counter = null;
		}
    }

    // This property gets or sets the PerformanceCounter stored by 
    //   a CounterDisplayItem object.
    public PerformanceCounter Counter
	{
        get {
            return m_Counter;
        }

		set {
			m_Counter = value;
        }
    }

    // This function overrides the Tostring() method to display the
    //   information about the Counter that will be necessary for the 
    //   user to select the proper counter.
    public override string ToString()
	{
		if (m_Counter != null)
		{
			return m_Counter.InstanceName + " - " + m_Counter.CounterName;
		}
        else 
		{
			return string.Empty;
		}
    }

    // This property returns a true if the counter is a custom counter, and 
    //   a false otherwise. Since there is no IsCustom property of a 
    //   PerformanceCounter object, a special bit of code is used. This code
    //   simple attempts to set the readonly property to false, then read a 
    //   value from the counter. This will raise an exception if the counter
    //   is NOT a custom counter, otherwise it will not.
    public bool IsCustom
	{
        get {
            // Store the current value of the readonly property
            bool isReadOnly = m_Counter.ReadOnly;

			try 
			{
				// The only way NextValue works when ReadOnly
				//   is false, is if the Counter is a Custom counter.
				//   Unfortunately, there is no property in the 
				//   PerformanceCounter object that already returns whether
				//   the counter is Custom.
				m_Counter.ReadOnly = false;
				m_Counter.NextValue();

				// if it makes it here, it is a custom counter
				return true;
			}
			catch(Exception)
			{
				// This is not a custom counter
				return false;
			}
            finally
			{
                // Reset the value to the previous value
                m_Counter.ReadOnly = isReadOnly;
            }
        }
    }
}