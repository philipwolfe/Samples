//TODO: For now, you must register from a command prompt with the command: 
//	"RegAsm $SAFEOBJNAME$.dll"
//Also, the resulting $SAFEOBJNAME$Setup.msi file is to be run, and the DLL file copied onto the CORPATH.

namespace $SAFEOBJNAME$
{
  using System;
  using Office;
//BEGIN VSOnly
  using EnvDTE;
//END VSOnly

  // <summary>
  //   The object for implementing an Add-in.
  // </summary>
  // <seealso class='IDTExtensibility2' />
//BEGIN VSCommand
  public class Connect : Object, IDTExtensibility2, IDTCommandTarget
//END VSCommand
//BEGIN NOT VSCommand
  public class Connect : Object, IDTExtensibility2
//END NOT VSCommand
  {
    
    // <summary>
    //      Implements the OnConnection method of the IDTExtensibility2 interface. 
    //      Receives notification that the Add-in is being loaded.
    // </summary>
    // <param term='application'>
    //      Root object of the host application.
    // </param>
    // <param term='connectMode'>
    //      Describes how the Add-in is being loaded.
    // </param>
    // <param term='addInInst'>
    //      Object representing this Add-in.
    // </param>
    // <seealso class='IDTExtensibility2' />
    public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref object[] custom)
    {
//BEGIN VSOnly
      m_ApplicationObject = (_DTE)application;
          m_AddInInstance = (AddIn)addInInst;
//END VSOnly
//BEGIN VSCommand
      if(connectMode == ext_ConnectMode.ext_cm_UISetup)
      {
        String strProgID;
        Commands commands;
		Command command;
        _CommandBars commandBars;
		CommandBar commandBar;
		CommandBarControl commandBarControl;
        object []contextGUIDS;
        contextGUIDS = new object[] { };

        strProgID = m_AddInInstance.ProgID;
        strProgID += ".CommandName";
        commands = m_ApplicationObject.Commands;
        commandBars = m_ApplicationObject.CommandBars;
        command = commands.AddNamedCommand(m_AddInInstance, strProgID, strProgID, strProgID, true, 12, ref contextGUIDS, 0);

		commandBars = m_ApplicationObject.CommandBars;
		commandBar = (CommandBar)commandBars["Tools"];
		commandBarControl = command.AddControl(commandBar, 1);
      }
//END VSCommand
//BEGIN NOT VSOnly
      m_ApplicationObject = application;
          m_AddInInstance = addInInst;
//END NOT VSOnly
    }

    // <summary>
    //      Implements the OnDisconnection method of the IDTExtensibility2 interface. 
    //      Receives notification that the Add-in is being unloaded.
    // </summary>
    // <param term='disconnectMode'>
    //      Describes how the Add-in is being unloaded.
    // </param>
    // <param term='custom'>
    //      Array of parameters that are host application specific.
    // </param>
    // <seealso class='IDTExtensibility2' />
    public void OnDisconnection(ext_DisconnectMode disconnectMode, ref object[] custom)
    {
    }

    // <summary>
    //      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. 
    //      Receives notification that the collection of Add-ins has changed.
    // </summary>
    // <param term='custom'>
    //      Array of parameters that are host application specific.
    // </param>
    // <seealso class='IDTExtensibility2' />
    public void OnAddInsUpdate(ref object[] custom)
    {
    }

    // <summary>
    //      Implements the OnStartupComplete method of the IDTExtensibility2 interface. 
    //      Receives notification that the host application has completed loading.
    // </summary>
    // <param term='custom'>
    //      Array of parameters that are host application specific.
    // </param>
    // <seealso class='IDTExtensibility2' />
    public void OnStartupComplete(ref object[] custom)
    {
    }

    // <summary>
    //      Implements the OnBeginShutdown method of the IDTExtensibility2 interface. 
    //      Receives notification that the host application is being unloaded.
    // </summary>
    // <param term='custom'>
    //      Array of parameters that are host application specific.
    // </param>
    // <seealso class='IDTExtensibility2' />
    public void OnBeginShutdown(ref object[] custom)
    {
    }
//BEGIN VSCommand
    // <summary>
    //      Implements the QueryStatus method of the IDTCommandTarget interface. 
    //      This is called when the command's availability is updated
    // </summary>
    // <param term='commandName'>
    // </param>
    // <param term='neededText'>
    // </param>
    // <param term='status'>
    // </param>
    // <param term='commandText'>
    // </param>
    // <seealso class='Exec' />
    public void QueryStatus(string commandName, EnvDTE.vsCommandStatusTextWanted neededText, ref EnvDTE.vsCommandStatus status, ref object commandText)
    {
    }

    // <summary>
    //      Implements the Exec method of the IDTCommandTarget interface. 
    //      This is called when the command is invoked.
    // </summary>
    // <param term='commandName'>
    // </param>
    // <param term='executeOption'>
    // </param>
    // <param term='varIn'>
    // </param>
    // <param term='varOut'>
    // </param>
    // <param term='handled'>
    // </param>
    // <seealso class='Exec' />
    public void Exec(string commandName, EnvDTE.vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
    {
    }
//END VSCommand
//BEGIN VSOnly
    _DTE m_ApplicationObject;
    AddIn m_AddInInstance;
//END VSOnly
//BEGIN NOT VSOnly
    object m_ApplicationObject;
    object m_AddInInstance;
//END NOT VSOnly
  }
}
