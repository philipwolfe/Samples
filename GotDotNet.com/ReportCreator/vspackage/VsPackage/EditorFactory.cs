using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.VSIP;

using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Vsip.VsPackage
{
    /// <summary>
    /// Factory for creating our editors
    /// </summary>
    [Guid("f4b1224e-6c23-43e3-a978-fbe849feea9e")]
    public class EditorFactory : IVsEditorFactory
    {
        private VsPackage myPackage;
        private IOleServiceProvider vsServiceProvider;


        public EditorFactory(VsPackage packageEditor)
        {
            Trace.WriteLine(string.Format("Entering {0} constructor", this.ToString()));

            myPackage = packageEditor;
        }
        
        #region IVsEditorFactory Members

        public int SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp)
        {
            vsServiceProvider = psp;
            return NativeMethods.S_OK;
        }

        public int MapLogicalView(ref Guid rguidLogicalView, out string pbstrPhysicalView)
        {
            // We only support 1 phisical view, so return null
            pbstrPhysicalView = null;
            return NativeMethods.S_OK;
        }

        public int Close()
        {
            return NativeMethods.S_OK;
        }

        public int CreateEditorInstance(
                        uint grfCreateDoc,
                        string pszMkDocument,
                        string pszPhysicalView,
                        IVsHierarchy pvHier,
                        uint itemid,
                        System.IntPtr punkDocDataExisting,
                        out System.IntPtr ppunkDocView,
                        out System.IntPtr ppunkDocData,
                        out string pbstrEditorCaption,
                        out Guid pguidCmdUI,
                        out int pgrfCDW)
        {
            Trace.WriteLine(string.Format("Entering {0} CreateEditorInstance()", this.ToString()));

            // Initialize to null
            ppunkDocView = new System.IntPtr ();
            ppunkDocData = new System.IntPtr ();
            pguidCmdUI = new Guid ();
            pgrfCDW = 0;
            pbstrEditorCaption = null;

            // Validate inputs
            if ((grfCreateDoc & (NativeMethods.CEF_OPENFILE | NativeMethods.CEF_SILENT)) == 0)
            {
                return NativeMethods.E_INVALIDARG;
            }
            if (punkDocDataExisting != IntPtr.Zero)
            {
                return NativeMethods.VS_E_INCOMPATIBLEDOCDATA;
            }

            // Create the Document (editor)
            EditorPane newEditor = new EditorPane(myPackage);
            ppunkDocView = Marshal.GetIUnknownForObject(newEditor);
            ppunkDocData = Marshal.GetIUnknownForObject(newEditor);
            pbstrEditorCaption = "";

            return NativeMethods.S_OK;
        }

        #endregion
    }
}
