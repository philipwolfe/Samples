using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventViewer
{
	public partial class MessageViewer : Form
	{
		string date, type, computer, source, message;

		public MessageViewer(string Date, string Computer, string Type, string Source, string Message)
		{
			InitializeComponent();
			date = Date;
			computer = Computer;
			type = Type;
			source = Source;
			message = Message;
		}

		private void MessageViewer_Load(object sender, EventArgs e)
		{
			labelDate.Text = date;
			labelComputer.Text = computer;
			labelType.Text = type;
			labelSource.Text = source;
			textBoxMessage.Text = message;
		}
	}
}