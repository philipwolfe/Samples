using System;
using System.Windows.Forms;
using System.Drawing;

// This form is the main form for the screen saver. It does all the painting
//   of the screen, and handles when it should terminate and release control 
//   back to Windows.

public class frmSceenSaver : System.Windows.Forms.Form 
{
	// Declare the class variables that will be used for the Screen
	//   Saver.
	private Graphics m_Graphics ;  //' Graphics object on which to draw;
	private Random m_Random = new Random();  //' Random object to support the drawing;
	// Options object that contains information about the user selected options
	private Options m_Options = new Options();
	// Used to for first setting MouseMove location
	private bool m_IsActive = false;
	// Used to determine if the Mouse has actually been moved
	private Point m_MouseLocation;

	#region " Windows Form Designer generated code "

	public frmSceenSaver() 
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing) 
	{
		if (disposing) 
		{
			if (components != null) 
			{
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

	private System.Windows.Forms.Timer tmrUpdateScreen;

	private void InitializeComponent() 
	{

		this.components = new System.ComponentModel.Container();

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSceenSaver));

		this.tmrUpdateScreen = new System.Windows.Forms.Timer(this.components);

		this.tmrUpdateScreen.Tick += new EventHandler(tmrUpdateScreen_Tick);

		//

		//tmrUpdateScreen

		//

		//

		//frmSceenSaver

		//

		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");

		this.AccessibleName = resources.GetString("$this.AccessibleName");

		this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

		this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

		this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

		this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

		this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

		this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

		this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

		this.ControlBox = false;

		this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

		this.Enabled = (bool) resources.GetObject("$this.Enabled");

		this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

		this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

		this.MaximizeBox = false;

		this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

		this.MinimizeBox = false;

		this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

		this.Name = "frmSceenSaver";

		this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

		this.ShowInTaskbar = false;

		this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;

		this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

		this.Text = resources.GetString("$this.Text");

		this.TopMost = true;

		this.Visible = (bool) resources.GetObject("$this.Visible");

		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		base.MouseMove += new MouseEventHandler(frmSceenSaver_MouseMove);

		base.Load += new EventHandler(frmSceenSaver_Load);

		base.MouseDown += new MouseEventHandler(frmSceenSaver_MouseDown);

	}

	#endregion

	// Close the screen saver when the user moves the mouse. Unfortunately, the 
	//   MouseMove event is fired by some very trivial moves of the mouse, so 
	//   instead, verify that the mouse has actually been moved by at least
	//   a few pixels before exiting.
	private void frmSceenSaver_MouseMove(object sender,System.Windows.Forms.MouseEventArgs e ) //base.MouseMove;
	{
		// if the MouseLocation still points to 0,0, move it to its actual location
		//   and save the location for later. Otherwise, check to see if the user
		//   has moved the mouse at least 10 pixels.

		if (! m_IsActive) 
		{
			this.m_MouseLocation = new Point(e.X, e.Y);
			m_IsActive = true;
		}
		else 
		{
			if ((Math.Abs(e.X - this.m_MouseLocation.X) > 10) || 
				(Math.Abs(e.Y - this.m_MouseLocation.Y) > 10 ))
			{
				// The user has moved the mouse so leave this program
				Application.Exit();
			}
		}
	}

	// This subroutine initializes the Screen Saver form when it is loaded

	private void frmSceenSaver_Load(object sender, System.EventArgs e) //base.Load;
	{
		// Create the Graphics object to use when drawing.
		this.m_Graphics = this.CreateGraphics();
		// Load the Saved options. Remember that if no Options file exists, one
		//   will be created.
		m_Options.LoadOptions();
		// Set the speed based on the user defined Options.
		switch( m_Options.Speed)
		{
			case "Slow":
				this.tmrUpdateScreen.Interval = 500;
				break;
			case "Fast":
				this.tmrUpdateScreen.Interval = 100;
				break;
			default: 
			{
				this.tmrUpdateScreen.Interval = 200;
				break;
			}
		}
		// Enable the timer.
		this.tmrUpdateScreen.Enabled = true;
	}

	// The subroutine causes the screen saver to close if the user 
	//   pushes a mouse button.
	private void frmSceenSaver_MouseDown(object sender,System.Windows.Forms.MouseEventArgs e ) //base.MouseDown;
	{
		Application.Exit();
	}

	// This code is executed whenever the timer tick event if fired. It draws
	//   a shape to the screen.
	private void tmrUpdateScreen_Tick(object sender, System.EventArgs e) 
	{
		DrawShape();
	}
	// --- class Methods ---
	// This subroutine just draws a randomly colored, randomly sized, shapes to 
	//   the screen, based on some user defined parameters.
	private void DrawShape()
	{
		// Get the largest possible values for the screen
		int maxX  = this.Width;
		int maxY  = this.Height;
		int x1, x2, y1, y2;  //' Coordinates of random points;
		Rectangle myRect;  //' Rectangle to paint the shapes;
		Color myColor;  //' Color used to paint the shapes;
		// Generate some random numbers to use coordinates
		x1 = m_Random.Next(0, maxX);
		x2 = m_Random.Next(0, maxX);
		y1 = m_Random.Next(0, maxY);
		y2 = m_Random.Next(0, maxY);
		// Create a rectangle based on the randomly generated coordinates
		myRect = new Rectangle(Math.Min(x1, x2), Math.Min(y1, y2),
			Math.Abs(x1 - x2), Math.Abs(y1 - y2));

		// Get a random color. if the user wants transparency then allow the
		//   transparency to be randomly generated well.  if not, then set the
		//   Alpha to 255 (the max).

		if (m_Options.IsTransparent)
		{
			myColor = Color.FromArgb(m_Random.Next(255), m_Random.Next(255),
				m_Random.Next(255), m_Random.Next(255));
		}
		else 
		{
			myColor = Color.FromArgb(255, m_Random.Next(255),
				m_Random.Next(255), m_Random.Next(255));
		}
		// Draw an Ellipse or rectangle based on User defined options.

		if (m_Options.Shape == "Ellipses")
		{
			m_Graphics.FillEllipse(new SolidBrush(myColor), myRect);
		}
		else 
		{
			m_Graphics.FillRectangle(new SolidBrush(myColor), myRect);
		}
	}
	// This sub is the first one that executes when the Screen Saver 
	//   program is run.  Since Windows will pass parameters to the this
	//   program whenever a user is setting up the screen saver using the 
	//   Display Properties -> Screen Saver property screen.
	[STAThread()] static void Main(string[] args)
	{
		// Check to see if there were any passed arguments. if not, then
		//   the user simply double-clicked on the .scr file.

		if (args.Length > 0)
		{
			// This means we have some passed arguments.  Windows will
			//   automatically pass a "/s", "/p" or a "/c" depending
			//   on how the screen saver should behave.  The meanings for each
			//   of these parameters is seen below.
			// Check to see if the Screen saver should preview.

			if (args[0].ToLower() == "/p") 
			{
				// This functionality is not implemented here because it involves
				//   creating and joining threads and is beyond the scope of this
				//   How-To.
				// Simply exit the application
				Application.Exit();
			}
			// Check to see if the Screen saver should show user definable options.
			if (args[0].ToLower().Trim().Substring(0, 2) == "/c") 
			{
				// Create a frmOptions form and display it.
				frmOptions userOptionsForm = new frmOptions();
				userOptionsForm.ShowDialog();
				// Exit the application.
				Application.Exit();
			}

			// Check to see if the Screen saver should simply execute
			if (args[0].ToLower() == "/s")
			{
				// Create a frmSceenSaver form and display it.
				frmSceenSaver screenSaverForm = new frmSceenSaver();
				screenSaverForm.ShowDialog();
				// Exit the application when the form is closed
				Application.Exit();
			}
		}
		else 
		{
			// Fire up the Screen saver.  Note: This is only used when the user
			//   Double clicks on the EXE, since otherwise windows passes a
			//   parameter to the application.
			// Create a frmSceenSaver form and display it.
			frmSceenSaver screenSaverForm = new frmSceenSaver();
			screenSaverForm.ShowDialog();
			// Exit the application when the form is closed
			Application.Exit();
		}
	}
}


