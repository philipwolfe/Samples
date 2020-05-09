using System;
using XBLIP.DAIL;

namespace XSLTesterApp
{
	/// <summary>
	/// 
	/// </summary>
	internal class TestDAIL : XBLIP.DAIL.AbstractDAIL
	{
		protected override IDAILDataSource getDataSource(string strDSLabel) 
		{
			switch(strDSLabel) 
			{
				case "NULL":
					return new XBLIP.DAIL.DataSources.NullDataSource();
				case "NULLPIPE":
					return new NullPipeDataSource();
				default:
					return null;
			}
		}

	}
}
