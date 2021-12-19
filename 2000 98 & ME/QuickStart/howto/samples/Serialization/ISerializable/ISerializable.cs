using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Collections;

public class SimpleGraph {
    
    
    public static void Main(String[] args) {
        
        Console.WriteLine ("Create object graph");
        TreeNode node = new TreeNode ("");
        FillTree (node);
        node.PrintTree (Console.Out);
		
        Console.Write ("Serializing object graph to disk..");
        Stream s = (new File ("foo.xml")).Open(FileMode.Create);
	// BinaryFormatter b = new BinaryFormatter();
        SoapFormatter b = new SoapFormatter ();
        b.Serialize(s, node);
        s.Close();	
        Console.WriteLine ("Complete.");
        
	Console.Write ("Deserializing object graph from disk..");
        Stream r = (new File ("foo.xml")).Open(FileMode.Open);
	// BinaryFormatter c = new BinaryFormatter();
        SoapFormatter c = new SoapFormatter ();
		
        TreeNode n = (TreeNode) c.Deserialize(r);
        Console.WriteLine ("Complete.");
        r.Close();
        n.PrintTree (Console.Out);
        
	Console.WriteLine ("\r\nPress Return to exit.");
	Console.Read();
    }
    
    public static void FillTree (TreeNode node)
    {
        Type [] types = typeof (object).Module.Assembly.GetTypes();
        node.AddChild (new TreeNode (typeof(object).FullName));
        
		
        foreach (Type t in types)
        {
            if (t.BaseType == null) continue;
            if (!t.IsPublic) continue;
            TreeNode n = node.Find (t.BaseType.FullName);
            if (n != null) n.AddChild (new TreeNode (t));
        }
    }
}

[serializable] public class TreeNode : ISerializable
{
    private Object value;
	
    private ArrayList children;
    
    
    private TreeNode (SerializationInfo info, StreamingContext c)
    {
        value = info.GetValue ("value", typeof(object));
        children = new ArrayList ();
        Object o;
        
        for (int i = 1; i < info.MemberCount; i++)
        {
            o = info.GetValue (i.ToString(), typeof(object));
            children.Add (o);
        }
    }
	
    public TreeNode (Object val)
    {
        if (val == null) throw new Exception ("val must not be null");
        value = val;
        children = new ArrayList ();
    }
	
    void ISerializable.GetObjectData (SerializationInfo info, StreamingContext context)
    {
        if (value == null) info.AddValue ("value", "NULL");
        else info.AddValue ("value", value.ToString() + "(SAVED)");
        int i = 1;
        foreach (object o in children)
        {
            if (o == null) continue;
            info.AddValue (i.ToString(), o);
            i++;
        }
    }
	
    public Object Value {
        get 
        {
            return value;
        }
    }
    
    
    public void AddChild (TreeNode child)
    {
        if (!children.Contains (child))
            children.Add (child);
    }
    
    public TreeNode Find (Object val)
    {
        if (val == null) throw new Exception ("val must not be null");
        if (value.Equals (val)) return this;
        foreach (TreeNode t in children)
        {
            TreeNode w = t.Find (val);
            if (w != null) return w;
        }
        return null;
    }

    override public bool Equals (Object obj)
    {
        if (! (obj is TreeNode)) return false;
        TreeNode t = (TreeNode) obj;
        return (t.value.Equals (this.value));
    }

    override public string ToString ()
    {
        return value.ToString ();
    }
    
    public void PrintTree (TextWriter  output)
    {
        PrintTree (output, 0);
    }
    
    private void PrintTree (TextWriter  output, int offset)
    {
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        for (int i =0; i < offset-1; i++)
        {
            sb1.Append (" ");
            sb1.Append ("|");
            sb2.Append (" ");
            sb2.Append ("|");
        }
        if (offset >=1)
        {
            sb1.Append (" ");
            sb1.Append ("+-");
            sb2.Append (" ");
            sb2.Append ("|");
        }
        output.WriteLine ("{0}", sb2);
        output.WriteLine ("{0}{1}", sb1, value);
        foreach (TreeNode t in children)
        {
            t.PrintTree (output, offset+1);
        }
    }
    
    
}

