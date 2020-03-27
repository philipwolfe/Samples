    On error resume next
    '
    ' Running as a VBS
    '
    Script = True
    Source = GetPath
	WebRoot = "c:\inetpub\wwwroot"
    
    set fso = CreateObject("Scripting.FileSystemObject")
	for each site in fso.GetFolder(Source).SubFolders
		FolderName = fso.GetFileName(Site.Path)
		if lcase(FolderName) <> "solution" then
			ReinstallWebApplication FolderName
			CheckError
		end if
	next

	CheckError
	

Function Share(Path, Name)
    Output "Sharing " & Path
    
    'dim objServices As SWbemServices
    
    Set objServices = GetObject _
              ("WinMgmts:{impersonationLevel=impersonate}!/root/cimv2")
    
    '************************ Create the new share *********************
        
    Set objShare = objServices.Get("Win32_Share")
    Set objInParam = objShare.Methods_("Create").InParameters.SpawnInstance_()
    objInParam.Properties_.Item("Description") = ""
    objInParam.Properties_.Item("Name") = Name
    objInParam.Properties_.Item("Path") = Path
    objInParam.Properties_.Item("Type") = 0
    
    
    '************************ Execute the method **********************
    Set ObjOutParams = objShare.ExecMethod_("Create", objInParam)
    If ObjOutParams.ReturnValue <> 0 And ObjOutParams.ReturnValue <> 22 Then
        Beep
        Output "***Unable to create share, return value was : " _
           & "objOutParams.ReturnValue"
    End If

End Function

'
' The following compatability functions allow this script to function in VB
' or as a VBS file.
'

Sub Output(s)
    If Script Then
        WScript.echo s
    Else
        Debug.Print s
    End If
End Sub

Function GetPath()
    If Script Then
        GetPath = Left(WScript.scriptfullname, InStrRev(WScript.scriptfullname, "\") - 1)
    Else
        GetPath = App.Path
    End If
End Function

Function Run(s)
    If Script Then
        Set WshShell = WScript.CreateObject("WScript.Shell")
        WshShell.Run s, ,true
    Else
        Shell s, vbNormalFocus
    End If
End Function


Sub CheckError()
    if Err.Number then
        msgbox err.number & ":" & err.source & ":" & err.description
	if script then
            wscript.quit
        else
            stop
        end if
    end if
end sub

Sub StopService(ServiceName)
    Set objServices = GetObject _
              ("WinMgmts:{impersonationLevel=impersonate}")
              
    Set services = objServices.InstancesOf("Win32_Service")
    
    For Each s In services
        If s.DisplayName = ServiceName Then
            s.ChangeStartMode ("Manual")
            s.StopService
        End If
    Next
end sub

Sub DeleteGPO(nc, DisplayName)
    'Dim Policies As IADsContainer
    Set Policies = GetObject("LDAP://CN=Policies,CN=System," & nc)
    
    'Dim Policy
    For Each Policy In Policies
        If Policy.DisplayName = DisplayName Then
            'Dim c As IADsContainer
            Set c = Policy
            RecursiveDelete c
            Policies.Delete Policy.Class, Policy.Name
            Exit For
        End If
    Next
End Sub

Sub RecursiveDelete(c)
    'Dim subc As IADsContainer
    
    For Each subc In c
        RecursiveDelete subc
    Next
    
    For Each subc In c
        c.Delete subc.Class, "CN=" & subc.cn
    Next
End Sub

Sub Uninstall(PartialName)
    Set objServices = GetObject _
              ("WinMgmts:{impersonationLevel=impersonate}!/root/cimv2")


    Set Products = objServices.InstancesOf("Win32_Product")

    For Each product In Products
        If instr(product.Name,PartialName) > 0 Then
			output "Uninstalling " & product.name
			product.uninstall
        End If
    Next
end sub



Sub ReinstallWebApplication(AppName)
	UninstallWebApplication AppName
	InstallWebApplication(AppName)
end Sub

sub UninstallWebApplication(AppName)
	set fso = createobject("scripting.filesystemobject")

	on error resume next
	Set DirObj = GetObject("IIS://LocalHost/W3SVC/1/ROOT/" & AppName) 
	DirObj.AppDelete
	on error goto 0

	DeleteFolder WebRoot & "\" & AppName
end sub

sub InstallWebApplication (AppName)
	set fso = createobject("scripting.filesystemobject")

	output "Copying : " & Source & "\" & AppName & " to " & WebRoot & "\" & AppName
	fso.CopyFolder Source & "\" & AppName, WebRoot & "\" & AppName
	checkerror

	Dim DirObj 
	Const INPROC = True 
	Const OUTPROC = False 
	
	output "Creating Web Application for IIS://LocalHost/W3SVC/1/ROOT/" & AppName
	
	Set DirObj = GetObject("IIS://LocalHost/W3SVC/1/ROOT") 
	on error resume next
	DirObj.delete "IIsWebVirtualDir", AppName
	on error goto 0
	set mywd = DirObj.Create ("IIsWebVirtualDir", AppName)
	mywd.setinfo
	mywd.AppCreate true
	mywd.setinfo

	run """c:\program files\common files\microsoft shared\web server extensions\40\bin\fpsrvadm.exe"" -o install -p 80 -w /" & AppName
	run """c:\program files\common files\microsoft shared\web server extensions\40\bin\fpsrvadm.exe"" -o check -p 80 -w /" & AppName
end sub

function MyDocuments()
	set shell = createobject("WScript.Shell")
	MyDocuments = shell.SpecialFolders("MyDocuments")
end function

sub DeleteFile(FileName)
	set fso = createobject("scripting.filesystemobject")
	if fso.fileexists(filename) then
		output "Deleting : " & filename
		fso.deletefile filename, true
	end if
end sub

sub DeleteFolder(FolderName)
	set fso = createobject("scripting.filesystemobject")
	if fso.FolderExists(Foldername) then
		output "Deleting : " & Foldername
		fso.deleteFolder Foldername, true
	end if
end sub