//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.

//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 

//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 

//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.IO;
using System;
using System.Windows.Forms;


public class frmMain : System.Windows.Forms.Form
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code ";

    public frmMain()
	{

        //This call is required by the Windows Form Designer.

        InitializeComponent();

        //Add any initialization after the InitializeComponent() call
        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        // to read the AssemblyTitle attribute.

        AssemblyInfo ainfo = new AssemblyInfo();

        this.Text = ainfo.Title;
        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

    }

    //Form overrides dispose to clean up the component list.

    protected override void Dispose(bool disposing)
	{

        if (disposing) 
		{
            if(components != null) 
			{
                components.Dispose();
            }
        }

        base.Dispose(disposing);
    }

    //Required by the Windows Form Designer

    private System.ComponentModel.IContainer components;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.

    internal  System.Windows.Forms.MainMenu mnuMain;

    internal  System.Windows.Forms.MenuItem mnuFile;

    internal System.Windows.Forms.MenuItem mnuExit ;

    internal System.Windows.Forms.MenuItem mnuHelp;

    internal System.Windows.Forms.MenuItem mnuAbout;

    internal System.Windows.Forms.Label lblPath;

    internal System.Windows.Forms.TextBox txtPath;

    internal System.Windows.Forms.CheckBox chkEvents;

    internal System.Windows.Forms.TextBox txtFilter;

    internal System.Windows.Forms.Label lblFilter;

    internal System.Windows.Forms.CheckBox chkIncludeSubdirectories;

    internal System.Windows.Forms.CheckedListBox clstNotifyFilter;

    internal System.Windows.Forms.Label lblNotifyFilter;

    internal System.IO.FileSystemWatcher fsw;

    internal System.Windows.Forms.Button btnClear;

    internal System.Windows.Forms.ListBox lstEvents;

    internal System.Windows.Forms.Label Label1;

    internal System.Windows.Forms.Button btnCreate;

    internal System.Windows.Forms.ComboBox cboSampleFile;

    internal System.Windows.Forms.Button btnRename;

    internal System.Windows.Forms.Button btnModify;

    internal System.Windows.Forms.Button btnDelete;

    internal System.Windows.Forms.Button btnDeleteAll;

    private void InitializeComponent()
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.lblPath = new System.Windows.Forms.Label();

        this.txtPath = new System.Windows.Forms.TextBox();

        this.chkEvents = new System.Windows.Forms.CheckBox();

        this.txtFilter = new System.Windows.Forms.TextBox();

        this.lblFilter = new System.Windows.Forms.Label();

        this.chkIncludeSubdirectories = new System.Windows.Forms.CheckBox();

        this.clstNotifyFilter = new System.Windows.Forms.CheckedListBox();

        this.lblNotifyFilter = new System.Windows.Forms.Label();

        this.btnDelete = new System.Windows.Forms.Button();

        this.btnModify = new System.Windows.Forms.Button();

        this.btnRename = new System.Windows.Forms.Button();

        this.cboSampleFile = new System.Windows.Forms.ComboBox();

        this.btnCreate = new System.Windows.Forms.Button();

        this.Label1 = new System.Windows.Forms.Label();

        this.btnClear = new System.Windows.Forms.Button();

        this.lstEvents = new System.Windows.Forms.ListBox();

        this.fsw = new System.IO.FileSystemWatcher();

        this.btnDeleteAll = new System.Windows.Forms.Button();

        ((System.ComponentModel.ISupportInitialize)(this.fsw)).BeginInit()  ;

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

        //

        //mnuFile

        //

        this.mnuFile.Index = 0;

        this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.mnuFile.Text = "&File";

        //

        //mnuExit

        //

        this.mnuExit.Index = 0;

        this.mnuExit.Text = "E&xit";
		this.mnuExit.Click+=new EventHandler(mnuExit_Click);

        //

        //mnuHelp

        //

        this.mnuHelp.Index = 1;

        this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.mnuHelp.Text = "&Help";

        //

        //mnuAbout

        //

        this.mnuAbout.Index = 0;

        this.mnuAbout.Text = "Text Comes from AssemblyInfo";

		this.mnuAbout.Click+=new EventHandler(mnuAbout_Click);
        //

        //lblPath

        //

        this.lblPath.Location = new System.Drawing.Point(8, 8);

        this.lblPath.Name = "lblPath";

        this.lblPath.Size = new System.Drawing.Size(64, 23);

        this.lblPath.TabIndex = 0;

        this.lblPath.Text = "Path";

        this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //txtPath

        //

        this.txtPath.Location = new System.Drawing.Point(80, 8);

        this.txtPath.Name = "txtPath";

        this.txtPath.Size = new System.Drawing.Size(136, 20);

        this.txtPath.TabIndex = 1;

        this.txtPath.Text = @"C:\";

        //

        //chkEvents

        //

        this.chkEvents.Appearance = System.Windows.Forms.Appearance.Button;

        this.chkEvents.Location = new System.Drawing.Point(80, 208);

        this.chkEvents.Name = "chkEvents";

        this.chkEvents.Size = new System.Drawing.Size(144, 24);

        this.chkEvents.TabIndex = 2;

        this.chkEvents.Text = "&Enable Raising Events";

        this.chkEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

		this.chkEvents.CheckedChanged+=new EventHandler(chkEvents_CheckedChanged);

        //

        //txtFilter

        //

        this.txtFilter.Location = new System.Drawing.Point(80, 32);

        this.txtFilter.Name = "txtFilter";

        this.txtFilter.Size = new System.Drawing.Size(136, 20);

        this.txtFilter.TabIndex = 4;

        this.txtFilter.Text = "*.*";

        //

        //lblFilter

        //

        this.lblFilter.Location = new System.Drawing.Point(8, 32);

        this.lblFilter.Name = "lblFilter";

        this.lblFilter.Size = new System.Drawing.Size(64, 23);

        this.lblFilter.TabIndex = 3;

        this.lblFilter.Text = "Filter";

        this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //chkIncludeSubdirectories

        //

        this.chkIncludeSubdirectories.Location = new System.Drawing.Point(80, 184);

        this.chkIncludeSubdirectories.Name = "chkIncludeSubdirectories";

        this.chkIncludeSubdirectories.Size = new System.Drawing.Size(144, 24);

        this.chkIncludeSubdirectories.TabIndex = 5;

        this.chkIncludeSubdirectories.Text = "Include voiddirectories";

        //

        //clstNotifyFilter

        //

        this.clstNotifyFilter.CheckOnClick = true;

        this.clstNotifyFilter.Location = new System.Drawing.Point(80, 56);

        this.clstNotifyFilter.Name = "clstNotifyFilter";

        this.clstNotifyFilter.Size = new System.Drawing.Size(136, 124);

        this.clstNotifyFilter.TabIndex = 6;

        //

        //lblNotifyFilter

        //

        this.lblNotifyFilter.Location = new System.Drawing.Point(8, 56);

        this.lblNotifyFilter.Name = "lblNotifyFilter";

        this.lblNotifyFilter.Size = new System.Drawing.Size(64, 23);

        this.lblNotifyFilter.TabIndex = 7;

        this.lblNotifyFilter.Text = "Notify Filter";

        this.lblNotifyFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //btnDelete

        //

        this.btnDelete.Enabled = false;

        this.btnDelete.Location = new System.Drawing.Point(272, 104);

        this.btnDelete.Name = "btnDelete";

        this.btnDelete.Size = new System.Drawing.Size(160, 23);

        this.btnDelete.TabIndex = 8;

        this.btnDelete.Text = "Delete Sample File";

		this.btnDelete.Click+=new EventHandler(btnDelete_Click);

        //

        //btnModify

        //

        this.btnModify.Enabled = false;

        this.btnModify.Location = new System.Drawing.Point(272, 80);

        this.btnModify.Name = "btnModify";

        this.btnModify.Size = new System.Drawing.Size(160, 23);

        this.btnModify.TabIndex = 7;

        this.btnModify.Text = "Modify Sample File";

		this.btnModify.Click+=new EventHandler(btnModify_Click);

        //

        //btnRename

        //

        this.btnRename.Enabled = false;

        this.btnRename.Location = new System.Drawing.Point(272, 56);

        this.btnRename.Name = "btnRename";

        this.btnRename.Size = new System.Drawing.Size(160, 23);

        this.btnRename.TabIndex = 6;

        this.btnRename.Text = "Rename Sample File";

		this.btnRename.Click+=new EventHandler(btnRename_Click);

        //

        //cboSampleFile

        //

        this.cboSampleFile.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right);

        this.cboSampleFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        this.cboSampleFile.Location = new System.Drawing.Point(272, 8);

        this.cboSampleFile.Name = "cboSampleFile";

        this.cboSampleFile.Size = new System.Drawing.Size(400, 21);

        this.cboSampleFile.TabIndex = 5;

		this.cboSampleFile.SelectedIndexChanged+=new EventHandler(cboSampleFile_SelectedIndexChanged);

        //

        //btnCreate

        //

        this.btnCreate.Location = new System.Drawing.Point(272, 32);

        this.btnCreate.Name = "btnCreate";

        this.btnCreate.Size = new System.Drawing.Size(160, 23);

        this.btnCreate.TabIndex = 4;

        this.btnCreate.Text = "Create Sample File";

		this.btnCreate.Click+=new EventHandler(btnCreate_Click);

        //

        //Label1

        //

        this.Label1.Location = new System.Drawing.Point(232, 8);

        this.Label1.Name = "Label1";

        this.Label1.Size = new System.Drawing.Size(32, 23);

        this.Label1.TabIndex = 2;

        this.Label1.Text = "File";

        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //btnClear

        //

        this.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

        this.btnClear.Location = new System.Drawing.Point(440, 208);

        this.btnClear.Name = "btnClear";

        this.btnClear.Size = new System.Drawing.Size(88, 23);

        this.btnClear.TabIndex = 1;

        this.btnClear.Text = "&Clear";

		this.btnClear.Click+=new EventHandler(btnClear_Click);

        //

        //lstEvents

        //

        this.lstEvents.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right);

        this.lstEvents.IntegralHeight = false;

        this.lstEvents.Location = new System.Drawing.Point(440, 32);

        this.lstEvents.Name = "lstEvents";

        this.lstEvents.Size = new System.Drawing.Size(232, 168);

        this.lstEvents.TabIndex = 0;

        //

        //fsw

        //

        this.fsw.Path = @"C:\";

        this.fsw.SynchronizingObject = this;

        //

        //btnDeleteAll

        //

        this.btnDeleteAll.Location = new System.Drawing.Point(272, 128);

        this.btnDeleteAll.Name = "btnDeleteAll";

        this.btnDeleteAll.Size = new System.Drawing.Size(160, 23);

        this.btnDeleteAll.TabIndex = 9;

        this.btnDeleteAll.Text = "Delete All Sample Files";

		this.btnDeleteAll.Click+=new EventHandler(btnDeleteAll_Click);

		//

		//fsw

		//
		fsw.Error+=new ErrorEventHandler(fsw_Error);
		fsw.Renamed+=new RenamedEventHandler(fsw_Renamed);
		fsw.Changed+=new FileSystemEventHandler(HandleChangedCreatedDeleted); 
		fsw.Created+=new FileSystemEventHandler(HandleChangedCreatedDeleted); 
		fsw.Deleted+=new FileSystemEventHandler(HandleChangedCreatedDeleted); 


        //

        //frmMain

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(674, 233);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnDeleteAll, this.chkIncludeSubdirectories, this.lblPath, this.clstNotifyFilter, this.lblNotifyFilter, this.txtFilter, this.txtPath, this.lblFilter, this.chkEvents, this.Label1, this.btnClear, this.btnCreate, this.btnModify, this.btnDelete, this.cboSampleFile, this.lstEvents, this.btnRename});

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.MaximizeBox = false;

        this.Menu = this.mnuMain;

        this.MinimumSize = new System.Drawing.Size(682, 280);

        this.Name = "frmMain";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        this.Text = "Title Comes from Assembly Info";

        ((System.ComponentModel.ISupportInitialize) (this.fsw)).EndInit() ;

        this.ResumeLayout(false);

		this.Load+=new EventHandler(frmMain_Load);

    }

