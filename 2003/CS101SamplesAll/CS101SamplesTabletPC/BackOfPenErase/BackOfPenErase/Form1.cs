using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;

namespace BackOfPenErase
{
    public partial class Form1 : Form
    {
        InkOverlay myInkOverlay;
        InkOverlayEditingMode selectedMode;

        public Form1()
        {
            InitializeComponent();

            //Create and enable ink collection on the panel
            myInkOverlay = new InkOverlay(panel1);
            myInkOverlay.Enabled = true;

            //If the pen comes in range inverted, switch to "Delete" editing mode
            myInkOverlay.CursorInRange += delegate(object sender, InkCollectorCursorInRangeEventArgs e)
            {
                if (e.Cursor.Inverted)
                {
                    myInkOverlay.EditingMode = InkOverlayEditingMode.Delete;
                }
                else
                {
                    //Pen is not inverted, so switch (or maintain) manually selected editing mode
                    myInkOverlay.EditingMode = selectedMode;
                }
            };

            //Wire up the radio buttons

            //Ink Mode radio button
            radioButton1.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if (radioButton1.Checked)
                {
                    selectedMode = InkOverlayEditingMode.Ink;
                    DoModeChange(InkOverlayEditingMode.Ink);
                }
            };

            //Select mode radio button
            radioButton2.CheckedChanged += delegate(object sender, EventArgs e)
                        {
                            if (radioButton2.Checked)
                            {
                                selectedMode = InkOverlayEditingMode.Select;
                                DoModeChange(InkOverlayEditingMode.Select);
                            }
                        };

            //Delete mode radio button 
            radioButton3.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if (radioButton3.Checked)
                {
                    selectedMode = InkOverlayEditingMode.Delete;
                    DoModeChange(InkOverlayEditingMode.Delete);
                }
            };

            //Wire up delete mode buttons
            //Delete entire stroke
            radioButton4.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if (radioButton4.Checked)
                {
                    myInkOverlay.EraserMode = InkOverlayEraserMode.StrokeErase;
                }
            };

            //Delete point(s) at tip of pen
            radioButton5.CheckedChanged += delegate(object sender, EventArgs e)
            {
                if(radioButton5.Checked)
                {
                    myInkOverlay.EraserMode = InkOverlayEraserMode.PointErase;
                }
            };

        }

        private void DoModeChange(InkOverlayEditingMode newMode)
        {
            //Switch the collection mode
            myInkOverlay.EditingMode = newMode;

            //Switch the radio buttons to reflect new mode
            switch (newMode)
            {
                case InkOverlayEditingMode.Ink:
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    break;
                case InkOverlayEditingMode.Select:
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    radioButton3.Checked = false;
                    break;
                case InkOverlayEditingMode.Delete:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}