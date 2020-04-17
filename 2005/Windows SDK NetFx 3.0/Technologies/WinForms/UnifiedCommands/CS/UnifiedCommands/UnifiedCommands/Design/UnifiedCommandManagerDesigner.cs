//=-------------------------------------------------------------------=
// File:     UnifiedCommandManagerDesigner.cs
//
// Summary:  
//=-------------------------------------------------------------------=
// This file is part of the Microsoft SDK Sample Package.
//
// Copyright (C) Microsoft Corporation.  All rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//=====================================================================
//
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.UnifiedCommands.Design
{
    //=----------------------------------------------------------------------=
    // UnifiedCommandManagerDesigner
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This class supports some of the key operations of the 
    ///   UnifiedCommandManager object at design time, including giving the
    ///   the ability to add new commands, etc.
    /// </summary>
    public class UnifiedCommandManagerDesigner : ComponentDesigner
    {

        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                   Private Members/Data/Types/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        /// 
        /// <summary>
        ///   This is the set of verbs we support, of which there is
        ///   currently only one -- an "add command" verb.
        /// </summary>
        /// 
        private DesignerVerbCollection m_verbs;



        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //               Public Properties/Methods/Events/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=


        //=------------------------------------------------------------------=
        // UnifiedCommandManagerDesigner
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Constructor to initialise any data that requires such.
        /// </summary>
        /// 
        public UnifiedCommandManagerDesigner()
        {

        }


        //=------------------------------------------------------------------=
        // Verbs
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns the set of verbs available for this component.  There
        ///   is only one, which is an "Add" Command verb.
        /// </summary>
        /// 
        /// <value>
        ///   The collection of verbs to use.
        /// </value>
        /// 
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (this.m_verbs == null)
                {
                    DesignerVerb dv;
                    this.m_verbs = new DesignerVerbCollection();
                    dv = new DesignerVerb("Add", new EventHandler(OnAdd));
                    this.m_verbs.Add(dv);
                }

                return this.m_verbs;
            }
        }



        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //             Private Properties/Methods/Functions/Events...
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // OnAdd
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has selected the "Add Command" verb.  Go and do so
        ///   now.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   Where it comes from.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details about the event.
        /// </param>
        /// 
        private void OnAdd(object sender, EventArgs e)
        {
            DesignerTransaction dt = null;
            UnifiedCommandManager ucm;
            PropertyDescriptor pd;
            MemberDescriptor md;
            IDesignerHost idh;
            UnifiedCommand uc;

            ucm = this.Component as UnifiedCommandManager;
            md = TypeDescriptor.GetProperties(this.Component)["Commands"];
            idh = this.GetService(typeof(IDesignerHost)) as IDesignerHost;

            if (idh != null)
            {
                try
                {
					try
					{
						dt = idh.CreateTransaction("AddCommand");
						RaiseComponentChanging(md);
					}
					catch (Exception ex)
					{
						if (ex == CheckoutException.Canceled)
						{
							return;
						}

						throw ex;
					}

                    uc = (UnifiedCommand)idh.CreateComponent(typeof(UnifiedCommand));

                    pd = TypeDescriptor.GetProperties(uc)["Name"];
                    if (pd != null && pd.PropertyType == typeof(string))
                    {
                        uc.CommandName = (string)pd.GetValue(uc);
                    }

                    ucm.Commands.Add(uc);
                    RaiseComponentChanged(md, null, null);
                }
                finally
                {
                    if (dt != null)
                    {
                        dt.Commit();
                    }
                }
            }

        }


    }
}
