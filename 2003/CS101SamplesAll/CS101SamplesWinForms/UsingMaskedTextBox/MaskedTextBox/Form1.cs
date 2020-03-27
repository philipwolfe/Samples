using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsingMaskedTextBox
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

            this.PhoneNoMaskedTextBox.Mask = "(999) 000-0000";
            // Beep upon invalid entry
            this.PhoneNoMaskedTextBox.BeepOnError = true;
            
            // Date mask example
            this.ShortDateMaskedTextBox.Mask = "09/09/0099";
            // The mask doesn't validate the value; it will accept 13/32/0000.
            // Therefore, use the ValidatingType property to specify a date type for validation.
            this.ShortDateMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // To know if validation fails, listen to the TypeValidationCompleted event
            this.ShortDateMaskedTextBox.TypeValidationCompleted +=new TypeValidationEventHandler(MyTypeValidationCompleted);

            this.SSNMaskedTextBox.Mask = "000-00-0000";
            // The prompt can be customized.
            this.SSNMaskedTextBox.PromptChar = '#';
            // And hidden when focus is lost.
            this.SSNMaskedTextBox.HidePromptOnLeave = true;
            
            this.Custom1MaskedTextBox.Mask = "AA000A";
            // Provide custom behavior when mask rejects the input.
            this.Custom1MaskedTextBox.MaskInputRejected +=new MaskInputRejectedEventHandler(MaskInputRejected);
            // Reset custom behavior when user types a character.
            this.Custom1MaskedTextBox.KeyDown += new KeyEventHandler(MaskInputReset);

			this.Custom2MaskedTextBox.Mask = "QP00-LA";
			
			this.Custom3MaskedTextBox.Mask = ">LL0099";

			this.CurrencyMaskedTextBox.Mask = "$999,999.00";

			this.LatitudeMaskedTextBox.Mask = "00 >L";
			this.LatitudeMaskedTextBox.ValidatingType = typeof(Latitude);
			this.LatitudeMaskedTextBox.TypeValidationCompleted += new TypeValidationEventHandler(MyTypeValidationCompleted);

			// Display masks in labels.
			this.PhoneNoMaskLabel.Text = this.PhoneNoMaskedTextBox.Mask;
			this.ShortDateMaskLabel.Text = this.ShortDateMaskedTextBox.Mask;
			this.SSNMaskLabel.Text = this.SSNMaskedTextBox.Mask;
			this.Custom1MaskLabel.Text = this.Custom1MaskedTextBox.Mask;
			this.Custom2MaskLabel.Text = this.Custom2MaskedTextBox.Mask;
			this.Custom3MaskLabel.Text = this.Custom3MaskedTextBox.Mask;
			this.CurrencyMaskLabel.Text = this.CurrencyMaskedTextBox.Mask;
			this.LatitudeMaskLabel.Text = this.LatitudeMaskedTextBox.Mask;
		}

        // Provide a custom handler for invalid mask notification.
        // This handler changes the text to red.
        private void MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            System.Windows.Forms.MaskedTextBox ctl = (System.Windows.Forms.MaskedTextBox)sender;
            ctl.ForeColor = Color.Red;
        }
		// Change control outline back to default.
        private void MaskInputReset(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.MaskedTextBox ctl = (System.Windows.Forms.MaskedTextBox)sender;
            ctl.ForeColor = Color.FromName("Window Text");
        }

        private void MaskTextBox_Leave(object sender, EventArgs e)
		{
			// Set the mask for testing.
			this.TesterMaskedTextBox.Mask = this.MaskTextBox.Text;
        }

		private void CurrencyMaskedTextBox_Leave(object sender, EventArgs e)
		{
			// Reflect the results of applying the mask.
			this.CurrencyMaskedTextBox.Text = this.CurrencyMaskedTextBox.Text;
		}
		
		// The event args for the TypeValidationCompleted event
		// contain whether validaion failed.
		private void MyTypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
				MessageBox.Show(this, "The value you entered does not conform to type " + 
					((MaskedTextBox)sender).ValidatingType.ToString() + ".", this.Text);
            }
        }
	}
}