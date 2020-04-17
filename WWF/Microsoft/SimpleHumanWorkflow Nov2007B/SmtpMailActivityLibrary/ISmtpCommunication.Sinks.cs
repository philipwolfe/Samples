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

namespace SMTPMailActivityLibrary {
    using System;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;
    using System.Workflow.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.ComponentModel.Design;

    #region look n feel
    internal sealed class MailReceivedCustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public MailReceivedCustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.GreenYellow;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.Beige;
            this.BackColorEnd = Color.DarkGreen;
            this.BackgroundStyle = LinearGradientMode.ForwardDiagonal;
        }
    }

    [ActivityDesignerThemeAttribute(typeof(MailReceivedCustomActivityDesignerTheme))]
    public class MailReceivedCustomActivityDesigner : ActivityDesigner
    {

    }
    #endregion

    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(MailReceivedCustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(SmtpMailReceived), "Resources.EMailMessage.bmp")]
    public partial class SmtpMailReceived : HandleExternalEventActivity {
        
        public static DependencyProperty MessageIdProperty = DependencyProperty.Register("MessageId", typeof(System.Guid), typeof(SmtpMailReceived));
        
        public static DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(string), typeof(SmtpMailReceived));
        
        public static DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(string), typeof(SmtpMailReceived));
        
        public static DependencyProperty SubjectProperty = DependencyProperty.Register("Subject", typeof(string), typeof(SmtpMailReceived));
        
        public static DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(string), typeof(SmtpMailReceived));
        
        public static DependencyProperty MailTypeProperty = DependencyProperty.Register("MailType", typeof(SmtpMailActivityLibrary.Interfaces.SmtpEMailType), typeof(SmtpMailReceived));
        
        public SmtpMailReceived() {
            base.InterfaceType = typeof(SmtpMailActivityLibrary.Interfaces.ISmtpCommunication);
            base.EventName = "SmtpMailReceived";
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
        public System.Guid MessageId {
            get {
                return ((System.Guid)(this.GetValue(SmtpMailReceived.MessageIdProperty)));
            }
            set {
                this.SetValue(SmtpMailReceived.MessageIdProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string To {
            get {
                return ((string)(this.GetValue(SmtpMailReceived.ToProperty)));
            }
            set {
                this.SetValue(SmtpMailReceived.ToProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string From {
            get {
                return ((string)(this.GetValue(SmtpMailReceived.FromProperty)));
            }
            set {
                this.SetValue(SmtpMailReceived.FromProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string Subject {
            get {
                return ((string)(this.GetValue(SmtpMailReceived.SubjectProperty)));
            }
            set {
                this.SetValue(SmtpMailReceived.SubjectProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string Body {
            get {
                return ((string)(this.GetValue(SmtpMailReceived.BodyProperty)));
            }
            set {
                this.SetValue(SmtpMailReceived.BodyProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public SmtpMailActivityLibrary.Interfaces.SmtpEMailType MailType {
            get {
                return ((SmtpMailActivityLibrary.Interfaces.SmtpEMailType)(this.GetValue(SmtpMailReceived.MailTypeProperty)));
            }
            set {
                this.SetValue(SmtpMailReceived.MailTypeProperty, value);
            }
        }
        
        protected override void OnInvoked(System.EventArgs e) {
            SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs castedE = ((SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs)(e));
            this.MessageId = ((System.Guid)(castedE.MessageId));
            this.To = ((string)(castedE.To));
            this.From = ((string)(castedE.From));
            this.Subject = ((string)(castedE.Subject));
            this.Body = ((string)(castedE.Body));
            this.MailType = ((SmtpMailActivityLibrary.Interfaces.SmtpEMailType)(castedE.MailType));
        }
    }
}
