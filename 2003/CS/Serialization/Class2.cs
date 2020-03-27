//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
//This class is marked as Serializable. Additionally, this class implements
//ISerializable, which allows for custom Serialization. ISerializable requires
//implementation of the GetObjectData method, as well as an additional constructor
//that will be called on Deserialization.
//In this example, it will be serialized and deserialized to and from a file. 
//if using the Soap formatter, the file will be called Class1File.xml. if using 
//the Binary formatter, the file will be called Class1File.dat.
//See the Form_Load event of frmMain to change the file names.

using System;
using System.Runtime.Serialization; // Namespace for ISerializable

//This attribute makes the class serializable
[Serializable()] 
public class Class2: ISerializable
{
	//Because custom serialization is being used in this example, the NonSerialized
    //attribute is not enforced. Instead, the writer of the class determines what is
    //and isn't serialized, based on the GetObjectData method below. Note that in this
    //class, even though z is marked as NonSerialized, the field is serialized anyway.

	public int x;
    private int y;
    
	[NonSerialized()] public int z;

    //Simple constructor to load in values for the fields.

	public Class2(int argx, int argy, int argz)
	{
		this.x = argx;
		this.y = argy;
		this.z = argz;
	}

	//This is the special constructor called during 
	//deserialization. Note that both fields and custom
	//information (like a time stamp) can be serialized.
	public Class2(SerializationInfo info, StreamingContext context)
	{
		this.x = info.GetInt32("x");
		this.y = info.GetInt32("y");
		this.z = info.GetInt32("z");

		DateTime d = info.GetDateTime("TimeStamp");
	}

	//property to view the value of the private field y
	public int GetY
	{
		get {
			return y;
		}
	}

	//This method controls how the fields will be serialized
	//You can pass in current values (like x & z) or some other value 
	//(like y). You can also serialize other items, even if there are 
	//no fields that they represent (like 'TimeStamp').

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", this.x);
		info.AddValue("y", -1);
		info.AddValue("z", this.z);
		info.AddValue("TimeStamp", DateTime.Now);
	}
}

