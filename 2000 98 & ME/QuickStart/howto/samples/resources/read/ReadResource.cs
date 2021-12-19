using System;
using System.Resources;
using System.Reflection;


public class ReadResourceDemo
{
    // The resource manager for accessing the resources.
    ResourceManager _resourceManager;
	
    public ReadResourceDemo() {
        // Create a resource manager and store it.
        _resourceManager = new ResourceManager("Errors",                        // basename for the resources
                                               Assembly.GetExecutingAssembly(),
                                               null,                            // default resource file format
                                               false);                          // do not use satellite assemblies
    }
    
    
    public double Divide(int op1, int op2) {
        double result;
		
        if(op2 == 0) {
            // Create exception with string from resource.
            // Now application can be localized without altering source code.
            Exception exc = new Exception(_resourceManager.GetString("DivisionByZero"));
            throw(exc);
        } else {
            result = op1 / op2;
        }
		
        return result;
    }
    
    
    public static void Main(string[] args) {

        ReadResourceDemo demo = new ReadResourceDemo();
		
        Console.WriteLine("4 divided by 2 is {0}", demo.Divide(4, 2) );
		
        // Provoke an error to see exception.
        Console.WriteLine("4 divided by 0 is {0}", demo.Divide(4, 0) );
		
        Console.WriteLine ("\r\nPress Return to exit.");
        Console.Read();
    }
}

