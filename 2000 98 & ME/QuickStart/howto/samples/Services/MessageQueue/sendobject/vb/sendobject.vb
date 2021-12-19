Imports System
Imports System.Messaging
	
Public Class SendObject

    Public Shared Sub Main() 

        Dim mqPath As String = ".\MQSendSample"

        if(Not MessageQueue.Exists(mqPath)) then
            MessageQueue.Create(mqPath)
        end if
		
        Dim mq As MessageQueue = new MessageQueue(mqPath)

        Dim customer As Customer = new Customer()
        customer.LastName = "Copernicus"
        customer.FirstName = "Nicolaus"		
        mq.Send(customer)     

    End Sub

End Class