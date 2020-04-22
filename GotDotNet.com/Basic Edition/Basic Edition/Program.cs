//=============================================================
// C# OpenGL Framework
// Copyright (c) 2005-2006 devDept.com
// All rights reserved.
//
// For more information on this program, please visit: 
// http://www.csharpopenglframework.com
//
// For licensing information, please visit: 
// http://www.csharpopenglframework.com/licensing.html
//=============================================================

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace openglFramework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.Run(new MainForm());
        }
    }
}