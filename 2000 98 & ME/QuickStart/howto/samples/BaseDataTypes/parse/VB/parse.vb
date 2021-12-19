Imports System
Imports System.Globalization

Namespace Parse
    Public Class parseExample
    
    public shared sub Main()
            ' This variable forces the data parsing to succeed.  If you'd like
            ' to see the parsing work in your own locale, you can remove this
            ' call and then replace all dates with ones that are formatted in
            ' your locale specific manner.
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US")

            'Simple DateTime parsing 
            Console.WriteLine()
            Dim date1 As String = "03/17/77"
            Console.WriteLine("Parsing {0}.", date1)
            Dim d As DateTime = DateTime.Parse(date1)
            Console.WriteLine("The date parsed as {0}", d)
        
            'DateTime parsing using ParseExact 
            Console.WriteLine()
            Dim date2 As String = "Thursday, March 17, 1977"
            Console.WriteLine("Parsing {0}.", date2)
            Dim d2 As DateTime = DateTime.ParseExact(date2, "D", Nothing)
            Console.WriteLine("The date parsed as {0}", d2)
        
            'Simple numeric parsing
            Dim toBeParsed As String = "123456"
            Console.WriteLine()
            Console.WriteLine("Parsing the string {0}.", toBeParsed)
            Dim i As Integer = Int32.Parse(toBeParsed)
            Console.WriteLine("The string parsed to {0}.", i)
        
            'Parsing using NumberStyles
            Console.WriteLine()
            Dim toBeParsed2 As String = "  (123456)"
            Console.WriteLine()
            Console.WriteLine("Parsing the string {0} which contains leading white space and parens.", toBeParsed)
            Dim j As Integer = Int32.Parse(toBeParsed2, NumberStyles.AllowParentheses BitOr NumberStyles.AllowLeadingWhite)
            Console.WriteLine("The string parsed to {0}.", i)
        
            Console.WriteLine ()
            Console.WriteLine("Press Return to exit.")
            Console.Read()
        End Sub

    End Class

End Namespace
