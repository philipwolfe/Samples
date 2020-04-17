'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'-----------------------------------------------------------------------
Namespace Microsoft.Samples
    Friend Class FormMain
        Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer
        Friend WithEvents labelFirstName As System.Windows.Forms.Label
        Friend WithEvents textFirstName As System.Windows.Forms.TextBox
        Friend WithEvents labelLastName As System.Windows.Forms.Label
        Friend WithEvents textLastName As System.Windows.Forms.TextBox
        Friend WithEvents numericChildren As System.Windows.Forms.NumericUpDown
        Friend WithEvents labelStreet1 As System.Windows.Forms.Label
        Friend WithEvents labelStreet2 As System.Windows.Forms.Label
        Friend WithEvents labelCity As System.Windows.Forms.Label
        Friend WithEvents labelChildren As System.Windows.Forms.Label
        Friend WithEvents labelMaritalStatus As System.Windows.Forms.Label
        Friend WithEvents comboMaritalStatus As System.Windows.Forms.ComboBox
        Friend WithEvents buttonBirthDate As System.Windows.Forms.Button
        Friend WithEvents textBirthDate As System.Windows.Forms.TextBox
        Friend WithEvents textStreet1 As System.Windows.Forms.TextBox
        Friend WithEvents textStreet2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
        Friend WithEvents comboState As System.Windows.Forms.ComboBox
        Friend WithEvents groupAddress As System.Windows.Forms.GroupBox
        Friend WithEvents groupPersonal As System.Windows.Forms.GroupBox
        Friend WithEvents labelState As System.Windows.Forms.Label
        Friend WithEvents labelDOB As System.Windows.Forms.Label
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
            Me.groupAddress = New System.Windows.Forms.GroupBox
            Me.comboState = New System.Windows.Forms.ComboBox
            Me.labelState = New System.Windows.Forms.Label
            Me.TextBox3 = New System.Windows.Forms.TextBox
            Me.TextBox2 = New System.Windows.Forms.TextBox
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.labelCity = New System.Windows.Forms.Label
            Me.labelStreet2 = New System.Windows.Forms.Label
            Me.labelStreet1 = New System.Windows.Forms.Label
            Me.groupPersonal = New System.Windows.Forms.GroupBox
            Me.textBirthDate = New System.Windows.Forms.TextBox
            Me.buttonBirthDate = New System.Windows.Forms.Button
            Me.labelDOB = New System.Windows.Forms.Label
            Me.comboMaritalStatus = New System.Windows.Forms.ComboBox
            Me.labelMaritalStatus = New System.Windows.Forms.Label
            Me.labelChildren = New System.Windows.Forms.Label
            Me.numericChildren = New System.Windows.Forms.NumericUpDown
            Me.labelLastName = New System.Windows.Forms.Label
            Me.textLastName = New System.Windows.Forms.TextBox
            Me.textFirstName = New System.Windows.Forms.TextBox
            Me.labelFirstName = New System.Windows.Forms.Label
            Me.groupAddress.SuspendLayout()
            Me.groupPersonal.SuspendLayout()
            CType(Me.numericChildren, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'groupAddress
            '
            resources.ApplyResources(Me.groupAddress, "groupAddress")
            Me.groupAddress.Controls.Add(Me.comboState)
            Me.groupAddress.Controls.Add(Me.labelState)
            Me.groupAddress.Controls.Add(Me.TextBox3)
            Me.groupAddress.Controls.Add(Me.TextBox2)
            Me.groupAddress.Controls.Add(Me.TextBox1)
            Me.groupAddress.Controls.Add(Me.labelCity)
            Me.groupAddress.Controls.Add(Me.labelStreet2)
            Me.groupAddress.Controls.Add(Me.labelStreet1)
            Me.groupAddress.Font = Nothing
            Me.groupAddress.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.groupAddress.Name = "groupAddress"
            Me.groupAddress.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            Me.groupAddress.TabStop = False
            '
            'comboState
            '
            resources.ApplyResources(Me.comboState, "comboState")
            Me.comboState.Font = Nothing
            Me.comboState.FormattingEnabled = True
            Me.comboState.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.comboState.Name = "comboState"
            Me.comboState.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelState
            '
            resources.ApplyResources(Me.labelState, "labelState")
            Me.labelState.Font = Nothing
            Me.labelState.Name = "labelState"
            Me.labelState.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'TextBox3
            '
            resources.ApplyResources(Me.TextBox3, "TextBox3")
            Me.TextBox3.Font = Nothing
            Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'TextBox2
            '
            resources.ApplyResources(Me.TextBox2, "TextBox2")
            Me.TextBox2.Font = Nothing
            Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'TextBox1
            '
            resources.ApplyResources(Me.TextBox1, "TextBox1")
            Me.TextBox1.Font = Nothing
            Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelCity
            '
            resources.ApplyResources(Me.labelCity, "labelCity")
            Me.labelCity.Font = Nothing
            Me.labelCity.Name = "labelCity"
            Me.labelCity.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelStreet2
            '
            resources.ApplyResources(Me.labelStreet2, "labelStreet2")
            Me.labelStreet2.Font = Nothing
            Me.labelStreet2.Name = "labelStreet2"
            Me.labelStreet2.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelStreet1
            '
            resources.ApplyResources(Me.labelStreet1, "labelStreet1")
            Me.labelStreet1.Font = Nothing
            Me.labelStreet1.Name = "labelStreet1"
            Me.labelStreet1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'groupPersonal
            '
            resources.ApplyResources(Me.groupPersonal, "groupPersonal")
            Me.groupPersonal.Controls.Add(Me.textBirthDate)
            Me.groupPersonal.Controls.Add(Me.buttonBirthDate)
            Me.groupPersonal.Controls.Add(Me.labelDOB)
            Me.groupPersonal.Controls.Add(Me.comboMaritalStatus)
            Me.groupPersonal.Controls.Add(Me.labelMaritalStatus)
            Me.groupPersonal.Controls.Add(Me.labelChildren)
            Me.groupPersonal.Controls.Add(Me.numericChildren)
            Me.groupPersonal.Controls.Add(Me.labelLastName)
            Me.groupPersonal.Controls.Add(Me.textLastName)
            Me.groupPersonal.Controls.Add(Me.textFirstName)
            Me.groupPersonal.Controls.Add(Me.labelFirstName)
            Me.groupPersonal.Font = Nothing
            Me.groupPersonal.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.groupPersonal.Name = "groupPersonal"
            Me.groupPersonal.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            Me.groupPersonal.TabStop = False
            '
            'textBirthDate
            '
            resources.ApplyResources(Me.textBirthDate, "textBirthDate")
            Me.textBirthDate.Font = Nothing
            Me.textBirthDate.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.textBirthDate.Name = "textBirthDate"
            Me.textBirthDate.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'buttonBirthDate
            '
            resources.ApplyResources(Me.buttonBirthDate, "buttonBirthDate")
            Me.buttonBirthDate.Font = Nothing
            Me.buttonBirthDate.Name = "buttonBirthDate"
            Me.buttonBirthDate.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelDOB
            '
            resources.ApplyResources(Me.labelDOB, "labelDOB")
            Me.labelDOB.Font = Nothing
            Me.labelDOB.Name = "labelDOB"
            Me.labelDOB.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'comboMaritalStatus
            '
            resources.ApplyResources(Me.comboMaritalStatus, "comboMaritalStatus")
            Me.comboMaritalStatus.Font = Nothing
            Me.comboMaritalStatus.FormattingEnabled = True
            Me.comboMaritalStatus.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.comboMaritalStatus.Name = "comboMaritalStatus"
            Me.comboMaritalStatus.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelMaritalStatus
            '
            resources.ApplyResources(Me.labelMaritalStatus, "labelMaritalStatus")
            Me.labelMaritalStatus.Font = Nothing
            Me.labelMaritalStatus.Name = "labelMaritalStatus"
            Me.labelMaritalStatus.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelChildren
            '
            resources.ApplyResources(Me.labelChildren, "labelChildren")
            Me.labelChildren.Font = Nothing
            Me.labelChildren.Name = "labelChildren"
            Me.labelChildren.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'numericChildren
            '
            resources.ApplyResources(Me.numericChildren, "numericChildren")
            Me.numericChildren.Font = Nothing
            Me.numericChildren.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.numericChildren.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
            Me.numericChildren.Name = "numericChildren"
            Me.numericChildren.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelLastName
            '
            resources.ApplyResources(Me.labelLastName, "labelLastName")
            Me.labelLastName.Font = Nothing
            Me.labelLastName.Name = "labelLastName"
            Me.labelLastName.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'textLastName
            '
            resources.ApplyResources(Me.textLastName, "textLastName")
            Me.textLastName.Font = Nothing
            Me.textLastName.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.textLastName.Name = "textLastName"
            Me.textLastName.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'textFirstName
            '
            resources.ApplyResources(Me.textFirstName, "textFirstName")
            Me.textFirstName.Font = Nothing
            Me.textFirstName.ImeMode = System.Windows.Forms.ImeMode.Inherit
            Me.textFirstName.Name = "textFirstName"
            Me.textFirstName.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'labelFirstName
            '
            resources.ApplyResources(Me.labelFirstName, "labelFirstName")
            Me.labelFirstName.Font = Nothing
            Me.labelFirstName.Name = "labelFirstName"
            Me.labelFirstName.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            '
            'FormMain
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.groupPersonal)
            Me.Controls.Add(Me.groupAddress)
            Me.Icon = Nothing
            Me.Name = "FormMain"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
            Me.groupAddress.ResumeLayout(False)
            Me.groupAddress.PerformLayout()
            Me.groupPersonal.ResumeLayout(False)
            Me.groupPersonal.PerformLayout()
            CType(Me.numericChildren, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
        ' With strongly typed resources, we don't need this line ...
        'Private resMgr As System.Resources.ResourceManager

        Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' use ResGen to create the strings.vb file:
            ' Resgen /str:vb strings.txt

            ' With storngly typed resources, we don't need this line ...
            ' resMgr = New System.Resources.ResourceManager(GetType(FormMain))

            ' these are the problem strings: 
            ' Notice mis-spellings, and bad references
            ' Me.Text = resMgr.GetString("CustomerFormTile")
            ' groupPersonal.Text = resMgr.GetString("CustomerFormpersonal")
            ' labelChildren.Text = resMgr.GetString("CustomerFormKids")
            ' labelDOB.Text = resMgr.GetString("CustomerFirmDOB")

            ' because of the strong-typing, if we refer to the wrong field,
            ' we'll get compile-time support
            Me.Text = strings.CustomerFormTitle
            groupPersonal.Text = strings.CustomerFormPersonal
            labelChildren.Text = strings.CustomerFormChildren
            labelDOB.Text = strings.CustomerFormDOB
            labelFirstName.Text = strings.CustomerFormFirstName
            labelCity.Text = strings.CustomerFormCity
            labelState.Text = strings.CustomerFormState
            labelStreet1.Text = strings.CustomerFormStreet1
            labelStreet2.Text = strings.CustomerFormStreet2
            groupAddress.Text = strings.CustomerFormAddress
            labelLastName.Text = strings.CustomerFormLastName
            labelMaritalStatus.Text = strings.CustomerFormMaritalStatus

        End Sub
    End Class
End Namespace