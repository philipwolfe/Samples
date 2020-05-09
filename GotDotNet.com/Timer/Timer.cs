using System ;
using System.Web ;
using System.Web.UI;
using System.Web.UI.WebControls ;
using System.ComponentModel;
using System.Globalization ;


namespace MarkItUp.WebControls
{
	/// <summary>
	/// Provides a mechanism for generating recurring events at specified intervals.
	/// </summary>
	/// <remarks>
	/// <p>
	/// The Timer control requires javascript support in order to function.
	/// </p>
	/// </remarks>
	/// <example>
	/// The following example shows you how to create a Timer control on 
	/// your page that will generate a server postback after 3 seconds.
	/// <code>
	/// <![CDATA[
	/// <%@ Register TagPrefix="miu" Namespace="MarkItUp.WebControls" Assembly="MarkItUp.WebControls.Timer" %>
	/// <script runat="server" language="c#" >
	///	private void MyTimer_Elapsed(object sender, MarkItUp.WebControls.TimerElapsedEventArgs e)
	///	{
	///     Response.Write( e.CommandName + "<br />" ) ;
	///     Response.Write( e.CommandArgument + "<br />" ) ;
	///	}
	/// </script>
	/// <form runat="server">
	///     <miu:Timer 
	///	        id="MyTimer" 
	///	        runat="server" 
	///	        Interval="1000"
	///	        MaxTicks="3"
	///     />
	/// </form>
	/// ]]>
	/// </code>
	/// </example>
	[DefaultProperty("Interval"),
		Description("Provides a mechanism for generating recurring events at specified intervals."),
		DefaultEvent("Elapsed"),
		ToolboxData("<{0}:Timer runat=server></{0}:Timer>")]
	public class Timer : Control, IPostBackEventHandler
	{
		// TODO: add a property that allows a piece of custom script to be executed on the Elapsed
		// i.e.: Server-side or Client-side events

		#region Fields

		private int intervalNotSet = -1 ;
		private int minimumInterval = 400 ;
		private String scriptKey = "MarkItUp.WebControls.Timer" ;

		#endregion
		
		#region Properties

		/// <summary>
		/// Gets or sets the name of the custom client-side script to use for client-side event notifications.
		/// </summary>
		/// <remarks>
		/// Client-side event-handler that receives notifications for each Tick of the Timer.
		///</remarks>
		/// <example>
		/// The following example shows you how to receive client-side notifications from the control.
		/// <code>
		/// <![CDATA[
		/// <%@ Register TagPrefix="miu" Namespace="MarkItUp.WebControls" Assembly="MarkItUp.WebControls.Timer" %>
		///
		/// <form runat="server">
		///     <miu:Timer 
		///	        id="MyTimer" 
		///	        runat="server" 
		///	        ClientNotificationFunction="ClientNotify"
		///	        Interval="1000"
		///	        MaxTicks="3"
		///     />
		/// </form>
		/// 
		/// 
		/// <script language="javascript">
		///     function ClientNotify( source, arguments )
		///     {
		///         window.status = arguments.TickCount + " of " + arguments.MaxTicks ;
		///     }
		/// </script>
		/// 
		/// ]]>
		/// </code>
		/// </example>
		[Bindable(true),
		Category("Behaviour"),
		DefaultValue(""),
		Description("Client script to use for notifications.")]
		public string ClientNotificationFunction
		{
			get 
			{
				Object handlerName = this.ViewState["ClientNotificationFunction"];
				if ( handlerName != null ) 
				{
					return handlerName.ToString() ;
				}
				else
				{
					return String.Empty ;
				}
			}
			set 
			{
				this.ViewState["ClientNotificationFunction"] = value ;
			}
		}


