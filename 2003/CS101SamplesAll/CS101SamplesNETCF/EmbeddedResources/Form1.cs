using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

// Embedded Resources
// Resources such as bitmaps can be 'Embedded' and compiled into the assembly.  Simply
// addd the desired resource, in this case a .bmp file to the project and then set the
// Build Action property of the file to 'Embedded Resource'

namespace EmbeddedResources
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Load Images into the thumbnail size PictureBoxes
            GetThumbImages();

            // Set Form to close instead of minimize
            MinimizeBox = false;
        }

        // Load the 4 embedded images from the assembly into the thumbnail picture boxes
        private void GetThumbImages()
        {
            System.IO.Stream stream;
            Bitmap bmp;

            // Get Assembly
            Assembly asm = Assembly.GetExecutingAssembly();

            // Get images as a stream from the Assembly
            // Thumb1
            stream = asm.GetManifestResourceStream("EmbeddedResources.Gone Fishing.bmp");
            bmp = new Bitmap(stream);
            Thumb1PictureBox.Image = bmp;

            // Thumb2
            stream = asm.GetManifestResourceStream("EmbeddedResources.Coffee Bean.bmp");
            bmp = new Bitmap(stream);
            Thumb2PictureBox.Image = bmp;

            // Thumb3
            stream = asm.GetManifestResourceStream("EmbeddedResources.River Sumida.bmp");
            bmp = new Bitmap(stream);
            Thumb3PictureBox.Image = bmp;

            // Thumb4
            stream = asm.GetManifestResourceStream("EmbeddedResources.Santa Fe Stucco.bmp");
            bmp = new Bitmap(stream);
            Thumb4PictureBox.Image = bmp;
        }

        // Get image compiled as an embedded resource for the form background.
        protected override void OnPaint(PaintEventArgs e)
        {  
            // Get Assembly
            Assembly asm = Assembly.GetExecutingAssembly();

            // Get image as a stream from the Assembly
            System.IO.Stream stream = asm.GetManifestResourceStream("EmbeddedResources.Greenstone.bmp");

            // Save Stream to a bitmap
            Bitmap backGroundImage = new Bitmap(stream);

            // Set the drawing rectangle
            Rectangle rect = new Rectangle(0, 0, backGroundImage.Width, backGroundImage.Height);

            // Draw the Imagee
            e.Graphics.DrawImage(backGroundImage, this.ClientRectangle, rect, GraphicsUnit.Pixel);
        }

        private void Thumb1PictureBox_Click(object sender, EventArgs e)
        {
            // Set the MainPicture Image to the clicked Thumb Image
            MainPictureBox.Image = Thumb1PictureBox.Image;
        }

        private void Thumb2PictureBox_Click(object sender, EventArgs e)
        {
            // Set the MainPicture Image to the clicked Thumb Image
            MainPictureBox.Image = Thumb2PictureBox.Image;
        }

        private void Thumb3PictureBox_Click(object sender, EventArgs e)
        {
            // Set the MainPicture Image to the clicked Thumb Image
            MainPictureBox.Image = Thumb3PictureBox.Image;
        }

        private void Thumb4PictureBox_Click(object sender, EventArgs e)
        {
            // Set the MainPicture Image to the clicked Thumb Image
            MainPictureBox.Image = Thumb4PictureBox.Image;
        }
       
    }
}