tlbimp %SystemRoot%\System32\shdocvw.dll

csc /debug /target:exe /r:shdocvw.dll /out:Explorer.exe Explorer.cs



