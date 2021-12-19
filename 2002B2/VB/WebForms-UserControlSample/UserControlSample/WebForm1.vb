Option Strict On
Option Explicit On 

'The following Imports statements were auto-generated
Imports System
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Microsoft.VisualBasic

Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents AvailableSelected As UserControlSample.PairedListBox
    
#Region " Web Forms Designer Generated Code "

    Dim WithEvents WebForm1 As System.Web.UI.Page
    
    Sub New()
        WebForm1 = Me
    End Sub

    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()

    End Sub

#End Region
   
    Protected Sub WebForm1_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles WebForm1.load
        'This web form conta        
        If Not IsPostBack Then   ' Evals true first time browser hits the page
            'Populate an ArrayList with values for the source listbox            
            Dim al As New ArrayList()
            With al
                .Add("Apples")
                .Add("Bananas")
                .Add("Grapes")
                .Add("Oranges")
                .Add("Peaches")
                .Add("Pears")
                .Add("Plums")
            End With

            'Set properties on the user control
            With AvailableSelected
                .Label1 = "Available:"          'Label over first listbox
                .Label2 = "Selected:"           'Label over second listbox
                .AddButtonText = "Add ->"       'Caption for top button
                .RemoveButtonText = "<- Remove" 'Caption for bottom button
                .List1Values = al               'Assign values for first listbox
            End With
        End If
    End Sub

    Protected Sub WebForm1_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles WebForm1.init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

End Class
