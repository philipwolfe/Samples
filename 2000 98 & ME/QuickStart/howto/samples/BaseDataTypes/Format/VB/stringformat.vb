Option Strict Off
Imports System

Public Class StringFormat 
    
      Public Shared Sub main()
           
        'Formatting a table
        Console.WriteLine("Formatting in a table")
        Dim names() As String = {"Mary-Beth", "Aunt Alma", "Sue", "My Really Long Name", "Matt"}
        
        Dim k as Integer
        For k = 0 to 4
            Console.WriteLine ("{0,-5}{1,-20}", k, names(k))
        Next
        Console.WriteLine()
        
        'Enum formatting
        Console.WriteLine("Enum Formatting")
        Dim e as System.Enum 
        e = CObj (Color.Red)
        Console.WriteLine ("Name: {0}, Value: {1}", e.Format(), e.Format ("D", Nothing))
        Console.WriteLine()
        
        'DateTime built in formats
        Console.WriteLine ("DateTime Formatting:  Predefined formats")
        Console.WriteLine ("{0,-15}{1}" ,"Code", "Format")
        Console.WriteLine ("{0,-15}{1}" ,"----", "------")
        Dim d As Object
        d = CObj (DateTime.Now)
        PrintFormat (d, "d")
        PrintFormat (d, "D")
        PrintFormat (d, "f")
        PrintFormat (d, "F")
        PrintFormat (d, "g")
        PrintFormat (d, "G")
        PrintFormat (d, "m")
        PrintFormat (d, "r")
        PrintFormat (d, "s")
        PrintFormat (d, "t")
        PrintFormat (d, "T")
        PrintFormat (d, "u")
        PrintFormat (d, "U")
        Console.WriteLine()  
          
          
        'DateTime picture  formats
        
        Console.WriteLine("DateTime Formatting:  Picture formats")
        Console.WriteLine ("{0,-15}{1,-10}" ,"Code", "Format")
        Console.WriteLine ("{0,-15}{1,-10}" ,"----", "------")
        PrintFormat (d, "ddd")
        PrintFormat (d, "MMMM dd, yyyy")    
        Console.WriteLine()
        
        'Number standard formats
        Dim num as Object
        num = CObj (12.9625)
        
        Console.WriteLine()
        Console.WriteLine("Numeric Formatting:  Predefined formats")
        Console.WriteLine ("{0,-15}{1}" ,"Code", "Format")
        Console.WriteLine ("{0,-15}{1}" ,"----", "------")
        PrintFormat (num, "c")
        PrintFormat (CObj (103), "d")
        PrintFormat (num, "e")
        PrintFormat (num, "f")
        PrintFormat (num, "g")
        PrintFormat (num, "n")
        PrintFormat (CObj(1102), "x")
        Console.WriteLine()
        
        'Number custom formats
        Dim i as Object
        i = CObj (25)
        
        Console.WriteLine("Numeric Formatting:  Picture formats")
        Console.WriteLine ("{0,-15}{1}" ,"Code", "Format")
        Console.WriteLine ("{0,-15}{1}" ,"----", "------")
        PrintFormat (i, "#")
        PrintFormat (i, "###")
        PrintFormat (i, "#.00")
        PrintFormat (i/100.0, "%#")
        PrintFormat (i, "D4")
        Console.WriteLine()
        
        
        'User defined types can specify their own formatting that works in exactly the same way.
        'See the definition of MyType below
        
        Console.WriteLine("Formatting Custom Types")	
        Console.WriteLine ("{0,-15}{1}" ,"Code", "Format")
        Console.WriteLine ("{0,-15}{1}" ,"----", "------")
        Dim t As MyType 
        t = new MyType (43)
        PrintFormat (t, "b")
        Console.WriteLine()

 	dim j as integer = 100

	Console.WriteLine (String.Format("{0} in the custom B8 format is {1:B8}", new object() {j, j}, new BaseFormatter ()))
	Console.WriteLine (String.Format("{0} in the custom B16 format is {1:B16}", new object() {j, j}, new BaseFormatter ()))
 
 
        
       
        Console.WriteLine ()
		Console.WriteLine ("Press Return to exit.")
		Console.Read()
        
     End Sub 'end of main
     
    Public Shared Sub PrintFormat (value As IFormattable, formatString as String)
        Console.WriteLine ("{0,-15}{1}", formatString, value.Format (formatString, Nothing))
    End Sub 
     
End Class

Public enum Color
    Red
    Blue
    Green
End Enum

'This is my own custom type that implements IFormattable and respects the "b" format for binary 
'as well as all the formatting codes for Int32.
'Console.WriteLine, String.Format, etc will call the Format method to get the string form of an 
'instance of this type
Public class MyType : Implements IFormattable
    
    private  _value As Integer  'to store the value internal
    Public Sub New(value As Integer)
      MyBase.New()
      _value = value
    End Sub
    
    'This is the formatting method called by String.Format.  In it, we look for the "b" format
    'which we respect  and then fall through to Int32's format for anything else we don't know about.
    'Function Format(ByVal format As String, ByVal sop As System.IServiceObjectProvider) As String for interface IFormattable.

    Public Function Format (ByVal formatStr As String, ByVal sop As IServiceObjectProvider) As String Implements IFormattable.Format
    
        If (formatStr.Equals ("b"))
            Return Convert.ToString (_value, 2)
        Else Return _value.Format (formatStr, sop)
        End If
    End Function 
End Class 'MyType




'This class provides a new formatting code: Bn where n is any number between 2 and 64. This 
'Formatting code allows numbers to be printed out in any base.   
'To get access to the formatting code, a user needs to pass BaseFormatter to String.Format()

public class BaseFormatter : Implements IServiceObjectProvider, ICustomFormatter

    
    'String.Format calls this method to get an instance of a ICustomFormatter to handle the formatting.
    'In our case, we just return the same instance (this), but it would be possible return an instance 
    'of a different type.

    public function GetServiceObject (service as Type) as object Implements IServiceObjectProvider.GetServiceObject

      

      if (service = System.Type.GetType("System.ICustomFormatter")) then
	return me
      else
	return nothing
      end if
	


    end function
    
    'Once String.Format gets the ICustomFormatter it calls this format method on each argument. 

    public function Format (formatString as string, arg as object, sop as IServiceObjectProvider)  as string implements ICustomFormatter.Format
 

        if formatString is nothing then
	  return  String.Format ("{0}", arg)
	end if

        dim i as integer = formatstring.length

        if not formatstring.StartsWith("B") then  
	    dim temp as string = "{0:" + formatstring +"}"
            return system.String.Format (temp, arg)
	end if

        'otherwise, get the base out of the format string and use it to form the output string
        formatstring = formatstring.Trim (new char() {"B"})

	dim b as integer = Convert.ToInt32(formatstring)
	return Convert.ToString(Convert.ToInt32(arg), b)

     end function    

end class
   