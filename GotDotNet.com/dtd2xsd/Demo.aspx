<%@PAGE LANGUAGE=C# debug="true"%>
<%@Import Namespace="dtd2xsd"%>
<%@Import Namespace="System"%>
<%@Import Namespace="System.Xml"%>
<%@Import Namespace="System.Xml.Schema"%>
<%@Import Namespace="System.IO"%>
<%@Import Namespace="dtd2xsd"%>
<script runat="server">
string Dtd2XsdTest(Uri baseUri, string subset)
{
  try {
  	Dtd dtd = Dtd.Parse(baseUri,  
	                    null, // errorLog
	                    null, // root name
	                    null, // pubid
	                    null, // url
	                    subset,  // dtd subset
	                    null, // proxy
	                    new NameTable(),
	                    false,  // SGML
                      GROUPS.Checked); // preserveGroups
	                    
    XmlSchema s = dtd.GetSchema(null,null);
    StringWriter sw = new StringWriter();
    XmlTextWriter w = new XmlTextWriter(sw);
    w.Formatting = Formatting.Indented;
    s.Write(w);
    w.Close();   
    return sw.ToString();              
  } catch (Exception e) {
    return e.Message;
  }
}
void SubmitBtn_Click(Object Src, EventArgs E) 
{
	string result = Dtd2XsdTest(
	  new Uri("file://"+Server.MapPath(".")),
	  DATA.InnerText);
	XSD.InnerText = result;
}
</script>
<form runat="server" method="POST" action="demo.aspx">
<h4 style="margin:0;background-color:navy;color:white">Data</h4>
<textarea runat="server" rows=10 cols=70 id=DATA>
<!ENTITY % e "(c|d)*">
<!ELEMENT foo (a,b,%e;)>
<!ELEMENT a (#PCDATA)>
<!ELEMENT b (#PCDATA)>
<!ELEMENT c (#PCDATA)>
<!ELEMENT d (#PCDATA)>
</textarea>
<h4 style="margin:0;background-color:navy;color:white">XSD</h4>
<textarea runat="server" rows=20 cols=70 id=XSD></textarea>
<br/>
<asp:button text="SUBMIT" Onclick="SubmitBtn_Click" runat=server/>
<asp:checkbox id="GROUPS" checked runat=server/> Preserve Groups

<%
// Dynamically figure out where we are on the server so we don't hard code this fact in the href.
Uri one = new Uri("file://"+Server.MapPath("/"));
Uri two = new Uri("file://"+Server.MapPath("."));
string path = one.MakeRelative(two).Substring(2);
%>
<br/><br/>
See <a href="/srcview/srcview.aspx?path=<%=path%>/dtd2xsd.src&file=Demo.aspx">Source Code</a>
for this page.

 </form>