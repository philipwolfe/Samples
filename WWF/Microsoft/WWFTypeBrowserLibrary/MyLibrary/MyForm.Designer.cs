namespace MyLibrary
{
	partial class MyForm
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
			this.components = new System.ComponentModel.Container();
			this.myControl1 = new MyLibrary.MyControl();
			this.myComponent1 = new MyLibrary.MyComponent(this.components);
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.SuspendLayout();
			// 
			// myControl1
			// 
			this.myControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.myControl1.Location = new System.Drawing.Point(41, 36);
			this.myControl1.Name = "myControl1";
			this.myControl1.Size = new System.Drawing.Size(150, 150);
			this.myControl1.SomeValueType = typeof(System.Xml.Serialization.CodeGenerationOptions);
			this.myControl1.TabIndex = 0;
			// 
			// myComponent1
			// 
			this.myComponent1.DataContractType = typeof(MyLibrary.PersonContract);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Location = new System.Drawing.Point(221, 36);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(224, 280);
			this.propertyGrid1.TabIndex = 1;
			// 
			// MyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 328);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.myControl1);
			this.Name = "MyForm";
			this.Text = "MyForm";
			this.Load += new System.EventHandler(this.MyForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MyComponent myComponent1;
		private MyControl myControl1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
	}
}