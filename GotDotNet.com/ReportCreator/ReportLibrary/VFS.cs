using System;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region VirtualFileSystem
	[ToolboxItem(false)]
	public class VirtualFileSystem:Component
	{
		#region class variables
		protected StringList FFiles;
		string FFilter;
		protected string FFileName;
		protected FileStream FReadStream;
		protected FileStream FWriteStream;
		string FInitialDir;
		protected string FTitle;
		FileMode FFileMode;
		bool FMultiSelect;
		#endregion

		#region class events
		public event EventHandler OnExecuteSetup;
		#endregion

		#region constructor
		public VirtualFileSystem()
		{
			FFiles=new StringList("");
			FileMode=FileMode.Create;
			MultiSelect=true;
		}
		#endregion

		#region class properties
		public virtual StringList Files
		{
			get
			{
				return FFiles;
			}
		}

		public string InitialDir
		{
			get
			{
				return FInitialDir;
			}
			set
			{
				FInitialDir=value;
			}
		}

		public string FileName
		{
			get
			{
				return FFileName;
			}
			set
			{
				FFileName=value;
			}
		}

		public virtual string Params
		{
			get
			{
				return null;
			}
			set
			{
				
			}
		}

		public bool MultiSelect
		{
			get
			{
				return FMultiSelect;
			}
			set
			{
				FMultiSelect=value;
			}
		}

		[DefaultValue(FileMode.Create)]
		public FileMode FileMode
		{
			get
			{
				return FFileMode;
			}
			set
			{
				FFileMode=value;
			}
		}

		public string Filter
		{
			get
			{
				return FFilter;
			}
			set
			{
				FFilter=value;
			}
		}

		public string MediaName
		{
			get
			{
				return GetMediaName();
			}
		}

		[Browsable(false)]
		public virtual string DisplayName
		{
			get
			{
				return null;
			}						
		}
		#endregion

		#region class methods
		public virtual bool FileExists(string AFileName)
		{
			return false;
		}

		public virtual void ExecuteSetup()
		{
			if(OnExecuteSetup!=null)
				OnExecuteSetup(this,EventArgs.Empty);
		}

		public virtual string Caption()
		{
			return FileName;
		}
		public virtual bool OpenDialogExecute()
		{
			return false;
		}

		public virtual string ExtractFileNameOnly(string AFileName)
		{
			return "";
		}

		public virtual FileStream CreateReadStream(string AFileName)
		{
			return null;
		}

		public virtual FileStream CreateWriteStream(string AFileName)
		{
			return null;
		}

		public virtual void CloseWriteStream()
		{
			if(FWriteStream!=null)
				FWriteStream.Close();
		}

		public virtual bool SaveDialogExecute()
		{
			return false;
		}

		public virtual string GetMediaName()
		{
			return "";
		}
		#endregion	
	}
	#endregion

	#region StandartFileSystem
	[ToolboxItem(true)]
	public class StandartFileSystem:VirtualFileSystem
	{
		#region class variables
		StringList ExtList;
		string FDefaultExt;
		#endregion
		
		#region class methods
		public override bool OpenDialogExecute()
		{
			OpenFileDialog OpenDialog=new OpenFileDialog();
			OpenDialog.FileName=FileName;
			OpenDialog.DefaultExt=DefaultExt;
			OpenDialog.Filter=Filter;
			OpenDialog.Multiselect=MultiSelect;
			OpenDialog.Title=Title;

			if(OpenDialog.ShowDialog()==DialogResult.OK)
			{
				FFiles.Clear();
				FFiles.AddRange(OpenDialog.FileNames);
				FileName=OpenDialog.FileName;
				return true;				
			}
			else
				return false;
		}

		public override bool FileExists(string AFileName)
		{
			return File.Exists(AFileName);
		}

		public override void ExecuteSetup()
		{
			base.ExecuteSetup();
			SFSetup d=new SFSetup();
			try
			{
				for(int i=0;i<ExtList.Count;i++)
				{
					d.listBox1.Items.Add(ExtList.GetString(i));
				}
				d.Text=DisplayName;
				if(d.ShowDialog()==DialogResult.OK)
				{
					ExtList.Clear();
					ExtList.AddStrings(d.ExtList);
				}
			}
			finally
			{
				d.Dispose();
			}
		}

		public override string GetMediaName()
		{
			return "File";
		}

		public override string ExtractFileNameOnly(string AFileName)
		{
			int p=0;
			while(p>-1)
			{
				p=AFileName.IndexOf("\\");
				AFileName=AFileName.Substring(p+1);
			}
			p=AFileName.IndexOf(".");
			if(p>0)
				AFileName=AFileName.Substring(0,AFileName.Length-(AFileName.Length-p));
			return AFileName;
		}

		public override FileStream CreateWriteStream(string AFileName)
		{
			FFileName=AFileName;
			FWriteStream=new FileStream(AFileName,FileMode);
			return FWriteStream;
		}

		public override bool SaveDialogExecute()
		{
			bool freturn;
			SaveFileDialog SaveDialog=new SaveFileDialog();
			SaveDialog.FileName=FileName;
			SaveDialog.InitialDirectory=InitialDir;
			SaveDialog.DefaultExt=DefaultExt;
			SaveDialog.Filter=Filter;
			SaveDialog.Title=Title;

			if(SaveDialog.ShowDialog()==DialogResult.OK)
			{
				FileName=SaveDialog.FileName;
				freturn=true;
			}
			else
				freturn=false;
			return freturn;
		}

		public override FileStream CreateReadStream(string AFileName)
		{
			FFileName=AFileName;
			FReadStream=new FileStream(AFileName,FileMode.Open);
			return FReadStream;
		}
		#endregion

		#region constructor
		public StandartFileSystem()
		{
			ExtList=new StringList("StandardFileSystem.ExtList");
			ExtList.Sorted=true;
			ExtList.Duplicate=false;
		}
		#endregion

		#region class properties
		public string Title
		{
			get
			{
				return FTitle;
			}
			set
			{
				FTitle=value;
			}
		}

		public override string DisplayName
		{
			get
			{
				return "Standart";
			}
		}

		public override string Params
		{
			get
			{			
				return ExtList.GetCommaText();
			}
			set
			{
				string s;
				if(value!="" && value!=null)
					ExtList.SetCommaText(value);
				if(ExtList.Count==0)
				{
					ExtList.Add("SD");
					ExtList.Add("SDT");
				}
				DefaultExt="";
				if(ExtList.Count>0)
				{
					Filter="";
					s="";
					for(int i=0;i<ExtList.Count-1;i++)
					{
						s=s+"*."+ExtList.GetString(i)+";";
					}
					s=s+"*."+ExtList.GetString(ExtList.Count-1);
					Filter="Reports ("+s+")|"+s+"|";
					DefaultExt=ExtList.GetString(0);
				}
				Filter=Filter+"All files (*.*)|*.*";
			}
		}

		public string DefaultExt
		{
			get
			{
				return FDefaultExt;
			}
			set
			{
				FDefaultExt=value;
			}
		}
		#endregion	
	}
	#endregion
}
