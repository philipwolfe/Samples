Imports System
Imports System.Messaging

public class Formatters

    public shared sub Main()
        Dim mqPath As String = ".\FormattersSample"
        if(not MessageQueue.Exists(mqPath)) then
            MessageQueue.Create(mqPath)
        end if
		
        Dim mq As MessageQueue = new MessageQueue(mqPath)
		
        Dim order As Order = new Order()
        order.OrderId = 102
        order.ItemDescription = "MS Visual Studio 7"

        mq.Formatter = new XmlMessageFormatter()    	
        mq.Send(order)

        mq.Formatter = new BinaryMessageFormatter()		
        mq.Send(order)

        mq.Formatter = new ActiveXMessageFormatter()
        mq.Send(10)
    end sub

end class