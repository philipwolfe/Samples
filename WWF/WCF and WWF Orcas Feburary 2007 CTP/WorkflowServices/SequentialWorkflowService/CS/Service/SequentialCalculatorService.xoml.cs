using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Microsoft.WorkflowServices.Samples
{
	public partial class SequentialCalculatorService : SequentialWorkflowActivity
	{
        [NonSerialized]
        public int inputValue = default(int);
        public int currentValue = default(int);
        public bool powerOn = true;
        public string owner = default(string);

        private void PowerOff(object sender, EventArgs e)
        {
            powerOn = false;
        }

        private void Add(object sender, EventArgs e)
        {
            currentValue += inputValue;
            Output("Add");
        }

        private void Subtract(object sender, EventArgs e)
        {
            currentValue -= inputValue;
            Output("Subtract");
        }

        private void Multiply(object sender, EventArgs e)
        {
            currentValue *= inputValue;
            Output("Multiply");
        }

        private void Divide(object sender, EventArgs e)
        {
            currentValue /= inputValue;
            Output("Divide");
        }

        private void Output(string operation)
        {
            Console.WriteLine(operation + "(" + inputValue.ToString() + ")");
            Console.WriteLine("[" + currentValue.ToString() + "]");
        }

        private void IdentifyOwner(object sender, OperationValidationEventArgs e)
        {
            owner = ExtractCallerName(e.ClaimSets);
        }

        private void ValidateOwner(object sender, OperationValidationEventArgs e)
        {
            if (!String.IsNullOrEmpty(owner) && owner.Equals(ExtractCallerName(e.ClaimSets)))
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        private string ExtractCallerName(ReadOnlyCollection<ClaimSet> claimSets)
        {
            string owner = string.Empty;
            foreach (ClaimSet claims in claimSets)
            {
                foreach (Claim claim in claims)
                {
                    if (claim.ClaimType.Equals(ClaimTypes.Name) && claim.Right.Equals(Rights.PossessProperty))
                    {
                        owner = claim.Resource.ToString();
                        break;
                    }
                }
            }
            return owner;
        }

        private void PowerOnCondition(object sender, ConditionalEventArgs e)
        {
            if (this.powerOn == true)
            {
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }


    }
}
