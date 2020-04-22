<script>
var IsAuthenticated = false;
var UpdateInterval;

/* Get the game state and re-generate the scoreboard */
function Update()
{
	var bool = TankClientControl.GameStarted;
	if (bool == true)
	{						
		var gamestate = TankClientControl.GetGameState()
		
		var html = "<table height='100%' width='100%' cellpadding='0' cellspacing='0' border='1'><col width='2%'><col width='24%'><col width='22%'>";
		var playerInfo = new Enumerator(gamestate.split(';'));						
		
		for (;!playerInfo.atEnd(); playerInfo.moveNext())
		{				
			var items = playerInfo.item().split(',');
			
			html += "<tr valign='top'><td align='left'>&nbsp;</td><td align='left'><span class='regulartext'>";
						
			if (items[0] == "{{GetUserName}}")
			{
				html += "<b>";
			}
			
			html += items[0];
			html += "</span></td><td align='left'><span class='regulartext'>";
			html += items[1];
			html += "pts</span></td></tr>";			
			
			if (items[0] == "{{GetUserName}}")
			{
				html += "</b>";
			}
		}
		html += "</table>";
		
		scoreboard.innerHTML = html;				
	}
}

function OkToShoot()
{	
	if (IsAuthenticated)
	{
		if (confirm("Do you want to purchase a Tank license with this card?"))
		{
			TankClientControl.CanShoot = true;
		}
	}
	else
	{
		alert("Please sign in with your Passport account first!");
	}
}

function OnDelete(deleteURL, deleteID, refreshURL, refreshBody)
{		
	var xmlHttp		= new ActiveXObject("Microsoft.XMLHTTP");
	var url			= deleteURL + "?id=" + deleteID;
			
	xmlHttp.Open("GET", url, false);
	xmlHttp.Send("nothing");				
		
	Refresh(refreshURL, refreshBody);
}		

function OnAdd(addURL, refreshURL, refreshBody)
{	
	showModalDialog(addURL);
	
	// refresh this page
	Refresh(refreshURL, refreshBody);
}

function Refresh(refreshURL, refreshBody)
{	
	var xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");	
	xmlHttp.Open("GET", refreshURL, false);
	xmlHttp.Send("nothing");				
	this.document.body.all[refreshBody].innerHTML = xmlHttp.responseText;
}

function SelectAll(cb, collection)
{					
	if (this.document.body.all[collection].length > 0)
	{		
		var allItems = new Enumerator(this.document.body.all[collection]);
		for (;!allItems.atEnd(); allItems.moveNext())
		{			
			var contact = allItems.item();			
			contact.checked = cb.checked;
		}
	}
	else
	{
		this.document.body.all[collection].checked = cb.checked;
	}
}
</script>	

<script for=document event=onstop>
	window.clearInterval(UpdateInterval);
</script>
