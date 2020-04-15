
using System.Collections;
// Sets up the class that is used to test the Garbage Collector. 


public class GcTest
{

	// Two private variables are declared. One for the name of the
	//   current object and one to hold a GcTest child object.

	private string m_Name;

	private GcTest m_Child;
	
	// Events should be declared with a corresponding event handler. This
	// combination is used when relevant changes occur in the object.
	// Verify that the declared event is of the type defined by the delegate.

	public delegate void InfoEventHandler(string message );

	public event InfoEventHandler ObjectGcInfo ;

	// Ensure a constructor is created that accepts two parameters -- the
	// name of the object and the number of levels of child
	// elements that should be created.
	// new() is the keyword used to create a constructor in Visual Basic.NET.

	public GcTest(string name, int numLevels)
	{

		// Just set the name of the current object to the passed name parameter.

		m_Name = name;

		// Only objects declared using will receive this
		// event, since event handlers pointed to by AddHandler can only
		// be associated after the object is created. Since in this How-To, they
		// are created dynamically, this event won't be caught.
		
		if(ObjectGcInfo!=null)
		{
			ObjectGcInfo(m_Name + " Created");
		}
		// Ensure the object hierarchy isn't too deep, since it doesn't help with
		// understanding the Garbage Collector and it makes for 
		// a messy user iterface.
		// Limit the number of levels to 5.

		if (numLevels > 5)
		{

			numLevels = 5;

		}

		// Begin by testing that the numLevels is greater than zero, so 
		//   that our hierarchy is limited. if it is greater than zero, then
		//   create a child object, naming it the name of the current object
		//   except prefixing it with an "*" to distinguish it. Also, be sure
		//   to decrement the number of 
		//   levels (so that it doesn't create objects indefinitely).

		if (numLevels > 0) 
		{

			m_Child = new GcTest("*" + m_Name, numLevels - 1);

			// ObjectGcInfo can be raised by the child object, well
			//   this object, so ensure that the myChildHandler has been
			//   associated with the child's ObjectGcInfo event.
			
			m_Child.ObjectGcInfo +=new InfoEventHandler(myChildHandler);
		}

	}

	// return the GC Generation a read-only property.

	public  int Generation
	{
		get 
		{
			
			// GetGeneration returns the generation of the current object.
			return System.GC.GetGeneration(this);
		}
        

	}

	public  string Name
	{
		get 
		{

			// return the name of the current object.
			return m_Name;

		}

	}

	// Declare a Dispose method.

	public void Dispose(bool isFinalizeSupressed)
	{

		// if SuppressFinalize is requested, tell the Garbage Collector
		//   to suppress the finalization of this object. This can dramatically
		//   increase the performance of the garbage collector.

		if (isFinalizeSupressed)
		{
		
			System.GC.SuppressFinalize(this);

		}

		// Dispose of any Children and set them to null

		if (m_Child != null)
		{
			m_Child.Dispose(isFinalizeSupressed);
			m_Child = null;
		}

		// Raise event showing that the object was disposed. Include in
		//   parenthesis the value of SuppressFinalize.

		ObjectGcInfo(m_Name + " Disposed (" + isFinalizeSupressed.ToString() + ")");
	}

	// This function kills the object with the name passed
	//   in the parameter. It is called recursively through
	//   the entire hierarchy. It returns true if the object
	//   was killed, false otherwise.

	public bool DisposeChildNamed(string name ,bool isFinalizeSupressed )
	{

		// Check to see if m_child is nothing

		if ( m_Child != null)
		{

			// Check to see if the current child zis the object

			//   to be disposed of.

			if (m_Child.Name == name)
			{

				// Dispose of m_Child

				m_Child.Dispose(isFinalizeSupressed);

				return true;
			}
			else 
			{

				// try { to find object to Dispose by searching through

				//   child hierarchy.

				m_Child.DisposeChildNamed(name, isFinalizeSupressed);
				return false;
			}
		}
		else 
		{

			// We've reached the end of the chain and 
			//   didn't find the object so return false

			return false;

		}

	}

	// This function returns an ArrayList containing the names

	//   of all of the created objects and their children.

	public ArrayList GetSelfAndChildGenerations()
	{
		// Create an ArrayList to use.

		ArrayList myArrayList = new ArrayList();

		// if child exists, call the GetSelfAndChildNames() function
		//   recursively, to get list of children.

		if (m_Child != null) 
		{

		// Get ArrayList from child.

		myArrayList = m_Child.GetSelfAndChildGenerations();
		}
        else 
		{

            // No child exists, so the program is at the bottom
            //   of its chain. Create a new ArrayList.

            myArrayList = new ArrayList();

        }

        // Add the name of the current object to the ArrayList at the
        //   first position.

        myArrayList.Insert(0, m_Name + " - Gen: " + this.Generation.ToString());

        // return the ArrayList.

        return myArrayList;

    }

    // This function returns an ArrayList containing the names
    //   of all of the created objects and their children.

    public ArrayList GetSelfAndChildNames() 
	{

        // Create an ArrayList to use.

      ArrayList myArrayList = new ArrayList();

        // if child exists, call the GetSelfAndChildNames() function
        //   recursively, to get list of children.

		if (m_Child != null)
		{

			// Get ArrayList from child.

			myArrayList = m_Child.GetSelfAndChildNames();
		}
		else 
		{

			// No child exists, so the program is at the bottom
			//   of its chain. Create a new ArrayList.

			
		}

        // Add the name of the current object to the ArrayList at the
        //   first position.

        myArrayList.Insert(0, m_Name);

        // return the ArrayList.

        return myArrayList;

    }

    // Override the Finalize method to raise information

    
	~GcTest()
	{
		
		// Let the parent of this object know that
		//   finalization was called.

		ObjectGcInfo(m_Name + " Finalized");
	}


    // This function kills the object with the name passed
    //   in the parameter. It is called recursively through
    //   the entire hierarchy. It returns true if the object
    //   was killed, false otherwise.

    public bool KillChildNamed(string name)
{

        // Check to see if m_child is nothing

		if (m_Child != null) 
		{

			// Check to see if the current child is the object
			//   to be disposed of.

			if (m_Child.Name == name)
			{
				// Kill m_Child

				m_Child = null;

				return true;
			}
			else 
			{

				// try { to find object to kill by searching through
				//   child hierarchy.

				m_Child.KillChildNamed(name);
				return false;
			}
		}

		else 
		{

			// We've reached the end of the chain and 
			//   didn't find the object so return false

			return false;

		}

    }

    // Set up an event handler for the child that will simply
    //   pass the events up the chain.

    public void myChildHandler(string message)
	{

        // Raise an ObjectGcInfo event, passing the information
        //   up the object tree.

		ObjectGcInfo(message);
		
		
    }

    // Override the Tostring to return the name of the object.

    public override string ToString()
	{
		
        return m_Name;

    }

}

