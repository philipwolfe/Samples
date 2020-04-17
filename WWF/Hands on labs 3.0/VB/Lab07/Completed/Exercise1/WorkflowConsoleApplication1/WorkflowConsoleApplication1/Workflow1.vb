'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

Public class Workflow1
    Inherits SequentialWorkflowActivity

    Public Enum NumberIs
        Odd = 0
        Even = 1
    End Enum
    Private currentNumber As NumberIs = NumberIs.Odd
    Private userRequestsExit As Boolean

    'number entered is odd
    Public Sub codeActivity1_ExecuteCode(ByVal sender As Object, ByVal e As EventArgs)

        Console.WriteLine("the number is odd")
        GetNextNumber()

    End Sub

    'number entered is even
    Public Sub codeActivity2_ExecuteCode(ByVal sender As Object, ByVal e As EventArgs)

        Console.WriteLine("the number is even")
        GetNextNumber()
    End Sub


    'evaluate number entered by user and set currentNumber variable
    Private Sub GetNextNumber()

        Dim numIn As Integer

        Console.WriteLine("enter a number.")
        Dim charIn As String = Console.ReadLine()

        If Int32.TryParse(charIn, numIn) Then

            If ((numIn Mod 2) = 0) Then

                currentNumber = NumberIs.Even

            Else

                currentNumber = NumberIs.Odd
            End If

        ElseIf (charIn.Contains("x")) Then

            userRequestsExit = True

        Else

            GetNextNumber()
        End If
    End Sub


    'used to control execution of codeActivity1_ExecuteCode1
    Public Sub oddCondition(ByVal sender As Object, ByVal args As ConditionalEventArgs)

        args.Result = ((currentNumber = NumberIs.Odd))

    End Sub

    'used to control execution of codeActivity2_ExecuteCode1
    Public Sub evenCondition(ByVal sender As Object, ByVal args As ConditionalEventArgs)

        args.Result = ((currentNumber = NumberIs.Even))

    End Sub

    'used to control execution of the ConditionedActivityGroup
    Public Sub timeToExit(ByVal sender As Object, ByVal args As ConditionalEventArgs)

        args.Result = userRequestsExit

    End Sub



End Class
