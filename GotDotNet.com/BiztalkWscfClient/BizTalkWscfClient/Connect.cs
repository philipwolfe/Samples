#region Imports

using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EnvDTE;
using Extensibility;
using Microsoft.Office.Core;

#endregion

namespace BizTalkWscfClient
{
	#region Read me for Add-in installation and setup information.
	// When run, the Add-in wizard prepared the registry for the Add-in.
	// At a later time, if the Add-in becomes unavailable for reasons such as:
	//   1) You moved this project to a computer other than which is was originally created on.
	//   2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
	//   3) Registry corruption.
	// you will need to re-register the Add-in by building the MyAddin21Setup project 
	// by right clicking the project in the Solution Explorer, then choosing install.
	#endregion
	
	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[Guid("235ADF50-6A9A-4916-B1AA-CD062EE6EC9A"), ProgId("BizTalkWscfClient.Connect")]
	public class Connect : Object, IDTExtensibility2, IDTCommandTarget
	{
		#region ..cctor

		/// <summary>
		///		Implements the constructor for the Add-in object.
		///		Place your initialization code within this method.
		/// </summary>
		public Connect()
		{
		}

		#endregion

		#region Public methods

		/// <summary>
		///      Implements the OnConnection method of the IDTExtensibility2 interface.
		///      Receives notification that the Add-in is being loaded.
		/// </summary>
		/// <param term='application'>
		///      Root object of the host application.
		/// </param>
		/// <param term='connectMode'>
		///      Describes how the Add-in is being loaded.
		/// </param>
		/// <param term='addInInst'>
		///      Object representing this Add-in.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
			applicationObject = (_DTE)application;
			addInInstance = (AddIn)addInInst;
			
			object []contextGUIDS = new object[] { };

			try
			{
				// delete previous commands, it might be from aprevious installation;
				// be sure we register the right ones

				foreach (Command command in applicationObject.Commands)
				{
					if (command.Name != null && command.Name.IndexOf("BizTalkWscfClient") != -1)
					{
						command.Delete();
					}
				}

				// Create the 'generate odx' and 'post process wscf proxy' add-in commands.
				Command cmdGenerateOdxInDir = applicationObject.Commands.AddNamedCommand(addInInstance, 
					generateOdxInDirCmdName, "Generate Web Port .odx in this folder", "Generates in a project directory an .odx file based on a web proxy port generated by Wscf", 
					false, 1975, ref contextGUIDS, 
					(int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled);

				Command cmdGenerateOdxInRoot = applicationObject.Commands.AddNamedCommand(addInInstance, 
					generateOdxInProjRootCmdName, "Generate Web Port .odx in the project root", "Generates in the project dir  an .odx file based on a web proxy port generated by Wscf", 
					false, 1975, ref contextGUIDS, 
					(int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled);

				// Specify the menu (Folder) where the add-in command should go.
				CommandBar cmdBar = applicationObject.CommandBars["Folder"];

				// Add the commands to the corresponding command bar.
				cmdGenerateOdxInDir.AddControl(cmdBar, 1);				

				cmdBar = applicationObject.CommandBars["Project"];
				cmdGenerateOdxInRoot.AddControl(cmdBar, 1);
			}
			catch(Exception e)
			{
				MessageBox.Show("Error encountered during initialization: " + e.Message, 
					addInName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}			
		}

		/// <summary>
		///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
		///     Receives notification that the Add-in is being unloaded.
		/// </summary>
		/// <param term='disconnectMode'>
		///      Describes how the Add-in is being unloaded.
		/// </param>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
		}

		/// <summary>
		///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		///      Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
		}

		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}

