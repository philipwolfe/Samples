Imports System.Collections.Generic

Imports Microsoft.VisualStudio.Tools.Applications.Runtime
Imports Word = Microsoft.Office.Interop.Word
Imports Office = Microsoft.Office.Core

Public Class ThisDocument

    Dim commandBar As Office.CommandBar
    Dim wordCountButton As Office.CommandBarButton
    Dim wordsPerParagraphButton As Office.CommandBarButton
    Dim addButton As Office.CommandBarButton
    Dim dynamicButtons As New List(Of Office.CommandBarButton)

    Private Sub ThisDocument_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        CreateToolbar()
    End Sub

    Private Sub ThisDocument_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub


    ''' <summary>
    ''' Create a toolbar with three dedicated buttons, and the ability
    ''' to add additional buttons at runtime.
    ''' 
    ''' NOTE: When exiting the application, Word may prompt to save
    ''' changes to Normal.dot.  You do NOT want to do this.
    ''' </summary>
    Private Sub CreateToolbar()
        ' Verify that the toolbar is not already present
        Try
            commandBar = Me.CommandBars("TestBar")
            MessageBox.Show("Toolbar was already present!")
        Catch
            ' Not present, so create a new one
            commandBar = Application.CommandBars.Add("TestBar", Temporary:=True)
        End Try

        Try
            ' Create the three static buttons, and wire them up
            ' to event handlers
            ' Notice the "missing" object references in the Controls.Add()
            ' calls.  This is used when invoking COM interop calls from C#
            ' and is provided automatically by the VSTO framework.
            ' In VB, this is not needed as missing arguments can simply
            ' can simply be omitted, however in C# a value must be present,
            ' hence the "missing" object of type System.Type.Missing.
            ' Word count button
            wordCountButton = CType(commandBar.Controls.Add(1, Temporary:=True), Office.CommandBarButton)
            wordCountButton.Style = Office.MsoButtonStyle.msoButtonCaption
            wordCountButton.Caption = "Word Count"
            wordCountButton.Tag = "WordCount"
            AddHandler wordCountButton.Click, AddressOf Me.wordCountButton_Click

            ' Words per paragraph button
            wordsPerParagraphButton = CType(commandBar.Controls.Add(1, Temporary:=True), Office.CommandBarButton)
            wordsPerParagraphButton.Style = Office.MsoButtonStyle.msoButtonCaption
            wordsPerParagraphButton.Caption = "Words Per Paragraph"
            wordsPerParagraphButton.Tag = "WordsPerPara"
            AddHandler wordsPerParagraphButton.Click, AddressOf Me.wordsPerParaButton_Click

            ' Button to add new buttons
            addButton = CType(commandBar.Controls.Add(1, Temporary:=True), Office.CommandBarButton)
            addButton.Style = Office.MsoButtonStyle.msoButtonCaption
            addButton.Caption = "Add Button"
            addButton.Tag = "AddButton"
            AddHandler addButton.Click, AddressOf Me.addButton_Click

            ' Make the command bar visible (a new command bar is
            ' not visible by default
            commandBar.Visible = True
        Catch e As Exception
            MessageBox.Show(e.ToString, "Initialize error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' On each click, a new button is created and wired up to
    ''' the shared newButton_Click event handler.
    ''' </summary>
    ''' <param name="Ctrl"></param>
    ''' <param name="CancelDefault"></param>
    Private Sub addButton_Click(ByVal Ctrl As Office.CommandBarButton, ByRef CancelDefault As Boolean)
        Dim newButton As Office.CommandBarButton = CType(commandBar.Controls.Add(1, Temporary:=True), Office.CommandBarButton)
        newButton.Style = Office.MsoButtonStyle.msoButtonCaption
        newButton.Caption = ("New Button" & commandBar.Controls.Count)

        newButton.Tag = ("NewButton" & commandBar.Controls.Count)

        AddHandler newButton.Click, AddressOf Me.newButton_Click

        dynamicButtons.Add(newButton)
    End Sub

    ''' <summary>
    ''' A simply event handler to display the name of
    ''' the current button when clicked
    ''' </summary>
    ''' <param name="Ctrl"></param>
    ''' <param name="CancelDefault"></param>
    Private Sub newButton_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean)
        MessageBox.Show("You clicked " & Ctrl.Caption)
    End Sub

    ''' <summary>
    ''' Divides the number of words in the document by the number of
    ''' paragraphs in order to obtain the words/paragraph ratio.
    ''' </summary>
    ''' <param name="Ctrl"></param>
    ''' <param name="CancelDefault"></param>
    Private Sub wordsPerParaButton_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean)
        MessageBox.Show("Words per paragraph: " _
            & (Me.ActiveWindow.Document.Words.Count / Me.ActiveWindow.Document.Paragraphs.Count))
    End Sub

    ''' <summary>
    ''' Simply displays the word count for the document.
    ''' </summary>
    ''' <param name="Ctrl"></param>
    ''' <param name="CancelDefault"></param>
    Private Sub wordCountButton_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean)
        MessageBox.Show("Words count: " & Me.ActiveWindow.Document.Words.Count)
    End Sub
End Class
