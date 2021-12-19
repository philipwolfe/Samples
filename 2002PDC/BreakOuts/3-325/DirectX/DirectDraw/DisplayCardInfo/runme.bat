tlbimp dx7vb.dll /out:DxVBLib.dll

csc /out:DisplayCardInfo.exe DisplayCardInfo.cs /r:DxVBLib.dll

DisplayCardInfo.exe