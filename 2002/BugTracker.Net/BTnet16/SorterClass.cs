////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Windows.Forms;

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// Sorter class for auto-sorting colums in a list view
	/// Thanks! to the Windows Forms faq:
	/// http://www.syncfusion.com/FAQ/Winforms/
	/// 
	/// </summary>
	////////////////////////////////////////////////////////////
	public class SorterClass : IComparer 
	{ 
		private int _colNum = 0; 
		private SortOrder _sortOrder = SortOrder.Ascending;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Constructor that tells the callback routine which
		/// column and which sort order we're sorting so
		/// it can do the comparison properly
		/// </summary>
		/// <param name="colNum"></param>
		/// <param name="sortOrder"></param>
		////////////////////////////////////////////////////////////
		public SorterClass(int colNum, SortOrder sortOrder) 
		{ 
			_colNum = colNum; 
			_sortOrder = sortOrder;
		} 
 

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Compare these two objects (which in our case are collections
		/// of objects) and return -1 if x < y, 0 if x=y and 1 if x>y
		/// (if we're sorting ascending, reverse < and > if descending)
		/// </summary>
		/// <param name="x">"left" object</param>
		/// <param name="y">"right" object</param>
		/// <returns>-1 if x < y, 0 if x=y and 1 if x>y (if ascending (see above))</returns>
		////////////////////////////////////////////////////////////
		public int Compare(object x, object y) 
		{ 
			System.Windows.Forms.ListViewItem item1 = (System.Windows.Forms.ListViewItem) x; 
			System.Windows.Forms.ListViewItem item2 = (System.Windows.Forms.ListViewItem) y; 

			if (_sortOrder == SortOrder.Ascending)
			{
				if(item1.SubItems[_colNum].Text.CompareTo(item2.SubItems[_colNum].Text) < 0)
					return -1; 
				else if(item1.SubItems[_colNum].Text.CompareTo(item2.SubItems[_colNum].Text) > 0)
					return 1; 
				else 
					return 0; 
			}
			else
			{
				if(item2.SubItems[_colNum].Text.CompareTo(item1.SubItems[_colNum].Text) < 0)
					return -1; 
				else if(item2.SubItems[_colNum].Text.CompareTo(item1.SubItems[_colNum].Text) > 0)
					return 1; 
				else 
					return 0; 
			}
		} 
	} 

}