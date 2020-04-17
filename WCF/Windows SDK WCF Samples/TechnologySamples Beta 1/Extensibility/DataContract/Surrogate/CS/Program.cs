
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.CodeDom.Compiler;
using System.Xml.Serialization;
#endregion

namespace DCSurrogateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create and populate an Employee instance
            Employee emp = new Employee();
            emp.date_hired = new DateTime(1999, 10, 14);
            emp.salary = 33000;

            //Note that the Person class is a legacy XmlSerializable class
            //without a DataContract
            emp.person = new Person();
            emp.person.first_name = "Mike";
            emp.person.last_name = "Ray";
            emp.person.age = 44;

            //Create a serializer
            DataContractSerializer dcs = new DataContractSerializer(typeof(Employee));

            //Attempt to serialize without a surrogate (this will fail)
            Console.WriteLine(" Attempting to serialize without a surrogate: \n");
            StringWriter sw1 = new StringWriter();
            XmlWriter xw1 = XmlWriter.Create(sw1);
            try
            {
                dcs.WriteObject(xw1, emp);
            }
            catch (InvalidDataContractException)
            {
                xw1.Flush();
                Console.Write(sw1.ToString());
                Console.WriteLine("\n\n Cannot serialize without a surrogate since Person has no DataContract \n");
            }

            DataContractSerializer surrogateDcs = 
                new DataContractSerializer(typeof(Employee), null, int.MaxValue, false, false, new LegacyPersonTypeSurrogate());

            //Plug in the surrogate and try again (this will succeed)
            Console.WriteLine(" We now plug in a surrogate for the Person class and try again: \n");
            StringWriter sw2 = new StringWriter();
            XmlWriter xw2 = XmlWriter.Create(sw2);
            try
            {
                surrogateDcs.WriteObject(xw2, emp);
            }
            catch (InvalidDataContractException)
            {
                Console.WriteLine(" We never get here");
            }
            xw2.Flush();
            sw2.Flush();
            Console.Write(sw2.ToString());
            Console.WriteLine("\n\n Serialization succeeded. Now doing deserialization...\n");

            //Deserialize using a surrogate
            StringReader tr = new StringReader(sw2.ToString());
            XmlReader xr = XmlReader.Create(tr);
            Employee newemp = (Employee)surrogateDcs.ReadObject(xr);
            Console.Write("Deserialized Person data: " + newemp.person.first_name + " " + newemp.person.last_name);
            Console.Write(", age " + newemp.person.age + "\n\n");

            Console.WriteLine("\n\n Deserialization succeeded. Now doing schema export/import...\n");

            //The following code demonstrates schema export with a surrogate.
            //The surrogate indicates how to export the non-DataContract Person type.
            //Without the surrogate, schema export would fail.
            XsdDataContractExporter xsdexp = new XsdDataContractExporter();
            xsdexp.Options = new ExportOptions();
            xsdexp.Options.DataContractSurrogate = new LegacyPersonTypeSurrogate();
            xsdexp.Export(typeof(Employee));

            //Write out exported schema to a file
            using (FileStream fs = new FileStream("sample.xsd", FileMode.Create))
            {
                foreach (XmlSchema sch in xsdexp.Schemas.Schemas())
                {
                    sch.Write(fs);
                }
            }

            //The following code demonstrates schema import with a surrogate.
            //The surrogate is used to indicate that the Person class already exists
            //and that there is no need to generate a new class when importing the
            //"PersonSurrogated" data contract.
            //If the surrogate wasn't plugged in, schema import would generate a PersonSurrogated class,
            //and the "person" field of Employee would be imported as PersonSurrogated and not Person.
            XsdDataContractImporter xsdimp = new XsdDataContractImporter();
            xsdimp.Options = new ImportOptions();
            xsdimp.Options.DataContractSurrogate = new LegacyPersonTypeSurrogate();
            xsdimp.Import(xsdexp.Schemas);

            //Write out the imported schema to a C-Sharp file
            using (FileStream fs = new FileStream("sample.cs", FileMode.Create))
            {
                TextWriter tw = new StreamWriter(fs);
                CodeDomProvider cdp = new Microsoft.CSharp.CSharpCodeProvider();
                cdp.GenerateCodeFromCompileUnit(xsdimp.CodeCompileUnit, tw, null);
                tw.Flush();
            }

            Console.WriteLine("\n\n To see the results of schema export and import,");
            Console.WriteLine(" see SAMPLE.XSD and SAMPLE.CS.\n");

            Console.WriteLine(" Press ENTER to terminate the sample.\n");
            Console.ReadLine();
        }
    }


    // This is the Employee (outer) type used in the sample.
    [DataContract]
    class Employee
    {
        [DataMember]
        public DateTime date_hired;

        [DataMember]
        public Decimal salary;

        [DataMember]
        public Person person;
    }

    // This is the Person (inner) type used in the sample.
    // Note that it is a legacy XmlSerializable type and not a DataContract type
    public class Person
    {
        [XmlElement("FirstName")]
        public string first_name;

        [XmlElement("LastName")]
        public string last_name;

        [XmlAttribute("Age")]
        public int age;

        public Person() { }
    }

    // This is the surrogated version of the Person type
    // that will be used for its serialization/deserialization.
    [DataContract]
    class PersonSurrogated
    {
        [DataMember]
        public string xmlData;
        //xmlData will store the XML returned for a Person instance by the XmlSerializer
    }

    //This is the surrogate that substitutes PersonSurrogated for Person
    class LegacyPersonTypeSurrogate : IDataContractSurrogate
    {

        #region IDataContractSurrogate Members

        public Type GetDataContractType(Type type)
        {
            // "Person" will be serialized as "PersonSurrogated"
            // This method is called during serialization and schema export
            if (typeof(Person).IsAssignableFrom(type))
            {
                return typeof(PersonSurrogated);
            }
            return type;
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            //This method is called on serialization.
            //If we're serializing Person,...
            if (obj is Person)
            {
                // ... we use the XmlSerializer to perform the actual serialization
                PersonSurrogated ps = new PersonSurrogated();
                XmlSerializer xs = new XmlSerializer(typeof(Person));
                StringWriter sw = new StringWriter();
                xs.Serialize(sw, (Person)obj);
                ps.xmlData = sw.ToString();
                return ps;
            }
            return obj;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            //This method is called on deserialization.
            //If we're deserializing PersonSurrogated,...
            if (obj is PersonSurrogated)
            {
                //... we use the XmlSerializer to do the actual deserialization
                PersonSurrogated ps = (PersonSurrogated)obj;
                XmlSerializer xs = new XmlSerializer(typeof(Person));
                return (Person)xs.Deserialize(new StringReader(ps.xmlData));
            }
            return obj;
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            // This method is called on schema import.

            // What we say here is that if we see a PersonSurrogated data contract in the specified namespace,
            // we should not create a new type for it since we already have an existing type, "Person".
            if (typeNamespace.Equals("http://schemas.datacontract.org/2004/07/DCSurrogateSample"))
            {
                if (typeName.Equals("PersonSurrogated"))
                {
                    return typeof(Person);
                }
            }
            return null;
        }

        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            // Not used in this sample.
            // We could use this method to construct an entirely new CLR type when a certain type is imported.
            return typeDeclaration;
        }


        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            // Not used in this sample
            return null;
        }

        public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
        {
            // Not used in this sample
            return null;
        }

        public void GetKnownCustomDataTypes(KnownTypeCollection customDataTypes)
        {
            // Not used in this sample
            throw new NotImplementedException();
        }

        #endregion
    }

}
