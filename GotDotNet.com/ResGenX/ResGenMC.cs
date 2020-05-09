using System;
using System.IO;
using System.Resources;
using RexxLib;
using Messages;

namespace ResGenX {
	/// <summary>
	/// Generates a resource file from a .mc file
	/// </summary>
	/// <remarks>The .mc file has the same structure as described in the Microsoft documentaion.
	/// For conversion to a Managed Code application the follow assumptions are made:
	/// <list type="number">
	/// <item><term>SeverityNames and FacilityNames have the following format:
	/// <code>
	/// SeverityName = (label=value:name ... )
	/// FacilityNames = (label=value:name ... )
	/// </code>
	/// The <c>:name</c> element is ignored.<para>
	/// The following Severity codes are predefined:<code>
	/// Success = 0x0
	/// Informational = 0x1
	/// Warning = 0x2
	/// Error = 0x3
	/// </code>
	/// </para>
	/// <para>
	/// The following Facility names codes are predefined:<code>
	/// System = 0xFF
	/// Application = 0xFFF
	/// </code>
	/// </para>
	/// </term></item>
	/// <item><term>The LanguageNames directive has the following format:
	/// <code>
	/// LanguageNames = (language=culturename ... )
	/// For example: LanguageNames=(English=en German=de)</code>
	/// <para>The following Languages are predefined:<code>
	///	English   en
	///	German    de
	///	TChinese  zv-CHT    (Chinese Traditional)
	///	SChinese  zv-CHS    (Chinese Simplified) 
	///	Spanish   es
	///	French    fr
	/// </code></para>
	/// </term></item>
	/// <item><term>
	/// Message text contains Managed Code formatting strings not printf strings.
	/// </term></item>
	/// <item><term>
	/// The <c>\</c> character is used as the place holder delimitor not <c>%</c>.
	/// <para>
	/// The following place holders are recognized:<code>
	///	\n - for newline
	///	\t - for tag
	///	\b - for a leading or trailing space
	///	\0 - if at the end of the last line, do not insert a newline at the end of a message
	///	</code></para>
	///	</term></item>
	///	<item><term>
	///	A newline character will be appended to the last line unless directed not to.
	///	</term></item>
	///	<item><term>
	///	Message text is terminated by a line containing only a period or a blank line.
	///	</term></item>
	/// </list></remarks>
	/// <history>
	/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
	/// </history>
	class ResGenMC {
		private int exitCode;
		private System.Resources.ResourceManager rmgr;
		
		// hash table to hold Severity code data
		System.Collections.Hashtable severity;

		// hash table to hold Facility code data
		System.Collections.Hashtable facility;

		// list sorted on SymbolicName that connects the message ID and text to the
		// SymbolicName.
		System.Collections.SortedList symbol;

		// hash table to hold the culture for a language
		System.Collections.Hashtable language = new System.Collections.Hashtable();

		
		string resFile;						// name of output resource file(s)
		string resType;						// the type of resource to be created
		private int lineNum;			// current line number of input file
		private string curLine;	  // current line of input being processed;
		private TextReader mcRdr;

		// array used to hold the parsed message definition elements
		string[] parsed;
		private const int key = 0, data = 1, rest = 2;

		/// <summary>
		/// generate a resource file from an .mc file
		/// </summary>
		/// <param name="inFile">Name of the .mc input file</param>
		/// <param name="outFile">Name of the output resource file</param>
		/// <param name="type">Type of resource file to create</param>
		/// <param name="xref">Type of cross reference to create</param>
		/// <returns>Returns an exit code. A value of zero indicates success.
		/// Any other value indicates an error occured.</returns>
		/// <remarks></remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
		/// </history>
		internal int Process(string inFile, string outFile, string type, string xref) {
			
			resFile = outFile;
			resType = type;

			rmgr = new ResourceManager("ResGenX.ResGenMsg", System.Reflection.Assembly.GetExecutingAssembly());

			// Set default Severity codes
			severity = new System.Collections.Hashtable();
			severity.Add("Success", (uint)0);
			severity.Add("Informational", (uint)1);
			severity.Add("Warning", (uint)2);
			severity.Add("Error", (uint)3);

			// Set Default Facility codes
			facility = new System.Collections.Hashtable();
			facility.Add("System", (uint)255);
			facility.Add("Application", (uint)4095);

			language = new System.Collections.Hashtable();
			language.Add("English", "en");
			language.Add("German", "de");
			language.Add("TChinese", "zv-CHT");		// traditional Chinese
			language.Add("SChinese", "zv-CHS");		// simplified Chinese
			language.Add("Spanish", "es");
			language.Add("French", "fr");

			// list sorted on SymbolicName that connects the message ID and text to the
			// SymbolicName.
			symbol = new System.Collections.SortedList();

			// IO stream used to read the .mc file
			mcRdr = new System.IO.StreamReader(File.OpenRead(inFile));
			// array used to hold the parsed message definition elements
			parsed = (string[])Array.CreateInstance(typeof(string), 0);

			int resCnt = 0;
			lineNum = 0;

			MCHeader();
			if (exitCode == 0) {
				resCnt = MCMessages();
				mcRdr.Close();
				if (exitCode == 0) {

					// display number of resources created
					Util.Message(rmgr, Msg.ProcessingComplete, resCnt, inFile);

					if (symbol.Count > 0)
						Util.CreateXref(resFile, symbol, xref);
				
				}
			}
			symbol.Clear();
			symbol = null;
			language.Clear();
			language = null;
			facility.Clear();
			facility = null;
			severity.Clear();
			severity = null;
			rmgr.ReleaseAllResources();
			rmgr = null;
			return exitCode;
		}

