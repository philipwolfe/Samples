@echo on
csc /W:0 /incr /debug  /r:mscorlib.dll /r:System.DLL /r:System.Drawing.DLL /r:System.Windows.Forms.DLL  /linkres:scribble.resx /out:Scribble.exe *.cs
f:\tests\bin\touch scribble.cs

csc /W:0  /incr /debug /time  /r:mscorlib.dll /r:System.DLL /r:System.Drawing.DLL /r:System.Windows.Forms.DLL  /linkres:scribble.resx /out:Scribble.exe *.cs