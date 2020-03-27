'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics


Public Class AssemblyTreeView : Inherits TreeView
    ' A tree view control with drag and drop ability.  This control is used to
    ' display the Assembly tree.

    'Signals that a node has been copied to another node.  The main window uses this event to update the MDI forms.
    Public Event NodeCopied(ByVal destinationNode As MemberNode)


    Public Sub New()
        MyBase.New()
        'Turn on drag and drop.
        Me.AllowDrop = True
    End Sub

    Protected Overrides Sub OnDragDrop(ByVal drgevent As DragEventArgs)
        ' Perform the actual Drag and Drop operation.  The copy target will
        ' have been selected by the OnDragOver method.  The node kinds are
        ' compared and the user is notified if the node shapes prohibit a
        ' copy.  If the copy occurs, an OnNodeCopied event is raised so the
        ' main window can update the MDI forms.
        '
        ' Tip:
        '     It will be difficult to determine the type of data in the drag
        '     event object.  Try the code below first to figure out the
        '     correct string parameter for DragEventArgs.Data.GetData:
        '
        '         Dim x As String
        '         For Each x In drgevent.Data.GetFormats(True)
        '            Dim obj As Object = _
        '                   drgevent.Data.GetData(x, False)
        '            If Not obj Is Nothing Then
        '               Debug.WriteLine(x)
        '            End If
        '         Next

        MyBase.OnDragDrop(drgevent)

        'Get the object being dragged.
        Dim source As MemberNode = CType(drgevent.Data.GetData("XMLDocumentationTool.MemberNode", False), MemberNode)

        'There is no target, so do nothing.
        If Me.SelectedNode Is Nothing Then
            Return
        End If

        Dim target As MemberNode = CType(Me.SelectedNode, MemberNode)

        'Copying a node onto itself does nothing.
        If target Is source Then
            Return
        End If

        'Copy
        CopyNode(source, target)

    End Sub

    Protected Overrides Sub OnDragEnter(ByVal drgevent As DragEventArgs)
        ' The user is allowed to drag and drop member nodes only.  If the user
        ' attempts to drag something else, display a Not-Allowed mouse cursor.

        Dim obj As Object = drgevent.Data.GetData("XMLDocumentationTool.MemberNode", False)
        If obj Is Nothing Then
            drgevent.Effect = DragDropEffects.None
        Else
            drgevent.Effect = DragDropEffects.Copy
        End If
        MyBase.OnDragEnter(drgevent)
    End Sub

    Protected Overrides Sub OnDragOver(ByVal drgevent As DragEventArgs)
        'Select the target nodes as something is dragged over them.

        MyBase.OnDragOver(drgevent)
        'The PointToClient function is necessary to orient the Point coordinates correctly.
        Me.SelectedNode = Me.GetNodeAt(PointToClient(New Point(drgevent.X, drgevent.Y)))
    End Sub

    Protected Overrides Sub OnItemDrag(ByVal e As ItemDragEventArgs)
        MyBase.OnItemDrag(e)
        'Begin the drag-drop operation.
        DoDragDrop(e.Item, DragDropEffects.Copy)
    End Sub

    Public Sub CopyNode(ByVal source As MemberNode, ByVal target As MemberNode)
        'Copy one node to another, either by copy/paste or drag/drop.

        If Not source.HasContent() Then
            MsgBox("Source has no content. Nothing to copy.")
            Return
        End If

        'Determine the differences between the source and target.  If the differences are too great,
        'a copy cannot be performed.
        Select Case MemberNode.ClassifyDifference(source, target)
            Case Difference.None
                'There are no differences between the source and target which prohibit a copy.
                'Ask the user to verify the copy operation.
                Dim message As String = "Copy:" & vbCrLf & "    " & source.FriendlySignatureWithPath & vbCrLf & _
                                        "To:" & vbCrLf & "    " & target.FriendlySignatureWithPath & vbCrLf & vbCrLf & _
                                        "Destination content will be overwritten. Continue with copy?"
                If MsgBoxResult.Yes = MsgBox(message, MsgBoxStyle.YesNo) Then
                    'Copy the content.
                    target.Copy(source)
                    'Signal that a copy has occurred.
                    RaiseEvent NodeCopied(target)
                End If

            Case Difference.ParamNum
                MsgBox(GetErrorMessage(ErrorID.FieldCountNotMatch1, "parameter"))

            Case Difference.RemarksNum
                MsgBox(GetErrorMessage(ErrorID.FieldCountNotMatch1, "remarks"))

            Case Difference.ReturnNum
                MsgBox(GetErrorMessage(ErrorID.FieldCountNotMatch1, "returns"))

            Case Difference.SummaryNum
                MsgBox(GetErrorMessage(ErrorID.FieldCountNotMatch1, "summary"))

            Case Difference.PropertyValueNum
                MsgBox(GetErrorMessage(ErrorID.FieldCountNotMatch1, "value"))

            Case Else
                Debug.Fail("unexpected difference value")

        End Select

    End Sub
End Class
