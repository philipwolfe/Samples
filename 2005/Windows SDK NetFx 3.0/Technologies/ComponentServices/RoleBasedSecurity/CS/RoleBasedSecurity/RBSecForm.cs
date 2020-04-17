/*=====================================================================
  File:      RBSecForm.cs

  Summary:   Client for Role-Based Security Demo

---------------------------------------------------------------------
  This file is part of the Microsoft .NET Framework SDK Code Samples.

  Copyright (C) Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.EnterpriseServices;

namespace Microsoft.Samples.Technologies.ComponentServices.RoleBasedSecurity
{
    public class RBSecForm: Form
    {
        private Button whoAmI;
        private Button amInRole;
        private Label label;

        public RBSecForm()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.whoAmI  = new Button();
            this.amInRole = new Button();
            this.label     = new Label();

            whoAmI.Location = new System.Drawing.Point(40, 40);
            whoAmI.Size    = new System.Drawing.Size(150, 24);
            whoAmI.TabIndex= 1;
            whoAmI.Text    = "Display Logged On User";
            whoAmI.Click  += new EventHandler (this.WhoAmI_Click);

            amInRole.Location = new System.Drawing.Point (40, 70);
            amInRole.Size     = new System.Drawing.Size (150, 24);
            amInRole.TabIndex = 1;
            amInRole.Text     = "Is Caller In Demo Role?";
            amInRole.Click   += new EventHandler (this.AmInRole_Click);

            label.Location = new System.Drawing.Point (24, 10);
            label.Size    = new System.Drawing.Size (210, 24);

            this.Text = "Role-Based Security Demo";
            this.AutoScaleDimensions = new System.Drawing.SizeF (5, 13);
            this.ClientSize = new System.Drawing.Size (250, 150);
            this.Controls.Add (this.whoAmI);
            this.Controls.Add (this.amInRole);
            this.Controls.Add (this.label);
        }

       
        private void WhoAmI_Click (object sender, System.EventArgs e)
        {
            label.Text = "";
            this.Cursor = Cursors.WaitCursor;
 
            try 
            {        
                // The using keyword is to have the COM+ object disposed 
                // directly when finished running the code inside the using section.
                // This is to release the COM+ Object on the server as soon as 
                // possible.
                using (RBSecurityObject test = new RBSecurityObject())
                {
                    label.Text = test.WhoIsCaller();
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not create RBSecurityObject");
            }
            finally
            {                
                this.Cursor = Cursors.Arrow;
            }
        }

        
        private void AmInRole_Click (object sender, System.EventArgs e)
        {
            label.Text = "";
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
                using(RBSecurityObject test = new RBSecurityObject())
                {
                    if (test.IsCallerInDemoRole())
                    {
                        label.Text = "You ARE in RBSecurityDemoRole";
                    } 
                    else 
                    {
                        label.Text = "You are NOT in RBSecurityDemoRole";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not create RBSecurityObject");
            }
            finally
            {                
                this.Cursor = Cursors.Arrow;
            }
        }
       

        [STAThread]
        public static void Main(string[] args) 
        {
            Application.Run(new RBSecForm());
        }
    }
}