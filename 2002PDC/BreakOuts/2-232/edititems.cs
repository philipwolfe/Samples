
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.NewXml;
using System.NewXml.Xsl;

public class MyCodeBehind : Page 
{
    public DataGrid MyDataGrid;
    public HtmlGenericControl Message;

    String SortField;

    protected void Page_Load(Object Src, EventArgs E) 
    {
        if (!IsPostBack)
	  {
	    if (SortField == "")
	      SortField = "uom";
            BindGrid();
	  }
    }

    public void MyDataGrid_Edit(Object sender, DataGridCommandEventArgs E)
    {
        MyDataGrid.EditItemIndex = (int) E.Item.ItemIndex;
        BindGrid();
    }

    public void MyDataGrid_Cancel(Object sender, DataGridCommandEventArgs E)
    {
        MyDataGrid.EditItemIndex = -1;
        BindGrid();
    }

    public void MyDataGrid_Update(Object sender, DataGridCommandEventArgs E)
    {
	DataSet ds = ((XmlDataDocument) Application["Document"]).DataSet;
        DataView dv = ds.Tables["Item"].DefaultView;
	DataRowView rv = (DataRowView) dv[MyDataGrid.EditItemIndex];
	DataRow row = rv.Row;

	row.BeginEdit();

        int numCols = E.Item.Cells.Count;
        for (int i = 1; i < numCols; i++) //skip first column
        {
            String colvalue = ((TextBox) E.Item.Cells[i].Controls[0]).Text;
	    row[i-1] = colvalue;
        }

	row.EndEdit();
	row.AcceptChanges();

        MyDataGrid.EditItemIndex = -1;
        BindGrid();
    }

    public void BindGrid() 
    {
	DataSet ds = ((XmlDataDocument) Application["Document"]).DataSet;

	MyDataGrid.DataSource = ds.Tables["Item"].DefaultView;

	DataView dv = (DataView) MyDataGrid.DataSource;
	dv.Sort = SortField;
        MyDataGrid.DataBind();
    }

    public void MyDataGrid_Sort(Object sender, DataGridSortCommandEventArgs e)
    {
        SortField = (string) e.SortField;
        BindGrid();
    }

    protected void Submit_Click(Object sender, EventArgs E)
    {
        XmlDataDocument doc = (XmlDataDocument) Application["Document"];
	DataDocumentNavigator nav = new DataDocumentNavigator(doc);
	XslTransform tr = new XslTransform();

	XmlTextWriter wr = new XmlTextWriter(Server.MapPath("ponew.xml"),
					     null);

	tr.Load(Server.MapPath("poxform.xsl"));
	tr.Transform(nav, null, wr);
    }
}
