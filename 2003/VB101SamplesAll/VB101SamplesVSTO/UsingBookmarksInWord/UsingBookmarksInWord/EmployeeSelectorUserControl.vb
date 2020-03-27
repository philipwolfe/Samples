Imports Word = Microsoft.Office.Interop.Word
Imports Office = Microsoft.Office.Core

Public Class EmployeeSelectorUserControl

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Fill the dataset when the control initializes
        Me.vEmployeeTableAdapter.Fill(Me.adventureWorks_DataDataSet.vEmployee)

    End Sub

    ''' <summary>
    ''' Event handler when the Select button is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub selectButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles selectButton.Click
        ' The BindingSource object acts as a broker between the
        ' DataSource and the objects binding to the data.
        ' The BindingSource object has a concept of current
        ' record (manipulated by the BindingNavigator in this
        ' case.  When the Select button is clicked, you can
        ' work with the current record (returned as a DataRowView,
        ' then obtain its Row property, then cast it to the
        ' specialized vEmployeeRow.
        Dim currentRow As AdventureWorks_DataDataSet.vEmployeeRow = _
            CType(CType(vEmployeeBindingSource.Current, DataRowView).Row, _
            AdventureWorks_DataDataSet.vEmployeeRow)

        ' The main document already has a number of bookmarks defined.
        ' The Text property allows you to replace the contained text.
        Globals.ThisDocument.lastNameBookmark.Text = currentRow.LastName
        Globals.ThisDocument.firstNameBookmark.Text = currentRow.FirstName
        Globals.ThisDocument.jobTitleBookmark.Text = currentRow.JobTitle
        Globals.ThisDocument.emailAddressBookmark.Text = currentRow.EmailAddress

        SetAndReplacePhoneBookmark(currentRow.Phone)
    End Sub

    ''' <summary>
    ''' When a programatically-added Bookmark object is added, any
    ''' change will remove the bookmark from the document.  This method
    ''' retains the original bookmark.
    ''' </summary>
    ''' <param name="contents"></param>
    Private Sub SetAndReplacePhoneBookmark(ByVal contents As String)
        ' Retrieve the bookmark from the Bookmarks collection by name,
        ' then retrieve the embedded Range object
        Dim currentRange As Word.Range = _
            Globals.ThisDocument.Bookmarks("phoneBookmark").Range

        ' Replace the text of the range with the new contents
        currentRange.Text = contents

        ' Finally, the bookmark is added back to the collection
        ' since setting the text removes it initially.
        Globals.ThisDocument.Bookmarks.Add("phoneBookmark", currentRange)
    End Sub
End Class
