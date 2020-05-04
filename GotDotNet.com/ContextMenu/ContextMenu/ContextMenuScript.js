
window.MarkItUp_ContextMenu_Menus = new Array() ;
window.MarkItUp_ContextMenu_PostingBack = false ;



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
//     DHTMLPopUp Menu Helper Classes
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

// Public Enums

var LinkType = new Object() ;
	LinkType.PostBack = 0 ;
	LinkType.Delegate = 1 ;		// signature for a callback is :
								// public void delegate( sender, MenuItemClickedEventArgs )
	
	
var MenuItemFields = new Object() ;
	MenuItemFields.Text = 0 ;
	MenuItemFields.CommandArgument = 1 ;
	MenuItemFields.CallbackFunction = 2 ;

var splitChars = "___"

/**************************************************************
/				BROWSER CLASS
/**************************************************************/
function Browser()
{ 
	if ( parseInt( navigator.appVersion.charAt(0) ) >= 4 )
	{
		this.isDOM = document.getElementById ? true : false ;
		this.isNav6 = (navigator.appName == "Netscape") ? true : false ;
		this.isNav4 = (navigator.appName == "Netscape" && !(this.isDOM)) ? true : false ;
		this.isIE4 = (navigator.appName.indexOf("Microsoft") != -1) ? true : false ;
	}
}
browser = new Browser() ;

/**************************************************************
/				MenuItemClickedEventArgs CLASS
/**************************************************************/


function MenuItemClickedEventArgs( arg )
{
	this.LinkCommandArgument = null ;
    this.MenuItemCommandArgument = null ;

	var args = arg.split( splitChars ) ;
	if( args.length == 2 )
	{
		this.LinkCommandArgument = args[0] ;
		this.MenuItemCommandArgument = args[1] ;
	}
}


/**************************************************************
/				MENU CLASS
/**************************************************************/

function Menu( identity, menuClientId, linkArgument )
{
	// class members
	this.MenuItems = new Array() ;
	this.Id = menuClientId ;
	this.DisplayName = "(none)" ;
	this.PostBackScript = null ;
	this.LinkArgument = ( linkArgument ) ? linkArgument : '' ;
	this.x = 0 ;
	this.y = 0 ;
	this.Owner = null ;
	this.Canvass = null ;
	
	// call .ctor
	this.Init(identity) ;
}


Menu.prototype.Init = function(e)
{
	// initialize the Locals...
	//this.DisplayName = MarkItUp_ContextMenu[this.Id][1][0] ;
	this.PostBackScript = ( MarkItUp_ContextMenu[this.Id][0][0] ) ? MarkItUp_ContextMenu[this.Id][0][0] : null ;
	if( MarkItUp_ContextMenu[this.Id].length )
	{
		for( var i = 0; i < MarkItUp_ContextMenu[this.Id][1].length; i++ )
		{
			this.MenuItems[i] = new MenuItem( e, 
					MarkItUp_ContextMenu[this.Id][1][i][MenuItemFields.Text], 
					MarkItUp_ContextMenu[this.Id][1][i][MenuItemFields.CommandArgument], 
					MarkItUp_ContextMenu[this.Id][1][i][MenuItemFields.CallbackFunction]
				) ;
			this.MenuItems[i].Menu = this ;
		}
	}
	
	// initialize the Canvass...
	if (browser.isNav4) 
	{ 
		var tmpLayer = new Layer(200) ;
	}
	else if (browser.isIE4 || browser.isDOM)
	{
		var tmpLayer = browser.isDOM ? document.getElementById("MarkItUp_ContextMenu_MenuContainer") : document.all.menuContainer ;
	}
	this.Canvass = tmpLayer ;
	this.SetVisibility( false ) ;
	
}	// Init


// Overrides [object].toString() ;
Menu.prototype.toString = function() 
{
		return this.MenuItemNumber + " - " + this.DisplayName + ".  [" + this.MenuItems.length + " items ]" ;
}	// toString


Menu.prototype.Show = function()
{ 
	this.SetVisibility( true ) ;
	this.PositionCanvass() ;
	this.WriteString( this.GetHtml() ) ;
}	// Show


