Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Imports Microsoft.Samples.WinForms.VB.SimpleBinding.Data

Namespace Microsoft.Samples.WinForms.VB.SimpleBinding 

    Public Class SimpleBinding
        Inherits System.WinForms.Form

        'Required by the Windows Forms Designer   
        Private components As System.ComponentModel.Container
        Private labelTitle As System.WinForms.Label
        Private buttonMovePrev As System.WinForms.Button
        Private textBoxLastName As System.WinForms.TextBox
        Private textBoxPosition As System.WinForms.TextBox
        Private labelDOB As System.WinForms.Label
        Private labelFirstName As System.WinForms.Label
        Private textBoxTitle As System.WinForms.TextBox
        Private dateTimeFormat1 As System.WinForms.ComponentModel.DateTimeFormat
        Private buttonMoveNext As System.WinForms.Button
        Private textBoxID As System.WinForms.TextBox
        Private buttonMoveFirst As System.WinForms.Button
        Private labelID As System.WinForms.Label
        Private labelAddress As System.WinForms.Label
        Private buttonMoveLast As System.WinForms.Button
        Private textBoxFirstName As System.WinForms.TextBox
        Private textBoxDOB As System.WinForms.TextBox
        Private panelVCRControl As System.WinForms.Panel
        Private labelLastName As System.WinForms.Label
        Private textBoxAddress As System.WinForms.TextBox
        
	    Private custList() As Customer
    
        Public Sub New()
           MyBase.New
    
           'This call is required by the Windows Forms Designer.
           InitializeComponent
    
           ' TODO: Add any constructor code after InitializeComponent call

            ' Get the list of customers as an array
            custList = CustomerList.GetCustomersArray()

            ' Set up the bindings so that each field on the form is
            ' bound to a property of Customer
            textBoxID.Bindings.Add("Text", custList, "ID")
            textBoxTitle.Bindings.Add("Text", custList, "Title")
            textBoxLastName.Bindings.Add("Text", custList, "LastName")
            textBoxFirstName.Bindings.Add("Text", custList, "FirstName")
            textBoxDOB.Bindings.Add("Value", custList, "DateOfBirth")
            textBoxAddress.Bindings.Add("Text", custList, "Address")

            ' We want to handle position changing events for the DATA VCR Panel
            ' Position is managed by the Form's BindingManager so hook the position changed
            ' event on the BindingManager
            AddHandler Me.BindingManager(custList).PositionChanged, new System.EventHandler(AddressOf customers_PositionChanged)
            
            ' Set up the initial text for the DATA VCR Panel
            textBoxPosition.Text = "Record " + (Me.BindingManager(custList).Position + 1).ToString() + " of " + custList.Length.ToString()
            
            ' Set the minimum form size to the client size + the height of the title bar
            Me.MinTrackSize = new Size(368, (413 + SystemInformation.CaptionHeight))

        End Sub

        ' When the MoveFirst button is clicked set the position for the CustomersList
        ' to the first record
        private Sub buttonMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
            Me.BindingManager(custList).Position = 0 
        End Sub


        ' When the MoveLast button is clicked set the position for the CustomersList 
        ' to the last record
        private Sub buttonMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
            Me.BindingManager(custList).Position = custList.Length - 1
        End Sub


        ' When the MoveNext button is clicked increment the position for the CustomersList
        private Sub buttonMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
            If Me.BindingManager(custList).Position < custList.Length - 1 Then 
                Me.BindingManager(custList).Position = Me.BindingManager(custList).Position + 1
            End if
        End Sub


        ' When the MovePrev button is clicked decrement the position for the CustomersList
        private Sub buttonMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
            if Me.BindingManager(custList).Position > 0 Then 
                Me.BindingManager(custList).Position -=	1
            End If
        End Sub


        ' Position has changed - update the DATA VCR panel
        private Sub customers_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) 
            textBoxPosition.Text = "Record " + (Me.BindingManager(custList).Position + 1).ToString() + " of " + custList.Length.ToString()
        End Sub


        'Clean up any resources being used
        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub 

        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New SimpleBinding())
        End Sub

        'NOTE: The following procedure is required by the Windows Forms Designer
        'Do not modify it.
        Private Sub InitializeComponent() 
            Me.components = New System.ComponentModel.Container
            Me.textBoxTitle = New System.WinForms.TextBox
            Me.labelFirstName = New System.WinForms.Label
            Me.dateTimeFormat1 = New System.WinForms.ComponentModel.DateTimeFormat
            Me.buttonMoveNext = New System.WinForms.Button
            Me.buttonMovePrev = New System.WinForms.Button
            Me.labelTitle = New System.WinForms.Label
            Me.textBoxLastName = New System.WinForms.TextBox
            Me.labelDOB = New System.WinForms.Label
            Me.textBoxPosition = New System.WinForms.TextBox
            Me.textBoxID = New System.WinForms.TextBox
            Me.textBoxFirstName = New System.WinForms.TextBox
            Me.textBoxDOB = New System.WinForms.TextBox
            Me.textBoxAddress = New System.WinForms.TextBox
            Me.panelVCRControl = New System.WinForms.Panel
            Me.buttonMoveFirst = New System.WinForms.Button
            Me.labelLastName = New System.WinForms.Label
            Me.labelID = New System.WinForms.Label
            Me.buttonMoveLast = New System.WinForms.Button
            Me.labelAddress = New System.WinForms.Label

            textBoxTitle.Location = New System.Drawing.Point(88, 70)
            textBoxTitle.Text = ""
            textBoxTitle.TabIndex = 1
            textBoxTitle.Size = New System.Drawing.Size(70, 20)

            labelFirstName.Location = New System.Drawing.Point(8, 112)
            labelFirstName.Text = "&First Name:"
            labelFirstName.Size = New System.Drawing.Size(64, 16)
            labelFirstName.TabIndex = 7

            dateTimeFormat1.DisplayFormat = "D"
            '@design dateTimeFormat1.SetLocation(New System.Drawing.Point(7, 7))

            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.Text = "Customer Details"
            '@design Me.TrayLargeIcon = True
            '@design Me.TrayHeight = 93
            Me.ClientSize = New System.Drawing.Size(368, 413)

            buttonMoveNext.Location = New System.Drawing.Point(184, 8)
            buttonMoveNext.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonMoveNext.Size = New System.Drawing.Size(32, 32)
            buttonMoveNext.TabIndex = 11
            buttonMoveNext.Anchor = System.WinForms.AnchorStyles.Top
            buttonMoveNext.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
            buttonMoveNext.Text = ">"
            AddHandler buttonMoveNext.Click, New System.EventHandler(AddressOf Me.buttonMoveNext_Click)

            buttonMovePrev.Location = New System.Drawing.Point(48, 8)
            buttonMovePrev.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonMovePrev.Size = New System.Drawing.Size(32, 32)
            buttonMovePrev.TabIndex = 12
            buttonMovePrev.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
            buttonMovePrev.Text = "<"
            AddHandler buttonMovePrev.Click, New System.EventHandler(AddressOf Me.buttonMovePrev_Click)

            labelTitle.Location = New System.Drawing.Point(8, 72)
            labelTitle.Text = "&Title:"
            labelTitle.Size = New System.Drawing.Size(64, 16)
            labelTitle.TabIndex = 6

            textBoxLastName.Location = New System.Drawing.Point(88, 152)
            textBoxLastName.Text = ""
            textBoxLastName.Anchor = System.WinForms.AnchorStyles.TopLeftRight
            textBoxLastName.TabIndex = 3
            textBoxLastName.Size = New System.Drawing.Size(243, 20)

            labelDOB.Location = New System.Drawing.Point(8, 194)
            labelDOB.Text = "&Date of Birth:"
            labelDOB.Size = New System.Drawing.Size(72, 16)
            labelDOB.TabIndex = 16

            textBoxPosition.Location = New System.Drawing.Point(88, 14)
            textBoxPosition.Text = ""
            textBoxPosition.Anchor = System.WinForms.AnchorStyles.Left
            textBoxPosition.BorderStyle = System.WinForms.BorderStyle.FixedSingle
            textBoxPosition.ReadOnly = True
            textBoxPosition.TabIndex = 14
            textBoxPosition.Size = New System.Drawing.Size(88, 20)

            textBoxID.Location = New System.Drawing.Point(88, 30)
            textBoxID.Text = ""
            textBoxID.ReadOnly = True
            textBoxID.TabIndex = 0
            textBoxID.Size = New System.Drawing.Size(203, 20)

            textBoxFirstName.Location = New System.Drawing.Point(88, 112)
            textBoxFirstName.Text = ""
            textBoxFirstName.Anchor = System.WinForms.AnchorStyles.TopLeftRight
            textBoxFirstName.TabIndex = 2
            textBoxFirstName.Size = New System.Drawing.Size(243, 20)

            textBoxDOB.Location = New System.Drawing.Point(88, 192)
            textBoxDOB.Anchor = System.WinForms.AnchorStyles.TopLeftRight
            textBoxDOB.Format = dateTimeFormat1
            textBoxDOB.TabIndex = 17
            textBoxDOB.Size = New System.Drawing.Size(243, 20)

            textBoxAddress.Location = New System.Drawing.Point(88, 232)
            textBoxAddress.Text = ""
            textBoxAddress.Anchor = System.WinForms.AnchorStyles.All
            textBoxAddress.Multiline = True
            textBoxAddress.AcceptsReturn = True
            textBoxAddress.TabIndex = 4
            textBoxAddress.Size = New System.Drawing.Size(264, 88)

            panelVCRControl.BorderStyle = System.WinForms.BorderStyle.FixedSingle
            panelVCRControl.Location = New System.Drawing.Point(88, 344)
            panelVCRControl.Size = New System.Drawing.Size(264, 48)
            panelVCRControl.TabIndex = 15
            panelVCRControl.Anchor = System.WinForms.AnchorStyles.Bottom
            panelVCRControl.Text = "panel1"

            buttonMoveFirst.Location = New System.Drawing.Point(8, 8)
            buttonMoveFirst.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonMoveFirst.Size = New System.Drawing.Size(32, 32)
            buttonMoveFirst.TabIndex = 13
            buttonMoveFirst.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
            buttonMoveFirst.Text = "|<"
            AddHandler buttonMoveFirst.Click, New System.EventHandler(AddressOf Me.buttonMoveFirst_Click)

            labelLastName.Location = New System.Drawing.Point(8, 154)
            labelLastName.Text = "&Last Name:"
            labelLastName.Size = New System.Drawing.Size(64, 16)
            labelLastName.TabIndex = 8

            labelID.Location = New System.Drawing.Point(8, 32)
            labelID.Text = "ID:"
            labelID.Size = New System.Drawing.Size(64, 16)
            labelID.TabIndex = 5

            buttonMoveLast.Location = New System.Drawing.Point(224, 8)
            buttonMoveLast.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonMoveLast.Size = New System.Drawing.Size(32, 32)
            buttonMoveLast.TabIndex = 10
            buttonMoveLast.Anchor = System.WinForms.AnchorStyles.Top
            buttonMoveLast.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
            buttonMoveLast.Text = ">|"
            AddHandler buttonMoveLast.Click, New System.EventHandler(AddressOf Me.buttonMoveLast_Click)

            labelAddress.Location = New System.Drawing.Point(8, 232)
            labelAddress.Text = "&Address:"
            labelAddress.Size = New System.Drawing.Size(64, 16)
            labelAddress.TabIndex = 9

            panelVCRControl.Controls.Add(textBoxPosition)
            panelVCRControl.Controls.Add(buttonMoveFirst)
            panelVCRControl.Controls.Add(buttonMovePrev)
            panelVCRControl.Controls.Add(buttonMoveNext)
            panelVCRControl.Controls.Add(buttonMoveLast)
            Me.Controls.Add(textBoxAddress)
            Me.Controls.Add(labelLastName)
            Me.Controls.Add(panelVCRControl)
            Me.Controls.Add(textBoxDOB)
            Me.Controls.Add(textBoxFirstName)
            Me.Controls.Add(labelAddress)
            Me.Controls.Add(labelID)
            Me.Controls.Add(textBoxID)
            Me.Controls.Add(textBoxTitle)
            Me.Controls.Add(labelFirstName)
            Me.Controls.Add(labelDOB)
            Me.Controls.Add(textBoxLastName)
            Me.Controls.Add(labelTitle)

        End Sub

    End Class

End Namespace

