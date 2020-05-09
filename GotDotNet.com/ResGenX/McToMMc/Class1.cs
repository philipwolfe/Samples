using System;
using System.IO;


namespace McToMMc {
	/// <summary>
	/// Convert .mc file for use with managed code
	/// </summary>
	/// <remarks>The syntax of the <c>McToMMc</c> command is:
	/// <code>McToMMc infile.mc[,outfile.ext] ...</code>
	/// The infile must have an extension of <c>mc</c>. If the output file
	/// is not specified a name of <c>infile.mmc</c> will be used. Multiple
	/// infile,outfile parameters may be specified.
	/// <para>The <c>%c</c> formating strings used in an mc file are replaced as follows:
	/// <list type="definition">
	/// <item><term>%.</term><description>Replace with a period.</description></item>
	/// <item><term>%b</term><description>Replaced with "\b".</description></item>
	/// <item><term>%%</term><description>Replaced by a percent sign.</description></item>
	/// <item><term>%!</term><description>Replaced by a exclamation point.</description></item>
	/// <item><term>%r</term><description>Replaced with "\r".</description></item>
	/// <item><term>%\</term><description>Replaced with "\n".</description></item>
	/// <item><term>%0</term><description>Replaced with "\0".</description></item>
	/// <item><term>%nn[!printf-format-specifier!]</term><description>Replaced with a managed code format specifier.</description></item>
	/// </list></para>
	/// </remarks>
	/// <history>
	/// 	 <modified  user="JJohnson"  date ="7/25/2006"></modified>
	/// </history>
	class Class1 {

		[STAThread]
		static int Main(string[] args) {
			if (args.Length < 1) return 0;
			Converter prog = new Converter();
			return prog.Process(args);
			//string[] testargs = new string[] {@"E:\CatErr.mc"};
			//string[] testargs = new string[] {"-h"};
			//return prog.Process(testargs);
			
		}
	}
	/// <summary>
	/// Performs the actual .mc file conversion.
	/// </summary>
	/// <remarks>See <see cref="Class1"/> for a description of the conversion process.</remarks>
	/// <history>
	/// 	 <modified  user="JJohnson"  date ="8/8/2006"></modified>
	/// </history>
	class Converter {
		private int exitCode;

		private int lineNum;			// current line number of input file
		private string curLine;	// current line of input being processed;

		internal int Process(string[] args) {
			string inFileName, outFileName;
			int ndx = 0, pos;

			if (args[0].ToLower().Equals("-h") || args[0].ToLower().Equals("--help")) {
				Console.WriteLine("Usage: McToMMc infile.mc[,outfile.ext] ...\n"+
					"\nInput file must have an extension of '.mc'.\n"+
					"If output file is not specified a name of 'infile.mmc' will be used.");
				return 0;
			}

			exitCode = 0;

			for (; ndx < args.Length; ++ndx) {
				// get input file name
				inFileName = args[ndx];
				outFileName = "";
				if ((pos = inFileName.IndexOf(',')) > 0) {
					outFileName = inFileName.Substring(pos+1);
					inFileName = inFileName.Substring(0,pos-1);
				}

				// check if extension was specified and that it is .mc
				if (inFileName.ToLower().EndsWith(".mc") && File.Exists(inFileName)) {
					if (outFileName.Length == 0)
						outFileName = inFileName.Substring(0,inFileName.Length-3)+".mmc";
					Convert(inFileName, outFileName);
				} else {
					Console.Error.Write("Input file does not exist or has invalid extension.");
					exitCode = 2;
					break;
				}

				if (exitCode != 0)
					break;
			}

			return exitCode;
		}

