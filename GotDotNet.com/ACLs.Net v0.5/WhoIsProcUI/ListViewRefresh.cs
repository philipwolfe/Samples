using System;
using System.Collections;
using System.Windows.Forms;

namespace WhoIsProcUI
{
	/// <summary>
	///  Helper class to handle the refresh of a list view.
	/// </summary>
	public class ListViewRefreshHelper : IDisposable
	{
		private readonly ListView _lv;
		private IComparer _savedComparer;
		private int _topSel;

		public ListViewRefreshHelper(ListView lv)
		{
			_lv = lv;
			BeginUpdate();
		}
		public void Dispose()
		{
			EndUpdate();
		}
		private void BeginUpdate()
		{
			_lv.BeginUpdate();

			_topSel = (_lv.TopItem != null ? _lv.TopItem.Index : 0);
			_savedComparer = _lv.ListViewItemSorter;
			_lv.ListViewItemSorter = null;
			_lv.Items.Clear();
		}
		private void EndUpdate()
		{
			_lv.ListViewItemSorter = _savedComparer;

			// Try to restore the listview vertical scroll bar as it was before the update
			if (_lv.Items.Count > 0)
			{
				if (_topSel > _lv.Items.Count)
					_topSel = _lv.Items.Count - 1;

				_lv.EnsureVisible(_topSel);

				int i = _topSel + 1;
				while( (_lv.TopItem != null) && (_topSel > _lv.TopItem.Index) && (i < _lv.Items.Count))
				{
					_lv.EnsureVisible(i);
					i++;
					//_topSel = _lv.TopItem.Index;
				}
			}
			_lv.EndUpdate();
		}
	}
}
