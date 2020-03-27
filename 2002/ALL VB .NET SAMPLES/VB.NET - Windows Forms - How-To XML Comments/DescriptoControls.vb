'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics
Imports System.Reflection.Assembly


Public Class DescriptoBox : Inherits RichTextBox
    ' A textbox control specifically tailored for the XML Documentation Tool.
    ' There is a one-to-one mapping between a member node's content
    ' descriptors and DescriptoBoxes.  It is a DescriptoBox which offers the
    ' interface through which a content descriptor is edited.

    Private Const BOX_HEIGHT As Integer = 64    'Height of a DescriptoBox.

    Private m_Descriptor As ContentDescriptor   'The descriptor which this textbox edits.


    Sub New(ByVal descriptor As ContentDescriptor, ByVal ContextMenu As ContextMenu, ByVal TextChangedHandler As EventHandler)
        ' Builds a DescriptoBox with a specific visual style.  It also hooks-
        ' up a TextChanged event handler so the member node and content
        ' descriptor's states can be updated.

        MyBase.New()

        m_Descriptor = descriptor

        Me.Multiline = True
        Me.ContextMenu = ContextMenu
        Me.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top

        'Width will be adjusted automatically, but the height will remain static.
        Me.Height = BOX_HEIGHT

        'The inital contents of the DescriptoBox is the content of its corresponding content descriptor.
        Me.Text = descriptor.Content

        'A descriptor with errors cannot be edited, so make the DescriptoBox readonly, otherwise
        'hook-up the textchanged event handler.
        If descriptor.HasErrors Then
            Me.ReadOnly = True
            Me.ForeColor = Color.Red
        Else
            AddHandler Me.TextChanged, TextChangedHandler
        End If
    End Sub

    Public ReadOnly Property Descriptor() As ContentDescriptor
        Get
            Return m_Descriptor
        End Get
    End Property

End Class

Public Class DescriptoLabel : Inherits Label
    ' A label control specifically tailored for the XML Documentation Tool.
    ' For simplicity, every DescriptoLabel references the content descriptor
    ' for which it was built.  This facilitates deleting the content
    ' descriptor when the user selects "Delete" from the DescriptoLabel's
    ' context menu.  A label need not represent a content descriptor, however
    ' the context menu and delete ability goes away.

    Private m_Descriptor As ContentDescriptor                   'The descriptor which this label represents.

    Private WithEvents m_LabelContextMenu As ContextMenu        'The context menu for the DescriptoLabel (used for sinking events).
    Private WithEvents m_MenuDelete As MenuItem                 'Delete item on the context menu (used for sinking events).

    'Signals the user has chosen to delete the content descriptor.
    Public Event DeleteDescriptor(ByVal descriptor As ContentDescriptor)

    Public Sub New(ByVal text As String, ByVal descriptor As ContentDescriptor, ByVal DeleteHandler As DeleteDescriptorEventHandler)
        ' Builds a DescriptoLabel using the text for the label and the
        ' descriptor for which this label represents.  The visual style is
        ' also built, which includes a context menu and text alignment.

        MyBase.New()

        m_Descriptor = descriptor
        Me.Text = text

        Me.TextAlign = ContentAlignment.MiddleLeft
        Me.Size = New Size(Me.PreferredWidth, Me.PreferredHeight)

        If Not m_Descriptor Is Nothing Then
            If m_Descriptor.HasErrors Then
                Me.ForeColor = Color.Red
                AddHandler DeleteDescriptor, DeleteHandler
            End If

            'Construct the context menu and menu items.
            m_MenuDelete = New MenuItem("Delete")

            m_LabelContextMenu = New ContextMenu()
            m_LabelContextMenu.MenuItems.Add(m_MenuDelete)

            Me.ContextMenu = m_LabelContextMenu
        End If
    End Sub

    Private Sub ContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_LabelContextMenu.Popup
        'The Delete command on the context menu is enabled only if this label's descriptor has errors.
        m_MenuDelete.Enabled = Not m_Descriptor Is Nothing AndAlso m_Descriptor.HasErrors
    End Sub

    Private Sub MenuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_MenuDelete.Click
        'Signal that the user wants to delete this label.
        RaiseEvent DeleteDescriptor(m_Descriptor)
    End Sub

End Class
