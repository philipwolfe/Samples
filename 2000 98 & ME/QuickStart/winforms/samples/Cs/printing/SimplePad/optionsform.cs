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
namespace Microsoft.Samples.WinForms.Cs.SimplePad {
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.WinForms;


    public class OptionsForm : Form {
        private System.ComponentModel.Container components;
        private Button okButton;
        private PropertyGrid grid;
        private object customizer;

        public OptionsForm(object customizer) {
            InitializeComponent();

            this.customizer = customizer;
            grid.SelectedObject = customizer;
        }

        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.okButton = new Button();
            this.grid = new PropertyGrid();

            this.AutoScaleBaseSize = new Size(5, 13);
            this.Text = "Notepad+ Options";
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.CancelButton = okButton;
            this.Icon = null;
            this.AcceptButton = okButton;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(328, 325);

            okButton.Location = new Point(232, 297);
            okButton.DialogResult = DialogResult.OK;
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 0;
            okButton.Anchor = AnchorStyles.BottomRight;
            okButton.Text = "OK";

            grid.Location = new Point(8, 8);
            grid.Text = "PropertyGrid";
            grid.Size = new Size(312, 281);
            grid.CommandsVisibleIfAvailable = true;
            grid.ActiveDocument = null;
            grid.TabIndex = 1;
            grid.AutoScrollMinSize = new Size(0, 0);
            grid.Anchor = AnchorStyles.All;
            grid.ToolbarVisible = false;

            this.Controls.Add(okButton);
            this.Controls.Add(grid);
        }

    }
}