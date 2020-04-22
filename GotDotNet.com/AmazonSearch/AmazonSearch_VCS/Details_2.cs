#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net;

#endregion

namespace WSFun.Amazon
{
    public partial class Details
    {
        private Image _image;

        // Override ToString method to display product name in list box.
        public override string ToString()
        {
            return ProductName;
        }

        // Image of associated item.
        public Image ItemImage
        {
            get
            {
                if (_image == null)
                {
                    WebRequest webReq = WebRequest.Create(this.ImageUrlMedium);
                    WebResponse webResp = webReq.GetResponse();
                    _image = Image.FromStream(webResp.GetResponseStream());
                }
                return _image;
            }
        }
    }
}
