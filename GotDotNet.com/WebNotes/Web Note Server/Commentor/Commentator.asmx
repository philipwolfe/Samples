<%@ WebService Language="C#" Class="Commentator" %>

using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebNotes;
using System.Text;
using WebNotesDALComponents;
using BaseDALComponents;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Commentator  : System.Web.Services.WebService {

    public Commentator()
    {
        String ConnectionString = "";
        System.Configuration.ConnectionStringSettings setting = System.Configuration.ConfigurationManager.ConnectionStrings["WebNoteConnection"];
        // Read String from a file.
        ConnectionString = setting.ConnectionString;
        this.factory = new WebNoteFactory(ConnectionString);
    }
    private WebNoteFactory factory;

    public WebNoteFactory WebNoteFactory
    {
        set
        {
            this.factory = value;
        }
        get
        {
            return this.factory;
        }
    }
   
    [WebMethod]
    public void AddNote( WebNotes.WebNote webnote )
    {
        factory.CreateNewWebNote(webnote);
    }
    [WebMethod]
    public WebNoteCollection ViewNotes(WebNotes.WebNote webnote)
    {
        return factory.SelectWebNote(webnote);
    }
    [WebMethod]
    public void UpdateNotes(WebNotes.WebNote oldwebnote, WebNotes.WebNote newwebnote)
    {
        factory.UpdateWebNote(oldwebnote, newwebnote);
    }
    [WebMethod]
    public void DeleteNotes(WebNotes.WebNote webnote)
    {
        factory.DeleteWebNote(webnote);
    }
    [WebMethod]
    public void Close()
    {
        this.factory.CloseFactory();
    }
   
}

