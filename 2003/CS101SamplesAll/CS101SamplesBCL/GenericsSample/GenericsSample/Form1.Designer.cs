namespace GenericsSample
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
            this.label3 = new System.Windows.Forms.Label();
            this.exceptionLog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IterateUnsafeListMs = new System.Windows.Forms.TextBox();
            this.LoadUnsafeListMs = new System.Windows.Forms.TextBox();
            this.iterateSafeListMs = new System.Windows.Forms.TextBox();
            this.LoadSafeListMs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startSpeedTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddUnsafeList = new System.Windows.Forms.Button();
            this.AddSafeList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.safeObjectList = new System.Windows.Forms.CheckedListBox();
            this.unsafeObjectList = new System.Windows.Forms.CheckedListBox();
            this.masterObjectList = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(265, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Safe List";
            // 
            // exceptionLog
            // 
            this.exceptionLog.Location = new System.Drawing.Point(6, 19);
            this.exceptionLog.Multiline = true;
            this.exceptionLog.Name = "exceptionLog";
            this.exceptionLog.Size = new System.Drawing.Size(451, 73);
            this.exceptionLog.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exceptionLog);
            this.groupBox2.Location = new System.Drawing.Point(12, 445);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 107);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exception Log";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.IterateUnsafeListMs);
            this.groupBox3.Controls.Add(this.LoadUnsafeListMs);
            this.groupBox3.Controls.Add(this.iterateSafeListMs);
            this.groupBox3.Controls.Add(this.LoadSafeListMs);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.startSpeedTest);
            this.groupBox3.Location = new System.Drawing.Point(12, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(475, 159);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Speed Test";
            // 
            // IterateUnsafeListMs
            // 
            this.IterateUnsafeListMs.Location = new System.Drawing.Point(377, 93);
            this.IterateUnsafeListMs.Name = "IterateUnsafeListMs";
            this.IterateUnsafeListMs.Size = new System.Drawing.Size(51, 20);
            this.IterateUnsafeListMs.TabIndex = 8;
            // 
            // LoadUnsafeListMs
            // 
            this.LoadUnsafeListMs.Location = new System.Drawing.Point(377, 63);
            this.LoadUnsafeListMs.Name = "LoadUnsafeListMs";
            this.LoadUnsafeListMs.Size = new System.Drawing.Size(51, 20);
            this.LoadUnsafeListMs.TabIndex = 7;
            // 
            // iterateSafeListMs
            // 
            this.iterateSafeListMs.Location = new System.Drawing.Point(140, 93);
            this.iterateSafeListMs.Name = "iterateSafeListMs";
            this.iterateSafeListMs.Size = new System.Drawing.Size(51, 20);
            this.iterateSafeListMs.TabIndex = 6;
            // 
            // LoadSafeListMs
            // 
            this.LoadSafeListMs.Location = new System.Drawing.Point(140, 63);
            this.LoadSafeListMs.Name = "LoadSafeListMs";
            this.LoadSafeListMs.Size = new System.Drawing.Size(51, 20);
            this.LoadSafeListMs.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Iterate Unsafe List(ms):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Load Unsafe List(ms):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Iterate Safe List(ms):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Load Safe List(ms):";
            // 
            // startSpeedTest
            // 
            this.startSpeedTest.Location = new System.Drawing.Point(173, 130);
            this.startSpeedTest.Name = "startSpeedTest";
            this.startSpeedTest.Size = new System.Drawing.Size(117, 23);
            this.startSpeedTest.TabIndex = 0;
            this.startSpeedTest.Text = "Start Speed test";
            this.startSpeedTest.Click += new System.EventHandler(this.startSpeedTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.AddUnsafeList);
            this.groupBox1.Controls.Add(this.AddSafeList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.safeObjectList);
            this.groupBox1.Controls.Add(this.unsafeObjectList);
            this.groupBox1.Controls.Add(this.masterObjectList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 262);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type Safety";
            // 
            // AddUnsafeList
            // 
            this.AddUnsafeList.Location = new System.Drawing.Point(141, 228);
            this.AddUnsafeList.Name = "AddUnsafeList";
            this.AddUnsafeList.Size = new System.Drawing.Size(118, 23);
            this.AddUnsafeList.TabIndex = 14;
            this.AddUnsafeList.Text = "Add to unsafe List";
            this.AddUnsafeList.Click += new System.EventHandler(this.AddUnsafeList_Click);
            // 
            // AddSafeList
            // 
            this.AddSafeList.Location = new System.Drawing.Point(7, 228);
            this.AddSafeList.Name = "AddSafeList";
            this.AddSafeList.Size = new System.Drawing.Size(116, 23);
            this.AddSafeList.TabIndex = 13;
            this.AddSafeList.Text = "Add to Safe List";
            this.AddSafeList.Click += new System.EventHandler(this.AddSafeList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(265, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Unsafe List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Master List";
            // 
            // safeObjectList
            // 
            this.safeObjectList.FormattingEnabled = true;
            this.safeObjectList.Location = new System.Drawing.Point(265, 123);
            this.safeObjectList.Name = "safeObjectList";
            this.safeObjectList.Size = new System.Drawing.Size(195, 64);
            this.safeObjectList.TabIndex = 10;
            // 
            // unsafeObjectList
            // 
            this.unsafeObjectList.FormattingEnabled = true;
            this.unsafeObjectList.Location = new System.Drawing.Point(265, 33);
            this.unsafeObjectList.Name = "unsafeObjectList";
            this.unsafeObjectList.Size = new System.Drawing.Size(195, 64);
            this.unsafeObjectList.TabIndex = 9;
            // 
            // masterObjectList
            // 
            this.masterObjectList.CheckOnClick = true;
            this.masterObjectList.FormattingEnabled = true;
            this.masterObjectList.Location = new System.Drawing.Point(6, 33);
            this.masterObjectList.Name = "masterObjectList";
            this.masterObjectList.Size = new System.Drawing.Size(253, 154);
            this.masterObjectList.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(441, 37);
            this.label8.TabIndex = 15;
            this.label8.Text = "Select items from the master list, and select add to safe list and add to unsafe " +
                "list to see the type safety of generics.";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(68, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(337, 35);
            this.label9.TabIndex = 16;
            this.label9.Text = "Select the \"Start Speed test\" button to see the speed difference between an Array" +
                "List and a safe Genric container.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 564);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generics Sample";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox exceptionLog;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button startSpeedTest;
		private System.Windows.Forms.TextBox IterateUnsafeListMs;
		private System.Windows.Forms.TextBox LoadUnsafeListMs;
		private System.Windows.Forms.TextBox iterateSafeListMs;
		private System.Windows.Forms.TextBox LoadSafeListMs;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button AddUnsafeList;
		private System.Windows.Forms.Button AddSafeList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox safeObjectList;
		private System.Windows.Forms.CheckedListBox unsafeObjectList;
		private System.Windows.Forms.CheckedListBox masterObjectList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
	}
}

