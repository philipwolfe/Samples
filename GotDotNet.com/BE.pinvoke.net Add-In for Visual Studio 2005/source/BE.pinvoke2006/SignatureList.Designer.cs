namespace BE.pinvoke2006
{
    partial class SignatureList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.moduleDescriptionLabel = new System.Windows.Forms.Label();
            this.signaturesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.alternativeApiLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // moduleDescriptionLabel
            // 
            this.moduleDescriptionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduleDescriptionLabel.Location = new System.Drawing.Point(3, 10);
            this.moduleDescriptionLabel.Name = "moduleDescriptionLabel";
            this.moduleDescriptionLabel.Size = new System.Drawing.Size(537, 40);
            this.moduleDescriptionLabel.TabIndex = 0;
            this.moduleDescriptionLabel.Text = "label1";
            // 
            // signaturesPanel
            // 
            this.signaturesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.signaturesPanel.AutoScroll = true;
            this.signaturesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.signaturesPanel.Location = new System.Drawing.Point(0, 53);
            this.signaturesPanel.Name = "signaturesPanel";
            this.signaturesPanel.Size = new System.Drawing.Size(543, 385);
            this.signaturesPanel.TabIndex = 1;
            this.signaturesPanel.WrapContents = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alternative Managed API:";
            // 
            // alternativeApiLabel
            // 
            this.alternativeApiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.alternativeApiLabel.Location = new System.Drawing.Point(157, 451);
            this.alternativeApiLabel.Name = "alternativeApiLabel";
            this.alternativeApiLabel.Size = new System.Drawing.Size(383, 56);
            this.alternativeApiLabel.TabIndex = 3;
            // 
            // SignatureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.alternativeApiLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signaturesPanel);
            this.Controls.Add(this.moduleDescriptionLabel);
            this.Name = "SignatureList";
            this.Size = new System.Drawing.Size(543, 507);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label moduleDescriptionLabel;
        private System.Windows.Forms.FlowLayoutPanel signaturesPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label alternativeApiLabel;
    }
}
