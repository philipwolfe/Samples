#region Copyright Notice
// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

#endregion

using System;
using System.IO;
using System.Text;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    

    public class UddiClient : IDisposable
    {
        InquireProxy inquireProxy;
        PublishProxy publishProxy;
        authToken token;        

        public UddiClient()
        {
            inquireProxy = new InquireProxy("Inquire");
            publishProxy = new PublishProxy("Publish");
        }

        public void Login(string username, string password)
        {
            get_authToken getToken = new get_authToken();
            getToken.generic = "2.0";
            getToken.userID = username;
            getToken.cred = password;

            get_authTokenRequest request = new get_authTokenRequest();
            request.get_authToken = getToken;
            token = publishProxy.get_authToken(request).authToken;
        }

        public businessInfo[] GetBusinessByName(string businessName)
        {
            find_business find = new find_business();
            find.name = new name[1] { new name() };
            find.name[0].Value = businessName;
            find.generic = "2.0";
            find.maxRows = 20;

            find_businessRequest request = new find_businessRequest();
            request.find_business = find;
            businessList bList = inquireProxy.find_business(request).businessList;
            return bList.businessInfos;
        }


        public string PublishBusiness(string businessName, string description)
        {
            save_business newBusiness = new save_business();
            newBusiness.authInfo = token.authInfo;
            newBusiness.generic = "2.0";
            newBusiness.businessEntity = new businessEntity[1] { new businessEntity() };

            businessEntity myBusinessEntity = newBusiness.businessEntity[0];
            myBusinessEntity.name = new name[1] { new name() };
            myBusinessEntity.name[0].Value = businessName;
            myBusinessEntity.businessKey = "";
            myBusinessEntity.description = new description[1] { new description() };
            myBusinessEntity.description[0].Value = description;

            save_businessRequest request = new save_businessRequest();
            request.save_business = newBusiness;
            businessDetail myBusinessDetail = publishProxy.save_business(request).businessDetail;

            return myBusinessDetail.businessEntity[0].businessKey;
        }

        public businessInfo[] GetMyBusinesses()
        {
            get_registeredInfo getInfo = new get_registeredInfo();

            getInfo.generic = "2.0";
            getInfo.authInfo = token.authInfo;

            get_registeredInfoRequest request = new get_registeredInfoRequest();
            request.get_registeredInfo = getInfo;
            registeredInfo info = publishProxy.get_registeredInfo(request).registeredInfo;
            if (info == null) return null;

            return info.businessInfos;
        }

        public businessInfo GetMyBusinessByName(string businessName)
        {
            get_registeredInfo getInfo = new get_registeredInfo();

            getInfo.generic = "2.0";
            getInfo.authInfo = token.authInfo;

            get_registeredInfoRequest request = new get_registeredInfoRequest();
            request.get_registeredInfo = getInfo;
            registeredInfo info = publishProxy.get_registeredInfo(request).registeredInfo;

            if (info == null) return null;
            foreach (businessInfo bInfo in info.businessInfos)
            {
                if (bInfo.name[0].Value == businessName)
                {
                    return bInfo;
                }
            }
            return null;
        }

        public void DeleteMyBusinesses()
        {
            businessInfo[] infos = this.GetMyBusinesses();

            delete_business business = new delete_business();
            business.businessKey = new string[infos.Length];
            for (int i = 0; i < infos.Length; i++)
            {
                business.businessKey[i] = infos[i].businessKey;
            }
            business.generic = "2.0";
            business.authInfo = token.authInfo;

            delete_businessRequest request = new delete_businessRequest();
            request.delete_business = business;
            publishProxy.delete_business(request);
        }

        public void DeleteMyBusiness(string businessKey)
        {
            delete_business business = new delete_business();
            business.businessKey = new string[1] { businessKey };
            business.generic = "2.0";
            business.authInfo = token.authInfo;

            delete_businessRequest request = new delete_businessRequest();
            request.delete_business = business;
            publishProxy.delete_business(request);
        }

        public void PrintBusinessInfo(businessInfo bInfo)
        {
            if (bInfo.name != null)
            {
                foreach (name n in bInfo.name)
                    Console.WriteLine("Name:        " + n.Value);
            }

            if (bInfo.description != null)
            {
                foreach (description desc in bInfo.description)
                    Console.WriteLine("Description: " + desc.Value);
            }
            Console.WriteLine("Key:         " + bInfo.businessKey);

            if (bInfo.serviceInfos != null)
                PrintServiceInfos(bInfo.serviceInfos);

            Console.WriteLine();
        }

        public void PrintServiceInfos(serviceInfo[] serviceInfos)
        {
            Console.WriteLine("Total Services Offered = " + serviceInfos.Length);
            if (serviceInfos.Length > 0)
            {
                foreach (serviceInfo sInfo in serviceInfos)
                {
                    Console.WriteLine("\tService Key: " + sInfo.serviceKey);

                    if (sInfo.name != null)
                    {
                        foreach (name n in sInfo.name)
                            Console.WriteLine("\tName: " + n.Value);

                    }

                    Console.WriteLine();
                }
            }
        }

        public void Dispose()
        {
            ((ICommunicationObject)inquireProxy).Close();
            ((ICommunicationObject)publishProxy).Close();
        }

    }

    
}
