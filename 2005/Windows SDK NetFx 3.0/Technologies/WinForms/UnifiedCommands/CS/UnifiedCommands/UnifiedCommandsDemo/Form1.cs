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
using System.IO;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;


namespace Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo
{
    //=----------------------------------------------------------------------=
    // Form1
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This is the sample form to demonstrate using UnifiedCommands.
    /// </summary>
    /// 
    partial class Form1 : Form
    {
        #region Private Members/Data Types/Constants.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                Private Members/Data Types/Constants.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        /// 
        /// <summary>
        ///   This is the filename that was opened or last saved as.
        /// </summary>
        /// 
        private string m_fileName;

        #endregion // Private Members/Data Types/Constants.




        #region Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // Form1
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initialises a new instance of this class.
        /// </summary>
        /// 
        public Form1()
        {
            InitializeComponent();

            this.m_fileName = null;
        }

        #endregion // Public Methods/Properties/etc.






        #region Non-Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Non-Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // Form1_Load
        //=------------------------------------------------------------------=
        /// <summary>
        ///   As the form is about to be shown, we'll just make sure that
        ///   some reasonable defaults are set, most notably relating to the
        ///   font.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cmdFontFace.SubItemSelected = "Arial";
            this.cmdFontSize.SubItemSelected = "12 pt";

            this.richTextBox1.HideSelection = false;
        }


