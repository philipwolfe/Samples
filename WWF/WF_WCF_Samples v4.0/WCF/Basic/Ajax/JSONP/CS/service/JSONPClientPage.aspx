<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>JSONP Service Client Page</title>

    <script type="text/javascript">
    // <![CDATA[
    
    function JsonPCallBack(result){
    document.getElementById("name").value = result.Name;
    document.getElementById("address").value = result.Address;
    }

    function jsonp(url)
    {                 
        var script = document.createElement("script");        
        script.setAttribute("src",url);
        script.setAttribute("type","text/javascript");                
        document.body.appendChild(script);
    }
    // ]]>
    </script>

</head>
<body>
    <h1>
        JSONP Service Client Page</h1>
        Customer:
        <p/>
        Name: <input type="text" id="name"/>
        <p/>
        Address: <input type="text" id="address"/>
        <script type="text/javascript" defer="defer">jsonp('http://localhost:33695/CustomerService/GetCustomer?callback=JsonPCallBack');</script>
</body>
</html>
