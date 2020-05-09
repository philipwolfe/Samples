namespace Messages {
	/// <summary>SymbolicName and MsgID cross reference for resgenmsg</summary>
	public class Msg {
 
		//
		// Exception adding message to resource\n{0}\n
		//
		public const string AddToResourceFailed = "C400006E";
 
		//
		// Duplicate message ID: Severity:{0} Facility:{1} Message:{2}\n
		//
		public const string DuplicateMessageID = "C4000046";
 
		//
		// Input file does not exist or has in invalid extension: {0}\n
		//
		public const string InputFileError = "C4000001";
 
		//
		// Output file has an invalid extension: {0}\n
		//
		public const string InvalidExtension = "C400000A";
 
		//
		// Invalid MC file structute at (0)\n
		//
		public const string InvalidMCStructure = "C400001E";
 
		//
		// Invalid or unsupported option: {0}\n
		//
		public const string InvalidOption = "C4000050";
 
		//
		// Invalid text file structure:\n{0}\n
		//
		public const string InvalidTxtStructure = "C4000014";
 
		//
		// Value out of range or invalid at {0} : (1}\n
		//
		public const string OutofRange = "C4000028";
 
		//
		// Read in {0} resources from `{1}'\nWritting resource file... Done\n
		//
		public const string ProcessingComplete = "04000014";
 
		//
		// Symbol already defined at {0}: {1}\n
		//
		public const string SymbolAlreadyDefined = "C400003C";
 
		//
		// Undefined {0} name at {1}: {2}\n
		//
		public const string UndefinedElement = "C4000032";
 
		//
		// Usage:\tResGenX [/xref {{cs | vb}}] inFile.ext [outFile.ext]\n
		//
		public const string Usage = "04000001";
	}
}
