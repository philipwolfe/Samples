
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.NewXml;
using System.IO;

public class MyCodeBehind : Page 
{
    public HtmlGenericControl Message;
    public HtmlGenericControl Message1;
    public HtmlGenericControl Message2;
    public HtmlGenericControl Message3;
    public HtmlGenericControl Message4;
    public HtmlGenericControl Message5;
    public HtmlGenericControl Message6;
    public HtmlGenericControl Message7;
    public DataGrid MyDataGrid1;
    public DataGrid MyDataGrid2;
    public DataGrid MyDataGrid3;
    public DataGrid MyDataGrid4;
    public DataGrid MyDataGrid5;
    public DataGrid MyDataGrid6;
    public DataGrid MyDataGrid7;

    protected void Page_Load(Object Src, EventArgs E) 
    {
        if (!IsPostBack)
	  BindGrid();
    }

    public void BindGrid() 
    {
	XmlTextReader r = new XmlTextReader(Server.MapPath("po.xml"));
	XmlDataDocument doc = new XmlDataDocument();
//	doc.LoadDataSetMapping(Server.MapPath("poschema.xsd"));
	doc.LoadDataSetMapping(Server.MapPath("poschema.xdr"));
	doc.Load(r);
	DataSet ds = doc.DataSet;

        Message.InnerHtml = "Number of Tables: " + ds.Tables.Count.ToString();

	int i = 0;
	Message1.InnerHtml = ds.Tables[i].TableName;
        MyDataGrid1.DataSource=ds.Tables[i].DefaultView;
        MyDataGrid1.DataBind();

	i++;
	Message2.InnerHtml = ds.Tables[i].TableName;
        MyDataGrid2.DataSource=ds.Tables[i].DefaultView;
        MyDataGrid2.DataBind();

	i++;
	Message3.InnerHtml = ds.Tables[i].TableName;
        MyDataGrid3.DataSource=ds.Tables[i].DefaultView;
        MyDataGrid3.DataBind();

	i++;
	Message4.InnerHtml = ds.Tables[i].TableName;
        MyDataGrid4.DataSource=ds.Tables[i].DefaultView;
        MyDataGrid4.DataBind();

	i++;
	Message5.InnerHtml = ds.Tables[i].TableName;
        MyDataGrid5.DataSource=ds.Tables[i].DefaultView;
        MyDataGrid5.DataBind();

	i++;
	Message6.InnerHtml = ds.Tables[i].TableName;
        MyDataGrid6.DataSource=ds.Tables[i].DefaultView;
        MyDataGrid6.DataBind();

	i++;
	Message7.InnerHtml = ds.Tables[i].TableName;
        MyDataGrid7.DataSource=ds.Tables[i].DefaultView;
        MyDataGrid7.DataBind();

    }

}
