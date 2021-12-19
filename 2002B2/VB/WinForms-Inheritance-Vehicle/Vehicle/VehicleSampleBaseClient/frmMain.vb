Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports VehicleDemoBO.VehicleDemo

Public Class Form1
    
    Inherits System.Windows.Forms.Form
    
    
    Public Sub New()
        MyBase.New()
        
        Form1 = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        'Set the default vehicleType to Car
        Me.cboVehicleType.SelectedIndex = 0
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
    Private WithEvents lblComputedRange As System.Windows.Forms.Label
    Private WithEvents chxSailboat As System.Windows.Forms.CheckBox

    Private WithEvents lblVehicleType As System.Windows.Forms.Label
    Private WithEvents cmdComputeRange As System.Windows.Forms.Button


    Private WithEvents lblFuelCapacity As System.Windows.Forms.Label
    Private WithEvents lblMilesPerGallon As System.Windows.Forms.Label
    Private WithEvents txtFuelCapacity As System.Windows.Forms.TextBox
    Private WithEvents txtMilesPerGallon As System.Windows.Forms.TextBox
    Private WithEvents cboVehicleType As System.Windows.Forms.ComboBox




















    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblFuelCapacity = New System.Windows.Forms.Label()
        Me.cboVehicleType = New System.Windows.Forms.ComboBox()
        Me.lblVehicleType = New System.Windows.Forms.Label()
        Me.chxSailboat = New System.Windows.Forms.CheckBox()
        Me.txtMilesPerGallon = New System.Windows.Forms.TextBox()
        Me.cmdComputeRange = New System.Windows.Forms.Button()
        Me.txtFuelCapacity = New System.Windows.Forms.TextBox()
        Me.lblComputedRange = New System.Windows.Forms.Label()
        Me.lblMilesPerGallon = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        lblFuelCapacity.Location = New System.Drawing.Point(16, 96)
        lblFuelCapacity.Text = "Fuel Capacity:"
        lblFuelCapacity.Size = New System.Drawing.Size(100, 16)
        lblFuelCapacity.TabIndex = 12
        lblFuelCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right

        cboVehicleType.Location = New System.Drawing.Point(120, 24)
        cboVehicleType.Size = New System.Drawing.Size(104, 21)
        cboVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboVehicleType.TabIndex = 8
        cboVehicleType.Items.Add("Car")
        cboVehicleType.Items.Add("Boat")

        lblVehicleType.Location = New System.Drawing.Point(16, 24)
        lblVehicleType.Text = "Vehicle Type:"
        lblVehicleType.Size = New System.Drawing.Size(100, 16)
        lblVehicleType.TabIndex = 16
        lblVehicleType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right

        chxSailboat.Location = New System.Drawing.Point(120, 128)
        chxSailboat.Text = "Sailboat"
        chxSailboat.Size = New System.Drawing.Size(104, 24)
        chxSailboat.Enabled = False
        chxSailboat.TabIndex = 18

        txtMilesPerGallon.Location = New System.Drawing.Point(120, 64)
        txtMilesPerGallon.TabIndex = 9
        txtMilesPerGallon.Size = New System.Drawing.Size(100, 20)

        cmdComputeRange.Location = New System.Drawing.Point(120, 160)
        cmdComputeRange.Size = New System.Drawing.Size(96, 23)
        cmdComputeRange.TabIndex = 15
        cmdComputeRange.Text = "Compute Range"

        txtFuelCapacity.Location = New System.Drawing.Point(120, 96)
        txtFuelCapacity.TabIndex = 10
        txtFuelCapacity.Size = New System.Drawing.Size(100, 20)

        lblComputedRange.Location = New System.Drawing.Point(8, 192)
        lblComputedRange.Text = "Click Compute Range To See Your Vehicle's Range"
        lblComputedRange.Size = New System.Drawing.Size(280, 48)
        lblComputedRange.ForeColor = System.Drawing.Color.Red
        lblComputedRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold)
        lblComputedRange.TabIndex = 19

        lblMilesPerGallon.Location = New System.Drawing.Point(16, 64)
        lblMilesPerGallon.Text = "Miles Per Gallon:"
        lblMilesPerGallon.Size = New System.Drawing.Size(100, 16)
        lblMilesPerGallon.TabIndex = 11
        lblMilesPerGallon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Text = "VehicleDemo"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 245)

        Me.Controls.Add(lblComputedRange)
        Me.Controls.Add(chxSailboat)
        Me.Controls.Add(lblVehicleType)
        Me.Controls.Add(cmdComputeRange)
        Me.Controls.Add(lblFuelCapacity)
        Me.Controls.Add(lblMilesPerGallon)
        Me.Controls.Add(txtFuelCapacity)
        Me.Controls.Add(txtMilesPerGallon)
        Me.Controls.Add(cboVehicleType)
    End Sub

#End Region

    Protected Sub cboVehicleType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVehicleType.SelectedIndexChanged
        'Enable/Disable the Sailboat checkbox depending on the VehicleType
        If Me.cboVehicleType.Text = "Boat" Then
            Me.chxSailboat.Enabled = True
        Else
            Me.chxSailboat.Enabled = False
        End If
    End Sub

    Protected Sub cmdComputeRange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdComputeRange.click
        Dim Vehicle As Object
        Dim Range As Integer

        'Create the object type based on the type of vehicle specified.
        'We are late binding the objVehicle object, so we can create it as either a
        'car or a boat.
        If Me.cboVehicleType.Text = "Boat" Then
            If Me.chxSailboat.Checked Then
                Vehicle = New SailBoat()
            Else
                Vehicle = New Boat()
            End If
        Else
            Vehicle = New Car()
        End If

        'Set the FuelCapacity and MilesPerGallon properties
        'These calls are the same regardless of the type of vehicle
        Vehicle.FuelCapacity = CInt(Me.txtFuelCapacity.Text)
        Vehicle.MilesPerGallon = CInt(Me.txtMilesPerGallon.Text)
        'Call the ComputeRange function.  Note that we will execute different implementations
        'of this method depending on the vehicle type.
        Range = Vehicle.ComputeRange()

        'Display the computed range
        Me.lblComputedRange.Text = "Your Vehicle's Range is: " & CStr(Range)

    End Sub

End Class
