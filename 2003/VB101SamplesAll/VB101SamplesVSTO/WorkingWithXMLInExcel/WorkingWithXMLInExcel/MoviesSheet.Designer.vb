'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.26
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



'''
<Microsoft.VisualStudio.Tools.Applications.Runtime.StartupObjectAttribute(1),  _
 System.Runtime.InteropServices.ComVisibleAttribute(false),  _
 System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>  _
Partial Public NotInheritable Class MoviesSheet
    Inherits Microsoft.Office.Tools.Excel.Worksheet
    Implements Microsoft.VisualStudio.Tools.Applications.Runtime.IStartup
    
    Friend WithEvents MoviesListObject As Microsoft.Office.Tools.Excel.ListObject
    
    <Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private RuntimeCallback As Microsoft.VisualStudio.Tools.Applications.Runtime.IRuntimeServiceProvider
    
    <Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private HostItemHost As Microsoft.VisualStudio.Tools.Applications.Runtime.IHostItemProvider
    
    <Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private DataHost As Microsoft.VisualStudio.Tools.Applications.Runtime.ICachedDataProvider
    
    Friend WithEvents MoviesBindingSource As System.Windows.Forms.BindingSource
    
    Private components As System.ComponentModel.IContainer
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Public Sub New(ByVal RuntimeCallback As Microsoft.VisualStudio.Tools.Applications.Runtime.IRuntimeServiceProvider)
        MyBase.New(CType(RuntimeCallback.GetService(GetType(Microsoft.VisualStudio.Tools.Applications.Runtime.IHostItemProvider)),Microsoft.VisualStudio.Tools.Applications.Runtime.IHostItemProvider), RuntimeCallback, "Sheet1", Nothing, "Sheet1")
        Me.RuntimeCallback = RuntimeCallback
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Public Sub Initialize() Implements Microsoft.VisualStudio.Tools.Applications.Runtime.IStartup.Initialize
        Me.HostItemHost = CType(Me.RuntimeCallback.GetService(GetType(Microsoft.VisualStudio.Tools.Applications.Runtime.IHostItemProvider)),Microsoft.VisualStudio.Tools.Applications.Runtime.IHostItemProvider)
        Me.DataHost = CType(Me.RuntimeCallback.GetService(GetType(Microsoft.VisualStudio.Tools.Applications.Runtime.ICachedDataProvider)),Microsoft.VisualStudio.Tools.Applications.Runtime.ICachedDataProvider)
        Globals.MoviesSheet = Me
        System.Windows.Forms.Application.EnableVisualStyles
        Me.InitializeCachedData
        Me.InitializeControls
        Me.InitializeComponents
        Me.InitializeData
        Me.BeginInitialization
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Public Sub FinishInitialization() Implements Microsoft.VisualStudio.Tools.Applications.Runtime.IStartup.FinishInitialization
        Me.OnStartup
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Public Sub InitializeDataBindings() Implements Microsoft.VisualStudio.Tools.Applications.Runtime.IStartup.InitializeDataBindings
        Me.BindToData
        Me.EndInitialization
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Public Overrides Sub OnShutdown() Implements Microsoft.VisualStudio.Tools.Applications.Runtime.IStartup.OnShutdown
        Me.MoviesListObject.Dispose
        MyBase.OnShutdown
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private Sub InitializeCachedData()
        If (Me.DataHost Is Nothing) Then
            Return
        End If
        If Me.DataHost.IsCacheInitialized Then
            Me.DataHost.FillCachedData(Me)
        End If
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private Sub InitializeData()
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private Sub BindToData()
        Me.MoviesListObject.SetDataBinding(Me.MoviesBindingSource, "", "Rating", "RunningTime", "Name", "ShowTimes")
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Private Sub StartCaching(ByVal MemberName As String)
        Me.DataHost.StartCaching(Me, MemberName)
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Private Sub StopCaching(ByVal MemberName As String)
        Me.DataHost.StopCaching(Me, MemberName)
    End Sub
    
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Private Function IsCached(ByVal MemberName As String) As Boolean
        Return Me.DataHost.IsCached(Me, MemberName)
    End Function
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private Sub BeginInitialization()
        Me.BeginInit
        Me.MoviesListObject.BeginInit
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private Sub EndInitialization()
        Me.MoviesListObject.EndInit
        Me.EndInit
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private Sub InitializeControls()
        Me.MoviesListObject = New Microsoft.Office.Tools.Excel.ListObject(Me.HostItemHost, Me.RuntimeCallback, "Sheet1:MoviesListObject", Me, "MoviesListObject")
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private Sub InitializeComponents()
        Me.components = New System.ComponentModel.Container
        Me.MoviesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MoviesListObject,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MoviesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        '
        'MoviesListObject
        '
        Me.MoviesListObject.DataBoundFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatColor1
        '
        'MoviesBindingSource
        '
        Me.MoviesBindingSource.DataSource = GetType(WorkingWithXMLInExcel.IgnyteTheaterMovieService.Movie)
        '
        'MoviesSheet
        '
        CType(Me.MoviesListObject,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MoviesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
    End Sub
    
    '''
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
    Private Function NeedsFill(ByVal MemberName As String) As Boolean
        Return Me.DataHost.NeedsFill(Me, MemberName)
    End Function
End Class

Partial Friend NotInheritable Class Globals
    
    Private Shared _MoviesSheet As MoviesSheet
    
    Friend Shared Property MoviesSheet() As MoviesSheet
        Get
            Return _MoviesSheet
        End Get
        Set
            If (_MoviesSheet Is Nothing) Then
                _MoviesSheet = value
            Else
                Throw New System.NotSupportedException
            End If
        End Set
    End Property
End Class
