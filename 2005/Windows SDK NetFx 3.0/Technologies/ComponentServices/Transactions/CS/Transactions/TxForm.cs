/*=====================================================================
  File:      TXForm.cs

  Summary:   Windows.Forms Code for .NET COM+ Transactions Sample

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
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;

namespace Microsoft.Samples.Technologies.ComponentServices.Transactions
{
	/// <summary>
	/// This class handles the UI for the Transaction Sample
	/// </summary>
	public class TXForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label currentValueLabel;
		private System.Windows.Forms.TextBox currentValue;
		private System.Windows.Forms.Button post;
		private System.Windows.Forms.Button autoCompletePost;
		private System.Windows.Forms.TextBox newValue;
		private System.Windows.Forms.Label newValueLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public TXForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		
		}

		protected override void OnLoad(EventArgs e)
		{					
					try
					{
						// The 'using' construct below results in a call to Dispose on exiting the 
						// curly braces. It could be replaced with an explicit call to Object.Dispose
						// This is a C#-specific construct.
						//
						// It is important to dispose COM+ objects as soon as possible so that
						// COM+ metadata such as context does not remain in memory unnecessarily
						// and so that COM+ services such as Object Pooling work properly.
					    using( TXDemoServer txDemoServer = new TXDemoServer()) 
				           //we want the object to be disposed immediately
					   {
						// Retrieve & display the current value
						currentValue.Text = txDemoServer.RetrieveCurrentValue().ToString(CultureInfo.CurrentCulture);
					   }
					}
					catch(CurrentValueNotReadException)
					{
						MessageBox.Show("Unable to read the current value from the database" 
							, "Error");
						Application.Exit();
					}
					catch(Exception ex)
					{
						MessageBox.Show("An exception was caught : "+ex.Message + 
							"\nUnable to launch the COM+ Server. Closing the application." , 
								"Error");
						Application.Exit();
					}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.currentValueLabel = new System.Windows.Forms.Label();
            this.currentValue = new System.Windows.Forms.TextBox();
            this.post = new System.Windows.Forms.Button();
            this.autoCompletePost = new System.Windows.Forms.Button();
            this.newValue = new System.Windows.Forms.TextBox();
            this.newValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
// 
// currentValueLabel
// 
            this.currentValueLabel.Location = new System.Drawing.Point(8, 8);
            this.currentValueLabel.Name = "currentValueLabel";
            this.currentValueLabel.Size = new System.Drawing.Size(80, 16);
            this.currentValueLabel.TabIndex = 0;
            this.currentValueLabel.Text = "Current Value:";
// 
// currentValue
// 
            this.currentValue.Location = new System.Drawing.Point(88, 8);
            this.currentValue.Name = "currentValue";
            this.currentValue.ReadOnly = true;
            this.currentValue.TabIndex = 1;
            this.currentValue.TabStop = false;
// 
// post
// 
            this.post.Location = new System.Drawing.Point(8, 72);
            this.post.Name = "post";
            this.post.Size = new System.Drawing.Size(88, 23);
            this.post.TabIndex = 3;
            this.post.Text = "&Post";
            this.post.Click += new System.EventHandler(this.Post_Click);
// 
// autoCompletePost
// 
            this.autoCompletePost.Location = new System.Drawing.Point(104, 72);
            this.autoCompletePost.Name = "autoCompletePost";
            this.autoCompletePost.Size = new System.Drawing.Size(88, 23);
            this.autoCompletePost.TabIndex = 4;
            this.autoCompletePost.Text = "&AutoComplete";
            this.autoCompletePost.Click += new System.EventHandler(this.AutoCompletePost_Click);
// 
// newValue
// 
            this.newValue.Location = new System.Drawing.Point(88, 40);
            this.newValue.Name = "newValue";
            this.newValue.TabIndex = 2;
            this.newValue.Text = "5";
// 
// newValueLabel
// 
            this.newValueLabel.Location = new System.Drawing.Point(8, 40);
            this.newValueLabel.Name = "newValueLabel";
            this.newValueLabel.Size = new System.Drawing.Size(80, 16);
            this.newValueLabel.TabIndex = 5;
            this.newValueLabel.Text = "New Value:";
// 
// TXForm
// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
            this.ClientSize = new System.Drawing.Size(200, 101);
            this.Controls.Add(this.newValue);
            this.Controls.Add(this.newValueLabel);
            this.Controls.Add(this.autoCompletePost);
            this.Controls.Add(this.post);
            this.Controls.Add(this.currentValue);
            this.Controls.Add(this.currentValueLabel);
            this.Name = "TXForm";
            this.Text = "TXForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

		// Start the Post with a manual transaction if the user clicks on the 
		// Post button
		private void Post_Click(object sender, System.EventArgs e)
		{
			int val = 0;
			try
			{
				val = int.Parse(newValue.Text, CultureInfo.CurrentCulture);
			}
			catch
			{
				MessageBox.Show("Please enter a value to post!");
				return;
			}
			try
			{
				// The 'using' construct below results in a call to Dispose on exiting the 
				// curly braces. It could be replaced with an explicit call to Object.Dispose
				// This is a C#-specific construct.
				//
				// It is important to dispose COM+ objects as soon as possible so that
				// COM+ metadata such as context does not remain in memory unnecessarily
				// and so that COM+ services such as Object Pooling work properly.
			    using( TXDemoServer txDemoServer = new TXDemoServer())
			    //we want the object to be disposed immediately
			   {
		    		txDemoServer.Post(val);
			   }
			}
			catch(DatabaseExecutionException)
			{
				MessageBox.Show("Unable to update the database" , "Error");
				return;
			}
			catch(Exception ex)
			{
				MessageBox.Show("An exception was caught : "+ex.Message);
				return;
			}
			try
			{
				// The 'using' construct below results in a call to Dispose on exiting the 
				// curly braces. It could be replaced with an explicit call to Object.Dispose
				// This is a C#-specific construct.
				//
				// It is important to dispose COM+ objects as soon as possible so that
				// COM+ metadata such as context does not remain in memory unnecessarily
				// and so that COM+ services such as Object Pooling work properly.
				using( TXDemoServer txDemoServer = new TXDemoServer())
				//we want the object to be disposed immediately
				{
					currentValue.Text = txDemoServer.RetrieveCurrentValue().ToString(CultureInfo.CurrentCulture);
				}
			}
			catch(CurrentValueNotReadException)
			{
				MessageBox.Show("Unable to read the current value from the database" ,
										"Error");
				return;
			}
		}

		//Start the Post with automatic transaction if the user clicks on the 
		//autoCompletePost button
		private void AutoCompletePost_Click(object sender, System.EventArgs e)
		{
			int val = 0;
			try
			{
				val = int.Parse(newValue.Text, CultureInfo.CurrentCulture);
			}
			catch
			{
				MessageBox.Show("Please enter a value to post!");
				return;
			}
			try
			{
				// The 'using' construct below results in a call to Dispose on exiting the 
				// curly braces. It could be replaced with an explicit call to Object.Dispose
				// This is a C#-specific construct.
				//
				// It is important to dispose COM+ objects as soon as possible so that
				// COM+ metadata such as context does not remain in memory unnecessarily
				// and so that COM+ services such as Object Pooling work properly.
				using( TXDemoServer txDemoServer = new TXDemoServer())
				//we want the object to be disposed immediately
				{
					txDemoServer.AutoCompletePost(val);
				}
			}
			catch(ValueOutOfRangeException)
			{
				MessageBox.Show("The transaction has been aborted by throwing an " +
											"AbortTransactionException" , "No Error");
			}
			catch(DatabaseExecutionException)
			{
				MessageBox.Show("Unable to update the database" , "Error");
				return;
			}
			catch(Exception ex)
			{
						MessageBox.Show("An exception was caught : " + ex.Message);
						return;
			}
			try
			{
				// The 'using' construct below results in a call to Dispose on exiting the 
				// curly braces. It could be replaced with an explicit call to Object.Dispose
				// This is a C#-specific construct.
				//
				// It is important to dispose COM+ objects as soon as possible so that
				// COM+ metadata such as context does not remain in memory unnecessarily
				// and so that COM+ services such as Object Pooling work properly.
				using( TXDemoServer txDemoServer = new TXDemoServer())
				//we want the object to be disposed immediately
				{
					currentValue.Text = txDemoServer.RetrieveCurrentValue().ToString(CultureInfo.CurrentCulture);
				}
			}
			catch(CurrentValueNotReadException)
			{
				MessageBox.Show("Unable to read the current value from the database" ,
										"Error");
				return;
			}
		}

        [STAThread]
		private static void Main(String[] args)
		{
			Application.Run(new TXForm());
		}
	}
}
