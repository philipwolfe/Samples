using System;
using System.Drawing;


namespace ConsoleAnimate
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (0 == args.GetLength(0))
			{
				ShowMessage();
				return;
			}

			Console.Clear();
			Console.CursorVisible = false;

			StringMatrixGenerator generator = new StringMatrixGenerator();
			generator.CharacterFont = new Font("Times New Roman", 12, FontStyle.Bold);

			System.Collections.ArrayList effects = new System.Collections.ArrayList();
		
			TopToDownEffect topDownEffect = new TopToDownEffect();
			topDownEffect.Frames = 5;
			effects.Add(topDownEffect);

			FadeToDefaultEffect effect = new FadeToDefaultEffect();
			effect.Frames = 5;
			//effects.Add(effect);

			OutInEffect outInEffect = new OutInEffect();
			outInEffect.Frames = 10;
			//effects.Add(outInEffect);

			RandomEffect randomEffect = new RandomEffect();
			randomEffect.Frames = 10;
			effects.Add(randomEffect);

			for (int i = 0; i < args.GetLength(0); i++)
			{
				MatrixPoint[] points = generator.GenerateMatrix(args[i]);
				
				IConsoleFunEffect currentEffect = (IConsoleFunEffect)effects[i % effects.Count];
				currentEffect.SetPoints( points );
				
				ConsoleFun.Animate(currentEffect, 100);
				System.Threading.Thread.Sleep(3000);
				Console.Clear();
			}

			Console.ForegroundColor = ConsoleColor.White;
			Console.CursorVisible = true;
		}

		static void ShowMessage()
		{
			Console.WriteLine( "Welcome to ConsoleAnimate Demo Application." );
			Console.WriteLine( "This application will demo some of the new feature in the new implementation of the System.Console class in Whidbey.");
			Console.WriteLine("Usage:");
			Console.WriteLine("ConsoleAnimate.exe str1 str2 str3 str4 ... strN");
			Console.WriteLine("str1 --> strN are the strings that the application will output.");
		}
	}
}
