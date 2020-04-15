//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

public class frmMain : System.Windows.Forms.Form 
{
#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    public frmMain() 
{
        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.
        AssemblyInfo ainfo = new AssemblyInfo();
        this.Text = ainfo.Title;
        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
    }

    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing) 
	{
        if (disposing) {
            if (components != null) {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    private System.Windows.Forms.MainMenu mnuMain;

    private System.Windows.Forms.MenuItem mnuFile;

    private System.Windows.Forms.MenuItem mnuExit;

    private System.Windows.Forms.MenuItem mnuHelp;

    private System.Windows.Forms.MenuItem mnuAbout;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.RadioButton optWink;

    private System.Windows.Forms.RadioButton optBall;

    private System.Windows.Forms.Timer tmrAnimation;

    private System.Windows.Forms.RadioButton optText;

    private void InitializeComponent() {

        this.components = new System.ComponentModel.Container();

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.tmrAnimation = new System.Windows.Forms.Timer(this.components);

        this.Label1 = new System.Windows.Forms.Label();

        this.optWink = new System.Windows.Forms.RadioButton();

        this.optBall = new System.Windows.Forms.RadioButton();

        this.optText = new System.Windows.Forms.RadioButton();

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

        this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

        //

        //mnuFile

        //

        this.mnuFile.Enabled = (bool) resources.GetObject("mnuFile.Enabled");

        this.mnuFile.Index = 0;

        this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.mnuFile.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuFile.Shortcut");

        this.mnuFile.ShowShortcut = (bool) resources.GetObject("mnuFile.ShowShortcut");

        this.mnuFile.Text = resources.GetString("mnuFile.Text");

        this.mnuFile.Visible = (bool) resources.GetObject("mnuFile.Visible");

        //

        //mnuExit

        //

        this.mnuExit.Enabled = (bool) resources.GetObject("mnuExit.Enabled");

        this.mnuExit.Index = 0;

        this.mnuExit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuExit.Shortcut");

        this.mnuExit.ShowShortcut = (bool) resources.GetObject("mnuExit.ShowShortcut");

        this.mnuExit.Text = resources.GetString("mnuExit.Text");

        this.mnuExit.Visible = (bool) resources.GetObject("mnuExit.Visible");

		this.mnuExit.Click += new EventHandler(mnuExit_Click);

        //

        //mnuHelp

        //

        this.mnuHelp.Enabled = (bool) resources.GetObject("mnuHelp.Enabled");

        this.mnuHelp.Index = 1;

        this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.mnuHelp.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuHelp.Shortcut");

        this.mnuHelp.ShowShortcut = (bool) resources.GetObject("mnuHelp.ShowShortcut");

        this.mnuHelp.Text = resources.GetString("mnuHelp.Text");

        this.mnuHelp.Visible = (bool) resources.GetObject("mnuHelp.Visible");

        //

        //mnuAbout

        //

        this.mnuAbout.Enabled = (bool) resources.GetObject("mnuAbout.Enabled");

        this.mnuAbout.Index = 0;

        this.mnuAbout.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuAbout.Shortcut");

        this.mnuAbout.ShowShortcut = (bool) resources.GetObject("mnuAbout.ShowShortcut");

        this.mnuAbout.Text = resources.GetString("mnuAbout.Text");

        this.mnuAbout.Visible = (bool) resources.GetObject("mnuAbout.Visible");

		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);

        //

        //tmrAnimation

        //

        this.tmrAnimation.Enabled = true;
		this.tmrAnimation.Tick += new EventHandler(TimerOnTick);

        //

        //Label1

        //

        this.Label1.AccessibleDescription = (string) resources.GetObject("Label1.AccessibleDescription");

        this.Label1.AccessibleName = (string) resources.GetObject("Label1.AccessibleName");

        this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label1.Anchor");

        this.Label1.AutoSize = (bool) resources.GetObject("Label1.AutoSize");

        this.Label1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label1.Dock");

        this.Label1.Enabled = (bool) resources.GetObject("Label1.Enabled");

        this.Label1.Font = (System.Drawing.Font) resources.GetObject("Label1.Font");

        this.Label1.Image = (System.Drawing.Image) resources.GetObject("Label1.Image");

        this.Label1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label1.ImageAlign");

        this.Label1.ImageIndex = (int) resources.GetObject("Label1.ImageIndex");

        this.Label1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label1.ImeMode");

        this.Label1.Location = (System.Drawing.Point) resources.GetObject("Label1.Location");

        this.Label1.Name = "Label1";

        this.Label1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label1.RightToLeft");

        this.Label1.Size = (System.Drawing.Size) resources.GetObject("Label1.Size");

        this.Label1.TabIndex = (int) resources.GetObject("Label1.TabIndex");

        this.Label1.Text = resources.GetString("Label1.Text");

        this.Label1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label1.TextAlign");

        this.Label1.Visible = (bool) resources.GetObject("Label1.Visible");

        //

        //optWink

        //

        this.optWink.AccessibleDescription = resources.GetString("optWink.AccessibleDescription");

        this.optWink.AccessibleName = resources.GetString("optWink.AccessibleName");

        this.optWink.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optWink.Anchor");

        this.optWink.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optWink.Appearance");

        this.optWink.BackgroundImage = (System.Drawing.Image) resources.GetObject("optWink.BackgroundImage");

        this.optWink.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWink.CheckAlign");

        this.optWink.Checked = true;

        this.optWink.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optWink.Dock");

        this.optWink.Enabled = (bool) resources.GetObject("optWink.Enabled");

        this.optWink.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optWink.FlatStyle");

        this.optWink.Font = (System.Drawing.Font) resources.GetObject("optWink.Font");

        this.optWink.Image = (System.Drawing.Image) resources.GetObject("optWink.Image");

        this.optWink.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWink.ImageAlign");

        this.optWink.ImageIndex = (int) resources.GetObject("optWink.ImageIndex");

        this.optWink.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optWink.ImeMode");

        this.optWink.Location = (System.Drawing.Point) resources.GetObject("optWink.Location");

        this.optWink.Name = "optWink";

        this.optWink.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optWink.RightToLeft");

        this.optWink.Size = (System.Drawing.Size) resources.GetObject("optWink.Size");

        this.optWink.TabIndex = (int) resources.GetObject("optWink.TabIndex");

        this.optWink.TabStop = true;

        this.optWink.Text = resources.GetString("optWink.Text");

        this.optWink.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWink.TextAlign");

        this.optWink.Visible = (bool) resources.GetObject("optWink.Visible");

		this.optWink.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);

        //

        //optBall

        //

        this.optBall.AccessibleDescription = resources.GetString("optBall.AccessibleDescription");

        this.optBall.AccessibleName = resources.GetString("optBall.AccessibleName");

        this.optBall.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optBall.Anchor");

        this.optBall.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optBall.Appearance");

        this.optBall.BackgroundImage = (System.Drawing.Image) resources.GetObject("optBall.BackgroundImage");

        this.optBall.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optBall.CheckAlign");

        this.optBall.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optBall.Dock");

        this.optBall.Enabled = (bool) resources.GetObject("optBall.Enabled");

        this.optBall.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optBall.FlatStyle");

        this.optBall.Font = (System.Drawing.Font) resources.GetObject("optBall.Font");

        this.optBall.Image = (System.Drawing.Image) resources.GetObject("optBall.Image");

        this.optBall.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optBall.ImageAlign");

        this.optBall.ImageIndex = (int) resources.GetObject("optBall.ImageIndex");

        this.optBall.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optBall.ImeMode");

        this.optBall.Location = (System.Drawing.Point) resources.GetObject("optBall.Location");

        this.optBall.Name = "optBall";

        this.optBall.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optBall.RightToLeft");

        this.optBall.Size = (System.Drawing.Size) resources.GetObject("optBall.Size");

        this.optBall.TabIndex = (int) resources.GetObject("optBall.TabIndex");

        this.optBall.Text = resources.GetString("optBall.Text");

        this.optBall.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optBall.TextAlign");

        this.optBall.Visible = (bool) resources.GetObject("optBall.Visible");

		this.optBall.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);

        //

        //optText

        //

        this.optText.AccessibleDescription = resources.GetString("optText.AccessibleDescription");

        this.optText.AccessibleName = resources.GetString("optText.AccessibleName");

        this.optText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optText.Anchor");

        this.optText.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optText.Appearance");

        this.optText.BackgroundImage = (System.Drawing.Image) resources.GetObject("optText.BackgroundImage");

        this.optText.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optText.CheckAlign");

        this.optText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optText.Dock");

        this.optText.Enabled = (bool) resources.GetObject("optText.Enabled");

        this.optText.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optText.FlatStyle");

        this.optText.Font = (System.Drawing.Font) resources.GetObject("optText.Font");

        this.optText.Image = (System.Drawing.Image) resources.GetObject("optText.Image");

        this.optText.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optText.ImageAlign");

        this.optText.ImageIndex = (int) resources.GetObject("optText.ImageIndex");

        this.optText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optText.ImeMode");

        this.optText.Location = (System.Drawing.Point) resources.GetObject("optText.Location");

        this.optText.Name = "optText";

        this.optText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optText.RightToLeft");

        this.optText.Size = (System.Drawing.Size) resources.GetObject("optText.Size");

        this.optText.TabIndex = (int) resources.GetObject("optText.TabIndex");

        this.optText.Text = resources.GetString("optText.Text");

        this.optText.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optText.TextAlign");

        this.optText.Visible = (bool) resources.GetObject("optText.Visible");


        //

        //frmMain

        //

        this.AccessibleDescription = (string) resources.GetObject("$this.AccessibleDescription");

        this.AccessibleName = (string) resources.GetObject("$this.AccessibleName");

        this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

        this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

        this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

        this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

        this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

        this.BackColor = System.Drawing.SystemColors.Window;

        this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

        this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.optText, this.optBall, this.optWink, this.Label1});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximizeBox = false;

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.Menu = this.mnuMain;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmMain";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.ResumeLayout(false);
		
		this.Load += new EventHandler(frmMain_Load);

    }

