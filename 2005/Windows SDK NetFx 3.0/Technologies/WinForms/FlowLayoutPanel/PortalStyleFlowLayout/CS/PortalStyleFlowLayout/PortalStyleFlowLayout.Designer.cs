namespace Microsoft.Samples.Windows.Forms.PortalStyleFlowLayout
{
    partial class MainPortal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.portalElement1 = new Microsoft.Samples.Windows.Forms.PortalStyleFlowLayout.PortalElement();
            this.buttonAddPortalElement = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.portalElement1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-1, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(486, 408);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // portalElement1
            // 
            this.portalElement1.AutoSize = true;
            this.portalElement1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.portalElement1.Location = new System.Drawing.Point(3, 3);
            this.portalElement1.Name = "portalElement1";
            this.portalElement1.Size = new System.Drawing.Size(183, 175);
            this.portalElement1.TabIndex = 0;
            // 
            // buttonAddPortalElement
            // 
            this.buttonAddPortalElement.Location = new System.Drawing.Point(12, 12);
            this.buttonAddPortalElement.Name = "buttonAddPortalElement";
            this.buttonAddPortalElement.Size = new System.Drawing.Size(186, 23);
            this.buttonAddPortalElement.TabIndex = 1;
            this.buttonAddPortalElement.Text = "Add New Element";
            this.buttonAddPortalElement.Click += new System.EventHandler(this.buttonAddPortalElement_Click);
            // 
            // MainPortal
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(185)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(482, 448);
            this.Controls.Add(this.buttonAddPortalElement);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainPortal";
            this.Text = "Portal Style Demo";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonAddPortalElement;
        private PortalElement portalElement1;

    }
}

