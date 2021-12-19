rem The following line shall be excuted only once to generate the user signature
rem sn -k Sample.key

csc /debug /t:library ExcelServer.cs /a.keyfile:Sample.key
al /i:ExcelServer.dll
del ExcelServer.tlb
regasm ExcelServer.dll /tlb:ExcelServer.tlb
