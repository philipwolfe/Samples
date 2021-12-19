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

   public class FlashTrackBarDarkenByEditor : FlashTrackBarValueEditor {
       protected override void SetEditorProps(FlashTrackBar editingInstance, FlashTrackBar editor) {
           base.SetEditorProps(editingInstance, editor);
           editor.Min = 0;
           editor.Max = byte.MaxValue;
       }
   }
}
