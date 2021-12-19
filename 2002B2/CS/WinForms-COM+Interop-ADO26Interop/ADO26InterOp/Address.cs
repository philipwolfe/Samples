using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using ADODB;


namespace ADO26InterOp
{
	/// <summary>
	/// Summary description for Address.
	/// </summary>
	public class Address : System.ComponentModel.Component
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public Address()
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		//This function returns connection string
		public string GetConnectStr()
		{
			return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AddressBook.mdb;";
		}

		//This function returns an ADO 2.6 recordset object
		//The recordset contains the value of the name field of every record in the Address table.
		public ADODB.Recordset GetName()
		{
			try
			{

				string strSQL;
				ADODB.Connection cnName;
				ADODB.Recordset rsName;
				strSQL = "SELECT Name From Address";

				cnName = new ADODB.Connection();
				rsName = new ADODB.Recordset();
				cnName.Open(GetConnectStr(),"","",0);

				rsName.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				rsName.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;

				rsName.Open(strSQL, cnName, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly,0);
				rsName.ActiveConnection = null;
				cnName.Close();

				return rsName;
			}
			catch(Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.ToString());
				return null;
			}
		}

		//This function returns an ADO 2.6 recordset object
		//The recordset contains all field values of a record in the Address table
		//where the Name field equals the strName.  This is used to populate the address
		//text boxes with data.
		public ADODB.Recordset GetAddress(string strName)
		{
			string strSQL;
			ADODB.Connection cnAddress;
			ADODB.Recordset rsAddress;
			strSQL = "SELECT * From Address where Name = '" + strName + "'";
			
			cnAddress = new ADODB.Connection();
			rsAddress = new ADODB.Recordset();			
			cnAddress.Open(GetConnectStr(),"","",0);

			rsAddress.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;
			rsAddress.Open(strSQL, cnAddress, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly,0);

			return rsAddress;
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
