var ToolBar_Supported = ToolBar_Supported ;
if (ToolBar_Supported != null && ToolBar_Supported == true)
{
	//To Turn on/off Frame support, set Frame_Supported = true/false.
	Frame_Supported = false;

	// Customize default ICP menu color - bgColor, fontColor, mouseoverColor
	setDefaultICPMenuColor("#000000", "#ffffff", "#ff0000");

	// Customize toolbar background color
	setToolbarBGColor("#000000");
	
	// display ADS
	setAds("games/headline.gif","/isapi/gomscom.asp?target=/games/","") ;

	// display ICP Banner
	setICPBanner("games/clear.gif","/isapi/gomscom.asp?target=/games/","") ;
	
	//***** Add ICP menus *****
	//Home
	addICPMenu("HomeMenu", "Home", "","");
	addICPSubMenu("HomeMenu","Microsoft Games home","/games/default.asp");

	//downloads
	addICPMenu("DownloadsMenu", "Downloads", "","");
	addICPSubMenu("DownloadsMenu","Trial Versions","/games/_redir/d_trial.asp");
	addICPSubMenu("DownloadsMenu","Patches","/games/_redir/d_patch.asp");
	addICPSubMenu("DownloadsMenu","Goodies","/games/_redir/d_goodies.asp");
	addICPSubMenu("DownloadsMenu","CD Sampler","/games/_redir/d_sampler.asp");

	//News
	addICPMenu("NewsMenu","News", "","");
	addICPSubMenu("NewsMenu","Age II: The Conquerors Expansion Trial Version!","/games/_redir/h_headline1.asp?URL=/games/default.asp#h1");
	addICPSubMenu("NewsMenu","All Aboard! Train Simulator Has Left the Station","/games/_redir/h_headline2.asp?URL=/games/default.asp#h2");
	addICPSubMenu("NewsMenu","Gamevoice: Add the power of voice to your games","/games/_redir/h_headline3.asp?URL=/games/default.asp#h3");
	addICPSubMenu("NewsMenu","All-New Conquest: Frontier Wars Web Site Goes Live","/games/_redir/h_headline4.asp?URL=/games/default.asp#h4");
	addICPSubMenu("NewsMenu","Behind the Scenes with Sergio Garcia and Links 2001","/games/_redir/h_headline5.asp?URL=/games/default.asp#h5");
	addICPSubMenu("NewsMenu","Midtown Madness 2 Revs it Up on the Web","/games/_redir/h_headline6.asp?URL=/games/default.asp#h6");
	addICPSubMenuLine("NewsMenu");
	addICPSubMenu("NewsMenu","Current","/games/default.asp?filter=current");
	addICPSubMenu("NewsMenu","Archive","/games/default.asp?filter=archive");
	addICPSubMenu("NewsMenu","Press Releases","/games/default.asp?filter=press");
	addICPSubMenuLine("NewsMenu");
	addICPSubMenu("NewsMenu","Subscribe to the Monthly Newsletter","/games/subscribe.htm");
	
	//Games List A-F
	addICPMenu("GamesMenu1", "Games A-F", "","");
	addICPSubMenu("GamesMenu1","Age of Empires II Expansion","/games/products.asp?filter=conquerors");
	addICPSubMenu("GamesMenu1","Age of Empires II","/games/products.asp?filter=age2");
	addICPSubMenu("GamesMenu1","Age of Empires Expansion","/games/products.asp?filter=aoeexpansion");
	addICPSubMenu("GamesMenu1","Age of Empires","/games/products.asp?filter=empires");
//	addICPSubMenu("GamesMenu1","Arcade","/games/products.asp?filter=arcade");
	addICPSubMenu("GamesMenu1","Allegiance","/games/products.asp?filter=allegiance");
	addICPSubMenu("GamesMenu1","Asheron's Call","/games/products.asp?filter=asheronscall");
//	addICPSubMenu("GamesMenu1","Baseball 3D","/games/products.asp?filter=baseball");
    addICPSubMenu("GamesMenu1","Baseball 2001","/games/products.asp?filter=baseball2001");
	addICPSubMenu("GamesMenu1","Baseball 2000","/games/products.asp?filter=baseball2000");
//	addICPSubMenu("GamesMenu1","CART Precision Racing","/games/products.asp?filter=cart");
	addICPSubMenu("GamesMenu1","Close Combat III: TRF ","/games/products.asp?filter=closecombat");
	addICPSubMenu("GamesMenu1","Close Combat II: ABTF","/games/products.asp?filter=cc2");
	addICPSubMenu("GamesMenu1","Close Combat","/games/products.asp?filter=cc1");
	addICPSubMenu("GamesMenu1","Combat Flight Simulator","/games/products.asp?filter=combatfs");
	addICPSubMenu("GamesMenu1","Conquest","/games/products.asp?filter=conquest");
    addICPSubMenu("GamesMenu1","Crimson Skies","/games/products.asp?filter=crimsonskies");
	addICPSubMenu("GamesMenu1","Dungeon Siege","/games/products.asp?filter=dungeonsiege");
	addICPSubMenu("GamesMenu1","EP: Puzzle Collection","/games/products.asp?filter=puzzle");
	addICPSubMenu("GamesMenu1","Fighter Ace II","/games/products.asp?filter=fighteraceii");
//	addICPSubMenu("GamesMenu1","Fighter Ace ","/games/products.asp?filter=fighterace");
	addICPSubMenu("GamesMenu1","Flight Simulator 2000","/games/products.asp?filter=fs2000");
	addICPSubMenu("GamesMenu1","Flight Simulator 98","/games/products.asp?filter=fsim");
    addICPSubMenu("GamesMenu1","Freelancer","/games/products.asp?filter=freelancer");

	//Games List G-Z
	addICPMenu("GamesMenu2", "Games G-Z", "","");
	addICPSubMenu("GamesMenu2","Golf 1999 Edition","/games/products.asp?filter=golf");
	addICPSubMenu("GamesMenu2","Intl. Soccer 2000","/games/products.asp?filter=soccer2000");
	addICPSubMenu("GamesMenu2","Links LS 10-Course Pack","/games/products.asp?filter=linkscourses");
	addICPSubMenu("GamesMenu2","Links 2001","/games/products.asp?filter=links2001");
	addICPSubMenu("GamesMenu2","Links LS 2000","/games/products.asp?filter=links2000");
	addICPSubMenu("GamesMenu2","Links LS 99","/games/products.asp?filter=links99");
	addICPSubMenu("GamesMenu2","Links Extreme","/games/products.asp?filter=linksextreme");
	addICPSubMenu("GamesMenu2","Links LS Mac","/games/products.asp?filter=linksmac");
	addICPSubMenu("GamesMenu2","Loose Cannon","/games/products.asp?filter=loosecannon");
//	addICPSubMenu("GamesMenu2","Midtown Madness 2","/games/products.asp?filter=midtown2");
	addICPSubMenu("GamesMenu2","MechCommander 2","/games/products.asp?filter=mechcommander2");
	addICPSubMenu("GamesMenu2","MechWarrior 4: Vengeance","/games/products.asp?filter=mechwarrior4");
	addICPSubMenu("GamesMenu2","Midtown Madness 2","/games/products.asp?filter=midtown2");
	addICPSubMenu("GamesMenu2","Midtown Madness","/games/products.asp?filter=midtown");
	addICPSubMenu("GamesMenu2","Monster Truck Madness 2","/games/products.asp?filter=monster");
	addICPSubMenu("GamesMenu2","Motocross Madness 2","/games/products.asp?filter=motocross2");
	addICPSubMenu("GamesMenu2","Motocross Madness","/games/products.asp?filter=motocross");
	addICPSubMenu("GamesMenu2","NBA Inside Drive 2000","/games/products.asp?filter=insidedrive2000");
	addICPSubMenu("GamesMenu2","NFL Fever 2000","/games/products.asp?filter=fever2000");
//	addICPSubMenu("GamesMenu2","Outwars","/games/products.asp?filter=outwars");
	addICPSubMenu("GamesMenu2","Pandora's Box","/games/products.asp?filter=pandorasbox");
	addICPSubMenu("GamesMenu2","Pinball Arcade","/games/products.asp?filter=pinball");
	addICPSubMenu("GamesMenu2","Return of Arcade","/games/products.asp?filter=arcade2");
	addICPSubMenu("GamesMenu2","Revenge of Arcade","/games/products.asp?filter=revenge");
	addICPSubMenu("GamesMenu2","StarLancer","/games/products.asp?filter=starlancer");
	addICPSubMenu("GamesMenu2","Tex Murphy: Overseer","/games/products.asp?filter=overseer");
	addICPSubMenu("GamesMenu2","Tex Murphy: Pandora Directive","/games/products.asp?filter=pandoradirective");
	addICPSubMenu("GamesMenu2","Tex Murphy: Under a Killing Moon","/games/products.asp?filter=underakillingmoon");
	addICPSubMenu("GamesMenu2","Train Simulator","/games/products.asp?filter=trainsim");
//	addICPSubMenu("GamesMenu2","Urban Assault","/games/products.asp?filter=urbanassault");

//Nitro
	addICPMenu("Nitro", "Order Online", "","");
	addICPSubMenu("Nitro","Age II: The Conquerors Expansion","/games/_redir/shop/age_2x.htm");
	addICPSubMenu("Nitro","Age of Empires II","/games/_redir/shop/age_2.htm");
	addICPSubMenu("Nitro","Age of Empires","/games/_redir/shop/age.htm");
	addICPSubMenu("Nitro","Age of Empires Expansion","/games/_redir/shop/age_x.htm");
	addICPSubMenu("Nitro","Age of Empires Gold","/games/_redir/shop/age_gold.htm");
	addICPSubMenu("Nitro","Allegiance","/games/_redir/shop/allegiance.htm");
	addICPSubMenu("Nitro","Asheron's Call","/games/_redir/shop/asherons_call.htm");
 addICPSubMenu("Nitro","Baseball 2001","/games/_redir/shop/baseball2001.htm");
//  addICPSubMenu("Nitro","Baseball 3D","http://shop.microsoft.com/referral/selector.asp?siteid=468&furl=1");
//  addICPSubMenu("Nitro","CART Precision Racing","http://shop.microsoft.com/referral/selector.asp?siteid=546&furl=1");
	addICPSubMenu("Nitro","Close Combat Trilogy: (1,2, &amp; 3)","/games/_redir/shop/closecombat_trilogy.htm");
	addICPSubMenu("Nitro","Close Combat III: TRF","/games/_redir/shop/closecombat_3.htm");
	addICPSubMenu("Nitro","Close Combat II: ABTF","/games/_redir/shop/closecombat_2.htm");
	addICPSubMenu("Nitro","Combat Flight Simulator","/games/_redir/shop/combat_flight_sim.htm");
	addICPSubMenu("Nitro","Entertainment Pack","/games/_redir/shop/ep.htm");
	addICPSubMenu("Nitro","EP: Puzzle Collection","/games/_redir/shop/ep_puzzle.htm");
	// addICPSubMenu("Nitro","Flight Simulator 95","http://shop.microsoft.com/referral/selector.asp?siteid=280&furl=1");
	addICPSubMenu("Nitro","Flight Simulator 98","/games/_redir/shop/fs_98.htm");
	addICPSubMenu("Nitro","Flight Simulator 2000","/games/_redir/shop/fs_2000.htm");
	addICPSubMenu("Nitro","Flight Simulator 2000 Pro","/games/_redir/shop/fs_2000_pro.htm");
	addICPSubMenu("Nitro","Golf 1999 Edition","/games/_redir/shop/golf_99.htm");
	addICPSubMenu("Nitro","Intl. Soccer 2000","/games/_redir/shop/soccer_2000.htm");
	addICPSubMenu("Nitro","Links LS 10-Course Pack","/games/_redir/shop/ls_10pack.htm");
	addICPSubMenu("Nitro","Links LS 2000","/games/_redir/shop/ls_2000.htm");
	addICPSubMenu("Nitro","Links Extreme","/games/_redir/shop/ls_extreme.htm");
	addICPSubMenu("Nitro","Links Libraries","/games/_redir/shop/ls_addon.htm");
	// addICPSubMenu("Nitro","Links LS 99","http://shop.microsoft.com/referral/selector.asp?siteid=10074&furl=1");
	addICPSubMenu("Nitro","Links LS Macintosh","/games/_redir/shop/ls_mac.htm");
	addICPSubMenu("Nitro","Midtown Madness","/games/_redir/shop/midtown_madness.htm");
	addICPSubMenu("Nitro","Monster Truck Madness 2","/games/_redir/shop/monster_truck_madness_2.htm");
	addICPSubMenu("Nitro","Motocross Madness 2","/games/_redir/shop/motocross_madness2.htm");
	addICPSubMenu("Nitro","Motocross Madness","/games/_redir/shop/motocross_madness.htm");
	addICPSubMenu("Nitro","NBA Inside Drive 2000","/games/_redir/shop/nba_2000.htm");
	addICPSubMenu("Nitro","NFL Fever 2000","/games/_redir/shop/nfl_fever.htm");
addICPSubMenu("Nitro","Pandora's Box","/games/_redir/shop/pandoras_box.htm");
	addICPSubMenu("Nitro","Pinball Arcade","/games/_redir/shop/pinball_arcade.htm");
	addICPSubMenu("Nitro","Return of Arcade","/games/_redir/shop/return_of_arcade.htm");
	addICPSubMenu("Nitro","Revenge of Arcade","/games/_redir/shop/revenge_of_arcade.htm");
	addICPSubMenu("Nitro","StarLancer","/games/_redir/shop/starlancer.htm");
	addICPSubMenuLine("Nitro");
	addICPSubMenu("Nitro","Microsoft Strategy Guides","/games/_redir/shop/ms_press.htm");

//	Related Links
	addICPMenu("relatedlinksMenu", "Related Links", "","");
	addICPSubMenu("relatedlinksMenu","Playtest Microsoft Games","/games/playtest/");
	addICPSubMenu("relatedlinksMenu","MSN Gaming Zone","http://www.zone.com");
	addICPSubMenu("relatedlinksMenu","Gaming Devices","/hardware/sidewinder/default.htm");



	setICPSubMenuWidth("HomeMenu","Absolute","210")
	setICPSubMenuWidth("DownloadsMenu","Absolute","125")
	setICPSubMenuWidth("NewsMenu","Absolute","330")
	setICPSubMenuWidth("GamesMenu1","Absolute","265")
	setICPSubMenuWidth("GamesMenu2","Absolute","265")
	setICPSubMenuWidth("Nitro","Absolute","265")
		

}