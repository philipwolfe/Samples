How to install the XSL Wizard:
1) Copy the file "XSL Wizard.vsz" into the Project Items directory. For example, for VB this would be the "VBProjectItems" of the install directory
2) Create a hidden folder named "Templates" under the above mentioned ptoject items directory, and copy the files xsltemplate.xsl and xmltemplate.xml into it. 
3) Open the copied "XSL Wizard.vsz" file in notepad or another editor. Change the string "E:\vsbuilt\Retail\Bin\i386\VBProjectItems\Templates" to the path of copied Templates folder.
4) Build and/or regsvr32 the DLL
5) Create a project, select Add Items, and select "XSL Wizard"

NOTE: Currently, the DTE object model does not do search/replace. When the files are created. you will need to open the generated .xml file, and change %FILENAME% the the filename of the added item.