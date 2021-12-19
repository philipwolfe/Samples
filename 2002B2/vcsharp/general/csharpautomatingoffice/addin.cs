using System;
using System.Runtime.InteropServices;
using System.Threading;
using Word;
using Office;

public enum ext_ConnectMode
    {	ext_cm_AfterStartup	= 0,
	ext_cm_Startup	= 1,
	ext_cm_External	= 2,
	ext_cm_CommandLine	= 3
    }

public enum ext_DisconnectMode
    {	ext_dm_HostShutdown	= 0,
	ext_dm_UserClosed	= 1
    }


[Guid("B65AD801-ABAF-11D0-BB8B-00A0C90F2744")]
public interface IDTExtensibility2
{
    void OnConnection( 
        Application app,
        ext_ConnectMode ConnectMode,
        string AddInInst,
        [MarshalAs(UnmanagedType.SafeArray)]ref Array custom);
    
    void OnDisconnection( 
        ext_DisconnectMode RemoveMode,
        [MarshalAs(UnmanagedType.SafeArray)]ref Array custom);
    
    void OnAddInsUpdate( 
        [MarshalAs(UnmanagedType.SafeArray)]ref Array custom);
    
    void OnStartupComplete( 
        [MarshalAs(UnmanagedType.SafeArray)]ref Array custom);
    
    void BeginShutdown( 
        [MarshalAs(UnmanagedType.SafeArray)]ref Array custom);
    
}

public delegate void ComBarEventHandler(ref Office._CommandBarButton Ctrl, ref bool CancelDefault);

[Guid("114D81D9-D689-4572-AC2B-137CD88AC90C")]
public class CConnect : IDTExtensibility2
{
	int m_cRef; //Reference count for this component
	event ComBarEventHandler m_pCBEH;
	static int g_cServerLocks = 0;
	
	public CConnect() 
	{
		//Increment our global refcount so that we know not to unload the addin
		Interlocked.Increment(ref g_cServerLocks); 
		m_cRef = 0; //We don't yet have any interface pointers to this object
	
		//Lets the addin know when the user clicked the new item on the toolbar. 
		m_pCBEH = null;
		//TODO: ADD ANY NECESSARY CONSTRUCTION
	} 

	~CConnect()
	{
		//Decrement our global refcount so we know when to unload the addin
		Interlocked.Decrement(ref g_cServerLocks); 

		//TODO: ADD ANY NECESSARY DESTRUCTION
	}

	//Once the connection to the host application is made, these
	//are the functions that you will use to customize behavior.
	public void OnConnection (Application app,
		ext_ConnectMode ConnectMode, string AddInInst,
		ref Array custom)
	{
	}
	public void OnDisconnection(ext_DisconnectMode RemoveMode,
		ref Array custom)
	{
	}
	public void OnAddInsUpdate(ref Array custom)
	{
	}
	public void OnStartupComplete(ref Array custom)
	{
	}
	public void BeginShutdown(ref Array custom)
	{
	}
	public void AddItemToCommandBar()
	{
	}

}

