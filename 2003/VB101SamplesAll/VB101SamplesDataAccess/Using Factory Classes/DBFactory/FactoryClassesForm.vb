Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Configuration
Imports System.Diagnostics

Public Class factoryClassesForm

    ''' <summary>
    ''' In this event, you create the DbProviderFactory which allows
    ''' you to connect to the a number of different data sources.  
    ''' All the specific connection string information is retrieved
    ''' from the app.config file.  This allows you to write the generic connection
    ''' code and the specific information is populated from the configuration file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub getDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getDataButton.Click
        Try

            '' Create an instance of the new StopWatch class to measure performance
            Dim myWatch As Stopwatch = New Stopwatch()

            '' Start the timer to measure connection and retrieval of data
            myWatch.Start()

            '' Get the name of the database we are going to use
            Dim myName As String = providerComboBox.SelectedItem.ToString()

            '' Get the connection settings from the configuration file based on the name selected
            '' in the ComboBox
            Dim myConnectionSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(myName)

            '' Create an instance of the DbProviderFactory by using the Provider name in the config file
            Dim myProvider As DbProviderFactory = DbProviderFactories.GetFactory(myConnectionSettings.ProviderName)

            '' Create the connection from the DbProvider factory, this code does not need to change for
            '' for different providers
            Dim myConnection As DbConnection = myProvider.CreateConnection()

            '' Get the connection string from the connectionsettings
            '' This gets us the specific provider by which we will connect
            myConnection.ConnectionString = myConnectionSettings.ConnectionString

            '' Open the connection
            myConnection.Open()

            '' now we can create the DataAdapter and then create a command
            Dim myAdapter As DbDataAdapter = myProvider.CreateDataAdapter()
            Dim myCommand As DbCommand = myProvider.CreateCommand()

            '' Create the DataSet so that we can populate the datagrid
            Dim myQuery As String = "SELECT * FROM SampleData"
            Dim myDataSet As DataSet = New DataSet()

            myCommand.Connection = myConnection
            myCommand.CommandText = myQuery

            myAdapter.SelectCommand = myCommand

            myAdapter.Fill(myDataSet)

            displayDataGridView.DataSource = myDataSet.Tables(0)

            '' Now we can stop the timer and display the elapsed time along
            '' with other provider and connection string information
            myWatch.Stop()
            elapsedTimeTextLabel.Text = "Elapsed Time: " & myWatch.ElapsedMilliseconds.ToString() & " ms"
            providerNameTextLabel.Text = "Provider: " & myConnectionSettings.ProviderName.ToString()
            connectionStringLabel.Text = myConnectionSettings.ConnectionString.ToString()


        Catch ex As Exception

            MessageBox.Show("There was an error retrieving data.  Please try again.", "Alert")

        End Try

    End Sub

    ''' <summary>
    ''' This event fires when the form loads.  This sets the ComboBox with a default value.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub factoryClassesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        providerComboBox.SelectedIndex = 0
    End Sub
End Class
