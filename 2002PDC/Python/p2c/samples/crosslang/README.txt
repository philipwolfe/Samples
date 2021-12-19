This is an adaptation of the standard NGWS CrossLang sample

Before you try and run this sample, you must:
* Ensure that the Python compiler and runtime has been built, and works
   correctly.  Ensure the standard test suite completes.
   
* Locate and build the standard NGWS "CrossLang" sample.

* Copy *.dll and *.mod from that directory into this directory.

* Run 'nmake'

After building, open Table.htm in IE 5.5.  The "Power Generator" button
will execute the Python code.

There will also be a MakeTable_py.exe.  This is similar to the code executed 
by Table.htm, except it is written in Python, and dumps the output
(HTML tags and all!) to the console.

-- eof --