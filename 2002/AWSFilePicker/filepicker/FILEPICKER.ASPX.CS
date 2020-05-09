//--------------------------------------------------------------------------------
//Product
//		AWS File Picker
//Author
//		Alex Avrutin (alex@awsystems.biz)
//Company
//		Advanced Web Systems (http://awsystems.biz)
//											Join The Progress!
//Version 
//		1.0.1
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
//		The idea of this component and a pair of routines inside :-) were inspired by  
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
//		A page that is loaded in pop up window and fulfills the main machinery for the app
//		(file browsing, uploading, restrictions and so on).



using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Security;
using System.Data;


namespace AWS
{

	public class FilePickerPage : System.Web.UI.Page {

		protected TextBox NewFolderText;
		protected Button NewFolderBtn;
		protected Button UploadBtn;
		protected HtmlInputFile fileToUpload;
		protected Label Header;
		protected ImageButton GoRoot;
		protected TextBox setRootTxt;
		protected ImageButton UpBtn;
		protected System.Web.UI.WebControls.Image	imgFSObject;
		protected DataGrid dgFSList;
		protected PlaceHolder UploadArea;
		protected PlaceHolder CreateDirArea;


		bool _AllowUpload = false;
		bool _AllowCreateDirs = false;
		bool _AllowDelete = false;
		bool _AllowRename = false;
		bool _UseAppRelPath = true;
		String _UploadDir = "";
		String FPTextBoxID = "";
   
