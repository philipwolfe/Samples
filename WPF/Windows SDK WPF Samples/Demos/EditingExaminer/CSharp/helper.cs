using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Collections;
using System.Windows;
using System.IO;
using System.Xml;
using System.Windows.Markup;

namespace EditingExaminer
{
    /// <summary>
    /// Provides help function for the document TreeView.
    /// </summary>
    class TreeViewhelper
    {
        /// <summary>
        /// Create or fill up a TreeView of the document content
        /// </summary>
        /// <param name="treeView">Pass an TreeView control</param>
        /// <param name="document">Pass in an Document object</param>
        /// <returns></returns>
        public static TreeView SetupTreeView(TreeView treeView, FlowDocument document)
        {
            TreeViewItem root; 
            if (treeView == null)
            {
                treeView = new TreeView();
                treeView.Visibility = Visibility.Visible;
            }
            if (document != null)
            {
                treeView.Items.Clear();
                root = new TreeViewItem();
                root.Header = "Document";
                root.IsExpanded = true;
                treeView.Items.Add(root);
                AddCollection(root, document.Blocks as IList);
            }
         
            return treeView;
        }

        static void AddCollection(TreeViewItem item, IList list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                TreeViewItem titem = new TreeViewItem();
                item.Items.Add(titem);
                titem.IsExpanded = true;
                titem.Header = list[i].GetType().Name;
                AddItem(titem, list[i] as TextElement);
            }
        }

        static void AddItem(TreeViewItem item, TextElement textElement)
        {
            TreeViewItem childItem;

            if (textElement is InlineUIContainer)
            {
                childItem = new TreeViewItem();
                childItem.Header = ((InlineUIContainer)textElement).Child.GetType().Name;
                childItem.IsExpanded = true;
                item.Items.Add(childItem);
             
            }
            else if (textElement is BlockUIContainer)
            {
                childItem = new TreeViewItem();
                childItem.Header = ((BlockUIContainer)textElement).Child.GetType().Name;
                childItem.IsExpanded = true;
                item.Items.Add(childItem);
            }
            else if (textElement is Span)
            {
                AddCollection(item, ((Span)textElement).Inlines);
            }
            else if (textElement is Paragraph)
            {
                AddCollection(item, ((Paragraph)textElement).Inlines);
            }
            else if (textElement is List)
            {
                AddCollection(item, ((List)textElement).ListItems);
            }
            else if (textElement is ListItem)
            {
               AddCollection(item, ((ListItem)textElement).Blocks);
            }
            else if (textElement is Table)
            {
                TableTreeView(item, textElement as Table);
            }
            else if (textElement is AnchoredBlock)
            {
                Floater floater = textElement as Floater;
                AddCollection(item, ((AnchoredBlock)textElement).Blocks);
            }
      
            //The element should be an inline (Run); try to display the text.
            else if (textElement is Inline)
            {
                TextRange range = new TextRange(((Inline)textElement).ContentEnd, ((Inline)textElement).ContentStart);
                item.Header = item.Header + " - [" + range.Text + "]";
            }
        }

