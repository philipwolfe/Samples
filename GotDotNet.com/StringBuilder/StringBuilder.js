/*
    ##################### DO NOT MODIFY THIS HEADER #####################
    # Title: StringBuilder Class                                        #
    # Description: Simulates the C# StringBuilder Class in Javascript.  #
    # Website: www.codevendor.com                                       #
    # Author: Adam Smith                                                #
    # Email: ibulwark@hotmail.com                                       #
    # Date: November 12, 2006                                           #
    #####################################################################
*/

// Simulates the C# StringBuilder Class in Javascript.
// Parameter["stringToAdd"] - The string to add. 
StringBuilder = function(stringToAdd)
{    
    var h = new Array();
    if(stringToAdd){h[0] = stringToAdd;} 
    this.Append = Append;
    this.AppendLine = AppendLine;
    this.ToString = ToString;
    this.Clear = Clear;
    this.Length = Length;
    this.Replace = Replace;
    this.Remove = Remove;
    this.Insert = Insert;
    this.GetType = GetType;      
    
    // Appends the string representation of a specified object to the end of this instance.
    // Parameter["stringToAppend"] - The string to append. 
    function Append(stringToAppend)
    {
        h[h.length] = stringToAppend;
    } 

    // Appends the string representation of a specified object to the end of this instance with a carriage return and line feed.
    // Parameter["stringToAppend"] - The string to append. 
    function AppendLine(stringToAppend)
    {
        h[h.length] = stringToAppend;
        h[h.length] = "\r\n";
    } 
  
    // Converts a StringBuilder to a String.
    function ToString()
    {
        if(!h){ return ""; }
        if(h.length<2){ return (h[0])?h[0]:""; }
        var a = h.join('');
        h = new Array();
        h[0] = a;
        return a;
    }

    // Clears the StringBuilder
    function Clear()
    {
        h = new Array();
    }

    // Gets the StringBuilder Length
    function Length()
    {
        if(!h){return 0;}
        if(h.length<2){ return (h[0])?h[0].length:0; }
        var a = h.join('');
        h = new Array();
        h[0] = a;
        return a.length;
    }

    // Replaces all occurrences of a specified character or string in this instance with another specified character or string.
    // Parameter["oldValue"] - The string to replace. 
    // Parameter["newValue"] - The string that replaces oldValue. 
    // Parameter["caseSensitive"] - True or false for case replace.
    // Return Value - A reference to this instance with all instances of oldValue replaced by newValue.
    function Replace(oldValue, newValue, caseSensitive)
    {
        var r = new RegExp(oldValue,(caseSensitive==true)?'g':'gi');
        var b = h.join('').replace(r, newValue);
        h = new Array();
        h[0] = b;
        return this;
    }

    // Removes the specified range of characters from this instance.
    // Parameter["startIndex"] - The position where removal begins. 
    // Parameter["length"] - The number of characters to remove.
    // Return Value - A reference to this instance after the excise operation has occurred.
    function Remove(startIndex, length)
    {       
        var s = h.join('');
	    h = new Array();
	
	    if(startIndex<1){h[0]=s.substring(length, s.length);}
	    if(startIndex>s.length){h[0]=s;}
	    else
	    {
	        h[0]=s.substring(0, startIndex);  
	        h[1]=s.substring(startIndex+length, s.length);
	    }
	
        return this;
    }

    // Inserts the string representation of a specified object into this instance at a specified character position.
    // Parameter["index"] - The position at which to insert.
    // Parameter["value"] - The string to insert. 
    // Return Value - A reference to this instance after the insert operation has occurred.
    function Insert(index, value)
    {
        var s = h.join('');
	    h = new Array();
	
	    if(index<1){h[0]=value; h[1]=s;}
	    if(index>=s.length){h[0]=s; h[1]=value;}
	    else
	    {
	        h[0]=s.substring(0, index); 
	        h[1]=value; 
	        h[2]=s.substring(index, s.length);
	    }
	
        return this;
    }

    // Gets the type
    function GetType()
    {
        return "StringBuilder";
    }
};