Imports Office = Microsoft.Office.Core
Imports Excel = Microsoft.Office.Interop.Excel

Public Class AddProductUserControl
    Dim dataSet As AdventureWorks_DataDataSet
    Dim tableAdapter As AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter
    Dim productTable As AdventureWorks_DataDataSet.ProductDataTable
    Dim currentProduct As AdventureWorks_DataDataSet.ProductRow

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dataSet = New AdventureWorks_DataDataSet()
        productTable = dataSet.Product

        tableAdapter = New UsingTheListObject.AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter()
        tableAdapter.Fill(productTable)
    End Sub

    ''' <summary>
    ''' The Insert button should only be enabled if the item
    ''' name has been found.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub itemNumberTextbox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles itemNumberTextBox.TextChanged
        If (itemNumberTextBox.Text.Length = 0) Then
            lookupButton.Enabled = False
            currentProduct = Nothing
            insertItemButton.Enabled = False
        Else
            lookupButton.Enabled = True
        End If
    End Sub

    Private Sub lookupButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lookupButton.Click
        Dim row() As AdventureWorks_DataDataSet.ProductRow = CType(dataSet.Product.Select(("ProductNumber='" _
                        + (itemNumberTextBox.Text + "'"))), AdventureWorks_DataDataSet.ProductRow())
        If (row.Length > 0) Then
            itemNameTextbox.Text = row(0).Name
            currentProduct = row(0)
        Else
            itemNameTextbox.Text = "{NOT FOUND}"
            currentProduct = Nothing
        End If
        insertItemButton.Enabled = (Not (currentProduct) Is Nothing)
    End Sub

    Private Sub insertItemButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles insertItemButton.Click
        Dim row As Excel.ListRow = Globals.Sheet1.orderDetailsList.ListRows.Add(Type.Missing)
        Dim currentCell As Excel.Range = CType(row.Range.Item(1, 1), Excel.Range)
        currentCell.Value2 = currentProduct.ProductNumber
        currentCell = CType(row.Range.Item(1, 2), Excel.Range)
        currentCell.Value2 = currentProduct.Name
        currentCell = CType(row.Range.Item(1, 3), Excel.Range)
        currentCell.Value2 = currentProduct.ListPrice
    End Sub

End Class
