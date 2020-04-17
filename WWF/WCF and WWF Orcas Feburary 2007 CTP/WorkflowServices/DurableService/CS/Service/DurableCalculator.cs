using System;
using System.ServiceModel.Description;

namespace Microsoft.WorkflowServices.Samples
{
    [Serializable]
    [DurableServiceBehavior]
    public class DurableCalculator : ICalculator
    {
        int currentValue = default(int);

        [DurableOperationBehavior(CanCreateInstance=true)]
        public int PowerOn()
        {
            return currentValue;
        }

        [DurableOperationBehavior()]
        public int Add(int value)
        {
            return (currentValue += value);
        }

        [DurableOperationBehavior()]
        public int Subtract(int value)
        {
            return (currentValue -= value);
        }

        [DurableOperationBehavior()]
        public int Multiply(int value)
        {
            return (currentValue *= value);
        }

        [DurableOperationBehavior()]
        public int Divide(int value)
        {
            return (currentValue /= value);
        }

        [DurableOperationBehavior(CompletesInstance=true)]
        public void PowerOff()
        {
        }

    }
}
