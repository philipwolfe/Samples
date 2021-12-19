//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.CheckedListBoxCtl {
    using System;
    using System.ComponentModel;
    using System.WinForms;
    using System.Resources;
    using System.Drawing;

    // <doc>
    // <desc>
    //     This sample demonstrates many of the properties and features
    //     of the CheckedListBox control.
    // </desc>
    // </doc>
    //
    public class CheckedListBoxCtl : System.WinForms.Form {

        private System.ComponentModel.Container components ;
	    private System.WinForms.ToolTip toolTip1;
        private System.WinForms.GroupBox groupBox1;
	    private System.WinForms.CheckBox chkOnClick;
	    private System.WinForms.CheckBox chkIntegralHeight;
	    private System.WinForms.CheckBox chkMultiColumn;
	    private System.WinForms.Button cmdAdd;
	    private System.WinForms.CheckBox chkSorted;
	    private System.WinForms.Button cmdRemove;
	    private System.WinForms.Button cmdReset;
	    private System.WinForms.CheckBox chkThreeDCheckBoxes;
	    private System.WinForms.CheckedListBox checkedListBox1;

        // <doc>
        // <desc>
        //     The fruit that we can add to the checkedListBox1.
        // </desc>
        // </doc>
        //
        private string[] fruits = new string[] { "Spruce",
                                "Ash",
                                "Koa",
                                "Elm",
                                "Oak",
                                "Cherry",
                                "Ironwood",
                                "Cedar",
                                "Sequoia",
                                "Walnut",
                                "Maple",
                                "Balsa",
                                "Pine" };

        
        // <doc>
        // <desc>
        //     Public Constructor
        // </desc>
        // </doc>
        //
        public CheckedListBoxCtl () : base() {
             	
            // This call is required for support of the WinForms Designer.
            InitializeComponent();

            // Add all but the last five fruits to the checkedListBox1
            for (int i = 0; i <= fruits.Length - 5; i++) {
                checkedListBox1.Items.Add(fruits[i]);
            }
        }

        // CheckedListBoxCtl overrides dispose so it can clean up the
        // component list.
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        // <doc>
        // <desc>
        //     Event that gets fired when the user clicks on the threeDCheckBoxes
        //     checkbox.
        // </desc>
        // </doc>
        //
        private void chkThreeDCheckBoxes_Click(object sender, EventArgs e) {
            checkedListBox1.ThreeDCheckBoxes = chkThreeDCheckBoxes.Checked;
        }
    
        // <doc>
        // <desc>
        //     Event that gets fired when the user clicks on the integralHeight
        //     checkbox.
        // </desc>
        // </doc>
        //
        private void chkIntegralHeight_Click(object sender, EventArgs e) {
            checkedListBox1.IntegralHeight = chkIntegralHeight.Checked;
            checkedListBox1.Height = 94;
        }
    
        // <doc>
        // <desc>
        //     Event that gets fired when the user clicks on the multiColumn
        //     checkbox.
        // </desc>
        // </doc>
        //
        private void chkMultiColumn_Click(object sender, EventArgs e) {
            checkedListBox1.MultiColumn = chkMultiColumn.Checked;
        }
    
        // <doc>
        // <desc>
        //     Event that gets fired when the user clicks on the sorted
        //     checkbox.
        // </desc>
        // </doc>
        //
        private void chkSorted_Click(object sender, EventArgs e) {
            checkedListBox1.Sorted = chkSorted.Checked;
            cmdReset.Enabled = !chkSorted.Checked;
        }
    
        // <doc>
        // <desc>
        //     This event gets fired when the user clicks on the onClick
        //     CheckBox.
        // </desc>
        // </doc>
        //
        private void chkOnClick_Click(object sender, EventArgs e) {
            checkedListBox1.CheckOnClick = chkOnClick.Checked;
        }
    
        // <doc>
        // <desc>
        //     Event that gets fired when the user clicks on the Add
        //     button.  This handler adds a fruit to the listbox if
        //     any additional fruit remain.
        // </desc>
        // </doc>
        //
        private void cmdAdd_Click(object sender, EventArgs e) {
            // If we still have some fruit that have not been
            // added to the checkedListBox1, run through the list
            // and add the first fruit that has not been added.
            if (checkedListBox1.Items.Count < fruits.Length) {
                bool stopLoop = false;
                bool found = false;
                int i = 0;
                while (stopLoop == false) {
                    found = false;
                    for (int j = 0; j < checkedListBox1.Items.Count; j++)
                        if (fruits[i].Equals((string)checkedListBox1.Items[j])) {
                            found = true;
                        }
                    if (found == false)
                        stopLoop = true;
                    else
                        i++;
                }
                checkedListBox1.Items.Add(fruits[i]);
            }
    
            // Make sure that the user can't attemp to add fruits
            // that don't exist.
            if (checkedListBox1.Items.Count == fruits.Length)
                cmdAdd.Enabled = false;
    
            if (checkedListBox1.Items.Count > 0)
                cmdRemove.Enabled = true;
        }
    
        // <doc>
        // <desc>
        //     Event that gets fired when the user clicks on the Remove button.
        //     This handler removes the selected fruit from the list.
        // </desc>
        // </doc>
        //
        private void cmdRemove_Click(object sender, EventArgs e) {
            if (checkedListBox1.SelectedIndex >= 0) {
                int index = checkedListBox1.SelectedIndex;
                checkedListBox1.Items.Remove(index);
    
                if (index > 0)
                    checkedListBox1.SelectedIndex = index - 1;
                else if (checkedListBox1.Items.Count != 0)
                    checkedListBox1.SelectedIndex = 0;
            }
    
            if (checkedListBox1.Items.Count== 0)
                cmdRemove.Enabled = false;
    
            if (checkedListBox1.Items.Count < fruits.Length)
                cmdAdd.Enabled = true;
        }
    
        // <doc>
        // <desc>
        //     Event that gets fired when the user clicks on the Reset button.
        // </desc>
        // </doc>
        //
        private void cmdReset_Click(object sender, EventArgs e ) {
            int nListItems = checkedListBox1.Items.Count;
            bool[] new_checked = new bool[fruits.Length];
            string item = "";
    
            for (int k = 0; k < fruits.Length; k++)
                new_checked[k] = false;
    
            int m = 0;
            for (int k = 0; k < nListItems; k++) {
                if (checkedListBox1.GetItemChecked(k)) {
                    item = (string) checkedListBox1.Items[k];
                    for (m = 0; m < fruits.Length; m++)
                        if (fruits[m].Equals(item))
                            new_checked[m] = true;
                }
            }
    
            checkedListBox1.Items.Clear();
    
            for (int j = 0; j < nListItems; j++) {
                checkedListBox1.Items.Add(fruits[j]);
                if (new_checked[j] == true)
                    checkedListBox1.SetItemChecked(j,true);
            }
    
            cmdReset.Enabled = false;
        }

    	
        // NOTE: The following code is required by the Windows Forms Designer
        // It can be modified using the Windows Forms Designer.  
        // Do not modify it using the code editor.
        private void InitializeComponent() {
		this.components = new System.ComponentModel.Container();
		this.chkMultiColumn = new System.WinForms.CheckBox();
		this.cmdRemove = new System.WinForms.Button();
		this.chkSorted = new System.WinForms.CheckBox();
		this.cmdReset = new System.WinForms.Button();
		this.chkThreeDCheckBoxes = new System.WinForms.CheckBox();
		this.groupBox1 = new System.WinForms.GroupBox();
		this.chkOnClick = new System.WinForms.CheckBox();
		this.chkIntegralHeight = new System.WinForms.CheckBox();
		this.cmdAdd = new System.WinForms.Button();
		this.checkedListBox1 = new System.WinForms.CheckedListBox();
		this.toolTip1 = new System.WinForms.ToolTip(components);
		
		chkMultiColumn.Location = new System.Drawing.Point(16, 72);
		chkMultiColumn.TabIndex = 2;
		chkMultiColumn.CheckState = System.WinForms.CheckState.Checked;
		chkMultiColumn.Text = "&MultiColumn";
		chkMultiColumn.Size = new System.Drawing.Size(104, 25);
		chkMultiColumn.Checked = true;
		chkMultiColumn.Click += new System.EventHandler(chkMultiColumn_Click);
		
		cmdRemove.Location = new System.Drawing.Point(96, 168);
		cmdRemove.TabIndex = 3;
		cmdRemove.Text = "&Remove";
		cmdRemove.Size = new System.Drawing.Size(75, 23);
		cmdRemove.Click += new System.EventHandler(cmdRemove_Click);
		
		chkSorted.Location = new System.Drawing.Point(16, 96);
		chkSorted.TabIndex = 3;
		chkSorted.Text = "&Sorted";
		chkSorted.Size = new System.Drawing.Size(136, 25);
		toolTip1.SetToolTip(chkSorted, "Controls whether the list is sorted.");
		chkSorted.Click += new System.EventHandler(chkSorted_Click);
		
		cmdReset.Location = new System.Drawing.Point(16, 200);
		cmdReset.TabIndex = 4;
		cmdReset.Enabled = false;
		cmdReset.Text = "&Reset";
		cmdReset.Size = new System.Drawing.Size(75, 23);
		cmdReset.Click += new System.EventHandler(cmdReset_Click);
		
		chkThreeDCheckBoxes.Location = new System.Drawing.Point(16, 24);
		chkThreeDCheckBoxes.TabIndex = 0;
		chkThreeDCheckBoxes.CheckState = System.WinForms.CheckState.Checked;
		chkThreeDCheckBoxes.Text = "T&hreeDCheckBoxes";
		chkThreeDCheckBoxes.Size = new System.Drawing.Size(136, 25);
		chkThreeDCheckBoxes.Checked = true;
		toolTip1.SetToolTip(chkThreeDCheckBoxes, "Indicates if the check values should be shown as flat or 3D checkmarks.");
		chkThreeDCheckBoxes.Click += new System.EventHandler(chkThreeDCheckBoxes_Click);
		
		groupBox1.Location = new System.Drawing.Point(248, 16);
		groupBox1.TabIndex = 0;
		groupBox1.TabStop = false;
		groupBox1.Text = "CheckedListBox";
		groupBox1.Size = new System.Drawing.Size(248, 264);
		
		chkOnClick.Location = new System.Drawing.Point(16, 120);
		chkOnClick.TabIndex = 4;
		chkOnClick.CheckState = System.WinForms.CheckState.Checked;
		chkOnClick.Text = "&CheckOnClick";
		chkOnClick.Size = new System.Drawing.Size(136, 25);
		chkOnClick.Checked = true;
		toolTip1.SetToolTip(chkOnClick, "Indicates whether the check box should be toggled on the first click on an item.");
		chkOnClick.Click += new EventHandler(chkOnClick_Click);
		
		chkIntegralHeight.Location = new System.Drawing.Point(16, 48);
		chkIntegralHeight.TabIndex = 1;
		chkIntegralHeight.CheckState = System.WinForms.CheckState.Checked;
		chkIntegralHeight.Text = "&IntegralHeight";
		chkIntegralHeight.Size = new System.Drawing.Size(120, 25);
		chkIntegralHeight.Checked = true;
		chkIntegralHeight.Click += new EventHandler(chkIntegralHeight_Click);
		
		cmdAdd.Location = new System.Drawing.Point(16, 168);
		cmdAdd.TabIndex = 2;
		cmdAdd.Text = "&Add";
		cmdAdd.Size = new System.Drawing.Size(75, 23);
		cmdAdd.Click += new EventHandler(cmdAdd_Click);
		
		checkedListBox1.ThreeDCheckBoxes = true;
		checkedListBox1.IntegralHeight = false;
		checkedListBox1.TabIndex = 1;
		checkedListBox1.CheckOnClick = true;
		checkedListBox1.ColumnWidth = 100;
		checkedListBox1.MultiColumn = true;
		checkedListBox1.Size = new System.Drawing.Size(232, 84);
		checkedListBox1.Location = new System.Drawing.Point(8, 24);
		checkedListBox1.Text = "checkedListBox1";
		
		toolTip1.Active = true;
		//@design toolTip1.SetLocation(new System.Drawing.Point(10, 10));
		
		this.Text = "Checked ListBox";
		this.TabIndex = 0;
		this.Size = new System.Drawing.Size(512, 320);
		
		this.Controls.Add(groupBox1);
		this.Controls.Add(cmdAdd);
		this.Controls.Add(cmdRemove);
		this.Controls.Add(cmdReset);
		this.Controls.Add(checkedListBox1);
		groupBox1.Controls.Add(chkOnClick);
		groupBox1.Controls.Add(chkIntegralHeight);
		groupBox1.Controls.Add(chkMultiColumn);
		groupBox1.Controls.Add(chkThreeDCheckBoxes);
		groupBox1.Controls.Add(chkSorted);
		
	}

        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new CheckedListBoxCtl());
        }

    }

}




