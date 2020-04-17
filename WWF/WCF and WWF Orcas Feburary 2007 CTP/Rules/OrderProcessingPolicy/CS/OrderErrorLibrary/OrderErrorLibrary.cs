//--------------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Microsoft.Rules.Samples
{
    // The container class of the extension method
    public static class Extensions
    {
        // The definition of the extension method for the class OrderErrorCollection
        public static void PrintOrderErrors(this OrderErrorCollection orderErrorCollection)
        {
            Console.WriteLine();

            foreach (OrderError orderError in orderErrorCollection)
            {
                Console.WriteLine(orderError.ErrorText);
            }
        }
    }

    // The error object that will get created when an invalid input is entered
    public class OrderError
    {
        private string errorText;       // ie. Error: Zip code is invalid
        private string customerName;    // ie. "John Customer"
        private int itemNum;            // ie. 1 => for Vista Ultimate DVD
        private string zipCode;         // ie. "00999"

        public OrderError()
        {
        }

        public OrderError(int invalidItemNum)
        {
            this.ItemNum = invalidItemNum;
        }

        public OrderError(string invalidZipCode)
        {
            this.ZipCode = invalidZipCode;
        }

        public string ErrorText
        {
            get
            {
                return this.errorText;
            }
            set
            {
                this.errorText = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return this.customerName;
            }
            set
            {
                this.customerName = value;
            }
        }

        public int ItemNum
        {
            get
            {
                return this.itemNum;
            }
            set
            {
                this.itemNum = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return this.zipCode;
            }
            set
            {
                this.zipCode = value;
            }
        }
    }

    public class OrderErrorCollection : Collection<OrderError>
    {
        public OrderErrorCollection()
        {
        }

        public void AddError(OrderError orderError)
        {
            this.Add(orderError);
        }

        // Overload the operator + for two OrderErrorCollection objects
        public static OrderErrorCollection operator +(OrderErrorCollection orderErrorCollection1, OrderErrorCollection orderErrorCollection2)
        {
            OrderErrorCollection orderErrorCollection = new OrderErrorCollection();
            if (null != orderErrorCollection1)
            {
                foreach (OrderError orderError in orderErrorCollection1)
                    orderErrorCollection.Add(orderError);
            }

            if (null != orderErrorCollection2)
            {
                foreach (OrderError orderError in orderErrorCollection2)
                    orderErrorCollection.Add(orderError);
            }

            return orderErrorCollection;
        }
    }
}
