using System;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {
    public class ThrowException : Activity {
        public static readonly DependencyProperty ExceptionProperty =DependencyProperty.Register("Exception",typeof(System.Exception),typeof(ThrowException));
        public Exception Exception {
            get {
                return base.GetValue(ExceptionProperty) as Exception;
            }
            set {
                base.SetValue(ExceptionProperty, value);
            }
        }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            if (Exception == null)
                throw new NullReferenceException("Exception is null");

            throw Exception;
        }
    }
}