		/// <summary>
		/// Process .mc file Header data
		/// </summary>
		/// <returns></returns>
		/// <remarks>The Header consists of the Severity, Facility and Language definitions.</remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/30/2006"></modified>
		/// </history>
		private void MCHeader() {
			
			System.Collections.Hashtable hash;

			// used to convert hex to int
			string hex = "0123456789ABCDEF";
			string hexVal;

			int pos, minValue, maxValue;
			string keyWord, dataValue;
			bool inHeader;

			inHeader = true;
			curLine = mcRdr.ReadLine();
			// First process and header definitions
			while (curLine != null && inHeader) {
				++lineNum;
				curLine = curLine.Trim();
				// all non comment lines have a format of: keyword=value
				if (curLine.Length > 0 && curLine[0] != ';') { 
					if ((pos = curLine.IndexOf('=')) < 1) {
						Util.Message(rmgr, Msg.InvalidMCStructure, lineNum);
						exitCode = 4;
						inHeader = false;
						break;
					}
					parsed = Rexx.Parse(curLine, "[0] '=' [1]");
					keyWord = parsed[key].Trim();
					switch (keyWord.ToLower()) {
							// ignore MessagIDTypedef and OutputBase directives
						case "messageidtypedef":
						case "outputbase":
							break;
						case "languagenames":
							dataValue = ExtractHeaderElement();
							if (exitCode == 0) {
								while (dataValue.Length > 0) {
									parsed = Rexx.Parse(dataValue,"[0] '=' [1] [2]");
									if (language.ContainsKey(parsed[key])) 
										language[parsed[key]] = parsed[data];
									else
										language.Add(parsed[key], parsed[data]);
									dataValue = parsed[rest];
								}
							}
							break;
							// These statements all have the same structure keyword=(label=value:name ... )
							// ths :name part is ignored.
						case "severitynames":
						case "facilitynames":
							dataValue = parsed[data].Trim();
							dataValue = ExtractHeaderElement();
							if (exitCode == 0) {
								// are we processing Severity or Facility names
								if (keyWord.ToLower().Equals("severitynames")) {
									hash = severity;		// hash table to add data to
									minValue = 0;				// minimum accepible value
									maxValue = 3;				// maximum acceptible value
								} else {
									hash = facility;		// hash table to add data to
									minValue = 0;				// minimum accepible value
									maxValue = 4095;		// maximum acceptible value
								}
								
								while (dataValue.Length > 0) {
									// each data element has the format: label=value:name
									// the :name element is ignored if present
									parsed = Rexx.Parse(dataValue, "[0] '=' [1] [2]");
									if ((pos = parsed[data].IndexOf(':')) > 0)
										parsed[data] = parsed[data].Substring(0,pos);
									int val = 0;
									// is value spcified in hex
									if (parsed[data].ToUpper().StartsWith("0X")) {
										// extract hex value and convert to uppercase
										hexVal = parsed[data].Substring(2).ToUpper();
										// ensure we have only valid hex characters
										if (Rexx.Verify(hexVal, hex) == -1) {
											for (int i = 0; i < hexVal.Length; ++i)
												val = (val << 4) + hex.IndexOf(hexVal[i]);
										} else val = -1;
									} else {
										try {
											val = Int32.Parse(parsed[data]);
										} catch {val = -1;}
									}
									// if data is valid
									// then add it to the hash table
									if (val >= minValue && val <= maxValue) {
										if (hash.ContainsKey(parsed[key].Trim()))
											hash[parsed[key]] = (uint)val;
										else
											hash.Add(parsed[key].Trim(), (uint)val);
									} else {
										Util.Message(rmgr, Msg.OutofRange, lineNum, parsed[data]);
										exitCode = 5;
										break;
									}
									dataValue = parsed[rest];
								}		// end while (dataValue.Length > 0) 
							}
							break;
						default:
							inHeader = false;
							break;
					}		// end switch (keyWord.ToLower())
					if (exitCode != 0) break;
				}		// end if (curLine.Length > 0 && curLine[0] != ';') else
				if (inHeader)
					curLine = mcRdr.ReadLine();
			}		// end while (curLine != null && inHeader)
		}

