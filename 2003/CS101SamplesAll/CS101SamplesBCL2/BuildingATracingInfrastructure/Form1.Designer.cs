namespace BuildingATracingInfrastructure {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.webServiceButton = new System.Windows.Forms.Button();
            this.webServiceDelayTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.serverNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.databaseButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.longProcessButton = new System.Windows.Forms.Button();
            this.longProcessDelayTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.webServiceButton);
            this.panel1.Controls.Add(this.webServiceDelayTextBox);
            this.panel1.Location = new System.Drawing.Point(32, 361);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 139);
            this.panel1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(34, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(402, 45);
            this.label5.TabIndex = 1;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Retrieve Data from a Web Service";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Delay (secs.)";
            // 
            // webServiceButton
            // 
            this.webServiceButton.Location = new System.Drawing.Point(286, 97);
            this.webServiceButton.Name = "webServiceButton";
            this.webServiceButton.Size = new System.Drawing.Size(136, 23);
            this.webServiceButton.TabIndex = 4;
            this.webServiceButton.Text = "Access Web Service";
            this.webServiceButton.UseVisualStyleBackColor = true;
            this.webServiceButton.Click += new System.EventHandler(this.webServiceButton_Click);
            // 
            // webServiceDelayTextBox
            // 
            this.webServiceDelayTextBox.Location = new System.Drawing.Point(136, 97);
            this.webServiceDelayTextBox.Name = "webServiceDelayTextBox";
            this.webServiceDelayTextBox.Size = new System.Drawing.Size(121, 20);
            this.webServiceDelayTextBox.TabIndex = 3;
            this.webServiceDelayTextBox.Text = "2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(535, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.serverNamecomboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.databaseButton);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(32, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 139);
            this.panel2.TabIndex = 1;
            // 
            // serverNamecomboBox
            // 
            this.serverNamecomboBox.FormattingEnabled = true;
            this.serverNamecomboBox.Items.AddRange(new object[] {
            "AvailableServer",
            "UnavailableServer"});
            this.serverNamecomboBox.Location = new System.Drawing.Point(136, 93);
            this.serverNamecomboBox.Name = "serverNamecomboBox";
            this.serverNamecomboBox.Size = new System.Drawing.Size(121, 21);
            this.serverNamecomboBox.TabIndex = 3;
            this.serverNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.serverNamecomboBox_SelectedIndexChanged);
            this.serverNamecomboBox.TextChanged += new System.EventHandler(this.serverNamecomboBox_SelectedIndexChanged);
            this.serverNamecomboBox.TextUpdate += new System.EventHandler(this.serverNamecomboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server name";
            // 
            // databaseButton
            // 
            this.databaseButton.Location = new System.Drawing.Point(286, 91);
            this.databaseButton.Name = "databaseButton";
            this.databaseButton.Size = new System.Drawing.Size(136, 23);
            this.databaseButton.TabIndex = 4;
            this.databaseButton.Text = "Connect to Database";
            this.databaseButton.UseVisualStyleBackColor = true;
            this.databaseButton.Click += new System.EventHandler(this.databaseButton_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(34, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(402, 43);
            this.label6.TabIndex = 1;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Connect to a Database";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.longProcessButton);
            this.panel3.Controls.Add(this.longProcessDelayTextBox);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(32, 204);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(466, 139);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length (secs.)";
            // 
            // longProcessButton
            // 
            this.longProcessButton.Location = new System.Drawing.Point(286, 101);
            this.longProcessButton.Name = "longProcessButton";
            this.longProcessButton.Size = new System.Drawing.Size(136, 23);
            this.longProcessButton.TabIndex = 4;
            this.longProcessButton.Text = "Run Long Process";
            this.longProcessButton.UseVisualStyleBackColor = true;
            this.longProcessButton.Click += new System.EventHandler(this.longProcessButton_Click);
            // 
            // longProcessDelayTextBox
            // 
            this.longProcessDelayTextBox.Location = new System.Drawing.Point(136, 101);
            this.longProcessDelayTextBox.Name = "longProcessDelayTextBox";
            this.longProcessDelayTextBox.Size = new System.Drawing.Size(121, 20);
            this.longProcessDelayTextBox.TabIndex = 3;
            this.longProcessDelayTextBox.Text = "2";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(34, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(402, 52);
            this.label9.TabIndex = 1;
            this.label9.Text = "This demonstration simulates running a lengthy process. It will time out if you s" +
                "et the execution time longer than 3 seconds. Trace information is written to a t" +
                "ext file in the TraceData folder.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Run a Lengthy Process";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(423, 513);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 551);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tracing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button webServiceButton;
        private System.Windows.Forms.TextBox webServiceDelayTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox serverNamecomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button databaseButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button longProcessButton;
        private System.Windows.Forms.TextBox longProcessDelayTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button closeButton;
    }
}

