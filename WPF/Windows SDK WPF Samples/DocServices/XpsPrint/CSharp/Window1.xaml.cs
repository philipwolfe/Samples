// XpsPrint SDK Sample - Window1.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved. 

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Printing;
using Microsoft.Win32;
using SDKSampleHelper;


namespace SDKSample
{
    // ------------------------- partial class Window1 ------------------------
    /// <summary>
    ///   Provides interaction logic for Window1.xaml user interface.</summary>
    public partial class Window1 : Window
    {
        // --------------------------- Constructor ----------------------------
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


        // ----------------------- ContentDir getter --------------------------
        /// <summary>
        ///   Gets the string to the \Content directory.</summary>
        public String ContentDir
        {
            get
                { return _contentDir; }
        }


        #region Button Event Handlers
        // -------------------------- OnBtnSaveClick --------------------------
        /// <summary>
        ///   Called when the "Save (synchronous)" button is clicked.</summary>
        private void OnBtnPrintClick(object sender, RoutedEventArgs e)
        {
            ButtonHelperPrint(false);
        }


        // ----------------------- OnBtnSaveAsyncClick ------------------------
        /// <summary>
        ///   Called when the "Save (asynchronous)" button is clicked.</summary>
        private void OnBtnPrintAsyncClick(object sender, RoutedEventArgs e)
        {
            ButtonHelperPrint(true);
        }


        // ------------------------ ButtonHelperPrint -------------------------
        /// <summary>
        ///   Saves the current DocumentViewer content either
        ///   synchronously (waiting for completion) or
        ///   asynchronously (not waiting for completion).</summary>
        /// <param name="async">
        ///   true to save asynchronously; false to save synchronously.</param>
        private void ButtonHelperPrint(bool async)
        {
            // Display Printer dialog for user to
            // choose the printer to output to.
            XpsPrintHelper printHelper = new XpsPrintHelper(_contentDir);
            PrintDialog printDialog = printHelper.GetPrintDialog();
            if (printDialog == null)
                return;     //user selected cancel

            PrintQueue printQueue = printDialog.PrintQueue;

            if (async)
            {
                _printHelper = printHelper;

                //Make progress controls visible
                AsyncPrintLabel.Visibility = Visibility.Visible;
                AsyncPrintProgress.Visibility = Visibility.Visible;
                AsyncPrintStatus.Visibility = Visibility.Visible;

                //register for async archiving events
                _printHelper.OnAsyncPrintChange +=
                    new XpsPrintHelper.AsyncPrintChangeHandler(AsyncPrintEvent);

                AsyncPrintProgress.Value = 10;
                AsyncPrintStatus.Text = "Async Print Initiated";

                UIEnabled(false, false, true);
            }// end:if (async)

            // Print the DocumentViewer's current content.
            switch (currentMode)
            {
                case eGuiMode.SingleVisual:
                {
                    printHelper.PrintSingleVisual(printQueue, async);
                    break;
                }
                case eGuiMode.MultipleVisuals:
                {
                    printHelper.PrintMultipleVisuals(printQueue, async);
                    break;
                }
                case eGuiMode.SingleFlowDocument:
                {
                    printHelper.PrintSingleFlowContentDocument(
                        printQueue, async);
                    break;
                }
                case eGuiMode.SingleFixedDocument:
                {
                    printHelper.PrintSingleFixedContentDocument(
                        printQueue, async);
                    break;
                }
                case eGuiMode.MultipleFixedDocuments:
                {
                    printHelper.PrintMultipleFixedContentDocuments(
                        printQueue, async);
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
            _printHelper.CancelAsync();
        }

        #endregion // Button Event Handlers


        // -------------------------- AsyncPrintEvent -------------------------
        /// <summary>
        ///   Called as the asynchronous save proceeds.</summary>
        /// <param name="saveHelper"></param>
        /// <param name="asyncInformation">
        ///   Progress information about the asynchronous save.</param>
       private void AsyncPrintEvent(
            object printHelper, AsyncPrintEventArgs asyncInformation)
        {
            if (asyncInformation.Completed)
            {
                AsyncPrintStatus.Text = asyncInformation.Status;
                AsyncPrintProgress.Value = 100;

                MessageBox.Show(asyncInformation.Status, "Completed");

                //Hide async controls
                AsyncPrintLabel.Visibility = Visibility.Hidden;
                AsyncPrintProgress.Visibility = Visibility.Hidden;
                AsyncPrintStatus.Visibility = Visibility.Hidden;

                //Enabled print buttons, and disable the cancel button
                UIEnabled(true, true, false);
            }
            else
            {
                AsyncPrintStatus.Text = asyncInformation.Status;
                AsyncPrintProgress.Value += 5;
            }
        }// end:AsyncPrintEvent()


        // -------------------- GetContainerPathFromDialog --------------------
        /// <summary>
        ///   Dislays a Save As... dialog for the user to choose the path and
        ///   container (file) name to save the document content to.</summary>
        /// <returns></returns>
        private string GetContainerPathFromDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "XPS document files (*.xps)|*.xps";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == true)
            {   // The user specified a valid path and filename.
                return saveFileDialog.FileName;
            }
            else
            {   // The user clicked "Cancel" to the Save As... dialog.
                return null;
            }
        }// end:GetContainerPathFromDialog()


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
        private void UIEnabled(bool bPrint, bool bPrintAsync, bool bCancel)
        {
            // Set button state
            btnPrint.IsEnabled = bPrint;
            btnPrintAsync.IsEnabled = bPrintAsync;
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
            WPFContent wpfContent = new WPFContent(_contentDir);
            docViewer.Document =
                wpfContent.LoadViewableFixedContent(containerName, true);
        }


        #region Private Members

        // GUI Enumerations
        private enum eGuiMode
        {
            SingleVisual,
            MultipleVisuals,
            SingleFlowDocument,
            SingleFixedDocument,
            MultipleFixedDocuments
        };

        // String to save the current Content directory
        private String _contentDir;

        // The current DocumentViewer content mode
        private eGuiMode currentMode;

        // State to enable cancellation
        private XpsPrintHelper _printHelper = null;

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

        private const String _combinedContainer =
            @"Content\CombinedFixedDocumentSequence.xps";

        #endregion //Private Members


    }// end:partial class Window1

}// end:namespace SDKSample
