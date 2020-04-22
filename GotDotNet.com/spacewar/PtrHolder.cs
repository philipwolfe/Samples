using System;
using System.Runtime.InteropServices;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for PtrHolder.
	/// </summary>
	public unsafe class PtrHolder
	{
		void* p;

		public void* Ptr
		{
			get
			{
				return p;
			}
			set
			{
				p = value;
			}
		}

		public PtrHolder(void* p)
		{
			this.p = p;
		}

		public int ReadInt()
		{
			int* pInt = (int*) p;
			int ret = *pInt;
			pInt++;
			p = pInt;
			return ret;
		}

		public void WriteInt(int value)
		{
			int* pInt = (int*) p;
			*pInt = value;
			pInt++;
			p = pInt;
		}

		public string ReadString()
		{
			int len = ReadInt();

			char* pC = (char*) p;
			string ret = new String(pC);
			pC += (ret.Length + 1);	// move past string & terminator
			p = pC;

			return ret;
		}

		public void WriteString(string s)
		{
			WriteInt(s.Length);
			char* pDest = (char*) p;
			fixed (char* pString = s)
			{
				char* pSource = pString;
				for (int i = 0; i < s.Length + 1; i++)
				{
					*pDest = *pSource;
					pDest++;
					pSource++;
				}
			}
			p = pDest;
		}
	}
}