		private void Page_Load(object sender, System.EventArgs e) {
			DirectoryInfo mainDir; //information on the current directory (if is)
			String _PhysicalPath; //Actual physical path for selected file name or current folder
			String _UploadFolderRelativePath; //Path for the file, relative to the upload folder
			
			FPTextBoxID = Request.QueryString["TextBoxID"]; //Client id of File Picker Text Box
			// check if an variable with Upload Directory name passed - it is obligatory  			
			if (Session[FPTextBoxID + "fpUploadDir"] == null) {
				//Stop working
				ReportError("Sorry, can't get necessary session data.",  "Check if your web browser and firewall allow cookies.\\nIf everything is OK, report the site administrator about this error.");
				return;
			}
			else {
				_UploadDir = (String)Session[FPTextBoxID + "fpUploadDir"];
				//Add a slash in the end of the upload path if it is not provided
				_UploadDir =  AddSlashIfNotExist(_UploadDir);
			}

			//Find enabled actions for the current user
			if (Session[FPTextBoxID + "fpAllowUpload"] != null) 
				_AllowUpload = Convert.ToBoolean(Session[FPTextBoxID + "fpAllowUpload"]);
			if (Session[FPTextBoxID + "fpAllowCreateDirs"] != null)
				_AllowCreateDirs = Convert.ToBoolean(Session[FPTextBoxID + "fpAllowCreateDirs"]);
			if (Session[FPTextBoxID + "fpAllowDelete"]!= null)
				_AllowDelete = Convert.ToBoolean(Session[FPTextBoxID + "fpAllowDelete"]);
			if (Session[FPTextBoxID + "fpAllowRename"]!= null)
				_AllowRename = Convert.ToBoolean(Session[FPTextBoxID + "fpAllowRename"]);

			//Disable a control if an action disabled
			UploadArea.Visible = _AllowUpload;
			CreateDirArea.Visible = _AllowCreateDirs;
			//Delete file action will be disabled later in the dgFSList_ItemDataBound procedure
			//as we don't have access to Del button now.
			
			//Check if the file manager should return application-relative or
			//Upload folder-relative path to the parent page
			if (Session[FPTextBoxID + "fpUseAppRelPath"]!= null)
				_UseAppRelPath = Convert.ToBoolean(Session[FPTextBoxID + "fpUseAppRelPath"]);

			//Default sorting settings
			if (ViewState["SortColumn"] == null) ViewState["SortColumn"] = "FileName"; //default sort column
			if (ViewState["SortOrder"] == null) ViewState["SortOrder"] = "DESC"; //default sort direction

			//Check if this is the first load of the page
			if (!IsPostBack) //if yes
			{	
				//Just cleaning up..
				ViewState["fpUploadFolderRelativePath"]= ""; 

				///<BugFix IssueID="1" ProductVersion="1.5" Description="In AWS FilePicker v 1.0 changing page did not influence the item you 
				//selectd in the grid -- you always selected the items from the first page. It happened due 
				//to page index that was missing because ViewState is turned off for the DataGrid. To solve the problem,
				//store the page index in the Session variable explicitly and get it when binding DataGrid.">
				//set current page index (if specified)
				if (Session[FPTextBoxID + "CurrentPageIndex"] == null) {
					Session[FPTextBoxID + "CurrentPageIndex"] = 0; //starting page index
				}
				///</BugFix>

				//Try to get a directory to follow into from TextBox on the parent page
				if (Request.QueryString["value"]!= null) {
					if (Request.QueryString["value"].ToString()!="") {
						
						//Path stored in the TextBox on the parent page (remove filename)
						String _CurrentPath = getParentDirectory(Request.QueryString["value"].ToString());
						//--------------------^^^^^^^^^^^^^^^^^^-------
						
						//This removes filename as well as returnes a parent folder
						_CurrentPath = AddSlashIfNotExist(_CurrentPath);
						
						//Resolve Upload folder-relavite path for the current path
						if (_UseAppRelPath == true) {
							//Check if the path is valid -- in any case when use app-relative path enabled, 
							//the path length cannot be less then Upload dir length 
							//as upload path included into the filename 
							if (_CurrentPath.Length > _UploadDir.Length) {
								_UploadFolderRelativePath = _CurrentPath.Substring(_UploadDir.Length); 
							}
							else {
								_UploadFolderRelativePath = String.Empty;
							}
						}
						else {
							_UploadFolderRelativePath = _CurrentPath;							
						}						
						
						//Resolve physical path for a relative path
						_PhysicalPath = Server.MapPath (_UploadDir + _UploadFolderRelativePath);
						
						//Create a directory object that will help check if the path exists
						mainDir = new DirectoryInfo(_PhysicalPath);

						//Check if physical path we get for the current selected file exists
						if(mainDir.Exists == true) {								
							ViewState["fpUploadFolderRelativePath"] = _UploadFolderRelativePath;
						}
					}
				}
			}

			showFiles();	// list the files and folders in the current directory
		}
		
