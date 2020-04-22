using System;
using System.Globalization;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using System.Reflection;
using System.Security.Cryptography;

public interface IThreadRunnable
{
	/// <summary>
	/// This method has to be implemented in order that starting of the thread causes the object's 
	/// run method to be called in that separately executing thread.
	/// </summary>
	void Run();
}

public class Utils
{
	public static long DateTime01011970 = 621355968000000000;
	public static char INTERNAL_ACTION_ID_DELIMITER = '#';
	public static IFormatProvider CultureInfoEn = new CultureInfo("en-US", false);

	#region Date
	private static DateTime currentDate = DateTime.MinValue;
	/// <summary>
	/// Get ceuurent DateTime (default = Now)
	/// </summary>
	public static DateTime Date
	{
		get
		{
			if (currentDate != DateTime.MinValue)
				return currentDate;
			else
				return DateTime.Now;
		}
	}
	#endregion
	#region OverrideCurrentDate(DateTime)
	/// <summary>
	/// Override Current Date (default = Now)
	/// </summary>
	/// <param name="current">DateTime to override</param>
	public static void OverrideCurrentDate(DateTime current)
	{
		currentDate = current;
	}
	#endregion

	#region ToHexString(sbyte[])
	/// <summary> The hex digits used to build a hex string representation of a byte array.</summary>
	private static readonly char[] hexChar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

	/// <summary>
	/// Converts a byte array to a hex string representing it. The hex digits are lower case.
	/// </summary>
	/// <param name="b">the byte array to convert</param>
	/// <returns> the hex representation of b</returns>
	public static string ToHexString(sbyte[] b)
	{
		StringBuilder sb = new StringBuilder(b.Length * 2);
		for (int i = 0; i < b.Length; i++)
		{
			sb.Append(hexChar[Utils.URShift((b[i] & 0xf0), 4)]);
			sb.Append(hexChar[b[i] & 0x0f]);
		}
		return sb.ToString();
	}
	#endregion
	#region GetInternalActionId(actionId)
	public static string GetInternalActionId(string actionId)
	{
		if (actionId == null) return null;
		int delimiterIndex = actionId.IndexOf(INTERNAL_ACTION_ID_DELIMITER);
		if (delimiterIndex > 0)
			return actionId.Substring(0, delimiterIndex).Trim();
		return null;
	}
	#endregion
	#region StripInternalActionId(actionId)
	public static string StripInternalActionId(string actionId)
	{
		if (actionId == null) return null;
		int delimiterIndex = actionId.IndexOf(INTERNAL_ACTION_ID_DELIMITER);
		if (delimiterIndex > 0)
		{
			if (actionId.Length > delimiterIndex + 1)
				return actionId.Substring(delimiterIndex + 1).Trim();
		}
		return null;
	}
	#endregion
	#region AddInternalActionId(actionId, internalActionId)
	public static string AddInternalActionId(string actionId, string internalActionId)
	{
		if (actionId == null)
			return internalActionId + INTERNAL_ACTION_ID_DELIMITER;
		else
			return internalActionId + INTERNAL_ACTION_ID_DELIMITER + actionId;
	}
	#endregion
	#region IsTrue(string)
	/// <summary>
	/// Checks if a String represents <code>true</code> or <code>false</code> according to Asterisk's logic.<br/>
	/// The original implementation is <code>util.c</code> is as follows:
	/// </summary>
	/// <param name="s">the String to check for <code>true</code>.</param>
	/// <returns>
	/// <code>true</code> if s represents <code>true</code>,
	/// <code>false</code> otherwise.
	/// </returns>
	public static bool IsTrue(string s)
	{
		if (s == null || s.Length == 0)
			return false;
		string sx = s.ToLower();
		if (sx == "yes" || sx == "true" || sx == "y" || sx == "t" || sx == "1" || sx == "on")
			return true;
		return false;
	}
	#endregion

	#region ToByteArray(...)
	/// <summary>
	/// Converts an array of sbytes to an array of bytes
	/// </summary>
	/// <param name="sbyteArray">The array of sbytes to be converted</param>
	/// <returns>The new array of bytes</returns>
	public static byte[] ToByteArray(sbyte[] sbyteArray)
	{
		byte[] byteArray = null;

		if (sbyteArray != null)
		{
			byteArray = new byte[sbyteArray.Length];
			for (int index = 0; index < sbyteArray.Length; index++)
				byteArray[index] = (byte)sbyteArray[index];
		}
		return byteArray;
	}

	/// <summary>
	/// Converts a string to an array of bytes
	/// </summary>
	/// <param name="byteString">The string to be converted</param>
	/// <returns>The new array of bytes</returns>
	public static byte[] ToByteArray(string byteString)
	{
		return UTF8Encoding.UTF8.GetBytes(byteString);
	}