        //=------------------------------------------------------------------=
        // exitToolStripMenuItem_Click
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Time to go bye-bye!
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //=------------------------------------------------------------------=
        // richTextBox1_SelectionChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Whenever the user changes the selection, go and update the
        ///   various UnifiedCommands.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            Font f = this.richTextBox1.SelectionFont;
            if (f != null)
            {

                if ((f.Style & FontStyle.Bold) != 0)
                {
                    this.cmdFontBold.CheckState = CheckState.Checked;
                }
                else
                {
                    this.cmdFontBold.CheckState = CheckState.Unchecked;
                }

                if ((f.Style & FontStyle.Italic) != 0)
                {
                    this.cmdFontItalic.CheckState = CheckState.Checked;
                }
                else
                {
                    this.cmdFontItalic.CheckState = CheckState.Unchecked;
                }

                this.cmdFontFace.SubItemSelected = f.Name;
            }
        }


        #region UnifiedCommand Event Processing
        //=------------------------------------------------------------------=
        // cmdFileOpen_Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has clicked on something attached to the Open Document
        ///   command (File.Open or a button on the toolbar).  Go and let them
        ///   open a document now.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void cmdFileOpen_Execute(object sender, EventArgs e)
        {
            ResourceManager rm = UnifiedCommandsDemoMain.GetResourceManager();
            DialogResult dr;

            this.openFileDialog1.AddExtension = true;
            this.openFileDialog1.DefaultExt = "rtf";
            this.openFileDialog1.Filter = rm.GetString("strOpenSaveFilter");
            this.openFileDialog1.Multiselect = false;
            dr = this.openFileDialog1.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                try
                {
					FileInfo f = new FileInfo(this.openFileDialog1.FileName);
					if (f.Extension == ".rtf")
						this.richTextBox1.LoadFile(this.openFileDialog1.FileName);
					else
						this.richTextBox1.LoadFile(this.openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    this.m_fileName = this.openFileDialog1.FileName;
                }

                catch (ArgumentException aee)
                {
                    MessageBox.Show("ArgumentException " + aee.Message.ToString());
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("IOException " + ioe.Message.ToString());
                }
                
            }
        }


        //=------------------------------------------------------------------=
        // cmdFileSave_Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has clicked on something attached to the Save Document
        ///   command (File.Save or a button on the toolbar).  Go and let them
        ///   save the document now.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void cmdFileSave_Execute(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_fileName))
            {
                cmdFileSaveAs_Execute(sender, EventArgs.Empty);
            }
            else
            {
                try
                {
                    this.richTextBox1.SaveFile(this.m_fileName);
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("IOException " + ioe.Message.ToString());
                }
            }
        }

                
        //=------------------------------------------------------------------=
        // cmdFileSaveAs_Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The use has clicked on the File.Save As menu item, so go and
        ///   save the document now, letting them choose a filename.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void cmdFileSaveAs_Execute(object sender, EventArgs e)
        {
            ResourceManager rm = UnifiedCommandsDemoMain.GetResourceManager();
            DialogResult dr;

            this.saveFileDialog1.AddExtension = true;
            this.saveFileDialog1.DefaultExt = "rtf";
            this.saveFileDialog1.Filter = rm.GetString("strOpenSaveFilter");
            this.saveFileDialog1.OverwritePrompt = true;
            dr = this.saveFileDialog1.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                try
                {
                    this.richTextBox1.SaveFile(this.saveFileDialog1.FileName);
                    this.m_fileName = this.saveFileDialog1.FileName;
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("IOException " + ioe.Message.ToString());
                }
            }
        }


        //=------------------------------------------------------------------=
        // cmdFilePrint_Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has clicked on something associated with the Print
        ///   Document Command.  We won't actually implement this, but include
        ///   it to make the sample application look cooler.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void cmdFilePrint_Execute(object sender, EventArgs e)
        {
            MessageBox.Show("Print Code would go here!");
        }


        //=------------------------------------------------------------------=
        // cmdFontBold_Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has changed whether the font should be bold or not.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void cmdFontBold_Execute(object sender, EventArgs e)
        {
            if (cmdFontBold.CheckState != CheckState.Checked)
            {
                cmdFontBold.CheckState = CheckState.Checked;
            }
            else
            {
                cmdFontBold.CheckState = CheckState.Unchecked;
            }

            setActiveFont();
        }


        //=------------------------------------------------------------------=
        // cmdFontItalic_Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has indicated that they would like to change how either
        ///   new text for typing or the currently selected text is 
        ///   italicised.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void cmdFontItalic_Execute(object sender, EventArgs e)
        {
            if (cmdFontItalic.CheckState != CheckState.Checked)
            {
                cmdFontItalic.CheckState = CheckState.Checked;
            }
            else
            {
                cmdFontItalic.CheckState = CheckState.Unchecked;
            }

            setActiveFont();
        }


        //=------------------------------------------------------------------=
        // cmdFontFace_Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has changed the font face for use in either the 
        ///   current selection or the text to be entered.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void cmdFontFace_Execute(object sender, EventArgs e)
        {
            setActiveFont();
        }


        //=------------------------------------------------------------------=
        // cmdFontSize_Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user wants to change the size of the currently selected
        ///   text or the text to be inserted.   They can do this either via
        ///   the menus or via the font toolbar.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void cmdFontSize_Execute(object sender, EventArgs e)
        {
            setActiveFont();
        }

        #endregion // UnifiedCommand Event Processing



        //=------------------------------------------------------------------=
        // setActiveFont
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Given that there was a change in either the bold, italic, or
        ///   font face selection, go and update the font being used for
        ///   insertion in the rich text box control.
        /// </summary>
        /// 
        private void setActiveFont()
        {
            FontStyle fs = 0;
            string face;
            string size;
            int pts = 12;

            //
            // build up the font style based on user selections.
            //
            if (cmdFontItalic.CheckState == CheckState.Checked)
            {
                fs |= FontStyle.Italic;
            }
            if (cmdFontBold.CheckState == CheckState.Checked)
            {
                fs |= FontStyle.Bold;
            }

            //
            // get the font size.  get the string, and remove the " pt"
            //
            size = this.cmdFontSize.SubItemSelected;
            if (size != null)
            {
                pts = int.Parse(size.Substring(0, size.Length - 3));
            }

            //
            // get the font face.
            //
            face = cmdFontFace.SubItemSelected;
            if (face == null)
            {
                face = "Arial";
            }

            //
            // finally, put together the font object, and set it on the 
            // SelectionFont property, which sets the text of either the
            // insertion point or currently selected text (the latter only if
            // there is any, else the former).
            //
            this.richTextBox1.SelectionFont = new Font(face, pts, fs);
        }

        #endregion // Non-Public Methods/Properties/etc.

    }
}