		///<summary>Get a list with file systems objects (files and dirs),
		///bind it to the DataGrid. Also, hide or show the navigation buttons (up/root)
		///and set the header.</summary>
		private void showFiles() {
			
			///<BugFix ProductVersion="1.5" Description="If somehow relative path in session variable lost, initialize the var again,
			//and set root directory current, thereby aviod 'Object not set to an instance of object'
			//error that happened often in the initial version.">
			if (ViewState["fpUploadFolderRelativePath"] == null) {
				ViewState["fpUploadFolderRelativePath"] = "";
			}
			///</BugFix>

			if(ViewState["fpUploadFolderRelativePath"].ToString() != "") {	
				Header.Text = "Showing contents of <b>" + ViewState["fpUploadFolderRelativePath"].ToString() + "</b> directory.";				
				UpBtn.Visible = true;		// this button has no context in the root dir
				GoRoot.Visible = true;		// same
			}
			else{
				Header.Text = "Showing contents of <B>root directory.</b>";	
				UpBtn.Visible = false;		// this button has no context in the root dir
				GoRoot.Visible = false;		// same
			}

			//safety checks handled by ValidatePath function
			DirectoryInfo mainDir = ValidatePath(_UploadDir + (String)ViewState["fpUploadFolderRelativePath"]);			
			if(mainDir == null)	return;	// bail out
			
			
			///<BugFix IssueID="1" ProductVersion="1.5" Description="In AWS FilePicker v 1.0 changing page did not influence the item you 
			//selectd in the grid -- you always selected the items from the first page. It happened due 
			//to page index that was missing because ViewState is turned off for the DataGrid. To solve the problem,
			//store the page index in the Session variable explicitly and get it when binding DataGrid.">
			//set current page index (if specified)
			if (Session[FPTextBoxID + "CurrentPageIndex"] != null){
				//ensure that page index will not be out of total DataGrid pages number 
				float PageCountFloat = (float)(mainDir.GetFileSystemInfos().Length) / (float)(dgFSList.PageSize);
				int PageCount = (int)PageCountFloat; 
				//If page count is fractional number (not integer), then some items are rest that 
				//do not comprise full DataGrid page, but anyway require one more page for them. 
				if (PageCount < PageCountFloat) {PageCount++ ;}  
	
				//Ensure CurrentPageIndex is not out of range. 		
				if (((int)Session[FPTextBoxID + "CurrentPageIndex"]) < PageCount) {
					dgFSList.CurrentPageIndex = (int)Session[FPTextBoxID + "CurrentPageIndex"];
				}
				else {
					dgFSList.CurrentPageIndex = 0;
				}
			}
			///</BugFix>
			
			//Get a list of files and folders in this directory
			FileSystemInfo[] FSInfos = mainDir.GetFileSystemInfos(); //GetFileSystemInfos returns an array of DataSystemInfos

			///<NewFeature Issue="2" ProductVersion="1.5" Description="Add ability to sort files and folders in the grid.">
			//Because we cannot sort either FileSystemInfo or DataGrid objects directly, create and populate a  
			//DataTable object that will be a proxy here allowing us to sort items
			DataTable FileSystemInfosTable;
			DataView FileSystemTableView; //actually we will sort a DataView object associated with the DataTable
			DataRow myDataRow;

			//Create a DataTable object
			FileSystemInfosTable = new DataTable(); 
			
			//Create columns
			FileSystemInfosTable.Columns.Add(new DataColumn("IsFile", Type.GetType("System.Boolean"))); //Is this a file or directory?			
			FileSystemInfosTable.Columns.Add(new DataColumn("FileName", Type.GetType("System.String"))); //FileName
			FileSystemInfosTable.Columns.Add(new DataColumn("Size", Type.GetType("System.Int32"))); //Size
			FileSystemInfosTable.Columns.Add(new DataColumn("Modified", Type.GetType("System.DateTime"))); //Last modified date and time
			
			foreach (FileSystemInfo FSInfo in FSInfos){
				myDataRow = FileSystemInfosTable.NewRow();
				
				myDataRow["FileName"] = FSInfo.ToString(); 
				myDataRow["Modified"] = FSInfo.LastWriteTime;

				//We can get size only if we work with FileInfo object. As the array can contain both 
				//FileInfo (represent a file) and Directoryinfo (represent a directory) objects, 
				//first check what we work with.
				switch (FSInfo.GetType().ToString()) {
					case "System.IO.DirectoryInfo": {
						//A directory -- take advantage of the chance and set file system info type 
						myDataRow["IsFile"] = false;
						//Do not set size -- it is the directory
						break;
					}
					case "System.IO.FileInfo": {
						//A file -- take advantage of the chance and set file system info type 
						myDataRow["IsFile"] = true;
						//Set file size
						myDataRow["Size"] = ((FileInfo)FSInfo).Length;
						break;	
					}
				}	
				FileSystemInfosTable.Rows.Add(myDataRow);
			}
			
			//Get a DataView of the DataTable. It allows us to sort the items in the table
			FileSystemTableView = FileSystemInfosTable.DefaultView;
			//Sort DataView 
			FileSystemTableView.Sort = (String)ViewState["SortColumn"] + " " + (String)ViewState["SortOrder"];
			dgFSList.DataSource = FileSystemTableView;
			//Ensure PageIndex is not out of range
			
			///</NewFeature>			
			
			//if a row is edited (renaming of a file or folder), set EditItemIndex using saved value
			if (ViewState["EditItemIndex"] != null) {
				dgFSList.EditItemIndex = (int)ViewState["EditItemIndex"];
			}
			
			dgFSList.DataBind();
		}
		
