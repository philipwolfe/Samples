var vsTaskPriorityMedium = 2
var vsTaskIconUser = 5
var vsWindowKindTaskList = "{4A9B7E51-AA16-11D0-A8C5-00A0C921A4D2}"


/////////////////////////////////////////////////////////////////////////////////
//	Sample WSH script to work with the Visual Studio Object Model
// 	Connect to a new instance of Visual Studio, and add a task item
/////////////////////////////////////////////////////////////////////////////////

var TaskListObj
var TaskItemsObj
var TaskItemObj
var objDTE = WScript.CreateObject("VisualStudio.DTE");
objDTE.MainWindow.Visible = true;
objDTE.UserControl = true;
TaskListObj = objDTE.Windows.item(vsWindowKindTaskList).Object;
TaskItemsObj = TaskListObj.TaskItems;
TaskItemObj = TaskItemsObj.Add("UserReminder", "Reminder", "This is to remind you that you can use the WSH to automate Visual Studio", vsTaskPriorityMedium, vsTaskIconUser, true, "", 0, true);