		/// <summary>
		/// Gets or sets the interval to raise the <see cref="Timer.Elapsed"/> event of the Timer.
		/// </summary>
		/// <remarks>
		/// Number of milliseconds to wait before increasing the tick counter.
		/// Minimum value is 500 ;
		///</remarks>
		[Bindable(true),
		Category("Behaviour"),
		DefaultValue("1000"),
		Description("Number of milliseconds to wait before firing each client-side Tick event.")]
		public int Interval
		{
			get 
			{
				Object interval = this.ViewState["Interval"];
				if ( interval != null ) 
				{
					return (int)interval ;
				}
				else
				{
					return 1000 ;
				}
			}
			set 
			{
				int tmp = (int)value ;
				if( tmp >= minimumInterval )
					this.ViewState["Interval"] = tmp ;
				else
					this.ViewState["Interval"] = minimumInterval ;
			
			}
		}


		/// <summary>
		/// Gets or sets the number of <see cref="Timer.Interval"/>s to raise the <see cref="Timer.Elapsed"/> event of the Timer.
		/// </summary>
		/// <remarks>
		/// Number of <see cref="Timer.Interval"/>s to wait before raising the <see cref="Timer.Elapsed"/> event.
		/// Returns -1 if the interval has not been set. 
		/// Minimum value is 1 ;
		///</remarks>
		[Bindable(true),
		Category("Behaviour"),
		DefaultValue("-1"),
		Description("Number of Intervals to wait before raising the Elapsed event.")]
		public int MaxTicks
		{
			get 
			{
				Object maxTicks = this.ViewState["MaxTicks"];
				if ( maxTicks != null ) 
				{
					return (int)maxTicks ;
				}
				return intervalNotSet ;
			}
			set 
			{
				if( value > 0 )
					this.ViewState["MaxTicks"] = value ;
			}
		}


		/// <summary>
		/// Gets or sets the command name associated with the <see cref="Timer"/> that is 
		/// passed to the <see cref="Timer.Elapsed" /> event.
		/// </summary>
		/// <example>
		/// The following example shows you how to use a <see cref="Timer"/> control on your page.
		/// <code>
		/// <![CDATA[
		/// <%@ Register TagPrefix="miu" Namespace="MarkItUp.WebControls" Assembly="MarkItUp.WebControls.Timer" %>
		/// <script runat="server" language="c#" >
		///	private void MyTimer_Elapsed(object sender, MarkItUp.WebControls.TimerElapsedEventArgs e)
		/// {
		///     if( e.CommandName == "Foo" && e.CommandArgument == "Bar" )
		///     {
		///         // do something...
		///     }
		/// }
		/// </script>
		/// <form runat="server">
		///		<miu:Timer 
		///	        id="MyTimer" 
		///	        runat="server" 
		///	        CommandName="Foo" 
		///	        CommandArgument="Bar" 
		///	        Interval="1000"
		///	        MaxTicks="3"
		///	    />
		/// </form>
		/// ]]>
		/// </code>
		/// </example>
		[Bindable(true),
		Category("Data"),
		DefaultValue(""),
		Description("The command name associated with the Elapsed event.")]
		public String CommandName
		{
			get 
			{
				Object commandName = this.ViewState["CommandName"];
				if ( commandName != null ) 
				{
					return (String)commandName ;
				}
				return String.Empty  ;
			}
			set 
			{
				this.ViewState["CommandName"] = value ;
			}
		}
		
		
		/// <summary>
		/// Gets or sets an optional parameter passed to the <see cref="Timer.Elapsed" /> event 
		/// along with the associated <see cref="Timer.CommandName" />.
		/// </summary>
		/// <remarks>
		/// Returns -1 if the interval has not been set. 
		///</remarks>
		/// <example>
		/// The following example shows you how to use a <see cref="Timer"/> control on your page.
		/// <code>
		/// <![CDATA[
		/// <%@ Register TagPrefix="miu" Namespace="MarkItUp.WebControls" Assembly="MarkItUp.WebControls.Timer" %>
		/// <script runat="server" language="c#" >
		/// private void MyTimer_Elapsed(object sender, MarkItUp.WebControls.TimerElapsedEventArgs e)
		/// {
		///     if( e.CommandName == "Foo" && e.CommandArgument == "Bar" )
		///     {
		///         // do something...
		///     }
		/// }
		/// </script>
		/// <form runat="server">
		///		<miu:Timer 
		///	        id="MyTimer" 
		///	        runat="server" 
		///	        CommandName="Foo" 
		///	        CommandArgument="Bar" 
		///	        Interval="1000"
		///	        MaxTicks="3"
		///	    />
		/// </form>
		/// ]]>
		/// </code>
		/// </example>
		[Bindable(true),
		Category("Data"),
		DefaultValue(""),
		Description("An optional parameter passed to the Elapsed event.")]
		public String CommandArgument
		{
			get 
			{
				Object commandArgument = this.ViewState["CommandArgument"];
				if ( commandArgument != null ) 
				{
					return (String)commandArgument ;
				}
				return String.Empty  ;
			}
			set 
			{
				this.ViewState["CommandArgument"] = value ;
			}
		}