		///<summary>Invoked when the DataGrid binds a row. Acquire and set a file/dir information.
		///</summary>
		private void dgFSList_ItemDataBound(Object sender, DataGridItemEventArgs e) {
			String _FileSizeStr;

			//do not process header, footer and pager
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem ||
				e.Item.ItemType == ListItemType.EditItem ) {
				
				//Fill in common file/folder data
				
				if (e.Item.ItemType != ListItemType.EditItem) {
					((LinkButton)e.Item.FindControl("lbFileName")).Text = ((DataRowView)e.Item.DataItem)["FileName"].ToString();
					//Disable delete action if this is forbidden for the current user
					((LinkButton)e.Item.FindControl("imbDel")).Visible = _AllowDelete;
					//Disable rename action if this is forbidden for the current user
					((LinkButton)e.Item.FindControl("imbRen")).Visible = _AllowRename;				
					ViewState["fpUploadFolderRelativePath"] = AddSlashIfNotExist(ViewState["fpUploadFolderRelativePath"].ToString());
					((HyperLink)e.Item.FindControl("hlView")).NavigateUrl = 
						_UploadDir + ViewState["fpUploadFolderRelativePath"].ToString() + ((DataRowView)e.Item.DataItem)["FileName"].ToString();
					//Add delete confirmation
					LinkButton imbDel = (LinkButton)e.Item.FindControl("imbDel");
					String ConfirmJS = "return confirm('Do you want to proceed?');";
					imbDel.Attributes["onclick"] = ConfirmJS;
				}

				((Label)e.Item.FindControl("lbModified")).Text = ((DataRowView)e.Item.DataItem)["Modified"].ToString();
				System.Web.UI.WebControls.Image FSOImage = ((System.Web.UI.WebControls.Image)e.Item.FindControl("imgFSObject"));
				
				
				//Settings depending on whether DataGrid displays file or folder
				switch ((bool)((DataRowView)e.Item.DataItem)["isFile"]) {
					case false: {
						//a directory
						FSOImage.ImageUrl = "img/folder.gif";
						FSOImage.AlternateText = "Folder";
						((Label)e.Item.FindControl("lblSize")).Text = "Dir";
						e.Item.Attributes.Add("FSOType", "Folder");
						break;
					}
					case true: {
						//a file
						FSOImage.ImageUrl = "img/file.gif";
						FSOImage.AlternateText = "File";
						_FileSizeStr = GetFileSize((int)((DataRowView)e.Item.DataItem)["Size"]);
						((Label)e.Item.FindControl("lblSize")).Text = _FileSizeStr;
						e.Item.Attributes.Add("FSOType", "File");						
						break;
					}
				}
			}
		}
		
