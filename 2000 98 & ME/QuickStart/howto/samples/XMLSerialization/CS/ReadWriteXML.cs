using System.Xml.Serialization;
using System.IO;
using XmlSerializationHowTo;

public class Test {
    public static void Main(string[] args) {
        XmlSerializer serializer = new XmlSerializer(typeof(PurchaseOrder));

        TextReader reader = new StreamReader("..\\PurchaseOrder.xml");
        PurchaseOrder po = (PurchaseOrder)serializer.Deserialize(reader);
        reader.Close();

        TextWriter writer = new StreamWriter("PurchaseOrder2.xml");
        serializer.Serialize(writer, po);
        writer.Close();
    }
}
