using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace teststub
{
    class Program
    {
        [STAThread()]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.Run(new BE.pinvoke2006.DownloadForm());
        }


    }
}
