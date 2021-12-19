Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form
    Private strSampleScope As String
    Public Sub New()
        MyBase.New
        strSamplescope = "Form Level"
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
    Private WithEvents btnLoadImpClass As System.Windows.Forms.Button
    Private WithEvents btnLoadNum As System.Windows.Forms.Button
    Private WithEvents btnLoadWithText As System.Windows.Forms.Button
    Private WithEvents btnLoad As System.Windows.Forms.Button
    Private WithEvents btnConstr_Destr As System.Windows.Forms.Button
    Private WithEvents txtProp1 As System.Windows.Forms.TextBox
    Private WithEvents txtProp2 As System.Windows.Forms.TextBox
    Private WithEvents btnSwap As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox




    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox









    Private WithEvents btnScope As System.Windows.Forms.Button



    Private WithEvents btnWinInherit As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtProp1 = New System.Windows.Forms.TextBox()
        Me.btnLoadImpClass = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnConstr_Destr = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnScope = New System.Windows.Forms.Button()
        Me.btnWinInherit = New System.Windows.Forms.Button()
        Me.btnLoadWithText = New System.Windows.Forms.Button()
        Me.btnSwap = New System.Windows.Forms.Button()
        Me.txtProp2 = New System.Windows.Forms.TextBox()
        Me.btnLoadNum = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        GroupBox1.Location = New System.Drawing.Point(8, 40)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        GroupBox1.Text = "New Class Features"
        GroupBox1.Size = New System.Drawing.Size(472, 184)

        txtProp1.Location = New System.Drawing.Point(8, 64)
        txtProp1.TabIndex = 3
        txtProp1.Size = New System.Drawing.Size(88, 20)

        btnLoadImpClass.Location = New System.Drawing.Point(16, 120)
        btnLoadImpClass.Size = New System.Drawing.Size(152, 24)
        btnLoadImpClass.TabIndex = 9
        btnLoadImpClass.Text = "Load Implementation Class"

        GroupBox2.Location = New System.Drawing.Point(184, 16)
        GroupBox2.TabIndex = 4
        GroupBox2.TabStop = False
        GroupBox2.Text = "Swap Properties"
        GroupBox2.Size = New System.Drawing.Size(280, 96)

        btnConstr_Destr.Location = New System.Drawing.Point(16, 152)
        btnConstr_Destr.Size = New System.Drawing.Size(152, 24)
        btnConstr_Destr.TabIndex = 5
        btnConstr_Destr.Text = "Constructor/Destructor"

        Label1.Location = New System.Drawing.Point(8, 16)
        Label1.Text = "A change in VB 7 allows properties of class to be passed ByRef to a function and with the modifications of the values to be reflected back to the properties."
        Label1.Size = New System.Drawing.Size(264, 40)
        Label1.TabIndex = 0

        btnScope.Location = New System.Drawing.Point(144, 8)
        btnScope.Size = New System.Drawing.Size(120, 24)
        btnScope.TabIndex = 4
        btnScope.Text = "New Variable Scope Behaviors"

        btnWinInherit.Location = New System.Drawing.Point(16, 8)
        btnWinInherit.Size = New System.Drawing.Size(120, 24)
        btnWinInherit.TabIndex = 0
        btnWinInherit.Text = "Window Inheritance"

        btnLoadWithText.Location = New System.Drawing.Point(16, 56)
        btnLoadWithText.Size = New System.Drawing.Size(152, 24)
        btnLoadWithText.TabIndex = 7
        btnLoadWithText.Text = "Load With Text"

        btnSwap.Location = New System.Drawing.Point(200, 64)
        btnSwap.Size = New System.Drawing.Size(72, 24)
        btnSwap.TabIndex = 1
        btnSwap.Text = "Swap"

        txtProp2.Location = New System.Drawing.Point(104, 64)
        txtProp2.TabIndex = 2
        txtProp2.Size = New System.Drawing.Size(88, 20)

        btnLoadNum.Location = New System.Drawing.Point(16, 88)
        btnLoadNum.Size = New System.Drawing.Size(152, 24)
        btnLoadNum.TabIndex = 8
        btnLoadNum.Text = "Load With a Numeric Value"

        btnLoad.Location = New System.Drawing.Point(16, 24)
        btnLoad.Size = New System.Drawing.Size(152, 24)
        btnLoad.TabIndex = 6
        btnLoad.Text = "Load Class"
        Me.Text = "New Language Features"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 229)

        GroupBox1.Controls.Add(btnLoadImpClass)
        GroupBox1.Controls.Add(btnLoadNum)
        GroupBox1.Controls.Add(btnLoadWithText)
        GroupBox1.Controls.Add(btnLoad)
        GroupBox1.Controls.Add(btnConstr_Destr)
        GroupBox1.Controls.Add(GroupBox2)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(btnSwap)
        GroupBox2.Controls.Add(txtProp2)
        GroupBox2.Controls.Add(txtProp1)
        Me.Controls.Add(GroupBox1)
        Me.Controls.Add(btnScope)
        Me.Controls.Add(btnWinInherit)
    End Sub

