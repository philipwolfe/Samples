//Copyright (c) 2006 Jon Flanders - http://www.masteringbiztalk.com/
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
//associated documentation files (the "Software"), to deal in the Software without restriction, 
//including without limitation the rights to use, copy, modify, merge, publish, distribute, 
//sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
//is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included 
//in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
//FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WorkflowVisibilityControl
{
    public class WFToolboxImageHandler : IHttpHandler
    {


        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            Image i =  WorkflowDesignerControl.WorkflowDesignerControl.GetToolboxImage(context.Request["name"].ToString());
            MemoryStream ms = new MemoryStream();
            if (i == null)
            {          
                i = new Bitmap(16, 16);
                Graphics g = Graphics.FromImage(i);
                g.FillRectangle(Brushes.White, 0, 0, 16, 16);
               
            }
            i.Save(ms, ImageFormat.Png);
            ms.Seek(0, SeekOrigin.Begin);
            context.Response.BinaryWrite(ms.GetBuffer());
            context.Response.End();

        }


    }
}
