using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WebNotesUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main (String [] args)
        {

            String argument = "";
            if ( args.Length == 1 )
            {
                argument = args [ 0 ];
            }
            else if ( args.Length > 2 )
            {
                Application.Exit ();
            }

            
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault ( false );
            Application.Run ( new WebNotesUI.WebNoteUI(argument) );
        }
    }
}