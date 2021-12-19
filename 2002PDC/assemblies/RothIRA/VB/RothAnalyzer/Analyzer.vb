'*+==========================================================================
'  File:      analyzer.vb
'
'  Summary:   Contains a class used to hold the temporary data needed for the Roth calc
' 
'  Classes:   CRothAnalyzer
'
'  Functions: None
'             
'----------------------------------------------------------------------------
'  This file is part of the Microsoft NGWS Samples.
'
'  Copyright (C) 1998-1999 Microsoft Corporation.  All rights reserved.
'==========================================================================+*/

Imports System
Imports Samples.Assemblies.Download.Calcr
Imports Samples.Assemblies.Download.Statics

Namespace Samples.Assemblies.Download.Analyzer
    Public Class CRothAnalyzer
        Public Property Name() As String
            Get
                Name = CRothStatics.ParticipantName
            End Get
            Set
                CRothStatics.ParticipantName = value
            End Set
        End Property

        Public Property AGI() As Integer
            Get
                AGI = CRothStatics.ParticipantAGI
            End Get
            Set
                CRothStatics.ParticipantAGI = value
            End Set
        End Property

        Public Function GetAmount() 'As Integer
            Dim calc As CRothCalculator = New CRothCalculator
            GetAmount = calc.GetAmount(CRothStatics.ParticipantAGI, CRothStatics.ParticipantFilingStatus)
        End Function

        Public Function GetCanConvert() As Boolean
            Dim calc As CRothCalculator = New CRothCalculator
            GetCanConvert = calc.GetCanConvert(CRothStatics.ParticipantAGI, CRothStatics.ParticipantFilingStatus)
        End Function

    End Class
End Namespace
