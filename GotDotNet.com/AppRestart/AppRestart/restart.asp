<% 
    Sub Touch(FolderPath, FileName, NewDate)          
        Set app = Server.CreateObject("Shell.Application") 
        Set folder = app.NameSpace(FolderPath) 
        Set file = folder.ParseName(FileName)          
        file.ModifyDate = NewDate  
        set file = nothing 
        set folder = nothing 
        set app = nothing 
    End Sub  
    Call Touch(Server.MapPath("/"), "web.config", now) 
    Response.Write "Restarted..."      
%>
<html>
<body>
Put this page in your robots.txt file with "Disallow", or you will get bots restarting your app on you!
</body>
</html>