// renders string to Canvass
Menu.prototype.WriteString = function(s)
{
    if(browser.isNav4)
    {
        this.Canvass.document.open() ;
        this.Canvass.document.writeln(s) ;
        this.Canvass.document.close() ;
    }
    if (browser.isIE4 || browser.isDOM)
    {
        this.Canvass.innerHTML = s ;
    }          
}   // WriteString


Menu.prototype.Hide = function()
{
	this.SetVisibility( false ) ;
	this.Owner = null ;
	this.Canvass.innerHtml = "" ;
}	// Hide


Menu.prototype.IsOwnedBy = function()
{
	return ( this.IsOwnedBy.arguments[0] == this.Owner ) ;
}	// IsOwnedBy


Menu.prototype.SetVisibility = function()
{
	if(browser.isNav4)
	{
		if (this.SetVisibility.arguments.length == 0)
		{
			this.Canvass.visibility = this.isVisible ? 'show' : 'hide' ;
			this.isVisible = !(this.isVisible)
		}
		else
		{
			this.Canvass.visibility = this.SetVisibility.arguments[0] ? 'show' : 'hide' ;
			this.isVisible = this.SetVisibility.arguments[0] ;
		}
	}
	else if (browser.isIE4 || browser.isDOM)
	{
		if (this.SetVisibility.arguments.length == 0)
		{
			this.Canvass.style.visibility = this.isVisible ? 'visible' : 'hidden' ;
			this.isVisible = !(this.isVisible)
		}
		else
		{
			this.Canvass.style.visibility = this.SetVisibility.arguments[0] ? 'visible' : 'hidden' ;
			this.isVisible = this.SetVisibility.arguments[0] ;
		}
	}      
}   // SetVisibility


// apply Positioning
Menu.prototype.PositionCanvass = function()
{
	if ( browser.isNav4 ) 
	{ 
		this.Canvass.left = this.x ;
		this.Canvass.top = this.y ;
	}
	else if ( browser.isIE4 || browser.isDOM )
	{
		this.Canvass.style.left = this.x ;
		this.Canvass.style.top = this.y ;
	}       
}   // PositionCanvass


Menu.prototype.GetHtml = function()
{
	var s = "<table class=\"MarkItUp_ContextMenu_MenuTable\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\" border=\"0\">\n" ;
	for( var i = 0; i < this.MenuItems.length; i++ )
	{
		s += "\t<tr>\n\t\t<td>\n\t\t\t" ;
		s += this.MenuItems[i].GetHtml() ;
		s += "\n\t\t</td>\n\t</tr>\n" ;
	}
	s += "</table>" ;
	return s ;
}   // GetHtml


/**************************************************************
/				MENUITEM CLASS
/**************************************************************/
function MenuItem( e, displayName, argument, callback )
{
	this.DisplayName = displayName ;
	this.Menu = null ;
	this.CommandArgument = argument ;
	this.LinkType = LinkType.PostBack ;
	this.InvokeCallback = null ;
	
	if( arguments.length == 4 && callback != null && callback.length > 0 )
	{
		this.LinkType = LinkType.Delegate ;
		this.InvokeCallback = callback ;
	}
}


MenuItem.prototype.toString = function()
{
	return this.DisplayName ;
}   // Override of toString()

MenuItem.prototype.GetHtml = function()
{
	var delegateFunction = ( this.LinkType == LinkType.Delegate ) ? this.InvokeCallback : "''" ;
	var s =  "<div class=\"MarkItUp_ContextMenu_MenuItemBar MarkItUp_ContextMenu_MenuItem\" "
				+ " onClick=\"javascript: MarkItUp_ContextMenu_HandleItemClick( this, " + delegateFunction + ", '" 
				+ this.Menu.LinkArgument + splitChars + this.CommandArgument + "' ) ; "
				+ " event.cancelBubble = true ; \""
				+ " onMouseOut=\"javascript: MarkItUp_ContextMenu_MenuItemOver(this, 'out') ; "
				+ " document.onmousedown = MarkItUp_ContextMenu_HandleDocumentClick ;\" "
				+ " onMouseOver=\"javascript: MarkItUp_ContextMenu_MenuItemOver(this, 'over') ; "
				+ " document.onmousedown = null;\""
				+ ">" + this.DisplayName + "</div>" ;
	return s
}   // GetHtml


