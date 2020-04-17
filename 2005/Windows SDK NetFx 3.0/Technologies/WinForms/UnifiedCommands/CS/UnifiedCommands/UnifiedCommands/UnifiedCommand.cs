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
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text.RegularExpressions;

namespace Microsoft.Samples.Windows.Forms.UnifiedCommands
{
    //=----------------------------------------------------------------------=
    // UnifiedCommand
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This is an individual command with which the UnifiedCommandManager
    ///   works.  Items have their (IExtenderProvider provided) Command
    ///   property set to one of these.
    /// </summary>
    /// 
    [ToolboxItem(false)]
    [DefaultProperty("CommandName")]
    [DefaultEvent("Execute")]
    [Browsable(true)]
    [DesignTimeVisible(false)]
    public class UnifiedCommand : Component
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
        ///   User friendly display name for the command.
        /// </summary>
        /// 
        private string m_commandName;

        /// 
        /// <summary>
        ///   User friendly description for the command
        /// </summary>
        /// 
        private string m_commandDescription;


        ///
        /// <summary>
        ///   This is the collection of ToolStripItems with which this 
        ///   particular command is associated.
        /// </summary>
        /// 
        private ArrayList m_associations;

        /// 
        /// <summary>
        ///   We will change some other items' enable values in our
        ///   EnabledChanged handler, so we have to use a flag to prevent
        ///   re-entry.
        /// </summary>
        /// 
        private bool m_inEnabledChanged;

        /// 
        /// <summary>
        ///   We will change some other items' visible values in our
        ///   VisibleChanged handler, so we have to use a flag to prevent
        ///   re-entry.
        /// </summary>
        /// 
        private bool m_inVisibleChanged;

        /// 
        /// <summary>
        ///   We will change some other items' checkstate values in our
        ///   CheckedChanged handler, so we have to use a flag to prevent
        ///   re-entry.
        /// </summary>
        /// 
        private bool m_inCheckedChanged;

        /// 
        /// <summary>
        ///   Are we in the middle of tracking a SelectedIndex change in
        ///   a ToolStripComboBox?
        /// </summary>
        /// 
        private bool m_inSelectedItemChanging;

        /// 
        /// <summary>
        ///   Controls whether the items for which we are responsible are
        ///   enabled or not.
        /// </summary>
        /// 
        private bool m_enabled;

        /// 
        /// <summary>
        ///   Controls whether the items for which we are responsible are
        ///   visible or not.
        /// </summary>
        /// 
        private bool m_visible;

        /// 
        /// <summary>
        ///   Indicates and controls the current value of the CheckState 
        ///   property on the items for which we are repsonsible.
        /// </summary>
        /// 
        private CheckState m_checkState;

        /// 
        /// <summary>
        ///   If one of our items is a ToolStripMenuItem with child items,
        ///   or it's a ToolStripComboBox, then we'll also try to track
        ///   the selection of sub-items between them.
        /// </summary>
        /// 
        private string m_subItemSelected;


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
        // UnifiedCommand
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initialises a new instance of this class.
        /// </summary>
        /// 
        public UnifiedCommand()
        {
            this.m_commandName = null;
            this.m_commandDescription = null;

            this.m_associations = new ArrayList();

            this.m_inEnabledChanged = false;
            this.m_inVisibleChanged = false;
            this.m_inCheckedChanged = false;
            this.m_inSelectedItemChanging = false;

            this.m_enabled = true;
            this.m_visible = true;
            this.m_checkState = CheckState.Unchecked;
        }


        //=------------------------------------------------------------------=
        // UnifiedCommand
        //=------------------------------------------------------------------=
        /// <summary>
        ///   An overloaded version of our constructor that adds us, if 
        ///   appropriate, to an optionally specified container object.
        /// </summary>
        /// 
        /// <param name="container">
        ///   Optionally specified container to which we should add ourselves.
        /// </param>
        /// 
        public UnifiedCommand(IContainer container) : this()
        {
            if (container != null)
            {
                container.Add(this);
            }
        }


