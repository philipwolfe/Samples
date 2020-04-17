//---------------------------------------------------------------------
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
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Microsoft.Samples.Windows.Forms.UnifiedCommands
{
    //=----------------------------------------------------------------------=
    // UnifiedCommandCollection 
    //=----------------------------------------------------------------------=
    ///   We use Generic collection to do most of the work, but we need
    ///   some simple notifications here, so we subclass it to do those. 
    ///   We also implement a useful "AddRange" method.
    public class UnifiedCommandCollection : Collection<UnifiedCommand>
    {
        #region Private Members/Data Types/Constants.
        //=------------------------------------------------------------------=
        //                Private Members/Data Types/Constants.
        //=------------------------------------------------------------------=

		/// Our parent UnifiedCommandManager.  
		/// This is so we can tell them about additions and removals.
        private UnifiedCommandManager m_parent;

        #endregion // Private Members/Data Types/Constants.


        #region Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //              Public Methods/Properties/etc.
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // UnifiedCommandCollection
        //=------------------------------------------------------------------=
        ///   Initializes a new instance of this class, making sure that
        ///   our parent is properly set.
        public UnifiedCommandCollection(UnifiedCommandManager parent)
        {
			if (parent == null)
			{
				throw (new ArgumentNullException());
			}
					
			this.m_parent = parent;
        }

        //=------------------------------------------------------------------=
        // AddRange
        //=------------------------------------------------------------------=
        ///   By Default, the Generic collections don't provide an AddRange,
        ///   but it's such a useful method we're going to add one ourselves.
        public void AddRange(UnifiedCommand[] commands)
        {
            if (commands != null)
            {
                for (int x = 0; x < commands.Length; x++)
                {
                    this.Add(commands[x]);
                }
            }
        }

        #endregion // Public Methods/Properties/etc.

        #region Non-Public Methods/Functions/Properties
        //=------------------------------------------------------------------=
        //              Non-Public Methods/Functions/Properties
        //=------------------------------------------------------------------=


		//=------------------------------------------------------------------=
        // ClearItems
        //=------------------------------------------------------------------=
		protected override void ClearItems()
		{
			while (this.Items.Count > 0)
			{
				this.RemoveItem(0);
			}
		}

        //=------------------------------------------------------------------=
        // InsertItem
        //=------------------------------------------------------------------=
        ///   The given item is being inserted into the list at the given
        ///   index.
        protected override void InsertItem(int index, UnifiedCommand item)
        {
            base.InsertItem(index, item);
            this.m_parent.OnCommandAdded(item);
        }

        //=------------------------------------------------------------------=
        // SetItem
        //=------------------------------------------------------------------=
        ///   The item at the specified index will be replaced with the 
        ///   specified new item.
        protected override void SetItem(int index, UnifiedCommand item)
        {
            this.m_parent.OnCommandRemoved(this[index]);
            base.SetItem(index, item);
            this.m_parent.OnCommandAdded(item);
        }

        //=------------------------------------------------------------------=
        // RemoveItem
        //=------------------------------------------------------------------=
        ///   The item at the specified index is to be removed from the
        ///   collection.
        protected override void RemoveItem(int index)
        {
            this.m_parent.OnCommandRemoved(this[index]);
            base.RemoveItem(index);
        }

        #endregion // Non-Public Methods/Functions/Properties
    }
}