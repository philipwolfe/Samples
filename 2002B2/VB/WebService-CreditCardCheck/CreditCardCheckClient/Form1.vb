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
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub
    Friend WithEvents cmdVerify As System.Windows.Forms.Button
    Friend WithEvents txtCreditCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblResult As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdVerify = New System.Windows.Forms.Button()
        Me.txtCreditCardNumber = New System.Windows.Forms.TextBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdVerify
        '
        Me.cmdVerify.Location = New System.Drawing.Point(224, 16)
        Me.cmdVerify.Name = "cmdVerify"
        Me.cmdVerify.Size = New System.Drawing.Size(80, 24)
        Me.cmdVerify.TabIndex = 0
        Me.cmdVerify.Text = "Verify"
        '
        'txtCreditCardNumber
        '
        Me.txtCreditCardNumber.Location = New System.Drawing.Point(40, 16)
        Me.txtCreditCardNumber.Name = "txtCreditCardNumber"
        Me.txtCreditCardNumber.Size = New System.Drawing.Size(168, 20)
        Me.txtCreditCardNumber.TabIndex = 1
        Me.txtCreditCardNumber.Text = ""
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(40, 56)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(176, 24)
        Me.lblResult.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(336, 93)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblResult, Me.txtCreditCardNumber, Me.cmdVerify})
        Me.Name = "Form1"
        Me.Text = "Credit Card Check"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVerify.Click

        ' A Web Reference was setup, pointing to http://localhost/CreditCheckService.  This
        ' allows us to Early Bind to the Web Service

        ' Instantiate the CreditCheck Web Service
        Dim CreditCheck As New localhost.Service1()

        ' Display an Hourglass cursor
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Try
            ' Call the Web Service
            Dim Result As String
            Result = CreditCheck.VerifyCreditCard(txtCreditCardNumber.Text)
            If (Result = "Approved") Then
                lblResult.ForeColor = Color.Green
            Else
                lblResult.ForeColor = Color.Red
            End If
            lblResult.Text = Result
        Catch
            ' Display an error message
            MessageBox.Show("An unexpected error was returned fromt he service.", "Service Error")
        End Try

        ' Return the cursor to it's normal state
        Me.Cursor = System.Windows.Forms.Cursors.Arrow

    End Sub
End Class
