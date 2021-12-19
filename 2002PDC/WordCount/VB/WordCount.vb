
' Add the classes in the following namespaces to our namespace
imports System
imports System.IO
imports System.Collections
imports CompWordCounter

Option Explicit
Option Strict Off

' ///////////////////////////////////////////////////////////////////////////////


Public Module modmain

   Sub Main()
        ' Parse the command-line arguments
        dim ap as New WordCountArgParser
        dim args as string()



        args = Environment.GetCommandLineArgs()

        if not ap.Parse() then 
            ' An error occurrend while parsing
            exit sub
        end if


        ' If an output file was specified on the command-line, use it
        dim fsOut as FileStream  = nothing
        dim sw as StreamWriter = nothing
        if ap.OutputFile <> "" then
            fsOut = new FileStream(ap.OutputFile, FileMode.Create, FileAccess.Write, FileShare.None)
            sw = new StreamWriter(fsOut)

            ' By associating the StreamWriter with the console, the rest of 
            ' the code can think it's writing to the console but the console 
            ' object redirects the output to the StreamWriter
            Console.SetOut(sw)
        end if

        ' Create a WordCounter object to keep running statistics
        dim wc as New WordCounter

        ' Write the table header
        Console.WriteLine("Lines  Words  Chars  Bytes  Pathname")

        ' Iterate over the user-specified files
        dim e as IEnumerator = ap.GetPathnameEnumerator()
        while (e.MoveNext())
            dim NumLines, NumWords, NumChars, NumBytes as Int64
            ' Calculate the words stats for this file
            wc.CountStats(e.Current, NumLines, NumWords, NumChars, NumBytes)

            ' Display the results
            dim StrArgs(5) as String
            StrArgs(0) = NumLines.ToString()
            StrArgs(1) = NumWords.ToString() 
            StrArgs(2) = NumChars.ToString() 
            StrArgs(3) = NumBytes.ToString() 
            StrArgs(4) = e.Current 
            
            Console.WriteLine(System.String.Format("{0,5}  {1,5}  {2,5}  {3,5}  {4,5}", StrArgs))
        End While


        ' Done processing all files, show the totals
        Console.WriteLine("-----  -----  -----  -----  ---------------------")
        Console.WriteLine(System.String.Format("{0,5}  {1,5}  {2,5}  {3,5}  Total in all files", wc.TotalLines, wc.TotalWords, wc.TotalChars, wc.TotalBytes))

        ' If the user wants to see the word usage alphabetically, show it
        if ap.ShowAlphabeticalWordUsage then
            dim de as IDictionaryEnumerator = wc.GetWordsAlphabeticallyEnumerator()
            Console.WriteLine(System.String.Format("Word usage sorted alphabetically ({0} unique words)", wc.UniqueWords))
            while de.MoveNext()
                Console.WriteLine(System.String.Format("{0,5}: {1}", de.Value, de.Key))
            End While
        end if

        ' If the user wants to see the word usage by occurrance, show it
        if ap.ShowOccurranceWordUsage then
            dim de as IDictionaryEnumerator = wc.GetWordsByOccurranceEnumerator()
            Console.WriteLine(System.String.Format("Word usage sorted by occurrance ({0} unique words)", wc.UniqueWords))
            while de.MoveNext()
                Console.WriteLine(System.String.Format("{0,5}: {1}", de.Key.Occurrances, de.Key.Word))
            End While
        End If

        ' Explicitly close the console to guarantee that the StreamWriter object (sw) is flushed
        Console.Out.Close()
        if not (fsOut = nothing) then fsOut.Close()    

   End Sub

End Module


'///////////////////////////////// End of File /////////////////////////////////
