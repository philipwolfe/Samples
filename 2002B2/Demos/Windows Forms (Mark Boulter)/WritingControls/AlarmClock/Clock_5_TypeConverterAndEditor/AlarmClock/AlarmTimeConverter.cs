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
    using System.Collections;
    using System.ComponentModel;
    using System.Reflection;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Globalization;
    using System.ComponentModel.Design.Serialization;
    
    /// <summary>
    ///    <para>
    ///       The TypeConverter for AlarmTime - allows us to persist the control
    ///       even though it is not a Component
    ///    </para>
    /// </summary>
    public sealed class AlarmTimeConverter : ExpandableObjectConverter {
    

        /// <summary>
        ///    <para>
        ///         Returns true if the object can be converted to an instance of the given type
        ///         In this case we support converting AlarmTimes to InstanceDescriptors for 
        ///         designer code generation 
        ///    </para>
        /// </summary>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof(InstanceDescriptor)) {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        ///    <para>
        ///         Converts the given object to another type.  In this case we support 
        ///         conversion to an InstanceDescriptor. An InstanceDescriptor contains 
        ///         sufficient information to create a new instance of the object. It is 
        ///         used by the designer code engine. The code below looks complex because 
        ///         we are being careful to call the optimal constructor. We invoke any 
        ///         constructor, passing in null or default values for parameters we don't 
        ///         care about, but it is not asnice for the user.
        ///         If we cannot convert to the destination type, this method will throw
        ///         a NotSupportedException.
        ///    </para>
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == null) {
                throw new ArgumentNullException("destinationType");
            }

            if (destinationType == typeof(InstanceDescriptor) && value is AlarmTime) {
                AlarmTime item = (AlarmTime)value;
                ConstructorInfo ctor;
                
                if (item.Time != AlarmTime.DefaultTime && item.Color != AlarmTime.DefaultColor && item.AlarmTimeShape != AlarmTime.DefaultAlarmTimeShape) {
                    ctor = typeof(AlarmTime).GetConstructor(new Type[] { typeof(TimePattern),
                                                                           typeof(Color),
                                                                           typeof(AlarmTimeShape)
                    });
                    if (ctor != null) {
                        return new InstanceDescriptor(ctor, new object[] {
                                                                             item.Time,
                                                                             item.Color,
                                                                             item.AlarmTimeShape});
                    }
                }

                if (item.Time != AlarmTime.DefaultTime && item.Color != AlarmTime.DefaultColor) {
                    ctor = typeof(AlarmTime).GetConstructor(new Type[] { typeof(TimePattern),
                                                                           typeof(Color)
                    });
                    if (ctor != null) {
                        return new InstanceDescriptor(ctor, new object[] {
                                                                             item.Time,
                                                                             item.Color});
                    }
                }
                                      
                if (item.Time != AlarmTime.DefaultTime && item.AlarmTimeShape != AlarmTime.DefaultAlarmTimeShape) {
                    ctor = typeof(AlarmTime).GetConstructor(new Type[] { typeof(TimePattern),
                                                                           typeof(AlarmTimeShape)
                    });
                    if (ctor != null) {
                        return new InstanceDescriptor(ctor, new object[] {
                                                                             item.Time,
                                                                             item.AlarmTimeShape});
                    }
                }

                if (item.Color != AlarmTime.DefaultColor && item.AlarmTimeShape != AlarmTime.DefaultAlarmTimeShape) {
                    ctor = typeof(AlarmTime).GetConstructor(new Type[] { typeof(Color),
                                                                           typeof(AlarmTimeShape)
                    });
                    if (ctor != null) {
                        return new InstanceDescriptor(ctor, new object[] {
                                                                             item.Color,
                                                                             item.AlarmTimeShape});
                    }
                }

                if (item.Time != AlarmTime.DefaultTime) {
                    ctor = typeof(AlarmTime).GetConstructor(new Type[] { typeof(TimePattern) });
                    if (ctor != null) {
                        return new InstanceDescriptor(ctor, new object[] {item.Time});
                    }
                }

                if (item.Color != AlarmTime.DefaultColor) {
                    ctor = typeof(AlarmTime).GetConstructor(new Type[] { typeof(Color) });
                    if (ctor != null) {
                        return new InstanceDescriptor(ctor, new object[] {item.Color});
                    }
                }

                if (item.AlarmTimeShape != AlarmTime.DefaultAlarmTimeShape) {
                    ctor = typeof(AlarmTime).GetConstructor(new Type[] { typeof(AlarmTimeShape) });
                    if (ctor != null) {
                        return new InstanceDescriptor(ctor, new object[] {item.AlarmTimeShape});
                    }
                }
                
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}


