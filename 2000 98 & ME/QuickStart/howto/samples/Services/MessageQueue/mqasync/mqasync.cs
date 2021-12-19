using System;
using System.Messaging;
using System.Threading;

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
        }
        else {
            MessageQueue mq = new MessageQueue(mqPath);
            ((XmlMessageFormatter)mq.Formatter).TargetTypeNames = new string[]{"System.String"};

            mq.ReceiveCompleted += new ReceiveCompletedEventHandler(OnReceiveCompleted);
            mq.BeginReceive();
        }

        Console.WriteLine("Press Enter to quit the sample");
        Console.ReadLine();
    }

    public static void OnReceiveCompleted(Object source, ReceiveAsyncEventArgs asyncResult){
        MessageQueue mq = (MessageQueue)source;
        Message m = mq.EndReceive(asyncResult.AsyncResult);
        Console.WriteLine("Message: " + (string)m.Body);
        mq.BeginReceive();
    }
}