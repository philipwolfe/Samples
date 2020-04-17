'=====================================================================
'  File:      TaskPaneMain.vb
'
'  Summary:   Contains global methods and things to help us manage all
'             the controls at runtime, most notably localisation of
'             resources, etc...
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
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

Imports System.Resources



'=--------------------------------------------------------------------------=
' TaskPaneMain
'=--------------------------------------------------------------------------=
''' <summary>
'''   A Module with methods and the like which we will use to
'''   manage globalisation and other aspects of using the controls at runtime. 
''' </summary>
''' 
Friend Module TaskPaneMain

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Private data/types/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    ''' 
    ''' <summary>
    '''   I'm assuming that all variables in a Module are "Shared".
    ''' </summary>
    ''' 
    Private s_resourceManager As ResourceManager

    ''' 
    ''' <summary>
    '''   This is the resource manager for strictly design time descriptions
    ''' </summary>
    ''' 
    Private s_designResources As ResourceManager







    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                            Public Methods
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' GetResourceManager
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''  Returns our resource manager, loading it the first 
    '''  time it is required.
    ''' </summary>
    ''' 
    Public Function GetResourceManager() As ResourceManager

        '
        ' Load in the manager if necessary.
        '
        If s_resourceManager Is Nothing Then

            s_resourceManager = New System.Resources.ResourceManager("Microsoft.Samples.Windows.Forms.TaskPane.TaskPaneResources", _
                                                    GetType(Microsoft.Samples.Windows.Forms.TaskPane.TaskPane).Assembly)

        End If

        Return s_resourceManager

    End Function ' GetResourceManager


End Module ' TaskPaneMain

