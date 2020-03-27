@echo off
REM -- First make map file from Microsoft Visual C++ generated resource.h
echo // MAKEHELP.BAT generated Help Map file.  Used by TraceTool.HPJ. >"hlp\TraceTool.hm"
echo. >>"hlp\TraceTool.hm"
echo // Commands (ID_* and IDM_*) >>"hlp\TraceTool.hm"
makehm ID_,HID_,0x10000 IDM_,HIDM_,0x10000 resource.h >>"hlp\TraceTool.hm"
echo. >>"hlp\TraceTool.hm"
echo // Prompts (IDP_*) >>"hlp\TraceTool.hm"
makehm IDP_,HIDP_,0x30000 resource.h >>"hlp\TraceTool.hm"
echo. >>"hlp\TraceTool.hm"
echo // Resources (IDR_*) >>"hlp\TraceTool.hm"
makehm IDR_,HIDR_,0x20000 resource.h >>"hlp\TraceTool.hm"
echo. >>"hlp\TraceTool.hm"
echo // Dialogs (IDD_*) >>"hlp\TraceTool.hm"
makehm IDD_,HIDD_,0x20000 resource.h >>"hlp\TraceTool.hm"
echo. >>"hlp\TraceTool.hm"
echo // Frame Controls (IDW_*) >>"hlp\TraceTool.hm"
makehm IDW_,HIDW_,0x50000 resource.h >>"hlp\TraceTool.hm"
REM -- Make help for Project TraceTool


echo Building Win32 Help files
start /wait hcw /C /E /M "hlp\TraceTool.hpj"
echo.
if exist Debug\nul if exist hlp\TraceTool.hlp copy "hlp\TraceTool.hlp" Debug\AtlTraceTool.hlp
if exist Debug\nul if exist hlp\TraceTool.cnt copy "hlp\TraceTool.cnt" Debug\AtlTraceTool.cnt
if exist Release\nul if exist hlp\TraceTool.hlp copy "hlp\TraceTool.hlp" Release\AtlTraceTool.hlp
if exist Release\nul if exist hlp\TraceTool.cnt copy "hlp\TraceTool.cnt" Release\AtlTraceTool.cnt
goto :done

:Error
echo hlp\TraceTool.hpj(1) : error: Problem encountered creating help file

:done
echo.
