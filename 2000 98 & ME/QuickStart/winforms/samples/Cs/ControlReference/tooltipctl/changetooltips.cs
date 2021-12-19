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
namespace Microsoft.Samples.WinForms.Cs.ToolTipCtl {

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using System.Diagnostics;
   

    public class ChangeToolTips : System.WinForms.Form {
        internal ImageList imgList;
        internal string[] toolTips;

        public ChangeToolTips(ImageList smlImageList, string[] toolTips) : base() {

            //
            // Required for Win Form Designer support
            //
            InitForm();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.imgList = smlImageList;
            this.toolTips = toolTips;
            listView1.SmallImageList = smlImageList;
            SetToolTipRows();
        }

        private void SetToolTipRows() {
            Debug.Assert(imgList.Images.Count == toolTips.Length,
                         "Incorrect number of images or tooltips");

            listView1.Columns.Add("ToolTip Text", listView1.Size.Width - 5,
                                  HorizontalAlignment.Left);
            for (int i = 0; i < toolTips.Length; i++) {
                ListItem item = new ListItem(toolTips[i],i);
                listView1.ListItems.Add(item);
            }
        }

        public virtual string[] GetToolTips() {
            return toolTips;
        }

        /// <summary>
        ///    Clean up any resources being used
        /// </summary>
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void ListView1_afterLabelEdit(object source, LabelEditEventArgs e) {
            if (e.Label == null) {
                e.CancelEdit = true;
                return;
            }
            toolTips[e.Item] = e.Label;
        }

        internal System.ComponentModel.Container components = new Container();
        internal System.WinForms.Button btnOk = new Button();
        internal System.WinForms.Button btnCancel = new Button();
        internal System.WinForms.ListView listView1 = new ListView();
        internal System.WinForms.Label label1 = new Label();

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor
        /// </summary>
        private void InitForm() {
            this.Text = "ChangeToolTips";
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BorderStyle = System.WinForms.FormBorderStyle.FixedDialog;
            this.ClientSize = new System.Drawing.Size(302, 302);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;

            btnOk.Location = new System.Drawing.Point(16, 272);
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "&Ok";
            btnOk.DialogResult = System.WinForms.DialogResult.OK;

            btnCancel.Location = new System.Drawing.Point(104, 272);
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "&Cancel";
            btnCancel.DialogResult = System.WinForms.DialogResult.Cancel;

            listView1.Location = new System.Drawing.Point(16, 48);
            listView1.Size = new System.Drawing.Size(272, 192);
            listView1.TabIndex = 0;
            listView1.Text = "listView1";
            listView1.HeaderStyle = System.WinForms.ColumnHeaderStyle.Nonclickable;
            listView1.LabelEdit = true;
            listView1.MultiSelect = false;
            listView1.View = System.WinForms.View.Report;
            listView1.AfterLabelEdit += new LabelEditEventHandler(this.ListView1_afterLabelEdit);

            label1.Location = new System.Drawing.Point(16, 8);
            label1.Size = new System.Drawing.Size(272, 24);
            label1.TabIndex = 3;
            label1.TabStop = false;
            label1.Text = "To change the text for a tooltip, click or press enter on a selected label.";

            this.SetNewControls(new Control[] {
                                    label1,
                                    listView1,
                                    btnCancel,
                                    btnOk});
        }
    }
}