	/// <summary>
	/// Converts a array of object-type instances to a byte-type array.
	/// </summary>
	/// <param name="tempObjectArray">Array to convert.</param>
	/// <returns>An array of byte type elements.</returns>
	public static byte[] ToByteArray(object[] tempObjectArray)
	{
		byte[] byteArray = null;
		if (tempObjectArray != null)
		{
			byteArray = new byte[tempObjectArray.Length];
			for (int index = 0; index < tempObjectArray.Length; index++)
				byteArray[index] = (byte)tempObjectArray[index];
		}
		return byteArray;
	}

	/// <summary>
	/// Receives a byte array and returns it transformed in an sbyte array
	/// </summary>
	/// <param name="byteArray">Byte array to process</param>
	/// <returns>The transformed array</returns>
	public static sbyte[] ToSByteArray(byte[] byteArray)
	{
		sbyte[] sbyteArray = null;
		if (byteArray != null)
		{
			sbyteArray = new sbyte[byteArray.Length];
			for (int index = 0; index < byteArray.Length; index++)
				sbyteArray[index] = (sbyte)byteArray[index];
		}
		return sbyteArray;
	}
	#endregion

	#region GetConstructorModifiers(constructor)
	/// <summary>
	/// Obtains the int value depending of the type of modifiers that the constructor have
	/// </summary>
	/// <param name="constructor">The ConstructorInfo used to obtain the int value</param>
	/// <returns>The int value of the modifier present in the constructor. 1 if it's public, 2 if it's private, otherwise 4</returns>
	public static int GetConstructorModifiers(ConstructorInfo constructor)
	{
		int temp;
		if (constructor.IsPublic)
			temp = 1;
		else if (constructor.IsPrivate)
			temp = 2;
		else
			temp = 4;
		return temp;
	}
	#endregion

	#region CollectionToString(collection)
	/// <summary>
	/// Converts the specified collection to its string representation.
	/// </summary>
	/// <param name="c">The collection to convert to string.</param>
	/// <returns>A string representation of the specified collection.</returns>
	public static string CollectionToString(ICollection c)
	{
		StringBuilder s = new StringBuilder();
		if (c != null)
		{
			ArrayList l = new ArrayList(c);

			bool isDictionary = (c is BitArray || c is Hashtable || c is IDictionary || c is NameValueCollection || (l.Count > 0 && l[0] is DictionaryEntry));
			for (int index = 0; index < l.Count; index++)
			{
				if (l[index] == null)
					s.Append("null");
				else if (!isDictionary)
					s.Append(l[index]);
				else
				{
					isDictionary = true;
					if (c is NameValueCollection)
						s.Append(((NameValueCollection)c).GetKey(index));
					else
						s.Append(((DictionaryEntry)l[index]).Key);
					s.Append("=");
					if (c is NameValueCollection)
						s.Append(((NameValueCollection)c).GetValues(index)[0]);
					else
						s.Append(((DictionaryEntry)l[index]).Value);

				}
				if (index < l.Count - 1)
					s.Append(", ");
			}

			if (isDictionary)
			{
				if (c is ArrayList)
					isDictionary = false;
			}
			if (isDictionary)
			{
				s.Insert(0, "{");
				s.Append("}");
			}
			else
			{
				s.Insert(0, "[");
				s.Append("]");
			}
		}
		else
			s.Insert(0, "null");
		return s.ToString();
	}
	#endregion

	#region URShift(...)
	/// <summary>
	/// Performs an unsigned bitwise right shift with the specified number
	/// </summary>
	/// <param name="number">Number to operate on</param>
	/// <param name="bits">Ammount of bits to shift</param>
	/// <returns>The resulting number from the shift operation</returns>
	public static int URShift(int number, int bits)
	{
		if (number >= 0)
			return number >> bits;
		else
			return (number >> bits) + (2 << ~bits);
	}

	/// <summary>
	/// Performs an unsigned bitwise right shift with the specified number
	/// </summary>
	/// <param name="number">Number to operate on</param>
	/// <param name="bits">Ammount of bits to shift</param>
	/// <returns>The resulting number from the shift operation</returns>
	public static int URShift(int number, long bits)
	{
		return URShift(number, (int)bits);
	}

	/// <summary>
	/// Performs an unsigned bitwise right shift with the specified number
	/// </summary>
	/// <param name="number">Number to operate on</param>
	/// <param name="bits">Ammount of bits to shift</param>
	/// <returns>The resulting number from the shift operation</returns>
	public static long URShift(long number, int bits)
	{
		if (number >= 0)
			return number >> bits;
		else
			return (number >> bits) + (2L << ~bits);
	}

