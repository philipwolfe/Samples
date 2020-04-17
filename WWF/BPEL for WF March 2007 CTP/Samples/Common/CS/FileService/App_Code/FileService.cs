//---------------------------------------------------------------------
//  This file is part of the  BPEL for Windows Workflow Foundation Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Web.Services;
using System.IO;

namespace FileService
{
    [WebService(Namespace = "http://tempuri.org/")]
    public class FileService : System.Web.Services.WebService
    {
        [WebMethod]
        public void writeLine(string message)
        {
            using (StreamWriter writer = File.AppendText("Output.txt"))
            {
                writer.WriteLine(string.Format("{0} : {1}", DateTime.Now, message));
            }
        }
    }
}
