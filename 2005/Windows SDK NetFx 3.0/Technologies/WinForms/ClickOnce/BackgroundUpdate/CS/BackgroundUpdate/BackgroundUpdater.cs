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
using System.ComponentModel;
using System.Deployment.Application;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdate
{
    //=----------------------------------------------------------------------=
    // BackgroundUpdater
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This is a handy little non-visual component you can drop on a 
    ///   form to have it do all your background updating for you!  You
    ///   can configure how long it takes between checks, as well as 
    ///   whether it should complain if the application is network
    ///   deployed or not.
    /// </summary>
    /// 
    [DefaultProperty("ThrowIfNotNetworkDeployed")]
    [DefaultEvent("UpdateCompleted")]
    public class BackgroundUpdater : Component
    {
        #region Private data types/constants/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                  Private data types/constants/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        /// 
        /// <summary>
        ///   The ApplicationDeployment.CurrentDeployment object.  If this is
        ///   null/Nothing, then the application is not deployed via 
        ///   ClickOnce.
        /// </summary>
        /// 
        protected ApplicationDeployment m_deployment;

        /// 
        /// <summary>
        ///   The currently running version of the deployed app.
        /// </summary>
        /// 
        protected Version m_CurrentVersion;


        /// 
        /// <summary>
        ///   Controls whether we should silently fail (false) or throw
        ///   an exception if the programmer calls Start() and we are
        ///   not deployed via ClickOnce.
        /// </summary>
        /// 
        protected bool m_throwIfNotNetworkDeployed;

        /// 
        /// <summary>
        ///   A flag that indicates whether or not we are actively updating
        ///   right now.
        /// </summary>
        /// 
        protected bool m_updating;

        /// 
        /// <summary>
        ///   Number of MILLISECONDS between each check.  Default value
        ///   is two hours.
        /// </summary>
        /// 
        protected int m_updateInterval;

        /// 
        /// <summary>
        ///   One minute, specified in milliseconds
        /// </summary>
        /// 
        protected const int ONE_MINUTE_IN_MS = 1000 * 60;
        
        /// 
        /// <summary>
        ///   The Timer object we will use to manage the intervals between
        ///   update checks.
        /// </summary>
        /// 
        protected Timer m_updateTimer;

        #endregion // Private data types/constants/etc.


        #region Public Methods/Properties/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                  Public Methods/Properties/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // BackgroundUpdater
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initialises a new instance of our object.
        /// </summary>
        /// 
        public BackgroundUpdater()
        {
            this.m_deployment = null;
            this.m_CurrentVersion = null;
            this.m_throwIfNotNetworkDeployed = false;
            this.m_updateInterval = ONE_MINUTE_IN_MS;
            this.m_updating = false;

            //
            // Set up the timer, its default interval, and hook up to its
            // Tick event.
            //
            this.m_updateTimer = new Timer();
            this.m_updateTimer.Interval = this.m_updateInterval;
            this.m_updateTimer.Stop();
            this.m_updateTimer.Tick += new EventHandler(updateTimer_Tick);
        }


        //=------------------------------------------------------------------=
        // BackgroundUpdater
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initializes a new instance of this object, adding ourselves,
        ///   if necessary, to the specified container.
        /// </summary>
        /// 
        /// <param name="container">
        ///   The container to which, if specified, we should add ourselves.
        /// </param>
        /// 
        public BackgroundUpdater(IContainer container) : this()
        {
            if (container != null)
            {
                container.Add(this);
            }
        }

        //=------------------------------------------------------------------=
        // CurrentVersion
        //=------------------------------------------------------------------=
        /// <summary>
        ///  Returns current
        /// </summary>
        /// 
        /// <value>
        ///   String 
        /// </value>
        ///
        [LocalizableDescription("descCurrentVersion")]
        [DefaultValue("1.0.0.0")]
        public Version CurrentVersion
        {
            get
            {
                // Get CurrentVersion
                this.m_deployment = ApplicationDeployment.CurrentDeployment;
                m_CurrentVersion = this.m_deployment.CurrentVersion;
                return this.m_CurrentVersion;
            }
        }


        //=------------------------------------------------------------------=
        // ThrowIfNotNetworkDeployed
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Controls whether we should fail silently (false) or throw an
        ///   Exception (true) if the programmer calls start and the 
        ///   application is not deployed via the ClickOnce framework.
        /// </summary>
        /// 
        /// <value>
        ///   A boolean controlling whether we should throw when we detect 
        ///   that we are not network deployed.
        /// </value>
        ///
        [LocalizableDescription("descThrowIfNotNetworkDeployed")]
        [DefaultValue(false)]
        public bool ThrowIfNotNetworkDeployed
        {
            get
            {
                return this.m_throwIfNotNetworkDeployed;
            }

            set
            {
                this.m_throwIfNotNetworkDeployed = value;
            }
        }


        //=------------------------------------------------------------------=
        // UpdateInterval
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Controls the interval, in milliseconds, between  update checks.
        /// </summary>
        /// 
        /// <value>
        ///   The interval in milliseconds. The default value is 1 minute.
        /// </value>
        /// 
        [LocalizableDescription("descUpdateInterval")]
        [DefaultValue(ONE_MINUTE_IN_MS)]
        public int UpdateInterval
        {
            get
            {
                return this.m_updateInterval;
            }

            set
            {
                if (value < 0)
                {
                    throw new TimeTravelNotInventedYetException();
                }

                this.m_updateInterval = value;
                this.m_updateTimer.Interval = value;
            }
        }


        //=------------------------------------------------------------------=
        // Start
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Tells the component to begin update checks in the background.
        /// </summary>
        /// 
        public void Start()
        {
            this.m_updateTimer.Start();
        }


        //=------------------------------------------------------------------=
        // Stop
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Tells the component to stop checking for updates.
        /// </summary>
        /// 
        public void Stop()
        {
            this.m_updateTimer.Stop();
        }

        //=------------------------------------------------------------------=
        // UpdateCompleted
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This event is raised whenever a background update is completed.  
        /// </summary>
        /// 
        [LocalizableDescription("descUpdateCompleted")]
        public event UpdateCompletedEventHandler UpdateCompleted;
        
        #endregion // Public Methods/Properties/etc


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
        // updateTimer_Tick
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We'll periodically check for a new version using a Timer.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   System.EventArgs.Empty
        /// </param>
        /// 
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            beginUpdate();
        }


        //=------------------------------------------------------------------=
        // beginUpdate
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Tells us to begin checking for a new version, and if there
        ///   is one, to download it.
        /// </summary>
        /// 
        private void beginUpdate()
        {
            if (this.m_updating != true)
            {
                // Flag ourselves as updating.
                this.m_updating = true;

                // If the app is network deployed, then start a background update.
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    // Get the application deployment 
                    // Hook up the UpdateCompleted event and the UpdateProgressChanged event
                    this.m_deployment = ApplicationDeployment.CurrentDeployment;
                    this.m_deployment.UpdateCompleted += new AsyncCompletedEventHandler(deploymentUpdateCompleted);
                    this.m_deployment.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(deploymentUpdateProgressChanged);

                    // Begin the asynchronous update
                    this.m_deployment.UpdateAsync();
                }
                else
                {
                    if (this.m_throwIfNotNetworkDeployed)
                    {
                        throw new NotNetworkDeployedException();
                    }
                }
            }
        }

        //=------------------------------------------------------------------=
        // deploymentUpdateProgressChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   application update progress changed
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details about it.
        /// </param>
        /// 
        void deploymentUpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            // you can use this event to track update progress including 
            // number of bytes downloaded, percentage, which filegroup, etc.
        }


        //=------------------------------------------------------------------=
        // deploymentUpdateCompleted
        //=------------------------------------------------------------------=
        /// <summary>
        ///   An update of the application was completed. 
        ///   Even though we got an UpdateCompleted event, 
        ///   we  still need to check the following:
        ///   1. Was a newer version downloaded (UpdatedVersion > CurrentVersion) ?
        ///   2. Was the update cancelled (check e.Cancelled) ?
        ///   3. Was there was an error (check e.Error) ?
        ///   Note: we will let the form handle checking e.Error and e.Cancelled.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details about it.
        /// </param>
        /// 
        void deploymentUpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            UpdateCompletedEventArgs ucea;

            try
            {
                ucea = new UpdateCompletedEventArgs(
                           this.m_deployment.UpdatedVersion, e.Error, e.Cancelled);
                    
                    // Raise the BackgroundUpdater.UpdateCompleted event that the
                    // BackgroundUpdateDemoForm is listening on.
                    if (this.UpdateCompleted != null)
                    {
                        this.UpdateCompleted(this, ucea);
                    }
            }
            finally
            {
                // Reset internal updating flag.
                this.m_updating = false;
            }
        }

        #endregion // Non-Public Methods/Functions/Properties
    }
}