#endregion;

#region " Standard Menu Code ";

    // <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are

    // not the focus of the demo. Remove them if you wish to debug the procedures.

    // This code simply shows the About form.

    private void mnuAbout_Click(object sender, System.EventArgs e) 
	{
        // Open the About form in Dialog Mode

        frmAbout frm = new frmAbout();
        frm.ShowDialog(this);
        frm.Dispose();

    }

    // This code will close the form.

    private void mnuExit_Click(object sender, System.EventArgs e)
	{

        // Close the current form
        this.Close();

    }

#endregion;

    // When the code creates temporary files, it will use this 
    // name as its root.

    private const string FILE_ROOT  = "Tempfile.txt";

    private void btnClear_Click(object sender, System.EventArgs e)
	{

        // Clear the list of file events.

        lstEvents.Items.Clear();

    }

    private void btnCreate_Click(object sender, System.EventArgs e)
	{

		try 
		{

			string strFile  = GetUniqueFileName(fsw.Path, FILE_ROOT);

			// Create the file and immediately close it.
			File.Create(strFile).Close();
            
			// Add the new file to the combo box.
			cboSampleFile.Items.Add(strFile);
			cboSampleFile.Text = strFile;

			// Enable and disable buttons.

			HandleItems();
		}
        catch (Exception exp)
		{

            MessageBox.Show(exp.Message, this.Text);

        }

    }

    private void btnDelete_Click(object sender, System.EventArgs e)
	{

        string strName = cboSampleFile.Text;

        // if the file still exists, delete it, and fix up the combo box to match.

        if (CheckFile(strName))
		{

			try 
			{

				File.Delete(strName);
				RemoveFileName(strName);
				HandleItems();
			}

			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, this.Text);

			}

        }

    }

    private void btnModify_Click(object sender, System.EventArgs e)
	{

        string strName  = cboSampleFile.Text;

        // if the file still exists, modify it.

        if (CheckFile(strName))
		{

			try 
			{

				FileStream fs = new FileStream(cboSampleFile.Text, FileMode.Append);

				StreamWriter sw = new StreamWriter(fs);

				sw.WriteLine("This is more text");

				sw.Close();

				fs.Close();
			}

            catch (Exception exp)
			{

                MessageBox.Show(exp.Message, this.Text);
            }

        }

    }

    private void btnRename_Click(object sender, System.EventArgs e)
	{

        string strOld ;
        string strnew ;

        // if the file still exists, rename it.

        strOld = cboSampleFile.Text;

        if (CheckFile(strOld))
		{

            strnew = GetUniqueFileName(Path.GetDirectoryName(strOld), Path.GetFileName(strOld));

			try 
			{

				File.Move(strOld, strnew);
				cboSampleFile.Items.Remove(strOld);
				cboSampleFile.Items.Add(strnew);
				cboSampleFile.Text = strnew;
			}
			catch (Exception exp)
			{

				MessageBox.Show(exp.Message, this.Text);

			}

        }

    }

    private void cboSampleFile_SelectedIndexChanged(object sender, System.EventArgs e)
	{

        // Check to make sure the selected file is still around. if not, 
        // ask to have it removed.

        CheckFile(cboSampleFile.Text);
        HandleItems();

    }

    private void chkEvents_CheckedChanged(object sender, System.EventArgs e)
	{

        bool blnIsRunning;

        if (chkEvents.Checked) 
		{
			try 
			{

				GatherFSWProperties(fsw);
			}

			catch (Exception exp)
			{

				MessageBox.Show(exp.Message, this.Text);
				chkEvents.Checked = false;
			}

        }

        // == the FileSystemWatcher component
        // monitoring file changes?

        blnIsRunning = chkEvents.Checked;
        fsw.EnableRaisingEvents = blnIsRunning;

        // if the events are enabled, disable
        // all the controls for gathering properties.
        // Otherwise, enable the controls.

        txtPath.Enabled = ! blnIsRunning;

        txtFilter.Enabled = ! blnIsRunning;

        chkIncludeSubdirectories.Enabled = ! blnIsRunning;

        clstNotifyFilter.Enabled = ! blnIsRunning;

    }

    private void frmMain_Load(object sender, System.EventArgs e)
	{

        // Add the names from the enum to the CheckedListBox
        // control. You can bind the data source to the return 
        // value from the GetValues method, supplying an enumeration type.
        // The GetValues method comes from the System.enum namespace. It 
        // requires an enumeration type, and returns an array of values
        // corresponding to the items in the enumeration. This adds the 
        // list of NotifyFilter values to the CheckedListBox control.

        clstNotifyFilter.DataSource = System.Enum.GetValues(typeof(NotifyFilters));
		
        // Display all the properties of the FileSystemWatcher object.

        DisplayFSWProperties(fsw);

    }

    private void fsw_Error(Object sender , System.IO.ErrorEventArgs e )
		{

        Exception exp  = e.GetException();
        AddItem(exp.Message);

		}

    private void fsw_Renamed(Object sender , System.IO.RenamedEventArgs e )
	{
        string strText  = string.Format("{0} was renamed to {1}", e.OldName, e.Name);
        AddItem(strText);

    }

    private void AddItem(string strText )
	{
        lstEvents.Items.Add(strText);
    }

    private bool CheckFile(string strFileName )
	{

        // Check to make sure the selected file is still around. if not, 
        // ask to have it removed.

		if (File.Exists(strFileName))
		{
			return true;
		}

		else 
		{

			MessageBox.Show("The selected file has been deleted. It will be removed from this list as well.");

			RemoveFileName(strFileName);

			HandleItems();

			return false;

		}

    }

    private void DisplayFSWProperties(FileSystemWatcher fsw )
	{
		
        SetChecks((int) fsw.NotifyFilter, clstNotifyFilter);
        txtPath.Text = fsw.Path;
        txtFilter.Text = fsw.Filter;
        chkEvents.Checked = fsw.EnableRaisingEvents;
        chkIncludeSubdirectories.Checked = fsw.IncludeSubdirectories;

    }

    private void GatherFSWProperties(FileSystemWatcher fsw )
	{

        // This code may raise errors, but the caller will
        // need to catch them!

        fsw.Path = txtPath.Text;
        fsw.Filter = txtFilter.Text;
        fsw.IncludeSubdirectories = chkIncludeSubdirectories.Checked;
        fsw.NotifyFilter = (NotifyFilters) GetChecks(clstNotifyFilter);

    }

    private int GetChecks(CheckedListBox clst )
	{

        // Loop through all the items in the CheckedListBox, 
        // and generate an integer value corresponding to all the 
        // selected bits. Each item in the CheckedListBox is actually
        // an integer (from an enumeration), so you simply need
        // to convert each object into an integer, then OR it with 
        // the result.

        int intValue=0;


        try 
		{

            foreach (Object obj in clst.CheckedItems)
			{
				intValue = intValue | (int) obj;
				
			}

				return intValue;
			}
        catch (Exception exp)
		{
            MessageBox.Show(exp.Message, this.Text);
			return intValue;
		
        }

    }

    private string GetUniqueFileName(string Path , string Root )
	{

        // Generate a unique file name, using Root as the file name root, in the 
        // specified path. For example, if Path is C:\ and Root is TempFile.txt,
        // the procedure will attempt to return C:\TempFile.txt.00. if that file 
        // exists, it will attempt to return C:\TempFile.txt.01, incrementing
        // the value until it finds a name that doesn't already exist.

        string strTemp;
        int i = 0;

        // Remove \ or space from the end of the path.
        // Remove . or space from the end of the file name.

        Path = Path.TrimEnd(@"\ ".ToCharArray());
        Root = Root.TrimEnd(@". ".ToCharArray());

        // Loop, incrementing a counter, until you find 
        // a file that doesn't already exist.

        do
		{
			strTemp = string.Format(@"{0}\{1}.{2:00}", Path, Root, i);
			i += 1;
		}
        while (File.Exists(strTemp) && i < 100);
        return strTemp;

        // if you had 100 of these files already, you'll end up overwriting
        // .99. Sorry.
    }

    private void HandleChangedCreatedDeleted(Object sender ,  System.IO.FileSystemEventArgs e)
	{
        // This one procedure can handle the Changed, Created, and Deleted events, 
        // because they all have the same event signature.

        string strText  = string.Format("{0} was {1}", e.Name, e.ChangeType);

        AddItem(strText);

    }

    private void HandleItems()
	{

        // Enable or Disable buttons.
        bool blnEnable  = (cboSampleFile.Text != string.Empty);

        btnModify.Enabled = blnEnable;
        btnDelete.Enabled = blnEnable;
        btnRename.Enabled = blnEnable;

    }

    private void RemoveFileName(string strFileName )
	{

        // Remove the specified file name from 
        // the combo box. if there are other file names
        // to be had, select the first one.

        cboSampleFile.Items.Remove(strFileName);

        if (cboSampleFile.Items.Count > 0)
		{

            cboSampleFile.Text = cboSampleFile.Items[0].ToString();

        }

    }

    private void SetChecks(int Value , CheckedListBox clst )
	{

        int intValue;
        bool blnCheck;

        // Loop through each item in the CheckedListBox control.
        // For each item, if the bit corresponding to the 
        // current enumerated value is set, check the 
        // corresponding item in the list.

        for (int i = 0; i<= clst.Items.Count - 1;i++)
		{
		intValue = (int) (clst.Items[i]);

		blnCheck =  ((intValue & Value) == intValue);

		clst.SetItemChecked(i, blnCheck);
		
		}
    }

    private void btnDeleteAll_Click(object sender, System.EventArgs e) 
	{

        // Delete all the files in the combo box.

		foreach (string strName in cboSampleFile.Items)
		{

			try 
			{
				File.Delete(strName);
			}
			catch
			{

				// if you can't delete the file, it must 
				// already be deleted. Just go on.
			}

		}

        cboSampleFile.Items.Clear();

        HandleItems();

    }

}

