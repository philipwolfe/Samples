//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

namespace IRtcCommunication_Activities {
    using System;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;
    using System.Xml.XPath;
    using System.Text.RegularExpressions;
    
    
    public class SendRtcMessage : SendMessage {

        public static DependencyProperty XmlDataProperty = DependencyProperty.Register("XmlData", typeof(string), typeof(SendRtcMessage));

        [ValidationOption(ValidationOption.Optional)]
        public string XmlData
        {
            get
            {
                return ((string)(this.GetValue(SendRtcMessage.XmlDataProperty)));
            }
            set
            {
                this.SetValue(SendRtcMessage.XmlDataProperty, value);
            }
        }

        protected override void OnMethodInvoking(System.EventArgs e)
        {
            string msgBodyParsed = this.Message;
            //Prepare a navigator arond the XmlData so we can retrieve information from it
            if (XmlData != "")
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(XmlData);
                XPathNavigator xpn = doc.CreateNavigator();

                //Parse the Message body looking for replacement tags
                Regex rex = new Regex("<%(?'xpath'[^%]*)%>", RegexOptions.Compiled);

                foreach (Match match in rex.Matches(this.Message))
                {
                    string xpath = match.Groups["xpath"].Value;
                    XPathNavigator nodeValue = xpn.SelectSingleNode(xpath);

                    if (nodeValue != null)
                    {
                        Regex rexReplace = new Regex("<%" + xpath + "%>");
                        msgBodyParsed = rexReplace.Replace(msgBodyParsed, nodeValue.Value.ToString());
                    }
                }
            }

            this.ParameterBindings["Uri"].Value = this.Uri;
            this.ParameterBindings["Message"].Value = msgBodyParsed;

        }
        
    }
}
