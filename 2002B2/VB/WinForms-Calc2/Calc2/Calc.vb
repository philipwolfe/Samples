Public Class Form1
    Inherits System.Windows.Forms.Form


    'Data variables
    Private Op1, Op2 As Double          'Previously input operand.
    Private NumOps As Integer             'Number of operands.
    Private LastInput As Operation        'Indicate type of last keypress event.
    Private OpFlag As String              'Indicate pending operation.
    Private OpPrev As String              'Previous operation
    Private Minus As String               'Just like a #define for "-"

    Private Enum Operation
        None = 0
        Operand
        Operator
        CE
        Cancel
    End Enum

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub
    Friend WithEvents Calc9 As System.Windows.Forms.Button
    Friend WithEvents Calc8 As System.Windows.Forms.Button
    Friend WithEvents CalcRes As System.Windows.Forms.Button
    Friend WithEvents CalcDec As System.Windows.Forms.Button
    Friend WithEvents CalcCan As System.Windows.Forms.Button
    Friend WithEvents Calc7 As System.Windows.Forms.Button
    Friend WithEvents Calc6 As System.Windows.Forms.Button
    Friend WithEvents CalcDiv As System.Windows.Forms.Button
    Friend WithEvents CalcBS As System.Windows.Forms.Button
    Friend WithEvents calcField As System.Windows.Forms.TextBox
    Friend WithEvents CalcMul As System.Windows.Forms.Button
    Friend WithEvents CalcSub As System.Windows.Forms.Button
    Friend WithEvents CalcSign As System.Windows.Forms.Button
    Friend WithEvents Calc5 As System.Windows.Forms.Button
    Friend WithEvents Calc4 As System.Windows.Forms.Button
    Friend WithEvents Calc3 As System.Windows.Forms.Button
    Friend WithEvents Calc2 As System.Windows.Forms.Button
    Friend WithEvents Calc1 As System.Windows.Forms.Button
    Friend WithEvents Calc0 As System.Windows.Forms.Button
    Friend WithEvents CalcCE As System.Windows.Forms.Button
    Friend WithEvents CalcPlus As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CalcSub = New System.Windows.Forms.Button()
        Me.calcField = New System.Windows.Forms.TextBox()
        Me.CalcDiv = New System.Windows.Forms.Button()
        Me.CalcPlus = New System.Windows.Forms.Button()
        Me.CalcRes = New System.Windows.Forms.Button()
        Me.CalcCan = New System.Windows.Forms.Button()
        Me.Calc7 = New System.Windows.Forms.Button()
        Me.Calc6 = New System.Windows.Forms.Button()
        Me.CalcBS = New System.Windows.Forms.Button()
        Me.Calc4 = New System.Windows.Forms.Button()
        Me.Calc3 = New System.Windows.Forms.Button()
        Me.Calc2 = New System.Windows.Forms.Button()
        Me.CalcSign = New System.Windows.Forms.Button()
        Me.Calc0 = New System.Windows.Forms.Button()
        Me.Calc9 = New System.Windows.Forms.Button()
        Me.Calc8 = New System.Windows.Forms.Button()
        Me.CalcCE = New System.Windows.Forms.Button()
        Me.Calc5 = New System.Windows.Forms.Button()
        Me.CalcMul = New System.Windows.Forms.Button()
        Me.Calc1 = New System.Windows.Forms.Button()
        Me.CalcDec = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CalcSub
        '
        Me.CalcSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcSub.Location = New System.Drawing.Point(160, 144)
        Me.CalcSub.Name = "CalcSub"
        Me.CalcSub.Size = New System.Drawing.Size(32, 32)
        Me.CalcSub.TabIndex = 0
        Me.CalcSub.Text = "-"
        '
        'calcField
        '
        Me.calcField.Location = New System.Drawing.Point(16, 8)
        Me.calcField.Name = "calcField"
        Me.calcField.Size = New System.Drawing.Size(224, 20)
        Me.calcField.TabIndex = 1
        Me.calcField.Text = ""
        Me.calcField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CalcDiv
        '
        Me.CalcDiv.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcDiv.Location = New System.Drawing.Point(160, 48)
        Me.CalcDiv.Name = "CalcDiv"
        Me.CalcDiv.Size = New System.Drawing.Size(32, 32)
        Me.CalcDiv.TabIndex = 0
        Me.CalcDiv.Text = "/"
        '
        'CalcPlus
        '
        Me.CalcPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcPlus.Location = New System.Drawing.Point(160, 192)
        Me.CalcPlus.Name = "CalcPlus"
        Me.CalcPlus.Size = New System.Drawing.Size(32, 32)
        Me.CalcPlus.TabIndex = 0
        Me.CalcPlus.Text = "+"
        '
        'CalcRes
        '
        Me.CalcRes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcRes.Location = New System.Drawing.Point(208, 192)
        Me.CalcRes.Name = "CalcRes"
        Me.CalcRes.Size = New System.Drawing.Size(32, 32)
        Me.CalcRes.TabIndex = 0
        Me.CalcRes.Text = "="
        '
        'CalcCan
        '
        Me.CalcCan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcCan.Location = New System.Drawing.Point(208, 144)
        Me.CalcCan.Name = "CalcCan"
        Me.CalcCan.Size = New System.Drawing.Size(32, 32)
        Me.CalcCan.TabIndex = 0
        Me.CalcCan.Text = "C"
        '
        'Calc7
        '
        Me.Calc7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc7.Location = New System.Drawing.Point(16, 48)
        Me.Calc7.Name = "Calc7"
        Me.Calc7.Size = New System.Drawing.Size(32, 32)
        Me.Calc7.TabIndex = 0
        Me.Calc7.Text = "7"
        '
        'Calc6
        '
        Me.Calc6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc6.Location = New System.Drawing.Point(112, 96)
        Me.Calc6.Name = "Calc6"
        Me.Calc6.Size = New System.Drawing.Size(32, 32)
        Me.Calc6.TabIndex = 0
        Me.Calc6.Text = "6"
        '
        'CalcBS
        '
        Me.CalcBS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcBS.Location = New System.Drawing.Point(208, 48)
        Me.CalcBS.Name = "CalcBS"
        Me.CalcBS.Size = New System.Drawing.Size(32, 32)
        Me.CalcBS.TabIndex = 0
        Me.CalcBS.Text = "BS"
        '
        'Calc4
        '
        Me.Calc4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc4.Location = New System.Drawing.Point(16, 96)
        Me.Calc4.Name = "Calc4"
        Me.Calc4.Size = New System.Drawing.Size(32, 32)
        Me.Calc4.TabIndex = 0
        Me.Calc4.Text = "4"
        '
        'Calc3
        '
        Me.Calc3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc3.Location = New System.Drawing.Point(112, 144)
        Me.Calc3.Name = "Calc3"
        Me.Calc3.Size = New System.Drawing.Size(32, 32)
        Me.Calc3.TabIndex = 0
        Me.Calc3.Text = "3"
        '
        'Calc2
        '
        Me.Calc2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc2.Location = New System.Drawing.Point(64, 144)
        Me.Calc2.Name = "Calc2"
        Me.Calc2.Size = New System.Drawing.Size(32, 32)
        Me.Calc2.TabIndex = 0
        Me.Calc2.Text = "2"
        '
        'CalcSign
        '
        Me.CalcSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcSign.Location = New System.Drawing.Point(64, 192)
        Me.CalcSign.Name = "CalcSign"
        Me.CalcSign.Size = New System.Drawing.Size(32, 32)
        Me.CalcSign.TabIndex = 0
        Me.CalcSign.Text = "+/-"
        '
        'Calc0
        '
        Me.Calc0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc0.Location = New System.Drawing.Point(16, 192)
        Me.Calc0.Name = "Calc0"
        Me.Calc0.Size = New System.Drawing.Size(32, 32)
        Me.Calc0.TabIndex = 0
        Me.Calc0.Text = "0"
        '
        'Calc9
        '
        Me.Calc9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc9.Location = New System.Drawing.Point(112, 48)
        Me.Calc9.Name = "Calc9"
        Me.Calc9.Size = New System.Drawing.Size(32, 32)
        Me.Calc9.TabIndex = 0
        Me.Calc9.Text = "9"
        '
        'Calc8
        '
        Me.Calc8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc8.Location = New System.Drawing.Point(64, 48)
        Me.Calc8.Name = "Calc8"
        Me.Calc8.Size = New System.Drawing.Size(32, 32)
        Me.Calc8.TabIndex = 0
        Me.Calc8.Text = "8"
        '
        'CalcCE
        '
        Me.CalcCE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcCE.Location = New System.Drawing.Point(208, 96)
        Me.CalcCE.Name = "CalcCE"
        Me.CalcCE.Size = New System.Drawing.Size(32, 32)
        Me.CalcCE.TabIndex = 0
        Me.CalcCE.Text = "CE"
        '
        'Calc5
        '
        Me.Calc5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc5.Location = New System.Drawing.Point(64, 96)
        Me.Calc5.Name = "Calc5"
        Me.Calc5.Size = New System.Drawing.Size(32, 32)
        Me.Calc5.TabIndex = 0
        Me.Calc5.Text = "5"
        '
        'CalcMul
        '
        Me.CalcMul.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcMul.Location = New System.Drawing.Point(160, 96)
        Me.CalcMul.Name = "CalcMul"
        Me.CalcMul.Size = New System.Drawing.Size(32, 32)
        Me.CalcMul.TabIndex = 0
        Me.CalcMul.Text = "*"
        '
        'Calc1
        '
        Me.Calc1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Calc1.Location = New System.Drawing.Point(16, 144)
        Me.Calc1.Name = "Calc1"
        Me.Calc1.Size = New System.Drawing.Size(32, 32)
        Me.Calc1.TabIndex = 0
        Me.Calc1.Text = "1"
        '
        'CalcDec
        '
        Me.CalcDec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CalcDec.Location = New System.Drawing.Point(112, 192)
        Me.CalcDec.Name = "CalcDec"
        Me.CalcDec.Size = New System.Drawing.Size(32, 32)
        Me.CalcDec.TabIndex = 0
        Me.CalcDec.Text = "."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(248, 237)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.calcField, Me.Calc3, Me.Calc2, Me.Calc1, Me.CalcRes, Me.CalcPlus, Me.CalcDec, Me.CalcSign, Me.Calc0, Me.Calc7, Me.Calc8, Me.Calc9, Me.CalcDiv, Me.CalcBS, Me.CalcCE, Me.CalcMul, Me.Calc6, Me.Calc5, Me.Calc4, Me.CalcCan, Me.CalcSub})
        Me.Name = "Form1"
        Me.Text = "Calculator"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Calc7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc7.Click
        CalcNum_Click(sender, e)
    End Sub

    '0 - 9, ., click event
    Protected Sub CalcNum_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (LastInput.Equals(Operation.Operand) = False) Then
            calcField().Text = "0."
        End If

        Dim SelButton As Button
        SelButton = CType(sender, Button)
        FormatEditField(SelButton.Text)

        LastInput = Operation.Operand
    End Sub

    'private helpers
    'helper to format the entry in the text box!
    Private Sub FormatEditField(ByVal newChar As String)
        Dim strValue As String
        strValue = calcField().Text

        If (strValue.CompareTo("0.") = 0) Then
            strValue = newChar
        Else
            'determine if there are more than one .'s
            If (newChar = ".") Then
                'if it's found, return
                If (strValue.IndexOf(newChar) <> -1) Then
                    'don't do anything
                    Return
                End If
            End If

            strValue = strValue + newChar
        End If

        calcField().Text = strValue
    End Sub

    ' helper to initialize the vals
    Private Sub Reset()
        Op1 = 0
        Op2 = 0

        NumOps = 0
        LastInput = Operation.None

        OpFlag = ""
        OpPrev = ""

        calcField().Text = "0."
    End Sub

    Private Sub Calc9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc9.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub Calc8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc8.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub Calc6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc6.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub Calc5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc5.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub Calc4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc4.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub Calc3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc3.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub Calc2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc2.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub Calc1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc1.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub Calc0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calc0.Click
        CalcNum_Click(sender, e)
    End Sub

    Private Sub CalcBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBS.Click
        Dim strValue As String
        strValue = calcField().Text

        If ((strValue.CompareTo("0.") <> 0) And (strValue.Length <> 0)) Then
            strValue = strValue.Remove(strValue.Length - 1, 1)
        End If

        If ((strValue.Length = 0) Or (strValue = "-")) Then
            strValue = "0."
        End If

        calcField().Text = strValue
    End Sub

    Private Sub CalcCan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcCan.Click
        Reset()
    End Sub

    Private Sub CalcCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcCE.Click
        If (LastInput.Equals(Operation.Operand)) Then
            calcField().Text = "0."
        ElseIf (LastInput.Equals(Operation.Operator)) Then
            OpFlag = OpPrev
        End If

        LastInput = Operation.CE
    End Sub

    Private Sub CalcDiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcDiv.Click
        CalcRes_Click(sender, e)
    End Sub

    Private Sub CalcRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcRes.Click
        If (calcField().Text.Length = 0) Then
            Return
        End If

        If (LastInput.Equals(Operation.Operand)) Then
            NumOps = NumOps + 1
        End If

        Select Case NumOps
            Case 1
                Op1 = Convert.ToDouble(calcField().Text)

            Case 2
                Op2 = Convert.ToDouble(calcField().Text)

                Select Case OpFlag
                    Case "+"
                        Op1 = Op1 + Op2

                    Case "-"
                        Op1 = Op1 - Op2

                    Case "*"
                        Op1 = Op1 * Op2

                    Case "/"
                        If (Op2 = 0) Then
                            MsgBox("Can't divide by zero!", MsgBoxStyle.OKOnly, "Calculator")
                        Else
                            Op1 = Op1 / Op2
                        End If

                    Case "="
                        Op1 = Op2
                End Select

                calcField().Text = Op1.ToString()
                NumOps = 1
        End Select

        LastInput = Operation.Operator
        OpPrev = OpFlag

        Dim SelButton As Button
        SelButton = CType(sender, Button)
        OpFlag = SelButton.Text
    End Sub

    Private Sub CalcSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcSub.Click
        CalcRes_Click(sender, e)
    End Sub

    Private Sub CalcMul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcMul.Click
        CalcRes_Click(sender, e)
    End Sub

    Private Sub CalcPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcPlus.Click
        CalcRes_Click(sender, e)
    End Sub

    Private Sub CalcSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcSign.Click
        If (calcField().Text = "-") Then
            calcField().Text = calcField().Text.TrimStart(Minus.ToCharArray())
        Else
            calcField().Text = Minus + calcField().Text
        End If

        LastInput = Operation.Operand
    End Sub

    Private Sub CalcDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcDec.Click
        CalcNum_Click(sender, e)
    End Sub
End Class