// private member
function MarkItUp_ContextMenu_MenuItemOver( e, dir )
{
	if(dir == "over" )
		e.className = "MarkItUp_ContextMenu_MenuItemBar_Over MarkItUp_ContextMenu_MenuItem" ;
	else
		e.className = "MarkItUp_ContextMenu_MenuItemBar MarkItUp_ContextMenu_MenuItem" ;
}


// optional third argument... if present, value will be stored in value __ContextMenuPostBack
function MarkItUp_ContextMenu_HandleItemClick( clickedItem, callback, commandArgument )
{
	MarkItUp_ContextMenu_Menu.Hide(); 
	if( MarkItUp_ContextMenu_HandleItemClick.arguments.length == 3 && callback.length > 0 )
	{	
	    // handle in the client
		var args = new MenuItemClickedEventArgs( commandArgument ) ;
		callback( clickedItem, args ) ; // callback is a function pointer to the client handler
	}else{	
	    // eval the __doPostBack string
		eval( MarkItUp_ContextMenu_Menu.PostBackScript.replace( "@menuResult@", commandArgument ) );
	}
}

function MarkItUp_ContextMenu_HandleDocumentClick()
{
	if( MarkItUp_ContextMenu_Menu ) 
		MarkItUp_ContextMenu_Menu.Hide() ;
}

window.document.onmousedown = MarkItUp_ContextMenu_HandleDocumentClick ;


// write out positional style information into page
if( browser.isDOM )
{
	document.writeln('<style>');
	document.writeln('#MarkItUp_ContextMenu_MenuContainer {');
	document.writeln('position : absolute;');
	document.writeln('z-index : 100;');
	document.writeln('left: -200;') ;
	document.writeln('width : 160px;');
	document.writeln('}');
	document.writeln('</style>');
	document.writeln('<DIV Id="MarkItUp_ContextMenu_MenuContainer"></DIV>') ;
}



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
//			Global, Public Members
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


// global reference to the menu object
var MarkItUp_ContextMenu_Menu = null ;

// Display the menu when the user mouses over a trigger element
// called either OnClick or OnMouseOver
function MarkItUp_ContextMenu_ShowMenu( e, menuClientId, linkCommandArgument )
{ 
	if( MarkItUp_ContextMenu_Menu == null )
	{
		MarkItUp_ContextMenu_Menu = new Menu( e, menuClientId, linkCommandArgument ) ;
	}
	else if( !MarkItUp_ContextMenu_Menu.IsOwnedBy( e ) ) 
	{
		MarkItUp_ContextMenu_Menu = new Menu( e, menuClientId, linkCommandArgument ) ; 
	}
	else
	{
		return ;
	}
	
	if ( browser.isDOM )
	{
		MarkItUp_ContextMenu_Menu.x = MarkItUp_ContextMenu_GetRealX( e ) + 10
		MarkItUp_ContextMenu_Menu.y = MarkItUp_ContextMenu_GetRealY( e ) + 10
		MarkItUp_ContextMenu_Menu.Show() ;
	}
	MarkItUp_ContextMenu_Menu.Owner = e ;
}


function MarkItUp_ContextMenu_GetRealX(obj)
{
	var curleft = 0;
	if (obj.offsetParent)
	{
		while (obj.offsetParent)
		{
			curleft += obj.offsetLeft;
			obj = obj.offsetParent;
		}
	}
	else if (obj.x)
		curleft += obj.x;
	return curleft;
}

function MarkItUp_ContextMenu_GetRealY(obj)
{
	var curtop = 0;
	if (obj.offsetParent)
	{
		while (obj.offsetParent)
		{
			curtop += obj.offsetTop;
			obj = obj.offsetParent;
		}
	}
	else if (obj.y)
		curtop += obj.y;
	return curtop;
}