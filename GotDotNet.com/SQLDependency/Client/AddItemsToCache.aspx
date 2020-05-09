<%@ Page Language="C#"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<script runat=server>
  const string DSN = "server=localhost;uid=sa;pwd=00password;database=pubs";

  public DataSet PopulateDataSet() {
    DataSet ds = new DataSet();

    SqlConnection myConnection = new SqlConnection(DSN);

    SqlDataAdapter myCommand = new SqlDataAdapter("select * from authors", myConnection);

    myCommand.Fill(ds, "Authors");

    return ds;
  }

  public void AddDataSetToCache(DataSet ds) {
    string CacheKey = "Authors-Table";
    string AppPath = "http://localhost/mgb/Cache/SQLDependency/Client/";
    string TableToMonitor = "authors";

    if (null != Cache[CacheKey]){
      span1.InnerHtml = "Getting DataSet from Cache...";

      ds = (DataSet)Cache[CacheKey];
    } else {
      span1.InnerHtml = "Cache invalid, getting DataSet from SQL...";

      Cache[CacheKey] = ds;

      SqlChangeNotification s = new SqlChangeNotification();
      s.DataSourceName = DSN;
      s.OnChangeInvalidateCache(AppPath, CacheKey, TableToMonitor);
    }
  }
  
  public void Page_Load(){
    DataSet ds = PopulateDataSet();

    AddDataSetToCache(ds);

    MyList.DataSource = ds;
    MyList.DataBind();

  }
</script>
<font size=6>
<span id=span1 runat=server />
</font>
<P>
<ASP:DataGrid id="MyList" HeaderStyle-BackColor="#aaaadd" BackColor="#ccccff" runat="server" />
