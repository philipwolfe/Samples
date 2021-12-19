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
namespace Microsoft.Samples.WinForms.Cs.ComboBoxCtl {
    using System;
    using System.ComponentModel;
    using System.Collections;
    using System.WinForms;
    using System.Resources;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    // <doc>
    // <desc>
    //     This sample demonstrates the properties and features
    //     of the ComboBox control.
    //     The sample also shows two different ways to use a ComboBox which does
    //     not contain String data.  The first method uses a Hashtable which maps
    //     strings to the data and the second method uses a wrapper object which
    //     exposes a toString() method used by the ComboBox.
    // </desc>
    // </doc>
    //
    public class ComboBoxCtl : System.WinForms.Form {
        private System.ComponentModel.Container components;
    
	
	private System.WinForms.Label label6; 
        private System.WinForms.ComboBox comboBegin;
   	
        private System.WinForms.Label label7; 
	private System.WinForms.ComboBox comboEnd;

	private System.WinForms.CheckBox chkEnabled;
        private System.WinForms.CheckBox chkSorted;
        private System.WinForms.CheckBox chkIntegralHeight;

        private System.WinForms.GroupBox groupBox1;

        private System.WinForms.Label label1;
        private System.WinForms.ComboBox cmbStyle;

	private System.WinForms.Label label2;
        private System.WinForms.ComboBox cmbDrawMode;
	
        private System.WinForms.Label label3;
        private System.WinForms.ComboBox cmbItemHeight;        

	private System.WinForms.Label label4;
        private System.WinForms.ComboBox cmbMaxDropDownItems;
               
        private System.WinForms.Label label5; 
        private System.WinForms.Label label9; 
        private System.WinForms.Panel panel1;
        
        private System.WinForms.ToolTip toolTip1;
    
        private Size      cmbsize ;
        private Hashtable colorMap = new Hashtable();
        private Color     gradientBegin = Color.Red;
        private Color     gradientEnd = Color.Blue;

        // <doc>
        // <desc>
        //     We speed up ownerdraw operations on the Color ComboBoxes
        //     by caching the Brush objects which represent the Color
        //     to choose.
        // </desc>
        // <seealso class='ComboBoxCtl.GetTheBrush()'/>
        // </doc>
        //
        private Hashtable brushMap = new Hashtable();

        // <doc>
        // <desc>
        //     Public Constructor
        // </desc>
        // </doc>
        //
        public ComboBoxCtl () : base() {
             	
            // This call is required for support of the Windows Forms Form Designer.
            InitializeComponent();

            InitControlState();
            MakeColorMap();
            FillItems(comboBegin);
            comboBegin.SelectedIndex = 0;
            FillItems(comboEnd);
            comboEnd.SelectedIndex = comboEnd.Items.Count-1;
            cmbsize = comboBegin.Size;
        }

        // <doc>
        // <desc>
        //     This class defines the objects in the ComboBoxes that drive
        //     the properties of the color selection ComboBoxes.
        //     Use this object to use erations with ComboBoxes and ListBoxes.
        //     Add the <paramref term='s'/> data member to the eration item's
        //     english description and the <paramref term='i'/> data member to the actual
        //     value of the eration item.
        //     The ToString() method will allow the ComboBox and ListBox controls to 
        //     display the text which represents the eration item.
        // </desc>
        // </doc>
        //
        private class StringIntObject {
            public string s;
            public int i;

            public StringIntObject(string sz, int n) {
                s=sz;
                i=n;
            }

            public override string ToString() {
                return s;
            }
        }

