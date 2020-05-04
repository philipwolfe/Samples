using System;
using System.Configuration.Install;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;

namespace BE.pinvoke2006
{
	[RunInstaller(true)]
	[ComVisible(false)]
    public class VS2005AddinInstaller : Installer
	{
		public override void Install(System.Collections.IDictionary
			stateSaver)
		{
			base.Install(stateSaver);

            try
            {
                if (!Directory.Exists(CommonAddInPath))
                    Directory.CreateDirectory(CommonAddInPath);

                XmlDocument doc = new XmlDocument();
                doc.Load(AddInDefaultLocation);
                XmlNodeList nl = doc.GetElementsByTagName("Assembly");
                nl[0].InnerText = AssemblyLocation;
                doc.Save(CommonAddInLocation);

                File.Delete(AddInDefaultLocation);
            }
            catch (Exception ex)
            {
                throw new InstallException("Failed to register AddIn", ex);
            }
		}

		public override void Uninstall(System.Collections.IDictionary
			savedState)
		{
			base.Uninstall(savedState);

            try
            {
                if (File.Exists(CommonAddInLocation))
                    File.Delete(CommonAddInLocation);
            }
            catch (Exception ex)
            {
                throw new InstallException("Failed to unregister AddIn", ex);
            }
		}

        public string AddInDefaultLocation
        {
            get
            {
                string path = Path.GetDirectoryName(AssemblyLocation);
                string af = Path.Combine(path, AddInFilename );
                return af;
            }
        }

        public string AssemblyLocation
        {
            get
            {
                string f = this.GetType().Assembly.Location;
                return f;
            }
        }

        public string AddInFilename
        {
            get
            {
                return "BE.pinvoke2006.AddIn";
            }
        }

        public string CommonAddInPath
        {
            get
            {
                string commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string addinPath = Path.Combine(commonApplicationData, @"Microsoft\MSEnvShared\Addins");
                return addinPath;
            }
        }

        public string CommonAddInLocation
        {
            get
            {
                return Path.Combine(CommonAddInPath, AddInFilename);
            }
        }
	}
}
