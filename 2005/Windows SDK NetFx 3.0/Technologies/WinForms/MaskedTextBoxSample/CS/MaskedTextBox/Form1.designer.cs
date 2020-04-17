//---------------------------------------------------------------------
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
//---------------------------------------------------------------------

namespace Microsoft.Samples
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.maskCompletedStatusStripPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.maskFullStatusStripPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.copyMaskFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textMaskFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.insertKeyModeCheckBox = new System.Windows.Forms.CheckBox();
            this.beepOnErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.hidePromptOnLeaveCheckBox = new System.Windows.Forms.CheckBox();
            this.promptCharComboBox = new System.Windows.Forms.ComboBox();
            this.promptCharLabel = new System.Windows.Forms.Label();
            this.useSystemPasswordCharCheckBox = new System.Windows.Forms.CheckBox();
            this.eventLogTextBox = new System.Windows.Forms.TextBox();
            this.eventLogLabel = new System.Windows.Forms.Label();
            this.passwordCharLabel = new System.Windows.Forms.Label();
            this.passwordCharCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.propertiesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maskCompletedStatusStripPanel,
            this.maskFullStatusStripPanel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(522, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // maskCompletedStatusStripPanel
            // 
            this.maskCompletedStatusStripPanel.Name = "maskCompletedStatusStripPanel";
            this.maskCompletedStatusStripPanel.Size = new System.Drawing.Size(85, 17);
            this.maskCompletedStatusStripPanel.Text = "Mask Completed";
            // 
            // maskFullStatusStripPanel
            // 
            this.maskFullStatusStripPanel.Name = "maskFullStatusStripPanel";
            this.maskFullStatusStripPanel.Size = new System.Drawing.Size(50, 17);
            this.maskFullStatusStripPanel.Text = "Mask Full";
            // 
            // propertiesGroupBox
            // 
            this.propertiesGroupBox.Controls.Add(this.copyMaskFormatComboBox);
            this.propertiesGroupBox.Controls.Add(this.label4);
            this.propertiesGroupBox.Controls.Add(this.textMaskFormatComboBox);
            this.propertiesGroupBox.Controls.Add(this.label3);
            this.propertiesGroupBox.Controls.Add(this.insertKeyModeCheckBox);
            this.propertiesGroupBox.Controls.Add(this.beepOnErrorCheckBox);
            this.propertiesGroupBox.Controls.Add(this.hidePromptOnLeaveCheckBox);
            this.propertiesGroupBox.Controls.Add(this.promptCharComboBox);
            this.propertiesGroupBox.Controls.Add(this.promptCharLabel);
            this.propertiesGroupBox.Controls.Add(this.useSystemPasswordCharCheckBox);
            this.propertiesGroupBox.Controls.Add(this.eventLogTextBox);
            this.propertiesGroupBox.Controls.Add(this.eventLogLabel);
            this.propertiesGroupBox.Controls.Add(this.passwordCharLabel);
            this.propertiesGroupBox.Controls.Add(this.passwordCharCombo);
            this.propertiesGroupBox.Location = new System.Drawing.Point(11, 66);
            this.propertiesGroupBox.Name = "propertiesGroupBox";
            this.propertiesGroupBox.Size = new System.Drawing.Size(499, 310);
            this.propertiesGroupBox.TabIndex = 1;
            this.propertiesGroupBox.TabStop = false;
            this.propertiesGroupBox.Text = "Properties";
            // 
            // copyMaskFormatComboBox
            // 
            this.copyMaskFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.copyMaskFormatComboBox.DropDownWidth = 150;
            this.copyMaskFormatComboBox.FormattingEnabled = true;
            this.copyMaskFormatComboBox.Location = new System.Drawing.Point(373, 111);
            this.copyMaskFormatComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.copyMaskFormatComboBox.Name = "copyMaskFormatComboBox";
            this.copyMaskFormatComboBox.Size = new System.Drawing.Size(116, 21);
            this.copyMaskFormatComboBox.TabIndex = 7;
            this.toolTip1.SetToolTip(this.copyMaskFormatComboBox, "Setting the CutCopyMaskFormat property changes whether \r\nprompt and / or literal " +
                    "characters are included in the \r\nstring captured on cut and copy operations.");
            this.copyMaskFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.copyMaskFormatComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Mask Format in Copy";
            this.toolTip1.SetToolTip(this.label4, "Setting the CutCopyMaskFormat property changes whether \r\nprompt and / or literal " +
                    "characters are included in the \r\nstring captured on cut and copy operations.");
            // 
            // textMaskFormatComboBox
            // 
            this.textMaskFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textMaskFormatComboBox.DropDownWidth = 150;
            this.textMaskFormatComboBox.FormattingEnabled = true;
            this.textMaskFormatComboBox.Location = new System.Drawing.Point(373, 80);
            this.textMaskFormatComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textMaskFormatComboBox.Name = "textMaskFormatComboBox";
            this.textMaskFormatComboBox.Size = new System.Drawing.Size(116, 21);
            this.textMaskFormatComboBox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.textMaskFormatComboBox, "Setting the TextMaskFormat property changes whether \r\nprompt and / or literal cha" +
                    "racters are included in \r\nthe Text property.");
            this.textMaskFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.textMaskFormatComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mask Format in Text";
            this.toolTip1.SetToolTip(this.label3, "Setting the TextMaskFormat property changes whether \r\nprompt and / or literal cha" +
                    "racters are included in \r\nthe Text property.");
            // 
            // insertKeyModeCheckBox
            // 
            this.insertKeyModeCheckBox.Location = new System.Drawing.Point(7, 109);
            this.insertKeyModeCheckBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.insertKeyModeCheckBox.Name = "insertKeyModeCheckBox";
            this.insertKeyModeCheckBox.Size = new System.Drawing.Size(157, 24);
            this.insertKeyModeCheckBox.TabIndex = 3;
            this.insertKeyModeCheckBox.Text = "Insert key mode";
            this.toolTip1.SetToolTip(this.insertKeyModeCheckBox, resources.GetString("insertKeyModeCheckBox.ToolTip"));
            this.insertKeyModeCheckBox.CheckedChanged += new System.EventHandler(this.propertyCheckBox_CheckedChanged);
            // 
            // beepOnErrorCheckBox
            // 
            this.beepOnErrorCheckBox.Location = new System.Drawing.Point(7, 78);
            this.beepOnErrorCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.beepOnErrorCheckBox.Name = "beepOnErrorCheckBox";
            this.beepOnErrorCheckBox.Size = new System.Drawing.Size(104, 24);
            this.beepOnErrorCheckBox.TabIndex = 2;
            this.beepOnErrorCheckBox.Text = "Beep on error";
            this.toolTip1.SetToolTip(this.beepOnErrorCheckBox, "Setting the BeepOnError property to true causes the\r\nMaskedTextBox to play a beep" +
                    " when a character is \r\nentered that does not conform to the the mask.");
            this.beepOnErrorCheckBox.CheckedChanged += new System.EventHandler(this.propertyCheckBox_CheckedChanged);
            // 
            // hidePromptOnLeaveCheckBox
            // 
            this.hidePromptOnLeaveCheckBox.Location = new System.Drawing.Point(7, 47);
            this.hidePromptOnLeaveCheckBox.Name = "hidePromptOnLeaveCheckBox";
            this.hidePromptOnLeaveCheckBox.Size = new System.Drawing.Size(157, 24);
            this.hidePromptOnLeaveCheckBox.TabIndex = 1;
            this.hidePromptOnLeaveCheckBox.Text = "Hide prompt on leave";
            this.toolTip1.SetToolTip(this.hidePromptOnLeaveCheckBox, "Setting the HidePromptOnLeave property causes the \r\nprompt characters to be hidde" +
                    "n when the MaskedTextBox \r\nloses focus.");
            this.hidePromptOnLeaveCheckBox.CheckedChanged += new System.EventHandler(this.propertyCheckBox_CheckedChanged);
            // 
            // promptCharComboBox
            // 
            this.promptCharComboBox.FormattingEnabled = true;
            this.promptCharComboBox.Location = new System.Drawing.Point(373, 49);
            this.promptCharComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.promptCharComboBox.Name = "promptCharComboBox";
            this.promptCharComboBox.Size = new System.Drawing.Size(116, 21);
            this.promptCharComboBox.TabIndex = 5;
            this.toolTip1.SetToolTip(this.promptCharComboBox, "Setting the PromptChar property changes all the \r\nprompt characters in the Masked" +
                    "TextBox to the \r\nspecified character.");
            this.promptCharComboBox.SelectedIndexChanged += new System.EventHandler(this.promptCharComboBox_SelectedIndexChanged);
            // 
            // promptCharLabel
            // 
            this.promptCharLabel.AutoSize = true;
            this.promptCharLabel.Location = new System.Drawing.Point(258, 52);
            this.promptCharLabel.Name = "promptCharLabel";
            this.promptCharLabel.Size = new System.Drawing.Size(89, 13);
            this.promptCharLabel.TabIndex = 11;
            this.promptCharLabel.Text = "Prompt Character";
            this.toolTip1.SetToolTip(this.promptCharLabel, "Setting the PromptChar property changes all the \r\nprompt characters in the Masked" +
                    "TextBox to the \r\nspecified character.");
            // 
            // useSystemPasswordCharCheckBox
            // 
            this.useSystemPasswordCharCheckBox.Location = new System.Drawing.Point(7, 16);
            this.useSystemPasswordCharCheckBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.useSystemPasswordCharCheckBox.Name = "useSystemPasswordCharCheckBox";
            this.useSystemPasswordCharCheckBox.Size = new System.Drawing.Size(202, 24);
            this.useSystemPasswordCharCheckBox.TabIndex = 0;
            this.useSystemPasswordCharCheckBox.Text = "Use system password character";
            this.toolTip1.SetToolTip(this.useSystemPasswordCharCheckBox, resources.GetString("useSystemPasswordCharCheckBox.ToolTip"));
            this.useSystemPasswordCharCheckBox.CheckedChanged += new System.EventHandler(this.propertyCheckBox_CheckedChanged);
            // 
            // eventLogTextBox
            // 
            this.eventLogTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.eventLogTextBox.Location = new System.Drawing.Point(6, 153);
            this.eventLogTextBox.Multiline = true;
            this.eventLogTextBox.Name = "eventLogTextBox";
            this.eventLogTextBox.ReadOnly = true;
            this.eventLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventLogTextBox.Size = new System.Drawing.Size(487, 151);
            this.eventLogTextBox.TabIndex = 8;
            this.toolTip1.SetToolTip(this.eventLogTextBox, "The Event Log TextBox will echo the MaskInputRejected and \r\nTypeValidationFailed " +
                    "events.");
            // 
            // eventLogLabel
            // 
            this.eventLogLabel.AutoSize = true;
            this.eventLogLabel.Location = new System.Drawing.Point(4, 136);
            this.eventLogLabel.Name = "eventLogLabel";
            this.eventLogLabel.Size = new System.Drawing.Size(59, 13);
            this.eventLogLabel.TabIndex = 3;
            this.eventLogLabel.Text = "Event Log:";
            this.toolTip1.SetToolTip(this.eventLogLabel, "The Event Log TextBox will echo the MaskInputRejected and \r\nTypeValidationFailed " +
                    "events.");
            // 
            // passwordCharLabel
            // 
            this.passwordCharLabel.AutoSize = true;
            this.passwordCharLabel.Location = new System.Drawing.Point(258, 22);
            this.passwordCharLabel.Name = "passwordCharLabel";
            this.passwordCharLabel.Size = new System.Drawing.Size(102, 13);
            this.passwordCharLabel.TabIndex = 0;
            this.passwordCharLabel.Text = "Password Character";
            this.toolTip1.SetToolTip(this.passwordCharLabel, resources.GetString("passwordCharLabel.ToolTip"));
            // 
            // passwordCharCombo
            // 
            this.passwordCharCombo.FormattingEnabled = true;
            this.passwordCharCombo.Location = new System.Drawing.Point(373, 19);
            this.passwordCharCombo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.passwordCharCombo.Name = "passwordCharCombo";
            this.passwordCharCombo.Size = new System.Drawing.Size(116, 21);
            this.passwordCharCombo.TabIndex = 4;
            this.toolTip1.SetToolTip(this.passwordCharCombo, resources.GetString("passwordCharCombo.ToolTip"));
            this.passwordCharCombo.SelectedIndexChanged += new System.EventHandler(this.passwordCharCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Enter IP Address:";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(225, 26);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.maskedTextBox1.Mask = "099.099.099.099";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(137, 20);
            this.maskedTextBox1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.maskedTextBox1, resources.GetString("maskedTextBox1.ToolTip"));
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            this.maskedTextBox1.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.maskedTextBox1_TypeValidationCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Text Property:";
            this.toolTip1.SetToolTip(this.label2, "The Text property of the TextBox is set to the Text \r\nproperty of the MaskedTextB" +
                    "ox above.");
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.outputTextBox.Location = new System.Drawing.Point(224, 401);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(138, 20);
            this.outputTextBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.outputTextBox, "The Text property of the TextBox is set to the Text \r\nproperty of the MaskedTextB" +
                    "ox above.");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create IP Object";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(522, 464);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.propertiesGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "MaskedTextBox Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.propertiesGroupBox.ResumeLayout(false);
            this.propertiesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel maskCompletedStatusStripPanel;
		private System.Windows.Forms.ToolStripStatusLabel maskFullStatusStripPanel;
        private System.Windows.Forms.GroupBox propertiesGroupBox;
        private System.Windows.Forms.Label passwordCharLabel;
        private System.Windows.Forms.ComboBox passwordCharCombo;
        private System.Windows.Forms.TextBox eventLogTextBox;
        private System.Windows.Forms.Label eventLogLabel;
		private System.Windows.Forms.CheckBox useSystemPasswordCharCheckBox;
        private System.Windows.Forms.CheckBox hidePromptOnLeaveCheckBox;
        private System.Windows.Forms.CheckBox beepOnErrorCheckBox;
        private System.Windows.Forms.CheckBox insertKeyModeCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label promptCharLabel;
        private System.Windows.Forms.ComboBox promptCharComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox copyMaskFormatComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox textMaskFormatComboBox;
		private System.Windows.Forms.Label label3;
    }
}