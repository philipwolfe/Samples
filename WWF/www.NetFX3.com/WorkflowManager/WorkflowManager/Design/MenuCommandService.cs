using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using IServiceProvider = System.IServiceProvider;

namespace Microsoft.Workflow.Samples.WorkflowManager.DesignerHosting
{
    #region Class MenuCommandService
    /// <summary>
    /// Dummy menu command service implementation. This is required to hook up menus
    /// with the designer. For more information please refer to IMenuCommandService documentation in MSDN.
    /// </summary>
    internal sealed class MenuCommandService : IMenuCommandService, IDisposable
    {
        private IServiceProvider _serviceProvider;
        private ArrayList _commands;
        private EventHandler _commandChangedHandler;
        private ArrayList _globalVerbs;
        private ISelectionService _selectionService;
        // This is the set of verbs we offer through the Verbs property.
        // It consists of the global verbs + any verbs that the currently
        // selected designer wants to offer.  This collection changes with the
        // current selection.
        //
        private DesignerVerbCollection _currentVerbs;
        // this is the type that we last picked up verbs from
        // so we know when we need to refresh
        //
        private Type _verbSourceType;

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.MenuCommandService"]/*' />
        /// <devdoc>
        ///     Creates a new menu command service.
        /// </devdoc>
        public MenuCommandService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _commandChangedHandler = new EventHandler(this.OnCommandChanged);
            TypeDescriptor.Refreshed += new RefreshEventHandler(this.OnTypeRefreshed);
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.Dispose"]/*' />
        /// <devdoc>
        ///     Disposes of this service.
        /// </devdoc>
        public void Dispose()
        {
            if (_selectionService != null)
            {
                _selectionService.SelectionChanging -= new EventHandler(this.OnSelectionChanging);
                _selectionService = null;
            }

            if (_serviceProvider != null)
            {
                _serviceProvider = null;
                TypeDescriptor.Refreshed -= new RefreshEventHandler(this.OnTypeRefreshed);
            }

            if (_commands != null)
            {
                foreach (MenuCommand command in _commands)
                {
                    command.CommandChanged -= _commandChangedHandler;
                }

                _commands.Clear();
            }
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.Verbs"]/*' />
        /// <devdoc>
        ///      Retrieves a set of verbs that are global to all objects on the design
        ///      surface.  This set of verbs will be merged with individual component verbs.
        ///      In the case of a name conflict, the component verb will NativeMethods.
        /// </devdoc>
        public DesignerVerbCollection Verbs
        {
            get
            {
                EnsureVerbs();
                return _currentVerbs;
            }
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.AddCommand"]/*' />
        /// <devdoc>
        ///     Adds a menu command to the document.  The menu command must already exist
        ///     on a menu; this merely adds a handler for it.
        /// </devdoc>
        public void AddCommand(MenuCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            // If the command already exists, it is an error to add
            // a duplicate.
            if (((IMenuCommandService)this).FindCommand(command.CommandID) != null)
                throw new ArgumentException();//SR.GetString(SR.MenuCommandService_DuplicateCommand, command.CommandID.ToString()));

            if (_commands == null)
                _commands = new ArrayList();
            _commands.Add(command);
            command.CommandChanged += _commandChangedHandler;

            OnCommandChanged(command, EventArgs.Empty);
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.AddVerb"]/*' />
        /// <devdoc>
        ///      Adds a verb to the set of global verbs.  Individual components should 
        ///      use the Verbs property of their designer, rather than call this method.
        ///      This method is intended for objects that want to offer a verb that is
        ///      available regardless of what components are selected.
        /// </devdoc>
        public void AddVerb(DesignerVerb verb)
        {
            if (verb == null)
            {
                throw new ArgumentNullException("verb");
            }

            if (_globalVerbs == null)
            {
                _globalVerbs = new ArrayList();
            }

            _globalVerbs.Add(verb);
            OnCommandChanged(null, EventArgs.Empty);
            EnsureVerbs();
            if (!((IMenuCommandService)this).Verbs.Contains(verb))
                ((IMenuCommandService)this).Verbs.Add(verb);
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.EnsureVerbs"]/*' />
        /// <devdoc>
        ///      Ensures that the verb list has been created.
        /// </devdoc>
        private void EnsureVerbs()
        {
            // We apply global verbs only if the base component is the
            // currently selected object.
            //
            bool useGlobalVerbs = false;

            if (_currentVerbs == null && _serviceProvider != null)
            {
                DesignerVerb[] buildVerbs = null;

                if (_selectionService == null)
                {
                    _selectionService = _serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
                    if (_selectionService != null)
                    {
                        _selectionService.SelectionChanging += new EventHandler(this.OnSelectionChanging);
                    }
                }

                int verbCount = 0;
                DesignerVerbCollection localVerbs = null;
                IDesignerHost designerHost = _serviceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;

                if (_selectionService != null && designerHost != null && _selectionService.SelectionCount == 1)
                {
                    object selectedComponent = _selectionService.PrimarySelection;

                    if (selectedComponent is IComponent && !TypeDescriptor.GetAttributes(selectedComponent).Contains(InheritanceAttribute.InheritedReadOnly))
                    {
                        useGlobalVerbs = (selectedComponent == designerHost.RootComponent);

                        IDesigner designer = designerHost.GetDesigner((IComponent)selectedComponent);

                        if (designer != null)
                        {
                            localVerbs = designer.Verbs;
                            if (localVerbs != null)
                            {
                                verbCount += localVerbs.Count;
                                _verbSourceType = selectedComponent.GetType();
                            }
                            else
                            {
                                _verbSourceType = null;
                            }
                        }
                    }
                }

                if (useGlobalVerbs && _globalVerbs == null)
                {
                    useGlobalVerbs = false;
                }

                if (useGlobalVerbs)
                {
                    verbCount += _globalVerbs.Count;
                }

                buildVerbs = new DesignerVerb[verbCount];
                if (useGlobalVerbs)
                {
                    _globalVerbs.CopyTo(buildVerbs);
                }

                if (localVerbs != null && localVerbs.Count > 0)
                {
                    int localStart = 0;

                    if (useGlobalVerbs)
                    {
                        localStart = _globalVerbs.Count;
                    }

                    localVerbs.CopyTo(buildVerbs, localStart);
                    if (useGlobalVerbs)
                    {
                        // Now we must look for verbs with conflicting names.  We do a case insensitive
                        // search on the name here (users will never understand if two verbs differ only
                        // in case).  We also do a simple n^2 algorithm here; I expect it to be rare 
                        // for there to be over 5 verbs, and even more rare for there to be a name
                        // conflict, so we can make the conflict reslution a bit more expensive and
                        // keep the normal case fast.
                        //
                        for (int gv = _globalVerbs.Count - 1; gv >= 0; gv--)
                        {
                            for (int lv = localVerbs.Count - 1; lv >= 0; lv--)
                            {
                                if (string.Compare(((DesignerVerb)_globalVerbs[gv]).Text, localVerbs[lv].Text, true) == 0)
                                {
                                    // Conflict.  We decrement globalVerbCount and NULL the slot.
                                    //
                                    Debug.Assert(buildVerbs[gv].Equals(_globalVerbs[gv]), "We depend on these arrays matching");
                                    buildVerbs[gv] = null;
                                    verbCount--;
                                }
                            }
                        }

                        if (buildVerbs.Length != verbCount)
                        {
                            // We encountered one or more conflicts.  Remove them by creating a new array.
                            //
                            DesignerVerb[] newVerbs = new DesignerVerb[verbCount];
                            int index = 0;

                            for (int i = 0; i < buildVerbs.Length; i++)
                            {
                                if (buildVerbs[i] != null)
                                {
                                    newVerbs[index++] = buildVerbs[i];
                                }
                            }

                            Debug.Assert(index == verbCount, "We miscounted verbs somewhere");
                            buildVerbs = newVerbs;
                        }
                    }
                }

                _currentVerbs = new DesignerVerbCollection(buildVerbs);
            }
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.FindCommand"]/*' />
        /// <devdoc>
        ///     Searches for the given command ID and returns the MenuCommand
        ///     associated with it.
        /// </devdoc>
        public MenuCommand FindCommand(CommandID commandID)
        {
            int temp = 0;

            return FindCommand(commandID.Guid, commandID.ID, ref temp);
        }

        /// <devdoc>
        ///     Locates the requested command. This will throw an appropriate
        ///     ComFailException if the command couldn't be found.
        /// </devdoc>
        private MenuCommand FindCommand(Guid guid, int id, ref int hrReturn)
        {
            // The hresult we will return.  We start with unknown group, and
            // then if we find a group match, we will switch this to
            // OLECMDERR_E_NOTSUPPORTED.
            //
            hrReturn = -1;//NativeMethods.OLECMDERR_E_UNKNOWNGROUP;
            if (_commands != null)
            {
                foreach (MenuCommand command in _commands)
                {
                    CommandID cid = command.CommandID;

                    if (cid.ID == id)
                    {
                        if (cid.Guid.Equals(guid))
                        {
                            hrReturn = 0;
                            return command;
                        }
                    }
                }
            }

            // Next, search the verb list as well.
            //
            EnsureVerbs();
            if (_currentVerbs != null)
            {
                int currentID = StandardCommands.VerbFirst.ID;

                foreach (DesignerVerb verb in _currentVerbs)
                {
                    CommandID cid = verb.CommandID;

                    if (cid.ID == id)
                    {
                        if (cid.Guid.Equals(guid))
                        {
                            hrReturn = 0;
                            return verb;
                        }
                    }

                    // We assign virtual sequential IDs to verbs we get from the component. This allows users
                    // to not worry about assigning these IDs themselves.
                    //
                    if (currentID == id)
                    {
                        if (cid.Guid.Equals(guid))
                        {
                            hrReturn = 0;
                            return verb;
                        }
                    }

                    if (cid.Equals(StandardCommands.VerbFirst))
                        currentID++;
                }
            }
            return null;
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.GlobalInvoke"]/*' />
        /// <devdoc>
        ///     Invokes a command on the local form or in the global environment.
        ///     The local form is first searched for the given command ID.  If it is
        ///     found, it is invoked.  Otherwise the the command ID is passed to the
        ///     global environment command handler, if one is available.
        /// </devdoc>
        public bool GlobalInvoke(CommandID commandID)
        {
            // try to find it locally
            MenuCommand cmd = ((IMenuCommandService)this).FindCommand(commandID);
            if (cmd != null)
            {
                cmd.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.GlobalInvoke1"]/*' />
        /// <devdoc>
        ///     Invokes a command on the local form or in the global environment.
        ///     The local form is first searched for the given command ID.  If it is
        ///     found, it is invoked.  Otherwise the the command ID is passed to the
        ///     global environment command handler, if one is available.
        /// </devdoc>
        public bool GlobalInvoke(CommandID commandID, object arg)
        {
            // try to find it locally
            MenuCommand cmd = ((IMenuCommandService)this).FindCommand(commandID);

            if (cmd != null)
            {
                cmd.Invoke(arg);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <devdoc>
        ///     This is called by a menu command when it's status has changed.
        /// </devdoc>
        private void OnCommandChanged(object sender, EventArgs e)
        {
        }

        /// <devdoc>
        ///     Called by TypeDescriptor when a type changes.  If this type is currently holding
        ///     our verb, invalidate the list.
        /// </devdoc>
        private void OnTypeRefreshed(RefreshEventArgs e)
        {
            if (_verbSourceType != null && _verbSourceType.IsAssignableFrom(e.TypeChanged))
                _currentVerbs = null;
        }

        /// <devdoc>
        ///      This is called by the selection service when the selection has changed.  Here
        ///      we invalidate our verb list.
        /// </devdoc>
        private void OnSelectionChanging(object sender, EventArgs e)
        {
            if (_currentVerbs != null)
            {
                _currentVerbs = null;
                OnCommandChanged(this, EventArgs.Empty);
            }
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.RemoveCommand"]/*' />
        /// <devdoc>
        ///     Removes the given menu command from the document.
        /// </devdoc>
        public void RemoveCommand(MenuCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            if (_commands != null)
            {
                int index = _commands.IndexOf(command);

                if (index != -1)
                {
                    _commands.RemoveAt(index);
                    command.CommandChanged -= _commandChangedHandler;

                    // Now that we've removed a new command, we must mark this command as dirty.
                    //
                    OnCommandChanged(command, EventArgs.Empty);
                }
                return;
            }
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.RemoveVerb"]/*' />
        /// <devdoc>
        ///     Removes the given verb from the document.
        /// </devdoc>
        public void RemoveVerb(DesignerVerb verb)
        {
            if (verb == null)
            {
                throw new ArgumentNullException("verb");
            }

            if (_globalVerbs != null)
            {
                int index = _globalVerbs.IndexOf(verb);

                if (index != -1)
                {
                    _globalVerbs.RemoveAt(index);
                    EnsureVerbs();
                    if (((IMenuCommandService)this).Verbs.Contains(verb))
                    {
                        ((IMenuCommandService)this).Verbs.Remove(verb);
                    }

                    OnCommandChanged(null, EventArgs.Empty);
                }
            }
        }

        /// <include file='doc\MenuCommandService.uex' path='docs/doc[@for="MenuCommandService.ShowContextMenu"]/*' />
        /// <devdoc>
        ///     Shows the context menu with the given command ID at the given location.
        /// </devdoc>
        public void ShowContextMenu(CommandID menuID, int x, int y)
        {
        }
    }
    #endregion
}