		///<summary>Invoked when an user clicked a file(folder) or a Del button 
		private void dgFSList_ItemCommand(Object sender, DataGridCommandEventArgs e) {
			//Map commands 
			if (e.CommandName == "FSOClick") {
				String FileName = ((LinkButton)e.Item.FindControl("lbFileName")).Text;
				// add  "/" at end of relative path if it doesn't exist				
				ViewState["fpUploadFolderRelativePath"] = AddSlashIfNotExist(ViewState["fpUploadFolderRelativePath"].ToString());
				//if user clicked file or folder name
				switch (e.Item.Attributes["FSOType"]) {								
					case "Folder": {
						//if we work with directory, follow into it
						ChangePath(FileName);
						showFiles();
						break;
					}

					case "File": {
						//if we work with file, select this file	
						SelectFile(ViewState["fpUploadFolderRelativePath"].ToString() + FileName);
						break;
					}
				}
			}

			else if (e.CommandName == "Del") {
				String FileName = ((LinkButton)e.Item.FindControl("lbFileName")).Text;

				switch (e.Item.Attributes["FSOType"]) {
					case "File": {					
						FileInfo file = new FileInfo(Server.MapPath(_UploadDir + ViewState["fpUploadFolderRelativePath"].ToString()+ FileName));
						try	{
							file.Delete();
						}
						catch //(Exception ex)
						{
							ReportError("Cannot delete the file.",  "The file can be busy, in use by an application \\nor you do not have write permissions for the current directory or for the file.");
						}						
						break;
					}

					case "Folder": {
						try	{
							DirectoryInfo dir = new DirectoryInfo(Server.MapPath(_UploadDir + ViewState["fpUploadFolderRelativePath"].ToString()+FileName));
							dir.Delete(true); //Delete recursive							
						}
						catch	//(Exception ex)	
						{
							ReportError("Could not delete folder.",  "Check that the folder exists and you have \\nwrite permissions for the current directory.");
						}
						break;
					}
				}
				showFiles();
			}

			///<NewFeature IssueID="3" ProductVersion="1.5" Description = "Add ability to rename files directy in the DataGrid">
			else if (e.CommandName == "Rename") {
				//Rename file -- save previous file/folder name and turn DataGrid into edit mode 
				
				ViewState["PrevFileFolderName"] = ((LinkButton)e.Item.Cells[1].Controls[1]).Text;
				ViewState["EditItemIndex"] = e.Item.ItemIndex;
				ViewState["FSOType"] = e.Item.Attributes["FSOType"];
				dgFSList.EditItemIndex = e.Item.ItemIndex;

				showFiles();

			}
			else if (e.CommandName == "Update") {
				//Accept new file or folder name
				
				//names without path
				string NewFileName = ((TextBox)e.Item.Cells[1].Controls[1]).Text; 
				string OldFileName = ViewState["PrevFileFolderName"].ToString();				
				//names wuth virtual path
				NewFileName = _UploadDir + ViewState["fpUploadFolderRelativePath"].ToString() + "/" + NewFileName;
				OldFileName = _UploadDir + ViewState["fpUploadFolderRelativePath"].ToString() + "/" + OldFileName;				
				//names with physical path (what we need to rename the file)
				NewFileName = Server.MapPath(NewFileName);
				OldFileName = Server.MapPath(OldFileName);
				//rename the file or folder
				try {
					switch (ViewState["FSOType"].ToString()) {
						case "File": {
							File.Move (OldFileName, NewFileName);						
							break;
						}
						case "Folder": {
							Directory.Move (OldFileName, NewFileName);	
							break;
						}
					}
				}
				catch (System.IO.IOException ex){
					//File (folder) with the same name is likely to exist
					ReportError("An error occured while renaming a file (folder)", "Check if a file(folder) with the same exists.");
				}
				catch (Exception ex) {
					//Other errors
					ReportError("An error occured while renaming a file (folder)", "Ensure you have enougth write permissions.");
				}
				//exit edit mode
				dgFSList.EditItemIndex = -1;
				ViewState["EditItemIndex"] = -1;
				//rebuld the files & folders list 
				showFiles();
			}

			else if (e.CommandName == "Cancel") {
				//Cancel renaming

				dgFSList.EditItemIndex = -1;
				ViewState["EditItemIndex"] = -1;
				showFiles();
			}
			///</NewFeature>
 
		}
	
