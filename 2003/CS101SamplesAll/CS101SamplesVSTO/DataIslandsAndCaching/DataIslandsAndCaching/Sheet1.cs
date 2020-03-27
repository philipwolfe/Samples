using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace DataIslandsAndCaching
{
    public partial class Sheet1
    {
        // This will automatically be persisted by the VSTO framework
        // based on the attribute (declarative).
        [Cached()]
        public AdventureWorks_DataDataSet ds;

        public AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter eta;
        public BindingSource ebs;
    
        // This will be set to be cached manually (imperative).
        // Any cached object must be a read/write public property/member
        // which meets the requirements of XmlSerializer and is not null.   
        public string cachedString;

        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            // If A1 and C2 are not cleared, it could be confusing.
            // Since they are being used as status indicators, it makes
            // sense to clear them as soon as the document is opened.
            this.Range["B1", missing].Value2 = null;
            this.Range["C2", missing].Value2 = null;

            CacheDataSet();

            CacheStringObject();
        }

        /// <summary>
        /// To provide a robust solution, data should always be read from
        /// the underlying source is online.  If offline, the data should
        /// be pulled from cache, if present.
        /// </summary>
        private void CacheDataSet()
        {
            string status;

            // Start by trying to read live data.  If successfull, use this data,
            // but indicate that cached data was found.
            try
            {
                eta = new DataIslandsAndCaching.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter();
                AdventureWorks_DataDataSet ds2 = new AdventureWorks_DataDataSet();
                eta.Fill(ds2.Employee);

                if (ds == null)
                {
                    status = "ONLINE, LIVE DATA IN USE, NO CACHED DATA FOUND";
                }
                else status = "ONLINE, LIVE DATA IN USE, CACHED DATA FOUND";

                ds = ds2;
            }
            // An error in reading data means application is offline.  Display
            // status based on whether or not cached data was found.
            catch
            {
                if (ds == null)
                {
                    status = "OFFLINE, NO CACHED DATA FOUND";
                    ds = new AdventureWorks_DataDataSet();
                }
                else
                {
                    status = "OFFLINE, CACHED DATA FOUND";
                }
            }

            ebs = new BindingSource(ds.Employee, "");
            employeesList.SetDataBinding(ebs, "", "NationalIDNumber", "LoginID", "Title", "HireDate", "BirthDate");

            this.Range["B1", missing].Value2 = status;
        }

        /// <summary>
        /// Set "cachedString" to be a cached object if not already.
        /// Note: The reference must not be null to be cacheable.
        /// </summary>
        private void CacheStringObject()
        {
            if (!this.IsCached("cachedString"))
            {
                cachedString = string.Format("CACHED: {0:d} @ {0:t}", DateTime.Now);

                this.StartCaching("cachedString");
                this.Range["C2", missing].Value2 =
                    "Data in cache was not set.  Save and re-open the document and the data will persist.";
            }
            // If object is already cached, the value will be set upon initialization
            else
            {
                this.Range["B2", missing].Value2 = cachedString;
            }
        }

        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Sheet1_Startup);
            this.Shutdown += new System.EventHandler(Sheet1_Shutdown);
        }

        #endregion

    }
}
