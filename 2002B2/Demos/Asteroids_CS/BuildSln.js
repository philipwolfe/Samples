// 
// ---------------------------------------------------------------
// Executes a command and echos the output to the Shell.
//
// This script executes a command and echos the output to the 
// shell. It is meant to be run from a command line like a batch
// file and echos the output to the console. CScript is the command 
// line execution engine for the WSH enviroment.
//
// It does this by piping the output to a file and then writing the
// file to the screen. The command line arguments are concatenated
// together in order to do so.
//
// Usage: Execute.js [args]
//

var l_script_usage = "This script executes a command and echos the output to the \nshell. It is meant to be run from a command line like a batch \nfile and echos the output to the console. CScript is the command \nline execution engine for the WSH enviroment. \n\nIt does this by piping the output to a file and then writing the \nfile to the screen. The command line arguments are concatenated \ntogether in order to do so. \n\nUsage: Execute.js [args]";

var COMSPEC_TYPE = " /C "; // [/C | /K]
var PIPE = " > ";

var g_debug_script = false;

function ExecuteCommand(fso, shell, File_Arguments)
{
	var WindowsFolder = 0, SystemFolder = 1, TemporaryFolder = 2;
	var Env = shell.Environment("SYSTEM");
	var ComSpec = shell.ExpandEnvironmentStrings( Env("ComSpec") );
	var Folder = fso.GetSpecialFolder( TemporaryFolder );
	var PipeFile = fso.BuildPath(Folder.Path, fso.GetTempName());
	var Cmd = ComSpec + COMSPEC_TYPE + File_Arguments + PIPE + PipeFile;
		
	if( g_debug_script )
	{
		/*
		WScript.Echo("COMSPEC: " + ComSpec);		
		WScript.Echo("Pipe File: " + PipeFile);
		WScript.Echo("Temporary Folder: " + Folder.Path );
		WScript.Echo("Command: " + File_Arguments + PIPE + PipeFile);	
		WScript.Echo("Shell Command: " + Cmd);
		*/
	}
	
	if(g_debug_script)
		shell.Run(Cmd, 10, true); // 0 = runtime, 10 = view debug
	else
		shell.Run(Cmd, 0, true); // 0 = runtime, 10 = view debug
	
	return PipeFile;

}

function EchoStdOut(fso, shell, File_Arguments)
{
	var ForReading = 1, ForWriting = 2, ForAppending = 8;
	var TristateUseDefault = -2, TristateTrue = -1, TristateFalse = 0;
	var StdOut = ExecuteCommand(fso, shell, File_Arguments );
	var op = "";	
	
	if( !fso.FileExists( StdOut ) )
	{
		WScript.Echo("Error running command.");
		return op;
	}
	
	var file = fso.GetFile( StdOut );
	if(file == null) return op;

	var fs = file.OpenAsTextStream(ForReading, TristateUseDefault);
	if(fs == null) return op;
	
	if( !fs.AtEndOfStream )
		op = fs.ReadAll( );
	
	fs.Close();
	file.Delete();
	
	return op;
}

function LoadXmlDom(xml)
{
	//Create and Load Dom from XML
	var xmldom = new ActiveXObject("Msxml2.DOMDocument.3.0");

	xmldom.async = false;
	xmldom.load(xml); //XML
	if( xmldom.parseError.errorCode )
	{
		WScript.Echo( xml + "(" + xmldom.parseError.Line + ") Error = " + xmldom.parseError.errorCode + " : " + xmldom.parseError.reason );
		WScript.Quit();
	}
	
    return xmldom;
}

function GetXPathAttributes(dom, xpath, attribute, delimiter)
{
	var ret = "";

	var nodes = dom.selectNodes(xpath);
	if( nodes == null ) return ret;
	
	for ( i = 0; i < nodes.length; i++)
	{
		var node = nodes(i);
		var attrib = node.getAttribute(attribute);
		if(attrib != null )
			ret += attrib;
		if( i + 1 < nodes.length )
			ret += delimiter;
	}
	
	if( g_debug_script )
		WScript.Echo("XPath: " + xpath + " Attribute: " + attribute + " Selection: " + ret);
	
	return ret;
}