#End Region

    Protected Sub btnSwap_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSwap.Click
        Dim objSample As SampleClass
        objSample = New SampleClass()
        objSample.MyProp = txtProp1.Text
        objSample.MyProp1 = txtProp2.Text
        Swap(objSample.MyProp, objSample.MyProp1)
        txtProp1.Text = objSample.MyProp
        txtProp2.Text = objSample.MyProp1
    End Sub

    Protected Sub Swap(ByRef strValue1 As String, ByRef strValue2 As String)
        Dim strTmp As String
        strTmp = strValue1
        strValue1 = strValue2
        strValue2 = strTmp
    End Sub

    Protected Sub btnConstr_Destr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConstr_Destr.Click
        Dim objSample As SampleConstrDestr
        'Calls the constructor
        objSample = New SampleConstrDestr()
        'Call destructor when the object goes out of scope 
        'and garbage collection is done
        'Not Implemented in Beta1
    End Sub



    Protected Sub btnLoadImpClass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadImpClass.Click
        Dim objSample1 As SampleInterface.IFirst
        Dim objSample2 As SampleInterface.ISecond
        objSample1 = New SampleImplementClass()
        MessageBox.Show(objSample1.Foo)
        MessageBox.Show(objSample1.Foo1)
        'Must explictily case an object from one interface
        'to a different object with a different interface
        objSample2 = CType(objSample1, SampleInterface.ISecond)
        MessageBox.Show(objSample2.Foo)
        MessageBox.Show(objSample2.Foo2)

    End Sub



    Protected Sub btnLoadNum_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadNum.Click
        Dim objSample As SampleDerivedClass
        Dim lngValue As Long
        Dim strValue As String
        Try
            strValue = InputBox("Enter a value to load the class.", "Class Load")
            'All datatypes are now objects that contain various method and properties
            'some of the method are to convert the variable to another datatype.
            lngValue = Convert.ToInt64(strValue)
            'Overloaded constructer loaded with a long
            objSample = New SampleDerivedClass(lngValue)
            MessageBox.Show(objSample.GetValue)

        Catch
            'Overloaded constructor loaded with a string
            objSample = New SampleDerivedClass(strValue)
            MessageBox.Show(objSample.GetValue)

        End Try
    End Sub



    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim objSample As SampleClass
        objSample = New SampleClass()
        MessageBox.Show(objSample.GetValue)
    End Sub

    Protected Sub btnLoadWithText_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadWithText.Click
        Dim strInput As String
        Dim objSample As SampleClass
        strInput = InputBox("Enter a value to load the class.", "Class Load")

        objSample = New SampleClass(strInput)
        MessageBox.Show(objSample.GetValue)
    End Sub
    Protected Sub btnScope_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnScope.Click
        CheckScope()
    End Sub



    Private Sub CheckScope()
        Dim i As Integer
        'strSampleScope is defined at the class level
        MessageBox.Show(strSampleScope)
        If True Then
            Dim strSampleScope As String
            'The If block defines a new version of strSampleScope
            'that is valid until the end if
            strSampleScope = "If Block Level"
            'Block Level
            MessageBox.Show(strSampleScope)
        End If
        'Class Level
        MessageBox.Show(strSampleScope)
        For i = 0 To 1
            Dim strSampleScope As String
            'The For block defines a new version of strSampleScope
            'that is valid until the For loop has completed.
            'strSampleScope does not get redefined in each iteration
            'of the loop.
            strSampleScope = strSampleScope & "For Block Level " & i.ToString & " "
            'Block Level
            MessageBox.Show(strSampleScope)
        Next
        'Class Level
        MessageBox.Show(strSampleScope)
    End Sub





    Protected Sub btnWinInherit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWinInherit.Click
        Dim frmBase As Sample_Base_Form = New Sample_Base_Form()
        frmBase.ShowDialog()

    End Sub


End Class
