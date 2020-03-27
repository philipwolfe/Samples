//
// Leaker.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <comdef.h>
#include <atlstr.h>
#include <iostream>

using namespace std;

//
// constants
//
const _bstr_t bsNAME = L"Name";

//
// Defined smartpointers for use in implementation
//
_COM_SMARTPTR_TYPEDEF(IXMLDOMDocument,			__uuidof(IXMLDOMDocument));
_COM_SMARTPTR_TYPEDEF(IXMLDOMElement,			__uuidof(IXMLDOMElement));
_COM_SMARTPTR_TYPEDEF(IXMLDOMNodeList,			__uuidof(IXMLDOMNodeList));
_COM_SMARTPTR_TYPEDEF(IXMLDOMNode,				__uuidof(IXMLDOMNode));
_COM_SMARTPTR_TYPEDEF(IXMLDOMNamedNodeMap,		__uuidof(IXMLDOMNamedNodeMap));

//
// Method:	DisplayNamespaces
// Purpose: Recursive method to build namespaces from XML nodes.
//
void DisplayNamespaces(IXMLDOMNodePtr ptrNamespacesRoot, CAtlStringW strParentPath = "")
{
	//
	// Make sure we were given a node 
	//
	if (ptrNamespacesRoot == NULL)
	{
		cout << "Problem: No Root Node" << endl;
	}
	else
	{
		HRESULT hr = S_OK;
		long lNamespaceRoots = 0;
		IXMLDOMNodeListPtr ptrNamespaces = NULL;


		//
		// Get the children list for the node
		//
		hr = ptrNamespacesRoot->get_childNodes(&ptrNamespaces);
		if (SUCCEEDED(hr) && ptrNamespaces != NULL)
		{
			//
			// Get the children node length
			//
			hr = ptrNamespaces->get_length(&lNamespaceRoots);

			if (SUCCEEDED(hr))
			{
				//
				// If the node has no children then display any text in the node if present
				//
				if (lNamespaceRoots == 0)
				{
					BSTR bstrName = NULL;
					hr = ptrNamespacesRoot->get_text(&bstrName);
					if (SUCCEEDED(hr) && bstrName)
					{
						if (SysStringLen(bstrName) != 0)
						{
							strParentPath.AppendFormat(L".%s", bstrName);
							wcout << strParentPath.GetString() << endl;
						}
						SysFreeString(bstrName), bstrName = NULL;
					}
				}

				//
				// loop through all the child nodes and get their name attribute 
				// and display the built out namespace. Then recurse and build 
				// out any namespaces defined within
				//
				for (long lItem = 0; lItem < lNamespaceRoots; lItem++)
				{
					IXMLDOMNodePtr ptrNamespace = NULL;
					CAtlStringW strPath = strParentPath;
					hr = ptrNamespaces->get_item(lItem, &ptrNamespace);
					if (SUCCEEDED(hr) && ptrNamespace != NULL)
					{
						strPath = strParentPath;
						IXMLDOMNamedNodeMapPtr ptrAttributes = NULL;
						hr = ptrNamespace->get_attributes(&ptrAttributes);
						if (SUCCEEDED(hr) && ptrAttributes != NULL)
						{
							IXMLDOMNodePtr ptrName = NULL;
							hr = ptrAttributes->getNamedItem(bsNAME, &ptrName);
							if (SUCCEEDED(hr) && ptrName != NULL)
							{
								BSTR bstrName = NULL;
								hr = ptrName->get_text(&bstrName);
								if (SUCCEEDED(hr) && bstrName)
								{
									if (strPath.GetLength() == 0)
									{
										strPath = bstrName;
									}
									else
									{
										strPath.AppendFormat(L".%s", bstrName);
									}
									SysFreeString(bstrName), bstrName = NULL;
									wcout << strPath.GetString() << endl;
								}
								ptrName = NULL;
							}
							ptrAttributes = NULL;
						}
						DisplayNamespaces(ptrNamespace, strPath);
						ptrNamespace = NULL;
					}
				}
			}
			ptrNamespaces = NULL;
		}
	}
}

//
// Method:	LoadAndParse
// Purpose: Loads the namespaces XML document and then passes the document element 
//			onto the display routine.
//
void LoadAndParse()
{
	HRESULT hr = S_OK;
	IXMLDOMDocumentPtr ptrNamespacesXML = NULL;

	//
	// Create the DOMDocument object
	//
	hr = ptrNamespacesXML.CreateInstance(CLSID_DOMDocument);
	if (SUCCEEDED(hr) && ptrNamespacesXML != NULL)
	{
		// build path to tip of the day xml file
		CAtlStringW strFileName("Namespaces.xml");
		VARIANT_BOOL vbLoaded = VARIANT_FALSE;

		// Load the XML file.
		hr = ptrNamespacesXML->load(_variant_t(strFileName), &vbLoaded);
		if (SUCCEEDED(hr) && vbLoaded == VARIANT_TRUE)
		{
			// Get the documents root element
			IXMLDOMElementPtr ptrNamespacesRoot = NULL;
			hr = ptrNamespacesXML->get_documentElement(&ptrNamespacesRoot);
			if (SUCCEEDED(hr) && ptrNamespacesRoot != NULL)
			{
				// display the namespaces contained within the XML tree.
				DisplayNamespaces(ptrNamespacesRoot);
				ptrNamespacesRoot = NULL;
			}
		}
		else
		{
			wcout << L"Problem: Unable to load, " << strFileName.GetString() << endl;
		}
		ptrNamespacesXML = NULL;
	}
	else
	{
		cout << "Problem: Unable to create XML Document Object" << endl;
	}
}

int main(int argc, char* argv[])
{
	//
	// Initialize COM for use within this application since we need it 
	// to demonstrate the _ATL_DEBUG_INTERFACES macro
	//
	CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);
	
	LoadAndParse();
	
	//
	// Every CoInitialize(Ex) must be complimented with a CoUninitialize call
	//
	CoUninitialize();

	printf("Press Enter to continue");
	getchar();

	return 0;
}
