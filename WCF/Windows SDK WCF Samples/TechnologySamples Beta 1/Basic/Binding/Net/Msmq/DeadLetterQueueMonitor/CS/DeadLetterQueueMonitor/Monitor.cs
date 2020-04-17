 namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.Configuration;
    using System.Messaging;
    using System.Transactions;

    class Monitor
    {
        const byte FrameSimplexMode = 3;
        const byte FrameSingletonSizedMode = 4;

        MessageQueue datagramQueue;
        MessageQueue sessionQueue;
        MessageQueue unrecognizedQueue;
        MessageQueue deadLetterQueue;

        static void Main()
        {
            new Monitor().Run();

            Console.WriteLine("The dead letter queue monitor is ready.");
            Console.WriteLine("The monitor separates WCF datagram and session messages in a queue and sends it to different queues");
            Console.WriteLine("Press <ENTER> to terminate monitor.");
            Console.WriteLine();
            Console.ReadLine();
        }

        void Run()
        {
            string queueName = ConfigurationManager.AppSettings["datagramQueueName"];
            if (! MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);
            this.datagramQueue = new MessageQueue(queueName);

            queueName = ConfigurationManager.AppSettings["sessionQueueName"];
            if (! MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);
            this.sessionQueue = new MessageQueue(queueName);

            queueName = ConfigurationManager.AppSettings["unrecognizedQueueName"];
            if (! MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);
            this.unrecognizedQueue = new MessageQueue(queueName);

            this.deadLetterQueue = new MessageQueue("FormatName:DIRECT=OS:localhost\\system$;deadxact");

            this.deadLetterQueue.BeginPeek(MessageQueue.InfiniteTimeout, this, OnPeekComplete);
        }

        void OnPeekComplete(IAsyncResult result)
        {
            this.deadLetterQueue.EndPeek(result);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    Message message = this.deadLetterQueue.Receive(TimeSpan.Zero, MessageQueueTransactionType.Automatic);

                    // Read first 5 bytes of the message body. 
                    // Fifth byte points to the .NET framing frame type.
                    // See [url here] for .NET framing protocol details.
                    // If the fifth byte does not match value to indicate WCF queued session or datagram message
                    // the message will be dispatched to the unrecognized message queue.
                    // Please note that if there is a random message whose fifth byte meets the values for session or datagram
                    // message, this program would interpret them as session or datagram.

                    // By default, messages are dispatched to the unrecognized message queue.
                    MessageQueue destinationQueue = unrecognizedQueue;

                    byte[] frameHeaderBuffer = new byte[5];                    
                    if (5 == message.BodyStream.Read(frameHeaderBuffer, 0, 5))
                    {
                        if (Monitor.FrameSimplexMode == frameHeaderBuffer[4])
                        {
                            // If fith byte's value is 3, this is probably WCF queued session message.
                            Console.WriteLine("Found a WCF Session message ...sending to session dead letter queue ");
                            destinationQueue = this.sessionQueue;
                        }
                        else if (Monitor.FrameSingletonSizedMode == frameHeaderBuffer[4])
                        {
                            // If fith byte's value is 4, this is probably WCF queued datagram message.
                            Console.WriteLine("Found a WCF Datagram message...sending to datagram dead letter queue");
                            destinationQueue = this.datagramQueue;
                        }
                    }
                    message.BodyStream.Position = 0;

                    destinationQueue.Send(message, MessageQueueTransactionType.Automatic);
                    scope.Complete();

                }
                catch (MessageQueueException exception)
                {
                    Console.WriteLine(exception);
                }
            }

            this.deadLetterQueue.BeginPeek(MessageQueue.InfiniteTimeout, this, OnPeekComplete);
        }
    }
}
