del WordCounter.dll
del WordCount.exe

csc /t:library /out:WordCount.dll WordCount.cs ArgParser.cs
vbc /t:exe /out:WordCount.exe Wordcount.vb WordCountArgParser.vb /reference:WordCount.dll
