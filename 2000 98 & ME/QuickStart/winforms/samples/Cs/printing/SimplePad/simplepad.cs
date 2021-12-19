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
    using System.Drawing.Printing;
    using System.Collections;
    using System.IO;
    using System.ComponentModel;
    using System.WinForms;

    public class SimplePad : System.WinForms.Form {
        private static readonly string noFilename = "Untitled";
        private static readonly string notDirtyCaptionFormat = "{0} - SimplePad+";
        private static readonly string dirtyCaptionFormat = "{0}* - SimplePad+";
        private string editingFileName = null;
        private bool dirty = false;
        private bool fileOnDiskModified = false;

        private Container components;

        private MenuItem menuItem22;
        private MenuItem selectAllMenu;
        private MenuItem menuItem20;
        private MenuItem gotoMenu;
        private MenuItem menuItem18;
        private MenuItem menuItem17;
        private MenuItem menuItem16;
        private MenuItem menuItem15;
        private MenuItem DeleteMenu;
        private MenuItem pasteMenu;
        private MenuItem copyMenu;
        private MenuItem CutMenu;
        private MenuItem menuItem8;
        private MenuItem UndoMenu;
        private MenuItem optionsMenu;
        private MenuItem menuItem7;
        private MenuItem fontMenu;
        private MenuItem wordWrapMenu;
        private System.WinForms.PrintDialog printDialog1;
        private FontDialog fontDialog1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private StatusBarPanel linePanel;
        private StatusBarPanel statusPanel;
        private StatusBar statusBar1;
        private RichTextBox textArea;
        private MenuItem exitMenu;
        private MenuItem menuItem12;
        private MenuItem printMenu;
        private MenuItem pageSetupMenu;
        private MenuItem menuItem9;
        private MenuItem saveAsMenu;
        private MenuItem saveMenu;
        private MenuItem openMenu;
        private MenuItem newMenu;
        private MenuItem menuItem4;
        private MenuItem menuItem3;
        private MenuItem menuItem2;
        private MenuItem menuItem1;
        private MainMenu mainMenu;
        private MenuItem printPreviewMenu;
        private FileSystemWatcher dirWatcher;
        private PageSettings storedPageSettings = null ;

        public SimplePad() {
            InitializeComponent();
            UpdateFormText();
        }

        protected Size MinTrackSize {
            override get {
                return new Size(100, 100);
            }
        }

        public override void Dispose() {
            base.Dispose();
        }

        private void InitializeComponent() {
            this.components = new Container();
            this.wordWrapMenu = new MenuItem();
            this.mainMenu = new MainMenu();
            this.statusBar1 = new StatusBar();
            this.menuItem4 = new MenuItem();
            this.menuItem20 = new MenuItem();
            this.textArea = new RichTextBox();
            this.linePanel = new StatusBarPanel();
            this.newMenu = new MenuItem();
            this.saveMenu = new MenuItem();
            this.menuItem18 = new MenuItem();
            this.pasteMenu = new MenuItem();
            this.exitMenu = new MenuItem();
            this.statusPanel = new StatusBarPanel();
            this.selectAllMenu = new MenuItem();
            this.gotoMenu = new MenuItem();
            this.DeleteMenu = new MenuItem();
            this.menuItem15 = new MenuItem();
            this.menuItem17 = new MenuItem();
            this.copyMenu = new MenuItem();
            this.menuItem16 = new MenuItem();
            this.optionsMenu = new MenuItem();
            this.menuItem9 = new MenuItem();
            this.saveFileDialog1 = new SaveFileDialog();
            this.fontMenu = new MenuItem();
            this.UndoMenu = new MenuItem();
            this.menuItem12 = new MenuItem();
            this.CutMenu = new MenuItem();
            this.menuItem22 = new MenuItem();
            this.menuItem8 = new MenuItem();
            this.dirWatcher = new FileSystemWatcher();
            this.menuItem7 = new MenuItem();
            this.printMenu = new MenuItem();
            this.printDialog1 = new System.WinForms.PrintDialog();
            this.saveAsMenu = new MenuItem();
            this.fontDialog1 = new FontDialog();
            this.openFileDialog1 = new OpenFileDialog();
            this.menuItem1 = new MenuItem();
            this.openMenu = new MenuItem();
            this.menuItem2 = new MenuItem();
            this.pageSetupMenu = new MenuItem();
            this.menuItem3 = new MenuItem();
            this.printPreviewMenu = new MenuItem();

            dirWatcher.BeginInit();

            wordWrapMenu.BarBreak = false;
            wordWrapMenu.Break = false;
            wordWrapMenu.Text = "&Word Wrap";
            wordWrapMenu.Index = 0;
            wordWrapMenu.DefaultItem = false;
            wordWrapMenu.Click += new EventHandler(WordWrapMenu_Click);

            //@design mainMenu.SetLocation(new Point(643, 7));
            mainMenu.MenuItems.All = new MenuItem[] {menuItem1, menuItem2, menuItem3, menuItem4};

            statusBar1.Location = new Point(0, 379);
            statusBar1.BackColor = SystemColors.Control;
            statusBar1.Size = new Size(512, 20);
            statusBar1.TabIndex = 1;
            statusBar1.ShowPanels = true;
            statusBar1.Text = "statusBar1";
            statusBar1.Panels.All = new StatusBarPanel[] {statusPanel, linePanel};

            menuItem4.BarBreak = false;
            menuItem4.Break = false;
            menuItem4.Text = "&Help";
            menuItem4.Index = 3;
            menuItem4.DefaultItem = false;

            menuItem20.BarBreak = false;
            menuItem20.Break = false;
            menuItem20.Text = "-";
            menuItem20.Index = 11;
            menuItem20.DefaultItem = false;

            textArea.Text = "";
            textArea.Size = new Size(512, 379);
            textArea.TabIndex = 0;
            textArea.Dock = DockStyle.Fill;
            textArea.WordWrap = false;
            textArea.AcceptsTab = true;
            textArea.TextChanged += new EventHandler(this.TextArea_TextChanged);

            this.AutoScaleBaseSize = new Size(6, 16);
            this.Text = "SimplePad+";
            this.Menu = mainMenu;
            this.ClientSize = new Size(512, 399);

            newMenu.BarBreak = false;
            newMenu.Break = false;
            newMenu.Text = "&New";
            newMenu.Shortcut = Shortcut.CtrlN;
            newMenu.Index = 0;
            newMenu.DefaultItem = false;
            newMenu.Click += new EventHandler(NewMenu_Click);

            saveMenu.BarBreak = false;
            saveMenu.Break = false;
            saveMenu.Text = "&Save";
            saveMenu.Shortcut = Shortcut.CtrlS;
            saveMenu.Index = 2;
            saveMenu.DefaultItem = false;
            saveMenu.Click += new EventHandler(SaveMenu_Click);

            pasteMenu.BarBreak = false;
            pasteMenu.Break = false;
            pasteMenu.Text = "&Paste";
            pasteMenu.Index = 4;
            pasteMenu.DefaultItem = false;
            pasteMenu.Shortcut = Shortcut.CtrlV;
            pasteMenu.Click += new EventHandler(PasteMenu_Click);

            exitMenu.BarBreak = false;
            exitMenu.Break = false;
            exitMenu.Text = "E&xit";
            exitMenu.Index = 8;
            exitMenu.DefaultItem = false;
            exitMenu.Click += new EventHandler(ExitMenu_Click);

            statusPanel.Text = "Ready";
            statusPanel.BorderStyle = StatusBarPanelBorderStyle.None;
            statusPanel.Width = 396;
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;

            selectAllMenu.BarBreak = false;
            selectAllMenu.Break = false;
            selectAllMenu.Text = "Select &All";
            selectAllMenu.Index = 12;
            selectAllMenu.DefaultItem = false;
            selectAllMenu.Shortcut = Shortcut.CtrlA;
            selectAllMenu.Click += new EventHandler(this.SelectAllMenu_Click);

            gotoMenu.BarBreak = false;
            gotoMenu.Break = false;
            gotoMenu.Text = "&Go To...";
            gotoMenu.Shortcut = Shortcut.CtrlG;
            gotoMenu.Index = 10;
            gotoMenu.DefaultItem = false;
            gotoMenu.Click += new EventHandler(this.GotoMenu_Click);

            DeleteMenu.BarBreak = false;
            DeleteMenu.Break = false;
            DeleteMenu.Text = "De&lete";
            DeleteMenu.Index = 5;
            DeleteMenu.DefaultItem = false;
            DeleteMenu.Click += new EventHandler(this.DeleteMenu_Click);

            menuItem15.BarBreak = false;
            menuItem15.Break = false;
            menuItem15.Text = "-";
            menuItem15.Index = 6;
            menuItem15.DefaultItem = false;

            copyMenu.BarBreak = false;
            copyMenu.Break = false;
            copyMenu.Text = "&Copy";
            copyMenu.Index = 3;
            copyMenu.DefaultItem = false;
            copyMenu.Shortcut = Shortcut.CtrlC;
            copyMenu.Click += new EventHandler(CopyMenu_Click);

            optionsMenu.BarBreak = false;
            optionsMenu.Break = false;
            optionsMenu.Text = "&Options...";
            optionsMenu.Index = 3;
            optionsMenu.DefaultItem = false;
            optionsMenu.Click += new EventHandler(OptionsMenu_Click);

            menuItem9.BarBreak = false;
            menuItem9.Break = false;
            menuItem9.Text = "-";
            menuItem9.Index = 4;
            menuItem9.DefaultItem = false;

            //@design saveFileDialog1.SetLocation(new Point(590, 7));
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Save As";

            fontMenu.BarBreak = false;
            fontMenu.Break = false;
            fontMenu.Text = "&Font...";
            fontMenu.Index = 1;
            fontMenu.DefaultItem = false;
            fontMenu.Click += new EventHandler(FontMenu_Click);

            UndoMenu.BarBreak = false;
            UndoMenu.Break = false;
            UndoMenu.Text = "&Undo";
            UndoMenu.Index = 0;
            UndoMenu.DefaultItem = false;
            UndoMenu.Shortcut = Shortcut.CtrlZ;
            UndoMenu.Click += new EventHandler(UndoMenu_Click);

            menuItem12.BarBreak = false;
            menuItem12.Break = false;
            menuItem12.Text = "-";
            menuItem12.Index = 7;
            menuItem12.DefaultItem = false;

            CutMenu.BarBreak = false;
            CutMenu.Break = false;
            CutMenu.Text = "Cu&t";
            CutMenu.Index = 2;
            CutMenu.DefaultItem = false;
            CutMenu.Shortcut = Shortcut.CtrlX;
            CutMenu.Click += new EventHandler(CutMenu_Click);

            menuItem8.BarBreak = false;
            menuItem8.Break = false;
            menuItem8.Text = "-";
            menuItem8.Index = 1;
            menuItem8.DefaultItem = false;

            //@design dirWatcher.SetLocation(new Point(696, 7));
            dirWatcher.Changed += new FileSystemEventHandler(DirWatcher_Changed);

            menuItem7.BarBreak = false;
            menuItem7.Break = false;
            menuItem7.Text = "-";
            menuItem7.Index = 2;
            menuItem7.DefaultItem = false;

            printMenu.BarBreak = false;
            printMenu.Break = false;
            printMenu.Text = "&Print...";
            printMenu.Index = 6;
            printMenu.DefaultItem = false;
            printMenu.Shortcut = Shortcut.CtrlP;
            printMenu.Click += new EventHandler(PrintMenu_Click);

            printPreviewMenu.BarBreak = false;
            printPreviewMenu.Break = false;
            printPreviewMenu.Text = "Print Pre&view...";
            printPreviewMenu.Index = 6;
            printPreviewMenu.DefaultItem = false;
            printPreviewMenu.Click += new EventHandler(PrintPreviewMenu_Click);

            //@design printDialog1.SetLocation(new Point(378, 7));

            saveAsMenu.BarBreak = false;
            saveAsMenu.Break = false;
            saveAsMenu.Text = "Save &As...";
            saveAsMenu.Index = 3;
            saveAsMenu.DefaultItem = false;
            saveAsMenu.Click += new EventHandler(SaveAsMenu_Click);

            //@design fontDialog1.SetLocation(new Point(166, 7));
            fontDialog1.ShowColor = true;
            fontDialog1.ShowEffects = true;

            //@design openFileDialog1.SetLocation(new Point(484, 7));
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
            openFileDialog1.Title = "Open";
            openFileDialog1.DefaultExt = ".rtf";

            menuItem1.BarBreak = false;
            menuItem1.Break = false;
            menuItem1.Text = "&File";
            menuItem1.Index = 0;
            menuItem1.DefaultItem = false;
            menuItem1.MenuItems.All = new MenuItem[] {newMenu, openMenu, saveMenu, saveAsMenu, menuItem9, printMenu, printPreviewMenu, pageSetupMenu, menuItem12, exitMenu};

            openMenu.BarBreak = false;
            openMenu.Break = false;
            openMenu.Text = "&Open...";
            openMenu.Index = 1;
            openMenu.Shortcut = Shortcut.CtrlO;
            openMenu.DefaultItem = false;
            openMenu.Click += new EventHandler(OpenMenu_Click);

            menuItem2.BarBreak = false;
            menuItem2.Break = false;
            menuItem2.Text = "&Edit";
            menuItem2.Index = 1;
            menuItem2.DefaultItem = false;
            menuItem2.MenuItems.All = new MenuItem[] {UndoMenu, menuItem8, CutMenu, copyMenu, pasteMenu, DeleteMenu, menuItem15, gotoMenu, menuItem20, selectAllMenu};

            pageSetupMenu.BarBreak = false;
            pageSetupMenu.Break = false;
            pageSetupMenu.Text = "Page Set&up...";
            pageSetupMenu.Index = 5;
            pageSetupMenu.DefaultItem = false;
            pageSetupMenu.Click += new EventHandler(PageSetupMenu_Click);

            menuItem3.BarBreak = false;
            menuItem3.Break = false;
            menuItem3.Text = "F&ormat";
            menuItem3.Index = 2;
            menuItem3.DefaultItem = false;
            menuItem3.MenuItems.All = new MenuItem[] {wordWrapMenu, fontMenu, menuItem7, optionsMenu};

            this.Controls.Add(statusBar1);
            this.Controls.Add(textArea);

            dirWatcher.EndInit();
        }

        private void PromptForReload() {
            fileOnDiskModified = false;

            System.WinForms.DialogResult dr = MessageBox.Show(this, 
                "The current file has been changed, do you want to reload it?",
                "File Change Notification",
                MessageBox.YesNo | MessageBox.IconQuestion);

            if (dr == System.WinForms.DialogResult.Yes) {

                ReadEditingFile();
            }
        }

        protected override void OnActivated(EventArgs e) {
            base.OnActivated(e);

            if (fileOnDiskModified) {
                PromptForReload();
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

            if (dirty) {
                System.WinForms.DialogResult dr = MessageBox.Show(this,
                    "Do you want to save the current changes?",
                    "Save Changes?",
                    MessageBox.YesNoCancel | MessageBox.IconQuestion);

                switch (dr) {
                    case System.WinForms.DialogResult.Yes:
                        Save();
                        break;
                    case System.WinForms.DialogResult.No:
                        break;
                    case System.WinForms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void DirWatcher_Changed(object sender, FileSystemEventArgs e) {
            if (this.ContainsFocus) {
                PromptForReload();
            }
            else {
                fileOnDiskModified = true;
            }
        }

        private void TextArea_TextChanged(object sender, EventArgs e) {
            if (!dirty) {
                dirty = true;
                UpdateFormText();
            }
        }

        private void SaveAs() {
            System.WinForms.DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == System.WinForms.DialogResult.OK) {
                editingFileName = saveFileDialog1.FileName;
                dirWatcher.Enabled = false;
                dirWatcher.Path = File.GetDirectoryNameFromPath(editingFileName);
                dirWatcher.Filter = File.GetFileNameFromPath(editingFileName);
                Save();
                UpdateFormText();
            }
        }

        private void Save() {

            if (editingFileName == null || editingFileName.Length < 1) {
                SaveAs();
                return;
            }

            dirWatcher.Enabled = false;
            FileStream fs = null;
            try {
                if (File.FileExists(editingFileName)) {
                    fs = new FileStream(editingFileName, FileMode.Open);
                }
                else {
                    fs = new FileStream(editingFileName, FileMode.Create);
                }

                string fext = File.GetExtension(editingFileName).ToUpper();

                Console.WriteLine(editingFileName);

                if (fext.Equals(".RTF")) 
                    textArea.SaveFile(fs, RichTextBoxStreamType.RichText);
                else
                    textArea.SaveFile(fs, RichTextBoxStreamType.PlainText);

            }
            finally {
                if (fs != null) {
                    fs.Flush();
                    fs.Close();
                    dirty = false;
                }
                dirWatcher.Enabled = true;
            }
        }

        private void ExitMenu_Click(object sender, EventArgs e) {
            this.Close();
        }



        private void SaveMenu_Click(object sender, EventArgs e) {
            Save();
        }

        private void Goto(int line) {
            string text = textArea.Text;
            int cur = 0;
            for (int i=1; i<line; i++) {
                int next = text.IndexOf("\n", cur + 1);
                if (next == -1) {
                    break;
                }
                cur = next;
            }
            if (line > 1) {
                textArea.Select(cur - (line - 2), 0);
            }
            else {
                textArea.Select(cur, 0);
            }
        }

        private int GetCurrentLine() {
            char[] text = textArea.Text.ToCharArray();
            int cur = textArea.SelectionStart;
            int line = 1;
            for (int i=0; i<cur; i++) {
                if (text[i] == '\n') {
                    cur++;
                    line++;
                }
            }
            return line;
        }

        private void GotoMenu_Click(object sender, EventArgs e) {
            System.WinForms.DialogResult dr;
            GotoForm f = new GotoForm();
            f.Line = GetCurrentLine();
            dr = f.ShowDialog(this);
            if (dr == System.WinForms.DialogResult.OK) {
                Goto(f.Line);
            }
        }

        private void SaveAsMenu_Click(object sender, EventArgs e) {
            SaveAs();
        }

        private void WordWrapMenu_Click(object sender, EventArgs e) {
            wordWrapMenu.Checked = !wordWrapMenu.Checked;
            textArea.WordWrap = wordWrapMenu.Checked;
        }

        private void NewMenu_Click(object sender, EventArgs e) {
            MessageBox.Show("Not implemented");
        }

        private void OpenMenu_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == System.WinForms.DialogResult.OK) {
                editingFileName = openFileDialog1.FileName;
                ReadEditingFile();
            }
        }

        private void FontMenu_Click(object sender, EventArgs e) {
            if (fontDialog1.ShowDialog() == System.WinForms.DialogResult.OK) {
                textArea.SelectionFont = fontDialog1.Font;
                textArea.SelectionColor = fontDialog1.Color;
            }
        }

        private void OptionsMenu_Click(object sender, EventArgs e) {
            OptionsForm f = new OptionsForm(new SimplePadOptions(this));
            f.ShowDialog(this);
        }

        private void CutMenu_Click(object sender, EventArgs e) {
            if (textArea.SelectedText.Equals("")) return;
            Clipboard.SetDataObject(textArea.SelectedRTF,true);
            textArea.SelectedRTF = "" ;
        }

        private void UndoMenu_Click(object sender, EventArgs e) {
            textArea.Undo();
        }

        private void CopyMenu_Click(object sender, EventArgs e) {
            if (textArea.SelectedText.Equals("")) return;
            Clipboard.SetDataObject(textArea.SelectedRTF,true);
        }

        private void SelectAllMenu_Click(object sender, EventArgs e) {
            textArea.SelectAll();
        }

        private void DeleteMenu_Click(object sender, EventArgs e) {
            textArea.SelectedRTF = "" ;
        }

        private void PasteMenu_Click(object sender, EventArgs e) {
            try {
                 DataObject data = (DataObject)Clipboard.GetDataObject();
                 if (data.GetDataPresent(DataFormats.RTF)) {
                     string text = (string)data.GetData(DataFormats.RTF);
                     if (!text.Equals("")) textArea.SelectedRTF = text;
                 }
                 else if (data.GetDataPresent(DataFormats.Text)) {
                     string text = (string)data.GetData(DataFormats.Text);
                     if (!text.Equals("")) textArea.SelectedText = text;
                 }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void PrintMenu_Click(object sender, EventArgs e) {
            StringReader streamToPrint = new StringReader (textArea.Text);
            TextPrintDocument pd = new TextPrintDocument(streamToPrint); //Assumes the default printer

            if (storedPageSettings != null) {
                pd.DefaultPageSettings = storedPageSettings ;
            }
           
            PrintDialog dlg = new PrintDialog() ;
            dlg.Document = pd;
            DialogResult result = dlg.ShowDialog();
           
            if (result == DialogResult.OK) {
                pd.Print();
            }
        }

        private void PageSetupMenu_Click(object sender, EventArgs e) {
            try {
                PageSetupDialog psDlg = new PageSetupDialog() ;
            
                if (storedPageSettings == null) {
                    storedPageSettings =  new PageSettings();
                }

                psDlg.PageSettings = storedPageSettings ;
                psDlg.ShowDialog();
            
            } catch(Exception ex) { 
                MessageBox.Show("An error occurred - " + ex.Message);
            }
        }

        private void PrintPreviewMenu_Click(object sender, EventArgs e) {

            try {
                StringReader streamToPrint = new StringReader (textArea.Text);
                TextPrintDocument pd = new TextPrintDocument(streamToPrint); //Assumes the default printer

                if (storedPageSettings != null) {
                    pd.DefaultPageSettings = storedPageSettings ;
                }

                PrintPreviewDialog dlg = new PrintPreviewDialog() ;
                dlg.Document = pd;
                dlg.ShowDialog();
            } catch(Exception ex) { 
                MessageBox.Show("An error occurred attempting to preview the file to print - " + ex.Message);
            }

        }


        private void ReadEditingFile() {
            textArea.TextChanged -= new EventHandler(this.TextArea_TextChanged);
            dirWatcher.Enabled = false;
            try {

                Stream s = new FileStream(editingFileName, FileMode.Open);
                
                string fext = File.GetExtension(editingFileName).ToUpper();

                if (fext.Equals(".RTF")) 
                    textArea.LoadFile(s, RichTextBoxStreamType.RichText);
                else
                    textArea.LoadFile(s, RichTextBoxStreamType.PlainText);

                s.Close();

                dirWatcher.Path = File.GetDirectoryNameFromPath(editingFileName);
                dirWatcher.Filter = File.GetFileNameFromPath(editingFileName);

                dirty = false;
                UpdateFormText();
            }
            finally {
                textArea.TextChanged += new EventHandler(this.TextArea_TextChanged);
                dirWatcher.Enabled = true;
            }
        }

        private void UpdateFormText() {
            string file = noFilename;
            if (editingFileName != null && editingFileName.Length > 1) {
                file = editingFileName;
            }

            if (dirty) {
                this.Text = string.Format(dirtyCaptionFormat, file);
            }
            else {
                this.Text = string.Format(notDirtyCaptionFormat, file);
            }
        }

        public static void Main(string[] args) {
            Application.Run(new SimplePad());
        }

        internal class SimplePadOptions {
            private SimplePad owner;

            public SimplePadOptions(SimplePad owner) {
                this.owner = owner;
            }

            [
                Description("Color used for the background of the text"),
                Category("Text Display")
            ]
            public Color BackColor {
                get {
                    return owner.textArea.BackColor;
                }
                set {
                    owner.textArea.BackColor = value;
                }
            }

            [
                Description("Color used for the forecolor of the text"),
                Category("Text Display")
            ]
            public Color ForeColor {
                get {
                    return owner.textArea.ForeColor;
                }
                set {
                    owner.textArea.ForeColor = value;
                }
            }

            [
                Description("Adjusts the font used to display text in SimplePad+"),
                Category("Text Display")
            ]
            public Font DefaultFont {
                get {
                    return owner.textArea.Font;
                }
                set {
                    owner.textArea.Font = value;
                }
            }

            [
                Description("Determines if text will word wrap"),
                Category("Text Display"),
                DefaultValue(false)
            ]
            public bool WordWrap {
                get {
                    return owner.wordWrapMenu.Checked;
                }
                set {
                    owner.wordWrapMenu.Checked = owner.textArea.WordWrap = value;
                }
            }

            [
                Description("Modifies the opacity of SimplePad+. Windows 2000 only."),
                Category("Application"),
                TypeConverterAttribute(typeof(OpacityConverter)),
                DefaultValue(1.0)
            ]
            public double Opacity {
                get {
                    return owner.Opacity;
                }
                set {
                    owner.Opacity = value;
                }
            }
        }
    }
}
