//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.LinqToObjects
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Collections.Generic;    

    class Program
    {
        static void Main(string[] args)
        {            
            UseFindInCollectionAsStandAloneActivity();

            UseFindInCollectionInWorkflow();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();            
        }

        // This sample shows how to use FindInCollection as a stand alone activity (e.g.
        // it is not part of any workflow and its executed directly.
        // The main goal of this sample is to demonstrate the public interface of 
        // FindInCollection.        
        static void UseFindInCollectionAsStandAloneActivity()
        {
            // create the list
            IList<Employee> employees = new List<Employee>()
            {
                new Employee(1, "Employee 1", "PM", "Redmond"),
                new Employee(2, "Employee 2", "SDET", "Redmond"),
                new Employee(3, "Employee 3", "SDET", "Redmond"),
                new Employee(4, "Employee 4", "DEV", "Redmond"),
                new Employee(5, "Employee 5", "DEV", "Redmond"),
                new Employee(6, "Employee 6", "PM", "Redmod"),
                new Employee(7, "Employee 7", "PM", "China")
            };

            // create and execute FindInCollection activity to filter the list
            WorkflowElement wf = new FindInCollection<Employee>
            {
                Collections = new InArgument<IEnumerable<Employee>>(employees),
                Predicate = new InArgument<Func<Employee, bool>>(e => e.Role == "PM" && e.Location.Equals("Redmond"))                
            };
            IDictionary<string, object> results = WorkflowInvoker.Invoke(wf);

            // show results in the console
            IList<Employee> result = (IList<Employee>)results["Result"];
            foreach (Employee employee in result)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        // This sample shows how to use FindInCollection inside a workflow.
        // In this case, we are combining CollectionActivities (AddToCollection activity)
        // FindInCollection and ForEach.
        static void UseFindInCollectionInWorkflow()
        {
            // create workflow variables
            var employees = new Variable<IList<Employee>>() { Default = new List<Employee>() };
            var devsFromRedmond = new Variable<IList<Employee>>();
            var iterationVariable = new Variable<Employee>();
            
            // create workflow program
            WorkflowElement sampleWorkflow = new Sequence
            {
                Variables = { employees, devsFromRedmond }, 
                Activities =
                {
                    new AddToCollection<Employee>
                    {
                        Collection = new InArgument<ICollection<Employee>>(employees),
                        Item =  new InArgument<Employee>(new Employee(1, "Employee 1", "DEV", "Redmond"))
                    },
                    new AddToCollection<Employee>
                    {
                        Collection = new InArgument<ICollection<Employee>>(employees),
                        Item =  new InArgument<Employee>(new Employee(2, "Employee 2", "DEV", "Redmond"))
                    },
                    new AddToCollection<Employee>
                    {
                        Collection = new InArgument<ICollection<Employee>>(employees),
                        Item =  new InArgument<Employee>(new Employee(3, "Employee 3", "PM", "Redmond"))
                    },
                    new AddToCollection<Employee>
                    {
                        Collection = new InArgument<ICollection<Employee>>(employees),
                        Item =  new InArgument<Employee>(new Employee(4, "Employee 4", "PM", "China"))
                    },
                    new FindInCollection<Employee>
                    {
                        Collections = new InArgument<IEnumerable<Employee>>(employees),
                        Predicate = new InArgument<Func<Employee, bool>>(e => e.Role == "DEV" && e.Location.Equals("Redmond")),
                        Result = new OutArgument<IList<Employee>>(devsFromRedmond)
                    },
                    new ForEach<Employee>
                    {
                        Values = new InArgument<IEnumerable<Employee>>(devsFromRedmond),
                        Body = new ActivityAction<Employee>
                        {
                            Argument = iterationVariable,
                            Handler = new WriteLine
                            {
                                Text = new InArgument<string>(env => iterationVariable.Get(env).ToString())
                            }
                        }
                    }
                }
            };

            // execute workflow
            WorkflowInvoker.Invoke(sampleWorkflow);
        }
    }
}