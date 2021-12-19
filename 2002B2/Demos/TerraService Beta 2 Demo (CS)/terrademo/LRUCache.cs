// Copyright (C) Microsoft Corporation.  All Rights Reserved.
// LRUCache.cs

using System;	

	public class LRUCache 
	{
		Object[] cache;
		Int32 size, pos = -1;
		public LRUCache(Int32 size) 
		{
			cache = new Object[size];
			this.size = size;
		}
		public void Add(Object o) 
		{
			cache[(++pos % size)] = o;
		}
	}