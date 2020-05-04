using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Demo_ContextMenu
{
	/// <summary>
	/// Summary description for LinksMaster.
	/// </summary>
	public class LinksMaster : System.Web.UI.Page
	{
		protected MarkItUp.WebControls.ContextMenu ctxDataBound;
		protected MarkItUp.WebControls.ContextMenu ctxChangeTitle;
		protected MarkItUp.WebControls.ContextMenuLink lnkPageTitle;
		protected MarkItUp.WebControls.ContextMenuItem ctxItemChangeColor;
		protected MarkItUp.WebControls.ContextMenuItem ctxItemChangeTitle;
		protected System.Web.UI.WebControls.DataGrid grdTest;
		protected MarkItUp.WebControls.ContextMenuItem ctxItemChangeTitle2;
		protected System.Web.UI.WebControls.TextBox txtPageTitle;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			ArrayList list = new ArrayList() ;
			string[] texts = {"Rob", "Pete", "Jeff", "Jim", "Darren", 
								 "Rob", "Pete", "Jeff", "Jim", "Darren", "Rob", "Pete", 
								 "Jeff", "Jim", "Darren", "Rob", "Pete", "Jeff", "Jim", 
								 "Darren", "Rob", "Pete", "Jeff", "Jim", "Darren" } ;
			Foo obj ;

			for( int i = 0; i < texts.Length; i++ )
			{
				obj = new Foo() ;
				obj.ItemText = texts[i] ;
				list.Add(obj) ;
			}

			grdTest.DataSource = list ;
			grdTest.DataBind() ;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
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
			this.ctxDataBound.ItemClick += new MarkItUp.WebControls.ContextItemClickEventHandler(this.ctxDataBound_ItemClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void ctxDataBound_ItemClick(object sender, MarkItUp.WebControls.ItemClickEventArgs e)
		{
			txtPageTitle.Text = e.LinkCommandArgument ;
		}
	}

	public class Foo
	{
		public Foo() 
		{
			itemText = String.Empty;
		}


		private string itemText = String.Empty ;

		public string ItemText 
		{
			get { return itemText ; }
			set { itemText = value ; }
		}
	}
}
