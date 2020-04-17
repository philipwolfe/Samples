'=====================================================================
'  File:      BlendFillEditorUI.vb
'
'  Summary:   This is the design type UITypeEditor for the BlendFill
'             class.  Very cool.
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

Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.Design
Imports System.Security.Permissions

'=--------------------------------------------------------------------------=
' BlendFillEditorUI
'=--------------------------------------------------------------------------=
''' <summary>
'''   This is the design time UITypeEditor for the BlendFill class.
''' </summary>
''' 
<ToolboxItem(False)> _
<System.Security.Permissions.PermissionSet(SecurityAction.InheritanceDemand, Name:="FullTrust")> _
<System.Security.Permissions.PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust")> _
Public Class BlendFillEditorUI
    Inherits System.Windows.Forms.UserControl

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                      Private types/data/goo/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '
    ' current blend direction.
    '
    Private m_direction As BlendStyle

    '
    ' Start Color
    '
    Private m_startColor As Color

    '
    ' Finish Color
    '
    Private m_finishColor As Color

    '
    ' Are we reversed for RTL?
    '
    Private m_reverse As Boolean


    Private m_svc As IWindowsFormsEditorService


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal in_svc As IWindowsFormsEditorService, _
                   ByVal in_blendFill As BlendFill, _
                   ByVal in_reverse As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.m_svc = in_svc

        '
        ' Save out the values we were given.
        '
        Me.m_direction = in_blendFill.Style
        Me.m_startColor = in_blendFill.StartColor
        Me.m_finishColor = in_blendFill.FinishColor
        Me.m_reverse = in_reverse

        '
        ' Populate and select values in the appropriate list boxes.
        '
        Dim rm As System.Resources.ResourceManager
        rm = New System.Resources.ResourceManager(GetType(BlendFillEditorUI))
        populateDirectionListBox(rm)
        populateAndSelectColorList(Me.startColorList, Me.m_startColor, rm)
        populateAndSelectColorList(Me.finishColorList, Me.m_finishColor, rm)

    End Sub ' New


    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents mainTab As System.Windows.Forms.TabControl
    Friend WithEvents directionPage As System.Windows.Forms.TabPage
    Friend WithEvents startColorPage As System.Windows.Forms.TabPage
    Friend WithEvents finishColorPage As System.Windows.Forms.TabPage
    Friend WithEvents directionComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents startColorList As System.Windows.Forms.ListBox
    Friend WithEvents finishColorList As System.Windows.Forms.ListBox
    Friend WithEvents blendSamplePanel As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BlendFillEditorUI))
        Me.mainTab = New System.Windows.Forms.TabControl
        Me.directionPage = New System.Windows.Forms.TabPage
        Me.blendSamplePanel = New System.Windows.Forms.Panel
        Me.directionComboBox = New System.Windows.Forms.ComboBox
        Me.startColorPage = New System.Windows.Forms.TabPage
        Me.startColorList = New System.Windows.Forms.ListBox
        Me.finishColorPage = New System.Windows.Forms.TabPage
        Me.finishColorList = New System.Windows.Forms.ListBox
        Me.mainTab.SuspendLayout()
        Me.directionPage.SuspendLayout()
        Me.startColorPage.SuspendLayout()
        Me.finishColorPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainTab
        '
        Me.mainTab.AccessibleDescription = resources.GetString("mainTab.AccessibleDescription")
        Me.mainTab.AccessibleName = resources.GetString("mainTab.AccessibleName")
        Me.mainTab.Alignment = CType(resources.GetObject("mainTab.Alignment"), System.Windows.Forms.TabAlignment)
        Me.mainTab.Anchor = CType(resources.GetObject("mainTab.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.mainTab.Appearance = CType(resources.GetObject("mainTab.Appearance"), System.Windows.Forms.TabAppearance)
        Me.mainTab.BackgroundImage = CType(resources.GetObject("mainTab.BackgroundImage"), System.Drawing.Image)
        Me.mainTab.Controls.Add(Me.directionPage)
        Me.mainTab.Controls.Add(Me.startColorPage)
        Me.mainTab.Controls.Add(Me.finishColorPage)
        Me.mainTab.Dock = CType(resources.GetObject("mainTab.Dock"), System.Windows.Forms.DockStyle)
        Me.mainTab.Enabled = CType(resources.GetObject("mainTab.Enabled"), Boolean)
        Me.mainTab.Font = CType(resources.GetObject("mainTab.Font"), System.Drawing.Font)
        Me.mainTab.ImeMode = CType(resources.GetObject("mainTab.ImeMode"), System.Windows.Forms.ImeMode)
        Me.mainTab.ItemSize = CType(resources.GetObject("mainTab.ItemSize"), System.Drawing.Size)
        Me.mainTab.Location = CType(resources.GetObject("mainTab.Location"), System.Drawing.Point)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.Padding = CType(resources.GetObject("mainTab.Padding"), System.Drawing.Point)
        Me.mainTab.RightToLeft = CType(resources.GetObject("mainTab.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.ShowToolTips = CType(resources.GetObject("mainTab.ShowToolTips"), Boolean)
        Me.mainTab.Size = CType(resources.GetObject("mainTab.Size"), System.Drawing.Size)
        Me.mainTab.TabIndex = CType(resources.GetObject("mainTab.TabIndex"), Integer)
        Me.mainTab.Text = resources.GetString("mainTab.Text")
        Me.mainTab.Visible = CType(resources.GetObject("mainTab.Visible"), Boolean)
        '
        'directionPage
        '
        Me.directionPage.AccessibleDescription = resources.GetString("directionPage.AccessibleDescription")
        Me.directionPage.AccessibleName = resources.GetString("directionPage.AccessibleName")
        Me.directionPage.Anchor = CType(resources.GetObject("directionPage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.directionPage.AutoScroll = CType(resources.GetObject("directionPage.AutoScroll"), Boolean)
        Me.directionPage.AutoScrollMargin = CType(resources.GetObject("directionPage.AutoScrollMargin"), System.Drawing.Size)
        Me.directionPage.AutoScrollMinSize = CType(resources.GetObject("directionPage.AutoScrollMinSize"), System.Drawing.Size)
        Me.directionPage.BackgroundImage = CType(resources.GetObject("directionPage.BackgroundImage"), System.Drawing.Image)
        Me.directionPage.Controls.Add(Me.blendSamplePanel)
        Me.directionPage.Controls.Add(Me.directionComboBox)
        Me.directionPage.Dock = CType(resources.GetObject("directionPage.Dock"), System.Windows.Forms.DockStyle)
        Me.directionPage.Enabled = CType(resources.GetObject("directionPage.Enabled"), Boolean)
        Me.directionPage.Font = CType(resources.GetObject("directionPage.Font"), System.Drawing.Font)
        Me.directionPage.ImageIndex = CType(resources.GetObject("directionPage.ImageIndex"), Integer)
        Me.directionPage.ImeMode = CType(resources.GetObject("directionPage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.directionPage.Location = CType(resources.GetObject("directionPage.Location"), System.Drawing.Point)
        Me.directionPage.Name = "directionPage"
        Me.directionPage.RightToLeft = CType(resources.GetObject("directionPage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.directionPage.Size = CType(resources.GetObject("directionPage.Size"), System.Drawing.Size)
        Me.directionPage.TabIndex = CType(resources.GetObject("directionPage.TabIndex"), Integer)
        Me.directionPage.Text = resources.GetString("directionPage.Text")
        Me.directionPage.ToolTipText = resources.GetString("directionPage.ToolTipText")
        Me.directionPage.Visible = CType(resources.GetObject("directionPage.Visible"), Boolean)
        '
        'blendSamplePanel
        '
        Me.blendSamplePanel.AccessibleDescription = resources.GetString("blendSamplePanel.AccessibleDescription")
        Me.blendSamplePanel.AccessibleName = resources.GetString("blendSamplePanel.AccessibleName")
        Me.blendSamplePanel.Anchor = CType(resources.GetObject("blendSamplePanel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.blendSamplePanel.AutoScroll = CType(resources.GetObject("blendSamplePanel.AutoScroll"), Boolean)
        Me.blendSamplePanel.AutoScrollMargin = CType(resources.GetObject("blendSamplePanel.AutoScrollMargin"), System.Drawing.Size)
        Me.blendSamplePanel.AutoScrollMinSize = CType(resources.GetObject("blendSamplePanel.AutoScrollMinSize"), System.Drawing.Size)
        Me.blendSamplePanel.BackgroundImage = CType(resources.GetObject("blendSamplePanel.BackgroundImage"), System.Drawing.Image)
        Me.blendSamplePanel.Dock = CType(resources.GetObject("blendSamplePanel.Dock"), System.Windows.Forms.DockStyle)
        Me.blendSamplePanel.Enabled = CType(resources.GetObject("blendSamplePanel.Enabled"), Boolean)
        Me.blendSamplePanel.Font = CType(resources.GetObject("blendSamplePanel.Font"), System.Drawing.Font)
        Me.blendSamplePanel.ImeMode = CType(resources.GetObject("blendSamplePanel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.blendSamplePanel.Location = CType(resources.GetObject("blendSamplePanel.Location"), System.Drawing.Point)
        Me.blendSamplePanel.Name = "blendSamplePanel"
        Me.blendSamplePanel.RightToLeft = CType(resources.GetObject("blendSamplePanel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.blendSamplePanel.Size = CType(resources.GetObject("blendSamplePanel.Size"), System.Drawing.Size)
        Me.blendSamplePanel.TabIndex = CType(resources.GetObject("blendSamplePanel.TabIndex"), Integer)
        Me.blendSamplePanel.Text = resources.GetString("blendSamplePanel.Text")
        Me.blendSamplePanel.Visible = CType(resources.GetObject("blendSamplePanel.Visible"), Boolean)
        '
        'directionComboBox
        '
        Me.directionComboBox.AccessibleDescription = resources.GetString("directionComboBox.AccessibleDescription")
        Me.directionComboBox.AccessibleName = resources.GetString("directionComboBox.AccessibleName")
        Me.directionComboBox.Anchor = CType(resources.GetObject("directionComboBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.directionComboBox.BackgroundImage = CType(resources.GetObject("directionComboBox.BackgroundImage"), System.Drawing.Image)
        Me.directionComboBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.directionComboBox.Dock = CType(resources.GetObject("directionComboBox.Dock"), System.Windows.Forms.DockStyle)
        Me.directionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.directionComboBox.Enabled = CType(resources.GetObject("directionComboBox.Enabled"), Boolean)
        Me.directionComboBox.Font = CType(resources.GetObject("directionComboBox.Font"), System.Drawing.Font)
        Me.directionComboBox.ImeMode = CType(resources.GetObject("directionComboBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.directionComboBox.IntegralHeight = CType(resources.GetObject("directionComboBox.IntegralHeight"), Boolean)
        Me.directionComboBox.ItemHeight = CType(resources.GetObject("directionComboBox.ItemHeight"), Integer)
        Me.directionComboBox.Location = CType(resources.GetObject("directionComboBox.Location"), System.Drawing.Point)
        Me.directionComboBox.MaxDropDownItems = CType(resources.GetObject("directionComboBox.MaxDropDownItems"), Integer)
        Me.directionComboBox.MaxLength = CType(resources.GetObject("directionComboBox.MaxLength"), Integer)
        Me.directionComboBox.Name = "directionComboBox"
        Me.directionComboBox.RightToLeft = CType(resources.GetObject("directionComboBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.directionComboBox.Size = CType(resources.GetObject("directionComboBox.Size"), System.Drawing.Size)
        Me.directionComboBox.TabIndex = CType(resources.GetObject("directionComboBox.TabIndex"), Integer)
        Me.directionComboBox.Text = resources.GetString("directionComboBox.Text")
        Me.directionComboBox.Visible = CType(resources.GetObject("directionComboBox.Visible"), Boolean)
        '
        'startColorPage
        '
        Me.startColorPage.AccessibleDescription = resources.GetString("startColorPage.AccessibleDescription")
        Me.startColorPage.AccessibleName = resources.GetString("startColorPage.AccessibleName")
        Me.startColorPage.Anchor = CType(resources.GetObject("startColorPage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.startColorPage.AutoScroll = CType(resources.GetObject("startColorPage.AutoScroll"), Boolean)
        Me.startColorPage.AutoScrollMargin = CType(resources.GetObject("startColorPage.AutoScrollMargin"), System.Drawing.Size)
        Me.startColorPage.AutoScrollMinSize = CType(resources.GetObject("startColorPage.AutoScrollMinSize"), System.Drawing.Size)
        Me.startColorPage.BackgroundImage = CType(resources.GetObject("startColorPage.BackgroundImage"), System.Drawing.Image)
        Me.startColorPage.Controls.Add(Me.startColorList)
        Me.startColorPage.Dock = CType(resources.GetObject("startColorPage.Dock"), System.Windows.Forms.DockStyle)
        Me.startColorPage.Enabled = CType(resources.GetObject("startColorPage.Enabled"), Boolean)
        Me.startColorPage.Font = CType(resources.GetObject("startColorPage.Font"), System.Drawing.Font)
        Me.startColorPage.ImageIndex = CType(resources.GetObject("startColorPage.ImageIndex"), Integer)
        Me.startColorPage.ImeMode = CType(resources.GetObject("startColorPage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.startColorPage.Location = CType(resources.GetObject("startColorPage.Location"), System.Drawing.Point)
        Me.startColorPage.Name = "startColorPage"
        Me.startColorPage.RightToLeft = CType(resources.GetObject("startColorPage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.startColorPage.Size = CType(resources.GetObject("startColorPage.Size"), System.Drawing.Size)
        Me.startColorPage.TabIndex = CType(resources.GetObject("startColorPage.TabIndex"), Integer)
        Me.startColorPage.Text = resources.GetString("startColorPage.Text")
        Me.startColorPage.ToolTipText = resources.GetString("startColorPage.ToolTipText")
        Me.startColorPage.Visible = CType(resources.GetObject("startColorPage.Visible"), Boolean)
        '
        'startColorList
        '
        Me.startColorList.AccessibleDescription = resources.GetString("startColorList.AccessibleDescription")
        Me.startColorList.AccessibleName = resources.GetString("startColorList.AccessibleName")
        Me.startColorList.Anchor = CType(resources.GetObject("startColorList.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.startColorList.BackgroundImage = CType(resources.GetObject("startColorList.BackgroundImage"), System.Drawing.Image)
        Me.startColorList.ColumnWidth = CType(resources.GetObject("startColorList.ColumnWidth"), Integer)
        Me.startColorList.Dock = CType(resources.GetObject("startColorList.Dock"), System.Windows.Forms.DockStyle)
        Me.startColorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.startColorList.Enabled = CType(resources.GetObject("startColorList.Enabled"), Boolean)
        Me.startColorList.Font = CType(resources.GetObject("startColorList.Font"), System.Drawing.Font)
        Me.startColorList.HorizontalExtent = CType(resources.GetObject("startColorList.HorizontalExtent"), Integer)
        Me.startColorList.HorizontalScrollbar = CType(resources.GetObject("startColorList.HorizontalScrollbar"), Boolean)
        Me.startColorList.ImeMode = CType(resources.GetObject("startColorList.ImeMode"), System.Windows.Forms.ImeMode)
        Me.startColorList.IntegralHeight = CType(resources.GetObject("startColorList.IntegralHeight"), Boolean)
        Me.startColorList.ItemHeight = CType(resources.GetObject("startColorList.ItemHeight"), Integer)
        Me.startColorList.Location = CType(resources.GetObject("startColorList.Location"), System.Drawing.Point)
        Me.startColorList.Name = "startColorList"
        Me.startColorList.RightToLeft = CType(resources.GetObject("startColorList.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.startColorList.ScrollAlwaysVisible = CType(resources.GetObject("startColorList.ScrollAlwaysVisible"), Boolean)
        Me.startColorList.Size = CType(resources.GetObject("startColorList.Size"), System.Drawing.Size)
        Me.startColorList.TabIndex = CType(resources.GetObject("startColorList.TabIndex"), Integer)
        Me.startColorList.Visible = CType(resources.GetObject("startColorList.Visible"), Boolean)
        '
        'finishColorPage
        '
        Me.finishColorPage.AccessibleDescription = resources.GetString("finishColorPage.AccessibleDescription")
        Me.finishColorPage.AccessibleName = resources.GetString("finishColorPage.AccessibleName")
        Me.finishColorPage.Anchor = CType(resources.GetObject("finishColorPage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.finishColorPage.AutoScroll = CType(resources.GetObject("finishColorPage.AutoScroll"), Boolean)
        Me.finishColorPage.AutoScrollMargin = CType(resources.GetObject("finishColorPage.AutoScrollMargin"), System.Drawing.Size)
        Me.finishColorPage.AutoScrollMinSize = CType(resources.GetObject("finishColorPage.AutoScrollMinSize"), System.Drawing.Size)
        Me.finishColorPage.BackgroundImage = CType(resources.GetObject("finishColorPage.BackgroundImage"), System.Drawing.Image)
        Me.finishColorPage.Controls.Add(Me.finishColorList)
        Me.finishColorPage.Dock = CType(resources.GetObject("finishColorPage.Dock"), System.Windows.Forms.DockStyle)
        Me.finishColorPage.Enabled = CType(resources.GetObject("finishColorPage.Enabled"), Boolean)
        Me.finishColorPage.Font = CType(resources.GetObject("finishColorPage.Font"), System.Drawing.Font)
        Me.finishColorPage.ImageIndex = CType(resources.GetObject("finishColorPage.ImageIndex"), Integer)
        Me.finishColorPage.ImeMode = CType(resources.GetObject("finishColorPage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.finishColorPage.Location = CType(resources.GetObject("finishColorPage.Location"), System.Drawing.Point)
        Me.finishColorPage.Name = "finishColorPage"
        Me.finishColorPage.RightToLeft = CType(resources.GetObject("finishColorPage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.finishColorPage.Size = CType(resources.GetObject("finishColorPage.Size"), System.Drawing.Size)
        Me.finishColorPage.TabIndex = CType(resources.GetObject("finishColorPage.TabIndex"), Integer)
        Me.finishColorPage.Text = resources.GetString("finishColorPage.Text")
        Me.finishColorPage.ToolTipText = resources.GetString("finishColorPage.ToolTipText")
        Me.finishColorPage.Visible = CType(resources.GetObject("finishColorPage.Visible"), Boolean)
        '
        'finishColorList
        '
        Me.finishColorList.AccessibleDescription = resources.GetString("finishColorList.AccessibleDescription")
        Me.finishColorList.AccessibleName = resources.GetString("finishColorList.AccessibleName")
        Me.finishColorList.Anchor = CType(resources.GetObject("finishColorList.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.finishColorList.BackgroundImage = CType(resources.GetObject("finishColorList.BackgroundImage"), System.Drawing.Image)
        Me.finishColorList.ColumnWidth = CType(resources.GetObject("finishColorList.ColumnWidth"), Integer)
        Me.finishColorList.Dock = CType(resources.GetObject("finishColorList.Dock"), System.Windows.Forms.DockStyle)
        Me.finishColorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.finishColorList.Enabled = CType(resources.GetObject("finishColorList.Enabled"), Boolean)
        Me.finishColorList.Font = CType(resources.GetObject("finishColorList.Font"), System.Drawing.Font)
        Me.finishColorList.HorizontalExtent = CType(resources.GetObject("finishColorList.HorizontalExtent"), Integer)
        Me.finishColorList.HorizontalScrollbar = CType(resources.GetObject("finishColorList.HorizontalScrollbar"), Boolean)
        Me.finishColorList.ImeMode = CType(resources.GetObject("finishColorList.ImeMode"), System.Windows.Forms.ImeMode)
        Me.finishColorList.IntegralHeight = CType(resources.GetObject("finishColorList.IntegralHeight"), Boolean)
        Me.finishColorList.ItemHeight = CType(resources.GetObject("finishColorList.ItemHeight"), Integer)
        Me.finishColorList.Location = CType(resources.GetObject("finishColorList.Location"), System.Drawing.Point)
        Me.finishColorList.Name = "finishColorList"
        Me.finishColorList.RightToLeft = CType(resources.GetObject("finishColorList.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.finishColorList.ScrollAlwaysVisible = CType(resources.GetObject("finishColorList.ScrollAlwaysVisible"), Boolean)
        Me.finishColorList.Size = CType(resources.GetObject("finishColorList.Size"), System.Drawing.Size)
        Me.finishColorList.TabIndex = CType(resources.GetObject("finishColorList.TabIndex"), Integer)
        Me.finishColorList.Visible = CType(resources.GetObject("finishColorList.Visible"), Boolean)
        '
        'BlendFillEditorUI
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.Add(Me.mainTab)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.Name = "BlendFillEditorUI"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Text = resources.GetString("$this.Text")
        Me.mainTab.ResumeLayout(False)
        Me.directionPage.ResumeLayout(False)
        Me.startColorPage.ResumeLayout(False)
        Me.finishColorPage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region




    '=----------------------------------------------------------------------=
    ' GetValue
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns what this editor currently has represented as a value.
    ''' </summary>
    ''' 
    ''' <returns>
    '''   A BlendFill object representing the current value of the editor.
    ''' </returns>
    ''' 
    Friend Function GetValue() As BlendFill

        Dim canli As ColorAndNameListItem
        Dim startColor, finishColor As Color
        Dim direction As BlendStyle

        startColor = Nothing
        finishColor = Nothing

        '
        ' Get the start color
        '
        canli = CType(Me.startColorList.Items(Me.startColorList.SelectedIndex), ColorAndNameListItem)
        If Not canli Is Nothing Then
            startColor = canli.Color
        End If

        ' 
        ' Finish Color
        '
        canli = CType(Me.finishColorList.Items(Me.finishColorList.SelectedIndex), ColorAndNameListItem)
        If Not canli Is Nothing Then
            finishColor = canli.Color
        End If

        '
        ' blend direction
        '
        direction = CType(Me.directionComboBox.SelectedIndex, BlendStyle)

        Return New BlendFill(direction, startColor, finishColor)

    End Function ' GetValue



    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Private Methods/Properties/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' populateDirectionListBox
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Populates and initializes the direction list box with the
    '''   appropriate values.
    ''' </summary>
    ''' 
    ''' <param name="in_resources">
    '''   From where to obtain localized strings.
    ''' </param>
    ''' 
    Private Sub populateDirectionListBox(ByVal in_resources As System.Resources.ResourceManager)

        Dim s As String

        '
        ' Please note that these keys match the values/order of BlendStyle
        ' exactly !!!!
        '
        Dim keys() As String = New String() { _
            "directionHorizontal", _
            "directionVertical", _
            "directionForwardDiagonal", _
            "directionBackwardDiagonal" _
        }

        '
        ' okay, whip through the list of values, and put them into the list
        ' box.
        '
        For x As Integer = 0 To keys.Length - 1

            s = in_resources.GetString(keys(x))
            System.Diagnostics.Debug.Assert(Not s Is Nothing AndAlso Not s = "")
            Me.directionComboBox.Items.Add(s)

        Next

        '
        ' Finally, select the appropriate item
        '
        Me.directionComboBox.SelectedIndex = Me.m_direction

    End Sub ' populateDirectionListBox


    '=----------------------------------------------------------------------=
    ' populateAndSelectColorList
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Sets up an owner draw listbox to contain most of the interesting
    '''   colors currently available on the system.  It will then select
    '''   the given color.
    ''' </summary>
    ''' 
    ''' <param name="in_listBox">
    '''   The owner-draw ListBox to populate.
    ''' </param>
    ''' 
    ''' <param name="in_selectMe">
    '''   The Color to select.
    ''' </param>
    ''' 
    ''' <param name="in_resources">
    '''   From where to get localized strings.
    ''' </param>
    ''' 
    Private Sub populateAndSelectColorList(ByVal in_listBox As ListBox, _
                                            ByVal in_selectMe As Color, _
                                            ByVal in_resources As System.Resources.ResourceManager)

        Dim canli As New ColorAndNameListItem
        Dim s As String

        '
        ' 1. Add SystemColors to list box.  Please note that we're going to
        '    pass in the color to select so that we can compare against the
        '    colors in their native format, and not have to go back and 
        '    regenerate the colors from the type strings, etc ...
        '
        addColorsToList(in_listBox, GetType(SystemColors), in_selectMe)

        '
        ' 2. Add Regular colors to the list box.
        '
        addColorsToList(in_listBox, GetType(Color), in_selectMe)

        '
        ' 3. If the user gave us a color that isn't one of the predefined
        '    system-y colors, then go and add a "Custom" entry for their
        '    color.
        '
        If in_listBox.SelectedIndex = -1 Then
            s = in_resources.GetString("customColor")
            System.Diagnostics.Debug.Assert(Not s Is Nothing AndAlso Not s = "")

            canli = New ColorAndNameListItem
            canli.Color = in_selectMe
            canli.Name = s

            in_listBox.Items.Insert(0, canli)
            in_listBox.SelectedIndex = 0
        End If

    End Sub ' populateAndSelectColorList


    '=----------------------------------------------------------------------=
    ' addColorsToList
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Given an object with a tonne of static color objects, go and get
    '''   those and add them to the list of colors.  We will also do an
    '''   optimisation, and select the appropriate color if it's in our list.
    ''' </summary>
    ''' 
    ''' <param name="in_listBox">
    '''   Where to add the colors.
    ''' </param>
    ''' 
    ''' <param name="in_colorSource">
    '''   From which class to get the colors.
    ''' </param>
    ''' 
    ''' <param name="in_selectMe">
    '''   Indicates which color to select when showing the list.
    ''' </param>
    ''' 
    Private Sub addColorsToList(ByVal in_listBox As ListBox, _
                                 ByVal in_colorSource As Type, _
                                 ByVal in_selectMe As Color)

        Dim pic() As System.Reflection.PropertyInfo
        Dim canli As ColorAndNameListItem
        Dim pi As System.Reflection.PropertyInfo
        Dim i As Integer

        pic = in_colorSource.GetProperties(CType(&HFFFFFFFF, System.Reflection.BindingFlags))

        '
        ' Loop through all the properties looking for Color properties.
        '
        For Each pi In pic

            If pi.PropertyType() Is GetType(Color) Then
                canli = New ColorAndNameListItem
                canli.Color = CType(pi.GetValue(Nothing, Nothing), Color)
                canli.Name = pi.Name

                i = in_listBox.Items.Add(canli)
                If in_selectMe.Equals(canli.Color) Then
                    in_listBox.SelectedIndex = i
                End If
            End If
        Next

    End Sub ' addColorsToList



    '=----------------------------------------------------------------------=
    ' startColorList_DrawItem
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   We are supposed to draw an item in the list box now.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   Details about it, including the Graphics object.
    ''' </param>
    ''' 
    Private Sub startColorList_DrawItem(ByVal sender As Object, _
                                         ByVal e As DrawItemEventArgs) _
                                         Handles startColorList.DrawItem

        drawItemForListBox(CType(sender, ListBox), e)

    End Sub ' startColorList_DrawItem



    '=----------------------------------------------------------------------=
    ' finishColorList_DrawItem
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   We are supposed to draw an item in the list box now.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   Details about it, including the Grahpics object.
    ''' </param>
    ''' 
    Private Sub finishColorList_DrawItem(ByVal sender As Object, _
                                          ByVal e As DrawItemEventArgs) _
                                          Handles finishColorList.DrawItem

        drawItemForListBox(CType(sender, ListBox), e)

    End Sub ' finishColorList_DrawItem


    '=----------------------------------------------------------------------=
    ' drawItemForListBox
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Draws an item for one of the two color list boxes.  We're just
    '''   going to try and look as much like the regular Color UITypeEditor
    '''   as possible.
    ''' </summary>
    ''' 
    ''' <param name="in_listBox">
    '''   The ListBox being drawn.
    ''' </param>
    ''' 
    ''' <param name="in_args">
    '''   Detailsa bout the painting event.
    ''' </param>
    ''' 
    Private Sub drawItemForListBox(ByVal in_listBox As ListBox, _
                                   ByVal in_args As DrawItemEventArgs)

        Dim canli As ColorAndNameListItem
        Dim b As SolidBrush
        Dim r As Rectangle
        Dim g As Graphics
        Dim p As Pen

        b = Nothing
        g = Nothing
        p = Nothing

        If in_listBox Is Nothing Then
            System.Diagnostics.Debug.Fail("DrawItem event for something that isn't a ListBox!")
            Return
        End If

        '
        ' draw the background for all the dudes. Cooly, this changes color
        ' based on selection, etc ... coool!
        '
        in_args.DrawBackground()

        g = in_args.Graphics
        r = in_args.Bounds

        '
        ' Get the ColorAndNameListItem for the details of what we're doing.
        '
        canli = CType(in_listBox.Items(in_args.Index), ColorAndNameListItem)
        If canli Is Nothing Then
            System.Diagnostics.Debug.Fail("A bogus item was inserted into the " & in_listBox.Name & " ListBox.")
            Return
        End If

        '
        ' Now, go and draw the color in a little framed box.
        '
        Try
            b = New SolidBrush(canli.Color)
            p = New Pen(Color.Black)

            g.FillRectangle(b, r.Left + 2, r.Top + 2, 22, in_listBox.ItemHeight - 4)
            g.DrawRectangle(p, r.Left + 2, r.Top + 2, 22, in_listBox.ItemHeight - 4)

        Finally

            If Not b Is Nothing Then b.Dispose()
            If Not p Is Nothing Then p.Dispose()

        End Try

        '
        ' Finally, go and draw the text next to the color !
        '
        Try
            If Not (in_args.State And DrawItemState.Selected) = 0 Then
                b = New SolidBrush(in_listBox.BackColor)
            Else
                b = New SolidBrush(SystemColors.ControlText)
            End If


            g.DrawString(canli.Name, in_listBox.Font, b, _
                         r.Left + 26, in_args.Bounds.Top + 2)

        Finally

            If Not b Is Nothing Then b.Dispose()

        End Try

    End Sub ' drawItemForListBox


    '=----------------------------------------------------------------------=
    ' blendSamplePanel_Paint
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Paints a little preview of the blend operation for the user.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   Deatils about the event, including the Graphics object.
    ''' </param>
    ''' 
    Private Sub blendSamplePanel_Paint(ByVal sender As Object, _
                                       ByVal e As PaintEventArgs) _
                                       Handles blendSamplePanel.Paint

        Dim lgb As LinearGradientBrush
        Dim rects() As Rectangle
        Dim g As Graphics
        Dim p As Pen

        lgb = Nothing
        p = Nothing
        g = e.Graphics

        '
        ' Draw the four sample rects.
        '
        rects = getPanelRects()

        For x As Integer = 0 To rects.Length - 1

            Try
                'If x = 0 AndAlso Me.m_reverse = True Then
                'lgb = New LinearGradientBrush(rects(x), Me.m_finishColor, _
                '         Me.m_startColor, getAngle(x))
                'Else
                lgb = New LinearGradientBrush(rects(x), Me.m_startColor, _
                          Me.m_finishColor, getAngle(x))
                'End If

                g.FillRectangle(lgb, rects(x))

                '
                ' Draw a rect around it.
                '
                If x = Me.m_direction Then
                    p = New Pen(Color.Black, 3)
                Else
                    p = New Pen(Color.Black, 1)
                End If

                g.DrawRectangle(p, rects(x))

            Finally
                If Not lgb Is Nothing Then lgb.Dispose()
                If Not p Is Nothing Then p.Dispose()
            End Try

        Next


    End Sub ' blendSamplePanel_Paint


    '=----------------------------------------------------------------------=
    ' getAngle
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns an angle for a LinearGradientBrush given a direction/style.
    ''' </summary>
    ''' 
    ''' <param name="in_direction">
    '''   The style or direction for which we wish to query the angle.
    ''' </param>
    ''' 
    ''' <returns>
    '''   The angle to draw.
    ''' </returns>
    ''' 
    Private Function getAngle(ByVal in_direction As Integer) As Single

        Select Case in_direction

            Case BlendStyle.Horizontal
                If Me.m_reverse = False Then
                    Return 0S
                Else
                    Return 180S
                End If

            Case BlendStyle.Vertical
                Return 90S

            Case BlendStyle.ForwardDiagonal
                If Me.m_reverse = False Then
                    Return 45S
                Else
                    Return 135S
                End If

            Case BlendStyle.BackwardDiagonal
                If Me.m_reverse = False Then
                    Return 135S
                Else
                    Return 45S
                End If

            Case Else
                System.Diagnostics.Debug.Fail("Bogus Direction")
                Return 0S
        End Select

    End Function ' getAngle


    '=----------------------------------------------------------------------=
    ' getPanelRects
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns the rectangles in which to draw the samples.
    ''' </summary>
    ''' 
    ''' <returns>
    '''   An array of rectangles in which to draw the samples.
    ''' </returns>
    ''' 
    Private Function getPanelRects() As Rectangle()

        Dim rects() As Rectangle
        Dim w, h As Integer

        w = CType(blendSamplePanel.Width / 2, Integer) - 8
        h = CType(blendSamplePanel.Height / 2, Integer) - 8
        rects = New Rectangle(3) {}

        rects(0) = New Rectangle(4, 4, w, h)
        rects(1) = New Rectangle(w + 8, 4, w, h)
        rects(2) = New Rectangle(4, h + 8, w, h)
        rects(3) = New Rectangle(w + 8, h + 8, w, h)

        Return rects

    End Function ' getPanelRects


    '=----------------------------------------------------------------------=
    ' directionComboBox_SelectedIndexChanged
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Update the sample panel with the new selection.
    ''' </summary>
    ''' 
    Private Sub directionComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles directionComboBox.SelectedIndexChanged

        Me.m_direction = CType(Me.directionComboBox.SelectedIndex, BlendStyle)
        Me.blendSamplePanel.Refresh()

    End Sub ' directionComboBox_SelectedIndexChanged


    '=----------------------------------------------------------------------=
    ' finishColorList_SelectedIndexChanged
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Update the sample box.
    ''' </summary>
    ''' 
    Private Sub finishColorList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles finishColorList.SelectedIndexChanged

        Dim canli As ColorAndNameListItem

        canli = CType(Me.finishColorList.Items(Me.finishColorList.SelectedIndex), ColorAndNameListItem)
        If Not canli Is Nothing Then
            Me.m_finishColor = canli.Color
        End If

        Me.blendSamplePanel.Refresh()

    End Sub ' finishColorList_SelectedIndexChanged


    '=----------------------------------------------------------------------=
    ' startColorList_SelectedIndexChanged
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Update the sample box.
    ''' </summary>
    ''' 
    Private Sub startColorList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles startColorList.SelectedIndexChanged

        Dim canli As ColorAndNameListItem

        canli = CType(Me.startColorList.Items(Me.startColorList.SelectedIndex), ColorAndNameListItem)
        If Not canli Is Nothing Then
            Me.m_startColor = canli.Color
        End If

        Me.blendSamplePanel.Refresh()

    End Sub ' startColorList_SelectedIndexChanged


    '=----------------------------------------------------------------------=
    ' blendSamplePanel_MouseUp
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   They've clicked on the sample panel.  Update the selection if
    '''   necessary.
    ''' </summary>
    ''' 
    Private Sub blendSamplePanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles blendSamplePanel.MouseUp
        Dim rects() As Rectangle

        rects = getPanelRects()

        For x As Integer = 0 To rects.Length - 1
            If rects(x).Contains(e.X, e.Y) Then
                Me.m_direction = CType(x, BlendStyle)
                Me.blendSamplePanel.Refresh()
                Me.directionComboBox.SelectedIndex = x
            End If
        Next

    End Sub ' blendSamplePanel_MouseUp


    '=----------------------------------------------------------------------=
    ' blendSamplePanel_DoubleClick
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Close down the editor.
    ''' </summary>
    ''' 
    Private Sub blendSamplePanel_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles blendSamplePanel.DoubleClick

        If Not Me.m_svc Is Nothing Then
            Me.m_svc.CloseDropDown()
        End If

    End Sub ' blendSamplePanel_DoubleClick



    '=----------------------------------------------------------------------=
    ' startColorList_DoubleClick
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Close down the editor.
    ''' </summary>
    ''' 
    Private Sub startColorList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles startColorList.DoubleClick

        If Not Me.m_svc Is Nothing Then
            Me.m_svc.CloseDropDown()
        End If

    End Sub ' startColorList_DoubleClick


    '=----------------------------------------------------------------------=
    ' finishColorList_DoubleClick
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Close down the editor.
    ''' </summary>
    ''' 
    Private Sub finishColorList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles finishColorList.DoubleClick

        If Not Me.m_svc Is Nothing Then
            Me.m_svc.CloseDropDown()
        End If

    End Sub ' finishColorList_DoubleClick






    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                           Private Types
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' ColorAndNameListItem
    '=----------------------------------------------------------------------=
    ' Wraps a list item in our two color list boxes.
    '
    '
    Private Class ColorAndNameListItem

        Public Color As Color
        Public Name As String

        Public Overrides Function ToString() As String
            Return Me.Name
        End Function

    End Class ' ColorAndNameListItem



End Class ' BlendFillEditorUI
