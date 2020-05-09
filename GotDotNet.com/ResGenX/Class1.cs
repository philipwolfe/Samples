using System;
using System.IO;
using System.Resources;
using Messages;

namespace ResGenX {
	/// <summary>
	/// Defines the entry point "Main".
	/// </summary>
	/// <remarks>Calls <see cref="ResGenX"/> to do the actual processing.</remarks>
	/// <history>
	/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
	/// </history>
	class Class1 {

		[STAThread]
		static int Main(string[] args) {
			if (args.Length < 1) return 0;
			ResGenX prog = new ResGenX();
			return prog.Process(args);
			//string[] testargs = new string[] {@"E:\Visual Studio\Projects\resgenx\Messages.txt", @"E:\Visual Studio\Projects\resgenx\Messages.resources"};
			//string[] testargs = new string[] {"/xref", "cs", @"e:\caterr.mc", @"e:\demo.resources"};
			//string[] testargs = new string[] {"/xref", "cs", @"E:\Visual Studio\Projects\resgenx\ResGenMsg.mc"}; //, @"E:\Visual Studio\Projects\resgenx\test.resources"};
			//string[] testargs = new string[] {"/xref", "cs", @"E:\Visual Studio\Projects\resgenx\ResGenMsg.txt"};
			//string[] testargs = new string[] {@"E:\Visual Studio\Projects\resgenx\ResGenMsg.resources", @"E:\Visual Studio\Projects\resgenx\test.txt"};
			//string[] testargs = new string[] {"-h"};
			//return prog.Process(testargs);
			
		}
	}

	/// <summary>
	/// Contains the routines that do the actual processing.
	/// </summary>
	/// <param name="args">The command line arguments</param>
	/// <returns>Returns the exit code. A value of zero indicates success.
	/// Any other value indicates an error occured.</returns>
	/// <remarks>The routines in ResGenx are:
	/// <list type="definition">
	/// <item><term><see cref="Process"/></term><description>Evaluates the command line</description></item>
	/// <item><term><see cref="GenResFromMC"/></term><description>Loads the <see cref="ResGenMC"/> class
	/// which performs the conversion of an .mc file to a resource.</description></item>
	/// <item><term><see cref="GenResFromTxt"/></term><description>Converts a .txt file to a resource</description></item>
	/// <item><term><see cref="GenTxtFromRes"/></term><description>Converts a resource into a .txt file</description></item>
	/// <item><term><see cref="GenResFromRes"/></term><description>Convert a .resources to a .resx or visa versa</description></item>
	/// </list></remarks>
	/// <history>
	/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
	/// </history>
	class ResGenX {
		private int exitCode;
		private bool compileOption, resGenMCLoaded;
		private int maxLineLength, maxSegmentLength;
		private System.Resources.ResourceManager rmgr;
		private ResGenMC mcProcessor;
		private System.Collections.SortedList symbol;

		int lineNum;
		string curLine, xrefType;

