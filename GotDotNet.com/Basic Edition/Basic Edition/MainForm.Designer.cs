using System.Drawing;

namespace openglFramework
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.springToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.selectedCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fpsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.oglfVersionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vendorTextBox = new System.Windows.Forms.TextBox();
            this.rendererTextBox = new System.Windows.Forms.TextBox();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.sourceCodeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chordalErrorUpDown = new System.Windows.Forms.NumericUpDown();
            this.fieldOfViewUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openGLControl1 = new openglFramework.OpenGLControl();
            this.zoomButton = new openglFramework.ToggleButton();
            this.rotateButton = new openglFramework.ToggleButton();
            this.panButton = new openglFramework.ToggleButton();
            this.perspectiveButton = new openglFramework.ToggleButton();
            this.parallelButton = new openglFramework.ToggleButton();
            this.cullingButton = new openglFramework.ToggleButton();
            this.orientationButton = new openglFramework.ToggleButton();
            this.shadedButton = new openglFramework.ToggleButton();
            this.edgesButton = new openglFramework.ToggleButton();
            this.wireframeButton = new openglFramework.ToggleButton();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chordalErrorUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldOfViewUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusLabel,
            this.springToolStripStatusLabel,
            this.loadingProgressBar,
            this.selectedCountStatusLabel,
            this.fpsStatusLabel,
            this.oglfVersionStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(864, 23);
            this.statusStrip1.TabIndex = 52;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(496, 18);
            this.mainStatusLabel.Text = "Middle Mouse Button = Rotate, Ctrl + Middle = Pan, Shift + Middle = Zoom, Mouse W" +
                "heel = Zoom +/-";
            // 
            // springToolStripStatusLabel
            // 
            this.springToolStripStatusLabel.Name = "springToolStripStatusLabel";
            this.springToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.springToolStripStatusLabel.Size = new System.Drawing.Size(146, 18);
            this.springToolStripStatusLabel.Spring = true;
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.loadingProgressBar.Size = new System.Drawing.Size(105, 17);
            this.loadingProgressBar.Visible = false;
            // 
            // selectedCountStatusLabel
            // 
            this.selectedCountStatusLabel.AutoSize = false;
            this.selectedCountStatusLabel.AutoToolTip = true;
            this.selectedCountStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.selectedCountStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.selectedCountStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.selectedCountStatusLabel.Name = "selectedCountStatusLabel";
            this.selectedCountStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.selectedCountStatusLabel.Size = new System.Drawing.Size(64, 18);
            this.selectedCountStatusLabel.Text = "0";
            this.selectedCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectedCountStatusLabel.ToolTipText = "Selected count";
            // 
            // fpsStatusLabel
            // 
            this.fpsStatusLabel.AutoSize = false;
            this.fpsStatusLabel.AutoToolTip = true;
            this.fpsStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.fpsStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.fpsStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.fpsStatusLabel.Name = "fpsStatusLabel";
            this.fpsStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.fpsStatusLabel.Size = new System.Drawing.Size(64, 18);
            this.fpsStatusLabel.Text = "toolStripStatusLabel1";
            this.fpsStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fpsStatusLabel.ToolTipText = "Frames per second";
            // 
            // oglfVersionStatusLabel
            // 
            this.oglfVersionStatusLabel.AutoSize = false;
            this.oglfVersionStatusLabel.AutoToolTip = true;
            this.oglfVersionStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.oglfVersionStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.oglfVersionStatusLabel.Name = "oglfVersionStatusLabel";
            this.oglfVersionStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.oglfVersionStatusLabel.Size = new System.Drawing.Size(64, 18);
            this.oglfVersionStatusLabel.Text = "toolStripStatusLabel1";
            this.oglfVersionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.oglfVersionStatusLabel.ToolTipText = "C# OpenGL Framework version";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.vendorTextBox);
            this.groupBox1.Controls.Add(this.rendererTextBox);
            this.groupBox1.Controls.Add(this.versionTextBox);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(569, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 96);
            this.groupBox1.TabIndex = 269;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OpenGL Version";
            // 
            // vendorTextBox
            // 
            this.vendorTextBox.Location = new System.Drawing.Point(84, 65);
            this.vendorTextBox.Name = "vendorTextBox";
            this.vendorTextBox.ReadOnly = true;
            this.vendorTextBox.Size = new System.Drawing.Size(190, 21);
            this.vendorTextBox.TabIndex = 5;
            // 
            // rendererTextBox
            // 
            this.rendererTextBox.Location = new System.Drawing.Point(84, 41);
            this.rendererTextBox.Name = "rendererTextBox";
            this.rendererTextBox.ReadOnly = true;
            this.rendererTextBox.Size = new System.Drawing.Size(190, 21);
            this.rendererTextBox.TabIndex = 4;
            // 
            // versionTextBox
            // 
            this.versionTextBox.Location = new System.Drawing.Point(84, 17);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.ReadOnly = true;
            this.versionTextBox.Size = new System.Drawing.Size(190, 21);
            this.versionTextBox.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Vendor";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Renderer";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Version";
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(568, 220);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(94, 22);
            this.openButton.TabIndex = 263;
            this.openButton.Text = "Open...";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // sourceCodeButton
            // 
            this.sourceCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceCodeButton.Location = new System.Drawing.Point(760, 220);
            this.sourceCodeButton.Name = "sourceCodeButton";
            this.sourceCodeButton.Size = new System.Drawing.Size(94, 22);
            this.sourceCodeButton.TabIndex = 262;
            this.sourceCodeButton.Text = "Source Code";
            this.sourceCodeButton.Click += new System.EventHandler(this.sourceCodeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(664, 220);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 22);
            this.saveButton.TabIndex = 261;
            this.saveButton.Text = "Save...";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(569, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 255;
            this.label3.Text = "ZPR";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(569, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 254;
            this.label2.Text = "Projection";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(569, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 253;
            this.label1.Text = "Shading";
            // 
            // chordalErrorUpDown
            // 
            this.chordalErrorUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chordalErrorUpDown.DecimalPlaces = 2;
            this.chordalErrorUpDown.Enabled = false;
            this.chordalErrorUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.chordalErrorUpDown.Location = new System.Drawing.Point(761, 76);
            this.chordalErrorUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.chordalErrorUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.chordalErrorUpDown.Name = "chordalErrorUpDown";
            this.chordalErrorUpDown.Size = new System.Drawing.Size(94, 21);
            this.chordalErrorUpDown.TabIndex = 252;
            this.chordalErrorUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chordalErrorUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.chordalErrorUpDown.ValueChanged += new System.EventHandler(this.chordalErrorUpDown_ValueChanged);
            // 
            // fieldOfViewUpDown
            // 
            this.fieldOfViewUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldOfViewUpDown.Enabled = false;
            this.fieldOfViewUpDown.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.fieldOfViewUpDown.Location = new System.Drawing.Point(761, 122);
            this.fieldOfViewUpDown.Maximum = new decimal(new int[] {
            280,
            0,
            0,
            0});
            this.fieldOfViewUpDown.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.fieldOfViewUpDown.Name = "fieldOfViewUpDown";
            this.fieldOfViewUpDown.Size = new System.Drawing.Size(92, 21);
            this.fieldOfViewUpDown.TabIndex = 251;
            this.fieldOfViewUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fieldOfViewUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.fieldOfViewUpDown.ValueChanged += new System.EventHandler(this.fieldOfView_ValueChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(569, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 222;
            this.label12.Text = "File";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 23);
            this.label17.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 23);
            this.label18.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(568, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 21);
            this.panel1.TabIndex = 270;
            // 
            // openGLControl1
            // 
            this.openGLControl1.AmbientLight = new float[] {
        0.1F,
        0.1F,
        0.1F,
        1F};
            this.openGLControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.openGLControl1.BackFaceCulling = true;
            this.openGLControl1.BackgroundMode = openglFramework.OpenGLControl.backgroundType.Bitmap;
            this.openGLControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openGLControl1.ChordalErr = 0.1F;
            this.openGLControl1.EdgeWeight = 2F;
            this.openGLControl1.FieldOfView = 80F;
            this.openGLControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGLControl1.Location = new System.Drawing.Point(8, 9);
            this.openGLControl1.MainLightDiffuse = new float[] {
        0.75F,
        0.75F,
        0.75F,
        1F};
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.PanButtonDown = false;
            this.openGLControl1.PointSize = 4F;
            this.openGLControl1.ProjectionMode = openglFramework.OpenGLControl.projectionType.Perspective;
            this.openGLControl1.RotateButtonDown = false;
            this.openGLControl1.ShadingMode = openglFramework.OpenGLControl.shadingType.ShadedAndEdges;
            this.openGLControl1.ShadowMode = openglFramework.OpenGLControl.shadowType.Transparent;
            this.openGLControl1.ShowBoundingBox = true;
            this.openGLControl1.ShowLabels = true;
            this.openGLControl1.ShowLegend = true;
            this.openGLControl1.ShowLights = false;
            this.openGLControl1.ShowNodes = false;
            this.openGLControl1.ShowNormals = false;
            this.openGLControl1.ShowOrigin = false;
            this.openGLControl1.ShowProgress = true;
            this.openGLControl1.ShowUCSIcon = true;
            this.openGLControl1.SideLightDiffuse = new float[] {
        0.2F,
        0.2F,
        0.2F,
        1F};
            this.openGLControl1.Size = new System.Drawing.Size(552, 640);
            this.openGLControl1.TabIndex = 1;
            this.openGLControl1.WireframeWeight = 1.5F;
            this.openGLControl1.ZoomButtonDown = false;
            this.openGLControl1.ZoomWindowButtonDown = false;
            this.openGLControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.openGLControl1_Paint);
            // 
            // zoomButton
            // 
            this.zoomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoomButton.Enabled = false;
            this.zoomButton.Location = new System.Drawing.Point(568, 169);
            this.zoomButton.Name = "zoomButton";
            this.zoomButton.Size = new System.Drawing.Size(94, 22);
            this.zoomButton.TabIndex = 169;
            this.zoomButton.Text = "Zoom";
            this.zoomButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zoomButton.Click += new System.EventHandler(this.zoomButton_Click);
            // 
            // rotateButton
            // 
            this.rotateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rotateButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.rotateButton.Location = new System.Drawing.Point(760, 169);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(94, 22);
            this.rotateButton.TabIndex = 171;
            this.rotateButton.Text = "Rotate";
            this.rotateButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // panButton
            // 
            this.panButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.panButton.Enabled = false;
            this.panButton.Location = new System.Drawing.Point(664, 169);
            this.panButton.Name = "panButton";
            this.panButton.Size = new System.Drawing.Size(94, 22);
            this.panButton.TabIndex = 170;
            this.panButton.Text = "Pan";
            this.panButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.panButton.Click += new System.EventHandler(this.panButton_Click);
            // 
            // perspectiveButton
            // 
            this.perspectiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.perspectiveButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.perspectiveButton.Location = new System.Drawing.Point(664, 122);
            this.perspectiveButton.Name = "perspectiveButton";
            this.perspectiveButton.Size = new System.Drawing.Size(94, 22);
            this.perspectiveButton.TabIndex = 166;
            this.perspectiveButton.Text = "Perspective";
            this.perspectiveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.perspectiveButton.Click += new System.EventHandler(this.perspectiveButton_Click);
            // 
            // parallelButton
            // 
            this.parallelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.parallelButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.parallelButton.Location = new System.Drawing.Point(568, 122);
            this.parallelButton.Name = "parallelButton";
            this.parallelButton.Size = new System.Drawing.Size(94, 22);
            this.parallelButton.TabIndex = 165;
            this.parallelButton.Text = "Parallel";
            this.parallelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.parallelButton.Click += new System.EventHandler(this.parallelButton_Click);
            // 
            // cullingButton
            // 
            this.cullingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cullingButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.cullingButton.Location = new System.Drawing.Point(664, 75);
            this.cullingButton.Name = "cullingButton";
            this.cullingButton.Size = new System.Drawing.Size(94, 22);
            this.cullingButton.TabIndex = 198;
            this.cullingButton.Text = "Culling";
            this.cullingButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cullingButton.UseVisualStyleBackColor = true;
            this.cullingButton.CheckedChanged += new System.EventHandler(this.cullingButton_CheckedChanged);
            // 
            // orientationButton
            // 
            this.orientationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orientationButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.orientationButton.Location = new System.Drawing.Point(568, 75);
            this.orientationButton.Name = "orientationButton";
            this.orientationButton.Size = new System.Drawing.Size(94, 22);
            this.orientationButton.TabIndex = 162;
            this.orientationButton.Text = "Orientation";
            this.orientationButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.orientationButton.UseVisualStyleBackColor = true;
            this.orientationButton.Click += new System.EventHandler(this.orientationButton_Click);
            // 
            // shadedButton
            // 
            this.shadedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shadedButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.shadedButton.Location = new System.Drawing.Point(664, 50);
            this.shadedButton.Name = "shadedButton";
            this.shadedButton.Size = new System.Drawing.Size(94, 22);
            this.shadedButton.TabIndex = 160;
            this.shadedButton.Text = "Shaded";
            this.shadedButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shadedButton.Click += new System.EventHandler(this.shadedButton_Click);
            // 
            // edgesButton
            // 
            this.edgesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edgesButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.edgesButton.Location = new System.Drawing.Point(760, 50);
            this.edgesButton.Name = "edgesButton";
            this.edgesButton.Size = new System.Drawing.Size(94, 22);
            this.edgesButton.TabIndex = 161;
            this.edgesButton.Text = "Shaded && Edges";
            this.edgesButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edgesButton.Click += new System.EventHandler(this.edgesButton_Click);
            // 
            // wireframeButton
            // 
            this.wireframeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wireframeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.wireframeButton.Location = new System.Drawing.Point(568, 50);
            this.wireframeButton.Name = "wireframeButton";
            this.wireframeButton.Size = new System.Drawing.Size(94, 22);
            this.wireframeButton.TabIndex = 159;
            this.wireframeButton.Text = "Wireframe";
            this.wireframeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wireframeButton.Click += new System.EventHandler(this.wireframeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.openGLControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoomButton);
            this.Controls.Add(this.rotateButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.sourceCodeButton);
            this.Controls.Add(this.panButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.perspectiveButton);
            this.Controls.Add(this.parallelButton);
            this.Controls.Add(this.cullingButton);
            this.Controls.Add(this.orientationButton);
            this.Controls.Add(this.shadedButton);
            this.Controls.Add(this.edgesButton);
            this.Controls.Add(this.wireframeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fieldOfViewUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chordalErrorUpDown);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "C# OpenGL Framework - Basic Edition";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chordalErrorUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldOfViewUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel mainStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel fpsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel springToolStripStatusLabel;
        public System.Windows.Forms.ToolStripStatusLabel selectedCountStatusLabel;
        private OpenGLControl openGLControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripProgressBar loadingProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel oglfVersionStatusLabel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label12;
        private ToggleButton cullingButton;
        private ToggleButton zoomButton;
        private ToggleButton rotateButton;
        private ToggleButton panButton;
        private ToggleButton perspectiveButton;
        private ToggleButton parallelButton;
        private ToggleButton orientationButton;
        private ToggleButton shadedButton;
        private ToggleButton edgesButton;
        private ToggleButton wireframeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown chordalErrorUpDown;
        private System.Windows.Forms.NumericUpDown fieldOfViewUpDown;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button sourceCodeButton;
        private System.Windows.Forms.Button saveButton;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox vendorTextBox;
        private System.Windows.Forms.TextBox rendererTextBox;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;

     
    }
}

