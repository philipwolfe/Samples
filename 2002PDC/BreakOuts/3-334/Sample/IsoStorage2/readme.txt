This sample illustrates the user of Application store in IsolatedStorage.
 
MinMax.dll is an assembly that accepts integers and keeps track of the
Minimum and Maximum integer values. It does this by maintaining 2 files,
one for Minimum and the other for Maximum value. Files are created in
different stores depending on the application that uses MinMax.dll. This
is achieved by using the application Isolated Store.

Compile the applications by executing mk.bat. Make sure that the C Sharp
compiler (csc.exe) is in your path. 

Temperature.exe is an application that uses MinMax.dll to keep track of
the minimum and maximum temperatures, given a set of temperatures. This
application can be invoked multiple times and it will keep track of
minimum and maximum values across invocation of Temperature.exe.

Execute 
    Temperature.exe 45 30 50 25
    Temperature.exe 35 52 28 37
    Temperature.exe 48 31 22 42

    The results are preserved across invocation.

    Temperature.exe /Reset 

    To reset and start over again.

AccountBalance.exe uses MinMax to store the account balance for a users
checking account after each transaction.

Execute 
    AccountBalance.exe 45000 60000 7500 9000
    AccountBalance.exe 75000 25000 8500 15000
    AccountBalance.exe 24000 17500 5000 22000

    The results are preserved across invocation.

    AccountBalance.exe /Reset 

    To reset and start over again.

Execute
    Temperature.exe /Reset
    AccountBalance.exe /Reset
    Temperature.exe 20 32 31 18
    AccountBalance.exe 17000 5000 24000 14543

    Data of Temperature.exe does not corrupt that of AccountBalance.exe

mk.bat
    Uses the C Sharp compiler to create 
    MinMax.dll from MinMax.cs
    Temperature.exe from Temperature.cs
    AccountBalance.exe from AccountBalance.cs

MinMax.cs ==> MinMax.dll
    Creates 2 files, in the application Isolated Store. One file tracks
the running minimum value and the other keeps track of the running max
value. MinMax provides public APIs to add data, get min and max values.
It also provides a way to reset the data.


Temperature.cs ==> Temperature.exe

    Takes command line arguments for temperature values. Uses MinMax.dll
to store these values and prints the current min and max values. Provides
a command line option to reset history.

AccountBalance.cs ==> AccountBalance.exe

    Takes command line arguments for account balance values. Uses MinMax.dll
to store these values and prints the current min and max values. Provides
a command line option to reset history.

