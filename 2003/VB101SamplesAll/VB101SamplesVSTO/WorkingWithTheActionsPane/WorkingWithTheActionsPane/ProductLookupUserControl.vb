Class ProductLookupUserControl

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        productTableAdapter.Fill(adventureWorks_DataDataSet.Product)

    End Sub

    Private Sub insertProductInfoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertProductInfoButton.Click
        ' Complex casting due to row being contained in list
        Dim prod As AdventureWorks_DataDataSet.ProductRow = _
            CType(CType(productsListBox.SelectedItem, DataRowView).Row, _
                AdventureWorks_DataDataSet.ProductRow)

        ' It is important to check each value for null prior to
        ' attempting to access it, or an exception will be thrown.
        Dim price As String = String.Format("{0:c}", prod.ListPrice)

        ' As with price, confirm that weight is not null
        Dim weight As String
        If Not prod.IsWeightNull Then
            weight = String.Format("{0:0.##} {1}", _
                prod.Weight, prod.WeightUnitMeasureCode)
        Else
            weight = "Unknown"
        End If

        ' Format the fields using the string.Format() method.  This
        ' is more efficient than using string concatenation
        Dim productInfo As String = _
            String.Format("[{0}] {1} - Price: {2}, Weight: {3}", _
            prod.ProductNumber, prod.Name, price, weight)

        ' Obtain the Selection property in order to 
        Dim currentSelection As Word.Selection = _
            Globals.ThisDocument.Application.Selection

        ' Only add the text if the cursor is positioned as an insertion
        ' point, not if text is currently selected.  This prevents loss
        ' of existing text.
        If (currentSelection.Type = Word.WdSelectionType.wdSelectionIP) Then
            currentSelection.TypeText(productInfo)
            currentSelection.TypeParagraph()
        End If

    End Sub
End Class
