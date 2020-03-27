using System;

namespace ConsoleApplication1
{
	
	class Class1
	{
		static void Main(string[] args)
		{
			String s;
			Int32 suffix_pos;
			substring_w string1 = new substring_w();
			Console.WriteLine("Enter the string ...");
			s = Console.ReadLine();
			Console.WriteLine("Enter the position ...");
			suffix_pos = Int32.Parse(Console.ReadLine());
			Console.WriteLine(string1.find_suffix(s, suffix_pos));

		}
	}
}
