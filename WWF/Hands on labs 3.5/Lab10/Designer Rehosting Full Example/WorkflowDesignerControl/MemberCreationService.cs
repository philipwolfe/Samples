//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

namespace WorkflowDesignerControl
{
    #region Using Statements
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Workflow.ComponentModel.Design;
    using System.CodeDom;
    using System.Reflection;
    using System.CodeDom.Compiler;
    using System.Workflow.ComponentModel.Compiler;
    using System.ComponentModel.Design;
    using System.Workflow.ComponentModel;
    using Microsoft.CSharp;

    #endregion

    #region MemberCreationService

    internal class MemberCreationService : IMemberCreationService
    {
        private const string DependencyPropertyInit_CS = "DependencyProperty.Register(\"{0}\", typeof({1}), typeof({2}){3})";
        private const string DependencyPropertyOption = ", new PropertyMetadata({0})";

        private WorkflowLoader loader = null;
        private IServiceProvider serviceProvider = null;
        private CodeDomProvider provider = null;
        protected const BindingFlags baseMemberBindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

        internal MemberCreationService(IServiceProvider serviceProvider, WorkflowLoader loader)
        {
            this.serviceProvider = serviceProvider;
            this.loader = loader;
            this.provider = new CSharpCodeProvider();
        }

        #region IMemberCreationService Members

        public void CreateField(string className, string fieldName, Type fieldType, Type[] genericParameterTypes, MemberAttributes attributes, CodeSnippetExpression initializationExpression, bool overwriteExisting)
        {
            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException("className");
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("fieldName");
            if (fieldType == null)
                throw new ArgumentNullException("fieldType");
            if (fieldName == null)
                throw new ArgumentNullException("fieldName");

            if (!this.CodeProvider.IsValidIdentifier(fieldName))
                throw new ArgumentException();

            //If the classname is null then check if we can emit in the class being designed
            if (DoesFieldExist(className, fieldName))
            {
                if (overwriteExisting == true)
                    RemoveField(className, fieldName);
                else
                    throw new Exception("Error_DifferentTypeFieldExists");
            }

            Type type = null;
            if ((genericParameterTypes != null) && (fieldType.IsGenericTypeDefinition))
                type = fieldType.MakeGenericType(genericParameterTypes);
            else
                type = fieldType;

            // prepare field
            CodeMemberField field = new CodeMemberField();
            field.Name = fieldName;
            field.Type = GetCodeTypeReference(className, type);
            field.UserData["UserVisible"] = true;
            field.Attributes = attributes;

            if (initializationExpression == null)
            {
                string formattedType = FormatType(type);
                if (type.GetConstructor(Type.EmptyTypes) != null)
                    field.InitExpression = new CodeSnippetExpression("new " + formattedType + "()");
                else
                    field.InitExpression = new CodeSnippetExpression("default(" + formattedType + ")");
            }
            else
            {
                field.InitExpression = initializationExpression;
            }

            string nsName = null;
            Helpers.GetNamespaceAndClassName(className, out nsName, out className);

            // Get the type declaration from code compile unit
            CodeTypeDeclaration typeDeclaration = GetCodeTypeDeclFromCodeCompileUnit(nsName, className);

            int index = 0;
            foreach (CodeTypeMember member in typeDeclaration.Members)
            {
                if (member is CodeMemberField)
                    index++;
                else
                    break;
            }

            //push the field into the code compile unit
            typeDeclaration.Members.Insert(index, field);
            field.Type.UserData[typeof(Type)] = fieldType;

            // refresh the code compile unit
            TypeProvider typeProvider = (TypeProvider)this.serviceProvider.GetService(typeof(ITypeProvider));
            typeProvider.RefreshCodeCompileUnit(this.loader.CodeBesideCCU, new EventHandler(RefreshCCU));
        }

