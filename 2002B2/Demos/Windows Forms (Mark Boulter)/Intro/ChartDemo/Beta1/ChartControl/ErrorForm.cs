namespace Charting {

    using System;
    using System.WinForms;
    using System.Drawing;

    /// <summary>
    ///    Summary description for Win32Form1.
    /// </summary>
    internal class ErrorForm : System.WinForms.Form {

        /// <summary> 
        ///    Required by the Win Forms designer 
        /// </summary>
	private System.ComponentModel.Container components;
    private System.WinForms.Button buttonClose;
    private System.WinForms.RichTextBox RichTextBoxErrors;
        
        public ErrorForm(string title) {

            // Required for Win Form Designer support
            InitializeComponent();


            // TODO: Add any constructor code after InitializeComponent call
            RichTextBoxErrors.Text = title;            
			RichTextBoxErrors.Select(0,0);
				
        }

        /// <summary>
        ///    Clean up any resources being used
        /// </summary>
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }


        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with an editor
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container ();
            this.RichTextBoxErrors = new System.WinForms.RichTextBox ();
            this.buttonClose = new System.WinForms.Button ();
            //@this.TrayHeight = 0;
            //@this.TrayLargeIcon = false;
            //@this.TrayAutoArrange = true;
            RichTextBoxErrors.Size = new System.Drawing.Size (622, 275);
            RichTextBoxErrors.BorderStyle = System.WinForms.BorderStyle.FixedSingle;
            RichTextBoxErrors.TabIndex = 1;
            RichTextBoxErrors.Font = new System.Drawing.Font ("Microsoft Sans Serif", 19, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            RichTextBoxErrors.Anchor = System.WinForms.AnchorStyles.All;
            RichTextBoxErrors.Location = new System.Drawing.Point (8, 24);
            buttonClose.Location = new System.Drawing.Point (534, 323);
            buttonClose.FlatStyle = System.WinForms.FlatStyle.Flat;
            buttonClose.Size = new System.Drawing.Size (96, 32);
            buttonClose.TabIndex = 2;
            buttonClose.Anchor = System.WinForms.AnchorStyles.BottomRight;
            buttonClose.Text = "Close";
            buttonClose.Click += new System.EventHandler (this.buttonClose_Click_1);
            this.Text = "Error";
            this.AutoScaleBaseSize = new System.Drawing.Size (8, 19);
            this.Font = new System.Drawing.Font ("Microsoft Sans Serif", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.AcceptButton = this.buttonClose;
            this.SizeGripStyle = System.WinForms.SizeGripStyle.Show;
            this.ClientSize = new System.Drawing.Size (648, 365);
            this.Controls.Add (this.buttonClose);
            this.Controls.Add (this.RichTextBoxErrors);
        }

        protected void buttonClose_Click_1 (object sender, System.EventArgs e)
        {
            this.Close();
        }

    protected void buttonClose_Click(object sender, System.EventArgs e)
	{
		this.Close();
	}
}

}


