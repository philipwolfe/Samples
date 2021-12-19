Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


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
        'components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrentValue As System.Windows.Forms.Label
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents txtModel As System.Windows.Forms.TextBox
    Friend WithEvents txtMake As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdBlueBook As System.Windows.Forms.Button
    Friend WithEvents cmdBlackBook As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox



    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.txtMake = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblCurrentValue = New System.Windows.Forms.Label()
        Me.cmdBlueBook = New System.Windows.Forms.Button()
        Me.cmdBlackBook = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.cboCondition, Me.txtYear, Me.txtModel, Me.txtMake, Me.Label3, Me.Label2, Me.Label1, Me.GroupBox2})
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8!)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 328)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Price A Car"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Condition"
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.DropDownWidth = 120
        Me.cboCondition.Location = New System.Drawing.Point(72, 96)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(120, 21)
        Me.cboCondition.TabIndex = 9
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(72, 72)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(120, 20)
        Me.txtYear.TabIndex = 8
        Me.txtYear.Text = "1996"
        '
        'txtModel
        '
        Me.txtModel.Location = New System.Drawing.Point(72, 48)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(120, 20)
        Me.txtModel.TabIndex = 7
        Me.txtModel.Text = "Avenger"
        '
        'txtMake
        '
        Me.txtMake.Location = New System.Drawing.Point(72, 24)
        Me.txtMake.Name = "txtMake"
        Me.txtMake.Size = New System.Drawing.Size(120, 20)
        Me.txtMake.TabIndex = 6
        Me.txtMake.Text = "Dodge"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Year"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Model"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Make"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCurrentValue, Me.cmdBlueBook, Me.cmdBlackBook})
        Me.GroupBox2.Location = New System.Drawing.Point(16, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(232, 144)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Calculate Current Value Based on:"
        '
        'lblCurrentValue
        '
        Me.lblCurrentValue.Font = New System.Drawing.Font("Tahoma", 12!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentValue.Location = New System.Drawing.Point(104, 64)
        Me.lblCurrentValue.Name = "lblCurrentValue"
        Me.lblCurrentValue.Size = New System.Drawing.Size(120, 40)
        Me.lblCurrentValue.TabIndex = 2
        '
        'cmdBlueBook
        '
        Me.cmdBlueBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBlueBook.Location = New System.Drawing.Point(16, 88)
        Me.cmdBlueBook.Name = "cmdBlueBook"
        Me.cmdBlueBook.Size = New System.Drawing.Size(56, 40)
        Me.cmdBlueBook.TabIndex = 1
        Me.cmdBlueBook.Text = "Blue Book"
        '
        'cmdBlackBook
        '
        Me.cmdBlackBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBlackBook.Location = New System.Drawing.Point(16, 32)
        Me.cmdBlackBook.Name = "cmdBlackBook"
        Me.cmdBlackBook.Size = New System.Drawing.Size(56, 40)
        Me.cmdBlackBook.TabIndex = 0
        Me.cmdBlackBook.Text = "Black Book"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 357)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Delegate Sample - Price A Car"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    
    Private Function BlueBookValue(ByVal Make As String, ByVal Model As String, ByVal Year As String) As Double
        '*** In this sample, the blue book value is hard-coded in the Function.     ***
        '*** However, these values would typically be retrieved from a data source. ***
        Select Case UCase(Make)
            Case "DODGE"
                Select Case UCase(Model)
                    Case "AVENGER"
                        Select Case Year
                            Case "1996"
                                BlueBookValue = 14000
                            Case Else
                                BlueBookValue = 12000
                        End Select
                    Case Else
                        BlueBookValue = 10000
                End Select
            Case Else
                BlueBookValue = 8000
        End Select
    End Function

    Private Function BlackBookValue(ByVal Make As String, ByVal Model As String, ByVal Year As String) As Double
        '*** In this sample, the black book value is hard-coded in the Function.    ***
        '*** However, these values would typically be retrieved from a data source. ***
        Select Case UCase(Make)
            Case "DODGE"
                Select Case UCase(Model)
                    Case "AVENGER"
                        Select Case Year
                            Case "1996"
                                BlackBookValue = 16520
                            Case Else
                                BlackBookValue = 14520
                        End Select
                    Case Else
                        BlackBookValue = 12520
                End Select
            Case Else
                BlackBookValue = 10520
        End Select
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboCondition.Items.Add("MINT")
        Me.cboCondition.Items.Add("VERY GOOD")
        Me.cboCondition.Items.Add("GOOD")
        Me.cboCondition.Items.Add("POOR")
        Me.cboCondition.Items.Add("JUNK")


    End Sub

    Private Sub cmdBlackBook_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBlackBook.Click
        Dim objCar As New Car()
        Dim dblValue As Double

        '*** In this Sub, a reference to the BlueBookValue method will be passed to the ***
        '*** delegate indicating that the total value of the car should be based on our ***
        '*** calculated blue book value                                                 ***

        '*** In the call below, we use a delegate to call the BlueBookValue method  ***
        '*** on our behalf.  If, in the future, a new method of determining car     ***
        '*** values became avaliable (i.e. Red Book Values), we could add an add'l  ***
        '*** method without having to change our Cars component.                    ***
        Select Case UCase(Me.cboCondition.Text)
            Case "MINT"
                dblValue = objCar.CalculateTotal(AddressOf BlueBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condMint)
            Case "VERY GOOD"
                dblValue = objCar.CalculateTotal(AddressOf BlueBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condVeryGood)
            Case "GOOD"
                dblValue = objCar.CalculateTotal(AddressOf BlueBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condGood)
            Case "POOR"
                dblValue = objCar.CalculateTotal(AddressOf BlueBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condPoor)
            Case "JUNK"
                dblValue = objCar.CalculateTotal(AddressOf BlueBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condJunk)
        End Select

        Me.lblCurrentValue.Text = dblValue.ToString("C")
        objCar = Nothing
    End Sub

    Private Sub cmdBlueBook_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBlueBook.Click
        Dim objCar As New Car()
        Dim dblValue As Double

        '*** In this Sub, a reference to the BlackBookValue method will be passed to the ***
        '*** delegate indicating that the total value of the car should be based on our  ***
        '*** calculated black book value                                                 ***

        '*** In the call below, we use a delegate to call the BlackBookValue method ***
        '*** on our behalf.  If, in the future, a new method of determining car     ***
        '*** values became avaliable (i.e. Red Book Values), we could add an add'l  ***
        '*** method without having to change our Cars component.                    ***
        Select Case UCase(Me.cboCondition.Text)
            Case "MINT"
                dblValue = objCar.CalculateTotal(AddressOf BlackBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condMint)
            Case "VERY GOOD"
                dblValue = objCar.CalculateTotal(AddressOf BlackBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condVeryGood)
            Case "GOOD"
                dblValue = objCar.CalculateTotal(AddressOf BlackBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condGood)
            Case "POOR"
                dblValue = objCar.CalculateTotal(AddressOf BlackBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condPoor)
            Case "JUNK"
                dblValue = objCar.CalculateTotal(AddressOf BlackBookValue, Me.txtMake.Text, Me.txtModel.Text, Me.txtYear.Text, Car.ConditionEnum.condJunk)
        End Select

        Me.lblCurrentValue.Text = dblValue.ToString("C")
        objCar = Nothing
    End Sub
End Class