        //=------------------------------------------------------------------=
        // CommandName
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user friendly name for this command, such as "Open Document"
        /// </summary>
        /// 
        /// <value>
        ///   A string value showing the user friendly name for this command.
        ///   This value should be localized.
        /// </value>
        /// 
        [LocalizableDescription("descCommandNameProp")]
        [Localizable(true)]
        public string CommandName
        {
            get
            {
                return this.m_commandName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.m_commandName = value;
            }
        }


        //=------------------------------------------------------------------=
        // CommandDescription
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user friendly description for this command, such as "Shows
        ///   a dialog so you can open an existing Document for editing."
        /// </summary>
        /// 
        /// <value>
        ///   A string value showing the user friendly description for this
        ///   command.  This value should be localized.
        /// </value>
        /// 
        [LocalizableDescription("descCommandDescriptionProp")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string CommandDescription
        {
            get
            {
                return this.m_commandDescription;
            }

            set
            {
                this.m_commandDescription = value;
            }
        }


        //=------------------------------------------------------------------=
        // Enabled
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Controls/reflects whether all the items associated with us are
        ///   enabled or not.  Changing this affects <em>all</em> items
        ///   associated with us.
        /// </summary>
        /// 
        /// <value>
        ///   A boolean indicating whether the items associated with us are
        ///   Enabled or not.
        /// </value>
        /// 
        [Browsable(false)]
        [DefaultValue(true)]
        public bool Enabled
        {
            get
            {
                return this.m_enabled;
            }

            set
            {
                setEnabledValue(value, null);
            }
        }


        //=------------------------------------------------------------------=
        // Visible
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Controls/reflects whether all the items associated with us are
        ///   visible or not.  Changing this affects <em>all</em> items
        ///   associated with us.
        /// </summary>
        /// 
        /// <value>
        ///   A boolean indicating whether the items associated with us are
        ///   Visible or not.
        /// </value>
        /// 
        [Browsable(false)]
        [DefaultValue(true)]
        public bool Visible
        {
            get
            {
                return this.m_visible;
            }

            set
            {
                setVisibleValue(value, null);
            }
        }


        //=------------------------------------------------------------------=
        // CheckState
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Controls/reflects what all the items associated with us have
        ///   for their CheckState property value.  Changing this affects 
        ///   <em>all</em> items associated with us.
        /// </summary>
        /// 
        /// <value>
        ///   The current CheckState value for all associated items.
        /// </value>
        /// 
        [Browsable(false)]
        [DefaultValue(CheckState.Unchecked)]
        public CheckState CheckState
        {
            get
            {
                return this.m_checkState;
            }

            set
            {
                setCheckStateValue(value, null);
            }
        }


        //=------------------------------------------------------------------=
        // SubItemSelected
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Controls which sub-item of us is selected.  This only makes 
        ///   sense for menu-items with sub-menus or ToolStripComboBoxes.  
        ///   For the former, the sub-item with the given text is selected
        ///   while, for the latter, the given item in the combo is selected.
        /// </summary>
        /// 
        /// <value>
        ///   The sub item selected or to be selected.  If the given item 
        ///   doesn't exist, then the value is ignored for the given
        ///   associated item.
        /// </value>
        /// 
        [DefaultValue(null)]
        public string SubItemSelected
        {
            get
            {
                return this.m_subItemSelected;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                setSubItemSelected(value, null);
            }
        }


        //=------------------------------------------------------------------=
        // ExecuteNow
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This causes this command to go through the sequence of events
        ///   that would have otherwise happened had the user clicked on an
        ///   associated ToolStripMenuItem or ToolStripButton, etc.  The
        ///   end result is that the Execute event is raised.
        /// </summary>
        /// 
        [LocalizableDescription("descExecuteNowMethod")]
        public void ExecuteNow()
        {
            OnExecute();
        }


        //=------------------------------------------------------------------=
        // Execute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This event is fired whenever the user clicks on the associated
        ///   strip item associated with this command.  It can also be fired
        ///   manually by calling the ExecuteNow() method.
        /// </summary>
        /// 
        [LocalizableDescription("descExecuteEvent")]
        public event EventHandler Execute;

        #endregion // Public Methods/Properties/etc.









        #region Namespace-Public Methods/Functions/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Namespace-Public Methods/Functions/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // AddToolStripItem
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The given ToolStripItem has had us set to their Command
        ///   property, so we need to go and hook everything up now so that
        ///   we can correctly manage it.
        /// </summary>
        /// 
        /// <param name="tsi">
        ///   The item to associate with us.
        /// </param>
        /// 
        protected internal void AddToolStripItem(ToolStripItem tsi)
        {
            if (this.m_associations.Contains(tsi))
            {
                throw new AlreadyAssociatedException();
            }

            this.m_associations.Add(tsi);

            //
            // hook up to some events on the component so that we can track
            // changes and clicks, and update other components as appropriate.
            //
            tsi.Click += new EventHandler(OnItemClick);
            tsi.EnabledChanged += new EventHandler(OnItemEnableChanged);
            tsi.VisibleChanged += new EventHandler(OnItemVisibleChanged);

            //
            // this last event is a bit complicated -- it only applies to a
            // few possible types of items, but we -definitely- want this
            // functionality.
            //
            if (tsi is ToolStripButton)
            {
                (tsi as ToolStripButton).CheckedChanged
                        += new EventHandler(OnItemCheckedChanged);
            }
            else if (tsi is ToolStripMenuItem)
            {
                ToolStripMenuItem tsmi;
                tsmi = tsi as ToolStripMenuItem;

                tsmi.CheckedChanged += new EventHandler(OnItemCheckedChanged);
                tsmi.DropDownItemClicked +=
                    new ToolStripItemClickedEventHandler(
                                OnItemDropDownItemClicked);
            }
            else if (tsi is ToolStripComboBox)
            {
                ToolStripComboBox tscb;
                tscb = (tsi as ToolStripComboBox);

                tscb.SelectedIndexChanged +=
                    new EventHandler(OnItemSelectedIndexChanged);
            }

        }


        //=------------------------------------------------------------------=
        // RemoveToolStripItem
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Asks us to dissociate ourselves from the given ToolStripItem.
        ///   We will unhook all events and otherwise move on.  We can handle
        ///   the rejection.  It's okay, really.  We're fine.
        /// </summary>
        /// 
        /// <param name="tsi">
        ///   The item from which to dissociate ourselves.
        /// </param>
        /// 
        protected internal void RemoveToolStripItem(ToolStripItem tsi)
        {
            if (!this.m_associations.Contains(tsi))
            {
                throw new NotAssociatedException();
            }

            this.m_associations.Remove(tsi);

            //
            // finally, unhook any events that we might have hooked up
            // to this deely-bop.
            //
            tsi.EnabledChanged -= new EventHandler(OnItemEnableChanged);
            tsi.VisibleChanged -= new EventHandler(OnItemVisibleChanged);

            if (tsi is ToolStripButton)
            {
                tsi.Click -= new EventHandler(OnItemClick);
                (tsi as ToolStripButton).CheckedChanged
                        -= new EventHandler(OnItemCheckedChanged);
            }
            else if (tsi is ToolStripMenuItem)
            {
                ToolStripMenuItem tsmi;
                tsmi = tsi as ToolStripMenuItem;

                tsmi.CheckedChanged -= new EventHandler(OnItemCheckedChanged);
                tsmi.DropDownItemClicked -=
                    new ToolStripItemClickedEventHandler(
                                OnItemDropDownItemClicked);
            }
            else if (tsi is ToolStripComboBox)
            {
                ToolStripComboBox tscb;
                tscb = (tsi as ToolStripComboBox);

                tscb.SelectedIndexChanged -=
                    new EventHandler(OnItemSelectedIndexChanged);
            }

        }


        //=------------------------------------------------------------------=
        // ContainsToolStripItem
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Asks us whether or not we're associated with the given 
        ///   ToolStripItem.
        /// </summary>
        /// 
        /// <param name="tsi">
        ///   The item to check for an association.
        /// </param>
        /// 
        protected internal bool ContainsToolStripItem(ToolStripItem tsi)
        {
            return this.m_associations.Contains(tsi);
        }

        #endregion // Namespace-Public Methods/Functions/Properties







        #region Non-Public Methods/Functions/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Non-Public Methods/Functions/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // OnExecute
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Fires the Execute event to anybody listening.  This method is
        ///   provided to conform to standard event method patterns. (i.e.
        ///   Code should never just call the Execute event directly, but 
        ///   always this method).
        /// </summary>
        /// 
        protected void OnExecute()
        {
			EventHandler handler = this.Execute;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }


        //=------------------------------------------------------------------=
        // OnItemClick
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has clicked on one of the items with which we are
        ///   associated.  We will just raise the "Execute" event.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   The item from which the event came.
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void OnItemClick(object sender, EventArgs e)
        {
            OnExecute();
        }


        //=------------------------------------------------------------------=
        // OnItemEnableChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The Enabled property on one of the items with which we are 
        ///   associated has changed.  Go and change all of the others now
        ///   too.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   The item which had its Enabled property changed.
        /// </param>
        /// 
        /// <param name="e">
        ///   System.EventArgs.Empty
        /// </param>
        /// 
        private void OnItemEnableChanged(object sender, EventArgs e)
        {
            bool newValue;

            //
            // since we're going to be changing our other controls' Enabled
            // properties now, we don't want them to trigger any of this
            // code ...
            //
            if (this.m_inEnabledChanged)
            {
                return;
            }

            try
            {
                this.m_inEnabledChanged = true;
                if (sender is ToolStripItem)
                {
                    newValue = (sender as ToolStripItem).Enabled;

                    setEnabledValue(newValue, sender as ToolStripItem);
                }
            }
            finally
            {
                this.m_inEnabledChanged = false;
            }
        }


        //=------------------------------------------------------------------=
        // OnItemVisibleChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The Visible property on one of the items with which we are 
        ///   associated has changed.  Go and change all of the others now
        ///   too.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   The item which had its Visible property changed.
        /// </param>
        /// 
        /// <param name="e">
        ///   System.EventArgs.Empty
        /// </param>
        /// 
        private void OnItemVisibleChanged(object sender, EventArgs e)
        {
            bool newValue;

            //
            // since we're going to be changing our other controls' Visible
            // properties now, we don't want them to trigger any of this
            // code ...
            //
            if (this.m_inVisibleChanged)
            {
                return;
            }

            try
            {
                this.m_inVisibleChanged = true;

                if (sender is ToolStripItem)
                {
                    newValue = (sender as ToolStripItem).Visible;

                    setVisibleValue(newValue, sender as ToolStripItem);
                }
            }
            finally
            {
                this.m_inVisibleChanged = false;
            }
        }


        //=------------------------------------------------------------------=
        // OnItemCheckedChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The Checked property on one of the items with which we are 
        ///   associated has changed.  Go and change all of the others now
        ///   too.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   The item which had its Checked property changed.
        /// </param>
        /// 
        /// <param name="e">
        ///   System.EventArgs.Empty
        /// </param>
        /// 
        private void OnItemCheckedChanged(object sender, EventArgs e)
        {
            CheckState cs;

            // if there are sub-menu items, ignore this.
            if (sender is ToolStripMenuItem && (sender as ToolStripMenuItem).HasDropDownItems)
            {
                return;
            }

            // since we're going to be changing our other components here
            // we don't want them triggering all this code as well.
            if (this.m_inCheckedChanged)
            {
                return;
            }

            try
            {
                this.m_inCheckedChanged = true;

                // get the new checkstate value that we're going to give
                // to all the other items for which we are responsible.
                if (sender is ToolStripButton)
                {
                    cs = (sender as ToolStripButton).CheckState;
                }
                else if (sender is ToolStripMenuItem)
                {
                    cs = (sender as ToolStripMenuItem).CheckState;
                }
                else
                {
                    System.Diagnostics.Debug.Fail("Bad ToolStripItem type!");
                    return;
                }

                setCheckStateValue(cs, sender as ToolStripItem);
            }
            finally
            {
                this.m_inCheckedChanged = false;
            }
        }


        //=------------------------------------------------------------------=
        // OnItemDropDownItemClicked
        //=------------------------------------------------------------------=
        ///   One of the items in the sub-menu of the given item was clicked.
        ///   Update any other sub-menus or combo boxes with which we are
        ///   associated now.
        private void OnItemDropDownItemClicked
        (
            object sender,
            ToolStripItemClickedEventArgs e
        )
        {
            ToolStripMenuItem tsmi;
            string value;

            // since we're going to be changing our other components here
            // we don't want them triggering all this code as well.
            if (this.m_inSelectedItemChanging)
            {
                return;
            }

            try
            {
                this.m_inSelectedItemChanging = true;

                if (e.ClickedItem is ToolStripMenuItem)
                {
                    tsmi = e.ClickedItem as ToolStripMenuItem;
                    
					// Handle escaped mnemonics (&&)
					value = Regex.Replace(tsmi.Text, "&(.)", "$1");
					
					setSubItemSelected(value, sender as ToolStripItem);

                    // finally, doing this is an "Execute" event.
                    OnExecute();
                }
            }
            finally
            {
                this.m_inSelectedItemChanging = false;
            }
        }


        //=------------------------------------------------------------------=
        // OnItemSelectedIndexChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user selected an item in the combo drop down in a 
        ///   ToolStripComboBox
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
        private void OnItemSelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox tscb;
            string value;

            //
            // since we're going to be changing our other components here
            // we don't want them triggering all this code as well!!
            //
            if (this.m_inSelectedItemChanging)
            {
                return;
            }

            try
            {
                this.m_inSelectedItemChanging = true;

                tscb = sender as ToolStripComboBox;
                value = tscb.SelectedItem.ToString();

                setSubItemSelected(value, tscb);

                //
                // finally, doing this is an "Execute" event.
                //
                OnExecute();
            }
            finally
            {
                this.m_inSelectedItemChanging = false;
            }

        }


