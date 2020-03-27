'******************************************************************************
' SL.VBS
'
' Field Content Team Script Library
'
' Author: Marcelo Uemura (marcelou@microsoft.com)
'
' Main Guidlines:
' - Most of the functions start with a prefix that indicates what product it
'   relates to (e.g. MSMQPurgeQueue or BizTalkGetInstallationFolder)
' - Functions that start with <ProductName>Helper are helper functions specific 
'   to this product and are not intended to be called directly by the user. Be
'   careful when deleting these functions as they are called by other functions
'   in the same product group
' - All functions that start with an SLUtil prefix are generic to all products
'   so, again, be careful when deleting these functions
'
' - Note that for every function in this module, there is a comment header with
'   a brief description of parameters and return values and also a disabled
'   sample code that shows how to use it. Just remove the comment character from 
'   the sample code and execute this script and you can see how this particular
'   function works
'
' 

Option Explicit

'******************************************************************************
' Scribt Library log (dialog feedback) toggle
'   Enable = "1"
'   Disable = "0"
'

Const LOGMESSAGE = "0"


'******************************************************************************
' Function Name : SLUtilGetScriptPath
' Input         : none
' Return value  : Path where the VBS file is being executed 
' Description   : Get the path from where the VBS file is being executed
' TestCode      :
'
' Wscript.Echo SLUtilGetScriptPath
'

Function SLUtilGetScriptPath

    Dim objFSO 
    Set objFSO = CreateObject("Scripting.FileSystemObject")
    
    SLUtilGetScriptPath = objFSO.GetParentFolderName( WScript.ScriptFullName )
    
    Set objFSO = nothing
End Function

'******************************************************************************
' Function Name : SLUtilLogMessage
' Input         : nSeverity             Severity of the Message
'                 strMessage            Message
' Return value  : none
' Description   : Log a message in the file defined by constant LOG_FILE
' TestCode      :
'
' SLUtilLogMessage 1, "Error Message"
'

Sub SLUtilLogMessage( ByVal nSeverity, ByVal strMessage )

    If LOGMESSAGE = 0 Then Exit Sub

    Dim strBuffer
    strBuffer = CStr(Now) & ": (" & CStr(nSeverity) & ") " & strMessage
    WScript.Echo strBuffer
    If nSeverity <> 0 Then
        Dim objShell
        Set objShell = WScript.CreateObject("WScript.Shell")
        objShell.LogEvent 1, strMessage
        Set objShell = nothing
    End If
End Sub 

'******************************************************************************
' Function Name : SLUtilGetComputerName
' Input         : None
' Return value  : Return the computer name
' Description   : Returns the host computer name using Network object
' TestCode      :
'
' WScript.Echo SLUtilGetComputerName
'

Function SLUtilGetComputerName
    Dim objNet 
    Set objNet = WScript.CreateObject("WScript.Network")
    SLUtilGetComputerName = objNet.ComputerName 
End Function

'******************************************************************************
' Function Name : SLUtilStartService
' Input         : strServiceName 	Name of the service
' Return value  : none
' Description   : Start a service
' TestCode      :
'
' SLUtilStartService "BTWSvcMgr" ' Start the XLANG Scheduler
'
Function SLUtilStartService( ByVal strServiceName )
    SLUtilShellExec "Net Start " & strServiceName
	SLUtilLogMessage 0, "SLUtilStartService: Service " & strServiceName & _
	    " Started."
End Function

'******************************************************************************
' Function Name : SLUtilStopService
' Input         : strServiceName 	Name of the service
' Return value  : none
' Description   : Start a service
' TestCode      :
'
' SLUtilStopService "BTWSvcMgr" ' Start the XLANG Scheduler
'
Sub SLUtilStopService( ByVal strServiceName )
    SLUtilShellExec "Net Stop " & strServiceName
	SLUtilLogMessage 0, "SLUtilStopService: Service " & strServiceName & _
	    " Stopped."
End Sub

'******************************************************************************
' Function Name : SLUtilReboot
' Input         : none
' Return value  : none
' Description   : Reboot the machine
' TestCode      :
'
' SLUtilReboot  
'
Sub SLUtilReboot
    Dim objServices
    Dim objOSSet
    Dim objOS
    Set objServices = GetObject _
        ("WinMgmts:{impersonationLevel=impersonate,(ShutDown)}")
    Set objOSSet = objServices.InstancesOf("Win32_OperatingSystem")
    For Each objOS In objOSSet
        objOS.Win32Shutdown (2)
    Next
	SLUtilLogMessage 0, "SLUtilReboot"
End Sub

'******************************************************************************
' Function Name : SLUtilLogoff
' Input         : none
' Return value  : none
' Description   : Logoff the current user
' TestCode      :
'
' SLUtilLogoff
'
Sub SLUtilLogoff
    Dim objServices
    Dim objOSSet
    Dim objOS
    Set objServices = GetObject _
        ("WinMgmts:{impersonationLevel=impersonate,(ShutDown)}")
    Set objOSSet = objServices.InstancesOf("Win32_OperatingSystem")
    For Each objOS In objOSSet
        objOS.Win32Shutdown (0)
    Next
	SLUtilLogMessage 0, "SLUtilLogoff"
End Sub


'******************************************************************************
' Function Name : SLUtilCreateShortcut
' Input         : strLocation           Shortcut to be created
'                 strTarget             File that the shortcut points to
'                 strArguments          Arguments
'                 strDescription        Description of the shortcut 
'                 strWorkingDir         Working folder
' Return value  : none
' Description   : Executes a command line
' TestCode      :
'
' SLUtilCreateShortcut "c:\np.lnk", "c:\winnt\notepad.exe", "", "", ""
' SLUtilCreateShortcut "c:\localhost.lnk", "http://localhost/", "", "", ""
'

Sub SLUtilCreateShortcut( byval strLocation, _
    byval strTarget, _
    byval strArguments, _
    byval strDescription, _
    byval strWorkingDir)
    
    Dim WshShell
    Dim oShellLink
    Set WshShell = WScript.CreateObject("WScript.Shell")
    Set oShellLink = WshShell.CreateShortcut(strLocation)
    oShellLink.TargetPath = strTarget
    oShellLink.Arguments = strArguments
    oShellLink.WindowStyle = 1
    oShellLink.Description = strDescription
    oShellLink.WorkingDirectory = strWorkingDir
    oShellLink.Save
    Set oShellLink = nothing
    Set WshShell = nothing
end sub



'******************************************************************************
' Function Name : SLUtilShellExec
' Input         : strCmdLine 	    Command line to be executed
' Return value  : none
' Description   : Executes a command line
' TestCode      :
'
' SLUtilShellExec "Notepad"
'
Sub SLUtilShellExec( strCmdLine )
	SLUtilLogMessage 0, "SLUtilShellExec: " & strCmdLine
    Dim objShell
    Set objShell =  WScript.CreateObject ("Wscript.Shell")
    ' objShell.Run CommandLine, WindowStyle (0=hide), WaitOnReturn
    objShell.Run strCmdline, 0, TRUE
    Set objShell = Nothing
End Sub


'******************************************************************************
' Function Name : SQLServerExecScript
' Input         : strScriptFileName 	    Script to be executed
'                 strUsername               username
'                 strPassword               password
' Return value  : none
' Description   : Executes a SQL Server script
' TestCode      :
'
' SQLServerExecScript "c:\test.sql"
'

