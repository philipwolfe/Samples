'Copyright (c) 2000, Micr osoft Corporation. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

namespace HowTo.Samples.XML

public class ReadXmlStreamSample 
    
    public shared sub Main()
        
        Dim stream as StringReader
        Dim reader as XmlTextReader = nothing

        try            
            Console.WriteLine ("Initializing StringReader ...")    
            stream = new StringReader ("<?xml version='1.0'?>" & _
                                       "<!-- This file represents a fragment of a book store inventory database -->" & _
                                       "<bookstore>" & _
                                       " <book genre=""autobiography"" publicationdate=""1981"" ISBN=""1-861003-11-0"">" & _
                                       "   <title>The Autobiography of Benjamin Franklin</title>" & _
                                       "   <author>" & _
                                       "       <first-name>Benjamin</first-name>" & _
                                       "       <last-name>Franklin</last-name>" & _
                                       "   </author>" & _
                                       "   <price>8.99</price>" & _
                                       " </book>" & _
                                       " <book genre=""novel"" publicationdate=""1967"" ISBN=""0-201-63361-2"">" & _
                                       "   <title>The Confidence Man</title>" & _
                                       "   <author>" & _
                                       "       <first-name>Herman</first-name>" & _
                                       "       <last-name>Melville</last-name>" & _
                                       "   </author>" & _
                                       "   <price>11.99</price>" & _
                                       " </book>" & _
                                       "  <book genre=""philosophy"" publicationdate=""1991"" ISBN=""1-861001-57-6"">" & _
                                       "   <title>The Gorgias</title>" & _
                                       "   <author>" & _
                                       "       <name>Plato</name>" & _
                                       "   </author>" & _
                                       "   <price>9.99</price>" & _
                                       " </book>" & _
                                       "</bookstore>")

            ' Load the XmlTextReader from the stream
            reader = new XmlTextReader (stream)

            Console.WriteLine ("Processing ...")    
            Console.WriteLine ()    
            FormatXml(reader)    

        catch e as Exception
            Console.WriteLine ("Exception: {0} ", e.ToString())                        

        finally 
            Console.WriteLine()    
            Console.WriteLine("Processing of stream complete.")
            if not (reader = nothing)
                reader.Close()
            end if

        end try
    end sub        

    private shared sub FormatXml (reader as XmlTextReader)
    
        Dim PI_count, Doc_count, comment_count, element_count as Integer
        Dim attribute_count, text_count, whitespace_count as Integer

        While reader.Read()
        
            Select (reader.NodeType)
            
            case XmlNodeType.ProcessingInstruction:
                Format (reader, "ProcessingInstruction")
                PI_count += 1

            case XmlNodeType.DocumentType:
                Format (reader, "DocumentType")
                Doc_count += 1

            case XmlNodeType.Comment:
                Format (reader, "Comment")
                comment_count += 1

            case XmlNodeType.Element:
                Format (reader, "Element")
                element_count += 1
                While reader.MoveToNextAttribute()                
                    Format (reader, "Attribute")
                end While

                if (reader.HasAttributes)
                    attribute_count += reader.AttributeCount
                end if

            case XmlNodeType.Text:
                Format (reader, "Text")
                text_count += 1 

            case XmlNodeType.Whitespace:
                whitespace_count += 1

            end Select
            
        end While    
            
        ' Display the Statistics for the file 
        Console.WriteLine ()
        Console.WriteLine("Statistics for stream")
        Console.WriteLine ()
        Console.WriteLine("ProcessingInstruction: " & PI_count)
        Console.WriteLine("DocumentType: " & Doc_count)
        Console.WriteLine("Comment: " & comment_count)
        Console.WriteLine("Element: " & element_count)
        Console.WriteLine("Attribute: " & attribute_count)
        Console.WriteLine("Text: " & text_count)
        Console.WriteLine("Whitespace: " & whitespace_count)
    end sub
        
    private shared sub Format(byref reader as XmlTextReader, NodeType as String)
    
        ' Format the output
        Console.Write(reader.Depth & " ")
        Console.Write(reader.AttributeCount & " ")

        Dim i as Integer
        for i = 0 to reader.Depth
            Console.Write(Strings.chr(9))
        Next
        
        Console.Write(reader.Prefix & NodeType & "<" & reader.Name & ">" & reader.Value)
        Console.WriteLine()

    end sub    

end Class
end Namespace
