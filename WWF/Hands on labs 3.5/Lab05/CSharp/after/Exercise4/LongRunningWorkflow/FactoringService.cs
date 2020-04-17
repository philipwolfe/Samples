//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Activities;
using System.Workflow.Runtime;

namespace LongRunningWorkflow
{
    [Serializable]
    public class PrimeFactoringEventArgs : ExternalDataEventArgs
    {
        private int primeCount;

        public int PrimeCount
        {
            get { return primeCount; }
        }

        public PrimeFactoringEventArgs(Guid instanceId, int primeCount)
            : base(instanceId)
        {
            this.primeCount = primeCount;
        }
    }

    [ExternalDataExchange]
    public interface IPrimeFactoring
    {
        void FactorPrimes();
        event EventHandler<PrimeFactoringEventArgs> FactoredPrimes;
    }

    [Serializable]
    public class FactoringService : IPrimeFactoring
    {
        #region IPrimeFactoring Members

        public void FactorPrimes()
        {
            ThreadPool.QueueUserWorkItem(FactorPrimes, WorkflowEnvironment.WorkflowInstanceId);
        }

        public event EventHandler<PrimeFactoringEventArgs> FactoredPrimes;

        #endregion

        private void FactorPrimes(object instanceId)
        {
            Console.WriteLine("Beginning Factoring Prime Numbers");

            DateTime start = DateTime.Now;

            int topNumber = 100000000;
            BitArray numbers = new BitArray(topNumber, true);

            for (int i = 2; i < topNumber; i++)
            {
                if (numbers[i])
                {
                    for (int j = i * 2; j < topNumber; j += i)
                    {
                        numbers[j] = false;
                    }
                }
            }

            int primes = 0;

            for (int i = 1; i < topNumber; i++)
            {
                if (numbers[i])
                {
                    primes++;
                }
            }

            Console.WriteLine("Finished Factoring Prime Numbers (" + Math.Round(DateTime.Now.Subtract(start).TotalSeconds, 0) + " seconds)");

            if (FactoredPrimes != null)
            {
                this.FactoredPrimes(this, new PrimeFactoringEventArgs((Guid)instanceId, primes));
            }
        }
    }

}
