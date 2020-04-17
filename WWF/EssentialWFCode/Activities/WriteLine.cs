using System;
using System.Workflow.ComponentModel;
using System.ComponentModel;
using EssentialWF.Services;


namespace EssentialWF.Activities {
    public class WriteLine : Activity {
        public static readonly DependencyProperty TextProperty =   DependencyProperty.Register("Text",typeof(string), typeof(WriteLine));
      
        public string Text {
          get { return (string) GetValue(TextProperty); }
          set { SetValue(TextProperty, value); }
        }
      
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            
          Console.WriteLine(this.Text);
          return ActivityExecutionStatus.Closed;
        }
    }

    public class AsyncWriteLine : Activity {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",typeof(string), typeof(AsyncWriteLine));

        public string Text {
          get { return (string) GetValue(TextProperty); }
          set { SetValue(TextProperty, value); }
        }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            base.Invoke(ContinueAt, EventArgs.Empty);
            return ActivityExecutionStatus.Executing;
        }
        void ContinueAt(object sender, EventArgs e) {
            ActivityExecutionContext context = sender as ActivityExecutionContext;

            WriterService writer = context.GetService<WriterService>();
            writer.Write(this.Text);

            context.CloseActivity();
        }
    }
}
