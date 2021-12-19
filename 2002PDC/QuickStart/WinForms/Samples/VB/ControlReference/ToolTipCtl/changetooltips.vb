'------------------------------------------------------------------------------
' <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'       
'    This source code is intended only as a supplement to Microsoft
'    Development Tools and/or on-line documentation.  See these other
'    materials for detailed information regarding Microsoft code samples.
'
' </copyright>                                                                
'------------------------------------------------------------------------------

Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms
Imports System.Diagnostics

Option Explicit
Option Strict Off

namespace Microsoft.Samples.WinForms.Vb.ToolTipCtl 
   

    public class ChangeToolTips : inherits System.WinForms.Form
        protected imgList As ImageList
        protected toolTips() As String

        public Sub New(smlImageList As ImageList, toolTips() As String)
            MyBase.New() 

            ' Required for WinForms Form Designer support
            InitForm()     

            Me.imgList = smlImageList
            Me.toolTips = toolTips
            listView1.SmallImageList = smlImageList
            SetToolTipRows()
        end sub

        private sub SetToolTipRows() 
            Debug.Assert(imgList.Images.Count = toolTips.Length, "Incorrect number of images or tooltips")

            listView1.Columns.Add("ToolTip Text", listView1.Size.Width - 5, HorizontalAlignment.Left)
	    Dim i As Integer
            for i = 0 to toolTips.Length-1
                Dim item As new ListItem(toolTips(i),i)
                listView1.ListItems.Add(item)
            next
        end sub

        public function GetToolTips() As String() 
            return toolTips
        end function

        ' <doc>
        ' <desc>
        '     ChangeToolTips overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        overrides public sub Dispose() 
            MyBase.Dispose()
            components.Dispose()
        end sub

        private sub ListView1_afterLabelEdit(source As Object, e As LabelEditEventArgs) 
            if (e.Label = Nothing) then
                e.CancelEdit = true
                return
            end if
            toolTips(e.Item) = e.Label
        end sub

        ' <doc>
        ' <desc>
        '     NOTE: The following code is required by the WFC form
        '     designer.  It can be modified using the form editor.  Do not
        '     modify it using the code editor.
        ' </desc>
        ' </doc>
        '
        protected components As new System.ComponentModel.Container()
        protected btnOk As new System.WinForms.Button()
        protected btnCancel As new System.WinForms.Button()
        protected listView1 As new System.WinForms.ListView()
        protected label1 As new System.WinForms.Label()

        private sub InitForm() 
            Me.Text = "ChangeToolTips"
            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.BorderStyle = System.WinForms.FormBorderStyle.FixedDialog
            Me.ClientSize = new System.Drawing.Size(302, 302)
            Me.MaximizeBox = false
            Me.MinimizeBox = false
            Me.ShowInTaskbar = false

            btnOk.Location = new System.Drawing.Point(16, 272)
            btnOk.Size = new System.Drawing.Size(75, 23)
            btnOk.TabIndex = 1
            btnOk.Text = "&Ok"
            btnOk.DialogResult = System.WinForms.DialogResult.OK

            btnCancel.Location = new System.Drawing.Point(104, 272)
            btnCancel.Size = new System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 2
            btnCancel.Text = "&Cancel"
            btnCancel.DialogResult = System.WinForms.DialogResult.Cancel

            listView1.Location = new System.Drawing.Point(16, 48)
            listView1.Size = new System.Drawing.Size(272, 192)
            listView1.TabIndex = 0
            listView1.Text = "listView1"
            listView1.HeaderStyle = System.WinForms.ColumnHeaderStyle.Nonclickable
            listView1.LabelEdit = true
            listView1.MultiSelect = false
            listView1.View = System.WinForms.View.Report
            listView1.AddOnAfterLabelEdit(new LabelEditEventHandler(AddressOf Me.ListView1_afterLabelEdit))

            label1.Location = new System.Drawing.Point(16, 8)
            label1.Size = new System.Drawing.Size(272, 24)
            label1.TabIndex = 3
            label1.TabStop = false
            label1.Text = "To change the text for a tooltip, click or press enter on a selected label."

            Me.SetNewControls(new Control() { label1, listView1, btnCancel, btnOk })
        end sub
    end class
end namespace

