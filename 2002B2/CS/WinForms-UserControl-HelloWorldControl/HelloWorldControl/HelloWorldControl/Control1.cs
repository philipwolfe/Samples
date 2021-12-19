using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HelloWorldControl
{
	/// <summary>
	/// Summary description for Control1.
	/// </summary>
	public class Control1 : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public Control1()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			components.Dispose();
		}


		protected override void OnPaint(PaintEventArgs e) 
		{
			//Paint the Text property on the control
			e.Graphics.DrawString(Text, 
				Font, 
				new SolidBrush(ForeColor), 
				ClientRectangle);
		}
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ClientSize = new System.Drawing.Size(292, 273);
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
