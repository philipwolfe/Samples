using System;
using System.Text;

/// <summary>
/// Stores the Help URL for a specific program element.
/// </summary>
public class HelpUrlAttribute : System.Attribute 
{
    private string myUrl;
    
	/// <summary>
	/// The constructor for the Help URL Attribute
	/// </summary>
	/// <param name="url"> The Url to store </param>
    public HelpUrlAttribute(string url) 
    {
        myUrl = url;
    }
    
	/// <summary>
	/// The Url that contains the help for the programming element.
	/// </summary>
    public string Url
    {
        get { return myUrl; }
    }
 
	/// <summary>
	/// The string representation of this object.
	/// </summary>
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        
        sb.Append( "Help URL - ");
        sb.Append( Url );
        
        return sb.ToString();
    }
}