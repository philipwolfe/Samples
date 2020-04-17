// XpsSyncAsyncSave SDK Sample - Window1.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved. 

using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using SDKSampleHelper;


namespace SDKSample
{
    // ------------------------- partial class Window1 ------------------------
    /// <summary>
    ///   Provides interaction logic for Window1.xaml user interface.</summary>
    public partial class Window1 : Window
    {
        /// <summary>
        ///   Default constructor.</summary>
        public Window1()
        {
            _contentDir = Directory.GetCurrentDirectory();
            InitializeComponent();
        }


        // --------------------------- WindowLoaded ---------------------------
        /// <summary>
        ///   Called when the windows is initially loaded to display.</summary>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {       
            currentMode = eGuiMode.SingleVisual;
            cbMode.SelectedIndex = (int)currentMode;
        }


        #region Button Event Handlers
        // -------------------------- OnBtnSaveClick --------------------------
        /// <summary>
        ///   Called when the "Save (synchronous)" button is clicked.</summary>
        private void OnBtnSaveClick(object sender, RoutedEventArgs e)
        {
            ButtonHelperSave(false);
        }


        // ----------------------- OnBtnSaveAsyncClick ------------------------
        /// <summary>
        ///   Called when the "Save (asynchronous)" button is clicked.</summary>
        private void OnBtnSaveAsyncClick(object sender, RoutedEventArgs e)
        {   
            ButtonHelperSave(true);
        }


        // ------------------------- ButtonHelperSave -------------------------
        /// <summary>
        ///   Saves the current DocumentViewer content either
        ///   synchronously (waiting for completion) or
        ///   asynchronously (not waiting for completion).</summary>
        /// <param name="async">
        ///   true to save asynchronously; false to save synchronously.</param>
        private void ButtonHelperSave(bool async)
        {
            // Display Save As... dialog for user to
            // choose path and container (file) name. 
            String newContainerPath = GetContainerPathFromDialog();
            if (newContainerPath == null)
                return;

            SaveHelper saveHelper = new SaveHelper(_contentDir);

            if (async)
            {
                _saveHelper = saveHelper;

                //Make progress controls visible
                AsyncSaveLabel.Visibility = Visibility.Visible;
                AsyncSaveProgress.Visibility = Visibility.Visible;
                AsyncSaveStatus.Visibility = Visibility.Visible;

                //register for async saving events
                _saveHelper.OnAsyncSaveChange +=
                    new SaveHelper.AsyncSaveChangeHandler(AsyncSaveEvent);

                AsyncSaveProgress.Value = 10;

                AsyncSaveStatus.Text = "Async Save Initiated";

                UIEnabled(false, false, true);
            }// end:if (async)

            // Save the DocumentViewer's current content.
            switch (currentMode)
            {
                case eGuiMode.SingleVisual:
                {
                    saveHelper.SaveSingleVisual(
                        newContainerPath, async);
                    break;
                }
                case eGuiMode.MultipleVisuals:
                {
                    saveHelper.SaveMultipleVisuals(
                        newContainerPath, async);
                    break;
                }
                case eGuiMode.SingleFlowDocument:
                {
                    saveHelper.SaveSingleFlowContentDocument(
                        newContainerPath, async);
                    break;
                }
                case eGuiMode.SingleFixedDocument:
                {
                    saveHelper.SaveSingleFixedContentDocument(
                        newContainerPath, async);
                    break;
                }
                case eGuiMode.MultipleFixedDocuments:
                {
                    saveHelper.SaveMultipleFixedContentDocuments(
                        newContainerPath, async);
                    break;
                }
            }// end:switch (currentMode)
        }// end:ButtonHelperSave()


        // ------------------------- OnBtnCancelClick -------------------------
        /// <summary>
        ///   Called when the asynchronous save
        ///   "Cancel" button is clicked.</summary>
        private void OnBtnCancelClick(object sender, RoutedEventArgs e)
        {
            _saveHelper.CancelAsync();
        }

        #endregion // Button Event Handlers


        // -------------------------- AsyncSaveEvent --------------------------
        /// <summary>
        ///   Called as the asynchronous save proceeds.</summary>
        /// <param name="saveHelper"></param>
        /// <param name="asyncInformation">
        ///   Progress information about the asynchronous save.</param>
        private void AsyncSaveEvent(
                     object saveHelper, AsyncSaveEventArgs asyncInformation)
        {
            if (asyncInformation.Completed)
            {
                AsyncSaveStatus.Text = asyncInformation.Status;

                MessageBox.Show(asyncInformation.Status, "Completed");

                //Hide async controls
                AsyncSaveLabel.Visibility = Visibility.Hidden;
                AsyncSaveProgress.Visibility = Visibility.Hidden;
                AsyncSaveStatus.Visibility = Visibility.Hidden;

                // Enable save buttons and disable the cancel button.
                UIEnabled(true, true, false);
            }
            else // Save has not completed, update the progress bar.
            {   
                AsyncSaveStatus.Text = asyncInformation.Status;
                AsyncSaveProgress.Value += 10;
            }
        }


