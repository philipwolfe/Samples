Imports System.Xml.Serialization
Imports System.IO
Imports XmlSerializationHowTo

public Class Test
	Shared Sub Main()
        	Dim serializer as XmlSerializer
		serializer = new XmlSerializer(GetType(PurchaseOrder))

        	Dim reader as TextReader 
		reader = new StreamReader("..\PurchaseOrder.xml")

	        Dim po as PurchaseOrder 
		po = CType(serializer.Deserialize(reader), PurchaseOrder)

	        reader.Close

	        Dim writer as TextWriter 
		writer = new StreamWriter("PurchaseOrder2.xml")

        	serializer.Serialize(writer, po)
        	writer.Close()
	End Sub
End Class
