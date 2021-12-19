/*=====================================================================
  File:      WordCount.cs

  Summary:   Demonstrates how to create a WordCount application
             using various COM+ 2.0 library types.

---------------------------------------------------------------------
  This file is part of the Microsoft COM+ 2.0 SDK Code Samples.

  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

// Add the classes in the following namespaces to our namespace
using System;
using System.IO;
using System.Collections;

namespace CompWordCounter{

///////////////////////////////////////////////////////////////////////////////


// The WordCounter class
public class WordCounter {
    public WordCounter() { /* No interesting construction */ }

    // Each object of this class keeps a running total of the files its processed
    // The following members hold this running information
    Int64 totalLines = 0; 
    Int64 totalWords = 0;
    Int64 totalChars = 0;
    Int64 totalBytes = 0;

    // The set of all words seen (sorted alphabetically)
    SortedList wordCounter = new SortedList();

    // The following methods return the running-total info
    public Int64 TotalLines { get { return totalLines; } }
    public Int64 TotalWords { get { return totalWords; } }
    public Int64 TotalChars { get { return totalChars; } }
    public Int64 TotalBytes { get { return totalBytes; } }

    // This method calculates the statistics for a single file.
    // This file's info is returned via the out parameters
    // The running total of all files is maintained in the data members
    public Boolean CountStats(String pathname, 
        out Int64 numLines, out Int64 numWords, out Int64 numChars, out Int64 numBytes) {

        Boolean Ok = true;  // Assume success
        numLines = numWords = numChars = numBytes = 0;  // Initialize out params to zero
        try {
            // Attempt to open the input file for read-only access
            FileStream fsIn = new FileStream(pathname, FileMode.Open, FileAccess.Read, FileShare.Read);
            numBytes = fsIn.Length;
            StreamReader sr = new StreamReader(fsIn);

            // Process every line in the file
            for (String Line = sr.ReadLine(); Line != null; Line = sr.ReadLine()) {
                numLines++;
                numChars += Line.Length;
                String[] Words = Line.Split(null);  // Split the line into words
                numWords += Words.Length;
                for (int Word = 0; Word < Words.Length; Word++) {
                    if (Words[Word] != null) {
                        if (!wordCounter.ContainsKey(Words[Word])) {
                            // If we've never seen this word before, add it to the sorted list with a count of 1
                            wordCounter.Add(Words[Word], 1);
                        } else {
                            // If we have seen this word before, just increment its count
                            wordCounter[Words[Word]] = (Int32) wordCounter[Words[Word]] + 1;
                        }
                    }
                }
            }
            // Explicitly close the StreamReader to properly flush all buffers
            sr.Close(); // This also closes the FileStream (fsIn)
        }
        catch (FileNotFoundException) {
            // The specified input file could not be opened
            Ok = false;
        }
        // Increment the running totals with whatever was discovered about this file
        totalLines += numLines;
        totalWords += numWords;
        totalChars += numChars;
        totalBytes += numBytes;
        return(Ok);
    }

    // Returns an enumerator for the words (sorted alphabetically)
    public IDictionaryEnumerator GetWordsAlphabeticallyEnumerator() {
        return (IDictionaryEnumerator) wordCounter.GetEnumerator();
    }


    // This nested class is only used to sort the words by occurrance
    // An instance of this class is created for each word
    public class WordOccurrance : IComparable {

        // Members indicating the number of times this word occurred and the word itself
        private int occurrances;
        private String word;

        // Constructor
        public WordOccurrance(int occurrances, String word) {
            this.occurrances = occurrances;
            this.word = word;
        }

        // Sorts two WordOccurrance objects by occurrance first, then by word
        public int CompareTo(Object o) {
            // Compare the occurance of the two objects
            int n = occurrances - ((WordOccurrance)o).occurrances;
            if (n == 0) {
                // Both objects have the same ccurrance, sort alphabetically by word
                n = String.Compare(word, ((WordOccurrance)o).word);
            }
            return(n);
        }

        // Return the occurrance value of this word
        public int Occurrances { get { return occurrances; } }

        // Return this word
        public String Word { get { return word; } }
    }


    // Returns an enumerator for the words (sorted by occurrance)
    public IDictionaryEnumerator GetWordsByOccurranceEnumerator() {
        // To create a list of words sorted by occurrance, we need another SortedList object
        SortedList sl = new SortedList();

        // Now, we'll iterate through the words alphabetically
        IDictionaryEnumerator de = GetWordsAlphabeticallyEnumerator();
        while (de.MoveNext()) {

            // For each word, we create a new WordOccurrance object which
            // contains the word and its occurrance value.
            // The WordOccurrance class contains a CompareTo method which knows
            // to sort WordOccurrance objects by occurrance value and then alphabetically by the word itself.
            sl.Add(new WordOccurrance((int)de.Value, (string)de.Key), null);
        }
        // Return an enumerator for the words (sorted by occurrance)
        return (IDictionaryEnumerator) sl.GetEnumerator();        
    }

    // Returns the number of unique words processed
    public int UniqueWords {
        get { return wordCounter.Count; }
    }
}


///////////////////////////////////////////////////////////////////////////////


}

///////////////////////////////// End of File /////////////////////////////////
