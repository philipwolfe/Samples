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
'namespace Microsoft.Samples.WinForms.VB.CheckedListBoxCtl

    imports System
    imports System.ComponentModel
    imports System.WinForms
    imports System.Resources
    imports System.Drawing

'option strict off


    public Module ModMain

    ' <doc>
    ' <desc>
    '     This sample demonstrates many of the properties and features
    '     of the CheckedListBox control.
    ' </desc>
    ' </doc>
    '
    public class CheckedListBoxCtl
	Inherits System.WinForms.Form


        
        ' <doc>
        ' <desc>
        '     Public Constructor
        ' </desc>
        ' </doc>
        '
	Public Sub New()
        	MyBase.New

            dim i as integer
 	
            ' This call is required for support of the WinForms Designer.
            InitializeComponent()

            ' Add all but the last five fruits to the checkedListBox1
            for i = 0 to fruits.Length - 5
                checkedListBox1.Items.Add(fruits(i))
            next
        end sub

        ' CheckedListBoxCtl overrides dispose so it can clean up the
        ' component list.
        overrides public sub Dispose()
            MyBase.Dispose()
            components.Dispose()
        end sub

        ' <doc>
        ' <desc>
        '     Event that gets fired when the user clicks on the threeDCheckBoxes
        '     checkbox.
        ' </desc>
        ' </doc>
        '
        private  sub chkThreeDCheckBoxes_Click(sender as object,  e as EventArgs)
            checkedListBox1.ThreeDCheckBoxes = chkThreeDCheckBoxes.Checked
        end sub
    
        ' <doc>
        ' <desc>
        '     Event that gets fired when the user clicks on the integralHeight
        '     checkbox.
        ' </desc>
        ' </doc>
        '
        private  sub chkIntegralHeight_Click(sender as object,  e as EventArgs)
            checkedListBox1.IntegralHeight = chkIntegralHeight.Checked
            checkedListBox1.Height = 94
        end sub
    
        ' <doc>
        ' <desc>
        '     Event that gets fired when the user clicks on the multiColumn
        '     checkbox.
        ' </desc>
        ' </doc>
        '
        private  sub chkMultiColumn_Click(sender as object,  e as EventArgs)
            checkedListBox1.MultiColumn = chkMultiColumn.Checked
        end sub
    
        ' <doc>
        ' <desc>
        '     Event that gets fired when the user clicks on the sorted
        '     checkbox.
        ' </desc>
        ' </doc>
        '
        private  sub chkSorted_Click(sender as object,  e as EventArgs)
            checkedListBox1.Sorted = chkSorted.Checked
            cmdReset.Enabled = not chkSorted.Checked
        end sub
    
        ' <doc>
        ' <desc>
        '     This event gets fired when the user clicks on the onClick
        '     CheckBox.
        ' </desc>
        ' </doc>
        '
        private  sub chkOnClick_Click(sender as object,  e as EventArgs)
            checkedListBox1.CheckOnClick = chkOnClick.Checked
        end sub
    
        ' <doc>
        ' <desc>
        '     Event that gets fired when the user clicks on the Add
        '     button.  This handler adds a fruit to the listbox if
        '     any additional fruit remain.
        ' </desc>
        ' </doc>
        '
        private  sub cmdAdd_Click(sender as object,  e as EventArgs)
            ' If we still have some fruit that have not been
            ' added to the checkedListBox1, run through the list
            ' and add the first fruit that has not been added.
            if (checkedListBox1.Items.Count < fruits.Length) then
                dim stopLoop as boolean = false
                dim found as boolean = false
                dim i as integer = 0
		dim j as integer
                do while (stopLoop = false)
                    found = false
                    for j = 0 to checkedListBox1.Items.Count -1
                        if (fruits(i).Equals(checkedListBox1.Items(j))) then
                            found = true
			    exit for
			endif
                    next
                    if (found = false) then
                        stopLoop = true
		    else
			i += 1
		    endif
                loop
                checkedListBox1.Items.Add(fruits(i))
            endif
    
            ' Make sure that the user can't attemp to add fruits
            ' that don't exist.
            if (checkedListBox1.Items.Count = fruits.Length) then _
                cmdAdd.Enabled = false
    
            if (checkedListBox1.Items.Count > 0) then _
                cmdRemove.Enabled = true
        end sub
    
        ' <doc>
        ' <desc>
        '     Event that gets fired when the user clicks on the Remove button.
        '     This handler removes the selected fruit from the list.
        ' </desc>
        ' </doc>
        '
        private  sub cmdRemove_Click(sender as object,  e as EventArgs)
            if (checkedListBox1.SelectedIndex >= 0) then
                dim index as integer = checkedListBox1.SelectedIndex
                checkedListBox1.Items.Remove(index)
    
                if (index > 0) then
                    checkedListBox1.SelectedIndex = index - 1
                elseif (checkedListBox1.Items.Count <> 0) then
                    checkedListBox1.SelectedIndex = 0
		endif
            endif
    
            if (checkedListBox1.Items.Count = 0) then _
                cmdRemove.Enabled = false
    
            if (checkedListBox1.Items.Count < fruits.Length) then _
                cmdAdd.Enabled = true
        end sub
    
        ' <doc>
        ' <desc>
        '     Event that gets fired when the user clicks on the Reset button.
        ' </desc>
        ' </doc>
        '
        private  sub cmdReset_Click(sender as object ,  e as EventArgs)
            dim nListItems as integer = checkedListBox1.Items.Count
            dim new_checked(fruits.Length) as boolean
            dim item as string = ""
 
	    dim k as integer
            for k = 0 to fruits.Length -1
                new_checked(k) = false
    	    next

            dim m as integer = 0
            for k = 0 to nListItems -1
                if (checkedListBox1.GetItemChecked(k)) then
                    item = Cstr(checkedListBox1.Items(k))
                    for m = 0 to fruits.Length-1
                        if (fruits(m).Equals(item)) then _
                            new_checked(m) = true
		    next
                endif
            next
    
            checkedListBox1.Items.Clear()
    
            for k= 0 to nListItems -1
                checkedListBox1.Items.Add(fruits(k))
                if (new_checked(k) = true) then _
                    checkedListBox1.SetItemChecked(k,true)
            next
    
            cmdReset.Enabled = false
        end sub

	    private components as System.ComponentModel.Container  
	    private toolTip1 as System.WinForms.ToolTip 
	    private groupBox1 as System.WinForms.GroupBox 
	    private chkOnClick as System.WinForms.CheckBox 
	    private chkIntegralHeight as System.WinForms.CheckBox 
	    private chkMultiColumn as System.WinForms.CheckBox 
	    private cmdAdd as System.WinForms.Button 
	    private chkSorted as System.WinForms.CheckBox 
	    private cmdRemove as System.WinForms.Button 
	    private cmdReset as System.WinForms.Button 
	    private chkThreeDCheckBoxes as System.WinForms.CheckBox 
	    private checkedListBox1 as System.WinForms.CheckedListBox 

        ' <doc>
        ' <desc>
        '     The fruit that we can add to the checkedListBox1.
        ' </desc>
        ' </doc>
        '

    	        private fruits as string()  = new string() { "Spruce", _
                                "Ash", _
                                "Koa", _
                                "Elm", _
                                "Oak", _
                                "Cherry", _
                                "Ironwood", _
                                "Cedar", _
                                "Sequoia", _
                                "Walnut", _
                                "Maple", _
                                "Balsa", _
                                "Pine" }

        ' NOTE: The following code is required by the Win Forms Designer
        ' It can be modified using the Win Forms Designer.  
        ' Do not modify it using the code editor.
        private  sub InitializeComponent()
		Me.components = new System.ComponentModel.Container()
		Me.chkMultiColumn = new System.WinForms.CheckBox()
		Me.cmdRemove = new System.WinForms.Button()
		Me.chkSorted = new System.WinForms.CheckBox()
		Me.cmdReset = new System.WinForms.Button()
		Me.chkThreeDCheckBoxes = new System.WinForms.CheckBox()
		Me.groupBox1 = new System.WinForms.GroupBox()
		Me.chkOnClick = new System.WinForms.CheckBox()
		Me.chkIntegralHeight = new System.WinForms.CheckBox()
		Me.cmdAdd = new System.WinForms.Button()
		Me.checkedListBox1 = new System.WinForms.CheckedListBox()
		Me.toolTip1 = new System.WinForms.ToolTip(components)
		
		chkMultiColumn.Location = new System.Drawing.Point(16, 72)
		chkMultiColumn.TabIndex = 2
		chkMultiColumn.CheckState = System.WinForms.CheckState.Checked
		chkMultiColumn.Text = "&MultiColumn"
		chkMultiColumn.Size = new System.Drawing.Size(104, 25)
		chkMultiColumn.Checked = true
		chkMultiColumn.AddOnClick(new System.EventHandler(AddressOf chkMultiColumn_Click))
		
		cmdRemove.Location = new System.Drawing.Point(96, 168)
		cmdRemove.TabIndex = 3
		cmdRemove.Text = "&Remove"
		cmdRemove.Size = new System.Drawing.Size(75, 23)
		cmdRemove.AddOnClick(new System.EventHandler(AddressOf cmdRemove_Click))
		
		chkSorted.Location = new System.Drawing.Point(16, 96)
		chkSorted.TabIndex = 3
		chkSorted.Text = "&Sorted"
		chkSorted.Size = new System.Drawing.Size(136, 25)
		toolTip1.SetToolTip(chkSorted, "Controls whether the list is sorted.")
		chkSorted.AddOnClick(new System.EventHandler(AddressOf chkSorted_Click))
		
		cmdReset.Location = new System.Drawing.Point(16, 200)
		cmdReset.TabIndex = 4
		cmdReset.Enabled = false
		cmdReset.Text = "&Reset"
		cmdReset.Size = new System.Drawing.Size(75, 23)
		cmdReset.AddOnClick(new System.EventHandler(AddressOf cmdReset_Click))
		
		chkThreeDCheckBoxes.Location = new System.Drawing.Point(16, 24)
		chkThreeDCheckBoxes.TabIndex = 0
		chkThreeDCheckBoxes.CheckState = System.WinForms.CheckState.Checked
		chkThreeDCheckBoxes.Text = "T&hreeDCheckBoxes"
		chkThreeDCheckBoxes.Size = new System.Drawing.Size(136, 25)
		chkThreeDCheckBoxes.Checked = true
		toolTip1.SetToolTip(chkThreeDCheckBoxes, "Indicates if the check values should be shown as flat or 3D checkmarks.")
		chkThreeDCheckBoxes.AddOnClick(new System.EventHandler(AddressOf chkThreeDCheckBoxes_Click))
		
		groupBox1.Location = new System.Drawing.Point(248, 16)
		groupBox1.TabIndex = 0
		groupBox1.TabStop = false
		groupBox1.Text = "CheckedListBox"
		groupBox1.Size = new System.Drawing.Size(248, 264)
		
		chkOnClick.Location = new System.Drawing.Point(16, 120)
		chkOnClick.TabIndex = 4
		chkOnClick.CheckState = System.WinForms.CheckState.Checked
		chkOnClick.Text = "&CheckOnClick"
		chkOnClick.Size = new System.Drawing.Size(136, 25)
		chkOnClick.Checked = true
		toolTip1.SetToolTip(chkOnClick, "Indicates whether the check box should be toggled on the first click on an item.")
		chkOnClick.AddOnClick(new System.EventHandler(AddressOf chkOnClick_Click))
		
		chkIntegralHeight.Location = new System.Drawing.Point(16, 48)
		chkIntegralHeight.TabIndex = 1
		chkIntegralHeight.CheckState = System.WinForms.CheckState.Checked
		chkIntegralHeight.Text = "&IntegralHeight"
		chkIntegralHeight.Size = new System.Drawing.Size(120, 25)
		chkIntegralHeight.Checked = true
		chkIntegralHeight.AddOnClick(new System.EventHandler(AddressOf chkIntegralHeight_Click))
		
		cmdAdd.Location = new System.Drawing.Point(16, 168)
		cmdAdd.TabIndex = 2
		cmdAdd.Text = "&Add"
		cmdAdd.Size = new System.Drawing.Size(75, 23)
		cmdAdd.AddOnClick(new System.EventHandler(AddressOf cmdAdd_Click))
		
		checkedListBox1.ThreeDCheckBoxes = true
		checkedListBox1.IntegralHeight = false
		checkedListBox1.TabIndex = 1
		checkedListBox1.CheckOnClick = true
		checkedListBox1.ColumnWidth = 100
		checkedListBox1.MultiColumn = true
		checkedListBox1.Size = new System.Drawing.Size(232, 84)
		checkedListBox1.Location = new System.Drawing.Point(8, 24)
		checkedListBox1.Text = "checkedListBox1"
		
		toolTip1.Active = true
		'@design toolTip1.SetLocation(new System.Drawing.Point(10, 10))
		
		Me.Text = "Checked ListBox"
		Me.TabIndex = 0
		Me.Size = new System.Drawing.Size(512, 320)
		
		Me.Controls.Add(groupBox1)
		Me.Controls.Add(cmdAdd)
		Me.Controls.Add(cmdRemove)
		Me.Controls.Add(cmdReset)
		Me.Controls.Add(checkedListBox1)
		groupBox1.Controls.Add(chkOnClick)
		groupBox1.Controls.Add(chkIntegralHeight)
		groupBox1.Controls.Add(chkMultiColumn)
		groupBox1.Controls.Add(chkThreeDCheckBoxes)
		groupBox1.Controls.Add(chkSorted)
		
	end sub
    end class

        ' The main entry point for the application.
        public  sub Main()
            Application.Run(new CheckedListBoxCtl())
        end sub


end module




