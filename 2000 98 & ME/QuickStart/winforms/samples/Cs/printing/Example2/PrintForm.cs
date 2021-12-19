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

    public class PrintForm : System.WinForms.Form {
        private System.ComponentModel.Container components;
	    private System.WinForms.Button printButton;

        public PrintForm() : base() {
            // This call is required by the Windows Forms Designer.
            InitializeComponent();
        }
    

        //Event fired when the user presses the print button
        private void printButton_Click(object sender, EventArgs e) {
            try {
                
                StreamReader streamToPrint = new StreamReader ("PrintMe.Txt");
                try {
                    TextFilePrintDocument pd = new TextFilePrintDocument(streamToPrint); //Assumes the default printer
                    pd.Print();
                } finally {
                    streamToPrint.Close() ;
                }

            } catch(Exception ex) { 
                MessageBox.Show("An error occurred printing the file - " + ex.Message);
            }
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
    		this.Text = "Print Example 2";
    		
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
            Application.Run(new PrintForm());
        }

    }
}





