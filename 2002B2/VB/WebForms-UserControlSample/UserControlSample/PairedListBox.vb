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

Public Class PairedListBox
    Inherits System.Web.UI.UserControl
    Private List1 As ArrayList
    Private List2 As ArrayList
    
    'Private variables to store control property values (with default values)
    Private mLabel1 As String = "ListBox1"            'Label over first listbox
    Private mLabel2 As String = "ListBox2"            'Label over second listbox
    Private mAddButtonText As String = "Add"          'Caption for top button
    Private mRemoveButtonText As String = "Remove"    'Caption for bottom button

#Region " Web Forms Designer Generated Code "

    Dim WithEvents PairedListBox As System.Web.UI.UserControl
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnRemove As System.Web.UI.WebControls.Button
    Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox
    Protected WithEvents ListBox2 As System.Web.UI.WebControls.ListBox
    Protected WithEvents divLabel1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divLabel2 As System.Web.UI.HtmlControls.HtmlGenericControl
  
    Sub New()
        PairedListBox = Me
    End Sub

    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()

    End Sub

#End Region
    
    Public Property List1Values() As ArrayList
        'Property to reference values in the first listbox
        Get
            List1 = GetValues(ListBox1)
            Return List1
        End Get
        Set
            List1 = Value
            Call SetList1Values()
        End Set
    End Property
    
    Public ReadOnly Property List2Values() As ArrayList
        'Property to reference values in the second listbox
        Get
            List2 = GetValues(ListBox2)
            Return List2
        End Get
    End Property
    
    Public Property Label1() As String
        'Property for the text of the label over the first listbox
        Get
            Return mLabel1
        End Get
        Set
            mLabel1 = Value
            Call SetProperties()
        End Set
    End Property
    
    Public Property Label2() As String
        'Property for the text of the label over the second listbox
        Get
            Return mLabel2
        End Get
        Set
            mLabel2 = Value
            Call SetProperties()
        End Set
    End Property
    
    Public Property AddButtonText() As String
        'Property for the text of the top button which moves a value from the
        'first listbox to the second listbox
        Get
            Return mAddButtonText
        End Get
        Set
            mAddButtonText = Value
            Call SetProperties()
        End Set
    End Property
    
    Public Property RemoveButtonText() As String
        'Property for the text of the bottom button which moves a value from the
        'second listbox to the first listbox
        Get
            Return mRemoveButtonText
        End Get
        Set
            mRemoveButtonText = Value
            Call SetProperties()
        End Set
    End Property
    
    Protected Sub PairedListBox_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        If Not IsPostback Then   ' Evals true first time browser hits the page	
            Call SetProperties()    'Set the initial properties for the control
        End If
    End Sub
    
    Protected Sub PairedListBox_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    
    Public Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Call Move(ListBox1, ListBox2)   'Move a value from the first listbox to the second listbox
    End Sub
    
    Public Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Call Move(ListBox2, ListBox1)   'Move a value from the second listbox to the first listbox
    End Sub
    
    Private Sub Move(ByRef FromList As ListBox, ByRef ToList As ListBox)
        'Moves a value from the "From" listbox to the "To" listbox
        Dim Item As String
        Dim Index As Integer

        If FromList.SelectedIndex > -1 Then
            Item = FromList.SelectedItem.Text
            'Remove the value from the "From" listbox            
            FromList.Items.Remove(Item)
            'Find the correct position in the "To" listbox to maintain alphabetical order
            For Index = 0 To ToList.Items.Count - 1
                If Item < ToList.Items(Index).Text Then
                    Exit For
                End If
            Next Index
            'Insert the value in the "To" listbox
            ToList.Items.Insert(Index, Item)
        End If
    End Sub

    Private Function GetValues(ByRef Control As ListBox) As ArrayList
        'Retrieves values from a listbox and puts them in an ArrayList
        Dim Index As Integer
        Dim List As ArrayList

        For Index = 0 To Control.Items.Count - 1
            List.Add(Control.Items(Index).Text)
        Next Index
        GetValues = List
    End Function

    Private Sub SetProperties()
        'Set properties of the constituent controls that can be modified by the user control container
        divLabel1.InnerText = mLabel1
        divLabel2.InnerText = mLabel2
        btnAdd.Text = mAddButtonText
        btnRemove.Text = mRemoveButtonText

    End Sub

    Private Sub SetList1Values()
        'Populate the first listbox with values from an ArrayList        
        Dim Index As Integer

        ListBox1.Items.Clear()
        For Index = 0 To List1.Count - 1
            ListBox1.Items.Add(List1.Item(Index).ToString)
        Next Index

    End Sub
End Class
