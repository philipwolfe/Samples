using System;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {
    public class ThrowTypedFault : Activity {
        internal static readonly DependencyProperty FaultTypeProperty = DependencyProperty.Register("FaultType",typeof(Type),typeof(ThrowTypedFault),new PropertyMetadata(DependencyPropertyOptions.Metadata));

        public static readonly DependencyProperty FaultMessageProperty = DependencyProperty.Register("FaultMessage",typeof(string),typeof(ThrowTypedFault));

        public Type FaultType {
            get {
                return base.GetValue(FaultTypeProperty) as Type;
            }
            set {
                base.SetValue(FaultTypeProperty, value);
            }
        }

        public string FaultMessage {
            get {
                return base.GetValue(FaultMessageProperty) as string;
            }
            set {
                base.SetValue(FaultMessageProperty, value);
            }
        }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            System.Reflection.ConstructorInfo c = FaultType.GetConstructor(new Type[] { typeof(System.String) } );
            Exception e = c.Invoke(new object[] { FaultMessage }) as Exception;

            throw e;
        }
    }
}
