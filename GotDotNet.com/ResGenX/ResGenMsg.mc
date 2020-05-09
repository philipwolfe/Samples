
SeverityNames=(Success=0x0
               Informational=0x1
               Warning=0x2
               Error=0x3
              )

FacilityNames=(ResGenX=0x400)
LanguageNames=(English=en)

Messageid=1 Facility=ResGenX Severity=Success SymbolicName=Usage
Language=English
Usage:\tResGenX [/xref {{cs | vb}}] inFile.ext [outFile.ext]\n
\tResGenX [/compile] [/xref {{cs | vb\}}] inFile1.ext[,outFile1.resources] [...]\n\n
Where .ext is .resX, .txt, mc or .resources\n\n
Converts files from one resource format to another.  If the outFile\n
is not specified, inFile.resources will be used.\n\n
The /compile option takes a list of .resX, mc or .txt files to convert to\n
.resources files in one bulk operation, replacing .ext with .resources for\n
the output file name.\n\n
The /xref option specifies the type of cross reference file(s)\n
to create. Specify cs to create a CSharp style or vb for Visual Basic.\n
If the option is ommitted both styles are generated.
.

Messageid=1 Facility=ResGenX Severity=Error SymbolicName=InputFileError
Language=English
Input file does not exist or has in invalid extension: {0}
.

Messageid=10 Facility=ResGenX Severity=Error SymbolicName=InvalidExtension
Language=English
Output file has an invalid extension: {0}
.

Messageid=20 Facility=ResGenX Severity=Success SymbolicName=ProcessingComplete
Language=English
Read in {0} resources from `{1}'\n
Writting resource file... Done
.

Messageid=20 Facility=ResGenX Severity=Error SymbolicName=InvalidTxtStructure
Language=English
Invalid text file structure:\n{0}
.

Messageid=30 Facility=ResGenX Severity=Error SymbolicName=InvalidMCStructure
Language=English
Invalid MC file structute at (0)
.

Messageid=40 Facility=ResGenX Severity=Error SymbolicName=OutofRange
Language=English
Value out of range or invalid at {0} : (1}
.

Messageid=50 Facility=ResGenX Severity=Error SymbolicName=UndefinedElement
Language=English
Undefined {0} name at {1}: {2}
.

Messageid=60 Facility=ResGenX Severity=Error SymbolicName=SymbolAlreadyDefined
Language=English
Symbol already defined at {0}: {1}
.

Messageid=70 Facility=ResGenX Severity=Error SymbolicName=DuplicateMessageID
Language=English
Duplicate message ID: Severity:{0} Facility:{1} Message:{2}
.

Messageid=80 Facility=ResGenX Severity=Error SymbolicName=InvalidOption
Language=English
Invalid or unsupported option: {0}
.

Messageid=110 Facility=ResGenX Severity=Error SymbolicName=AddToResourceFailed
Language=English
Exception adding message to resource\n{0}
.
