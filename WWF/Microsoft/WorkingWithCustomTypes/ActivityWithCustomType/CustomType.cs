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
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design.Serialization;
using System.Workflow.ComponentModel.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Drawing.Design;

namespace CustomTypeSerialization.ActivityWithCustomType
{
    [DesignerSerializer(typeof(MyTypeCodeDomSerializer), typeof(CodeDomSerializer))]
    [DesignerSerializer(typeof(MyTypeSerializer), typeof(WorkflowMarkupSerializer))]
    [EditorAttribute(typeof(MyTypeUITypeEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(MyTypeTypeConverter))]
    [Serializable()]
    public class MyType
    {
        string paramOne;
        string paramTwo;

        public MyType(string paramOne, string paramTwo)
        {
            ParamOne = paramOne;
            ParamTwo = paramTwo;
        }

        public string ParamOne
        {
            get{ return paramOne; }
            set{ paramOne = value; }
        }

        public string ParamTwo
        {
            get { return paramTwo; }
            set { paramTwo = value; }
        }

        public override string ToString()
        {
            return string.Format("ParamOne={0}, ParamTwo={1}", this.paramOne, this.paramTwo);
        }
    }

    public class MyTypeUITypeEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            CustomTypeEditor myTypeEditor = new CustomTypeEditor();

            if (value != null && value.GetType().IsAssignableFrom(typeof(MyType)))
            { 
                MyType myType = value as MyType;
                myTypeEditor.txtParamOne.Text = myType.ParamOne;
                myTypeEditor.txtParamTwo.Text = myType.ParamTwo;
            }

            if (myTypeEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return new MyType(myTypeEditor.txtParamOne.Text, myTypeEditor.txtParamTwo.Text);
            }
            else
            { 
                return base.EditValue(context, provider, value);
            }            
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext typeDescriptorContext)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }

    public class MyTypeCodeDomSerializer : CodeDomSerializer
    {
        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");

            if (manager.Context == null)
                throw new ArgumentException("Missing Context Property", "manager");

            if (value == null)
                return new CodePrimitiveExpression(null);

            MyType customType = value as MyType;
            if (customType == null)
                throw new ArgumentException("value property is not of type MyType", "value");

            return new CodeObjectCreateExpression(typeof(MyType), new CodeExpression[] { new CodePrimitiveExpression(customType.ParamOne), new CodePrimitiveExpression(customType.ParamTwo)});
        }
    }

    public class MyTypeSerializer : WorkflowMarkupSerializer
    {
        protected override bool CanSerializeToString(WorkflowMarkupSerializationManager serializationManager, object value)
        {
            return true;
        }

        protected override object DeserializeFromString(WorkflowMarkupSerializationManager serializationManager, Type propertyType, string value)
        {
            return Helper.Deserialize(value);
        }
    }

    public class MyTypeTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(MyType))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (context.PropertyDescriptor.PropertyType.IsAssignableFrom(typeof(MyType)) && destinationType == typeof(string))
            {
                if (value == null)
                {
                    return string.Empty;
                }
                else
                {
                    return (value as MyType).ToString();
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (context.PropertyDescriptor.PropertyType == typeof(MyType))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (context.PropertyDescriptor.PropertyType == typeof(MyType))
            {
                return Helper.Deserialize(value as string);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            ArrayList properties = new ArrayList();
            MyType customType = value as MyType;
            if (customType != null && context != null)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(value, new Attribute[] { BrowsableAttribute.Yes });
                
                properties.Add(props["ParamOne"]);
                properties.Add(props["ParamTwo"]);

                return new PropertyDescriptorCollection((PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor)));
            }
            return base.GetProperties(context, value, attributes);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    class Helper
    {
        public static MyType Deserialize(string stringValue)
        {
            MyType myType = null;

            if (!stringValue.Contains("x:Null"))
            {
                string[] parameters = stringValue.Split(new char[] { ',' }, 2);
                if (parameters.Length == 2)
                {
                    string paramOneMatch = "ParamOne=";
                    string paramTwoMatch = "ParamTwo=";
                    string paramOneVal = parameters[0].Trim();
                    string paramTwoVal = parameters[1].Trim();

                    if (paramOneVal.StartsWith(paramOneMatch, StringComparison.OrdinalIgnoreCase)
                        && paramTwoVal.StartsWith(paramTwoMatch, StringComparison.OrdinalIgnoreCase))
                    {
                        paramOneVal = paramOneVal.Substring(paramOneMatch.Length);
                        paramTwoVal = paramTwoVal.Substring(paramTwoMatch.Length);
                        myType = new MyType(paramOneVal, paramTwoVal);
                    }
                }
            }

            return myType;
        }
    }
}
