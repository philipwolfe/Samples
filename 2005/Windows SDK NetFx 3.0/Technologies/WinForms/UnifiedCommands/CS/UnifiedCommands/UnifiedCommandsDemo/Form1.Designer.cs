namespace Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationMenus = new System.Windows.Forms.MenuStrip();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.fontFaceToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.arialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tahomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timesNewRomanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courierNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lucidaConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wingDingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verdanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.ptToolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.documentToolStrip = new System.Windows.Forms.ToolStrip();
            this.openDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fontToolStrip = new System.Windows.Forms.ToolStrip();
            this.bBToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.iIToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fontFaceToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.faceToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.fontSizeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.fontSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.unifiedCommandManager1 = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommandManager(this.components);
            this.cmdFileSave = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand(this.components);
            this.cmdFileSaveAs = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand(this.components);
            this.cmdFilePrint = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand(this.components);
            this.cmdFontBold = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand(this.components);
            this.cmdFontItalic = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand(this.components);
            this.cmdFontFace = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand(this.components);
            this.cmdFontSize = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand(this.components);
            this.cmdFileOpen = new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand(this.components);
            this.applicationMenus.SuspendLayout();
            this.documentToolStrip.SuspendLayout();
            this.fontToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.fileToolStripMenuItem, null);
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.saveToolStripMenuItem, this.cmdFileSave);
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.saveAsToolStripMenuItem, this.cmdFileSaveAs);
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // printToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.printToolStripMenuItem, this.cmdFilePrint);
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // toolStripMenuItem1
            // 
            this.unifiedCommandManager1.SetCommand(this.toolStripMenuItem1, null);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.exitToolStripMenuItem, null);
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // applicationMenus
            // 
            this.applicationMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.applicationMenus.Location = new System.Drawing.Point(0, 0);
            this.applicationMenus.Name = "applicationMenus";
            this.applicationMenus.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.applicationMenus.Size = new System.Drawing.Size(644, 24);
            this.applicationMenus.TabIndex = 0;
            this.applicationMenus.Text = "menuStrip1";
            // 
            // fontToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.fontToolStripMenuItem, null);
            this.fontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boldToolStripMenuItem,
            this.italicToolStripMenuItem,
            this.toolStripMenuItem2,
            this.fontFaceToolStripMenu,
            this.fontSizeToolStripMenuItem});
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fontToolStripMenuItem.Text = "Fo&nt";
            // 
            // boldToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.boldToolStripMenuItem, this.cmdFontBold);
            this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            this.boldToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.boldToolStripMenuItem.Text = "&Bold";
            // 
            // italicToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.italicToolStripMenuItem, this.cmdFontItalic);
            this.italicToolStripMenuItem.Name = "italicToolStripMenuItem";
            this.italicToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.italicToolStripMenuItem.Text = "&Italic";
            // 
            // toolStripMenuItem2
            // 
            this.unifiedCommandManager1.SetCommand(this.toolStripMenuItem2, null);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 6);
            // 
            // fontFaceToolStripMenu
            // 
            this.unifiedCommandManager1.SetCommand(this.fontFaceToolStripMenu, this.cmdFontFace);
            this.fontFaceToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arialToolStripMenuItem,
            this.tahomaToolStripMenuItem,
            this.timesNewRomanToolStripMenuItem,
            this.courierNewToolStripMenuItem,
            this.lucidaConsoleToolStripMenuItem,
            this.wingDingsToolStripMenuItem,
            this.verdanaToolStripMenuItem});
            this.fontFaceToolStripMenu.Name = "fontFaceToolStripMenu";
            this.fontFaceToolStripMenu.Size = new System.Drawing.Size(125, 22);
            this.fontFaceToolStripMenu.Text = "&Font Face";
            // 
            // arialToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.arialToolStripMenuItem, null);
            this.arialToolStripMenuItem.Name = "arialToolStripMenuItem";
            this.arialToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.arialToolStripMenuItem.Text = "&Arial";
            // 
            // tahomaToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.tahomaToolStripMenuItem, null);
            this.tahomaToolStripMenuItem.Name = "tahomaToolStripMenuItem";
            this.tahomaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.tahomaToolStripMenuItem.Text = "&Tahoma";
            // 
            // timesNewRomanToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.timesNewRomanToolStripMenuItem, null);
            this.timesNewRomanToolStripMenuItem.Name = "timesNewRomanToolStripMenuItem";
            this.timesNewRomanToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.timesNewRomanToolStripMenuItem.Text = "&Times New Roman";
            // 
            // courierNewToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.courierNewToolStripMenuItem, null);
            this.courierNewToolStripMenuItem.Name = "courierNewToolStripMenuItem";
            this.courierNewToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.courierNewToolStripMenuItem.Text = "&Courier New";
            // 
            // lucidaConsoleToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.lucidaConsoleToolStripMenuItem, null);
            this.lucidaConsoleToolStripMenuItem.Name = "lucidaConsoleToolStripMenuItem";
            this.lucidaConsoleToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.lucidaConsoleToolStripMenuItem.Text = "&Lucida Console";
            // 
            // wingDingsToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.wingDingsToolStripMenuItem, null);
            this.wingDingsToolStripMenuItem.Name = "wingDingsToolStripMenuItem";
            this.wingDingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.wingDingsToolStripMenuItem.Text = "&Wingdings";
            // 
            // verdanaToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.verdanaToolStripMenuItem, null);
            this.verdanaToolStripMenuItem.Name = "verdanaToolStripMenuItem";
            this.verdanaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.verdanaToolStripMenuItem.Text = "&Verdana";
            // 
            // fontSizeToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.fontSizeToolStripMenuItem, this.cmdFontSize);
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ptToolStripMenuItem,
            this.ptToolStripMenuItem1,
            this.ptToolStripMenuItem2,
            this.ptToolStripMenuItem3,
            this.ptToolStripMenuItem4,
            this.ptToolStripMenuItem5,
            this.ptToolStripMenuItem6,
            this.ptToolStripMenuItem7,
            this.ptToolStripMenuItem8,
            this.ptToolStripMenuItem9,
            this.ptToolStripMenuItem10,
            this.ptToolStripMenuItem11,
            this.ptToolStripMenuItem12});
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fontSizeToolStripMenuItem.Text = "Font &Size";
            // 
            // ptToolStripMenuItem
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem, null);
            this.ptToolStripMenuItem.Name = "ptToolStripMenuItem";
            this.ptToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem.Text = "8 pt";
            // 
            // ptToolStripMenuItem1
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem1, null);
            this.ptToolStripMenuItem1.Name = "ptToolStripMenuItem1";
            this.ptToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem1.Text = "9 pt";
            // 
            // ptToolStripMenuItem2
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem2, null);
            this.ptToolStripMenuItem2.Name = "ptToolStripMenuItem2";
            this.ptToolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem2.Text = "10 pt";
            // 
            // ptToolStripMenuItem3
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem3, null);
            this.ptToolStripMenuItem3.Name = "ptToolStripMenuItem3";
            this.ptToolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem3.Text = "11 pt";
            // 
            // ptToolStripMenuItem4
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem4, null);
            this.ptToolStripMenuItem4.Name = "ptToolStripMenuItem4";
            this.ptToolStripMenuItem4.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem4.Text = "12 pt";
            // 
            // ptToolStripMenuItem5
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem5, null);
            this.ptToolStripMenuItem5.Name = "ptToolStripMenuItem5";
            this.ptToolStripMenuItem5.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem5.Text = "13 pt";
            // 
            // ptToolStripMenuItem6
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem6, null);
            this.ptToolStripMenuItem6.Name = "ptToolStripMenuItem6";
            this.ptToolStripMenuItem6.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem6.Text = "14 pt";
            // 
            // ptToolStripMenuItem7
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem7, null);
            this.ptToolStripMenuItem7.Name = "ptToolStripMenuItem7";
            this.ptToolStripMenuItem7.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem7.Text = "15 pt";
            // 
            // ptToolStripMenuItem8
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem8, null);
            this.ptToolStripMenuItem8.Name = "ptToolStripMenuItem8";
            this.ptToolStripMenuItem8.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem8.Text = "16 pt";
            // 
            // ptToolStripMenuItem9
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem9, null);
            this.ptToolStripMenuItem9.Name = "ptToolStripMenuItem9";
            this.ptToolStripMenuItem9.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem9.Text = "20 pt";
            // 
            // ptToolStripMenuItem10
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem10, null);
            this.ptToolStripMenuItem10.Name = "ptToolStripMenuItem10";
            this.ptToolStripMenuItem10.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem10.Text = "24 pt";
            // 
            // ptToolStripMenuItem11
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem11, null);
            this.ptToolStripMenuItem11.Name = "ptToolStripMenuItem11";
            this.ptToolStripMenuItem11.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem11.Text = "36 pt";
            // 
            // ptToolStripMenuItem12
            // 
            this.unifiedCommandManager1.SetCommand(this.ptToolStripMenuItem12, null);
            this.ptToolStripMenuItem12.Name = "ptToolStripMenuItem12";
            this.ptToolStripMenuItem12.Size = new System.Drawing.Size(102, 22);
            this.ptToolStripMenuItem12.Text = "72 pt";
            // 
            // documentToolStrip
            // 
            this.documentToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.documentToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDocumentToolStripButton,
            this.saveDocumentToolStripButton,
            this.printDocumentToolStripButton});
            this.documentToolStrip.Location = new System.Drawing.Point(0, 24);
            this.documentToolStrip.Name = "documentToolStrip";
            this.documentToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.documentToolStrip.Size = new System.Drawing.Size(644, 25);
            this.documentToolStrip.TabIndex = 1;
            this.documentToolStrip.Text = "documentToolStrip";
            // 
            // openDocumentToolStripButton
            // 
            this.unifiedCommandManager1.SetCommand(this.openDocumentToolStripButton, this.cmdFileOpen);
            this.openDocumentToolStripButton.Image = global::Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo.Properties.Resources.FileOpen;
            this.openDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.openDocumentToolStripButton.Name = "openDocumentToolStripButton";
            this.openDocumentToolStripButton.Size = new System.Drawing.Size(104, 22);
            this.openDocumentToolStripButton.Text = "&Open Document";
            // 
            // saveDocumentToolStripButton
            // 
            this.unifiedCommandManager1.SetCommand(this.saveDocumentToolStripButton, this.cmdFileSave);
            this.saveDocumentToolStripButton.Image = global::Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo.Properties.Resources.FileSave;
            this.saveDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.saveDocumentToolStripButton.Name = "saveDocumentToolStripButton";
            this.saveDocumentToolStripButton.Size = new System.Drawing.Size(102, 22);
            this.saveDocumentToolStripButton.Text = "&Save Document";
            // 
            // printDocumentToolStripButton
            // 
            this.unifiedCommandManager1.SetCommand(this.printDocumentToolStripButton, this.cmdFilePrint);
            this.printDocumentToolStripButton.Image = global::Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo.Properties.Resources.FilePrint;
            this.printDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.printDocumentToolStripButton.Name = "printDocumentToolStripButton";
            this.printDocumentToolStripButton.Size = new System.Drawing.Size(100, 22);
            this.printDocumentToolStripButton.Text = "&Print Document";
            // 
            // fontToolStrip
            // 
            this.fontToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fontToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bBToolStripButton,
            this.iIToolStripButton,
            this.fontFaceToolStripLabel,
            this.faceToolStripComboBox,
            this.fontSizeToolStripLabel,
            this.fontSizeToolStripComboBox});
            this.fontToolStrip.Location = new System.Drawing.Point(0, 49);
            this.fontToolStrip.Name = "fontToolStrip";
            this.fontToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.fontToolStrip.Size = new System.Drawing.Size(644, 25);
            this.fontToolStrip.TabIndex = 2;
            this.fontToolStrip.Text = "fontToolStrip";
            // 
            // bBToolStripButton
            // 
            this.unifiedCommandManager1.SetCommand(this.bBToolStripButton, this.cmdFontBold);
            this.bBToolStripButton.Image = global::Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo.Properties.Resources.B;
            this.bBToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.bBToolStripButton.Name = "bBToolStripButton";
            this.bBToolStripButton.Size = new System.Drawing.Size(47, 22);
            this.bBToolStripButton.Text = "Bold";
            this.bBToolStripButton.ToolTipText = "Bold";
            // 
            // iIToolStripButton
            // 
            this.unifiedCommandManager1.SetCommand(this.iIToolStripButton, this.cmdFontItalic);
            this.iIToolStripButton.Image = global::Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo.Properties.Resources.I;
            this.iIToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.iIToolStripButton.Name = "iIToolStripButton";
            this.iIToolStripButton.Size = new System.Drawing.Size(55, 22);
            this.iIToolStripButton.Text = "Italics";
            this.iIToolStripButton.ToolTipText = "Italics";
            // 
            // fontFaceToolStripLabel
            // 
            this.unifiedCommandManager1.SetCommand(this.fontFaceToolStripLabel, null);
            this.fontFaceToolStripLabel.Name = "fontFaceToolStripLabel";
            this.fontFaceToolStripLabel.Size = new System.Drawing.Size(59, 22);
            this.fontFaceToolStripLabel.Text = "Font Face:";
            this.fontFaceToolStripLabel.ToolTipText = "Font Face";
            // 
            // faceToolStripComboBox
            // 
            this.unifiedCommandManager1.SetCommand(this.faceToolStripComboBox, this.cmdFontFace);
            this.faceToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.faceToolStripComboBox.Items.AddRange(new object[] {
            "Arial",
            "Tahoma",
            "Times New Roman",
            "Courier New",
            "Lucida Console",
            "Wingdings",
            "Verdana"});
            this.faceToolStripComboBox.Name = "faceToolStripComboBox";
            this.faceToolStripComboBox.Size = new System.Drawing.Size(138, 25);
            // 
            // fontSizeToolStripLabel
            // 
            this.unifiedCommandManager1.SetCommand(this.fontSizeToolStripLabel, null);
            this.fontSizeToolStripLabel.Name = "fontSizeToolStripLabel";
            this.fontSizeToolStripLabel.Size = new System.Drawing.Size(55, 22);
            this.fontSizeToolStripLabel.Text = "Font Size:";
            // 
            // fontSizeToolStripComboBox
            // 
            this.unifiedCommandManager1.SetCommand(this.fontSizeToolStripComboBox, this.cmdFontSize);
            this.fontSizeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontSizeToolStripComboBox.Items.AddRange(new object[] {
            "8 pt",
            "9 pt",
            "10 pt",
            "11 pt",
            "12 pt",
            "13 pt",
            "14 pt",
            "15 pt",
            "16 pt",
            "20 pt",
            "24 pt",
            "36 pt",
            "72 pt"});
            this.fontSizeToolStripComboBox.Name = "fontSizeToolStripComboBox";
            this.fontSizeToolStripComboBox.Size = new System.Drawing.Size(138, 25);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 71);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(644, 294);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            // 
            // unifiedCommandManager1
            // 
            this.unifiedCommandManager1.Commands.AddRange(new Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand[] {
            this.cmdFileOpen,
            this.cmdFileSave,
            this.cmdFilePrint,
            this.cmdFontBold,
            this.cmdFontItalic,
            this.cmdFontFace,
            this.cmdFileSaveAs,
            this.cmdFontSize});
            // 
            // cmdFileSave
            // 
            this.cmdFileSave.CommandName = "Save Document";
            this.cmdFileSave.Execute += new System.EventHandler(this.cmdFileSave_Execute);
            // 
            // cmdFileSaveAs
            // 
            this.cmdFileSaveAs.CommandName = "Save Document As";
            this.cmdFileSaveAs.Execute += new System.EventHandler(this.cmdFileSaveAs_Execute);
            // 
            // cmdFilePrint
            // 
            this.cmdFilePrint.CommandName = "Print Document";
            this.cmdFilePrint.Execute += new System.EventHandler(this.cmdFilePrint_Execute);
            // 
            // cmdFontBold
            // 
            this.cmdFontBold.CommandName = "Bold Font";
            this.cmdFontBold.Execute += new System.EventHandler(this.cmdFontBold_Execute);
            // 
            // cmdFontItalic
            // 
            this.cmdFontItalic.CommandName = "Italicised Font";
            this.cmdFontItalic.Execute += new System.EventHandler(this.cmdFontItalic_Execute);
            // 
            // cmdFontFace
            // 
            this.cmdFontFace.CommandName = "Font Face";
            this.cmdFontFace.Execute += new System.EventHandler(this.cmdFontFace_Execute);
            // 
            // cmdFontSize
            // 
            this.cmdFontSize.CommandDescription = "The size of the input font (in pts)";
            this.cmdFontSize.CommandName = "Font Size";
            this.cmdFontSize.Execute += new System.EventHandler(this.cmdFontSize_Execute);
            // 
            // cmdFileOpen
            // 
            this.cmdFileOpen.CommandName = "Open Document";
            this.cmdFileOpen.Execute += new System.EventHandler(this.cmdFileOpen_Execute);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(644, 365);
            this.Controls.Add(this.fontToolStrip);
            this.Controls.Add(this.documentToolStrip);
            this.Controls.Add(this.applicationMenus);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Unified Commands Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.applicationMenus.ResumeLayout(false);
            this.applicationMenus.PerformLayout();
            this.documentToolStrip.ResumeLayout(false);
            this.documentToolStrip.PerformLayout();
            this.fontToolStrip.ResumeLayout(false);
            this.fontToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip applicationMenus;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip documentToolStrip;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStrip fontToolStrip;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripLabel fontFaceToolStripLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripLabel fontSizeToolStripLabel;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommandManager unifiedCommandManager1;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand cmdFileOpen;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand cmdFileSave;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand cmdFilePrint;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand cmdFontBold;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand cmdFontItalic;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand cmdFontFace;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand cmdFileSaveAs;
        private Microsoft.Samples.Windows.Forms.UnifiedCommands.UnifiedCommand cmdFontSize;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontFaceToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem arialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tahomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timesNewRomanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courierNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lucidaConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wingDingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verdanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem ptToolStripMenuItem12;
        private System.Windows.Forms.ToolStripButton openDocumentToolStripButton;
        private System.Windows.Forms.ToolStripButton saveDocumentToolStripButton;
        private System.Windows.Forms.ToolStripButton printDocumentToolStripButton;
        private System.Windows.Forms.ToolStripButton bBToolStripButton;
        private System.Windows.Forms.ToolStripButton iIToolStripButton;
        private System.Windows.Forms.ToolStripComboBox faceToolStripComboBox;
        private System.Windows.Forms.ToolStripComboBox fontSizeToolStripComboBox;
    }
}