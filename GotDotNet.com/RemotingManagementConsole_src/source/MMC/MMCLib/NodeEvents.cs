using System;

namespace Ironring.Management.MMC
{
    
	public delegate void NodeNotificationHandler(object sender, NodeEventArgs args);

	/// <summary>
	/// Summary description for NodeEvents.
	/// </summary>
	public class NodeEventArgs : EventArgs
	{
		public NodeEventArgs()
		{
		}
	}


	public class ActivateArgs : NodeEventArgs
	{
		public bool m_activate;

		public ActivateArgs(bool activate)
		{
			m_activate = activate;
		}
	}

	public class AddImagesArgs : NodeEventArgs
	{
		public IImageList m_il;
        
		public AddImagesArgs(IImageList il)
		{
			m_il = il;
		}
	}

	public class CommandArgs : NodeEventArgs
	{
		public int m_command;
        
		public CommandArgs(int command)
		{
			m_command = command;
		}
	}

	public class ObjectArgs : NodeEventArgs
	{
		public object m_object;
        
		public ObjectArgs(object obj)
		{
			m_object = obj;
		}
	}

	//---added by Roman Kiss
	public class NameValueArgs : NodeEventArgs
	{
		private string m_key;
		private object m_val;
    
		public string Key {get{ return m_key; } set {m_key = value;}}
		public object Val {get{ return m_val; } set {m_val = value;}}
		public NameValueArgs() { m_key = null; m_val = null; }
		public NameValueArgs(string key, object val){	m_key = key;	m_val = val; }
	}


}
