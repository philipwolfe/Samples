using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Data;
using System.Data.OleDb;
using BaseDALComponents;
using WebNotes;
using WebNotesDALComponents;

namespace WebNotesDALComponents
{
    public class WebNoteFactory
    {
        private DataExecuter dataexecuter;
 
        public WebNoteFactory (String connectionstring) 
        {
            this.dataexecuter = new DataExecuter ( connectionstring );
            this.dataexecuter.Open ();
            this.dataexecuter.Table = "WebNotes";
        }
        public WebNoteFactory (DataExecuter dataexecuter) 
        {
            this.dataexecuter = dataexecuter;
            this.dataexecuter.Open ();
            this.dataexecuter.Table = "WebNotes";
        }

        public void CloseFactory ()
        {
            this.dataexecuter.Close ();
        }

        public void CreateNewWebNote (WebNote webnote)
        {
            String note = webnote.Note;
            String url = webnote.Url;

            this.dataexecuter.ExecuteInsert ( new String [] { "Url='"+url+"'","Note='"+note+"'"} );


            
        }
        public void DeleteWebNote ( WebNote webnote )
        {
            String note = webnote.Note;
            String url = webnote.Url;

            this.dataexecuter.ExecuteDelete ("url='"+url+"' AND Note='"+note+"'");
        }
        public void UpdateWebNote ( WebNote oldwebnote , WebNote newwebnote)
        {
            String oldnote = oldwebnote.Note;
            String oldurl = oldwebnote.Url;

            String newnote = newwebnote.Note;
            String newurl = newwebnote.Url;

            this.dataexecuter.ExecuteUpdate ( new String [] { "Url='"+newurl +"'","Note='"+newnote+"'"}, "url='"+oldurl+"' AND note='"+oldnote+"'" );

        }
        public WebNoteCollection SelectWebNote ( WebNote webnote )
        {
            String note = webnote.Note;
            String url = webnote.Url;

            ArrayList myrowsfromDB = this.dataexecuter.ExecuteSelect ( new String [] { "*" },"url='"+url+"'");

            return this.FillWebNoteCollection ( myrowsfromDB );
        }

        public WebNoteCollection SelectWebNote ()
        {
           
            ArrayList myrowsfromDB = this.dataexecuter.ExecuteSelect ( new String [] { "*" });

            return this.FillWebNoteCollection ( myrowsfromDB );
        }

        private WebNoteCollection FillWebNoteCollection (ArrayList webnotes)
        {
            Object [] mynotesfromDB = null;
            WebNoteCollection webnotecollection = new WebNoteCollection ();
            WebNote webnotecontainer = new WebNote ();

            for ( int i = 0 ; i < webnotes.Count ; ++i )
            {
                mynotesfromDB = ( Object [] ) webnotes [ i ];
                webnotecontainer = new WebNote ( mynotesfromDB [ 0 ].ToString () , mynotesfromDB [ 1 ].ToString () );
                webnotecollection.Add ( webnotecontainer );
            }
            return webnotecollection;
        }

    }
}
