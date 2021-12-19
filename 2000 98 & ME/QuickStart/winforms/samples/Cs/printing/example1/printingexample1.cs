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
namespace Microsoft.Samples.WinForms.Cs.PrintingExample1 {
    using System;
    using System.ComponentModel;
    using System.WinForms;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;

    public class PrintingExample1 : System.WinForms.Form {
        private System.ComponentModel.Container components;
	    private System.WinForms.Button printButton;

        private Font printFont;
        private StreamReader streamToPrint;


        public PrintingExample1() : base() {
            // This call is required by the Windows Forms Designer.
            InitializeComponent();
        }


        //Event fired when the user presses the print button
        private void printButton_Click(object sender, EventArgs e) {
            try {
                
                streamToPrint = new StreamReader ("PrintMe.Txt");
                try {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument(); //Assumes the default printer
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                    pd.Print();
                } finally {
                    streamToPrint.Close() ;
                }

            } catch(Exception ex) { 
                MessageBox.Show("An error occurred printing the file - " + ex.Message);
            }
        }

        //Event fired for each page to print
        private void pd_PrintPage(object sender, PrintPageEventArgs ev) {
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


        // <doc>
        // <desc>
        //     PrintCtl overrides dispose so it can clean up the
        //     component list.
        // </desc>
        // </doc>
        //
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }
    

        // NOTE: The following code is required by the Windows Forms Form Designer
        // It can be modified using the Windows Forms Form Designer.  
        // Do not modify it using the code editor.
        private void InitializeComponent() {
		
    		this.components = new System.ComponentModel.Container();
    		this.printButton = new System.WinForms.Button();
    		
    		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    		this.ClientSize = new System.Drawing.Size(504, 381);
    		this.Text = "Print Example 1";
    		
    		printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
    		printButton.Location = new System.Drawing.Point(32, 110);
    		printButton.FlatStyle = System.WinForms.FlatStyle.Flat;
    		printButton.TabIndex = 0;
    		printButton.Text = "Print the file";
    		printButton.Size = new System.Drawing.Size(136, 40);
    		printButton.Click += new System.EventHandler(printButton_Click);
    		
    		this.Controls.Add(printButton);
    		
    	}

        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new PrintingExample1());
        }

    }
}






