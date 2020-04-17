//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
/*-----------------------------------------------------------------------

  File:      OCForm.cs

  Summary:   .Net client code for COM+ Object Construction Sample

---------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Microsoft.Samples.Technologies.ComponentServices.ObjectConstruction
{
    public class OCForm: Form
    {
        private Button constructButton;


        public OCForm()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.constructButton = new Button ();

            constructButton.Location = new System.Drawing.Point (80, 40);
            constructButton.Size = new System.Drawing.Size (96, 24);
            constructButton.TabIndex = 1;
            constructButton.Text = "Create Object";
            constructButton.Click += new EventHandler (this.Construct_Click);

            this.Text = "Object Construction String Demo";
			this.AutoScaleDimensions = new Size(5, 13);
            this.ClientSize = new System.Drawing.Size (270, 120);
            this.Controls.Add (this.constructButton);
        }
 
      
        private void Construct_Click (object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // The 'using' construct below results in a call to Dispose on exiting the 
                // curly braces. It could be replaced with an explicit call to Object.Dispose
                // This is a C#-specific construct.
                //
                // It is important to dispose COM+ objects as soon as possible so that
                // COM+ metadata such as context does not remain in memory unnecessarily
                // and so that COM+ services such as Object Pooling work properly.
                using(ObjectConstructionTest order = new ObjectConstructionTest())
                {
                    // this method will throw up a single message box
                    // but does not meaningful work.
                    order.DoWork();
                }      
            }

            catch (Exception ex)
            {
                MessageBox.Show("An exception was caught : "+ex.Message, "Error");
            }

            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        [STAThread]
        public static void Main(string[] args) 
        {
            Application.Run(new OCForm());
        }
    }
}