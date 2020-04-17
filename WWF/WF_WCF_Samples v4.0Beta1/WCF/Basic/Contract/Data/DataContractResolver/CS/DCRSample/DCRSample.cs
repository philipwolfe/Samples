
//-----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
//-----------------------------------------------------------------

namespace Microsoft.Samples.DCR
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    using Microsoft.Samples.DCR.Types;

    [KnownAssembly("Types")]
    public class DCRSample
    {
        static void Main(string[] args)
        {
            object[] attributes = typeof(DCRSample).GetCustomAttributes(typeof(KnownAssembly), true);
            if (attributes.GetLength(0) != 0)
            {
                Assembly assembly = Assembly.Load(new AssemblyName(((KnownAssembly)attributes[0]).AssemblyName));
                DataContractResolverSample dcrSample = new DataContractResolverSample(assembly);

                Console.WriteLine("Serializing types from assembly: " + ((KnownAssembly)attributes[0]).AssemblyName);
                foreach (Type type in assembly.GetTypes())
                {
                    dcrSample.serialize(type);
                    dcrSample.deserialize(type);
                }
                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.WriteLine("Assembly not found");
            }
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate.");
            Console.ReadLine();
        }
    }

    class DataContractResolverSample
    {
        DataContractSerializer serializer;
        StringBuilder buffer;

        public DataContractResolverSample(Assembly assembly)
        {
            this.serializer = new DataContractSerializer(typeof(Object), null, int.MaxValue, false, true, null, new MyDataContractResolver(assembly));
        }

        public void serialize(Type type)
        {
            Object instance = Activator.CreateInstance(type);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Serializing type: {0}", type.Name);
            Console.WriteLine();
            this.buffer = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(this.buffer))
            {
                try
                {
                    this.serializer.WriteObject(xmlWriter, instance);
                }
                catch (SerializationException error)
                {
                    Console.WriteLine(error.ToString());
                }
            }
            Console.WriteLine(this.buffer.ToString());
        }

        public void deserialize(Type type)
        {
            Console.WriteLine();
            Console.WriteLine("Deserializing type: {0}", type.Name);
            Console.WriteLine();
            using (XmlReader xmlReader = XmlReader.Create(new StringReader(this.buffer.ToString())))
            {
                Object obj = this.serializer.ReadObject(xmlReader);
            }
        }
    }

    class MyDataContractResolver : DataContractResolver
    {
        private Dictionary<string, XmlDictionaryString> dictionary = new Dictionary<string, XmlDictionaryString>();
        Assembly assembly;

        public MyDataContractResolver(Assembly assembly)
        {
            this.assembly = assembly;
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
                return null;
            }
        }

        // Used at serialization
        // Maps any Type to a new xsi:type representation
        public override void ResolveType(Type dataContractType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            string name = dataContractType.Name;
            string namesp = dataContractType.Namespace;
            typeName = new XmlDictionaryString(XmlDictionary.Empty, name, 0); 
            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, namesp, 0);
            if (!dictionary.ContainsKey(dataContractType.Name))
            {
                dictionary.Add(name, typeName);
            }
            if (!dictionary.ContainsKey(dataContractType.Namespace))
            {
                dictionary.Add(namesp, typeNamespace);
            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    class KnownAssembly : System.Attribute
    {
        public KnownAssembly(string name)
        {
            this.AssemblyName = name;
        }

        public string AssemblyName { get; set; }
    }

}
