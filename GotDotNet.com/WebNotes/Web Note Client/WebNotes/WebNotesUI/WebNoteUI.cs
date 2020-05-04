using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebNotes;

namespace WebNotesUI
{
    public partial class WebNoteUI : Form
    {
        private String url;
        public WebNoteUI (String url)
        {
            this.url = url;
            InitializeComponent ();
        }

        private void Note_Container_SelectedIndexChanged ( object sender , EventArgs e )
        {
            TabControl tabcontrol = ( TabControl ) sender;
            if ( tabcontrol.SelectedTab.Text.ToLower ().StartsWith ( "view" ) )
            {
                this.Submit_btn.Text = "View";
            }
            else if ( tabcontrol.SelectedTab.Text.ToLower ().StartsWith ( "add" ) )
            {
                this.Submit_btn.Text = "Submit";
            }
        }

        private void Submit_btn_Click ( object sender , EventArgs e )
        {
            

            String url = this.Url_Text.Text;
            String Comment = this.NotesBox.Text;
            url = url.Replace ( '=' , '_' );
            Commentator commentaor = new Commentator ();
            if (Comment == null)
            {
                Comment = "";
            }
            WebNotes.WebNote webnote = new WebNotes.WebNote ( url , Comment );
            
            
            if ( Note_Container.SelectedIndex == 0 )
            {
                commentaor.AddNote ( webnote );
            }
            else if ( Note_Container.SelectedIndex == 1 )
            {
                WebNoteCollection notes = commentaor.ViewNotes (webnote);
                String [] display_notes = new String [ notes.Count ];
                for ( int i = 0 ; i < notes.Count ; ++i )
                {
                    display_notes [ i ] = notes [ i ].Note;
                }
                this.Notes_Viewer.Lines = display_notes;
            }
            MessageBox.Show ( "Task Performed" );
 
        }

        private void WebNoteUI_Load ( object sender , EventArgs e )
        {
            this.Url_Text.Text = url;
        }

    }
}