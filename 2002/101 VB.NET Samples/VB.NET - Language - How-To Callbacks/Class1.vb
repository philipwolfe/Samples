'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
Option Strict On

Delegate Sub Delegate1()

Friend Class Class1

    'This field holds an interface reference for calling back to the client
    Private icb As ICallback

    'This field holds a delegate reference for calling back into the client
    Private del1 As Delegate1

    Public Sub RegisterInterFaceForCallback(ByVal cb As ICallback)
        'this method receives a reference to the client.

        'Register the client for the callback
        icb = cb

    End Sub

    Public Sub UnRegisterInterfaceForCallback()

        'Unregister the client 
        icb = Nothing

    End Sub

    Public Sub UseInterfaceCallback()
        'This method uses the registered client ref to call back 
        'into the client

        'Make sure something is registered first
        If Not icb Is Nothing Then
            'Call back into the client code
            icb.CallbackMethod()
        End If

    End Sub

    Public Sub RegisterDelegateForCallback(ByVal d As Delegate1)
        'this method receives a reference to the client.

        'Register the client for the callback
        del1 = d
    End Sub

    Public Sub UnRegisterDelegateForCallback()

        'Unregister the client 
        del1 = Nothing

    End Sub

    Public Sub UseDelegateCallback()
        'This method uses the registered client ref to call back 
        'into the client

        'Make sure something is registered first
        If Not del1 Is Nothing Then
            'Call back into the client code
            del1.Invoke()
        End If

    End Sub

    Public Sub UseAsyncDelegateCallback()
        'This method uses the registered client ref to call back 
        'into the client asynchronously.

        'Make sure something is registered first
        If Not del1 Is Nothing Then
            'Call back into the client code asynchronously
            'The arguments can be ignored in this usage.
            del1.BeginInvoke(Nothing, Nothing)
        End If

    End Sub

    Public Sub UseBuiltInDelegateCallback()
        'This method doesn't need a registered client. The callback is part
        'of the delegate infrastructure, and happens independently of this 
        'implementation. Note that this method isn't even aware that there
        'is a callback occurring with the delegate that makes the call.

        'With the AsyncCallback delegate, registration/unregistration is needed.
        'The callback just happens based on the client's including it in the
        'parameter list.
    End Sub

End Class
