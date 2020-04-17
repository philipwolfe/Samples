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
    internal sealed class SendMessageCustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public SendMessageCustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.Purple;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.Pink;
            this.BackColorEnd = Color.Yellow;
            this.BackgroundStyle = LinearGradientMode.Vertical;
        }
    }

    [ActivityDesignerThemeAttribute(typeof(SendMessageCustomActivityDesignerTheme))]
    public class SendMessageCustomActivityDesigner : ActivityDesigner
    {

    }
    #endregion

    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(SendMessageCustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(SendMessage), "Resources.SendMessage.bmp")]
    public partial class SendMessage : CallExternalMethodActivity {
        
        public static DependencyProperty UriProperty = DependencyProperty.Register("Uri", typeof(string), typeof(SendMessage));
        
        public static DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(SendMessage));
        
        public SendMessage() {
            base.InterfaceType = typeof(RtcActivityLibrary.Interfaces.IRtcCommunication);
            base.MethodName = "SendMessage";
        }
        
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public override System.Type InterfaceType {
            get {
                return base.InterfaceType;
            }
            set {
                throw new System.InvalidOperationException("Cannot set InterfaceType on a derived CallExternalMethodActivity.");
            }
        }
        
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public override string MethodName {
            get {
                return base.MethodName;
            }
            set {
                throw new System.InvalidOperationException("Cannot set MethodName on a derived CallExternalMethodActivity.");
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string Uri {
            get {
                return ((string)(this.GetValue(SendMessage.UriProperty)));
            }
            set {
                this.SetValue(SendMessage.UriProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string Message {
            get {
                return ((string)(this.GetValue(SendMessage.MessageProperty)));
            }
            set {
                this.SetValue(SendMessage.MessageProperty, value);
            }
        }
        /*
        protected override void OnMethodInvoking(System.EventArgs e) {
            this.ParameterBindings["Uri"].Value = this.Uri;
            this.ParameterBindings["Message"].Value = this.Message;
        }
         * */
    }
}
