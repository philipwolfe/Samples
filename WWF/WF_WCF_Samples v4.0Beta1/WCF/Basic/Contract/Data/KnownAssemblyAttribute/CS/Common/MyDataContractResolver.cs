
//-----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
//-----------------------------------------------------------------

namespace Microsoft.Samples.KAA.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Xml;

    public class MyDataContractResolver : DataContractResolver
    {
        Dictionary<string, XmlDictionaryString> dictionary = new Dictionary<string, XmlDictionaryString>();
        Assembly assembly;

        public MyDataContractResolver(string assemblyName)
        {
            this.KnownTypes = new List<Type>();

            assembly = Assembly.Load(new AssemblyName(assemblyName));
            foreach (Type type in assembly.GetTypes())
            {
                bool knownTypeFound = false;
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);
                if (attrs.Length != 0)
                {
                    foreach (System.Attribute attr in attrs)
                    {
                        if (attr is KnownTypeAttribute)
                        {
                            Type t = ((KnownTypeAttribute)attr).Type;
                            if (this.KnownTypes.IndexOf(t) < 0)
                            {
                                this.KnownTypes.Add(t);
                            }
                            knownTypeFound = true;
                        }
                    }
                }
                if (!knownTypeFound)
                {
                    string name = type.Name;
                    string namesp = type.Namespace;
                    if (!dictionary.ContainsKey(name))
                    {
                        dictionary.Add(name, new XmlDictionaryString(XmlDictionary.Empty, name, 0));
                    }
                    if (!dictionary.ContainsKey(namesp))
                    {
                        dictionary.Add(namesp, new XmlDictionaryString(XmlDictionary.Empty, namesp, 0));
                    }
                }
            }
        }

        public IList<Type> KnownTypes
        {
            get; set;
        }

        // Used at deserialization
        // Allows users to map xsi:type name to any Type 
        public override Type ResolveName(string typeName, string typeNamespace, DataContractResolver knownTypeResolver)
        {
            XmlDictionaryString tName;
            XmlDictionaryString tNamespace;

            if (dictionary.TryGetValue(typeName, out tName) && dictionary.TryGetValue(typeNamespace, out tNamespace))
            {
                return this.assembly.GetType(tNamespace.Value + "." + tName.Value);
            }
            else
            {
                return knownTypeResolver.ResolveName(typeName, typeNamespace, null);
            }
        }

        // Used at serialization
        // Maps any Type to a new xsi:type representation
        public override void ResolveType(Type dataContractType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            knownTypeResolver.ResolveType(dataContractType, null, out typeName, out typeNamespace);
            if (typeName == null || typeNamespace == null)
            {
                typeName = new XmlDictionaryString(XmlDictionary.Empty, dataContractType.Name, 0);
                typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, dataContractType.Namespace, 0);
            }
        }
    }
}
