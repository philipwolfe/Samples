//--------------------------------------------------------------------------------
//Product
//		AWS File Picker 1.5
//Author
//		Alex Avrutin (alex@awsystems.biz)
//Company
//		Advanced Web Systems (http://www.awsystems.biz)
//						Join The Progress!
//Version 
//		1.0
//Description:
//		This components reminds the "Open File" dialog in windows apps. It let users
//		navigate an upload folder and its subfolders on the server and select a file. 
//		Also, user can upload files to the selected folder, create subfolders and
//		delete them if necessary.
//		You can easily adjust the permissions you grant each person. You can forbid
//		uploading files, deleting them, creating folders. You also can limit size of
//		files that can be uploaded and restrict allowed types of files. For example, 
//		you can let users ability to upload only pictures (gifs and jpgs) with the 
//		size not more then 50Kb.
//Credits:
//		The idea of this component and a pair of routines inside ;-) were inspired by  
//		Tim Mackey's Web Based File Manager (www.scootasp.net). This is a very interesting
//		and useful web application, however I did not like how Tim built the  
//		list of files (Tom, you know, there is a great DataGrid control, isn't it? :-).
//		Anyway, thank you a lot. It is a really good app, especially for its zero price. 
//		Also I'd like to thank Peter Blum (www.PeterBlum.com) who showed how a Real Web 
//		Control must be built with his DateTextBox control (also, a very robust and free 
//		one). I borrowed here the framework (code for main routines and properties for
//		rendering and pop up) and a few lines of JavaScript code (can't stand client 
//		programming, you know ;-). 
//This file:
//Interface and the control rendering routines.



using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Drawing.Design;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Reflection;


[assembly:TagPrefix("AWS", "AWS")]

namespace AWS
{
	[ToolboxData("<{0}:FilePicker runat=server></{0}:FilePicker>")]
	public class FilePicker : System.Web.UI.WebControls.TextBox, INamingContainer
	{
		protected bool _IsInDesignMode = false; 
		private HyperLink _HyperLink = null;  // the HyperLink for the image button

