using System;
using System.Collections.Specialized;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Configuration;
using System.Workflow.Runtime.Tracking;
using Microsoft.Workflow.Samples.Administration;

namespace HostForm
{
    public class WinOEHost
    {
        private string trackingConnectionString = null;
        private bool liveAdministrationEnabled = false;

        private WorkflowRuntime container = null;
        private SqlTrackingService trackingService = null;
        private AdministrationService administrationService = null;

        private WorkflowRuntimeSection mySection = null;

        private bool runtimeInitialized = false;

        public WinOEHost(string trackingConnectionString)
        {
            this.trackingConnectionString = trackingConnectionString;
            if (this.trackingConnectionString != null && this.trackingConnectionString.Length > 0)
            {
                this.mySection = new WorkflowRuntimeSection();
                this.mySection.Name = "my section";
            }
            this.container = (this.mySection != null) ? new WorkflowRuntime(this.mySection) : new WorkflowRuntime();
        }

        public string TrackingConnectionString
        {
            get { return this.trackingConnectionString; }
        }

        public bool LiveAdministrationEnabled
        {
            get { return this.liveAdministrationEnabled; }
            set { this.liveAdministrationEnabled = value; }
        }

        public WorkflowRuntime WorkflowServiceContainer
        {
            get { return this.container; }
        }

        public WorkflowRuntime InstanceService
        {
            get { return this.container; }
        }

        public void AddService(object service)
        {
            this.container.AddService(service);
        }

        public void InitializeRuntime()
        {
            try
            {
                if (!this.runtimeInitialized)
                {
                    if (LiveAdministrationEnabled)
                        this.administrationService = new AdministrationService(container);

                    if (this.trackingConnectionString != null && this.trackingConnectionString.Length > 0 && this.mySection != null)
                    {
                        this.mySection.CommonParameters.Add(new System.Configuration.NameValueConfigurationElement("ConnectionString", this.trackingConnectionString));

                        NameValueCollection collection = new NameValueCollection();
                        this.trackingService = new SqlTrackingService(collection);
                        container.AddService(this.trackingService);

                        this.trackingService.IsTransactional = false;
                        this.trackingService.UseDefaultProfile = true;
                    }
                    container.StartRuntime();
                    this.runtimeInitialized = true;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        public void Shutdown()
        {
            //if(this.administrationService != null)
            //    this.administrationService.DisconnectFromClient(false);

            container.StopRuntime();
        }
    }
}