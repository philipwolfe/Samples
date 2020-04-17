'---------------------------------------------------------------------
'  This file is part of the  BPEL for Windows Workflow Foundation Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Imports System
Imports System.Web.Services
Imports System.IO

Public Class FileService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Sub writeLine(ByVal message As String)
        Using writer As StreamWriter = File.AppendText("Output.txt")
            writer.WriteLine(String.Format("{0} : {1}", DateTime.Now, message))
        End Using
    End Sub

End Class
