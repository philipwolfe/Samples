'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class UI
    ' This function inserts an option into the top row of a DataTable. If you want 
    ' the additional option to appear at the top of the list as well as the data to
    ' appear in alphabetical order it must be pre-sorted. Creating and sorting a 
    ' DataView after the option is added may cause the additional option to not 
    ' appear at the top. Thus, the data should be sorted at the SQL Server tier.
    Shared Function AddOption(ByVal ds As DataSet, ByVal strDisplayField As String, ByVal strValueField As String, ByRef strNewOptionText As String, ByVal strNewOptionValue As String) As DataSet
        Dim dt As DataTable
        Dim drNew As DataRow
        dt = ds.Tables(0)

        drNew = dt.NewRow()
        drNew(strDisplayField) = strNewOptionText
        drNew(strValueField) = strNewOptionValue
        dt.Rows.InsertAt(drNew, 0)
        dt.AcceptChanges()

        Return ds
    End Function

    ' This function inserts an option into the top position of an ArrayList. See further 
    ' comments, above.
    Shared Function AddOption(ByVal arl As ArrayList, ByVal objNewOption As Object) As ArrayList
        arl.Insert(0, objNewOption)
        Return arl
    End Function
End Class
