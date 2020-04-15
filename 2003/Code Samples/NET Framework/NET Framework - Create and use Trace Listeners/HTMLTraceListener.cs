using System;
using System.IO;

// This class was created to output trace messages to an HTML file using tags

public class HTMLTraceListener: System.Diagnostics.TextWriterTraceListener
{
    // Use constructor from TextWriterTraceListener to write to a stream
    public HTMLTraceListener(Stream stream): base(stream) {}

    public void WriteHeader(string Title)
	{
        // new method to add a title to the top of the HTML document
        Writer.WriteLine("<head>");
        Writer.WriteLine("<title>" + Title + "</title>");
        Writer.WriteLine("</head>");
        Writer.WriteLine("<H2>" + Title + "</H2>");
        Writer.WriteLine("<P><HR>");
    }

    protected override void WriteIndent()
	{
        // Override WriteIndent to handle indention in an HTML document
        // using &nbsp; for a space
		if (IndentLevel > 0)
		{
			for(int i = 1; i < IndentLevel; i++)
			{
				for(int j = 1; j < IndentSize; j++)
				{
					Writer.Write("&nbsp;");
				}
			}
        }
    }

    public override void WriteLine(string message)
	{
        // Override WriteLine Method to add tags to output message
        Writer.Write("<B>" + DateTime.Now.ToString() + " - ");

        if (NeedIndent)
		{
            WriteIndent();
        }

        Writer.WriteLine(message + "</B><BR>");
    }
}