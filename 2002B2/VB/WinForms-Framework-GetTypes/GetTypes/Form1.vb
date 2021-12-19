Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.Reflection


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents txtTypes As System.Windows.Forms.TextBox
    Private WithEvents btnGetTypes As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtTypes = New System.Windows.Forms.TextBox()
        Me.btnGetTypes = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        txtTypes.Location = New System.Drawing.Point(8, 40)
        txtTypes.Multiline = True
        txtTypes.AcceptsReturn = True
        txtTypes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        txtTypes.TabIndex = 1
        txtTypes.AcceptsTab = True
        txtTypes.Size = New System.Drawing.Size(584, 480)

        btnGetTypes.Location = New System.Drawing.Point(8, 8)
        btnGetTypes.Size = New System.Drawing.Size(75, 23)
        btnGetTypes.TabIndex = 0
        btnGetTypes.Text = "Get Types"

        Me.Text = "Get Types"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(608, 549)

        Me.Controls.Add(txtTypes)
        Me.Controls.Add(btnGetTypes)
    End Sub

#End Region

    Protected Sub btnGetTypes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetTypes.Click
        Dim s As String
        Dim o As Object

        'List all the types from the mscorlib assembly.

        'Get the mscorlib assembly, it's the one Object is defined in
        Dim a As Reflection.Assembly = GetType(Object).Module.Assembly

        'Get all the types in this assembly
        Dim Types() As Type = a.GetTypes()

        'let's take a look at them, and gather a little bit of data as we do it.
        Dim numValueTypes As Integer = 0
        Dim numInterfaces As Integer = 0
        s = s & "Get all the types from the assembly: " & a.GetName().ToString() & Chr(13) & Chr(10)
        For Each o In types
            Dim t As Type = CType(o, Type)
            s = s & t.FullName & Chr(13) & Chr(10)
            If (t.IsInterface) Then
                numInterfaces += 1
            End If
            If (t.IsValueType) Then
                numValueTypes += 1
            End If
        Next
        s = s & "Out of " & types.Length & " types, " & numInterfaces & " are interfaces and " & numValueTypes & " are value types" & Chr(13) & Chr(10)

        'Load an assembly from disk, just so happens it's THIS assembly
        Dim b As Reflection.Assembly = Reflection.Assembly.LoadFrom("gettypes.exe")
        Dim types2() As Type = b.GetTypes()
        For Each o In types2
            Dim t As Type = CType(o, Type)
            s = s & t.FullName & Chr(13) & Chr(10)
        Next

        txtTypes.Text = s
    End Sub

End Class
