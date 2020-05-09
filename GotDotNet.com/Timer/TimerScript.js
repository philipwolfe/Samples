
	window.MarkItUp_Timer_Timers = new Array() ;
	window.MarkItUp_Timer_PostingBack = false ;
	
	function MarkItUp_Timer()
	{
		this.ControlName = MarkItUp_Timer.arguments.length >= 1 ? MarkItUp_Timer.arguments[0] : "" ;
		
		if( MarkItUp_Timer.arguments.length == 5 )
		{
			this.CommandName = ( MarkItUp_Timer.arguments[1] ) ? MarkItUp_Timer.arguments[1] : "" ;
			this.TickCount = 0 ;
			this.CommandArgument = ( MarkItUp_Timer.arguments[2] ) ? MarkItUp_Timer.arguments[2] : "" ;
			this.PostBackScript = ( MarkItUp_Timer.arguments[3] ) ? MarkItUp_Timer.arguments[3] : null ;
		
			if( MarkItUp_Timer.arguments[4].length > 0 )
			{
				this.MustNotify = true ;
				this.NotifyRoutine = MarkItUp_Timer.arguments[4] ;
			}
			else
			{
				this.MustNotify = false ;
			}
		}
	}
	
	MarkItUp_Timer.prototype.Notify = function()
	{
		if( this.MustNotify )
		{
			eval( this.NotifyRoutine + "( null, new MarkItUp_Timer_EventArgs( " + this.TickCount + ", " + this.MaxTicks + " ) ) ;" ) ;
		}
	}
	
	function MarkItUp_Timer_EventArgs()
	{
		this.TickCount = MarkItUp_Timer_EventArgs.arguments[0] ;
		this.MaxTicks = MarkItUp_Timer_EventArgs.arguments[1] ;
	}
	
	function MarkItUp_Timer_Init( ctlName, interval, maxTicks, commandName, commandArgument, postbackScript, clientNotify )
	{
		MarkItUp_Timer_Timers[ctlName] = new MarkItUp_Timer(ctlName, commandName, commandArgument, postbackScript, clientNotify ) ;
		MarkItUp_Timer_Timers[ctlName].MaxTicks = maxTicks ;
		MarkItUp_Timer_Timers[ctlName].TickCount = 0 ;
		
		window.setInterval("MarkItUp_Timer_Count('" + ctlName + "')", interval ) ;
	}
	
	function MarkItUp_Timer_Count()
	{
		if ( window.MarkItUp_Timer_PostingBack ) {
			return;
		}
	
		if( MarkItUp_Timer_Count.arguments.length > 0 )
		{
			var timer = window.MarkItUp_Timer_Timers[MarkItUp_Timer_Count.arguments[0]] ;
			if( ++timer.TickCount >= timer.MaxTicks ) 
			{
				window.MarkItUp_Timer_PostingBack = true ;
				if( timer.PostBackScript ) 
				{
					var args = timer.CommandName + "$$$" + timer.CommandArgument ;
					eval( timer.PostBackScript.replace( "@timerResult@", args ) );
				}
			}
			else
			{
				timer.Notify()
			}
		}
	}