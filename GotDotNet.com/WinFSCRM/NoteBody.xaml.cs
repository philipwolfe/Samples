using System;
using System.Storage.Core;
using MSAvalon.Windows;
using MSAvalon.Windows.Controls;
using MSAvalon.Windows.Documents;
using MSAvalon.Windows.Navigation;
using MSAvalon.Windows.Shapes;

namespace WinFSCRM
{
    /// <summary>
    /// Interaction logic for NoteBody.xaml
    /// </summary>

    public partial class NoteBody : MSAvalon.Windows.Documents.Document
    {
		public void LoadNote(System.Storage.Core.Document document)
		{
			if (!text.TextRange.IsEmpty)
			{
				text.TextRange.Text = " ";
			}

			text.TextRange.Append("Title: " + document.Title + Environment.NewLine);
			text.TextRange.Append("Author: " + (document.Authors[0] as Author).Name + Environment.NewLine + Environment.NewLine);
			text.TextRange.Append(System.Text.Encoding.UTF8.GetString((byte[])document.Body));
		}
    }
}