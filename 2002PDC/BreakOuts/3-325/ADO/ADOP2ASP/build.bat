regasm %LOCATEDLL%\System.Data.dll /tlb:System.Data.tlb
copy System.Data.tlb c:\inetpub\wwwroot\*.*
copy ADOP2asp.asp c:\inetpub\wwwroot\*.*

net stop iisadmin /y && net start w3svc


start /w "%ProgramFiles%/Internet Explorer/IEXPLORE.EXE" Http://localhost/ADOP2asp.asp