/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.IO;
using System.Xml;
    
public class XmlDocumentSample
{
    private const String m_Document = "books.xml";

    public static void Main()
    {
        XmlDocumentSample xmldocument = new XmlDocumentSample();
    }

    public XmlDocumentSample()
    {
        try
        {
            // Load the XML from file
			Console.WriteLine ();
            Console.WriteLine ("Loading file {0} ...", m_Document);

            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load (m_Document);

            Console.WriteLine ("XmlDocument loaded with XML data successfully ...");

            // Get a DocumentNavigator from the XmlDocument
            Console.WriteLine ("Create a Navigator ...");
            DocumentNavigator navigator = new DocumentNavigator(xmldocument);

            // Display contents
            Console.WriteLine ("Display contents of the file {0}", m_Document);
            Console.WriteLine ();

            navigator.MoveToDocument(); // Initialize the Navigator to start at the root
            DisplayTree(navigator); // Display all the nodes
            
            // Find the price of the first book. Start at the root node
            Console.WriteLine ();
            Console.WriteLine ("Find the price of the first book by navigating nodes ...");
            navigator.MoveToDocument();
            DisplayNode (true, navigator); // root node
            DisplayNode (navigator.MoveToFirstChild(), navigator); // ?xml version='1.0'? node
            DisplayNode (navigator.MoveToNext(), navigator); //!-- This file ... node
            DisplayNode (navigator.MoveToNext(), navigator); // bookstore element
            DisplayNode (navigator.MoveToFirstChild(), navigator); // book element
            DisplayNode (navigator.MoveToFirstChild(), navigator); // title element
            DisplayNode (navigator.MoveToNext(), navigator);// author element
            DisplayNode (navigator.MoveToNext(), navigator); // price Element
            DisplayNode (navigator.MoveToFirstChild(), navigator); // value of price element

            // Select the book titles
            Console.WriteLine("\r\nSelect the book titles ...");
            navigator.MoveToDocument();

            navigator.Select("descendant::book/title");

            while(navigator.MoveToNextSelected())
            {
                Console.Write("<" + navigator.Name + ">" + navigator.InnerText + "\r\n");
            };
        } 
        catch (Exception e)
        {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }

    // Walks the XmlNavigator tree recursively 
    public void DisplayTree (XmlNavigator navigator)
    {
        if (navigator.HasChildren)
        {
            navigator.MoveToChild(0);
            Format (navigator);
            DisplayTree (navigator); 
            navigator.MoveToParent();
        }
        while (navigator.MoveToNext())
        {
            Format (navigator);
            DisplayTree (navigator); 
        }
    }

    // Format the output
    private void Format (XmlNavigator navigator)
    {
        if (!navigator.HasChildren)
        {
            Console.Write("<" + navigator.Name + ">" + navigator.Value + "\r\n");
        }
        else
        {
            Console.Write("<" + navigator.Name + ">");

            if (navigator.HasAttributes)
            {
                Console.Write("\r\nAttributes of <" + navigator.Name + ">\r\n");

                for (int i = 0; i < navigator.AttributeCount; i++)
                {
                    navigator.PushPosition();
                    navigator.MoveToAttribute(i);
                    Console.Write("<" + navigator.Name + "> " + navigator.Value + " ");
                    navigator.PopPosition();
                }
            }
            Console.WriteLine();
        }
    }

    private void DisplayNode(Boolean success, XmlNavigator navigator)
    {
        if (success && (navigator.NodeType == XmlNodeType.Text))
            Console.Write("<" + navigator.Name + ">" + navigator.Value + "\r\n");
        else if (success)
            Console.Write("<" + navigator.Name + ">\r\n");
        else
            Console.WriteLine();
    }
} // End class XmlDocumentSample
} // End namespace HowTo.Samples.XML
