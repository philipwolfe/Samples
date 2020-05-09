using System;
using System.Data;
using System.Runtime.InteropServices;


namespace Ironring.Management.MMC
{
	/// <summary>
	/// Configures the resultview as a Listview control.  Supports binding 
	/// to a DataTable to provide the schema and data
	/// 
	/// TBD: overridable data binding methods to augment GetDisplayInfo
	/// </summary>
	public class ReportNode : BaseNode
	{
        /// <summary>
        /// Underlying template for the listview control
        /// </summary>
		protected DataTable m_table = null;

        /// <summary>
        /// ctor takes the snapin to register with
        /// </summary>
        /// <param name="snapin"></param>
		public ReportNode(SnapinBase snapin) : base(snapin)
		{
		}

        /// <summary>
        /// Access the underlying DataTable 
        /// </summary>
		public DataTable Table
		{
			get { return m_table; }
			set { m_table = value; }
		}

        /// <summary>
        /// BaseNode override to populate the treeview control
        /// with column information and data
        /// </summary>
        /// <param name="console"></param>
		public override void OnShow()
		{
            IConsole2 console = Snapin.ResultViewConsole;

			// setup the header for the columns we want to show
            IHeaderCtrl2 header = console as IHeaderCtrl2;
			OnShowHeader(header);
			
			// add the actual data items 
			IResultData rdata = console as IResultData;
			OnShowData(rdata);

            rdata.SetViewMode((int)ViewMode.Report);
		}

        /// <summary>
        /// Overridable Helper method to populat the column header
        /// </summary>
        /// <param name="header"></param>
		public virtual void OnShowHeader(IHeaderCtrl2 header)
		{
			try
			{
				if (Table != null)
				{
					// Let's put in the column titles
					foreach (DataColumn col in Table.Columns)
					{
						string name = col.ColumnName;
						int ord = col.Ordinal;
						header.InsertColumn(ord, name, (int)ColumnHeaderFormat.LEFT, (int)MMCLV.AUTO);
					}
				}
			}
			catch(COMException e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
			}
		}

		/// <summary>
		/// Overridable helper method to populate the column data
		/// </summary>
		/// <param name="ResultData"></param>
		public virtual void OnShowData(IResultData ResultData)
		{
			if (Table != null)
			{
				int nRow = 1;

				RESULTDATAITEM rdi = new RESULTDATAITEM();
				foreach (DataRow row in Table.Rows)
				{
                    row.ToString();

					rdi.mask	= (uint)RDI.STR | (uint)RDI.IMAGE | (uint)RDI.PARAM;     

					// TBD: what image?
					rdi.nImage  = -1;   
					rdi.str     = (IntPtr)(-1);  // callback for names
					rdi.nCol    = 0;

					// The low word contains the cookie for the node, while the high word 
					// contains the row number + 1 we're inserting
					rdi.lParam = m_iCookie | (nRow << 16);
					ResultData.InsertItem(ref rdi);
					nRow++;
				}
			}
		}

        /// <summary>
        /// BaseNode callback override responsible for provided data.  Lookup the 
        /// row info in the lparam of the resultdataitem since its packed in with  
        /// our own cookie
        /// </summary>
        /// <param name="ResultDataItem"></param>
		public override void GetDisplayInfo(ref RESULTDATAITEM ResultDataItem)
		{
			bool bCallbase = true;

            // the "cell" data
			if (Table != null)
			{
                int nRow = (ResultDataItem.lParam >> 16) - 1;
                int nCol = ResultDataItem.nCol;

				if ((ResultDataItem.mask & (uint)RDI.STR) > 0)
				{
					string data = DisplayName;
					if (nRow >= 0 && nRow < Table.Rows.Count && nCol >= 0 && nCol < Table.Columns.Count)
					{
						data = Table.Rows[nRow].ItemArray[nCol].ToString();
						bCallbase = false;
					}

					ResultDataItem.str = Marshal.StringToCoTaskMemUni(data);
				}
			}

            // the image - requires 2 images in the image list
            // small - 0
            // large - 1
            if ((ResultDataItem.mask & (uint)RDI.IMAGE) > 0)
            {
                int offset = 1;
                if (IsUSeSmallIcons())
                    offset = 0;
                
                ResultDataItem.nImage = (Cookie << 16) + offset;
            }

			if (bCallbase)
				base.GetDisplayInfo(ref ResultDataItem);
		}

	}
}
