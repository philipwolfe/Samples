//=============================================================
// C# OpenGL Framework
// Copyright (c) 2005-2006 devDept.com
// All rights reserved.
//
// For more information on this program, please visit: 
// http://www.csharpopenglframework.com
//
// For licensing information, please visit: 
// http://www.csharpopenglframework.com/licensing.html
//=============================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Globalization;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace openglFramework
{
    public partial class MainForm : Form
    {

        public MainForm()
        {

            // To set decimal separator as point
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            InitializeComponent();

            MinimumSize = Size;            
            
            #region Buttons status

            // Shading
            switch (openGLControl1.ShadingMode)
            {

                case OpenGLControl.shadingType.Wireframe:
                    wireframeButton.Checked = true;
                    break;

                case OpenGLControl.shadingType.Shaded:
                    shadedButton.Checked = true;
                    break;

                case OpenGLControl.shadingType.ShadedAndEdges:
                    edgesButton.Checked = true;
                    break;

                case OpenGLControl.shadingType.Orientation:
                    orientationButton.Checked = true;
                    break;

            }

            cullingButton.Checked = openGLControl1.BackFaceCulling;
            chordalErrorUpDown.Value = (decimal) openGLControl1.ChordalErr;

            // Projection
            switch (openGLControl1.ProjectionMode)
            {

                case OpenGLControl.projectionType.Parallel:
                    parallelButton.Checked = true;
                    perspectiveButton.Checked = false;
                    fieldOfViewUpDown.Enabled = false;
                    break;
                case OpenGLControl.projectionType.Perspective:
                    parallelButton.Checked = false;
                    perspectiveButton.Checked = true;
                    fieldOfViewUpDown.Enabled = true;
                    break;
            }

            fieldOfViewUpDown.Value = (int) openGLControl1.FieldOfView;

            oglfVersionStatusLabel.Text = ProductVersion;

            #endregion

            #region Jet drawing

            // from the book OpenGL SuperBible, Second Edition (2nd Edition) by Richard S. Wright Jr., Michael R. Sweet
            // <a href="http://www.amazon.com/exec/obidos/ASIN/1571691642/devdept-20"> CTRL + click to follow link

            // Nose Cone /////////////////////////////
            //openGLControl1.entities.Add(new TriangularFace(new float[] {  0, -60, 0},
            //                                                new float[] {-15, -30, 0},
            //                                                new float[] { 15, -30, 0 }, Color.DarkGray));
            openGLControl1.entities.Add(new TriangularFace(new float[] { +15.0f, -30.0f,  0.0f },
                                                            new float[] {  0.0f, -30.0f, 15.0f },
                                                            new float[] {  0.0f, -60.0f,  0.0f }, Color.Cyan));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 0.0f, -60.0f, 0.0f },
                                                            new float[] {  0.0f, -30.0f, 15.0f },
                                                            new float[] {-15.0f, -30.0f,  0.0f }, Color.Cyan));

            // Body of the plane ////////////////////////
            openGLControl1.entities.Add(new TriangularFace(new float[] { -15.0f, -30.0f, 0.0f },
                                                            new float[] { 0.0f, -30.0f, 15.0f },
                                                            new float[] { 0.0f, +56.0f, 0.0f }, Color.FromArgb(148,148,148)));
            //openGLControl1.entities.Add(new TriangularFace(new float[] { 0.0f, +56.0f, 0.0f },
            //                                                new float[] { 0.0f, -30.0f, 15.0f },
            //                                                new float[] { 15.0f, -30.0f, 0.0f }, Color.DarkGray));
            //openGLControl1.entities.Add(new TriangularFace(new float[] { 15.0f, -30.0f, 0.0f },
            //                                                new float[] { -15.0f, -30.0f, 0.0f },
            //                                                new float[] { 0.0f, +56.0f, 0.0f }, Color.DarkGray));
         
            TriangularFace triangle = new TriangularFace(
                                                new float[] { 0.0f, +56.0f, 0.0f },
                                                new float[] { 0.0f, -30.0f, 15.0f },
                                                new float[] { 15.0f, -30.0f, 0.0f }, Color.FromArgb(148, 148, 148));

            openGLControl1.entities.Add(triangle);
            
           
            // plane belly
            QuadFace quad = new QuadFace(
                                                     new float[] { 0.0f, +56.0f, 0.0f },
                                                     new float[] { +15.0f, -30.0f, 0.0f },
                                                     new float[] { 0.0f, -60.0f, 0.0f },
                                                     new float[] { -15.0f, -30.0f, 0.0f }, Color.FromArgb(148, 148, 148));

            openGLControl1.entities.Add(quad);

                     
            /// Wings //////////////////////////////////
            openGLControl1.entities.Add(new TriangularFace(new float[] { 0.0f, -27.0f, 2.0f },
                                                             new float[] { -60.0f, +8.0f, 2.0f },
                                                             new float[] { 60.0f, +8.0f, 2.0f }, Color.CornflowerBlue));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 60.0f, +8.0f, 2.0f },
                                                            new float[] { 0.0f, +8.0f, 7.0f },
                                                            new float[] { 0.0f, -27.0f, 2.0f }, Color.CornflowerBlue));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 60.0f, +8.0f, 2.0f },
                                                            new float[] { -60.0f, +8.0f, 2.0f },
                                                            new float[] { 0.0f, +8.0f, 7.0f }, Color.CornflowerBlue));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 0.0f, -27.0f, 2.0f },
                                                             new float[] { 0.0f, +8.0f, 7.0f },
                                                             new float[] { -60.0f, +8.0f, 2.0f }, Color.CornflowerBlue));


            // Tail section ///////////////////////////////
            openGLControl1.entities.Add(new TriangularFace(new float[] { -30.0f, +57.0f, -0.50f },
                                                           new float[] { 30.0f, +57.0f, -0.50f},
                                                           new float[] { 0.0f, +40.0f, -0.50f }, Color.Crimson));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 0.0f, +40.0f, -0.5f },
                                                            new float[] { 30.0f, +57.0f, -0.5f },
                                                            new float[] { 0.0f, +57.0f, 4.0f }, Color.Crimson));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 0.0f, +57.0f, 4.0f },
                                                            new float[] { -30.0f, +57.0f, -0.5f },
                                                            new float[] { 0.0f, +40.0f, -0.5f }, Color.Crimson));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 30.0f, +57.0f, -0.5f },
                                                            new float[] { -30.0f, +57.0f, -0.5f },
                                                            new float[] { 0.0f, +57.0f, 4.0f }, Color.Crimson));

            /// Vertical Tail section ////////////////
            openGLControl1.entities.Add(new TriangularFace(new float[] { 0.0f, +40.0f, 0.5f },
                                                            new float[] { 3.0f, +57.0f, 0.5f },
                                                            new float[] { 0.0f, +65.0f, 25.0f }, Color.Chartreuse));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 0.0f, +65.0f, 25.0f },
                                                             new float[] { -3.0f, +57.0f, 0.5f },
                                                             new float[] { 0.0f, +40.0f, 0.5f }, Color.Chartreuse));
            openGLControl1.entities.Add(new TriangularFace(new float[] { 3.0f, +57.0f, 0.5f },
                                                             new float[] { -3.0f, +57.0f, 0.5f },
                                                             new float[] { 0.0f, +65.0f, 25.0f }, Color.Chartreuse));

            // Line
            openGLControl1.entities.Add(new RichLine(new float[] { -22, 0, -5 },
                                     new float[] { 22, 0, -5 }, Color.White, 1, 0xf5ff));

            // Points
            openGLControl1.entities.Add(new Point(-60, +12, 2, Color.Black));
            openGLControl1.entities.Add(new Point(-60, +16, 2, Color.Black));
            openGLControl1.entities.Add(new Point(-60, +21, 2, Color.Black));
            openGLControl1.entities.Add(new Point(-60, +27, 2, Color.Black));
            openGLControl1.entities.Add(new Point(-60, +34, 2, Color.Black));

            //Wheel Crosses
            openGLControl1.entities.Add(new Line(new float[] { -20, 0, -6 }, new float[] { -20, 0, -4 }, Color.Black));
            openGLControl1.entities.Add(new Line(new float[] { -20, -1, -5 }, new float[] { -20, +1, -5 }, Color.Black));
            openGLControl1.entities.Add(new Line(new float[] { +20, 0, -6 }, new float[] { +20, 0, -4 }, Color.Black));
            openGLControl1.entities.Add(new Line(new float[] { +20, -1, -5 }, new float[] { +20, +1, -5 }, Color.Black));
            openGLControl1.entities.Add(new Line(new float[] { 0, -41, -6 }, new float[] { 0, -43, -6 }, Color.Black));
            openGLControl1.entities.Add(new Line(new float[] { 0, -42, -7 }, new float[] { 0, -42, -5 }, Color.Black));

            #endregion

            #region Labels

            openGLControl1.labels.Add(new LeaderLabel(+60.0f, +8.0f, 2.0f, "Left wing", 30));
            openGLControl1.labels.Add(new LeaderLabel(0.0f, +65.0f, 25.0f, "Tail", 30));

            #endregion


            versionTextBox.Text = OpenGL.gl.GetString(OpenGL.gl.VERSION);
            rendererTextBox.Text = OpenGL.gl.GetString(OpenGL.gl.RENDERER);
            vendorTextBox.Text = OpenGL.gl.GetString(OpenGL.gl.VENDOR);

        }

        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {

            openGLControl1.MakeRenderingContextCurrent();
            openGLControl1.DrawScene(1.0f);

            fpsStatusLabel.Text = openGLControl1.Fps + " fps";

        }

        #region Shading

        private void wireframeButton_Click(object sender, EventArgs e)
        {

            wireframeButton.Checked = true;

            openGLControl1.ShadingMode = OpenGLControl.shadingType.Wireframe;

            shadedButton.Checked = false;
            edgesButton.Checked = false;
            orientationButton.Checked = false;

        }

        private void shadedButton_Click(object sender, EventArgs e)
        {

            shadedButton.Checked = true;
    
            openGLControl1.ShadingMode = OpenGLControl.shadingType.Shaded;

            wireframeButton.Checked = false;
            edgesButton.Checked = false;
            orientationButton.Checked = false;
        
        }

        private void edgesButton_Click(object sender, EventArgs e)
        {
            edgesButton.Checked = true;
        
            openGLControl1.ShadingMode = OpenGLControl.shadingType.ShadedAndEdges;

            wireframeButton.Checked = false;
            shadedButton.Checked = false;
            orientationButton.Checked = false;
       
        }

        private void orientationButton_Click(object sender, EventArgs e)
        {

            orientationButton.Checked = true;

            openGLControl1.ShadingMode = OpenGLControl.shadingType.Orientation;

            wireframeButton.Checked = false;
            shadedButton.Checked = false;
            edgesButton.Checked = false;

        }

        private void cullingButton_CheckedChanged(object sender, EventArgs e)
        {

            openGLControl1.BackFaceCulling = cullingButton.Checked;

        }

        private void chordalErrorUpDown_ValueChanged(object sender, EventArgs e)
        {
            openGLControl1.ChordalErr = (float) chordalErrorUpDown.Value;
        }

        #endregion

        #region Zoom/Pan/Rotate

        private void zoomButton_Click(object sender, EventArgs e)
        {

//            zoomButton.Checked = false;
            openGLControl1.ZoomButtonDown = zoomButton.Checked;
            panButton.Checked = false;
            openGLControl1.PanButtonDown = panButton.Checked;
            rotateButton.Checked = false;
            openGLControl1.RotateButtonDown = rotateButton.Checked;



            openGLControl1.SetZoomCursor();
        }

        private void panButton_Click(object sender, EventArgs e)
        {
            
            zoomButton.Checked = false;
            openGLControl1.ZoomButtonDown = zoomButton.Checked;
     //       panButton.Checked = false;
            openGLControl1.PanButtonDown = panButton.Checked;
            rotateButton.Checked = false;
            openGLControl1.RotateButtonDown = rotateButton.Checked;


            openGLControl1.SetPanCursor();

        }

        private void rotateButton_Click(object sender, EventArgs e)
        {

            zoomButton.Checked = false;
            openGLControl1.ZoomButtonDown = zoomButton.Checked;
            panButton.Checked = false;
            openGLControl1.PanButtonDown = panButton.Checked;
  //          rotateButton.Checked = false;
            openGLControl1.RotateButtonDown = rotateButton.Checked;


            openGLControl1.SetRotateCursor();
        }

        #endregion

        #region Projection

        private void parallelButton_Click(object sender, EventArgs e)
        {

            parallelButton.Checked = true;

            openGLControl1.ProjectionMode = openglFramework.OpenGLControl.projectionType.Parallel;

            perspectiveButton.Checked = false;
            fieldOfViewUpDown.Enabled = false;


        }

        private void perspectiveButton_Click(object sender, EventArgs e)
        {

            perspectiveButton.Checked = true;

            openGLControl1.ProjectionMode = openglFramework.OpenGLControl.projectionType.Perspective;

            parallelButton.Checked = false;
            fieldOfViewUpDown.Enabled = true;
        }

        private void fieldOfView_ValueChanged(object sender, EventArgs e)
        {

            openGLControl1.FieldOfView = (int) fieldOfViewUpDown.Value;

        }

        #endregion

        #region File Open / Save

        private void openButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog myOpenFileDialog = new OpenFileDialog();

            myOpenFileDialog.InitialDirectory = ".";
            myOpenFileDialog.Filter = "Design files (*.design)|*.design|All files (*.*)|*.*";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.RestoreDirectory = true;

            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)

                OpenFile(myOpenFileDialog.FileName);


        }

        void OpenFile(string name)
        {

            FileInfo f = new FileInfo(name);

            Stream myStream = f.OpenRead();

            if (myStream != null)
            {

                StatusText("Loading...");
                Cursor = Cursors.WaitCursor;

                BinaryFormatter myBinaryFormat = new BinaryFormatter();
                try
                {

                    openGLControl1.entities = (ArrayList) myBinaryFormat.Deserialize(myStream);

                    myStream.Close();

                    openGLControl1.Invalidate();

                    StatusText("");
                    Cursor = Cursors.Arrow;
                }
                catch (Exception e)
                {
                    StatusText(e.GetType().Name);
                }
                finally
                {
                    myStream.Close();
                    Cursor = Cursors.Arrow;
                }

            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {

            SaveFileDialog mySaveFileDialog = new SaveFileDialog();

            mySaveFileDialog.InitialDirectory = ".";
            mySaveFileDialog.Filter = "Design files (*.design)|*.design|All files (*.*)|*.*";
            mySaveFileDialog.FilterIndex = 1;
            mySaveFileDialog.RestoreDirectory = true;
            mySaveFileDialog.FileName = "";

            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
            {

                Stream myStream = null;

                StatusText("Saving...");
                Cursor = Cursors.WaitCursor;

                if ((myStream = mySaveFileDialog.OpenFile()) != null)
                {

                    BinaryFormatter myBinaryFormat = new BinaryFormatter();
                    try
                    {

                        myBinaryFormat.Serialize(myStream, openGLControl1.entities);

                        myStream.Close();

                        StatusText("");
                        Cursor = Cursors.Arrow;

                    }
                    catch (Exception e)
                    {
                        StatusText(e.GetType().Name);
                    }
                    finally
                    {
                        myStream.Close();
                        Cursor = Cursors.Arrow;
                    }




                }

            }
        }

        #endregion

        public void StatusText(string str)
        {

            this.mainStatusLabel.Text = str;

        }

        private void sourceCodeButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.csharpopenglframework.com");
        }

    }

}