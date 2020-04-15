using System;
using System.Windows.Forms;
using System.Drawing;

public class frmEdit:System.Windows.Forms.Form 
{

	#region " Windows Form Designer generated code "

	public frmEdit() 
	{
		//This call is required by the Windows Form Designer.

		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	//Form overrides dispose to clean up the component list.

	protected override void Dispose(bool disposing) 
	{

		if (disposing) 
		{

			if (components != null) 
			{

				components.Dispose();

			}

		}

		base.Dispose(disposing);

	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer

	//It can be modified using the Windows Form Designer.  

	//Do not modify it using the code editor.

	private System.Windows.Forms.MainMenu MainMenu1;

	private System.Windows.Forms.MenuItem mnuSave;

	private System.Windows.Forms.MenuItem mnuPrint;

	private System.Windows.Forms.MenuItem mnuEdit;

	private System.Windows.Forms.MenuItem mnuCut;

	private System.Windows.Forms.MenuItem mnuCopy;

	private System.Windows.Forms.MenuItem mnuPaste;

	private System.Windows.Forms.TextBox txtEdit;

	private System.Windows.Forms.MenuItem MenuItem1;

	private System.Windows.Forms.MenuItem MenuItem2;

	private System.Windows.Forms.MenuItem MenuItem3;

	private System.Windows.Forms.MenuItem mnuSize;

	private System.Windows.Forms.MenuItem mnuSmall;

	private System.Windows.Forms.MenuItem mnuMedium;

	private System.Windows.Forms.MenuItem mnuLarge;

	private System.Windows.Forms.MenuItem mnuUndo;

	private System.Windows.Forms.MenuItem mnuFile;

	private void InitializeComponent() 
	{

		System.Resources.ResourceManager resources  = new System.Resources.ResourceManager(typeof(frmEdit));

		this.txtEdit = new System.Windows.Forms.TextBox();

		this.MainMenu1 = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.MenuItem1 = new System.Windows.Forms.MenuItem();

		this.mnuSave = new System.Windows.Forms.MenuItem();

		this.mnuPrint = new System.Windows.Forms.MenuItem();

		this.MenuItem2 = new System.Windows.Forms.MenuItem();

		this.mnuEdit = new System.Windows.Forms.MenuItem();

		this.mnuUndo = new System.Windows.Forms.MenuItem();

		this.mnuCut = new System.Windows.Forms.MenuItem();

		this.mnuCopy = new System.Windows.Forms.MenuItem();

		this.mnuPaste = new System.Windows.Forms.MenuItem();

		this.MenuItem3 = new System.Windows.Forms.MenuItem();

		this.mnuSize = new System.Windows.Forms.MenuItem();

		this.mnuSmall = new System.Windows.Forms.MenuItem();

		this.mnuMedium = new System.Windows.Forms.MenuItem();

		this.mnuLarge = new System.Windows.Forms.MenuItem();

		this.SuspendLayout();

		//

		//txtEdit

		//

		this.txtEdit.Dock = System.Windows.Forms.DockStyle.Fill;

		this.txtEdit.Multiline = true;

		this.txtEdit.Name = "txtEdit";

		this.txtEdit.Size = new System.Drawing.Size(292, 154);

		this.txtEdit.TabIndex = 0;

		this.txtEdit.Text = "";
		this.txtEdit.ModifiedChanged += new EventHandler(txtEdit_ModifiedChanged);

		//

		//MainMenu1

		//

		this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuEdit});

		//

		//mnuFile

		//

		this.mnuFile.Index = 0;

		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuItem1, this.mnuSave, this.mnuPrint, this.MenuItem2});

		this.mnuFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;

		this.mnuFile.Text = "&File";
		this.mnuFile.Popup += new EventHandler(mnuFile_Popup);

		//

		//MenuItem1

		//

		this.MenuItem1.Index = 0;

		this.MenuItem1.MergeOrder = 1;

		this.MenuItem1.Text = "-";

		//

		//mnuSave

		//

		this.mnuSave.Index = 1;

		this.mnuSave.MergeOrder = 2;

		this.mnuSave.MergeType = System.Windows.Forms.MenuMerge.MergeItems;

		this.mnuSave.Text = "&Save";
		this.mnuSave.Click += new EventHandler(mnuSave_Click);

		//

		//mnuPrint

		//

		this.mnuPrint.Index = 2;

		this.mnuPrint.MergeOrder = 3;

		this.mnuPrint.MergeType = System.Windows.Forms.MenuMerge.MergeItems;

		this.mnuPrint.Text = "&Print";
		this.mnuPrint.Click += new EventHandler(mnuPrint_Click);

		//

		//MenuItem2

		//

		this.MenuItem2.Index = 3;

		this.MenuItem2.MergeOrder = 4;

		this.MenuItem2.Text = "-";

		//

		//mnuEdit

		//

		this.mnuEdit.Index = 1;

		this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuUndo, this.mnuCut, this.mnuCopy, this.mnuPaste, this.MenuItem3, this.mnuSize});

		this.mnuEdit.MergeOrder = 5;

		this.mnuEdit.Text = "&Edit";
		this.mnuEdit.Popup += new EventHandler(mnuEdit_Popup);

		//

		//mnuUndo

		//

		this.mnuUndo.Index = 0;

		this.mnuUndo.Text = "&Undo";
		this.mnuUndo.Click += new EventHandler(mnuUndo_Click);

		//

		//mnuCut

		//

		this.mnuCut.Index = 1;

		this.mnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;

		this.mnuCut.Text = "Cu&t";
		this.mnuCut.Click += new EventHandler(mnuCut_Click);

		//

		//mnuCopy

		//

		this.mnuCopy.Index = 2;

		this.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;

		this.mnuCopy.Text = "&Copy";
		this.mnuCopy.Click += new EventHandler(mnuCopy_Click);

		//

		//mnuPaste

		//

		this.mnuPaste.Index = 3;

		this.mnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;

		this.mnuPaste.Text = "&Paste";
		this.mnuPaste.Click += new EventHandler(mnuPaste_Click);

		//

		//MenuItem3

		//

		this.MenuItem3.Index = 4;

		this.MenuItem3.Text = "-";

		//

		//mnuSize

		//

		this.mnuSize.Index = 5;

		this.mnuSize.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuSmall, this.mnuMedium, this.mnuLarge});

		this.mnuSize.Text = "Text &Size";

		//

		//mnuSmall

		//

		this.mnuSmall.Checked = true;

		this.mnuSmall.Index = 0;

		this.mnuSmall.RadioCheck = true;

		this.mnuSmall.Text = "&Small";
		this.mnuSmall.Click += new EventHandler(mnuSmall_Click);

		//

		//mnuMedium

		//

		this.mnuMedium.Index = 1;

		this.mnuMedium.RadioCheck = true;

		this.mnuMedium.Text = "&Medium";
		this.mnuMedium.Click += new EventHandler(mnuMedium_Click);

		//

		//mnuLarge

		//

		this.mnuLarge.Index = 2;

		this.mnuLarge.RadioCheck = true;

		this.mnuLarge.Text = "&Large";
		this.mnuLarge.Click += new EventHandler(mnuLarge_Click);

		//ClearStatus
		this.mnuCopy.Click += new EventHandler(ClearStatus);
		this.mnuCut.Click += new EventHandler(ClearStatus);
		this.mnuEdit.Click += new EventHandler(ClearStatus); 
		this.mnuFile.Click += new EventHandler(ClearStatus);
		this.mnuLarge.Click += new EventHandler(ClearStatus);
		this.mnuMedium.Click += new EventHandler(ClearStatus);
		this.mnuPaste.Click += new EventHandler(ClearStatus);
		this.mnuPrint.Click += new EventHandler(ClearStatus);
		this.mnuSave.Click += new EventHandler(ClearStatus);
		this.mnuSize.Click += new EventHandler(ClearStatus);
		this.mnuSmall.Click += new EventHandler(ClearStatus);
		this.mnuUndo.Click += new EventHandler(ClearStatus);
		
		//HandleStatus
		this.mnuSave.Select += new EventHandler(HandleStatus);
		this.mnuCopy.Select += new EventHandler(HandleStatus);
		this.mnuCut.Select += new EventHandler(HandleStatus);
		this.mnuLarge.Select += new EventHandler(HandleStatus);
		this.mnuMedium.Select += new EventHandler(HandleStatus);
		this.mnuSmall.Select += new EventHandler(HandleStatus);
		this.mnuPrint.Select += new EventHandler(HandleStatus);
		this.mnuPaste.Select += new EventHandler(HandleStatus);
		this.mnuUndo.Select += new EventHandler(HandleStatus);
		this.mnuSize.Select += new EventHandler(HandleStatus);
		this.mnuEdit.Select += new EventHandler(HandleStatus);
		this.mnuFile.Select += new EventHandler(HandleStatus);

		//

		//frmEdit

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(292, 154);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtEdit});

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.Menu = this.MainMenu1;

		this.Name = "frmEdit";

		this.Text = "Demonstrate Menus and Toolbars";

		


		this.ResumeLayout(false);

	}

	#endregion

	private enum FontSize
	{
		Small = 8,
		Medium = 12,
		Large = 16,
	}
    

	private bool mblnModified=false;

	private void mnuCopy_Click(object sender, System.EventArgs e)
	{

		Copy();

	}

	private void mnuCut_Click(object sender, System.EventArgs e)
	{

		Cut();

	}

	private void mnuEdit_Popup(object sender, System.EventArgs e)
	{
		HandleEditItems();

	}

	private void mnuFile_Popup(object sender, System.EventArgs e)
	{
		HandleFileItems();

	}

	private void mnuLarge_Click(object sender, System.EventArgs e)
	{

		SetLargeFont();

	}

	private void mnuMedium_Click(object sender, System.EventArgs e)
	{
		SetMediumFont();

	}

	private void mnuPaste_Click(object sender, System.EventArgs e)
	{
		Paste();

	}

	private void mnuPrint_Click(object sender, System.EventArgs e)
	{
		Print();

	}

	private void mnuSave_Click(object sender, System.EventArgs e)
	{
		Save();

	}

	private void mnuSmall_Click(object sender, System.EventArgs e)
	{
		SetSmallFont();

	}

	private void mnuUndo_Click(object sender, System.EventArgs e)
	{
		Undo();

	}

	private void txtEdit_ModifiedChanged(object sender, System.EventArgs e) 
	{
		// When the text box is modified, set the 

		// mblnModified value.

		mblnModified = true;

	}

	private void ClearStatus(object sender, System.EventArgs e)
	{
		ClearStatusBar();
	}

	private void ClearStatusBar()
	{
		try 
		{
			((frmMain) this.ParentForm).ClearStatusBar();
		}
		catch
		{
			// Do nothing at all if this fails.
		}

	}

	public void Copy()
	{
		txtEdit.Copy();
	}

	public void Cut()
	{
		txtEdit.Cut();

	}

	private void HandleEditItems()
	{

	// Determine if the the Cut/Copy/Paste menu items 
	// should be enabled.
	// Paste is enabled if the Clipboard object contains text.
	IDataObject iData  = Clipboard.GetDataObject();
	mnuPaste.Enabled = iData.GetDataPresent(typeof(string));
	// Cut and Copy are enabled if the text box contains
	// one or more selected characters. 

	bool blnEnable = (txtEdit.SelectedText.Length > 0);
		
	mnuCut.Enabled = blnEnable;
	mnuCopy.Enabled = blnEnable;

	// Handle Undo text.

	if (txtEdit.CanUndo)
	   {
		mnuUndo.Text = "&Undo";
		mnuUndo.Enabled = true;
		}
        else 
		{
            mnuUndo.Text = "null to Undo";
            mnuUndo.Enabled = false;
        }

    }

    private void HandleFileItems()
	{
        mnuPrint.Enabled = (txtEdit.Text.Length > 0);
        mnuSave.Enabled = mblnModified;
    }

    private void HandleStatus(object sender, System.EventArgs e)
	{
        string strText ;

		if (sender == mnuSave) 
		{
			strText = "Save the current contents";

		} 
		else if ( sender == mnuCopy) 
		{
			strText = "Copy selected text to the clipboard";

		} 
		else if ( sender == mnuCut)
		{
			strText = "Cut selected text to the clipboard";
		}
		else if ( sender == mnuLarge)
		{

			strText = "Display text using large font";

		} 
		else if ( sender == mnuMedium)
		{
			strText = "Display text using medium font";

		} 
		else if ( sender == mnuSmall)
		{
			strText = "Display text using small font";

		} 
		else if ( sender == mnuPrint)
		{
			strText = "Print the current contents";

		} 
		else if ( sender == mnuPaste)
		{
			strText = "Paste the contents of the clipboard";

		} 
		else if ( sender == mnuUndo)
		{

			strText = "Undo changes to contents";
		}
		else 
		{

			strText = string.Empty;

		}

		((frmMain) this.ParentForm).WriteToStatusBar(strText);
    }

    public void Paste()
	{
        txtEdit.Paste();
    }

    public void Print()
	{
        MessageBox.Show("Add code to print your document here", this.Text);

    }

    public void Save()
	{	
        MessageBox.Show("Add code to save your document here", this.Text);

    }

    public void SetLargeFont()
	{
        SetSize(FontSize.Large);

    }

    public void SetMediumFont()
	{
        SetSize(FontSize.Medium);

    }

    public void SetSmallFont()
	{
        SetSize(FontSize.Small);

    }

    private void SetSize(FontSize Size )
	{
		Font fnt = new Font(txtEdit.Font.FontFamily, (int) Size);
        txtEdit.Font = fnt;

        // Uncheck them all!

        mnuSmall.Checked = false;

        mnuMedium.Checked = false;

        mnuLarge.Checked = false;

        // Now check the appropriate item.

        switch(Size)
		{
            case FontSize.Small:

                mnuSmall.Checked = true;
				break;

            case FontSize.Medium:

                mnuMedium.Checked = true;
				break;
            case FontSize.Large:

                mnuLarge.Checked = true;
				break;
		}

    }

    public void Undo()
	{
        txtEdit.Undo();

    }

}