		internal ResGenX() {
			try {
				this.maxLineLength = Int32.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("maxLineLength"));
				this.maxSegmentLength = Int32.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("maxSegmentLength"));
			} catch {
				this.maxLineLength = 100;
				this.maxSegmentLength = 80;
			}
			rmgr = null;
		}

		/// <summary>
		/// Evaluate the command line and execute the request
		/// </summary>
		/// <param name="args">The command line arguments</param>
		/// <returns>Returns the exit code. A value of zero indicates success.
		/// Any other value indicates an error occured.</returns>
		/// <remarks>The command line format is:
		/// <code>
		/// resgenx [/xref {cs|vb}] inputfile.ext [outputfile.ext]
		/// resgenx [/compile] [/xref {cs|vb}] inputfile.ext[,outputfile.ext] ...
		/// </code>
		/// <list type="definition">
		/// <item><term>/compile</term><description>Allows you to specify multiple .resx, .txt or .mc files to 
		/// convert to .resources files in a single bulk operation. If you do not specify this option, you can 
		/// specify only one input file argument.</description></item>
		/// <item><term>/xref {cs|vb}</term><description>This specifies the type of cross reference to create
		/// when processing a .mc file or a .txt file that uses the symbolic name syntax.
		///  <c>cs</c> is for CSharp and <c>vb</c> for Visual Basic. If this prameter is ommitted then both
		///  types are generated if symbolic names are used.</description></item>
		/// <item><term>inputfile.ext</term>
		/// <description> The name of the input file to convert. The extension must be one of the following:
		/// <list type="definition">
		/// <item><term>.txt</term><description>Specifies the extension for a text file to convert to a .resources 
		/// or a .resx file. Text files can only contain string resources.</description></item>
		///	<item><term>.resx</term><description>Specifies the extension for an XML-based resource file to convert
		///	to a .resources or a .txt file. </description></item> 
		///	<item><term>.resources</term><description>Specifies the extension for a resource file to convert to 
		///	a .resx or a .txt file.</description></item>
		///	<item><term>.mc</term><description>Specifies the the extension of a message compiler file to 
		///	convert to a .resources or a .resx file.</description></item>
		///	</list>
		///	 </description></item>
		///	 <para>
		/// <item><term>outputFilename.ext</term><description> The name of the resource file to create.
		/// The ouput file extension <c>MAY NOT</c> be .mc. A .mc file cannot be recreated. It should also be noted
		/// that any symbolic names in a .txt file can not be recreated from the resource file.
		///	This argument is optional when converting from a .txt, .resx or .mc file. The default output name is
		///	inputfile.resources. The outputfile argument is mandatory when 
		///	converting from a .resources file. Specify the .resx extension when converting a .resources file to 
		///	an XML-based resource file. Specify the .txt extension when converting a .resources file to a text 
		///	file. Only string resources will be written to a .txt file.
		///	</description></item>
		///	</para>
		/// </list></remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
		/// </history>		
		internal int Process(string[] args) {
			string inFileName, outFileName, inExt, outExt, option;
			int ndx = 0;
			bool verifyOutput;

			rmgr = new ResourceManager("ResGenX.ResGenMsg", System.Reflection.Assembly.GetExecutingAssembly());

			if (args[0].ToLower().Equals("-h") || args[0].ToLower().Equals("--help")) {
				Util.Message(rmgr, Msg.Usage);
				return 0;
			}

			exitCode = 0;
			compileOption = false;
			xrefType = "both";
			inExt = "";	outExt = "";
			option = "";
			while (args[ndx][0] == '/') {
				option = args[ndx];
				if (option.ToLower().Equals("/compile")) {
					compileOption = true;
				} else {
					if (option.ToLower().Equals("/xref")) {
						++ndx;
						if (args[ndx].ToLower().Equals("cs"))
							xrefType = "cs";
						else {
							if (args[ndx].ToLower().Equals("vb"))
								xrefType = "vb";
							else exitCode = 11;
						}
					} else exitCode = 11;
				}
				if (exitCode != 0) break;
				++ndx;
			}

			if (exitCode != 0) {
				Util.Message(rmgr, Msg.InvalidOption, option);
				return 11;
			}

			for (; ndx < args.Length; ++ndx) {
				verifyOutput = true;
				// get input file name
				inFileName = args[ndx];
				outFileName = null;
				if (compileOption) {
					int pos;
					if ((pos = inFileName.IndexOf(',')) > 0) {
						outFileName = inFileName.Substring(pos+1);
						inFileName = inFileName.Substring(0, pos);
					}
				}
				// extract the file extension and check that file exists
				inExt = VerifyInFileName(ref inFileName);
				if (exitCode != 0) {
					Util.Message(rmgr, Msg.InputFileError, inFileName);
					break;
				}

				if (compileOption) {
					if (outFileName == null) {
						outFileName = inFileName;
						outExt = "resources";
						verifyOutput = false;
					}
				} else {
					// has an output file been specified
					if (args.Length > ndx+1)
						outFileName = args[++ndx];	// get file name
					else {
						outFileName = inFileName;
						outExt = "";
						verifyOutput = false;
					}
				}

				if (verifyOutput) {
					// extract extension and verify it is compatiable with input
					outExt = VerifyOutFileName(ref outFileName, inExt);
					if (exitCode != 0)  {
						Util.Message(rmgr, "Msg002E", outFileName);
						break;
					}
				}
				
				// reconstruct the input file name
				inFileName += "."+inExt;
				switch (inExt) {
					case "txt":
							GenResFromTxt(inFileName, outFileName, outExt);
						break;

					case "mc":
					case "mmc":
							GenResFromMC(inFileName, outFileName, outExt);
						break;

					case "resx":
						if (outExt.Equals("txt"))
							GenTxtFromRes(inFileName, outFileName, inExt);
						else 
							GenResFromRes(inFileName, outFileName, inExt);
						break;

					case "resources":
						// an output file must be specified when input is resources
						if (outExt.Equals("")) {
							exitCode = 2;
							Util.Message(rmgr, Msg.InvalidExtension, outFileName+"."+outExt);
							break;
						} else {
							if (outExt.Equals("txt"))
								GenTxtFromRes(inFileName, outFileName, inExt);
							else 
								GenResFromRes(inFileName, outFileName, inExt);
						}
						break;
				}

				if (exitCode != 0 || !compileOption)
					break;
			}

			rmgr.ReleaseAllResources();
			rmgr = null;
			mcProcessor = null;
			return exitCode;
		}

		//Checks that the file exists and has a valid extension
		private string VerifyInFileName(ref string fileName) {
			string ext = null;
			int pos = 0;

			// does file exist
			if (File.Exists(fileName)) {
				// locate extension
				pos = fileName.LastIndexOf('.');
				if (pos > 0) {
					// extract extension
					ext = fileName.Substring(pos+1).ToLower(); 
					do {
						// is extension valid
						if (!ext.Equals("txt"))
							if (!ext.Equals("resx"))
								if (!ext.Equals("resources"))
									if (!ext.Equals("mc"))
										if (!ext.Equals("mmc")) {
											exitCode = 2;
											ext = null;
											break;
										}
						// is extension valid with the compile option
						if (compileOption) {
							if (!ext.Equals("txt"))
								if (!ext.Equals("resx")) {
									exitCode = 2;
									ext = null;
									break;
								}
						}
						// extract the file name;
						fileName = fileName.Substring(0, pos);
					} while (false);
				}
			} else exitCode = 2;
			return ext;
		}

		// The input file extension is used to ensure that the output file
		// has the proper extension
		private string VerifyOutFileName(ref string fileName, string inExt) {
			string ext = null;
			int pos = 0;

			// locate extension
			pos = fileName.LastIndexOf('.');
			if (pos > 0) {
				// extract extension
				ext = fileName.Substring(pos+1).ToLower(); 
				do {
					// check if valid for txt input
					if (inExt.Equals("txt")) {
						if (!ext.Equals("resx"))
							if (!ext.Equals("resources"))
								exitCode = 1;
					} else {
						// check if valid for resx input
						if (inExt.Equals("resx")) {
							if (!ext.Equals("txt"))
								if (!ext.Equals("resources")) 
									exitCode = 1;
						} else {
							// check if valid for resources input
							if (inExt.Equals("resources")) {
								if (!ext.Equals("resx"))
									if (!ext.Equals("txt"))
										exitCode = 1;
							}
						}
					}
					fileName = fileName.Substring(0, pos);
				} while (false);
			} else exitCode = 1;

			return ext;
		}

		/// <summary>
		/// Load the <see cref="ResGenMC"/> class to perform the conversion
		/// </summary>
		/// <param name="inFileName">The name of the .mc file</param>
		/// <param name="outFileName">The name of the output file</param>
		/// <param name="resType">the type of resource to create</param>
		/// <returns></returns>
		/// <remarks></remarks>
		/// <seealso cref="ResGenMC"/>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/30/2006"></modified>
		/// </history>
		private void GenResFromMC(string inFileName, string outFileName, string resType) {

			if (!resGenMCLoaded) {
				mcProcessor = new ResGenMC();
				resGenMCLoaded = true;
			}

			exitCode = mcProcessor.Process(inFileName, outFileName, resType, xrefType);
		}
	
		/// <summary>
		/// Generate a resources or resx file from a txt file.
		/// </summary>
		/// <param name="inFileName">The name of the input txt file.</param>
		/// <param name="outFileName">The name of the output file.</param>
		/// <param name="resType">The type of resource to be created</param>
		/// <returns></returns>
		/// <remarks>The handling of txt files is where <c>resgenx</c> differs from <c>resgen</c>.
		/// The message text can consist of multiple lines. For example:
		/// <code>
		/// SymbolicName:MsgID = text line1
		///         text line2
		///         text line3
		/// </code>
		/// A message continues until a blank or comment line is found.
		/// As with <c>resgen</c> leading and trailing spaces are ignored.
		/// Comment lines must start with a semicolon ";" or a pound sign "#". Comment
		/// lines cannot appear in the body of a message.
		/// The following escape sequences are recognized by <c>ResGenX</c>:
		/// <list type="bullet">
		/// <item><term>\n - Insert a newline chararcter. By default
		/// a newline character is added to the end of a message.</term></item>
		/// <item><term>\t - Insert a tab character.</term></item>
		/// <item><term>\b - Used to reserve leading or trailing spaces.</term></item>
		/// <item><term>\0 - Used to suppress the insertion of a newline to the last line of a message.
		/// Must be used at the end of the last line in a message.</term></item>
		/// </list>
		/// The <c>SymbolicName</c> element is optional. If specified the command line option <c>/xref</c>
		/// (see <see cref="ResGenX.Process"/>) is used to create a cross reference of the <c>MsgID</c> and the <c>SymbolicName</c>.
		/// </remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
		/// </history>
		private void GenResFromTxt(string inFileName, string outFileName, string resType) {
			bool continuation = false;
			string txtMsg, txtMsgID, symName;
			IResourceWriter resFile;
			int cnt = 0;

			symbol = new System.Collections.SortedList();

			TextReader txtFile = new System.IO.StreamReader(File.OpenRead(inFileName));

			if (resType.Equals("resx"))
				resFile = new ResXResourceWriter(outFileName+".resx");
			else 
				resFile = new ResourceWriter(outFileName+".resources");

			txtMsg = ""; txtMsgID = "";
			symName = "";
			// read first line
			curLine = txtFile.ReadLine();
			++lineNum;
			while (curLine != null) {
				// remove leading and trailing spaces
				curLine = curLine.Trim(' ', '\t');
				// check for blank and comment lines
				if (curLine.Length > 0 && curLine[0] != ';' && curLine[0] != '#') {
					// are we processing a multiline message
					if (continuation) {
						txtMsg += curLine;
					} else {
						int pos = 0;
						// find the equal sign that follows the message ID
						pos = curLine.IndexOf('=');
						// was an equal sign found
						if (pos > 0 ) { 
							// set length of message line
							int end = curLine.Length - pos-1;
							// extract the message ID
							txtMsgID = curLine.Substring(0, pos).TrimEnd();
							// extract message line
							txtMsg = curLine.Substring(pos+1, end).TrimStart();
							symName = "";
							if ((pos = txtMsgID.IndexOf(':')) > 0) {
								symName = txtMsgID.Substring(0,pos);
								txtMsgID = txtMsgID.Substring(pos+1);
							}
							continuation = true;		// assume multiline message
						} else {
							// an equal sign was not found
							// set error code and exit
							exitCode = 3;
							Util.Message(rmgr, Msg.InvalidTxtStructure, curLine);
							break;
						}
					}		// end if (continuation) else
				}		// end if (curLine.Length > 0 && curLine[0] != ';' && curLine[0] != '#')
				else continuation = false;		// a blank or comment line was found

				// if there is no more data and we have valid line format
				// then write message to resource file
				if (!continuation) {
					if (txtMsgID.Length > 0 && txtMsg.Length > 0) {
						AddMsgToRes(resFile, txtMsgID, txtMsg, symName);
						++cnt;
					}
					txtMsgID = ""; txtMsg = "";
				}
				//}		// end if (curLine.Length > 0 && curLine[0] != ';' && curLine[0] != '#')

				if (exitCode != 0) break;

				// read the next txt file line
				curLine = txtFile.ReadLine();
				++lineNum;
			}

			if (txtMsgID.Length > 0 && txtMsg.Length > 0) {
				AddMsgToRes(resFile, txtMsgID, txtMsg, symName);
				++cnt;
			}

			txtFile.Close();
			resFile.Close();
			resFile.Dispose();

			if (exitCode == 0) {
				Util.Message(rmgr, Msg.ProcessingComplete, cnt, inFileName);
				if (symbol.Count > 0)
					Util.CreateXref(outFileName, symbol, xrefType);
			}
			symbol.Clear();
			symbol = null;
		}

		private void AddMsgToRes(IResourceWriter rw, string msgID, string msg, string symName) {
				if (msg.EndsWith("\\0"))
					msg = msg.Substring(0, msg.Length-2);
				else 
					msg += "\\n";
							
				if (symName.Length > 0) {
					if (symbol.ContainsKey(symName))
						Util.Message(rmgr, Msg.SymbolAlreadyDefined, lineNum, symName);
					else
						symbol.Add(symName, msgID+";"+msg);
				}

				msg = msg.Replace("\\t","\t").Replace("\\b"," ");
				try {
					rw.AddResource(msgID, msg.Replace("\\n","\n"));
				} catch (Exception e) {
					Util.Message(rmgr, Msg.AddToResourceFailed, e.Message);
					exitCode = 11;
				}
		}

		/// <summary>
		/// Generate a txt file from a resources file.
		/// </summary>
		/// <param name="inFileName">The name of the input file.</param>
		/// <param name="outFileName">The name of the output file.</param>
		/// <param name="resType">The type of resource file to create</param>
		/// <returns></returns>
		/// <remarks>Only <c>string</c> elements of the resource file are written to the output file.
		/// A multi line text message will be generated under the following condiftions:
		/// <list type="number">
		/// <item><term>The text length must be greater that 100.</term></item>
		/// <item><term>If the message text contains the newline sequence <c>\n</c>
		/// the text will be split at that the point immediately following the newline sequence.</term></item>
		/// <item><term>If the text does not contain newlinr characters, it will be broken into segments of
		/// 80 characters maximum. If possible the break point will ne on a space.
		/// The max line length, 100, and the max segment length, 80, are configurable thru the
		/// application configuration file.
		/// </term></item>
		/// </list></remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
		/// </history>
		private void GenTxtFromRes(string inFileName, string outFileName, string resType) {
			IResourceReader resFile;
			string indent, msgID, msgTxt;
			int pos, cnt = 0;
			bool firstLine;

			TextWriter txtFile = new System.IO.StreamWriter(outFileName+".txt", false, System.Text.Encoding.UTF8);
			
			if (resType.Equals("resx"))
				resFile = new ResXResourceReader(inFileName);
			else 
				resFile = new ResourceReader(inFileName);

			System.Collections.IDictionaryEnumerator ide = resFile.GetEnumerator();

			while (ide.MoveNext()) {
				++cnt;
				// get resource id
				msgID = (string)ide.Key;
				// only process string resources
				if (ide.Value.GetType().Equals(typeof(string))) { 
					msgTxt = (string)ide.Value;
					// if present remove last newline character
					if (msgTxt[msgTxt.Length-1] == '\n')
						msgTxt = msgTxt.Substring(0, msgTxt.Length-1);
					else msgTxt += "\0";
					curLine = msgID+" = ";
					indent = new string(' ', curLine.Length);
					firstLine = true;

					// check for a multi line message
					if (msgTxt.Length > maxLineLength && msgTxt.IndexOf("\n") >= 0) {
						// split text at newline sequence
						while ((pos = msgTxt.IndexOf("\n")) >= 0) { 
							// extract a line of text
							curLine += msgTxt.Substring(0,pos)+"\\n";
							// remove extracted line
							msgTxt = msgTxt.Substring(pos+1);
							// add any place holders to line
							curLine = ProcessLine(curLine);
							if (!firstLine)
								curLine = indent+curLine;
							firstLine = false;
							// write line to output file
							txtFile.WriteLine(curLine);
							curLine = "";
						}
					} else {
						// is line longer than max
						if (msgTxt.Length > maxLineLength) {
							// break line into segments
							while (msgTxt.Length > maxSegmentLength) {
								// locate a space to segment the line on
								pos = msgTxt.LastIndexOf(' ', maxSegmentLength+1);
								// if a space was found
								// then set break point at next char
								// else set it at segment length
								if (pos > 0) ++pos;
								else pos = maxSegmentLength;
								// extract line segment
								curLine += msgTxt.Substring(0, pos);
								// remove segment from msg text
								msgTxt = msgTxt.Substring(pos+1);
								// add any place holders to line
								curLine = ProcessLine(curLine);
								if (!firstLine)
									curLine = indent+curLine;
								firstLine = false;
								// write segment to file
								txtFile.WriteLine(curLine);
								curLine = "";
							}
						}
					}
					// write any remaing text
					if (!firstLine)
						curLine = indent+curLine;
					if (msgTxt.Length > 0)
						txtFile.WriteLine(curLine+ProcessLine(msgTxt));
				}
				// write a blank line between messages
				txtFile.WriteLine("");
			}

			Util.Message(rmgr, Msg.ProcessingComplete, cnt, inFileName);

			resFile.Close();
			txtFile.Flush();
			txtFile.Close();
		}
		// Any leading and/or trailing blanks are replaced by "\b"
		// Any newline is replaced by "\n" and any tabs by "\t"
		private string ProcessLine(string line) {
			int bc, i;
			string lbstr = "", tbstr = "";

			bc = line.Length - line.TrimStart(' ').Length;
			if (bc > 0) {
				lbstr = "\\b";
				for (i = 1; i < bc; i *= 2)
					lbstr += lbstr;
				lbstr = lbstr.Substring(0, bc);
			}
			bc = line.Length - line.TrimEnd(' ').Length;
			if (bc > 0) {
				tbstr = "\\b";
				for (i = 1; i < bc; i *= 2)
					tbstr += tbstr;
				tbstr = tbstr.Substring(0, bc);
			}
			line = lbstr+line.Trim(' ')+tbstr; 
			return line.Replace("\t", "\\t").Replace("\n", "\\n");
		}
	
		/// <summary>
		/// Generate a resources file from a resx  or a resx file from a resources.
		/// </summary>
		/// <param name="inFileName">The name of the input file.</param>
		/// <param name="outFileName">The name of the output file.</param>
		/// <param name="resType">The type of resource to create</param>
		/// <returns></returns>
		/// <remarks>If the input file is a .resources then a .resx file is created. If the input is a .resx
		/// the a .resources is created.</remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
		/// </history>
		private void GenResFromRes(string inFileName, string outFileName, string resType) {
			IResourceReader inRes;
			IResourceWriter outRes;

			if (resType.Equals("resx")) {
				inRes = new ResXResourceReader(inFileName);
				outRes = new ResourceWriter(outFileName+".resources");
			} else {
				inRes = new ResourceReader(inFileName);
				outRes = new ResXResourceWriter(outFileName+".resx");
			}
			
			int cnt = 0;

			System.Collections.IDictionaryEnumerator ide = inRes.GetEnumerator();

			while (ide.MoveNext()) {
				outRes.AddResource((string)ide.Key, ide.Value);
				++cnt;
			}
			Util.Message(rmgr, Msg.ProcessingComplete, cnt, inFileName);

			inRes.Close();
			outRes.Close();
			inRes.Dispose();
			outRes.Dispose();
		}

	}
}
