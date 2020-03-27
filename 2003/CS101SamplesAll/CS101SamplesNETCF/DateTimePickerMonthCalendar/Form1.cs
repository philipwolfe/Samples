using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DateTimePickerMonthCalendarCS
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// Init the checkboxes based on the current state of the MonthCalendar
			ShowTodayCheckBox.Checked = MonthPicker.ShowToday;
			ShowTodayCircleCheckBox.Checked = MonthPicker.ShowTodayCircle;

			// Init the Combo box to first selection (Sunday)
			FirstDayOfWeekComboBox.SelectedIndex = 0;

			// Init the date and time labels
			ShowSelectedDateTime();

			// set initial value of label to today
			MonthDateLabel.Text = MonthPicker.TodayDate.ToShortDateString(); 
		}

	    // Modify the DateTimeLabel text to reflect the currently selected date and time.
	    private void ShowSelectedDateTime()
		{
			string dateStr = dateDateTimePicker.Value.ToShortDateString();
			string timeStr = timeDateTimePicker.Value.ToShortTimeString();

			// Concatenate the date picker value with the time picker value
			DateTimeLabel.Text = dateStr + " " + timeStr;
		}

		// Event when user changes the date
		private void DatePicker_ValueChanged(object sender, EventArgs e)
		{
			ShowSelectedDateTime();
		}

		// Event when user changes the time
		private void TimePicker_ValudChanged(object sender, EventArgs e)
		{
			ShowSelectedDateTime();
		}

		// Event when the user clicks on a date
		private void MonthPicker_DateChanged(object sender, DateRangeEventArgs e)
		{
			// Show the start and end dates
			MonthDateLabel.Text = e.Start.ToShortDateString() + " -- " + e.End.ToShortDateString();
		}

		// ShowToday: Default value is set to True which displays the current date at the bottom of the Calendar. Setting it to False will hide it.
		private void ShowTodayCheckBox_CheckStateChanged(object sender, EventArgs e)
		{
			MonthPicker.ShowToday = ShowTodayCheckBox.Checked;
		}

		// ShowTodayCircle: Default value is set to True which displays a red circle on the current date. Setting it to False will make the circle disappear.
		private void ShowTodayCircleCheckBox_CheckStateChanged(object sender, EventArgs e)
		{
			MonthPicker.ShowTodayCircle = ShowTodayCircleCheckBox.Checked;
		}

		// FirstDayOfWeek: Default value is Default which means that the week starts with Sunday as the first day and Saturday as last. You can set the first day of the week depending upon your choice by selecting from the predefined list with this property.
		private void FirstDayOfWeekComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (FirstDayOfWeekComboBox.SelectedIndex)
			{
				case 0 : MonthPicker.FirstDayOfWeek = Day.Sunday; break;
				case 1 : MonthPicker.FirstDayOfWeek = Day.Monday; break;
				case 2 : MonthPicker.FirstDayOfWeek = Day.Tuesday; break;
				case 3 : MonthPicker.FirstDayOfWeek = Day.Wednesday; break;
				case 4 : MonthPicker.FirstDayOfWeek = Day.Thursday; break;
				case 5 : MonthPicker.FirstDayOfWeek = Day.Friday; break;
				case 6 : MonthPicker.FirstDayOfWeek = Day.Saturday; break;
				default : MonthPicker.FirstDayOfWeek = Day.Default; break;
			}
		}

	}
}