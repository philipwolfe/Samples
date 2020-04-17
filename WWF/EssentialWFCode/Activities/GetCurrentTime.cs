using System;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {
    public class GetCurrentTime : Activity {
        public static DependencyProperty TimeProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Time", typeof(string), typeof(GetCurrentTime));
        public string Time {
            get {return ((string)(base.GetValue(GetCurrentTime.TimeProperty)));}
            private set {base.SetValue(GetCurrentTime.TimeProperty, value);}
        }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext) {
            Time = DateTime.Now.ToString();
            return base.Execute(executionContext);
        }
    }
}