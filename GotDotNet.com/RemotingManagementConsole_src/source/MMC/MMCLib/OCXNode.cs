using System;


namespace Ironring.Management.MMC
{
	/// <summary>
	/// Node with a Resultview that contains ActivX controls.  Provide the
	/// Guid for the OCX and the rest is magic.  Currently doesn't support
	/// sinking events generated by the control.
	/// </summary>
	public class OCXNode : BaseNode
	{
        /// <summary>
        /// The guid for the ActivX Control
        /// </summary>
		protected Guid m_guidOCX;

        /// <summary>
        /// Create a new ActiveX control for resultviews 
        /// of this type or reuse the existing one
        /// </summary>
        protected bool m_bCreateNew;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="snapin"></param>
		public OCXNode(SnapinBase snapin) : base(snapin)
		{
            m_bCreateNew = false;
		}

        /// <summary>
        /// Access the ActiveX control Guid
        /// </summary>
		public Guid OCXGuid
		{
			get { return m_guidOCX; }
			set { m_guidOCX = value; }
		}

        /// <summary>
        /// This is an MMC concept.  Should it create a new activeX control for each 
        /// result view of this type or a new one.
        /// </summary>
        public bool CreateNew
        {
            get { return m_bCreateNew; }
            set { m_bCreateNew = value; }
        }

        /// <summary>
        /// Provides the dring representation fo the guid to MMC 
        /// to create on its terms.
        /// </summary>
        /// <param name="pViewOptions"></param>
        /// <returns></returns>
		public override string GetResultViewType(ref int pViewOptions)
		{
			// the default for std OCX views
            pViewOptions = 0;
            if (CreateNew)
			    pViewOptions = (int)MMC_VIEW_OPTIONS.CREATENEW;

			return "{" + OCXGuid + "}";		
		}
	}
}
