//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.InvokeMethodUsage
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            // execute the workflow
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            WorkflowInstance myInstance = new WorkflowInstance(CreateWf());
            myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { syncEvent.Set(); };
            myInstance.Run();
            syncEvent.WaitOne();
                        
            // wait for confirmation to exit             
            Console.ReadKey();
        }

        // Create a workflow that shows different ways of using InvokeMethod.         
        // All instances of the InvokeMethod activity in this workflow 
        // are invoking methods from TestClass class (file TestClass.cs)
        static WorkflowElement CreateWf()
        {
            TestClass testClass = new TestClass();
            Variable<string> outParam = new Variable<string>() { Default = "this is an out param" };
            Variable<int> resultValue = new Variable<int>();

            return new Sequence
            {
                Variables = { outParam, resultValue },
                Activities =
                {
                    // use InvokeMethod to call an instance method without parameters
                    new WriteLine { Text = "Instance Method Call" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(testClass),
                        MethodName = "InstanceMethod"
                    },

                    // use InvokeMethod to call an instance method with two parameters (string and int)
                    new WriteLine(),
                    new WriteLine { Text = "Instance Method Call with Parameters" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(testClass),
                        MethodName = "InstanceMethod",
                        Parameters =
                        {
                            new InArgument<string>("My favorite number is"),
                            new InArgument<int>(42)
                        }
                    },

                    // use InvokeMethod to call an instance method with two parameters (string and int) 
                    // and a parameter array of type string[].                    
                    new WriteLine(),
                    new WriteLine { Text = "Instance Method Call with Parameter Arrays" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(testClass),
                        MethodName = "InstanceMethod",
                        Parameters =
                        {
                            new InArgument<string>("My favorite number is"),
                            new InArgument<int>(42),
                            new InArgument<string>("first item of the param array"),
                            new InArgument<string>("second item of the param array"),
                            new InArgument<string>("third item of the param array")
                        }
                    },

                    // use InvokeMethod to call an instance method with two parameters (two int numbers)
                    // and a result of type int. In this case, the result value is bound to a variable
                    // and used in another activity (is displayed in the console using WriteLine)
                    new WriteLine {},
                    new WriteLine { Text = "Instance Method Call with Parameters and Return Value" }, 
                    new InvokeMethod 
                    {
                        TargetObject = new InArgument<TestClass>(testClass),
                        MethodName = "InstanceMethodWithResult",
                        Parameters =
                        {
                            new InArgument<int>(20),
                            new InArgument<int>(22)
                        },
                        Result = new OutArgument<int>(resultValue)
                    },
                    new WriteLine { Text = new InArgument<string>(env => string.Format("....Result: {0}", resultValue.Get(env))) },

                    // use InvokeMethod to call a static method with two parameters (string and int). All options 
                    // for calling instance methods are also available for static methods.
                    new WriteLine(),
                    new WriteLine { Text = "Static Method Call with Parameters" },
                    new InvokeMethod
                    {
                        TargetType = typeof(TestClass),
                        MethodName = "StaticMethod",
                        Parameters =
                        {
                            new InArgument<string>("My favorite number is"),
                            new InArgument<int>(42)
                        }
                    },

                    // use InvokeMethod to call an instance method with one generic parameter (int this case, <string>)                    
                    new WriteLine(),
                    new WriteLine { Text = "Generic Instance Method Call with Generic Parameters" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(testClass),
                        MethodName = "GenericInstanceMethod",
                        GenericTypeArguments = { typeof(string) },
                        Parameters =
                        {
                            new InArgument<string>("Hello world")                            
                        }
                    },

                    // use InvokeMethod to call a static method with two generic parameters (int this case, <string> and <int>)                  
                    new WriteLine(),
                    new WriteLine { Text = "Generic Static Method Call with Two Generic Parameters" },
                    new InvokeMethod
                    {
                        TargetType = typeof(TestClass),
                        MethodName = "GenericStaticMethod",
                        GenericTypeArguments = 
                        { 
                            typeof(string), 
                            typeof(int)
                        },
                        Parameters =
                        {
                            new InArgument<string>("Favorite Number"),                            
                            new InArgument<int>(42)     
                        }
                    },                

                    // use InvokeMethod to call an instance method that has one parameter
                    // passed by reference (a string param). In this case, the reference parameter is bound 
                    // to a variable (outParam) and used in another activity (is displayed in the console using WriteLine)
                    new WriteLine(),
                    new WriteLine { Text = "Instance Method Call with Parameters by Rerefence" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(testClass),
                        MethodName = "InstanceMethod",
                        Parameters =
                            {
                                new InArgument<string>("My favorite number is"),
                                new InArgument<int>(42),
                                new InOutArgument<string>(outParam)
                            }
                    },
                    new WriteLine { Text = new InArgument<string>(env => string.Format("....out param changed to: {0}", outParam.Get(env))) },

                     // use InvokeMethod to call an asynchronous instance method
                    new WriteLine(),
                    new WriteLine { Text = "Async Instance Method Call" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(testClass),
                        MethodName = "AsyncMethodSample",
                        RunAsynchronously = true,
                        Parameters =
                        {                                
                            new InArgument<string>("Hello async"),                                
                        }
                    },                   
                    
                    new WriteLine(),
                    new WriteLine { Text = "Sample completed, press any key to exit..." }
                }
            };
        }
    }   
}