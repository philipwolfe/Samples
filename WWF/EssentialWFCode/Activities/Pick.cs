using System;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;

namespace EssentialWF.Activities {
    
    [ActivityValidator(typeof(PickValidator))]
    public class Pick : CompositeActivity {

        public static readonly DependencyProperty FollowerOfProperty = DependencyProperty.RegisterAttached("FollowerOf",typeof(string),typeof(Pick),new PropertyMetadata(DependencyPropertyOptions.Metadata),typeof(FollowerOfAttachedPropertyValidator));
        public static object GetFollowerOf(object dependencyObject) {
          DependencyObject o = dependencyObject as DependencyObject;
          return o.GetValue(Pick.FollowerOfProperty);
        }

        public static void SetFollowerOf(object dependencyObject,object value){
          DependencyObject o = dependencyObject as DependencyObject;
          o.SetValue(Pick.FollowerOfProperty, value);
        }

        internal static bool IsLeader(Activity a) {
          return (Pick.GetFollowerOf(a) == null);
        }

        private bool firstLeaderDone;
        protected override void Initialize(IServiceProvider provider){
          firstLeaderDone = false;
          base.Initialize(provider);
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context){
          if (EnabledActivities.Count == 0)
            return ActivityExecutionStatus.Closed;

          // schedule execution of the leaders
          foreach (Activity child in EnabledActivities) {
            if (Pick.IsLeader(child)) {
              child.Closed += this.ContinueAt;
              context.ExecuteActivity(child);
            }
          }

          return ActivityExecutionStatus.Executing;
        }

        void ContinueAt(object sender, ActivityExecutionStatusChangedEventArgs e) {
            e.Activity.Closed -= this.ContinueAt;
            ActivityExecutionContext context = sender as ActivityExecutionContext;

            if (!firstLeaderDone) {
                // first leader is now completed
                firstLeaderDone = true;
                string leaderName = e.Activity.Name;

                // cancel the other leaders, if any
                int leadersCanceled = 0;
                foreach (Activity child in EnabledActivities) {
                  if (child.ExecutionStatus == ActivityExecutionStatus.Executing) {
                    context.CancelActivity(child);
                    leadersCanceled++;
                  }
                }

                // schedule execution of the followers, if any
                int followersExecuted = 0;
                foreach (Activity child in EnabledActivities) {
                    string s = Pick.GetFollowerOf(child) as string;
                    if (leaderName.Equals(s)) {
                        child.Closed += this.ContinueAt;
                        context.ExecuteActivity(child);
                        followersExecuted++;
                    }
                }
                if ((leadersCanceled + followersExecuted) == 0) {
                  // no cancelled leaders, and also no followers
                  context.CloseActivity();
                }
            }
            // a follower has completed
            else  {
                foreach (Activity child in EnabledActivities) {
                    ActivityExecutionStatus status = child.ExecutionStatus;

                    if ((status != ActivityExecutionStatus.Closed) && (status != ActivityExecutionStatus.Initialized)) {
                        // there is still at least 1 follower executing
                        return;
                    }
                }

                // all followers are done
                context.CloseActivity();
            }
        }

        // Cancellation logic
        //...
    }
    public class PickValidator : CompositeActivityValidator {

        public override ValidationErrorCollection Validate(ValidationManager manager, object obj) {
            ValidationErrorCollection errors = base.Validate(manager, obj);

            Pick pick = obj as Pick;
            foreach (Activity child in pick.EnabledActivities) {
            // there must be at least 1 leader
            if (Pick.IsLeader(child))
              return errors;
            }

            errors.Add(new ValidationError(@"At least one child of Pick must not carry the FollowerOf attached property", 200));

            return errors;
        }
    }
    public class FollowerOfAttachedPropertyValidator : Validator {
    
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj) {
            ValidationErrorCollection errors = base.Validate(manager, obj);

            string activityName = obj as string;
            if (activityName == null || activityName.Equals(string.Empty)) {
                errors.Add(new ValidationError(@"FollowerOf has null or empty value specified", 201));
                return errors;
            }

            Activity activity = manager.Context[typeof(Activity)] as Activity;
            Pick pick = activity.Parent as Pick;

            if (pick == null) {
                errors.Add(new ValidationError(@"FollowerOf must be applied to a child activity of Pick", 202));
                return errors;
            }

            Activity target = pick.Activities[activityName];
            if (target == null) {
                errors.Add(new ValidationError(@"FollowerOf must be the name of a child activity of Pick", 203));
                return errors;
            }

            if (target.Name.Equals(activity.Name)) {
                errors.Add(new ValidationError(@"FollowerOf cannot refer to the same activity to which it is attached", 204));
                return errors;
            }

            return errors;
       }
    }
}
