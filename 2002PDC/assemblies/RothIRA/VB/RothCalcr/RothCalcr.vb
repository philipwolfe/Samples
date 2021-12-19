'*+==========================================================================
'  File:      rothcalcr.vb
'
'  Summary:   Contains a class used to compute Roth IRA eligibility
' 
'  Classes:   CRothCalculator
'
'  Functions: None
'             
'----------------------------------------------------------------------------
'  This file is part of the Microsoft NGWS Samples.
'
'  Copyright (C) 1998-1999 Microsoft Corporation.  All rights reserved.
'==========================================================================+*/
Imports System

Namespace Samples.Assemblies.Download.Calcr

    Public Class CRothCalculator

        Private Const StatusMarriedJoint = 0
        Private Const StatusMarriedSeparate = 1
        Private Const StatusSingle = 2

        Public Function GetAmount(ByVal agi As Integer, ByVal status As Integer) As Integer
        
            ' The roth calculation is actually more complicated than this -- it phases out at various income levels
            Select Case (status)
			
                Case StatusMarriedJoint
                    If (agi > 160000) Then
                        GetAmount = 0
                    Else
                        GetAmount = 2000
                    End If

                Case StatusMarriedSeparate
                    If (agi > 110000) Then
                        GetAmount = 0
                    Else
                        GetAmount = 2000
                    End If

                Case StatusSingle
                    If (agi > 10000) Then
                        GetAmount = 0
                    Else
                        GetAmount = 2000
                    End If

			    Case Else:
                    GetAmount = 0
            End Select

        End Function

        Public Function GetCanConvert(ByVal agi As Integer, ByVal status As Integer) As Boolean
		
            Select Case (status)
			
                Case StatusMarriedJoint
                Case StatusSingle

                    If (agi > 100000) Then
                        GetCanConvert = False
                    Else
                        GetCanConvert = True
                    End If

                Case StatusMarriedSeparate
                    GetCanConvert = False
			    Case Else
                    GetCanConvert = False
            End Select

        End Function
    End Class

End Namespace
