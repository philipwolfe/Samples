Option Strict On

Imports System.IO
Imports System.IO.File

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Create files for this sample.  User may choose to omit this action if there are already 
        ' files on the emulator or device.
        CreateSampleFiles()

        ' Init the ComboBox
        InitCombo()
        FilterComboBox.SelectedIndex = 0 ' Select default filter as All

        ' Set the initial folder for the DocumentList control
        FileDocumentList.SelectedDirectory = "Personal"
    End Sub

    ' Create simple text and xml files for this sample.  In order to properly demonstrate the 
    ' DocumentList control, there should be some files on the device.  Because emulators don't have
    ' any useful files in the My Documents folder or sub folders, six files will be created here to 
    ' guarantee files will be available for viewing.  Note there are also usually some default template
    ' files in the \My Documents\Templates older as well.
    Private Sub CreateSampleFiles()
        Dim i As Integer
        Dim path As String = "\My Documents\Personal\"

        ' Create 3 text files
        For i = 0 To 2
            Dim name As String = "TextFile" & CStr(i) & ".txt"
            Dim writer As StreamWriter = File.CreateText(path & name)
            writer.WriteLine(name)
            writer.WriteLine()
            writer.WriteLine("This is a standard text file created for this sample")
            writer.Close()
        Next i

        ' Create 3 xml files
        For i = 0 To 2
            Dim name As String = "XmlFile" & CStr(i) & ".xml"
            Dim writer As StreamWriter = File.CreateText(path & name)
            writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
            writer.WriteLine("<Items>")
            writer.WriteLine("<Item>")
            writer.WriteLine("<Name>Apple" & CStr(i) & "</Name>")
            writer.WriteLine("<Desc>Round Fruit</Desc>")
            writer.WriteLine("</Item>")
            writer.WriteLine("<Items>")
            writer.Close()
        Next i
    End Sub

    ' Give the Combo Box some initial filter values
    Private Sub InitCombo()
        FilterComboBox.Items.Add("All")
        FilterComboBox.Items.Add("Text")
        FilterComboBox.Items.Add("Xml")
        FilterComboBox.Items.Add("Other")
        FileDocumentList.Filter = GetFilter()
    End Sub

    ' Determine the filter based on the selected index of the combo box
    ' For each filtering option, the filter string contains a description of the filter, 
    ' followed by a vertical bar (|) and the filter pattern. Because of limited space, 
    ' Pocket PC guidelines suggest skipping the description. 
    ' An omitted description REQUIRES A SPACE before a vertical bar. 
    ' For example, the following filter string includes a description:

    '   "Text files (*.txt)|*.txt"

    '   Without a description, this filter string should appear as: " |*.txt"

    ' A vertical bar also separates filtering options. You can use semicolons to 
    ' delineate multiple filter patterns within a filter option. 
    ' The following filter string specifies five filtering options: 
    '   " |*.*| |*.pwi;*.pdt| |*.rtf| |*.txt| |*.xml"
    Private Function GetFilter() As String
        Select Case FilterComboBox.SelectedIndex
            Case 1 : Return " |*.txt"
            Case 2 : Return " |*.xml"
            Case 3 : Return " |*.pwi;*.pdt| |*.rtf| |*.txt| |*.xml"
            Case Else : Return " |*.*" ' default "All" which is case 0
        End Select
    End Function

    ' Event to set DocumentList Filter property when selection in ComboBox is changed
    Private Sub FilterComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FilterComboBox.SelectedIndexChanged
        Dim filter As String = GetFilter()
        FileDocumentList.Filter = filter

        ' Update the StatusBar so filter can be seen.
        ActionStatusBar.Text = "Filter: " & FilterComboBox.Items(FilterComboBox.SelectedIndex).ToString & " - " & filter
        FileContentsTextBox.Text = String.Empty ' clear text
    End Sub

    ' Handle the DeletingDocument event with code to close the file.
    Private Sub FileDocumentList_DeletingDocument(ByVal sender As Object, ByVal docevent As Microsoft.WindowsCE.Forms.DocumentListEventArgs) Handles FileDocumentList.DeletingDocument
        ActionStatusBar.Text = "Deleted: " & docevent.Path
        FileContentsTextBox.Text = String.Empty ' clear text
    End Sub

    ' Handle the DocumentedActivated event with code to open the file, read file and display contents
    ' in the TextBox
    Private Sub FileDocumentList_DocumentActivated(ByVal sender As Object, ByVal docevent As Microsoft.WindowsCE.Forms.DocumentListEventArgs) Handles FileDocumentList.DocumentActivated
        FileContentsTextBox.Text = String.Empty ' clear text box
        ActionStatusBar.Text = "Activated: " & docevent.Path
        ' Open the selected file and display contents in textbox
        Try
            ' Create an instance of StreamReader to read from a file.
            Dim reader As StreamReader = New StreamReader(docevent.Path)
            Dim line As String
            Dim fileText As String = String.Empty
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            Do
                line = reader.ReadLine()
                FileContentsTextBox.Text &= line & ControlChars.CrLf
            Loop Until line Is Nothing
            reader.Close()
        Catch E As Exception
            ' Let the user know what went wrong.
            MessageBox.Show("The file could not be read:" & ControlChars.CrLf & E.Message)
        End Try
    End Sub

    ' Handle the SelectedDirectoryChanged event with code that sets the correct  
    ' path for opening and closing files.
    Private Sub FileDocumentList_SelectedDirectoryChanged(ByVal sender As Object, _
    ByVal e As System.EventArgs) Handles FileDocumentList.SelectedDirectoryChanged
        ' Write selected folder change to the status bar
        ActionStatusBar.Text = "Folder: " & FileDocumentList.SelectedDirectory
        FileContentsTextBox.Text = String.Empty ' clear text
    End Sub

    ' Delete the Sample Files that were created.  It is assumed that the files remain
    ' in the created location and have not been renamed or moved    Private Sub DeleteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMenuItem.Click
    Private Sub DeleteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMenuItem.Click
        FileContentsTextBox.Text = String.Empty ' clear text
        Dim path As String = "\My Documents\Personal\"
        Try
            ' Delete text files
            File.Delete(path & "TextFile0.txt")
            File.Delete(path & "TextFile1.txt")
            File.Delete(path & "TextFile2.txt")

            ' Delete xml files
            File.Delete(path & "XmlFile0.xml")
            File.Delete(path & "XmlFile1.xml")
            File.Delete(path & "XmlFile2.xml")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Create the sample files again...Useful if files have been deleted while using the 
    ' DocumentList control delete or move
    Private Sub CreateMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateMenuItem.Click
        FileContentsTextBox.Text = String.Empty ' clear text
        CreateSampleFiles()
    End Sub
End Class
