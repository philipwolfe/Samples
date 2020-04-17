//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Microsoft.Samples.Windows.Forms.EventBasedAsync {

    partial class AsyncPictureBoxForm : Form 
    {
        public AsyncPictureBoxForm() 
        {
            InitializeComponent();

             instructionsLinkLabel.TabStop = false;
        }
        
        /// <summary>
        /// Handle the Click event on btnLoad. 
        /// Start the async load of the bitmap file pointed to by txtLocation - this can be 
        /// a file name or url
        /// </summary>
        private void btnLoad_Click(System.Object sender, System.EventArgs e) {

            imageLoadProgressBar.Value = 0;
            bigImagePictureBox.Image = null;
            btnLoad.Enabled = false;
            btnCancel.Enabled = true;

            bigImagePictureBox.LoadAsync(txtLocation.Text);
        }

        /// <summary>
        /// Handle the Click event on btnCancel.
        /// Cancel the async loading of the bitmap file
        /// Note: It is possible that the load may have completed by the time cancel is processed
        ///       - you will need to take this into account in your applications
        /// </summary>
        private void btnCancel_Click(System.Object sender, System.EventArgs e) {
            bigImagePictureBox.CancelAsync();
        }

        /// <summary>
        /// Handle the LoadCompleted event. This event is raised when the PictureBox has 
        /// finished async loading the bitmap.
        /// The AsyncCompletedEventArgs contains information about the async operation 
        /// - whether it was canceled, if there was an error and so on
        /// </summary>
        private void BigImagePictureBox_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            btnCancel.Enabled = false;
            btnLoad.Enabled = true;
            if (e.Error != null) {
                MessageBox.Show(e.Error.Message, "Async PictureBox Sample", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else if ((e.Cancelled == true)) {
                MessageBox.Show("Load of picture canceled", "Async PictureBox Sample");
            } else {
                MessageBox.Show("Load of picture completed", "Async PictureBox Sample");
            }
        }

        /// <summary>
        /// Handle the ProgressChanged event. This event is raised during the async loading
        /// of the bitmap. It can be used to give progress feedback to the user.
        /// The ProgressChangedEventArgs contains information about the progress of 
        /// the async operation - in this case the percentage complete
        /// </summary>
        private void BigImagePictureBox_LoadProgressChanged(System.Object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            imageLoadProgressBar.Value = e.ProgressPercentage;
        }

        /// <summary> 
        /// Utility method that generates a 35MB bitmap for the sample
        /// This should really be done asynchronously as well
        /// but to keep the sample simple we'll do it in line.
        /// </summary>
        private void InstructionsLinkLabel_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
            using (new WaitCursorManager(this)) {

                Bitmap startingBmp = Properties.Resources.SampleBitmap;
                using (Bitmap bigBmp = new Bitmap(3000, 3000, PixelFormat.Format32bppRgb)) {
                    using (Graphics gBmp = Graphics.FromImage(bigBmp)) {
                        using (TextureBrush bmpBrush = new TextureBrush(startingBmp)) {
                            gBmp.FillRectangle(bmpBrush, gBmp.ClipBounds);
                            gBmp.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.White)), gBmp.ClipBounds);
                            bigBmp.Save("big.bmp", ImageFormat.Bmp);
                        }
                    }
                }
            
            }
        }

		private void txtLocation_TextChanged(object sender, EventArgs e)
		{
			if (this.txtLocation.Text.Length == 0)
				this.btnLoad.Enabled = false;
			else
				this.btnLoad.Enabled = true;
		}
    }
}