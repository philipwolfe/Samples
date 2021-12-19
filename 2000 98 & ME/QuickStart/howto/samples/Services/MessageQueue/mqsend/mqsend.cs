using System;
using System.Messaging;
	
public class MQSend 
{
    public static void Main(String[] args) 
	{
        string appName = Environment.GetCommandLineArgs()[0];

		if(args.Length != 2)
		{
			Console.WriteLine("Usage: " + appName +" <queue> <message>");
			return;
		}

		string mqPath = ".\\" + args[0];
		if(!MessageQueue.Exists(mqPath))
		{
			MessageQueue.Create(mqPath);
		}
		
		MessageQueue mq = new MessageQueue(mqPath);
		mq.Send(args[1]);
    }
}