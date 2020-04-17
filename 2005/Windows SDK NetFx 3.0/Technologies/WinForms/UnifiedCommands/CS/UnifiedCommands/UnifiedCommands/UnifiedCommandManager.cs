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
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;


namespace Microsoft.Samples.Windows.Forms.UnifiedCommands
{
    //=----------------------------------------------------------------------=
    // UnifiedCommandManager
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This is the core UnifiedManager class.  It manages a collection of 
    ///   UnifiedCommand objects, and by using the IExtenderProvider 
    ///   interface, makes sure that all ToolStripItem-derived components on
    ///   the parent form get a "Command" property.
    /// </summary>
    /// 
    [Designer(typeof(Design.UnifiedCommandManagerDesigner))]
    [DefaultProperty("Commands")]
    [ProvideProperty("Command", typeof(ToolStripItem))]
    [ToolboxItemFilter("System.Windows.Forms")]
    public class UnifiedCommandManager : Component, IExtenderProvider
        
    {
        #region Private Members/Data Types/Constants.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                Private Members/Data Types/Constants.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        /// 
        /// <summary>
        ///   This is our collection of UnifiedCommand objects.  The 
        ///   individual objects manage their direct relationships with
        ///   items on the form for which they are ane extender.
        /// </summary>
        /// 
        protected UnifiedCommandCollection m_commands;

        #endregion // Private Members/Data Types/Constants.



        #region Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // UnifiedCommandManager
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initialises a new instance of this object, setting up some 
        ///   reasonable default values internally, etc.
        /// </summary>
        /// 
        public UnifiedCommandManager()
        {
            this.m_commands = new UnifiedCommandCollection(this);
        }


        //=------------------------------------------------------------------=
        // UnifiedCommandManager
        //=------------------------------------------------------------------=
        /// <summary>
        ///   An overloaded constructor for this component that adds us, if
        ///   necessary, to an optionally specified container.
        /// </summary>
        /// 
        /// <param name="container">
        ///   The container to which, if not null/Nothing, we should be
        ///   added.
        /// </param>
        ///
        public UnifiedCommandManager(IContainer container) : this()
        {
            if (container != null)
            {
                container.Add(this);
            }
        }


        //=------------------------------------------------------------------=
        // Commands
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This is our collection of UnifiedCommand objects.
        /// </summary>
        /// 
        /// <value>
        ///   A collection of UnifiedCommand objects.  Peopel should 
        ///   rarely have to modify or inspect this directly.  Instead, it
        ///   will mostly be used through extending ToolStripItem-derived
        ///   components on the host form.
        /// </value>
        /// 
        [LocalizableDescription("descUnifiedCommandsProp")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public UnifiedCommandCollection Commands
        {
            get
            {
                return this.m_commands;
            }
        }


        #region IExtenderProvider Members
        //=------------------------------------------------------------------=
        // CanExtend
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Given a component, asks us if the object is of a type for which
        ///   we are willing to proffer the "Command" property.  This is true
        ///   only for ToolStripItem classes and derivatives.
        /// </summary>
        /// 
        /// <param name="extendee">
        ///   The object for which an answer is sought.
        /// </param>
        /// 
        /// <returns>
        ///   A boolean indicating whether it can be extended by us (True) or
        ///   not (False).
        /// </returns>
        /// 
        public bool CanExtend(object extendee)
        {
            if (extendee is ToolStripItem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //=------------------------------------------------------------------=
        // SetCommand
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Asks us to set the proffered property (Command) on the given
        ///   component.  We, fortunately, pass all this on to the individual
        ///   UnifiedCommand object, which remembers all relationships, etc.
        /// </summary>
        /// 
        /// <param name="tsi">
        ///   The item for which the Command property is to be set.
        /// </param>
        /// 
        /// <param name="uc">
        ///   The UnifiedCommand for the property value.
        /// </param>
        /// 
        public void SetCommand(ToolStripItem tsi, UnifiedCommand uc)
        {
            //
            // if they want to dissociate this item from any commands,
            // then go and do so now.
            //
            if (uc == null)
            {
                for (int x = 0; x < this.m_commands.Count; x++)
                {
                    if (this.m_commands[x].ContainsToolStripItem(tsi))
                    {
                        this.m_commands[x].RemoveToolStripItem(tsi);
                    }
                }
            }
            else
            {
                //
                // otherwise, if they gave us a valid command for which we
                // are responsible, then go and make the association now.
                //
                uc.AddToolStripItem(tsi);
            }
        }


        //=------------------------------------------------------------------=
        // GetCommand
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Asks us to return the UnifiedCommand value for the profferred
        ///   Command property on the given ToolStripItem
        /// </summary>
        /// 
        /// <param name="tsi">
        ///   The item whose Command property value we wish to obtain.
        /// </param>
        /// 
        /// <returns>
        ///   The Command property value for the given item.
        /// </returns>
        /// 
        [Description("descExtendCommandProp")]
        public UnifiedCommand GetCommand(ToolStripItem tsi)
        {
            return findCommandForStripItem(tsi);
        }

        #endregion // IExtenderProvider Members

        #endregion // Public Methods/Properties/etc.








        #region Namespace-Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Namespace-Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // OnCommandAdded
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The specified UnifiedCommand object has been added to our
        ///   collection of UnifiedCommands.  We'll go and hook up all the
        ///   relevant information for it now.
        /// </summary>
        /// 
        /// <param name="command">
        ///   The command being added.
        /// </param>
        /// 
        protected internal void OnCommandAdded(UnifiedCommand command)
        {
        }


        //=------------------------------------------------------------------=
        // OnCommandRemoved
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The specified UnifiedCommand object has been removed from our
        ///   collection of commands.  We'll go and delete any information
        ///   we have for it.
        /// </summary>
        /// 
        /// <param name="command">
        ///   The command that is being deleted.
        /// </param>
        /// 
        protected internal void OnCommandRemoved(UnifiedCommand command)
        {
        }

        #endregion // Namespace-Public Methods/Properties/etc.






        #region Non-Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Non-Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // findCommandForStripItem
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Asks us to locate, in our collection of UnifiedCommand objects,
        ///   the command that is associated with the given component, or
        ///   just returns a null/Nothing pointer if none currently is.
        /// </summary>
        /// 
        /// <param name="tsi">
        ///   The item whose Command property value is being sought.
        /// </param>
        /// 
        /// <returns>
        ///   The Command property value for the given item, or null/Nothing
        ///   in the case where it isn't set.
        /// </returns>
        /// 
        protected UnifiedCommand findCommandForStripItem(ToolStripItem tsi)
        {
            for (int x = 0; x < this.m_commands.Count; x++)
            {
                if (this.m_commands[x].ContainsToolStripItem(tsi))
                {
                    return this.m_commands[x];
                }
            }

            return null;
        }

        #endregion // Non-Public Methods/Properties/etc.
    }
}
