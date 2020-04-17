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

using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdateDemo
{
    //=----------------------------------------------------------------------=
    // UpdateIntervalDialog
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   A simple little dilaog to let users input values for an update 
    ///   interval.
    /// </summary>
    /// 
    partial class UpdateIntervalDialog : Form
    {
        #region Private data types/constants/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                  Private data types/constants/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        /// 
        /// <summary>
        ///   This is the number of minutes that the user has set for
        ///   their update interval.
        /// </summary>
        /// 
        int m_minutes = 1;

        #endregion // Private data types/constants/etc.






        #region Public Methods/Properties/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                  Public Methods/Properties/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=



        //=------------------------------------------------------------------=
        // UpdateIntervalDialog
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initialises a new instance of this class.
        /// </summary>
        /// 
        public UpdateIntervalDialog()
        {
            InitializeComponent();
        }


        //=------------------------------------------------------------------=
        // UpdateInterval
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The number of minutes to show in the Numeric Updown
        /// </summary>
        /// 
        /// <value>
        ///   An integer value with the number of minutes to use as an update
        ///   interval.  This is different from the ms that the actual
        ///   BackgroundUpdater uses, but it might be more helpful here.
        /// </value>
        /// 
        public int UpdateInterval
        {
            get
            {
                return this.m_minutes;
            }
            set
            {
                this.m_minutes = value;
            }
        }

        #endregion // Public Methods/Properties/etc







        #region Non-Public Methods/Functions/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Non-Public Methods/Functions/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // UpdateIntervalDialog_Load
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The dialog is almost ready to show.  Go and set the number in
        ///   the updown now.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details
        /// </param>
        /// 
        private void UpdateIntervalDialog_Load(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = this.m_minutes;
        }


        //=------------------------------------------------------------------=
        // okButton_Click
        //=------------------------------------------------------------------=
        /// <summary>
        ///   If the user closes the dialog with OK, update the selected value
        ///   of number of minutes.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details
        /// </param>
        /// 
        private void okButton_Click(object sender, EventArgs e)
        {
            this.m_minutes = (int)this.numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion // Non-Public Methods/Functions/Properties

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