        // <doc>
        // <desc>
        //     Sets the default states for the controls driving the properties
        //     of the two ComboBoxes.
        // </desc>
        // </doc>
        //
        private void InitControlState() {
            // Sync the checkboxes
            chkSorted.Checked = comboBegin.Sorted;
            chkEnabled.Checked = comboBegin.Enabled;
            chkIntegralHeight.Checked = comboBegin.IntegralHeight;

            // Sync ComboBox styles to ComboBoxStyle.DROPDOWN
            StringIntObject[] aStyle = new StringIntObject[3];
            aStyle[0] = new StringIntObject("Simple",(int)ComboBoxStyle.Simple);
            aStyle[1] = new StringIntObject("Dropdown",(int)ComboBoxStyle.DropDown);
            aStyle[2] = new StringIntObject("Dropdownlist",(int)ComboBoxStyle.DropDownList);
            cmbStyle.Items.All = aStyle;
            comboBegin.Style = (ComboBoxStyle)aStyle[1].i;
            comboEnd.Style = (ComboBoxStyle)aStyle[1].i;
            cmbStyle.SelectedIndex = 1;

            // Sync ComboBox draw modes to DrawMode.NORMAL
            StringIntObject[] aDMO = new StringIntObject[3];
            aDMO[0] = new StringIntObject("Normal",(int)DrawMode.Normal);
            aDMO[1] = new StringIntObject("Ownerdrawfixed",(int)DrawMode.OwnerDrawFixed);
            aDMO[2] = new StringIntObject("Ownerdrawvariable",(int)DrawMode.OwnerDrawVariable);
            cmbDrawMode.Items.All = aDMO;
            comboBegin.DrawMode = (DrawMode)aDMO[0].i;
            comboEnd.DrawMode = (DrawMode)aDMO[0].i;
            cmbDrawMode.SelectedIndex = 0;
        }

        private void FillItems(ComboBox cmb) {
            IEnumerator keys = colorMap.Keys.GetEnumerator();
            while (keys.MoveNext()) {
                cmb.Items.Add(keys.Current);
            }
        }

        private void MakeColorMap() {
            colorMap["Aqua"] = Color.Aqua;
            colorMap["Black"] = Color.Black;
            colorMap["Blue"] = Color.Blue;
            colorMap["Brown"] = Color.Brown;
            colorMap["Cyan"] = Color.Cyan;
            colorMap["Dark Gray"] = Color.DarkGray;
            colorMap["Gray"] = Color.Gray;
            colorMap["Green"] = Color.Green;
            colorMap["Light Gray"] = Color.LightGray;
            colorMap["Magenta"] = Color.Magenta;
            colorMap["Orange"] = Color.Orange;
            colorMap["Purple"] = Color.Purple;
            colorMap["Red"] = Color.Red;
            colorMap["White"] = Color.White;
            colorMap["Yellow"] = Color.Yellow;
        }

        // <doc>
        // <desc>
        //     ComboBoxCtl overrides dispose so it can clean up the
        //     component list.
        // </desc>
        // </doc>
        //
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        // <doc>
        // <desc>
        //     Returns the int which is currently selected in a ComboBox.
        // </desc>
        // <param term='cmb'>
        //     The ComboBox to get the integral value from
        // </param>
        // <retvalue>
        //     If the String is in a valid numeric format, the integer
        //     representation of it is returned.  Otherwise, if
        //     no item is selected <it>or</it> the selected item is
        //     not a valid int, -1 is returned.
        // </retvalue>
        // </doc>
        //
        protected int SelectedValue(ComboBox cmb) {
            int ret;
            object obj = cmb.SelectedItem;
            if (obj == null) {
                return -1;
            }
            try {
                ret = Int32.FromString(obj.ToString());
            }
            catch (FormatException) {
                return -1;
            }
            return ret;
        }
	
        protected void chkEnabled_Click(object sender, EventArgs e) {
            comboBegin.Enabled = chkEnabled.Checked;
            comboEnd.Enabled = chkEnabled.Checked;
        }

  	protected void chkIntegralHeight_Click(object sender, EventArgs e) {
            comboBegin.IntegralHeight = chkIntegralHeight.Checked;
            comboEnd.IntegralHeight = chkIntegralHeight.Checked;
        }

        protected void chkSorted_Click(object sender, EventArgs e) {
            bool sorted = chkSorted.Checked;
            comboBegin.Sorted = sorted;
            comboEnd.Sorted = sorted;
            if (!sorted) {
                RandomShuffle(comboBegin);
                RandomShuffle(comboEnd);
            }
        }

