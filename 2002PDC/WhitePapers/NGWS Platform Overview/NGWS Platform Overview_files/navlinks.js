
	// -----------------------------------------------------------
	// InitNavLinks()
	// Sets link text, URL and icon for NavLinks Show based on framed state
	// -----------------------------------------------------------

	function InitNavLinks()
	{
		if ("object" != typeof(lnkShowImg) || "object" != typeof(imgShow) || "object" != typeof(lnkShowImg.all.tags( "FONT" )))
		{
			return false;
		}

		var bIsFramed = ((top != self) && ("TOC" == top.frames[0].name));
		if (bIsFramed)
		{
			lnkShowImg.all.tags( "FONT" )[0].innerText = "hide toc";
			lnkShowImg.href = self.location.href;
			imgShow.src = "/msdn-online/shared/graphics/icons/hidetoc.gif";
		}
		else
		{
			lnkShowImg.all.tags( "FONT" )[0].innerText = "show toc";
			var sPath = self.location.pathname;

			// WATCH OUT FOR INSTANCES OF MSDN-ONLINE !!!	
			sPath = sPath.replace("/msdn-online","");
			var sFrameHref = sPath.match(/[/][^/]+[/]/) + "c-frame.htm#" + sPath;
			lnkShowImg.href = sFrameHref;
			imgShow.src = "/msdn-online/shared/graphics/icons/showtoc.gif";
		}
	}

	// -----------------------------------------------------------
	// NavLinks_hover()
	// DHTML script for NavLinks mouseover and mouseout.
	// -----------------------------------------------------------

	
		/////////////////////////////////////////////////////////////
		//
		//	Function: process_button() - Button Event handler
		//	Parameters: none
		//	Returns: void
		//
		//	This function processes mouse and keyboard events on all
		//	button elements (className contains "Btn" within a given
		//	container.  Button specific processing is sent to the buttonClick()
		//  	function. Information about the button can be stored in expandos,
		//			STATE ( "On" , "Off" )
		//			IMG ( contains the base name and ID of the icon )
		//
		/////////////////////////////////////////////////////////////
	
	
		function process_button()
		{
			var oEl = event.srcElement;
			event.cancelBubble = true;
			while( -1 == oEl.className.indexOf( "Btn" ) )
			{
				oEl = oEl.parentElement;
				if( !oEl ) return;
			}
			var baseClass = oEl.className.substring( 0 , oEl.className.indexOf( "Btn" ) + 3 );
			var btnImage = null;
			if( oEl.IMG ) btnImage = oEl.all.tags( "IMG" )[0];
	
			switch( event.type )
			{
				case "mouseout" :
					if( oEl.contains( event.toElement ) ) return;
					if( btnImage )
					{
						btnImage.src =  btnImage.src.substring( 0 , btnImage.src.length - 5 ) + "1.gif";
					}
					if( oEl.STATE )
					{
	
						oEl.className = baseClass + oEl.STATE;
					}
					else
					{
						oEl.className = baseClass + "Off";
					}
					break;
				case "mouseover" :
					if( oEl.contains( event.fromElement ) ) return;
					
					if( btnImage )
					{
						btnImage.src =  btnImage.src.substring( 0 , btnImage.src.length - 5 ) + "2.gif";
					}
					if( oEl.STATE )
					{
						var tmpState = oEl.STATE == "Off" ? "Up" : "Down";
						oEl.className = baseClass + tmpState;
					}
					else
					{
						oEl.className = baseClass + "Up";
					}
					break;
	
				case "mousedown" :
					oEl.className = baseClass + "Down";
					break;
	
				case "mouseup" :
					if( oEl.STATE )
					{
						oEl.STATE = oEl.STATE == "Off" ? "On" : "Off";
						var tmpState = oEl.STATE == "On" ? "Down" : "Up";
						oEl.className = baseClass + tmpState;
					}
					else
					{
						oEl.className = baseClass + "Up";
					}
					break;
	
				case "click" :
					event.returnValue = doButtonClick( oEl );
					break;
	
				case "dblclick" :
					event.returnValue = doButtonClick( oEl );
					break;
	
				case "keyup" :
					if( 13 == event.keyCode )
					{
						if( oEl.STATE )
						{
							oEl.STATE = oEl.STATE == "Off" ? "On" : "Off";
							var tmpState = oEl.STATE == "On" ? "Down" : "Up";
							oEl.className = baseClass + tmpState;
						}
						else
						{
							oEl.className = baseClass + "Up";
						}
						event.returnValue = doButtonClick( oEl );
					}
					break;
					
				case "selectstart" :
					if( oEl )
					{
						event.returnValue = false;
						return false;
					}
					break;
	
				default :
					break;
	
			}
		}
	
	////////////////////////////////////////////////////////////////////
	//
	//	Function: doButtonClick()
	//	Parameters: oEl - Button Element which fired the event
	//	Returns: event return value
	//
	//	This function navigates to the first link contained in a button,
	//	or performs a custom button action if one is defined on an individual page.
	//
	////////////////////////////////////////////////////////////////////
	
		function doButtonClick( oEl )
		{
			var oLink = oEl.all.tags( "A" );
			if( oLink.length  )
			{
				if( "_blank" == oLink[0].target )
				{
					winComments = window.open(  oLink[0].href ,"winComments" , "width=640,height=480,location=no,status=yes,resizable=yes,scrollbars=yes,menubar=yes,toolbar=no" );
					winComments.focus();
					event.returnValue = false;
					return false;
				}
				else if( !oEl.ACTION )
				{
					oLink[0].click();
					return true;
				}
			}
			
			if( "function" == typeof( fnCustomAction ) )
			{	
				return fnCustomAction( oEl );
			}
		}

	// -----------------------------------------------------------
	// PreloadNavLinksImages()
	// Preloads mouseover images.
	// -----------------------------------------------------------

	function PreloadNavLinksImages()
	{
		var sRootPath = new String("/msdn-online/shared/graphics/icons/");
		var aImages = new Array("show","hide","sync","index","search","prev","next","up");
		for (var i=0;i<aImages.length;i++)
		{
			var eImg = new Image();
			eImg.src = sRootPath + "nl-" + aImages[i] + "-1.gif";
		}
	}
	if (oBD.getsNavBar) PreloadNavLinksImages();
