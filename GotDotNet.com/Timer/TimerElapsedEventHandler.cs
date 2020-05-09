using System;
using System.Web ;
using System.Text.RegularExpressions ;

namespace MarkItUp.WebControls 
{

	/// <summary>
	/// The signature for a method handling the <see cref="Timer.Elapsed" /> event.
	/// </summary>
	public delegate void TimerElapsedEventHandler( Object sender, TimerElapsedEventArgs e );
	
	/// <summary>
	/// Provides data for the <see cref="Timer.Elapsed" /> event.
	/// </summary>
	public class TimerElapsedEventArgs : EventArgs 
	{
		private String commandName ;
		private String commandArgument ;
		
		/// <summary>
		/// Instantiates a <see cref="TimerElapsedEventArgs" /> with the given results.
		/// </summary>
		/// <param name="arg"></param>
		public TimerElapsedEventArgs( String arg ) 
		{
			this.commandName = String.Empty ;
			this.commandArgument = String.Empty ;

			if( arg != "@timerResult@" )
			{
				string[] args = Regex.Split( arg, @"\$\$\$" ) ;

				if( args.Length == 2 ) 
				{
					this.commandName = args[0] ;
					this.commandArgument = args[1] ;
				}
			}
		}

		/// <summary>
		/// Gets the CommandName for the event.
		/// </summary>
		public String CommandName 
		{
			get 
			{
				return this.commandName ;
			}
		}
		
		/// <summary>
		/// Gets the CommandArgument for the event.
		/// </summary>
		public String CommandArgument 
		{
			get 
			{
				return this.commandArgument ;
			}
		}
		
	}
}