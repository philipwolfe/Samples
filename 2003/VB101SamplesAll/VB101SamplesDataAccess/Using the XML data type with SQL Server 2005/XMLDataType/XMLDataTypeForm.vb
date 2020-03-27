Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Data.SqlTypes
Imports System.Configuration


Public Class XMLDataTypeForm


    ''' <summary>
    ''' This event reads an XML file and stores the information in 
    ''' an xml data type column.  This did not exist in previous versions of 
    ''' SQL Server.  With the next XmlReader object, you can read xml data
    ''' directly from your source and insert the reader object into a SqlDbType.Xml column.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub insertDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertDataButton.Click

        Try
            schemaDataGridView.DataSource = ""
            dataRichTextBox.Text = ""

            insertDataButton.Text = "Processing..."
            insertDataButton.Enabled = False

            '' first initialize the connection string and the query string
            Dim connectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            Dim myQuery As String = ""
            If Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My CD's") Then

                myQuery = "INSERT INTO  CDInformation(CDInformation) VALUES(@myXMLData)"

            ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Plants") Then

                myQuery = "INSERT INTO  PlantInformation(PlantInformation) VALUES(@myXMLData)"

            ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Menus") Then

                myQuery = "INSERT INTO  MenuInformation(MenuInformation) VALUES(@myXMLData)"

            End If
            '' create all connection objects and command objects here
            Using myConnection As SqlConnection = New SqlConnection(connectionString)
                Using myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)

                    myConnection.Open()
                    '' Add SqlDbType parameter to be inserted into the table
                    myCommand.Parameters.Add("@myXMLData", SqlDbType.Xml)

                    '' connect the parameter value to a file based on the the collectionList item chosen
                    Dim myXmlReader As XmlReader = Nothing
                    If Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My CD's") Then

                        myXmlReader = XmlReader.Create("../../DataFiles/cd_catalog.xml")

                    ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Plants") Then

                        myXmlReader = XmlReader.Create("../../DataFiles/plant_catalog.xml")

                    ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Menus") Then

                        myXmlReader = XmlReader.Create("../../DataFiles/simple.xml")
                    End If

                    '' We want to make sure the XmlReader has been assigned
                    If Not myXmlReader Is Nothing Then

                        myCommand.Parameters(0).Value = New SqlXml(myXmlReader)
                        Dim i As Integer = myCommand.ExecuteNonQuery()
                        MessageBox.Show("Inserted Successfully!", "Information")
                    Else
                        MessageBox.Show("There was an error inserting!", "Alert")
                    End If
                End Using
            End Using

        Catch ex As Exception

            MessageBox.Show("There was an error inserting!", "Alert")
        End Try

        insertDataButton.Text = "Insert Data"
        insertDataButton.Enabled = True

    End Sub

    ''' <summary>
    ''' This event shows the actual data. This event shows the database columns by binding to a DataGridview
    ''' and the actual data is displayed in a richtextbox to show how easy it is to get the data out of a xml data field
    ''' You can also choose between data with markup and data without
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub showDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showDataButton.Click

        Try

            If withMarkupRadioButton.Checked Then
                DisplayDataWithMarkup()
            Else
                DisplayDataWithoutMarkup()
                withoutMarkupRadioButton.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show("There was an error displaying data. Please click the 'Insert Data' button first.", "Alert")
        End Try
    End Sub

    ''' <summary>
    ''' This method reads the XML data from the database and then populates the DataGridView and the 
    ''' clean data populates the richtext box.  This is accomplished by creating a SqlDataReader and data table to 
    ''' populate the DataGridViewfrom and the new XmlReader object to populate the RichTextBox. 
    ''' </summary>
    Private Sub DisplayDataWithoutMarkup()

        Try

            '' initialize the different parameters, these will all be used later.
            Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            Dim myQuery As String = ""
            Dim myCleanData As String = ""

            '' determine which table should be queried
            If Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My CD's") Then

                myQuery = "select TOP 1 CDInformation from CDInformation"

            ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Plants") Then

                myQuery = "select TOP 1 PlantInformation from PlantInformation"

            ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Menus") Then

                myQuery = "select TOP 1 MenuInformation from MenuInformation"
            End If

            '' This is where the main work happens.  We read through all the records returned
            '' from the database.  We use the new XmlReader object to read the XML data that is
            '' stored in the database
            Using myConnection As SqlConnection = New SqlConnection(myConnectionString)
                Using myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)

                    myConnection.Open()
                    Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                    Dim mySecondCommand As SqlCommand = New SqlCommand(myQuery, myConnection)

                    Dim myData As DataTable = New DataTable()
                    myData.Load(myReader)
                    myReader.Close()

                    '' We are going to read the data stored in the xmlReader
                    Dim myXMLReader As XmlReader = mySecondCommand.ExecuteXmlReader()
                    myXMLReader.Read()
                    While myXMLReader.Read()

                        '' Here we are getting the data without any markup to be displayed
                        myCleanData = myCleanData + myXMLReader.ReadString() & vbCrLf
                    End While


                    '' Bind the DataTable to the DataGridView
                    schemaDataGridView.DataSource = myData
                    '' Here we are assigning the data to the textbox to show the XML data without markup
                    dataRichTextBox.Text = myCleanData
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("There was an error displaying data without markup. Please click the 'Insert Data' button first.", "Alert")
        End Try


    End Sub

    ''' <summary>
    ''' This method is similar to the DisplayDataWithoutMarkup except that in this method,
    ''' we are displaying the specific data in the nodes in the XML document.
    ''' </summary>
    Private Sub DisplayDataWithMarkup()

        Try

            '' initialize the different parameters, these will all be used later.
            Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            Dim myQuery As String = ""
            Dim myXMLData As String = ""

            '' determine which table to query
            If Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My CD's") Then

                myQuery = "select TOP 1 CDInformation from CDInformation"

            ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Plants") Then

                myQuery = "select TOP 1 PlantInformation from PlantInformation"

            ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Menus") Then

                myQuery = "select TOP 1 MenuInformation from MenuInformation"

            End If
            '' Here we are again creating the data readers to display the data
            '' We are using the new XmlReader to read the XML data that is returned from the query
            Using myConnection As SqlConnection = New SqlConnection(myConnectionString)
                Using myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)

                    myConnection.Open()
                    Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                    Dim mySecondCommand As SqlCommand = New SqlCommand(myQuery, myConnection)

                    Dim myData As DataTable = New DataTable()
                    myData.Load(myReader)
                    myReader.Close()

                    Dim myXMLReader As XmlReader = mySecondCommand.ExecuteXmlReader()
                    While myXMLReader.Read()

                        myXMLReader.Read()
                        myXMLData = myXMLData & myXMLReader.ReadOuterXml() & vbCrLf & vbCrLf
                        myXMLReader.Read()
                    End While
                    '' Bind the DataTable to the DataGridView to see how the data is stored in the databas
                    schemaDataGridView.DataSource = myData
                    '' Assign richTextBox with XML data
                    dataRichTextBox.Text = myXMLData

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("There was an error displaying data with markup. Please click the 'Insert Data' button first.", "Alert")
        End Try

    End Sub
    ''' <summary>
    ''' This method displays the table schema so that you can see how the table is setup with it's 
    ''' properties
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub showDefinitionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showDefinitionButton.Click
        Try

            dataRichTextBox.Text = ""

            '' set up the Connection String and Querystring
            Dim myConnectionString As String = ConfigurationManager.AppSettings("myConnectionString")
            Dim myQuery As String = ""
            If Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My CD's") Then

                myQuery = "select * from CDInformation"

            ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Plants") Then

                myQuery = "select * from PlantInformation"

            ElseIf Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() = "My Menus") Then

                myQuery = "select * from MenuInformation"

            End If
            '' This is where you get the Table Schema that is
            '' to be displayed in the DataGridView
            Using myConnection As SqlConnection = New SqlConnection(myConnectionString)
                Using myCommand As SqlCommand = New SqlCommand(myQuery, myConnection)

                    myConnection.Open()
                    Dim myDataReader As SqlDataReader = myCommand.ExecuteReader()
                    Dim myDataTable As DataTable = myDataReader.GetSchemaTable()

                    schemaDataGridView.DataSource = myDataTable

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("There was an error displaying table definition.  Please click the 'Insert Data' button first.", "Alert")
        End Try

    End Sub

#Region "Events"

    ''' <summary>
    ''' This event loads the ComboBox with collection items.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub XMLDataTypeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        collectionListComboBox.Items.Add("My CD's")
        collectionListComboBox.Items.Add("My Plants")
        collectionListComboBox.Items.Add("My Menus")
        collectionListComboBox.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' This event displays information without markup
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub withoutMarkupRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles withoutMarkupRadioButton.Click
        DisplayDataWithoutMarkup()
    End Sub
    ''' <summary>
    ''' This event displays information with markup
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub withMrkupRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles withMarkupRadioButton.Click
        DisplayDataWithMarkup()
    End Sub

#End Region
 
    
End Class
