using System;

namespace XSLQueryBuilderApp
{
	public class PDOClassFactory
	{
		private static PDOClassFactory singleton;

		private PDOClassFactory()
		{
		}

		public static PDOClassFactory getClassFactory() 
		{
			if(singleton == null)
				singleton = new PDOClassFactory();

			return singleton;
		}

		public ITrack createTrack(string id) 
		{
			ITrack result;

			switch(id) 
			{
				case "RetrieveTrack" :
					result = new RetrieveTrack();
					break;
				case "InsertTrack" :
					result = new InsertTrack();
					break;
				case "DeleteTrack" :
					result = new DeleteTrack();
					break;
				case "UpdateTrack" :
					result = new UpdateTrack();
					break;
				case "SPTrack" :
					result = new StoredProcedureTrack();
					break;
				default :
					result = null;
					break;
			}
			return result;
		}

		public IField createField(string id)
		{
			IField result;

			switch(id) 
			{
				case "UnTypedField":
					result = new UnTypedField();
					break;
				case "StringField":
					result = new StringField();
					break;
				case "DateField":
					result = new DateField();
					break;
				case "NumberField":
					result = new NumberField();
					break;
				default:
					result = null;
					break;
			}

			return result;
		}
	}
}
