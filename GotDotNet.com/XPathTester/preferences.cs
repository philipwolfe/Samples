using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XPathTester
{
	/// <summary>
	/// Summary description for preferences.
	/// </summary>
	public class preferences : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private userPreferences _currentValues;
		private System.Windows.Forms.PropertyGrid preferenceProperties;
		private userPreferences _newValues;

		public preferences(userPreferences currentValues)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			_currentValues = currentValues;
			_newValues = new userPreferences();

			// a method to clone the userpreferences object would be useful here, if it were bigger
			_newValues.ContextNodeColor = _currentValues.ContextNodeColor;
			_newValues.MatchNodeColor = _currentValues.MatchNodeColor;
			_newValues.EvaluateExpressionsInteractively = _currentValues.EvaluateExpressionsInteractively;

			SetUIFromCurrentPreferences();
		}

		// set the UI of the form from the current user preferences
		private void SetUIFromCurrentPreferences()
		{
			preferenceProperties.SelectedObject = _newValues;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(preferences));
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.preferenceProperties = new System.Windows.Forms.PropertyGrid();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okButton.Location = new System.Drawing.Point(134, 152);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(80, 24);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelButton.Location = new System.Drawing.Point(216, 152);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(80, 24);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// preferenceProperties
			// 
			this.preferenceProperties.CommandsVisibleIfAvailable = true;
			this.preferenceProperties.LargeButtons = false;
			this.preferenceProperties.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.preferenceProperties.Location = new System.Drawing.Point(8, 8);
			this.preferenceProperties.Name = "preferenceProperties";
			this.preferenceProperties.Size = new System.Drawing.Size(288, 136);
			this.preferenceProperties.TabIndex = 2;
			this.preferenceProperties.Text = "propertyGrid1";
			this.preferenceProperties.ToolbarVisible = false;
			this.preferenceProperties.ViewBackColor = System.Drawing.SystemColors.Window;
			this.preferenceProperties.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// preferences
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(306, 184);
			this.Controls.Add(this.preferenceProperties);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "preferences";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "preferences";
			this.ResumeLayout(false);

		}
		#endregion

		private void pickContextNodeColourButton_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			_newValues.ContextNodeColor = SetColour(_newValues.ContextNodeColor);
			SetUIFromCurrentPreferences();
		}

		// show a colour find dialog - return the colour selected if the user clicks OK
		private System.Drawing.Color SetColour(System.Drawing.Color currentColour)
		{
			System.Windows.Forms.ColorDialog colourSelector = new System.Windows.Forms.ColorDialog();
			colourSelector.Color = currentColour;
			System.Windows.Forms.DialogResult result = colourSelector.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
			{
				return colourSelector.Color;
			}
			else 
			{
				return currentColour;
			}
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			SaveSettings();
		}

		protected void SaveSettings()
		{
			try 
			{
				_newValues.SaveSettings();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("There was an unexpected error saving the preferences. " + ex.Message, "Error Saving Preferences", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
			}
			_currentValues.MatchNodeColor = _newValues.MatchNodeColor;
			_currentValues.ContextNodeColor = _newValues.ContextNodeColor;
			_currentValues.EvaluateExpressionsInteractively = _newValues.EvaluateExpressionsInteractively;
			this.Close();
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			_newValues.MatchNodeColor = SetColour(_newValues.MatchNodeColor);
			SetUIFromCurrentPreferences();
		}
	}
}
