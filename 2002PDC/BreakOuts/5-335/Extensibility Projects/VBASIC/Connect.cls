Attribute Version = "7.0"
Attribute MyClass
    ModuleType = Class
    Access = [Friend]
    CreationAccess = [Friend]
End Attribute

Option Explicit

Implements IDTExtensibility2
//BEGIN VSCommand
//BEGIN Add Tools Menu
Implements IDTCommandTarget

Sub Exec(ByVal CmdName As String, ByVal ExecuteOption As EnvDTE.EnvDTE.vsCommandExecOption, ByVal VariantIn As Variant, VariantOut As Variant, handled As Boolean) Implements EnvDTE.EnvDTE.IDTCommandTarget.Exec
    If CmdName = "$SAFEOBJNAME$.Connect.Command" Then
        MsgBox "Click"
        handled = True
    End If
End Sub
 
Sub QueryStatus(ByVal CmdName As String, ByVal NeededText As EnvDTE.EnvDTE.vsCommandStatusTextWanted, StatusOption As EnvDTE.EnvDTE.vsCommandStatus, CommandText As Variant) Implements EnvDTE.EnvDTE.IDTCommandTarget.QueryStatus
    If CmdName = "$SAFEOBJNAME$.Connect.Command" Then
        StatusOption = vsCommandStatusEnabled + vsCommandStatusSupported
    Else
        StatusOption = vsCommandStatusUnsupported
    End If
End Sub

//END Add Tools Menu
 Dim g_Application As DTE.DTE
//END VSCommand
//BEGIN NOT VSCommand
 Dim g_Application As Object
//END NOT VSCommand


Sub OnAddInsUpdate(custom(*) As Variant) Implements EnvDTE.EnvDTE.IDTExtensibility2.OnAddInsUpdate

End Sub

Sub OnBeginShutdown(custom(*) As Variant) Implements EnvDTE.EnvDTE.IDTExtensibility2.OnBeginShutdown

End Sub

Sub OnConnection(ByVal Application As Object, ByVal ConnectMode As EnvDTE.EnvDTE.ext_Connectmode, ByVal Addininst As Object, custom(*) As Variant) Implements EnvDTE.EnvDTE.IDTExtensibility2.OnConnection
    On Error GoTo Error_OnConnection
    Set g_Application = Application
//BEGIN VSCommand
//BEGIN Add Tools Menu
    If ConnectMode = ext_cm_UISetup Then
        Dim CommandObj As Command
        Dim ContextGuids()
            Set CommandObj = g_Application.Commands.AddNamedCommand(AddInInst, "Command", "My Add-in", "Executes command for My Add-in", True, 59, ContextGuids, 0)
            CommandObj.AddControl g_Application.CommandBars("MenuBar").Controls("Tools").CommandBar
        Exit Sub
    End If
//END Add Tools Menu
//END VSCommand
    Exit Sub
Error_OnConnection:
    MsgBox "Error: " + Err.Description
End Sub

Sub OnDisconnection(ByVal RemoveMode As EnvDTE.EnvDTE.ext_Disconnectmode, custom(*) As Variant) Implements EnvDTE.EnvDTE.IDTExtensibility2.OnDisconnection

End Sub

Sub OnStartupComplete(custom(*) As Variant) Implements EnvDTE.EnvDTE.IDTExtensibility2.OnStartupComplete

End Sub