/*+==========================================================================
  File:      MinMax.cs

  Summary:   Sample that uses IsolatedStorage. MinMax has a running Min value 
             and a Max value. These values are persisted on disk. The 
             application store is used to persist this information. Different
             stores will be open for different applications.
	
  Classes:   MinMax

  Functions: Min (get, set), Max (get, set), Reset, AddData
             
  Author:    Shajan Dasan (shajand@microsoft.com)

  Date:      21 July 2000

----------------------------------------------------------------------------
  This file is part of the Microsoft .NET Samples.

  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
==========================================================================+*/

using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace Sample
{
    public class MinMax
    {
        // Isolated Storage File names where data is stored
        const String c_MinFileName = "Min.dat";
        const String c_MaxFileName = "Max.dat";
    
        // The Isolated Store file streams for the application that 
        // instantiates MinMax 

        Stream m_MaxStream;
        Stream m_MinStream;
    
        public MinMax(String name)
        {
            // Implicit "get store for application that created this object"
            // Open FileStreams in the application store.
    
            m_MaxStream = new IsolatedStorageFileStream(name + c_MaxFileName,
                                FileMode.OpenOrCreate, FileAccess.ReadWrite, 
                                FileShare.ReadWrite);
    
            m_MinStream = new IsolatedStorageFileStream(name + c_MinFileName,
                                FileMode.OpenOrCreate, FileAccess.ReadWrite,
                                FileShare.ReadWrite);
        }
    
        public MinMax() : this("") { }
    
        // The current Max
    
        public int Max {
    
            get {
    
                return GetValue(m_MaxStream, Int32.MinValue);
            }
    
            set {
    
                SetValue(m_MaxStream, value);
            }
        }
    
        // The current Min
    
        public int Min {
    
            get {
    
                return GetValue(m_MinStream, Int32.MaxValue);
            }
    
            set {
    
                SetValue(m_MinStream, value);
            }
        }
    
        public void Reset()
        {
            this.Max = Int32.MinValue;
            this.Min = Int32.MaxValue;
        }

        public void AddData(int data)
        {
            if (data > this.Max)
                this.Max = data;
    
            if (data < this.Min)
                this.Min = data;
        }
    
        private static int GetValue(Stream s, int def)
        {
            // Get int value from the beginning of the stream.
            // return default on error.
    
            int value;
            BinaryReader reader;
    
            s.Seek(0, SeekOrigin.Begin);
    
            reader = new BinaryReader(s);
    
            try {
                value = reader.ReadInt32();
            } catch (Exception) {
                value = def;
            }
    
            return value;
        }
    
    
        private static void SetValue(Stream s, int value)
        {
            // Set int value to the beginning of the stream.
    
            BinaryWriter writer;
    
            s.Seek(0, SeekOrigin.Begin);
            writer = new BinaryWriter(s);
    
            writer.Write(value);
    
            writer.Flush();
        }
    
        protected override void Finalize()
        {
            m_MaxStream.Close();
            m_MinStream.Close();
        }
    }
}

