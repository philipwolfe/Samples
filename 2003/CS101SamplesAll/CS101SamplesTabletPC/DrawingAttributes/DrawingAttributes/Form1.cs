using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;

namespace DrawingAttributes
{
    public partial class Form1 : Form
    {
        InkOverlay inkOverlay;
        bool isDisposed;

        public Form1()
        {
            InitializeComponent();

            //Place the various raster operations in the group box
            InitializeRasterOperations();

            //Create and enable the ink collecting control
            inkOverlay = new InkOverlay(panel1);
            inkOverlay.Enabled = true;

            //Set the initial drawing attributes
            SetAttributes(null, null);
        }

        //Populate the group box with a list of the available raster operations
        void InitializeRasterOperations()
        {
            //Add all the name in RasterOperation to the groupbox for possible selection
            foreach (String rasterOpName in Enum.GetNames(typeof(RasterOperation)))
            {
                //Create a new radio button
                RadioButton rasterButton = new RadioButton();
                rasterButton.Text = rasterOpName;

                //Default raster op is "CopyPen"
                if (rasterOpName == "CopyPen")
                {
                    rasterButton.Checked = true;
                }

                //Add button to flow layout panel
                flowLayoutPanel1.Controls.Add(rasterButton);

                //Handle checked changed
                rasterButton.CheckedChanged += delegate(object sender, EventArgs e)
                {
                    //Note use of "outer variable capture"
                    if (rasterButton.Checked)
                    {
                        //Change from text to enum value
                        RasterOperation chosenOp = (RasterOperation) Enum.Parse(typeof(RasterOperation), rasterButton.Text);
                        //Set attribute
                        inkOverlay.DefaultDrawingAttributes.RasterOperation = chosenOp;
                    }
                };
            }
        }

        //Sets the major default drawing attributes of the InkOverlay (minus color, raster operation, and some rare attributes)
        void SetAttributes(object sender, EventArgs e)
        {
            //Anti-aliasing
            inkOverlay.DefaultDrawingAttributes.AntiAliased = antiAliasedCheckBox.Checked;

            //Pressure sensitivity
            inkOverlay.DefaultDrawingAttributes.IgnorePressure = !pressureSensitiveCheckBox.Checked;

            //Pen tip
            if (penTipBall.Checked)
            {
                inkOverlay.DefaultDrawingAttributes.PenTip = PenTip.Ball;
            }
            else
            {
                inkOverlay.DefaultDrawingAttributes.PenTip = PenTip.Rectangle;
            }

            //Transparency
            inkOverlay.DefaultDrawingAttributes.Transparency = Decimal.ToByte(transparencyUpDown.Value);

            //Height
            inkOverlay.DefaultDrawingAttributes.Height = Decimal.ToInt32(heightUpDown.Value);

            //Width
            inkOverlay.DefaultDrawingAttributes.Width = Decimal.ToInt32(widthUpDown.Value);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            //Create the standard dialog
            ColorDialog colorDialog = new ColorDialog();
            //Set the color to the current ink color
            colorDialog.Color = inkOverlay.DefaultDrawingAttributes.Color;
            //Show it
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                //Set color to chosen
                inkOverlay.DefaultDrawingAttributes.Color = colorDialog.Color;
            }
        }
    }
}