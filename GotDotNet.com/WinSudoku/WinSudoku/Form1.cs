using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WinSudoku
{
    public partial class Form1 : Form
    {
        private int[,] stack;
        private int[,] init;

        public Form1()
        {
            InitializeComponent();
            ar = new int[9,9];      // array to hold entered values [row,column]
            init = new int[9,9];    // array to define user entered initial values
            stack = new int[82,3]; // array to keep track of tried values [row,column,value]
        }

        /// <summary>
        /// Lock initial values and read from textbox into array
        /// </summary>
        void fillArray()
        {
            System.Windows.Forms.TextBox tb;
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    ar[j, i] = 0;
                    init[j, i] = 0;
                    // get the textbox associated with the array
                    tb = (System.Windows.Forms.TextBox)findTextbox(i + j * 9);
                    tb.ForeColor = Color.Black;
                    if (tb.Text.Length > 0)     // found entry
                    {
                        try
                        {
                            ar[j, i] = Convert.ToInt32(tb.Text);
                            if ((ar[j, i] > 0) && (ar[j, i] < 10))
                            {
                                //tb.Enabled = false;
                                init[j, i] = -1;
                                tb.ForeColor = Color.Red;
                            }
                            else
                                tb.Text = "";
                        }
                        catch
                        {
                            tb.Text = "";   // wipe invalid entry
                        }
                    }
                    else
                        ar[j, i] = 0;
                }
            }
            return;
        }

        /// <summary>
        /// Start BackgroundWorker process to solve puzzle
        /// </summary>
        void Startwork()
        {
            Cursor = Cursors.WaitCursor;
            bw1.RunWorkerAsync();
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Background function to solve by trial and error method
        /// Insert one value into a row that is not present in the same row or column,
        /// push location and value on stack and continue.
        /// If solution works, increment value, if no solution at end, back off on stack and retry.
        /// </summary>
        int solveIt(BackgroundWorker worker, DoWorkEventArgs e)
        {
            //BackgroundWorker bw = (BackgroundWorker)sender; 
            fillArray();
            System.Windows.Forms.TextBox tb;
            int row = 0;
            int col = 0;
            int stpt = 0;
            stack[0,0] = 0;
            stack[0,1] = 0;
            stack[0,2] = 1;
            int val = 1; 
            // main loop, break out when done
            while (true)
            {
                if (col > 8)
                {
                    col = 0;
                    row++;
                }
                if (row > 8) // got it!
                {
                    break;
                }
                // find first open square
                if(init[row,col] == -1) // has initial value in it
                {
                    col++;
                    continue;
                }
                while (isPresent(row, col, val) == true)
                {
                    val++;
                }
                if (val < 10)    // found possible solution, save location and value
                {
                    stack[stpt, 0] = row;
                    stack[stpt, 1] = col;
                    stack[stpt, 2] = val;
                    ar[row, col] = val;
                    init[row, col] = 1;
                    tb = (System.Windows.Forms.TextBox)findTextbox(col + row * 9);
                    bw1.ReportProgress(col + row * 9, val);
                    Thread.Sleep(10);
                    // set parameters for next try
                    stpt++;
                    col++;
                    val = 1;
                    continue;
                }
                else
                {
                    // couldn't find a solution, so backtrack...
                    while (true)
                    {
                        if (stpt == 0)
                            return 1;
                        stpt--; // go to previous entry on stack
                        if ((stpt == 0) && (stack[0, 2] == 9))
                        {
                            return 1;
                        }
                        row = stack[stpt, 0];
                        col = stack[stpt, 1];
                        val = stack[stpt, 2];
                        // find associated textbox in window and clear text
                        tb = (System.Windows.Forms.TextBox)findTextbox(col + row * 9);
                        bw1.ReportProgress(col + row * 9, val);
                        Thread.Sleep(10);
                        ar[row, col] = 0;
                        init[row, col] = 0;
                        val++;
                        if (val < 10)
                            break;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// Updates displayed numbers as they are tried by the background process
        /// </summary>
        /// <param name="e">e.ProcessPercentage = number of TextBox (0 to 80), e.UserState = TextBox.Text</param>
        void textUpdate(System.ComponentModel.ProgressChangedEventArgs e)
        {
            System.Windows.Forms.TextBox tb;
            tb = (System.Windows.Forms.TextBox)findTextbox(e.ProgressPercentage);
            tb.Text = e.UserState.ToString();
        }

        /// <summary>
        /// BackgroundWorker final message
        /// </summary>
        /// <param name="msg"></param>
        void CompleteMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        /// <summary>
        /// Find handle to TextBox based on index number
        /// </summary>
        /// <param name="idx">index of TextBoxes (0 to 80)</param>
        /// <returns>TextBox object on success, else null</returns>
        object findTextbox(int idx)
        {
            foreach (Control tempCtrl in this.Controls)
            {
                // Find the proper textBox based on idx "t0" to "t80"
                if (tempCtrl.Name == ("t" + idx.ToString()))
                    return tempCtrl;
            }
            MessageBox.Show("Could not find TextBox 't" + idx.ToString() +"'");
            return null;
        }

        /// <summary>
        /// Clear all calculated and entered values and associated arrays.
        /// </summary>
        void clearMenu()
        {
            System.Windows.Forms.TextBox tb;
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    ar[j, i] = 0;
                    init[j, i] = 0;
                    tb = (System.Windows.Forms.TextBox)findTextbox(i + j * 9);
                    tb.Text = "";
                    tb.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Clear all calculated values.
        /// </summary>
        void editInitial()
        {
            System.Windows.Forms.TextBox tb;
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    tb = (System.Windows.Forms.TextBox)findTextbox(i + j * 9);
                    tb.Enabled = true;
                    if (init[j, i] == 1)
                    {
                        tb.Text = "";
                        ar[j, i] = 0;
                        init[j, i] = 0;
                    }
                }
            }
            fillArray();
        }

        /// <summary>
        /// Check if value to insert already exists in row or column of ar[9,9]
        /// or in 3x3 sub-square where [row,column] places it.
        /// </summary>
        /// <param name="row">row in 9x9 array ar[,]</param>
        /// <param name="col">column in 9x9 array ar[,]</param>
        /// <param name="val">value (int) to check against</param>
        /// <returns>true if already exists</returns>
        bool isPresent(int row, int col, int val)
        {
            // check for row and column values in 9x9 array
            for(int i = 0; i < 9; i++)
            {
                if(ar[i, col] == val)
                    return true;
                if(ar[row,i] == val)
                    return true;
            }
            // check for repeating number in 3x3 sub-square
            int irow = (row / 3) * 3;   // lowest row in sub-square
            int icol = (col / 3) * 3;   // lowest column in sub-square
            for (int j = irow; j < irow + 3; j++)
            {
                for (int k = icol; k < icol + 3; k++)
                {
                    if (ar[j, k] == val)
                        return true;
                }
            }
            return false;
        }
    }
}