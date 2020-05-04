namespace WebNotesUI
{
    partial class WebNoteUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.Submit_btn = new System.Windows.Forms.Button ();
            this.Url_Text = new System.Windows.Forms.Label ();
            this.Note_Container = new System.Windows.Forms.TabControl ();
            this.tabPage1 = new System.Windows.Forms.TabPage ();
            this.NotesBox = new System.Windows.Forms.RichTextBox ();
            this.tabPage2 = new System.Windows.Forms.TabPage ();
            this.Notes_Viewer = new System.Windows.Forms.RichTextBox ();
            this.Note_Container.SuspendLayout ();
            this.tabPage1.SuspendLayout ();
            this.tabPage2.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // Submit_btn
            // 
            this.Submit_btn.Location = new System.Drawing.Point ( 343 , 226 );
            this.Submit_btn.Name = "Submit_btn";
            this.Submit_btn.Size = new System.Drawing.Size ( 75 , 23 );
            this.Submit_btn.TabIndex = 3;
            this.Submit_btn.Text = "Submit";
            this.Submit_btn.UseVisualStyleBackColor = true;
            this.Submit_btn.Click += new System.EventHandler ( this.Submit_btn_Click );
            // 
            // Url_Text
            // 
            this.Url_Text.AutoSize = true;
            this.Url_Text.Dock = System.Windows.Forms.DockStyle.Top;
            this.Url_Text.ForeColor = System.Drawing.Color.Blue;
            this.Url_Text.Location = new System.Drawing.Point ( 0 , 0 );
            this.Url_Text.Name = "Url_Text";
            this.Url_Text.Size = new System.Drawing.Size ( 26 , 13 );
            this.Url_Text.TabIndex = 4;
            this.Url_Text.Text = "Url: ";
            // 
            // Note_Container
            // 
            this.Note_Container.Controls.Add ( this.tabPage1 );
            this.Note_Container.Controls.Add ( this.tabPage2 );
            this.Note_Container.Location = new System.Drawing.Point ( 3 , 29 );
            this.Note_Container.Name = "Note_Container";
            this.Note_Container.SelectedIndex = 0;
            this.Note_Container.Size = new System.Drawing.Size ( 441 , 191 );
            this.Note_Container.TabIndex = 5;
            this.Note_Container.SelectedIndexChanged += new System.EventHandler ( this.Note_Container_SelectedIndexChanged );
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add ( this.NotesBox );
            this.tabPage1.Location = new System.Drawing.Point ( 4 , 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding ( 3 );
            this.tabPage1.Size = new System.Drawing.Size ( 433 , 165 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Notes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // NotesBox
            // 
            this.NotesBox.Location = new System.Drawing.Point ( -1 , 3 );
            this.NotesBox.Name = "NotesBox";
            this.NotesBox.Size = new System.Drawing.Size ( 435 , 159 );
            this.NotesBox.TabIndex = 1;
            this.NotesBox.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add ( this.Notes_Viewer );
            this.tabPage2.Location = new System.Drawing.Point ( 4 , 22 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding ( 3 );
            this.tabPage2.Size = new System.Drawing.Size ( 433 , 165 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View Notes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Notes_Viewer
            // 
            this.Notes_Viewer.Location = new System.Drawing.Point ( -1 , 0 );
            this.Notes_Viewer.Name = "Notes_Viewer";
            this.Notes_Viewer.Size = new System.Drawing.Size ( 435 , 160 );
            this.Notes_Viewer.TabIndex = 1;
            this.Notes_Viewer.Text = "";
            // 
            // WebNoteUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F , 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size ( 444 , 282 );
            this.Controls.Add ( this.Note_Container );
            this.Controls.Add ( this.Url_Text );
            this.Controls.Add ( this.Submit_btn );
            this.Name = "WebNoteUI";
            this.Text = "WebNoteUI";
            this.Load += new System.EventHandler ( this.WebNoteUI_Load );
            this.Note_Container.ResumeLayout ( false );
            this.tabPage1.ResumeLayout ( false );
            this.tabPage2.ResumeLayout ( false );
            this.ResumeLayout ( false );
            this.PerformLayout ();

        }

        #endregion

        private System.Windows.Forms.Button Submit_btn;
        private System.Windows.Forms.Label Url_Text;
        private System.Windows.Forms.TabControl Note_Container;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox NotesBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox Notes_Viewer;
    }
}