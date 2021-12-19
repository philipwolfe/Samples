'Contains the messagebox object
Imports System.Windows.Forms
Public Class SampleConstrDestr
    Public Sub New()
        MessageBox.Show("Classes use the New constructor instead of the Initalize event.")
    End Sub
    Public Sub Destruct()
        MessageBox.Show("Classes use the Destruct destructor instead of the Terminate event.")
        
    End Sub
    Protected Overrides Sub Finalize()
        MessageBox.Show("Garbage Collection calls Finalize after it detects there are no more references to the object.", "SampleConstrDestr:Finalize")
        MyBase.Finalize()
    End Sub
    
End Class

