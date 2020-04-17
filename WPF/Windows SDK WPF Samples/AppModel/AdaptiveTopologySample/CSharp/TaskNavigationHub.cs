namespace AdaptiveTopologySample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Windows.Threading;

    public class TaskNavigationHub : PageFunction<TaskContext>
    {
        List<PageFunction<TaskResult>> navigationOrder = new List<PageFunction<TaskResult>>();
        TaskData taskData = new TaskData();
        static TaskNavigationHub taskNavigationHub;

        public TaskNavigationHub()
        {
            taskNavigationHub = this;
        }

        public static TaskNavigationHub Current
        {
            get { return taskNavigationHub; }
        }

        #region Navigation for determining the navigation order of the task
        protected override void Start()
        {
            // Keep this page function instance in navigation history until completion
            JournalEntry.SetKeepAlive(this, true);
            this.RemoveFromJournal = true;

            // Navigate to data entry page to determine navigation sequence
            DataEntryPage dataEntryPage = new DataEntryPage();
            dataEntryPage.Return += new ReturnEventHandler<TaskContext>(dataEntryPage_Return);
            this.NavigationService.Navigate(dataEntryPage);
        }
        void dataEntryPage_Return(object sender, ReturnEventArgs<TaskContext> e)
        {
            TaskContext dataEntryTaskContext = (TaskContext)e.Result;

            // Cancel task if data entry page was canceled
            if (dataEntryTaskContext.Result == TaskResult.Canceled)
            {
                OnReturn(new ReturnEventArgs<TaskContext>(new TaskContext(TaskResult.Canceled, null)));
                return;
            }

            // Organize navigation direction
            if ((TaskNavigationDirection)dataEntryTaskContext.Data == TaskNavigationDirection.Forwards)
            {
                this.navigationOrder.Add((PageFunction<TaskResult>)new TaskPage1(this.taskData));
                this.navigationOrder.Add((PageFunction<TaskResult>)new TaskPage2(this.taskData));
                this.navigationOrder.Add((PageFunction<TaskResult>)new TaskPage3(this.taskData));
            }
            else
            {
                this.navigationOrder.Add((PageFunction<TaskResult>)new TaskPage3(this.taskData));
                this.navigationOrder.Add((PageFunction<TaskResult>)new TaskPage2(this.taskData));
                this.navigationOrder.Add((PageFunction<TaskResult>)new TaskPage1(this.taskData));
            }

            // Navigate to first page
            this.navigationOrder[0].Return += NavigationHub_Return;
            NavigationWindow host = (NavigationWindow)Application.Current.MainWindow;
            host.Navigate(this.navigationOrder[0]);
        }
        #endregion

        public PageFunction<TaskResult> GetNextTaskPage(PageFunction<TaskResult> currentPageFunction)
        {
            int index = this.navigationOrder.IndexOf((PageFunction<TaskResult>)currentPageFunction);
            return this.navigationOrder[++index];
        }
        public bool CanGoNext(PageFunction<TaskResult> currentPageFunction) {
            int index = this.navigationOrder.IndexOf((PageFunction<TaskResult>)currentPageFunction);
            return (index < this.navigationOrder.Count - 1);
        }
        public bool CanGoBack(PageFunction<TaskResult> currentPageFunction)
        {
            int index = this.navigationOrder.IndexOf((PageFunction<TaskResult>)currentPageFunction);
            return (index > 0);
        }
        public bool CanFinish(PageFunction<TaskResult> currentPageFunction)
        {
            int index = this.navigationOrder.IndexOf((PageFunction<TaskResult>)currentPageFunction);
            return (index == this.navigationOrder.Count - 1);
        }
                
        void NavigationHub_Return(object sender, ReturnEventArgs<TaskResult> e)
        {
            // If returning, task was completed (finished or canceled),
            // so continue returning to calling page
            OnReturn(new ReturnEventArgs<TaskContext>(new TaskContext(e.Result, this.taskData)));
        }
    }
}