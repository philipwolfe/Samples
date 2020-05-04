using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.VSIP;

using IServiceProvider = System.IServiceProvider;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using VSStd97CmdID = Microsoft.VisualStudio.VSIP.NativeMethods.VSStd97CmdID;

using Windows.Forms.Designer;
using Windows.Forms.Reports.ReportLibrary;

namespace Vsip.VsPackage
{
	/// <summary>
	/// This control host the editor (an extended RichTextBox) and is responsible for
	/// handling the commands targeted to the editor as well as saving and loading
	/// the document. This control also implement the search and replace functionalities.
	/// </summary>
	public class EditorPane : EditorForm,
		IVsPersistDocData,
		IPersistFileFormat,
		IOleCommandTarget,
		IVsWindowPane,
		IVsDocDataFileChangeControl,
		IVsFileChangeEvents
	{
		public const uint myFormat = 0;
		public const string myExtension = ".sd";

		#region Fields
		IOleServiceProvider vsServiceProvider = null;
		private VsPackage myPackage = null;

		private string fileName;
		private bool isDirty;
		// This flag is true when we are asking the QueryEditQuerySave service if we can edit the
		// file. It is used to avoid to have more than one request queued.
		private bool gettingCheckoutStatus;


		// Counter of the file system changes to ignore.
		private int changesToIgnore;
		// Cookie for the subscription to the file system notification events.
		private uint fileChangeNotifyCookie;
		// This flag is used to know when the reload procedure is running.
		private bool isFileReloading;

		private const char EndLine = (char)10;

		private IVsRunningDocumentTable runningDocTable;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Timer reloadTimer;
		private Microsoft.VisualStudio.VSIP.Helper.SelectionContainer selContainer;
		private ITrackSelection trackSel;
		ArrayList listObjects;
		EditorProperties EditProp;
		bool FSetUndo;
		#endregion

		private EditorPane()
		{
			PrivateInit(null);

			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		public EditorPane(VsPackage package)
		{
			EditRep.SelectCell+=new SelectCellEventHandler(EditRep_SelectCell);
			EditRep.SelectBand+=new SelectBandEventHandler(EditRep_SelectBand);
			EditRep.Change+=new EventHandler(EditRep_Change);
			InitializeComponent();
			PrivateInit(package);
			PrivateInit();
		}

		private void PrivateInit(VsPackage package)
		{
			myPackage = package;
			gettingCheckoutStatus = false;
			isFileReloading = false;
			fileChangeNotifyCookie = NativeMethods.VSCOOKIE_NIL;
			changesToIgnore = 0;
		}

		private void PrivateInit()
		{

			trackSel = null;
			listObjects = new ArrayList();
			EditRep.Units=Units.Cm;

			// Create the SelectionContainer object.
			selContainer = new Microsoft.VisualStudio.VSIP.Helper.SelectionContainer(true, false);
			selContainer.SelectableObjects = listObjects;
			selContainer.SelectedObjects = listObjects;
		}

		private ITrackSelection TrackSelection
		{
			get
			{
				if (trackSel == null)
				{
					trackSel = (ITrackSelection)GetVsService( typeof(ITrackSelection) );
				}
				return trackSel;
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				// Unsubscribe from the notification of file system events
				AdviseFileChange(false);
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		/// <summary>
		/// Retrieves the requested service from the Shell.
		/// </summary>
		/// <param name="serviceType">Service that is being requested</param>
		/// <returns>An object which type is as requested</returns>
		public object GetVsService(Type serviceType) 
		{
			// Ask the shell for the requested service
			Guid serviceGuid = serviceType.GUID;
			Guid interfaceGuid = NativeMethods.IID_IUnknown;
			IntPtr serviceObjectPtr = IntPtr.Zero;

			int hresult = vsServiceProvider.QueryService(
				ref serviceGuid,
				ref interfaceGuid,
				out serviceObjectPtr);
			if ( NativeMethods.Failed(hresult) )
				throw new COMException(string.Format("Failed to get Service: {0}", serviceType.Name),
					hresult);
			return Marshal.GetObjectForIUnknown(serviceObjectPtr);
		}

		private void NotifyDocChanged(bool isReload)
		{
			// Get a reference to the Running Document Table
			if ( null == runningDocTable )
			{
				runningDocTable = (IVsRunningDocumentTable)GetVsService(typeof(SVsRunningDocumentTable));
			}

			// Lock the document
			uint docCookie;
			IVsHierarchy hierarchy;
			uint itemID;
			IntPtr    docData;
			int hr = runningDocTable.FindAndLockDocument(
				(uint)_VSRDTFLAGS.RDT_ReadLock,
				fileName,
				out hierarchy,
				out itemID,
				out docData,
				out docCookie
				);
			NativeMethods.ThrowOnFailure(hr);

			// Send the notification
			hr = runningDocTable.NotifyDocumentChanged(docCookie, (uint)__VSRDTATTRIB.RDTA_DocDataReloaded);
			NativeMethods.ThrowOnFailure(hr);

			// Unlock the document
			hr = runningDocTable.UnlockDocument((uint)_VSRDTFLAGS.RDT_ReadLock, docCookie);
			NativeMethods.ThrowOnFailure(hr);
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support.
		/// normally you would not modify the contents of this method with the code editor and instead
		/// manipulate it with the design view instead.  In the case where you are creating a new VS
		/// editor and no longer need use of the wizard-generated controls, you can feel free to edit
		/// this code in the code view or in the design view.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
     
			this.reloadTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// reloadTimer
			// 
			this.reloadTimer.Tick += new System.EventHandler(this.reloadTimer_Tick);
			// 
			// EditorPane
			// 
			this.Name = "EditorPane";
			this.ResumeLayout(false);

		}
		#endregion


		#region IOleCommandTarget Members

		/// <summary>
		/// The shell call this function to know if a menu item should be visible and
		/// if it should be enabled/disabled.
		/// Note that this function will only be called when an instance of this editor
		/// is open.
		/// </summary>
		/// <param name="guidCmdGroup">Guid describing which set of command the current command(s) belong to</param>
		/// <param name="cCmds">Number of command which status are being asked for</param>
		/// <param name="prgCmds">Information for each command</param>
		/// <param name="pCmdText">Used to dynamically change the command text</param>
		/// <returns>HRESULT</returns>
		public int QueryStatus(ref Guid guidCmdGroup, uint cCmds, OLECMD[] prgCmds, System.IntPtr pCmdText)
		{
			OLECMDF cmdf = OLECMDF.OLECMDF_SUPPORTED;
			Debug.Assert(cCmds == 1, "Multiple commands");
			Debug.Assert(prgCmds!=null, "NULL argument");

			if ((prgCmds == null))
				return NativeMethods.E_INVALIDARG;

			
			if (guidCmdGroup == NativeMethods.guidVSStd97)
			{
				// Process standard Commands
				switch (prgCmds[0].cmdID)
				{
					case (uint)VSStd97CmdID.cmdidPrint:
					{
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					
					case (uint)VSStd97CmdID.cmdidPageSetup:
					{
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
				
					case (uint)VSStd97CmdID.cmdidSelectAll:
					{
						// Always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case (uint)VSStd97CmdID.cmdidCopy:
					case (uint)VSStd97CmdID.cmdidCut:
					case (uint)VSStd97CmdID.cmdidDelete:					
					{
						cmdf |= OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case (uint)VSStd97CmdID.cmdidPaste:
					{
						// Enable if clipboard has content we can paste
						if (CanPaste())
							cmdf |= OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case (uint)VSStd97CmdID.cmdidRedo:
					{
						if (EditRep.Undo.CanRedo())
							cmdf |= OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case (uint)VSStd97CmdID.cmdidUndo:
					{
						if (EditRep.Undo.CanUndo())
							cmdf |= OLECMDF.OLECMDF_ENABLED;
						break;
					}
					default:
						return (int)(Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_NOTSUPPORTED);
				}
				
			}
			else if (guidCmdGroup == GuidList.guidVsPackageCmdSet)
			{
				// Process our Commands
				switch (prgCmds[0].cmdID)
				{
					case PkgCmdIDList.icmd_PageColor:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_PageBackground:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_AddCell:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_DeleteCell:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_CellMoveLeft:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_CellMoveRight:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_SplitCell:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_MergeCellsHor:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_MergeCellsVer:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_CellShape:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_CellProperties:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_AddBand:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_Deleteband:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_BandMoveUp:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_BandMoveDown:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_Styles:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
					case PkgCmdIDList.icmd_Preview:
					{
						// This command is always enabled
						cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
						break;
					}
		
					default:
						return (int)(Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_NOTSUPPORTED);
				}
			}
			else
				return (int)(Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_NOTSUPPORTED);
			prgCmds[0].cmdf = (uint)cmdf;
			return NativeMethods.S_OK;
		}

		/// <summary>
		/// Execute a command
		/// Typically, only the first 2 arguments are used (to identify which command should be run)
		/// </summary>
		/// <param name="guidCmdGroup">Guid describing which set of command the current command(s) belong to</param>
		/// <param name="nCmdID">Command that should be executed</param>
		/// <param name="nCmdexecopt">options for the command</param>
		/// <param name="pvaIn">Pointer to input arguments</param>
		/// <param name="pvaOut">Pointer to command output</param>
		/// <returns></returns>
		public int Exec(ref Guid guidCmdGroup, uint nCmdID, uint nCmdexecopt, System.IntPtr pvaIn, System.IntPtr pvaOut)
		{
			Trace.WriteLine (string.Format("Entering Exec() of: {0}", this.ToString()));
			
			if (guidCmdGroup == NativeMethods.guidVSStd97)
			{
				// Process standard Visual Studio Commands
				switch (nCmdID)
				{
					case (uint)VSStd97CmdID.cmdidPageSetup:
					{
						if(EditRep.PageSettings())
						{
							EditRep.Invalidate();
							EditRep.OnChange();
						}
						break;
					}
					case (uint)VSStd97CmdID.cmdidPrint:
					{
						EditRep.Print();
						break;
					}
					case (uint)VSStd97CmdID.cmdidCopy:
					{
						Copy();
						break;
					}
					case (uint)VSStd97CmdID.cmdidCut:
					{
						Copy();
						Delete();
						break;
					}
					case (uint)VSStd97CmdID.cmdidDelete:
					{
						Delete();
						break;
					}
					case (uint)VSStd97CmdID.cmdidPaste:
					{
						Paste();
						break;
					}
					case (uint)VSStd97CmdID.cmdidRedo:
					{
						try
						{
							FSetUndo=false;
							if(EditRep.Undo.CanRedo())
							{
								EditRep.Template.SetText(EditRep.Undo.GetRedo());
								EditRep.ClearSel();

								EditRep.CurrBandIdx=Math.Min(EditRep.CurrBandIdx,EditRep.SrcRep.BandCount-1);
								EditRep.CurrCellIdx=Math.Min(EditRep.CurrCellIdx,EditRep.CurrBand.CellCount-1);
								EditRep.SelAdd(EditRep.CurrBandIdx,EditRep.CurrCellIdx);
							}
						}
						finally
						{
							EditRep.Invalidate();
							FSetUndo=true;
						}	
						break;
					}
					case (uint)VSStd97CmdID.cmdidUndo:
					{
						try
						{
							FSetUndo=false;
							if(EditRep.Undo.CanUndo())
							{
								EditRep.Template.SetText(EditRep.Undo.GetUndo());
								EditRep.ClearSel();

								EditRep.CurrBandIdx=Math.Min(EditRep.CurrBandIdx,EditRep.SrcRep.BandCount-1);
								EditRep.CurrCellIdx=Math.Min(EditRep.CurrCellIdx,EditRep.CurrBand.CellCount-1);
								EditRep.SelAdd(EditRep.CurrBandIdx,EditRep.CurrCellIdx);
							}
						}
						finally
						{
							EditRep.Invalidate();
							FSetUndo=true;
						}
						break;
					}
					case (uint)VSStd97CmdID.cmdidSelectAll:
					{
						EditRep.SelAll();
						break;
					}
					default:
						return (int)(Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_NOTSUPPORTED);
				}
			}
			else if (guidCmdGroup == GuidList.guidVsPackageCmdSet)
			{
				switch (nCmdID)
				{
					case PkgCmdIDList.icmd_PageColor:
					{
						GraidentDialog d=new GraidentDialog();
						if(!EditRep.SrcRep.PageGraident)
						{
							d.comboBox1.SelectedIndex=0;
							d.BackgroundColor=EditRep.SrcRep.PageColor;
						}
						else
						{
							d.comboBox1.SelectedItem=EditRep.SrcRep.PageFillDirection;
							d.BackgroundColor=EditRep.SrcRep.PageColor;
							d.GraidentColor=EditRep.SrcRep.PageGraidentColor;
						}

						if(d.ShowDialog()==DialogResult.OK)
						{
							if(d.comboBox1.SelectedIndex==0)
								EditRep.SrcRep.PageGraident=false;
							else
							{
								EditRep.SrcRep.PageGraident=true;
								EditRep.SrcRep.PageGraidentColor=d.GraidentColor;
								EditRep.SrcRep.PageFillDirection=((FillDirection)d.comboBox1.SelectedItem);
							}
							EditRep.SrcRep.PageColor=d.BackgroundColor;
							EditRep.OnChange();
							Refresh();
						}
						break;
					}
					case PkgCmdIDList.icmd_PageBackground:
					{
						PageBackground d=new PageBackground();
						d.textBox4.Text=EditRep.SrcRep.PagePictureFileName;
						d.checkBox1.Checked=EditRep.SrcRep.PageLinkPictureToFile;
						d.comboBox1.SelectedIndex=(int)EditRep.SrcRep.PageImagePosition;
						if(d.ShowDialog()==DialogResult.OK)
						{
							if(d.checkBox1.Checked)
							{
								EditRep.SrcRep.PageLinkPictureToFile=true;
								EditRep.SrcRep.PagePictureFileName=d.textBox4.Text;
							}
							else
							{
								EditRep.SrcRep.PageLinkPictureToFile=false;
								try
								{
									EditRep.SrcRep.PagePicture=new Bitmap(d.textBox4.Text);
								}
								catch
								{
									d.textBox4.Text="";
								}
								EditRep.SrcRep.PagePictureFileName="";
							}
				
							EditRep.SrcRep.PageImagePosition=(ImagePosition)d.comboBox1.SelectedItem;
							if(d.textBox4.Text!="")
								EditRep.SrcRep.PageImage=true;
							else
							{
								EditRep.SrcRep.PageImage=false;
							}
							EditRep.OnChange();
							Refresh();
						}
						break;
					}
					case PkgCmdIDList.icmd_AddCell:
					{
						if(EditRep.CurrBand!=null)
						{
							EditRep.CurrBand.sender=true;
							EditRep.CurrBand.NewCell();
							EditRep.CurrCellIdx=EditRep.CurrBand.CellCount-1;
							EditRep.ClearSel();
							EditRep.SelAdd(EditRep.CurrBandIdx,EditRep.CurrCellIdx);
							EditRep.OnChange();
							EditRep.Invalidate();
						}
						break;
					}
					case PkgCmdIDList.icmd_DeleteCell:
					{
						if((EditRep.Focus())&&(EditRep.SelCount>0))
						{
							EditRep.DeleteSelCells();
							EditRep.SelAdd(EditRep.CurrBandIdx,EditRep.CurrCellIdx);
							EditRep.Invalidate();
							EditRep.OnChange();
						}
						break;
					}
					case PkgCmdIDList.icmd_CellMoveLeft:
					{
						bool ismodified=false;

						if(EditRep.SelCount>0)
						{
							for(int idxband=0;idxband<EditRep.SrcRep.BandCount;idxband++)
							{
								for(int idxcell=1;idxcell<EditRep.SrcRep.GetBand(idxband).CellCount;idxcell++)
								{
									if(EditRep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
									{
										EditRep.SrcRep.GetBand(idxband).MoveCell(idxcell,idxcell-1);
										ismodified=true;
									}
								}
							}
						}
						else
						{
							if(EditRep.CurrCellIdx>0)
							{
								EditRep.SrcRep.GetBand(EditRep.CurrBandIdx).MoveCell(EditRep.CurrCellIdx,EditRep.CurrCellIdx-1);
								ismodified=true;
							}
						}
						if(ismodified)
						{
							EditRep.CurrCellIdx=EditRep.CurrCellIdx-1;
							EditRep.Invalidate();
							EditRep.OnChange();
						}
						break;
					}
					case PkgCmdIDList.icmd_CellMoveRight:
					{
						bool ismodified=false;

						if(EditRep.SelCount>0)
						{
							for(int idxband=0;idxband<EditRep.SrcRep.BandCount;idxband++)
							{
								for(int idxcell=EditRep.SrcRep.GetBand(idxband).CellCount-2;idxcell>-1;idxcell--)
								{
									if(EditRep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
									{
										EditRep.SrcRep.GetBand(idxband).MoveCell(idxcell,idxcell+1);
										ismodified=true;
									}
								}
							}
						}
						else
						{
							if(EditRep.CurrCellIdx<EditRep.SrcRep.GetBand(EditRep.CurrBandIdx).CellCount-1)
							{
								EditRep.SrcRep.GetBand(EditRep.CurrBandIdx).MoveCell(EditRep.CurrCellIdx,EditRep.CurrCellIdx+1);
								ismodified=true;
							}
						}
						if(ismodified)
						{
							EditRep.CurrCellIdx=EditRep.CurrCellIdx+1;
							EditRep.Invalidate();
							EditRep.OnChange();
						}
						break;
					}
					case PkgCmdIDList.icmd_SplitCell:
					{
						if((EditRep.CurrBand!=null)&&(EditRep.CurrCell!=null))
						{
							EditRep.CurrBand.Split(EditRep.CurrCell);
							EditRep.Invalidate();
							EditRep.OnChange();
						}
						break;
					}
					case PkgCmdIDList.icmd_MergeCellsHor:
					{
						if(EditRep.MergeSelectedCells())
						{
							EditRep.Invalidate();
							EditRep.OnChange();
						}
						break;
					}
					case PkgCmdIDList.icmd_MergeCellsVer:
					{
						int idxband, idxcell, idxband2, idxcell2;
						float l,r;
						Cell cell;

						try
						{
							for(idxband=0;idxband<EditRep.SrcRep.BandCount;idxband++)
							{
								if(EditRep.SrcRep.GetBand(idxband).Selected)
								{
									for(idxcell=0;idxcell<EditRep.SrcRep.GetBand(idxband).CellCount;idxcell++)
									{
										if(EditRep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
										{
											cell=EditRep.SrcRep.GetBand(idxband).GetCell(idxcell);
											l=EditRep.SrcRep.GetBand(idxband).GetLefts(idxcell);
											r=EditRep.SrcRep.GetBand(idxband).GetRights(idxcell);

											for(idxband2=idxband+1;idxband2<EditRep.SrcRep.BandCount;idxband2++)
											{
												if(!(EditRep.SrcRep.GetBand(idxband2).Selected))
												{
													cell.Focused=true;
													break;
												}
												for(idxcell2=0;idxcell2<EditRep.SrcRep.GetBand(idxband2).CellCount;idxcell2++)
												{
													if((EditRep.SrcRep.GetBand(idxband2).GetCell(idxcell2).Selected)&&
														(EditRep.SrcRep.GetBand(idxband2).GetLefts(idxcell2)==l)&&
														(EditRep.SrcRep.GetBand(idxband2).GetRights(idxcell2)==r))
													{
														EditRep.SrcRep.GetBand(idxband2).GetCell(idxcell2).Shared=true;
														EditRep.SrcRep.GetBand(idxband2).BandChange(this,EventArgs.Empty);
														break;
													}
												}
											}
										}
									}
								}
							}
						}
						finally
						{
							EditRep.OnChange();
							EditRep.Refresh();
						}
						break;
					}
					case PkgCmdIDList.icmd_CellShape:
					{
						ShapeDialog d=new ShapeDialog();	
						if(EditRep.CurrCell.Shape==false)
						{
							d.comboBox2.SelectedIndex=0;
							d.comboBox1.SelectedIndex=0;
							d.comboBox3.SelectedIndex=0;
						}
						else
						{
							d.comboBox2.SelectedItem=EditRep.CurrCell.ShapeType;
							d.BackgroundColor=EditRep.CurrCell.ShapeColor;
							d.BorderColor=EditRep.CurrCell.ShapeBorderColor;
							d.textBox1.Text=EditRep.CurrCell.ShapeBorderWidth.ToString();
							d.comboBox3.SelectedItem=EditRep.CurrCell.ShapeBorderStyle;
							if(EditRep.CurrCell.ShapeGraident==false)
								d.comboBox1.SelectedIndex=0;
							else
							{
								d.comboBox1.SelectedItem=EditRep.CurrCell.ShapeFillDirection;
								d.GraidentColor=EditRep.CurrCell.ShapeGraidentColor;
							}
						}

						if(d.ShowDialog()==DialogResult.OK)
						{
							for(int i=0;i<EditRep.SelCount;i++)
							{
								if(d.comboBox2.SelectedIndex==0)
									EditRep.GetSel(i).Shape=false;
								else
								{
									EditRep.GetSel(i).Shape=true;
									EditRep.GetSel(i).ShapeColor=d.BackgroundColor;
									EditRep.GetSel(i).ShapeType=((ShapeType)d.comboBox2.SelectedItem);
									EditRep.GetSel(i).ShapeBorderColor=d.BorderColor;
									EditRep.GetSel(i).ShapeBorderStyle=((System.Drawing.Drawing2D.DashStyle)d.comboBox3.SelectedItem);
									try
									{
										EditRep.GetSel(i).ShapeBorderWidth=Convert.ToInt32(d.textBox1.Text);
									}
									catch
									{
										EditRep.GetSel(i).ShapeBorderWidth=0;
									}
									if(d.comboBox1.SelectedIndex==0)
										EditRep.GetSel(i).ShapeGraident=false;
									else
									{
										EditRep.GetSel(i).ShapeGraident=true;
										EditRep.GetSel(i).ShapeGraidentColor=d.GraidentColor;
										EditRep.GetSel(i).ShapeFillDirection=((FillDirection)d.comboBox1.SelectedItem);
									}
								}
							}
							EditRep.OnChange();
						}
						EditRep.Refresh();
						d.Dispose();
						break;
					}
					case PkgCmdIDList.icmd_CellProperties:
					{
						CellPropDlg d=new CellPropDlg();
						d.Rep=EditRep;
						if(d.ShowDialog()==DialogResult.OK)
						{
							EditRep.OnChange();
							EditRep.Refresh();
						}
						d.Dispose();
						break;
					}
					case PkgCmdIDList.icmd_AddBand:
					{
						EditRep.sender=true;
						EditRep.NewBand();
						EditRep.ClearSel();
						EditRep.CurrBandIdx=EditRep.SrcRep.BandCount-1;
						EditRep.SelAdd(EditRep.CurrBandIdx,EditRep.CurrCellIdx);
						EditRep.OnChange();
						this.Refresh();
						break;
					}
					case PkgCmdIDList.icmd_Deleteband:
					{
						for(int idxband=EditRep.SrcRep.BandCount-1;idxband>-1;idxband--)
						{
							if(EditRep.SrcRep.GetBand(idxband).Selected)
							{
								EditRep.DeleteBand(idxband);
							}
						}
						EditRep.Invalidate();
						EditRep.OnChange();
						break;
					}
					case PkgCmdIDList.icmd_BandMoveUp:
					{
						bool IsModified=false;

						for(int idxband=0;idxband<EditRep.SrcRep.BandCount;idxband++)
						{
							if(EditRep.SrcRep.GetBand(idxband).Selected)
							{
								if(!EditRep.SrcRep.MoveBand(idxband,idxband-1))
									break;
								IsModified=true;
							}
						}
						if(IsModified)
						{
							EditRep.CurrBandIdx=EditRep.CurrBandIdx-1;
							EditRep.Invalidate();
							EditRep.OnChange();
						}
						break;
					}
					case PkgCmdIDList.icmd_BandMoveDown:
					{
						bool IsModified=false;

						for(int idxband=EditRep.SrcRep.BandCount-1;idxband>-1;idxband--)
						{
							if(EditRep.SrcRep.GetBand(idxband).Selected)
							{
								if(!EditRep.SrcRep.MoveBand(idxband,idxband+1))
									break;
								IsModified=true;
							}
						}
						if(IsModified)
						{
							EditRep.CurrBandIdx=EditRep.CurrBandIdx+1;
							EditRep.Invalidate();
							EditRep.OnChange();
						}
						break;
					}
					case PkgCmdIDList.icmd_Styles:
					{
						StyleDlg dlg=new StyleDlg();
						dlg.StyleList.AddRange(EditRep.SrcRep.StyleList);
						dlg.Rep=EditRep;
						if(dlg.ShowDialog()==DialogResult.OK)
						{
							EditRep.SrcRep.StyleList.Clear();
							EditRep.SrcRep.StyleList.AddRange(dlg.StyleList);
							EditRep.OnChange();
							Refresh();
						}
						break;
					}
					case PkgCmdIDList.icmd_Preview:
					{
						EditRep.Preview();
						break;
					}
						
					default:
						return (int)(Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_NOTSUPPORTED);
				}
			}
			else
				return (int)Microsoft.VisualStudio.OLE.Interop.Constants.OLECMDERR_E_UNKNOWNGROUP;

			return NativeMethods.S_OK;
		}
		#endregion


		#region IVsWindowPane Members

		public int SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp)
		{
			vsServiceProvider = psp;
			return NativeMethods.S_OK;
		}

		int Microsoft.VisualStudio.Shell.Interop.IVsWindowPane.TranslateAccelerator(MSG[] lpmsg)
		{
			return NativeMethods.S_FALSE;
		}

		int Microsoft.VisualStudio.Shell.Interop.IVsWindowPane.SaveViewState(IStream pStream)
		{
			return NativeMethods.S_OK;
		}

		int Microsoft.VisualStudio.Shell.Interop.IVsWindowPane.LoadViewState(IStream pStream)
		{
			return NativeMethods.S_OK;
		}

		int Microsoft.VisualStudio.Shell.Interop.IVsWindowPane.GetDefaultSize(SIZE[] size)
		{
			if (size.Length >= 1)
			{
				size[0].cx = Size.Width;
				size[0].cy = Size.Height;
			}

			return NativeMethods.S_OK;
		}

		int Microsoft.VisualStudio.Shell.Interop.IVsWindowPane.CreatePaneWindow(System.IntPtr hwndParent, int x, int y, int cx, int cy, out System.IntPtr hwnd)
		{
			NativeMethods.SetParent(Handle, hwndParent);
			hwnd = Handle;

			Size = new System.Drawing.Size(cx - x, cy - y);
			return NativeMethods.S_OK;
		}

		public int ClosePane()
		{
			this.Dispose(true);
			return NativeMethods.S_OK;
		}

		#endregion

		int Microsoft.VisualStudio.OLE.Interop.IPersist.GetClassID(out Guid pClassID)
		{
			pClassID = GuidList.guidEditorFactory;
			return NativeMethods.S_OK;
		}


		#region IPersistFileFormat Members

		int IPersistFileFormat.SaveCompleted(string pszFilename)
		{
			// TODO:  Add Editor.SaveCompleted implementation
			return NativeMethods.S_OK;
		}

		int IPersistFileFormat.GetCurFile(out string ppszFilename, out uint pnFormatIndex)
		{
			// We only support 1 format so return its index
			pnFormatIndex = myFormat;
			ppszFilename = fileName;
			return NativeMethods.S_OK;
		}

		int IPersistFileFormat.InitNew(uint nFormatIndex)
		{
			if (nFormatIndex != myFormat)
			{
				return NativeMethods.E_INVALIDARG;
			}
			// until someone change the file, we can consider it not dirty as
			// the user would be annoyed if we prompt him to save an empty file
			isDirty = false;
			return NativeMethods.S_OK;
		}

		int IPersistFileFormat.GetClassID(out Guid pClassID)
		{
			return ((Microsoft.VisualStudio.OLE.Interop.IPersist)this).GetClassID(out pClassID);
		}

		int IPersistFileFormat.GetFormatList(out string ppszFormatList)
		{
			string formatList = string.Format("Reporteditor (*{0}){1}*{0}{1}{1}", myExtension, EndLine);
			ppszFormatList = formatList;
			return NativeMethods.S_OK;
		}

		int IPersistFileFormat.Load(string pszFilename, uint grfMode, int fReadOnly)
		{
			if ( (pszFilename == null) && 
				((fileName == null) || (fileName.Length == 0)) )
			{
				throw new ArgumentNullException("File name should not be null");
			}

			bool isReload = false;

			// If the new file name is null, then this operation is a reload
			if (pszFilename == null)
			{
				isReload = true;
			}

			// Show the wait cursor while loading the file
			IVsUIShell vsUiShell = (IVsUIShell)GetVsService(typeof(SVsUIShell));
			if (vsUiShell != null)
			{
				vsUiShell.SetWaitCursor();
			}

			// Set the new file name
			if ( !isReload )
			{
				fileName = pszFilename;
			}
           
			EditRep.Load(fileName);
			isDirty = false;

			// Notify the load or reload
			NotifyDocChanged( isReload );
			listObjects.Clear();
			EditProp=new EditorProperties(EditRep,this);
			listObjects.Add(EditProp);
			selContainer.SelectableObjects=listObjects;
			selContainer.SelectedObjects=listObjects;
			if (null != TrackSelection)
			{
				TrackSelection.OnSelectChange((ISelectionContainer)selContainer );
			}
			FSetUndo=true;
			EditRep.Undo=new Undo(128);
			EditRep.Undo.Clear();
			EditRep.Undo.Add(EditRep.Template.GetText());

			return NativeMethods.S_OK;
		}

		int IPersistFileFormat.IsDirty(out int pfIsDirty)
		{
			if (isDirty)
			{
				pfIsDirty = 1;
			}
			else
			{
				pfIsDirty = 0;
			}

			return NativeMethods.S_OK;
		}

		int IPersistFileFormat.Save(string pszFilename, int remember, uint nFormatIndex)
		{
			// If file is null or same --> SAVE
			if (pszFilename == null || pszFilename == fileName)
			{
				EditRep.Save(fileName);
				isDirty = false;
			}
				// If remember --> SaveAs
			else if (remember != 0)
			{
				fileName = pszFilename;
				EditRep.Save(fileName);
				isDirty = false;
			}
				// Else, Save a Copy As
			else
			{
				// textBox1.SaveFile(pszFilename, RichTextBoxStreamType.PlainText);
				EditRep.Save(pszFilename);
			}

			return NativeMethods.S_OK;
		}

		#endregion


		#region IVsPersistDocData Members

		public int IsDocDataDirty(out int pfDirty)
		{
			return ((IPersistFileFormat)this).IsDirty(out pfDirty);
		}

		public int SaveDocData(Microsoft.VisualStudio.Shell.Interop.VSSAVEFLAGS dwSave, out string pbstrMkDocumentNew, out int pfSaveCanceled)
		{
			pbstrMkDocumentNew = null;
			pfSaveCanceled = 0;
			int hr = NativeMethods.S_OK;

			switch (dwSave)
			{
				case VSSAVEFLAGS.VSSAVE_Save:
				case VSSAVEFLAGS.VSSAVE_SilentSave:
				{
					IVsQueryEditQuerySave2 queryEditQuerySave = (IVsQueryEditQuerySave2)GetVsService(typeof(SVsQueryEditQuerySave));

					// Call QueryEditQuerySave
					uint result=0;
					hr = queryEditQuerySave.QuerySaveFile(
						fileName,        // filename
						0,               // flags
						null,            // file attributes
						out result);     // result
					if ( NativeMethods.Failed(hr) )
						return hr;

					// Process according to result from QuerySave
					if (result == (uint)tagVSQuerySaveResult.QSR_NoSave_Cancel
						|| result == (uint)tagVSQuerySaveResult.QSR_NoSave_UserCanceled)
					{
						pfSaveCanceled = ~0;
					}
					else if (result == (uint)tagVSQuerySaveResult.QSR_NoSave_Continue)
					{
					}
					else if (result == (uint)tagVSQuerySaveResult.QSR_SaveOK)
					{
						// Call the shell to do the save for us
						IVsUIShell uiShell = (IVsUIShell)GetVsService(typeof(SVsUIShell));
						hr = uiShell.SaveDocDataToFile(dwSave, (IPersistFileFormat)this, fileName, out pbstrMkDocumentNew, out pfSaveCanceled);
					}
					else if (result == (uint)tagVSQuerySaveResult.QSR_ForceSaveAs)
					{
						// Call the shell to do the SaveAS for us
						IVsUIShell uiShell = (IVsUIShell)GetVsService(typeof(SVsUIShell));
						hr = uiShell.SaveDocDataToFile(VSSAVEFLAGS.VSSAVE_SaveAs, (IPersistFileFormat)this, fileName, out pbstrMkDocumentNew, out pfSaveCanceled);
					}
					else
					{
						return NativeMethods.E_UNEXPECTED;
					}
					break;
				}
				case VSSAVEFLAGS.VSSAVE_SaveAs:
				case VSSAVEFLAGS.VSSAVE_SaveCopyAs:
				{
					// Make sure the file name as the right extension
					if (!fileName.EndsWith(myExtension))
					{
						fileName += myExtension;
					}
					// Call the shell to do the save for us
					IVsUIShell uiShell = (IVsUIShell)GetVsService(typeof(SVsUIShell));
					hr = uiShell.SaveDocDataToFile(dwSave, (IPersistFileFormat)this, fileName, out pbstrMkDocumentNew, out pfSaveCanceled);
					break;
				}
				default:
					return NativeMethods.E_UNEXPECTED;
			};
			return hr;
		}

		public int LoadDocData(string pszMkDocument)
		{
			return ((IPersistFileFormat)this).Load(pszMkDocument, 0, 0);
		}

		public int SetUntitledDocPath(string pszDocDataPath)
		{
			return ((IPersistFileFormat)this).InitNew(myFormat);
		}

		public int GetGuidEditorType(out Guid pClassID)
		{
			return ((IPersistFileFormat)this).GetClassID(out pClassID);
		}

		public int Close()
		{
			for(int i=0;i<Controls.Count;i++)
			{
				Controls[i].Dispose();
			}
			return NativeMethods.S_OK;
		}

		public int IsDocDataReloadable(out int pfReloadable)
		{
			// Allow file to be reloaded
			pfReloadable = 1;
			return NativeMethods.S_OK;
		}

		public int RenameDocData(uint grfAttribs, IVsHierarchy pHierNew, uint itemidNew, string pszMkDocumentNew)
		{
			// TODO:  Add EditorPane.RenameDocData implementation
			return NativeMethods.S_OK;
		}

		public int ReloadDocData(uint grfFlags)
		{
			return ((IPersistFileFormat)this).Load(null, grfFlags, 0);
		}

		public int OnRegisterDocData(uint docCookie, IVsHierarchy pHierNew, uint itemidNew)
		{
			return NativeMethods.S_OK;
		}

		#endregion

		#region IVsDocDataFileChangeControl

		/// <summary>
		/// Called by the shell to notify if a file change must be ignored.
		/// </summary>
		/// <param name="fIgnore">Flag not zero if the file change must be ignored.</param>
		int IVsDocDataFileChangeControl.IgnoreFileChanges(int fIgnore)
		{
			if (0 != fIgnore)
			{
				// The changes must be ignored, so increase the counter of changes to ignore
				++changesToIgnore;
			}
			else
			{
				if (changesToIgnore > 0)
				{
					--changesToIgnore;
				}
			}

			return NativeMethods.S_OK;
		}

		#endregion

		#region IVsFileChangeEvents

		/// <summary>
		/// Event called when a directory changes.
		/// </summary>
		/// <param name="pszDirectory">Path if the changed directory.</param>
		int IVsFileChangeEvents.DirectoryChanged(string pszDirectory)
		{
			// Do nothing: we are not interested in this event.
			return NativeMethods.S_OK;
		}

		/// <summary>
		/// Event called when there are file changes.
		/// </summary>
		/// <param name="cChanges">Number of files changed.</param>
		/// <param name="rgpszFile">Path of the files.</param>
		/// <param name="rggrfChange">Flags with the kind of changes.</param>
		int IVsFileChangeEvents.FilesChanged(uint cChanges, string[] rgpszFile , uint[] rggrfChange)
		{
			// Check the number of changes.
			if (0 == cChanges)
			{
				// Why this event was called if there is no change???
				return NativeMethods.E_UNEXPECTED;
			}

			// If the counter of the changes to ignore (set by IVsDocDataFileChangeControl.IgnoreFileChanges)
			// is zero we can process this set of changes, otherwise ignore it.
			if (0 != changesToIgnore)
				return NativeMethods.S_OK;

			// Now scan the list of the changed files to find if the one opened in the editor
			// is one of the changed
			for (int i=0; i < cChanges; ++i)
			{
				if (fileName.ToLower() == rgpszFile[i].ToLower())
				{
					// The file opened in the editor is changed.
					// The first step now is to find the kind of change.
					uint contentChange = (uint)_VSFILECHANGEFLAGS.VSFILECHG_Size | (uint)_VSFILECHANGEFLAGS.VSFILECHG_Time;
					if ( (rggrfChange[i] & contentChange) != 0 )
					{
						// The content of the file is changed outside the editor, so we need to
						// prompt the user for re-load the file. It is possible to have multiple
						// notification for this change, but we want to prompt the user and reload
						// the file only once
						if ( reloadTimer.Enabled || isFileReloading)
						{
							// The reload is running, so we don't need to start it again.
							return NativeMethods.S_OK;
						}

						// Set the timer timeout and start it
						reloadTimer.Interval = 500;
						reloadTimer.Enabled = true;
						reloadTimer.Start();
					}
				}
			}

			return NativeMethods.S_OK;
		}

		#endregion

		private void AdviseFileChange(bool subscribe)
		{
			// Get the VsFileChangeEx service; this service will call us back when a file system
			// event will occur on the file(s) that we register.
			IVsFileChangeEx fileChangeService = (IVsFileChangeEx)GetVsService(typeof(SVsFileChangeEx));
			int hr = NativeMethods.S_OK;

			if ( !subscribe )
			{
				// If the goal is to unsubscribe, but there is no subscription active, exit.
				if (fileChangeNotifyCookie == NativeMethods.VSCOOKIE_NIL)
					return;

				// Now there is an active subscription, so unsubscribe.
				hr = fileChangeService.UnadviseFileChange(fileChangeNotifyCookie);
				// No more subscription active, so set the cookie to NIL
				fileChangeNotifyCookie = NativeMethods.VSCOOKIE_NIL;
				NativeMethods.ThrowOnFailure(hr);
				return;
			}

			// Here we want to subscribe for notification when the file opened in the editor changes.
			uint eventsToSubscribe = (uint)_VSFILECHANGEFLAGS.VSFILECHG_Size | 
				(uint)_VSFILECHANGEFLAGS.VSFILECHG_Time;
			hr = fileChangeService.AdviseFileChange(
				fileName,                        // The file to check
				eventsToSubscribe,                // Filter to use for the notification
				(IVsFileChangeEvents)this,        // The callback to call
				out fileChangeNotifyCookie);    // Cookie used to identify this subscription.
			NativeMethods.ThrowOnFailure(hr);
		}

		/// <summary>
		/// This function asks to the QueryEditQuerySave service if it is possible to
		/// edit the file.
		/// </summary>
		private bool CanEditFile()
		{
			Trace.WriteLine("\t**** CanEditFile called ****");

			// Check the status of the recursion guard
			if (gettingCheckoutStatus)
				return false;

			try
			{
				// Set the recursion guard
				gettingCheckoutStatus = true;

				// Get the QueryEditQuerySave service
				IVsQueryEditQuerySave2 queryEditQuerySave = (IVsQueryEditQuerySave2)GetVsService(typeof(SVsQueryEditQuerySave));

				// Now call the QueryEdit method to find the edit status of this file
				string[] documents = { this.fileName };
				uint result;
				uint outFlags;

				// Note that this function can popup a dialog to ask the user to checkout the file.
				// When this dialog is visible, it is possible to receive other request to change
				// the file and this is the reason for the recursion guard.
				int hr = queryEditQuerySave.QueryEditFiles(
					0,              // Flags
					1,              // Number of elements in the array
					documents,      // Files to edit
					null,           // Input flags
					null,           // Input array of VSQEQS_FILE_ATTRIBUTE_DATA
					out result,     // result of the checkout
					out outFlags    // Additional flags
					);
				if (NativeMethods.Failed(hr))
					return false;

				if (result == (uint)tagVSQueryEditResult.QER_EditOK)
				{
					// In this case (and only in this case) we can return true from this function.
					return true;
				}
			}
			finally
			{
				gettingCheckoutStatus = false;
			}
			return false;
		}

		private void reloadTimer_Tick(object sender, System.EventArgs e)
		{
			// Here we want to check if we can process the reload.
			// We don't want to show the reload popup when the shell is not the active window,
			// so as first we check if the shell has the focus.
			// To do so we use the Win32 function GetActiveWindow that will return the handle
			// of the active window in the current application and NULL (0) if no window has
			// the focus.
			if (0 != GetActiveWindow())
			{
				try
				{
					// Set the flag about the reload status. 
					// It is important to avoid that the popup will show multiple times for the same file.
					isFileReloading = true;

					// The timer was used only to not run this procedure in syncronously inside the
					// notification function, so now we can stop end disable it.
					reloadTimer.Stop();
					reloadTimer.Enabled = false;

					// Build the title and message for the popup.
					string message = fileName + "\n\nThis file has changed outside the editor. Do you wish to reload it?";
					string title = "Microsoft Development Environment";
					// Show the popup
					System.Windows.Forms.DialogResult res = MessageBox.Show(
						this, 
						message, 
						title, 
						System.Windows.Forms.MessageBoxButtons.YesNo, 
						System.Windows.Forms.MessageBoxIcon.Question);
					if (res == System.Windows.Forms.DialogResult.Yes)
					{
						// The user wants to reload the data, so let's call the function that will do the job.
						int hr = ((IVsPersistDocData)this).ReloadDocData(0);
						// If this fail, this is not fatal, but we should try to understand what went wrong.
						Debug.Assert(hr >= 0, "Failed to close IVsWindowFrame while disposing of the package");
					}
				}
				finally
				{
					// Reset the flag about the reload status.
					isFileReloading = false;
				}
			}
		}

		private void EditRep_SelectCell(object sender, SelectCellEventArgs arg)
		{
			SelectBand=false;
			listObjects.Clear();
			CellProperties cellprop=new CellProperties(EditRep.CurrCell,this);
			BandProperties bandprop=new BandProperties(EditRep.CurrBand,this);
			listObjects.Add(cellprop);
			listObjects.Add(bandprop);
			listObjects.Add(EditProp);
			ArrayList array=new ArrayList();
			array.Add(cellprop);
			selContainer.SelectableObjects=listObjects;
			selContainer.SelectedObjects=array;
			if (null != TrackSelection)
			{
				TrackSelection.OnSelectChange((ISelectionContainer)selContainer );
			}
		}

		private void EditRep_SelectBand(object sender, SelectBandEventArgs arg)
		{
			SelectBand=true;
			listObjects.Clear();
			BandProperties BandProp=new BandProperties(EditRep.CurrBand,this);
			CellProperties CellProp=new CellProperties(EditRep.CurrCell,this);
			listObjects.Add(BandProp);
			listObjects.Add(EditProp);
			listObjects.Add(CellProp);
			ArrayList array=new ArrayList();
			array.Add(BandProp);
			selContainer.SelectableObjects=listObjects;
			selContainer.SelectedObjects=array;
			if (null != TrackSelection)
			{
				TrackSelection.OnSelectChange((ISelectionContainer)selContainer);
			}
		}

		private void EditRep_Change(object sender, EventArgs e)
		{
			isDirty = true;
			
			if(FSetUndo)
			{
				EditRep.Undo.Add(EditRep.Template.GetText());
			}			
			UpdateRulerBars();
		}

		// We need this Win32 function to find out if the shell has the focus.
		[DllImport("user32.Dll")]
		static extern int GetActiveWindow();
	}

	public enum VSStd97CmdID
	{
		cmdidCopy=			15,                                                 
		cmdidCut=			16,                                                                          
		cmdidDelete=		17,
		cmdidPaste=			26,
		cmdidRedo=			29,
		cmdidUndo=			43,
		cmdidSelectAll=		31,
		cmdidPageSetup=		227,
		cmdidPrint=			27
	}
}