		#endregion
		

		/// <summary>
		/// The event that is raised when the <see cref="Timer.Interval" /> has elapsed 
		/// for the <see cref="Timer" />.
		/// </summary>
		/// <remarks />
		public event TimerElapsedEventHandler Elapsed ;


		/// <summary>
		/// Raises the Elapsed event.
		/// </summary>
		protected virtual void OnElapsed( TimerElapsedEventArgs e ) 
		{
			if ( this.Elapsed != null ) 
			{
				this.Elapsed( this, e ) ;
			}
		}

		/// <summary>
		/// Overrides <see cref="Control.OnPreRender"/>
		/// </summary>
		protected override void OnPreRender( EventArgs e ) 
		{
			base.OnPreRender( e ) ;
			RegisterClientScript() ;
		}

		/// <summary>
		/// Registers the neccessary clientscript for the Timer.
		/// </summary>
		protected virtual void RegisterClientScript() 
		{
			//TODO: finalize RegisterArrayDeclaration
			//this.Page.RegisterArrayDeclaration( "MarkItUp_Timers","'" + this.ClientID + "', \"" + this.Page.GetPostBackEventReference( this, "@timerResult@" ) + "\", \"" + this.CommandName + "\", \"" + this.CommandArgument  + "\"") ;

			if ( !Page.IsClientScriptBlockRegistered( scriptKey ) ) 
			{
				using (System.IO.StreamReader reader = new System.IO.StreamReader(typeof(Timer).Assembly.GetManifestResourceStream( typeof(Timer), "TimerScript.js"))) 
				{ 
					String script = "<script language='javascript' type='text/javascript' >\r\n<!--\r\n" + reader.ReadToEnd() + "\r\n//-->\r\n</script>" ;
					this.Page.RegisterClientScriptBlock( scriptKey, script );
				}
			}

			if ( !Page.IsStartupScriptRegistered( scriptKey + "_" + this.ClientID ) && this.MaxTicks > 0 ) 
			{
				string initScript = "<scr" + "ipt language='javascript' type='text/javascript'>" ;
				initScript += String.Format(@"MarkItUp_Timer_Init( ""{0}"", {1}, {2}, ""{3}"", ""{4}"", ""{5}"", ""{6}"") ;", this.ClientID, this.Interval, this.MaxTicks, this.CommandName, this.CommandArgument, this.Page.GetPostBackEventReference(this, "@timerResult@"), this.ClientNotificationFunction ) ;
				initScript += "</script>" ;
				Page.RegisterStartupScript(scriptKey + "_" + this.ClientID, initScript ) ;
			}
		}


		#region IPostBackEventHandler Members
		void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
		{
			this.OnElapsed(new TimerElapsedEventArgs(eventArgument));
		}
		#endregion

		/// <summary>
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render( HtmlTextWriter output )
		{
			//output.Write(Text) ;
		}
		}
}
