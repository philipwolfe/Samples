using System;
using MSAvalon.Windows;
using MSAvalon.Windows.Controls;
using MSAvalon.Windows.Documents;
using MSAvalon.Windows.Navigation;
using MSAvalon.Windows.Shapes;

namespace WinFSCRM
{
    /// <summary>
    /// Interaction logic for EventInformation.xaml
    /// </summary>

	public partial class EventInformation: FlowPanel
    {
		public void LoadEvent(System.Storage.Core.Event ev)
		{
			name.TextRange.Text = (string)ev.DisplayName;
			date.TextRange.Text = ev.EventTime.ToShortDateString();
			description.TextRange.Text = (string)ev.Description;
		}
    }
}