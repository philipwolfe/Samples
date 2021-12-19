Imports wabTSDemo.net.terraservice
Public Class Form1
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

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
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lblPU As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents cbPU As System.Windows.Forms.ComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblPU = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.cbPU = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(144, 320)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.TabIndex = 0
        Me.btnCheck.Text = "&Check"
        '
        'lblResult
        '
        Me.lblResult.Font = New System.Drawing.Font("Arial", 16!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.Location = New System.Drawing.Point(16, 96)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(344, 192)
        Me.lblResult.TabIndex = 1
        Me.lblResult.Text = "Value"
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPU
        '
        Me.lblPU.Location = New System.Drawing.Point(16, 8)
        Me.lblPU.Name = "lblPU"
        Me.lblPU.Size = New System.Drawing.Size(152, 23)
        Me.lblPU.TabIndex = 2
        Me.lblPU.Text = "Political Unit"
        '
        'lblYear
        '
        Me.lblYear.Location = New System.Drawing.Point(16, 40)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(160, 23)
        Me.lblYear.TabIndex = 3
        Me.lblYear.Text = "Year"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(176, 40)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.TabIndex = 4
        Me.txtYear.Text = "1990"
        '
        'cbPU
        '
        Me.cbPU.DropDownWidth = 121
        Me.cbPU.Items.AddRange(New Object() {"City", "County", "State", "CensusTract"})
        Me.cbPU.Location = New System.Drawing.Point(176, 8)
        Me.cbPU.Name = "cbPU"
        Me.cbPU.Size = New System.Drawing.Size(121, 21)
        Me.cbPU.TabIndex = 5
        Me.cbPU.Text = "City"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 366)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbPU, Me.txtYear, Me.lblYear, Me.lblPU, Me.lblResult, Me.btnCheck})
        Me.Name = "Form1"
        Me.Text = "TerraService - Visual Basic.NET"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click


        'Create a variable that refers to Terraserver's CensusServer
        Dim myCS As New CensusService()


        'Create a object that stores the Const from TerraServer
        Dim objPU As PoliticalUnit



        Dim txtPU As String

        txtPU = cbPU.Text

        If txtPU = "CensusTract" Then

            objPU = PoliticalUnit.CensusTract
        ElseIf txtPU = "City" Then
            objPU = PoliticalUnit.City
        ElseIf txtPU = "County" Then
            objPU = PoliticalUnit.County
        ElseIf txtPU = "State" Then

            objPU = PoliticalUnit.State

        Else
            objPU = PoliticalUnit.Unknown
        End If


        'Short and to the point
        lblResult.Text = CStr(myCS.CountOfPoliticalUnit(objPU, CInt(txtYear.Text)))


        'Verbose and descriptive
        'lblResult.Text() = "There are " + CStr(myCS.CountOfPoliticalUnit(objPU, CInt(txtYear.Text))) + " of type " + txtPU + " in the Census Database."


    End Sub

    Private Sub cbPU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPU.SelectedIndexChanged

    End Sub

    Private Sub lblYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblYear.Click

    End Sub

    Private Sub lblPU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPU.Click

    End Sub

    Private Sub txtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged

    End Sub

    Private Sub lblResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblResult.Click

    End Sub
End Class