	/// <summary>
	/// Performs an unsigned bitwise right shift with the specified number
	/// </summary>
	/// <param name="number">Number to operate on</param>
	/// <param name="bits">Ammount of bits to shift</param>
	/// <returns>The resulting number from the shift operation</returns>
	public static long URShift(long number, long bits)
	{
		return URShift(number, (int)bits);
	}
	#endregion

	#region Class - MessageDigestSupport
	/// <summary>
	/// Encapsulates the functionality of message digest algorithms such as SHA-1 or MD5.
	/// </summary>
	public class MessageDigestSupport
	{
		private HashAlgorithm algorithm;
		private byte[] data = new byte[0];
		private int position;
		private string algorithmName;

		/// <summary>
		/// Creates a message digest using the specified name to set Algorithm property.
		/// </summary>
		/// <param name="algorithm">The name of the algorithm to use</param>
		public MessageDigestSupport(string algorithm)
		{
			if (algorithm.Equals("SHA-1"))
			{
				this.algorithmName = "SHA";
			}
			else
			{
				this.algorithmName = algorithm;
			}
			this.Algorithm = (HashAlgorithm)CryptoConfig.CreateFromName(this.algorithmName);
			this.data = new byte[0];
			this.position = 0;
		}

		#region Algorithm
		/// <summary>
		/// The HashAlgorithm instance that provide the cryptographic hash algorithm
		/// </summary>
		public HashAlgorithm Algorithm
		{
			get
			{
				return this.algorithm;
			}
			set
			{
				this.algorithm = value;
			}
		}
		#endregion
		#region Data
		/// <summary>
		/// The digest data
		/// </summary>
		public byte[] Data
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = value;
			}
		}
		#endregion
		#region AlgorithmName
		/// <summary>
		/// The name of the cryptographic hash algorithm used in the instance
		/// </summary>
		public string AlgorithmName
		{
			get
			{
				return this.algorithmName;
			}
		}
		#endregion
		#region DigestData
		/// <summary>
		/// Computes the hash value for the internal data digest.
		/// </summary>
		/// <returns>The array of signed bytes with the resulting hash value</returns>
		public sbyte[] DigestData()
		{
			sbyte[] result = ToSByteArray(this.Algorithm.ComputeHash(this.data));
			this.Reset();
			return result;
		}
		/// <summary>
		/// Performs and update on the digest with the specified array and then completes the digest
		/// computation.
		/// </summary>
		/// <param name="newData">The array of bytes for final update to the digest</param>
		/// <returns>An array of signed bytes with the resulting hash value</returns>
		public sbyte[] DigestData(sbyte[] newData)
		{
			this.Update(ToByteArray(newData));
			return this.DigestData();
		}


		/// <summary>
		/// Computes the hash value for the internal digest and places the digest returned into the specified buffer
		/// </summary>
		/// <param name="buffer">The buffer for the output digest</param>
		/// <param name="offset">Offset into the buffer for the beginning index</param>
		/// <param name="length">Total number of bytes for the digest</param>
		/// <returns>The number of bytes placed into the output buffer</returns>
		public int DigestData(sbyte[] buffer, int offset, int length)
		{
			byte[] result = this.Algorithm.ComputeHash(this.data);
			int count = 0;
			if (length >= this.GetDigestLength())
			{
				if (buffer.Length >= (length + offset))
				{
					for (; count < result.Length; count++)
					{
						buffer[offset + count] = (sbyte)result[count];
					}
				}
				else
				{
					throw new ArgumentException("output buffer too small for the specified offset and length");
				}
			}
			else
			{
				throw new Exception("Partial digests not returned");
			}
			return count;
		}
		#endregion
		#region Update
		/// <summary>
		/// Updates the digest data with the specified array of bytes by making an append
		/// operation in the internal array of data.
		/// </summary>
		/// <param name="newData">The array of bytes for the update operation</param>
		public void Update(byte[] newData)
		{
			if (position == 0)
			{
				this.Data = newData;
				this.position = this.Data.Length - 1;
			}
			else
			{
				byte[] oldData = this.Data;
				this.Data = new byte[newData.Length + position + 1];
				oldData.CopyTo(this.Data, 0);
				newData.CopyTo(this.Data, oldData.Length);

				this.position = this.Data.Length - 1;
			}
		}
		/// <summary>
		/// Updates the digest data with the input byte by calling the method Update with an array.
		/// </summary>
		/// <param name="newData">The input byte for the update</param>
		public void Update(byte newData)
		{
			byte[] newDataArray = new byte[1];
			newDataArray[0] = newData;
			this.Update(newDataArray);
		}

		/// <summary>
		/// Updates the specified count of bytes with the input array of bytes starting at the
		/// input offset.
		/// </summary>
		/// <param name="newData">The array of bytes for the update operation</param>
		/// <param name="offset">The initial position to start from in the array of bytes</param>
		/// <param name="count">The number of bytes fot the update</param>
		public void Update(byte[] newData, int offset, int count)
		{
			byte[] newDataArray = new byte[count];
			Array.Copy(newData, offset, newDataArray, 0, count);
			this.Update(newDataArray);
		}
		#endregion
		#region Reset
		/// <summary>
		/// Resets the digest data to the initial state.
		/// </summary>
		public void Reset()
		{
			this.data = null;
			this.position = 0;
		}
		#endregion
		#region ToString
		/// <summary>
		/// Returns a string representation of the Message Digest
		/// </summary>
		/// <returns>A string representation of the object</returns>
		public override string ToString()
		{
			return this.Algorithm.ToString();
		}
		#endregion
		#region GetInstance
		/// <summary>
		/// Generates a new instance of the MessageDigestSupport class using the specified algorithm
		/// </summary>
		/// <param name="algorithm">The name of the algorithm to use</param>
		/// <returns>A new instance of the MessageDigestSupport class</returns>
		public static MessageDigestSupport GetInstance(string algorithm)
		{
			return new MessageDigestSupport(algorithm);
		}
		#endregion
		#region EquivalentDigest
		/// <summary>
		/// Compares two arrays of signed bytes evaluating equivalence in digest data
		/// </summary>
		/// <param name="firstDigest">An array of signed bytes for comparison</param>
		/// <param name="secondDigest">An array of signed bytes for comparison</param>
		/// <returns>True if the input digest arrays are equal</returns>
		public static bool EquivalentDigest(SByte[] firstDigest, SByte[] secondDigest)
		{
			bool result = false;
			if (firstDigest.Length == secondDigest.Length)
			{
				int index = 0;
				result = true;
				while (result && index < firstDigest.Length)
				{
					result = firstDigest[index] == secondDigest[index];
					index++;
				}
			}

			return result;
		}
		#endregion
		#region GetDigestLength
		/// <summary>
		/// Gets a number of bytes representing the length of the digest
		/// </summary>
		/// <returns>The length of the digest in bytes</returns>
		public int GetDigestLength()
		{
			return this.algorithm.HashSize / 8;
		}
		#endregion
	}
	#endregion

	#region Class - ThreadClass
	/// <summary>
	/// Support class used to handle threads
	/// </summary>
	public class ThreadClass : IThreadRunnable
	{
		/// <summary>The instance of Threading.Thread</summary>
		private Thread thread;

		#region ThreadClass()
		/// <summary>
		/// Initializes a new instance of the ThreadClass class
		/// </summary>
		public ThreadClass()
		{
			thread = new Thread(new ThreadStart(Run));
		}
		#endregion
		#region ThreadClass(name)
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="Name">The name of the thread</param>
		public ThreadClass(string Name)
		{
			thread = new Thread(new ThreadStart(Run));
			this.Name = Name;
		}
		#endregion
		#region ThreadClass(start)
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
		public ThreadClass(ThreadStart start)
		{
			thread = new Thread(start);
		}
		#endregion
		#region ThreadClass(start, name)
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
		/// <param name="name">The name of the thread</param>
		public ThreadClass(ThreadStart start, string name)
		{
			thread = new Thread(start);
			this.Name = name;
		}
		#endregion

		#region Run()
		/// <summary>
		/// This method has no functionality unless the method is overridden
		/// </summary>
		public virtual void Run()
		{
		}
		#endregion
		#region Start()
		/// <summary>
		/// Causes the operating system to change the state of the current thread instance to ThreadState.Running
		/// </summary>
		public virtual void Start()
		{
			thread.Start();
		}
		#endregion
		#region Interrupt()
		/// <summary>
		/// Interrupts a thread that is in the WaitSleepJoin thread state
		/// </summary>
		public virtual void Interrupt()
		{
			thread.Interrupt();
		}
		#endregion
		#region Current()
		/// <summary>
		/// Gets the currently running thread
		/// </summary>
		/// <returns>The currently running thread</returns>
		public static ThreadClass Current()
		{
			ThreadClass CurrentThread = new ThreadClass();
			CurrentThread.Instance = Thread.CurrentThread;
			return CurrentThread;
		}
		#endregion

		#region Instance
		/// <summary>
		/// Gets the current thread instance
		/// </summary>
		public Thread Instance
		{
			get { return thread; }
			set { thread = value; }
		}
		#endregion
		#region Name
		/// <summary>
		/// Gets or sets the name of the thread
		/// </summary>
		public string Name
		{
			get { return thread.Name; }
			set
			{
				if (thread.Name == null)
					thread.Name = value;
			}
		}
		#endregion
		#region Priority
		/// <summary>
		/// Gets or sets a value indicating the scheduling priority of a thread
		/// </summary>
		public ThreadPriority Priority
		{
			get { return thread.Priority; }
			set { thread.Priority = value; }
		}
		#endregion
		#region IsAlive
		/// <summary>
		/// Gets a value indicating the execution status of the current thread
		/// </summary>
		public bool IsAlive
		{
			get { return thread.IsAlive; }
		}
		#endregion
		#region IsBackground
		/// <summary>
		/// Gets or sets a value indicating whether or not a thread is a background thread.
		/// </summary>
		public bool IsBackground
		{
			get { return thread.IsBackground; }
			set { thread.IsBackground = value; }
		}
		#endregion
	}
	#endregion

	#region Class - Tokenizer
	/// <summary>
	/// The class performs token processing in strings
	/// </summary>
	public class Tokenizer : IEnumerator
	{
		/// Position over the string
		private long currentPos = 0;
		/// Include demiliters in the results.
		private bool includeDelims = false;
		/// Char representation of the String to tokenize.
		private char[] chars = null;
		//The tokenizer uses the default delimiter set: the space character, the tab character, the newline character, and the carriage-return character and the form-feed character
		private string delimiters = " \t\n\r\f";

		#region Tokenizer(source)
		/// <summary>
		/// Initializes a new class instance with a specified string to process
		/// </summary>
		/// <param name="tokenize">String to tokenize</param>
		public Tokenizer(string tokenize)
		{
			this.chars = tokenize.ToCharArray();
		}
		#endregion
		#region Tokenizer(source, delimiters)
		/// <summary>
		/// Initializes a new class instance with a specified string to process
		/// and the specified token delimiters to use
		/// </summary>
		/// <param name="tokenize">String to tokenize</param>
		/// <param name="delimiters">String containing the delimiters</param>
		public Tokenizer(string tokenize, string delimiters)
			: this(tokenize)
		{
			this.delimiters = delimiters;
		}
		#endregion
		#region Tokenizer(source, delimiters, includeDelims)
		/// <summary>
		/// Initializes a new class instance with a specified string to process, the specified token 
		/// delimiters to use, and whether the delimiters must be included in the results.
		/// </summary>
		/// <param name=tokenize">String to tokenize</param>
		/// <param name="delimiters">String containing the delimiters</param>
		/// <param name="includeDelims">Determines if delimiters are included in the results.</param>
		public Tokenizer(string tokenize, string delimiters, bool includeDelims)
			: this(tokenize, delimiters)
		{
			this.includeDelims = includeDelims;
		}
		#endregion

		#region NextToken()
		/// <summary>
		/// Returns the next token from the token list
		/// </summary>
		/// <returns>The string value of the token</returns>
		public string NextToken()
		{
			return NextToken(this.delimiters);
		}
		#endregion
		#region NextToken(delimiters)
		/// <summary>
		/// Returns the next token from the source string, using the provided
		/// token delimiters
		/// </summary>
		/// <param name="delimiters">String containing the delimiters to use</param>
		/// <returns>The string value of the token</returns>
		public string NextToken(string delimiters)
		{
			// According to documentation, the usage of the received delimiters should be temporary (only for this call).
			// However, it seems it is not true, so the following line is necessary.
			this.delimiters = delimiters;

			// at the end 
			if (this.currentPos == this.chars.Length)
				throw new ArgumentOutOfRangeException();
			// if over a delimiter and delimiters must be returned
			else if ((Array.IndexOf(delimiters.ToCharArray(), chars[this.currentPos]) != -1)
					 && this.includeDelims)
				return "" + this.chars[this.currentPos++];
			// need to get the token wo delimiters.
			else
				return nextToken(delimiters.ToCharArray());
		}
		#endregion
		#region NextToken(delimiters)
		/// <summary>
		/// Returns the nextToken without delimiters
		/// </summary>
		private string nextToken(char[] delimiters)
		{
			string token = "";
			long pos = this.currentPos;

			//skip possible delimiters
			while (Array.IndexOf(delimiters, this.chars[currentPos]) != -1)
				//The last one is a delimiter (i.e there is no more tokens)
				if (++this.currentPos == this.chars.Length)
				{
					this.currentPos = pos;
					throw new ArgumentOutOfRangeException();
				}

			//getting the token
			while (Array.IndexOf(delimiters, this.chars[this.currentPos]) == -1)
			{
				token += this.chars[this.currentPos];
				//the last one is not a delimiter
				if (++this.currentPos == this.chars.Length)
					break;
			}
			return token;
		}
		#endregion
		#region HasMoreTokens()
		/// <summary>
		/// Determines if there are more tokens to return from the source string
		/// </summary>
		/// <returns>True or false, depending if there are more tokens</returns>
		public bool HasMoreTokens()
		{
			//keeping the current pos
			long pos = this.currentPos;
			try
			{
				this.NextToken();
			}
			catch (ArgumentOutOfRangeException)
			{
				return false;
			}
			this.currentPos = pos;
			return true;
		}
		#endregion
		#region MoveNext()
		/// <summary>
		//  Performs the same action as HasMoreTokens.
		/// </summary>
		/// <returns>True or false, depending if there are more tokens</returns>
		public bool MoveNext()
		{
			return this.HasMoreTokens();
		}
		#endregion
		#region Reset()
		/// <summary>
		/// Does nothing.
		/// </summary>
		public void Reset()
		{
			;
		}
		#endregion

		#region Count
		/// <summary>
		/// Remaining tokens count
		/// </summary>
		public int Count
		{
			get
			{
				//keeping the current pos
				long pos = this.currentPos;
				int i = 0;

				try
				{
					while (true)
					{
						this.NextToken();
						i++;
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					this.currentPos = pos;
					return i;
				}
			}
		}
		#endregion
		#region Current
		/// <summary>
		///  Performs the same action as NextToken.
		/// </summary>
		public object Current
		{
			get { return this.NextToken(); }
		}
		#endregion
	}
	#endregion

	#region Class - HashSetSupport
	/// <summary>
	/// SupportClass for the HashSet class.
	/// </summary>
	public class HashSetSupport : ArrayList, ISetSupport
	{
		public HashSetSupport()
			: base()
		{
		}

		public HashSetSupport(ICollection c)
		{
			this.AddAll(c);
		}

		public HashSetSupport(int capacity)
			: base(capacity)
		{
		}

		/// <summary>
		/// Adds a new element to the ArrayList if it is not already present.
		/// </summary>
		/// <param name="obj">Element to insert to the ArrayList.</param>
		/// <returns>Returns true if the new element was inserted, false otherwise.</returns>
		new public virtual bool Add(object obj)
		{
			bool inserted = this.Contains(obj);
			if (!inserted)
			{
				base.Add(obj);
			}
			return !inserted;
		}

		/// <summary>
		/// Adds all the elements of the specified collection that are not present to the list.
		/// </summary>
		/// <param name="c">Collection where the new elements will be added</param>
		/// <returns>Returns true if at least one element was added, false otherwise.</returns>
		public bool AddAll(ICollection c)
		{
			IEnumerator e = new ArrayList(c).GetEnumerator();
			bool added = false;

			while (e.MoveNext() == true)
			{
				if (this.Add(e.Current) == true)
					added = true;
			}
			return added;
		}

		/// <summary>
		/// Returns a copy of the HashSet instance.
		/// </summary>		
		/// <returns>Returns a shallow copy of the current HashSet.</returns>
		public override object Clone()
		{
			return base.MemberwiseClone();
		}
	}
	#endregion

	#region Class - ICollectionSupport
	/// <summary>
	/// This class provides functionality not found in .NET collection-related interfaces.
	/// </summary>
	public class ICollectionSupport
	{
		/// <summary>
		/// Adds a new element to the specified collection.
		/// </summary>
		/// <param name="c">Collection where the new element will be added.</param>
		/// <param name="obj">Object to add.</param>
		/// <returns>true</returns>
		public static bool Add(ICollection c, object obj)
		{
			bool added = false;
			//Reflection. Invoke either the "add" or "Add" method.
			MethodInfo method;
			try
			{
				//Get the "add" method for proprietary classes
				method = c.GetType().GetMethod("Add");
				if (method == null)
					method = c.GetType().GetMethod("add");
				int index = (int)method.Invoke(c, new object[] { obj });
				if (index >= 0)
					added = true;
			}
			catch (Exception e)
			{
				throw e;
			}
			return added;
		}

		/// <summary>
		/// Adds all of the elements of the "c" collection to the "target" collection.
		/// </summary>
		/// <param name="target">Collection where the new elements will be added.</param>
		/// <param name="c">Collection whose elements will be added.</param>
		/// <returns>Returns true if at least one element was added, false otherwise.</returns>
		public static bool AddAll(ICollection target, ICollection c)
		{
			IEnumerator e = new ArrayList(c).GetEnumerator();
			bool added = false;

			//Reflection. Invoke "addAll" method for proprietary classes
			MethodInfo method;
			try
			{
				method = target.GetType().GetMethod("addAll");

				if (method != null)
					added = (bool)method.Invoke(target, new object[] { c });
				else
				{
					method = target.GetType().GetMethod("Add");
					while (e.MoveNext() == true)
					{
						bool tempBAdded = (int)method.Invoke(target, new object[] { e.Current }) >= 0;
						added = added ? added : tempBAdded;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return added;
		}

		/// <summary>
		/// Removes all the elements from the collection.
		/// </summary>
		/// <param name="c">The collection to remove elements.</param>
		public static void Clear(ICollection c)
		{
			//Reflection. Invoke "Clear" method or "clear" method for proprietary classes
			MethodInfo method;
			try
			{
				method = c.GetType().GetMethod("Clear");

				if (method == null)
					method = c.GetType().GetMethod("clear");

				method.Invoke(c, new object[] { });
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// Determines whether the collection contains the specified element.
		/// </summary>
		/// <param name="c">The collection to check.</param>
		/// <param name="obj">The object to locate in the collection.</param>
		/// <returns>true if the element is in the collection.</returns>
		public static bool Contains(ICollection c, object obj)
		{
			bool contains = false;

			//Reflection. Invoke "contains" method for proprietary classes
			MethodInfo method;
			try
			{
				method = c.GetType().GetMethod("Contains");

				if (method == null)
					method = c.GetType().GetMethod("contains");

				contains = (bool)method.Invoke(c, new object[] { obj });
			}
			catch (Exception e)
			{
				throw e;
			}

			return contains;
		}

		/// <summary>
		/// Determines whether the collection contains all the elements in the specified collection.
		/// </summary>
		/// <param name="target">The collection to check.</param>
		/// <param name="c">Collection whose elements would be checked for containment.</param>
		/// <returns>true id the target collection contains all the elements of the specified collection.</returns>
		public static bool ContainsAll(ICollection target, ICollection c)
		{
			IEnumerator e = c.GetEnumerator();

			bool contains = false;

			//Reflection. Invoke "containsAll" method for proprietary classes or "Contains" method for each element in the collection
			MethodInfo method;
			try
			{
				method = target.GetType().GetMethod("containsAll");

				if (method != null)
					contains = (bool)method.Invoke(target, new Object[] { c });
				else
				{
					method = target.GetType().GetMethod("Contains");
					while (e.MoveNext() == true)
					{
						if ((contains = (bool)method.Invoke(target, new Object[] { e.Current })) == false)
							break;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return contains;
		}

		/// <summary>
		/// Removes the specified element from the collection.
		/// </summary>
		/// <param name="c">The collection where the element will be removed.</param>
		/// <param name="obj">The element to remove from the collection.</param>
		public static bool Remove(ICollection c, object obj)
		{
			bool changed = false;

			//Reflection. Invoke "remove" method for proprietary classes or "Remove" method
			MethodInfo method;
			try
			{
				method = c.GetType().GetMethod("remove");

				if (method != null)
					method.Invoke(c, new object[] { obj });
				else
				{
					method = c.GetType().GetMethod("Contains");
					changed = (bool)method.Invoke(c, new object[] { obj });
					method = c.GetType().GetMethod("Remove");
					method.Invoke(c, new object[] { obj });
				}
			}
			catch (Exception e)
			{
				throw e;
			}

			return changed;
		}

		/// <summary>
		/// Removes all the elements from the specified collection that are contained in the target collection.
		/// </summary>
		/// <param name="target">Collection where the elements will be removed.</param>
		/// <param name="c">Elements to remove from the target collection.</param>
		/// <returns>true</returns>
		public static bool RemoveAll(ICollection target, ICollection c)
		{
			ArrayList al = ToArrayList(c);
			IEnumerator e = al.GetEnumerator();

			//Reflection. Invoke "removeAll" method for proprietary classes or "Remove" for each element in the collection
			MethodInfo method;
			try
			{
				method = target.GetType().GetMethod("removeAll");

				if (method != null)
					method.Invoke(target, new object[] { al });
				else
				{
					method = target.GetType().GetMethod("Remove");
					MethodInfo methodContains = target.GetType().GetMethod("Contains");

					while (e.MoveNext() == true)
					{
						while ((bool)methodContains.Invoke(target, new object[] { e.Current }) == true)
							method.Invoke(target, new object[] { e.Current });
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return true;
		}

		/// <summary>
		/// Retains the elements in the target collection that are contained in the specified collection
		/// </summary>
		/// <param name="target">Collection where the elements will be removed.</param>
		/// <param name="c">Elements to be retained in the target collection.</param>
		/// <returns>true</returns>
		public static bool RetainAll(ICollection target, ICollection c)
		{
			IEnumerator e = new ArrayList(target).GetEnumerator();
			ArrayList al = new ArrayList(c);

			//Reflection. Invoke "retainAll" method for proprietary classes or "Remove" for each element in the collection
			MethodInfo method;
			try
			{
				method = c.GetType().GetMethod("retainAll");

				if (method != null)
					method.Invoke(target, new object[] { c });
				else
				{
					method = c.GetType().GetMethod("Remove");

					while (e.MoveNext() == true)
					{
						if (al.Contains(e.Current) == false)
							method.Invoke(target, new object[] { e.Current });
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return true;
		}

		/// <summary>
		/// Returns an array containing all the elements of the collection.
		/// </summary>
		/// <returns>The array containing all the elements of the collection.</returns>
		public static object[] ToArray(ICollection c)
		{
			int index = 0;
			object[] objects = new object[c.Count];
			IEnumerator e = c.GetEnumerator();
			while (e.MoveNext())
				objects[index++] = e.Current;
			return objects;
		}

		/// <summary>
		/// Obtains an array containing all the elements of the collection.
		/// </summary>
		/// <param name="objects">The array into which the elements of the collection will be stored.</param>
		/// <returns>The array containing all the elements of the collection.</returns>
		public static object[] ToArray(ICollection c, object[] objects)
		{
			int index = 0;

			Type type = objects.GetType().GetElementType();
			object[] objs = (object[])Array.CreateInstance(type, c.Count);

			IEnumerator e = c.GetEnumerator();

			while (e.MoveNext())
				objs[index++] = e.Current;

			//If objects is smaller than c then do not return the new array in the parameter
			if (objects.Length >= c.Count)
				objs.CopyTo(objects, 0);

			return objs;
		}

		/// <summary>
		/// Converts an ICollection instance to an ArrayList instance.
		/// </summary>
		/// <param name="c">The ICollection instance to be converted.</param>
		/// <returns>An ArrayList instance in which its elements are the elements of the ICollection instance.</returns>
		public static ArrayList ToArrayList(ICollection c)
		{
			ArrayList tempArrayList = new ArrayList();
			IEnumerator tempEnumerator = c.GetEnumerator();
			while (tempEnumerator.MoveNext())
				tempArrayList.Add(tempEnumerator.Current);
			return tempArrayList;
		}
		#region ParseVariables(...)
		/// <summary>
		/// Parse variable(s) string to dictionary.
		/// </summary>
		/// <param name="dictionary"></param>
		/// <param name="variables">variable(a) string</param>
		/// <param name="delim">variable pairs delimiter</param>
		/// <returns></returns>
		public static IDictionary ParseVariables(IDictionary dictionary, string variables, string delim)
		{
			if (dictionary == null)
				dictionary = new Hashtable();
			else
				dictionary.Clear();
			if (variables == null || variables.Length == 0)
				return dictionary;
			string[] vars = variables.Split(delim.ToCharArray());
			int idx;
			string vname, vval;
			foreach (string var in vars)
			{
				idx = var.IndexOf('=');
				if (idx > 0)
				{
					vname = var.Substring(0, idx);
					vval = var.Substring(idx + 1);
				}
				else
				{
					vname = var;
					vval = "";
				}
				dictionary.Add(vname, vval);
			}
			return dictionary;
		}
		#endregion
		#region JoinVariables(IDictionary dictionary, string delim)
		/// <summary>
		/// Join variables dictionary to string.
		/// </summary>
		/// <param name="dictionary"></param>
		/// <param name="delim"></param>
		/// <returns></returns>
		public static string JoinVariables(IDictionary dictionary, string delim)
		{
			StringBuilder sb = new StringBuilder();
			foreach (DictionaryEntry var in dictionary)
			{
				if (sb.Length > 0)
					sb.Append("|");
				sb.Append(var.Key);
				sb.Append("=");
				sb.Append(var.Value);
			}
			return sb.ToString();
		}
		#endregion
	}
	#endregion

	#region Interface ISetSupport
	/// <summary>
	/// Represents a collection ob objects that contains no duplicate elements.
	/// </summary>	
	public interface ISetSupport : ICollection, IList
	{
		/// <summary>
		/// Adds a new element to the Collection if it is not already present.
		/// </summary>
		/// <param name="obj">The object to add to the collection.</param>
		/// <returns>Returns true if the object was added to the collection, otherwise false.</returns>
		new bool Add(object obj);

		/// <summary>
		/// Adds all the elements of the specified collection to the Set.
		/// </summary>
		/// <param name="c">Collection of objects to add.</param>
		/// <returns>true</returns>
		bool AddAll(ICollection c);
	}
	#endregion
}
