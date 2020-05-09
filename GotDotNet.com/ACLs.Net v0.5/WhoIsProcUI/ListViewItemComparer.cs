using System;
using System.Collections;
using System.Windows.Forms;

namespace WhoIsProcUI
{
	/// <summary>
	///  Easy sorting of the columns of a listview.
	///  Remembers the column index to sort.
	///  Automatic support for ascending/descending sort depending on current ordering of the items
	///  Support for right-aligned columns (i.e. most commonly numbers)
	/// </summary>
	class ListViewItemComparer : IComparer
	{
		private readonly int _column;
		private readonly bool _rightCompare;
		private readonly bool _reverseSort;
		private bool _sorted = true;

		public ListViewItemComparer(ListView lv, int column, bool reverseSort)
		{
			_column = column;
			_rightCompare = (lv.Columns[_column].TextAlign == HorizontalAlignment.Right);
			_reverseSort = reverseSort;
		}
		public bool Sorted
		{
			get
			{
				return _sorted;
			}
		}

		#region Implementation of IComparer

		public int Compare(object x, object y)
		{
			ListViewItem item1 = (ListViewItem)x;
			ListViewItem item2 = (ListViewItem)y;

			string s1 = item1.SubItems[_column].Text;
			string s2 = item2.SubItems[_column].Text;

			int rc;
			// For right-aligned text, the string length has priority on the string
			// comparison ordering.
			if (_rightCompare && (s1.Length > s2.Length))
				rc = 1;
			else if (_rightCompare && (s1.Length < s2.Length))
				rc = -1;
			else
				rc = String.Compare(s1, s2);

			if (_reverseSort)
				rc = -rc;

			// If at least one of the comparison indicates y > x, it means
			// the items were not sorted.
			if (rc > 0)
				_sorted = false;

			return rc;
		}

		#endregion

		/// <summary>
		///  Static method to apply a ListViewItemComparer on a given column
		///  of a listview.
		/// </summary>
		/// <param name="lv">The listview</param>
		/// <param name="column">The column index of the listview</param>
		public static void SortListView(ListView lv, int column)
		{
			// First, try to sort in ascending order
			ListViewItemComparer cmp = new ListViewItemComparer(lv, column, false);
			lv.ListViewItemSorter = cmp;

			// If the items were already sorted, sort in reverse order.
			if (cmp.Sorted)
			{
				ListViewItemComparer cmp2 = new ListViewItemComparer(lv, column, true);
				lv.ListViewItemSorter = cmp2;
			}
		}
	}
}
