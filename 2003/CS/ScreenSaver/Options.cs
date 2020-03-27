using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

// This is the class that holds the Options information.  The Options information
//   is defined a class so that it can be easily serialized and deserialized.

[Serializable()] public class Options
{
    // Set up the class variables and make them their defaults
    private string m_Speed  = "Fast";
    private string m_Shape  = "Ellipse";
    private bool m_IsTransparent  = true;

    // Set the OptionsPath to the current location with a fixed file name.
    private string OptionsPath  = Environment.CurrentDirectory + "\\C# How-To Screen Saver Options.opt";

    // --- class Properties ---
    // This property returns whether the screen saver should use transparency
    //   when drawing the shapes to the screen.

    public bool IsTransparent
	{
        get {
            return m_IsTransparent;
        }
        set
		{
            m_IsTransparent = value;
        }
    }

    // This property returns what shapes the screen saver should use 
    //   when drawing to the screen.
    public string Shape
	{
        get {
            return m_Shape;
        }
        set {
            m_Shape = value;
        }
    }

    // This property returns what speed the screen saver should use 
    //   when drawing to the screen.
    public string Speed
	{
        get {
            return m_Speed;
        }
        set {
            m_Speed = value;
        }
    }

    // --- class Methods ---
    // This function returns 'true' if the options file exists, 'false' otherwise.
    public bool IsOptionFileExisting() 
	{
        System.IO.FileInfo myIO = new System.IO.FileInfo(OptionsPath);
        return myIO.Exists;
    }

	// This function loads the user defined options.  First, it checks to see
    //   if an options file exists. if it does, the options are loaded from it.
    //   if the file doesn't exist, one is created with the defaults.
    public void LoadOptions()
	{
        Options myOptions = new Options(); //' An Options object to use;
        // Check to see if an Option file exists, if so, load it!  else {
        //   create one.
        if (myOptions.IsOptionFileExisting()) 
		{
            // Load the options
            // Create an XmlSerializer to use for retrieving options values
            XmlSerializer mySerializer = new XmlSerializer(typeof(Options));
            // Create a StreamReader to point to the options file
            StreamReader myTextReader = new StreamReader(OptionsPath);
            // Create an XmlTextReader to actually read the options.
            XmlTextReader myXmlReader = new XmlTextReader(myTextReader);
            // First verify that the file can be deserialized into an Option
            //   object format.

			if (mySerializer.CanDeserialize(myXmlReader))
			{
				// Deserialize the object
				myOptions = ((Options)  mySerializer.Deserialize(myXmlReader));
			}
			else 
			{
				// Save a new Options file
				myOptions.SaveOptions();
			}
            // Close the IO objects we've used.
            myXmlReader.Close();
            myTextReader.Close();
            // Set the properties for this Options object to those retrieved
            //   from the file (or else use the defaults from the temporary
            //   Options object, if the file could not be deserialized).
            this.Speed = myOptions.Speed;
            this.IsTransparent = myOptions.IsTransparent;
            this.Shape = myOptions.Shape;
        }
    }

    // This function saves the user defined options to disk.

    public void SaveOptions()
	{
        // Create a stream writer to overwrite any files currently there, so that
        //   the fresh options can be saved.
        System.IO.StreamWriter myWriter = new System.IO.StreamWriter(OptionsPath);
        // Create an XML Serializer to serialize the object
        XmlSerializer myXmlSerializer = new XmlSerializer(this.GetType());
        // Serialize the current Options object (Me) to disk.
        myXmlSerializer.Serialize(myWriter, this);
        // Close the writer.
        myWriter.Close();
    }
}

