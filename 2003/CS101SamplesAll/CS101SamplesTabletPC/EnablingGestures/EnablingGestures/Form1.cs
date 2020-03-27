using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;

namespace EnablingGestures
{
    public partial class Form1 : Form
    {
        InkOverlay inkOverlay;
        //Tracks status of Dispose(bool)
        bool isDisposed;

        //Indices within checkedListBox1 of "special action" gestures
        int allGesturesIndex;
        int noGesturesIndex;

        public Form1()
        {
            InitializeComponent();

            //Add all the types of ApplicationGesture to the checkedListBox for possible selection
            checkedListBox1.Items.AddRange(Enum.GetNames(typeof(ApplicationGesture)));

            //Find the "AllGestures" and "NoGestures" items and store their indices for later special handling
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string gestureName = checkedListBox1.Items[i].ToString();
                if ( gestureName == "AllGestures")
                {
                    //Start with this one checked
                    checkedListBox1.SetItemChecked(i, true);
                    allGesturesIndex = i;
                }
                if (gestureName == "NoGesture")
                {
                    noGesturesIndex = i;
                }
            }

            //Flag for ItemCheck delegate: differentiate between user-initiated and program-initiated state change
            bool programmaticRecursionSoReturn = false;

            checkedListBox1.ItemCheck += delegate(object sender, ItemCheckEventArgs e)
            {
                //If event raised programmatically, it's just a UI, not behavioral, change, so return immediately
                if (programmaticRecursionSoReturn)
                {
                    return;
                }

                //Set recursion flag so programmatically raised events return quickly
                programmaticRecursionSoReturn = true;

                //Are we turning on or turning off the gesture?
                bool listening = e.NewValue == CheckState.Checked ? true : false;

                //Which gesture?
                string gestureName = checkedListBox1.Items[e.Index].ToString();
                ApplicationGesture gesture = (ApplicationGesture) Enum.Parse(typeof(ApplicationGesture), gestureName);

                //On the special values, clear all previously-selected gestures
                if (e.Index == allGesturesIndex || e.Index == noGesturesIndex)
                {
                    foreach (int checkedIndex in checkedListBox1.CheckedIndices)
                    {
                        //This will raise ItemCheck event, but programmaticRecursionSoReturn flag is set
                        checkedListBox1.SetItemCheckState(checkedIndex, CheckState.Unchecked);
                    }
                }
                else
                {
                    //Clear the special values. (Note: Programmatically raised ItemCheck event)
                    checkedListBox1.SetItemCheckState(allGesturesIndex, CheckState.Unchecked);
                    checkedListBox1.SetItemCheckState(noGesturesIndex, CheckState.Unchecked);
                }

                //Apply listening value to chosen gesture
                inkOverlay.SetGestureStatus(gesture, listening);

                //Clear recursion flag
                programmaticRecursionSoReturn = false;
            };

            //Set up ink-collecting object
            inkOverlay = new InkOverlay(panel1);
            inkOverlay.Enabled = true;
            //By default, CollectionMode is Ink. Final option is InkAndGesture. 
            inkOverlay.CollectionMode = CollectionMode.GestureOnly;
            //Since we checked this in the listbox, set the status correctly
            inkOverlay.SetGestureStatus(ApplicationGesture.AllGestures, true);

            //Gesture-handler: Note how often NoGesture has a higher confidence than sought-for gesture
            inkOverlay.Gesture += delegate(object sender, InkCollectorGestureEventArgs e)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Gesture candidate in e.Gestures)
                {
                    sb.AppendFormat("{0} : {1}\n", candidate.Id, candidate.Confidence);
                }
                label1.Text = sb.ToString();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear the ink and redraw the screen
            inkOverlay.Ink.DeleteStrokes();
            panel1.Invalidate();
        }

    }
}