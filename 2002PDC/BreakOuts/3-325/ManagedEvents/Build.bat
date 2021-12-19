
csc /debug /target:library /out:EventSrc.dll .\EventSource\EventSrc.cs

Regasm EventSrc.dll /tlb:EventSrc.tlb

