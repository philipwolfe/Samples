using System;
using System.Messaging;

public class MQCtrl {
    public static void Main(String[] args) 
    {
        string appName = Environment.GetCommandLineArgs()[0];

        if ( args.Length != 3 ) {
            Console.WriteLine("Usage: ");
            Console.WriteLine("\t" + appName +" <queue> <command> <value>");
            Console.WriteLine("");
            Console.WriteLine("\t\t<command> =");
            Console.WriteLine("\t\t\tl: change label");
            Console.WriteLine("\t\t\ts: change queue size");
            Console.WriteLine("\t\t\tj: change journal size");
            return;
        }

        string mqPath = ".\\" + args[0];
        if ( !MessageQueue.Exists(mqPath) ) {
            Console.WriteLine("The queue " + mqPath + " does not exist");
            return;     
        }

        MessageQueue mq = new MessageQueue(mqPath);

        string command = args[1];

        if ( command == "l" ) {
            mq.Label = args[2]; 
        } else if ( command == "s" ) {
            mq.MaximumQueueSize = UInt32.FromString(args[2]);
        } else if ( command == "j" ) {
            mq.MaximumJournalSize = UInt32.FromString(args[2]);
        }
    }
}