        public void RemoveField(string className, string fieldName)
        {
            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException("className");
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("fieldName");

            string nsName = null;
            Helpers.GetNamespaceAndClassName(className, out nsName, out className);

            CodeTypeDeclaration typeDeclaration = GetCodeTypeDeclFromCodeCompileUnit(nsName, className);
            CodeTypeMemberCollection fields = typeDeclaration.Members;

            CodeMemberField fieldToRemove = null;
            if (fields != null)
            {
                foreach (CodeTypeMember member in fields)
                {
                    if (member is CodeMemberField)
                    {
                        CodeMemberField field = (CodeMemberField)member;
                        if (field.Name == fieldName)
                        {
                            fieldToRemove = field;
                        }
                        else if (String.Compare(field.Name, fieldName, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            fieldToRemove = field;
                        }
                    }
                }

                if (fieldToRemove != null)
                    fields.Remove(fieldToRemove);
            }
            if (fieldToRemove == null)
                throw new Exception(fieldName);

            ITypeProvider typeProvider = this.ServiceProvider.GetService(typeof(ITypeProvider)) as ITypeProvider;
            if (typeProvider == null)
                throw new InvalidOperationException(typeof(ITypeProvider).FullName);
            ((TypeProvider)typeProvider).RefreshCodeCompileUnit(this.loader.CodeBesideCCU, new EventHandler(RefreshCCU));

        }

        public void CreateProperty(string className, string propertyName, Type propertyType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty, bool isAttached, Type ownerType, bool isReadOnly)
        {
            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException("className");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyName");
            if (propertyType == null)
                throw new ArgumentNullException("propertyType");

            if (!this.CodeProvider.IsValidIdentifier(propertyName))
                throw new ArgumentException("Invalid Identifier");

            if (!this.DoesPropertyExist(className, propertyName, propertyType))
            {
                // create property
                CodeMemberProperty property = new CodeMemberProperty();
                property.Name = propertyName;
                property.Type = GetCodeTypeReference(className, propertyType);
                property.Attributes = MemberAttributes.Public | MemberAttributes.Final;

                // add property attributes
                if (attributes != null)
                {
                    foreach (AttributeInfo attribute in attributes)
                    {
                        CodeTypeReference attributeTypeRef = GetCodeTypeReference(className, attribute.AttributeType);
                        CodeAttributeDeclaration attribDecl = new CodeAttributeDeclaration(attributeTypeRef);
                        foreach (object param in attribute.ArgumentValues)
                        {
                            if (param is CodeExpression)
                                attribDecl.Arguments.Add(new CodeAttributeArgument(param as CodeExpression));
                        }
                        property.CustomAttributes.Add(attribDecl);
                    }
                }

                // Create private field to hold the property's data
                IDesignerHost host = this.ServiceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (host == null)
                    throw new InvalidOperationException(typeof(IDesignerHost).FullName);

                ITypeProvider typeProvider = this.ServiceProvider.GetService(typeof(ITypeProvider)) as ITypeProvider;
                if (typeProvider == null)
                    throw new InvalidOperationException(typeof(ITypeProvider).FullName);

                string fieldName = null;
                if (emitDependencyProperty)
                {
                    fieldName = propertyName + "Property";
                    property.UserData["_vsDependencyPropertyFieldKey"] = fieldName;
                    if (!isAttached)
                        CreateStaticFieldForDependencyProperty(className, propertyName, propertyType, fieldName, isMetaProperty, false);
                }
                else
                {
                    bool existingField = false;
                    //We recreate the field everytime, this is done for the dynamic properties
                    fieldName = GeneratePropertyAssociatedFieldName(className, propertyName, propertyType, out existingField);
                    if (!existingField)
                        CreateField(className, fieldName, propertyType, null, MemberAttributes.Private, null, true);
                }

                // Add getter and setter logic to retrieve and assign the value to the new private field
                if (emitDependencyProperty)
                {
                    CodeFieldReferenceExpression fieldRef = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(isAttached ? ownerType.FullName : className), fieldName);

                    property.HasGet = true;
                    CodeTypeReference typeRef = new CodeTypeReference(propertyType);

                    property.GetStatements.Add(new CodeMethodReturnStatement(new CodeCastExpression(typeRef, new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), "GetValue", fieldRef))));

                    if (!isReadOnly)
                    {
                        property.HasSet = true;
                        property.SetStatements.Add(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), "SetValue", fieldRef, new CodeSnippetExpression("value")));
                    }
                }
                else
                {
                    property.HasGet = true;
                    property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName)));

                    if (!isReadOnly)
                    {
                        property.HasSet = true;
                        CodeExpression ifNOTDesignModeExpression = new CodeBinaryOperatorExpression(new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "DesignMode"), CodeBinaryOperatorType.ValueEquality, new CodePrimitiveExpression(false));
                        property.SetStatements.Add(new CodeConditionStatement(ifNOTDesignModeExpression, new CodeThrowExceptionStatement(new CodeObjectCreateExpression(typeof(InvalidOperationException), new CodeExpression[] { }))));
                        property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName), new CodeSnippetExpression("value")));
                    }
                }

                string nsName = null;
                Helpers.GetNamespaceAndClassName(className, out nsName, out className);

                CodeTypeDeclaration typeDeclaration = GetCodeTypeDeclFromCodeCompileUnit(nsName, className);

                int index = 0;
                foreach (CodeTypeMember member in typeDeclaration.Members)
                {
                    if (member is CodeMemberProperty)
                        index++;
                    else
                        break;
                }

                typeDeclaration.Members.Insert(index, property);
                ((TypeProvider)typeProvider).RefreshCodeCompileUnit(this.loader.CodeBesideCCU, new EventHandler(RefreshCCU));
            }
        }

        public void UpdateProperty(string className, string oldPropertyName, Type oldPropertyType, string newPropertyName, Type newPropertyType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty)
        {
            throw new NotImplementedException();
        }

        public void RemoveProperty(string className, string propertyName, Type propertyType)
        {
            throw new NotImplementedException();
        }

        public void CreateEvent(string className, string eventName, Type eventType, AttributeInfo[] attributes, bool emitDependencyProperty)
        {
            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException("className");
            if (string.IsNullOrEmpty(eventName))
                throw new ArgumentNullException("eventName");
            if (eventType == null)
                throw new ArgumentNullException("eventType");
            if (!this.CodeProvider.IsValidIdentifier(eventName))
                throw new ArgumentException();

            if (!this.DoesEventExist(className, eventName, eventType))
            {
                // create event
                CodeMemberEvent eventInfo = new CodeMemberEvent();
                eventInfo.Name = eventName;
                eventInfo.Type = new CodeTypeReference(eventType);
                eventInfo.Type.UserData["_vsEventHandlerTypeKey"] = eventType;
                eventInfo.Attributes = MemberAttributes.Public | MemberAttributes.Final;

                // add custom attributes
                if (attributes != null)
                {
                    foreach (AttributeInfo attribute in attributes)
                    {
                        CodeTypeReference attributeTypeRef = GetCodeTypeReference(className, attribute.AttributeType);
                        CodeAttributeDeclaration attribDecl = new CodeAttributeDeclaration(attributeTypeRef);
                        foreach (object param in attribute.ArgumentValues)
                        {
                            if (param is CodeExpression)
                                attribDecl.Arguments.Add(new CodeAttributeArgument(param as CodeExpression));
                        }
                        eventInfo.CustomAttributes.Add(attribDecl);
                    }
                }

                // Add getter and setter logic to retrieve and assign the value to the new private field
                if (emitDependencyProperty)
                {
                    // Create static field for the dependency property.
                    string fieldName = eventName + "Event";
                    CreateStaticFieldForDependencyProperty(className, eventName, eventType, fieldName, false, true);
                    eventInfo.UserData["_vsEventHandlerTypeKey"] = fieldName;
                }

                string nsName = null;
                Helpers.GetNamespaceAndClassName(className, out nsName, out className);

                CodeTypeDeclaration typeDeclaration = GetCodeTypeDeclFromCodeCompileUnit(nsName, className);

                int index = 0;
                foreach (CodeTypeMember member in typeDeclaration.Members)
                {
                    if (member is CodeMemberEvent)
                        index++;
                    else
                        break;
                }

                ITypeProvider typeProvider = this.ServiceProvider.GetService(typeof(ITypeProvider)) as ITypeProvider;
                if (typeProvider == null)
                    throw new InvalidOperationException(typeof(ITypeProvider).FullName);
                typeDeclaration.Members.Insert(index, eventInfo);
                ((TypeProvider)typeProvider).RefreshCodeCompileUnit(this.loader.CodeBesideCCU, new EventHandler(RefreshCCU));
            }

        }

        public void UpdateEvent(string className, string oldEventName, Type oldEventType, string newEventName, Type newEventType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty)
        {
            throw new NotImplementedException();
        }

        public void RemoveEvent(string className, string eventName, Type eventType)
        {
            throw new NotImplementedException();
        }

        public void ShowCode(Activity contextActivity, string methodName, Type delegateType)
        {
            throw new NotImplementedException();
        }

        public void ShowCode()
        {
            throw new NotImplementedException();
        }

        public void ShowCode(string fileName)
        {
            throw new NotImplementedException();
        }

        public void UpdateBaseType(string className, Type baseType)
        {
            throw new NotImplementedException();
        }

        public void UpdateTypeName(string oldClassName, string newClassName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Internal Methods

        internal static string FormatType(Type type)
        {
            string typeName = string.Empty;
            if (type.IsArray)
            {
                typeName = FormatType(type.GetElementType());
                typeName += '[';
                typeName += new string(',', type.GetArrayRank() - 1);
                typeName += ']';
            }
            else
            {
                typeName = type.FullName;
                int indexOfSpecialChar = typeName.IndexOf('`');
                if (indexOfSpecialChar != -1)
                    typeName = typeName.Substring(0, indexOfSpecialChar);
                typeName = typeName.Replace('+', '.');

                if (type.ContainsGenericParameters || type.IsGenericType)
                {
                    Type[] genericArguments = type.GetGenericArguments();
                    typeName += '<';
                    bool first = true;
                    foreach (Type genericArgument in genericArguments)
                    {
                        if (!first)
                            typeName += ", ";
                        else
                        {
                            first = false;
                        }
                        typeName += FormatType(genericArgument);
                    }

                    typeName += '>';
                }
            }
            return typeName;
        }

        #endregion

        #region Private Methods

        private void RefreshCCU(object sender, EventArgs e)
        {   
            // we dont want to do anything here
        }

        #endregion

        #region Helper Properties

        private WorkflowLoader Loader
        {
            get
            {
                return this.loader;
            }
        }
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.serviceProvider;
            }
        }
        private CodeDomProvider CodeProvider
        {
            get
            {
                return this.provider;
            }
        }
        private Activity RootActivity
        {
            get
            {
                IDesignerHost host = this.ServiceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (host == null)
                    throw new InvalidOperationException(typeof(IDesignerHost).FullName);

                return host.RootComponent as Activity;
            }
        }

        #endregion

        #region Helper Methods

        private string GeneratePropertyAssociatedFieldName(string className, string propertyName, Type propertyType, out bool exisitingField)
        {
            exisitingField = false;

            IIdentifierCreationService identCreationService = this.ServiceProvider.GetService(typeof(IIdentifierCreationService)) as IIdentifierCreationService;
            if (identCreationService == null)
                throw new InvalidOperationException();

            string baseFieldName = "_";
            if (propertyName.StartsWith("@"))
                baseFieldName += propertyName.Substring(1);
            else
                baseFieldName += propertyName;

            bool validIdent = false;
            int identCount = 1;
            string fieldName = String.Empty;
            while (!validIdent && identCount < Int32.MaxValue)
            {
                fieldName = baseFieldName + System.Convert.ToString(identCount);

                try
                {
                    identCreationService.ValidateIdentifier(RootActivity, fieldName);
                    validIdent = true;

                    //See if the field already exists, and if it's the same type
                    if (DoesFieldExist(className, fieldName, propertyType))
                        exisitingField = true;
                    else if (DoesFieldExist(className, fieldName))
                        validIdent = false;
                }
                catch
                {
                    validIdent = false;
                }

                identCount += 1;
            }

            return fieldName;
        }

        private bool DoesFieldExist(string className, string fieldName)
        {
            return DoesFieldExist(className, fieldName, null);
        }

        private bool DoesFieldExist(string className, string fieldName, Type fieldType)
        {
            if (className == null || className.Length == 0)
                return false;

            ITypeProvider typeProvider = (ITypeProvider)this.ServiceProvider.GetService(typeof(ITypeProvider));
            if (typeProvider == null)
                throw new Exception("Error_MissingTypeProvider");

            Type typeDeclaration = typeProvider.GetType(className, true);
            foreach (FieldInfo member in typeDeclaration.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
            {
                if (fieldType == null || member.FieldType == fieldType)
                {
                    if (member.Name == fieldName)
                        return true;
                }
            }
            return false;
        }

        private bool DoesPropertyExist(string className, string propertyName, Type propertyType)
        {
            if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(propertyName) || propertyType == null)
                return false;

            ITypeProvider typeProvider = (ITypeProvider)this.ServiceProvider.GetService(typeof(ITypeProvider));
            if (typeProvider == null)
                throw new Exception("Error_MissingTypeProvider");

            Type typeDeclaration = typeProvider.GetType(className, true);
            foreach (PropertyInfo property in typeDeclaration.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (property.Name == propertyName && property.PropertyType == propertyType)
                    return true;
            }

            return false;
        }

        private bool DoesEventExist(string className, string eventName, Type eventHandlerType)
        {
            if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(eventName) || eventHandlerType == null)
                return false;

            ITypeProvider typeProvider = (ITypeProvider)this.ServiceProvider.GetService(typeof(ITypeProvider));
            if (typeProvider == null)
                throw new Exception("Error_MissingTypeProvider");

            Type typeDeclaration = typeProvider.GetType(className, true);
            foreach (EventInfo eventInfo in typeDeclaration.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (eventInfo.Name == eventName && eventInfo.EventHandlerType == eventHandlerType)
                    return true;
            }

            return false;
        }

        private CodeTypeReference GetCodeTypeReference(string className, Type type)
        {
            CodeTypeReference codeTypeReference = new CodeTypeReference();
            codeTypeReference.ArrayRank = 0;
            codeTypeReference.ArrayElementType = null;
            codeTypeReference.BaseType = type.FullName;
            return codeTypeReference;
        }

        private CodeTypeDeclaration GetCodeTypeDeclFromCodeCompileUnit(string nsName, string className)
        {
            CodeTypeDeclaration typeDeclaration = null;
            foreach (CodeNamespace ns in this.loader.CodeBesideCCU.Namespaces)
            {
                if (ns.Name == nsName)
                {
                    foreach (CodeTypeDeclaration decl in ns.Types)
                    {
                        if (decl.Name == className)
                        {
                            typeDeclaration = decl;
                            break;
                        }
                    }
                }
            }
            return typeDeclaration;
        }

        private void CreateStaticFieldForDependencyProperty(string className, string propertyName, Type propertyType, string fieldName, bool isMetaProperty, bool isEvent)
        {
            //Emit the DependencyProperty.Register statement
            CodeSnippetExpression initExpression = (CodeSnippetExpression)CreateStaticFieldInitExpression(className, propertyName, propertyType.FullName, TypeProvider.IsAssignable(typeof(Delegate), propertyType), isMetaProperty, isEvent);
            CreateField(className, fieldName, typeof(DependencyProperty), null, MemberAttributes.Public | MemberAttributes.Static, initExpression, true);
        }

        private CodeExpression CreateStaticFieldInitExpression(string className, string propertyName, string propTypeName, bool isDelegateType, bool isMetaProperty, bool isEvent)
        {
            CodeSnippetExpression initExpression = new CodeSnippetExpression();
            const string DependencyPropertyInit_CS = "DependencyProperty.Register(\"{0}\", typeof({1}), typeof({2}){3})";
            const string DependencyPropertyOption = ", new PropertyMetadata({0})";

            string metaOptions = string.Empty;
            if (isMetaProperty)
                metaOptions = "DependencyPropertyOptions.Metadata";
            if (!isEvent && isDelegateType)
            {
                if (!string.IsNullOrEmpty(metaOptions))
                {
                    metaOptions += " | ";
                    metaOptions += "DependencyPropertyOptions.DelegateProperty";
                }
                else
                    metaOptions = "DependencyPropertyOptions.DelegateProperty";
            }

            if (!string.IsNullOrEmpty(metaOptions))
                metaOptions = string.Format(DependencyPropertyOption, metaOptions);


            initExpression.Value = String.Format(DependencyPropertyInit_CS, propertyName, propTypeName, className, metaOptions);

            return initExpression;
        }

        #endregion
    }
    #endregion
}