        // <doc>
        // <desc>
        //     Performs a random shuffle on the given ComboBox.
        // </desc>
        // <param term='cmb'>
        //     The ComboBox to shuffle
        // </param>
        // </doc>
        //
        private void RandomShuffle(ComboBox cmb) {
            object [] items = cmb.Items.All;
            int swapItem;
            Random rand = new Random();
            for (int i = 0; i < items.Length; ++i) {
                swapItem = Math.Abs(rand.Next()) % items.Length;
                if (swapItem != i) {
                    object tempObject = items[swapItem];
                    items[swapItem] = items[i];
                    items[i] = tempObject;
                }
            }
            cmb.Items.All = items;
        }

        protected void cmbItemHeight_SelectedIndexChanged(object sender, EventArgs e) {
            int i = SelectedValue(cmbItemHeight);
            if (i == -1)
                return;
            comboBegin.ItemHeight = i;
            comboEnd.ItemHeight = i;
        }

        protected void cmbStyle_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBoxStyle i = (ComboBoxStyle)(((StringIntObject)cmbStyle.SelectedItem).i);
            comboBegin.Style = i;
            comboEnd.Style = i;

            if (i == ComboBoxStyle.Simple) {
                comboBegin.SetSize(cmbsize.Width, cmbsize.Height * 3);
                comboEnd.SetSize(cmbsize.Width, cmbsize.Height * 3);
                cmbMaxDropDownItems.Enabled = false;
            }
	    else
		cmbMaxDropDownItems.Enabled = true;
        }

        protected void cmbDrawMode_SelectedIndexChanged(object sender, EventArgs e) {
            DrawMode i = (DrawMode)(((StringIntObject)cmbDrawMode.SelectedItem).i);
            comboBegin.DrawMode = i;
            comboEnd.DrawMode = i;

            if (i == DrawMode.OwnerDrawVariable) {
                cmbItemHeight.Enabled = true;
            }
            else {
                cmbItemHeight.Enabled = false;
            }
        }

        // <doc>
        // <desc>
        //     This DrawItem event handler is invoked to draw an item in a ComboBox if that
        //     ComboBox is in an OwnerDraw DrawMode.
        // </desc>
        // </doc>
        //
        protected void combo_DrawItem(object sender, DrawItemEventArgs die) {
            ComboBox cmb = (ComboBox) sender;
            if (die.Index == -1)
                return;
            if (sender == null)
                return;


            string strColor = (string)cmb.Items[die.Index];
            Color clrSelected = (Color)colorMap[strColor];
            Graphics g = die.Graphics;

            // If the item is selected, this draws the correct background color
            die.DrawBackground();
            die.DrawFocusRectangle();

            // Draw the color's preview box
            Rectangle rectPreviewBox = die.Bounds;
            rectPreviewBox.Offset(2,2);
            rectPreviewBox.Width = 20;
            rectPreviewBox.Height -= 4;
            g.DrawRectangle(new Pen(die.ForeColor), rectPreviewBox);

            /*
             * Get the appropriate Brush object for the selected color
             * and fill the preview box.
             */
            Brush coloredBrush = GetTheBrush(clrSelected);
            rectPreviewBox.Offset(1,1);
            rectPreviewBox.Width -= 2;
            rectPreviewBox.Height -= 2;
            g.FillRectangle(coloredBrush, rectPreviewBox);

            // Draw the name of the color selected
            g.DrawString(strColor, Font, new SolidBrush(die.ForeColor), die.Bounds.X+30,die.Bounds.Y+1);

            g.Dispose();
        }