		// Collect all elements of a Header directive
		private string ExtractHeaderElement() {

			string dataValue = parsed[1].Trim();
			// enuse we have leading (
			if (dataValue[0] != '(') {
				exitCode = 4;
			} else {
				// append all lines to dataValue until we find an ending )
				while (!dataValue.EndsWith(")")) {
					curLine = mcRdr.ReadLine().Trim();
					++lineNum;
					if (curLine == null || curLine[0] == ';' || curLine.Length == 0) {
						exitCode = 4;
						break;
					}
					dataValue += " "+curLine;
				}
			}

			if (exitCode != 0)
				Util.Message(rmgr, Msg.InvalidMCStructure, lineNum);
			else
				// remove leading ( and trailing )
				dataValue = dataValue.Substring(1, dataValue.Length-2).Trim();

			return dataValue;

		}
		/// <summary>
		/// Process the messages in the .mc file and write them to a resource file
		/// </summary>
		/// <returns></returns>
		/// <remarks>A message definition consists of the following
		/// <code>
		/// MessageId = [number|+number]
		/// Severity = severity_name
		/// Facility = facility_name
		/// SymbolicName = name
		/// OutputBase = {number}
		///
		/// following by: (for each language)
		/// Language=name
		/// message text
		/// .
		/// </code>
		/// The OutputBase keyword is ignored.
		/// Severity and Facility are optional and default to <c>Success</c> and <c>Application</c> respectivly.
		/// </remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/30/2006"></modified>
		/// </history>
		private int MCMessages() {
			int resCnt;
			uint sevNum, facNum, lastMsgid, msgID, msgNum;
			string keyWord, symName, msgName, resText, culture;
			bool firstLang;

			IResourceWriter rw, fallBack;

			// hash table to hold a ResourceWriter for each language spcified;
			System.Collections.Hashtable resource = new System.Collections.Hashtable();

			// this hash table is used to prevent duplicate message IDs
			System.Collections.Hashtable dupMsg = new System.Collections.Hashtable();

			lastMsgid = sevNum = facNum = msgID = 0;
			symName = null;
			firstLang = true;
			resCnt = 0;
			rw = fallBack = null;
			if (resType.Equals("resx"))
				fallBack = new ResXResourceWriter(resFile+".resx");
			else
				fallBack = new ResourceWriter(resFile+".resources");
			// process the message definitions
			while (curLine != null) {
				curLine = curLine.Trim();

				// A message definition consists of the following:
				//
				// MessageId = [number|+number]
				// Severity = severity_name
				// Facility = facility_name
				// SymbolicName = name
				// OutputBase = {number}
				//
				// following by: (for each language)
				// Language=name
				// message text
				// .

				// the OutputBase keyword is ignored
				
				while (curLine.Length > 0) {
					// ignore comment lines
					if (curLine[0] == ';')
						curLine = "";
					else {
						parsed = Rexx.Parse(curLine, " [0] '=' [1] [2]");
						keyWord = parsed[key].ToLower();
						switch (keyWord) {

								// get the message number and set the default Severity and Facility codes
							case "messageid":
								msgID = 4096;
								if (Rexx.IsNumeric(parsed[data])) {
									uint val = UInt32.Parse(parsed[data]);
									if (parsed[data][0] == '+')
										msgID = lastMsgid + val;
									else msgID = val;
									lastMsgid = msgID;
								}	
								if (msgID > 65535) {
									Util.Message(rmgr, Msg.OutofRange, lineNum, parsed[data]);
									exitCode = 5;
								}
								sevNum = (uint)severity["Success"];
								facNum = (uint)facility["Application"];
								symName = null;
								firstLang = true;
								break;

								// Get the specified Facility code
							case "facility":
								if (facility.ContainsKey(parsed[data]))
									facNum = (uint)facility[parsed[data]];
								else {
									Util.Message(rmgr, Msg.UndefinedElement, "Facility", lineNum, parsed[data]);
									exitCode = 6;
								}
								break;

								// get the specified Severity code
							case "severity":
								if (severity.ContainsKey(parsed[data]))
									sevNum = (uint)severity[parsed[data]];
								else {
									Util.Message(rmgr, Msg.UndefinedElement, "Severity", lineNum, parsed[data]);
									exitCode = 6;
								}
								break;

								// get the specified symbolic name
							case "symbolicname":
								if (!symbol.ContainsKey(parsed[data])) {
									symName = parsed[data];
								}	else {
									Util.Message(rmgr, Msg.SymbolAlreadyDefined, lineNum, parsed[data]);
									exitCode = 7;
								}
								break;

								// process the message text for this language
							case "language":
								if (language.ContainsKey(parsed[data])) {
									culture = (string)language[parsed[data]];
									// get or create the resource writer for this language
									if (resource.ContainsKey(culture))
										rw = (IResourceWriter)resource[culture];
									else {
										if (resType.Equals("resx"))
											rw = new ResXResourceWriter(resFile+"."+culture+".resx");
										else
											rw = new ResourceWriter(resFile+"."+culture+".resources");
										resource.Add(culture, rw);
									}
								} else {
									Util.Message(rmgr, Msg.UndefinedElement, "Language", lineNum, parsed[data]);
									exitCode = 6;
								}

								if (exitCode == 0) {
									// format mesage id and process message text
									msgNum = (sevNum << 30) | (facNum << 16) | msgID;
									msgName = string.Format("{0,8:X8}", msgNum);
									if (dupMsg.ContainsKey(msgName)) {
										Util.Message(rmgr, Msg.DuplicateMessageID, sevNum, facNum, msgID);
										exitCode = 10;
									} else {
										dupMsg.Add(msgName, null);
										ProcessMessage(rw, msgName, out resText);
										++resCnt;
										// save symbolic name and message text for cross reference class
										if (symName == null)
											symName = msgName;
										if (firstLang) {
											symbol.Add(symName, msgName+";"+resText);
											fallBack.AddResource(msgName, resText.Replace("\\n", "\n").Replace("\\t", "\t"));
										}
										firstLang = false;
									}
								}
								parsed[rest] = "";
								break;
						}		// end switch (keyWord)

						curLine = parsed[rest];
						if (exitCode > 0) break;
					}		// end if (curLine[0] != ';')
					
				}		
				if (exitCode > 0) break;
				curLine = mcRdr.ReadLine();
				++lineNum;
			}		// end while (curLine != null)

			// close all open resource writers
			System.Collections.IDictionaryEnumerator ide = resource.GetEnumerator();
			while (ide.MoveNext()) {
				rw = (IResourceWriter)ide.Value;
				rw.Close();
				rw.Dispose();
			}
			fallBack.Close();
			fallBack.Dispose();

			return resCnt;
		}

		/// <summary>
		/// Format a text message for inclusion into a resource
		/// </summary>
		/// <param name="rw">The IResourceWriter</param>
		/// <param name="msgName">The message id</param>
		/// <param name="resText">returns the formated message</param>
		/// <returns>The number of lines read to process this message</returns>
		/// <remarks>This routine gathers the text lines that comprise this message into a signle resource. 
		/// Any place holder codes are replaced with thier actual values.</remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/28/2006"></modified>
		/// </history>
		private void ProcessMessage(IResourceWriter rw, string msgName, out string resText) {

			resText ="";
			curLine = mcRdr.ReadLine();
			while (curLine != null) {
				++lineNum;
				curLine = curLine.Trim();
				// is then the end of the message
				if (curLine.Length == 0 || curLine == ".") break;
				// replave any place holders with the correct data
				curLine = curLine.Replace("\\b", " ");
				resText += curLine;
				curLine = mcRdr.ReadLine();
			}
			if (resText.EndsWith("\\0"))
				resText = resText.Substring(0, resText.Length-2);
			else
				resText += "\\n";
			rw.AddResource(msgName, resText.Replace("\\n","\n").Replace("\\t","\t"));
		}

	}
}
