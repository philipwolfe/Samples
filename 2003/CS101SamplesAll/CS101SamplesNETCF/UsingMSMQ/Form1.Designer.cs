namespace UsingMSMQ
{
    partial class Form1
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
            this.ReceiveButton = new System.Windows.Forms.Button();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ReceivedListBox = new System.Windows.Forms.ListBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReceiveButton
            // 
            this.ReceiveButton.Location = new System.Drawing.Point(182, 3);
            this.ReceiveButton.Name = "ReceiveButton";
            this.ReceiveButton.Size = new System.Drawing.Size(55, 20);
            this.ReceiveButton.TabIndex = 6;
            this.ReceiveButton.Text = "Receive";
            this.ReceiveButton.Click += new System.EventHandler(this.ReceiveButton_Click);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 246);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 22);
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label4.Location = new System.Drawing.Point(3, 64);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(234, 12);
            this.Label4.Text = "Click \"Receive\" to remove messages from que.";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Label3.Location = new System.Drawing.Point(3, 47);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(234, 12);
            this.Label3.Text = "Click \"Send\" to add messages to que. ";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.Panel1.Controls.Add(this.ReceivedListBox);
            this.Panel1.Controls.Add(this.ReceiveButton);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Location = new System.Drawing.Point(0, 79);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(240, 167);
            // 
            // ReceivedListBox
            // 
            this.ReceivedListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ReceivedListBox.Location = new System.Drawing.Point(0, 25);
            this.ReceivedListBox.Name = "ReceivedListBox";
            this.ReceivedListBox.Size = new System.Drawing.Size(240, 142);
            this.ReceivedListBox.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(0, 3);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(128, 20);
            this.Label2.Text = "Messages Received";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(198, 23);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(39, 20);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send";
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // SendTextBox
            // 
            this.SendTextBox.Location = new System.Drawing.Point(3, 22);
            this.SendTextBox.Name = "SendTextBox";
            this.SendTextBox.Size = new System.Drawing.Size(189, 21);
            this.SendTextBox.TabIndex = 8;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(3, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 20);
            this.Label1.Text = "Message:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.SendTextBox);
            this.Controls.Add(this.Label1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ReceiveButton;
        internal System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ListBox ReceivedListBox;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.MainMenu mainMenu1;
        internal System.Windows.Forms.TextBox SendTextBox;
        internal System.Windows.Forms.Label Label1;

    }
}

