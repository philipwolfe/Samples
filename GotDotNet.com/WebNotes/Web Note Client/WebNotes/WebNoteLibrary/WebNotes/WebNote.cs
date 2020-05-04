using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace WebNotes
{
    [System.Xml.Serialization.XmlTypeAttribute ( Namespace = "http://tempuri.org/" )]
    public class WebNote
    {
        private String note;
        private String url;

        public WebNote () { }
        public WebNote ( String url , String note )
        {
            this.note = note;
            this.url = url;
        }
        public String Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }

        public String Note
        {
            get
            {
                return this.note;
            }
            set
            {
                this.note = value;
            }
        }
    }
}
