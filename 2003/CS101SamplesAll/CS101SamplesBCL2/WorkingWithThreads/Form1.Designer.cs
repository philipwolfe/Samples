namespace WorkingWithThreads {
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundLoopsComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.foregroundLoopsComboBox = new System.Windows.Forms.ComboBox();
            this.clearResultsButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.beginButton = new System.Windows.Forms.Button();
            this.resultsTextBoxBackground = new System.Windows.Forms.TextBox();
            this.resultsTextBoxMain = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exponentResultTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timesToDoubleComboBox = new System.Windows.Forms.ComboBox();
            this.numberToDoubleComboBox = new System.Windows.Forms.ComboBox();
            this.clearResultsBGW = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButtonBGW = new System.Windows.Forms.Button();
            this.beginButtonBGW = new System.Windows.Forms.Button();
            this.resultsTextBoxBGW = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(662, 434);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.backgroundLoopsComboBox);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.foregroundLoopsComboBox);
            this.tabPage1.Controls.Add(this.clearResultsButton);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cancelButton);
            this.tabPage1.Controls.Add(this.beginButton);
            this.tabPage1.Controls.Add(this.resultsTextBoxBackground);
            this.tabPage1.Controls.Add(this.resultsTextBoxMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(654, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Threading";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Background loops";
            // 
            // backgroundLoopsComboBox
            // 
            this.backgroundLoopsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.backgroundLoopsComboBox.FormattingEnabled = true;
            this.backgroundLoopsComboBox.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8"});
            this.backgroundLoopsComboBox.Location = new System.Drawing.Point(117, 226);
            this.backgroundLoopsComboBox.Name = "backgroundLoopsComboBox";
            this.backgroundLoopsComboBox.Size = new System.Drawing.Size(121, 21);
            this.backgroundLoopsComboBox.TabIndex = 8;
            this.backgroundLoopsComboBox.SelectedIndexChanged += new System.EventHandler(this.backgroundLoopsComboBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Main loops";
            // 
            // foregroundLoopsComboBox
            // 
            this.foregroundLoopsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.foregroundLoopsComboBox.FormattingEnabled = true;
            this.foregroundLoopsComboBox.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8"});
            this.foregroundLoopsComboBox.Location = new System.Drawing.Point(117, 199);
            this.foregroundLoopsComboBox.Name = "foregroundLoopsComboBox";
            this.foregroundLoopsComboBox.Size = new System.Drawing.Size(121, 21);
            this.foregroundLoopsComboBox.TabIndex = 6;
            this.foregroundLoopsComboBox.SelectedIndexChanged += new System.EventHandler(this.foregroundLoopsComboBox_SelectedIndexChanged);
            // 
            // clearResultsButton
            // 
            this.clearResultsButton.Location = new System.Drawing.Point(224, 365);
            this.clearResultsButton.Name = "clearResultsButton";
            this.clearResultsButton.Size = new System.Drawing.Size(81, 23);
            this.clearResultsButton.TabIndex = 2;
            this.clearResultsButton.Text = "Clear Results";
            this.clearResultsButton.UseVisualStyleBackColor = true;
            this.clearResultsButton.Click += new System.EventHandler(this.clearResultsButton_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 83);
            this.label4.TabIndex = 4;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Basic Threading";
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(104, 365);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel Background";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(23, 365);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(75, 23);
            this.beginButton.TabIndex = 0;
            this.beginButton.Text = "Begin";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // resultsTextBoxBackground
            // 
            this.resultsTextBoxBackground.Location = new System.Drawing.Point(388, 268);
            this.resultsTextBoxBackground.Multiline = true;
            this.resultsTextBoxBackground.Name = "resultsTextBoxBackground";
            this.resultsTextBoxBackground.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBoxBackground.Size = new System.Drawing.Size(249, 120);
            this.resultsTextBoxBackground.TabIndex = 10;
            // 
            // resultsTextBoxMain
            // 
            this.resultsTextBoxMain.Location = new System.Drawing.Point(388, 16);
            this.resultsTextBoxMain.Multiline = true;
            this.resultsTextBoxMain.Name = "resultsTextBoxMain";
            this.resultsTextBoxMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBoxMain.Size = new System.Drawing.Size(249, 246);
            this.resultsTextBoxMain.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.exponentResultTextBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.timesToDoubleComboBox);
            this.tabPage2.Controls.Add(this.numberToDoubleComboBox);
            this.tabPage2.Controls.Add(this.clearResultsBGW);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cancelButtonBGW);
            this.tabPage2.Controls.Add(this.beginButtonBGW);
            this.tabPage2.Controls.Add(this.resultsTextBoxBGW);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(654, 408);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Background Worker";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // exponentResultTextBox
            // 
            this.exponentResultTextBox.Location = new System.Drawing.Point(141, 225);
            this.exponentResultTextBox.Name = "exponentResultTextBox";
            this.exponentResultTextBox.Size = new System.Drawing.Size(121, 20);
            this.exponentResultTextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Result";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Times to Double";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number to Double";
            // 
            // timesToDoubleComboBox
            // 
            this.timesToDoubleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timesToDoubleComboBox.FormattingEnabled = true;
            this.timesToDoubleComboBox.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9"});
            this.timesToDoubleComboBox.Location = new System.Drawing.Point(141, 198);
            this.timesToDoubleComboBox.Name = "timesToDoubleComboBox";
            this.timesToDoubleComboBox.Size = new System.Drawing.Size(121, 21);
            this.timesToDoubleComboBox.TabIndex = 8;
            this.timesToDoubleComboBox.SelectedIndexChanged += new System.EventHandler(this.timesToDoubleComboBox_SelectedIndexChanged);
            // 
            // numberToDoubleComboBox
            // 
            this.numberToDoubleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberToDoubleComboBox.FormattingEnabled = true;
            this.numberToDoubleComboBox.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8"});
            this.numberToDoubleComboBox.Location = new System.Drawing.Point(141, 171);
            this.numberToDoubleComboBox.Name = "numberToDoubleComboBox";
            this.numberToDoubleComboBox.Size = new System.Drawing.Size(121, 21);
            this.numberToDoubleComboBox.TabIndex = 6;
            this.numberToDoubleComboBox.SelectedIndexChanged += new System.EventHandler(this.numberForExponentComboBox_SelectedIndexChanged);
            // 
            // clearResultsBGW
            // 
            this.clearResultsBGW.Location = new System.Drawing.Point(221, 363);
            this.clearResultsBGW.Name = "clearResultsBGW";
            this.clearResultsBGW.Size = new System.Drawing.Size(81, 23);
            this.clearResultsBGW.TabIndex = 2;
            this.clearResultsBGW.Text = "Clear Results";
            this.clearResultsBGW.UseVisualStyleBackColor = true;
            this.clearResultsBGW.Click += new System.EventHandler(this.clearResultsBGW_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 300);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(350, 19);
            this.progressBar1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 98);
            this.label3.TabIndex = 4;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "BackgroundWorker Component";
            // 
            // cancelButtonBGW
            // 
            this.cancelButtonBGW.Enabled = false;
            this.cancelButtonBGW.Location = new System.Drawing.Point(101, 363);
            this.cancelButtonBGW.Name = "cancelButtonBGW";
            this.cancelButtonBGW.Size = new System.Drawing.Size(112, 23);
            this.cancelButtonBGW.TabIndex = 1;
            this.cancelButtonBGW.Text = "Cancel Background";
            this.cancelButtonBGW.UseVisualStyleBackColor = true;
            this.cancelButtonBGW.Click += new System.EventHandler(this.cancelButtonBGW_Click);
            // 
            // beginButtonBGW
            // 
            this.beginButtonBGW.Location = new System.Drawing.Point(20, 363);
            this.beginButtonBGW.Name = "beginButtonBGW";
            this.beginButtonBGW.Size = new System.Drawing.Size(75, 23);
            this.beginButtonBGW.TabIndex = 0;
            this.beginButtonBGW.Text = "Begin";
            this.beginButtonBGW.UseVisualStyleBackColor = true;
            this.beginButtonBGW.Click += new System.EventHandler(this.beginButtonBGW_Click);
            // 
            // resultsTextBoxBGW
            // 
            this.resultsTextBoxBGW.Location = new System.Drawing.Point(387, 14);
            this.resultsTextBoxBGW.Multiline = true;
            this.resultsTextBoxBGW.Name = "resultsTextBoxBGW";
            this.resultsTextBoxBGW.Size = new System.Drawing.Size(247, 372);
            this.resultsTextBoxBGW.TabIndex = 13;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(598, 448);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 482);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(15, 0, 15, 40);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.TextBox resultsTextBoxMain;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button beginButtonBGW;
        private System.Windows.Forms.TextBox resultsTextBoxBGW;
        private System.Windows.Forms.Button cancelButtonBGW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button clearResultsButton;
        private System.Windows.Forms.TextBox resultsTextBoxBackground;
        private System.Windows.Forms.Button clearResultsBGW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox numberToDoubleComboBox;
        private System.Windows.Forms.TextBox exponentResultTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox backgroundLoopsComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox foregroundLoopsComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox timesToDoubleComboBox;
    }
}

