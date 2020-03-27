Option Strict On

Imports System.IO ' For stream reader / writer
Imports System.Xml ' For XmlTextReader
Imports System.Data ' For DataSet


Public Class Form1

    Private Const myFileName As String = "\My Documents\Personal\Persons.xml"
    Private myDataSet As DataSet

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myDataSet = New DataSet
        CreateXmlDataFile()

        ' Hide PrevNextButton until after user has loaded xml file
        PrevNextButton.Visible = False
    End Sub

    ' Create simple xml file data file with two entries for this sample.  
    Private Sub CreateXmlDataFile()

        ' Create xml file
        Dim writer As StreamWriter = File.CreateText(myFileName)
        writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
        writer.WriteLine("<Persons>")
        writer.WriteLine("  <Person>")
        writer.WriteLine("      <First>Joe</First>")
        writer.WriteLine("      <Last>Smith</Last>")
        writer.WriteLine("      <Phone>509-555-1212</Phone>")
        writer.WriteLine("  </Person>")
        writer.WriteLine("  <Person>")
        writer.WriteLine("      <First>Jane</First>")
        writer.WriteLine("      <Last>Jones</Last>")
        writer.WriteLine("      <Phone>503-555-1212</Phone>")
        writer.WriteLine("  </Person>")
        writer.WriteLine("</Persons>")
        writer.Close()
    End Sub

    Private Sub ClearBindings()
        TextBox1.DataBindings.Clear()
        TextBox2.DataBindings.Clear()
        TextBox3.DataBindings.Clear()
    End Sub

    Private Sub AddBindings(ByVal dataSet As DataSet)
        TextBox1.DataBindings.Add(New Binding("Text", dataSet, "Person.First"))
        TextBox2.DataBindings.Add(New Binding("Text", dataSet, "Person.Last"))
        TextBox3.DataBindings.Add(New Binding("Text", dataSet, "Person.Phone"))
    End Sub

    ' Uses a FileStream and XmlTextReader to read the xml file generated when
    ' the form is created...see Form1 class member fileName for location of file
    Private Sub ReadXml(ByVal dataSet As DataSet)
        Try
            Dim fs As FileStream = New FileStream(myFileName, FileMode.Open)
            Dim reader As New XmlTextReader(fs)
            dataSet.ReadXml(reader)
            reader.Close() ' close reader and underlying stream
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Load the xml file into a 
    Private Sub LoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadButton.Click
        StatusBar1.Text = "Loading Xml from File..."
        StatusBar1.Update() ' Force update
        Cursor.Current = Cursors.WaitCursor ' Show wait cursor

        ' Clear the DataSet and DataBindings in case the 'Load' button is clicked repeatedly
        myDataSet.Clear()
        ClearBindings()

        ' Populate dataset with data from xml file
        ReadXml(myDataSet)

        ' Add Bindings
        AddBindings(myDataSet)

        Cursor.Current = Cursors.Default ' show default cursor
        StatusBar1.Text = "Loading Xml from File...Complete"

        ' Show PrevNextButton after file loaded
        PrevNextButton.Visible = True
    End Sub

    Private Sub PrevNextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrevNextButton.Click
        If PrevNextButton.Text = "Next" Then
            BindingContext(myDataSet, "Person").Position += 1
            PrevNextButton.Text = "Prev"
            StatusBar1.Text = "Person: " & TextBox1.Text & " " & TextBox2.Text & " - " & TextBox3.Text
        Else
            BindingContext(myDataSet, "Person").Position -= 1
            PrevNextButton.Text = "Next"
            StatusBar1.Text = "Person: " & TextBox1.Text & " " & TextBox2.Text & " - " & TextBox3.Text
        End If
    End Sub

    Private Sub DeleteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMenuItem.Click
        ' Delete xml file
        Try
            File.Delete(myFileName)

            ' Hide PrevNextButton until after user has loaded xml file
            PrevNextButton.Visible = False
            StatusBar1.Text = "File Deleted"
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub CreateMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateMenuItem.Click
        CreateXmlDataFile()
        StatusBar1.Text = "File Created"
    End Sub
End Class
