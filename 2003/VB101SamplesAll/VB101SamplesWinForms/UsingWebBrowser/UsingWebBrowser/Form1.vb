Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml
Imports System.Data

' Enable Interop to support communication between this class and the WebBrowser control
<System.Runtime.InteropServices.ComVisible(True)> _
Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        setupBrowser1()
        setupBrowser2()
        setupBrowser3()
    End Sub

#Region "WebBrowser1: Simple Browser"

    Private Sub setupBrowser1()
        ' Configure 1st WebBrowser control
        ' Allow navigation to other pages
        webBrowser1.AllowNavigation = True
        ' Enable the IE context menu in the browser control
        webBrowser1.IsWebBrowserContextMenuEnabled = True
        ' Enable keyboard shortcutes in the browser control
        webBrowser1.WebBrowserShortcutsEnabled = True
    End Sub

    ' Provide an accessor for the browserAddressTextBox control
    Private Property browserUrl() As String
        Get
            Return browserAddressTextBox.Text.Trim()
        End Get
        Set(ByVal value As String)

            browserAddressTextBox.Text = value
        End Set
    End Property

    ' Update status strip with status message
    Private Sub updateBrowserStatus(ByVal message As String)
        If message.Trim() = String.Empty Then
            message = "Ready"
        End If
        browserStatusLabel.Text = message
    End Sub

    Private Sub browserGoButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browserGoButton.Click
        Navigate()
    End Sub

    Private Sub Navigate()
        If Not browserUrl.StartsWith("http://") Then
            browserUrl = "http://" & browserUrl()
        End If

        Try
            webBrowser1.Navigate(New Uri(browserUrl))
        Catch
            MessageBox.Show("Invalid Url.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub browserBackButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browserBackButton.Click
        webBrowser1.GoBack()
    End Sub

    Private Sub browserForwardButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browserForwardButton.Click
        webBrowser1.GoForward()
    End Sub

    Private Sub webBrowser1_Navigated(ByVal sender As Object, ByVal e As WebBrowserNavigatedEventArgs) Handles webBrowser1.Navigated
        ' Refresh Address after navigation, in case redirects occurred
        browserUrl = e.Url.ToString()
        updateBrowserStatus(String.Empty)
    End Sub

    Private Sub webBrowser1_Navigating(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs) Handles webBrowser1.Navigating
        ' Provide feedback to user that the browser is busy
        updateBrowserStatus("Navigating...")
    End Sub

    Sub Form1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
        ' Navigate if the ENTER key is pressed
        If e.KeyChar = vbCrLf Then
            Navigate()
        End If
    End Sub

    Private Sub browserRefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browserRefreshButton.Click
        webBrowser1.Refresh()
    End Sub

    Private Sub browserStopButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browserStopButton.Click
        webBrowser1.Stop()
    End Sub

#End Region

#Region "WebBrowser2: HTML Document Viewer"

    Private Sub setupBrowser2()
        ' This prevents the Web browser from opening files that are dropped onto it.
        webBrowser2.AllowWebBrowserDrop = False

        ' Load up the browser with the sample's ReadMe
        Dim fi As New FileInfo("..\..\ReadMe.htm")
        DisplayHTMLDoc(fi.FullName)
    End Sub

    Private Sub DisplayHTMLDoc(ByVal path As String)
        If Not path = String.Empty Then
            Try
                If (File.Exists(path)) Then
                    ' Any of the following will work.
                    'webBrowser2.Navigate(new Uri(path))
                    'webBrowser2.DocumentStream = File.OpenRead(path)
                    webBrowser2.Url = New Uri(path)
                Else
                    MessageBox.Show("The browser could not navigate to " & _
                       path & ".", Me.Text)
                End If
            Catch ex As ApplicationException
                MessageBox.Show("The following error occurred:" + ex.Message)
            End Try
        End If
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim openFileDialog1 = New OpenFileDialog()

        ' Default directory is project root
        openFileDialog1.InitialDirectory = "..\..\"
        openFileDialog1.Filter = "HTML files (*.html)|*.html|HTM files (*.htm)|*.htm|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            fileNameTextBox.Text = openFileDialog1.FileName
            ' Display the HTML Doc as well.
            DisplayHTMLDoc(fileNameTextBox.Text.Trim())
        End If
    End Sub

    Private Sub viewButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles viewButton.Click
        DisplayHTMLDoc(fileNameTextBox.Text.Trim())
    End Sub

#End Region

#Region "WebBrowser3: 2-way Interaction"

    Private sales1 As Sales
    Private salesHeaderBindingSource As BindingSource
    Private salesDetailBindingSource As BindingSource


    Private Sub setupBrowser3()
        ' Bind the Form to the Sales data
        BindOrderForm()

        ' Load the browser with the Sales Order printing template
        webBrowser3.DocumentStream = File.OpenRead(Environment.CurrentDirectory + "\..\..\SalesOrderForm.html")


        ' Specify host form as the scripting object
        webBrowser3.ObjectForScripting = Me
    End Sub

    Private Sub BindOrderForm()
        Dim projectPath As String = Environment.CurrentDirectory + "\..\..\"
        sales1 = New Sales()
        sales1.ReadXml(projectPath + "Sales.xml")

        salesHeaderBindingSource = New BindingSource()
        salesHeaderBindingSource.DataSource = sales1.SalesHeader
        salesHeaderBindingSource.Position = 0
        ' Handle event to refresh the HTML Form when change the current Order
        AddHandler salesHeaderBindingSource.CurrentChanged, AddressOf salesHeaderBindingSource_CurrentChanged

        salesDetailBindingSource = New BindingSource(salesHeaderBindingSource, "SalesHeader_SalesDetail")

        Dim salesHeaderBindingNavigator As New BindingNavigator(True)
        salesHeaderBindingNavigator.BindingSource = salesHeaderBindingSource

        Me.splitContainer2.Panel1.Controls.Add(salesHeaderBindingNavigator)
        salesHeaderBindingNavigator.Dock = DockStyle.Top

        ' Bind the controls to the BindingSource
        Me.headerIDTextBox.DataBindings.Add( _
                New Binding("Text", salesHeaderBindingSource, "HeaderID", True))
        Me.salesPersonIDTextBox.DataBindings.Add( _
                New Binding("Text", salesHeaderBindingSource, "SalesPersonID", True))
        Me.salesPersonNameTextBox.DataBindings.Add( _
                New Binding("Text", salesHeaderBindingSource, "SalesPersonName", True))
        Me.customerIDTextBox.DataBindings.Add( _
                New Binding("Text", salesHeaderBindingSource, "CustomerID", True))
        Me.customerNameTextBox.DataBindings.Add( _
                New Binding("Text", salesHeaderBindingSource, "CustomerName", True))
        Me.salesDateDateTimePicker.DataBindings.Add( _
                New Binding("Value", salesHeaderBindingSource, "SalesDate", True))
        Me.salesTotalTextBox.DataBindings.Add( _
                New Binding("Text", salesHeaderBindingSource, "SalesTotal", True))

        salesDetailsRowDataGridView.DataSource = salesDetailBindingSource
    End Sub

    Public Sub RefreshHTMLForm()
        ' Inject the data from the current OrderForm into the HTML template

        ' Grab the current order
        Dim salesHeader As Sales.SalesHeaderRow = _
            CType((CType(salesHeaderBindingSource.Current, DataRowView)).Row, Sales.SalesHeaderRow)

        ' Refresh the SalesHeader information
        Dim htmlDoc As HtmlDocument = webBrowser3.Document
        If htmlDoc.All("SalesPersonID") IsNot Nothing Then
            htmlDoc.All("SalesPersonID").InnerText = salesHeader.SalesPersonID.ToString()
        End If
        If htmlDoc.All("SalesPersonName") IsNot Nothing Then
            htmlDoc.All("SalesPersonName").InnerText = salesHeader.SalesPersonName
        End If
        If htmlDoc.All("CustomerID") IsNot Nothing Then
            htmlDoc.All("CustomerID").InnerText = salesHeader.CustomerID.ToString()
        End If
        If htmlDoc.All("CustomerName") IsNot Nothing Then
            htmlDoc.All("CustomerName").InnerText = salesHeader.CustomerName
        End If
        If htmlDoc.All("SalesDate") IsNot Nothing Then
            htmlDoc.All("SalesDate").InnerText = salesHeader.SalesDate.ToShortDateString()
        End If
        If htmlDoc.All("SalesTotal") IsNot Nothing Then
            htmlDoc.All("SalesTotal").InnerText = salesHeader.SalesTotal.ToString()
        End If

        ' Build SalesDetails table
        ' The SalesDetailTable element contains the template for each SalesDetail item
        Dim detailsTemplate As HtmlElement = htmlDoc.GetElementById("SalesDetailsTemplate")
        ' Populated sales data is injected into SalesData element
        Dim detailsData As HtmlElement = htmlDoc.GetElementById("SalesData")

        ' Build up the HTML row for each SalesDetail record based upon the template
        ' Replace the element HTML with the row values
        ' and append add each row's resulting HTML to a string
        Dim detailsText As String = String.Empty
        For Each saleDetail As Sales.SalesDetailRow In salesHeader.GetSalesDetailRows()

            If detailsTemplate.All("ItemID") IsNot Nothing Then
                detailsTemplate.All("ItemID").InnerHtml = saleDetail("ItemID").ToString()
            End If
            If detailsTemplate.All("ItemName") IsNot Nothing Then
                detailsTemplate.All("ItemName").InnerHtml = saleDetail("ItemName").ToString()
            End If
            If detailsTemplate.All("Quantity") IsNot Nothing Then
                detailsTemplate.All("Quantity").InnerHtml = saleDetail("Quantity").ToString()
            End If
            If detailsTemplate.All("UnitPrice") IsNot Nothing Then
                detailsTemplate.All("UnitPrice").InnerHtml = saleDetail("UnitPrice").ToString()
            End If
            If detailsTemplate.All("SubTotal") IsNot Nothing Then
                detailsTemplate.All("SubTotal").InnerHtml = saleDetail("SubTotal").ToString()
            End If

            detailsText += detailsTemplate.InnerHtml
        Next

        ' Restore the template
        If detailsTemplate.All("ItemID") IsNot Nothing Then
            detailsTemplate.All("ItemID").InnerHtml = String.Empty
        End If
        If detailsTemplate.All("ItemName") IsNot Nothing Then
            detailsTemplate.All("ItemName").InnerHtml = String.Empty
        End If
        If detailsTemplate.All("Quantity") IsNot Nothing Then
            detailsTemplate.All("Quantity").InnerHtml = String.Empty
        End If
        If detailsTemplate.All("UnitPrice") IsNot Nothing Then
            detailsTemplate.All("UnitPrice").InnerHtml = String.Empty
        End If
        If detailsTemplate.All("SubTotal") IsNot Nothing Then
            detailsTemplate.All("SubTotal").InnerHtml = String.Empty
        End If

        ' Inject populated HTML into data element
        detailsData.InnerHtml = detailsText

    End Sub

    Private Sub salesHeaderBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As EventArgs)
        RefreshHTMLForm()
    End Sub

    ' When selecting the 2-way interaction tab, 
    ' refresh the HTML Form
    Private Sub tabControl1_Selected(ByVal sender As Object, ByVal e As TabControlEventArgs) Handles tabControl1.Selected
        If tabControl1.SelectedTab Is tabPage3 Then
            RefreshHTMLForm()
        End If
    End Sub

#End Region

End Class
