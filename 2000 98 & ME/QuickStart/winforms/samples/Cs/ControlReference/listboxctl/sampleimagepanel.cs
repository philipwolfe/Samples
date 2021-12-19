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
namespace Microsoft.Samples.WinForms.Cs.ListBoxCtl {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    // <doc>
    // <desc>
    //     This simple control displays the images selected in the ListBox
    // </desc>                                                            
    // </doc>
    //
    public class SampleImagePanel : System.WinForms.Panel {
        internal System.Drawing.Image[] myImages = new System.Drawing.Image[4];
        private int imageCnt = 0;

        public SampleImagePanel()
            : base() {
        }

        public virtual void AddImage(Image img) {
            if (imageCnt >= myImages.Length) {
                return;
            }
            myImages[imageCnt++] = img;
        }

        public virtual void ClearImages() {
            imageCnt = 0;
        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
            for (int i=0; i<imageCnt; i++) {
                pe.Graphics.DrawImage(myImages[i], new System.Drawing.Point(0, 30 * i + 5));
            }
        }
    }
}
