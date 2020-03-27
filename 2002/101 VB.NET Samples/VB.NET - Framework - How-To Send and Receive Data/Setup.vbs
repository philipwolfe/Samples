' Copyright (C) 2002 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
' EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
' MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

Option Explicit

Dim Source
Dim WebRoot
Dim ScriptName

On Error Resume Next
Source = GetPath()
' Change the following path statement if your
' IIS installation is not on your C: drive.
WebRoot = "c:\inetpub\wwwroot"
ScriptName = "Virtual Directory Builder"

Dim fso
Dim Site
Dim FolderName
InstallWebApplication("SendAndReceiveDataWebPages")

MsgBox "Installation Complete!", 64, ScriptName

   
Function GetPath()
	GetPath = Left(wscript.scriptfullname, InStrRev(wscript.scriptfullname, "\") - 1)
End Function

Sub CheckError()
	If Err.Number <> 0 Then
		MsgBox Err.Number & ":" & Err.Source & ":" & Err.Description, 16, ScriptName & " Error"
		wscript.quit
        End If
End Sub

Sub InstallWebApplication(AppName)
	Dim fso
	Set fso = CreateObject("Scripting.FileSystemObject")
	
	wscript.echo "Copying : " & Source & "\" & AppName & " to " & WebRoot & "\" & AppName
	fso.CopyFolder Source & "\" & AppName, WebRoot & "\" & AppName
	CheckError
	
	Dim DirObj
	Const POOLED = 2
	
	wscript.echo "Creating Web Application for IIS://LocalHost/W3SVC/1/ROOT/" & AppName
	
	Set DirObj = GetObject("IIS://LocalHost/W3SVC/1/ROOT")
	On Error Resume Next
		DirObj.Delete "IIsWebVirtualDir", AppName
	On Error GoTo 0
	
	Dim vDir
	Set vDir = DirObj.Create("IISWebVirtualDir", AppName)
	vDir.Path = WebRoot & "\" & AppName
	vDir.AccessScript = True
	vDir.AppFriendlyName = AppName
	vDir.AppCreate2 POOLED
	vDir.SetInfo
End Sub

    
    
    