function GetXPathIndexAttribute(dom, xpath, attribute, index)
{
	var ret = "";

	var nodes = dom.selectNodes(xpath);
	if( nodes == null || nodes.length < index ) return ret;
	
	var node = nodes(index);	
	if( node == null ) return ret;
	
	var attrib = node.getAttribute(attribute);
	if(attrib != null )
		ret = attrib;
	
	if( g_debug_script )
		WScript.Echo("XPath: " + xpath + " Attribute: " + attribute + "Index: " + index + " Selection: " + ret);
	
	return ret;
}

function GetSingleXPathAttribute(dom, xpath, attribute)
{
	var ret = "";

	var node = dom.selectSingleNode(xpath);
	if( node == null ) return ret;
	
	var attrib = node.getAttribute(attribute);
	if(attrib != null )
		ret += attrib;
	
	if( g_debug_script )
		WScript.Echo("XPath: " + xpath + " Attribute: " + attribute + " Selection: " + ret);
	
	return ret;
}

function GetProjectDirectory(fso, csproj)
{
	var fullPath = fso.GetAbsolutePathName(csproj);
	return fullPath.substr(0, fullPath.lastIndexOf("\\") );
}

function GetSourceFiles(dom, fso, projdir)
{
	var source = "";
	var i = 0;
	var arrSources = new Array();
	
	while( (source = GetXPathIndexAttribute(dom, "//Files/Include/File[@BuildAction = 'Compile']", "RelPath", i) ) != "" )
		arrSources[i++] = fso.GetAbsolutePathName( source );

	var j = 0;
	
	while( (source = GetXPathIndexAttribute(dom, "//Files/Include/File[@BuildAction = 'Compile']", "Link", j) ) != "" )
		arrSources[i + j++] = fso.BuildPath(projdir, source );

	var sources = "";
	
	for(i = 0; i < arrSources.length; i++)
		sources += arrSources[i] + " ";

	return sources;
}

function GetResourceFiles(dom)
{
	return GetXPathAttributes(dom, "//Files/Include/File[@BuildAction = 'EmbeddedResource']", "Link", ",");
}

function GetReferenceAssembiles(dom, fso)
{
	var assembly = "";
	var i = 0;
	var arr = new Array();
	
	while( (assembly = GetXPathIndexAttribute(dom, "//References/Reference[@Name != '']", "Name", i) ) != "" )
		arr[i++] = assembly + ".dll";

	return arr;	
}

function GetConfigurationOption(dom, configuration, option)
{
	return GetSingleXPathAttribute(dom, "//Config[@Name = '" + configuration + "']", option);
}

function GetSetting(dom, setting)
{
	return GetSingleXPathAttribute(dom, "//Settings", setting);
}

function CompileResources(dom, fso, shell, objDir)
{
	var ret = "";
	//var resources = GetResourceFiles(dom);
	
	var resources = "";
	var i = 0;
	var arr = new Array();
	
	while( (resources = GetXPathIndexAttribute(dom, "//Files/Include/File[@BuildAction = 'EmbeddedResource']", "Link", i) ) != "" )
		arr[i++] = resources;	
	
	if( arr.length == 0 ) return ret;

	for( i = 0; i < arr.length; i++)
	{
		var resPath = fso.GetAbsolutePathName( arr[i] );
		var slash = resPath.lastIndexOf("\\");
		var dot = resPath.lastIndexOf(".");

		var resFile = objDir + "\\" + resPath.substr(slash + 1, dot-slash) + "resources";
	   	var cmd = "ResGen.exe " + resPath + " " + resFile;

		WScript.Echo("Preparing resources... " + resPath.substr( slash + 1 ));
		if( g_debug_script ) WScript.Echo(cmd);

		var op = EchoStdOut(fso, shell, cmd);
		WScript.Echo(op);
		
	   	ret += (ret.length != 0) ? " " + resFile : resFile;
	}

	return ret;
}

function BuildResourceOption( resources )
{
	return ( resources == "" ) ? "" : " /resource:" + resources;
}

function BuildOutputOption( output, type )
{
	var exe = /exe/i;
	var lib = /lib/i;
	
	if(type.match(exe) != null)
		return " /out:" + output + ".exe";
	else if(type.match(lib) != null)
		return " /out:" + output + ".dll";
	else
		return " /out:" + output + ".mod";
}

