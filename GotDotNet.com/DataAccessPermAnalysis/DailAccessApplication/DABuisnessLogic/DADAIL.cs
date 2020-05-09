using System;
using XBLIP.DAIL;
using XBLIP.DAIL.DataSources;

namespace DABuisnessLogic
{
	/// <summary>
	/// Dail for application
	/// </summary>
	public class DADAIL: AbstractDAIL
	{
		public DADAIL():base()
		{
		
		}

		protected override IDAILDataSource getDataSource(string strDSLabel) 
		{	
			IDAILDataSource aDataSource = null;

			if("DAApp" == strDSLabel) 
				aDataSource = new SimpleOleDbDataSource(
					@"File name=D:\userFolder\Lang - c#\XBLIP\DailAccessApplication\test.udl");
			else
				throw new UnknownDataSourceException(strDSLabel);

			return aDataSource;
		}

	}
}
