@echo off
@setlocal

set OUTFILE=run
set OUTTYPE=exe
REM *** dependencies
del %OUTFILE%.exe
del *.pdb

echo Building %OUTFILE%.%OUTTYPE%
csc /t:%OUTTYPE% /out:%OUTFILE%.%OUTTYPE% *.cs /r:System.Data.dll /r:System.dll /r:System.Xml.dll /debug