function BuildTargetOption( target )
{
	return " /target:" +  target.toLowerCase();
}

function BuildDocumentationOption( doc )
{
	return doc == "" ? "" :" /doc:" + doc;
}
function BuildEntryPointOption( type )
{
	return type == null || type == "" ? " " : "/main:" + type;
}
function BuildAssembliesOption( assemblies )
{
	var ret = ""; //" /reference: ";

	for( i = 0; i < assemblies.length; i++)
		ret += " /r:" + assemblies[i];

	return ret;
}
function BuildModulesOption( modules )
{
	return " /addmodule:" + modules;
}
function BuildDebugOption( configuration )
{
	var re = /debug/i;
	if(configuration.match(re) != null)
		return " /debug+ /debug:full";
	else
		return " /debug- /debug:pdbonly";
}
function BuildWarningOption( )
{
	return " ";
}
function BuildSymbolsOption( symbols )
{
	return " /define:" + symbols;
}
function BuildSourcesOption( sources )
{
	return " " + sources;
}

function CompileProject(fso, shell, csproj, configuration)
{
	var cmd = "csc.exe";

	//
	// Setup Temp Directory
	//	
	var objDir = "";
	var projDir = GetProjectDirectory(fso, csproj); 
	objDir = projDir + "\\" + "obj";	
	if( !fso.FolderExists( objDir ) ) fso.CreateFolder( objDir );
	objDir = projDir + "\\" + "obj" + "\\" + configuration;
	if( !fso.FolderExists( objDir ) ) fso.CreateFolder( objDir );

	//
	// Build Output Settings
	//
	var type = GetSetting(LoadXmlDom(csproj), "OutputType");
	var assemblyName = GetSetting(LoadXmlDom(csproj), "AssemblyName");
	var outputDir = GetConfigurationOption(LoadXmlDom(csproj), configuration, "OutputPath");
	var fullOutputDir = fso.GetAbsolutePathName( outputDir );
	var assemblyDir = fso.BuildPath(fullOutputDir, assemblyName);
		
	cmd += BuildTargetOption( type );
	cmd += BuildOutputOption( assemblyDir, type );
	cmd += BuildEntryPointOption( null );

	//
	// Compile Resources
	//
	cmd += BuildResourceOption( CompileResources( LoadXmlDom(csproj), fso, shell, objDir )); 

	//
	// Specify Documentation File
	//
	var docFile = GetConfigurationOption(LoadXmlDom(csproj), configuration, "DocumentationFile");
	if( docFile.length != 0 )
	{
		var fullDocDir = fso.BuildPath(fullOutputDir, docFile);
		cmd += BuildDocumentationOption( fullDocDir  );
	}

	//
	// Assembly Link Settings
	//	
	cmd += BuildAssembliesOption( GetReferenceAssembiles( LoadXmlDom(csproj), fso ));
	//cmd += BuildModulesOption( GetReferenceAssembiles( LoadXmlDom(csproj) ));

	//
	// Build Configuration Settings
	//
	cmd += BuildDebugOption( configuration );
	//cmd += BuildWarningOption( );
	cmd += BuildSymbolsOption( GetConfigurationOption(LoadXmlDom(csproj), configuration, "DefineConstants") );
	
	//
	// Build Sources Files
	//
	cmd += BuildSourcesOption( GetSourceFiles( LoadXmlDom(csproj), fso, projDir ));

	if(g_debug_script || true) WScript.Echo(cmd);
	
	WScript.Echo("Compiling " + assemblyName + "... ");		
	var op = EchoStdOut(fso, shell, cmd);
	WScript.Echo(op);
}

function SetTrustee(Services, Domain, Name, SID)
{
     var trustee = Services.Get("Win32_Trustee").SpawnInstance_();
     trustee.Domain = Domain;
     trustee.Name = Name;
     trustee.SID = SID;
     return trustee;
}

function SetACE(Services, AccessMask, AceFlags, AceType, Trustee)
{
     var Ace = Services.Get("Win32_Ace").SpawnInstance_();
     Ace.AccessMask = AccessMask;
     Ace.AceFlags = AceFlags;
     Ace.AceType = AceType;
     Ace.Trustee = Trustee;
     return Ace;
}

