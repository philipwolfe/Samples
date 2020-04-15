using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

public class frmGraphics : System.Windows.Forms.Form
{
    private int drawX;
    private int drawY;

#region " Windows Form Designer generated code "

    public frmGraphics() 
	{
        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
    }
    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing) {
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
    private System.Windows.Forms.MainMenu MainMenu1;

    private System.Windows.Forms.MenuItem MenuItem1;

    private System.Windows.Forms.MenuItem miDrawLine;

    private System.Windows.Forms.MenuItem miDrawCircle;

    private System.Windows.Forms.MenuItem miDrawRectangle;

    private System.Windows.Forms.MenuItem miDrawText;

    private System.Windows.Forms.MenuItem miDrawFancyText;

    private System.Windows.Forms.PictureBox picDrawing;

    private void InitializeComponent() {

        this.MainMenu1 = new System.Windows.Forms.MainMenu();

        this.MenuItem1 = new System.Windows.Forms.MenuItem();

        this.miDrawLine = new System.Windows.Forms.MenuItem();

        this.miDrawCircle = new System.Windows.Forms.MenuItem();

        this.miDrawRectangle = new System.Windows.Forms.MenuItem();

        this.miDrawText = new System.Windows.Forms.MenuItem();

        this.miDrawFancyText = new System.Windows.Forms.MenuItem();

        this.picDrawing = new System.Windows.Forms.PictureBox();

        this.SuspendLayout();

        //

        //MainMenu1

        //

        this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuItem1});

        //

        //MenuItem1

        //

        this.MenuItem1.Index = 0;

        this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.miDrawLine, this.miDrawCircle, this.miDrawRectangle, this.miDrawText, this.miDrawFancyText});

        this.MenuItem1.Text = "Action";

        //

        //miDrawLine

        //

        this.miDrawLine.Index = 0;

        this.miDrawLine.Text = "Draw Line";

		this.miDrawLine.Click += new EventHandler(miDrawLine_Click);

        //

        //miDrawCircle

        //

        this.miDrawCircle.Index = 1;

        this.miDrawCircle.Text = "Draw Circle";

		this.miDrawCircle.Click += new EventHandler(miDrawCircle_Click);

        //

        //miDrawRectangle

        //

        this.miDrawRectangle.Index = 2;

        this.miDrawRectangle.Text = "Draw Rectangle";

		this.miDrawRectangle.Click += new EventHandler(miDrawRectangle_Click);

        //

        //miDrawText

        //

        this.miDrawText.Index = 3;

        this.miDrawText.Text = "Draw Text";

		this.miDrawText.Click += new EventHandler(miDrawText_Click);

        //

        //miDrawFancyText

        //

        this.miDrawFancyText.Index = 4;

        this.miDrawFancyText.Text = "Draw Fancy Text";

		this.miDrawFancyText.Click += new EventHandler(miDrawFancyText_Click);

        //

        //picDrawing

        //

        this.picDrawing.Location = new System.Drawing.Point(104, 24);

        this.picDrawing.Name = "picDrawing";

        this.picDrawing.Size = new System.Drawing.Size(424, 312);

        this.picDrawing.TabIndex = 0;

        this.picDrawing.TabStop = false;

        //

        //frmGraphics

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(554, 360);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.picDrawing});

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Menu = this.MainMenu1;

        this.Name = "frmGraphics";

        this.Text = "Graphics Support";

        this.ResumeLayout(false);
		this.Load += new EventHandler(frmGraphics_Load);

    }

#endregion

    private void miDrawLine_Click(object sender, System.EventArgs e) 
	{
        picDrawing.CreateGraphics().Clear(this.BackColor);
        Graphics g = picDrawing.CreateGraphics();
        Pen p = new Pen(Color.Blue, 6);
        g.DrawLine(p, 100, 100, 50, 150);
        g.Dispose();
    }

    private void frmGraphics_Load(object sender, System.EventArgs e) 
	{
        drawX = Convert.ToInt32((ClientSize.Width / 2) + 50);
        drawY = Convert.ToInt32((ClientSize.Height / 2) + 50);
    }

    private void miDrawCircle_Click(object sender, System.EventArgs e) 
	{
        picDrawing.CreateGraphics().Clear(this.BackColor);
        Graphics g = picDrawing.CreateGraphics();
        Pen p = new Pen(Color.Red, 3);
        g.DrawEllipse(p, 120, 120, 100, 100);
        g.Dispose();
    }

    private void miDrawRectangle_Click(object sender, System.EventArgs e) 
	{
        picDrawing.CreateGraphics().Clear(this.BackColor);
        Graphics g = picDrawing.CreateGraphics();
        Pen p = new Pen(Color.Green, 3);
        g.DrawRectangle(p, 150, 150, 100, 100);
        g.Dispose();
    }

    private void miDrawText_Click(object sender, System.EventArgs e) 
	{
        picDrawing.CreateGraphics().Clear(this.BackColor);
        Graphics g = picDrawing.CreateGraphics();
        g.DrawString("C#.NET", new Font("Arial", 20), Brushes.Blue, 135, 135);
        g.Dispose();

    }

    private void miDrawFancyText_Click(object sender, System.EventArgs e) 
	{
        picDrawing.CreateGraphics().Clear(this.BackColor);
        Graphics g = picDrawing.CreateGraphics();
        SolidBrush b1 = new SolidBrush(Color.FromArgb(80, 10, 255, 100));
        g.DrawString("C#.NET", new Font("Arial", 30), b1, 135, 135);
        SolidBrush b2 = new SolidBrush(Color.FromArgb(80, 100, 255, 100));
        g.DrawString("C#.NET", new Font("Arial", 20), b2, 150, 150);
        SolidBrush b3 = new SolidBrush(Color.FromArgb(80, 10, 255, 100));
        g.DrawString("C#.NET", new Font("Arial", 10), b3, 170, 170);
        g.Dispose();
    }
}

