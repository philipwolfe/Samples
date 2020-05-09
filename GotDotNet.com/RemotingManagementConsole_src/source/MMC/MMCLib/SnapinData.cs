using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace Ironring.Management.MMC
{
	/// <summary>
	/// Implements IDataObject interface.  Responsible for mapping IDataObject 
	/// pointers that MMC uses to our managed Node objects.
	/// </summary>
	public class DataObject : IDataObject
	{

        /// <summary>
        /// Clipboard format for Display Name
        /// </summary>
		protected static ushort s_DisplayName; 

        /// <summary>
        /// Clipboard format for NodeType
        /// </summary>
		protected static ushort s_NodeType;    
 
        /// <summary>
        /// Clipboard format for SZNodeType 
        /// </summary>
		protected static ushort s_SZNodeType;  

        /// <summary>
        /// Clipboard format for SnapinClsid
        /// </summary>
		protected static ushort s_SnapinClsid; 
    
        /// <summary>
        /// The node that this Data object is
        /// </summary>
		protected BaseNode m_NodeData;      
		// responsible for

        // flags
        public static readonly int NULL = 0;
        public static readonly int CUSTOMOCX = -1;
        public static readonly int CUSTOMWEB = -2;


        /////////////////////////////////////////////////////////////////////
        /// Implementation
        /// 


        /// <summary>
        /// Construct the IDataObject implementation and associate 
        /// it with the node provided
        /// </summary>
        /// <param name="initData"></param>
		public DataObject(BaseNode initData)
		{
			// Set the Node this Data Object will be responsible for
			m_NodeData = initData;

		}


        /// <summary>
        /// Static class constructor used to init our static data
        /// </summary>
        static DataObject()
        {
            // Get the Clipboard Format Numbers for these various items.
            // MMC should have already registered these Clipboard Formats,
            // so this call just gives us the id assigned for each format.

            s_NodeType = RegisterClipboardFormat("CCF_NODETYPE");
            s_SZNodeType = RegisterClipboardFormat("CCF_SZNODETYPE");
            s_SnapinClsid = RegisterClipboardFormat("CCF_SNAPIN_CLASSID");
            s_DisplayName = RegisterClipboardFormat("CCF_DISPLAY_NAME");
        }
    
        /// <summary>
        /// The node associated with the IDataObject
        /// </summary>
		public BaseNode Node
		{
			get { return m_NodeData; }
		}

        /// <summary>
        /// Send data to MMC in a stream depending on what is requested 
        /// </summary>
        /// <param name="pFormatEtc"></param>
        /// <param name="pMedium"></param>
		public void GetDataHere(ref FORMATETC pFormatEtc, ref STGMEDIUM pMedium)
		{
            try
            {

                // We'll send this array if we don't know what to send
                byte[] Nothing = {0x0, 0x0};

                ushort cf = (ushort)pFormatEtc.cfFormat;

                // make a memory stream to handle streaming data to a buffer
                MemoryStream stream = new MemoryStream(128);
                Encoding ue = new UnicodeEncoding();
                BinaryWriter writer = new BinaryWriter(stream, ue);

                // See if we need to send a string....
                if (cf == s_DisplayName || cf == s_SZNodeType)
                {
                    if (cf == s_DisplayName)
                        writer.Write(m_NodeData.DisplayName.ToCharArray());
                    else
                        writer.Write(Nothing);
                }
                    // We need to send a GUID
                else if (cf == s_NodeType || cf == s_SnapinClsid)
                {
                    Guid guid;

                    if (cf == s_NodeType)
                    {
                        guid = m_NodeData.Guid;
                    }
                    else //if (cf == s_SnapinClsid)
                    {
                        guid = m_NodeData.Snapin.Guid;
                    }
    				
                    writer.Write(guid.ToByteArray());
                }


                // Write the memstream to the IStream.

                //IStream pStream = null;   
                UCOMIStream pStream = null;
                CreateStreamOnHGlobal(pMedium.hGlobal, 0, out pStream );
    			
                // If we couldn't open a global handle....
                if (pStream == null)
                    throw new SnapinException("Fail to CreateStreamOnHGlobal");

                writer.Flush();
				
				IntPtr dataSentPtr = Marshal.AllocCoTaskMem(4);
				pStream.Write(stream.GetBuffer(), (int)stream.Length, dataSentPtr);

				int dataSent = Marshal.ReadInt32(dataSentPtr);
				Marshal.FreeCoTaskMem(dataSentPtr);

				if (dataSent != stream.Length)
					throw new SnapinException("Cannot write the data provided.");

            }
            catch(SnapinException e)
            {
                System.Diagnostics.Debug.WriteLine("DataObject::GetDataHere " + e.Message);
            }
		}

        /// <summary>
        /// Not impl
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
		public int GetData(ref FORMATETC a, ref STGMEDIUM b)
		{
			return HRESULT.E_NOTIMPL;
		}

        /// <summary>
        /// Not impl
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
		public int QueryGetData(IntPtr a)
		{
			return HRESULT.E_NOTIMPL;
		}

        /// <summary>
        /// Not impl
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
		public int GetCanonicalFormatEtc(IntPtr a, IntPtr b)
		{
			return HRESULT.E_NOTIMPL;
		}

        /// <summary>
        /// Not impl
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
		public int SetData(IntPtr a, IntPtr b, int c)
		{
			return HRESULT.E_NOTIMPL;
		}
    
        /// <summary>
        /// Not impl
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
		public int EnumFormatEtc(uint a, IntPtr b)
		{
			return HRESULT.E_NOTIMPL;
		}
    
        /// <summary>
        /// Not impl
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
		public int DAdvise(IntPtr a, uint b, IntPtr c, ref uint d)
		{
			return HRESULT.E_NOTIMPL;
		}

        /// <summary>
        /// Not impl
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
		public int DUnadvise(uint a)
		{
			return HRESULT.E_NOTIMPL;
		}

        /// <summary>
        /// Not impl
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
		public int EnumDAdvise(IntPtr a)
		{
			return HRESULT.E_NOTIMPL;
		}

        //////////////////////////////////////////////////////////////////////////
        /// P/Invoke Helpers

        /// <summary>
        /// Used to create an IStream over global memory
        /// </summary>
		[DllImport("ole32.dll")]
		protected static extern int CreateStreamOnHGlobal(int hGlobal, int fDeleteOnRelease, out UCOMIStream ppstm);


        /// <summary>
        /// Get the clipboard format ids
        /// </summary>
		[DllImport("user32.dll", CharSet=CharSet.Unicode)]
		protected static extern ushort RegisterClipboardFormat(String format);
	}
}
