/*=====================================================================
  File:     Schema.cs

  Summary:  Demonstrates schema management related classes and methods.

---------------------------------------------------------------------
  This file is part of the Microsoft .NET SDK Code Samples.

  Copyright (C) Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

using System;
using System.Security.Permissions;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;


[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace Microsoft.Samples.DirectoryServices
{
    public class SchemaSamples
    {
        // ldap display name of the schema class to search for
        private static string className = "user";
        // ldap display name of the schema property to search for
        private static string propertyName = "sAMAccountName";

        // properties of new schema class to be created 
        private static string newClassLdapDisplayName = "class2";
        private static string newClassOid = "1.2.3.4.10";
        private static string newClassCommonName = "Class2";
        private static string newClassSubClassOf = "top";

        // already existing property
        private static string newClassOptionalProperty = "property1"; 

        // properties of new schema property to be created 
        private static string newPropertyLdapDisplayName = "property2";
        private static string newPropertyOid = "1.2.3.4.5.10";
        private static string newPropertyCommonName = "Property2";
        private static ActiveDirectorySyntax newPropertySyntax = 
                                         ActiveDirectorySyntax.CaseIgnoreString;

        // what context to use (using current context here)
        private static DirectoryContext context = 
                              new DirectoryContext(DirectoryContextType.Forest);

        public static void Main()
        {
          try
          {
            SchemaSample();
            SchemaClassSample();
            SchemaPropertySample();

            //
            // uncomment the following to add a new class 
            // and property to the schema 
            // (the properties of the class and property have been 
            //  specified above as static variables
            //  which need to be modified as appropriate)
            //
            // CreateNewClass();
            // CreateNewProperty();
          }
          catch (Exception e)
          {
            Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                              e.GetType().Name + ":" + e.Message);
          }          
        }

        public static void SchemaSample()
        {

            Console.WriteLine();
            Console.WriteLine("<---------SCHEMA Samples---------->\n");

            // get the schema associated with the current forest
            ActiveDirectorySchema schema;

            try
            {
                schema = ActiveDirectorySchema.GetCurrentSchema();
            }
            catch (ActiveDirectoryObjectNotFoundException e)
            {
                // current context is not associated with domain/forest
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Current schema: {0}", schema);
            Console.WriteLine();

            // get all the abstract classes in the schema
            Console.WriteLine("All abstract schema classes:");
            foreach (ActiveDirectorySchemaClass schemaClass in 
                                schema.FindAllClasses(SchemaClassType.Abstract))
            {
                Console.WriteLine(schemaClass);
            }
            Console.WriteLine();

            // get all the defunct classes in the schema
            Console.WriteLine("All defunct schema classes:");
            foreach (ActiveDirectorySchemaClass schemaClass in 
                                                 schema.FindAllDefunctClasses())
            {
                Console.WriteLine(schemaClass);
            }
            Console.WriteLine();

            // get all the properties that are indexed 
            // and replicated to global catalog
            Console.WriteLine("All indexed properties that are also "+
                                               "replicated to global catalog:");
            foreach (ActiveDirectorySchemaProperty schemaProperty in 
                                schema.FindAllProperties(
                                                 PropertyTypes.Indexed | 
                                                 PropertyTypes.InGlobalCatalog))
            {
                Console.WriteLine(schemaProperty);
            }
            Console.WriteLine();
        }

        public static void SchemaClassSample()
        {

            Console.WriteLine();
            Console.WriteLine("<---------SCHEMA CLASS Sample---------->\n");

            // Find the schema class in the current forest 
            // and print it's properties

            ActiveDirectorySchemaClass schemaClass;

            try
            {
                schemaClass = ActiveDirectorySchemaClass.FindByName(context, 
                                                                    className);
            }
            catch (ArgumentException e)
            {
                // this exception could be thrown if the current context 
                // is not associated any domain/forest
                Console.WriteLine(e.Message);
                return;
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                Console.WriteLine("Schema class \"{0}\" could not be found");
                return;
            }

            Console.WriteLine("Name: {0}", schemaClass.Name);
            Console.WriteLine("Oid: {0}", schemaClass.Oid);
            Console.WriteLine("Description: {0}", schemaClass.Description);
            Console.WriteLine();
            Console.WriteLine("MandatoryProperties:");
            foreach (ActiveDirectorySchemaProperty schemaProperty in 
                                                schemaClass.MandatoryProperties)
            {
                Console.WriteLine(schemaProperty);
            }
            Console.WriteLine();
            Console.WriteLine("Possible Superiors:");
            foreach (ActiveDirectorySchemaClass supClass in 
                                                  schemaClass.PossibleSuperiors)
            {
                Console.WriteLine(supClass);
            }
            Console.WriteLine();
            Console.WriteLine("SubClassOf: {0}", schemaClass.SubClassOf);
            Console.WriteLine("SchemaGuid: {0}", schemaClass.SchemaGuid);


        }

        public static void SchemaPropertySample()
        {

            Console.WriteLine();
            Console.WriteLine("<---------SCHEMA PROPERTY Sample---------->\n");

            // Find the schema property in the current forest 
            // and print it's properties

            ActiveDirectorySchemaProperty schemaProperty;

            try
            {
                schemaProperty = ActiveDirectorySchemaProperty.FindByName(
                                                                  context,
                                                                  propertyName);
            }
            catch (ArgumentException e)
            {
                // this exception could be thrown if the current context 
                // is not associated any domain/forest
                Console.WriteLine(e.Message);
                return;
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                Console.WriteLine("Schema property \"{0}\" could not be found");
                return;
            }

            Console.WriteLine("Name: {0}", schemaProperty.Name);
            Console.WriteLine("Oid: {0}", schemaProperty.Oid);
            Console.WriteLine("Description: {0}", schemaProperty.Description);
            Console.WriteLine();

            // limits on the length of the property (in this case this is length
            // these could also mean upper and lower limits 
            // values for value the property)
            try
            {
                Console.WriteLine("RangeLower: {0}", schemaProperty.RangeLower);
                Console.WriteLine("RangeUpper: {0}", schemaProperty.RangeUpper);
                Console.WriteLine();
            }
            catch (ArgumentNullException)
            {
                // if these properties are not defined for the schema property, 
                // ArgumentNullException is thrown
                Console.WriteLine("RangeLower/RangeUpper not defined.");
            }

            // other characteristics of the property
            Console.WriteLine("IsIndexed: {0}", schemaProperty.IsIndexed);
            Console.WriteLine("IsInGlobalCatalog: {0}", 
                                              schemaProperty.IsInGlobalCatalog);

        }

        public static void CreateNewProperty()
        {
            // create a new property object
            ActiveDirectorySchemaProperty newProperty = 
                                      new ActiveDirectorySchemaProperty(
                                                    context, 
                                                    newPropertyLdapDisplayName);

            // set the properties for this schema class
            newProperty.CommonName = newPropertyCommonName;
            newProperty.Oid = newPropertyOid;
            newProperty.IsSingleValued = true;
            newProperty.Syntax = newPropertySyntax;
            // replicated to global catalog
            newProperty.IsInGlobalCatalog = true;

            // save the new class to the backend store
            try
            {
                newProperty.Save();
            }
            catch (ActiveDirectoryObjectExistsException)
            {
                // a class by this name already exists 
                Console.WriteLine("FAILED to created new property.");
                return;
            }
            Console.WriteLine("Property \"{0}\" created successfully.", 
                                                    newPropertyLdapDisplayName);
        }

        public static void CreateNewClass()
        {
            // create a new class object
            ActiveDirectorySchemaClass newClass = 
                                            new ActiveDirectorySchemaClass(
                                                      context, 
                                                       newClassLdapDisplayName);

            // set the properties for this schema class
            newClass.CommonName = newClassCommonName;
            newClass.Oid = newClassOid;
            newClass.SubClassOf = ActiveDirectorySchemaClass.FindByName(
                                                            context, 
                                                            newClassSubClassOf);
            newClass.Type = SchemaClassType.Structural;
            // adding the previously created property as an optional property
            newClass.OptionalProperties.Add(
                                ActiveDirectorySchemaProperty.FindByName(
                                                     context, 
                                                     newClassOptionalProperty));

            // save the new class to the backend store
            try
            {
                newClass.Save();
            }
            catch (ActiveDirectoryObjectExistsException)
            {
                // a class by this name already exists 
                Console.WriteLine("FAILED to created new class.");
                return;
            }
            Console.WriteLine("Class \"{0}\" created successfully.", 
                                                       newClassLdapDisplayName);
        }

    }
}
