set PATH=%PATH%;%windir%\microsoft.net\framework64\v4.0.21019;%windir%\microsoft.net\framework\v4.0.21019;%WINDIR%\Microsoft.NET\Framework64\v4.0.21019;%WINDIR%\Microsoft.NET\Framework\v2.0.50727;%PROGRAMFILES%\Microsoft SDKs\Windows\v7.0A\bin
gacutil /nologo /i Client.dll
regasm /nologo /tlb:Client.tlb Client.dll