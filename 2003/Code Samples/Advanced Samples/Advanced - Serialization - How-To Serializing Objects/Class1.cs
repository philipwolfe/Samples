//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
//This class is marked as Serializable. In this example, it will be
//serialized and deserialized to and from a file. if using the Soap
//formatter, the file will be called Class1File.xml. if using the  
//Binary formatter, the file will be called Class1File.dat.
//See the Form_Load event of frmMain to change the file names.
//This attribute makes the class serializable

using System;

[Serializable()] 
public class Class1 
{
	//All fields in this class will be serialized, regardless of scope, 
	//unless they are specifically marked as NonSerialized, like z.

	public int x;
	private int y;

	[NonSerialized()] public int z;

	//Simple constructor to load in values for the fields.
	public Class1(int argx, int argy, int argz)
	{
		this.x = argx;
		this.y = argy;
		this.z = argz;
	}

	//property to view the value of the private field y
	public int GetY
	{
		get {
			return y;
		}
	}
}