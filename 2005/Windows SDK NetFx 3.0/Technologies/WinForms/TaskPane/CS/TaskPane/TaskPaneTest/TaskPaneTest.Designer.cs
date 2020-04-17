
namespace Microsoft.Samples.Windows.Forms.TaskPaneTest
{
    partial class TaskPaneTest
    {
        [System.Diagnostics.DebuggerNonUserCode]
        public TaskPaneTest() : base()
        {        

            //This call is required by the Windows Form Designer.
            InitializeComponent();

        }

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components = null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPaneTest));
            this.testPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cornerStyleGroup = new System.Windows.Forms.GroupBox();
            this.squaredCornerStyleRadio = new System.Windows.Forms.RadioButton();
            this.roundedCornerStyleRadio = new System.Windows.Forms.RadioButton();
            this.sysDefCornerStyleRadio = new System.Windows.Forms.RadioButton();
            this.dockGroup = new System.Windows.Forms.GroupBox();
            this.rightDockRadio = new System.Windows.Forms.RadioButton();
            this.bottomDockRadio = new System.Windows.Forms.RadioButton();
            this.topDockRadio = new System.Windows.Forms.RadioButton();
            this.leftDockRadio = new System.Windows.Forms.RadioButton();
            this.expandAndCollapseFramesButton = new System.Windows.Forms.Button();
            this.addAndRemoveButton = new System.Windows.Forms.Button();
            this.TaskPane1 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskPane();
            this.TaskFrame0 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.TaskFrame1 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.TaskFrame2 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.LinkLabel4 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel3 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.hiddenTaskFrame = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.testPanel.SuspendLayout();
            this.cornerStyleGroup.SuspendLayout();
            this.dockGroup.SuspendLayout();
            this.TaskPane1.SuspendLayout();
            this.TaskFrame2.SuspendLayout();
            this.SuspendLayout();
            // 
            // testPanel
            // 
            this.testPanel.Controls.Add(this.label1);
            this.testPanel.Controls.Add(this.cornerStyleGroup);
            this.testPanel.Controls.Add(this.dockGroup);
            this.testPanel.Controls.Add(this.expandAndCollapseFramesButton);
            this.testPanel.Controls.Add(this.addAndRemoveButton);
            this.testPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.testPanel.Location = new System.Drawing.Point(224, 0);
            this.testPanel.Name = "testPanel";
            this.testPanel.Size = new System.Drawing.Size(342, 440);
            this.testPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 156);
            this.label1.TabIndex = 11;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // cornerStyleGroup
            // 
            this.cornerStyleGroup.Controls.Add(this.squaredCornerStyleRadio);
            this.cornerStyleGroup.Controls.Add(this.roundedCornerStyleRadio);
            this.cornerStyleGroup.Controls.Add(this.sysDefCornerStyleRadio);
            this.cornerStyleGroup.Location = new System.Drawing.Point(7, 13);
            this.cornerStyleGroup.Name = "cornerStyleGroup";
            this.cornerStyleGroup.Size = new System.Drawing.Size(135, 92);
            this.cornerStyleGroup.TabIndex = 0;
            this.cornerStyleGroup.TabStop = false;
            this.cornerStyleGroup.Text = "Corner Style";
            // 
            // squaredCornerStyleRadio
            // 
            this.squaredCornerStyleRadio.AutoSize = true;
            this.squaredCornerStyleRadio.Location = new System.Drawing.Point(7, 68);
            this.squaredCornerStyleRadio.Name = "squaredCornerStyleRadio";
            this.squaredCornerStyleRadio.Size = new System.Drawing.Size(65, 17);
            this.squaredCornerStyleRadio.TabIndex = 2;
            this.squaredCornerStyleRadio.Text = "S&quared";
            this.squaredCornerStyleRadio.CheckedChanged += new System.EventHandler(this.squaredCornerStyleRadio_CheckedChanged);
            // 
            // roundedCornerStyleRadio
            // 
            this.roundedCornerStyleRadio.AutoSize = true;
            this.roundedCornerStyleRadio.Location = new System.Drawing.Point(7, 44);
            this.roundedCornerStyleRadio.Name = "roundedCornerStyleRadio";
            this.roundedCornerStyleRadio.Size = new System.Drawing.Size(69, 17);
            this.roundedCornerStyleRadio.TabIndex = 1;
            this.roundedCornerStyleRadio.Text = "Rou&nded";
            this.roundedCornerStyleRadio.Click += new System.EventHandler(this.roundedCornerStyleRadio_CheckedChanged);
            // 
            // sysDefCornerStyleRadio
            // 
            this.sysDefCornerStyleRadio.AutoSize = true;
            this.sysDefCornerStyleRadio.Checked = true;
            this.sysDefCornerStyleRadio.Location = new System.Drawing.Point(7, 20);
            this.sysDefCornerStyleRadio.Name = "sysDefCornerStyleRadio";
            this.sysDefCornerStyleRadio.Size = new System.Drawing.Size(96, 17);
            this.sysDefCornerStyleRadio.TabIndex = 0;
            this.sysDefCornerStyleRadio.Text = "&System Default";
            this.sysDefCornerStyleRadio.Click += new System.EventHandler(this.sysDefCornerStyleRadio_CheckedChanged);
            // 
            // dockGroup
            // 
            this.dockGroup.Controls.Add(this.rightDockRadio);
            this.dockGroup.Controls.Add(this.bottomDockRadio);
            this.dockGroup.Controls.Add(this.topDockRadio);
            this.dockGroup.Controls.Add(this.leftDockRadio);
            this.dockGroup.Location = new System.Drawing.Point(149, 13);
            this.dockGroup.Name = "dockGroup";
            this.dockGroup.Size = new System.Drawing.Size(174, 92);
            this.dockGroup.TabIndex = 1;
            this.dockGroup.TabStop = false;
            this.dockGroup.Text = "Dock";
            // 
            // rightDockRadio
            // 
            this.rightDockRadio.AutoSize = true;
            this.rightDockRadio.Location = new System.Drawing.Point(86, 20);
            this.rightDockRadio.Name = "rightDockRadio";
            this.rightDockRadio.Size = new System.Drawing.Size(50, 17);
            this.rightDockRadio.TabIndex = 1;
            this.rightDockRadio.Text = "&Right";
            this.rightDockRadio.CheckedChanged += new System.EventHandler(this.rightDockRadio_CheckedChanged);
            // 
            // bottomDockRadio
            // 
            this.bottomDockRadio.AutoSize = true;
            this.bottomDockRadio.Location = new System.Drawing.Point(86, 43);
            this.bottomDockRadio.Name = "bottomDockRadio";
            this.bottomDockRadio.Size = new System.Drawing.Size(58, 17);
            this.bottomDockRadio.TabIndex = 3;
            this.bottomDockRadio.Text = "&Bottom";
            this.bottomDockRadio.CheckedChanged += new System.EventHandler(this.bottomDockRadio_CheckedChanged);
            // 
            // topDockRadio
            // 
            this.topDockRadio.AutoSize = true;
            this.topDockRadio.Location = new System.Drawing.Point(7, 44);
            this.topDockRadio.Name = "topDockRadio";
            this.topDockRadio.Size = new System.Drawing.Size(44, 17);
            this.topDockRadio.TabIndex = 2;
            this.topDockRadio.Text = "To&p";
            this.topDockRadio.CheckedChanged += new System.EventHandler(this.topDockRadio_CheckedChanged);
            // 
            // leftDockRadio
            // 
            this.leftDockRadio.AutoSize = true;
            this.leftDockRadio.Checked = true;
            this.leftDockRadio.Location = new System.Drawing.Point(7, 20);
            this.leftDockRadio.Name = "leftDockRadio";
            this.leftDockRadio.Size = new System.Drawing.Size(43, 17);
            this.leftDockRadio.TabIndex = 0;
            this.leftDockRadio.Text = "&Left";
            this.leftDockRadio.CheckedChanged += new System.EventHandler(this.leftDockRadio_CheckedChanged);
            // 
            // expandAndCollapseFramesButton
            // 
            this.expandAndCollapseFramesButton.Location = new System.Drawing.Point(58, 159);
            this.expandAndCollapseFramesButton.Name = "expandAndCollapseFramesButton";
            this.expandAndCollapseFramesButton.Size = new System.Drawing.Size(200, 29);
            this.expandAndCollapseFramesButton.TabIndex = 4;
            this.expandAndCollapseFramesButton.Text = "E&xpand and Collapse Frames";
            this.expandAndCollapseFramesButton.Click += new System.EventHandler(this.expandAndCollapseFramesButton_Click);
            // 
            // addAndRemoveButton
            // 
            this.addAndRemoveButton.Location = new System.Drawing.Point(58, 119);
            this.addAndRemoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.addAndRemoveButton.Name = "addAndRemoveButton";
            this.addAndRemoveButton.Size = new System.Drawing.Size(200, 29);
            this.addAndRemoveButton.TabIndex = 3;
            this.addAndRemoveButton.Text = "A&dd, Remove and Reorder Frames";
            this.addAndRemoveButton.Click += new System.EventHandler(this.addAndRemoveButton_Click);
            // 
            // TaskPane1
            // 
            this.TaskPane1.AutoScroll = true;
            this.TaskPane1.AutoScrollMinSize = new System.Drawing.Size(0, 584);
            this.TaskPane1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TaskPane1.Controls.Add(this.TaskFrame0);
            this.TaskPane1.Controls.Add(this.TaskFrame1);
            this.TaskPane1.Controls.Add(this.TaskFrame2);
            this.TaskPane1.Controls.Add(this.hiddenTaskFrame);
            this.TaskPane1.Dock = System.Windows.Forms.DockStyle.Left;
            this.TaskPane1.Location = new System.Drawing.Point(0, 0);
            this.TaskPane1.Name = "TaskPane1";
            this.TaskPane1.Size = new System.Drawing.Size(224, 440);
            this.TaskPane1.TabIndex = 0;
            // 
            // TaskFrame0
            // 
            this.TaskFrame0.AllowDrop = true;
            this.TaskFrame0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.TaskFrame0.CaptionBlend = new Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(170)))), ((int)(((byte)(230))))));
            this.TaskFrame0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.TaskFrame0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(111)))), ((int)(((byte)(100)))));
            this.TaskFrame0.Location = new System.Drawing.Point(12, 33);
            this.TaskFrame0.Name = "TaskFrame0";
            this.TaskFrame0.Size = new System.Drawing.Size(182, 100);
            this.TaskFrame0.TabIndex = 0;
            this.TaskFrame0.Text = "First TaskFrame!";
            // 
            // TaskFrame1
            // 
            this.TaskFrame1.AllowDrop = true;
            this.TaskFrame1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.TaskFrame1.CaptionBlend = new Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(170)))), ((int)(((byte)(230))))));
            this.TaskFrame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.TaskFrame1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(111)))), ((int)(((byte)(100)))));
            this.TaskFrame1.Location = new System.Drawing.Point(12, 166);
            this.TaskFrame1.Name = "TaskFrame1";
            this.TaskFrame1.Size = new System.Drawing.Size(182, 40);
            this.TaskFrame1.TabIndex = 1;
            this.TaskFrame1.Text = "TaskFrame1";
            // 
            // TaskFrame2
            // 
            this.TaskFrame2.AllowDrop = true;
            this.TaskFrame2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.TaskFrame2.CaptionBlend = new Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(170)))), ((int)(((byte)(230))))));
            this.TaskFrame2.Controls.Add(this.LinkLabel4);
            this.TaskFrame2.Controls.Add(this.LinkLabel3);
            this.TaskFrame2.Controls.Add(this.LinkLabel2);
            this.TaskFrame2.Controls.Add(this.LinkLabel1);
            this.TaskFrame2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.TaskFrame2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(111)))), ((int)(((byte)(100)))));
            this.TaskFrame2.IsExpanded = false;
            this.TaskFrame2.Location = new System.Drawing.Point(12, 239);
            this.TaskFrame2.Name = "TaskFrame2";
            this.TaskFrame2.Size = new System.Drawing.Size(182, 200);
            this.TaskFrame2.TabIndex = 2;
            this.TaskFrame2.Text = "TaskFrame2";
            // 
            // LinkLabel4
            // 
            this.LinkLabel4.AutoSize = true;
            this.LinkLabel4.Location = new System.Drawing.Point(21, 81);
            this.LinkLabel4.Name = "LinkLabel4";
            this.LinkLabel4.Size = new System.Drawing.Size(88, 13);
            this.LinkLabel4.TabIndex = 3;
            this.LinkLabel4.TabStop = true;
            this.LinkLabel4.Text = "Manage Users";
            this.LinkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel4_LinkClicked);
            // 
            // LinkLabel3
            // 
            this.LinkLabel3.AutoSize = true;
            this.LinkLabel3.Location = new System.Drawing.Point(21, 60);
            this.LinkLabel3.Name = "LinkLabel3";
            this.LinkLabel3.Size = new System.Drawing.Size(92, 13);
            this.LinkLabel3.TabIndex = 2;
            this.LinkLabel3.TabStop = true;
            this.LinkLabel3.Text = "Show All Users";
            this.LinkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel3_LinkClicked);
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.Location = new System.Drawing.Point(21, 39);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(83, 13);
            this.LinkLabel2.TabIndex = 1;
            this.LinkLabel2.TabStop = true;
            this.LinkLabel2.Text = "Remove User";
            this.LinkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Location = new System.Drawing.Point(21, 18);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(132, 13);
            this.LinkLabel1.TabIndex = 0;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "Useless Links Abound";
            this.LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // hiddenTaskFrame
            // 
            this.hiddenTaskFrame.AllowDrop = true;
            this.hiddenTaskFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.hiddenTaskFrame.CaptionBlend = new Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(170)))), ((int)(((byte)(230))))));
            this.hiddenTaskFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.hiddenTaskFrame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(111)))), ((int)(((byte)(100)))));
            this.hiddenTaskFrame.Location = new System.Drawing.Point(12, 472);
            this.hiddenTaskFrame.Name = "TaskFrame3";
            this.hiddenTaskFrame.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hiddenTaskFrame.Size = new System.Drawing.Size(182, 100);
            this.hiddenTaskFrame.TabIndex = 3;
            this.hiddenTaskFrame.Text = "Surprise!";
            this.hiddenTaskFrame.Visible = false;
            // 
            // TaskPaneTest
            // 
            this.ClientSize = new System.Drawing.Size(566, 440);
            this.Controls.Add(this.testPanel);
            this.Controls.Add(this.TaskPane1);
            this.Name = "TaskPaneTest";
            this.Text = "TaskPane Sample";
            this.testPanel.ResumeLayout(false);
            this.testPanel.PerformLayout();
            this.cornerStyleGroup.ResumeLayout(false);
            this.cornerStyleGroup.PerformLayout();
            this.dockGroup.ResumeLayout(false);
            this.dockGroup.PerformLayout();
            this.TaskPane1.ResumeLayout(false);
            this.TaskFrame2.ResumeLayout(false);
            this.TaskFrame2.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel testPanel;
        internal System.Windows.Forms.GroupBox dockGroup;
        internal System.Windows.Forms.GroupBox cornerStyleGroup;
        internal System.Windows.Forms.RadioButton squaredCornerStyleRadio;
        internal System.Windows.Forms.RadioButton roundedCornerStyleRadio;
        internal System.Windows.Forms.RadioButton sysDefCornerStyleRadio;
        internal System.Windows.Forms.Button expandAndCollapseFramesButton;
        internal System.Windows.Forms.Button addAndRemoveButton;
        internal System.Windows.Forms.RadioButton topDockRadio;
        internal System.Windows.Forms.RadioButton leftDockRadio;
        internal System.Windows.Forms.RadioButton rightDockRadio;
        internal System.Windows.Forms.RadioButton bottomDockRadio;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskPane TaskPane1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame TaskFrame0;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame TaskFrame1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame TaskFrame2;
        private System.Windows.Forms.LinkLabel LinkLabel4;
        private System.Windows.Forms.LinkLabel LinkLabel3;
        private System.Windows.Forms.LinkLabel LinkLabel2;
        private System.Windows.Forms.LinkLabel LinkLabel1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame hiddenTaskFrame;
        private System.Windows.Forms.Label label1;
    }

}
