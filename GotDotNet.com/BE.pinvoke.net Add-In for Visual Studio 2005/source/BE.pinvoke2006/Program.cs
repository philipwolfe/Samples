using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE.pinvoke2006.WebService;
using System.Diagnostics;

namespace BE.pinvoke2006
{
    public enum State { Searching, SearchingCompleted, SearchingError }

    static class Program
    {
        public static void Reset()
        {
            pInvokeService = null;
            content = null;
            currentLanguage = "(All)";
            currentSignature = null;
            state = State.SearchingCompleted;
        }

        static PInvokeService pInvokeService;

        public static PInvokeService PInvokeService
        {
            get
            {
                if (Program.pInvokeService == null)
                {
                    Program.pInvokeService = new PInvokeService();
                    Program.pInvokeService.GetResultsForFunctionCompleted += new GetResultsForFunctionCompletedEventHandler(pInvokeService_GetResultsForFunctionCompleted);
                }
                return Program.pInvokeService; 
            }
        }

        static void pInvokeService_GetResultsForFunctionCompleted(object sender, GetResultsForFunctionCompletedEventArgs e)
        {
            try
            {
                Content = e.Result;
                Program.State = State.SearchingCompleted;
            }
            catch (System.Reflection.TargetInvocationException tiex)
            {
                Content = new SignatureInfo[0];
                Error = tiex;
                Program.State = State.SearchingError;
            }
            //catch (Exception ex)
            //{
            //    return;
            //}
            //catch (System.Web.Services.Protocols.SoapException sex)
            //{
                
            //}
        }

        static Exception error;

        public static Exception Error
        {
            get { return Program.error; }
            set
            {
                if (error == value)
                    return;
                Program.error = value;
            }
        }

        public static void FindFunction(string function, string module)
        {
            Program.State = State.Searching;
            Program.CurrentSignature = null;
            PInvokeService.GetResultsForFunctionAsync(function, module);
        }

        static State state = State.SearchingCompleted;

        public static State State
        {
            get { return Program.state; }
            set 
            {
                if (Program.state == value)
                    return;
                Program.state = value;

                OnStateChanged(EventArgs.Empty);
            }
        }

        public static event EventHandler StateChanged;

        public static void OnStateChanged(EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(null, e);
        }

        static SignatureInfo[] content;

        public static SignatureInfo[] Content
        {
            get { return Program.content; }
            set 
            {
                if (content == value)
                    return;
                Program.content = value;
                Program.OnContentChanged(EventArgs.Empty);
            }
        }

        public static event EventHandler ContentChanged;

        static void OnContentChanged(EventArgs e)
        {
            if (ContentChanged != null)
                ContentChanged(null, e);
        }

        static SignatureInfo currentSignature;

        public static SignatureInfo CurrentSignature
        {
            get { return Program.currentSignature; }
            set
            {
                if (currentSignature == value)
                    return;
                Program.currentSignature = value;
                Program.OnCurrentSignatureChanged(EventArgs.Empty);
            }
        }

        public static event EventHandler CurrentSignatureChanged;

        static void OnCurrentSignatureChanged(EventArgs e)
        {
            if (CurrentSignatureChanged != null)
                CurrentSignatureChanged(null, e);
        }

        static string currentLanguage = "(All)";
        public static string CurrentLanguage
        {
            get
            {
                return currentLanguage;
            }
            set
            {
                if (currentLanguage == value)
                    return;
                currentLanguage = value;
                OnCurrentLanguageChanged(EventArgs.Empty);
            }
        }

        public static event EventHandler CurrentLanguageChanged;

        static void OnCurrentLanguageChanged(EventArgs e)
        {
            if (CurrentLanguageChanged != null)
                CurrentLanguageChanged(null, e);
        }

        public static string ConvertString(string s)
        {
            return s.Replace("|", Environment.NewLine);
        }

        internal static void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message, "BE.pinvoke2006", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void BrowseTo(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                Program.ShowException(ex);
            }
        }

        internal static void ConstributeSignatures(string username, string signatures)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                PInvokeService.ContributeSignaturesAndTypes(signatures, currentLanguage, username);
                //System.Threading.Thread.Sleep(3000);

                MessageBox.Show("The signatures and types are successfully constributed!", "BE.pinvoke2006");

            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


    }
}