        // <doc>
        // <desc>
        //     Retrieves a Brush object which corresponds to <em>clr</em>
        //     Brushes created are cached for performance.
        // </desc>
        // <param term='clr'>
        //     The Color which the returned Brush will paint
        // </param>
        // <retvalue>
        //     A Brush object which corresponds to <em>clr</em>
        //     Treat this object as read-only.
        // </retvalue>
        // </doc>
        //
        private Brush GetTheBrush(Color clr) {
            if (clr.IsEmpty)
                throw new ArgumentException();
            object ret = brushMap[clr];
            if (ret == null) {
                Brush clrBrush = new SolidBrush(clr);
                brushMap.Add(clr,clrBrush);
                return clrBrush;
            }
            else {
                return(Brush)ret;
            }
        }

        protected void comboBegin_SelectedIndexChanged(object sender, EventArgs e) {
            Color c = (Color)colorMap[comboBegin.SelectedItem];
            gradientBegin = c;
            panel1.Invalidate();
        }

        protected void comboEnd_SelectedIndexChanged(object sender, EventArgs e) {
            Color c = (Color)colorMap[comboEnd.SelectedItem];
            gradientEnd = c;
            panel1.Invalidate();
        }

        protected void cmbMaxDropDownItems_SelectedIndexChanged(object sender, EventArgs e) {
            int i = SelectedValue(cmbMaxDropDownItems);
            if (i == -1)
                return;
            comboBegin.MaxDropDownItems = i;
            comboEnd.MaxDropDownItems = i;
        }

        private void combo_MeasureItem(object sender, MeasureItemEventArgs mie) {
	    ComboBox cb = (ComboBox) sender;
            mie.ItemHeight = cb.ItemHeight - 2;
        }

        protected void panel1_Paint(object sender, PaintEventArgs e) {
            Brush brush = new LinearGradientBrush (panel1.ClientRectangle, gradientBegin, gradientEnd,LinearGradientMode.ForwardDiagonal) ;
            e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
        }

        //protected void combo_KeyPress(object sender, KeyPressEventArgs e) {
        //    if (Char.IsLetterOrDigit(e.KeyChar))
        //        e.Handled = true;
        //}


        // NOTE: The following code is required by the Windows Forms Form Designer
        // It can be modified using the Windows Forms Form Designer.  
        // Do not modify it using the code editor.
        private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.cmbDrawMode = new System.WinForms.ComboBox();
		this.chkEnabled = new System.WinForms.CheckBox();
		this.groupBox1 = new System.WinForms.GroupBox();
		this.cmbMaxDropDownItems = new System.WinForms.ComboBox();
		this.toolTip1 = new System.WinForms.ToolTip(components);
		this.chkSorted = new System.WinForms.CheckBox();
		this.chkIntegralHeight = new System.WinForms.CheckBox();
		this.comboEnd = new System.WinForms.ComboBox();
		this.cmbItemHeight = new System.WinForms.ComboBox();
		this.cmbStyle = new System.WinForms.ComboBox();
		this.label6 = new System.WinForms.Label();
		this.comboBegin = new System.WinForms.ComboBox();
		this.label5 = new System.WinForms.Label();
		this.label9 = new System.WinForms.Label();
		this.label4 = new System.WinForms.Label();
		this.label3 = new System.WinForms.Label();
		this.label7 = new System.WinForms.Label();
		this.label2 = new System.WinForms.Label();
		this.panel1 = new System.WinForms.Panel();
		this.label1 = new System.WinForms.Label();
		
		//@design this.TrayHeight = 90;
		//@design this.TrayLargeIcon = false;
		//@design this.TrayAutoArrange = true;
		this.Text = "ComboBox";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(504, 293);
		
		cmbDrawMode.Location = new System.Drawing.Point(128, 120);
		cmbDrawMode.Size = new System.Drawing.Size(104, 21);
		cmbDrawMode.Style = System.WinForms.ComboBoxStyle.DropDownList;
		toolTip1.SetToolTip(cmbDrawMode, "Controls ComboBox painting");
		cmbDrawMode.TabIndex = 5;
		cmbDrawMode.SelectedIndexChanged += new System.EventHandler(cmbDrawMode_SelectedIndexChanged);
		
