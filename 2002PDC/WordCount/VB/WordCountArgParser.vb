
' Add the classes in the following namespaces to our namespace
imports System
imports System.IO
imports System.Collections
imports CompArgParser

Option Explicit
Option Strict Off

public class WordCountArgParser
inherits ArgParser

    ' Members identifying command-line argument settings
    private vshowAlphabeticalWordUsage as Boolean 
    private vshowOccurranceWordUsage as Boolean 
    private voutputFile as String  
    private pathnames as new ArrayList

    ' Give the set of valid command-line switches to the base class

    private s() as string = {"?", "o", "a", "f"}

    sub New()
        MyBase.New ()
    end sub


    ' Returns the name of the user-specified output file or null if not specified
    ReadOnly Property OutputFile() as String
        Get
            OutputFile = voutputFile
        End Get
    end Property

    ' Indicates whether the user wanted to see all the words sorted alphabetically
    ReadOnly Property ShowAlphabeticalWordUsage() as Boolean 
        get
            ShowAlphabeticalWordUsage = vshowAlphabeticalWordUsage
        end get
    end property


    ' Indicates whether the user wanted to see all the words sorted by occurrance
    ReadOnly Property ShowOccurranceWordUsage() as Boolean
        get
            showOccurranceWordUsage = vshowOccurranceWordUsage
        end get
    end property


    ' Shows application's usage info and also reports command-line argument errors.
    overrides public sub OnUsage(errorInfo as String)
        if errorInfo <> "" Then 
            ' An command-line argument error occurred, report it to user
            ' errInfo identifies the argument that is in error.
            Console.WriteLine("Command-line switch error: {0}", errorInfo)
        end if

	    Console.WriteLine("Usage: WordCount [-a] [-o] [-f<output-pathname>] input-pathname...")
	    Console.WriteLine("   -?  Show this usage information")
	    Console.WriteLine("   -a  Word usage sorted alphabetically")
	    Console.WriteLine("   -o  Word usage sorted by occurrance")
	    Console.WriteLine("   -f  Send output to specified pathname instead of the console")
    end sub


    ' Called for each non-switch command-line argument (filespecs)
    overrides public function OnNonSwitch(switchValue as String) as ArgParser.SwitchStatus  ' protected (?) overrides (?)
        dim ss as SwitchStatus = SwitchStatus.NoError
        ' Add command-line argument to array of pathnames.
        dim d as String = File.GetDirectoryNameFromPath(switchValue)


        dim ddd As String
        if d.Length = 0 then
	    ddd = "."
        else
            ddd = d
        end if
        dim dir as new System.IO.Directory(ddd)

        ' Convert switchValue to set of pathnames, add each pathname to the pathnames ArrayList.
        dim f as object ' System.IO.File (?)
        for each f in dir.GetFiles(System.IO.File.GetFileNameFromPath(switchValue)) 
            pathnames.Add(f.FullName)
        next

        OnNonSwitch = ss
    end function


    ' Returns an enumerator that includes all the user-desired files.
    public function GetPathnameEnumerator() as IEnumerator
        GetPathnameEnumerator = pathnames.GetEnumerator(0, pathnames.Count)
    end function


    ' Called for each switch command-line argument
    overrides function OnSwitch(switchSymbol as string, switchValue as string) as ArgParser.SwitchStatus ' protected (?)
        ' NOTE: For case-insensitive switches, 
        '       switchSymbol will contain all lower-case characters

        dim ss as SwitchStatus = SwitchStatus.NoError
        select case (switchSymbol)

        case "?":   ' User wants to see Usage
            ss = SwitchStatus.ShowUsage

        case "a":   ' User wants to see all words sorted alphabetically
            vshowAlphabeticalWordUsage = true

        case "o":   ' User wants to see all words sorted by occurrance
            vshowOccurranceWordUsage = true

        case "f":   ' User wants output redirected to a specified file
            if switchValue.Length < 1 then
                Console.WriteLine("No output file specified.")
                ss = SwitchStatus.Error
            else
                voutputFile = switchValue
            end if

        case else
    	    Console.WriteLine("Invalid switch: " & switchSymbol & ".")
            ss = SwitchStatus.Error
        end select


        OnSwitch = ss
    End Function


    ' Called when all command-line arguments have been parsed
    overrides function OnDoneParse() as ArgParser.SwitchStatus ' protected (?)
        dim ss as SwitchStatus = SwitchStatus.NoError
        ' Sort all the pathnames in the list
        if pathnames.Count = 0 then
            Console.WriteLine("No pathnames specified.")
            ss = SwitchStatus.Error
        else
            pathnames.Sort(0, pathnames.Count, nothing)
        end if 
        OnDoneParse = ss
    end function
end class

