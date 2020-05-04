using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Windows.Forms;
using System.Reflection;

namespace BE.pinvoke2006
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
		/// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		public Connect()
		{
		}

		/// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;

            _CommandBars cmdBars = (_CommandBars)_applicationObject.CommandBars;
            Microsoft.VisualStudio.CommandBars.CommandBar cmdBar = cmdBars["Code Window"];

            object[] contextGUIDS = new object[] { };
            Commands2 commands = (Commands2)_applicationObject.Commands;


            cmInsertPinvoke = commands.AddNamedCommand2(_addInInstance, insertCommandName, "Insert PInvoke Signatures..."
                , "Insert PInvoke Signatures..."
                , true, System.Reflection.Missing.Value, ref contextGUIDS
                , (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled
                , (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);

            cmInsertPinvoke.AddControl(cmdBar, 1);


            cmContributePinvoke = commands.AddNamedCommand2(_addInInstance, contributeCommandName, "Contribute PInvoke Signatures and Types..."
                , "Contribute PInvoke Signatures and Types..."
                , true, System.Reflection.Missing.Value, ref contextGUIDS
                , (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled
                , (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);

            cmContributePinvoke.AddControl(cmdBar, 2);
        }

        string insertCommandName = "INSERTPINVOKE";
        string insertCommandFullname = "BE.pinvoke2006.Connect.INSERTPINVOKE";
        
        string contributeCommandName = "CONTRIBUTEINVOKE";
        string contributeCommandFullname = "BE.pinvoke2006.Connect.CONTRIBUTEINVOKE";
        
        Command cmInsertPinvoke;
        Command cmContributePinvoke;

 

		/// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
            cmInsertPinvoke.Delete();
            cmContributePinvoke.Delete();
		}

		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}
		
		private DTE2 _applicationObject;
		private AddIn _addInInstance;

        #region IDTCommandTarget Members

        public void Exec(string CmdName, vsCommandExecOption ExecuteOption, ref object VariantIn
            , ref object VariantOut, ref bool Handled)
        {
            Handled = false;
            if (ExecuteOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            {
                if (CmdName == this.insertCommandFullname)
                {
                    Handled = true;

                    Program.Reset();

                    DownloadForm df = new DownloadForm();
                    if (df.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (Program.CurrentSignature != null)
                        {
                            TryInsert(Program.ConvertString(Program.CurrentSignature.Signature));
                        }
                    }
                    return;
                }
                else if (CmdName == this.contributeCommandFullname)
                {
                    Handled = true;

                    Program.Reset();

                    try
                    {
                        string activeDocumentLanguage = _applicationObject.ActiveDocument.Language;
                        Program.CurrentLanguage = activeDocumentLanguage;
                        UploadForm uf = new UploadForm();
                        uf.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        public void QueryStatus(string CmdName, vsCommandStatusTextWanted NeededText, ref vsCommandStatus StatusOption, ref object CommandText)
        {
            if (NeededText == EnvDTE.vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                if (CmdName == this.insertCommandFullname)
                {
                    StatusOption = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                }
                else if (CmdName == this.contributeCommandFullname)
                {
                    StatusOption = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                }
            }
        }

        #endregion

        void TryInsert(string s)
        {
            try
            {
                Document activeDoc = _applicationObject.ActiveDocument;
                if (activeDoc == null)
                    return;

                object oSelection = activeDoc.Selection;
                Type tSelection = oSelection.GetType();

                object[] args = new object[] { s };

                tSelection.InvokeMember("Insert"
                    , BindingFlags.InvokeMethod | (BindingFlags.Public | BindingFlags.Instance)
                    , null,
                    oSelection,
                    args);

                return;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}