		//--------------------------------------------------------------------------------
		/// <summary>
		/// The URL of the Browse image button.
		/// Default is "~/FilePicker/img/browse.gif".
		/// </summary>
		[DefaultValue("~/FilePicker/img/browse.gif")]
		[Category("Behavior")]
		[Description("The URL of the image shown to the right of the edit box.")]
		[Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string fpImageURL
		{
			get { return _ImageURL; }
			set { _ImageURL = value; }
		}
		private string _ImageURL = "~/FilePicker/img/browse.gif";

		//--------------------------------------------------------------------------------
		/// <summary>
		/// The name of the page opened in the popup window.
		/// Usually it is FilePicker.aspx.
		/// Default is "FilePicker/FilePicker.aspx".
		/// </summary>
		[DefaultValue("FilePicker/FilePicker.aspx")]
		[Category("Behavior")]
		[Description("The URL of the file opened within the popup window.")]
		[Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
		public string fpPopupURL
		{
			get { return _PopupURL; }
			set { _PopupURL = value; }
		}
		private string _PopupURL = "FilePicker/FilePicker.aspx";

		//--------------------------------------------------------------------------------
		///<summary>
		///Base directory for uploaded files, virtual directory on the server. Default is ~/Upload/
		///<summary>
		[DefaultValue("~/Upload/")]
		[Category("Behavior")]
		[Description("Base directory for uploaded files.")]
		[Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
		public string fpUploadDir
		{
			get { return _UploadDir; }
			set { _UploadDir = value; }
		}
		private String _UploadDir = "~/Upload/";

		//--------------------------------------------------------------------------------
		///<summary>
		///Specifies whether application-relative path (True) or upload directory relative path (False) must be returned.  Default is True
		///<summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("Specifies whether application-relative path (True) or upload directory relative path (False) must be returned. ")]
		public bool fpUseAppRelPath
		{
			get { return _UseAppRelPath; }
			set { _UseAppRelPath = value; }
		}
		private bool _UseAppRelPath = true;

		//--------------------------------------------------------------------------------
		///<summary>
		///Whether allow user to upload files or not. Default is true.
		///<summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("Whether allow user to upload files or not.")]
		public bool fpAllowUpload
		{
			get { return _AllowUpload; }
			set { _AllowUpload = value; }
		}
		private bool _AllowUpload = true;

		//--------------------------------------------------------------------------------
		///<summary>
		///Whether allow user to create directories in the base directory and its subdirectories.
		///Default is true.
		///<summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("Whether allow user to create directories.")]
		public bool fpAllowCreateDirs
		{
			get { return _AllowCreateDirs; }
			set { _AllowCreateDirs = value; }
		}
		private bool _AllowCreateDirs = true;

		//--------------------------------------------------------------------------------
		///<summary>
		///Whether allow user to delete directories and files in the base directory 
		///and its subdirectories.
		///Default is true.
		///<summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("Whether allow user to delete files and directories.")]
		public bool fpAllowDelete
		{
			get { return _AllowDelete; }
			set { _AllowDelete = value; }
		}
		private bool _AllowDelete = true;

		//--------------------------------------------------------------------------------
		///<summary>
		///Whether allow user to rename directories and files in the base directory 
		///and its subdirectories.
		///Default is true.
		///<summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("Whether allow user to rename files and directories.")]
		public bool fpAllowRename
		{
			get { return _AllowRename; }
			set { _AllowRename = value; }
		}
		private bool _AllowRename = true;	
		
		//--------------------------------------------------------------------------------
		///<summary>
		///If set, restricts size of files that can be uploaded (in bytes).
		///Default is 0 (restriction is turned off).
		///<summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("If set, restricts size of files that can be uploaded (in bytes).")]
		public long fpUploadSizeLimit
		{
			get { return _UploadSizeLimit; }
			set { _UploadSizeLimit = value; }
		}
		private long _UploadSizeLimit = 0;

		//--------------------------------------------------------------------------------
		///<summary>
		///Comma-delimited extensions representing file types allowed for upload. 
		///If not set, all the types accepted. 
		///Default is "" (restriction is turned off).
		///<summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("File extensions allowed for upload (delimited with comma).")]
		public String fpAllowedUploadFileExts
		{
			get { return _AllowedUploadFileExts; }
			set { _AllowedUploadFileExts = value; }
		}
		private String _AllowedUploadFileExts = "";


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Shifts the top edge of the image button.
		/// Positive values shift down. Negative up. Values are in pixels.
		/// Default is 2.
		/// </summary>
		[DefaultValue(2)]
		[Category("Appearance")]
		[Description("Shifts the top edge of the image button.")]
		public int fpImageTopOffset
		{
			get { return _ImageTopOffset; }
			set { _ImageTopOffset = value; }
		}
		private int _ImageTopOffset = 2;

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Shifts the left edge of the image button.
		/// Positive values shift right. Negative left. Values are in pixels.
		/// When 0, the left is flush with the right edge of the TextBox.
		/// Defaults to 1.
		/// </summary>
		[DefaultValue(1)]
		[Category("Appearance")]
		[Description("Shifts the left edge of the image button.")]
		public int fpImageLeftOffset
		{
			get { return _ImageLeftOffset; }
			set { _ImageLeftOffset = value; }
		}
		private int _ImageLeftOffset = 1;

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Determines the popup window's width in pixels.
		/// If you customize the font information in FilePicker.aspx, you may need to adjust this.
		/// </summary>
		[DefaultValue(450)]
		[Category("Appearance")]
		[Description("The width of the popup window in pixels.")]
		public int fpPopupWidth
		{
			get { return _PopupWidth; }
			set { _PopupWidth = value; }
		}
		private int _PopupWidth = 450;

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Determines the popup window's height in pixels.
		/// If you customize the font information in FilePicker.aspx, you may need to adjust this.
		/// </summary>
		[DefaultValue(500)]
		[Category("Appearance")]
		[Description("The height of the popup window in pixels.")]
		public int fpPopupHeight
		{
			get { return _PopupHeight; }
			set { _PopupHeight = value; }
		}
		private int _PopupHeight = 500;

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Shifts the initial top position of the select file dialog.
		/// Positive values shift down. Negative up. Values are in pixels.
		/// When 0, the top is aligned with the top of the graphic image.
		/// This only affects IE browsers as all others center the window.
		/// Defaults to -75 to center it against the image assuming the default for fpPopupHeight.
		/// </summary>
		[DefaultValue(-75)]
		[Category("Appearance")]
		[Description("Shifts the initial top position of the popup the select file dialog. (IE Browsers only.)")]
		public int fpPopupTopOffset
		{
			get { return _PopupTopOffset; }
			set { _PopupTopOffset = value; }
		}
		private int _PopupTopOffset = -75;

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Shifts the initial left position of the select file dialog.
		/// Positive values shift right. Negative left. Values are in pixels.
		/// When 0, the left is aligned with the left of the graphic image.
		/// This only affects IE browsers as all others center the window.
		/// Defaults to 0.
		/// </summary>
		[DefaultValue(0)]
		[Category("Appearance")]
		[Description("Shifts the initial left position of the select file dialog. (IE Browsers only.)")]
		public int fpPopupLeftOffset
		{
			get { return _PopupLeftOffset; }
			set { _PopupLeftOffset = value; }
		}
		private int _PopupLeftOffset = 0;

		//---- OVERRIDDEN PROPERTIES -----------------------------------------------------
		// Selected properties have been made read only and/or given alternative Attributes.

		[Browsable(false)]
		public override TextBoxMode TextMode 
		{get { return TextBoxMode.SingleLine; }}

		[Browsable(false)]
		public override int Rows {get {return base.Rows;}}

		[Browsable(false)]
		public override bool Wrap 
		{get { return base.Wrap; } set { base.Wrap = true;} }

		[Browsable(false)]
		public override String Text 
		{get { return base.Text; } set { base.Text = value;} }
		//--------------------------------------------------------------------------------
		///<summary>
		///Selected file name.
		///</summary>

		[Category("Data")]
		[Description("Selected file name.")]
		[Bindable(true)]
		public String FileName 
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		// ------ METHODS ----------------------------------------------------------------
		/// <summary>
		/// CreateChildControls installs the HyperLink control which hosts the image button.
		/// </summary>
		protected override void CreateChildControls()
		{
			// establish the image button
			_HyperLink = new HyperLink();
			_HyperLink.EnableViewState = false;
			Controls.Add(_HyperLink);
			string _HyperLinkID = _HyperLink.ClientID;
			_HyperLink.Attributes["ID"] = _HyperLinkID;  // HyperLink doesn't insert an ID but we need it for a JavaScript lookup

		}  // CreateChildControls()

		//--------------------------------------------------------------------------
		/// <summary>
		/// OnPreRender applies all of the properties to the controls. This allows
		/// properties to be set programmatically and be handled correctly during
		/// a new page or post back load.
		/// It establishes all client side scripting and installs a variety of custom 
		/// client-side attributes for the scripts to use.
		/// </summary>
		protected override void OnPreRender(EventArgs e)
		{
			///<ErrorFix IssueID=3 ProductVersion="1.5" Descripion = 
			///"Due to using session variables, in v1.0 you could not use more then 
			///1 FP instance on one webform. Now, this is possible because each instance 
			///will save its data in usique session variables."> 
			//Save information for file manager that will be opened in the popup window.
			HttpContext.Current.Session[this.ClientID + "fpUploadDir"] = _UploadDir;
			HttpContext.Current.Session[this.ClientID + "fpAllowUpload"] = _AllowUpload;
			HttpContext.Current.Session[this.ClientID + "fpAllowCreateDirs"] = _AllowCreateDirs;
			HttpContext.Current.Session[this.ClientID + "fpAllowDelete"] = _AllowDelete;
			HttpContext.Current.Session[this.ClientID + "fpAllowRename"] = _AllowRename;
			HttpContext.Current.Session[this.ClientID + "fpAllowedUploadFileExts"] = _AllowedUploadFileExts;
			HttpContext.Current.Session[this.ClientID + "fpUploadSizeLimit"] = _UploadSizeLimit;
			HttpContext.Current.Session[this.ClientID + "fpUseAppRelPath"] = _UseAppRelPath;
			///</ErrorFix>
			_HyperLink.Visible = this.Visible;
			if (_HyperLink.Visible)
			{
				System.Web.UI.WebControls.Image _Image = new System.Web.UI.WebControls.Image();
				_Image.ImageUrl = _ImageURL;
				_Image.ToolTip = "...";
				_Image.Style["POSITION"]="relative";
				_Image.Style["TOP"]=_ImageTopOffset.ToString() + "px";
				_Image.Style["LEFT"]=_ImageLeftOffset.ToString() + "px";
				_HyperLink.Enabled = this.Enabled;
				_Image.Enabled = this.Enabled;
				_HyperLink.Controls.Add(_Image);
			}

			// the rest is script related. Not useful in design mode
			if (_IsInDesignMode)
				return;

			RegisterPopupScript();  // the popup function is always supplied even when the button isn't
			_HyperLink.NavigateUrl = "javascript:PopupWindow('" + this.ClientID + "', '" + 
				_HyperLink.ClientID + "');";

			//By Peter Blum:
			// The Javascripts use many of this control's properties. We'll use the following
			// technique to get those properties into the client side. It allows each instance 
			// of the control to safely have its own values.
			// Put custom attributes into the FilePicker HTML tag. These attributes are harmless
			// to the browser (assuming they are named in a way that doesn't interfere with future DOM releases).
			// The DOM method element.getAttribute('name') will retrieve the value in any browser.
			// We've build a special script, GetAttribute, to handle this while assigning a default.
			RegisterGetAttribute();
			this.Attributes["Custom_PopupWidth"] = this._PopupWidth.ToString();
			this.Attributes["Custom_PopupHeight"] = this._PopupHeight.ToString();
			this.Attributes["Custom_PopupPath"] = this._PopupURL;
			this.Attributes["Custom_PopupTopOffset"] = this._PopupTopOffset.ToString();
			this.Attributes["Custom_PopupLeftOffset"] = this._PopupLeftOffset.ToString();

		}  // CreateChildControls

		//-------------------------------------------------------------------------------------
		/// <summary>
		/// RegisterGetAttribute registers the client-side scripting routine GetAttribute
		/// which is used by most other routines to retrieve an attribute from the date element
		/// and if not found, use the default supplied.
		/// </summary>
		protected void RegisterGetAttribute()
		{
			if (!Page.IsClientScriptBlockRegistered("GetAttribute"))
			{
				StringBuilder _Script = new StringBuilder(1000);
				_Script.Append("<script language=javascript>\n");
				_Script.Append("function GetAttribute(pElement, pAttributeName, pDefaultValue) \n");
				_Script.Append("{\n");
				_Script.Append("  var vResult = pElement.getAttribute(pAttributeName, 0);\n");
				_Script.Append("  if (vResult == null)\n");
				_Script.Append("     vResult = pDefaultValue; \n");
				_Script.Append("  return vResult; \n");      
				_Script.Append("} // GetAttribute()\n\n");
				_Script.Append("</script>\n");
				Page.RegisterClientScriptBlock("GetAttribute", _Script.ToString());
			}
		}  // RegisterGetAttribute()

		//-------------------------------------------------------------------------------------
		/// <summary>
		/// RegisterPopupScript registers the client side function PopupWindow
		/// which opens the select file dialog.
		/// It uses the file in fpPopupURL and sets two parameters for it:
		/// pTextBoxID - this is the ID of the Text Box where file name of a selected file will be placed.
		/// Prior to opening the window, numerous calculations are run to determine the top left
		/// corner of the window. For IE browsers, it should be flush left with the image button.
		/// For other browsers, it will be centered on the page. Adjustments are made if the window
		/// exceeds the bottom or right of the screen.
		/// </summary>
		protected void RegisterPopupScript()
		{
			if (!Page.IsClientScriptBlockRegistered("SetupPopup"))
			{
				StringBuilder vScript = new StringBuilder(2000);
				vScript.Append("<script language=javascript>\n");
				vScript.Append("function PopupWindow(pTextBoxID, pButtonID) \n");
				vScript.Append("{\n");
				vScript.Append("  var vTextBox = document.getElementById(pTextBoxID);\n");
				vScript.Append("  var vFileName;\n");
				vScript.Append("  var vButton = document.getElementById(pButtonID);\n");
				vScript.Append("  var vTopPos = 0;\n");
				vScript.Append("  var vLeftPos = 0;\n");
				vScript.Append("  var vScreenWidth;\n   var vScreenHeight;\n");
				vScript.Append("  var vPopupWidth = eval(GetAttribute(vTextBox, 'Custom_PopupWidth', 136));\n");
				vScript.Append("  var vPopupHeight = eval(GetAttribute(vTextBox, 'Custom_PopupHeight', 138));\n");
				vScript.Append("  if ((document.all != null) && (window.screenTop != null)) // IE except Mac\n");
				vScript.Append("  {\n");
				vScript.Append("    vScreenWidth = screen.availWidth;\n    vScreenHeight = screen.availHeight;\n");
				vScript.Append("    if (vButton != null)\n");
				vScript.Append("    {\n");
				vScript.Append("       vTopPos = vButton.offsetTop - document.body.scrollTop + window.screenTop;\n");
				vScript.Append("       vLeftPos = vButton.offsetLeft - document.body.scrollLeft + window.screenLeft;\n");
				vScript.Append("       vParent = vButton.offsetParent;\n"); //parentElement
				vScript.Append("    }\n");
				vScript.Append("    else // no Browse button. Position to the right of the edit box. \n");
				vScript.Append("    {\n");
				vScript.Append("       vTopPos = vTextBox.offsetTop - document.body.scrollTop + window.screenTop;\n");
				vScript.Append("       vLeftPos = vTextBox.offsetLeft + vTextBox.offsetWidth - document.body.scrollLeft + window.screenLeft;\n");
				vScript.Append("       vParent = vTextBox.offsetParent;\n"); //parentElement
				vScript.Append("    }\n");
				vScript.Append("    while (vParent != null)\n");
				vScript.Append("    {\n");
				vScript.Append("       vTopPos = vTopPos + vParent.offsetTop;\n");
				vScript.Append("       vLeftPos = vLeftPos + vParent.offsetLeft;\n");
				vScript.Append("       vParent = vParent.offsetParent;\n");   // parentElement
				vScript.Append("    }\n");
				vScript.Append("    vTopPos = vTopPos + eval(GetAttribute(vTextBox, 'Custom_PopupTopOffset', -75));\n");
				vScript.Append("    vLeftPos = vLeftPos + eval(GetAttribute(vTextBox, 'Custom_PopupLeftOffset', 0));\n");
				vScript.Append("  // if offscreen, shift left or up\n");
				vScript.Append("    if (vLeftPos + vPopupWidth > vScreenWidth)\n");
				vScript.Append("       vLeftPos = vScreenWidth - vPopupWidth;\n");
				vScript.Append("    if (vTopPos + vPopupHeight > vScreenHeight)\n");
				vScript.Append("       vTopPos = vScreenHeight - vPopupHeight;\n");
				vScript.Append("  }\n   else  // Netscape and IE Mac \n");
				vScript.Append("  {\n");
				// By Peter Blum:
				// there is no way to identify the top and left edge position of the window in Mozilla/Netscape.
				// The Mozilla.org docs indicate that window.screen.top and window.screen.left do this
				// but they always return 0, which is what I would have thought for the screen object to do.
				// As a result, we cannot do this properly. Thus, we are using auto centering.
				vScript.Append("    vTopPos = (window.screen.availHeight - vPopupHeight) / 2;\n");
				vScript.Append("    vLeftPos =(window.screen.availWidth - vPopupWidth) / 2;\n");
				vScript.Append("  }\n");
				vScript.Append("  var vValueParam = '';\n");  // will either be blank or contain '&date=HttpEncoded(datevalue)
				vScript.Append("  if (vTextBox.value != '')\n");
				vScript.Append("    vValueParam = '&value=' + vTextBox.value.toString();\n");
				vScript.Append("  var vPopupPath = GetAttribute(vTextBox, 'Custom_PopupPath', 'FilePicker.aspx');\n");
				vScript.Append("  fp_window=window.open(vPopupPath+ '?TextBoxID=");
				vScript.Append("' + pTextBoxID + vValueParam,\n");
				vScript.Append("  'fp_window','top='+vTopPos+', left='+vLeftPos+', width='+vPopupWidth+',height='+vPopupHeight+'");
				vScript.Append(",menubar=no,resizable=yes,scrollbars=yes,toolbar=no,location=no');\n");
				vScript.Append("  fp_window.focus();\n");
				vScript.Append("} // PopupWindow()\n\n");
				vScript.Append("</script>\n");
				Page.RegisterClientScriptBlock("SetupPopup", vScript.ToString());
			}
		}  // RegisterPopupScript()


		//----------------------------------------------------------------------------------------
		/// <summary>
		/// Allow the child controls to be rendered.
		/// </summary>
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			RenderChildren(writer);
		}  // Render()
	}
}  // namespace AWS

