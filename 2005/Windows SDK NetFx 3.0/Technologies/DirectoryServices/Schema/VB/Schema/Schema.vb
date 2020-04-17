'=====================================================================
'  File:     Schema.vb
'
'  Summary:  Demonstrates schema management related classes and methods.
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
'
'  Copyright (C) Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================

Imports System
Imports System.Security.Permissions
Imports System.DirectoryServices
Imports System.DirectoryServices.ActiveDirectory


<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")> 
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 
<Assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)> 


Namespace Microsoft.Samples.DirectoryServices

    Public NotInheritable Class SchemaSamples
        ' ldap display name of the schema class to search for
        Private Shared className As String = "user"
        ' ldap display name of the schema property to search for
        Private Shared propertyName As String = "sAMAccountName"

        ' properties of new schema class to be created 
        Private Shared newClassLdapDisplayName As String = "class2"
        Private Shared newClassOid As String = "1.2.3.4.10"
        Private Shared newClassCommonName As String = "Class2"
        Private Shared newClassSubClassOf As String = "top"

        ' already existing property
        Private Shared newClassOptionalProperty As String = "property1"

        ' properties of new schema property to be created 
        Private Shared newPropertyLdapDisplayName As String = "property2"
        Private Shared newPropertyOid As String = "1.2.3.4.5.10"
        Private Shared newPropertyCommonName As String = "Property2"
        Private Shared newPropertySyntax As _
                ActiveDirectorySyntax = ActiveDirectorySyntax.CaseIgnoreString

        ' what context to use (using current context here)
        Private Shared context As New DirectoryContext(DirectoryContextType.Forest)

        Private Sub New()
        End Sub

        Public Shared Sub Main()
            Try
                SchemaSample()
                SchemaClassSample()
                SchemaPropertySample()

                '
                ' uncomment the following to add a new class 
                ' and property to the schema 
                ' (the properties of the class and property have been 
                '  specified above as static variables
                '  which need to be modified as appropriate)
                '
                ' CreateNewClass();
                ' CreateNewProperty();
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine()
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            End Try
        End Sub 'Main

        Public Shared Sub SchemaSample()

            Console.WriteLine()
            Console.WriteLine("<---------SCHEMA Samples---------->")
            Console.WriteLine()

            ' get the schema associated with the current forest
            Dim schema As ActiveDirectorySchema

            Try
                schema = ActiveDirectorySchema.GetCurrentSchema()
            Catch e As ActiveDirectoryObjectNotFoundException
                ' current context is not associated with domain/forest
                Console.WriteLine(e.Message)
                Return
            End Try

            Console.WriteLine("Current schema: {0}", schema)
            Console.WriteLine()

            ' get all the abstract classes in the schema
            Console.WriteLine("All abstract schema classes:")
            Dim schemaClass As ActiveDirectorySchemaClass
            For Each schemaClass In _
                        schema.FindAllClasses(SchemaClassType.Abstract)
                Console.WriteLine(schemaClass)
            Next schemaClass
            Console.WriteLine()

            ' get all the defunct classes in the schema
            Console.WriteLine("All defunct schema classes:")

            For Each schemaClass In schema.FindAllDefunctClasses()
                Console.WriteLine(schemaClass)
            Next schemaClass
            Console.WriteLine()

            ' get all the properties that are indexed 
            ' and replicated to global catalog
            Console.WriteLine("All indexed properties that are also " + _
                                "replicated to global catalog:")
            Dim schemaProperty As ActiveDirectorySchemaProperty
            For Each schemaProperty In _
                schema.FindAllProperties((PropertyTypes.Indexed Or _
                                        PropertyTypes.InGlobalCatalog))
                Console.WriteLine(schemaProperty)
            Next schemaProperty
            Console.WriteLine()
        End Sub 'SchemaSample


        Public Shared Sub SchemaClassSample()

            Console.WriteLine()
            Console.WriteLine("<---------SCHEMA CLASS Sample---------->")
            Console.WriteLine()

            ' Find the schema class in the current forest 
            ' and print it's properties
            Dim schemaClass As ActiveDirectorySchemaClass = Nothing

            Try
                schemaClass = ActiveDirectorySchemaClass.FindByName(context, _
                                                                    className)
            Catch e As ArgumentException
                ' this exception could be thrown if the current context 
                ' is not associated any domain/forest
                Console.WriteLine(e.Message)
                Return
            Catch
            End Try

            Console.WriteLine("Name: {0}", schemaClass.Name)
            Console.WriteLine("Oid: {0}", schemaClass.Oid)
            Console.WriteLine("Description: {0}", schemaClass.Description)
            Console.WriteLine()
            Console.WriteLine("MandatoryProperties:")
            Dim schemaProperty As ActiveDirectorySchemaProperty
            For Each schemaProperty In schemaClass.MandatoryProperties
                Console.WriteLine(schemaProperty)
            Next schemaProperty
            Console.WriteLine()
            Console.WriteLine("Possible Superiors:")
            Dim supClass As ActiveDirectorySchemaClass
            For Each supClass In schemaClass.PossibleSuperiors
                Console.WriteLine(supClass)
            Next supClass
            Console.WriteLine()
            Console.WriteLine("SubClassOf: {0}", schemaClass.SubClassOf)
            Console.WriteLine("SchemaGuid: {0}", schemaClass.SchemaGuid)
        End Sub 'SchemaClassSample



        Public Shared Sub SchemaPropertySample()

            Console.WriteLine()
            Console.WriteLine("<---------SCHEMA PROPERTY Sample---------->")

            ' Find the schema property in the current forest 
            ' and print it's properties
            Dim schemaProperty As ActiveDirectorySchemaProperty = Nothing

            Try
                schemaProperty = ActiveDirectorySchemaProperty.FindByName(context, _
                                                                        propertyName)
            Catch e As ArgumentException
                ' this exception could be thrown if the current context 
                ' is not associated any domain/forest
                Console.WriteLine(e.Message)
                Return
            Catch
            End Try

            Console.WriteLine("Name: {0}", schemaProperty.Name)
            Console.WriteLine("Oid: {0}", schemaProperty.Oid)
            Console.WriteLine("Description: {0}", schemaProperty.Description)
            Console.WriteLine()

            ' limits on the length of the property (in this case this is length
            ' these could also mean upper and lower limits 
            ' values for value the property)
            Try
                Console.WriteLine("RangeLower: {0}", schemaProperty.RangeLower)
                Console.WriteLine("RangeUpper: {0}", schemaProperty.RangeUpper)
                Console.WriteLine()
            Catch
            End Try
            ' if these properties are not defined for the schema property, 
            ' ArgumentNullException is thrown

            ' other characteristics of the property
            Console.WriteLine("IsIndexed: {0}", schemaProperty.IsIndexed)
            Console.WriteLine("IsInGlobalCatalog: {0}", _
                                schemaProperty.IsInGlobalCatalog)
        End Sub 'SchemaPropertySample



        Public Shared Sub CreateNewProperty()
            ' create a new property object
            Dim newProperty As New ActiveDirectorySchemaProperty(context, _
                                                newPropertyLdapDisplayName)

            ' set the properties for this schema class
            newProperty.CommonName = newPropertyCommonName
            newProperty.Oid = newPropertyOid
            newProperty.IsSingleValued = True
            newProperty.Syntax = newPropertySyntax
            ' replicated to global catalog
            newProperty.IsInGlobalCatalog = True

            ' save the new class to the backend store
            Try
                newProperty.Save()
            Catch
            End Try
            ' a class by this name already exists 
            Console.WriteLine("Property ""{0}"" created successfully.", _
                                    newPropertyLdapDisplayName)
        End Sub 'CreateNewProperty


        Public Shared Sub CreateNewClass()
            ' create a new class object
            Dim newClass As New ActiveDirectorySchemaClass(context, _
                                                newClassLdapDisplayName)

            ' set the properties for this schema class
            newClass.CommonName = newClassCommonName
            newClass.Oid = newClassOid
            newClass.SubClassOf = _
                            ActiveDirectorySchemaClass.FindByName(context, _
                                newClassSubClassOf)
            newClass.Type = SchemaClassType.Structural
            ' adding the previously created property as an optional property
            newClass.OptionalProperties.Add( _
                ActiveDirectorySchemaProperty.FindByName(context, _
                                                    newClassOptionalProperty))

            ' save the new class to the backend store
            Try
                newClass.Save()
            Catch
            End Try
            ' a class by this name already exists 
            Console.WriteLine("Class ""{0}"" created successfully.", _
                                newClassLdapDisplayName)
        End Sub 'CreateNewClass
    End Class 'SchemaSamples
End Namespace 'Microsoft.Samples.DirectoryServices 