		chkEnabled.Location = new System.Drawing.Point(16, 24);
		chkEnabled.Text = "Enabled";
		chkEnabled.Size = new System.Drawing.Size(88, 16);
		toolTip1.SetToolTip(chkEnabled, "Sets a Boolean value determining whether the ComboBox is cli" + 
			"ckable");
		chkEnabled.TabIndex = 0;
		chkEnabled.Click += new System.EventHandler(chkEnabled_Click);
		
		groupBox1.Location = new System.Drawing.Point(248, 16);
		groupBox1.TabIndex = 2;
		groupBox1.TabStop = false;
		groupBox1.Text = "ComboBox";
		groupBox1.Size = new System.Drawing.Size(248, 264);
		
		cmbMaxDropDownItems.Location = new System.Drawing.Point(128, 168);
		cmbMaxDropDownItems.Size = new System.Drawing.Size(104, 21);
		cmbMaxDropDownItems.Style = System.WinForms.ComboBoxStyle.DropDownList;
		toolTip1.SetToolTip(cmbMaxDropDownItems, "The number of items to display on dropdown");
		cmbMaxDropDownItems.TabIndex = 7;
		cmbMaxDropDownItems.SelectedIndexChanged += new System.EventHandler(cmbMaxDropDownItems_SelectedIndexChanged);
		cmbMaxDropDownItems.Items.All = new object[] {"2",
			"4",
			"6",
			"8",
			"10"};
		
		//@design toolTip1.SetLocation(new System.Drawing.Point(7, 7));
		toolTip1.Active = true;
		
		chkSorted.Location = new System.Drawing.Point(16, 48);
		chkSorted.Text = "Sorted";
		chkSorted.Size = new System.Drawing.Size(88, 16);
		toolTip1.SetToolTip(chkSorted, "Sets whether the items in the ComboBoxes\nshould be sorted a" + 
			"lphabetically");
		chkSorted.TabIndex = 1;
		chkSorted.Click += new System.EventHandler(chkSorted_Click);
		
		chkIntegralHeight.Location = new System.Drawing.Point(16, 72);
		chkIntegralHeight.Text = "IntegralHeight";
		chkIntegralHeight.Size = new System.Drawing.Size(104, 16);
		toolTip1.SetToolTip(chkIntegralHeight, "Sets a boolean value indicating\nwhether the combo box shoul" + 
			"d resize\nto avoid showing partial items");
		chkIntegralHeight.TabIndex = 2;
		chkIntegralHeight.Click += new System.EventHandler(chkIntegralHeight_Click);
		
		comboEnd.Text = "comboBegin1";
		comboEnd.Location = new System.Drawing.Point(24, 120);
		comboEnd.Size = new System.Drawing.Size(208, 21);
		toolTip1.SetToolTip(comboEnd, "Choose the color for the right end of gradient");
		comboEnd.TabIndex = 1;
		comboEnd.Sorted = true;
		comboEnd.MeasureItem += new System.WinForms.MeasureItemEventHandler(combo_MeasureItem);
		comboEnd.DrawItem += new System.WinForms.DrawItemEventHandler(combo_DrawItem);
		comboEnd.SelectedIndexChanged += new System.EventHandler(comboEnd_SelectedIndexChanged);
		
		cmbItemHeight.Location = new System.Drawing.Point(128, 144);
		cmbItemHeight.Size = new System.Drawing.Size(104, 21);
		cmbItemHeight.Style = System.WinForms.ComboBoxStyle.DropDownList;
		toolTip1.SetToolTip(cmbItemHeight, "The height, in pixels, of an item in the combo box");
		cmbItemHeight.TabIndex = 6;
		cmbItemHeight.SelectedIndexChanged += new System.EventHandler(cmbItemHeight_SelectedIndexChanged);
		cmbItemHeight.Items.All = new object[] {"12",
			"14",
			"16",
			"18",
			"24",
			"26"};
		
