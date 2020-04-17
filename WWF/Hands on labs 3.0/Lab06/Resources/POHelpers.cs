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

namespace ContosoWorkflows
{
    public class POHelpers
    {

        public static void CopyPOItems(POSchema.PO sourcePO, Northwind.PO destinationPO)
        {
            if (sourcePO.Items != null)
            {
                destinationPO.Items = new Northwind.POItem[sourcePO.Items.Length];
                for (int i = 0; i < sourcePO.Items.Length; i++)
                {
                    destinationPO.Items[i] = new Northwind.POItem();
                    destinationPO.Items[i].Sku = sourcePO.Items[i].Sku;
                    destinationPO.Items[i].Price = sourcePO.Items[i].Price;
                    destinationPO.Items[i].Amount = sourcePO.Items[i].Amount;
                }
            }
        }

        public static void CopyPOHistory(POSchema.PO sourcePO, Northwind.PO destinationPO)
        {
            if (sourcePO.History != null)
            {
                destinationPO.History = new Northwind.POStatus[sourcePO.History.Length];
                for (int i = 0; i < sourcePO.History.Length; i++)
                {
                    destinationPO.History[i] = new Northwind.POStatus();
                    destinationPO.History[i].Contact = sourcePO.History[i].Contact;
                    destinationPO.History[i].PoStatus = sourcePO.History[i].PoStatus;
                    destinationPO.History[i].Timestamp = sourcePO.History[i].Timestamp;
                }
            }
        }

        public static void CopyPOHeader(POSchema.PO sourcePO, Northwind.PO destinationPO)
        {
            destinationPO.PONumber = sourcePO.PONumber;
            destinationPO.OrderTotal = sourcePO.OrderTotal;
        }

        public static void CopyPOItems(POSchema.PO sourcePO, Fabrikam.PO destinationPO)
        {
            if (sourcePO.Items != null)
            {
                destinationPO.Items = new Fabrikam.POItem[sourcePO.Items.Length];
                for (int i = 0; i < sourcePO.Items.Length; i++)
                {
                    destinationPO.Items[i] = new Fabrikam.POItem();
                    destinationPO.Items[i].Sku = sourcePO.Items[i].Sku;
                    destinationPO.Items[i].Price = sourcePO.Items[i].Price;
                    destinationPO.Items[i].Amount = sourcePO.Items[i].Amount;
                }
            }
        }

        public static void CopyPOHeader(POSchema.PO sourcePO, Fabrikam.PO destinationPO)
        {
            destinationPO.PONumber = sourcePO.PONumber;
            destinationPO.OrderTotal = sourcePO.OrderTotal;
        }

        public static void CopyPOHistory(POSchema.PO sourcePO, Fabrikam.PO destinationPO)
        {
            if (sourcePO.History != null)
            {
                destinationPO.History = new Fabrikam.POStatus[sourcePO.History.Length];
                for (int i = 0; i < sourcePO.History.Length; i++)
                {
                    destinationPO.History[i] = new Fabrikam.POStatus();
                    destinationPO.History[i].Contact = sourcePO.History[i].Contact;
                    destinationPO.History[i].PoStatus = sourcePO.History[i].PoStatus;
                    destinationPO.History[i].Timestamp = sourcePO.History[i].Timestamp;
                }
            }
        }
    }
}

