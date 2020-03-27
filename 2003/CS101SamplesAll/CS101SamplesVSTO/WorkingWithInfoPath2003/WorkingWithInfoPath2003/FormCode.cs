using System;
using Microsoft.Office.Interop.InfoPath.SemiTrust;

// Office integration attribute. Identifies the startup class for the form. Do not
// modify.
[assembly: System.ComponentModel.DescriptionAttribute("InfoPathStartupClass, Version=1.0, Class=WorkingWithInfoPath2003.WorkingWithInfoPath2003")]

namespace WorkingWithInfoPath2003
{
	// The namespace prefixes defined in this attribute must remain synchronized with
	// those in the form definition file (.xsf).
    [InfoPathNamespace("xmlns:my=\"http://schemas.microsoft.com/office/infopath/2003/myXSD/2005-10-24T16-46-13\" xmlns:xsf=\"http://schemas.microsoft.com/office/infopath/2003/solutionDefinition\" xmlns:msxsl=\"urn:schemas-microsoft-com:xslt\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xdUtil=\"http://schemas.microsoft.com/office/infopath/2003/xslt/Util\" xmlns:xdXDocument=\"http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument\" xmlns:xdMath=\"http://schemas.microsoft.com/office/infopath/2003/xslt/Math\" xmlns:xdDate=\"http://schemas.microsoft.com/office/infopath/2003/xslt/Date\" xmlns:xd=\"http://schemas.microsoft.com/office/infopath/2003\" xmlns:d=\"http://schemas.microsoft.com/office/infopath/2003/ado/dataFields\" xmlns:dfs=\"http://schemas.microsoft.com/office/infopath/2003/dataFormSolution\"")]
	public class WorkingWithInfoPath2003
	{
		private XDocument	thisXDocument;
		private Application	thisApplication;

		public void _Startup(Application app, XDocument doc)
		{
			thisXDocument = doc;
			thisApplication = app;
		}

		public void _Shutdown()
		{
		}

		///<summary>
		/// This is the Click event handler for the Get Products button. You create 
		/// this handler from within InfoPath by right-clicking the button, selecting
		/// Button Properties, and then entering an ID and clicking Edit Form Code.
		///</summary>
		// The following function handler is created by Microsoft Office InfoPath. Do not
		// modify the type or number of arguments.
		[InfoPathEventHandler(MatchPath="getProductsButton", EventType=InfoPathEventType.OnClick)]
		public void getProductsButton_OnClick(DocActionEvent e)
		{
			// Retrieve the user-selected category by selecing the corresponding node
            // in the main data source and then accessing its text property.
			string selectedCategory = 
                thisXDocument.DOM.selectSingleNode(
                "/my:AdventureWorksProductsOrder/my:SelectedCategory").text;

			// Specify a custom query string for retrieving Adventure Works products.
            // This will override the query specified in the data connection. Note
            // also that for this to work you must have the "Automatically retrieve
            // data when form is opened" option unchecked in the Data Connection 
			// Wizard for the "Products" data connection.
			string query = "select ProductID,[Name],[ProductNumber],[Color]," +
                "[ListPrice],[ProductSubcategoryID] " + 
				"from [Production].[Product] as [Product] " +
                "where [ProductSubcategoryID]=" + selectedCategory;

			// Access the "Products" data connection created via the 
            // Tools | Data Connections menu option in InfoPath.
			ADOAdapterObject queryAdapterAccess = 
                (ADOAdapterObject)thisXDocument.DataObjects["Products"].QueryAdapter;

			// Set the Command property to the custom query string.
			queryAdapterAccess.Command = query;

            try
			{
				// Initiate the query.
                queryAdapterAccess.Query();
			}
            catch (Exception ex)
			{
                thisXDocument.UI.Alert(ex.ToString());
			}
		}

		///<summary>
		/// This is the OnAfterChange event handler for the Products repeating
        /// table. You create this handler from within InfoPath as follows: In
        /// the Data Sources pane, in the Main data source, right-click the Product
        /// group and select Properties. Click the Validation and Event Handlers
        /// tab. For Events select OnAfterChange and then click Edit.
		///</summary>
		// The following function handler is created by Microsoft Office InfoPath. Do not
		// modify the type or number of arguments.
		[InfoPathEventHandler(MatchPath = "/my:AdventureWorksProductsOrder/my:Product", EventType = InfoPathEventType.OnAfterChange)]
		public void Product_OnAfterChange(DataDOMEvent e)
		{
			if (e.IsUndoRedo)
			{
				// An undo or redo operation has occurred and the DOM is read-only.
				return;
			}

			try
			{
				// As this is a repeating table with many child nodes, there are many
                // events that bubble up.  Therefore, you have to filter out the ones
                // that are relevant to the user entering or changing a Product ID
                // value. With a little trial and error with the DataDOMEvent properties 
				// you can come up with an appropriate conditional statement.
				if (e.Source.nodeType.ToString() == "NODE_TEXT" && 
                    e.Operation=="Insert" && e.NewValue != null)
				{
					// Create an object that represents the DOM for the "Products"
                    // secondary data source, i.e., the one that is displayed above
                    // the order form and filtered by category.
					DOMDocument50 productsDataDOM = 
                        (DOMDocument50)thisXDocument.DataObjects["Products"].DOM;
                    
					// To run XPath queries against this data DOM you must add some
                    // namespace declarations. To determine what these should be you
                    // can view the sampledata.xml file created when you create a
					// new InfoPath solution.
					productsDataDOM.setProperty(
                        "SelectionNamespaces", 
                        "xmlns:dfs=\"http://schemas.microsoft.com/office/infopath/2003/dataFormSolution\" " +
                        "xmlns:d=\"http://schemas.microsoft.com/office/infopath/2003/ado/dataFields\" ");

					// Create a node object representing the product the user wants to
                    // buy. This is determined by matching the ProductID attribute in
                    // the data DOM with the user's entered value.
					IXMLDOMNode productLookupNode = 
                        productsDataDOM.selectSingleNode(
                        "/dfs:myFields/dfs:dataFields/d:Product[@ProductID='" +
                        e.NewValue.ToString().Replace("'", "`") + "']");
                    
					if (productLookupNode != null)
					{
						// Se the Name and Unit Price fields in the order form to the attribute
                        // values of the looked-up product.
						e.Source.parentNode.parentNode.selectSingleNode("my:Name").text =
                            productLookupNode.selectSingleNode("@Name").text;
						e.Source.parentNode.parentNode.selectSingleNode("my:UnitPrice").text =
                            productLookupNode.selectSingleNode("@ListPrice").text;
					}
					else if(e.Source.parentNode.nodeName == "my:ID")
					{
						thisXDocument.UI.Alert("The Product ID could not be found in the list above.");
					}
				}
			}
			catch (Exception ex)
			{
				this.thisXDocument.UI.Alert(ex.ToString());
				return;
			}
		}
	}
}
