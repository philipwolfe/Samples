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
    internal sealed class GetStatusCustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public GetStatusCustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.PeachPuff;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.SeaShell;
            this.BackColorEnd = Color.Turquoise;
            this.BackgroundStyle = LinearGradientMode.Vertical;
        }
    }

    [ActivityDesignerThemeAttribute(typeof(GetStatusCustomActivityDesignerTheme))]
    public class GetStatusCustomActivityDesigner : ActivityDesigner
    {

    }
    #endregion

    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(GetStatusCustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(GetStatus), "Resources.GetStatus.bmp")]
    public class GetStatus : CallExternalMethodActivity {
        
        public static DependencyProperty UriProperty = DependencyProperty.Register("Uri", typeof(string), typeof(GetStatus));
        
        public static DependencyProperty ReturnValueProperty = DependencyProperty.Register("ReturnValue", typeof(RTCCORELib.RTC_PRESENCE_STATUS), typeof(GetStatus));
        
        public GetStatus() {
            base.InterfaceType = typeof(RtcActivityLibrary.Interfaces.IRtcGetStatus);
            base.MethodName = "GetStatus";
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
                return ((string)(this.GetValue(GetStatus.UriProperty)));
            }
            set {
                this.SetValue(GetStatus.UriProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public RTCCORELib.RTC_PRESENCE_STATUS ReturnValue {
            get {
                return ((RTCCORELib.RTC_PRESENCE_STATUS)(this.GetValue(GetStatus.ReturnValueProperty)));
            }
            set {
                this.SetValue(GetStatus.ReturnValueProperty, value);
            }
        }
        
        protected override void OnMethodInvoking(System.EventArgs e) {
            this.ParameterBindings["Uri"].Value = this.Uri;
        }
        
        protected override void OnMethodInvoked(System.EventArgs e) {
            this.ReturnValue = ((RTCCORELib.RTC_PRESENCE_STATUS)(this.ParameterBindings["(ReturnValue)"].Value));
        }
    }
}
