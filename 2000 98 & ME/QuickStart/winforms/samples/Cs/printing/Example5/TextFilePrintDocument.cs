//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.PrintingExample2 {
    using System;
    using System.ComponentModel;
    using System.WinForms;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;

    // <doc>
    // <desc>
    //     TextFilePrintDocument prints a stream to a printer 
    //
    //     Note: In order to avoid problems closing a file 
    //     if an exception occurs this class simply takes a 
    //     steam and leaves it to the caller to open the file 
    //     to print
    //
    // </desc>
    // </doc>
    public class TextFilePrintDocument : PrintDocument {

        private Font printFont           = null ;
        private StreamReader streamToPrint = null ;

        public TextFilePrintDocument(StreamReader streamToPrint) : base ()  {
            this.streamToPrint = streamToPrint ;
        }

        //Override OnBeginPrint to set up the font we are going to use
        protected override void OnBeginPrint(PrintEventArgs ev) {
            base.OnBeginPrint(ev) ;
            printFont = new Font("Arial", 10);
        }

        //Override the OnPrintPage to provide the printing logic for the document
        protected override void OnPrintPage(PrintPageEventArgs ev) {
            
            base.OnPrintPage(ev) ;
            
            float lpp = 0 ;
            float yPos =  0 ;
            int count = 0 ;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line=null;
            
            //Work out the number of lines per page 
            //Use the MarginBounds on the event to do this
            lpp = ev.MarginBounds.Height  / printFont.GetHeight(ev.Graphics) ;

            //Now iterate over the file printing out each line
            //NOTE WELL: This assumes that a single line is not wider than the page width
            //Check count first so that we don't read line that we won't print
            while (count < lpp && ((line=streamToPrint.ReadLine()) != null)) {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));

                //NOTE WELL: In the PDC Release you must pass a StringFormat to DrawString or the 
                //Print Preview control will not work. 
                ev.Graphics.DrawString (line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

                count++;
            }

            //If we have more lines then print another page
            if (line != null) 
                ev.HasMorePages = true ;
            else 
                ev.HasMorePages = false ;
        }

    }

}






