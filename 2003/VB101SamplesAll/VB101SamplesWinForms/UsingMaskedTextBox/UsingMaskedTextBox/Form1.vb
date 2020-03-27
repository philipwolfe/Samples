Public Class Form1

    Public Sub New()

        ' me call is required by the Windows Form Designer.
        InitializeComponent()

        Me.PhoneNoMaskedTextBox.Mask = "(999) 000-0000"
        ' Beep upon invalid entry
        Me.PhoneNoMaskedTextBox.BeepOnError = True

        ' Date mask example
        Me.ShortDateMaskedTextBox.Mask = "09/09/0099"
        ' The mask doesn't validate the value it will accept 13/32/0000.
        ' Therefore, use the ValidatingType property to specify a date type for validation.
        Me.ShortDateMaskedTextBox.ValidatingType = GetType(System.DateTime)
        ' To know if validation fails, listen to the TypeValidationCompleted event
        AddHandler Me.ShortDateMaskedTextBox.TypeValidationCompleted, New TypeValidationEventHandler(AddressOf MyTypeValidationCompleted)

        Me.SSNMaskedTextBox.Mask = "000-00-0000"
        ' The prompt can be customized.
        Me.SSNMaskedTextBox.PromptChar = "#"
        ' And hidden when focus is lost.
        Me.SSNMaskedTextBox.HidePromptOnLeave = True

        Me.Custom1MaskedTextBox.Mask = "AA000A"
        ' Provide custom behavior when mask rejects the input.
        AddHandler Me.Custom1MaskedTextBox.MaskInputRejected, New MaskInputRejectedEventHandler(AddressOf MaskInputRejected)
        ' Reset custom behavior when user types a character.
        AddHandler Me.Custom1MaskedTextBox.KeyDown, New KeyEventHandler(AddressOf MaskInputReset)

        Me.Custom2MaskedTextBox.Mask = "QP00-LA"

        Me.Custom3MaskedTextBox.Mask = ">LL0099"

        Me.CurrencyMaskedTextBox.Mask = "$999,999.00"

        Me.LatitudeMaskedTextBox.Mask = "00 >L"
        Me.LatitudeMaskedTextBox.ValidatingType = GetType(Latitude)
        AddHandler Me.LatitudeMaskedTextBox.TypeValidationCompleted, New TypeValidationEventHandler(AddressOf MyTypeValidationCompleted)

        ' Display masks in labels.
        Me.PhoneNoMaskLabel.Text = Me.PhoneNoMaskedTextBox.Mask
        Me.ShortDateMaskLabel.Text = Me.ShortDateMaskedTextBox.Mask
        Me.SSNMaskLabel.Text = Me.SSNMaskedTextBox.Mask
        Me.Custom1MaskLabel.Text = Me.Custom1MaskedTextBox.Mask
        Me.Custom2MaskLabel.Text = Me.Custom2MaskedTextBox.Mask
        Me.Custom3MaskLabel.Text = Me.Custom3MaskedTextBox.Mask
        Me.CurrencyMaskLabel.Text = Me.CurrencyMaskedTextBox.Mask
        Me.LatitudeMaskLabel.Text = Me.LatitudeMaskedTextBox.Mask
    End Sub

            ' Provide a custom handler for invalid mask notification.
        ' me handler changes the text to red.
    Private Sub MaskInputRejected(ByVal sender As Object, ByVal e As MaskInputRejectedEventArgs)
        Dim ctl As System.Windows.Forms.MaskedTextBox = CType(sender, System.Windows.Forms.MaskedTextBox)
        ctl.ForeColor = Color.Red
    End Sub

    ' Change control outline back to default.
    Private Sub MaskInputReset(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim ctl As System.Windows.Forms.MaskedTextBox = CType(sender, System.Windows.Forms.MaskedTextBox)
        ctl.ForeColor = Color.FromName("Window Text")
    End Sub

    Private Sub MaskTextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskTextBox.Leave
        ' Reflect the results of applying the mask.
        Me.TesterMaskedTextBox.Mask = Me.MaskTextBox.Text
    End Sub

		' The event args for the TypeValidationCompleted event
		' contain whether validaion failed.
    Private Sub MyTypeValidationCompleted(ByVal sender As Object, ByVal e As TypeValidationEventArgs)
        If e.IsValidInput = False Then
            MessageBox.Show(Me, "The value you entered does not conform to type " & _
             CType(sender, MaskedTextBox).ValidatingType.ToString() & ".", Me.Text)
        End If
    End Sub

End Class
