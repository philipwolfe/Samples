using System;
using System.Messaging;
using System.IO;
using System.Runtime.Serialization;

public class MQReceive {
    public static void Main(String[] args)
    {
        string appName = Environment.GetCommandLineArgs()[0];

        if ( args.Length != 1 ) {
            Console.WriteLine("Usage: " + appName +" <queue>");
            return;
        }

        string mqPath = ".\\" + args[0];

        if ( !MessageQueue.Exists(mqPath) ) {
            Console.WriteLine("The queue '" + mqPath + "' does not exist!");
            return;
        }

        MessageQueue mq = new MessageQueue(mqPath);
        ((XmlMessageFormatter)mq.Formatter).TargetTypeNames = new string[]{"System.String"};

        try {
            Message m = mq.Receive(new TimeSpan(0,0,3));
            Console.WriteLine("Message: " + (string)m.Body);
        }
        catch ( MessageQueueException ) {
            Console.WriteLine("There are no messages in the queue");
            return;
        }
        catch ( InvalidOperationException ) {
            Console.WriteLine("The message removed from the queue is not a string");
            return;
        }
    }
}