using System;
using System.Data;
using System.Data.SQL;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class MyCodeBehind : Page {

    public TextBox      Name;
    public DropDownList Category;
    public DataList     MyList;

    public void SubmitBtn_Click(Object sender, EventArgs e) {

        if (Page.IsValid) {

           SQLConnection myConnection = new SQLConnection("server=localhost;uid=sa;pwd=;database=pubs");
           SQLDataSetCommand myCommand = new SQLDataSetCommand("select * from Titles where type='" + Category.SelectedItem.Value + "'", myConnection);

           DataSet ds = new DataSet();
           myCommand.FillDataSet(ds, "Titles");

           MyList.DataSource = ds.Tables["Titles"].DefaultView;
           MyList.DataBind();
        }
    }
}