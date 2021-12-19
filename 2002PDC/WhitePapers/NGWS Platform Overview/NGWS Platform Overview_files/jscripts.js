	function ValidateForm(eForm)
	{
		if ("" == eForm.qu.value || "Enter phrase" == eForm.qu.value)
		{
			window.alert("Please enter a search phrase.   ");
			eForm.qu.focus();
			eForm.qu.select();
			return false;
		}
	}

function ToggleDisplay(oButton, oItems)
{

	if (oItems.style.display == "none")	{
		oItems.style.display = "";
		oButton.src = "/msdnmag/images/minus.gif";
	}	else {
		oItems.style.display = "none";
		oButton.src = "/msdnmag/images/plus.gif";
	}
	return false;
}

function leftnav_keyup()
{
	var oActive = window.event.srcElement;
	var sActiveId = oActive.id;
	oItem = document.all[ sActiveId + "items" ];
	oBtn = document.all[ sActiveId + "btn" ];
	if (event.keyCode == 13) {

		if ('clsTocHead' == oActive.className)
		{
			ToggleDisplay(oBtn ,oItem );
		} 
	}
	return;
}


	
	
		/////////////////////////////////////////////////////////////
		//
		//	Function: process_button() - Button Event handler
		//	Parameters: none
		//	Returns: void
		//
		//	This function processes mouse and keyboard events on all
		//	button elements (className contains "clsBtn" within a given
		//	container.  Button specific processing is sent to the buttonClick()
		//  function. Information about the button can be stored in expandos,
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
				case "mouseout" 	:
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
				case "mouseover" 	:
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
	
				case "mousedown" 	:
					oEl.className = baseClass + "Down";
					break;
	
				case "mouseup" 		:
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
	
				case "click" 		:
					doButtonClick( oEl );
					break;
	
				case "keyup" 		:
					if( 13 == event.keyCode )
					{
						doButtonClick( oEl );
					}
					break;
					
				case "selectstart" :
					if( oEl )
					{
						event.returnValue = false;
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
	//	Returns: void
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
					return false;
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
