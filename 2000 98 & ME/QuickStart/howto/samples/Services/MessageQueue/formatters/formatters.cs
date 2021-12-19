using System;
using System.Messaging;

public class Formatters {
    public static void Main(String[] args) 
    {
        string mqPath = ".\\FormattersSample";

        if ( !MessageQueue.Exists(mqPath) ) {
            MessageQueue.Create(mqPath);
        }

        MessageQueue mq = new MessageQueue(mqPath);

        Order order = new Order();
        order.OrderId = 102;
        order.ItemDescription = "MS Visual Studio 7";

        mq.Formatter = new XmlMessageFormatter();  
        mq.Send(order);

        mq.Formatter = new BinaryMessageFormatter();        
        mq.Send(order);

        mq.Formatter = new ActiveXMessageFormatter();     
        mq.Send(10); 
    }
}