		///<NewFeature Issue="2" ProductVersion="1.5" Description="Add ability to sort files and folders in the grid.">
		///<summary>Invoked when an user sort the DataGrid.</summary>
		private void dgFSList_SortCommand(Object sender, DataGridSortCommandEventArgs e) {			
			//if the same column caption has been clicked twice, change sort order. 
			//Otherwise, change the sort column
			if (ViewState["SortColumn"].ToString() == (string)e.SortExpression) {
				if (ViewState["SortOrder"].ToString() == "ASC") {
					ViewState["SortOrder"] = "DESC";
				}
				else {
					ViewState["SortOrder"] = "ASC";
				}
			}
			else {
				ViewState["SortColumn"] = (string)e.SortExpression;
			}

			showFiles();
		}
		///</NewFeature>

		
		///<summary>Invoked when an user clicked the Create a New Directory button.</summary>
		private void NewFolderBtn_Click(object sender, System.EventArgs e) {
			if(this.NewFolderText.Text == "")	// user gave no folder name
				ReportError("No folder name given for new folder.", "Please type in a new folder name.");
			else
			{
				try
				{
					DirectoryInfo dir = new DirectoryInfo(Server.MapPath(_UploadDir + ViewState["fpUploadFolderRelativePath"].ToString() + "/" + NewFolderText.Text));
					dir.Create();
					showFiles();
				}
				catch		//(Exception ex)
				{
					ReportError("Cannot not create folder: " + this.NewFolderText.Text.ToString(),  "Ensure you have write permissions for the current directory");
				}
			}
		}
		
		///<summary>Invoked when an user clicked the Upload button.</summary>
		private void UploadBtn_Click(object sender, System.EventArgs e)	{
			
			bool IsFileAllowed = false;	//do not allow upload this file by default	
			String AllowedUploadFileExts = Session[FPTextBoxID + "fpAllowedUploadFileExts"].ToString();

			if(fileToUpload.PostedFile.FileName == "")	// no file selected
				ReportError("No file selected for upload.", "Please click Browse and select the file you wish to upload.");
			else
			{
				try
				{
					//check if it is allowed to upload file with these extensions and size					
					string filename = fileToUpload.PostedFile.FileName;	
					long fileSize = fileToUpload.PostedFile.ContentLength;
						
					//If a limit by exts set
					if (AllowedUploadFileExts!="") {
						//get an array of allowed exts
						Char[] cSplit = new Char[1];
						cSplit[0]=',';	
						String[] AllowedExts = AllowedUploadFileExts.Split(cSplit);

						//Check if the file extension conforms the restrictions
						if (Path.HasExtension(filename)) {
							String UploadFileExt = Path.GetExtension(filename);
							//Remove a dot from the file extension
							UploadFileExt = UploadFileExt.Replace(".", "");
							UploadFileExt = UploadFileExt.Trim();
							foreach (String Extension in AllowedExts) {
								//Remove a dot form a restricting extension (if is)
								String CleanExtension = Extension.Replace(".", "");
								CleanExtension = CleanExtension.Trim();
								if (UploadFileExt.ToLower() == CleanExtension.ToLower()){
									IsFileAllowed = true;
									break;
								}
							}
						}
					}
					else {
						IsFileAllowed = true;
					}
					
					if (!IsFileAllowed)	 {	
						ReportError("Sorry, this file type is not served.", "Please, upload files with the following expensions:\\n" + AllowedUploadFileExts);
					}

					//Check if uploaded file conforms the size limit
					if (Session[FPTextBoxID + "fpUploadSizeLimit"] != null) {
						long UploadSizeLimit = Convert.ToInt32(Session[FPTextBoxID + "fpUploadSizeLimit"]);
						if (UploadSizeLimit>0) {
							if (fileSize > UploadSizeLimit) {
								Response.Write("<script>alert(\"Too large file. Max file size is " + GetFileSize(UploadSizeLimit) + ".\"); </script>");
								IsFileAllowed = false;
							}
						}
					}
					
					//if everything is O'k
					if (IsFileAllowed) {
						String FileSizeStr = GetFileSize(fileSize);
						string togo = _UploadDir + ViewState["fpUploadFolderRelativePath"].ToString() + "/" + filename.Remove(0, filename.LastIndexOf("\\") + 1);
						fileToUpload.PostedFile.SaveAs(Server.MapPath(togo));	 					
						showFiles();
					}
				}
				catch //(Exception ex)
				{
					ReportError("Upload failed.",  "The file may be too large or \\naccess to the upload directory denied.");
				}
			}
		}
		
