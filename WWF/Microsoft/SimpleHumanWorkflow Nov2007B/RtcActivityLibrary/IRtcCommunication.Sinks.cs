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

namespace RtcActivityLibrary {
    using System;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.ComponentModel;
    using System.Drawing;
    using System.Workflow.ComponentModel.Design;
    using System.Drawing.Drawing2D;
    using System.ComponentModel.Design;

    #region look n feel
    internal sealed class MessageRecievedCustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public MessageRecievedCustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.Thistle;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.Green;
            this.BackColorEnd = Color.Wheat;
            this.BackgroundStyle = LinearGradientMode.Vertical;
        }
    }

    [ActivityDesignerThemeAttribute(typeof(MessageRecievedCustomActivityDesignerTheme))]
    public class MessageRecievedCustomActivityDesigner : ActivityDesigner
    {

    }
    #endregion

    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(MessageRecievedCustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(RtcMessageReceived), "Resources.ReceiveMessage.bmp")]
    public partial class RtcMessageReceived : HandleExternalEventActivity {
        
        public static DependencyProperty UriProperty = DependencyProperty.Register("Uri", typeof(string), typeof(RtcMessageReceived));
        
        public static DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(RtcMessageReceived));
        
        public RtcMessageReceived() {
            base.InterfaceType = typeof(RtcActivityLibrary.Interfaces.IRtcCommunication);
            base.EventName = "RtcMessageReceived";
        }
        
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public override System.Type InterfaceType {
            get {
                return base.InterfaceType;
            }
            set {
                throw new System.InvalidOperationException("Cannot set InterfaceType on a derived HandleExternalEventActivity.");
            }
        }
        
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public override string EventName {
            get {
                return base.EventName;
            }
            set {
                throw new System.InvalidOperationException("Cannot set EventName on a derived HandleExternalEventActivity.");
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string Uri {
            get {
                return ((string)(this.GetValue(RtcMessageReceived.UriProperty)));
            }
            set {
                this.SetValue(RtcMessageReceived.UriProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string Message {
            get {
                return ((string)(this.GetValue(RtcMessageReceived.MessageProperty)));
            }
            set {
                this.SetValue(RtcMessageReceived.MessageProperty, value);
            }
        }
        
        protected override void OnInvoked(System.EventArgs e) {
            RtcActivityLibrary.Interfaces.RtcMessageEventArgs castedE = ((RtcActivityLibrary.Interfaces.RtcMessageEventArgs)(e));
            this.Uri = ((string)(castedE.Uri));
            this.Message = ((string)(castedE.Message));
        }
    }
}
