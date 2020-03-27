NS4 = (document.layers) ? 1 : 0;
IE4 = (document.all) ? 1 : 0;
ver4 = (NS4 || IE4) ? 1 : 0;   
isMac = (navigator.appVersion.indexOf("Mac") != -1) ? 1 : 0;
isTrans = (IE4 && !isMac) ? 1 : 0;

var localRoot = "http://www.microsoft.com/games/";
