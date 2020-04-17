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
    using System.Text.RegularExpressions;
    
    
    public partial class ReceiveRtcMessage :RtcMessageReceived {

        public static DependencyProperty RegexProperty = DependencyProperty.Register("Regex", typeof(string), typeof(ReceiveRtcMessage));
        public static DependencyProperty RegexMatchedProperty = DependencyProperty.Register("RegexMatched", typeof(bool), typeof(ReceiveRtcMessage));


        [ValidationOption(ValidationOption.Optional)]
        public string Regex
        {
            get
            {
                return ((string)(this.GetValue(ReceiveRtcMessage.RegexProperty)));
            }
            set
            {
                this.SetValue(ReceiveRtcMessage.RegexProperty, value);
            }
        }


        [ValidationOption(ValidationOption.None)]
        public bool RegexMatched
        {
            get
            {

                Regex rgx;
                if (this.Message == null || this.Regex == null || this.Message.Length == 0 || this.Regex.Length == 0)
                {
                    return false;
                }
                else
                {
                    rgx = new Regex(this.Regex);
                    return rgx.IsMatch(this.Message);
                }


            }
        }
    }
}
