VariantUse:  Demonstrates the use of variants.

This basic sample shows how to change existing data 
into a variant and how to change a variant into other 
types of data.  Many COM objects accept variants as 
function parameters.  The goal of this sample is to 
help you change standard C data types into variants.

This sample covers the use of currency, dates, 
SAFEARRAYS, multidimensional arrays, strings, chars, 
shorts, and longs.

Running the Sample:

Build VariantUse.exe and run it in the debugger.  Place 
breakpoints in the code dealing with the type of data 
you are trying to understand.  For example, if you want 
to see the use of variants with strings, place breakpoints 
in the OnString function.  Run the sample in the debugger 
and press the "Strings" button.  Pressing the buttons 
on the main dialog will have no apparent effect on the 
application unless there are breakpoints in the associated 
code.  Once a break point is reached, use the single step 
feature of the debugger to step through the code that 
transforms a data into an out of a variant.
