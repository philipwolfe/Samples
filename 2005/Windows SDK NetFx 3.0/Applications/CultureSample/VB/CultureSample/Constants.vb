 '-----------------------------------------------------------------------
'  This file is part of the Microsoft .nET SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AnD InFORMATIOn ARE PROVIDED AS IS WITHOUT WARRAnTY OF AnY
'KInD, EITHER EXPRESSED OR IMPLIED, InCLUDInG BUT nOT LIMITED TO THE
'IMPLIED WARRAnTIES OF MERCHAnTABILITY AnD/OR FITnESS FOR A
'PARTICULAR PURPOSE.
'-----------------------------------------------------------------------
Imports System
Imports System.Collections


'/ <summary>
'/ Constants required for the application.
'/ </summary>

NotInheritable Class Constants
    
    Private Sub New() 
    
    End Sub 'New
    
    Public Const LongNumber As Int64 = 123456789
    Public Const CharHyphen As Char = "-"c
    Public Const Hyphen As String = "-"
    Public Const Comma As String = ","
    Public Const Space As String = " "
    Public Const Dot As String = "."
    Public Const Slash As String = "/"
    Public Const SemiColon As String = ";"
    Public Const NumberFormat As String = "n"
    Public Const CurrencyFormat As String = "C"
    Public Const ShortDateFormat As String = "d"
    Public Const LongDateFormat As String = "D"
    Public Const TimeFormat As String = "T"
    Public Const Dollar As String = "$"
    Public Const Minus As String = "-"
    Public Const SampleNumber As String = "1.1"
    
    Public Shared PositiveFormat As String() =  {"{0}{1}", "{1}{0}", "{0} {1}", "{1} {0}"}
    
    Public Shared NegativeFormat As String() =  {"({0}{1})", "-{0}{1}", "{0}-{1}", "{0}{1}-", "({1}{0})", "-{1}{0}", "{1}-{0}", "{1}{0}-", "-{1} {0}", "-{0} {1}", "{1} {0}-", "{0} {1}-", "{0} -{1}", "{1}- {0}", "({0} {1})", "({1} {0})"}
    
    Public Shared NumberGroupFormats As Object() =  {"123456789", "123,456,789", "12,34,56,789"}
    Public Shared ShortDateFormats As Object() =  {"M/d/yyyy", "M/d/yy", "MM/dd/yy", "MM/dd/yyyy"}
    Public Shared TimeFormats As Object() =  {"h:mm:ss tt", "hh:mm:ss tt", "H:mm:ss", "HH:mm:ss"}
    Public Shared LongDateFormats As Object() =  {"dddd, MMMM dd, yyyy", "MMMM dd, yyyy", "dddd, dd MMMM, yyyy", "dd MMMM, yyyy"}
    
    Public Const SuccessMessage As String = "Registered."
    Public Const ErrorNeutralCulture As String = "Neutral cultures cannot be parsed."
    Public Const ErrorFileFound As String = """.nlp"" file already exists."
    Public Const ErrorInvalidName As String = "Invalid name."
    
    
    '*
'		 * Reusing the PositiveFormat strings for both currency and number
'		 * Replaces the characters and returns the string format
'		 
    Public Shared Function GetNumberFormat(ByVal positive As Boolean, ByVal currencySymbol As String, ByVal type As String) As String() 
        Dim str As String() = Nothing
        
        'Retrieve from positive or negative list
        str = IIf(positive = True, PositiveFormat, NegativeFormat) 'TODO: For performance reasons this should be changed to nested IF statements
        Dim stringList(str.Length - 1) As String
        Dim i As Integer
        
        While i < str.Length
            'Temp string for replacement for retaining the original string 
            stringList(i) = String.Format(str(i), currencySymbol, type)
            i += 1
        End While
        Return stringList
    
    End Function 'GetNumberFormat 
End Class 'Constants