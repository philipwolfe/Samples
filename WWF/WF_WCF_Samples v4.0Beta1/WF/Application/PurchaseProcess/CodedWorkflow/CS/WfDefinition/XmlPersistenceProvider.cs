//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.PurchaseProcess
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Persistence;
    using System.Runtime.Serialization;
    using System.ServiceModel.Persistence;
    using System.Xml.Linq;
    using Microsoft.Samples.WF.PurchaseProcess;
   
    /// <summary>
    /// Custom persistence provider to save workflow instances to files. It also
    /// leverages the schematized persistence framework for saving the Rfp attached
    /// to the instances to a queriable Xml file    
    ///    - PersistenceProvider: base class for creating custom persistence provider
    ///    - IDataViewMapper: interface for implementing schematized persistence
    /// </summary>
    public class XmlPersistenceProvider: PersistenceProvider, IDataViewMapper
    {

        protected override TimeSpan DefaultCloseTimeout
        {
            get
            {
                return TimeSpan.FromSeconds(15);
            }
        }

        protected override TimeSpan DefaultOpenTimeout
        {
            get
            {
                return TimeSpan.FromSeconds(15);
            }
        }

        public XmlPersistenceProvider(Guid id)
            : base(id)
        {
        }

        public override void Delete(object instance, TimeSpan timeout)
        {
            string fileName = IOHelper.GetFileName(this.Id);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public override IAsyncResult BeginDelete(object instance, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Delete(instance, timeout);
            return new CompletedAsyncResult(callback, state);
        }

        public override void EndDelete(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        public override object Create(object instance, TimeSpan timeout)
        {
            string fileName = IOHelper.GetFileName(this.Id);

            if (File.Exists(fileName))
            {
                throw new PersistenceException("We were asked to Create but the file exists.");
            }

            return Save(instance, timeout);
        }

        public override IAsyncResult BeginCreate(object instance, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Create(instance, timeout);
            return new CompletedAsyncResult<object>(null, callback, state);
        }

        public override object EndCreate(IAsyncResult result)
        {
            return CompletedAsyncResult<object>.End(result);
        }

        public override object Update(object instance, TimeSpan timeout)
        {            
            string fileName = IOHelper.GetFileName(this.Id);

            if (!File.Exists(fileName))
            {
                throw new PersistenceException("We were asked to Update but the file does not exist.");
            }

            return Save(instance, timeout);
        }

        public override IAsyncResult BeginUpdate(object instance, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Update(instance, timeout);
            return new CompletedAsyncResult<object>(null, callback, state);
        }

        public override object EndUpdate(IAsyncResult result)
        {
            return CompletedAsyncResult<object>.End(result);
        }        

        public override object Load(TimeSpan timeout)
        {
            string fileName = IOHelper.GetFileName(this.Id);

            try
            {
                using (FileStream inputStream = new FileStream(fileName, FileMode.Open))
                {
                    return LoadFromFile(inputStream, new NetDataContractSerializer());
                }
            }
            catch (FileNotFoundException exception)
            {
                throw new PersistenceException(exception.Message);
            }
        }

        public override IAsyncResult BeginLoad(TimeSpan timeout, AsyncCallback callback, object state)
        {
            object instance = Load(timeout);
            return new CompletedAsyncResult<object>(instance, callback, state);
        }

        public override object EndLoad(IAsyncResult result)
        {
            return CompletedAsyncResult<object>.End(result);
        }

        
        void EnsurePersistenceDirectory()
        {
            if (!Directory.Exists(IOHelper.PersistenceDirectory))
            {
                Directory.CreateDirectory(IOHelper.PersistenceDirectory);
            }
        }

        object LoadFromFile(Stream inputStream, XmlObjectSerializer serializer)
        {
            return serializer.ReadObject(inputStream);
        }

        object Save(object instance, TimeSpan timeout)
        {
            string fileName = IOHelper.GetFileName(this.Id);

            using (FileStream outputStream = new FileStream(fileName, FileMode.Create))
            {
                NetDataContractSerializer s = new NetDataContractSerializer();                
                s.Serialize(outputStream, instance);            
            }

            return null;
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnClose(TimeSpan timeout)
        {            
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        protected override void OnAbort()
        {
        }
        
        public IAsyncResult BeginDelete(Guid instanceId, System.Collections.IEnumerable dataToMap, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult(callback, state);
        }

        public void Delete(Guid instanceId, System.Collections.IEnumerable dataToMap, TimeSpan timeout)
        {
        }

        public IAsyncResult BeginMap(Guid instanceId, System.Collections.IEnumerable dataToMap, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Map(instanceId, dataToMap, timeout);

            return new CompletedAsyncResult(callback, state);
        }        

        public void EndMap(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        // schematized persistence step. Map the schematized data to a persistent store, in this case, a Xml file
        public void Map(Guid instanceId, System.Collections.IEnumerable dataToMap, TimeSpan timeout)
        {
            RequestForProposal requestForProposal = null;
            WorkflowInstanceInfo workflowInstanceInfo = null;

            foreach (object item in dataToMap)
            {
                if (item is WorkflowInstanceInfo)
                {
                    workflowInstanceInfo = (WorkflowInstanceInfo)item;
                }
                else if (item is RequestForProposal)
                {
                    requestForProposal = (RequestForProposal)item;
                }
            }
                
            // ensure that the output file exists
            IOHelper.EnsureAllRfpFileExists();

            // load the document
            XElement doc = XElement.Load(IOHelper.GetAllRfpsFileName());
            
            IEnumerable<XElement> current =
                                    from r in doc.Elements("requestForProposal")
                                    where r.Attribute("id").Value.Equals(instanceId.ToString())
                                    select r;


            // if it is finished, only update status
            if (workflowInstanceInfo.State == ActivityInstanceState.Closed)
            {
                // erase nodes for the current rfp                    
                foreach (XElement xe in current)
                {
                    xe.Attribute("status").Value = "finished";
                }
            }
            else
            {
                // erase nodes for the current rfp                    
                foreach (XElement xe in current)
                {                    
                    xe.Remove();
                }

                // get the Xml version of the Rfp, add it to the document and save it            
                XElement e = SerializeRfp(requestForProposal, instanceId);
                doc.Add(e);

            }

            doc.Save(IOHelper.GetAllRfpsFileName());
        }

        // serialize a Rfp to Xml using Linq to Xml
        XElement SerializeRfp(RequestForProposal rfp, Guid instanceId)
        {
            // main body of the rfp
             XElement ret = 
                new XElement("requestForProposal", 
                    new XAttribute("id", instanceId.ToString()),
                    new XAttribute("status", rfp.Status),                        
                        new XElement("creationDate", rfp.CreationDate),                        
                        new XElement("completionDate", rfp.CompletionDate),
                        new XElement("title", rfp.Title),
                        new XElement("description", rfp.Description));

            // add invited vendors
            XElement invitedVendors = new XElement("invitedVendors");
            foreach (Vendor vendor in rfp.InvitedVendors)
            {
                invitedVendors.Add(
                    new XElement("vendor",
                        new XAttribute("id", vendor.Id)));
            }          
            ret.Add(invitedVendors);

            // add vendor proposals            
            XElement vendorProposals = new XElement("vendorProposals");
            foreach (VendorProposal proposal in rfp.VendorProposals.Values)
            {
                vendorProposals.Add(
                    new XElement("vendorProposal",
                        new XAttribute("vendorId", proposal.Vendor.Id),
                        new XAttribute("date", proposal.Date),
                        new XAttribute("value", proposal.Value)));               
            }          
            ret.Add(vendorProposals);

            // add best proposal
            if (rfp.BestProposal != null && rfp.BestProposal.Vendor != null)
            {
                ret.Add(
                    new XElement("bestProposal",
                        new XAttribute("vendorId", rfp.BestProposal.Vendor.Id),
                        new XAttribute("date", rfp.BestProposal.Date),
                        new XAttribute("value", rfp.BestProposal.Value)));               
            }

            return ret;           
        }
    }    
}