Sub SQLServerExecScript( ByVal strScriptFileName, _
    ByVal strUsername, _
    ByVal strPassword )
    
    Dim strCmdLine
	SLUtilLogMessage 0, "SQLServerExecScript: " & strScriptFileName
	
	strCmdLine = "OSQL -U """ & strUserName & """"
	strCmdLine = strCmdLine & " -P """ & strPassword & """"
	strCmdLine = strCmdLine & " -i """ & strScriptFileName & """"
	
	SLUtilShellExec strCmdLine
End Sub

'******************************************************************************
' Function Name : IISCreateVirtualDirectory
' Input         : strVirtualDirectoryName       Name of the VRoot
'                 strPhysicalPath               Path of the folder that
'                                               contains the VRoot
' Return value  : None
' Description   : Create an IIS Virtual Directory
' 
' TestCode      :
'
' IISCreateVirtualDirectory "FM_SOAP", "C:\temp"
'

Sub IISCreateVirtualDirectory(ByVal strVirtualDirectoryName, _
    ByVal strPhysicalPath)

    Dim strCompName
    Dim strIIS
    Dim strVirtualDirectoryPath
    Dim objVirtualDirectory
    Dim objIIS
    Dim objFSO

    '
    ' Verifies if VRoot already exists
    '    
    strCompName = SLUtilGetComputerName
    strIIS = "IIS://" & strCompName & "/W3SVC/1/Root"

    On Error Resume Next
    Set objIIS = GetObject(strIIS  & "/" & strVirtualDirectoryName)

    If Err.Number = 0 Then
        SLUtilLogMessage 1, strVirtualDirectoryName & _
            " Virtual Directory Already Exist"
        Set objVirtualDirectory = Nothing
        Set objIIS = Nothing
        Set objFSO = Nothing
        On Error GoTo 0
        Exit Sub
    End If

    Err.Clear

    Set objIIS = Nothing
    Set objIIS = GetObject(strIIS)

    if Err.Number > 0 then
        SLUtilLogMessage 1, "Can't Create Virtual Directory " & _
            strVirtualDirectoryName & " :" & err.description
        Set objVirtualDirectory = Nothing
        Set objIIS = Nothing
        Set objFSO = Nothing
        On Error GoTo 0
        Exit Sub
    End If


    Set objFSO = CreateObject("Scripting.FileSystemObject")

    if not objFSO.FolderExists(strPhysicalPath) then
        SLUtilLogMessage 1, strPhysicalPath & _
            ": Folder Does Not Exist, Can't Create Virtual Directory"
        Set objVirtualDirectory = Nothing
        Set objIIS = Nothing
        Set objFSO = Nothing
        On Error GoTo 0
        Exit Sub
    End if
    
    '
    ' Create Virtual Directory
    '
    Set objVirtualDirectory = objIIS.Create("IISWebVirtualDir", _
        strVirtualDirectoryName)
    objVirtualDirectory.AccessScript = 1
    objVirtualDirectory.Path = strPhysicalPath
    objVirtualDirectory.SetInfo 
    objVirtualDirectory.AppCreate 1
    Set objVirtualDirectory = Nothing

    if Err.Number > 0 then
        SLUtilLogMessage 1, "Create Virtual Directory " & Err.Description
    else
        SLUtilLogMessage 0, strVirtualDirectoryName & _
	    " Virtual Directory Created" 
    End if

    Set objIIS = Nothing
    Set objFSO = Nothing
    Set objVirtualDirectory = Nothing
    On Error GoTo 0

End Sub

'******************************************************************************
' Function Name : IISDeleteVirtualDirectory
' Input         : strVirtualDirectoryName       Name of the VRoot
' Return value  : None
' Description   : Delete an IIS Virtual Directory
' 
' TestCode      :
'
' IISDeleteVirtualDirectory "FM_SOAP"
'

Sub IISDeleteVirtualDirectory(ByVal strVirtualDirectoryName )

    Dim strCompName
    Dim strIIS
    Dim objIIS
    Dim strVirtualDirectoryPath
    Dim objVirtualDirectory

    SLUtilLogMessage 0, "IISDeleteVirtualDirectory: " & strVirtualDirectoryName

    strCompName = SLUtilGetComputerName
    strIIS = "IIS://" & strCompName & "/W3SVC/1/Root"

    On Error Resume Next
    Set objVirtualDirectory = GetObject(strIIS  & "/" & strVirtualDirectoryName)

    If Err.Number <> 0 Then
        Set objIIS = nothing
        Set objVirtualDirectory = Nothing
        On Error GoTo 0
        Exit Sub
    End If

    On Error GoTo 0
 
    objVirtualDirectory.AppDelete   
    Set objIIS = GetObject(strIIS)
    
    objIIS.Delete "IISWebDirectory", strVirtualDirectoryName
    
    Set objIIS = nothing
    Set objVirtualDirectory = Nothing
    On Error GoTo 0

End Sub

'******************************************************************************
' Function Name : MSMQPurgeQueue
' Input         : strQueueName          Name of the Queue
' Return value  : None
' Description   : Purge all messages in a queue
' 
' TestCode      :
'
' MSMQPurgeQueue ".\private$\testqueue"
'

Sub MSMQPurgeQueue( strQueueName )

    Const MQ_RECEIVE_ACCESS = 1
    Const MQ_DENY_NONE = 0

    Dim objQI
    Dim objQueue
    Dim objMessage

    SLUtilLogMessage 0, "MSMQPurgeQueue: " & strQueueName
    
    Set objQI = CreateObject("MSMQ.MSMQQueueInfo")
    objQI.PathName = strQueueName
    Set objQueue = objQI.Open( MQ_RECEIVE_ACCESS, MQ_DENY_NONE )

    Do While True
        Set objMessage = objQueue.Receive(,,,100)
        If objMessage Is Nothing Then Exit Do
    Loop
    objQueue.Close
    
    Set objQueue = Nothing
    Set objQI = Nothing
    Set objMessage = Nothing
End Sub

'******************************************************************************
' Function Name : MSMQCreateQueue
' Input         : strQueueName          Name of the Queue
'                 strQueueLabel         Queue Label
' Return value  : None
' Description   : Create a queue
' 
' TestCode      :
'
' MSMQCreateQueue ".\private$\testqueue", "Test Queue Label"
'
Sub MSMQCreateQueue( ByVal strQueueName, ByVal strQueueLabel )
    dim objQI

    SLUtilLogMessage 0, "MSMQCreateQueue: " & strQueueName

    Set objQI = CreateObject("MSMQ.MSMQQueueInfo")
    objQI.PathName = strQueueName
    objQI.Label = strQueueLabel
    ' the first true states that the queue should be transactional
    ' the second one that everybody could read this queue
    objQI.Create true, true
    Set objQI = nothing
End Sub

'******************************************************************************
' Function Name : MSMQDeleteQueue
' Input         : strQueueName          Name of the Queue
' Return value  : None
' Description   : Delete a queue
' 
' TestCode      :
'
' MSMQDeleteQueue ".\private$\testqueue"
'

Sub MSMQDeleteQueue( ByVal strQueueName )
    On Error Resume Next
    dim objQI
    
    SLUtilLogMessage 0, "MSMQDeleteQueue: " & strQueueName
    
    Set objQI = CreateObject("MSMQ.MSMQQueueInfo")
    objQI.PathName = strQueueName
    objQI.Delete    
    Set objQI = nothing
    On Error GoTo 0
End Sub

'******************************************************************************
' Function Name : COMPlusShutdownApplication
' Input         : strApplicationName    Name of the Application
' Return value  : None
' Description   : Shutdown a COM+ Application
' 
' TestCode      :
'
' COMPlusShutdownApplication "BizTalk Server Out-of-Process Package"
'
Sub COMPlusShutdownApplication( ByVal strApplicationName )
    Dim objCatalog
    Set objCatalog = CreateObject("COMAdmin.COMAdminCatalog")
    objCatalog.ShutdownApplication strApplicationName
    Set objCatalog = Nothing
End Sub 


'******************************************************************************
' Function Name : COMPlusRemoveApplication
' Input         : strApplicationName    Name of the Application
' Return value  : None
' Description   : Remove a COM+ Application from the COM+ Catalog
' 
' TestCode      :
'
' COMPlusRemoveApplication "TestApp"
'
Sub COMPlusRemoveApplication( ByVal strApplicationName )
    Dim objCatalog 
    Dim objApplications
    Dim objApp
    Dim nAppNumber
    
    SLUtilLogMessage 0, "COMPlusRemoveApplication: " & strApplicationName

    '  Open a session with the objCatalog
    '  Instantiate a COMAdminCatalog object 
    Set objCatalog = CreateObject("COMAdmin.COMAdminCatalog")
    
    '  Create a new COM+ application
    '  First get the "Applications" collection from the objCatalog,
    '  representing it with the generic COMAdminCatalogCollection 
    Set objApplications = objCatalog.GetCollection("Applications")    
    objApplications.Populate

    ' Remove application if exists
    nAppNumber = 0
    For Each objApp In objApplications
       If objApp.Value("Name") = strApplicationName Then
          objApplications.Remove nAppNumber
       End If
       nAppNumber = nAppNumber + 1
    Next 
    objApplications.SaveChanges
    
    Set objApp = nothing
    Set objApplications = nothing
    Set objCatalog = nothing    
End Sub 


'******************************************************************************
' Function Name : COMPlusAddApplication
' Input         : strApplicationName    Name of the Application
' Return value  : None
' Description   : Add a COM+ Application to the COM+ Catalog
' 
' TestCode      :
'
' COMPlusAddApplication "TestApp"
'

Sub COMPlusAddApplication( ByVal strApplicationName )
    
    Dim objCatalog 
    Dim objApplications
    Dim objApp

    
    SLUtilLogMessage 0, "COMPlusAddApplication: " & strApplicationName
    
    '  Open a session with the objCatalog
    '  Instantiate a COMAdminCatalog object 
    Set objCatalog = CreateObject("COMAdmin.COMAdminCatalog")
    
    '  Create a new COM+ application
    '  First get the "Applications" collection from the objCatalog,
    '  representing it with the generic COMAdminCatalogCollection 
    Set objApplications = objCatalog.GetCollection("Applications") 

    '  Add a new item to this collection, representing the item
    '  with the generic object, COMAdminCatalogObject 
    Set objApp = objApplications.Add
    
    '  Set the "Name" of the new item, using the Value property
    '  on COMAdminCatalogObject. Value is a generic property taking a
    '  name/value (string/variant) pair to set a named property 
    objApp.Value("Name") = strApplicationName
    
    '  Save changes made to the "Applications" collection 
    objApplications.SaveChanges
    
    Set objApp = nothing
    Set objApplications = nothing
    Set objCatalog = nothing
End Sub


'******************************************************************************
' Function Name : COMPlusAddComponent
' Input         : strApplicationName    Name of the Application
'                 strDll                Full path of the component DLL
' Return value  : None
' Description   : Add a Component to a COM+ Application
' 
' TestCode      :
'
' COMPlusAddComponent "TestApp", _
'    "C:\MSDNContent\Q2FY01\DEVQ201-01\Demo\XLangDemo3\XlangDemo3MSMQ\XLangDemo3MSMQ.DLL"
'

Sub COMPlusAddComponent( ByVal strApplicationName, ByVal strDllPath )
    
    Dim objCatalog 
    Dim objApplications
    Dim objApp

    
    SLUtilLogMessage 0, "COMPlusAddComponent: " & strApplicationName & ", " & _
        strDllPath
    
    '  Open a session with the objCatalog
    '  Instantiate a COMAdminCatalog object 
    Set objCatalog = CreateObject("COMAdmin.COMAdminCatalog")
    
    '  Create a new COM+ application
    '  First get the "Applications" collection from the objCatalog,
    '  representing it with the generic COMAdminCatalogCollection 
    Set objApplications = objCatalog.GetCollection("Applications") 
    
    '  Install components into the application
    '  Use the InstallComponent method on COMAdminCatalog 
    '  in this case the last two parameters are passed as empty strings 
    objCatalog.InstallComponent strApplicationName, strDllPath, "", ""
        
    '  Save these changes
    objApplications.SaveChanges
    
    Set objApplications = nothing
    Set objCatalog = nothing

End Sub     


'******************************************************************************
' Function Name : BizTalkGetWebDAVURL
' Input         : none
' Return value  : URL to WebDAV repository
' Description   : Returns a URL to root of WebDAV repository. Used as a helper
'                 function to CreateDocuments based on schemas stored on 
'                 WebDAV, as BizTalkCreateDocument function requires a document
'                 stored on the webDAV
' 
' TestCode      :
'
' WScript.Echo BizTAlkGetWebDAVURL
'

Function BizTalkGetWebDAVURL
    Dim strWebDAVURL
    strWebDAVURL = "http://" & SLUtilGetComputerName & _
        "/BizTalkServerRepository"
    BizTalkGetWebDAVURL = strWebDAVURL
	SLUtilLogMessage 0, "BizTalkGetWebDAVURL: " & strWebDAVURL
End Function

'******************************************************************************
' Function Name : BizTalkGetInstallationFolder
' Input         : none
' Return value  : URL to WebDAV repository
' Description   : Returns a URL to root of WebDAV repository. Used as a helper
'                 function to CreateDocuments based on schemas stored on 
'                 WebDAV, as BizTalkCreateDocument function requires a document
'                 stored on the webDAV
' 
' TestCode      :
'
' WScript.Echo BizTalkGetInstallationFolder
'

Function BizTalkGetInstallationFolder
	Dim strProdID
	Dim objInstaller
	Dim strInstallationFolder

	strProdID = "{E0993E49-C0A8-11D2-973D-00C04F79E4B3}"

	Set objInstaller = CreateObject ("WindowsInstaller.Installer")
	strInstallationFolder = objInstaller.ProductInfo(strProdID, "InstallLocation")
	Set objInstaller = Nothing
	
	BizTalkGetInstallationFolder = strInstallationFolder	
	SLUtilLogMessage 0, "BizTalkGetInstallationFolder: " & strInstallationFolder

End Function

'******************************************************************************
' Function Name : BizTalkGetOrganizationID
' Input         : strOrganization   Name of the organization
' Return value  : Organization Id
' Description   : Find the Organization Id from the Organization Name
' 
' TestCode      :
'
' Dim nOrgId
' nOrgId = BizTalkGetOrganizationID( "Home Organization" )
' MsgBox nOrgId
'

Function BizTalkGetOrganizationID( ByVal strOrganization )

    Dim nOrgId
    Dim objBTS
    Dim objOrganization
    SLUtilLogMessage 0, "BizTalkGetOrganizationId: " & strOrganization
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objOrganization = objBTS.CreateOrganization
    
    Call objOrganization.LoadByName( strOrganization )    
    nOrgId = objOrganization.Handle
        
    Set objBTS = nothing
    Set objOrganization = nothing

    BizTalkGetOrganizationID = nOrgId
End Function
    
'******************************************************************************
' Function Name : BizTalkHelperRemoveObject
' Input         : objRef            Reference to an instance of object to be
'                                   removed
'                 strName           Name of the object to be removed
' Return value  : None
' Description   : This is supposed to be used as a helper function to
'                 BizTalkRemoveDocument, BizTalkRemovePort, BizTalkRemoveChannel
' 
' TestCode      :
'
' Dim objBTS
' Set objBTS = CreateObject("BizTalk.BizTalkConfig")
' Set objDocument = objBTS.CreateDocument
' BizTalkHelperRemoveObject objDocument, "ShippingQuery"
' Set objBTS = nothing
' Set objDocument = nothing
'

Sub BizTalkHelperRemoveObject( ByRef objRef, ByVal strName )

    On Error Resume Next
    objRef.LoadByName strName
    If Err.Number = 0 Then
        objRef.Remove
    Else
        ' Object does not exist, ignore the error
        Err.Clear
    End If
    On Error GoTo 0
End Sub
    
'******************************************************************************
' Function Name : BizTalkRemoveOrganization
' Input         : strName           Name of the object to be removed
' Return value  : None
' Description   : Remove a Organization
' 
' TestCode      :
'
' BizTalkRemoveOrganization "MSDNHomeOrganization"
'

Sub BizTalkRemoveOrganization( ByVal strName )
    Dim objBTS
    Dim objOrganization
    SLUtilLogMessage 0, "BizTalkRemoveOrganization: " & strName
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objOrganization = objBTS.CreateOrganization
    BizTalkHelperRemoveObject objOrganization, strName
    Set objBTS = nothing
    Set objOrganization = nothing
End Sub


'******************************************************************************
' Function Name : BizTalkRemoveApplication
' Input         : strAppName         Name of the Application to be removed
' Return value  : None
' Description   : Remove an Application
' 
' TestCode      :
'
' BizTalkRemoveApplication "MSDNApp"
'

Sub BizTalkRemoveApplication( ByVal strAppName )
    
    Dim objBTS
    Dim objOrganization
    Dim rsApplications
    
    SLUtilLogMessage 0, "BizTalkRemoveApplication: " & strAppName
    
    On Error Resume Next
    
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objOrganization = objBTS.CreateOrganization
    objOrganization.LoadByName "Home Organization"
    If Err.Number <> 0 Then
        SLUtilLogMessage 1, "BizTalkRemoveApplication: Can't find Home Organization"
        
        Set objBTS = nothing 
        Set objOrganization = nothing
        Set rsApplications = nothing
        On Error GoTo 0
        Exit Sub
    End If

    Set rsApplications = objOrganization.Applications
    Do While not rsApplications.eof
        If rsApplications.Fields("name") = strAppName Then
            objOrganization.RemoveApplication rsApplications.Fields("Id")
            Exit Do
        End If    
        rsApplications.MoveNext
    Loop     
    
    objOrganization.Save

    Set objBTS = nothing
    Set objOrganization = nothing
    Set rsApplications = nothing
    On Error GoTo 0
    
End Sub


'******************************************************************************
' Function Name : BizTalkRemoveDocument
' Input         : strName           Name of the object to be removed
' Return value  : None
' Description   : Remove a Document
' 
' TestCode      :
'
' BizTalkRemoveDocument "MSDNDocument"
'

Sub BizTalkRemoveDocument( ByVal strName )
    Dim objBTS
    Dim objDocument
    SLUtilLogMessage 0, "BizTalkRemoveDocument: " & strName
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objDocument = objBTS.CreateDocument
    BizTalkHelperRemoveObject objDocument, strName
    Set objBTS = nothing
    Set objDocument = nothing
End Sub
    
'******************************************************************************
' Function Name : BizTalkRemovePort
' Input         : strName           Name of the object to be removed
' Return value  : None
' Description   : Remove a Port
' 
' TestCode      :
'
' BizTalkRemovePort "ShippingQueryPort"
'

Sub BizTalkRemovePort( ByVal strName )
    Dim objBTS
    Dim objPort
    SLUtilLogMessage 0, "BizTalkRemovePort: " & strName
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objPort = objBTS.CreatePort
    BizTalkHelperRemoveObject objPort, strName
    Set objBTS = nothing
    Set objPort = nothing
End Sub
    
    
'******************************************************************************
' Function Name : BizTalkRemoveChannel
' Input         : strName           Name of the object to be removed
' Return value  : None
' Description   : Remove a Channel
' 
' TestCode      :
'
' BizTalkRemoveChannel "ShippingQueryChannel"
'

Sub BizTalkRemoveChannel( ByVal strName )
    Dim objBTS
    Dim objChannel
    SLUtilLogMessage 0, "BizTalkRemoveChannel: " & strName
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objChannel = objBTS.CreateChannel
    BizTalkHelperRemoveObject objChannel, strName
    Set objBTS = nothing
    Set objChannel = nothing
End Sub
    
'******************************************************************************
' Function Name : BizTalkCreateOrganization
' Input         : strName           Name of the organization
' Return value  : OrganizationID
' Description   : Create an Organization and return its ID
' 
' TestCode      :
'
' BizTalkCreateOrganization "MSDNHomeOrganization"
'

Function BizTalkCreateOrganization( ByVal strName )
    Dim objBTS
    Dim objOrg
    Dim nHandle
    SLUtilLogMessage 0, "BizTalkCreateOrganization: " & strName
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objOrg = objBTS.CreateOrganization
    objOrg.Name = strName
    objOrg.Create
    nHandle = objOrg.Handle
    Set objOrg = Nothing
    Set objBTS = nothing
    BizTalkCreateOrganization = nHandle
End Function 


'******************************************************************************
' Function Name : BizTalkCreateApplication
' Input         : strAppName         Name of the Application to be created
' Return value  : Application ID
' Description   : Create an Application on Home Organization
' 
' TestCode      :
'
' Wscript.Echo "AppID: " & BizTalkCreateApplication( "MSDNApp" )
'

Function BizTalkCreateApplication( ByVal strAppName )
    
    Dim nAppID
    Dim objBTS
    Dim objOrganization
    Dim rsApplications
    
    SLUtilLogMessage 0, "BizTalkCreateApplication: " & strAppName
    
    On Error Resume Next
    
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objOrganization = objBTS.CreateOrganization
    objOrganization.LoadByName "Home Organization"
    If Err.Number <> 0 Then
        SLUtilLogMessage 1, "BizTalkCreateApplication: Can't load Home Organization " 
        
        Set objBTS = nothing 
        Set objOrganization = nothing
        Set rsApplications = nothing
        On Error GoTo 0
        Exit Function
    End If

    objOrganization.CreateApplication( strAppName )
    objOrganization.Save
    
    Set rsApplications = objOrganization.Applications
    Do While not rsApplications.eof
        If rsApplications.Fields("name") = strAppName Then
            nAppID = rsApplications.Fields("Id")
            Exit Do
        End If    
        rsApplications.MoveNext
    Loop

    Set objBTS = nothing
    Set objOrganization = nothing
    Set rsApplications = nothing
    On Error GoTo 0
    
    BizTalkCreateApplication = nAppID
End Function

'******************************************************************************
' Function Name : BizTalkCreateDocument
' Input         : strName           Name of the Document
'                 strReferenceURL   URL to the schema that defines this 
'                                   document
' Return value  : DocumentID
' Description   : Create an Document and return its ID
' 
' TestCode      :
'
' BizTalkCreateDocument "MSDNDocument", BizTalkGetWebDAVURL & _
'   "/docspecs/Microsoft/CommonPO.XML"
'

Function BizTalkCreateDocument( ByVal strName, ByVal strReferenceURL )
    Dim objBTS
    Dim objDoc
    Dim nID
    SLUtilLogMessage 0, "BizTalkCreateDocument: " & strName & ", " & _
        strReferenceURL
        
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objDoc = objBTS.CreateDocument
    objDoc.Clear
    objDoc.Name = strName
    objDoc.Reference = strReferenceURL
    nId = objDoc.Create
    Set objBTS = nothing
    Set objDoc = nothing
    BizTalkCreateDocument = nID
End Function

'******************************************************************************
' Function Name : BizTalkHelperCreatePort
' Input         : strPortName       Name of the Port
'                 bToOrganization   Defines if this port is to an Organization
'                                   or to an Application
'                 nOrganizationId   Organization ID if bToOrganization is True
'                 nApplicationID    Application ID if bToOrganization is False
'                 nTransportType    Transport Type, see constants defined below
'                 strAddress        Port address
' Return value  : PortID
' Description   : Create an Port and return its ID
' 
Const BIZTALK_TRANSPORT_TYPE_NONE = 1
Const BIZTALK_TRANSPORT_TYPE_HTTP = 4
Const BIZTALK_TRANSPORT_TYPE_SMTP = 8
Const BIZTALK_TRANSPORT_TYPE_APPINTEGRATION = 32
Const BIZTALK_TRANSPORT_TYPE_MSMQ = 128
Const BIZTALK_TRANPSORT_TYPE_FILE = 256
Const BIZTALK_TRANSPORT_TYPE_HTTPS = 1024
Const BIZTALK_TRANSPORT_TYPE_OPENDESTINATION = 1024
Const BIZTALK_TRANSPORT_TYPE_LOOPBACK = 4096

' TestCode      :
'
' dim nOrgId
' nOrgId = BizTalkCreateOrganization( "MSDNHomeOrganization" )
' BizTalkHelperCreatePort "MSDNPort", true, nOrgId, 0, _
'   BIZTALK_TRANSPORT_TYPE_MSMQ, ".\private$\testqueue"
'

Function BizTalkHelperCreatePort( ByVal strPortName, _
    ByVal bToOrganization, _
    ByVal nOrganizationId, _
    ByVal nApplicationId, _
    ByVal nTransportType, _
    ByVal strAddress )
    
    Dim objBTS
    Dim objPort
    Dim nID
        
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objPort = objBTS.CreatePort
    objPort.Clear
    objPort.Name = strPortName
    If bToOrganization Then
        objPort.DestinationEndPoint.Organization = nOrganizationId
    Else
        objPort.DestinationEndPoint.Organization = BizTalkGetOrganizationID("Home Organization")
        objPort.DestinationEndPoint.Application = nApplicationId
    End If
    
    objPort.PrimaryTransport.Type = nTransportType
    objPort.PrimaryTransport.Address = strAddress
     
    nId = objPort.Create
    Set objBTS = nothing
    Set objPort = nothing
    BizTalkHelperCreatePort = nID
End Function


'******************************************************************************
' Function Name : BizTalkCreatePortToOrganization
' Input         : strPortName       Name of the Port
'                 nOrganizationId   Organization ID
'                 nTransportType    Transport Type
'                 strAddress        Port address
' Return value  : PortID
' Description   : Create an Port and return its ID
' 
' TestCode      :
'
' Dim nOrgId
' nOrgId = BizTalkCreateOrganization( "MSDNHomeOrganization" )
' BizTalkCreatePortToOrganization "MSDNPort", nOrgId, _
'   BIZTALK_TRANSPORT_TYPE_MSMQ, ".\private$\testqueue"
'

Function BizTalkCreatePortToOrganization( ByVal strPortName, _
    ByVal nOrganizationId, _
    ByVal nTransportType, _
    ByVal strAddress )
    
    Dim nPortId
    
    SLUtilLogMessage 0, "BizTalkCreatePortToOrganization: " & _
        strPortName & ", " & _
        CStr(nOrganizationID) & ", " & _
        CStr(nTransportType) & ", " & _
        strAddress
    
    nPortId = BizTalkHelperCreatePort( strPortName, true, nOrganizationId, 0, _
        nTransportType, strAddress )
    BizTalkCreatePortToOrganization = nPortId
End Function

'******************************************************************************
' Function Name : BizTalkCreatePortToApplication
' Input         : strPortName       Name of the Port
'                 nApplicationId    Application ID 
'                 nTransportType    Transport Type
'                 strAddress        Port address
' Return value  : PortID
' Description   : Create an Port and return its ID
' 
' TestCode      :
'
' Dim nAppId
' nAppID = BizTalkCreateApplication( "MSDNApp" )
' BizTalkCreatePortToApplication "MSDNPort", nAppId, _
'   BIZTALK_TRANSPORT_TYPE_MSMQ, ".\private$\testqueue"
'

Function BizTalkCreatePortToApplication( ByVal strPortName, _
    ByVal nApplicationId, _
    ByVal nTransportType, _
    ByVal strAddress )
    
    Dim nPortId
    
    SLUtilLogMessage 0, "BizTalkCreatePortToApplication: " & _
        strPortName & ", " & _
        CStr(nApplicationID) & ", " & _
        CStr(nTransportType) & ", " & _
        strAddress
    
    nPortId = BizTalkHelperCreatePort( strPortName, false, 0, nApplicationId, _
        nTransportType, strAddress )
    BizTalkCreatePortToApplication = nPortId
End Function


'******************************************************************************
' Function Name : BizTalkHelperCreateChannel
' Input         : strChannelName    Name of the Channel
'                 nOpennessType     Openness Type, See constants defined below
'                                   Only NOTOPEN, SOURCE and FROMWORKFLOW are
'                                   valid
'                 nOrgId            Organization Id
'                 nAppId            Application Id. If nAppId <> 0 then
'                                   nOrgId must be set to the Organization Id
'                                   of the Home Organization
'                 nInputDocId       Input Document Definition Id
'                 nOutputDocId      Output Document Definition Id
'                 strMapReference   Referent to a transformation map in the
'                                   repository. Only needed if nInputDoc <>
'                                   nOutputDoc
'                 nPortId           Port Id
' Return value  : ChannelID
' Description   : Create an channel and return its ID
' 
' TestCode      :
'
' See BizTalkCreateOpenSourceChannel, BizTalkCreateOpenSourceChannel, 
' BizTalkCreateFromAppChannel, BizTalkCreateFromOrgChannel
'
Const BIZTALK_OPENNESS_TYPE_EX_NOTOPEN = 1
Const BIZTALK_OPENNESS_TYPE_EX_SOURCE = 2
Const BIZTALK_OPENNESS_TYPE_EX_DESTINATION = 4
Const BIZTALK_OPENNESS_TYPE_EX_FROMWORKFLOW = 8
Const BIZTALK_OPENNESS_TYPE_EX_TOWORKFLOW = 16

Function BizTalkHelperCreateChannel( _
    ByVal strChannelName, _
    ByVal nOpennessType, _
    ByVal nOrgId, _
    ByVal nAppId, _
    ByVal nInputDocId, _
    ByVal nOutputDocId, _
    ByVal strMapReference, _
    ByVal nPortId )
    
    Dim objBTS
    Dim objChannel
    Dim nID
        
    Set objBTS = CreateObject("BizTalk.BizTalkConfig")
    Set objChannel = objBTS.CreateChannel
    objChannel.Clear
    objChannel.Name = strChannelName
    
    objChannel.SourceEndPoint.Openness = nOpennessType
    Select Case nOpennessType
        Case BIZTALK_OPENNESS_TYPE_EX_NOTOPEN
            ' Handle the following cases
            ' Channel from a different Organization or
            ' a channel from an Application from Home Organization
            objChannel.SourceEndPoint.Organization = nOrgId
            If nAppId <> 0 Then
                objChannel.SourceEndPoint.Application = nAppId
                If nOrgId <> BizTalkGetOrganizationID("Home Organization") Then
                    SLUtilLogMessage 1, "BizTalkHelperCreateChannel: " & _
                        "Channel from Application must have nOrgId = Home Organization"
                    objBTS = nothing
                    objChannel = nothing
                    Exit Function
                End If
            End If
            
        Case BIZTALK_OPENNESS_TYPE_EX_SOURCE
            ' Handle an open source channel: No Org or App defined
            objChannel.SourceEndPoint.Organization = 0
            objChannel.SourceEndPoint.Application = 0

        Case BIZTALK_OPENNESS_TYPE_EX_FROMWORKFLOW
            objChannel.SourceEndPoint.Application = 0
            objChannel.SourceEndPoint.Organization = nOrgId
            If nOrgId <> BizTalkGetOrganizationID("Home Organization") Then
                SLUtilLogMessage 1, "BizTalkHelperCreateChannel: " & _
                    "Channel from XLANG must have nOrgId = Home Organization"
                objBTS = nothing
                objChannel = nothing
                Exit Function
            End If
        
        Case Else
            SLUtilLogMessage 1, "BizTalkHelperCreateChannel: " & _
                "Invalid nOpennessType parameter " & CStr(nChannelOrigin)        
            objBTS = nothing
            objChannel = nothing
            Exit Function
    End Select
    
    objChannel.InputDocument = nInputDocId
    objChannel.OutputDocument = nOutputDocId
    If nInputDocId <> nOutputDocId Then
        If strMapReference <> "" Then
            objChannel.MapReference = strMapReference
        Else
            SLUtilLogMessage 1, "BizTalkHelperCreateChannel: " & _
                "nInputDoc <> nOutputDoc: must specify MapReference "
            objBTS = nothing
            objChannel = nothing
            Exit Function
        End If
    End If
        
    objChannel.Port = nPortId    
    nId = objChannel.Create
    
    Set objBTS = nothing
    Set objChannel = nothing
    BizTalkHelperCreateChannel = nID
End Function


'******************************************************************************
' Function Name : BizTalkCreateXLANGChannel
' Input         : strChannelName    Name of the Channel
'                 nAppId            Application Id. 
'                 nInputDocId       Input Document Definition Id
'                 nOutputDocId      Output Document Definition Id
'                 strMapReference   Referent to a transformation map in the
'                                   repository. Only needed if nInputDoc <>
'                                   nOutputDoc
'                 nPortId           Port Id

' Return value  : ChannelID
' Description   : Create a channel that receives its message from a XLANG schedule
' 
' TestCode      :
'
' Dim nOrgId
' Dim nPortId
' Dim nDocId
' nOrgId = BizTalkCreateOrganization( "MSDNHomeOrganization" )
' nPortId = BizTalkCreatePortToOrganization( "MSDNPort", nOrgId, _
'   BIZTALK_TRANSPORT_TYPE_MSMQ, ".\private$\testqueue" )
' nDocId = BizTalkCreateDocument( "MSDNDocument", BizTalkGetWebDAVURL & _
'   "/docspecs/Microsoft/CommonPO.XML" )
'
' Call BizTalkCreateXLANGChannel( "MSDNXLANGChannel", nDocId, nDocId, "", nPortId )
'
Function BizTalkCreateXLANGChannel( _
    ByVal strChannelName, _
    ByVal nInputDocId, _
    ByVal nOutputDocId, _
    ByVal strMapReference, _
    ByVal nPortId )
    
    Dim nChannelId 

    SLUtilLogMessage 0, "BizTalkCreateXLANGChannel: " & _
        strChannelName & ", " & _
        CStr(nInputDocId) & ", " & _
        CStr(nOutputDocId) & ", " & _
        strMapReference & ", " & _
        CStr(nPortId)

    nChannelId = BizTalkHelperCreateChannel( strChannelName, _
        BIZTALK_OPENNESS_TYPE_EX_FROMWORKFLOW, _
        BizTalkGetOrganizationID("Home Organization"), _
        0, _
        nInputDocId, _
        nOutputDocId, _
        strMapReference, _
        nPortId )
    BizTalkCreateXLANGChannel = nChannelId
End Function


'******************************************************************************
' Function Name : BizTalkCreateOpenSourceChannel
' Input         : strChannelName    Name of the Channel
'                 nInputDocId       Input Document Definition Id
'                 nOutputDocId      Output Document Definition Id
'                 strMapReference   Referent to a transformation map in the
'                                   repository. Only needed if nInputDoc <>
'                                   nOutputDoc
'                 nPortId           Port Id

' Return value  : ChannelID
' Description   : Create an open source channel. No organization or application
'                 defined
' 
' TestCode      :
'
' Dim nOrgId
' Dim nPortId
' Dim nDocId
' nOrgId = BizTalkCreateOrganization( "MSDNHomeOrganization" )
' nPortId = BizTalkCreatePortToOrganization( "MSDNPort", nOrgId, _
'   BIZTALK_TRANSPORT_TYPE_MSMQ, ".\private$\testqueue" )
' nDocId = BizTalkCreateDocument( "MSDNDocument", BizTalkGetWebDAVURL & _
'   "/docspecs/Microsoft/CommonPO.XML" )
'
' Call BizTalkCreateOpenSourceChannel( "MSDNOpenSourceChannel", nDocId, nDocId, "", nPortId )
'
Function BizTalkCreateOpenSourceChannel( _
    ByVal strChannelName, _
    ByVal nInputDocId, _
    ByVal nOutputDocId, _
    ByVal strMapReference, _
    ByVal nPortId )
    
    Dim nChannelId 

    SLUtilLogMessage 0, "BizTalkCreateOpenSourceChannel: " & _
        strChannelName & ", " & _
        CStr(nInputDocId) & ", " & _
        CStr(nOutputDocId) & ", " & _
        strMapReference & ", " & _
        CStr(nPortId)

    nChannelId = BizTalkHelperCreateChannel( strChannelName, _
        BIZTALK_OPENNESS_TYPE_EX_SOURCE, _
        0, _
        0, _
        nInputDocId, _
        nOutputDocId, _
        strMapReference, _
        nPortId )
        
    BizTalkCreateOpenSourceChannel = nChannelId
End Function


'******************************************************************************
' Function Name : BizTalkCreateFromAppChannel
' Input         : strChannelName    Name of the Channel
'                 nInputDocId       Input Document Definition Id
'                 nOutputDocId      Output Document Definition Id
'                 strMapReference   Referent to a transformation map in the
'                                   repository. Only needed if nInputDoc <>
'                                   nOutputDoc
'                 nPortId           Port Id

' Return value  : ChannelID
' Description   : Create a channel that receive messages from an application.
'                 there is no need for an Organization Id as we'll assume
'                 Home Organization
' 
' TestCode      :
'
' Dim nOrgId
' Dim nAppId
' Dim nPortId
' Dim nDocId
' nOrgId = BizTalkCreateOrganization( "MSDNHomeOrganization" )
' nAppID = BizTalkCreateApplication( "MSDNApp" )
' nPortId = BizTalkCreatePortToOrganization( "MSDNPort", nOrgId, _
'   BIZTALK_TRANSPORT_TYPE_MSMQ, ".\private$\testqueue" )
' nDocId = BizTalkCreateDocument( "MSDNDocument", BizTalkGetWebDAVURL & _
'   "/docspecs/Microsoft/CommonPO.XML" )
'
' Call BizTalkCreateFromAppChannel( "MSDNFromAppChannel", nAppId, nDocId, nDocId, "", nPortId )
'
Function BizTalkCreateFromAppChannel( _
    ByVal strChannelName, _
    ByVal nAppId, _
    ByVal nInputDocId, _
    ByVal nOutputDocId, _
    ByVal strMapReference, _
    ByVal nPortId )
    
    Dim nChannelId 

    SLUtilLogMessage 0, "BizTalkCreateFromAppChannel: " & _
        strChannelName & ", " & _
        CStr(nAppId) & ", " & _
        CStr(nInputDocId) & ", " & _
        CStr(nOutputDocId) & ", " & _
        strMapReference & ", " & _
        CStr(nPortId)

    nChannelId = BizTalkHelperCreateChannel( strChannelName, _
        BIZTALK_OPENNESS_TYPE_EX_NOTOPEN, _
        BizTalkGetOrganizationID("Home Organization"), _
        nAppId, _
        nInputDocId, _
        nOutputDocId, _
        strMapReference, _
        nPortId )
        
    BizTalkCreateFromAppChannel = nChannelId
End Function


'******************************************************************************
' Function Name : BizTalkCreateFromOrgChannel
' Input         : strChannelName    Name of the Channel
'                 nInputDocId       Input Document Definition Id
'                 nOutputDocId      Output Document Definition Id
'                 strMapReference   Referent to a transformation map in the
'                                   repository. Only needed if nInputDoc <>
'                                   nOutputDoc
'                 nPortId           Port Id

' Return value  : ChannelID
' Description   : Create a channel that receive messages from an application.
'                 there is no need for an Organization Id as we'll assume
'                 Home Organization
' 
' TestCode      :
'
' Dim nOrgId
' Dim nPortId
' Dim nDocId
' nOrgId = BizTalkCreateOrganization( "MSDNHomeOrganization" )
' nPortId = BizTalkCreatePortToOrganization( "MSDNPort", nOrgId, _
'   BIZTALK_TRANSPORT_TYPE_MSMQ, ".\private$\testqueue" )
' nDocId = BizTalkCreateDocument( "MSDNDocument", BizTalkGetWebDAVURL & _
'   "/docspecs/Microsoft/CommonPO.XML" )
'
' Call BizTalkCreateFromOrgChannel( "MSDNFromOrgChannel", nOrgId, nDocId, nDocId, "", nPortId )
'
Function BizTalkCreateFromOrgChannel( _
    ByVal strChannelName, _
    ByVal nOrgId, _
    ByVal nInputDocId, _
    ByVal nOutputDocId, _
    ByVal strMapReference, _
    ByVal nPortId )
    
    Dim nChannelId 

    SLUtilLogMessage 0, "BizTalkCreateFromOrgChannel: " & _
        strChannelName & ", " & _
        CStr(nOrgId) & ", " & _
        CStr(nInputDocId) & ", " & _
        CStr(nOutputDocId) & ", " & _
        strMapReference & ", " & _
        CStr(nPortId)

    nChannelId = BizTalkHelperCreateChannel( strChannelName, _
        BIZTALK_OPENNESS_TYPE_EX_NOTOPEN, _
        nOrgId, _
        0, _
        nInputDocId, _
        nOutputDocId, _
        strMapReference, _
        nPortId )
        
    BizTalkCreateFromOrgChannel = nChannelId
End Function


'******************************************************************************
' Function Name : BizTalkWMIGetServerByName
' Input         : strServerName     Name of the Server
' Return value  : WMI Server Object
' Description   : Use WMI to find and return the BizTalk Server Object
' 
' TestCode      :
'
' Dim objServer
' Set objServer = BizTalkWMIGetServerByName( SLUtilGetComputerName )
' Wscript.Echo objServer.Name
' Set objServer = nothing
' 

Const BIZTALK_WMI_BIZTALK_NAMESPACE = "MicrosoftBiztalkServer"
Const BIZTALK_WMI_GROUP_NAMESPACE = "MicrosoftBizTalkServer_Group"
Const BIZTALK_WMI_MGMT_NAMESPACE = "MicrosoftBizTalkServer_MgmtDB"
Const BIZTALK_WMI_SERVER_NAMESPACE = "MicrosoftBizTalkServer_SERVER"
Const BIZTALK_WMI_RECVSVC_NAMESPACE = "MicrosoftBizTalkServer_ReceiveFunction"
Const BIZTALK_WMI_QUEUE_NAMESPACE = "MicrosoftBizTalkServer_Queue"
Const BIZTALK_WMI_WORKQ_NAMESPACE = "MicrosoftBizTalkServer_WorkQueue"
Const BIZTALK_WMI_SCHEDULEDQ_NAMESPACE = "MicrosoftBizTalkServer_ScheduledQueue"
Const BIZTALK_WMI_RETRYQ_NAMESPACE = "MicrosoftBizTalkServer_RetryQueue"
Const BIZTALK_WMI_SUSPENDEDQ_NAMESPACE = "MicrosoftBizTalkServer_SuspendedQueue"

Function BizTalkWMIGetServerByName( ByVal strServerName )
    Dim objLocator 
    Dim objBizTalkServer
    Set objLocator = CreateObject("WbemScripting.SWbemLocator")
    Set objBizTalkServer = _
        objLocator.ConnectServer(".", "root\" & BIZTALK_WMI_BIZTALK_NAMESPACE )

    Set BizTalkWMIGetServerByName = Nothing    
    Set BizTalkWMIGetServerByName = _
        objBizTalkServer.Get(BIZTALK_WMI_SERVER_NAMESPACE & ".NAME=""" & strServerName & """")
        
    Set objLocator = nothing
    Set objBizTalkServer = nothing
End Function

'******************************************************************************
' Function Name : BizTalkWMIGetGroupByName
' Input         : strGroupName     Name of the BizTalk Server Group
' Return value  : WMI Server Object
' Description   : Use WMI to find and return the BizTalk Server Group Object
' 
' TestCode      :
'
' Dim objGroup
' Set objGroup = BizTalkWMIGetGroupByName( BizTalkWMIGetGroupName( SLUtilGetComputerName ) )
' Wscript.Echo objGroup.Name
' Set objGroup = nothing
' 
Function BizTalkWMIGetGroupByName( ByVal strGroupName )
    Dim objLocator 
    Dim objBizTalkServer
    Set objLocator = CreateObject("WbemScripting.SWbemLocator")
    Set objBizTalkServer = _
        objLocator.ConnectServer(".", "root\" & BIZTALK_WMI_BIZTALK_NAMESPACE )

    Set BizTalkWMIGetGroupByName = Nothing
    Set BizTalkWMIGetGroupByName = _
        objBizTalkServer.Get(BIZTALK_WMI_GROUP_NAMESPACE & ".NAME=""" & strGroupName & """")
       
    Set objLocator = nothing
    Set objBizTalkServer = nothing
End Function

'******************************************************************************
' Function Name : BizTalkWMIGetGroupName
' Input         : strGroupName     Name of the BizTalk Server Group
' Return value  : WMI Server Object
' Description   : Use WMI to find and return the BizTalk Server Group Object
' 
' TestCode      :
'
' Dim objGroup
' Set objGroup = BizTalkWMIGetGroupByName( BizTalkWMIGetGroupName( SLUtilGetComputerName ) )
' Wscript.Echo objGroup.Name
' Set objGroup = nothing
' 
' Wscript.Echo BizTalkWMIGetGroupName( SLUtilGetComputerName )

Function BizTalkWMIGetGroupName( strServerName )
    Dim objServer
	Set objServer = BizTalkWMIGetServerByName( strServerName )
	BizTalkWMIGetGroupName = objServer.GroupName
	Set objServer = Nothing
End Function


'******************************************************************************
' Function Name : BizTalkWMICreateReceiveFunction
' Input         : strName                   Name of the receive function
'                 strGroupName              Name of the BizTalk Server Group
'                 strProcessingServer       Name of the Server
'                 strFilenameMask           If you're creating a file receive
'                                           function, this parameter sets the
'                                           mask that will be used to process
'                                           files
'                 nProtocolType             See constants BIZTALK_ADMIN_PROTOCOL
'                 strPollingLocation        Either a queue name or a file folder
'                 strDocumentName
'                 strSourceID
'                 strSourceQualifier
'                 strDestinationID
'                 strDestinationQualifier
'                 strChannelName            Name of the channel that will be
'                                           called to process documents received
'                                           by this receive function
'                 strEnvelopeName           Name of the envelope
'                 strUsername               If the queue or the folder requires
'                                           special access priviledges, you can
'                                           define the username and password that
'                                           will be used. Please be sure that
'                                           this user has "Logon as a batch job" 
'                                           grant.
'                 strPassword               Password 
'                 
' Return value  : none
' Description   : Use WMI to create a file or queue receive function in BizTalk Server
' Wbem Scripting Constants

Const wbemChangeFlagCreateOrUpdate = 0
Const wbemChangeFlagUpdateOnly = 1
Const wbemChangeFlagCreateOnly = 2
Const wbemChangeFlagUpdateCompatible = 0
Const wbemChangeFlagUpdateSafeMode = 32
Const wbemChangeFlagUpdateForceMode = 64

Const BIZTALK_ADMIN_PROTOCOL_TYPE_UNSPECIFIED = 0
Const BIZTALK_ADMIN_PROTOCOL_TYPE_FILE = 1
Const BIZTALK_ADMIN_PROTOCOL_TYPE_MSMQ = 2
' 
' TestCode      :
'
  
' Dim nOrgId
' Dim nPortId
' Dim nDocId
' nOrgId = BizTalkCreateOrganization( "MSDNHomeOrganization" )
' nPortId = BizTalkCreatePortToOrganization( "MSDNPort", nOrgId, _
'   BIZTALK_TRANSPORT_TYPE_MSMQ, ".\private$\testqueue" )
' nDocId = BizTalkCreateDocument( "MSDNDocument", BizTalkGetWebDAVURL & _
'   "/docspecs/Microsoft/CommonPO.XML" )
'
' Call BizTalkCreateFromOrgChannel( "MSDNFromOrgChannel", nOrgId, nDocId, nDocId, "", nPortId )
' Call BizTalkWMICreateReceiveFunction( _
'     "MSDNFileReceiveFunction", _	  
'     BizTalkWMIGetGroupName(SLUtilGetComputerName), _ 							
'     SLUtilGetComputerName, _							
'     "*.xml", _								
'     BIZTALK_ADMIN_PROTOCOL_TYPE_FILE, _				
'     "c:\temp", _
'     "", _										
'     "", _										
'     "", _ 									
'     "", _										
'     "", _										
'     "MSDNFromOrgChannel", _					
'     "", _
'     "", _                 
'     "")	               

Sub BizTalkWMICreateReceiveFunction( _
    ByVal strName, _
    ByVal strGroupName, _
    ByVal strProcessingServer, _
    ByVal strFilenameMask, _
    ByVal nProtocolType, _
    ByVal strPollingLocation, _
    ByVal strDocumentName, _
    ByVal strSourceID, _
    ByVal strSourceQualifier, _
    ByVal strDestinationID, _
    ByVal strDestinationQualifier, _
    ByVal strChannelName, _
    ByVal strEnvelopeName, _
    ByVal strUsername, _
    ByVal strPassword)

    Dim objBTSRecvSvc
    Dim objBTSRecvSvcInstance
    Dim objLocator 
    Dim objBizTalkServer


    SLUtilLogMessage 0, "BizTalkWMICreateReceiveFunction: " & _
        strName & ", " & _
        strGroupName & ", " & _
        strProcessingServer & ", " & _
        strFilenameMask & ", " & _       
        CStr(nProtocolType) & ", " & _
        strPollingLocation & ", " & _       
        strDocumentName


    Set objLocator = CreateObject("WbemScripting.SWbemLocator")
    Set objBizTalkServer = _
        objLocator.ConnectServer(".", "root\" & BIZTALK_WMI_BIZTALK_NAMESPACE )


    Set objBTSRecvSvc = objBizTalkServer.Get(BIZTALK_WMI_RECVSVC_NAMESPACE)
    Set objBTSRecvSvcInstance = objBTSRecvSvc.SpawnInstance_
 
    objBTSRecvSvcInstance.Name = strName
    objBTSRecvSvcInstance.GroupName = strGroupName
    objBTSRecvSvcInstance.FilenameMask = strFilenameMask
    objBTSRecvSvcInstance.ProcessingServer = strProcessingServer
    objBTSRecvSvcInstance.ProtocolType = nProtocolType
    objBTSRecvSvcInstance.PollingLocation = strPollingLocation
    objBTSRecvSvcInstance.OpennessFlag = BIZTALK_OPENNESS_TYPE_EX_NOTOPEN
    objBTSRecvSvcInstance.IsPassThrough = false
    If (strDocumentName <> "") Then  objBTSRecvSvcInstance.DocumentName = strDocumentName
    If (strSourceID <> "") Then  objBTSRecvSvcInstance.SourceID = strSourceID
    If (strSourceQualifier <> "") Then  objBTSRecvSvcInstance.SourceQualifier = strSourceQualifier
    If (strDestinationID <> "") Then  objBTSRecvSvcInstance.DestinationID = strDestinationID
    If (strDestinationQualifier <> "") Then  objBTSRecvSvcInstance.DestinationQualifier = strDestinationQualifier
    If (strChannelName <> "") Then  objBTSRecvSvcInstance.ChannelName = strChannelName
    If (strEnvelopeName <> "") Then  objBTSRecvSvcInstance.EnvelopeName = strEnvelopeName    
    objBTSRecvSvcInstance.Username = strUsername
    objBTSRecvSvcInstance.Password = strPassword
    objBTSRecvSvcInstance.Put_ (wbemChangeFlagCreateOnly)
    
    Set objBTSRecvSvcInstance = Nothing
    Set objBTSRecvSvc = Nothing
          
    Set objLocator = nothing
    Set objBizTalkServer = nothing
End Sub


'******************************************************************************
' Function Name : BizTalkWMIDeleteReceiveFunction
' Input         : strRecvSvcName     Name of the receive function to be deleted
' Return value  : none
' Description   : Use WMI to remove a receive function
' 
' TestCode      :
'
' Call BizTalkWMIDeleteReceiveFunction("MSDNFileReceiveFunction")
'

Sub BizTalkWMIDeleteReceiveFunction( ByVal strRecvSvcName )
    Dim objLocator 
    Dim objBizTalkServer


    SLUtilLogMessage 0, "BizTalkWMIDeleteReceiveFunction: " & _
        strRecvSvcName 

    Set objLocator = CreateObject("WbemScripting.SWbemLocator")
    Set objBizTalkServer = _
        objLocator.ConnectServer(".", "root\" & BIZTALK_WMI_BIZTALK_NAMESPACE )

    Call objBizTalkServer.Delete(BIZTALK_WMI_RECVSVC_NAMESPACE & ".NAME=""" & strRecvSvcName & """")
       
    Set objLocator = nothing
    Set objBizTalkServer = nothing
End Sub

'******************************************************************************
'******************************************************************************
' Add your code here...
on error resume next

IISDeleteVirtualDirectory "Lab3"
IISDeleteVirtualDirectory "Lab4"

IISDeleteVirtualDirectory "WebApplication1"
SLUtilShellExec "cmd /c rd C:\Inetpub\wwwroot\WebApplication1 /s/q"

IISDeleteVirtualDirectory "WebApplication2"
SLUtilShellExec "cmd /c rd C:\Inetpub\wwwroot\WebApplication2 /s/q"

IISDeleteVirtualDirectory "WebApplication3"
SLUtilShellExec "cmd /c rd C:\Inetpub\wwwroot\WebApplication3 /s/q"

IISDeleteVirtualDirectory "WebService1"
SLUtilShellExec "cmd /c rd C:\Inetpub\wwwroot\WebService1 /s/q"

IISDeleteVirtualDirectory "WebService2"
SLUtilShellExec "cmd /c rd C:\Inetpub\wwwroot\WebService2 /s/q"

IISDeleteVirtualDirectory "WebService3"
SLUtilShellExec "cmd /c rd C:\Inetpub\wwwroot\WebService3 /s/q"

IISDeleteVirtualDirectory "Inheritance"
SLUtilShellExec "cmd /c rd C:\Inetpub\wwwroot\Inheritance /s/q"

Dim fso 
Dim fldr
Set fso = CreateObject("scripting.filesystemobject")

Set fldr = fso.DeleteFolder ("C:\Documents and Settings\Administrator\Start Menu\Programs\Experience VS.NET Content")
Set fldr = fso.DeleteFolder ("C:\FieldContent\Experience VS.NET")

Set fldr = Nothing
Set fso = Nothing

'******************************************************************************
WScript.Echo "Reset Script is complete."
'******************************************************************************
