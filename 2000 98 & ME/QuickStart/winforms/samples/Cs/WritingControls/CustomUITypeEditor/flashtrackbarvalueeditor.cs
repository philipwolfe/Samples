//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.FlashTrackBar {
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Core;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Design;
    using System.WinForms;
    using System.WinForms.ComponentModel;
    using System.WinForms.Design;

    public class FlashTrackBarValueEditor : UITypeEditor {

        private IWinFormsEditorService edSvc = null;

        protected virtual void SetEditorProps(FlashTrackBar editingInstance, FlashTrackBar editor) {
            editor.ShowValue = true;
            editor.StartColor = Color.Navy;
            editor.EndColor = Color.White;
            editor.ForeColor = Color.White;
            editor.Min = editingInstance.Min;
            editor.Max = editingInstance.Max;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceObjectProvider provider, object value) {

            if (context != null 
                && context.Instance != null
                && provider != null) {

                edSvc = (IWinFormsEditorService)provider.GetServiceObject(typeof(IWinFormsEditorService));

                if (edSvc != null) {
                    FlashTrackBar trackBar = new FlashTrackBar();
                    trackBar.ValueChanged += new EventHandler(this.ValueChanged);
                    SetEditorProps((FlashTrackBar)context.Instance, trackBar);
                    bool asInt = true;
                    if (value is int) {
                        trackBar.Value = (int)value;
                    }
                    else if (value is byte) {
                        asInt = false;
                        trackBar.Value = (byte)value;
                    }
                    edSvc.DropDownControl(trackBar);
                    if (asInt) {
                        value = trackBar.Value;
                    }
                    else {
                        value = (byte)trackBar.Value;
                    }
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            if (context != null && context.Instance != null) {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        private void ValueChanged(object sender, EventArgs e) {
            if (edSvc != null) {
                edSvc.CloseDropDown();
            }
        }
    }
}