        static void TableTreeView(TreeViewItem item, Table table)
        {
            TreeViewItem item1, item2;
            foreach (TableRowGroup rg in table.RowGroups)
            {
                foreach (TableRow tr in rg.Rows)
                {
                    item1 = new TreeViewItem();
                    item1.IsExpanded = true;
                    item1.Header = "TableRow";
                    item.Items.Add(item1);
                    foreach (TableCell tc in tr.Cells)
                    {
                        item2 = new TreeViewItem();
                        item2.Header = "TableCell";
                        item1.Items.Add(item2);
                        item2.IsExpanded = true;
                        AddCollection(item2, tc.Blocks);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Provides help functions for processing XAML.
    /// </summary>
    public class XamlHelper
    {
        /// <summary>
        /// Get XAML from TextRange.Xml property
        /// </summary>
        /// <param name="range">TextRange</param>
        /// <returns>return a string serialized from the TextRange</returns>
        public static string TextRange_GetXml(TextRange range)
        {
            MemoryStream mstream;

            if (range == null)
            {
                throw new ArgumentNullException("range");
            }

            mstream = new MemoryStream();
            range.Save(mstream, DataFormats.Xaml);

            //must move the stream pointer to the beginning since range.save() will move it to the end.
            mstream.Seek(0, SeekOrigin.Begin);

            //Create a stream reader to read the xaml.
            StreamReader stringReader = new StreamReader(mstream);

            return stringReader.ReadToEnd();
        }

        /// <summary>
        /// Set XML to TextRange.Xml property.
        /// </summary>
        /// <param name="range">TextRange</param>
        /// <param name="xaml">XAML to be set</param>
        public static void TextRange_SetXml(TextRange range, string xaml)
        {
            MemoryStream mstream;
            if (null == xaml)
            {
                throw new ArgumentNullException("xaml");
            }
            if (range == null)
            {
                throw new ArgumentNullException("range");
            }

            mstream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(mstream);

            mstream.Seek(0, SeekOrigin.Begin); //this line may not be needed.
            sWriter.Write(xaml);
            sWriter.Flush();

            //move the stream pointer to the beginning. 
            mstream.Seek(0, SeekOrigin.Begin);

            range.Load(mstream, DataFormats.Xaml);
        }

        /// <summary>
        /// Parse a string to WPF object.
        /// </summary>
        /// <param name="str">string to be parsed</param>
        /// <returns>return an object</returns>
        public static object ParseXaml(string str)
        {
            MemoryStream ms = new MemoryStream(str.Length);
            StreamWriter sw = new StreamWriter(ms);
            sw.Write(str);
            sw.Flush();

            ms.Seek(0, SeekOrigin.Begin);

            ParserContext pc = new ParserContext();

            pc.BaseUri = new Uri(System.Environment.CurrentDirectory + "/");
           
            return XamlReader.Load(ms, pc);          
        }

        public static string IndentXaml(string xaml)
        {
            //open the string as an XML node
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xaml);
            XmlNodeReader nodeReader = new XmlNodeReader(xmlDoc);

            //write it back onto a stringWriter
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter(stringWriter);
            xmlWriter.Formatting = System.Xml.Formatting.Indented;
            xmlWriter.Indentation = 4;
            xmlWriter.IndentChar = ' ';
            xmlWriter.WriteNode(nodeReader, false);

            string result = stringWriter.ToString();
            xmlWriter.Close();

            return result;
        }

        public static string RemoveIndentation(string xaml)
        {
            if(xaml.Contains("\r\n    "))
            {
               return RemoveIndentation(xaml.Replace("\r\n    ", "\r\n"));
            }
            else 
            {
                return xaml.Replace("\r\n", "");
            }
        }

        public static string ColoringXaml(string xaml)
        {
            string[] strs;
            string value = "";
            string s1, s2;
            s1 = "<Section xml:space=\"preserve\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph>";
            s2 = "</Paragraph></Section>";

            strs = xaml.Split(new char[] { '<' });
            for (int i = 1; i < strs.Length; i++)
            {
                value += ProcessEachTag(strs[i]);
            }
            return s1 + value + s2;
        }

        static string ProcessEachTag(string str)
        {
            string front = "<Run Foreground=\"Blue\">&lt;</Run>";
            string end = "<Run Foreground=\"Blue\">&gt;</Run>";
            string frontWithSlash = "<Run Foreground=\"Blue\">&lt;/</Run>";
            string endWithSlash = "<Run Foreground=\"Blue\"> /&gt;</Run>";//a space is added.
            string tagNameStart = "<Run FontWeight=\"Bold\">";
            string propertynameStart = "<Run Foreground=\"Red\">";
            string propertyValueStart = "\"<Run Foreground=\"Blue\">";
            string endRun = "</Run>";
            string returnValue;
            string[] strs;
            int i = 0;

            if (str.StartsWith("/"))
            {   //if the tag is an end tag, remove the "/"
                returnValue = frontWithSlash;
                str = str.Substring(1).TrimStart();
            }
            else
            {
                returnValue = front;
            }
            strs = str.Split(new char[] { '>' });
            str = strs[0];
            i = (str.EndsWith("/")) ? 1 : 0;

            str = str.Substring(0, str.Length - i).Trim();

            if (str.Contains("="))//the tag has a property
            {
                //set tagName 
                returnValue += tagNameStart + str.Substring(0, str.IndexOf(" ")) + endRun + " ";
                str = str.Substring(str.IndexOf(" ")).Trim();
            }
            else //no property
            {
                returnValue += tagNameStart + str.Trim() + endRun + " ";
                //nothing left to parse
                str = "";
            }

            //Take care of properties:
            while (str.Length > 0)
            {
                returnValue += propertynameStart + str.Substring(0, str.IndexOf("=")) + endRun + "=";
                str = str.Substring(str.IndexOf("\"") + 1).Trim();
                returnValue += propertyValueStart + str.Substring(0, str.IndexOf("\"")) + endRun + "\" ";
                str = str.Substring(str.IndexOf("\"") + 1).Trim();
            }

            if (returnValue.EndsWith(" "))
            {
                returnValue = returnValue.Substring(0, returnValue.Length - 1);
            }

            returnValue += (i == 1) ? endWithSlash : end;

            //Add the content after the ">"
            returnValue += strs[1];

            return returnValue;
        }
    }
}