		///<summary>Invoked when an user changes a page.</summary>
		private void dgFSList_PageChaged(Object sender, DataGridPageChangedEventArgs e) {
			
			///<BugFix IssueID="1" ProductVersion="1.5" Description="In AWS FilePicker v 1.0 changing page did not influence the item you 
			//selectd in the grid -- you always selected the items from the first page. It happened due 
			//to page index that was missing because ViewState is turned off for the DataGrid. To solve the problem,
			//store the page index in the Session variable explicitly and get it when binding DataGrid.">
			//set current page index (if specified)
			Session[FPTextBoxID + "CurrentPageIndex"] = e.NewPageIndex;
			//<BugFix>

			dgFSList.CurrentPageIndex = e.NewPageIndex;
			showFiles();

		}

		///<summary>Prepares a string representation of a file size.</summary>
		private String GetFileSize(long Lenght) {
			if(Lenght > 1000000) return ((Lenght/1000000).ToString() + " Mb");
			else if(Lenght > 1000) return ((Lenght/1000).ToString() + " Kb");
			else return (Lenght.ToString() + " b");

		}

		///<summary>Adds a slash in the end of a path if it does not exist. </summary>
		private String AddSlashIfNotExist(String str) {
			if(str.LastIndexOf("/") != str.Length-1) {
				str += "/";
			} 
			return(str);
		}


		///<summary>Changes a path.</summary>
		private void ChangePath (String Direction) {				
			if(Direction == "/")	// goto root
				ViewState["fpUploadFolderRelativePath"] = "";
			else if(Direction == "../") // go one level up in directory tree
				ViewState["fpUploadFolderRelativePath"] = getParentDirectory(ViewState["fpUploadFolderRelativePath"].ToString());
			else	// add the directory name to the end of the current path
				ViewState["fpUploadFolderRelativePath"] = ViewState["fpUploadFolderRelativePath"].ToString() + Direction + "/";			

		}

		///<summary>Returns a name of a file that user selected into the parent TextBox.</summary>
		public void SelectFile(String FileName) {
			if ((bool)_UseAppRelPath == true) {
				FileName = _UploadDir + FileName; 
			}

			if (!Page.IsStartupScriptRegistered("UpdateCaller")) {
				StringBuilder strjscript = new StringBuilder("<script language='javascript'>\n", 2000);
				//strjscript.Append("function StartupScript() {\n");
				strjscript.Append("if (window.opener == null) ");
				strjscript.Append("  { window.close(); }\n");
				strjscript.Append("else \n");
				strjscript.Append("{\n");
				strjscript.Append("  var vCallerDocument = window.opener.document;\n  var vItem;\n");
				strjscript.Append("  vItem = vCallerDocument.getElementById('" + Request.QueryString["TextBoxID"] + "');\n");
				strjscript.Append("  vItem.value = '" + FileName + "';\n");
				strjscript.Append("}\n");
				strjscript.Append("window.close();\n");
				//strjscript.Append("}\n");  // function end
				strjscript.Append("\n</script>");

				Page.RegisterStartupScript("UpdateCaller", strjscript.ToString());
			}
		} 

