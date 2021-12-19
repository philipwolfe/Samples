// MakeTable.cs -- Demo us using the table generators from csharp
// Trivial demo - really exists only as a comparison against MakeTable.py
using System;

public class Application {

	public static void
	MakeTable(TableGen.TableGenerator gen, String param) {
		gen.SetParameter(param);
		Console.WriteLine(gen.GetHeader());
		for (int col = 0; col < gen.GetColumnCount(); col++) {
			for (int row = 0; row < gen.GetRowCount(); row++) {
				Console.Write("{0}\t", gen.GetCell(row, col));
			}
			Console.WriteLine();
		}
		Console.WriteLine(gen.GetFooter());
	}

	public static int
	Main(String []args) {
		Console.WriteLine("--- A Calendar ---");
		MakeTable( new CalendarGenerator(), "06/2000");

		Console.WriteLine("--- A Multiplication Table ---");
		MakeTable( new MultiGen.MultiGenerator(), "7*8");

		Console.WriteLine("--- A Python Powered Power Table ---");
		MakeTable( new PowerGenerator(), "7*8");

		return 0;
	}
	
};