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

namespace OrderLocalServices
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
        }

        public void RaiseOrderCreatedEvent(string orderId, Guid instanceId)
        {

            if (OrderCreated != null)
                OrderCreated(null, new OrderEventArgs(instanceId, orderId));
        }

        public void RaiseOrderShippedEvent(string orderId, Guid instanceId)
        {
            if (OrderShipped != null)
                OrderShipped(null, new OrderEventArgs(instanceId, orderId));
        }

        public void RaiseOrderUpdatedEvent(string orderId, Guid instanceId)
        {
            if (OrderUpdated != null)
                OrderUpdated(null, new OrderEventArgs(instanceId, orderId));
        }
        public void RaiseOrderProcessedEvent(string orderId, Guid instanceId)
        {
            if (OrderProcessed != null)
                OrderProcessed(null, new OrderEventArgs(instanceId, orderId));
        }
        public void RaiseOrderCanceledEvent(string orderId, Guid instanceId)
        {
            if (OrderCanceled != null)
                OrderCanceled(null, new OrderEventArgs(instanceId, orderId));
        }
        public event EventHandler<OrderEventArgs> OrderCreated;
        public event EventHandler<OrderEventArgs> OrderShipped;
        public event EventHandler<OrderEventArgs> OrderUpdated;
        public event EventHandler<OrderEventArgs> OrderProcessed;
        public event EventHandler<OrderEventArgs> OrderCanceled;
    }
}
