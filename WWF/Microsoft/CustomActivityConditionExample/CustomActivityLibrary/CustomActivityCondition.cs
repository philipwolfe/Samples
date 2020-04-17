//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.ComponentModel;
using System.Workflow.Activities.Rules;
using System.Collections;
using System.Globalization;

namespace CustomActivityLibrary
{    
    [DisplayName("Custom Activity Condition")]
    public class CustomActivityCondition : ActivityCondition
	{
        public override bool Evaluate(Activity activity, IServiceProvider provider)
        {
            return (this.customCondition.Equals("foo", StringComparison.CurrentCultureIgnoreCase));
        }

        private string customCondition = string.Empty;
        public string CustomCondition
        {
            get{ return this.customCondition; }
            set{ this.customCondition = value; }
        }
    }

    public class CustomActivityConditionTypeConverter : TypeConverter
    {
        private Hashtable conditionDecls = new Hashtable();

        public CustomActivityConditionTypeConverter()
        {
            AddTypeToHashTable(typeof(RuleConditionReference));
            AddTypeToHashTable(typeof(CodeCondition));
            AddTypeToHashTable(typeof(CustomActivityCondition));
        }

        private void AddTypeToHashTable(Type typeToAdd)
        {
            string key = typeToAdd.FullName;
            object[] attributes = typeToAdd.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            if (attributes != null && attributes.Length > 0 && attributes[0] is DisplayNameAttribute)
                key = ((DisplayNameAttribute)attributes[0]).DisplayName;
            this.conditionDecls.Add(key, typeToAdd);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                if (((string)value).Length == 0 || ((string)value) == "(None)")
                    return null;
                else
                    return Activator.CreateInstance(this.conditionDecls[value] as Type);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value == null)
                return "(None)";

            object convertedValue = null;
            if (destinationType == typeof(string) && value is ActivityCondition)
            {
                foreach (DictionaryEntry conditionTypeEntry in this.conditionDecls)
                {
                    if (value.GetType() == conditionTypeEntry.Value)
                    {
                        convertedValue = conditionTypeEntry.Key;
                        break;
                    }
                }
            }

            if (convertedValue == null)
                convertedValue = base.ConvertTo(context, culture, value, destinationType);

            return convertedValue;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ArrayList conditionDeclList = new ArrayList();

            conditionDeclList.Add(null);
            foreach (object key in this.conditionDecls.Keys)
            {
                Type declType = this.conditionDecls[key] as Type;
                conditionDeclList.Add(Activator.CreateInstance(declType));
            }
            return new StandardValuesCollection((ActivityCondition[])conditionDeclList.ToArray(typeof(ActivityCondition)));
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = new PropertyDescriptorCollection(new PropertyDescriptor[] { });

            TypeConverter typeConverter = TypeDescriptor.GetConverter(value.GetType());
            if (typeConverter != null && typeConverter.GetType() != GetType() && typeConverter.GetPropertiesSupported())
            {
                return typeConverter.GetProperties(context, value, attributes);
            }

            return props;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }    
    }
}
