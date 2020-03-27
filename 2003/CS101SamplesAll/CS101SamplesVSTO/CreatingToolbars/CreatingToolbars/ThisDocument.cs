using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace CreatingToolbars
{
    public partial class ThisDocument
    {
        private Office.CommandBar commandBar ;
        private Office.CommandBarButton wordCountButton;
        private Office.CommandBarButton wordsPerParagraphButton;
        private Office.CommandBarButton addButton;
        private List<Office.CommandBarButton> dynamicButtons =
            new List<Office.CommandBarButton>();

        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            CreateToolbar();
        }

        /// <summary>
        /// Create a toolbar with three dedicated buttons, and the ability
        /// to add additional buttons at runtime.
        /// 
        /// NOTE: When exiting the application, Word may prompt to save
        /// changes to Normal.dot.  You do NOT want to do this.
        /// </summary>
        private void CreateToolbar()
        {
            // Verify that the toolbar is not already present
            try
            {
                commandBar = this.CommandBars["TestBar"];
                MessageBox.Show("Toolbar was already present!");
            }
            catch
            {
                // Not present, so create a new one
                commandBar = Application.CommandBars.Add("TestBar", missing, missing, true);
            }

            try
            {
                // Create the three static buttons, and wire them up
                // to event handlers

                // Notice the "missing" object references in the Controls.Add()
                // calls.  This is used when invoking COM interop calls from C#
                // and is provided automatically by the VSTO framework.
                // In VB, this is not needed as missing arguments can simply
                // can simply be omitted, however in C# a value must be present,
                // hence the "missing" object of type System.Type.Missing.

                // Word count button
                wordCountButton = (Office.CommandBarButton)
                    commandBar.Controls.Add(1, missing, missing, missing, true);
                wordCountButton.Style = Office.MsoButtonStyle.msoButtonCaption;
                wordCountButton.Caption = "Word Count";
                wordCountButton.Tag = "WordCount";

                wordCountButton.Click +=
                    new Office._CommandBarButtonEvents_ClickEventHandler(wordCountButton_Click);

                // Words per paragraph button
                wordsPerParagraphButton = (Office.CommandBarButton)
                    commandBar.Controls.Add(1, missing, missing, missing, true);
                wordsPerParagraphButton.Style = Office.MsoButtonStyle.msoButtonCaption;
                wordsPerParagraphButton.Caption = "Words Per Paragraph";
                wordsPerParagraphButton.Tag = "WordsPerPara";

                wordsPerParagraphButton.Click +=
                    new Office._CommandBarButtonEvents_ClickEventHandler(wordsPerParaButton_Click);

                // Button to add new buttons
                addButton = (Office.CommandBarButton)
                    commandBar.Controls.Add(1, missing, missing, missing, true);
                addButton.Style = Office.MsoButtonStyle.msoButtonCaption;
                addButton.Caption = "Add Button";
                addButton.Tag = "AddButton";

                addButton.Click +=
                    new Office._CommandBarButtonEvents_ClickEventHandler(addButton_Click);

                // Make the command bar visible (a new command bar is
                // not visible by default
                commandBar.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Initialize error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// On each click, a new button is created and wired up to
        /// the shared newButton_Click event handler.
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        void addButton_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            Office.CommandBarButton newButton = (Office.CommandBarButton)
                    commandBar.Controls.Add(1, missing, missing, missing, true);
            newButton.Style = Office.MsoButtonStyle.msoButtonCaption;
            newButton.Caption = "New Button" + commandBar.Controls.Count;
            newButton.Tag = "NewButton" + commandBar.Controls.Count;

            newButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(newButton_Click);

            dynamicButtons.Add(newButton);
        }

        /// <summary>
        /// A simply event handler to display the name of
        /// the current button when clicked
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        void newButton_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            MessageBox.Show("You clicked " + Ctrl.Caption);
        }

        /// <summary>
        /// Divides the number of words in the document by the number of
        /// paragraphs in order to obtain the words/paragraph ratio.
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        void wordsPerParaButton_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            MessageBox.Show("Words per paragraph: " +
                this.ActiveWindow.Document.Words.Count / this.ActiveWindow.Document.Paragraphs.Count);
        }

        /// <summary>
        /// Simply displays the word count for the document.
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        void wordCountButton_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            MessageBox.Show("Words count: " + this.ActiveWindow.Document.Words.Count);
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
