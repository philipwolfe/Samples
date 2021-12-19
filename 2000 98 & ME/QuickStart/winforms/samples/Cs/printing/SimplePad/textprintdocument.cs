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
namespace Microsoft.Samples.WinForms.Cs.SimplePad {
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
    public class TextPrintDocument : PrintDocument {

        private Font printFont             = null ;
        private StringReader streamToPrint = null ;
        private string overflowText        = null;

        public TextPrintDocument(StringReader streamToPrint) : base ()  {
            this.streamToPrint = streamToPrint ;
        }

        //Override OnBeginPrint to set up the font we are going to use
        protected override void OnBeginPrint(PrintEventArgs ev) {
            base.OnBeginPrint(ev) ;

            //TODO: Pick up font from RichText
            printFont = new Font("Arial", 10);

            overflowText = null;
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

            //If we have overflow text from the last page deal with that first
            while (count < lpp && overflowText != null) {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                int linesPrinted = PrintLine(ev,overflowText, yPos);
                count += linesPrinted;
            }

            //Now iterate over the file printing out each line
            //Check count first so that we don't read line that we won't print
            while (count < lpp && ((line=streamToPrint.ReadLine()) != null)) {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                int linesPrinted = PrintLine(ev,line, yPos);
                count += linesPrinted;
            }

            //If we have more lines then print another page
            if (line != null) 
                ev.HasMorePages = true ;
            else 
                ev.HasMorePages = false ;
        }


        private int PrintLine(PrintPageEventArgs e, string text, float yStartPos) {
            Graphics graphics = e.Graphics;
            Margins margins = e.PageSettings.Margins;
            StringFormat format = new StringFormat();
            int lines;
            int characters;
            RectangleF rectangle = new RectangleF(margins.Left, 
                                    yStartPos,
                                    e.MarginBounds.Width, 
                                    e.MarginBounds.Height);
                                   
            graphics.MeasureString(text, printFont, rectangle.Size, format, out characters, out lines);

            Console.WriteLine("Chars " + characters);
            Console.WriteLine("Text " + text.Length);

            //If characters is less than string.length then we can't fit the whole
            //paragraph on the page so print what we can and store the rest for the
            //next page
            if (characters < text.Length) {
                overflowText = text.Substring(characters);
                MessageBox.Show(overflowText);
            } else {
                overflowText = null;
            }

            //NOTE WELL: In the PDC Release you must pass a StringFormat to DrawString or the 
            //Print Preview control will not work. 
            graphics.DrawString(text, printFont, Brushes.Black, rectangle, format);


            //Cope with empty lines
            if (lines == 0 ) 
                lines = 1;

            return lines;
        }

    }

}






