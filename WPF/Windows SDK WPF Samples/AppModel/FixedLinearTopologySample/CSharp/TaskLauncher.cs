namespace FixedLinearTopologySample
{
    using System;
    using System.Windows.Navigation;
    
    public class TaskLauncher : PageFunction<TaskContext>
    {
        TaskData taskData = new TaskData();
        
        protected override void Start()
        {
            base.Start();

            // Retain instance in navigation history until task is complete
            this.KeepAlive = true;
            
            // Launch the task
            TaskPage1 taskPage1 = new TaskPage1(this.taskData);
            taskPage1.Return += new ReturnEventHandler<TaskResult>(taskPage_Return);
            this.NavigationService.Navigate(taskPage1);
        }

        public void taskPage_Return(object sender, ReturnEventArgs<TaskResult> e)
        {
            // Task was completed (finished or canceled), return TaskResult and TaskData
            OnReturn(new ReturnEventArgs<TaskContext>(new TaskContext(e.Result, this.taskData)));
        }
    }
}