		/// <summary>
		///      Implements the QueryStatus method of the IDTCommandTarget interface.
		///      This is called when the command's availability is updated
		/// </summary>
		/// <param term='commandName'>
		///		The name of the command to determine state for.
		/// </param>
		/// <param term='neededText'>
		///		Text that is needed for the command.
		/// </param>
		/// <param term='status'>
		///		The state of the command in the user interface.
		/// </param>
		/// <param term='commandText'>
		///		Text requested by the neededText parameter.
		/// </param>
		/// <seealso class='Exec' />
		public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
		{
			try
			{
				if(neededText != vsCommandStatusTextWanted.vsCommandStatusTextWantedNone
					|| applicationObject.SelectedItems.MultiSelect  
					|| ( commandName != FullCommandName(generateOdxInDirCmdName)
						&& commandName != FullCommandName(generateOdxInProjRootCmdName)))
				{
					return;
				}

				// get project type 
				IList projects = (IList)applicationObject.ActiveSolutionProjects;
				if (projects.Count != 1)
				{
					return;
				}

				Project project = (Project) projects[0];
				if (commandName == FullCommandName(generateOdxInProjRootCmdName) 
					&& "{8E2B9538-4BF0-42B1-B5B9-D28BE4B0C699}".Equals(project.Kind.ToUpper()))
				{
					status = vsCommandStatus.vsCommandStatusSupported|vsCommandStatus.vsCommandStatusEnabled;
				}

				ProjectItem projectItem = applicationObject.SelectedItems.Item(1).ProjectItem;
				if (projectItem == null || projectItem.FileCount != 1)
				{
					return;
				}			
				
				string fileName = projectItem.get_FileNames(1);

				if (commandName == FullCommandName(generateOdxInDirCmdName) 
					&& "{8E2B9538-4BF0-42B1-B5B9-D28BE4B0C699}".Equals(project.Kind.ToUpper()))
				{
					if (Directory.Exists(fileName))
					{
						status = vsCommandStatus.vsCommandStatusSupported|vsCommandStatus.vsCommandStatusEnabled;
					}
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error encountered during detecting command status: " + exc.Message, 
					addInName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		///      Implements the Exec method of the IDTCommandTarget interface.
		///      This is called when the command is invoked.
		/// </summary>
		/// <param term='commandName'>
		///		The name of the command to execute.
		/// </param>
		/// <param term='executeOption'>
		///		Describes how the command should be run.
		/// </param>
		/// <param term='varIn'>
		///		Parameters passed from the caller to the command handler.
		/// </param>
		/// <param term='varOut'>
		///		Parameters passed from the command handler to the caller.
		/// </param>
		/// <param term='handled'>
		///		Informs the caller if the command was handled or not.
		/// </param>
		/// <seealso class='Exec' />
		public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
			try
			{
				handled = false;
				if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
				{
					ProjectItem file = applicationObject.SelectedItems.Item(1).ProjectItem;
					if (commandName == FullCommandName(generateOdxInDirCmdName))
					{
						ExecGenerateOdxCmd(new AddOdxFileInDirCmd(file));
						handled = true;
					}
					else if (commandName == FullCommandName(generateOdxInProjRootCmdName))
					{
						ExecGenerateOdxCmd(new AddOdxFileInRootCmd(applicationObject.SelectedItems.Item(1).Project));
						handled = true;
					}
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error encountered during executing command: " + exc.Message, 
					addInName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Private methods

		private void ExecGenerateOdxCmd(IAddOdxFileCommand addOdxFileCommand)
		{
			try
			{
				if (generateOdxForm == null || !lastAddOdxFileCmd.Equals(addOdxFileCommand))
				{
					generateOdxForm = new GenerateOdxForm(addOdxFileCommand);
					lastAddOdxFileCmd = addOdxFileCommand;
				}
				generateOdxForm.ShowDialog();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error encountered during initializing the port type generation setup form: \r\n" + exc.Message, 
					addInName, MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}

		private string FullCommandName(string commandName)
		{
			return string.Format("{0}{1}", "BizTalkWscfClient.Connect.", commandName);
		}

		#endregion

		#region Private member variables

		private static string generateOdxInDirCmdName = "BizTalkWscfClientGenerateOdxInDirCmd";
		private static string generateOdxInProjRootCmdName = "BizTalkWscfClientGenerateOdxInProjRootCmd";

		private _DTE applicationObject;
		private AddIn addInInstance;
		private GenerateOdxForm generateOdxForm;
		private IAddOdxFileCommand lastAddOdxFileCmd;

		#endregion

		#region public static constants

		public const string addInName = "BizTalkWscfClient";

		#endregion		
	}
}