		///<summary>Checks if a path valid and accessible.</summary>
		private DirectoryInfo ValidatePath(String Path){
			// called by showFiles(), does checks to see if directory to be opened is valid
			DirectoryInfo mainDir;
			try{
				mainDir = new DirectoryInfo(Server.MapPath(Path));
				if(mainDir.Exists == true)
					return mainDir;	// no problems
				else	// directory does not exist
					ReportError(@"The directory " + Server.MapPath(Path).Replace(@"\", @"\\") + " does not exist.",  "If you set the site root manually, try resetting it to the current directory: ./");
			}
			catch (DirectoryNotFoundException e)
			{
				ReportError("The path could not be found.",  "Try going to the root directory.");
				//Use the exception variable somehow to avoid warnings during compilation
				e.ToString();
			}
			
			catch (SecurityException e)
			{
				ReportError("You do not have permissions to view this directory.", "Please, or contact support service.");
				//Use the exception variable somehow to avoid warnings during compilation
				e.ToString();
			}
			catch (ArgumentException e)
			{
				ReportError("The path has invalid characters.",  "Try renaming the file and removing non-standard characters.");
				//Use the exception variable somehow to avoid warnings during compilation
				e.ToString();
			}
			catch (Exception e)
			{
				ReportError("Could not get directory information.",  "Try manually resetting the root path to ./");
				//Use the exception variable somehow to avoid warnings during compilation
				e.ToString();
			}
			return null;
		}

		///<summary>Returns a parent directory for a given directory.</summary>
		private string getParentDirectory(String RelativePath){	
			// this function works for /main/db/test/ as well as /main/db/test.aspx
			if(RelativePath == "./")
				return("../");	// trivial, no string manipulation required
			else if(RelativePath == "")
				return("");	// can't go higher than root
			else
			{
				// remove trailing "/" at end of path
				if(RelativePath.LastIndexOf("/") == RelativePath.Length-1){	
					RelativePath = RelativePath.Remove(RelativePath.LastIndexOf("/"), (RelativePath.Length - RelativePath.LastIndexOf("/")));
				}
				try
				{
					// remove the characters after the last occurence of / in the string. => parent directory
					RelativePath = RelativePath.Remove(RelativePath.LastIndexOf("/"), (RelativePath.Length - RelativePath.LastIndexOf("/")));
					return(RelativePath);
				}
				catch
				{
					return("");	// default to root;
				}
			}			
		}

		///<summary>Displays an error message.</summary>
		private void ReportError(string problem, string suggestion){
			// outputs error, in english, and in tech, and with any suggestions.
			StringBuilder strjscript = new StringBuilder("<script language='javascript'>\n");
			strjscript.Append("var Msg='There is a problem: \\n';\n");
			strjscript.Append("Msg +='" + problem + "\\n';\n");
			strjscript.Append("Msg +='Suggestion: \\n" + suggestion + "\\n';\n");
			strjscript.Append("alert(Msg);\n");
			strjscript.Append("window.close();\n");
			strjscript.Append("</script>");
			Response.Write(strjscript.ToString());
		}

		///<summary>Invoked when an user clicked the Up button.</summary>
		private void UpBtn_Click(Object sender, ImageClickEventArgs e){
			ChangePath("../");
			showFiles();
		}

		///<summary>Invoked when an user clicked the Go Root button.</summary>
		private void GoRoot_Click(Object sender, ImageClickEventArgs e){
			ChangePath("/");
			showFiles();
		}
		    
		///<summary>Invoked when a page initializes.</summary>
		override protected void OnInit(EventArgs e) {
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{ 
			this.Load += new EventHandler(Page_Load);
			this.UpBtn.Click += new ImageClickEventHandler(UpBtn_Click);
			this.GoRoot.Click += new ImageClickEventHandler(GoRoot_Click);
			this.UploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
			this.NewFolderBtn.Click += new System.EventHandler(this.NewFolderBtn_Click);
			dgFSList.ItemDataBound += new DataGridItemEventHandler(dgFSList_ItemDataBound);
			dgFSList.ItemCommand += new DataGridCommandEventHandler(dgFSList_ItemCommand);
			dgFSList.SortCommand += new DataGridSortCommandEventHandler(dgFSList_SortCommand);
			dgFSList.PageIndexChanged += new DataGridPageChangedEventHandler (dgFSList_PageChaged);
		}
	}
}