'---------------------------------------------------------------------------------------------------
' This function creates a web application on the specified web site
' and with the specified path
' Adapted by Alex Avrutin (alex@awsystems.spb.ru) 06/19/2002
' from original mkwebdir.vbs supplied with MS IIS
' Modifications:
' - Creates web apps instead of just virtual directories
' - Can create only one web app per a run
' - If virtual dir with the same name found, deletes it without asking
' - Added new required argument - --Path (-p)
'---------------------------------------------------------------------------------------------------


' Force explicit declaration of all variables.
Option Explicit



Dim oArgs, ArgNum

Dim ArgComputer, ArgWebSite,  ArgDirName, ArgDirPath

Set oArgs = WScript.Arguments
ArgComputer = "LocalHost"
ArgWebSite = "1"

ArgNum = 0
While ArgNum < oArgs.Count

	If (ArgNum + 1) >= oArgs.Count Then
		Call DisplayUsage
	End If	

	Select Case LCase(oArgs(ArgNum))
		Case "--computer","-c":
			ArgNum = ArgNum + 1
			ArgComputer = oArgs(ArgNum)
 		Case "--website","-w":
			ArgNum = ArgNum + 1
			ArgWebSite = oArgs(ArgNum)
		Case "--virtualdir","-v":
			ArgNum = ArgNum + 1
			ArgDirName = oArgs(ArgNum)
		Case "--path","-p":
			ArgNum = ArgNum + 1
			ArgDirPath =  oArgs(ArgNum)
		Case "--help","-?"
			Call DisplayUsage
	End Select

	ArgNum = ArgNum + 1

Wend

If ArgDirName = "" Or ArgDirPath="" Then
	WScript.Echo ""
	Trace "Please, specify both virtual directory name and its physical path at least."
	WScript.Echo ""
	Call DisplayUsage
End if

Call ASTCreateWebApp(ArgComputer,ArgWebSite,ArgDirName,ArgDirPath)


'---------------------------------------------------------------------------------
Sub Display(Msg)
	WScript.Echo Now & ". Error Code: " & Hex(Err) & " - " & Msg
End Sub

Sub Trace(Msg)
	WScript.Echo Now & " : " & Msg	
End Sub

Sub DisplayUsage()
	WScript.Echo "Usage: mkwebapp [--computer|-c COMPUTER]"
	WScript.Echo "                <--website|-w WEBSITE>"
	WScript.Echo "                <--virtualdir|-v NAME>"
	WScript.Echo "                <--path|-p PATH>"
	WScript.Echo "                [--help|-?]"	

	WScript.Echo ""
	WScript.Echo "Note, WEBSITE is the Web Site on which the directory will be created."
	WScript.Echo "The name can be specified as one of the following, in the priority specified:"
	WScript.Echo " Server Number (i.e. 1, 2, 10, etc.)"
	WScript.Echo " Server Description (i.e ""My Server"")"
	WScript.Echo " Server Host name (i.e. ""www.domain.com"")"
	WScript.Echo " IP Address (i.e., 127.0.0.1)"
	WScript.Echo ""
	WScript.Echo ""
	WScript.Echo "Example : mkwebapp -c MyComputer -w ""Default Web Site"""
	WScript.Echo "           -v ""dir"" -p ""c:\inetpub\wwwroot\dir"""

	WScript.Quit
End Sub
'---------------------------------------------------------------------------------


Sub ASTCreateWebApp(ComputerName,WebSiteName,DirName,DirPath)
	Dim Computer, webSite, WebSiteID, vRoot, vDir, DirNum, Test
	On Error Resume Next
	
	set webSite = findWeb(ComputerName, WebSiteName)
	if IsObject(webSite) then
		set vRoot = webSite.GetObject("IIsWebVirtualDir", "Root")
		Trace "Accessing root for " & webSite.ADsPath
		If (Err <> 0) Then
			Display "Unable to access root for " & webSite.ADsPath
		Else
			Err=0
			'If this directory exists, delete it
			Set test = vRoot.GetObject("IIsWebVirtualDir", DirName)
			If (Err = 0) Then
				'Directory exists
				Trace "Directory with such name exists. Delete it."
			    vRoot.Delete "IIsWebVirtualDir", DirName
			End If
			Err = 0

			'Create the new virtual directory
			Trace "Creating directory object..."
			Set vDir = vRoot.Create("IIsWebVirtualDir",DirName)
			If (Err <> 0) Then
				Display "Unable to create " & vRoot.ADsPath & "/" & DirName &"."
			Else
				'Set the new virtual directory path
				vDir.AccessRead = true
				vDir.AccessScript = true
				vDir.Path = DirPath
				If (Err <> 0) Then
					Display "Unable to bind path " & DirPath & " to " & vRootName & "/" & DirName & ". Path may be invalid."
					
				Else
					Err = 0
					'Save the changes
					vDir.SetInfo
					If (Err <> 0) Then
							'riase error and quit
							Display "Unable to save configuration for " & vRootName & "/" & DirName &"."
					Else
						Trace "Virtual directory created successfully."
						Err = 0
						Trace "Creating Web Application..."
						vDir.AppCreate2(2) 'Create pooled Web App 
						vDir.AppFriendlyName = "Web application"
						vDir.SetInfo

						If (Err <> 0) Then
							Display "Unable to create web application of virtual directory."
							vRoot.Delete "IIsWebVirtualDir",DirName
						Else
							Trace "New web aplication created successfully."
							Trace "Done."
						End If
					End If	
				End If
			End If
			Err = 0
		End If
	else
		Display "Unable to find "& WebSiteName &" on "& ComputerName
	End if

End Sub

function getBinding(bindstr)

	Dim one, two, ia, ip, hn
	
	one=Instr(bindstr,":")
	two=Instr((one+1),bindstr,":")
	
	ia=Mid(bindstr,1,(one-1))
	ip=Mid(bindstr,(one+1),((two-one)-1))
	hn=Mid(bindstr,(two+1))
	
	getBinding=Array(ia,ip,hn)
end function

Function findWeb(computer, webname)
	On Error Resume Next

	Dim websvc, site
	dim webinfo
	Dim aBinding, binding

	set websvc = GetObject("IIS://"&computer&"/W3svc")
	if (Err <> 0) then
		exit function
	end if
	' First try to open the webname.
	set site = websvc.GetObject("IIsWebServer", webname)
	if (Err = 0) and (not isNull(site)) then
		if (site.class = "IIsWebServer") then
			' Here we found a site that is a web server.
			set findWeb = site
			exit function
		end if
	end if
	err.clear
	for each site in websvc
		if site.class = "IIsWebServer" then
			'
			' First, check to see if the ServerComment
			' matches
			'
			If site.ServerComment = webname Then
				set findWeb = site
				exit function
			End If
			aBinding=site.ServerBindings
			if (IsArray(aBinding)) then
				if aBinding(0) = "" then
					binding = Null
				else
					binding = getBinding(aBinding(0))
				end if
			else 
				if aBinding = "" then
					binding = Null
				else
					binding = getBinding(aBinding)
				end if
			end if
			if IsArray(binding) then
				if (binding(2) = webname) or (binding(0) = webname) then
					set findWeb = site
					exit function
				End If
			end if 
		end if
	next
End Function