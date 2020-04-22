using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Sets the priority for continuation upon exiting the application.
	/// </summary>
	public class SetPriorityCommand : AGICommand
	{
		/// <summary>
		/// Get/Set the priority for continuation upon exiting the application.
		/// </summary>
		/// <returns>the priority for continuation upon exiting the application.</returns>
		/// <param name="priority">the priority for continuation upon exiting the application.</param>
		virtual public int Priority
		{
			get { return priority; }
			set { this.priority = value; }
		}
		
		/// <summary> The priority for continuation upon exiting the application.</summary>
		private int priority;
		
		/// <summary>
		/// Creates a new SetPriorityCommand.
		/// </summary>
		/// <param name="priority">the priority for continuation upon exiting the application.</param>
		public SetPriorityCommand(int priority)
		{
			this.priority = priority;
		}
		
		public override string BuildCommand()
		{
			return "SET PRIORITY " + priority;
		}
	}
}