		cmbStyle.Location = new System.Drawing.Point(128, 96);
		cmbStyle.Size = new System.Drawing.Size(104, 21);
		cmbStyle.Style = System.WinForms.ComboBoxStyle.DropDownList;
		toolTip1.SetToolTip(cmbStyle, "Controls the appearance and functionality of the ComboBox");
		cmbStyle.TabIndex = 4;
		cmbStyle.SelectedIndexChanged += new System.EventHandler(cmbStyle_SelectedIndexChanged);
		
		label6.Location = new System.Drawing.Point(24, 16);
		label6.Text = "Left:";
		label6.Size = new System.Drawing.Size(96, 16);
		label6.TabIndex = 5;
		
		comboBegin.Text = "comboBegin1";
		comboBegin.Location = new System.Drawing.Point(24, 32);
		comboBegin.Size = new System.Drawing.Size(208, 21);
		toolTip1.SetToolTip(comboBegin, "Choose color for left end of gradient");
		comboBegin.TabIndex = 0;
		comboBegin.Sorted = true;
		comboBegin.MeasureItem += new System.WinForms.MeasureItemEventHandler(combo_MeasureItem);
		comboBegin.DrawItem += new System.WinForms.DrawItemEventHandler(combo_DrawItem);
		comboBegin.SelectedIndexChanged += new System.EventHandler(comboBegin_SelectedIndexChanged);
		
		label5.Location = new System.Drawing.Point(16, 208);
		label5.Text = "Left";
		label5.Size = new System.Drawing.Size(64, 16);
		label5.TabIndex = 12;
		
		label9.Location = new System.Drawing.Point(200, 208);
		label9.Text = "Right";
		label9.Size = new System.Drawing.Size(32, 16);
		label9.TabIndex = 14;
		
		label4.Location = new System.Drawing.Point(16, 176);
		label4.Text = "MaxDropdownItems";
		label4.Size = new System.Drawing.Size(104, 16);
		label4.TabIndex = 11;
		
		label3.Location = new System.Drawing.Point(16, 152);
		label3.Text = "ItemHeight";
		label3.Size = new System.Drawing.Size(80, 16);
		label3.TabIndex = 10;
		
		label7.Location = new System.Drawing.Point(24, 104);
		label7.Text = "Right:";
		label7.Size = new System.Drawing.Size(96, 16);
		label7.TabIndex = 3;
		
		label2.Location = new System.Drawing.Point(16, 128);
		label2.Text = "DrawMode";
		label2.Size = new System.Drawing.Size(88, 16);
		label2.TabIndex = 9;
		
		panel1.Location = new System.Drawing.Point(16, 224);
		panel1.Text = "panel1";
		panel1.Size = new System.Drawing.Size(216, 24);
		panel1.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		panel1.TabIndex = 3;
		panel1.Paint += new System.WinForms.PaintEventHandler(panel1_Paint);
		
		label1.Location = new System.Drawing.Point(16, 104);
		label1.Text = "Style";
		label1.Size = new System.Drawing.Size(88, 16);
		label1.TabIndex = 8;
		this.Controls.Add(label7);
		this.Controls.Add(label6);
		this.Controls.Add(comboEnd);
		this.Controls.Add(comboBegin);
		this.Controls.Add(groupBox1);
		groupBox1.Controls.Add(panel1);
		groupBox1.Controls.Add(label9);
		groupBox1.Controls.Add(label5);
		groupBox1.Controls.Add(cmbStyle);
		groupBox1.Controls.Add(cmbDrawMode);
		groupBox1.Controls.Add(cmbItemHeight);
		groupBox1.Controls.Add(cmbMaxDropDownItems);
		groupBox1.Controls.Add(label4);
		groupBox1.Controls.Add(label3);
		groupBox1.Controls.Add(label2);
		groupBox1.Controls.Add(label1);
		groupBox1.Controls.Add(chkIntegralHeight);
		groupBox1.Controls.Add(chkSorted);
		groupBox1.Controls.Add(chkEnabled);
	}
 
  
        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new ComboBoxCtl());
        }

    }

}


