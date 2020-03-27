using System;
using System.Text;

/// <summary>
/// Stores a programming note.
/// </summary>
/// <remarks>
/// Notice how the AttributeUsage attribute can be used to AllowMultiple 
/// attributes to exist on the same programming entity
/// </remarks>
[AttributeUsage(AttributeTargets.All,
	            AllowMultiple=true)]
public class ProgrammingNoteAttribute : System.Attribute 
{
    private string myNote;
    
	/// <summary>
	/// The constructor for the Programming Note Attribute
	/// </summary>
	/// <param name="note"> The note to store </param>
    public ProgrammingNoteAttribute(string note) 
    {
        myNote = note;
    }
    
	/// <summary>
	/// The Note contents 
	/// </summary>
    public string Note
    {
        get { return myNote; }
    }
 
	/// <summary>
	/// The string representation of this object.
	/// </summary>
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        
        sb.Append( "Programming Note - ");
        sb.Append( Note );
               
        return sb.ToString();
    }
}