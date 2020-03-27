Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Data.SqlClient
Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports System.Configuration


Public Class xpathXslForm
    ''' <summary>
    ''' This event displays the actual data that is stored in the database.  Using the XmlReader you can
    ''' retrieve the xml data type results from the database.
    ''' The XmlDocument class allows us to search on the XML results that are stored in the reader
    ''' The XmlNavigator and XPathNodeIterator classes allows you to filter the results that are stored
    ''' in the XmlDocument.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub displayDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles displayDataButton.Click

        Try

            '' Initialize the connection string
            Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            '' The using block ensures that we will close this connection when we finish
            Using myConnection As SqlConnection = New SqlConnection(myConnectionString)

                '' Using the new StopWatch class, we can display the time required to 
                '' retrieve, filter and display the results
                Dim myWatch As Stopwatch = New Stopwatch()
                '' Open the connection
                myConnection.Open()

                '' Retrieve the XML results
                Dim myQuery As String = "SELECT TOP 1 Description FROM Information ORDER BY ID Desc"

                '' Create the SqlCommand
                Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)

                '' Here you want to set the XmlReader settings to ensure that the
                '' data returned will fit within a conformance level and be properly 
                '' displayed
                Dim mySettings As XmlReaderSettings = New XmlReaderSettings()
                mySettings.ConformanceLevel = ConformanceLevel.Fragment
                mySettings.IgnoreComments = True
                mySettings.IgnoreWhitespace = True

                '' At this point, you want start the timer
                myWatch.Start()

                '' Here we are filling the XmlReader object with the results from the query
                Dim myReader As XmlReader = XmlReader.Create(myCommand.ExecuteXmlReader(), mySettings)

                '' Now, we are creating the XmlDocument that we will use when we filter the results
                Dim myDocument As XmlDocument = New XmlDocument()
                myDocument.Load(myReader)


                '' We need to create a navigator object so that we can execute an XPath Query
                Dim myNavigator As XPathNavigator = myDocument.CreateNavigator()

                '' Get the price from the combobox that we will use to filter the results
                Dim myPrice As String = priceChoiceComboBox.SelectedItem.ToString()

                '' Set the XPath Query that we will use to filter the results
                Dim myExpression As String = "/CATALOG/PLANT[PRICE>" & myPrice & "]"

                '' Create an XPathNodeIterator that is returned when we execute the filter expression
                '' these are just returned as the values of the nodes.
                Dim myIterator As XPathNodeIterator = myNavigator.Select(myExpression)

                '' We can set how many rows are returned from the iterator
                rowsReturned.Text = myIterator.Count.ToString()

                '' Since we want to transform the data, we need to pass the Iterator results as arguments in the
                '' transformation method
                Dim myArguments As XsltArgumentList = New XsltArgumentList()
                myArguments.AddParam("parameter1", "", myIterator)

                '' We create a new XslCompiledTransform object which supercedes the XslTransform class
                Dim myTransform As XslCompiledTransform = New XslCompiledTransform()
                '' We have to load the XSL style sheet before we perform any transformation
                myTransform.Load(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()).ToString() + "\Datafiles\PlantCatalog.xsl")

                '' We are setting the XmlWriterSettings so that we match the conformance level of the XmlReaderSettings
                Dim myWriterSettings As XmlWriterSettings = New XmlWriterSettings()
                myWriterSettings.ConformanceLevel = ConformanceLevel.Fragment

                '' Create a string builder which will eventually contain our transformed results
                Dim myString As StringBuilder = New StringBuilder()

                '' Perform the transformation using the XmlDocument, the Parameters created from the Iterator and 
                '' write it to the StringBuilder
                myTransform.Transform(myDocument, myArguments, XmlWriter.Create(myString, myWriterSettings))

                '' Using the WebBrowser control, display the transformed data
                resultsWebBrowser.DocumentText = myString.ToString()
                '' We can stop the timing now
                myWatch.Stop()

                '' Display the time required to perform the transformation
                elapsedTime.Text = myWatch.ElapsedMilliseconds.ToString() & " ms"
            End Using

        Catch ex As Exception
            MessageBox.Show("There was an error displaying the data.  Please click the 'Load XML' button first.", "Alert")
        End Try

    End Sub

    ''' <summary>
    ''' This event allows us to read in some XML from a file and insert it into the database 
    ''' by using the Bulk and the SingleClob keywords.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub loadXMLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadXMLButton.Click
        Try
            loadXMLButton.Text = "Processing..."
            loadXMLButton.Enabled = False
            Application.DoEvents()

            Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            Dim myConnection As SqlConnection = New SqlConnection(myConnectionString)
            myConnection.Open()
            Dim myQuery As String = "INSERT INTO Information " _
                            & " SELECT XmlColumn " _
                            & " FROM    (SELECT *     " _
                            & " FROM OPENROWSET (BULK '" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()).ToString() + "\\Datafiles\\plant_catalog.xml', SINGLE_CLOB)  " _
                            & " AS XmlColumn) AS R(XmlColumn)"

            Dim myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)
            myCommand.ExecuteNonQuery()
            MessageBox.Show("Data Loaded!", "Information")
        Catch ex As Exception
            MessageBox.Show("There was an error loading the data.  Please try again.", "Alert")
        Finally
            loadXMLButton.Enabled = True
            loadXMLButton.Text = "Load XML"
        End Try
    End Sub

    ''' <summary>
    ''' This event fires when the form is loaded and fills the ComboBox with price information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub XPathXslForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer

        Try
            For i = 1 To 10
                priceChoiceComboBox.Items.Add(i)
            Next
            priceChoiceComboBox.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("There was an error loading the ComboBox.  Please try again.", "Alert")
        End Try

    End Sub






End Class