//
//Note: The WMI operating system core components are supported 
//on Windows NT 4.0 with Service Pack 4 or later, including Windows 2000, 
//and on Windows 95 OSR2 and Windows 98.
//
function CreateAuthenticatedUserShare(Path, Name, Description)
{
	var locator = new ActiveXObject("WbemScripting.SWbemLocator");
	var server = locator.ConnectServer();
	//locator.Security_.ImpersonationLevel = 3; //wbemImpersonationLevelImpersonate == 3

	// Get the Win32_SecurityDescriptor class and spawn a new instance.
    var SecurityDescriptor = server.Get("Win32_SecurityDescriptor");
    var sd = SecurityDescriptor.SpawnInstance_();
    
    //
	// Prepare the Security Descriptor for the new share.
	//
    sd.ControlFlags = 4;

    //var AceLocalAdmin = SetACE(server, 2032127, 3, 0, 
	//				SetTrustee(server, "orleans", 
	//					"administrator", 
	//					new Array(1, 5, 0, 0, 0, 0, 0, 5, 21, 0, 0, 0, 160, 101, 207, 126, 120, 75, 155, 95, 231, 124, 135, 112, 119, 238, 0, 0)
	//				)
	//			);
    var AceAuthenticatedUsers = SetACE(server, 2032127, 3, 0, 
					SetTrustee(server, "US", 
						"Authenticated Users", 
						new Array(1, 1, 0, 0, 0, 0, 0, 5, 11, 0, 0, 0)
					)
				);
    //var AceEveryone = SetACE(server, 2032127, 3, 0, 
	//				SetTrustee(server, null, 
	//					"EVERYONE", 
	//					new Array(1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0)
	//				)
	//			);
    
	//sd.DACL = new Array(AceLocalAdmin, AceAuthenticatedUsers, AceEveryone);
	sd.DACL = new Array(AceAuthenticatedUsers);
    
    //
	// Create the new share 
	//
    var share = server.Get("Win32_Share");
    var params = share.Methods_("Create").InParameters.SpawnInstance_();

	params.Access = sd;
    params.Description = Description;
    params.Name = Name;
    params.Path = Path;
    params.Type = 0;
    
    //params.MaximumAllowed = 10;		//optional - default is 'max allowed'
    //params.Password = "Password";		//optional - default is no password

	//
	// Execute the method.
	//
    var ret = share.ExecMethod_("Create", params);
    if (ret.ReturnValue == 0 )
    {
		WScript.Echo("Share " + Name + " at " + Path + " created successfully");
	}
    else
	{
		WScript.Echo( (ret.ReturnValue == 22 ) ? 
		"Share may already exist" :
		"Unable to create share, return value was : " + ret.ReturnValue);
	}
}

//
//Note: The WMI operating system core components are supported 
//on Windows NT 4.0 with Service Pack 4 or later, including Windows 2000, 
//and on Windows 95 OSR2 and Windows 98.
//
function DeleteShare(Name)
{
	var locator = new ActiveXObject("WbemScripting.SWbemLocator");
	var server = locator.ConnectServer();
	//locator.Security_.ImpersonationLevel = 3; //wbemImpersonationLevelImpersonate == 3

    //
	// Find the share 
	//
    var share = server.Get("Win32_Share=\"" + Name + "\"");
    if( share == null ) 
    {
		WScript.Echo("Share not found." );
		return;
    }

	//
	// Execute the method.
	//
    var ret = share.Delete();
    if (ret == 0 )
    {
		WScript.Echo("Share '" + Name + "' deleted successfully");
	}
    else
	{
		WScript.Echo( (ret.ReturnValue == 22 ) ? 
		"Share may already exist" :
		"Unable to delete share, return value was : " + ret.ReturnValue);
	}
}


function Main()
{
	var fso = new ActiveXObject("Scripting.FileSystemObject");
	var shell = new ActiveXObject("WScript.Shell");

	var args = WScript.Arguments;
	var arg = "";
	var File_Arguments = "";

	if( args.Count() < 1 )
	{
		WScript.Echo( l_script_usage );
		WScript.Quit();
	}

	for(i = 0; i < args.Count(); i++)
		File_Arguments += args(i) + " ";

	if( g_debug_script )
		WScript.Echo("Args: " + File_Arguments);		

	CompileProject(fso, shell, args(0), "Debug");
}


Main();
