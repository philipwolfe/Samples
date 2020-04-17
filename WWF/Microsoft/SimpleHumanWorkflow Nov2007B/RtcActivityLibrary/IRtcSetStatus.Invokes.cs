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
    internal sealed class SetStatusCustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public SetStatusCustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.GreenYellow;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.MidnightBlue;
            this.BackColorEnd = Color.Yellow;
            this.BackgroundStyle = LinearGradientMode.BackwardDiagonal;
        }
    }

    [ActivityDesignerThemeAttribute(typeof(SetStatusCustomActivityDesignerTheme))]
    public class SetStatusCustomActivityDesigner : ActivityDesigner
    {

    }
    #endregion

    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(SetStatusCustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(SetStatus), "Resources.SetStatus.bmp")]
    public class SetStatus : CallExternalMethodActivity {
        
        public static DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(RTCCORELib.RTC_PRESENCE_STATUS), typeof(SetStatus));
        
        public SetStatus() {
            base.InterfaceType = typeof(RtcActivityLibrary.Interfaces.IRtcSetStatus);
            base.MethodName = "SetStatus";
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
        public RTCCORELib.RTC_PRESENCE_STATUS Status {
            get {
                return ((RTCCORELib.RTC_PRESENCE_STATUS)(this.GetValue(SetStatus.StatusProperty)));
            }
            set {
                this.SetValue(SetStatus.StatusProperty, value);
            }
        }
        
        protected override void OnMethodInvoking(System.EventArgs e) {
            this.ParameterBindings["Status"].Value = this.Status;
        }
    }
}
