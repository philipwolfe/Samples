//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.SwitchRange
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Activities.Validation;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Markup;

    /// <summary>
    /// This activity allows switching on a range of values.     
    /// </summary>
    /// <typeparam name="T">Type of the values in the range</typeparam>
    [ContentProperty("Cases")]
    public sealed class SwitchRange<T> : NativeActivity where T:IComparable
    {
        IList<CaseRange<T>> cases;

        public SwitchRange()
        {
        }

        [IsRequired]
        [DefaultValue(null)]
        public InArgument<T> Expression { get; set; }

        public IList<CaseRange<T>> Cases
        {
            get
            {
                if (this.cases == null)
                {
                    this.cases = new List<CaseRange<T>>();
                }
                return this.cases;
            }
        }

        [DefaultValue(null)]
        public WorkflowElement Default { get; set; }

        //Bind the Expression to a Runtime argument and add to the collection of arguments
        protected override void OnGetArguments(IList<RuntimeArgument> arguments)
        {
            if (Expression != null)
            {
                RuntimeArgument expressionArgument = new RuntimeArgument("Expression", typeof(T), ArgumentDirection.In);
                Argument.Bind(Expression, expressionArgument);
                arguments.Add(expressionArgument);
            }
        }

        //Add CaseRanges and Default as children of SwitchRange so they can be scheduled
        protected override void OnGetChildren(IList<WorkflowElement> children)
        {
            foreach (CaseRange<T> range in Cases)
            {
                children.Add(range.Action);
            }

            if (Default != null)
            {
                children.Add(Default);
            }
        }

        //Perform validations and then call base.OnOpen()
        protected override void OnOpen(DeclaredEnvironment environment)
        {
            int malformedRanges = 0;
            foreach (CaseRange<T> range in Cases)
            {
                if (range.From == null || range.To == null)
                {
                    malformedRanges++;
                }
            }

            if (Expression == null)
            {
                throw new ValidationException(string.Format(CultureInfo.InvariantCulture, "SwitchRange {0}: Expression is unspecified", DisplayName));
            }

            if (malformedRanges > 0)
            {
                throw new ValidationException(string.Format(CultureInfo.InvariantCulture, "SwitchRange {0}: There is/are {1} CaseRange(s) that have either From or To unspecified", DisplayName, malformedRanges));
            }

            base.OnOpen(environment);
        }

        //Evaluate the expression, find a matching CaseRange or Default if specified and schedule that for execution
        protected override void Execute(ActivityExecutionContext context)
        {
            // evaluate the expression for the switch
            T result = (T)this.Expression.Get(context);

            // find best matching case according with the result of the expression
            WorkflowElement matchingCase = FindMatchingCase(result);

            // if a schedule the case for execution (if found)
            if (matchingCase != null)
            {
                context.ScheduleActivity(matchingCase);
            }
        }

        //Define validations that can be enforced at Design time, if a designer were built for this
        protected override void OnGetConstraints(IList<System.Activities.Validation.Constraint> constraints)
        {
          Variable<SwitchRange<T>> activity = new Variable<SwitchRange<T>> { Name = "constraintArg" };
          Variable<CaseRange<T>> switchCase = new Variable<CaseRange<T>> { Name = "switchCase" };
          constraints.Add(new Constraint<SwitchRange<T>>
          {
              Body = new ActivityAction<SwitchRange<T>, ValidationContext>
              {
                  Argument1 = activity,
                  Handler = new Sequence
                  {
                      Activities =
                      {
                          new AssertValidation 
                          {
                              Assertion = ValueExpression.Create(ctx => activity.Get(ctx).Default != null || activity.Get(ctx).Cases.Count > 0),
                              Message = ValueExpression.Create(ctx => "A Switch with no cases and no 'Default' set will never do anything."),
                              IsWarning = true
                          },
                          new AssertValidation 
                          {
                              Assertion = ValueExpression.Create(ctx => activity.Get(ctx).Default == null || activity.Get(ctx).Cases.Count > 0),
                              Message = ValueExpression.Create(ctx => "A Switch with a 'Default' but no cases is redundant, since you could just execute the 'Default' directly. Did you mean to add some cases?"),
                              IsWarning = true
                          },
                          new AssertValidation
                          {
                              Assertion = ValueExpression.Create(ctx => activity.Get(ctx).Expression != null),
                              Message = ValueExpression.Create(ctx => string.Format(CultureInfo.InvariantCulture, "SwitchRange {0}: Expression is unspecified", DisplayName))
                          },
                          new ForEach<CaseRange<T>>
                          {
                              Values = ValueExpression.Create(ctx => (IEnumerable<CaseRange<T>>)activity.Get(ctx).Cases),
                              Body = new ActivityAction<CaseRange<T>>
                              {
                                  Argument = switchCase,
                                  Handler = new AssertValidation
                                  {
                                      Assertion = ValueExpression.Create(ctx => switchCase.Get(ctx).From != null && switchCase.Get(ctx).To != null),
                                      Message = ValueExpression.Create(ctx => string.Format(CultureInfo.InvariantCulture, "SwitchRange {0}: CaseRange has either From or To unspecified", DisplayName))
                                  }
                              }
                          }
                      }
                  }
              }
          });
      }

        private WorkflowElement FindMatchingCase(T result)
        {
            WorkflowElement matchingCase = null;
            
            //Iterate through each CaseRange to check if the result falls within the range
            foreach (CaseRange<T> caseRange in Cases)
            {
                if (caseRange.IsInRange(result))
                {
                    matchingCase = caseRange.Action;
                    break;
                }
            }

            //if no matching CaseRange is found then choose Default
            if (matchingCase == null && Default != null)
            {
                matchingCase = Default;
            }

            return matchingCase;
        }
    }
}

