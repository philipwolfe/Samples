using System;
using System.Collections;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;

namespace Windows.Forms.Reports.ReportLibrary
{
	public class CommonFileSystem:VirtualFileSystem
	{
		#region class variables
		protected ArrayList FSList;
		protected VirtualFileSystem CurFS;
		protected string FRegRoot;
		#endregion

		#region constructor
		public CommonFileSystem(string ARegRoot)
		{
			FSList=new ArrayList();
			CurFS=new StandartFileSystem();
			FSList.Add(CurFS);
			FRegRoot=ARegRoot;
			LoadParams();
		}
		#endregion

		#region methods
		public void LoadParams()
		{
			RegistryKey reg;
			for(int i=0;i<FSList.Count;i++)
			{
				VirtualFileSystem vfs=(VirtualFileSystem)FSList[i];
				string s=FRegRoot+"\\Setup\\"+vfs.DisplayName;
				reg=Registry.CurrentUser.OpenSubKey(s,true);
				if(reg==null)
					reg=Registry.CurrentUser.CreateSubKey(s);
				vfs.Params=(string)reg.GetValue("Params");
			}
		}

		public bool OpenFile(string filename)
		{
			bool freturn=false;
			if(SelectFS())
			{
				CurFS.Files.Clear();
				Files.Add(CurFS.MediaName+":"+filename);
				freturn=true;
			}
			return freturn;
		}

		public override string ExtractFileNameOnly(string AFileName)
		{
			return CurFS.ExtractFileNameOnly(SelectFSByFileName(AFileName));
		}

		public override bool SaveDialogExecute()
		{
			return (SelectFS()&&CurFS.SaveDialogExecute());
		}

		public override string Caption()
		{
			return CurFS.MediaName+":"+CurFS.FileName;
		}

		public override FileStream CreateWriteStream(string AFileName)
		{
			return CurFS.CreateWriteStream(SelectFSByFileName(AFileName));
		}

		public override FileStream CreateReadStream(string AFileName)
		{
			return CurFS.CreateReadStream(SelectFSByFileName(AFileName));
		}

		public override bool OpenDialogExecute()
		{
			bool freturn=false;
			if(SelectFS())
			{
				freturn=CurFS.OpenDialogExecute();
				if(freturn)
				{
					for(int i=0;i<Files.Count;i++)
					{
						Files.SetString(i,CurFS.MediaName+":"+Files.GetString(i));
					}
				}
			}
			return freturn;
		}

		public override bool FileExists(string AFileName)
		{
			return CurFS.FileExists(SelectFSByFileName(AFileName));
		}

		public override void ExecuteSetup()
		{
			if(SelectFS())
				CurFS.ExecuteSetup();
		}

		protected bool SelectFS()
		{
			SelectFSDlg d;
			bool freturn=false;

			if(FSList.Count==1)
			{
				CurFS=(VirtualFileSystem)FSList[0];
				freturn=true;
			}
			else
			{
				if(FSList.Count>1)
				{
					d=new SelectFSDlg();
					for(int i=0;i<FSList.Count;i++)
					{
						d.listBox1.Items.Add(((VirtualFileSystem)FSList[i]).DisplayName);
					}
					d.listBox1.SelectedIndex=d.listBox1.Items.IndexOf(CurFS);
					if(d.ShowDialog()==DialogResult.OK)
					{
						CurFS=(VirtualFileSystem)d.listBox1.Items[d.listBox1.SelectedIndex];
						freturn=true;
					}
				}
			}
			return freturn;
		}

		protected string SelectFSByFileName(string Value)
		{
			int idx;
			string s,freturn;

			freturn=Value;
			CurFS=(VirtualFileSystem)FSList[0];
			idx=Value.IndexOf(":");
			if(idx>-1)
			{
				s=Value.Substring(0,idx);
				for(int i=0;i<FSList.Count;i++)
				{
					if(Generic.CT(s,((VirtualFileSystem)FSList[i]).MediaName))
					{
						CurFS=(VirtualFileSystem)FSList[i];
						freturn=Value.Substring(idx+1,Value.Length-idx-1);
						break;
					}
				}
			}
			return freturn;
		}
		#endregion

		#region properties
		public new string FileName
		{
			get
			{
				return CurFS.MediaName+":"+CurFS.FileName;
			}
			set
			{
				CurFS.FileName=SelectFSByFileName(value);
			}
		}

		public override string DisplayName
		{
			get
			{
				return CurFS.DisplayName;
			}
		}

		public override string Params
		{
			get
			{
				return CurFS.Params;
			}
			set
			{
				CurFS.Params=value;
			}
		}

		public override StringList Files
		{
			get
			{
				return CurFS.Files;
			}
		}
		#endregion
	}
}
