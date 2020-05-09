using System;

namespace Ironring.Management.MMC
{
	/// <summary>
	/// HTML node class provides a web browser for the result view.  
	/// Set the Url to set the starting page.
	/// </summary>
	public class HTMLNode : BaseNode
	{
        /// <summary>
        /// The Url to navigate to on startup.
        /// </summary>
		protected string m_strUrl;

        //////////////////////////////////////////////////////////////////
        ///
        /// Implementation
        ///
        
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="snapin"></param>
		public HTMLNode(SnapinBase snapin) : base(snapin)
		{
			m_strUrl = "about:blank";
		}

        /// <summary>
        /// Set or get the url to navigate to on startup.
        /// </summary>
		public string Url
		{
			get { return m_strUrl; }
            set { m_strUrl = value; }
		}
		
		/// <summary>
		/// Provide MMC with the startup Url when called
		/// </summary>
		/// <param name="pViewOptions"></param>
		/// <returns></returns>
		public override string GetResultViewType(ref int pViewOptions)
		{
			// the default for std list views
			pViewOptions = 0;
			return Url;		
		}
	}
}
