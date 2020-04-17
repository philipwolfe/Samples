using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Activities;
using System.Threading;

namespace Microsoft.Samples.PowerShell
{
    class PowerShellSample
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Running workflow...");
            WorkflowInvoker.Invoke(CreateWf());

            Console.WriteLine("Press <return> to continue...");
            Console.Read();
        }

        private static WorkflowElement CreateWf()
        {
            // variables.
            Variable<PSObject> pipeline1 = new Variable<PSObject>() { Name = "Pipeline 1" };
            Variable<PSObject> pipeline2 = new Variable<PSObject>() { Name = "Pipeline 2" };
            Variable<Process> process1 = new Variable<Process>() { Name = "Process 1" };
            Variable<Process> process2 = new Variable<Process>() { Name = "Process 2" };
            Variable<Collection<Process>> processes1 = new Variable<Collection<Process>> { Name = "Processes 1" };
            Variable<Collection<Process>> processes2 = new Variable<Collection<Process>> { Name = "Processes 2" };

            Sequence body = new Sequence()
            {
                Variables = { processes1, processes2 },
                Activities = 
                {
                    // Simple PowerShell invocation.
                    new WriteLine()
                    {
                        Text = "Simple powerShell invocation. Launching notepad."
                    },

                    new InvokePowerShell()
                    {
                        CommandText = "notepad"
                    },
          
                    // Using PowerShell<T> to capture output.
                    new WriteLine()
                    {
                        Text = "Getting process and then pass the output to a Collection."
                    },
                    new InvokePowerShell<Process>()
                    {
                        CommandText = "Get-Process",
                        Output = processes1,
                        InitializationAction = new ActivityFunc<PSObject,Process>()
                        {
                            Argument = pipeline1,
                            Result = process1,
                            Handler = new Assign<Process>()
                            {
                                To = process1,
                                Value = new InArgument<Process>((env) => (Process)pipeline1.Get(env).BaseObject)
                            }
                        }
                    },

                    new PrintCollection<Process>()
                    {
                        Header = "System Processes",
                        Collection = processes1
                    },
          
                    // Invoke PowerShell using input pipeline.
                    new WriteLine()
                    {
                        Text = "Passing data to PowerShell thru the input pipeline and then sort on unique process names."
                    },

                    new InvokePowerShell<Process>()
                    {
                        CommandText = "Get-Unique",
                        Input = processes1,
                        Output = processes2,
                        InitializationAction = new ActivityFunc<PSObject,Process>()
                        {
                            Argument = pipeline2,
                            Result = process2,
                            Handler = new Assign<Process>()
                            {
                                To = process2,
                                Value = new InArgument<Process>((env) => (Process)pipeline2.Get(env).BaseObject)
                            }
                        }
                    },

                    new PrintCollection<Process>()
                    {
                        Header = "System Processes",
                        Collection = processes2
                    }
                }
            };

            return body;
        }
    }
}