        //=------------------------------------------------------------------=
        // setEnabledValue
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Sets the Enabled property on <em>all</em> of our components.
        /// </summary>
        /// 
        /// <param name="value">
        ///   New value.
        /// </param>
        /// 
        /// <param name="causedBy">
        ///   The item that caused the change ( we don't want to re-set its
        ///   value!).
        /// </param>
        /// 
        private void setEnabledValue(bool value, ToolStripItem causedBy)
        {
            //
            // loop through all our other components, and change
            // the Enabled values for all of those except the one
            // that triggered this event.
            //
            for (int x = 0; x < this.m_associations.Count; x++)
            {
                ToolStripItem tsi;
                tsi = this.m_associations[x] as ToolStripItem;

                if (tsi != causedBy)
                {
                    tsi.Enabled = value;
                }
            }

            this.m_enabled = value;
        }


        //=------------------------------------------------------------------=
        // setVisibleValue
        //=------------------------------------------------------------------=
        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <param name="value">
        /// </param>
        /// 
        /// <param name="causedBy">
        /// </param>
        /// 
        private void setVisibleValue(bool value, ToolStripItem causedBy)
        {
            //
            // loop through all our other components, and change
            // the visible values for all of those except the one
            // that triggered this event.
            //
            for (int x = 0; x < this.m_associations.Count; x++)
            {
                ToolStripItem tsi;
                tsi = this.m_associations[x] as ToolStripItem;

                if (tsi != causedBy)
                {
                    tsi.Visible = value;
                }
            }

            this.m_visible = value;
        }


