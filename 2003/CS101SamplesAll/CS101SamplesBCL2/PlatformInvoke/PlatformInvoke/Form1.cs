// Demonstrates new interop abilities such as the ability to wrap native function pointers 
// into delegates and the ability to marshal fixed-size arrays of structures inside structures.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlatformInvoke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Init some values for the bottom right point
            BottomRightXUpDown.Value = 5;
            BottomRightYUpDown.Value = 5;
        }

        //  This is the CallBack Method.  The DLL will call this method with the area
        //  calculated within the dll
        public static void ShowArea(int area)
        {
            MessageBox.Show("Calculated Area From CallBack = " + area.ToString());
        }

        //  Validate that the points are indeed topLeft and bottomRight
        private bool ValidatePoints(MyPoint tlPoint, MyPoint brPoint)
        {
            if ((tlPoint.x < brPoint.x) && (tlPoint.y < brPoint.y))
                return true;
            else
                return false;
        }

        //  Create and populate the Rectangle structure based on the UpDown Controls
        private MyRectangle GetRectangle()
        {
            MyPoint tlPoint;
            MyPoint brPoint;

            //  Create points based on UpDown controls
            int x = (int)TopLeftXUpDown.Value;
            int y = (int)TopLeftYUpDown.Value;
            tlPoint = new MyPoint((int)TopLeftXUpDown.Value, (int)TopLeftYUpDown.Value);
            x = (int)BottomRightXUpDown.Value;
            y = (int)BottomRightYUpDown.Value;
            brPoint = new MyPoint((int)BottomRightXUpDown.Value, (int)BottomRightYUpDown.Value);

            //  Make sure that points are indeed topLeft and bottomRight
            if ((ValidatePoints(tlPoint, brPoint) == false))
            {
                throw new Exception("Error: Points are not top left and bottom right");
            }
            return new MyRectangle(tlPoint, brPoint);
        }

        private void CalcAreaButton_Click(object sender, EventArgs e)
        {
            try
            {
                //  Get Rectangle based on UI
                MyRectangle rect = GetRectangle();

                //  Marshal Rectangle (array of struct inside a struct) to unmanaged DLL and
                //  return calculated area
                int area = LibWrapper.GetRectangleArea(ref rect);

                AreaLabel.Text = area.ToString();
                CalcAreaLabel.Text = area.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalcAreaCallBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                //  Get Rectangle based on UI
                MyRectangle rect = GetRectangle();

                //  Marshal address of callback function and 
                //  marshal Rectangle (array of struct inside a struct) to unmanaged DLL and
                //  return calculated area via callback function
                FPtr callback;
                callback = new FPtr(Form1.ShowArea);
                LibWrapper.GetRectangleAreaCallBack(callback, ref rect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}