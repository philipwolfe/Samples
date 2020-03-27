/////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Description: Shows how to create and use custom attributes in C# and C++
//
/////////////////////////////////////////////////////////////////////

using System.Security.Permissions;

[System.AttributeUsageAttribute(System.AttributeTargets.Class|System.AttributeTargets.Struct, AllowMultiple=true)]
public class Author : System.Attribute {
   public static void Main() {}
   public Author(string name) { this.name = name; version = (float) 1.0; }
   public Author(int name) {}
   public Author() {}
   public float version;
   private string name;
   public int[] rgnField;
   public double [] rgdField;
}

[System.Security.Permissions.PermissionSetAttribute(SecurityAction.Demand)]
[ABC(SomeStuff.e17)]
[ABC(1, rgdField=new double[2] {6, 1.2})]
[ABC, ABC("99"), ABC(1, rgnField=new int[2] {1, 2})]
[ABC, ABC("99"), Author(1, rgnField=new int[2] {1, 2})]
public class MYStuff {
}

