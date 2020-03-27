/* (C) 2001 Microsoft Corporation  */

var bCopyOnly = false;

function OnFinish(selProj, selObj)
{
	try
	{
		var strProjectPath = wizard.FindSymbol("PROJECT_PATH");
		var strProjectName = wizard.FindSymbol("PROJECT_NAME");

		var bEmptyProject = wizard.FindSymbol("EMPTY_PROJECT");

		selProj = CreateProject(strProjectName, strProjectPath);

		AddCommonConfig(selProj, strProjectName);
		AddSpecificConfig(selProj, strProjectName, bEmptyProject);

		SetFilters(selProj);

		if (!bEmptyProject)
		{
			var InfFile = CreateInfFile();
			AddFilesToProject(selProj, strProjectName, InfFile);
			SetCommonPchSettings(selProj);
			InfFile.Delete();
			var projName = strProjectPath + "\\" + strProjectName + ".vcproj";
			selProj.Object.Save();
		}
	}
	catch(e)
	{
		if (e.description.length != 0)
			SetErrorInfo(e);
		return e.number
	}
}

function GetTargetName(strName, strProjectName, strResourcePath)
{
	var strTarget = strName;

	if (strName == "readme.txt")
		strTarget = "ReadMe.txt";
	if (strName == "resource.h")
		strTarget = "Resource.h";

	if (strName == "small.ico")
	{
		strTarget = "small.ico";
		bCopyOnly = true;
	}
	if (strName.substr(0, 4) == "root")
	{
		var strlen = strName.length;
		if (strName == "root.ico")
			bCopyOnly = true;

		strTarget = strProjectName + strName.substr(4, strlen - 4);
	}
	return strTarget; 
}


function AddSpecificConfig(proj, strProjectName, bEmptyProject)
{
	var bMFC = wizard.FindSymbol("SUPPORT_MFC");

	var config = proj.Object.Configurations("Debug|Win32");
	config.CharacterSet = charSetMBCS;


	var CLTool = config.Tools("VCCLCompilerTool");
	if (bEmptyProject)
	{
		CLTool.UsePrecompiledHeader = pchGenerateAuto;
	}


	if (bMFC)
		CLTool.RuntimeLibrary = rtMultiThreadedDebugDLL;
	else
		CLTool.RuntimeLibrary = rtSingleThreadedDebug;

	var strDefines = "WIN32;_DEBUG";

	strDefines += ";_CONSOLE";
	if (bMFC)
		strDefines += ";_AFXDLL";

	CLTool.PreprocessorDefinitions = strDefines;
	if (bEmptyProject)
		CLTool.UsePrecompiledHeader = pchNone;

	var LinkTool = config.Tools("VCLinkerTool");
	LinkTool.ProgramDatabaseFile = "$(outdir)/" + strProjectName + ".pdb";
	LinkTool.GenerateDebugInformation = true;
	LinkTool.LinkIncremental = linkIncrementalYes;
	LinkTool.SubSystem = subSystemConsole;
	LinkTool.OutputFile = "$(outdir)/" + strProjectName + ".exe";

	config = proj.Object.Configurations.Item("Release|Win32");
	config.CharacterSet = charSetMBCS;

	var CLTool = config.Tools("VCCLCompilerTool");
	if (bEmptyProject)
	{
		CLTool.UsePrecompiledHeader = pchGenerateAuto;
	}


	if (bMFC)
		CLTool.RuntimeLibrary = rtMultiThreadedDLL;
	else
		CLTool.RuntimeLibrary = rtSingleThreaded;

	CLTool.InlineFunctionExpansion = expandOnlyInline;

	var strDefines = "WIN32;NDEBUG;_MBCS";
	if (bEmptyProject)
		CLTool.UsePrecompiledHeader = pchNone;

	strDefines += ";_CONSOLE";
	if (bMFC)
		strDefines += ";_AFXDLL";

	CLTool.PreprocessorDefinitions = strDefines;

	var LinkTool = config.Tools("VCLinkerTool");
	LinkTool.GenerateDebugInformation = true;
	LinkTool.LinkIncremental = linkIncrementalNo;

	LinkTool.SubSystem = subSystemConsole;

	LinkTool.OutputFile = "$(outdir)/" + strProjectName + ".exe";
}

function SetFileProperties(projfile, strName)
{
	return false;
}

function DoOpenFile(strTarget)
{
	return false;
}