		private void Convert(string inFile, string outFile) {
			bool inMsg;

			// IO stream used to read the .mc file
			TextReader tr = new System.IO.StreamReader(File.OpenRead(inFile));
			if (File.Exists(outFile))
				File.Delete(outFile);
			// IO stream to write the converted file to
			TextWriter tw = new StreamWriter(File.OpenWrite(outFile));

			inMsg = false;
			curLine = tr.ReadLine();
			++lineNum;
			while (curLine != null) {
				if (curLine.Trim().Equals("."))
					inMsg = false;

				if (inMsg) ConvertLine();
				else
					if (curLine.Trim().ToLower().StartsWith("language="))
					inMsg = true;
			
				tw.WriteLine(curLine);
				curLine = tr.ReadLine();
			}
			tw.Flush();
			tw.Close();
			tr.Close();
		}

		private void ConvertLine() {
			string format, printf, width, percision, line;
			int pos, index;
			char flag = ' ', type = ' ';
		
			line = curLine.Substring(0, curLine.Length);
			curLine = "";
			// replave any place holders with the correct data
			line = line.Replace("%b", "\b");
			line = line.Replace("%.", ".");
			line = line.Replace("%r", "\r");
			// is a line break need at the end of the message
			if (line.EndsWith("%\\"))
				line = line.Substring(0,line.Length-2)+"\\n";
			// check if no line break requested
			if (line.EndsWith("%0")) 
				line = line.Substring(0,line.Length-2)+"\\0";
			// scan for and replace any printf formating strings
			pos = line.IndexOf('%');
			index = 0;
			while (pos >= 0) {
				curLine += line.Substring(0,pos);
				// remove the %
				line = line.Substring(pos+1);
				// did we find a %! or a %%
				if (line[0] == '!' || line[0] == '%') {
					curLine += line.Substring(0,1);
					line = line.Substring(1);
				} else {
					// initalize format string
					format = "";
					// extract the one or two digit index number and any formating string
					// the format string has the following format:
					// [flag][width[.percision]][modifier]type
					if (Char.IsDigit(line[0])) {
						index = 1;
						if (Char.IsDigit(line[1])) ++index;
						int val = Int32.Parse(line.Substring(0, index));
						--val;
						format = "{"+val.ToString();
						line = line.Substring(index);
						printf = null;
						// is there a formating string
						if (line[0] == '!') {
							if ((pos = line.IndexOf('!', 1)) > 0) {
								printf = line.Substring(1, pos-1);
								line = line.Substring(pos+1);
							}
						}
						if (printf != null) {
							// extract type
							type = printf[printf.Length-1];
							printf = printf.Substring(0, printf.Length-1);
							// remove any type modifier
							pos = printf.Length-1;
							if ("hlI".IndexOf(printf[pos]) >= 0)
								printf = printf.Substring(0, printf.Length-1);
							else {
								if (printf.EndsWith("I32") || printf.EndsWith("I64"))
									printf = printf.Substring(0, printf.Length-3);
							}
							// extract flag char if present
							flag = '~';
							if ("-+0 #".IndexOf(printf[0]) >= 0) {
								flag = printf[0];
								printf = printf.Substring(1);
							}
							width = "";
							percision = "";
							if (printf.Length > 0) {
								if ((pos = printf.IndexOf('.')) > 0) {
									width = printf.Substring(0, pos);
									percision = printf.Substring(pos+1);
								} else width = printf;
							}

							if (flag == '#') {
								if (type == 'x')
									format = "0x"+format;
								else {
									if (type == 'X')
										format = "0X"+format;
									else format = "0"+format;
								}
							}
							if (flag == '-' && width.Length > 0)
								width = "-"+width;
							if (width.Length > 0)
								format += ","+width;
							if ("diou".IndexOf(type) >= 0)
								format += ":D"+percision;
							else {
								if ("Ggf".IndexOf(type) >= 0)
									format += ":G"+percision;
								else {
									if (type == 'e')
										format = ":e"+percision;
									if (type == 'E')
										format = ":E"+percision;
								}
							}
						}
						format += "}";
					}
					curLine += format;
				}		// end if (line[0] == '!' || line[0] == '%') else

				pos = line.IndexOf('%');
			}		// end while (pos >= 0)
			curLine += line;
		}

	}
}
