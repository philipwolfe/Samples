'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version:1.2.30610.0
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.IO
Imports System.Resources


'This class was auto-generated by the Strongly Typed Resource Builder
'class via a tool like ResGen or Visual Studio.NET.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
NotInheritable Class strings
    
    Private Shared _resMgr As System.Resources.ResourceManager
    
    Public Shared ReadOnly Property ResourceManager As System.Resources.ResourceManager
        Get
            If (_resMgr Is Nothing) Then
                Dim temp As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(strings))
                System.Threading.Thread.MemoryBarrier
                _resMgr = temp
            End If
            Return _resMgr
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormAddress As String
        Get
            Return ResourceManager.GetString("CustomerFormAddress")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormChildren As String
        Get
            Return ResourceManager.GetString("CustomerFormChildren")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormCity As String
        Get
            Return ResourceManager.GetString("CustomerFormCity")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormDOB As String
        Get
            Return ResourceManager.GetString("CustomerFormDOB")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormFirstName As String
        Get
            Return ResourceManager.GetString("CustomerFormFirstName")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormLastName As String
        Get
            Return ResourceManager.GetString("CustomerFormLastName")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormMaritalStatus As String
        Get
            Return ResourceManager.GetString("CustomerFormMaritalStatus")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormPersonal As String
        Get
            Return ResourceManager.GetString("CustomerFormPersonal")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormState As String
        Get
            Return ResourceManager.GetString("CustomerFormState")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormStreet1 As String
        Get
            Return ResourceManager.GetString("CustomerFormStreet1")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormStreet2 As String
        Get
            Return ResourceManager.GetString("CustomerFormStreet2")
        End Get
    End Property
    
    Public Shared ReadOnly Property CustomerFormTitle As String
        Get
            Return ResourceManager.GetString("CustomerFormTitle")
        End Get
    End Property
    
    Public Shared ReadOnly Property FlagLarge As System.Drawing.Bitmap
        Get
            Return CType(ResourceManager.GetObject("FlagLarge"),System.Drawing.Bitmap)
        End Get
    End Property
    
    Public Shared ReadOnly Property FlagSmall As System.Drawing.Bitmap
        Get
            Return CType(ResourceManager.GetObject("FlagSmall"),System.Drawing.Bitmap)
        End Get
    End Property
    
    Public Shared ReadOnly Property MainFlag As System.Drawing.Bitmap
        Get
            Return CType(ResourceManager.GetObject("MainFlag"),System.Drawing.Bitmap)
        End Get
    End Property
End Class
