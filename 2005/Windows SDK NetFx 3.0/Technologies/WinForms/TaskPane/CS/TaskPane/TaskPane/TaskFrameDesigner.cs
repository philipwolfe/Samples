//=====================================================================
//  File:      TaskFrameDesigner.cs
//
//  Summary:   This class provides a majority of the design time 
//             functionality seen and needed in our TaskFrame class
//             in the IDE.
//
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

using System.Windows.Forms.Design;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Reflection;
using System;

namespace Microsoft.Samples.Windows.Forms.TaskPane.Design
{
    //=------------------------------------------------------------------=
    // TaskFrameDesigner
    //=------------------------------------------------------------------=
    /// <summary>
    /// This class will provide most of the interesting design time 
    /// functionality for this control.
    /// </summary>
    /// 
    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
    public class TaskFrameDesigner : ScrollableControlDesigner
    {

        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        // Private member variables and the likes
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        ///
        /// <summary>
        /// shadowed visible property
        /// </summary>
        ///
        private bool m_visible;

        ///
        /// <summary>
        /// Shadowed Isexpanded property
        /// </summary>
        ///
        private bool m_IsExpanded;






        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                    Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // Constructor
        //=------------------------------------------------------------------=
        /// <summary>
        /// Initializes an instance of this class for use.
        /// </summary>
        ///
        public TaskFrameDesigner() : base()
        {            
            this.m_IsExpanded = true;
            this.m_visible = true;
        }





        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                Private/Protected/Friend Subs/Functions
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // Visible
        //=------------------------------------------------------------------=
        /// <summary>
        /// Shadows property which we will let users set and persist at design,
        /// but we don't actually want it happening until runtime!
        /// </summary>
        ///
        private bool Visible        
        {
            get
            {
                return this.m_visible;
            }

            set
            {
                this.m_visible = value;
            }
        }


        //=------------------------------------------------------------------=
        // IsExpanded
        //=------------------------------------------------------------------=
        /// <summary>
        /// Shadowed property which will let users set and persist this for
        /// proper use at runtime ...
        /// </summary>
        /// 
        private bool IsExpanded        
        {
            get
            {
                return this.m_IsExpanded;
            }

            set
            {
                this.m_IsExpanded = value;
            }
        }

        //=------------------------------------------------------------------=
        // CanBeParentedTo
        //=------------------------------------------------------------------=
        /// <summary>
        ///   To what type of object can we be parented?  Only TaskPanes.
        /// </summary>
        /// 
        public override bool CanBeParentedTo(IDesigner in_parentDesigner)
        {
            if ((in_parentDesigner) is TaskPaneDesigner)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //=------------------------------------------------------------------=
        // SelectionRules
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We cannot be resized.
        /// </summary>
        /// 
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules sr;
                Control ctl;

                sr = base.SelectionRules;
                ctl = Control;

                if ((ctl.Parent) is TaskPane)
                {
                    sr = sr & (~SelectionRules.AllSizeable);
                }

                return sr;
            }
        }


        //=------------------------------------------------------------------=
        // PreFilterProperties
        //=------------------------------------------------------------------=
        /// <summary>
        /// We want to "Shadow" a few properties, most notably:
        ///
        /// - IsExpanded
        /// - Visible
        ///
        /// This stuff is incredibly complicated.
        /// </summary>
        /// 
        protected override void PreFilterProperties(IDictionary in_properties)
        {
            PropertyDescriptor propDesc;
            string[] shadowProps;
            Attribute[] empty;

            shadowProps = new string[]{"Visible", "IsExpanded"};

            empty = new Attribute[]{};

            for(int x=0; x<shadowProps.Length; x++)
            {

                propDesc = (PropertyDescriptor) in_properties[shadowProps[x]];
                if (propDesc != null)
                {
                    in_properties[shadowProps[x]] = TypeDescriptor.CreateProperty(
                        typeof(TaskFrameDesigner), propDesc, empty);
                }
            }
        }
    
    }

}

