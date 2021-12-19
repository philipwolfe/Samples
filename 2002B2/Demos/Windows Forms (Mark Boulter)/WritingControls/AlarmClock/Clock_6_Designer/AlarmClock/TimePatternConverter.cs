//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace MyCompany.Controls {

    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.ComponentModel.Design.Serialization;
    using System.Reflection;

    public sealed class TimePatternConverter : TypeConverter {
    
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string)) {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof(InstanceDescriptor)) {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string) {
                string text = ((string)value).Trim();
                try {
                    return TimePattern.Parse(text);
                }
                catch(Exception e) {
                    throw new Exception(String.Format("Cannot convert '{0}' ({1}) into a TimeSpan object", value, value.GetType()), e);
                }
            }
            
            return base.ConvertFrom(context, culture, value);
        }
        
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == null) {
                throw new ArgumentNullException("destinationType");
            }

            if (destinationType == typeof(InstanceDescriptor) && value is TimePattern) {
                TimePattern tp = (TimePattern)value;
                MethodInfo parseMethod = typeof(TimePattern).GetMethod("Parse");
                if (parseMethod != null) {
                    return new InstanceDescriptor(parseMethod, new object[] {tp.ToString()});
                }
            }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }

    }
}


