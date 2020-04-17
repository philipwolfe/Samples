if (WScript.Arguments.length != 1) { 
    WScript.Echo("Usage: CScript RestartTracing.js <PID>");
    WScript.Quit(0);
}

var PID = WScript.Arguments(0);
var locator = WScript.CreateObject ("WbemScripting.SWbemLocator");
var provider = locator.ConnectServer ("", "root/ServiceModel");
var indigo;
var objSet;
var count;

try
{
    indigo = GetObject("winmgmts:root/ServiceModel");
    objSet = indigo.ExecQuery("SELECT * FROM AppDomainInfo WHERE ProcessId=" + PID);
}
catch (e)
{
    WScript.Echo ("Failed to connect to root/ServiceModel (" + e + ")");
    Wcript.Quit(-1);
}

var domains = new Enumerator (objSet);
while (!domains.atEnd())
{
    var domain = domains.item ();
    var traceLevel = domain.TraceLevel;
    domain.TraceLevel = "Off";
    domain.Put_();

    var configPath = domain.ServiceConfigPath;
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    if (!fso.FileExists(configPath))
    {
        WScript.Echo("Configuration file " & configPath & " was not found. Is your service running on remote computer?");
        WScript.Quit(0);
    }
    WScript.Echo("Found configuration file " + configPath);
    var configFile = fso.GetFile(configPath);
    var configFolder = configFile.ParentFolder;
    var traceListeners = new VBArray(domain.ServiceModelTraceListeners);
    traceListeners = traceListeners.toArray();
    WScript.Echo("Found " + traceListeners.length + " trace listeners");
    WScript.Echo("Looking for trace files in " + configFolder);
    for (var j = 0 ; j < traceListeners.length ; j++)
    {
        
        var arguments = new VBArray(traceListeners[j].TraceListenerArguments);
        arguments = arguments.toArray();
        for (var i = 0 ; i < arguments.length ; i++)
        {
            if (arguments[i].Name == "initializeData" && arguments[i].Value != "")
            {
                SaveAndDelete(configFolder + "\\" + arguments[i].Value);
            }
        }
    }
    //restart tracing
    domain.TraceLevel = traceLevel;
    domain.Put_();
    domains.moveNext ();
}

function SaveAndDelete(path) 
{
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    if (!fso.FileExists(path))
    {
        WScript.Echo("Trace file " + path + " was not found.");
    }
    else
    {
        var traceFile = fso.GetFile(path);
        var currentTime = new Date()
        var newName = path + "." + currentTime.getFullYear() + "." + currentTime.getMonth() + "." + currentTime.getDay() + "." + currentTime.getHours() + "." + currentTime.getMinutes()  + "." + currentTime.getSeconds() + ".svclog";
        traceFile.Move(newName);
        WScript.Echo("Moved " + path + " to " + newName);
    }
}
