' Copyright (c) Microsoft Corporation.  All Rights Reserved.

' Create a service proxy using the service moniker.
' This references the address, the binding type and the COM visible contract ID
Set calcProxy = GetObject("service:address=http://localhost/ServiceModelSamples/service.svc, binding=wsHttpBinding, contract={9213C6D2-5A6F-3D26-839B-3BA9B82228D3}") 

' Call the service operations on the proxy
WScript.Echo "100 + 15.99 = " & calcProxy.Add(100, 15.99)
WScript.Echo "145 - 76.54 = " & calcProxy.Subtract(145, 76.54)
WScript.Echo "9 * 81.25 = " & calcProxy.Multiply(9, 81.25)
WScript.Echo "22 / 7 = " & calcProxy.Divide(22, 7)

