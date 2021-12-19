/* Copyright (c) 2000, Microsoft Corporation. All Rights Reserved.*/

namespace HowTo.Samples.XML
{

using System;
using System.Globalization;
using System.IO;
using System.Xml;
    
public class XmlDocumentSample
{
    private const String m_Document = "books.xml";
    private const String m_UpdatedDocument = "updatebooks.xml";

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
            Console.WriteLine ("Contents of file {0}", m_Document);
            Console.WriteLine ();

            navigator.MoveToDocument();
            DisplayTree(navigator);
            
            // Increase all the book prices by 2%
            Console.WriteLine("\r\nIncrease all the book prices by 2% ...");
            navigator.PushPosition();

            navigator.Select ("descendant::book/price");

            while (navigator.MoveToNextSelected())
            {
                navigator.MoveToFirstChild();
                Double price = Double.Parse(navigator.Value);
                navigator.Value = Double.Format(price * 1.02, "#.00");
                navigator.MoveToParent();
            }

            navigator.PopPosition();        
                        
            Console.WriteLine("\r\nAdding a new book to the bookstore ...");
            // Navigate to add a new book at the start of the bookstore
	        navigator.MoveToDocumentElement();

            // Insert the new book
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Element,"book","","");
            navigator.SetAttribute ("genre","Object-Orientated Technology");
            navigator.SetAttribute ("publicationdate","1994");
            navigator.SetAttribute ("ISBN","0-201-63361-2");
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Element,"title","","");
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Text,"title","","");
            navigator.Value = "Design Patterns - Elements of Reusable Object-Orientated Software";
            navigator.MoveToParent(); //author element node
            navigator.Insert(TreePosition.After,XmlNodeType.Element,"author","","");
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Element,"first-name","","");
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Text,"first-name","","");
            navigator.Value = "Eric";
            navigator.MoveToParent(); //author element node
            navigator.Insert(TreePosition.After,XmlNodeType.Element,"last-name","","");
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Text,"last-name","","");
            navigator.Value = "Gamma";
            navigator.MoveToParent(); //author element node
            navigator.MoveToParent(); //title element node
            navigator.Insert(TreePosition.After,XmlNodeType.Element,"price","","");
            navigator.Insert(TreePosition.FirstChild,XmlNodeType.Text,"price","","");
            navigator.Value = "49.95";

            // Write out data as XML
            xmldocument.Save(m_UpdatedDocument);
            Console.WriteLine("\r\nNew book and updated prices saved in file {0}\r\n", m_UpdatedDocument);

            // Display updated contents
            Console.WriteLine ("Updated contents of file {0}", m_Document);
            Console.WriteLine ();

            navigator.MoveToDocument();
            DisplayTree(navigator);
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
            Format(navigator);
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
} // End class XmlDocumentSample
} // End namespace HowTo.Samples.XML
