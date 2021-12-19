using System;
using System.Messaging;
	
public class SendObject
{
        public static void Main(String[] args) 
	{
		string mqPath = ".\\MQSendSample";

		if(!MessageQueue.Exists(mqPath))
		{
			MessageQueue.Create(mqPath);
		}
		
		MessageQueue mq = new MessageQueue(mqPath);

		Customer customer = new Customer();
		customer.LastName = "Copernicus";
		customer.FirstName = "Nicolaus";		
		mq.Send(customer);	
        }
}