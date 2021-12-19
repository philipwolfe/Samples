'***********************************************************************
'* Task Interface
'* 
'* The Task Interface abstracts out the properties, methods, and events 
'* that are used for communication between a task and the controller of
'* the task.  
'*
'***********************************************************************
Public Interface Task
    '* StartTask is called to initiate execution of the background task
    Sub StartTask()

    '* PercentComplete is called to produce an estimate for how much of
    '* the work to be performed by the task has been completed
    Function PercentComplete() As Integer

    '* Property Name is the descriptive name of the task
    Property TaskName() As String

    ' Event OnTaskComplete raises a notification when a task is completed
    Event OnTaskComplete(ByVal Task As Task)

    ' Property Thread is the thread on which a task is run
    Property Thread() As Thread
End Interface

'***********************************************************************
'* Class TaskListItem
'* 
'* TaskListItem inherits from the ListItem control and adds a Task field.
'* This allows a task to be stored with each ListItem 
'***********************************************************************
Public Class TaskListItem
    Inherits System.Windows.Forms.ListViewItem
    Public Task As Task
    '***********************************************************************
    '* Constructor for TaskListItem
    '* 
    '* Create a new TaskListItem. The last two parameters are passed
    '* directly to the constructor of the base class.  The task parameter
    '* is stored in the task data member.
    '***********************************************************************
    Public Sub New(ByVal t As Task, ByVal rgstr() As String)        
        Call MyBase.New(rgstr)
        Task = t
    End Sub

End Class
