using System;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Ironring.Management.MMC
{
   /// <summary>
   /// Form node presents a Winforms UserControl as the result view
   /// implementation.  Make sure you use the WinForms achor features
   /// to support dynamic sizing of controls since the result view is 
   /// resizable.
   /// The FormNode is actually an OCX Node to MMC that hosts a shim 
   /// ActiveX control provided as part of this library.  Methods on the
   /// shim control communicate the UserControl Type to host.
   /// </summary>
   public class FormNode : OCXNode
   {
       /// <summary>
       /// The Type of the UserControl to create
       /// </summary>
       protected Type m_ControlType;
	   protected object usercontrol;

       //////////////////////////////////////////////////////////////////
       ///
       /// Implementation
       ///

        public FormNode(SnapinBase snapin) : base(snapin)
        {
            // this is the CLSID of the shim OCX that loads the form
            OCXGuid = new Guid("97AD17DA-70A5-45B9-9E10-DEAA3D26E17D");
            CreateNew = true;
        }

        /// <summary>
        /// The Type of UserControl to host in the result view
        /// </summary>
        public Type ControlType
        {
            get { return m_ControlType; } 
            set { m_ControlType = value; }
        }

	   public object UserControl
	   {
		   get { return usercontrol; }
	   }
	   

        /// <summary>
        /// A notification handler called by MMC on initialization
        /// </summary>
        /// <param name="objOCX"></param>
        /// <returns></returns>
        public override bool OnInitOcx(object objOCX)
        {
            // the OCX must implement this because its our shim control
            IMMCFormsShim shim = objOCX as IMMCFormsShim;

            if (shim == null || ControlType == null)
                return false;

            // get the type information from reflection
            Assembly asm = Assembly.GetAssembly(m_ControlType);

            // create the user control in the OCX
			System.IntPtr pUnk = shim.HostUserControl(asm.FullName, m_ControlType.ToString());

			// marshal the usercontrol reference back up through the shim
			// and store as UserControl property
			usercontrol = Marshal.GetObjectForIUnknown(pUnk);

			// check if the usercontrol implements ISnapinLink
			// if so provide a back reference to the base snapin.
			ISnapinLink snapinLink = usercontrol as ISnapinLink;
			if(snapinLink != null)
				snapinLink.ContextNode = this;

            return true;
        }
   }
}
