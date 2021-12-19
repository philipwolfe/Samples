This sample illustrates the user of Assembly store in IsolatedStorage.

User name is persisted in a file. This file is created in the Isolated 
Store of the assembly UserName.exe. A public static method 'GetUserName'
is provided by UserName.exe, which can be used by other applications to
get the user name. The same data file is used even if different applications
call 'GetUserName'.

Compile the applications by executing mk.bat. Make sure that the C Sharp
compiler (csc.exe) is in your path. 

Execute 
    UserName.exe 
    UserName.exe
    UserName.exe

    UserName.exe 'remembers' the user name. 

Execute
    UserName.exe /Reset.

    Erase the user name from file.

Execute 
    UserName.exe 
    HelloUser.exe. 

    HelloUser.exe gets the user name that the user supplied to UserName.exe. 

Execute 
    UserName.exe /Reset 
    HelloUser.exe 
    UserName.exe

    The user name is stored during execution of UserName.exe and is reused 
    by HelloUser.exe.

 
mk.bat
    Uses the C Sharp compiler to create 
    UserName.exe from UserName.cs
    HelloUser.exe from HelloUser.cs

UserName.cs ==> UserName.exe

    Provides an API 'GetUserName' which prompts the user for name the first
time the API is called. This information is then persisted in a file in the
Isolated Store of GetUser.exe.

HelloUser.cs ==> HelloUser.exe

    Uses 'UserName.GetUserName' to obtain the user name.

