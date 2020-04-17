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

namespace SMTPMailActivityLibrary
{
    using System;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Workflow.ComponentModel.Design;
    using System.Drawing;
    using System.Xml.XPath;
    using System.Xml;
    using System.Text;
    using System.Workflow.ComponentModel.Compiler;
   

    
    public partial class SendEmail : CallExternalMethodActivity
    {
        public static DependencyProperty XmlDataProperty = DependencyProperty.Register("XmlData", typeof(IXPathNavigable), typeof(SendEmail));

        [ValidationOption(ValidationOption.Optional)]
        public IXPathNavigable XmlData
        {
            get
            {
                return ((IXPathNavigable)(this.GetValue(SendEmail.XmlDataProperty)));
            }
            set
            {
                this.SetValue(SendEmail.XmlDataProperty, value);
            }
        }

        protected override void OnMethodInvoking(System.EventArgs e)
        {
            string msgBodyParsed = this.Body;
            //Prepare a navigator arond the XmlData so we can retrieve information from it
            if (XmlData != null)
            {
                XPathNavigator xpn = XmlData.CreateNavigator();

                //Parse the Message body looking for replacement tags
                Regex rex = new Regex("<%(?'xpath'[^%]*)%>", RegexOptions.Compiled);

                foreach (Match match in rex.Matches(this.Body))
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

            this.ParameterBindings["MessageId"].Value = this.MessageId;
            this.ParameterBindings["To"].Value = this.To;
            this.ParameterBindings["From"].Value = this.From;
            this.ParameterBindings["Subject"].Value = this.Subject;
            this.ParameterBindings["Body"].Value = msgBodyParsed;
            this.ParameterBindings["MailType"].Value = this.MailType;

        }
        

       

    }
}