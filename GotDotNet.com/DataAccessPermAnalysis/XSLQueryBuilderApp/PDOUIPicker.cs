using System;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	public class PDOUIPicker:ITrackVisitor,IFieldVisitor
	{
		public IWin32Window	parentWindow;
		private DialogResult _uiResult;

		public PDOUIPicker()
		{
			_uiResult = DialogResult.Cancel;
			parentWindow = null;
		}

		public DialogResult uiResult 
		{
			get 
			{
				return _uiResult;
			}
		}

		public void visit(RetrieveTrack track) 
		{
			showTrackDialog(new FormRetrieveTrackUI(),track);
		}

		public void visit(UpdateTrack track) 
		{
			showTrackDialog(new FormUpdateTrackUI(),track);
		}

		public void visit(InsertTrack track) 
		{
			showTrackDialog(new FormInsertTrackUI(),track);
		}

		public void visit(DeleteTrack track) 
		{
			showTrackDialog(new FormDeleteTrackUI(),track);
		}

		public void visit(StoredProcedureTrack track) 
		{
			showTrackDialog(new FormSPTrackUI(),track);
		}

		private void showTrackDialog(ITrackUI trackUI,ITrack track) 
		{
			trackUI.track = track;
			_uiResult = trackUI.ShowDialog(parentWindow);
		}

		public void visit(UnTypedField field) 
		{
			showFieldDialog(new FormFieldUI(),field);
		}

		private void showFieldDialog(IFieldUI fieldUI,IField field) 
		{
			fieldUI.field = field;
			_uiResult = fieldUI.ShowDialog(parentWindow);
		}

		public void visit(StringField field) 
		{
			showFieldDialog(new FormFieldUI(),field);
		}

		public void visit(DateField field) 
		{
			showFieldDialog(new FormDateFieldUI(),field);
		}

		public void visit(NumberField field) 
		{
			showFieldDialog(new FormNumberFieldUI(),field);
		}
	}
}
