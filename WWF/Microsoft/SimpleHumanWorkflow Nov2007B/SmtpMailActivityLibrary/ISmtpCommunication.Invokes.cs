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
    internal sealed class SendEmailCustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public SendEmailCustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.DarkOrange;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.LightSkyBlue;
            this.BackColorEnd = Color.MistyRose;
            this.BackgroundStyle = LinearGradientMode.Vertical;
        }
    }

    [ActivityDesignerThemeAttribute(typeof(SendEmailCustomActivityDesignerTheme))]
    public class SendEmailCustomActivityDesigner : ActivityDesigner
    {

    }
    #endregion

    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(SendEmailCustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(SendEmail), "Resources.EMailMessage.bmp")]
    public partial class SendEmail : CallExternalMethodActivity {
        
        public static DependencyProperty MessageIdProperty = DependencyProperty.Register("MessageId", typeof(System.Guid), typeof(SendEmail));
        
        public static DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(string), typeof(SendEmail));
        
        public static DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(string), typeof(SendEmail));
        
        public static DependencyProperty SubjectProperty = DependencyProperty.Register("Subject", typeof(string), typeof(SendEmail));
        
        public static DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(string), typeof(SendEmail));
        
        public static DependencyProperty MailTypeProperty = DependencyProperty.Register("MailType", typeof(SmtpMailActivityLibrary.Interfaces.SmtpEMailType), typeof(SendEmail));
        
        public SendEmail() {
            base.InterfaceType = typeof(SmtpMailActivityLibrary.Interfaces.ISmtpCommunication);
            base.MethodName = "SendEmail";
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
        public System.Guid MessageId {
            get {
                return ((System.Guid)(this.GetValue(SendEmail.MessageIdProperty)));
            }
            set {
                this.SetValue(SendEmail.MessageIdProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string To {
            get {
                return ((string)(this.GetValue(SendEmail.ToProperty)));
            }
            set {
                this.SetValue(SendEmail.ToProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string From {
            get {
                return ((string)(this.GetValue(SendEmail.FromProperty)));
            }
            set {
                this.SetValue(SendEmail.FromProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string Subject {
            get {
                return ((string)(this.GetValue(SendEmail.SubjectProperty)));
            }
            set {
                this.SetValue(SendEmail.SubjectProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public string Body {
            get {
                return ((string)(this.GetValue(SendEmail.BodyProperty)));
            }
            set {
                this.SetValue(SendEmail.BodyProperty, value);
            }
        }
        
        [System.Workflow.ComponentModel.Compiler.ValidationOptionAttribute(System.Workflow.ComponentModel.Compiler.ValidationOption.Required)]
        public SmtpMailActivityLibrary.Interfaces.SmtpEMailType MailType {
            get {
                return ((SmtpMailActivityLibrary.Interfaces.SmtpEMailType)(this.GetValue(SendEmail.MailTypeProperty)));
            }
            set {
                this.SetValue(SendEmail.MailTypeProperty, value);
            }
        }
        
        
    }
}
