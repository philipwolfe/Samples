' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace Microsoft.ServiceModel.Samples

    Public Class client

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()> _
        Public Shared Sub Main()

            Application.EnableVisualStyles()
            Application.Run(New Form1())

        End Sub

    End Class

End Namespace