        // -------------------- GetContainerPathFromDialog --------------------
        /// <summary>
        ///   Dislays a Save As... dialog for the user to choose the path and
        ///   container (file) name to save the document content to.</summary>
        /// <returns></returns>
        private string GetContainerPathFromDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "XPS Document files (*.xps)|*.xps";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == true)
            {   // The user specified a valid path and filename.
                return saveFileDialog.FileName;
            }
            else
            {   // The user clicked "Cancel" to the Save As... dialog.
                return null;
            }
        }


        // ---------------------------- UIEnabled -----------------------------
        /// <summary>
        ///   Enables or disables the "Save synchronous", "Save 
        ///   asynchronous", and "Cancel" user buttons.</summary>
        /// <param name="bSave">
        ///   true to enable "Save synchronous"; false to disable.</param>
        /// <param name="bSaveAsync">
        ///   true to enable "Save asynchronous"; false to disable.</param>
        /// <param name="bCancel"></param>
        ///   true to enable the "Cancel" button; false to disable.</param>
        private void UIEnabled(bool bSave, bool bSaveAsync, bool bCancel)
        {
            // Set button state
            btnSave.IsEnabled = bSave;
            btnSaveAsync.IsEnabled = bSaveAsync;
            btnCancelAsync.IsEnabled = bCancel;

            this.ApplyTemplate();
        }


        // -------------------------- OnCbModeChange --------------------------
        /// <summary>
        ///   Handles user changes to the combobox selection.</summary>
        /// <param name="sender">
        ///   The sender initiating the event.</param>
        /// <param name="e">
        ///   The event args.</param>
        private void OnCbModeChange(object sender, RoutedEventArgs e)
        {
            // Update window mode based on user selection
            UpdateUI((eGuiMode)cbMode.SelectedIndex);
        }


        // ------------------------------ UpdateUI ----------------------------
        /// <summary>
        ///   Updates UI based on the combobox selected GUI mode change.</summary>
        /// <param name="mode">
        ///   The new user selected content mode for the DocumentViewer.</param>
        private void UpdateUI(eGuiMode mode)
        {
            currentMode = mode;

            switch (mode)
            {
                case eGuiMode.SingleVisual:
                    InitDocumentViewer(_contentDir + "\\" + _oneVisualContainer);
                    UIEnabled(true, true, false);
                    break;

                case eGuiMode.MultipleVisuals:
                    InitDocumentViewer(_contentDir + "\\" + _multipleVisualsContainer);
                    UIEnabled(true, true, false);
                    break;

                case eGuiMode.SingleFlowDocument:
                    InitDocumentViewer(_contentDir + "\\" + _flowDocumentContainer);
                    UIEnabled(true, true, false);
                    break;

                case eGuiMode.SingleFixedDocument:
                    InitDocumentViewer(_contentDir + "\\" + _fixedDocumentContainer);
                    UIEnabled(true, true, false);
                    break;

                case eGuiMode.MultipleFixedDocuments:
                    InitDocumentViewer(_contentDir + "\\" + _fixedDocumentSequenceContainer);
                    UIEnabled(true, true, false);
                    break;
            }
        }// end:UpdateUI()


        // ------------------------- InitDocumentViewer -----------------------
        /// <summary>
        ///   Loads content from a file into a DocumentViewer control.</summary>
        /// <param name="containerName">
        ///   The XPS container file to load to the DocViewer control.</param>
        private void InitDocumentViewer(string containerName)
        {
            XPFContent xpfContent = new XPFContent(_contentDir);
            docViewer.Document = xpfContent.LoadViewableFixedContent(containerName);
        }

        #region Private Members

        String _contentDir; // Path to the Content directory

        // DocumentViewer content mode enumerations
        private enum eGuiMode
        {
            SingleVisual,
            MultipleVisuals,
            SingleFlowDocument,
            SingleFixedDocument,
            MultipleFixedDocuments
        };

        // The current DocumentViewer content mode
        private eGuiMode currentMode;

        private SaveHelper _saveHelper;

        private const String _oneVisualContainer =
            @"Content\ViewOneVisual.xps";

        private const String _multipleVisualsContainer =
            @"Content\ViewMultipleVisuals.xps";

        private const String _flowDocumentContainer =
            @"Content\ViewFlowDocument.xps";

        private const String _fixedDocumentContainer =
            @"Content\ViewFixedDocument.xps";

        private const String _fixedDocumentSequenceContainer =
            @"Content\ViewFixedDocumentSequence.xps";
        
        #endregion //Private Members

    }// end:partial class Window1

}// end:namespace SDKSample
