using System;
using System.Collections;
using System.Text;

namespace XSLQueryBuilderApp
{
	public class ShortNamesGenerator
	{
		private Hashtable usedNames;
		private readonly char[] nameSeperator = new char[] {'_'};
		private static ShortNamesGenerator singleton;

		private ShortNamesGenerator()
		{
			usedNames = new Hashtable();
		}

		public static ShortNamesGenerator getGenerator() 
		{
			if(singleton == null)
				singleton = new ShortNamesGenerator();

			return singleton;
		}

		public void reset() 
		{
			usedNames.Clear();
		}

		public string generateShortName(string longName) 
		{
			string baseName = getShortNameBase(longName);
			string shortName;
			int nameIndex;

			if(usedNames.Contains(baseName)) 
			{
				nameIndex = (int)usedNames[baseName];
				shortName = baseName + nameIndex.ToString();
				usedNames[baseName] = nameIndex + 1;
			} 
			else 
			{
				shortName = baseName;
				usedNames.Add(baseName,0);
			}
			return shortName;
		}

		private string getShortNameBase(string longName) 
		{
			string[] nameSections = longName.Split(nameSeperator);
			int i;
			StringBuilder stringBuilder = new StringBuilder(nameSections.Length);

			for(i=0;i<nameSections.Length;++i)
				if(nameSections[i].Length > 0)
					stringBuilder.Append(nameSections[i][0]);
			return stringBuilder.ToString();
		}
	}
}
