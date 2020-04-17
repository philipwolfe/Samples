'This script adds the necessary Windows Presentation Foundation MIME types to an IIS Server.
'To use this script, just double-click or execute it from a command line.
'Running this script multiple times results in multiple entries in the IIS MimeMap.

Dim MimeMapObj, MimeMapArray, MimeTypesToAddArray, WshShell, oExec
Const ADS_PROPERTY_UPDATE = 2 

'Set the MIME types to be added
MimeTypesToAddArray = Array(".manifest", "application/manifest", ".xaml", "application/xaml+xml", ".application", "application/x-ms-application", ".deploy", "application/octet-stream", ".xbap", "application/x-ms-xbap", ".xps", "application/vnd.ms-xpsdocument") 

'Get the mimemap object 
Set MimeMapObj = GetObject("IIS://LocalHost/MimeMap")

'Call AddMimeType for every pair of extension/MIME type
For counter = 0 to UBound(MimeTypesToAddArray) Step 2
 AddMimeType MimeTypesToAddArray(counter), MimeTypesToAddArray(counter+1)
Next

'Create a Shell object
Set WshShell = CreateObject("WScript.Shell")

'Stop and Start the IIS Service
Set oExec = WshShell.Exec("net stop w3svc")
Do While oExec.Status = 0
  WScript.Sleep 100
Loop

Set oExec = WshShell.Exec("net start w3svc")
Do While oExec.Status = 0
  WScript.Sleep 100
Loop

Set oExec = Nothing

'Report status to user
WScript.Echo "Windows Presentation Foundation MIME types have been registered."

'AddMimeType Sub
Sub AddMimeType (Ext, MType)

    'Get the mappings from the MimeMap property. 
    MimeMapArray = MimeMapObj.GetEx("MimeMap") 

    ' Add a new mapping. 
    i = UBound(MimeMapArray) + 1 
    Redim Preserve MimeMapArray(i) 
    Set MimeMapArray(i) = CreateObject("MimeMap") 
    MimeMapArray(i).Extension = Ext 
    MimeMapArray(i).MimeType = MType 
    MimeMapObj.PutEx ADS_PROPERTY_UPDATE, "MimeMap", MimeMapArray
    MimeMapObj.SetInfo
    
End Sub