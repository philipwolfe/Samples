//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//-----------------------------------------------------------------------
// --------------------------------------------------------------------------
//  StringWalker class: this string encapsulates string operations in order
//  to provide easy methods that handle surrogates and combining characters
// --------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.Samples.StringWalker
{
	[Serializable]
	public class StringWalkerException : Exception
	{
		public StringWalkerException()           : base() { }
		public StringWalkerException(String message) : base(message) { }
		public StringWalkerException(String message, Exception innerException) : base(message, innerException) { }
		protected StringWalkerException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}

	public class StringWalker
	{
		// private members
		private string myString = String.Empty;

		private int[] myIndex;

		private int myPos;

		// public property
		public int Length
		{
			get
			{
				return (null != myIndex) ? myIndex.Length : 0;
			}
		}

		// constructor
		public StringWalker(string input)
		{
			Initialize(input);
		}

		// ToString overriden method
		public override string ToString()
		{
			return myString;
		}

		// "easy" walking methods: GetFirst, GetNext, GetPrev, GetLast, Get
		// these are basically wrapper around the GetSubString method
		public bool GetFirst(out string input)
		{
			myPos = 0;
			return Get(myPos, out input);
		}

		public bool GetLast(out string input)
		{
			myPos = Length - 1;
			return Get(myPos, out input);
		}

		public bool GetNext(out string input)
		{
			return Get(++myPos, out input);
		}

		public bool GetPrevious(out string input)
		{
			return Get(--myPos, out input);
		}

		public bool Get(int index, out string input)
		{
			return (0 != GetSubString(index, 1, out input));
		}

		// GetSubString method
		public int GetSubString(int index, int count, out string input)
		{
			// check for index within bounds and non zero count
			if ((1 <= count) && (0 <= index) && (index < Length))
			{
				try
				{
					int lastindex = index + count;

					// if we are past the last char, then we get the string
					// up to the last char and return the actual count
					if (lastindex > (Length - 1))
					{
						input = myString.Substring(myIndex[index]);
						return Length - index;
					}
					else
					{
						input = myString.Substring(myIndex[index], myIndex[lastindex] - myIndex[index]);
						return count;
					}
				}
				catch // catch all and throw our exception
				{
					throw (new StringWalkerException());
				}
			}
			else
			{
				input = String.Empty;
				return 0;
			}
		}

		// Insert, Remove: both methods return true if the operation was succesful and false otherwise
		// Insert: inserts a string at the specified position
		public bool Insert(int index, string input)
		{
			if ((0 <= index) && (index <= Length))
			{
				try
				{
					if (index == Length)
						Initialize(myString.Insert(myString.Length, input));
					else
						Initialize(myString.Insert(myIndex[index], input));

					return true;
				}
				catch // catch all and throw our exception
				{
					throw (new StringWalkerException());
				}
			}

			return false;
		}

		// Remove: removes the specified number of text elements starting at the specified position
		public bool Remove(int index, int count)
		{
			if ((count > 0) && (0 <= index) && (index < Length))
			{
				try
				{
					int idxLast = index + count;
					int charcount = (idxLast < Length) ? myIndex[idxLast] - myIndex[index] : myString.Length - myIndex[index];

					Initialize(myString.Remove(myIndex[index], charcount));
					return true;
				}
				catch // catch all and throw our exception
				{
					throw (new StringWalkerException());
				}
			}

			return false;
		}

		// IndexOf: 
		public int IndexOf(string input, int index)
		{
			if ((0 <= index) && (index < Length))
			{
				try
				{
					// try and find the input string in the current string
					int position = myIndex[index];
					int foundAt = myString.IndexOf(input, position);

					// if the string is found, then we need to see if it
					// can be matched to a text element index.
					if (-1 != foundAt)
					{
						for (int i = 0; i < myIndex.Length; i++)
							if (myIndex[i] == foundAt)
								return i;
					}
				}
				catch // catch all and throw our exception
				{
					throw (new StringWalkerException());
				}
			}

			return -1;
		}

		// private initialization method
		private void Initialize(string input)
		{
			try
			{
				myPos = 0;
				myString = input;
				myIndex = StringInfo.ParseCombiningCharacters(myString);
			}
			catch (ArgumentNullException)
			{
				throw (new StringWalkerException());
			}
		}
	}
}