#endregion

#region " Standard Menu Code "

    // This code simply shows the About form.
    private void mnuAbout_Click(object sender, System.EventArgs e) {
        // Open the About form in Dialog Mode
        frmAbout frm = new frmAbout();
        frm.ShowDialog(this);
        frm.Dispose();
    }

    // This code will close the form.
    private void mnuExit_Click(object sender, System.EventArgs e) {
        // Close the current form
        this.Close();
    }

#endregion

    const int WINK_TIMER_INTERVAL  = 150;  //' In milliseconds
    protected Image[] arrImages = new Image[4];
    protected int intCurrentImage = 0;
    protected int j = 1;
    const int BALL_TIMER_INTERVAL  = 25;  //' In milliseconds;
    private int intBallSize  = 16; //' fraction of client area;
    private int intMoveSize  = 4; //' fraction of ball size;
    private Bitmap bitmap;
    private int intBallPositionX, intBallPositionY ;
    private int intBallRadiusX, intBallRadiusY, intBallMoveX, intBallMoveY,
        intBallBitmapWidth, intBallBitmapHeight;
    private int intBitmapWidthMargin, intBitmapHeightMargin ;
    const int TEXT_TIMER_INTERVAL = 15;  //' In milliseconds;
    protected int intCurrentGradientShift = 10;
    protected int intGradiantStep = 5;

    // This subroutine handles the Load event for the Form.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        // Fills the image array for the Winking Eye example.
		int i;
		for (i=0;i<=3;i++)
		{
			string sFileName =  "..\\..\\Eye" + (i + 1).ToString() + ".png";
		
			arrImages[i]= new Bitmap(sFileName);	
		}
    }

    // This subroutine handles the CheckChanged event for the radio buttons.
    private void RadioButtons_CheckedChanged(object sender, System.EventArgs e) //optWink.CheckedChanged, optBall.CheckedChanged;
	{
        if (optWink.Checked)
		{
            tmrAnimation.Interval = WINK_TIMER_INTERVAL;
        } 
		else if (optBall.Checked) 
		{
            tmrAnimation.Interval = BALL_TIMER_INTERVAL;
        } 
		else if (optText.Checked)
		{
            tmrAnimation.Interval = TEXT_TIMER_INTERVAL;
        }
        OnResize(EventArgs.Empty);
    }

    // This subroutine handles the Tick event for the Timer. 
    // This is where the animation takes place.
    protected void TimerOnTick(object obj ,EventArgs ea ) 
	{
        if (optWink.Checked)
		{
            // Obtain the Graphics object exposed by the Form.
            Graphics grfx  = CreateGraphics();
            // Call DrawImage, using Overload #8, which takes the current image to be
            // displayed, the X and Y coordinates (which, in this case centers the 
            // image in the client area), and the image's width and height.
            grfx.DrawImage(arrImages[intCurrentImage],
                Convert.ToInt32((ClientSize.Width - arrImages[intCurrentImage].Width) / 2), 
                Convert.ToInt32((ClientSize.Height - arrImages[intCurrentImage].Height) / 2), 
                arrImages[intCurrentImage].Width, arrImages[intCurrentImage].Height);
            // It is always a good idea to call Dispose for objects that expose this
            // method instead of waiting for the Garbage Collector to do it for you.
            // This almost always increases the application's performance.
            grfx.Dispose();
            // Loop through the images.
            intCurrentImage += j;

            if (intCurrentImage == 3) 
			{
                // This is the last image of the four, so reverse the animation
                // order so that the eye closes.
                j = -1;
            } 
			else if (intCurrentImage == 0)
			{
                // This is the first image of the four, so reverse the animation
                // order so that the eye opens again.
                j = 1;
            }
        } 
		else if ( optBall.Checked)
		{
            // Obtain the Graphics object exposed by the Form.
            Graphics grfx = CreateGraphics();
            // Draw the bitmap containing the ball on the Form.
            grfx.DrawImage(bitmap, Convert.ToInt32(intBallPositionX - intBallBitmapWidth / 2),
                Convert.ToInt32(intBallPositionY - intBallBitmapHeight / 2),
                intBallBitmapWidth, intBallBitmapHeight);
            grfx.Dispose();
            // Increment the ball position by the distance it has
            // moved in both X and Y after being redrawn.
            intBallPositionX += intBallMoveX;
            intBallPositionY += intBallMoveY;
            // Reverse the ball's direction when it hits a boundary.

            if ((intBallPositionX + intBallRadiusX >= ClientSize.Width )
                || (intBallPositionX - intBallRadiusX <= 0))
			{
                intBallMoveX = -intBallMoveX;
                Microsoft.VisualBasic.Interaction.Beep();
            }
            // Set the Y boundary at 40 instead of 0 so the ball does not bounce
            // into controls on the Form.

            if ((intBallPositionY + intBallRadiusY >= ClientSize.Height)
                || (intBallPositionY - intBallRadiusY <= 40))
			{
                intBallMoveY = -intBallMoveY;
                Microsoft.VisualBasic.Interaction.Beep();
            }
        }
		else if ( optText.Checked)
		{
            // Obtain the Graphics object exposed by the Form.
            Graphics grfx = CreateGraphics();
            // Set the font type, text, and determine its size.

            Font font = new Font("Microsoft Sans Serif", 96, 
                FontStyle.Bold, GraphicsUnit.Point);

            string strText  = "GDI+!";
            SizeF sizfText = new SizeF(grfx.MeasureString(strText, font));

            // Set the point at which the text will be drawn: centered
            // in the client area.

            PointF ptfTextStart = new PointF(Convert.ToSingle(ClientSize.Width - sizfText.Width) / 2,
                Convert.ToSingle(ClientSize.Height - sizfText.Height) / 2);

            // Set the gradient start and end point, the latter being adjusted
            // by a changing value to give the animation affect.
            PointF ptfGradientStart = new PointF(0, 0);
            PointF ptfGradientEnd = new PointF(intCurrentGradientShift, 200);
            // Instantiate the brush used for drawing the text.
            LinearGradientBrush grBrush = new LinearGradientBrush(ptfGradientStart,
                ptfGradientEnd, Color.Blue, BackColor);
            // Draw the text centered on the client area.
            grfx.DrawString(strText, font, grBrush, ptfTextStart);
            grfx.Dispose();
            // Shift the gradient, reversing it when it gets to a certain value.
            intCurrentGradientShift += intGradiantStep;

            if (intCurrentGradientShift == 500)
			{
                intGradiantStep = -5;
            } 
			else if ( intCurrentGradientShift == -50) 
			{
                intGradiantStep = 5;
            }
        }
    }

    // This method overrides the OnResize method in the base Control class. OnResize 
    // raises the Resize event, which occurs when the control (in this case, the 
    // Form) is resized.
    protected override void OnResize(EventArgs ea)
	{
        if (optWink.Checked)
		{
            // Obtain the Graphics object exposed by the Form and erase any drawings.
            Graphics grfx  = CreateGraphics();
            // You could also call grfx.Clear(BackColor) or this.Invalidate() to clear
            // off the screen.
            this.Refresh();
            grfx.Dispose();
        } 
		else if (optBall.Checked) 
		{
            // Obtain the Graphics object exposed by the Form and erase any drawings.
            Graphics grfx  = CreateGraphics();
            grfx.Clear(BackColor);
            // Set the radius of the ball to a fraction of the width or height
            // of the client area, whichever is less.
            double dblRadius  = Math.Min(ClientSize.Width / grfx.DpiX,
                ClientSize.Height / grfx.DpiY) / intBallSize;

            // Set the width and height of the ball in most cases the DPI is
            // identical in the X and Y axes.
            intBallRadiusX = Convert.ToInt32(dblRadius * grfx.DpiX);
            intBallRadiusY = Convert.ToInt32(dblRadius * grfx.DpiY);
            grfx.Dispose();

            // Set the distance the ball moves to 1 pixel or a fraction of the
            // ball's size, whichever is greater. This means that the distance the 
            // ball moves each time it is drawn is proportional to its size, which 
            // is, in turn, proportional to the size of the client area. Thus, when 
            // the client area is shrunk the ball slows down, and when it is 
            // increased, the ball speeds up. 
            intBallMoveX = Convert.ToInt32(Math.Max(1, intBallRadiusX / intMoveSize));
            intBallMoveY = Convert.ToInt32(Math.Max(1, intBallRadiusY / intMoveSize));

            // Notice that the value of the ball's movement also serves the
            // margin around the ball, which determines the size of the actual 
            // bitmap on which the ball is drawn. Thus, the distance the ball moves 
            // is exactly equal to the size of the bitmap, which permits the previous 
            // image of the ball to be erased before the next image is drawn, all 
            // without an inordinate amount of flickering.
            intBitmapWidthMargin = intBallMoveX;
            intBitmapHeightMargin = intBallMoveY;
            // Determine the actual size of the Bitmap on which the ball is drawn by
            // adding the margins to the ball's dimensions.
            intBallBitmapWidth = 2 * (intBallRadiusX + intBitmapWidthMargin);
            intBallBitmapHeight = 2 * (intBallRadiusY + intBitmapHeightMargin);
            // Create a new bitmap, passing in the width and height
            bitmap = new Bitmap(intBallBitmapWidth, intBallBitmapHeight);
            // Obtain the Graphics object exposed by the Bitmap, clear the existing 
            // ball, and draw the new ball.
            grfx = Graphics.FromImage(bitmap);
            grfx.Clear(BackColor);
            grfx.FillEllipse(Brushes.Red, new Rectangle(intBallMoveX,
                    intBallMoveY, 2 * intBallRadiusX, 2 * intBallRadiusY));
            grfx.Dispose();
            // Reset the ball's position to the center of the client area.
            intBallPositionX = Convert.ToInt32(ClientSize.Width / 2);
            intBallPositionY = Convert.ToInt32(ClientSize.Height / 2);

        } 
		else if (optText.Checked) 
		{
            // Obtain the Graphics object exposed by the Form and erase any drawings.
            Graphics grfx  = CreateGraphics();
            grfx.Clear(BackColor);
        }
    }
}