        //=------------------------------------------------------------------=
        // setCheckStateValue
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Sets the CheckState property on <em>all</em> of our components.
        /// </summary>
        /// 
        /// <param name="value">
        ///   New value.
        /// </param>
        /// 
        /// <param name="causedBy">
        ///   The item that caused the change ( we don't want to re-set its
        ///   value!).
        /// </param>
        /// 
        private void setCheckStateValue
        (
            CheckState value,
            ToolStripItem causedBy
        )
        {
            //
            // now, go and set this new value on all the other controls
            // for which we are responsible. 
            //
            for (int x = 0; x < this.m_associations.Count; x++)
            {
                //
                // if it's not the dude that sent us the message, then
                // we'll change their value too.
                //
                if (this.m_associations[x] != causedBy)
                {
                    if (this.m_associations[x] is ToolStripButton)
                    {
                        ToolStripButton tsb;

                        tsb = this.m_associations[x] as ToolStripButton;
                        tsb.CheckState = value;
                    }
                    else if (this.m_associations[x] is ToolStripMenuItem)
                    {
                        ToolStripMenuItem tsmi;

                        tsmi = this.m_associations[x] as ToolStripMenuItem;
                        tsmi.CheckState = value;
                    }
                }
            }

            this.m_checkState = value;
        }


