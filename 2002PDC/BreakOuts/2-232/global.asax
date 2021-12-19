<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.NewXml"%>
<%@ Assembly Name="System.XML.dll"%>

<script language="C#" runat="server">

    void Application_Start(Object sender, EventArgs e) {
    
	XmlTextReader r = new XmlTextReader(Server.MapPath("po.xml"));
	XmlDataDocument doc = new XmlDataDocument();

// 	can map using either XDR or XSD schema
//	doc.LoadDataSetMapping(Server.MapPath("poschema.xsd"));
	doc.LoadDataSetMapping(Server.MapPath("poschema.xdr"));
	doc.Load(r);

        Application["Document"] = doc;
    }

</script>

