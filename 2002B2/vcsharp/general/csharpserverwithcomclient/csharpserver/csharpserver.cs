//  (c)2000 Microsoft Corporation
//
//  Build this part of the sample with the following commands:
//
//	csc /target:library CSharpServer.cs
//  regasm CSharpServer.dll /tlb:CSharpServer.TLB
//

using System;
using System.Runtime.InteropServices;

namespace CSharpServer
{
	//Since the .NET interface and coclass have to behave as COM objects,
	//we have to give them guids
	[Guid("DBE0E8C4-1C61-41f3-B6A4-4E2F353D3D05")]
	public interface IManagedInterface
	{
		
		int PrintHi(string name);
	}// interface IManagedInterface



	[Guid("C6659361-1625-4746-931C-36014B146679")]
	public class InterfaceImplementation : IManagedInterface
	{
		public int PrintHi(string name)
		{
			Console.WriteLine("Hello, {0}!", name);
			return 33;
		}
	}// class InterfaceImplementation

}


