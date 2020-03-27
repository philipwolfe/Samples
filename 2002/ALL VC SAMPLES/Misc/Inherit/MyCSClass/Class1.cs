namespace MyCSClass
{
	using System;

	/// <summary>
	///		A simple C# class with one method
	/// </summary>
	public class CSClass
	{
		public CSClass()
		{
		}

		/// <summary>
		/// Returns the length of a string
		/// </summary>
		/// <param name="str">The string whose length we are interested in.</param>
		/// <returns>The length of the string</returns>
		public int MyMethod(string str)
		{
			return str.Length;
		}

		/// <summary>
		/// Returns the square of a value
		/// </summary>
		/// <param name="n">The value to square.</param>
		/// <returns>The square of the value</returns>
		virtual public int MyVirtualMethod(int n)
		{
			return n*n;
		}
	}
}
