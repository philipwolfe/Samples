using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Workflow.Samples.Administration
{
    //we will give this object as a call back proxy to the LiveWorkflowInstance
    public class AdministrationServiceProxy : MarshalByRefObject
    {
        private Dictionary<Guid, IStateChangeEventCallback> localInstances = new Dictionary<Guid, IStateChangeEventCallback>();
        private IStateUpdatableInstanceCreator creator = null;

        public event EventHandler OnInstanceStateChanged;

        private AdministrationService remoteAdminService = null;
        private static AdministrationServiceProxy administrationServiceProxy = null;

        private AdministrationServiceProxy(IStateUpdatableInstanceCreator creator)
        {
            this.creator = creator;
            AdministrationServiceProxy.RegisterAdministrationServiceProxy(this);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        #region remoting management

        //main entrance on the client side
        public static AdministrationServiceProxy EstablishLiveConnection(IStateUpdatableInstanceCreator creator)
        {
            //this will open the proxy port
            try
            {
                AdministrationServiceProxy proxy = new AdministrationServiceProxy(creator);

                //this will connect to the remote admin service hosted by the runtime
                proxy.remoteAdminService = AdministrationService.ConnectToRemoteService();

                //now make the remote admin service connect back to us
                proxy.remoteAdminService.SetRemoteCallback();

                return proxy;
            }
            catch
            {
                return null;
            }
        }

        //raw connection point
        public static AdministrationServiceProxy ConnectToRemoteService()
        {
            return AdministrationServiceProxy.administrationServiceProxy;
        }

        private static void RegisterAdministrationServiceProxy(AdministrationServiceProxy administrationServiceProxy)
        {
            AdministrationServiceProxy.administrationServiceProxy = administrationServiceProxy;
        }

        #endregion

        #region event callbacks
        //will be called by the remote client
        public void FireOnInstanceChanged(Guid instanceId)
        {
            IStateChangeEventCallback instance = this.localInstances[instanceId];
            instance.OnStateChange(new DynamicUpdateEventArgs(instanceId));
        }

        //will be called by the remote client
        public void FireOnInstanceUpdated(Guid instanceId)
        {
            IStateChangeEventCallback instance = this.localInstances[instanceId];
            instance.OnStateChange(new ActivityStateChangeEventArgs(instanceId, null));
        }

        public void FireOnInstanceStateChanged(Guid instanceId, InstanceStateChangeType changeType)
        {
            lock (this.localInstances)
            {
                if (this.localInstances.ContainsKey(instanceId))
                {
                    //only fire event on the instances that are already referenced
                    IStateChangeEventCallback instance = this.localInstances[instanceId];
                    instance.OnStateChange(new InstanceStateChangeEventArgs(instanceId, changeType));
                }

                if (OnInstanceStateChanged != null)
                    OnInstanceStateChanged(this, new InstanceStateChangeEventArgs(instanceId, changeType));
            }
        }
        #endregion

        #region proxy pass through methods
        public string[] GetLoadedAssemblies()
        {
            return this.remoteAdminService.GetLoadedAssemblies();
        }

        public ICollection GetWorkflowInstances()
        {
            ICollection liveInstances = this.remoteAdminService.GetWorkflowInstances();
            ArrayList proxyInstances = new ArrayList();

            foreach (LiveWorkflowInstance liveInstance in liveInstances)
            {
                if (!this.localInstances.ContainsKey(liveInstance.InstanceId))
                {
                    IStateChangeEventCallback instance = this.creator.CreateLiveProxyInstance(liveInstance);
                    this.localInstances.Add(liveInstance.InstanceId, instance);
                }

                proxyInstances.Add(this.localInstances[liveInstance.InstanceId]);
            }

            return proxyInstances;
        }
        public IStateChangeEventCallback GetWorkflowInstance(Guid instanceId)
        {
            if (this.localInstances.ContainsKey(instanceId))
                return this.localInstances[instanceId];

            LiveWorkflowInstance liveInstance = this.remoteAdminService.GetWorkflowInstance(instanceId);
            IStateChangeEventCallback instance = this.creator.CreateLiveProxyInstance(liveInstance);
            this.localInstances.Add(liveInstance.InstanceId, instance);
            return instance;
        }
        #endregion
    }
}