        //=------------------------------------------------------------------=
        // setSubItemSelected
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Sets the selected item (in a combo box) or sub-menu-item (for
        ///   a menu) to the given text value.  If the given value does not
        ///   exist for any associated item, we ignore that item and continue.
        /// </summary>
        /// 
        /// <param name="itemText">
        ///   The text to select in all our components.
        /// </param>
        /// 
        /// <param name="causedBy">
        ///   The item that caused the change ( we don't want to re-set its
        ///   value!).
        /// </param>
        /// 
        private void setSubItemSelected
        (
            string itemText,
            ToolStripItem causedBy
        )
        {
            //
            // loop through all our items, looking for ToolStripMenuItems
            // with sub-menus and ToolStrip ComboBoxes.  If we find them,
            // go and try to find the appropriate item in their sub-item
            // collections.
            //
            for (int x = 0; x < this.m_associations.Count; x++)
            {
                if (this.m_associations[x] != causedBy)
                {
                    if (this.m_associations[x] is ToolStripMenuItem)
                    {
                        selectSubItemOfMenuItem(this.m_associations[x]
                                                    as ToolStripMenuItem,
                                                itemText);
                    }
                    else if (this.m_associations[x] is ToolStripComboBox)
                    {
                        selectSubItemOfComboBox(this.m_associations[x]
                                                    as ToolStripComboBox,
                                                itemText);
                    }
                }
            }

            this.m_subItemSelected = itemText;
        }


        //=------------------------------------------------------------------=
        // selectSubItemOfMenuItem
        //=------------------------------------------------------------------=
         ///   Selects the sub-menu-item with the given text value (minus
        ///   any &amp; characters, of course).
        private void selectSubItemOfMenuItem(ToolStripMenuItem tsmi, string itemText)
        {
            for (int x = 0; x < tsmi.DropDown.Items.Count; x++)
            {
                ToolStripMenuItem sub;
                string fixedText;

                sub = (tsmi.DropDownItems[x] as ToolStripMenuItem);
  				fixedText = Regex.Replace(sub.Text, "&(.)", "$1");

                if (fixedText.Equals(itemText,
                            StringComparison.CurrentCultureIgnoreCase))
                {
                    sub.CheckState = CheckState.Checked;
                }
                else
                {
                    sub.CheckState = CheckState.Unchecked;
                }
            }
        }


        //=------------------------------------------------------------------=
        // selectSubItemOfComboBox
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Selects the given drop down of the given combo box.
        /// </summary>
        /// 
        /// <param name="tscb">
        ///   The ToolStripComboBox whose specified drop down item we want
        ///   selected.
        /// </param>
        /// 
        /// <param name="itemText">
        ///   The text value of the item to select.
        /// </param>
        /// 
        private void selectSubItemOfComboBox
        (
            ToolStripComboBox tscb,
            string itemText
        )
        {
            for (int x = 0; x < tscb.Items.Count; x++)
            {
                if (tscb.Items[x].ToString().Equals(itemText,
                                   StringComparison.CurrentCultureIgnoreCase))
                {
                    tscb.SelectedIndex = x;
                    return;
                }
            }
        }

        #endregion // Non-Public Methods/Functions/Properties
    }
}