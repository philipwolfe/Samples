using System;
using Ironring.Management.MMC;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Ironring.Management.MMC
{
	/// <summary>
	/// Provides information to add Snapin dialog about the snapin.  
	/// Also used in snapin registration.  Implements ISnapinAbout
	/// to communicate with MMC.
	/// </summary>
	public class About : ISnapinAbout
	{
		/// <summary>
		/// A long description of the snapin
		/// </summary>
		string m_Description;

        /// <summary>
        /// the organization providing the snapin 
        /// </summary>
		string m_Provider;

        /// <summary>
        /// the version of the snapin: TBD: tie this to the assembly version? 
        /// </summary>
		string m_Version;

		/// <summary>
		/// embedded image name for main icon
		/// </summary>
		string m_MainIconName;
        /// <summary>
        /// embedded image name for main icon
        /// </summary>
        
        string m_SmallOpenName;     
        /// <summary>
        /// embedded image name for Small Open image
        /// </summary>
        string m_SmallClosedName;	
        /// <summary>
        /// embedded image name for small closed image
        /// </summary>
        string m_LargeName;        

		/// <summary>
		/// ImageList contains images for all "about" images.
		/// </summary>
		ImageList staticFolderIcons = new ImageList();

		/// <summary>
		/// This following indices are used to access the icons in the staticFolderIcons list.
		/// </summary>
		private const int mainIconIndex = 0;
		private const int smallOpenImageIndex = 1;
		private const int smallClosedImageIndex = 2;
		private const int largeImageIndex = 3;

        /// <summary>
        /// RGB color value describing the trasnparent color
        /// </summary>
		Color m_Mask; 

        ///////////////////////////////////////////////////////////////////
        ///
        /// Implementation
        ///

        
        /// <summary>
        /// ctor
        /// </summary>
		public About()
		{
			// lift the provider and version information from the
			// snapin attribute on the associated snapin class.

			object[] attrs = GetType().GetCustomAttributes(typeof(AboutSnapinAttribute), true);
			if (attrs.Length > 0)
			{
				AboutSnapinAttribute aboutAttrib = (AboutSnapinAttribute)attrs[0];
				attrs = aboutAttrib.SnapinType.GetCustomAttributes(typeof(SnapinInAttribute), true);
				if (attrs.Length != 0)
				{
					SnapinInAttribute snapinAttrib  = (SnapinInAttribute)attrs[0];

					m_Provider = snapinAttrib.Provider;
					if (snapinAttrib.Version != null)
					{
						m_Version = snapinAttrib.Version;
					}
					else
					{
						m_Version = GetType().Module.Assembly.GetName().Version.ToString();
					}

				}
			}

			/// The color mask is important when the color depth of the screen is not 32. In this 
			/// case, the unmanaged bitmaps must be translated to the color depth of the screen and
			///  the color mask should specify Color.Black. 
	
			m_Mask = Color.Black;

			staticFolderIcons.Insert(mainIconIndex, "");
			staticFolderIcons.Insert(smallOpenImageIndex, "");
			staticFolderIcons.Insert(smallClosedImageIndex, "");
			staticFolderIcons.Insert(largeImageIndex, "");
		}

        /// <summary>
        /// Get at the description
        /// </summary>
	    public string Description
		{
			get { return m_Description; }
			set { m_Description = value; }
		}

        /// <summary>
        /// Get at the description
        /// </summary>
        public string Provider
		{
			get { return m_Provider; }
			set { m_Provider = value; }
		}

        /// <summary>
        /// Get at the description
        /// </summary>
        public string Version
		{
			get { return m_Version; }
			set { m_Version = value; }
		}

        /// <summary>
        /// Get at the description
        /// </summary>
        public string MainIconName 
		{
			get {	return m_MainIconName; }
			set 
			{ 
				m_MainIconName = value; 
				staticFolderIcons.Replace(mainIconIndex, m_MainIconName);
			}
		}

        /// <summary>
        /// Get at the description
        /// </summary>
		public string SmallOpenImageName
		{
			get { return m_SmallOpenName; }
			set 
			{ 
				m_SmallOpenName = value; 
				staticFolderIcons.Replace(smallOpenImageIndex, m_SmallOpenName);
			}
		}

        /// <summary>
        /// Get at the description
        /// </summary>
        public string SmallClosedImageName 
		{
			get { return m_SmallClosedName; } 
			set 
			{ 
				m_SmallClosedName = value; 
				staticFolderIcons.Replace(smallClosedImageIndex, m_SmallClosedName);
			}
		}

        /// <summary>
        /// Get at the description
        /// </summary>
        public string LargeImageName 
		{
			get { return m_LargeName; }
			set 
			{ 
				m_LargeName = value; 
				staticFolderIcons.Replace(largeImageIndex, m_LargeName);
			}
		}

        /// <summary>
        /// Get or set the image color mask
        /// </summary>
        public Color ImageColorMask
		{
			get { return m_Mask; }
			set { m_Mask = value; }
		}


        ////////////////////////////////////////////////////////////////////
        /// ISnapinAbout Implementation
        /// 
     
		/// <summary>
		/// Returns the textual description for this snapin
		/// </summary>
		/// <param name="lpDescription">out parameter</param>
		public void GetSnapinDescription(out IntPtr lpDescription)
		{
			lpDescription = Marshal.StringToCoTaskMemUni(Description);
		}

		/// <summary>
		/// This returns the creator of the snapin - thats you! 
		/// </summary>
		/// <param name="pName"></param>
		public void GetProvider(out IntPtr pName)
		{
			pName = Marshal.StringToCoTaskMemUni(Provider);
		}

		/// <summary>
		/// Retuens the version of this snapin.  The version can be optionally provided 
		/// in the Snapin Attribute that decorates the snapin class.  If not provided the
		/// assembly version attribute is used - the assembly where your snapin resides.
		/// </summary>
		/// <param name="lpVersion">the version string maj.min.build.rev</param>
		public void GetSnapinVersion(out IntPtr lpVersion)
		{
			lpVersion = Marshal.StringToCoTaskMemUni(Version);
		}

		/// <summary>
		/// This returns the About page image handle - application icon
		/// </summary>
		/// <param name="hAppIcon"></param>
		public void GetSnapinImage(out IntPtr hAppIcon)
		{
			hAppIcon = staticFolderIcons.GetIconHandle(mainIconIndex);
		}


		/// <summary>
		/// return handles to images
		/// </summary>
		/// <param name="hSmallImage"></param>
		/// <param name="hSmallImageOpen"></param>
		/// <param name="hLargeImage"></param>
		/// <param name="cMask"></param>
		public void GetStaticFolderImage(out IntPtr hSmallImage, out IntPtr hSmallImageOpen, out IntPtr hLargeImage, out uint cMask)
		{
			hSmallImage = staticFolderIcons.GetBitmapHandle(smallClosedImageIndex);
			hSmallImageOpen = staticFolderIcons.GetBitmapHandle(smallOpenImageIndex);
			hLargeImage = staticFolderIcons.GetBitmapHandle(largeImageIndex);
			cMask = (uint) m_Mask.ToArgb();
		}
	}
}
