//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

namespace WorkflowDesignerControl
{
    #region Using Statements

    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;
    using System.Windows.Forms;
    using System.Drawing;
    
    #endregion

    #region Class WorkflowMenuCommandService
    internal sealed class WorkflowMenuCommandService : MenuCommandService
    {
        public WorkflowMenuCommandService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }


        public override void ShowContextMenu(CommandID menuID, int x, int y)
        {
            if (menuID == WorkflowMenuCommands.SelectionMenu)
            {
                ContextMenu contextMenu = new ContextMenu();

                foreach (DesignerVerb verb in Verbs)
                {
                    MenuItem menuItem = new MenuItem(verb.Text, new EventHandler(OnMenuClicked));
                    menuItem.Tag = verb;
                    contextMenu.MenuItems.Add(menuItem);
                }

                MenuItem[] items = GetSelectionMenuItems();
                if (items.Length > 0)
                {
                    contextMenu.MenuItems.Add(new MenuItem("-"));
                    foreach (MenuItem item in items)
                        contextMenu.MenuItems.Add(item);
                }

                WorkflowView workflowView = GetService(typeof(WorkflowView)) as WorkflowView;
                if (workflowView != null)
                    contextMenu.Show(workflowView, workflowView.PointToClient(new Point(x, y)));
            }
        }

        private void OnMenuClicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null && menuItem.Tag is MenuCommand)
            {
                MenuCommand command = menuItem.Tag as MenuCommand;
                command.Invoke();
            }
        }

        private MenuItem[] GetSelectionMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            bool addMenuItems = true;
            ISelectionService selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
            {
                foreach (object obj in selectionService.GetSelectedComponents())
                {
                    if (!(obj is Activity))
                    {
                        addMenuItems = false;
                        break;
                    }
                }
            }

            if (addMenuItems)
            {
                Dictionary<CommandID, string> selectionCommands = new Dictionary<CommandID, string>();
                selectionCommands.Add(WorkflowMenuCommands.Cut, "Cut");
                selectionCommands.Add(WorkflowMenuCommands.Copy, "Copy");
                selectionCommands.Add(WorkflowMenuCommands.Paste, "Paste");
                selectionCommands.Add(WorkflowMenuCommands.Delete, "Delete");


                foreach (CommandID id in selectionCommands.Keys)
                {
                    MenuCommand command = FindCommand(id);
                    if (command != null)
                    {
                        MenuItem menuItem = new MenuItem(selectionCommands[id], new EventHandler(OnMenuClicked));
                        menuItem.Tag = command;
                        menuItems.Add(menuItem);
                    }
                }
            }

            return menuItems.ToArray();
        }
    }
    #endregion
}