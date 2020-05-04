/***************************************************************************
         Copyright (c) Microsoft Corporation, All rights reserved.             
    This code sample is provided "AS IS" without warranty of any kind, 
    it is not recommended for use in a production environment.
***************************************************************************/

// VsPkg.cs : Implementation of VsPackage
//

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.VSIP;

using MSVSIP = Microsoft.VisualStudio.VSIP;

[assembly:ComVisible(true)]

namespace Vsip.VsPackage
{
    /////////////////////////////////////////////////////////////////////////////
    // VsPackage
    [MSVSIP.Helper.DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\7.1Exp")]
    [MSVSIP.Helper.InstalledProductRegistration(ProductNameResId = 100, ProductDetailsResId = 102, IconResId = 400, ProductId = "1.0")]
    [MSVSIP.Helper.ProvideMenuResource(1000, 1)]
    
        [MSVSIP.Helper.RegisterEditorExtension(typeof(EditorFactory), ".sd", 32, "{A2FE74E1-B743-11d0-AE1A-00A0C90FFFC3}", "..\\Templates", 106)]
    [Guid("9aa75229-9d91-4841-8a43-45f03018a250")]
    public class VsPackage : MSVSIP.Helper.Package
    {
        
        
        private EditorFactory editorFactory;
        
        public VsPackage()
        {
            Trace.WriteLine(string.Format("Entering constructor for: {0}", this.ToString()));
        }

        

        /////////////////////////////////////////////////////////////////////////////
        // CBscPkgPackage Package Implementation
        #region Package Members

        protected override void Initialize()
        {
            Trace.WriteLine (string.Format("Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();
            
            //Create Editor Factory
            editorFactory = new EditorFactory(this);
            base.RegisterEditorFactory(editorFactory);
            
        }

        protected override void ResetDefaults(/*[in] */uint flags)
        {
            Trace.WriteLine (string.Format("Entering ResetDefaults() of: {0}", this.ToString()));
        }

        protected override int CreateTool(/*[in]*/ref Guid guidPersistenceSlot)
        {
            Trace.WriteLine (string.Format("Entering CreateTool() of: {0}", this.ToString()));

            return NativeMethods.E_NOTIMPL;
    
        }

        protected override void Dispose(bool disposing)
        {
            Trace.WriteLine (string.Format("Entering Dispose() of: {0}", this.ToString()));
            
            base.Dispose(disposing);
        }

        protected override object GetAutomationObject(
            /*[in] */ string propName)
        {
            Trace.WriteLine (string.Format("Entering GetAutomationObject() of: {0}", this.ToString()));

            throw new NotImplementedException();
        }

        protected override VSPROPSHEETPAGE GetPropertyPage(
            /*[in] */ref Guid guidPage)
        {
            Trace.WriteLine (string.Format("Entering GetPropertyPage() of: {0}", this.ToString()));
            throw new NotImplementedException ();
        }

        protected override bool QueryClose()
        {
            Trace.WriteLine (string.Format("Entering QueryClose() of: {0}", this.ToString()));
            return true;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////
        // VsPackage IOleCommandTarget Implementation
        #region IOleCommandTarget Members

        /// <summary>
        /// Once the package is loaded, this function will be called
        /// to set the visibility of the menu items and toolbar buttons used by this package.
        /// </summary>
        protected override int QueryStatus(ref Guid guidCmdGroup, uint cmds, OLECMD[] prgCmds, System.IntPtr pCmdText)
        {
            Trace.WriteLine (string.Format("Entering QueryStatus() of: {0}", this.ToString()));

            Debug.Assert(cmds == 1, "Multiple commands");
            Debug.Assert(prgCmds!=null, "NULL argument");

            if ((prgCmds == null))
                throw new ArgumentNullException("QueryStatus");

            OLECMDF cmdf = 0;
            int result = NativeMethods.S_OK;

            if (guidCmdGroup == GuidList.guidVsPackageCmdSet)
            {
                // The following bitwise flags control the state of a command:
                //        OLECMDF_SUPPORTED, OLECMDF_ENABLED, OLECMDF_LATCHED,
                //        OLECMDF_NINCHED, OLECMDF_INVISIBLE, OLECMDF_DEFHIDEONCTXTMENU
                //
                // Common cases are the following:
                //    1. Enable a command --  cmdf = OLECMDF_SUPPORTED | OLECMDF_ENABLED
                //    2. Disable a command -- cmdf = OLECMDF_SUPPORTED
                //    3. Hide a command --    cmdf = OLECMDF_SUPPORTED | OLECMDF_INVISIBLE

                switch (prgCmds[0].cmdID)
                {


                    default:
                    {
                        result = (int)(Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_NOTSUPPORTED);
                        break;
                    }
                }
            }
            else
                result = (int)Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_UNKNOWNGROUP;

            prgCmds[0].cmdf = (uint)cmdf;

            return result;
        }

        /// <summary>
        /// This function is called when someone click on a menu item or a toolbar button
        /// used by this package. It is responsible for executing the command
        /// </summary>
        protected override int Exec(ref Guid guidCmdGroup, uint cmdID, uint nCmdexecopt, System.IntPtr pvaIn, System.IntPtr pvaOut)
        {
            Trace.WriteLine (string.Format("Entering Exec() of: {0}", this.ToString()));

            int result = NativeMethods.S_OK;

            if (guidCmdGroup == GuidList.guidVsPackageCmdSet)
            {
                switch (cmdID)
                {


                    default:
                    {
                        result = (int)(Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_NOTSUPPORTED);
                        break;
                    }
                }
            }
            else
                result = (int)Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_UNKNOWNGROUP;

            return result;
        }
        #endregion

    }
}