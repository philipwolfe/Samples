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

Imports System
Imports System.Text
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design

Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules

Public Class SendMailDesigner
    Inherits ActivityDesigner

    Dim parentActivity As SendMailActivity

    Protected Overrides Sub Initialize(ByVal activity As Activity)
        MyBase.Initialize(activity)
        parentActivity = CType(activity, SendMailActivity)
    End Sub

    Protected Overrides Function OnLayoutSize(ByVal e As ActivityDesignerLayoutEventArgs) As Size
        Return New Size(230, 100)
    End Function

    Protected Overrides Sub OnPaint(ByVal e As ActivityDesignerPaintEventArgs)
        Dim frameRect As Rectangle = New Rectangle(Me.Location.X, Me.Location.Y, _
                                            (Me.Size.Width - 5), (Me.Size.Height - 5))
        Dim shadowRect As Rectangle = New Rectangle((frameRect.X + 5), (frameRect.Y + 5), _
                                            frameRect.Width, frameRect.Height)
        Dim pageRect As Rectangle = New Rectangle((frameRect.X + 4), (frameRect.Y + 24), _
                                            (frameRect.Width - 8), (frameRect.Height - 28))
        Dim titleRect As Rectangle = New Rectangle((frameRect.X + 15), (frameRect.Y + 4), _
                                            (frameRect.Width / 2), 20)

        Dim frameBrush As Brush = New LinearGradientBrush(frameRect, Color.DarkBlue, Color.LightBlue, 45)
        e.Graphics.FillPath(Brushes.LightGray, RoundedRect(shadowRect))
        e.Graphics.FillPath(frameBrush, RoundedRect(frameRect))
        e.Graphics.FillPath(New LinearGradientBrush(pageRect, Color.White, Color.WhiteSmoke, 45), RoundedRect(pageRect))
        e.Graphics.DrawString(Activity.QualifiedName, New Font("Segoe UI", 9), Brushes.White, titleRect)
        frameRect.Inflate(20, 20)
        Dim textToDisplay As String = String.Format("To : '{0}'" & vbCrLf & "From : '{1}'" & vbCrLf _
                                        & "Subject : '{2}'" & vbCrLf, parentActivity.MailTo, _
                                        parentActivity.MailFrom, parentActivity.Subject)
        e.Graphics.DrawString(String.Format(textToDisplay, parentActivity.Subject), _
            New Font("Segoe UI", 8), Brushes.Black, pageRect.X, (pageRect.Y + 15))
    End Sub

    Private Function RoundedRect(ByVal frame As Rectangle) As GraphicsPath
        Dim path As GraphicsPath = New GraphicsPath
        Dim radius As Integer = 7
        Dim diameter As Integer = (radius * 2)

        Dim arc As Rectangle = New Rectangle(frame.Left, frame.Top, diameter, diameter)

        path.AddArc(arc, 180, 90)

        arc.X = (frame.Right - diameter)
        path.AddArc(arc, 270, 90)

        arc.Y = (frame.Bottom - diameter)
        path.AddArc(arc, 0, 90)

        arc.X = frame.Left
        path.AddArc(arc, 90, 90)

        path.CloseFigure()

        Return path
    End Function

End Class