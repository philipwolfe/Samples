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
using System.Collections.Generic;
using System.Text;

namespace POSchema
{
    [Serializable]
    public class PO
    {
		private string poNumber;

		public string PONumber
		{
			get { return poNumber; }
			set { poNumber = value; }
		}
		private string fulfillerTrackingNumber;

		public string FulfillerTrackingNumber
		{
			get { return fulfillerTrackingNumber; }
			set { fulfillerTrackingNumber = value; }
		}
		private double orderTotal;

		public double OrderTotal
		{
			get { return orderTotal; }
			set { orderTotal = value; }
		}
		private POItem[] items;

		public POItem[] Items
		{
			get { return items; }
			set { items = value; }
		}
		private POStatus[] history;

		public POStatus[] History
		{
			get { return history; }
			set { history = value; }
		}

		public static PO GeneratePOInstance()
		{
			PO newPOInstance = new PO();
			newPOInstance.PONumber = Guid.NewGuid().ToString();
			newPOInstance.FulfillerTrackingNumber = "";

			// Create one History item
			newPOInstance.History = new POStatus[1];
			newPOInstance.History[0] = new POStatus();
			newPOInstance.History[0].Contact = System.Threading.Thread.CurrentPrincipal.Identity.Name;
			newPOInstance.History[0].PoStatus = "New";
			newPOInstance.History[0].Timestamp = DateTime.Now;

			//Add the Items in the PO
			newPOInstance.Items = new POItem[2];

			// Item 1
			newPOInstance.Items[0] = new POItem();
			newPOInstance.Items[0].Sku = "1234";
			newPOInstance.Items[0].Price = 12;
			newPOInstance.Items[0].Amount = 5;
			newPOInstance.OrderTotal += newPOInstance.Items[0].Price * newPOInstance.Items[0].Amount;

			// Item 2
			newPOInstance.Items[1] = new POItem();
			newPOInstance.Items[1].Sku = "5678";
			newPOInstance.Items[1].Price = 43.5;
			newPOInstance.Items[1].Amount = 3;
			newPOInstance.OrderTotal += newPOInstance.Items[1].Price * newPOInstance.Items[1].Amount;

			return newPOInstance;
		}

        public static void CopyHistoryAndChangeStatus(PO sourcePO, PO destinationPO, string newStatus)
        {
            if (sourcePO.History != null)
            {
                destinationPO.History = new POStatus[sourcePO.History.Length + 1];
                for (int i = 0; i < sourcePO.History.Length; i++)
                {
                    destinationPO.History[i] = new POStatus();
                    destinationPO.History[i].Contact = sourcePO.History[i].Contact;
                    destinationPO.History[i].PoStatus = sourcePO.History[i].PoStatus;
                    destinationPO.History[i].Timestamp = sourcePO.History[i].Timestamp;
                }
                destinationPO.History[sourcePO.History.Length] = new POStatus();
                destinationPO.History[sourcePO.History.Length].Contact = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                if (sourcePO.Items == null)
                    destinationPO.History[sourcePO.History.Length].PoStatus = "Rejected";
                else
                    destinationPO.History[sourcePO.History.Length].PoStatus = newStatus;
                destinationPO.History[sourcePO.History.Length].Timestamp = DateTime.Now;

            }
            else
            {
                destinationPO.History = new POStatus[1];
                destinationPO.History[0] = new POStatus();
                destinationPO.History[0].Contact = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                destinationPO.History[0].PoStatus = "Rejected due to no history";
            }
        }

        public static void CopyPOItems(PO sourcePO, PO destinationPO)
        {
            if (sourcePO.Items != null)
            {
                destinationPO.Items = new POItem[sourcePO.Items.Length];
                for (int i = 0; i < sourcePO.Items.Length; i++)
                {
                    destinationPO.Items[i] = new POItem();
                    destinationPO.Items[i].Sku = sourcePO.Items[i].Sku;
                    destinationPO.Items[i].Price = sourcePO.Items[i].Price;
                    destinationPO.Items[i].Amount = sourcePO.Items[i].Amount;
                }
            }
        }

        public static void GenerateResponseHeader(PO sourcePO, PO destinationPO, string trackingRef)
        {
            destinationPO.PONumber = sourcePO.PONumber;
            destinationPO.OrderTotal = sourcePO.OrderTotal;
            destinationPO.FulfillerTrackingNumber = trackingRef + sourcePO.PONumber;
        }

    }

    [Serializable]
    public class POItem
    {
		private string sku;

		public string Sku
		{
			get { return sku; }
			set { sku = value; }
		}
		private double amount;

		public double Amount
		{
			get { return amount; }
			set { amount = value; }
		}
		private double price;

		public double Price
		{
			get { return price; }
			set { price = value; }
		}
    }

    [Serializable]
    public class POStatus
    {
		private string contact;

		public string Contact
		{
			get { return contact; }
			set { contact = value; }
		}
		private string poStatus;

		public string PoStatus
		{
			get { return poStatus; }
			set { poStatus = value; }
		}
		private DateTime timestamp;

		public DateTime Timestamp
		{
			get { return timestamp; }
			set { timestamp = value; }
		}
    }
}
