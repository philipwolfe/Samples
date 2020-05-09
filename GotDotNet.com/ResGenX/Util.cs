using System;

namespace ResGenX {
	/// <summary>
	/// Common Utility functions for ResGenX.
	/// </summary>
	public class Util {
		/// <summary>
		/// Creates the message and Symbolc name cross reference
		/// </summary>
		/// <param name="fileName">Name of the cross reference file</param>
		/// <param name="symbol">Sorted list that hols the cross reference data</param>
		/// <param name="xrefType">The type of cross reference file to create</param>
		/// <returns>The cross reference is a class that links the message
		/// symbolic name to the message ID.</returns>
		/// <remarks></remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/31/2006"></modified>
		/// </history>
		static internal void CreateXref(string fileName, System.Collections.SortedList symbol, string xrefType) {
			bool xrefCS, xrefVB;
			int pos;
			string symName, resText, msgName;

			System.IO.TextWriter cstw, vbtw;

			xrefCS = true;
			xrefVB = true;
			if (xrefType == "cs")
				xrefVB = false;
			if (xrefType == "vb")
				xrefCS = false;

			vbtw = cstw = null;
			if (xrefCS) {
				if (System.IO.File.Exists(fileName+".cs"))
					System.IO.File.Delete(fileName+".cs");
				cstw = new System.IO.StreamWriter(System.IO.File.OpenWrite(fileName+".cs"));
				cstw.WriteLine("namespace Messages {");
				cstw.WriteLine("\t/// <summary>SymbolicName and MsgID cross reference for "+
					fileName.Substring(fileName.LastIndexOf('\\')+1)+"</summary>"); 
				cstw.WriteLine("\tpublic class Msg {");
			}

			if (xrefVB) {
				if (System.IO.File.Exists(fileName+".vb"))
					System.IO.File.Delete(fileName+".vb");
				vbtw = new System.IO.StreamWriter(System.IO.File.OpenWrite(fileName+".vb"));
				vbtw.WriteLine("Namespace Messages");
				vbtw.WriteLine("\t'// <summary>SymbolicName and MsgID cross reference for "+
					fileName.Substring(fileName.LastIndexOf('\\')+1)+"</summary>");
				vbtw.WriteLine("\tPublic Class Msg");
			}

			System.Collections.IDictionaryEnumerator ide = symbol.GetEnumerator();
			while (ide.MoveNext()) {
				symName = (string)ide.Key;
				msgName = (string)ide.Value;
				pos = msgName.IndexOf(';');
				resText = msgName.Substring(pos+1);
				if (resText.Length > 100)
					resText = resText.Substring(0, resText.IndexOf("\\n")+2);
				if (resText.Length > 100)
					resText = resText.Substring(0, 80);
				msgName = msgName.Substring(0, pos);

				if (xrefCS) {
					cstw.WriteLine(" ");
					cstw.WriteLine("\t\t//");
					cstw.WriteLine("\t\t// "+resText);
					cstw.WriteLine("\t\t//");
					cstw.WriteLine("\t\tpublic const string "+symName+" = \""+msgName+"\";"); 
				}

				if (xrefVB) {
					vbtw.WriteLine(" ");
					vbtw.WriteLine("\t\t'");
					vbtw.WriteLine("\t\t' "+resText);
					vbtw.WriteLine("\t\t'");
					vbtw.WriteLine("\t\tPublic Const "+symName+" as String = \""+msgName+"\""); 
				}
			}
			if (xrefCS) {
				cstw.WriteLine("\t}");
				cstw.WriteLine("}");
				cstw.Flush();
				cstw.Close();
			}
			if (xrefVB) {
				vbtw.WriteLine("\tEnd Class");
				vbtw.WriteLine("End Namespace");
				vbtw.Flush();
				vbtw.Close();
			}
		}
		
		/// <summary>
		/// Writes messages to the console
		/// </summary>
		/// <param name="rmgr">The ResourceManager for the message resources</param>
		/// <param name="msgID">The ID of the message to write</param>
		/// <param name="args">Any string format arguments</param>
		/// <returns></returns>
		/// <remarks>This routine looks up a message in the Messages resource and
		/// writes it to the console. Error messages are written to <c>stderr</c>
		/// all other messages are written to <c>stdout</c>.</remarks>
		/// <history>
		/// 	 <modified  user="JJohnson"  date ="7/26/2006"></modified>
		/// </history>
		static internal void Message(System.Resources.ResourceManager rmgr, string msgID, params object[] args) {
			System.IO.TextWriter stream;

			int sevNum = ("123456789ABCDEF".IndexOf(msgID[0])+1) >> 2;
			 
			if (sevNum > 1)
				stream = Console.Error;
			else stream = Console.Out;
			
			stream.Write(rmgr.GetString(msgID), args);
		}
	}
}