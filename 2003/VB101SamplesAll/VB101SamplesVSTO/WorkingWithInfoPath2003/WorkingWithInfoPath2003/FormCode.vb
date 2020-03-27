Imports	System
Imports	Microsoft.Office.Interop.InfoPath.SemiTrust
Imports Microsoft.VisualBasic

' Office integration attribute. Identifies the startup class for the form. Do not
' modify.
<Assembly: System.ComponentModel.DescriptionAttribute("InfoPathStartupClass, Version=1.0, Class=WorkingWithInfoPath2003.WorkingWithInfoPath2003")>

Namespace WorkingWithInfoPath2003

	' The namespace prefixes defined in this attribute must remain synchronized with
	' those in the form definition file (.xsf).
    '<InfoPathNamespace("xmlns:my='http:'schemas.microsoft.com/office/infopath/2003/myXSD/2005-10-25T23-50-04'")> _
    <InfoPathNamespace("xmlns:my=""http://schemas.microsoft.com/office/infopath/2003/myXSD/2005-10-25T23-50-04"" xmlns:xsf=""http://schemas.microsoft.com/office/infopath/2003/solutionDefinition"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xdUtil=""http://schemas.microsoft.com/office/infopath/2003/xslt/Util"" xmlns:xdXDocument=""http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument"" xmlns:xdMath=""http://schemas.microsoft.com/office/infopath/2003/xslt/Math"" xmlns:xdDate=""http://schemas.microsoft.com/office/infopath/2003/xslt/Date"" xmlns:xd=""http://schemas.microsoft.com/office/infopath/2003"" xmlns:d=""http://schemas.microsoft.com/office/infopath/2003/ado/dataFields"" xmlns:dfs=""http://schemas.microsoft.com/office/infopath/2003/dataFormSolution""")> _
    Public Class WorkingWithInfoPath2003

        Private thisXDocument As XDocument
        Private thisApplication As Application

        Public Sub _Startup(ByVal app As Application, ByVal doc As XDocument)
            thisXDocument = doc
            thisApplication = app
        End Sub

        Public Sub _Shutdown()
        End Sub

        '''<summary>
        ''' This is the Click event handler for the Get Products button. You create 
        ''' this handler from within InfoPath by right-clicking the button, selecting
        ''' Button Properties, and then entering an ID and clicking Edit Form Code.
        '''</summary>
        ' The following function handler is created by Microsoft Office InfoPath. Do not
        ' modify the type or number of arguments.
        <InfoPathEventHandler(MatchPath:="getProductsButton", EventType:=InfoPathEventType.OnClick)> _
        Public Sub getProductsButton_OnClick(ByVal e As DocActionEvent)
            ' Retrieve the user-selected category by selecing the corresponding node in the main
            ' data source and then accessing its text property.
            Dim selectedCategory As String = _
                thisXDocument.DOM.selectSingleNode( _
                "/my:AdventureWorksProductsOrder/my:SelectedCategory").text

            ' Specify a custom query string for retrieving Adventure Works products.
            ' This will override the query specified in the data connection. Note
            ' also that for this to work you must have the "Automatically retrieve
            ' data when form is opened" option unchecked in the Data Connection 
            ' Wizard for the "Products" data connection.
            Dim query As String = "select [ProductID],[Name],[ProductNumber],[Color]," & _
                "[ListPrice],[ProductSubcategoryID] " & _
                "from [Production].[Product] as [Product] where [ProductSubcategoryID]=" & _
                selectedCategory

            ' Access the "Products" data connection created via the
            ' Tools | Data Connections menu option in InfoPath.
            Dim queryAdapterAccess As ADOAdapterObject = _
                CType(thisXDocument.DataObjects("Products").QueryAdapter, ADOAdapterObject)

            ' Set the Command property to the custom query string.
            queryAdapterAccess.Command = query

            Try
                ' Initiate the query.
                queryAdapterAccess.Query()
            Catch ex As Exception
                thisXDocument.UI.Alert(ex.ToString())
            End Try
        End Sub

        '''<summary>
        ''' This is the OnAfterChange event handler for the Products repeating table.
        ''' You create this handler from within InfoPath as follows: In the Data Sources
        ''' pane, in the Main data source, right-click the Product group and select
        ''' Properties. Click the Validation and Event Handlers tab. For Events select
        ''' OnAfterChange and then click Edit.
        '''</summary>
        ' The following function handler is created by Microsoft Office InfoPath. Do not
        ' modify the type or number of arguments.
        <InfoPathEventHandler(MatchPath:="/my:AdventureWorksProductsOrder/my:Product", EventType:=InfoPathEventType.OnAfterChange)> _
        Public Sub Product_OnAfterChange(ByVal e As DataDOMEvent)
            ' Write code here to restore the global state.

            If (e.IsUndoRedo) Then
                ' An undo or redo operation has occurred and the DOM is read-only.
                Return
            End If

            ' A field change has occurred and the DOM is writable. Write code here to respond
            ' to the changes.
            Try

                ' As this is a repeating table with many child nodes, there are many
                ' events that bubble up.  Therefore, you have to filter out the ones
                ' that are relevant to the user entering or changing a Product ID value.
                ' With a little trial and error with the DataDOMEvent properties 
                ' you can come up with an appropriate conditional statement.
                If e.Source.nodeType.ToString() = "NODE_TEXT" _
                    AndAlso e.Operation = "Insert" _
                    AndAlso Not IsNothing(e.NewValue) Then

                    ' Create an object that represents the DOM for the "Products"
                    ' secondary data source, i.e., the one that is displayed above
                    ' the order form and filtered by category.
                    Dim productsDataDOM As DOMDocument50 = _
                        CType(thisXDocument.DataObjects("Products").DOM, DOMDocument50)

                    ' To run XPath queries against this data DOM you must add some
                    ' namespace declarations. To determine what these should be you
                    ' can view the sampledata.xml file created when you create a new
                    ' InfoPath solution.
                    productsDataDOM.setProperty("SelectionNamespaces", _
                        "xmlns:dfs=""http://schemas.microsoft.com/office/infopath/2003/dataFormSolution"" " & _
                        "xmlns:d=""http://schemas.microsoft.com/office/infopath/2003/ado/dataFields"" ")

                    ' Create a node object representing the product the user wants
                    ' to buy. This is determined by matching the ProductID attribute
                    ' in the data DOM with the user's entered value.
                    Dim productLookupNode As IXMLDOMNode = _
                        productsDataDOM.selectSingleNode( _
                        "/dfs:myFields/dfs:dataFields/d:Product[@ProductID='" & _
                        e.NewValue.ToString().Replace("'", "`") & "']")

                    If Not IsNothing(productLookupNode) Then
                        ' Se the Name and Unit Price fields in the order form to the
                        ' attribute values of the looked-up product.
                        e.Source.parentNode.parentNode.selectSingleNode("my:Name").text = _
                            productLookupNode.selectSingleNode("@Name").text
                        e.Source.parentNode.parentNode.selectSingleNode("my:UnitPrice").text = _
                            productLookupNode.selectSingleNode("@ListPrice").text
                    ElseIf e.Source.parentNode.nodeName = "my:ID" Then
                        thisXDocument.UI.Alert("The Product ID could not be found in the list above.")
                    End If
                End If
            Catch ex As Exception
                thisXDocument.UI.Alert(ex.ToString())
            End Try
        End Sub
    End Class

End Namespace
