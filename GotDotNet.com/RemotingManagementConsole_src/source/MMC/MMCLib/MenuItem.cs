using System;
using System.Collections;
using Ironring.Management.MMC;


namespace Ironring.Management.MMC
{

	/// <summary>
	/// Delegate definition for all menu handlers
	/// </summary>
	public delegate void MenuCommandHandler(object item, BaseNode node);
    
	/// <summary>
	/// Handles menu item features
	/// </summary>
	public class MenuItem
	{
		/// <summary>
		/// Name can support nmeumonics like &File
		/// </summary>
		protected string m_Name;

		/// <summary>
		/// added by Roman Kiss
		/// Flag to control visibility of the menu
		/// </summary>
		protected bool m_Visible;


		/// <summary>
		/// Text to display in the MMC status bar when the user
		/// hovers over the menu item
		/// </summary>
		protected string m_StatusText;

		/// <summary>
		/// The integer command that MMC uses when if fires the command
		/// </summary>
		protected int m_nCommandId;

		/// <summary>
		/// Command handler event for revicing notifications fo the menu command
		/// </summary>
		public event MenuCommandHandler Handler;

		/// <summary>
		///  Supports sub menu items used to construct trees of menus
		/// </summary>
		public ArrayList m_Children;
        

		////////////////////////////////////////////////////////////////////////
		///
		/// Implementation
		///


		/// <summary>
		/// default ctor
		/// </summary>
		public MenuItem()
		{
		}

		/// <summary>
		/// Common usage ctor to provide the class flields at once
		/// </summary>
		/// <param name="Name"></param>
		/// <param name="StatusText"></param>
		/// <param name="handler"></param>
		public MenuItem(string Name, string StatusText, MenuCommandHandler handler)
		{
			m_Name = Name;
			m_StatusText = StatusText;
			Handler += handler;
			m_nCommandId = 0;
			m_Visible = true;
		}

		/// <summary>
		/// The menu display name
		/// </summary>
		public string Name
		{
			get{ return m_Name; }
			set{ m_Name = value; }
		}

		/// <summary>
		/// added by Roman Kiss
		/// Flag to control visibility of the menu
		/// </summary>
		public bool Visible
		{
			get{ return m_Visible; }
			set{ m_Visible = value; }
		}
		/// <summary>
		/// The silly status bar text
		/// </summary>
		public string StatusText
		{
			get{ return m_StatusText; }
			set{ m_StatusText = value; }
		}
		
		/// <summary>
		///  the command Id
		/// </summary>
		public int CommandId
		{
			get{ return m_nCommandId; }
			set{ m_nCommandId = value; }
		}
		
		/// <summary>
		/// Called by the node when a command is fired by MMC
		/// </summary>
		/// <param name="node"></param>
		public void Command(BaseNode node)
		{
			OnCommand(node);
		}

		/// <summary>
		/// Called to handle the command.  Consider inheriting from this 
		/// class and overriding this behavior if required.
		/// </summary>
		/// <param name="node"></param>
		protected virtual void OnCommand(BaseNode node)
		{
			if (Handler != null)
				Handler(this, node);
		}
	}
}
