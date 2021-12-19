This directory contains unsupported tools to be used with the Visual Studio Object model.

The following items are currently available:
	ExtBrws.dll - This dll is an Add-in that will work in VS 7.0 or VBA 7.0. To use it, regsvr32 the dll, then load it from the VS or VBA 
			Add-in Manager dialog. Click the item on the Tools menu to bring up a dialog that displays all the late bound objects
			available under DTE, DTE.Events, or DTE.Properties.

	Object Model Chart.gif - This is a preliminary graphic showing a chart of the object model layout.

	GenerateIcoData.exe - This is a program that will generate data that can be entered into the registry settings for an Add-in that
			displays Help About information. When generating the registry keys for Help About information, an icon is needed for
			display. Data that can be used can be in the form of:
				C:\filePath\FileName.dll,resid
				C:\FilePath\Filename.ico
				Raw binary data in the registry
			To generate the binary data for the regisry, you would create a binary value, and copy the hex information into this value.
			This tool generates this information.