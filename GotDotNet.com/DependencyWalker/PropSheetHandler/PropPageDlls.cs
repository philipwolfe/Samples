using System;
using System.IO; 
using System.Resources;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Microsoft.PDC01Demo.PropSheetHandler
{

/// <summary>
/// Handles property page creation for managed DLLs. Creates
/// controls and shows list of assemblies that are referenced
/// by the selected one.
/// </summary>

public class PropPageDlls : PropPage
{
	protected Label			lblStatReferences;
	protected Label			lblMessage;
	protected TreeView		tvAllRefs;
	protected ImageList		imageList1;
	protected IContainer	components;


	protected AppDomain		helpAppDomain = null;	// Helper AppDomain for inspecting selected assembly
	protected AssemblyName[] staticRefs = null;		// List of references

	//-------------------------------------------------
	//-------------------------------------------------
	public PropPageDlls(String fileName): base(fileName)
	{
	}

    //-------------------------------------------------
    // Creates all the controls for the 
    // property sheet and places them on the form.
	// Called when INITDIALOG message arrives.
    //-------------------------------------------------
    public override void InsertPropSheetPageControls(IntPtr hWnd)
    {
//		APIWrapper.MessageBox(0, "InsertPropSheetPageControls", "", 0);

		this.hWnd = hWnd;

		try
		{
			GetValuesAndInsertControls();
		}
		catch(BadImageFormatException)
		{
			// this is not managed DLL
			InsertControlsForUnmanaged();
			return;
		}

		catch(Exception e)
		{
			APIWrapper.MessageBox(0, e.Message, "", 0);
			return;
		}
		
    }

	//-------------------------------------------------
	//-------------------------------------------------
    public virtual void GetValuesAndInsertControls()
    {	
//		APIWrapper.MessageBox(0, "GetValuesAndInsertControls", "", 0);

		// Set up our parent managed control first
		parent = new UserControl();
		SetParent(parent.Handle, hWnd);

		components = new System.ComponentModel.Container();
		ResourceManager resources = new System.Resources.ResourceManager("Microsoft.PDC01Demo.PropSheetHandler.PropPageDlls", Assembly.GetExecutingAssembly(), null);
		imageList1 = new ImageList(components);


		parent.SuspendLayout();
		parent.Location = new Point(0, 0);
		parent.Size = new Size(375, 475);

		// Set up label
		lblStatReferences = new Label();
		lblStatReferences.Location = new Point(16, 16);
		lblStatReferences.Size = new Size(296, 16);
		lblStatReferences.TabIndex = 0;
		lblStatReferences.Text = "Referenced assemblies";
		parent.Controls.Add(lblStatReferences);

		imageList1.ColorDepth = ColorDepth.Depth8Bit;
		imageList1.ImageSize = new Size(16, 16);
		imageList1.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
		imageList1.TransparentColor = Color.White;

		CreateAppDomain();

		//create helper object that will handle assembly loading for us
		AssemblyHelper asmHelper = (AssemblyHelper)helpAppDomain.CreateInstanceAndUnwrap(
			Assembly.GetAssembly(typeof(AssemblyHelper)).FullName, 
			typeof(AssemblyHelper).FullName);

		AssemblyName asmName;
		staticRefs = asmHelper.GetNames(fullFileName, out asmName);

		tvAllRefs = new TreeView();
		tvAllRefs.Location = new Point(16, 40);
		tvAllRefs.Size = new Size(304, 216);
		tvAllRefs.TabIndex = 1;
		tvAllRefs.ImageList = imageList1;

		// root node is selected file
		TreeNode root = new TreeNode(asmName.Name + ", Version=" + asmName.Version);
		tvAllRefs.Nodes.Add(root);

		TreeNode node = null;
		foreach(AssemblyName name in staticRefs)
		{
			node = new TreeNode(name.Name + ", Version=" + name.Version);
			root.Nodes.Add(node);
			GetRefsRecursive(asmHelper, name, node);
		}
		root.Expand();
		parent.Controls.Add(tvAllRefs);
		parent.ResumeLayout(false);

		AppDomain.Unload(helpAppDomain);
	}

	//-------------------------------------------------
	//-------------------------------------------------
	private void GetRefsRecursive(AssemblyHelper asmHelper, AssemblyName parentAsm, TreeNode parentNode)
	{
		TreeNode node = null;
		AssemblyName[] refs = null;
		string trueVersion = null;

		try
		{
			refs = asmHelper.GetNames(parentAsm, ref trueVersion);
		}
		catch(FileNotFoundException)
		{
			parentNode.Text += " (can not be loaded!)";
			parentNode.ImageIndex = 2;
			parentNode.SelectedImageIndex = 2;
			return;
		}

		if(trueVersion != null)
		{
			parentNode.ImageIndex = 1;
			parentNode.SelectedImageIndex = 1;
			parentNode.Text += " (loaded: Version=" + trueVersion + ")";
		}

		if(IsCircularRef(parentNode))
		{
			parentNode.ImageIndex = 3;
			parentNode.SelectedImageIndex = 3;
			return;
		}

		foreach(AssemblyName name in refs)
		{
			node = new TreeNode(name.Name + ", Version=" + name.Version);
			parentNode.Nodes.Add(node);
			GetRefsRecursive(asmHelper, name, node);
		}
	}

	//-------------------------------------------------
	//-------------------------------------------------
	protected bool IsCircularRef(TreeNode parentNode)
	{
		TreeNode current = parentNode.Parent;
		while(current != null && current.Text != parentNode.Text)
		{
			current = current.Parent;
		}

		if(current == null)
			return false;
		else
		{
//			APIWrapper.MessageBox(0, "circular " + parentNode.Text, "", 0);
			return true;
		}
	}

    //-------------------------------------------------
    //-------------------------------------------------
    public virtual void CreateAppDomain()
    {
		AppDomainSetup setup = new AppDomainSetup();
		setup.ApplicationBase = Path.GetDirectoryName(fullFileName);
		setup.ConfigurationFile = fullFileName + ".config";

		helpAppDomain = AppDomain.CreateDomain("newDomain", null, setup);
    }

	//-------------------------------------------------
	// Tell user that this is not managed assembly
	//-------------------------------------------------
	public virtual void InsertControlsForUnmanaged()
	{
		lblMessage = new Label();

		lblMessage.Location = new Point(16, 40);
		lblMessage.Size = new Size(296, 168);
		lblMessage.TabIndex = 2;
		lblMessage.Text = fullFileName + " is not a managed assembly.";
		parent.Controls.Add(lblMessage);
	}
}

}// namespace Microsoft.PDC01Demo.PropSheetHandler


