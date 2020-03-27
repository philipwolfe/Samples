
Public Class Sheet1

    Dim chartTitleLabel As Label
    Dim chartTitleTextBox As TextBox
    Dim chartTypeLabel As Label
    Dim changeChartTypeComboBox As ComboBox
    Dim minimumSalesLabel As Label
    Dim minimumSalesTextBox As TextBox


    Private Sub Sheet1_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        If NeedsFill("adventureWorks_DataDataSet") Then
            VSalesPersonSalesByFiscalYearsTableAdapter.Fill( _
                AdventureWorks_DataDataSet.vSalesPersonSalesByFiscalYears)
        End If

        ' Create the chart title Label
        chartTitleLabel = New Label()
        chartTitleLabel.Text = "Chart Title"

        ' Create the TextBox for the chart type
        chartTitleTextBox = New TextBox()
        chartTitleTextBox.Text = embeddedChart.ChartTitle.Caption
        AddHandler chartTitleTextBox.TextChanged, _
            AddressOf Me.chartTitleTextBox_TextChanged

        ' Create the Label for chart type
        chartTypeLabel = New Label()
        chartTypeLabel.Text = "Chart Type"

        ' Create the ComboBox for chart types
        changeChartTypeComboBox = New ComboBox()

        ' The AddRange method is used to add an entire array of
        ' values to the ComboBox.  The Enum.GetNames method
        ' returns a string representation of all values in an
        ' enumerated type (the chart types in this example).
        ' This is a convenient way to populate the list without
        ' duplicating values.
        changeChartTypeComboBox.Items.AddRange( _
            System.Enum.GetNames(GetType(Excel.XlChartType)))
        changeChartTypeComboBox.Text = _
            embeddedChart.ChartType.ToString()
        AddHandler changeChartTypeComboBox.SelectedIndexChanged, _
            AddressOf Me.changeChartTypeComboBox_SelectedIndexChanged

        ' Create the chart title Label
        minimumSalesLabel = New Label
        minimumSalesLabel.Text = "Show sales consistently above:"

        ' Create the TextBox for the chart type
        minimumSalesTextBox = New TextBox
        minimumSalesTextBox.Text = ""
        AddHandler minimumSalesTextBox.TextChanged, _
            AddressOf Me.minimumSalesTextBox_TextChanged

        ' Add all controls to the Document Actions pane
        Globals.ThisWorkbook.ActionsPane.Controls.Add(chartTypeLabel)
        Globals.ThisWorkbook.ActionsPane.Controls.Add(changeChartTypeComboBox)
        Globals.ThisWorkbook.ActionsPane.Controls.Add(chartTitleLabel)
        Globals.ThisWorkbook.ActionsPane.Controls.Add(chartTitleTextBox)
        Globals.ThisWorkbook.ActionsPane.Controls.Add(minimumSalesLabel)
        Globals.ThisWorkbook.ActionsPane.Controls.Add(minimumSalesTextBox)
    End Sub

    Private Sub minimumSalesTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        If (minimumSalesTextBox.Text <> String.Empty) Then
            Dim filter As String = String.Format( _
                "[2002] >= {0} and [2003] >= {0} and [2004] >= {0}", _
                minimumSalesTextBox.Text)
            VSalesPersonSalesByFiscalYearsBindingSource.Filter = filter
        Else
            VSalesPersonSalesByFiscalYearsBindingSource.Filter = ""
        End If
    End Sub

    ' <summary>
    ' Changes the chart title caption based on the contents
    ' of the chartTitleTextBox.
    ' </summary>
    ' <param name="sender"></param>
    ' <param name="e"></param>
    Private Sub chartTitleTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        embeddedChart.ChartTitle.Caption = chartTitleTextBox.Text
        Globals.sheetChart.ChartTitle.Text = chartTitleTextBox.Text
    End Sub

    ' <summary>
    ' Changes the chart type based on the contents of the ComboBox.
    ' If the selected type starts with xlStock, the type is not
    ' changed.  Stock charts require additional information to
    ' render.
    ' </summary>
    ' <param name="sender"></param>
    ' <param name="e"></param>
    Private Sub changeChartTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedText As String = changeChartTypeComboBox.Text
        If selectedText.StartsWith("xlStock") Then
            ' Stock types are special cases so will not be rendered.
        Else
            Dim type As Excel.XlChartType = _
                CType(System.Enum.Parse(GetType(Excel.XlChartType), _
                changeChartTypeComboBox.Text), Excel.XlChartType)
            embeddedChart.ChartType = Type
            Globals.sheetChart.ChartType = Type
        End If
    End Sub

    Private Sub Sheet1_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
