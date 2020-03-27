Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualStudio.Tools.Applications.Runtime
Imports Word = Microsoft.Office.Interop.Word
Imports Office = Microsoft.Office.Core
Imports Microsoft.Office.Tools.Word
Imports System.Windows.Forms


Public Class SampleSmartTag
    Inherits SmartTag

    Private popupTextAction, insertTextAction As Action

    Private data As AdventureWorks_DataDataSet

    Private adapter As AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter

    Friend Sub New()
        MyBase.New("www.microsoft.com/VSTO#SampleSmartTag", "AdventureWorks Product SmartTag")

        ' Initialize dataset
        data = New AdventureWorks_DataDataSet
        adapter = New CreatingSmartTags.AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter
        adapter.Fill(data.Product)

        ' Create items to display in the Smart Tag menu, and
        ' actions to associate when they are clicked.
        popupTextAction = New Action("Show product info")
        AddHandler popupTextAction.Click, AddressOf Me.popupTextAction_Click
        insertTextAction = New Action("Insert product info")
        AddHandler insertTextAction.Click, AddressOf Me.insertTextAction_Click

        ' The two actions are added to the array of Action objects
        Actions = New Action() {popupTextAction, insertTextAction}

        ' The RegEx object encapuslates a regular expression which is a
        ' standardized method of recognizing patterns within text.
        ' This expression will find product numbers in the form of
        ' XX-XXXX or XX-XXXX-## as based on products in AdventureWorks
        Expressions.Add(New Regex("\b[A-Z]{2}-[A-Z,0-9]{4}(-[0-9]{2})?\b"))

        ' Specific words can be added to match in addition to the expression
        Terms.Add("TEST")
    End Sub

    ''' <summary>
    ''' The event handler to be called if the "Show product info" action
    ''' is clicked in the Smart Tag popup.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub popupTextAction_Click(ByVal sender As Object, ByVal e As ActionEventArgs)
        Dim text As String = RetrieveProductData(e.Range.Text)
        MessageBox.Show(("Product information:" & vbLf + text))
    End Sub

    ''' <summary>
    ''' The event handler to be called if the "Insert product info" action
    ''' is clicked in the Smart Tag popup.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub insertTextAction_Click(ByVal sender As Object, ByVal e As ActionEventArgs)
        Dim text As String = RetrieveProductData(e.Range.Text)
        e.Range.Text = text
    End Sub

    ''' <summary>
    ''' Retrieves the row in the Product database corresponding to the
    ''' product number added.
    ''' </summary>
    ''' <param name="productID"></param>
    ''' <returns></returns>
    Private Function RetrieveProductData(ByVal productID As String) As String
        Dim row() As AdventureWorks_DataDataSet.ProductRow = CType(data.Product.Select(("ProductNumber='" _
                        + (productID + "'"))), AdventureWorks_DataDataSet.ProductRow())
        If (row.Length > 0) Then
            Return String.Format("Product: {0} [{1:c}]", _
                        row(0).Name, _
                        row(0).ListPrice)
        Else
            Return "Product information for " & productID & " not found"
        End If
    End Function

    ''' <summary>
    ''' The Recognize() method of the SmartTag base class allows you to
    ''' perform custom checking for matching expressions.
    ''' 
    ''' Normally, this method is not required, however can be included if the
    ''' code should perform matching beyond simple pattern.  This could
    ''' include a call to a database, Web service, or local business object
    ''' to verify that a matched pattern should indeed display a smart tag.
    ''' This requires that you do your own pattern matching based on the 
    ''' current text token being passed in the first argument.
    ''' 
    ''' Note: In order to use the interfaces defined in the declaration, 
    ''' you must add the COM reference "Microsoft Smart Tags 2.0 Type Library"
    ''' to the project.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="site"></param>
    ''' <param name="tokenList"></param>
    Protected Overrides Sub Recognize(ByVal text As String, ByVal site As Microsoft.Office.Interop.SmartTag.ISmartTagRecognizerSite, ByVal tokenList As Microsoft.Office.Interop.SmartTag.ISmartTagTokenList)
        ' Do nothing and allow the base class to handle the recognition
        MyBase.Recognize(text, site, tokenList)
    End Sub
End Class
